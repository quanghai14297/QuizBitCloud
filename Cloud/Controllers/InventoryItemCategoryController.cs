using QuizBit.BL;
using QuizBit.Contract;
using QuizBit.Entity;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Cloud.Controllers
{
    [Authorize]
    public class InventoryItemCategoryController : ApiController
    {
        [HttpPost]
        [Route("api/InventoryItemCategory/InsertUpdate")]
        public object InsertUpdateInventoryItemCategory([FromBody] InsertUpdateParameter<InventoryItemCategory> item)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var objBL = new BLInventoryItemCategory();
                if (objBL.CheckCodeExists(item.Data.InventoryItemCategoryID, item.Data.InventoryItemCategoryCode))
                {
                    result.Success = false;
                    result.ErrorCode = ErrorCode.DuplicateCode;
                }
                else
                {
                    result.Success = new BLInventoryItemCategory().InsertUpdateInventoryItemCategory(item.Data);
                    //if (objBL.InactiveObject("InventoryItemCategory", "InventoryItemCategoryID", item.OldID))
                    //{
                    //    result.Success = new BLInventoryItemCategory().InsertUpdateInventoryItemCategory(item.Data);
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
        [Route("api/InventoryItemCategory/Delete")]
        public object DeleteInventoryItemCategory([FromBody] Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                if (new BLInventoryItemCategory().CheckBeforeDeleteInventoryItemCategory(itemID))
                {
                    result.Success = false;
                    result.ErrorCode = ErrorCode.ItemWasUsed;
                }
                else
                    result.Success = new BLInventoryItemCategory().DeleteInventoryItemCategory(itemID);
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
        [Route("api/InventoryItemCategory/CheckBeforeDelete")]
        public object CheckBeforeDeleteInventoryItemCategory([FromBody] Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Success = new BLInventoryItemCategory().CheckBeforeDeleteInventoryItemCategory(itemID);
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
        [Route("api/InventoryItemCategory/GetByID")]
        public object GetInventoryItemCategoryByID(Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            List<InventoryItemCategory> items;
            try
            {
                items = new BLInventoryItemCategory().GetInventoryItemCategory(itemID);
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
        [Route("api/InventoryItemCategory/GetList")]
        public object GetInventoryItemCategorys()
        {
            ServiceResult result = new ServiceResult();
            List<InventoryItemCategory> items;
            try
            {
                items = new BLInventoryItemCategory().GetInventoryItemCategorys();
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