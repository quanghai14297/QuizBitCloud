using QuizBit.Contract;
using QuizBit.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBit.DL
{
    public class DLUser : DLBase
    {
        public DLUser()
        {
            TableName = "User";
            ObjectIDParam = "@UserID";
            InitStored();
        }

        /// <summary>
        /// kiểm tra đối tượng đã tồn tại trên DB hay chưa
        /// </summary>
        /// <param name="itemID">id của item</param>
        /// <param name="condtion">tiêu chí đã tồn tại</param>
        /// <returns></returns>
        public bool CheckCodeExists(Guid itemID, string conditions)
        {
            return CheckObjectIsExistsByOneCondition(itemID, "UserName", conditions);
        }


        public bool ChangePassword(ChangePasswordRequest changePasswordRequest)
        {
            using (var sqlCommand = CreateSqlCommand("Proc_ChangePassword"))
            {
                sqlCommand.Parameters.AddWithValue("@UserName", changePasswordRequest.UserName);
                sqlCommand.Parameters.AddWithValue("@OldPass", EncryptUtil.MD5Hash(changePasswordRequest.OldPass));
                sqlCommand.Parameters.AddWithValue("@NewPass", EncryptUtil.MD5Hash(changePasswordRequest.NewPass));
                return sqlCommand.ExecuteNonQuery() > 0;
            }
        }
    }
}
