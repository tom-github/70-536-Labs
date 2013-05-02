Imports System.Net

Imports System.Threading

Module Module1

    <MTAThread()> Sub Main()
        Dim urls As String() = {"http://www.microsoft.com", _
                                "http://www.contoso.com", _
                                "http://www.msn.com", _
                                "http://msdn.microsoft.com", _
                                "http://mspress.microsoft.com"}

        Dim waitHandles As AutoResetEvent() = New AutoResetEvent(urls.Length - 1) {}

        ' Record the time before we start
        Dim beginTime As DateTime = DateTime.Now

        ' Retrieve each page
        Dim i As Integer = 0
        For Each url As String In urls
            waitHandles(i) = New AutoResetEvent(False)
            Dim ti As New ThreadInfo(url, waitHandles(i))
            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf GetPage), ti)
            i += 1
        Next

        WaitHandle.WaitAll(waitHandles)

        ' Display the elapsed time
        Console.WriteLine("Time elapsed: " + (DateTime.Now - beginTime).ToString())
        Console.WriteLine("Press a key to continue")
        Console.ReadKey()
    End Sub

    Class ThreadInfo
        Public url As String
        Public are As AutoResetEvent

        Public Sub New(ByVal _url As String, ByVal _are As AutoResetEvent)
            url = _url
            are = _are
        End Sub
    End Class

    Sub GetPage(ByVal data As Object)
        ' Cast the object to a ThreadInfo
        Dim ti As ThreadInfo = DirectCast(data, ThreadInfo)

        ' Request the URL
        Dim wr As WebResponse = WebRequest.Create(ti.url).GetResponse()

        ' Display the value for the Content-Length header
        Console.WriteLine(ti.url + ": " + wr.Headers("Content-Length"))

        wr.Close()

        ' Let the parent thread know the process is done
        ti.are.Set()
    End Sub
End Module
