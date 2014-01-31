using System;

class ExchangeValues
{
    static void Main()
    {
        // Declare  two integer variables and assign them with 5 and 10 and after that exchange their values.
        int a = 5;
        int b = 10;
        Console.WriteLine("a = {0}\tb = {1}", a, b);
        // Now exchange values...
        int aOld = a;
        a = b;
        b = aOld;
        Console.WriteLine("a = {0}\tb = {1}",a,b);
    }
}