'***************************************************
'This control is free for you to use and distribute,
'as long as this header remains intact and unmodified.
'By using this control you take full responsibility for this
'controls operation. 
'***************************************************

Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System


Public Class LabelPlus : Inherits Control
    ' Inherits System.Windows.Forms.Control
#Region " Private Propterties "
    'Private fTextColor As Color
    Private fShadowColor As Color
    Private fGradientFillColor As Color
    Private fUseGradientFill As Boolean
    Private fGradientFillStyle As LinearGradientMode
    Private fLabelEffect As eLabelEffect
    Private oShadowColor As Color
    Private oForeColor As Color
    Private fDrawBorder As Boolean

    Enum eLabelEffect
        le3dLeft = 0
        le3dRight = 1
        leFlat = 2
        leFlying = 3
        leRaised = 4
        leLowered = 5
        leEmbossed = 6
    End Enum
#End Region

#Region " Public Propterties "

    'Public Property TextColor() As Color
    '    Get
    '        Return fTextColor
    '    End Get
    '    Set(ByVal Value As Color)
    '        fTextColor = Value
    '        Refresh()
    '    End Set
    'End Property
    Public Property ShadowColor() As Color
        Get
            Return fShadowColor
        End Get
        Set(ByVal Value As Color)
            fShadowColor = Value
            Refresh()
        End Set
    End Property
    Public Property GradientFillColor() As Color
        Get
            Return fGradientFillColor
        End Get
        Set(ByVal Value As Color)
            fGradientFillColor = Value
            'fGradientFillColor = Value
            Refresh()
        End Set
    End Property
    Public Property UseGradientFill() As Boolean
        Get
            Return fUseGradientFill
        End Get
        Set(ByVal Value As Boolean)
            fUseGradientFill = Value
            Refresh()
        End Set
    End Property

    Public Property DrawBorder() As Boolean
        Get
            Return fDrawBorder
        End Get
        Set(ByVal Value As Boolean)
            fDrawBorder = Value
            Refresh()
        End Set
    End Property

    Public Property GradientFillStyle() As LinearGradientMode
        Get
            Return fGradientFillStyle
        End Get
        Set(ByVal Value As LinearGradientMode)
            fGradientFillStyle = Value
            Refresh()
        End Set
    End Property
    Public Property LabelEffect() As eLabelEffect
        Get
            Return fLabelEffect
        End Get
        Set(ByVal Value As eLabelEffect)
            fLabelEffect = Value
            Refresh()
        End Set
    End Property

    Public Overrides Property Text() As String
        Get
            Text = MyBase.Text
        End Get
        Set(ByVal Value As String)
            MyBase.Text = Value
            Refresh()
        End Set
    End Property

#End Region


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Text = "LabelPlus"
        ForeColor = Color.White
        fLabelEffect = eLabelEffect.leFlat
        fUseGradientFill = True
        fGradientFillColor = Color.DarkGray
        fShadowColor = Color.DarkSlateGray
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
        'LabelPlus
        '
        Me.Size = New System.Drawing.Size(100, 23)

    End Sub

#End Region

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        ' Dim MyGDISurface As Graphics
        ' MyGDISurface = Me.CreateGraphics
        Dim x As Single = ClientRectangle.X
        Dim y As Single = ClientRectangle.Y

        MyBase.OnPaint(e)
        If fUseGradientFill Then
            e.Graphics.FillRectangle(New LinearGradientBrush(ClientRectangle, fGradientFillColor, BackColor, fGradientFillStyle), 0, 0, Width, Height)
        End If

        If fDrawBorder Then
            Dim p1 As Pen = New Pen(Color.Black, 2)
            e.Graphics.DrawRectangle(p1, Me.ClientRectangle)
            p1.Dispose()
        End If

        Select Case fLabelEffect
            Case eLabelEffect.le3dLeft
                e.Graphics.DrawString(Text, Font, New SolidBrush(fShadowColor), x - 1, y + 1)
                e.Graphics.DrawString(Text, Font, New SolidBrush(ForeColor), x, y)
            Case eLabelEffect.leFlat
                e.Graphics.DrawString(Text, Font, New SolidBrush(ForeColor), x, y)
            Case eLabelEffect.leFlying
                e.Graphics.DrawString(Text, Font, New SolidBrush(fShadowColor), x - 1, y + 2)
                e.Graphics.DrawString(Text, Font, New SolidBrush(ForeColor), x + 1, y)
            Case eLabelEffect.le3dRight
                e.Graphics.DrawString(Text, Font, New SolidBrush(fShadowColor), x + 1, y + 1)
                e.Graphics.DrawString(Text, Font, New SolidBrush(ForeColor), x, y)
            Case eLabelEffect.leLowered
                'canvas.font.color:=upcol;
                e.Graphics.DrawString(Text, Font, New SolidBrush(fShadowColor), x + 1, y)
                e.Graphics.DrawString(Text, Font, New SolidBrush(fShadowColor), x, y + 1)
                'canvas.font.color:=downcol;
                e.Graphics.DrawString(Text, Font, New SolidBrush(Color.Black), x - 1, y)
                e.Graphics.DrawString(Text, Font, New SolidBrush(Color.Black), x, y - 1)
                'canvas.font.color:=useclr;
                e.Graphics.DrawString(Text, Font, New SolidBrush(ForeColor), x, y)
            Case eLabelEffect.leRaised
                'canvas.font.color:=upcol;
                e.Graphics.DrawString(Text, Font, New SolidBrush(fShadowColor), x - 1, y)
                e.Graphics.DrawString(Text, Font, New SolidBrush(fShadowColor), x, y - 1)
                'canvas.font.color:=downcol;
                e.Graphics.DrawString(Text, Font, New SolidBrush(Color.Black), x + 1, y)
                e.Graphics.DrawString(Text, Font, New SolidBrush(Color.Black), x, y + 1)
                'canvas.font.color:=useclr;
                e.Graphics.DrawString(Text, Font, New SolidBrush(ForeColor), x, y)
            Case eLabelEffect.leEmbossed
                'canvas.font.color:=upcol;
                e.Graphics.DrawString(Text, Font, New SolidBrush(fShadowColor), x - 1, y)
                e.Graphics.DrawString(Text, Font, New SolidBrush(fShadowColor), x + 1, y)
                e.Graphics.DrawString(Text, Font, New SolidBrush(fShadowColor), x, y - 1)
                e.Graphics.DrawString(Text, Font, New SolidBrush(fShadowColor), x, y + 1)
                'canvas.font.color:=useclr;
                e.Graphics.DrawString(Text, Font, New SolidBrush(ForeColor), x, y)
        End Select

    End Sub

    Private Sub LabelPlus_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Refresh()
    End Sub

    Public Sub FocusHighLight()
        ForeColor = oForeColor
        fShadowColor = oShadowColor
    End Sub

    Public Sub FocusDim()
        ForeColor = oShadowColor
        fShadowColor = oForeColor
    End Sub

    Protected Overrides Sub OnCreateControl()
        oShadowColor = fShadowColor
        oForeColor = ForeColor
    End Sub
End Class
