using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.Entity
{
    public class InventoryItemCategory
    {
        public Guid InventoryItemCategoryID { get; set; }
        public string InventoryItemCategoryCode { get; set; }
        public string InventoryItemCategoryName { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public bool Inactive { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public string ModifiedBy { get; set; }
        public string OldIDs { get; set; }
    }
}
