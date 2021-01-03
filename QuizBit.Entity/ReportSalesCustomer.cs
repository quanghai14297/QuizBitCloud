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
        public float TotalAmount { get; set; }
        public float TotalVATAmount { get; set; }
        public float TotalSaleAmount { get; set; }
        public string CustomerName { get; set; }
    }
}
