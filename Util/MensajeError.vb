Namespace Sophia.HistoriaClinica.UI.Escritrio



    Public Class MensajeError

        Public Shared Sub Mensaje(ByVal codigo As Integer)

            MessageBox.Show("No se pudo completar la actividad requerida.", "Sophia", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0)

        End Sub

    End Class



End Namespace
