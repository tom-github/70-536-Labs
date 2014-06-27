Imports System.Security.Principal
Imports System.Security.Permissions

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        'Add any initialization after the InitializeComponent() call
        ' Create a WindowsIdentity object representing the current user
        Dim currentIdentity As WindowsIdentity = WindowsIdentity.GetCurrent()

        ' Create a WindowsPrincipal object representing the current user
        Dim currentPrincipal As WindowsPrincipal = New WindowsPrincipal(currentIdentity)

        ' Set the security policy context to Windows security
        System.AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal)

        ' Hide the subtract and multiply buttons if the user is not an Administrator
        If Not currentPrincipal.IsInRole(WindowsBuiltInRole.Administrator) Then
            subtractButton.Visible = False
            multiplyButton.Visible = False
        End If

        ' Hide the Add button if the user is not in the Users group
        If Not currentPrincipal.IsInRole(WindowsBuiltInRole.User) Then
            addButton.Visible = False
        End If

        ' Hide the Divide button if the user is not named CPhilp
        If Not (currentIdentity.Name.ToLower() = _
            System.Environment.MachineName.ToLower() + "\cphilp") Then
            divideButton.Visible = False
        End If
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
    Private WithEvents answerLabel As System.Windows.Forms.Label
    Private WithEvents integer1 As System.Windows.Forms.TextBox
    Private WithEvents addButton As System.Windows.Forms.Button
    Private WithEvents integer2 As System.Windows.Forms.TextBox
    Private WithEvents multiplyButton As System.Windows.Forms.Button
    Private WithEvents subtractButton As System.Windows.Forms.Button
    Private WithEvents divideButton As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.answerLabel = New System.Windows.Forms.Label
        Me.integer1 = New System.Windows.Forms.TextBox
        Me.addButton = New System.Windows.Forms.Button
        Me.integer2 = New System.Windows.Forms.TextBox
        Me.multiplyButton = New System.Windows.Forms.Button
        Me.subtractButton = New System.Windows.Forms.Button
        Me.divideButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'answerLabel
        '
        Me.answerLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.answerLabel.Location = New System.Drawing.Point(26, 112)
        Me.answerLabel.Name = "answerLabel"
        Me.answerLabel.Size = New System.Drawing.Size(248, 24)
        Me.answerLabel.TabIndex = 9
        Me.answerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'integer1
        '
        Me.integer1.Location = New System.Drawing.Point(18, 8)
        Me.integer1.Name = "integer1"
        Me.integer1.Size = New System.Drawing.Size(112, 20)
        Me.integer1.TabIndex = 7
        Me.integer1.Text = "2"
        Me.integer1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'addButton
        '
        Me.addButton.Location = New System.Drawing.Point(34, 40)
        Me.addButton.Name = "addButton"
        Me.addButton.TabIndex = 3
        Me.addButton.Text = "Add"
        '
        'integer2
        '
        Me.integer2.Location = New System.Drawing.Point(146, 8)
        Me.integer2.Name = "integer2"
        Me.integer2.Size = New System.Drawing.Size(128, 20)
        Me.integer2.TabIndex = 8
        Me.integer2.Text = "3"
        Me.integer2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'multiplyButton
        '
        Me.multiplyButton.Location = New System.Drawing.Point(170, 40)
        Me.multiplyButton.Name = "multiplyButton"
        Me.multiplyButton.TabIndex = 4
        Me.multiplyButton.Text = "Multiply"
        '
        'subtractButton
        '
        Me.subtractButton.Location = New System.Drawing.Point(34, 72)
        Me.subtractButton.Name = "subtractButton"
        Me.subtractButton.TabIndex = 6
        Me.subtractButton.Text = "Subtract"
        '
        'divideButton
        '
        Me.divideButton.Location = New System.Drawing.Point(170, 72)
        Me.divideButton.Name = "divideButton"
        Me.divideButton.TabIndex = 5
        Me.divideButton.Text = "Divide"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 149)
        Me.Controls.Add(Me.answerLabel)
        Me.Controls.Add(Me.integer1)
        Me.Controls.Add(Me.addButton)
        Me.Controls.Add(Me.integer2)
        Me.Controls.Add(Me.multiplyButton)
        Me.Controls.Add(Me.subtractButton)
        Me.Controls.Add(Me.divideButton)
        Me.Name = "Form1"
        Me.Text = "Super-secret math form"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub multiplyButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles multiplyButton.Click
        answerLabel.Text = multiply(Integer.Parse(integer1.Text), Integer.Parse(integer2.Text)).ToString
    End Sub

    <PrincipalPermission(SecurityAction.Demand, Role:="BUILTIN\Administrators")> _
    Private Function multiply(ByVal int1 As Integer, ByVal int2 As Integer) As Integer
        Return int1 * int2
    End Function

    Private Sub addButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addButton.Click
        Try
            ' Demand that user is member of the built-in Users group
            ' Because this method is called by a Windows event, protect it 
            ' with a imperative RBS demand
            Dim userPermission As PrincipalPermission = _
                New PrincipalPermission(Nothing, "BUILTIN\Users")
            userPermission.Demand()

            ' Perform calculations
            Dim answer As Integer = (Integer.Parse(integer1.Text) + Integer.Parse(integer2.Text))
            answerLabel.Text = answer.ToString()
        Catch ex As System.Security.SecurityException
            ' Display message box explaining access denial
            MessageBox.Show("You have been denied access: " + ex.Message)
            ' TODO: Log error
        End Try
    End Sub

    Private Sub subtractButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles subtractButton.Click
        Dim answer As Integer = (Integer.Parse(integer1.Text) - Integer.Parse(integer2.Text))
        answerLabel.Text = answer.ToString
    End Sub

    Private Sub divideButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles divideButton.Click
        ' Concatenate the computer and username
        Dim allowUser As String = System.Environment.MachineName + "\cphilp"
        Try
            ' Demand that user has the username "cphilp" on the local 
            ' computer. Because this method is called by a Windows event, 
            ' protect it with a imperative RBS demand
            Dim p As PrincipalPermission = New PrincipalPermission(allowUser, Nothing)
            p.Demand()

            ' Perform super-secret mathematical calculations
            Dim answer As Decimal = (Decimal.Parse(integer1.Text) / Decimal.Parse(integer2.Text))
            answerLabel.Text = Decimal.Round(answer, 2).ToString()
        Catch ex As System.Security.SecurityException
            ' Display message box explaining access denial
            MessageBox.Show("You have been denied access: " + ex.Message)
            ' TODO: Log error
        End Try
    End Sub
End Class
