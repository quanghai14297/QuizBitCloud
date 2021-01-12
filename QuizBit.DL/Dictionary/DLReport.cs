﻿using System;
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
        public ReportSalesCustomer GetReportSalesCustomer(ParamDate date)
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
                    return CommonFunction.ConvertDataTable<ReportSalesCustomer>(table)[0];
                }
                else
                {
                    return null;
                }
            }
        }
        public ReportSalesArea GetReportSalesArea(ParamDate date)
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
                if (CommonFunction.ConvertDataTable<ReportSalesArea>(table).Count > 0)
                {
                    return CommonFunction.ConvertDataTable<ReportSalesArea>(table)[0];
                }
                else
                {
                    return null;
                }
            }
        }
        public SAInvoiceViewer GetReportSales(ParamDate date)
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
                    return CommonFunction.ConvertDataTable<SAInvoiceViewer>(table)[0];
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
