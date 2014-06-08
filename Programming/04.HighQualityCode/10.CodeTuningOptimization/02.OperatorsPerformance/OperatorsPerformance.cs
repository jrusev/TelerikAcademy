using System;
using System.Diagnostics;

class OperatorsPerformance
{
    const int RepeatCount = 10000000;

    static readonly Stopwatch stopwatch = new Stopwatch();

    static void Main()
    {
        unchecked
        {
            {
                DisplayTestResult("Add int", () =>
                {
                    int count = 0;

                    for (int i = 1; i < RepeatCount; i++)
                        count += i;
                });

                DisplayTestResult("Add long", () =>
                {
                    long count = 0;

                    for (int i = 1; i < RepeatCount; i++)
                        count += i;
                });

                DisplayTestResult("Add float", () =>
                {
                    float count = 0;

                    for (int i = 1; i < RepeatCount; i++)
                        count += i;
                });

                DisplayTestResult("Add double", () =>
                {
                    double count = 0;

                    for (int i = 1; i < RepeatCount; i++)
                        count += i;
                });

                DisplayTestResult("Add decimal", () =>
                {
                    decimal count = 0;

                    for (int i = 1; i < RepeatCount; i++)
                        count += i;
                });
            }

            Console.WriteLine();

            {
                DisplayTestResult("Subract int", () =>
                {
                    int count = 0;

                    for (int i = 1; i < RepeatCount; i++)
                        count--;
                });

                DisplayTestResult("Subract long", () =>
                {
                    long count = 0;

                    for (int i = 1; i < RepeatCount; i++)
                        count--;
                });

                DisplayTestResult("Subract float", () =>
                {
                    float count = 0;

                    for (int i = 1; i < RepeatCount; i++)
                        count--;
                });

                DisplayTestResult("Subract double", () =>
                {
                    double count = 0;

                    for (int i = 1; i < RepeatCount; i++)
                        count--;
                });

                DisplayTestResult("Subract decimal", () =>
                {
                    decimal count = 0;

                    for (int i = 1; i < RepeatCount; i++)
                        count--;
                });
            }

            Console.WriteLine();

            {
                DisplayTestResult("Increment int", () =>
                {
                    int count = 0;

                    for (int i = 1; i < RepeatCount; i++)
                        count++;
                });

                DisplayTestResult("Increment long", () =>
                {
                    long count = 0;

                    for (int i = 1; i < RepeatCount; i++)
                        count++;
                });

                DisplayTestResult("Increment float", () =>
                {
                    float count = 0;

                    for (int i = 1; i < RepeatCount; i++)
                        count++;
                });

                DisplayTestResult("Increment double", () =>
                {
                    double count = 0;

                    for (int i = 1; i < RepeatCount; i++)
                        count++;
                });

                DisplayTestResult("Increment decimal", () =>
                {
                    decimal count = 0;

                    for (int i = 1; i < RepeatCount; i++)
                        count++;
                });
            }

            Console.WriteLine();

            {
                DisplayTestResult("Multiply int", () =>
                {
                    int count = 1;

                    for (int i = 1; i < RepeatCount; i++)
                        count *= i;
                });

                DisplayTestResult("Multiply long", () =>
                {
                    long count = 1;

                    for (int i = 1; i < RepeatCount; i++)
                        count *= i;
                });

                DisplayTestResult("Multiply float", () =>
                {
                    float count = 1;

                    for (int i = 1; i < RepeatCount; i++)
                        count *= i;
                });

                DisplayTestResult("Multiply double", () =>
                {
                    double count = 1;

                    for (int i = 1; i < RepeatCount; i++)
                        count *= i;
                });

                DisplayTestResult("Multiply decimal", () =>
                {
                    decimal count = 1;

                    for (int i = 1; i < RepeatCount; i++)
                        count *= 1.000000000001m;
                });
            }

            Console.WriteLine();

            {
                DisplayTestResult("Divide int", () =>
                {
                    int count = int.MaxValue;

                    for (int i = 1; i < RepeatCount; i++)
                        count /= i;
                });

                DisplayTestResult("Divide long", () =>
                {
                    long count = long.MaxValue;

                    for (int i = 1; i < RepeatCount; i++)
                        count /= i;
                });

                DisplayTestResult("Divide float", () =>
                {
                    float count = float.MaxValue;

                    for (int i = 1; i < RepeatCount; i++)
                        count /= i;
                });

                DisplayTestResult("Divide double", () =>
                {
                    double count = double.MaxValue;

                    for (int i = 1; i < RepeatCount; i++)
                        count /= i;
                });

                DisplayTestResult("Divide decimal", () =>
                {
                    decimal count = decimal.MaxValue;

                    for (int i = 1; i < RepeatCount; i++)
                        count /= i;
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