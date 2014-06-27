Module Module1

    Sub Main()
        Try
            TrustedClass.Distrust.WriteToFile("C:\Inetpub\test-deleteme.txt", "This assembly lacks permissions to write to the file.")
            Console.WriteLine("Wrote to the file.")
        Catch ex As Exception
            Console.WriteLine("Couldn't write to the file.")
            Console.WriteLine(ex.GetType().ToString() + ": " + ex.Message)
        End Try
    End Sub

End Module
