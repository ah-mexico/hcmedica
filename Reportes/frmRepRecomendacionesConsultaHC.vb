Imports objGenerales = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports System.Collections.Generic
Imports Microsoft.Reporting.WinForms

Public Class frmRepRecomendacionesConsultaHC

    Private _historiaClinica As FormatoHistoriaClinica

    Public Sub imprimirRecomendaciones(ByVal historiaClinica As FormatoHistoriaClinica)
        Dim objGen As objGenerales.Generales

        objGen = objGenerales.Generales.Instancia

        _historiaClinica = historiaClinica

        If _historiaClinica.Recomendaciones Is Nothing Then
            MsgBox("No existen datos para el paciente", MsgBoxStyle.Information)
            Exit Sub
        End If

        Me.RecomendacionEgresoBindingSource.DataSource = _historiaClinica.Recomendaciones
        If Not _historiaClinica.Recomendaciones Is Nothing Then
            ObjetoSimpleBindingSource.DataSource = _historiaClinica.Recomendaciones.Procedimientos
            ObjetoAuxiliarBindingSource.DataSource = _historiaClinica.Recomendaciones.Medicamentos
        End If

        If objGen.Pais = "482" Then ''Peru
            Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "HistoriaClinica.RepRecomendacionEgresoPeru.rdlc"
        Else
            Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "HistoriaClinica.RepRecomendacionEgreso.rdlc"
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
        aParametros.Add(New ReportParameter("Reimpresion", True))
        ReportViewer1.LocalReport.SetParameters(aParametros)
    End Sub

    Private Sub frmRepRecomendacionesConsultaHC_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If _historiaClinica.SeccionesHC.Triage Then
            frmRepTriageConsultaHC.Show()
            frmRepTriageConsultaHC.imprimirTriage(_historiaClinica)
        End If
    End Sub
End Class