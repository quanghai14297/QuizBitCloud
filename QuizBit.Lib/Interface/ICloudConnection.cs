using QuizBit.Contract;

namespace QuizBit.Lib
{
    public interface ICloudConnection
    {
        /// <summary>
        /// Hàm thực hiện đăng nhập
        /// </summary>
        /// <returns>Token</returns>
        string Login(string username, string password);
    }
}
