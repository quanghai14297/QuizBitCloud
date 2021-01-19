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
        public List<ReportSalesCustomer> GetReportSalesCustomer(ParamDate date)
        {
            return new DLReport().GetReportSalesCustomer(date);
        }
        public List<ReportSalesArea> GetReportSalesArea(ParamDate date)
        {
            return new DLReport().GetReportSalesArea(date);
        }
        public List<SAInvoiceViewer> GetReportSales(ParamDate date)
        {
            return new DLReport().GetReportSales(date);
        }
        public List<ReportSalesEmployee> GetReportSalesEmployee(ParamDate date)
        {
            return new DLReport().GetReportSalesEmployee(date);
        }
        
    }
    
}
