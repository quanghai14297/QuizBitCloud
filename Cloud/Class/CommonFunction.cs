using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Cloud
{
    public static class CommonFunction
    {
        public static void WriteLog(Exception ex, string message = "", string objectName = "")
        {
            try
            {
                new QuizBit.BL.BLException().WriteLog(ex, message, objectName);
            }
            catch (Exception)
            {
                // Do nothing
            }
        }
    }
}