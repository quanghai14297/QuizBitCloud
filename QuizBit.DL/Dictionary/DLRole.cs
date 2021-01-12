using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizBit.Contract;
using QuizBit.Entity;

namespace QuizBit.DL
{
    public class DLRole : DLBase
    {
        public DLRole()
        {
            TableName = "Role";
            ObjectIDParam = "@UserJoinRoleID";
            InitStored();
        }
    }
}
