Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports System.Collections.Generic
Imports System.Data.Common

Namespace Sophia.HistoriaClinica.Reportes
    ''' <summary>
    ''' Clase que encapsula los datos de una nota de evolucion
    ''' </summary>
    ''' <remarks></remarks>
    Public Class SubseccionNeo
        Inherits GPMDataReport

        Private _cod_historia As Decimal    'Codigo de la manilla registrada para el recien nacido
        Private _Consecutivo As Integer     'Fecha de nacimiento
        Private _notaevolucion As String    'Hora del recien nacido
        Private _fecha As DateTime          'minuto del recien nacido
        Private _hora_evolucion As String   'Peso del recien nacido
        Private _min_evolucion As String    'Talla del recien nacido

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


#End Region

        Public Sub New()
            MyBase.New()
        End Sub

       
        Public Function consultarSubseccionNeoDT(ByVal objConexion As Conexion, ByVal dCod_Historia As Integer, ByVal strFechaIni As Nullable(Of Date), ByVal strFechaFin As Nullable(Of Date), ByVal iHoraIni As Nullable(Of Integer), ByVal iHoraFin As Nullable(Of Integer)) As DataTable

            Dim lError As Long = 0

            gpmDataObj.setSQLSentence("HCENF_TraerSubseccionNeo", CommandType.StoredProcedure)

            gpmDataObj.addInputParameter("@intCodhistoria", SqlDbType.Int, dCod_Historia)
            gpmDataObj.addInputParameter("@strFechaIni", SqlDbType.DateTime, strFechaIni)
            gpmDataObj.addInputParameter("@strFechaFin", SqlDbType.DateTime, strFechaFin)
            gpmDataObj.addInputParameter("@iHoraIni", SqlDbType.Int, iHoraIni)
            gpmDataObj.addInputParameter("@iHoraFin", SqlDbType.Int, iHoraFin)
            gpmDataObj.addInputParameter("lError", SqlDbType.Int, lError)

            Return gpmDataObj.execDT
        End Function


    End Class
End Namespace