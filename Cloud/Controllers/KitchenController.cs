using QuizBit.BL;
using QuizBit.Contract;
using QuizBit.Entity;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Cloud.Controllers
{
    [Authorize]
    public class KitchenController : ApiController
    {
        [HttpPost]
        [Route("api/Kitchen/InsertUpdate")]
        public object InsertUpdateKitchen([FromBody] Kitchen item)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Success = new BLKitchen().InsertUpdateKitchen(item);
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
        [Route("api/Kitchen/Delete")]
        public object DeleteKitchen([FromBody] Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Success = new BLKitchen().DeleteKitchen(itemID);          
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
        [Route("api/Kitchen/CheckBeforeDelete")]
        public object CheckBeforeDeleteKitchen([FromBody] Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Success = new BLKitchen().CheckBeforeDeleteKitchen(itemID);
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
        [Route("api/Kitchen/GetByID")]
        public object GetKitchenByID(Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            List<Kitchen> items;
            try
            {
                items = new BLKitchen().GetKitchen(itemID);
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
        [Route("api/Kitchen/GetList")]
        public object GetKitchens()
        {
            ServiceResult result = new ServiceResult();
            List<Kitchen> items;
            try
            {
                items = new BLKitchen().GetKitchens();
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