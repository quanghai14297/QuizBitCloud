using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.Entity
{
    public class ReportSalesCustomer
    {
        public string CustomerCode { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalVATAmount { get; set; }
        public decimal TotalSaleAmount { get; set; }
        public string CustomerName { get; set; }
    }
}
