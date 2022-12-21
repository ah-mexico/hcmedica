Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.BL

Namespace Sophia.HistoriaClinica.DatosGenerales
    '''-----------------------------------------------------------------------------
    ''' Project	 : HistoriaClinica
    ''' Class	 : Sophia.HistoriaClinica.DatosGenerales
    ''' -----------------------------------------------------------------------------
    ''' <summary>º
    ''' Clase Generales del namespace Sophia.HistoriaClinica.Comunes que es la clase base
    ''' Esta clase se utiliza para almacenar la información general o valores globales
    ''' generales utilizados en la aplicación Window 2005
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[mvargas]	27/03/2006 - 6/27/2006	Created - Modified
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class Generales
        Implements IDisposable


        '// Propiedades \\
        Private _strCadena As String
        Private _strCadenaLocal As String
        Private _strCodPreSgs As String
        Private _strCodSucur As String
        Private _strLogin As String
        Private _tipoUsuario As String
        Private _strEspecialidad As String
        Private _descripEspecialidad As String
        Private _strCentroCosto As String
        Private _strNombreMedico As String
        Private _strRegistroMedico As String
        Private _strFormatoFechaCorta As String
        Private _strFormatoFechaLargo As String
        Private _strCiudad As String
        Private _strDepartamento As String
        Private _strDescripcionDepartamento As String
        Private _strPais As String
        Private _strDescripcionPais As String
        Private _bContingencia As Boolean
        Private _bManejaRips As Boolean
        Private _strCorreccion As String
        Private _strVersion As String
        Private _soloconsulta As Boolean
        Private _soloconsultaFarma As Boolean

        'TODO: Pendientes por inicializar
        Private _strDescripcionPrestador As String
        Private _strDescripcionSucursal As String
        Private _strDescripcionCentroCosto As String
        Private _strDescripcionCiudad As String

        'CDQF
        Private _strNoVademecum As Boolean

        Private _blnEstadoInstancia As Boolean
        Private Shared _Instancia As Generales


#Region "Propiedades"
        Public Property Cadena() As String
            Get
                Return _strCadena
            End Get
            Set(ByVal value As String)
                _strCadena = value
            End Set
        End Property

        Public Property CadenaLocal() As String
            Get
                Return _strCadenaLocal
            End Get
            Set(ByVal value As String)
                _strCadenaLocal = value
            End Set
        End Property

        Public Property Prestador() As String
            Get
                Return _strCodPreSgs
            End Get
            Set(ByVal value As String)
                _strCodPreSgs = value
            End Set
        End Property

        Public Property DescripcionPrestador() As String
            Get
                Return _strDescripcionPrestador
            End Get
            Set(ByVal Value As String)
                _strDescripcionPrestador = Value
            End Set
        End Property

        Public Property Sucursal() As String
            Get
                Return _strCodSucur
            End Get
            Set(ByVal value As String)
                _strCodSucur = value
            End Set
        End Property

        Public Property DescripcionSucursal() As String
            Get
                Return _strDescripcionSucursal
            End Get
            Set(ByVal Value As String)
                _strDescripcionSucursal = Value
            End Set
        End Property

        Public Property Login() As String
            Get
                Return _strLogin
            End Get
            Set(ByVal value As String)
                _strLogin = value
            End Set
        End Property
        Public Property TipoUsuario() As String
            Get
                Return _tipoUsuario
            End Get
            Set(ByVal Value As String)
                _tipoUsuario = Value
            End Set
        End Property
        Public Property CodigoEspecialidad() As String
            Get
                Return _strEspecialidad
            End Get
            Set(ByVal value As String)
                _strEspecialidad = value
            End Set
        End Property
        Public Property DescripcionEspecialidad() As String
            Get
                Return _descripEspecialidad
            End Get
            Set(ByVal Value As String)
                _descripEspecialidad = Value
            End Set
        End Property

        Public Property CentroCosto() As String
            Get
                Return _strCentroCosto
            End Get
            Set(ByVal value As String)
                _strCentroCosto = value
            End Set
        End Property

        Public Property DescripcionCentroCosto() As String
            Get
                Return _strDescripcionCentroCosto
            End Get
            Set(ByVal Value As String)
                _strDescripcionCentroCosto = Value
            End Set
        End Property

        Public Property NombreMedico() As String
            Get
                Return _strNombreMedico
            End Get
            Set(ByVal value As String)
                _strNombreMedico = value
            End Set
        End Property

        Public Property RegistroMedico() As String
            Get
                Return _strRegistroMedico
            End Get
            Set(ByVal value As String)
                _strRegistroMedico = value
            End Set
        End Property

        Public Property FormatoFechaCorta() As String
            Get
                Return _strFormatoFechaCorta
            End Get
            Set(ByVal value As String)
                _strFormatoFechaCorta = value
            End Set
        End Property

        Public Property FormatoFechaLargo() As String
            Get
                Return _strFormatoFechaLargo
            End Get
            Set(ByVal value As String)
                _strFormatoFechaLargo = value
            End Set
        End Property

        Public Property Ciudad() As String
            Get
                Return _strCiudad
            End Get
            Set(ByVal value As String)
                _strCiudad = value
            End Set
        End Property

        Public Property DescripcionCiudad() As String
            Get
                Return _strDescripcionCiudad
            End Get
            Set(ByVal Value As String)
                _strDescripcionCiudad = Value
            End Set
        End Property


        Public Property Departamento() As String
            Get
                Return _strDepartamento
            End Get
            Set(ByVal value As String)
                _strDepartamento = value
            End Set
        End Property
        Public Property DescripcionDepartamento() As String
            Get
                Return _strDescripcionDepartamento
            End Get
            Set(ByVal value As String)
                _strDescripcionDepartamento = value
            End Set
        End Property
        Public Property Pais() As String
            Get
                Return _strPais
            End Get
            Set(ByVal value As String)
                _strPais = value
            End Set
        End Property
        Public Property DescripcionPais() As String
            Get
                Return _strDescripcionPais
            End Get
            Set(ByVal value As String)
                _strDescripcionPais = value
            End Set
        End Property

        Public Property EstadoInstancia() As Boolean
            Get
                Return _blnEstadoInstancia
            End Get
            Set(ByVal Value As Boolean)
                _blnEstadoInstancia = Value
            End Set
        End Property
        '/ para determinar si el sistema está en contingenci y 
        ' y poder modificar fechas \
        Public Property Contingencia() As Boolean
            Get
                Return _bContingencia
            End Get
            Set(ByVal value As Boolean)
                _bContingencia = value
            End Set
        End Property

        Public Property ManejaRips() As Boolean
            Get
                Return _bManejaRips
            End Get
            Set(ByVal value As Boolean)
                _bManejaRips = value
            End Set
        End Property

        Public Property strNoVademecum() As Boolean
            Get
                Return _strNoVademecum
            End Get
            Set(ByVal value As Boolean)
                _strNoVademecum = value
            End Set
        End Property


        Private _blnHistoriaClinicaTieneModificaciones As Boolean
        Public Property HistoriaClinicaTieneModificaciones() As Boolean
            Get
                Return _blnHistoriaClinicaTieneModificaciones
            End Get
            Set(ByVal Value As Boolean)
                _blnHistoriaClinicaTieneModificaciones = Value
            End Set
        End Property

        Public Property MedicoRealizaCorreccion() As String
            Get
                Return _strCorreccion
            End Get
            Set(ByVal Value As String)
                _strCorreccion = Value
            End Set
        End Property

        Public Property SoloConsulta() As Boolean
            Get
                Return _soloconsulta
            End Get
            Set(ByVal value As Boolean)
                _soloconsulta = value
            End Set
        End Property
        ''cpgaray OS 7531913 farmacia solo puede consultar ordenes médicas
        Public Property SoloConsultaFarma() As Boolean
            Get
                Return _soloconsultaFarma
            End Get
            Set(ByVal value As Boolean)
                _soloconsultaFarma = value
            End Set
        End Property

        Public Property Version() As String
            Get
                Return _strVersion
            End Get
            Set(ByVal value As String)
                _strVersion = value
            End Set
        End Property

        ''' <summary>
        ''' Servidor de Reportes para la Historia Clínica
        ''' </summary>
        Private _srv_rpt_sophia As String
        ''' <summary>
        ''' Servidor de Reportes para la Historia Clínica
        ''' </summary>
        ''' <returns></returns>
        Public Property Srv_Rpt_Sophia() As String
            Get
                Return _srv_rpt_sophia
            End Get
            Set(ByVal value As String)
                _srv_rpt_sophia = value
            End Set
        End Property

        ''' <summary>
        ''' Ruta del Servidor de Reportes
        ''' </summary>
        Private _ruta_rpt_sophia As String
        ''' <summary>
        ''' Ruta del Servidor de Reportes
        ''' </summary>
        ''' <returns></returns>
        Public Property Ruta_Rpt_Sophia() As String
            Get
                Return _ruta_rpt_sophia
            End Get
            Set(ByVal value As String)
                _ruta_rpt_sophia = value
            End Set
        End Property
        ''' <summary>
        ''' Usuario del servidor de reportes
        ''' </summary>
        Private _usr_rpt_sophia As String
        ''' <summary>
        ''' Usuario del servidor de reportes
        ''' </summary>
        ''' <returns></returns>
        Public Property Usr_Rpt_Sophia() As String
            Get
                Return _usr_rpt_sophia
            End Get
            Set(ByVal value As String)
                _usr_rpt_sophia = value
            End Set
        End Property
        ''' <summary>
        ''' Password del Usuario del servidor de reportes
        ''' </summary>
        Private _pwd_rpt_sophia As String
        ''' <summary>
        ''' Password del Usuario del servidor de reportes
        ''' </summary>
        ''' <returns></returns>
        Public Property Pwd_Rpt_Sophia() As String
            Get
                Return _pwd_rpt_sophia
            End Get
            Set(ByVal value As String)
                _pwd_rpt_sophia = value
            End Set
        End Property
        ''' <summary>
        ''' Dominio del usuario
        ''' </summary>
        Private _dom_rpt_sophia As String
        ''' <summary>
        ''' Dominio del usuario
        ''' </summary>
        ''' <returns></returns>
        Public Property Dom_Rpt_Sophia() As String
            Get
                Return _dom_rpt_sophia
            End Get
            Set(ByVal value As String)
                _dom_rpt_sophia = value
            End Set
        End Property

        ''' <summary>
        ''' Dominio del usuario
        ''' </summary>
        Private _reportingService As Integer
        ''' <summary>
        ''' Dominio del usuario
        ''' </summary>
        ''' <returns></returns>
        Public Property ReportingService() As Integer
            Get
                Return _reportingService
            End Get
            Set(ByVal value As Integer)
                _reportingService = value
            End Set
        End Property
        ''' <summary>
        ''' Servidor Origen de la Admisión
        ''' </summary>
        Private _OrigenAdm As String
        ''' <summary>
        ''' Servidor Origen de la Admisión
        ''' </summary>
        ''' <returns></returns>
        Public Property OrigenAdm() As String
            Get
                Return _OrigenAdm
            End Get
            Set(ByVal value As String)
                _OrigenAdm = value
            End Set
        End Property
#End Region

        ''' <summary>
        ''' Funcion que devuelve la instancia de la clase Generales, si no tiene instancia
        ''' crea una, si no devuelve la existente
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared ReadOnly Property Instancia() As Generales
            Get
                If _Instancia Is Nothing Then
                    _Instancia = New Generales
                End If
                Return _Instancia
            End Get
        End Property

        '// Métododos \\
        '// Constructor \\
        Private Sub New()
            _blnHistoriaClinicaTieneModificaciones = False
        End Sub

        ''' <summary>cargarParametrosIniciales
        ''' Carga los parametros iniciales pasados desde sophia por medio de un xml
        ''' e inicializa tanto la conexion como el objeto de datos generales
        ''' </summary>
        ''' <param name="xmlParametros">Documento xml que contiene la informacion de los parametros iniciales</param>
        ''' <param name="objConexion">Objeto que encapsula los datos de la conexion</param>
        ''' <returns>Si hay un error retorna un numero asocioado</returns>
        ''' <remarks></remarks>
        Public Function cargarParametrosIniciales(ByVal xmlParametros As String, Optional ByRef objConexion As conexion = Nothing) As Integer

            Dim DSParametros As New DataSet
            Dim DTParametros As New DataTable
            Dim strContingencia As String
            Dim strManejaRIPS As String
            Dim xmlSR As System.IO.StringReader = New System.IO.StringReader(xmlParametros)

            ''Se mete codigo en un bloque try catch para capturar el error en cnexion de medellin
            ''Claudia Garay
            ''24 feb 2010
            Try

                DSParametros.ReadXml(xmlSR, XmlReadMode.InferSchema)
                If DSParametros.Tables.Count > 0 Then
                    DTParametros = DSParametros.Tables(0)
                Else
                    ''Retorna el error pues no cargo los datos
                    Return 1
                End If

                With DTParametros.Rows(0)

                    If Not objConexion Is Nothing Then
                        objConexion.strServidor = .Item("Servidor").ToString
                        objConexion.strBaseDatos = .Item("BaseDatos").ToString
                        objConexion.strUsuarioBD = .Item("UserID").ToString
                        objConexion.strClaveUsuarioBD = .Item("PWD").ToString
                        objConexion.EstadoInstancia = True
                    End If

                    _strCodPreSgs = .Item("prestadora").ToString
                    _strDescripcionPrestador = .Item("des_prestadora").ToString
                    _strCodSucur = .Item("sucursal").ToString
                    _strDescripcionSucursal = .Item("des_sucursal").ToString
                    _strLogin = .Item("Login").ToString
                    _tipoUsuario = .Item("TipoUsuario").ToString
                    _strNombreMedico = .Item("nom_medico").ToString
                    _strEspecialidad = .Item("especialidad").ToString
                    _descripEspecialidad = .Item("des_especialidad").ToString
                    _strRegistroMedico = .Item("reg_medico").ToString
                    _strCentroCosto = .Item("cen_costo").ToString
                    _strCiudad = .Item("ciudad").ToString
                    _strDescripcionCiudad = .Item("des_ciudad").ToString
                    _strDepartamento = .Item("depart").ToString
                    _strDescripcionDepartamento = .Item("des_depart").ToString
                    _strPais = .Item("pais").ToString
                    _strDescripcionPais = .Item("des_pais").ToString
                    strContingencia = .Item("contingencia").ToString
                    _bContingencia = IIf(UCase(strContingencia) = "S", True, False)
                    strManejaRIPS = .Item("man_rips").ToString
                    _bManejaRips = IIf(UCase(strManejaRIPS) = "S", True, False)
                    _strCorreccion = .Item("Corregir").ToString
                    '_strVersion = .Item("Version").ToString
                End With

                _strFormatoFechaCorta = "yyyy/MM/dd"
                _strFormatoFechaLargo = "yyyy/MM/dd HH:mm:ss.fff"
                Dim strDir As String = System.Environment.SystemDirectory.ToString

                _strCadenaLocal = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strDir & "\SOPHIA\Sophia.mdb"
                'Indica que ya se cargaron los datos del objeto
                _blnEstadoInstancia = True

                ConsultarServidorReporte(objConexion)

                Return 0
            Catch ex As Exception
                MsgBox(ex.Message & "   " & ex.StackTrace)
            End Try

        End Function

        Public Sub ConsultarServidorReporte(ByVal objConexion As Conexion)
            Dim objDatosMC As New BLHistoriaBasica
            Dim Datos() As Object
            Dim lError As Long
            Dim dtConfigServidorReporte As DataTable

            ReDim Datos(2)
            Datos(0) = "HCL_RPT_RUTA_SOPHIA" 'String.Empty
            Datos(1) = 0

            Try
                dtConfigServidorReporte = objDatosMC.ConsultarServidorReporte(objConexion, lError, Datos)

                If dtConfigServidorReporte.Rows.Count Then
                    _srv_rpt_sophia = dtConfigServidorReporte.Rows(0)("Servidor")
                    _ruta_rpt_sophia = dtConfigServidorReporte.Rows(0)("Ruta")
                    _dom_rpt_sophia = dtConfigServidorReporte.Rows(0)("Dominio")
                    _usr_rpt_sophia = dtConfigServidorReporte.Rows(0)("Usuario")
                    _pwd_rpt_sophia = dtConfigServidorReporte.Rows(0)("Password")
                    _reportingService = dtConfigServidorReporte.Rows(0)("ReportingService")
                    _OrigenAdm = dtConfigServidorReporte.Rows(0)("OrigenAdm")
                End If

                If lError <> 0 Then
                    MessageBox.Show("Error al Consultar la configuración del servidor de reportes")
                    'blnFallaConsultaDatosMC = True
                End If

            Catch ex As Exception
                MessageBox.Show("Error al Consultar la configuración del servidor de reportes")
            End Try
        End Sub

        Public Function ValidadAdmTrasladada(ByVal objConexion As Conexion, ByVal Cod_pre_sgs As String,
                                                          ByVal Cod_sucur As String, ByVal Tip_Admision As String,
                                                          ByVal Ano_Adm As Integer, ByVal Num_Adm As Double) As String
            Dim oDLEvolucion As New DAO.DAOEvolucion

            Return oDLEvolucion.ValidadAdmTrasladada(objConexion, Cod_pre_sgs, Cod_sucur, Tip_Admision, Ano_Adm, Num_Adm)
        End Function

        '/ para destruir objeto \

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

    End Class
End Namespace
