using QuizBit.DL;
using QuizBit.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.BL
{
    public class BLRole : BLBase
    {
        public List<Role> GetRole()
        {
            return new DLRole().GetListObject<Role>();
        }
    }
}
