Imports System.IO

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

        ' Write the contents of the MemoryStream to a file
        Dim fs As FileStream = File.Create("output.txt")
        ms.WriteTo(fs)

        ' Close the file and MemoryStream
        sw.Close()
        ms.Close()
        fs.Close()

        ' Display the file to the console
        Dim tr As TextReader = File.OpenText("output.txt")
        Console.Write(tr.ReadToEnd())
        tr.Close()
    End Sub

End Module
