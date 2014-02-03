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
        public readonly string DialedNumber;

        private readonly DateTime startCall;

        private DateTime endCall;

        // Constructor
        public Call(string dialedNumber)
        {
            this.startCall = DateTime.Now;
            this.DialedNumber = dialedNumber;
        }

        // Copy constructor
        public Call(Call callToCopy)
        {
            this.DialedNumber = callToCopy.DialedNumber;
            this.startCall = callToCopy.startCall;
            this.endCall = callToCopy.endCall;
        }

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
        public DateTime Date()
        {
            return this.startCall; // DateTime is a struct, so it's immutable
        }

        internal void EndCall()
        {
            this.endCall = DateTime.Now;
        }

        internal void EndCall(int durationSeconds)
        {
            this.endCall = this.startCall.AddSeconds(durationSeconds);
        }
    }
}
