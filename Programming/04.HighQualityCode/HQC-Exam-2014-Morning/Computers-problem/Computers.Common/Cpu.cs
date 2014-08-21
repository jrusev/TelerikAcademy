namespace Computers.Common
{
    using System;

    public class Cpu
    {
        private const string NumTooLow = "Number too low.";
        private const string NumTooHigh = "Number too high.";
        private const string SquareResultFormat = "Square of {0} is {1}.";  
      
        private const int MinNumber = 0;
        private const int MaxNumber32 = 500;
        private const int MaxNumber64 = 1000;
        private const int MaxNumber128 = 2000;

        private static readonly Random Random = new Random();

        private readonly IRam ram;
        private byte numberOfBits;
        private byte numberOfCores;     

        public Cpu(byte numberOfCores, byte numberOfBits, IRam ram)
        {
            this.numberOfCores = numberOfCores;
            this.numberOfBits = numberOfBits;
            this.ram = ram;
        }        

        public string SquareNumber()
        {
            switch (this.numberOfBits)
            {
                case 32:
                    return this.CalcSquare(MinNumber, MaxNumber32);
                case 64:
                    return this.CalcSquare(MinNumber, MaxNumber64);
                case 128:
                    return this.CalcSquare(MinNumber, MaxNumber128);
                default:
                    throw new InvalidOperationException(this.numberOfBits + "bits architecture is not supported");
            }
        }

        public void Rand(int min, int max)
        {
            if (min > max)
            {
                throw new ArgumentOutOfRangeException("Min cannot be greater than max!");
            }

            int randomNumber = Random.Next(min, max);
            this.ram.SaveValue(randomNumber);
        }

        private string CalcSquare(int min, int max)
        {
            string result;

            var data = this.ram.LoadValue();
            if (data < min)
            {
                result = Cpu.NumTooLow;
            }
            else if (data > max)
            {
                result = Cpu.NumTooHigh;
            }
            else
            {
                int answer = data * data;
                result = string.Format(SquareResultFormat, data, answer);
            }

            return result;
        }
    }
}