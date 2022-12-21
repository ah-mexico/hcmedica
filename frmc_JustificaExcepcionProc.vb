Imports System.Windows.Forms
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales.Generales


Public Class frmc_JustificaExcepcionProc
    Public strJustificacion As String = ""

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel

        txtJustificacion.Text = String.Empty
        Me.Close()
    End Sub

    
    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Me.strJustificacion = txtJustificacion.Text
        Me.Close()
    End Sub
End Class
