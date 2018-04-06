using System;
using Geoban.CSharp.ConsoleClient.Reflections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Geoban.CSharp.UnitTests
{

    public class Foo
    {
        
    }

    [TestClass]
    public class ReflectionUnitTests
    {
        [TestMethod]
        public void FactoryTest()
        {
            IStrategy strategy = Factory.Create("HappyDays");

            strategy.DoWork();

        }
    }
}
