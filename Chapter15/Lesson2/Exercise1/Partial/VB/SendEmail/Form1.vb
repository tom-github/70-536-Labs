Imports System.Net.Mail

Public Class Form1

    Private Sub sendButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendButton.Click
        Try
            ' Create a MailMessage object
            Dim mm As MailMessage = New MailMessage

            ' Define the sender and recipient
            mm.From = New MailAddress(fromEmailAddress.Text, fromDisplayName.Text)
            mm.To.Add(New MailAddress(toEmailAddress.Text, toDisplayName.Text))

            ' Define the subject and body
            mm.Subject = subjectTextBox.Text
            mm.Body = bodyTextBox.Text
            mm.IsBodyHtml = htmlRadioButton.Checked

            ' TODO: Send e-mail
        Catch ex As ArgumentException
            MessageBox.Show("You must type from and to e-mail addresses", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As FormatException
            MessageBox.Show("You must provide valid from and to e-mail addresses", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
