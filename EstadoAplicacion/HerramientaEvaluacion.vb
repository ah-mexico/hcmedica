Public Class HerramientaEvaluacion

    ''Declaracion de los atributos a manejar herramientas de evaluacion
    Private Shared _Instancia As HerramientaEvaluacion
    Private _Pregunta As String
    Private _Respuesta As String
    Private _Preguntas As DataTable ''preguntas de las diferentes herramientas de evaluación
    Private _Respuestas As DataTable ''diferentes resouestas de las preguntas de herramientas de evaluación
    
    Public Shared ReadOnly Property Instancia() As HerramientaEvaluacion
        Get
            If _Instancia Is Nothing Then
                _Instancia = New HerramientaEvaluacion
            End If
            Return _Instancia
        End Get
    End Property
    Public Property Pregunta() As String
        Get
            Return _Pregunta
        End Get
        Set(ByVal Value As String)
            _Pregunta = Value
        End Set
    End Property
    Public Property Respuesta() As String
        Get
            Return _Respuesta
        End Get
        Set(ByVal Value As String)
            _Respuesta = Value
        End Set
    End Property
    
    Public Property Preguntas() As DataTable
        Get
            Return _Preguntas
        End Get
        Set(ByVal Value As DataTable)
            _Preguntas = Value
        End Set
    End Property

    Public Property Respuestas() As DataTable
        Get
            Return _Respuestas
        End Get
        Set(ByVal Value As DataTable)
            _Respuestas = Value
        End Set
    End Property
    Public Sub Limpiar()
        _Pregunta = String.Empty
        _Respuesta = String.Empty
        
        _Preguntas = Nothing
        _Respuestas = Nothing        
    End Sub
End Class
