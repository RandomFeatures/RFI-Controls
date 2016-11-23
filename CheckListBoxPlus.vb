Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.Reflection
Imports System.Windows.Forms
Imports System.IO

Public Class CheckListBoxPlus
    Inherits System.Windows.Forms.ListBox
    Private fFirstBrush As Brush
    Private fSecondBrush As Brush
    Private fHighlightBrush As Brush
    Private fFirstColor As Color
    Private fSecondColor As Color
    Private fHighlightColor As Color

    Public Property FirstColor() As Color
        Get
            Return fFirstColor
        End Get
        Set(ByVal Value As Color)
            fFirstColor = Value
            If Not fFirstBrush Is Nothing Then
                fFirstBrush.Dispose()
            End If
            fFirstBrush = New SolidBrush(Value)
        End Set
    End Property

    Public Property SecondColor() As Color
        Get
            Return fSecondColor
        End Get
        Set(ByVal Value As Color)
            fSecondColor = Value
            If Not fSecondBrush Is Nothing Then
                fSecondBrush.Dispose()
            End If
            fSecondBrush = New SolidBrush(Value)
        End Set
    End Property

    Public Property HighlightColor() As Color
        Get
            Return fHighlightColor
        End Get
        Set(ByVal Value As Color)
            fHighlightColor = Value
            If Not fHighlightBrush Is Nothing Then
                fHighlightBrush.Dispose()
            End If
            fHighlightBrush = New SolidBrush(Value)
        End Set
    End Property


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        Dim r As Rectangle
        r = New Rectangle(0, 0, MyBase.Width, 10)
        FirstColor = Color.WhiteSmoke
        SecondColor = Color.Lavender
        HighlightColor = Color.RoyalBlue
        MyBase.DrawMode = DrawMode.OwnerDrawFixed

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        fFirstBrush.Dispose()
        fSecondBrush.Dispose()
        fHighlightBrush.Dispose()
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents imageList As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CheckListBoxPlus))
        Me.imageList = New System.Windows.Forms.ImageList(Me.components)
        '
        'imageList
        '
        Me.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.imageList.ImageSize = New System.Drawing.Size(19, 14)
        Me.imageList.ImageStream = CType(resources.GetObject("imageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList.TransparentColor = System.Drawing.Color.Fuchsia

    End Sub

#End Region



    Protected Overrides Sub OnDrawItem(ByVal e As System.Windows.Forms.DrawItemEventArgs)
        Dim brush As Brush
        Dim MyBrush As Brush
        Dim Itemselected As Boolean
        Dim ItemText As String
        Dim MyColor As Color
        Dim MyImage As Image


        ' The following method should generally be called beforedrawing.
        ' It is actually superfluous here, since the subsequent  Drawing()
        ' will completely cover the area of interest.
        e.DrawBackground()

        'The system provides the context
        'into which the owner custom-draws the required graphics.
        'The context into which to draw is e.graphics.
        'The index of the item to be painted is e.Index.
        'The painting should be done into the area described by e.Bounds.
        If Items.Count > 0 Then

            If e.Index Mod 2 = 0 Then
                brush = fFirstBrush
            Else
                brush = fSecondBrush
            End If

            e.Graphics.FillRectangle(brush, e.Bounds)
            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                Itemselected = True
                MyBrush = Brushes.White
                brush = fHighlightBrush
                e.Graphics.FillRectangle(brush, e.Bounds)
            Else
                Itemselected = False
                MyBrush = Brushes.MidnightBlue
            End If
            MyImage = Nothing

            If MyBase.Items.Item(e.Index) Is Nothing Then
                MyImage = imageList.Images.Item(1)
            Else
                If CType(MyBase.Items.Item(e.Index), CheckItem).Value = True Then
                    MyImage = imageList.Images.Item(0)
                Else
                    MyImage = imageList.Images.Item(1)
                End If
            End If

            ItemText = "   " & CType(MyBase.Items.Item(e.Index), CheckItem).Desc

            e.Graphics.DrawImage(MyImage, e.Bounds.X, e.Bounds.Y)
            e.Graphics.DrawString(ItemText, Me.Font, MyBrush, e.Bounds.X, e.Bounds.Y)

            e.DrawFocusRectangle()
            MyBrush = Nothing
        End If

    End Sub

    Public Sub Add(ByVal Name As String, ByVal desc As String, ByVal value As Boolean)
        'fCheckList.Add(Name, desc, value)
        Dim fCheckItem As New CheckItem
        If Name Is Nothing Then
            Exit Sub
        End If
        If desc Is Nothing Then
            fCheckItem.Name = Name
        Else
            fCheckItem.Name = Name
            fCheckItem.Desc = desc
        End If
        fCheckItem.Value = value
        MyBase.Items.Add(fCheckItem)

    End Sub

    Private Sub CheckListBoxPlus_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        If Not MyBase.Items.Item(MyBase.SelectedIndex) Is Nothing Then
            CType(MyBase.Items.Item(MyBase.SelectedIndex), CheckItem).Value = Not (CType(MyBase.Items.Item(MyBase.SelectedIndex), CheckItem).Value)
        End If
        If MyBase.SelectedIndex < MyBase.Items.Count - 1 Then
            MyBase.SelectedIndex += 1
            MyBase.SelectedIndex -= 1
        Else
            MyBase.SelectedIndex -= 1
            MyBase.SelectedIndex += 1
        End If
    End Sub

    Private Sub CheckListBoxPlus_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
        '        MyBase.SelectedIndex -= 1
    End Sub

End Class

Public Class CheckItem
    Private mName As String
    Private mDesc As String
    Private mValue As Boolean
    Public Property Name() As String
        Get
            Return mName
        End Get
        Set(ByVal Value As String)
            mName = Value
        End Set
    End Property
    Public Property Desc() As String
        Get
            Return mDesc
        End Get
        Set(ByVal Value As String)
            mDesc = Value
        End Set
    End Property
    Public Property Value() As Boolean
        Get
            Return mValue
        End Get
        Set(ByVal Value As Boolean)
            mValue = Value
        End Set
    End Property
End Class

