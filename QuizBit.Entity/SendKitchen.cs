using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.Entity
{
    public class SendKitchen
    {
        public Guid SendKitchenID { get; set; }
        public Guid? KitchenID { get; set; }
        public string DataContent { get; set; }
        public Guid? SenderID { get; set; }
        public DateTime SendDate { get; set; }
        public int SendKitchenStatus { get; set; }
        public string Description { get; set; }
        public Guid? InventoryItemID { get; set; }
        public int Quantity { get; set; }
    }
}
