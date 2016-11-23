'***************************************************
'This control is free for you to use and distribute,
'as long as this header remains intact and unmodified.
'By using this control you take full responsibility for this
'controls operation. 
'***************************************************

Imports System.Windows.Forms
Imports System.Windows.Forms.Label
Imports System.Drawing
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System

Public Enum enumTextType
    Normal = 0
    AlphaNumeric = 1
    NumbersOnly = 2
    Currency = 3
End Enum

Public Class TextPlus
    Inherits System.Windows.Forms.TextBox
#Region " Private Variables "
    Private selTextType As enumTextType = enumTextType.AlphaNumeric
    'Private fNumbersOnly As Boolean
    Private fTabOnEnter As Boolean
    'Private PreviousText As String
    Private fFocusBGColor As Color
    Private fFocusFontColor As Color
    Private fBGColor As Color
    Private fFontColor As Color

    Enum eLabelEffect
        le3dLeft = 0
        le3dRight = 1
        leFlat = 2
        leFlying = 3
    End Enum

    Enum eLabelPosition
        lpTop = 0
        lbLeft = 1
    End Enum

#End Region

#Region " Public Properties "

    Public Property TextType() As enumTextType
        Get
            TextType = selTextType
        End Get
        Set(ByVal Value As enumTextType)
            selTextType = Value
        End Set
    End Property

    Public Property TabOnEnter() As Boolean
        Get
            Return fTabOnEnter
        End Get
        Set(ByVal Value As Boolean)
            fTabOnEnter = Value
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

#End Region

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    'UserControl overrides dispose to clean up the component list.
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

    End Sub

#End Region

    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        MyBase.OnKeyPress(e) 'iherited
        If fTabOnEnter Then
            If e.KeyChar = Chr(13) Then
                Me.FindForm().SelectNextControl(Me, True, True, True, True)
            End If
        End If
        'If fNumbersOnly Then
        '    PreviousText = Text
        'End If

        e.Handled = True
        Select Case TextType
            Case enumTextType.AlphaNumeric
                e.Handled = Not (IsNumeric(e.KeyChar) Or (e.KeyChar Like "[A-Z]" Or e.KeyChar Like "[a-z]" Or e.KeyChar = " "))
            Case enumTextType.Currency
                e.Handled = Not (IsNumeric(e.KeyChar) Or (e.KeyChar = "." And Not CBool(InStr(Text, "."))))
            Case enumTextType.NumbersOnly
                e.Handled = Not IsNumeric(e.KeyChar)
            Case Else : e.Handled = False
        End Select
        If e.KeyChar = Chr(&H8) Then e.Handled = False
        If e.KeyChar.IsControl(e.KeyChar) Then e.Handled = False
    End Sub


    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl() 'inherited

        'If fNumbersOnly Then
        '    PreviousText = ""
        'End If

        ' Create the label and set it default values
        fBGColor = Me.BackColor
        fFontColor = Me.ForeColor
    End Sub



    Protected Overrides Sub OnGotFocus(ByVal e As System.EventArgs)
        Me.BackColor = fFocusBGColor
        Me.ForeColor = fFocusFontColor
    End Sub


    Protected Overrides Sub OnLostFocus(ByVal e As System.EventArgs)
        Me.BackColor = fBGColor
        Me.ForeColor = fFontColor
    End Sub

    Private Sub TextPlus_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Enter
        Me.SelectAll()
        If TextType = enumTextType.Currency Then
            If Me.Text = "0.00" Then
                Me.Text = ""
            End If
        End If
        If TextType = enumTextType.NumbersOnly Then
            If Me.Text = "0" Then
                Me.Text = ""
            End If
        End If

    End Sub

    Private Sub TextPlus_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
        Dim val As Double
        'If Me.Text = "" Then Exit Sub
        If TextType = enumTextType.Currency Then
            If Me.Text <> "" Then
                val = Double.Parse(Me.Text)
                Me.Text = val.ToString("##0.00")
            Else
                Me.Text = "0.00"
            End If
        End If
        If TextType = enumTextType.NumbersOnly Then
            If Me.Text = "" Then
                Me.Text = "0"
            End If
        End If
    End Sub
End Class
