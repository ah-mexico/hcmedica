Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales.Generales
Imports objPaciente = HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente.Paciente

Namespace Sophia.HistoriaClinica.BL
    Public Class BLRptHC_Enf_Med

#Region "BLRptHC_Enf_Med"

#Region "Grabar Auditoria"
        Public Function GrabarAuditoria(ByVal objConexion As objCon, ByVal cod_historia As Integer,
            ByVal cod_pre_sgs As String, ByVal cod_sucur As String, ByVal tip_admision As String,
            ByVal ano_adm As Integer, ByVal num_adm As Integer, ByVal medico As String,
            ByVal estado As String, ByVal obs As String, ByVal ID_programa As Integer) As Long
            Dim obj As New Sophia.HistoriaClinica.DAO.DAORptHC_Enf_Med
            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia
            Dim lError As Long
            lError = obj.GrabarAuditoria(objConexion, cod_historia, cod_pre_sgs, cod_sucur, tip_admision, ano_adm, num_adm, medico, estado, obs, ID_programa)
            Return lError
        End Function
#End Region

#End Region

    End Class
End Namespace

