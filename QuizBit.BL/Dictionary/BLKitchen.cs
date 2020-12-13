using QuizBit.DL;
using QuizBit.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.BL
{
    public class BLKitchen : BLBase
    {

        public bool InsertUpdateKitchen(Kitchen item)
        {
            return new DLKitchen().InsertUpdateObject(item);
        }

        public bool DeleteKitchen(Guid itemID)
        {
            return new DLKitchen().DeleteObject(itemID);
        }

        public bool CheckBeforeDeleteKitchen(Guid itemID)
        {
            return new DLKitchen().CheckBeforeDeleteObject(itemID);
        }

        public List<Kitchen> GetKitchen(Guid itemID)
        {
            return new DLKitchen().GetObjectByID<Kitchen, Guid>(itemID);
        }

        public List<Kitchen> GetKitchens()
        {
            return new DLKitchen().GetListObject<Kitchen>();
        }
    }
}
