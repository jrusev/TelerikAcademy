using System;
using System.Collections.Generic;

// Define a class ListItem<T> that has two fields: value (of type T) and NextItem (of type ListItem<T>). 
public class ListItem<T>
{
    /// <summary>
    /// Initializes a new instance of the ListItem<T> class, containing the specified value.
    /// </summary>
    /// <param name="value">The value to contain in the ListItem<T>.</param>
    public ListItem(T value)
    {
        this.Value = value;
        this.NextItem = null;
    }

    public T Value { get; set; }

    public ListItem<T> NextItem { get; set; }

    public override string ToString()
    {
        return this.Value.ToString();
    }
}
