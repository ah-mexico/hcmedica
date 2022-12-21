<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRecEgreso
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.CtlRecomEgreso1 = New HistoriaClinica.ctlRecomEgreso
        Me.SuspendLayout()
        '
        'CtlRecomEgreso1
        '
        Me.CtlRecomEgreso1.AutoScroll = True
        Me.CtlRecomEgreso1.Location = New System.Drawing.Point(41, 21)
        Me.CtlRecomEgreso1.Name = "CtlRecomEgreso1"
        Me.CtlRecomEgreso1.Size = New System.Drawing.Size(826, 342)
        Me.CtlRecomEgreso1.TabIndex = 0
        '
        'frmRecEgreso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(891, 397)
        Me.Controls.Add(Me.CtlRecomEgreso1)
        Me.Name = "frmRecEgreso"
        Me.Text = "frmRecEgreso"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtlRecomEgreso1 As HistoriaClinica.ctlRecomEgreso
End Class
