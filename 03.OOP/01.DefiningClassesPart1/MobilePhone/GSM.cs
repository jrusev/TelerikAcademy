/*
 * Define a class that holds information about a mobile phone device:
 * For complete description of the task see ExerciseDescription.txt
 */

namespace MobilePhone
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Mobile phone device
    /// </summary>
    public class GSM
    {
        /// <summary>
        /// Holds information about iPhone 4S.
        /// </summary>
        private static GSM iPhone4S = new GSM("iPhone4S", "Apple", 500, new Battery("1440 mAh", 10, 3, BatteryType.LiIo), new Display(4.7m, 16000000));

        // Fields
        private string model;
        private string manufacturer;
        private decimal price;
        private string owner;
        private Battery battery;
        private Display display;
        private List<Call> callHistory; // Holds a list of the performed calls.

        // Constructors
        public GSM(string model, string manufacturer)
            : this(model, manufacturer, 0, null, null, null)
        {
        }

        public GSM(string model, string manufacturer, Battery batt, Display disp)
            : this(model, manufacturer, 0, null, batt, disp)
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
            this.callHistory = new List<Call>();
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

            private set
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

            private set
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
                if (value < 0)
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

        public List<Call> CallHistory
        {
            get { return this.callHistory; }
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

        /// <summary>
        /// Opens a new call - creates a new Call object with the dialed number and adds it to the call list.
        /// </summary>
        /// <param name="phoneNum">The dialed number</param>
        public void OpenCall(string phoneNum)
        {
            Call call = new Call(phoneNum);
            this.callHistory.Add(call);
        }

        /// <summary>
        /// Closes a call - ends the last opened call from the call list.
        /// </summary>
        public void CloseCall(int durationSeconds = -1)
        {
            if (this.callHistory.Count == 0)
            {
                throw new ApplicationException("No call to close!");
            }

            Call lastCall = this.callHistory[this.callHistory.Count - 1];
            if (lastCall.IsClosed)
            {
                throw new ApplicationException("No open calls!");
            }

            if (durationSeconds < 0)
            {
                lastCall.EndCall(); // Will calculate the duration by the system clock
            }
            else
            {
                lastCall.EndCall(durationSeconds);
            }            
        }

        /// <summary>
        /// Clears the call history.
        /// </summary>
        public void ClearCallHistory()
        {
            this.CallHistory.Clear();
        }

        /// <summary>
        /// Delete calls from the calls history.
        /// </summary>
        /// <param name="index">The index of the call in the call history.</param>
        public void DeleteCall(int index)
        {
            // RemoveAt will throw ArgumentOutOfRange exception if index is out of range
            this.CallHistory.RemoveAt(index);
        }

        /// <summary>
        /// Calculates the total price of the calls in the call history.
        /// </summary>
        /// <param name="pricePerMinute">The price per minute.</param>
        public decimal TotalCallPrice(decimal pricePerMinute)
        {
            int totalCallTimeSeconds = 0;
            foreach (var call in this.CallHistory)
            {
                totalCallTimeSeconds += call.Duration;
            }

            return totalCallTimeSeconds * pricePerMinute / 60;
        }
    }
}
