using Microsoft.IdentityModel.Tokens;
using QuizBit.Contract;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Cloud.Authen
{
    public class TokenValidationHandler : DelegatingHandler
    {

        /// <summary>
        /// Nhận request và Validate
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpStatusCode statusCode;
            string token;
            string message = "";

            // Kiểm tra Token có tồn tại không
            if (!TryRetrieveToken(request, out token))
            {
                // Không tồn tại thì gán lại Mã lỗi và SendAsync để trả về Message
                statusCode = HttpStatusCode.Unauthorized;
                // SendAsync
                // Nếu Controller có [Authorize] thì trả về "Message": "Authorization has been denied for this request."
                // Nếu Controller không có [Authorize] thì gọi API như bình thường
                return base.SendAsync(request, cancellationToken);
            }

            // Tồn tại Token thì Validate LifeTime
            try
            {
                var now = DateTime.UtcNow;
                var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(CommonKey.SecureKey));

                SecurityToken securityToken;
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                TokenValidationParameters validationParameters = new TokenValidationParameters()
                {
                    ValidAudience = CommonKey.WebUrl,
                    ValidIssuer = CommonKey.WebUrl,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    LifetimeValidator = this.LifetimeValidator,
                    IssuerSigningKey = securityKey
                };
                //extract and assign the user of the jwt
                HttpContext.Current.User = handler.ValidateToken(token, validationParameters, out securityToken);
                Thread.CurrentPrincipal = handler.ValidateToken(token, validationParameters, out securityToken);

                return base.SendAsync(request, cancellationToken);
            }
            catch (SecurityTokenValidationException ex)
            {
                CommonFunction.WriteLog(ex, objectName: request.RequestUri.ToString());
                statusCode = HttpStatusCode.Unauthorized;
                if (ex.Message.Contains("Lifetime validation failed"))
                    message = ErrorCode.TokenTimeout;
                else if (ex.Message.Contains("Signature validation failed"))
                    message = ErrorCode.InvalidToken;
                else message = ex.Message;
            }
            catch (Exception ex)
            {
                CommonFunction.WriteLog(ex, objectName: request.RequestUri.ToString());
                if (ex.Message.Contains("Unable to decode the header"))
                {
                    statusCode = HttpStatusCode.Unauthorized;
                }
                else statusCode = HttpStatusCode.InternalServerError;

                message = ex.Message;
            }
            HttpResponseMessage httpResponse = request.CreateResponse(statusCode,
                new ServiceResult(false, statusCode.ToString(), null, message));
            return Task<HttpResponseMessage>.Factory.StartNew(() => httpResponse);
        }

        /// <summary>
        /// Kiểm tra Token có tồn tại không
        /// </summary>
        /// <param name="request"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        private static bool TryRetrieveToken(HttpRequestMessage request, out string token)
        {
            token = null;
            IEnumerable<string> authzHeaders;
            if (!request.Headers.TryGetValues("Authorization", out authzHeaders) || authzHeaders.Count() > 1)
            {
                return false;
            }
            var bearerToken = authzHeaders.ElementAt(0);
            token = bearerToken.StartsWith("Bearer ") ? bearerToken.Substring(7) : bearerToken;
            return true;
        }

        /// <summary>
        /// Kiểm tra thời gian Token
        /// </summary>
        /// <param name="notBefore"></param>
        /// <param name="expires"></param>
        /// <param name="securityToken"></param>
        /// <param name="validationParameters"></param>
        /// <returns></returns>
        public bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            // Validate lần cuối đổi mật khẩu
            // Nếu thời gian tạo token < Thời gian đổi mật khẩu cuối thì Token không đăng nhập được
            if (notBefore != null)
            {
                var username = (((JwtSecurityToken)securityToken).Payload["unique_name"] ?? "").ToString();
                var lasttime = new QuizBit.BL.BLLogin().GetTimeLastChangedPassword(username);
                if (lasttime == DateTime.MinValue || lasttime > notBefore) return false;
            }
            // Validate thời hạn sử dụng Token
            if (expires != null)
            {
                if (DateTime.UtcNow < expires) return true;
            }
            return false;
        }
    }
}