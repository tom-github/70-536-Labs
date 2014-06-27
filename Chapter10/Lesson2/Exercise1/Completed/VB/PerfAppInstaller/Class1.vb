Imports System.Configuration.Install
Imports System.ComponentModel

<RunInstaller(True)> _
        Public Class InstallCounter
    Inherits Installer
    Public Sub New()
        MyBase.New()
    End Sub

    Public Overloads Overrides Sub Commit(ByVal mySavedState As IDictionary)
        MyBase.Commit(mySavedState)
    End Sub

    Public Overloads Overrides Sub Install(ByVal stateSaver As IDictionary)
        MyBase.Install(stateSaver)
        If Not PerformanceCounterCategory.Exists("PerfApp") Then
            PerformanceCounterCategory.Create("PerfApp", "Counters for PerfApp", PerformanceCounterCategoryType.SingleInstance, "Clicks", "Times the user has clicked the button.")
        End If
    End Sub

    Public Overloads Overrides Sub Uninstall(ByVal savedState As IDictionary)
        MyBase.Uninstall(savedState)
        If PerformanceCounterCategory.Exists("PerfApp") Then
            PerformanceCounterCategory.Delete("PerfApp")
        End If
    End Sub

    Public Overloads Overrides Sub Rollback(ByVal savedState As IDictionary)
        MyBase.Rollback(savedState)
        If PerformanceCounterCategory.Exists("PerfApp") Then
            PerformanceCounterCategory.Delete("PerfApp")
        End If
    End Sub
End Class
