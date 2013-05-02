Imports System.Collections.Specialized
Imports System.Configuration

Class Window1

    Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles button1.Click
        Dim config As Configuration = _
    ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
        config.AppSettings.Settings.Remove("Title")
        config.AppSettings.Settings.Add("Title", titleTextBox.Text)

        config.AppSettings.Settings.Remove("Number")
        config.AppSettings.Settings.Add("Number", numberSlider.Value.ToString())
        config.Save(ConfigurationSaveMode.Modified)
    End Sub

    Private Sub Window_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        If ConfigurationManager.AppSettings("Title") IsNot Nothing Then
            Me.Title = ConfigurationManager.AppSettings("Title")
            titleTextBox.Text = ConfigurationManager.AppSettings("Title")
        End If

        If ConfigurationManager.AppSettings("Number") IsNot Nothing Then
            numberSlider.Value = Double.Parse(ConfigurationManager.AppSettings("Number"))
        End If
    End Sub
End Class
