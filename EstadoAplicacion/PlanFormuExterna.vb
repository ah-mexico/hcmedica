Namespace Sophia.HistoriaClinica.Controles
    ''' -----------------------------------------------------------------------------
    ''' Project	 : HistoriaClinica.PlanFormuExterna
    ''' Class	 : Sophia.HistoriaClinica.PlanFormuExterna
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Clase ProcedimientosExternos del namespace Sophia.HistoriaClinica.Controles.PlanFormuExterna que es la clase base
    ''' Esta clase se utiliza para almacenar la información correspondiente control FormulacionExterna
    ''' del Plan de Manejo y se utilizados en la aplicación Window 2005 para el control ctlPlanFormuExterna
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' [mvargas]	09/05/2006 Created
    ''' </history>
    Public Class PlanFormuExterna
        Implements IDisposable

        Private Shared _Instancia As PlanFormuExterna

        '// Para controlar el estado (Nuevo, Modificado) \\
        Private strEstado As String = ""

        '// Para almacenar la información relacionada con los medicamentes \\
        Private cdtFormulacion As DataTable
        Private cdtNroFormulas As DataTable
        Private dblNroFormula As Double = 0
        Private intPos As Integer = 1
        Private blnNuevaForm As Boolean = False
        Private blnNuevaActiva As Boolean = False
        Private strObservaciones As String = ""        
        Private _tipoEntidad As String
        '// Constructor \\
        Private Sub New()

        End Sub

        Public Shared ReadOnly Property Instancia() As PlanFormuExterna
            Get
                If _Instancia Is Nothing Then
                    _Instancia = New PlanFormuExterna
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

        Public Property dtFormulacion() As DataTable
            Get
                Return cdtFormulacion
            End Get
            Set(ByVal value As DataTable)
                cdtFormulacion = value
            End Set
        End Property

        Public Property dtNroFormulas() As DataTable
            Get
                Return cdtNroFormulas
            End Get
            Set(ByVal value As DataTable)
                cdtNroFormulas = value
            End Set
        End Property


        Public Property NumeroFormulaActual() As Double
            Get
                Return dblNroFormula
            End Get
            Set(ByVal value As Double)
                dblNroFormula = value
            End Set
        End Property

        Public Property PosicionActualFormula() As Integer
            Get
                Return intPos
            End Get
            Set(ByVal value As Integer)
                intPos = value
            End Set
        End Property

        Public Property EsNuevaFormula() As Boolean
            Get
                Return blnNuevaForm
            End Get
            Set(ByVal value As Boolean)
                blnNuevaForm = value
            End Set
        End Property

        Public Property NuevaFormulaActiva() As Boolean
            Get
                Return blnNuevaActiva
            End Get
            Set(ByVal value As Boolean)
                blnNuevaActiva = value
            End Set
        End Property

        Public Property ObservacionesFormula() As String
            Get
                Return strObservaciones
            End Get
            Set(ByVal value As String)
                strObservaciones = value
            End Set
        End Property
        Public Property TipoEntidad() As String
            Get
                Return _tipoEntidad
            End Get
            Set(ByVal value As String)
                _tipoEntidad = value
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
            cdtFormulacion = Nothing
            cdtNroFormulas = Nothing
            dblNroFormula = 0
            intPos = 1
            blnNuevaForm = False
            blnNuevaActiva = False
            strObservaciones = ""
        End Sub

    End Class
End Namespace
