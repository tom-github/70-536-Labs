Imports System.Globalization

Class Window1

    Private Sub Window1_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        For Each ci As CultureInfo In CultureInfo.GetCultures(CultureTypes.SpecificCultures)
            cultureComboBox.Items.Add(ci)
        Next
    End Sub

    Private Sub cultureComboBox_SelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs)
        Dim selectedCulture As CultureInfo = DirectCast(e.AddedItems(0), CultureInfo)
        codeLabel.Content = selectedCulture.IetfLanguageTag
        nativeLabel.Content = selectedCulture.NativeName

        Dim d As Double = 1234567.89
        currencyLabel.Content = d.ToString("C", selectedCulture)
        dateLabel.Content = DateTime.Now.ToString(selectedCulture)
    End Sub
End Class
