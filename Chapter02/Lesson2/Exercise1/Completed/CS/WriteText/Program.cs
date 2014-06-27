using System;
using System.IO;

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

            // Write the contents of the MemoryStream to a file
            FileStream fs = File.Create("output.txt");
            ms.WriteTo(fs);

            // Close the file and MemoryStream
            sw.Close();
            ms.Close();
            fs.Close();

            // Display the file to the console
            TextReader tr = File.OpenText("output.txt");
            Console.Write(tr.ReadToEnd());
            tr.Close();
        }
    }
}
