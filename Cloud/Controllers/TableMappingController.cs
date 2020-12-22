using QuizBit.BL;
using QuizBit.Contract;
using QuizBit.DL;
using QuizBit.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Cloud.Controllers
{
    [Authorize]
    public class TableMappingController : ApiController
    {
        [HttpPost]
        [Route("api/TableMapping/InsertUpdate")]
        public object InsertUpdateTableMapping([FromBody] TableMapping item)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Success = new BLTableMapping().InsertUpdateTableMapping(item);
            }
            catch (Exception ex)
            {
                CommonFunction.WriteLog(ex, SerializeUtil.Serialize(item), Request.RequestUri.ToString());
                result.Success = false;
                result.ErrorCode = ex.Message;
            }
            return result;
        }

        [HttpPost]
        [Route("api/TableMapping/Delete")]
        public object DeleteTableMapping([FromBody] Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Success = new BLTableMapping().DeleteTableMapping(itemID);          
            }
            catch (Exception ex)
            {
                CommonFunction.WriteLog(ex, SerializeUtil.Serialize(itemID), Request.RequestUri.ToString());
                result.Success = false;
                result.ErrorCode = ex.Message;
            }
            return result;
        }

        [HttpPost]
        [Route("api/TableMapping/CheckBeforeDelete")]
        public object CheckBeforeDeleteTableMapping([FromBody] Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Success = new BLTableMapping().CheckBeforeDeleteTableMapping(itemID);
            }
            catch (Exception ex)
            {
                CommonFunction.WriteLog(ex, itemID.ToString(), Request.RequestUri.ToString());
                result.Success = false;
                result.ErrorCode = ex.Message;
            }
            return result;
        }

        [HttpGet]
        [Route("api/TableMapping/GetByID")]
        public object GetTableMappingByID(Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            List<TableMapping> items;
            try
            {
                items = new BLTableMapping().GetTableMapping(itemID);
                result.Success = true;
                result.Data = items;
            }
            catch (Exception ex)
            {
                CommonFunction.WriteLog(ex, SerializeUtil.Serialize(itemID), Request.RequestUri.ToString());
                result.Success = false;
                result.ErrorCode = ex.Message;
            }
            return result;
        }

        [HttpGet]
        [Route("api/TableMapping/GetList")]
        public object GetTableMappings()
        {
            ServiceResult result = new ServiceResult();
            List<TableMapping> items;
            try
            {
                items = new BLTableMapping().GetTableMappings();
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
        
        [HttpGet]
        [Route("api/TableMapping/GetByAreaID")]
        public object GetTableMappingByAreaID(Guid areaID, String time)
        {
            ServiceResult result = new ServiceResult();
            List<TableMappingCustom> items;
            try
            {
                DateTime dateRequest = Convert.ToDateTime(time);
              items = new DLTableMapping().GetTableMappingByAreaID(areaID, dateRequest);
                result.Success = true;
                result.Data = items;
            }
            catch (Exception ex)
            {
                CommonFunction.WriteLog(ex, SerializeUtil.Serialize(areaID), Request.RequestUri.ToString());
                result.Success = false;
                result.ErrorCode = ex.Message;
            }
            return result;
        }
        [HttpGet]
        [Route("api/TableMapping/GetByAreaIDByMobile")]
        public object GetTableMappingByAreaIDByMobile(Guid areaID, String time)
        {
            ServiceResult result = new ServiceResult();
            List<TableMappingCustom> items;
            
            try
            {
                DateTime dateRequest = Convert.ToDateTime(time);
                

                items = new DLTableMapping().GetTableMappingByAreaID(areaID, dateRequest);
                TableMappingCustom tableMapping = new TableMappingCustom();
                for (int i = 0; i < 3; i++)
                {
                    tableMapping.AreaID = Guid.NewGuid();
                    tableMapping.TableName = "A.Test";
                    tableMapping.AreaID = areaID;
                    tableMapping.SortOrder = 0;
                    items.Add(tableMapping);
                }
                items = items.OrderBy(x => x.SortOrder).ToList();
                result.Success = true;
                result.Data = items;
               
            }
            catch (Exception ex)
            {
                CommonFunction.WriteLog(ex, SerializeUtil.Serialize(areaID), Request.RequestUri.ToString());
                result.Success = false;
                result.ErrorCode = ex.Message;
            }
            return result;
        }
    }
}