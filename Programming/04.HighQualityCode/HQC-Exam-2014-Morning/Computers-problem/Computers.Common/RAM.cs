namespace Computers.Common
{
    public class Ram : IRam
    {
        private int integerValue;

        // amount is never used, it can be removed
        private int amount;

        public Ram(int amount = 8)
        {
            this.amount = amount;
        }

        public void SaveValue(int integerValue)
        {
            this.integerValue = integerValue;
        }

        public virtual int LoadValue()
        {
            return this.integerValue;
        }
    }
}
