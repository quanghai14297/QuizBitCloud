using System;
using Newtonsoft.Json;

namespace QuizBit.Contract
{
    public class SerializeUtil
    {
        /// <summary>
        /// Chuyển object thành string JSON
        /// </summary>
        /// <param name="value">Đối tượng cần convert sang JSON</param>
        /// <returns>chuỗi JSON</returns>
        public static string Serialize(object value)
        {
            var setting = new JsonSerializerSettings();
            setting.DateTimeZoneHandling = DateTimeZoneHandling.Local;
            return JsonConvert.SerializeObject(value, setting);
        }

        /// <summary>
        /// Chuyển string JSON thành object T
        /// </summary>
        /// <typeparam name="T">Loại đối tượng trả về</typeparam>
        /// <param name="value">chuỗi JSON cần giải mã</param>
        /// <returns>Đối tượng trả về từ JSON</returns>
        public static T Deserialize<T>(string value)
        {
            var setting = new JsonSerializerSettings();
            setting.DateTimeZoneHandling = DateTimeZoneHandling.Local;
            return JsonConvert.DeserializeObject<T>(value, setting);
        }

        /// <summary>
        /// Chuyển string JSON thành object type
        /// </summary>
        /// <param name="value">chuỗi JSON cần giải mã</param>
        /// <param name="type">loại dữ liệu cần giải mã ra</param>
        /// <returns>Đối tượng trả về từ JSON</returns>
        public static object Deserialize(string value, Type type)
        {
            return JsonConvert.DeserializeObject(value, type);
        }
    }
}
