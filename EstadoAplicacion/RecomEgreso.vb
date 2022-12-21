Namespace Sophia.HistoriaClinica.Controles

    ' -----------------------------------------------------------------------------
    ' Project	 : HistoriaClinica.RecomEgreso
    ' Class	 : Sophia.HistoriaClinica.Controles.RecomEgreso
    ' -----------------------------------------------------------------------------
    ' <summary>
    ' Clase RecomEgreso del namespace Sophia.HistoriaClinica.Controles.RecomEgreso que es la clase base
    ' Esta clase se utiliza para almacenar la información correspondiente control Recomendaciones al Egreso
    ' y se utilizará en la aplicación Window 2005 para el control ctlRecomEgreso
    ' </summary>
    ' <remarks>
    ' </remarks>
    ' <history>
    ' [mvargas]	11/05/2006 Created
    ' </history>
    Public Class RecomEgreso
        Implements IDisposable

        Private Shared _Instancia As RecomEgreso
        '// Para controlar el estado (Nuevo, Modificado) \\
        Private disposedValue As Boolean = False        ' To detect redundant calls

        Private strEstado As String
        Private strSignosAlarma As String
        Private blSignoFiebre As Boolean
        Private blSignoCalor As Boolean
        Private blSignoEnrojecimiento As Boolean
        Private blSignoSecrecion As Boolean
        Private strActividadFisica As String
        Private strRecomendacionNutricional As String
        Private strRecomendacionGeneral As String
        Private strResultadoDiagnostico As String
        Private intIncapacidad As Integer
        Private strFechaControl As String
        Private strLugarControl As String
        Private strTelefonoMedico As String
        Private strConciliacion As String ''cpgaray 

        '// Constructor \\
        Private Sub New()

        End Sub

        Public Shared ReadOnly Property Instancia() As RecomEgreso
            Get
                If _Instancia Is Nothing Then
                    _Instancia = New RecomEgreso
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
        Public Property SignosAlarma() As String
            Get
                Return strSignosAlarma
            End Get
            Set(ByVal value As String)
                strSignosAlarma = value
            End Set
        End Property
        Public Property SignoFiebre() As Boolean
            Get
                Return blSignoFiebre
            End Get
            Set(ByVal value As Boolean)
                blSignoFiebre = value
            End Set
        End Property
        Public Property SignoCalor() As Boolean
            Get
                Return blSignoCalor
            End Get
            Set(ByVal value As Boolean)
                blSignoCalor = value
            End Set
        End Property
        Public Property SignoEnrojecimiento() As Boolean
            Get
                Return blSignoEnrojecimiento
            End Get
            Set(ByVal value As Boolean)
                blSignoEnrojecimiento = value
            End Set
        End Property
        Public Property SignoSecrecion() As Boolean
            Get
                Return blSignoSecrecion
            End Get
            Set(ByVal value As Boolean)
                blSignoSecrecion = value
            End Set
        End Property
        Public Property ActividadFisica() As String
            Get
                Return strActividadFisica
            End Get
            Set(ByVal value As String)
                strActividadFisica = value
            End Set
        End Property
        Public Property RecomendacionNutricional() As String
            Get
                Return strRecomendacionNutricional
            End Get
            Set(ByVal value As String)
                strRecomendacionNutricional = value
            End Set
        End Property
        Public Property RecomendacionGeneral() As String
            Get
                Return strRecomendacionGeneral
            End Get
            Set(ByVal value As String)
                strRecomendacionGeneral = value
            End Set
        End Property
        Public Property ResultadoDiagnostico() As String
            Get
                Return strResultadoDiagnostico
            End Get
            Set(ByVal value As String)
                strResultadoDiagnostico = value
            End Set
        End Property
        Public Property Incapacidad() As Integer
            Get
                Return intIncapacidad
            End Get
            Set(ByVal value As Integer)
                intIncapacidad = value
            End Set
        End Property
        Public Property FechaControl() As String
            Get
                Return strFechaControl
            End Get
            Set(ByVal value As String)
                strFechaControl = value
            End Set
        End Property
        Public Property LugarControl() As String
            Get
                Return strLugarControl
            End Get
            Set(ByVal value As String)
                strLugarControl = value
            End Set
        End Property
        Public Property TelefonoMedico() As String
            Get
                Return strTelefonoMedico
            End Get
            Set(ByVal value As String)
                strTelefonoMedico = value
            End Set
        End Property
        ''cpgaray Conciliacion de medicamentos Febrero 27 2012
        Public Property ConciliacionMedicamentos() As String
            Get
                Return strConciliacion
            End Get
            Set(ByVal value As String)
                strConciliacion = value
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
            strSignosAlarma = ""
            blSignoFiebre = False
            blSignoCalor = False
            blSignoEnrojecimiento = False
            blSignoSecrecion = False
            strActividadFisica = ""
            strRecomendacionNutricional = ""
            strRecomendacionGeneral = ""
            strResultadoDiagnostico = ""
            intIncapacidad = 0
            strFechaControl = ""
            strLugarControl = ""
            strTelefonoMedico = ""
        End Sub
    End Class
End Namespace
