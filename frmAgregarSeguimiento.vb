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
Imports System.ComponentModel

Public Class frmAgregarSeguimiento

#Region "Propiedades"

    'Private Shared _Instancia As ctlInsercionCateter
    Private objGeneral As Generales
    Private objPaciente As Paciente
    Private objDAOEnfermeria As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOEnfermeriaCP
    Private objCateter As New RegistroCateter
    Private myParent As ctlCPEnfermeria
    Private cadenaFechaVacia As String = "  /  /       :"
    Private objsegcateter As New RegistroCateter

#End Region
    Dim FechaAct As DateTime, swcampo As Integer
    Dim vopcion() As String

    Private Sub rbno_CheckedChanged(sender As Object, e As EventArgs) Handles rbno.CheckedChanged
        If rbno.Checked Then
            rbsi.Checked = False
            chklistcuracion.Enabled = False
            LimpiarCheckListBox(chklistcuracion)
            chklistcuracion.BackColor = Color.White
        End If
    End Sub

    Private Sub rbsi_CheckedChanged(sender As Object, e As EventArgs) Handles rbsi.CheckedChanged
        If rbsi.Checked Then
            rbno.Checked = False
            chklistcuracion.Enabled = True
        End If
    End Sub

    Private Sub btncancelar_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        Me.Close()
    End Sub

    Private Sub frmAgregarSeguimiento_Load(sender As Object, e As EventArgs) Handles Me.Load
        'txtfechaa.Enabled = False
        If variablesseg.vchc Then
            Label11.Visible = True
        Else
            Label11.Visible = False
        End If
        chklistmotreiro.Visible = False
        CargarCombos()
        FechaAct = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
        txtfechaa.Text = FechaAct.ToString("dd/MM/yyyy HH:mm:ss")
        If variablesseg.vestadoreg <> Nothing Then
            If variablesseg.vestadoreg.ToString = "M" Then
                cargaInformacion()
            End If
        End If
    End Sub

    Private Sub txtfechaa_LostFocus(sender As Object, e As EventArgs) Handles txtfechaa.LostFocus
        Dim dias As Integer

        If txtfechaa.Text = cadenaFechaVacia Then
            txtfechaa.Text = FechaAct.ToString("dd/MM/yyyy HH:mm:ss")
            Exit Sub
        Else
            dias = (DateDiff(DateInterval.Hour, CDate(txtfechaa.Text), CDate(FechaAct)))
        End If

        If dias < 0 Or dias >= 24 Then
            MsgBox("La fecha y hora registradas están fuera del rango permitido")
            txtfechaa.Text = FechaAct.ToString("dd/MM/yyyy HH:mm:ss")
            Exit Sub
        End If

    End Sub

    Private Sub cmbgestfinal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbgestfinal.SelectedIndexChanged
        If IsNothing(cmbgestfinal.SelectedValue) <> True Then
            If cmbgestfinal.SelectedValue.ToString() = "97201" Then
                chklistmotreiro.Visible = True
                Label12.Visible = True
            Else
                chklistmotreiro.Visible = False
                Label12.Visible = False
                LimpiarCheckListBox(chklistmotreiro)
                chklistmotreiro.BackColor = Color.White
            End If
        End If
    End Sub

    Private Sub btnagregar_Click(sender As Object, e As EventArgs) Handles btnagregar.Click
        Dim validac As String, cmr As String, mr As String, gestionfinal As String, fechaseg As DateTime, fec As DateTime
        ValidarCampos()
        fec = txtfechaa.Text.ToString
        fechaseg = fec.Day.ToString + "/" + Month(txtfechaa.Text).ToString + "/" + Year(txtfechaa.Text).ToString + " " + Hour(txtfechaa.Text).ToString + ":" + Minute(txtfechaa.Text).ToString + ":" + Second(FechaAct).ToString
        If swcampo > 0 Then
            Exit Sub
        End If

        If rbsi.Checked Then
            validac = "SI"
        End If
        If rbno.Checked Then
            validac = "NO"
        End If
        If cmbgestfinal.Text = "" Then
            gestionfinal = "0"
        Else
            gestionfinal = cmbgestfinal.SelectedValue.ToString()
        End If
        If gestionfinal = "97201" Then
            cmr = GetCheckBoxListSelections(chklistmotreiro)
            mr = GetCheckBoxListSelectionsDes(chklistmotreiro)
            ctlSeguimientoCateter.Instancia.btnAgSeg.Enabled = False
        Else
            cmr = ""
            mr = ""
        End If
        If (cmbgestfinal.Text.ToString) <> Nothing Then
            dtsegcateter.Rows.Add(fechaseg,
            DateDiff(DateInterval.Day, CDate(variables.fechacat.ToString("dd/MM/yyyy")), CDate(txtfechaa.Text)),
            GetCheckBoxListSelections(chkListSitioInsert),
            GetCheckBoxListSelectionsDes(chkListSitioInsert),
            validac,
            GetCheckBoxListSelections(chklistcuracion),
            GetCheckBoxListSelectionsDes(chklistcuracion),
            GetCheckBoxListSelections(chklistverifica),
            GetCheckBoxListSelectionsDes(chklistverifica),
            cmbgestfinal.SelectedValue,
            cmbgestfinal.Text, cmr, mr, "A", variablesseg.vresponsable, variablesseg.vespecialidad)
        Else
            dtsegcateter.Rows.Add(fechaseg.ToString("dd/MM/yyyy HH:mm:ss"), DateDiff(DateInterval.Day, CDate(variables.fechacat.ToString("dd/MM/yyyy")), CDate(txtfechaa.Text)), GetCheckBoxListSelections(chkListSitioInsert), GetCheckBoxListSelectionsDes(chkListSitioInsert), validac, GetCheckBoxListSelections(chklistcuracion), GetCheckBoxListSelectionsDes(chklistcuracion), GetCheckBoxListSelections(chklistverifica), GetCheckBoxListSelectionsDes(chklistverifica), "", "", cmr, mr, "A", variablesseg.vresponsable, variablesseg.vespecialidad)
        End If
        ctlSeguimientoCateter.Instancia.dtgsegcateter.DataSource = dtsegcateter
        ctlSeguimientoCateter.Instancia.dtgsegcateter.CurrentCell = ctlSeguimientoCateter.Instancia.dtgsegcateter.Rows(ctlSeguimientoCateter.Instancia.dtgsegcateter.RowCount - 1).Cells(0)
        limpiarcampos()
        Me.Close()
    End Sub
    Private Sub chkListSitioInsert_SelectedIndexChanged(sender As Object, e As EventArgs) Handles chkListSitioInsert.SelectedIndexChanged
        Dim i As Integer, EstadoSitio As String, pos As Integer
        chkListSitioInsert.BackColor = Color.White
        pos = 0
        If chkListSitioInsert.Items(chkListSitioInsert.SelectedIndex)(0).ToString <> Nothing Then
            EstadoSitio = chkListSitioInsert.Items(chkListSitioInsert.SelectedIndex)(0).ToString
        Else
            EstadoSitio = ""
        End If
        If EstadoSitio.ToString <> "" Then
            If EstadoSitio = "96801" Or EstadoSitio = "96808" Then
                For i = 0 To (chkListSitioInsert.Items.Count - 1)
                    If chkListSitioInsert.Items(i)(0).ToString <> EstadoSitio Then
                        chkListSitioInsert.SetItemCheckState(i, CheckState.Unchecked)
                    End If
                Next
            Else
                For i = 0 To (chkListSitioInsert.Items.Count - 1)
                    If chkListSitioInsert.Items(i)(0).ToString = "96801" Or chkListSitioInsert.Items(i)(0).ToString = "96808" Then
                        chkListSitioInsert.SetItemCheckState(i, CheckState.Unchecked)
                    End If
                Next
            End If
        End If
    End Sub
    Private Sub chklistcuracion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles chklistcuracion.SelectedIndexChanged
        chklistcuracion.BackColor = Color.White
    End Sub
    Private Sub chklistverifica_SelectedIndexChanged(sender As Object, e As EventArgs) Handles chklistverifica.SelectedIndexChanged
        chklistverifica.BackColor = Color.White
    End Sub
    Private Sub chklistmotreiro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles chklistmotreiro.SelectedIndexChanged
        chklistmotreiro.BackColor = Color.White
    End Sub

#Region "Funciones"
    Private Sub CargarCombos()
        Dim dt As New DataTable
        Try

            chkListSitioInsert.ResetText()
            chkListSitioInsert.BeginUpdate()
            If variables.tipocateter1 = "Subcutaneo" Then
                dt = objDAOEnfermeria.CargarCombo(25, "1")
            Else
                dt = objDAOEnfermeria.CargarCombo(25, "2")
            End If

            If dt.Rows.Count = 0 Then
                MsgBox("No existen Estados de sitios de inserción parametrizadas.")
            End If
            chkListSitioInsert.DataSource = dt

            chkListSitioInsert.DisplayMember = "descripcion"
            chkListSitioInsert.ValueMember = "Id"
            chkListSitioInsert.EndUpdate()
            dt = Nothing

            chklistcuracion.ResetText()
            chklistcuracion.BeginUpdate()
            dt = objDAOEnfermeria.CargarCombo(26)

            If dt.Rows.Count = 0 Then
                MsgBox("No existen Elementos de curación parametrizadas.")
            End If
            chklistcuracion.DataSource = dt

            chklistcuracion.DisplayMember = "descripcion"
            chklistcuracion.ValueMember = "Id"
            chklistcuracion.EndUpdate()
            dt = Nothing


            chklistverifica.ResetText()
            chklistverifica.BeginUpdate()
            dt = objDAOEnfermeria.CargarCombo(27)

            If dt.Rows.Count = 0 Then
                MsgBox("No existen verificaciones parametrizadas.")
            End If
            chklistverifica.DataSource = dt

            chklistverifica.DisplayMember = "descripcion"
            chklistverifica.ValueMember = "Id"
            chklistverifica.EndUpdate()
            dt = Nothing

            cmbgestfinal.ResetText()
            cmbgestfinal.BeginUpdate()
            dt = objDAOEnfermeria.CargarCombo(28)

            If dt.Rows.Count = 0 Then
                MsgBox("No existen Gestiones Finales parametrizadas.")
            End If
            cmbgestfinal.DataSource = dt

            cmbgestfinal.DisplayMember = "descripcion"
            cmbgestfinal.ValueMember = "Id"
            cmbgestfinal.EndUpdate()
            cmbgestfinal.SelectedIndex = -1

            dt = Nothing


            chklistmotreiro.ResetText()
            chklistmotreiro.BeginUpdate()
            If variables.tipocateter1 = "Subcutaneo" Then
                dt = objDAOEnfermeria.CargarCombo(29, "1")
            Else
                dt = objDAOEnfermeria.CargarCombo(29, "2")
            End If

            If dt.Rows.Count = 0 Then
                MsgBox("No existen motivos de retiro parametrizados.")
            End If
            chklistmotreiro.DataSource = dt

            chklistmotreiro.DisplayMember = "descripcion"
            chklistmotreiro.ValueMember = "Id"
            chklistmotreiro.EndUpdate()
            dt = Nothing
        Catch ex As Exception
            Throw (ex)
        End Try

    End Sub

    Private Sub ValidarCampos()
        swcampo = 0
        If Me.txtfechaa.Text = cadenaFechaVacia Then
            txtfechaa.BackColor = Color.IndianRed
            swcampo = swcampo + 1
        Else
            txtfechaa.BackColor = Color.White
            swcampo = swcampo + 0
        End If
        If GetCheckBoxListSelections(chkListSitioInsert) = Nothing Then
            chkListSitioInsert.BackColor = Color.IndianRed
            swcampo = swcampo + 1
        End If


        If rbsi.Checked Then
            If GetCheckBoxListSelections(chklistcuracion) = Nothing Then
                chklistcuracion.BackColor = Color.IndianRed
                swcampo = swcampo + 1
            End If
        End If

        If GetCheckBoxListSelections(chklistverifica) = Nothing Then
            chklistverifica.BackColor = Color.IndianRed
            swcampo = swcampo + 1
        End If

        If chklistmotreiro.Visible And GetCheckBoxListSelections(chklistmotreiro) = Nothing Then
            chklistmotreiro.BackColor = Color.IndianRed
            swcampo = swcampo + 1
        End If
        If variablesseg.vchc Then
            cmbgestfinal.BackColor = Color.IndianRed
            swcampo = swcampo + 1
        End If
    End Sub

    Private Sub LimpiarCheckListBox(ByVal chkListBox As CheckedListBox)
        Dim i As Integer
        For i = 0 To (chkListBox.Items.Count - 1)
            chkListBox.SetItemCheckState(i, CheckState.Unchecked)
        Next
    End Sub
    Private Sub limpiarcampos()
        LimpiarCheckListBox(chkListSitioInsert)
        LimpiarCheckListBox(chklistcuracion)
        LimpiarCheckListBox(chklistverifica)
        LimpiarCheckListBox(chklistmotreiro)
        cmbgestfinal.Text = ""
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
    Private Function GetCheckBoxListSelectionsDes(ByVal chkListBox As CheckedListBox) As String

        Dim i As Integer
        Dim ListItems As New List(Of String)
        For i = 0 To (chkListBox.Items.Count - 1)
            If chkListBox.GetItemChecked(i) = True Then
                ListItems.Add(chkListBox.Items(i)(1).ToString.Trim)
            End If
        Next
        If ListItems.Count > 0 Then
            Return String.Join("-", ListItems.ToArray())
        Else
            Return Nothing
        End If
    End Function
    Private Function GetcmbListSelectionsDes(ByVal chkListBox As CheckedListBox) As DataTable

        Dim i As Integer, tblIns As New DataTable, Row As DataRow
        For i = 0 To (chkListBox.Items.Count - 1)
            If chkListBox.GetItemChecked(i) = True Then
                tblIns.Columns.Add()
                Row = tblIns.NewRow
                Row(i) = chkListBox.Items(i)(1)
                tblIns.Rows.Add(Row)
            End If
        Next
        If tblIns.Rows.Count > 0 Then
            Return tblIns
        Else
            Return Nothing
        End If
    End Function
    Public Sub cargachklist(ByVal chkListBox As CheckedListBox, ByVal vopc() As String)
        Dim i As Integer, iregistro As Integer
        For iregistro = 0 To vopc.Length - 1
            For i = 0 To (chkListBox.Items.Count - 1)
                If chkListBox.Items(i)(0).ToString.Trim = vopc(iregistro) Then
                    chkListBox.SetItemCheckState(i, CheckState.Checked)
                End If
            Next
        Next
    End Sub
    Private Sub cargaInformacion()
        txtfechaa.Text = ""
        txtfechaa.Text = variablesseg.vfec_con
        vopcion = Split(variablesseg.vcodestsitins, "<|^|>")
        cargachklist(chkListSitioInsert, vopcion)
        If variablesseg.vvalcuracion.ToString = "SI" Then
            rbsi.Checked = True
            rbno.Checked = False
        Else
            rbno.Checked = True
            rbsi.Checked = False
        End If
        vopcion = Split(variablesseg.vcodCuracion, "<|^|>")
        cargachklist(chklistcuracion, vopcion)
        vopcion = Split(variablesseg.vcodverifica, "<|^|>")
        cargachklist(chklistverifica, vopcion)

        If variablesseg.vcodgestionf.ToString <> Nothing Then
            cmbgestfinal.SelectedValue = variablesseg.vcodgestionf
            If variablesseg.vcodgestionf.ToString = "97201" Then
                chklistmotreiro.Visible = True
                vopcion = Split(variablesseg.vcodmotivoret, "<|^|>")
                cargachklist(chklistmotreiro, vopcion)
            Else
                chklistmotreiro.Visible = False
            End If
        End If
    End Sub

    Private Sub txtfechaa_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles txtfechaa.MaskInputRejected

    End Sub
    Private Sub frmAgregarSeguimiento_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dim validac As String, cmr As String, mr As String, gestionfinal As String, fechaseg As DateTime, fec As DateTime
        If variablesseg.vestadoreg.ToString = "M" Then
            ValidarCampos()
            fec = txtfechaa.Text.ToString
            fechaseg = fec.Day.ToString + "/" + Month(txtfechaa.Text).ToString + "/" + Year(txtfechaa.Text).ToString + " " + Hour(txtfechaa.Text).ToString + ":" + Minute(txtfechaa.Text).ToString + ":" + Second(FechaAct).ToString
            If swcampo > 0 Then
                Exit Sub
            End If

            If rbsi.Checked Then
                validac = "SI"
            End If
            If rbno.Checked Then
                validac = "NO"
            End If
            If cmbgestfinal.Text = "" Then
                gestionfinal = "0"
            Else
                gestionfinal = cmbgestfinal.SelectedValue.ToString()
            End If
            If gestionfinal = "97201" Then
                cmr = GetCheckBoxListSelections(chklistmotreiro)
                mr = GetCheckBoxListSelectionsDes(chklistmotreiro)
                ctlSeguimientoCateter.Instancia.btnAgSeg.Enabled = False
            Else
                cmr = ""
                mr = ""
            End If
            If (cmbgestfinal.Text.ToString) <> Nothing Then
                dtsegcateter.Rows.Add(fechaseg, DateDiff(DateInterval.Day, CDate(variables.fechacat.ToString("dd/MM/yyyy")), CDate(txtfechaa.Text)), GetCheckBoxListSelections(chkListSitioInsert), GetCheckBoxListSelectionsDes(chkListSitioInsert), validac, GetCheckBoxListSelections(chklistcuracion), GetCheckBoxListSelectionsDes(chklistcuracion), GetCheckBoxListSelections(chklistverifica), GetCheckBoxListSelectionsDes(chklistverifica), cmbgestfinal.SelectedValue, cmbgestfinal.Text, cmr, mr, "A", variablesseg.vresponsable, variablesseg.vespecialidad)
            Else

                dtsegcateter.Rows.Add(fechaseg.ToString("dd/MM/yyyy HH:mm:ss"), DateDiff(DateInterval.Day, CDate(variables.fechacat.ToString("dd/MM/yyyy")), CDate(txtfechaa.Text)), GetCheckBoxListSelections(chkListSitioInsert), GetCheckBoxListSelectionsDes(chkListSitioInsert), validac, GetCheckBoxListSelections(chklistcuracion), GetCheckBoxListSelectionsDes(chklistcuracion), GetCheckBoxListSelections(chklistverifica), GetCheckBoxListSelectionsDes(chklistverifica), "", "", cmr, mr, "A", variablesseg.vresponsable, variablesseg.vespecialidad)
            End If
            ctlSeguimientoCateter.Instancia.dtgsegcateter.DataSource = dtsegcateter
            limpiarcampos()
            Me.Close()
        End If
        limpiarcampos()
    End Sub
#End Region
End Class