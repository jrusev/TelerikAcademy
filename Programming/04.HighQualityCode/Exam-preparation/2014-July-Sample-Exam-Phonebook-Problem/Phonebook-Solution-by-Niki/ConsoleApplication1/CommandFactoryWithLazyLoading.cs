namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Phonebook.Command;

    public class CommandFactoryWithLazyLoading : ICommandFactory
    {
        private IDeletablePhonebookRepository data;
        private IPrinter printer;
        private IPhoneNumberSanitizer sanitizer;
        private IPhonebookCommand addCommand;
        private IPhonebookCommand changeCommand;
        private IPhonebookCommand listCommand;
        private IPhonebookCommand removeCommand;

        public CommandFactoryWithLazyLoading(IDeletablePhonebookRepository data, IPrinter printer, IPhoneNumberSanitizer sanitizer)
        {
            this.data = data;
            this.printer = printer;
            this.sanitizer = sanitizer;
        }

        public IPhonebookCommand CreateCommand(string commandName, int argumentsCount)
        {
            IPhonebookCommand command;
            if (commandName.StartsWith("AddPhone") && (argumentsCount >= 2))
            {
                if (this.addCommand == null)
                {
                    this.addCommand = new AddPhoneCommand(this.data, this.printer, this.sanitizer);
                }

                command = this.addCommand;
            }
            else if ((commandName == "ChangePhone") && (argumentsCount == 2))
            {
                if (this.changeCommand == null)
                {
                    this.changeCommand = new ChangePhoneCommand(this.data, this.printer, this.sanitizer);
                }

                command = this.changeCommand;
            }
            else if ((commandName == "List") && (argumentsCount == 2))
            {
                if (this.listCommand == null)
                {
                    this.listCommand = new ListPhonesCommand(this.data, this.printer);
                }

                command = this.listCommand;
            }
            else if (commandName == "Remove" && argumentsCount == 1)
            {
                if (this.removeCommand == null)
                {
                    this.removeCommand = new RemovePhoneCommand(this.data, this.printer, this.sanitizer);
                }

                command = this.removeCommand;
            }
            else
            {
                throw new ArgumentException("Invalid command!");
            }

            return command;
        }
    }
}
