using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.Entity
{
    public class SAInvoiceDetail
    {
        public Guid RefDetailID { get; set; }
        public Guid RefID { get; set; }
        public Guid? ItemID { get; set; }
        public Guid? ItemAdditionID { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal QuantityAddition { get; set; }
        public Decimal UnitPrice { get; set; }
        public Decimal SaleAmount { get; set; }
        public Decimal DiscountRate { get; set; }
        public Decimal DiscountAmount { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public Guid? PromotionID { get; set; }
        public Guid? OrderDetailID { get; set; }
    }
}
