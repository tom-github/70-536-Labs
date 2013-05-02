Imports System.Diagnostics

Class Window1

    Private Sub Window_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Dim myLog As New EventLog("LoggingApp Log")
        myLog.Source = "LoggingApp"
        myLog.WriteEntry("LoggingApp started!", EventLogEntryType.Information, 1001)
    End Sub
End Class
