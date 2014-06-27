Imports System.IO
Imports System.Security.Permissions

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents declarativeDemandButton As System.Windows.Forms.Button
    Friend WithEvents statusLabel As System.Windows.Forms.Label
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents noDemandButton As System.Windows.Forms.Button
    Friend WithEvents imperativeDemandButton As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.declarativeDemandButton = New System.Windows.Forms.Button
        Me.statusLabel = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.noDemandButton = New System.Windows.Forms.Button
        Me.imperativeDemandButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'declarativeDemandButton
        '
        Me.declarativeDemandButton.Location = New System.Drawing.Point(8, 168)
        Me.declarativeDemandButton.Name = "declarativeDemandButton"
        Me.declarativeDemandButton.Size = New System.Drawing.Size(272, 23)
        Me.declarativeDemandButton.TabIndex = 7
        Me.declarativeDemandButton.Text = "Create file with declarative demand"
        '
        'statusLabel
        '
        Me.statusLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.statusLabel.Location = New System.Drawing.Point(8, 40)
        Me.statusLabel.Name = "statusLabel"
        Me.statusLabel.Size = New System.Drawing.Size(272, 80)
        Me.statusLabel.TabIndex = 4
        Me.statusLabel.Text = "No action taken"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(16, 8)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(264, 23)
        Me.label1.TabIndex = 3
        Me.label1.Text = "Status:"
        Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'noDemandButton
        '
        Me.noDemandButton.Location = New System.Drawing.Point(8, 136)
        Me.noDemandButton.Name = "noDemandButton"
        Me.noDemandButton.Size = New System.Drawing.Size(272, 23)
        Me.noDemandButton.TabIndex = 6
        Me.noDemandButton.Text = "Create file with no demand"
        '
        'imperativeDemandButton
        '
        Me.imperativeDemandButton.Location = New System.Drawing.Point(8, 200)
        Me.imperativeDemandButton.Name = "imperativeDemandButton"
        Me.imperativeDemandButton.Size = New System.Drawing.Size(272, 23)
        Me.imperativeDemandButton.TabIndex = 5
        Me.imperativeDemandButton.Text = "Create file with imperative demand"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 229)
        Me.Controls.Add(Me.declarativeDemandButton)
        Me.Controls.Add(Me.statusLabel)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.noDemandButton)
        Me.Controls.Add(Me.imperativeDemandButton)
        Me.Name = "Form1"
        Me.Text = "Code Access Security Demands"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub noDemandButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles noDemandButton.Click
        createFile(RandomFileName)
    End Sub

    Private Sub declarativeDemandButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles declarativeDemandButton.Click
        Try
            declarativeCreateFile()
        Catch ex As Exception
            statusLabel.Text = "Failed before attempting to create file. "
            statusLabel.Text += ex.GetType.ToString + ": " + ex.Message
        End Try
    End Sub

    Private Sub imperativeDemandButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imperativeDemandButton.Click
        Dim fileName As String = RandomFileName()
        Dim writeFilePermission As FileIOPermission = New FileIOPermission(FileIOPermissionAccess.Write, fileName)
        Try
            writeFilePermission.Demand()
            createFile(fileName)
        Catch ex As Exception
            statusLabel.Text = "Failed before attempting to create file. "
            statusLabel.Text += ex.GetType.ToString + ": " + ex.Message
        End Try
    End Sub

    Private Function RandomFileName() As String
        Dim myRandom As Random = New Random
        Return "C:\Documents and Settings\Administrator\" + myRandom.Next.ToString
    End Function

    Private Sub createFile(ByVal fileName As String)
        Try
            Dim sw As StreamWriter = File.CreateText(fileName)
            sw.Close()
            statusLabel.Text = "Successfully created file: " + fileName
            File.Delete(fileName)
        Catch ex As Exception
            statusLabel.Text = "Failed when attempting to create file. "
            statusLabel.Text += ex.GetType.ToString + ": " + ex.Message
        End Try
    End Sub

    ' Note that you cannot use a random filename in declarative permissions
    ' because the filename must be statically defined.
    <FileIOPermission(SecurityAction.Demand, Write:="C:\Documents and Settings\Administrator\12345")> _
    Private Sub declarativeCreateFile()
        createFile("C:\Documents and Settings\Administrator\12345")
    End Sub
End Class
