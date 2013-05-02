using System;
using System.IO;
using System.IO.IsolatedStorage;

namespace WriteText
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a MemoryStream object
            MemoryStream ms = new MemoryStream();

            // Create a StreamWriter object to allow 
            // writing strings to the MemoryStream
            StreamWriter sw = new StreamWriter(ms);

            Console.WriteLine("Type 'quit' on a blank line to exit.");
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "quit")
                    break;
                sw.WriteLine(input);
            }

            // Flush the contents of the StreamWriter so it can be written to disk
            sw.Flush();

            // Get the store isolated by the assembly
            IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForAssembly();

            // Create the isolated storage file in the assembly we just grabbed
            IsolatedStorageFileStream isoFile = new IsolatedStorageFileStream("output.txt", FileMode.Create, isoStore);

            // Write the contents of the MemoryStream to a file
            ms.WriteTo(isoFile);

            // Close the file and MemoryStream
            sw.Close();
            ms.Close();
            isoFile.Close();

            // Display the file to the console
            IsolatedStorageFileStream readIsoFile = new IsolatedStorageFileStream("output.txt", FileMode.Open, isoStore);
            TextReader tr = new StreamReader(readIsoFile);
            Console.Write(tr.ReadToEnd());
            tr.Close();
        }
    }
}
