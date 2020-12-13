using QuizBit.DL;
using QuizBit.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.BL
{
    public class BLInventoryItem : BLBase
    {

        public bool InsertUpdateInventoryItem(InventoryItem item)
        {
            return new DLInventoryItem().InsertUpdateObject(item);
        }

        public bool DeleteInventoryItem(Guid itemID)
        {
            return new DLInventoryItem().DeleteObject(itemID);
        }

        public bool CheckBeforeDeleteInventoryItem(Guid itemID)
        {
            return new DLInventoryItem().CheckBeforeDeleteObject(itemID);
        }

        public List<InventoryItem> GetInventoryItem(Guid itemID)
        {
            return new DLInventoryItem().GetObjectByID<InventoryItem, Guid>(itemID);
        }

        public List<InventoryItem> GetInventoryItems()
        {
            return new DLInventoryItem().GetListObject<InventoryItem>();
        }

        public bool CheckCodeExists(Guid itemID, string conditions)
        {
            return new DLInventoryItem().CheckCodeExists(itemID, conditions);
        }
    }
}
