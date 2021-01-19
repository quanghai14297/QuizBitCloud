using QuizBit.BL;
using QuizBit.Contract;
using QuizBit.Entity;
using System;
using System.Collections.Generic;
using System.Web.Http;


namespace Cloud.Controllers
{
    public class ReportController : ApiController
    {
        [HttpGet]
        [Route("api/Report/Overview")]
        public object Overview()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                Overview items;
                var objBL = new BLOverview();
                items = objBL.GetOverviews();
                result.Data = items;
            }
            catch (Exception ex)
            {
                CommonFunction.WriteLog(ex, "", Request.RequestUri.ToString());
                result.Success = false;
                result.ErrorCode = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("api/Report/getReportSalesCustomer")]
        public object GetReportSalesCustomer([FromBody] ParamDate date)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                List < ReportSalesCustomer> items;
                var objBL = new BLReport();
                items = objBL.GetReportSalesCustomer(date);
                result.Data = items;
            }
            catch (Exception ex)
            {
                CommonFunction.WriteLog(ex, "", Request.RequestUri.ToString());
                result.Success = false;
                result.ErrorCode = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("api/Report/getReportSalesArea")]
        public object GetReportSalesArea([FromBody] ParamDate date)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                List < ReportSalesArea> items;
                var objBL = new BLReport();
                items = objBL.GetReportSalesArea(date);
                result.Data = items;
            }
            catch (Exception ex)
            {
                CommonFunction.WriteLog(ex, "", Request.RequestUri.ToString());
                result.Success = false;
                result.ErrorCode = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("api/Report/getReportSales")]
        public object GetReportSales([FromBody] ParamDate date)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                List<SAInvoiceViewer> items;
                var objBL = new BLReport();
                items = objBL.GetReportSales(date);
                result.Data = items;
            }
            catch (Exception ex)
            {
                CommonFunction.WriteLog(ex, "", Request.RequestUri.ToString());
                result.Success = false;
                result.ErrorCode = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("api/Report/getReportSalesEmployee")]
        public object GetReportSalesEmployee([FromBody] ParamDate date)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                List < ReportSalesEmployee> items;
                var objBL = new BLReport();
                items = objBL.GetReportSalesEmployee(date);
                result.Data = items;
            }
            catch (Exception ex)
            {
                CommonFunction.WriteLog(ex, "", Request.RequestUri.ToString());
                result.Success = false;
                result.ErrorCode = ex.Message;
            }
            return result;
        }
    }
}