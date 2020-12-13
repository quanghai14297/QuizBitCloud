using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace QuizBit.Contract
{
    public class APIParameter
    {
        [JsonIgnore]
        public string AppID { get; set; }

        [JsonIgnore]
        public string SecureToken { get; set; }

        [JsonIgnore]
        public string CompanyID { get; set; }

        [JsonIgnore]
        public string UserName { get; set; }

        /// <summary>
        /// Hàm Validate tham số truyền vào
        /// </summary>
        /// <returns></returns>
        public string ValidateParameter()
        {
            return string.Empty;
        }
    }
}
