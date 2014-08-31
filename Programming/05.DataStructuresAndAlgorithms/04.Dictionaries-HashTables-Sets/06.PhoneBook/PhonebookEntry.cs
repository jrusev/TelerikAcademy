public struct PhonebookEntry
{
    public string Name, Town, Phone;

    public override string ToString()
    {
        return string.Format("{0} | {1} | {2}", this.Name, this.Town, this.Phone);
    }
}