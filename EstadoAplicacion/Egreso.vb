Namespace Sophia.HistoriaClinica.Controles
    ''' -----------------------------------------------------------------------------
    ''' Project	 : HistoriaClinica.Egresos
    ''' Class	 : Sophia.HistoriaClinica.Controles.Egreso
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Clase Egreso del namespace Sophia.HistoriaClinica.Controles.Egreso que es la clase base
    ''' Esta clase se utiliza para almacenar la información correspondiente al control Egreso
    ''' y se utilizados en la aplicación Window 2005 para el control ctlEgresos
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' [mvargas]	11/04/2006 Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class Egreso
        Implements IDisposable

        Private Shared _Instancia As Egreso

        '// Para controlar el estado (Nuevo, Modificado) \\
        Private strEstado As String

        '// Para almacenar la información relacionada con los diagnósticos en los Egresos \\
        Private cdtDiagnostico As DataTable

        '// Para almacenar la información relacionada con la información adicional en los Egresos \\
        'Private cdtDatosEgreso As DataTable
        Private _EstadoSalida As String = ""
        Private _CausaMuerte As String = ""
        Private _DestinoFinal As String = ""
        Private _ResumenEvolucion As String = ""
        Private _FechaEgreso As String = ""
        Private _HoraEgreso As Integer
        Private _MinutoEgreso As Integer
        Private _postEgreso As String = ""
        Private _obspostEgreso As String = ""


        '// Constructor \\
        Private Sub New()

        End Sub

        '// Instancia \\
        Public Shared ReadOnly Property Instancia() As Egreso
            Get
                If _Instancia Is Nothing Then
                    _Instancia = New Egreso
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
        Public Property dtDiagnostico() As DataTable
            Get
                Return cdtDiagnostico
            End Get
            Set(ByVal value As DataTable)
                cdtDiagnostico = value
            End Set
        End Property
        'Public Property dtDatosEgreso() As DataTable
        '    Get
        '        Return cdtDatosEgreso
        '    End Get
        '    Set(ByVal value As DataTable)
        '        cdtDatosEgreso = value
        '    End Set
        'End Property
        Public Property EstadoSalida() As String
            Get
                Return _EstadoSalida
            End Get
            Set(ByVal value As String)
                _EstadoSalida = value
            End Set
        End Property
        Public Property CausaMuerte() As String
            Get
                Return _CausaMuerte
            End Get
            Set(ByVal value As String)
                _CausaMuerte = value
            End Set
        End Property
        Public Property DestinoFinal() As String
            Get
                Return _DestinoFinal
            End Get
            Set(ByVal value As String)
                _DestinoFinal = value
            End Set
        End Property
        Public Property ResumenEvolucion() As String
            Get
                Return _ResumenEvolucion
            End Get
            Set(ByVal value As String)
                _ResumenEvolucion = value
            End Set
        End Property
        Public Property FechaEgreso() As String
            Get
                Return _FechaEgreso
            End Get
            Set(ByVal value As String)
                _FechaEgreso = value
            End Set
        End Property
        Public Property HoraEgreso() As Integer
            Get
                Return _HoraEgreso
            End Get
            Set(ByVal value As Integer)
                _HoraEgreso = value
            End Set
        End Property
        Public Property MinutoEgreso() As Integer
            Get
                Return _MinutoEgreso
            End Get
            Set(ByVal value As Integer)
                _MinutoEgreso = value
            End Set
        End Property

        Public Property PostEgreso() As String
            Get
                Return _postEgreso
            End Get
            Set(ByVal value As String)
                _postEgreso = value
            End Set
        End Property
        ''Claudia Garay Acreditacion Noviembre 26 de 2010
        Public Property ObsPostEgreso() As String
            Get
                Return _obspostEgreso
            End Get
            Set(ByVal value As String)
                _obspostEgreso = value
            End Set
        End Property

        Private disposedValue As Boolean = False        ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: free unmanaged resources when explicitly called
                End If

                ' TODO: free shared unmanaged resources
                _Instancia = Nothing
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
            cdtDiagnostico = Nothing
            _EstadoSalida = ""
            _CausaMuerte = ""
            _DestinoFinal = ""
            _ResumenEvolucion = ""
            _FechaEgreso = ""
            _HoraEgreso = 0
            _MinutoEgreso = 0
            _postEgreso = ""
            _obspostEgreso = "" ''Claudia Garay Acreditacion Noviembre 26 de 2010
        End Sub

    End Class

    
End Namespace

