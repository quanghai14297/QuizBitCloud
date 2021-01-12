using QuizBit.BL;
using QuizBit.Contract;
using QuizBit.DL;
using QuizBit.Entity;
using System;
using System.Collections.Generic;
using System.Web.Http;


namespace Cloud.Controllers
{
    [Authorize]
    public class EmployeeController : ApiController
    {
        [HttpGet]
        [Route("api/Employee/GetList")]
        public object GetOrders()
        {
            ServiceResult result = new ServiceResult();
            List<Employee> items;
            try
            {
                items = new BLEmployee().GetEmployees();
                result.Success = true;
                result.Data = items;
            }
            catch (Exception ex)
            {
                CommonFunction.WriteLog(ex, SerializeUtil.Serialize(""), Request.RequestUri.ToString());
                result.Success = false;
                result.ErrorCode = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("api/Employee/Delete")]
        public object DeleteEmployee([FromBody] Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                
                    result.Success = new BLEmployee().DeleteEmployee(itemID);
            }
            catch (Exception ex)
            {
                CommonFunction.WriteLog(ex, SerializeUtil.Serialize(itemID), Request.RequestUri.ToString());
                result.Success = false;
                result.ErrorCode = ex.Message;
            }
            return result;
        }

    }
}