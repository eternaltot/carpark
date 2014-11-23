<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InsertCardType1
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
        Me.browseFile = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.showFileName = New System.Windows.Forms.TextBox()
        Me.backBt = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'insertCardType
        '
        Me.insertCardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.insertCardType.FormattingEnabled = True
        Me.insertCardType.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.insertCardType.Location = New System.Drawing.Point(27, 12)
        Me.insertCardType.Name = "insertCardType"
        Me.insertCardType.Size = New System.Drawing.Size(233, 21)
        Me.insertCardType.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "text format : "
        '
        'browseFile
        '
        Me.browseFile.Location = New System.Drawing.Point(257, 73)
        Me.browseFile.Name = "browseFile"
        Me.browseFile.Size = New System.Drawing.Size(75, 23)
        Me.browseFile.TabIndex = 2
        Me.browseFile.Text = "browse"
        Me.browseFile.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(85, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(328, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "[card number] | [card type] | [active date] | [expire date] | [card group]"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(338, 73)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "บันทึก"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'showFileName
        '
        Me.showFileName.Location = New System.Drawing.Point(16, 76)
        Me.showFileName.Name = "showFileName"
        Me.showFileName.ReadOnly = True
        Me.showFileName.Size = New System.Drawing.Size(235, 20)
        Me.showFileName.TabIndex = 5
        '
        'backBt
        '
        Me.backBt.Location = New System.Drawing.Point(338, 226)
        Me.backBt.Name = "backBt"
        Me.backBt.Size = New System.Drawing.Size(75, 23)
        Me.backBt.TabIndex = 6
        Me.backBt.Text = "กลับ"
        Me.backBt.UseVisualStyleBackColor = True
        '
        'InsertCardType1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(416, 261)
        Me.Controls.Add(Me.backBt)
        Me.Controls.Add(Me.showFileName)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.browseFile)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.insertCardType)
        Me.Name = "InsertCardType1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents insertCardType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents browseFile As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents showFileName As System.Windows.Forms.TextBox
    Friend WithEvents backBt As System.Windows.Forms.Button

End Class
