namespace Phonebook.Command
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RemovePhoneCommand : IPhonebookCommand
    {
        private IPrinter printer;
        private IDeletablePhonebookRepository data;
        private IPhoneNumberSanitizer sanitizer;

        public RemovePhoneCommand(IDeletablePhonebookRepository data, IPrinter printer, IPhoneNumberSanitizer sanitizer)
        {
            this.printer = printer;
            this.data = data;
            this.sanitizer = sanitizer;
        }

        public void Execute(string[] arguments)
        {
            // TODO: Invalid phone number
            var sanitized = this.sanitizer.Sanitize(arguments[0]);
            if (this.data.Remove(sanitized))
            {
                this.printer.Print("Success");
            }
            else
            {
                this.printer.Print("Phone number could not be found");
            }
        }
    }
}
