using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Forming_Regular_Expressions
{
    class Program
    {
        static void Main(string[] args)
        {

            #region How to Use Regular Expressions for Pattern Matching

            Console.Write("Enter regular expression: ");
            string regularExpression = Console.ReadLine();
            Console.Write("Enter input for comparison: ");
            string input = Console.ReadLine();
            if (Regex.IsMatch(input, regularExpression))
                Console.WriteLine("Input matches regular expression.");
            else
                Console.WriteLine("Input DOES NOT match regular expression.");


            //C:\>TestRegExp
            //Enter regular expression: ^\d{5}$
            //Enter input for comparison: 1234
            //InputDOESNOTmatchregularexpression.
            //C:\>TestRegExp
            //Enter regular expression: ^\d{5}$
            //Enter input for comparison: 12345
            //Inputmatchesregularexpression.


            Regex.IsMatch("pattern", @"\Apattern\Z");

            string s = "abc\r\ndef\r\nghi";

            Regex.IsMatch(s, "^def$");

            Regex.IsMatch(s, "^def$", RegexOptions.Multiline);

            #endregion

            #region How to Extract Matched Data

            string input1 = "Company Name: Contoso, Inc.";
            Match m = Regex.Match(input1, @"Company Name: (.*$)");
            Console.WriteLine(m.Groups[1]);


            #endregion

            #region How to Replace Substrings Using Regular Expressions

            //MDYToDMY
            //CleanInput

            #endregion
        }
        void DumpHrefs(String inputString)
        {
            Regex r;
            Match m;
            r = new Regex(@"href\s*=\s*(?:""(?<1>[^""]*)""|(?<1>\S+))",
            RegexOptions.IgnoreCase | RegexOptions.Compiled);
            for (m = r.Match(inputString); m.Success; m = m.NextMatch())
            {
                Console.WriteLine("Found href " + m.Groups[1] + " at "
                + m.Groups[1].Index);
            }
        }
        String Extension(String url)
        {
            Regex r = new Regex(@"^(?<proto>\w+)://[^/]+?(?<port>:\d+)?/",
            RegexOptions.Compiled);
            return r.Match(url).Result("${proto}${port}");
        }
        String MDYToDMY(String input)
        {
            return Regex.Replace(input,
            @"\b(?<month>\d{1,2})/(?<day>\d{1,2})/(?<year>\d{2,4})\b",
            "${day}-${month}-${year}");
        }
        String CleanInput(string strIn)
        {
            // Replace invalid characters with empty strings.
            return Regex.Replace(strIn, @"[^\w\.@-]", "");
        }
    }
}
