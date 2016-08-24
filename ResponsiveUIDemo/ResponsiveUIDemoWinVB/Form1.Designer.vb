<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.progressBar1 = New System.Windows.Forms.ProgressBar()
        Me.cmdBackgroundWorker = New System.Windows.Forms.Button()
        Me.cmdThreadPool = New System.Windows.Forms.Button()
        Me.cmdTAPMethod = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'progressBar1
        '
        Me.progressBar1.Location = New System.Drawing.Point(12, 70)
        Me.progressBar1.Name = "progressBar1"
        Me.progressBar1.Size = New System.Drawing.Size(438, 18)
        Me.progressBar1.TabIndex = 5
        '
        'cmdBackgroundWorker
        '
        Me.cmdBackgroundWorker.Location = New System.Drawing.Point(160, 41)
        Me.cmdBackgroundWorker.Name = "cmdBackgroundWorker"
        Me.cmdBackgroundWorker.Size = New System.Drawing.Size(142, 23)
        Me.cmdBackgroundWorker.TabIndex = 4
        Me.cmdBackgroundWorker.Text = "Background worker"
        Me.cmdBackgroundWorker.UseVisualStyleBackColor = True
        '
        'cmdThreadPool
        '
        Me.cmdThreadPool.Location = New System.Drawing.Point(12, 41)
        Me.cmdThreadPool.Name = "cmdThreadPool"
        Me.cmdThreadPool.Size = New System.Drawing.Size(142, 23)
        Me.cmdThreadPool.TabIndex = 3
        Me.cmdThreadPool.Text = "Threadpool method"
        Me.cmdThreadPool.UseVisualStyleBackColor = True
        '
        'cmdTAPMethod
        '
        Me.cmdTAPMethod.Location = New System.Drawing.Point(308, 41)
        Me.cmdTAPMethod.Name = "cmdTAPMethod"
        Me.cmdTAPMethod.Size = New System.Drawing.Size(142, 23)
        Me.cmdTAPMethod.TabIndex = 6
        Me.cmdTAPMethod.Text = "Progress Reporting Pattern"
        Me.cmdTAPMethod.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(465, 101)
        Me.Controls.Add(Me.cmdTAPMethod)
        Me.Controls.Add(Me.progressBar1)
        Me.Controls.Add(Me.cmdBackgroundWorker)
        Me.Controls.Add(Me.cmdThreadPool)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents progressBar1 As System.Windows.Forms.ProgressBar
    Private WithEvents cmdBackgroundWorker As System.Windows.Forms.Button
    Private WithEvents cmdThreadPool As System.Windows.Forms.Button
    Friend WithEvents cmdTAPMethod As System.Windows.Forms.Button

End Class
