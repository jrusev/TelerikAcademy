namespace CalendarSystem.Client
{
    public class CmdListEvents : ICommand
    {
        private CalendarSystemController controller;
        private string[] parameters;

        public CmdListEvents(CalendarSystemController controller, string[] parameters)
        {
            this.controller = controller;
            this.parameters = parameters;
        }

        public string Execute()
        {
            return this.controller.ListEvents(this.parameters);
        }
    }
}
