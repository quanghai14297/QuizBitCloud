using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizBit.DL;
using QuizBit.Entity;

namespace QuizBit.BL
{
    public class BLReport
    {
        public ReportSalesCustomer GetReportSalesCustomer(ParamDate date)
        {
            return new DLReport().GetReportSalesCustomer(date);
        }
        public ReportSalesArea GetReportSalesArea(ParamDate date)
        {
            return new DLReport().GetReportSalesArea(date);
        }
        public SAInvoiceViewer GetReportSales(ParamDate date)
        {
            return new DLReport().GetReportSales(date);
        }

    }
    
}
