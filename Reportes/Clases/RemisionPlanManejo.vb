
Imports System.Data.Common
Imports System.Collections.Generic
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion
Imports HistoriaClinica.Sophia.HistoriaClinica.HistoriaBasica
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales

Namespace Sophia.HistoriaClinica.Reportes
    ''' --------------------------------------------------------------------------------------------------
    ''' Project	 : HistoriaClinica.Reportes.Clases
    ''' Class	 : Sophia.HistoriaClinica.Reportes.RemisionPlanManejo
    ''' --------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Clase RemisionPlanManejo del namespace Sophia.HistoriaClinica.Reportes que es la clase base
    ''' Esta clase se utiliza para almacenar la información correspondiente a la remision para el
    ''' reporte de remisiones del Plan de Manejo y se utilizados en la aplicación Window 2005 
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' [mvargas]	24/05/2006 Created
    ''' </history>
    ''' ---------------------------------------------------------------------------------------------------

    Public Class RemisionPlanManejo
        Inherits GPMDataReport

        Private strEmpresa As String
        Private strFechaRemision As String
        Private intHoraRemision As Integer
        Private intMinutoRemision As Integer
        Private strMedicoRemite As String
        Private strTipoDocUsuario As String
        Private strNumDocUsuario As String
        Private strApellidoUsuario As String
        Private strNombreUsuario As String
        Private strEntidadAfiliacion As String
        Private strTipoEntidad As String
        Private intEdadUsuario As Integer
        Private strUnidadTiempoUsuario As String
        Private strSexoUsuario As String
        Private strNumeroAdmisionUsuario As String
        Private strLugarNacimientoUsuario As String
        Private strOcupacionUsuario As String
        Private strEstadoCivilUsuario As String
        Private strTelefonoUsuario As String
        Private strDireccionUsuario As String
        Private strDeptoResidenciaUsuario As String
        Private strCiudadResidenciaUsuario As String
        Private strNombreResponsable As String
        Private strTipoDocResponsable As String
        Private strNumeroDocResponsable As String
        Private strParentescoResponsable As String
        Private strDireccionResponsable As String
        Private strTelefonoResponsable As String
        Private strDirOficinaResponsable As String
        Private strTelOficinaResponsable As String
        Private strNombreMedico As String
        Private strTipoDocMedico As String
        Private strDocumentoMedico As String
        Private strRegistroMedico As String
        Private strFechaActual As String
        Private strNumeroAutoriza As String
        Private strFechaAutoriza As String
        Private strHoraAutoriza As String
        Private strMinutoAutoriza As String
        Private strSucursal As String
        Private strTipoUsuario As String
        Private strCondicionUsuaria As String
        Private strObservaciones As String
        Private strPais As String

        Private strDesInstitucion As String
        Private strServicio As String
        Private strDesAmbulancia As String
        Private strDescNivel As String
        Private strMedicoConfirma As String
        Private strCargoMedico As String
        Private strAnanmesis As String
        Private strAuxiliarDiagnostico As String
        Private strEvolucion As String
        Private strDiagnostico As String
        Private strComplicaciones As String
        Private strTratamientos As String
        Private strMotivos As String
        Private strEstadoPaciente As String
        Private _secuencia As String 'martovar
        Private _pais As String  'martovar
        Public objDatosGenerales As objGeneral.Generales

        Public Sub New()

        End Sub

#Region "Propiedades"
        Public ReadOnly Property Empresa() As String
            Get
                Return strEmpresa
            End Get
        End Property
        Public ReadOnly Property FechaRemision() As String
            Get
                Return strFechaRemision
            End Get
        End Property
        Public ReadOnly Property HoraRemision() As Integer
            Get
                Return intHoraRemision
            End Get
        End Property
        Public ReadOnly Property MinutoRemision() As Integer
            Get
                Return intMinutoRemision
            End Get
        End Property
        Public ReadOnly Property MedicoRemite() As String
            Get
                Return strMedicoRemite
            End Get
        End Property
        Public ReadOnly Property TipoDocUsuario() As String
            Get
                Return strTipoDocUsuario
            End Get
        End Property
        Public ReadOnly Property NumDocUsuario() As String
            Get
                Return strNumDocUsuario
            End Get
        End Property
        Public ReadOnly Property ApellidoUsuario() As String
            Get
                Return strApellidoUsuario
            End Get
        End Property
        Public ReadOnly Property NombreUsuario() As String
            Get
                Return strNombreUsuario
            End Get
        End Property
        Public ReadOnly Property EntidadAfiliacion() As String
            Get
                Return strEntidadAfiliacion
            End Get
        End Property
        Public ReadOnly Property TipoEntidad() As String
            Get
                Return strTipoEntidad
            End Get
        End Property
        Public ReadOnly Property EdadUsuario() As Integer
            Get
                Return intEdadUsuario
            End Get
        End Property
        Public ReadOnly Property UnidadTiempoUsuario() As String
            Get
                Return strUnidadTiempoUsuario
            End Get
        End Property
        Public ReadOnly Property SexoUsuario() As String
            Get
                Return strSexoUsuario
            End Get
        End Property
        Public ReadOnly Property NumeroAdmisionUsuario() As String
            Get
                Return strNumeroAdmisionUsuario
            End Get
        End Property
        Public ReadOnly Property LugarNacimientoUsuario() As String
            Get
                Return strLugarNacimientoUsuario
            End Get
        End Property
        Public ReadOnly Property OcupacionUsuario() As String
            Get
                Return strOcupacionUsuario
            End Get
        End Property
        Public ReadOnly Property EstadoCivilUsuario() As String
            Get
                Return strEstadoCivilUsuario
            End Get
        End Property
        Public ReadOnly Property TelefonoUsuario() As String
            Get
                Return strTelefonoUsuario
            End Get
        End Property
        Public ReadOnly Property DireccionUsuario() As String
            Get
                Return strDireccionUsuario
            End Get
        End Property
        Public ReadOnly Property DeptoResidenciaUsuario() As String
            Get
                Return strDeptoResidenciaUsuario
            End Get
        End Property
        Public ReadOnly Property CiudadResidenciaUsuario() As String
            Get
                Return strCiudadResidenciaUsuario
            End Get
        End Property
        Public ReadOnly Property NombreResponsable() As String
            Get
                Return strNombreResponsable
            End Get
        End Property
        Public ReadOnly Property TipoDocResponsable() As String
            Get
                Return strTipoDocResponsable
            End Get
        End Property
        Public ReadOnly Property NumeroDocResponsable() As String
            Get
                Return strNumeroDocResponsable
            End Get
        End Property
        Public ReadOnly Property ParentescoResponsable() As String
            Get
                Return strParentescoResponsable
            End Get
        End Property
        Public ReadOnly Property DireccionResponsable() As String
            Get
                Return strDireccionResponsable
            End Get
        End Property
        Public ReadOnly Property TelefonoResponsable() As String
            Get
                Return strTelefonoResponsable
            End Get
        End Property
        Public ReadOnly Property DirOficinaResponsable() As String
            Get
                Return strDirOficinaResponsable
            End Get
        End Property
        Public ReadOnly Property TelOficinaResponsable() As String
            Get
                Return strTelOficinaResponsable
            End Get
        End Property
        Public ReadOnly Property NombreMedico() As String
            Get
                Return strNombreMedico
            End Get
        End Property
        Public ReadOnly Property TipoDocMedico() As String
            Get
                Return strTipoDocMedico
            End Get
        End Property
        Public ReadOnly Property DocumentoMedico() As String
            Get
                Return strDocumentoMedico
            End Get
        End Property
        Public ReadOnly Property RegistroMedico() As String
            Get
                Return strRegistroMedico
            End Get
        End Property
        Public ReadOnly Property FechaActual() As String
            Get
                Return strFechaActual
            End Get
        End Property
        Public Property NumeroAutoriza() As String
            Get
                Return strNumeroAutoriza
            End Get
            Set(ByVal value As String)
                strNumeroAutoriza = value
            End Set
        End Property
        Public Property FechaAutoriza() As String
            Get
                Return strFechaAutoriza
            End Get
            Set(ByVal value As String)
                If IsDate(value) Then
                    value = Format(CDate(value), "dd/MM/yyyy")
                End If
                strFechaAutoriza = value
            End Set
        End Property
        Public Property HoraAutoriza() As String
            Get
                Return strHoraAutoriza
            End Get
            Set(ByVal value As String)
                strHoraAutoriza = value
            End Set
        End Property
        Public Property MinutoAutoriza() As String
            Get
                Return strMinutoAutoriza
            End Get
            Set(ByVal value As String)
                strMinutoAutoriza = value
            End Set
        End Property
        Public ReadOnly Property Sucursal() As String
            Get
                Return strSucursal
            End Get
        End Property
        Public Property TipoUsuario() As String
            Get
                Return strTipoUsuario
            End Get
            Set(ByVal value As String)
                strTipoUsuario = value
            End Set
        End Property

        Public Property CondicionUsuaria() As String
            Get
                Return strCondicionUsuaria
            End Get
            Set(ByVal value As String)
                strCondicionUsuaria = value
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

        Public Property DesAmbulancia() As String
            Get
                Return strDesAmbulancia
            End Get
            Set(ByVal value As String)
                strDesAmbulancia = value
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

        Public Property secuencia() As String
            Get
                Return _secuencia
            End Get
            Set(ByVal value As String)
                _secuencia = value
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


        Public Property EstadoPaciente() As String
            Get
                Return strEstadoPaciente
            End Get
            Set(ByVal value As String)
                strEstadoPaciente = value
            End Set
        End Property

#End Region

        Public Sub New(ByVal sEmpresa As String, ByVal sFechaRemision As String,
                        ByVal iHoraRemision As Integer, ByVal iMinutoRemision As Integer,
                        ByVal sMedicoRemite As String, ByVal sTipoDocUsuario As String,
                        ByVal sNumDocUsuario As String, ByVal sApellidoUsuario As String,
                        ByVal sNombreUsuario As String, ByVal sEntidadAfiliacion As String,
                        ByVal sTipoEntidad As String, ByVal iEdadUsuario As Integer,
                        ByVal sUnidadTiempoUsuario As String, ByVal sSexoUsuario As String,
                        ByVal sNumeroAdmisionUsuario As String, ByVal sLugarNacimientoUsuario As String,
                        ByVal sOcupacionUsuario As String, ByVal sEstadoCivilUsuario As String,
                        ByVal sTelefonoUsuario As String, ByVal sDireccionUsuario As String,
                        ByVal sDeptoResidenciaUsuario As String, ByVal sCiudadResidenciaUsuario As String,
                        ByVal sNombreResponsable As String, ByVal sTipoDocResponsable As String,
                        ByVal sNumeroDocResponsable As String, ByVal sParentescoResponsable As String,
                        ByVal sDireccionResponsable As String, ByVal sTelefonoResponsable As String,
                        ByVal sDirOficinaResponsable As String, ByVal sTelOficinaResponsable As String,
                        ByVal sNombreMedico As String, ByVal sTipoDocMedico As String,
                        ByVal sDocumentoMedico As String, ByVal sRegistroMedico As String,
                        ByVal sFechaActual As String, ByVal sFechaAutoriza As String,
                        ByVal sHoraAutoriza As String, ByVal sMinutoAutoriza As String, ByVal sSucursal As String)

            strEmpresa = sEmpresa
            strFechaRemision = sFechaRemision
            intHoraRemision = iHoraRemision
            intMinutoRemision = iMinutoRemision
            strMedicoRemite = sMedicoRemite
            strTipoDocUsuario = sTipoDocUsuario
            strNumDocUsuario = sNumDocUsuario
            strApellidoUsuario = sApellidoUsuario
            strNombreUsuario = sNombreUsuario
            strEntidadAfiliacion = sEntidadAfiliacion
            strTipoEntidad = sTipoEntidad
            intEdadUsuario = iEdadUsuario
            strUnidadTiempoUsuario = sUnidadTiempoUsuario
            strSexoUsuario = sSexoUsuario
            strNumeroAdmisionUsuario = sNumeroAdmisionUsuario
            strLugarNacimientoUsuario = sLugarNacimientoUsuario
            strOcupacionUsuario = sOcupacionUsuario
            strEstadoCivilUsuario = sEstadoCivilUsuario
            strTelefonoUsuario = sTelefonoUsuario
            strDireccionUsuario = sDireccionUsuario
            strDeptoResidenciaUsuario = sDeptoResidenciaUsuario
            strCiudadResidenciaUsuario = sCiudadResidenciaUsuario
            strNombreResponsable = sNombreResponsable
            strTipoDocResponsable = sTipoDocResponsable
            strNumeroDocResponsable = sNumeroDocResponsable
            strParentescoResponsable = sParentescoResponsable
            strDireccionResponsable = sDireccionResponsable
            strTelefonoResponsable = sTelefonoResponsable
            strDirOficinaResponsable = sDirOficinaResponsable
            strTelOficinaResponsable = sTelOficinaResponsable
            strNombreMedico = sNombreMedico
            strTipoDocMedico = sTipoDocMedico
            strDocumentoMedico = sDocumentoMedico
            strRegistroMedico = sRegistroMedico
            strFechaActual = sFechaActual
            strFechaAutoriza = sFechaAutoriza
            strHoraAutoriza = sHoraAutoriza
            strMinutoAutoriza = sMinutoAutoriza
            strSucursal = sSucursal

        End Sub

        Public Function crearRemision(ByVal strCodigoPrestador As String, ByVal strCodigoSucursal As String,
                                ByVal strTipDoc As String, ByVal strNumDoc As String,
                                ByVal strTipAdm As String, ByVal iAno As Integer,
                                ByVal lNumAdm As Long) As Boolean
            Dim dtRemision As DataTable

            dtRemision = consultarRemision(strCodigoPrestador, strCodigoSucursal, strTipDoc, strNumDoc, strTipAdm, iAno,
                                               lNumAdm)

            Return inicializarRemision(dtRemision)

        End Function

        Private Function consultarRemision(ByVal strCodigoPrestador As String, ByVal strCodigoSucursal As String,
                                              ByVal strTipDoc As String, ByVal strNumDoc As String,
                                              ByVal strTipAdm As String, ByVal iAno As Integer,
                                               ByVal lNumAdm As Long) As DataTable

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 14/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper
            Dim dtSet As DataSet
            Dim dt As DataTable = Nothing
            Dim objC As objCon = objCon.Instancia

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objC.strServidor, objC.strBaseDatos, objC.strUsuarioBD, objC.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''Using cmd
            '' ''    cmd = db.GetStoredProcCommandWrapper("HC_Reportes_Remision")

            '' ''    With cmd
            '' ''        .AddInParameter("strCodigoPrestador", DbType.String, strCodigoPrestador)
            '' ''        .AddInParameter("strCodigoSucursal", DbType.String, strCodigoSucursal)
            '' ''        .AddInParameter("strTipoDocumento", DbType.String, strTipDoc)
            '' ''        .AddInParameter("strNumDoc", DbType.String, strNumDoc)
            '' ''        .AddInParameter("strTipoAdmision", DbType.String, strTipAdm)
            '' ''        .AddInParameter("lAnoAdmision", DbType.Int32, iAno)
            '' ''        .AddInParameter("dNumeroAdmision", DbType.Double, lNumAdm)
            '' ''    End With

            '' ''    ds = db.ExecuteDataSet(cmd)
            '' ''    dt = ds.Tables(0)
            '' ''End Using

            gpmDataObj.setSQLSentence("HC_Reportes_Remision", CommandType.StoredProcedure)

            gpmDataObj.addInputParameter("strCodigoPrestador", SqlDbType.VarChar, strCodigoPrestador)
            gpmDataObj.addInputParameter("strCodigoSucursal", SqlDbType.VarChar, strCodigoSucursal)
            gpmDataObj.addInputParameter("strTipoDocumento", SqlDbType.VarChar, strTipDoc)
            gpmDataObj.addInputParameter("strNumDoc", SqlDbType.VarChar, strNumDoc)
            gpmDataObj.addInputParameter("strTipoAdmision", SqlDbType.VarChar, strTipAdm)
            gpmDataObj.addInputParameter("lAnoAdmision", SqlDbType.Int, iAno)
            gpmDataObj.addInputParameter("dNumeroAdmision", SqlDbType.Decimal, lNumAdm)


            dtSet = gpmDataObj.execDS()
            ' If Not dtSet Is Nothing Then
            If dtSet.Tables.Count > 0 Then
                dt = dtSet.Tables(0)
            End If

            Return dt
        End Function

        Public Function inicializarRemision(ByVal dtRemision As DataTable) As Boolean

            Dim strCodigoCondicionUsuaria As String

            objDatosGenerales = objGeneral.Generales.Instancia

            If dtRemision Is Nothing Then
                Return False
            End If
            If dtRemision.Rows.Count <= 0 Then
                Return False
            End If

            With dtRemision.Rows(0)
                strEmpresa = .Item("Empresa").ToString
                strFechaRemision = .Item("FechaRemision").ToString
                intHoraRemision = .Item("HoraRemision").ToString
                intMinutoRemision = .Item("MinutoRemision").ToString
                strMedicoRemite = .Item("MedicoRemite").ToString
                strTipoDocUsuario = .Item("TipoDocUsurio").ToString
                strNumDocUsuario = .Item("NumDocUsuario").ToString
                strApellidoUsuario = .Item("ApellidoUsuario").ToString
                strNombreUsuario = .Item("NombreUsuario").ToString
                strEntidadAfiliacion = .Item("EntidadAfiliacion").ToString
                strTipoEntidad = .Item("TipoEntidad").ToString
                intEdadUsuario = .Item("EdadUsuario").ToString
                strUnidadTiempoUsuario = .Item("UnidadTiempoUsuario").ToString
                strSexoUsuario = .Item("SexoUsuario").ToString
                strNumeroAdmisionUsuario = .Item("NumeroAdmisionUsuario").ToString
                strLugarNacimientoUsuario = .Item("LugarNacimientoUsuario").ToString
                strOcupacionUsuario = .Item("OcupacionUsuario").ToString
                strEstadoCivilUsuario = .Item("EstadoCivilUsuario").ToString
                strTelefonoUsuario = .Item("TelefonoUsuario").ToString
                strDireccionUsuario = .Item("DireccionUsuario").ToString
                strDeptoResidenciaUsuario = .Item("DepartamentoResidenciaUsuario").ToString
                strCiudadResidenciaUsuario = .Item("CiudadResidenciaUsuario").ToString
                strNombreResponsable = .Item("NombreResponsable").ToString
                strTipoDocResponsable = .Item("TipoDocResponsable").ToString
                strNumeroDocResponsable = .Item("NumeroDocResponsable").ToString
                strParentescoResponsable = .Item("ParentescoResponsable").ToString
                strDireccionResponsable = .Item("DireccionResponsable").ToString
                strTelefonoResponsable = .Item("TelefonoResponsable").ToString
                strDirOficinaResponsable = .Item("OficinaResponsable").ToString
                strTelOficinaResponsable = .Item("TelefonoOficinaResponsable").ToString
                strNombreMedico = .Item("NombreMedico").ToString
                strTipoDocMedico = .Item("TipoDocMedico").ToString
                strDocumentoMedico = .Item("DocumentoMedico").ToString
                _pais = .Item("Pais").ToString

                '_pais = objDatosGenerales.Pais

                If objDatosGenerales.Pais = "482" Then ''agregar segundo registro médico para Perú. Cpgaray Octubre 21 de 2013
                    If Len(.Item("RegistroMedico2").ToString) = 0 Then
                        strRegistroMedico = .Item("RegistroMedico").ToString
                    Else
                        strRegistroMedico = .Item("RegistroMedico").ToString & " - " & .Item("RegistroMedico2").ToString
                    End If
                    _secuencia = .Item("Secuencia").ToString
                Else
                    strRegistroMedico = .Item("RegistroMedico").ToString
                End If


                strFechaActual = .Item("FechaActual").ToString
                strNumeroAutoriza = .Item("NumeroAutorizacion").ToString
                Me.FechaAutoriza = .Item("FechaAutorizacion").ToString
                strHoraAutoriza = .Item("HoraAutorizacion").ToString
                strMinutoAutoriza = .Item("MinutoAutorizacion").ToString
                strSucursal = .Item("Sucursal").ToString
                strObservaciones = .Item("Observaciones").ToString

                strCodigoCondicionUsuaria = DatosHistoriaBasica.Instancia.ImpresionDiagnostica.CodigoCondicionUsuaria

                Select Case strCodigoCondicionUsuaria
                    Case "1"
                        strCondicionUsuaria = "EMBARAZO PRIMER TRIMESTRE"
                    Case "2"
                        strCondicionUsuaria = "EMBARAZO SEGUNDO TRIMESTRE"
                    Case "3"
                        strCondicionUsuaria = "EMBARAZO TERCER TRIMESTRE"
                    Case "4"
                        strCondicionUsuaria = "NO EMBARAZADA"
                    Case Else
                        strCondicionUsuaria = ""
                End Select

                Select Case UCase(Mid(.Item("TipoEntidad").ToString, 1, 3))
                    Case "ARS"
                        strTipoUsuario = "SUBSIDIADO"
                    Case "EPS"
                        strTipoUsuario = "CONTRIBUTIVO"
                    Case "PAR"
                        strTipoUsuario = "PARTICULAR"
                    Case Else
                        strTipoUsuario = "OTRO"
                End Select

            End With

            Return True

        End Function

    End Class
End Namespace
