namespace Bank.Common
{
    using System;
    using System.Linq;

    public class ClientIndividual : Client
    {
        public ClientIndividual(string name)
            : base(true, name)
        {
        }

        protected override bool IsValidName(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }

            // If any one character is not a letter
            if (str.Any(c => !char.IsLetter(c)))
            {
                return false;
            }

            return true;
        }
    }
}