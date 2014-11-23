Imports Excel = Microsoft.Office.Interop.Excel

Public Class InsertCardType1

    Dim APP As New Excel.Application

    Dim worksheet As Excel.Worksheet

    Dim workbook As Excel.Workbook

    Private Sub setComboboxInsertCard(ByVal index As Int32)
        Dim ivp As New vpair("นำเข้าจากไฟล์ ตามรูปแบบที่กำหนดไว้", 1)
        Me.insertCardType.Items.Add(ivp)

        ivp = New vpair("นำเข้าตามลำดับบัตร เรียงลำดับตามตัวเลข ตัวอักษร", 2)
        Me.insertCardType.Items.Add(ivp)

        ivp = New vpair("นําเข้าแยกตาม หมายเลขบัตรทีละ 20 หมายเลข", 3)
        Me.insertCardType.Items.Add(ivp)

        ivp = New vpair("บัตรรายเดือน บัตร VIP ซึ่งมีการจ่ายค่าเช่าเป็นรายเดือน", 4)
        Me.insertCardType.Items.Add(ivp)

        Me.insertCardType.SelectedIndex = index
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles insertCardType.SelectedIndexChanged

        Dim ivp As vpair = insertCardType.SelectedItem

        If ivp.value = 2 Then
            Dim Login As New InsertCardType2
            Login.Show()
            Me.Close()
        ElseIf ivp.value = 3 Then
            Dim Login As New InsertCardType3
            Login.Show()
            Me.Close()
        ElseIf ivp.value = 4 Then
            Dim Login As New InsertCardType4
            Login.Show()
            Me.Close()
        End If

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        setComboboxInsertCard(0)
    End Sub

    Private Sub browseFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles browseFile.Click
        Using ofd As New OpenFileDialog()
            ofd.Filter = "XLS Files (*.xls)|*.xls|XLSX Files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
            If ofd.ShowDialog() = DialogResult.OK Then
                Dim TestArray() As String = Split(ofd.FileName, "\")

                showFileName.Text = TestArray(TestArray.Length - 1)
            End If


            workbook = APP.Workbooks.Open(ofd.FileName)

            worksheet = workbook.Sheets.Item(1)

        End Using
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim index As Int32 = 1
        Dim newCard As Card
        Dim db As New DatabaseProjectEntities

        If showFileName.Text = Nothing Then
            MessageBox.Show("กรุณาเลือกไฟล์")
            Return
        End If

        While worksheet.Cells(index, 2).Value <> Nothing
            newCard = New Card()
            newCard.card_no = worksheet.Cells(index, 1).Value
            newCard.card_type = UCase(worksheet.Cells(index, 2).Value)

            If TypeOf worksheet.Cells(index, 3).Value Is Date Then
                newCard.start_date = worksheet.Cells(index, 3).Value
            ElseIf TypeOf worksheet.Cells(index, 3).Value Is String Then
                newCard.end_date = DateTime.Parse(worksheet.Cells(index, 3).Value)
            End If

            If TypeOf worksheet.Cells(index, 4).Value Is Date Then
                newCard.end_date = worksheet.Cells(index, 4).Value
            ElseIf TypeOf worksheet.Cells(index, 4).Value Is String Then
                newCard.end_date = DateTime.Parse(worksheet.Cells(index, 4).Value)
            End If

            db.Cards.AddObject(newCard)
            index = index + 1
        End While

        db.SaveChanges()

        MessageBox.Show("บันทึกรายการสำเร็จ")
    End Sub

    Private Sub backBt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles backBt.Click
        Dim Login As New searchAndEditCardNew
        Login.Show()
        Me.Close()
    End Sub
End Class
