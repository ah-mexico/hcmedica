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

Public Class ctlCPAspectosSociales

#Region "Properties"

    Private Shared _Instancia As ctlCPAspectosSociales
    Private objGeneral As Generales
    Private objPaciente As Paciente
    Private objConexion As Conexion
    Private objEvolucion As Evolucion
    Private objCpAspectosSOciales As AspectosSociales
    Private objDACPAspectosSociales As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOCuidadosPaliativos
    Private objDACPComposicionFamiliar As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOCuidadosPaliativos
    Private objQxManejaDatos As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAODescripcionQXManejoDeDatos
    Private strCirujanoInvitado As String = ""
    Private strClasifiDiagn As String = ""
    Private objHistoriaBasica As DatosHistoriaBasica
    Private lstFamiliares As List(Of ComposicionFamiliar)
    Private oFamiliar As ComposicionFamiliar
    Private bsFamiliares As BindingSource
    Private index As Integer = -1
#End Region

#Region "Instancia de Control"

    Public Shared ReadOnly Property Instancia() As ctlCPAspectosSociales
        Get
            If _Instancia Is Nothing Then
                _Instancia = New ctlCPAspectosSociales
            End If
            Return _Instancia
        End Get
    End Property

#End Region

#Region "Events"

    Private Sub ctlCPAspectosSociales_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        Try
            If Me.Visible Then
                objGeneral = Generales.Instancia
                objPaciente = Paciente.Instancia
                CargarCombos()
                loadComposicionFamiliar(New ComposicionFamiliar)
                loadAspectosSociales(New AspectosSociales)
                rbtSiTrabajoEstable.Checked = False
                rbtNoTrabajoEstable.Checked = False
                rbtSiTieneHijos.Checked = False
                rbtNoTieneHijos.Checked = False
                oFamiliar = New ComposicionFamiliar
                bsFamiliares = New BindingSource

                'consultar Familiar
                oFamiliar.tip_doc = objPaciente.TipoDocumento
                oFamiliar.Num_doc = objPaciente.NumeroDocumento
                oFamiliar.cod_pre_sgs = objGeneral.Prestador

                oFamiliar.cod_sucur = objGeneral.Sucursal
                oFamiliar.tip_admision = objPaciente.TipoAdmision
                oFamiliar.ano_adm = objPaciente.AnoAdmision
                oFamiliar.num_adm = objPaciente.NumeroAdmision

                Me.loadFamiliares(oFamiliar)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ctlCPAspectosSociales_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'dtgFamiliar.AllowUserToDeleteRows = True
        Try
            If Me.Visible Then
                objGeneral = Generales.Instancia
                objPaciente = Paciente.Instancia
                CargarCombos()
                loadComposicionFamiliar(New ComposicionFamiliar)
                loadAspectosSociales(New AspectosSociales)
                rbtSiTrabajoEstable.Checked = False
                rbtNoTrabajoEstable.Checked = False
                rbtSiTieneHijos.Checked = False
                rbtNoTieneHijos.Checked = False
                oFamiliar = New ComposicionFamiliar
                bsFamiliares = New BindingSource

                'consultar Familiar
                oFamiliar.tip_doc = objPaciente.TipoDocumento
                oFamiliar.Num_doc = objPaciente.NumeroDocumento
                oFamiliar.cod_pre_sgs = objGeneral.Prestador

                oFamiliar.cod_sucur = objGeneral.Sucursal
                oFamiliar.tip_admision = objPaciente.TipoAdmision
                oFamiliar.ano_adm = objPaciente.AnoAdmision
                oFamiliar.num_adm = objPaciente.NumeroAdmision

                Me.loadFamiliares(oFamiliar)

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            Dim Resultado As String
            Dim oAspectosSociales As New AspectosSociales()

            Try
                For Each fam As ComposicionFamiliar In lstFamiliares
                    If fam.cod_pre_sgs = objGeneral.Prestador And _
                        fam.cod_sucur = objGeneral.Sucursal And fam.tip_admision = objPaciente.TipoAdmision And _
                        fam.ano_adm = objPaciente.AnoAdmision And fam.num_adm = objPaciente.NumeroAdmision Then
                        fam.IdPariente = fam.IdPariente
                    Else
                        fam.IdPariente = Nothing
                        fam.cod_pre_sgs = objGeneral.Prestador
                        fam.cod_sucur = objGeneral.Sucursal
                        fam.tip_admision = objPaciente.TipoAdmision

                        fam.ano_adm = objPaciente.AnoAdmision
                        fam.num_adm = objPaciente.NumeroAdmision
                    End If
                    fam.login = objGeneral.Login

                    Resultado = oFamiliar.GuardarFamiliar(fam)
                Next
            Catch ex As Exception
                'Throw New Exception("Hubo un error al almacenar los Familiares")
                MessageBox.Show("No se pudo guardar la información ingresada de los Familiares. ", "Historia Clínica", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
            End Try

            oAspectosSociales.cod_pre_sgs = objGeneral.Prestador
            oAspectosSociales.cod_sucur = objGeneral.Sucursal
            oAspectosSociales.tip_admision = objPaciente.TipoAdmision

            oAspectosSociales.ano_adm = objPaciente.AnoAdmision
            oAspectosSociales.num_adm = objPaciente.NumeroAdmision
            oAspectosSociales.tip_doc = objPaciente.TipoDocumento
            oAspectosSociales.Num_doc = objPaciente.NumeroDocumento

            oAspectosSociales.ConQuienVive = cmbConvivencia.SelectedValue
            oAspectosSociales.TipoDeVivienda = cmbTipoVivienda.SelectedValue
            oAspectosSociales.TenenciaDeLaVivienda = cmbTenencia.SelectedValue

            oAspectosSociales.EstratoDeLaVivienda = cmbEstrato.SelectedValue
            oAspectosSociales.NivelEscolaridad = cmbNivelEducativo.SelectedValue
            oAspectosSociales.Ocupacion = cmbOcupacion.SelectedValue

            If rbtSiTrabajoEstable.Checked Then
                oAspectosSociales.CuentaConUnTrabajoEstable = 1
            End If
            If rbtNoTrabajoEstable.Checked Then
                oAspectosSociales.CuentaConUnTrabajoEstable = 2
            End If

            oAspectosSociales.Ingresos = cmbNivelIngresos.SelectedValue
            oAspectosSociales.CondicionDelPadre = cmbCondicionPadre.SelectedValue
            oAspectosSociales.CondicionDeLaMadre = cmbCondicionMadre.SelectedValue

            oAspectosSociales.NumeroDeHermanos = IIf(txtNumeroHermanos.Text = String.Empty, 0, txtNumeroHermanos.Text)
            oAspectosSociales.Lugar = IIf(txtLugarPaciente.Text = String.Empty, 0, txtLugarPaciente.Text)

            If rbtSiTieneHijos.Checked Then
                oAspectosSociales.TieneHijos = 1
            End If
            If rbtNoTieneHijos.Checked Then
                oAspectosSociales.TieneHijos = 2
            End If

            oAspectosSociales.TipoDeFamilia = cmbTipoFamilia.SelectedValue
            oAspectosSociales.NumeroDeIntegrantesDeLaFamilia = IIf(txtNumeroIntegrantes.Text = String.Empty, 0, txtNumeroIntegrantes.Text)
            oAspectosSociales.PersonasACargo = IIf(txtPersonasCargo.Text = String.Empty, 0, txtPersonasCargo.Text)

            oAspectosSociales.NombreDelCuidador = txtNombreCuidador.Text
            oAspectosSociales.TipoDeDocumentoDelCuidador = cmbTipodocumento.SelectedValue
            oAspectosSociales.NumeroDeDocumentoDelCuidador = txtDocumento.Text
            'oAspectosSociales.NumeroDeDocumentoDelCuidador = IIf(txtDocumento.Text = String.Empty, 0, txtDocumento.Text)

            oAspectosSociales.ParentescoDelCuidador = cmbParentescoCuidador.SelectedValue
            oAspectosSociales.DireccionDelCuidador = txtDireccionCuidador.Text
            oAspectosSociales.EscolaridadDelCuidador = cmbNivEduCuidador.SelectedValue

            oAspectosSociales.OcupacionDelCuidador = cmbOcupacionCuidador.SelectedValue
            oAspectosSociales.EstadoCivilDelCuidador = cmbEstadoCivil.SelectedValue
            oAspectosSociales.PlanDeIntervencion = txtPlanIntervencion.Text

            oAspectosSociales.ProblemasIdentificados = txtProblemasIdentificados.Text
            oAspectosSociales.login = objGeneral.Login
            oAspectosSociales.obs = String.Empty

            Resultado = oAspectosSociales.GuardarAspectoSocial(oAspectosSociales)

            If Resultado = String.Empty Then
                MessageBox.Show("La información ingresada fue guardada exitosamente. ", "Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Information)
                loadAspectosSociales(New AspectosSociales)
            End If
            index = -1
        Catch ex As Exception
            MessageBox.Show("No se pudo guardar la información ingresada. ", "Historia Clínica", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub lnkNuevo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkNuevo.LinkClicked
        Try
            index = -1
            loadComposicionFamiliar(New ComposicionFamiliar)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAgregarFamiliar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarFamiliar.Click
        Try
            If index = -1 Then
                'oFamiliar.IdPariente = lstFamiliares.Count + 1

                oFamiliar.tip_doc = objPaciente.TipoDocumento
                oFamiliar.Num_doc = objPaciente.NumeroDocumento
                oFamiliar.NombreDelIntegranteDeLaFamilia = txtNombreFamiliar.Text

                oFamiliar.EdadDelIntegranteDeLaFamilia = txtEdadFamiliar.Text
                oFamiliar.ParentescoDelIntegranteDeLaFamilia = cmbParentesco.SelectedValue
                oFamiliar.dscParentescoDelIntegranteDeLaFamilia = cmbParentesco.Text

                oFamiliar.OcupacionDelIntegranteDeLaFamilia = cmbOcupacionFam.SelectedValue
                oFamiliar.dscOcupacionDelIntegranteDeLaFamilia = cmbOcupacionFam.Text
                oFamiliar.cod_pre_sgs = objGeneral.Prestador

                oFamiliar.cod_sucur = objGeneral.Sucursal
                oFamiliar.tip_admision = objPaciente.TipoAdmision
                oFamiliar.ano_adm = objPaciente.AnoAdmision

                oFamiliar.num_adm = objPaciente.NumeroAdmision
                oFamiliar.login = objGeneral.Login
                oFamiliar.obs = String.Empty


                lstFamiliares.Add(oFamiliar)

                If lstFamiliares.Count > 0 Then
                    bsFamiliares = New BindingSource
                    dtgFamiliar.AutoGenerateColumns = False
                    bsFamiliares.DataSource = lstFamiliares
                    dtgFamiliar.DataSource = bsFamiliares
                    dtgFamiliar.Refresh()
                    loadComposicionFamiliar(New ComposicionFamiliar)
                Else
                    dtgFamiliar.DataSource = Nothing
                End If
            Else
                Dim newDataRow As DataGridViewRow

                newDataRow = dtgFamiliar.Rows(index)

                newDataRow.Cells("IdPariente").Value = oFamiliar.IdPariente
                newDataRow.Cells("tip_doc").Value = objPaciente.TipoDocumento
                newDataRow.Cells("Num_doc").Value = objPaciente.NumeroDocumento

                newDataRow.Cells("NombreDelIntegranteDeLaFamilia").Value = txtNombreFamiliar.Text
                newDataRow.Cells("ParentescoDelIntegranteDeLaFamilia").Value = cmbParentesco.SelectedValue
                newDataRow.Cells("dscParentescoDelIntegranteDeLaFamilia").Value = cmbParentesco.Text

                newDataRow.Cells("EdadDelIntegranteDeLaFamilia").Value = txtEdadFamiliar.Text
                newDataRow.Cells("OcupacionDelIntegranteDeLaFamilia").Value = cmbOcupacionFam.SelectedValue
                newDataRow.Cells("dscOcupacionDelIntegranteDeLaFamilia").Value = cmbOcupacionFam.Text

            End If
            index = -1

        Catch ex As Exception
            MessageBox.Show("No se pudo guardar la información ingresada. ", "Historia Clínica", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

        End Try
    End Sub

    Private Sub txtOcupacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOcupacion.TextChanged
        Try
            Dim Index As Integer
            If txtOcupacion.Text.Length > 3 Then
                Index = cmbOcupacion.FindString(txtOcupacion.Text)
                cmbOcupacion.SelectedIndex = Index
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtCodOcupacionFam_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodOcupacionFam.TextChanged
        Try
            Dim Index As Integer
            If txtCodOcupacionFam.Text.Length > 3 Then
                Index = cmbOcupacionFam.FindString(txtCodOcupacionFam.Text)
                cmbOcupacionFam.SelectedIndex = Index
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtOcupacionCuidador_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOcupacionCuidador.TextChanged
        Try
            Dim Index As Integer
            If txtOcupacionCuidador.Text.Length > 3 Then
                Index = cmbOcupacionCuidador.FindString(txtOcupacionCuidador.Text)
                cmbOcupacionCuidador.SelectedIndex = Index
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtgFamiliar_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtgFamiliar.DoubleClick
        Try
            Dim IdPariente As String = dtgFamiliar.CurrentRow.Cells("IdPariente").Value
            index = dtgFamiliar.CurrentRow.Index

            If IdPariente <> "" Then
                oFamiliar.IdPariente = dtgFamiliar.CurrentRow.Cells("IdPariente").Value
                oFamiliar.tip_doc = dtgFamiliar.CurrentRow.Cells("tip_doc").Value
                oFamiliar.Num_doc = dtgFamiliar.CurrentRow.Cells("Num_doc").Value
                oFamiliar.NombreDelIntegranteDeLaFamilia = dtgFamiliar.CurrentRow.Cells("NombreDelIntegranteDeLaFamilia").Value
                oFamiliar.EdadDelIntegranteDeLaFamilia = dtgFamiliar.CurrentRow.Cells("EdadDelIntegranteDeLaFamilia").Value
                oFamiliar.ParentescoDelIntegranteDeLaFamilia = dtgFamiliar.CurrentRow.Cells("ParentescoDelIntegranteDeLaFamilia").Value
                oFamiliar.dscParentescoDelIntegranteDeLaFamilia = dtgFamiliar.CurrentRow.Cells("dscParentescoDelIntegranteDeLaFamilia").Value
                oFamiliar.OcupacionDelIntegranteDeLaFamilia = dtgFamiliar.CurrentRow.Cells("OcupacionDelIntegranteDeLaFamilia").Value
                oFamiliar.dscOcupacionDelIntegranteDeLaFamilia = dtgFamiliar.CurrentRow.Cells("dscOcupacionDelIntegranteDeLaFamilia").Value
                loadComposicionFamiliar(oFamiliar)
                '                lstFamiliares.RemoveAll(AddressOf EliminarFamiliares)
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub dtgFamiliar_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgFamiliar.CellClick
    '    Try
    '        Dim IdPariente As String = dtgFamiliar.Rows(e.RowIndex).Cells("IdPariente").Value

    '        If IdPariente <> "" Then
    '            oFamiliar.IdPariente = dtgFamiliar.Rows(e.RowIndex).Cells("IdPariente").Value
    '            oFamiliar.tip_doc = dtgFamiliar.Rows(e.RowIndex).Cells("tip_doc").Value
    '            oFamiliar.Num_doc = dtgFamiliar.Rows(e.RowIndex).Cells("Num_doc").Value
    '            oFamiliar.NombreDelIntegranteDeLaFamilia = dtgFamiliar.Rows(e.RowIndex).Cells("NombreDelIntegranteDeLaFamilia").Value
    '            oFamiliar.EdadDelIntegranteDeLaFamilia = dtgFamiliar.Rows(e.RowIndex).Cells("EdadDelIntegranteDeLaFamilia").Value
    '            oFamiliar.ParentescoDelIntegranteDeLaFamilia = dtgFamiliar.Rows(e.RowIndex).Cells("ParentescoDelIntegranteDeLaFamilia").Value
    '            oFamiliar.dscParentescoDelIntegranteDeLaFamilia = dtgFamiliar.Rows(e.RowIndex).Cells("dscParentescoDelIntegranteDeLaFamilia").Value
    '            oFamiliar.OcupacionDelIntegranteDeLaFamilia = dtgFamiliar.Rows(e.RowIndex).Cells("OcupacionDelIntegranteDeLaFamilia").Value
    '            oFamiliar.dscOcupacionDelIntegranteDeLaFamilia = dtgFamiliar.Rows(e.RowIndex).Cells("dscOcupacionDelIntegranteDeLaFamilia").Value
    '            loadComposicionFamiliar(oFamiliar)
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub btnSugerirRespuesta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSugerirRespuesta.Click
        Try
            Dim oAspectosSociales As New AspectosSociales()
            loadAspectosSociales(oAspectosSociales.SugerirRespuesta(objGeneral, objPaciente))

        Catch ex As Exception
            MessageBox.Show("No fue posible consultar las últimas respuestas de este paciente.", "Historia Clínica", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

        End Try
    End Sub

    Private Sub btnSugerirFamiliares_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSugerirFamiliares.Click
        Try
            oFamiliar = New ComposicionFamiliar
            oFamiliar.tip_doc = objPaciente.TipoDocumento
            oFamiliar.Num_doc = objPaciente.NumeroDocumento
            loadFamiliares(oFamiliar)
            index = -1
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

    Private Sub dtgFamiliar_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dtgFamiliar.UserDeletingRow
        Dim IdPariente As String = e.Row.Cells("IdPariente").Value
        Dim lstFamilia As New List(Of ComposicionFamiliar)
        If IdPariente <> "" Then
            Try

            
                If MessageBox.Show("¿Está Seguro de Borrar este Registro?", "Cuidados Paliativos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    'EliminarImpresionDiagnostica(e.Row)
                    If IdPariente <> "0" Then
                        oFamiliar.IdPariente = e.Row.Cells("IdPariente").Value
                        oFamiliar.tip_doc = e.Row.Cells("tip_doc").Value
                        oFamiliar.Num_doc = e.Row.Cells("Num_doc").Value
                        'EliminarFamiliares(oFamiliar)
                        objDACPComposicionFamiliar.EliminarFamiliar(oFamiliar)
                        'lstFamiliares.RemoveAll(AddressOf EliminarFamiliares)
                    End If
                    'For i As Integer = 0 To lstFamilia.Count - 1
                    '    If lstFamilia(i).IdPariente = IdPariente Then
                    '        lstFamiliares.Remove(lstFamilia(i))
                    '    End If
                    'Next
                    'If lstFamiliares.Count > 0 Then
                    '    dtgFamiliar.AutoGenerateColumns = False
                    '    bsFamiliares.DataSource = lstFamiliares
                    '    dtgFamiliar.DataSource = bsFamiliares
                    'Else
                    '    dtgFamiliar.DataSource = Nothing
                    'End If

                    'dtgFamiliar.AutoGenerateColumns = False
                    'bsFamiliares.DataSource = lstFamiliares
                    'dtgFamiliar.DataSource = bsFamiliares
                Else
                    e.Cancel = True
                End If
            Catch ex As Exception

            End Try
        Else
            MessageBox.Show("No Es Permitido Eliminar Este Registro")
            e.Cancel = True
        End If

        'LimpiarPantallaImpresionDiagnostica()
        'txtCodTipoDiagnosticoID.Focus()

        
    End Sub

#End Region

#Region "Functions"

    ''' <summary>
    ''' Carga los combos que contiene el formulario
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CargarCombos()
        Dim dt As New DataTable
        Try
            cmbConvivencia.ResetText()
            cmbConvivencia.BeginUpdate()

            dt = objDACPAspectosSociales.CargarCombosCPAspectosSociales(1) 'Convivencia

            If dt.Rows.Count = 0 Then
                MsgBox("No existen Tipos de Convivencia parametrizados.")
            End If
            cmbConvivencia.DataSource = dt

            cmbConvivencia.DisplayMember = "descripcion"
            cmbConvivencia.ValueMember = "Id"
            cmbConvivencia.EndUpdate()

            dt = Nothing

            cmbTipoVivienda.ResetText()
            cmbTipoVivienda.BeginUpdate()

            dt = objDACPAspectosSociales.CargarCombosCPAspectosSociales(2) 'Tipo de Vivienda

            If dt.Rows.Count = 0 Then
                MsgBox("No existen Tipos de Vivienda parametrizados.")
            End If
            cmbTipoVivienda.DataSource = dt

            cmbTipoVivienda.DisplayMember = "descripcion"
            cmbTipoVivienda.ValueMember = "Id"
            cmbTipoVivienda.EndUpdate()

            dt = Nothing

            cmbTenencia.ResetText()
            cmbTenencia.BeginUpdate()

            dt = objDACPAspectosSociales.CargarCombosCPAspectosSociales(3) 'Tipo de Tenencia

            If dt.Rows.Count = 0 Then
                MsgBox("No existen Tipos de Tenencia parametrizados.")
            End If
            cmbTenencia.DataSource = dt

            cmbTenencia.DisplayMember = "descripcion"
            cmbTenencia.ValueMember = "Id"
            cmbTenencia.EndUpdate()

            dt = Nothing

            cmbEstrato.ResetText()
            cmbEstrato.BeginUpdate()

            dt = objDACPAspectosSociales.CargarCombosCPAspectosSociales(4) 'Estrato Social

            If dt.Rows.Count = 0 Then
                MsgBox("No existen Estratos Sociales parametrizados.")
            End If
            cmbEstrato.DataSource = dt

            cmbEstrato.DisplayMember = "descripcion"
            cmbEstrato.ValueMember = "Id"
            cmbEstrato.EndUpdate()

            'NIvel Educativo Paciente
            dt = Nothing

            cmbNivelEducativo.ResetText()
            cmbNivelEducativo.BeginUpdate()

            dt = objDACPAspectosSociales.CargarCombosCPAspectosSociales(5) 'NIvel Educativo

            If dt.Rows.Count = 0 Then
                MsgBox("No existen NIveles Educativos parametrizados.")
            End If
            cmbNivelEducativo.DataSource = dt

            cmbNivelEducativo.DisplayMember = "descripcion"
            cmbNivelEducativo.ValueMember = "id_escolaridad"
            cmbNivelEducativo.EndUpdate()


            'NIvel Educativo Cuidador
            dt = Nothing
            cmbNivEduCuidador.ResetText()
            cmbNivEduCuidador.BeginUpdate()

            dt = objDACPAspectosSociales.CargarCombosCPAspectosSociales(5) 'NIvel Educativo

            If dt.Rows.Count = 0 Then
                MsgBox("No existen NIveles Educativos parametrizados.")
            End If
            cmbNivEduCuidador.DataSource = dt
            cmbNivEduCuidador.DisplayMember = "descripcion"
            cmbNivEduCuidador.ValueMember = "id_escolaridad"
            cmbNivEduCuidador.EndUpdate()

            'Ocupación
            dt = Nothing

            cmbOcupacion.ResetText()
            cmbOcupacion.BeginUpdate()

            dt = objDACPAspectosSociales.CargarCombosCPAspectosSociales(6) 'Ocupación

            If dt.Rows.Count = 0 Then
                MsgBox("No existen Ocupaciones parametrizadas.")
            End If
            cmbOcupacion.DataSource = dt

            cmbOcupacion.DisplayMember = "descripcion"
            cmbOcupacion.ValueMember = "ocupacion"
            cmbOcupacion.EndUpdate()

            'Ocupación Familiar
            dt = Nothing

            cmbOcupacionFam.ResetText()
            cmbOcupacionFam.BeginUpdate()

            dt = objDACPAspectosSociales.CargarCombosCPAspectosSociales(6) 'Ocupación

            If dt.Rows.Count = 0 Then
                MsgBox("No existen Ocupaciones parametrizadas.")
            End If
            cmbOcupacionFam.DataSource = dt

            cmbOcupacionFam.DisplayMember = "descripcion"
            cmbOcupacionFam.ValueMember = "ocupacion"
            cmbOcupacionFam.EndUpdate()

            'Ocupación cuidador
            dt = Nothing

            cmbOcupacionCuidador.ResetText()
            cmbOcupacionCuidador.BeginUpdate()

            dt = objDACPAspectosSociales.CargarCombosCPAspectosSociales(6) 'Ocupación

            If dt.Rows.Count = 0 Then
                MsgBox("No existen Ocupaciones parametrizadas.")
            End If
            cmbOcupacionCuidador.DataSource = dt

            cmbOcupacionCuidador.DisplayMember = "descripcion"
            cmbOcupacionCuidador.ValueMember = "ocupacion"
            cmbOcupacionCuidador.EndUpdate()


            dt = Nothing

            cmbNivelIngresos.ResetText()
            cmbNivelIngresos.BeginUpdate()

            dt = objDACPAspectosSociales.CargarCombosCPAspectosSociales(7) 'Nivel de Ingresos

            If dt.Rows.Count = 0 Then
                MsgBox("No existen Niveles de Ingresos parametrizados.")
            End If
            cmbNivelIngresos.DataSource = dt

            cmbNivelIngresos.DisplayMember = "descripcion"
            cmbNivelIngresos.ValueMember = "Id"
            cmbNivelIngresos.EndUpdate()

            'Tipo de Familia
            dt = Nothing

            cmbTipoFamilia.ResetText()
            cmbTipoFamilia.BeginUpdate()

            dt = objDACPAspectosSociales.CargarCombosCPAspectosSociales(8) 'Tipo de Familia

            If dt.Rows.Count = 0 Then
                MsgBox("No existen Tipos de Familia parametrizados.")
            End If
            cmbTipoFamilia.DataSource = dt

            cmbTipoFamilia.DisplayMember = "descripcion"
            cmbTipoFamilia.ValueMember = "Id"
            cmbTipoFamilia.EndUpdate()

            'Parentesco
            dt = Nothing

            cmbParentesco.ResetText()
            cmbParentesco.BeginUpdate()

            dt = objDACPAspectosSociales.CargarCombosCPAspectosSociales(9) 'Parentesco

            If dt.Rows.Count = 0 Then
                MsgBox("No existen Parentescos parametrizados.")
            End If
            cmbParentesco.DataSource = dt

            cmbParentesco.DisplayMember = "Descripcion"
            cmbParentesco.ValueMember = "IdParentesco"
            cmbParentesco.EndUpdate()

            'Parentesco Cuidador
            dt = Nothing

            cmbParentescoCuidador.ResetText()
            cmbParentescoCuidador.BeginUpdate()

            dt = objDACPAspectosSociales.CargarCombosCPAspectosSociales(9) 'Parentesco

            If dt.Rows.Count = 0 Then
                MsgBox("No existen Parentescos parametrizados.")
            End If
            cmbParentescoCuidador.DataSource = dt
            cmbParentescoCuidador.DisplayMember = "Descripcion"
            cmbParentescoCuidador.ValueMember = "IdParentesco"
            cmbParentescoCuidador.EndUpdate()

            'Tipo Documento
            dt = Nothing

            cmbTipodocumento.ResetText()
            cmbTipodocumento.BeginUpdate()

            dt = objDACPAspectosSociales.CargarCombosCPAspectosSociales(10) 'Tipo Documento

            If dt.Rows.Count = 0 Then
                MsgBox("No existen Tipos de Documento parametrizados.")
            End If
            cmbTipodocumento.DataSource = dt

            cmbTipodocumento.DisplayMember = "descripcion"
            cmbTipodocumento.ValueMember = "tip_doc"
            cmbTipodocumento.EndUpdate()

            'Estado civil
            dt = Nothing

            cmbEstadoCivil.ResetText()
            cmbEstadoCivil.BeginUpdate()

            dt = objDACPAspectosSociales.CargarCombosCPAspectosSociales(11) 'Estado civil

            If dt.Rows.Count = 0 Then
                MsgBox("No existen Estados civiles parametrizados.")
            End If
            cmbEstadoCivil.DataSource = dt

            cmbEstadoCivil.DisplayMember = "descripcion"
            cmbEstadoCivil.ValueMember = "est_civil"
            cmbEstadoCivil.EndUpdate()

            'Condicion de la Madre
            dt = Nothing

            cmbCondicionMadre.ResetText()
            cmbCondicionMadre.BeginUpdate()

            dt = objDACPAspectosSociales.CargarCombosCPAspectosSociales(12) 'Condicion de la Madre

            If dt.Rows.Count = 0 Then
                MsgBox("No existen Parentescos parametrizados.")
            End If
            cmbCondicionMadre.DataSource = dt

            cmbCondicionMadre.DisplayMember = "descripcion"
            cmbCondicionMadre.ValueMember = "Id"
            cmbCondicionMadre.EndUpdate()

            'Condicion del Padre
            dt = Nothing

            cmbCondicionPadre.ResetText()
            cmbCondicionPadre.BeginUpdate()

            dt = objDACPAspectosSociales.CargarCombosCPAspectosSociales(13) 'Condicion del Padre

            If dt.Rows.Count = 0 Then
                MsgBox("No existen Parentescos parametrizados.")
            End If
            cmbCondicionPadre.DataSource = dt

            cmbCondicionPadre.DisplayMember = "descripcion"
            cmbCondicionPadre.ValueMember = "Id"
            cmbCondicionPadre.EndUpdate()



        Catch ex As Exception
            Throw (ex)
        End Try


    End Sub

    ''' <summary>
    ''' Carga la información del familiar
    ''' </summary>
    ''' <param name="oComposicionFamiliar">Familiar a cargar</param>
    ''' <remarks></remarks>
    Private Sub loadComposicionFamiliar(ByVal oComposicionFamiliar As ComposicionFamiliar)
        Try
            oFamiliar = oComposicionFamiliar
            txtNombreFamiliar.Text = oComposicionFamiliar.NombreDelIntegranteDeLaFamilia

            If oComposicionFamiliar.EdadDelIntegranteDeLaFamilia = 0 Then
                txtEdadFamiliar.Text = String.Empty
            Else
                txtEdadFamiliar.Text = oComposicionFamiliar.EdadDelIntegranteDeLaFamilia
            End If

            cmbParentesco.SelectedValue = IIf(oComposicionFamiliar.ParentescoDelIntegranteDeLaFamilia = Nothing, 0, oComposicionFamiliar.ParentescoDelIntegranteDeLaFamilia)

            If oComposicionFamiliar.OcupacionDelIntegranteDeLaFamilia = 0 Then
                txtCodOcupacionFam.Text = String.Empty
            Else
                txtCodOcupacionFam.Text = oComposicionFamiliar.OcupacionDelIntegranteDeLaFamilia
            End If

            cmbOcupacionFam.SelectedValue = IIf(oComposicionFamiliar.OcupacionDelIntegranteDeLaFamilia = Nothing, "", oComposicionFamiliar.OcupacionDelIntegranteDeLaFamilia)
            txtCodOcupacionFam.Text = String.Empty

        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

    ''' <summary>
    ''' Carga la información del aspecto social
    ''' </summary>
    ''' <param name="oAspectosSociales">Aspecto Social a cargar</param>
    ''' <remarks></remarks>
    Private Sub loadAspectosSociales(ByVal oAspectosSociales As AspectosSociales)
        Try
            cmbConvivencia.SelectedValue = oAspectosSociales.ConQuienVive
            cmbTipoVivienda.SelectedValue = oAspectosSociales.TipoDeVivienda
            cmbTenencia.SelectedValue = oAspectosSociales.TenenciaDeLaVivienda
            cmbEstrato.SelectedValue = oAspectosSociales.EstratoDeLaVivienda

            cmbNivelEducativo.SelectedValue = IIf(oAspectosSociales.NivelEscolaridad = Nothing, "", oAspectosSociales.NivelEscolaridad)
            cmbOcupacion.SelectedValue = IIf(oAspectosSociales.Ocupacion = Nothing, "", oAspectosSociales.Ocupacion)
            txtOcupacion.Text = String.Empty

            If oAspectosSociales.CuentaConUnTrabajoEstable = 0 Then
                rbtSiTrabajoEstable.Checked = False
                rbtNoTrabajoEstable.Checked = False
            Else
                Select Case oAspectosSociales.CuentaConUnTrabajoEstable.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiTrabajoEstable.Checked = True
                        rbtNoTrabajoEstable.Checked = False
                    Case "2"
                        rbtSiTrabajoEstable.Checked = False
                        rbtNoTrabajoEstable.Checked = True
                End Select
            End If

            cmbNivelIngresos.SelectedValue = oAspectosSociales.Ingresos
            cmbCondicionMadre.SelectedValue = oAspectosSociales.CondicionDeLaMadre
            cmbCondicionPadre.SelectedValue = oAspectosSociales.CondicionDelPadre

            If oAspectosSociales.NumeroDeHermanos = 0 Then
                txtNumeroHermanos.Text = String.Empty
            Else
                txtNumeroHermanos.Text = oAspectosSociales.NumeroDeHermanos
            End If

            If oAspectosSociales.Lugar = 0 Then
                txtLugarPaciente.Text = String.Empty
            Else
                txtLugarPaciente.Text = oAspectosSociales.Lugar
            End If

            If oAspectosSociales.PersonasACargo = 0 Then
                txtPersonasCargo.Text = String.Empty
            Else
                txtPersonasCargo.Text = oAspectosSociales.PersonasACargo
            End If

            If oAspectosSociales.NumeroDeIntegrantesDeLaFamilia = 0 Then
                txtNumeroIntegrantes.Text = String.Empty
            Else
                txtNumeroIntegrantes.Text = oAspectosSociales.NumeroDeIntegrantesDeLaFamilia
            End If

            If oAspectosSociales.NumeroDeIntegrantesDeLaFamilia = 0 Then
                txtNumeroIntegrantes.Text = String.Empty
            Else
                txtNumeroIntegrantes.Text = oAspectosSociales.NumeroDeIntegrantesDeLaFamilia
            End If

            If oAspectosSociales.TieneHijos = 0 Then
                rbtSiTieneHijos.Checked = False
                rbtNoTieneHijos.Checked = False
            Else
                Select Case oAspectosSociales.TieneHijos.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiTieneHijos.Checked = True
                        rbtNoTieneHijos.Checked = False
                    Case "2"
                        rbtSiTieneHijos.Checked = False
                        rbtNoTieneHijos.Checked = True
                End Select
            End If

            cmbTipoFamilia.SelectedValue = oAspectosSociales.TipoDeFamilia
            txtNombreCuidador.Text = oAspectosSociales.NombreDelCuidador
            cmbTipodocumento.SelectedValue = IIf(oAspectosSociales.TipoDeDocumentoDelCuidador = Nothing, "", oAspectosSociales.TipoDeDocumentoDelCuidador)

            If oAspectosSociales.NumeroDeDocumentoDelCuidador = 0 Then
                txtDocumento.Text = String.Empty
            Else
                txtDocumento.Text = oAspectosSociales.NumeroDeDocumentoDelCuidador
            End If

            cmbParentescoCuidador.SelectedValue = IIf(oAspectosSociales.ParentescoDelCuidador = Nothing, 0, oAspectosSociales.ParentescoDelCuidador)
            cmbNivEduCuidador.SelectedValue = IIf(oAspectosSociales.EscolaridadDelCuidador = Nothing, "", oAspectosSociales.EscolaridadDelCuidador)
            txtDireccionCuidador.Text = oAspectosSociales.DireccionDelCuidador

            cmbEstadoCivil.SelectedValue = IIf(oAspectosSociales.EstadoCivilDelCuidador = Nothing, "", oAspectosSociales.EstadoCivilDelCuidador)
            cmbOcupacionCuidador.SelectedValue = IIf(oAspectosSociales.OcupacionDelCuidador = Nothing, "", oAspectosSociales.OcupacionDelCuidador)
            txtOcupacionCuidador.Text = String.Empty

            txtProblemasIdentificados.Text = oAspectosSociales.ProblemasIdentificados
            txtPlanIntervencion.Text = oAspectosSociales.PlanDeIntervencion


        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

    ''' <summary>
    ''' Carga los familiares registrados al paciente.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub loadFamiliares(ByVal oComposicionFamiliar As ComposicionFamiliar)
        Try

            lstFamiliares = New List(Of ComposicionFamiliar)
            lstFamiliares = objDACPComposicionFamiliar.ConsultarFamiliar(oComposicionFamiliar)

            If lstFamiliares.Count > 0 Then
                dtgFamiliar.AutoGenerateColumns = False
                bsFamiliares.DataSource = lstFamiliares
                dtgFamiliar.DataSource = bsFamiliares
            Else
                dtgFamiliar.DataSource = Nothing
            End If

        Catch ex As Exception

        End Try
    End Sub

    '''' <summary>
    '''' Carga los familiares registrados al paciente.
    '''' </summary>
    '''' <remarks></remarks>
    'Private Function EliminarFamiliares(ByVal fFamiliar As ComposicionFamiliar) As Boolean
    '    Try

    '        objDACPComposicionFamiliar.EliminarFamiliar(fFamiliar)
    '        'Return IIf(fFamiliar.IdPariente.Equals(IdPariente), True, False)

    '    Catch ex As Exception

    '    End Try
    'End Function

#End Region


    Private Sub dtgFamiliar_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dtgFamiliar.DataError
        MsgBox(e.Exception.Message.ToString())
    End Sub
End Class

