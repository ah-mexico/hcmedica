<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRepFomulaProcedimtPDF
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Me.FormulaProcedimDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DetailFormulaProcedDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DiagnFrmlProcedimDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.viewFomulaProcedimPDF = New Microsoft.Reporting.WinForms.ReportViewer
        CType(Me.FormulaProcedimDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DetailFormulaProcedDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DiagnFrmlProcedimDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FormulaProcedimDataBindingSource
        '
        Me.FormulaProcedimDataBindingSource.DataSource = GetType(HistoriaClinica.Sophia.HistoriaClinica.Reportes.Data.FormulaProcedimData)
        '
        'DetailFormulaProcedDataBindingSource
        '
        Me.DetailFormulaProcedDataBindingSource.DataSource = GetType(HistoriaClinica.Sophia.HistoriaClinica.Reportes.Data.DetailFormulaProcedData)
        '
        'DiagnFrmlProcedimDataBindingSource
        '
        Me.DiagnFrmlProcedimDataBindingSource.DataSource = GetType(HistoriaClinica.Sophia.HistoriaClinica.Reportes.Data.DiagnFrmlProcedimData)
        '
        'viewFomulaProcedimPDF
        '
        Me.viewFomulaProcedimPDF.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "HistoriaClinica_Sophia_HistoriaClinica_Reportes_Data_FormulaProcedimData"
        ReportDataSource1.Value = Me.FormulaProcedimDataBindingSource
        ReportDataSource2.Name = "HistoriaClinica_Sophia_HistoriaClinica_Reportes_Data_DetailFormulaProcedData"
        ReportDataSource2.Value = Me.DetailFormulaProcedDataBindingSource
        ReportDataSource3.Name = "HistoriaClinica_Sophia_HistoriaClinica_Reportes_Data_DiagnFrmlProcedimData"
        ReportDataSource3.Value = Me.DiagnFrmlProcedimDataBindingSource
        Me.viewFomulaProcedimPDF.LocalReport.DataSources.Add(ReportDataSource1)
        Me.viewFomulaProcedimPDF.LocalReport.DataSources.Add(ReportDataSource2)
        Me.viewFomulaProcedimPDF.LocalReport.DataSources.Add(ReportDataSource3)
        Me.viewFomulaProcedimPDF.LocalReport.ReportEmbeddedResource = "HistoriaClinica.RepFormulaProcedimPDF.rdlc"
        Me.viewFomulaProcedimPDF.Location = New System.Drawing.Point(0, 0)
        Me.viewFomulaProcedimPDF.Name = "viewFomulaProcedimPDF"
        Me.viewFomulaProcedimPDF.Size = New System.Drawing.Size(413, 249)
        Me.viewFomulaProcedimPDF.TabIndex = 0
        '
        'FrmRepFomulaProcedimtPDF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(413, 249)
        Me.Controls.Add(Me.viewFomulaProcedimPDF)
        Me.Name = "FrmRepFomulaProcedimtPDF"
        Me.Text = "Fomula de Procedimientos"
        CType(Me.FormulaProcedimDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DetailFormulaProcedDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DiagnFrmlProcedimDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents viewFomulaProcedimPDF As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents FormulaProcedimDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DetailFormulaProcedDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DiagnFrmlProcedimDataBindingSource As System.Windows.Forms.BindingSource
End Class
