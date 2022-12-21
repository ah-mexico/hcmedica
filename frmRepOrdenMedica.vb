Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports pacienteHC = HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente.Paciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports System.Collections.Generic
Imports Microsoft.Reporting.WinForms

Public Class frmRepOrdenMedica


    Private listaDietas As List(Of Dieta)
    Private listaMedicamentos As List(Of Medicamento)
    Private listaMedControl As List(Of MedicamentoControl)
    Private listaProcedim As List(Of Procedimiento)
    ' herojas agfa_orm_in 2014/09/24 lista de procedimientos que no se realizan en la institucion
    Private listaProcedimN As List(Of ProcedimientoNoPractica)
    ' herojas agfa_orm_in 2014/09/24 lista de procedimientos que no se realizan en la sede de la orden
    Private listaProcedimNoSede As List(Of ProcedimientoNoSede)

    Private listaOrdenGeneral As List(Of OrdenGeneral)
    Private objConexion As Conexion


    Public Sub imprimirOrdenMedica(ByVal dtDietas As DataTable, ByVal dtMedicamentos As DataTable, _
                                   ByVal dtProcedimientos As DataTable, ByVal dtOrdenGenerales As DataTable, _
                                   ByVal objDatosGenerales As Generales, ByVal objPaciente As pacienteHC, _
                                   ByVal NroOrden As Double, Optional ByVal strCentroCostoOrigen As String = "", Optional ByVal strpractica As String = "")



        listaDietas = Dieta.crearListaDietas(dtDietas)


        listaMedicamentos = New Medicamento().crearListaMedicamentos(dtMedicamentos)


        listaMedControl = New MedicamentoControl().crearListaMedicamentos(dtMedicamentos)

        listaProcedim = New Procedimiento().crearListaProcedimOrdenMedica(dtProcedimientos, strpractica)

        ' herojas agfa_orm_in lista de procedimientos que no realiza la intitucion
        listaProcedimN = New ProcedimientoNoPractica().crearListaProcedimOrdenMedicano(dtProcedimientos, objDatosGenerales.NombreMedico, objDatosGenerales.RegistroMedico, objDatosGenerales.DescripcionEspecialidad)

        ' herojas agfa_orm_in lista de procedimientos que no realiza la sede de la orden
        listaProcedimNoSede = New ProcedimientoNoSede().crearListaProcedimOrdenMedicaNoSede(dtProcedimientos, objDatosGenerales.NombreMedico, objDatosGenerales.RegistroMedico, objDatosGenerales.DescripcionEspecialidad)

        listaOrdenGeneral = OrdenGeneral.crearListaOrdenesGenerales(dtOrdenGenerales)

        asignarNroOrden(NroOrden)
        'jlalfonso
        '2009-01-08. permite traer el numero de pedido de los procedimientos
        traerProceOrdenMedica(objConexion, objDatosGenerales.Prestador, objDatosGenerales.Sucursal, objPaciente.TipoAdmision, _
                               objPaciente.AnoAdmision, objPaciente.NumeroAdmision, NroOrden, strpractica)

        ProcedimientoBindingSource.DataSource = listaProcedim
        'ProcedimientoNBindingSource.DataSource = listaProcedimN
        'ProcedimientoNoSedeBindingSource.DataSource = listaProcedimNoSede
        MedicamentoBindingSource.DataSource = listaMedicamentos
        If objDatosGenerales.Pais = "482" Then
            Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "HistoriaClinica.RepOrdenesMedicasPeru.rdlc"
        Else
            Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "HistoriaClinica.RepOrdenesMedicas.rdlc"
        End If
        asignarParametros(objDatosGenerales, objPaciente, NroOrden, strCentroCostoOrigen)



        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEventHandler
        Me.ReportViewer1.RefreshReport()
    End Sub

    Public Sub reimprimirOrdenMedica(ByVal objConexion As Conexion, ByVal cod_pre_sgs As String, _
                                     ByVal cod_sucur As String, ByVal tip_admision As String, _
                                     ByVal ano_adm As String, ByVal num_adm As String, _
                                     ByVal NroOrden As Double)

        Dim objOrden As New Orden
        Dim lError As Long
        Dim objDatosGenerales As Generales

        objDatosGenerales = Generales.Instancia

        Try

            'If objDatosGenerales.Pais = "482" Then
            'lError = objOrden.crearOrdenMedicaReimpresionPeru(objConexion, cod_pre_sgs, cod_sucur, _
            '                                                     tip_admision, ano_adm, num_adm)

            'Else
            lError = objOrden.crearOrdenMedicaReimpresion(objConexion, cod_pre_sgs, cod_sucur, _
                                                                  tip_admision, ano_adm, num_adm, NroOrden)

            'End If

            If lError <> 0 Then
                If lError = 99 Then
                    MsgBox("No existe información para el número de orden suministrado. ")
                Else
                    MsgBox("Error en la consulta de la orden médica. ")
                End If

                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("Error en la consulta de la orden médica. ")
            Exit Sub
        End Try

        With objOrden
            listaDietas = .Dietas
            listaMedicamentos = .Medicamentos
            listaMedControl = .MedicamentosControl
            listaProcedim = .Procedimientos
            listaOrdenGeneral = .OrdenesGenerales
            ' listaProcedimN = .ProcedimientosN
        End With

        ProcedimientoBindingSource.DataSource = listaProcedim
        MedicamentoBindingSource.DataSource = listaMedicamentos

        If objDatosGenerales.Pais = "482" Then
            Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "HistoriaClinica.RepOrdenesMedicasPeru.rdlc"
        Else
            Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "HistoriaClinica.RepOrdenesMedicas.rdlc"
        End If

        asignarParametrosReimpresion(objOrden)

        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEventHandler
        Me.ReportViewer1.RefreshReport()


    End Sub
    'jlalfonso-2009-01-09
    'permite traer orden medica y obtener el numero de pedido de los procedimientos.
    Public Sub traerProceOrdenMedica(ByVal objConexion As Conexion, ByVal cod_pre_sgs As String, _
                                   ByVal cod_sucur As String, ByVal tip_admision As String, _
                                   ByVal ano_adm As String, ByVal num_adm As String, _
                                   ByVal NroOrden As Double, Optional ByVal strPracticaOsi As String = "")

        Dim objOrden As New Orden
        Dim lError As Long

        Try
            lError = objOrden.crearOrdenMedicaReimpresion(objConexion, cod_pre_sgs, cod_sucur, _
                                                          tip_admision, ano_adm, num_adm, NroOrden, strPracticaOsi)
            If lError <> 0 Then
                If lError = 99 Then
                    MsgBox("No existe información para el número de orden suministrado. ")
                Else
                    MsgBox("Error en la consulta de la orden médica. ")
                End If

                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("Error en la consulta de la orden médica. ")
            Exit Sub
        End Try

        With objOrden
            listaProcedim = .Procedimientos
            ' listaProcedimN = .ProcedimientosN
        End With
    End Sub

    Private Sub ReportViewer1_RenderingComplete(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.RenderingCompleteEventArgs) Handles ReportViewer1.RenderingComplete
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
    End Sub

    Public Sub asignarParametros(ByVal objDatosGenerales As Generales, ByVal objPaciente As pacienteHC, _
                                 ByVal NroOrden As Double, Optional ByVal strCentroCostoOrigen As String = "")

        Dim aParametros(23) As ReportParameter

        Dim strcondicion As String
        Dim strentidad As String
        Dim StrCarnet As String
        Dim objGenerales As New DAOGeneral()


        strcondicion = "descripcion='" & objPaciente.DescripcionEntidad & "'"

        strentidad = objGenerales.EjecutarSQLStrValor("genentid", objConexion, "entidad", strcondicion)

        strcondicion = ""

        strcondicion = "tip_doc='" & objPaciente.TipoDocumento & "' AND " & _
                       "num_doc='" & objPaciente.NumeroDocumento & "' AND " & _
          "cod_sucur='" & objDatosGenerales.Sucursal & "' AND entidad= '" & strentidad & "'"

        StrCarnet = objGenerales.EjecutarSQLStrValor("genpacen", objConexion, "distinct carnet", strcondicion)

        If Len(StrCarnet) = 0 Then
            StrCarnet = ""
        End If

        With objDatosGenerales
            aParametros(0) = New ReportParameter("Sucursal", .DescripcionSucursal)
            aParametros(1) = New ReportParameter("Medico", .NombreMedico)
            aParametros(2) = New ReportParameter("RegistroMedico", .RegistroMedico)
            aParametros(3) = New ReportParameter("Especialidad", .DescripcionEspecialidad)
        End With

        With objPaciente
            aParametros(4) = New ReportParameter("NumDoc", .NumeroDocumento)
            aParametros(5) = New ReportParameter("TipDoc", .TipoDocumento)
            aParametros(6) = New ReportParameter("NroAdmision", .TipoAdmision & " " & .AnoAdmision & " " & .NumeroAdmision)
            aParametros(7) = New ReportParameter("Entidad", .DescripcionEntidad)
            aParametros(8) = New ReportParameter("Nombre", .NombreCompleto)
            aParametros(9) = New ReportParameter("Edad", .Edad & " " & .DescripcionUnidadMedidaEdad)
            aParametros(10) = New ReportParameter("Sexo", .Genero)
            aParametros(11) = New ReportParameter("Grupo", .GrupoSanguineo)
            aParametros(12) = New ReportParameter("RH", .RH)
            aParametros(13) = New ReportParameter("Ciudad", .Ciudad)
            aParametros(14) = New ReportParameter("Pais", .Pais)
            aParametros(15) = New ReportParameter("dirSucursal", .DirSucursal)
            aParametros(16) = New ReportParameter("telSucursal", .telSucursal)



        End With

        aParametros(17) = New ReportParameter("Fecha", Format(FuncionesGenerales.FechaServidor(), "dd/MM/yyyy"))
        aParametros(18) = New ReportParameter("Hora", Format(FuncionesGenerales.FechaServidor(), "HH:mm"))
        aParametros(19) = New ReportParameter("NroOrden", NroOrden)
        aParametros(20) = New ReportParameter("CentroCostoOrigen", strCentroCostoOrigen)
        aParametros(21) = New ReportParameter("EsReimpresion", False)
        aParametros(22) = New ReportParameter("Carnet", StrCarnet)

        aParametros(23) = New ReportParameter("FechaImpresion", Format(FuncionesGenerales.FechaServidor(), "dd/MM/yyyy HH:mm"))

      
        

        ReportViewer1.LocalReport.SetParameters(aParametros)
    End Sub
    Public Sub asignarParametrosReimpresion(ByVal objOrden As Orden)

        Dim aParametros(23) As ReportParameter
        Dim strcondicion As String
        Dim strentidad As String
        Dim StrCarnet As String
        Dim objGenerales As New DAOGeneral()

        ''Consultamos el numero de carnet del paciente

        strcondicion = "descripcion='" & objOrden.EntidadPrestadora & "'"

        strentidad = objGenerales.EjecutarSQLStrValor("genentid", objConexion, "entidad", strcondicion)

        strcondicion = ""


        strcondicion = "tip_doc='" & objOrden.Paciente.TipoDocumento & "' AND " & _
                       "num_doc='" & objOrden.Paciente.NumeroDocumento & "' AND " & _
          "cod_sucur='" & objOrden.CodigoSucursal & "' AND entidad= '" & strentidad & "'"

        StrCarnet = objGenerales.EjecutarSQLStrValor("genpacen", objConexion, "distinct carnet", strcondicion)

        If Len(StrCarnet) = 0 Then
            StrCarnet = ""
        End If

        With objOrden
            aParametros(0) = New ReportParameter("Sucursal", .Sucursal)
            aParametros(1) = New ReportParameter("Medico", .NombreMedico)
            aParametros(2) = New ReportParameter("RegistroMedico", .RegistroMedico)
            aParametros(3) = New ReportParameter("Especialidad", .Especialidad)
            aParametros(4) = New ReportParameter("NumDoc", .Paciente.NumeroDocumento)
            aParametros(5) = New ReportParameter("TipDoc", .Paciente.TipoDocumento)
            aParametros(6) = New ReportParameter("NroAdmision", .TipoAdmision & " " & .AnoAdmision & " " & .NumeroAdmision)
            aParametros(7) = New ReportParameter("Entidad", .EntidadPrestadora)
            aParametros(8) = New ReportParameter("Nombre", .Paciente.Nombre)
            aParametros(9) = New ReportParameter("Edad", .Paciente.Edad & " " & .Paciente.UnidadEdad)
            aParametros(10) = New ReportParameter("Sexo", .Paciente.DescripSexo)
            aParametros(11) = New ReportParameter("Grupo", .Paciente.GrupoSanguineo)
            aParametros(12) = New ReportParameter("RH", .Paciente.FactorRH)
            aParametros(13) = New ReportParameter("Fecha", Format(CDate(.Fecha), "dd/MM/yyyy"))
            aParametros(14) = New ReportParameter("Hora", Format(CDate(.Fecha), "HH:mm"))
            aParametros(15) = New ReportParameter("NroOrden", .NumeroOrden)
            aParametros(16) = New ReportParameter("CentroCostoOrigen", .DescripcionCentroDeCostoOrigen)
            aParametros(17) = New ReportParameter("EsReimpresion", True)
            aParametros(18) = New ReportParameter("Ciudad", "")
            aParametros(19) = New ReportParameter("Pais", "")
            aParametros(20) = New ReportParameter("dirSucursal", "")
            aParametros(21) = New ReportParameter("telSucursal", "")
            aParametros(22) = New ReportParameter("FechaImpresion", Format(FuncionesGenerales.FechaServidor(), "dd/MM/yyyy HH:mm"))

        End With
        aParametros(23) = New ReportParameter("Carnet", StrCarnet)

        ReportViewer1.LocalReport.SetParameters(aParametros)

    End Sub

    Public Sub asignarNroOrden(ByVal NroOrden As Double)
        Dim objDieta As Dieta
        Dim objMedica As Medicamento
        Dim objProcedim As Procedimiento
        Dim objOrdenGeneral As OrdenGeneral

        For Each objDieta In listaDietas
            objDieta.NumeroOrden = NroOrden
        Next

        For Each objMedica In listaMedicamentos
            objMedica.NumeroOrden = NroOrden
        Next

        For Each objProcedim In listaProcedim
            objProcedim.NumeroOrden = NroOrden
        Next

        For Each objOrdenGeneral In listaOrdenGeneral
            objOrdenGeneral.NumeroOrden = NroOrden
        Next
    End Sub
    Public Sub SubreportProcessingEventHandler(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)

        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Dieta", listaDietas))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Medicamento", listaMedicamentos))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_MedicamentoControl", listaMedControl))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Procedimiento", listaProcedim))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_OrdenGeneral", listaOrdenGeneral))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_ProcedimientoNoPractica", listaProcedimN))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_ProcedimientoNoSede", listaProcedimNoSede))

    End Sub

    Private Sub frmRepOrdenMedica_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class