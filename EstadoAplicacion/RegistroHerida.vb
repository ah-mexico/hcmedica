Public Class RegistroHerida

#Region "Properties"

    Private Shared _Instancia As RegistroHerida
    Private _cod_pre_sgs As String
    Private _cod_sucur As String
    Private _tip_admision As String
    Private _ano_adm As Integer
    Private _num_adm As Decimal
    Private _Tip_Doc As String
    Private _Num_Doc As String
    Private _Loc_Herida As String
    Private _Tip_Herida As String
    Private _Long_Herida As String
    Private _Tunelizacion As String
    Private _Ubi_Tunelizacion As String
    Private _Prof_Tunelizacion As String
    Private _Fistula As String
    Private _Ubi_Fistula As String
    Private _Prof_Fistula As String
    Private _Tejido_Comprometido As String
    Private _Grado As Integer
    Private _Nec_Seco As String
    Private _Nec_Humedo As String
    Private _Fibrina As String
    Private _Epitelizacion As String
    Private _Granulacion As String
    Private _Exudado As Integer
    Private _Car_Exudado As Integer
    Private _Signo_Infeccion As String
    Private _Piel_Circundante As String
    Private _Estado_Bordes As String
    Private _Tiene_Desbridamiento As String
    Private _Tipo_Desbridamiento As String
    Private _Justif_No_Desbridamiento As String
    Private _Protocolo As String
    Private _Frec_Curacion As Integer
    Private _Obs_Herida As String
    Private _Fec_Con As DateTime
    Private _Obs As String
    Private _Login As String

    Public Shared ReadOnly Property Instancia() As RegistroHerida
        Get
            If _Instancia Is Nothing Then
                _Instancia = New RegistroHerida
            End If
            Return _Instancia
        End Get
    End Property

    Public Property Cod_pre_sgs() As String
        Get
            Return _cod_pre_sgs
        End Get
        Set(ByVal Value As String)
            _cod_pre_sgs = Value
        End Set
    End Property

    Public Property Cod_sucur() As String
        Get
            Return _cod_sucur
        End Get
        Set(ByVal Value As String)
            _cod_sucur = Value
        End Set
    End Property

    Public Property Tip_admision() As String
        Get
            Return _tip_admision
        End Get
        Set(ByVal Value As String)
            _tip_admision = Value
        End Set
    End Property

    Public Property Ano_adm() As Integer
        Get
            Return _ano_adm
        End Get
        Set(ByVal Value As Integer)
            _ano_adm = Value
        End Set
    End Property

    Public Property Num_adm() As Decimal
        Get
            Return _num_adm
        End Get
        Set(ByVal Value As Decimal)
            _num_adm = Value
        End Set
    End Property

    Public Property Tip_Doc() As String
        Get
            Return _Tip_Doc
        End Get
        Set(ByVal Value As String)
            _Tip_Doc = Value
        End Set
    End Property

    Public Property Num_Doc() As String
        Get
            Return _Num_Doc
        End Get
        Set(ByVal Value As String)
            _Num_Doc = Value
        End Set
    End Property

    Public Property Loc_Herida() As String
        Get
            Return _Loc_Herida
        End Get
        Set(ByVal Value As String)
            _Loc_Herida = Value
        End Set
    End Property

    Public Property Tip_Herida() As String
        Get
            Return _Tip_Herida
        End Get
        Set(ByVal Value As String)
            _Tip_Herida = Value
        End Set
    End Property

    Public Property Long_Herida() As String
        Get
            Return _Long_Herida
        End Get
        Set(ByVal Value As String)
            _Long_Herida = Value
        End Set
    End Property

    Public Property Tunelizacion() As String
        Get
            Return _Tunelizacion
        End Get
        Set(ByVal Value As String)
            _Tunelizacion = Value
        End Set
    End Property

    Public Property Ubi_Tunelizacion() As String
        Get
            Return _Ubi_Tunelizacion
        End Get
        Set(ByVal Value As String)
            _Ubi_Tunelizacion = Value
        End Set
    End Property

    Public Property Prof_Tunelizacion() As String
        Get
            Return _Prof_Tunelizacion
        End Get
        Set(ByVal Value As String)
            _Prof_Tunelizacion = Value
        End Set
    End Property

    Public Property Fistula() As String
        Get
            Return _Fistula
        End Get
        Set(ByVal Value As String)
            _Fistula = Value
        End Set
    End Property

    Public Property Ubi_Fistula() As String
        Get
            Return _Ubi_Fistula
        End Get
        Set(ByVal Value As String)
            _Ubi_Fistula = Value
        End Set
    End Property

    Public Property Prof_Fistula() As String
        Get
            Return _Prof_Fistula
        End Get
        Set(ByVal Value As String)
            _Prof_Fistula = Value
        End Set
    End Property

    Public Property Tejido_Comprometido() As String
        Get
            Return _Tejido_Comprometido
        End Get
        Set(ByVal Value As String)
            _Tejido_Comprometido = Value
        End Set
    End Property

    Public Property Grado() As Integer
        Get
            Return _Grado
        End Get
        Set(ByVal Value As Integer)
            _Grado = Value
        End Set
    End Property

    Public Property Nec_Seco() As String
        Get
            Return _Nec_Seco
        End Get
        Set(ByVal Value As String)
            _Nec_Seco = Value
        End Set
    End Property

    Public Property Nec_Humedo() As String
        Get
            Return _Nec_Humedo
        End Get
        Set(ByVal Value As String)
            _Nec_Humedo = Value
        End Set
    End Property

    Public Property Fibrina() As String
        Get
            Return _Fibrina
        End Get
        Set(ByVal Value As String)
            _Fibrina = Value
        End Set
    End Property

    Public Property Epitelizacion() As String
        Get
            Return _Epitelizacion
        End Get
        Set(ByVal Value As String)
            _Epitelizacion = Value
        End Set
    End Property

    Public Property Granulacion() As String
        Get
            Return _Granulacion
        End Get
        Set(ByVal Value As String)
            _Granulacion = Value
        End Set
    End Property

    Public Property Exudado() As Integer
        Get
            Return _Exudado
        End Get
        Set(ByVal Value As Integer)
            _Exudado = Value
        End Set
    End Property

    Public Property Car_Exudado() As Integer
        Get
            Return _Car_Exudado
        End Get
        Set(ByVal Value As Integer)
            _Car_Exudado = Value
        End Set
    End Property

    Public Property Signo_Infeccion() As String
        Get
            Return _Signo_Infeccion
        End Get
        Set(ByVal Value As String)
            _Signo_Infeccion = Value
        End Set
    End Property

    Public Property Piel_Circundante() As String
        Get
            Return _Piel_Circundante
        End Get
        Set(ByVal Value As String)
            _Piel_Circundante = Value
        End Set
    End Property

    Public Property Estado_Bordes() As String
        Get
            Return _Estado_Bordes
        End Get
        Set(ByVal Value As String)
            _Estado_Bordes = Value
        End Set
    End Property

    Public Property Tiene_Desbridamiento() As String
        Get
            Return _Tiene_Desbridamiento
        End Get
        Set(ByVal Value As String)
            _Tiene_Desbridamiento = Value
        End Set
    End Property

    Public Property Tipo_Desbridamiento() As String
        Get
            Return _Tipo_Desbridamiento
        End Get
        Set(ByVal Value As String)
            _Tipo_Desbridamiento = Value
        End Set
    End Property

    Public Property Justif_No_Desbridamiento() As String
        Get
            Return _Justif_No_Desbridamiento
        End Get
        Set(ByVal Value As String)
            _Justif_No_Desbridamiento = Value
        End Set
    End Property

    Public Property Protocolo() As String
        Get
            Return _Protocolo
        End Get
        Set(ByVal Value As String)
            _Protocolo = Value
        End Set
    End Property

    Public Property Frec_Curacion() As Integer
        Get
            Return _Frec_Curacion
        End Get
        Set(ByVal Value As Integer)
            _Frec_Curacion = Value
        End Set
    End Property

    Public Property Obs_Herida() As String
        Get
            Return _Obs_Herida
        End Get
        Set(ByVal Value As String)
            _Obs_Herida = Value
        End Set
    End Property

    Public Property Fec_Con() As DateTime
        Get
            Return _Fec_Con
        End Get
        Set(ByVal Value As DateTime)
            _Fec_Con = Value
        End Set
    End Property

    Public Property Obs() As String
        Get
            Return _Obs
        End Get
        Set(ByVal Value As String)
            _Obs = Value
        End Set
    End Property

    Public Property Login() As String
        Get
            Return _Login
        End Get
        Set(ByVal Value As String)
            _Login = Value
        End Set
    End Property


#End Region


#Region "Functions"

#End Region



End Class
