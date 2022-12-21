Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports System.Collections.Generic

Namespace Sophia.HistoriaClinica.Reportes
    Public Class Toxico
        Inherits Antecedente

        Private _clase As String
        Public Property Clase() As String
            Get
                Return _clase
            End Get
            Set(ByVal Value As String)
                _clase = Value
            End Set
        End Property

        Private _toxico As String
        Public Property toxico() As String
            Get
                Return _toxico
            End Get
            Set(ByVal Value As String)
                _toxico = Value
            End Set
        End Property

        Private _consumo As String
        Public Property Consumo() As String
            Get
                Return _consumo
            End Get
            Set(ByVal Value As String)
                _consumo = Value
            End Set
        End Property

        Private _frecuencia As String
        Public Property frecuencia() As String
            Get
                Return _frecuencia
            End Get
            Set(ByVal Value As String)
                _frecuencia = Value
            End Set
        End Property

        Private _tiempoConsumo As Integer
        Public Property TiempoConsumo() As Integer
            Get
                Return _tiempoConsumo
            End Get
            Set(ByVal Value As Integer)
                _tiempoConsumo = Value
            End Set
        End Property

        Private _unidadMedidaConsumido As String
        Public Property UnidadMedidaConsumido() As String
            Get
                Return _unidadMedidaConsumido
            End Get
            Set(ByVal Value As String)
                _unidadMedidaConsumido = Value
            End Set
        End Property

        Private _tiempoNoConsumo As Integer
        Public Property TiempoNoConsumo() As Integer
            Get
                Return _tiempoNoConsumo
            End Get
            Set(ByVal Value As Integer)
                _tiempoNoConsumo = Value
            End Set
        End Property

        Private _unidadMedidaNoConsumido As String
        Public Property UnidadMedidaNoConsumido() As String
            Get
                Return _unidadMedidaNoConsumido
            End Get
            Set(ByVal Value As String)
                _unidadMedidaNoConsumido = Value
            End Set
        End Property

        ''' <summary>
        ''' constructor por defecto de la clase.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal strClase As String, ByVal strToxico As String, _
                    ByVal strConsumo As String, ByVal strFrecuencia As String, _
                    ByVal tConsumo As Integer, ByVal unidadConsumido As String, _
                    ByVal tNoConsumo As Integer, ByVal unidadNoConsumido As String, _
                    ByVal obs As String)

            _clase = strClase
            _toxico = strToxico
            _consumo = strConsumo
            _frecuencia = strFrecuencia
            _tiempoConsumo = tConsumo
            _unidadMedidaConsumido = unidadConsumido
            _tiempoNoConsumo = tNoConsumo
            _unidadMedidaNoConsumido = unidadNoConsumido
            Observaciones = obs
        End Sub
        Public Sub New(ByVal strAntecedente As String)

            Antecedente = strAntecedente
        End Sub

        Public Function consultarAntToxicos(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String,
                   ByVal strCod_sucur As String, ByVal strTipDoc As String,
                   ByVal strNumDoc As String, ByVal strLogin As String,
                   ByVal fechaHistoria As String, ByVal strTip_admision As String, ByVal lano_adm As String,
                   ByVal dnum_adm As String, Optional ByVal fec_ini As String = "",
                   Optional ByVal fec_fin As String = "", Optional ByVal AntHst As Boolean = True) As List(Of Toxico)


            Dim antToxico As Toxico
            Dim drDatos As IDataReader
            Dim listaToxicos As New List(Of Toxico)

            gpmDataObj.setSQLSentence("HC_RPT_ANTECEDENTESTOXICOS", CommandType.StoredProcedure)

            gpmDataObj.addInputParameter("TIPDOC", SqlDbType.VarChar, strTipDoc)
            gpmDataObj.addInputParameter("NUMDOC", SqlDbType.VarChar, strNumDoc)
            gpmDataObj.addInputParameter("ANTECEDENTES_HST", SqlDbType.Bit, AntHst)

            If fec_fin <> "" Or fec_fin <> "" Then
                gpmDataObj.addInputParameter("FEC_INI", SqlDbType.DateTime, fec_ini)
                gpmDataObj.addInputParameter("FEC_FIN", SqlDbType.DateTime, fec_fin)
            Else
                gpmDataObj.addInputParameter("FEC_INI", SqlDbType.DateTime, Nothing)
                gpmDataObj.addInputParameter("FEC_FIN", SqlDbType.DateTime, Nothing)
            End If

            drDatos = gpmDataObj.ExecRdr()

            While drDatos.Read()

                antToxico = New Toxico(drDatos("ANTECEDENTE").ToString)
                antToxico.NombreMedico = drDatos("PROFESIONAL").ToString
                antToxico.Fecha = drDatos("FECHA").ToString
                listaToxicos.Add(antToxico)

            End While

            If drDatos.IsClosed = False Then
                drDatos.Close()
            End If

            Return listaToxicos
        End Function
    End Class
End Namespace

