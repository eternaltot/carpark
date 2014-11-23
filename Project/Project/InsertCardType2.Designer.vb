<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InsertCardType2
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
        Me.insertCardType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.startDate = New System.Windows.Forms.DateTimePicker()
        Me.endDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cardNostart = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cardNoEnd = New System.Windows.Forms.TextBox()
        Me.saveBt = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cardTypeS = New System.Windows.Forms.ComboBox()
        Me.backBt = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'insertCardType
        '
        Me.insertCardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.insertCardType.FormattingEnabled = True
        Me.insertCardType.Location = New System.Drawing.Point(27, 12)
        Me.insertCardType.Name = "insertCardType"
        Me.insertCardType.Size = New System.Drawing.Size(241, 21)
        Me.insertCardType.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "วันที่ออกบัตร"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "วันที่หมดอายุ"
        '
        'startDate
        '
        Me.startDate.Location = New System.Drawing.Point(67, 54)
        Me.startDate.Name = "startDate"
        Me.startDate.Size = New System.Drawing.Size(205, 20)
        Me.startDate.TabIndex = 3
        '
        'endDate
        '
        Me.endDate.Location = New System.Drawing.Point(67, 93)
        Me.endDate.Name = "endDate"
        Me.endDate.Size = New System.Drawing.Size(205, 20)
        Me.endDate.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 150)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "หมายเลขบัตร"
        '
        'cardNostart
        '
        Me.cardNostart.Location = New System.Drawing.Point(89, 150)
        Me.cardNostart.Name = "cardNostart"
        Me.cardNostart.Size = New System.Drawing.Size(179, 20)
        Me.cardNostart.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(51, 184)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(19, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "ถึง"
        '
        'cardNoEnd
        '
        Me.cardNoEnd.Location = New System.Drawing.Point(89, 184)
        Me.cardNoEnd.Name = "cardNoEnd"
        Me.cardNoEnd.Size = New System.Drawing.Size(179, 20)
        Me.cardNoEnd.TabIndex = 8
        '
        'saveBt
        '
        Me.saveBt.Location = New System.Drawing.Point(193, 221)
        Me.saveBt.Name = "saveBt"
        Me.saveBt.Size = New System.Drawing.Size(75, 23)
        Me.saveBt.TabIndex = 9
        Me.saveBt.Text = "บันทึก"
        Me.saveBt.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "ประเภทบัตร"
        '
        'cardTypeS
        '
        Me.cardTypeS.FormattingEnabled = True
        Me.cardTypeS.Location = New System.Drawing.Point(89, 120)
        Me.cardTypeS.Name = "cardTypeS"
        Me.cardTypeS.Size = New System.Drawing.Size(179, 21)
        Me.cardTypeS.TabIndex = 11
        '
        'backBt
        '
        Me.backBt.Location = New System.Drawing.Point(112, 221)
        Me.backBt.Name = "backBt"
        Me.backBt.Size = New System.Drawing.Size(75, 23)
        Me.backBt.TabIndex = 12
        Me.backBt.Text = "กลับ"
        Me.backBt.UseVisualStyleBackColor = True
        '
        'InsertCardType2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.backBt)
        Me.Controls.Add(Me.cardTypeS)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.saveBt)
        Me.Controls.Add(Me.cardNoEnd)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cardNostart)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.endDate)
        Me.Controls.Add(Me.startDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.insertCardType)
        Me.Name = "InsertCardType2"
        Me.Text = "Form2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents insertCardType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents startDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents endDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cardNostart As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cardNoEnd As System.Windows.Forms.TextBox
    Friend WithEvents saveBt As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cardTypeS As System.Windows.Forms.ComboBox
    Friend WithEvents backBt As System.Windows.Forms.Button
End Class
