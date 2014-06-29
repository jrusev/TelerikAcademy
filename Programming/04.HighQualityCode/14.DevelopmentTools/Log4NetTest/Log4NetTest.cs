using log4net;
using log4net.Config;
using System;

class Program
{
    static void Main()
    {
        BasicConfigurator.Configure();

        ILog log = LogManager.GetLogger("log");

        log.Debug("Debug message successfulyl logged!");
        log.Error("Error message successfulyl logged!");

        try
        {
            throw new InvalidOperationException();
        }
        catch (InvalidOperationException e)
        {
            log.Fatal("Exception caught:", e);
        }
    }
}
