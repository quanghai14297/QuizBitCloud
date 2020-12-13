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
    public class DLOrder : DLBase
    {
        public static string PROC_GET_ORDER_BY_DATE = "Proc_GetListOrderByOrderDate";


        public DLOrder()
        {
            TableName = "Order";
            ObjectIDParam = "@OrderID";
            InitStored();
        }

        public bool InsertUpdateOrder(OrderEntity orderEntity)
        {
            bool insertUpdateSuccess = true;
            // var oDB = CreateDatabaseObject();

            Order order = orderEntity.order;
            var orderDetail = orderEntity.orderDetails;

            var param = CommonFunction.getParameters(order);
            int i = 0;
            using (var sqlCommand = CreateSqlCommand("Proc_InsertUpdateOrder"))
            {
                sqlCommand.Parameters.AddRange(param);
                i = sqlCommand.ExecuteNonQuery();

            }
            using (var sqlCommand2 = CreateSqlCommand("Proc_InsertUpdateOrderDetail"))
            {
                if (i > 0)
                {
                    sqlCommand2.Parameters.Clear();
                    foreach (OrderDetail item in orderDetail)
                    {
                        var param1 = CommonFunction.getParameters(item);
                        sqlCommand2.Parameters.AddRange(param1);
                        insertUpdateSuccess = sqlCommand2.ExecuteNonQuery() > 0;
                        sqlCommand2.Parameters.Clear();
                    }
                }
                else
                {
                    insertUpdateSuccess = false;
                }
                sqlCommand2.Connection.Close();
            }

            if (!insertUpdateSuccess)
            {
                DeleteObject(order.OrderID);
            }
            return insertUpdateSuccess;
        }


        public List<OrderResponse> getListOrder(DateTime time)
        {
            var table = new DataTable();
            using (var sqlAdapter = new SqlDataAdapter())
            {
                using (var sqlCommand = CreateSqlCommand(PROC_GET_ORDER_BY_DATE))
                {
                    sqlCommand.Parameters.AddWithValue("@Today", time);
                    sqlAdapter.SelectCommand = sqlCommand;
                    sqlAdapter.Fill(table);
                    sqlCommand.Connection.Close();
                }
                return CommonFunction.ConvertDataTable<OrderResponse>(table);
            }
        }

        public List<OrderResponse> getListOrder(DateTime time, int orderStatus)
        {
            var table = new DataTable();
            using (var sqlAdapter = new SqlDataAdapter())
            {
                using (var sqlCommand = CreateSqlCommand("Proc_GetListOrderByOrderDateAndType"))
                {
                    sqlCommand.Parameters.AddWithValue("@Today", time);
                    sqlCommand.Parameters.AddWithValue("@OrderStatus", orderStatus);
                    sqlAdapter.SelectCommand = sqlCommand;
                    sqlAdapter.Fill(table);
                    sqlCommand.Connection.Close();
                }
                return CommonFunction.ConvertDataTable<OrderResponse>(table);
            }
        }

        /// <summary>
        /// lấy mã order
        /// </summary>
        /// <returns></returns>
        public string getOrderNo()
        {
            using (var sqlCommand = CreateSqlCommand("Proc_GetNumberOrder"))
            {
                sqlCommand.Parameters.AddWithValue("@Year", 2019);
                string result = sqlCommand.ExecuteScalar().ToString();
                sqlCommand.Connection.Close();
                return "2019." + result;
            }
        }

        public bool checkIfExistOrderNo(Order order)
        {
            return CheckObjectIsExistsByConditions(order.OrderID, "OrderNo = '" + order.OrderNo + "'");
        }



        public bool checkOrderIsSendKitchen(Guid orderID)
        {
            using (var sqlCommand = CreateSqlCommand("Proc_CheckOrderAlreadySendKitchen"))
            {
                sqlCommand.Parameters.AddWithValue("@OrderID", orderID);
                string result = sqlCommand.ExecuteScalar().ToString();
                sqlCommand.Connection.Close();
                return result == IS_EXISTS ? true : false;
            }
        }

        public bool RequestPayOrder(Guid orderID)
        {
            using (var sqlCommand = CreateSqlCommand("Proc_OrderRequestPay"))
            {
                sqlCommand.Parameters.AddWithValue("@OrderID", orderID);
                int result = sqlCommand.ExecuteNonQuery();
                sqlCommand.Connection.Close();
                return result > 0;
            }
        }


        public bool CancelOrder(CancelOrderRequest cancelOrderRequest)
        {
            using (var sqlCommand = CreateSqlCommand("Proc_CancelOrder"))
            {
                sqlCommand.Parameters.AddWithValue("@OrderID", cancelOrderRequest.OrderID);
                sqlCommand.Parameters.AddWithValue("@CancelReason", cancelOrderRequest.CancelReason);
                int result = sqlCommand.ExecuteNonQuery();
                sqlCommand.Connection.Close();
                return result > 0;
            }
        }


        public List<OrderDetail> GetOrderDetailsByOrderID(Guid orderID)
        {
            var table = new DataTable();
            using (var sqlAdapter = new SqlDataAdapter())
            {
                using (var sqlCommand = CreateSqlCommand("Proc_GetOrderDetailByOrderID"))
                {
                    sqlCommand.Parameters.AddWithValue("@OrderID", orderID);
                    sqlAdapter.SelectCommand = sqlCommand;
                    sqlAdapter.Fill(table);
                    sqlCommand.Connection.Close();
                }
                return CommonFunction.ConvertDataTable<OrderDetail>(table);
            }
            return null;
        }
    }
}
