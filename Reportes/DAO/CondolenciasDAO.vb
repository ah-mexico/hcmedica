Imports System.Collections.Generic
Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes.Data
Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales.Generales
Namespace Sophia.HistoriaClinica.Reportes.DAO
    Public Class CondolenciasDAO
        Inherits GPMDataReport
        ''' <remarks></remarks>
        Public Function dsConsultarCondolencias(ByVal strCod_pre_sgs As String, _
                              ByVal strCod_sucur As String, ByVal strTipAdm As String, _
                              ByVal intAnoAdm As Integer, ByVal dNumAdm As Double, _
                              ByVal strTipDoc As String, ByVal strNumDoc As String) As DataTable

            Dim dtSetReturn As DataTable

            ''Carga de parametros para ejecucion del procedimiento
            gpmDataObj.setSQLSentence("HC_Reportes_RepCondolencias", CommandType.StoredProcedure)

            gpmDataObj.addInputParameter("@cod_pre_sgs", SqlDbType.VarChar, strCod_pre_sgs)
            gpmDataObj.addInputParameter("@cod_sucur", SqlDbType.VarChar, strCod_sucur)
            gpmDataObj.addInputParameter("@tip_admision", SqlDbType.VarChar, strTipAdm)
            gpmDataObj.addInputParameter("@ano_adm", SqlDbType.Int, intAnoAdm)
            gpmDataObj.addInputParameter("@num_adm", SqlDbType.BigInt, dNumAdm)
            gpmDataObj.addInputParameter("@tip_doc", SqlDbType.VarChar, strTipDoc)
            gpmDataObj.addInputParameter("@num_doc", SqlDbType.VarChar, strNumDoc)

            ''Ejecucion del procedimiento
            dtSetReturn = gpmDataObj.execDT()

            Return dtSetReturn
        End Function

        Private Function ifIsDBNullReturnNull(ByVal objValidate As Object) As Object
            If (IsDBNull(objValidate)) Then
                Return Nothing
            Else
                Return objValidate
            End If
        End Function

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub
    End Class
End Namespace