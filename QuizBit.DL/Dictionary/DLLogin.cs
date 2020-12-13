using System;
using System.Data;
using System.Data.SqlClient;
using QuizBit.Entity;
using QuizBit.Contract;

namespace QuizBit.DL
{
    public class DLLogin : DLBase
    {
        #region Declaration

        #endregion

        #region Property

        #endregion

        #region Function

        /// <summary>
        /// Hàm kiểm tra tài khoản trong database
        /// </summary>
        /// <param name="userName">Tên đăng nhập</param>
        /// <param name="password">Mật khẩu</param>
        /// <returns></returns>
        private UserLogin GetUserLogin(string userName, string password)
        {
            var userLogin = new UserLogin(userName, password);
            var table = new DataTable();
            using (var sqlAdapter = new SqlDataAdapter())
            {
                using (var sqlCommand = CreateSqlCommand("dbo.Proc_GetUserLogin"))
                {
                    sqlCommand.Parameters.AddWithValue("@UserName", userLogin.UserName);
                    sqlCommand.Parameters.AddWithValue("@Password", userLogin.Password);
                    sqlAdapter.SelectCommand = sqlCommand;
                    sqlAdapter.Fill(table);
                    sqlCommand.Connection.Close();
                }
            }
            if (table.Rows.Count > 0)
            {
                var user = CommonFunction.GetItem<UserLogin>(table.Rows[0]);
                return user;
            }
            else return null;
        }

        /// <summary>
        /// Hàm đăng nhập
        /// </summary>
        /// <param name="userName">Tên đăng nhập</param>
        /// <param name="password"></param>
        /// <returns>Mật khẩu</returns>
        public UserLogin Login(string userName, string password)
        {
            return GetUserLogin(userName, password);
        }

        /// <summary>
        /// Hàm đăng nhập
        /// </summary>
        /// <param name="userName">Tên đăng nhập</param>
        /// <returns>Thời gian thay đổi mật khẩu cuối cùng</returns>
        public DateTime GetTimeLastChangedPassword(string userName)
        {
            using (var sqlAdapter = new SqlDataAdapter())
            {
                using (var sqlCommand = CreateSqlCommand("dbo.Proc_GetTimeLastChangedPassword"))
                {
                    sqlCommand.Parameters.AddWithValue("@UserName", userName);
                    var lastTime = DateTime.MinValue;
                    var result = (sqlCommand.ExecuteScalar() ?? "").ToString();
                    if (DateTime.TryParse(result, out lastTime))
                    {
                        return lastTime;
                    }
                    else return DateTime.MinValue;
                }
            }
        }

        #endregion

        #region Event

        #endregion
    }
}
