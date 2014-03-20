namespace Bank.Common
{
    using System;
    using System.Linq;

    public class ClientCompany : Client
    {
        public ClientCompany(string name)
            : base(false, name)
        {
        }

        protected override bool IsValidName(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }

            return true;
        }
    }
}
