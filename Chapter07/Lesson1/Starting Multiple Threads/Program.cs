using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Starting_Multiple_Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Using the ThreadPool Class

            ThreadPool.QueueUserWorkItem(ThreadProc1);
            Console.WriteLine("Main thread does some work, then sleeps.");
            Thread.Sleep(1000);
            Console.WriteLine("Main thread exits.");


            string state = "Hello, world!";
            ThreadPool.QueueUserWorkItem(ThreadProc, state);
            Console.WriteLine("Main thread does some work, then sleeps.");
            Thread.Sleep(1000);
            Console.WriteLine("Main thread exits.");


            //By default, the thread pool has 250 worker threads per available processor
            ThreadPool.QueueUserWorkItem(ThreadProc, "Thread 1");
            ThreadPool.QueueUserWorkItem(ThreadProc, "Thread 2");
            ThreadPool.QueueUserWorkItem(ThreadProc, "Thread 3");
            ThreadPool.QueueUserWorkItem(ThreadProc, "Thread 4");


            int workerThreads;
            int completionPortThreads;
            ThreadPool.GetAvailableThreads(out workerThreads, out completionPortThreads);
            Console.WriteLine("Available threads: " + workerThreads.ToString());

            #endregion

            #region Understanding Foreground and Background Threads

            ThreadPool.QueueUserWorkItem(ThreadProc2, "Thread 1");
            ThreadPool.QueueUserWorkItem(ThreadProc2, "Thread 2");
            ThreadProc2("Thread 3"); // Called as part of the foreground thread
            ThreadPool.QueueUserWorkItem(ThreadProc2, "Thread 4");
            Console.WriteLine("Main thread does some work, then sleeps.");
            Thread.Sleep(1000);
            Console.WriteLine("Main thread exits.");
            Console.ReadKey();

            #endregion
        }
        static void ThreadProc1(Object stateInfo)
        {
            Console.WriteLine("Hello from the thread pool.");
        }

        // You must manually cast from the Object class in C#
        static void ThreadProc(Object stateInfo)
        {
            string state = (string)stateInfo;
            Console.WriteLine("Hello from the thread pool: " + state);
        }
        static void ThreadProc2(Object stateInfo)
        {
            string state = (string)stateInfo;
            if (Thread.CurrentThread.IsBackground)
                Console.WriteLine("Hello from backgroud thread: " + state);
            else
                Console.WriteLine("Hello from foreground thread: " + state);
        }
    }
}
