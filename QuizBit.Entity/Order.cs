using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.Entity
{
    public class Order
    {
        public Guid OrderID { get; set; }
        public string OrderNo { get; set; }
        public int OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid? BranchID { get; set; }
        public Guid? CustomerID { get; set; }
        public int NumberOfPeople { get; set; }
        public Guid? BookingID { get; set; }
        public Guid? EmployeeID { get; set; }
        public Guid? CancelEmployeeID { get; set; }
        public string CancelReason { get; set; }
        public Guid? TableID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
