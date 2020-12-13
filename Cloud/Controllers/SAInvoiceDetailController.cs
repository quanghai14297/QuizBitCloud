using QuizBit.BL;
using QuizBit.Contract;
using QuizBit.Entity;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Cloud.Controllers
{
    [Authorize]
    public class SAInvoiceDetailController : ApiController
    {
        [HttpPost]
        [Route("api/SAInvoiceDetail/InsertUpdate")]
        public object InsertUpdateSAInvoiceDetail([FromBody] SAInvoiceDetail item)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Success = new BLSAInvoiceDetail().InsertUpdateSAInvoiceDetail(item);
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
        [Route("api/SAInvoiceDetail/Delete")]
        public object DeleteSAInvoiceDetail([FromBody] Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Success = new BLSAInvoiceDetail().DeleteSAInvoiceDetail(itemID);          
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
        [Route("api/SAInvoiceDetail/CheckBeforeDelete")]
        public object CheckBeforeDeleteSAInvoiceDetail([FromBody] Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Success = new BLSAInvoiceDetail().CheckBeforeDeleteSAInvoiceDetail(itemID);
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
        [Route("api/SAInvoiceDetail/GetByID")]
        public object GetSAInvoiceDetailByID(Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            List<SAInvoiceDetail> items;
            try
            {
                items = new BLSAInvoiceDetail().GetSAInvoiceDetail(itemID);
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
        [Route("api/SAInvoiceDetail/GetList")]
        public object GetSAInvoiceDetails()
        {
            ServiceResult result = new ServiceResult();
            List<SAInvoiceDetail> items;
            try
            {
                items = new BLSAInvoiceDetail().GetSAInvoiceDetails();
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