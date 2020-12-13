using QuizBit.Contract;
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
    public class DLTableMapping : DLBase
    {
        public DLTableMapping()
        {
            TableName = "TableMapping";
            ObjectIDParam = "@TableID";
            InitStored();
        }

        /// <summary>
        /// kiểm tra tên bàn đã tồn tại hay chưa
        /// </summary>
        /// <param name="itemID">id của item</param>
        /// <param name="tableName">tên bàn</param>
        /// <returns></returns>
        public bool CheckCodeExists(Guid itemID, string tableName)
        {
            return CheckObjectIsExistsByOneCondition(itemID, "TableName", tableName);
        }


        /// <summary>
        /// Lấy ra danh sách bàn theo Khu vực
        /// </summary>
        /// <typeparam name="T">Kiểu đối tượng</typeparam>
        /// <param name="objectID">ID của đối tượng</param>
        /// <returns></returns>
        public List<TableMappingCustom> GetTableMappingByAreaID(Guid objectID, DateTime time)
        {
            var table = new DataTable();
            using (var sqlAdapter = new SqlDataAdapter())
            {
                using (var sqlCommand = CreateSqlCommand("Proc_GetTableMappingByAreaID"))
                {
                    sqlCommand.Parameters.AddWithValue("AreaID", objectID);
                    sqlCommand.Parameters.AddWithValue("Today", time);
                    sqlAdapter.SelectCommand = sqlCommand;
                    sqlAdapter.Fill(table);
                    sqlCommand.Connection.Close();
                }
                return CommonFunction.ConvertDataTable<TableMappingCustom>(table);
            }
        }
    }
}
