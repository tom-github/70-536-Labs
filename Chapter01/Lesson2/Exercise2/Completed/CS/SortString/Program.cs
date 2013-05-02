using System;

namespace SortString
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Microsoft .NET Framework Application Development Foundation";
            string[] sa = s.Split(' ');
            Array.Sort(sa);
            s = string.Join(" ", sa);
            Console.WriteLine(s);
        }
    }
}
