using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.Lib
{
    public static class CloudLibrary
    {
        /// <summary>
        /// Tạo Service thao tác dữ liệu
        /// </summary>
        /// <returns></returns>
        public static ICloudPublishing CreateService()
        {
            return new CloudPublishing();
        }

        /// <summary>
        /// Tạo Service kết nối ứng dụng
        /// </summary>
        /// <returns></returns>
        public static ICloudConnection CreateServiceConnection()
        {
            return new CloudConnection();
        }
    }
}
