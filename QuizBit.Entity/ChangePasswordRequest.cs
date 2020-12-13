using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.Entity
{
    public class ChangePasswordRequest
    {
        //[dbo].[Proc_ChangePassword]
        public string UserName { get; set; }
        public string OldPass { get; set; }
        public string NewPass { get; set; }
    }
}
