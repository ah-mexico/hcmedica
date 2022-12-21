Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports System.Collections.Generic
Imports Microsoft.Reporting.WinForms

Public Class frmRepSeccionesAdicionales

    Private _remision As RemisionPlanManejo
    Private _recomendaciones As RecomendacionEgreso
    Private _triage As Triage

    Public Sub imprimirSeccionesAdicionales(ByVal objRemision As RemisionPlanManejo, ByVal objRecomendaciones As RecomendacionEgreso, _
                                            ByVal objTriage As Triage)

        _remision = objRemision
        _recomendaciones = objRecomendaciones
        _triage = objTriage
        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEventHandler
        setParametrosReporte()

        Me.ReportViewer1.RefreshReport()

    End Sub

    Public Sub SubreportProcessingEventHandler(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)

        Dim bsSource As New BindingSource()

        bsSource.DataSource = _remision
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_RemisionPlanManejo", bsSource))

        bsSource = New BindingSource()
        bsSource.DataSource = _recomendaciones
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_RecomendacionEgreso", bsSource))

        If Not _recomendaciones Is Nothing Then
            bsSource = New BindingSource()
            bsSource.DataSource = _recomendaciones.Medicamentos
            e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Comunes_ObjetoAuxiliar", bsSource))

            bsSource = New BindingSource()
            bsSource.DataSource = _recomendaciones.Procedimientos
            e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Comunes_ObjetoSimple", bsSource))
        Else
            bsSource = New BindingSource()
            bsSource.DataSource = Nothing
            e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Comunes_ObjetoAuxiliar", bsSource))
            e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Comunes_ObjetoSimple", bsSource))
        End If

        bsSource = New BindingSource()
        bsSource.DataSource = _triage
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Triage", bsSource))

        If Not _triage Is Nothing Then
            bsSource = New BindingSource()
            bsSource.DataSource = _triage.Paciente
        Else
            bsSource = New BindingSource()
            bsSource.DataSource = Nothing
        End If

        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Paciente", bsSource))

    End Sub

    Public Sub setParametrosReporte()
        Dim aParametros As New List(Of ReportParameter)

        aParametros.Add(New ReportParameter("FechaImpresion", Format(FuncionesGenerales.FechaServidor(), "dd/MM/yyyy HH:mm")))
        aParametros.Add(New ReportParameter("HayRemision", _remision Is Nothing))
        aParametros.Add(New ReportParameter("HayRecomendaciones", _recomendaciones Is Nothing))
        ReportViewer1.LocalReport.SetParameters(aParametros)
    End Sub

End Class