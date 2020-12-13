using System;

namespace QuizBit.Entity
{
    public class InventoryItem
    {
        public Guid InventoryItemID { get; set; }
        public string InventoryItemCode { get; set; }
        public string InventoryItemName { get; set; }
        public int InventoryItemType { get; set; }
        public Guid? InventoryItemCategoryID { get; set; }
        public Guid? UnitID { get; set; }
        public string Description { get; set; }
        public byte[] FileResource { get; set; }
        public int CourseType { get; set; }
        public Decimal UnitPrice { get; set; }
        public bool Inactive { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public string ModifiedBy { get; set; }
        public string OldIDs { get; set; }
    }
}
