<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepRecomendacionesConsultaHC
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
        Dim ReportDataSource4 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource5 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource6 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Me.ObjetoSimpleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ObjetoAuxiliarBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RecomendacionEgresoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        CType(Me.ObjetoSimpleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ObjetoAuxiliarBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RecomendacionEgresoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ObjetoSimpleBindingSource
        '
        Me.ObjetoSimpleBindingSource.DataSource = GetType(HistoriaClinica.Sophia.HistoriaClinica.Comunes.ObjetoSimple)
        '
        'ObjetoAuxiliarBindingSource
        '
        Me.ObjetoAuxiliarBindingSource.DataSource = GetType(HistoriaClinica.Sophia.HistoriaClinica.Comunes.ObjetoAuxiliar)
        '
        'RecomendacionEgresoBindingSource
        '
        Me.RecomendacionEgresoBindingSource.DataSource = GetType(HistoriaClinica.Sophia.HistoriaClinica.Reportes.RecomendacionEgreso)
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource4.Name = "HistoriaClinica_Sophia_HistoriaClinica_Comunes_ObjetoSimple"
        ReportDataSource4.Value = Me.ObjetoSimpleBindingSource
        ReportDataSource5.Name = "HistoriaClinica_Sophia_HistoriaClinica_Comunes_ObjetoAuxiliar"
        ReportDataSource5.Value = Me.ObjetoAuxiliarBindingSource
        ReportDataSource6.Name = "HistoriaClinica_Sophia_HistoriaClinica_Reportes_RecomendacionEgreso"
        ReportDataSource6.Value = Me.RecomendacionEgresoBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource4)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource5)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource6)        
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(292, 266)
        Me.ReportViewer1.TabIndex = 0
        '
        'frmRepRecomendacionesConsultaHC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "frmRepRecomendacionesConsultaHC"
        Me.Text = "Reporte de Recomendaciones al egreso"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ObjetoSimpleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ObjetoAuxiliarBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RecomendacionEgresoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ObjetoSimpleBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ObjetoAuxiliarBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RecomendacionEgresoBindingSource As System.Windows.Forms.BindingSource
End Class
