Public Module strFunctions

    Private Sub strDelete(ByRef s As String, ByVal index As Integer, ByVal count As Integer)
        s = s.Remove(index, count)
    End Sub

    Private Function strToken(ByRef s As String, ByVal seperator As Char) As String
        Dim I As Integer
        Dim strTmp As String
        I = s.IndexOf(seperator)
        If I > 0 Then

            strTmp = s.Substring(I, 1)
            s = s.Remove(I, 1)
            Return strTmp
        Else
            s = ""
            Return s
        End If


    End Function

    Public Function strTokenCount(ByVal S As String, ByVal Seperator As Char) As Integer
        Dim Result As Integer
        Dim tmpStr = S

        Result = 0
        While tmpStr <> ""
            strToken(tmpStr, Seperator)
            Inc(Result)
        End While
        Return Result

    End Function

    Public Function strTokenAt(ByVal S As String, ByVal Seperator As Char, ByVal At As Integer) As String
        Dim i, j As Integer
        Dim Result As String
        j = 0
        i = 0
        While (i <= At) And (j < S.Length)
            If S.Chars(j).Equals(Seperator) Then
                Inc(i)
            ElseIf i = At Then
                Result = Result & S.Chars(j)
            End If

            Inc(j)
        End While
        Return Result
    End Function

    Public Sub Inc(ByRef i As Integer, Optional ByVal n As Integer = 1)
        i += n
    End Sub

    Public Sub Dec(ByRef i As Integer, Optional ByVal n As Integer = 1)
        i -= n
    End Sub
End Module
