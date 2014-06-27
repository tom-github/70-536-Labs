using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Threading;

namespace GetPages
{
    class Program
    {
        class ThreadInfo
        {
            public string url;
            public AutoResetEvent are;

            public ThreadInfo(string _url, AutoResetEvent _are)
            {
                url = _url;
                are = _are;
            }
        }

        static void Main(string[] args)
        {
            string[] urls = { "http://www.microsoft.com",
                                "http://www.contoso.com",
                                "http://www.msn.com",
                                "http://msdn.microsoft.com",
                                "http://mspress.microsoft.com" };

            // Define an array with three AutoResetEvent WaitHandles.
            AutoResetEvent[] waitHandles = new AutoResetEvent[urls.Length];
         
            // Record the time before we start
            DateTime beginTime = DateTime.Now;

            // Retrieve each page
            int i = 0;
            foreach (string url in urls)
            {
                waitHandles[i] = new AutoResetEvent(false);
                ThreadInfo ti = new ThreadInfo(url, waitHandles[i]);
                ThreadPool.QueueUserWorkItem(new WaitCallback(GetPage), ti);
                i++;
            }

            // Wait for all threads to complete
            WaitHandle.WaitAll(waitHandles);

            // Display the elapsed time
            Console.WriteLine("Time elapsed: " + (DateTime.Now - beginTime).ToString());
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }

        static void GetPage(object data)
        {
            // Cast the object to a ThreadInfo
            ThreadInfo ti = (ThreadInfo)data;

            // Request the URL
            WebResponse wr = WebRequest.Create(ti.url).GetResponse();

            // Display the value for the Content-Length header
            Console.WriteLine(ti.url + ": " + wr.Headers["Content-Length"]);

            wr.Close();

            // Let the parent thread know the process is done
            ti.are.Set();
        }

    }
}
