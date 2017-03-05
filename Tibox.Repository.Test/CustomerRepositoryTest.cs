using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Tibox.Models;
using Tibox.Repository.Northwind;
using Tibox.UnitOfWork;

namespace Tibox.Repository.Test
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        //private readonly IRepository<Customer> _repository;
        //private readonly ICustomerRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerRepositoryTest()
        {
            //_repository = new BaseRepository<Customer>();
            //_repository = new CustomerRepository();
            _unitOfWork = new TiboxUnitOfWork();
        }

        [TestMethod]
        public void Get_All_Customers()
        {
            var result = _unitOfWork.Customers.GetAll();
            Assert.AreEqual(result.Count() > 0, true);
        }

        [TestMethod]
        public void Insert_Customer()
        {
            var customer = new Customer
            {
                FirstName = "Luigui",
                LastName = "Astohuamán",
                City = "Lima",
                Country = "Perú",
                Phone = "1123123123"
            };

            var result = _unitOfWork.Customers.Insert(customer);
            Assert.AreEqual(result > 0, true);
        }

        [TestMethod]
        public void Update_Customer()
        {
            var customer = _unitOfWork.Customers.GetEntityById(87);
            Assert.AreEqual(customer != null, true);

            customer.City = "Ica";
            customer.Phone = "5656565665";

            var result = _unitOfWork.Customers.Update(customer);
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void Delete_Customer()
        {
            var customer = _unitOfWork.Customers.GetEntityById(80);
            Assert.AreEqual(customer != null, true);

            var result = _unitOfWork.Customers.Delete(customer);
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void Get_Customers_ByNames()
        {
            var customer = _unitOfWork.Customers.SearchByNames("Maria", "Anders");

            Assert.AreEqual(customer != null, true);

            Assert.AreEqual(customer.Id, 1);
            Assert.AreEqual(customer.FirstName, "Maria");
            Assert.AreEqual(customer.LastName, "Anders");

        }

        [TestMethod]
        public void Get_Customer_Whit_Orders()
        {
            var customer = _unitOfWork.Customers.CustomerWithOrders(85);

            Assert.AreEqual(customer != null, true);

            Assert.AreEqual(customer.Orders.Any(), true);
            

        }
    }
}
