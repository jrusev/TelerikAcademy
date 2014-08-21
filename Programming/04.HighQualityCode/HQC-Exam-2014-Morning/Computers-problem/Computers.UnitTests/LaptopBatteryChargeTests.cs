using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Computers.Common;

namespace Computers.UnitTests
{
    [TestClass]
    public class LaptopBatteryChargeTests
    {
        [TestMethod]
        public void InitialChargeMustBe50()
        {
            var battery = new LaptopBattery();

            Assert.AreEqual(50, battery.Percentage);
        }

        [TestMethod]
        public void ChargeWorksCorrectWithPositiveValues()
        {
            var battery = new LaptopBattery();
            battery.Charge(1);

            Assert.AreEqual(51, battery.Percentage);
        }

        [TestMethod]
        public void ChargeWorksCorrectWithNegativeValues()
        {
            var battery = new LaptopBattery();
            battery.Charge(-1);

            Assert.AreEqual(49, battery.Percentage);
        }

        [TestMethod]
        public void ChargeShouldNotGoBelowZero()
        {
            var battery = new LaptopBattery();
            battery.Charge(-51);

            Assert.AreEqual(0, battery.Percentage);
        }

        [TestMethod]
        public void ChargeShouldNotGoAbove100()
        {
            var battery = new LaptopBattery();
            battery.Charge(51);

            Assert.AreEqual(100, battery.Percentage);
        }
    }
}
