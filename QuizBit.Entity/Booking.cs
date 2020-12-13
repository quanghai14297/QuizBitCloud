using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.Entity
{
    public class Booking
    {
        public Guid BookingID { get; set; }
        public string BookingNo { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.Now;
        public int BookingStatus { get; set; } = 0;
        public Guid? BranchID { get; set; }
        public Guid CustomerID { get; set; }
        public int NumberOfPeople { get; set; } = 1;
        public DateTime FromTime { get; set; }
        public string RequestMeal { get; set; }
        public string RequestOther { get; set; }
        public bool IsArrangedTable { get; set; } = true;
        public string TableDescription { get; set; }
        public bool IsOrderFood { get; set; }
        public string RequestKitchen { get; set; }
        public string CancelDescription { get; set; }
        public string PaymentDescription { get; set; }
        public Guid EmployeeID { get; set; }
        public Guid TableID { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public string ModifiedBy { get; set; }
    }
}
