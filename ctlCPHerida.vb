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

Public Class ctlCPHerida		

#Region "Properties"

    Private Shared _Instancia As ctlCPHerida
    Private objGeneral As Generales
    Private objPaciente As Paciente    
    Private objHerida As New RegistroHerida
    Private objDAOHerida As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOEnfermeriaCP
    Private objQxManejaDatos As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAODescripcionQXManejoDeDatos
    Private myParent As ctlCPEnfermeria

#End Region

#Region "Instancia de Control"

    Public Shared ReadOnly Property Instancia() As ctlCPHerida
        Get
            If _Instancia Is Nothing Then
                _Instancia = New ctlCPHerida
            End If
            Return _Instancia
        End Get
    End Property

#End Region

#Region "Events"

    Private Sub ctlCPHerida_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        objGeneral = Generales.Instancia
        objPaciente = Paciente.Instancia
        If Me.Visible Then
            myParent = Me.Parent.Parent.Parent.Parent                     
            CargarCombos()
        End If
    End Sub

    Private Sub rbSiTunelizacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSiTunelizacion.CheckedChanged
        If rbSiTunelizacion.Checked Then
            txtUbiTunelizacion.Enabled = True
            txtProfTunelizacion.Enabled = True
        Else
            txtUbiTunelizacion.Enabled = False
            txtProfTunelizacion.Enabled = False
        End If
    End Sub

    Private Sub rbNoTunelizacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbNoTunelizacion.CheckedChanged
        If rbNoTunelizacion.Checked Then
            txtUbiTunelizacion.Enabled = False
            txtProfTunelizacion.Enabled = False
        Else
            txtUbiTunelizacion.Enabled = True
            txtProfTunelizacion.Enabled = True
        End If
    End Sub

    Private Sub rbSiFistula_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSiFistula.CheckedChanged
        If rbSiFistula.Checked Then
            txtUbiFistula.Enabled = True
            txtProfFistula.Enabled = True
        Else
            txtUbiFistula.Enabled = False
            txtProfFistula.Enabled = False
        End If
    End Sub

    Private Sub rbNoFistula_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbNoFistula.CheckedChanged
        If rbNoFistula.Checked Then
            txtUbiFistula.Enabled = False
            txtProfFistula.Enabled = False
        Else
            txtUbiFistula.Enabled = True
            txtProfFistula.Enabled = True
        End If
    End Sub

    Private Sub cmbExudado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbExudado.SelectedIndexChanged
        If IsNothing(cmbExudado.SelectedValue) Then
            cmbCaracExudado.Enabled = False
            cmbCaracExudado.SelectedValue = -1
        Else

            If cmbExudado.SelectedValue.ToString() = "94601" Then
                cmbCaracExudado.Enabled = False
            Else
                cmbCaracExudado.Enabled = True
            End If
        End If
    End Sub

    Private Sub rbSiDesbridamiento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSiDesbridamiento.CheckedChanged
        If rbSiDesbridamiento.Checked Then
            Me.chkListTipoDesbridamiento.Enabled = True
            Me.chkListNoDesbridamiento.Enabled = False
        Else
            Me.chkListTipoDesbridamiento.Enabled = False
            Me.chkListNoDesbridamiento.Enabled = True
        End If
    End Sub

    Private Sub rbNoDesbridamiento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbNoDesbridamiento.CheckedChanged
        If rbNoDesbridamiento.Checked Then
            Me.chkListTipoDesbridamiento.Enabled = False
            Me.chkListNoDesbridamiento.Enabled = True
        Else
            Me.chkListTipoDesbridamiento.Enabled = True
            Me.chkListNoDesbridamiento.Enabled = False
        End If
    End Sub

    Private Sub chkListSignoInfeccion_ItemCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chkListSignoInfeccion.ItemCheck
        Dim indice As Integer = chkListSignoInfeccion.FindStringExact("Sin signos de infeccion")
        ManejoCamposCheckBoxList(chkListSignoInfeccion, indice, e)
    End Sub

    Private Sub chkListTejidoComprometido_ItemCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chkListTejidoComprometido.ItemCheck
        Dim indice As Integer = chkListTejidoComprometido.FindStringExact("Eritema cutaneo que no palidece al presionar ")
        ManejoCamposCheckBoxList(chkListTejidoComprometido, indice, e)
    End Sub

    Private Sub chkListPielCircundante_ItemCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chkListPielCircundante.ItemCheck
        Dim indice As Integer = chkListPielCircundante.FindStringExact("Intacta")
        ManejoCamposCheckBoxList(chkListPielCircundante, indice, e)
    End Sub

    Private Sub chkListEstadoBordes_ItemCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chkListEstadoBordes.ItemCheck
        Dim indice As Integer = chkListEstadoBordes.FindStringExact("Sanos")
        ManejoCamposCheckBoxList(chkListEstadoBordes, indice, e)
    End Sub

    Private Sub btnAyudaGradoLesion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAyudaGradoLesion.Click
        Dim builder As String
        builder = "Para tener en cuenta:" & vbNewLine
        builder = builder & "Grado I:Eritema cutáneo que no palidece al presionar" & vbNewLine
        builder = builder & "Grado II: Si es solamente epidemis y/o Dermis" & vbNewLine
        builder = builder & "Grado III: Si es epidemis+dermis+tejido subcutaneo" & vbNewLine
        builder = builder & "Grado IV: Epidermis+dermis+tejido subcutaneo y/o musculo o fascia o organo"

        MsgBox(builder, MsgBoxStyle.Information)
    End Sub

    Private Sub btnAyudaPorcentaje_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAyudaPorcentaje.Click
        Dim builder As String
        builder = "Para tener en cuenta:" & vbNewLine & vbNewLine
        builder = builder & "A cada una se le asigna un porcentaje, y la suma de todas no debe superar el 100%."

        MsgBox(builder, MsgBoxStyle.Information)
    End Sub

    Private Sub btnGuardarHerida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarHerida.Click
        'If (ValidarCampos()) Then
        GuardaRegistroHerida()
        'End If
    End Sub

#End Region

#Region "Functions"

    Private Sub CargarCombos()
        Dim dt As New DataTable
        Try
            chkListTipoHerida.ResetText()
            chkListTipoHerida.BeginUpdate()
            dt = objDAOHerida.CargarCombo(8)

            If dt.Rows.Count = 0 Then
                MsgBox("No existen tipos de heridas parametrizados.")
            End If
            chkListTipoHerida.DataSource = dt

            chkListTipoHerida.DisplayMember = "descripcion"
            chkListTipoHerida.ValueMember = "Id"
            chkListTipoHerida.EndUpdate()            

            dt = Nothing

            chkListTejidoComprometido.ResetText()
            chkListTejidoComprometido.BeginUpdate()
            dt = objDAOHerida.CargarCombo(9)

            If dt.Rows.Count = 0 Then
                MsgBox("No existen tejidos comprometidos parametrizados.")
            End If
            chkListTejidoComprometido.DataSource = dt

            chkListTejidoComprometido.DisplayMember = "descripcion"
            chkListTejidoComprometido.ValueMember = "Id"
            chkListTejidoComprometido.EndUpdate()

            dt = Nothing

            cmbGradoLesion.ResetText()
            cmbGradoLesion.BeginUpdate()
            dt = objDAOHerida.CargarCombo(10)

            If dt.Rows.Count = 0 Then
                MsgBox("No existen grados de lesión parametrizados.")
            End If
            cmbGradoLesion.DataSource = dt

            cmbGradoLesion.DisplayMember = "descripcion"
            cmbGradoLesion.ValueMember = "Id"
            cmbGradoLesion.EndUpdate()
            cmbGradoLesion.SelectedValue = -1

            dt = Nothing

            cmbExudado.ResetText()
            cmbExudado.BeginUpdate()
            dt = objDAOHerida.CargarCombo(11)

            If dt.Rows.Count = 0 Then
                MsgBox("No existen exudados parametrizados.")
            End If
            cmbExudado.DataSource = dt

            cmbExudado.DisplayMember = "descripcion"
            cmbExudado.ValueMember = "Id"
            cmbExudado.EndUpdate()
            cmbExudado.SelectedValue = -1

            dt = Nothing

            cmbCaracExudado.ResetText()
            cmbCaracExudado.BeginUpdate()
            dt = objDAOHerida.CargarCombo(12)

            If dt.Rows.Count = 0 Then
                MsgBox("No existen grados de lesión parametrizados.")
            End If
            cmbCaracExudado.DataSource = dt

            cmbCaracExudado.DisplayMember = "descripcion"
            cmbCaracExudado.ValueMember = "Id"
            cmbCaracExudado.EndUpdate()
            cmbCaracExudado.SelectedValue = -1

            dt = Nothing

            chkListSignoInfeccion.ResetText()
            chkListSignoInfeccion.BeginUpdate()
            dt = objDAOHerida.CargarCombo(13)

            If dt.Rows.Count = 0 Then
                MsgBox("No existen signos de infección de herida parametrizados.")
            End If
            chkListSignoInfeccion.DataSource = dt

            chkListSignoInfeccion.DisplayMember = "descripcion"
            chkListSignoInfeccion.ValueMember = "Id"
            chkListSignoInfeccion.EndUpdate()

            dt = Nothing

            chkListPielCircundante.ResetText()
            chkListPielCircundante.BeginUpdate()
            dt = objDAOHerida.CargarCombo(14)

            If dt.Rows.Count = 0 Then
                MsgBox("No existen estados de piel circundante parametrizados.")
            End If
            chkListPielCircundante.DataSource = dt

            chkListPielCircundante.DisplayMember = "descripcion"
            chkListPielCircundante.ValueMember = "Id"
            chkListPielCircundante.EndUpdate()

            dt = Nothing

            chkListEstadoBordes.ResetText()
            chkListEstadoBordes.BeginUpdate()
            dt = objDAOHerida.CargarCombo(15)

            If dt.Rows.Count = 0 Then
                MsgBox("No existen estados de bordes de herida parametrizados.")
            End If
            chkListEstadoBordes.DataSource = dt

            chkListEstadoBordes.DisplayMember = "descripcion"
            chkListEstadoBordes.ValueMember = "Id"
            chkListEstadoBordes.EndUpdate()

            dt = Nothing

            chkListTipoDesbridamiento.ResetText()
            chkListTipoDesbridamiento.BeginUpdate()
            dt = objDAOHerida.CargarCombo(16)

            If dt.Rows.Count = 0 Then
                MsgBox("No existen tipos de desbridamiento parametrizados.")
            End If
            chkListTipoDesbridamiento.DataSource = dt

            chkListTipoDesbridamiento.DisplayMember = "descripcion"
            chkListTipoDesbridamiento.ValueMember = "Id"
            chkListTipoDesbridamiento.EndUpdate()

            dt = Nothing

            chkListNoDesbridamiento.ResetText()
            chkListNoDesbridamiento.BeginUpdate()
            dt = objDAOHerida.CargarCombo(17)

            If dt.Rows.Count = 0 Then
                MsgBox("No existen lateralidades parametrizadas.")
            End If
            chkListNoDesbridamiento.DataSource = dt

            chkListNoDesbridamiento.DisplayMember = "descripcion"
            chkListNoDesbridamiento.ValueMember = "Id"
            chkListNoDesbridamiento.EndUpdate()

            dt = Nothing

            cmbFrecuenciaCuracion.ResetText()
            cmbFrecuenciaCuracion.BeginUpdate()
            dt = objDAOHerida.CargarCombo(18)

            If dt.Rows.Count = 0 Then
                MsgBox("No existen indicaciones del catéter parametrizadas.")
            End If
            cmbFrecuenciaCuracion.DataSource = dt

            cmbFrecuenciaCuracion.DisplayMember = "descripcion"
            cmbFrecuenciaCuracion.ValueMember = "Id"
            cmbFrecuenciaCuracion.EndUpdate()
            cmbFrecuenciaCuracion.SelectedValue = -1


        Catch ex As Exception
            Throw (ex)
        End Try

    End Sub

    Private Sub GuardaRegistroHerida()
        Dim Resultado As Boolean
        Dim strAccionCateter As String = String.Empty

        objHerida.Cod_pre_sgs = objGeneral.Prestador
        objHerida.Cod_sucur = objGeneral.Sucursal
        objHerida.Tip_admision = objPaciente.TipoAdmision
        objHerida.Ano_adm = objPaciente.AnoAdmision
        objHerida.Num_adm = objPaciente.NumeroAdmision
        objHerida.Tip_Doc = objPaciente.TipoDocumento
        objHerida.Num_Doc = objPaciente.NumeroDocumento

        If (Me.txtLocalizacionHerida.Text.Trim().Length > 0) Then
            objHerida.Loc_Herida = Me.txtLocalizacionHerida.Text.Trim()
        End If
        If (Me.txtLongitudHerida.Text.Trim().Length > 0) Then
            objHerida.Long_Herida = Me.txtLongitudHerida.Text.Trim()
        End If
        objHerida.Tip_Herida = GetCheckBoxListSelections(Me.chkListTipoHerida)

        If Me.rbSiTunelizacion.Checked Then
            objHerida.Tunelizacion = "SI"
            If (Me.txtUbiTunelizacion.Text.Trim().Length > 0) Then
                objHerida.Ubi_Tunelizacion = Me.txtUbiTunelizacion.Text.Trim()
            End If
            If (Me.txtProfTunelizacion.Text.Trim().Length > 0) Then
                objHerida.Prof_Tunelizacion = Me.txtProfTunelizacion.Text.Trim()
            End If
        Else
            objHerida.Tunelizacion = "NO"
        End If

        If Me.rbSiFistula.Checked Then
            objHerida.Fistula = "SI"
            If (Me.txtUbiFistula.Text.Trim().Length > 0) Then
                objHerida.Ubi_Fistula = Me.txtUbiFistula.Text.Trim()
            End If
            If (Me.txtProfFistula.Text.Trim().Length > 0) Then
                objHerida.Prof_Fistula = Me.txtProfFistula.Text.Trim()
            End If
        Else
            objHerida.Fistula = "NO"
        End If

        objHerida.Tejido_Comprometido = GetCheckBoxListSelections(Me.chkListTejidoComprometido)
        If IsNothing(Me.cmbExudado.SelectedValue) Then
            objHerida.Grado = 0
        Else
            objHerida.Grado = Me.cmbGradoLesion.SelectedValue
        End If
        If (Me.txtNecSeco.Text.Trim().Length > 0) Then
            objHerida.Nec_Seco = Me.txtNecSeco.Text.Trim()
        End If
        If (Me.txtNecHumedo.Text.Trim().Length > 0) Then
            objHerida.Nec_Humedo = Me.txtNecHumedo.Text.Trim()
        End If
        If (Me.txtFibrina.Text.Trim().Length > 0) Then
            objHerida.Fibrina = Me.txtFibrina.Text.Trim()
        End If
        If (Me.txtEpitelizacion.Text.Trim().Length > 0) Then
            objHerida.Epitelizacion = Me.txtEpitelizacion.Text.Trim()
        End If
        If (Me.txtGranulacion.Text.Trim().Length > 0) Then
            objHerida.Granulacion = Me.txtGranulacion.Text.Trim()
        End If

        If IsNothing(Me.cmbExudado.SelectedValue) Then
            objHerida.Exudado = 0
        Else
            objHerida.Exudado = Me.cmbExudado.SelectedValue
        End If

        If Me.cmbCaracExudado.Enabled Then
            objHerida.Car_Exudado = Me.cmbCaracExudado.SelectedValue
        End If
        objHerida.Signo_Infeccion = GetCheckBoxListSelections(Me.chkListSignoInfeccion)
        objHerida.Piel_Circundante = GetCheckBoxListSelections(Me.chkListPielCircundante)
        objHerida.Estado_Bordes = GetCheckBoxListSelections(Me.chkListEstadoBordes)

        If Me.rbSiDesbridamiento.Checked = True And Me.rbNoDesbridamiento.Checked = False Then
            objHerida.Tiene_Desbridamiento = "SI"
            objHerida.Tipo_Desbridamiento = GetCheckBoxListSelections(Me.chkListTipoDesbridamiento)
        Else
            objHerida.Tiene_Desbridamiento = "NO"
            objHerida.Justif_No_Desbridamiento = GetCheckBoxListSelections(Me.chkListNoDesbridamiento)
        End If

        If (Me.txtProtocolo.Text.Trim().Length > 0) Then
            objHerida.Protocolo = Me.txtProtocolo.Text.Trim()
        End If
        If IsNothing(Me.cmbFrecuenciaCuracion.SelectedValue) Then
            objHerida.Frec_Curacion = 0
        Else
            objHerida.Frec_Curacion = Me.cmbFrecuenciaCuracion.SelectedValue
        End If
        If (Me.txtObsHerida.Text.Trim().Length > 0) Then
            objHerida.Obs_Herida = Me.txtObsHerida.Text.Trim()
        End If

        objHerida.Login = objGeneral.Login
        objHerida.Obs = String.Empty

        Resultado = objDAOHerida.GuardarRegistroHerida(objHerida)

        If Resultado Then
            MsgBox("Información de herida guardada satisfactoriamiente", MsgBoxStyle.Information)
            LimpiarCampos()
            myParent.rbSiPresentaHerida.Checked = False
            myParent.rbNoPresentaHerida.Checked = True
            myParent.CargarDatosHeridas()
        End If
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

    Private Sub LimpiarCampos()
        Me.rbSiTunelizacion.Checked = False
        Me.rbSiTunelizacion.Checked = True
        Me.rbSiFistula.Checked = False
        Me.rbNoFistula.Checked = True
        Me.cmbCaracExudado.SelectedIndex = -1
        Me.cmbExudado.SelectedIndex = -1
        Me.cmbFrecuenciaCuracion.SelectedIndex = -1
        Me.cmbGradoLesion.SelectedIndex = -1
        Me.txtEpitelizacion.Text = String.Empty
        Me.txtFibrina.Text = String.Empty
        Me.txtGranulacion.Text = String.Empty
        Me.txtLocalizacionHerida.Text = String.Empty
        Me.txtLongitudHerida.Text = String.Empty
        Me.txtNecHumedo.Text = String.Empty
        Me.txtObsHerida.Text = String.Empty
        Me.txtProfFistula.Text = String.Empty
        Me.txtProfTunelizacion.Text = String.Empty
        Me.txtProtocolo.Text = String.Empty
        Me.txtUbiFistula.Text = String.Empty
        Me.txtUbiTunelizacion.Text = String.Empty
        LimpiarCheckListBox(Me.chkListNoDesbridamiento)
        LimpiarCheckListBox(Me.chkListPielCircundante)
        LimpiarCheckListBox(Me.chkListSignoInfeccion)
        LimpiarCheckListBox(Me.chkListTejidoComprometido)
        LimpiarCheckListBox(Me.chkListTipoDesbridamiento)
        LimpiarCheckListBox(Me.chkListTipoHerida)
        LimpiarCheckListBox(Me.chkListEstadoBordes)
        objHerida = New RegistroHerida
        CargarCombos()
    End Sub

    Private Sub LimpiarCheckListBox(ByVal chkListBox As CheckedListBox)
        Dim i As Integer
        For i = 0 To (chkListBox.Items.Count - 1)
            chkListBox.SetItemCheckState(i, CheckState.Unchecked)
        Next
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

    Private Function ValidarCampos() As Boolean
        If Me.chkListTipoHerida.CheckedItems.Count = 0 Then
            MsgBox("Debe indicar el tipo de herida presentada", MsgBoxStyle.Exclamation)
            Return False
        End If
        If Me.txtLocalizacionHerida.Text.Trim().Length = 0 Then
            MsgBox("Debe indicar la localización de la herida presentada", MsgBoxStyle.Exclamation)
            Return False
        End If
        If Me.txtLongitudHerida.Text.Trim().Length = 0 Then
            MsgBox("Debe indicar la longitud de la herida presentada", MsgBoxStyle.Exclamation)
            Return False
        End If
        If Me.rbNoTunelizacion.Checked = False And Me.rbSiTunelizacion.Checked = False Then
            MsgBox("Debe indicar si hay tunelización", MsgBoxStyle.Exclamation)
            Return False
        End If
        If Me.rbSiTunelizacion.Checked And Me.txtUbiTunelizacion.Text.Trim().Length = 0 Then
            MsgBox("Debe indicar la ubicación de tunelización", MsgBoxStyle.Exclamation)
        End If
        If Me.rbSiTunelizacion.Checked And Me.txtProfTunelizacion.Text.Trim().Length = 0 Then
            MsgBox("Debe indicar la profundidad de tunelización", MsgBoxStyle.Exclamation)
        End If
        If Me.rbNoFistula.Checked = False And Me.rbSiFistula.Checked = False Then
            MsgBox("Debe indicar si hay fístula", MsgBoxStyle.Exclamation)
            Return False
        End If
        If Me.rbSiFistula.Checked And Me.txtUbiFistula.Text.Trim().Length = 0 Then
            MsgBox("Debe indicar la ubicación de fístula", MsgBoxStyle.Exclamation)
        End If
        If Me.rbSiTunelizacion.Checked And Me.txtProfTunelizacion.Text.Trim().Length = 0 Then
            MsgBox("Debe indicar la profundidad de fístula", MsgBoxStyle.Exclamation)
        End If
        If Me.chkListTejidoComprometido.CheckedItems.Count = 0 Then
            MsgBox("Debe indicar el tejido comprometido con la herida", MsgBoxStyle.Exclamation)
            Return False
        End If
        If IsNothing(Me.cmbGradoLesion.SelectedValue) Then
            MsgBox("Debe indicar el grado de la lesión", MsgBoxStyle.Exclamation)
            Return False
        End If

        Try
            If (Convert.ToDecimal(Me.txtNecHumedo.Text) + Convert.ToDecimal(Me.txtNecSeco.Text) _
         + Convert.ToDecimal(Me.txtFibrina.Text) + Convert.ToDecimal(Me.txtGranulacion.Text) + Convert.ToDecimal(Me.txtEpitelizacion.Text) <> 100) Then
                MsgBox("Los porcentajes de heridas deben dar el total de 100%. Favor revisar", MsgBoxStyle.Exclamation)
                Return False
            End If
        Catch ex As Exception
            MsgBox("Debe diligenciar los porcentajes de características del lecho de la herida", MsgBoxStyle.Exclamation)
            Return False
        End Try

        If IsNothing(Me.cmbExudado.SelectedValue) Then
            MsgBox("Debe indicar el exudado de la herida", MsgBoxStyle.Exclamation)
            Return False
        End If
        If Me.chkListSignoInfeccion.CheckedItems.Count = 0 Then
            MsgBox("Debe indicar los signos de infección presentados", MsgBoxStyle.Exclamation)
            Return False
        End If
        If Me.chkListPielCircundante.CheckedItems.Count = 0 Then
            MsgBox("Debe indicar el estado de la piel circundante a la herida", MsgBoxStyle.Exclamation)
            Return False
        End If
        If Me.chkListEstadoBordes.CheckedItems.Count = 0 Then
            MsgBox("Debe indicar el estado de los bordes de la herida", MsgBoxStyle.Exclamation)
            Return False
        End If
        If Me.rbSiDesbridamiento.Checked = False And Me.rbNoDesbridamiento.Checked = False Then
            MsgBox("Debe indicar si hay desbridamiento", MsgBoxStyle.Exclamation)
            Return False
        End If
        If Me.rbSiDesbridamiento.Checked = True And Me.chkListTipoDesbridamiento.CheckedItems.Count = 0 Then
            MsgBox("Debe indicar el tipo de desbridamiento presentado", MsgBoxStyle.Exclamation)
            Return False
        End If
        If Me.rbNoDesbridamiento.Checked = True And Me.chkListNoDesbridamiento.CheckedItems.Count = 0 Then
            MsgBox("Debe indicar la justificación de no desbridamiento", MsgBoxStyle.Exclamation)
            Return False
        End If
        If Me.txtProtocolo.Text.Trim().Length = 0 Then
            MsgBox("Debe indicar el protocolo instaurado", MsgBoxStyle.Exclamation)
            Return False
        End If
        If IsNothing(Me.cmbFrecuenciaCuracion.SelectedValue) Then
            MsgBox("Debe indicar la frecuencia de curación de la herida", MsgBoxStyle.Exclamation)
            Return False
        End If
        If Me.txtObsHerida.Text.Trim().Length = 0 Then
            MsgBox("Debe indicar las observaciones hechas a la herida", MsgBoxStyle.Exclamation)
            Return False
        End If
        Return True
    End Function

#End Region



End Class

