using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.Entity
{
   public class CancelOrderRequest
    {
        public string OrderID { get; set; }
        public string CancelReason { get; set; }
    }
}
