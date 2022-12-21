<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEvolucion
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
        Me.CtlEvolucion1 = New HistoriaClinica.ctlEvolucion
        Me.SuspendLayout()
        '
        'CtlEvolucion1
        '
        Me.CtlEvolucion1.Location = New System.Drawing.Point(22, 12)
        Me.CtlEvolucion1.Name = "CtlEvolucion1"
        Me.CtlEvolucion1.Size = New System.Drawing.Size(800, 531)
        Me.CtlEvolucion1.TabIndex = 0
        '
        'frmEvolucion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(847, 542)
        Me.Controls.Add(Me.CtlEvolucion1)
        Me.Name = "frmEvolucion"
        Me.Text = "frmEvolucion"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtlEvolucion1 As HistoriaClinica.ctlEvolucion
End Class
