Public Class FixedString
    Private m_FixedLen As Integer
    Private m_Value As String

    Public Property Length() As Integer
        Get
            Return m_FixedLen
        End Get
        Set(ByVal Value As Integer)
            m_FixedLen = Value
        End Set
    End Property

    Public Property StringValue() As String
        Get
            Return m_Value.PadRight(m_FixedLen, " ")
        End Get
        Set(ByVal Value As String)
            If Value.Length > m_FixedLen Then
                m_Value = Value.Substring(0, m_FixedLen)
            End If
            m_Value = Value
        End Set
    End Property

    Public Sub New(ByVal Len As Integer)
        m_FixedLen = Len
    End Sub


End Class
