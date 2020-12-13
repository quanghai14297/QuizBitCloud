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
    public class DLBookingDetail : DLBase
    {
        public DLBookingDetail()
        {
            TableName = "BookingDetail";
            ObjectIDParam = "@BookingDetailID";
            InitStored();
        }
    }
}
