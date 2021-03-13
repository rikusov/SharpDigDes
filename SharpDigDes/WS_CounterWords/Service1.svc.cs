using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WS_CounterWords
{
    public class Service1 : IService1
    {
        public Dictionary<string, int> HowWords(string s) {
            return ForDLL.CounterWords.HowWords_p(s,Environment.ProcessorCount);
        }
    }
}
