namespace Bank.Common
{
    using System;
    using System.Linq;

    // Customers could be individuals or companies.
    public abstract class Client
    {
        private string name;

        protected Client(bool isIndividual, string name)
        {
            this.IsIndividual = isIndividual;
            this.Name = name;
        }

        public bool IsIndividual { get; private set; }

        public string Name
        {
            get
            { 
                return this.name;
            }

            private set
            {
                if (!this.IsValidName(value))
                {
                    throw new ApplicationException("Invalid name!");
                }

                this.name = value;
            }
        }

        protected abstract bool IsValidName(string str);
    }
}
