using System;
using System.Collections.Generic;
using System.Text;
using System.Security;
using System.Security.Policy;

namespace AppDomainDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an Evidence object for the Internet zone
            Zone safeZone = new Zone(SecurityZone.Internet);
            object[] hostEvidence = { new Zone(SecurityZone.Internet) };
            Evidence e = new Evidence(hostEvidence, null);

            // Create an AppDomain.
            AppDomain d = AppDomain.CreateDomain("New Domain", e);

            // Run the assembly
            d.ExecuteAssemblyByName("ShowWinIni");
        }
    }
}
