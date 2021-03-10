using System.Collections.Generic;
using System.Linq;

namespace ForDLL
{
    public class CounterWords
    {

        private Dictionary<string, int> HowWords(string s)
        {
            Dictionary<string, int> out_dict = new Dictionary<string, int>();


            foreach (string item in FormatStr(s).Split(' '))
            {
                if (item == "" || item == " ") continue;
                if (out_dict.ContainsKey(item)) out_dict[item]++;
                else out_dict[item] = 1;
            }

            out_dict = out_dict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            return out_dict;
        }

        private string FormatStr(string s)
        {

            string[] ElemChar = new string[] { ",", ".", "!", "?", "(", ")" };
            string out_str = s;

            foreach (string item in ElemChar) out_str = out_str.Replace(item, "");

            return out_str.ToLower();

        }

    }
}
