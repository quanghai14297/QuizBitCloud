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
    public class OrderController : ApiController
    {
        [HttpPost]
        [Route("api/Order/InsertUpdateOrderEntity")]
        public object InsertUpdateOrderEntity([FromBody] OrderEntity item)
        {
            ServiceResult result = new ServiceResult();
            DLOrder dLOrder = new DLOrder();

            try
            {
                result.Success = new BLOrder().InsertUpdateOrderEntity(item);
                //if (dLOrder.checkIfExistOrderNo(item.order))
                //{
                //    result.Success = false;
                //    result.ErrorCode = ErrorCode.DuplicateCode;
                //}
                //else
                //{
                    
                //}

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
        [Route("api/Order/InsertUpdate")]
        public object InsertUpdateOrder([FromBody] Order item)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Success = new BLOrder().InsertUpdateOrder(item);
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
        [Route("api/Order/RequestPayOrder")]
        public object RequestPayOrder([FromBody] Guid orderID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Success = new DLOrder().RequestPayOrder(orderID);
            }
            catch (Exception ex)
            {
                CommonFunction.WriteLog(ex, SerializeUtil.Serialize(orderID), Request.RequestUri.ToString());
                result.Success = false;
                result.ErrorCode = ex.Message;
            }
            return result;
        }


        [HttpPost]
        [Route("api/Order/CheckOrderIsSendKitchen")]
        public object CheckOrderIsSendKitchen([FromBody] Guid orderID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Success = new DLOrder().checkOrderIsSendKitchen(orderID);
            }
            catch (Exception ex)
            {
                CommonFunction.WriteLog(ex, SerializeUtil.Serialize(orderID), Request.RequestUri.ToString());
                result.Success = false;
                result.ErrorCode = ex.Message;
            }
            return result;
        }


        [HttpPost]
        [Route("api/Order/CancelOrder")]
        public object CancelOrder([FromBody] CancelOrderRequest cancelOrderRequest)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Success = new DLOrder().CancelOrder(cancelOrderRequest);
            }
            catch (Exception ex)
            {
                CommonFunction.WriteLog(ex, SerializeUtil.Serialize(cancelOrderRequest.ToString()), Request.RequestUri.ToString());
                result.Success = false;
                result.ErrorCode = ex.Message;
            }
            return result;
        }

        [HttpPost]
        [Route("api/Order/CheckBeforeDelete")]
        public object CheckBeforeDeleteOrder([FromBody] Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Success = new BLOrder().CheckBeforeDeleteOrder(itemID);
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
        [Route("api/Order/GetByID")]
        public object GetOrderByID(Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            List<Order> items;
            try
            {
                items = new BLOrder().GetOrder(itemID);
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
        [Route("api/Order/GetList")]
        public object GetOrders()
        {
            ServiceResult result = new ServiceResult();
            List<OrderResponse> items;
            try
            {
                items = new BLOrder().GetOrdersToday();
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


        [HttpGet]
        [Route("api/Order/GetOrdersByOrderStatus")]
        public object GetOrdersByOrderStatus(int orderStatus)
        {
            ServiceResult result = new ServiceResult();
            List<OrderResponse> items;
            try
            {
                items = new BLOrder().GetOrdersTodayWithOrderStatus(orderStatus);
                result.Success = true;
                result.Data = items;
            }
            catch (Exception ex)
            {
                CommonFunction.WriteLog(ex, SerializeUtil.Serialize(orderStatus + ""), Request.RequestUri.ToString());
                result.Success = false;
                result.ErrorCode = ex.Message;
            }
            return result;
        }


        [HttpGet]
        [Route("api/Order/GetOrderNo")]
        public object GetOrderNo()
        {
            ServiceResult result = new ServiceResult();
            string orderNo = "";
            try
            {
                orderNo = new DLOrder().getOrderNo();
                result.Success = true;
                result.Data = orderNo;
            }
            catch (Exception ex)
            {
                CommonFunction.WriteLog(ex, SerializeUtil.Serialize(orderNo + ""), Request.RequestUri.ToString());
                result.Success = false;
                result.ErrorCode = ex.Message;
            }
            return result;
        }

        [HttpGet]
        [Route("api/Order/GetOrderDetailsByOrderID")]
        public object GetOrderDetailsByOrderID(Guid orderID)
        {
            ServiceResult result = new ServiceResult();
            List<OrderDetail> items;
            try
            {
                items = new DLOrder().GetOrderDetailsByOrderID(orderID);
                result.Success = true;
                result.Data = items;
            }
            catch (Exception ex)
            {
                CommonFunction.WriteLog(ex, SerializeUtil.Serialize(orderID + ""), Request.RequestUri.ToString());
                result.Success = false;
                result.ErrorCode = ex.Message;
            }
            return result;
        }


    }
}