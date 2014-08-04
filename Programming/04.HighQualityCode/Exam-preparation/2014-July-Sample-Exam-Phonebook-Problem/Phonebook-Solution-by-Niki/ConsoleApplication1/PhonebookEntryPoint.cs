namespace Phonebook
{
    using System;
    using System.Linq;
    using Phonebook.Command;
    using System.IO;

    // TODO: Check for StyleCop warnings
    // TODO: Fix runtime error
    public static class PhonebookEntryPoint
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

        public static void Main()
        {
            Console.SetIn(new StringReader(test001_Input));

            IDeletablePhonebookRepository data = new PhonebookRepositoryWithDictionary();
            IPrinter printer = new StringBuilderPrinter();
            IPhoneNumberSanitizer sanitizer = new PhonebookSanitizer();
            ICommandFactory commandFactory = new CommandFactoryWithLazyLoading(data, printer, sanitizer);
            ICommandParser commandParser = new CommandParser();

            while (true)
            {
                string userLine = Console.ReadLine();

                if (userLine == "End" || userLine == null)
                {
                    break;
                }

                var commandInfo = commandParser.Parse(userLine);
                IPhonebookCommand command = commandFactory.CreateCommand(commandInfo.CommandName, commandInfo.Arguments.Count());
                command.Execute(commandInfo.Arguments.ToArray());
            }

            printer.Accept(new ConsolePrinterVisitorWithoutNewLine());
        }
    }
}