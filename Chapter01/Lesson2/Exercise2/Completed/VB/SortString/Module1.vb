Module Module1

    Sub Main()
        Dim s As String = "Microsoft .NET Framework Application Development Foundation"
        Dim sa As String() = s.Split(" ")
        Array.Sort(sa)
        s = String.Join(" ", sa)
        Console.WriteLine(s)
    End Sub

End Module
