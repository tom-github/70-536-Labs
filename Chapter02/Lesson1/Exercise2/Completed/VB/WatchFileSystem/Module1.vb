Imports System.IO

Module Module1

    Sub Main()
        ' Create an instance of FileSystemWatcher
        Dim fsw As New FileSystemWatcher(Environment.GetEnvironmentVariable("USERPROFILE"))

        ' Set the FileSystemWatcher properties
        fsw.IncludeSubdirectories = True
        fsw.NotifyFilter = NotifyFilters.FileName Or NotifyFilters.LastWrite

        ' Add the Changed event handler
        AddHandler fsw.Changed, AddressOf fsw_Changed
        AddHandler fsw.Created, AddressOf fsw_Changed
        AddHandler fsw.Deleted, AddressOf fsw_Changed
        AddHandler fsw.Renamed, AddressOf fsw_Renamed

        ' Start monitoring events
        fsw.EnableRaisingEvents = True

        ' Wait for user input before ending
        Console.WriteLine("Press a key to end the program.")
        Console.ReadKey()
    End Sub

    Sub fsw_Changed(ByVal sender As Object, ByVal e As FileSystemEventArgs)
        ' Write the path of a changed file to the console
        Console.WriteLine(e.ChangeType.ToString + ": " + e.FullPath)
    End Sub

    Sub fsw_Renamed(ByVal sender As Object, ByVal e As RenamedEventArgs)
        ' Write the path of a changed file to the console
        Console.WriteLine(e.ChangeType.ToString + " from " + e.OldFullPath + " to " + e.Name)
    End Sub

End Module
