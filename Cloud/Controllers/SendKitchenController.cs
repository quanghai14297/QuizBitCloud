using QuizBit.BL;
using QuizBit.Contract;
using QuizBit.Entity;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Cloud.Controllers
{
    [Authorize]
    public class SendKitchenController : ApiController
    {
        [HttpPost]
        [Route("api/SendKitchen/InsertUpdate")]
        public object InsertUpdateSendKitchen([FromBody] SendKitchen item)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Success = new BLSendKitchen().InsertUpdateSendKitchen(item);
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
        [Route("api/SendKitchen/Delete")]
        public object DeleteSendKitchen([FromBody] Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Success = new BLSendKitchen().DeleteSendKitchen(itemID);          
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
        [Route("api/SendKitchen/CheckBeforeDelete")]
        public object CheckBeforeDeleteSendKitchen([FromBody] Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Success = new BLSendKitchen().CheckBeforeDeleteSendKitchen(itemID);
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
        [Route("api/SendKitchen/GetByID")]
        public object GetSendKitchenByID(Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            List<SendKitchen> items;
            try
            {
                items = new BLSendKitchen().GetSendKitchen(itemID);
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
        [Route("api/SendKitchen/GetList")]
        public object GetSendKitchens()
        {
            ServiceResult result = new ServiceResult();
            List<SendKitchen> items;
            try
            {
                items = new BLSendKitchen().GetSendKitchens();
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