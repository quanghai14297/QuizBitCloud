using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.Entity
{
    public class TableMappingCustom
    {
        public Guid AreaID { get; set; }
        public string AreaName { get; set; }
        public Guid TableID { get; set; }
        public string TableName { get; set; }
        public int SortOrder { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime OrderDate { get; set; }
        public int TableStatus { get; set; }
    }
}
