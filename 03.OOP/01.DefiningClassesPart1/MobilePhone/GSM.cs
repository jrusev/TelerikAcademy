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
        // Fields
        private string model;
        private string manufacturer;
        private uint price;
        private string owner;
        private Battery battery;
        private Display display;

        // Add a static field and a property IPhone4S in the GSM class to hold the information about iPhone 4S.
        private static string iOS = "7.0.4";

        // Constructors
        public GSM(string model, string manufacturer)
            : this(model, manufacturer, 0, null, null, null)
        {
        }

        public GSM(string model, string manufacturer, Battery batt, Display disp)
            : this(model, manufacturer, 0, null, batt, disp)
        {
        }

        public GSM(string model, string manufacturer, uint price, string owner, Battery batt, Display disp)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.Battery = batt;
            this.Display = disp;
        }

        // Properties
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

        public uint Price
        {
            get { return this.price; }
            set { this.price = value; }
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

        public static string IOS
        {
            get { return GSM.iOS; }
            set { GSM.iOS = value; }
        }

        // Methods
        public override string ToString()
        {
            return string.Format("Model: {0}\nManufacturer: {1}\nPrice: ${2}\nOwner: {3}\nBattery: {4}\n",
                this.Model, this.Manufacturer, this.Price, this.Owner ?? "unknown", this.Battery != null ? this.Battery.Type.ToString() : "unknown");
        }
    }
}
