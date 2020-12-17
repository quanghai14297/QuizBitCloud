using QuizBit.BL;
using QuizBit.DL;
using QuizBit.Contract;
using QuizBit.Entity;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Cloud.Controllers
{
    [Authorize]
    public class UnitController : ApiController
    {

        [HttpPost]
        [Route("api/Unit/InsertUpdate")]
        public object InsertUpdateUnit([FromBody] InsertUpdateParameter<Unit> item)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var objBL = new BLUnit();
                if (objBL.CheckCodeExists(item.Data.UnitID, item.Data.UnitName))
                {
                    result.Success = false;
                    result.ErrorCode = ErrorCode.DuplicateCode;
                }
                else
                {
                    result.Success = objBL.InsertUpdateUnit(item.Data);
                    //if (objBL.InactiveObject("Unit", "UnitID", item.OldID))
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
        [Route("api/Unit/CheckCodeExists")]
        public object CheckCodeExists([FromBody] Unit item)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                // Đây là check Tồn tại - nếu tồn tại thì trả true, không thì trả false
                // không phải lỗi
                if (new BLUnit().CheckCodeExists(item.UnitID, item.UnitName))
                    result.Success = true;
                else
                    result.Success = false;
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
        [Route("api/Unit/Delete")]
        public object DeleteUnit([FromBody] Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                if (new BLUnit().CheckBeforeDeleteUnit(itemID))
                {
                    result.Success = false;
                    result.ErrorCode = ErrorCode.ItemWasUsed;
                }
                else
                    result.Success = new BLUnit().DeleteUnit(itemID);
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
        [Route("api/Unit/CheckBeforeDelete")]
        public object CheckBeforeDeleteUnit([FromBody] Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Success = new BLUnit().CheckBeforeDeleteUnit(itemID);
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
        [Route("api/Unit/GetByID")]
        public object GetUnitByID(Guid itemID)
        {
            ServiceResult result = new ServiceResult();
            List<Unit> items;
            try
            {
                items = new BLUnit().GetUnit(itemID);
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
        [Route("api/Unit/GetList")]
        public object GetUnits()
        {
            ServiceResult result = new ServiceResult();
            List<Unit> items;
            try
            {
                items = new BLUnit().GetUnits();
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
        [Route("api/Unit/GetByName")]
        public object GetUnitByName(string unitName)
        {
            ServiceResult result = new ServiceResult();
            List<Unit> items;
            try
            {
                items = new BLUnit().GetUnitByName(unitName);
                result.Success = true;
                result.Data = items;
            }
            catch (Exception ex)
            {
                CommonFunction.WriteLog(ex, unitName, Request.RequestUri.ToString());
                result.Success = false;
                result.ErrorCode = ex.Message;
            }
            return result;
        }

    }
}