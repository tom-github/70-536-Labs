Imports System.Security.AccessControl
Imports System.Security.Policy
Imports System.Security.Principal
Imports System.IO

Module Module1

    Sub Main()
        Dim ds As New DirectorySecurity()
        ds.AddAccessRule(New FileSystemAccessRule("Guest", FileSystemRights.Read, AccessControlType.Allow))
        Dim newFolder As String = System.IO.Path.Combine( _
        Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Guest")
        Directory.CreateDirectory(newFolder, ds)

        Dim newFile As String = System.IO.Path.Combine(newFolder, "Data.dat")
        File.Create(newFile)
    End Sub

End Module
