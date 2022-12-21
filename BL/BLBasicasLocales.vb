Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion

Namespace Sophia.HistoriaClinica.BL

    ''' -----------------------------------------------------------------------------
    ''' Project	 : HistoriClinica.BL.BLBasicasLocales
    ''' Class	 : Sophia.HistoriaClinica.BL.BLBasicasLocales
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Clase BLBasicasLocales del namespace Sophia.HistoriaClinica.BL
    ''' que es la clase data de HistoriaClinica.BL
    ''' y será usada desde la aplicación WinForms 2005
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[ggarzon]	05/04/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------

    Public Class BLBasicasLocales
        Public Function TraerDatosTablasBasicasLocales(ByVal strCadenaConexion As String, ByVal strTabla As String, _
                                                       ByVal strCampos As String, ByVal strCondicion As String, _
                                                       Optional ByVal strOrder As String = "") As DataTable
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOBasicasLocales

            Return obj.TraerDatosTablasBasicasLocales(strCadenaConexion, strTabla, strCampos, strCondicion, strOrder)
        End Function

    End Class

End Namespace
