Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports System.Collections.Generic
Imports HistoriaClinica.Sophia.HistoriaClinica.Util
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports System.Data.Common


Namespace Sophia.HistoriaClinica.Reportes
    ''' <summary>
    ''' Clase que encapsula los datos de una escala Riesgo
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Alarma
        Inherits GPMDataReport
        Private general As Generales
        Private _cod_historia As String
        Private _consecutivo As Integer
        Private _fec_con As String
        Private _login As String
        'Private _cod_riesgo As Integer
        Private _RIESGOCAIDA As String
        Private _RIESGOFUGA As String
        Private _ALERGICO As String
        Private _ANTICOAGULADO As String
        Private _ALERTAMEDICA As String
        Private _QUIRURGICO As String

        Private _estado As String
        Private _descripcion As String
        ''Private _hora As Integer
        'Private _minuto As Integer
        Private _AlarmasPac As List(Of Alarma)

#Region "Propiedades"

        Public Property CodHistoria() As String
            Get
                Return _cod_historia
            End Get
            Set(ByVal value As String)
                _cod_historia = value
            End Set
        End Property
        Public Property Consecutivo() As Integer
            Get
                Return _consecutivo
            End Get
            Set(ByVal value As Integer)
                _consecutivo = value
            End Set
        End Property
        Public Property Fecha() As String
            Get
                Return _fec_con
            End Get
            Set(ByVal value As String)
                _fec_con = value
            End Set
        End Property
        Public Property Login() As String
            Get
                Return _login
            End Get
            Set(ByVal value As String)
                _login = value
            End Set
        End Property
        'Public Property CodRiesgo() As Integer
        '    Get
        '        Return _cod_riesgo
        '    End Get
        '    Set(ByVal value As Integer)
        '        _cod_riesgo = value
        '    End Set
        'End Property
        Public Property RIESGOCAIDA() As String
            Get
                Return _RIESGOCAIDA
            End Get
            Set(ByVal value As String)
                _RIESGOCAIDA = value
            End Set
        End Property
        Public Property RIESGOFUGA() As String
            Get
                Return _RIESGOFUGA
            End Get
            Set(ByVal value As String)
                _RIESGOFUGA = value
            End Set
        End Property
        Public Property ALERGICO() As String
            Get
                Return _ALERGICO
            End Get
            Set(ByVal value As String)
                _ALERGICO = value
            End Set
        End Property
        Public Property ANTICOAGULADO() As String
            Get
                Return _ANTICOAGULADO
            End Get
            Set(ByVal value As String)
                _ANTICOAGULADO = value
            End Set
        End Property
        Public Property ALERTAMEDICA() As String
            Get
                Return _ALERTAMEDICA
            End Get
            Set(ByVal value As String)
                _ALERTAMEDICA = value
            End Set
        End Property
        Public Property QUIRURGICO() As String
            Get
                Return _QUIRURGICO
            End Get
            Set(ByVal value As String)
                _QUIRURGICO = value
            End Set
        End Property
        Public Property Estado() As String
            Get
                Return _estado
            End Get
            Set(ByVal value As String)
                _estado = value
            End Set
        End Property
        'Public Property Descripcion() As String
        '    Get
        '        Return _descripcion
        '    End Get
        '    Set(ByVal value As String)
        '        _descripcion = value
        '    End Set
        'End Property
        Public Property AlarmasPac() As List(Of Alarma)
            Get
                Return _AlarmasPac
            End Get
            Set(ByVal Value As List(Of Alarma))
                _AlarmasPac = Value
            End Set
        End Property
        'Public Property Minuto() As Integer
        '    Get
        '        Return _minuto
        '    End Get
        '    Set(ByVal value As Integer)
        '        _minuto = value
        '    End Set
        'End Property
        'Public Property Hora() As Integer
        '    Get
        '        Return _hora
        '    End Get
        '    Set(ByVal value As Integer)
        '        _hora = value
        '    End Set
        'End Property

#End Region



        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal fecha As String, ByVal riesgocaida As String, _
                   ByVal riesgofuga As String, ByVal alergico As String, _
                   ByVal anticoagulado As String, ByVal alertamedica As String, _
                   ByVal quirurgico As String)

            _fec_con = fecha
            _RIESGOCAIDA = riesgocaida
            _RIESGOFUGA = riesgofuga
            _ALERGICO = alergico
            _ANTICOAGULADO = anticoagulado
            _ALERTAMEDICA = alertamedica
            _QUIRURGICO = quirurgico

        End Sub


        ''' <summary>
        ''' Consulta el stored Procedure que devuelve la informacion 
        ''' de una determinada escala de Riesgo 
        ''' </summary>
        ''' <param name="strcod_pre_sgs">Codigo del prestador</param>
        ''' <param name="strCod_sucur">Codigo de la sucursal</param>
        ''' <param name="strTip_admision">Tipo de Admision</param>
        ''' <param name="iAno_adm">Año de la Admision</param>
        ''' <param name="lNum_adm">Numero de la admision a la que se le hace la nota</param>C:\FuentesClaudia\Fuentes\HCSophia\Enfermeria\Fuentes\Reportes\Clases\EscalaRiesgo.vb
        ''' <param name="strCodHistoria">Codigo de la Historia</param>
        ''' <param name="strLogin">Login que realizo la nota</param>
        ''' <remarks></remarks>
        ''' 
        Public Function consultarHistoricoAlarmas(ByVal objConexion As Conexion, ByVal cod_historia As Integer, ByVal strFechaIni As Nullable(Of Date), ByVal strFechaFin As Nullable(Of Date), ByVal iHoraIni As Nullable(Of Integer), ByVal iHoraFin As Nullable(Of Integer)) As DataTable

            Dim lError As Long = 0

            'general = Generales.Instancia
            gpmDataObj.setSQLSentence("HCENF_ConsultaHistoricoAlarmasXPacRep", CommandType.StoredProcedure)
            gpmDataObj.addInputParameter("@intCodhistoria", SqlDbType.Int, cod_historia)
            gpmDataObj.addInputParameter("@strFechaIni", SqlDbType.DateTime, strFechaIni)
            gpmDataObj.addInputParameter("@strFechaFin", SqlDbType.DateTime, strFechaFin)
            gpmDataObj.addInputParameter("@iHoraIni", SqlDbType.Int, iHoraIni)
            gpmDataObj.addInputParameter("@iHoraFin", SqlDbType.Int, iHoraFin)
            gpmDataObj.addOutputParameter("@lError", SqlDbType.Int, lError)

            Return gpmDataObj.execDT

        End Function



        Public Function crearListaAlarma(ByVal objConexion As Conexion, ByVal cod_historia As Integer, ByVal strFechaIni As Nullable(Of Date), ByVal strFechaFin As Nullable(Of Date), ByVal iHoraIni As Nullable(Of Integer), ByVal iHoraFin As Nullable(Of Integer)) As List(Of Alarma)

            Dim objAlarma As Alarma
            Dim drDatos As IDataReader
            Dim listaAlarma As New List(Of Alarma)
            Dim lError As Long = 0
            Dim i As Integer = 0



            gpmDataObj.setSQLSentence("HCENF_ConsultaHistoricoAlarmasXPacRep", CommandType.StoredProcedure)
            gpmDataObj.addInputParameter("@intCodhistoria", SqlDbType.Int, cod_historia)
            gpmDataObj.addInputParameter("@strFechaIni", SqlDbType.DateTime, strFechaIni)
            gpmDataObj.addInputParameter("@strFechaFin", SqlDbType.DateTime, strFechaFin)
            gpmDataObj.addInputParameter("@iHoraIni", SqlDbType.Int, iHoraIni)
            gpmDataObj.addInputParameter("@iHoraFin", SqlDbType.Int, iHoraFin)
            gpmDataObj.addOutputParameter("@lError", SqlDbType.Int, lError)


            drDatos = gpmDataObj.ExecRdr()

            While drDatos.Read()
                If i = 0 Then
                    objAlarma = New Alarma(drDatos("fecha").ToString, drDatos("riesgocaida").ToString, _
                                           drDatos("riesgofuga").ToString, drDatos("alergico").ToString, _
                                           drDatos("anticoagulado").ToString, drDatos("alertamedica").ToString, drDatos("quirurgico").ToString)

                    listaAlarma.Add(objAlarma)
                    i = i + 1
                End If
            End While

            If drDatos.IsClosed = False Then
                drDatos.Close()
            End If


            Return listaAlarma
        End Function



    End Class
End Namespace
