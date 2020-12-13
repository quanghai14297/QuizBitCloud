using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QuizBit.Contract.DataObject;
using QuizBit.Contract;

namespace Cloud.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        public object Get()
        {
            var add = new Address();
            add.name = "Hoàng hôn";
            add.location = "Hà Nội";

            var account = new AccountObject();
            account.name = "Dương Đắc Khanh";
            account.data = add;

            var voucher = new Voucher();
            voucher.account = account;
            var voucher2 = new Voucher();
            voucher2.account = account;
            var voucher3 = new Voucher();
            voucher3.account = account;

            var list = new List<object> { voucher, voucher2, voucher3 };
            var oServiceResult = new ServiceResult(data: list);
            return oServiceResult;
        }

        // GET api/values/5
        public object Get(int id)
        {
            var add = new Address();
            add.name = "Hoàng hôn";
            add.location = "Hà Nội";

            var account = new AccountObject();
            account.name = "Dương Đắc Khanh";
            account.data = add;

            var voucher = new Voucher();
            voucher.account = account;

            var oServiceResult = new ServiceResult(data: voucher);
            return oServiceResult;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
