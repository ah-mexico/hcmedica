Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports System.ComponentModel
Imports System.Collections.Generic

Public Class SignosVitales
#Region "CONST"
    'Public Const HistoriaBasica As String = "HCB"
    'Public Const Evolucion As String = "EVL"
#End Region

#Region "ENUM"
    Public Enum Abreviatura
        <Description("FC")> Frecuencia_Cardiaca
        <Description("FR")> Frecuencia_Respiratoria
        <Description("PAS")> Tensión_Arterial_Sistolica
        <Description("PAD")> Tensión_Arterial_Diastolica
        <Description("TEMP")> Temperatura
        <Description("SPO2")> Saturación_Oxígeno
        <Description("EVA")> Escala_Dolor
    End Enum

    Public Enum OrigenSV
        <Description("HCB")> HistoriaBasica
        <Description("EVL")> Evolucion
    End Enum

#End Region

#Region "PROPERTIES"

    Private _cod_pre_sgs As String
    Private _cod_sucur As String
    Private _tip_doc As String
    Private _Num_doc As String
    Private _tip_admision As String
    Private _ano_adm As Integer
    Private _num_adm As Decimal
    Private _peso As Decimal
    Private _talla As Decimal
    Private _imc As Decimal
    Private _P_Cefalico As Decimal
    Private _ta_dias As Integer
    Private _ta_sist As Integer
    Private _temperatura As Decimal
    Private _fre_cardiaca As Integer
    Private _fre_respira As Integer
    Private _fec_con As DateTime
    Private _login As String
    Private _obs As String
    Private _confidencial As String
    Private _alerta As String
    Private _glasgow As Integer
    Private _embriaguez As String
    Private _P_abdominal As Decimal
    Private _satoxi As Decimal
    Private _EAnaloga_dolor As String
    Private _ORIGEN As String
    Private _IdEspecialidad As String

    Public Property idEspecialidad() As String
        Get
            Return _IdEspecialidad
        End Get
        Set(ByVal Value As String)
            _IdEspecialidad = Value
        End Set
    End Property
    Public Property cod_pre_sgs() As String
        Get
            Return _cod_pre_sgs
        End Get
        Set(ByVal Value As String)
            _cod_pre_sgs = Value
        End Set
    End Property

    Public Property cod_sucur() As String
        Get
            Return _cod_sucur
        End Get
        Set(ByVal Value As String)
            _cod_sucur = Value
        End Set
    End Property

    Public Property tip_doc() As String
        Get
            Return _tip_doc
        End Get
        Set(ByVal Value As String)
            _tip_doc = Value
        End Set
    End Property

    Public Property Num_doc() As String
        Get
            Return _Num_doc
        End Get
        Set(ByVal Value As String)
            _Num_doc = Value
        End Set
    End Property

    Public Property tip_admision() As String
        Get
            Return _tip_admision
        End Get
        Set(ByVal Value As String)
            _tip_admision = Value
        End Set
    End Property

    Public Property ano_adm() As Integer
        Get
            Return _ano_adm
        End Get
        Set(ByVal Value As Integer)
            _ano_adm = Value
        End Set
    End Property

    Public Property num_adm() As Decimal
        Get
            Return _num_adm
        End Get
        Set(ByVal Value As Decimal)
            _num_adm = Value
        End Set
    End Property

    Public Property peso() As Decimal
        Get
            Return _peso
        End Get
        Set(ByVal Value As Decimal)
            _peso = Value
        End Set
    End Property

    Public Property talla() As Decimal
        Get
            Return _talla
        End Get
        Set(ByVal Value As Decimal)
            _talla = Value
        End Set
    End Property

    Public Property imc() As Decimal
        Get
            Return _imc
        End Get
        Set(ByVal Value As Decimal)
            _imc = Value
        End Set
    End Property

    Public Property P_Cefalico() As Decimal
        Get
            Return _P_Cefalico
        End Get
        Set(ByVal Value As Decimal)
            _P_Cefalico = Value
        End Set
    End Property

    Public Property ta_dias() As Integer
        Get
            Return _ta_dias
        End Get
        Set(ByVal Value As Integer)
            _ta_dias = Value
        End Set
    End Property

    Public Property ta_sist() As Integer
        Get
            Return _ta_sist
        End Get
        Set(ByVal Value As Integer)
            _ta_sist = Value
        End Set
    End Property

    Public Property temperatura() As Decimal
        Get
            Return _temperatura
        End Get
        Set(ByVal Value As Decimal)
            _temperatura = Value
        End Set
    End Property

    Public Property fre_cardiaca() As Integer
        Get
            Return _fre_cardiaca
        End Get
        Set(ByVal Value As Integer)
            _fre_cardiaca = Value
        End Set
    End Property

    Public Property fre_respira() As Integer
        Get
            Return _fre_respira
        End Get
        Set(ByVal Value As Integer)
            _fre_respira = Value
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

    Public Property login() As String
        Get
            Return _login
        End Get
        Set(ByVal Value As String)
            _login = Value
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

    Public Property confidencial() As String
        Get
            Return _confidencial
        End Get
        Set(ByVal Value As String)
            _confidencial = Value
        End Set
    End Property

    Public Property alerta() As String
        Get
            Return _alerta
        End Get
        Set(ByVal Value As String)
            _alerta = Value
        End Set
    End Property

    Public Property glasgow() As Integer
        Get
            Return _glasgow
        End Get
        Set(ByVal Value As Integer)
            _glasgow = Value
        End Set
    End Property

    Public Property embriaguez() As String
        Get
            Return _embriaguez
        End Get
        Set(ByVal Value As String)
            _embriaguez = Value
        End Set
    End Property

    Public Property P_abdominal() As Decimal
        Get
            Return _P_abdominal
        End Get
        Set(ByVal Value As Decimal)
            _P_abdominal = Value
        End Set
    End Property

    Public Property satoxi() As Decimal
        Get
            Return _satoxi
        End Get
        Set(ByVal Value As Decimal)
            _satoxi = Value
        End Set
    End Property

    Public Property EAnaloga_dolor() As String
        Get
            Return _EAnaloga_dolor
        End Get
        Set(ByVal Value As String)
            _EAnaloga_dolor = Value
        End Set
    End Property

    Public Property ORIGEN() As String
        Get
            Return _ORIGEN
        End Get
        Set(ByVal Value As String)
            _ORIGEN = Value
        End Set
    End Property
#End Region

#Region "FUNCTIONS"

    Public Function Add_SignosVitales(ByVal oConexion As objCon, ByVal oSignosVitales As SignosVitales) As Long
        Dim oSigVitales As New BLSignosVitales

        Return oSigVitales.addSignosVitales(oConexion, oSignosVitales)

    End Function

    Public Function Get_SignosVitales(ByVal oConexion As objCon, ByRef lError As Long, ByVal oSignosVitales As SignosVitales) As List(Of SignosVitales)
        Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
        Dim Param() As Object

        ReDim Param(5)

        Param(0) = oSignosVitales.cod_pre_sgs
        Param(1) = oSignosVitales.cod_sucur
        Param(2) = oSignosVitales.tip_admision
        Param(3) = oSignosVitales.ano_adm
        Param(4) = oSignosVitales.num_adm
        Param(5) = lError

        Return obj.ConvertDataTableToList(Of SignosVitales)(obj.EjecutarSPConParametros("HC_GET_SIGNOSVITALES", oConexion, lError, Param))

    End Function

#End Region

End Class
