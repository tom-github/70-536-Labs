using System;
using System.Collections.Generic;
using System.Text;

namespace AppDomainDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an AppDomain.
            AppDomain d = AppDomain.CreateDomain("New Domain");

            // Run the assembly
            // TODO: Edit the path to the executable file
            d.ExecuteAssemblyByName("ShowWinIni");
        }
    }
}
