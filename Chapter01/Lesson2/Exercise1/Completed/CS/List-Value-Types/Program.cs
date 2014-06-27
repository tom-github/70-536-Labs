using System;

namespace List_Value_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            const sbyte a = 0;
            const Byte b = 0;
            const Int16 c = 0;
            const Int32 d = 0;
            const Int64 e = 0;
            const string s = "";
            Exception ex = new Exception();
            object[] types = { a, b, c, d, e, s, ex };

            foreach ( object o in types )
            {
                string type;
                if (o.GetType().IsValueType)
                    type = "Value type";
                else
                    type = "Reference Type";
                
                Console.WriteLine("{0}: {1}", o.GetType(), type );
                Console.ReadKey();
            }
        }
    }
}
