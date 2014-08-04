namespace Phonebook
{
    using Phonebook.Command;

    public interface ICommandFactory
    {
        IPhonebookCommand CreateCommand(string commandName, int argumentsCount);
    }
}
