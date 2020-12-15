using QuizBit.BL;
using QuizBit.Contract;
using QuizBit.Entity;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Cloud.Controllers
{
    [Authorize]
    public class InventoryItemController : ApiController
    {
        [HttpPost]
        [Route("api/InventoryItem/InsertUpdate")]
        public object InsertUpdateInventoryItem([FromBody] InsertUpdateParameter<InventoryItem> item)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var objBL = new BLInventoryItem();
                if (objBL.CheckCodeExists(item.Data.InventoryItemID, item.Data.InventoryItemCode))
                {
                    result.Success = false;
                    result.ErrorCode = ErrorCode.DuplicateCode;
                }
                else
                {
                    result.Success = objBL.InsertUpdateInventoryItem(item.Data);
                    //if (objBL.InactiveObject("InventoryItem", "InventoryItemID", item.OldID))
                    //{
                    //    result.Success = objBL.InsertUpdateInventoryItem(item.Data);
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
        [Route("api/InventoryItem/Delete")]
        public object DeleteInventoryItem([FromBody] Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                if (new BLInventoryItem().CheckBeforeDeleteInventoryItem(itemID))
                {
                    result.Success = false;
                    result.ErrorCode = ErrorCode.ItemWasUsed;
                }
                else
                    result.Success = new BLInventoryItem().DeleteInventoryItem(itemID);
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
        [Route("api/InventoryItem/CheckBeforeDelete")]
        public object CheckBeforeDeleteInventoryItem([FromBody] Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Success = new BLInventoryItem().CheckBeforeDeleteInventoryItem(itemID);
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
        [Route("api/InventoryItem/GetByID")]
        public object GetInventoryItemByID(Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            List<InventoryItem> items;
            try
            {
                items = new BLInventoryItem().GetInventoryItem(itemID);
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
        [Route("api/InventoryItem/GetList")]
        public object GetInventoryItems()
        {
            ServiceResult result = new ServiceResult();
            List<InventoryItem> items;
            try
            {
                items = new BLInventoryItem().GetInventoryItems();
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