using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PcComponentsShop.Infrastructure.Business.Basic_Actions;
using PcComponentsShop.Infrastructure.Business.ActionValidators;
using PcComponentsShop.Domain.Core.Basic_Models;
using System.Collections.Generic;
using PcComponentsShop.Infrastructure.Business.Basic_Models;
using System.Linq;

namespace PcComponentsShop.Tests
{
    [TestClass]
    public class BusinessTests
    {
        [TestMethod]
        public void ReturnCorrectOrderIfValidationCorrect()
        {
            var date = DateTime.Now;
            OrderValidators.UserName = "TestUser";
            var boughtGood = new Good() { FullName = "TestGoodName", ID = 1, ProducedAt = date };
            OrderValidators.AllGoods = new List<Good>() { boughtGood };
            var order = OrdersManipulator.CreateAndReturnNewOrder("TestUser", boughtGood, OrderValidators.IsValidOrder);
            var expectedOrder = new Order()
            {
                OrderId = 0,
                FullGoodName = "TestGoodName",
                GoodAmount = 1,
                GoodCategory = null,
                GoodId = 1,
                GoodImgSrc = "no information",
                GoodPrice = 0,
                OrderStatus = OrderStatus.Registered.ToString(),
                PaidAt = null,
                UserName = "TestUser"
            };
            Assert.AreEqual(expectedOrder.ToString(), order.ToString());
        }
        [TestMethod]
        public void ReturnNullIfValidationIncorrectDoesNotContainInAllGoods()
        {
            var date = DateTime.Now;
            OrderValidators.UserName = "TestUser";
            var boughtGood = new Good() { FullName = "TestGoodName", ID = 1, ProducedAt = date };
            OrderValidators.AllGoods = new List<Good>() { new Good() };
            var order = OrdersManipulator.CreateAndReturnNewOrder("TestUser", boughtGood, OrderValidators.IsValidOrder);
            Assert.AreEqual(null, order);
        }
        [TestMethod]
        public void ReturnNullIfValidationIncorrectUserNameDoesNotMatch()
        {
            var date = DateTime.Now;
            OrderValidators.UserName = "WrongTestUser";
            var boughtGood = new Good() { FullName = "TestGoodName", ID = 1, ProducedAt = date };
            OrderValidators.AllGoods = new List<Good>() { boughtGood };
            var order = OrdersManipulator.CreateAndReturnNewOrder("TestUser", boughtGood, OrderValidators.IsValidOrder);
            Assert.AreEqual(null, order);
        }
    }
}
