using QuizBit.Contract;
using QuizBit.Entity;
using QuizBit.BL;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace Cloud.Controllers
{
    public class LoginController : ApiController
    {
        /// <summary>
        /// Đăng nhập
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Authenticate([FromBody] UserLogin login)
        {
            IHttpActionResult response;
            HttpResponseMessage httpResponse = null;

            if (login != null)
                login = new BLLogin().Login(login.UserName, EncryptUtil.MD5Hash(login.Password));

            if (login != null)
            {
                // Tài khoản mật khẩu hợp lệ thì Tạo Token
                string token = CreateToken(login.UserName);
                // return Ok<string>(token);
                httpResponse = Request.CreateResponse(HttpStatusCode.OK, new ServiceResult(true, null, token, null));
            }
            else
            {
                // Nếu không hợp lệ thì trả về lỗi
                httpResponse = Request.CreateResponse(HttpStatusCode.Unauthorized, new ServiceResult(false, ErrorCode.InvalidPassword));
            }
            response = ResponseMessage(httpResponse);
            return response;
        }

        /// <summary>
        /// Đăng nhập
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/login/getuser")]
        public object Get([FromBody] UserLogin login)
        {
            ServiceResult result = new ServiceResult();

            if (login != null)
                login = new BLLogin().Login(login.UserName, EncryptUtil.MD5Hash(login.Password));

            if (login != null)
            {
                result.Data = login;
            }
            else
            {
                result.Success = false;
                result.ErrorCode = ErrorCode.InvalidPassword;
            }
            return result;
        }

        /// <summary>
        /// Khởi tạo Token
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        private string CreateToken(string username)
        {
            //Set issued at date
            DateTime issuedAt = DateTime.UtcNow;
            //set the time when it expires
            string[] lstExpires = Constant.TokenExpires.Split('.');
            DateTime expires = DateTime.UtcNow.AddDays(Convert.ToDouble(lstExpires[0])).AddHours(Convert.ToDouble(lstExpires[1])).AddMinutes(Convert.ToDouble(lstExpires[2]));

            // http://stackoverflow.com/questions/18223868/how-to-encrypt-jwt-security-token
            var tokenHandler = new JwtSecurityTokenHandler();

            //create a identity and add claims to the user which we want to log in
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username)
            });

            var now = DateTime.UtcNow;
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(CommonKey.SecureKey));
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);

            //create the jwt
            var token = (JwtSecurityToken)
                tokenHandler.CreateJwtSecurityToken(issuer: CommonKey.WebUrl,
                audience: CommonKey.WebUrl,
                subject: claimsIdentity,
                notBefore: issuedAt,
                expires: expires,
                signingCredentials: signingCredentials);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
