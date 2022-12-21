Public Class DescripcionQuirurgica

    ''Declaracion de los atributos a manejar en la descripcion quirúrgica
    Private Shared _Instancia As DescripcionQuirurgica
    Private _consecutivo As String
    Private _procedimiento As String
    Private _nroAutorizacion As String
    Private _FecIngresoSala As Date
    Private _HoraIngresoSala As Integer
    Private _MinIngresoSala As Integer
    Private _FecInicio As Date
    Private _HoraInicio As Integer
    Private _MinInicio As Integer
    Private _FecFinalizacion As Date
    Private _HoraFinalizacion As Integer
    Private _MinFinalizacion As Integer
    Private _FecSalida As Date
    Private _HoraSalida As Integer
    Private _MinSalida As Integer
    Private _dtEquipoquirurgico As DataTable ''Personal medico presente en la cirugía
    Private _strAnestesia As String
    Private _dtProfilaxisAnt As DataTable
    Private _dtDiagnPreopera As DataTable
    Private _dtDiagnPostpera As DataTable
    Private _dtIntervencion As DataTable
    Private _strTipoCirugia As String
    Private _strDescrIntervencion As String
    Private _strTejidosPatologia As String
    Private _TiempoHoraQx As Integer
    Private _TiempoMinsQx As Integer
    Private _SangradoEstimado As Integer
    Private _RecuentoMaterial As Integer '' 0 Completo y 1 incompleto
    Private _strHallazgos As String
    Private _strComplicaciones As String
    Private _secuencia As Integer
    'Joseph Moreno (IG) Fec:2019/11/18 Particularidades
    Private _Descripcion As String = ""
    Private _Particularidades As String
    ''' <summary>
    ''' ''''''
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Shared ReadOnly Property Instancia() As DescripcionQuirurgica
        Get
            If _Instancia Is Nothing Then
                _Instancia = New DescripcionQuirurgica
            End If
            Return _Instancia
        End Get
    End Property
    Public Property Consecutivo() As String
        Get
            Return _consecutivo
        End Get
        Set(ByVal Value As String)
            _consecutivo = Value
        End Set
    End Property
    Public Property NroAutorizacion() As String
        Get
            Return _nroAutorizacion
        End Get
        Set(ByVal Value As String)
            _nroAutorizacion = Value
        End Set
    End Property
    Public Property Procedimiento() As String
        Get
            Return _procedimiento
        End Get
        Set(ByVal Value As String)
            _procedimiento = Value
        End Set
    End Property
    Public Property FecIngresoSala() As Date
        Get
            Return _FecIngresoSala
        End Get
        Set(ByVal Value As Date)
            _FecIngresoSala = Value
        End Set
    End Property
    Public Property HoraIngresoSala() As Integer
        Get
            Return _HoraIngresoSala
        End Get
        Set(ByVal Value As Integer)
            _HoraIngresoSala = Value
        End Set
    End Property
    Public Property MinIngresoSala() As Integer
        Get
            Return _MinIngresoSala
        End Get
        Set(ByVal Value As Integer)
            _MinIngresoSala = Value
        End Set
    End Property
    Public Property FecInicio() As Date
        Get
            Return _FecInicio
        End Get
        Set(ByVal Value As Date)
            _FecInicio = Value
        End Set
    End Property
    Public Property HoraInicio() As Integer
        Get
            Return _HoraInicio
        End Get
        Set(ByVal Value As Integer)
            _HoraInicio = Value
        End Set
    End Property
    Public Property MinInicio() As Integer
        Get
            Return _MinInicio
        End Get
        Set(ByVal Value As Integer)
            _MinInicio = Value
        End Set
    End Property
    Public Property FecFinalizacion() As Date
        Get
            Return _FecFinalizacion
        End Get
        Set(ByVal Value As Date)
            _FecFinalizacion = Value
        End Set
    End Property
    Public Property HoraFinalizacion() As Integer
        Get
            Return _HoraFinalizacion
        End Get
        Set(ByVal Value As Integer)
            _HoraFinalizacion = Value
        End Set
    End Property
    Public Property MinFinalizacion() As Integer
        Get
            Return _MinFinalizacion
        End Get
        Set(ByVal Value As Integer)
            _MinFinalizacion = Value
        End Set
    End Property
    Public Property FecSalida() As Date
        Get
            Return _FecSalida
        End Get
        Set(ByVal Value As Date)
            _FecSalida = Value
        End Set
    End Property
    Public Property HoraSalida() As Integer
        Get
            Return _HoraSalida
        End Get
        Set(ByVal Value As Integer)
            _HoraSalida = Value
        End Set
    End Property
    Public Property MinSalida() As Integer
        Get
            Return _MinSalida
        End Get
        Set(ByVal Value As Integer)
            _MinSalida = Value
        End Set
    End Property
    Public Property dtEquipoquirurgico() As DataTable
        Get
            Return _dtEquipoquirurgico
        End Get
        Set(ByVal Value As DataTable)
            _dtEquipoquirurgico = Value
        End Set
    End Property
    Public Property strAnestesia() As String
        Get
            Return _strAnestesia
        End Get
        Set(ByVal Value As String)
            _strAnestesia = Value
        End Set
    End Property
    Public Property dtProfilaxisAnt() As DataTable
        Get
            Return _dtProfilaxisAnt
        End Get
        Set(ByVal Value As DataTable)
            _dtProfilaxisAnt = Value
        End Set
    End Property
    Public Property dtDiagnPreopera() As DataTable
        Get
            Return _dtDiagnPreopera
        End Get
        Set(ByVal Value As DataTable)
            _dtDiagnPreopera = Value
        End Set
    End Property
    Public Property dtDiagnPostpera() As DataTable
        Get
            Return _dtDiagnPostpera
        End Get
        Set(ByVal Value As DataTable)
            _dtDiagnPostpera = Value
        End Set
    End Property
    Public Property dtIntervencion() As DataTable
        Get
            Return _dtIntervencion
        End Get
        Set(ByVal Value As DataTable)
            _dtIntervencion = Value
        End Set
    End Property
    Public Property strTipoCirugia() As String
        Get
            Return _strTipoCirugia
        End Get
        Set(ByVal Value As String)
            _strTipoCirugia = Value
        End Set
    End Property
    Public Property strDescrIntervencion() As String
        Get
            Return _strDescrIntervencion
        End Get
        Set(ByVal Value As String)
            _strDescrIntervencion = Value
        End Set
    End Property
    Public Property strTejidosPatologia() As String
        Get
            Return _strTejidosPatologia
        End Get
        Set(ByVal Value As String)
            _strTejidosPatologia = Value
        End Set
    End Property
    Public Property TiempoHoraQx() As Integer
        Get
            Return _TiempoHoraQx
        End Get
        Set(ByVal Value As Integer)
            _TiempoHoraQx = Value
        End Set
    End Property
    Public Property TiempoMinsQx() As Integer
        Get
            Return _TiempoMinsQx
        End Get
        Set(ByVal Value As Integer)
            _TiempoMinsQx = Value
        End Set
    End Property
    Public Property SangradoEstimado() As Integer
        Get
            Return _SangradoEstimado
        End Get
        Set(ByVal Value As Integer)
            _SangradoEstimado = Value
        End Set
    End Property
    Public Property RecuentoMaterial() As Integer
        Get
            Return _RecuentoMaterial
        End Get
        Set(ByVal Value As Integer)
            _RecuentoMaterial = Value
        End Set
    End Property
    Public Property strHallazgos() As String
        Get
            Return _strHallazgos
        End Get
        Set(ByVal Value As String)
            _strHallazgos = Value
        End Set
    End Property
    Public Property strComplicaciones() As String
        Get
            Return _strComplicaciones
        End Get
        Set(ByVal Value As String)
            _strComplicaciones = Value
        End Set
    End Property
    Public Property Secuencia() As Integer
        Get
            Return _secuencia
        End Get
        Set(ByVal Value As Integer)
            _secuencia = Value
        End Set
    End Property

    Public Sub Limpiar()
        _consecutivo = String.Empty
        _procedimiento = String.Empty
        _nroAutorizacion = String.Empty
        _HoraIngresoSala = 0
        _MinIngresoSala = 0
        _HoraInicio = 0
        _MinInicio = 0
        _HoraFinalizacion = 0
        _MinFinalizacion = 0
        _HoraSalida = 0
        _MinSalida = 0
        _dtEquipoquirurgico = Nothing ''Personal medico presente en la cirugía
        _strAnestesia = String.Empty
        _dtProfilaxisAnt = Nothing
        _dtDiagnPreopera = Nothing
        _dtDiagnPostpera = Nothing
        _dtIntervencion = Nothing
        _strTipoCirugia = String.Empty
        _strDescrIntervencion = String.Empty
        _strTejidosPatologia = String.Empty
        _TiempoHoraQx = 0
        _TiempoMinsQx = 0
        _SangradoEstimado = 0
        _RecuentoMaterial = 0 '' 0 Completo y 1 incompleto
        _strHallazgos = String.Empty
        _strComplicaciones = String.Empty
        _secuencia = 0
        'Joseph Moreno (IG) Fec: 2019/11/18 Particularidades
        _Descripcion = ""
        _Particularidades = ""
    End Sub

    'Joseph Moreno (IG) Fec: 2019/11/18 Particularidades
    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal Value As String)
            _Descripcion = Value
        End Set
    End Property
    Public Property Particularidades() As String
        Get
            Return _Particularidades
        End Get
        Set(ByVal Value As String)
            _Particularidades = Value
        End Set
    End Property
End Class
