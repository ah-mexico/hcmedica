Imports System.Drawing
Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion

Public Class frmConsultaPorNombre

    Private _datosConexion As conexion
    Private Sub frmConsultaPorNombre_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ''Se llama la instancia del objeto singleton que contiene los datos de la conexion
        _datosConexion = Conexion.Instancia()
    End Sub

    Public Function mostrar(ByRef objPaciente As Paciente) As Boolean
        Dim dtpacientes As DataTable

        dtpacientes = New Paciente().BuscarPorNombre(_datosConexion, objPaciente.PrimerNombre, objPaciente.PrimerApellido)

        If dtpacientes.Rows.Count = 0 Then
            Return False
        End If

        If dtpacientes.Rows.Count = 1 Then
            With dtpacientes.Rows(0)
                objPaciente = New Paciente(.Item("Tip_doc").ToString, .Item("num_doc").ToString, _
                                           strPrinom:=.Item("pri_nom").ToString, strSegNom:=.Item("seg_nom").ToString, _
                                           strpriape:=.Item("pri_ape").ToString, strsegape:=.Item("seg_ape").ToString)
                objPaciente.Unificado = .Item("Unificado").ToString
            End With
        Else

            dtgPacientes.AutoGenerateColumns = False
            dtgPacientes.DataSource = dtpacientes

            If Me.ShowDialog() = Windows.Forms.DialogResult.OK Then
                With dtgPacientes.CurrentRow
                    objPaciente = New Paciente(.Cells("tip_doc").Value.ToString, .Cells("num_doc").Value.ToString, _
                                           strPrinom:=.Cells("pri_nom").Value.ToString, strSegNom:=.Cells("seg_nom").Value.ToString, _
                                           strpriape:=.Cells("pri_ape").Value.ToString, strsegape:=.Cells("seg_ape").Value.ToString)
                    objPaciente.Unificado = .Cells("unificado").Value.ToString
                End With
            Else
                objPaciente = New Paciente()
                Return False
            End If
        End If

        'Se consultan tanto el paciente Unificador como los pacientes unificados a este
        Select Case objPaciente.Unificado
            Case "U"   'El paciente es Unificado
                'Se busca el paciente unificador del paciente ingresado y los unificados relacionados con
                'el unificador encontrado
                objPaciente.PacienteUnificador = New Paciente().BuscaUnificador(_datosConexion, objPaciente.NumeroDocumento, objPaciente.NumeroDocumento)
                objPaciente.PacientesUnificados = New Paciente().BuscarUnificados(_datosConexion, objPaciente.PacienteUnificador.TipoDocumento, objPaciente.PacienteUnificador.NumeroDocumento)
            Case "UU"   'El paciente es unificador
                'Se Buscan los pacientes unificados a este unificador
                objPaciente.PacientesUnificados = New Paciente().BuscarUnificados(_datosConexion, objPaciente.TipoDocumento, objPaciente.NumeroDocumento)
        End Select

        Return True
    End Function

End Class