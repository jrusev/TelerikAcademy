using System;
using System.Diagnostics;

// Write a program to compare the performance of Math.Sqrt(), Math.Log() and Math.Sin() for float and double.
class MathFunctionsPerformance
{
    const int RepeatCount = 10000000;

    static readonly Stopwatch stopwatch = new Stopwatch();

    static void Main()
    {
        unchecked
        {
            {
                DisplayTestResult("Square root float", () =>
                {
                    for (float i = 1; i < RepeatCount; i++)
                        Math.Sqrt(i);
                });

                DisplayTestResult("Square root double", () =>
                {
                    for (double i = 1; i < RepeatCount; i++)
                        Math.Sqrt(i);
                });
            }

            Console.WriteLine();

            {
                DisplayTestResult("Ln float", () =>
                {
                    for (float i = 1; i < RepeatCount; i++)
                        Math.Log(i);
                });

                DisplayTestResult("Ln double", () =>
                {
                    for (double i = 1; i < RepeatCount; i++)
                        Math.Log(i);
                });
            }

            Console.WriteLine();

            {
                DisplayTestResult("Sin float", () =>
                {
                    for (float i = 1; i < RepeatCount; i++)
                        Math.Sin(i);
                });

                DisplayTestResult("Sin double", () =>
                {
                    for (double i = 1; i < RepeatCount; i++)
                        Math.Sin(i);
                });
            }
        }
    }

    static void DisplayTestResult(string title, Action action)
    {
        Console.Write("{0, -20}", title);
        stopwatch.Restart();

        action();

        stopwatch.Stop();
        Console.WriteLine(stopwatch.Elapsed);
    }
}