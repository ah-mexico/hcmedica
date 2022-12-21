Imports System.Collections.Generic
Imports HistoriaClinica.wsCuidadoPaliativo
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO

Public Class IngresoaPrograma

#Region "Properties"

    Private Shared _Instancia As IngresoaPrograma
    Private _cod_pre_sgs As String
    Private _cod_sucur As String
    Private _tip_admision As String
    Private _ano_adm As Integer
    Private _num_adm As Decimal
    Private _tip_doc As String
    Private _Num_doc As String
    Private _FechaIngreso As String
    Private _Harecibidoatencionpreviaporcuidadospaliativos As String
    Private _Donderecibioatencionporcuidadospaliativos As String
    Private _FechaDiagnostico As String
    Private _Harequeridoatencionporurgenciasuhospitalizacionenelultimomes As String
    Private _Fechadelaatencionporurgencias_Hospitalizacion_UltimoMes As String
    Private _Laatencionporurgencias_hospitalizacionestaasociadacoeldiagnosticodebase As String
    Private _Observacionesdelaatencion_Urgencias_Hospitalizacion As String
    Private _Harequeridoatencionporcirugiaambulatoriaenelultimomes As String
    Private _Fechadelaatencionporurgencias_Hospitalizacion As String
    Private _Elpacienteestarecibiendoalgunadelassiguientesintervenciones As String
    Private _Observacionesintervencionespaliativos As String
    Private _Conoceeldiagnostico_Paciente As String
    Private _Conoceelpronostico_Paciente As String
    Private _Pideinformacion_Paciente As String
    Private _Pidequenoseleinforme_Paciente As String

    Private _Conoceeldiagnostico_Familia As String
    Private _Conoceelpronostico_Familia As String
    Private _Pideinformacion_Familia As String
    Private _Pidequenoseleinforme_Familia As String

    Private _CercodeSilencio As String
    Private _Informacioninsuficiente As String

    Private _fec_con As DateTime
    Private _obs As String
    Private _login As String

    Public ReadOnly npFechaIngreso As String = "FechaIngreso"
    Public ReadOnly npHarecibidoatencionpreviaporcuidadospaliativos As String = "Harecibidoatencionpreviaporcuidadospaliativos"
    Public ReadOnly npDonderecibioatencionporcuidadospaliativos As String = "Donderecibioatencionporcuidadospaliativos"
    Public ReadOnly npFechaDiagnostico As String = "FechaDiagnostico"
    Public ReadOnly npHarequeridoatencionporurgenciasuhospitalizacionenelultimomes As String = "Harequeridoatencionporurgenciasuhospitalizacionenelultimomes"
    Public ReadOnly npFechadelaatencionporurgencias_Hospitalizacion_UltimoMes As String = "Fechadelaatencionporurgencias_Hospitalizacion_UltimoMes"
    Public ReadOnly npLaatencionporurgencias_hospitalizacionestaasociadacoeldiagnosticodebase As String = "Laatencionporurgencias_hospitalizacionestaasociadacoeldiagnosticodebase"
    Public ReadOnly npObservacionesdelaatencion_Urgencias_Hospitalizacion As String = "Observacionesdelaatencion_Urgencias_Hospitalizacion"
    Public ReadOnly npHarequeridoatencionporcirugiaambulatoriaenelultimomes As String = "Harequeridoatencionporcirugiaambulatoriaenelultimomes"
    Public ReadOnly npFechadelaatencionporurgencias_Hospitalizacion As String = "npFechadelaatencionporurgencias_Hospitalizacion"
    Public ReadOnly npElpacienteestarecibiendoalgunadelassiguientesintervenciones As String = "Elpacienteestarecibiendoalgunadelassiguientesintervenciones"
    Public ReadOnly npObservacionesintervencionespaliativos As String = "Observacionesintervencionespaliativos"
    Public ReadOnly npConoceeldiagnostico_Paciente As String = "Conoceeldiagnostico_Paciente"
    Public ReadOnly npConoceelpronostico_Paciente As String = "Conoceelpronostico_Paciente"
    Public ReadOnly npPideinformacion_Paciente As String = "Pideinformacion_Paciente"
    Public ReadOnly npPidequenoseleinforme_Paciente As String = "Pidequenoseleinforme_Paciente"
    Public ReadOnly npConoceeldiagnostico_Familia As String = "Conoceeldiagnostico_Familia"
    Public ReadOnly npConoceelpronostico_Familia As String = "Conoceelpronostico_Familia"
    Public ReadOnly npPideinformacion_Familia As String = "Pideinformacion_Familia"
    Public ReadOnly npPidequenoseleinforme_Familia As String = "Pidequenoseleinforme_Familia"

    Public ReadOnly npCercodeSilencio As String = "CercodeSilencio"
    Public ReadOnly npInformacioninsuficiente As String = "Informacioninsuficiente"

    Public ReadOnly Seccion As Integer = 1

    Public Shared ReadOnly Property Instancia() As IngresoaPrograma
        Get
            If _Instancia Is Nothing Then
                _Instancia = New IngresoaPrograma
            End If
            Return _Instancia
        End Get
    End Property

    Public Property cod_pre_sgs() As String
        Get
            Return _cod_pre_sgs
        End Get
        Set(ByVal Value As String)
            _cod_pre_sgs = Value
        End Set
    End Property

    Public Property cod_sucur() As String
        Get
            Return _cod_sucur
        End Get
        Set(ByVal Value As String)
            _cod_sucur = Value
        End Set
    End Property

    Public Property tip_admision() As String
        Get
            Return _tip_admision
        End Get
        Set(ByVal Value As String)
            _tip_admision = Value
        End Set
    End Property

    Public Property ano_adm() As Integer
        Get
            Return _ano_adm
        End Get
        Set(ByVal Value As Integer)
            _ano_adm = Value
        End Set
    End Property

    Public Property num_adm() As Decimal
        Get
            Return _num_adm
        End Get
        Set(ByVal Value As Decimal)
            _num_adm = Value
        End Set
    End Property

    Public Property tip_doc() As String
        Get
            Return _tip_doc
        End Get
        Set(ByVal Value As String)
            _tip_doc = Value
        End Set
    End Property

    Public Property Num_doc() As String
        Get
            Return _Num_doc
        End Get
        Set(ByVal Value As String)
            _Num_doc = Value
        End Set
    End Property

    Public Property FechaIngreso() As String
        Get
            Return _FechaIngreso
        End Get
        Set(ByVal Value As String)
            _FechaIngreso = Value
        End Set
    End Property

    Public Property Harecibidoatencionpreviaporcuidadospaliativos() As String
        Get
            Return _Harecibidoatencionpreviaporcuidadospaliativos
        End Get
        Set(ByVal Value As String)
            _Harecibidoatencionpreviaporcuidadospaliativos = Value
        End Set
    End Property

    Public Property Donderecibioatencionporcuidadospaliativos() As String
        Get
            Return _Donderecibioatencionporcuidadospaliativos
        End Get
        Set(ByVal Value As String)
            _Donderecibioatencionporcuidadospaliativos = Value
        End Set
    End Property

    Public Property FechaDiagnostico() As String
        Get
            Return _FechaDiagnostico
        End Get
        Set(ByVal Value As String)
            _FechaDiagnostico = Value
        End Set
    End Property

    Public Property Harequeridoatencionporurgenciasuhospitalizacionenelultimomes() As String
        Get
            Return _Harequeridoatencionporurgenciasuhospitalizacionenelultimomes
        End Get
        Set(ByVal Value As String)
            _Harequeridoatencionporurgenciasuhospitalizacionenelultimomes = Value
        End Set
    End Property

    Public Property Fechadelaatencionporurgencias_Hospitalizacion_UltimoMes() As String
        Get
            Return _Fechadelaatencionporurgencias_Hospitalizacion_UltimoMes
        End Get
        Set(ByVal Value As String)
            _Fechadelaatencionporurgencias_Hospitalizacion_UltimoMes = Value
        End Set
    End Property

    Public Property Laatencionporurgencias_hospitalizacionestaasociadacoeldiagnosticodebase() As String
        Get
            Return _Laatencionporurgencias_hospitalizacionestaasociadacoeldiagnosticodebase
        End Get
        Set(ByVal Value As String)
            _Laatencionporurgencias_hospitalizacionestaasociadacoeldiagnosticodebase = Value
        End Set
    End Property

    Public Property Observacionesdelaatencion_Urgencias_Hospitalizacion() As String
        Get
            Return _Observacionesdelaatencion_Urgencias_Hospitalizacion
        End Get
        Set(ByVal Value As String)
            _Observacionesdelaatencion_Urgencias_Hospitalizacion = Value
        End Set
    End Property

    Public Property Fechadelaatencionporurgencias_Hospitalizacion() As String
        Get
            Return _Fechadelaatencionporurgencias_Hospitalizacion
        End Get
        Set(ByVal Value As String)
            _Fechadelaatencionporurgencias_Hospitalizacion = Value
        End Set
    End Property

    Public Property Harequeridoatencionporcirugiaambulatoriaenelultimomes() As String
        Get
            Return _Harequeridoatencionporcirugiaambulatoriaenelultimomes
        End Get
        Set(ByVal Value As String)
            _Harequeridoatencionporcirugiaambulatoriaenelultimomes = Value
        End Set
    End Property

    Public Property Elpacienteestarecibiendoalgunadelassiguientesintervenciones() As String
        Get
            Return _Elpacienteestarecibiendoalgunadelassiguientesintervenciones
        End Get
        Set(ByVal Value As String)
            _Elpacienteestarecibiendoalgunadelassiguientesintervenciones = Value
        End Set
    End Property

    Public Property Observacionesintervencionespaliativos() As String
        Get
            Return _Observacionesintervencionespaliativos
        End Get
        Set(ByVal Value As String)
            _Observacionesintervencionespaliativos = Value
        End Set
    End Property

    Public Property Conoceeldiagnostico_Paciente() As String
        Get
            Return _Conoceeldiagnostico_Paciente
        End Get
        Set(ByVal Value As String)
            _Conoceeldiagnostico_Paciente = Value
        End Set
    End Property

    Public Property Pideinformacion_Paciente() As String
        Get
            Return _Pideinformacion_Paciente
        End Get
        Set(ByVal Value As String)
            _Pideinformacion_Paciente = Value
        End Set
    End Property


    Public Property Conoceelpronostico_Paciente() As String
        Get
            Return _Conoceelpronostico_Paciente
        End Get
        Set(ByVal Value As String)
            _Conoceelpronostico_Paciente = Value
        End Set
    End Property

    Public Property Pidequenoseleinforme_Paciente() As String
        Get
            Return _Pidequenoseleinforme_Paciente
        End Get
        Set(ByVal Value As String)
            _Pidequenoseleinforme_Paciente = Value
        End Set
    End Property

    Public Property Conoceeldiagnostico_Familia() As String
        Get
            Return _Conoceeldiagnostico_Familia
        End Get
        Set(ByVal Value As String)
            _Conoceeldiagnostico_Familia = Value
        End Set
    End Property

    Public Property Conoceelpronostico_Familia() As String
        Get
            Return _Conoceelpronostico_Familia
        End Get
        Set(ByVal Value As String)
            _Conoceelpronostico_Familia = Value
        End Set
    End Property

    Public Property Pideinformacion_Familia() As String
        Get
            Return _Pideinformacion_Familia
        End Get
        Set(ByVal Value As String)
            _Pideinformacion_Familia = Value
        End Set
    End Property

    Public Property Pidequenoseleinforme_Familia() As String
        Get
            Return _Pidequenoseleinforme_Familia
        End Get
        Set(ByVal Value As String)
            _Pidequenoseleinforme_Familia = Value
        End Set
    End Property

    Public Property CercodeSilencio() As String
        Get
            Return _CercodeSilencio
        End Get
        Set(ByVal Value As String)
            _CercodeSilencio = Value
        End Set
    End Property

    Public Property Informacioninsuficiente() As String
        Get
            Return _Informacioninsuficiente
        End Get
        Set(ByVal Value As String)
            _Informacioninsuficiente = Value
        End Set
    End Property


    Public Property fec_con() As DateTime
        Get
            Return _fec_con
        End Get
        Set(ByVal Value As DateTime)
            _fec_con = Value
        End Set
    End Property

    Public Property obs() As String
        Get
            Return _obs
        End Get
        Set(ByVal Value As String)
            _obs = Value
        End Set
    End Property

    Public Property login() As String
        Get
            Return _login
        End Get
        Set(ByVal Value As String)
            _login = Value
        End Set
    End Property

    Private lstPreguntasIngresoaProgramaCP As List(Of PreguntaCP)

#End Region

#Region "Funtions"

    Public Function ObtenerUltimaRespuesta(ByVal IdPregunta As Integer, ByVal Respuesta As String) As IngresoaPrograma
        Dim objDAOIngresoaPrograma As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOIngresoaPrograma
        Return objDAOIngresoaPrograma.ConsultarURIngresoaPrograma(IdPregunta, Respuesta)
    End Function

    Public Function ConsultarPreguntas(ByVal oPreguntaCP As PreguntaCP) As List(Of PreguntaCP)
        Dim objDAPreguntaCP As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOIngresoaPrograma
        oPreguntaCP.seccion = Me.Seccion
        Return objDAPreguntaCP.ConsultarPreguntas(oPreguntaCP)
    End Function

    Public Function SugerirRespuesta(ByVal objGeneral As Generales, ByVal objPaciente As Paciente) As IngresoaPrograma
        Dim srvIngresoaPrograma As New CuidadosPaleativosServiceImpService()

        Dim oIngresoaPrograma As New IngresoaPrograma()
        Dim oURIngresoaPrograma As New IngresoaPrograma()

        Try

            lstPreguntasIngresoaProgramaCP = ConsultarPreguntas(New PreguntaCP)

            If lstPreguntasIngresoaProgramaCP.Count > 0 Then
                Dim aPreUltRespuesta(lstPreguntasIngresoaProgramaCP.Count) As Long
                Dim aUltimaRespuesta(lstPreguntasIngresoaProgramaCP.Count) As PreguntaType
                Dim DAOCP As New DAOCuidadosPaliativos()
                Dim Resultado As String
                Dim appOrigen As String = objPaciente.AppOrigenCP.ToUpper()

                srvIngresoaPrograma.Url = DAOCP.ConsultarUrlServicioUT(objGeneral.Prestador, objGeneral.Sucursal, DAOCP.TipoServicio, DAOCP.MetodoServicio)

                If srvIngresoaPrograma.Url = "" Then
                    Throw New Exception("No fue posible consultar el servicio de últimas respuestas (URL).")
                End If

                For i As Integer = 0 To lstPreguntasIngresoaProgramaCP.Count - 1
                    aPreUltRespuesta(i) = lstPreguntasIngresoaProgramaCP.Item(i).id
                Next

                'srvAspectosSociales.Url = "http://BOAD100DESAR026:8880/CuidadosPaleativosWS/CuidadosPaleativosService"

                'Resultado = srvAspectosSociales.ultimasRespuestas(objPaciente.TipoDocumento, "17021266", aPreUltRespuesta, "SOPHIA", "BOGOTA", aUltimaRespuesta)
                ''WACHV, 22Dic2017, Se agrega Obtener la ref regional en cada Bd
                '',se cambia parametro de regional objPaciente.Ciudad.ToUpper() por lo retornado en strRegionalRefBD
                Dim strRegionalRefBD As String = DAOCP.ConsultarRegional()
                Resultado = srvIngresoaPrograma.ultimasRespuestas(objPaciente.TipoDocumento, objPaciente.NumeroDocumento,
                aPreUltRespuesta, appOrigen, strRegionalRefBD.ToUpper(), aUltimaRespuesta)

                For Each pr As PreguntaType In aUltimaRespuesta
                    If pr.respuestas.textoRespuesta <> Nothing Then
                        oIngresoaPrograma = ObtenerUltimaRespuesta(pr.idPregunta, pr.respuestas.textoRespuesta)
                        CargarUltimaRespuesta(oIngresoaPrograma, oURIngresoaPrograma)
                    End If
                    If Not pr.respuestas.listadoIdRespuesta Is Nothing Then
                        If pr.respuestas.listadoIdRespuesta.Length > 0 Then
                            For i As Integer = 0 To pr.respuestas.listadoIdRespuesta.Length - 1
                                oIngresoaPrograma = ObtenerUltimaRespuesta(pr.idPregunta, pr.respuestas.listadoIdRespuesta(i).ToString())
                                CargarUltimaRespuesta(oIngresoaPrograma, oURIngresoaPrograma)
                            Next
                        End If
                    End If
                Next
            End If
            Return oURIngresoaPrograma
        Catch ex As Exception
            ''WACHV,27SEPT2017, SE REALIZA VALIDACDION PARA ESTE CASO
            If (ex.Message.ToString() <> "ERROR") Then
                Throw ex
            End If
        End Try
    End Function

    ''' <summary>
    ''' Carga el objeto de ultima respuesta que se devuelve al control
    ''' </summary>
    ''' <param name="oAspectosSociales">Ingreso  Programa</param>
    ''' <param name="oURAspectosSociales">Última Respuesta Ingreso  Programa</param>
    ''' <remarks></remarks>
    Private Sub CargarUltimaRespuesta(ByVal oIngresoaPrograma As IngresoaPrograma, ByRef oURIngresoaPrograma As IngresoaPrograma)
        Try
            If oIngresoaPrograma.FechaIngreso <> "0" Then
                oURIngresoaPrograma.FechaIngreso = oIngresoaPrograma.FechaIngreso
            End If

            If oIngresoaPrograma.Harecibidoatencionpreviaporcuidadospaliativos <> "0" Then
                oURIngresoaPrograma.Harecibidoatencionpreviaporcuidadospaliativos = oIngresoaPrograma.Harecibidoatencionpreviaporcuidadospaliativos
            End If

            If oIngresoaPrograma.Donderecibioatencionporcuidadospaliativos <> "0" Then
                oURIngresoaPrograma.Donderecibioatencionporcuidadospaliativos = oIngresoaPrograma.Donderecibioatencionporcuidadospaliativos
            End If

            If oIngresoaPrograma.FechaDiagnostico <> "0" Then
                oURIngresoaPrograma.FechaDiagnostico = oIngresoaPrograma.FechaDiagnostico
            End If

            If oIngresoaPrograma._Harequeridoatencionporurgenciasuhospitalizacionenelultimomes <> "" Then
                oURIngresoaPrograma.Harequeridoatencionporurgenciasuhospitalizacionenelultimomes = oIngresoaPrograma.Harequeridoatencionporurgenciasuhospitalizacionenelultimomes
            End If

            If oIngresoaPrograma.Harequeridoatencionporcirugiaambulatoriaenelultimomes <> "0" Then
                oURIngresoaPrograma.Harequeridoatencionporcirugiaambulatoriaenelultimomes = oIngresoaPrograma.Harequeridoatencionporcirugiaambulatoriaenelultimomes
            End If

            If oIngresoaPrograma.Fechadelaatencionporurgencias_Hospitalizacion_UltimoMes <> "" Then
                oURIngresoaPrograma.Fechadelaatencionporurgencias_Hospitalizacion_UltimoMes = oIngresoaPrograma.Fechadelaatencionporurgencias_Hospitalizacion_UltimoMes
            End If

            If oIngresoaPrograma.Laatencionporurgencias_hospitalizacionestaasociadacoeldiagnosticodebase <> "0" Then
                oURIngresoaPrograma.Laatencionporurgencias_hospitalizacionestaasociadacoeldiagnosticodebase = oIngresoaPrograma.Laatencionporurgencias_hospitalizacionestaasociadacoeldiagnosticodebase
            End If

            If oIngresoaPrograma.Observacionesdelaatencion_Urgencias_Hospitalizacion <> "0" Then
                oURIngresoaPrograma.Observacionesdelaatencion_Urgencias_Hospitalizacion = oIngresoaPrograma.Observacionesdelaatencion_Urgencias_Hospitalizacion
            End If

            If oIngresoaPrograma.Harequeridoatencionporcirugiaambulatoriaenelultimomes <> "0" Then
                oURIngresoaPrograma.Harequeridoatencionporcirugiaambulatoriaenelultimomes = oIngresoaPrograma.Harequeridoatencionporcirugiaambulatoriaenelultimomes
            End If

            If oIngresoaPrograma.Fechadelaatencionporurgencias_Hospitalizacion <> "" Then
                oURIngresoaPrograma.Fechadelaatencionporurgencias_Hospitalizacion = oIngresoaPrograma.Fechadelaatencionporurgencias_Hospitalizacion
            End If

            If oIngresoaPrograma.Elpacienteestarecibiendoalgunadelassiguientesintervenciones <> "0" Then
                If oURIngresoaPrograma.Elpacienteestarecibiendoalgunadelassiguientesintervenciones = "" Then
                    oURIngresoaPrograma.Elpacienteestarecibiendoalgunadelassiguientesintervenciones = oIngresoaPrograma.Elpacienteestarecibiendoalgunadelassiguientesintervenciones
                Else
                    oURIngresoaPrograma.Elpacienteestarecibiendoalgunadelassiguientesintervenciones = oURIngresoaPrograma.Elpacienteestarecibiendoalgunadelassiguientesintervenciones & "," & oIngresoaPrograma.Elpacienteestarecibiendoalgunadelassiguientesintervenciones
                End If

            End If

            If oIngresoaPrograma.Observacionesintervencionespaliativos <> "0" Then
                oURIngresoaPrograma.Observacionesintervencionespaliativos = oIngresoaPrograma.Observacionesintervencionespaliativos
            End If

            If oIngresoaPrograma.Conoceeldiagnostico_Paciente <> "0" Then
                oURIngresoaPrograma.Conoceeldiagnostico_Paciente = oIngresoaPrograma.Conoceeldiagnostico_Paciente
            End If

            If oIngresoaPrograma.Conoceelpronostico_Paciente <> "0" Then
                oURIngresoaPrograma.Conoceelpronostico_Paciente = oIngresoaPrograma.Conoceelpronostico_Paciente
            End If

            If oIngresoaPrograma.Pideinformacion_Paciente <> "0" Then
                oURIngresoaPrograma.Pideinformacion_Paciente = oIngresoaPrograma.Pideinformacion_Paciente
            End If

            If oIngresoaPrograma.Pidequenoseleinforme_Paciente <> "0" Then
                oURIngresoaPrograma.Pidequenoseleinforme_Paciente = oIngresoaPrograma.Pidequenoseleinforme_Paciente
            End If


            If oIngresoaPrograma.Conoceeldiagnostico_Familia <> "0" Then
                oURIngresoaPrograma.Conoceeldiagnostico_Familia = oIngresoaPrograma.Conoceeldiagnostico_Familia
            End If

            If oIngresoaPrograma.Conoceelpronostico_Familia <> "0" Then
                oURIngresoaPrograma.Conoceelpronostico_Familia = oIngresoaPrograma.Conoceelpronostico_Familia
            End If

            If oIngresoaPrograma.Pideinformacion_Familia <> "0" Then
                oURIngresoaPrograma.Pideinformacion_Familia = oIngresoaPrograma.Pideinformacion_Familia
            End If

            If oIngresoaPrograma.Pidequenoseleinforme_Familia <> "0" Then
                oURIngresoaPrograma.Pidequenoseleinforme_Familia = oIngresoaPrograma.Pidequenoseleinforme_Familia
            End If

            If oIngresoaPrograma.CercodeSilencio <> "0" Then
                oURIngresoaPrograma.CercodeSilencio = oIngresoaPrograma.CercodeSilencio
            End If

            If oIngresoaPrograma.Informacioninsuficiente <> "0" Then
                oURIngresoaPrograma.Informacioninsuficiente = oIngresoaPrograma.Informacioninsuficiente
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region


End Class