using System;
using System.Collections.Generic;

class CheckBrackets
{
    static void Main()
    {
        // Write a program to check if in a given expression the brackets are put correctly.
        // Example of correct expression: ((a+b)/5-d).
        // Example of incorrect expression: )(a+b)).

        Console.WriteLine("This program will check if brackets are put correctly.");
        Console.WriteLine("It does not check if the rest of the expression is valid.\n");

        string exprA = "((a+b)/5-d)";
        string exprB = ")(a+b))";

        Console.WriteLine("{0} -> {1}", exprA, ValidateBrackets(exprA) ? "correct" : "incorrect");
        Console.WriteLine("{0} -> {1}", exprB, ValidateBrackets(exprB) ? "correct" : "incorrect");

        while (true)
        {
            Console.Write("\nEnter math expression that contains brackets: ");
            string expr = Console.ReadLine();

            Console.WriteLine("{0} -> {1}", expr, ValidateBrackets(expr) ? "correct" : "incorrect");
        }
    }

    static bool ValidateBrackets(string expr)
    {
        if (expr == null)
        {
            return false;
        }

        if (expr == String.Empty)
        {
            return false;
        }

        int countOpening = 0;

        foreach (var token in expr)
        {
            if (token == '(')
            {
                countOpening++;
            }

            if (token == ')')
            {
                if (countOpening > 0)
                {
                    countOpening--;
                }
                else
                {
                    return false;
                }             
            }
        }

        return ! (countOpening > 0);
    }
}