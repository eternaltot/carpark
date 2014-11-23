Imports System
Imports System.Windows.Forms

Public Class searchAndEditCardNew

    Dim dbSelect As New DatabaseProjectEntities

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        doSearch()

    End Sub

    Private Sub addCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addCard.Click
        Dim Login As New InsertCardType1
        Login.Show()
        Me.Close()
    End Sub



    Private Sub daleteBt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles daleteBt.Click

        'MessageBox.Show(dateGrid.SelectedRows.Count)


        Dim list As New List(Of Card)

        For index As Integer = 1 To dateGrid.Rows.Count
            Dim x As Boolean
            x = dateGrid.Rows(index - 1).Cells(0).Value

            If x = True Then
                list.Add(dateGrid.Rows(index - 1).DataBoundItem)
            End If
        Next

        For Each item As Card In list
            dbSelect.DeleteObject(item)
        Next

        dbSelect.SaveChanges()

        MessageBox.Show("ลบรายการสำเร็จ")

        doSearch()
    End Sub

    Private Sub doSearch()
        dbSelect = New DatabaseProjectEntities

        Dim cardN = ""
        If CardNoIn.Text <> Nothing Then
            cardN = CardNoIn.Text
        End If

        Dim cardType As String = cardTypeS.SelectedItem
        If cardTypeS.SelectedIndex = -1 Then
            cardType = ""
        End If

        Dim cusName = ""
        If cusNameIn.Text <> Nothing Then
            cusName = cusNameIn.Text
        End If

        Dim cusLastName = ""
        If cusLastNameIn.Text <> Nothing Then
            cusLastName = cusLastNameIn.Text
        End If

        Dim cusCarNo = ""
        If cusCarNoIn.Text <> Nothing Then
            cusCarNo = cusCarNoIn.Text
        End If

        Dim query = From p In dbSelect.Cards Where p.card_no.Contains(cardN) And p.card_type.Contains(cardType) And _
                    (p.MEMBER.MEMBER_NAME.Contains(cusName) Or (cusName = "" And p.MEMBER.MEMBER_NAME Is Nothing)) And _
                    (p.MEMBER.MEMBER_LASTNAME.Contains(cusLastName) Or (cusLastName = "" And p.MEMBER.MEMBER_NAME Is Nothing)) Select p

        dateGrid.DataSource = query.ToList()


        For index As Integer = 1 To dateGrid.Rows.Count
            Dim card As Card = dateGrid.Rows(index - 1).DataBoundItem

            If Not IsDBNull(card) And card.customer_id IsNot Nothing Then
                dateGrid.Rows(index - 1).Cells(3).Value = card.MEMBER.MEMBER_NAME + " " + card.MEMBER.MEMBER_LASTNAME
            End If
        Next

    End Sub

    Private Function setObjectNothing(ByVal indexs As String) As String
        If indexs <> Nothing Then
            For index As Integer = 1 To indexs.Length
                If (indexs(index - 1) <> " ") Then
                    Return indexs
                End If
            Next
        End If

        Return Nothing
    End Function

    Private Function validateSave() As Boolean
        Dim dbValidate As New DatabaseProjectEntities
        Dim message As String = ""
        Dim result As Boolean = True
        For index As Integer = 1 To dateGrid.Rows.Count
            Dim card As Card = dateGrid.Rows(index - 1).DataBoundItem
            Dim text = setObjectNothing(dateGrid.Rows(index - 1).Cells(3).Value)
            If text IsNot Nothing Then
                Dim TestArray() As String = Split(text, " ")
                If TestArray.Length = 2 Then
                    Dim name As String = TestArray(0)
                    Dim lastName As String = TestArray(1)
                    Dim query = From p In dbValidate.MEMBERs Where p.MEMBER_NAME = name And p.MEMBER_LASTNAME = lastName Select p
                    Dim members As IEnumerable(Of MEMBER) = query.ToList()
                    If members.Count = 1 Then
                        card.customer_id = members.ToList.Item(0).MEMBER_ID
                    Else
                        result = False
                        message += "(" + TestArray(0) + " " + TestArray(1) + ")"
                    End If
                Else
                    result = False
                    message += "(" + text + ")"
                End If
            End If
        Next

        If Not result Then
            MessageBox.Show("ไม่พบสมาชิก ดัวต่อไปนี้ " + message + "ในระบบ")
            Return False
        Else
            Return True
        End If

    End Function

    Private Sub saveBt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveBt.Click

        If Not validateSave() Then
            Return
        End If

        If dateGrid.DataSource IsNot Nothing Then
            Dim list As New List(Of Card)
            list = dateGrid.DataSource

            For index As Integer = 1 To dateGrid.Rows.Count
                Dim card As Card = dateGrid.Rows(index - 1).DataBoundItem
                dateGrid.Rows(index - 1).Cells(3).Value = setObjectNothing(dateGrid.Rows(index - 1).Cells(3).Value)
                If dateGrid.Rows(index - 1).Cells(3).Value Is Nothing Then
                    card.customer_id = Nothing
                Else
                    Dim TestArray() As String = Split(Text, " ")
                    If TestArray.Length = 2 Then
                        Dim name As String = TestArray(0)
                        Dim lastName As String = TestArray(1)
                        Dim query = From p In dbSelect.MEMBERs Where p.MEMBER_NAME = name And p.MEMBER_LASTNAME = lastName Select p
                        Dim members As IEnumerable(Of MEMBER) = query.ToList()

                        card.customer_id = members.ToList.Item(0).MEMBER_ID
                    End If
                End If
            Next

            dbSelect.SaveChanges()
        End If

        MessageBox.Show("บันทึกรายการสำเร็จ")
    End Sub


    Private Sub searchAndEditCard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ivp As New String("VIP")
        Me.cardTypeS.Items.Add(ivp)

        ivp = New String("OTHER")
        Me.cardTypeS.Items.Add(ivp)
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        doSearch()
    End Sub
End Class

Public Class CalendarColumn
    Inherits DataGridViewColumn

    Public Sub New()
        MyBase.New(New CalendarCell())
    End Sub

    Public Overrides Property CellTemplate() As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(ByVal value As DataGridViewCell)

            ' Ensure that the cell used for the template is a CalendarCell. 
            If (value IsNot Nothing) AndAlso _
                Not value.GetType().IsAssignableFrom(GetType(CalendarCell)) _
                Then
                Throw New InvalidCastException("Must be a CalendarCell")
            End If
            MyBase.CellTemplate = value

        End Set
    End Property

End Class

Public Class CalendarCell
    Inherits DataGridViewTextBoxCell

    Public Sub New()
        ' Use the short date format. 
        Me.Style.Format = "d"
    End Sub

    Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, _
        ByVal initialFormattedValue As Object, _
        ByVal dataGridViewCellStyle As DataGridViewCellStyle)

        ' Set the value of the editing control to the current cell value. 
        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, _
            dataGridViewCellStyle)

        Dim ctl As CalendarEditingControl = _
            CType(DataGridView.EditingControl, CalendarEditingControl)

        ' Use the default row value when Value property is null. 
        If (Me.Value Is Nothing) Then
            ctl.Value = CType(Me.DefaultNewRowValue, DateTime)
        Else
            ctl.Value = CType(Me.Value, DateTime)
        End If
    End Sub

    Public Overrides ReadOnly Property EditType() As Type
        Get
            ' Return the type of the editing control that CalendarCell uses. 
            Return GetType(CalendarEditingControl)
        End Get
    End Property

    Public Overrides ReadOnly Property ValueType() As Type
        Get
            ' Return the type of the value that CalendarCell contains. 
            Return GetType(DateTime)
        End Get
    End Property

    Public Overrides ReadOnly Property DefaultNewRowValue() As Object
        Get
            ' Use the current date and time as the default value. 
            Return DateTime.Now
        End Get
    End Property

End Class

Class CalendarEditingControl
    Inherits DateTimePicker
    Implements IDataGridViewEditingControl

    Private dataGridViewControl As DataGridView
    Private valueIsChanged As Boolean = False
    Private rowIndexNum As Integer

    Public Sub New()
        Me.Format = DateTimePickerFormat.Short
    End Sub

    Public Property EditingControlFormattedValue() As Object _
        Implements IDataGridViewEditingControl.EditingControlFormattedValue

        Get
            Return Me.Value.ToShortDateString()
        End Get

        Set(ByVal value As Object)
            Try
                ' This will throw an exception of the string is  
                ' null, empty, or not in the format of a date. 
                Me.Value = DateTime.Parse(CStr(value))
            Catch
                ' In the case of an exception, just use the default 
                ' value so we're not left with a null value. 
                Me.Value = DateTime.Now
            End Try
        End Set

    End Property

    Public Function GetEditingControlFormattedValue(ByVal context _
        As DataGridViewDataErrorContexts) As Object _
        Implements IDataGridViewEditingControl.GetEditingControlFormattedValue

        Return Me.Value.ToShortDateString()

    End Function

    Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As  _
        DataGridViewCellStyle) _
        Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl

        Me.Font = dataGridViewCellStyle.Font
        Me.CalendarForeColor = dataGridViewCellStyle.ForeColor
        Me.CalendarMonthBackground = dataGridViewCellStyle.BackColor

    End Sub

    Public Property EditingControlRowIndex() As Integer _
        Implements IDataGridViewEditingControl.EditingControlRowIndex

        Get
            Return rowIndexNum
        End Get
        Set(ByVal value As Integer)
            rowIndexNum = value
        End Set

    End Property

    Public Function EditingControlWantsInputKey(ByVal key As Keys, _
        ByVal dataGridViewWantsInputKey As Boolean) As Boolean _
        Implements IDataGridViewEditingControl.EditingControlWantsInputKey

        ' Let the DateTimePicker handle the keys listed. 
        Select Case key And Keys.KeyCode
            Case Keys.Left, Keys.Up, Keys.Down, Keys.Right, _
                Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp

                Return True

            Case Else
                Return Not dataGridViewWantsInputKey
        End Select

    End Function

    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) _
        Implements IDataGridViewEditingControl.PrepareEditingControlForEdit

        ' No preparation needs to be done. 

    End Sub

    Public ReadOnly Property RepositionEditingControlOnValueChange() _
        As Boolean Implements _
        IDataGridViewEditingControl.RepositionEditingControlOnValueChange

        Get
            Return False
        End Get

    End Property

    Public Property EditingControlDataGridView() As DataGridView _
        Implements IDataGridViewEditingControl.EditingControlDataGridView

        Get
            Return dataGridViewControl
        End Get
        Set(ByVal value As DataGridView)
            dataGridViewControl = value
        End Set

    End Property

    Public Property EditingControlValueChanged() As Boolean _
        Implements IDataGridViewEditingControl.EditingControlValueChanged

        Get
            Return valueIsChanged
        End Get
        Set(ByVal value As Boolean)
            valueIsChanged = value
        End Set

    End Property

    Public ReadOnly Property EditingControlCursor() As Cursor _
        Implements IDataGridViewEditingControl.EditingPanelCursor

        Get
            Return MyBase.Cursor
        End Get

    End Property

    Protected Overrides Sub OnValueChanged(ByVal eventargs As EventArgs)

        ' Notify the DataGridView that the contents of the cell have changed.
        valueIsChanged = True
        Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
        MyBase.OnValueChanged(eventargs)

    End Sub

End Class
