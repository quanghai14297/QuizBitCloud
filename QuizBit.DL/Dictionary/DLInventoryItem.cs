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
    public class DLInventoryItem : DLBase
    {

        #region Procedure name specific
        private const string Proc_GetInventoryItemByNameOrCode = "Proc_FilterInventoryItemCategoryByNameOrCode";
        #endregion

        #region Param Name
        private const string inventoryKeyWordParam = "@KeyWord";
        #endregion
        public DLInventoryItem()
        {
            TableName = "InventoryItem";
            ObjectIDParam = "@InventoryItemID";
            InitStored();
        }

        /// <summary>
        /// lấy danh sách thực đơn theo tên/mã
        /// </summary>
        /// <param name="keyWord">tên/mã thực đơn</param>
        /// <returns></returns>
        public List<InventoryItem> GetInventoryItemByName(string keyWord)
        {
            // return GetObjectByCondition<InventoryItem>(Proc_GetInventoryItemByNameOrCode, inventoryKeyWordParam, keyWord);
            return null;
        }

        /// <summary>
        /// kiểm tra đối tượng đã tồn tại trên DB hay chưa
        /// </summary>
        /// <param name="itemID">id của item</param>
        /// <param name="condtion">tiêu chí đã tồn tại</param>
        /// <returns></returns>
        public bool CheckCodeExists(Guid itemID, string conditions)
        {
            return CheckObjectIsExistsByOneCondition(itemID, "InventoryItemCode", conditions);
        }
    }
}
