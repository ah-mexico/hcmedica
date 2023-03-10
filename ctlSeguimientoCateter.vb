Imports System.IO
Imports System.Collections.Generic
Imports System.Data.DataTable
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.HistoriaBasica
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Public Module variablesseg 'Santiago Balcero Se definen variables globales para captura
    Public fechasegcat As DateTime,
           estadositcod As String,
           estadositdes As String,
           severificacod As String,
           severificades As String,
           hacecuracion As String,
           elecuracioncod As String,
           elecuraciondes As String,
           gestionfinalcod As String,
           gestionfinaldes As String,
           motivoretcod As String,
           motivoretdes As String,
           dtsegcateter As New DataTable("dtsegcateter"),
           vfec_con As DateTime,
           vdiacateter As String,
           vcodestsitins As String,
           vestsitins As String,
           vvalcuracion As String,
           vcodCuracion As String,
           vcuracion As String,
           vcodverifica As String,
           vverifica As String,
           vcodgestionf As String,
           vgestionf As String,
           vcodmotivoret As String,
           vmotivoret As String,
           vestadoreg As String,
           vresponsable As String,
           vespecialidad As String,
           vchc As Boolean
End Module
Public Class ctlSeguimientoCateter

#Region "Propiedades"
    Private Shared _Instancia As ctlSeguimientoCateter
    Private objGeneral As Generales
    Private objPaciente As Paciente
    Private objDAOEnfermeria As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOEnfermeriaCP
    Private objCateter As New RegistroCateter
    Private myParent As ctlCPEnfermeria
    Private cadenaFechaVacia As String = "/  /"
    Private objDtGestionCateter As DataTable
    Private objGestionCateteres As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOEnfermeriaCP
    Dim swg As Integer
    Public bActivarControles As Boolean = False

#End Region

#Region "Instancia de Control"

    Public Shared ReadOnly Property Instancia() As ctlSeguimientoCateter
        Get
            If _Instancia Is Nothing Then
                _Instancia = New ctlSeguimientoCateter
            End If
            Return _Instancia
        End Get
    End Property

#End Region

#Region "Events"
    Private Sub ctlSeguimientoCateter_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged
        objGeneral = Generales.Instancia
        objPaciente = Paciente.Instancia
        CargarDataGridView()
        btnAgSeg.Enabled = bActivarControles
        BtnGuardar.Enabled = bActivarControles
    End Sub
    Private Sub ctlSeguimientoCateter_Load(sender As Object, e As EventArgs) Handles Me.Load
        objGeneral = Generales.Instancia
        objPaciente = Paciente.Instancia
        swg = 0
        vresponsable = objGeneral.Login
        'vespecialidad = objGestionCateteres.ConsultarEspecialidad(3, Generales.Instancia.Prestador,
        '                                                             Generales.Instancia.Sucursal,
        '                                                             objGeneral.Login)
        vespecialidad = objGeneral.DescripcionEspecialidad  ''Descripcion Especialidad del que se loguea

        limpiar_camposseguimiento()
        activacion_controles(False)
        cargar_campos()
        ValidaCierreHC()
        btnAgSeg.Enabled = bActivarControles
        BtnGuardar.Enabled = bActivarControles
    End Sub

    Private Sub btnAgSeg_Click(sender As Object, e As EventArgs) Handles btnAgSeg.Click
        variablesseg.vestadoreg = "A"
        frmAgregarSeguimiento.ShowDialog()
        dtgsegcateter.CurrentCell = dtgsegcateter.Rows(dtgsegcateter.RowCount - 1).Cells(0)
    End Sub
    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        GuardarSeguimientoCateter()
        cargar_campos()
        swg = 1
        Me.ParentForm.Close()
    End Sub

    'Private Sub dtgsegcateter_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgsegcateter.CellClick
    '    'Santiago Balcero, Boton de eliminacion y modificacion
    '    Dim frmModalOpercionesCateter As New frmOperacionesCateter
    '    If e.ColumnIndex <> -1 Then
    '        If (dtgsegcateter.Columns(e.ColumnIndex).Name = "btneliminar") Then
    '            If dtgsegcateter.Rows(e.RowIndex).Cells("EstadoReg").Value.ToString <> Nothing Then
    '                If dtgsegcateter.Rows(e.RowIndex).Cells("EstadoReg").Value = "A" Then
    '                    If dtgsegcateter.Rows(e.RowIndex).Cells("codgestionf").Value.ToString <> Nothing Then

    '                        If dtgsegcateter.Rows(e.RowIndex).Cells("codgestionf").Value = "97201" Then
    '                            btnAgSeg.Enabled = True
    '                        End If
    '                    End If
    '                    dtgsegcateter.Rows.Remove(dtgsegcateter.CurrentRow)
    '                End If
    '            End If
    '        End If
    '    End If
    'End Sub
    'Private Sub cmbTipoCateterSeg_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Dim dt As New DataTable
    '    chkListPresentaSignos.ResetText()
    '    chkListPresentaSignos.BeginUpdate()
    '    If IsNothing(cmbTipoCateterSeg.SelectedValue) Then
    '        dt = Nothing
    '    Else
    '        If cmbTipoCateterSeg.SelectedValue.ToString() = "92001" Then
    '            dt = objDAOEnfermeria.CargarCombo(5, "S")
    '        Else
    '            dt = objDAOEnfermeria.CargarCombo(5, "I")
    '        End If
    '    End If

    '    If Not IsNothing(dt) Then
    '        If dt.Rows.Count = 0 Then
    '            MsgBox("No existen signos presentados parametrizados.")
    '        End If
    '    End If
    '    chkListPresentaSignos.DataSource = dt
    '    If Not IsNothing(dt) Then
    '        chkListPresentaSignos.DisplayMember = "descripcion"
    '        chkListPresentaSignos.ValueMember = "Id"
    '    End If
    '    chkListPresentaSignos.EndUpdate()
    '    LimpiarCheckListBox(chkListPresentaSignos)

    'End Sub

    'Private Sub rbSiCuracion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    chkListElemCuracion.Enabled = rbSiCuracion.Checked
    'End Sub

    'Private Sub rbNoCuracion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    chkListElemCuracion.Enabled = Not rbNoCuracion.Checked
    'End Sub

    'Private Sub chkListPresentaSignos_ItemCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs)
    '    Dim indice As Integer
    '    If cmbTipoCateterSeg.SelectedValue.ToString() = "92001" Then
    '        indice = chkListPresentaSignos.FindStringExact("")
    '    Else
    '        indice = chkListPresentaSignos.FindStringExact("Sin signos de flebitis")
    '        ManejoCamposCheckBoxList(chkListPresentaSignos, indice, e)
    '    End If
    'End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    If (Not ValidarFechas()) Then
    '        Exit Sub
    '    End If
    '    GuardarSeguimientoCateter()
    'End Sub
#End Region

    '#Region "Functions"

    'Private Sub CargarCombos()
    '    Dim dt As New DataTable
    '    Try
    '        cmbTipoCateterSeg.ResetText()
    '        cmbTipoCateterSeg.BeginUpdate()
    '        dt = objDAOEnfermeria.CargarCombo(2, "S")

    '        If dt.Rows.Count = 0 Then
    '            MsgBox("No existen tipos de catéter parametrizados.")
    '        End If
    '        cmbTipoCateterSeg.DataSource = dt

    '        cmbTipoCateterSeg.DisplayMember = "descripcion"
    '        cmbTipoCateterSeg.ValueMember = "Id"
    '        cmbTipoCateterSeg.EndUpdate()
    '        cmbTipoCateterSeg.SelectedValue = -1

    '        dt = Nothing

    '        chkListElemCuracion.ResetText()
    '        chkListElemCuracion.BeginUpdate()
    '        dt = objDAOEnfermeria.CargarCombo(6)

    '        If dt.Rows.Count = 0 Then
    '            MsgBox("No existen indicaciones del catéter parametrizadas.")
    '        End If
    '        chkListElemCuracion.DataSource = dt

    '        chkListElemCuracion.DisplayMember = "descripcion"
    '        chkListElemCuracion.ValueMember = "Id"
    '        chkListElemCuracion.EndUpdate()

    '    Catch ex As Exception
    '        Throw (ex)
    '    End Try

    'End Sub

    'Private Sub LimpiarCampos()
    '    Me.mskFecInsercion.Text = String.Empty
    '    Me.mskFecCuracion.Text = String.Empty
    '    Me.cmbTipoCateterSeg.SelectedValue = -1
    '    LimpiarCheckListBox(Me.chkListElemCuracion)
    '    LimpiarCheckListBox(Me.chkListPresentaSignos)
    '    Me.rbNoCuracion.Checked = False
    '    Me.rbSiCuracion.Checked = False
    '    objCateter = New RegistroCateter
    'End Sub

    'Private Function ValidarFechas() As Boolean
    '    Dim esValido As Boolean = True
    '    Dim fechaInsercion As Date
    '    Dim fechaCuracion As Date
    '    Dim formatoFecha As String = "dd/MM/yyyy"
    '    Try
    '        If Me.mskFecInsercion.Text.Trim().Length > 0 And Me.mskFecInsercion.Text.Trim() <> cadenaFechaVacia Then
    '            fechaInsercion = Date.ParseExact(Me.mskFecInsercion.Text.Trim(), formatoFecha, System.Globalization.DateTimeFormatInfo.InvariantInfo)
    '            If fechaInsercion > Date.Now Then
    '                MsgBox("La fecha de inserción no debe ser superior al día de hoy. Favor revisar", MsgBoxStyle.Critical)
    '                Return False
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox("La fecha de inserción no es válida. Favor revisar", MsgBoxStyle.Critical)
    '        Return False
    '    End Try

    '    Try
    '        If Me.mskFecCuracion.Text.Trim().Length > 0 And Me.mskFecCuracion.Text.Trim() <> cadenaFechaVacia Then
    '            fechaCuracion = Date.ParseExact(Me.mskFecCuracion.Text.Trim(), formatoFecha, System.Globalization.DateTimeFormatInfo.InvariantInfo)
    '            If fechaCuracion > Date.Now Then
    '                MsgBox("La fecha de curación no debe ser superior al día de hoy. Favor revisar", MsgBoxStyle.Critical)
    '                Return False
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox("La fecha de curación no es válida. Favor revisar", MsgBoxStyle.Critical)
    '        Return False
    '    End Try

    '    'If Not IsNothing(fechaInsercion) And Not IsNothing(fechaCuracion) And fechaInsercion > fechaCuracion Then
    '    '    MsgBox("La fecha de inserción no puede ser posterior a la fecha de curación. Favor revisar", MsgBoxStyle.Critical)
    '    '    Return False
    '    'End If

    '    Return True
    'End Function


#Region "Rutinas para administración y limpieza de controles"
    Private Sub activacion_controles(estado As Boolean)
        If estado = False Then
            Me.txtfecha.Enabled = False
            Me.txttipcateter.Enabled = False
            Me.txtzonains.Enabled = False
            Me.txtlateralidad.Enabled = False
            Me.txtindicaciones.Enabled = False
            Me.txtcomplicaciones.Enabled = False
            Me.txtnpuncion.Enabled = False
            Me.txtresponsable.Enabled = False
            Me.txtespecialidad.Enabled = False
            Me.btnAgSeg.Visible = False
            Me.BtnGuardar.Visible = False
        End If

    End Sub
#End Region

#Region "Fuctions"
    Private Sub LimpiarObjetos()
        fechasegcat = Nothing
        estadositcod = ""
        estadositdes = ""
        severificacod = ""
        severificades = ""
        hacecuracion = ""
        elecuracioncod = ""
        elecuraciondes = ""
        gestionfinalcod = ""
        gestionfinaldes = ""
        motivoretcod = ""
        motivoretdes = ""
        dtsegcateter = Nothing
    End Sub

    Private Sub cargar_campos()
        Me.txtfecha.Text = variables.fechacat.ToString("dd/MM/yyyy HH:mm:ss")
        Me.txttipcateter.Text = variables.tipocateter1
        Me.txtzonains.Text = variables.zoninser
        Me.txtlateralidad.Text = variables.lateral
        Me.txtindicaciones.Text = variables.Indicacion
        Me.txtcomplicaciones.Text = variables.complica
        Me.txtnpuncion.Text = variables.npuncion
        Me.txtresponsable.Text = variables.responsable1
        Me.txtespecialidad.Text = variables.especialidad1
        If variables.estcateter = 0 Then
            Me.btnAgSeg.Visible = False
            Me.BtnGuardar.Visible = False
        Else
            Me.btnAgSeg.Visible = True
            Me.BtnGuardar.Visible = True
        End If
        CargarDataGridView()
        validar_datos_grilla()
    End Sub
    Private Sub CargarDataGridView()
        ''Llamar al historico
        Try

            Dim objdg As New DataGridView
            'Dim strIP As String = ""
            'Dim strHostName As String
            'strHostName = System.Net.Dns.GetHostName()
            'strIP = System.Net.Dns.GetHostByName(strHostName).AddressList(0).ToString()

            If variables.codcateter <> Nothing Then
                objDtGestionCateter = objGestionCateteres.ConsultarSeguimientoCateter(1, Paciente.Instancia.TipoDocumento,
                                                                              Paciente.Instancia.NumeroDocumento,
                                                                              variables.codcateter,
                                                                              variables.fechacat.ToString("dd/MM/yyyy HH:mm"),
                                                                              Generales.Instancia.Prestador, Generales.Instancia.Sucursal,
                                                                              Paciente.Instancia.TipoAdmision,
                                                                              Paciente.Instancia.AnoAdmision,
                                                                              Paciente.Instancia.NumeroAdmision)

                If objDtGestionCateter.Rows.Count > 0 Or objDtGestionCateter.Rows.Count <> Nothing Then

                    dtgsegcateter.DataSource = Nothing
                    dtsegcateter = objDtGestionCateter
                    dtsegcateter.AcceptChanges()
                    objdg = New DataGridView
                    objdg.DataSource = dtsegcateter
                    dtgsegcateter.DataSource = dtsegcateter
                    dtgsegcateter.AllowUserToAddRows = False
                    dtgsegcateter.AutoGenerateColumns = False
                Else
                    Dim dc As New DataColumn("Fec_con", Type.GetType("System.String")),
                    dc1 As New DataColumn("DiaCateter", Type.GetType("System.String")),
                    dc2 As New DataColumn("CodEstSitIns", Type.GetType("System.String")),
                    dc3 As New DataColumn("EstSitIns", Type.GetType("System.String")),
                    dc4 As New DataColumn("valcuracion", Type.GetType("System.String")),
                    dc5 As New DataColumn("codCuracion", Type.GetType("System.String")),
                    dc6 As New DataColumn("Curacion", Type.GetType("System.String")),
                    dc7 As New DataColumn("codverifica", Type.GetType("System.String")),
                    dc8 As New DataColumn("verifica", Type.GetType("System.String")),
                    dc9 As New DataColumn("codgestionf", Type.GetType("System.String")),
                    dc10 As New DataColumn("gestionf", Type.GetType("System.String")),
                    dc11 As New DataColumn("CodMotivoret", Type.GetType("System.String")),
                    dc12 As New DataColumn("Motivoret", Type.GetType("System.String")),
                    dc13 As New DataColumn("EstadoReg", Type.GetType("System.String")),
                    dc14 As New DataColumn("Responsable", Type.GetType("System.String")),
                    dc15 As New DataColumn("Especialidad", Type.GetType("System.String"))
                    dtgsegcateter.DataSource = Nothing
                    dtgsegcateter.AllowUserToAddRows = True
                    dtgsegcateter.AutoGenerateColumns = False
                    dtsegcateter = New DataTable()
                    dtsegcateter.Columns.Add(dc)
                    dtsegcateter.Columns.Add(dc1)
                    dtsegcateter.Columns.Add(dc2)
                    dtsegcateter.Columns.Add(dc3)
                    dtsegcateter.Columns.Add(dc4)
                    dtsegcateter.Columns.Add(dc5)
                    dtsegcateter.Columns.Add(dc6)
                    dtsegcateter.Columns.Add(dc7)
                    dtsegcateter.Columns.Add(dc8)
                    dtsegcateter.Columns.Add(dc9)
                    dtsegcateter.Columns.Add(dc10)
                    dtsegcateter.Columns.Add(dc11)
                    dtsegcateter.Columns.Add(dc12)
                    dtsegcateter.Columns.Add(dc13)
                    dtsegcateter.Columns.Add(dc14)
                    dtsegcateter.Columns.Add(dc15)
                End If
                dtgsegcateter.Refresh()
            End If
        Catch ex As Exception
            'Throw (ex)
        End Try
    End Sub
    Private Sub ManejoCamposCheckBoxList(ByVal control As CheckedListBox, ByVal indice As Integer, ByVal e As System.Windows.Forms.ItemCheckEventArgs)
        If e.Index = indice And e.NewValue = CheckState.Checked Then
            Dim i As Integer
            For i = 0 To control.Items.Count - 1
                If i <> e.Index Then
                    control.SetItemChecked(i, False)
                    control.SetItemChecked(i, False)
                End If
            Next
        Else
            If e.NewValue = CheckState.Checked Then
                control.SetItemChecked(indice, False)
                control.SetItemChecked(indice, False)
            End If
        End If
    End Sub
    Private Sub validar_datos_grilla()
        Try
            If dtgsegcateter.Rows.Count > 0 Then
                For Each row As DataGridViewRow In dtgsegcateter.Rows
                    'If row.Cells("gestionf").Value.ToString <> Nothing Then
                    If row.Cells("gestionf").Value = "Retiro de catéter" Then
                        btnAgSeg.Enabled = False
                        Exit Sub
                    Else
                        btnAgSeg.Enabled = True
                    End If
                    'End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub limpiar_camposseguimiento()
        'vfec_con = ""
        vdiacateter = ""
        vcodestsitins = ""
        vestsitins = ""
        vvalcuracion = ""
        vcodCuracion = ""
        vcuracion = ""
        vcodverifica = ""
        vverifica = ""
        vcodgestionf = ""
        vgestionf = ""
        vcodmotivoret = ""
        vmotivoret = ""
        vestadoreg = ""
    End Sub
    Private Sub ValidaCierreHC()
        objCateter.Cod_pre_sgs = objGeneral.Prestador
        objCateter.Cod_sucur = objGeneral.Sucursal
        objCateter.Tip_admision = objPaciente.TipoAdmision
        objCateter.Ano_adm = objPaciente.AnoAdmision
        objCateter.Num_adm = objPaciente.NumeroAdmision
        vchc = Me.objDAOEnfermeria.ValidacierreHC(2, objCateter)
    End Sub
    Private Sub GuardarSeguimientoCateter()
        Dim Resultado As Boolean, fec_insertc As String
        fec_insertc = variables.fechacat.ToString("dd/MM/yyyy HH:mm")
        For Each row As DataGridViewRow In dtgsegcateter.Rows

            If Not row.Cells("Fec_con").Value Is DBNull.Value Then
                If Not row.Cells("EstadoReg").Value <> "A" Then
                    objCateter.Cod_pre_sgs = objGeneral.Prestador
                    objCateter.Cod_sucur = objGeneral.Sucursal
                    objCateter.Tip_admision = objPaciente.TipoAdmision
                    objCateter.Ano_adm = objPaciente.AnoAdmision
                    objCateter.Num_adm = objPaciente.NumeroAdmision
                    objCateter.Tip_Doc = objPaciente.TipoDocumento
                    objCateter.Num_Doc = objPaciente.NumeroDocumento
                    objCateter.Tip_Registro = "SEGUIMIENTO"
                    objCateter.Fec_Insercion = row.Cells("Fec_con").Value
                    objCateter.Dias_Cateter = Val(row.Cells("DiaCateter").Value)
                    objCateter.SignosPresentados = row.Cells("CodEstSitIns").Value
                    objCateter.RealizoCuracion = row.Cells("valcuracion").Value
                    If Not row.Cells("valcuracion").Value = "NO" Then
                        objCateter.ElementosCuracion = row.Cells("codCuracion").Value
                    End If
                    objCateter.SeVerifica = row.Cells("codverifica").Value
                    If Not row.Cells("codgestionf").Value.ToString <> Nothing Then
                        objCateter.GestionFinal = ""
                    Else
                        objCateter.GestionFinal = row.Cells("codgestionf").Value
                        If row.Cells("codgestionf").Value = "97201" Then
                            objCateter.MRetiro = row.Cells("CodMotivoret").Value
                        End If
                    End If
                    objCateter.Login = objGeneral.Login
                    objCateter.LoginMedico = objGeneral.Login
                    objCateter.Especialidad = vespecialidad
                    objCateter.Obs = String.Empty
                    objCateter.CodCateter = variables.codcateter
                    objCateter.Fec_Curacion = DateTime.Parse(fec_insertc).ToString("dd/MM/yyyy HH:mm")
                    objCateter.EsSophia = "SI"
                    Resultado = Me.objDAOEnfermeria.GuardaSeguimientoCateter(objCateter)
                End If
            End If
        Next

        If Resultado Then
            MsgBox("Información de seguimiento de catéter guardada satisfactoriamiente", MsgBoxStyle.Information)
        End If
    End Sub
    Private Function GetCheckBoxListSelections(ByVal chkListBox As CheckedListBox) As String
        Dim i As Integer
        Dim ListItems As New List(Of String)
        For i = 0 To (chkListBox.Items.Count - 1)
            If chkListBox.GetItemChecked(i) = True Then
                ListItems.Add(chkListBox.Items(i)(0).ToString.Trim)
            End If
        Next
        If ListItems.Count > 0 Then
            Return String.Join("<|^|>", ListItems.ToArray())
        Else
            Return Nothing
        End If
    End Function
    Private Sub LimpiarCheckListBox(ByVal chkListBox As CheckedListBox)
        Dim i As Integer
        For i = 0 To (chkListBox.Items.Count - 1)
            chkListBox.SetItemCheckState(i, CheckState.Unchecked)
        Next
    End Sub
    'Santiago Balcero, al oprimir tecla suprimir valida si es un seguimiento nuevo se puede eliminar
    Private Sub dtgsegcateter_KeyDown(sender As Object, e As KeyEventArgs) Handles dtgsegcateter.KeyDown
        If e.KeyCode = Keys.Delete Then
            If Convert.ToString(dtgsegcateter.Rows(dtgsegcateter.CurrentRow.Index).Cells("EstadoReg").Value) <> Nothing Then
                If Convert.ToString(dtgsegcateter.Rows(dtgsegcateter.CurrentRow.Index).Cells("EstadoReg").Value) = "A" Then
                    If Convert.ToString(dtgsegcateter.Rows(dtgsegcateter.CurrentRow.Index).Cells("codgestionf").Value) <> Nothing Then
                        If Convert.ToString(dtgsegcateter.Rows(dtgsegcateter.CurrentRow.Index).Cells("codgestionf").Value) = "97201" Then
                            btnAgSeg.Enabled = True
                        End If
                    End If
                    dtgsegcateter.Rows.Remove(dtgsegcateter.CurrentRow)
                End If
            End If
        End If
    End Sub

    Private Sub dtgsegcateter_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgsegcateter.CellDoubleClick
        If Convert.ToString(dtgsegcateter.Rows(e.RowIndex).Cells("EstadoReg").Value) <> Nothing Then
            If Convert.ToString(dtgsegcateter.Rows(e.RowIndex).Cells("EstadoReg").Value) = "A" Then
                If Convert.ToString(dtgsegcateter.Rows(e.RowIndex).Cells("codgestionf").Value) <> Nothing Then
                    If Convert.ToString(dtgsegcateter.Rows(e.RowIndex).Cells("codgestionf").Value) = "97201" Then
                        btnAgSeg.Enabled = True
                    End If
                End If
                limpiar_camposseguimiento()
                variablesseg.vfec_con = dtgsegcateter.Rows(e.RowIndex).Cells("Fec_con").Value
                variablesseg.vcodestsitins = dtgsegcateter.Rows(e.RowIndex).Cells("CodEstSitIns").Value
                variablesseg.vestsitins = dtgsegcateter.Rows(e.RowIndex).Cells("EstSitIns").Value
                variablesseg.vvalcuracion = dtgsegcateter.Rows(e.RowIndex).Cells("valcuracion").Value
                If dtgsegcateter.Rows(e.RowIndex).Cells("codCuracion").Value.ToString = Nothing Then
                    variablesseg.vcodCuracion = ""
                    variablesseg.vcuracion = ""

                Else
                    variablesseg.vcodCuracion = dtgsegcateter.Rows(e.RowIndex).Cells("codCuracion").Value
                    variablesseg.vcuracion = dtgsegcateter.Rows(e.RowIndex).Cells("Curacion").Value

                End If
                variablesseg.vcodverifica = dtgsegcateter.Rows(e.RowIndex).Cells("codverifica").Value
                variablesseg.vverifica = dtgsegcateter.Rows(e.RowIndex).Cells("verifica").Value
                variablesseg.vcodgestionf = dtgsegcateter.Rows(e.RowIndex).Cells("codgestionf").Value
                variablesseg.vgestionf = dtgsegcateter.Rows(e.RowIndex).Cells("gestionf").Value
                variablesseg.vcodmotivoret = dtgsegcateter.Rows(e.RowIndex).Cells("CodMotivoret").Value
                variablesseg.vmotivoret = dtgsegcateter.Rows(e.RowIndex).Cells("Motivoret").Value
                variablesseg.vestadoreg = "M"
                dtgsegcateter.Rows.Remove(dtgsegcateter.CurrentRow)
                frmAgregarSeguimiento.ShowDialog()
            End If
        End If
    End Sub
    Public Sub cguardar()
        Dim mcierre As String
        If vestadoreg <> "" Then
            If swg = 0 Then
                mcierre = MsgBox("Desea Guardar los cambios antes de cerrar el formulario", vbOKCancel)
                If mcierre = 1 Then
                    GuardarSeguimientoCateter()
                    cargar_campos()
                End If
            End If
        End If
    End Sub




    '''''WACHV,FIN, 27Nov2017, Para Mostrar Ayuda tipo Tooltip text sobre los combos definidos
    ''Private Sub MostrarToolTip(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
    ''        txtfecha.MouseHover,
    ''        txttipcateter.MouseHover,
    ''        txtzonains.MouseHover,
    ''        txtlateralidad.MouseHover,
    ''        txtindicaciones.MouseHover,
    ''        txtcomplicaciones.MouseHover,
    ''        txtnpuncion.MouseHover,
    ''        txtresponsable.MouseHover,
    ''        txtespecialidad.MouseHover
    ''    If (sender.text <> "") Then
    ''        ToolTip1.SetToolTip(sender, sender.text)
    ''    End If
    ''End Sub


#End Region

End Class
