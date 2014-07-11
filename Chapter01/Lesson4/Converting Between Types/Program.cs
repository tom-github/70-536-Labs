using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converting_Between_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Conversion

            int i0 = 1;
            double d = 1.0001;
            d = i0; // Conversion allowed.

            #endregion

            #region What Are Boxing and Unboxing?

            //Boxing converts a value type to a reference type
            int i = 123;
            object o = (object)i;

            //Unboxing convets a reference type to value type
            object o1 = 123;
            int i1 = (int)o1;

            #endregion

            #region How to Implement Conversion in Custom Types

            TypeA a; int i2;
            // Widening conversion is OK implicit.
            a = 42; // Rather than a.Value = 42
            // Narrowing conversion must be explicit in C#.
            i2 = (int)a; // Rather than i = a.Value
            Console.WriteLine("a = {0}, i2 = {1}", a.ToString(), i2.ToString());


            TypeA a1; bool b;
            a1 = 42;
            // Convert using ToBoolean.
            b = Convert.ToBoolean(1);
            Console.WriteLine("a1 = {0}, b = {1}", a.ToString(), b.ToString());


            #endregion
        }

    }
    struct TypeA
    {
        public int Value;
        // Allows implicit conversion from an integer.
        public static implicit operator TypeA(int arg)
        {
            TypeA res = new TypeA();
            res.Value = arg;
            return res;
        }
        // Allows explicit conversion to an integer.
        public static explicit operator int(TypeA arg)
        {
            return arg.Value;
        }
        // Provides string conversion (avoids boxing).
        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
