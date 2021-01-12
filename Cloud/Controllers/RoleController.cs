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
    public class RoleController : ApiController
    {
        [HttpGet]
        [Route("api/Role/GetList")]
        public object GetList()
        {
            ServiceResult result = new ServiceResult();
            List<Role> items;
            try
            {
                items = new BLRole().GetRole();
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