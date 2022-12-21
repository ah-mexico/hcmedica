Imports System.Collections.Generic

Public Class PreguntaCP
    'HC_CpPreguntas

    Private _id As Integer
    Private _descripcion As String
    Private _seccion As Long
    Private _Tabla_Movimiento As String
    Private _Pregunta_Campo As String
    Private _id_av As Integer
    Private _id_respuestaav As String
    Private _fec_con As DateTime
    Private _obs As String
    Private _login As String

    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal Value As Integer)
            _id = Value
        End Set
    End Property

    Public Property descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal Value As String)
            _descripcion = Value
        End Set
    End Property

    Public Property seccion() As Long
        Get
            Return _seccion
        End Get
        Set(ByVal Value As Long)
            _seccion = Value
        End Set
    End Property

    Public Property Tabla_Movimiento() As String
        Get
            Return _Tabla_Movimiento
        End Get
        Set(ByVal Value As String)
            _Tabla_Movimiento = Value
        End Set
    End Property

    Public Property Pregunta_Campo() As String
        Get
            Return _Pregunta_Campo
        End Get
        Set(ByVal Value As String)
            _Pregunta_Campo = Value
        End Set
    End Property

    Public Property id_av() As Integer
        Get
            Return _id_av
        End Get
        Set(ByVal Value As Integer)
            _id_av = Value
        End Set
    End Property

    Public Property id_respuestaav() As String
        Get
            Return _id_respuestaav
        End Get
        Set(ByVal Value As String)
            _id_respuestaav = Value
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

    Public Function ConsultarPreguntas(ByVal oPreguntaCP As PreguntaCP) As List(Of PreguntaCP)

        Dim objDAPreguntaCP As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOCuidadosPaliativos
        Return objDAPreguntaCP.ConsultarPreguntas(oPreguntaCP)

    End Function

End Class
