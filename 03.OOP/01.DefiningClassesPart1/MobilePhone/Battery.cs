namespace MobilePhone
{
    /// <summary>
    /// Battery - model, hours idle and hours talk
    /// </summary>
    public class Battery
    {
        // Constructors
        public Battery() : this(null, 0, 0, BatteryType.LiIo)
        {
        }

        public Battery(string model, uint hoursIdle, uint hoursTalk, BatteryType type)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.Type = type;
        }

        // Properties
        public string Model { get; set; }

        public uint HoursIdle { get; set; }

        public uint HoursTalk { get; set; }

        public BatteryType Type { get; set; }
    }
}
