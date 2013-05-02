Module Module1

    Sub Main()
        Dim d As AppDomain = AppDomain.CreateDomain("NewDomain")
        d.ExecuteAssemblyByName("ShowWinIni")
    End Sub

End Module
