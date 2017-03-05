using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Repository.Northwind;
using Tibox.Repository;
using Tibox.Models;

namespace Tibox.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customers { get; }
        IOrderRepository Orders { get; }
        IRepository<OrderItem> OrderItems { get; }
        IRepository<Product> Products { get; }
        IRepository<Supplier> Suppliers { get; }
    }
}
