using System;

namespace QuizBit.Entity
{
    /// <summary>
    /// Object đăng nhập
    /// </summary>
    public class UserLogin
    {
        /// <summary>
        /// Khởi tạo
        /// </summary>
        public UserLogin()
        {

        }

        /// <summary>
        /// Khởi tạo
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public UserLogin(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        /// <summary>
        /// ID User
        /// </summary>
        public Guid UserID { get; set; }

        /// <summary>
        /// ID Nhân viên
        /// </summary>
        public Guid EmployeeID { get; set; }

        /// <summary>
        /// Tên đăng nhập
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Mật khẩu
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Tên hiển thị
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Còn hoạt động không
        /// </summary>
        public bool Inactive { get; set; }

        /// <summary>
        /// Ngày tạo tài khoản
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày cập nhật
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Người cập nhật
        /// </summary>
        public string ModifiedBy { get; set; }
    }
}