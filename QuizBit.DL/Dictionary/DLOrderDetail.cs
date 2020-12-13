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
    public class DLOrderDetail : DLBase
    {
        public DLOrderDetail()
        {
            TableName = "OrderDetail";
            ObjectIDParam = "@OrderDetailID";
            InitStored();
        }
    }
}
