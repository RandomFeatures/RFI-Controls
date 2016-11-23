'***************************************************
'This control is free for you to use and distribute,
'as long as this header remains intact and unmodified.
'By using this control you take full responsibility for this
'controls operation. 
'***************************************************
Imports System.ComponentModel

<DefaultProperty("Text")> _
Public Class ComboPlus
    Inherits System.Windows.Forms.ComboBox
    Private fFocusBGColor As Color
    Private fFocusFontColor As Color
    Private fBGColor As Color
    Private fFontColor As Color
    Private fFlatStyle As Boolean
    Private strPrevText As String

    Public Property FlayStyle() As Boolean
        Get
            Return fFlatStyle
        End Get
        Set(ByVal Value As Boolean)
            fFlatStyle = Value
        End Set
    End Property

    Public Property FocusBGColor() As Color
        Get
            Return fFocusBGColor
        End Get
        Set(ByVal Value As Color)
            fFocusBGColor = Value
            Refresh()
        End Set
    End Property
    Public Property FocusFontColor() As Color
        Get
            Return fFocusFontColor
        End Get
        Set(ByVal Value As Color)
            fFocusFontColor = Value
            Refresh()
        End Set
    End Property


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        MyBase.Text = ""
        'This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub

    'UserControl1 overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub
#End Region

    Private m_LastValue As String = ""
    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim strSearch As String

        If Me.DropDownStyle = ComboBoxStyle.DropDown Then

            Select Case Asc(e.KeyChar)
                Case Keys.Escape
                    Text = ""
                    m_LastValue = ""
                    SelectedIndex = -1
                Case Keys.Back
                    If Text <> "" And m_LastValue <> "" Then
                        strSearch = m_LastValue.Substring(0, m_LastValue.Length - 1)
                    End If
                    If strSearch = "" Then
                        Text = ""
                        m_LastValue = ""
                        SelectedIndex = -1
                        e.Handled = True
                        Exit Sub
                    End If
                Case Else
                    If Text = "" Then
                        strSearch = e.KeyChar()
                    Else
                        strSearch = m_LastValue & e.KeyChar
                    End If

            End Select

            Dim pos As Integer = Me.FindString(strSearch)
            If pos <> -1 Then
                If pos = 0 Then
                    SelectedIndex = pos
                Else
                    Text = Items(pos)
                End If

                SelectionStart = 0
                SelectionLength = strSearch.Length
                m_LastValue = strSearch
            Else
                If m_LastValue <> "" Then
                    SelectedIndex = Items.IndexOf(m_LastValue)
                    Text = m_LastValue
                    SelectionStart = 0
                    SelectionLength = m_LastValue.Length
                Else
                    SelectedIndex = 0
                End If

            End If

            e.Handled = True
        Else
            e.Handled = False
        End If

    End Sub

    <DefaultValue("")> _
    Public Overrides Property Text() As String
        Get
            Return MyBase.Text
        End Get

        Set(ByVal Value As String)
            Dim i As Integer

            i = MyBase.FindString(Value)

            If i > 0 Then
                MyBase.SelectedItem = MyBase.Items(i)
            End If
        End Set
    End Property

    Protected Overrides Sub OnGotFocus(ByVal e As System.EventArgs)
        Me.BackColor = fFocusBGColor
        Me.ForeColor = fFocusFontColor
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnLostFocus(ByVal e As System.EventArgs)
        Me.BackColor = fBGColor
        Me.ForeColor = fFontColor
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnCreateControl()
        fBGColor = Me.BackColor
        fFontColor = Me.ForeColor
    End Sub

    Protected Overrides Sub WndProc(ByRef m As Message)
        MyBase.WndProc(m)
        If fFlatStyle Then

            Select Case m.Msg
                Case &HF
                    Dim g As Graphics = Me.CreateGraphics
                    Dim p1 As Pen = New Pen(Color.Black, 2)
                    Dim p2 As Pen = New Pen(Me.BackColor, 2)

                    g.DrawRectangle(p1, Me.ClientRectangle)
                    g.DrawLine(p2, 1, Me.Height - 2, Me.Width - 1, Me.Height - 2)
                    g.DrawLine(p2, 1, 2, Me.Width - 1, 2)
                    g.DrawLine(p2, 2, 2, 2, Me.Height - 2)
                    g.DrawLine(p2, Me.Width - 2, 1, Me.Width - 2, Me.Height - 1)
                    p1.Dispose()
                    p2.Dispose()
                Case Else
                    Exit Select
            End Select
        End If

    End Sub





End Class


