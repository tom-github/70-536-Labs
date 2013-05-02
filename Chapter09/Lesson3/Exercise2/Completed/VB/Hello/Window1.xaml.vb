Imports System.Collections
Imports System.IO
Imports System.Configuration.Install
Imports System.ComponentModel

Class Window1

End Class

<RunInstaller(True)> _
Public Class HelloInstaller
    Inherits Installer
    Public Sub New()
        MyBase.New()
    End Sub

    Public Overloads Overrides Sub Commit(ByVal mySavedState As IDictionary)
        MyBase.Commit(mySavedState)
        System.IO.File.CreateText("Commit.txt")
    End Sub

    Public Overloads Overrides Sub Install(ByVal stateSaver As IDictionary)
        MyBase.Install(stateSaver)
        System.IO.File.CreateText("Install.txt")
    End Sub

    Public Overloads Overrides Sub Uninstall(ByVal savedState As IDictionary)
        MyBase.Uninstall(savedState)
        File.Delete("Commit.txt")
        File.Delete("Install.txt")
    End Sub

    Public Overloads Overrides Sub Rollback(ByVal savedState As IDictionary)
        MyBase.Rollback(savedState)
        File.Delete("Install.txt")
    End Sub
End Class
