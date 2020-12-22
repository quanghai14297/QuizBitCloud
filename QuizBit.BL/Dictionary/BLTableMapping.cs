using QuizBit.DL;
using QuizBit.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.BL
{
    public class BLTableMapping : BLBase
    {

        public bool InsertUpdateTableMapping(TableMapping item)
        {
            return new DLTableMapping().InsertUpdateObject(item);
        }

        public bool DeleteTableMapping(Guid itemID)
        {
            return new DLTableMapping().DeleteObject(itemID);
        }

        public bool CheckBeforeDeleteTableMapping(Guid itemID)
        {
            return new DLTableMapping().CheckBeforeDeleteObject(itemID);
        }

        public List<TableMapping> GetTableMapping(Guid itemID)
        {
            return new DLTableMapping().GetObjectByID<TableMapping, Guid>(itemID);
        }

        public List<TableMapping> GetTableMappings()
        {
            return new DLTableMapping().GetListObject<TableMapping>();
        }
        
    }
}
