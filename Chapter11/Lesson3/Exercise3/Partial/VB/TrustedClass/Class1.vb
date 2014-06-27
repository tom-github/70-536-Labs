Imports System.IO
Imports System.Security
Imports System.Security.Permissions

<Assembly: AllowPartiallyTrustedCallers()> 
Public Class Distrust
    Public Shared Sub WriteToFile(ByVal fileName As String, ByVal contents As String)
        Dim newFile As StreamWriter = New StreamWriter(fileName)
        newFile.WriteLine(contents)
        newFile.Close()
    End Sub
End Class
