using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.Entity
{
    public class BookingDetail
    {
        public Guid BookingDetailID { get; set; }
        public Guid BookingID { get; set; }
        public Guid? InventoryItemID { get; set; }
        public Decimal Quantity { get; set; }
        public string Desciption { get; set; }
        public int BookingDetailStatus { get; set; }
        public int SortOrder { get; set; }
        public Guid? SendKitchenID { get; set; }
        public string SenderName { get; set; }
        public string CancelName { get; set; }    
    }
}
