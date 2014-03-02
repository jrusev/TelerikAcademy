using System;
using System.Collections.Generic;

public class AudioDocument : MultimediaDocument
{
    public string SampleRate { get; protected set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "samplerate")
        {
            this.SampleRate = value;
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("samplerate", this.SampleRate));
        base.SaveAllProperties(output);
    }
}