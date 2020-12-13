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
    public class DLKitchen : DLBase
    {
        public DLKitchen()
        {
            TableName = "Kitchen";
            ObjectIDParam = "@KitchenID";
            InitStored();
        }

        /// <summary>
        /// kiểm tra tên bếp đã tồn tại hay chưa
        /// </summary>
        /// <param name="itemID">id của item</param>
        /// <param name="conditions">tên bếp</param>
        /// <returns></returns>
        public bool CheckCodeExists(Guid itemID, string conditions)
        {
            return CheckObjectIsExistsByOneCondition(itemID, "KitchenName", conditions);
        }
    }
}
