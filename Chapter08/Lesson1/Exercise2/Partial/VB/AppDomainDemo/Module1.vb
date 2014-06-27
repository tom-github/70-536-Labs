Module Module1

    Sub Main()
        Dim d As AppDomain = AppDomain.CreateDomain("NewDomain")
        d.ExecuteAssembly("ShowWinIni.exe")
    End Sub

End Module
