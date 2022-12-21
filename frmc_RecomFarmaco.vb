Public Class frmc_RecomFarmaco
    Private dt As New DataTable
    Public Sub Mostrar(ByVal dtFarmaco As DataTable)
        dt = dtFarmaco
    End Sub

    Private Sub frmc_RecomFarmaco_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.dtgFarmaco.DataSource = dt
    End Sub
End Class