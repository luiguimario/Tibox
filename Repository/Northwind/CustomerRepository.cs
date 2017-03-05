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
    public class CustomerRepository: BaseRepository<Customer>, ICustomerRepository
    {
        public Customer CustomerWithOrders(int id)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@customerId", id);

                using (var multiple = connection.QueryMultiple("dbo.CustomerWithOrders",
                                            parameters,
                                            commandType: System.Data.CommandType.StoredProcedure))
                {
                    var customer = multiple.Read<Customer>().Single();
                    customer.Orders = multiple.Read<Order>();
                    return customer;
                }
            }
        }

        public Customer SearchByNames (string firstname, string lastName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@firstName", firstname);
                parameters.Add("@lastName", lastName);

                return connection.QueryFirst<Customer>("dbo.CustomerSearchByNames",
                                                parameters,
                                                commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        
    }
}
