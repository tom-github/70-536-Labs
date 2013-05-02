Imports System.Net

Imports System.Threading

Module Module1

    Sub Main()
        Dim urls As String() = {"http://www.microsoft.com", _
                                "http://www.contoso.com", _
                                "http://www.msn.com", _
                                "http://msdn.microsoft.com", _
                                "http://mspress.microsoft.com"}

        ' Record the time before we start
        Dim beginTime As DateTime = DateTime.Now

        ' Retrieve each page
        For Each url As String In urls
            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf GetPage), url)
        Next

        ' Display the elapsed time
        Console.WriteLine("Time elapsed: " + (DateTime.Now - beginTime).ToString())
        Console.WriteLine("Press a key to continue")
        Console.ReadKey()
    End Sub

    Sub GetPage(ByVal data As Object)
        ' Cast the object to a string
        Dim url As String = DirectCast(data, String)

        ' Request the URL
        Dim wr As WebResponse = WebRequest.Create(url).GetResponse()

        ' Display the value for the Content-Length header
        Console.WriteLine(url + ": " + wr.Headers("Content-Length"))

        wr.Close()
    End Sub
End Module
