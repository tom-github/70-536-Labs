Imports System.Security
Imports System.Security.Policy

Module Module1

    Sub Main()
        ' Create an Evidence object for the Internet zone
        Dim safeZone As Zone = New Zone(SecurityZone.Internet)
        Dim hostEvidence As Object() = {New Zone(SecurityZone.Internet)}
        Dim e As Evidence = New Evidence(hostEvidence, Nothing)

        ' Create an AppDomain
        Dim d As AppDomain = AppDomain.CreateDomain("NewDomain", e)
        d.ExecuteAssemblyByName("ShowWinIni")
    End Sub

End Module
