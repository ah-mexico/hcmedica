Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports System.Collections.Generic

Public Class ctlInsercionCateter

#Region "Propiedades"
    Private Shared _Instancia As ctlInsercionCateter
    Private objGeneral As Generales
    Private objPaciente As Paciente
    Private objDAOEnfermeria As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOEnfermeriaCP
    Private objCateter As New RegistroCateter
    Public ctlGestionCateteres As ctlGestionCateteres
    Private cadenaFechaVacia As String = "  /  /       :"
#End Region

    Dim FechaAct As DateTime, swcampo As Integer

#Region "Instancia de Control"

    Public Shared ReadOnly Property Instancia() As ctlInsercionCateter
        Get
            If _Instancia Is Nothing Then
                _Instancia = New ctlInsercionCateter
            End If
            Return _Instancia
        End Get
    End Property
#End Region

#Region "Events"
    Private Sub ctlInsercionCateter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objGeneral = Generales.Instancia
        objPaciente = Paciente.Instancia
        Me.ctlGestionCateteres = ctlGestionCateteres.Instancia
        CargarCombos()
        LimpiarCampos()
        LimpiarCheckListBox(Me.chklistIndicaciones)
        LimpiarCheckListBox(Me.chklistComplicaciones)
        FechaAct = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
        mskFecHoraInsercion.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") ''Fecha Actual x Defecto
        mskFecHoraInsercion.Focus()
    End Sub

    Private Sub ctlInsercionCateter_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible Then
            CargarCombos()
            LimpiarCampos()
            LimpiarCheckListBox(Me.chklistIndicaciones)
            LimpiarCheckListBox(Me.chklistComplicaciones)
            mskFecHoraInsercion.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") ''Fecha Actual x Defecto
            mskFecHoraInsercion.Focus()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarInsercion.Click
        If fncValidarIngresoCateter() = True Then
            GuardaIngresoCateter()
        End If
    End Sub
    Private Sub cboTipoCateter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoCateter.SelectedIndexChanged
        Try
            If IsNothing(cboTipoCateter.SelectedValue) Then
                cboTipoCateter.SelectedValue = -1
            Else
                If cboTipoCateter.SelectedValue.ToString() = "95802" Then ''Tipo Cateter Subcutáneo =95802.
                    CargarCombosxTipoCateter(1)
                Else
                    CargarCombosxTipoCateter(2)
                End If
                mskFecHoraInsercion.Focus()
            End If
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

#End Region

#Region "Functions"

    Private Sub LimpiarCampos()
        Try
            mskFecHoraInsercion.Text = ""
            cboTipoCateter.SelectedIndex = -1
            cmbLateralidad.SelectedIndex = -1
            chklistIndicaciones.SelectedIndex = -1
            Me.cbCalibreCateter.SelectedValue = -1
            Me.mskFecHoraInsercion.Text = String.Empty
            Me.cboZonaInsercion.SelectedValue = -1
            Me.cmbLateralidad.SelectedValue = -1
            Me.chklistIndicaciones.SelectedValue = -1
            Me.cboNumeroPunciones.SelectedValue = -1
            Me.chklistComplicaciones.SelectedValue = -1
            lblReqFechaHoraInsercionCateter.Visible = True
            lblReqTipoCateter.Visible = True
            lblReqZonaInsercion.Visible = True
            lblReqCalibreCateter.Visible = True
            lblReqLateralidad.Visible = True
            LblReqNumPunciones.Visible = True
            lblReqIndicaciones.Visible = True
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

    Private Sub LimpiarCheckListBox(ByVal chkListBox As CheckedListBox)
        Dim i As Integer
        For i = 0 To (chkListBox.Items.Count - 1)
            chkListBox.SetItemCheckState(i, CheckState.Unchecked)
        Next
    End Sub

    ''' WACHV, 07NOV2017, Cargar los combos segun la seleccion
    Private Sub CargarCombosxTipoCateter(ByVal strCaso As String)
        ''Si es 1 es Subcuteneo y si es 2 es ''Vascular periférico.
        Dim dt As New DataTable
        ''CARGAR ZONA DE INSERCION
        cboZonaInsercion.ResetText()
        cboZonaInsercion.BeginUpdate()
        dt = objDAOEnfermeria.CargarCombo(21, strCaso)
        If dt.Rows.Count = 0 Then
            MsgBox("No existen Zona de Insercion parametrizados.")
        End If
        cboZonaInsercion.DataSource = dt
        cboZonaInsercion.DisplayMember = "descripcion"
        cboZonaInsercion.ValueMember = "Id"
        cboZonaInsercion.EndUpdate()
        cboZonaInsercion.SelectedIndex = -1
        dt = Nothing

        ''CARGAR COMPLICACIONES
        chklistComplicaciones.ResetText()
        chklistComplicaciones.BeginUpdate()
        dt = objDAOEnfermeria.CargarCombo(24, strCaso)
        If dt.Rows.Count = 0 Then
            MsgBox("No existen complicaciones parametrizados.")
        End If
        chklistComplicaciones.DataSource = dt
        chklistComplicaciones.DisplayMember = "descripcion"
        chklistComplicaciones.ValueMember = "Id"
        chklistComplicaciones.EndUpdate()
        chklistComplicaciones.SelectedIndex = -1

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

    Private Sub CargarCombos()
        Dim dt As New DataTable
        Try
            cboTipoCateter.ResetText()
            cboTipoCateter.BeginUpdate()
            dt = objDAOEnfermeria.CargarCombo(19)

            If dt.Rows.Count = 0 Then
                MsgBox("No existen tipos de catéter parametrizados.")
            End If
            cboTipoCateter.DataSource = dt

            cboTipoCateter.DisplayMember = "descripcion"
            cboTipoCateter.ValueMember = "Id"
            cboTipoCateter.EndUpdate()
            cboTipoCateter.SelectedIndex = -1

            dt = Nothing

            cmbLateralidad.ResetText()
            cmbLateralidad.BeginUpdate()
            dt = objDAOEnfermeria.CargarCombo(3)

            If dt.Rows.Count = 0 Then
                MsgBox("No existen lateralidades parametrizadas.")
            End If
            cmbLateralidad.DataSource = dt

            cmbLateralidad.DisplayMember = "descripcion"
            cmbLateralidad.ValueMember = "Id"
            cmbLateralidad.EndUpdate()
            cmbLateralidad.SelectedIndex = -1

            dt = Nothing

            '''WACHV, 07NOV2017,INICIO, PARA CARGAR CALIBRES DEL CATETER
            cbCalibreCateter.ResetText()
            cbCalibreCateter.BeginUpdate()
            dt = objDAOEnfermeria.CargarCombo(20)
            If dt.Rows.Count = 0 Then
                MsgBox("No existen calibres de Cateter parametrizados.")
            End If
            cbCalibreCateter.DataSource = dt
            cbCalibreCateter.DisplayMember = "descripcion"
            cbCalibreCateter.ValueMember = "Id"
            cbCalibreCateter.EndUpdate()
            cbCalibreCateter.SelectedIndex = -1

            dt = Nothing

            chklistIndicaciones.ResetText()
            chklistIndicaciones.BeginUpdate()
            dt = objDAOEnfermeria.CargarCombo(23)

            If dt.Rows.Count = 0 Then
                MsgBox("No existen indicaciones del catéter parametrizadas.")
            End If
            chklistIndicaciones.DataSource = dt

            chklistIndicaciones.DisplayMember = "descripcion"
            chklistIndicaciones.ValueMember = "Id"
            chklistIndicaciones.EndUpdate()
            chklistIndicaciones.SelectedIndex = -1

            dt = Nothing

            ''''WACHV, 07NOV2017,INICIO, PARA CARGAR PUNCIONES
            cboNumeroPunciones.ResetText()
            cboNumeroPunciones.BeginUpdate()
            dt = objDAOEnfermeria.CargarCombo(22)
            If dt.Rows.Count = 0 Then
                MsgBox("No existen Punciones parametrizados.")
            End If
            cboNumeroPunciones.DataSource = dt
            cboNumeroPunciones.DisplayMember = "descripcion"
            cboNumeroPunciones.ValueMember = "Id"
            cboNumeroPunciones.EndUpdate()
            cboNumeroPunciones.SelectedIndex = -1

        Catch ex As Exception
            Throw (ex)
        End Try

    End Sub

    Private Function fncValidarIngresoCateter() As Boolean
        Dim bvalidarIngresoCateter As Boolean = True

        If (mskFecHoraInsercion.Text <> "  /  /" And (bvalidarFecha(mskFecHoraInsercion.Text) = True)) Then
            MsgBox("Error, debe escribir una fecha de Insercion Válida", MsgBoxStyle.Information, "Historia Clinica")
            bvalidarIngresoCateter = False
            lblReqFechaHoraInsercionCateter.Visible = True
            Exit Function
        Else
            lblReqFechaHoraInsercionCateter.Visible = False
        End If

        'If bvalidarFecha(mskFecHoraInsercion.Text) = True Then
        '        MsgBox("Error, debe escribir una fecha de Insercion Válida", MsgBoxStyle.Information, "Historia Clinica")
        '        bvalidarIngresoCateter = False
        '        lblReqFechaHoraInsercionCateter.Visible = True
        '        Exit Function
        '    Else
        '        lblReqFechaHoraInsercionCateter.Visible = False
        '    End If
        'Else
        '    MsgBox("Error, debe dar una fecha de Insercion", MsgBoxStyle.Information, "Historia Clinica")
        '    bvalidarIngresoCateter = False
        '    lblReqFechaHoraInsercionCateter.Visible = True
        '    Exit Function
        'End If

        If (Me.cboTipoCateter.SelectedValue = Nothing) Then
            MsgBox("Error, debe seleccionar un Tipo de Cateter", MsgBoxStyle.Information, "Historia Clinica")
            bvalidarIngresoCateter = False
            lblReqTipoCateter.Visible = True
            Exit Function
        Else
            lblReqTipoCateter.Visible = False
        End If

        If (Me.cboZonaInsercion.SelectedValue = Nothing) Then
            MsgBox("Error, debe seleccionar una Zona Insercion", MsgBoxStyle.Information, "Historia Clinica")
            bvalidarIngresoCateter = False
            lblReqZonaInsercion.Visible = True
            Exit Function
        Else
            lblReqZonaInsercion.Visible = False
        End If

        If (Me.cbCalibreCateter.SelectedValue = Nothing) Then
            MsgBox("Error, debe seleccionar un Calibre de Cateter", MsgBoxStyle.Information, "Historia Clinica")
            bvalidarIngresoCateter = False
            lblReqCalibreCateter.Visible = True
            Exit Function
        Else
            lblReqCalibreCateter.Visible = False
        End If

        If (Me.cmbLateralidad.SelectedValue = Nothing) Then
            MsgBox("Error, debe seleccionar la Lateralidad", MsgBoxStyle.Information, "Historia Clinica")
            bvalidarIngresoCateter = False
            lblReqLateralidad.Visible = True
            Exit Function
        Else
            lblReqLateralidad.Visible = False
        End If

        If (Me.cboNumeroPunciones.SelectedValue = Nothing) Then
            MsgBox("Error, debe seleccionar el Numero de Punciones", MsgBoxStyle.Information, "Historia Clinica")
            bvalidarIngresoCateter = False
            LblReqNumPunciones.Visible = True
            Exit Function
        Else
            LblReqNumPunciones.Visible = False
        End If

        Dim strIndicaciones As String = GetCheckBoxListSelections(chklistIndicaciones)

        If (strIndicaciones = "") Then
            MsgBox("Error, debe seleccionar las Indicaciones", MsgBoxStyle.Information, "Historia Clinica")
            bvalidarIngresoCateter = False
            lblReqIndicaciones.Visible = True
            Exit Function
        Else
            lblReqIndicaciones.Visible = False
        End If

        'If (Me.cboComplicacionesCateter.SelectedValue = Nothing) Then
        '    MsgBox("Error, debe seleccionar las Complicaciones", MsgBoxStyle.Information, "Historia Clinica")
        '    bvalidarIngresoCateter = False
        '    Exit Function
        'End If

        fncValidarIngresoCateter = bvalidarIngresoCateter

    End Function
    Private Function fncValidarCombinacionCateter() As Boolean
        Dim bvalidarCombinacionCateter As Boolean = True
        If Me.objDAOEnfermeria.BuscarCombinacionCateter(objCateter.Tip_Doc, objCateter.Num_Doc, objCateter.Fec_Insercion, objCateter.Tip_Cateter, objCateter.Sitio_Insercion, objCateter.Lateralidad) = True Then
            MsgBox("Error,No se puede insertar el mismo tipo de catéter para la misma zona y con la misma lateralidad.", MsgBoxStyle.Information, "Historia Clinica")
            bvalidarCombinacionCateter = False
            fncValidarCombinacionCateter = bvalidarCombinacionCateter
            Exit Function
        End If
        fncValidarCombinacionCateter = bvalidarCombinacionCateter
    End Function
    Private Function bvalidarFecha(ByVal strvalorvalidar As String) As Boolean
        Dim bValidaFecha As Boolean = False
        Dim fechaMinima As New DateTime(1900, 1, 1)
        ''Dim fechaMaxima As DateTime = Format(FuncionesGenerales.FechaServidor())
        Dim fechaMaxima As DateTime = Format(FuncionesGenerales.FechaServidor().ToString("dd/MM/yyyy HH:mm"))
        Dim fechaDiaAnterior As Date = DateAdd(DateInterval.Day, -1, fechaMaxima)
        'Dim fechaDiaAnterior As DateTime = fechaMaxima.ToString("dd/mm/yyyy HH:mm")
        Dim dtFechaNacimientoPaciente As Date = objPaciente.FechaNacimiento
        Try
            ' Valor a Evaluar
            '
            If IsDate(strvalorvalidar) Then
                'Dim fecha As DateTime = CDate(strvalorvalidar)
                Dim fecha As DateTime = DateTime.Parse(strvalorvalidar).ToString("dd/MM/yyyy HH:mm")
                'Dim fecha As DateTime = DateTime.ParseExact(strvalorvalidar, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture)

                If (fecha < fechaMinima) OrElse (fecha.Day > fechaMaxima.Day) OrElse (fecha.Year > fechaMaxima.Year) OrElse (fecha < dtFechaNacimientoPaciente) Then
                    'MessageBox.Show("Fecha errónea")
                    bValidaFecha = True
                ElseIf (DateDiff(DateInterval.Day, fechaDiaAnterior, fecha) < 0) Then ''Validar un dia hacia atras
                    bValidaFecha = True
                End If
            Else
                'MessageBox.Show("Fecha errónea")
                bValidaFecha = True
            End If

            bvalidarFecha = bValidaFecha

        Catch ex As Exception
            bValidaFecha = True
        End Try

    End Function
    Public Sub GuardaIngresoCateter()
        Dim Resultado As Boolean
        objCateter.Cod_pre_sgs = objGeneral.Prestador
        objCateter.Cod_sucur = objGeneral.Sucursal
        objCateter.Tip_admision = objPaciente.TipoAdmision
        objCateter.Ano_adm = objPaciente.AnoAdmision
        objCateter.Num_adm = objPaciente.NumeroAdmision
        objCateter.Tip_Doc = objPaciente.TipoDocumento
        objCateter.Num_Doc = objPaciente.NumeroDocumento
        objCateter.Tip_Registro = "INSERCION"
        objCateter.EsSophia = "SI"

        objCateter.Fec_Insercion = mskFecHoraInsercion.Text

        If Not IsNothing(Me.cboTipoCateter.SelectedValue) Then
            objCateter.Tip_Cateter = Convert.ToInt32(Me.cboTipoCateter.SelectedValue)
        End If
        If Not IsNothing(Me.cboZonaInsercion.SelectedValue) Then
            objCateter.Sitio_Insercion = Convert.ToInt32(Me.cboZonaInsercion.SelectedValue)
        End If

        If Not IsNothing(Me.cbCalibreCateter.SelectedValue) Then
            objCateter.Calibre = Me.cbCalibreCateter.SelectedValue
        End If
        If Not IsNothing(Me.cmbLateralidad.SelectedValue) Then
            objCateter.Lateralidad = Me.cmbLateralidad.SelectedValue
        End If

        If Not IsNothing(Me.cboNumeroPunciones.SelectedValue) Then
            objCateter.NroPunciones = Me.cboNumeroPunciones.SelectedValue
        End If

        'If Not IsNothing(Me.chklistIndicaciones.SelectedValue) Then
        objCateter.Indicaciones = GetCheckBoxListSelections(Me.chklistIndicaciones)
        'End If

        'If Not IsNothing(Me.chklistComplicaciones.SelectedValue) Then
        objCateter.Complicaciones = GetCheckBoxListSelections(Me.chklistComplicaciones)
        'End If

        objCateter.Seguimiento_del_cateter = "96401" ''SI

        objCateter.Especialidad = objGeneral.DescripcionEspecialidad  ''Descripcion Especialidad del que se loguea
        objCateter.LoginMedico = objGeneral.Login                     ''Medico que se loguea para sophia el codigo
        objCateter.Login = objGeneral.Login                           ''Login del que se loguea
        objCateter.Obs = String.Empty

        If fncValidarCombinacionCateter() Then
            Resultado = Me.objDAOEnfermeria.GuardarRegistroCateter(objCateter)
            If Resultado Then
                MsgBox("Información de inserción de catéter guardada satisfactoriamiente", MsgBoxStyle.Information)
                LimpiarCampos()
                Me.ParentForm.Close()
            End If
        End If
    End Sub

    Private Sub chklistIndicaciones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles chklistIndicaciones.SelectedIndexChanged
        chklistIndicaciones.BackColor = Color.White
    End Sub

    Private Sub chklistComplicaciones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles chklistComplicaciones.SelectedIndexChanged
        chklistComplicaciones.BackColor = Color.White
    End Sub



    Private Sub mskFecHoraInsercion_LostFocus(sender As Object, e As EventArgs) Handles mskFecHoraInsercion.LostFocus
        Dim dias As Integer

        If mskFecHoraInsercion.Text = cadenaFechaVacia Then
            mskFecHoraInsercion.Text = FechaAct.ToString("dd/MM/yyyy HH:mm:ss")
            Exit Sub
        Else
            dias = (DateDiff(DateInterval.Hour, CDate(mskFecHoraInsercion.Text), CDate(FechaAct)))
        End If

        If dias < 0 Or dias >= 24 Then
            MsgBox("La fecha y hora registradas están fuera del rango permitido")
            mskFecHoraInsercion.Text = FechaAct.ToString("dd/MM/yyyy HH:mm:ss")
            Exit Sub
        End If

    End Sub

#End Region


End Class
