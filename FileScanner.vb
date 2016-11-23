'***************************************************
'This control is free for you to use and distribute,
'as long as this header remains intact and unmodified.
'By using this control you take full responsibility for this
'controls operation. 
'***************************************************

Imports System.IO

Public Class FileScanner
    Inherits System.ComponentModel.Component
    Private fFileExt As String
    Private fDir As String

    Public Property FileExt() As String 'what file time to look for
        Get
            Return fFileExt
        End Get
        Set(ByVal Value As String)
            fFileExt = Value
        End Set
    End Property
    Public Property TheDir() As String
        Get
            Return fDir
        End Get
        Set(ByVal Value As String)
            fDir = Value
        End Set
    End Property
    'Call this when a file matching the ext in found
    Public Event FoundAFile(ByVal FileName As String)

#Region " Component Designer generated code "

    Public Sub New(ByVal Container As System.ComponentModel.IContainer)
        MyClass.New()
        fFileExt = "*"  'set the default
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

    Public Sub ProcessDirectory()
        If (fDir <> "") And Directory.Exists(fDir) Then
            ProcessTheDirectory(fDir)
        End If

    End Sub

    Public Sub ProcessDirectory(ByVal cDir As String)
        If (cDir <> "") And Directory.Exists(cDir) Then
            ProcessTheDirectory(cDir)
        End If
    End Sub

    Public Sub ProcessDirectory(ByVal cDir As String, ByVal ext As String)
        If (cDir <> "") And (ext <> "") And Directory.Exists(cDir) Then
            fFileExt = ext
            ProcessTheDirectory(cDir)
        End If
    End Sub

    Private Sub ProcessTheDirectory(ByVal cDir As String)
        Dim FileName As String
        Try
            If Microsoft.VisualBasic.Right(cDir, 1) <> "\" Then
                cDir = cDir & "\"
            End If

            FileName = Dir(cDir & "*." & fFileExt)
            Do While FileName <> ""
                RaiseEvent FoundAFile(cDir & FileName) 'I found one!!
                FileName = Dir()   ' Get next entry.
            Loop
        Catch e As Exception
            Throw New Exception(e.ToString, e)
        End Try
    End Sub


End Class
