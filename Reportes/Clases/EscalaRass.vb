Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports System.Collections.Generic
Imports System.Data.Common


Namespace Sophia.HistoriaClinica.Reportes
    ''' <summary>
    ''' Clase que encapsula los datos de una nota de evolucion
    ''' </summary>
    ''' <remarks></remarks>
    Public Class EscalaRass
        Inherits GPMDataReport

        'Private _fecha As String                   'Fecha de la evolucion
        'Private _hora As String                    'Hora de la evolucion
        'Private _minuto As String                  'Minuto de la evolucion
        Private _cod_historia As Long               'cod Historia
        Private _consecutivo As Integer
        Private _fecha As String
        Private _escala_rass As String
        Private _medico As String                   'Nombre del medico
        Private _cargo As String                    'Cargo del medico

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
        Public ReadOnly Property Escala_rass() As String
            Get
                Return _escala_rass
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
        ByVal strescala_rass As String, ByVal strMedico As String, ByVal strcargo As String)


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
            _escala_rass = strescala_rass
            _medico = strMedico
            _cargo = strcargo

        End Sub
        ''' <summary>
        ''' Consulta el stored Procedure que devuelve la informacion 
        ''' de una determinada Escala Rass 
        ''' </summary>
        ''' <param name="strcod_pre_sgs">Codigo del prestador</param>
        ''' <param name="strCod_sucur">Codigo de la sucursal</param>
        ''' <param name="strTip_admision">Tipo de Admision</param>
        ''' <param name="iAno_adm">Año de la Admision</param>
        ''' <param name="lNum_adm">Numero de la admision a la que se le hace la nota</param>
        ''' <param name="strCodHistoria">Fecha de realizacion de la nota</param>
        ''' <param name="strLogin">Login que realizo la nota</param>
        ''' <remarks></remarks>
        ''' 
        Public Function consultarEscalaRass(ByVal objConexion As Conexion, ByVal strCodHistoria As Long, ByVal strFechaIni As Nullable(Of Date), ByVal strFechaFin As Nullable(Of Date), ByVal iHoraIni As Nullable(Of Integer), ByVal iHoraFin As Nullable(Of Integer)) As DataTable

            Dim lError As Long = 0

            gpmDataObj.setSQLSentence("HCENF_TraerEscalaRass", CommandType.StoredProcedure)

            gpmDataObj.addInputParameter("codhistoria", SqlDbType.Int, strCodHistoria)
            gpmDataObj.addInputParameter("@strFechaIni", SqlDbType.DateTime, strFechaIni)
            gpmDataObj.addInputParameter("@strFechaFin", SqlDbType.DateTime, strFechaFin)
            gpmDataObj.addInputParameter("@iHoraIni", SqlDbType.Int, iHoraIni)
            gpmDataObj.addInputParameter("@iHoraFin", SqlDbType.Int, iHoraFin)
            gpmDataObj.addOutputParameter("lError", SqlDbType.Int, lError)

            Return gpmDataObj.execDT

        End Function

    End Class
End Namespace
