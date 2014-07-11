using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Using_Common_Reference_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Comparing the Behavior of Reference and Value Types

            Numbers n1 = new Numbers(0);
            Numbers n2 = n1;
            n1.val += 1;
            n2.val += 2;
            Console.WriteLine("n1 = {0}, n2 = {1}", n1, n2);

            #endregion

            #region Strings and String Builders

            string s = "this is some text to search";
            s = s.Replace("search", "replace");
            Console.WriteLine(s);

            string s1;
            s1 = "wombat"; // "wombat"
            s1 += " kangaroo"; // "wombat kangaroo"
            s1 += " wallaby"; // "wombat kangaroo wallaby"
            s1 += " koala"; // "wombat kangaroo wallaby koala"
            Console.WriteLine(s1);

            System.Text.StringBuilder sb = new System.Text.StringBuilder(30);
            sb.Append("wombat"); // Build string.
            sb.Append(" kangaroo");
            sb.Append(" wallaby");
            sb.Append(" koala");
            string s2 = sb.ToString(); // Copy result to string.
            Console.WriteLine(s2);

            #endregion

            #region How to Create and Sort Arrays

            // Declare and initialize an array.
            int[] ar = { 3, 1, 2 };
            // Call a shared/static array method.
            Array.Sort(ar);
            // Display the result.
            Console.WriteLine("{0}, {1}, {2}", ar[0], ar[1], ar[2]);

            #endregion

            #region How to Use Streams

            try
            {
                StreamReader sr = new StreamReader(@"C:\boot.ini");
                Console.WriteLine(sr.ReadToEnd());
            }
            catch (Exception ex)
            {
                // If there are any problems reading the file, display an error message
                Console.WriteLine("Error reading file: " + ex.Message);
            }

            try
            {
                StreamReader sr = new StreamReader("text.txt");
                Console.WriteLine(sr.ReadToEnd());
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Console.WriteLine("The file could not be found.");
            }
            catch (System.UnauthorizedAccessException ex)
            {
                Console.WriteLine("You do not have sufficient permissions.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading file: " + ex.Message);
            }

            
            
            StreamReader sr1 = new StreamReader("text.txt");

            try
            {
                Console.WriteLine(sr1.ReadToEnd());
            }
            catch (Exception ex)
            {
                // If there are any problems reading the file, display an error message
                Console.WriteLine("Error reading file: " + ex.Message);
            }
            finally
            {
                // Close the StreamReader, whether or not an exception occurred
                sr1.Close();
            }
            #endregion
        }
    }
    struct Numbers
    {
        public int val;
        public Numbers(int _val)
        { val = _val; }
        public override string ToString()
        { return val.ToString(); }
    }
}
