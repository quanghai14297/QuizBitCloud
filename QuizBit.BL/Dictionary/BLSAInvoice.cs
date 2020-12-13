using QuizBit.DL;
using QuizBit.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.BL
{
    public class BLSAInvoice : BLBase
    {

        public bool InsertUpdateSAInvoice(SAInvoice item)
        {
            return new DLSAInvoice().InsertUpdateObject(item);
        }

        public bool DeleteSAInvoice(Guid itemID)
        {
            return new DLSAInvoice().DeleteObject(itemID);
        }

        public bool CheckBeforeDeleteSAInvoice(Guid itemID)
        {
            return new DLSAInvoice().CheckBeforeDeleteObject(itemID);
        }

        public List<SAInvoice> GetSAInvoice(Guid itemID)
        {
            return new DLSAInvoice().GetObjectByID<SAInvoice, Guid>(itemID);
        }

        public List<SAInvoice> GetSAInvoices()
        {
            return new DLSAInvoice().GetListObject<SAInvoice>();
        }
    }
}
