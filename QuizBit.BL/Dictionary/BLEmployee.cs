using QuizBit.DL;
using QuizBit.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.BL
{
    public class BLEmployee : BLBase
    {

        public bool InsertUpdateEmployee(Employee item)
        {
            return new DLEmployee().InsertUpdateObject(item);
        }

        public bool DeleteEmployee(Guid itemID)
        {
            return new DLEmployee().DeleteObject(itemID);
        }

        public bool CheckBeforeDeleteEmployee(Guid itemID)
        {
            return new DLEmployee().CheckBeforeDeleteObject(itemID);
        }

        public bool CheckCodeExists(Guid itemID, string conditions)
        {
            return new DLEmployee().CheckCodeExists(itemID, conditions);
        }

        public List<Employee> GetEmployee(Guid itemID)
        {
            return new DLEmployee().GetObjectByID<Employee, Guid>(itemID);
        }

        public List<Employee> GetEmployees()
        {
            return new DLEmployee().GetListObject<Employee>();
        }
    }
}
