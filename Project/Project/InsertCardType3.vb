Public Class InsertCardType3

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

    Private Sub insertCardType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles insertCardType.SelectedIndexChanged
        Dim ivp As vpair = insertCardType.SelectedItem

        If ivp.value = 1 Then
            Dim Login As New InsertCardType1
            Login.Show()
            Me.Close()
        ElseIf ivp.value = 2 Then
            Dim Login As New InsertCardType2
            Login.Show()
            Me.Close()
        ElseIf ivp.value = 4 Then
            Dim Login As New InsertCardType4
            Login.Show()
            Me.Close()
        End If
    End Sub


    Private Sub InsertCardType3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        setComboboxInsertCard(2)

        Dim ivp As New String("VIP")
        Me.cardTypeS.Items.Add(ivp)

        ivp = New String("OTHER")
        Me.cardTypeS.Items.Add(ivp)
    End Sub

    Private Sub numberCardkeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles numberCard1.KeyPress, numberCard2.KeyPress, numberCard3.KeyPress, numberCard4.KeyPress, numberCard5.KeyPress, numberCard6.KeyPress, numberCard7.KeyPress, numberCard8.KeyPress, numberCard9.KeyPress, numberCard10.KeyPress _
                                                                                                                        , numberCard11.KeyPress, numberCard12.KeyPress, numberCard13.KeyPress, numberCard14.KeyPress, numberCard15.KeyPress, numberCard16.KeyPress, numberCard17.KeyPress, numberCard18.KeyPress, numberCard19.KeyPress, numberCard20.KeyPress
        '97 - 122 = Ascii codes for simple letters
        '65 - 90  = Ascii codes for capital letters
        '48 - 57  = Ascii codes for numbers

        'If Asc(e.KeyChar) <> 8 Then
        'If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
        'e.Handled = True
        'End If
        'End If
    End Sub

    Private Sub saveChanges(ByVal indexs As List(Of System.Windows.Forms.TextBox))
        Dim db As New DatabaseProjectEntities
        Dim newCard As Card

        Dim cardType As String = cardTypeS.SelectedItem

        If cardTypeS.SelectedIndex = -1 Then
            cardType = ""
        End If

        For Each index As System.Windows.Forms.TextBox In indexs
            If index.Text <> Nothing Then
                newCard = New Card()
                newCard.card_no = index.Text
                newCard.start_date = startDate.Value
                newCard.end_date = endDate.Value
                newCard.card_type = cardType
                db.Cards.AddObject(newCard)
                db.SaveChanges()
            End If
        Next
    End Sub

    Private Function validateSave(ByVal indexs As List(Of System.Windows.Forms.TextBox)) As Boolean
        Dim db As New DatabaseProjectEntities
        Dim message As String = ""
        Dim result As Boolean = True
        For Each objects As System.Windows.Forms.TextBox In indexs
            If objects.Text <> Nothing Then
                Dim text As String = objects.Text
                Dim query = From p In db.Cards Where p.card_no = text Select p
                Dim Cards As IEnumerable(Of Card) = query.ToList()

                If Cards.Count <> 0 Then
                    message += text + " "
                    result = False
                End If
            End If
        Next

        If result Then
            Return False
        Else
            MessageBox.Show("มีหมายเลขบัตร" + message + "ซ้ำกับในระบบ")
            Return True
        End If

    End Function

   
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim TorsionList As New List(Of System.Windows.Forms.TextBox)
        TorsionList.Add(numberCard1)
        TorsionList.Add(numberCard2)
        TorsionList.Add(numberCard3)
        TorsionList.Add(numberCard4)
        TorsionList.Add(numberCard5)
        TorsionList.Add(numberCard6)
        TorsionList.Add(numberCard7)
        TorsionList.Add(numberCard8)
        TorsionList.Add(numberCard9)
        TorsionList.Add(numberCard10)
        TorsionList.Add(numberCard11)
        TorsionList.Add(numberCard12)
        TorsionList.Add(numberCard13)
        TorsionList.Add(numberCard14)
        TorsionList.Add(numberCard15)
        TorsionList.Add(numberCard16)
        TorsionList.Add(numberCard17)
        TorsionList.Add(numberCard18)
        TorsionList.Add(numberCard19)
        TorsionList.Add(numberCard20)

        If endDate.Value < startDate.Value Then
            MessageBox.Show("วันที่สิ้นสุดจะต้องมากกว่าวันที่เริ่มต้น")
            Return
        End If

        If validateSave(TorsionList) Then
            Return
        End If
        saveChanges(TorsionList)

        MessageBox.Show("บันทึกรายการสำเร็จ")

    End Sub

    Private Sub backBt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles backBt.Click
        Dim Login As New searchAndEditCardNew
        Login.Show()
        Me.Close()
    End Sub

    Private Sub numberCard1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numberCard1.TextChanged

    End Sub
End Class