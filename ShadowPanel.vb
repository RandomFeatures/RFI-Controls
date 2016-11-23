'***************************************************
'This control is free for you to use and distribute,
'as long as this header remains intact and unmodified.
'By using this control you take full responsibility for this
'controls operation. 
'***************************************************
Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel

Public Class ShadowPanel
    Inherits System.Windows.Forms.Panel
    Private fShadowWidth As Integer
    Private fShadowColor As Color

    Public Property ShadowWidth() As Integer
        Get
            Return fShadowWidth
        End Get
        Set(ByVal Value As Integer)
            fShadowWidth = Value
            Refresh()
        End Set
    End Property

    Public Property ShadowColor() As Color
        Get
            Return fShadowColor

        End Get
        Set(ByVal Value As Color)
            fShadowColor = Value
            Refresh()
        End Set
    End Property
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        fShadowColor = Color.DarkGray

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
        '
        'ShadowPanel
        '
        Me.Size = New System.Drawing.Size(240, 152)

    End Sub

#End Region

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        Dim x As Single = ClientRectangle.X
        Dim y As Single = ClientRectangle.Y
        Dim MyShadowControl As Control
        Dim iLoop As Integer
        Dim iLoop2 As Integer
        Dim x1 As Integer
        Dim y1 As Integer
        Dim x2 As Integer
        Dim y2 As Integer
        Dim LocalPen As New Pen(fShadowColor, 3)


        For iLoop = 0 To Me.Controls.Count - 1
            MyShadowControl = Me.Controls.Item(iLoop)
            'Not everything looks good with a shadow
            'skip the ones that the user indicated too
            If (MyShadowControl.Tag = 2142) Or _
               (Not (TypeOf MyShadowControl Is Label) And _
               Not (TypeOf MyShadowControl Is LinkLabel) And _
               Not (TypeOf MyShadowControl Is CheckBox) And _
               Not (TypeOf MyShadowControl Is Button) And _
               Not (TypeOf MyShadowControl Is TabControl) And _
               Not (TypeOf MyShadowControl Is HScrollBar) And _
               Not (TypeOf MyShadowControl Is VScrollBar) And _
               Not (TypeOf MyShadowControl Is Splitter) And _
               Not (TypeOf MyShadowControl Is TrackBar) And _
               Not (TypeOf MyShadowControl Is ProgressBar) And _
               Not (TypeOf MyShadowControl Is ToolBar) And _
               Not (TypeOf MyShadowControl Is StatusBar) And _
               Not (TypeOf MyShadowControl Is RadioButton) And _
               Not (TypeOf MyShadowControl Is LabelPlus) And _
               MyShadowControl.Tag <> 2412) Then

                'Get the starting pos
                x1 = MyShadowControl.Left + 1
                x2 = x1 + MyShadowControl.Width
                y1 = (MyShadowControl.Top + MyShadowControl.Height)
                y2 = y1
                'Bottom line
                For iLoop2 = 0 To fShadowWidth - 1
                    e.Graphics.DrawLine(LocalPen, x1, y1 + iLoop2, x2, y2 + iLoop2)
                Next

                'Get the starting pos
                x1 = MyShadowControl.Left + MyShadowControl.Width
                x2 = x1
                y1 = MyShadowControl.Top + 1
                y2 = y1 + MyShadowControl.Height
                'side line
                For iLoop2 = 0 To fShadowWidth - 1
                    e.Graphics.DrawLine(LocalPen, x1 + iLoop2, y1, x2 + iLoop2, y2 + iLoop2 + 1)
                Next
                MyShadowControl = Nothing
            End If
        Next
        LocalPen.Dispose()

    End Sub

    Protected Overrides Sub OnCreateControl()
        fShadowWidth = 1
    End Sub
End Class
