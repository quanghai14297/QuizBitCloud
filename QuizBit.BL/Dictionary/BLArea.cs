using QuizBit.DL;
using QuizBit.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.BL
{
    public class BLArea : BLBase
    {

        public bool InsertUpdateArea(Area item)
        {
            return new DLArea().InsertUpdateObject(item);
        }

        public bool DeleteArea(Guid itemID)
        {
            return new DLArea().DeleteObject(itemID);
        }

        public bool CheckBeforeDeleteArea(Guid itemID)
        {
            return new DLArea().CheckBeforeDeleteObject(itemID);
        }

        public bool CheckCodeExists(Guid itemID, string conditions)
        {
            return new DLArea().CheckCodeExists(itemID, conditions);
        }

        public List<Area> GetArea(Guid itemID)
        {
            return new DLArea().GetObjectByID<Area, Guid>(itemID);
        }

        public List<Area> GetAreas()
        {
            return new DLArea().GetListObject<Area>();
        }
    }
}
