Imports System.Linq
Imports System.Reflection
Imports System.Collections.Generic
Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales

Namespace Sophia.HistoriaClinica.DAO

    ''' -----------------------------------------------------------------------------
    ''' Project	 : HistoriClinica.DAO.DAOGeneral
    ''' Class	 : Sophia.HistoriaClinica.DAO.DAOGeneral
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Clase DAOEgresos del namespace Sophia.HistoriaClinica.DAO que es la clase 
    ''' data de HistoriaClinica.DAO
    ''' y será usada desde este namespace para el acceso a los datos
    ''' se agrega de la application block Data.SqlHelper
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[ggarzon]	28/03/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class DAOGeneral
        Inherits GPMData

#Region "EjecutarSenteciasSQL - Retorna Datatable"
        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Función general, basada en la extensión del Enterprice.Library.Data
        ''' Para ejecutar un procedmiento almacenado con parámetros de entrada y sin transaccionalidad
        ''' </summary>
        ''' <returns>DataTable con los registros de los egresos seleccionador</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[ggarzon-mvargas]	19/04/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function EjecutarSQLConParametros(ByVal strTabla As String, ByVal objConexion As objCon, ByVal strCampos As String, ByVal strCondicion As String) As DataTable
            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
            '' ''Dim db As Database
            '' ''Dim ds As New DataSet
            '' ''Dim command As DBCommandWrapper
            Dim dtTable As New DataTable

            Dim strSql As String
            If strCondicion.Trim.Length > 0 Then
                strCondicion = " WHERE " & strCondicion
            End If
            strSql = "SELECT " & strCampos & " FROM " & strTabla & strCondicion

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''command = db.GetSqlStringCommandWrapper(strSql)
            '' ''ds = db.ExecuteDataSet(command)
            Me.setSQLSentence(strSql, CommandType.Text)

            dtTable = Me.execDS().Tables(0)

            Return dtTable

        End Function

#End Region

#Region "EjecutarSpConParametros-Retorna Datatable"
        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Función general, basada en la extensión del Enterprice.Library.Data
        ''' Para ejecutar un procedmiento almacenado con parámetros de entrada y sin transaccionalidad
        ''' </summary>
        ''' <param name="strProcedimiento">Parámetro tipo string que indica el nombre del
        ''' Procedimiento almacenado</param>
        ''' <param name="parametersArray">Parámetro tipo object que indica los parámetros del procedimiento</param>
        ''' <returns>DataTable con los registros de los egresos seleccionador</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[ggarzon-mvargas]	19/04/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function EjecutarSPConParametros(ByVal strProcedimiento As String, ByVal objConexion As objCon,
                                                ByRef lError As Long, ByVal ParamArray parametersArray() As Object) As DataTable
            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
            '' ''Dim db As Database
            Dim dtSet As New DataSet
            Dim dtTable As New DataTable


            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''Dim SelectCommand As DBCommandWrapper = db.GetStoredProcCommandWrapper(strProcedimiento, parametersArray)
            '' ''ds = db.ExecuteDataSet(SelectCommand)
            Me.setSQLSentence(strProcedimiento, CommandType.StoredProcedure)
            Me.addParameters(parametersArray)

            dtSet = Me.execDS()
            If (Not dtSet Is Nothing And dtSet.Tables.Count > 0) Then
                dtTable = dtSet.Tables(0)
            End If
            If lError > 0 Then
                If (Not Me.Parameters("@lError") Is Nothing) Then
                    lError = CType(Me.Parameters("@lError").Value, Long)
                End If
            End If
            'cariasm
            'If (Not dtSet Is Nothing) Then
            '    dtTable = dtSet.Tables(0)
            'End If

            '' ''SelectCommand.Command.Connection.Close()
            '' ''SelectCommand.Dispose()
            Return dtTable

        End Function
#End Region

#Region "EjecutarSpSinParametros-Retorna Datatable"
        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Función general, basada en la extensión del Enterprice.Library.Data
        ''' Para ejecutar un procedmiento almacenado sin parámetros de entrada y sin transaccionalidad
        ''' </summary>
        ''' <param name="strProcedimiento">Parámetro tipo string que indica el nombre del
        ''' Procedimiento almacenado</param>
        ''' <returns>DataTable con los registros de los egresos seleccionador</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[ggarzon-mvargas]	19/04/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function EjecutarSPSinParametros(ByVal strProcedimiento As String, ByVal objConexion As objCon,
                                                ByRef lError As Long) As DataTable
            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
            '' ''Dim db As Database
            Dim dtSet As New DataSet
            Dim dtTable As New DataTable

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''Dim SelectCommand As DBCommandWrapper = db.GetStoredProcCommandWrapper(strProcedimiento)
            'SelectCommand.AddIOParameter("@lerror", DbType.Int32, 2)

            '' ''ds = db.ExecuteDataSet(SelectCommand)
            'lError = CType(SelectCommand.GetParameterValue("lerror"), Long)

            '' ''dt = ds.Tables(0)
            '' ''SelectCommand.Command.Connection.Close()
            '' ''SelectCommand.Dispose()
            Me.setSQLSentence(strProcedimiento, CommandType.StoredProcedure)
            dtSet = Me.execDS()

            If (Not dtSet Is Nothing) Then
                dtTable = dtSet.Tables(0)
            End If

            Return dtTable

        End Function
#End Region

#Region "EjecutarSpConParametroTran-Retorna Long"
        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Función general, basada en la extensión del Enterprice.Library.Data
        ''' Para ejecutar un procedmiento almacenado con parámetros de entrada con transaccionalidad 
        ''' y retornar un Long
        ''' </summary>
        ''' <param name="strProcedimiento">Parámetro tipo string que indica el nombre del
        ''' Procedimiento almacenado</param>
        ''' <param name="parametersArray">Parámetro tipo object que indica los parámetros del procedimiento</param>
        ''' <returns>Long con el número de error o 0 sin errores</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[ggarzon-mvargas]	22/04/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function EjecutarSPConParametrosTran(ByVal strProcedimiento As String, ByVal objConexion As objCon, ByVal ParamArray parametersArray() As Object) As Long
            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
            '' ''Dim db As Database

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)

            '' ''Dim SelectCommand As DBCommandWrapper = db.GetStoredProcCommandWrapper(strProcedimiento, a)
            ' '' ''SelectCommand.AddIOParameter("@lerror", DbType.Int32, 2)
            '' ''db.ExecuteNonQuery(SelectCommand)
            '' '' = CType(SelectCommand.GetParameterValue("lError"), Long)
            '' ''SelectCommand.Command.Connection.Close()
            '' ''SelectCommand.Dispose()
            Dim longReturn As Long = 0


            Me.setSQLSentence(strProcedimiento, CommandType.StoredProcedure)


            Me.addParameters(parametersArray)

            Me.ExecRdrSp()
            If (Not Me.Parameters("lError") Is Nothing And Not Me.Parameters("lError").Value.ToString = "") Then
                longReturn = Long.Parse(Me.Parameters("lError").Value)
            End If

            Return longReturn
        End Function

        'Inicia: CCGUTIEREZ - OSI. 04/03/2020
        'Proyecto: Sophia - Pyxis. ALM_188
        'Cambio: Se inactiva bloque, el control de excepcion se realiza directamente en la funcion ConsultarDiasHistorico
        'Friend Shared Function ConsultarDiasHistorico(strNombre As String) As DataTable
        '    Throw New NotImplementedException()
        'End Function
        'Fin. CCGUTIEREZ

#End Region

#Region "EjecutarSentenciaSQl -Retorna String"
        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Función general, basada en la extensión del Enterprice.Library.Data
        ''' Para ejecutar una sentencia sql y retornar un string
        ''' </summary>
        ''' <param name="strTabla">Parámetro tipo string que indica el nombre de la tabla</param>
        ''' <param name="strCampos">Parámetro tipo string que indica los campos a consultar</param>
        ''' <param name="strCondicion">Parámetro tipo string que indica los condicionantes de la consulta</param>
        ''' <returns>string con valor</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mvargas]	05/05/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function EjecutarSQLStrValor(ByVal strTabla As String, ByVal objConexion As objCon, ByVal strCampos As String, ByVal strCondicion As String) As String
            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper
            Dim strSql As String
            Dim strReturn As String

            If strCondicion.Trim.Length > 0 Then
                strCondicion = " WHERE " & strCondicion
            End If
            strSql = "SELECT " & strCampos & " FROM " & strTabla & strCondicion
            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''command = db.GetSqlStringCommandWrapper(strSql)
            '' ''strSql = db.ExecuteScalar(Command).ToString()
            Me.setSQLSentence(strSql, CommandType.Text)

            strReturn = Me.executeScalar()

            Return strReturn

            '' ''Esto nunca sera ejecutado
            '' ''command.Command.Connection.Close()
            '' ''Command.Dispose()

        End Function
#End Region

#Region "EjecutarSenteciasSQL - Retorna arraylist"
        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Función general, basada en la extensión del Enterprice.Library.Data
        ''' Para ejecutar una sentencia sql y retornar un arraylist
        ''' </summary>
        ''' <param name="objConexion">Parámetro tipo objeto conexion con los parámetros para la conexion</param>
        ''' <param name="strSQL">Parámetro tipo string que indica la setencia sql</param>
        ''' <returns>array list con valor</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mvargas]	10/05/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function EjecutarSQLArrayList(ByVal objConexion As objCon, ByVal strSQL As String) As ArrayList
            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper

            Dim i As Integer
            Dim dtReader As IDataReader
            Dim arDatos As ArrayList = New ArrayList


            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''command = db.GetSqlStringCommandWrapper(strSQL)
            '' ''dr = db.ExecuteReader(command)

            Me.setSQLSentence(strSQL, CommandType.Text)
            dtReader = Me.ExecRdr()
            If (Not dtReader Is Nothing) Then
                While dtReader.Read()
                    For i = 0 To dtReader.FieldCount - 1
                        Dim obj As New Sophia.HistoriaClinica.Comunes.ObjetoSimple
                        obj.strDato = dtReader.GetName(i).ToString()
                        obj.strValor = dtReader.GetValue(i).ToString()
                        arDatos.Add(obj)
                    Next
                End While
            End If

            '' ''command.Command.Connection.Close()
            '' ''command.Command.Connection.Dispose()
            Return arDatos
        End Function
#End Region

#Region "TraerFechaServidor"
        Public Function traerFechaServidor() As Date
            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
            '' ''Dim db As Database
            Dim objConexion As objCon
            '' ''Dim command As DBCommandWrapper

            objConexion = objCon.Instancia()

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''command = db.GetStoredProcCommandWrapper("HC_TraerFechaSistema")
            Me.setSQLSentence("HC_TraerFechaSistema", CommandType.StoredProcedure)

            Return CType(Me.executeScalar(), Date)

        End Function
#End Region

#Region "EjecutarSPConParametros Retorna DataSet"
        Public Function EjecutarSPConParametrosDataSet(ByVal strProcedimiento As String, ByVal objConexion As objCon,
                                                       ByRef lError As Long, ByVal ParamArray parametersArray() As Object) As DataSet
            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
            '' ''Dim db As Database
            Dim ds As New DataSet

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''Dim SelectCommand As DBCommandWrapper = db.GetStoredProcCommandWrapper(strProcedimiento, parametersArray)
            '' ''ds = db.ExecuteDataSet(SelectCommand)

            '' ''If lError >= 0 Then
            '' ''    lError = CType(SelectCommand.GetParameterValue("@lerror"), Long)
            '' ''End If.

            '' ''SelectCommand.Command.Connection.Close()
            '' ''SelectCommand.Dispose()
            Me.setSQLSentence(strProcedimiento, CommandType.StoredProcedure)
            Me.addParameters(parametersArray)
            ds = Me.execDS()
            'cariasm
            'If lError <> 0 Or ds.Tables.Count = 0 Then
            If lError >= 0 Then
                If (Not Me.Parameters("@lError") Is Nothing) Then
                    lError = CType(Me.Parameters("@lError").Value, Long)
                End If
            End If

            Return ds

        End Function
#End Region
        Public Function consultarProgramasEduc(ByVal objConexion As objCon) As DataTable
            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''command = db.GetSqlStringCommandWrapper("select tipDieta, descripcion from nuttipdieta")
            Dim dtTable As DataTable
            Me.setSQLSentence("select codigo_programa, descripcion from genProgEducacion (nolock)", CommandType.Text)
            dtTable = Me.execDT()

            Return dtTable

        End Function
        ''' <summary>
        ''' Rmzaldua Liquidos 2018/03/08
        ''' </summary>
        ''' <param name="strNombre"></param>
        ''' <returns></returns>
        Public Function ConsultarDiasHistorico(ByVal strNombre As String) As DataTable
            Dim dt As New DataTable
            Me.setSQLSentence("DB_Traergenparsophia", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("nombre_par", SqlDbType.VarChar, strNombre)
            dt = Me.execDT()
            Return dt
        End Function

        Public Function ConvertDataTableToList(Of T)(ByVal dt As DataTable) As List(Of T)
            Dim data As List(Of T) = New List(Of T)()

            For Each row As DataRow In dt.Rows
                Dim item As T = GetItem(Of T)(row)
                data.Add(item)
            Next

            Return data
        End Function

        Public Function GetItem(Of T)(ByVal dr As DataRow) As T
            Dim temp As Type = GetType(T)
            Dim obj As T = Activator.CreateInstance(Of T)()

            For Each column As DataColumn In dr.Table.Columns

                For Each pro As PropertyInfo In temp.GetProperties()

                    If pro.Name.ToUpper() = column.ColumnName.ToUpper() And dr(column.ColumnName).GetType.Name <> "DBNull" Then
                        pro.SetValue(obj, dr(column.ColumnName), Nothing)
                    Else
                        Continue For
                    End If
                Next
            Next

            Return obj
        End Function

        'Inicia: CCGUTIEREZ - OSI. 04/05/2020
        'Proyecto: Sophia - Contingencia. COVID-19 
        'Cambio: Se agrega funcion tipo DataTable que recupera todos los campos de la tabla GENMEDIC
        'Solicitud: ALM_06
        Public Function dtbMedicoResidente(ByVal strMedico As String) As DataTable

            Dim dtMedRes As New DataTable

            Me.setSQLSentence("SP_MedicoResidente", CommandType.StoredProcedure)
            Me.ParametersCollection.Clear()
            Me.addInputParameter("@strMedico", SqlDbType.VarChar, strMedico)

            dtMedRes = Me.execDT()

            dtbMedicoResidente = dtMedRes

        End Function

    End Class
End Namespace