public class File
{
    public File(string name, long size)
    {
        this.Name = name;
        this.SizeBytes = size;
    }

    public string Name { get; private set; }

    public long SizeBytes { get; private set; }

    public override string ToString()
    {
        return this.Name + " (" + this.SizeBytes + " bytes)";
    }
}