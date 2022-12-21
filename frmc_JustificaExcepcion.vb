Imports System.Windows.Forms
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales.Generales


Public Class frmc_JustificaExcepcion
    Public strJustificacion As String = ""
    Public objBl As New BLOrdenes
    Private Dosis As Double
    Private Frecuencia As Double
    Private Clasificacion As String
    Private objDao As New DAOGeneral
    Private General As objGeneral
    Public dtCtc As New DataTable




    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel

        txtPA.Text = String.Empty
        txtConcentracion.Text = String.Empty
        txtForFarma.Text = String.Empty
        txtDias.Text = String.Empty
        txtDosis.Text = String.Empty
        txtCodMed.Text = String.Empty
        mskFechaHasta.Text = String.Empty

        dtgEquivalente.DataSource = Nothing

        Me.Close()
    End Sub

    Public Sub Mostrar(ByVal strMedicamento As String, ByVal frecuenciaMed As Double, _
    ByVal strcod_pre_sgs As String, ByVal strCod_sucur As String, ByVal strTip_Admision As String, _
    ByVal lano_adm As Integer, ByVal num_adm As Integer, ByVal strLogin As String, ByVal objConexion As objCon)

        Dim dtResult As New DataTable
        Dim fecha As String

        Dim fec_ini As Date
        Dim fec_fin As Date


        ''LimpiarControles()

        BLOrdenes.GrabarErroresOrdenesMedicas("HistoriaMedicaCTC" & " Entra emergente CTC")

        General = objGeneral.Instancia
        fecha = Format(objDao.traerFechaServidor(), General.FormatoFechaCorta)
        mskFechaDesde.Text = Format(CDate(fecha), "dd/MM/yyyy")
                

        mskFechaHasta.Text = DateAdd("d", 29, CDate(mskFechaDesde.Text))
        fec_ini = mskFechaDesde.Text
        fec_fin = mskFechaHasta.Text
        txtDias.Text = (DateDiff(DateInterval.Day, fec_ini, fec_fin) + 1)
        lblDuracion.Text = txtDias.Text & " Dias"

        txtDias.Text = (DateDiff(DateInterval.Day, fec_ini, fec_fin) + 1)
        lblDuracion.Text = txtDias.Text & " Dias"
        Me.dtCtc = New DataTable

        ''Traer los diagnósticos
        'ConsultarDiagnosticos(strcod_pre_sgs, strCod_sucur, strTip_Admision, lano_adm, num_adm, strLogin, objConexion)
        txtCodDiagn.ControlComboEnlace = txtdescDiagn
        With txtdescDiagn
            .CampoMostrar = "descripcion"
            .ControlTextoEnlace = txtCodDiagn
            .CampoEnlazado = "codigo"
            .CategoriaDatos = CategoriaDatos.Diagnosticos
            '.CargarDatos()
            .CargarButton()
        End With
        ''Cargar las unidades de medida
        CargarUnidadMedida()

        ' Me.Dosis = dosisMed
        Me.Frecuencia = frecuenciaMed

        dtResult = BLOrdenes.ConsultaMedicamentosEquivalentes(strMedicamento)

        If dtResult.Rows.Count > 0 Then
            ConfigurarGrilla(dtResult)
            GroupBox2.Location = New System.Drawing.Point(5, 128)
            GrpMedicamento.Location = New System.Drawing.Point(5, 179)
            GroupBox1.Location = New System.Drawing.Point(5, 359)
            Label11.Location = New System.Drawing.Point(7, 590)
            txtJustificacion.Location = New System.Drawing.Point(5, 609)
            Panel1.Location = New System.Drawing.Point(445, 702)
            dtgEquivalente.Visible = True
            Me.Width = 622
            Me.Height = 764
        Else
            MsgBox("No existen medicamentos equivalentes asociados", MsgBoxStyle.Information)
            ConfigurarGrilla(dtResult)
            dtgEquivalente.Visible = False
            GroupBox2.Location = New System.Drawing.Point(11, 30)
            GrpMedicamento.Location = New System.Drawing.Point(11, 82)
            GroupBox1.Location = New System.Drawing.Point(10, 257)
            Label11.Location = New System.Drawing.Point(9, 493)
            txtJustificacion.Location = New System.Drawing.Point(13, 513)
            Panel1.Location = New System.Drawing.Point(419, 611)
            Me.Height = 679
            Me.txtCodMed.Enabled = True
            Me.txtPA.Enabled = True
            mskFechaHasta.Focus()

        End If

        Me.txtDias.Enabled = False

    End Sub
    Private Sub ConsultarDiagnosticos(ByVal strcod_pre_sgs As String, ByVal strCod_sucur As String, ByVal strTip_Admision As String, _
    ByVal lano_adm As Integer, ByVal num_adm As Integer, ByVal strLogin As String, ByVal objConexion As objCon)

        Dim dtresult As New DataTable
        Dim objBl As New Sophia.HistoriaClinica.BL.BLEgresos

        ' dtresult = objBl.ConsultarDiagnosticoReingreso(strcod_pre_sgs, strCod_sucur, strTip_Admision, lano_adm, num_adm, "I", strLogin, objConexion)

        With dtresult
            .Columns.Add("diagnost", System.Type.GetType("System.String"))
            .Columns.Add("descripcion", System.Type.GetType("System.String"))
            .Columns.Add("obs", System.Type.GetType("System.String"))
            .Columns.Add("clasificacion", System.Type.GetType("System.String"))         
        End With

        With dtgDiagnostico
            .DataSource = dtresult
            '.Columns.Item("tip_admision").Visible = False
            '.Columns.Item("ano_adm").Visible = False
            '.Columns.Item("num_adm").Visible = False
            '.Columns.Item("tip_diag").Visible = False
            '.Columns.Item("tDescripcion").Visible = False
            .Columns.Item("clasificacion").Visible = False
            '.Columns.Item("Antecedente").Visible = False
            '.Columns.Item("confidencial").Visible = False
            '.Columns.Item("planManejo").Visible = False
            '.Columns.Item("secuencia").Visible = False
            '.Columns.Item("clase_diag").Visible = False
            '.Columns.Item("categoria_diag").Visible = False
            '.Columns.Item("CategoriaDes").Visible = False
            '.Columns.Item("fec_hc").Visible = False
            '.Columns.Item("Nuevo").Visible = False
            .Columns.Item("diagnost").HeaderText = "Código"
            .Columns.Item("diagnost").Width = 80
            .Columns.Item("descripcion").HeaderText = "Diagnóstico"
            .Columns.Item("descripcion").Width = 250
            .Columns.Item("obs").HeaderText = "Observación"
            .Columns.Item("obs").Width = 175
        End With

        '/Para los Diagnosticos
        txtCodDiagn.ControlComboEnlace = txtdescDiagn
        With txtdescDiagn
            .CampoMostrar = "descripcion"
            .ControlTextoEnlace = txtCodDiagn
            .CampoEnlazado = "codigo"
            .CategoriaDatos = CategoriaDatos.Diagnosticos
            .CargarDatos()
            .CargarButton()
        End With

    End Sub

    Private Sub ConfigurarGrilla(ByVal dt As DataTable)

        With dtgEquivalente
            .DataSource = dt
            .Columns("cod_corto").HeaderText = "Código Producto"
            .Columns("cod_corto").Width = 100
            .Columns("producto_equiv").HeaderText = "Código Equivalente"
            .Columns("producto_equiv").Width = 100
            .Columns("descripcion_pa").HeaderText = "Descripción"
            .Columns("descripcion_pa").Width = 350
            .Columns("descripcion").Visible = False
            .Columns("concentracion").Visible = False
            .Columns("ForFarma").Visible = False
        End With


    End Sub

    Private Sub dtgEquivalente_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgEquivalente.CellDoubleClick
        txtPA.Text = IIf(IsDBNull(dtgEquivalente.CurrentRow.Cells("descripcion_pa").Value), "", dtgEquivalente.CurrentRow.Cells("descripcion_pa").Value)
        txtConcentracion.Text = IIf(IsDBNull(dtgEquivalente.CurrentRow.Cells("concentracion").Value), "", dtgEquivalente.CurrentRow.Cells("concentracion").Value)
        If Len(txtConcentracion.Text) > 0 Then
            txtConcentracion.Enabled = False
        Else
            txtConcentracion.Enabled = True
        End If
        txtForFarma.Text = IIf(IsDBNull(dtgEquivalente.CurrentRow.Cells("ForFarma").Value), "", dtgEquivalente.CurrentRow.Cells("ForFarma").Value)
        If Len(txtForFarma.Text) > 0 Then
            txtForFarma.Enabled = False
        Else
            txtForFarma.Enabled = True
        End If
        txtCodMed.Text = dtgEquivalente.CurrentRow.Cells("producto_equiv").Value
        mskFechaHasta.Focus()
    End Sub

    Private Sub mskFechaHasta_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskFechaHasta.Validated
        Dim fec_ini As Date
        Dim fec_fin As Date

        If mskFechaHasta.Text <> "  /  /" Then
            fec_ini = mskFechaDesde.Text
            fec_fin = mskFechaHasta.Text
            txtDias.Text = (DateDiff(DateInterval.Day, fec_ini, fec_fin) + 1)
            lblDuracion.Text = txtDias.Text & " Dias"
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click

        BuscarMedicamento()

    End Sub
    Private Sub BuscarMedicamento()
        Sophia.HistoriaClinica.Buscador.frmBuscadorEquiva.Mostrar(CategoriaDatos.OrdenMedicamentosDescripcion, txtPA.Text, txtCodMed.Text)

        If Sophia.HistoriaClinica.Buscador.frmBuscadorEquiva.strCodMedicamentoequiva <> "" Then

            txtCodMed.Text = Sophia.HistoriaClinica.Buscador.frmBuscadorEquiva.strCodMedicamentoequiva
            txtPA.Text = Sophia.HistoriaClinica.Buscador.frmBuscadorEquiva.strDescMedicamentoequiva
            txtConcentracion.Text = Sophia.HistoriaClinica.Buscador.frmBuscadorEquiva.strConcentracion
            If Len(txtConcentracion.Text) = 0 Then
                txtConcentracion.Enabled = True
            Else
                txtConcentracion.Enabled = False
            End If
            txtForFarma.Text = Sophia.HistoriaClinica.Buscador.frmBuscadorEquiva.strForFarma
            If Len(txtForFarma.Text) = 0 Then
                txtForFarma.Enabled = True
            Else
                txtForFarma.Enabled = False
            End If
        Else
            txtCodMed.Text = ""
            txtPA.Text = ""
        End If
    End Sub


    Private Sub btnBuscarDiag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Sophia.HistoriaClinica.Buscador.frmBuscadorEquiva.Mostrar(CategoriaDatos.Diagnosticos, txtdescDiagn.Text)

        If Sophia.HistoriaClinica.Buscador.frmBuscadorEquiva.strCodMedicamentoequiva <> "" Then
            txtCodDiagn.Text = Sophia.HistoriaClinica.Buscador.frmBuscadorEquiva.strCodMedicamentoequiva
            txtdescDiagn.Text = Sophia.HistoriaClinica.Buscador.frmBuscadorEquiva.strDescMedicamentoequiva
            Clasificacion = Sophia.HistoriaClinica.Buscador.frmBuscadorEquiva.strClasificacionDiagn
        End If
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim i As Integer

        If dtCtc.Rows.Count = 0 Then
            CrearTablaCtc()
        End If

        dtCtc.Rows.Add(dtCtc.NewRow)

        i = dtCtc.Rows.Count - 1

        dtCtc.Rows(i).Item("cod_corto") = txtCodMed.Text
        dtCtc.Rows(i).Item("concentracion") = txtConcentracion.Text
        dtCtc.Rows(i).Item("for_farma") = txtForFarma.Text
        dtCtc.Rows(i).Item("diasTratamiento") = txtDias.Text
        dtCtc.Rows(i).Item("DosisXDia") = txtDosis.Text
        dtCtc.Rows(i).Item("fec_desde") = mskFechaDesde.Text
        dtCtc.Rows(i).Item("fec_hasta") = mskFechaHasta.Text
        dtCtc.Rows(i).Item("diagnost") = txtCodDiagn.Text
        dtCtc.Rows(i).Item("clasificacion") = Me.Clasificacion
        dtCtc.Rows(i).Item("Justificacion") = Me.txtJustificacion.Text
        dtCtc.Rows(i).Item("obs") = txtObsDiagn.Text

        LimpiarControles()

        Me.Close()
    End Sub
    Private Sub CrearTablaCtc()
        With dtCtc
            .Columns.Add("cod_corto", System.Type.GetType("System.String"))
            .Columns.Add("concentracion", System.Type.GetType("System.String"))
            .Columns.Add("for_farma", System.Type.GetType("System.String"))
            .Columns.Add("diasTratamiento", System.Type.GetType("System.String"))
            .Columns.Add("DosisXDia", System.Type.GetType("System.String"))
            .Columns.Add("fec_desde", System.Type.GetType("System.String"))
            .Columns.Add("fec_hasta", System.Type.GetType("System.String"))
            .Columns.Add("diagnost", System.Type.GetType("System.String"))
            .Columns.Add("clasificacion", System.Type.GetType("System.String"))
            .Columns.Add("Justificacion", System.Type.GetType("System.String"))
            .Columns.Add("obs", System.Type.GetType("System.String"))
        End With

    End Sub



    Private Sub dtgDiagnostico_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgDiagnostico.CellDoubleClick
        txtCodDiagn.Text = dtgDiagnostico.CurrentRow.Cells("diagnost").Value
        txtdescDiagn.Text = dtgDiagnostico.CurrentRow.Cells("descripcion").Value
        Clasificacion = dtgDiagnostico.CurrentRow.Cells("clasificacion").Value
    End Sub
    Private Sub LimpiarControles()
        dtgEquivalente.DataSource = Nothing
        dtgDiagnostico.DataSource = Nothing
        mskFechaHasta.Text = "  /  /"
        mskFechaDesde.Text = "  /  /"
        txtCodMed.Text = String.Empty
        txtPA.Text = String.Empty
        txtConcentracion.Text = String.Empty
        txtForFarma.Text = String.Empty
        txtDias.Text = String.Empty
        txtDosis.Text = String.Empty
        lblDuracion.Text = String.Empty
        txtCodDiagn.Text = String.Empty
        ' txtdescDiagn.ResetText()
        'txtdescDiagn.Text = String.Empty
        'txtdescDiagn.Text = ""
        If Not txtdescDiagn.OrigenDeDatos Is Nothing Then
            txtdescDiagn.OrigenDeDatos.Rows.Clear()
            txtdescDiagn.Text = ""
        End If

        txtObsDiagn.Text = String.Empty
        txtJustificacion.Text = String.Empty
    End Sub

    Private Sub mskFechaDesde_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskFechaDesde.LostFocus
        Dim fec_ini As Date
        Dim fec_fin As Date

        ' Se calcula la fecha final 30 dias despues (se cuenta el dia actual por eso se suman 29)- Requerimiento 04042014 - Mforero
        If mskFechaHasta.Text <> "  /  /" Then
            mskFechaHasta.Text = DateAdd("d", 29, CDate(mskFechaDesde.Text))
            fec_ini = mskFechaDesde.Text
            fec_fin = mskFechaHasta.Text
            txtDias.Text = (DateDiff(DateInterval.Day, fec_ini, fec_fin) + 1)
            lblDuracion.Text = txtDias.Text & " Dias"
        End If
    End Sub


    Private Sub mskFechaDesde_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mskFechaDesde.Validating
        If mskFechaDesde.Text <> "  /  /" Then
            If Not IsDate(mskFechaDesde.Text) Then

                MsgBox("Fecha invalida. Debe digitar una fecha valida.", MsgBoxStyle.Information)
                e.Cancel = True
                mskFechaDesde.Select(0, mskFechaDesde.TextLength)
            End If
        End If
    End Sub


    Private Sub mskFechaHasta_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mskFechaHasta.Validating
        If mskFechaHasta.Text <> "  /  /" Then
            If Not IsDate(mskFechaHasta.Text) Then
                MsgBox("Fecha invalida. Debe digitar una fecha valida.", MsgBoxStyle.Information)
                e.Cancel = True
                mskFechaHasta.Select(0, mskFechaHasta.TextLength)
            Else
                If Not CDate(mskFechaHasta.Text) >= CDate(mskFechaDesde.Text) Then
                    MsgBox("La fecha final no puede ser menor a la inicial.", MsgBoxStyle.Information)
                    e.Cancel = True
                    mskFechaDesde.Select(0, mskFechaDesde.TextLength)
                End If
            End If
        End If
    End Sub


    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Dim i As Integer

        If ValidarObligatorios() = False Then
            Exit Sub
        End If

        If dtCtc.Rows.Count = 0 Then
            CrearTablaCtc()
        End If

        dtCtc.Rows.Add(dtCtc.NewRow)

        i = dtCtc.Rows.Count - 1

        dtCtc.Rows(i).Item("cod_corto") = txtCodMed.Text
        dtCtc.Rows(i).Item("concentracion") = txtConcentracion.Text
        dtCtc.Rows(i).Item("for_farma") = txtForFarma.Text
        dtCtc.Rows(i).Item("diasTratamiento") = txtDias.Text
        dtCtc.Rows(i).Item("DosisXDia") = txtDosis.Text & " " & cmbUnidad.Text
        dtCtc.Rows(i).Item("fec_desde") = mskFechaDesde.Text
        dtCtc.Rows(i).Item("fec_hasta") = mskFechaHasta.Text
        dtCtc.Rows(i).Item("diagnost") = txtCodDiagn.Text
        dtCtc.Rows(i).Item("clasificacion") = Me.Clasificacion
        dtCtc.Rows(i).Item("Justificacion") = Me.txtJustificacion.Text
        dtCtc.Rows(i).Item("obs") = txtObsDiagn.Text

        BLOrdenes.GrabarErroresOrdenesMedicas("HistoriaMedicaCTC" & " Click boton agregar " & txtCodMed.Text & " " & txtConcentracion.Text & " " & _
        txtForFarma.Text & " " & txtDias.Text & " " & txtDosis.Text & " " & cmbUnidad.Text & " " & mskFechaDesde.Text & " " & mskFechaHasta.Text & " " & txtCodDiagn.Text & " " & Clasificacion & " " & txtJustificacion.Text)

        BLOrdenes.GrabarErroresOrdenesMedicas("HistoriaMedicaCTCIP " & lF_sDireccionIP())

        LimpiarControles()

        Me.Close()
    End Sub
    Private Function ValidarObligatorios() As Boolean
        If Len(txtCodMed.Text) = 0 Then
            MsgBox("Ingrese o seleccione el producto Equivalente", MsgBoxStyle.Information)
            txtCodMed.Focus()
            Return False
        ElseIf mskFechaDesde.Text = "  /  /" Then
            MsgBox("Ingrese la Fecha Desde", MsgBoxStyle.Information)
            Return False
        ElseIf mskFechaHasta.Text = "  /  /" Then
            MsgBox("Ingrese la Fecha Hasta", MsgBoxStyle.Information)
            Return False
        ElseIf Len(txtConcentracion.Text) = 0 Then
            MsgBox("Ingrese la Concentración", MsgBoxStyle.Information)
            txtConcentracion.Focus()
            Return False
        ElseIf Len(txtForFarma.Text) = 0 Then
            MsgBox("Ingrese la Forma Farmaceutica", MsgBoxStyle.Information)
            txtForFarma.Focus()
            Return False
        ElseIf Len(txtDosis.Text) = 0 Then
            MsgBox("Ingrese la Dosis", MsgBoxStyle.Information)
            txtDosis.Focus()
            Return False
        ElseIf Len(txtCodDiagn.Text) = 0 Then
            MsgBox("Ingrese o seleccione el diagnóstico", MsgBoxStyle.Information)
            txtCodDiagn.Focus()
            Return False
        ElseIf Len(txtJustificacion.Text) = 0 Then
            MsgBox("Ingrese la Justificación", MsgBoxStyle.Information)
            txtJustificacion.Focus()
            Return False
        ElseIf Len(cmbUnidad.Text) = 0 Then
            MsgBox("Seleccione una Unidad de Medida Valida", MsgBoxStyle.Information)
            cmbUnidad.Focus()
            Return False
        ElseIf Len(cmbUnidad.Text) > 0 Then

            If cmbUnidad.SelectedValue Is Nothing Then
                MsgBox("Seleccione una Unidad de Medida Valida", MsgBoxStyle.Information)
                cmbUnidad.Focus()
                Return False
            Else
                Return True
            End If

        Else
            Return True
        End If
    End Function

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel

        txtPA.Text = String.Empty
        txtConcentracion.Text = String.Empty
        txtForFarma.Text = String.Empty
        txtDias.Text = String.Empty
        txtDosis.Text = String.Empty
        txtCodMed.Text = String.Empty
        mskFechaHasta.Text = String.Empty

        dtgEquivalente.DataSource = Nothing

        Me.Close()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub frmc_JustificaExcepcion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        LimpiarControles()
    End Sub

    Private Sub btnBuscarDiag_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarDiag.Click
        Sophia.HistoriaClinica.Buscador.frmBuscadorEquiva.Mostrar(CategoriaDatos.Diagnosticos, txtdescDiagn.Text)

        If Sophia.HistoriaClinica.Buscador.frmBuscadorEquiva.strCodMedicamentoequiva <> "" Then
            txtCodDiagn.Text = Sophia.HistoriaClinica.Buscador.frmBuscadorEquiva.strCodMedicamentoequiva
            txtdescDiagn.Text = Sophia.HistoriaClinica.Buscador.frmBuscadorEquiva.strDescMedicamentoequiva
            Clasificacion = Sophia.HistoriaClinica.Buscador.frmBuscadorEquiva.strClasificacionDiagn
        End If
    End Sub

    Public Sub CargarUnidadMedida()
        Dim objConexion As objCon
        Dim dtDatos As New DataTable

        objConexion = objCon.Instancia


        With cmbUnidad
            .BeginUpdate()
            dtDatos = BLOrdenes.consultarUnidadMedida(objConexion)
            If dtDatos.Rows.Count > 0 Then
                dtDatos.Rows.InsertAt(dtDatos.NewRow(), 0)
            Else
                MsgBox("Error al consultar la parametrización de unidad de medida.", MsgBoxStyle.Information)
            End If
            .DataSource = dtDatos
            .DisplayMember = "descripcion"
            .ValueMember = "concentracion"
            .EndUpdate()

        End With

    End Sub

    Private Sub dtgEquivalente_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgEquivalente.CellContentClick

    End Sub

    Private Sub txtJustificacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtJustificacion.KeyPress
        If e.KeyChar = ">" Or e.KeyChar = "<" Then
            ''SendKeys.Send("{TAB }")
            e.Handled = True

        End If
    End Sub

    Private Sub txtCodDiagn_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodDiagn.TextChanged

    End Sub

    Private Sub txtdescDiagn_ActualizarDatosElegidos(ByVal datosElegidos As System.Data.DataRow) Handles txtdescDiagn.ActualizarDatosElegidos
        With datosElegidos
            Clasificacion = .Item("clasificacion").ToString
        End With
    End Sub

    Private Sub frmc_JustificaExcepcion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ''LimpiarControles()
    End Sub


    Private Sub frmc_JustificaExcepcion_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        ''LimpiarControles()
        txtCodDiagn.ControlComboEnlace = txtdescDiagn
        With txtdescDiagn
            .CampoMostrar = "descripcion"
            .ControlTextoEnlace = txtCodDiagn
            .CampoEnlazado = "codigo"
            .CategoriaDatos = CategoriaDatos.Diagnosticos
            .CargarDatos()
            .CargarButton()
        End With
    End Sub

    Private Sub txtCodMed_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodMed.Validating
        If Len(Trim(txtCodMed.Text)) > 0 Then
            BuscarMedicamento()
        End If
    End Sub

    Private Function lF_sDireccionIP() As String
        Dim query As New System.Management.ManagementObjectSearcher("Select * From WIN32_NetworkAdapterConfiguration Where IPEnabled = 'TRUE'")
        Dim queryCollection As System.Management.ManagementObjectCollection = query.Get()
        Dim mo As New System.Management.ManagementObject
        Dim strIPAddress As String = ""
        For Each mo In queryCollection
            Dim strAddresses() As String = CType(mo("IPAddress"), String())
            For Each strIPAddress In strAddresses
                Exit For
            Next
            If strIPAddress <> "" Then Exit For
        Next
        '--Liberando Memoria--
        query.Dispose()
        query = Nothing
        queryCollection.Dispose()
        queryCollection = Nothing
        mo.Dispose()
        mo = Nothing
        '---------------------
        Return strIPAddress
    End Function

  
End Class
