
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Namespace Sophia.HistoriaClinica.DAO
    Public Class DAOEvolucion
        Inherits GPMData

        Public Function ValidadAdmTrasladada(ByVal objConexion As Conexion, ByVal Cod_pre_sgs As String,
                                                          ByVal Cod_sucur As String, ByVal Tip_Admision As String,
                                                          ByVal Ano_Adm As Integer, ByVal Num_Adm As Double) As String

            Dim stradmisiondes As String = ""

            Me.setSQLSentence("Sp_consultaradmisiondestino", CommandType.StoredProcedure)
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, Cod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, Cod_sucur)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, Tip_Admision)
            Me.addInputParameter("ano_adm", SqlDbType.Int, Ano_Adm)
            Me.addInputParameter("num_adm", SqlDbType.Int, Num_Adm)
            Me.addOutputParameter("tip_admision_des2", SqlDbType.VarChar, 2)
            Me.addOutputParameter("ano_adm_des2", SqlDbType.Int, 0)
            Me.addOutputParameter("num_adm_des2", SqlDbType.Int, 0)

            Me.Exec()

            stradmisiondes = Me.Parameters("tip_admision_des2").Value & "-" & Me.Parameters("ano_adm_des2").Value & "-" & Me.Parameters("num_adm_des2").Value

            Return stradmisiondes

        End Function
    End Class
End Namespace
