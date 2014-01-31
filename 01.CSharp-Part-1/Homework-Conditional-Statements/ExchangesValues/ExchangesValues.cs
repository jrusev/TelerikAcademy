using System;

class ExchangesValues
{
    static void Main()
    {
        // Write an if statement that examines two integer variables and exchanges their values if the first one is greater than the second one.

        Console.Write("int a = ");
        int num1 = int.Parse(Console.ReadLine());

        Console.Write("int b = ");
        int num2 = int.Parse(Console.ReadLine());

        if (num1 > num2 )
        {
            int temp = num1;
            num1 = num2;
            num2 = temp;
        }
        Console.WriteLine("a = {0}",num1);
        Console.WriteLine("b = {0}", num2);
    }
}