Namespace Sophia.HistoriaClinica.Controles
    ''' -----------------------------------------------------------------------------
    ''' Project	 : HistoriaClinica.PlanProcExternos
    ''' Class	 : Sophia.HistoriaClinica.PlanProcExternos
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Clase ProcedimientosExternos del namespace Sophia.HistoriaClinica.Controles.PlanProcExternos que es la clase base
    ''' Esta clase se utiliza para almacenar la información correspondiente control ProcedimientosExternos
    ''' del Plan de Manejo y se utilizados en la aplicación Window 2005 para el control ctlPlanProcExternos
    ''' </summary>
    ''' <remarks></remarks>
    ''' <history>
    ''' [mvargas]	02/05/2006 Created
    ''' </history>
    Public Class PlanProcExternos
        Implements IDisposable

        Private Shared _Instancia As PlanProcExternos

        '// Para controlar el estado (Nuevo, Modificado) \\
        Private strEstado As String

        '// Para almacenar la información relacionada con los procedimientos Externos \\
        Private cdtProcedimientos As DataTable

        '//Determina si la informacion cargada en el objeto es una referencia 
        'a la que se le va a guardar una contrareferecia.
        Private esContrareferencia As Boolean

        Private dtDatosImpresionDiagnostica As DataTable

        '// Constructor \\
        Private Sub New()

        End Sub

        Public Shared ReadOnly Property Instancia() As PlanProcExternos
            Get
                If _Instancia Is Nothing Then
                    _Instancia = New PlanProcExternos
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

        Public Property dtProcedimientos() As DataTable
            Get
                Return cdtProcedimientos
            End Get
            Set(ByVal value As DataTable)
                cdtProcedimientos = value
            End Set
        End Property

        ''' <summary>
        ''' Esta funcion permite modificar desde afuera de la clase se pueda 
        ''' determinar si la informacion del objeto es para grabar una 
        ''' contrareferencia. Estos cambios se hacen en la forma frmReferencia 
        ''' cuando se carga este objeto con la informacion de la referencia elegida.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ContraReferencia() As Boolean
            Get
                Return EsContraReferencia
            End Get
            Set(ByVal value As Boolean)
                esContrareferencia = value
            End Set
        End Property

        Public Property DatosImpresionDiagnostica() As DataTable
            Get
                Return dtDatosImpresionDiagnostica
            End Get
            Set(ByVal value As DataTable)
                dtDatosImpresionDiagnostica = value
            End Set
        End Property

        Private blnPermiteLimpiarReferencia As Boolean
        Public Property PermiteLimpiarReferencia() As Boolean
            Get
                Return blnPermiteLimpiarReferencia
            End Get
            Set(ByVal value As Boolean)
                blnPermiteLimpiarReferencia = value
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
            cdtProcedimientos = Nothing
            esContrareferencia = False
        End Sub

    End Class
End Namespace