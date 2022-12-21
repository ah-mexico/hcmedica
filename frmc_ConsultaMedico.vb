Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
''Claudia Garay
''Acreditacion Medico Residente
''2011-04-05
Public Class frmc_ConsultaMedico
    Private Shared _Instancia As frmc_ConsultaMedico
    Private objConexion As Conexion
    Public ValidaSeleccion As Boolean
    Private objEvolucion As Evolucion
    Private objGenerales As Generales
    Private objPaciente As Paciente

    Public Shared ReadOnly Property Instancia() As frmc_ConsultaMedico
        Get
            If _Instancia Is Nothing Then
                _Instancia = New frmc_ConsultaMedico
            End If
            Return _Instancia
        End Get

    End Property

    Private Sub cmdbuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdbuscar.Click

        If txtNombre.Text = String.Empty And txtApellido.Text = String.Empty Then
            MsgBox("No existen parametros de busqueda", MsgBoxStyle.Information)
            Exit Sub
        End If

        consultarNombreMedico(txtNombre.Text, txtApellido.Text)
    End Sub

    Private Sub consultarNombreMedico(ByVal strNombre As String, ByVal strApellido As String)
        Dim objDao As New DAOHistoriaBasica
        Dim dtdatos As New DataTable
        objConexion = Conexion.Instancia

        If strNombre <> "" Then
            strNombre = "%" & strNombre & strApellido & "%"
        End If

        'If strApellido <> "" Then
        '    strApellido = "%" & strApellido & "%"
        'End If

        dtdatos = objDao.ConsultarDatosMedico(objConexion, strNombre, strApellido, "", 1)
        If dtdatos.Rows.Count = 0 Then
            MsgBox("No existen datos para esta consulta", MsgBoxStyle.Information)
        End If

        dtgmedico.DataSource = dtdatos




    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Me.Close()
        ValidaSeleccion = 0
    End Sub

    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        objConexion = Conexion.Instancia
        objEvolucion = Evolucion.Instancia
        If dtgmedico.CurrentRow Is Nothing Then
            MsgBox("Seleccione un Registro de la Lista", MsgBoxStyle.Information)
            Exit Sub
        End If
        objEvolucion.MedicoAcompanaResidente = dtgmedico.CurrentRow.Cells("medico").Value
        GuardarDatosResidente(objConexion, objEvolucion.MedicoAcompanaResidente)
        Me.Close()
        ValidaSeleccion = 1
    End Sub
    Private Sub GuardarDatosResidente(ByVal objconexion As Conexion, ByVal strMedicoAcompa As String)
        Dim lError As Long
        Dim objDao As New DAOHistoriaBasica
        objGenerales = Generales.Instancia
        objPaciente = Paciente.Instancia
        Try
            lError = objDao.AlmacenaMedicoResidente(objconexion, objGenerales.Prestador, objGenerales.Sucursal, objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision, objPaciente.TipoDocumento, objPaciente.NumeroDocumento, strMedicoAcompa, objGenerales.Login, objGenerales.Login, "")

            If lError <> 0 Then
                MsgBox("Error al guardar los datos del residente", MsgBoxStyle.Critical, "Medico Residente")
            End If
        Catch ex As Exception
            MsgBox("Error al guardar los datos del residente" & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


End Class