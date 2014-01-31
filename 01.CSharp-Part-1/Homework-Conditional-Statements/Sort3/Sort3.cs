using System;

class Sort3
{
    static void Main()
    {
        // Sort 3 real values in descending order using nested if statements.
        // descending -> from the biggest to the smallest

        Console.Write("a = ");
        float a = float.Parse(Console.ReadLine());
        Console.Write("b = ");
        float b = float.Parse(Console.ReadLine());
        Console.Write("c = ");
        float c = float.Parse(Console.ReadLine());

        // we will create an array with 3 elements, which will store the numbers in descending order
        float[] array = new float[3]; // array[0] > array[1] > array[2]
        if (a > b)
        {
            if (a > c)
            {
                array[0] = a; // a>b, a>c
                if (b>c)
                {
                    array[1] = b;
                    array[2] = c;               
                }
                else
                {
                    array[1] = c;
                    array[2] = b;
                }
            }
            else
            {
                array[0] = c; // a>b, c>a
                array[1] = a;
                array[2] = b;
            }
        }
        else
        {
            if (b > c)
            {
                array[0] = b; // b>a, b>c
                if (a > c)
                {
                    array[1] = a;
                    array[2] = c;
                }
                else
                {
                    array[1] = c;
                    array[2] = a;
                }
            }
            else
            {
                array[0] = c; // b>a, c>b
                array[1] = b;
                array[2] = a;
            }
        }
        Console.WriteLine("The numbers in descending order are: {0}, {1}, {2}.",array[0],array[1],array[2]);
    }
}