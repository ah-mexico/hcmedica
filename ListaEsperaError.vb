'**HDCPCEF (Habilitar - Deshabilitar Código Para Corrección Examen Fisico**
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class ListaEsperaError

    Private objDatosGenerales As Generales
    Private objDatosPaciente As Paciente
    Private objConexion As Conexion
    Private strProcedimientoConseguirDatos As String
    Private strOpcion As String
    Private dtClearDatos As New DataTable
    Private blnHistoriaPendiente As Boolean
    Private blnCrearEncabezadoHC As Boolean
    Private blnLimpiarDatosSucursal As Boolean = True
    Private blnEntraAdmisionSucursal As Boolean = False

    Public Sub New()

        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        SetStyle(ControlStyles.UserPaint, True)
        ' This call is required by the Windows Form Designer.

        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub ListaEspera_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim objLocal As New Sophia.HistoriaClinica.DAO.DAOGeneral


        objDatosGenerales = Generales.Instancia
        objDatosPaciente = Paciente.Instancia
        objConexion = Conexion.Instancia

        CrearOrigenDeDatosLimpio()
        dtgLista.DataSource = dtClearDatos
        ConfigurarGrilla()


        With txtCodigoSucursal
            .NombreCampoBusqueda = "cod_sucur"
            .NombreCampoBuscado = "descripcion"
            .ControlTextoEnlace = cboSucursal
        End With
        With cboSucursal
            .NombreCampoDatos = "descripcion"
            .ControlTextoEnlace = txtCodigoSucursal
            .OrigenDeDatos = objLocal.EjecutarSQLConParametros("gensucur", objConexion, "cod_sucur, descripcion", "cod_sucur in ('0138', '0139', '0017')")
            .CargarDatosDescripcion()
        End With

        With txtCodigoTipoDocumento
            .NombreCampoBusqueda = "tip_doc"
            .NombreCampoBuscado = "descripcion"
            .ControlTextoEnlace = txtDescTipoDocumento
        End With
        With txtDescTipoDocumento
            .NombreCampoDatos = "descripcion"
            .ControlTextoEnlace = txtCodigoTipoDocumento
            .OrigenDeDatos = objLocal.EjecutarSQLConParametros("gentipdo", objConexion, "tip_doc, descripcion", "")
            .CargarDatosDescripcion()
        End With

        dtFecIni.ResetText()
        dtFecFin.ResetText()

        If objDatosGenerales.MedicoRealizaCorreccion = "S" Then
            HistoriasIniciales()
        End If

        HabilitarControles(True)
    End Sub

    Private Sub HistoriasIniciales()
        Dim Datos() As Object = Nothing
        Dim lError As Long
        Dim intRow As Integer
        Dim dtDatosLista As New DataTable
        Dim objConseguirDatos As New Sophia.HistoriaClinica.DAO.DAOGeneral


        ReDim Datos(28)
        Datos(0) = 4
        Datos(1) = objDatosGenerales.Prestador
        Datos(2) = ""
        Datos(3) = ""
        Datos(4) = 0
        Datos(5) = 0
        Datos(6) = ""
        Datos(7) = ""
        Datos(8) = ""
        Datos(9) = ""
        For intRow = 10 To 25
            Datos(intRow) = ""
        Next
        Datos(26) = objDatosGenerales.MedicoRealizaCorreccion
        Datos(27) = objDatosGenerales.Login
        Datos(28) = lError

        Try
            Me.Cursor = Cursors.WaitCursor
            dtDatosLista = objConseguirDatos.EjecutarSPConParametros("HC_CorregirExamenFisico", objConexion, lError, Datos)
            If lError = 9999 Then
                MessageBox.Show("No Existen Datos Para Esta Consulta")
            Else
                If dtDatosLista.Rows.Count = 0 Then
                    MessageBox.Show("No Existen Datos Para Esta Consulta")
                Else
                    Me.dtgLista.Enabled = True
                    Me.dtgLista.DataSource = dtDatosLista
                    dtgLista.Sort(dtgLista.Columns("nombre"), System.ComponentModel.ListSortDirection.Ascending)
                    ConfigurarGrilla()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            'Implementar
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub HabilitarControles(ByVal blnHabilitado As Boolean, Optional ByVal strGrupo As String = "")

        cmdLista.Enabled = True
        txtCodigoTipoDocumento.Enabled = True
        txtDescTipoDocumento.Enabled = True
        txtNumeroDocumento.Enabled = True
        txtTipoAdmision.Enabled = True
        txtAnoAdmision.Enabled = True
        txtNumeroAdmision.Enabled = True

    End Sub

    Private Sub LimpiarDatosPersonales()
        txtCodigoTipoDocumento.ResetText()
        txtDescTipoDocumento.ResetText()
        txtNumeroDocumento.ResetText()
        txtTipoAdmision.ResetText()
        txtAnoAdmision.ResetText()
        txtNumeroAdmision.ResetText()
    End Sub

    Private Sub LimpiarDatosSucursal()
        cboSucursal.ResetText()
        txtCodigoSucursal.ResetText()
        dtFecIni.ResetText()
        dtFecFin.ResetText()
    End Sub

    Private Sub ValidarTextosDocumentoAdmision(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumeroDocumento.KeyDown, txtNumeroAdmision.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmdLista.Focus()
        End If
    End Sub

    Private Sub TextosBuscador_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTipoAdmision.TextChanged, txtNumeroDocumento.TextChanged, txtNumeroAdmision.TextChanged, txtDescTipoDocumento.TextChanged, txtCodigoTipoDocumento.TextChanged, txtAnoAdmision.TextChanged

        Dim blnTextoBusqueda As Boolean
        If sender.Text.Trim.Length > 0 Then
            cmdLista.Enabled = True
        Else
            Dim ctlControl As Control

            For Each ctlControl In Me.gbDatos.Controls
                If TypeOf ctlControl Is TextBox Then
                    If ctlControl.Text.Trim.Length > 0 Then
                        blnTextoBusqueda = True
                        Exit For
                    End If
                End If
            Next


            cmdLista.Enabled = True
        End If

    End Sub

    Private Sub cmdLista_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLista.Click
        Dim dtDatosLista As New DataTable
        Dim objConseguirDatos As New Sophia.HistoriaClinica.DAO.DAOGeneral
        Dim lError As Long
        Dim Datos() As Object = Nothing
        Dim intRow As Integer
        Dim intDatoCompletoDoc As Integer
        Dim intDatoCompletoAdm As Integer
        Dim intSucursal As Integer

        If Me.rbtConsultaOpcionDocumento.Checked = False Then
            txtCodigoTipoDocumento.ResetText()
            txtDescTipoDocumento.ResetText()
            txtNumeroDocumento.ResetText()
        End If

        If Me.rbtConsultaOpcionAdmision.Checked = False Then
            txtTipoAdmision.ResetText()
            txtAnoAdmision.ResetText()
            txtNumeroAdmision.ResetText()
        End If

        If Me.rbtConsultaOpcionSucursal.Checked = False Then
            dtFecIni.ResetText()
            dtFecFin.ResetText()
            If Me.rbtConsultaOpcionAdmision.Checked = False Then
                cboSucursal.ResetText()
            End If
        End If

        blnLimpiarDatosSucursal = True

        If (Me.txtCodigoTipoDocumento.Text.Trim.Length > 0) Then
            intDatoCompletoDoc += 1
        End If
        If (Me.txtNumeroDocumento.Text.Trim.Length > 0) Then
            intDatoCompletoDoc += 1
        End If

        If (Me.txtTipoAdmision.Text.Trim.Length > 0) Then
            intDatoCompletoAdm += 1
        End If
        If (Me.txtAnoAdmision.Text.Trim.Length > 0) Then
            intDatoCompletoAdm += 1
        End If
        If (Me.txtNumeroAdmision.Text.Trim.Length > 0) Then
            intDatoCompletoAdm += 1
        End If


        If intDatoCompletoDoc = 1 Then
            MessageBox.Show("Datos Incompletos")
            If (Me.txtCodigoTipoDocumento.Text.Trim.Length = 0) Then
                Me.txtCodigoTipoDocumento.Focus()
            Else
                Me.txtNumeroDocumento.Focus()
            End If
            Exit Sub
        End If

        If intDatoCompletoAdm > 0 And intDatoCompletoAdm < 3 Then
            MessageBox.Show("Datos Incompletos")
            If (Me.txtTipoAdmision.Text.Trim.Length = 0) Then
                Me.txtTipoAdmision.Focus()
            ElseIf (Me.txtAnoAdmision.Text.Trim.Length = 0) Then
                Me.txtAnoAdmision.Focus()
            ElseIf (Me.txtNumeroAdmision.Text.Trim.Length = 0) Then
                Me.txtNumeroAdmision.Focus()
            End If
            Exit Sub
        End If

        If intDatoCompletoDoc = 0 And intDatoCompletoAdm = 0 And cboSucursal.Text.Trim.Length = 0 And objDatosGenerales.MedicoRealizaCorreccion <> "S" Then
            MessageBox.Show("Debe Seleccionar La Sucursal")
            Exit Sub
        End If

        If intDatoCompletoDoc = 0 And intDatoCompletoAdm = 0 And cboSucursal.Text.Trim.Length > 0 Then
            If (dtFecIni.Text = "  /  /" Or dtFecFin.Text = "  /  /") Then
                MessageBox.Show("Debe Seleccionar Rango de Fechas para la Consulta")
                If dtFecIni.Text = "  /  /" Then
                    dtFecIni.Focus()
                ElseIf dtFecFin.Text = "  /  /" Then
                    dtFecFin.Focus()
                End If
                Exit Sub
            End If
        End If

        If cboSucursal.Text.Trim.Length > 0 And dtFecIni.Text <> "  /  /" And dtFecFin.Text <> "  /  /" Then
            intSucursal = 1
            blnLimpiarDatosSucursal = False
        End If

        If intDatoCompletoDoc = 2 Then
            LimpiarDatosSucursal()
            txtTipoAdmision.ResetText()
            txtNumeroAdmision.ResetText()
            txtAnoAdmision.ResetText()
        End If

        If intDatoCompletoAdm = 3 And intDatoCompletoDoc < 2 Then
            'LimpiarDatosSucursal()
            txtCodigoTipoDocumento.ResetText()
            txtDescTipoDocumento.ResetText()
            txtNumeroDocumento.ResetText()
            If cboSucursal.Text.Trim.Length = 0 Then
                MessageBox.Show("Debe Seleccionar La Sucursal")
                cboSucursal.Focus()
                Exit Sub
            Else
                intSucursal = 1
                blnEntraAdmisionSucursal = True
            End If
        End If

        If intSucursal = 1 And intDatoCompletoAdm < 3 Then
            LimpiarDatosPersonales()
        End If

        ReDim Datos(28)
        Datos(0) = 4
        Datos(1) = objDatosGenerales.Prestador
        Datos(2) = IIf(intSucursal = 1, txtCodigoSucursal.Text, "")
        Datos(3) = IIf(intDatoCompletoAdm = 3 And intDatoCompletoDoc < 2, txtTipoAdmision.Text, "")
        Datos(4) = IIf(intDatoCompletoAdm = 3 And intDatoCompletoDoc < 2, txtAnoAdmision.Text, 0)
        Datos(5) = IIf(intDatoCompletoAdm = 3 And intDatoCompletoDoc < 2, txtNumeroAdmision.Text, 0)
        Datos(6) = IIf(intDatoCompletoDoc = 2, txtCodigoTipoDocumento.Text, "")
        Datos(7) = IIf(intDatoCompletoDoc = 2, txtNumeroDocumento.Text, "")
        If intSucursal = 1 And intDatoCompletoAdm < 3 Then
            Datos(8) = Format(CDate(dtFecIni.Text), "yyyy/MM/dd")
            Datos(9) = Format(CDate(dtFecFin.Text), "yyyy/MM/dd")
        Else
            Datos(8) = ""
            Datos(9) = ""
        End If
        For intRow = 10 To 25
            Datos(intRow) = ""
        Next
        Datos(26) = objDatosGenerales.MedicoRealizaCorreccion
        Datos(27) = objDatosGenerales.Login
        Datos(28) = lError

        Try
            Me.Cursor = Cursors.WaitCursor
            dtDatosLista = objConseguirDatos.EjecutarSPConParametros("HC_CorregirExamenFisico", objConexion, lError, Datos)
            If lError = 9999 Then
                MessageBox.Show("No Existen Datos Para Esta Consulta")
            Else
                If dtDatosLista.Rows.Count = 0 Then
                    MessageBox.Show("No Existen Datos Para Esta Consulta")
                Else
                    Me.dtgLista.Enabled = True
                    Me.dtgLista.DataSource = dtDatosLista
                    dtgLista.Sort(dtgLista.Columns("nombre"), System.ComponentModel.ListSortDirection.Ascending)
                    ConfigurarGrilla()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            'Implementar
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ConfigurarGrilla()
        dtgLista.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
    End Sub

    Private Sub dtgLista_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgLista.CellClick
        EditarValores(dtgLista.CurrentRow)
    End Sub

    Private Sub CrearOrigenDeDatosLimpio()
        Dim dr As DataRow
        With dtClearDatos
            .Columns.Add("tip_doc", System.Type.GetType("System.String"))
            .Columns.Add("num_doc", System.Type.GetType("System.String"))
            .Columns.Add("nombre", System.Type.GetType("System.String"))
            .Columns.Add("admision", System.Type.GetType("System.String"))
            .Columns.Add("fec_hc", System.Type.GetType("System.String"))
            .Columns.Add("cod_pre_sgs", System.Type.GetType("System.String"))
            .Columns.Add("cod_sucur", System.Type.GetType("System.String"))
            .Columns.Add("tip_admision", System.Type.GetType("System.String"))
            .Columns.Add("ano_adm", System.Type.GetType("System.String"))
            .Columns.Add("num_adm", System.Type.GetType("System.String"))
            .Columns.Add("estado", System.Type.GetType("System.String"))
            .Columns.Add("fec_con", System.Type.GetType("System.String"))
            .Columns.Add("login", System.Type.GetType("System.String"))
            dr = dtClearDatos.NewRow()
            .Rows.Add(dr)
        End With

    End Sub

    Private Sub EditarValores(ByVal dtRow As DataGridViewRow)
        txtCodigoTipoDocumento.Text = dtRow.Cells("tip_doc").Value.ToString
        txtDescTipoDocumento.Text = txtCodigoTipoDocumento.DescripcionCodigo
        txtNumeroDocumento.Text = dtRow.Cells("num_doc").Value.ToString
        txtTipoAdmision.Text = dtRow.Cells("tip_admision").Value.ToString
        txtAnoAdmision.Text = dtRow.Cells("ano_adm").Value.ToString
        txtNumeroAdmision.Text = dtRow.Cells("num_adm").Value.ToString
        txtCodigoSucursal.Text = dtRow.Cells("cod_sucur").Value.ToString
        cboSucursal.Text = txtCodigoSucursal.DescripcionCodigo
    End Sub

    Private Sub TraerPacienteListaEspera()
        Dim dtDatosPaciente As New DataTable
        Dim objConseguirDatos As New BLHistoriaBasica
        Dim lError As Long
        Dim Datos() As Object = Nothing

        Try
            Me.Cursor = Cursors.WaitCursor
            dtDatosPaciente = objConseguirDatos.ConsultarDatosPacientes(strProcedimientoConseguirDatos, objConexion, lError, Datos)
            If lError = 9999 Then
                MessageBox.Show("No Existen Datos Para Esta Consulta")
            Else
                Me.dtgLista.Enabled = True
                Me.dtgLista.DataSource = dtDatosPaciente
                ConfigurarGrilla()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub AlmacenarInformacionPaciente(ByVal dRow As DataGridViewRow)

        Dim objConseguirDatos As New BLBasicasLocales
        Dim objConseguirDatosS As New BLHistoriaBasica



        With objDatosPaciente
            .TipoDocumento = dRow.Cells("tip_doc").Value.ToString
            Try
                .DescripcionTipoDocumento = objConseguirDatos.TraerDatosTablasBasicasLocales(objDatosGenerales.CadenaLocal, "gentipdo", "descripcion", "tip_doc='" & dRow.Cells("tip_doc").Value.ToString & "'").Rows(0)("descripcion").ToString
            Catch ex As Exception
                .DescripcionTipoDocumento = ""
            End Try
            .NumeroDocumento = dRow.Cells("num_doc").Value.ToString
            .PrimerApellido = dRow.Cells("pri_ape").Value.ToString
            .SegundoApellido = dRow.Cells("seg_ape").Value.ToString
            .PrimerNombre = dRow.Cells("pri_nom").Value.ToString
            .SegundoNombre = dRow.Cells("seg_nom").Value.ToString
            .TipoAdmision = dRow.Cells("tip_admision").Value.ToString
            .AnoAdmision = Val(dRow.Cells("ano_adm").Value.ToString)
            .NumeroAdmision = Val(dRow.Cells("num_adm").Value.ToString)
            .FechaHistoriaClinica = dRow.Cells("fec_hc").Value.ToString
            .EstadoInstancia = True
        End With

    End Sub

    Private Sub AbrirHistoriaClinica()


        Dim intRow As Integer
        Dim dtDatos As New DataTable
        Dim dtRows() As DataRow

        If dtgLista.CurrentRow Is Nothing Then
            MessageBox.Show("Seleccione un Registro de la Lista", "Lista de Espera", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        AlmacenarInformacionPaciente(dtgLista.CurrentRow)

        If ConsultarAdmisionesConEF_Errado() = True Then
            frmCorreccionEF_tmp.Mostrar()
            dtDatos = dtgLista.DataSource
            For intRow = 0 To objDatosPaciente.HistoriasConErroresEF.Rows.Count - 1
                If objDatosPaciente.HistoriasConErroresEF.Rows(intRow).Item("estado").ToString = "M" Then
                    dtRows = dtDatos.Select("cod_pre_sgs='" & dtgLista.CurrentRow.Cells("cod_pre_sgs").Value & "' AND cod_sucur='" & dtgLista.CurrentRow.Cells("cod_sucur").Value & _
                                          "' AND tip_admision='" & dtgLista.CurrentRow.Cells("tip_admision").Value & "' AND ano_adm=" & dtgLista.CurrentRow.Cells("ano_adm").Value & _
                                          " AND num_adm=" & dtgLista.CurrentRow.Cells("num_adm").Value & " AND tip_doc='" & dtgLista.CurrentRow.Cells("tip_doc").Value & _
                                           "' AND num_doc='" & dtgLista.CurrentRow.Cells("num_doc").Value & "'")
                    dtDatos.Rows.Remove(dtRows(0))
                End If
            Next
            If dtDatos.Rows.Count > 0 Then
                dtgLista.DataSource = dtDatos
            Else
                dtgLista.DataSource = dtClearDatos
            End If
            If blnLimpiarDatosSucursal = True Then
                LimpiarDatosSucursal()
            End If
            LimpiarDatosPersonales()
        Else
            MessageBox.Show("La Historia Clínica seleccionada ya fue corregida.", "Reclasificación Examen Físico", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dtgLista.Rows.Remove(dtgLista.CurrentRow)
        End If


    End Sub

    Private Sub dtgLista_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgLista.CellDoubleClick
        AbrirHistoriaClinica()
    End Sub

    Private Sub dtFecIni_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtFecIni.Validating
        If dtFecIni.Text <> "  /  /" Then
            If Not IsDate(dtFecIni.Text) Then
                MsgBox("Fecha invalida. Debe digitar una fecha valida.", MsgBoxStyle.Information)
                e.Cancel = True
                dtFecIni.Select(0, dtFecIni.TextLength)
                Exit Sub
            End If
            If dtFecFin.Text <> "  /  /" Then
                If IsDate(dtFecFin.Text) Then
                    If (CDate(dtFecFin.Text) - CDate(dtFecIni.Text)).Days > 30 Then
                        MsgBox("Rango de Fechas es muy grande. Seleccione un rango máximo de 30 días.", MsgBoxStyle.Information)
                        e.Cancel = True
                        dtFecFin.Select(0, dtFecFin.TextLength)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub dtFecFin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtFecFin.KeyPress, dtFecIni.KeyPress
        ValidaKeyPress(sender, e)
    End Sub

    Private Sub dtFecFin_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtFecFin.Validating
        If dtFecFin.Text <> "  /  /" Then
            If Not IsDate(dtFecFin.Text) Then
                MsgBox("Fecha invalida. Debe digitar una fecha valida.", MsgBoxStyle.Information)
                e.Cancel = True
                dtFecFin.Select(0, dtFecIni.TextLength)
            Else
                If dtFecIni.Text = "  /  /" Then
                    MsgBox("Debe digitar una fecha valida para la Fecha Inicial", MsgBoxStyle.Information)
                    dtFecFin.Select(0, dtFecIni.TextLength)
                    dtFecIni.Focus()
                    Exit Sub
                End If
                If Not CDate(dtFecFin.Text) >= CDate(dtFecIni.Text) Then
                    MsgBox("Fecha invalida. Debe digitar una fecha valida.", MsgBoxStyle.Information)
                    e.Cancel = True
                    dtFecFin.Select(0, dtFecIni.TextLength)
                Else
                    If (CDate(dtFecFin.Text) - CDate(dtFecIni.Text)).Days > 30 Then
                        MsgBox("Rango de Fechas es muy grande. Seleccione un rango máximo de 30 días.", MsgBoxStyle.Information)
                        e.Cancel = True
                        dtFecFin.Select(0, dtFecFin.TextLength)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub ValidaKeyPress(ByRef MyControl As Control, ByVal s As KeyPressEventArgs)
        If Len(MyControl.Tag) > 0 Then
            If Mid(MyControl.Tag, 1, 1) = "N" Then
                If Not Regex.IsMatch(s.KeyChar, "[0-9]") Then
                    s.Handled = True
                End If
            ElseIf Mid(MyControl.Tag, 1, 1) = "L" Then
                If Not Regex.IsMatch(s.KeyChar, "[a-zA-Z]") Then
                    s.Handled = True
                End If
            Else
                s.Handled = True
            End If
        End If

        Select Case s.KeyChar
            Case Convert.ToChar(Keys.Return)
                If MyControl.Name.ToUpper = "dtFecFin".ToUpper Then
                    cmdLista.Focus()
                Else
                    SendKeys.Send("{TAB}")
                End If

                s.Handled = True
        End Select
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        dtgLista.DataSource = dtClearDatos
        LimpiarDatosSucursal()
        LimpiarDatosPersonales()
        cboSucursal.Focus()
    End Sub

    Private Function ConsultarAdmisionesConEF_Errado() As Boolean
        Dim objDAOGeneral As New Sophia.HistoriaClinica.DAO.DAOGeneral
        Dim dtDatos As DataTable
        Dim strCondicion As String
        Dim blnRespuesta As Boolean
        Dim strCondicionAdmision As String
        Dim intOrden As Integer
        '' ''Dim dtRowOrd() As DataRow
        '' ''Dim dtTable As DataTable
        '' ''Dim dtRow As DataRow
        '' ''Dim datFecha As Date
        Dim blnAdmisionExiste As Boolean = False

        If blnEntraAdmisionSucursal = True Then
            strCondicionAdmision = "tip_admision='" & objDatosPaciente.TipoAdmision & "' AND " & _
                                   "ano_adm=" & objDatosPaciente.AnoAdmision & " AND num_adm=" & objDatosPaciente.NumeroAdmision & _
                                   " AND cod_sucur='" & txtCodigoSucursal.Text & "' AND "
        Else
            strCondicionAdmision = ""
        End If


        strCondicion = strCondicionAdmision & "tip_doc='" & objDatosPaciente.TipoDocumento & "' AND " & _
                       "num_doc='" & objDatosPaciente.NumeroDocumento & "' AND estado='E'"

        If objDatosGenerales.MedicoRealizaCorreccion = "S" Then
            strCondicion = strCondicion & " AND login='" & objDatosGenerales.Login & "'"
        End If

        dtDatos = objDAOGeneral.EjecutarSQLConParametros("hcCorreccion with  (NOLOCK)", objConexion, "cod_pre_sgs, cod_sucur, tip_admision, ano_adm, num_adm, tip_doc, num_doc, login_egreso, estado, fec_hc, fec_con, " & objDatosGenerales.Login & " as login, obs, 0 as Orden, login as login_original", strCondicion)


        If dtDatos.Rows.Count > 0 Then
            For intOrden = 0 To dtDatos.Rows.Count - 1
                With dtgLista.CurrentRow
                    If dtDatos.Rows(intOrden).Item("tip_admision") = .Cells("tip_admision").Value And _
                       dtDatos.Rows(intOrden).Item("ano_adm") = .Cells("ano_adm").Value And _
                       dtDatos.Rows(intOrden).Item("num_adm") = .Cells("num_adm").Value Then
                        dtDatos.Rows(intOrden).Item("orden") = 1
                        blnAdmisionExiste = True
                    Else
                        If Month(dtDatos.Rows(intOrden).Item("fec_hc")) = Month(.Cells("fec_hc").Value) Then
                            dtDatos.Rows(intOrden).Item("orden") = 2
                        Else
                            dtDatos.Rows(intOrden).Item("orden") = 3
                        End If
                    End If
                End With
            Next
            dtDatos.DefaultView.Sort = "Orden ASC, fec_hc ASC"
        End If

        If blnAdmisionExiste = True Then
            blnRespuesta = dtDatos.DefaultView.Table.Rows.Count > 0

            If blnRespuesta = True Then
                objDatosPaciente.HistoriasConErroresEF = dtDatos.DefaultView.ToTable
            End If
        End If

        Return blnRespuesta

    End Function





    Private Sub ClickOpcionConsulta(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtConsultaOpcionSucursal.Click, rbtConsultaOpcionDocumento.Click, rbtConsultaOpcionAdmision.Click

        Panel1.Enabled = False
        Panel2.Enabled = False
        Panel3.Enabled = False

        cboSucursal.ResetText()
        dtFecIni.ResetText()
        dtFecFin.ResetText()
        txtCodigoTipoDocumento.ResetText()
        txtDescTipoDocumento.ResetText()
        txtNumeroDocumento.ResetText()
        txtTipoAdmision.ResetText()
        txtNumeroAdmision.ResetText()
        txtAnoAdmision.ResetText()

        dtgLista.DataSource = dtClearDatos

        Select Case sender.name.ToString.ToUpper
            Case "RBTCONSULTAOPCIONSUCURSAL"
                Panel1.Enabled = True
                dtFecIni.Enabled = True
                dtFecFin.Enabled = True
                cboSucursal.Focus()
            Case "RBTCONSULTAOPCIONDOCUMENTO"
                Panel2.Enabled = True
                txtCodigoTipoDocumento.Focus()
            Case "RBTCONSULTAOPCIONADMISION"
                Panel1.Enabled = True
                dtFecIni.Enabled = False
                dtFecFin.Enabled = False
                Panel3.Enabled = True
                txtTipoAdmision.Focus()
        End Select

    End Sub


End Class
'**/