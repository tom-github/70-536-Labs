using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Managing_Threads
{
    class Program
    {

        static void Main(string[] args)
        {
            #region Starting and Stopping Threads

            // Create the thread object, passing in the
            // DoWork method using a ThreadStart delegate.
            Thread DoWorkThread = new Thread(new ThreadStart(DoWork));
            // Start the thread.
            DoWorkThread.Start();
            // Wait one second to allow the thread to begin to run
            Thread.Sleep(1000);
            // Abort the thread
            DoWorkThread.Abort();
            Console.WriteLine("The Main() thread is ending.");
            Thread.Sleep(6000);

            #endregion

            #region Passing Data to and from Threads

            // Supply the state information required by the task.
            Multiply m = new Multiply("Hello, world!", 13, new Managing_Threads.Multiply.ResultDelegate(ResultCallback));
            Thread t = new Thread(new ThreadStart(m.ThreadProc));
            t.Start();
            Console.WriteLine("Main thread does some work, then waits.");
            t.Join();
            Console.WriteLine("Thread completed.");
            Console.ReadKey();

            #endregion
        }

        public static void DoWork()
        {
            Console.WriteLine("DoWork is running on another thread.");
            try
            {
                Thread.Sleep(5000);
            }

            catch (ThreadAbortException ex)
            {
                Console.WriteLine("DoWork was aborted." + ex.Message);
            }
            finally
            {
                Console.WriteLine("Use finally to close all open resources.");
            }

            Console.WriteLine("DoWork has ended.");
        }
        public static void ResultCallback(int retValue)
        {
            Console.WriteLine("Returned value: {0}", retValue);
        }



    }
    public class Multiply
    {
        // Delegate that defines the signature for the callback method.
        public delegate void ResultDelegate(int value);

        // State information used in the task.
        private string greeting;
        private int value;

        // Delegate used to execute the callback method when the task is complete.
        private ResultDelegate callback;

        // The constructor obtains the state information and the callback delegate.
        public Multiply(string _greeting, int _value, ResultDelegate _callback)
        {
            greeting = _greeting;
            value = _value;
            callback = _callback;
        }
        // The thread procedure performs the tasks (displaying
        // the greeting and multiplying the value by 2).
        public void ThreadProc()
        {
            Console.WriteLine(greeting);
            if (callback != null)
                callback(value * 2);
        }
    }
}
