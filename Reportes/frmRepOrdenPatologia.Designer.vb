<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepOrdenPatologia
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
        Me.HCEncabezadoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PacienteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DescripcionQxBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PatologiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DiagnosticoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        CType(Me.HCEncabezadoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PacienteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DescripcionQxBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PatologiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DiagnosticoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'HCEncabezadoBindingSource
        '
        Me.HCEncabezadoBindingSource.DataSource = GetType(HistoriaClinica.Sophia.HistoriaClinica.Reportes.HCEncabezado)
        '
        'PacienteBindingSource
        '
        Me.PacienteBindingSource.DataSource = GetType(HistoriaClinica.Sophia.HistoriaClinica.Reportes.Paciente)
        '
        'DescripcionQxBindingSource
        '
        Me.DescripcionQxBindingSource.DataSource = GetType(HistoriaClinica.Sophia.HistoriaClinica.Reportes.DescripcionQx)
        '
        'PatologiaBindingSource
        Me.DiagnosticoBindingSource.DataSource = GetType(HistoriaClinica.Sophia.HistoriaClinica.Reportes.Diagnostico)

        '
        Me.PatologiaBindingSource.DataSource = GetType(HistoriaClinica.Sophia.HistoriaClinica.Reportes.OrdenPatologia)
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "HistoriaClinica_Sophia_HistoriaClinica_Reportes_HCEncabezado"
        ReportDataSource1.Value = Me.HCEncabezadoBindingSource
        ReportDataSource2.Name = "HistoriaClinica_Sophia_HistoriaClinica_Reportes_Paciente"
        ReportDataSource2.Value = Me.PacienteBindingSource
        ReportDataSource3.Name = "HistoriaClinica_Sophia_HistoriaClinica_Reportes_Diagnostico"
        ReportDataSource3.Value = Me.DiagnosticoBindingSource
        ReportDataSource4.Name = "HistoriaClinica_Sophia_HistoriaClinica_Reportes_OrdenPatologia"
        ReportDataSource4.Value = Me.PatologiaBindingSource
        ReportDataSource5.Name = "HistoriaClinica_Sophia_HistoriaClinica_Reportes_DescripcionQx"
        ReportDataSource5.Value = Me.PatologiaBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource3)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource4)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource5)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "HistoriaClinica.RepOrdenPatologia.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(292, 273)
        Me.ReportViewer1.TabIndex = 0
        '
        'frmRepOrdenPatologia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "frmRepOrdenPatologia"
        Me.Text = "Reporte Orden De Patologia"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.HCEncabezadoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PacienteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DescripcionQxBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PatologiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DiagnosticoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents HCEncabezadoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PacienteBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DescripcionQxBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DiagnosticoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PatologiaBindingSource As System.Windows.Forms.BindingSource
End Class
