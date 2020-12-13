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
    public class DLCustomer : DLBase
    {
        public DLCustomer()
        {
            TableName = "Customer";
            ObjectIDParam = "@CustomerID";
            InitStored();
        }

        public bool CheckCodeExists(Guid itemID, string conditions)
        {
            return CheckObjectIsExistsByOneCondition(itemID, "CustomerCode", conditions);
        }
    }
}
