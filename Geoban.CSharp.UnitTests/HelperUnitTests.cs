using System;
using System.Diagnostics;
using System.Linq;
using Geoban.CSharp.ConsoleClient.LazyCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Geoban.CSharp.UnitTests
{
    [TestClass]
    public class HelperUnitTests
    {
        [TestMethod]
        public void GetWeekDaysTest()
        {
            // Arrange

            Helper helper = new Helper();

            // Acts

            var result = helper.GetWeekDays();

            // Asserts

            Assert.IsNotNull(result);

            foreach (var item in result)
            {
                Assert.IsFalse(string.IsNullOrEmpty(item));
            }

            Assert.IsTrue(result.ToList().Count == 7);


        }


        [TestMethod]
        public void EnumerableTest()
        {
            Team team = new Team();

            team.Add("Marcin");
            team.Add("Tomasz");
            team.Add("Łukasz");
            team.Add("Patryk");
            team.Add("Filip");
            team.Add("Tomasz");
            team.Add("Radek");
            team.Add("Mariusz");

            foreach (var member in team)
            {
                Trace.WriteLine(member);
            }
        }
    }
}
