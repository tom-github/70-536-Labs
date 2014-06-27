using System.Text;
using System.IO;

namespace Convert
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"C:\windows\win.ini");
            StreamWriter sw = new StreamWriter("win-utf7.txt", false, Encoding.UTF7);
            sw.WriteLine(sr.ReadToEnd());
            sw.Close();
            sr.Close();
        }
    }
}
