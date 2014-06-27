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
                PageSize ps = new PageSize(url, waitHandles[i], new ResultDelegate(ResultCallback));
                Thread t = new Thread(new ThreadStart(ps.GetPageSize));
                t.Start();
                i++;
            }

            // Wait for all threads to complete
            WaitHandle.WaitAll(waitHandles);

            // Display the elapsed time
            Console.WriteLine("Time elapsed: " + (DateTime.Now - beginTime).ToString());
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }

        // The callback method must match the signature of the callback delegate.
        static void ResultCallback(PageSize ps)
        {
            Console.WriteLine("{0}: {1}", ps.url, ps.bytes.ToString());
        }

        // Delegate that defines the signature for the callback method.
        public delegate void ResultDelegate(PageSize ps);

        public class PageSize
        {
            public string url;
            public AutoResetEvent are;
            public int bytes;

            // Delegate used to execute the callback method when the task is complete.
            private ResultDelegate callback;

            public PageSize(string _url, AutoResetEvent _are, ResultDelegate _callback)
            {
                url = _url;
                are = _are;
                callback = _callback;
            }

            public void GetPageSize()
            {
                // Request the URL
                WebResponse wr = WebRequest.Create(url).GetResponse();

                bytes = int.Parse(wr.Headers["Content-Length"]);

                // Display the value for the Content-Length header
                // Console.WriteLine(url + ": " + bytes.ToString());

                wr.Close();

                callback(this);

                // Let the parent thread know the process is done
                are.Set();
            }
        }
    }
}
