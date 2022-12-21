Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports System.Data.Common

Namespace Sophia.HistoriaClinica.Reportes
    ''' <summary>
    ''' Clase que encapsula los datos del encabezado
    ''' del Reporte de Historia Clinica
    ''' </summary>
    ''' <remarks></remarks>
    Public Class HCEnfEncabezado
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

        Private _edad As String
        Private _ubicacion As String
        Private _edadAMD As String
        Private _religion As String

        Private objDatosGenerales As objGeneral.Generales


#Region "Propiedades"
        Public ReadOnly Property Sucursal() As String
            Get
                Return _sucursal
            End Get
        End Property
        Public Property Religion() As String
            Get
                Return _religion
            End Get
            Set(ByVal Value As String)
                _religion = Value
            End Set
        End Property
        Public Property EdadAMD() As String
            Get
                Return _edadAMD
            End Get
            Set(ByVal Value As String)
                _edadAMD = Value
            End Set
        End Property
        Public Property Prestador() As String
            Get
                Return _prestador
            End Get
            Set(ByVal Value As String)
                _prestador = Value
            End Set
        End Property
        Public Property Edad() As String
            Get
                Return _edad
            End Get
            Set(ByVal Value As String)
                _edad = Value
            End Set
        End Property
        Public Property Ubicacion() As String
            Get
                Return _ubicacion
            End Get
            Set(ByVal Value As String)
                _ubicacion = Value
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
            _edad = ""
            _ubicacion = ""
            _edadAMD = ""
            _religion = ""
        End Sub
       
        Public Sub consultarHcEnfEncabezado(ByVal objConexion As Conexion, ByVal dCod_Historia As Double)

            Dim dr As DbDataReader

            gpmDataObj.setSQLSentence("HCEnf_Reportes_Encabezado", CommandType.StoredProcedure)

            gpmDataObj.addInputParameter("dblcodhistoria", SqlDbType.VarChar, dCod_Historia)

            dr = gpmDataObj.ExecRdr()

            'Inicializa los miembros de la clase con la informacion consultada
            inicializarHCEnfEncabezado(objConexion, dr)

            If dr.IsClosed = False Then
                dr.Close()
            End If

        End Sub

        ''' <summary>
        ''' Inicializa los miembros de la clase con la informacion obtenida
        ''' del stored procedure pa_Reportes_HCEncabezado.
        ''' </summary>
        ''' <param name="dataReaderHC"></param>
        ''' <remarks></remarks>
        Public Sub inicializarHCEnfEncabezado(ByVal objConexion As Conexion, ByVal dataReaderHC As DbDataReader)

            Dim fecha As Date
            Dim unificador As Paciente
            Dim strFecha As String

            objDatosGenerales = objGeneral.Generales.Instancia

            While dataReaderHC.Read()
                _sucursal = dataReaderHC("sucursal").ToString
                _prestador = dataReaderHC("prestador").ToString

                If dataReaderHC("fec_hc").ToString.Length > 0 Then
                    fecha = dataReaderHC("fec_hc").ToString
                    _fecha = Format(fecha, "dd/MM/yyyy")
                Else
                    _fecha = ""
                End If

                strFecha = dataReaderHC("fec_hc").ToString
                If IsDate(strFecha) Then
                    fecha = strFecha
                    _fechaConFormato = Format(fecha, "yyyy/MM/dd")
                Else
                    _fechaConFormato = Format(Now, "yyyy/MM/dd")
                End If

                _hora = dataReaderHC("hor_hc").ToString
                _minuto = dataReaderHC("min_hc").ToString
                _numeroAdmision = dataReaderHC("num_adm").ToString
                _anoAdmision = dataReaderHC("ano_adm").ToString
                _tipoAdmision = dataReaderHC("tip_admision").ToString
                _entidad = dataReaderHC("entidad").ToString
                _estado = dataReaderHC("estado").ToString


                'Crea un objeto que encapsula la informacion del paciente
                _paciente = New Paciente(dataReaderHC("tip_doc").ToString,
                                         dataReaderHC("Num_doc").ToString,
                                         nombre:=dataReaderHC("paciente").ToString,
                                         sexo:=dataReaderHC("sexo").ToString,
                                         edad:=dataReaderHC("edad").ToString,
                                         uniEdad:=dataReaderHC("UnidadEdad").ToString,
                                         grupoSanguineo:=dataReaderHC("gru_sanguineo").ToString,
                                         factorRH:=dataReaderHC("rh").ToString,
                                         desTipoID:=dataReaderHC("desTipoID").ToString,
                                        EdadAMD:=dataReaderHC("edadAMD").ToString,
                                        Ubicacion:=dataReaderHC("ubicacion").ToString,
                                         Religion:=dataReaderHC("Religion").ToString)

                With _paciente
                    .Edad = _paciente.calcularEdad(dataReaderHC("fec_nac").ToString, .UnidadEdad)
                    '.Edad = edad.ToString
                    '.UnidadEdad = unidadEdad
                    unificador = New Paciente().BuscaUnificador(objConexion, .TipoDocumento, .NumeroDocumento)
                    .PacienteUnificador = unificador
                End With
                _recomedaciones = dataReaderHC("OBS").ToString
                _medicoEgreso = dataReaderHC("NombreMedicoEgresa").ToString



                If objDatosGenerales.Pais = "482" Then ''agregar segundo registro médico para Perú. Cpgaray Octubre 21 de 2013
                    If Len(dataReaderHC("RegistroMedicoEgresa2").ToString) = 0 Then
                        _registroMedicoEgreso = dataReaderHC("RegistroMedicoEgresa").ToString
                    Else
                        _registroMedicoEgreso = dataReaderHC("RegistroMedicoEgresa").ToString & " - " & dataReaderHC("RegistroMedicoEgresa2").ToString
                    End If

                    If Len(dataReaderHC("RegistroMedicoLogin2").ToString) = 0 Then
                        _registroMedicoingreso = dataReaderHC("RegistroMedicoLogin").ToString
                    Else
                        _registroMedicoingreso = dataReaderHC("RegistroMedicoLogin").ToString & " - " & dataReaderHC("RegistroMedicoLogin2").ToString
                    End If
                    _secuencia = dataReaderHC("Secuencia").ToString

                Else
                    _registroMedicoingreso = dataReaderHC("RegistroMedicoLogin").ToString
                    _registroMedicoEgreso = dataReaderHC("RegistroMedicoEgresa").ToString
                End If


                _especialidadEgreso = dataReaderHC("EspecialidadMedicoEgreso").ToString

                _medicoIngreso = dataReaderHC("NombreMedicoLogin").ToString               
                _especialidadMedicoIngreso = dataReaderHC("EspecialidadMedicoLogin").ToString
                _ciudad = dataReaderHC("ciudad").ToString
                _pais = dataReaderHC("pais").ToString
                _dirSucursal = dataReaderHC("dirSucursal").ToString
                _telSucursal = dataReaderHC("telSucursal").ToString


            End While
        End Sub



        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub
    End Class

End Namespace
