using System;
using Geoban.CSharp.ConsoleClient.Generics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Geoban.CSharp.UnitTests
{
    [TestClass]
    public class GenericUnitTests
    {
        [TestMethod]
        public void GenericClassTest()
        {
            var customer = new Customer
            {
                Id = 1,
                FirstName = "Marcin",
                LastName = "Sulecki"
            };

            CustomersService customersService = new CustomersService();
            customersService.Add(customer);


          
        }
    }
}
