using QuizBit.BL;
using QuizBit.Contract;
using QuizBit.Entity;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Cloud.Controllers
{
    [Authorize]
    public class AreaController : ApiController
    {
        [HttpPost]
        [Route("api/Area/InsertUpdate")]
        public object InsertUpdateArea([FromBody] InsertUpdateParameter<Area> item)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var objBL = new BLArea();
                if (objBL.CheckCodeExists(item.Data.AreaID, item.Data.AreaName))
                {
                    result.Success = false;
                    result.ErrorCode = ErrorCode.DuplicateCode;
                }
                else
                {
                    result.Success = objBL.InsertUpdateArea(item.Data);
                    //if (objBL.InactiveObject("InventoryItem", "InventoryItemID", item.OldID))
                    //{
                        
                    //}
                    //else
                    //{
                    //    result.Success = false;
                    //    result.ErrorCode = ErrorCode.ItemNotInactive;
                    //}
                }
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
        [Route("api/Area/Delete")]
        public object DeleteArea([FromBody] Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                if (new BLArea().CheckBeforeDeleteArea(itemID))
                {
                    result.Success = false;
                    result.ErrorCode = ErrorCode.ItemWasUsed;
                }
                else
                    result.Success = new BLArea().DeleteArea(itemID);
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
        [Route("api/Area/CheckBeforeDelete")]
        public object CheckBeforeDeleteArea([FromBody] Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Success = new BLArea().CheckBeforeDeleteArea(itemID);
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
        [Route("api/Area/GetByID")]
        public object GetAreaByID(Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            List<Area> items;
            try
            {
                items = new BLArea().GetArea(itemID);
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
        [Route("api/Area/GetList")]
        public object GetAreas()
        {
            ServiceResult result = new ServiceResult();
            List<Area> items;
            try
            {
                items = new BLArea().GetAreas();
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
    }
}