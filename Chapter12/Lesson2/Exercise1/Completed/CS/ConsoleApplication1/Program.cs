using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.AccessControl;
using System.Security.Policy;
using System.Security.Principal;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectorySecurity ds = new DirectorySecurity();
            ds.AddAccessRule(new FileSystemAccessRule("Guest",
                FileSystemRights.Read, AccessControlType.Allow));
            string newFolder = System.IO.Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Guest");
            Directory.CreateDirectory(newFolder, ds);

            string newFile = System.IO.Path.Combine(newFolder, "Data.dat");
            File.Create(newFile);
        }
    }
}
