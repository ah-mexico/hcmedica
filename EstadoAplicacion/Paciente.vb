Namespace Sophia.HistoriaClinica.DatosPaciente

    ''' -----------------------------------------------------------------------------
    ''' Project	 : HistoriaClinica.Paciente
    ''' Class	 : Sophia.HistoriaClinica.Paciente
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Clase Paciente del namespace Sophia.HistoriaClinica.Paciente que es la clase base
    ''' Esta clase se utiliza para almacenar la información global del paciente 
    ''' y se utilizados en la aplicación Window 2005 para egresos
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' [mvargas]	06/05/2006 Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class Paciente
        Implements IDisposable

        Private _strTipoDocumento As String
        Private _strNumDocumento As String
        Private _strNombre As String
        Private _strPriApe As String
        Private _strSegApe As String
        Private _strPriNom As String
        Private _strSegNom As String
        Private _strGenero As String
        Private _strTipoAdmision As String
        Private _intAnoAdmision As Integer
        Private _lNumeroAdmision As Long
        Private _bReingreso As Boolean
        Private _intEdad As Integer
        Private _tipoAdmision As String
        Private Shared _Instancia As Paciente
        Private _strTipoConsultorio As String
        Private _fotoPaciente As Bitmap
        Private _strConsultorio As String
        Private _strFechaIngresoAdm As String
        Private _intHoraIngresoAdm As Integer
        Private _intMinutoIngresoAdm As Integer
        Private _strClasificacionTriage As String
        Private _strCodUnidadMedidaEdad As String
        Private _strDescripcionUnidadMedidaEdad As String
        Private _strCodigoOcupacionPaciente As String
        Private _strDescripcionOcupacionPaciente As String
        Private _strFechaNacimiento As String
        Private _strGrupoSanguineo As String
        Private _strRH As String
        Private _strTipoUnificacion As String
        Private _dtDocsUnif As DataTable
        Private _estadoInicialHistoria As String
        Private _blnEstadoInstancia As Boolean
        Private _strTipoHistoria As String
        Private _strDescripcionTipoHistoria As String
        Private _strFechaHistoriaClinica As String
        Private _intHoraHistoriaClinica As Integer
        Private _intMinutoHistoriaClinica As String
        Private _strEntidad As String
        Private _strDescripcionEntidad As String
        Private _strFechaCita As String
        Private _intHoraCita As Integer
        Private _intMinutoCita As String
        Private _strIdentificadorCama As String
        Private _strFechaAtencionProcedimiento As String
        Private _intHoraAtencionProcedimiento As String
        Private _intMinutoAtencionProcedimiento As String
        Private _strEstadoAdmision As String
        Private _strManejaConvenio As String
        Private _blnHistoriaTieneEgreso As Boolean
        Private _strXMLDocumentosUnificados As String
        Private _strDescripcionTipoDocumento As String
        Private _strTipoUsuario As String
        Private _dtHC_Erradas As DataTable
        Private _strTipoEntidad As String
        Private _strDescripcionGenero As String
        Private _Carnet As String
        Private _Cama As String
        Private _esCronico As String  ''Claudia Garay 22/12/2009
        Private _codhistoria As String ''Claudia Garay Enfermeria 25 septiembre de 2010
        Private _ciudad As String
        Private _pais As String
        Private _dirSucursal As String
        Private _telSucursal As String
#Region "cariasm Cambios HCBasica" '2017-06-14
        ''' <summary>
        ''' Admision del paciente
        ''' </summary>
        ''' <remarks></remarks>
        Private _Admision As String
        Public Property Admision() As String
            Get
                Return _Admision
            End Get
            Set(ByVal value As String)
                _Admision = value
            End Set
        End Property
        ''' <summary>
        ''' Edad en Años Meses y días del paciente
        ''' </summary>
        ''' <remarks></remarks>
        Private _EdadAMD As String
        Public Property EdadAMD() As String
            Get
                Return _EdadAMD
            End Get
            Set(ByVal value As String)
                _EdadAMD = value
            End Set
        End Property
        ''' <summary>
        ''' Nombre completo del paciente
        ''' </summary>
        ''' <remarks></remarks>
        Private _NombreCompleto As String
        Public Property NombreCompleto() As String
            Get
                Return _NombreCompleto
            End Get
            Set(ByVal value As String)
                _NombreCompleto = value
            End Set
        End Property
        ''' <summary>
        ''' Grupo Sanguineo y RH del paciente
        ''' </summary>
        ''' <remarks></remarks>
        Private _GrupoRH As String
        Public Property GrupoRH() As String
            Get
                Return _GrupoRH
            End Get
            Set(ByVal value As String)
                _GrupoRH = value
            End Set
        End Property
        ''' <summary>
        ''' Religión del paciente
        ''' </summary>
        ''' <remarks></remarks>
        Private _Religion As String
        Public Property Religion() As String
            Get
                Return _Religion
            End Get
            Set(ByVal value As String)
                _Religion = value
            End Set
        End Property
        ''' <summary>
        ''' Fecha y Hora de admisión del paciente
        ''' </summary>
        ''' <remarks></remarks>
        Private _FechaHoraAdmision As String
        Public Property FechaHoraAdmision() As String
            Get
                Return _FechaHoraAdmision
            End Get
            Set(ByVal value As String)
                _FechaHoraAdmision = value
            End Set
        End Property
        ''' <summary>
        ''' Ubicación del paciente
        ''' </summary>
        ''' <remarks></remarks>
        Private _Ubicacion As String
        Public Property Ubicacion() As String
            Get
                Return _Ubicacion
            End Get
            Set(ByVal value As String)
                _Ubicacion = value
            End Set
        End Property

#End Region

        

        ''' <summary>
        ''' Tipo de paciente que tiene una edad mayor de 14 años 
        ''' </summary>
        ''' <remarks></remarks>
        Public Const ADULTO As String = "ADULTO"
        ''' <summary>
        ''' Tipo de paciente que tiene una edad menor o igual de 14 años
        ''' </summary>
        ''' <remarks></remarks>
        Public Const PEDIATRICO As String = "PEDIATRICO"
        ''' <summary>
        ''' Tipo de estado de la historia clinica el que el paciente
        ''' se deja en observacion 
        ''' </summary>
        ''' <remarks></remarks>
        Public Const OBSERVACION As String = "O"
        ''' <summary>
        ''' Tipo de estado de la historia clinica el que el paciente
        ''' se deja pendiente para ingresar informacion adicional 
        ''' </summary>
        ''' <remarks></remarks>
        Public Const PENDIENTE As String = "P"
        ''' <summary>
        ''' Tipo de estado de la historia clinica que se encuentra en 
        ''' lista de espera
        ''' </summary>
        ''' <remarks></remarks>
        Public Const ENLISTAESPERA As String = "L"
        ''' <summary>
        ''' Tipos de admision 
        ''' </summary>
        ''' <remarks></remarks>
        Public Const HOSPITALIZACION As String = "H"
        Public Const URGENCIAS As String = "U"
        Public Const CIRUGIA As String = "A"
        Public Const CONSULTAEXTERNA As String = "E"
        Public Const ADT As String = "P"
        ''' <summary>
        ''' Aplicación que consume el servicio de Cuidados Paliativos
        ''' </summary>
        ''' <remarks></remarks>
        Public Const AppOrigenCP As String = "SOPHIA"

#Region "Propiedades"

        Public Shared ReadOnly Property Instancia() As Paciente
            Get
                If _Instancia Is Nothing Then
                    _Instancia = New Paciente
                End If
                Return _Instancia
            End Get
        End Property
        Private Sub New()

        End Sub
        ''Claudia Garay Enfermeria 25 septiembre de 2010 Codigo identificador de la HC
        Public Property CodHistoria() As String
            Get
                Return _codhistoria
            End Get
            Set(ByVal value As String)
                _codhistoria = value
            End Set
        End Property

        Public Property TipoDocumento() As String
            Get
                Return _strTipoDocumento
            End Get
            Set(ByVal value As String)
                _strTipoDocumento = value
            End Set
        End Property

        Public Property DescripcionTipoDocumento() As String
            Get
                Return _strDescripcionTipoDocumento
            End Get
            Set(ByVal Value As String)
                _strDescripcionTipoDocumento = Value
            End Set
        End Property

        Public Property NumeroDocumento() As String
            Get
                Return _strNumDocumento
            End Get
            Set(ByVal value As String)
                _strNumDocumento = value
            End Set
        End Property
        'cariasm
        'Public ReadOnly Property NombreCompleto() As String
        '    Get
        '        Return _strPriNom.Trim & " " & _strSegNom.Trim & " " & _strPriApe.Trim & " " & _strSegApe.Trim
        '    End Get
        'End Property
        Public Property PrimerApellido() As String
            Get
                Return _strPriApe
            End Get
            Set(ByVal value As String)
                _strPriApe = value
            End Set
        End Property
        Public Property SegundoApellido() As String
            Get
                Return _strSegApe
            End Get
            Set(ByVal value As String)
                _strSegApe = value
            End Set
        End Property

        Public Property PrimerNombre() As String
            Get
                Return _strPriNom
            End Get
            Set(ByVal value As String)
                _strPriNom = value
            End Set
        End Property

        Public Property SegundoNombre() As String
            Get
                Return _strSegNom
            End Get
            Set(ByVal value As String)
                _strSegNom = value
            End Set
        End Property

        Public Property Genero() As String
            Get
                Return _strGenero
            End Get
            Set(ByVal value As String)
                _strGenero = value
                Select Case _strGenero
                    Case "M"
                        _strDescripcionGenero = "MASCULINO"
                    Case "F"
                        _strDescripcionGenero = "FEMENINO"
                    Case "A"
                        _strDescripcionGenero = "AMBOS"
                    Case "I"
                        _strDescripcionGenero = "INDETERMINADO"
                    Case "N"
                        _strDescripcionGenero = "INDETERMINADO"
                End Select
            End Set
        End Property
        Public Property TipoAdmision() As String
            Get
                Return _strTipoAdmision
            End Get
            Set(ByVal value As String)
                _strTipoAdmision = value
            End Set
        End Property
        Public Property AnoAdmision() As Integer
            Get
                Return _intAnoAdmision
            End Get
            Set(ByVal value As Integer)
                _intAnoAdmision = value
            End Set
        End Property
        Public Property NumeroAdmision() As Long
            Get
                Return _lNumeroAdmision
            End Get
            Set(ByVal value As Long)
                _lNumeroAdmision = value
            End Set
        End Property

        Public ReadOnly Property Reingreso() As Boolean
            Get
                If _strTipoHistoria = "V" And _blnHistoriaTieneEgreso Then
                    _bReingreso = True
                Else
                    _bReingreso = False
                End If

                Return _bReingreso
            End Get
        End Property
        Public Property Edad() As Integer
            Get
                Return _intEdad
            End Get
            Set(ByVal value As Integer)
                _intEdad = value
            End Set
        End Property

        Public Property TipoConsultorio() As String
            Get
                Return _strTipoConsultorio
            End Get
            Set(ByVal Value As String)
                _strTipoConsultorio = Value
            End Set
        End Property

        Public Property Consultorio() As String
            Get
                Return _strConsultorio
            End Get
            Set(ByVal Value As String)
                _strConsultorio = Value
            End Set
        End Property

        Public Property FechaIngresoAdmision() As String
            Get
                Return _strFechaIngresoAdm
            End Get
            Set(ByVal Value As String)
                _strFechaIngresoAdm = Value
            End Set
        End Property

        Public Property HoraIngresoAdmision() As Integer
            Get
                Return _intHoraIngresoAdm
            End Get
            Set(ByVal Value As Integer)
                _intHoraIngresoAdm = Value
            End Set
        End Property

        Public Property MinutoIngresoAdmision() As Integer
            Get
                Return _intMinutoIngresoAdm
            End Get
            Set(ByVal Value As Integer)
                _intMinutoIngresoAdm = Value
            End Set
        End Property

        Public Property ClasificacionTriage() As String
            Get
                Return _strClasificacionTriage
            End Get
            Set(ByVal Value As String)
                _strClasificacionTriage = Value
            End Set
        End Property

        Public Property CodigoUnidadMedidaEdad() As String
            Get
                Return _strCodUnidadMedidaEdad
            End Get
            Set(ByVal Value As String)
                _strCodUnidadMedidaEdad = Value
            End Set
        End Property

        Public Property DescripcionUnidadMedidaEdad() As String
            Get
                Return _strDescripcionUnidadMedidaEdad
            End Get
            Set(ByVal Value As String)
                _strDescripcionUnidadMedidaEdad = Value
            End Set
        End Property

        Public Property CodigoOcupacionPaciente() As String
            Get
                Return _strCodigoOcupacionPaciente
            End Get
            Set(ByVal Value As String)
                _strCodigoOcupacionPaciente = Value
            End Set
        End Property

        Public Property DescripcionOcupacionPaciente() As String
            Get
                Return _strDescripcionOcupacionPaciente
            End Get
            Set(ByVal Value As String)
                _strDescripcionOcupacionPaciente = Value
            End Set
        End Property

        Public Property FechaNacimiento() As String
            Get
                Return _strFechaNacimiento
            End Get
            Set(ByVal Value As String)
                _strFechaNacimiento = Value
            End Set
        End Property

        Public Property GrupoSanguineo() As String
            Get
                Return _strGrupoSanguineo
            End Get
            Set(ByVal Value As String)
                _strGrupoSanguineo = Value
            End Set
        End Property

        Public Property RH() As String
            Get
                Return _strRH
            End Get
            Set(ByVal Value As String)
                _strRH = Value
            End Set
        End Property

        Public Property Unificado() As String
            Get
                Return _strTipoUnificacion
            End Get
            Set(ByVal Value As String)
                _strTipoUnificacion = Value
            End Set
        End Property

        Public Property FotoPaciente() As Bitmap
            Get
                Return _fotoPaciente
            End Get
            Set(ByVal Value As Bitmap)
                _fotoPaciente = Value
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

        Public Property TipoHistoria() As String
            Get
                Return _strTipoHistoria
            End Get
            Set(ByVal value As String)
                _strTipoHistoria = value
            End Set
        End Property

        Public Property DescripcionTipoHistoria() As String
            Get
                Return _strDescripcionTipoHistoria
            End Get
            Set(ByVal Value As String)
                _strDescripcionTipoHistoria = Value
            End Set
        End Property

        Public Property FechaHistoriaClinica() As String
            Get
                Return _strFechaHistoriaClinica
            End Get
            Set(ByVal Value As String)
                _strFechaHistoriaClinica = Value
            End Set
        End Property

        Public Property HoraHistoriaClinica() As Integer
            Get
                Return _intHoraHistoriaClinica
            End Get
            Set(ByVal Value As Integer)
                _intHoraHistoriaClinica = Value
            End Set
        End Property

        Public Property MinutoHistoriaClinica() As String
            Get
                Return _intMinutoHistoriaClinica
            End Get
            Set(ByVal Value As String)
                _intMinutoHistoriaClinica = Value
            End Set
        End Property

        Public Property Entidad() As String
            Get
                Return _strEntidad
            End Get
            Set(ByVal value As String)
                _strEntidad = value
            End Set
        End Property

        Public Property DescripcionEntidad() As String
            Get
                Return _strDescripcionEntidad
            End Get
            Set(ByVal Value As String)
                _strDescripcionEntidad = Value
            End Set
        End Property

        Public Property FechaCita() As String
            Get
                Return _strFechaCita
            End Get
            Set(ByVal Value As String)
                _strFechaCita = Value
            End Set
        End Property

        Public Property HoraCita() As Integer
            Get
                Return _intHoraCita
            End Get
            Set(ByVal Value As Integer)
                _intHoraCita = Value
            End Set
        End Property

        Public Property MinutoCita() As String
            Get
                Return _intMinutoCita
            End Get
            Set(ByVal Value As String)
                _intMinutoCita = Value
            End Set
        End Property

        Public Property IdentificadorCama() As String
            Get
                Return _strIdentificadorCama
            End Get
            Set(ByVal Value As String)
                _strIdentificadorCama = Value
            End Set
        End Property

        Public Property FechaAtencionProcedimiento() As String
            Get
                Return _strFechaAtencionProcedimiento
            End Get
            Set(ByVal Value As String)
                _strFechaAtencionProcedimiento = Value
            End Set
        End Property

        Public Property HoraAtencionProcedimiento() As String
            Get
                Return _intHoraAtencionProcedimiento
            End Get
            Set(ByVal Value As String)
                _intHoraAtencionProcedimiento = Value
            End Set
        End Property

        Public Property MinutoAtencionProcedimiento() As String
            Get
                Return _intMinutoAtencionProcedimiento
            End Get
            Set(ByVal Value As String)
                _intMinutoAtencionProcedimiento = Value
            End Set
        End Property

        Public Property EstadoAdmision() As String
            Get
                Return _strEstadoAdmision
            End Get
            Set(ByVal Value As String)
                _strEstadoAdmision = Value
            End Set
        End Property

        Public Property ManejaConvenio() As String
            Get
                Return _strManejaConvenio
            End Get
            Set(ByVal value As String)
                _strManejaConvenio = value
            End Set
        End Property

        Public Property HistoriaTieneEgreso() As Boolean
            Get
                Return _blnHistoriaTieneEgreso
            End Get
            Set(ByVal Value As Boolean)
                _blnHistoriaTieneEgreso = Value
            End Set
        End Property

        Public Property DocumentosUnificados() As DataTable
            Get
                Return _dtDocsUnif
            End Get
            Set(ByVal value As DataTable)
                _dtDocsUnif = value
            End Set
        End Property

        Public Property XMLDocumentosUnificados() As String
            Get
                Return _strXMLDocumentosUnificados
            End Get
            Set(ByVal Value As String)
                _strXMLDocumentosUnificados = Value
            End Set
        End Property

        Public Property EstadoInicialHistoria() As String
            Get
                Return _estadoInicialHistoria
            End Get
            Set(ByVal value As String)
                _estadoInicialHistoria = value
            End Set
        End Property

        Public Property TipoUsuario() As String
            Get
                Return _strTipoUsuario
            End Get
            Set(ByVal value As String)
                _strTipoUsuario = value
            End Set
        End Property

        Public Property HistoriasConErroresEF() As DataTable
            Get
                Return _dtHC_Erradas
            End Get
            Set(ByVal value As DataTable)
                _dtHC_Erradas = value
            End Set
        End Property

        Public Property TipoEntidad() As String
            Get
                Return _strTipoEntidad
            End Get
            Set(ByVal value As String)
                _strTipoEntidad = value
            End Set
        End Property

        Public Property DescripcionGenero() As String
            Get
                Return _strDescripcionGenero
            End Get
            Set(ByVal value As String)
                _strDescripcionGenero = value
            End Set
        End Property


        Public Property Carnet() As String
            Get
                Return _Carnet
            End Get
            Set(ByVal value As String)
                _Carnet = value
            End Set
        End Property
        Public Property Cama() As String
            Get
                Return _Cama
            End Get
            Set(ByVal value As String)
                _Cama = value
            End Set
        End Property

        Public Property Cronico() As String
            Get
                Return _esCronico
            End Get
            Set(ByVal value As String)
                _esCronico = value
            End Set
        End Property
        ''cpgaray marzo 19 2015 datos de la sede en el pie de pagina OS 265514 
        Public Property Ciudad() As String
            Get
                Return _ciudad
            End Get
            Set(ByVal value As String)
                _ciudad = value
            End Set
        End Property
        Public Property Pais() As String
            Get
                Return _pais
            End Get
            Set(ByVal value As String)
                _pais = value
            End Set
        End Property
        Public Property DirSucursal() As String
            Get
                Return _dirSucursal
            End Get
            Set(ByVal value As String)
                _dirSucursal = value
            End Set
        End Property
        Public Property telSucursal() As String
            Get
                Return _telSucursal
            End Get
            Set(ByVal value As String)
                _telSucursal = value
            End Set
        End Property


#End Region

        ''' <summary>
        ''' Funcion que determina segun la edad el tipo de paciente para ser 
        ''' utilizado en el triage.
        ''' </summary>
        ''' <param name="edad">Edad del paciente</param>
        ''' <returns>Tipo de paciente, Adulto o Pediatrico </returns>
        ''' <remarks></remarks>
        Public Shared Function TipoPacienteTriage(ByVal edad As Integer) As String
            If edad > 14 Then
                Return ADULTO
            Else
                Return PEDIATRICO
            End If
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
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
            _strTipoDocumento = ""
            _strNumDocumento = ""
            _strNombre = ""
            _strPriApe = ""
            _strSegApe = ""
            _strPriNom = ""
            _strSegNom = ""
            _strGenero = ""
            _strTipoAdmision = ""
            _intAnoAdmision = 0
            _lNumeroAdmision = 0
            _bReingreso = False
            _intEdad = 0
            _tipoAdmision = ""
            _strTipoConsultorio = ""
            _fotoPaciente = Nothing
            _strConsultorio = ""
            _strFechaIngresoAdm = ""
            _intHoraIngresoAdm = 0
            _intMinutoIngresoAdm = 0
            _strClasificacionTriage = ""
            _strCodUnidadMedidaEdad = ""
            _strDescripcionUnidadMedidaEdad = ""
            _strCodigoOcupacionPaciente = ""
            _strDescripcionOcupacionPaciente = ""
            _strFechaNacimiento = ""
            _strGrupoSanguineo = ""
            _strRH = ""
            _strTipoUnificacion = ""
            _dtDocsUnif = Nothing
            _estadoInicialHistoria = ""
            _strTipoHistoria = ""
            _strDescripcionTipoHistoria = ""
            _strFechaHistoriaClinica = ""
            _intHoraHistoriaClinica = 0
            _intMinutoHistoriaClinica = 0
            _strEntidad = ""
            _strDescripcionEntidad = ""
            _strFechaCita = ""
            _intHoraCita = 0
            _intMinutoCita = 0
            _strIdentificadorCama = ""
            _strFechaAtencionProcedimiento = ""
            _intHoraAtencionProcedimiento = 0
            _intMinutoAtencionProcedimiento = 0
            _strEstadoAdmision = ""
            _strManejaConvenio = ""
            _blnHistoriaTieneEgreso = False
            _strXMLDocumentosUnificados = ""
            _strDescripcionTipoDocumento = ""
            _strTipoUsuario = ""
            _dtHC_Erradas = Nothing
            _strTipoEntidad = ""
            _strDescripcionGenero = ""
            _codhistoria = 0  ''Claudia Garay Enfermeria 25 septiembre de 2010
            _ciudad = ""
            _pais = ""
            _dirSucursal = ""
            _telSucursal = ""
        End Sub
    End Class
End Namespace