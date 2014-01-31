using System;

class Number2Text
{
    static void Main()
    {
        /* Write a program that converts a number in the range [0...999] to a text corresponding to its English pronunciation. Examples:
         * 0 -> "Zero"
         * 273 -> "Two hundred seventy three"
         * 400 -> "Four hundred"
         * 501 -> "Five hundred and one"
         * 711 -> "Seven hundred and eleven"
         */
        while (true)
        {
            Console.WriteLine("Please enter a number between 0 and 999: ");
            int number;
            while (true)
            {
                bool isValidInput = int.TryParse(Console.ReadLine(), out number);
                if (isValidInput && number >= 0 && number <= 999)
                {
                    break; // we exit the cycle, if the user has entered an integer from 0 to 999
                }
                Console.Write("Please enter an integer in the range [0...999]:");
            }
            int digitUnits = number % 10;
            int digitTens = (number / 10) % 10 ;
            int digitHundreds = (number / 100) % 10;

            if (number <= 99)
            {
                Console.WriteLine(Num2Text_0_99(number));
            }
            else // 100 - 999
            {
                int tens = number % 100; // for example (235 % 100 = 35)
                if (tens == 0)
                {
                    Console.WriteLine("{0}", Digit2Text100(digitHundreds));
                }
                else
                {
                    Console.WriteLine("{0} and {1}", Digit2Text100(digitHundreds), Num2Text_0_99(tens));
                }
            }
        }// end big while
    }

    static string Num2Text_0_99(int num) // [0;99] converts to text all numbers from 0 to 99
    {
        string digitText;
        int digitUnits = num % 10;
        int digitTens = (num / 10) % 10;

        if (num <= 9)
        {
            digitText = Digit2Text(digitUnits);
        }
        else if (num <= 19)
        {
            digitText = Num2Text_10_19(num);
        }
        else if (num <= 99)
        {
            digitText = (digitUnits == 0) ? Tens2Text(digitTens) : (Tens2Text(digitTens) + " " + Digit2Text(digitUnits));
        }
        else // 100 - 999
        {
            digitText = "??";
        }
        return digitText;
    }

    static string Digit2Text(int singleDigit) // [0;9]
    {
        string digitText;
        switch (singleDigit)
        {
            case 0: digitText = "zero"; break;
            case 1: digitText = "one"; break;
            case 2: digitText = "two"; break;
            case 3: digitText = "three"; break;
            case 4: digitText = "four"; break;
            case 5: digitText = "five"; break;
            case 6: digitText = "six"; break;
            case 7: digitText = "seven"; break;
            case 8: digitText = "eight"; break;
            case 9: digitText = "nine"; break;
            default: digitText = "?"; break;
        }
        return digitText;
    }

    static string Num2Text_10_19(int number10_19) // [10;19]
    {
        string digitText;
        switch (number10_19)
        {
            case 10: digitText = "ten"; break;
            case 11: digitText = "eleven"; break;
            case 12: digitText = "twelve"; break;
            case 13: digitText = "thirteen"; break;
            case 14: digitText = "fourteen"; break;
            case 15: digitText = "fifteen"; break;
            case 16: digitText = "sixteen"; break;
            case 17: digitText = "seventeen"; break;
            case 18: digitText = "eighteen"; break;
            case 19: digitText = "nineteen"; break;
            default: digitText = "?"; break;
        }
        return digitText;
    }

    static string Tens2Text(int singleDigit) // [2;9] for the first digit of numbers from 20 to 99
    {
        string digitText;
        switch (singleDigit)
        {
            case 2: digitText = "twenty"; break;
            case 3: digitText = "thirty"; break;
            case 4: digitText = "fourty"; break;
            case 5: digitText = "fifty"; break;
            case 6: digitText = "sixty"; break;
            case 7: digitText = "seventy"; break;
            case 8: digitText = "eighty"; break;
            case 9: digitText = "ninety"; break;
            default: digitText = "?"; break;
        }
        return digitText;
    }

    static string Digit2Text100(int singleDigit) // [1;9] for the hundreds digit
    {
        string digitText;
        switch (singleDigit)
        {
            case 1: digitText = "one hundred"; break;
            case 2: digitText = "two hundred"; break;
            case 3: digitText = "three hundred"; break;
            case 4: digitText = "four hundred"; break;
            case 5: digitText = "five hundred"; break;
            case 6: digitText = "six hundred"; break;
            case 7: digitText = "seven hundred"; break;
            case 8: digitText = "eight hundred"; break;
            case 9: digitText = "nine hundred"; break;
            default: digitText = "?"; break;
        }
        return digitText;
    }
}
