Imports System.IO

' TODO: Add CAS declarations
Module Module1

    Sub Main()
        ' Create a file
        Dim tw As TextWriter = New StreamWriter("C:\Hello.txt")
        tw.WriteLine("Hello, world!")
        tw.Close()

        ' Display the text of the file
        Dim tr As TextReader = New StreamReader("C:\Hello.txt")
        Console.WriteLine(tr.ReadToEnd())
        tr.Close()
    End Sub

End Module
