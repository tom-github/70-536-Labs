using System;
using System.IO;

namespace WatchFileSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of FileSystemWatcher
            FileSystemWatcher fsw = new FileSystemWatcher(Environment.GetEnvironmentVariable("USERPROFILE"));

            // Set the FileSystemWatcher properties
            fsw.IncludeSubdirectories = true;
            fsw.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite;

            // Add the Changed event handler
            fsw.Changed += new FileSystemEventHandler(fsw_Changed);
            fsw.Created += new FileSystemEventHandler(fsw_Changed);
            fsw.Deleted += new FileSystemEventHandler(fsw_Changed);
            fsw.Renamed += new RenamedEventHandler(fsw_Renamed);
            
            // Start monitoring events
            fsw.EnableRaisingEvents = true;

            // Wait for user input before ending
            Console.WriteLine("Press a key to end the program.");
            Console.ReadKey();
        }

        static void fsw_Changed(object sender, FileSystemEventArgs e)
        {
            // Write the path of a changed file to the console
            Console.WriteLine(e.ChangeType + ": " + e.FullPath);
        }

        static void fsw_Renamed(object sender, RenamedEventArgs e)
        {
            // Write the path of a changed file to the console
            Console.WriteLine(e.ChangeType + " from " + e.OldFullPath + " to " + e.Name);
        }
    }
}
