Imports System.Collections.Generic
Imports HistoriaClinica.wsCuidadoPaliativo
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO

Public Class EgresoCP

#Region "Properties"

    Private Shared _Instancia As EgresoCP
    Private _cod_pre_sgs As String
    Private _cod_sucur As String
    Private _tip_admision As String
    Private _ano_adm As Integer
    Private _num_adm As Decimal
    Private _tip_doc As String
    Private _Num_doc As String
    Private _Fecha_de_egreso As String
    Private _EstanciadePrograma As String
    Private _MotivoEgreso As String
    Private _LugarFallece As String
    Private _HospitalfueradeRed As String
    Private _IntervencionSicologicapostFallecimiento As String
    Private _ExpliqueRazon As String
    Private _fec_con As DateTime
    Private _obs As String
    Private _login As String

    Public ReadOnly npFecha_de_egreso As String = "FechaEgreso"
    Public ReadOnly npEstanciadePrograma As String = "EstanciaPrograma"
    Public ReadOnly npMotivoEgreso As String = "MotivoEgreso"
    Public ReadOnly npLugarFallece As String = "LugarFallece"
    Public ReadOnly npHospitalfueradeRed As String = "HospitalfueradeRed"
    Public ReadOnly npIntervencionSicologicapostFallecimiento As String = "IntervencionSicologicapostFallecimiento"
    Public ReadOnly npExpliqueRazon As String = "ExpliqueRazon"
    
    Public ReadOnly SeccionEgresoCp As Integer = 7

    Public Shared ReadOnly Property Instancia() As EgresoCP
        Get
            If _Instancia Is Nothing Then
                _Instancia = New EgresoCP
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

    Public Property Fecha_de_egreso() As String
        Get
            Return _Fecha_de_egreso
        End Get
        Set(ByVal Value As String)
            _Fecha_de_egreso = Value
        End Set
    End Property

    Public Property EstanciadePrograma() As String
        Get
            Return _EstanciadePrograma
        End Get
        Set(ByVal Value As String)
            _EstanciadePrograma = Value
        End Set
    End Property

    Public Property MotivoEgreso() As String
        Get
            Return _MotivoEgreso
        End Get
        Set(ByVal Value As String)
            _MotivoEgreso = Value
        End Set
    End Property

    Public Property LugarFallece() As String
        Get
            Return _LugarFallece
        End Get
        Set(ByVal Value As String)
            _LugarFallece = Value
        End Set
    End Property

    Public Property HospitalfueradeRed() As String
        Get
            Return _HospitalfueradeRed
        End Get
        Set(ByVal Value As String)
            _HospitalfueradeRed = Value
        End Set
    End Property

    Public Property IntervencionSicologicapostFallecimiento() As String
        Get
            Return _IntervencionSicologicapostFallecimiento
        End Get
        Set(ByVal Value As String)
            _IntervencionSicologicapostFallecimiento = Value
        End Set
    End Property

    Public Property ExpliqueRazon() As String
        Get
            Return _ExpliqueRazon
        End Get
        Set(ByVal Value As String)
            _ExpliqueRazon = Value
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


    Private lstPreguntasEgresoCP As List(Of PreguntaCP)

#End Region

#Region "Funtions"

    Public Function ObtenerUltimaRespuesta(ByVal IdPregunta As Integer, ByVal Respuesta As String) As EgresoCP
        Dim objDACPEgresoCP As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOCuidadosPaliativos
        Return objDACPEgresoCP.ConsultarUREgresoPrograma(IdPregunta, Respuesta)
    End Function

    Public Function ConsultarPreguntas(ByVal oPreguntaCP As PreguntaCP) As List(Of PreguntaCP)
        Dim objDAPreguntaCP As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOCuidadosPaliativos
        oPreguntaCP.seccion = Me.SeccionEgresoCp
        Return objDAPreguntaCP.ConsultarPreguntas(oPreguntaCP)
    End Function

    Public Function SugerirRespuesta(ByVal objGeneral As Generales, ByVal objPaciente As Paciente) As EgresoCP
        Dim srvEgresoCp As New CuidadosPaleativosServiceImpService()

        Dim oEgresoCP As New EgresoCP()
        Dim oUREgresoCP As New EgresoCP()
        Try

            lstPreguntasEgresoCP = ConsultarPreguntas(New PreguntaCP)

            If lstPreguntasEgresoCP.Count > 0 Then
                Dim aPreUltRespuesta(lstPreguntasEgresoCP.Count) As Long
                Dim aUltimaRespuesta(lstPreguntasEgresoCP.Count) As PreguntaType
                Dim DAOCP As New DAOCuidadosPaliativos()
                Dim Resultado As String
                Dim appOrigen As String = objPaciente.AppOrigenCP.ToUpper()

                srvEgresoCp.Url = DAOCP.ConsultarUrlServicioUT(objGeneral.Prestador, objGeneral.Sucursal, DAOCP.TipoServicio, DAOCP.MetodoServicio)

                If srvEgresoCp.Url = "" Then
                    Throw New Exception("No fue posible consultar el servicio de últimas respuestas (URL).")
                End If

                For i As Integer = 0 To lstPreguntasEgresoCP.Count - 1
                    aPreUltRespuesta(i) = lstPreguntasEgresoCP.Item(i).id
                Next

                'srvAspectosSociales.Url = "http://BOAD100DESAR026:8880/CuidadosPaleativosWS/CuidadosPaleativosService"

                'Resultado = srvAspectosSociales.ultimasRespuestas(objPaciente.TipoDocumento, "17021266", aPreUltRespuesta, "SOPHIA", "BOGOTA", aUltimaRespuesta)
                ''WACHV, 22Dic2017, Se agrega Obtener la ref regional en cada Bd
                '',se cambia parametro de regional objPaciente.Ciudad.ToUpper() por lo retornado en strRegionalRefBD
                Dim strRegionalRefBD As String = DAOCP.ConsultarRegional()
                Resultado = srvEgresoCp.ultimasRespuestas(objPaciente.TipoDocumento, objPaciente.NumeroDocumento,
                aPreUltRespuesta, appOrigen, strRegionalRefBD.ToUpper(), aUltimaRespuesta)

                For Each pr As PreguntaType In aUltimaRespuesta
                    If pr.respuestas.textoRespuesta <> Nothing Then
                        oEgresoCP = ObtenerUltimaRespuesta(pr.idPregunta, pr.respuestas.textoRespuesta)
                        CargarUltimaRespuesta(oEgresoCP, oUREgresoCP)
                    End If
                    If Not pr.respuestas.listadoIdRespuesta Is Nothing Then
                        If pr.respuestas.listadoIdRespuesta.Length > 0 Then
                            For i As Integer = 0 To pr.respuestas.listadoIdRespuesta.Length - 1
                                oEgresoCP = ObtenerUltimaRespuesta(pr.idPregunta, pr.respuestas.listadoIdRespuesta(i).ToString())
                                CargarUltimaRespuesta(oEgresoCP, oUREgresoCP)
                            Next
                        End If
                    End If
                Next
            End If
            Return oUREgresoCP
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Carga el objeto de ultima respuesta que se devuelve al control
    ''' </summary>
    ''' <param name="oUREgresoCP">Egreso</param>
    ''' <param name="oURoUREgresoCP">Última Respuesta Egreso</param>
    ''' <remarks></remarks>
    Private Sub CargarUltimaRespuesta(ByVal oEgresoCP As EgresoCP, ByRef oUREgresoCP As EgresoCP)
        Try
            If oEgresoCP.EstanciadePrograma <> "0" Then
                oUREgresoCP.EstanciadePrograma = oEgresoCP.EstanciadePrograma
            End If

            If oEgresoCP.ExpliqueRazon <> "0" Then
                oUREgresoCP.ExpliqueRazon = oEgresoCP.ExpliqueRazon
            End If

            If oEgresoCP.Fecha_de_egreso <> "0" Then
                oUREgresoCP.Fecha_de_egreso = oEgresoCP.Fecha_de_egreso
            End If

            If oEgresoCP.HospitalfueradeRed <> "" Then
                oUREgresoCP.HospitalfueradeRed = oEgresoCP.HospitalfueradeRed
            End If

            If oEgresoCP.IntervencionSicologicapostFallecimiento <> "" Then
                oUREgresoCP.IntervencionSicologicapostFallecimiento = oEgresoCP.IntervencionSicologicapostFallecimiento
            End If

            If oEgresoCP.LugarFallece <> "0" Then
                oUREgresoCP.LugarFallece = oEgresoCP.LugarFallece
            End If

            If oEgresoCP.MotivoEgreso <> "0" Then
                oUREgresoCP.MotivoEgreso = oEgresoCP.MotivoEgreso
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub


#End Region


End Class