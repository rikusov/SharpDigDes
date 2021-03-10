using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace ForDLL
{
    public static class CounterWords
    {

        private static Dictionary<string, int> HowWords(string s)
        {
            //Stopwatch SWatch = new Stopwatch();
            //SWatch.Start();
            Dictionary<string, int> out_dict = new Dictionary<string, int>();
            //SWatch.Stop();
            //System.Console.WriteLine("Create dict:" + SWatch.Elapsed);

            //SWatch.Start();
            var new_s = Regex.Matches(Regex.Replace(s, @"[-]|[\d]", ""), @"\w+");
            //SWatch.Stop();
            //System.Console.WriteLine("Regex:" + SWatch.Elapsed);

            foreach (Match item in new_s)
            {
                if (out_dict.ContainsKey(item.Value)) out_dict[item.Value]++;
                else out_dict[item.Value] = 1;
            }

            out_dict = out_dict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            return out_dict;
        }


    }
}
