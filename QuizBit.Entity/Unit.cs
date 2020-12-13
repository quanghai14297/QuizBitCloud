using System;

namespace QuizBit.Entity
{
    public class Unit
    {
        public Guid UnitID { get; set; }
        public string UnitName { get; set; }
        public string Description { get; set; }
        public bool Inactive { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public string ModifiedBy { get; set; }
        public string OldIDs { get; set; }
    }
}
