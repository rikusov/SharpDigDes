using System;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;


namespace ForExe
{
    class Program
    {
        static void Main(string[] args)
        {
            var tm = typeof(ForDLL.CounterWords).GetMethod("HowWords" ,BindingFlags.NonPublic | BindingFlags.Static);

            Stopwatch watch = new Stopwatch();
            watch.Start();

            var dict = tm.Invoke(null,new Object[] { ReadFile() });

            watch.Stop();
            Console.WriteLine("WitOutTask:" + watch.Elapsed);

            for (int i = 1; i <= 16; i++) {
                watch.Restart();
                var dict2 = ForDLL.CounterWords.HowWords_p(ReadFile(), i);
                watch.Stop();
                Console.WriteLine("WithTask(CountTask = {0}):{1}",i,watch.Elapsed);
                WriteFile((Dictionary<string, int>)dict2, @"C:\Users\Ra19\Documents\project_hlam\Less_Sharp\Les\WAW"+i+".txt");
            }

            WriteFile((Dictionary<string,int>)dict);

            Console.ReadKey();

        }

        static string ReadFile(string path = @"C:\Users\Ra19\Documents\project_hlam\Less_Sharp\Les\WAW.txt") {
            return (new StreamReader(path)).ReadToEnd();
        }

        static void WriteFile(Dictionary<string,int> dict, string path = @"C:\Users\Ra19\Documents\project_hlam\Less_Sharp\Les\WAW1.txt")
        {
            var SW = new StreamWriter(path);

            foreach (KeyValuePair<string, int> item in dict)
                SW.WriteLine("{0} {1}", item.Key, item.Value);

            SW.Close();

        }



    }
}
