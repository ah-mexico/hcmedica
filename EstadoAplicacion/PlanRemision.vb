Namespace Sophia.HistoriaClinica.Controles

    ' -----------------------------------------------------------------------------
    ' Project	 : HistoriaClinica.PlanRemision
    ' Class	 : Sophia.HistoriaClinica.Controles.PlanRemision
    ' -----------------------------------------------------------------------------
    ' <summary>
    ' Clase RecomEgreso del namespace Sophia.HistoriaClinica.Controles.PlanRemision que es la clase base
    ' Esta clase se utiliza para almacenar la información correspondiente control Remisiones en el plan de
    ' de manejo y se utilizará en la aplicación Window 2005 para el control ctlPlanRemision
    ' </summary>
    ' <remarks>
    ' </remarks>
    ' <history>
    ' [mvargas]	12/05/2006 Created
    ' </history>
    Public Class PlanRemision
        Implements IDisposable

        Private Shared _Instancia As PlanRemision
        '// Para controlar el estado (Nuevo, Modificado, Grabar) \\
        Private disposedValue As Boolean = False        ' To detect redundant calls

        Private strEstado As String = ""
        Private strCodigoInstitucion As String = ""
        Private strDesInstitucion As String = ""
        Private strServicio As String = ""
        Private strMedicoConfirma As String = ""
        Private strCargoMedico As String = ""
        Private strCodigoAmbulancia As String = ""
        Private strDesAmbulancia As String = ""
        Private strTraAmbulan As String = "" ''cpgaray
        Private strNivel As String = ""
        Private strDescNivel As String = ""
        Private strNumeroAutoriza As String = ""
        Private strAnanmesis As String = ""
        Private strAuxiliarDiagnostico As String = ""
        Private strEvolucion As String = ""
        Private strDiagnostico As String = ""
        Private strComplicaciones As String = ""
        Private strTratamientos As String = ""
        Private strMotivos As String = ""
        Private strEstadoPaciente As String = ""
        Private strFechaAutorizacion As String = ""
        Private intHoraAutorizacion As Integer
        Private intMinutoAutorizacion As Integer
        Private strObservaciones As String = ""

        'Campos utilizados para manejar la funcionalidad de contrareferencia
        Private tipoAdmisionOrigen As String = ""
        Private anoAdmisionOrigen As Integer = 0
        Private numeroAdmisionOrigen As Long = 0
        Private fecha_remision As String = ""
        Private hora_remision As Integer = 0
        Private minuto_remision As Integer = 0
        Private codSucursal_origen As String = ""
        Private codPrestador_Origen As String = ""
        Private esContrareferencia As Boolean = False
        Private cerrada As String = ""
        Private respuesta As String = ""
        Private interpretacion As String = ""
        Private dtDatosImpresionDiagnostica As DataTable

        '// Constructor \\
        Private Sub New()

        End Sub

        Public Shared ReadOnly Property Instancia() As PlanRemision
            Get
                If _Instancia Is Nothing Then
                    _Instancia = New PlanRemision
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
        Public Property CodigoInstitucion() As String
            Get
                Return strCodigoInstitucion
            End Get
            Set(ByVal value As String)
                strCodigoInstitucion = value
            End Set
        End Property
        Public Property DesInstitucion() As String
            Get
                Return strDesInstitucion
            End Get
            Set(ByVal value As String)
                strDesInstitucion = value
            End Set
        End Property
        Public Property Servicio() As String
            Get
                Return strServicio
            End Get
            Set(ByVal value As String)
                strServicio = value
            End Set
        End Property
        Public Property MedicoConfirma() As String
            Get
                Return strMedicoConfirma
            End Get
            Set(ByVal value As String)
                strMedicoConfirma = value
            End Set
        End Property
        Public Property CargoMedico() As String
            Get
                Return strCargoMedico
            End Get
            Set(ByVal value As String)
                strCargoMedico = value
            End Set
        End Property
        Public Property CodigoAmbulancia() As String
            Get
                Return strCodigoAmbulancia
            End Get
            Set(ByVal value As String)
                strCodigoAmbulancia = value
            End Set
        End Property
        Public Property TrasladoAmbulancia() As String ''cpgaray
            Get
                Return strTraAmbulan
            End Get
            Set(ByVal value As String)
                strTraAmbulan = value
            End Set
        End Property
        Public Property DesAmbulancia() As String
            Get
                Return strDesAmbulancia
            End Get
            Set(ByVal value As String)
                strDesAmbulancia = value
            End Set
        End Property
        Public Property Nivel() As String
            Get
                Return strNivel
            End Get
            Set(ByVal value As String)
                strNivel = value
            End Set
        End Property
        Public Property DesNivel() As String
            Get
                Return strDescNivel
            End Get
            Set(ByVal value As String)
                strDescNivel = value
            End Set
        End Property
        Public Property NumeroAutorizacion() As String
            Get
                Return strNumeroAutoriza
            End Get
            Set(ByVal value As String)
                strNumeroAutoriza = value
            End Set
        End Property
        Public Property Ananmesis() As String
            Get
                Return strAnanmesis
            End Get
            Set(ByVal value As String)
                strAnanmesis = value
            End Set
        End Property
        Public Property AuxiliarDiagnostico() As String
            Get
                Return strAuxiliarDiagnostico
            End Get
            Set(ByVal value As String)
                strAuxiliarDiagnostico = value
            End Set
        End Property
        Public Property Evolucion() As String
            Get
                Return strEvolucion
            End Get
            Set(ByVal value As String)
                strEvolucion = value
            End Set
        End Property
        Public Property Diagnostico() As String
            Get
                Return strDiagnostico
            End Get
            Set(ByVal value As String)
                strDiagnostico = value
            End Set
        End Property
        Public Property Complicaciones() As String
            Get
                Return strComplicaciones
            End Get
            Set(ByVal value As String)
                strComplicaciones = value
            End Set
        End Property
        Public Property Tratamientos() As String
            Get
                Return strTratamientos
            End Get
            Set(ByVal value As String)
                strTratamientos = value
            End Set
        End Property
        Public Property Motivos() As String
            Get
                Return strMotivos
            End Get
            Set(ByVal value As String)
                strMotivos = value
            End Set
        End Property
        Public Property EstadoPaciente() As String
            Get
                Return strEstadoPaciente
            End Get
            Set(ByVal value As String)
                strEstadoPaciente = value
            End Set
        End Property
        Public Property FechaAutorizacion() As String
            Get
                Return strFechaAutorizacion
            End Get
            Set(ByVal value As String)
                strFechaAutorizacion = value
            End Set
        End Property
        Public Property HoraAutorizacion() As Integer
            Get
                Return intHoraAutorizacion
            End Get
            Set(ByVal value As Integer)
                intHoraAutorizacion = value
            End Set
        End Property
        Public Property MinutoAutorizacion() As Integer
            Get
                Return intMinutoAutorizacion
            End Get
            Set(ByVal value As Integer)
                intMinutoAutorizacion = value
            End Set
        End Property

        Public Property Observaciones() As String
            Get
                Return strObservaciones
            End Get
            Set(ByVal value As String)
                strObservaciones = value
            End Set
        End Property

        Public Property TipoAdmisionOrigenR() As String
            Get
                Return tipoAdmisionOrigen
            End Get
            Set(ByVal value As String)
                tipoAdmisionOrigen = value
            End Set
        End Property

        Public Property AnoAdmisionOrigenR() As Integer
            Get
                Return anoAdmisionOrigen
            End Get
            Set(ByVal value As Integer)
                anoAdmisionOrigen = value
            End Set
        End Property

        Public Property NumeroAdmisionOrigenR() As Long
            Get
                Return numeroAdmisionOrigen
            End Get
            Set(ByVal value As Long)
                numeroAdmisionOrigen = value
            End Set
        End Property

        Public Property FechaRemision() As String
            Get
                Return fecha_remision
            End Get
            Set(ByVal value As String)
                fecha_remision = value
            End Set
        End Property

        Public Property HoraRemision() As Integer
            Get
                Return hora_remision
            End Get
            Set(ByVal value As Integer)
                hora_remision = value
            End Set
        End Property

        Public Property MinutoRemision() As Integer
            Get
                Return minuto_remision
            End Get
            Set(ByVal value As Integer)
                minuto_remision = value
            End Set
        End Property

        Public Property SucursalOrigen() As String
            Get
                Return codSucursal_origen
            End Get
            Set(ByVal value As String)
                codSucursal_origen = value
            End Set
        End Property

        Public Property PrestadorOrigen() As String
            Get
                Return codPrestador_Origen
            End Get
            Set(ByVal value As String)
                codPrestador_Origen = value
            End Set
        End Property

        Public Property Contrareferencia() As Boolean
            Get
                Return esContrareferencia
            End Get
            Set(ByVal value As Boolean)
                esContrareferencia = value
            End Set
        End Property

        Public Property ContrareferenciaCerrada() As String
            Get
                Return cerrada
            End Get
            Set(ByVal value As String)
                cerrada = value
            End Set
        End Property

        Public Property RepuestaContrareferencia() As String
            Get
                Return respuesta
            End Get
            Set(ByVal value As String)
                respuesta = value
            End Set
        End Property

        Public Property InterpretacionContrareferencia() As String
            Get
                Return interpretacion
            End Get
            Set(ByVal value As String)
                interpretacion = value
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

        Private strEstadoOriginal As String
        Public Property EstadoOriginal() As String
            Get
                Return strEstadoOriginal
            End Get
            Set(ByVal value As String)
                strEstadoOriginal = value
            End Set
        End Property

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
            strCodigoInstitucion = ""
            strDesInstitucion = ""
            strServicio = ""
            strMedicoConfirma = ""
            strCargoMedico = ""
            strCodigoAmbulancia = ""
            strDesAmbulancia = ""
            strNivel = ""
            strDescNivel = ""
            strNumeroAutoriza = ""
            strAnanmesis = ""
            strAuxiliarDiagnostico = ""
            strEvolucion = ""
            strDiagnostico = ""
            strComplicaciones = ""
            strTratamientos = ""
            strMotivos = ""
            strEstadoPaciente = ""
            strFechaAutorizacion = ""
            intHoraAutorizacion = 0
            intMinutoAutorizacion = 0
            strObservaciones = ""
            tipoAdmisionOrigen = ""
            anoAdmisionOrigen = 0
            numeroAdmisionOrigen = 0
            fecha_remision = ""
            hora_remision = 0
            minuto_remision = 0
            codSucursal_origen = ""
            codPrestador_Origen = ""
            esContrareferencia = False
            cerrada = ""
            respuesta = ""
            interpretacion = ""

        End Sub

    End Class

End Namespace
