Imports System.Timers
Imports System.IO
Imports System.Net

Public Class MonitorWebSite

    Private t As Timer = Nothing

    Protected Overrides Sub OnStart(ByVal args() As String)
        t.Start()
    End Sub

    Protected Overrides Sub OnStop()
        t.Stop()
    End Sub

    Protected Overrides Sub OnContinue()
        t.Start()
    End Sub

    Protected Overrides Sub OnPause()
        t.Stop()
    End Sub

    Protected Overrides Sub OnShutdown()
        t.Stop()
    End Sub

    Protected Sub t_Elapsed(ByVal sender As System.Object, ByVal e As System.Timers.ElapsedEventArgs)
        Try
            ' Send the HTTP request
            Dim url As String = "http://www.microsoft.com"
            Dim g As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            Dim r As HttpWebResponse = CType(g.GetResponse, HttpWebResponse)

            ' Log the response to a text file
            Dim path As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "log.txt"
            Dim tw As TextWriter = New StreamWriter(path, True)
            tw.WriteLine(DateTime.Now.ToString + " for " + url + ": " + r.StatusCode.ToString)
            tw.Close()

            ' Close the HTTP response
            r.Close()
        Catch ex As Exception
            System.Diagnostics.EventLog.WriteEntry("Application", "Exception: " + ex.Message.ToString)
        End Try
    End Sub
End Class
