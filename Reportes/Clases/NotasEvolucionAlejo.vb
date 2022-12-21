Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports System.Collections.Generic
Imports System.Data.Common

Namespace Sophia.HistoriaClinica.Reportes
    ''' <summary>
    ''' Clase que encapsula los datos de una nota de evolucion
    ''' </summary>
    ''' <remarks></remarks>
    Public Class NotasEvolucion
        Inherits GPMDataReport

        Private _cod_historia As Decimal    'Codigo de la manilla registrada para el recien nacido
        Private _Consecutivo As Integer     'Fecha de nacimiento
        Private _notaevolucion As String    'Hora del recien nacido
        Private _fecha As DateTime          'minuto del recien nacido
        Private _hora_evolucion As String   'Peso del recien nacido
        Private _min_evolucion As String    'Talla del recien nacido
        Private _fec_con As DateTime          'minuto del recien nacido
        Private _hora_reg As String   'Peso del recien nacido
        Private _min_reg As String    'Talla del recien nacido
        Private _login As String            'Perimetro cefalico del recien nacido
        Private _cargo As String

#Region "Propiedades"
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
        Public ReadOnly Property notaevolucion() As String
            Get
                Return _notaevolucion
            End Get
        End Property
        Public ReadOnly Property fecha() As DateTime
            Get
                Return _fecha
            End Get
        End Property
        Public ReadOnly Property hora_evolucion() As String
            Get
                Return _hora_evolucion
            End Get
        End Property
        Public ReadOnly Property min_evolucion() As String
            Get
                Return _min_evolucion
            End Get
        End Property
        Public ReadOnly Property fec_con() As DateTime
            Get
                Return _fec_con
            End Get
        End Property
        Public ReadOnly Property hora_reg() As String
            Get
                Return _hora_reg
            End Get
        End Property
        Public ReadOnly Property min_reg() As String
            Get
                Return _min_reg
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

        Public Sub New(ByVal dcod_historia As Decimal, ByVal iConsecutivo As Integer, ByVal snotaevolucion As String, _
                       ByVal dfecha As DateTime, ByVal shora_evolucion As String, ByVal smin_evolucion As String, _
                       ByVal dfec_con As DateTime, ByVal shora_reg As String, ByVal smin_reg As String, _
                       ByVal slogin As String, ByVal scargo As String)

            _cod_historia = dcod_historia
            _Consecutivo = iConsecutivo
            _notaevolucion = snotaevolucion
            _fecha = dfecha
            _hora_evolucion = shora_evolucion
            _min_evolucion = smin_evolucion
            _fec_con = dfec_con
            _hora_reg = shora_reg
            _min_reg = smin_reg
            _login = slogin
            _cargo = scargo
        End Sub

        Public Function consultarNotasEvolucion(ByVal objConexion As Conexion, _
                                              ByVal dCod_Historia As Decimal, ByVal strFechaIni_RecNac As String, ByVal strFechaFin_RecNac As String, ByVal iHoraIni_RecNac As Integer, ByVal iHoraFin_RecNac As Integer) As List(Of NotasEvolucion)

            Dim dtReader As DbDataReader
            Dim objNotasEvolucion As NotasEvolucion
            Dim listaNotasEvolucion As New List(Of NotasEvolucion)

            Dim lError As Long = 0

            gpmDataObj.setSQLSentence("HCEnf_TraerNotasEvolucion", CommandType.StoredProcedure)

            gpmDataObj.addInputParameter("@intCodhistoria", SqlDbType.Int, dCod_Historia)
            gpmDataObj.addInputParameter("lError", SqlDbType.Int, lError)

            dtReader = gpmDataObj.ExecRdr()

            While dtReader.Read()
                objNotasEvolucion = New NotasEvolucion(dCod_Historia, CInt(dtReader("Consecutivo").ToString), _
                                                   dtReader("notaevolucion").ToString, CDate(dtReader("fecha").ToString), _
                                                   dtReader("hora_evolucion").ToString, dtReader("min_evolucion").ToString, _
                                                   CDate(dtReader("fec_con").ToString), dtReader("hora_reg").ToString, _
                                                   dtReader("min_reg").ToString, dtReader("login").ToString, dtReader("cargo").ToString)
                listaNotasEvolucion.Add(objNotasEvolucion)
            End While

            If dtReader.IsClosed = False Then
                dtReader.Close()
            End If

            Return listaNotasEvolucion

        End Function

        Public Function consultarNotasEvolucionDT(ByVal objConexion As Conexion, ByVal dCod_Historia As Integer, ByVal strFechaIni As Nullable(Of Date), ByVal strFechaFin As Nullable(Of Date), ByVal iHoraIni As Nullable(Of Integer), ByVal iHoraFin As Nullable(Of Integer)) As DataTable

            Dim lError As Long = 0

            gpmDataObj.setSQLSentence("HCEnf_TraerNotasEvolucion", CommandType.StoredProcedure)

            gpmDataObj.addInputParameter("@intCodhistoria", SqlDbType.Int, dCod_Historia)
            'gpmDataObj.addInputParameter("@intCodhistoria", SqlDbType.Int, dCod_Historia)
            gpmDataObj.addInputParameter("@strFechaIni", SqlDbType.DateTime, strFechaIni)
            gpmDataObj.addInputParameter("@strFechaFin", SqlDbType.DateTime, strFechaFin)
            gpmDataObj.addInputParameter("@iHoraIni", SqlDbType.Int, iHoraIni)
            gpmDataObj.addInputParameter("@iHoraFin", SqlDbType.Int, iHoraFin)
            gpmDataObj.addInputParameter("lError", SqlDbType.Int, lError)

            Return gpmDataObj.execDT
        End Function


    End Class
End Namespace