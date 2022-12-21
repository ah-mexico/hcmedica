Imports HistoriaClinica.Sophia.HistoriaClinica.BL.BLOrdenes
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports objPaciente = HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente.Paciente

Imports objGenerales = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales.Generales
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports System.Collections.Generic
Imports HistoriaClinica.Sophia.HistoriaClinica

Public Class BLConciliacionMedicamentos


    Dim ObjGeneral As objGenerales

    Public Shared Sub procesarCampoTratamiento1(ByRef dtDatos As DataTable, ByVal valor As String, ByVal eAccion As Accion)

        Dim rowArray() As DataRow
        Dim row As DataRow

        If eAccion = Accion.Cargar Then ''Cargar
            rowArray = dtDatos.Select("tratamiento = '" & valor & "'")

            ' For Each row In rowArray
            'row.BeginEdit()
            'row.Item("tratamiento") = Nothing
            'row.EndEdit()
            ' Next

        ElseIf eAccion = Accion.Grabar Then ''Grabar
            rowArray = dtDatos.Select("tratamiento is null")

            For Each row In rowArray
                'row.BeginEdit()
                row.Item("tratamiento") = valor
                'row.EndEdit()
            Next

        End If
    End Sub


    Public Shared Function consultarMedicamentosConciliados(ByVal objConexion As Conexion, ByVal strCod_pre_sgs As String, ByVal strCod_sucur As String,
                                               ByVal strTip_Admision As String, ByVal strAno_Adm As Integer,
                                               ByVal strNum_Adm As Double) As DataSet

        Dim dsDatos As DataSet
        Dim daoOrden As New DAOConciliacionMedicamentos()
        dsDatos = daoOrden.consultarMedicamentosConciliados(objConexion, strCod_pre_sgs, strCod_sucur, strTip_Admision,
                                              strAno_Adm, strNum_Adm)
        With dsDatos

            .Tables(0).TableName = "MEDICAMENTOS"


            procesarCampoTratamiento(.Tables("MEDICAMENTOS"), INICIA, Accion.Cargar)

        End With


        Return dsDatos
    End Function

    Public Shared Function consultarMedicamentosConciliadosSuspen(ByVal objConexion As Conexion, ByVal strCod_pre_sgs As String, ByVal strCod_sucur As String,
                                               ByVal strTip_Admision As String, ByVal strAno_Adm As Integer,
                                               ByVal strNum_Adm As Double) As DataSet

        Dim dsDatos As DataSet
        Dim daoOrden As New DAOConciliacionMedicamentos()
        dsDatos = daoOrden.consultarMedicamentosNoConciliadosSuspend(objConexion, strCod_pre_sgs, strCod_sucur, strTip_Admision,
                                          strAno_Adm, strNum_Adm)
        With dsDatos

            .Tables(0).TableName = "MEDICAMENTOSSUS"


            procesarCampoTratamiento(.Tables("MEDICAMENTOSSUS"), INICIA, Accion.Cargar)

        End With


        Return dsDatos
    End Function

    Public Shared Function consultarMedicamentosConciliadosOtros(ByVal objConexion As Conexion, ByVal strCod_pre_sgs As String, ByVal strCod_sucur As String,
                                             ByVal strTip_Admision As String, ByVal strAno_Adm As Integer,
                                             ByVal strNum_Adm As Double) As DataSet

        Dim dsDatos As DataSet
        Dim daoOrden As New DAOConciliacionMedicamentos()
        dsDatos = daoOrden.consultarMedicamentosConciliadosOtros(objConexion, strCod_pre_sgs, strCod_sucur, strTip_Admision,
                                          strAno_Adm, strNum_Adm)
        With dsDatos
            .Tables(0).TableName = "MEDICAMENTOSOTROS"

            procesarCampoTratamiento1(.Tables("MEDICAMENTOSOTROS"), INICIA, Accion.Cargar) ''ER_OSI_593_Modificacion_Funcionalidad_de_Dietas martovar

        End With


        Return dsDatos
    End Function


    Public Shared Function consultarMotivoSuspensionMedicamentos(ByVal objConexion As Conexion) As DataTable
        Dim daoOrden As New DAOConciliacionMedicamentos()
        Return daoOrden.consultarMotivoSuspensionMedicamentos(objConexion)
    End Function


    Private Function CreateDataTablePaciente() As DataTable

        Dim objDatosPaciente As Paciente = Paciente.Instancia
        Dim dtDatosPaciente As DataTable = New DataTable()
        dtDatosPaciente.Columns.Add("Admision", GetType(String))
        dtDatosPaciente.Columns.Add("AnoAdmision", GetType(String))
        dtDatosPaciente.Columns.Add("Cama", GetType(String))
        dtDatosPaciente.Columns.Add("Carnet", GetType(String))
        dtDatosPaciente.Columns.Add("Ciudad", GetType(String))
        dtDatosPaciente.Columns.Add("ClasificacionTriage", GetType(String))
        dtDatosPaciente.Columns.Add("CodHistoria", GetType(String))
        dtDatosPaciente.Columns.Add("CodigoOcupacionPaciente", GetType(String))
        dtDatosPaciente.Columns.Add("CodigoUnidadMedidaEdad", GetType(String))
        dtDatosPaciente.Columns.Add("Consultorio", GetType(String))
        dtDatosPaciente.Columns.Add("Cronico", GetType(String))
        dtDatosPaciente.Columns.Add("DescripcionEntidad", GetType(String))
        dtDatosPaciente.Columns.Add("DescripcionGenero", GetType(String))
        dtDatosPaciente.Columns.Add("DescripcionOcupacionPaciente", GetType(String))
        dtDatosPaciente.Columns.Add("DescripcionTipoDocumento", GetType(String))
        dtDatosPaciente.Columns.Add("DescripcionTipoHistoria", GetType(String))
        dtDatosPaciente.Columns.Add("DescripcionUnidadMedidaEdad", GetType(String))
        dtDatosPaciente.Columns.Add("DirSucursal", GetType(String))
        dtDatosPaciente.Columns.Add("Edad", GetType(String))
        dtDatosPaciente.Columns.Add("EdadAMD", GetType(String))
        dtDatosPaciente.Columns.Add("Entidad", GetType(String))
        dtDatosPaciente.Columns.Add("EstadoAdmision", GetType(String))
        dtDatosPaciente.Columns.Add("EstadoInicialHistoria", GetType(String))
        dtDatosPaciente.Columns.Add("EstadoInstancia", GetType(String))
        dtDatosPaciente.Columns.Add("FechaAtencionProcedimiento", GetType(String))
        dtDatosPaciente.Columns.Add("FechaCita", GetType(String))
        dtDatosPaciente.Columns.Add("FechaHistoriaClinica", GetType(String))
        dtDatosPaciente.Columns.Add("FechaHoraAdmision", GetType(String))
        dtDatosPaciente.Columns.Add("FechaIngresoAdmision", GetType(String))
        dtDatosPaciente.Columns.Add("FechaNacimiento", GetType(String))
        dtDatosPaciente.Columns.Add("Genero", GetType(String))
        dtDatosPaciente.Columns.Add("GrupoRH", GetType(String))
        dtDatosPaciente.Columns.Add("GrupoSanguineo", GetType(String))
        dtDatosPaciente.Columns.Add("HistoriaTieneEgreso", GetType(String))
        dtDatosPaciente.Columns.Add("HoraAtencionProcedimiento", GetType(String))
        dtDatosPaciente.Columns.Add("HoraCita", GetType(String))
        dtDatosPaciente.Columns.Add("HoraHistoriaClinica", GetType(String))
        dtDatosPaciente.Columns.Add("HoraIngresoAdmision", GetType(String))
        dtDatosPaciente.Columns.Add("IdentificadorCama", GetType(String))
        dtDatosPaciente.Columns.Add("ManejaConvenio", GetType(String))
        dtDatosPaciente.Columns.Add("MinutoAtencionProcedimiento", GetType(String))
        dtDatosPaciente.Columns.Add("MinutoCita", GetType(String))
        dtDatosPaciente.Columns.Add("MinutoHistoriaClinica", GetType(String))
        dtDatosPaciente.Columns.Add("MinutoIngresoAdmision", GetType(String))
        dtDatosPaciente.Columns.Add("NombreCompleto", GetType(String))
        dtDatosPaciente.Columns.Add("NumeroAdmision", GetType(String))
        dtDatosPaciente.Columns.Add("NumeroDocumento", GetType(String))
        dtDatosPaciente.Columns.Add("Pais", GetType(String))
        dtDatosPaciente.Columns.Add("PrimerApellido", GetType(String))
        dtDatosPaciente.Columns.Add("PrimerNombre", GetType(String))
        dtDatosPaciente.Columns.Add("RH", GetType(String))
        dtDatosPaciente.Columns.Add("Reingreso", GetType(String))
        dtDatosPaciente.Columns.Add("Religion", GetType(String))
        dtDatosPaciente.Columns.Add("SegundoApellido", GetType(String))
        dtDatosPaciente.Columns.Add("SegundoNombre", GetType(String))
        dtDatosPaciente.Columns.Add("TipoAdmision", GetType(String))
        dtDatosPaciente.Columns.Add("TipoConsultorio", GetType(String))
        dtDatosPaciente.Columns.Add("TipoDocumento", GetType(String))
        dtDatosPaciente.Columns.Add("TipoEntidad", GetType(String))
        dtDatosPaciente.Columns.Add("TipoHistoria", GetType(String))
        dtDatosPaciente.Columns.Add("TipoUsuario", GetType(String))
        dtDatosPaciente.Columns.Add("Ubicacion", GetType(String))
        Dim filaNueva As DataRow = dtDatosPaciente.NewRow()
        filaNueva("Admision") = objDatosPaciente.Admision
        filaNueva("AnoAdmision") = objDatosPaciente.AnoAdmision
        filaNueva("Cama") = objDatosPaciente.Cama
        filaNueva("Carnet") = objDatosPaciente.Carnet
        filaNueva("Ciudad") = objDatosPaciente.Ciudad
        filaNueva("ClasificacionTriage") = objDatosPaciente.ClasificacionTriage
        filaNueva("CodHistoria") = objDatosPaciente.CodHistoria
        filaNueva("CodigoOcupacionPaciente") = objDatosPaciente.CodigoOcupacionPaciente
        filaNueva("CodigoUnidadMedidaEdad") = objDatosPaciente.CodigoUnidadMedidaEdad
        filaNueva("Consultorio") = objDatosPaciente.Consultorio
        filaNueva("Cronico") = objDatosPaciente.Cronico
        filaNueva("DescripcionEntidad") = objDatosPaciente.DescripcionEntidad
        filaNueva("DescripcionGenero") = objDatosPaciente.DescripcionGenero
        filaNueva("DescripcionOcupacionPaciente") = objDatosPaciente.DescripcionOcupacionPaciente
        filaNueva("DescripcionTipoDocumento") = objDatosPaciente.DescripcionTipoDocumento
        filaNueva("DescripcionTipoHistoria") = objDatosPaciente.DescripcionTipoHistoria
        filaNueva("DescripcionUnidadMedidaEdad") = objDatosPaciente.DescripcionUnidadMedidaEdad
        filaNueva("DirSucursal") = objDatosPaciente.DirSucursal
        filaNueva("Edad") = objDatosPaciente.Edad
        filaNueva("EdadAMD") = objDatosPaciente.EdadAMD
        filaNueva("Entidad") = objDatosPaciente.Entidad
        filaNueva("EstadoAdmision") = objDatosPaciente.EstadoAdmision
        filaNueva("EstadoInicialHistoria") = objDatosPaciente.EstadoInicialHistoria
        filaNueva("EstadoInstancia") = objDatosPaciente.EstadoInstancia
        filaNueva("FechaAtencionProcedimiento") = objDatosPaciente.FechaAtencionProcedimiento
        filaNueva("FechaCita") = objDatosPaciente.FechaCita
        filaNueva("FechaHistoriaClinica") = objDatosPaciente.FechaHistoriaClinica
        filaNueva("FechaHoraAdmision") = objDatosPaciente.FechaHoraAdmision
        filaNueva("FechaIngresoAdmision") = objDatosPaciente.FechaIngresoAdmision
        filaNueva("FechaNacimiento") = objDatosPaciente.FechaNacimiento
        filaNueva("Genero") = objDatosPaciente.Genero
        filaNueva("GrupoRH") = objDatosPaciente.GrupoRH
        filaNueva("GrupoSanguineo") = objDatosPaciente.GrupoSanguineo
        filaNueva("HistoriaTieneEgreso") = objDatosPaciente.HistoriaTieneEgreso
        filaNueva("HoraAtencionProcedimiento") = objDatosPaciente.HoraAtencionProcedimiento
        filaNueva("HoraCita") = objDatosPaciente.HoraCita
        filaNueva("HoraHistoriaClinica") = objDatosPaciente.HoraHistoriaClinica
        filaNueva("HoraIngresoAdmision") = objDatosPaciente.HoraIngresoAdmision
        filaNueva("IdentificadorCama") = objDatosPaciente.IdentificadorCama
        filaNueva("ManejaConvenio") = objDatosPaciente.ManejaConvenio
        filaNueva("MinutoAtencionProcedimiento") = objDatosPaciente.MinutoAtencionProcedimiento
        filaNueva("MinutoCita") = objDatosPaciente.MinutoCita
        filaNueva("MinutoHistoriaClinica") = objDatosPaciente.MinutoHistoriaClinica
        filaNueva("MinutoIngresoAdmision") = objDatosPaciente.MinutoIngresoAdmision
        filaNueva("NombreCompleto") = objDatosPaciente.NombreCompleto
        filaNueva("NumeroAdmision") = objDatosPaciente.NumeroAdmision
        filaNueva("NumeroDocumento") = objDatosPaciente.NumeroDocumento
        filaNueva("Pais") = objDatosPaciente.Pais
        filaNueva("PrimerApellido") = objDatosPaciente.PrimerApellido
        filaNueva("PrimerNombre") = objDatosPaciente.PrimerNombre
        filaNueva("RH") = objDatosPaciente.RH
        filaNueva("Reingreso") = objDatosPaciente.Reingreso
        filaNueva("Religion") = objDatosPaciente.Religion
        filaNueva("SegundoApellido") = objDatosPaciente.SegundoApellido
        filaNueva("SegundoNombre") = objDatosPaciente.SegundoNombre
        filaNueva("TipoAdmision") = objDatosPaciente.TipoAdmision
        filaNueva("TipoConsultorio") = objDatosPaciente.TipoConsultorio
        filaNueva("TipoDocumento") = objDatosPaciente.TipoDocumento
        filaNueva("TipoEntidad") = objDatosPaciente.TipoEntidad
        filaNueva("TipoHistoria") = objDatosPaciente.TipoHistoria
        filaNueva("TipoUsuario") = objDatosPaciente.TipoUsuario
        filaNueva("Ubicacion") = objDatosPaciente.Ubicacion
        dtDatosPaciente.Rows.Add(filaNueva)
        Return dtDatosPaciente
    End Function



    Private Shared Function CrearTableDietas() As DataTable
        Dim dtDietas As New DataTable
        With dtDietas.Columns
            .Add("obs")
            .Add("fec_con")
            .Add("Tratamiento")
            .Add("NroOrden")
            .Add("Dieta")
            .Add("estado")
            .Add("login")
            .Add("medico")
            .Add("cod_pre_sgs")
            .Add("cod_sucur")
            .Add("tip_admision")
            .Add("ano_adm")
            .Add("num_adm")
            .Add("Secuencia")
            .Add("ResHidrica")
        End With
        Return dtDietas
    End Function


    Private Shared Function CrearTableProcedimineto() As DataTable
        Dim dtProcedim As New DataTable
        With dtProcedim.Columns
            .Add("descripcion_proce")
            .Add("Cantidad")
            .Add("obs")
            .Add("cod_pre_sgs")
            .Add("cod_sucur")
            .Add("tip_admision")
            .Add("num_adm")
            .Add("ano_adm")
            .Add("NroOrden")
            .Add("procedim ")
            .Add("medico")
            .Add("fec_con")
            .Add("login")
            .Add("tieneConvenio")
            .Add("codigo_ris")
            .Add("numconsulta")
            .Add("mensaje")
            .Add("grabaPedido")
            .Add("secuencia")
            .Add("uni_solicit")
            .Add("uni_aplicada")
            .Add("uni_suministrada")
            .Add("durante")
            .Add("cen_cos_des")
            .Add("cen_cos_origen")
            .Add("entidad")
            .Add("tip_proced")
            .Add("NroPedido")
            .Add("OrigenProcedim")
            .Add("JustificaSinConve")
            .Add("tieneCcostoLabo")
            .Add("CodSISPRO")
            .Add("DesSISPRO")
            .Add("autoSISPRO")
            .Add("EstadoInterconsulta")
            .Add("procedimhomologo")
            .Add("entidadpedido")
            .Add("cod_Labor")
            .Add("genprocedes")
            .Add("particularidades")
            .Add("procedimientos")
        End With
        Return dtProcedim
    End Function


    Private Shared Function CrearTableGenerales() As DataTable
        Dim dtGeneral As New DataTable
        With dtGeneral.Columns
            .Add("cod_pre_sgs")
            .Add("cod_sucur")
            .Add("tip_admision")
            .Add("num_adm")
            .Add("ano_adm")
            .Add("NroOrden")
            .Add("Secuencia")
            .Add("TextoOrden")
            .Add("Tratamiento")
            .Add("medico")
            .Add("Especialidad")
            .Add("estado")
            .Add("fec_con")
            .Add("login")
            .Add("obs")
            .Add("Orden")
            .Add("entidad")
            .Add("cada")
            .Add("Tiempo")
        End With
        Return dtGeneral
    End Function

    Private Shared Function CrearTableAislamiento() As DataTable
        Dim dtAislamiento As New DataTable



        With dtAislamiento.Columns
            .Add("cod_pre_sgs")
            .Add("cod_sucur")
            .Add("tip_admision")
            .Add("num_adm")
            .Add("ano_adm")
            .Add("NroOrden")
            .Add("Secuencia")
            .Add("Tratamiento")
            .Add("medico")
            .Add("estado")
            .Add("aisla_fecha_hora")
            .Add("login")
            .Add("aisla_aislamiento")
            .Add("aisla_obs")
            .Add("aisla_medico")
            .Add("aisla_especialidad")
            .Add("TextoOrden")
            .Add("tipo_aislamiento")
            .Add("aisla_continuar")
            .Add("aisla_suspender")
            .Add("aisla_nuevo")
        End With
        Return dtAislamiento
    End Function


    Public Shared ReadOnly columnasMedicamentos As String() = {"fec_con", "diastrat", "codSISPRO", "desSISPRO", "cod_pre_sgs", "cod_sucur", "tip_admision", "ano_adm",
                                                                                   "num_adm", "NroOrden", "producto", "FormaFarma", "Presentacion", "Contenido", "Concentracion", "Dosis",
                                                                                   "UniMedDosis", "ViaAdministra", "Frecuencia", "TecnicaAdministra", "UnicaDosis", "Tratamiento", "medico", "estado",
                                                                                   "login", "obs", "Secuencia", "MedControl", "cantidadcontrol", "cantidadletrascontrol", "autoSISPRO", "fecfintra",
                                                                                   "cod_corto", "concentracionEq", "for_farma", "diasTratamiento", "DosisXDia", "DosisXDiaNoPos", "fec_desde", "fec_hasta",
                                                                                   "diagnost", "Justificacion", "clasificacion", "obsDiagn", "viaBolo", "diastrat1", "OMDurante", "OMPasarEn",
                                                                                    "OMRescates", "OMNumDosis", "idRegistro", "id_esquema", "tratamiento_esquema", "estado_esquema", "peso_paciente", "talla_paciente",
                                                                                   "sct", "intencion_terapia", "linea_tratamiento", "ciclo", "creatinina", "unidad_medida_creatinina", "tfg numeric", "unidad_referencia",
                                                                                   "dosis_resultante", "ajuste_dosis", "dosis_ajustada", "dosis_teorica", "pasar_en", "tiempo", "vehiculo", "volumen_final_solucion",
                                                                                   "adm_durante_dias", "conciliado", "origen", "motivo_id", "textomotivo", "login_sus", "fecha_sus", "espec_sus"}


    Public Shared Function guardarOrdenes(ByVal objConexion As Conexion, ByVal cod_pre_sgs As String,
                                                  ByVal strCodSucur As String, ByVal tip_admision As String,
                                                  ByVal num_adm As String, ByVal ano_adm As String, ByVal strLogin As String,
                                                  ByVal medico As String, ByVal strCodEspecialidad As String, ByVal entidad As String,
                                                  ByVal dtMedicamentos As DataTable, ByVal dtpaciente As DataTable,
                                                  ByRef NroOrden As Double, ByRef fechaOrden As Date,
                                                  ByRef centroCostoOrigen As String, ByRef strGuia As String,
                                                  ByRef strJustificacion As String, ByRef strTipoServicio As String,
                                                  ByRef strPrioridad As String, ByVal CodProcedim As String, ByVal DescripProcedim As String, ByRef InicioSesion As DateTime, Optional ByRef Practicaosi As String = "") As Long

        ''Dsanchez IG - Req 594 - 09/10/2017
        Dim dtAislamientosModificados As DataTable = CrearTableAislamiento()
        Dim dtAislamientosNuevos As DataTable = CrearTableAislamiento()
        Dim xmlAislamientosModificados As String = String.Empty
        Dim xmlAislamientosNuevos As String = String.Empty

        Dim dtDietasModificadas As DataTable = CrearTableDietas()
        Dim dtDietasNuevas As DataTable = CrearTableDietas()
        Dim xmlDietasModifica As String = ""
        Dim xmlDietasNuevas As String = ""

        Dim dtMedicaModificados As New DataTable
        Dim dtMedicaNuevos As New DataTable
        Dim xmlMedicaModificados As String = ""
        Dim xmlMedicaNuevos As String = ""

        Dim dtproceNuevos As DataTable = CrearTableProcedimineto()
        Dim dtProcedimXCentroCosto As ArrayList
        Dim xmlProceNuevos As String

        Dim dtGeneralesModificados As DataTable = CrearTableGenerales()
        Dim dtGeneralesNuevos As DataTable = CrearTableGenerales()
        Dim xmlGeneralesModificados As String
        Dim xmlGeneralesNuevos As String

        ''Claudia Garay Abril 05 2011 Auditoria Ordenes
        Dim intCountAislamientos As Integer = 0
        Dim intCountDietas As Integer = 0
        Dim intCountMedicamento As Integer = 0
        Dim intCountProcedimiento As Integer = 0
        Dim intCountGenerales As Integer = 0
        Dim objpaciente As Paciente
        Dim ObjGeneral As objGenerales
        objpaciente = Paciente.Instancia
        ObjGeneral = objGenerales.Instancia

        Dim lError As Long
        Dim i As Integer
        Dim intGuardar As Integer = 0
        Dim strMensaje As String = ""

        Dim daoOrden As New DAOConciliacionMedicamentos()
        Dim daogeneral As New DAOGeneral
        Dim Agfa As String

        Dim procedimHomologo As String = ""
        Dim entidadvalida As String = ""
        Dim strGeneraPedido As String = ""
        Dim strGeneraPedidoLabo As String = ""

        Dim dtproceris As New DataTable
        Dim intris As Integer = 0
        Dim intValida As Integer = 0
        Dim intGraba As Integer = 0

        Dim strCodSucuragfa As String

        Dim numPedido As Decimal

        'dtAislamientosModificados = dtAislamientos.Clone()
        'dtAislamientosNuevos = dtAislamientos.Clone()

        'dtDietasModificadas = dtDietas.Clone()
        'dtDietasNuevas = dtDietas.Clone()

        dtMedicaModificados = dtMedicamentos.Clone()
        dtMedicaNuevos = dtMedicamentos.Clone()

        'dtproceNuevos = dtProcedimientos.Clone()

        'dtGeneralesModificados = dtGenerales.Clone
        'dtGeneralesNuevos = dtGenerales.Clone



        'consecutivo = daoGeneral.EjecutarSQLStrValor("hcEnfAlarma", objconexion, " max(consecutivo)", " cod_historia=" & cod_historia)

        ''intGuardar = daogeneral.EjecutarSQLStrValor("hcgrabarOrdenes", objConexion, "modo_guardar", " cod_pre_sgs='" & cod_pre_sgs & "' and cod_sucur='" & strCodSucur & "'")

        If IsDBNull(intGuardar) Then
            intGuardar = 0
        End If

        If intGuardar = 0 Then


            ''Dsanchez IG - Req 594 - 09/10/2017
            '----------------------------AISLAMIENTOS-----------------------------------
            '''Se buscan los aislamientos que han sido modificados
            'dtAislamientosModificados = filtrarTabla(dtAislamientos, DataViewRowState.ModifiedCurrent, dtAislamientosModificados)
            '''Cambia el campo tratamiento cuando es Null al valor I por 
            'procesarCampoTratamiento(dtAislamientosModificados, INICIA, Accion.Grabar)

            'asignarSecuencia(dtAislamientos)

            '''Se buscan los aislamientos nuevos.Tambien se adicionan los registros 
            '''modificados ya que estos se insertan con un nuevo numero de orden quedando activos en la nueva orden.
            'dtAislamientosNuevos = filtrarTabla(dtAislamientos, DataViewRowState.Added, dtAislamientosNuevos)
            'dtAislamientosNuevos = filtrarTabla(dtAislamientos, DataViewRowState.ModifiedCurrent, dtAislamientosNuevos)

            '''Cambia el campo tratamiento cuando es Null al valor I por 
            'procesarCampoTratamiento(dtAislamientosNuevos, INICIA, Accion.Grabar)

            '''Se eliminan las colunmas que contienen informacion innecesaria para la grabacion
            '''dtAislamientosModificados = configurarDataTableDietasParaGrabar(dtAislamientosModificados)
            '''dtAislamientosNuevos = configurarDataTableDietasParaGrabar(dtAislamientosNuevos)

            'If dtAislamientosNuevos.Rows.Count > 0 Then
            '    intCountDietas = dtAislamientosNuevos.Rows.Count
            'End If

            '''Se generan los xml que contienen la informacion de las dietas
            'xmlAislamientosModificados = FuncionesGenerales.GenerarXMLxProcedimiento(dtAislamientosModificados)
            'xmlAislamientosNuevos = FuncionesGenerales.GenerarXMLxProcedimiento(dtAislamientosNuevos)

            ''----------------------------DIETAS-----------------------------------
            '''Se buscan las dietas que han sido modificadas 
            'dtDietasModificadas = filtrarTabla(dtDietas, DataViewRowState.ModifiedCurrent, dtDietasModificadas)
            '''Cambia el campo tratamiento cuando es Null al valor I por 
            'procesarCampoTratamiento(dtDietasModificadas, INICIA, Accion.Grabar)

            'asignarSecuencia(dtDietas)
            '''Se buscan las dietas nuevas.Tambien se adicionan los registros 
            '''modificados ya que estos se insertan con un nuevo numero de orden quedando activos en la nueva orden.
            'dtDietasNuevas = filtrarTabla(dtDietas, DataViewRowState.Added, dtDietasNuevas)
            'dtDietasNuevas = filtrarTabla(dtDietas, DataViewRowState.ModifiedCurrent, dtDietasNuevas)

            '''Cambia el campo tratamiento cuando es Null al valor I por 
            'procesarCampoTratamiento(dtDietasNuevas, INICIA, Accion.Grabar)

            '''Se eliminan las colunmas que contienen informacion innecesaria para la grabacion
            'dtDietasModificadas = configurarDataTableDietasParaGrabar(dtDietasModificadas)
            'dtDietasNuevas = configurarDataTableDietasParaGrabar(dtDietasNuevas)

            'If dtDietasNuevas.Rows.Count > 0 Then
            '    intCountDietas = dtDietasNuevas.Rows.Count
            'End If


            '''Se generan los xml que contienen la informacion de las dietas
            'xmlDietasModifica = FuncionesGenerales.GenerarXMLxProcedimiento(dtDietasModificadas)
            'xmlDietasNuevas = FuncionesGenerales.GenerarXMLxProcedimiento(dtDietasNuevas)

            '--------------------------MEDICAMENTOS--------------------------------
            ''Se buscan los medicamentos modificados 
            'If dtMedicaModificados.Rows.Count > 0 Then
            dtMedicaModificados = filtrarTabla(dtMedicamentos, DataViewRowState.ModifiedCurrent, dtMedicaModificados)
            ''Cambia el campo tratamiento que esta en null por I Iniciado
            procesarCampoTratamiento(dtMedicaModificados, INICIA, Accion.Grabar)
            'End If

            asignarSecuencia(dtMedicamentos)
            ''Se buscan  los medicamentos nuevos.Tambien se adicionan los registros 
            ''modificados ya que estos se insertan con un nuevo numero de orden quedando activos en la nueva orden.
            dtMedicaNuevos = filtrarTabla(dtMedicamentos, DataViewRowState.Added, dtMedicaNuevos)
            dtMedicaNuevos = filtrarTabla(dtMedicamentos, DataViewRowState.ModifiedCurrent, dtMedicaNuevos)
            ''Cambia el campo tratamiento que esta en null por I Iniciado
            procesarCampoTratamiento(dtMedicaNuevos, INICIA, Accion.Grabar)

            ''Se eliminan las colunmas que contienen informacion innecesaria para la grabacion
            'If dtMedicaModificados.Rows.Count > 0 Then
            dtMedicaModificados = configurarDataTableMedicaParaGrabar(dtMedicaModificados)
            'End If

            dtMedicaNuevos = configurarDataTableMedicaParaGrabar(dtMedicaNuevos)

            If dtMedicaNuevos.Rows.Count > 0 Then
                intCountMedicamento = dtMedicaNuevos.Rows.Count
            End If

            ''Se generan los xml que contiene la informacion de los medicamentos
            xmlMedicaModificados = FuncionesGenerales.GenerarXMLxProcedimiento(dtMedicaModificados)
            xmlMedicaNuevos = FuncionesGenerales.GenerarXMLxProcedimiento(dtMedicaNuevos)


            '-------------------------PROCEDIMIENTOS --------------------------------



            '----------------------------ORDENES GENERALES----------------------------  
            ''Se buscan los registros modificados de las ordenes generales. Estas ordenes se inactivan
            ''y se crea una nueva orden con los nuevos datos(Continuar, suspender)
            'dtGeneralesModificados = filtrarTabla(dtGenerales, DataViewRowState.ModifiedCurrent, dtGeneralesModificados)
            '''Cambia el campo tratamiento que esta en null por I Iniciado
            'procesarCampoTratamiento(dtGeneralesModificados, INICIA, Accion.Grabar)

            '''Se buscan los registros nuevos de las ordenes generales
            'asignarSecuencia(dtGenerales)
            'dtGeneralesNuevos = filtrarTabla(dtGenerales, DataViewRowState.Added, dtGeneralesNuevos)
            'dtGeneralesNuevos = filtrarTabla(dtGenerales, DataViewRowState.ModifiedCurrent, dtGeneralesNuevos)
            '''Cambia el campo tratamiento que esta en null por I Iniciado
            'procesarCampoTratamiento(dtGeneralesNuevos, INICIA, Accion.Grabar)

            '''Se eliminan las colunmas que contienen informacion innecesaria para la grabacion
            'dtGeneralesModificados = configurarDataTableOrdenGeneralParaGrabar(dtGeneralesModificados)
            'dtGeneralesNuevos = configurarDataTableOrdenGeneralParaGrabar(dtGeneralesNuevos)

            'If dtGeneralesNuevos.Rows.Count > 0 Then
            '    intCountGenerales = dtGeneralesNuevos.Rows.Count
            'End If

            'xmlGeneralesModificados = FuncionesGenerales.GenerarXMLxProcedimiento(dtGeneralesModificados)
            'xmlGeneralesNuevos = FuncionesGenerales.GenerarXMLxProcedimiento(dtGeneralesNuevos)


            '''Validar si existen datos para grabar 
            'If dtAislamientosModificados.Rows.Count <= 0 And dtAislamientosNuevos.Rows.Count <= 0 And
            '   dtDietasModificadas.Rows.Count <= 0 And dtDietasNuevas.Rows.Count <= 0 And
            '   dtMedicaModificados.Rows.Count <= 0 And dtMedicaNuevos.Rows.Count <= 0 And
            '   dtProcedimientos.Rows.Count <= 0 And dtGeneralesModificados.Rows.Count <= 0 And
            '    dtGeneralesNuevos.Rows.Count <= 0 Then
            '    Return 999  ''No existen datos para guardar
            'End If



            ''Procedimiento que llama al stored procedure que graba
            Try
                ''

                BLConciliacionMedicamentos.GrabarErroresOrdenesMedicas("HistoriaMedicaCTC" & Mid(xmlMedicaNuevos, 1, 5000))
                BLConciliacionMedicamentos.GrabarErroresOrdenesMedicas("HistoriaMedicaCTC" & Mid(xmlProceNuevos, 1, 5000))
                BLConciliacionMedicamentos.GrabarErroresOrdenesMedicas("ORDENMEDICA" & Mid(xmlMedicaModificados, 1, 5000))

                '' eloaiza@intergrupo - 30-08-2019
                '' cambio en parametros para guardar ordenes.
                Dim tipoParametro As String = BLConciliacionMedicamentos.ConsultarParametros("ParamObjsEnviarOrdenesMedicas")

                If (String.IsNullOrEmpty(tipoParametro) Or tipoParametro.ToUpperInvariant().Trim() = "XML") Then
                    If strGeneraPedidoLabo = "N" Then
                        'lError = daoOrden.guardarOrdenes(objConexion, cod_pre_sgs, strCodSucur, tip_admision, num_adm,
                        '                                                   ano_adm, strLogin, medico, strCodEspecialidad, entidad,
                        '                                                   xmlAislamientosModificados, xmlAislamientosNuevos,
                        '                                                   xmlDietasModifica, xmlDietasNuevas, xmlMedicaModificados,
                        '                                                   xmlMedicaNuevos, xmlProceNuevos, xmlGeneralesModificados,
                        '                                                   xmlGeneralesNuevos, NroOrden, fechaOrden, centroCostoOrigen,
                        '                                                   strGuia, strJustificacion, strTipoServicio, strPrioridad, InicioSesion)
                    Else
                        'lError = daoOrden.guardarOrdenesLabo(objConexion, cod_pre_sgs, strCodSucur, tip_admision, num_adm,
                        '                                                   ano_adm, strLogin, medico, strCodEspecialidad, entidad,
                        '                                                   xmlAislamientosModificados, xmlAislamientosNuevos,
                        '                                                   xmlDietasModifica, xmlDietasNuevas, xmlMedicaModificados,
                        '                                                   xmlMedicaNuevos, xmlProceNuevos, xmlGeneralesModificados,
                        '                                                   xmlGeneralesNuevos, NroOrden, fechaOrden, centroCostoOrigen,
                        '                                                   strGuia, strJustificacion, strTipoServicio, strPrioridad)

                    End If
                ElseIf (tipoParametro.ToUpperInvariant().Trim() = "DATATABLE") Then
                    'Es necesario asegurar que el orden de las colunas sea el mismo que los Type de la BD para evitar errores al momento de pasar los parametros 
                    'en el procedimiento'
                    dtAislamientosNuevos = Comunes.FuncionesGenerales.ReOrganizarColumnasEnDatatable(dtAislamientosNuevos, columnasAislamientos)
                    dtAislamientosModificados = Comunes.FuncionesGenerales.ReOrganizarColumnasEnDatatable(dtAislamientosModificados, columnasAislamientos)

                    dtDietasNuevas = Comunes.FuncionesGenerales.ReOrganizarColumnasEnDatatable(dtDietasNuevas, columnasDietas)
                    dtDietasModificadas = Comunes.FuncionesGenerales.ReOrganizarColumnasEnDatatable(dtDietasModificadas, columnasDietas)

                    'dtGeneralesNuevos = Comunes.FuncionesGenerales.ReOrganizarColumnasEnDatatable(dtGeneralesNuevos, columnasGenerales)
                    'dtGeneralesNuevos.Columns.Remove("Frecuencia")
                    'dtGeneralesNuevos.Columns.Remove("Observaciones")

                    'dtGeneralesModificados = Comunes.FuncionesGenerales.ReOrganizarColumnasEnDatatable(dtGeneralesModificados, columnasGenerales)
                    'dtGeneralesModificados.Columns.Remove("Frecuencia")
                    'dtGeneralesModificados.Columns.Remove("Observaciones")

                    dtMedicaNuevos.Columns.Remove("tmp_suspender_med")
                    dtMedicaNuevos.Columns.Remove("tmp_modificar_med")
                    dtMedicaModificados.Columns.Remove("tmp_suspender_med")
                    dtMedicaModificados.Columns.Remove("tmp_modificar_med")
                    dtMedicaNuevos.Columns.Remove("tfg numeric")
                    dtMedicaModificados.Columns.Remove("tfg numeric")
                    dtMedicaNuevos.Columns.Remove("motivosus")
                    dtMedicaModificados.Columns.Remove("motivosus")
                    dtMedicaNuevos.Columns.Remove("flag_pos")
                    dtMedicaModificados.Columns.Remove("flag_pos")

                    dtMedicaNuevos = Comunes.FuncionesGenerales.ReOrganizarColumnasEnDatatable(dtMedicaNuevos, columnasMedicamentos)
                    dtMedicaModificados = Comunes.FuncionesGenerales.ReOrganizarColumnasEnDatatable(dtMedicaModificados, columnasMedicamentos)

                    'dtProcedimientos = Comunes.FuncionesGenerales.ReOrganizarColumnasEnDatatable(dtProcedimientos, columnasProcedimientos)
                    ' Se eliminan estas dos columnas que son temporales

                    lError = daoOrden.guardarOrdenes(objConexion, cod_pre_sgs, strCodSucur, tip_admision, num_adm,
                                                     ano_adm, strLogin, medico, strCodEspecialidad, entidad,
                                                     dtAislamientosModificados, dtAislamientosNuevos, dtDietasModificadas, dtDietasNuevas, dtMedicaModificados,
                                                     dtMedicaNuevos, dtproceNuevos, dtGeneralesModificados, dtGeneralesNuevos, dtpaciente,
                                                     NroOrden, fechaOrden, centroCostoOrigen,
                                                     strGuia, strJustificacion, strTipoServicio, strPrioridad, InicioSesion)
                Else
                    Throw New Exception("El valor para el parametro ParamObjsEnviarOrdenesMedicas no es válido")
                End If


            Catch ex As Exception
                BLConciliacionMedicamentos.GrabarErroresOrdenesMedicas("HistoriaMedica" & ex.Message)
                MsgBox("Error al guardar ordenes " & ex.Message)
            End Try

            If lError <> 0 Then
                Return lError
            Else
                Dim objP As objPaciente = objpaciente.Instancia
                Dim strPrioridadtmp As String = strPrioridad

                If strPrioridadtmp = "" Then
                    ' se le agrega cambio de prioridad por urgente cuando el procedimiento es para U o para una H
                    ' Realizado herojas, cambio solicitado por ORM - Agfa
                    If objpaciente.TipoAdmision = "U" Or objpaciente.TipoAdmision = "H" Then
                        strPrioridadtmp = "1"
                    Else
                        strPrioridadtmp = "3"
                    End If
                End If



                Agfa = daogeneral.EjecutarSQLStrValor("gensucur (nolock)", objConexion, " agfa", " cod_sucur='" & strCodSucur & "'")
                If IIf(IsDBNull(Agfa), "N", Agfa) = "S" Then

                    If Len(strCodSucur) = 3 Then
                        strCodSucuragfa = "0" & strCodSucur
                    Else
                        strCodSucuragfa = strCodSucur
                    End If


                    'For Each dr As DataRow In dtProcedimientos.Rows

                    '    ' Evalua procedimiento ris es realizado en la sede numconsulta="2"

                    '    If dr("OrigenProcedim") = "RIS" And dr("numconsulta") = 2 Then

                    '        'agfa_orm_in herojas traer el numero del pedido en la variable nuor mPedido
                    '        daoOrden.ConsultarDatosPedidoOrdenRis(dr("cod_pre_sgs"), dr("cod_sucur"), objpaciente.TipoAdmision, objpaciente.NumeroAdmision, objpaciente.AnoAdmision, NroOrden, dr("procedim"), numPedido)

                    '        dtproceris = daogeneral.EjecutarSQLConParametros("genproceris", objConexion, "cod_sucur", " codigo_ris='" & dr("codigo_ris") & "' and procedim='" & dr("procedim") & "'")

                    '        intGraba = intGraba + 1
                    '        ' se concatena la sucursal a la admision. Solicitud agfa proyecto agfa_orm_in herojas
                    '        ' se le agrega la entidad 2014/09/15 agfa_orm_in
                    '        ' se le agregan los parametros tipo, año y numero de admision herojas 2015/02/11
                    '        'CCGUTIEREZ - OSI. 07/09/2020. Se agrega parametro dr("particularidades")
                    '        ''CCGUTIEREZ - OSI. 28/06/2021. Se agrega parametro dr("procedimientos")
                    '        lError = daoOrden.guardarOrdenesAGFA(objConexion, "N", FuncionesGenerales.FechaServidor(), objpaciente.TipoDocumento & objpaciente.NumeroDocumento,
                    '                 objpaciente.PrimerNombre, objpaciente.PrimerApellido, objpaciente.FechaNacimiento,
                    '                 objpaciente.Genero, "", objpaciente.TipoAdmision,
                    '                 objpaciente.TipoAdmision & objpaciente.AnoAdmision & objpaciente.NumeroAdmision & "-" & strCodSucuragfa,
                    '                 NroOrden, dr("cod_sucur"), NroOrden, FuncionesGenerales.FechaServidor(),
                    '                 FuncionesGenerales.FechaServidor().AddDays(1), strPrioridadtmp, strLogin, strLogin,
                    '                 0, dr("codigo_ris"), dr("descripcion_proce"), fechaOrden, strJustificacion, dr("obs"),
                    '                dr("cen_cos_origen"), dr("cen_cos_des"), numPedido, strCodSucur, cod_pre_sgs,
                    '                dr("entidad"), dr("procedim"), ObjGeneral.NombreMedico,
                    '                objpaciente.AnoAdmision, objpaciente.NumeroAdmision, dr("particularidades"), dr("procedimientos"), intGraba)


                    '    End If
                    'Next
                End If
                'If IIf(IsDBNull(Agfa), "N", Agfa) = "S" Then

                '            If Len(strCodSucur) = 3 Then
                '                strCodSucuragfa = "0" & strCodSucur
                '            Else
                '                strCodSucuragfa = strCodSucur
                '            End If


                '    For Each dr As DataRow In dtProcedimientos.Rows

                '        If dr("OrigenProcedim") = "ris" Then

                '                    'agfa_orm_in herojas traer el numero del pedido en la variable numPedido
                '                    daoOrden.ConsultarDatosPedidoOrdenRis(dr("cod_pre_sgs"), dr("cod_sucur"), objpaciente.TipoAdmision, objpaciente.NumeroAdmision, objpaciente.AnoAdmision, NroOrden, dr("procedim"), numPedido)

                '            dtproceris = daogeneral.EjecutarSQLConParametros("genproceris", objConexion, "cod_sucur", " codigo_ris='" & dr("codigo_ris") & "' and procedim='" & dr("procedim") & "'")

                '            If dtproceris.Rows.Count > 0 Then

                '                If dtproceris.Rows.Count = 1 Then

                '                    If dtproceris.Rows(intris).Item("cod_sucur").ToString = strCodSucur Then '' se practica en la sucursal
                '                        intGraba = intGraba + 1
                '                                ' se concatena la sucursal a la admision. Solicitud agfa proyecto agfa_orm_in herojas
                '                                ' se le agrega la entidad 2014/09/15 agfa_orm_in
                '                                lError = daoOrden.guardarOrdenesAGFA(objConexion, "N", FuncionesGenerales.FechaServidor(), objpaciente.TipoDocumento & objpaciente.NumeroDocumento, _
                '                                         objpaciente.PrimerNombre, objpaciente.PrimerApellido, objpaciente.FechaNacimiento, _
                '                                         objpaciente.Genero, "", objpaciente.TipoAdmision, _
                '                                         objpaciente.TipoAdmision & objpaciente.AnoAdmision & objpaciente.NumeroAdmision & "-" & strCodSucuragfa, _
                '                                         NroOrden, dr("cod_sucur"), "", FuncionesGenerales.FechaServidor(), _
                '                                         FuncionesGenerales.FechaServidor().AddDays(1), strPrioridadtmp, strLogin, strLogin, _
                '                                         0, dr("codigo_ris"), dr("descripcion_proce"), fechaOrden, strJustificacion, dr("obs"), _
                '                                        dr("cen_cos_origen"), dr("cen_cos_des"), numPedido, strCodSucur, cod_pre_sgs, _
                '                                        dr("entidad"), dr("procedim"), ObjGeneral.NombreMedico, intGraba)
                '                    Else
                '                        'Practicaosi = "EL PROCEDIMIENTO NO SE REALIZA EN ESTA INSTITUCIÓN"
                '                        Practicaosi = "EL PROCEDIMIENTO NO SE REALIZA EN ESTA SEDE"
                '                                If numPedido > 0 Then
                '                                    daoOrden.AnulaPedidoSophia(dr("cod_pre_sgs"), dr("cod_sucur"), dr("cen_cos_des"), numPedido, strLogin, Practicaosi)
                '                                End If
                '                    End If

                '                Else

                '                    For intris = 0 To dtproceris.Rows.Count - 1

                '                        If dtproceris.Rows(intris).Item("cod_sucur").ToString = strCodSucur Then '' se practica en la sucursal
                '                                    ' se concatena la sucursal a la admision. Solicitud agfa proyecto orm herojas
                '                                    intGraba = intGraba + 1 'intValida = intValida + 1
                '                                    lError = daoOrden.guardarOrdenesAGFA(objConexion, "N", FuncionesGenerales.FechaServidor(), _
                '                                        objpaciente.TipoDocumento & objpaciente.NumeroDocumento, objpaciente.PrimerNombre, _
                '                                        objpaciente.PrimerApellido, objpaciente.FechaNacimiento, objpaciente.Genero, "", _
                '                                        objpaciente.TipoAdmision, objpaciente.TipoAdmision & objpaciente.AnoAdmision & objpaciente.NumeroAdmision & "-" & strCodSucuragfa, _
                '                                        NroOrden, dr("cod_sucur"), "", FuncionesGenerales.FechaServidor(), _
                '                                        FuncionesGenerales.FechaServidor().AddDays(1), strPrioridadtmp, strLogin, strLogin, 0, _
                '                                        dr("codigo_ris"), dr("descripcion_proce"), fechaOrden, strJustificacion, dr("obs"), _
                '                                        dr("cen_cos_origen"), dr("cen_cos_des"), numPedido, strCodSucur, cod_pre_sgs, _
                '                                        dr("entidad"), dr("procedim"), ObjGeneral.NombreMedico, intGraba)
                '                            Exit For
                '                        End If

                '                    Next
                '                End If
                '            Else

                '                Practicaosi = "EL PROCEDIMIENTO NO SE REALIZA EN ESTA INSTITUCIÓN"
                '                        If numPedido > 0 Then
                '                            daoOrden.AnulaPedidoSophia(dr("cod_pre_sgs"), dr("cod_sucur"), dr("cen_cos_des"), numPedido, strLogin, Practicaosi)
                '                        End If

                '            End If


                '        Else

                '            If Mid(dr("procedim"), 1, 3) = "402" Then ''Procedimientos de radiologia

                '                dtproceris = daogeneral.EjecutarSQLConParametros("genproceris", objConexion, "cod_sucur", "procedim='" & dr("procedim") & "'")

                '                If dtproceris.Rows.Count > 0 Then

                '                    If dtproceris.Rows.Count = 1 Then

                '                        If dtproceris.Rows(intris).Item("cod_sucur").ToString <> strCodSucur Then
                '                            Practicaosi = "EL PROCEDIMIENTO NO SE REALIZA EN ESTA SEDE"
                '                                    If numPedido > 0 Then
                '                                        daoOrden.AnulaPedidoSophia(dr("cod_pre_sgs"), dr("cod_sucur"), dr("cen_cos_des"), numPedido, strLogin, Practicaosi)
                '                                    End If
                '                        End If

                '                    Else

                '                        For intris = 0 To dtproceris.Rows.Count - 1

                '                            If dtproceris.Rows(intris).Item("cod_sucur").ToString = strCodSucur Then '' se practica en la sucursal
                '                                intValida = 0
                '                                Exit For
                '                            Else
                '                                intValida = intValida + 1
                '                            End If

                '                        Next
                '                    End If

                '                End If

                '            End If
                '        End If
                '                If intValida = 0 Then
                '            Practicaosi = "EL PROCEDIMIENTO NO SE REALIZA EN ESTA SEDE"
                '                    If numPedido > 0 Then
                '                        daoOrden.AnulaPedidoSophia(dr("cod_pre_sgs"), dr("cod_sucur"), dr("cen_cos_des"), numPedido, strLogin, Practicaosi)
                '                    End If
                '        End If
                '    Next
                'End If
                'End If
            End If

        Else

            'lError = GrabarOrdenesNutricion(objConexion, cod_pre_sgs, strCodSucur, tip_admision, num_adm, ano_adm,
            '         strLogin, medico, strCodEspecialidad, entidad, dtDietas, NroOrden, fechaOrden, intCountDietas)

            If lError <> 0 Then
                strMensaje = " -Dietas"
            End If


            lError = GrabarOrdenesMedicamentos(objConexion, cod_pre_sgs, strCodSucur, tip_admision, num_adm, ano_adm,
            strLogin, medico, strCodEspecialidad, entidad, dtMedicamentos, NroOrden, fechaOrden, intCountMedicamento)

            If lError <> 0 Then
                strMensaje = +" -Medicamentos"
            End If

            'lError = GrabarOrdenesProcedimientos(objConexion, cod_pre_sgs, strCodSucur, tip_admision, num_adm, ano_adm,
            'strLogin, medico, strCodEspecialidad, entidad, dtProcedimientos, NroOrden, fechaOrden, centroCostoOrigen, strGuia,
            'strJustificacion, strTipoServicio, strPrioridad, CodProcedim, intCountProcedimiento)

            If lError <> 0 Then
                strMensaje = +" -Procedimientos"
            End If

            'lError = GrabarOrdenesGenerales(objConexion, cod_pre_sgs, strCodSucur, tip_admision, num_adm, ano_adm,
            'strLogin, medico, strCodEspecialidad, entidad, dtGenerales, NroOrden, fechaOrden, intCountGenerales)

            If lError <> 0 Then
                strMensaje = +" -Generales"
            End If

            If Len(strMensaje) > 0 Then
                MsgBox("Error al grabar Ordenes " & strMensaje)
            End If


        End If

        Try
            daoOrden.GrabarAuditOrdenes(objConexion, cod_pre_sgs, strCodSucur, tip_admision, ano_adm, num_adm,
            objpaciente.TipoDocumento & objpaciente.NumeroDocumento, strLogin, intCountMedicamento, intCountGenerales,
            intCountDietas, intCountProcedimiento, NroOrden, strMensaje & CStr(lError), "OR")
        Catch ex As Exception

        End Try

        Return lError
    End Function

    Public Shared Sub GrabarErroresOrdenesMedicas(ByVal Descripcion As String)

        Dim daoOrden As New DAOOrdenes


        daoOrden.GrabarErroresOrdenesMed(Descripcion)


    End Sub

    Public Shared Function ConsultarParametros(ByVal paramName As String, Optional ByVal LinkedServer As String = "") As String
        Dim daoOrden As New DAOOrdenes
        Return daoOrden.ConsultarParametrosGenerico(paramName, LinkedServer)
    End Function

    Public Shared Function configurarDataTableMedicaParaGrabar(ByVal dtMedicamentos As DataTable) As DataTable
        Dim dtFiltrado As DataTable

        dtFiltrado = dtMedicamentos.Copy()
        With dtFiltrado.Columns
            .Remove("prescripcion")
            .Remove("descripcion")
            .Remove("nombreMedico")
            .Remove("especialidad")
        End With

        Return dtFiltrado
    End Function


End Class
