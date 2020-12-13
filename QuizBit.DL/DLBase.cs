using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizBit.Contract;

namespace QuizBit.DL
{
    public class DLBase
    {
        #region Declaration
        public static string IS_EXISTS = "1";

        /// <summary>
        /// Tên băng
        /// </summary>
        protected string TableName = "";

        /// <summary>
        /// ID name của đối tượng
        /// </summary>
        protected string ObjectIDParam = "";

        /// <summary>
        /// Tên thủ tục Lấy dữ liệu
        /// </summary>
        protected string Stored_Get = "Proc_Get";

        /// <summary>
        /// Tên thủ tục Lấy dữ liệu by ID
        /// </summary>
        protected string Stored_Get_By_ID = "";

        /// <summary>
        /// Tên thủ tục Lấy toàn bộ dữ liệu
        /// </summary>
        protected string Stored_GetAll = "Proc_GetAll";

        /// <summary>
        /// Tên thủ tục Lấy dữ liệu theo Code
        /// </summary>
        protected string Stored_GetByCode = "Proc_GetByCode";

        /// <summary>
        /// Tên thủ tục Thêm-Cập nhật dữ liệu master
        /// </summary>
        protected string Stored_InsertUpdate = "Proc_InsertUpdate";

        /// <summary>
        /// Tên thủ tục Thêm dữ liệu master
        /// </summary>
        protected string Stored_Insert = "Proc_Create";

        /// <summary>
        /// Tên thủ tục Cập nhật dữ liệu master
        /// </summary>
        protected string Stored_Update = "Proc_Update";

        /// <summary>
        /// Tên thủ tục Xóa dữ liệu master
        /// </summary>
        protected string Stored_Delete = "Proc_Delete";

        /// <summary>
        /// Thủ tục kiểm tra dữ liệu đã là khóa ngoại không
        /// </summary>
        protected string Stored_CheckBeforeDelete = "Proc_CheckBeforeDelete";

        /// <summary>
        /// Tên thủ tục lấy ra dữ liệu FK
        /// </summary>
        protected string Stored_Get_FK = "Proc_Get_FK_";

        /// <summary>
        /// Tên thủ tục lấy ra dữ liệu kiểm tra trùng
        /// </summary>
        protected string Stored_Get_Unique = "Proc_GetUnique_";

        /// <summary>
        /// Tên ID - Khóa chính
        /// </summary>
        protected string Param_ObjectID = "";

        #endregion

        #region Property

        #endregion

        #region Function

        /// <summary>
        /// Khởi tạo tên thủ tục trong Database theo Tên bảng
        /// </summary>
        protected void InitStored()
        {
            Stored_Get += TableName;
            Stored_Get_By_ID += Stored_Get + "ByID";
            Stored_GetAll += TableName;
            Stored_GetByCode += TableName;
            Stored_InsertUpdate += TableName;
            Stored_Insert += TableName;
            Stored_Update += TableName;
            Stored_Delete += TableName;
            Stored_CheckBeforeDelete += TableName;
            Stored_Get_FK += TableName;
            Stored_Get_Unique += TableName;
        }

        /// <summary>
        /// Khởi tạo SqlCommand
        /// </summary>
        /// <param name="procdureName">Tên Procedure cần dùng</param>
        /// <returns>SqlCommand</returns>
        /// <remarks></remarks>
        ///  Created by ddkhanh - 26/12/2018
        protected SqlCommand CreateSqlCommand(string procdureName = "", string commandText = "")
        {
            var sqlCommand = new SqlCommand();
            sqlCommand.Connection = ConnectSQL.GetConnection();
            if (string.IsNullOrEmpty(procdureName))
            {
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = commandText;
            }
            else
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = procdureName;
            }
            if (sqlCommand.Connection.State == ConnectionState.Closed) sqlCommand.Connection.Open();
            return sqlCommand;
        }

        /// <summary>
        /// Phương thức lấy danh sách đối tượng
        /// </summary>
        /// <typeparam name="T">Kiểu đối tượng</typeparam>
        /// <returns>danh sách đối tượng</returns>
        public List<T> GetListObject<T>()
        {
            var table = new DataTable();
            using (var sqlAdapter = new SqlDataAdapter())
            {
                using (var sqlCommand = CreateSqlCommand(Stored_Get))
                {
                    sqlAdapter.SelectCommand = sqlCommand;
                    sqlAdapter.Fill(table);
                    sqlCommand.Connection.Close();
                }
                return CommonFunction.ConvertDataTable<T>(table);
            }
        }

        /// <summary>
        /// Phương thức lấy 1 đối tượng dựa vào ID truyền vào
        /// </summary>
        /// <typeparam name="T">Kiểu đối tượng</typeparam>
        /// <param name="objectID">ID của đối tượng</param>
        /// <returns></returns>
        public List<T> GetObjectByID<T, G>(G objectID)
        {
            var table = new DataTable();
            using (var sqlAdapter = new SqlDataAdapter())
            {
                using (var sqlCommand = CreateSqlCommand(Stored_Get_By_ID))
                {
                    sqlCommand.Parameters.AddWithValue(ObjectIDParam, objectID);
                    sqlAdapter.SelectCommand = sqlCommand;
                    sqlAdapter.Fill(table);
                    sqlCommand.Connection.Close();
                }
                return CommonFunction.ConvertDataTable<T>(table);
            }
        }

        /// <summary>
        /// Phương thức lấy 1 đối tượng/1 danh sách đối tượng theo 1 tiêu chí truyền vào
        /// </summary>
        /// <typeparam name="T">Kiểu đối tượng</typeparam>
        /// <typeparam name="T">Kiểu đối tượng điều kiện</typeparam>
        /// <typeparam name="storedName">tên procedure</typeparam>
        /// <param name="condition">tiêu chí </param>
        /// <param name="paramName">tên param trong sql</param>
        /// <returns>danh sách đối tượng </returns>
        public List<T> GetObjectByCondition<T, G>(string storedName, string paramName, G condition)
        {
            var table = new DataTable();
            using (var sqlAdapter = new SqlDataAdapter())
            {
                using (var sqlCommand = CreateSqlCommand(storedName))
                {
                    sqlCommand.Parameters.AddWithValue(paramName, condition);
                    sqlAdapter.SelectCommand = sqlCommand;
                    sqlAdapter.Fill(table);
                    sqlCommand.Connection.Close();
                }
                return CommonFunction.ConvertDataTable<T>(table);
            }
        }

        /// <summary>
        /// Kiểm tra đối tượng đã tồn tại với điều kiện truyền vào hay chưa
        /// </summary>
        /// <typeparam name="T">kiểu ID</typeparam>
        /// <typeparam name="G">kiểu điều kiện</typeparam>
        /// <param name="objectID">ID của đối tượng thêm/cập nhật</param>
        /// <param name="condition">điều kiện kiểm tra</param>
        /// <returns></returns>
        public bool CheckObjectIsExistsByOneCondition<T, G>(T objectID, string conditionParam, G condition)
        {
            string query = "IF EXISTS (SELECT * FROM " + TableName + " WHERE " + ObjectIDParam.Replace("@", "") + " != '" + objectID + "' AND " + conditionParam + " = ";
            if (condition.GetType() == typeof(string))
            {
                query += "N" + "'" + condition + "'";
            }
            else
            {
                query += condition;
            }
            query += ") SELECT 1 ELSE SELECT 0";

            using (var sqlCommand = CreateSqlCommand())
            {
                sqlCommand.CommandText = query;
                string result = sqlCommand.ExecuteScalar().ToString();
                sqlCommand.Connection.Close();
                return result == IS_EXISTS ? true : false;
            }
        }

        /// <summary>
        /// Ngừng theo dõi các danh mục
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tableName"></param>
        /// <param name="idName"></param>
        /// <param name="oldID"></param>
        /// <returns></returns>
        public bool InactiveObject<T>(string tableName, string idName, T oldID)
        {
            string query = "UPDATE " + tableName + " SET Inactive = 0 WHERE " + idName + " = '" + oldID + "'";
            using (var sqlCommand = CreateSqlCommand())
            {
                sqlCommand.CommandText = query;
                return sqlCommand.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// Kiểm tra đối tượng đã tồn tại với điều kiện truyền vào hay chưa
        /// </summary>
        /// <typeparam name="T">kiểu ID</typeparam>
        /// <typeparam name="G">kiểu điều kiện</typeparam>
        /// <param name="condition">điều kiện kiểm tra</param>
        /// <returns></returns>
        public bool CheckObjectIsExistsByConditions<T>(T objectID, string condition)
        {
            string query = "IF EXISTS (SELECT * FROM[" + TableName + "] WHERE " + ObjectIDParam.Replace("@", "") + " != '" + objectID + "' AND " + condition + ") SELECT 1 ELSE SELECT 0";

            using (var sqlCommand = CreateSqlCommand())
            {
                sqlCommand.CommandText = query;
                string result = sqlCommand.ExecuteScalar().ToString();
                sqlCommand.Connection.Close();
                return result == IS_EXISTS ? true : false;
            }
        }

        /// <summary>
        /// Phương thức thêm/cập nhật mới đối tượng
        /// </summary>
        /// <typeparam name="T">loại đối tượng</typeparam>
        /// <param name="obj">đối tượng cần thêm</param>
        /// <returns>thêm/cập nhật đối tượng thành công/thất bại</returns>
        public bool InsertUpdateObject<T>(T obj)
        {
            var oDB = CreateDatabaseObject();
            object[] param = CommonFunction.ConvertToParamArray(obj);
            var result = oDB.ExecuteNonQuery(Stored_InsertUpdate, param);
            return result > 0;
        }

        /// <summary>
        /// Phương thức xóa 1 đối tượng
        /// </summary>
        /// <param name="objectID"> xóa đối tượng có ID = objectID</param>
        /// <returns>xóa thành công/thất bại</returns>
        public bool DeleteObject<T>(T objectID)
        {
            using (var sqlCommand = CreateSqlCommand(Stored_Delete))
            {
                sqlCommand.Parameters.AddWithValue(ObjectIDParam, objectID);
                int i = sqlCommand.ExecuteNonQuery();
                sqlCommand.Connection.Close();
                return i > 0;
            }
        }

        /// <summary>
        /// Kiểm tra đối tượng đã tồn tại khóa ngoại chưa
        /// </summary>
        /// <param name="objectID"> xóa đối tượng có ID = objectID</param>
        /// <returns>đối tượng đã tồn tại khóa ngoại chưa</returns>
        public bool CheckBeforeDeleteObject<T>(T objectID)
        {
            using (var sqlCommand = CreateSqlCommand(Stored_CheckBeforeDelete))
            {
                sqlCommand.Parameters.AddWithValue(ObjectIDParam, objectID);
                string result = sqlCommand.ExecuteScalar().ToString();
                sqlCommand.Connection.Close();
                return result == IS_EXISTS ? true : false;
            }
        }


        #region Method - Enterprise Library

        /// <summary>
        /// Khởi tạo đối tượng Database để thao tác với dữ liệu
        /// </summary>
        /// <returns></returns>
        protected Database CreateDatabaseObject()
        {
            return new SqlDatabase(ConnectSQL.GetConnectionString());
        }

        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <param name="storeName">Tên Store</param>
        /// <param name="ds">DataSet kết quả</param>
        /// <param name="tableName">Tên bảng chứa dữ liệu</param>
        protected void GetData(string storeName, DataSet ds, string tableName)
        {
            try
            {
                var oDB = CreateDatabaseObject();
                ds.Tables[tableName].Clear();
                oDB.LoadDataSet(Stored_GetAll, ds, new string[] { tableName });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <param name="storeName">Tên Store</param>
        /// <param name="ds">DataSet kết quả</param>
        /// <param name="tableName">Tên bảng chứa dữ liệu</param>
        protected bool UpdateData(string storeName, params object[] parameterValues)
        {
            try
            {
                var oDB = CreateDatabaseObject();
                if (oDB.ExecuteNonQuery(storeName, parameterValues) > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected bool InsertUpdateData(string storeName, DataRow row)
        {
            try
            {
                var oDB = CreateDatabaseObject();
                var cmd = CreateSqlCommand(storeName);
                oDB.DiscoverParameters(cmd);
                //oDB.ex
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        #endregion

        #endregion

        #region Event

        #endregion
    }
}
