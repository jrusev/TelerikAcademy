using System;
using System.Threading;
using MobilePhone;

// Write a class GSMCallHistoryTest to test the call history functionality of the GSM class:
//    Create an instance of the GSM class.
//    Add few calls.
//    Display the information about the calls.
//    Assuming that the price per minute is 0.37 calculate and print the total price of the calls in the history.
//    Remove the longest call from the history and calculate the total price again.
//    Finally clear the call history and print it.
public class GSMCallHistoryTest
{
    public static void Main()
    {
        // Create the phone
        GSM myPhone = new GSM("Nexus 5", "Google");
        Console.WriteLine("Your phone: {0} {1}\n", myPhone.Manufacturer, myPhone.Model);

        // Let's make some random calls
        int numCalls = 5;
        Random rand = new Random();
        int callNumber;
        int callDuration;
        for (int i = 0; i < numCalls; i++)
        {
            callNumber = rand.Next(884000000, 899999999);
            callDuration = rand.Next(30, 300);

            myPhone.OpenCall("+359" + callNumber);
            myPhone.CloseCall(callDuration);
        }

        // Display the call history
        DisplayCallHistory(myPhone);

        // Display total cost of all calls
        decimal pricePerMinute = 0.37m;
        PrintTotalCost(myPhone, pricePerMinute);

        // Get the longest call
        int longestCallIndex = 0;
        for (int i = 0; i < myPhone.CallHistory.Count; i++)
        {
            if (myPhone.CallHistory[i].Duration > myPhone.CallHistory[longestCallIndex].Duration)
            {
                longestCallIndex = i;
            }
        }

        // Remove the longest call
        myPhone.DeleteCall(longestCallIndex);

        // Display total cost of all calls
        Console.WriteLine("\nAfter removing the longest call from the history:");
        PrintTotalCost(myPhone, pricePerMinute);

        // Clear the call history and print it. 
        Console.WriteLine("\nClear call history...");
        myPhone.ClearCallHistory();
        Console.WriteLine();
        DisplayCallHistory(myPhone);      
    }

    /// <summary>
    /// Display the call history.
    /// </summary>
    /// <param name="phone">The phone whose history to display.</param>
    public static void DisplayCallHistory(GSM phone)
    {
        Console.WriteLine("Call Log");
        Console.WriteLine("=====================");
        if (phone.CallHistory.Count == 0)
        {
            Console.WriteLine("(No calls)");
        }
        else
        {
            foreach (var call in phone.CallHistory)
            {
                Console.WriteLine("Number: {0}", call.DialedNumber);
                Console.WriteLine("Duration: {0} sec", call.Duration);
                Console.WriteLine();
            }
        }
    }

    /// <summary>
    /// Prints the total price of the calls in the phone history.
    /// </summary>
    /// <param name="phone">The phone.</param>
    /// <param name="pricePerMinute">Price per minute.</param>
    static void PrintTotalCost(GSM phone, decimal pricePerMinute)
    {
        Console.WriteLine("Total cost: ${0:F2}", phone.TotalCallPrice(pricePerMinute));
    }
}
