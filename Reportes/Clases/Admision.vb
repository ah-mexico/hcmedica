Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports System.Collections.Generic
Imports System.Data.Common


Namespace Sophia.HistoriaClinica.Reportes
    Public Class Admision
        Inherits GPMDataReport

        Private _servicio As String
        Private _sucursal As String
        Private _numAdmision As String
        Private _cama As String
        Private _tipoCama As String
        Private _seccion As String
        Private _fechaIngreso As String
        Private _horaIngreso As String
        Private _idMedicoTratante As String
        Private _nombreMedicoTratante As String
        Private _idMedicoHospital As String
        Private _nombreMedicoHospital As String
        Private _entidad As String
        Private _autoriza As String
        Private _autorizacion As String
        Private _loginCreacion As String
        Private _clasificacion As String
        Private _paciente As Paciente
        Private _numAnticipo As String
        Private _valAnticipo As String
        Private _labelNumAnticipo As String
        Private _labelValAnticipo As String
        Private _login As String
        Private _fecha As String
        Private _ObsAdmision As String
        Private _copia As String
        Private _causaExterna As String
        Private _incapacidad As String
        Private _diasIncapacidad As String
        Private _fechaInicialIncapacidad As String
        Private _fechaFinalIncapacidad As String


#Region "Propiedades"
        Public ReadOnly Property Servicio() As String
            Get
                Return _servicio
            End Get
        End Property
        Public ReadOnly Property Sucursal() As String
            Get
                Return _sucursal
            End Get
        End Property
        Public ReadOnly Property NumeroAdmision() As String
            Get
                Return _numAdmision
            End Get
        End Property
        Public ReadOnly Property Cama() As String
            Get
                Return _cama
            End Get
        End Property
        Public ReadOnly Property TipoCama() As String
            Get
                Return _tipoCama
            End Get
        End Property
        Public ReadOnly Property Seccion() As String
            Get
                Return _seccion
            End Get
        End Property
        Public ReadOnly Property FechaIngreso() As String
            Get
                Return _fechaIngreso
            End Get
        End Property
        Public ReadOnly Property HoraIngreso() As String
            Get
                Return _horaIngreso
            End Get
        End Property
        Public ReadOnly Property IDMedicoTratante() As String
            Get
                Return _idMedicoTratante
            End Get
        End Property
        Public ReadOnly Property NombreMedicoTratante() As String
            Get
                Return _nombreMedicoTratante
            End Get
        End Property
        Public ReadOnly Property IDMedicoHospital() As String
            Get
                Return _idMedicoHospital
            End Get
        End Property
        Public ReadOnly Property NombreMedicoHospital() As String
            Get
                Return _nombreMedicoHospital
            End Get
        End Property
        Public ReadOnly Property Entidad() As String
            Get
                Return _entidad
            End Get
        End Property
        Public ReadOnly Property Actualiza() As String
            Get
                Return _autoriza
            End Get
        End Property
        Public ReadOnly Property Actualizacion() As String
            Get
                Return _autorizacion
            End Get
        End Property
        Public ReadOnly Property LoginCreacion() As String
            Get
                Return _loginCreacion
            End Get
        End Property
        Public ReadOnly Property Clasificacion() As String
            Get
                Return _clasificacion
            End Get
        End Property
        Public ReadOnly Property Paciente() As Paciente
            Get
                Return _paciente
            End Get
        End Property
        Public ReadOnly Property NumeroAnticipo() As String
            Get
                Return _numAnticipo
            End Get
        End Property
        Public ReadOnly Property ValorAnticipo() As String
            Get
                Return _valAnticipo
            End Get
        End Property
        Public ReadOnly Property Login() As String
            Get
                Return _login
            End Get
        End Property
        Public ReadOnly Property Fecha() As String
            Get
                Return _fecha
            End Get
        End Property
        Public ReadOnly Property Observaciones() As String
            Get
                Return _ObsAdmision
            End Get
        End Property
        Public ReadOnly Property LabelNumAnticipo() As String
            Get
                Return _labelNumAnticipo
            End Get
        End Property
        Public ReadOnly Property LabelValAnticipo() As String
            Get
                Return _labelValAnticipo
            End Get
        End Property
        Public ReadOnly Property Copia() As String
            Get
                Return _copia
            End Get
        End Property
        Public Property CausaExterna() As String
            Get
                Return _causaExterna
            End Get
            Set(ByVal Value As String)
                _causaExterna = Value
            End Set
        End Property
        Public Property Incapacidad() As String
            Get
                Return _incapacidad
            End Get
            Set(ByVal Value As String)
                _incapacidad = Value
            End Set
        End Property
        Public Property DiasIncapacidad() As String
            Get
                Return _diasIncapacidad
            End Get
            Set(ByVal Value As String)
                _diasIncapacidad = Value
            End Set
        End Property
        Public Property FechaInicialIncapacidad() As String
            Get
                Return _fechaInicialIncapacidad
            End Get
            Set(ByVal value As String)
                _fechaInicialIncapacidad = value
            End Set
        End Property
        Public Property FechaFinalIncapacidad() As String
            Get
                Return _fechaFinalIncapacidad
            End Get
            Set(ByVal value As String)
                _fechaFinalIncapacidad = value
            End Set
        End Property

#End Region

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal causa As String, ByVal incapacidad As String,
                       ByVal diasIncapacita As String, Optional ByVal fechaIncapacidad As String = "")
            _causaExterna = causa
            _incapacidad = incapacidad
            _diasIncapacidad = diasIncapacita
            If IsDate(fechaIncapacidad) And IsNumeric(diasIncapacita) Then
                _fechaInicialIncapacidad = Format(CDate(fechaIncapacidad), "dd/MM/yyyy")
                _fechaFinalIncapacidad = DateAdd(DateInterval.Day, CInt(_diasIncapacidad) - 1, CDate(fechaIncapacidad))
            End If
        End Sub
        Public Function llenarAdmision(ByVal objConexion As Conexion, ByVal intAccion As Integer, ByVal strcod_pre_sgs As String,
                                    ByVal strCod_sucur As String, ByVal strTipDoc As String,
                                    ByVal strNumDoc As String, ByVal strTipAdm As String,
                                    ByVal intAnoAdm As Integer, ByVal dNumAdm As Double) As Integer
            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 13/12/2007
            '' ''Dim cmd As DBCommandWrapper
            Dim iError As Integer
            Dim objPaciente As Paciente
            Dim dtDatosAdm As DataTable
            Dim dtAdmisionesAnt As DataTable

            dtDatosAdm = New DataTable
            dtAdmisionesAnt = New DataTable

            iError = traerDatosReimpresion(objConexion, intAccion, strcod_pre_sgs, strCod_sucur, strTipDoc, strNumDoc, strTipAdm,
                                           intAnoAdm, dNumAdm, dtDatosAdm, dtAdmisionesAnt)

            If iError = 0 Then
                If dtDatosAdm.Rows.Count = 0 Then
                    Return 999
                End If
                '' ''objPaciente = crearPaciente(dtDatosAdm, dtAdmisionesAnt, cmd)
                '' ''inicializar(dtDatosAdm, objPaciente, cmd)

                Dim paramsList As New List(Of SqlClient.SqlParameter)

                For Each param As SqlClient.SqlParameter In gpmDataObj.ParametersCollection
                    paramsList.Add(param)
                Next

                objPaciente = crearPaciente(dtDatosAdm, dtAdmisionesAnt)
                inicializar(dtDatosAdm, objPaciente, paramsList)
            End If

            Return iError
        End Function
        Private Function traerDatosReimpresion(ByVal objConexion As Conexion, ByVal intAccion As Integer, ByVal strcod_pre_sgs As String,
                                    ByVal strCod_sucur As String, ByVal strTipDoc As String,
                                    ByVal strNumDoc As String, ByVal strTipAdm As String,
                                    ByVal intAnoAdm As Integer, ByVal dNumAdm As Double,
                                    ByRef dtDatosAdmision As DataTable,
                                    ByRef dtAdmisionesAnteriores As DataTable) As Integer
            '' ''ByRef cmd As DBCommandWrapper) As Integer
            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 13/12/2007

            '' ''Dim db As Database
            '' ''Dim cmd As DBCommandWrapper
            Dim dtSet As DataSet

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''cmd = db.GetStoredProcCommandWrapper("pa_Reportes_ReImpAdmision")

            '' ''With cmd
            '' ''    .AddInParameter("intAccion", DbType.Int32, intAccion)
            '' ''    .AddInParameter("strCodPreSgs", DbType.String, strcod_pre_sgs)
            '' ''    .AddInParameter("strCodSucur", DbType.String, strCod_sucur)
            '' ''    .AddInParameter("strTipDoc", DbType.String, strTipDoc)
            '' ''    .AddInParameter("strNumDoc", DbType.String, strNumDoc)

            '' ''    .AddInParameter("strTipAdm", DbType.String, strTipAdm)
            '' ''    .AddInParameter("intAnoAdm", DbType.Int32, intAnoAdm)
            '' ''    .AddInParameter("dblNumAdm", DbType.Double, dNumAdm)
            '' ''    .AddInParameter("intEntAdmadmen", DbType.Int32, 1)
            '' ''    .AddInParameter("strFlagPrincipal", DbType.String, "S")

            '' ''    .AddInParameter("strLogin", DbType.String, "")
            '' ''    .AddOutParameter("strAutorizacion", DbType.String, 28)
            '' ''    .AddOutParameter("dblNumAnticipo", DbType.Double, 9)
            '' ''    .AddOutParameter("dblValAnticipo", DbType.Double, 9)
            '' ''    .AddOutParameter("intCantAdm", DbType.Int32, 4)

            '' ''    .AddOutParameter("strTipoDocumento", DbType.String, 50)
            '' ''    .AddOutParameter("strCarnet", DbType.String, 25)
            '' ''    .AddOutParameter("lError", DbType.Int32, 4)
            '' ''End With

            '' ''dts = db.ExecuteDataSet(cmd)
            '' ''dtDatosAdmision = dts.Tables(0)
            '' ''dtAdmisionesAnteriores = dts.Tables(1)

            '' ''Return cmd.GetParameterValue("@lError")

            gpmDataObj.setSQLSentence("pa_Reportes_ReImpAdmision", CommandType.StoredProcedure)

            gpmDataObj.addInputParameter("intAccion", SqlDbType.Int, intAccion)
            gpmDataObj.addInputParameter("strCodPreSgs", SqlDbType.VarChar, strcod_pre_sgs)
            gpmDataObj.addInputParameter("strCodSucur", SqlDbType.VarChar, strCod_sucur)
            gpmDataObj.addInputParameter("strTipDoc", SqlDbType.VarChar, strTipDoc)
            gpmDataObj.addInputParameter("strNumDoc", SqlDbType.VarChar, strNumDoc)

            gpmDataObj.addInputParameter("strTipAdm", SqlDbType.VarChar, strTipAdm)
            gpmDataObj.addInputParameter("intAnoAdm", SqlDbType.Int, intAnoAdm)
            gpmDataObj.addInputParameter("dblNumAdm", SqlDbType.Decimal, dNumAdm)
            gpmDataObj.addInputParameter("intEntAdmadmen", SqlDbType.Int, 1)
            gpmDataObj.addInputParameter("strFlagPrincipal", SqlDbType.VarChar, "S")
            gpmDataObj.addInputParameter("strLogin", SqlDbType.VarChar, "")

            gpmDataObj.addOutputParameter("strAutorizacion", SqlDbType.VarChar, 28)
            'martovar 2014-10-14 se agragan campos de caja y valor_vale que no se estaban enviado al store procedure y estaba generando error en la reimpresion se visualizo en pruebas version 2.9.0
            gpmDataObj.addOutputParameter("strCaja", SqlDbType.VarChar, 28)
            gpmDataObj.addOutputParameter("strValor_Vale", SqlDbType.VarChar, 28)

            gpmDataObj.addOutputParameter("dblNumAnticipo", SqlDbType.Decimal, 9)
            gpmDataObj.addOutputParameter("dblValAnticipo", SqlDbType.Decimal, 9)
            gpmDataObj.addOutputParameter("intCantAdm", SqlDbType.Int)

            gpmDataObj.addOutputParameter("strTipoDocumento", SqlDbType.VarChar, 50)
            gpmDataObj.addOutputParameter("strCarnet", SqlDbType.VarChar, 25)
            gpmDataObj.addOutputParameter("lError", SqlDbType.Int)



            dtSet = gpmDataObj.execDS()
            If dtSet.Tables.Count = 2 Then
                dtDatosAdmision = dtSet.Tables(0)
                dtAdmisionesAnteriores = dtSet.Tables(1)
            End If

            Return Integer.Parse(gpmDataObj.Parameters("@lError").Value)
        End Function

        Private Sub inicializar(ByVal dtDatosAdm As DataTable, ByVal objPaciente As Paciente, ByVal paramsList As List(Of SqlClient.SqlParameter)) '' '', ByVal cmd As DBCommandWrapper)
            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 13/12/2007

            Dim fecha As Date

            If dtDatosAdm.Rows.Count > 0 Then
                With dtDatosAdm.Rows(0)
                    _servicio = .Item("servicio").ToString
                    _sucursal = .Item("sucursal").ToString
                    _numAdmision = .Item("admision").ToString
                    _cama = .Item("cama").ToString
                    _tipoCama = .Item("tip_cama").ToString
                    _seccion = .Item("seccion").ToString
                    If .Item("fec_ingreso").ToString.Length > 0 Then
                        fecha = .Item("fec_ingreso").ToString
                        _fechaIngreso = Format(fecha, "dd/MMMM/yyyy")
                    Else
                        _fechaIngreso = ""
                    End If
                    _horaIngreso = .Item("hor_ingreso").ToString
                    _idMedicoTratante = .Item("med_trat").ToString
                    _nombreMedicoTratante = .Item("nom_med_tra").ToString
                    _idMedicoHospital = .Item("med_hos").ToString
                    _nombreMedicoHospital = .Item("nom_med_hos").ToString
                    _entidad = .Item("entidad").ToString
                    _autoriza = .Item("autoriza").ToString
                    _loginCreacion = .Item("login_creacion").ToString
                    _clasificacion = .Item("clasificacion").ToString
                    _paciente = objPaciente
                    _ObsAdmision = .Item("ObsAdmision").ToString
                End With
            End If

            For Each sqlParam As SqlClient.SqlParameter In paramsList

                Select Case sqlParam.ParameterName
                    Case "@strAutorizacion"
                        _autorizacion = ifObjectIsDBNullReturnEmpty(sqlParam.Value)
                    Case "@dblNumAnticipo"
                        _numAnticipo = ifObjectIsDBNullReturnEmpty(sqlParam.Value)
                    Case "@dblValAnticipo"
                        _valAnticipo = ifObjectIsDBNullReturnEmpty(sqlParam.Value)
                    Case "@strLogin"
                        _login = ifObjectIsDBNullReturnEmpty(sqlParam.Value)
                End Select
            Next

            If Left(_numAdmision, 1) = "H" Then
                _labelNumAnticipo = "NÚMERO ANTICIPO:"
                _labelValAnticipo = "VALOR ANTICIPO:"
            End If

            _fecha = Format(FuncionesGenerales.FechaServidor(), "dd/MMMM/yyyy HH:mm tt")
            _copia = "COPIA"
        End Sub

        Private Function ifObjectIsDBNullReturnEmpty(ByVal obj As Object) As String
            If (IsDBNull(obj)) Then
                Return ""
            Else
                Return obj
            End If
        End Function
        Private Function crearPaciente(ByVal dtDatosAdm As DataTable, ByVal dtAdmisionesAnt As DataTable) As Paciente
            '' ''ByVal cmdDatosAdm As DBCommandWrapper) As Paciente

            '' ''Return New Paciente(dtDatosAdm, dtAdmisionesAnt, cmdDatosAdm.GetParameterValue("@intCantAdm"), _
            '' ''                    cmdDatosAdm.GetParameterValue("@strTipoDocumento").ToString, _
            '' ''                    cmdDatosAdm.GetParameterValue("@strCarnet").ToString)

            Return New Paciente(dtDatosAdm, dtAdmisionesAnt, gpmDataObj.Parameters("@intCantAdm").Value,
                                gpmDataObj.Parameters("@strTipoDocumento").Value,
                                gpmDataObj.Parameters("@strCarnet").Value)

        End Function

        Public Function consultarEgresos(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String,
                   ByVal strCod_sucur As String, ByVal strTip_admision As String,
                   ByVal iano_adm As Long, ByVal lnum_adm As Double) As List(Of Admision)

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 13/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper
            Dim objAdmision As Admision
            Dim drDatos As IDataReader
            Dim listaEgresos As New List(Of Admision)

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''command = db.GetStoredProcCommandWrapper("pa_Reportes_HCEgresos")

            '' ''With command
            '' ''    .AddInParameter("strcod_pre_sgs", DbType.String, strcod_pre_sgs)
            '' ''    .AddInParameter("strCod_sucur", DbType.String, strCod_sucur)
            '' ''    .AddInParameter("strTip_admision", DbType.String, strTip_admision)
            '' ''    .AddInParameter("iano_adm", DbType.Int16, iano_adm)
            '' ''    .AddInParameter("lnum_adm", DbType.Double, lnum_adm)
            '' ''End With

            '' ''drDatos = db.ExecuteReader(command)
            gpmDataObj.setSQLSentence("pa_Reportes_HCEgresos", CommandType.StoredProcedure)
            gpmDataObj.addInputParameter("strcod_pre_sgs", SqlDbType.VarChar, strcod_pre_sgs)
            gpmDataObj.addInputParameter("strCod_sucur", SqlDbType.VarChar, strCod_sucur)
            gpmDataObj.addInputParameter("strTip_admision", SqlDbType.VarChar, strTip_admision)
            gpmDataObj.addInputParameter("iano_adm", SqlDbType.Int, iano_adm)
            gpmDataObj.addInputParameter("lnum_adm", SqlDbType.Decimal, lnum_adm)

            drDatos = gpmDataObj.ExecRdr()

            While drDatos.Read()
                objAdmision = New Admision(drDatos("cDescripcion").ToString, drDatos("incapacidad").ToString,
                              drDatos("dias_incapa").ToString, drDatos("fec_incapacidad").ToString)
                listaEgresos.Add(objAdmision)
            End While

            If drDatos.IsClosed = False Then
                drDatos.Close()
            End If
            '' ''command.Command.Connection.Close()
            '' ''command.Command.Connection.Dispose()

            Return listaEgresos

        End Function

        Public Function crearListaEgresos(ByVal drdatos As IDataReader) As List(Of Admision)

            Dim objAdmision As Admision
            Dim listaEgresos As New List(Of Admision)

            While drdatos.Read()
                objAdmision = New Admision(drdatos("cDescripcion").ToString, "", drdatos("dias_incapa").ToString)
                If IsDate(drdatos("fec_incapacidad").ToString) Then
                    objAdmision.FechaInicialIncapacidad = Format(CDate(drdatos("fec_incapacidad").ToString), "dd/MM/yyyy")
                Else
                    objAdmision.FechaInicialIncapacidad = ""
                End If

                If IsDate(drdatos("FechaFinal").ToString) Then
                    objAdmision.FechaFinalIncapacidad = Format(CDate(drdatos("FechaFinal").ToString), "dd/MM/yyyy")
                Else
                    objAdmision.FechaFinalIncapacidad = ""
                End If
                listaEgresos.Add(objAdmision)
            End While

            Return listaEgresos

        End Function

        Public Function consultarCentroDeCostoOrigen(ByVal objconexion As Conexion, ByVal strcod_pre_sgs As String, ByVal strCod_sucur As String,
                                                            ByVal strTip_admision As String, ByVal iAno_adm As Integer,
                                                            ByVal lNum_adm As Double, ByVal strEntidad As String) As String

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 13/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper
            Dim strCentroCostoOrigen As String

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objconexion.strServidor, objconexion.strBaseDatos, objconexion.strUsuarioBD, objconexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''command = db.GetStoredProcCommandWrapper("HC_TraerCentroDeCostoOrigen")
            '' ''With command
            '' ''    .AddInParameter("strcod_pre_sgs", DbType.String, strcod_pre_sgs)
            '' ''    .AddInParameter("strCod_sucur", DbType.String, strCod_sucur)
            '' ''    .AddInParameter("strTip_admision", DbType.String, strTip_admision)
            '' ''    .AddInParameter("lNum_adm", DbType.Double, lNum_adm)
            '' ''    .AddInParameter("iAno_adm", DbType.Int16, iAno_adm)
            '' ''    .AddInParameter("strEntidad", DbType.String, strEntidad)
            '' ''    .AddOutParameter("cen_cos_origen", DbType.String, 8)
            '' ''End With

            '' ''db.ExecuteDataSet(command)
            '' ''strCentroCostoOrigen = command.GetParameterValue("@cen_cos_origen").ToString

            gpmDataObj.setSQLSentence("HC_TraerCentroDeCostoOrigen", CommandType.StoredProcedure)

            gpmDataObj.addInputParameter("strcod_pre_sgs", SqlDbType.VarChar, strcod_pre_sgs)
            gpmDataObj.addInputParameter("strCod_sucur", SqlDbType.VarChar, strCod_sucur)
            gpmDataObj.addInputParameter("strTip_admision", SqlDbType.VarChar, strTip_admision)
            gpmDataObj.addInputParameter("lNum_adm", SqlDbType.Decimal, lNum_adm)
            gpmDataObj.addInputParameter("iAno_adm", SqlDbType.Int, iAno_adm)
            gpmDataObj.addInputParameter("strEntidad", SqlDbType.VarChar, strEntidad)
            gpmDataObj.addOutputParameter("cen_cos_origen", SqlDbType.VarChar, 8)

            gpmDataObj.execDS()

            strCentroCostoOrigen = IIf(IsDBNull(gpmDataObj.Parameters("cen_cos_origen").Value), "", gpmDataObj.Parameters("cen_cos_origen").Value)

            Return strCentroCostoOrigen

        End Function

    End Class

End Namespace
