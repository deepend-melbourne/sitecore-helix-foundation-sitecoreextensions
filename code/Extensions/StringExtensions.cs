using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Sitecore.Foundation.SitecoreExtensions.Extensions
{
    public static class StringExtensions
    {
        public static string Humanize(this string input)
        {
            return Regex.Replace(input, "(\\B[A-Z])", " $1");
        }

        public static string ToCssUrlValue(this string url)
        {
            return string.IsNullOrWhiteSpace(url) ? "none" : $"url('{url}')";
        }

        /// <summary>
        /// Encodes the provided string to Base64
        /// </summary>
        /// <param name="plainText">UTF8 string</param>
        /// <returns>plainText encoded to a Base64 string</returns>
        public static string EncodeToBase64(this string plainText)
        {
            if (plainText == null)
            {
                return null;
            }

            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        /// <summary>
        /// Decodes the provided string from Base64 to plain text
        /// </summary>
        /// <param name="encodedText">Base64 string</param>
        /// <returns>encodedText decoded to a plain text UTF8 string</returns>
        public static string DecodeFromBase64(this string encodedText)
        {
            if (encodedText == null)
            {
                return null;
            }

            var base64EncodedBytes = System.Convert.FromBase64String(encodedText);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static IEnumerable<string> AsSplitList(this string value, string separator = ",")
        {
            return !string.IsNullOrEmpty(value) ? value.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries) : Enumerable.Empty<string>();
        }

        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value))
                return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength) + "...";
        }

        /// <summary>
        /// Returns the provided default value if the string is null or empty
        /// </summary>
        /// <param name="value">The value to be tested for being null or empty</param>
        /// <param name="defaultValue">The default value</param>
        /// <returns>Returns defaultValue if value is null or empty; otherwise value</returns>
        public static string DefaultIfNullOrEmpty(this string value, string defaultValue)
        {
            return !string.IsNullOrEmpty(value) ? value : defaultValue;
        }

        /// <summary>
        /// Returns the provided default value if the string is null, empty or whitespace
        /// </summary>
        /// <param name="value">The value to be tested for being null, empty or whitespace</param>
        /// <param name="defaultValue">The default value</param>
        /// <returns>Returns defaultValue if value is null, empty or whitespace; otherwise value</returns>
        public static string DefaultIfNullOrWhitespace(this string value, string defaultValue)
        {
            return !string.IsNullOrWhiteSpace(value) ? value : defaultValue;
        }
    }
}
