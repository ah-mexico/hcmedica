Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
'Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports pacienteHC = HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente.Paciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports System.Collections.Generic
Imports Microsoft.Reporting.WinForms

Public Class frmRepOrdenesMedicasXAdmision

    Private listaAislamientos As List(Of Aislamiento)
    Private listaDietas As List(Of Dieta)
    Private listaMedicamentos As List(Of Medicamento)
    Private listaProcedim As List(Of Procedimiento)
    Private listaOrdenGeneral As List(Of OrdenGeneral)
    Private Conexion As Conexion
    Private codSucur As String




    Public Sub imprimirOrdenMedica(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String, _
                   ByVal strCod_sucur As String, ByVal strTip_admision As String, _
                   ByVal iAno_adm As String, ByVal lNum_adm As Long, ByVal objpaciente As pacienteHC)

        Dim listaOrdenes As List(Of Orden)
        Dim dtEncabezadoOrden As DataTable = Nothing
        Dim objDatosGenerales As objGeneral.Generales

        objDatosGenerales = objGeneral.Generales.Instancia
        objpaciente = pacienteHC.Instancia

        Conexion = objConexion
        codSucur = strCod_sucur
        Try

            If objDatosGenerales.Pais = "482" Then
                listaOrdenes = New Orden().ConsultarOrdenesMedicas(objConexion, strcod_pre_sgs, _
                                                        strCod_sucur, strTip_admision, _
                                                        iAno_adm, lNum_adm, listaProcedim, _
                                                        dtEncabezadoOrden)

                OrdenBindingSource.DataSource = listaOrdenes

                asignarParametros(dtEncabezadoOrden, objpaciente, objDatosGenerales)
            Else
                listaOrdenes = New Orden().ConsultarOrdenesMedicas(objConexion, strcod_pre_sgs,
                                        strCod_sucur, strTip_admision,
                                        iAno_adm, lNum_adm, listaAislamientos, listaDietas,
                                        listaMedicamentos, listaProcedim,
                                        listaOrdenGeneral, dtEncabezadoOrden)

                OrdenBindingSource.DataSource = listaOrdenes

                asignarParametros(dtEncabezadoOrden, objpaciente, objDatosGenerales)
            End If


        Catch ex As Exception
            MsgBox("Error en la consulta de las Ordenes Medicas", MsgBoxStyle.Information)
            Exit Sub
        End Try

        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEventHandler
        Me.ReportViewer1.RefreshReport()
    End Sub
    Public Sub asignarParametros(ByVal dtEncabezadoOrden As DataTable, ByVal objpaciente1 As pacienteHC, ByVal objDatosGenerales As objGeneral.Generales)

        Dim aParametros(15) As ReportParameter
        Dim objPaciente As New Paciente
        Dim edad As Integer
        Dim unidadEdad As String = ""
        Dim StrCarnet As String
        Dim objGenerales As New DAOGeneral()
        'Dim objconexion As New Conexion
        Dim strcondicion As String
        Dim strentidad As String




        If dtEncabezadoOrden.Rows.Count <= 0 Then
            MsgBox("Error en la consulta del encabezado de la Orden")
            Exit Sub
        End If


        strcondicion = "descripcion='" & dtEncabezadoOrden.Rows(0).Item("entidad") & "'"

        strentidad = objGenerales.EjecutarSQLStrValor("genentid", Conexion, "entidad", strcondicion)

        strcondicion = ""

        strcondicion = "tip_doc='" & dtEncabezadoOrden.Rows(0).Item("tip_doc") & "' AND " & _
                        "num_doc='" & dtEncabezadoOrden.Rows(0).Item("Num_doc") & "' AND " & _
         "cod_sucur='" & codSucur & "'AND entidad= '" & strentidad & "'"

        StrCarnet = objGenerales.EjecutarSQLStrValor("genpacen", Conexion, "distinct carnet", strcondicion)
        If Len(StrCarnet) = 0 Then
            StrCarnet = ""
        End If

        With dtEncabezadoOrden.Rows(0)
            aParametros(0) = New ReportParameter("Sucursal", .Item("sucursal").ToString)
            aParametros(1) = New ReportParameter("NumDoc", .Item("Num_doc").ToString)
            aParametros(2) = New ReportParameter("TipDoc", .Item("tip_doc").ToString)
            aParametros(3) = New ReportParameter("NroAdmision", .Item("tip_admision").ToString & " " & .Item("ano_adm").ToString & " " & .Item("num_adm").ToString)
            aParametros(4) = New ReportParameter("Entidad", .Item("entidad").ToString)
            aParametros(5) = New ReportParameter("Nombre", .Item("paciente").ToString)
            edad = objPaciente.calcularEdad(.Item("fec_nac").ToString, unidadEdad)
        End With
        With objpaciente1
            aParametros(6) = New ReportParameter("Edad", .EdadAMD)
        End With
        With dtEncabezadoOrden.Rows(0)
            aParametros(7) = New ReportParameter("Sexo", .Item("sexo").ToString)
            aParametros(8) = New ReportParameter("Grupo", .Item("gru_sanguineo").ToString)
            aParametros(9) = New ReportParameter("RH", .Item("rh").ToString)
        End With

        With objpaciente1
            aParametros(10) = New ReportParameter("Fecha", .FechaHoraAdmision)
        End With

        aParametros(11) = New ReportParameter("Hora", Format(FuncionesGenerales.FechaServidor(), "dd/MM/yyyy HH:mm"))
        aParametros(12) = New ReportParameter("Carnet", StrCarnet)

        With objpaciente1
            aParametros(13) = New ReportParameter("Ubicacion", .Ubicacion)
            aParametros(14) = New ReportParameter("Religion", .Religion)
        End With
        With objDatosGenerales
            aParametros(15) = New ReportParameter("Prestador", .DescripcionPrestador)
        End With


        ReportViewer1.LocalReport.SetParameters(aParametros)
    End Sub

    Public Sub SubreportProcessingEventHandler(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)

        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Aislamiento", listaAislamientos))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Dieta", listaDietas))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Medicamento", listaMedicamentos))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Procedimiento", listaProcedim))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_OrdenGeneral", listaOrdenGeneral))

    End Sub

    'Private Sub ReportViewer1_RenderingComplete(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.RenderingCompleteEventArgs) Handles ReportViewer1.RenderingComplete
    '    'Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
    '    'Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
    'End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
    End Sub
End Class