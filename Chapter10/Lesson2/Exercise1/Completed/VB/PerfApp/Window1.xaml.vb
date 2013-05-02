Class Window1 

    Private Sub counterButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles counterButton.Click
        Dim pc As New PerformanceCounter("PerfApp", "Clicks", False)
        pc.Increment()
        counterLabel.Content = pc.NextValue().ToString()
    End Sub
End Class
