Public Class MedicamentosConciliadosOtros
    Implements IDisposable

    Private Shared _instancia As MedicamentosConciliadosOtros
    Private _TabladOrdenes As DataSet
    Private _dtMedicamentos As DataTable
    Private _estado As String

    Private Sub New()
        _estado = "N"
    End Sub

    Public Shared ReadOnly Property Instancia() As MedicamentosConciliadosOtros
        Get
            If _instancia Is Nothing Then
                _instancia = New MedicamentosConciliadosOtros()
            End If
            Return _instancia
        End Get
    End Property

#Region "Propiedades"

    Public Property TablasOrdenes() As DataSet
        Get
            Return _TabladOrdenes
        End Get
        Set(ByVal Value As DataSet)
            _TabladOrdenes = Value
        End Set
    End Property

    Public Property dtMedicamentos() As DataTable
        Get
            Return _dtMedicamentos
        End Get
        Set(ByVal Value As DataTable)
            _dtMedicamentos = Value
        End Set
    End Property

    Public Property Estado() As String
        Get
            Return _estado
        End Get
        Set(ByVal Value As String)
            _estado = Value
        End Set
    End Property
#End Region


    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If

            ' TODO: free shared unmanaged resources
            _instancia = Nothing
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
        _TabladOrdenes = Nothing
        _estado = "N"
    End Sub
End Class
