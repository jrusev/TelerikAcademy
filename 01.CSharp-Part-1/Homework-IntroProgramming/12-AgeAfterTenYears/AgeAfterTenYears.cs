// Write a program to read your age from the console and print how old you will be after 10 years.

using System;

class AgePlusTen
{
    static void Main()
    {
        Console.Write("Please, enter your age: ");

        byte ageInput;
        // If the user input is not a number of type byte (integer from 0 to 255), keep asking for input
        while (!byte.TryParse(Console.ReadLine(), out ageInput))
        {
            // If the user has entered a valid input the first time, this code will never execute
            Console.WriteLine("Please, enter valid age!");
        }
        // this code will execute only if the age input is valid
        Console.WriteLine("After 10 years you will be {0} years old.", ageInput + 10);
    }
}