using System;

// Using delegates write a class Timer that can execute certain method at each t seconds.
public class TimerExample
{
    public static void Main()
    {
        // Timer interval in seconds
        double t_sec = 1.0;

        // Create a timer (100 ms interval by default).
        Timer timer = new Timer();

        // Set the interval in milliseconds
        timer.Interval = (int)(t_sec * 1000);

        // Attach our method to the Elapsed delegate
        timer.Elapsed += new TimerDelegate(OnTimerTick);

        Console.WriteLine("Press Enter to exit the program.");
        Console.ReadLine();

        // Unsubscribe from the timer event, this will stop the timer
        timer.Elapsed -= new TimerDelegate(OnTimerTick);
    }

    // This is the method that will be called by the Elapsed delegate 
    // Note that the method is private and it is not called from within this class!
    private static void OnTimerTick(string source)
    {
        Console.WriteLine(
            "{0} was called at {1} by the {2}.",
            System.Reflection.MethodBase.GetCurrentMethod().Name,
            DateTime.Now.ToString("HH:mm:ss"),
            source);
    }
}