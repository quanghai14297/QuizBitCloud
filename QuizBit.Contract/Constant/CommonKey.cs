using System;
using System.Configuration;

namespace QuizBit.Contract
{
    public static class CommonKey
    {
        /// <summary>
        /// Key Mã hóa
        /// </summary>
        public static string SecureKey = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";

        /// <summary>
        /// Địa chỉ Website
        /// </summary>
        public static string WebUrl
        {
            get
            {
#if DEBUG
                return Constant.WebUrlDebug;
#else
                string url = Constant.WebUrl;
                try
                {
                    var appSetting = ConfigurationManager.AppSettings["WebUrl"];
                    if (appSetting != null)
                        if (string.IsNullOrEmpty(appSetting))
                            url = appSetting;
                }
                catch (Exception)
                {
                    url = Constant.WebUrl;
                }
                return url;
#endif

            }
        }

        /// <summary>
        /// Tên conenction trên Cloud
        /// </summary>
        public static string Connect_SQL_Cloud
        {
            get { return "app_quizbit_cloud"; }
        }
    }
}
