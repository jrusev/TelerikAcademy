/*
 * Define a class that holds information about a mobile phone device:
 * model, manufacturer, price, owner, battery characteristics (model, hours idle and hours talk)
 * and display characteristics (size and number of colors).
 * Define 3 separate classes (class GSM holding instances of the classes Battery and Display).
 */

namespace MobilePhone
{
    using System;

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
