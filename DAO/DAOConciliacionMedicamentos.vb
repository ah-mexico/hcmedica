Imports System.Data.SqlClient
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion

Public Class DAOConciliacionMedicamentos
    Inherits GPMData


    Private command As SqlCommand = New SqlCommand
    Private connectionString As String = String.Empty
    Private objDataConnexion As Conexion = Nothing


    Public Function consultarMedicamentosConciliados(ByVal objConexion As Conexion, ByVal strCod_pre_sgs As String,
                                             ByVal strCod_sucur As String, ByVal strTip_Admision As String,
                                             ByVal strAno_Adm As Integer, ByVal strNum_Adm As Double) As DataSet
        '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
        '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
        '' ''Dim db As Database
        '' ''Dim command As DBCommandWrapper
        '' ''Dim numeroRegistros As Integer
        Dim dsDatos As DataSet

        '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
        '' ''command = db.GetStoredProcCommandWrapper("HC_ConsultarOrdenes")
        '' ''With command
        '' ''    .AddInParameter("cod_pre_sgs", DbType.String, strCod_pre_sgs)
        '' ''    .AddInParameter("cod_sucur", DbType.String, strCod_sucur)
        '' ''    .AddInParameter("tip_admision", DbType.String, strTip_Admision)
        '' ''    .AddInParameter("ano_adm", DbType.Int16, strAno_Adm)
        '' ''    .AddInParameter("num_adm", DbType.Double, strNum_Adm)
        '' ''End With

        '' ''dsDatos = db.ExecuteDataSet(command)

        Me.setSQLSentence("HC_med_concil", CommandType.StoredProcedure)
        Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, strCod_pre_sgs)
        Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strCod_sucur)
        Me.addInputParameter("tip_admision", SqlDbType.VarChar, strTip_Admision)
        Me.addInputParameter("ano_adm", SqlDbType.Int, strAno_Adm)
        Me.addInputParameter("num_adm", SqlDbType.Int, strNum_Adm)

        dsDatos = Me.execDS()

        Return dsDatos
    End Function



    Public Function consultarMedicamentosNoConciliadosSuspend(ByVal objConexion As Conexion, ByVal strCod_pre_sgs As String,
                                             ByVal strCod_sucur As String, ByVal strTip_Admision As String,
                                             ByVal strAno_Adm As Integer, ByVal strNum_Adm As Double) As DataSet
        '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
        '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
        '' ''Dim db As Database
        '' ''Dim command As DBCommandWrapper
        '' ''Dim numeroRegistros As Integer
        Dim dsDatos As DataSet

        '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
        '' ''command = db.GetStoredProcCommandWrapper("HC_ConsultarOrdenes")
        '' ''With command
        '' ''    .AddInParameter("cod_pre_sgs", DbType.String, strCod_pre_sgs)
        '' ''    .AddInParameter("cod_sucur", DbType.String, strCod_sucur)
        '' ''    .AddInParameter("tip_admision", DbType.String, strTip_Admision)
        '' ''    .AddInParameter("ano_adm", DbType.Int16, strAno_Adm)
        '' ''    .AddInParameter("num_adm", DbType.Double, strNum_Adm)
        '' ''End With

        '' ''dsDatos = db.ExecuteDataSet(command)

        Me.setSQLSentence("HC_med_sus_concil", CommandType.StoredProcedure)
        Me.addInputParameter("@cod_pre_sgs", SqlDbType.VarChar, strCod_pre_sgs)
        Me.addInputParameter("@cod_sucur", SqlDbType.VarChar, strCod_sucur)
        Me.addInputParameter("@tip_admision", SqlDbType.VarChar, strTip_Admision)
        Me.addInputParameter("@ano_adm", SqlDbType.Int, strAno_Adm)
        Me.addInputParameter("@num_adm", SqlDbType.Int, strNum_Adm)

        dsDatos = Me.execDS()

        Return dsDatos
    End Function



    Public Function consultarMedicamentosConciliadosOtros(ByVal objConexion As Conexion, ByVal strCod_pre_sgs As String,
                                           ByVal strCod_sucur As String, ByVal strTip_Admision As String,
                                           ByVal strAno_Adm As Integer, ByVal strNum_Adm As Double) As DataSet
        '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
        '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
        '' ''Dim db As Database
        '' ''Dim command As DBCommandWrapper
        '' ''Dim numeroRegistros As Integer
        Dim dsDatos As DataSet

        '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
        '' ''command = db.GetStoredProcCommandWrapper("HC_ConsultarOrdenes")
        '' ''With command
        '' ''    .AddInParameter("cod_pre_sgs", DbType.String, strCod_pre_sgs)
        '' ''    .AddInParameter("cod_sucur", DbType.String, strCod_sucur)
        '' ''    .AddInParameter("tip_admision", DbType.String, strTip_Admision)
        '' ''    .AddInParameter("ano_adm", DbType.Int16, strAno_Adm)
        '' ''    .AddInParameter("num_adm", DbType.Double, strNum_Adm)
        '' ''End With

        '' ''dsDatos = db.ExecuteDataSet(command)

        Me.setSQLSentence("HC_otros_med_concil", CommandType.StoredProcedure)
        Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, strCod_pre_sgs)
        Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strCod_sucur)
        Me.addInputParameter("tip_admision", SqlDbType.VarChar, strTip_Admision)
        Me.addInputParameter("ano_adm", SqlDbType.Int, strAno_Adm)
        Me.addInputParameter("num_adm", SqlDbType.Int, strNum_Adm)

        dsDatos = Me.execDS()

        Return dsDatos
    End Function

    Public Function consultarMotivoSuspensionMedicamentos(ByVal objConexion As Conexion) As DataTable
        '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
        '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
        '' ''Dim db As Database
        '' ''Dim command As DBCommandWrapper

        '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
        '' ''command = db.GetSqlStringCommandWrapper("select via, descripcion from genViaAdministracion")
        Dim dtTable As DataTable
        Me.setSQLSentence("SELECT motivo,descripcion from genmotiv   where cla_motivo = '26' order by motivo desc", CommandType.Text)
        dtTable = Me.execDT()

        Return dtTable
    End Function


    Public Function GrabarAuditOrdenes(ByVal objConexion As Conexion, ByVal strCod_pre_sgs As String,
                                               ByVal strCod_sucur As String, ByVal strTip_Admision As String,
                                               ByVal strAno_Adm As Integer, ByVal strNum_Adm As Double,
                                               ByVal paciente As String, ByVal strmedico As String,
                                               ByVal Iom As Integer, ByVal Iog As Integer, ByVal Iod As Integer,
                                               ByVal Iop As Integer, ByVal Nrorden As Decimal, ByVal strobs As String, ByVal strtipo As String) As Long

        Dim lError As Long



        Me.setSQLSentence("hc_ingresatablaAuditOrdenes", CommandType.StoredProcedure)
        Me.ParametersCollection.Clear()
        Me.addInputParameter("@cod_pre_sgs", SqlDbType.VarChar, strCod_pre_sgs)
        Me.addInputParameter("@cod_sucur", SqlDbType.VarChar, strCod_sucur)
        Me.addInputParameter("@tip_admision", SqlDbType.VarChar, strTip_Admision)
        Me.addInputParameter("@ano_adm", SqlDbType.Int, strAno_Adm)
        Me.addInputParameter("@num_adm", SqlDbType.Int, strNum_Adm)
        Me.addInputParameter("@medico", SqlDbType.VarChar, strmedico)
        Me.addInputParameter("@paciente", SqlDbType.VarChar, paciente)
        Me.addInputParameter("@countom", SqlDbType.Int, Iom)
        Me.addInputParameter("@countog", SqlDbType.Int, Iog)
        Me.addInputParameter("@countod", SqlDbType.Int, Iod)
        Me.addInputParameter("@countop", SqlDbType.Int, Iop)
        Me.addInputParameter("@NroOrden", SqlDbType.Int, Nrorden)
        Me.addInputParameter("@obs", SqlDbType.VarChar, strobs)
        Me.addInputParameter("@tipo", SqlDbType.VarChar, strtipo)
        Me.addInputParameter("@Error", SqlDbType.Int, lError)

        Me.Exec()
        lError = Me.Parameters("Error").Value

        Return lError
    End Function

    Public Function guardarOrdenesAGFA(ByVal objConexion As Conexion, ByVal MSH_STATUS As String, ByVal MSH_DATE As Date,
                                             ByVal PID2_ID As String,
                                             ByVal PID5_LNAME As String, ByVal PID5_FNAME As String,
                                             ByVal PID7_BDATE As DateTime, ByVal PID8_SEX As String, ByVal PID11_ADDRESS As String,
                                             ByVal PV118_PATIENT_TYPE As String, ByVal PV119_ADMIN_NUMB As String, ByVal ORC2_ORDERNUMBER As String,
                                             ByVal ORC2_OPN_ID As String, ByVal ORC4_ORDERGROUP As String,
                                             ByVal ORC7_STARTDATE As DateTime, ByVal ORC7_ENDDATE As DateTime,
                                             ByVal ORC7_PRIORITY As Integer, ByVal ORC10_AUTHORCODE As String,
                                             ByVal ORC12_PHYSICIANCODE As String, ByVal ORC25_ORDERSTATUS As Integer,
                                             ByVal OBR4_EXAMCODE As String, ByRef OBR4_EXAMNAME As String,
                                             ByRef ORC6_ORDERDATE As Date, ByRef OBR13_CLINICALINFO As String, ByRef OBR31_STUDYREASON As String,
                                             ByVal CC_ORIGEN As String, ByVal CC_DESTINO As String, ByVal NroPedido As Decimal, ByVal sucursal As String,
                                             ByVal Prestador As String, ByVal OBX_ENTIDAD As String, ByVal OBX_CODIGO_HIS As String,
                                             ByVal NOMBRE_MEDICO As String,
                                             ByVal ano_adm As String, ByVal num_adm As String, ByVal particularidades As String,
                                             ByVal procedimientos As String, Optional ByVal intConse As Integer = 0) As Long


        Dim lError As Long
        Dim obs As String
        Dim Orden As String

        If NroPedido > 0 Then
            obs = "CON PEDIDO"
        Else
            obs = "SIN PEDIDO"
        End If
        If ORC25_ORDERSTATUS = 0 Then
            Orden = ORC4_ORDERGROUP & "-" & intConse
        Else
            Orden = ORC4_ORDERGROUP
        End If
        Me.setSQLSentence("HC_GrabarOrdenesMedicasAGFA", CommandType.StoredProcedure)
        Me.ClearParameters()
        Me.addInputParameter("MSH_STATUS", SqlDbType.VarChar, MSH_STATUS)
        Me.addInputParameter("MSH_DATE", SqlDbType.DateTime, MSH_DATE)
        Me.addInputParameter("PID2_ID", SqlDbType.VarChar, PID2_ID)
        Me.addInputParameter("PID5_LNAME", SqlDbType.VarChar, PID5_LNAME)
        Me.addInputParameter("PID5_FNAME", SqlDbType.VarChar, PID5_FNAME)
        Me.addInputParameter("PID7_BDATE", SqlDbType.DateTime, PID7_BDATE)
        Me.addInputParameter("PID8_SEX", SqlDbType.VarChar, PID8_SEX)
        Me.addInputParameter("PID11_ADDRESS", SqlDbType.VarChar, PID11_ADDRESS)
        Me.addInputParameter("PV118_PATIENT_TYPE", SqlDbType.VarChar, PV118_PATIENT_TYPE)
        Me.addInputParameter("PV119_ADMIN_NUMB", SqlDbType.VarChar, PV119_ADMIN_NUMB)
        Me.addInputParameter("ORC2_ORDERNUMBER", SqlDbType.VarChar, ORC2_ORDERNUMBER)
        Me.addInputParameter("ORC2_OPN_ID", SqlDbType.VarChar, ORC2_OPN_ID)
        Me.addInputParameter("ORC4_ORDERGROUP", SqlDbType.VarChar, Orden)
        Me.addInputParameter("ORC7_STARTDATE", SqlDbType.DateTime, ORC7_STARTDATE)
        Me.addInputParameter("ORC7_ENDDATE", SqlDbType.DateTime, ORC7_ENDDATE)
        Me.addInputParameter("ORC7_PRIORITY", SqlDbType.TinyInt, ORC7_PRIORITY)
        Me.addInputParameter("ORC10_AUTHORCODE", SqlDbType.VarChar, ORC10_AUTHORCODE)
        Me.addInputParameter("ORC12_PHYSICIANCODE", SqlDbType.VarChar, ORC12_PHYSICIANCODE)
        Me.addInputParameter("ORC25_ORDERSTATUS", SqlDbType.Int, ORC25_ORDERSTATUS)
        Me.addInputParameter("OBR4_EXAMCODE", SqlDbType.VarChar, OBR4_EXAMCODE)
        Me.addInputParameter("OBR4_EXAMNAME", SqlDbType.VarChar, OBR4_EXAMNAME)
        Me.addInputParameter("ORC6_ORDERDATE", SqlDbType.DateTime, ORC6_ORDERDATE)
        Me.addInputParameter("OBR13_CLINICALINFO", SqlDbType.VarChar, OBR13_CLINICALINFO)
        Me.addInputParameter("OBR31_STUDYREASON", SqlDbType.VarChar, OBR31_STUDYREASON)
        Me.addInputParameter("CC_ORIGEN", SqlDbType.VarChar, CC_ORIGEN)
        Me.addInputParameter("CC_DESTINO", SqlDbType.VarChar, CC_DESTINO)
        Me.addInputParameter("NroPedido", SqlDbType.Decimal, NroPedido)
        ' herojas 2014/09/15 se le agrega el parameto entidad para que en la tabla agfa_orm_in quede guardada la entidad
        Me.addInputParameter("OBX_ENTIDAD", SqlDbType.VarChar, OBX_ENTIDAD)
        ' herojas 2014/10/09 se le agregan los parametros codigo sophia, observaciones y el nombre del medico para que sean mostrados en el log agfa
        Me.addInputParameter("OBX_CODIGO_HIS", SqlDbType.VarChar, OBX_CODIGO_HIS)
        Me.addInputParameter("OBX_NOMBRE_MEDICO", SqlDbType.VarChar, NOMBRE_MEDICO)
        Me.addInputParameter("OBX_OBS_SIS", SqlDbType.VarChar, obs)
        Me.addInputParameter("sucursal", SqlDbType.VarChar, sucursal)
        Me.addInputParameter("Prestador", SqlDbType.VarChar, Prestador)
        '=============
        Me.addOutputParameter("lError", SqlDbType.Int)
        ' herojas 2015/02/11 Para consultar la cama se envia la admision       
        Me.addInputParameter("ano_adm", SqlDbType.Int, ano_adm)
        Me.addInputParameter("num_adm", SqlDbType.Decimal, num_adm)
        Me.addInputParameter("rsParticularidades", SqlDbType.VarChar, particularidades) ''CCGUTIEREZ - OSI. 07/09/2020. Se agrega parametro dr("particularidades")
        Me.addInputParameter("rsProcedimientos", SqlDbType.VarChar, procedimientos) ''CCGUTIEREZ - OSI. 28/06/2021. Se agrega parametro dr("procedimientos")
        Me.Exec()
        lError = Me.Parameters("lError").Value

        Return lError
    End Function

    Public Sub ConsultarDatosPedidoOrdenRis(ByVal strcod_pre_sgs As String, ByVal strcod_sucur As String,
      ByVal tip_admision As String, ByVal num_adm As Integer, ByVal ano_adm As Integer, ByVal nroOrden As Decimal, ByVal strprocedim As String,
      ByRef numPedido As Decimal)


        Me.setSQLSentence("HC_ConsultarPedidoRis", CommandType.StoredProcedure)
        Me.ClearParameters()
        Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, strcod_pre_sgs)
        Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strcod_sucur)
        Me.addInputParameter("tip_admision", SqlDbType.VarChar, tip_admision)
        Me.addInputParameter("num_adm", SqlDbType.VarChar, num_adm)
        Me.addInputParameter("ano_adm", SqlDbType.VarChar, ano_adm)
        Me.addInputParameter("num_orden", SqlDbType.Decimal, nroOrden)
        Me.addInputParameter("procedim", SqlDbType.VarChar, strprocedim)
        Me.addOutputParameter("num_pedido", SqlDbType.Decimal, numPedido)
        Me.Exec()

        numPedido = Me.Parameters("num_pedido").Value

    End Sub





    ''' <summary>
    ''' Funcion que guarda los registros modificados y nuevos para todas las ordenes 
    ''' medicas(Dietas, medicamentos, procedimientos, ordenes generales). Para dietas,
    ''' medicamentos y procedimientos los registros modificados (Continuar - Suspender)
    ''' se inactivan y se crea un nuevo registro con una nuevo numero de orden, estado
    ''' activo y valor de tratamiento digitado por el usuario. Se insertan ademas los nuevos
    ''' registros  
    ''' </summary>
    ''' <param name="objConexion">Objeto con los datos de la conexion</param>
    ''' <param name="strCodSucur">Codigo de la sucursal</param>
    ''' <param name="xmlDietasModifica">XML con info de dietas modificadas</param>
    ''' <param name="xmlDietasNuevas">XML con info de nuevas dietas</param>
    ''' <param name="xmlMedicaModificados">XML con info de medicamentos modificados</param>
    ''' <param name="xmlMedicaNuevos">XML con info de Nuevos medicamentos</param>
    ''' <param name="xmlProceNuevos">XML con info de nuevos procedimientos</param>
    ''' <param name="NroOrden">Numero de orden que retorna el store procedure</param>
    ''' <returns>El posible numero de error generado en el store procedure</returns>
    ''' <remarks></remarks>
    Public Function guardarOrdenes(ByVal objConexion As Conexion, ByVal cod_pre_sgs As String,
                                              ByVal strCodSucur As String, ByVal tip_admision As String,
                                              ByVal num_adm As String, ByVal ano_adm As String, ByVal strLogin As String,
                                              ByVal medico As String, ByVal strCodEspecialidad As String, ByVal entidad As String,
                                              ByVal xmlAislamientosModifica As DataTable, ByVal xmlAislamientosNuevos As DataTable,
                                              ByVal xmlDietasModifica As DataTable, ByVal xmlDietasNuevas As DataTable,
                                              ByVal xmlMedicaModificados As DataTable, ByVal xmlMedicaNuevos As DataTable,
                                              ByVal xmlProceNuevos As DataTable, ByVal xmlGeneralesModificados As DataTable,
                                              ByVal xmlGeneralesNuevos As DataTable, ByVal dtDatosPaciente As DataTable,
                                              ByRef NroOrden As Double, ByRef fechaOrden As Date, ByRef centroCostoOrigen As String,
                                              ByRef strGuia As String, ByRef strJustificacion As String,
                                              ByRef strTipoServicio As String, ByRef strPrioridad As String, ByRef InicioSesion As DateTime) As Long

        '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
        '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
        Dim lError As Long

        'Joseph Moreno (IG) Fec:2019/11/24 Particularidades
        'CU03 Hrariza@
        'Inicio
        'Me.setSQLSentence("HC_GrabarOrdenesMedicas_P", CommandType.StoredProcedure)
        Me.setSQLSentence("HC_GrabarMedicamentosConcil", CommandType.StoredProcedure)
        'Fin
        'Me.setSQLSentence("HC_GrabarOrdenesMedicas_P_Ext", CommandType.StoredProcedure)
        'Me.setSQLSentence("HC_GrabarOrdenesMedicas_PruebaCTC", CommandType.StoredProcedure)
        Me.ParametersCollection.Clear()
        Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, cod_pre_sgs)
        Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strCodSucur)
        Me.addInputParameter("tip_admision", SqlDbType.VarChar, tip_admision)
        Me.addInputParameter("num_adm", SqlDbType.Int, num_adm)
        Me.addInputParameter("ano_adm", SqlDbType.Int, ano_adm)
        Me.addInputParameter("strLogin", SqlDbType.VarChar, strLogin)
        Me.addInputParameter("medico", SqlDbType.VarChar, medico)
        Me.addInputParameter("especialidad", SqlDbType.VarChar, strCodEspecialidad)
        Me.addInputParameter("entidad", SqlDbType.VarChar, entidad)
        Me.addInputParameter("txtXmlAislamientosModif", SqlDbType.Structured, xmlAislamientosModifica)
        Me.addInputParameter("txtXmlAislamientosNuevos", SqlDbType.Structured, xmlAislamientosNuevos)
        Me.addInputParameter("txtXmlDietasModif", SqlDbType.Structured, xmlDietasModifica)
        Me.addInputParameter("txtXmlDietasNuevas", SqlDbType.Structured, xmlDietasNuevas)
        Me.addInputParameter("txtXmlMedicaModificados", SqlDbType.Structured, xmlMedicaModificados)
        Me.addInputParameter("txtXmlMedicaNuevos", SqlDbType.Structured, xmlMedicaNuevos)
        Me.addInputParameter("txtXmlProceNuevos", SqlDbType.Structured, xmlProceNuevos)
        Me.addInputParameter("txtXmlGeneralesModificados", SqlDbType.Structured, xmlGeneralesModificados)
        Me.addInputParameter("txtXmlGeneralesNuevos", SqlDbType.Structured, xmlGeneralesNuevos)
        Me.addInputParameter("Tbl_DatosPaciente", SqlDbType.Structured, dtDatosPaciente)
        Me.addOutputParameter("NewNroOrden", SqlDbType.Int)
        Me.addOutputParameter("fechaOrden", SqlDbType.DateTime)
        Me.addOutputParameter("centroDeCostoOrigen", SqlDbType.VarChar, 8)
        'parametros creados por Ing. Ricardo Mauricio Zaldúa C. 2009-02-03 Res 3047 solicitado por Mauricio Forero
        Me.addInputParameter("strGuia", SqlDbType.VarChar, strGuia)
        Me.addInputParameter("strJustificacion", SqlDbType.VarChar, strJustificacion)
        Me.addInputParameter("strTipoServicio", SqlDbType.VarChar, strTipoServicio)
        Me.addInputParameter("strPrioridad", SqlDbType.VarChar, strPrioridad)
        'CU03 Hrariza@
        'Inicio
        Me.addInputParameter("flag", SqlDbType.VarChar, "CONCILIACION")
        'Fin
        Me.Parameters("txtXmlAislamientosModif").TypeName = "dbo.UT_Tbl_Aislamientos"
        Me.Parameters("txtXmlAislamientosNuevos").TypeName = "dbo.UT_Tbl_Aislamientos"
        Me.Parameters("txtXmlDietasModif").TypeName = "dbo.UT_Tbl_Dietas"
        Me.Parameters("txtXmlDietasNuevas").TypeName = "dbo.UT_Tbl_Dietas"
        'CU03 Hrariza@
        'Inicio
        'Me.Parameters("txtXmlMedicaModificados").TypeName = "dbo.UT_Tbl_Medicamentos"
        'Me.Parameters("txtXmlMedicaNuevos").TypeName = "dbo.UT_Tbl_Medicamentos"
        Me.Parameters("txtXmlMedicaModificados").TypeName = "dbo.UT_Tbl_Medicamentos_Concil"
        Me.Parameters("txtXmlMedicaNuevos").TypeName = "dbo.UT_Tbl_Medicamentos_Concil"
        'Fin
        'Joseph Moreno (IG) Fec:2019/11/28 Particularidades
        'Me.Parameters("txtXmlProceNuevos").TypeName = "dbo.UT_Tbl_Procedimientos"
        Me.Parameters("txtXmlProceNuevos").TypeName = "dbo.UT_Tbl_ProcedimientosExt"
        Me.Parameters("txtXmlGeneralesModificados").TypeName = "dbo.UT_Tbl_Generales"
        Me.Parameters("txtXmlGeneralesNuevos").TypeName = "dbo.UT_Tbl_Generales"
        Me.Parameters("Tbl_DatosPaciente").TypeName = "dbo.UT_Tbl_DatosPaciente"
        '=============
        Me.addOutputParameter("lError", SqlDbType.Int)
        Me.addInputParameter("FInicialSeion", SqlDbType.DateTime, InicioSesion)
        Me.Exec()

        lError = Me.Parameters("lError").Value

        If IsNumeric(Me.Parameters("NewNroOrden").Value) Then
            NroOrden = CType(Me.Parameters("NewNroOrden").Value, Double)
        Else
            NroOrden = 0
        End If

        If IsDate(Me.Parameters("fechaOrden").Value) Then
            fechaOrden = CType(Me.Parameters("fechaOrden").Value, Date)
        End If

        If IsDBNull(Me.Parameters("centroDeCostoOrigen").Value) Then
            centroCostoOrigen = ""
        Else
            centroCostoOrigen = CType(Me.Parameters("centroDeCostoOrigen").Value, String)
        End If

        ValidarPedidoGenerado(cod_pre_sgs, strCodSucur, tip_admision, ano_adm, num_adm, NroOrden)

        Return lError

    End Function


    Public Sub ValidarPedidoGenerado(ByVal strCod_pre_sgs As String,
                                                       ByVal strCod_sucur As String, ByVal strTip_Admision As String,
                                                       ByVal strAno_Adm As Integer, ByVal strNum_Adm As Double, ByVal NroOrden As Integer)

        Dim dtDatos As DataTable
        Dim strProcedimiento As String = ""

        Me.setSQLSentence("HC_ValidarPedidoGenerado", CommandType.StoredProcedure)
        Me.ClearParameters()
        Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, strCod_pre_sgs)
        Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strCod_sucur)
        Me.addInputParameter("tip_admision", SqlDbType.VarChar, strTip_Admision)
        Me.addInputParameter("num_adm", SqlDbType.Int, strNum_Adm)
        Me.addInputParameter("ano_adm", SqlDbType.Int, strAno_Adm)
        Me.addInputParameter("NroOrden", SqlDbType.Int, NroOrden)

        dtDatos = Me.execDT

        For i As Integer = 0 To dtDatos.Rows.Count - 1

            strProcedimiento = strProcedimiento + dtDatos.Rows(i).Item("Procedimiento") & " " & dtDatos.Rows(i).Item("nombre_examen") & vbCrLf

        Next

        If strProcedimiento.Length > 0 Then
            '                MsgBox("No se generó pedido por el sistema para los siguientes procedimientos. Se debe generar un pedido manual. " & vbCrLf & strProcedimiento)
            MsgBox("No se generó pedido por el sistema para los siguientes procedimientos. " & vbCrLf & strProcedimiento)
        End If

    End Sub


    ''' <summary>
    ''' eloaiza@intergrupo
    '''30-08-2019
    ''' Metodo clonado de guardar funciones, los parametros de cadena que representan un xml se reemplazan
    ''' por objetos de tipo DataTable (los nombres de los parametros se mantendran) que almacenan la informacion
    ''' de todas las ordenes medicas(Dietas, medicamentos, procedimientos, ordenes generales). Para dietas,
    ''' medicamentos y procedimientos los registros modificados (Continuar - Suspender)
    ''' se inactivan y se crea un nuevo registro con una nuevo numero de orden, estado
    ''' activo y valor de tratamiento digitado por el usuario. Se insertan ademas los nuevos
    ''' registros  
    ''' </summary>
    ''' <param name="objConexion">Objeto con los datos de la conexion</param>
    ''' <param name="strCodSucur">Codigo de la sucursal</param>
    ''' <param name="xmlDietasModifica">Tabla con registros de dietas modificadas</param>
    ''' <param name="xmlDietasNuevas">Tabla con registros de nuevas dietas</param>
    ''' <param name="xmlMedicaModificados">Tabla con registros de medicamentos modificados</param>
    ''' <param name="xmlMedicaNuevos">Tabla con registros de Nuevos medicamentos</param>
    ''' <param name="xmlProceNuevos">Tabla con registros de nuevos procedimientos</param>
    ''' <param name="NroOrden">Numero de orden que retorna el store procedure</param>
    ''' <returns>El posible numero de error generado en el store procedure</returns>
    ''' <remarks></remarks>
    'Public Function guardarOrdenes(ByVal objConexion As Conexion, ByVal cod_pre_sgs As String,
    '                                      ByVal strCodSucur As String, ByVal tip_admision As String,
    '                                      ByVal num_adm As String, ByVal ano_adm As String, ByVal strLogin As String,
    '                                      ByVal medico As String, ByVal strCodEspecialidad As String, ByVal entidad As String,
    '                                      ByVal xmlAislamientosModifica As DataTable, ByVal xmlAislamientosNuevos As DataTable,
    '                                      ByVal xmlDietasModifica As DataTable, ByVal xmlDietasNuevas As DataTable,
    '                                      ByVal xmlMedicaModificados As DataTable, ByVal xmlMedicaNuevos As DataTable,
    '                                      ByVal xmlProceNuevos As DataTable, ByVal xmlGeneralesModificados As DataTable,
    '                                      ByVal xmlGeneralesNuevos As DataTable, ByVal dtDatosPaciente As DataTable,
    '                                      ByRef NroOrden As Double, ByRef fechaOrden As Date, ByRef centroCostoOrigen As String,
    '                                      ByRef strGuia As String, ByRef strJustificacion As String,
    '                                      ByRef strTipoServicio As String, ByRef strPrioridad As String, ByRef InicioSesion As DateTime) As Long

    '    '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
    '    '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
    '    Dim lError As Long

    '    'Joseph Moreno (IG) Fec:2019/11/24 Particularidades
    '    'CU03 Hrariza@
    '    'Inicio
    '    'Me.setSQLSentence("HC_GrabarOrdenesMedicas_P", CommandType.StoredProcedure)
    '    Me.setSQLSentence("HC_GrabarOrdenesMedicas_CQ", CommandType.StoredProcedure)
    '    'Fin
    '    'Me.setSQLSentence("HC_GrabarOrdenesMedicas_P_Ext", CommandType.StoredProcedure)
    '    'Me.setSQLSentence("HC_GrabarOrdenesMedicas_PruebaCTC", CommandType.StoredProcedure)
    '    Me.ParametersCollection.Clear()
    '    Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, cod_pre_sgs)
    '    Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strCodSucur)
    '    Me.addInputParameter("tip_admision", SqlDbType.VarChar, tip_admision)
    '    Me.addInputParameter("num_adm", SqlDbType.Int, num_adm)
    '    Me.addInputParameter("ano_adm", SqlDbType.Int, ano_adm)
    '    Me.addInputParameter("strLogin", SqlDbType.VarChar, strLogin)
    '    Me.addInputParameter("medico", SqlDbType.VarChar, medico)
    '    Me.addInputParameter("especialidad", SqlDbType.VarChar, strCodEspecialidad)
    '    Me.addInputParameter("entidad", SqlDbType.VarChar, entidad)
    '    Me.addInputParameter("txtXmlAislamientosModif", SqlDbType.Structured, xmlAislamientosModifica)
    '    Me.addInputParameter("txtXmlAislamientosNuevos", SqlDbType.Structured, xmlAislamientosNuevos)
    '    Me.addInputParameter("txtXmlDietasModif", SqlDbType.Structured, xmlDietasModifica)
    '    Me.addInputParameter("txtXmlDietasNuevas", SqlDbType.Structured, xmlDietasNuevas)
    '    Me.addInputParameter("txtXmlMedicaModificados", SqlDbType.Structured, xmlMedicaModificados)
    '    Me.addInputParameter("txtXmlMedicaNuevos", SqlDbType.Structured, xmlMedicaNuevos)
    '    Me.addInputParameter("txtXmlProceNuevos", SqlDbType.Structured, xmlProceNuevos)
    '    Me.addInputParameter("txtXmlGeneralesModificados", SqlDbType.Structured, xmlGeneralesModificados)
    '    Me.addInputParameter("txtXmlGeneralesNuevos", SqlDbType.Structured, xmlGeneralesNuevos)
    '    Me.addInputParameter("Tbl_DatosPaciente", SqlDbType.Structured, dtDatosPaciente)
    '    Me.addOutputParameter("NewNroOrden", SqlDbType.Int)
    '    Me.addOutputParameter("fechaOrden", SqlDbType.DateTime)
    '    Me.addOutputParameter("centroDeCostoOrigen", SqlDbType.VarChar, 8)
    '    'parametros creados por Ing. Ricardo Mauricio Zaldúa C. 2009-02-03 Res 3047 solicitado por Mauricio Forero
    '    Me.addInputParameter("strGuia", SqlDbType.VarChar, strGuia)
    '    Me.addInputParameter("strJustificacion", SqlDbType.VarChar, strJustificacion)
    '    Me.addInputParameter("strTipoServicio", SqlDbType.VarChar, strTipoServicio)
    '    Me.addInputParameter("strPrioridad", SqlDbType.VarChar, strPrioridad)
    '    'CU03 Hrariza@
    '    'Inicio
    '    Me.addInputParameter("flag", SqlDbType.VarChar, "CONCILIACION")
    '    'Fin
    '    Me.Parameters("txtXmlAislamientosModif").TypeName = "dbo.UT_Tbl_Aislamientos"
    '    Me.Parameters("txtXmlAislamientosNuevos").TypeName = "dbo.UT_Tbl_Aislamientos"
    '    Me.Parameters("txtXmlDietasModif").TypeName = "dbo.UT_Tbl_Dietas"
    '    Me.Parameters("txtXmlDietasNuevas").TypeName = "dbo.UT_Tbl_Dietas"
    '    'CU03 Hrariza@
    '    'Inicio
    '    'Me.Parameters("txtXmlMedicaModificados").TypeName = "dbo.UT_Tbl_Medicamentos"
    '    'Me.Parameters("txtXmlMedicaNuevos").TypeName = "dbo.UT_Tbl_Medicamentos"
    '    Me.Parameters("txtXmlMedicaModificados").TypeName = "dbo.UT_Tbl_Medicamentos_CQ"
    '    Me.Parameters("txtXmlMedicaNuevos").TypeName = "dbo.UT_Tbl_Medicamentos_CQ"
    '    'Fin
    '    'Joseph Moreno (IG) Fec:2019/11/28 Particularidades
    '    'Me.Parameters("txtXmlProceNuevos").TypeName = "dbo.UT_Tbl_Procedimientos"
    '    Me.Parameters("txtXmlProceNuevos").TypeName = "dbo.UT_Tbl_ProcedimientosExt"
    '    Me.Parameters("txtXmlGeneralesModificados").TypeName = "dbo.UT_Tbl_Generales"
    '    Me.Parameters("txtXmlGeneralesNuevos").TypeName = "dbo.UT_Tbl_Generales"
    '    Me.Parameters("Tbl_DatosPaciente").TypeName = "dbo.UT_Tbl_DatosPaciente"
    '    '=============
    '    Me.addOutputParameter("lError", SqlDbType.Int)
    '    Me.addInputParameter("FInicialSeion", SqlDbType.DateTime, InicioSesion)
    '    Me.Exec()

    '    lError = Me.Parameters("lError").Value

    '    If IsNumeric(Me.Parameters("NewNroOrden").Value) Then
    '        NroOrden = CType(Me.Parameters("NewNroOrden").Value, Double)
    '    Else
    '        NroOrden = 0
    '    End If

    '    If IsDate(Me.Parameters("fechaOrden").Value) Then
    '        fechaOrden = CType(Me.Parameters("fechaOrden").Value, Date)
    '    End If

    '    If IsDBNull(Me.Parameters("centroDeCostoOrigen").Value) Then
    '        centroCostoOrigen = ""
    '    Else
    '        centroCostoOrigen = CType(Me.Parameters("centroDeCostoOrigen").Value, String)
    '    End If

    '    ValidarPedidoGenerado(cod_pre_sgs, strCodSucur, tip_admision, ano_adm, num_adm, NroOrden)

    'Return lError

    'End Function

    Public Function guardarOrdenesLabo(ByVal objConexion As Conexion, ByVal cod_pre_sgs As String,
                                            ByVal strCodSucur As String, ByVal tip_admision As String,
                                            ByVal num_adm As String, ByVal ano_adm As String, ByVal strLogin As String,
                                            ByVal medico As String, ByVal strCodEspecialidad As String, ByVal entidad As String,
                                            ByVal xmlAislamientosModifica As String, ByVal xmlAislamientosNuevos As String,
                                            ByVal xmlDietasModifica As String, ByVal xmlDietasNuevas As String,
                                            ByVal xmlMedicaModificados As String, ByVal xmlMedicaNuevos As String,
                                            ByVal xmlProceNuevos As String, ByVal xmlGeneralesModificados As String,
                                            ByVal xmlGeneralesNuevos As String, ByRef NroOrden As Double,
                                            ByRef fechaOrden As Date, ByRef centroCostoOrigen As String,
                                            ByRef strGuia As String, ByRef strJustificacion As String,
                                            ByRef strTipoServicio As String, ByRef strPrioridad As String) As Long

        '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
        '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
        '' ''Dim db As Database
        '' ''Dim command As DBCommandWrapper
        '' ''Dim numeroRegistros As Integer
        Dim lError As Long

        'lError = generales.EjecutarSPConParametrosTran("HC_GrabarOrdenesMedicas", objConexion, strCodSucur, xmlDietasModifica, xmlDietasNuevas, NroOrden, lError)

        '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
        '' ''command = db.GetStoredProcCommandWrapper("HC_GrabarOrdenesMedicas")
        '' ''With command
        '' ''    .AddInParameter("cod_pre_sgs", DbType.String, cod_pre_sgs)
        '' ''    .AddInParameter("cod_sucur", DbType.String, strCodSucur)
        '' ''    .AddInParameter("tip_admision", DbType.String, tip_admision)
        '' ''    .AddInParameter("num_adm", DbType.Double, num_adm)
        '' ''    .AddInParameter("ano_adm", DbType.Int16, ano_adm)
        '' ''    .AddInParameter("strLogin", DbType.String, strLogin)
        '' ''    .AddInParameter("medico", DbType.String, medico)
        '' ''    .AddInParameter("especialidad", DbType.String, strCodEspecialidad)
        '' ''    .AddInParameter("entidad", DbType.String, entidad)
        '' ''    .AddInParameter("txtXmlDietasModif", DbType.String, xmlDietasModifica)
        '' ''    .AddInParameter("txtXmlDietasNuevas", DbType.String, xmlDietasNuevas)
        '' ''    .AddInParameter("txtXmlMedicaModificados", DbType.String, xmlMedicaModificados)
        '' ''    .AddInParameter("txtXmlMedicaNuevos", DbType.String, xmlMedicaNuevos)
        '' ''    .AddInParameter("txtXmlProceNuevos", DbType.String, xmlProceNuevos)
        '' ''    .AddInParameter("txtXmlGeneralesModificados", DbType.String, xmlGeneralesModificados)
        '' ''    .AddInParameter("txtXmlGeneralesNuevos", DbType.String, xmlGeneralesNuevos)
        '' ''    .AddOutParameter("NewNroOrden", DbType.Double, 9)
        '' ''    .AddOutParameter("fechaOrden", DbType.DateTime, 8)
        '' ''    .AddOutParameter("centroDeCostoOrigen", DbType.String, 8)
        '' ''    .AddOutParameter("lError", DbType.Int16, 4)
        '' ''End With

        '' ''db.ExecuteNonQuery(command)
        '' ''lError = CType(command.GetParameterValue("@lError"), Long)

        '' ''If IsNumeric(command.GetParameterValue("@NewNroOrden").ToString) Then
        '' ''    NroOrden = CType(command.GetParameterValue("@NewNroOrden").ToString, Double)
        '' ''Else
        '' ''    NroOrden = 0
        '' ''End If

        '' ''If IsDate(command.GetParameterValue("@fechaOrden").ToString) Then
        '' ''    fechaOrden = CType(command.GetParameterValue("@fechaOrden").ToString, Date)
        '' ''End If

        '' ''centroCostoOrigen = command.GetParameterValue("@centroDeCostoOrigen").ToString

        Me.setSQLSentence("HC_GrabarOrdenesMedicasLabo", CommandType.StoredProcedure)
        'Me.setSQLSentence("HC_GrabarOrdenesMedicas_PruebaCTC", CommandType.StoredProcedure)
        Me.ParametersCollection.Clear()
        Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, cod_pre_sgs)
        Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strCodSucur)
        Me.addInputParameter("tip_admision", SqlDbType.VarChar, tip_admision)
        Me.addInputParameter("num_adm", SqlDbType.Int, num_adm)
        Me.addInputParameter("ano_adm", SqlDbType.Int, ano_adm)
        Me.addInputParameter("strLogin", SqlDbType.VarChar, strLogin)
        Me.addInputParameter("medico", SqlDbType.VarChar, medico)
        Me.addInputParameter("especialidad", SqlDbType.VarChar, strCodEspecialidad)
        Me.addInputParameter("entidad", SqlDbType.VarChar, entidad)
        Me.addInputParameter("@txtXmlAislamientosModif", SqlDbType.VarChar, xmlAislamientosModifica)
        Me.addInputParameter("@txtXmlAislamientosNuevos", SqlDbType.VarChar, xmlAislamientosNuevos)
        Me.addInputParameter("txtXmlDietasModif", SqlDbType.VarChar, xmlDietasModifica)
        Me.addInputParameter("txtXmlDietasNuevas", SqlDbType.VarChar, xmlDietasNuevas)
        Me.addInputParameter("txtXmlMedicaModificados", SqlDbType.VarChar, xmlMedicaModificados)
        Me.addInputParameter("txtXmlMedicaNuevos", SqlDbType.VarChar, xmlMedicaNuevos)
        Me.addInputParameter("txtXmlProceNuevos", SqlDbType.VarChar, xmlProceNuevos)
        Me.addInputParameter("txtXmlGeneralesModificados", SqlDbType.VarChar, xmlGeneralesModificados)
        Me.addInputParameter("txtXmlGeneralesNuevos", SqlDbType.VarChar, xmlGeneralesNuevos)
        Me.addOutputParameter("NewNroOrden", SqlDbType.Int)
        Me.addOutputParameter("fechaOrden", SqlDbType.DateTime)
        Me.addOutputParameter("centroDeCostoOrigen", SqlDbType.VarChar, 8)
        'parametros creados por Ing. Ricardo Mauricio Zaldúa C. 2009-02-03 Res 3047 solicitado por Mauricio Forero
        Me.addInputParameter("strGuia", SqlDbType.VarChar, strGuia)
        Me.addInputParameter("strJustificacion", SqlDbType.VarChar, strJustificacion)
        Me.addInputParameter("strTipoServicio", SqlDbType.VarChar, strTipoServicio)
        Me.addInputParameter("strPrioridad", SqlDbType.VarChar, strPrioridad)
        '=============
        Me.addOutputParameter("lError", SqlDbType.Int)
        Me.Exec()
        lError = Me.Parameters("lError").Value

        If IsNumeric(Me.Parameters("NewNroOrden").Value) Then
            NroOrden = CType(Me.Parameters("NewNroOrden").Value, Double)
        Else
            NroOrden = 0
        End If

        If IsDate(Me.Parameters("@fechaOrden").Value) Then
            fechaOrden = CType(Me.Parameters("@fechaOrden").Value, Date)
        End If

        If IsDBNull(Me.Parameters("@centroDeCostoOrigen").Value) Then
            centroCostoOrigen = ""
        Else
            centroCostoOrigen = Me.Parameters("@centroDeCostoOrigen").Value
        End If



        ValidarPedidoGenerado(cod_pre_sgs, strCodSucur, tip_admision, ano_adm, num_adm, NroOrden)

        Return lError

    End Function

    Public Sub ConsultarDatosGrabacionPedidosRis(ByVal strcod_pre_sgs As String, ByVal strcod_sucur As String,
   ByVal tip_admision As String, ByVal num_adm As Integer, ByVal ano_adm As Integer, ByVal strprocedim As String,
   ByRef generaPedido As String, ByRef procedimHomologo As String, ByRef entidadvalida As String, ByVal strCcosto As String)


        Me.setSQLSentence("HC_ValidarProcedimientosRis", CommandType.StoredProcedure)
        Me.ClearParameters()
        Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, strcod_pre_sgs)
        Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strcod_sucur)
        Me.addInputParameter("tip_admision", SqlDbType.VarChar, tip_admision)
        Me.addInputParameter("num_adm", SqlDbType.VarChar, num_adm)
        Me.addInputParameter("ano_adm", SqlDbType.VarChar, ano_adm)
        Me.addInputParameter("procedim", SqlDbType.VarChar, strprocedim)
        Me.addOutputParameter("generaPedido", SqlDbType.VarChar, 1)
        Me.addOutputParameter("procedimHomologo", SqlDbType.VarChar, 9)
        Me.addInputParameter("entidad", SqlDbType.VarChar, entidadvalida)
        Me.addInputParameter("ccosto", SqlDbType.VarChar, strCcosto)
        Me.Exec()

        generaPedido = Me.Parameters("generaPedido").Value
        procedimHomologo = IIf(IsDBNull(Me.Parameters("procedimHomologo").Value), "", Me.Parameters("procedimHomologo").Value)

    End Sub


End Class
