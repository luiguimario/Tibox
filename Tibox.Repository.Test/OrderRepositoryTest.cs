using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tibox.Repository.Test
{
    [TestClass]
    public class OrderRepositoryTest
    {
        private readonly IRepository<Order> _repository;
        public OrderRepositoryTest()
        {
            _repository = new BaseRepository<Order>();
        }

        [TestMethod]
        public void Get_All_Orders()
        {
            var result = _repository.GetAll();
            Assert.AreEqual(result.Count() > 0, true);
        }

        /*
        [TestMethod]
        public void Insert_Order()
        {
            var customer = new Order
            {
                CustomerId = 1,
                OrderDate = "13/02/2017";
                
            };

            var result = _repository.Insert(customer);
            Assert.AreEqual(result > 0, true);
        }

        [TestMethod]
        public void Update_Customer()
        {
            var customer = _repository.GetEntityById(87);
            Assert.AreEqual(customer != null, true);

            customer.City = "Ica";
            customer.Phone = "5656565665";

            var result = _repository.Update(customer);
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void Delete_Customer()
        {
            var customer = _repository.GetEntityById(80);
            Assert.AreEqual(customer != null, true);

            var result = _repository.Delete(customer);
            Assert.AreEqual(result, true);
        }

    */

    }
}
