using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.Contract
{
    /// <summary>
    /// Format dữ liệu trả về từ Service
    /// </summary>
    public class ServiceResult
    {
        #region Property

        /// <summary>
        /// Trạng thái: True Thành công, False thất bại
        /// </summary>
        public bool Success { get; set; } = false;

        /// <summary>
        /// Mã lỗi chính
        /// </summary>
        public string ErrorCode { get; set; } = "";

        /// <summary>
        /// Thông báo: thường là thông báo lỗi
        /// </summary>
        public List<string> Errors { get; set; } = new List<string>();

        /// <summary>
        /// Dữ liệu chính trả về
        /// </summary>
        public object Data { get; set; } = null;

        /// <summary>
        /// Dữ liệu tự cấu hình
        /// </summary>
        public object CustomData { get; set; }

        #endregion

        #region Contructor

        /// <summary>
        /// Khởi tạo không tham số
        /// </summary>
        public ServiceResult()
        {
            this.Success = true;
            this.ErrorCode = "";
        }

        /// <summary>
        /// Khởi tạo có tham số
        /// </summary>
        /// <param name="success"></param>
        /// <param name="errorCode"></param>
        /// <param name="data"></param>
        /// <param name="customData"></param>
        public ServiceResult(bool success = true, string errorCode = "", object data = null, object customData = null)
        {
            this.Success = success;
            this.ErrorCode = errorCode;
            this.Data = data;
            this.CustomData = customData;
        }

        #endregion

    }


    /// <summary>
    /// Format dữ liệu trả về từ Service
    /// </summary>
    public class ServiceResult<T>
    {
        #region Property

        /// <summary>
        /// Trạng thái: True Thành công, False thất bại
        /// </summary>
        public bool Success { get; set; } = false;

        /// <summary>
        /// Mã lỗi chính
        /// </summary>
        public string ErrorCode { get; set; } = "";

        /// <summary>
        /// Thông báo: thường là thông báo lỗi
        /// </summary>
        public List<string> Errors { get; set; } = new List<string>();

        /// <summary>
        /// Dữ liệu chính trả về
        /// </summary>
        public T Data { get; set; } = default(T);

        /// <summary>
        /// Dữ liệu tự cấu hình
        /// </summary>
        public object CustomData { get; set; }

        #endregion

        #region Contructor

        /// <summary>
        /// Khởi tạo không tham số
        /// </summary>
        public ServiceResult()
        {
            this.Success = true;
            this.ErrorCode = "";
        }

        /// <summary>
        /// Khởi tạo có tham số
        /// </summary>
        /// <param name="success"></param>
        /// <param name="errorCode"></param>
        /// <param name="data"></param>
        /// <param name="customData"></param>
        public ServiceResult(bool success = true, string errorCode = "", T data = default(T), object customData = null)
        {
            this.Success = success;
            this.ErrorCode = errorCode;
            this.Data = data;
            this.CustomData = customData;
        }

        #endregion

    }
}
