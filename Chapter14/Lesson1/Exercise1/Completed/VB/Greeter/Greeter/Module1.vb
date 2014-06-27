Imports System.Reflection
Imports System.IO

Module Module1

    Sub Main()

        For Each f As String In Directory.GetFiles(System.Environment.CurrentDirectory, "addon-*.dll")
            Dim asm As Assembly = Assembly.LoadFile(f)

            Dim descs As Object() = asm.GetCustomAttributes(GetType(AssemblyDescriptionAttribute), False)
            Dim desc As AssemblyDescriptionAttribute = DirectCast(descs(0), AssemblyDescriptionAttribute)
            Console.WriteLine(desc.Description)

            For Each t As Type In asm.GetTypes()
                If t.Name.EndsWith("Greeting") Then
                    Dim greet As MethodInfo = t.GetMethod("Greet")
                    greet.Invoke(Nothing, Nothing)
                    Exit For
                End If
            Next
        Next

    End Sub

End Module
