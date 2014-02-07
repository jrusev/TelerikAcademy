using System;
using System.Threading;

// The delegate type used to call other methods.
public delegate void TimerDelegate(string source);

/// <summary>
/// Generates recurring events in an application using a delegate.
/// </summary>
public class Timer
{
    // A separate thread for the timer to run without blocking the main application
    private readonly Thread timerThread;

    // Constructor
    public Timer(int t = 100)
    {
        if (t <= 0)
        {
            throw new ApplicationException("Timer interval must be greater than zero!");
        }

        this.Interval = t;
        this.timerThread = new Thread(() =>
        {
            while (Elapsed == null)
            {
            }

            while (Elapsed != null)
            {
                this.Elapsed("Elapsed delegate");
                Thread.Sleep(this.Interval);
            }
        });

        this.timerThread.Start();
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
    public int Interval { get; set; }
}