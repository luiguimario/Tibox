using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tibox.UnitOfWork;

namespace Tibox.Repository.Test
{
    [TestClass]
    public class OrderRepositoryTest
    {
        //private readonly IRepository<Order> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderRepositoryTest()
        {
            //_repository = new BaseRepository<Order>();
            _unitOfWork = new TiboxUnitOfWork();
        }

        [TestMethod]
        public void Get_All_Orders()
        {
            //var result = _repository.GetAll();
            var result = _unitOfWork.Orders.GetAll();
            Assert.AreEqual(result.Count() > 0, true);
        }

        /*
        [TestMethod]
        public void Insert_Order()
        {
            var order = new Order
            {
                OrderDate = "05/03/2017",
                OrderNumber = 2,

                
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


        [TestMethod]
        public void Get_Order_ByNumberOrder()
        {
            var order = _unitOfWork.Orders.SearchByOrderNumber(542384);
            
            Assert.AreEqual(order != null, true);

            Assert.AreEqual(order.Id, 7);
            Assert.AreEqual(order.CustomerId, 14);

        }

        [TestMethod]
        public void Get_Customer_Whit_Orders()
        {
            var order = _unitOfWork.Orders.OrderWithOrderItems(7);

            Assert.AreEqual(order != null, true);

            Assert.AreEqual(order.OrderItems.Any(), true);


        }


    }
}
