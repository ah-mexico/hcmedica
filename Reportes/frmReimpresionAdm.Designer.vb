<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReimpresionAdm
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Me.AdmisionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PacienteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RepAdmisionU = New Microsoft.Reporting.WinForms.ReportViewer
        CType(Me.AdmisionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PacienteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AdmisionBindingSource
        '
        Me.AdmisionBindingSource.DataSource = GetType(HistoriaClinica.Sophia.HistoriaClinica.Reportes.Admision)
        '
        'PacienteBindingSource
        '
        Me.PacienteBindingSource.DataSource = GetType(HistoriaClinica.Sophia.HistoriaClinica.Reportes.Paciente)
        '
        'RepAdmisionU
        '
        Me.RepAdmisionU.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "HistoriaClinica_Sophia_HistoriaClinica_Reportes_Admision"
        ReportDataSource1.Value = Me.AdmisionBindingSource
        ReportDataSource2.Name = "HistoriaClinica_Sophia_HistoriaClinica_Reportes_Paciente"
        ReportDataSource2.Value = Me.PacienteBindingSource
        Me.RepAdmisionU.LocalReport.DataSources.Add(ReportDataSource1)
        Me.RepAdmisionU.LocalReport.DataSources.Add(ReportDataSource2)
        Me.RepAdmisionU.LocalReport.ReportEmbeddedResource = "HistoriaClinica.ReimpresionAdm.rdlc"
        Me.RepAdmisionU.Location = New System.Drawing.Point(0, 0)
        Me.RepAdmisionU.Margin = New System.Windows.Forms.Padding(0)
        Me.RepAdmisionU.Name = "RepAdmisionU"
        Me.RepAdmisionU.Size = New System.Drawing.Size(322, 333)
        Me.RepAdmisionU.TabIndex = 0
        '
        'frmReimpresionAdm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(322, 333)
        Me.Controls.Add(Me.RepAdmisionU)
        Me.Name = "frmReimpresionAdm"
        Me.Text = "Reimpresión de Admisión"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.AdmisionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PacienteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RepAdmisionU As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents AdmisionBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PacienteBindingSource As System.Windows.Forms.BindingSource
End Class
