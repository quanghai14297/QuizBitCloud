using System;

namespace QuizBit.Entity
{
    public class Employee
    {
        public Guid EmployeeID { get; set; }
        public Guid BranchID { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public int Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string BirthPlace { get; set; }
        public string HomeLand { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string HomePhone { get; set; }
        public string Address { get; set; }
        public byte[] Avatar { get; set; }
        public Guid UserID { get; set; }
        public int RoleID { get; set; }
        public string IdentifyNumber { get; set; }
        public string IdentifyNumberIssuedPlace { get; set; }
        public DateTime IdentifyNumberIssuedDate { get; set; }
        public string Description { get; set; }
        public string MaritalStatus { get; set; }
        public string Religion { get; set; }
        public string Nationality { get; set; }
        public int JobStatus { get; set; }
        public DateTime ProbationDate { get; set; }
        public DateTime ReceiveDate { get; set; }
        public DateTime TerminationDate { get; set; }
        public string ReasonTermination { get; set; }
    }
}
