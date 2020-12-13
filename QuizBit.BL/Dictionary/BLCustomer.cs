using QuizBit.DL;
using QuizBit.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.BL
{
    public class BLCustomer : BLBase
    {

        public bool InsertUpdateCustomer(Customer item)
        {
            return new DLCustomer().InsertUpdateObject(item);
        }

        public bool DeleteCustomer(Guid itemID)
        {
            return new DLCustomer().DeleteObject(itemID);
        }

        public bool CheckBeforeDeleteCustomer(Guid itemID)
        {
            return new DLCustomer().CheckBeforeDeleteObject(itemID);
        }

        public bool CheckCodeExists(Guid itemID, string conditions)
        {
            return new DLCustomer().CheckCodeExists(itemID, conditions);
        }

        public List<Customer> GetCustomer(Guid itemID)
        {
            return new DLCustomer().GetObjectByID<Customer, Guid>(itemID);
        }

        public List<Customer> GetCustomers()
        {
            return new DLCustomer().GetListObject<Customer>();
        }
    }
}
