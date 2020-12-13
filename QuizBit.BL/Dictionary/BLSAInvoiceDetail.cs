using QuizBit.DL;
using QuizBit.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.BL
{
    public class BLSAInvoiceDetail : BLBase
    {

        public bool InsertUpdateSAInvoiceDetail(SAInvoiceDetail item)
        {
            return new DLSAInvoiceDetail().InsertUpdateObject(item);
        }

        public bool DeleteSAInvoiceDetail(Guid itemID)
        {
            return new DLSAInvoiceDetail().DeleteObject(itemID);
        }

        public bool CheckBeforeDeleteSAInvoiceDetail(Guid itemID)
        {
            return new DLSAInvoiceDetail().CheckBeforeDeleteObject(itemID);
        }

        public List<SAInvoiceDetail> GetSAInvoiceDetail(Guid itemID)
        {
            return new DLSAInvoiceDetail().GetObjectByID<SAInvoiceDetail, Guid>(itemID);
        }

        public List<SAInvoiceDetail> GetSAInvoiceDetails()
        {
            return new DLSAInvoiceDetail().GetListObject<SAInvoiceDetail>();
        }
    }
}
