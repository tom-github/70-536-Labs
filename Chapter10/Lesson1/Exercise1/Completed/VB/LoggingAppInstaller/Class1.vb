Imports System.Diagnostics
Imports System.Configuration.Install
Imports System.ComponentModel
Imports System.Collections

<RunInstaller(True)> _
Public Class InstallLog
    Inherits Installer
    Public Sub New()
        MyBase.New()
    End Sub

    Public Overloads Overrides Sub Commit(ByVal mySavedState As IDictionary)
        MyBase.Commit(mySavedState)
    End Sub

    Public Overloads Overrides Sub Install(ByVal stateSaver As IDictionary)
        MyBase.Install(stateSaver)
        If Not EventLog.Exists("LoggingApp Log") Then
            EventLog.CreateEventSource("LoggingApp", "LoggingApp Log")
        End If
    End Sub

    Public Overloads Overrides Sub Uninstall(ByVal savedState As IDictionary)
        MyBase.Uninstall(savedState)
        RemoveLog()
    End Sub

    Public Overloads Overrides Sub Rollback(ByVal savedState As IDictionary)
        MyBase.Rollback(savedState)
        RemoveLog()
    End Sub

    Public Sub RemoveLog()
        If EventLog.Exists("LoggingApp Log") Then
            EventLog.DeleteEventSource("LoggingApp")
            EventLog.Delete("LoggingApp Log")
        End If
    End Sub
End Class
