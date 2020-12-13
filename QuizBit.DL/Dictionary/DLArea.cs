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
    public class DLArea : DLBase
    {
        public DLArea()
        {
            TableName = "Area";
            ObjectIDParam = "@AreaID";
            InitStored();
        }

        public bool CheckCodeExists(Guid itemID, string conditions)
        {
            return CheckObjectIsExistsByOneCondition(itemID, "AreaName", conditions);
        }
    }
}
