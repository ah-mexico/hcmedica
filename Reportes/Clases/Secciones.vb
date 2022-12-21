Namespace Sophia.HistoriaClinica.Reportes
    Public Class Secciones

        Private _remision As Boolean
        Private _recomendaciones As Boolean
        Private _triage As Boolean
        Private _incapacidad As Boolean
        Private _formula As Boolean
        Private _procedimExt As Boolean
        Private _todas As Boolean
        Private _descripcionQx As Boolean
        Private _IdentificadorRiesgo As Boolean
        '


        Public Property IdentificadorRiesgo() As Boolean
            Get
                Return _IdentificadorRiesgo
            End Get
            Set(ByVal value As Boolean)
                _IdentificadorRiesgo = value
            End Set
        End Property
        Public Property Remision() As Boolean
            Get
                Return _remision
            End Get
            Set(ByVal value As Boolean)
                _remision = value
            End Set
        End Property

        Public Property Recomendaciones() As Boolean
            Get
                Return _recomendaciones
            End Get
            Set(ByVal value As Boolean)
                _recomendaciones = value
            End Set
        End Property

        Public Property Triage() As Boolean
            Get
                Return _triage
            End Get
            Set(ByVal value As Boolean)
                _triage = value
            End Set
        End Property

        Public Property Todas() As Boolean
            Get
                Return _todas
            End Get
            Set(ByVal value As Boolean)
                _todas = value
            End Set
        End Property
        Public Property Incapacidad() As Boolean
            Get
                Return _incapacidad
            End Get
            Set(ByVal value As Boolean)
                _incapacidad = value
            End Set
        End Property

        Public Property Formula() As Boolean
            Get
                Return _formula
            End Get
            Set(ByVal value As Boolean)
                _formula = value
            End Set
        End Property
        Public Property ProcedimExt() As Boolean
            Get
                Return _procedimExt
            End Get
            Set(ByVal value As Boolean)
                _procedimExt = value
            End Set
        End Property
        Public Property DescripcionQx() As Boolean
            Get
                Return _descripcionQx
            End Get
            Set(ByVal value As Boolean)
                _descripcionQx = value
            End Set
        End Property
    End Class

End Namespace

