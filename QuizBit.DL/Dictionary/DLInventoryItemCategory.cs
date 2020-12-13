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
    public class DLInventoryItemCategory : DLBase
    {


        public DLInventoryItemCategory()
        {
            TableName = "InventoryItemCategory";
            ObjectIDParam = "@InventoryItemCategoryID";
            InitStored();
        }

        /// <summary>
        /// kiểm tra đối tượng đã tồn tại trên DB hay chưa
        /// </summary>
        /// <param name="itemID">id của item</param>
        /// <param name="condtion">tiêu chí đã tồn tại</param>
        /// <returns></returns>
        public bool CheckCodeExists(Guid itemID, string conditions)
        {
            return CheckObjectIsExistsByOneCondition(itemID, "InventoryItemCategoryCode", conditions);
        }
    }
}
