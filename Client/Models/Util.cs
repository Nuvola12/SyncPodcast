using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HonorsClient.Models
{
    internal class Util
    {
        public static string FormatTime(int seconds, bool includeWords)
        {
            int hours = seconds / 3600;
            int minutes = (seconds % 3600) / 60;
            int secs = seconds % 60;

            if (hours > 0)
            {
                if (includeWords) { return string.Format("{0:00} hour {1:00} min {2:00} sec", hours, minutes, secs); }
                return string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, secs);
            }
            else
            {
                if (includeWords) { return string.Format("{1:00} min {2:00} sec", minutes, secs); }
                return string.Format("{0:00}:{1:00}", minutes, secs);
            }
        }

        public static StringContent GetJsonStringContent(string json)
        {
            // Encode the JSON string using HttpUtility.UrlEncode.
            var encodedJson = HttpUtility.UrlEncode(json);

            var content = new StringContent(encodedJson, System.Text.Encoding.UTF8, "application/x-www-form-urlencoded");
            return content;
        }

        public static string ExtractDate(string input)
        {
            string[] parts = input.Split(' ');

            string day = parts[1].Trim(',');
            string month = parts[2];

            string date = $"{day} {month}";

            return date;
        }

        public static string EscapeLabelSpecialCharacters(string input)
        {
            string[] specialCharacters = { "&", "_", ":", "." };
            string[] escapedCharacters = { "&&", "&&_", "&&:", "&&." };

            for (int i = 0; i < specialCharacters.Length; i++)
            {
                input = input.Replace(specialCharacters[i], escapedCharacters[i]);
            }

            return input;
        }
    }
}
