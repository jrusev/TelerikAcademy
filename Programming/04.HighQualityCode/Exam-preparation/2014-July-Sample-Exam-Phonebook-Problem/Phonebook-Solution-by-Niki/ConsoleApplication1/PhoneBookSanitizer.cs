namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PhonebookSanitizer : IPhoneNumberSanitizer
    {
        private const string Code = "+359";

        public string Sanitize(string phoneNumber)
        {
            StringBuilder phoneNumberSanitized = new StringBuilder();
            foreach (char ch in phoneNumber)
            {
                if (char.IsDigit(ch) || (ch == '+'))
                {
                    phoneNumberSanitized.Append(ch);
                }
            }

            if (phoneNumberSanitized.Length >= 2 && phoneNumberSanitized[0] == '0' && phoneNumberSanitized[1] == '0')
            {
                phoneNumberSanitized.Remove(0, 1);
                phoneNumberSanitized[0] = '+';
            }

            while (phoneNumberSanitized.Length > 0 && phoneNumberSanitized[0] == '0')
            {
                phoneNumberSanitized.Remove(0, 1);
            }

            if (phoneNumberSanitized.Length > 0 && phoneNumberSanitized[0] != '+')
            {
                phoneNumberSanitized.Insert(0, Code);
            }

            return phoneNumberSanitized.ToString();
        }
    }
}
