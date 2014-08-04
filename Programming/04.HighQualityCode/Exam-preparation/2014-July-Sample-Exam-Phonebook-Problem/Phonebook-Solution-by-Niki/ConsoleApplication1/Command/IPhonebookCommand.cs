namespace Phonebook.Command
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IPhonebookCommand
    {
        void Execute(string[] arguments);
    }
}
