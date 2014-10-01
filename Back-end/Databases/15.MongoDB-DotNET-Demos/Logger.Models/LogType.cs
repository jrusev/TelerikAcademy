namespace Logger.Models
{
    public class LogType
    {
        public string Type { get; set; }

        public string State { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.State, this.Type);
        }
    }
}
