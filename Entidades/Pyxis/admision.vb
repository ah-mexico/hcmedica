Imports System.Collections.Generic

Public Class admision
    Private Property _id_Admision As String
    Private Property _id_Admision_Anterior As String
    Private Property _tipo_Documento As String
    Private Property _id_Paciente As String
    'Private Property _Id_Alternativo As String
    Private Property _tipo_Admision As String
    Private Property _fecha_Admision As String
    Private Property _apellido_Materno As String
    Private Property _apellido_Paterno As String
    Private Property _nombres As String
    Private Property _sexo As String
    Private Property _peso As String
    Private Property _edad As String
    Private Property _fecha_Nacimiento As String
    Private Property _fecha_Alta_Paciente As String
    Private Property _estado_Procesamiento As String

    'Private Property _estado_Proceso_Alta As String
    'Private Property _fecha_Creacion As String
    'Private Property _fecha_Hora_Proc_Alta As String
    'Private Property _fecha_Hora_Procesamiento As String
    'Private Property _fecha_Ultima_Actualizacion As String
    'Private Property _id_Alternativo As String
    'Private Property _mensaje_Error As String
    'Private Property _sitio_Dispensacion As String
    'Private Property _fecha_Upd_Estado As String
    Private Property _estado_Admision As String

    Public Property id_Admision() As String
        Get
            Return _id_Admision
        End Get
        Friend Set(ByVal value As String)
            _id_Admision = value
        End Set
    End Property
    Public Property id_Admision_Anterior() As String
        Get
            Return _id_Admision_Anterior
        End Get
        Friend Set(ByVal value As String)
            _id_Admision_Anterior = value
        End Set
    End Property
    Public Property tipo_Documento() As String
        Get
            Return _tipo_Documento
        End Get
        Friend Set(ByVal value As String)
            _tipo_Documento = value
        End Set
    End Property
    Public Property id_Paciente() As String
        Get
            Return _id_Paciente
        End Get
        Friend Set(ByVal value As String)
            _id_Paciente = value
        End Set
    End Property
    'Public Property Id_Alternativo() As String
    '    Get
    '        Return _Id_Alternativo
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _Id_Alternativo = value
    '    End Set
    'End Property
    Public Property tipo_Admision() As String
        Get
            Return _tipo_Admision
        End Get
        Friend Set(ByVal value As String)
            _tipo_Admision = value
        End Set
    End Property
    Public Property fecha_Admision() As String
        Get
            Return _fecha_Admision
        End Get
        Friend Set(ByVal value As String)
            _fecha_Admision = value
        End Set
    End Property
    Public Property apellido_Materno() As String
        Get
            Return _apellido_Materno
        End Get
        Friend Set(ByVal value As String)
            _apellido_Materno = value
        End Set
    End Property
    Public Property apellido_Paterno() As String
        Get
            Return _apellido_Paterno
        End Get
        Friend Set(ByVal value As String)
            _apellido_Paterno = value
        End Set
    End Property
    Public Property nombres() As String
        Get
            Return _nombres
        End Get
        Friend Set(ByVal value As String)
            _nombres = value
        End Set
    End Property
    Public Property sexo() As String
        Get
            Return _sexo
        End Get
        Friend Set(ByVal value As String)
            _sexo = value
        End Set
    End Property
    Public Property peso() As String
        Get
            Return _peso
        End Get
        Friend Set(ByVal value As String)
            _peso = value
        End Set
    End Property
    Public Property edad() As String
        Get
            Return _edad
        End Get
        Friend Set(ByVal value As String)
            _edad = value
        End Set
    End Property
    Public Property fecha_Nacimiento() As String
        Get
            Return _fecha_Nacimiento
        End Get
        Friend Set(ByVal value As String)
            _fecha_Nacimiento = value
        End Set
    End Property
    Public Property fecha_Alta_Paciente() As String
        Get
            Return _fecha_Alta_Paciente
        End Get
        Friend Set(ByVal value As String)
            _fecha_Alta_Paciente = value
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

    Public Property estado_Admision() As String
        Get
            Return _estado_Admision
        End Get
        Friend Set(ByVal value As String)
            _estado_Admision = value
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
    'Public Property fecha_Hora_Proc_Alta() As String
    '    Get
    '        Return _fecha_Hora_Proc_Alta
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _fecha_Hora_Proc_Alta = value
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


    'Public Property estado_Proceso_Alta() As String
    '    Get
    '        Return _estado_Proceso_Alta
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _estado_Proceso_Alta = value
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

    'Public Property id_Alternativo() As String
    '    Get
    '        Return _id_Alternativo
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _id_Alternativo = value
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

    'Public Property sitio_Dispensacion() As String
    '    Get
    '        Return _sitio_Dispensacion
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _sitio_Dispensacion = value
    '    End Set
    'End Property


    'End Property




    'Public Property fecha_Upd_Estado() As String
    '    Get
    '        Return _fecha_Upd_Estado
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _fecha_Upd_Estado = value
    '    End Set
    'End Property
End Class
