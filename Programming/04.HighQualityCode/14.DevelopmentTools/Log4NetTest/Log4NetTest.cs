using System;
using log4net;
using log4net.Config;

class Program
{
    static void Main()
    {
        BasicConfigurator.Configure();

        ILog log = LogManager.GetLogger("log");

        log.Debug("Debug message successfulyl logged!");
        log.Error("Error message successfulyl logged!");
    }
}
