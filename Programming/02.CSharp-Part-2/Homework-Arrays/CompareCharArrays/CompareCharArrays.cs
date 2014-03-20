using System;

class CompareCharArrays
{
    static void Main()
    {
        /* Write a program that compares two char arrays lexicographically (letter by letter).
         * 
         * In lexicographic order the elements are compared one by one starting from the very left.
         * If the elements are not the same, the array, whose element is smaller (comes earlier in the alphabet), comes first.
         * If the elements are equal, the next character is compared.
         * If the end of one of the arrays is reached, without finding different elements,
         * the shorter array is the smaller (comes earlier lexicographically).
         * If all elements are equal, the arrays are equal.
         */

        // we will start with a string, because it is easier to enter
        // then we will convert it to char array
        Console.Write("Please enter the first word : ");
        string sentenceA = Console.ReadLine();
        Console.Write("Please enter the second word: ");
        string sentenceB = Console.ReadLine();

        char[] arrayA = sentenceA.ToCharArray();
        char[] arrayB = sentenceB.ToCharArray();

        for (int i = 0; i < Math.Min(arrayA.Length, arrayB.Length); i++)
        {
            if (arrayA[i] < arrayB[i])
            {
                Console.WriteLine("{0} < {1}", new String(arrayA), new String(arrayB)); // can't print the array directly or by calling ToString()
                return;
            }
            if (arrayA[i] > arrayB[i])
            {
                Console.WriteLine("{1} < {0}", new String(arrayA), new String(arrayB));
                return;
            }
        }
        // the program will get here if all the characters that were compared were equal
        if (arrayA.Length == arrayB.Length)
        {
            Console.WriteLine("The arrays are equal");
        }
        else
        {
            Console.WriteLine(arrayA.Length < arrayB.Length ? "{0} < {1}" : "{1} < {0}", new String(arrayA), new String(arrayB));
        }
    }
}