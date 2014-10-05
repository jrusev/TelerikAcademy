namespace SubstringCounter.Service
{
    using System;
    using System.Text.RegularExpressions;

    public class SubstringCounter : ISubstringCounter
    {
        // The method returns the number of times the second string contains the first string.
        public int GetOccurrences(string toBeMatched, string toCountFrom)
        {
            if (toBeMatched == null)
            {
                throw new ArgumentNullException("toBeMatched", "Parameter cannot be null.");
            }

            if (toCountFrom == null)
            {
                throw new ArgumentNullException("toCountFrom", "Parameter cannot be null.");
            }

            int count = Regex.Matches(toCountFrom, toBeMatched).Count;
            return count;
        }
    }
}
