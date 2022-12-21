<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrdenes
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
        Me.CtlOrdenesMedicas1 = New HistoriaClinica.ctlOrdenesMedicas
        Me.SuspendLayout()
        '
        'CtlOrdenesMedicas1
        '
        Me.CtlOrdenesMedicas1.AutoScroll = True
        Me.CtlOrdenesMedicas1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtlOrdenesMedicas1.Location = New System.Drawing.Point(0, 0)
        Me.CtlOrdenesMedicas1.Name = "CtlOrdenesMedicas1"
        Me.CtlOrdenesMedicas1.Size = New System.Drawing.Size(803, 589)
        Me.CtlOrdenesMedicas1.TabIndex = 0
        '
        'frmOrdenes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(803, 589)
        Me.Controls.Add(Me.CtlOrdenesMedicas1)
        Me.Name = "frmOrdenes"
        Me.Text = "frmOrdenes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtlOrdenesMedicas1 As HistoriaClinica.ctlOrdenesMedicas
End Class
