Imports System
Imports objComun = HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports objDatosGenerales = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion

Namespace Sophia.HistoriaClinica.DAO
    Public Class DAOTraerInfoPaciente
        Inherits GPMData

#Region "Traer Info Paciente"
        Public Function DAOTraerInfoPaciente(ByVal strTipoDoc As String, ByVal strNumDoc As String) As DataSet
            Dim dtset As New DataSet

            Me.setSQLSentence("DB_TraerInfoPaciente", CommandType.StoredProcedure)
            Me.addInputParameter("strTip_Doc", SqlDbType.VarChar, strTipoDoc)
            Me.addInputParameter("strNum_Doc", SqlDbType.VarChar, strNumDoc)
            dtset = Me.execDS()

            Return dtset
        End Function
#End Region
    End Class

End Namespace
