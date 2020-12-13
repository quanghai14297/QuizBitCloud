using System;

namespace QuizBit.BL
{
    public class BLException
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
            new DL.DLException().WriteLog(ex, message, objectName);
        }

        #endregion
    }
}
