'***************************************************
'This control is free for you to use and distribute,
'as long as this header remains intact and unmodified.
'By using this control you take full responsibility for this
'controls operation. 
'***************************************************
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class DateTimePickerPlus
    Inherits System.Windows.Forms.DateTimePicker
    Private fFocusBGColor As Color
    Private fFocusFontColor As Color
    Private fBGColor As Color
    Private fFontColor As Color
    Private fFlatStyle As Boolean

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

#Region " Component Designer generated code "

    Public Sub New(ByVal Container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        Container.Add(Me)
    End Sub

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Component overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

#End Region

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
        Dim tte As Object
        tte = Me.GetContainerControl

        If fFlatStyle Then
            Select Case m.Msg
                Case &HF
                    Dim g As Graphics = tte.CreateGraphics
                    Dim p1 As Pen = New Pen(Color.Black, 2)
                    Dim p2 As Pen = New Pen(Me.BackColor, 2)
                    g.DrawRectangle(p1, tte.ClientRectangle)
                    g.DrawLine(p2, 1, tte.Height - 2, tte.Width - 1, tte.Height - 2)
                    g.DrawLine(p2, 1, 2, tte.Width - 1, 2)
                    g.DrawLine(p2, 2, 2, 2, tte.Height - 2)
                    g.DrawLine(p2, tte.Width - 2, 1, tte.Width - 2, tte.Height - 1)
                Case Else
                    Exit Select
            End Select
        End If

    End Sub


End Class
