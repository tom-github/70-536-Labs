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

    Public Shared Sub WriteToFileWrapper(ByVal fileName As String, _
        ByVal contents As String)
        ' Assert permission to allow caller to bypass security check
        Dim newFilePermission As FileIOPermission = _
            New FileIOPermission(FileIOPermissionAccess.Write, fileName)
        newFilePermission.Assert()
        Try
            WriteToFile(fileName, contents)
        Finally
            ' Clean up the assertion
            CodeAccessPermission.RevertAssert()
        End Try
    End Sub


End Class
