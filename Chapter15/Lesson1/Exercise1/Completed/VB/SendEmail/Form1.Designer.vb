<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.sendButton = New System.Windows.Forms.Button
        Me.htmlRadioButton = New System.Windows.Forms.RadioButton
        Me.textRadioButton = New System.Windows.Forms.RadioButton
        Me.bodyTextBox = New System.Windows.Forms.TextBox
        Me.subjectTextBox = New System.Windows.Forms.TextBox
        Me.label8 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.toEmailAddress = New System.Windows.Forms.TextBox
        Me.fromDisplayName = New System.Windows.Forms.TextBox
        Me.sslCheckBox = New System.Windows.Forms.CheckBox
        Me.fromEmailAddress = New System.Windows.Forms.TextBox
        Me.label10 = New System.Windows.Forms.Label
        Me.label11 = New System.Windows.Forms.Label
        Me.toDisplayName = New System.Windows.Forms.TextBox
        Me.passwordTextBox = New System.Windows.Forms.TextBox
        Me.usernameTextBox = New System.Windows.Forms.TextBox
        Me.label9 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.serverTextBox = New System.Windows.Forms.TextBox
        Me.label7 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'sendButton
        '
        Me.sendButton.Location = New System.Drawing.Point(383, 257)
        Me.sendButton.Name = "sendButton"
        Me.sendButton.Size = New System.Drawing.Size(367, 23)
        Me.sendButton.TabIndex = 30
        Me.sendButton.Text = "Send"
        Me.sendButton.UseVisualStyleBackColor = True
        '
        'htmlRadioButton
        '
        Me.htmlRadioButton.AutoSize = True
        Me.htmlRadioButton.Location = New System.Drawing.Point(261, 263)
        Me.htmlRadioButton.Name = "htmlRadioButton"
        Me.htmlRadioButton.Size = New System.Drawing.Size(55, 17)
        Me.htmlRadioButton.TabIndex = 29
        Me.htmlRadioButton.TabStop = True
        Me.htmlRadioButton.Text = "HTML"
        Me.htmlRadioButton.UseVisualStyleBackColor = True
        '
        'textRadioButton
        '
        Me.textRadioButton.AutoSize = True
        Me.textRadioButton.Location = New System.Drawing.Point(111, 263)
        Me.textRadioButton.Name = "textRadioButton"
        Me.textRadioButton.Size = New System.Drawing.Size(46, 17)
        Me.textRadioButton.TabIndex = 28
        Me.textRadioButton.TabStop = True
        Me.textRadioButton.Text = "Text"
        Me.textRadioButton.UseVisualStyleBackColor = True
        '
        'bodyTextBox
        '
        Me.bodyTextBox.Location = New System.Drawing.Point(63, 115)
        Me.bodyTextBox.Multiline = True
        Me.bodyTextBox.Name = "bodyTextBox"
        Me.bodyTextBox.Size = New System.Drawing.Size(294, 135)
        Me.bodyTextBox.TabIndex = 27
        '
        'subjectTextBox
        '
        Me.subjectTextBox.Location = New System.Drawing.Point(63, 89)
        Me.subjectTextBox.Name = "subjectTextBox"
        Me.subjectTextBox.Size = New System.Drawing.Size(294, 20)
        Me.subjectTextBox.TabIndex = 26
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(60, 263)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(42, 13)
        Me.label8.TabIndex = 15
        Me.label8.Text = "Format:"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(12, 118)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(34, 13)
        Me.label6.TabIndex = 16
        Me.label6.Text = "Body:"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(12, 92)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(46, 13)
        Me.label5.TabIndex = 14
        Me.label5.Text = "Subject:"
        '
        'toEmailAddress
        '
        Me.toEmailAddress.Location = New System.Drawing.Point(63, 63)
        Me.toEmailAddress.Name = "toEmailAddress"
        Me.toEmailAddress.Size = New System.Drawing.Size(144, 20)
        Me.toEmailAddress.TabIndex = 23
        '
        'fromDisplayName
        '
        Me.fromDisplayName.Location = New System.Drawing.Point(213, 37)
        Me.fromDisplayName.Name = "fromDisplayName"
        Me.fromDisplayName.Size = New System.Drawing.Size(144, 20)
        Me.fromDisplayName.TabIndex = 22
        '
        'sslCheckBox
        '
        Me.sslCheckBox.AutoSize = True
        Me.sslCheckBox.Location = New System.Drawing.Point(59, 102)
        Me.sslCheckBox.Name = "sslCheckBox"
        Me.sslCheckBox.Size = New System.Drawing.Size(82, 17)
        Me.sslCheckBox.TabIndex = 12
        Me.sslCheckBox.Text = "Enable SSL"
        Me.sslCheckBox.UseVisualStyleBackColor = True
        '
        'fromEmailAddress
        '
        Me.fromEmailAddress.Location = New System.Drawing.Point(63, 37)
        Me.fromEmailAddress.Name = "fromEmailAddress"
        Me.fromEmailAddress.Size = New System.Drawing.Size(144, 20)
        Me.fromEmailAddress.TabIndex = 21
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.Location = New System.Drawing.Point(258, 53)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(53, 13)
        Me.label10.TabIndex = 0
        Me.label10.Text = "Password"
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.Location = New System.Drawing.Point(8, 72)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(36, 13)
        Me.label11.TabIndex = 0
        Me.label11.Text = "Login:"
        '
        'toDisplayName
        '
        Me.toDisplayName.Location = New System.Drawing.Point(213, 63)
        Me.toDisplayName.Name = "toDisplayName"
        Me.toDisplayName.Size = New System.Drawing.Size(144, 20)
        Me.toDisplayName.TabIndex = 25
        '
        'passwordTextBox
        '
        Me.passwordTextBox.Location = New System.Drawing.Point(209, 69)
        Me.passwordTextBox.Name = "passwordTextBox"
        Me.passwordTextBox.Size = New System.Drawing.Size(144, 20)
        Me.passwordTextBox.TabIndex = 11
        '
        'usernameTextBox
        '
        Me.usernameTextBox.Location = New System.Drawing.Point(59, 69)
        Me.usernameTextBox.Name = "usernameTextBox"
        Me.usernameTextBox.Size = New System.Drawing.Size(144, 20)
        Me.usernameTextBox.TabIndex = 10
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Location = New System.Drawing.Point(109, 53)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(55, 13)
        Me.label9.TabIndex = 0
        Me.label9.Text = "Username"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(12, 66)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(23, 13)
        Me.label2.TabIndex = 17
        Me.label2.Text = "To:"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(12, 40)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(33, 13)
        Me.label1.TabIndex = 20
        Me.label1.Text = "From:"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.sslCheckBox)
        Me.groupBox1.Controls.Add(Me.passwordTextBox)
        Me.groupBox1.Controls.Add(Me.label9)
        Me.groupBox1.Controls.Add(Me.label10)
        Me.groupBox1.Controls.Add(Me.label11)
        Me.groupBox1.Controls.Add(Me.serverTextBox)
        Me.groupBox1.Controls.Add(Me.usernameTextBox)
        Me.groupBox1.Controls.Add(Me.label7)
        Me.groupBox1.Location = New System.Drawing.Point(383, 66)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(367, 129)
        Me.groupBox1.TabIndex = 24
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Server settings"
        '
        'serverTextBox
        '
        Me.serverTextBox.Location = New System.Drawing.Point(59, 21)
        Me.serverTextBox.Name = "serverTextBox"
        Me.serverTextBox.Size = New System.Drawing.Size(294, 20)
        Me.serverTextBox.TabIndex = 9
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(8, 24)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(41, 13)
        Me.label7.TabIndex = 0
        Me.label7.Text = "Server:"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(95, 21)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(76, 13)
        Me.label3.TabIndex = 19
        Me.label3.Text = "E-mail Address"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(248, 21)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(72, 13)
        Me.label4.TabIndex = 18
        Me.label4.Text = "Display Name"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(763, 300)
        Me.Controls.Add(Me.sendButton)
        Me.Controls.Add(Me.htmlRadioButton)
        Me.Controls.Add(Me.textRadioButton)
        Me.Controls.Add(Me.bodyTextBox)
        Me.Controls.Add(Me.subjectTextBox)
        Me.Controls.Add(Me.label8)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.toEmailAddress)
        Me.Controls.Add(Me.fromDisplayName)
        Me.Controls.Add(Me.fromEmailAddress)
        Me.Controls.Add(Me.toDisplayName)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label4)
        Me.MaximumSize = New System.Drawing.Size(771, 334)
        Me.MinimumSize = New System.Drawing.Size(771, 334)
        Me.Name = "Form1"
        Me.Text = "Send E-mail"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents sendButton As System.Windows.Forms.Button
    Private WithEvents htmlRadioButton As System.Windows.Forms.RadioButton
    Private WithEvents textRadioButton As System.Windows.Forms.RadioButton
    Private WithEvents bodyTextBox As System.Windows.Forms.TextBox
    Private WithEvents subjectTextBox As System.Windows.Forms.TextBox
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents toEmailAddress As System.Windows.Forms.TextBox
    Private WithEvents fromDisplayName As System.Windows.Forms.TextBox
    Private WithEvents sslCheckBox As System.Windows.Forms.CheckBox
    Private WithEvents fromEmailAddress As System.Windows.Forms.TextBox
    Private WithEvents label10 As System.Windows.Forms.Label
    Private WithEvents label11 As System.Windows.Forms.Label
    Private WithEvents toDisplayName As System.Windows.Forms.TextBox
    Private WithEvents passwordTextBox As System.Windows.Forms.TextBox
    Private WithEvents usernameTextBox As System.Windows.Forms.TextBox
    Private WithEvents label9 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents serverTextBox As System.Windows.Forms.TextBox
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label

End Class
