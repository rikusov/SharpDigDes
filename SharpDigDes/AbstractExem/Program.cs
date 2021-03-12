using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace AbstractExem
{
    public abstract class MyClass {

        public string A = "PublicPerem";
        private string B = "PrivatePerem";

        public void PublicMethod() {

            Console.WriteLine("PublicMethod");
        }
        private void PrivateMethod() {

            Console.WriteLine("PrivateMethod");        
            
        }
    
    } 


    class Program
    {
        static void Main(string[] args)
        {

           // var t = typeof(MyClass);

            //var tt = t.GetType();


            //var constr = typeof(MyClass).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { }, null);

            //var abstrex = System.Activator.CreateInstance(t);

            Assembly asm = Assembly.Load("mscorlib");

            var trt = asm.GetTypes()[298];

            //var t = typeof(MyClass) as Ru;


            //var rt = System.Activator.CreateInstance(trt);

            //var abstex = t.Invoke(new object[] { });

            Console.WriteLine(t);


        }
    }
}
