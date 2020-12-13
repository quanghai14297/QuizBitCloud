using QuizBit.DL;
using QuizBit.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.BL
{
    public class BLInventoryItemCategory : BLBase
    {

        public bool InsertUpdateInventoryItemCategory(InventoryItemCategory item)
        {
            return new DLInventoryItemCategory().InsertUpdateObject(item);
        }

        public bool DeleteInventoryItemCategory(Guid itemID)
        {
            return new DLInventoryItemCategory().DeleteObject(itemID);
        }

        public bool CheckBeforeDeleteInventoryItemCategory(Guid itemID)
        {
            return new DLInventoryItemCategory().CheckBeforeDeleteObject(itemID);
        }

        public List<InventoryItemCategory> GetInventoryItemCategory(Guid itemID)
        {
            return new DLInventoryItemCategory().GetObjectByID<InventoryItemCategory, Guid>(itemID);
        }

        public List<InventoryItemCategory> GetInventoryItemCategorys()
        {
            return new DLInventoryItemCategory().GetListObject<InventoryItemCategory>();
        }

        public bool CheckCodeExists(Guid itemID, string conditions)
        {
            return new DLInventoryItemCategory().CheckCodeExists(itemID, conditions);
        }
    }
}
