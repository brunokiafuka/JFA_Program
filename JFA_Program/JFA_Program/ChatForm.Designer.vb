<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChatForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtQuestion = New System.Windows.Forms.RichTextBox()
        Me.chatList = New System.Windows.Forms.ListBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.Button1.Location = New System.Drawing.Point(336, 371)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(117, 47)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "send"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtQuestion
        '
        Me.txtQuestion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.txtQuestion.Location = New System.Drawing.Point(15, 367)
        Me.txtQuestion.Name = "txtQuestion"
        Me.txtQuestion.Size = New System.Drawing.Size(314, 55)
        Me.txtQuestion.TabIndex = 1
        Me.txtQuestion.Text = ""
        '
        'chatList
        '
        Me.chatList.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.chatList.FormattingEnabled = True
        Me.chatList.ItemHeight = 18
        Me.chatList.Location = New System.Drawing.Point(12, 59)
        Me.chatList.Name = "chatList"
        Me.chatList.Size = New System.Drawing.Size(438, 292)
        Me.chatList.TabIndex = 2
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.TextBox1.Location = New System.Drawing.Point(98, 18)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(228, 23)
        Me.TextBox1.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "User Name:"
        '
        'ChatForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(480, 434)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.chatList)
        Me.Controls.Add(Me.txtQuestion)
        Me.Controls.Add(Me.Button1)
        Me.Name = "ChatForm"
        Me.Text = "CNSBoot Help"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents txtQuestion As RichTextBox
    Friend WithEvents chatList As ListBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
End Class
