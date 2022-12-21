Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports System.Collections.Generic
Imports Microsoft.Reporting.WinForms

Public Class frmRepOrdenPatologia
    Dim objDescripcionQxParametros As List(Of DescripcionQx)
    Dim objDiagnostico As List(Of HistoriaClinica.Sophia.HistoriaClinica.Reportes.Diagnostico)
    Dim objDiagnostico1 As List(Of HistoriaClinica.Sophia.HistoriaClinica.Reportes.Diagnostico)
    Dim objOrdenPatologia As List(Of OrdenPatologia)
    Dim dtEquipoMedico As DataTable
    Dim dtDescqx As DataTable
    Private objDesc As New DescripcionQx
    Private blnEsReimpresion As Boolean
    Dim objHcEncabezado As New HCEncabezado()
    Public objDatosGenerales As objGeneral.Generales
    Public Sub imprimirOrdenPatologia(ByVal strCodigoPrestador As String, ByVal strCodigoSucursal As String, _
    ByVal strProcedim As String, ByVal strConsecutivo As Decimal, ByVal secuencia As Integer, ByVal strTip_admision As String, ByVal iAno_adm As Integer, ByVal lNum_adm As String, _
      Optional ByVal strTip_Doc As String = "", Optional ByVal strNum_Doc As String = "")

        Try
            Dim objconexion As Conexion
            Dim dsresultados As DataSet
            Dim dsresultados1 As DataSet
            Dim row() As DataRow
            Dim dtDescqx As New DataTable
            objDatosGenerales = objGeneral.Generales.Instancia

            objHcEncabezado.consultarHcEncabezado(objconexion, strCodigoPrestador, strCodigoSucursal, _
                            strTip_admision, iAno_adm, lNum_adm)



            dsresultados = New OrdenPatologia().ConsultarReporteOrdenPatologia(strCodigoPrestador, strCodigoSucursal, strProcedim, strConsecutivo, strTip_admision, iAno_adm, lNum_adm, strTip_Doc, strNum_Doc)
            objOrdenPatologia = New OrdenPatologia().CargarReporteOrdenPatologia(dsresultados.Tables(0))


            dsresultados1 = New DescripcionQx().ConsultarReporteDescripcionQX(strCodigoPrestador, strCodigoSucursal, strProcedim, strConsecutivo, secuencia, strTip_admision, iAno_adm, lNum_adm, strTip_Doc, strNum_Doc)
            objDiagnostico = New DescripcionQx().CargarDiagnosticoDescripcionQX(dsresultados1.Tables(0))

            dtDescqx = dsresultados.Tables(0)

            HCEncabezadoBindingSource.DataSource = objHcEncabezado
            PacienteBindingSource.DataSource = objHcEncabezado.Paciente
            PatologiaBindingSource.DataSource = objOrdenPatologia
            Me.DiagnosticoBindingSource.DataSource = objDiagnostico




            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEventHandler


            If dtDescqx.Rows.Count > 0 Then
                setParametrosReporte()
            End If



            'Se pinta el reporte

            Me.ReportViewer1.RefreshReport()
        Catch ex As Exception
            MsgBox("Error en la impresion. " & ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Public Sub setParametrosReporte()

        Dim aParametros(17) As ReportParameter

        aParametros(0) = New ReportParameter("Medico", "")
        aParametros(1) = New ReportParameter("Especialidad", "")
        aParametros(2) = New ReportParameter("RegistroMedico", "")

        With objHcEncabezado


            aParametros(3) = New ReportParameter("Sucursal", .Sucursal)
            aParametros(4) = New ReportParameter("NroHistoria", .Paciente.NumeroDocumento)
            aParametros(5) = New ReportParameter("Fecha", .Fecha)
            aParametros(6) = New ReportParameter("Hora", .Hora & " : " & .Minuto)
            aParametros(7) = New ReportParameter("NroAdmision", .TipoAdmision & " " & .AnoAdmision & " " & .NumeroAdmision)
            aParametros(8) = New ReportParameter("Entidad", .Entidad)
            aParametros(9) = New ReportParameter("Paciente", .Paciente.TipoDocumento & " " & .Paciente.NumeroDocumento)
            aParametros(10) = New ReportParameter("Nombre", .Paciente.Nombre)
            aParametros(11) = New ReportParameter("Edad", .Paciente.Edad & " " & .Paciente.UnidadEdad)
            aParametros(12) = New ReportParameter("Sexo", .Paciente.DescripSexo)
            aParametros(13) = New ReportParameter("Grupo", .Paciente.GrupoSanguineo)
            aParametros(14) = New ReportParameter("RH", .Paciente.FactorRH)
            aParametros(15) = New ReportParameter("FechaImpresion", Format(FuncionesGenerales.FechaServidor(), "dd/MM/yyyy HH:mm"))
            aParametros(16) = New ReportParameter("Pais", .Pais)
            aParametros(17) = New ReportParameter("Secuencia", .secuencia)
        End With
    
        ReportViewer1.LocalReport.SetParameters(aParametros)

    End Sub

    Private Sub ReportViewer1_RenderingComplete(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.RenderingCompleteEventArgs) Handles ReportViewer1.RenderingComplete
        ''Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
    End Sub
    Public Sub SubreportProcessingEventHandler(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)

        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Diagnostico", objDiagnostico))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_DescripcionQx", objDescripcionQxParametros))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_OrdenPatologia", objOrdenPatologia))

    End Sub

End Class