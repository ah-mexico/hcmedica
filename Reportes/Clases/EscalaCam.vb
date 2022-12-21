Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports System.Collections.Generic
Imports System.Data.Common


Namespace Sophia.HistoriaClinica.Reportes
    ''' <summary>
    ''' Clase que encapsula los datos de una nota de evolucion
    ''' </summary>
    ''' <remarks></remarks>
    Public Class EscalaCam
        Inherits GPMDataReport

        'Private _fecha As String                   'Fecha 
        'Private _hora As String                    'Hora 
        'Private _minuto As String                  'Minuto
        Private _cod_historia As Long               'Cod Historia
        Private _consecutivo As Integer
        Private _fecha As String
        Private _camIcu As String
        'Private _camIcu2 As String
        Private _medico As String                   'Nombre del medico
        Private _cargo As String                    'Cargo del Medico

#Region "Propiedades"

        'Public ReadOnly Property Hora() As String
        '    Get
        '        Return _hora
        '    End Get
        'End Property
        'Public ReadOnly Property Minuto() As String
        '    Get
        '        Return _minuto
        '    End Get
        'End Property

        Public ReadOnly Property Cod_historia() As Long
            Get
                Return _cod_historia
            End Get
        End Property
        Public ReadOnly Property Consecutivo() As Integer
            Get
                Return _consecutivo
            End Get
        End Property
        Public ReadOnly Property Fecha() As String
            Get
                Return _fecha
            End Get
        End Property
        Public ReadOnly Property CamIcu() As String
            Get
                Return _camIcu
            End Get
        End Property
        Public ReadOnly Property Medico() As String
            Get
                Return _medico
            End Get
        End Property
        Public ReadOnly Property Cargo() As String
            Get
                Return _cargo
            End Get
        End Property
#End Region

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal strcod_historia As Long, ByVal strconsecutivo As Integer, ByVal strfecha As String, _
        ByVal strcamIcu As String, ByVal strMedico As String, ByVal strcargo As String)


            'Dim fecha As Date

            'If strfecha.Length > 0 Then
            '    fecha = strfecha
            '    _fecha = Format(fecha, "dd/MMMM/yyyy")
            'Else
            '    _fecha = ""
            'End If

            _cod_historia = strcod_historia
            _consecutivo = strconsecutivo
            _fecha = strfecha
            _camIcu = strcamIcu
            '_camIcu2 = strcamIcu2
            _medico = strMedico
            _cargo = strcargo

        End Sub
        ''' <summary>
        ''' Consulta el stored Procedure que devuelve la informacion 
        ''' de una determinada Escala Cam-Icu 
        ''' </summary>
        ''' <param name="strcod_pre_sgs">Codigo del prestador</param>
        ''' <param name="strCod_sucur">Codigo de la sucursal</param>
        ''' <param name="strTip_admision">Tipo de Admision</param>
        ''' <param name="iAno_adm">Año de la Admision</param>
        ''' <param name="lNum_adm">Numero de la admision a la que se le hace la nota</param>
        ''' <param name="strCodHistoria">Numero de la Historia</param>
        ''' <param name="strLogin">Login que realizo la Escala</param>
        ''' <remarks></remarks>
        ''' 
        Public Function consultarEscalaCam(ByVal objConexion As Conexion, ByVal strCodHistoria As Long, ByVal strFechaIni As Nullable(Of Date), ByVal strFechaFin As Nullable(Of Date), ByVal iHoraIni As Nullable(Of Integer), ByVal iHoraFin As Nullable(Of Integer)) As DataTable

            gpmDataObj.setSQLSentence("HCENF_TraerCamIcu", CommandType.StoredProcedure)

            gpmDataObj.addInputParameter("codhistoria", SqlDbType.Int, strCodHistoria)
            gpmDataObj.addInputParameter("@strFechaIni", SqlDbType.DateTime, strFechaIni)
            gpmDataObj.addInputParameter("@strFechaFin", SqlDbType.DateTime, strFechaFin)
            gpmDataObj.addInputParameter("@iHoraIni", SqlDbType.Int, iHoraIni)
            gpmDataObj.addInputParameter("@iHoraFin", SqlDbType.Int, iHoraFin)
            gpmDataObj.addInputParameter("lError", SqlDbType.Int, 0)

            Return gpmDataObj.execDT
        End Function

    End Class
End Namespace
