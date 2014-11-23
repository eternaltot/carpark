Public Class vpair
    Public text As String
    Public value As Int32

    Public Sub New()
    End Sub

    Public Sub New(ByVal textIn As String, ByVal ValueIn As Int32)
        Me.text = textIn
        Me.value = ValueIn
    End Sub

    Public Overrides Function toString() As String

        Return text

    End Function

End Class
