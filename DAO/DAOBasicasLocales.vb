
Namespace Sophia.HistoriaClinica.DAO

#Region "DAOBasicasLocales"
    ''' -----------------------------------------------------------------------------
    ''' Project	 : HistoriClinica.DAO.DAOBasicasLocales
    ''' Class	 : Sophia.HistoriaClinica.DAO.DAOBasicasLocales
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Clase DAOBasicasLocales del namespace Sophia.HistoriaClinica.DAO.DAOBasicasLocales
    ''' que es la clase data de HistoriaClinica.DAO
    ''' y será usada desde este namespace para el acceso a los datos
    ''' se agrega de la application block Data.SqlHelper
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[ggarzon]	05/04/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------

    Public Class DAOBasicasLocales
        Inherits GPMData


        Public Function TraerDatosTablasBasicasLocales(ByVal strCadenaConexion As String, ByVal strTabla As String, _
                                                       ByVal strCampos As String, ByVal strCondicion As String, _
                                                       Optional ByVal strOrder As String = "") As DataTable

            Dim dtTable As New DataTable
            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007

            '' ''Dim cnn As New OleDbConnection(strCadenaConexion)
            '' ''Dim cmd As New OleDbCommand
            '' ''Dim dtReaderOle As OleDbDataReader

            If strCondicion.Trim.Length > 0 Then
                strCondicion = " WHERE " & strCondicion
            End If

            If strOrder.Trim.Length > 0 Then
                strCondicion += " ORDER BY " & strOrder
            End If


            '' ''cmd.CommandText = "SELECT " & strCampos & " FROM " & strTabla & strCondicion
            '' ''cnn.Open()
            '' ''cmd.Connection = cnn
            '' ''dtReaderOle = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            '' ''dtTable.Load(dtReaderOle)

            '' ''dtReaderOle.Close()
            '' ''dtReaderOle.Dispose()
            '' ''cmd.Dispose()
            Me.setSQLSentence("SELECT " & strCampos & " FROM " & strTabla & strCondicion, CommandType.Text)
            dtTable.Load(Me.ExecRdr())

            Return dtTable

        End Function

    End Class

#End Region

End Namespace