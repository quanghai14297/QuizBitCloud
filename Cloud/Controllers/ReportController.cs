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
                ReportSalesCustomer items;
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
    }
}