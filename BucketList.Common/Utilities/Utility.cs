using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BucketList.Common.Utilities
{
    /// <summary>
    /// Utility class
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// Generate Random String
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string GenerateRandomString(int size)
        {
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");
            GuidString = GuidString.Replace('/', 'a');
            return GuidString;
        }

        public static string KeepOnlyAlphabetsAndCovertToLower(string str, int maxLength = 0)
        {
            string processedString = GetMaxLengthString(str, maxLength);

            processedString = Regex.Replace(processedString.ToLower(), @"[^a-z]+", String.Empty);

            return processedString;
        }

        public static string GetMaxLengthString(string str, int maxLength = 0)
        {
            string subString = null;
            if (maxLength > 0)
            {
                int lastIndex = str.Length > maxLength ? maxLength : str.Length;
                subString = str.Substring(0, lastIndex);
            }
            else
            {
                subString = str;
            }
            return subString;
        }
    }
}
