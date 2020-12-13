using QuizBit.DL;
using QuizBit.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.BL
{
    public class BLOrder : BLBase
    {

        public bool InsertUpdateOrderEntity(OrderEntity item)
        {
            return new DLOrder().InsertUpdateOrder(item);
        }

        public bool InsertUpdateOrder(Order item)
        {
            return new DLOrder().InsertUpdateObject(item);
        }

        public bool DeleteOrder(Guid itemID)
        {
            return new DLOrder().DeleteObject(itemID);
        }

        public bool CheckBeforeDeleteOrder(Guid itemID)
        {
            return new DLOrder().CheckBeforeDeleteObject(itemID);
        }

        public List<Order> GetOrder(Guid itemID)
        {
            return new DLOrder().GetObjectByID<Order, Guid>(itemID);
        }

        public List<OrderResponse> GetOrdersToday()
        {
            DateTime time = DateTime.Now;
            return new DLOrder().getListOrder(time);
        }

        public List<OrderResponse> GetOrdersTodayWithOrderStatus(int orderStatus)
        {
            DateTime time = DateTime.Now;
            return new DLOrder().getListOrder(time, orderStatus);
        }


    }
}
