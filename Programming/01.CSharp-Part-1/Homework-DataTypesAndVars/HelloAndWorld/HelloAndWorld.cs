using System;

class HelloAndWorld
{
    static void Main()
    {
        // Declare two string variables and assign them with “Hello” and “World”.
        string hello = "Hello";
        string world = "World";
        // Declare an object variable and assign it with the concatenation of the first two variables (mind adding an interval).
        object helloWorld = hello + " " + world;
        // Declare a third string variable and initialize it with the value of the object variable (you should perform type casting).
        string helloWorldString = (string)helloWorld;
        Console.WriteLine(helloWorldString);
    }
}