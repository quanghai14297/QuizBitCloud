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
    public class DLEmployee : DLBase
    {
        public DLEmployee()
        {
            TableName = "Employee";
            ObjectIDParam = "@EmployeeID";
            InitStored();
        }

        public bool CheckCodeExists(Guid itemID, string conditions)
        {
            return CheckObjectIsExistsByOneCondition(itemID, "EmployeeCode", conditions);
        }
    }
}
