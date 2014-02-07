using System;
using System.Timers;

// Write a class Timer that can execute certain method at each t seconds,
// using .NET events and following the best practices.
public class TimerExample
{
    private static System.Timers.Timer timer;

    public static void Main()
    {
        // Timer interval in seconds
        double t_sec = 1.0;

        // Create a timer (100 ms interval by default).
        timer = new System.Timers.Timer();

        // Set the interval in milliseconds
        timer.Interval = t_sec * 1000;

        // Hook up the Elapsed event for the timer.
        // public event ElapsedEventHandler Elapsed;
        // public delegate void ElapsedEventHandler(object sender, ElapsedEventArgs e);
        // sender: The source of the event.
        // e: An ElapsedEventArgs object that contains the event data (DateTime SignalTime).
        timer.Elapsed += new ElapsedEventHandler(OnTimerTick);

        timer.Enabled = true;

        Console.WriteLine("Press the Enter key to exit the program.");
        Console.ReadLine();
    }

    // Specify what you want to happen when the Elapsed event is raised. 
    private static void OnTimerTick(object source, ElapsedEventArgs e)
    {
        Console.WriteLine(
            "{0} was called at {1} by the Elapsed event.",
            System.Reflection.MethodBase.GetCurrentMethod().Name,
            e.SignalTime.ToString("HH:mm:ss"));
    }
}