Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports System.Collections.Generic
Imports System.Data.Common

Namespace Sophia.HistoriaClinica.Reportes
    Public Class Paciente
        Inherits GPMDataReport

        Private _tipoDocumento As String
        Private _numeroDocumento As String
        Private _descripTipoDocumento As String
        Private _nombre As String
        Private _estadoCivil As String
        Private _desSexo As String
        Private _desOcupacion As String
        Private _fechaNacimiento As String
        Private _ciudadNacimiento As String
        Private _nacionalidad As String
        Private _edad As String
        Private _unidadEdad As String
        Private _dirCasa As String
        Private _ciudadCasa As String
        Private _departamentoCasa As String
        Private _telCasa As String
        Private _dirOficina As String
        Private _ciudadOficina As String
        Private _telOficina As String
        Private _NombreReponsable As String
        Private _parentesco As String
        Private _dirCasaResponsable As String
        Private _telCasaResponsable As String
        Private _carnet As String
        Private _reingreso As String
        Private _admision1 As String
        Private _admision2 As String
        Private _admision3 As String
        Private _admision4 As String
        Private _admision5 As String
        Private _plan As String
        Private _grupoSanguineo As String
        Private _factorRh As String
        Private _primerNombre As String
        Private _segundoNombre As String
        Private _primerApellido As String
        Private _segundoApellido As String
        Private _pacienteUnificador As Paciente
        Private _unificado As String
        Private _pacientesUnificados As List(Of Paciente)
      
#Region "Propiedades"
        Public Property TipoDocumento() As String
            Get
                Return _tipoDocumento
            End Get
            Set(ByVal value As String)
                _tipoDocumento = value
            End Set
        End Property
        Public  Property NumeroDocumento() As String
            Get
                Return _numeroDocumento
            End Get
            Set(ByVal value As String)
                _numeroDocumento = value
            End Set
        End Property
        Public ReadOnly Property DescripTipoDocumento() As String
            Get
                Return _descripTipoDocumento
            End Get
        End Property
        Public Property Nombre() As String
            Get
                Return _nombre
            End Get
            Set(ByVal value As String)
                _nombre = value
            End Set
        End Property
        Public ReadOnly Property EstadoCivil() As String
            Get
                Return _estadoCivil
            End Get
        End Property
        Public Property DescripSexo() As String
            Get
                Return _desSexo
            End Get
            Set(ByVal value As String)
                _desSexo = value
            End Set
        End Property
        Public ReadOnly Property DescripOcupacion() As String
            Get
                Return _desOcupacion
            End Get
        End Property
        Public Property FechaNacimiento() As String
            Get
                Return _fechaNacimiento
            End Get
            Set(ByVal value As String)
                _fechaNacimiento = value
            End Set
        End Property
        Public ReadOnly Property CiudadNacimiento() As String
            Get
                Return _ciudadNacimiento
            End Get
        End Property
        Public ReadOnly Property Nacionalidad() As String
            Get
                Return _nacionalidad
            End Get
        End Property
        Public Property Edad() As String
            Get
                Return _edad
            End Get
            Set(ByVal value As String)
                _edad = value
            End Set
        End Property
        Public Property UnidadEdad() As String
            Get
                Return _unidadEdad
            End Get
            Set(ByVal value As String)
                _unidadEdad = value
            End Set
        End Property
        Public ReadOnly Property DireccionCasa() As String
            Get
                Return _dirCasa
            End Get
        End Property
        Public ReadOnly Property CiudadCasa() As String
            Get
                Return _ciudadCasa
            End Get
        End Property
        Public ReadOnly Property DepartamentoCasa() As String
            Get
                Return _departamentoCasa
            End Get
        End Property
        Public ReadOnly Property TelefonoCasa() As String
            Get
                Return _telCasa
            End Get
        End Property
        Public ReadOnly Property DireccionOficina() As String
            Get
                Return _dirOficina
            End Get
        End Property
        Public ReadOnly Property CiudadOficina() As String
            Get
                Return _ciudadOficina
            End Get
        End Property
        Public ReadOnly Property TelefonoOficina() As String
            Get
                Return _telOficina
            End Get
        End Property
        Public ReadOnly Property NombreResponsable() As String
            Get
                Return _NombreReponsable
            End Get
        End Property
        Public ReadOnly Property Parentesco() As String
            Get
                Return _parentesco
            End Get
        End Property
        Public ReadOnly Property DireccionCasaResponsable() As String
            Get
                Return _dirCasaResponsable
            End Get
        End Property
        Public ReadOnly Property TelefonoCasaResponsable() As String
            Get
                Return _telCasaResponsable
            End Get
        End Property
        Public ReadOnly Property Carnet() As String
            Get
                Return _carnet
            End Get
        End Property
        Public ReadOnly Property Reingreso() As String
            Get
                Return _reingreso
            End Get
        End Property
        Public ReadOnly Property Admision1() As String
            Get
                Return _admision1
            End Get
        End Property
        Public ReadOnly Property Admision2() As String
            Get
                Return _admision2
            End Get
        End Property
        Public ReadOnly Property Admision3() As String
            Get
                Return _admision3
            End Get
        End Property
        Public ReadOnly Property Admision4() As String
            Get
                Return _admision4
            End Get
        End Property
        Public ReadOnly Property Admision5() As String
            Get
                Return _admision5
            End Get
        End Property
        Public ReadOnly Property Plan() As String
            Get
                Return _plan
            End Get
        End Property
        Public ReadOnly Property GrupoSanguineo() As String
            Get
                Return _grupoSanguineo
            End Get
        End Property
        Public ReadOnly Property FactorRH() As String
            Get
                Return _factorRh
            End Get
        End Property
        Public Property FechaUnificador() As String
            Get
                Return _pacienteUnificador.FechaNacimiento
            End Get
            Set(ByVal Value As String)
                _pacienteUnificador.FechaNacimiento = Value
            End Set
        End Property
        Public Property SexoUnificador() As String
            Get
                Return _pacienteUnificador.DescripSexo
            End Get
            Set(ByVal Value As String)
                _pacienteUnificador.DescripSexo = Value
            End Set
        End Property
        Public Property NombreUnificador() As String
            Get
                Return _pacienteUnificador.Nombre
            End Get
            Set(ByVal Value As String)
                _pacienteUnificador.Nombre = Value
            End Set
        End Property
        Public Property TipDocumentoUnificador() As String
            Get
                Return _pacienteUnificador.TipoDocumento
            End Get
            Set(ByVal Value As String)
                _pacienteUnificador.TipoDocumento = Value
            End Set
        End Property
        Public Property Unificado() As String
            Get
                Return _unificado
            End Get
            Set(ByVal Value As String)
                _unificado = Value
            End Set
        End Property
        Public Property NumDocumentoUnificador() As String
            Get
                Return _pacienteUnificador.NumeroDocumento
            End Get
            Set(ByVal Value As String)
                _pacienteUnificador.NumeroDocumento = Value
            End Set
        End Property
        Public Property SegundoNombre() As String
            Get
                Return _segundoNombre
            End Get
            Set(ByVal Value As String)
                _segundoNombre = Value
            End Set
        End Property
        Public Property PrimerNombre() As String
            Get
                Return _primerNombre
            End Get
            Set(ByVal Value As String)
                _primerNombre = Value
            End Set
        End Property
        Public Property PrimerApellido() As String
            Get
                Return _primerApellido
            End Get
            Set(ByVal Value As String)
                _primerApellido = Value
            End Set
        End Property
        Public Property SegundoApellido() As String
            Get
                Return _segundoApellido
            End Get
            Set(ByVal Value As String)
                _segundoApellido = Value
            End Set
        End Property
        Public Property PacienteUnificador() As Paciente
            Get
                Return _pacienteUnificador
            End Get
            Set(ByVal value As Paciente)
                _pacienteUnificador = value
            End Set
        End Property
        Public Property PacientesUnificados() As List(Of Paciente)
            Get
                Return _pacientesUnificados
            End Get
            Set(ByVal Value As List(Of Paciente))
                _pacientesUnificados = Value
            End Set
        End Property

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

        Public Sub New()
            _tipoDocumento = ""
            _numeroDocumento = ""
            _descripTipoDocumento = ""
            _nombre = ""
            _estadoCivil = ""
            _desSexo = ""
            _desOcupacion = ""
            _fechaNacimiento = ""
            _ciudadNacimiento = ""
            _nacionalidad = ""
            _edad = ""
            _unidadEdad = ""
            _dirCasa = ""
            _ciudadCasa = ""
            _departamentoCasa = ""
            _telCasa = ""
            _dirOficina = ""
            _ciudadOficina = ""
            _telOficina = ""
            _NombreReponsable = ""
            _parentesco = ""
            _dirCasaResponsable = ""
            _telCasaResponsable = ""
            _carnet = ""
            _reingreso = ""
            _admision1 = ""
            _admision2 = ""
            _admision3 = ""
            _admision4 = ""
            _admision5 = ""
            _plan = ""
            _grupoSanguineo = ""
            _factorRh = ""
            _primerNombre = ""
            _segundoNombre = ""
            _primerApellido = ""
            _segundoApellido = ""
        End Sub

        Public Sub New(ByVal dtDatosAdm As DataTable, ByVal dtAdmisionesAnt As DataTable, _
                       ByVal cantAdm As Integer, ByVal desTipoDocumento As String, ByVal carnet As String)

            Dim fecha As Date
            Dim i As Integer
            Dim numeroAdmisiones As Integer
            Dim admisiones As String() = New String() {}
            ReDim admisiones(5)

            If cantAdm < 2 Then
                _reingreso = "Primera Vez"
            Else
                _reingreso = "Reingreso " & cantAdm
            End If

            _carnet = carnet

            If dtAdmisionesAnt.Rows.Count > 5 Then
                numeroAdmisiones = 5
            Else
                numeroAdmisiones = dtAdmisionesAnt.Rows.Count
            End If

            For i = 0 To numeroAdmisiones - 1
                admisiones(i) = dtAdmisionesAnt.Rows(i).Item("admision").ToString
            Next

            _admision1 = admisiones(0)
            _admision2 = admisiones(1)
            _admision3 = admisiones(2)
            _admision4 = admisiones(3)
            _admision5 = admisiones(4)

            _descripTipoDocumento = desTipoDocumento

            If dtDatosAdm.Rows.Count > 0 Then
                With dtDatosAdm.Rows(0)
                    _tipoDocumento = .Item("tip_doc").ToString
                    _numeroDocumento = .Item("num_doc").ToString
                    _nombre = .Item("nombre").ToString
                    _estadoCivil = .Item("estado_civil").ToString
                    _desSexo = .Item("desSexo").ToString
                    _desOcupacion = .Item("desOcupacion").ToString
                    If .Item("fec_nac").ToString.Length > 0 Then
                        fecha = .Item("fec_nac").ToString
                        _fechaNacimiento = Format(fecha, "dd/MMMM/yyyy")
                    Else
                        _fechaNacimiento = ""
                    End If
                    _ciudadNacimiento = .Item("ciu_nac").ToString
                    _nacionalidad = .Item("nacionalidad").ToString
                    _edad = .Item("edad").ToString
                    _unidadEdad = .Item("unidad").ToString
                    _dirCasa = .Item("dir_casa").ToString
                    _ciudadCasa = .Item("ciu_casa").ToString
                    _departamentoCasa = .Item("dep_casa").ToString
                    _telCasa = .Item("tel_casa").ToString
                    _dirOficina = .Item("dir_oficina").ToString
                    _ciudadOficina = .Item("ciu_oficina").ToString
                    _telOficina = .Item("tel_oficina").ToString
                    _NombreReponsable = .Item("nom_res").ToString
                    _parentesco = .Item("paren").ToString
                    _dirCasaResponsable = .Item("dir_res").ToString
                    _telCasaResponsable = .Item("tel_res").ToString
                End With
            End If
        End Sub

        Public Sub New(ByVal tipdoc As String, ByVal numdoc As String, _
                       Optional ByVal nombre As String = "", Optional ByVal estadoCivil As String = "", _
                       Optional ByVal sexo As String = "", Optional ByVal ocupacion As String = "", _
                       Optional ByVal fecNacim As String = "", Optional ByVal edad As String = "", _
                       Optional ByVal uniEdad As String = "", Optional ByVal direccionCasa As String = "", _
                       Optional ByVal telefonoCasa As String = "", Optional ByVal plan As String = "", _
                       Optional ByVal carnet As String = "", Optional ByVal grupoSanguineo As String = "", _
                       Optional ByVal factorRH As String = "", Optional ByVal strPriNom As String = "", _
                       Optional ByVal strSegNom As String = "", Optional ByVal strPriApe As String = "", _
                       Optional ByVal Admision As String = "", Optional ByVal EdadAMD As String = "", _
                       Optional ByVal Ubicacion As String = "", Optional ByVal Religion As String = "", Optional ByVal FechaHoraAdmision As String = "", _
                       Optional ByVal strSegApe As String = "", Optional ByVal desTipoID As String = "")

            _tipoDocumento = tipdoc
            _numeroDocumento = numdoc
            _nombre = nombre
            _estadoCivil = estadoCivil
            _desSexo = sexo
            _desOcupacion = ocupacion
            _fechaNacimiento = fecNacim
            _edad = edad
            _unidadEdad = uniEdad
            _dirCasa = direccionCasa
            _telCasa = telefonoCasa
            _plan = plan
            _carnet = carnet
            _grupoSanguineo = grupoSanguineo
            _factorRh = factorRH
            _primerNombre = strPriNom
            _segundoNombre = strSegNom
            _primerApellido = strPriApe
            _segundoApellido = strSegApe
            _pacienteUnificador = New Paciente()
            _pacientesUnificados = New List(Of Paciente)
            _descripTipoDocumento = desTipoID
            _Admision = Admision
            _EdadAMD = EdadAMD
            _Religion = Religion
            _Ubicacion = Ubicacion
            _FechaHoraAdmision = FechaHoraAdmision
        End Sub



        ''' <summary>
        ''' Calcula la edad del paciente basado en la edad del mismo
        ''' </summary>
        ''' <param name="fecha_nacim"></param>
        ''' <param name="unidadEdad"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function calcularEdad(ByVal fecha_nacim As Date, ByRef unidadEdad As String) As Integer
            Dim lNumDias As Long
            Dim edad As Integer = 0

            If Not fecha_nacim.ToString = "" Then
                lNumDias = Now().Subtract(fecha_nacim).TotalDays 'fecha_nacim.Subtract(Now()).TotalDays
                If lNumDias > 365 Then
                    unidadEdad = "AÑOS"
                    edad = CInt(Fix(lNumDias / 365))
                Else
                    If lNumDias > 30 And lNumDias < 365 Then
                        unidadEdad = "MESES"
                        edad = CInt(Fix(lNumDias / 30))
                    Else
                        unidadEdad = "DIAS"
                        edad = CInt(Fix(lNumDias))
                    End If
                End If
            End If

            Return edad
        End Function

        Public Function buscarDocumento(ByVal objConexion As Conexion, ByVal tipDocumento As String, ByVal numDocumento As String) As Paciente
            'TODO: Documentar bien este paciente para que no tenga problemas con la otra clase paciente
            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 13/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper
            Dim strSQL As String
            Dim objPaciente As New Paciente()
            Dim objUnificador As New Paciente()
            Dim drDatos As DbDataReader



            strSQL = "select a.pri_nom, a.seg_nom, a.pri_ape, a.seg_ape, a.fec_nac, " & _
                     "a.sexo, b.Descripcion As DescripcionSexo, a.num_doc, a.tip_doc, " & _
                     "a.unificado, C.descripcion AS DescripcionTipoID from genpacie a (nolock) INNER JOIN gensexo b  (nolock) ON a.sexo = b.sexo " & _
                     "INNER JOIN gentipdo AS C (nolock) ON a.tip_doc = C.tip_doc where a.tip_doc = '" & tipDocumento & "' and a.num_doc = '" & numDocumento & "'"

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''command = db.GetSqlStringCommandWrapper(strSQL)

            '' ''drDatos = db.ExecuteReader(command)

            gpmDataObj.setSQLSentence(strSQL, CommandType.Text)
            drDatos = gpmDataObj.ExecRdr()

            While drDatos.Read()

                objPaciente = New Paciente(tipDocumento, numDocumento, drDatos("pri_nom").ToString & " " & _
                                           drDatos("seg_nom").ToString & " " & drDatos("pri_ape").ToString & " " & _
                                           drDatos("seg_ape").ToString, sexo:=drDatos("DescripcionSexo").ToString, _
                                           fecNacim:=drDatos("fec_nac").ToString, strPriNom:=drDatos("pri_nom").ToString, strSegNom:=drDatos("seg_nom").ToString, _
                                           strpriApe:=drDatos("pri_ape").ToString, strsegApe:=drDatos("seg_ape").ToString, _
                                           destipoid:=drDatos("DescripcionTipoID").ToString)
                objPaciente.Unificado = drDatos("unificado").ToString

            End While

            '' ''command.Command.Connection.Close()
            '' ''command.Command.Connection.Dispose()

            'Se consultan tanto el paciente Unificador como los pacientes unificados a este
            Select Case objPaciente.Unificado
                Case "U"   'El paciente es Unificado
                    'Se busca el paciente unificador del paciente ingresado y los unificados relacionados con
                    'el unificador encontrado
                    objPaciente.PacienteUnificador = New Paciente().BuscaUnificador(objConexion, objPaciente.TipoDocumento, objPaciente.NumeroDocumento)
                    objPaciente.PacientesUnificados = New Paciente().BuscarUnificados(objConexion, objPaciente.PacienteUnificador.TipoDocumento, objPaciente.PacienteUnificador.NumeroDocumento)
                Case "UU"   'El paciente es unificador
                    'Se Buscan los pacientes unificados a este unificador
                    objPaciente.PacientesUnificados = New Paciente().BuscarUnificados(objConexion, objPaciente.TipoDocumento, objPaciente.NumeroDocumento)
            End Select

            If drDatos.IsClosed = False Then
                drDatos.Close()
            End If
            Return objPaciente

        End Function

        Public Function BuscaUnificador(ByVal objConexion As Conexion, ByVal tipDocumento As String, ByVal numDocumento As String) As Paciente

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 13/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper
            Dim strSQL As String
            Dim objPaciente As New Paciente()
            Dim drDatos As DbDataReader


            strSQL = "SELECT a.tip_doc_unificador, a.num_doc_unificador, b.pri_nom, b.seg_nom, b.pri_ape, b.seg_ape, b.fec_nac, b.sexo, " & _
                     " c.Descripcion As DescripcionSexo, b.num_doc, b.tip_doc, b.unificado   " & _
                     " FROM GENUNIPACIE a (nolock) INNER JOIN GENPACIE b (nolock) ON a.tip_doc_unificado = b.tip_doc and a.num_doc_unificado = b.num_doc " & _
                     " INNER JOIN GENSEXO c (nolock) ON b.sexo = c.sexo " & _
                     " WHERE a.tip_doc_unificado = '" & tipDocumento & "' AND a.num_doc_unificado = '" & numDocumento & "' "

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''command = db.GetSqlStringCommandWrapper(strSQL)

            '' ''drDatos = db.ExecuteReader(command)

            gpmDataObj.setSQLSentence(strSQL, CommandType.Text)
            drDatos = gpmDataObj.ExecRdr()

            While drDatos.Read()
                objPaciente = New Paciente(drDatos("tip_doc_unificador").ToString, drDatos("num_doc_unificador").ToString, _
                                           drDatos("pri_nom").ToString & " " & _
                                           drDatos("seg_nom").ToString & " " & drDatos("pri_ape").ToString & " " & _
                                           drDatos("seg_ape").ToString, fecNacim:=drDatos("fec_nac").ToString, _
                                           sexo:=drDatos("DescripcionSexo").ToString, strPriNom:=drDatos("pri_nom").ToString, _
                                           strSegNom:=drDatos("seg_nom").ToString, strpriApe:=drDatos("pri_ape").ToString, _
                                           strsegApe:=drDatos("seg_ape").ToString)
            End While

            If drDatos.IsClosed = False Then
                drDatos.Close()
            End If
            '' ''command.Command.Connection.Close()
            '' ''command.Command.Connection.Dispose()

            Return objPaciente
        End Function

        Public Function BuscarUnificados(ByVal objConexion As Conexion, ByVal tipDocUnificador As String, ByVal numDocUnificador As String) As List(Of Paciente)
            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 13/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper
            Dim strSQL As String
            Dim drDatos As DbDataReader
            Dim listaPacientes As New List(Of Paciente)
            Dim objPaciente As Paciente

            ''Se agrega nolock a las consultas
            ''Septiembre 25 2009
            ''Claudia Garay

            strSQL = "SELECT num_doc_unificado as Num_doc, tip_doc_unificado AS Tip_doc " & _
                     "FROM genunipacie (nolock) WHERE num_doc_unificador = '" & numDocUnificador & "' " & _
                     "AND tip_doc_unificador = '" & tipDocUnificador & "' "

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''command = db.GetSqlStringCommandWrapper(strSQL)
            '' ''drDatos = db.ExecuteReader(command)

            gpmDataObj.setSQLSentence(strSQL, CommandType.Text)
            drDatos = gpmDataObj.ExecRdr()

            While drDatos.Read()
                objPaciente = New Paciente(tipdoc:=drDatos("Tip_doc").ToString, _
                                           numdoc:=drDatos("Num_doc").ToString)

                listaPacientes.Add(objPaciente)

            End While

            If drDatos.IsClosed = False Then
                drDatos.Close()
            End If
            '' ''command.Command.Connection.Close()
            '' ''command.Command.Connection.Dispose()

            Return listaPacientes

        End Function

        Public Function BuscarPorNombre(ByVal objConexion As Conexion, ByVal strPrimerNombre As String, ByVal strPrimerApellido As String) As DataTable
            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 13/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper
            Dim dtPacientes As DataTable

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''command = db.GetStoredProcCommandWrapper("DB_TraerInfoPacientexNombre")

            '' ''command.AddInParameter("strPri_Ape", DbType.String, strPrimerApellido)
            '' ''command.AddInParameter("strPri_Nom", DbType.String, strPrimerNombre)

            '' ''dtPacientes = db.ExecuteDataSet(command).Tables(0)
            gpmDataObj.setSQLSentence("DB_TraerInfoPacientexNombre", CommandType.StoredProcedure)

            gpmDataObj.addInputParameter("strPri_Ape", SqlDbType.VarChar, strPrimerApellido)
            gpmDataObj.addInputParameter("strPri_Nom", SqlDbType.VarChar, strPrimerNombre)

            dtPacientes = gpmDataObj.execDS().Tables(0)

            Return dtPacientes

        End Function

        Public Function PacienteVacio(ByVal objPaciente As Paciente) As Boolean
            If objPaciente Is Nothing Then
                Return True
            Else
                If Len(objPaciente.TipoDocumento) <= 0 And Len(objPaciente.NumeroDocumento) <= 0 Then
                    Return True
                End If
            End If
            Return False
        End Function

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub
    End Class

End Namespace
