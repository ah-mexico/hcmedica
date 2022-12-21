Public Class ubicacion
    Private Property _id_Admision As String
    Private Property _id_Ubicacion As String
    Private Property _unidad_Enfermeria As String
    Private Property _id_Cama As String

    'Private Property _episodio As String
    'Private Property _fecha_Creacion As String
    'Private Property _fecha_Hora_Procesamiento As String
    'Private Property _fecha_Ultima_Actualizacion As String
    'Private Property _id_Admision As String


    'Private Property _id_Medico As String

    'Private Property _mensaje_Error As String
    'Private Property _nombre_Medico As String
    'Private Property _sala As String
    'Private Property _sec_Ubicacion As String
    'Private Property _sitio_Dispensacion As String

    'Public Property episodio() As String
    '    Get
    '        Return _episodio
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _episodio = value
    '    End Set
    'End Property
    Private Property _estado_Procesamiento As String

    Public Property id_Admision() As String
        Get
            Return _id_Admision
        End Get
        Friend Set(ByVal value As String)
            _id_Admision = value
        End Set
    End Property
    Public Property id_Ubicacion() As String
        Get
            Return _id_Ubicacion
        End Get
        Friend Set(ByVal value As String)
            _id_Ubicacion = value
        End Set
    End Property
    Public Property unidad_Enfermeria() As String
        Get
            Return _unidad_Enfermeria
        End Get
        Friend Set(ByVal value As String)
            _unidad_Enfermeria = value
        End Set
    End Property

    Public Property id_Cama() As String
        Get
            Return _id_Cama
        End Get
        Friend Set(ByVal value As String)
            _id_Cama = value
        End Set
    End Property
    Public Property estado_Procesamiento() As String
        Get
            Return _estado_Procesamiento
        End Get
        Friend Set(ByVal value As String)
            _estado_Procesamiento = value
        End Set
    End Property
    'Public Property fecha_Creacion() As String
    '    Get
    '        Return _fecha_Creacion
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _fecha_Creacion = value
    '    End Set
    'End Property
    'Public Property fecha_Hora_Procesamiento() As String
    '    Get
    '        Return _fecha_Hora_Procesamiento
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _fecha_Hora_Procesamiento = value
    '    End Set
    'End Property
    'Public Property fecha_Ultima_Actualizacion() As String
    '    Get
    '        Return _fecha_Ultima_Actualizacion
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _fecha_Ultima_Actualizacion = value
    '    End Set
    'End Property
    'Public Property id_Admision() As String
    '    Get
    '        Return _id_Admision
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _id_Admision = value
    '    End Set
    'End Property


    'Public Property id_Medico() As String
    '    Get
    '        Return _id_Medico
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _id_Medico = value
    '    End Set
    'End Property

    'Public Property mensaje_Error() As String
    '    Get
    '        Return _mensaje_Error
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _mensaje_Error = value
    '    End Set
    'End Property
    'Public Property nombre_Medico() As String
    '    Get
    '        Return _nombre_Medico
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _nombre_Medico = value
    '    End Set
    'End Property
    'Public Property sala() As String
    '    Get
    '        Return _sala
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _sala = value
    '    End Set
    'End Property
    'Public Property sec_Ubicacion() As String
    '    Get
    '        Return _sec_Ubicacion
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _sec_Ubicacion = value
    '    End Set
    'End Property
    'Public Property sitio_Dispensacion() As String
    '    Get
    '        Return _sitio_Dispensacion
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _sitio_Dispensacion = value
    '    End Set
    'End Property
End Class
