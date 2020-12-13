using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.Contract
{
    public class InsertUpdateParameter<T>
    {
        public Guid OldID { get; set; }

        public T Data { get; set; }

        public InsertUpdateParameter()
        {
            OldID = Guid.Empty;
            Data = default(T);
        }

        public InsertUpdateParameter(T data, Guid id)
        {
            Data = data;
            OldID = id;
        }

        public InsertUpdateParameter(Guid id, T data)
        {
            Data = data;
            OldID = id;
        }
    }
}
