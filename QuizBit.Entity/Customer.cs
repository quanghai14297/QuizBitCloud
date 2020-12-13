using System;

namespace QuizBit.Entity
{
    public class Customer
    {
        public Guid CustomerID { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; } 
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public bool Inactive { get; set; }
    }
}
