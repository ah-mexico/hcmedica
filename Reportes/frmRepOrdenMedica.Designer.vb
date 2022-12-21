<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepOrdenMedica
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource4 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource5 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ProcedimientoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MedicamentoControlBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MedicamentoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProcedimientoNoSedeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AlarmaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProcedimientoNoPracticaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.ProcedimientoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MedicamentoControlBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MedicamentoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProcedimientoNoSedeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AlarmaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProcedimientoNoPracticaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "HistoriaClinica_Sophia_HistoriaClinica_Reportes_MedicamentoControl"
        ReportDataSource1.Value = Me.MedicamentoControlBindingSource
        ReportDataSource2.Name = "HistoriaClinica_Sophia_HistoriaClinica_Reportes_Medicamento"
        ReportDataSource2.Value = Me.MedicamentoBindingSource
        ReportDataSource3.Name = "HistoriaClinica_Sophia_HistoriaClinica_Reportes_ProcedimientoNoSede"
        ReportDataSource3.Value = Me.ProcedimientoNoSedeBindingSource
        ReportDataSource4.Name = "HistoriaClinica_Sophia_HistoriaClinica_Reportes_Procedimiento"
        ReportDataSource4.Value = Me.ProcedimientoBindingSource
        ReportDataSource5.Name = "HistoriaClinica_Sophia_HistoriaClinica_Reportes_Alarma"
        ReportDataSource5.Value = Me.AlarmaBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource3)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource4)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource5)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "HistoriaClinica.RepOrdenesMedicas2.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(292, 266)
        Me.ReportViewer1.TabIndex = 0
        '
        'ProcedimientoBindingSource
        '
        Me.ProcedimientoBindingSource.DataSource = GetType(HistoriaClinica.Sophia.HistoriaClinica.Reportes.Procedimiento)
        '
        'MedicamentoControlBindingSource
        '
        Me.MedicamentoControlBindingSource.DataSource = GetType(HistoriaClinica.Sophia.HistoriaClinica.Reportes.MedicamentoControl)
        '
        'MedicamentoBindingSource
        '
        Me.MedicamentoBindingSource.DataSource = GetType(HistoriaClinica.Sophia.HistoriaClinica.Reportes.Medicamento)
        '
        'ProcedimientoNoSedeBindingSource
        '
        Me.ProcedimientoNoSedeBindingSource.DataSource = GetType(HistoriaClinica.Sophia.HistoriaClinica.Reportes.ProcedimientoNoSede)
        '
        'AlarmaBindingSource
        '
        Me.AlarmaBindingSource.DataSource = GetType(HistoriaClinica.Sophia.HistoriaClinica.Reportes.Alarma)
        '
        'ProcedimientoNoPracticaBindingSource
        '
        Me.ProcedimientoNoPracticaBindingSource.DataSource = GetType(HistoriaClinica.Sophia.HistoriaClinica.Reportes.ProcedimientoNoPractica)
        '
        'frmRepOrdenMedica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "frmRepOrdenMedica"
        Me.Text = "Orden Medica"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ProcedimientoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MedicamentoControlBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MedicamentoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProcedimientoNoSedeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AlarmaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProcedimientoNoPracticaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ProcedimientoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MedicamentoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MedicamentoControlBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProcedimientoNoPracticaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProcedimientoNoSedeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AlarmaBindingSource As System.Windows.Forms.BindingSource
End Class
