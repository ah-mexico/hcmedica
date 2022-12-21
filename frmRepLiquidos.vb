Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes
Imports System.Collections.Generic
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports Microsoft.Reporting.WinForms

Public Class frmRepLiquidos
    Dim objLiquidosAdmin As List(Of Liquidos)
    Dim objLiquidosElim As List(Of LiquidosElim)
    Dim objBalances As List(Of Balances)
    Dim m_CantDias As Integer = 0
    Dim m_CodHistoria As Integer = 0
    Dim m_fechaInicial As String = String.Empty
    Dim m_Conexion As Conexion
    Dim m_strnombrelogin As String

    Dim m_Peso As Double = 0
    Dim m_Edad As Double = 0
    '' Dim objLiquidosElim As List(Of LiquidosElim)
    Dim objHcEnfEncabezado As New HCEnfEncabezado()   'Informacion del encabezado del reporte

    ''Se modifica metodo - dsanchez 15/09/2017
    Public Sub imprimirRepLiquidosAdmin(ByVal objConexion As Conexion, ByVal dCod_Historia As Integer, ByVal fechaInicial As String, ByVal cantDias As Integer, ByVal peso As Double, ByVal edad As Double)
        Try
            Dim logintmp As String

            Me.ReportViewer1.LocalReport.DisplayName = "Control_de_Liquidos"

            m_CantDias = cantDias
            m_CodHistoria = dCod_Historia
            m_Conexion = objConexion
            m_fechaInicial = fechaInicial
            m_Peso = peso
            m_Edad = edad
            'Se llena el encabezado de la Historia Clinica. Contiene informacion 
            'de la admision, del paciente y la historia clinica
            objHcEnfEncabezado.consultarHcEnfEncabezado(objConexion, dCod_Historia)

            'Se lena el objeto de liquidos administrados y eliminados
            objLiquidosAdmin = New Liquidos().consultarLiquidosAdmin(objConexion, dCod_Historia, fechaInicial, "LA", cantDias)
            'objLiquidosElim = New LiquidosElim().consultarLiquidosEliminados(objConexion, dCod_Historia, fechaInicial, "LE", cantDias)
            objBalances = New Balances().consultarRepBalances(dCod_Historia, fechaInicial, cantDias)
            'Se asigna el objeto con la info del encabezado al datasource
            'que se asocio al reporte 
            Me.HCEnfEncabezadoBindingSource.DataSource = objHcEnfEncabezado

            'Se asigna el objeto con la info del paciente al datasource
            'que se asocio al reporte
            Me.PacienteBindingSource.DataSource = objHcEnfEncabezado.Paciente
            Me.LiquidoBindingSource1.DataSource = objLiquidosAdmin

            Dim dtDatos As DataTable

            logintmp = Generales.Instancia.Login

            dtDatos = BLPlaneacion.Consultarlogin(m_Conexion, logintmp)

            If dtDatos.Rows.Count > 0 Then
                m_strnombrelogin = dtDatos.Rows(0).Item("nombre").ToString
            End If

        Catch ex As Exception
            MsgBox("Error en la impresion. " & ex.Message, MsgBoxStyle.Critical)
        End Try

        ''Se define que el metodo SubreportProcessingEventHandler maneja el evento ReportViewer1.LocalReport.SubreportProcessing 
        ''del Reporte. Este evento ocurre cuando se procesan los subreportes contenidos en el reporte principal
        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEventHandler

        setParametrosReporte()

        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)

        'Se pinta el reporte
        Me.ReportViewer1.RefreshReport()

    End Sub

    Private Sub ReportViewer1_RenderingComplete(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.RenderingCompleteEventArgs) Handles ReportViewer1.RenderingComplete
        'Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
    End Sub

    ''Se modifica evento - dsanchez 15/09/2017
    Public Sub SubreportProcessingEventHandler(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)
        'Dim bsSource As New BindingSource()
        e.DataSources.Add(New ReportDataSource("Enfermeria_Sophia_HistoriaClinica_Reportes_Liquidos", objLiquidosAdmin))
        e.DataSources.Add(New ReportDataSource("Enfermeria_Sophia_HistoriaClinica_Reportes_Balances", objBalances))
    End Sub

    Public Sub setParametrosReporte()
        Dim aParametros(21) As ReportParameter

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
            aParametros(13) = New ReportParameter("Ciudad", UCase(.Ciudad))
            aParametros(14) = New ReportParameter("Pais", UCase(.Pais))
            aParametros(15) = New ReportParameter("dirSucursal", UCase(.DirSucursal))
            aParametros(16) = New ReportParameter("telSucursal", UCase(.telSucursal))
            aParametros(17) = New ReportParameter("Prestador", .Prestador)
            aParametros(18) = New ReportParameter("Religion", .Paciente.Religion)
            aParametros(19) = New ReportParameter("Ubicacion", .Paciente.Ubicacion)
            aParametros(20) = New ReportParameter("EdadAMD", .Paciente.EdadAMD)
            aParametros(21) = New ReportParameter("loginIMP", UCase(m_strnombrelogin))
        End With

        ReportViewer1.LocalReport.SetParameters(aParametros)

    End Sub

End Class