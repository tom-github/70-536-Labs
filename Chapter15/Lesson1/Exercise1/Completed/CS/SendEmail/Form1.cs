using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net.Mail;

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
                
                // TODO: Send e-mail
            }
            catch (ArgumentException)
            {
                MessageBox.Show("You must type from and to e-mail addresses", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("You must provide valid from and to e-mail addresses", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}