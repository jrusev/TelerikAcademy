using System;
using System.Diagnostics;

// The delegate type used to call other methods.
public delegate void TimerDelegate(string msg, DateTime date);

/// <summary>
/// Generates recurring events in an application using a delegate.
/// </summary>
public class Timer
{
    // Constructor
    public Timer(double t = 100)
    {
        this.Interval = t;
    }

    /// <summary>
    /// The delegate used to invoke other methods.
    /// The event keyword is simply a modifier that only applies to delegates.
    /// It restricts the access to the delegate to only add/remove methods,
    /// so that subscribers cannot unsubscribe other subscribers, invoke the delegate or set it to null.
    /// </summary>
    public event TimerDelegate Elapsed;

    /// <summary>
    /// Gets or sets the interval at which to call the Elapsed delegate.
    /// </summary>
    public double Interval { get; set; }

    public void Run()
    {
        Stopwatch sw = Stopwatch.StartNew();
        while (!Console.KeyAvailable)
        {
            if (sw.ElapsedMilliseconds >= this.Interval)
            {
                this.Elapsed("Elapsed delegate", DateTime.Now);
                sw.Restart();
            } 
        }
    }
}