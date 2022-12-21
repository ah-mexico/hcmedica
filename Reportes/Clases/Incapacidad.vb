
Namespace Sophia.HistoriaClinica.Reportes

    Public Class Incapacidad

        Private _diagnostico As String
        Private _observaciones As String
        Private _dias As String
        Private _fechaInicial As String
        Private _fechaFinal As String
        Private _especialidad As String
        Private _medicoIncapacidad As String

#Region "Propiedades"

        Public Property Diagnostico() As String
            Get
                Return _diagnostico
            End Get
            Set(ByVal value As String)
                _diagnostico = value
            End Set
        End Property

        Public Property Observaciones() As String
            Get
                Return _observaciones
            End Get
            Set(ByVal value As String)
                _observaciones = value
            End Set
        End Property

        Public Property Dias() As String
            Get
                Return _dias
            End Get
            Set(ByVal value As String)
                _dias = value
            End Set
        End Property

        Public Property FechaInicial() As String
            Get
                Return _fechaInicial
            End Get
            Set(ByVal value As String)
                _fechaInicial = value
            End Set
        End Property

        Public Property FechaFinal() As String
            Get
                Return _fechaFinal
            End Get
            Set(ByVal value As String)
                _fechaFinal = value
            End Set
        End Property
        Public Property Especialidad() As String ''cpgaray mostrar la especialidad de hcincapacidad
            Get
                Return _especialidad
            End Get
            Set(ByVal value As String)
                _especialidad = value
            End Set
        End Property
        Public Property MedicoIncapacidad() As String ''cpgaray mostrar el médico de hcincapacidad OS 170047

            Get
                Return _medicoIncapacidad
            End Get
            Set(ByVal value As String)
                _medicoIncapacidad = value
            End Set
        End Property
#End Region


    End Class

End Namespace

