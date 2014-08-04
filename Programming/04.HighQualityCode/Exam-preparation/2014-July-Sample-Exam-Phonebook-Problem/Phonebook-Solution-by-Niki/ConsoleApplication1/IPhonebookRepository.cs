namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    public interface IPhonebookRepository
    {
        /// <summary>
        /// Adds a new entry to the phone book.
        /// The names in the phonebook are unique (duplicates are not accepted) and case-insensitive.
        /// Adding phones for same name always performs merging: only the non-repeating canonical phones enter in the list of phones. 
        /// </summary>
        /// <param name="name">The name of the phone numbers holder</param>
        /// <param name="phoneNumbers">List of phone numbers</param>
        /// <returns>Returns if the entries are merged.</returns>
        bool AddPhone(string name, IEnumerable<string> phoneNumbers);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldPhoneNumber"></param>
        /// <param name="newPhoneNumber"></param>
        /// <returns></returns>
        int ChangePhone(string oldPhoneNumber, string newPhoneNumber);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        PhoneEntry[] ListEntries(int startIndex, int count);
    }
}
