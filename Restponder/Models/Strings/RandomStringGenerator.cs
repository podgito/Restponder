using System;
using System.Linq;

namespace Restponder.Models.Strings
{
    public static class RandomStringGenerator
    {
        private static string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
        private const int MAX_CHARS = 100;

        /// <summary>
        ///
        /// </summary>
        /// <param name="numChars">maxValue is 100</param>
        /// <returns></returns>
        public static string AlphaNumericString(int numChars)
        {
            if (numChars < 0 || numChars > MAX_CHARS) throw new ArgumentOutOfRangeException();

            var random = new Random();
            var result = new string(Enumerable.Repeat(chars, numChars).Select(s => s[random.Next(s.Length)]).ToArray());

            return result;
        }
    }
}