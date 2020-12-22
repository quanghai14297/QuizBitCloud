using QuizBit.DL;
using QuizBit.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.BL
{
    public class BLOverview
    {
        public Overview GetOverviews()
        {
            return new DLOverview().GetOverviews();
        }

    }
}
