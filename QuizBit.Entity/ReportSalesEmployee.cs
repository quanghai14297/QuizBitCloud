﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.Entity
{
    public class ReportSalesEmployee
    {
        public string AreaName { get; set; }
        public string TableName { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalVATAmount { get; set; }
        public decimal TotalSaleAmount { get; set; }
    }
}
