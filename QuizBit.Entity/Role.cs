using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.Entity
{
    public class Role
    {
        public Guid UserJoinRoleID { get; set; }
        public Guid UserID { get; set; }
        public string RoleCode { get; set; }
        public string RoleName { get; set; }
        public bool Inactive { get; set; }
        public int RoleID { get; set; }
    }
}
