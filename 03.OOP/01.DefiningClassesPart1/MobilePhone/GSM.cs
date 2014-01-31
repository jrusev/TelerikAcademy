/*
 * Define a class that holds information about a mobile phone device:
 * model, manufacturer, price, owner, battery characteristics and display characteristics.
 * Define 3 separate classes (class GSM holding instances of the classes Battery and Display).
 * For complete description see ExerciseDescription.txt
 */

namespace MobilePhone
{
    using System;

    /// <summary>
    /// Mobile phone device
    /// </summary>
    public class GSM
    {
        // Add a static field and a property IPhone4S in the GSM class to hold the information about iPhone 4S.
        private static GSM iPhone4S = new GSM("iPhone4S", "Apple", 500, new Battery("1440 mAh", 10, 3, BatteryType.LiIo), new Display(4.7m, 16000000));

        // Fields
        private string model;
        private string manufacturer;
        private decimal price;
        private string owner;
        private Battery battery;
        private Display display;

        // Constructors
        public GSM(string model, string manufacturer)
            : this(model, manufacturer, 1, null, null, null)
        {
        }

        public GSM(string model, string manufacturer, Battery batt, Display disp)
            : this(model, manufacturer, 1, null, batt, disp)
        {
        }

        public GSM(string model, string manufacturer, decimal price, Battery batt, Display disp)
            : this(model, manufacturer, price, null, batt, disp)
        {
        }

        public GSM(string model, string manufacturer, decimal price, string owner, Battery batt, Display disp)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.Battery = batt;
            this.Display = disp;
        }

        // Properties
        public static GSM IPhone4S
        {
            get { return GSM.iPhone4S; }
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new FormatException("Model cannot be null!");                    
                }

                this.model = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new FormatException("Manufacturer cannot be null!");
                }

                this.manufacturer = value;
            }
        }

        public decimal Price
        {
            get
            { 
                return this.price;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be negative!");
                }

                this.price = value;
            }
        }

        public string Owner
        {
            get { return this.owner; }
            set { this.owner = value; }
        }

        public Battery Battery
        {
            get { return this.battery; }
            set { this.battery = value; }
        }

        public Display Display
        {
            get { return this.display; }
            set { this.display = value; }
        }

        // Methods
        public override string ToString()
        {
            return string.Format(
                "Model: {0}\nManufacturer: {1}\nPrice: ${2}\nOwner: {3}\nBattery: {4}",
                this.Model,
                this.Manufacturer,
                this.Price,
                this.Owner ?? "unknown",
                this.Battery != null ? this.Battery.Type.ToString() : "unknown");
        }
    }
}
