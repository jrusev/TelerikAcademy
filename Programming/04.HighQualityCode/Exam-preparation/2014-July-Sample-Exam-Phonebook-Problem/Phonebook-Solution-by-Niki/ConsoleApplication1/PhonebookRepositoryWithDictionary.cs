namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Wintellect.PowerCollections;

    public class PhonebookRepositoryWithDictionary : IDeletablePhonebookRepository, IPhonebookRepository
    {
        private OrderedSet<PhoneEntry> sorted = new OrderedSet<PhoneEntry>();

        private Dictionary<string, PhoneEntry> dict = new Dictionary<string, PhoneEntry>();

        private MultiDictionary<string, PhoneEntry> multidict = new MultiDictionary<string, PhoneEntry>(false);

        public bool AddPhone(string name, IEnumerable<string> nums)
        {
            string name2 = name.ToLowerInvariant();
            PhoneEntry entry;
            bool entryExists = this.dict.TryGetValue(name2, out entry);
            if (!entryExists)
            {
                entry = new PhoneEntry();
                entry.Name = name;
                entry.PhoneNumbers = new SortedSet<string>();
                this.dict.Add(name2, entry);
                this.sorted.Add(entry);
            }

            foreach (var num in nums)
            {
                this.multidict.Add(num, entry);
            }

            entry.PhoneNumbers.UnionWith(nums);
            return !entryExists;
        }

        public int ChangePhone(string oldent, string newent)
        {
            var found = this.multidict[oldent].ToList();
            foreach (var entry in found)
            {
                entry.PhoneNumbers.Remove(oldent);
                this.multidict.Remove(oldent, entry);
                entry.PhoneNumbers.Add(newent);
                this.multidict.Add(newent, entry);
            }

            return found.Count;
        }

        public PhoneEntry[] ListEntries(int first, int num)
        {
            if (first < 0 || first + num > this.dict.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            PhoneEntry[] list = new PhoneEntry[num];
            for (int i = first; i <= first + num - 1; i++)
            {
                PhoneEntry entry = this.sorted[i];
                list[i - first] = entry;
            }

            return list;
        }

        public bool Remove(string phoneNumber)
        {
            var dictionaryCopy = this.dict.ToList();
            foreach (var entry in dictionaryCopy)
            {
                entry.Value.PhoneNumbers.Remove(phoneNumber);
                if (entry.Value.PhoneNumbers.Count == 0)
                {
                    this.dict.Remove(entry.Key);
                }
            }

            // TODO: Fix
            return true;
            //// TODO: Remove from all collection
        }
    }
}
