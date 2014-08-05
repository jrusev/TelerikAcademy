namespace CalendarSystem.Client
{
    using System;

    // Creates commands by given command name and parameters
    public class CommandFactory
    {
        private CalendarSystemController controller;

        public CommandFactory(CalendarSystemController controller)
        {
            this.controller = controller;
        }

        public ICommand CreateCommand(string cmdName, string[] cmdParams)
        {            
            switch (cmdName)
            {
                case "DeleteEvents":
                    return new CmdDeleteEvents(this.controller, cmdParams);
                case "AddEvent":
                    return new CmdAddEvent(this.controller, cmdParams);
                case "ListEvents":
                    return new CmdListEvents(this.controller, cmdParams);
                default:
                    throw new InvalidOperationException("Invalid command: " + cmdName);
            }
        }
    }
}
