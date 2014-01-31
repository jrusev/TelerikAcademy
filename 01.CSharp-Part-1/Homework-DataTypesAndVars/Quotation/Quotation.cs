using System;

class Quotation
{
    static void Main()
    {
        //Declare two string variables and assign them with following value:
        // The "use" of quotations causes difficulties.
        //Do the above in two different ways: with and without using quoted strings.
        string quoteA = "The \"use\" of quotations causes difficulties.";
        string quoteB = @"The ""use"" of quotations causes difficulties.";
        Console.WriteLine(quoteA);
        Console.WriteLine(quoteB);
    }
}
