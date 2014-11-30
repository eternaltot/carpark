Public Class Form2

    Private card_reader As New acr

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Login As New start
        Login.Show()
        Me.Close()
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        card_reader.init_reader()
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        card_reader.connect()

        If card_reader.connActive Then
            Dim uid As String
            card_reader.card()
            uid = card_reader.read_uid()

            Dim db As New DatabaseProjectEntities

            Dim Cards = (From p In db.Cards Where p.card_no = uid Select p).FirstOrDefault()

            If Cards Is Nothing Then

            Else
                Dim member = (From p In db.MEMBERs Where p.MEMBER_ID = Cards.customer_id Select p).FirstOrDefault()
                If member Is Nothing Then

                Else
                    Dim movement = (From p In db.Movements Where p.card_id = Cards.card_id And p.customer_id = member.MEMBER_ID And p.end_date Is Nothing Select p).FirstOrDefault()

                    If movement Is Nothing Then

                    Else
                        Dim today As DateTime = DateTime.Now
                        Dim startday As DateTime = movement.start_date

                        movement.end_date = today

                        Dim startDate As String

                        startDate = movement.start_date

                        endDateDB.Text = today.ToString
                        startTB.Text = startDate
                        CarNoOther.Text = movement.CAR_NO_OTHER

                        Dim wD As Long = DateDiff(DateInterval.Minute, startday, today)

                        sumH.Text = Math.Ceiling(wD / 60)

                        priceTB.Text = CType(sumH.Text, Long) * CType(priceOfH.Text, Long)

                        db.SaveChanges()
                    End If
                End If
            End If
        End If
    End Sub

End Class