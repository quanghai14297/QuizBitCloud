using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.Entity
{
    public class Kitchen
    {
        public Guid KitchenID { get; set; }
        public Guid? BranchID { get; set; }
        public string KitchenName { get; set; }
        public string Description { get; set; }
        public bool Inactive { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public string ModifiedBy { get; set; }
        public string OldIDs { get; set; }
    }
}
