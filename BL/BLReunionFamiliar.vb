Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales.Generales
Imports objPaciente = HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente.Paciente
Imports System.Collections.Generic
Imports HistoriaClinica.wsCuidadoPaliativo

Namespace Sophia.HistoriaClinica.BL
    Public Class BLReunionFamiliar

        Private _strSucursal As String
        Public Property Sucursal() As String
            Get
                Return _strSucursal
            End Get
            Set(ByVal value As String)
                _strSucursal = value
            End Set
        End Property

        Private _strPrestador As String
        Public Property Prestador() As String
            Get
                Return _strPrestador
            End Get
            Set(ByVal value As String)
                _strPrestador = value
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

        Private _intAnioAdmision As Integer
        Public Property AnioAdmision() As Integer
            Get
                Return _intAnioAdmision
            End Get
            Set(ByVal value As Integer)
                _intAnioAdmision = value
            End Set
        End Property

        Private _intNumAdmision As Integer
        Public Property NumAdmision() As Integer
            Get
                Return _intNumAdmision
            End Get
            Set(ByVal value As Integer)
                _intNumAdmision = value
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

        Private _intNumDocumento As Integer
        Public Property NumDocumento() As Integer
            Get
                Return _intNumDocumento
            End Get
            Set(ByVal value As Integer)
                _intNumDocumento = value
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

        Private _ListaParticipantesEquipoReunion As New List(Of BLParticipantesReunion)
        Public Property ParticipantesEquipoReunion() As List(Of BLParticipantesReunion)
            Get
                Return _ListaParticipantesEquipoReunion
            End Get
            Set(ByVal value As List(Of BLParticipantesReunion))
                _ListaParticipantesEquipoReunion = value
            End Set
        End Property

        Private _ListaParticipantesFamiliaReunion As New List(Of BLParticipantesReunion)
        Public Property ParticipantesFamiliaReunion() As List(Of BLParticipantesReunion)
            Get
                Return _ListaParticipantesFamiliaReunion
            End Get
            Set(ByVal value As List(Of BLParticipantesReunion))
                _ListaParticipantesFamiliaReunion = value
            End Set
        End Property

        Private _strInformacionReunion As String
        Public Property InformacionReunion() As String
            Get
                Return _strInformacionReunion
            End Get
            Set(ByVal value As String)
                _strInformacionReunion = value
            End Set
        End Property

        Private _strPreocupacionesDificultadesEmergentes As String
        Public Property PreocupacionesDificultadesEmergentes() As String
            Get
                Return _strPreocupacionesDificultadesEmergentes
            End Get
            Set(ByVal value As String)
                _strPreocupacionesDificultadesEmergentes = value
            End Set
        End Property

        Private _strTemasPendientes As String
        Public Property TemasPendientes() As String
            Get
                Return _strTemasPendientes
            End Get
            Set(ByVal value As String)
                _strTemasPendientes = value
            End Set
        End Property

        Private _strEstrategiasASeguir As String
        Public Property EstrategiasASeguir() As String
            Get
                Return _strEstrategiasASeguir
            End Get
            Set(ByVal value As String)
                _strEstrategiasASeguir = value
            End Set
        End Property

#Region "Functions"
        Public Function ConsultarPreguntas(ByVal oPreguntaCP As PreguntaCP) As List(Of PreguntaCP)
            Dim objDAPreguntaCP As New DAOCuidadosPaliativos()
            oPreguntaCP.seccion = 6
            Return objDAPreguntaCP.ConsultarPreguntas(oPreguntaCP)
        End Function

        Public Function ObtenerUltimaRespuesta(ByVal ultimasRespuestas() As PreguntaType) As BLReunionFamiliar
            Dim objDACPReunionFamiliar As New DAOReunionFamiliar()
            Return objDACPReunionFamiliar.ConsultarURReunionFamiliar(ultimasRespuestas)
        End Function

        Public Function obtenerParticipantesReunion(ByVal tipoDocumento As String, ByVal numeroDocumento As String, ByVal tipoParticipante As String) As DataTable
            Dim objDACPReunionFamiliar As New DAOReunionFamiliar()
            Return objDACPReunionFamiliar.obtenerParticipantesReunion(tipoDocumento, numeroDocumento, tipoParticipante)
        End Function
#End Region
    End Class
    
    Public Class BLParticipantesReunion

        Private _intIdPreguntaCaracteristica As Integer
        Public Property IdPreguntaCaracteristica() As Integer
            Get
                Return _intIdPreguntaCaracteristica
            End Get
            Set(ByVal value As Integer)
                _intIdPreguntaCaracteristica = value
            End Set
        End Property

        Private _intIdCaracteristicaParticipante As Integer
        Public Property IdCaracteriscitaParticipante() As Integer
            Get
                Return _intIdCaracteristicaParticipante
            End Get
            Set(ByVal value As Integer)
                _intIdCaracteristicaParticipante = value
            End Set
        End Property

        Private _strNombreCaracteristicaParticipante As String
        Public Property NombreCaracteristicaParticipante() As String
            Get
                Return _strNombreCaracteristicaParticipante
            End Get
            Set(ByVal value As String)
                _strNombreCaracteristicaParticipante = value
            End Set
        End Property

        Private _intIdPreguntaNombre As Integer
        Public Property IdPreguntaNombre() As Integer
            Get
                Return _intIdPreguntaNombre
            End Get
            Set(ByVal value As Integer)
                _intIdPreguntaNombre = value
            End Set
        End Property

        Private _intIdRespuestaNombre As Integer
        Public Property IdRespuestaNombre() As Integer
            Get
                Return _intIdRespuestaNombre
            End Get
            Set(ByVal value As Integer)
                _intIdRespuestaNombre = value
            End Set
        End Property

        Private _strNombreParticipante As String
        Public Property NombreParticipante() As String
            Get
                Return _strNombreParticipante
            End Get
            Set(ByVal value As String)
                _strNombreParticipante = value
            End Set
        End Property


    End Class
End Namespace