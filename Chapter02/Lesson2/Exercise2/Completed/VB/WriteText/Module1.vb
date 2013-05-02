Imports System.IO
Imports System.IO.IsolatedStorage

Module Module1

    Sub Main()
        ' Create a MemoryStream object
        Dim ms As New MemoryStream()

        ' Create a StreamWriter object to allow 
        ' writing strings to the MemoryStream
        Dim sw As New StreamWriter(ms)

        Console.WriteLine("Type 'quit' on a blank line to exit.")
        While True
            Dim input As String = Console.ReadLine()
            If input = "quit" Then
                Exit While
            End If
            sw.WriteLine(input)
        End While

        ' Flush the contents of the StreamWriter so it can be written to disk
        sw.Flush()

        ' Get the store isolated by the assembly
        Dim isoStore As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForAssembly()

        ' Create the isolated storage file in the assembly we just grabbed
        Dim isoFile As New IsolatedStorageFileStream("output.txt", FileMode.Create, isoStore)

        ' Write the contents of the MemoryStream to a file
        ms.WriteTo(isoFile)

        ' Close the file and MemoryStream
        sw.Close()
        ms.Close()
        isoFile.Close()

        ' Display the file to the console
        Dim readIsoFile As New IsolatedStorageFileStream("output.txt", FileMode.Open, isoStore)
        Dim tr As TextReader = New StreamReader(readIsoFile)
        Console.Write(tr.ReadToEnd())
        tr.Close()
    End Sub

End Module
