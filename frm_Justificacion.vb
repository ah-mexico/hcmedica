Imports HistoriaClinica.Sophia.HistoriaClinica
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion

Public Class frm_Justificacion


    ''' <summary>
    ''' Datos necesarios para establecer una conexion a la base
    ''' de Datos. Dentro de estos datos esta el nombre del servidor, 
    ''' el nombre de la base de datos, el usuario y el password.
    ''' </summary>
    ''' <remarks></remarks>
    Private datosConexion As Conexion
    Public descmotivoSuspension As String
    Public idmotivosuspension As String
    Private filaseleccionada As Integer
    Private datagrid As DataGridView



    Public Sub CargarMotivoSuspensionMedicamentos()
        With txtmotSus
            .DataSource = BLConciliacionMedicamentos.consultarMotivoSuspensionMedicamentos(datosConexion)
            .DisplayMember = "descripcion"
            .ValueMember = "motivo"

            Try
                '.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                '.AutoCompleteCustomSource = CreateCustomSourceAutoComplete(.DataSource)
                '.AutoCompleteSource = AutoCompleteSource.CustomSource
                .ResetText()
                .SelectedValue = vbNull
            Catch ex As Exception
                MsgBox("Error al consultar la parametrización de mmotivo de suspension de medicamentos.", MsgBoxStyle.Information)
            End Try
        End With
    End Sub

    Private Sub frm_Justificacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        datosConexion = Conexion.Instancia()
        Me.CargarMotivoSuspensionMedicamentos()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        If txtmotSus.SelectedValue = Nothing Then
            MsgBox("Falta información en campo obligatorio")
            txtmotSus.BackColor = Color.LightPink

            txtmotSus.Focus()

        Else

            idmotivosuspension = txtmotSus.SelectedValue.ToString()
            descmotivoSuspension = txtmotSus.Text.ToString()

            Me.Close()
        End If


    End Sub


End Class