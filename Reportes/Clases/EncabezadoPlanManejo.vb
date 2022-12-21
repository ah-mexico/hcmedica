Imports System.Data.Common
Imports System.Collections.Generic
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
''''////
Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales

Namespace Sophia.HistoriaClinica.Reportes
    ''' --------------------------------------------------------------------------------------------------
    ''' Project	 : HistoriaClinica.Reportes.Clases
    ''' Class	 : Sophia.HistoriaClinica.Reportes.EncabezadoPlanManejo
    ''' --------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Clase EncabezadoPlanManejo del namespace Sophia.HistoriaClinica.Reportes que es la clase base
    ''' Esta clase se utiliza para almacenar la información correspondiente a los encabezados para los
    ''' los reportes del Plan de Manejo y se utilizados en la aplicación Window 2005 
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' [mvargas]	16/05/2006 Created
    ''' </history>
    ''' ---------------------------------------------------------------------------------------------------
    Public Class EncabezadoPlanManejo
        Inherits GPMDataReport

        Private _nombreCompania As String
        Private _nombreSucursal As String
        Private _nit As String
        Private _direccion As String
        Private _telefono As String
        Private _nombreUsuario As String
        Private _DocumentoUsuario As String
        Private _planUsuario As String
        Private _numeroCarne As String
        Private _ciudad As String
        Private _entidadPrestadora As String
        Private _entidadAfiliacion As String
        Private _tipoDocumento As String
        Private _tipoUsuario As String
        Private _nombreMedico As String
        Private _documentoMedico As String
        Private _registroMedico As String
        Private _especialidadMed As String
        Private _fechaActual As String

        Private _NombreMedicoEgreso As String
        Private _DocumentoMedicoEgreso As String
        Private _RegistroMedicoEgreso As String
        Private _EspecialidadEgreso As String
        Private _des_especialidadEgreso As String

        Private objDatosGenerales As objGeneral.Generales

        ' Private _nitEmpresaTrabajaUsuario As String



        Public Sub New()

        End Sub

        Public Property NombreCompania() As String
            Get
                Return _nombreCompania
            End Get
            Set(ByVal Value As String)
                _nombreCompania = Value
            End Set
        End Property


        Public Property NombreSucursal() As String
            Get
                Return _nombreSucursal
            End Get
            Set(ByVal Value As String)
                _nombreSucursal = Value
            End Set
        End Property


        Public Property Nit() As String
            Get
                Return _nit
            End Get
            Set(ByVal Value As String)
                _nit = Value
            End Set
        End Property


        Public Property Direccion() As String
            Get
                Return _direccion
            End Get
            Set(ByVal Value As String)
                _direccion = Value
            End Set
        End Property


        Public Property Telefono() As String
            Get
                Return _telefono
            End Get
            Set(ByVal Value As String)
                _telefono = Value
            End Set
        End Property


        Public Property NombreUsuario() As String
            Get
                Return _nombreUsuario
            End Get
            Set(ByVal Value As String)
                _nombreUsuario = Value
            End Set
        End Property

        Public Property DocumentoUsuario() As String
            Get
                Return _DocumentoUsuario
            End Get
            Set(ByVal Value As String)
                _DocumentoUsuario = Value
            End Set
        End Property


        Public Property PlanUsuario() As String
            Get
                Return _planUsuario
            End Get
            Set(ByVal Value As String)
                _planUsuario = Value
            End Set
        End Property


        Public Property NumeroCarne() As String
            Get
                Return _numeroCarne
            End Get
            Set(ByVal Value As String)
                _numeroCarne = Value
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

        Public Property EntidadPrestadora() As String
            Get
                Return _entidadPrestadora
            End Get
            Set(ByVal Value As String)
                _entidadPrestadora = Value
            End Set
        End Property

        Public Property EntidadAfiliacion() As String
            Get
                Return _entidadAfiliacion
            End Get
            Set(ByVal Value As String)
                _entidadAfiliacion = Value
            End Set
        End Property

        Public Property TipoDocumento() As String
            Get
                Return _tipoDocumento
            End Get
            Set(ByVal Value As String)
                _tipoDocumento = Value
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

        Public Property NombreMedico() As String
            Get
                Return _nombreMedico
            End Get
            Set(ByVal Value As String)
                _nombreMedico = Value
            End Set
        End Property

        Public Property DocumentoMedico() As String
            Get
                Return _documentoMedico
            End Get
            Set(ByVal Value As String)
                _documentoMedico = Value
            End Set
        End Property

        Public Property RegistroMedico() As String
            Get
                Return _registroMedico
            End Get
            Set(ByVal Value As String)
                _registroMedico = Value
            End Set
        End Property



        Public Property EspecialidadMed() As String
            Get
                Return _especialidadMed
            End Get
            Set(ByVal value As String)
                _especialidadMed = value
            End Set
        End Property


        Public Property FechaActual() As String
            Get
                Return _fechaActual
            End Get
            Set(ByVal Value As String)
                _fechaActual = Value
            End Set
        End Property
        Public Property NombreMedicoEgreso() As String
            Get
                Return _NombreMedicoEgreso
            End Get
            Set(ByVal value As String)
                _NombreMedicoEgreso = value
            End Set
        End Property
        Public Property DocumentoMedicoEgreso() As String
            Get
                Return _DocumentoMedicoEgreso
            End Get
            Set(ByVal value As String)
                _DocumentoMedicoEgreso = value
            End Set
        End Property
        Public Property RegistroMedicoEgreso() As String
            Get
                Return _RegistroMedicoEgreso
            End Get
            Set(ByVal value As String)
                _RegistroMedicoEgreso = value
            End Set
        End Property
        Public Property EspecialidadEgreso() As String
            Get
                Return _EspecialidadEgreso
            End Get
            Set(ByVal value As String)
                _EspecialidadEgreso = value
            End Set
        End Property
        Public Property des_especialidadEgreso() As String
            Get
                Return _des_especialidadEgreso
            End Get
            Set(ByVal value As String)
                _des_especialidadEgreso = value
            End Set
        End Property

        'Public Property NitEmpresaTrabajaUsuario() As String
        '    Get
        '        Return _nitEmpresaTrabajaUsuario
        '    End Get
        '    Set(ByVal value As String)
        '        _nitEmpresaTrabajaUsuario = value
        '    End Set
        'End Property

        Public Sub New(ByVal strnombreCompania As String, ByVal strNombreSucursal As String, _
                        ByVal strNit As String, ByVal strDireccion As String, ByVal strTelefono As String, _
                        ByVal strNombreUsuario As String, ByVal strDocumentoUsuario As String, _
                        ByVal strPlanUsuario As String, ByVal strNumeroCarne As String, _
                        ByVal strCiudad As String, ByVal strEntidadPrestadora As String, _
                        ByVal strentidadAfiliacion As String, ByVal strTipoDocumento As String, _
                        ByVal strTipoUsuario As String, ByVal strNombreMedico As String, _
                        ByVal strDocumentoMedico As String, ByVal strRegistroMedico As String, _
                        ByVal strFecha As String, ByVal strNitEmpresaTrabajaUsuario As String)
            ' ByVal strFecha As String, ByVal strNitEmpresaTrabajaUsuario As String)

            _nombreCompania = strnombreCompania
            _nombreSucursal = strNombreSucursal
            _nit = strNit
            _direccion = strDireccion
            _telefono = strTelefono
            _nombreUsuario = strNombreUsuario
            _DocumentoUsuario = strDocumentoUsuario
            _planUsuario = strPlanUsuario
            _numeroCarne = strNumeroCarne
            _ciudad = strCiudad
            _entidadPrestadora = strEntidadPrestadora
            _entidadAfiliacion = strentidadAfiliacion
            _tipoDocumento = strTipoDocumento
            _tipoUsuario = strTipoUsuario
            _nombreMedico = strNombreMedico
            _documentoMedico = strDocumentoMedico
            _registroMedico = strRegistroMedico
            _fechaActual = strFecha
            ' _nitEmpresaTrabajaUsuario = strNitEmpresaTrabajaUsuario

            _NombreMedicoEgreso = ""
            _DocumentoMedicoEgreso = ""
            _RegistroMedicoEgreso = ""
            _EspecialidadEgreso = ""
            _des_especialidadEgreso = ""


        End Sub


        Public Sub crearEncabezado(ByVal strcod_pre_sgs As String, ByVal strCod_sucur As String, _
                                              ByVal strTipDoc As String, ByVal strNumDoc As String, _
                                              ByVal strTipAdm As String, ByVal iAno As Integer, _
                                               ByVal lNumAdm As Long)
            Dim dtEncabezado As DataTable

            dtEncabezado = consultarEncabezado(strcod_pre_sgs, strCod_sucur, strTipDoc, strNumDoc, strTipAdm, iAno, _
                                               lNumAdm)

            inicializarEncabezado(dtEncabezado)

        End Sub

        Private Function consultarEncabezado(ByVal strcod_pre_sgs As String, ByVal strCod_sucur As String, _
                                              ByVal strTipDoc As String, ByVal strNumDoc As String, _
                                              ByVal strTipAdm As String, ByVal iAno As Integer, _
                                               ByVal lNumAdm As Long) As DataTable

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 13/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper
            '' ''Dim ds As DataSet
            Dim dt As DataTable = Nothing
            '' ''Dim objC As objCon = objCon.Instancia

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objC.strServidor, objC.strBaseDatos, objC.strUsuarioBD, objC.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''Using cmd
            '' ''    cmd = db.GetStoredProcCommandWrapper("HC_Reportes_PlanEncabezado")

            '' ''    With cmd
            '' ''        .AddInParameter("strCodigoPrestador", DbType.String, strcod_pre_sgs)
            '' ''        .AddInParameter("strCodigoSucursal", DbType.String, strCod_sucur)
            '' ''        .AddInParameter("strTipoDocumento", DbType.String, strTipDoc)
            '' ''        .AddInParameter("strNumDoc", DbType.String, strNumDoc)
            '' ''        .AddInParameter("strTipoAdmision", DbType.String, strTipAdm)
            '' ''        .AddInParameter("lAnoAdmision", DbType.Int32, iAno)
            '' ''        .AddInParameter("dNumeroAdmision", DbType.Double, lNumAdm)
            '' ''    End With

            '' ''    ds = db.ExecuteDataSet(cmd)
            '' ''    dt = ds.Tables(0)
            '' ''End Using

            gpmDataObj.setSQLSentence("HC_Reportes_PlanEncabezado", CommandType.StoredProcedure)

            gpmDataObj.addInputParameter("strCodigoPrestador", SqlDbType.VarChar, strcod_pre_sgs)
            gpmDataObj.addInputParameter("strCodigoSucursal", SqlDbType.VarChar, strCod_sucur)
            gpmDataObj.addInputParameter("strTipoDocumento", SqlDbType.VarChar, strTipDoc)
            gpmDataObj.addInputParameter("strNumDoc", SqlDbType.VarChar, strNumDoc)
            gpmDataObj.addInputParameter("strTipoAdmision", SqlDbType.VarChar, strTipAdm)
            gpmDataObj.addInputParameter("lAnoAdmision", SqlDbType.Int, iAno)
            gpmDataObj.addInputParameter("dNumeroAdmision", SqlDbType.Decimal, lNumAdm)

            dt = gpmDataObj.execDS().Tables(0)

            Return dt
        End Function

        Public Sub inicializarEncabezado(ByVal dtEncabezado As DataTable)

            objDatosGenerales = objGeneral.Generales.Instancia
            If dtEncabezado.Rows.Count <= 0 Then
                Exit Sub
            End If

            With dtEncabezado.Rows(0)
                _nombreCompania = .Item("Empresa").ToString
                _nombreSucursal = .Item("Sucursal").ToString
                _direccion = .Item("DireccionSucursal").ToString
                _telefono = .Item("TelefonoSucursal").ToString
                _nit = .Item("NitSucursal").ToString
                _nombreUsuario = .Item("NombreUsuario").ToString
                _DocumentoUsuario = .Item("NumDocUsuario").ToString
                _planUsuario = .Item("TipoPlan").ToString
                _numeroCarne = .Item("CarneUsuario").ToString
                _ciudad = .Item("CiudadSucursal").ToString
                _entidadAfiliacion = .Item("EntidadAfiliacion").ToString
                _tipoDocumento = .Item("TipoDocUsuario").ToString

                Select Case UCase(Mid(.Item("TipoEntidad").ToString, 1, 3))
                    Case "ARS"
                        _tipoUsuario = "SUBSIDIADO"
                    Case "EPS"
                        _tipoUsuario = "CONTRIBUTIVO"
                    Case "PAR"
                        _tipoUsuario = "PARTICULAR"
                    Case Else
                        _tipoUsuario = "OTRO"
                End Select

                ' _tipoUsuario = .Item("tipoUsuario").ToString
                _nombreMedico = .Item("NombreMedico").ToString
                _documentoMedico = .Item("DocumentoMedico").ToString


                If objDatosGenerales.Pais = "482" Then ''agregar segundo registro médico para Perú. Cpgaray Octubre 21 de 2013
                    If Len(.Item("RegistroMedico2").ToString) = 0 Then
                        _registroMedico = .Item("RegistroMedico").ToString
                    Else
                        _registroMedico = .Item("RegistroMedico").ToString & " - " & .Item("RegistroMedico2").ToString
                    End If
                    If Len(.Item("RegistroMedicoEgreso2").ToString) = 0 Then
                        _RegistroMedicoEgreso = .Item("RegistroMedicoEgreso").ToString
                    Else
                        _RegistroMedicoEgreso = .Item("RegistroMedicoEgreso").ToString & " - " & .Item("RegistroMedicoEgreso2").ToString
                    End If

                Else
                    _registroMedico = .Item("RegistroMedico").ToString
                    _RegistroMedicoEgreso = .Item("RegistroMedicoEgreso").ToString
                End If

                _especialidadMed = .Item("des_especialidad").ToString
                _fechaActual = .Item("FechaActual").ToString
                ' dtEncabezado.Rows(0).Item("NombreMedicoEgreso").ToString
                ' _nitEmpresaTrabajaUsuario = .Item("NitEmpresaUsuario").ToString
                _NombreMedicoEgreso = .Item("NombreMedicoEgreso").ToString
                _DocumentoMedicoEgreso = .Item("DocumentoMedicoEgreso").ToString
                _EspecialidadEgreso = .Item("EspecialidadEgreso").ToString
                _des_especialidadEgreso = .Item("des_especialidadEgreso").ToString
            End With
        End Sub
    End Class
End Namespace