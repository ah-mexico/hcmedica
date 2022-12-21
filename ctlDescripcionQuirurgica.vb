Imports System.IO
Imports System.Collections
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.HistoriaBasica
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports objGenerales = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales

Public Class ctlDescripcionQuirurgica
    Private Shared _Instancia As ctlDescripcionQuirurgica
    Private objGeneral As Generales
    Private objPaciente As Paciente
    Private objConexion As Conexion
    Private objEvolucion As Evolucion
    Private objDescrQx As DescripcionQuirurgica
    Private objQx As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAODescripcionQX
    Private objQxManejaDatos As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAODescripcionQXManejoDeDatos
    Private strCirujanoInvitado As String = ""
    Private strClasifiDiagn As String = ""
    Private objHistoriaBasica As DatosHistoriaBasica
    Private datosLogin As Generales


#Region "Instancia de Control"
    Public Shared ReadOnly Property Instancia() As ctlDescripcionQuirurgica
        Get
            If _Instancia Is Nothing Then
                _Instancia = New ctlDescripcionQuirurgica
            End If
            Return _Instancia
        End Get
    End Property
#End Region

    Private Sub ctlDescripcionQuirurgica_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        objDescrQx = DescripcionQuirurgica.Instancia ''cpgaray
        objGeneral = Generales.Instancia
        objPaciente = Paciente.Instancia
        objConexion = Conexion.Instancia
        objEvolucion = Evolucion.Instancia
        CargarProcedimientosQuirurgicos()
        CargarCombos(1) ''Descripcion Quirurgica tipo de de empleado
        CargarCombos(3) ''Descripcion Quirurgica procedimientos
        CargarCombos(5) ''tipos de anestesia
        CargarCombos(6) ''Profilaxis
        CargarCombos(7)
        CargarObjetosDiagnosticos() ''Diagnosticos
        txtcodProce.Enabled = False
        cmbProcedim.Enabled = False
        'Joseph Moreno (IG) Fec:2019/11/19 Particularidades
        Me.ctlPartProce.Activar(False)
        'GroupBox1.Enabled = False
        'GroupBox3.Enabled = False
        'GroupBox2.Enabled = False
        'GroupBox5.Enabled = False
        'GroupBox7.Enabled = False
    End Sub
    Public Sub CargarProcedimientosQuirurgicos()


        Dim dtdatos As New DataTable

        Try
            ''  If objDescrQx.dtIntervencion Is Nothing Then


            'martovar 2014-08-08 req. 03 descripcion quirurgica version 2.9.0
            dtdatos = objQx.ConsultarProcedimientosXAdmision(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoDocumento,
            objPaciente.NumeroDocumento, objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision, 1)

            'dtdatos = objQx.ConsultarProcedimientosXAdmision(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoDocumento, _
            'objPaciente.NumeroDocumento, objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision)

            If dtdatos.Rows.Count = 0 Then
                '  dtdatos.Rows.Add(dtdatos.NewRow)
                MsgBox("No existen registros ")
                'Panel16.Enabled = False
                lnkNuevo.Enabled = False
                txtcodProce.Enabled = False
                cmbProcedim.Enabled = False
                'Joseph Moreno (IG) Fec:2019/11/19 Particularidades
                Me.ctlPartProce.Activar(False)
            Else
                dtdatos.Columns.Add("Copiar", System.Type.GetType("System.String"))
                'Temporal mientras modifico HCDescripcionQX_TraerProcedimientos
                Panel16.Enabled = True
                objDescrQx.dtIntervencion = dtdatos
                dtgProcedim.DataSource = dtdatos
                objDescrQx.Consecutivo = dtdatos.Rows(0).Item("Consecutivo").ToString

                configurarGrillaProc()
                lnkNuevo.Enabled = True
                txtcodProce.Enabled = True
                cmbProcedim.Enabled = True
                'Joseph Moreno (IG) Fec:2019/11/19 Particularidades
                Me.ctlPartProce.Activar(True)
            End If
            ''Else
            'If objDescrQx.dtIntervencion.Rows.Count = 0 Then
            '    MsgBox("No existen registros ")
            '    Exit Sub
            'End If
            dtgProcedim.DataSource = dtdatos
            'configurarGrillaProc()
            ''End If

        Catch ex As Exception
            MsgBox("Error al cargar los procedimientos quirúrgicos " & ex.Message)
        End Try

    End Sub
    Private Sub TieneImpresionDiagnostica()
        Dim dtdiagn As New DataTable
        Dim drow As DataRow
        Dim dtpostopera As New DataTable

        objHistoriaBasica = DatosHistoriaBasica.Instancia

        dtdiagn = objHistoriaBasica.ImpresionDiagnostica.DatosDiagnosticos

        If dtdiagn.Rows.Count > 0 Then
            dtpostopera = dtgPreoperatorio.DataSource
            'drow = dtpostopera.NewRow

            For i As Integer = 0 To dtdiagn.Rows.Count - 1
                drow = dtpostopera.NewRow
                drow.Item("consecutivo") = objDescrQx.Consecutivo
                drow.Item("procedim") = objDescrQx.Procedimiento
                drow.Item("diagnostic") = dtdiagn.Rows(i).Item("descripcion")
                drow.Item("diagnost") = dtdiagn.Rows(i).Item("diagnost")
                drow.Item("login") = objGeneral.Login
                drow.Item("obs") = ""
                drow.Item("clasificacion") = dtdiagn.Rows(i).Item("clasificacion")
                drow.Item("clase") = "PRE"
                dtpostopera.Rows.Add(drow)
                If ActualizaDiagnosticos(drow) Then

                    dtgPreoperatorio.DataSource = dtpostopera

                End If

            Next
            dtgPreoperatorio.DataSource = dtpostopera
        End If
    End Sub
    Private Sub configurarGrillaProc()

        With dtgProcedim
            .Columns.Item("Consecutivo").Width = 90
            .Columns.Item("Procedimiento").Width = 100
            .Columns.Item("Descripcion").Width = 250
            .Columns.Item("FechaInicio").Width = 100
            .Columns.Item("HoraInicio").Width = 80
            .Columns.Item("MinutoInicio").Width = 90
            .Columns.Item("FechaFinal").Width = 100
            .Columns.Item("HoraFinal").Width = 80
            .Columns.Item("MinutoFinal").Width = 90
            .Columns.Item("Anestesia").Width = 90
            .Columns("tip_anestesia").Visible = False
            .Columns("Copiar").Visible = False
            .Columns.Item("cod_permedas").Visible = False
            .Columns.Item("secuencia").Visible = False
            .Columns.Item("estado").Visible = False

            'Joseph Moreno (IG) Fec:2019/11/18 Particularidades
            If .Columns.Contains("genprocedes") Then
                .Columns.Item("genprocedes").Visible = False
            End If
            If .Columns.Contains("particularidades") Then
                .Columns.Item("particularidades").Visible = False
            End If
            'Resolucion 084 cufe 16 rjamestre
            .Columns.Item("Cod. Auto SISPRO").Width = 150 'Resolucion 084 RJMAESTRE CU16 - 16-07-2021
        End With

    End Sub

    Private Sub dtgProcedim_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgProcedim.CellClick

        ''If dtgProcedim.CurrentRow Is Nothing Then
        ''    MessageBox.Show("Seleccione un Registro de la Lista", "Descripción Quirúrgica", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ''    Exit Sub
        ''End If
        'Dim dtDatos As DataTable = dtgProcedim.DataSource
        'Dim cont As Integer = 0


        'For i As Integer = 0 To dtDatos.Rows.Count - 1
        '    If dtDatos.Rows(i).Item("Copiar").ToString = "S" Then
        '        cont = cont + 1
        '    End If
        'Next

        'If cont = 0 Then
        '    MessageBox.Show("Seleccione un Registro de la Lista", "Descripción Quirúrgica", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub
        'End If


        IniciarProcedimientos()

    End Sub
    Private Sub CargarCombos(ByVal intopcion As Integer)
        Dim dt As New DataTable

        Try


            Select Case intopcion
                Case 1 ''Tipo de profesional
                    txtCodTipPers.ResetText()
                    txtTipPers.ResetText()
                    With txtCodTipPers
                        .NombreCampoBuscado = "DESCRIPCION"
                        .NombreCampoBusqueda = "TIP_EMPLEADO"
                        .ControlTextoEnlace = txtTipPers
                    End With

                    ''Configuracion del campo que maneja la descripcion 
                    With txtTipPers
                        .NombreCampoDatos = "DESCRIPCION"
                        .ControlTextoEnlace = txtCodTipPers
                        Try
                            .OrigenDeDatos = objQx.CargarCombosDescQX(1)
                            .CargarDatosDescripcion()
                        Catch ex As Exception
                            MsgBox("Error en la consulta de los tipos profesional. " & ex.Message, MsgBoxStyle.Information)
                        End Try
                    End With
                Case 2 ''Especialidad
                    Try
                        cmbEspecialidad.ResetText()
                        cmbEspecialidad.BeginUpdate()

                        dt = objQx.CargarCombosDescQX(2, txtCodProfes.Text)

                        If dt.Rows.Count = 0 Then
                            MsgBox("No existen especialidades parametrizadas para el médico seleccionado")
                            txtCodProfes.Text = String.Empty
                            txtDescProfes.Text = String.Empty
                        End If
                        cmbEspecialidad.DataSource = dt

                        cmbEspecialidad.DisplayMember = "descripcion"
                        cmbEspecialidad.ValueMember = "especialidad"
                        cmbEspecialidad.EndUpdate()
                    Catch ex As Exception
                        MsgBox("Error en la consulta de especialidades. " & ex.Message, MsgBoxStyle.Information)
                    End Try

                Case 3
                    cmbProcedim.ResetText()
                    cmbProcedim.BeginUpdate()
                    txtcodProce.ControlComboEnlace = cmbProcedim

                    With cmbProcedim
                        .CampoMostrar = "descripcion"
                        .ControlTextoEnlace = txtcodProce
                        .CampoEnlazado = "Codigo"
                        .CategoriaDatos = CategoriaDatos.Procedimientos
                        .CargarDatos()
                        .CargarButton()
                    End With
                    cmbProcedim.EndUpdate()
                Case 4 ''Todas las Especialidades
                    Try
                        cmbEspecialidad.ResetText()
                        cmbEspecialidad.BeginUpdate()

                        cmbEspecialidad.DataSource = objQx.CargarCombosDescQX(3)
                        cmbEspecialidad.DisplayMember = "descripcion"
                        cmbEspecialidad.ValueMember = "especialidad"
                        cmbEspecialidad.EndUpdate()
                    Catch ex As Exception
                        MsgBox("Error en la consulta de especialidades. " & ex.Message, MsgBoxStyle.Information)
                    End Try
                Case 5 ''Tipo de Anestesia
                    Try
                        cmbAnestesia.ResetText()
                        cmbAnestesia.BeginUpdate()

                        cmbAnestesia.DataSource = objQx.CargarCombosDescQX(4)
                        cmbAnestesia.DisplayMember = "descripcion"
                        cmbAnestesia.ValueMember = "tip_anestesia"
                        cmbAnestesia.EndUpdate()
                    Catch ex As Exception
                        MsgBox("Error en la consulta de los tipos de anestesia. " & ex.Message, MsgBoxStyle.Information)
                    End Try
                Case 6 ''Medicamentos para profilaxis
                    cmbProfilaxis.ResetText()
                    cmbProfilaxis.BeginUpdate()
                    txtCodProfilaxis.ControlComboEnlace = cmbProfilaxis

                    With cmbProfilaxis
                        .CampoMostrar = "descripcion"
                        .ControlTextoEnlace = txtCodProfilaxis
                        .CampoEnlazado = "Codigo"
                        .CategoriaDatos = CategoriaDatos.OrdenMedicamentosDescripcion
                        .CargarDatos()
                        .CargarButton()
                    End With
                    cmbProfilaxis.EndUpdate()

                    dt.Columns.Add("codigo", System.Type.GetType("System.String"))
                    dt.Columns.Add("medicamento", System.Type.GetType("System.String"))
                    dtgProfilaxis.DataSource = dt
                Case 7 ''Tipo de Cirugia
                    Try
                        cmbTipoQx.ResetText()
                        cmbTipoQx.BeginUpdate()

                        cmbTipoQx.DataSource = objQx.CargarCombosDescQX(5, "", objGeneral.Prestador, objGeneral.Sucursal)
                        cmbTipoQx.DisplayMember = "DESCRIPCION"
                        cmbTipoQx.ValueMember = "TIE_LIMPIEZA"
                        cmbTipoQx.EndUpdate()
                    Catch ex As Exception
                        MsgBox("Error en la consulta de tipos de Cirugía. " & ex.Message, MsgBoxStyle.Information)
                    End Try

            End Select

        Catch ex As Exception



        End Try


    End Sub


    Private Sub IniciarProcedimientos()
        LimpiardatosDescQX()
        TraerDetalleProcedimiento()

        'BloquearControles(True)
        'btnAgregarProc.Enabled = True
        If lblTiempQx.Text = "" Then
            BloquearControles(True)
            btnAgregarProc.Enabled = True
        Else
            If Len(txtSangrado.Text) > 0 Or Len(txtTejidos.Text) > 0 _
            Or Len(txtDescIntervencion.Text) > 0 Or Len(txtComplicaciones.Text) > 0 _
            Or Len(txtHallazgos.Text) > 0 Then
                BloquearControles(True)
            Else
                BloquearControles(False)
                btnAgregarProc.Enabled = True
            End If
        End If
    End Sub

    Private Sub BloquearControles(ByVal boolBloquea As Boolean)

        If boolBloquea = True Then
            GroupBox1.Enabled = False
            GroupBox3.Enabled = False
            GroupBox2.Enabled = False
            GroupBox7.Enabled = False
            txtHallazgos.Enabled = False
            GroupBox5.Enabled = False
            txtTejidos.Enabled = False
            txtDescIntervencion.Enabled = False
            cmbTipoQx.Enabled = False
            txtSangrado.Enabled = False
            Me.GroupBox6.Enabled = True
            ' Me.RadioButtonNo.Checked = True
        Else
            GroupBox1.Enabled = True
            GroupBox3.Enabled = True
            GroupBox2.Enabled = True
            GroupBox7.Enabled = True
            txtHallazgos.Enabled = True
            GroupBox5.Enabled = True
            txtTejidos.Enabled = True
            txtDescIntervencion.Enabled = True
            cmbTipoQx.Enabled = True
            txtSangrado.Enabled = True
            Me.GroupBox6.Enabled = True
            'Me.RadioButtonNo.Checked = True
        End If

    End Sub
    ''cpgaray  13 feb 2012
    Private Sub TraerDetalleProcedimiento()
        Dim dsdetalle As New DataSet
        Dim dspatologia As New DataSet
        Dim dtspatologia As New DataTable

        Dim strDescripcionOriginal As String = ""

        Try

            If dtgProcedim.CurrentRow Is Nothing Then
                MsgBox("Seleccione un procedimiento")
                Exit Sub
            Else
                txtcodProce.Enabled = False
                txtcodProce.Text = dtgProcedim.CurrentRow.Cells("Procedimiento").Value
                cmbProcedim.Text = dtgProcedim.CurrentRow.Cells("Descripcion").Value
                mskInicioCir.Text = IIf(IsDBNull(dtgProcedim.CurrentRow.Cells("FechaInicio").Value), "", dtgProcedim.CurrentRow.Cells("FechaInicio").Value)
                txtHoraCir.Text = IIf(IsDBNull(dtgProcedim.CurrentRow.Cells("HoraInicio").Value), "", dtgProcedim.CurrentRow.Cells("HoraInicio").Value)
                txtMinCir.Text = IIf(IsDBNull(dtgProcedim.CurrentRow.Cells("MinutoInicio").Value), "", dtgProcedim.CurrentRow.Cells("MinutoInicio").Value)
                mskFinalCir.Text = IIf(IsDBNull(dtgProcedim.CurrentRow.Cells("FechaFinal").Value), "", dtgProcedim.CurrentRow.Cells("FechaFinal").Value)
                txtHoraFinalCir.Text = IIf(IsDBNull(dtgProcedim.CurrentRow.Cells("HoraFinal").Value), "", dtgProcedim.CurrentRow.Cells("HoraFinal").Value)
                txtMinFinCir.Text = IIf(IsDBNull(dtgProcedim.CurrentRow.Cells("MinutoFinal").Value), "", dtgProcedim.CurrentRow.Cells("MinutoFinal").Value)
                lblTiempQx.Text = IIf(IsDBNull(dtgProcedim.CurrentRow.Cells("TiempoQX").Value), "", dtgProcedim.CurrentRow.Cells("TiempoQX").Value)
                btnAgregarProc.Enabled = True
                objDescrQx.Consecutivo = dtgProcedim.CurrentRow.Cells("consecutivo").Value
                objDescrQx.Secuencia = IIf(IsDBNull(dtgProcedim.CurrentRow.Cells("secuencia").Value), 0, dtgProcedim.CurrentRow.Cells("secuencia").Value)
                objDescrQx.Procedimiento = dtgProcedim.CurrentRow.Cells("Procedimiento").Value
                'Joseph Moreno (IG) Fec:2019/11/18 Particularidades
                objDescrQx.Descripcion = dtgProcedim.CurrentRow.Cells("Descripcion").Value
                If dtgProcedim.Columns.Contains("genprocedes") Then
                    strDescripcionOriginal = dtgProcedim.CurrentRow.Cells("genprocedes").Value
                Else
                    strDescripcionOriginal = cmbProcedim.Text
                End If
                If dtgProcedim.Columns.Contains("particularidades") Then
                    objDescrQx.Particularidades = dtgProcedim.CurrentRow.Cells("particularidades").Value
                End If
                If IsDBNull(dtgProcedim.CurrentRow.Cells("bilateral").Value) Then
                    dtgProcedim.CurrentRow.Cells("bilateral").Value = "N"
                End If
                If dtgProcedim.CurrentRow.Cells("bilateral").Value = "S" Then
                    chkBilateral.Checked = True

                Else
                    chkBilateral.Checked = False
                End If

                If IsDBNull(dtgProcedim.CurrentRow.Cells("estado").Value) Then
                    btnAgregarProc.Enabled = True
                ElseIf dtgProcedim.CurrentRow.Cells("estado").Value = "I" Then
                    btnAgregarProc.Enabled = False
                Else
                    btnAgregarProc.Enabled = True
                End If

                'Joseph Moreno (IG) Fec:2019/11/18 Particularidades
                Me.ctlPartProce.PasarDatos(
                    Me.txtcodProce.Text, strDescripcionOriginal,
                    Sub(ByVal strDescripcionTotal As String, ByVal strXmlParticularidades As String, ByVal iCantidad As Integer, ByVal strXmlProcedimientos As String)
                        ActualizarTextoDescripcion(strDescripcionTotal)
                        objDescrQx.Descripcion = strDescripcionTotal
                        objDescrQx.Particularidades = strXmlParticularidades
                    End Sub,
                    strXmlGrpXPart:=objDescrQx.Particularidades)

            End If

            dsdetalle = objQx.ConsultarDetalleProcedimientosXAdmision(objGeneral.Prestador, objGeneral.Sucursal, dtgProcedim.CurrentRow.Cells("consecutivo").Value, dtgProcedim.CurrentRow.Cells("Procedimiento").Value)
            dspatologia = objQx.ConsultarOrdenPatologia(objGeneral.Prestador, objGeneral.Sucursal, dtgProcedim.CurrentRow.Cells("consecutivo").Value, dtgProcedim.CurrentRow.Cells("Procedimiento").Value, objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision)
            dtspatologia = dspatologia.Tables(0)
            If dsdetalle.Tables.Count = 0 Then
                Exit Sub
            End If

            CargarTiempos(dsdetalle.Tables(0))
            CargarEquipoQuirurgico(dsdetalle.Tables(1))
            CargarPersonalMedico(dsdetalle.Tables(2))
            CargarDiagnosticos(dsdetalle.Tables(3), dsdetalle.Tables(4))
            CargarProfilaxis(dsdetalle.Tables(5))
            CargarDatosDescripcionQX(dsdetalle.Tables(6))
            txtcodProce.Enabled = False
            cmbProcedim.Enabled = False
            'Joseph Moreno (IG) Fec:2019/11/19 Particularidades
            Me.ctlPartProce.Activar(False)

            If dtspatologia.Rows.Count > 0 Then
                Me.btImprimir.Visible = True
                Me.RadioButtonNo.Visible = False
                Me.RadioButtonSi.Checked = True
                Me.RadioButtonSi.Enabled = False
                'GroupBox6.Enabled = False


            Else
                Me.btImprimir.Visible = False
                Me.RadioButtonNo.Visible = True
                Me.RadioButtonSi.Enabled = True
            End If

        Catch ex As Exception
            MsgBox("Error al consultar el detalle del procedimiento " & ex.Message)
        End Try
    End Sub
    'Private Sub TextosBuscador_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescProfes.TextChanged, txtCodProfes.TextChanged  ', txtNumeroDocumento.TextChanged, txtNumeroCama.TextChanged, txtNumeroAdmision.TextChanged, txtDescTipoDocumento.TextChanged, txtCodigoTipoDocumento.TextChanged, txtAnoAdmision.TextChanged

    '    Dim blnTextoBusqueda As Boolean
    '    If sender.Text.Trim.Length > 0 Then
    '        ' cmdLista.Enabled = True
    '    Else
    '        Dim ctlControl As Control

    '        For Each ctlControl In Me.pnlProfesional.Controls
    '            If TypeOf ctlControl Is TextBox Then
    '                If ctlControl.Text.Trim.Length > 0 Then
    '                    blnTextoBusqueda = True
    '                    Exit For
    '                End If
    '            End If
    '        Next

    '        '    If rbEvolucion.Checked = True Or rbHospitalizacion.Checked = True Then
    '        '        cmdLista.Enabled = blnTextoBusqueda
    '        '    Else
    '        '        cmdLista.Enabled = True
    '        '    End If
    '        'End If

    '        'If Me.txtTipoAdmision.Text <> "" Then
    '        '    If Me.txtAnoAdmision.Text = "" Then
    '        '        Dim temaño As Integer
    '        '        temaño = Year(Date.Today)
    '        '        Me.txtAnoAdmision.Text = temaño
    '        '    End If
    '    End If

    'End Sub
    Private Sub CargarDatosDescripcionQX(ByVal dt As DataTable)

        If dt.Rows.Count > 0 Then

            'If Not IsDBNull(dt.Rows(0).Item("sangrado")) Then
            '    If dt.Rows(0).Item("sangrado") = "0" Then
            '        rbSangradoNo.Checked = True
            '    Else
            '        txtSangrado.Text = dt.Rows(0).Item("sangrado")
            '        rbSangradoSi.Checked = True
            '    End If
            'End If

            If Not IsDBNull(dt.Rows(0).Item("sangrado")) Then
                txtSangrado.Text = dt.Rows(0).Item("sangrado")
            End If

            txtTejidos.Text = IIf(IsDBNull(dt.Rows(0).Item("tejidos")), "", dt.Rows(0).Item("tejidos"))
            txtDescIntervencion.Text = IIf(IsDBNull(dt.Rows(0).Item("desc_intervencion")), "", dt.Rows(0).Item("desc_intervencion"))

            If Not IsDBNull(dt.Rows(0).Item("recuento_material")) Then
                If dt.Rows(0).Item("recuento_material") = "I" Then
                    rbIncompleto.Checked = True
                ElseIf dt.Rows(0).Item("recuento_material") = "C" Then
                    rbCompleto.Checked = True
                Else
                    rbIncompleto.Checked = False
                    rbCompleto.Checked = False
                    rbNA.Checked = True
                End If
            End If

            '
            If Not IsDBNull(dt.Rows(0).Item("complicaciones")) Then
                If Len(dt.Rows(0).Item("complicaciones")) > 0 Then
                    rbSiCompl.Checked = True
                    txtComplicaciones.Text = dt.Rows(0).Item("complicaciones")
                Else
                    rbSiCompl.Checked = False
                End If
            End If
            txtHallazgos.Text = IIf(IsDBNull(dt.Rows(0).Item("hallazgos")), "", dt.Rows(0).Item("hallazgos"))
        End If


    End Sub
    Private Sub CargarProfilaxis(ByVal dt As DataTable)

        If dt.Rows.Count = 0 Then
            rbProfilaxisNo.Checked = True
        Else
            rbProfilaxisSi.Checked = True
        End If

        dtgProfilaxis.DataSource = dt
        dtgProfilaxis.Columns("Medicamento").Width = 425
        dtgProfilaxis.Columns("codigo").Width = 100

    End Sub
    Private Sub CargarDiagnosticos(ByVal dtpre As DataTable, Optional ByVal dtpos As DataTable = Nothing)

        Try
            If Not dtpre Is Nothing > 0 Then
                With dtgPreoperatorio
                    .DataSource = dtpre
                    .Columns("consecutivo").Visible = False
                    .Columns("procedim").Visible = False
                    '.Columns("tip_diag").Visible = False
                    .Columns("login").Visible = False
                    .Columns("clasificacion").Visible = False
                    .Columns("clase").Visible = False
                    .Columns("diagnost").Visible = False
                    .Columns("Diagnostic").Width = 250
                    ' .Columns("TipoDiagnostico").Width = 50
                End With
            End If

            If Not dtpos Is Nothing > 0 Then
                With dtgPostperatorio
                    .DataSource = dtpos
                    .Columns("consecutivo").Visible = False
                    .Columns("procedim").Visible = False
                    '.Columns("tip_diag").Visible = False
                    .Columns("login").Visible = False
                    .Columns("clasificacion").Visible = False
                    .Columns("clase").Visible = False
                    .Columns("diagnost").Visible = False
                    .Columns("Diagnostic").Width = 250
                    '.Columns("TipoDiagnostico").Width = 50
                End With

            End If

            If dtpre.Rows.Count = 0 Then
                'Consultamos los diagnosticos de la impresion diagnosticos los cuales seran postoperatotio
                TieneImpresionDiagnostica()
            End If

        Catch ex As Exception
            MsgBox("Error al cargar los diagnósticos " & ex.Message)
        End Try
    End Sub
    Private Sub CargarTiempos(ByVal dt As DataTable)


        If dt.Rows.Count > 0 Then
            mskFechaIng.Text = dt.Rows(0).Item("fecha_inicial")
            txtHora.Text = dt.Rows(0).Item("hor_inicial")
            txtMin.Text = dt.Rows(0).Item("min_inicial")
            mskSalida.Text = dt.Rows(0).Item("fecha_final")
            txtHoraSal.Text = dt.Rows(0).Item("hor_final")
            txtMinSal.Text = dt.Rows(0).Item("min_final")
            cmbAnestesia.Text = dt.Rows(0).Item("descripcion")
            cmbTipoQx.Text = IIf(IsDBNull(dt.Rows(0).Item("tie_limpieza")), "", dt.Rows(0).Item("tie_limpieza"))
        End If

        If mskInicioCir.Text = "  /  /" Then
            mskInicioCir.Text = Format(FuncionesGenerales.FechaServidor(), "dd/MM/yyyy")
            mskFinalCir.Text = Format(FuncionesGenerales.FechaServidor(), "dd/MM/yyyy")

        End If

    End Sub

    Private Sub CargarEquipoQuirurgico(ByVal dt As DataTable)

    End Sub

    Private Sub CargarPersonalMedico(ByVal dt As DataTable)

        Try

            With dtgPersonalMedico
                .DataSource = dt
                .Columns("cod_pre_sgs").Visible = False
                .Columns("cod_sucur").Visible = False
                .Columns("consecutivo").Visible = False
                .Columns("procedim").Visible = False
                .Columns("tip_empleado").Visible = False
                .Columns("estado").Visible = False
                .Columns("bilateral").Visible = False
                .Columns("espc").Visible = False
                .Columns("login").Visible = False
                .Columns("nro_autoriza").Visible = False
                '.Columns("descripcion").Visible = False
                .Columns("Especialidad").Width = 150
                .Columns("Medico").Width = 250
                .Columns("tipoprofesional").Width = 150
            End With

            If dt.Rows.Count > 0 Then
                objDescrQx.NroAutorizacion = IIf(IsDBNull(dt.Rows(0).Item("nro_autoriza")), "", dt.Rows(0).Item("nro_autoriza"))

                If Not IsDBNull(dt.Rows(0).Item("bilateral")) Then

                    If dt.Rows(0).Item("bilateral") = "S" Then
                        chkBilateral.Checked = True
                    ElseIf dt.Rows(0).Item("bilateral") = "N" Then
                        chkBilateral.Checked = False
                    Else
                        chkBilateral.Checked = False
                    End If
                Else
                    chkBilateral.Checked = False
                End If
                chkBilateral.Enabled = False
            End If

        Catch ex As Exception

        End Try

    End Sub


    Private Sub CalcularTiempoQuirurgico()
        Dim hora As Integer
        Dim min As Integer
        Dim fec_ini As Date
        Dim fec_fin As Date
        Dim diferencia As Long


        Try


            If mskFinalCir.Text = mskInicioCir.Text Then


                If Val(txtHoraCir.Text) > 0 And Val(txtHoraFinalCir.Text) > 0 Then

                    If Val(txtHoraFinalCir.Text) < Val(txtHoraCir.Text) Then
                        MsgBox("La hora de finalización no puede ser menor a la hora de inicio")
                        txtHoraFinalCir.Focus()
                        Exit Sub
                    End If

                    hora = Val(txtHoraFinalCir.Text) - Val(txtHoraCir.Text)

                    If IIf(Len(txtMinFinCir.Text) = 0, 0, Val(txtMinFinCir.Text)) < IIf(Len(txtMinCir.Text) = 0, 0, Val(txtMinCir.Text)) Then
                        If Val(txtHoraFinalCir.Text) = Val(txtHoraCir.Text) Then
                            MsgBox("La hora de finalización no puede ser menor a la hora de inicio")
                            txtMinFinCir.Focus()
                            Exit Sub

                        End If
                        min = (60 - Val(txtMinCir.Text)) + Val(txtMinFinCir.Text)
                        hora = hora - 1
                    Else
                        min = Val(txtMinFinCir.Text) - Val(txtMinCir.Text)
                    End If

                    lblTiempQx.Text = hora & " Horas " & min & " Minutos"

                Else

                    If Val(txtHoraCir.Text) = 0 And Val(txtHoraFinalCir.Text) > 0 Then

                        hora = Val(txtHoraFinalCir.Text)

                        If IIf(Len(txtMinFinCir.Text) = 0, 0, Val(txtMinFinCir.Text)) < IIf(Len(txtMinCir.Text) = 0, 0, Val(txtMinCir.Text)) Then
                            If Val(txtHoraFinalCir.Text) = Val(txtHoraCir.Text) Then
                                MsgBox("La hora de finalización no puede ser menor a la hora de inicio")
                                txtMinFinCir.Focus()
                                Exit Sub

                            End If
                            min = (60 - Val(txtMinCir.Text)) + Val(txtMinFinCir.Text)
                            hora = hora - 1
                        Else
                            min = Val(txtMinFinCir.Text) - Val(txtMinCir.Text)
                        End If

                        lblTiempQx.Text = hora & " Horas " & min & " Minutos"
                    Else
                        MsgBox("Datos incompletos")
                        If Val(txtHoraCir.Text) > 0 Then
                            txtHoraFinalCir.Focus()
                        Else
                            txtHoraCir.Focus()
                        End If
                    End If
                End If

            Else

                fec_ini = mskInicioCir.Text & " " & txtHoraCir.Text & ":" & txtMinCir.Text
                fec_fin = mskFinalCir.Text & " " & txtHoraFinalCir.Text & ":" & txtMinFinCir.Text
                diferencia = DateDiff(DateInterval.Hour, fec_ini, fec_fin)



                If IIf(Len(txtMinFinCir.Text) = 0, 0, Val(txtMinFinCir.Text)) < IIf(Len(txtMinCir.Text) = 0, 0, Val(txtMinCir.Text)) Then
                    min = (60 - Val(txtMinCir.Text)) + Val(txtMinFinCir.Text)

                Else
                    min = Val(txtMinFinCir.Text) - Val(txtMinCir.Text)
                End If

                lblTiempQx.Text = diferencia & " Horas " & min & " Minutos"

            End If

        Catch ex As Exception

            MsgBox("Error al calcular el tiempo quirúrgico " & ex.Message)
        End Try


    End Sub


    Private Sub BuscarMedico()

        Dim frmConsulta As New frmc_ConsultaMedicoQx(txtDescProfes.Text, IIf(Len(txtCodTipPers.Text) = 0, "", txtCodTipPers.Text), txtNombre.Text)
        Try


            frmConsulta.ShowDialog()
            txtCodProfes.Text = frmConsulta.CodigoMedico
            txtDescProfes.Text = frmConsulta.ApellidoMedico
            txtNombre.Text = frmConsulta.NombreMedico

            If Len(txtCodProfes.Text) > 0 Then
                CargarCombos(2)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub ConsultarMedicoXDoc()
        Try

            If objQx.ConsultaMedicoXDoc(txtCodProfes.Text) = "" Then
                MsgBox("No existen registros para el dato ingresado")
            Else
                txtDescProfes.Text = objQx.ConsultaMedicoXDoc(txtCodProfes.Text)
                CargarCombos(2)
            End If

        Catch ex As Exception
            MsgBox("Error al consultar el médico" & ex.Message)
        End Try
    End Sub

    Private Sub AgregaMedico()
        Dim drow As DataRow
        Dim dtmedico As New DataTable
        Dim rows() As DataRow
        Dim dtproc As DataTable = dtgProcedim.DataSource
        Dim rowsProc() As DataRow
        Dim drowProc As DataRow
        Dim cont As Integer = 0

        'If txtCodTipPers.Text = "V" And txtCirujanoInvitado.Text = "" Then
        '    MsgBox("Datos Incompletos")
        '    Exit Sub
        'End If

        If txtCodTipPers.Text <> "V" And (txtCodTipPers.Text = "" Or txtCodProfes.Text = "" Or cmbEspecialidad.Text = "") Then
            MsgBox("Datos Incompletos")
            Exit Sub
        End If

        Try
            dtmedico = dtgPersonalMedico.DataSource
            strCirujanoInvitado = "N"
            If strCirujanoInvitado = "N" Then

                If Not dtmedico Is Nothing Then
                    If dtmedico.Rows.Count > 0 Then
                        rows = dtmedico.Select("consecutivo='" & dtmedico.Rows(0).Item("consecutivo") &
                           "' and procedim='" & dtmedico.Rows(0).Item("procedim") & "' and CodMedico='" &
                        txtCodProfes.Text & "' and tip_empleado='" & txtCodTipPers.Text & "'")

                        If rows.Length > 0 Then
                            MsgBox("Registro ya existe")
                            Exit Sub
                        End If

                    End If
                End If

            Else

                If Not dtmedico Is Nothing Then
                    If dtmedico.Rows.Count > 0 Then
                        rows = dtmedico.Select("consecutivo='" & dtmedico.Rows(0).Item("consecutivo") &
                           "' and procedim='" & dtmedico.Rows(0).Item("procedim") & "' and CodMedico='INVITADO' and tip_empleado='" & txtCodTipPers.Text & "'")

                        If rows.Length > 0 Then
                            MsgBox("Registro ya existe")
                            Exit Sub
                        End If

                    End If
                End If

            End If

            drow = dtmedico.NewRow

            drow.Item("cod_pre_sgs") = objGeneral.Prestador
            drow.Item("cod_sucur") = objGeneral.Sucursal
            drow.Item("consecutivo") = objDescrQx.Consecutivo
            drow.Item("procedim") = objDescrQx.Procedimiento
            drow.Item("tip_empleado") = txtCodTipPers.Text
            drow.Item("estado") = "L" ''NO se que es este estado =(
            drow.Item("bilateral") = IIf(chkBilateral.Checked = True, "S", "N")
            drow.Item("espc") = cmbEspecialidad.SelectedValue
            drow.Item("login") = objGeneral.Login
            drow.Item("especialidad") = cmbEspecialidad.Text
            drow.Item("TipoProfesional") = txtTipPers.Text
            drow.Item("obs") = txtobs.Text
            If strCirujanoInvitado = "N" Then
                drow.Item("CodMedico") = txtCodProfes.Text
                drow.Item("Medico") = txtDescProfes.Text
            Else
                drow.Item("CodMedico") = txtCodProfes.Text
                drow.Item("Medico") = txtDescProfes.Text
                'drow.Item("CodMedico") = "INVITADO"
                'drow.Item("Medico") = txtCirujanoInvitado.Text
            End If

            ''Actualizar el Cirujano en procedimientos nuevos

            'If txtCodTipPers.Text = "C" Then
            '    If Not dtproc Is Nothing Then
            '        If dtproc.Rows.Count > 0 Then
            '            rowsProc = dtproc.Select("consecutivo='" & objDescrQx.Consecutivo & _
            '               "' and procedimiento='" & objDescrQx.Procedimiento & "'")

            '            If rowsProc.Length > 0 Then

            '                For i As Integer = 0 To rowsProc.Length - 1
            '                    rowsProc(0).Item("cod_permedas") = txtCodProfes.Text
            '                Next
            '            End If
            '        End If

            '    End If

            'End If

            If ActualizaEquipoMedico(drow) = True Then
                dtmedico.Rows.Add(drow)
                ' dtgPersonalMedico.DataSource = dtmedico
                With dtgPersonalMedico
                    .DataSource = dtmedico
                    .Columns("cod_pre_sgs").Visible = False
                    .Columns("cod_sucur").Visible = False
                    .Columns("consecutivo").Visible = False
                    .Columns("procedim").Visible = False
                    .Columns("tip_empleado").Visible = False
                    .Columns("estado").Visible = False
                    .Columns("bilateral").Visible = False
                    .Columns("espc").Visible = False
                    .Columns("login").Visible = False
                    .Columns("nro_autoriza").Visible = False
                    '.Columns("descripcion").Visible = False
                    .Columns("Especialidad").Width = 150
                    .Columns("Medico").Width = 250
                    .Columns("tipoprofesional").Width = 150
                End With
            End If



            LimpiarEquipoMedico()
            ''  strCirujanoInvitado = "N"

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub LimpiarEquipoMedico()
        txtCodTipPers.Text = String.Empty
        txtCodProfes.Text = String.Empty
        cmbEspecialidad.ResetText()
        txtTipPers.Text = String.Empty
        txtDescProfes.Text = String.Empty
        txtCirujanoInvitado.Text = String.Empty
        txtobs.Text = String.Empty
        txtNombre.Text = String.Empty
    End Sub
    Private Sub AgregaDiagnostico()
        Dim drow As DataRow
        Dim dtdiagn As New DataTable
        Dim dtdiagnpost As New DataTable
        Dim rows() As DataRow
        Dim boolagregapost As Boolean = False

        Try


            If cmbClaseDiagn.Text = "" Or txtCodDiagnosticoID.Text = "" _
            Or cboDescDiagnosticoID.Text = "" Then

                MsgBox("Datos incompletos", MsgBoxStyle.Critical, "Diagnósticos")
                Exit Sub

            End If

            If cmbClaseDiagn.Text = "PREOPERATORIO" Then
                dtdiagn = dtgPreoperatorio.DataSource
                dtdiagnpost = dtgPostperatorio.DataSource
                boolagregapost = True

            Else
                dtdiagn = dtgPostperatorio.DataSource
            End If

            If Not dtdiagn Is Nothing Then
                If dtdiagn.Rows.Count > 0 Then
                    rows = dtdiagn.Select("consecutivo='" & dtdiagn.Rows(0).Item("consecutivo") &
                                "' and procedim='" & dtdiagn.Rows(0).Item("procedim") & "' and diagnost='" & txtCodDiagnosticoID.Text & "'")

                    If rows.Length > 0 Then
                        MsgBox("Registro ya existe")
                        Exit Sub
                    End If
                    If cmbClaseDiagn.Text = "PREOPERATORIO" Then
                        If Not dtdiagnpost Is Nothing Then
                            If dtdiagnpost.Rows.Count > 0 Then
                                rows = dtdiagnpost.Select("consecutivo='" & dtdiagn.Rows(0).Item("consecutivo") &
                                            "' and procedim='" & dtdiagn.Rows(0).Item("procedim") & "' and diagnost='" & txtCodDiagnosticoID.Text & "'")

                                If rows.Length > 0 Then
                                    MsgBox("Registro ya existe como postoperatorio")
                                    boolagregapost = False
                                Else
                                    boolagregapost = True
                                End If

                            End If

                        End If
                    End If

                End If



            Else
                dtdiagnpost.Rows.Add(dtdiagnpost.NewRow)
                dtdiagn.Rows.Add(dtdiagn.NewRow)
            End If



            drow = dtdiagn.NewRow

            drow.Item("consecutivo") = objDescrQx.Consecutivo
            drow.Item("procedim") = objDescrQx.Procedimiento
            drow.Item("diagnostic") = cboDescDiagnosticoID.Text
            'drow.Item("tip_diag") = txtCodTipoDiagnosticoID.Text
            'drow.Item("TipoDiagnostico") = txtDescTipoDiagnosticoID.Text
            drow.Item("diagnost") = txtCodDiagnosticoID.Text
            drow.Item("login") = objGeneral.Login
            drow.Item("obs") = txtobsdiagn.Text
            drow.Item("clasificacion") = strClasifiDiagn
            If cmbClaseDiagn.Text = "PREOPERATORIO" Then
                drow.Item("clase") = "PRE"
            Else
                drow.Item("clase") = "POS"
            End If
            dtdiagn.Rows.Add(drow)

            If ActualizaDiagnosticos(drow) Then
                If cmbClaseDiagn.Text = "PREOPERATORIO" Then
                    dtgPreoperatorio.DataSource = dtdiagn
                Else
                    dtgPostperatorio.DataSource = dtdiagn
                End If
            End If

            If boolagregapost = True Then
                'dtdiagnpost=dtgPostperatorio
                drow = dtdiagnpost.NewRow

                drow.Item("consecutivo") = objDescrQx.Consecutivo
                drow.Item("procedim") = objDescrQx.Procedimiento
                drow.Item("diagnostic") = cboDescDiagnosticoID.Text
                ' drow.Item("tip_diag") = txtCodTipoDiagnosticoID.Text
                'drow.Item("TipoDiagnostico") = txtDescTipoDiagnosticoID.Text
                drow.Item("diagnost") = txtCodDiagnosticoID.Text
                drow.Item("login") = objGeneral.Login
                drow.Item("obs") = txtobsdiagn.Text
                drow.Item("clasificacion") = strClasifiDiagn
                drow.Item("clase") = "POS"

                dtdiagnpost.Rows.Add(drow)

                If ActualizaDiagnosticos(drow) Then
                    If cmbClaseDiagn.Text = "PREOPERATORIO" Then
                        dtgPostperatorio.DataSource = dtdiagnpost
                    End If

                End If
            End If

            cmbClaseDiagn.Text = String.Empty
            ' txtCodTipoDiagnosticoID.Text = String.Empty
            ' txtDescTipoDiagnosticoID.Text = String.Empty
            txtCodDiagnosticoID.Text = String.Empty
            cboDescDiagnosticoID.Text = String.Empty
            txtobsdiagn.Text = String.Empty

        Catch ex As Exception

            MsgBox(ex.Message)
        End Try



    End Sub
    Private Sub cmbProcedim_ActualizarDatosElegidos(ByVal datosElegidos As System.Data.DataRow) Handles cmbProcedim.ActualizarDatosElegidos
        If datosElegidos Is Nothing Then
            txtcodProce.Text = ""
            'Joseph Moreno (IG) Fec:2019/11/18 Particularidades
            Me.ctlPartProce.Limpiar(True)
            Exit Sub
        End If

        txtcodProce.Text = datosElegidos.Item("codigo").ToString

        If datosElegidos.Item("bilateral").ToString = "S" Then
            chkBilateral.Checked = True
        Else
            chkBilateral.Checked = False
        End If

        'Joseph Moreno (IG) Fec:2019/11/18 Particularidades
        Me.ctlPartProce.PasarDatos(
            txtcodProce.Text, cmbProcedim.Text,
            Sub(ByVal strDescripcionTotal As String, ByVal iCantidad As String, ByVal strXmlParticularidades As String, ByVal strXmlProcedimientos As String)
                ActualizarTextoDescripcion(strDescripcionTotal)
                'Joseph Moreno (IG) Fec:2019/11/18 Bilateral
                chkBilateral.Checked = IIf(iCantidad < 2, False, True)
            End Sub)
    End Sub

    'Joseph Moreno (IG) Fec:2019/11/18 Particularidades
    Private Sub ActualizarTextoDescripcion(ByVal strDescripcionTotal As String)
        cmbProcedim.Text = strDescripcionTotal
    End Sub

    Private Sub txtMinFinCir_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMinFinCir.Validating
        CalcularTiempoQuirurgico()
    End Sub


    Private Sub txtHoraFinalCir_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtHoraFinalCir.Validating
        'CalcularTiempoQuirurgico()
    End Sub


    Private Sub txtMinCir_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMinCir.Validating

        If Len(txtHoraFinalCir.Text) > 0 And Len(txtHoraCir.Text) > 0 Then
            CalcularTiempoQuirurgico()
        End If
    End Sub

    Private Sub txtHoraCir_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtHoraCir.Validating
        If Len(txtHoraFinalCir.Text) > 0 Then
            CalcularTiempoQuirurgico()
        End If
    End Sub


    Private Sub mskInicioCir_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mskInicioCir.Validating
        If mskInicioCir.Text <> "  /  /" Then
            If Not IsDate(mskInicioCir.Text) Then
                MsgBox("Fecha invalida. Debe digitar una fecha valida.", MsgBoxStyle.Information)
                e.Cancel = True
                mskInicioCir.Select(0, mskInicioCir.TextLength)
            End If
        End If
    End Sub

    Private Sub mskFinalCir_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mskFinalCir.Validating
        If mskFinalCir.Text <> "  /  /" Then
            If Not IsDate(mskFinalCir.Text) Then
                MsgBox("Fecha invalida. Debe digitar una fecha valida.", MsgBoxStyle.Information)
                e.Cancel = True
                mskFinalCir.Select(0, mskFinalCir.TextLength)
            Else
                If Not CDate(mskFinalCir.Text) >= CDate(mskInicioCir.Text) Then
                    MsgBox("La fecha de finalización no puede ser menor a la de inicio.", MsgBoxStyle.Information)
                    e.Cancel = True
                    mskFinalCir.Select(0, mskFinalCir.TextLength)
                End If
            End If
        End If
    End Sub

    Private Sub btnAgregarEquipo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarEquipo.Click
        AgregaMedico()
    End Sub

    Private Sub txtCodProfes_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtCodProfes.MouseDoubleClick
        'BuscarMedico()

        Dim frmConsulta As New frmc_ConsultaMedicoQx("", IIf(Len(txtCodTipPers.Text) = 0, "", txtCodTipPers.Text), "")
        frmConsulta.ShowDialog()
        If Len(frmConsulta.CodigoMedico) > 0 Then
            txtCodProfes.Text = frmConsulta.CodigoMedico
            txtDescProfes.Text = frmConsulta.ApellidoMedico
            txtNombre.Text = frmConsulta.NombreMedico
        End If

    End Sub
    Private Sub txtCodProfes_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodProfes.Validating
        If Len(txtCodProfes.Text) > 0 Then
            ConsultarMedicoXDoc()
        End If
    End Sub


    Private Sub txtTipPers_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTipPers.Validating
        txtCodProfes.Text = String.Empty
        txtDescProfes.Text = String.Empty
        txtCirujanoInvitado.Text = String.Empty
        cmbEspecialidad.ResetText()

        If txtCodTipPers.Text = "V" Then 'Cirujano invitado
            pnlCirujanoInv.Visible = True
            pnlProfesional.Visible = False
            ''strCirujanoInvitado = "S"
        Else
            strCirujanoInvitado = "N"
            pnlCirujanoInv.Visible = False
            pnlProfesional.Visible = True
        End If
    End Sub


    Private Sub txtDescProfes_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)

        If Len(txtDescProfes.Text) > 0 Then
            BuscarMedico()
        Else
            ConsultarMedicoXDoc()
        End If

    End Sub

    Private Sub txtCirujanoInvitado_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCirujanoInvitado.Validating
        CargarCombos(4)
    End Sub

    Private Sub rbProfilaxisSi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbProfilaxisSi.CheckedChanged

        If rbProfilaxisSi.Checked = True Then
            'dtgProfilaxis.Enabled = True
            'txtCodProfilaxis.Enabled = True
            'cmbProfilaxis.Enabled = True
            'cmdAgregarProfilaxis.Enabled = True
            pnlProfilaxis.Enabled = True

        Else
            pnlProfilaxis.Enabled = False
            'dtgProfilaxis.Enabled = False
            'txtCodProfilaxis.Enabled = False
            'cmbProfilaxis.Enabled = False
            'cmdAgregarProfilaxis.Enabled = False
        End If

    End Sub

    Private Sub rbProfilaxisNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbProfilaxisNo.CheckedChanged
        If rbProfilaxisNo.Checked = True Then
            pnlProfilaxis.Enabled = False
            'dtgProfilaxis.Enabled = False
            'txtCodProfilaxis.Enabled = False
            'cmbProfilaxis.Enabled = False
            'cmdAgregarProfilaxis.Enabled = False
        Else
            pnlProfilaxis.Enabled = True
            'dtgProfilaxis.Enabled = True
            'txtCodProfilaxis.Enabled = True
            'cmbProfilaxis.Enabled = True
            'cmdAgregarProfilaxis.Enabled = True
        End If
    End Sub

    Private Sub cmbProfilaxis_ActualizarDatosElegidos(ByVal datosElegidos As System.Data.DataRow) Handles cmbProfilaxis.ActualizarDatosElegidos
        If datosElegidos Is Nothing Then
            txtCodProfilaxis.Text = ""
            cmbProfilaxis.Text = ""
            Exit Sub
        End If

        With datosElegidos
            txtCodProfilaxis.Text = .Item("codigo").ToString
            'txtCodProfilaxis.Text = .Item("codigo").ToString
        End With
    End Sub

    Private Sub cmdAgregarProfilaxis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAgregarProfilaxis.Click
        AgregarProfilaxis()
    End Sub

    Private Sub AgregarProfilaxis()
        Dim drow As DataRow
        Dim dtprofilaxis As New DataTable
        Dim rows() As DataRow
        Dim dtproc As DataTable = dtgProcedim.DataSource
        Dim cont As Integer = 0

        Try


            dtprofilaxis = dtgProfilaxis.DataSource

            If Not dtprofilaxis Is Nothing Then

                If dtprofilaxis.Rows.Count > 0 Then

                    rows = dtprofilaxis.Select("codigo='" & txtCodProfilaxis.Text & "'")

                    If rows.Length > 0 Then
                        MsgBox("Registro ya existe")
                        Exit Sub
                    End If
                End If
            End If




            drow = dtprofilaxis.NewRow

            drow.Item("codigo") = txtCodProfilaxis.Text
            drow.Item("medicamento") = cmbProfilaxis.Text



            If ActualizaProfilaxis(drow, 0) Then
                dtprofilaxis.Rows.Add(drow)
                dtgProfilaxis.DataSource = dtprofilaxis
            End If



            dtgProfilaxis.Columns("codigo").Width = 100
            dtgProfilaxis.Columns("medicamento").Width = 400

            txtCodProfilaxis.Text = String.Empty
            cmbProfilaxis.Text = String.Empty

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub CargarObjetosDiagnosticos()
        Dim objLocal As New BLBasicasLocales

        Try


            '/Para Tipo Diagnóstico
            'With txtCodTipoDiagnosticoID
            '    .NombreCampoBusqueda = "tip_diag"
            '    .NombreCampoBuscado = "descripcion"
            '    .ControlTextoEnlace = txtDescTipoDiagnosticoID
            'End With
            'With txtDescTipoDiagnosticoID
            '    .NombreCampoDatos = "descripcion"
            '    .ControlTextoEnlace = txtCodTipoDiagnosticoID
            '    .OrigenDeDatos = objLocal.TraerDatosTablasBasicasLocales(objGeneral.CadenaLocal, "hcTipDiag", "tip_diag,descripcion", "")
            '    .CargarDatosDescripcion()
            'End With
            '/Para los Diagnosticos
            txtCodDiagnosticoID.ControlComboEnlace = cboDescDiagnosticoID
            With cboDescDiagnosticoID
                .CampoMostrar = "descripcion"
                .ControlTextoEnlace = txtCodDiagnosticoID
                .CampoEnlazado = "codigo"
                .CategoriaDatos = CategoriaDatos.Diagnosticos
                .Login = objGeneral.Login
                .SexoPaciente = objPaciente.Genero
                .EdadPaciente = objPaciente.Edad
                .CargarDatos()
                .CargarButton()
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnAgregarDiagn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarDiagn.Click
        AgregaDiagnostico()
    End Sub

    Private Sub cboDescDiagnosticoID_ActualizarDatosElegidos(ByVal datosElegidos As System.Data.DataRow) Handles cboDescDiagnosticoID.ActualizarDatosElegidos
        If datosElegidos Is Nothing Then

            txtCodDiagnosticoID.Text = String.Empty
            cboDescDiagnosticoID.Text = String.Empty

            Exit Sub
        End If

        With datosElegidos
            strClasifiDiagn = .Item("clasificacion").ToString
        End With
    End Sub


    'Private Sub rbSangradoSi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    If rbSangradoSi.Checked = True Then
    '        txtSangrado.ReadOnly = False
    '    Else
    '        txtSangrado.ReadOnly = True
    '        txtSangrado.ResetText()
    '    End If


    'End Sub

    'Private Sub rbSangradoNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If rbSangradoSi.Checked = True Then
    '        txtSangrado.ReadOnly = False
    '    Else
    '        txtSangrado.ReadOnly = True
    '        txtSangrado.ResetText()
    '    End If

    'End Sub


    Private Sub btnAgregarProc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarProc.Click


        If (Len(txtSangrado.Text) > 0 And txtSangrado.Enabled = False) _
                   Or (Len(txtTejidos.Text) > 0 And txtTejidos.Enabled = False) _
                   Or (Len(txtDescIntervencion.Text) > 0 And txtDescIntervencion.Enabled = False) _
                   Or (Len(txtHallazgos.Text) > 0 And txtHallazgos.Enabled = False) Then
            Exit Sub

        End If
        ''cpgaray OS7743212 validacion de fecha finavl menor a la inicial.
        If mskFinalCir.Text <> "  /  /" Then
            If Not IsDate(mskFinalCir.Text) Then
                MsgBox("Fecha invalida. Debe digitar una fecha valida.", MsgBoxStyle.Information)
                Exit Sub
                mskFinalCir.Select(0, mskFinalCir.TextLength)
            Else
                If Not CDate(mskFinalCir.Text) >= CDate(mskInicioCir.Text) Then
                    MsgBox("La fecha de finalización no puede ser menor a la de inicio.", MsgBoxStyle.Information)
                    Exit Sub
                    mskFinalCir.Select(0, mskFinalCir.TextLength)
                End If
            End If
        End If
        AgregarProcedimiento()

        If dtgPersonalMedico.DataSource Is Nothing Then
            BloquearControles(True)
        End If

        'GroupBox1.Enabled = True
        'GroupBox3.Enabled = True
        'GroupBox2.Enabled = True
        'GroupBox5.Enabled = True
        'GroupBox7.Enabled = True

    End Sub

    Private Sub AgregarProcedimiento()
        Dim drow As DataRow
        Dim dtproc As New DataTable
        Dim rows() As DataRow
        Dim intaccion As Integer
        Dim cont As Integer = 0
        Dim secuencia As Integer = 0
        Dim cod_Sispro As String = 0 'Resolucion 084 RJMAESTRE CU16 - 16-07-2021
        Dim objdao As New DAOGeneral
        Dim strIncompletos As String = ""

        Try

            If ValidarProcedimientosSeleccionados() = False And txtcodProce.Enabled = False Then
                MessageBox.Show("Seleccione un Registro de la Lista", "Descripción Quirúrgica", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If cmbAnestesia.Text = "" Or mskInicioCir.Text = "  /  /" Or txtHoraCir.Text = "" Or txtMinCir.Text = "" Or
            mskFinalCir.Text = "  /  /" Or txtHoraFinalCir.Text = "" Or txtMinFinCir.Text = "" _
            Or txtcodProce.Text = "" Or cmbProcedim.Text = "" Then


                If cmbAnestesia.Text = "" Then
                    strIncompletos = "Anestesia -"
                End If
                If mskInicioCir.Text = "  /  /" Then
                    strIncompletos = strIncompletos & " Fecha Inicio -"
                End If
                If txtHoraCir.Text = "" Then
                    strIncompletos = strIncompletos & " Hora Inicio -"
                End If
                If txtMinCir.Text = "" Then
                    strIncompletos = strIncompletos & " Minuto Inicio -"
                End If

                If mskFinalCir.Text = "  /  /" Then
                    strIncompletos = strIncompletos & " Fecha Final -"
                End If
                If txtHoraFinalCir.Text = "" Then
                    strIncompletos = strIncompletos & " Hora Final -"
                End If
                If txtMinFinCir.Text = "" Then
                    strIncompletos = strIncompletos & " Minuto Final -"
                End If

                MsgBox("Datos incompletos " & strIncompletos)
                BloquearControles(True)
                btnAgregarProc.Enabled = True
                Exit Sub
            End If

            'secuencia = objdao.EjecutarSQLStrValor("hcdescqx", objConexion, " max(secuencia)", " cod_sucur='" & objGeneral.Sucursal & "' and cod_pre_sgs='" & objGeneral.Prestador & "' and consecutivo='" & objDescrQx.Consecutivo & "'")


            'objDescrQx.Secuencia = secuencia + 1
            dtproc = dtgProcedim.DataSource

            'Joseph Moreno (IG) Fec:2019/11/21 Particularidades
            If Not Me.ctlPartProce.Validar() Then
                MsgBox("Seleccione al menos una particularidad para continuar.")
                Exit Sub
            End If

            If txtcodProce.Enabled = True Then
                If Not dtproc Is Nothing Then


                    If dtproc.Rows.Count > 0 Then
                        ''Inicio llarias Se agrega filtro por consecutivo de programación ya que solo estaba por procedimiento
                        '' CA 5062106  2019-10-28
                        rows = dtproc.Select("Procedimiento='" & txtcodProce.Text & "' and consecutivo='" & objDescrQx.Consecutivo & "' ")
                        '' Fin llarias

                        If rows.Length > 0 Then
                            MsgBox("Registro ya existe")
                            Exit Sub
                        End If
                    End If
                End If


                For i As Integer = 0 To dtproc.Rows.Count - 1

                    If dtproc.Rows(i).Item("Copiar").ToString = "S" Then
                        cont = cont + 1
                    End If

                Next

                If cont = 0 Then

                    drow = dtproc.NewRow
                    cod_Sispro = AdicionarProcedimMIPRES("") 'Resolucion 084 RJMAESTRE CU16 - 16-07-2021

                    drow.Item("consecutivo") = objDescrQx.Consecutivo 'dtproc.Rows(0).Item("consecutivo")
                    drow.Item("Procedimiento") = txtcodProce.Text
                    'Joseph Moreno (IG) Fec:2019/11/18 Particularidades
                    'drow.Item("Descripcion") = cmbProcedim.Text
                    drow.Item("Descripcion") = ctlPartProce.DescripcionTotal()
                    drow.Item("FechaInicio") = mskInicioCir.Text
                    drow.Item("HoraInicio") = Val(txtHoraCir.Text)
                    drow.Item("MinutoInicio") = Val(txtMinCir.Text)
                    drow.Item("FechaFinal") = mskFinalCir.Text
                    drow.Item("HoraFinal") = Val(txtHoraFinalCir.Text)
                    drow.Item("MinutoFinal") = Val(txtMinFinCir.Text)
                    drow.Item("TiempoQX") = lblTiempQx.Text
                    drow.Item("tip_anestesia") = cmbAnestesia.SelectedValue
                    drow.Item("Anestesia") = cmbAnestesia.Text
                    drow.Item("Cod. Auto SISPRO") = cod_Sispro 'Resolucion 084 RJMAESTRE CU16 - 16-07-2021
                    drow.Item("Bilateral") = IIf(chkBilateral.Checked = True, "S", "N")
                    'Joseph Moreno (IG) Fec:2019/11/18 Particularidades
                    If dtproc.Columns.Contains("genprocedes") Then
                        drow.Item("genprocedes") = ctlPartProce.DescripcionOriginal()
                    End If
                    If dtproc.Columns.Contains("particularidades") Then
                        drow.Item("particularidades") = ctlPartProce.XmlGrpXPar()
                    End If

                    intaccion = 2
                    If ActualizaProcedimientos(drow, intaccion) Then
                        dtproc.Rows.Add(drow)
                        dtgProcedim.DataSource = dtproc
                    End If

                Else

                    For i As Integer = 0 To dtproc.Rows.Count - 1
                        If dtproc.Rows(i).Item("Copiar").ToString = "S" Then


                            drow = dtproc.NewRow
                            drow.Item("consecutivo") = dtproc.Rows(i).Item("consecutivo")
                            drow.Item("Procedimiento") = dtproc.Rows(i).Item("Procedimiento")

                            'Resolucion 084 RJMAESTRE CU16 - 16-07-2021
                            If (Me.txtcodProce.Text.Equals(dtproc.Rows(i).Item("Procedimiento"))) Then
                                cod_Sispro = AdicionarProcedimMIPRES(drow.Item("Cod. Auto SISPRO").ToString)
                                drow.Item("Cod. Auto SISPRO") = cod_Sispro
                            End If
                            'End Resolucion 084 RJMAESTRE CU16 - 16-07-2021

                            'Joseph Moreno (IG) Fec:2019/11/18 Particularidades
                            'drow.Item("Descripcion") = cmbProcedim.Text
                            drow.Item("Descripcion") = ctlPartProce.DescripcionTotal()
                            drow.Item("FechaInicio") = mskInicioCir.Text
                            drow.Item("HoraInicio") = Val(txtHoraCir.Text)
                            drow.Item("MinutoInicio") = Val(txtMinCir.Text)
                            drow.Item("FechaFinal") = mskFinalCir.Text
                            drow.Item("HoraFinal") = Val(txtHoraFinalCir.Text)
                            drow.Item("MinutoFinal") = Val(txtMinFinCir.Text)
                            drow.Item("TiempoQX") = lblTiempQx.Text
                            drow.Item("tip_anestesia") = cmbAnestesia.SelectedValue
                            drow.Item("Anestesia") = cmbAnestesia.Text
                            drow.Item("Bilateral") = IIf(chkBilateral.Checked = True, "S", "N")
                            'Joseph Moreno (IG) Fec:2019/11/18 Particularidades
                            If dtproc.Columns.Contains("genprocedes") Then
                                drow.Item("genprocedes") = ctlPartProce.DescripcionOriginal()
                            End If
                            If dtproc.Columns.Contains("particularidades") Then
                                drow.Item("particularidades") = ctlPartProce.XmlGrpXPar()
                            End If

                            intaccion = 2
                            If ActualizaProcedimientos(drow, intaccion) Then
                                dtproc.Rows.Add(drow)
                                dtgProcedim.DataSource = dtproc
                            End If

                        End If
                    Next
                End If
            Else


                For i As Integer = 0 To dtproc.Rows.Count - 1

                    If dtproc.Rows(i).Item("Copiar").ToString = "S" Then
                        cont = cont + 1
                    End If

                Next

                If cont = 0 Then

                    rows = dtproc.Select("Procedimiento='" & txtcodProce.Text & "' and consecutivo='" & objDescrQx.Consecutivo & "'")
                    'Resolucion 084 RJMAESTRE CU16 - 16-07-2021
                    cod_Sispro = AdicionarProcedimMIPRES(rows(0).Item("Cod. Auto SISPRO").ToString)
                    rows(0).Item("Cod. Auto SISPRO") = cod_Sispro
                    'End Resolucion 084 RJMAESTRE CU16 - 16-07-2021

                    'Joseph Moreno (IG) Fec:2019/11/18 Particularidades
                    rows(0).Item("Descripcion") = ctlPartProce.DescripcionTotal()
                    rows(0).Item("FechaInicio") = mskInicioCir.Text
                    rows(0).Item("HoraInicio") = Val(txtHoraCir.Text)
                    rows(0).Item("MinutoInicio") = Val(txtMinCir.Text)
                    rows(0).Item("FechaFinal") = mskFinalCir.Text
                    rows(0).Item("HoraFinal") = Val(txtHoraFinalCir.Text)
                    rows(0).Item("MinutoFinal") = Val(txtMinFinCir.Text)
                    rows(0).Item("TiempoQX") = lblTiempQx.Text
                    rows(0).Item("tip_anestesia") = cmbAnestesia.SelectedValue
                    rows(0).Item("Anestesia") = cmbAnestesia.Text
                    rows(0).Item("Bilateral") = IIf(chkBilateral.Checked = True, "S", "N")
                    'Joseph Moreno (IG) Fec:2019/11/18 Particularidades
                    If dtproc.Columns.Contains("genprocedes") Then
                        rows(0).Item("genprocedes") = ctlPartProce.DescripcionOriginal()
                    End If
                    If dtproc.Columns.Contains("particularidades") Then
                        rows(0).Item("particularidades") = ctlPartProce.XmlGrpXPar()
                    End If
                    drow = rows(0)

                    intaccion = 3
                    If ActualizaProcedimientos(drow, intaccion) Then
                        dtgProcedim.DataSource = dtproc
                    End If

                Else

                    For i As Integer = 0 To dtproc.Rows.Count - 1
                        If dtproc.Rows(i).Item("Copiar").ToString = "S" Then
                            'rows = dtproc.Select("Procedimiento='" & dtproc.Rows(i).Item("Procedimiento").ToString & "' and consecutivo='" & objDescrQx.Consecutivo & "'")
                            'Se cambia la variable con la cual se estaba validando el consecutivo --llarias 2014-07-16
                            rows = dtproc.Select("Procedimiento='" & dtproc.Rows(i).Item("Procedimiento").ToString & "' and consecutivo='" & dtproc.Rows(i).Item("Consecutivo").ToString & "'")

                            'Resolucion 084 RJMAESTRE CU16 - 16-07-2021
                            If (Me.txtcodProce.Text.Equals(dtproc.Rows(i).Item("Procedimiento").ToString)) Then
                                cod_Sispro = AdicionarProcedimMIPRES(rows(0).Item("Cod. Auto SISPRO").ToString)
                                rows(0).Item("Cod. Auto SISPRO") = cod_Sispro
                            End If
                            'End Resolucion 084 RJMAESTRE CU16 - 16-07-2021

                            'Joseph Moreno (IG) Fec:2019/11/18 Particularidades
                            rows(0).Item("Descripcion") = ctlPartProce.DescripcionTotal()
                            rows(0).Item("FechaInicio") = mskInicioCir.Text
                            rows(0).Item("HoraInicio") = Val(txtHoraCir.Text)
                            rows(0).Item("MinutoInicio") = Val(txtMinCir.Text)
                            rows(0).Item("FechaFinal") = mskFinalCir.Text
                            rows(0).Item("HoraFinal") = Val(txtHoraFinalCir.Text)
                            rows(0).Item("MinutoFinal") = Val(txtMinFinCir.Text)
                            rows(0).Item("TiempoQX") = lblTiempQx.Text
                            rows(0).Item("tip_anestesia") = cmbAnestesia.SelectedValue
                            rows(0).Item("Anestesia") = cmbAnestesia.Text
                            rows(0).Item("Bilateral") = IIf(chkBilateral.Checked = True, "S", "N")
                            'Joseph Moreno (IG) Fec:2019/11/18 Particularidades
                            If dtproc.Columns.Contains("genprocedes") Then
                                rows(0).Item("genprocedes") = ctlPartProce.DescripcionOriginal()
                            End If
                            If dtproc.Columns.Contains("particularidades") Then
                                rows(0).Item("particularidades") = ctlPartProce.XmlGrpXPar()
                            End If
                            drow = rows(0)

                            intaccion = 3
                            If ActualizaProcedimientos(drow, intaccion) Then
                                dtgProcedim.DataSource = dtproc
                            End If
                        End If
                    Next
                End If


            End If

            If ValidarProcedimientosSeleccionados() = False And txtcodProce.Enabled = False Then
                MessageBox.Show("Seleccione un Registro de la Lista", "Descripción Quirúrgica", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            ''Agregar el cirujano para los procedimientos nuevos
            Try
                If txtcodProce.Enabled = True Then
                    objQxManejaDatos.GuardarEquipoMedico(objGeneral.Prestador, objGeneral.Sucursal, objDescrQx.Consecutivo, txtcodProce.Text, objGeneral.Login, "C", objGeneral.CodigoEspecialidad, "L", IIf(chkBilateral.Checked = True, "S", "N"), 0, "", objGeneral.Login, "")
                    CargarProcedimientosQuirurgicos()
                End If

            Catch ex As Exception

            End Try
            BloquearControles(False)
            btnAgregarProc.Enabled = False
            'LimpiarProcedimientos()




        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub


    '' <summary>
    '' Resolucion 084 RJMAESTRE CU16 - 16-07-2021 Adiciona el nuevo registro a la grilla validando los datos obligatorios
    '' y los registros duplicados. se actualiza el dataTable relacionado con 
    '' el dataGrid 
    '' </summary>
    '' <param name="sender"></param>
    '' <param name="e"></param>
    '' <remarks></remarks>
    Private Function AdicionarProcedimMIPRES(ByVal cod_Sispro As String) As String

        Dim dtProc As DataTable
        Dim daoGeneral As New DAOGeneral
        Dim strTipoEntidad As String
        Dim pide_SISPRO As String
        Dim pag_SISPRO As String
        Dim flag_pos As String = ""
        Dim flag_posCondicionado As Boolean
        Dim dtProInterconsulta As New DataTable

        datosLogin = Generales.Instancia()
        objConexion = Conexion.Instancia()

        pide_SISPRO = daoGeneral.EjecutarSQLStrValor("gensucur (nolock)", objConexion, " pide_SISPRO", " cod_sucur='" & datosLogin.Sucursal & "'")
        pag_SISPRO = daoGeneral.EjecutarSQLStrValor("pargener (nolock)", objConexion, " pagsispro", " cod_pre_sgs='" & datosLogin.Prestador & "'")

        strTipoEntidad = objPaciente.TipoEntidad.ToString()

        dtProc = daoGeneral.EjecutarSQLConParametros("VW_GENPROCE_DES (NOLOCK)", objConexion, "flag_pos, codSISPRO, desSISPRO", "procedim='" & Me.txtcodProce.Text & "'" & String.Format(" AND CONVERT(DATE, '{0}') BETWEEN fec_ini_proce AND fec_fin_proce ", Format(DateTime.Now, "yyyy-MM-dd")))

        '' validacion SISPRO
        If pide_SISPRO = "S" And strTipoEntidad = "EPS" Then
            flag_pos = IIf(IsDBNull(dtProc.Rows(0).Item("flag_pos").ToString), "S", dtProc.Rows(0).Item("flag_pos").ToString)
            If flag_pos = "N" Then
                flag_posCondicionado = BLOrdenes.existePosCondicionado(objConexion, datosLogin.Prestador, datosLogin.Sucursal, objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision, "P", Me.txtcodProce.Text)
                If flag_posCondicionado = True Then
                    MsgBox("El elemento prescrito es POS Condicionado por Diagnóstico", MsgBoxStyle.Information, "Procedimientos")
                Else
                    System.Diagnostics.Process.Start(pag_SISPRO)
                    frm_SISPRO.Mostrar(cod_Sispro)
                    cod_Sispro = frm_SISPRO.Cod_SISPRO1
                End If
            End If

        End If

        Return cod_Sispro
    End Function

    Private Sub LimpiarProcedimientos()
        cmbAnestesia.Text = String.Empty
        lblTiempQx.Text = String.Empty
        mskInicioCir.Text = String.Empty
        txtHoraCir.Text = String.Empty
        txtMinCir.Text = String.Empty
        mskFinalCir.Text = String.Empty
        txtHoraFinalCir.Text = String.Empty
        txtMinFinCir.Text = String.Empty
        txtcodProce.Text = String.Empty
        cmbProcedim.Text = String.Empty
        txtcodProce.Enabled = True
        cmbProcedim.Enabled = True
        'Joseph Moreno (IG) Fec:2019/11/19 Particularidades
        Me.ctlPartProce.Activar(True)
        Me.ctlPartProce.Limpiar(True)
    End Sub
    Private Function ActualizaProcedimientos(ByVal drow As DataRow, ByVal intaccion As Integer) As Boolean
        Dim strMensaje As String = ""
        Dim dtproc As DataTable = dtgProcedim.DataSource
        Dim cont As Integer = 0

        'Joseph Moreno (IG) Fec:2019/11/18 Particularidades
        Dim strParticularidades As String = ""
        Try
            'Joseph Moreno (IG) Fec:2019/11/18 Particularidades
            If drow.Table.Columns.Contains("particularidades") Then
                strParticularidades = drow.Item("particularidades").ToString
            Else
                strParticularidades = ""
            End If

            'martovar 2014-10-10 version 2.9.0 descripcion quirurgica
            'Joseph Moreno (IG) Fec:2019/11/18 Particularidades
            'Resolucion 084 RJMAESTRE CU16 - 16-07-2021 add campo  drow.Item("Cod. Auto SISPRO").ToString
            strMensaje = objQxManejaDatos.GuardarProcedimiento(objGeneral.Prestador, objGeneral.Sucursal, drow.Item("consecutivo").ToString, drow.Item("Procedimiento").ToString,
                        drow.Item("FechaInicio").ToString, drow.Item("HoraInicio").ToString, drow.Item("MinutoInicio").ToString, drow.Item("FechaFinal").ToString, drow.Item("TiempoQX").ToString,
                        0, "", "", "", "", "", drow.Item("HoraFinal").ToString, drow.Item("MinutoFinal").ToString, drow.Item("tip_anestesia").ToString, objPaciente.Entidad, cmbTipoQx.SelectedValue, IIf(chkBilateral.Checked = True, "S", "N"), objGeneral.Login, intaccion, objDescrQx.Secuencia, objGeneral.CodigoEspecialidad, objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                        strParticularidades, drow.Item("Cod. Auto SISPRO").ToString)

            If Len(strMensaje) = 0 Then
                Return True
            Else
                MsgBox(strMensaje)
                objQxManejaDatos.GrabarLogErrores(strMensaje, objGeneral.Sucursal, objGeneral.Login, objDescrQx.Consecutivo, objDescrQx.Procedimiento)
                Return False
            End If


        Catch ex As Exception
            MsgBox("Error al grabar los datos " & ex.Message)
            objQxManejaDatos.GrabarLogErrores(ex.Message, objGeneral.Sucursal, drow.Item("Procedimiento").ToString, drow.Item("consecutivo").ToString, objGeneral.Login)
            Return False
        End Try

    End Function
    Private Function ActualizaProcedimientos(ByVal drow As DataGridViewRow, ByVal intaccion As Integer) As Boolean
        Dim strMensaje As String = ""

        'Joseph Moreno (IG) Fec:2019/11/18 Particularidades
        Dim strParticularidades As String = ""

        Try

            objDescrQx.Consecutivo = drow.Cells("consecutivo").Value.ToString
            objDescrQx.Procedimiento = drow.Cells("Procedimiento").Value.ToString
            objDescrQx.Descripcion = drow.Cells("Descripcion").Value
            'Joseph Moreno (IG) Fec:2019/11/18 Particularidades
            If drow.DataGridView.Columns.Contains("particularidades") Then
                strParticularidades = drow.Cells("particularidades").Value.ToString
            Else
                strParticularidades = ""
            End If

            objDescrQx.Particularidades = strParticularidades
            'martovar 2014-10-10 version 2.9.0 descripcion quirurgica
            'Joseph Moreno (IG) Fec:2019/11/18 Particularidades
            strMensaje = objQxManejaDatos.GuardarProcedimiento(objGeneral.Prestador, objGeneral.Sucursal, drow.Cells("consecutivo").Value.ToString,
            drow.Cells("Procedimiento").Value.ToString, "2000/01/01", 0,
            0, "2000/01/01", drow.Cells("TiempoQX").Value.ToString,
            0, "", "", "", "", "", 0,
            0, drow.Cells("tip_anestesia").Value.ToString, objPaciente.Entidad, cmbTipoQx.SelectedValue, IIf(chkBilateral.Checked = True, "S", "N"),
            objGeneral.Login, intaccion, objDescrQx.Secuencia, objGeneral.CodigoEspecialidad, objPaciente.TipoAdmision, objPaciente.AnoAdmision,
            objPaciente.NumeroAdmision, strParticularidades)

            'CargarProcedimientosQuirurgicos()

            If Len(strMensaje) = 0 Then
                LimpiarProcedimientos()
                LimpiardatosDescQX()
                txtcodProce.Enabled = False
                cmbProcedim.Enabled = False
                'Joseph Moreno (IG) Fec:2019/11/19 Particularidades
                Me.ctlPartProce.Activar(False)
                btnAgregarProc.Enabled = False
                Return True
            Else
                MsgBox(strMensaje)
                objQxManejaDatos.GrabarLogErrores(strMensaje, objGeneral.Sucursal, objGeneral.Login, objDescrQx.Consecutivo, objDescrQx.Procedimiento)
                Return False

            End If

        Catch ex As Exception
            MsgBox("Error al grabar los datos " & ex.Message)
            objQxManejaDatos.GrabarLogErrores(ex.Message, objGeneral.Sucursal, objGeneral.Login, objDescrQx.Consecutivo, objDescrQx.Procedimiento)
            'CargarProcedimientosQuirurgicos()
            Return False
        End Try
    End Function
    Private Function ActualizarEstadoEquipoMedico(ByVal drow As DataGridViewRow) As Boolean
        Dim strMensaje As String = ""
        Dim dt As DataTable = dtgPersonalMedico.DataSource
        Try

            ' objDescrQx.Consecutivo = drow.Cells("consecutivo").Value.ToString
            ' objDescrQx.Procedimiento = drow.Cells("Procedimiento").Value.ToString

            strMensaje = objQxManejaDatos.ActualizaEquipoMedico(objGeneral.Prestador, objGeneral.Sucursal, drow.Cells("consecutivo").Value.ToString,
            drow.Cells("Procedim").Value.ToString, drow.Cells("CodMedico").Value.ToString,
            drow.Cells("Tip_empleado").Value.ToString, objGeneral.Login)

            'CargarProcedimientosQuirurgicos()

            If Len(strMensaje) = 0 Then
                LimpiarEquipoMedico()
                Return True
            Else
                MsgBox(strMensaje)
                objQxManejaDatos.GrabarLogErrores(strMensaje, objGeneral.Sucursal, objGeneral.Login, objDescrQx.Consecutivo, objDescrQx.Procedimiento)
                Return False

            End If

        Catch ex As Exception
            MsgBox("Error al grabar los datos " & ex.Message)
            objQxManejaDatos.GrabarLogErrores(ex.Message, objGeneral.Sucursal, objGeneral.Login, objDescrQx.Consecutivo, objDescrQx.Procedimiento)
            'CargarProcedimientosQuirurgicos()
            Return False
        End Try
    End Function
    Private Function ActualizaProfilaxis(ByVal drow As DataRow, ByVal intaccion As Integer) As Boolean
        Dim strMensaje As String = ""
        Dim dtproc As DataTable = dtgProcedim.DataSource
        Dim cont As Integer = 0

        Try

            For i As Integer = 0 To dtproc.Rows.Count - 1

                If dtproc.Rows(i).Item("Copiar").ToString = "S" Then
                    cont = cont + 1
                End If

            Next

            If cont = 0 Then

                strMensaje = objQxManejaDatos.GrabarProfilaxis(objGeneral.Prestador, objGeneral.Sucursal, objDescrQx.Procedimiento, objDescrQx.Consecutivo,
                drow.Item("codigo").ToString, intaccion, objGeneral.Login, "")

                If Len(strMensaje) = 0 Then
                    Return True
                Else
                    MsgBox(strMensaje)
                    objQxManejaDatos.GrabarLogErrores(strMensaje, objGeneral.Sucursal, objGeneral.Login, objDescrQx.Consecutivo, objDescrQx.Procedimiento)
                    Return False
                End If

            Else


                For i As Integer = 0 To dtproc.Rows.Count - 1
                    If dtproc.Rows(i).Item("Copiar").ToString = "S" Then

                        strMensaje = objQxManejaDatos.GrabarProfilaxis(objGeneral.Prestador, objGeneral.Sucursal, dtproc.Rows(i).Item("Procedimiento").ToString, dtproc.Rows(i).Item("Consecutivo").ToString,
                        drow.Item("codigo").ToString, intaccion, objGeneral.Login, "")

                        If Len(strMensaje) > 0 Then
                            MsgBox(strMensaje)
                            objQxManejaDatos.GrabarLogErrores(strMensaje, objGeneral.Sucursal, objGeneral.Login, dtproc.Rows(i).Item("Consecutivo").ToString, dtproc.Rows(i).Item("Procedimento").ToString)
                        End If

                    End If
                Next


                If Len(strMensaje) = 0 Then
                    Return True
                Else
                    Return False
                End If

            End If



        Catch ex As Exception
            MsgBox("Error al grabar los datos " & ex.Message)
            objQxManejaDatos.GrabarLogErrores(ex.Message, objGeneral.Sucursal, objGeneral.Login, objDescrQx.Consecutivo, objDescrQx.Procedimiento)
            Return False
        End Try

    End Function
    Private Function ActualizaEquipoMedico(ByVal drow As DataRow) As Boolean
        Dim strMensaje As String = ""
        Dim dtproc As DataTable = dtgProcedim.DataSource
        Dim cont As Integer = 0

        Try


            For i As Integer = 0 To dtproc.Rows.Count - 1

                If dtproc.Rows(i).Item("Copiar").ToString = "S" Then
                    cont = cont + 1
                End If

            Next


            If cont = 0 Then

                strMensaje = objQxManejaDatos.GuardarEquipoMedico(objGeneral.Prestador, objGeneral.Sucursal, drow.Item("consecutivo").ToString, drow.Item("procedim").ToString,
                drow.Item("CodMedico").ToString, drow.Item("tip_empleado").ToString, drow.Item("espc").ToString, drow.Item("estado").ToString, drow.Item("bilateral").ToString,
                drow.Item("nro_autoriza").ToString, drow.Item("obs").ToString, objGeneral.Login, IIf(drow.Item("CodMedico").ToString = "INVITADO", drow.Item("Medico").ToString, ""))

                If Len(strMensaje) = 0 Then
                    Return True
                Else
                    MsgBox(strMensaje)
                    objQxManejaDatos.GrabarLogErrores(strMensaje, objGeneral.Sucursal, objGeneral.Login, objDescrQx.Consecutivo, objDescrQx.Procedimiento)
                    Return False
                End If

            Else

                For i As Integer = 0 To dtproc.Rows.Count - 1
                    If dtproc.Rows(i).Item("Copiar").ToString = "S" Then

                        strMensaje = objQxManejaDatos.GuardarEquipoMedico(objGeneral.Prestador, objGeneral.Sucursal, dtproc.Rows(i).Item("Consecutivo").ToString, dtproc.Rows(i).Item("Procedimiento").ToString,
                        drow.Item("CodMedico").ToString, drow.Item("tip_empleado").ToString, drow.Item("espc").ToString, drow.Item("estado").ToString, drow.Item("bilateral").ToString,
                        drow.Item("nro_autoriza").ToString, drow.Item("obs").ToString, objGeneral.Login, IIf(drow.Item("CodMedico").ToString = "INVITADO", drow.Item("Medico").ToString, ""))

                        If Len(strMensaje) > 0 Then
                            MsgBox(strMensaje)
                            objQxManejaDatos.GrabarLogErrores(strMensaje, objGeneral.Sucursal, objGeneral.Login, dtproc.Rows(i).Item("Consecutivo").ToString, dtproc.Rows(i).Item("Procedimiento").ToString)
                        End If

                    End If
                Next
                If Len(strMensaje) = 0 Then
                    Return True
                Else
                    Return False
                End If
            End If

        Catch ex As Exception
            MsgBox("Error al guardar los datos " & ex.Message)
            objQxManejaDatos.GrabarLogErrores(ex.Message, objGeneral.Sucursal, objGeneral.Login, objDescrQx.Consecutivo, objDescrQx.Procedimiento)
            Return False
        End Try

    End Function
    Private Function ActualizaDiagnosticos(ByVal drow As DataRow) As Boolean
        Dim strMensaje As String = ""
        Dim dtproc As DataTable = dtgProcedim.DataSource
        Dim cont As Integer = 0

        Try


            For i As Integer = 0 To dtproc.Rows.Count - 1

                If dtproc.Rows(i).Item("Copiar").ToString = "S" Then
                    cont = cont + 1
                End If

            Next

            If cont = 0 Then
                strMensaje = objQxManejaDatos.GuardarDiagnosticos(objGeneral.Prestador, objGeneral.Sucursal, drow.Item("consecutivo").ToString, drow.Item("procedim").ToString,
                            drow.Item("diagnost").ToString, drow.Item("clasificacion").ToString, drow.Item("clase").ToString, drow.Item("obs").ToString,
                objGeneral.Login)

                If Len(strMensaje) = 0 Then
                    Return True
                Else
                    MsgBox(strMensaje)
                    objQxManejaDatos.GrabarLogErrores(strMensaje, objGeneral.Sucursal, objGeneral.Login, objDescrQx.Consecutivo, objDescrQx.Procedimiento)
                    Return False
                End If
            Else

                For i As Integer = 0 To dtproc.Rows.Count - 1

                    If dtproc.Rows(i).Item("Copiar").ToString = "S" Then

                        strMensaje = objQxManejaDatos.GuardarDiagnosticos(objGeneral.Prestador, objGeneral.Sucursal, dtproc.Rows(i).Item("Consecutivo").ToString, dtproc.Rows(i).Item("Procedimiento").ToString,
                    drow.Item("diagnost").ToString, drow.Item("clasificacion").ToString, drow.Item("clase").ToString, drow.Item("obs").ToString,
                        objGeneral.Login)

                        If Len(strMensaje) > 0 Then
                            MsgBox(strMensaje)
                            objQxManejaDatos.GrabarLogErrores(strMensaje, objGeneral.Sucursal, objGeneral.Login, dtproc.Rows(i).Item("Consecutivo").ToString, dtproc.Rows(i).Item("Procedimiento").ToString)
                        End If

                    End If

                Next
                If Len(strMensaje) = 0 Then
                    Return True
                Else
                    Return False
                End If


            End If


        Catch ex As Exception
            MsgBox("Error al actualizar los datos " & ex.Message)
            objQxManejaDatos.GrabarLogErrores(ex.Message, objGeneral.Sucursal, objGeneral.Login, objDescrQx.Consecutivo, objDescrQx.Procedimiento)
            Return False
        End Try
    End Function
    Private Function EliminaDiagnosticos(ByVal drow As DataGridViewRow) As Boolean
        Dim strMensaje As String = ""

        Try

            strMensaje = objQxManejaDatos.ActualizaDiagnosticos(objGeneral.Prestador, objGeneral.Sucursal, drow.Cells("consecutivo").Value, drow.Cells("procedim").Value,
            drow.Cells("diagnost").Value, drow.Cells("clase").Value, objGeneral.Login)

            If Len(strMensaje) = 0 Then
                Return True
            Else
                MsgBox(strMensaje)
                objQxManejaDatos.GrabarLogErrores(strMensaje, objGeneral.Sucursal, objGeneral.Login, objDescrQx.Consecutivo, objDescrQx.Procedimiento)
                Return False
            End If
        Catch ex As Exception
            MsgBox("Error al actualizar los datos " & ex.Message)
            objQxManejaDatos.GrabarLogErrores(ex.Message, objGeneral.Sucursal, objGeneral.Login, objDescrQx.Consecutivo, objDescrQx.Procedimiento)
            Return False
        End Try
    End Function
    Private Function GuardarDescripcionQx() As Boolean
        Dim strMensaje As String = ""
        Dim dtProcedim As DataTable = dtgProcedim.DataSource
        Dim cont As Integer = 0
        Dim recuento As String = ""
        Dim secuencia As Integer = 0
        Dim objdao As New DAOGeneral

        'Joseph Moreno (IG) Fec:2019/11/18 Particularidades
        Dim booTienePart As Boolean = dtProcedim.Columns.Contains("particularidades")
        Dim strParticularidades As String = ""

        Try

            If rbCompleto.Checked = True Then
                recuento = "C"
            ElseIf rbIncompleto.Checked = True Then
                recuento = "I"
            Else
                recuento = "N"
            End If

            For i As Integer = 0 To dtProcedim.Rows.Count - 1

                If dtProcedim.Rows(i).Item("Copiar").ToString = "S" Then
                    cont = cont + 1
                End If

            Next

            If cont > 1 Then


                secuencia = objdao.EjecutarSQLStrValor("hcdescqx", objConexion, " max(secuencia)", " cod_sucur='" & objGeneral.Sucursal & "' and cod_pre_sgs='" & objGeneral.Prestador & "'")


                objDescrQx.Secuencia = secuencia + 1

                For i As Integer = 0 To dtProcedim.Rows.Count - 1

                    If dtProcedim.Rows(i).Item("Copiar").ToString = "S" Then
                        'Joseph Moreno (IG) Fec:2019/11/18 Particularidades
                        If booTienePart Then
                            strParticularidades = dtProcedim.Rows(i).Item("particularidades").ToString
                        End If
                        'martovar 2014-10-10 version 2.9.0 descripcion quirurgica
                        'Joseph Moreno (IG) Fec:2019/11/18 Particularidades
                        strMensaje = objQxManejaDatos.GuardarProcedimiento(objGeneral.Prestador, objGeneral.Sucursal, dtProcedim.Rows(i).Item("Consecutivo").ToString, dtProcedim.Rows(i).Item("Procedimiento").ToString,
                        "2011/01/01", 0, 0, "2011/01/01", 0,
                        IIf(Len(txtSangrado.Text) > 0, Val(txtSangrado.Text), 0), txtTejidos.Text, txtDescIntervencion.Text, recuento,
                        IIf(rbSiCompl.Checked = True, txtComplicaciones.Text, "NO"), txtHallazgos.Text, 0, 0, "", objPaciente.Entidad, cmbTipoQx.SelectedValue, IIf(chkBilateral.Checked = True, "S", "N"), objGeneral.Login, 0, objDescrQx.Secuencia, objGeneral.CodigoEspecialidad, objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                        strParticularidades)

                    End If

                Next
            Else

                secuencia = objdao.EjecutarSQLStrValor("hcdescqx", objConexion, " max(secuencia)", " cod_sucur='" & objGeneral.Sucursal & "' and cod_pre_sgs='" & objGeneral.Prestador & "'")


                objDescrQx.Secuencia = secuencia + 1
                'Joseph Moreno (IG) Fec:2019/11/18 Particularidades
                If booTienePart Then
                    strParticularidades = objDescrQx.Particularidades
                End If
                'martovar 2014-10-10 version 2.9.0 descripcion quirurgica
                'Joseph Moreno (IG) Fec:2019/11/18 Particularidades
                strMensaje = objQxManejaDatos.GuardarProcedimiento(objGeneral.Prestador, objGeneral.Sucursal, objDescrQx.Consecutivo, objDescrQx.Procedimiento,
                "2011/01/01", 0, 0, "2011/01/01", 0,
                IIf(Len(txtSangrado.Text) > 0, Val(txtSangrado.Text), 0), txtTejidos.Text, txtDescIntervencion.Text, recuento,
                IIf(rbSiCompl.Checked = True, txtComplicaciones.Text, "NO"), txtHallazgos.Text, 0, 0, "", objPaciente.Entidad, cmbTipoQx.SelectedValue, IIf(chkBilateral.Checked = True, "S", "N"), objGeneral.Login, 0, objDescrQx.Secuencia, objGeneral.CodigoEspecialidad, objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                strParticularidades)

            End If
            If Len(strMensaje) = 0 Then
                Return True
            Else
                MsgBox(strMensaje)
                objQxManejaDatos.GrabarLogErrores(strMensaje, objGeneral.Sucursal, objGeneral.Login, objDescrQx.Consecutivo, objDescrQx.Procedimiento)
                Return False
            End If

        Catch ex As Exception
            MsgBox("Error al guardar la descripción quirúrgica " & ex.Message)
            objQxManejaDatos.GrabarLogErrores(ex.Message, objGeneral.Sucursal, objGeneral.Login, objDescrQx.Consecutivo, objDescrQx.Procedimiento)
            Return False
        End Try


    End Function

    Private Sub dtgProcedim_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgProcedim.CellEndEdit

    End Sub


    Private Sub dtgProcedim_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dtgProcedim.UserDeletedRow
        dtgProcedim.DataSource.AcceptChanges()
    End Sub


    Private Sub dtgProcedim_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dtgProcedim.UserDeletingRow

        If MessageBox.Show("Esta Seguro de Borrar este Registro?", "Descripcion Quirurgica", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If Len(txtDescIntervencion.Text) > 0 And Len(txtComplicaciones.Text) > 0 And Len(txtHallazgos.Text) > 0 Then
                MsgBox("El procedimiento seleccionado no se puede eliminar")
                e.Cancel = True
                Exit Sub
            End If
            ActualizaProcedimientos(e.Row, 1)

        Else
            e.Cancel = True
        End If

    End Sub

    Private Sub LimpiardatosDescQX()
        chkBilateral.Checked = False
        cmbAnestesia.Text = String.Empty
        lblTiempQx.Text = String.Empty
        txtHoraCir.Text = String.Empty
        txtMinCir.Text = String.Empty
        txtHoraFinalCir.Text = String.Empty
        txtMinFinCir.Text = String.Empty
        txtcodProce.Text = String.Empty
        cmbProcedim.Text = String.Empty
        txtCodTipPers.Text = String.Empty
        txtTipPers.Text = String.Empty
        txtCodProfes.Text = String.Empty
        txtDescProfes.Text = String.Empty
        txtCirujanoInvitado.Text = String.Empty
        cmbEspecialidad.Text = String.Empty
        txtobs.Text = String.Empty
        txtCodProfilaxis.Text = String.Empty
        cmbClaseDiagn.Text = String.Empty
        'txtCodTipoDiagnosticoID.Text = String.Empty
        'txtDescTipoDiagnosticoID.Text = String.Empty
        txtCodDiagnosticoID.Text = String.Empty
        cboDescDiagnosticoID.Text = String.Empty
        txtobsdiagn.Text = String.Empty
        txtTejidos.Text = String.Empty
        cmbTipoQx.Text = String.Empty
        txtSangrado.Text = String.Empty
        txtDescIntervencion.Text = String.Empty
        txtComplicaciones.Text = String.Empty
        txtHallazgos.Text = String.Empty
        mskInicioCir.Text = String.Empty
        mskFinalCir.Text = String.Empty
        rbProfilaxisSi.Checked = False
        rbProfilaxisNo.Checked = False
        ''rbSangradoSi.Checked = False
        ''rbSangradoNo.Checked = False
        rbCompleto.Checked = False
        rbIncompleto.Checked = False
        rbSiCompl.Checked = False
        rbNoCompl.Checked = False
        dtgPersonalMedico.DataSource = Nothing
        dtgProfilaxis.DataSource = Nothing
        dtgPreoperatorio.DataSource = Nothing
        dtgPostperatorio.DataSource = Nothing
        GroupBox1.Enabled = True
        GroupBox3.Enabled = True
        GroupBox2.Enabled = True
        GroupBox5.Enabled = True
        GroupBox7.Enabled = True
        GroupBox6.Enabled = True
        Me.RadioButtonNo.Checked = True
        'Joseph Moreno (IG) Fec:2019/11/18 Particularidades
        Me.ctlPartProce.Limpiar(True)
    End Sub


    Private Sub rbSiCompl_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSiCompl.CheckedChanged

        If rbSiCompl.Checked = True Then
            txtComplicaciones.ReadOnly = False
        Else
            txtComplicaciones.ReadOnly = True
            txtComplicaciones.ResetText()
        End If
    End Sub

    Private Sub rbNoCompl_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbNoCompl.CheckedChanged
        If rbNoCompl.Checked = True Then
            txtComplicaciones.ReadOnly = True
            txtComplicaciones.ResetText()
        Else
            txtComplicaciones.ReadOnly = False
        End If
    End Sub

    Private Sub ctlDescripcionQuirurgica_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If sender.Visible Then
            LimpiardatosDescQX()
            CargarProcedimientosQuirurgicos()
            BloquearControles(True)
            txtcodProce.Enabled = False
            cmbProcedim.Enabled = False
            'Joseph Moreno (IG) Fec:2019/11/19 Particularidades
            Me.ctlPartProce.Activar(False)
            'GroupBox1.Enabled = False
            'GroupBox3.Enabled = False
            'GroupBox2.Enabled = False
            'GroupBox5.Enabled = False
            'GroupBox7.Enabled = False
        End If
    End Sub
    Private Sub CargarArhivo()
        Dim sLine As String = ""
        Dim arrText As New ArrayList()
        Dim myStream As Stream = Nothing
        Dim openFile As New OpenFileDialog
        Dim objreader As StreamReader
        Dim strRuta As String = ""

        openFile.InitialDirectory = "c:\"
        openFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        openFile.FilterIndex = 2
        openFile.RestoreDirectory = True

        If openFile.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                myStream = openFile.OpenFile()

                If (myStream IsNot Nothing) Then
                    strRuta = openFile.FileName
                Else
                    MsgBox("Error con el archivo seleccionado")
                End If


                objreader = New StreamReader(strRuta)

                Do
                    sLine = objreader.ReadLine()
                    If Not sLine Is Nothing Then
                        arrText.Add(sLine)
                    End If
                Loop Until sLine Is Nothing
                objreader.Close()

                For Each sLine In arrText
                    If (Len(txtDescIntervencion.Text) + Len(sLine)) < 4000 Then
                        txtDescIntervencion.Text += sLine
                    End If

                Next
                'Console.ReadLine()

            Catch Ex As Exception
                MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
            Finally
                ' Check this again, since we need to make sure we didn't throw an exception on open.
                If (myStream IsNot Nothing) Then
                    myStream.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        CargarArhivo()
    End Sub

    Private Sub lnkNuevo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkNuevo.LinkClicked
        LimpiarEquipoMedico()
        NuevoProcedimiento()
        dtgPersonalMedico.DataSource = Nothing
        dtgPostperatorio.DataSource = Nothing
        dtgPreoperatorio.DataSource = Nothing
        dtgProfilaxis.DataSource = Nothing
        ''rbSangradoSi.Checked = False
        ''rbSangradoNo.Checked = False
        rbCompleto.Checked = False
        rbIncompleto.Checked = False
        txtTejidos.ResetText()
        txtHallazgos.ResetText()
        txtComplicaciones.ResetText()
        txtDescIntervencion.ResetText()
        chkBilateral.Enabled = True
        txtcodProce.Enabled = True
        cmbProcedim.Enabled = True
        'Joseph Moreno (IG) Fec:2019/11/19 Particularidades
        Me.ctlPartProce.Activar(True)
        BloquearControles(False)
        btnAgregarProc.Enabled = True
        If mskInicioCir.Text = "  /  /" Then
            mskInicioCir.Text = Format(FuncionesGenerales.FechaServidor(), "dd/MM/yyyy")
            mskFinalCir.Text = Format(FuncionesGenerales.FechaServidor(), "dd/MM/yyyy")
        End If
    End Sub

    Private Sub btnGuardarDescripcionQx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarDescripcionQx.Click

        Dim dtProcedim As DataTable = dtgProcedim.DataSource


        If objDescrQx.Consecutivo = "" Then
            MsgBox("No existen datos por almacenar")
            Exit Sub
        End If

        If ValidarEquipoMedico() = False Then
            Exit Sub
        End If


        If Not dtgProcedim.CurrentRow Is Nothing Then

            For i As Integer = 0 To dtProcedim.Rows.Count - 1

                If dtProcedim.Rows(i).Item("Copiar").ToString = "S" Then

                    If IsDBNull(dtProcedim.Rows(i).Item("FechaInicio").ToString) Or
                    IsDBNull(dtProcedim.Rows(i).Item("HoraInicio").ToString) Or
                    IsDBNull(dtProcedim.Rows(i).Item("MinutoInicio").ToString) Or
                    IsDBNull(dtProcedim.Rows(i).Item("FechaFinal").ToString) Or
                    IsDBNull(dtProcedim.Rows(i).Item("HoraFinal").ToString) Or
                    IsDBNull(dtProcedim.Rows(i).Item("MinutoFinal").ToString) Then


                        MsgBox("Ingresar los datos de Fecha inicial/final Hora inicial/final o minuto inicial/final ", MsgBoxStyle.Information)
                        mskInicioCir.Focus()
                        If btnAgregarProc.Enabled = False Then
                            btnAgregarProc.Enabled = True
                        End If

                        Exit Sub
                    End If

                End If

            Next

            If IsDBNull(dtgProcedim.CurrentRow.Cells("FechaInicio").Value) Or
            IsDBNull(dtgProcedim.CurrentRow.Cells("HoraInicio").Value) Or
            IsDBNull(dtgProcedim.CurrentRow.Cells("MinutoInicio").Value) Or
            IsDBNull(dtgProcedim.CurrentRow.Cells("FechaFinal").Value) Or
            IsDBNull(dtgProcedim.CurrentRow.Cells("HoraFinal").Value) Or
        IsDBNull(dtgProcedim.CurrentRow.Cells("MinutoFinal").Value) Then


                MsgBox("Ingresar los datos de Fecha inicial/final Hora inicial/final o minuto inicial/final ", MsgBoxStyle.Information)
                mskInicioCir.Focus()
                Exit Sub
            End If


        End If

        If txtDescIntervencion.Enabled = True Then
            If MsgBox("Una vez almacenados los datos no podrán ser modificados. Desea Continuar", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                If GuardarDescripcionQx() = True Then
                    BloquearControles(True)
                    btnAgregarProc.Enabled = False
                    CargarProcedimientosQuirurgicos()

                End If
                ImprimirReporteQx()

            End If
        Else
            ImprimirReporteQx()
        End If


    End Sub
    Private Function ValidarEquipoMedico() As Boolean
        Dim dt As DataTable
        Dim dtrow() As DataRow
        Dim strMensaje As String = ""

        dt = dtgPersonalMedico.DataSource

        If dtgPersonalMedico.CurrentRow Is Nothing Then
            MsgBox("Personal Médico incompleto")
            Return False
        End If

        If dt.Rows.Count = 0 Then
            Return False
        Else

            dtrow = dt.Select("tip_empleado in ('N','C','I')")
            ' ''Ayudante
            'dtrow = dt.Select("tip_empleado ='A'")            
            'If dtrow.Length = 0 Then
            '    strMensaje += "Ayudante, "
            'End If

            ''Anestesiologo
            dtrow = dt.Select("tip_empleado ='N'")
            If dtrow.Length = 0 Then
                strMensaje += "Anestesiólogo, "
            End If

            ''Cirujano
            dtrow = dt.Select("tip_empleado ='C'")
            If dtrow.Length = 0 Then
                strMensaje += "Cirujano, "
            End If

            ''Instrumentador
            dtrow = dt.Select("tip_empleado ='I'")
            If dtrow.Length = 0 Then
                strMensaje += "Instrumentador "
            End If

        End If

        If Len(strMensaje) > 0 Then
            MsgBox("Personal Médico incompleto: " & strMensaje)
            Return False
        Else
            Return True
        End If

    End Function
    Private Sub ImprimirReporteQx()
        Dim frmRepDescr As New frmRepDescripcionQX

        Dim objDatosGenerales As objGenerales.Generales

        objDatosGenerales = objGenerales.Generales.Instancia

        If objDatosGenerales.Pais = "482" Then ''Peru 
            frmRepDescr.imprimirDescripcionQuirurgica(objConexion, objGeneral.Prestador, objGeneral.Sucursal,
                                                      "", objDescrQx.Consecutivo, objDescrQx.Secuencia,
                                                      objPaciente.TipoAdmision, objPaciente.AnoAdmision,
                                                      objPaciente.NumeroAdmision, objPaciente.TipoDocumento,
                                                      objPaciente.NumeroDocumento)
            frmRepDescr.Show()
        Else
            '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
            'Juan Carlos Jaramillo Lozano - IG
            RptHC_Enf_Med.Show()
            RptHC_Enf_Med.ImprimirHistoriaClinica_imprimirQuirurjico(objConexion, "62", objGeneral.Prestador,
                                                                    objGeneral.Sucursal, "", objDescrQx.Consecutivo,
                                                                    objDescrQx.Secuencia, objPaciente.TipoAdmision,
                                                                    objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                    objPaciente.TipoDocumento, objPaciente.NumeroDocumento,
                                                                     objPaciente.CodHistoria)
            '2019-03-11 Fin
        End If

        'objDescrQx.Procedimiento
    End Sub


    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        LimpiardatosDescQX()
        LimpiarProcedimientos()
        objDescrQx.Consecutivo = String.Empty
        objDescrQx.Procedimiento = String.Empty
        'Joseph Moreno (IG) Fec:2019/11/18 Particularidades
        objDescrQx.Descripcion = ""
        objDescrQx.Particularidades = ""
    End Sub
    Private Sub dtgPersonalMedico_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dtgPersonalMedico.UserDeletedRow
        dtgPersonalMedico.DataSource.AcceptChanges()
    End Sub

    Private Sub dtgPersonalMedico_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dtgPersonalMedico.UserDeletingRow
        If MessageBox.Show("Esta Seguro de Borrar este Registro?", "Descripcion Quirurgica", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ActualizarEstadoEquipoMedico(e.Row)
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub txtDescProfes_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtDescProfes.MouseDoubleClick
        'BuscarMedico()
        Dim frmConsulta As New frmc_ConsultaMedicoQx("", IIf(Len(txtCodTipPers.Text) = 0, "", txtCodTipPers.Text), txtNombre.Text)
        frmConsulta.ShowDialog()
        If Len(frmConsulta.CodigoMedico) > 0 Then
            txtCodProfes.Text = frmConsulta.CodigoMedico
            txtDescProfes.Text = frmConsulta.ApellidoMedico
            txtNombre.Text = frmConsulta.NombreMedico
            CargarCombos(2)
        End If
    End Sub

    Private Sub txtDescProfes_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescProfes.Validated

        If Len(txtCodProfes.Text) > 0 Then
            CargarCombos(2)
        End If
    End Sub

    Private Sub btnBuscarMedico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMedico.Click

        If Len(Trim(txtDescProfes.Text)) > 0 Or Len(Trim(txtNombre.Text)) Then
            Dim frmConsulta As New frmc_ConsultaMedicoQx(txtDescProfes.Text, IIf(Len(txtCodTipPers.Text) = 0, "", txtCodTipPers.Text), txtNombre.Text)
            frmConsulta.ShowDialog()
            txtCodProfes.Text = frmConsulta.CodigoMedico
            txtDescProfes.Text = frmConsulta.ApellidoMedico
            txtNombre.Text = frmConsulta.NombreMedico
            txtDescProfes.Focus()
        Else
            Dim frmConsultaT As New frmc_ConsultaMedicoQx(IIf(Len(txtCodTipPers.Text) = 0, "", txtCodTipPers.Text))
            frmConsultaT.ShowDialog()
        End If

    End Sub
    Private Sub NuevoProcedimiento()
        Dim dt As New DataTable

        txtcodProce.Text = String.Empty
        cmbProcedim.Text = String.Empty
        'Joseph Moreno (IG) Fec:2019/11/19 Particularidades
        Me.ctlPartProce.Limpiar(True)

        If Len(txtHoraCir.Text) = 0 Then

            dt = dtgProcedim.DataSource

            If dt.Rows.Count > 0 Then
                mskInicioCir.Text = IIf(IsDBNull(dt.Rows(0).Item("FechaInicio")), "", dt.Rows(0).Item("FechaInicio"))
                txtHoraCir.Text = IIf(IsDBNull(dt.Rows(0).Item("HoraInicio")), "", dt.Rows(0).Item("HoraInicio"))
                txtMinCir.Text = IIf(IsDBNull(dt.Rows(0).Item("MinutoInicio")), "", dt.Rows(0).Item("MinutoInicio"))
                mskFinalCir.Text = IIf(IsDBNull(dt.Rows(0).Item("FechaFinal")), "", dt.Rows(0).Item("FechaFinal"))
                txtHoraFinalCir.Text = IIf(IsDBNull(dt.Rows(0).Item("HoraFinal")), "", dt.Rows(0).Item("HoraFinal"))
                txtMinFinCir.Text = IIf(IsDBNull(dt.Rows(0).Item("MinutoFinal")), "", dt.Rows(0).Item("MinutoFinal"))
                lblTiempQx.Text = IIf(IsDBNull(dt.Rows(0).Item("TiempoQX")), "", dt.Rows(0).Item("TiempoQX"))
            End If


        End If


        For i As Integer = 0 To dt.Rows.Count - 1
            dt.Rows(i).Item("Copiar") = "N"


        Next


    End Sub


    Private Sub dtgPreoperatorio_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dtgPreoperatorio.UserDeletedRow
        dtgPreoperatorio.DataSource.AcceptChanges()
    End Sub

    Private Sub dtgPreoperatorio_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dtgPreoperatorio.UserDeletingRow
        If MessageBox.Show("Esta Seguro de eliminar este Diagnóstico?", "Descripcion Quirurgica", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            EliminaDiagnosticos(e.Row)

        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub dtgPostperatorio_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dtgPostperatorio.UserDeletedRow
        dtgPostperatorio.DataSource.AcceptChanges()
    End Sub

    Private Sub dtgPostperatorio_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dtgPostperatorio.UserDeletingRow
        If MessageBox.Show("Esta Seguro de eliminar este Diagnóstico?", "Descripcion Quirurgica", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            EliminaDiagnosticos(e.Row)

        Else
            e.Cancel = True
        End If
    End Sub



    Private Sub dtgProcedim_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgProcedim.CellContentClick
        Dim dtDatos As DataTable = dtgProcedim.DataSource
        Dim cont As Integer = 0
        Dim strCirujano As String = ""
        Dim contrep As Integer = 0

        If dtgProcedim.CurrentCell.ColumnIndex = dtgProcedim.Columns("Sel").Index And e.RowIndex >= 0 Then

            If Not IsDBNull(dtgProcedim.CurrentCell.Value) Then
                If dtgProcedim.CurrentCell.Value = "S" Then
                    dtgProcedim.CurrentCell.Value = "N"
                    dtDatos.Rows(e.RowIndex).Item("Copiar") = "N"
                Else
                    If Len(txtSangrado.Text) > 0 Or Len(txtTejidos.Text) > 0 _
                         Or Len(txtDescIntervencion.Text) > 0 Or Len(txtComplicaciones.Text) > 0 _
                         Or Len(txtHallazgos.Text) > 0 Then
                        dtDatos.Rows(e.RowIndex).Item("Copiar") = "N"
                        Exit Sub
                    End If
                    dtgProcedim.CurrentCell.Value = "S"
                    dtDatos.Rows(e.RowIndex).Item("Copiar") = "S"
                    strCirujano = IIf(IsDBNull(dtDatos.Rows(e.RowIndex).Item("cod_permedas")), "", dtDatos.Rows(e.RowIndex).Item("cod_permedas"))

                    For i As Integer = 0 To dtDatos.Rows.Count - 1

                        If dtDatos.Rows(i).Item("Copiar").ToString = "S" Then
                            'If (strCirujano <> IIf(IsDBNull(dtDatos.Rows(i).Item("cod_permedas").ToString), "", dtDatos.Rows(i).Item("cod_permedas").ToString)) And dtgProcedim.CurrentCell.Value = "S" Then
                            '    MsgBox("No puede seleccionar procedimientos con Cirujano diferente")
                            '    dtgProcedim.CurrentCell.Value = "N"
                            '    dtDatos.Rows(e.RowIndex).Item("Copiar") = "N"
                            '    contrep = contrep + 1
                            '    Exit For
                            'End If
                        End If

                    Next
                    If contrep = 0 Then
                        IniciarProcedimientos()
                    End If

                End If
            End If



            For i As Integer = 0 To dtDatos.Rows.Count - 1

                If dtDatos.Rows(i).Item("Copiar").ToString = "S" Then
                    cont = cont + 1
                End If

            Next
            If cont = 0 Then
                LimpiardatosDescQX()
                BloquearControles(True)
            End If

        End If

        If ValidarProcedimientosSeleccionados() = False Then
            MessageBox.Show("Seleccione un Registro de la Lista", "Descripción Quirúrgica", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If txtcodProce.Enabled = False And cmbProcedim.Enabled = False Then
                txtcodProce.Enabled = True
                cmbProcedim.Enabled = True
                'Joseph Moreno (IG) Fec:2019/11/19 Particularidades
                Me.ctlPartProce.Activar(True)
            End If
            Exit Sub
        End If

    End Sub

    Private Function ValidarProcedimientosSeleccionados() As Boolean
        Dim dtDatos As DataTable = dtgProcedim.DataSource
        Dim contsel As Integer = 0


        For i As Integer = 0 To dtDatos.Rows.Count - 1
            If dtDatos.Rows(i).Item("Copiar").ToString = "S" Then
                contsel = contsel + 1
            End If
        Next

        If contsel = 0 Then

            Return False
            Exit Function
        Else
            Return True
        End If

    End Function

    Private Sub Panel16_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel16.Click

        If GroupBox1.Enabled = False And Trim(txtHoraCir.Text.Length) = 0 And Trim(txtHoraFinalCir.Text.Length) = 0 And ValidarProcedimientosSeleccionados() = True Then
            MsgBox("Diligencie completamente los datos de la intervención para continuar")
        End If

    End Sub


    Private Sub RadioButtonSi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonSi.Click
        Dim dtDatos As DataTable
        Dim dtpreoperatorio As DataTable
        Dim dtpostoperatorio As DataTable

        Dim dspatologia As New DataSet
        Dim dtspatologia As New DataTable
        dtpreoperatorio = Me.dtgPreoperatorio.DataSource
        dtpostoperatorio = Me.dtgPostperatorio.DataSource
        dtDatos = dtgProcedim.DataSource
        Dim dtdatoC As DataTable = dtDatos.Clone
        Dim dr As DataRow = dtdatoC.NewRow
        dr("consecutivo") = dtDatos.Rows(dtgProcedim.CurrentCell.RowIndex).Item("consecutivo")
        dr("procedimiento") = dtDatos.Rows(dtgProcedim.CurrentCell.RowIndex).Item("procedimiento")
        dr("descripcion") = dtDatos.Rows(dtgProcedim.CurrentCell.RowIndex).Item("descripcion")
        dr("fechainicio") = dtDatos.Rows(dtgProcedim.CurrentCell.RowIndex).Item("fechainicio")
        dr("horainicio") = dtDatos.Rows(dtgProcedim.CurrentCell.RowIndex).Item("horainicio")
        dr("minutoinicio") = dtDatos.Rows(dtgProcedim.CurrentCell.RowIndex).Item("minutoinicio")
        dr("fechafinal") = dtDatos.Rows(dtgProcedim.CurrentCell.RowIndex).Item("fechafinal")
        dr("horafinal") = dtDatos.Rows(dtgProcedim.CurrentCell.RowIndex).Item("horafinal")
        dr("minutofinal") = dtDatos.Rows(dtgProcedim.CurrentCell.RowIndex).Item("minutofinal")
        dr("tiempoQX") = dtDatos.Rows(dtgProcedim.CurrentCell.RowIndex).Item("tiempoQX")
        dr("tip_anestesia") = dtDatos.Rows(dtgProcedim.CurrentCell.RowIndex).Item("tip_anestesia")
        dr("anestesia") = dtDatos.Rows(dtgProcedim.CurrentCell.RowIndex).Item("anestesia")
        dr("bilateral") = dtDatos.Rows(dtgProcedim.CurrentCell.RowIndex).Item("bilateral")
        dr("cod_permedas") = dtDatos.Rows(dtgProcedim.CurrentCell.RowIndex).Item("cod_permedas")
        dr("secuencia") = dtDatos.Rows(dtgProcedim.CurrentCell.RowIndex).Item("secuencia")
        dr("estado") = dtDatos.Rows(dtgProcedim.CurrentCell.RowIndex).Item("estado")
        dr("copiar") = dtDatos.Rows(dtgProcedim.CurrentCell.RowIndex).Item("copiar")
        'Joseph Moreno (IG) Fec:2019/11/18 Particularidades

        dtdatoC.Rows.Add(dr)
        frmOrdenPatologia.Mostrar(dtdatoC, dtpreoperatorio, dtpostoperatorio)
        dspatologia = objQx.ConsultarOrdenPatologia(objGeneral.Prestador, objGeneral.Sucursal, dtgProcedim.CurrentRow.Cells("consecutivo").Value, dtgProcedim.CurrentRow.Cells("Procedimiento").Value, objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision)
        dtspatologia = dspatologia.Tables(0)
        If dtspatologia.Rows.Count > 0 Then
            Me.btImprimir.Visible = True
            Me.RadioButtonNo.Visible = False
            Me.RadioButtonSi.Checked = True
            Me.RadioButtonSi.Enabled = False

        Else
            Me.btImprimir.Visible = False
            Me.RadioButtonNo.Visible = True
            Me.RadioButtonSi.Enabled = True
            Me.RadioButtonNo.Checked = True
        End If

        'Me.RadioButtonNo.Checked = True
    End Sub



    Private Sub btImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btImprimir.Click

        Dim frmRepOrdenP As New frmRepOrdenPatologia
        Dim dtproced As DataTable = Nothing

        dtproced = Me.dtgProcedim.DataSource

        frmRepOrdenP.imprimirOrdenPatologia(objGeneral.Prestador, objGeneral.Sucursal,
        dtgProcedim.CurrentRow.Cells("Procedimiento").Value, dtgProcedim.CurrentRow.Cells("consecutivo").Value, 20, objPaciente.TipoAdmision, objPaciente.AnoAdmision,
        objPaciente.NumeroAdmision, objPaciente.TipoDocumento, objPaciente.NumeroDocumento)
        frmRepOrdenP.Show()
        'objDescrQx.Procedimiento
    End Sub

    'Joseph Moreno (IG) Fec:2019/11/18 Particularidades
    Private Sub ctlPartProce_Load(sender As Object, e As EventArgs) Handles ctlPartProce.Load
        Me.ctlPartProce.PasarParametros(Me.lblParticularidad, 200)
    End Sub

    Private Sub cmbProcedim_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProcedim.SelectedIndexChanged

    End Sub

    'Inicia: CCGUTIEREZ - OSI. 20/01/2020
    'Proyecto: Sophia - Codificacion
    'Cambio: Se agrega el evento para que se Limpie el control de las Particularidades 
    'si se modifica la descripcion de búsqueda
    Private Sub cmbProcedim_TextUpdate(sender As Object, e As EventArgs) Handles cmbProcedim.TextUpdate
        Me.txtcodProce.Text = ""
        Me.ctlPartProce.Limpiar(True)
    End Sub
End Class

