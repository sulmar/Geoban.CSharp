using System;
using Geoban.CSharp.ConsoleClient.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Geoban.CSharp.UnitTests
{
    [TestClass]
    public class DateTimeUnitTests
    {
        [TestMethod]
        public void IsWeekendHelperTest()
        {
            // Arrange
            var date = DateTime.Parse("2018-04-05");

            // Acts
            var isWeekend = DateTimeHelper.IsWeekend(date);

            // Asserts
            Assert.IsFalse(isWeekend);

        }

        [TestMethod]
        public void IsWeekendExtensionTest()
        {
            // Arrange
            var date = DateTime.Parse("2018-04-05");

            // Acts
            var isWeekend = date.IsWeekend();

            // Asserts
            Assert.IsFalse(isWeekend);

        }
    }
}
