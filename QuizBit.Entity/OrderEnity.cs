using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.Entity
{
    public class OrderEntity
    {
        public Order order { get; set; }

        public List<OrderDetail> orderDetails { get; set; }

    }
}
