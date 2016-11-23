'***************************************************
'This control is free for you to use and distribute,
'as long as this header remains intact and unmodified.
'By using this control you take full responsibility for this
'controls operation. 
'***************************************************
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System

Public Class Busy
    Inherits System.Windows.Forms.UserControl
    Private fPlay As Boolean
    Private fRect As Rectangle
    Private fCleanUpRect As Rectangle
    Private MyGDISurface As Graphics
    Private pos As Integer
    Private iState As Boolean
    Private fBarWidth As Integer


    Public Property BarWidth() As Integer
        Get
            Return fBarWidth
        End Get
        Set(ByVal Value As Integer)
            fBarWidth = Value
            fRect.Width = fBarWidth
        End Set
    End Property
    Public Property Play() As Boolean
        Get
            Return fPlay
        End Get
        Set(ByVal Value As Boolean)
            fPlay = Value
            ftimer.Enabled = Value
            fRect.Width = fBarWidth
        End Set
    End Property

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        fRect = New Rectangle(0, 0, Width, Height)
        fCleanUpRect = New Rectangle(0, 0, 1, Height)
        MyGDISurface = Me.CreateGraphics
        'fBrushLeft = New LinearGradientBrush(fRect, ForeColor, BackColor, LinearGradientMode.Horizontal)
        'fBrushRight = New LinearGradientBrush(fRect, ForeColor, BackColor, LinearGradientMode.Horizontal)
        'fBrushRight.RotateTransform(180)
        pos = 0
        iState = True
        'ForeColor = BackColor
        'BackColor = Color.Navy
        ForeColor = Color.Navy

        fBarWidth = (Width \ 3)

    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        ftimer.Enabled = False
        fRect = Nothing
        MyGDISurface = Nothing
        fCleanUpRect = Nothing
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents ftimer As System.Timers.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ftimer = New System.Timers.Timer()
        CType(Me.ftimer, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'ftimer
        '
        Me.ftimer.Interval = 10
        Me.ftimer.SynchronizingObject = Me
        '
        'Busy
        '
        Me.Name = "Busy"
        Me.Size = New System.Drawing.Size(130, 10)
        CType(Me.ftimer, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

    Private Sub ftimer_Elapsed(ByVal sender As System.Object, ByVal e As System.Timers.ElapsedEventArgs) Handles ftimer.Elapsed

        Dim MyBrush As LinearGradientBrush


        If iState Then
            Inc(pos)
            fCleanUpRect.X = pos

            MyBrush = New LinearGradientBrush(fRect, BackColor, ForeColor, LinearGradientMode.Horizontal)
            'MyBrush.SetSigmaBellShape(0.95)

            If pos >= Width Then
                iState = False
            End If
        Else
            Dec(pos)
            fCleanUpRect.X = pos + fBarWidth

            MyBrush = New LinearGradientBrush(fRect, ForeColor, BackColor, LinearGradientMode.Horizontal)
            'MyBrush.SetSigmaBellShape(0.95)

            If pos < (0 - fBarWidth) Then
                fCleanUpRect.X = 0
                iState = True
            End If
        End If


        fRect.X = pos

        MyGDISurface.FillRectangle(MyBrush, fRect)
        MyGDISurface.FillRectangle(New SolidBrush(BackColor), fCleanUpRect)
        MyBrush = Nothing

    End Sub

    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        fRect.Height = Height
        fCleanUpRect.Height = Height
        MyGDISurface = Nothing
        MyGDISurface = Me.CreateGraphics
    End Sub

    Protected Overrides Sub OnCreateControl()
        ' MyGDISurface.FillRectangle(New SolidBrush(ForeColor), ClientRectangle)
    End Sub
End Class
