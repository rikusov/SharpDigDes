using System;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace ForExe
{
    class Program
    {
        static void Main(string[] args)
        {
            var tm = typeof(ForDLL.CounterWords).GetMethod("HowWords" ,BindingFlags.NonPublic | BindingFlags.Static);


            var dict = tm.Invoke(null,new Object[] { ReadFile() });

            WriteFile((Dictionary<string,int>)dict);

            //Console.ReadKey();

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
