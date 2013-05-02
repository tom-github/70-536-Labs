Imports System.Text.RegularExpressions

Module Module1

    Sub Main()
        Dim input As String() = {"(555)555-1212", "(555) 555-1212", "555-555-1212", "5555551212", "01111", "01111-1111", "47", "111-11-1111"}
        For Each s As String In input
            If IsPhone(s) Then
                Console.WriteLine(s + " is a phone number")
            Else
                If IsZip(s) Then
                    Console.WriteLine(s + " is a zip code")
                Else
                    Console.WriteLine(s + " is unknown")
                End If
            End If
        Next
    End Sub

    Function IsPhone(ByVal s As String) As Boolean
        ' TODO: Add regular expression matching
        Return False
    End Function

    Function IsZip(ByVal s As String) As Boolean
        ' TODO: Add regular expression matching
        Return False
    End Function
End Module
