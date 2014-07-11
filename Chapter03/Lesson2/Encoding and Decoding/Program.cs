using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encoding_and_Decoding
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Using the Encoding Class

            // Get Korean encoding
            Encoding e = Encoding.GetEncoding("Korean");
            // Convert ASCII bytes to Korean encoding
            byte[] encoded;
            encoded = e.GetBytes("Hello, World!");
            // Display the byte codes
            for (int i = 0; i < encoded.Length; i++)
                Console.WriteLine("Byte {0}: {1}", i, encoded[i]);

            #endregion

            #region How to Examine Supported Code Pages

            EncodingInfo[] ei = Encoding.GetEncodings();
            foreach (EncodingInfo e1 in ei)
                Console.WriteLine("{0}: {1}, {2}", e1.CodePage, e1.Name, e1.DisplayName);

            #endregion

            #region How to Specify the Encoding Type When Writing a File

            StreamWriter swUtf7 = new StreamWriter("utf7.txt", false, Encoding.UTF7);
            swUtf7.WriteLine("Hello, World!");
            swUtf7.Close();
            StreamWriter swUtf8 = new StreamWriter("utf8.txt", false, Encoding.UTF8);
            swUtf8.WriteLine("Hello, World!");
            swUtf8.Close();
            StreamWriter swUtf16 = new StreamWriter("utf16.txt", false, Encoding.Unicode);
            swUtf16.WriteLine("Hello, World!");
            swUtf16.Close();
            StreamWriter swUtf32 = new StreamWriter("utf32.txt", false, Encoding.UTF32);
            swUtf32.WriteLine("Hello, World!");
            swUtf32.Close();

            #endregion

            #region How to Specify the Encoding Type When Reading a File

            string fn = "file.txt";
            StreamWriter sw = new StreamWriter(fn, false, Encoding.UTF7);
            sw.WriteLine("Hello, World!");
            sw.Close();
            StreamReader sr = new StreamReader(fn, Encoding.UTF7);
            Console.WriteLine(sr.ReadToEnd());
            sr.Close();


            #endregion
        }
    }
}
