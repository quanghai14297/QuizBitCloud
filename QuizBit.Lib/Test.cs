using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.Lib
{
    class Test
    {
        private void Create()
        {
            var service = CloudLibrary.CreateServiceConnection();
            service.Login("khanhjm", "meohen12");
        }
    }
}
