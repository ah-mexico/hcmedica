Namespace Sophia.HistoriaClinica.Controles
    ''' -----------------------------------------------------------------------------
    ''' Project	 : HistoriaClinica.PlanIncapacidad
    ''' Class	 : Sophia.HistoriaClinica.PlanIncapacidad
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Clase PlanIncapacidad del namespace Sophia.HistoriaClinica.Controles.PlanIncapacidad que es la clase base
    ''' Esta clase se utiliza para almacenar la información correspondiente control Incapacidades
    ''' del Plan de Manejo y se utilizados en la aplicación Window 2005 para el control ctlPlanIncapacidad
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' [mvargas]	10/05/2006 Created
    ''' </history>
    Public Class PlanIncapacidad
        Implements IDisposable

        Private Shared _Instancia As PlanIncapacidad

        '// Para controlar el estado (Nuevo, Modificado) \\
        Private strEstado As String = ""

        Private _strCodigoDiagnostico As String = ""
        Private _strDiagnostico As String = ""
        Private _strObs As String = ""
        Private _intCantidad As Integer = 0
        Private _strFechaInicial As String = ""
        Private _strFechaFinal As String = ""

        '// Constructor \\
        Private Sub New()

        End Sub

        Public Shared ReadOnly Property Instancia() As PlanIncapacidad
            Get
                If _Instancia Is Nothing Then
                    _Instancia = New PlanIncapacidad
                End If
                Return _Instancia

            End Get
        End Property

        Public Property Estado() As String
            Get
                Return strEstado
            End Get
            Set(ByVal value As String)
                strEstado = value
            End Set
        End Property

        Public Property CodigoDiagnostico() As String
            Get
                Return _strCodigoDiagnostico
            End Get
            Set(ByVal value As String)
                _strCodigoDiagnostico = value
            End Set
        End Property
        Public Property Diagnostico() As String
            Get
                Return _strDiagnostico
            End Get
            Set(ByVal value As String)
                _strDiagnostico = value
            End Set
        End Property
        Public Property Observacion() As String
            Get
                Return _strObs
            End Get
            Set(ByVal value As String)
                _strObs = value
            End Set
        End Property
        Public Property Cantidad() As Integer
            Get
                Return _intCantidad
            End Get
            Set(ByVal value As Integer)
                _intCantidad = value
            End Set
        End Property
        Public Property FechaInicial() As String
            Get
                Return _strFechaInicial
            End Get
            Set(ByVal value As String)
                _strFechaInicial = value
            End Set
        End Property
        Public Property FechaFinal() As String
            Get
                Return _strFechaFinal
            End Get
            Set(ByVal value As String)
                _strFechaFinal = value
            End Set
        End Property
        Private disposedValue As Boolean = False        ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: free unmanaged resources when explicitly called
                End If
                _Instancia = Nothing
                ' TODO: free shared unmanaged resources
            End If
            Me.disposedValue = True
        End Sub

#Region " IDisposable Support "
        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

        Public Sub Limpiar()
            strEstado = ""
            _strCodigoDiagnostico = ""
            _strDiagnostico = ""
            _strObs = ""
            _intCantidad = 0
            _strFechaInicial = ""
            _strFechaFinal = ""
        End Sub
    End Class
End Namespace
