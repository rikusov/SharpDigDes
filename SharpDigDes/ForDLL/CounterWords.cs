using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace ForDLL
{
    public static class CounterWords
    {
        private static ConcurrentDictionary<string, int> s_dict = null;
        private static Dictionary<string, int> HowWords(string s){

            Dictionary<string, int> out_dict = new Dictionary<string, int>();

            var new_s = Regex.Matches(Regex.Replace(s.ToLower(), @"[-]|[\d]", ""), @"\w+");

            foreach (Match item in new_s)
            {
                if (out_dict.ContainsKey(item.Value)) out_dict[item.Value]++;
                else out_dict[item.Value] = 1;
            }

            out_dict = out_dict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            return out_dict;
        }

        public static Dictionary<string, int> HowWords_p(string s, int count_thread = 2) {

            s_dict = new ConcurrentDictionary<string, int>();

            var mc = Regex.Matches(Regex.Replace(s.ToLower(), @"[-]|[\d]", ""), @"\w+");

            Task[] a_task = new Task[count_thread];

            for (int i = 0; i < count_thread; i++) {
                int start = i * (int)(mc.Count / count_thread);
                int end = i == count_thread - 1 ? mc.Count : (i + 1) * (int)(mc.Count / count_thread);
                Task task = new Task(() => CountWord(mc, start, end));
                task.Start();
                a_task[i] = task;

            }

            Task.WaitAll(a_task);


            return s_dict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }
        private static void CountWord(MatchCollection mc, int start, int end) {

            for (int i = start; i < end; i++) {
                if (s_dict.ContainsKey(mc[i].Value))
                    s_dict[mc[i].Value]++;
                else
                   s_dict[mc[i].Value] = 1;
            
            }
        
        }



    }
}
