using QuizBit.Contract;
using System;

namespace QuizBit.DL
{
    public class DLException : DLBase
    {
        #region Declaration

        #endregion

        #region Property

        #endregion

        #region Function

        /// <summary>
        /// Hàm Ghi Log Lỗi Exception
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        /// <param name="objectName"></param>
        public void WriteLog(Exception ex, string message = "", string objectName = "")
        {
            var text = SerializeUtil.Serialize(new ObjectException(ex, message));
            using (var sqlCommand = CreateSqlCommand(string.Empty, "INSERT INTO ExceptionLog(ExceptionAction, Description) VALUES(@param1, @param2)"))
            {
                sqlCommand.Parameters.AddWithValue("@param1", objectName);
                sqlCommand.Parameters.AddWithValue("@param2", text);
                sqlCommand.ExecuteNonQuery();
            }
        }

        #endregion
    }

    public class ObjectException
    {
        public Exception exception { get; set; }

        public string message { get; set; }

        public ObjectException(Exception ex, string mess)
        {
            exception = ex;
            message = mess;
        }
    }
}
