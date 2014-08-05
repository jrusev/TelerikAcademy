namespace CalendarSystem.Client
{
    // Executes commands
    public class CommandExecutor
    {
        public string ExecuteCommand(ICommand cmd)
        {
            return cmd.Execute();
        }
    }
}
