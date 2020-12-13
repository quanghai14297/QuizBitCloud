using QuizBit.BL;
using QuizBit.Contract;
using QuizBit.Entity;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Cloud.Controllers
{
    [Authorize]
    public class OrderDetailController : ApiController
    {
        [HttpPost]
        [Route("api/OrderDetail/InsertUpdate")]
        public object InsertUpdateOrderDetail([FromBody] OrderDetail item)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Success = new BLOrderDetail().InsertUpdateOrderDetail(item);
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
        [Route("api/OrderDetail/Delete")]
        public object DeleteOrderDetail([FromBody] Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Success = new BLOrderDetail().DeleteOrderDetail(itemID);          
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
        [Route("api/OrderDetail/CheckBeforeDelete")]
        public object CheckBeforeDeleteOrderDetail([FromBody] Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Success = new BLOrderDetail().CheckBeforeDeleteOrderDetail(itemID);
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
        [Route("api/OrderDetail/GetByID")]
        public object GetOrderDetailByID(Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            List<OrderDetail> items;
            try
            {
                items = new BLOrderDetail().GetOrderDetail(itemID);
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
        [Route("api/OrderDetail/GetList")]
        public object GetOrderDetails()
        {
            ServiceResult result = new ServiceResult();
            List<OrderDetail> items;
            try
            {
                items = new BLOrderDetail().GetOrderDetails();
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