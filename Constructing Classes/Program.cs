using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructing_Classes
{
    class Program
    {
        public delegate void MyEventHandler(EventArgs e);
        public static event MyEventHandler MyEvent;

        static void Main(string[] args)
        {
            #region What Is Inheritance?

            try
            {
                throw new DerivedException();
            }
            catch (DerivedException ex)
            {
                Console.WriteLine("Source: {0}, Error: {1}", ex.Source, ex.Message);
            }

            #endregion
            #region What Is an Interface?


            #endregion
            #region How to Create and Consume a Generic Type

            Obj oa = new Obj("Hello, ", "World!");
            Console.WriteLine((string)oa.t + (string)oa.u);
            // Add two strings using the Gen class
            Gen<string, string> ga = new Gen<string, string>("Hello, ", "World!");
            Console.WriteLine(ga.t + ga.u);
            // Add a double and an int using the Obj class
            Obj ob = new Obj(10.125, 2005);
            Console.WriteLine((double)ob.t + (int)ob.u);
            // Add a double and an int using the Gen class
            Gen<double, int> gb = new Gen<double, int>(10.125, 2005);
            Console.WriteLine(gb.t + gb.u);


            // Add a double and an int using the Gen class
            Gen<double, int> gc = new Gen<double, int>(10.125, 2005);
            Console.WriteLine(gc.t + gc.u);
            // Add a double and an int using the Obj class
            Obj oc = new Obj(10125, 2005);
            Console.WriteLine((int)oc.t + (int)oc.u);

            #endregion
            #region How to Use Constraints

            CompGen<int> gc1 = new CompGen<int>(10125, 2005);
            Console.WriteLine(gc1.t1 + gc1.t2);
            // Add a double and an int using the Obj class
            Obj oc1 = new Obj(10125, 2005);
            Console.WriteLine((int)oc1.t + (int)oc1.u);

            #endregion
            #region What Is a Delegate? How to Respond and rise to an Event

            EventArgs e = new EventArgs();

            if (MyEvent != null)
            {
                // Invokes the delegates.
                MyEvent(e);
            }

            // Note that C# requires a check to determine whether handler is null.

            //apply windows forms
            //this button1.Click += new System.EventHandler(this.button1_Click);


            #endregion
            #region What Are Attributes?

            //To specify which security privileges a class requires
            //To specify security privileges to refuse in order to reduce security risk
            //To declare capabilities, such as supporting serialization
            //To describe the assembly by providing a title, description, and copyright notice

            // C# - AssemblyInfo.cs
            //[assembly: AssemblyTitle("ch01cs")]
            //[assembly: AssemblyDescription("Chapter 1 Samples")]
            //[assembly: AssemblyConfiguration("")]
            //[assembly: AssemblyCompany("Microsoft Learning")]
            //[assembly: AssemblyProduct("ch01cs")]
            //[assembly: AssemblyCopyright("Copyright © 2008")]
            //[assembly: AssemblyTrademark("")]

            #endregion region
            #region What Is Type Forwarding?

            //Type forwarding allows you to move a type from one assembly (assembly A) into
            //another (assembly B), and to do so in such a way that it is not necessary to recompile clients that consume assembly A.

            // C#
            //using System.Runtime.CompilerServices;
            //[assembly:TypeForwardedTo(typeof(DestLib.TypeA))]

            #endregion
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Method code
        }

    }
    class DerivedException : System.ApplicationException
    {
        public override string Message
        {
            get { return "An error occurred in the application."; }
        }
    }
    class BigClass : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
    interface IMessage
    {
        bool Send();
        string Message { get; set; }
        string Address { get; set; }
    }
    class EmailMessage : IMessage
    {

        public bool Send()
        {
            throw new NotImplementedException();
        }

        public string Message
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Address
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
    class Obj
    {
        public Object t;
        public Object u;
        public Obj(Object _t, Object _u)
        {
            t = _t;
            u = _u;
        }
    }
    class Gen<T, U>
    {
        public T t;
        public U u;
        public Gen(T _t, U _u)
        {
            t = _t;
            u = _u;
        }
    }
    class CompGen<T> where T : IComparable
    {
        public T t1;
        public T t2;
        public CompGen(T _t1, T _t2)
        {
            t1 = _t1;
            t2 = _t2;
        }
        public T Max()
        {
            if (t2.CompareTo(t1) < 0)
                return t1;
            else
                return t2;
        }
    }

}