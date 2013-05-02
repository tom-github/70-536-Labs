using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Reflection;

namespace Greeter
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string f in Directory.GetFiles(System.Environment.CurrentDirectory, "addon-*.dll"))
            {
                Assembly asm = Assembly.LoadFile(f);

                object[] descs = asm.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                AssemblyDescriptionAttribute desc = (AssemblyDescriptionAttribute)descs[0];
                Console.WriteLine(desc.Description);

                foreach (Type t in asm.GetTypes())
                {
                    if (t.Name.EndsWith("Greeting"))
                    {
                        MethodInfo greet = t.GetMethod("Greet");
                        greet.Invoke(null, null);
                        break;
                    }
                }
            }
        }
    }
}
