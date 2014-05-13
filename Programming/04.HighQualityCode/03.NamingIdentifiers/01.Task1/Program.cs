using System;

public class Program
{
    // Unused
    private const int MaxCount = 6;

    public static void Main()
    {
        var boolPrinter = new BoolPrinter();
        boolPrinter.PrintBool(true);
    }

    private class BoolPrinter
    {
        public void PrintBool(bool flag)
        {
            string flagAsString = flag.ToString();
            Console.WriteLine(flagAsString);
        }
    }
}
