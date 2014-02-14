using System;

internal class Program
{
    // Define a class InvalidRangeException<T> that holds information about an error condition related to invalid range.
    // It should hold error message and a range definition [start … end].
    // Write a sample application that demonstrates the InvalidRangeException
    // by entering numbers in the range [1..100] and dates in the range [1.1.1980 … 31.12.2013].
    private static void Main()
    {
        try
        {
            int min = 1;
            int max = 100;
            int number = int.MinValue;
            if (number < min || number > max)
            {
                throw new InvalidRangeException<int>(min, max);
            }
        }
        catch (InvalidRangeException<int> ex)
        {
            Console.WriteLine("Exception caught: {0}", ex.Message);
        }

        try
        {
            DateTime minDate = new DateTime(1980, 1, 1);
            DateTime maxDate = new DateTime(2013, 12, 31);
            DateTime date = DateTime.MinValue;
            if (date < minDate || date > maxDate)
            {
                throw new InvalidRangeException<DateTime>(minDate, maxDate);
            }
        }
        catch (InvalidRangeException<DateTime> ex)
        {
            Console.WriteLine("Exception caught: {0}", ex.Message);
        }
    }
}