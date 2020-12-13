using QuizBit.DL;
using QuizBit.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.BL
{
    public class BLUser : BLBase
    {

        public bool InsertUpdateUser(User item)
        {
            return new DLUser().InsertUpdateObject(item);
        }

        public bool DeleteUser(Guid itemID)
        {
            return new DLUser().DeleteObject(itemID);
        }

        public bool CheckBeforeDeleteUser(Guid itemID)
        {
            return new DLUser().CheckBeforeDeleteObject(itemID);
        }

        public List<User> GetUser(Guid itemID)
        {
            return new DLUser().GetObjectByID<User, Guid>(itemID);
        }

        public List<User> GetUsers()
        {
            return new DLUser().GetListObject<User>();
        }

        public bool CheckCodeExists(Guid itemID, string conditions)
        {
            return new DLUser().CheckCodeExists(itemID, conditions);
        }
    }
}
