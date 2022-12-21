Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes.FuncionesGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales.Generales

Public Class Frm_IdenticadoresRiesgoHistorico
    Private objConexion As Conexion
    Private IdHistoria As Int64
    Private datosPaciente As Paciente
    Public Sub Mostrar()

        Me.ShowDialog()

    End Sub

    Private Sub Frm_IdenticadoresRiesgoHistorico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim objBl As New Sophia.HistoriaClinica.BL.BLFactoresRiesgo
            Dim _resultado As New DataTable

            datosPaciente = Paciente.Instancia()
            IdHistoria = datosPaciente.CodHistoria


            _resultado = objBl.ConsultaHitorico(objConexion, IdHistoria)

            If _resultado.Rows.Count < 1 Then
                MsgBox("No se encontraron identificadores de riesgo en el histórico ", MsgBoxStyle.Information)
                Me.Close()
            End If

            dtgHistorico.DataSource = _resultado

            Me.dtgHistorico.DefaultCellStyle.WrapMode = DataGridViewTriState.True

            Me.dtgHistorico.Columns(0).Visible = False
            Me.dtgHistorico.Columns(1).Width = 180
            Me.dtgHistorico.Columns(2).Width = 130
            Me.dtgHistorico.Columns(3).Width = 200
            Me.dtgHistorico.Columns(4).Width = 200
            Me.dtgHistorico.Columns(5).Width = 200
            Me.dtgHistorico.Columns(6).Width = 130
            Me.dtgHistorico.Columns(7).Width = 200
            Me.dtgHistorico.Columns(8).Width = 200

            Dim aux As String = Nothing

            For x As Integer = 0 To dtgHistorico.RowCount - 1
                aux = dtgHistorico.Rows(x).Cells(6).Value.ToString
                If aux <> "" Then
                    Me.dtgHistorico.Rows(x).Cells(0).Style.ForeColor = Color.Gray
                    Me.dtgHistorico.Rows(x).Cells(1).Style.ForeColor = Color.Gray
                    Me.dtgHistorico.Rows(x).Cells(2).Style.ForeColor = Color.Gray
                    Me.dtgHistorico.Rows(x).Cells(3).Style.ForeColor = Color.Gray
                    Me.dtgHistorico.Rows(x).Cells(4).Style.ForeColor = Color.Gray
                    Me.dtgHistorico.Rows(x).Cells(5).Style.ForeColor = Color.Gray
                    Me.dtgHistorico.Rows(x).Cells(6).Style.ForeColor = Color.Gray
                    Me.dtgHistorico.Rows(x).Cells(7).Style.ForeColor = Color.Gray
                    Me.dtgHistorico.Rows(x).Cells(8).Style.ForeColor = Color.Gray
                    Me.dtgHistorico.Rows(x).Cells(9).Style.ForeColor = Color.Gray


                End If
                aux = Nothing
            Next

        Catch ex As Exception
            MsgBox("error al consultar el hístorico factor de riesgo : " + ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class