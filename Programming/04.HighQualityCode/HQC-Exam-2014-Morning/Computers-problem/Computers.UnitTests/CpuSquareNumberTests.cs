using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Computers.Common;
using Moq;

namespace Computers.UnitTests
{
    [TestClass]
    public class CpuSquareNumberTests
    {
        private const string NumTooLow = "Number too low.";

        private const string NumTooHigh = "Number too high.";

        private const string SquareResultFormat = "Square of {0} is {1}.";  

        [TestMethod]
        public void SqureShouldReturnCorrectValue()
        {
            int numberToSqure = 500;
            int square = numberToSqure * numberToSqure;
 
            // Create a mocked RAM to give a number to the CPU to operate with
            var mockedRam = new Mock<IRam>();
            mockedRam.Setup(r => r.LoadValue()).Returns(numberToSqure);

            var cpu = new Cpu(2, 32, mockedRam.Object);

            var actual = cpu.SquareNumber();
            var expected = string.Format(SquareResultFormat, numberToSqure, square);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SqureShouldReturnNumberTooLow()
        {
            var ram = new Ram(8);
            var cpu = new Cpu(2, 32, ram);

            ram.SaveValue(-1);
            var actual = cpu.SquareNumber();
            var expected = NumTooLow;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SqureShouldReturnNumberTooHigh32bit()
        {
            var ram = new Ram(8);
            var cpu = new Cpu(2, 32, ram);

            ram.SaveValue(501);
            var actual = cpu.SquareNumber();
            var expected = NumTooHigh;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SqureShouldReturnNumberTooHigh64bit()
        {
            var ram = new Ram(8);
            var cpu = new Cpu(2, 64, ram);

            ram.SaveValue(1001);
            var actual = cpu.SquareNumber();
            var expected = NumTooHigh;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SqureShouldReturnNumberTooHigh128bit()
        {
            var ram = new Ram(8);
            var cpu = new Cpu(2, 128, ram);

            ram.SaveValue(2001);
            var actual = cpu.SquareNumber();
            var expected = NumTooHigh;

            Assert.AreEqual(expected, actual);
        }
    }
}
