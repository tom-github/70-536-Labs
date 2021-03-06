﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;

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

            // Record the time before we start
            DateTime beginTime = DateTime.Now;

            // Retrieve each page
            foreach (string url in urls)
                GetPage(url);

            // Display the elapsed time
            Console.WriteLine("Time elapsed: " + (DateTime.Now - beginTime).ToString());
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }

        static void GetPage(string url)
        {
            // Request the URL
            WebResponse wr = WebRequest.Create(url).GetResponse();

            // Display the value for the Content-Length header
            Console.WriteLine(url + ": " + wr.Headers["Content-Length"]);

            wr.Close(); 
        }

    }
}
