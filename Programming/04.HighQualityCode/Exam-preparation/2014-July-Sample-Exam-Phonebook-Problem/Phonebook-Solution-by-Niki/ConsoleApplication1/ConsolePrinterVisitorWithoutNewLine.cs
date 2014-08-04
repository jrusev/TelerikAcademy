namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ConsolePrinterVisitorWithoutNewLine : IPrinterVisitor
    {
        public void Visit(string currentText)
        {
            Console.Write(currentText);
        }
    }
}
