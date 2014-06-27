Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Security
Imports System.Security.Permissions

Module Module1

    Sub Main()
        writePermissionState(New FileIOPermission(PermissionState.Unrestricted))
        writePermissionState(New EnvironmentPermission(EnvironmentPermissionAccess.Read, "USERNAME"))
        writePermissionState(New FileDialogPermission(FileDialogPermissionAccess.Open))
        writePermissionState(New IsolatedStorageFilePermission(PermissionState.Unrestricted))
        writePermissionState(New ReflectionPermission(ReflectionPermissionFlag.MemberAccess))
        writePermissionState(New UIPermission(UIPermissionWindow.SafeTopLevelWindows))
        writePermissionState(New PrintingPermission(PrintingPermissionLevel.SafePrinting))
        Console.WriteLine("Press Enter key to continue")
        Console.Read()
    End Sub

    Private Sub writePermissionState(ByVal p As System.Security.CodeAccessPermission)
        Console.WriteLine(p.GetType().ToString() + ": " + SecurityManager.IsGranted(p).ToString())
    End Sub
End Module
