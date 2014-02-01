namespace MobilePhone
{
    /// <summary>
    /// Battery - model, hours idle and hours talk
    /// </summary>
    public class Battery
    {
        // Fields
        public readonly BatteryType Type;

        public readonly string Model;

        public readonly uint HoursIdle;

        public readonly uint HoursTalk;

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
    }
}
