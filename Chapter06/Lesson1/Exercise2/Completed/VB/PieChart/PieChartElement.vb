Public Class PieChartElement
    Public name As String
    Public value As Single

    Public Sub New()
    End Sub

    Public Sub New(ByVal _name As String, ByVal _value As Single)
        name = _name
        value = _value
    End Sub
End Class
