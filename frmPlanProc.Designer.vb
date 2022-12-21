<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlanProc
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
        Me.components = New System.ComponentModel.Container
        Me.CtlPlanProcExternos1 = New HistoriaClinica.ctlPlanProcExternos
        Me.SuspendLayout()
        '
        'CtlPlanProcExternos1
        '
        Me.CtlPlanProcExternos1.AutoScroll = True
        Me.CtlPlanProcExternos1.Location = New System.Drawing.Point(12, 12)
        Me.CtlPlanProcExternos1.Name = "CtlPlanProcExternos1"
        Me.CtlPlanProcExternos1.Size = New System.Drawing.Size(821, 424)
        Me.CtlPlanProcExternos1.TabIndex = 0
        '
        'frmPlanProc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(846, 456)
        Me.Controls.Add(Me.CtlPlanProcExternos1)
        Me.Name = "frmPlanProc"
        Me.Text = "frmPlanProc"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtlPlanProcExternos1 As HistoriaClinica.ctlPlanProcExternos
End Class
