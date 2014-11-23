<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class searchAndEditCardNew
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
        Me.components = New System.ComponentModel.Container()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cardTypeS = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cusLastNameIn = New System.Windows.Forms.TextBox()
        Me.cusNameIn = New System.Windows.Forms.TextBox()
        Me.CardNoIn = New System.Windows.Forms.TextBox()
        Me.cardN = New System.Windows.Forms.ComboBox()
        Me.addCard = New System.Windows.Forms.Button()
        Me.daleteBt = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cusCarNoIn = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dateGrid = New System.Windows.Forms.DataGridView()
        Me.CardBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.saveBt = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CalendarColumn1 = New Project.CalendarColumn()
        Me.selectData = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.CardnoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CardtypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.MemberName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StartdateDataGridViewTextBoxColumn = New Project.CalendarColumn()
        Me.EnddateDataGridViewTextBoxColumn = New Project.CalendarColumn()
        CType(Me.dateGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CardBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(520, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "นามสกุล"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(359, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(20, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "ชื่อ"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(191, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "รหัสบัตร"
        '
        'cardTypeS
        '
        Me.cardTypeS.FormattingEnabled = True
        Me.cardTypeS.Location = New System.Drawing.Point(82, 12)
        Me.cardTypeS.Name = "cardTypeS"
        Me.cardTypeS.Size = New System.Drawing.Size(94, 21)
        Me.cardTypeS.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "ประเภทบัตร"
        '
        'cusLastNameIn
        '
        Me.cusLastNameIn.Location = New System.Drawing.Point(572, 13)
        Me.cusLastNameIn.Name = "cusLastNameIn"
        Me.cusLastNameIn.Size = New System.Drawing.Size(121, 20)
        Me.cusLastNameIn.TabIndex = 11
        '
        'cusNameIn
        '
        Me.cusNameIn.Location = New System.Drawing.Point(399, 13)
        Me.cusNameIn.Name = "cusNameIn"
        Me.cusNameIn.Size = New System.Drawing.Size(115, 20)
        Me.cusNameIn.TabIndex = 10
        '
        'CardNoIn
        '
        Me.CardNoIn.Location = New System.Drawing.Point(243, 12)
        Me.CardNoIn.Name = "CardNoIn"
        Me.CardNoIn.Size = New System.Drawing.Size(110, 20)
        Me.CardNoIn.TabIndex = 9
        '
        'cardN
        '
        Me.cardN.FormattingEnabled = True
        Me.cardN.Items.AddRange(New Object() {"VIP", "OTHER"})
        Me.cardN.Location = New System.Drawing.Point(82, 12)
        Me.cardN.Name = "cardN"
        Me.cardN.Size = New System.Drawing.Size(94, 21)
        Me.cardN.TabIndex = 13
        '
        'addCard
        '
        Me.addCard.Location = New System.Drawing.Point(618, 54)
        Me.addCard.Name = "addCard"
        Me.addCard.Size = New System.Drawing.Size(75, 23)
        Me.addCard.TabIndex = 17
        Me.addCard.Text = "เพิ่ม"
        Me.addCard.UseVisualStyleBackColor = True
        '
        'daleteBt
        '
        Me.daleteBt.Location = New System.Drawing.Point(537, 54)
        Me.daleteBt.Name = "daleteBt"
        Me.daleteBt.Size = New System.Drawing.Size(75, 23)
        Me.daleteBt.TabIndex = 18
        Me.daleteBt.Text = "ลบ"
        Me.daleteBt.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(194, 54)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 19
        Me.Button1.Text = "ค้นหา"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cusCarNoIn
        '
        Me.cusCarNoIn.Location = New System.Drawing.Point(82, 54)
        Me.cusCarNoIn.Name = "cusCarNoIn"
        Me.cusCarNoIn.Size = New System.Drawing.Size(100, 20)
        Me.cusCarNoIn.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "ทะเบียนรถ"
        '
        'dateGrid
        '
        Me.dateGrid.AllowUserToAddRows = False
        Me.dateGrid.AllowUserToDeleteRows = False
        Me.dateGrid.AutoGenerateColumns = False
        Me.dateGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dateGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.selectData, Me.CardnoDataGridViewTextBoxColumn, Me.CardtypeDataGridViewTextBoxColumn, Me.MemberName, Me.StartdateDataGridViewTextBoxColumn, Me.EnddateDataGridViewTextBoxColumn})
        Me.dateGrid.DataSource = Me.CardBindingSource
        Me.dateGrid.Location = New System.Drawing.Point(15, 99)
        Me.dateGrid.Name = "dateGrid"
        Me.dateGrid.Size = New System.Drawing.Size(678, 277)
        Me.dateGrid.TabIndex = 22
        '
        'CardBindingSource
        '
        Me.CardBindingSource.DataSource = GetType(Project.Card)
        '
        'saveBt
        '
        Me.saveBt.Location = New System.Drawing.Point(618, 382)
        Me.saveBt.Name = "saveBt"
        Me.saveBt.Size = New System.Drawing.Size(75, 23)
        Me.saveBt.TabIndex = 23
        Me.saveBt.Text = "บันทึก"
        Me.saveBt.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(537, 382)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 24
        Me.Button2.Text = "ยกเลิก"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "card_no"
        Me.DataGridViewTextBoxColumn1.HeaderText = "card_no"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "MemberName"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "start_date"
        Me.DataGridViewTextBoxColumn3.HeaderText = "start_date"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'CalendarColumn1
        '
        Me.CalendarColumn1.DataPropertyName = "end_date"
        Me.CalendarColumn1.HeaderText = "end_date"
        Me.CalendarColumn1.Name = "CalendarColumn1"
        Me.CalendarColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CalendarColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'selectData
        '
        Me.selectData.HeaderText = ""
        Me.selectData.Name = "selectData"
        Me.selectData.Width = 50
        '
        'CardnoDataGridViewTextBoxColumn
        '
        Me.CardnoDataGridViewTextBoxColumn.DataPropertyName = "card_no"
        Me.CardnoDataGridViewTextBoxColumn.HeaderText = "card_no"
        Me.CardnoDataGridViewTextBoxColumn.Name = "CardnoDataGridViewTextBoxColumn"
        '
        'CardtypeDataGridViewTextBoxColumn
        '
        Me.CardtypeDataGridViewTextBoxColumn.DataPropertyName = "card_type"
        Me.CardtypeDataGridViewTextBoxColumn.HeaderText = "card_type"
        Me.CardtypeDataGridViewTextBoxColumn.Items.AddRange(New Object() {"VIP", "OTHER"})
        Me.CardtypeDataGridViewTextBoxColumn.Name = "CardtypeDataGridViewTextBoxColumn"
        Me.CardtypeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CardtypeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'MemberName
        '
        Me.MemberName.HeaderText = "MemberName"
        Me.MemberName.Name = "MemberName"
        '
        'StartdateDataGridViewTextBoxColumn
        '
        Me.StartdateDataGridViewTextBoxColumn.DataPropertyName = "start_date"
        Me.StartdateDataGridViewTextBoxColumn.HeaderText = "start_date"
        Me.StartdateDataGridViewTextBoxColumn.Name = "StartdateDataGridViewTextBoxColumn"
        Me.StartdateDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.StartdateDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'EnddateDataGridViewTextBoxColumn
        '
        Me.EnddateDataGridViewTextBoxColumn.DataPropertyName = "end_date"
        Me.EnddateDataGridViewTextBoxColumn.HeaderText = "end_date"
        Me.EnddateDataGridViewTextBoxColumn.Name = "EnddateDataGridViewTextBoxColumn"
        Me.EnddateDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EnddateDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'searchAndEditCardNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(705, 417)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.saveBt)
        Me.Controls.Add(Me.dateGrid)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cusCarNoIn)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.daleteBt)
        Me.Controls.Add(Me.addCard)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cardTypeS)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cusLastNameIn)
        Me.Controls.Add(Me.cusNameIn)
        Me.Controls.Add(Me.CardNoIn)
        Me.Name = "searchAndEditCardNew"
        Me.Text = "searchAndEditCardNew"
        CType(Me.dateGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CardBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents cardTypeS As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cusLastNameIn As System.Windows.Forms.TextBox
    Friend WithEvents cusNameIn As System.Windows.Forms.TextBox
    Friend WithEvents CardNoIn As System.Windows.Forms.TextBox
    Public WithEvents cardN As System.Windows.Forms.ComboBox
    Friend WithEvents addCard As System.Windows.Forms.Button
    Friend WithEvents daleteBt As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cusCarNoIn As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dateGrid As System.Windows.Forms.DataGridView
    Friend WithEvents saveBt As System.Windows.Forms.Button
    Friend WithEvents CardBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MEMBERDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CalendarColumn1 As Project.CalendarColumn
    Friend WithEvents selectData As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents CardnoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CardtypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents MemberName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StartdateDataGridViewTextBoxColumn As Project.CalendarColumn
    Friend WithEvents EnddateDataGridViewTextBoxColumn As Project.CalendarColumn
End Class
