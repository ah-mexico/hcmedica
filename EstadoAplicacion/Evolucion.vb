Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion

Namespace Sophia.HistoriaClinica.Controles
    ''' -----------------------------------------------------------------------------
    ''' Project	 : HistoriaClinica.Evolucion
    ''' Class	 : Sophia.HistoriaClinica.Evolucion
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Clase Evolucion del namespace Sophia.HistoriaClinica.Controles.Evolucion que es la clase base
    ''' Esta clase se utiliza para almacenar la información correspondiente control Evolucion
    ''' y se utilizará en la aplicación Window 2005 para el control ctlEvolucion
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' [mvargas]	10/05/2006 Created
    ''' </history>
    Public Class Evolucion
        Implements IDisposable

        Public Enum TipoEvolucion
            Ingreso = 1
            Evolucion = 2
            Interconsulta = 3
            NotaAdicional = 4
            VisitaFallida = 5
            AdministracionMedicamentos = 6
            CuracionMayor = 7
            CuracionMediana = 8
            CuracionMenor = 9
            InterconsultaNP = 10 '--CCGUTIEREZ. 26/04/2020 
        End Enum


        Public Enum EstadoInterconsulta
            SinResponder = 1
            PendienteCierre = 2
            Cerrada = 3
        End Enum

        Private Shared _Instancia As Evolucion
        '// Para controlar el estado (Nuevo, Modificado) \\
        Private strEstado As String
        Private _COD_PRE_SGS As String
        Private _COD_SUCUR As String
        Private _TIP_DOC As String
        Private _NUM_DOC As String
        Private _TIP_ADMISION As String
        Private _ANO_ADM As Integer
        Private _NUM_ADM As Decimal
        Private _LOGIN As String
        Private cdtEvolucion As DataTable
        Private strDiagnostico As String
        Private strSubjetivo As String
        Private strParaclinico As String
        Private strObjetivo As String
        Private strNotasIngreso As String ''Claudia Garay 
        Private strPlanManejo As String
        Private strFecha As String
        Private intHora As Integer
        Private intMinuto As Integer
        Private strexp_pla As String
        Private strcon_med As String
        Private medicoacompa As String
        Private _Interconsulta As String
        Private _Analisis As String

        '// Para almacenar la información relacionada con los diagnósticos en los Egresos \\
        Private cdtDiagnosticoEvo As DataTable


        '// Constructor \\
        Public Sub New()

        End Sub

        Public Shared ReadOnly Property Instancia() As Evolucion
            Get
                If _Instancia Is Nothing Then
                    _Instancia = New Evolucion
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
        Public Property COD_PRE_SGS() As String
            Get
                Return _COD_PRE_SGS
            End Get
            Set(ByVal VALUE As String)
                _COD_PRE_SGS = VALUE
            End Set
        End Property

        Public Property COD_SUCUR() As String
            Get
                Return _COD_SUCUR
            End Get
            Set(ByVal VALUE As String)
                _COD_SUCUR = VALUE
            End Set
        End Property

        Public Property TIP_DOC() As String
            Get
                Return _TIP_DOC
            End Get
            Set(ByVal VALUE As String)
                _TIP_DOC = VALUE
            End Set
        End Property

        Public Property NUM_DOC() As String
            Get
                Return _NUM_DOC
            End Get
            Set(ByVal VALUE As String)
                _NUM_DOC = VALUE
            End Set
        End Property

        Public Property TIP_ADMISION() As String
            Get
                Return _TIP_ADMISION
            End Get
            Set(ByVal VALUE As String)
                _TIP_ADMISION = VALUE
            End Set
        End Property

        Public Property ANO_ADM() As Integer
            Get
                Return _ANO_ADM
            End Get
            Set(ByVal VALUE As Integer)
                _ANO_ADM = VALUE
            End Set
        End Property

        Public Property NUM_ADM() As Decimal
            Get
                Return _NUM_ADM
            End Get
            Set(ByVal VALUE As Decimal)
                _NUM_ADM = VALUE
            End Set
        End Property

        Public Property LOGIN() As String
            Get
                Return _LOGIN
            End Get
            Set(ByVal VALUE As String)
                _LOGIN = VALUE
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
        Public Property Subjetivo() As String
            Get
                Return strSubjetivo
            End Get
            Set(ByVal value As String)
                strSubjetivo = value
            End Set
        End Property
        Public Property Paraclinico() As String
            Get
                Return strParaclinico
            End Get
            Set(ByVal value As String)
                strParaclinico = value
            End Set
        End Property
        Public Property Objetivo() As String
            Get
                Return strObjetivo
            End Get
            Set(ByVal value As String)
                strObjetivo = value
            End Set
        End Property
        Public Property NotasIngreso() As String
            Get
                Return strNotasIngreso
            End Get
            Set(ByVal value As String)
                strNotasIngreso = value
            End Set
        End Property
        Public Property Analisis() As String
            Get
                Return _Analisis
            End Get
            Set(ByVal value As String)
                _Analisis = value
            End Set
        End Property

        Public Property PlanManejo() As String
            Get
                Return strPlanManejo
            End Get
            Set(ByVal value As String)
                strPlanManejo = value
            End Set
        End Property
        Public Property Fecha() As String
            Get
                Return strFecha
            End Get
            Set(ByVal value As String)
                strFecha = value
            End Set
        End Property
        Public Property Hora() As Integer
            Get
                Return intHora
            End Get
            Set(ByVal value As Integer)
                intHora = value
            End Set
        End Property
        Public Property Minuto() As Integer
            Get
                Return intMinuto
            End Get
            Set(ByVal value As Integer)
                intMinuto = value
            End Set
        End Property

        Public Property exp_pla() As String
            Get
                Return strexp_pla
            End Get
            Set(ByVal value As String)
                strexp_pla = value
            End Set
        End Property
        ''Claudia Garay 
        ''Medico Residente Cambios Acreditacion
        ''Abril 5 de 2011
        Public Property MedicoAcompanaResidente() As String
            Get
                Return medicoacompa
            End Get
            Set(ByVal value As String)
                medicoacompa = value
            End Set
        End Property
        Public Property Interconsulta() As String
            Get
                Return _Interconsulta
            End Get
            Set(ByVal value As String)
                _Interconsulta = value
            End Set
        End Property

        Public Property con_med() As String
            Get
                Return strcon_med
            End Get
            Set(ByVal value As String)
                strcon_med = value
            End Set
        End Property
        Private _Especialidad As String
        Public Property Especialidad() As String
            Get
                Return _Especialidad
            End Get
            Set(ByVal value As String)
                _Especialidad = value
            End Set
        End Property
        Private _Medico As String
        Public Property Medico() As String
            Get
                Return _Medico
            End Get
            Set(ByVal value As String)
                _Medico = value
            End Set
        End Property

        Private _Motivo As String
        Public Property Motivo() As String
            Get
                Return _Motivo
            End Get
            Set(ByVal value As String)
                _Motivo = value
            End Set
        End Property

        Private _Cierre As String
        Public Property Cierre() As String
            Get
                Return _Cierre
            End Get
            Set(ByVal value As String)
                _Cierre = value
            End Set
        End Property


        Private _EspecMedSol As String
        Public Property EspecMedSol() As String
            Get
                Return _EspecMedSol
            End Get
            Set(ByVal value As String)
                _EspecMedSol = value
            End Set
        End Property
        Private _NroOrden As String
        Public Property NroOrden() As String
            Get
                Return _NroOrden
            End Get
            Set(ByVal value As String)
                _NroOrden = value
            End Set
        End Property

        Private _Procedimiento As String
        Public Property Procedimiento() As String
            Get
                Return _Procedimiento
            End Get
            Set(ByVal value As String)
                _Procedimiento = value
            End Set
        End Property

        Private _IdTipoEvolucion As Integer
        Public Property IdTipoEvolucion() As Integer
            Get
                Return _IdTipoEvolucion
            End Get
            Set(ByVal value As Integer)
                _IdTipoEvolucion = value
            End Set
        End Property





        Public Property dtEvolucion() As DataTable
            Get
                Return cdtEvolucion
            End Get
            Set(ByVal value As DataTable)
                cdtEvolucion = value
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

        Public Property dtDiagnosticoEvo() As DataTable
            Get
                Return cdtDiagnosticoEvo
            End Get
            Set(ByVal value As DataTable)
                cdtDiagnosticoEvo = value
            End Set
        End Property

        Private _dtInterconsultas As DataTable
        Public Property dtInterconsultas() As DataTable
            Get
                Return _dtInterconsultas
            End Get
            Set(ByVal value As DataTable)
                _dtInterconsultas = value
            End Set
        End Property

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
            strDiagnostico = ""
            strSubjetivo = ""
            strParaclinico = ""
            strObjetivo = ""
            strPlanManejo = ""
            strFecha = ""
            strexp_pla = ""
            strcon_med = ""
            intHora = 0
            intMinuto = 0
            cdtEvolucion = Nothing
            cdtDiagnosticoEvo = Nothing
        End Sub

        Public Function ValidaEspDietaAislamiento(ByVal objConexion As Conexion, ByRef lError As Long, ByVal sEspecialidad As String) As Boolean
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim Param() As Object
            Dim dtEspAutoIC As DataTable

            ReDim Param(0)
            Param(0) = sEspecialidad
            dtEspAutoIC = obj.EjecutarSPConParametros("HC_EV_GET_ESP_VALIDA_DIETA_AISLAMIENTO", objConexion, lError, Param)

            If dtEspAutoIC.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function ValidaEspecialidadSignoVital(ByVal objConexion As Conexion, ByRef lError As Long, ByVal sEspecialidad As String) As Boolean
            Try


                Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
                Dim Param() As Object
                Dim dtEspSigVital As DataTable

                ReDim Param(0)
                Param(0) = sEspecialidad
                dtEspSigVital = obj.EjecutarSPConParametros("HC_EV_GET_ESP_VALIDA_SIG_VITAL", objConexion, lError, Param)

                If dtEspSigVital.Rows.Count = 0 Then
                    Return False
                Else
                    Return True
                End If
            Catch ex As Exception
                Return True
            End Try
        End Function


#Region "GrabarEVolucion"

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Proceso de grabar datos de la evolucion(procedimiento HC_GrabarEvolucion)
        ''' </summary>
        ''' <param name="objConexion">Parámetro de tipo conexion</param>
        ''' <param name="strDiagnostico">Parámetro de tipo string que indica el código del diagnóstico</param>
        ''' <param name = "strObjetivo">Parámetro de tipo string que indica el objetivo</param>
        ''' <param name = "strParaclinico">Parámetro de tipo string que indica el resumen paraclínico</param>
        ''' <param name = "strPlanManejo">Parámetro de tipo string que indica el resumen del plan de manejo</param>
        ''' <param name="dNumeroAdmin">Parámetro de tipo doubled que indica el número de admisión</param>
        ''' <param name="intAnoAdmin">Parámetro de tipo entero que indica el año de admisión</param>
        ''' <param name="intHora">Parámetro de tipo entero que indica la hora de evolución</param>
        ''' <param name="intMinuto">Parámetro de tipo entero que indica el minuto de la evolución</param>
        ''' <param name="strFecha">Parámetro de tipo string que indica la fecha de la evolución</param>
        ''' <param name="strLogin">Parámetro de tipo string que indica el login</param>
        ''' <param name="strNumDocumento">Parámetro de tipo string que indica el número del documento</param>
        ''' <param name="strPrestador">Parámetro de tipo string que indica el prestador</param>
        ''' <param name="strSubjetivo">Parámetro de tipo string que indica el resumen subjetivo</param>
        ''' <param name="strSucursal">Parámetro de tipo string que indica la sucursal</param>
        ''' <param name="strTipoAdmin">Parámetro de tipo string que indica el tipo de admisión</param>
        ''' <param name="strTipoDocumento">Parámetro de tipo string que indica el tipo de documento</param>
        ''' <returns>long con respuesta de la operación
        ''' <param name = "strFecha">Parámetro de tipo string que indica la fecha</param>
        ''' <param name = "intHora">Parámetro de tipo entero que indica la hora</param>
        ''' <param name = "intMinuto">Parámetro de tipo entero que indica el minuto</param>
        '''</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mvargas] 09/05/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------

        Public Function GrabarEvolucion(ByVal objConexion As Conexion, ByVal oEvolucion As Evolucion) As Long


            Dim lError As Long
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim Param() As Object

            ReDim Param(29)

            Param(0) = oEvolucion.COD_PRE_SGS
            Param(1) = oEvolucion.COD_SUCUR
            Param(2) = oEvolucion.TIP_DOC
            Param(3) = oEvolucion.NUM_DOC
            Param(4) = oEvolucion.TIP_ADMISION
            Param(5) = oEvolucion.ANO_ADM
            Param(6) = oEvolucion.NUM_ADM
            Param(7) = oEvolucion.LOGIN
            Param(8) = oEvolucion.Diagnostico
            Param(9) = oEvolucion.Objetivo
            Param(10) = oEvolucion.Paraclinico
            Param(11) = oEvolucion.PlanManejo
            Param(12) = oEvolucion.Subjetivo
            Param(13) = oEvolucion.NotasIngreso
            Param(14) = oEvolucion.Fecha
            Param(15) = oEvolucion.Hora
            Param(16) = oEvolucion.Minuto
            Param(17) = oEvolucion.exp_pla
            Param(18) = oEvolucion.con_med
            Param(19) = oEvolucion.Interconsulta
            Param(20) = oEvolucion.Especialidad
            Param(21) = oEvolucion.Medico
            Param(22) = oEvolucion.Motivo
            Param(23) = oEvolucion.Cierre
            Param(24) = oEvolucion.EspecMedSol
            Param(25) = lError
            Param(26) = oEvolucion.NroOrden
            Param(27) = oEvolucion.IdTipoEvolucion
            Param(28) = oEvolucion.Procedimiento
            Param(29) = oEvolucion.Analisis

            Return lError = obj.EjecutarSPConParametrosTran("HC_GrabarEvolucion", objConexion, Param)

        End Function
#End Region
    End Class
End Namespace