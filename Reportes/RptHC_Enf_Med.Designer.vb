<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RptHC_Enf_Med
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual
        Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote
        Me.ReportViewer1.ServerReport.ReportPath = "HC/rptHCConsolidada"
        Me.ReportViewer1.ServerReport.ReportServerUrl = New System.Uri("http://srvvsqldesa01/reportserver<", System.UriKind.Absolute)
        Me.ReportViewer1.Size = New System.Drawing.Size(1008, 729)
        Me.ReportViewer1.TabIndex = 0
        Me.ReportViewer1.UseWaitCursor = True
        '
        'RptHC_Enf_Med
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "RptHC_Enf_Med"
        Me.Text = "Reporte Historia Clínica"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
End Class
