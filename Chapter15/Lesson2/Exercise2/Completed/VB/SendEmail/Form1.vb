Imports System.Net.Mail
Imports System.Net
Imports System.ComponentModel

Public Class Form1
    Dim sc As SmtpClient
    Private Sub sendButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendButton.Click
        Try
            If sendButton.Text = "Send" Then
                ' Create a MailMessage object
                Dim mm As MailMessage = New MailMessage

                ' Define the sender and recipient
                mm.From = New MailAddress(fromEmailAddress.Text, fromDisplayName.Text)
                mm.To.Add(New MailAddress(toEmailAddress.Text, toDisplayName.Text))

                ' Define the subject and body
                mm.Subject = subjectTextBox.Text
                mm.Body = bodyTextBox.Text
                mm.IsBodyHtml = htmlRadioButton.Checked

                ' Configure the mail server
                sc = New SmtpClient(serverTextBox.Text)
                sc.EnableSsl = sslCheckBox.Checked
                If Not String.IsNullOrEmpty(usernameTextBox.Text) Then
                    sc.Credentials = New NetworkCredential(usernameTextBox.Text, passwordTextBox.Text)
                End If

                ' Send the message and notify the user of success
                ' sc.Send(mm)
                AddHandler sc.SendCompleted, AddressOf sc_SendCompleted
                sc.SendAsync(mm, Nothing)
                sendButton.Text = "Cancel"
            Else
                sc.SendAsyncCancel()
            End If
        Catch ex As ArgumentException
            MessageBox.Show("You must type from and to e-mail addresses", _
                "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As FormatException
            MessageBox.Show("You must provide valid from and to e-mail addresses", _
                "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As InvalidOperationException
            MessageBox.Show("Please provide a server name.", "No SMTP server provided", _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As SmtpFailedRecipientException
            MessageBox.Show("The mail server says that there is no mailbox for " + _
                toEmailAddress.Text + ".", "Invalid recipient", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As SmtpException
            ' Invalid hostnames result in a WebException InnerException that provides
            ' a more descriptive error, so get the base exception
            Dim inner As Exception = ex.GetBaseException
            MessageBox.Show("Could not send message: " + inner.Message, _
                "Problem sending message", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub sc_SendCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)
        If e.Cancelled Then
            MessageBox.Show("Message cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If Not (e.Error Is Nothing) Then
                MessageBox.Show("Error: " + e.Error.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Message sent successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        sendButton.Text = "Send"
    End Sub
End Class
