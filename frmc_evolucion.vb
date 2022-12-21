Public Class frmc_evolucion

    Public Sub New(ByVal dtDatos As DataTable)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        dtgEvolucion.DataSource = dtDatos
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Private Sub dtgEvolucion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgEvolucion.Click
        If dtgEvolucion.DataSource Is Nothing Then
            Exit Sub
        Else
            If dtgEvolucion.DataSource.Rows.Count <= 0 Then
                Exit Sub
            End If
        End If
        EditarDatosEvolucion(sender.CurrentRow)
    End Sub
    Private Sub EditarDatosEvolucion(ByVal dr As DataGridViewRow)



        Me.tbDiagnostico.Text = dr.Cells("DiagActual").Value.ToString
        Me.tbSubjetivo.Text = dr.Cells("subjetivo").Value.ToString
        Me.tbParaclinicos.Text = dr.Cells("interpParaclic").Value.ToString
        Me.tbObjetivo.Text = dr.Cells("notas").Value.ToString
        Me.tbPlanManejo.Text = dr.Cells("orden").Value.ToString
        Me.txtNotasIngr.Text = dr.Cells("NotasIngreso").Value.ToString



    End Sub


    Private Sub lnkNota_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkNota.LinkClicked
        ctlPlanRemision.Instancia.tbEvolucion.Text += " " & txtNotasIngr.Text
    End Sub

    Private Sub lnkSubjetivo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkSubjetivo.LinkClicked
        ctlPlanRemision.Instancia.tbEvolucion.Text += " " & tbSubjetivo.Text
    End Sub

    Private Sub lnkObjetivo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkObjetivo.LinkClicked
        ctlPlanRemision.Instancia.tbEvolucion.Text += " " & tbObjetivo.Text
    End Sub

    Private Sub lnkParaclinicos_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkParaclinicos.LinkClicked
        ctlPlanRemision.Instancia.tbEvolucion.Text += " " & tbParaclinicos.Text
    End Sub

    Private Sub lnkPlan_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkPlan.LinkClicked
        ctlPlanRemision.Instancia.tbEvolucion.Text += " " & tbPlanManejo.Text
    End Sub

    Private Sub lnkDiagnostico_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkDiagnostico.LinkClicked
        ctlPlanRemision.Instancia.tbEvolucion.Text += " " & tbDiagnostico.Text
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class