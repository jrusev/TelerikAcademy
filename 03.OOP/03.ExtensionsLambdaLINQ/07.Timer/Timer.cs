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
    /// Gets or sets the interval at which to call the Elapsed delegate.
    /// </summary>
    public double Interval { get; set; }

    /// <summary>
    /// The delegate used to invoke other methods.
    /// </summary>
    public TimerDelegate Elapsed { get; set; }

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