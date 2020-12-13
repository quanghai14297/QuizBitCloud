using QuizBit.DL;
using QuizBit.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.BL
{
    public class BLUnit : BLBase
    {

        public bool InsertUpdateUnit(Unit item)
        {
            return new DLUnit().InsertUpdateObject(item);
        }

        public bool DeleteUnit(Guid itemID)
        {
            return new DLUnit().DeleteObject(itemID);
        }

        public bool CheckBeforeDeleteUnit(Guid itemID)
        {
            return new DLUnit().CheckBeforeDeleteObject(itemID);
        }

        public List<Unit> GetUnit(Guid itemID)
        {
            return new DLUnit().GetObjectByID<Unit, Guid>(itemID);
        }

        public List<Unit> GetUnits()
        {
            return new DLUnit().GetListObject<Unit>();
        }

        public List<Unit> GetUnitByName(string unitName)
        {
            return new DLUnit().GetUnitByName(unitName);
        }

        public bool CheckCodeExists(Guid itemID, string conditions)
        {
            return new DLUnit().CheckCodeExists(itemID, conditions);
        }
    }
}
