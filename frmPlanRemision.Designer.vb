<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlanRemision
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
        Me.CtlPlanRemision1 = New HistoriaClinica.ctlPlanRemision
        Me.SuspendLayout()
        '
        'CtlPlanRemision1
        '
        Me.CtlPlanRemision1.AutoScroll = True
        Me.CtlPlanRemision1.Location = New System.Drawing.Point(32, 21)
        Me.CtlPlanRemision1.Name = "CtlPlanRemision1"
        Me.CtlPlanRemision1.Size = New System.Drawing.Size(819, 384)
        Me.CtlPlanRemision1.TabIndex = 0
        '
        'frmPlanRemision
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(899, 450)
        Me.Controls.Add(Me.CtlPlanRemision1)
        Me.Name = "frmPlanRemision"
        Me.Text = "frmPlanRemision"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtlPlanRemision1 As HistoriaClinica.ctlPlanRemision
End Class
