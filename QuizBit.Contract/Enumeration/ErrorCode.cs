using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.Contract
{
    public static class ErrorCode
    {
        /// <summary>
        /// Mật khẩu không hợp lệ
        /// </summary>
        public static string InvalidPassword = "InvalidPassword";

        /// <summary>
        /// Trường hợp ngoại lệ
        /// </summary>
        public static string Exception = "Exception";

        /// <summary>
        /// Token hết hạn
        /// </summary>
        public static string TokenTimeout = "TokenTimeout";

        /// <summary>
        /// Mật khẩu đã bị thay đổi - Token không hợp lệ
        /// </summary>
        public static string InvalidToken = "InvalidToken";

        /// <summary>
        /// Trùng tên
        /// </summary>
        public static string DuplicateCode = "DuplicateCode";

        /// <summary>
        /// Đã tồn tại
        /// </summary>
        public static string IsExists = "Exists";

        /// <summary>
        /// Đã được sử dụng
        /// </summary>
        public static string ItemWasUsed = "ItemWasUsed";

        /// <summary>
        /// Đối tượng không thể ngừng theo dõi
        /// </summary>
        public static string ItemNotInactive = "ItemNotInactive";
    }
}
