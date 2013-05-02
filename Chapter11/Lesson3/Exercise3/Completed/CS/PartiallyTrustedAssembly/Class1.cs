using System;

namespace PartiallyTrustedAssembly
{
	class Class1
	{
		static void Main(string[] args)
		{
            try
            {
                TrustedClass.Distrust.WriteToFileWrapper(@"C:\Inetpub\test-deleteme.txt", "This assembly lacks permissions to write to the file.");
                Console.WriteLine("\nWrote to the file.");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Couldn't write to the file.\n");
                Console.WriteLine(ex.GetType().ToString() + ": " + ex.Message);
            }
		}
	}
}
    