using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ForDLL
{
    public static class CounterWords
    {

        private static Dictionary<string, int> HowWords(string s)
        {
            Dictionary<string, int> out_dict = new Dictionary<string, int>();

            var new_s = Regex.Matches(Regex.Replace(s, @"[-]|[\d]", ""), @"\w+");

            foreach (Match item in new_s)
            {
                if (out_dict.ContainsKey(item.Value)) out_dict[item.Value]++;
                else out_dict[item.Value] = 1;
            }

            out_dict = out_dict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            return out_dict;
        }

        private static string FormatStr(string s)
        {

            string[] ElemChar = new string[] { ",", ".", "!", "?", "(", ")", "-", "\"", "—"};
            string out_str = s;

            
            foreach (string item in ElemChar) out_str = out_str.Replace(item, "");

            return out_str.ToLower();

        }

    }
}
