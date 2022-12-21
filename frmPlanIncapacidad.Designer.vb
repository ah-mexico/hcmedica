<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlanIncapacidad
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
        Me.CtlPlanIncapacidad1 = New HistoriaClinica.ctlPlanIncapacidad
        Me.SuspendLayout()
        '
        'CtlPlanIncapacidad1
        '
        Me.CtlPlanIncapacidad1.Location = New System.Drawing.Point(37, 40)
        Me.CtlPlanIncapacidad1.Name = "CtlPlanIncapacidad1"
        Me.CtlPlanIncapacidad1.Size = New System.Drawing.Size(800, 269)
        Me.CtlPlanIncapacidad1.TabIndex = 0
        '
        'frmPlanIncapacidadvb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(871, 361)
        Me.Controls.Add(Me.CtlPlanIncapacidad1)
        Me.Name = "frmPlanIncapacidadvb"
        Me.Text = "frmPlanIncapacidadvb"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtlPlanIncapacidad1 As HistoriaClinica.ctlPlanIncapacidad
End Class
