Imports System.Collections.Generic

Public Class prescribe
    Private Property _id_Admision As String
    Private Property _numero_Orden As String
    Private Property _tipo_De_Orden As String
    Private Property _id_Medico As String
    Private Property _nombre_Medico As String
    Private Property _primer_Apellido_Medico As String
    Private Property _segundo_Apellido_Medico As String
    Private Property _estado_Procesamiento() As String
    'Private Property _sec_Prescripciones As String
    'Private Property _sitio_Dispensacion As String
    ' Private Property _id_Admision As String

    'Private Property _tipo_Transaccion As String
    'Private Property _id_Comprador As String
    'Private Property _login_Ped As String
    'Private Property _login_Des As String
    'Private Property _tipo_Id_Comprador As String
    'Private Property _estado_Ebs As String
    'Private Property _tipo_Pedido As String
    'Private Property _acción As String
    'Private Property _motivo_Anulación As String
    'Private Property _fecha_Anulacion As String
    'Private Property _estado_Anulacion As String
    'Private Property _mensaje_error_Anulacion As String
    'Private Property _mensaje_Error As String
    'Private Property _fecha_Hora_Procesamiento As String
    'Private Property _fecha_Creacion As String
    'Private Property _fecha_Ultima_Actualizacion As String
    'Private Property _observacionGeneral As String
    Private Property _medicamentos As List(Of medicamentos)

    'Public Property sec_Prescripciones() As String
    '    Get
    '        Return _sec_Prescripciones
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _sec_Prescripciones = value
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
    'Public Property id_Admision() As String
    '    Get
    '        Return _id_Admision
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _id_Admision = value
    '    End Set
    'End Property
    Public Property id_Admision() As String
        Get
            Return _id_Admision
        End Get
        Friend Set(ByVal value As String)
            _id_Admision = value
        End Set
    End Property
    Public Property numero_Orden() As String
        Get
            Return _numero_Orden
        End Get
        Friend Set(ByVal value As String)
            _numero_Orden = value
        End Set
    End Property
    Public Property tipo_De_Orden() As String
        Get
            Return _tipo_De_Orden
        End Get
        Friend Set(ByVal value As String)
            _tipo_De_Orden = value
        End Set
    End Property
    Public Property id_Medico() As String
        Get
            Return _id_Medico
        End Get
        Friend Set(ByVal value As String)
            _id_Medico = value
        End Set
    End Property
    Public Property nombre_Medico() As String
        Get
            Return _nombre_Medico
        End Get
        Friend Set(ByVal value As String)
            _nombre_Medico = value
        End Set
    End Property
    Public Property primer_Apellido_Medico() As String
        Get
            Return _primer_Apellido_Medico
        End Get
        Friend Set(ByVal value As String)
            _primer_Apellido_Medico = value
        End Set
    End Property
    Public Property segundo_Apellido_Medico() As String
        Get
            Return _segundo_Apellido_Medico
        End Get
        Friend Set(ByVal value As String)
            _segundo_Apellido_Medico = value
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

    'Public Property tipo_Transaccion() As String
    '    Get
    '        Return _tipo_Transaccion
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _tipo_Transaccion = value
    '    End Set
    'End Property
    'Public Property id_Comprador() As String
    '    Get
    '        Return _id_Comprador
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _id_Comprador = value
    '    End Set
    'End Property
    'Public Property login_Ped() As String
    '    Get
    '        Return _login_Ped
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _login_Ped = value
    '    End Set
    'End Property
    'Public Property login_Des() As String
    '    Get
    '        Return _login_Des
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _login_Des = value
    '    End Set
    'End Property
    'Public Property tipo_Id_Comprador() As String
    '    Get
    '        Return _tipo_Id_Comprador
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _tipo_Id_Comprador = value
    '    End Set
    'End Property
    'Public Property estado_Ebs() As String
    '    Get
    '        Return _estado_Ebs
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _estado_Ebs = value
    '    End Set
    'End Property
    'Public Property tipo_Pedido() As String
    '    Get
    '        Return _tipo_Pedido
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _tipo_Pedido = value
    '    End Set
    'End Property
    'Public Property acción() As String
    '    Get
    '        Return _acción
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _acción = value
    '    End Set
    'End Property
    'Public Property motivo_Anulación() As String
    '    Get
    '        Return _motivo_Anulación
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _motivo_Anulación = value
    '    End Set
    'End Property
    'Public Property fecha_Anulacion() As String
    '    Get
    '        Return _fecha_Anulacion
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _fecha_Anulacion = value
    '    End Set
    'End Property
    'Public Property estado_Anulacion() As String
    '    Get
    '        Return _estado_Anulacion
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _estado_Anulacion = value
    '    End Set
    'End Property
    'Public Property mensaje_error_Anulacion() As String
    '    Get
    '        Return _mensaje_error_Anulacion
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _mensaje_error_Anulacion = value
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
    'Public Property fecha_Hora_Procesamiento() As String
    '    Get
    '        Return _fecha_Hora_Procesamiento
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _fecha_Hora_Procesamiento = value
    '    End Set
    'End Property
    'Public Property fecha_Creacion() As String
    '    Get
    '        Return _fecha_Creacion
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _fecha_Creacion = value
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
    'Public Property observacionGeneral() As String
    '    Get
    '        Return _observacionGeneral
    '    End Get
    '    Friend Set(ByVal value As String)
    '        _observacionGeneral = value
    '    End Set
    'End Property
    Public Property medicamentos() As List(Of medicamentos)
        Get
            Return _medicamentos
        End Get
        Friend Set(ByVal value As List(Of medicamentos))
            _medicamentos = value
        End Set
    End Property


End Class
