using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;
using System.Data.SqlClient;
using Dapper;

namespace Tibox.Repository.Northwind
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public Order OrderWithOrderItems(int orderId)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@orderId", orderId);

                using (var multiple = connection.QueryMultiple("dbo.OrderWhitOrderItems_Luigui",
                                            parameters,
                                            commandType: System.Data.CommandType.StoredProcedure))
                {
                    var order = multiple.Read<Order>().Single();
                    order.OrderItems = multiple.Read<OrderItem>();
                    return order;
                }

            }
        }

        public Order SearchByOrderNumber(int OrderNumber)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@orderNumber", OrderNumber);

                return connection.QueryFirst<Order>("dbo.OrderByOrderNumber_Luigui",
                                                parameters,
                                                commandType: System.Data.CommandType.StoredProcedure);

            }
        }
    }
}
