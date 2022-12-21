Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Namespace Sophia.HistoriaClinica.DAO
    Public Class DaoParaclinico
        Inherits GPMData

        Public Function HCAGFA_ConsultarDescripciones(ByVal strId As String,strFechaIni as String,strFechaFin as String) As DataSet
            Dim dt As DataSet

            Me.ParametersCollection.Clear()
            Me.setSQLSentence("HCAGFA_CONSULTADESCRIPCIONEXAMEN", CommandType.StoredProcedure)
            Me.addInputParameter("@identificador", SqlDbType.VarChar, strId) ''strId)
            Me.addInputParameter("@strFechaIni", SqlDbType.VarChar, strFechaIni)
            Me.addInputParameter("@strFechaFin", SqlDbType.VarChar, strFechaFin)
            dt = Me.execDS

            Return dt
        End Function

        Public Function HCAGFA_ConsultarInterface(ByVal strprestador As String, ByVal strSucursal As String) As DataTable
            Dim dt As DataTable

            Me.ParametersCollection.Clear()
            Me.setSQLSentence("HC_ConsultaInterfaceParaclinicos", CommandType.StoredProcedure)
            Me.addInputParameter("@cod_pre_sgs", SqlDbType.VarChar, strprestador) ''strId)
            Me.addInputParameter("@cod_sucur", SqlDbType.VarChar, strSucursal)
            dt = Me.execDT

            Return dt
        End Function


    End Class
End Namespace

