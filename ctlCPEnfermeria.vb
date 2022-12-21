Imports System.IO
Imports System.Collections.Generic
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.HistoriaBasica
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports HistoriaClinica.wsCuidadoPaliativo

Public Class ctlCPEnfermeria

#Region "Properties"

    Private Shared _Instancia As ctlCPEnfermeria
    Private objGeneral As Generales
    Private objPaciente As Paciente
    Private objConexion As Conexion
    Private objEvolucion As Evolucion
    Private objCpEnfermeria As New Enfermeria
    Private objDAOEnfermeria As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOEnfermeriaCP    
    Private objQxManejaDatos As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAODescripcionQXManejoDeDatos    
    Private objHistoriaBasica As DatosHistoriaBasica
    Private lstCateter As List(Of RegistroCateter)
    Private lstHeridas As List(Of RegistroHerida)
    Private pnlPaliativos As ctlCuidadoPaliativo = Nothing
    Private cadenaFormatoHora As String = "/  /       :"
    'Public ctlInsercion As ctlInsercionCateter = ctlInsercionCateter.Instancia() ---WACHV,10NOV2017, se quita se pasa a gestion de cateter,SEGUN REQUERIMIENTO REQ02
    Public ctlSeguimiento As ctlSeguimientoCateter = ctlSeguimientoCateter.Instancia()
    Public ctlRetiro As ctlRetiroCateter = ctlRetiroCateter.Instancia()
    Public ctlHerida As ctlCPHerida = ctlCPHerida.Instancia()


#End Region

#Region "Instancia de Control"

    Public Shared ReadOnly Property Instancia() As ctlCPEnfermeria
        Get
            If _Instancia Is Nothing Then
                _Instancia = New ctlCPEnfermeria                
            End If
            Return _Instancia
        End Get
    End Property

#End Region

#Region "Events"

    Private Sub ctlCPEnfermeria_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged        
        If Me.Visible Then            
            pnlPaliativos = Me.Parent.Parent
            'pnlPaliativos.Pnlenfermeria.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.EnfermeriaPaliativosOpen
            objGeneral = Generales.Instancia
            objPaciente = Paciente.Instancia
            'pnlCateter.Controls.Add(ctlInsercion)   ---WACHV,10NOV2017, se quita se pasa a gestion de cateter,SEGUN REQUERIMIENTO REQ02
            pnlCateter.Controls.Add(ctlSeguimiento)
            pnlCateter.Controls.Add(ctlRetiro)
            'ctlInsercion.Visible = False ---WACHV,10NOV2017, se quita se pasa a gestion de cateter,SEGUN REQUERIMIENTO REQ02
            ctlSeguimiento.Visible = False
            ctlRetiro.Visible = False
            pnlContHerida.Controls.Add(ctlHerida)
            ctlHerida.Visible = False
            CargarCombos()
            LimpiarCampos()
        Else
            Me.pnlCateter.Controls.Clear()
            pnlContHerida.Controls.Clear()
            If Not IsNothing(pnlPaliativos) Then
                pnlPaliativos = Me.Parent.Parent
                'pnlPaliativos.Pnlenfermeria.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.EnfermeriaPaliativos
            End If

        End If

    End Sub

    Private Sub rbSiAdminMedicamento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSiAdminMedicamento.CheckedChanged, rbNoAdminMedicamento.CheckedChanged
        If rbSiAdminMedicamento.Checked Then
            Me.mskFecHorAdmin.Enabled = True
        Else
            If rbNoAdminMedicamento.Checked Then
                Me.mskFecHorAdmin.Enabled = False
            End If
        End If
    End Sub

    ''' WACHV, 2NOV2017,SE INACTIVA, SEGUN REQUERIMIENTO REQ02
    'Private Sub chkInsercionCateter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    ctlInsercion.Visible = chkInsercionCateter.Checked

    '    If chkSeguimientoCateter.Checked Then
    '        ctlSeguimiento.Visible = True
    '    Else
    '        ctlSeguimiento.Visible = False
    '    End If
    '    If chkRetiroCateter.Checked Then
    '        ctlRetiro.Visible = True
    '    Else
    '        ctlRetiro.Visible = False
    '    End If
    '    pnlPaliativos.pnlContenedor.Height = Me.Height
    '    If ctlInsercion.Visible Then
    '        ctlInsercion.cmbTipoCateterIns.Focus()
    '    End If
    'End Sub
    ''' WACHV, 2NOV2017,SE INACTIVA, SEGUN REQUERIMIENTO REQ02
    'Private Sub chkSeguimientoCateter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    ctlSeguimiento.Visible = chkSeguimientoCateter.Checked

    '    If chkInsercionCateter.Checked Then
    '        ctlInsercion.Visible = True
    '    Else
    '        ctlInsercion.Visible = False
    '    End If
    '    If chkRetiroCateter.Checked Then
    '        ctlRetiro.Visible = True
    '    Else
    '        ctlRetiro.Visible = False
    '    End If
    '    pnlPaliativos.pnlContenedor.Height = Me.Height
    '    If ctlSeguimiento.Visible Then
    '        ctlSeguimiento.mskFecInsercion.Focus()
    '    End If
    'End Sub
    ''' WACHV, 2NOV2017,SE INACTIVA, SEGUN REQUERIMIENTO REQ02
    'Private Sub chkRetiroCateter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    ctlRetiro.Visible = chkRetiroCateter.Checked

    '    If chkInsercionCateter.Checked Then
    '        ctlInsercion.Visible = True
    '    Else
    '        ctlInsercion.Visible = False
    '    End If
    '    If chkSeguimientoCateter.Checked Then
    '        ctlSeguimiento.Visible = True
    '    Else
    '        ctlSeguimiento.Visible = False
    '    End If
    '    pnlPaliativos.pnlContenedor.Height = Me.Height
    '    If ctlRetiro.Visible Then
    '        ctlRetiro.mskFecHorRetiro.Focus()
    '    End If
    'End Sub

    Private Sub rbSiPresentaHerida_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSiPresentaHerida.CheckedChanged
        ctlHerida.Visible = rbSiPresentaHerida.Checked
        pnlPaliativos.pnlContenedor.Height = Me.Height
        If ctlHerida.Visible Then
            ctlHerida.chkListTipoHerida.Focus()
        End If
    End Sub

    Private Sub rbNoPresentaHerida_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbNoPresentaHerida.CheckedChanged
        ctlHerida.Visible = rbSiPresentaHerida.Checked
        If rbNoPresentaHerida.Checked Then
            ctlHerida.Visible = Not rbNoPresentaHerida.Checked
            pnlPaliativos.pnlContenedor.Height = Me.Height
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        'If (Not ValidarCamposEnfermeria()) Then
        '    Exit Sub
        'End If
        GuardaRegistroEnfermeria()
    End Sub

    Private Sub btnTraerRespuesta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTraerRespuesta.Click
        CargarDatosEnfermeria()
    End Sub

    Private Sub btnAgregarMedicamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarMedicamento.Click
        If (Not ValidarCamposMedicamentos()) Then
            Exit Sub
        End If
        GuardarAdminMedicamento()
    End Sub

    Private Sub dgvEvento_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvMedicamentos.UserDeletingRow, dgvHeridasPaciente.UserDeletingRow
        Dim dgvEvento As DataGridView = DirectCast(sender, DataGridView)
        If dgvEvento.RowCount < 1 Then
            Exit Sub
        End If
        If dgvEvento.SelectedRows.Count > 0 Then
            Dim arr(dgvEvento.SelectedRows.Count) As String
            Dim cadenaOpciones As String = String.Empty
            Dim idRegistro As String = String.Empty
            Dim i As Integer = 0
            For Each row As DataGridViewRow In dgvEvento.SelectedRows
                idRegistro = row.Cells(0).Value.ToString()
                If dgvEvento.SelectedRows.Count > 1 Then
                    arr(i) = idRegistro
                    i = i + 1
                End If
                'MessageBox.Show("idRegistro = " & idRegistro)                
            Next
            If dgvEvento.SelectedRows.Count = 1 Then
                cadenaOpciones = idRegistro
            Else
                cadenaOpciones = String.Join("|", arr)
            End If

            Dim idGrilla As String = String.Empty

            Select Case dgvEvento.Name
                Case Me.dgvMedicamentos.Name
                    idGrilla = "M"
                    Exit Select

                    ''' WACHV, 2NOV2017,SE INACTIVA, SEGUN REQUERIMIENTO REQ02
                'Case Me.dgvCateter.Name
                '    idGrilla = "C"
                '    Exit Select

                Case Me.dgvHeridasPaciente.Name
                    idGrilla = "H"
                    Exit Select
            End Select

            Me.objDAOEnfermeria.BorrarGrillaEnfermeria(objPaciente.TipoDocumento, objPaciente.NumeroDocumento, cadenaOpciones, idGrilla)
        End If
    End Sub

    Private Sub btnRespAdmin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRespAdmin.Click
        Dim dt As New DataTable
        dgvMedicamentos.DataSource = Nothing
        dgvMedicamentos.DataSource = objDAOEnfermeria.ConsultaURMedicamentos(objPaciente.TipoDocumento, objPaciente.NumeroDocumento)
        dgvMedicamentos.AutoGenerateColumns = False
    End Sub
    ''' WACHV, 2NOV2017,SE INACTIVA, SEGUN REQUERIMIENTO REQ02
    'Private Sub btnRespCateter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim dt As New DataTable
    '    dgvCateter.DataSource = Nothing
    '    Me.dgvCateter.DataSource = objDAOEnfermeria.ConsultaURCateter(objPaciente.TipoDocumento, objPaciente.NumeroDocumento)
    '    dgvCateter.AutoGenerateColumns = False
    'End Sub

    Private Sub btnRespHerida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRespHerida.Click
        Dim dt As New DataTable
        dgvHeridasPaciente.DataSource = Nothing
        dgvHeridasPaciente.DataSource = objDAOEnfermeria.ConsultarURHeridas(objPaciente.TipoDocumento, objPaciente.NumeroDocumento)
        dgvHeridasPaciente.AutoGenerateColumns = False
    End Sub

#End Region

#Region "Functions"

    Private Sub CargarCombos()
        Dim dt As New DataTable
        Try
            cmbViaAdministracion.ResetText()
            cmbViaAdministracion.BeginUpdate()
            dt = objDAOEnfermeria.CargarCombo(1)

            If dt.Rows.Count = 0 Then
                MsgBox("No existen vías de administración de medicamentos parametrizadas.")
            End If
            cmbViaAdministracion.DataSource = dt

            cmbViaAdministracion.DisplayMember = "descripcion"
            cmbViaAdministracion.ValueMember = "Id"
            cmbViaAdministracion.EndUpdate()
            cmbViaAdministracion.SelectedValue = -1

            dt = Nothing

            cmbUnidadMedida.ResetText()
            cmbUnidadMedida.BeginUpdate()
            dt = BLOrdenes.consultarUnidadMedida(objConexion)

            If dt.Rows.Count = 0 Then
                MsgBox("No existen unidades de medida parametrizadas.")
            End If

            cmbUnidadMedida.DataSource = dt

            cmbUnidadMedida.DisplayMember = "descripcion"
            cmbUnidadMedida.ValueMember = "descripcion"
            cmbUnidadMedida.EndUpdate()
            cmbUnidadMedida.SelectedValue = -1

            'With txtCodigoUM
            '    .NombreCampoBuscado = "descripcion"
            '    .NombreCampoBusqueda = "concentracion"
            '    .ControlTextoEnlace = txtDescripcionUM
            'End With

            'With txtDescripcionUM
            '    .NombreCampoDatos = "descripcion"
            '    .ControlTextoEnlace = txtCodigoUM

            '    Try
            '        .OrigenDeDatos = BLOrdenes.consultarUnidadMedida(objConexion)
            '        .CargarDatosDescripcion()
            '    Catch ex As Exception
            '        MsgBox("Error al consultar la parametrización de unidad de medida.", MsgBoxStyle.Information)
            '    End Try

            'End With

        Catch ex As Exception
            Throw (ex)
        End Try

    End Sub

    Private Sub LimpiarCampos()
        txtNombreProfesional.Text = String.Empty
        txtCuidadoEnfermedad.Text = String.Empty
        txtEvolEnfermeria.Text = String.Empty
        ''' WACHV, 2NOV2017,SE INACTIVA, SEGUN REQUERIMIENTO REQ02
        'chkRetiroCateter.Checked = False
        'chkInsercionCateter.Checked = False
        'chkSeguimientoCateter.Checked = False
        rbNoAdminMedicamento.Checked = False
        rbSiAdminMedicamento.Checked = False
        rbNoPresentaHerida.Checked = False
        rbSiPresentaHerida.Checked = False
        pnlPaliativos.pnlContenedor.Height = Me.Height
        CargarDatosMedicamentos()
        ''' WACHV, 2NOV2017,SE INACTIVA, SEGUN REQUERIMIENTO REQ02
        ''CargarDatosCateter()
        CargarDatosHeridas()
        objCpEnfermeria = New Enfermeria
    End Sub

    Private Sub LimpiarCamposMedicamento()
        txtNombreMedicamento.Text = String.Empty
        txtDosis.Text = String.Empty
        'Me.txtCodigoUM.Text = String.Empty
        'Me.txtDescripcionUM.Text = String.Empty
        cmbUnidadMedida.SelectedValue = -1
        cmbViaAdministracion.SelectedValue = -1
        rbNoAdminMedicamento.Checked = False
        rbSiAdminMedicamento.Checked = False
        mskFecHorAdmin.Text = String.Empty
        txtObsAdmin.Text = String.Empty
        objCpEnfermeria = New Enfermeria
        CargarDatosMedicamentos()
    End Sub

    Private Sub GuardaRegistroEnfermeria()
        Try
            Dim Resultado As Boolean
            Dim strAccionCateter As String = String.Empty

            objCpEnfermeria.Cod_pre_sgs = objGeneral.Prestador
            objCpEnfermeria.Cod_sucur = objGeneral.Sucursal
            objCpEnfermeria.Tip_admision = objPaciente.TipoAdmision

            objCpEnfermeria.Ano_adm = objPaciente.AnoAdmision
            objCpEnfermeria.Num_adm = objPaciente.NumeroAdmision
            objCpEnfermeria.Tip_doc = objPaciente.TipoDocumento
            objCpEnfermeria.Num_doc = objPaciente.NumeroDocumento
            If Me.txtNombreProfesional.Text.Trim().Length > 0 Then
                objCpEnfermeria.Nom_profesional = Me.txtNombreProfesional.Text.Trim()
            End If
            If Me.txtCuidadoEnfermedad.Text.Trim().Length > 0 Then
                objCpEnfermeria.Cuidados_Enfermeria = Me.txtCuidadoEnfermedad.Text.Trim()
            End If
            If Me.txtEvolEnfermeria.Text.Trim().Length > 0 Then
                objCpEnfermeria.Evolucion_Enfermeria = Me.txtEvolEnfermeria.Text.Trim()
            End If

            ''' WACHV, 2NOV2017,SE INACTIVA, SEGUN REQUERIMIENTO REQ02
            'If Me.chkInsercionCateter.Checked Then
            '    If strAccionCateter <> String.Empty Then
            '        strAccionCateter = strAccionCateter & ",I"
            '    Else
            '        strAccionCateter = "I"
            '    End If
            'End If

            ''' WACHV, 2NOV2017,SE INACTIVA, SEGUN REQUERIMIENTO REQ02
            'If Me.chkSeguimientoCateter.Checked Then
            '    If strAccionCateter <> String.Empty Then
            '        strAccionCateter = strAccionCateter & ",S"
            '    Else
            '        strAccionCateter = "S"
            '    End If
            'End If
            'If Me.chkRetiroCateter.Checked Then
            '    If strAccionCateter <> String.Empty Then
            '        strAccionCateter = strAccionCateter & ",R"
            '    Else
            '        strAccionCateter = "R"
            '    End If
            'End If

            objCpEnfermeria.ControlCateter = strAccionCateter
            If Me.rbSiPresentaHerida.Checked Then
                objCpEnfermeria.PresentaHeridas = "SI"
            Else
                objCpEnfermeria.PresentaHeridas = "NO"
            End If

            objCpEnfermeria.Login = objGeneral.Login
            objCpEnfermeria.Obs = String.Empty

            Resultado = Me.objDAOEnfermeria.GuardarRegistroEnfermeria(objCpEnfermeria)

            If Resultado Then
                MessageBox.Show("La información ingresada fue guardada exitosamente. ", "Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LimpiarCampos()
            End If

        Catch ex As Exception
            MessageBox.Show("No se pudo guardar la información ingresada. ", "Historia Clínica", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Function ValidarCamposEnfermeria() As Boolean
        If Me.txtNombreProfesional.Text.Trim().Length = 0 Then
            MsgBox("Debe escribir el nombre de profesional", MsgBoxStyle.Information)
            Return False
        End If
        If Me.txtCuidadoEnfermedad.Text.Trim().Length = 0 Then
            MsgBox("Debe diligenciar el campo de cuidados de enfermería", MsgBoxStyle.Information)
            Return False
        End If
        If Me.txtEvolEnfermeria.Text.Trim().Length = 0 Then
            MsgBox("Debe diligenciar el campo de evolución de enfermería", MsgBoxStyle.Information)
            Return False
        End If
        If Me.rbSiPresentaHerida.Checked = False And Me.rbNoPresentaHerida.Checked = False Then
            MsgBox("Debe indicar si el paciente presenta alguna herida", MsgBoxStyle.Information)
            Return False
        End If
        Return True
    End Function

    Private Function ValidarCamposMedicamentos() As Boolean
        Dim formatoFechaHora As String = "dd/MM/yyyy HH:mm"
        'If Me.txtNombreProfesional.Text.Trim().Length = 0 Then
        '    MsgBox("Debe escribir el nombre de profesional", MsgBoxStyle.Information)
        '    Return False
        'End If
        'If Me.txtNombreMedicamento.Text.Trim().Length = 0 Then
        '    MsgBox("Debe escribir el nombre del medicamento administrado", MsgBoxStyle.Information)
        '    Return False
        'End If
        'If Me.txtDosis.Text.Trim().Length = 0 Then
        '    MsgBox("Debe indicar la dosis suministrada", MsgBoxStyle.Information)
        '    Return False
        'End If
        'If IsNothing(cmbUnidadMedida.SelectedValue) Then
        '    MsgBox("Debe seleccionar la vía de administración del medicamento", MsgBoxStyle.Information)
        '    Return False
        'End If
        'If IsNothing(cmbViaAdministracion.SelectedValue) Then
        '    MsgBox("Debe seleccionar la vía de administración del medicamento", MsgBoxStyle.Information)
        '    Return False
        'End If
        'If (Me.rbSiAdminMedicamento.Checked = False And Me.rbNoAdminMedicamento.Checked = False) Then
        '    MsgBox("Debe indicar si se hizo la administración del medicamento", MsgBoxStyle.Information)
        '    Return False
        'End If        
        'If Me.rbSiAdminMedicamento.Checked Then
        If Me.mskFecHorAdmin.Text.Trim() <> cadenaFormatoHora Then
            Try
                Dim fecha As Date = Date.ParseExact(Me.mskFecHorAdmin.Text.Trim(), formatoFechaHora, System.Globalization.DateTimeFormatInfo.InvariantInfo)
                If fecha > Date.Now Then
                    MsgBox("La fecha y hora de administración es mayor al tiempo actual. Favor revisar", MsgBoxStyle.Information)
                    Return False
                End If
            Catch ex As Exception
                MsgBox("La fecha y hora de administración no es válida. Favor revisar", MsgBoxStyle.Information)
                Return False
            End Try
        End If
        'If Me.txtObsAdmin.Text.Trim().Length = 0 Then
        '    MsgBox("Debe diligenciar las observaciones de administración del medicamento", MsgBoxStyle.Information)
        '    Return False
        'End If
        Return True
    End Function

    Private Sub GuardarAdminMedicamento()
        Try
            Dim Resultado As Boolean

            objCpEnfermeria.Cod_pre_sgs = objGeneral.Prestador
            objCpEnfermeria.Cod_sucur = objGeneral.Sucursal
            objCpEnfermeria.Tip_admision = objPaciente.TipoAdmision

            objCpEnfermeria.Ano_adm = objPaciente.AnoAdmision
            objCpEnfermeria.Num_adm = objPaciente.NumeroAdmision
            objCpEnfermeria.Tip_doc = objPaciente.TipoDocumento
            objCpEnfermeria.Num_doc = objPaciente.NumeroDocumento

            If Me.txtNombreProfesional.Text.Trim().Length > 0 Then
                objCpEnfermeria.Nom_profesional = Me.txtNombreProfesional.Text.Trim()
            End If
            If Me.txtNombreMedicamento.Text.Trim().Length > 0 Then
                objCpEnfermeria.Nom_medicamento = Me.txtNombreMedicamento.Text.Trim()
            End If
            If Me.txtDosis.Text.Trim().Length > 0 Then
                objCpEnfermeria.Dosis = Me.txtDosis.Text.Trim()
            End If
            If Not IsNothing(cmbUnidadMedida.SelectedValue) Then
                objCpEnfermeria.Dosis = objCpEnfermeria.Dosis & "  " & Me.cmbUnidadMedida.SelectedValue.Trim()
            End If
            If Not IsNothing(cmbViaAdministracion.SelectedValue) Then
                objCpEnfermeria.Via_Administracion = Convert.ToInt32(Me.cmbViaAdministracion.SelectedValue)
            End If

            If Me.rbSiAdminMedicamento.Checked Then
                objCpEnfermeria.EsAdministrado = "SI"
            End If
            If Me.rbNoAdminMedicamento.Checked Then
                objCpEnfermeria.EsAdministrado = "NO"
            End If
            If mskFecHorAdmin.Text.Trim() <> cadenaFormatoHora Then
                objCpEnfermeria.Fec_Hora_Administracion = mskFecHorAdmin.Text.Trim()
            End If
            If Me.txtObsAdmin.Text.Trim().Length > 0 Then
                objCpEnfermeria.Obs_Administracion = txtObsAdmin.Text().Trim()
            End If

            objCpEnfermeria.Login = objGeneral.Login
            objCpEnfermeria.Obs = String.Empty

            Resultado = Me.objDAOEnfermeria.GuardarRegistroMedicamentos(objCpEnfermeria)

            If Resultado Then
                MessageBox.Show("La información de medicamento fue guardada exitosamente. ", "Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LimpiarCamposMedicamento()
            End If

        Catch ex As Exception
            MessageBox.Show("No se pudo guardar la información ingresada. ", "Historia Clínica", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub CargarCampos()
        Me.txtNombreProfesional.Text = objCpEnfermeria.Nom_profesional        
        Me.txtCuidadoEnfermedad.Text = objCpEnfermeria.Cuidados_Enfermeria
        Me.txtEvolEnfermeria.Text = objCpEnfermeria.Evolucion_Enfermeria

        If objCpEnfermeria.PresentaHeridas.ToString = "92901" Then
            rbSiPresentaHerida.Checked = True
        End If
        If objCpEnfermeria.PresentaHeridas.ToString = "92902" Then
            rbNoPresentaHerida.Checked = True
        End If

        'Me.txtNombreMedicamento.Text = objCpEnfermeria.Nom_medicamento
        'Me.txtDosis.Text = objCpEnfermeria.Dosis.Split("").GetValue(0).ToString()
        ''Me.txtDescripcionUM.Text = objCpEnfermeria.Dosis.Split("  ").GetValue(1).ToString()
        'Me.cmbUnidadMedida.SelectedValue = objCpEnfermeria.Dosis.Split("  ").GetValue(1).ToString()
        'Me.cmbViaAdministracion.SelectedValue = objCpEnfermeria.Via_Administracion
        'If objCpEnfermeria.EsAdministrado = "SI" Then
        '    Me.rbSiAdminMedicamento.Checked = True
        '    Me.mskFecHorAdmin.Text = objCpEnfermeria.Fec_Hora_Administracion
        'Else
        '    Me.rbSiAdminMedicamento.Checked = False
        '    Me.rbNoAdminMedicamento.Checked = True
        'End If
        'Me.txtObsAdmin.Text = objCpEnfermeria.Obs_Administracion
    End Sub

    Private Sub CargarDatosEnfermeria()
        Try
            objCpEnfermeria = objCpEnfermeria.CargarRegistroEnfermeria(objGeneral, objPaciente)
            CargarCampos()
        Catch ex As Exception
            MsgBox("No se puede cargar la información propuesta. Favor contactar con el administrador", MsgBoxStyle.Critical)
            'Throw (ex)
        End Try
    End Sub

    Private Sub CargarDatosMedicamentos()        
        dgvMedicamentos.DataSource = Nothing
        dgvMedicamentos.DataSource = objDAOEnfermeria.ConsultarRegistrosMedicamentos(objPaciente.TipoDocumento, objPaciente.NumeroDocumento)
        dgvMedicamentos.AutoGenerateColumns = False
    End Sub
    ''' WACHV, 2NOV2017,SE INACTIVA, SEGUN REQUERIMIENTO REQ02
    'Public Sub CargarDatosCateter()
    '    dgvCateter.DataSource = Nothing
    '    Me.dgvCateter.DataSource = objDAOEnfermeria.ConsultarRegistrosCateter(objPaciente.TipoDocumento, objPaciente.NumeroDocumento)
    '    dgvCateter.AutoGenerateColumns = False
    'End Sub

    Public Sub CargarDatosHeridas()        
        dgvHeridasPaciente.DataSource = Nothing
        dgvHeridasPaciente.DataSource = objDAOEnfermeria.ConsultarRegistrosHeridas(objPaciente.TipoDocumento, objPaciente.NumeroDocumento)
        dgvHeridasPaciente.AutoGenerateColumns = False
    End Sub

#End Region

    
    
    
End Class

