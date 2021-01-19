using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizBit.Contract;
using QuizBit.Entity;

namespace QuizBit.DL
{
    public class DLReport : DLBase
    {
        public List<ReportSalesCustomer> GetReportSalesCustomer(ParamDate date)
        {
            var table = new DataTable();
            var param = CommonFunction.getParameters(date);
            using (var sqlAdapter = new SqlDataAdapter())
            {
                using (var sqlCommand = CreateSqlCommand("Proc_GetReportSalesCustomer"))
                {
                    sqlCommand.Parameters.AddRange(param);
                    sqlAdapter.SelectCommand = sqlCommand;

                    sqlAdapter.Fill(table);
                    sqlCommand.Connection.Close();
                }
                if (CommonFunction.ConvertDataTable<ReportSalesCustomer>(table).Count > 0)
                {
                    return CommonFunction.ConvertDataTable<ReportSalesCustomer>(table);
                }
                else
                {
                    return null;
                }
            }
        }
        public List<ReportSalesArea> GetReportSalesArea(ParamDate date)
        {
            var table = new DataTable();
            var param = CommonFunction.getParameters(date);
            using (var sqlAdapter = new SqlDataAdapter())
            {
                using (var sqlCommand = CreateSqlCommand("Proc_GetReportSalesArea"))
                {
                    sqlCommand.Parameters.AddRange(param);
                    sqlAdapter.SelectCommand = sqlCommand;

                    sqlAdapter.Fill(table);
                    sqlCommand.Connection.Close();
                }
                if (CommonFunction.ConvertDataTable< ReportSalesArea>(table).Count > 0)
                {
                    return CommonFunction.ConvertDataTable< ReportSalesArea>(table);
                }
                else
                {
                    return null;
                }
            }
        }
        public List<SAInvoiceViewer> GetReportSales(ParamDate date)
        {
            var table = new DataTable();
            var param = CommonFunction.getParameters(date);
            using (var sqlAdapter = new SqlDataAdapter())
            {
                using (var sqlCommand = CreateSqlCommand("Proc_GetReportSales"))
                {
                    sqlCommand.Parameters.AddRange(param);
                    sqlAdapter.SelectCommand = sqlCommand;

                    sqlAdapter.Fill(table);
                    sqlCommand.Connection.Close();
                }
                if (CommonFunction.ConvertDataTable<SAInvoiceViewer>(table).Count > 0)
                {
                    return CommonFunction.ConvertDataTable<SAInvoiceViewer>(table);
                }
                else
                {
                    return null;
                }
            }
        }
        public List<ReportSalesEmployee> GetReportSalesEmployee(ParamDate date)
        {
            var table = new DataTable();
            var param = CommonFunction.getParameters(date);
            using (var sqlAdapter = new SqlDataAdapter())
            {
                using (var sqlCommand = CreateSqlCommand("Proc_GetReportSalesEmployee"))
                {
                    sqlCommand.Parameters.AddRange(param);
                    sqlAdapter.SelectCommand = sqlCommand;

                    sqlAdapter.Fill(table);
                    sqlCommand.Connection.Close();
                }
                if (CommonFunction.ConvertDataTable<ReportSalesEmployee>(table).Count > 0)
                {
                    return CommonFunction.ConvertDataTable<ReportSalesEmployee>(table);
                }
                else
                {
                    return null;
                }
            }
        }
        
    }
}
