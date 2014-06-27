using System;
using System.IO;

namespace BrowseFileSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Display the volumes attached to the computer
            Console.WriteLine("Drives:");
            foreach (DriveInfo di in DriveInfo.GetDrives())
                Console.WriteLine("  {0} ({1})", di.Name, di.DriveType);

            // Prompt the user to enter a drive letter
            Console.WriteLine("\nPress a drive letter to view files and folders");
            ConsoleKeyInfo drive = Console.ReadKey(true);

            // Create a DirectoryInfo object from the drive letter
            DirectoryInfo dir = new DirectoryInfo(drive.Key + @":\");

            // Display the folders in the root of the selected drive
            Console.WriteLine("\nFolders:");
            foreach (DirectoryInfo dirInfo in dir.GetDirectories())
                Console.WriteLine("  " + dirInfo.Name);

            // Display the files in the root of the selected drive
            Console.WriteLine("\nFiles:");
            foreach (FileInfo fi in dir.GetFiles())
                Console.WriteLine("  " + fi.Name);
        }
    }
}
