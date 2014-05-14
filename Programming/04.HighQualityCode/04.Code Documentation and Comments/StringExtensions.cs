//-----------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="Telerik Academy">
//     Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
// <summary>Extension methods for the System.String class.</summary>
//-----------------------------------------------------------------------
namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Provides extension methods for the <see cref="System.String"/> class.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Returns the MD5 hash of a string.
        /// </summary>
        /// <param name="input">The string whose hash is computed.</param>
        /// <returns>The 128-bit hash of the string.</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new StringBuilder to collect the bytes
            // and create a string.
            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return builder.ToString();
        }

        /// <summary>
        /// Converts the string to <see cref="System.Boolean"/>.
        /// </summary>
        /// <param name="input">The string to convert.</param>
        /// <returns>The <see cref="System.Boolean"/> representation of the current instance.</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Converts the string to <see cref="System.Int16"/>.
        /// </summary>
        /// <param name="input">The string to convert.</param>
        /// <returns>The <see cref="System.Int16"/> representation of the current instance.</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Converts the string to <see cref="System.Int32"/>.
        /// </summary>
        /// <param name="input">The string to convert.</param>
        /// <returns>The <see cref="System.Int32"/> representation of the current instance.</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Converts the string to <see cref="System.Int64"/>.
        /// </summary>
        /// <param name="input">The string to convert.</param>
        /// <returns>The <see cref="System.Int64"/> representation of the current instance.</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Converts the string to <see cref="System.DateTime"/>.
        /// </summary>
        /// <param name="input">The string to convert.</param>
        /// <returns>The <see cref="System.DateTime"/> representation of the current instance.</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Capitalizes the first letter of the input string.
        /// </summary>
        /// <param name="input">The string to capitalize.</param>
        /// <returns>A copy of the string with capital first letter or
        /// the current instance if it is null or empty.
        /// </returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Returns the substring between <paramref name="startString"/> and <paramref name="endString"/> 
        /// starting from <paramref name="startFrom"/> index of the current instance.
        /// </summary>
        /// <param name="input">The current <see cref="System.String"/> instance.</param>
        /// <param name="startString">The string from which the result string starts.</param>
        /// <param name="endString">The string at which the result string ends.</param>
        /// <param name="startFrom">The zero-based character position from which the search starts.</param>
        /// <returns>
        /// The substring from <paramref name="startString"/> to <paramref name="endString"/>
        /// starting from <paramref name="startFrom"/> index of the current instance.
        /// </returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Converts the Cyrillic letters of a string to Latin letters.
        /// </summary>
        /// <param name="input">The current <see cref="System.String"/> instance.</param>
        /// <returns>A string with all Cyrillic letters replaced by their Latin representations.</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Converts the Latin letters of a string to Cyrillic letters.
        /// </summary>
        /// <param name="input">The current <see cref="System.String"/> instance.</param>
        /// <returns>A string with all Latin letters replaced by their Cyrillic representations.</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Converts all Cyrillic letters in the string to their Latin equivalents
        /// and removes all non-alphanumeric characters (excluding the period ".").
        /// </summary>
        /// <param name="input">The string to convert.</param>
        /// <returns>The string with all Cyrillic letters converted to their Latin equivalents
        /// and all non-alphanumeric characters (excluding the period ".") removed.
        /// </returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Converts all Cyrillic letters in the string to their Latin equivalents,
        /// replaces the spaces with hyphens and removes all non-alphanumeric characters 
        /// (excluding the period "." and hyphen "-").
        /// </summary>
        /// <param name="input">The string to convert.</param>
        /// <returns>The string with all Cyrillic letters replaced with their Latin equivalents,
        /// spaces replaced with hyphens and all non-alphanumeric characters 
        /// (excluding the period "." and hyphen "-") removed.
        /// </returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Retrieves the first <paramref name="charsCount"/> characters in the string.
        /// </summary>
        /// <param name="input">The current string.</param>
        /// <param name="charsCount">The number of characters to retrieve.</param>
        /// <returns>A string consisting of the first <paramref name="charsCount"/> characters in the string.</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Retrieves the file extension of the current string (interpreted as a file name) 
        /// or an empty string if there is no valid extension.
        /// </summary>
        /// <param name="fileName">The file name as string.</param>
        /// <returns>The file extension of the filename or an empty string if no valid extension exists.</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Retrieves the corresponding content type for the specified file extension.
        /// </summary>
        /// <param name="fileExtension">The file extension as string.</param>
        /// <returns>The content type for the specified file extension.</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Converts the string to a <see cref="System.Byte"/> array.
        /// </summary>
        /// <param name="input">The string to convert.</param>
        /// <returns>The string as <see cref="System.Byte"/> array.</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
