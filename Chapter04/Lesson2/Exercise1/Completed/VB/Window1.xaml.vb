Class Window1
    Dim shoppingCart As New List(Of ShoppingCartItem)()

    Sub addButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Try
            shoppingCart.Add(New ShoppingCartItem(nameTextBox.Text, Double.Parse(priceTextBox.Text)))
            shoppingCartList.Items.Refresh()
            nameTextBox.Clear()
            priceTextBox.Clear()
        Catch ex As Exception
            MessageBox.Show("Please enter valid data: " + ex.Message)
        End Try
    End Sub

    Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        shoppingCartList.ItemsSource = shoppingCart
    End Sub

    Private Sub sortNameButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        shoppingCart.Sort(AddressOf ShoppingCartItem.SortByName)
        shoppingCartList.Items.Refresh()
    End Sub

    Private Sub sortPriceButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        shoppingCart.Sort(AddressOf ShoppingCartItem.SortByPrice)
        shoppingCartList.Items.Refresh()
    End Sub
End Class

Public Class ShoppingCartItem
    Public itemName As String
    Public price As Double

    Public Sub New(ByVal _itemName As String, ByVal _price As Double)
        Me.itemName = _itemName
        Me.price = _price
    End Sub

    Public Overrides Function ToString() As String
        Return Me.itemName + ": " + Me.price.ToString("C")
    End Function

    Public Shared Function SortByName(ByVal item1 As ShoppingCartItem, ByVal item2 As ShoppingCartItem) As Integer
        Return item1.itemName.CompareTo(item2.itemName)
    End Function

    Public Shared Function SortByPrice(ByVal item1 As ShoppingCartItem, ByVal item2 As ShoppingCartItem) As Integer
        Return item1.price.CompareTo(item2.price)
    End Function
End Class
