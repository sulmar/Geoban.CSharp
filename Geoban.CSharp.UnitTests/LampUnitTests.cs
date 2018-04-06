using System;
using Geoban.CC.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Geoban.CSharp.UnitTests
{
    [TestClass]
    public class LampUnitTests
    {
        [TestMethod]
        public void LampTest()
        {
            var lamp = new Lamp(
                () => Console.WriteLine("Dziekuję"), 
                () => Console.WriteLine("Witaj"));

            Assert.AreEqual(LampState.Off, lamp.State);

            lamp.SwitchOn();

            Assert.AreEqual(LampState.On, lamp.State);

            lamp.SwitchOff();

            Assert.AreEqual(LampState.Off, lamp.State);

            lamp.SwitchOff();


            lamp.SwitchOn();

            lamp.SwitchOn();

        }
    }
}
