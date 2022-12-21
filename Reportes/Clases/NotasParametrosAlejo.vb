Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports System.Collections.Generic
Imports System.Data.Common

Namespace Sophia.HistoriaClinica.Reportes
    ''' <summary>
    ''' Clase que encapsula los datos de una nota de evolucion
    ''' </summary>
    ''' <remarks></remarks>
    Public Class NotasParametros
        Inherits GPMDataReport

        Private _cod_grupoparametricas As Integer    'Codigo de la manilla registrada para el recien nacido
        Private _desc_grupoparametricas As String     'Fecha de nacimiento
        Private _cod_parametricas As Integer    'Hora del recien nacido
        Private _desc_parametricas As String          'minuto del recien nacido
        Private _cod_historia As Decimal   'Peso del recien nacido
        Private _Consecutivo As Integer    'Talla del recien nacido
        Private _fecha As DateTime          'minuto del recien nacido
        Private _hora_parametrica As String   'Peso del recien nacido
        Private _min_parametrica As String    'Talla del recien nacido
        Private _login As String            'Perimetro cefalico del recien nacido
        Private _cargo As String

#Region "Propiedades"
        Public ReadOnly Property cod_grupoparametricas() As Integer
            Get
                Return _cod_grupoparametricas
            End Get
        End Property
        Public ReadOnly Property desc_grupoparametricas() As String
            Get
                Return _desc_grupoparametricas
            End Get
        End Property
        Public ReadOnly Property cod_parametricas() As Integer
            Get
                Return _cod_parametricas
            End Get
        End Property
        Public ReadOnly Property desc_parametricas() As String
            Get
                Return _desc_parametricas
            End Get
        End Property
        Public ReadOnly Property cod_historia() As Decimal
            Get
                Return _cod_historia
            End Get
        End Property
        Public ReadOnly Property Consecutivo() As Integer
            Get
                Return _Consecutivo
            End Get
        End Property
        Public ReadOnly Property fecha() As DateTime
            Get
                Return _fecha
            End Get
        End Property
        Public ReadOnly Property hora_parametrica() As String
            Get
                Return _hora_parametrica
            End Get
        End Property
        Public ReadOnly Property min_parametrica() As String
            Get
                Return _min_parametrica
            End Get
        End Property
        Public ReadOnly Property login() As String
            Get
                Return _login
            End Get
        End Property
        Public ReadOnly Property cargo() As String
            Get
                Return _cargo
            End Get
        End Property
#End Region

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal icod_grupoparametricas As Integer, ByVal sdesc_grupoparametricas As String, ByVal icod_parametricas As Integer, _
                       ByVal ddesc_parametricas As String, ByVal dcod_historia As Decimal, ByVal iConsecutivo As Integer, _
                       ByVal dfecha As DateTime, ByVal shora_parametrica As String, ByVal smin_parametrica As String, _
                       ByVal slogin As String, ByVal scargo As String)

            _cod_grupoparametricas = icod_grupoparametricas
            _desc_grupoparametricas = sdesc_grupoparametricas
            _cod_parametricas = icod_parametricas
            _desc_parametricas = ddesc_parametricas
            _cod_historia = dcod_historia
            _Consecutivo = iConsecutivo
            _fecha = dfecha
            _hora_parametrica = shora_parametrica
            _min_parametrica = smin_parametrica
            _login = slogin
            _cargo = scargo
        End Sub

        Public Function consultarNotasParametricas(ByVal objConexion As Conexion, ByVal dCod_Historia As Decimal, ByVal strFechaIni_RecNac As String, ByVal strFechaFin_RecNac As String, ByVal iHoraIni_RecNac As Integer, ByVal iHoraFin_RecNac As Integer) As List(Of NotasParametros)

            Dim dtReader As DbDataReader
            Dim objNotasParametros As NotasParametros
            Dim listaNotasParametros As New List(Of NotasParametros)

            Dim lError As Long = 0

            gpmDataObj.setSQLSentence("HCENF_TraerNotasParametricas", CommandType.StoredProcedure)

            gpmDataObj.addInputParameter("@intCodhistoria", SqlDbType.Int, dCod_Historia)
            gpmDataObj.addInputParameter("lError", SqlDbType.Int, lError)

            dtReader = gpmDataObj.ExecRdr()

            While dtReader.Read()
                objNotasParametros = New NotasParametros(CInt(dtReader("cod_grupoparametricas").ToString), dtReader("desc_grupoparametricas").ToString, _
                                                   CInt(dtReader("cod_parametricas").ToString), dtReader("desc_parametricas").ToString, _
                                                   dCod_Historia, CInt(dtReader("Consecutivo").ToString), _
                                                   CDate(dtReader("fecha").ToString), dtReader("hora_parametrica").ToString, _
                                                   dtReader("min_parametrica").ToString, dtReader("login").ToString, dtReader("cargo").ToString)
                listaNotasParametros.Add(objNotasParametros)
            End While

            If dtReader.IsClosed = False Then
                dtReader.Close()
            End If

            Return listaNotasParametros

        End Function


        Public Function consultarNotasParametricasDT(ByVal objConexion As Conexion, ByVal dCod_Historia As Integer, ByVal strFechaIni_RecNac As Nullable(Of DateTime), ByVal strFechaFin_RecNac As Nullable(Of DateTime), ByVal iHoraIni_RecNac As Nullable(Of Integer), ByVal iHoraFin_RecNac As Nullable(Of Integer)) As DataTable
            Dim lError As Long = 0

            gpmDataObj.setSQLSentence("HCENF_TraerNotasParametricas", CommandType.StoredProcedure)

            gpmDataObj.addInputParameter("@intCodhistoria", SqlDbType.Int, dCod_Historia)
            gpmDataObj.addInputParameter("@strFechaIni_RecNac", SqlDbType.DateTime, strFechaIni_RecNac)
            gpmDataObj.addInputParameter("@strFechaFin_RecNac", SqlDbType.DateTime, strFechaFin_RecNac)
            gpmDataObj.addInputParameter("@iHoraIni_RecNac", SqlDbType.Int, iHoraIni_RecNac)
            gpmDataObj.addInputParameter("@iHoraFin_RecNac", SqlDbType.Int, iHoraFin_RecNac)
            gpmDataObj.addOutputParameter("@lError", SqlDbType.Int, lError)

            Return gpmDataObj.execDT
        End Function

    End Class
End Namespace