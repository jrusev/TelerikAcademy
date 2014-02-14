namespace _03.CustomException
{
    using System;

    public class InvalidRanceException<T> : ApplicationException
    {
        private T start;
        private T end;

        public InvalidRanceException(string message)
            : base(message)
        {
        }

        public InvalidRanceException(string message, Exception innerEx)
            : base(message, innerEx)
        {
        }

        public InvalidRanceException(string message, T start, T end)
            : base(message)
        {
            this.Start = start;
            this.End = end;
        }

        public InvalidRanceException(string message, T start, T end, Exception innerEx)
            : base(message, innerEx)
        {
            this.Start = start;
            this.End = end;
        }

        public T End
        {
            get
            {
                return this.end;
            }

            protected set
            {
                this.end = value;
            }
        }

        public T Start
        {
            get
            {
                return this.start;
            }

            protected set
            {
                this.start = value;
            }
        }

        public override string Message
        {
            get
            {
                if (this.Start != null && this.End != null)
                {
                    return string.Format("Value must be between {0} and {1}. {2})", this.Start, this.End, base.Message);
                }
                else
                {
                    return base.Message;
                }
            }
        }
    }
}

namespace _03.CustomException
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int outOfRangeNumber = 45;
            DateTime outOfRangeDate = new DateTime(2024, 12, 31);

            CheckNumber(outOfRangeNumber);
            CheckDate(outOfRangeDate);
        }

        private static void CheckDate(DateTime outOfRangeDate)
        {
            if (outOfRangeDate.Year < 1980 || outOfRangeDate.Year > 2013)
            {
                throw new InvalidRanceException<DateTime>("Invalid range", new DateTime(1980, 1, 1), new DateTime(2013, 12, 31));
            }
        }

        private static void CheckNumber(int outOfRangeNumber)
        {
            if (outOfRangeNumber < 1 || outOfRangeNumber > 100)
            {
                throw new InvalidRanceException<int>("Invalid range", 1, 100);
            }
        }
    }
}