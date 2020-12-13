using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.Entity
{
    public class User
    {
        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public bool Inactive { get; set; }
        public DateTime ChangedPasswordTime { get; set; }
    }
}
