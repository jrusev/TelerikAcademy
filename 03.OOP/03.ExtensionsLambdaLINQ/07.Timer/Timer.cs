using System;

// Using delegates write a class Timer that can execute certain method at each t seconds.
public class Timer
{
    public Action action;

    public int interval_seconds;

    public Timer(int t)
    {
        this.interval_seconds = t;
    }
}