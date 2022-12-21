Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports pacienteHC = HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente.Paciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports System.Collections.Generic
Imports Microsoft.Reporting.WinForms
Public Class frmRepSegDolor
    Dim objHcEnfEncabezado As New HCEnfEncabezado()
    Dim objNotasSeccionSD As DataTable
    Private objConexion As Conexion


    Public Sub ImprimirReporteSeguimientoDolor(ByVal objConexion As Conexion, ByVal dCod_Historia As Long, ByVal strFechaIni_RecNac As Nullable(Of DateTime), ByVal strFechaFin_RecNac As Nullable(Of DateTime), ByVal iHoraIni_RecNac As Nullable(Of Integer), ByVal iHoraFin_RecNac As Nullable(Of Integer))
        Try

            'Se llena el encabezado de la Historia Clinica. Contiene informacion 
            'de la admision, del paciente y la historia clinica
            objHcEnfEncabezado.consultarHcEnfEncabezado(objConexion, dCod_Historia)

            'Se llena el objeto que almacena infomacion del recien nacido
            objNotasSeccionSD = New SubseccionSD().consultarMonitoreoSubseccionSD(objConexion, dCod_Historia, strFechaIni_RecNac, strFechaFin_RecNac, iHoraIni_RecNac, iHoraFin_RecNac)

            objNotasSeccionSD.Columns(5).ColumnName = "Saturacion"

            Me.HCEnfEncabezadoBindingSource.DataSource = objHcEnfEncabezado

            'Se asigna el objeto con la info del paciente al datasource
            'que se asocio al reporte
            Me.PacienteBindingSource.DataSource = objHcEnfEncabezado.Paciente

        Catch ex As Exception
            MsgBox("Error en la impresion. " & ex.Message, MsgBoxStyle.Critical)
        End Try

        ''Se define que el metodo SubreportProcessingEventHandler maneja el evento ReportViewer1.LocalReport.SubreportProcessing 
        ''del Reporte. Este evento ocurre cuando se procesan los subreportes contenidos en el reporte principal
        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEventHandler

        setParametrosReporte()

        'Se pinta el reporte
        Me.ReportViewer1.RefreshReport()
    End Sub


    Public Sub SubreportProcessingEventHandler(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)
        Dim bsSource As New BindingSource()

        e.DataSources.Add(New ReportDataSource("dsTraerMonitoreoSubseccionSD_HCENF_TraerMonitoreoSubseccionSD", objNotasSeccionSD))
        '        e.DataSources.Add(New ReportDataSource("dsTraerMonitoreoSubseccionSD_HCENF_TraerMonitoreoSubseccionSD", objNotasSeccionSD))
    End Sub

    Public Sub setParametrosReporte()
        Dim aParametros(12) As ReportParameter

        With objHcEnfEncabezado
            aParametros(0) = New ReportParameter("Sucursal", .Sucursal)
            aParametros(1) = New ReportParameter("NroHistoria", .Paciente.NumeroDocumento)
            aParametros(2) = New ReportParameter("Fecha", .Fecha)
            aParametros(3) = New ReportParameter("Hora", .Hora & " : " & .Minuto)
            aParametros(4) = New ReportParameter("NroAdmision", .TipoAdmision & " " & .AnoAdmision & " " & .NumeroAdmision)
            aParametros(5) = New ReportParameter("Entidad", .Entidad)
            aParametros(6) = New ReportParameter("Paciente", .Paciente.TipoDocumento & " " & .Paciente.NumeroDocumento)
            aParametros(7) = New ReportParameter("Nombre", .Paciente.Nombre)
            aParametros(8) = New ReportParameter("Edad", .Paciente.Edad & " " & .Paciente.UnidadEdad)
            aParametros(9) = New ReportParameter("Sexo", .Paciente.DescripSexo)
            aParametros(10) = New ReportParameter("Grupo", .Paciente.GrupoSanguineo)
            aParametros(11) = New ReportParameter("RH", .Paciente.FactorRH)
            aParametros(12) = New ReportParameter("FechaImpresion", Format(FuncionesGenerales.FechaServidor(), "dd/MM/yyyy HH:mm"))
            'aParametros(13) = New ReportParameter("Ciudad", .Ciudad)
            'aParametros(14) = New ReportParameter("Pais", .Pais)
            'aParametros(15) = New ReportParameter("dirSucursal", .DirSucursal)
            'aParametros(16) = New ReportParameter("telSucursal", .TelSucursal)
        End With

        ReportViewer1.LocalReport.SetParameters(aParametros)

    End Sub
End Class