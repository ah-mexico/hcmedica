Imports System.Collections.Generic
Imports System
Imports HistoriaClinica.wsCuidadoPaliativo

Public Class ComplejidadDerivacion

#Region "Properties"
    Public ReadOnly SeccionCompDerivCP As Integer = 5

    Private _strPrestador As String
    Public Property Prestador() As String
        Get
            Return _strPrestador
        End Get
        Set(ByVal value As String)
            _strPrestador = value
        End Set
    End Property

    Private _strSucursal As String
    Public Property Sucursal() As String
        Get
            Return _strSucursal
        End Get
        Set(ByVal value As String)
            _strSucursal = value
        End Set
    End Property

    Private _strTipoAdmision As String
    Public Property TipoAdmision() As String
        Get
            Return _strTipoAdmision
        End Get
        Set(ByVal value As String)
            _strTipoAdmision = value
        End Set
    End Property

    Private strAnoAdmision As Integer
    Public Property AnoAdmision() As Integer
        Get
            Return strAnoAdmision
        End Get
        Set(ByVal value As Integer)
            strAnoAdmision = value
        End Set
    End Property

    Private _decNumeroAdmision As Decimal
    Public Property NumeroAdmision() As Decimal
        Get
            Return _decNumeroAdmision
        End Get
        Set(ByVal value As Decimal)
            _decNumeroAdmision = value
        End Set
    End Property

    Private _strLogin As String
    Public Property Login() As String
        Get
            Return _strLogin
        End Get
        Set(ByVal value As String)
            _strLogin = value
        End Set
    End Property

    Private _strObservaciones As String
    Public Property Observaciones() As String
        Get
            Return _strObservaciones
        End Get
        Set(ByVal value As String)
            _strObservaciones = value
        End Set
    End Property

    Private _strTipoDocumento As String
    Public Property TipoDocumento() As String
        Get
            Return _strTipoDocumento
        End Get
        Set(ByVal value As String)
            _strTipoDocumento = value
        End Set
    End Property

    Private _numeroDocumento As String
    Public Property NumeroDocumento() As String
        Get
            Return _numeroDocumento
        End Get
        Set(ByVal value As String)
            _numeroDocumento = value
        End Set
    End Property

    Private _strResultadoEscala As String
    Public Property ResultadoEscala() As String
        Get
            Return _strResultadoEscala
        End Get
        Set(ByVal value As String)
            _strResultadoEscala = value
        End Set
    End Property

    Private _strLugarDerivacion As String
    Public Property LugarDerivacion() As String
        Get
            Return _strLugarDerivacion
        End Get
        Set(ByVal value As String)
            _strLugarDerivacion = value
        End Set
    End Property

    Private _ComplejidadClinica As List(Of PreguntaComplejidad) = New List(Of PreguntaComplejidad)
    Public Property itemsComplejidadClinica() As List(Of PreguntaComplejidad)
        Get
            Return _ComplejidadClinica
        End Get
        Set(ByVal value As List(Of PreguntaComplejidad))
            _ComplejidadClinica = value
        End Set
    End Property

    Private _ComplejidadPsicosocial As List(Of PreguntaComplejidad) = New List(Of PreguntaComplejidad)
    Public Property itemsComplejidadPsicosocial() As List(Of PreguntaComplejidad)
        Get
            Return _ComplejidadPsicosocial
        End Get
        Set(ByVal value As List(Of PreguntaComplejidad))
            _ComplejidadPsicosocial = value
        End Set
    End Property

    Private _ComplejidadAtencion As List(Of PreguntaComplejidad) = New List(Of PreguntaComplejidad)
    Public Property itemsComplejidadAtencion() As List(Of PreguntaComplejidad)
        Get
            Return _ComplejidadAtencion
        End Get
        Set(ByVal value As List(Of PreguntaComplejidad))
            _ComplejidadAtencion = value
        End Set
    End Property

    Private _Derivacion As List(Of PreguntaComplejidad) = New List(Of PreguntaComplejidad)
    Public Property itemsDerivacion() As List(Of PreguntaComplejidad)
        Get
            Return _Derivacion
        End Get
        Set(ByVal value As List(Of PreguntaComplejidad))
            _Derivacion = value
        End Set
    End Property
    ''WACHV, INICIO, 24OCT2017,NUEVA PREGUNTA LUGAR DERIVACION NUEVA
    Private _strLugarDerivacionNva As String
    Public Property LugarDerivacionNva() As String
        Get
            Return _strLugarDerivacionNva
        End Get
        Set(ByVal value As String)
            _strLugarDerivacionNva = value
        End Set
    End Property ''WACHV, FIN, 24OCT2017,NUEVA PREGUNTA LUGAR DERIVACION NUEVA

    '''WACHV,INICIO, 13OCT2017, SE AGREGAN LOS NUEVOS CAMPOS DE TOTALES POR SECCION, COMPLEJIDAD CLINICA, PSICOSOCIAL,ATENCION
    Private _TotalComplejidadClinica As String
    Public Property TotalComplejidadClinica() As String
        Get
            Return _TotalComplejidadClinica
        End Get
        Set(ByVal value As String)
            _TotalComplejidadClinica = value
        End Set
    End Property

    Private _TotalComplejidadPsicoSocial As String
    Public Property TotalComplejidadPsicoSocial() As String
        Get
            Return _TotalComplejidadPsicoSocial
        End Get
        Set(ByVal value As String)
            _TotalComplejidadPsicoSocial = value
        End Set
    End Property
    Private _TotalComplejidadAtencion As String
    Public Property TotalComplejidadAtencion() As String
        Get
            Return _TotalComplejidadAtencion
        End Get
        Set(ByVal value As String)
            _TotalComplejidadAtencion = value
        End Set
    End Property     '''WACHV,FIN, 13OCT2017, SE AGREGAN LOS NUEVOS CAMPOS DE TOTALES POR SECCION, COMPLEJIDAD CLINICA, PSICOSOCIAL,ATENCION
#End Region

#Region "Funtions"
    Public Function ConsultarPreguntas(ByVal oPreguntaCP As PreguntaCP) As List(Of PreguntaCP)
        Dim objDAPreguntaCP As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOCuidadosPaliativos
        oPreguntaCP.seccion = Me.SeccionCompDerivCP
        Return objDAPreguntaCP.ConsultarPreguntas(oPreguntaCP)
    End Function

    Public Function ObtenerUltimaRespuesta(ByVal ultimasRespuestas() As PreguntaType) As ComplejidadDerivacion
        Dim objDACPComplejidadDerivacion As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOComplejidadDerivacion
        Return objDACPComplejidadDerivacion.ConsultarURComplejidadDerivacion(ultimasRespuestas)
    End Function
#End Region
End Class

Public Class PreguntaComplejidad
    Private _strRespuestaPregunta As String
    Public Property RespuestaPregunta() As String
        Get
            Return _strRespuestaPregunta
        End Get
        Set(ByVal value As String)
            _strRespuestaPregunta = value
        End Set
    End Property

    Private _strNomCampo As String
    Public Property NombreCampo() As String
        Get
            Return _strNomCampo
        End Get
        Set(ByVal value As String)
            _strNomCampo = value
        End Set
    End Property
End Class