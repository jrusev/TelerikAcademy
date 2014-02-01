namespace MobilePhone
{
    using System;

    /// <summary>
    /// Class Call to hold a call performed through a GSM.
    /// Contains date, time, dialed phone number and duration (in seconds).
    /// </summary>
    public class Call
    {
        // Fields
        private DateTime startCall;

        private DateTime endCall;

        // Constructor
        public Call(string dialedNumber)
        {
            this.startCall = DateTime.Now;
            this.DialedNumber = dialedNumber;
            this.IsClosed = false;
        }

        // Properties
        public string DialedNumber { get; private set; }

        public bool IsClosed { get; private set; }

        /// <summary>
        /// Call duration in seconds.
        /// </summary>
        /// <returns>Returns the time in seconds.</returns>
        public int Duration
        {
            get
            {
                TimeSpan span = this.endCall - this.startCall;
                return (int)span.TotalSeconds;
            }
        }

        // Methods
        public void EndCall()
        {
            this.endCall = DateTime.Now;
            this.IsClosed = true;
        }

        // Methods
        public void EndCall(int durationSeconds)
        {
            this.endCall = this.startCall.AddSeconds(durationSeconds);
            this.IsClosed = true;
        }

        public DateTime Date()
        {
            return this.startCall;
        }
    }
}
