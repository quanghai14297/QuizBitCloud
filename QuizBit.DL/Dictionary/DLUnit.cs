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
    public class DLUnit : DLBase
    {
        #region Procedure name specific
        private const string Proc_GetUnitByName = "Proc_GetUnitByName";
        #endregion

        #region Param Name
        private const string unitNameParam = "@UnitName";
        #endregion

        public DLUnit()
        {
            TableName = "Unit";
            ObjectIDParam = "@UnitID";
            InitStored();
        }


        /// <summary>
        /// lọc danh sách đơn vị theo tên
        /// </summary>
        /// <param name="unitName"></param>
        /// <returns></returns>
        public List<Unit> GetUnitByName(string unitName)
        {
            return GetObjectByCondition<Unit, string>(Proc_GetUnitByName, unitNameParam, unitName);
        }

        /// <summary>
        /// kiểm tra tên đơn bị đã tồn tại hay chưa
        /// </summary>
        /// <param name="itemID">id của item</param>
        /// <param name="conditions">tên đơn vị</param>
        /// <returns></returns>
        public bool CheckCodeExists(Guid itemID, string conditions)
        {
            return CheckObjectIsExistsByOneCondition(itemID, "UnitName", conditions);
        }
    }
}
