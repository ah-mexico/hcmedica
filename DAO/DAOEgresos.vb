Imports objComun = HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente

Imports objDatosGenerales = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion

Namespace Sophia.HistoriaClinica.DAO
#Region "DAOEgresos"
    ''' -----------------------------------------------------------------------------
    ''' Project	 : HistoriClinica.DAO.DAOEgresos
    ''' Class	 : Sophia.HistoriaClinica.Egresos.DAO.DAOEgresos
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Clase DAOEgresos del namespace Sophia.HistoriaClinica.Egresos.DAO que es la clase 
    ''' data de HistoriaClinica.DAO
    ''' y será usada desde este namespace para el acceso a los datos
    ''' se agrega de la application block Data.SqlHelper
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[mvargas]	28/03/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class DAOEgresos
        Inherits GPMData

        Private objGeneral As objDatosGenerales.Generales


#Region "Métodos DAOEgresos"
        Private strCadena As String

        Public Sub New()
            'objGeneral = Principal.objPrincipalGeneral
            'objPaciente = Principal.objPrincipalPaciente
        End Sub

#Region "ConsultarTiposDiagnostico"
        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Consultar los tipos de diagnosticos (procedimiento DB_TraerInfoTipoDiagnosticosTodos)
        ''' </summary>
        ''' <returns>DataTable con los registros de los tipos de diagnosticos</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mvargas]	31/03/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ConsultarTiposDiagnostico() As DataTable
            'Consumir del Data App Block
            Dim strCadena As String = objGeneral.Cadena
            Dim dtReader As IDataReader
            Dim dtTable As New DataTable

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
            '' ''dtReader = sqldb.ExecuteReader(strCadena, CommandType.StoredProcedure, "HC_TraerInfoTipoDiagnosticosTodos")
            Me.setSQLSentence("HC_TraerInfoTipoDiagnosticosTodos", CommandType.StoredProcedure)
            dtReader = Me.ExecRdr()
            dtTable.Load(dtReader)
            dtReader.Close()
            dtReader.Dispose()
            Return dtTable

        End Function
#End Region

#Region "ConsultarCategorias"
        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Consultar las categorías (se crea un datatable con las categoría)
        ''' </summary>
        ''' <returns>DataTable con los registros de las categorías</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mvargas]	31/03/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ConsultarCategorias() As DataTable
            Dim dtTable As New DataTable
            dtTable.Columns.Add("Categoria_diag", System.Type.GetType("System.String"))
            dtTable.Columns.Add("Descripcion", System.Type.GetType("System.String"))
            Dim dtRow As DataRow = dtTable.NewRow()
            dtRow("Categoria_diag") = "A"
            dtRow("Descripcion") = "RELACIONADO"
            dtTable.Rows.Add(dtRow)
            Dim dtRow1 As DataRow = dtTable.NewRow()
            dtRow1("Categoria_diag") = "P"
            dtRow1("Descripcion") = "PRINCIPAL"
            dtTable.Rows.Add(dtRow1)
            Dim dtRow2 As DataRow = dtTable.NewRow()
            dtRow2("Categoria_diag") = "C"
            dtRow2("Descripcion") = "COMPLICACION"
            dtTable.Rows.Add(dtRow2)
            Return dtTable
        End Function
#End Region

#Region "ConsultarCausasExternas"
        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Consultar las causas externas (procedimiento DB_TraerInfoCausaExternaTodos)
        ''' </summary>
        ''' <returns>DataTable con los registros de las causas externas</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mvargas]	31/03/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ConsultarCausasExternas() As DataTable
            'Consumir del Data App Block
            Dim dtReader As IDataReader
            Dim dtTable As New DataTable
            Dim strCadena As String = objGeneral.Cadena

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
            '' ''dtReader = sqldb.ExecuteReader(strCadena, CommandType.StoredProcedure, "HC_TraerInfoCausaExternaTodos")
            Me.setSQLSentence("HC_TraerInfoCausaExternaTodos", CommandType.StoredProcedure)
            dtReader = Me.ExecRdr()
            dtTable.Load(dtReader)
            dtReader.Close()
            dtReader.Dispose()
            Return dtTable

        End Function
#End Region

#Region "ConsultarCondicionUsuario"
        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Consultar las condiciones de un usuario (procedimiento DB_TraerInfoCondicionUsuariaTodos)
        ''' </summary>
        ''' <returns>DataTable con los registros de las condiciones de usuario</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mvargas]	31/03/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ConsultarCondicionUsuario() As DataTable
            'Consumir del Data App Block
            Dim dtReader As IDataReader
            Dim dtTable As New DataTable
            Dim strCadena As String = objGeneral.Cadena

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
            '' ''dtReader = sqldb.ExecuteReader(strCadena, CommandType.StoredProcedure, "HC_TraerInfoCondicionUsuariaTodos")
            Me.setSQLSentence("HC_TraerInfoCondicionUsuariaTodos", CommandType.StoredProcedure)
            dtReader = Me.ExecRdr()
            dtTable.Load(dtReader)
            dtReader.Close()
            dtReader.Dispose()
            Return dtTable

        End Function
#End Region

#Region "ConsultarTiposDiscapacidad"
        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Consultar los tipos de discapacidad (procedimiento DB_TraerInfoTiposDiscapacidadTodos)
        ''' </summary>
        ''' <returns>DataTable con los registros de los tipos de discapacidad</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mvargas]	03/04/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ConsultarTiposDiscapacidad() As DataTable
            'Consumir del Data App Block
            Dim dtReader As IDataReader
            Dim dtTable As New DataTable
            Dim strCadena As String = objGeneral.Cadena

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
            '' ''dtReader = sqldb.ExecuteReader(strCadena, CommandType.StoredProcedure, "HC_TraerInfoTiposDiscapacidadTodos")
            Me.setSQLSentence("HC_TraerInfoTiposDiscapacidadTodos", CommandType.StoredProcedure)
            dtReader = Me.ExecRdr()
            dtTable.Load(dtReader)
            dtReader.Close()
            dtReader.Dispose()
            Return dtTable

        End Function
#End Region

#Region "ConsultarGradosDiscapacidad"
        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Consultar los tipos de discapacidad (procedimiento DB_TraerInfoTiposDiscapacidadTodos)
        ''' </summary>
        ''' <returns>DataTable con los registros de los grados de discapacidad</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mvargas]	03/04/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ConsultarGradosDiscapacidad() As DataTable
            'Consumir del Data App Block
            Dim dtReader As IDataReader
            Dim dtTable As New DataTable
            Dim strCadena As String = objGeneral.Cadena

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
            '' ''dtReader = sqldb.ExecuteReader(strCadena, CommandType.StoredProcedure, "HC_TraerInfoGradoDiscapacidadTodos")
            Me.setSQLSentence("HC_TraerInfoGradoDiscapacidadTodos", CommandType.StoredProcedure)
            dtReader = Me.ExecRdr()
            dtTable.Load(dtReader)

            dtReader.Close()
            dtReader.Dispose()
            Return dtTable
        End Function
#End Region

#Region "ConsultarDestinoFinal"
        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Consultar los tipos de discapacidad (procedimiento DB_TraerInfoEstadoFinalTodos)
        ''' </summary>
        ''' <returns>DataTable con los registros para el destino final</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mvargas]	03/04/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ConsultarDestinoFinal() As DataTable
            'Consumir del Data App Block
            Dim dtReader As IDataReader
            Dim dtTable As New DataTable
            Dim strCadena As String = objGeneral.Cadena

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
            '' ''dtReader = sqldb.ExecuteReader(strCadena, CommandType.StoredProcedure, "HC_TraerInfoEstadoFinalTodos")
            Me.setSQLSentence("HC_TraerInfoEstadoFinalTodos", CommandType.StoredProcedure)
            dtReader = Me.ExecRdr()
            dtTable.Load(dtReader)

            dtReader.Close()
            dtReader.Dispose()
            Return dtTable

        End Function
#End Region

#Region "EjecutarSpConParametros-Retorna Datatable"
        '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
        '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007

        '' '' se comentarea el codigo ya que este metodo no esta siendo llamado por ninguna instancia en la aplicacion

        '''''''-----------------------------------------------------------------------------
        ''''''' <summary>
        ''''''' Función Para ejecutar un procedmiento almacenado con parámetros de entrada y sin transaccionalidad
        ''''''' </summary>
        ''''''' <param name="strProcedimiento">Parámetro tipo string que indica el nombre del
        ''''''' Procedimiento almacenado</param>
        ''''''' <param name="paramsArray">Parámetro tipo object que indica los parámetros del procedimiento</param>
        ''''''' <returns>DataTable con los registros de los egresos seleccionador</returns>
        ''''''' <remarks>
        ''''''' </remarks>
        ''''''' <history>
        ''''''' 	[ggarzon-mvargas]	19/04/2006	Created
        ''''''' </history>
        ''''''' -----------------------------------------------------------------------------
        '' ''Public Function EjecutarSPConParametros(ByVal strProcedimiento As String, ByVal objConexion As objCon, ByVal ParamArray paramsArray()() As Object) As DataTable
        '' ''    '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
        '' ''    '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
        '' ''    '' ''Dim db As Database
        '' ''    '' ''Dim dtSet As New DataSet
        '' ''    Dim dtTable As New DataTable

        '' ''    '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)

        '' ''    '' ''Dim SelectCommand As DBCommandWrapper = db.GetStoredProcCommandWrapper(strProcedimiento, a)
        '' ''    '' ''dtSet = db.ExecuteDataSet(SelectCommand)
        '' ''    '' ''dtTable = ds.Tables(0)
        '' ''    '' ''SelectCommand.Command.Connection.Close()
        '' ''    '' ''SelectCommand.Dispose()
        '' ''    '' ''dtSet.Dispose()

        '' ''    Me.AddSQL(strProcedimiento)
        '' ''    If (paramsArray.Length > 0) Then
        '' ''        For i As Integer = 0 To paramsArray.Length
        '' ''            Me.AddParam(paramsArray(i)(0), paramsArray(i)(1))
        '' ''        Next
        '' ''    End If

        '' ''    dtTable.Load(Me.ExecRdr())

        '' ''    Return dtTable

        '' ''End Function

#End Region

#Region "EjecutarSpSinParametros-Retorna Datatable"
        '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
        '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007

        '' '' se comentarea el codigo ya que este metodo no esta siendo llamado por ninguna instancia en la aplicacion

        '''''''-----------------------------------------------------------------------------
        ''''''' <summary>
        ''''''' Función general, basada en la extensión del Enterprice.Library.Data
        ''''''' Para ejecutar un procedmiento almacenado sin parámetros de entrada y sin transaccionalidad
        ''''''' </summary>
        ''''''' <param name="strProcedimiento">Parámetro tipo string que indica el nombre del
        ''''''' Procedimiento almacenado</param>
        ''''''' <returns>DataTable con los registros de los egresos seleccionador</returns>
        ''''''' <remarks>
        ''''''' </remarks>
        ''''''' <history>
        ''''''' 	[ggarzon-mvargas]	19/04/2006	Created
        ''''''' </history>
        ''''''' -----------------------------------------------------------------------------
        '' ''Public Function EjecutarSPSinParametros(ByVal strProcedimiento As String, ByVal objConexion As objCon) As DataTable
        '' ''    '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
        '' ''    '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
        '' ''    '' ''Dim db As Database
        '' ''    '' ''Dim ds As New DataSet
        '' ''    Dim dtTable As New DataTable

        '' ''    '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)

        '' ''    '' ''Dim SelectCommand As DBCommandWrapper = db.GetStoredProcCommandWrapper(strProcedimiento)
        '' ''    '' ''ds = db.ExecuteDataSet(SelectCommand)
        '' ''    '' ''dt = ds.Tables(0)
        '' ''    '' ''SelectCommand.Command.Connection.Close()
        '' ''    '' ''SelectCommand.Dispose()
        '' ''    '' ''ds.Dispose()

        '' ''    Me.AddSQL(strProcedimiento)
        '' ''    dtTable.Load(Me.ExecRdr())

        '' ''    Return dtTable

        '' ''End Function
#End Region

#Region "EjecutarSpConParametroTran-Retorna Long"
        '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
        '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007

        '' '' se comentarea el codigo ya que este metodo no esta siendo llamado por ninguna instancia en la aplicacion

        '''''''-----------------------------------------------------------------------------
        ''''''' <summary>
        ''''''' Función general, basada en la extensión del Enterprice.Library.Data
        ''''''' Para ejecutar un procedmiento almacenado con parámetros de entrada con transaccionalidad 
        ''''''' y retornar un Long
        ''''''' </summary>
        ''''''' <param name="strProcedimiento">Parámetro tipo string que indica el nombre del
        ''''''' Procedimiento almacenado</param>
        ''''''' <param name="paramsArray">Parámetro tipo object que indica los parámetros del procedimiento</param>
        ''''''' <returns>Long con el número de error o 0 sin errores</returns>
        ''''''' <remarks>
        ''''''' </remarks>
        ''''''' <history>
        ''''''' 	[ggarzon-mvargas]	22/04/2006	Created
        ''''''' </history>
        ''''''' -----------------------------------------------------------------------------
        '' ''Public Function EjecutarSPConParametrosTran(ByVal strProcedimiento As String, ByVal objConexion As objCon, ByVal ParamArray paramsArray() As Object) As Long
        '' ''    '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
        '' ''    '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
        '' ''    '' ''Dim db As Database

        '' ''    '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)

        '' ''    '' ''Dim SelectCommand As DBCommandWrapper = db.GetStoredProcCommandWrapper(strProcedimiento, a)
        '' ''    '' ''SelectCommand.AddIOParameter("@lsalida", DbType.Int32, 2)
        '' ''    '' ''db.ExecuteNonQuery(SelectCommand)
        '' ''    '' ''EjecutarSPConParametrosTran = CType(SelectCommand.GetParameterValue("lsalida"), Long)
        '' ''    'ds = db.ExecuteDataSet(SelectCommand)
        '' ''    'dt = ds.Tables(0)
        '' ''    SelectCommand.Command.Connection.Close()
        '' ''    SelectCommand.Dispose()

        '' ''End Function
#End Region

#Region "GrabarEgreso"
        '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
        '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007

        '' '' se comentarea el codigo ya que este metodo no esta siendo llamado por ninguna instancia en la aplicacion

        ''''''' <summary>
        ''''''' Funcion que ejecuta el stored procedure HC_GrabarEgreso que 
        ''''''' graba un egreso en la historia clínica
        ''''''' </summary>
        ''''''' <param name="objConexion">Datos de la conexion</param>
        ''''''' <param name="intAccion">Parámetro de tipo entero que indica la acción a ejecutar</param>
        ''''''' <param name="intAnoAdmi">Parámetro de tipo entero que indica el año de admisión</param>
        ''''''' <param name="lNumAdmi">Parámetro de tipo long que indica el número de admisión</param>
        ''''''' <param name="strCausaMuerte">Parámetro de tipo string que indica la causa de muerte</param>
        ''''''' <param name="strCodPrestador">Parámetro de tipo stringe que indica el código del prestador</param>
        ''''''' <param name="strEstadoSalida">Parámetro de tipo string que indica el estado a la salida</param>
        ''''''' <param name="strLogin">Parámetro de tipo string que indica el login</param>
        ''''''' <param name="strNumDoc">Parámetro de tipo string que indica número de documento</param>
        ''''''' <param name="strResumenEvolucion">Parámetro de tipo string que indica el resumen de la evolución</param>
        ''''''' <param name="strSucursal">Parámetro de tipo string que indica el código de la sucursal</param>
        ''''''' <param name="strTipoAdmi">Parámetro de tipo string que indica el tipo de admisión</param>
        ''''''' <param name="strTipoDocumento">Parámetro de tipo string que indica el tipo de documento</param>
        ''''''' <param name="trDestinoFinal">Parámetro de tipo string que indica el destino final</param>
        ''''''' <param name="xmlDiagnostico">Parámetro de tipo string con el xml de los datos del diagnóstico</param>
        ''''''' <returns>Long con el número de error</returns>
        ''''''' <history>
        ''''''' 	[mvargas]	22/04/2006	Created
        ''''''' </history>
        ''''''' -----------------------------------------------------------------------------

        '' ''Public Function GrabarEgreso(ByVal objConexion As objCon, ByVal intAccion As Integer, ByVal strEstadoSalida As String, ByVal strCausaMuerte As String, _
        '' ''ByVal trDestinoFinal As String, ByVal strResumenEvolucion As String, ByVal xmlDiagnostico As String, ByVal strCodPrestador As String, _
        '' ''ByVal strSucursal As String, ByVal strTipoDocumento As String, ByVal strNumDoc As String, ByVal strTipoAdmi As String, _
        '' ''ByVal intAnoAdmi As Integer, ByVal lNumAdmi As Long, ByVal strLogin As String) As Long

        '' ''    Dim db As Database
        '' ''    Dim lsalida As Long

        '' ''    db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)

        '' ''    Dim SelectCommand As DBCommandWrapper = db.GetStoredProcCommandWrapper("HC_GrabarEgreso")
        '' ''    '/ la accion es 0 porque siempre es nuevo \
        '' ''    SelectCommand.AddInParameter("intAccion", DbType.Int32, 0)
        '' ''    SelectCommand.AddInParameter("strCodPreSgs", DbType.String, strCodPrestador)
        '' ''    SelectCommand.AddInParameter("strCodSucur", DbType.String, strSucursal)
        '' ''    SelectCommand.AddInParameter("strTipDoc", DbType.String, strTipoDocumento)
        '' ''    SelectCommand.AddInParameter("strNumDoc", DbType.String, strNumDoc)
        '' ''    SelectCommand.AddInParameter("strTipAdm", DbType.String, strTipoAdmi)
        '' ''    SelectCommand.AddInParameter("intAnoAdm", DbType.Int32, intAnoAdmi)
        '' ''    SelectCommand.AddInParameter("dblNumAdm", DbType.Int64, lNumAdmi)
        '' ''    SelectCommand.AddInParameter("strClaseDiag", DbType.String, "E")
        '' ''    SelectCommand.AddInParameter("strLogin", DbType.String, strLogin)
        '' ''    SelectCommand.AddInParameter("strImpDxs", DbType.String, xmlDiagnostico)
        '' ''    SelectCommand.AddInParameter("strEstadoSalida", DbType.String, strEstadoSalida)
        '' ''    SelectCommand.AddInParameter("strCausaMuerte", DbType.String, strCausaMuerte)
        '' ''    SelectCommand.AddInParameter("trDestinoFinal", DbType.String, trDestinoFinal)
        '' ''    SelectCommand.AddInParameter("strResumen", DbType.String, strResumenEvolucion)
        '' ''    SelectCommand.AddOutParameter("lError", DbType.String, 0)


        '' ''    db.ExecuteNonQuery(SelectCommand)
        '' ''    lsalida = CType(SelectCommand.GetParameterValue("lError"), Long)
        '' ''    SelectCommand.Command.Connection.Close()
        '' ''    SelectCommand.Dispose()
        '' ''    Return lsalida

        '' ''End Function


#End Region

#Region "ConsultarCondicionesSalidaHC"


        Public Shared Function consultarCondicionesObligatoriasDeSalida(ByVal objConexion As objCon, ByVal strCod_pre_sgs As String, ByVal strcod_sucur As String, _
                                                         ByVal strTip_admision As String, ByVal strAno_adm As String, _
                                                         ByVal strNum_Adm As String) As DataSet
            Dim objGeneral As New DAOGeneral()
            Dim lError As Long = -1

            Return objGeneral.EjecutarSPConParametrosDataSet("HC_TraerCondicionesObligatoriasDeSalida", objConexion, lError, strCod_pre_sgs, _
                                                             strcod_sucur, strTip_admision, strAno_adm, strNum_Adm)

        End Function

        ''' <summary>
        ''' Funcion que ejecuta el stored procedure HC_TraerCondicionesEgreso que 
        ''' trae la informacion de el diagnostico principal, la causa externa y
        ''' la recomendaciones al egreso.
        ''' </summary>
        ''' <param name="objConexion">Datos de la conexion</param>
        ''' <param name="strCod_pre_sgs">Codigo del prestador</param>
        ''' <param name="strcod_sucur">Codigo de la sucursal</param>
        ''' <param name="strTip_admision">Tipo de admision</param>
        ''' <param name="strAno_adm">Año de admision</param>
        ''' <param name="strNum_Adm">Numero de admision</param>
        ''' <returns>Dataset con las consultas</returns>
        ''' <remarks></remarks>
        Public Shared Function consultarCondicionesEgreso(ByVal objConexion As objCon, ByVal strCod_pre_sgs As String, ByVal strcod_sucur As String, _
                                                         ByVal strTip_admision As String, ByVal strAno_adm As String, _
                                                         ByVal strNum_Adm As String) As DataSet
            Dim objGeneral As New DAOGeneral()
            Dim lError As Long = -1

            Return objGeneral.EjecutarSPConParametrosDataSet("HC_TraerCondicionesEgreso", objConexion, lError, strCod_pre_sgs, _
                                                             strcod_sucur, strTip_admision, strAno_adm, strNum_Adm)
        End Function

        Public Shared Function cerrarHistoriaClinica(ByVal objconexion As objCon, ByVal strCod_pre_sgs As String, ByVal strcod_sucur As String, _
                                                     ByVal strTip_admision As String, ByVal strAno_adm As String, ByVal strNum_Adm As String, _
                                                     ByVal strTip_doc As String, ByVal strNum_doc As String, ByVal strLogin As String) As Long
            Dim objGeneral As New DAOGeneral()
            Dim lError As Long = 0

            Return objGeneral.EjecutarSPConParametrosTran("HC_CerrarHistoriaClinica", objconexion, strCod_pre_sgs, _
                                                         strcod_sucur, strTip_admision, strAno_adm, strNum_Adm, _
                                                         strTip_doc, strNum_doc, strLogin, lError)
        End Function
        ''Claudia Garay solo cerrar la Historia Perú Octubre 28 de 2013
        Public Shared Function cerrarHistoriaClinicaCE(ByVal objconexion As objCon, ByVal strCod_pre_sgs As String, ByVal strcod_sucur As String, _
                                                     ByVal strTip_admision As String, ByVal strAno_adm As String, ByVal strNum_Adm As String, _
                                                     ByVal strLogin As String) As Long
            Dim objGeneral As New DAOGeneral()
            Dim lError As Long = 0

            Return objGeneral.EjecutarSPConParametrosTran("HC_CerrarHistoriaClinicaCE", objconexion, strCod_pre_sgs, _
                                                         strcod_sucur, strTip_admision, strAno_adm, strNum_Adm, strLogin, lError)
        End Function
        Public Shared Function observacionHistoriaClinica(ByVal objconexion As objCon, ByVal strCod_pre_sgs As String, ByVal strcod_sucur As String, _
                                                          ByVal strTip_admision As String, ByVal strAno_adm As String, ByVal strNum_Adm As String) As Long

            Dim objGeneral As New DAOGeneral()
            Dim lError As Long = 0

            Return objGeneral.EjecutarSPConParametrosTran("HC_DejarEnObservacionHistoriaClinica", objconexion, strCod_pre_sgs, _
                                                         strcod_sucur, strTip_admision, strAno_adm, strNum_Adm, lError)
        End Function

        Public Shared Function actualizarEstadoHistoriaClinica(ByVal objConexion As objCon, ByVal strCod_pre_sgs As String, _
                                               ByVal strCod_sucur As String, ByVal strTip_Admision As String, _
                                               ByVal strAno_Adm As Integer, ByVal strNum_Adm As Double, ByVal estado As String) As Long
            Dim objGeneral As New DAOGeneral
            Dim lerror As Long = 0

            lerror = objGeneral.EjecutarSPConParametrosTran("HC_ActualizarEstadoHCEncabezado", objConexion, strCod_pre_sgs, _
                                                          strCod_sucur, strTip_Admision, strAno_Adm, strNum_Adm, estado, lerror)
            Return lerror
        End Function

#End Region

#End Region
    End Class
#End Region

End Namespace

