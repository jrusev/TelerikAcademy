namespace CalendarSystem.Client
{
    using System;
    using System.Linq;

    // Parses an input string and returns a command
    public class CommandParser
    {
        private CommandFactory factory;

        public CommandParser(CommandFactory factory)
        {
            this.factory = factory;
        }

        public ICommand Parse(string input)
        {
            int indexOfFirstSpace = input.IndexOf(' ');
            if (indexOfFirstSpace == -1)
            {
                throw new InvalidOperationException("Invalid command: " + input);
            }

            string cmdName = input.Substring(0, indexOfFirstSpace);

            string cmdParamsString = input.Substring(indexOfFirstSpace + 1);
            var cmdParams = cmdParamsString.Split('|').Select(arg => arg.Trim()).ToArray();

            ICommand command = this.factory.CreateCommand(cmdName, cmdParams);
            return command;
        }
    }
}