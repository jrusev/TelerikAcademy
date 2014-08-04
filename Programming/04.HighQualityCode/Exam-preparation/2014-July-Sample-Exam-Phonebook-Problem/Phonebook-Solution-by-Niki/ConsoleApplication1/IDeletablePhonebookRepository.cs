namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IDeletablePhonebookRepository : IPhonebookRepository
    {
        bool Remove(string phoneNumber);
    }
}
