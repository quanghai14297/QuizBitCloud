using QuizBit.Contract;
using QuizBit.Entity;

namespace QuizBit.Lib
{
    class CloudConnection : ICloudConnection
    {
        /// <summary>
        /// Hàm thực hiện đăng nhập
        /// </summary>
        /// <returns>Token</returns>
        public string Login(string username, string password)
        {
            ServiceResult result = CloudServiceFactory.ExecuteFunction("login", new UserLogin(username, password));
            if (result.Success && result.Data != null)
                return result.Data.ToString();
            else return string.Empty;
        }
    }
}
