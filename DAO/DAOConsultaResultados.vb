Imports objDatosGenerales = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion

Namespace Sophia.HistoriaClinica.DAO
    Public Class DAOConsultaResultados
        Inherits GPMData
        ''TODO:Verificar si es necesario eliminar esta clase.
        '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
        '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007

        '' '' se comentarea el codigo ya que este metodo no esta siendo llamado por ninguna instancia en la aplicacion

        '' ''Public Shared Sub DAOTraerResDetImagenes(ByVal strTip_doc As String, _
        '' ''               ByVal strNum_doc As String, ByVal dteFecDesde As Date, _
        '' ''               ByVal dteFecHasta As Date, ByVal iTipoExamen As Integer, _
        '' ''               ByVal bAuditoria As Boolean, ByVal strLogin As String, ByVal strEstadoUnificacion As String)
        'objDatosGenerales.Generales.Instancia. 

        '' ''Dim db As Database
        '' ''Try
        '' ''    db = DynamicDatabaseFactory.CreateDatabase(objCon.Instancia.strServidor, objCon.Instancia.strBaseDatos, objCon.Instancia.strUsuarioBD, objCon.Instancia.strClaveUsuarioBD, DBProviderType.SqlServer)

        '' ''    Dim SelectCommand As DBCommandWrapper = db.GetStoredProcCommandWrapper("")
        '' ''    SelectCommand.AddIOParameter("@lsalida", DbType.Int32, 2)
        '' ''    db.ExecuteNonQuery(SelectCommand)
        '' ''    'EjecutarSPConParametrosTran = CType(SelectCommand.GetParameterValue("lsalida"), Long)
        '' ''    'ds = db.ExecuteDataSet(SelectCommand)
        '' ''    'dt = ds.Tables(0)
        '' ''    SelectCommand.Command.Connection.Close()
        '' ''    SelectCommand.Dispose()
        '' ''Catch ex As Exception
        '' ''    'Throw New Exception(" DAOEgresos.EjecutarSpConParametrosTran(" & strProcedimiento & ")")
        '' ''End Try

        '' ''End Sub


    End Class
End Namespace