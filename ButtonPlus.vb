Imports System.ComponentModel

Public Class ButtonPlus
    Inherits System.Windows.Forms.Button

    Private m_HightlightColor As Color
    Private MyParent As Control
    Private OldForeColor As Color

    Public Property HightLightColor() As Color
        Get
            Return m_HightlightColor
        End Get
        Set(ByVal Value As Color)
            m_HightlightColor = Value
        End Set
    End Property


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        m_HightlightColor = Color.BlueViolet
        OldForeColor = Me.ForeColor
        Me.FlatStyle = FlatStyle.Flat
        Me.TabStop = False


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
        components = New System.ComponentModel.Container()
    End Sub

#End Region


    Private Sub ButtonPlus_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.MouseEnter
        Me.ForeColor = m_HightlightColor
        Me.BackColor = Color.GhostWhite
        Refresh()
    End Sub


    Private Sub ButtonPlus_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.MouseLeave
        If Not MyParent Is Nothing Then
            Me.BackColor = MyParent.BackColor
            If Me.Text <> "" Then
                Me.ForeColor = OldForeColor
            Else
                Me.ForeColor = MyParent.BackColor
            End If
            Refresh()
        End If
    End Sub

    Private Sub ButtonPlus_ParentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.ParentChanged
        If Not Me Is Nothing Then
            MyParent = MyBase.GetContainerControl
            If Not MyParent Is Nothing Then
                Me.BackColor = MyParent.BackColor
                Refresh()
            End If
        End If
    End Sub
End Class
