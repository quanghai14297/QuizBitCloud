using QuizBit.DL;
using QuizBit.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.BL
{
    public class BLBooking : BLBase
    {

        public bool InsertUpdateBooking(Booking item)
        {
            return new DLBooking().InsertUpdateObject(item);
        }

        public bool DeleteBooking(Guid itemID)
        {
            return new DLBooking().DeleteObject(itemID);
        }

        public bool CheckBeforeDeleteBooking(Guid itemID)
        {
            return new DLBooking().CheckBeforeDeleteObject(itemID);
        }

        public List<Booking> GetBooking(Guid itemID)
        {
            return new DLBooking().GetObjectByID<Booking, Guid>(itemID);
        }

        public List<Booking> GetBookings()
        {
            return new DLBooking().GetListObject<Booking>();
        }
    }
}
