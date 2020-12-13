using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.Lib
{
    public class CommonFunction
    {
        /// <summary>
        /// Chuyển đổi dataTable sang dạng list object
        /// </summary>
        /// <typeparam name="T">kiểu object</typeparam>
        /// <param name="dt">DataTable</param>
        /// <returns> danh sách object sau khi được convert</returns>
        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        /// <summary>
        /// Chuyển dổi thông tin từ dataRow sang object
        /// </summary>
        /// <typeparam name="T">kiểu object</typeparam>
        /// <param name="dr">data row</param>
        /// <returns>object được convert</returns>
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName] == DBNull.Value ? null : dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }


        /// <summary>
        /// Lấy danh sách parameter của object
        /// </summary>
        /// <typeparam name="T"> kiểu object</typeparam>
        /// <param name="obj">object được truyền vào</param>
        /// <returns>danh sách sql param</returns>
        public static SqlParameter[] getParameters<T>(T obj)
        {
           
            Type temp = typeof(T);
            int count = temp.GetProperties().Count();
            SqlParameter[] lsParam = new SqlParameter[count];
            PropertyInfo[] info = temp.GetProperties();
            for( int i  = 0; i< count; i++)
            {
                PropertyInfo pro = info[i];
                string paramName = string.Format("@{0}", pro.Name);
                lsParam[i] = new SqlParameter(paramName, pro.GetValue(obj) ?? "");
            }
            return lsParam;
        }
    }
}
