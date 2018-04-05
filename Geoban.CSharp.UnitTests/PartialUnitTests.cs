using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geoban.CSharp.ConsoleClient.Partial;

namespace Geoban.CSharp.UnitTests
{
    [TestClass]
    public class PartialUnitTests
    {
        [TestMethod]
        public void PartialMethodTest()
        {
            Product product = new Product();

            product.Id = 10;
        }
    }
}
