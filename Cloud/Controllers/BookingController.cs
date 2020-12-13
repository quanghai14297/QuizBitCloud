using QuizBit.BL;
using QuizBit.Contract;
using QuizBit.Entity;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Cloud.Controllers
{
    [Authorize]
    public class BookingController : ApiController
    {
        [HttpPost]
        [Route("api/Booking/InsertUpdate")]
        public object InsertUpdateBooking([FromBody] Booking item)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Success = new BLBooking().InsertUpdateBooking(item);
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
        [Route("api/Booking/Delete")]
        public object DeleteBooking([FromBody] Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Success = new BLBooking().DeleteBooking(itemID);          
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
        [Route("api/Booking/CheckBeforeDelete")]
        public object CheckBeforeDeleteBooking([FromBody] Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Success = new BLBooking().CheckBeforeDeleteBooking(itemID);
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
        [Route("api/Booking/GetByID")]
        public object GetBookingByID(Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            List<Booking> items;
            try
            {
                items = new BLBooking().GetBooking(itemID);
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
        [Route("api/Booking/GetList")]
        public object GetBookings()
        {
            ServiceResult result = new ServiceResult();
            List<Booking> items;
            try
            {
                items = new BLBooking().GetBookings();
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