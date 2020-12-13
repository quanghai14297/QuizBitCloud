using QuizBit.DL;
using QuizBit.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.BL
{
    public class BLSendKitchen : BLBase
    {

        public bool InsertUpdateSendKitchen(SendKitchen item)
        {
            return new DLSendKitchen().InsertUpdateObject(item);
        }

        public bool DeleteSendKitchen(Guid itemID)
        {
            return new DLSendKitchen().DeleteObject(itemID);
        }

        public bool CheckBeforeDeleteSendKitchen(Guid itemID)
        {
            return new DLSendKitchen().CheckBeforeDeleteObject(itemID);
        }

        public List<SendKitchen> GetSendKitchen(Guid itemID)
        {
            return new DLSendKitchen().GetObjectByID<SendKitchen, Guid>(itemID);
        }

        public List<SendKitchen> GetSendKitchens()
        {
            return new DLSendKitchen().GetListObject<SendKitchen>();
        }
    }
}
