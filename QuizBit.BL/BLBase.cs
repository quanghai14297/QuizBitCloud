using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.BL
{
    public class BLBase
    {
        /// <summary>
        /// Ngừng theo dõi các danh mục
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tableName"></param>
        /// <param name="idname"></param>
        /// <param name="oldID"></param>
        /// <returns></returns>
        public bool InactiveObject<T>(string tableName, string idName, T oldID)
        {
            return new DL.DLBase().InactiveObject(tableName, idName, oldID);
        }
    }
}
