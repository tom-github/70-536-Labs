using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input_Output
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Enumerating Drives

            foreach (DriveInfo di in DriveInfo.GetDrives())
                Console.WriteLine(" {0} ({1})", di.Name, di.DriveType);

            #endregion

            #region Browsing Folders

            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows");
            Console.WriteLine("Folders:");
            foreach (DirectoryInfo dirInfo in dir.GetDirectories())
                Console.WriteLine(dirInfo.Name);
            Console.WriteLine("\nFiles:");
            foreach (FileInfo fi in dir.GetFiles())
                Console.WriteLine(fi.Name);

            #endregion

            #region Creating Folders

            DirectoryInfo newDir = new DirectoryInfo(@"C:\deleteme");
            if (newDir.Exists)
                Console.WriteLine("The folder already exists");
            else
                newDir.Create();

            #endregion

            #region Creating, Copying, Moving, and Deleting Files

            File.CreateText("mynewfile.txt");
            File.Copy("mynewfile.txt", "newfile2.txt");
            File.Move("newfile2.txt", "newfile3.txt");


            FileInfo fi1 = new FileInfo("mynewfile.txt");
            fi1.CreateText();
            fi1.CopyTo("newfile2.txt");
            FileInfo fi2 = new FileInfo("newfile2.txt");
            fi2.MoveTo("newfile3.txt");

            #endregion

            #region Monitoring the File System

            // Create an instance of FileSystemWatcher
            FileSystemWatcher fsw = new
            FileSystemWatcher(Environment.GetEnvironmentVariable("USERPROFILE"));
            // Set the FileSystemWatcher properties
            fsw.IncludeSubdirectories = true;
            fsw.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite;
            // Add the Changed event handler
            fsw.Changed += new FileSystemEventHandler(fsw_Changed);
            //fsw.Changed += new FileSystemEventHandler(fsw_Renamed);
            // Start monitoring events
            fsw.EnableRaisingEvents = true;

            #endregion

        }

      
        private static void fsw_Renamed(object sender, RenamedEventArgs e)
        {
            // Write the path of a changed file to the console
            Console.WriteLine(e.ChangeType + " from " + e.OldFullPath +
            " to " + e.Name);
        }
        private static void fsw_Changed(object sender, FileSystemEventArgs e)
        {
            // Write the path of a changed file to the console
            Console.WriteLine(e.ChangeType + ": " + e.FullPath);
        }
    }
}
