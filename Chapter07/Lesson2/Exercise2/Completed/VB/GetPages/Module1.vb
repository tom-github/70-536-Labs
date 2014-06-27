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
            Dim ps As New PageSize(url, waitHandles(i), New ResultDelegate(AddressOf ResultCallback))
            Dim t As New Thread(New ThreadStart(AddressOf ps.GetPageSize))
            t.Start()
            i += 1
        Next

        WaitHandle.WaitAll(waitHandles)

        ' Display the elapsed time
        Console.WriteLine("Time elapsed: " + (DateTime.Now - beginTime).ToString())
        Console.WriteLine("Press a key to continue")
        Console.ReadKey()
    End Sub

    ' The callback method must match the signature of the callback delegate.
    Sub ResultCallback(ByVal ps As PageSize)
        Console.WriteLine("{0}: {1}", ps.url, ps.bytes.ToString())
    End Sub

    ' Delegate that defines the signature for the callback method.
    Delegate Sub ResultDelegate(ByVal ps As PageSize)
    Class PageSize
        Public url As String
        Public are As AutoResetEvent
        Public bytes As Integer

        ' Delegate used to execute the callback method when the task is complete.
        Private callback As ResultDelegate

        Public Sub New(ByVal _url As String, ByVal _are As AutoResetEvent, ByVal _callback As ResultDelegate)
            url = _url
            are = _are
            callback = _callback
        End Sub

        Public Sub GetPageSize()
            ' Request the URL
            Dim wr As WebResponse = WebRequest.Create(url).GetResponse()

            bytes = Integer.Parse(wr.Headers("Content-Length"))

            ' Display the value for the Content-Length header
            ' Console.WriteLine(url + ": " + bytes.ToString());

            wr.Close()

            callback(Me)

            ' Let the parent thread know the process is done
            are.[Set]()
        End Sub
    End Class

End Module
