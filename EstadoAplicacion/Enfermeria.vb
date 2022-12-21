Imports System.Collections.Generic
Imports HistoriaClinica.wsCuidadoPaliativo
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Public Class Enfermeria
#Region "Properties"

    Private Shared _Instancia As Enfermeria
    Private _cod_pre_sgs As String
    Private _cod_sucur As String
    Private _tip_admision As String
    Private _ano_adm As Integer
    Private _num_adm As Decimal
    Private _tip_doc As String
    Private _Num_doc As String
    Private _Nom_profesional As String
    Private _Nom_medicamento As String
    Private _Dosis As String
    Private _Via_Administracion As Integer
    Private _EsAdministrado As String
    Private _Fec_Hora_Administracion As String
    Private _Obs_Administracion As String
    Private _Cuidados_Enfermeria As String
    Private _Evolucion_Enfermeria As String
    Private _ControlCateter As String
    Private _PresentaHeridas As String
    Private _fec_con As DateTime
    Private _obs As String
    Private _login As String

    Public ReadOnly SeccionEnfermeriaCP As Long = 9

    Public lstPreguntasEnfermeriaCP As List(Of PreguntaCP)

    Public Shared ReadOnly Property Instancia() As Enfermeria
        Get
            If _Instancia Is Nothing Then
                _Instancia = New Enfermeria
            End If
            Return _Instancia
        End Get
    End Property

    Public Property Cod_pre_sgs() As String
        Get
            Return _cod_pre_sgs
        End Get
        Set(ByVal Value As String)
            _cod_pre_sgs = Value
        End Set
    End Property

    Public Property Cod_sucur() As String
        Get
            Return _cod_sucur
        End Get
        Set(ByVal Value As String)
            _cod_sucur = Value
        End Set
    End Property

    Public Property Tip_admision() As String
        Get
            Return _tip_admision
        End Get
        Set(ByVal Value As String)
            _tip_admision = Value
        End Set
    End Property

    Public Property Ano_adm() As Integer
        Get
            Return _ano_adm
        End Get
        Set(ByVal Value As Integer)
            _ano_adm = Value
        End Set
    End Property

    Public Property Num_adm() As Decimal
        Get
            Return _num_adm
        End Get
        Set(ByVal Value As Decimal)
            _num_adm = Value
        End Set
    End Property

    Public Property Tip_doc() As String
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

    Public Property Nom_profesional() As String
        Get
            Return _Nom_profesional
        End Get
        Set(ByVal Value As String)
            _Nom_profesional = Value
        End Set
    End Property

    Public Property Nom_medicamento() As String
        Get
            Return _Nom_medicamento
        End Get
        Set(ByVal Value As String)
            _Nom_medicamento = Value
        End Set
    End Property

    Public Property Dosis() As String
        Get
            Return _Dosis
        End Get
        Set(ByVal Value As String)
            _Dosis = Value
        End Set
    End Property

    Public Property Via_Administracion() As Integer
        Get
            Return _Via_Administracion
        End Get
        Set(ByVal Value As Integer)
            _Via_Administracion = Value
        End Set
    End Property

    Public Property EsAdministrado() As String
        Get
            Return _EsAdministrado
        End Get
        Set(ByVal Value As String)
            _EsAdministrado = Value
        End Set
    End Property

    Public Property Fec_Hora_Administracion() As String
        Get
            Return _Fec_Hora_Administracion
        End Get
        Set(ByVal Value As String)
            _Fec_Hora_Administracion = Value
        End Set
    End Property

    Public Property ControlCateter() As String
        Get
            Return _ControlCateter
        End Get
        Set(ByVal Value As String)
            _ControlCateter = Value
        End Set
    End Property

    Public Property Obs_Administracion() As String
        Get
            Return _Obs_Administracion
        End Get
        Set(ByVal Value As String)
            _Obs_Administracion = Value
        End Set
    End Property

    Public Property Evolucion_Enfermeria() As String
        Get
            Return _Evolucion_Enfermeria
        End Get
        Set(ByVal Value As String)
            _Evolucion_Enfermeria = Value
        End Set
    End Property

    Public Property PresentaHeridas() As String
        Get
            Return _PresentaHeridas
        End Get
        Set(ByVal Value As String)
            _PresentaHeridas = Value
        End Set
    End Property

    Public Property Cuidados_Enfermeria() As String
        Get
            Return _Cuidados_Enfermeria
        End Get
        Set(ByVal Value As String)
            _Cuidados_Enfermeria = Value
        End Set
    End Property




    Public Property Fec_con() As DateTime
        Get
            Return _fec_con
        End Get
        Set(ByVal Value As DateTime)
            _fec_con = Value
        End Set
    End Property

    Public Property Obs() As String
        Get
            Return _obs
        End Get
        Set(ByVal Value As String)
            _obs = Value
        End Set
    End Property

    Public Property Login() As String
        Get
            Return _login
        End Get
        Set(ByVal Value As String)
            _login = Value
        End Set
    End Property
#End Region

#Region "Functions"

    Public Function GuardarRegistroEnfermeria(ByVal objEnfermeria As Enfermeria) As String
        'Dim objDACPAspectosSociales As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOCuidadosPaliativos
        'Return objDACPAspectosSociales.GuardarAspectoSocial(objEnfermeria)
        Return Nothing
    End Function

    Public Function CargarRegistroEnfermeria(ByVal objGeneral As Generales, ByVal objPaciente As Paciente) As Enfermeria
        Dim srvEnfermeria As New CuidadosPaleativosServiceImpService()
        Dim objEnfermeria As New Enfermeria
        Dim objDAOEnfermeria As New DAOEnfermeriaCP
        Try
            objEnfermeria.lstPreguntasEnfermeriaCP = objDAOEnfermeria.ConsultarPreguntas(New PreguntaCP, objEnfermeria.SeccionEnfermeriaCP)
            Dim aPreUltRespuesta(objEnfermeria.lstPreguntasEnfermeriaCP.Count) As Long
            Dim aUltimaRespuesta(objEnfermeria.lstPreguntasEnfermeriaCP.Count) As PreguntaType
            Dim DAOCP As New DAOCuidadosPaliativos()
            Dim Resultado As String = String.Empty
            Dim appOrigen As String = objPaciente.AppOrigenCP.ToUpper()

            srvEnfermeria.Url = DAOCP.ConsultarUrlServicioUT(objGeneral.Prestador, objGeneral.Sucursal, DAOCP.TipoServicio, DAOCP.MetodoServicio)

            If srvEnfermeria.Url = "" Then
                Throw New Exception("No fue posible consultar el servicio de últimas respuestas (URL).")
            End If

            For i As Integer = 0 To objEnfermeria.lstPreguntasEnfermeriaCP.Count - 1
                aPreUltRespuesta(i) = objEnfermeria.lstPreguntasEnfermeriaCP.Item(i).id
            Next

            ''WACHV, 22Dic2017, Se agrega Obtener la ref regional en cada Bd
            '',se cambia parametro de regional objPaciente.Ciudad.ToUpper() por lo retornado en strRegionalRefBD
            Dim strRegionalRefBD As String = DAOCP.ConsultarRegional()
            Resultado = srvEnfermeria.ultimasRespuestas(objPaciente.TipoDocumento, objPaciente.NumeroDocumento,
            aPreUltRespuesta, appOrigen, strRegionalRefBD.ToUpper(), aUltimaRespuesta)

            ArmarObjetoEnfermeria(aUltimaRespuesta, objDAOEnfermeria, objEnfermeria)

            Return objEnfermeria
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    ''' <summary>
    ''' Obtiene la ultima respuesta en forma del objeto de enfermería.
    ''' </summary>
    ''' <param name="IdPregunta">Id de la pregunta obtenida del servicio de última respuesta</param>
    ''' <param name="Respuesta">Respuesta de la pregunta obtenida del servicio de última respuesta</param>
    ''' <returns>El criterio ingreso con la respuesta obtenida por el servicio de última respuesta</returns>
    ''' <remarks></remarks>
    Private Function ObtenerUltimaRespuesta(ByVal objDAOEnfermeria As DAOEnfermeriaCP, ByVal IdPregunta As Integer, ByVal Respuesta As String) As Enfermeria
        Return objDAOEnfermeria.ConsultarUREnfermeria(IdPregunta, Respuesta)
    End Function

    Private Function ObtenerTextoParametrica(ByVal IdParam As Integer, ByVal objDAOEnfermeria As DAOEnfermeriaCP) As String
        Return objDAOEnfermeria.ConsultaParametrica(IdParam).Rows(0)(1).ToString().ToUpper()
    End Function

    Private Sub ArmarObjetoEnfermeria(ByVal aUltimaRespuesta() As PreguntaType, ByVal objDAOEnfermeria As DAOEnfermeriaCP, ByRef objEnfermeria As Enfermeria)
        For Each pr As PreguntaType In aUltimaRespuesta
            Select Case pr.idPregunta
                Case "901"
                    objEnfermeria.Nom_profesional = pr.respuestas.textoRespuesta
                    'Case "902"
                    '    objEnfermeria.Nom_medicamento = pr.respuestas.textoRespuesta
                    'Case "903"
                    '    objEnfermeria.Dosis = pr.respuestas.textoRespuesta
                    'Case "904"
                    '    objEnfermeria.Via_Administracion = pr.respuestas.listadoIdRespuesta(0)
                    'Case "905"                    
                    '    objEnfermeria.EsAdministrado = ObtenerTextoParametrica(Convert.ToInt32(pr.respuestas.listadoIdRespuesta(0)), objDAOEnfermeria)
                    'Case "906"
                    '    objEnfermeria.Fec_Hora_Administracion = pr.respuestas.textoRespuesta
                    'Case "907"
                    '    objEnfermeria.Obs_Administracion = pr.respuestas.textoRespuesta
                Case "908"
                    objEnfermeria.Cuidados_Enfermeria = pr.respuestas.textoRespuesta
                Case "909"
                    objEnfermeria.Evolucion_Enfermeria = pr.respuestas.textoRespuesta
                Case "929"
                    objEnfermeria._PresentaHeridas = pr.respuestas.listadoIdRespuesta(0)

            End Select
        Next
    End Sub

#End Region


End Class