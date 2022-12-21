<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepTriage
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
        Me.RepVTriage = New Microsoft.Reporting.WinForms.ReportViewer
        Me.TriageBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PacienteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.TriageBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PacienteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RepVTriage
        '
        Me.RepVTriage.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "HistoriaClinica_Sophia_HistoriaClinica_Reportes_Triage"
        ReportDataSource1.Value = Me.TriageBindingSource
        ReportDataSource2.Name = "HistoriaClinica_Sophia_HistoriaClinica_Reportes_Paciente"
        ReportDataSource2.Value = Me.PacienteBindingSource
        Me.RepVTriage.LocalReport.DataSources.Add(ReportDataSource1)
        Me.RepVTriage.LocalReport.DataSources.Add(ReportDataSource2)
        Me.RepVTriage.LocalReport.ReportEmbeddedResource = "HistoriaClinica.RepTriage.rdlc"
        Me.RepVTriage.Location = New System.Drawing.Point(0, 0)
        Me.RepVTriage.Name = "RepVTriage"
        Me.RepVTriage.Size = New System.Drawing.Size(398, 250)
        Me.RepVTriage.TabIndex = 0
        '
        'TriageBindingSource
        '
        Me.TriageBindingSource.DataSource = GetType(HistoriaClinica.Sophia.HistoriaClinica.Reportes.Triage)
        '
        'PacienteBindingSource
        '
        Me.PacienteBindingSource.DataSource = GetType(HistoriaClinica.Sophia.HistoriaClinica.Reportes.Paciente)
        '
        'frmRepTriage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(398, 250)
        Me.Controls.Add(Me.RepVTriage)
        Me.Name = "frmRepTriage"
        Me.Text = "Hoja de Triage"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.TriageBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PacienteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RepVTriage As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents TriageBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PacienteBindingSource As System.Windows.Forms.BindingSource
End Class
