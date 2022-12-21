
Public Class Egreso
    Inherits System.Windows.Forms.UserControl

    Private Sub Egreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim blhc As New Sophia.HistoriaClinica.Egresos.Bl.BLEgresos
        Try
            Me.dgLista.DataSource = blhc.ConsultarEgresosPaciente("envio")
        Catch ex As Exception
            MsgBox("Error en" + ex.Message)
        End Try
    End Sub

    Private Sub blCondicion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles blCondicion.Click

    End Sub

    Private Sub gbDatosAdicion_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gbDatosAdicion.Enter

    End Sub
End Class
