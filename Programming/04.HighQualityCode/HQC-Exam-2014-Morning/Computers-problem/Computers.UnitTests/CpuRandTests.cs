using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Computers.Common;

namespace Computers.UnitTests
{
    [TestClass]
    public class CpuRandTests
    {
        [TestMethod]
        public void CpuReturnsRandNumberInCorrectInterval()
        {
            int min = 10;
            int max = 100;

            var ram = new Ram(8);
            var cpu = new Cpu(2, 32, ram);

            cpu.Rand(min, max);
            var actual = ram.LoadValue();

            Assert.IsTrue(min <= actual && actual < max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CpuRandShouldThrowIfMinLessThanMax()
        {
            var cpu = new Cpu(2, 32, new Ram(8));
            cpu.Rand(100, 10);
        }
    }
}
