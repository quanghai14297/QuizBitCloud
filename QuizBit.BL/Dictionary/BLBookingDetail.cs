using QuizBit.DL;
using QuizBit.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.BL
{
    public class BLBookingDetail : BLBase
    {

        public bool InsertUpdateBookingDetail(BookingDetail item)
        {
            return new DLBookingDetail().InsertUpdateObject(item);
        }

        public bool DeleteBookingDetail(Guid itemID)
        {
            return new DLBookingDetail().DeleteObject(itemID);
        }

        public bool CheckBeforeDeleteBookingDetail(Guid itemID)
        {
            return new DLBookingDetail().CheckBeforeDeleteObject(itemID);
        }

        public List<BookingDetail> GetBookingDetail(Guid itemID)
        {
            return new DLBookingDetail().GetObjectByID<BookingDetail, Guid>(itemID);
        }

        public List<BookingDetail> GetBookingDetails()
        {
            return new DLBookingDetail().GetListObject<BookingDetail>();
        }
    }
}
