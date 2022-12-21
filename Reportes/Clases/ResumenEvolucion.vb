
Namespace Sophia.HistoriaClinica.Reportes
    Public Class ResumenEvolucion

        Private _resumen As String
        Private _destinoFinal As String
        Private _tipoDiscapacidad As String
        Private _gradoDiscapacidad As String

#Region "Propiedades"
        Public Property Resumen() As String
            Get
                Return _resumen
            End Get
            Set(ByVal Value As String)
                _resumen = Value
            End Set
        End Property
        Public Property DestinoFinal() As String
            Get
                Return _destinoFinal
            End Get
            Set(ByVal Value As String)
                _destinoFinal = Value
            End Set
        End Property
        Public Property TipoDiscapacidad() As String
            Get
                Return _tipoDiscapacidad
            End Get
            Set(ByVal Value As String)
                _tipoDiscapacidad = Value
            End Set
        End Property
        Public Property GradoDiscapacidad() As String
            Get
                Return _gradoDiscapacidad
            End Get
            Set(ByVal Value As String)
                _gradoDiscapacidad = Value
            End Set
        End Property
#End Region

        Public Sub New()
        End Sub

        Public Sub inicializar(ByVal drDatos As IDataReader)

            While drDatos.Read()
                _resumen = drDatos("resumen").ToString
                _destinoFinal = drDatos("DestinoFinal").ToString
                _tipoDiscapacidad = drDatos("TipoDiscapacidad").ToString
                _gradoDiscapacidad = drDatos("GradoDiscapacidad").ToString
            End While
        End Sub
    End Class
End Namespace

