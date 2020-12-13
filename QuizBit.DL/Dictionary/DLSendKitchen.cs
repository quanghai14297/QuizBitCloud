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
    public class DLSendKitchen : DLBase
    {
        public DLSendKitchen()
        {
            TableName = "SendKitchen";
            ObjectIDParam = "@SendKitchenID";
            InitStored();
        }
    }
}
