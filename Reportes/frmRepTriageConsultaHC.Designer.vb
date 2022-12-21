<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepTriageConsultaHC
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
        Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource4 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Me.PacienteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TriageBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        CType(Me.PacienteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TriageBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PacienteBindingSource
        '
        Me.PacienteBindingSource.DataSource = GetType(HistoriaClinica.Sophia.HistoriaClinica.Reportes.Paciente)
        '
        'TriageBindingSource
        '
        Me.TriageBindingSource.DataSource = GetType(HistoriaClinica.Sophia.HistoriaClinica.Reportes.Triage)
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource3.Name = "HistoriaClinica_Sophia_HistoriaClinica_Reportes_Paciente"
        ReportDataSource3.Value = Me.PacienteBindingSource
        ReportDataSource4.Name = "HistoriaClinica_Sophia_HistoriaClinica_Reportes_Triage"
        ReportDataSource4.Value = Me.TriageBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource3)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource4)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "HistoriaClinica.RepTriage.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(292, 266)
        Me.ReportViewer1.TabIndex = 0
        '
        'frmTriageConsultaHC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "frmTriageConsultaHC"
        Me.Text = "Hoja de Triage"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PacienteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TriageBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents PacienteBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TriageBindingSource As System.Windows.Forms.BindingSource
End Class
