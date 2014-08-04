namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ConsolePrinterVisitorWithNewLine : IPrinterVisitor
    {
        public void Visit(string currentText)
        {
            Console.WriteLine(currentText);
        }
    }
}
