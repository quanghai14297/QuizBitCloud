using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.Contract
{
    public static class CommonFunction
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

        public static DataTable ConvertToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable(typeof(T).Name);
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                if (prop.PropertyType.GenericTypeArguments.Count() == 0)
                    table.Columns.Add(prop.Name, prop.PropertyType);
                else
                    table.Columns.Add(prop.Name, prop.PropertyType.GenericTypeArguments[0]);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        /// <summary>
        /// Chuyển đổi thông tin từ dataRow sang object
        /// </summary>
        /// <typeparam name="T">kiểu object</typeparam>
        /// <param name="dr">data row</param>
        /// <returns>object được convert</returns>
        public static T GetItem<T>(DataRow dr)
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
            for (int i = 0; i < count; i++)
            {
                PropertyInfo prop = info[i];
                string paramName = string.Format("@{0}", prop.Name);
                if (prop.PropertyType.GenericTypeArguments.Count() == 0)
                {
                    lsParam[i] = new SqlParameter(paramName, prop.GetValue(obj));
                }
                else
                {
                    lsParam[i] = new SqlParameter(paramName, prop.GetValue(obj) ?? DBNull.Value);
                }
            }
            return lsParam;
        }

        /// <summary>
        /// Tạo Array Parameter từ Object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object[] ConvertToParamArray<T>(T obj)
        {
            var arr = new List<object>();
            Type temp = typeof(T);
            int count = temp.GetProperties().Count();
            PropertyInfo[] info = temp.GetProperties();
            for (int i = 0; i < count; i++)
            {
                PropertyInfo prop = info[i];
                if (prop.PropertyType.GenericTypeArguments.Count() == 0)
                {
                    arr.Add(prop.GetValue(obj));
                }
                else
                {
                    arr.Add(prop.GetValue(obj) ?? DBNull.Value);
                }
            }
            return arr.ToArray();
        }
    }
}
