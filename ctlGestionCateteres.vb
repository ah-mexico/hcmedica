Imports System
Imports System.Array
Imports System.IO
Imports System.Collections.Generic
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports HistoriaClinica.wsCuidadoPaliativo
Imports System.Xml.Linq

Public Module variables 'Santiago Balcero Se definen variables globales para captura
    Public fechacat As DateTime,
           tipocateter1 As String,
           zoninser As String,
           lateral As String,
           Indicacion As String,
           complica As String,
           npuncion As String,
           responsable1 As String,
           especialidad1 As String,
           codcateter As String,
           estcateter As String
End Module
Public Class ctlGestionCateteres
    Private Shared _Instancia As ctlGestionCateteres
    Private objGeneral As Generales
    Private objPaciente As Paciente
    Private objConexion As Conexion
    Private objEvolucion As Evolucion
    Private objGestionCateteres As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOEnfermeriaCP
    Private lstGestionCateteres As List(Of RegistroCateter)
    ''Paginar DatagridView
    Private objDtGestionCateter As DataTable
    Private ErrorModulo As String = ""
#Region "Instancia de Control"
    Public Shared ReadOnly Property Instancia() As ctlGestionCateteres
        Get
            If _Instancia Is Nothing Then
                _Instancia = New ctlGestionCateteres
            End If
            Return _Instancia
        End Get
    End Property
#End Region

    ''' <summary>
    ''' Opciones de Cargue Inicial del Control según el estado (N:Nuevo)
    ''' Trae La Fecha actual del Servidor
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
#Region "Load"
    Private Sub ctlGestionCateteres_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        frmHistoriaPrincipal.blnFirstEvolucion = False
        objGeneral = Generales.Instancia
        objPaciente = Paciente.Instancia
        objConexion = Conexion.Instancia
        IniciarGestionCateteres()
    End Sub

    Private Sub IniciarGestionCateteres()
        LimpiarDatos()
        CargarDataGridView()
    End Sub

    Private Sub ctlGestionCateteres_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged
        If sender.Visible = True Then
            IniciarGestionCateteres()
        End If
    End Sub
#End Region

#Region "Historicos de Avicena"

    Private Function CargarHistoricosGestionCateteresAvicena()

        Dim strMensaje As String = ""
        Dim dtdatosPregunta As New DataTable
        Dim srvGestionCateteres As New CuidadosPaleativosServiceImpService()
        ''Llamar al historico
        Dim strIP As String = ""
        Dim strHostName As String
        strHostName = System.Net.Dns.GetHostName()
        strIP = System.Net.Dns.GetHostByName(strHostName).AddressList(0).ToString()
        ''Para Almacenar los Cateteres retirados de Historico de Avicena
        Dim ArregloCateteresRetiradosEncontrados() As String

        Try
            ErrorModulo = "CargarHistoricosGestionCateteresAvicena"

            dtdatosPregunta = objGestionCateteres.ConsultaParametricaCateteres  ''seccion de las preguntas

            If dtdatosPregunta.Rows.Count > 0 Then
                Dim aPreHisAvicena As New UltimaRespuestaResquestType
                Dim aPreHisPreguntas(dtdatosPregunta.Rows.Count) As Long
                Dim aUltimaRespuesta(dtdatosPregunta.Rows.Count) As GrupoFechaType
                Dim DAOCP As New DAOCuidadosPaliativos()
                Dim Resultado, ResultadoInsercionCateter_Seguimiento As String
                Dim appOrigen As String = objPaciente.AppOrigenCP.ToUpper()
                Dim Fecha As String
                Dim dtDato As New DataTable
                Dim Dias As Integer = 0

                srvGestionCateteres.Url = DAOCP.ConsultarUrlServicioUT(objGeneral.Prestador, objGeneral.Sucursal, DAOCP.TipoServicio, DAOCP.MetodoServicioH)

                '''srvGestionCateteres.Url = "http://pappj605.colsanitas.com:8180/CuidadosPaleativosWS/CuidadosPaleativosService?wsdl"

                If srvGestionCateteres.Url = "" Then
                    Throw New Exception("No fue posible consultar el servicio de últimas respuestas (URL).")
                End If

                dtDato = objGestionCateteres.ConsultarDiasHistorico("Historico_Cateteres_Paliativos")
                If dtDato.Rows.Count = 0 Then
                    MsgBox("No existen parametros para el calculo de dias historico paliativos")
                Else
                    Dias = dtDato.Rows(0).Item("valor").ToString
                End If

                aPreHisAvicena.tipoDocumento = objPaciente.TipoDocumento
                aPreHisAvicena.numeroDocumento = objPaciente.NumeroDocumento ''objPaciente.NumeroDocumento  ''objPaciente.NumeroDocumento '''SE PROBARON CON ESTAS: 41413631 223344   79782569

                For i As Integer = 0 To dtdatosPregunta.Rows.Count - 1
                    aPreHisPreguntas(i) = dtdatosPregunta.Rows(i).Item("id_pregunta").ToString
                Next
                aPreHisAvicena.preguntas = aPreHisPreguntas
                aPreHisAvicena.origen = appOrigen
                ''WACHV, 22Dic2017, Se agrega Obtener la ref regional en cada Bd
                '',se cambia parametro de regional objPaciente.Ciudad.ToUpper() por lo retornado en strRegionalRefBD
                Dim strRegionalRefBD As String = DAOCP.ConsultarRegional()
                aPreHisAvicena.regional = strRegionalRefBD.ToUpper()

                Fecha = Format(DateTime.Now, "yyyy-MM-dd")
                Fecha = Fecha & " 23:59:59"

                ''ojo verificar el numero de dias, para este caso de cateteres, deben ser 360, si es diferente no trae
                Resultado = srvGestionCateteres.historicoRespuestas(aPreHisAvicena, Dias, Fecha, DAOCP.ProgramaH.ToUpper(), DAOCP.SeccionH.ToUpper(), DAOCP.SubSeccionHCateter.ToUpper(), aUltimaRespuesta)
                ''Obtiene los Catetres Retirados de los retornado x el WS
                ArregloCateteresRetiradosEncontrados = fncCateteresRetirados(aUltimaRespuesta)
                ''Guarda los cateteres y los seguimientos que vienen del WS
                ResultadoInsercionCateter_Seguimiento = strGuardarCateterHistoAvicena(aUltimaRespuesta, ArregloCateteresRetiradosEncontrados)
            End If
        Catch ex As Exception
            'Throw ex
            If ex.Message <> "ERROR" Then ''Si es un mensaje diferenet a retornado del  WS
                ErroresHC_Paliativos(ex.Source & " - " & Environment.MachineName.ToString & " - " & ErrorModulo, ex.Message, ex.StackTrace & " - " & ex.TargetSite.ToString)
                'Else
                'Dim strMensajeWs As String = DirectCast(DirectCast(ex, System.Web.Services.Protocols.SoapException).Detail, System.[Xml].XmlElement).InnerText
                'ErroresHC_Paliativos(ex.Source & " - " & Environment.MachineName.ToString & " - " & ErrorModulo, strMensajeWs, ex.StackTrace & " - " & ex.TargetSite.ToString)
            End If

        End Try
    End Function
    ''Funcion para Guardar los cateteres del Historico de Avicena, 
    'Si no es un Cateter Retirado segun el arreglo obtenido
    Public Function strGuardarCateterHistoAvicena(ByVal aUltimaRespuestaIn() As GrupoFechaType,
                                            ByRef strCateterRetiradoEncontrado As String()) As String
        Dim strCateteraGestionar As String = ""
        Dim ResultadoInsercionCateter As String = ""
        Dim ResultadoInsercionSeguimiento As String = ""
        Dim ListItemsIndicaciones As New List(Of String)
        Dim strIndicaciones As String = ""
        Dim ListItemsComplicaciones As New List(Of String)
        Dim strComplicaciones As String = ""

        Try
            ErrorModulo = "strGuardarCateterHistoAvicena"
            For i As Integer = 0 To aUltimaRespuestaIn.Length  ''Recorrer todo lo obtenido
                'For i As Integer = aUltimaRespuestaIn.Length - 1 To 0 Step -1 ''Recorrer todo lo obtenido
                Dim aUltimaRespuestaCateter As GrupoFechaType = aUltimaRespuestaIn(i)
                Dim objCateterAvicena As New RegistroCateter             ''Agregar Cateteres de Avicena
                objCateterAvicena.Cod_pre_sgs = objGeneral.Prestador
                objCateterAvicena.Cod_sucur = objGeneral.Sucursal
                objCateterAvicena.Tip_admision = objPaciente.TipoAdmision
                objCateterAvicena.Ano_adm = objPaciente.AnoAdmision
                objCateterAvicena.Num_adm = objPaciente.NumeroAdmision
                objCateterAvicena.Tip_Doc = objPaciente.TipoDocumento
                objCateterAvicena.Num_Doc = objPaciente.NumeroDocumento
                strCateteraGestionar = ""
                ResultadoInsercionCateter = ""
                If Not aUltimaRespuestaCateter.resultadosHist Is Nothing And aUltimaRespuestaCateter.resultadosHist.Length > 0 Then
                    For j As Integer = 0 To aUltimaRespuestaCateter.resultadosHist.Length - 1 ''Recorrer cada uno de los items
                        ''Armar Primero el cateter y luego el seguimiento x el codigo combinado de Catéter a gestionar
                        Select Case aUltimaRespuestaCateter.resultadosHist(j).idPregunta
                            Case "957" ''Fecha Insercion cateter
                                objCateterAvicena.Tip_Registro = "INSERCION"
                                objCateterAvicena.Fec_Insercion = aUltimaRespuestaCateter.fecha
                                objCateterAvicena.Fec_Insercion = Format(CDate(objCateterAvicena.Fec_Insercion), "dd/MM/yyyy hh:mm")
                            Case "958" ''Tipo Cateter
                                objCateterAvicena.Tip_Cateter = aUltimaRespuestaCateter.resultadosHist(j).codRespuesta
                            Case "959" ''Zona Insercion
                                objCateterAvicena.Sitio_Insercion = aUltimaRespuestaCateter.resultadosHist(j).codRespuesta
                            Case "914" ''Lateralidad
                                objCateterAvicena.Lateralidad = aUltimaRespuestaCateter.resultadosHist(j).codRespuesta
                            Case "960" ''calibre
                                objCateterAvicena.Calibre = aUltimaRespuestaCateter.resultadosHist(j).codRespuesta
                            Case "961" ''Punciones
                                objCateterAvicena.NroPunciones = aUltimaRespuestaCateter.resultadosHist(j).codRespuesta
                            Case "962" ''Indicaciones
                                ListItemsIndicaciones.Add(aUltimaRespuestaCateter.resultadosHist(j).codRespuesta)
                            Case "963" ''Complicaciones
                                ListItemsComplicaciones.Add(aUltimaRespuestaCateter.resultadosHist(j).codRespuesta)
                            Case "964" ''Dicotomica Si/NO Seguimiento del Cateter
                                objCateterAvicena.Seguimiento_del_cateter = aUltimaRespuestaCateter.resultadosHist(j).codRespuesta
                            Case "965" ''Tipo de Cateter a Gestionar
                                objCateterAvicena.Tip_Cateter_Gestionar = aUltimaRespuestaCateter.resultadosHist(j).codRespuesta
                            Case "974" ''Responsable
                                objCateterAvicena.LoginMedico = aUltimaRespuestaCateter.resultadosHist(j).interpretacion
                            Case "975" ''Especialidad
                                objCateterAvicena.Especialidad = aUltimaRespuestaCateter.resultadosHist(j).interpretacion
                        End Select
                        ''Obtener le codigo del cateter a gestionar, segun la combinacion
                        If Not objCateterAvicena.Tip_Cateter = Nothing And Not objCateterAvicena.Sitio_Insercion = Nothing And Not objCateterAvicena.Lateralidad = Nothing Then
                            strCateteraGestionar = fncCateteraGestionar(objCateterAvicena.Tip_Cateter, objCateterAvicena.Sitio_Insercion, objCateterAvicena.Lateralidad)
                        End If
                    Next j


                    If ListItemsIndicaciones.Count > 0 Then
                        strIndicaciones = String.Join("<|^|>", ListItemsIndicaciones.ToArray())
                        objCateterAvicena.Indicaciones = strIndicaciones
                    End If

                    If ListItemsComplicaciones.Count > 0 Then
                        strComplicaciones = String.Join("<|^|>", ListItemsComplicaciones.ToArray())
                        objCateterAvicena.Complicaciones = strComplicaciones
                    End If

                    objCateterAvicena.Login = objGeneral.Login
                    objCateterAvicena.Obs = String.Empty
                    objCateterAvicena.EsSophia = "NO" ''Marca que provienen del Hist. de Avicena

                    Dim bExiste As Boolean = False
                    'Evaluar si existe el codigo de cateter a retirados en los catetres a insertar
                    For x As Integer = 0 To strCateterRetiradoEncontrado.Length - 1
                        If strCateterRetiradoEncontrado(x) = strCateteraGestionar Then
                            bExiste = True
                        End If
                    Next
                    ''Si presenta Datos
                    If bExiste = False And Not objCateterAvicena.Fec_Insercion = Nothing Then
                        ''Si no Existe el cateter previamente lo inserta
                        If Me.objGestionCateteres.BuscarCombinacionCateter(objCateterAvicena.Tip_Doc, objCateterAvicena.Num_Doc,
                                                                           objCateterAvicena.Fec_Insercion, objCateterAvicena.Tip_Cateter,
                                                                           objCateterAvicena.Sitio_Insercion,
                                                                           objCateterAvicena.Lateralidad) = False Then
                            ResultadoInsercionCateter = ResultadoInsercionCateter & Me.objGestionCateteres.GuardarRegistroCateter(objCateterAvicena)
                            ResultadoInsercionSeguimiento = strGuardarSeguimientoCateter(aUltimaRespuestaIn, objCateterAvicena.Fec_Insercion, strCateteraGestionar, i)
                            strCateteraGestionar = ""
                        End If
                    End If
                End If
            Next i
            ''Retorna lo que cada proceso genero
            strGuardarCateterHistoAvicena = ResultadoInsercionCateter + ResultadoInsercionSeguimiento

        Catch ex As Exception
            ErroresHC_Paliativos(ex.Source & " - " & Environment.MachineName.ToString & " - " & ErrorModulo, ex.Message, ex.StackTrace & " - " & ex.TargetSite.ToString)
        End Try
    End Function
    ''Esta Funcion permite guardar los seguimientos del cateter encontrado x la combinacion del cateter a gestionar
    Public Function strGuardarSeguimientoCateter(ByVal aUltimaRespuestaIn() As GrupoFechaType,
                                                 ByVal strFechaCateter As String,
                                                 ByVal strCateteraGestionar As String, reg As Integer) As String
        Dim ResultadoSeguimiento As String = ""
        Try
            ErrorModulo = "strGuardarSeguimientoCateter"
            For i As Integer = reg To reg ''Recorrer todo lo obtenido
                Dim aUltimaRespuestaSeguimiento As GrupoFechaType = aUltimaRespuestaIn(i)
                Dim objSeguimientoCateterAvicena As New RegistroCateter  ''Agregar Seguimientos de Avicena
                Dim ListItemsEstadoSitioInsercion As New List(Of String)
                Dim strEstadoSitioInsercion As String = ""
                Dim ListItemsCuraciones As New List(Of String)
                Dim strCuraciones As String = ""
                Dim ListItemsSeVerifica As New List(Of String)
                Dim strSeVerifica As String = ""
                Dim ListItemsGestionFinal As New List(Of String)
                Dim strGestionFinal As String = ""
                Dim ListItemsMotivoRetiro As New List(Of String)
                Dim strMotivoRetiro As String = ""
                objSeguimientoCateterAvicena.Cod_pre_sgs = objGeneral.Prestador
                objSeguimientoCateterAvicena.Cod_sucur = objGeneral.Sucursal
                objSeguimientoCateterAvicena.Tip_admision = objPaciente.TipoAdmision
                objSeguimientoCateterAvicena.Ano_adm = objPaciente.AnoAdmision
                objSeguimientoCateterAvicena.Num_adm = objPaciente.NumeroAdmision
                objSeguimientoCateterAvicena.Tip_Doc = objPaciente.TipoDocumento
                objSeguimientoCateterAvicena.Num_Doc = objPaciente.NumeroDocumento
                If Not aUltimaRespuestaSeguimiento.resultadosHist Is Nothing And aUltimaRespuestaSeguimiento.resultadosHist.Length > 0 Then
                    For j As Integer = 0 To aUltimaRespuestaSeguimiento.resultadosHist.Length - 1 ''Recorrer cada uno de los items
                        ''Ciclo para los seguimientos de cada cateter por el codigo combinado
                        ''Armar los seguimientos del cateter
                        Select Case aUltimaRespuestaSeguimiento.resultadosHist(j).idPregunta
                            Case "966" ''Fecha Insercion Seguimiento
                                objSeguimientoCateterAvicena.Tip_Registro = "SEGUIMIENTO"
                                objSeguimientoCateterAvicena.Fec_Insercion = aUltimaRespuestaSeguimiento.resultadosHist(j).interpretacion
                            Case "967" ''Dias Cateter
                                objSeguimientoCateterAvicena.Dias_Cateter = aUltimaRespuestaSeguimiento.resultadosHist(j).interpretacion
                            Case "968" ''Estado sitio de inserción
                                ListItemsEstadoSitioInsercion.Add(aUltimaRespuestaSeguimiento.resultadosHist(j).codRespuesta)
                            Case "969" ''Se realiza curación Dicotomica
                                If aUltimaRespuestaSeguimiento.resultadosHist(j).interpretacion = "SI" Then
                                    objSeguimientoCateterAvicena.RealizoCuracion = "96901"
                                Else
                                    objSeguimientoCateterAvicena.RealizoCuracion = "96902"
                                End If
                            Case "970" ''Curaciones  
                                ListItemsCuraciones.Add(aUltimaRespuestaSeguimiento.resultadosHist(j).codRespuesta)
                            Case "971" ''Se verifica 
                                ListItemsSeVerifica.Add(aUltimaRespuestaSeguimiento.resultadosHist(j).codRespuesta)
                            Case "972"  ''Gestion final
                                ListItemsGestionFinal.Add(aUltimaRespuestaSeguimiento.resultadosHist(j).codRespuesta)
                            Case "973" ''Motivo retiro 
                                ListItemsMotivoRetiro.Add(aUltimaRespuestaSeguimiento.resultadosHist(j).codRespuesta)
                            Case "974" ''Responsable
                                objSeguimientoCateterAvicena.LoginMedico = aUltimaRespuestaSeguimiento.resultadosHist(j).interpretacion
                            Case "975" ''Especialidad
                                objSeguimientoCateterAvicena.Especialidad = aUltimaRespuestaSeguimiento.resultadosHist(j).interpretacion
                        End Select
                    Next j
                    ''Cuando Termina el ciclo, se guardan los que se encontraron de cadauno
                    '''Retorna los que son Multiples opciones
                    If ListItemsEstadoSitioInsercion.Count > 0 Then
                        ''Ojo cod 968, se cambia para este codigo y al guardar los seguimientos a SignosPresentados que es para Seguimientos
                        strEstadoSitioInsercion = String.Join("<|^|>", ListItemsEstadoSitioInsercion.ToArray())
                        objSeguimientoCateterAvicena.SignosPresentados = strEstadoSitioInsercion
                    End If
                    If ListItemsCuraciones.Count > 0 Then
                        strCuraciones = String.Join("<|^|>", ListItemsCuraciones.ToArray())
                        objSeguimientoCateterAvicena.ElementosCuracion = strCuraciones
                    End If
                    If ListItemsSeVerifica.Count > 0 Then
                        strSeVerifica = String.Join("<|^|>", ListItemsSeVerifica.ToArray())
                        objSeguimientoCateterAvicena.SeVerifica = strSeVerifica
                    End If
                    If ListItemsGestionFinal.Count > 0 Then
                        strGestionFinal = String.Join("<|^|>", ListItemsGestionFinal.ToArray())
                        objSeguimientoCateterAvicena.GestionFinal = strGestionFinal
                    End If
                    If ListItemsMotivoRetiro.Count > 0 Then
                        strMotivoRetiro = String.Join("<|^|>", ListItemsMotivoRetiro.ToArray())
                        objSeguimientoCateterAvicena.MotivoRetiro = strMotivoRetiro
                    End If

                    ''Se agrega para que realice la misma operacion para saber que seguimiento es de cual Cateter
                    objSeguimientoCateterAvicena.CodCateter = strCateteraGestionar
                    objSeguimientoCateterAvicena.Fec_Curacion = strFechaCateter

                    objSeguimientoCateterAvicena.Login = objGeneral.Login
                    objSeguimientoCateterAvicena.Obs = String.Empty
                    objSeguimientoCateterAvicena.EsSophia = "NO"

                    ''Esto es por si llega desde historico de avicena la fecha sin dato
                    If Not objSeguimientoCateterAvicena.Fec_Insercion = Nothing Then ''Si tiene Fecha de Insercion seguimiento
                        ResultadoSeguimiento = ResultadoSeguimiento & Me.objGestionCateteres.GuardaSeguimientoCateter(objSeguimientoCateterAvicena)
                    End If

                End If ''Si no es vacio o nothing
            Next i

            strGuardarSeguimientoCateter = ResultadoSeguimiento

        Catch ex As Exception
            ErroresHC_Paliativos(ex.Source & " - " & Environment.MachineName.ToString & " - " & ErrorModulo, ex.Message, ex.StackTrace & " - " & ex.TargetSite.ToString)
        End Try

    End Function

    ''Funcion que Obtiene los Cateteres que tiene estado retirado de los que llegan x el Ws
    ''Para utilizar el resultado y descartar estos cateteres antes de insertarlos
    Public Function fncCateteresRetirados(ByVal aUltimaRespuestaIn() As GrupoFechaType) As String()
        Dim strCateteraGestionar As String = ""
        Dim bEstaRetirado As Boolean = False
        Dim ArregloCateteresRetirados() As String

        Try
            ErrorModulo = "fncCateteresRetirados"
            If (IsNothing(ArregloCateteresRetirados)) Then
                ReDim ArregloCateteresRetirados(0)
            ElseIf (UBound(ArregloCateteresRetirados) = -1) Then
                ReDim ArregloCateteresRetirados(0)
            End If

            For i As Integer = aUltimaRespuestaIn.Length - 1 To 0 Step -1 ''Recorrer todo lo obtenido
                Dim aUltimaRespuestaSeguimiento As GrupoFechaType = aUltimaRespuestaIn(i)
                strCateteraGestionar = ""
                bEstaRetirado = False
                If Not aUltimaRespuestaSeguimiento.resultadosHist Is Nothing And aUltimaRespuestaSeguimiento.resultadosHist.Length > 0 Then
                    For j As Integer = 0 To aUltimaRespuestaSeguimiento.resultadosHist.Length - 1 ''Recorrer cada uno de los items
                        ''Ciclo para los seguimientos de cada cateter por el codigo combinado
                        ''Armar los seguimientos del cateter
                        Select Case aUltimaRespuestaSeguimiento.resultadosHist(j).idPregunta
                            Case "972", "965" '' Gestion final y Catéter a gestionar
                                If aUltimaRespuestaSeguimiento.resultadosHist(j).idPregunta = "972" Then
                                    If aUltimaRespuestaSeguimiento.resultadosHist(j).codRespuesta = "97201" Then ''Si esta Retirado
                                        bEstaRetirado = True
                                    End If
                                End If
                                If aUltimaRespuestaSeguimiento.resultadosHist(j).idPregunta = "965" Then
                                    strCateteraGestionar = aUltimaRespuestaSeguimiento.resultadosHist(j).codRespuesta
                                End If

                                If bEstaRetirado = True And Len(strCateteraGestionar) > 0 Then
                                    If UBound(ArregloCateteresRetirados) = 0 And IsNothing(ArregloCateteresRetirados(UBound(ArregloCateteresRetirados))) Then
                                        ArregloCateteresRetirados(UBound(ArregloCateteresRetirados)) = strCateteraGestionar
                                    Else
                                        ReDim Preserve ArregloCateteresRetirados(UBound(ArregloCateteresRetirados) + 1)
                                        ArregloCateteresRetirados(UBound(ArregloCateteresRetirados)) = strCateteraGestionar
                                    End If
                                End If
                        End Select
                    Next
                End If
            Next

            fncCateteresRetirados = ArregloCateteresRetirados

        Catch ex As Exception
            ErroresHC_Paliativos(ex.Source & " - " & Environment.MachineName.ToString & " - " & ErrorModulo, ex.Message, ex.StackTrace & " - " & ex.TargetSite.ToString)
        End Try

    End Function
    Private Function fncCateteraGestionar(ByVal tip_cat As String, ByVal sit_ins As String, ByVal lat_cat As String) As String

        Dim idParametrica As String = ""

        '--SUBCUTANEO
        If (tip_cat = "95802" And sit_ins = "95904" And lat_cat = "91402") Then idParametrica = "96501"  ''--Subcutaneo - Abdomen - Derecha
        If (tip_cat = "95802" And sit_ins = "95904" And lat_cat = "91401") Then idParametrica = "96502"   ''--Subcutaneo - Abdomen - Izquierda
        If (tip_cat = "95802" And sit_ins = "95901" And lat_cat = "91402") Then idParametrica = "96503"   ''--Subcutaneo - Deltoides - Derecha
        If (tip_cat = "95802" And sit_ins = "95901" And lat_cat = "91401") Then idParametrica = "96504"   ''--Subcutaneo - Deltoides - Izquierda
        If (tip_cat = "95802" And sit_ins = "95903" And lat_cat = "91402") Then idParametrica = "96505"   ''--Subcutaneo - Escapular - Derecha
        If (tip_cat = "95802" And sit_ins = "95903" And lat_cat = "91401") Then idParametrica = "96506"   ''--Subcutaneo - Escapular - Izquierda
        If (tip_cat = "95802" And sit_ins = "95902" And lat_cat = "91402") Then idParametrica = "96507"   ''--Subcutaneo - Infraclavicular - Derecha
        If (tip_cat = "95802" And sit_ins = "95902" And lat_cat = "91401") Then idParametrica = "96508"   ''--Subcutaneo - Infraclavicular - Izquierda
        If (tip_cat = "95802" And sit_ins = "95905" And lat_cat = "91402") Then idParametrica = "96509"   ''--Subcutaneo - Muslo(Cara Anterior) - Derecha
        If (tip_cat = "95802" And sit_ins = "95905" And lat_cat = "91401") Then idParametrica = "96510"   ''--Subcutaneo - Muslo(Cara Anterior) - Izquierda
        ''--VASCULAR PERIFERICO
        If (tip_cat = "95801" And sit_ins = "95913" And lat_cat = "91402") Then idParametrica = "96511"   ''--Vascular periférico - Arco dorsal mano - Derecha
        If (tip_cat = "95801" And sit_ins = "95913" And lat_cat = "91402") Then idParametrica = "96511"   ''--Vascular periférico - Arco dorsal mano - Derecha
        If (tip_cat = "95801" And sit_ins = "95913" And lat_cat = "91401") Then idParametrica = "96512"   ''--Vascular periférico - Arco dorsal mano - Izquierda
        If (tip_cat = "95801" And sit_ins = "95907" And lat_cat = "91402") Then idParametrica = "96513"   ''--Vascular periférico - Basílica brazo - Derecha
        If (tip_cat = "95801" And sit_ins = "95907" And lat_cat = "91401") Then idParametrica = "96514"   ''--Vascular periférico - Basílica brazo - Izquierda
        If (tip_cat = "95801" And sit_ins = "95911" And lat_cat = "91402") Then idParametrica = "96515"   ''--Vascular periférico - Basílica mano - Derecha
        If (tip_cat = "95801" And sit_ins = "95911" And lat_cat = "91401") Then idParametrica = "96516"   ''--Vascular periférico - Basílica mano - Izquierda
        If (tip_cat = "95801" And sit_ins = "95909" And lat_cat = "91402") Then idParametrica = "96517"   ''--Vascular periférico - Cefálica antebrazo - Derecha
        If (tip_cat = "95801" And sit_ins = "95909" And lat_cat = "91401") Then idParametrica = "96518"   ''--Vascular periférico - Cefálica antebrazo - Izquierda
        If (tip_cat = "95801" And sit_ins = "95906" And lat_cat = "91402") Then idParametrica = "96519"   ''--Vascular periférico - Cefálica brazo - Derecha
        If (tip_cat = "95801" And sit_ins = "95906" And lat_cat = "91401") Then idParametrica = "96520"   ''--Vascular periférico - Cefálica brazo - Izquierda
        If (tip_cat = "95801" And sit_ins = "95912" And lat_cat = "91402") Then idParametrica = "96521"   ''--Vascular periférico - Cefálica mano - Derecha
        If (tip_cat = "95801" And sit_ins = "95912" And lat_cat = "91401") Then idParametrica = "96522"   ''--Vascular periférico - Cefálica mano - Izquierda
        If (tip_cat = "95801" And sit_ins = "95910" And lat_cat = "91402") Then idParametrica = "96523"   ''--Vascular periférico - Media antebrazo - Derecha
        If (tip_cat = "95801" And sit_ins = "95910" And lat_cat = "91401") Then idParametrica = "96524"   ''--Vascular periférico - Media antebrazo - Izquierda
        If (tip_cat = "95801" And sit_ins = "95908" And lat_cat = "91402") Then idParametrica = "96525"   ''--Vascular periférico - Media cubital - Derecha
        If (tip_cat = "95801" And sit_ins = "95908" And lat_cat = "91401") Then idParametrica = "96526"   ''--Vascular periférico - Media cubital - Izquierda
        If (tip_cat = "95801" And sit_ins = "95914" And lat_cat = "91402") Then idParametrica = "96527"   ''--Vascular periférico - Metacarpiana - Derecha
        If (tip_cat = "95801" And sit_ins = "95914" And lat_cat = "91401") Then idParametrica = "96528"   ''--Vascular periférico - Metacarpiana - Izquierda

        fncCateteraGestionar = idParametrica

    End Function

#End Region

    ''' <summary>
    ''' Limpia Todos los controles del Control
    ''' </summary>
    ''' <remarks></remarks>

#Region "ImprimirReporte"
    Public Sub ImprimirReporte(ByVal strFecha As String, ByVal intHora As Integer, ByVal intMinuto As Integer, ByVal strcierre As String) 'martovar 2.9.0 req.03 2014-08-08 generacion de interconsultas 
        'frmRepEvolucion.Show()
        Dim dteFecha As String
        If strFecha.Length > 0 Then
            dteFecha = strFecha
        Else
            dteFecha = ""
        End If
        frmRepEvolucion.Show()
        frmRepEvolucion.imprimirRepEvolucion(objConexion, objGeneral.Prestador, objGeneral.Sucursal,
                                            objPaciente.TipoAdmision, objPaciente.AnoAdmision,
                                            objPaciente.NumeroAdmision, dteFecha, intHora, intMinuto,
                                            objGeneral.Login, strcierre)

    End Sub
#End Region

    Private Sub LimpiarDatos()
        dtgvGestionCateter.Refresh()
    End Sub
    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

#Region "CargarDataGridView"

    Private Sub CargarDataGridView()

        ''Inserta la informacion de que proviene de Avicena, si el registro no esta ya insertado, solo cateteres activos
        CargarHistoricosGestionCateteresAvicena()

        objDtGestionCateter = Nothing
        objDtGestionCateter = objGestionCateteres.ConsultarGestionCateter(Paciente.Instancia.TipoDocumento,
                                                                          Paciente.Instancia.NumeroDocumento,
                                                                          objGeneral.Prestador, objGeneral.Sucursal,
                                                                          objPaciente.TipoAdmision,
                                                                          objPaciente.AnoAdmision,
                                                                          objPaciente.NumeroAdmision)
        If objDtGestionCateter.Rows.Count >= 0 Then
            dtgvGestionCateter.AllowUserToAddRows = False
            dtgvGestionCateter.AutoGenerateColumns = False
            dtgvGestionCateter.DataSource = objDtGestionCateter
        Else
            dtgvGestionCateter.AllowUserToAddRows = True
            dtgvGestionCateter.DataSource = Nothing
        End If

    End Sub

#End Region

    ''' <summary>
    ''' Consulta Valores Inciales de la Historia Clínica y asigna valores 
    ''' en cada uno de los controles y objetos del Formulario
    ''' </summary>
    ''' <remarks></remarks>
#Region "ConsultarValores"
    Private Sub ConsultarValores()
        Dim objBl As New Sophia.HistoriaClinica.BL.BLEgresos

        Dim dtDiagnostico As New DataTable
        Dim i As Integer

        Try

            '// Consultar valores iniciales cuando no se cierra la historia \\
            dtDiagnostico = objBl.ConsultarDiagnosticoReingreso(objGeneral.Prestador, objGeneral.Sucursal,
                                    objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                    "E", objGeneral.Login, objConexion)


        Catch ex As Exception
            'MsgBox("Error al consultar datos", MsgBoxStyle.Exclamation)
        End Try

    End Sub
#End Region

    Public Sub SugerirRespuesta()
        Try
            LimpiarDatos()
            loadGestionCateteres()

        Catch ex As Exception
            MessageBox.Show("No fue posible consultar las últimas respuestas de este paciente.", "Historia Clínica", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

        End Try
    End Sub

    Private Sub loadGestionCateteres()
        Try
            CargarDataGridView()
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

    Private Function bvalidarFecha(ByVal strvalorvalidar As String) As Boolean

        Dim bValidaFecha As Boolean = False
        Dim fechaMinima As New DateTime(1900, 1, 1)
        Dim fechaMaxima As DateTime = Format(FuncionesGenerales.FechaServidor())
        Dim dtFechaNacimientoPaciente As Date = objPaciente.FechaNacimiento

        Try
            ' Valor a Evaluar
            '
            If IsDate(strvalorvalidar) Then
                Dim fecha As DateTime = CDate(strvalorvalidar)

                If (fecha < fechaMinima) OrElse (fecha > fechaMaxima) OrElse (fecha < dtFechaNacimientoPaciente) Then
                    'MessageBox.Show("Fecha errónea")
                    bValidaFecha = True
                End If
            Else
                'MessageBox.Show("Fecha errónea")
                bValidaFecha = True
            End If

            bvalidarFecha = bValidaFecha

        Catch ex As Exception
            bValidaFecha = True
        End Try

    End Function
    Private Sub btnAgregarCateter_Click(sender As Object, e As EventArgs) Handles btnAgregarCateter.Click
        Dim frmModalOpercionesCateter As New frmOperacionesCateter
        frmModalOpercionesCateter.iCaso = 1
        frmModalOpercionesCateter.ShowDialog()
        ctlGestionCateteres_Load(sender, e)
    End Sub

    Private Sub dgvInsercionCateteres_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgvGestionCateter.CellClick
        'Santiago Balcero, Se hace llamado a ctl de Seguimiento cateter
        Dim frmModalOpercionesCateter As New frmOperacionesCateter
        Dim drv As DataRowView
        If e.ColumnIndex <> -1 And e.RowIndex <> -1 Then
            drv = objDtGestionCateter.DefaultView.Item(e.RowIndex)
            If (dtgvGestionCateter.Columns(e.ColumnIndex).Name = "Seguimiento") Then
                If dtgvGestionCateter.RowCount >= 1 Then
                    fechacat = dtgvGestionCateter.Rows(e.RowIndex).Cells(7).Value
                    tipocateter1 = dtgvGestionCateter.Rows(e.RowIndex).Cells(9).Value
                    zoninser = dtgvGestionCateter.Rows(e.RowIndex).Cells(10).Value
                    lateral = dtgvGestionCateter.Rows(e.RowIndex).Cells(11).Value
                    Indicacion = dtgvGestionCateter.Rows(e.RowIndex).Cells(3).Value
                    If dtgvGestionCateter.Rows(e.RowIndex).Cells(12).Value.ToString = Nothing Then
                        complica = ""
                    Else
                        complica = dtgvGestionCateter.Rows(e.RowIndex).Cells(12).Value
                    End If
                    npuncion = dtgvGestionCateter.Rows(e.RowIndex).Cells(4).Value
                    responsable1 = dtgvGestionCateter.Rows(e.RowIndex).Cells(13).Value
                    especialidad1 = dtgvGestionCateter.Rows(e.RowIndex).Cells(14).Value
                    codcateter = dtgvGestionCateter.Rows(e.RowIndex).Cells(15).Value
                    estcateter = dtgvGestionCateter.Rows(e.RowIndex).Cells(16).Value

                    If drv.Item("activo").ToString = "1" Then
                        frmModalOpercionesCateter.iCaso = 3
                        frmModalOpercionesCateter.bActivarControles = True
                        frmModalOpercionesCateter.StartPosition = FormStartPosition.CenterScreen
                        frmModalOpercionesCateter.ShowDialog()
                        ctlGestionCateteres_Load(sender, e)
                    Else ''Muestra seguientos Inactivo
                        frmModalOpercionesCateter.iCaso = 3
                        frmModalOpercionesCateter.bActivarControles = False
                        frmModalOpercionesCateter.StartPosition = FormStartPosition.CenterScreen
                        frmModalOpercionesCateter.ShowDialog()
                        ctlGestionCateteres_Load(sender, e)
                    End If

                End If
            End If
        End If
    End Sub

    Private Sub dtgvGestionCateter_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dtgvGestionCateter.CellFormatting
        For i As Integer = 0 To Me.dtgvGestionCateter.Rows.Count - 1
            For ColNo As Integer = 1 To 17
                If Not dtgvGestionCateter.Rows(i).Cells(ColNo).Value Is DBNull.Value Then
                    If Me.dtgvGestionCateter.Rows(i).Cells("activo").Value = 0 Then ''Si Estan Retirados
                        dtgvGestionCateter.Rows(i).Cells(ColNo).Style.BackColor = Color.LightGray
                        dtgvGestionCateter.Rows(i).Cells(ColNo).Style.ForeColor = Color.DarkRed
                    ElseIf Me.dtgvGestionCateter.Rows(i).Cells("tip_reg").Value = "INSERCION" Then ''Insertados x Sophia
                        dtgvGestionCateter.Rows(i).Cells(ColNo).Style.BackColor = Color.White
                        dtgvGestionCateter.Rows(i).Cells(ColNo).Style.ForeColor = Color.DarkBlue
                    ElseIf Me.dtgvGestionCateter.Rows(i).Cells("tip_reg").Value = "AVINSERCION" Then ''Insertados del  hist. Avicena
                        dtgvGestionCateter.Rows(i).Cells(ColNo).Style.BackColor = Color.WhiteSmoke
                        dtgvGestionCateter.Rows(i).Cells(ColNo).Style.ForeColor = Color.DarkOliveGreen
                    End If
                End If
            Next
        Next

    End Sub

    Public Sub ErroresHC_Paliativos(ByVal ExSource As String, ByVal ExMessage As String, ByVal ExStackTrace As String)
        Dim objcontrolHcb As New Sophia.HistoriaClinica.BL.BLHistoriaBasica
        Dim Datos() As Object
        Dim lError As Long
        objGeneral = Generales.Instancia
        objPaciente = Paciente.Instancia
        objConexion = Conexion.Instancia
        Dim idErrorHC As Integer
        Dim objBL As New Sophia.HistoriaClinica.BL.BLBasicasGenerales

        ReDim Datos(11)
        Datos(0) = objGeneral.Prestador
        Datos(1) = objGeneral.Sucursal
        Datos(2) = objpaciente.TipoAdmision
        Datos(3) = objpaciente.AnoAdmision
        Datos(4) = objpaciente.NumeroAdmision
        Datos(5) = objpaciente.TipoDocumento
        Datos(6) = objpaciente.NumeroDocumento
        Datos(7) = ExSource
        Datos(8) = ExMessage
        Datos(9) = ExStackTrace
        Datos(10) = objGeneral.Login
        Datos(11) = lError

        Try
            lError = objBL.NErroresHC(objConexion, lError, Datos)
            idErrorHC = lError
        Catch ex As Exception

        End Try
    End Sub

End Class
