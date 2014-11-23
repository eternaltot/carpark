Public Class InsertCardType4
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

    Private Sub InsertCardType4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        setComboboxInsertCard(3)
    End Sub

    Private Sub numberCardkeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cardNo1.KeyPress, cardNo2.KeyPress, cardNo3.KeyPress, cardNo4.KeyPress, cardNo5.KeyPress, cardNo6.KeyPress, cardNo7.KeyPress, cardNo8.KeyPress, cardNo9.KeyPress, cardNo10.KeyPress
        '97 - 122 = Ascii codes for simple letters
        '65 - 90  = Ascii codes for capital letters
        '48 - 57  = Ascii codes for numbers

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
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
        ElseIf ivp.value = 3 Then
            Dim Login As New InsertCardType3
            Login.Show()
            Me.Close()
        End If
    End Sub

    Private Function validateObject(ByVal indexs As List(Of String)) As Boolean
        Dim db As New DatabaseProjectEntities
        Dim result As Boolean = True
        For Each objects As String In indexs
            Dim listSave As New List(Of String)
            Dim TestArray() As String = Split(objects, ":")

            Dim cardNo As String = TestArray(0)
            Dim name As String = TestArray(1)
            Dim surname As String = TestArray(2)
            Dim carNo As String = TestArray(3)

            If (cardNo = Nothing And name = Nothing And cardNo = Nothing And surname = Nothing And carNo = Nothing) Or _
                 (cardNo <> Nothing And name <> Nothing And cardNo <> Nothing And surname <> Nothing And carNo <> Nothing) Then
            Else
                result = False
            End If
        Next

        If result Then
            Return False
        Else
            MessageBox.Show("กรุณากรอกข้อมูลให้ถูกต้อง")
            Return True
        End If

    End Function

    Private Function validateSave(ByVal indexs As List(Of String)) As Boolean
        Dim db As New DatabaseProjectEntities
        Dim result As Boolean = True
        Dim message As String = ""
        For Each objects As String In indexs
            Dim listSave As New List(Of String)
            Dim TestArray() As String = Split(objects, ":")

            Dim cardNo As String = TestArray(0)
            Dim name As String = TestArray(1)
            Dim surname As String = TestArray(2)
            Dim carNo As String = TestArray(3)

            If cardNo <> Nothing Then
                Dim query = From p In db.Cards Where p.card_no = cardNo Select p
                Dim Cards As IEnumerable(Of Card) = query.ToList()

                If Cards.Count <> 0 Then
                    message += cardNo + " "
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

    Private Function validateSaveCardAndMember(ByVal indexs As List(Of String)) As Boolean
        Dim db As New DatabaseProjectEntities
        Dim result As Boolean = False
        Dim resultCar As Boolean = False
        Dim message As String = ""
        For Each objects As String In indexs
            Dim listSave As New List(Of String)
            Dim TestArray() As String = Split(objects, ":")

            Dim cardNo As String = TestArray(0)
            Dim name As String = TestArray(1)
            Dim surname As String = TestArray(2)
            Dim carNo As String = TestArray(3)

            If cardNo <> Nothing Then
                Dim query = From p In db.MEMBERs Where p.MEMBER_NAME = name And p.MEMBER_LASTNAME = surname Select p
                Dim members As IEnumerable(Of MEMBER) = query.ToList()

                If members.Count = 0 Then
                    message += "(" + name + " " + surname + ")"
                    result = True
                Else

                    Dim memId As String = members.ToList.Item(0).MEMBER_ID

                    Dim queryCar = From p In db.CARs Where p.CAR_NO = carNo And p.MEMBER_ID = memId Select p
                    Dim cars As IEnumerable(Of CAR) = queryCar.ToList()

                    If cars.Count = 0 Then
                        message += "(" + name + " " + surname + ")"
                        resultCar = True
                    End If
                End If
            End If
        Next

        If result Then
            MessageBox.Show("ไม่พบสมาชิก ดัวต่อไปนี้ " + message + "ในระบบ")
            Return True
        ElseIf resultCar Then
            MessageBox.Show("ไม่พบทะเบียนรถของสมาชิก ดัวต่อไปนี้ " + message + "ในระบบ")
            Return True
        Else
            Return False
        End If
    End Function

    Private Function saveObject(ByVal indexs As List(Of String)) As Boolean
        Dim db As New DatabaseProjectEntities
        Dim result As Boolean = False
        Dim resultCar As Boolean = False
        Dim message As String = ""
        For Each objects As String In indexs
            Dim listSave As New List(Of String)
            Dim TestArray() As String = Split(objects, ":")

            Dim cardNo As String = TestArray(0)
            Dim name As String = TestArray(1)
            Dim surname As String = TestArray(2)
            Dim carNo As String = TestArray(3)

            If cardNo <> Nothing Then
                Dim query = From p In db.MEMBERs Where p.MEMBER_NAME = name And p.MEMBER_LASTNAME = surname Select p
                Dim members As IEnumerable(Of MEMBER) = query.ToList()

                If members.Count = 1 Then
                    Dim memId As String = members.ToList.Item(0).MEMBER_ID

                    Dim newCard As Card = New Card()
                    newCard.customer_id = memId
                    newCard.card_type = "VIP"
                    newCard.start_date = startDate.Value
                    newCard.end_date = endDate.Value
                    newCard.card_no = cardNo

                    db.Cards.AddObject(newCard)
                End If
            End If
        Next

        If result Then
            MessageBox.Show("ไม่พบสมาชิก ดัวต่อไปนี้ " + message + "ในระบบ")
            Return True
        ElseIf resultCar Then
            MessageBox.Show("ไม่พบทะเบียนรถของสมาชิก ดัวต่อไปนี้ " + message + "ในระบบ")
            Return True
        Else
            db.SaveChanges()
            Return False
        End If
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If endDate.Value < startDate.Value Then
            MessageBox.Show("วันที่สิ้นสุดจะต้องมากกว่าวันที่เริ่มต้น")
            Return
        End If


        Dim listSave As New List(Of String)
        listSave.Add(cardNo1.Text + ":" + name1.Text + ":" + surname1.Text + ":" + carNo1.Text)
        listSave.Add(cardNo2.Text + ":" + name2.Text + ":" + surname2.Text + ":" + carNo2.Text)
        listSave.Add(cardNo3.Text + ":" + name3.Text + ":" + surname3.Text + ":" + carNo3.Text)
        listSave.Add(cardNo4.Text + ":" + name4.Text + ":" + surname4.Text + ":" + carNo4.Text)
        listSave.Add(cardNo5.Text + ":" + name5.Text + ":" + surname5.Text + ":" + carNo5.Text)
        listSave.Add(cardNo6.Text + ":" + name6.Text + ":" + surname6.Text + ":" + carNo6.Text)
        listSave.Add(cardNo7.Text + ":" + name7.Text + ":" + surname7.Text + ":" + carNo7.Text)
        listSave.Add(cardNo8.Text + ":" + name8.Text + ":" + surname8.Text + ":" + carNo8.Text)
        listSave.Add(cardNo9.Text + ":" + name9.Text + ":" + surname9.Text + ":" + carNo9.Text)
        listSave.Add(cardNo10.Text + ":" + name10.Text + ":" + surname10.Text + ":" + carNo10.Text)

        If validateObject(listSave) Then
            Return
        End If

        If validateSave(listSave) Then
            Return
        End If

        If validateSaveCardAndMember(listSave) Then
            Return
        End If

        saveObject(listSave)

        MessageBox.Show("บันทึกรายการสำเร็จ")
    End Sub

    Private Sub backBt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles backBt.Click
        Dim Login As New searchAndEditCardNew
        Login.Show()
        Me.Close()
    End Sub
End Class