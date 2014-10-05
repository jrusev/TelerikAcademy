namespace DateTimeConverter.Client
{
    using System;
    using DateTimeConverterServices;

    class Program
    {
        public static void Main()
        {
            var client = new DateTimeConverterClient();
            Console.WriteLine("Днес е {0}!", client.GetDayOfWeek(DateTime.Now));
        }
    }
}
