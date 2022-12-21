Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion


Namespace Sophia.HistoriaClinica.DAO
    Public Class DAOEscalas
        Inherits GPMData

#Region "DAOEscalas"

#Region "consultarTiposRass"
        Public Function consultarTiposRass(ByVal objConexion As Conexion) As DataTable
            Dim dtTable As DataTable
            Me.setSQLSentence("select cod_rass, desc_rass from hcenftiporass (nolock)", CommandType.Text)
            dtTable = Me.execDT()
            Return dtTable
        End Function
#End Region

#Region "consultarTiposRiesgo"
        Public Function consultarTiposRiesgo(ByVal objConexion As Conexion) As DataTable
            Dim dtTable As DataTable
            Me.setSQLSentence("SELECT cod_tiporiesgo,desc_tiporiesgo ,0 as valor FROM HCENFTIPORIESGO  (NOLOCK) ", CommandType.Text)
            dtTable = Me.execDT()
            Return dtTable
        End Function
#End Region

#Region "consultarTiposRiesgoNuevo"
        Public Function consultarTiposRiesgoNuevo(ByVal objConexion As Conexion) As DataTable
            Dim dtTable As DataTable
            Me.setSQLSentence("SELECT b.desc_categoriariesgo as categoria,b.desclarga_categoriariesgo as descripcion_larga,a.desc_tiporiesgo as factor_riesgo,valor,a.cod_tiporiesgo,a.categoriaRiesgo  FROM HCENFTIPORIESGO a (NOLOCK) inner join HCENFCATEGORIARIESGO b(nolock) on a.categoriaRiesgo=b.cod_categoriariesgo where a.categoriaRiesgo is not null", CommandType.Text)
            dtTable = Me.execDT()
            Return dtTable
        End Function
#End Region

#Region "consultarTiposRiesgoVal"
        Public Function consultarTiposRiesgoVal(ByVal objConexion As Conexion) As DataTable
            Dim dtTable As DataTable
            Me.setSQLSentence("SELECT cod_tiporiesgo,0 as valor, valor as puntaje FROM HCENFTIPORIESGO (NOLOCK) where categoriaRiesgo is not null", CommandType.Text)
            dtTable = Me.execDT()
            Return dtTable
        End Function
#End Region

#Region "GrabarTISS"
        Public Function GrabarTISS(ByVal objConexion As objCon, ByVal dNumeroHistoria As Integer, ByVal fecha As DateTime, ByVal hora As String, ByVal minuto As String, ByVal dTISS As Decimal, ByVal strLogin As String) As Long

            Dim lError As Long


            Me.setSQLSentence("HC_GrabarTISSEnfermeria", CommandType.StoredProcedure)

            Me.addInputParameter("@intCodhistoria", SqlDbType.Int, dNumeroHistoria)
            Me.addInputParameter("@fecha", SqlDbType.DateTime, fecha)
            Me.addInputParameter("@hora_TISS", SqlDbType.VarChar, hora)
            Me.addInputParameter("@min_TISS", SqlDbType.VarChar, minuto)
            Me.addInputParameter("@TISS", SqlDbType.Decimal, dTISS)
            Me.addInputParameter("@strlogin", SqlDbType.VarChar, strLogin)
            Me.addOutputParameter("lError", SqlDbType.Int)

            Try
                Me.BeginTransaction()
                Me.Exec()
                Me.Commit()
                lError = Val(Me.Parameters("lError").Value)
                Return lError

            Catch ex As Exception
                lError = -1
                Me.Rollback()
                Return lError
            End Try


        End Function
#End Region

#Region "ValidarTISS"
        Public Function ValidarTISS(ByVal objConexion As objCon, ByVal dNumeroHistoria As Integer, ByVal fecha As DateTime, ByVal hora As String, ByVal minuto As String) As Boolean
            Dim dtTable As DataTable
            Dim sSql As String = ""

            sSql = "select 1 from hcenftiss with(nolock)" & vbCrLf
            sSql = sSql & " where cod_historia = " & dNumeroHistoria & vbCrLf
            sSql = sSql & " and CONVERT(VARCHAR(10),fecha,103)  = '" & Format(fecha, "dd/MM/yyyy") & "'" & vbCrLf
            sSql = sSql & " and hora_tiss = '" & hora & "'" & vbCrLf
            sSql = sSql & " and min_tiss = '" & minuto & "'"

            Me.setSQLSentence(sSql, CommandType.Text)
            dtTable = Me.execDT()

            If dtTable.Rows.Count > 0 Then
                Return False
            Else
                Return True
            End If
        End Function
#End Region

#Region "ConsultarNotasTISS"
        Public Function ConsultarNotasTISS(ByVal objConexion As objCon, ByVal dNumeroHistoria As Integer, _
        ByRef dtNotasTISS As DataTable) As Long

            Dim lError As Long

            Me.setSQLSentence("HCEnf_ConsultarTISS", CommandType.StoredProcedure)

            Me.addInputParameter("@intCodhistoria", SqlDbType.Int, dNumeroHistoria)
            Me.addOutputParameter("lError", SqlDbType.Int)

            dtNotasTISS = Me.execDT()

            lError = Val(Me.Parameters("lError").Value)
            Return lError

        End Function
#End Region

#End Region


        ''' <summary>
        ''' Trae los datos de la escala en especifico que se encuentra parametrizada
        ''' </summary>
        ''' <param name="objConexion">cadena de conexión a base de datos</param>
        ''' <param name="idEscala">identificador de la escala a consultar</param>
        ''' <returns>datatable</returns>
        Public Function ConsultarPlantillaEscala(ByVal objConexion As Conexion, idEscala As Int16) As DataTable


            Dim dtdatos As DataTable

            Me.setSQLSentence("HCENF_ESCALA_CONSULTAR_PLANTILLA", CommandType.StoredProcedure)
            Me.addInputParameter("IDESCALA", SqlDbType.Int, idEscala)

            dtdatos = Me.execDT

            Return dtdatos

        End Function
        ''' <summary>
        ''' Carga el historico de escalas de acuerdo a los parametros suministrados
        ''' </summary>
        ''' <param name="objConexion">cadena de conexión a base de datos</param>
        ''' <param name="idEscala">identificador de la escala a consultar</param>
        ''' <param name="codhistoria">identificador de la HC a consultar</param>
        ''' <returns></returns>
        Public Function ConsultarEscalaHistorico(ByVal objConexion As Conexion, idEscala As Int16, codhistoria As Int64) As DataTable

            Dim dtdatos As DataTable

            Me.setSQLSentence("HCENF_ESCALA_CONSULTAR_ESCALA", CommandType.StoredProcedure)
            Me.addInputParameter("CODHISTORIA", SqlDbType.BigInt, codhistoria)
            Me.addInputParameter("IDESCALA", SqlDbType.Int, idEscala)

            dtdatos = Me.execDT

            Return dtdatos

        End Function
        ''' <summary>
        ''' Consulta el puntaje de la escala suministrada
        ''' </summary>
        ''' <param name="objConexion">cadena de conexión a base de datos</param>
        ''' <param name="idEscala">identificador de la escala a consultar</param>
        ''' <returns></returns>
        Public Function ConsultarEscalaPuntaje(ByVal objConexion As Conexion, idEscala As Int16) As DataTable

            Dim dtdatos As DataTable

            Me.setSQLSentence("HCENF_ESCALA_CONSULTA_PUNTAJE", CommandType.StoredProcedure)
            Me.addInputParameter("IDESCALA", SqlDbType.Int, idEscala)

            dtdatos = Me.execDT

            Return dtdatos

        End Function
        ''' <summary>
        ''' Consulta la clasificacion de la escala suministrada
        ''' </summary>
        ''' <param name="objConexion">cadena de conexión a base de datos</param>
        ''' <param name="idEscala">identificador de la escala a consultar</param>
        ''' <returns></returns>
        Public Function ConsultarEscalaClasificacionRiesgo(ByVal objConexion As Conexion, idEscala As Int16) As DataTable

            Dim dtdatos As DataTable

            Me.setSQLSentence("HCENF_ESCALA_CONSULTA_CLASIFICACION_RIESGO", CommandType.StoredProcedure)
            Me.addInputParameter("IDESCALA", SqlDbType.Int, idEscala)

            dtdatos = Me.execDT

            Return dtdatos

        End Function


        Public Function consultarHoraDif(ByVal objConexion As Conexion, IdEscala As Int32) As Int32

            Dim HoraDif As Int32 = 0
            Dim dtdatos As DataTable

            Me.setSQLSentence("HCENF_ESCALA_CONSULTA_MINIMOHORAS", CommandType.StoredProcedure)
            Me.addInputParameter("IDESCALA", SqlDbType.Int, IdEscala)

            dtdatos = Me.execDT

            If dtdatos.Rows.Count > 0 Then
                HoraDif = dtdatos.Rows(0).Item(0)
            End If

            Return HoraDif

        End Function

        ''' <summary>
        ''' Consulta el Linked Server donde se debe conectar, para bogota retorna vacio
        ''' </summary>
        ''' <param name="objConexion"></param>
        ''' <param name="Basedatos"></param>
        ''' <returns></returns>
        Public Function consultarLinkedBD(ByVal objConexion As Conexion, Basedatos As String) As DataTable


            Dim dtdatos As DataTable

            Me.setSQLSentence("HC_CONEXION_BD", CommandType.StoredProcedure)
            Me.addInputParameter("BDACTUAL", SqlDbType.Text, Basedatos)

            dtdatos = Me.execDT

            Return dtdatos

        End Function

    End Class
End Namespace
