Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports System.Collections.Generic
Imports System.Data.Common


Namespace Sophia.HistoriaClinica.Reportes
    ''' <summary>
    ''' Clase que encapsula los datos de una nota de evolucion
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Hemodialisis
        Inherits GPMDataReport

        Private _Cod_Historia As Decimal
        Private _Consecutivo As String
        Private _desc_tipocateter As String
        Private _fecha As DateTime
        Private _hora_cateter As String
        Private _min_cateter As String
        Private _calibre As Decimal
        Private _luzcateter As String
        Private _viainsercion As String
        Private _lateralidad As String
        Private _desc_sitioinsercion As String
        Private _desc_tecinsercion As String
        Private _numpuntuacion As String
        Private _controlradio As String
        Private _localizacion As String
        Private _desc_complicacion As String
        Private _desc_indicacion As String
#Region "Propiedades"
        Public ReadOnly Property Cod_Historia() As Integer
            Get
                Return _Cod_Historia
            End Get
        End Property
        Public ReadOnly Property Consecutivo() As String
            Get
                Return _Consecutivo
            End Get
        End Property
        Public ReadOnly Property Desc_tipocateter() As String
            Get
                Return _desc_tipocateter
            End Get
        End Property
        Public ReadOnly Property Fecha() As String
            Get
                Return _fecha
            End Get
        End Property
        Public ReadOnly Property Hora_cateter() As String
            Get
                Return _hora_cateter
            End Get
        End Property
        Public ReadOnly Property Min_cateter() As Integer
            Get
                Return _min_cateter
            End Get
        End Property
        Public ReadOnly Property Calibre() As Integer
            Get
                Return _calibre
            End Get
        End Property
        Public ReadOnly Property Luzcateter() As Integer
            Get
                Return _luzcateter
            End Get
        End Property
        Public ReadOnly Property Viainsercion() As String
            Get
                Return _viainsercion
            End Get
        End Property
        Public ReadOnly Property Lateralidad() As String
            Get
                Return _lateralidad
            End Get
        End Property
        Public ReadOnly Property Desc_sitioinsercion() As String
            Get
                Return _desc_sitioinsercion
            End Get
        End Property
        Public ReadOnly Property Desc_tecinsercion() As String
            Get
                Return _desc_tecinsercion
            End Get
        End Property
        Public ReadOnly Property Numpuntuacion() As Integer
            Get
                Return _numpuntuacion
            End Get
        End Property
        Public ReadOnly Property Controlradio() As String
            Get
                Return _controlradio
            End Get
        End Property
        Public ReadOnly Property Localizacion() As String
            Get
                Return _localizacion
            End Get
        End Property
        Public ReadOnly Property Desc_complicacion() As String
            Get
                Return _desc_complicacion
            End Get
        End Property
        Public ReadOnly Property Desc_indicacion() As String
            Get
                Return _desc_indicacion
            End Get
        End Property
#End Region
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal intCod_Historia As Integer, ByVal intConsecutivo As Integer, ByVal strdesc_tipocateter As String, ByVal fdtfecha As DateTime, _
                       ByVal strhora_cateter As String, ByVal strmin_cateter As String, ByVal intcalibre As Decimal, _
                       ByVal strluzcateter As String, ByVal strviainsercion As String, ByVal strlateralidad As String, _
                       ByVal strdesc_sitioinsercion As String, ByVal strdesc_tecinsercion As String, ByVal strnumpuntuacion As String, _
                       ByVal strcontrolradio As String, ByVal strlocalizacion As String, ByVal strdesc_complicacion As String, _
                       ByVal strdesc_indicacion As String)

            _Cod_Historia = intCod_Historia
            _Consecutivo = intConsecutivo
            _desc_tipocateter = strdesc_tipocateter
            _fecha = Format(fdtfecha, "dd/MM/yyyy")
            _hora_cateter = strhora_cateter
            _min_cateter = strmin_cateter
            _calibre = intcalibre
            _luzcateter = strluzcateter
            _viainsercion = strviainsercion
            _lateralidad = strlateralidad
            _desc_sitioinsercion = strdesc_sitioinsercion
            _desc_tecinsercion = strdesc_tecinsercion
            _numpuntuacion = strnumpuntuacion
            _controlradio = strcontrolradio
            _localizacion = strlocalizacion
            _desc_complicacion = strdesc_complicacion
            _desc_indicacion = strdesc_indicacion
        End Sub
        Public Function consultarHemodialisis(ByVal objConexion As Conexion, ByVal dCod_Historia As Integer, ByVal strFechaIni As Nullable(Of Date), ByVal strFechaFin As Nullable(Of Date), ByVal iHoraIni As Nullable(Of Integer), ByVal iHoraFin As Nullable(Of Integer)) As DataTable
            Dim lError As Long = 0
            gpmDataObj.setSQLSentence("HCENF_ReporteHemodialisis", CommandType.StoredProcedure)
            gpmDataObj.addInputParameter("@intCod_Historia", SqlDbType.Int, dCod_Historia)
            gpmDataObj.addInputParameter("@strFechaIni", SqlDbType.DateTime, strFechaIni)
            gpmDataObj.addInputParameter("@strFechaFin", SqlDbType.DateTime, strFechaFin)
            gpmDataObj.addInputParameter("@iHoraIni", SqlDbType.Int, iHoraIni)
            gpmDataObj.addInputParameter("@iHoraFin", SqlDbType.Int, iHoraFin)
            gpmDataObj.addInputParameter("lError", SqlDbType.Int, lError)
            Return gpmDataObj.execDT
        End Function
    End Class
End Namespace
