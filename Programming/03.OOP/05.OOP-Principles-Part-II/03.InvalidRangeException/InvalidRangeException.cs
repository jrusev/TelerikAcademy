public class InvalidRangeException<T> : System.ApplicationException    
{
    private const string OutOfRange = "Value out of range ({0} - {1}).";

    public InvalidRangeException(T min, T max)
        : base(string.Format(OutOfRange, min, max))
    {
        this.Min = min;
        this.Max = max;
    }

    public T Min { get; private set; }

    public T Max { get; private set; }
}