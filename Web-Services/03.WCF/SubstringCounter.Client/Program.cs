namespace SubstringCounter.Client
{
    using System;
    using SubstringCounterServices;

    class Program
    {
        static void Main()
        {
            var client = new SubstringCounterClient();

            string s1 = "day";
            string s2 = "monday, tuesday, wednesday... firday";
            int count = client.GetOccurrences(s1, s2);

            Console.WriteLine("str1 = \"{0}\"", s1);
            Console.WriteLine("str2 = \"{0}\"", s2);
            Console.WriteLine("str2 contains str1 {0} times.", count);
        }
    }
}
