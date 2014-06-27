Imports System.Collections

Module Module1

    Sub Main()
        Dim shoppingCart As New ArrayList()
        shoppingCart.Add(New ShoppingCartItem("Car", 5000))
        shoppingCart.Add(New ShoppingCartItem("Book", 30))
        shoppingCart.Add(New ShoppingCartItem("Phone", 80))
        shoppingCart.Add(New ShoppingCartItem("Computer", 1000))

        shoppingCart.Sort()
        shoppingCart.Reverse()

        For Each sci As ShoppingCartItem In shoppingCart
            Console.WriteLine(sci.itemName + ": $" + sci.price.ToString())
        Next
    End Sub

    Public Class ShoppingCartItem
        Implements IComparable
        Public itemName As String
        Public price As Double

        Public Sub New(ByVal _itemName As String, ByVal _price As Double)
            Me.itemName = _itemName
            Me.price = _price
        End Sub

        Public Function CompareTo(ByVal obj As Object) _
            As Integer Implements System.IComparable.CompareTo
            Dim otherItem As ShoppingCartItem = _
                DirectCast(obj, ShoppingCartItem)
            Return Me.price.CompareTo(otherItem.price)
        End Function
    End Class

End Module
