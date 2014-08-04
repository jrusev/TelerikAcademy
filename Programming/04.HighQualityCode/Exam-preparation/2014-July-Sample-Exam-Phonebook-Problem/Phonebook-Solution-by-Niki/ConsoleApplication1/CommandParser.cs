namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CommandParser : ICommandParser
    {
        public CommandInfo Parse(string text)
        {
            int indexOfTheParentesis = text.IndexOf('(');
            if (indexOfTheParentesis == -1)
            {
                throw new ArgumentException("Invalid command format");
            }

            string commandName = text.Substring(0, indexOfTheParentesis);
            if (!text.EndsWith(")"))
            {
                throw new ArgumentException("Invalid command format");
            }

            string listOfArgumentsAsString = text.Substring(indexOfTheParentesis + 1, text.Length - indexOfTheParentesis - 2);
            var argument = listOfArgumentsAsString.Split(',');
            for (int j = 0; j < argument.Length; j++)
            {
                argument[j] = argument[j].Trim();
            }

            var commandInfo = new CommandInfo
            {
                CommandName = commandName,
                Arguments = argument
            };

            return commandInfo;
        }
    }
}
