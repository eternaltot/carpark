Imports System.Collections.Generic

Public Class acr
    Private hContext As Long '--- context of reader ---

    Private hCard As Long '--- card handle ---
    Private Protocol As Long '--- protocal handle ---

    Private pollCase As Long

    Public readers As List(Of String) = New List(Of String)()
    Public connActive As Boolean = False
    Public CheckCard As Boolean = False


    Public CurrentReader As String = ""
    Public CurrentCardName As String = ""

    Public autoDet As Boolean
    Public dualPoll As Boolean
    Public detect As Boolean

    Public SendBuff(262) As Byte
    Public RecvBuff(262) As Byte
    Public SendLen As Integer
    Public RecvLen As Integer
    Public nBytesRet As Integer


    Private RdrState As SCARD_READERSTATE
    Private ioRequest As SCARD_IO_REQUEST
    Private dwState As Long
    Private dwActProtocol As Long

    Private ATRLen As Integer
    Private ATRVal(256) As Byte

    Public Sub close_reader()
        Dim retCode As Long

        retCode = ModWinsCard.SCardReleaseContext(hContext)

        If connActive Then
            retCode = ModWinsCard.SCardDisconnect(hCard, ModWinsCard.SCARD_UNPOWER_CARD)
        End If
    End Sub


    Public Sub init_reader()
        Dim ReaderCount As Integer
        Dim ctr As Integer
        Dim sReaderList As String = ""
        Dim retCode As Long

        '--- Generate Reader list ---
        For ctr = 0 To 255
            sReaderList = sReaderList + vbNullChar
        Next
        ReaderCount = 255

        ' 1. Establish context and obtain hContext handle
        retCode = ModWinsCard.SCardEstablishContext(ModWinsCard.SCARD_SCOPE_USER, 0, 0, hContext)

        If retCode <> ModWinsCard.SCARD_S_SUCCESS Then
            MsgBox("Error " & retCode)
            Exit Sub
        End If

        ' 2. List PC/SC card readers installed in the system
        retCode = ModWinsCard.SCardListReaders(hContext, "", sReaderList, ReaderCount)

        If retCode <> ModWinsCard.SCARD_S_SUCCESS Then
            MsgBox("Error " & retCode)
            Exit Sub
        End If

        readers.Clear()

        Dim sTemp As String
        Dim indx As Integer

        indx = 1
        sTemp = ""

        While (Mid(sReaderList, indx, 1) <> vbNullChar)
            While (Mid(sReaderList, indx, 1) <> vbNullChar)
                sTemp = sTemp + Mid(sReaderList, indx, 1)
                indx = indx + 1
            End While

            indx = indx + 1
            readers.Add(sTemp)
            sTemp = ""
        End While

        If readers.Count > 0 Then
            CurrentReader = readers.Item(0)
        End If
    End Sub


    Public Sub connect()
        Dim retCode As Long

        If connActive Then
            retCode = ModWinsCard.SCardDisconnect(hCard, ModWinsCard.SCARD_UNPOWER_CARD)
        End If

        If CurrentReader.Length > 0 Then
            'Connect
            retCode = ModWinsCard.SCardConnect(hContext, _
                                CurrentReader, _
                                ModWinsCard.SCARD_SHARE_SHARED, _
                                ModWinsCard.SCARD_PROTOCOL_T0 Or ModWinsCard.SCARD_PROTOCOL_T1, _
                                hCard, _
                                Protocol)
            If retCode <> ModWinsCard.SCARD_S_SUCCESS Then
                connActive = False
            Else
                connActive = True
            End If
        End If
    End Sub

    Public Sub card()
        Dim ReaderLen As Long
        Dim tmpWord As Long = 32
        Dim retCode As Long

        If connActive Then
            ATRLen = tmpWord
            retCode = ModWinsCard.SCardStatus(hCard, CurrentReader, ReaderLen, dwState, dwActProtocol, ATRVal(0), ATRLen)
            If retCode <> ModWinsCard.SCARD_S_SUCCESS Then
                MsgBox("nocard")
                CheckCard = False
            Else
                'MsgBox("card detect")
                InterpretATR()

                CheckCard = True
            End If

        End If

    End Sub

    Private Sub InterpretATR()
        Dim RIDVal As String = ""
        Dim cardName As String = ""
        Dim sATRStr As String = ""
        Dim lATRStr As String = ""
        Dim tmpVal As String = ""
        Dim indx As Integer
        Dim indx2 As Integer

        ' 4. Interpret ATR and guess card
        ' 4.1. Mifare cards using ISO 14443 Part 3 Supplemental Document
        If CInt(ATRLen) > 14 Then
            RIDVal = ""
            sATRStr = ""
            lATRStr = ""

            For indx = 7 To 11
                RIDVal = RIDVal & Format(Hex(ATRVal(indx)))
            Next indx

            For indx = 0 To 4
                'shift bit to right
                tmpVal = ATRVal(indx)
                For indx2 = 1 To 4
                    tmpVal = tmpVal / 2
                Next

                If ((indx = 1) And (tmpVal = 8)) Then
                    lATRStr = lATRStr + "8X"
                    sATRStr = sATRStr + "8X"
                Else
                    If indx = 4 Then
                        lATRStr = lATRStr + Format(Hex(ATRVal(indx)))
                    Else
                        lATRStr = lATRStr + Format(Hex(ATRVal(indx)))
                        sATRStr = sATRStr + Format(Hex(ATRVal(indx)))
                    End If
                End If
            Next

            ' Felica and Topaz Cards
            If ATRVal(12) = &H3 Then
                If ATRVal(13) = &HF0 Then
                    Select Case ATRVal(14)
                        Case &H11 : cardName = "FeliCa 212K"
                        Case &H12 : cardName = "Felica 424K"
                        Case &H4 : cardName = "Topaz"
                    End Select
                End If
            End If

            If ATRVal(12) = &H3 Then
                If ATRVal(13) = &H0 Then
                    Select Case ATRVal(14)
                        Case &H1 : cardName = cardName + " Mifare Standard 1K"
                        Case &H2 : cardName = cardName + " Mifare Standard 4K"
                        Case &H3 : cardName = cardName + " Mifare Ultra light"
                        Case &H4 : cardName = cardName + " SLE55R_XXXX"
                        Case &H6 : cardName = cardName + " SR176"
                        Case &H7 : cardName = cardName + " SRI X4K"
                        Case &H8 : cardName = cardName + " AT88RF020"
                        Case &H9 : cardName = cardName + " AT88SC0204CRF"
                        Case &HA : cardName = cardName + " AT88SC0808CRF"
                        Case &HB : cardName = cardName + " AT88SC1616CRF"
                        Case &HC : cardName = cardName + " AT88SC3216CRF"
                        Case &HD : cardName = cardName + " AT88SC6416CRF"
                        Case &HE : cardName = cardName + " SRF55V10P"
                        Case &HF : cardName = cardName + " SRF55V02P"
                        Case &H10 : cardName = cardName + " SRF55V10S"
                        Case &H11 : cardName = cardName + " SRF55V02S"
                        Case &H12 : cardName = cardName + " TAG IT"
                        Case &H13 : cardName = cardName + " LRI512"
                        Case &H14 : cardName = cardName + " ICODESLI"
                        Case &H15 : cardName = cardName + " TEMPSENS"
                        Case &H16 : cardName = cardName + " I.CODE1"
                        Case &H17 : cardName = cardName + " PicoPass 2K"
                        Case &H18 : cardName = cardName + " PicoPass 2KS"
                        Case &H19 : cardName = cardName + " PicoPass 16K"
                        Case &H1A : cardName = cardName + " PicoPass 16KS"
                        Case &H1B : cardName = cardName + " PicoPass 16K(8x2)"
                        Case &H1C : cardName = cardName + " PicoPass 16KS(8x2)"
                        Case &H1D : cardName = cardName + ": PicoPass 32KS(16+16)"
                        Case &H1E : cardName = cardName + ": PicoPass 32KS(16+8x2)"
                        Case &H1F : cardName = cardName + ": PicoPass 32KS(8x2+16)"
                        Case &H20 : cardName = cardName + ": PicoPass 32KS(8x2+8x2)"
                        Case &H21 : cardName = cardName + ": LRI64"
                        Case &H22 : cardName = cardName + ": I.CODE UID"
                        Case &H23 : cardName = cardName + ": I.CODE EPC"
                        Case &H24 : cardName = cardName + ": LRI12"
                        Case &H25 : cardName = cardName + ": LRI128"
                        Case &H26 : cardName = cardName + ": Mifare Mini"
                    End Select
                Else
                    If ATRVal(13) = &HFF Then
                        Select Case ATRVal(14)
                            Case &H9 : cardName = cardName & ": Mifare Mini."
                        End Select
                    End If
                End If

                'Call displayOut(6, 0, cardName)
            End If

        End If

        '4.2. Mifare DESFire card using ISO 14443 Part 4
        If CInt(ATRLen) = 11 Then
            RIDVal = ""
            For indx = 4 To 9
                RIDVal = RIDVal & Format(Hex(ATRVal(indx)))
            Next

            If RIDVal = "6757781280" Then
                'Call displayOut(6, 0, "Mifare DESFire")
                cardName = cardName & "Mifare DESFire"
            End If
        End If

        '4.3. Other cards using ISO 14443 Part 4
        If CInt(ATRLen) = 17 Then
            RIDVal = ""

            For indx = 4 To 15
                RIDVal = RIDVal & Format(Hex(RecvBuff(indx)), "00")
            Next

            If RIDVal = "50122345561253544E3381C3" Then
                cardName = cardName & "ST19XRC8E"
                'Call displayOut(6, 0, "ST19XRC8E")
            End If
        End If

        '4.4. other cards using ISO 14443 Type A or B
        If lATRStr = "3B8X800150" Then
            cardName = cardName & "ISO 14443B."
            'Call displayOut(6, 0, "ISO 14443B.")
        Else
            If sATRStr = "3B8X8001" Then
                cardName = cardName & "ISO 14443A"
                'Call displayOut(6, 0, "ISO 14443A")
            End If
        End If

        CurrentCardName = cardName
    End Sub

    Public Function read_uid() As String
        Dim retCode As Long

        ClearBuffers()

        SendBuff(0) = &HFF
        SendBuff(1) = &HCA
        SendBuff(2) = &H0
        SendBuff(3) = &H0
        SendBuff(4) = &H0

        SendLen = 5
        RecvLen = 2

        ioRequest.dwProtocol = Protocol
        ioRequest.cbPciLength = Len(ioRequest)
        RecvLen = 262
        'Issue SCardTransmit
        retCode = ModWinsCard.SCardTransmit(hCard, _
                             ioRequest, _
                             SendBuff(0), _
                             SendLen, _
                             ioRequest, _
                             RecvBuff(0), _
                             RecvLen)

        If retCode <> ModWinsCard.SCARD_S_SUCCESS Then
            'Call displayOut(1, retCode, "")
        End If

        Dim tmpStr As String = ""
        Dim indx As Integer

        'prints the command sent
        'For indx = 0 To SendLen - 1
        'tmpStr = tmpStr + Microsoft.VisualBasic.Right("00" & Hex(SendBuff(indx)), 2) + " "
        'Next

        'MsgBox(tmpStr)

        'Call displayOut(2, 0, tmpStr)
        'print the response recieved
        tmpStr = ""

        Dim uid As String = ""

        For indx = 0 To RecvLen - 1
            tmpStr = tmpStr + Microsoft.VisualBasic.Right("00" & Hex(RecvBuff(indx)), 2) + " "

            uid = uid + Microsoft.VisualBasic.Right("00" & Hex(RecvBuff(indx)), 2)
        Next

        If uid.Length >= 8 Then
            uid = uid.Substring(0, 8)
        End If

        Return uid
    End Function

    Private Sub ClearBuffers()
        Dim indx As Long

        For indx = 0 To 262
            RecvBuff(indx) = &H0
            SendBuff(indx) = &H0
        Next
    End Sub



End Class
