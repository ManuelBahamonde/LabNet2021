using Microsoft.VisualStudio.TestTools.UnitTesting;
using TpLinqLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpLinqLogic.Tests
{
    [TestClass()]
    public class CustomerLogicTests
    {
        [TestMethod()]
        public void GetWACustomersTest()
        {
            // Arrange
            var customerLogic = new CustomerLogic();

            // Act
            var customers = customerLogic.GetWACustomers();

            // Assert
            Assert.IsNotNull(customers);
        }
    }
}