Imports System.IO
Module Module1

    Sub Main()
        ' Display the volumes attached to the computer
        Console.WriteLine("Drives:")
        For Each di As DriveInfo In DriveInfo.GetDrives()
            Console.WriteLine("  {0} ({1})", di.Name, di.DriveType)
        Next

        ' Prompt the user to enter a drive letter
        Console.WriteLine()
        Console.WriteLine("Press a drive letter to view files and folders")
        Dim drive As ConsoleKeyInfo = Console.ReadKey(True)

        ' Create a DirectoryInfo object from the drive letter
        Dim dir As New DirectoryInfo(drive.Key.ToString() + ":\")

        ' Display the folders in the root of the selected drive
        Console.WriteLine()
        Console.WriteLine("Folders:")
        For Each dirInfo As DirectoryInfo In dir.GetDirectories()
            Console.WriteLine("  " + dirInfo.Name)
        Next

        ' Display the files in the root of the selected drive
        Console.WriteLine()
        Console.WriteLine("Files:")
        For Each fi As FileInfo In dir.GetFiles()
            Console.WriteLine("  " + fi.Name)
        Next
    End Sub

End Module
