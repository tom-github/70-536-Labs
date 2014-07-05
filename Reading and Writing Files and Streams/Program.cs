using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reading_and_Writing_Files_and_Streams
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Reading and Writing Text Files

            TextReader tr = File.OpenText(@"C:\windows\win.ini");
            Console.Write(tr.ReadToEnd());
            tr.Close();

            StreamReader sr = new StreamReader(@"C:\windows\win.ini");
            string input;
            while ((input = sr.ReadLine()) != null)
                Console.WriteLine(input);
            sr.Close();

            TextWriter tw = File.CreateText("output.txt");
            tw.WriteLine("Hello, world!");
            tw.Close();

            #region Reading and Writing Binary Files

            #endregion

            // Write ten integers
            FileStream fs = new FileStream("data.bin", FileMode.Create);
            BinaryWriter w = new BinaryWriter(fs);
            for (int i = 0; i < 11; i++)
                w.Write((int)i);
            w.Close();
            fs.Close();
            // Read the data
            fs = new FileStream("data.bin", FileMode.Open, FileAccess.Read);
            BinaryReader r = new BinaryReader(fs);
            for (int i = 0; i < 11; i++)
                Console.WriteLine(r.ReadInt32());
            r.Close();
            fs.Close();

            #endregion

            #region Reading and Writing Strings

            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            sw.Write("Hello, ");
            sw.Write("World!");
            sw.Close();

            StringReader sr1 = new StringReader(sb.ToString());
            Console.WriteLine(sr1.ReadToEnd());
            sr.Close();

            #endregion

            #region Using a MemoryStream

            // Create a MemoryStream object
            MemoryStream ms = new MemoryStream();
            // Create a StreamWriter object to allow
            // writing strings to the MemoryStream
            StreamWriter sw1 = new StreamWriter(ms);
            // Write to the StreamWriter and MemoryStream
            sw1.WriteLine("Hello, World!");
            // Flush the contents of the StreamWriter so it can be written to disk
            sw1.Flush();
            // Write the contents of the MemoryStream to a file
            ms.WriteTo(File.Create("memory.txt"));
            // Close the file and MemoryStream
            sw1.Close();
            ms.Close();

            #endregion

            #region Using Compressed Streams

            // Create a compressed stream using a new file
            GZipStream gzOut = new GZipStream(File.Create("data.zip"),
            CompressionMode.Compress);
            // Create a StreamWriter object to allow
            // writing strings to the GZipStream
            StreamWriter sw2 = new StreamWriter(gzOut);
            // Write data to the compressed stream, and then close it
            for (int i = 1; i < 1000; i++)
                sw2.Write("Hello, World! ");
            // Close the stream objects
            sw2.Close();
            gzOut.Close();
            // Open the file containing the compressed data
            GZipStream gzIn = new GZipStream(File.OpenRead("data.zip"),
            CompressionMode.Decompress);
            // Read and display the compressed data
            StreamReader sr2 = new StreamReader(gzIn);
            Console.WriteLine(sr2.ReadToEnd());
            // Close the stream objects
            sr2.Close();
            gzIn.Close();

            #endregion

            #region How to Access Isolated Storage

            // Get the store isolated by the assembly
            IsolatedStorageFile isoStore =
            IsolatedStorageFile.GetUserStoreForAssembly();
            // Create the isolated storage file in the assembly we just grabbed
            IsolatedStorageFileStream isoFile0 = new
            IsolatedStorageFileStream("myfile.txt", FileMode.Create, isoStore);
            // Create a StreamWriter using the isolated storage file
            StreamWriter sw0 = new StreamWriter(isoFile0);
            // Write a line of text to the file
            sw0.WriteLine("This text is written to a isolated storage file.");
            // Close the file
            sw0.Close();

            // Get the store isolated by the assembly
            IsolatedStorageFile isoStore1 =
            IsolatedStorageFile.GetUserStoreForAssembly();
            // Open the isolated storage file in the assembly we just grabbed
            IsolatedStorageFileStream isoFile1 = new
            IsolatedStorageFileStream("myfile.txt", FileMode.Open, isoStore1);
            // Create a StreamReader using the isolated storage file
            StreamReader sr3 = new StreamReader(isoFile1);
            // Read a line of text from the file
            string fileContents = sr3.ReadLine();
            // Close the file
            sr3.Close();

            #endregion
        }
    }
}
