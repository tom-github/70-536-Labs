Imports System.IO
Imports System.Text

Module Module1

    Sub Main()
        Dim sr As StreamReader = New StreamReader("C:\windows\win.ini")
        Dim sw As StreamWriter = New StreamWriter("win-utf7.txt", False, Encoding.UTF7)
        sw.WriteLine(sr.ReadToEnd)
        sw.Close()
        sr.Close()
    End Sub

End Module
