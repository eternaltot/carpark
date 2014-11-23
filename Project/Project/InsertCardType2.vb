Public Class InsertCardType2

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

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ivp As New String("VIP")
        Me.cardTypeS.Items.Add(ivp)

        ivp = New String("OTHER")
        Me.cardTypeS.Items.Add(ivp)

        setComboboxInsertCard(1)
    End Sub

    Private Sub insertCardType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles insertCardType.SelectedIndexChanged
        Dim ivp As vpair = insertCardType.SelectedItem

        If ivp.value = 1 Then
            Dim Login As New InsertCardType1
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

    Private Sub cardNostart_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cardNostart.KeyPress

        '97 - 122 = Ascii codes for simple letters
        '65 - 90  = Ascii codes for capital letters
        '48 - 57  = Ascii codes for numbers

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub cardNoEnd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cardNoEnd.KeyPress

        '97 - 122 = Ascii codes for simple letters
        '65 - 90  = Ascii codes for capital letters
        '48 - 57  = Ascii codes for numbers

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub saveBt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveBt.Click

        If cardNoEnd.Text = Nothing Or cardNostart.Text = Nothing Then
            MessageBox.Show("กรุณากรอกข้อมูลให้ครบ")
            Return
        End If

        If CType(cardNoEnd.Text, Integer) < CType(cardNostart.Text, Integer) Then
            MessageBox.Show("หมายเลขบัตรสิ้นสุดจะต้องมากกว่าหมายเลขบัตรเริ่มต้น")
            Return
        End If

        If endDate.Value < startDate.Value Then
            MessageBox.Show("วันที่สิ้นสุดจะต้องมากกว่าวันที่เริ่มต้น")
            Return
        End If

        Dim db As New DatabaseProjectEntities

        Dim query = From p In db.Cards Where p.card_no >= cardNostart.Text And p.card_no <= cardNoEnd.Text Select p
        Dim Cards As IEnumerable(Of Card) = query.ToList()

        If Cards.Count <> 0 Then
            MessageBox.Show("หมายเลขบัตรซ้ำกับในระบบ")
            Return
        End If

        Dim newCard As Card

        Dim cardType As String = cardTypeS.SelectedItem

        If cardTypeS.SelectedIndex = -1 Then
            cardType = ""
        End If

        For number As Integer = CType(cardNostart.Text, Integer) To CType(cardNoEnd.Text, Integer)
            newCard = New Card()

            newCard.card_no = number
            newCard.start_date = startDate.Value
            newCard.end_date = endDate.Value
            newCard.card_type = cardType

            db.Cards.AddObject(newCard)
            db.SaveChanges()
        Next

        MessageBox.Show("บันทึกรายการสำเร็จ")

    End Sub

    Private Sub backBt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles backBt.Click
        Dim Login As New searchAndEditCardNew
        Login.Show()
        Me.Close()
    End Sub
End Class