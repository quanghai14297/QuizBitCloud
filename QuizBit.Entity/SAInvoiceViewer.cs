using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.Entity
{
    public class SAInvoiceViewer
    {
        public Guid RefID { get; set; }
        public string RefNo { get; set; }
        public DateTime RefDate { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal VATAmount { get; set; }
        public decimal TotalSaleAmount { get; set; }
        public string InvNo { get; set; }
        public string TransactionID { get; set; }
    }
}
