Imports SpeechLib

Class Window1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button1.Click
        Dim voice As New SpVoice()
        voice.Speak(TextBox1.Text, SpeechVoiceSpeakFlags.SVSFDefault)
    End Sub
End Class
