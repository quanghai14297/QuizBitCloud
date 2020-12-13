using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.Entity
{
    public class TableMapping
    {
        public Guid TableID { get; set; }
        public Guid? AreaID { get; set; }
        public string TableName { get; set; }
        public string Description { get; set; }
        public bool Inactive { get; set; }
    }
}
