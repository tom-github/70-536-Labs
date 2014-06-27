using System;
using System.Collections.Generic;
using System.Text;

namespace Converting
{
    class Program
    {
        static void Main(string[] args)
        {
            Int16 i16 = 1;
            Int32 i32 = 1;
            double db = 1;

            i16 = (short) i32;
            i16 = (short) db;

            i32 = i16;
            i32 = (int) db;

            db = i16;
            db = i32;


        }
    }
}
