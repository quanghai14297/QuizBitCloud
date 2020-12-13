using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.Entity
{
    public class OrderDetail
    {
        public Guid OrderDetailID { get; set; }
        public Guid OrderID { get; set; }
        public Guid? InventoryItemID { get; set; }
        public Guid? InventoryItemAdditionID { get; set; }
        public Decimal Quantity { get; set; }
        public string QuantityAddition { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public Decimal CookedQuantity { get; set; }
        public Decimal ServedQuantity { get; set; }
        public Decimal CookingQuantity { get; set; }
        public int OrderDetailStatus { get; set; }
        public Guid? CancelEmployeeID { get; set; }
        public Guid? SendKitchenID { get; set; }
    }
}
