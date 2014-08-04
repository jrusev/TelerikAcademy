namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IPhoneNumberSanitizer
    {
        string Sanitize(string phoneNumber);
    }
}
