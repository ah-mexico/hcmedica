Imports System.Collections.Generic
Imports HistoriaClinica.wsCuidadoPaliativo
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO

Public Class ValoraciondeIngreso

    Private Shared _Instancia As ValoraciondeIngreso

    Private _cod_pre_sgs As String
    Private _cod_sucur As String
    Private _tip_admision As String
    Private _ano_adm As Integer
    Private _num_adm As Decimal
    Private _tip_doc As String
    Private _Num_doc As String

    Private _CriteriodeIngreso As String
    Private _Diagnostico_oncologico As String
    Private _Diagnostico_no_oncologico As String
    Private _CumpleCI As String
    Private _Req_JP As String
    Private _ObsJuntaP As String
    Private _IngPrograma As String
    Private _fec_con As DateTime
    Private _obs As String
    Private _login As String
    Private _FecIngProgAV As String

    Public ReadOnly npCriteriodeIngreso As String = "CriteriodeIngreso"
    Public ReadOnly npDiagnostico_oncologico As String = "Diagnostico_oncologico"
    Public ReadOnly npDiagnostico_no_oncologico As String = "Diagnostico_no_oncologico"
    Public ReadOnly npCumpleCI As String = "CumpleCI"
    Public ReadOnly npReq_JP As String = "Req_JP"
    Public ReadOnly npObsJuntaP As String = "ObsJuntaP"
    Public ReadOnly npIngPrograma As String = "IngPrograma"
    Public ReadOnly npFecIngProgAV As String = "FecIngProgAV"

    Public ReadOnly Seccion As Integer = 1

#Region "Propiedades"
    Public Shared ReadOnly Property Instancia() As ValoraciondeIngreso
        Get
            If _Instancia Is Nothing Then
                _Instancia = New ValoraciondeIngreso
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

    Public Property CriteriodeIngreso() As String
        Get
            Return _CriteriodeIngreso
        End Get
        Set(ByVal value As String)
            _CriteriodeIngreso = value
        End Set
    End Property

    Public Property Diagnostico_oncologico() As String
        Get
            Return _Diagnostico_oncologico
        End Get
        Set(ByVal value As String)
            _Diagnostico_oncologico = value
        End Set
    End Property

    Public Property Diagnostico_no_oncologico() As String
        Get
            Return _Diagnostico_no_oncologico
        End Get
        Set(ByVal value As String)
            _Diagnostico_no_oncologico = value
        End Set
    End Property

    Public Property CumpleCI() As String
        Get
            Return _CumpleCI
        End Get
        Set(ByVal value As String)
            _CumpleCI = value
        End Set

    End Property

    Public Property Req_JP() As String
        Get
            Return _Req_JP
        End Get
        Set(ByVal value As String)
            _Req_JP = value
        End Set

    End Property

    Public Property ObsJuntaP() As String
        Get
            Return _ObsJuntaP
        End Get
        Set(ByVal value As String)
            _ObsJuntaP = value
        End Set

    End Property

    Public Property IngPrograma() As String
        Get
            Return _IngPrograma
        End Get
        Set(ByVal value As String)
            _IngPrograma = value
        End Set

    End Property

    Public Property FecIngProgAV() As String
        Get
            Return _FecIngProgAV
        End Get
        Set(ByVal value As String)
            _FecIngProgAV = value
        End Set
    End Property

#End Region

    Public Sub New()
        MyBase.New()
    End Sub

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

    Public Sub Limpiar()
        _CriteriodeIngreso = ""
        _Diagnostico_oncologico = ""
        _Diagnostico_no_oncologico = ""
        _CumpleCI = ""
        _Req_JP = ""
        _ObsJuntaP = ""
        _IngPrograma = ""
        _FecIngProgAV = ""
    End Sub

    Private lstPreguntasValoradiondeIngresoCP As List(Of PreguntaCP)

#Region "Funtions"

    Public Function GuardarValoraciondeIngreso(ByVal oValoraciondeIngreso As ValoraciondeIngreso, ByVal strAVC As String) As String
        Dim objDACPValoraciondeIngreso As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOCuidadosPaliativos
        Return objDACPValoraciondeIngreso.GuardarValoraciondeIngreso(oValoraciondeIngreso, strAVC)
    End Function

    Public Function ObtenerUltimaRespuesta(ByVal IdPregunta As Integer, ByVal Respuesta As String) As ValoraciondeIngreso

        Dim objDAOvaloraciondeIngreso As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOCuidadosPaliativos

        Return objDAOvaloraciondeIngreso.ConsultarURValoraciondeIngreso(IdPregunta, Respuesta)

    End Function

    Public Function ConsultarPreguntas(ByVal oPreguntaCP As PreguntaCP) As List(Of PreguntaCP)
        Dim objDAPreguntaCP As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOIngresoaPrograma
        oPreguntaCP.seccion = Me.Seccion
        Return objDAPreguntaCP.ConsultarPreguntas(oPreguntaCP)
    End Function

    Public Function SugerirRespuesta(ByVal objGeneral As Generales, ByVal objPaciente As Paciente) As ValoraciondeIngreso

        Dim srvIngresoaPrograma As New CuidadosPaleativosServiceImpService()
        Dim oValoraciondeIngreso As New ValoraciondeIngreso()
        Dim oURValoraciondeIngreso As New ValoraciondeIngreso()

        Try

            lstPreguntasValoradiondeIngresoCP = ConsultarPreguntas(New PreguntaCP)

            If lstPreguntasValoradiondeIngresoCP.Count > 0 Then

                Dim aPreUltRespuesta(lstPreguntasValoradiondeIngresoCP.Count) As Long
                Dim aUltimaRespuesta(lstPreguntasValoradiondeIngresoCP.Count) As PreguntaType
                Dim DAOCP As New DAOCuidadosPaliativos()
                Dim Resultado As String
                Dim appOrigen As String = objPaciente.AppOrigenCP.ToUpper()

                srvIngresoaPrograma.Url = DAOCP.ConsultarUrlServicioUT(objGeneral.Prestador, objGeneral.Sucursal, DAOCP.TipoServicio, DAOCP.MetodoServicio)

                If srvIngresoaPrograma.Url = "" Then
                    Throw New Exception("No fue posible consultar el servicio de últimas respuestas (URL).")
                End If

                For i As Integer = 0 To lstPreguntasValoradiondeIngresoCP.Count - 1
                    aPreUltRespuesta(i) = lstPreguntasValoradiondeIngresoCP.Item(i).id
                Next

                'srvAspectosSociales.Url = "http://BOAD100DESAR026:8880/CuidadosPaleativosWS/CuidadosPaleativosService"
                'Resultado = srvAspectosSociales.ultimasRespuestas(objPaciente.TipoDocumento, "17021266", aPreUltRespuesta, "SOPHIA", "BOGOTA", aUltimaRespuesta)

                ''WACHV, 22Dic2017, Se agrega Obtener la ref regional en cada Bd
                ''se cambia parametro de regional objPaciente.Ciudad.ToUpper() por lo retornado en strRegionalRefBD
                Dim strRegionalRefBD As String = DAOCP.ConsultarRegional()

                Resultado = srvIngresoaPrograma.ultimasRespuestas(objPaciente.TipoDocumento, objPaciente.NumeroDocumento,
                aPreUltRespuesta, appOrigen, strRegionalRefBD.ToUpper(), aUltimaRespuesta)

                For Each pr As PreguntaType In aUltimaRespuesta
                    If pr.respuestas.textoRespuesta <> Nothing Then
                        oValoraciondeIngreso = ObtenerUltimaRespuesta(pr.idPregunta, pr.respuestas.textoRespuesta)
                        CargarUltimaRespuesta(oValoraciondeIngreso, oURValoraciondeIngreso)
                    End If

                    If Not pr.respuestas.listadoIdRespuesta Is Nothing Then

                        If pr.respuestas.listadoIdRespuesta.Length > 0 Then
                            For i As Integer = 0 To pr.respuestas.listadoIdRespuesta.Length - 1
                                oValoraciondeIngreso = ObtenerUltimaRespuesta(pr.idPregunta, pr.respuestas.listadoIdRespuesta(i).ToString())
                                CargarUltimaRespuesta(oValoraciondeIngreso, oURValoraciondeIngreso)
                            Next

                        End If

                    End If

                Next

            End If

            Return oURValoraciondeIngreso

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' Carga el objeto de ultima respuesta que se devuelve al control
    ''' </summary>
    ''' <param name="oValoraciondeIngreso">valoracion de Igreso</param>
    ''' <param name="oURValoraciondeIngreso">Última Respuesta valoracion de Igreso</param>
    ''' <remarks></remarks>
    Private Sub CargarUltimaRespuesta(ByVal oValoraciondeIngreso As ValoraciondeIngreso, ByRef oURValoraciondeIngreso As ValoraciondeIngreso)
        Try
            If oValoraciondeIngreso.Diagnostico_oncologico <> "0" Then
                oURValoraciondeIngreso.Diagnostico_oncologico = oValoraciondeIngreso.Diagnostico_oncologico
            End If

            If oValoraciondeIngreso.Diagnostico_no_oncologico <> "0" Then
                oURValoraciondeIngreso.Diagnostico_no_oncologico = oValoraciondeIngreso.Diagnostico_no_oncologico
            End If

            If oValoraciondeIngreso.CumpleCI <> "0" Then
                oURValoraciondeIngreso.CumpleCI = oValoraciondeIngreso.CumpleCI
            End If

            If oValoraciondeIngreso.IngPrograma <> "0" Then
                oURValoraciondeIngreso.IngPrograma = oValoraciondeIngreso.IngPrograma
            End If

            If oValoraciondeIngreso.ObsJuntaP <> "" Then
                oURValoraciondeIngreso.ObsJuntaP = oValoraciondeIngreso.ObsJuntaP
            End If

            If oValoraciondeIngreso.Req_JP <> "" Then
                oURValoraciondeIngreso.Req_JP = oValoraciondeIngreso.Req_JP
            End If

            If oValoraciondeIngreso.CriteriodeIngreso <> "0" Then
                oURValoraciondeIngreso.CriteriodeIngreso = oValoraciondeIngreso.CriteriodeIngreso
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


#End Region




End Class
