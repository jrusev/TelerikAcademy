using System.Collections.Generic;

// Represents a phonebook with entries
public class Phonebook
{
    // The hash table that holds the phonebook entries
    private IDictionary<string, List<PhonebookEntry>> book;

    // Creates a new instance of the Phonebook class which is empty
    public Phonebook()
    {
        this.book = new Dictionary<string, List<PhonebookEntry>>();
    }

    // Creates a new instance of the Phonebook class from a collection of phonebook entries
    public Phonebook(IEnumerable<PhonebookEntry> phonebookEntries) : this()
    {
        foreach (var entry in phonebookEntries)
        {
            this.Add(entry);
        }        
    }

    // Adds an entry to the phonebook
    public void Add(PhonebookEntry entry)
    {
        var names = entry.Name.Split(' ');
        foreach (var name in names)
        {
            this.AddEntry(name, entry);
            this.AddEntry(name + ' ' + entry.Town, entry);
        }
    }

    // Searches the phonebook by provided list of search terms, throws an exception if not found
    public IList<PhonebookEntry> Find(params string[] searchTerms)
    {
        var query = string.Join(" ", searchTerms);
        return this.book[query];
    }

    // Adds a phonebook entry to the internal hash table by key
    private void AddEntry(string key, PhonebookEntry entry)
    {
        if (!this.book.ContainsKey(key))
        {
            this.book[key] = new List<PhonebookEntry>();
        }

        this.book[key].Add(entry);
    }
}
