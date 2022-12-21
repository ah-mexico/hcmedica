Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports System.Data.Common

Namespace Sophia.HistoriaClinica.Reportes
    ''' <summary>
    ''' Clase que encapsula los datos del encabezado
    ''' del Reporte de Historia Clinica
    ''' </summary>
    ''' <remarks></remarks>
    Public Class HCEncabezado
        Inherits GPMDataReport

        Private _sucursal As String
        Private _prestador As String
        Private _fecha As String
        Private _hora As String
        Private _minuto As String
        Private _numeroAdmision As String
        Private _anoAdmision As String
        Private _tipoAdmision As String
        Private _entidad As String
        Private _paciente As Paciente
        Private _recomedaciones As String
        Private _medicoEgreso As String
        Private _registroMedicoEgreso As String
        Private _especialidadEgreso As String
        Private _medicoIngreso As String
        Private _registroMedicoingreso As String
        Private _especialidadMedicoIngreso As String
        Private _fechaIngreso As String
        Private _horaIngreso As String
        Private _fechaEgreso As String
        Private _horaEgreso As String
        Private _estancia As String
        Private _cama As String
        Private _medicoTratante As String
        Private _fechaConFormato As String
        Private _estado As String
        Private _TipoAdmIngreso As String
        Private _TipoAdmEgreso As String
        Private _ciudad As String
        Private _pais As String
        Private _dirSucursal As String
        Private _telSucursal As String
        Private _secuencia As String
        Private _causaexterna As String
        Private _fechaadm As String
        Private objDatosGenerales As objGeneral.Generales



#Region "Propiedades"
        Public ReadOnly Property Sucursal() As String
            Get
                Return _sucursal
            End Get
        End Property

        Public Property Prestador() As String
            Get
                Return _prestador
            End Get
            Set(ByVal Value As String)
                _prestador = Value
            End Set
        End Property

        Public Property Fecha() As String
            Get
                Return _fecha
            End Get
            Set(ByVal value As String)
                _fecha = value
            End Set
        End Property
        Public Property Hora() As String
            Get
                Return _hora
            End Get
            Set(ByVal value As String)
                _hora = value
            End Set
        End Property
        Public ReadOnly Property Minuto() As String
            Get
                Return _minuto
            End Get
        End Property
        Public ReadOnly Property NumeroAdmision() As String
            Get
                Return _numeroAdmision
            End Get
        End Property
        Public ReadOnly Property AnoAdmision() As String
            Get
                Return _anoAdmision
            End Get
        End Property
        Public ReadOnly Property TipoAdmision() As String
            Get
                Return _tipoAdmision
            End Get
        End Property
        Public ReadOnly Property TipoAdmIngreso() As String
            Get
                Return _TipoAdmIngreso
            End Get
        End Property
        Public ReadOnly Property TipoAdmEgreso() As String
            Get
                Return _TipoAdmEgreso
            End Get
        End Property
        Public ReadOnly Property Entidad() As String
            Get
                Return _entidad
            End Get
        End Property
        Public ReadOnly Property Paciente() As Paciente
            Get
                Return _paciente
            End Get
        End Property
        Public Property Recomedaciones() As String
            Get
                Return _recomedaciones
            End Get
            Set(ByVal Value As String)
                _recomedaciones = Value
            End Set
        End Property
        Public Property MedicoEgreso() As String
            Get
                Return _medicoEgreso
            End Get
            Set(ByVal Value As String)
                _medicoEgreso = Value
            End Set
        End Property
        Public Property RegistroMedicoEgreso() As String
            Get
                Return _registroMedicoEgreso
            End Get
            Set(ByVal Value As String)
                _registroMedicoEgreso = Value
            End Set
        End Property
        Public Property EspecialidadEgreso() As String
            Get
                Return _especialidadEgreso
            End Get
            Set(ByVal Value As String)
                _especialidadEgreso = Value
            End Set
        End Property
        Public Property MedicoIngreso() As String
            Get
                Return _medicoIngreso
            End Get
            Set(ByVal Value As String)
                _medicoIngreso = Value
            End Set
        End Property
        Public Property EspecialidadMedicoIngreso() As String
            Get
                Return _especialidadMedicoIngreso
            End Get
            Set(ByVal Value As String)
                _especialidadMedicoIngreso = Value
            End Set
        End Property
        Public Property RegistroMedicoingreso() As String
            Get
                Return _registroMedicoingreso
            End Get
            Set(ByVal Value As String)
                _registroMedicoingreso = Value
            End Set
        End Property
        Public Property fechaIngreso() As String
            Get
                Return _fechaIngreso
            End Get
            Set(ByVal Value As String)
                _fechaIngreso = Value
            End Set
        End Property

        Public Property HoraIngreso() As String
            Get
                Return _horaIngreso
            End Get
            Set(ByVal Value As String)
                _horaIngreso = Value
            End Set
        End Property

        Public Property FechaEgreso() As String
            Get
                Return _fechaEgreso
            End Get
            Set(ByVal Value As String)
                _fechaEgreso = Value
            End Set
        End Property

        Public Property HoraEgreso() As String
            Get
                Return _horaEgreso
            End Get
            Set(ByVal Value As String)
                _horaEgreso = Value
            End Set
        End Property

        Public Property Estancia() As String
            Get
                Return _estancia
            End Get
            Set(ByVal Value As String)
                _estancia = Value
            End Set
        End Property

        Public Property Cama() As String
            Get
                Return _cama
            End Get
            Set(ByVal Value As String)
                _cama = Value
            End Set
        End Property
        Public Property MedicoTratante() As String
            Get
                Return _medicoTratante
            End Get
            Set(ByVal Value As String)
                _medicoTratante = Value
            End Set
        End Property
        Public Property FechaConFormato() As String
            Get
                Return _fechaConFormato
            End Get
            Set(ByVal value As String)
                _fechaConFormato = value
            End Set
        End Property

        Public Property Estado() As String
            Get
                Return _estado
            End Get
            Set(ByVal value As String)
                _estado = value
            End Set
        End Property
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

        Public Property secuencia() As String
            Get
                Return _secuencia
            End Get
            Set(ByVal value As String)
                _secuencia = value
            End Set
        End Property

        Public Property CausaExterna() As String
            Get
                Return _causaexterna
            End Get
            Set(ByVal value As String)
                _causaexterna = value
            End Set
        End Property
        ''' <summary>
        ''' Se crea campo para corregir caso 453 y 459 20171221 rcr
        ''' </summary>
        ''' <returns></returns>
        Public Property Fechaadm() As String
            Get
                Return _fechaadm
            End Get
            Set(ByVal Value As String)
                _fechaadm = Value
            End Set
        End Property


#End Region

#Region "Constantes"
        ''Estados de la Historia
        Public Const PENDIENTE As String = "P"
        Public Const EGRESADA As String = "E"
        Public Const EVOLUCION As String = "O"
        Public Const ENLISTA As String = "L"

#End Region

        Public Sub New()
            MyBase.New()
            _sucursal = ""
            _prestador = ""
            _fecha = ""
            _hora = ""
            _minuto = ""
            _numeroAdmision = ""
            _anoAdmision = ""
            _tipoAdmision = ""
            _entidad = ""
            _paciente = New Paciente()
            _recomedaciones = ""
            _medicoEgreso = ""
            _registroMedicoEgreso = ""
            _especialidadEgreso = ""
            _medicoIngreso = ""
            _registroMedicoingreso = ""
            _especialidadMedicoIngreso = ""
            _fechaIngreso = ""
            _horaIngreso = ""
            _fechaEgreso = ""
            _horaEgreso = ""
            _estancia = ""
            _cama = ""
            _medicoTratante = ""
            _TipoAdmIngreso = ""
            _TipoAdmEgreso = ""
            _secuencia = ""
            _causaexterna = ""
            _fechaadm = ""

        End Sub
        ''' <summary>
        ''' Consulta datos que son mostrados en el encabezado del reporte 
        ''' de historia clinica para una determinada admision. 
        ''' Estos datos se relacionan con la admision, el enzabezado de la HC 
        ''' y el paciente.
        ''' </summary>
        ''' <param name="strcod_pre_sgs">Codigo del prestador</param>
        ''' <param name="strCod_sucur">Codigo de la Sucursal</param>
        ''' <param name="strTip_admision">Tipo de admision</param>
        ''' <param name="lano_adm">Año de la Admision</param>
        ''' <param name="dnum_adm">Numero de admision</param>
        ''' <remarks></remarks>
        Public Sub consultarHcEncabezado(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String, _
                   ByVal strCod_sucur As String, ByVal strTip_admision As String, _
                   ByVal lano_adm As Long, ByVal dnum_adm As Double)

            Dim dr As DbDataReader
            'Dim tipAdmIni As String

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 13/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''comm = db.GetStoredProcCommandWrapper("HC_Reportes_Encabezado")

            '' ''With comm
            '' ''    .AddInParameter("strcod_pre_sgs", DbType.String, strcod_pre_sgs)
            '' ''    .AddInParameter("strCod_sucur", DbType.String, strCod_sucur)
            '' ''    .AddInParameter("strTip_admision", DbType.String, strTip_admision)
            '' ''    .AddInParameter("lano_adm", DbType.String, lano_adm)
            '' ''    .AddInParameter("dnum_adm", DbType.String, dnum_adm)
            '' ''End With

            '' ''dr = db.ExecuteReader(comm)

            gpmDataObj.setSQLSentence("HC_Reportes_Encabezado", CommandType.StoredProcedure)

            gpmDataObj.addInputParameter("strcod_pre_sgs", SqlDbType.VarChar, strcod_pre_sgs)
            gpmDataObj.addInputParameter("strCod_sucur", SqlDbType.VarChar, strCod_sucur)
            gpmDataObj.addInputParameter("strTip_admision", SqlDbType.VarChar, strTip_admision)
            gpmDataObj.addInputParameter("lano_adm", SqlDbType.VarChar, lano_adm)
            gpmDataObj.addInputParameter("dnum_adm", SqlDbType.VarChar, dnum_adm)

            dr = gpmDataObj.ExecRdr()

            'tipAdmIni = dr("cod_adm_des").ToString
            'Inicializa los miembros de la clase con la informacion consultada
              inicializarHCEncabezado(objConexion, dr)

            If dr.IsClosed = False Then
                dr.Close()
            End If

            'buscarAdmision(objConexion, strTip_admision, tipAdmIni)
            '' ''comm.Command.Connection.Close()
            '' ''comm.Command.Connection.Dispose()

        End Sub

        'Cambio Realizado por Ing. Ricardo Mauricio Zaldúa C. Pogramador de Aplicaciones
        'Fecha 20-11-2008
        'Motivo Traer la descripcion del tipo de Admision de ingreso y el de egreso 
        Public Sub buscarAdmision(ByVal objConexion As Conexion, ByVal tipAdm As String, ByVal tipAdmIni As String)

            Dim strSQL As String
            Dim drAdm As DbDataReader

            'Solicitado por Enrique Forero
            'Admision Egreso
            strSQL = "select descripcion from gentipad where tip_admision = '" & tipAdm & "'"
            gpmDataObj.setSQLSentence(strSQL, CommandType.Text)
            drAdm = gpmDataObj.ExecRdr()
            While drAdm.Read()
                _TipoAdmEgreso = drAdm("Descripcion").ToString
            End While
            'Admision Ingreso
            drAdm.Close()
            _TipoAdmIngreso = tipAdm
            If tipAdm <> "U" Then
                If Len(tipAdmIni) > 0 Then
                    If Mid(tipAdmIni, 1, 1) = "U" Then
                        strSQL = "select descripcion from gentipad where tip_admision = '" & Mid(tipAdmIni, 1, 1) & "'"
                        gpmDataObj.setSQLSentence(strSQL, CommandType.Text)
                        drAdm = gpmDataObj.ExecRdr()
                        While drAdm.Read()
                            _TipoAdmIngreso = drAdm("Descripcion").ToString
                        End While
                    Else
                        _TipoAdmIngreso = _TipoAdmEgreso
                    End If
                Else
                    _TipoAdmIngreso = _TipoAdmEgreso
                End If
            Else
                _TipoAdmIngreso = _TipoAdmEgreso
            End If
            If drAdm.IsClosed = False Then
                drAdm.Close()
            End If
        End Sub

        ''' <summary>
        ''' Inicializa los miembros de la clase con la informacion obtenida
        ''' del stored procedure pa_Reportes_HCEncabezado.
        ''' </summary>
        ''' <param name="dataReaderHC"></param>
        ''' <remarks></remarks>
        Public Sub inicializarHCEncabezado(ByVal objConexion As Conexion, ByVal dataReaderHC As DbDataReader)

            Dim fecha As Date
            Dim unificador As Paciente
            Dim strFecha As String



            objDatosGenerales = objGeneral.Generales.Instancia

            While dataReaderHC.Read()
                _sucursal = objDatosGenerales.DescripcionPrestador + " - " + dataReaderHC("sucursal").ToString
                If dataReaderHC("fec_hc").ToString.Length > 0 Then
                    fecha = dataReaderHC("fec_hc").ToString
                    _fecha = Format(fecha, "dd/MM/yyyy")
                Else
                    _fecha = ""
                End If

                strFecha = dataReaderHC("fec_hc").ToString
                If IsDate(strFecha) Then
                    fecha = strFecha
                    _fechaConFormato = Format(fecha, "dd/MM/yyyy") ' "yyyy/MM/dd"
                Else
                    _fechaConFormato = Format(Now, "yyyy/MM/dd")
                End If
                _fechaadm = dataReaderHC("FECHAADM").ToString
                _hora = dataReaderHC("hor_hc").ToString
                _minuto = dataReaderHC("min_hc").ToString
                _numeroAdmision = dataReaderHC("num_adm").ToString
                _anoAdmision = dataReaderHC("ano_adm").ToString
                _tipoAdmision = dataReaderHC("tip_admision").ToString
                _entidad = dataReaderHC("entidad").ToString
                _estado = dataReaderHC("estado").ToString
                _causaexterna = dataReaderHC("causaext").ToString

                If objDatosGenerales.Pais = "482" Then ''agregar segundo registro médico para Perú. Cpgaray Octubre 21 de 2013
                    If Len(dataReaderHC("RegistroMedicoLogin").ToString) = 0 Then
                        _registroMedicoingreso = dataReaderHC("RegistroMedicoLogin").ToString
                    Else
                        _registroMedicoingreso = dataReaderHC("RegistroMedicoLogin").ToString & " REGISTRO MÉDICO 2 - " & dataReaderHC("RegistroMedicoLogin2").ToString
                    End If
                    If Len(dataReaderHC("RegistroMedicoEgresa2").ToString) = 0 Then
                        _registroMedicoEgreso = dataReaderHC("RegistroMedicoEgresa").ToString
                    Else
                        _registroMedicoEgreso = dataReaderHC("RegistroMedicoEgresa").ToString & " REGISTRO MÉDICO 2 - " & dataReaderHC("RegistroMedicoEgresa2").ToString
                    End If

                    _secuencia = dataReaderHC("Secuencia").ToString

                Else
                    _registroMedicoEgreso = dataReaderHC("RegistroMedicoEgresa").ToString
                    _registroMedicoingreso = dataReaderHC("RegistroMedicoLogin").ToString

                End If

                'Cambio realizado por Ricardo Mauricio Zaldúa C.
                'Fecha 24-11-2008
                'Motivo Realia la busqueda del tipo de admision
                'buscarAdmision(objConexion, dataReaderHC("tip_admision").ToString, dataReaderHC("cod_adm_des").ToString)

                'Crea un objeto que encapsula la informacion del paciente
                _paciente = New Paciente(dataReaderHC("tip_doc").ToString,
                                         dataReaderHC("Num_doc").ToString,
                                         nombre:=dataReaderHC("paciente").ToString,
                                         grupoSanguineo:=dataReaderHC("gru_sanguineo").ToString,
                                         factorRH:=dataReaderHC("rh").ToString,
                                         Admision:=dataReaderHC("desTipoID").ToString,
                                         EdadAMD:=dataReaderHC("EDADAMD").ToString,
                                         edad:=dataReaderHC("edad").ToString,
                                         sexo:=dataReaderHC("SEXO").ToString,
                                         Religion:=dataReaderHC("RELIGION").ToString,
                                         Ubicacion:=dataReaderHC("UBICACION").ToString,
                                         FechaHoraAdmision:=dataReaderHC("FECHAADM").ToString)

                '_paciente = New Paciente(dataReaderHC("tip_doc").ToString,
                '                         dataReaderHC("Num_doc").ToString,
                '                         nombre:=dataReaderHC("paciente").ToString,
                '                         grupoSanguineo:=dataReaderHC("gru_sanguineo").ToString,
                '                         factorRH:=dataReaderHC("rh").ToString,
                '                         Admision:=dataReaderHC("desTipoID").ToString,
                '                         EdadAMD:="",
                '                         edad:=dataReaderHC("edad").ToString,
                '                         sexo:="",
                '                         Religion:="",
                '                         Ubicacion:="",
                '                         FechaHoraAdmision:="")
                'uniEdad:=dataReaderHC("UnidadEdad").ToString, _

                With _paciente
                    ' .Edad =   _paciente.calcularEdad(dataReaderHC("fec_nac").ToString, .UnidadEdad)''la edad del paciente sera la de la admision tk 485539-20121229 cpgaray Enero 3 de 2013
                    '.Edad = edad.ToString
                    '.UnidadEdad = unidadEdad
                    unificador = New Paciente().BuscaUnificador(objConexion, .TipoDocumento, .NumeroDocumento)
                    .PacienteUnificador = unificador
                End With
                _recomedaciones = dataReaderHC("OBS").ToString
                _medicoEgreso = dataReaderHC("NombreMedicoEgresa").ToString
                _especialidadEgreso = dataReaderHC("EspecialidadMedicoEgreso").ToString
                _medicoIngreso = dataReaderHC("NombreMedicoLogin").ToString
                _especialidadMedicoIngreso = dataReaderHC("EspecialidadMedicoLogin").ToString
                _ciudad = dataReaderHC("ciudad").ToString
                _pais = dataReaderHC("pais").ToString
                _dirSucursal = dataReaderHC("dirSucursal").ToString
                _telSucursal = dataReaderHC("telSucursal").ToString
                _sucursal = objDatosGenerales.DescripcionPrestador + " - " + dataReaderHC("sucursal").ToString

            End While
        End Sub



        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub
    End Class

End Namespace
