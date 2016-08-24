Imports System.Threading
Imports System.ComponentModel
Imports System.Threading.Tasks

Public Class Form1
    ' For the progress reporting pattern, we need an object
    ' of type IProgress(Of T) to use for our marshalling onto the UI thread
    '  Create a progress object IProgress(Of T) (TAP - Task-based Asynchronous Pattern)
    Private progress As IProgress(Of ProgressChangedEventArgs)
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        '  As part of the Progress reporting pattern, we need an instance of
        '  Progress(Of T) object which implements the IProgress(Of T) interface
        '  Initialize a Progress(Of T) object to handle the marshalling functionality
        progress = New Progress(Of ProgressChangedEventArgs)

        '  Add a handler for the ProgressChanged event
        AddHandler CType(progress, Progress(Of ProgressChangedEventArgs)).ProgressChanged, AddressOf IProgress_Changed
    End Sub

    ''' <summary>
    ''' Used in all three demos
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SomeLongRunningProcess()
        ' Simulating a long running function
        Thread.Sleep(20)
    End Sub

    ''' <summary>
    ''' Used in all three demos
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SomeOtherLongRunningProcess()
        'Simulating a long running function
        Thread.Sleep(20)
    End Sub

#Region "Threadpool Functionality"
    Private Sub cmdThreadPool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThreadPool.Click
        '  This method is executed on the UI thread...I can touch the UI here
        progressBar1.Value = 0

        '  request a thread from the pool to execute Thread_Worker method
        ThreadPool.QueueUserWorkItem(AddressOf Thread_Worker)
    End Sub

    Private Sub Thread_Worker(ByVal stateInfo As Object)
        For i = 0 To 100
            SomeLongRunningProcess()
            SomeOtherLongRunningProcess()

            '  No thouchie!  Must use Invoke to alter UI 
            '  Passing in an anonymous function to update the UI
            Dim num As Integer = i ' VB doesn't like the use of I in lambda below
            Me.Invoke(New Action(Sub() progressBar1.Value = num))
        Next
    End Sub
#End Region
#Region "Background Worker Functionality"
    Private Sub cmdBackgroundWorker_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBackgroundWorker.Click
        progressBar1.Value = 0
        '  Create the background worker object
        Dim bg As BackgroundWorker = New BackgroundWorker

        '  Tell it you will be reporting progress
        bg.WorkerReportsProgress = True

        '  Set the handler for the progress Changed events that fire
        AddHandler bg.ProgressChanged, New ProgressChangedEventHandler(AddressOf bg_ProgressChanged)

        '  Set the method to do the work....I just use a lambda here
        AddHandler bg.DoWork, New DoWorkEventHandler(
                Sub(obj, args)
                    For i = 0 To 100
                        SomeLongRunningProcess()
                        SomeOtherLongRunningProcess()
                        bg.ReportProgress(i)
                    Next
                End Sub)

        ' Run it
        bg.RunWorkerAsync()
    End Sub

    ''' <summary>
    ''' Handles the progress changed events from the BackgroundWorker object
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub bg_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs)
        '  This event handler method is automatically marshalled onto the
        '  UI thread so I can touch the UI here without fear.
        progressBar1.Value = e.ProgressPercentage
    End Sub

#End Region
#Region "Progress Reporting Pattern Functionality (TAP)"
    Private Sub cmdTAPMethod_Click(sender As Object, e As EventArgs) Handles cmdTAPMethod.Click
        Dim t As Task = Task.Run(Sub()
                                     For index = 1 To 100
                                         SomeLongRunningProcess()
                                         SomeOtherLongRunningProcess()
                                         progress.Report(New ProgressChangedEventArgs(index, Nothing))
                                     Next
                                 End Sub)
    End Sub

    Private Sub IProgress_Changed(sender As Object, e As ProgressChangedEventArgs)
        progressBar1.Value = e.ProgressPercentage
    End Sub

#End Region
End Class

