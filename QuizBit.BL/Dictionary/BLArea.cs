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
            bool result = new DLArea().InsertUpdateObject(item);
            if (result && String.IsNullOrEmpty(item.OldIDs))
            {
                for (int i = 0; i < item.NumberOfTable; i++)
                {
                    TableMapping tableMapping = new TableMapping();
                    tableMapping.TableID = Guid.NewGuid();
                    tableMapping.AreaID = item.AreaID;
                    tableMapping.TableName = String.Format("Bàn {0}", i + 1);
                    tableMapping.Inactive = false;
                    tableMapping.SortOrder = i + 1;
                    DLTableMapping dLTable = new DLTableMapping();
                    dLTable.InsertUpdateObject(tableMapping);
                }
            }
            
            return result;
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
