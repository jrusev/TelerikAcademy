namespace Phonebook.Tests
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AddPhoneTests
    {
        [TestMethod]
        public void AddNonExistingPhoneEntryShouldReturnTrue()
        {
            IPhonebookRepository repository = new PhonebookRepositoryWithDictionary();

            var result = repository.AddPhone("Pesho", new List<string>() { });

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void AddExistingPhoneEntryShouldReturnFalse()
        {
            IPhonebookRepository repository = new PhonebookRepositoryWithDictionary();

            repository.AddPhone("Pesho", new List<string>() { });
            var result = repository.AddPhone("Pesho", new List<string>() { });

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void AddPhoneShouldMergeWithExistingPhoneNumbers()
        {
            IPhonebookRepository repository = new PhonebookRepositoryWithDictionary();

            repository.AddPhone("Pesho", new List<string>() { "112", "911" });
            var result = repository.AddPhone("Pesho", new List<string>() { "112" });

            Assert.AreEqual(2, repository.ListEntries(0, 1)[0].PhoneNumbers.Count);
        }

        [TestMethod]
        public void AddPhoneShouldMergeWithNewPhoneNumbers()
        {
            IPhonebookRepository repository = new PhonebookRepositoryWithDictionary();

            repository.AddPhone("Pesho", new List<string>() { "112", "911" });
            var result = repository.AddPhone("Pesho", new List<string>() { "113" });

            Assert.AreEqual(3, repository.ListEntries(0, 1)[0].PhoneNumbers.Count);
        }

        // TODO: Test Pesho and pesho are the same entry
    }
}
