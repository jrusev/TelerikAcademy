namespace CalendarSystem.Client
{
    public class CmdDeleteEvents : ICommand
    {
        private CalendarSystemController controller;
        private string[] parameters;

        public CmdDeleteEvents(CalendarSystemController controller, string[] parameters)
        {
            this.controller = controller;
            this.parameters = parameters;
        }

        public string Execute()
        {
            return this.controller.DeleteEvents(this.parameters);
        }
    }
}
