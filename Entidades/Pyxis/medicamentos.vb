Public Class medicamentos
    ' Private Property _atc() As String
    'Private Property _cod_barras() As String
    Private Property _numero_Orden_Detalle() As String
    Private Property _codigo_Articulo() As String
    Private Property _descripcion_Articulo() As String
    Private Property _via_Administracion() As String
    Private Property _frecuencia() As String
    Private Property _dosis() As String
    Private Property _unidad_Dosis() As String
    Private Property _estado_Procesamiento_Detalle() As String
    Private Property _horas_De_Toma() As String
    Private Property _fecha_Hora_Inicio() As String
    Private Property _fecha_Hora_Termino() As String

    'Private Property _sec_Prescripciones() As String
    'Private Property _volumen() As String
    'Private Property _unidad_De_Volumen() As String
    ' Private Property _estado_ebs() As String
    'Private Property _acción_detalle() As String
    Private Property _observacion() As String



    Public Property numero_Orden_Detalle() As String
        Get
            Return _numero_Orden_Detalle
        End Get
        Friend Set(ByVal value As String)
            _numero_Orden_Detalle = value
        End Set
    End Property
    Public Property codigo_Articulo() As String
        Get
            Return _codigo_Articulo
        End Get
        Friend Set(ByVal value As String)
            _codigo_Articulo = value
        End Set
    End Property

    Public Property descripcion_Articulo() As String
        Get
            Return _descripcion_Articulo()
        End Get
        Friend Set(ByVal value As String)
            _descripcion_Articulo() = value
        End Set
    End Property
    Public Property via_Administracion() As String
        Get
            Return _via_Administracion
        End Get
        Friend Set(ByVal value As String)
            _via_Administracion = value
        End Set
    End Property

    Public Property frecuencia() As String
        Get
            Return _frecuencia
        End Get
        Friend Set(ByVal value As String)
            _frecuencia = value
        End Set
    End Property
    Public Property dosis() As String
        Get
            Return _dosis
        End Get
        Friend Set(ByVal value As String)
            _dosis = value
        End Set
    End Property

    Public Property unidad_Dosis() As String
        Get
            Return _unidad_Dosis
        End Get
        Friend Set(ByVal value As String)
            _unidad_Dosis = value
        End Set
    End Property
    Public Property estado_Procesamiento_Detalle() As String
        Get
            Return _estado_Procesamiento_Detalle
        End Get
        Friend Set(ByVal value As String)
            _estado_Procesamiento_Detalle = value
        End Set
    End Property
    Public Property horas_De_Toma() As String
        Get
            Return _horas_De_Toma
        End Get
        Friend Set(ByVal value As String)
            _horas_De_Toma = value
        End Set
    End Property
    Public Property fecha_Hora_Inicio() As String
        Get
            Return _fecha_Hora_Inicio
        End Get
        Friend Set(ByVal value As String)
            _fecha_Hora_Inicio = value
        End Set
    End Property
    Public Property fecha_Hora_Termino() As String
        Get
            Return _fecha_Hora_Termino
        End Get
        Friend Set(ByVal value As String)
            _fecha_Hora_Termino = value
        End Set
    End Property


    'Public Property atc() As String
    '    Get
    '        Return _atc
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _atc = value
    '    End Set
    'End Property
    'Public Property cod_barras() As String
    '    Get
    '        Return _cod_barras
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _cod_barras = value
    '    End Set
    'End Property

    'Public Property estado_ebs() As String
    '    Get
    '        Return _estado_ebs
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _estado_ebs = value
    '    End Set
    'End Property


    'Public Property sec_Prescripciones() As String
    '    Get
    '        Return _sec_Prescripciones
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _sec_Prescripciones = value
    '    End Set
    'End Property


    'Public Property volumen() As String
    '    Get
    '        Return _volumen
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _volumen = value
    '    End Set
    'End Property

    'Public Property unidad_De_Volumen() As String
    '    Get
    '        Return _unidad_De_Volumen
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _unidad_De_Volumen = value
    '    End Set
    'End Property



    'Public Property acción_detalle() As String
    '    Get
    '        Return _acción_detalle
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _acción_detalle = value
    '    End Set
    'End Property
    Public Property observacion() As String
        Get
            Return _observacion
        End Get
        Friend Set(ByVal value As String)
            _observacion = value
        End Set
    End Property



End Class
