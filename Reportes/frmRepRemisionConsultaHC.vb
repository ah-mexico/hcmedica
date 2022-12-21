Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports System.Collections.Generic
Imports Microsoft.Reporting.WinForms


''' <summary>
''' Reporte de Remision, este es utilizado para transladar un paciente a otra institución.
''' </summary>
''' <remarks></remarks>
Public Class frmRepRemisionConsultaHC

    Private _historiaClinica As FormatoHistoriaClinica

    Public Sub imprimirRemision(ByVal historiaClinica As FormatoHistoriaClinica)

        _historiaClinica = historiaClinica

        If _historiaClinica.Remision Is Nothing Then
            MsgBox("No existen datos para el paciente.", MsgBoxStyle.Information)
            Exit Sub
        End If

        Me.RemisionPlanManejoBindingSource.DataSource = _historiaClinica.Remision

        setParametrosReporte()

        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub ReportViewer1_RenderingComplete(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.RenderingCompleteEventArgs) Handles ReportViewer1.RenderingComplete
        ''Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
    End Sub

    ''' <summary>
    ''' Establece las variables FechaImpresion, Reimpresion.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub setParametrosReporte()
        Dim aParametros As New List(Of ReportParameter)

        aParametros.Add(New ReportParameter("FechaImpresion", Format(FuncionesGenerales.FechaServidor(), "dd/MM/yyyy HH:mm")))
        aParametros.Add(New ReportParameter("Reimpresion", True))
        ReportViewer1.LocalReport.SetParameters(aParametros)
    End Sub

    Private Sub frmRepRemisionConsultaHC_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If _historiaClinica.SeccionesHC.Recomendaciones Then
            frmRepRecomendacionesConsultaHC.Show()
            frmRepRecomendacionesConsultaHC.imprimirRecomendaciones(_historiaClinica)
            Exit Sub
        End If

        If _historiaClinica.SeccionesHC.Triage Then
            frmRepTriageConsultaHC.Show()
            frmRepTriageConsultaHC.imprimirTriage(_historiaClinica)
        End If
    End Sub

    Private Sub ReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportViewer1.Load

    End Sub
End Class