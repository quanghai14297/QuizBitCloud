using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.Entity
{
    public class SAInvoice
    {
        public Guid RefID { get; set; }
        public Guid? BranchID { get; set; }
        public Guid? OrderID { get; set; }
        public string RefNo { get; set; }
        public DateTime RefDate { get; set; }
        public Guid? CustomerID { get; set; }
        public Decimal TotalSaleAmount { get; set; }
        public Decimal TotalDiscountAmount { get; set; }
        public Decimal ServiceRate { get; set; }
        public Decimal ServiceAmount { get; set; }
        public Guid? PromotionID { get; set; }
        public Decimal TotalAmount { get; set; }
        public Decimal VATRate { get; set; }
        public Decimal VATAmount { get; set; }
        public Decimal PaymentAmount { get; set; }
        public Decimal ReceiveAmount { get; set; }
        public Decimal ReturnAmount { get; set; }
        public Decimal OtherPromotionAmount { get; set; }
        public string JournalMemo { get; set; }
        public string CancelReason { get; set; }
        public int PaymentStatus { get; set; }
        public Guid? EmployeeID { get; set; }
        public bool IsApplyTaxWhenRequire { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
