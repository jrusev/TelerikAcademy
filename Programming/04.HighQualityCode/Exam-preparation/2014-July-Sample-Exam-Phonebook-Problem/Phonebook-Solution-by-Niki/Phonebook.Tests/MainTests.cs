using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Phonebook.Tests
{
    [TestClass]
    public class MainTests
    {
        private const string test001_Input = @"AddPhone(Kalina, 0899 777 235, 02 / 981 11 11)
AddPhone(kalina, +359899777235)
AddPhone(KALINA, (+359) 899777236)
AddPhone(Kalina (new), 0899 76 15 33)
List(0, 1)
List(10, 10)
ChangePhone((+359) 899 777236, 0883 22 33 44)
AddPhone(Zhoro.Telerik, 0893 656 756)
AddPhone(Alex St.Zagora, 042 77 33 55)
ChangePhone(0893 656 756, 0898 123 456)
List(1, 3)
ChangePhone(042 77 33 55, 02 98 11 111)
ChangePhone((02) 9811111, 088 322 33 44)
List(0, 2)
ChangePhone((02) 9811111, 088 322 33 44)
End
";
        private const string test001_output = @"Phone entry created
Phone entry merged
Phone entry merged
Phone entry created
[Kalina: +35929811111, +359899777235, +359899777236]
Invalid range
1 numbers changed
Phone entry created
Phone entry created
1 numbers changed
[Kalina: +35929811111, +359883223344, +359899777235]
[Kalina (new): +359899761533]
[Zhoro.Telerik: +359898123456]
1 numbers changed
2 numbers changed
[Alex St.Zagora: +359883223344]
[Kalina: +359883223344, +359899777235]
0 numbers changed
";
        
        [TestMethod]
        public void Main_test001()
        {
            var newOut = new StringWriter();
            var newIn = new StringReader(test001_Input);

            Console.SetOut(newOut);
            Console.SetIn(newIn);

            Phonebook.PhonebookEntryPoint.Main();

            Assert.AreEqual(test001_output, newOut.ToString());
        }
    }
}
