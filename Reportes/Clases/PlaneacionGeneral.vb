Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports System.Collections.Generic
Imports System.Data.Common
''Claudia Garay Planeacion de medicamentos
Namespace Sophia.HistoriaClinica.Reportes
    ''' <summary>
    ''' Clase que encapsula los datos de una nota de evolucion
    ''' </summary>
    ''' <remarks></remarks>
    Public Class PlaneacionGeneral
        Inherits GPMDataReport

        Private _fecha As String    'Fecha de planeacion
        Private _descripcion As String 'Descripcion de planeacion
        Private _descripcionplaneado As String 'Descripcion de planeacion
      

#Region "Propiedades"

        Public Property fecha() As String
            Get
                Return _fecha
            End Get
            Set(ByVal value As String)
                _fecha = value
            End Set
        End Property
        Public Property Descripcion() As String
            Get
                Return _descripcion
            End Get
            Set(ByVal value As String)
                _descripcion = value
            End Set
        End Property
        Public Property DescripcionPlaneado() As String
            Get
                Return _descripcionplaneado
            End Get
            Set(ByVal value As String)
                _descripcionplaneado = value
            End Set
        End Property

#End Region

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal dfecha As DateTime, ByVal sDescr As String, ByVal sdescplanea As String)

            _fecha = dfecha
            _descripcion = sDescr
            _descripcionplaneado = sdescplanea
        End Sub

        Public Function consultarPlaneacionMedicamentos(ByVal objConexion As Conexion, ByVal dCod_Historia As Decimal, ByVal strFechaIni_RecNac As String, ByVal strFechaFin_RecNac As String, ByVal iHoraIni_RecNac As Integer, ByVal iHoraFin_RecNac As Integer) As List(Of Planeacion)

            Dim dtReader As DbDataReader
            Dim objplaneacion As Planeacion
            Dim listaPlaneacion As New List(Of Planeacion)
            Dim lError As Long = 0

            gpmDataObj.setSQLSentence("HCENFREP_TraePlaneacionMedicamento", CommandType.StoredProcedure)

            gpmDataObj.addInputParameter("@intCodhistoria", SqlDbType.Int, dCod_Historia)
            gpmDataObj.addInputParameter("lError", SqlDbType.Int, lError)

            dtReader = gpmDataObj.ExecRdr()


            While dtReader.Read()
                objplaneacion = New Planeacion(CDate(dtReader("fecha").ToString), dtReader("cargo").ToString, _
                dtReader("medicamento").ToString, dtReader("estado").ToString, dtReader("hora").ToString, _
                dtReader("medico").ToString, dtReader("obs").ToString, dtReader("MedPlaneados").ToString)
                listaPlaneacion.Add(objplaneacion)
            End While

            If dtReader.IsClosed = False Then
                dtReader.Close()
            End If

            Return listaPlaneacion

        End Function


        Public Function consultarPlaneacionDT(ByVal objConexion As Conexion, ByVal dCod_Historia As Integer, ByVal strFechaIni_RecNac As Nullable(Of DateTime), ByVal strFechaFin_RecNac As Nullable(Of DateTime), ByVal iHoraIni_RecNac As Nullable(Of Integer), ByVal iHoraFin_RecNac As Nullable(Of Integer)) As List(Of PlaneacionGeneral)
            Dim listaPlaneacion As New List(Of PlaneacionGeneral)
            Dim lError As Long = 0
            Dim dtReader As DataTable
            Dim objPlaneacion As PlaneacionGeneral
            Dim drFila As DataRow


            gpmDataObj.setSQLSentence("HCENFREP_TraePlaneacionYAdministracionGenerales", CommandType.StoredProcedure)
            gpmDataObj.addInputParameter("@intCodhistoria", SqlDbType.Int, dCod_Historia)
            gpmDataObj.addInputParameter("@strFechaIni", SqlDbType.DateTime, strFechaIni_RecNac)
            gpmDataObj.addInputParameter("@strFechaFin", SqlDbType.DateTime, strFechaFin_RecNac)            
            gpmDataObj.addInputParameter("@iHoraIni", SqlDbType.Int, iHoraIni_RecNac)
            gpmDataObj.addInputParameter("@iHoraFin", SqlDbType.Int, iHoraFin_RecNac)
            gpmDataObj.addOutputParameter("@lError", SqlDbType.Int, lError)
            dtReader = gpmDataObj.execDT
            ''dtReader = Configuradescripcionconcatenada(dtReader)

            For Each drFila In dtReader.Rows
                objPlaneacion = New PlaneacionGeneral
                With objPlaneacion
                    .fecha = drFila.Item("fecha").ToString
                    .Descripcion = drFila.Item("descprograma").ToString
                    .DescripcionPlaneado = drFila.Item("desc_planeados").ToString
                End With
                listaPlaneacion.Add(objPlaneacion)
            Next
            Return listaPlaneacion

        End Function

    End Class
End Namespace