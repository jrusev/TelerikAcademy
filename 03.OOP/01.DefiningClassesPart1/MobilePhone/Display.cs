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
    /// Display - size and number of colors
    /// </summary>
    public class Display
    {
        private uint sizeInches;
        private uint totalColors;

        // Paramerless constrcutor - assume size is 1 inch, and has 1 color
        public Display() : this(1, 1)
        {
        }

        public Display(uint diagonal, uint colors)
        {
            this.SizeInches = diagonal;
            this.TotalColors = colors;
        }

        public uint SizeInches
        {
            get { return this.sizeInches; }
            set { this.sizeInches = value; }
        }

        public uint TotalColors
        {
            get { return this.totalColors; }
            set { this.totalColors = value; }
        }
    }
}
