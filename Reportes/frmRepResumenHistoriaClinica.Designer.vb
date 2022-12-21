<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepResumenHistoriaClinica
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
        Me.PacienteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.HCEncabezadoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.PacienteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HCEncabezadoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PacienteBindingSource
        '
        Me.PacienteBindingSource.DataMember = "Paciente"
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "HistoriaClinica_Sophia_HistoriaClinica_Reportes_Paciente"
        ReportDataSource1.Value = Me.PacienteBindingSource
        ReportDataSource2.Name = "HistoriaClinica_Sophia_HistoriaClinica_Reportes_HCEncabezado"
        ReportDataSource2.Value = Me.HCEncabezadoBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "HistoriaClinica.RepResumenHistoriaClinica.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(292, 273)
        Me.ReportViewer1.TabIndex = 0
        '
        'HCEncabezadoBindingSource
        '
        Me.HCEncabezadoBindingSource.DataSource = GetType(HistoriaClinica.Sophia.HistoriaClinica.Reportes.HCEncabezado)
        '
        'frmRepResumenHistoriaClinica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "frmRepResumenHistoriaClinica"
        Me.Text = "Resumen Historia Clínica"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PacienteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HCEncabezadoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents PacienteBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents HCEncabezadoBindingSource As System.Windows.Forms.BindingSource
End Class
