Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports System.Collections.Generic
Imports Microsoft.Reporting.WinForms

Public Class frmRepTriageConsultaHC

    Public Sub imprimirTriage(ByVal historiaClinica As FormatoHistoriaClinica)

        'If historiaClinica.Triage Is Nothing Then
        '    MsgBox("No existen datos para el paciente.", MsgBoxStyle.Information)
        '    Exit Sub
        'End If

        TriageBindingSource.DataSource = historiaClinica.Triage

        If Not historiaClinica.Triage Is Nothing Then
            PacienteBindingSource.DataSource = historiaClinica.Triage.Paciente
        End If

        setParametrosReporte()

        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub ReportViewer1_RenderingComplete(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.RenderingCompleteEventArgs) Handles ReportViewer1.RenderingComplete
        ''Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
    End Sub

    Public Sub setParametrosReporte()
        Dim aParametros As New List(Of ReportParameter)

        aParametros.Add(New ReportParameter("FechaImpresion", Format(FuncionesGenerales.FechaServidor(), "dd/MM/yyyy HH:mm")))
        ReportViewer1.LocalReport.SetParameters(aParametros)
    End Sub

End Class