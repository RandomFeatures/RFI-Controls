Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports System.Resources

Public Class CheckBoxPlus : Inherits Control

    Public Enum eCheckState
        Checked = 0
        Unchecked = 1
        Indeterminate = 2
    End Enum

#Region "Private Properties"
    Private m_Checked As Boolean
    Private m_CheckState As eCheckState
    Private m_Text As String
#End Region

#Region "Public Properties"

    Public Property Checked() As Boolean
        Get
            Return m_Checked
        End Get
        Set(ByVal Value As Boolean)
            If m_Checked <> Value Then
                m_Checked = Value
                If Value Then
                    m_CheckState = eCheckState.Checked
                Else
                    m_CheckState = eCheckState.Unchecked
                End If
                Me.Invalidate()
                RaiseEvent OnCheckedChanged(Me)
            End If
        End Set
    End Property

    Public Property CheckState() As eCheckState
        Get
            Return m_CheckState
        End Get
        Set(ByVal Value As eCheckState)
            If (m_CheckState <> Value) Then
                m_CheckState = Value
                Select Case Value
                    Case eCheckState.Checked : m_Checked = True
                    Case eCheckState.Unchecked : m_Checked = False
                    Case eCheckState.Indeterminate : m_Checked = True
                End Select
                Me.Invalidate()
                RaiseEvent OnCheckStateChanged(Me)
            End If
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

#Region "EventHandler"
    Public Event OnCheckedChanged(ByVal Sender As System.Object)
    Public Event OnCheckStateChanged(ByVal Sender As System.Object)

#End Region

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        Text = "CheckBoxPlus"

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents imageList As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CheckBoxPlus))
        Me.imageList = New System.Windows.Forms.ImageList(Me.components)
        '
        'imageList
        '
        Me.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.imageList.ImageSize = New System.Drawing.Size(19, 14)
        Me.imageList.ImageStream = CType(resources.GetObject("imageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList.TransparentColor = System.Drawing.Color.Fuchsia
        '
        'CheckBoxPlue
        '
        Me.Name = "CheckBoxPlus"
        Me.Size = New System.Drawing.Size(104, 24)

    End Sub

#End Region

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim X As Integer = Me.ClientRectangle.X + 25
        'int y = this.ClientRectangle.Y;
        Dim iTop As Integer = (Height / 2) - 7
        Dim mypen As New Pen(Me.ForeColor)


        Select Case (m_CheckState)
            Case eCheckState.Checked : imageList.Draw(e.Graphics, 5, iTop, 0)
            Case eCheckState.Unchecked : imageList.Draw(e.Graphics, 5, iTop, 1)
            Case eCheckState.Indeterminate : imageList.Draw(e.Graphics, 5, iTop, 2)
        End Select
        e.Graphics.DrawString(Me.Text, Me.Font, New SolidBrush(Me.ForeColor), X, iTop)

        If Me.Focused() Then
            mypen.DashStyle = Drawing.Drawing2D.DashStyle.Dash
            e.Graphics.DrawRectangle(mypen, X - 1, 2, Width - X - 1, Height - 4)
        End If

        mypen.Dispose()
        MyBase.OnPaint(e) '//draw me first
    End Sub

    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        Me.Invalidate()
        MyBase.OnResize(e)

    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        If (m_Checked) Then
            Checked = False
        Else
            Checked = True

            MyBase.OnMouseDown(e)
        End If

    End Sub


    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (e.KeyChar = Chr(32)) Then

            If (m_Checked) Then
                Checked = False
            Else
                Checked = True
                MyBase.OnKeyPress(e)
            End If
        End If

    End Sub


    Private Sub CheckBoxPlus_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Enter
        Me.Invalidate()
    End Sub

    Private Sub CheckBoxPlus_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Leave
        Me.Invalidate()
    End Sub
End Class
