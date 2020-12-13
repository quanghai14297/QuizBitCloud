using QuizBit.DL;
using QuizBit.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.BL
{
    public class BLOrderDetail : BLBase
    {

        public bool InsertUpdateOrderDetail(OrderDetail item)
        {
            return new DLOrderDetail().InsertUpdateObject(item);
        }

        public bool DeleteOrderDetail(Guid itemID)
        {
            return new DLOrderDetail().DeleteObject(itemID);
        }

        public bool CheckBeforeDeleteOrderDetail(Guid itemID)
        {
            return new DLOrderDetail().CheckBeforeDeleteObject(itemID);
        }

        public List<OrderDetail> GetOrderDetail(Guid itemID)
        {
            return new DLOrderDetail().GetObjectByID<OrderDetail, Guid>(itemID);
        }

        public List<OrderDetail> GetOrderDetails()
        {
            return new DLOrderDetail().GetListObject<OrderDetail>();
        }
    }
}
