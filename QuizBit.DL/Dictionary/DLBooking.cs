using QuizBit.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.DL
{
    public class DLBooking : DLBase
    {
        public DLBooking()
        {
            TableName = "Booking";
            ObjectIDParam = "@BookingID";
            InitStored();
        }
    }
}
