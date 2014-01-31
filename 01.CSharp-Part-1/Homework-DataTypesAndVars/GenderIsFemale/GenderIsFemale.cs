using System;

class GenderIsFemale
{
    static void Main()
    {
        // Declare a boolean variable called isFemale and assign an appropriate value corresponding to your gender.
        Console.WriteLine("Are you a female?");
        bool? isFemale = null; // we start with an empty value, it will be assigned after the user answers the question
        string answer = Console.ReadLine();
        if (answer == "yes" || answer == "Yes")
        {
            isFemale = true;
        }
        else if (answer == "no" || answer == "No")
        {
            isFemale = false;
        }
        // check the value and print it on the console
        if (isFemale.HasValue)
        {
            // if the user has answered with yes or no, isFemale will have a value (true or false)
            Console.WriteLine("isFemale = {0}", isFemale);
        }
        else
        {
            // otherwise isFemale is empty;
            Console.WriteLine("isFemale = UNKOWN"); // 
        }
    }
}