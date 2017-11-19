<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
		Me.txtQuestion = New System.Windows.Forms.RichTextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.btnAsk = New System.Windows.Forms.Button()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.ListBox1 = New System.Windows.Forms.ListBox()
		Me.questList = New System.Windows.Forms.ListBox()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.listJFA = New System.Windows.Forms.ListBox()
		Me.txtNLPComment = New System.Windows.Forms.RichTextBox()
		Me.SuspendLayout()
		'
		'txtQuestion
		'
		Me.txtQuestion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtQuestion.Location = New System.Drawing.Point(13, 97)
		Me.txtQuestion.Name = "txtQuestion"
		Me.txtQuestion.Size = New System.Drawing.Size(273, 184)
		Me.txtQuestion.TabIndex = 0
		Me.txtQuestion.Text = ""
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
		Me.Label1.Location = New System.Drawing.Point(13, 71)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(171, 17)
		Me.Label1.TabIndex = 1
		Me.Label1.Text = "Enter your objective here:"
		'
		'btnAsk
		'
		Me.btnAsk.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnAsk.Location = New System.Drawing.Point(198, 287)
		Me.btnAsk.Name = "btnAsk"
		Me.btnAsk.Size = New System.Drawing.Size(88, 41)
		Me.btnAsk.TabIndex = 2
		Me.btnAsk.Text = "Submit"
		Me.btnAsk.UseVisualStyleBackColor = True
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Font = New System.Drawing.Font("Lucida Sans", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.Location = New System.Drawing.Point(258, 20)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(167, 18)
		Me.Label2.TabIndex = 3
		Me.Label2.Text = "Ad Creation System"
		'
		'ListBox1
		'
		Me.ListBox1.FormattingEnabled = True
		Me.ListBox1.Location = New System.Drawing.Point(304, 97)
		Me.ListBox1.Name = "ListBox1"
		Me.ListBox1.Size = New System.Drawing.Size(134, 147)
		Me.ListBox1.TabIndex = 4
		'
		'questList
		'
		Me.questList.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.questList.FormattingEnabled = True
		Me.questList.ItemHeight = 20
		Me.questList.Location = New System.Drawing.Point(595, 97)
		Me.questList.Name = "questList"
		Me.questList.Size = New System.Drawing.Size(117, 164)
		Me.questList.TabIndex = 6
		Me.questList.Visible = False
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
		Me.Label5.Location = New System.Drawing.Point(301, 74)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(109, 17)
		Me.Label5.TabIndex = 9
		Me.Label5.Text = "NLP Comments:"
		'
		'listJFA
		'
		Me.listJFA.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.listJFA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.listJFA.ForeColor = System.Drawing.Color.Red
		Me.listJFA.FormattingEnabled = True
		Me.listJFA.ItemHeight = 20
		Me.listJFA.Location = New System.Drawing.Point(304, 97)
		Me.listJFA.Name = "listJFA"
		Me.listJFA.Size = New System.Drawing.Size(408, 184)
		Me.listJFA.TabIndex = 5
		Me.listJFA.Visible = False
		'
		'txtNLPComment
		'
		Me.txtNLPComment.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtNLPComment.Location = New System.Drawing.Point(304, 97)
		Me.txtNLPComment.Name = "txtNLPComment"
		Me.txtNLPComment.Size = New System.Drawing.Size(372, 184)
		Me.txtNLPComment.TabIndex = 10
		Me.txtNLPComment.Text = ""
		'
		'Form1
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
		Me.ClientSize = New System.Drawing.Size(734, 358)
		Me.Controls.Add(Me.txtNLPComment)
		Me.Controls.Add(Me.Label5)
		Me.Controls.Add(Me.questList)
		Me.Controls.Add(Me.listJFA)
		Me.Controls.Add(Me.ListBox1)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.btnAsk)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.txtQuestion)
		Me.Name = "Form1"
		Me.Text = "Mynoot"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents txtQuestion As RichTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnAsk As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents ListBox1 As ListBox
	Friend WithEvents questList As ListBox
	Friend WithEvents Label5 As Label
	Friend WithEvents listJFA As ListBox
	Friend WithEvents txtNLPComment As RichTextBox
End Class
