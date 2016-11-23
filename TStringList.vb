Class TStringItem
    Private mName As String
    Private mValue As String
    Private mStringItem As String
    Private mObject As String

    Public Property Name()
        Get
            Return mName
        End Get
        Set(ByVal Value)
            mName = Value
            mStringItem = Value
        End Set
    End Property

    Public Property Value()
        Get
            Return mValue
        End Get
        Set(ByVal Value)
            mValue = Value
            mStringItem = mName + "=" + Value
        End Set
    End Property

    Public Property StringItem()
        Get
            Return mStringItem
        End Get
        Set(ByVal Value) ' takes a name=value pair
            mStringItem = Value
            Dim splitLine(2) As String
            splitLine = mStringItem.Split("=")
            mName = splitLine(0)
            If splitLine.Length = 2 Then
                mValue = splitLine(1)
            Else
                mValue = ""
            End If

        End Set
    End Property

End Class

Public Class TStringList
    Inherits System.Collections.CollectionBase

    Default Property Item(ByVal index As Integer) As String
        Get 'just the name at this indx
            If index < InnerList.Count And index > -1 Then
                Return CType(InnerList.Item(index), TStringItem).Name
            Else
                Return ""
            End If
        End Get
        Set(ByVal Value As String)
            CType(InnerList.Item(index), TStringItem).Name = Value
        End Set
    End Property

    Public Property Text() As String
        Get
            Dim iLoop As Integer
            Dim ret As String
            'combine all the items into a line
            For iLoop = 0 To Count - 1
                ret += CType(InnerList.Item(iLoop), TStringItem).StringItem + vbCr
            Next
            Return ret
        End Get
        Set(ByVal Value As String)
            Dim splitLine() As String
            Dim iLoop As Integer
            'break it into lines
            splitLine = Value.Split(vbCr)
            'add each line as a new item
            For iLoop = 0 To splitLine.Length - 1
                Add(splitLine(iLoop))
            Next
        End Set
    End Property

    Sub Add(ByVal Name As String)
        Dim StringItem As New TStringItem()
        If Name Is Nothing Then
            Exit Sub
        End If
        StringItem.StringItem = Name
        InnerList.Add(StringItem)
    End Sub
    Sub Add(ByVal Name As String, ByVal Value As String)
        Dim StringItem As New TStringItem()
        If Name Is Nothing Then
            Exit Sub
        End If
        If Value Is Nothing Then
            StringItem.StringItem = Name
        Else
            StringItem.StringItem = Name + "=" + Value
        End If
        InnerList.Add(StringItem)
    End Sub

    Function GetValue(ByVal Name As String)
        Dim ret As Integer
        ret = IndexOf(Name)
        If ret > -1 Then
            Return CType(InnerList.Item(ret), TStringItem).Value
        Else
            Return ""
        End If
    End Function

    Function GetValue(ByVal Indx As Integer)
        If Indx < Count And Indx > -1 Then
            Return CType(InnerList.Item(Indx), TStringItem).Value
        Else
            Return ""
        End If
    End Function


    Function GetName(ByVal Indx As Integer)
        If Indx < Count And Indx > -1 Then
            Return CType(InnerList.Item(Indx), TStringItem).Name
        Else
            Return ""
        End If
    End Function

    Function GetNameByValue(ByVal Value As String)
        Dim iLoop As Integer
        Dim ret As String = ""
        For iLoop = 0 To Count - 1
            If String.Compare(CType(InnerList.Item(iLoop), TStringItem).Value.Trim, Value.Trim, True) = 0 Then
                ret = CType(InnerList.Item(iLoop), TStringItem).Name
                Exit For
            End If
        Next
        Return ret
    End Function

    Function IndexOf(ByVal Name As String)
        Dim iLoop As Integer
        Dim ret As Integer = -1
        For iLoop = 0 To Count - 1
            If String.Compare(CType(InnerList.Item(iLoop), TStringItem).Name.Trim, Name.Trim, True) = 0 Then
                ret = iLoop
                Exit For
            End If
        Next
        Return ret
    End Function

    Sub ChangeValue(ByVal Name As String, ByVal Value As String)
        Dim ret As Integer
        ret = IndexOf(Name)
        If ret > -1 Then
            CType(InnerList.Item(ret), TStringItem).Value = Value.Trim
        End If
    End Sub

    Sub DeleteItem(ByVal Name As String)
        Dim ret As Integer
        ret = IndexOf(Name)
        If ret > -1 Then
            Innerlist.RemoveAt(ret)
        End If
    End Sub

    Sub DeleteItem(ByVal Indx As Integer)
        Innerlist.RemoveAt(Indx)
    End Sub



End Class
