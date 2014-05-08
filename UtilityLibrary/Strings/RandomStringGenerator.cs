using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLibrary.Strings
{
    public static class RandomStringGenerator
    {
        static string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
        const int MAX_CHARS = 100;

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
