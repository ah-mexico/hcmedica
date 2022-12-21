<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepPlanIncapacidad
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
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.EncabezadoPlanManejoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.IncapacidadBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.EncabezadoPlanManejoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IncapacidadBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "HistoriaClinica_Sophia_HistoriaClinica_Reportes_EncabezadoPlanManejo"
        ReportDataSource1.Value = Me.EncabezadoPlanManejoBindingSource
        ReportDataSource2.Name = "HistoriaClinica_Sophia_HistoriaClinica_Reportes_Incapacidad"
        ReportDataSource2.Value = Me.IncapacidadBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "HistoriaClinica.RepIncapacidad.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(292, 273)
        Me.ReportViewer1.TabIndex = 0
        '
        'EncabezadoPlanManejoBindingSource
        '
        Me.EncabezadoPlanManejoBindingSource.DataSource = GetType(HistoriaClinica.Sophia.HistoriaClinica.Reportes.EncabezadoPlanManejo)
        '
        'IncapacidadBindingSource
        '
        Me.IncapacidadBindingSource.DataSource = GetType(HistoriaClinica.Sophia.HistoriaClinica.Reportes.Incapacidad)
        '
        'frmRepPlanIncapacidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "frmRepPlanIncapacidad"
        Me.Text = "Reporte de Incapacidad"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.EncabezadoPlanManejoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IncapacidadBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents EncabezadoPlanManejoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents IncapacidadBindingSource As System.Windows.Forms.BindingSource
End Class
