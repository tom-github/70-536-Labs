using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Using_Value_Types
{
    class Program
    {
        enum Titles { Mr, Ms, Mrs, Dr };

        static void Main(string[] args)
        {

            #region How to Declare a Value Type Variable

            // C#
            bool b = false;

            // C#
            Nullable<bool> b1 = null;
            // Shorthand notation, only for C#
            bool? b2 = null;

            // C#
            if (b2.HasValue) Console.WriteLine("b is {0}.", b2.Value);
            else Console.WriteLine("b is not set.");

            #endregion

            #region How to Create User-Defined Types

            // Create point
            Point p = new Point(20, 30);
            // Move point diagonally
            p.Offset(-1, -1);
            Console.WriteLine("Point X {0}, Y {1}", p.X, p.Y);

            Cycle degrees = new Cycle(0, 359);
            Cycle quarters = new Cycle(1, 4);
            for (int i = 0; i <= 8; i++)
            {
                degrees += 90; quarters += 1;
                Console.WriteLine("degrees = {0}, quarters = {1}", degrees, quarters);
            }


            #endregion

            #region How to Create Enumerations

            Titles t = Titles.Dr;
            Console.WriteLine("{0}.", t); // Displays "Dr."
            
            #endregion
        }
    }

    struct Cycle
    {
        // Private fields
        int _val, _min, _max;
        // Constructor
        public Cycle(int min, int max)
        {
            _val = min;
            _min = min;
            _max = max;
        }

        public int Value
        {
            get { return _val; }
            set
            {
                if (value > _max)
                    this.Value = value - _max + _min - 1;
                else
                {
                    if (value < _min)
                        this.Value = _min - value + _max - 1;
                    else
                        _val = value;
                }
            }
        }
        public override string ToString()
        {
            return Value.ToString();
        }
        public int ToInteger()
        {
            return Value;
        }
        public static Cycle operator +(Cycle arg1, int arg2)
        {
            arg1.Value += arg2;
            return arg1;
        }
        public static Cycle operator -(Cycle arg1, int arg2)
        {
            arg1.Value -= arg2;
            return arg1;
        }
    }
}
