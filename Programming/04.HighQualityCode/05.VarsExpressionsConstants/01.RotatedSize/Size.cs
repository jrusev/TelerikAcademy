public class Size
{
    public Size(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }

    public double Width { get; set; }

    public double Height { get; set; }

    public override string ToString()
    {
        return string.Format("width: {0:F2}, height {1:F2}", this.Width, this.Height);
    }
}