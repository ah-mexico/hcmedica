Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
imports HistoriaClinica .Sophia.HistoriaClinica.DatosConexion 

Namespace Sophia.HistoriaClinica.DAO

    Public Class GPMData

        Private command As SqlCommand = New SqlCommand
        '' ''Private m_sbStringConsulta As StringBuilder = New StringBuilder
        Private m_lngNTransacciones As Long = 0
        Public paramsArray() As Object

        Public Const TIMEOUT_COMMAND As Long = 180
        Private connectionString As String = String.Empty
        Private objDataConnexion As Conexion = Nothing

        Private Shared nInstancias As Int32 = 0

        ''' <summary>
        ''' Constructor de la clase
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
            Init()
            objDataConnexion = Conexion.Instancia
            Me.getConnectionString()
        End Sub

        ''' <summary>
        ''' Constructor de la clase
        ''' </summary>
        ''' <param name="objConnection">objeto que contiene los datos para generar la conexion</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal objConnection As Conexion)
            Init()
            objDataConnexion = objConnection
            Me.getConnectionString()
        End Sub

        ''' <summary>
        ''' Constructor de la clase
        ''' </summary>
        ''' <param name="strConnectionString">Cadena de coneccion</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal strConnectionString As String)
            Init()
            connectionString = strConnectionString
        End Sub

        ''' <summary>
        ''' Inicializa los objetos de la clase
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub Init()
            command.CommandTimeout = TIMEOUT_COMMAND
            command.CommandType = CommandType.Text
        End Sub

        ''' <summary>
        ''' Realiza la coneccion a la  base de datos
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub openConnexion()
            If command.Connection Is Nothing Then
                command.Connection = GenerateConnection()
            End If

            If command.Connection.State <> ConnectionState.Open Then
                command.Connection.Open()

            End If
        End Sub

        ''' <summary>
        ''' Obtiene la cadena de coneccion
        ''' </summary>
        ''' <returns>String que representa la cadena de coneccion</returns>
        ''' <remarks></remarks>
        Public Function getConnectionString() As String
            If (Me.connectionString Is Nothing) Then
                Me.connectionString = String.Empty
            End If
            If (Me.connectionString.Equals(String.Empty)) Then
                If (Me.command Is Nothing) Then
                    Me.command = New SqlCommand()
                End If

                If (Not Me.command.Connection Is Nothing) Then
                    Me.connectionString = Me.command.Connection.ConnectionString
                ElseIf (Not Me.objDataConnexion Is Nothing) Then
                    Me.connectionString = Me.objDataConnexion.getStringConnection()
                End If
            End If
            Return Me.connectionString
        End Function
        ''' <summary>
        ''' Genera o crea la coneccion
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GenerateConnection() As SqlConnection
            Return New SqlConnection(Me.GetConnectionString())
        End Function

        ''' <summary>
        '''  Es la sentencia SQL a ejecutar
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SQLSentence() As String
            Get
                '' ''Return m_sbStringConsulta.ToString()
                Return Me.command.CommandText
            End Get
            Set(ByVal Value As String)
                Me.command.CommandText = Value
            End Set
        End Property

        ''' <summary>
        ''' Limpia la sentencia SQL actual
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub clearSQLSentence()
            Me.command.CommandText = New String("")
        End Sub

        ''' <summary>
        ''' Fija el Tipo de Comando a ejecutar
        ''' </summary>
        ''' <param name="cmdType">Tipo de comando a ejecutar</param>
        ''' <remarks></remarks>
        Public Sub SetCommandType(ByVal cmdType As CommandType)
            command.CommandType = cmdType
        End Sub

        ''' <summary>
        ''' Fija el Tiempo de espera para el comando ejecutado
        ''' </summary>
        ''' <param name="nCommandTimeout">Tiempo de espera en la ejecucion de la transaccion.</param>
        ''' <remarks></remarks>
        Public Sub SetCommandTimeout(ByVal nCommandTimeout As Int32)
            command.CommandTimeout = nCommandTimeout
        End Sub

        ''' <summary>
        ''' Setea texto SQL al string de consulta
        ''' </summary>
        ''' <param name="strSQLSentence">Sentencia sql que puede ser un query o el nombre de una funcion, 
        ''' procedimiento almacenado u objeto en la base de datos.</param>
        ''' <param name="sqlSentenceType">Tipo de la sentencia sql.</param>
        ''' <remarks></remarks>
        Public Sub setSQLSentence(ByVal strSQLSentence As String, ByVal sqlSentenceType As CommandType)
            Me.clearSQLSentence()
            'Si el tipo de la sentencia es texto se limpian todos los parametros.
            If (sqlSentenceType = CommandType.Text) Then
                Me.ClearParameters()
            End If
            Me.command.CommandType = sqlSentenceType
            Me.command.CommandText = strSQLSentence
            '' ''m_sbStringConsulta.Append(strSQLSentence)
        End Sub
        ''' <summary>
        ''' Obtiene los parametros de un procedimiento y llena los valors con el arreglo de objetos.
        ''' </summary>
        ''' <remarks>En el arreglo de parametros deben venir los argumentos para ejecucion del store procedure
        ''' en el mismo orden de ejecucion. </remarks>
        Public Sub prepareParameters()
            If (Not Me.paramsArray Is Nothing) Then
                If (Me.paramsArray.Length > 0) Then
                    SqlCommandBuilder.DeriveParameters(Me.command)
                    Dim i As Integer

                    For Each parametro As SqlParameter In Me.command.Parameters
                        'Se coloca control para que cuando haya SPs con parámetros que pueden ser nulos en su firma. No se reviente al no mandarlos al construir el arreglo Datos()  INDRA/FABAICUE 10/03/2022
                        If (parametro.Direction <> ParameterDirection.ReturnValue And Me.paramsArray.Length - 1 >= i) Then
                            parametro.Value = Me.paramsArray(i)
                            i += 1
                        End If
                    Next
                End If
            End If
        End Sub
        ''' <summary>
        ''' Adiciona un grupo de valores para los parametros del procedimiento.
        ''' </summary>
        ''' <param name="paramsArray">Arreglo de parametros.</param>
        ''' <remarks>En el arreglo de parametros deben venir los argumentos para ejecucion del store procedure
        ''' en el mismo orden de ejecucion. </remarks>
        Public Sub addParameters(ByVal ParamArray paramsArray() As Object)
            Me.paramsArray = paramsArray
        End Sub
        ''' <summary>
        ''' Ejecuta un procedimiento almacenado.
        ''' </summary>
        ''' <param name="procedureName"></param>
        ''' <param name="paramsArray"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function execProcedure(ByVal procedureName As String, ByVal ParamArray paramsArray() As Object) As DataSet
            Dim dtSet As New DataSet()
            Try
                Me.openConnexion()

                Me.command.CommandType = CommandType.StoredProcedure
                Me.command.CommandText = procedureName
                '' Llena los parametros que conforman el procedure
                '' se debe tener en cuenta que esta instruccion hace un roundtrip para
                '' obtener la definicion de los paramtros del procedure
                '' llenar los parametros.
                Me.addParameters(paramsArray)
                Me.prepareParameters()

                ' Ejecutar comando
                Dim dtAdapter As New SqlClient.SqlDataAdapter(Me.command)
                dtAdapter.Fill(dtSet)
            Catch ex As Exception
                Throw ex
            Finally
                Me.closeConnexion()
            End Try

            Return dtSet
        End Function


        ''' <summary>
        ''' Adiciona valor a un parametro
        ''' Los nombres de los parametros inician con el caracter @
        ''' </summary>
        ''' <param name="strParamName">Nombre del parametro</param>
        ''' <param name="objParamValue">Valor del parametro</param>
        ''' <remarks></remarks>
        Public Sub AddParam(ByVal strParamName As String, ByVal objParamValue As Object)
            Dim param As SqlParameter = New SqlParameter(strParamName, objParamValue)
            command.Parameters.Add(param)
        End Sub

        ''' <summary>
        ''' Adiciona valor a un parametro, especificando el tipo 
        ''' </summary>
        ''' <param name="strParamName">Nombre del parametro</param>
        ''' <param name="sdtParamType">Tipo del parametro</param>
        ''' <param name="objParamValue">Valor del parametro</param>
        ''' <remarks></remarks>
        Public Sub AddParam(ByVal strParamName As String, ByVal sdtParamType As SqlDbType, ByVal objParamValue As Object)
            Dim param As SqlParameter = New SqlParameter(strParamName, sdtParamType)
            param.Value = objParamValue
            command.Parameters.Add(param)
        End Sub

        ''' <summary>
        ''' Adiciona un parametro de salida.
        ''' </summary>
        ''' <param name="strParamName">Nombre del parametro</param>
        ''' <param name="sdtParamType">Tipo del parametro</param>
        ''' <remarks>create: cavila@colsanitas.com</remarks>
        Public Sub addOutputParameter(ByVal strParamName As String, ByVal sdtParamType As SqlDbType)
            If (Not strParamName.StartsWith("@")) Then
                strParamName = "@" + strParamName
            End If
            Dim param As SqlParameter = New SqlParameter(strParamName, sdtParamType)
            param.Direction = ParameterDirection.Output
            command.Parameters.Add(param)
        End Sub

        ''' <summary>
        ''' Adiciona un parametro de salida.
        ''' </summary>
        ''' <param name="strParamName">Nombre del parametro</param>
        ''' <param name="sdtParamType">Tipo del parametro</param>
        ''' <param name="paramSize">Tamaño del parametro</param>
        ''' <remarks>create: cavila@colsanitas.com</remarks>
        Public Sub addOutputParameter(ByVal strParamName As String, ByVal sdtParamType As SqlDbType, ByRef paramSize As Integer)
            If (Not strParamName.StartsWith("@")) Then
                strParamName = "@" + strParamName
            End If
            Dim param As SqlParameter = New SqlParameter(strParamName, sdtParamType)
            param.Direction = ParameterDirection.Output
            param.Size = paramSize
            command.Parameters.Add(param)
        End Sub

        ''' <summary>
        ''' Adiciona valor a un parametro, especificando el tipo y si es IN o OUT
        ''' </summary>
        ''' <param name="strParamName">Nombre del parametro</param>
        ''' <param name="sdtParamType">Tipo del parametro</param>
        ''' <param name="paramDirection">Direccion, puede ser de entrada o salida</param>
        ''' <remarks></remarks>
        Public Sub AddParam(ByVal strParamName As String, ByVal sdtParamType As SqlDbType, ByVal paramDirection As ParameterDirection)
            Dim param As SqlParameter = New SqlParameter(strParamName, sdtParamType)
            param.Direction = paramDirection
            command.Parameters.Add(param)
        End Sub

        ''' <summary>
        ''' Adiciona valor a un parametro, especificando el tipo y direccion.
        ''' </summary>
        ''' <param name="strParamName">Nombre del parametro</param>
        ''' <param name="sdtParamType">Tipo del parametro</param>
        ''' <param name="objParamValue">Valor del parametro</param>
        ''' <remarks>create: cavila@colsanitas.com</remarks>
        Public Sub addInputParameter(ByVal strParamName As String, ByVal sdtParamType As SqlDbType, ByVal objParamValue As Object)
            If (Not strParamName.StartsWith("@")) Then
                strParamName = "@" + strParamName
            End If
            Dim param As SqlParameter = New SqlParameter(strParamName, sdtParamType)

            param.Direction = ParameterDirection.Input
            param.Value = objParamValue
            command.Parameters.Add(param)
        End Sub
        ''' <summary>
        ''' Retorna el parametro especificado con nombre
        ''' </summary>
        ''' <param name="strParamName">Nombre del parametro.</param>
        ''' <value></value>
        ''' <returns>Objeto Sqlparameter</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Parameters(ByVal strParamName As String) As SqlParameter
            Get
                If (Not strParamName.StartsWith("@")) Then
                    strParamName = "@" + strParamName
                End If
                Return command.Parameters(strParamName)
            End Get
        End Property

        ''' <summary>
        ''' Retorna la coleccion de parametros del command
        ''' </summary>
        ''' <value></value>
        ''' <returns>Objeto Sqlparameter</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ParametersCollection() As SqlParameterCollection
            Get
                Return command.Parameters
            End Get
        End Property

        ''' <summary>
        ''' Limpia todos los parametros que han sido adicionados al comando
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub ClearParameters()
            command.Parameters.Clear()
        End Sub

        ''' <summary>
        ''' Retorna un IDataReader
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ExecRdrSp() As SqlDataReader
            Dim sqlRdr As SqlDataReader

            Try
                If Me.objDataConnexion.EstadoInstancia Then
                    Me.objDataConnexion = Conexion.Instancia
                End If
                Me.openConnexion()
                Me.prepareParameters()
                sqlRdr = Me.command.ExecuteReader(CommandBehavior.CloseConnection)

            Catch e As Exception
                Me.closeConnexion()
                Me.ClearParameters()
                Throw e
            Finally
                Me.closeConnexion()
            End Try
            Return sqlRdr
        End Function

        Public Function ExecRdr() As SqlDataReader
            Dim sqlRdr As SqlDataReader

            Try
                If Me.objDataConnexion.EstadoInstancia Then
                    Me.objDataConnexion = Conexion.Instancia
                End If
                Me.openConnexion()
                Me.prepareParameters()
                sqlRdr = Me.command.ExecuteReader(CommandBehavior.CloseConnection)

            Catch e As Exception
                Me.closeConnexion()
                Me.ClearParameters()
                Throw e
            End Try
            Return sqlRdr
        End Function

        ''' <summary>
        ''' Retorna un objeto DataSet
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function execDS() As DataSet
            Dim adapter As New SqlDataAdapter
            Dim dtSet As New DataSet()

            Try
                openConnexion()
                '' ''command.CommandText = m_sbStringConsulta.ToString()
                adapter.SelectCommand = command
                Me.prepareParameters()
                adapter.Fill(dtSet)

            Catch ex As Exception
            Finally
                If Not IsInTransaction() Then
                    closeConnexion()
                    ' Me.ClearParameters()
                End If
            End Try

            Return dtSet
        End Function

        ''' <summary>
        ''' Metodo que ejecuta una sentencia sql y retorna un campo entre la primera columna y la primera fila. 
        ''' </summary>
        ''' <returns>Objeto encontrado en el campo entre la primera columna y la primera fila. </returns>
        ''' <remarks>create: cavila@colsanitas.com 12/12/2007</remarks>
        Public Function executeScalar() As Object
            Dim adapter As New SqlDataAdapter
            Dim ds As New DataSet
            Dim objReturn As Object = Nothing

            Try
                openConnexion()
                '' ''command.CommandText = m_sbStringConsulta.ToString()
                Me.prepareParameters()
                objReturn = command.ExecuteScalar()
                If IsDBNull(objReturn) Then
                    objReturn = Nothing
                End If
            Finally
                If Not IsInTransaction() Then
                    closeConnexion()
                End If
            End Try

            Return objReturn
        End Function

        ''' <summary>
        ''' Retorna un objeto DataTable
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function execDT() As DataTable
            Dim adapter As New SqlDataAdapter
            Dim dtTable As New DataTable

            Try
                openConnexion()
                '' ''command.CommandText = m_sbStringConsulta.ToString()
                Me.prepareParameters()
                adapter.SelectCommand = command
                adapter.Fill(dtTable)

            Finally
                If Not IsInTransaction() Then
                    closeConnexion()
                End If
            End Try

            Return dtTable
        End Function

        ''' <summary>
        ''' Ejecuta un Objeto Not Recordset Query
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Exec()
            Try
                openConnexion()
                Me.prepareParameters()
                command.ExecuteNonQuery()
            Finally
                If Not IsInTransaction() Then
                    closeConnexion()
                End If
            End Try
        End Sub

        ''' <summary>
        ''' Inicia la transaccion
        ''' </summary>
        ''' <remarks>
        ''' Para Transacciones
        ''' Características: Un nivel transacciones anidadas, conservando
        ''' el isolation level por defecto.
        ''' P.E:      Dim q As New DataLayer()
        '''           q.BeginTransaction()
        '''           Try
        '''               Lo que se hace
        '''               q.Commit()
        '''           Catch
        '''               q.Rollback()
        '''           End Try</remarks>
        Public Sub BeginTransaction()
            openConnexion()

            command.Transaction = command.Connection.BeginTransaction()

            m_lngNTransacciones = m_lngNTransacciones + 1
        End Sub

        ''' <summary>
        ''' Asegura la transaccion
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Commit()
            command.Transaction.Commit()

            m_lngNTransacciones = m_lngNTransacciones - 1

            If Not IsInTransaction() Then
                closeConnexion()
            End If
        End Sub

        ''' <summary>
        ''' Deshace la transaccion
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Rollback()
            command.Transaction.Rollback()

            m_lngNTransacciones = 0
            closeConnexion()
        End Sub

        ''' <summary>
        ''' Cierra la coneccion
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub closeConnexion()
            If Not command.Connection Is Nothing Then
                If command.Connection.State <> ConnectionState.Closed Then
                    If IsInTransaction() Then
                        Rollback()
                    End If

                    Command.Connection.Close()
                End If

                Command.Connection = Nothing
            End If
        End Sub

        ''' <summary>
        ''' Determina si existen transacciones
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function IsInTransaction() As Boolean
            Return (m_lngNTransacciones > 0)
        End Function



    End Class

End Namespace
