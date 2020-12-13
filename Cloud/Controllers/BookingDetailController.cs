using QuizBit.BL;
using QuizBit.Contract;
using QuizBit.Entity;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Cloud.Controllers
{
    [Authorize]
    public class BookingDetailController : ApiController
    {
        [HttpPost]
        [Route("api/BookingDetail/InsertUpdate")]
        public object InsertUpdateBookingDetail([FromBody] BookingDetail item)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Success = new BLBookingDetail().InsertUpdateBookingDetail(item);
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
        [Route("api/BookingDetail/Delete")]
        public object DeleteBookingDetail([FromBody] Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Success = new BLBookingDetail().DeleteBookingDetail(itemID);          
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
        [Route("api/BookingDetail/CheckBeforeDelete")]
        public object CheckBeforeDeleteBookingDetail([FromBody] Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Success = new BLBookingDetail().CheckBeforeDeleteBookingDetail(itemID);
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
        [Route("api/BookingDetail/GetByID")]
        public object GetBookingDetailByID(Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            List<BookingDetail> items;
            try
            {
                items = new BLBookingDetail().GetBookingDetail(itemID);
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
        [Route("api/BookingDetail/GetList")]
        public object GetBookingDetails()
        {
            ServiceResult result = new ServiceResult();
            List<BookingDetail> items;
            try
            {
                items = new BLBookingDetail().GetBookingDetails();
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