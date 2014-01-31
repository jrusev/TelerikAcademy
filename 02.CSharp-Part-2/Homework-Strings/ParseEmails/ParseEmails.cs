using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class ParseEmails
{
    static void Main()
    {
        // Write a program for extracting all email addresses from given text.
        // All substrings that match the format <identifier>@<host>…<domain> should be recognized as emails.

        string text = "Valid emails in the format <identifier>@<host>…<domain> : example@gmail.com or ab@cd.uk or test.user@yahoo.co.uk. # Not valid emails: test@test. @gmail.com. a@a.b.";

        List<string> emailAddresses = ParseEmailAddresses(text);

        foreach (var email in emailAddresses)
        {
            Console.WriteLine(email);
        }
    }

    // Finds email addresses in a text and returns them in list
    static List<string> ParseEmailAddresses(string text)
    {
        List<string> emailAddresses = new List<string>();

        // Split the text to words
        string[] splitted = text.Split(' ');

        // Perform a series of checks on each word
        for (int i = 0; i < splitted.Length; i++)
        {
            string word = splitted[i];

            if (!word.Contains("@")) continue;

            string[] parts = word.Split('@');
            if (parts.Length > 2) continue;

            // The word contains one '@'
            // Check the left side
            string identifier = parts[0];
            if (identifier.Length < 2) continue;
            if (identifier[0] == '.') continue;

            // The word has a correct identifier
            // Check the right side
            string rightSide = parts[1];

            if (rightSide.Length < 4) continue;

            if (!rightSide.Contains(".")) continue;

            if (rightSide[rightSide.Length - 1] == '.')
                rightSide = rightSide.Remove(rightSide.Length - 1);

            if (!rightSide.Contains(".")) continue;

            int indexOfPoint = rightSide.IndexOf('.');

            string domain = rightSide.Substring(indexOfPoint);

            if (domain.Length < 2) continue;

            // The word has a valid domain
            // Check the host
            string host = rightSide.Substring(0, indexOfPoint);

            if (host.Length < 2) continue;

            // Remove the point at the end of the domain
            if (word[word.Length - 1] == '.')
                word = word.Remove(word.Length - 1);

            // The word is a valid email address
            emailAddresses.Add(word);
        }

        return emailAddresses;
    }
}