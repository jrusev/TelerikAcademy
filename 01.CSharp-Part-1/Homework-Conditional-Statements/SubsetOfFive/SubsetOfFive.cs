using System;

class SubsetOfFive
{
    static void Main()
    {
        // We are given 5 integer numbers. Write a program that checks if the sum of some subset of them is 0.
        // Example: 3, -2, 1, 1, 8 -> 1+1-2=0.

        Console.WriteLine("Enter five integer numbers:");
        int[] number = new int[5]; // array of 5 elements to store the five numbers
        for (int i = 0; i < 5; i++)
        {
            number[i] = int.Parse(Console.ReadLine());
        }
        int countZeroSubsets = 0; // count how many subsets have a sum of 0
        int countChecks = 0; // count how many combinations of numbers are checked for their sum
        Console.WriteLine("The sum of the following subset(s) of numbers is 0:");
        for (int i = 0; i < 5; i++)
        {
            countChecks++;
            // check the subset of 1 number (5 subsets)
            if (number[i] == 0)
            {
                countZeroSubsets++;
                Console.WriteLine("[{0}]",number[i]);
            }
            for (int j = i + 1; j < 5; j++)
            {
                countChecks++;
                // check the subset of 2 numbers (10 subsets)
                if ((number[i] + number[j]) == 0)
                {
                    countZeroSubsets++;
                    Console.WriteLine("[{0},{1}]", number[i], number[j]);
                }
                for (int k = j + 1; k < 5; k++)
                {
                    countChecks++;
                    // check the subset of 3 numbers (10 subsets)
                    if ((number[i] + number[j] + number[k]) == 0)
                    {
                        countZeroSubsets++;
                        Console.WriteLine("[{0}, {1}, {2}]", number[i], number[j], number[k]);
                    }
                    for (int l = k + 1; l < 5; l++)
                    {
                        countChecks++;
                        // check the subset of 4 numbers (5 subsets)
                        if ((number[i] + number[j] + number[k] + number[l]) == 0)
                        {
                            countZeroSubsets++;
                            Console.WriteLine("[{0}, {1}, {2}, {3}]", number[i], number[j], number[k], number[l]);
                        }
                        for (int m = l + 1; m < 5; m++)
                        {
                            countChecks++;
                            // check the subset of 5 numbers (1 subset)
                            if ((number[i] + number[j] + number[k] + number[l] + number[m]) == 0)
                            {
                                countZeroSubsets++;
                                Console.WriteLine("[{0}, {1}, {2}, {3}, {4}]", number[i], number[j], number[k], number[l], number[m]);
                            }                            
                        }                        
                    }
                }
            }
        }
        if (countZeroSubsets == 0)
        {
            Console.WriteLine("There are no subsets whose sum is 0.");            
        }
        Console.WriteLine("Total subsets checked: {0}.",countChecks);
    }
}