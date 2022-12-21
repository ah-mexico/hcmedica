Imports System.Collections.Generic
Imports HistoriaClinica.wsCuidadoPaliativo
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO

Public Class AspectosSociales

#Region "Properties"

    Private Shared _Instancia As AspectosSociales
    Private _cod_pre_sgs As String
    Private _cod_sucur As String
    Private _tip_admision As String
    Private _ano_adm As Integer
    Private _num_adm As Decimal
    Private _tip_doc As String
    Private _Num_doc As String
    Private _ConQuienVive As Integer
    Private _TipoDeVivienda As Integer
    Private _TenenciaDeLaVivienda As Integer
    Private _EstratoDeLaVivienda As Integer
    Private _NivelEscolaridad As String
    Private _Ocupacion As String
    Private _CuentaConUnTrabajoEstable As Integer
    Private _Ingresos As Integer
    Private _CondicionDelPadre As Integer
    Private _CondicionDeLaMadre As Integer
    Private _NumeroDeHermanos As Integer
    Private _Lugar As Integer
    Private _TieneHijos As Integer
    Private _TipoDeFamilia As Integer
    Private _NumeroDeIntegrantesDeLaFamilia As Integer
    Private _PersonasACargo As Integer
    Private _NombreDelCuidador As String
    Private _TipoDeDocumentoDelCuidador As String
    Private _NumeroDeDocumentoDelCuidador As String
    Private _ParentescoDelCuidador As String
    Private _DireccionDelCuidador As String
    Private _EscolaridadDelCuidador As String
    Private _OcupacionDelCuidador As String
    Private _EstadoCivilDelCuidador As String
    Private _ProblemasIdentificados As String
    Private _PlanDeIntervencion As String
    Private _fec_con As DateTime
    Private _obs As String
    Private _login As String

    Public ReadOnly SeccionAspSocCP As Integer = 4

    Public Shared ReadOnly Property Instancia() As AspectosSociales
        Get
            If _Instancia Is Nothing Then
                _Instancia = New AspectosSociales
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

    Public Property ConQuienVive() As Integer
        Get
            Return _ConQuienVive
        End Get
        Set(ByVal Value As Integer)
            _ConQuienVive = Value
        End Set
    End Property

    Public Property TipoDeVivienda() As Integer
        Get
            Return _TipoDeVivienda
        End Get
        Set(ByVal Value As Integer)
            _TipoDeVivienda = Value
        End Set
    End Property

    Public Property TenenciaDeLaVivienda() As Integer
        Get
            Return _TenenciaDeLaVivienda
        End Get
        Set(ByVal Value As Integer)
            _TenenciaDeLaVivienda = Value
        End Set
    End Property

    Public Property EstratoDeLaVivienda() As Integer
        Get
            Return _EstratoDeLaVivienda
        End Get
        Set(ByVal Value As Integer)
            _EstratoDeLaVivienda = Value
        End Set
    End Property

    Public Property NivelEscolaridad() As String
        Get
            Return _NivelEscolaridad
        End Get
        Set(ByVal Value As String)
            _NivelEscolaridad = Value
        End Set
    End Property

    Public Property Ocupacion() As String
        Get
            Return _Ocupacion
        End Get
        Set(ByVal Value As String)
            _Ocupacion = Value
        End Set
    End Property

    Public Property CuentaConUnTrabajoEstable() As Integer
        Get
            Return _CuentaConUnTrabajoEstable
        End Get
        Set(ByVal Value As Integer)
            _CuentaConUnTrabajoEstable = Value
        End Set
    End Property

    Public Property Ingresos() As Integer
        Get
            Return _Ingresos
        End Get
        Set(ByVal Value As Integer)
            _Ingresos = Value
        End Set
    End Property

    Public Property CondicionDelPadre() As Integer
        Get
            Return _CondicionDelPadre
        End Get
        Set(ByVal Value As Integer)
            _CondicionDelPadre = Value
        End Set
    End Property

    Public Property CondicionDeLaMadre() As Integer
        Get
            Return _CondicionDeLaMadre
        End Get
        Set(ByVal Value As Integer)
            _CondicionDeLaMadre = Value
        End Set
    End Property

    Public Property NumeroDeHermanos() As Integer
        Get
            Return _NumeroDeHermanos
        End Get
        Set(ByVal Value As Integer)
            _NumeroDeHermanos = Value
        End Set
    End Property

    Public Property Lugar() As Integer
        Get
            Return _Lugar
        End Get
        Set(ByVal Value As Integer)
            _Lugar = Value
        End Set
    End Property

    Public Property TieneHijos() As Integer
        Get
            Return _TieneHijos
        End Get
        Set(ByVal Value As Integer)
            _TieneHijos = Value
        End Set
    End Property

    Public Property TipoDeFamilia() As Integer
        Get
            Return _TipoDeFamilia
        End Get
        Set(ByVal Value As Integer)
            _TipoDeFamilia = Value
        End Set
    End Property

    Public Property NumeroDeIntegrantesDeLaFamilia() As Integer
        Get
            Return _NumeroDeIntegrantesDeLaFamilia
        End Get
        Set(ByVal Value As Integer)
            _NumeroDeIntegrantesDeLaFamilia = Value
        End Set
    End Property

    Public Property PersonasACargo() As Integer
        Get
            Return _PersonasACargo
        End Get
        Set(ByVal Value As Integer)
            _PersonasACargo = Value
        End Set
    End Property

    Public Property NombreDelCuidador() As String
        Get
            Return _NombreDelCuidador
        End Get
        Set(ByVal Value As String)
            _NombreDelCuidador = Value
        End Set
    End Property

    Public Property TipoDeDocumentoDelCuidador() As String
        Get
            Return _TipoDeDocumentoDelCuidador
        End Get
        Set(ByVal Value As String)
            _TipoDeDocumentoDelCuidador = Value
        End Set
    End Property

    Public Property NumeroDeDocumentoDelCuidador() As String
        Get
            Return _NumeroDeDocumentoDelCuidador
        End Get
        Set(ByVal Value As String)
            _NumeroDeDocumentoDelCuidador = Value
        End Set
    End Property

    Public Property ParentescoDelCuidador() As String
        Get
            Return _ParentescoDelCuidador
        End Get
        Set(ByVal Value As String)
            _ParentescoDelCuidador = Value
        End Set
    End Property

    Public Property DireccionDelCuidador() As String
        Get
            Return _DireccionDelCuidador
        End Get
        Set(ByVal Value As String)
            _DireccionDelCuidador = Value
        End Set
    End Property

    Public Property EscolaridadDelCuidador() As String
        Get
            Return _EscolaridadDelCuidador
        End Get
        Set(ByVal Value As String)
            _EscolaridadDelCuidador = Value
        End Set
    End Property

    Public Property OcupacionDelCuidador() As String
        Get
            Return _OcupacionDelCuidador
        End Get
        Set(ByVal Value As String)
            _OcupacionDelCuidador = Value
        End Set
    End Property

    Public Property EstadoCivilDelCuidador() As String
        Get
            Return _EstadoCivilDelCuidador
        End Get
        Set(ByVal Value As String)
            _EstadoCivilDelCuidador = Value
        End Set
    End Property

    Public Property ProblemasIdentificados() As String
        Get
            Return _ProblemasIdentificados
        End Get
        Set(ByVal Value As String)
            _ProblemasIdentificados = Value
        End Set
    End Property

    Public Property PlanDeIntervencion() As String
        Get
            Return _PlanDeIntervencion
        End Get
        Set(ByVal Value As String)
            _PlanDeIntervencion = Value
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

    Private lstPreguntasAspSocCP As List(Of PreguntaCP)

#End Region

#Region "Functions"

    ''' <summary>
    ''' Guarda la Información de los aspectos sociales registrados al paciente
    ''' </summary>
    ''' <param name="oAspectosSociales">Información del aspecto social</param>
    ''' <returns>Resultado de la inserción</returns>
    ''' <remarks></remarks>
    Public Function GuardarAspectoSocial(ByVal oAspectosSociales As AspectosSociales) As String
        Dim objDACPAspectosSociales As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOCuidadosPaliativos
        Return objDACPAspectosSociales.GuardarAspectoSocial(oAspectosSociales)
    End Function

    ''' <summary>
    ''' Obtiene la ultima respuesta en forma del objeto de aspectos sociales.
    ''' </summary>
    ''' <param name="id_Pregunta">Id de la pregunta obtenida del servicio de última respuesta</param>
    ''' <param name="Respuesta">Respuesta de la pregunta obtenida del servicio de última respuesta</param>
    ''' <returns>El criterio ingreso con la respuesta obtenida por el servicio de última respuesta</returns>
    ''' <remarks></remarks>
    Private Function ObtenerUltimaRespuesta(ByVal id_Pregunta As Integer, ByVal Respuesta As String) As AspectosSociales
        Dim objDACPAspectosSociales As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOCuidadosPaliativos
        Return objDACPAspectosSociales.ConsultarURAspectoSocial(id_Pregunta, Respuesta)
    End Function

    ''' <summary>
    ''' Consulta las preguntas que corresponden al aspecto social
    ''' </summary>
    ''' <param name="oPreguntaCP">Aspecto Social que contiene los filtros de búsqueda</param>
    ''' <returns>Listado de preguntas</returns>
    ''' <remarks></remarks>
    Private Function ConsultarPreguntas(ByVal oPreguntaCP As PreguntaCP) As List(Of PreguntaCP)
        Dim objDAPreguntaCP As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOCuidadosPaliativos
        oPreguntaCP.seccion = Me.SeccionAspSocCP
        Return objDAPreguntaCP.ConsultarPreguntas(oPreguntaCP)
    End Function

    Public Function SugerirRespuesta(ByVal objGeneral As Generales, ByVal objPaciente As Paciente) As AspectosSociales
        Dim srvAspectosSociales As New CuidadosPaleativosServiceImpService()

        Dim oAspectosSociales As New AspectosSociales()
        Dim oURAspectosSociales As New AspectosSociales()
        Try

            lstPreguntasAspSocCP = ConsultarPreguntas(New PreguntaCP)

            If lstPreguntasAspSocCP.Count > 0 Then
                Dim aPreUltRespuesta(lstPreguntasAspSocCP.Count) As Long
                Dim aUltimaRespuesta(lstPreguntasAspSocCP.Count) As PreguntaType
                Dim DAOCP As New DAOCuidadosPaliativos()
                Dim Resultado As String
                Dim appOrigen As String = objPaciente.AppOrigenCP.ToUpper()

                srvAspectosSociales.Url = DAOCP.ConsultarUrlServicioUT(objGeneral.Prestador, objGeneral.Sucursal, DAOCP.TipoServicio, DAOCP.MetodoServicio)

                If srvAspectosSociales.Url = "" Then
                    Throw New Exception("No fue posible consultar el servicio de últimas respuestas (URL).")
                End If

                For i As Integer = 0 To lstPreguntasAspSocCP.Count - 1
                    aPreUltRespuesta(i) = lstPreguntasAspSocCP.Item(i).id
                Next

                'srvAspectosSociales.Url = "http://BOAD100DESAR026:8880/CuidadosPaleativosWS/CuidadosPaleativosService"
                'Resultado = srvAspectosSociales.ultimasRespuestas(objPaciente.TipoDocumento, "17021266", aPreUltRespuesta, "SOPHIA", "BOGOTA", aUltimaRespuesta)

                ''WACHV, 22Dic2017, Se agrega Obtener la ref regional en cada Bd
                '',se cambia parametro de regional objPaciente.Ciudad.ToUpper() por lo retornado en strRegionalRefBD
                Dim strRegionalRefBD As String = DAOCP.ConsultarRegional()
                Resultado = srvAspectosSociales.ultimasRespuestas(objPaciente.TipoDocumento, objPaciente.NumeroDocumento,
                aPreUltRespuesta, appOrigen, strRegionalRefBD.ToUpper(), aUltimaRespuesta)

                For Each pr As PreguntaType In aUltimaRespuesta
                    If pr.respuestas.textoRespuesta <> Nothing Then
                        oAspectosSociales = ObtenerUltimaRespuesta(pr.idPregunta, pr.respuestas.textoRespuesta)
                        CargarUltimaRespuesta(oAspectosSociales, oURAspectosSociales)
                    End If
                    If Not pr.respuestas.listadoIdRespuesta Is Nothing Then
                        If pr.respuestas.listadoIdRespuesta.Length > 0 Then
                            For i As Integer = 0 To pr.respuestas.listadoIdRespuesta.Length - 1
                                oAspectosSociales = ObtenerUltimaRespuesta(pr.idPregunta, pr.respuestas.listadoIdRespuesta(i).ToString())
                                CargarUltimaRespuesta(oAspectosSociales, oURAspectosSociales)
                            Next
                        End If
                    End If
                Next
            End If
            Return oURAspectosSociales
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Carga el objeto de ultima respuesta que se devuelve al control
    ''' </summary>
    ''' <param name="oAspectosSociales">Aspecto Social</param>
    ''' <param name="oURAspectosSociales">Última Respuesta Aspecto Social</param>
    ''' <remarks></remarks>
    Private Sub CargarUltimaRespuesta(ByVal oAspectosSociales As AspectosSociales, ByRef oURAspectosSociales As AspectosSociales)
        Try
            If oAspectosSociales.ConQuienVive <> 0 Then
                oURAspectosSociales.ConQuienVive = oAspectosSociales.ConQuienVive
            End If

            If oAspectosSociales.TipoDeVivienda <> 0 Then
                oURAspectosSociales.TipoDeVivienda = oAspectosSociales.TipoDeVivienda
            End If

            If oAspectosSociales.TenenciaDeLaVivienda <> 0 Then
                oURAspectosSociales.TenenciaDeLaVivienda = oAspectosSociales.TenenciaDeLaVivienda
            End If

            If oAspectosSociales.EstratoDeLaVivienda <> 0 Then
                oURAspectosSociales.EstratoDeLaVivienda = oAspectosSociales.EstratoDeLaVivienda
            End If

            If oAspectosSociales.NivelEscolaridad <> "" Then
                oURAspectosSociales.NivelEscolaridad = oAspectosSociales.NivelEscolaridad
            End If

            If oAspectosSociales.Ocupacion <> "" Then
                oURAspectosSociales.Ocupacion = oAspectosSociales.Ocupacion
            End If

            If oAspectosSociales.CuentaConUnTrabajoEstable <> 0 Then
                oURAspectosSociales.CuentaConUnTrabajoEstable = oAspectosSociales.CuentaConUnTrabajoEstable
            End If

            If oAspectosSociales.Ingresos <> 0 Then
                oURAspectosSociales.Ingresos = oAspectosSociales.Ingresos
            End If

            If oAspectosSociales.CondicionDelPadre <> 0 Then
                oURAspectosSociales.CondicionDelPadre = oAspectosSociales.CondicionDelPadre
            End If

            If oAspectosSociales.CondicionDeLaMadre <> 0 Then
                oURAspectosSociales.CondicionDeLaMadre = oAspectosSociales.CondicionDeLaMadre
            End If

            If oAspectosSociales.NumeroDeHermanos <> 0 Then
                oURAspectosSociales.NumeroDeHermanos = oAspectosSociales.NumeroDeHermanos
            End If

            If oAspectosSociales.Lugar <> 0 Then
                oURAspectosSociales.Lugar = oAspectosSociales.Lugar
            End If

            If oAspectosSociales.TieneHijos <> 0 Then
                oURAspectosSociales.TieneHijos = oAspectosSociales.TieneHijos
            End If

            If oAspectosSociales.TipoDeFamilia <> 0 Then
                oURAspectosSociales.TipoDeFamilia = oAspectosSociales.TipoDeFamilia
            End If

            If oAspectosSociales.NumeroDeIntegrantesDeLaFamilia <> 0 Then
                oURAspectosSociales.NumeroDeIntegrantesDeLaFamilia = oAspectosSociales.NumeroDeIntegrantesDeLaFamilia
            End If

            If oAspectosSociales.PersonasACargo <> 0 Then
                oURAspectosSociales.PersonasACargo = oAspectosSociales.PersonasACargo
            End If

            If oAspectosSociales.NombreDelCuidador <> "" Then
                oURAspectosSociales.NombreDelCuidador = oAspectosSociales.NombreDelCuidador
            End If

            If oAspectosSociales.TipoDeDocumentoDelCuidador <> "" Then
                oURAspectosSociales.TipoDeDocumentoDelCuidador = oAspectosSociales.TipoDeDocumentoDelCuidador
            End If

            If oAspectosSociales.NumeroDeDocumentoDelCuidador <> 0 Then
                oURAspectosSociales.NumeroDeDocumentoDelCuidador = oAspectosSociales.NumeroDeDocumentoDelCuidador
            End If

            If oAspectosSociales.ParentescoDelCuidador <> "" Then
                oURAspectosSociales.ParentescoDelCuidador = oAspectosSociales.ParentescoDelCuidador
            End If

            If oAspectosSociales.DireccionDelCuidador <> "" Then
                oURAspectosSociales.DireccionDelCuidador = oAspectosSociales.DireccionDelCuidador
            End If

            If oAspectosSociales.EscolaridadDelCuidador <> 0 Then
                oURAspectosSociales.EscolaridadDelCuidador = oAspectosSociales.EscolaridadDelCuidador
            End If

            If oAspectosSociales.OcupacionDelCuidador <> 0 Then
                oURAspectosSociales.OcupacionDelCuidador = oAspectosSociales.OcupacionDelCuidador
            End If

            If oAspectosSociales.EstadoCivilDelCuidador <> "" Then
                oURAspectosSociales.EstadoCivilDelCuidador = oAspectosSociales.EstadoCivilDelCuidador
            End If

            If oAspectosSociales.ProblemasIdentificados <> "" Then
                oURAspectosSociales.ProblemasIdentificados = oAspectosSociales.ProblemasIdentificados
            End If

            If oAspectosSociales.PlanDeIntervencion <> "" Then
                oURAspectosSociales.PlanDeIntervencion = oAspectosSociales.PlanDeIntervencion
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region


End Class