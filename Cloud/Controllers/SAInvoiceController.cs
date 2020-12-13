using QuizBit.BL;
using QuizBit.Contract;
using QuizBit.Entity;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Cloud.Controllers
{
    [Authorize]
    public class SAInvoiceController : ApiController
    {
        [HttpPost]
        [Route("api/SAInvoice/InsertUpdate")]
        public object InsertUpdateSAInvoice([FromBody] SAInvoice item)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Success = new BLSAInvoice().InsertUpdateSAInvoice(item);
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
        [Route("api/SAInvoice/Delete")]
        public object DeleteSAInvoice([FromBody] Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Success = new BLSAInvoice().DeleteSAInvoice(itemID);          
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
        [Route("api/SAInvoice/CheckBeforeDelete")]
        public object CheckBeforeDeleteSAInvoice([FromBody] Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Success = new BLSAInvoice().CheckBeforeDeleteSAInvoice(itemID);
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
        [Route("api/SAInvoice/GetByID")]
        public object GetSAInvoiceByID(Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            List<SAInvoice> items;
            try
            {
                items = new BLSAInvoice().GetSAInvoice(itemID);
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
        [Route("api/SAInvoice/GetList")]
        public object GetSAInvoices()
        {
            ServiceResult result = new ServiceResult();
            List<SAInvoice> items;
            try
            {
                items = new BLSAInvoice().GetSAInvoices();
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