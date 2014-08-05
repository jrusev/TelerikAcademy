namespace CalendarSystem.Client
{
    public class CmdAddEvent : ICommand
    {
        private CalendarSystemController controller;
        private string[] parameters;

        public CmdAddEvent(CalendarSystemController controller, string[] parameters)
        {
            this.controller = controller;
            this.parameters = parameters;
        }

        public string Execute()
        {
            return this.controller.AddEvent(this.parameters);
        }
    }
}
