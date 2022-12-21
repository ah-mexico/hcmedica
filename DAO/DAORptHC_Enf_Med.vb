Imports System
Imports objComun = HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports objDatosGenerales = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion

Namespace Sophia.HistoriaClinica.DAO
    Public Class DAORptHC_Enf_Med
        Inherits GPMData

#Region "GrabarAuditoria"
        Public Function GrabarAuditoria(ByVal objConexion As objCon, ByVal cod_historia As Integer,
            ByVal cod_pre_sgs As String, ByVal cod_sucur As String, ByVal tip_admision As String,
            ByVal ano_adm As Integer, ByVal num_adm As Integer, ByVal medico As String,
            ByVal estado As String, ByVal obs As String, ByVal ID_programa As Integer) As Long
            Dim lError As Long
            Me.setSQLSentence("hc_ingresatablaAuditAperturaHC", CommandType.StoredProcedure)
            Me.addInputParameter("@cod_historia", SqlDbType.Int, cod_historia)
            Me.addInputParameter("@cod_pre_sgs", SqlDbType.VarChar, cod_pre_sgs)
            Me.addInputParameter("@cod_sucur", SqlDbType.VarChar, cod_sucur)
            Me.addInputParameter("@tip_admision", SqlDbType.VarChar, tip_admision)
            Me.addInputParameter("@ano_adm", SqlDbType.Int, ano_adm)
            Me.addInputParameter("@num_adm", SqlDbType.Int, num_adm)
            Me.addInputParameter("@medico", SqlDbType.VarChar, medico)
            Me.addInputParameter("@estado", SqlDbType.VarChar, estado)
            Me.addInputParameter("@obs", SqlDbType.VarChar, obs)
            Me.addInputParameter("@ID_programa", SqlDbType.Int, ID_programa)
            Me.addOutputParameter("@Error", SqlDbType.Int)
            Me.Exec()
            lError = Val(Me.Parameters("Error").Value)
            Return lError
        End Function
#End Region
    End Class

End Namespace
