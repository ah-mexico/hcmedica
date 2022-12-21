Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion

Namespace Sophia.HistoriaClinica.DAO
    Public Class DAOFechas
        Inherits GPMData

#Region "consultarHoraDif"
        Public Function consultarHoraDif(ByVal objConexion As Conexion) As Integer
            Dim iHoraDif As String
            Me.setSQLSentence("select num_calibre as num_calibre from hcenfcalibre (nolock) where cod_vianser = 'T'", CommandType.Text)

            iHoraDif = Me.executeScalar()

            Return CInt(iHoraDif)
        End Function
#End Region

    End Class
End Namespace
