using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Document : IDocument
{
    public string Name { get; protected set; }

    public string Content { get; protected set; }

    public virtual void LoadProperty(string key, string value)
    {
        if (key == "name")
        {
            this.Name = value;
        }
        else if (key == "content")
        {
            this.Content = value;
        }
    }

    public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("name", this.Name));
        output.Add(new KeyValuePair<string, object>("content", this.Content));
    }

    public override string ToString()
    {
        // XXXDocument[key1=value1;key2=value2;…]
        // The keys should be ordered alphabetically.
        // Keys with no value should be skipped. 
        StringBuilder sb = new StringBuilder();
        sb.Append(this.GetType().Name);
        sb.Append("[");

        var properties = new List<KeyValuePair<string, object>>();
        this.SaveAllProperties(properties);
        var sortedProps = properties.OrderBy(pair => pair.Key);
        foreach (var keyValuePair in sortedProps)
        {
            if (keyValuePair.Value != null)
            {
                sb.Append(keyValuePair.Key);
                sb.Append("=");
                sb.Append(keyValuePair.Value);
                sb.Append(";");
            }
        }

        sb.Length--;
        sb.Append("]");

        return sb.ToString();
    }
}