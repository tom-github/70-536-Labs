Public Class Math
    Private _value As Integer = 0

    Public Property Value() As Integer
        Get
            Return _value
        End Get
        Set(ByVal value As Integer)
            _value = value
        End Set
    End Property

    Public Sub Add(ByVal n As Integer)
        _value += n
    End Sub

    Public Sub Subtract(ByVal n As Integer)
        _value -= n
    End Sub
End Class

