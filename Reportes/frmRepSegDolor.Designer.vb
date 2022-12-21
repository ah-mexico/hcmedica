<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepSegDolor
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.RecienNacidoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.HCEnfEncabezadoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PacienteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.RecienNacidoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HCEnfEncabezadoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PacienteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "HistoriaClinica.RepEnfSubseccionSD.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(292, 273)
        Me.ReportViewer1.TabIndex = 1
        '
        'RecienNacidoBindingSource
        '
        Me.RecienNacidoBindingSource.DataSource = GetType(HistoriaClinica.Sophia.HistoriaClinica.Reportes.Evolucion)
        '
        'HCEnfEncabezadoBindingSource
        '
        Me.HCEnfEncabezadoBindingSource.DataSource = GetType(HistoriaClinica.Sophia.HistoriaClinica.Reportes.HCEncabezado)
        '
        'PacienteBindingSource
        '
        Me.PacienteBindingSource.DataSource = GetType(HistoriaClinica.Sophia.HistoriaClinica.Reportes.Paciente)
        '
        'frmRepSegDolor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "frmRepSegDolor"
        Me.Text = "REPORTE NOTAS SEGUIMIENTO DOLOR"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RecienNacidoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HCEnfEncabezadoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PacienteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents RecienNacidoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents HCEnfEncabezadoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PacienteBindingSource As System.Windows.Forms.BindingSource
End Class
