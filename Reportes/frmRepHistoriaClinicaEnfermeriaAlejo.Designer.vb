<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepHistoriaClinicaEnfermeria
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
        Me.components = New System.ComponentModel.Container()
        Me.HCEnfEncabezadoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PacienteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.RecienNacidoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.HCEnfEncabezadoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PacienteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RecienNacidoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'HCEnfEncabezadoBindingSource
        '
        Me.HCEnfEncabezadoBindingSource.DataSource = GetType(HistoriaClinica.Sophia.HistoriaClinica.Reportes.HCEncabezado)
        '
        'PacienteBindingSource
        '
        Me.PacienteBindingSource.DataSource = GetType(HistoriaClinica.Sophia.HistoriaClinica.Reportes.Paciente)
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "HistoriaClinica.RepHistoriaClinicaAlejo.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(292, 273)
        Me.ReportViewer1.TabIndex = 0
        '
        'RecienNacidoBindingSource
        '
        Me.RecienNacidoBindingSource.DataSource = GetType(HistoriaClinica.Sophia.HistoriaClinica.Reportes.Evolucion)
        '
        'frmRepHistoriaClinicaEnfermeria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "frmRepHistoriaClinicaEnfermeria"
        Me.Text = "REPORTE HISTORIA CLINICA"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.HCEnfEncabezadoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PacienteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RecienNacidoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents HCEnfEncabezadoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PacienteBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RecienNacidoBindingSource As System.Windows.Forms.BindingSource
End Class
