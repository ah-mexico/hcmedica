<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.HcBasica1 = New HistoriaClinica.HCBasica
        Me.CtlDatosPaciente1 = New HistoriaClinica.ctlDatosPaciente
        Me.SuspendLayout()
        '
        'HcBasica1
        '
        Me.HcBasica1.AutoScroll = True
        Me.HcBasica1.BackColor = System.Drawing.Color.White
        Me.HcBasica1.Location = New System.Drawing.Point(53, 205)
        Me.HcBasica1.MaximumSize = New System.Drawing.Size(823, 200000)
        Me.HcBasica1.Name = "HcBasica1"
        Me.HcBasica1.Padding = New System.Windows.Forms.Padding(100, 0, 0, 0)
        Me.HcBasica1.Size = New System.Drawing.Size(823, 533)
        Me.HcBasica1.TabIndex = 1
        '
        'CtlDatosPaciente1
        '
        Me.CtlDatosPaciente1.BackColor = System.Drawing.SystemColors.Window
        Me.CtlDatosPaciente1.Location = New System.Drawing.Point(47, 12)
        Me.CtlDatosPaciente1.Name = "CtlDatosPaciente1"
        Me.CtlDatosPaciente1.Size = New System.Drawing.Size(835, 159)
        Me.CtlDatosPaciente1.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(919, 505)
        Me.Controls.Add(Me.HcBasica1)
        Me.Controls.Add(Me.CtlDatosPaciente1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtlDatosPaciente1 As HistoriaClinica.ctlDatosPaciente
    Friend WithEvents HcBasica1 As HistoriaClinica.HCBasica
End Class
