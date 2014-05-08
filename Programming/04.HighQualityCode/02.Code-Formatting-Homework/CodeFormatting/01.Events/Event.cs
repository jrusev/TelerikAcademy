using System;
using System.Text;

public class Event : IComparable
{
    public Event(DateTime date, string title, string location)
    {
        this.Date = date;
        this.Title = title;
        this.Location = location;
    }

    public DateTime Date { get; private set; }

    public string Title { get; private set; }

    public string Location { get; private set; }

    public int CompareTo(object obj)
    {
        Event other = obj as Event;

        int compareByDate = this.Date.CompareTo(other.Date);
        int compareByTitle = this.Title.CompareTo(other.Title);
        int compareByLocation = this.Location.CompareTo(other.Location);

        if (compareByDate == 0)
        {
            if (compareByTitle == 0)
            {
                return compareByLocation;
            }                
            else
            { 
                return compareByTitle;
            }
        }
        else
        {
            return compareByDate;
        }            
    }

    public override string ToString()
    {
        StringBuilder toString = new StringBuilder();
        toString.Append(this.Date.ToString("yyyy-MM-ddTHH:mm:ss"));        
        toString.Append(" | " + this.Title);
        if (this.Location != null && this.Location != string.Empty)
        {
            toString.Append(" | " + this.Location);
        }
            
        return toString.ToString();
    }
}
