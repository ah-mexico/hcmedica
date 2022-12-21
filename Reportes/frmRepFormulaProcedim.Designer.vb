<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepFormulaProcedim
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
        Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource4 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource5 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource6 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource7 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Me.ReportFormula = New Microsoft.Reporting.WinForms.ReportViewer
        Me.RepFormulaAutoriza = New Microsoft.Reporting.WinForms.ReportViewer
        Me.PacienteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.OrdenBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProcedimientoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DiagnosticoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.PacienteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrdenBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProcedimientoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DiagnosticoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportFormula
        '
        Me.ReportFormula.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "HistoriaClinica_Sophia_HistoriaClinica_Reportes_Procedimiento"
        ReportDataSource1.Value = Me.ProcedimientoBindingSource
        ReportDataSource2.Name = "HistoriaClinica_Sophia_HistoriaClinica_Reportes_Orden"
        ReportDataSource2.Value = Me.OrdenBindingSource
        ReportDataSource3.Name = "HistoriaClinica_Sophia_HistoriaClinica_Reportes_Paciente"
        ReportDataSource3.Value = Me.PacienteBindingSource
        ReportDataSource4.Name = "HistoriaClinica_Sophia_HistoriaClinica_Reportes_Diagnostico"
        ReportDataSource4.Value = Me.DiagnosticoBindingSource
        Me.ReportFormula.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportFormula.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportFormula.LocalReport.DataSources.Add(ReportDataSource3)
        Me.ReportFormula.LocalReport.DataSources.Add(ReportDataSource4)
        Me.ReportFormula.Location = New System.Drawing.Point(0, 0)
        Me.ReportFormula.Name = "ReportFormula"
        Me.ReportFormula.Size = New System.Drawing.Size(399, 250)
        Me.ReportFormula.TabIndex = 0
        '
        'RepFormulaAutoriza
        '
        Me.RepFormulaAutoriza.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource5.Name = "HistoriaClinica_Sophia_HistoriaClinica_Reportes_Paciente"
        ReportDataSource5.Value = Me.PacienteBindingSource
        ReportDataSource6.Name = "HistoriaClinica_Sophia_HistoriaClinica_Reportes_Orden"
        ReportDataSource6.Value = Me.OrdenBindingSource
        ReportDataSource7.Name = "HistoriaClinica_Sophia_HistoriaClinica_Reportes_Procedimiento"
        ReportDataSource7.Value = Me.ProcedimientoBindingSource
        Me.RepFormulaAutoriza.LocalReport.DataSources.Add(ReportDataSource5)
        Me.RepFormulaAutoriza.LocalReport.DataSources.Add(ReportDataSource6)
        Me.RepFormulaAutoriza.LocalReport.DataSources.Add(ReportDataSource7)
        Me.RepFormulaAutoriza.Location = New System.Drawing.Point(0, 0)
        Me.RepFormulaAutoriza.Name = "RepFormulaAutoriza"
        Me.RepFormulaAutoriza.Size = New System.Drawing.Size(399, 250)
        Me.RepFormulaAutoriza.TabIndex = 1
        '
        'PacienteBindingSource
        '
        Me.PacienteBindingSource.DataSource = GetType(HistoriaClinica.Sophia.HistoriaClinica.Reportes.Paciente)
        '
        'OrdenBindingSource
        '
        Me.OrdenBindingSource.DataSource = GetType(HistoriaClinica.Sophia.HistoriaClinica.Reportes.Orden)
        '
        'ProcedimientoBindingSource
        '
        Me.ProcedimientoBindingSource.DataSource = GetType(HistoriaClinica.Sophia.HistoriaClinica.Reportes.Procedimiento)
        '
        'DiagnosticoBindingSource
        '
        Me.DiagnosticoBindingSource.DataSource = GetType(HistoriaClinica.Sophia.HistoriaClinica.Reportes.Diagnostico)
        '
        'frmRepFormulaProcedim
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(399, 250)
        Me.Controls.Add(Me.ReportFormula)
        Me.Controls.Add(Me.RepFormulaAutoriza)
        Me.Name = "frmRepFormulaProcedim"
        Me.Text = "Procedimientos Externos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PacienteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrdenBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProcedimientoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DiagnosticoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportFormula As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ProcedimientoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents OrdenBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PacienteBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RepFormulaAutoriza As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DiagnosticoBindingSource As System.Windows.Forms.BindingSource
End Class
