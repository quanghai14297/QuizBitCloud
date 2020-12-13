using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.Entity
{
    public class Area
    {
        public Guid AreaID { get; set; }
        public string AreaName { get; set; }
        public Guid? BranchID { get; set; }
        public string Description { get; set; }
        public int NumberOfTable { get; set; }
        public byte[] Background { get; set; }
        public bool Inactive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string OldIDs { get; set; }
    }
}
