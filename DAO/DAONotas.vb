
Imports objDatosGenerales = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes
Imports HistoriaClinica.Sophia.HistoriaClinica.BL.BLNotasAclaratorias

Namespace Sophia.HistoriaClinica.DAO
    Public Class DAONotas
        Inherits GPMData

        Public Function DAOTraerHistorias(ByVal strTipoDoc As String, ByVal strNumDoc As String, ByVal strXMLUnificados As String) As DataSet
            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper

            Dim dtset As New DataSet

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objCon.Instancia.strServidor, objCon.Instancia.strBaseDatos, objCon.Instancia.strUsuarioBD, objCon.Instancia.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''command = db.GetStoredProcCommandWrapper("HC_TraerNotasAclaratorias")
            '' ''With command
            '' ''    .AddInParameter("strTipDoc", DbType.String, strTipoDoc)
            '' ''    .AddInParameter("strNumDoc", DbType.String, strNumDoc)
            '' ''    .AddInParameter("strDocumentosUnificados", DbType.String, strXMLUnificados)
            '' ''End With

            '' ''dtset = db.ExecuteDataSet(command)
            Me.setSQLSentence("HC_TraerNotasAclaratorias", CommandType.StoredProcedure)
            Me.addInputParameter("strTipDoc", SqlDbType.VarChar, strTipoDoc)
            Me.addInputParameter("strNumDoc", SqlDbType.VarChar, strNumDoc)
            Me.addInputParameter("strDocumentosUnificados", SqlDbType.VarChar, strXMLUnificados)
            dtset = Me.execDS()

            Return dtset

        End Function


        Public Sub DAOActualizaNotasAclaratorias(ByVal objNotas As datosNotasAclaratoria, ByVal strNotaAclara As String, ByVal strObservaciones As String, ByVal intadmisionExistente As Integer)
            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objCon.Instancia.strServidor, objCon.Instancia.strBaseDatos, objCon.Instancia.strUsuarioBD, objCon.Instancia.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' '' command = db.GetStoredProcCommandWrapper("pa_busHC_GrabarNotas")

            '' ''With command
            '' ''    .AddInParameter("@intAccion", DbType.Int16, intadmisionExistente)
            '' ''    .AddInParameter("@strCodPreSgs", DbType.String, objNotas.Prestadora)
            '' ''    .AddInParameter("@strCodSucur", DbType.String, objNotas.Sucursal)
            '' ''    .AddInParameter("@strTipAdm", DbType.String, objNotas.TipoAdmision)
            '' ''    .AddInParameter("@intAnoAdm", DbType.Int16, objNotas.AnnoAdmision)
            '' ''    .AddInParameter("@dblNumAdm", DbType.Int32, objNotas.Admision)
            '' ''    .AddInParameter("@dteFechaNota", DbType.DateTime, Now)
            '' ''    If intadmisionExistente = 1 Then
            '' ''        .AddInParameter("@dteHoraNota", DbType.DateTime, objNotas.HoraNota)
            '' ''    Else
            '' ''        .AddInParameter("@dteHoraNota", DbType.DateTime, Now)
            '' ''    End If

            '' ''    .AddInParameter("@strNota", DbType.String, strNotaAclara)
            '' ''    .AddInParameter("@strLogin", DbType.String, objDatosGenerales.Generales.Instancia.Login)
            '' ''    .AddInParameter("@strObs", DbType.String, strObservaciones)
            '' ''    .AddIOParameter("@lError", DbType.Int16, 2)
            '' ''End With
            '' ''db.ExecuteNonQuery(command)

            Me.setSQLSentence("pa_busHC_GrabarNotas", CommandType.StoredProcedure)
            Me.addInputParameter("intAccion", SqlDbType.Int, intadmisionExistente)
            Me.addInputParameter("strCodPreSgs", SqlDbType.VarChar, objNotas.Prestadora)
            Me.addInputParameter("strCodSucur", SqlDbType.VarChar, objNotas.Sucursal)

            Me.addInputParameter("strTipAdm", SqlDbType.VarChar, objNotas.TipoAdmision)
            Me.addInputParameter("intAnoAdm", SqlDbType.Int, objNotas.AnnoAdmision)
            Me.addInputParameter("dblNumAdm", SqlDbType.Int, objNotas.Admision)

            Me.addInputParameter("dteFechaNota", SqlDbType.DateTime, Now)

            If intadmisionExistente = 1 Then
                Me.addInputParameter("dteHoraNota", SqlDbType.DateTime, objNotas.HoraNota)
            Else
                Me.addInputParameter("dteHoraNota", SqlDbType.DateTime, Now)
            End If
            intadmisionExistente = 0
            Me.addInputParameter("strNota", SqlDbType.VarChar, strNotaAclara)
            Me.addInputParameter("strLogin", SqlDbType.VarChar, objDatosGenerales.Generales.Instancia.Login)
            Me.addInputParameter("strObs", SqlDbType.VarChar, strObservaciones)
            Me.addOutputParameter("lError", SqlDbType.Int)

            Me.Exec()

        End Sub


        'Se cambia consulta a procedimiento para traer solo una nota así estén repetidas --llarias 30/04/2014
        Public Function DAOTraerNotas(ByVal objNotas As datosNotasAclaratoria) As DataTable

            Dim ds As New DataTable

            Me.setSQLSentence("spTraerNotas", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, objNotas.Prestadora)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, objNotas.Sucursal)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, objNotas.TipoAdmision)
            Me.addInputParameter("ano_adm", SqlDbType.Int, objNotas.AnnoAdmision)
            Me.addInputParameter("num_adm", SqlDbType.Decimal, objNotas.Admision)
            ds = Me.execDT
            Return ds

        End Function


    End Class
End Namespace