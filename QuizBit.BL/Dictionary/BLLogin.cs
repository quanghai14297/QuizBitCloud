using QuizBit.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.BL
{
    public class BLLogin
    {
        /// <summary>
        /// Hàm đăng nhập
        /// </summary>
        /// <param name="userName">Tên đăng nhập</param>
        /// <param name="password"></param>
        /// <returns>Thành công - Thất bại</returns>
        public UserLogin Login(string userName, string password)
        {
            return new DL.DLLogin().Login(userName, password);
        }

        /// <summary>
        /// Hàm lấy thời gian thay đổi mật khẩu cuối cùng
        /// </summary>
        /// <param name="userName">Tên đăng nhập</param>
        /// <returns>Thời gian thay đổi mật khẩu cuối cùng</returns>
        public DateTime GetTimeLastChangedPassword(string userName)
        {
            return new DL.DLLogin().GetTimeLastChangedPassword(userName);
        }
    }
}
