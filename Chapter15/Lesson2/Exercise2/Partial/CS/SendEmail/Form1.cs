using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;

namespace SendEmail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a MailMessage object
                MailMessage mm = new MailMessage();

                // Define the sender and recipient
                mm.From = new MailAddress(fromEmailAddress.Text, fromDisplayName.Text);
                mm.To.Add(new MailAddress(toEmailAddress.Text, toDisplayName.Text));

                // Define the subject and body
                mm.Subject = subjectTextBox.Text;
                mm.Body = bodyTextBox.Text;
                mm.IsBodyHtml = htmlRadioButton.Checked;

                // Configure the mail server
                SmtpClient sc = new SmtpClient(serverTextBox.Text);
                sc.EnableSsl = sslCheckBox.Checked;
                if (!String.IsNullOrEmpty(usernameTextBox.Text))
                    sc.Credentials = new NetworkCredential(usernameTextBox.Text, passwordTextBox.Text);

                // Send the message and notify the user of success
                sc.Send(mm);
                MessageBox.Show("Message sent successfully.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("You must type from and to e-mail addresses",
                    "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("You must provide valid from and to e-mail addresses",
                    "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Please provide a server name.",
                    "No SMTP server provided", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SmtpFailedRecipientException)
            {
                MessageBox.Show("The mail server says that there is no mailbox for " + toEmailAddress.Text + ".",
                    "Invalid recipient", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SmtpException ex)
            {
                // Invalid hostnames result in a WebException InnerException that provides
                // a more descriptive error, so get the base exception
                Exception inner = ex.GetBaseException();
                MessageBox.Show("Could not send message: " + inner.Message,
                    "Problem sending message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}