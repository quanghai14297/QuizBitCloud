using QuizBit.BL;
using QuizBit.Contract;
using QuizBit.Entity;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Cloud.Controllers
{
    [Authorize]
    public class CustomerController : ApiController
    {
        [HttpPost]
        [Route("api/Customer/InsertUpdate")]
        public object InsertUpdateCustomer([FromBody] Customer item)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                if (new BLCustomer().CheckCodeExists(item.CustomerID, item.CustomerCode))
                {
                    result.Success = false;
                    result.ErrorCode = ErrorCode.DuplicateCode;
                }
                else
                    result.Success = new BLCustomer().InsertUpdateCustomer(item);
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
        [Route("api/Customer/Delete")]
        public object DeleteCustomer([FromBody] Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                if (new BLCustomer().CheckBeforeDeleteCustomer(itemID))
                {
                    result.Success = false;
                    result.ErrorCode = ErrorCode.ItemWasUsed;
                }
                else
                    result.Success = new BLCustomer().DeleteCustomer(itemID);
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
        [Route("api/Customer/CheckBeforeDelete")]
        public object CheckBeforeDeleteCustomer([FromBody] Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Success = new BLCustomer().CheckBeforeDeleteCustomer(itemID);
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
        [Route("api/Customer/GetByID")]
        public object GetCustomerByID(Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            List<Customer> items;
            try
            {
                items = new BLCustomer().GetCustomer(itemID);
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
        [Route("api/Customer/GetList")]
        public object GetCustomers()
        {
            ServiceResult result = new ServiceResult();
            List<Customer> items;
            try
            {
                items = new BLCustomer().GetCustomers();
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