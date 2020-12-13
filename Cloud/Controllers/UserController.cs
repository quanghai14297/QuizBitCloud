using QuizBit.BL;
using QuizBit.Contract;
using QuizBit.DL;
using QuizBit.Entity;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Cloud.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        [HttpPost]
        [Route("api/User/InsertUpdate")]
        public object InsertUpdateUser([FromBody] User item)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                if (new BLUser().CheckCodeExists(item.UserID, item.UserName))
                {
                    result.Success = false;
                    result.ErrorCode = ErrorCode.DuplicateCode;
                }
                else
                {
                    result.Success = new BLUser().InsertUpdateUser(item);
                }
            }
            catch (Exception ex)
            {
                CommonFunction.WriteLog(ex, SerializeUtil.Serialize(item), Request.RequestUri.ToString());
                result.Success = false;
                result.ErrorCode = ex.Message;
            }
            return result;
        }


        [HttpPost]
        [Route("api/User/ChangePassword")]
        public object ChangePassword([FromBody] ChangePasswordRequest changePasswordRequest)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Success = new DLUser().ChangePassword(changePasswordRequest);
            }
            catch (Exception ex)
            {
                CommonFunction.WriteLog(ex, SerializeUtil.Serialize(changePasswordRequest.UserName), Request.RequestUri.ToString());
                result.Success = false;
                result.ErrorCode = ex.Message;
            }
            return result;
        }

        [HttpPost]
        [Route("api/Unit/CheckCodeExists")]
        public object CheckCodeExists([FromBody] User item)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                // Đây là check Tồn tại - nếu tồn tại thì trả true, không thì trả false
                // không phải lỗi
                if (new BLUser().CheckCodeExists(item.UserID, item.UserName))
                    result.Success = true;
                else
                    result.Success = false;
            }
            catch (Exception ex)
            {
                CommonFunction.WriteLog(ex, SerializeUtil.Serialize(item), Request.RequestUri.ToString());
                result.Success = false;
                result.ErrorCode = ex.Message;
            }
            return result;
        }

        [HttpPost]
        [Route("api/User/Delete")]
        public object DeleteUser([FromBody] Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Success = new BLUser().DeleteUser(itemID);
            }
            catch (Exception ex)
            {
                CommonFunction.WriteLog(ex, SerializeUtil.Serialize(itemID), Request.RequestUri.ToString());
                result.Success = false;
                result.ErrorCode = ex.Message;
            }
            return result;
        }

        [HttpPost]
        [Route("api/User/CheckBeforeDelete")]
        public object CheckBeforeDeleteUser([FromBody] Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Success = new BLUser().CheckBeforeDeleteUser(itemID);
            }
            catch (Exception ex)
            {
                CommonFunction.WriteLog(ex, itemID.ToString(), Request.RequestUri.ToString());
                result.Success = false;
                result.ErrorCode = ex.Message;
            }
            return result;
        }

        [HttpGet]
        [Route("api/User/GetByID")]
        public object GetUserByID(Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            List<User> items;
            try
            {
                items = new BLUser().GetUser(itemID);
                result.Success = true;
                result.Data = items;
            }
            catch (Exception ex)
            {
                CommonFunction.WriteLog(ex, SerializeUtil.Serialize(itemID), Request.RequestUri.ToString());
                result.Success = false;
                result.ErrorCode = ex.Message;
            }
            return result;
        }

        [HttpGet]
        [Route("api/User/GetList")]
        public object GetUsers()
        {
            ServiceResult result = new ServiceResult();
            List<User> items;
            try
            {
                items = new BLUser().GetUsers();
                result.Success = true;
                result.Data = items;
            }
            catch (Exception ex)
            {
                CommonFunction.WriteLog(ex, SerializeUtil.Serialize(""), Request.RequestUri.ToString());
                result.Success = false;
                result.ErrorCode = ex.Message;
            }
            return result;
        }
    }
}