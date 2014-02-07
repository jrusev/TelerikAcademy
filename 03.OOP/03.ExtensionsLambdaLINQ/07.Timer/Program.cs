using System;

class Program
{
    // Using delegates write a class Timer that can execute certain method at each t seconds.
    static void Main()
    {
        int t_sec = 3;
        Timer timer = new Timer(t_sec);
        timer.action += Console.WriteLine;
    }
}