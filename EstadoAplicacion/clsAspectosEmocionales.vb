Imports System.Collections.Generic
Imports HistoriaClinica.wsCuidadoPaliativo
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO

Public Class AspectosEmocionales

#Region "Properties"

    Private Shared _Instancia As AspectosEmocionales
    Private _cod_pre_sgs As String
    Private _cod_sucur As String
    Private _tip_admision As String
    Private _ano_adm As Integer
    Private _num_adm As Decimal
    Private _tip_doc As String
    Private _Num_doc As String
    Private _ExamenMental As String
    Private _Expectativasycreencias As String
    Private _Afrontamientodelaenfermedad As String
    Private _Afrontamientodelafamiliaalasituacion As String
    Private _Problemasidentificados As String
    Private _Plandeintervencion As String
    Private _Niveldesufrimientoexistencial As String
    Private _Evaluaciondenecesidadesespirituales As String
    Private _Plandeintervencion_E_E As String
    Private _Intervenciondeduelo As String
    Private _DiagnosticoZ63_4 As String
    Private _Otrodiagnosticopsicologico As String

    Private _fec_con As DateTime
    Private _obs As String
    Private _login As String

    Public ReadOnly npExamenMental As String = "ExamenMental"
    Public ReadOnly npExpectativasycreencias As String = "Expectativasycreencias"
    Public ReadOnly npAfrontamientodelaenfermedad As String = "Afrontamientodelaenfermedad"
    Public ReadOnly np_Afrontamientodelafamiliaalasituacion As String = "_Afrontamientodelafamiliaalasituacion"
    Public ReadOnly npProblemasidentificados As String = "Problemasidentificados"
    Public ReadOnly npPlandeintervencion As String = "Plandeintervencion"
    Public ReadOnly npNiveldesufrimientoexistencial As String = "Niveldesufrimientoexistencial"
    Public ReadOnly npEvaluaciondenecesidadesespirituales As String = "Evaluaciondenecesidadesespirituales"
    Public ReadOnly npPlandeintervencion_E_E As String = "Plandeintervención_E_E"
    Public ReadOnly npIntervenciondeduelo As String = "Intervenciondeduelo"
    Public ReadOnly npDiagnosticoZ63_4 As String = "DiagnosticoZ63_4"
    Public ReadOnly npOtrodiagnosticopsicologico As String = "Otrodiagnosticopsicologico"

    Public ReadOnly SeccionAE As Integer = 3

    Public Shared ReadOnly Property Instancia() As AspectosEmocionales
        Get
            If _Instancia Is Nothing Then
                _Instancia = New AspectosEmocionales
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

    Public Property ExamenMental() As String
        Get
            Return _ExamenMental
        End Get
        Set(ByVal Value As String)
            _ExamenMental = Value
        End Set
    End Property

    Public Property Expectativasycreencias() As String
        Get
            Return _Expectativasycreencias
        End Get
        Set(ByVal Value As String)
            _Expectativasycreencias = Value
        End Set
    End Property

    Public Property Afrontamientodelaenfermedad() As String
        Get
            Return _Afrontamientodelaenfermedad
        End Get
        Set(ByVal Value As String)
            _Afrontamientodelaenfermedad = Value
        End Set
    End Property

    Public Property Afrontamientodelafamiliaalasituacion() As String
        Get
            Return _Afrontamientodelafamiliaalasituacion
        End Get
        Set(ByVal Value As String)
            _Afrontamientodelafamiliaalasituacion = Value
        End Set
    End Property

    Public Property Problemasidentificados() As String
        Get
            Return _Plandeintervencion
        End Get
        Set(ByVal Value As String)
            _Plandeintervencion = Value
        End Set
    End Property

    Public Property Plandeintervencion() As String
        Get
            Return _Problemasidentificados
        End Get
        Set(ByVal Value As String)
            _Problemasidentificados = Value
        End Set
    End Property

    Public Property Niveldesufrimientoexistencial() As String
        Get
            Return _Niveldesufrimientoexistencial
        End Get
        Set(ByVal Value As String)
            _Niveldesufrimientoexistencial = Value
        End Set
    End Property

    Public Property Evaluaciondenecesidadesespirituales() As String
        Get
            Return _Evaluaciondenecesidadesespirituales
        End Get
        Set(ByVal Value As String)
            _Evaluaciondenecesidadesespirituales = Value
        End Set
    End Property

    Public Property Plandeintervencion_E_E() As String
        Get
            Return _Plandeintervencion_E_E
        End Get
        Set(ByVal Value As String)
            _Plandeintervencion_E_E = Value
        End Set
    End Property

    Public Property Intervenciondeduelo() As String
        Get
            Return _Intervenciondeduelo
        End Get
        Set(ByVal Value As String)
            _Intervenciondeduelo = Value
        End Set
    End Property

    Public Property DiagnosticoZ63_4() As String
        Get
            Return _DiagnosticoZ63_4
        End Get
        Set(ByVal Value As String)
            _DiagnosticoZ63_4 = Value
        End Set
    End Property

    Public Property Otrodiagnosticopsicologico() As String
        Get
            Return _Otrodiagnosticopsicologico
        End Get
        Set(ByVal Value As String)
            _Otrodiagnosticopsicologico = Value
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


    Private lstPreguntasAspEmocionalesCP As List(Of PreguntaCP)

#End Region

#Region "Funtions"

    Public Function ObtenerUltimaRespuesta(ByVal IdPregunta As Integer, ByVal Respuesta As String) As AspectosEmocionales
        Dim objDAOAspectosEmocionalesCP As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOCuidadosPaliativos
        Return objDAOAspectosEmocionalesCP.ConsultarURAspectosEmocionales(IdPregunta, Respuesta)
    End Function

    Public Function ConsultarPreguntas(ByVal oPreguntaCP As PreguntaCP) As List(Of PreguntaCP)
        Dim objDAPreguntaCP As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOCuidadosPaliativos
        oPreguntaCP.seccion = Me.SeccionAE
        Return objDAPreguntaCP.ConsultarPreguntas(oPreguntaCP)
    End Function


    Public Function SugerirRespuesta(ByVal objGeneral As Generales, ByVal objPaciente As Paciente) As AspectosEmocionales
        Dim srvAspectosEmocionales As New CuidadosPaleativosServiceImpService()

        Dim oAspectosEmocionales As New AspectosEmocionales()
        Dim oURAspectosEmocionales As New AspectosEmocionales()
        Try

            lstPreguntasAspEmocionalesCP = ConsultarPreguntas(New PreguntaCP)

            If lstPreguntasAspEmocionalesCP.Count > 0 Then
                Dim aPreUltRespuesta(lstPreguntasAspEmocionalesCP.Count) As Long
                Dim aUltimaRespuesta(lstPreguntasAspEmocionalesCP.Count) As PreguntaType
                Dim DAOCP As New DAOCuidadosPaliativos()
                Dim Resultado As String
                Dim appOrigen As String = objPaciente.AppOrigenCP.ToUpper()

                srvAspectosEmocionales.Url = DAOCP.ConsultarUrlServicioUT(objGeneral.Prestador, objGeneral.Sucursal, DAOCP.TipoServicio, DAOCP.MetodoServicio)

                If srvAspectosEmocionales.Url = "" Then
                    Throw New Exception("No fue posible consultar el servicio de últimas respuestas (URL).")
                End If

                For i As Integer = 0 To lstPreguntasAspEmocionalesCP.Count - 1
                    aPreUltRespuesta(i) = lstPreguntasAspEmocionalesCP.Item(i).id
                Next

                'srvAspectosSociales.Url = "http://BOAD100DESAR026:8880/CuidadosPaleativosWS/CuidadosPaleativosService"

                'Resultado = srvAspectosSociales.ultimasRespuestas(objPaciente.TipoDocumento, "17021266", aPreUltRespuesta, "SOPHIA", "BOGOTA", aUltimaRespuesta)
                ''WACHV, 22Dic2017, Se agrega Obtener la ref regional en cada Bd
                '',se cambia parametro de regional objPaciente.Ciudad.ToUpper() por lo retornado en strRegionalRefBD
                Dim strRegionalRefBD As String = DAOCP.ConsultarRegional()
                Resultado = srvAspectosEmocionales.ultimasRespuestas(objPaciente.TipoDocumento, objPaciente.NumeroDocumento,
                aPreUltRespuesta, appOrigen, strRegionalRefBD.ToUpper(), aUltimaRespuesta)

                For Each pr As PreguntaType In aUltimaRespuesta
                    If pr.respuestas.textoRespuesta <> Nothing Then
                        oAspectosEmocionales = ObtenerUltimaRespuesta(pr.idPregunta, pr.respuestas.textoRespuesta)
                        CargarUltimaRespuesta(oAspectosEmocionales, oURAspectosEmocionales)
                    End If
                    If Not pr.respuestas.listadoIdRespuesta Is Nothing Then
                        If pr.respuestas.listadoIdRespuesta.Length > 0 Then
                            For i As Integer = 0 To pr.respuestas.listadoIdRespuesta.Length - 1
                                oAspectosEmocionales = ObtenerUltimaRespuesta(pr.idPregunta, pr.respuestas.listadoIdRespuesta(i).ToString())
                                CargarUltimaRespuesta(oAspectosEmocionales, oURAspectosEmocionales)
                            Next
                        End If
                    End If
                Next
            End If
            Return oURAspectosEmocionales
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Carga el objeto de ultima respuesta que se devuelve al control
    ''' </summary>
    ''' <param name="oAspectosEmocionales">Aspectos Emocionales</param>
    ''' <param name="oURAspectosEmocionales">Última Respuesta Aspectos Emocionales</param>
    ''' <remarks></remarks>
    Private Sub CargarUltimaRespuesta(ByVal oAspectosEmocionales As AspectosEmocionales, ByRef oURAspectosEmocionales As AspectosEmocionales)
        Try
            If oAspectosEmocionales.ExamenMental <> "0" Then
                oURAspectosEmocionales.ExamenMental = oAspectosEmocionales.ExamenMental
            End If

            If oAspectosEmocionales.Expectativasycreencias <> "0" Then
                oURAspectosEmocionales.Expectativasycreencias = oAspectosEmocionales.Expectativasycreencias
            End If

            If oAspectosEmocionales.Afrontamientodelaenfermedad <> "0" Then
                oURAspectosEmocionales.Afrontamientodelaenfermedad = oAspectosEmocionales.Afrontamientodelaenfermedad
            End If

            If oAspectosEmocionales.Afrontamientodelafamiliaalasituacion <> "0" Then
                oURAspectosEmocionales.Afrontamientodelafamiliaalasituacion = oAspectosEmocionales.Afrontamientodelafamiliaalasituacion
            End If

            If oAspectosEmocionales.Problemasidentificados <> "" Then
                oURAspectosEmocionales.Problemasidentificados = oAspectosEmocionales.Problemasidentificados
            End If

            If oAspectosEmocionales.Plandeintervencion <> "" Then
                oURAspectosEmocionales.Plandeintervencion = oAspectosEmocionales.Plandeintervencion
            End If

            If oAspectosEmocionales.Niveldesufrimientoexistencial <> "0" Then
                oURAspectosEmocionales.Niveldesufrimientoexistencial = oAspectosEmocionales.Niveldesufrimientoexistencial
            End If

            If oAspectosEmocionales.Evaluaciondenecesidadesespirituales <> "0" Then
                oURAspectosEmocionales.Evaluaciondenecesidadesespirituales = oAspectosEmocionales.Evaluaciondenecesidadesespirituales
            End If

            If oAspectosEmocionales.Plandeintervencion_E_E <> "0" Then
                oURAspectosEmocionales.Plandeintervencion_E_E = oAspectosEmocionales.Plandeintervencion_E_E
            End If

            If oAspectosEmocionales.Intervenciondeduelo <> "0" Then
                oURAspectosEmocionales.Intervenciondeduelo = oAspectosEmocionales.Intervenciondeduelo
            End If

            If oAspectosEmocionales.DiagnosticoZ63_4 <> "0" Then
                oURAspectosEmocionales.DiagnosticoZ63_4 = oAspectosEmocionales.DiagnosticoZ63_4
            End If

            If oAspectosEmocionales.Otrodiagnosticopsicologico <> "0" Then
                oURAspectosEmocionales.Otrodiagnosticopsicologico = oAspectosEmocionales.Otrodiagnosticopsicologico
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub



#End Region


End Class