Public Class RegistroCateter

#Region "Properties"

    Private Shared _Instancia As RegistroCateter
    Private _cod_pre_sgs As String
    Private _cod_sucur As String
    Private _tip_admision As String
    Private _ano_adm As Integer
    Private _num_adm As Long
    Private _Tip_Doc As String
    Private _Num_Doc As String
    Private _Tip_Registro As String
    Private _Fec_Insercion As String
    Private _Tip_Cateter As Integer
    Private _Dias_Cateter As Integer
    Private _Sitio_Insercion As String ''zona insercion
    Private _Calibre As String
    Private _Lateralidad As Integer
    Private _NroPunciones As Integer
    Private _Indicaciones As String
    Private _Complicaciones As String
    Private _Seguimientodelcateter As String
    Private _Fec_Curacion As String
    Private _Tip_Cateter_Gestionar As String ''***tipo de cateter a gestionar
    Private _SignosPresentados As String ''estado Estado sitio de inserción, esta relacionado con los signos presentados
    Private _RealizoCuracion As String
    Private _ElementosCuracion As String
    Private _Fec_Retiro As String ''***
    Private _MotivoRetiro As Integer
    Private _Fec_Con As DateTime
    Private _Obs As String
    Private _Login As String
    Private _Especialidad As String
    Private _LoginMedico As String
    Private _Severifica As String 'Santiago Balcero  Nueva Pregunta
    Private _GestionFinal As String 'Santiago Balcero  Nueva Pregunta
    Private _MRetiro As String 'Santiago Balcero  Nueva Pregunta
    Private _CodCateter As String 'Santiago Balcero  Nuevo campo
    Private _Es_Sophia As String ''Para Determinar si registro procede de Sophia o Avicena

    Public Shared ReadOnly Property Instancia() As RegistroCateter
        Get
            If _Instancia Is Nothing Then
                _Instancia = New RegistroCateter
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

    Public Property Num_adm() As Long
        Get
            Return _num_adm
        End Get
        Set(ByVal Value As Long)
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

    Public Property Tip_Registro() As String
        Get
            Return _Tip_Registro
        End Get
        Set(ByVal Value As String)
            _Tip_Registro = Value
        End Set
    End Property

    Public Property Tip_Cateter() As Integer
        Get
            Return _Tip_Cateter
        End Get
        Set(ByVal Value As Integer)
            _Tip_Cateter = Value
        End Set
    End Property

    Public Property Fec_Insercion() As String
        Get
            Return _Fec_Insercion
        End Get
        Set(ByVal Value As String)
            _Fec_Insercion = Value
        End Set
    End Property

    Public Property Sitio_Insercion() As String
        Get
            Return _Sitio_Insercion
        End Get
        Set(ByVal Value As String)
            _Sitio_Insercion = Value
        End Set
    End Property

    Public Property Calibre() As String
        Get
            Return _Calibre
        End Get
        Set(ByVal Value As String)
            _Calibre = Value
        End Set
    End Property

    Public Property Lateralidad() As Integer
        Get
            Return _Lateralidad
        End Get
        Set(ByVal Value As Integer)
            _Lateralidad = Value
        End Set
    End Property

    Public Property NroPunciones() As Integer
        Get
            Return _NroPunciones
        End Get
        Set(ByVal Value As Integer)
            _NroPunciones = Value
        End Set
    End Property

    Public Property Indicaciones() As String
        Get
            Return _Indicaciones
        End Get
        Set(ByVal Value As String)
            _Indicaciones = Value
        End Set
    End Property

    Public Property Complicaciones() As String
        Get
            Return _Complicaciones
        End Get
        Set(ByVal Value As String)
            _Complicaciones = Value
        End Set
    End Property

    Public Property Seguimiento_del_cateter() As String
        Get
            Return _Seguimientodelcateter
        End Get
        Set(ByVal Value As String)
            _Seguimientodelcateter = Value
        End Set
    End Property

    Public Property Fec_Curacion() As String
        Get
            Return _Fec_Curacion
        End Get
        Set(ByVal Value As String)
            _Fec_Curacion = Value
        End Set
    End Property

    Public Property Tip_Cateter_Gestionar() As String
        Get
            Return _Tip_Cateter_Gestionar
        End Get
        Set(ByVal Value As String)
            _Tip_Cateter_Gestionar = Value
        End Set
    End Property


    Public Property SignosPresentados() As String
        Get
            Return _SignosPresentados
        End Get
        Set(ByVal Value As String)
            _SignosPresentados = Value
        End Set
    End Property

    Public Property RealizoCuracion() As String
        Get
            Return _RealizoCuracion
        End Get
        Set(ByVal Value As String)
            _RealizoCuracion = Value
        End Set
    End Property

    Public Property ElementosCuracion() As String
        Get
            Return _ElementosCuracion
        End Get
        Set(ByVal Value As String)
            _ElementosCuracion = Value
        End Set
    End Property

    Public Property Fec_Retiro() As String
        Get
            Return _Fec_Retiro
        End Get
        Set(ByVal Value As String)
            _Fec_Retiro = Value
        End Set
    End Property

    Public Property MotivoRetiro() As Integer
        Get
            Return _MotivoRetiro
        End Get
        Set(ByVal Value As Integer)
            _MotivoRetiro = Value
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
    Public Property Especialidad() As String
        Get
            Return _Especialidad
        End Get
        Set(ByVal Value As String)
            _Especialidad = Value
        End Set
    End Property
    Public Property LoginMedico() As String
        Get
            Return _LoginMedico
        End Get
        Set(ByVal Value As String)
            _LoginMedico = Value
        End Set
    End Property
    'Santiago_Balcero Nuevo Campo
    Public Property Dias_Cateter() As Integer
        Get
            Return _Dias_Cateter
        End Get
        Set(ByVal Value As Integer)
            _Dias_Cateter = Value
        End Set
    End Property
    'Santiago Balcero Nueva Pregunta
    Public Property SeVerifica() As String
        Get
            Return _Severifica
        End Get
        Set(ByVal Value As String)
            _Severifica = Value
        End Set
    End Property
    'Santiago Balcero Nueva Pregunta
    Public Property GestionFinal() As String
        Get
            Return _GestionFinal
        End Get
        Set(ByVal Value As String)
            _GestionFinal = Value
        End Set
    End Property

    'Santiago Balcero--Nuevo campo
    Public Property MRetiro() As String
        Get
            Return _MRetiro
        End Get
        Set(ByVal Value As String)
            _MRetiro = Value
        End Set
    End Property

    'Santiago Balcero Nueva Pregunta
    Public Property CodCateter() As String
        Get
            Return _CodCateter
        End Get
        Set(ByVal Value As String)
            _CodCateter = Value
        End Set
    End Property
    ''Determinar si un regisrtro es de Sophia o Avicena
    Public Property EsSophia() As String
        Get
            Return _Es_Sophia
        End Get
        Set(ByVal Value As String)
            _Es_Sophia = Value
        End Set
    End Property

#End Region

End Class
