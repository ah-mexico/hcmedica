
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes.FuncionesGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports HistoriaClinica.Sophia.HistoriaClinica.HistoriaBasica
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports objGenerales = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Mail
Imports System.Net.Mail
Imports System.IO

' -----------------------------------------------------------------------------
' Project	 : HistoriaClinica.CtlPlanProcExternos
' Class	 : Sophia.HistoriaClinica.Egresos.CtlPlanProcExternos
' -----------------------------------------------------------------------------
' Clase CtlPlanProcExternos del namespace Sophia.HistoriaClinica.Egresos que es la clase base
' Esta clase tiene la funcionalidad del control de usuario para el plan de manejo para los 
' Procedimientos Externos y será usado en la aplicación cliente en Windows Form 2005
' -----------------------------------------------------------------------------
Public Class ctlPlanProcExternos
    '' ''Private Shared _Instancia As ctlPlanProcExternos
    Private objGeneral As Generales
    Private objPaciente As Paciente
    Private objConexion As Conexion
    Private daoGeneral As New DAOGeneral
    Private objProcExternos As PlanProcExternos
    Private objDatosHistoriaBasica As DatosHistoriaBasica
    Private strModificar As String = ""
    Private intCodPro As Integer

    'esta variable identifica si el usuario inserto datos y no los ha guardado
    Private datosSinAlmacenar As Boolean = False

    ''' <summary>
    ''' Determina si existen datos sin almacenar.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property existenDatosSinAlmacenar() As Boolean
        Get
            Return Me.datosSinAlmacenar
        End Get
    End Property

#Region "Instancia de Control"
    Public Shared ReadOnly Property Instancia() As ctlPlanProcExternos
        Get
            Return New ctlPlanProcExternos()
        End Get
    End Property
#End Region

#Region "Load"

    Private Sub ctlPlanProcExternos_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
        '*************REF-CONT*************************
        'pnlInfoImpresionDiagnostica.Visible = False
        '**********************************************
        '' ''disposeSigletonProcedim()
        ''Me.Visible = False
    End Sub

    Private Sub ctlPlanProcExternos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        frmHistoriaPrincipal.blnFirstPlanProcExternos = False

        objGeneral = Generales.Instancia
        objPaciente = Paciente.Instancia
        objConexion = Conexion.Instancia
        objProcExternos = PlanProcExternos.Instancia
        objDatosHistoriaBasica = DatosHistoriaBasica.Instancia
        CargarCombo()
        IniciarPlanProcesosExternos()
        InhabilitarPeru()
        Me.ctluProcExterno.Activar(False)
        Me.ctluProcExterno.PasarParametros(Nothing, 200)
    End Sub

    Private Sub IniciarPlanProcesosExternos()
        If objProcExternos.Estado = "N" Then
            cbProcedimiento.Text = ""
            btGrabar.Enabled = True
        End If
        'If objProcExternos.Estado = "G" Then
        '    btGrabar.Enabled = False
        'End If
        If objProcExternos.Estado <> "" Then
            LlenarGrilla()
            'dgProcedimiento.DataSource = objProcExternos.dtProcedimientos
        Else
            CargarValoresIniciales()
        End If

        '*************REF-CONT*************************
        'If objProcExternos.ContraReferencia = False Then
        '    'objDatosHistoriaBasica = DatosHistoriaBasica.Instancia
        '    'If objDatosHistoriaBasica.ImpresionDiagnostica.DatosDiagnosticos.Rows.Count > 0 Then
        '    '    pnlInfoImpresionDiagnostica.Visible = True
        '    '    dtgInfoID.DataSource = objDatosHistoriaBasica.ImpresionDiagnostica.DatosDiagnosticos
        '    '    dtgInfoID.Height = dtgInfoID.ColumnHeadersHeight + (dtgInfoID.Rows.GetRowsHeight(DataGridViewElementStates.None))
        '    'End If
        'Else
        '    'If Not objProcExternos.DatosImpresionDiagnostica Is Nothing Then
        '    '    If objProcExternos.DatosImpresionDiagnostica.Rows.Count > 0 Then
        '    '        pnlInfoImpresionDiagnostica.Visible = True
        '    '        dtgInfoID.DataSource = objProcExternos.DatosImpresionDiagnostica
        '    '        dtgInfoID.Height = dtgInfoID.ColumnHeadersHeight + (dtgInfoID.Rows.GetRowsHeight(DataGridViewElementStates.None))
        '    '    End If
        '    'End If
        'End If
        '**********************************************

        tbCodTipoProc.Focus()

        configurarPantallaContrareferencia()
    End Sub

    Private Sub configurarPantallaContrareferencia()
        'Walter Prens Herrera
        If objProcExternos.ContraReferencia = True Then

            With dgProcedimiento
                .Columns("con_procedim").Visible = False
                .Columns("PyP").Visible = False
                .Columns("cerrado").Visible = False
                .Columns("resultado").Visible = False
                .Columns("Interpretacion").Visible = False
                .Columns("NombreMedico").Visible = False
                .Columns("desSucur").Visible = False
                .Columns("hcOrigen").Visible = False
                .Columns("hcReferencia").Visible = False
                .Columns("codpresgs_prac").Visible = False
                .Columns("codsucur_prac").Visible = False
                .Columns("tipadmi_prac").Visible = False
                .Columns("anoadm_prac").Visible = False
                .Columns("numadm_prac").Visible = False
                .Columns("xmlGrpXPar").Visible = False
                '.Columns("xmlRsGrpXPart").Visible = False
            End With

            mostrarControlesContrarreferencia(True, False)

        Else
            mostrarControlesContrarreferencia(False, True)
        End If

    End Sub

    Private Sub mostrarControlesContrarreferencia(ByVal controlesVisibles As Boolean,
                                                  ByVal controlesEnabled As Boolean)

        pnlContrarreferencia.Visible = controlesVisibles
        'lblResultado.Visible = controlesVisibles
        'lblIterpretacion.Visible = controlesVisibles
        'txtResultado.Visible = controlesVisibles
        'txtInterpretacion.Visible = controlesVisibles

        tbCodProc.ReadOnly = Not controlesEnabled
        cbProcedimiento.Enabled = controlesEnabled
        tbCodTipoProc.ReadOnly = Not controlesEnabled
        tbDesTipoProc.ReadOnly = Not controlesEnabled
        tbCantidad.ReadOnly = Not controlesEnabled
        ckBilateral.Enabled = controlesEnabled
        tbObservaciones.ReadOnly = Not controlesEnabled
        txtResultado.ReadOnly = Not controlesEnabled
        txtInterpretacion.ReadOnly = Not controlesEnabled
        tb_Guia.ReadOnly = Not controlesEnabled
        tb_Justi.ReadOnly = Not controlesEnabled
        op_TipoServ.Enabled = controlesEnabled
        op_Electivo.Enabled = controlesEnabled
        op_PrioSI.Enabled = controlesEnabled
        op_PrioNO.Enabled = controlesEnabled
    End Sub
#End Region

#Region "Salir"

    Private Sub ctlPlanProcExternos_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged

        If sender.Visible Then
            If Me.datosSinAlmacenar = False Then
                LimpiarDatos()
                IniciarPlanProcesosExternos()
            End If

            If frmHistoriaPrincipal.blnFirstPlanProcExternos Then
                frmHistoriaPrincipal.blnFirstPlanProcExternos = False
            End If
        Else
            If Not objProcExternos.dtProcedimientos Is Nothing Then
                If objProcExternos.dtProcedimientos.Rows.Count > 0 And Me.datosSinAlmacenar Then
                    If MessageBox.Show("Desea Guardar la información de los procedimientos registrados?", "Historia Clinica", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        ''se almacenan los datos
                        Me.guardarDatosGrid()
                        Me.Visible = False
                    Else
                        Exit Sub
                    End If
                End If
            End If

            If objProcExternos.PermiteLimpiarReferencia = True Then
                objProcExternos.PermiteLimpiarReferencia = False
                objProcExternos.Estado = ""
                objProcExternos.DatosImpresionDiagnostica = Nothing
                objProcExternos.dtProcedimientos = Nothing
                CargarValoresIniciales()
                objProcExternos.ContraReferencia = False
                configurarPantallaContrareferencia()
            End If
            'Me.Dispose(True)
            InhabilitarPeru()
        End If
    End Sub

    Private Sub LimpiarDatos()
        tbCodTipoProc.ResetText()
        tbDesTipoProc.ResetText()
        tbCodProc.ResetText()
        cbProcedimiento.ResetText()
        tbCantidad.ResetText()
        ckBilateral.Checked = False
        tbObservaciones.ResetText()
        txtResultado.ResetText()
        txtInterpretacion.ResetText()
        chkPyP.Checked = False
    End Sub

#End Region

#Region "CargarValoresIniciales - Load"
    Private Sub CargarValoresIniciales()
        '// Definir Datos Para la grilla \\
        'CargarCombo()

        Dim dtTable As New DataTable
        With dtTable
            .Columns.Add("cod_pre_sgs", System.Type.GetType("System.String"))
            .Columns.Add("cod_sucur", System.Type.GetType("System.String"))
            .Columns.Add("tip_admision", System.Type.GetType("System.String"))
            .Columns.Add("ano_adm", System.Type.GetType("System.String"))
            .Columns.Add("num_adm", System.Type.GetType("System.String"))
            '.Columns.Add("con_procedim", System.Type.GetType("System.String"))
            .Columns.Add("procedim", System.Type.GetType("System.String"))
            .Columns.Add("tip_doc", System.Type.GetType("System.String"))
            .Columns.Add("Num_doc", System.Type.GetType("System.String"))
            .Columns.Add("entidad", System.Type.GetType("System.String"))
            .Columns.Add("cantidad", System.Type.GetType("System.String"))
            .Columns.Add("can_aplicada", System.Type.GetType("System.String"))
            .Columns.Add("fecha", System.Type.GetType("System.String"))
            .Columns.Add("medico", System.Type.GetType("System.String"))
            .Columns.Add("estado", System.Type.GetType("System.String"))
            .Columns.Add("pais", System.Type.GetType("System.String"))
            .Columns.Add("departamen", System.Type.GetType("System.String"))
            .Columns.Add("ciudad", System.Type.GetType("System.String"))
            .Columns.Add("fec_con", System.Type.GetType("System.String"))
            .Columns.Add("login", System.Type.GetType("System.String"))
            .Columns.Add("obs", System.Type.GetType("System.String"))
            .Columns.Add("bilateral", System.Type.GetType("System.String"))
            .Columns.Add("recomendacion", System.Type.GetType("System.String"))
            .Columns.Add("Descripcion", System.Type.GetType("System.String"))
            .Columns.Add("Nuevo", System.Type.GetType("System.String"))
            .Columns.Add("tipoprocedim", System.Type.GetType("System.String"))
            .Columns.Add("desctipo", System.Type.GetType("System.String"))
            .Columns.Add("PyP", System.Type.GetType("System.String"))
            .Columns.Add("TipServ", System.Type.GetType("System.String"))
            .Columns.Add("Priori", System.Type.GetType("System.String"))
            .Columns.Add("Guia", System.Type.GetType("System.String"))
            .Columns.Add("Justificacion", System.Type.GetType("System.String"))
            .Columns.Add("autoSispro", System.Type.GetType("System.String"))
            .Columns.Add("xmlGrpXPar", System.Type.GetType("System.String"))
            '.Columns.Add("xmlRsGrpXPart", System.Type.GetType("System.String"))
        End With
        dgProcedimiento.DataSource = dtTable
        With dgProcedimiento
            .Columns("cod_pre_sgs").Visible = False
            .Columns("cod_sucur").Visible = False
            .Columns("tip_admision").Visible = False
            .Columns("ano_adm").Visible = False
            .Columns("num_adm").Visible = False
            ' .Columns("con_procedim").Visible = False
            '.Columns("Procedim").Visible = False
            .Columns("tip_doc").Visible = False
            .Columns("Num_doc").Visible = False
            .Columns("entidad").Visible = False
            .Columns("cantidad").Visible = True
            .Columns("can_aplicada").Visible = False
            .Columns("fecha").Visible = False
            .Columns("medico").Visible = False
            .Columns("estado").Visible = False
            .Columns("pais").Visible = False
            .Columns("departamen").Visible = False
            .Columns("ciudad").Visible = False
            .Columns("fec_con").Visible = False
            .Columns("login").Visible = False
            .Columns("obs").Visible = True
            .Columns("obs").HeaderText = "OBSERVACIONES"
            '.Columns("obs").Width = 200
            .Columns("bilateral").Visible = True
            .Columns("recomendacion").Visible = False
            .Columns("Descripcion").Visible = True
            .Columns("Nuevo").Visible = False
            .Columns("tipoprocedim").Visible = False
            .Columns("desctipo").Visible = False
            .Columns("PyP").Visible = False
            .Columns("TipServ").Visible = False
            .Columns("Priori").Visible = False
            .Columns("Guia").Visible = False
            .Columns("Justificacion").Visible = False
            '.Columns("xmlGrpXPar").Visible = False
            .Columns(35).Visible = False
            '.Columns("xmlRsGrpXPart").Visible = False
        End With

        dgProcedimiento.Refresh()
    End Sub
#End Region

#Region "CargarCombo"
    Private Sub CargarCombo()

        Dim objLocal As New Sophia.HistoriaClinica.BL.BLBasicasLocales
        Dim strCadenaLocal As String = objGeneral.CadenaLocal

        '/ para los tipos de procedimientos \
        tbDesTipoProc.NombreCampoDatos = "descripcion"
        tbCodTipoProc.NombreCampoBusqueda = "tip_proced"
        tbCodTipoProc.NombreCampoBuscado = "descripcion"
        tbCodTipoProc.ControlTextoEnlace = tbDesTipoProc
        tbDesTipoProc.ControlTextoEnlace = tbCodTipoProc
        tbDesTipoProc.OrigenDeDatos = objLocal.TraerDatosTablasBasicasLocales(strCadenaLocal, "gentippr", "tip_proced,descripcion", "")
        tbDesTipoProc.CargarDatosDescripcion()


        tbCodProc.ControlComboEnlace = cbProcedimiento
        '/ para los Procedimientos \
        With cbProcedimiento
            .CampoMostrar = "descripcion"
            .ControlTextoEnlace = tbCodProc
            .CampoEnlazado = "codigo"
            If objGeneral.Pais = "482" Then
                .CategoriaDatos = CategoriaDatos.ProcedimientosEx
            Else
                .CategoriaDatos = CategoriaDatos.Procedimientos
            End If
            .Login = objGeneral.Login
            .CargarDatos()
            .CargarButton()
        End With

    End Sub
#End Region

#Region "LlenarGrilla"
    Private Sub LlenarGrilla()
        dgProcedimiento.DataSource = objProcExternos.dtProcedimientos
        With dgProcedimiento
            .Columns("cod_pre_sgs").Visible = False
            .Columns("cod_sucur").Visible = False
            .Columns("tip_admision").Visible = False
            .Columns("ano_adm").Visible = False
            .Columns("num_adm").Visible = False
            '.Columns("con_procedim").Visible = False
            .Columns("procedim").Visible = False
            .Columns("tip_doc").Visible = False
            .Columns("num_doc").Visible = False
            .Columns("entidad").Visible = False
            .Columns("cantidad").Visible = True
            .Columns("can_aplicada").Visible = False
            .Columns("fecha").Visible = False
            .Columns("medico").Visible = False
            .Columns("estado").Visible = False
            .Columns("pais").Visible = False
            .Columns("departamen").Visible = False
            .Columns("ciudad").Visible = False
            .Columns("fec_con").Visible = False
            .Columns("login").Visible = False
            .Columns("obs").Visible = True
            .Columns("obs").HeaderText = "OBSERVACIONES"
            '.Columns("obs").Width = 200
            .Columns("bilateral").Visible = True
            .Columns("recomendacion").Visible = False
            .Columns("Descripcion").Visible = True
            .Columns("Nuevo").Visible = False
            .Columns("tipoprocedim").Visible = False
            .Columns("desctipo").Visible = False
            .Columns("PyP").Visible = False
            .Columns("TipServ").Visible = False
            .Columns("Priori").Visible = False
            .Columns("Guia").Visible = False
            .Columns("Justificacion").Visible = False
            '.Columns("xmlGrpXPar").Visible = False
            .Columns(32).Visible = False
            ' .Columns("xmlRsGrpXPart").Visible = False
        End With
    End Sub
#End Region

#Region "Agregrar Procedimiento"
    Private Sub btAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAgregar.Click

        Dim bError As Boolean = True
        Dim dtTable As New DataTable
        dtTable = dgProcedimiento.DataSource
        Dim objBLG As New BLBasicasGenerales
        Dim pide_SISPRO As String
        Dim pag_SISPRO As String
        Dim cod_Sispro As String = ""
        Dim flag_pos As String = ""
        Dim flag_posCondicionado As Boolean

        'martovar se agregan cambios de codificacion 2019-10-28
        Dim dtFecha As Date
        dtFecha = Format(daoGeneral.traerFechaServidor(), objGeneral.FormatoFechaCorta)

        If (tbCodTipoProc.Text = String.Empty Or tbDesTipoProc.Text = String.Empty) Then
            MessageBox.Show("Debe seleccionar el Tipo de Procedimiento, para insertar el registro.", "Historia Clinica", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbCodTipoProc.Focus()
            Exit Sub
        End If

        ' agfa_orm_inm la descripcion de los procedimientos no va a coincidir poque se toman de tablas diferentes
        'If tbCodProc.Text.Trim.Length > 0 And cbProcedimiento.Text.Trim.Length > 0 Then
        '    If objBLG.ConsultarDescripcionItemPorCodigo(objConexion, CategoriaDatos.Procedimientos, tbCodProc.Text).Trim.ToLower <> cbProcedimiento.Text.Trim.ToLower Then
        '        MessageBox.Show("El Código y la Descripción del Procedimiento Seleccionado no Coinciden." & vbCrLf & "Seleccione Nuevamente el Procedimiento.", "Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        tbCodProc.Focus()
        '        Exit Sub
        '    End If
        'End If

        ' Validacion ingresada por Claudia Garay 
        ' Solicitud Enrique Forero
        ' Observaciones obligatorias para los procedimientos de grupo 402
        If Mid(tbCodProc.Text, 1, 3) = "402" And (LTrim(tbObservaciones.Text) = String.Empty) Then
            MessageBox.Show("Para este procedimiento es obligatorio ingresar observaciones.", "Historia Clinica", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbObservaciones.Focus()
            Exit Sub
        End If

        If ValidarDatos() Then
            If strModificar = "" Then
                '/cuando es una fila nueva
                If VerificarProcedimiento() Then
                    Dim objBl As New Sophia.HistoriaClinica.BL.BLBasicasGenerales
                    Dim dtRow As DataRow = dtTable.NewRow()
                    dtRow("cod_pre_sgs") = objGeneral.Prestador
                    dtRow("cod_sucur") = objGeneral.Sucursal
                    dtRow("tip_admision") = objPaciente.TipoAdmision
                    dtRow("ano_adm") = objPaciente.AnoAdmision
                    dtRow("num_adm") = objPaciente.NumeroAdmision
                    dtRow("procedim") = Trim(tbCodProc.Text)
                    dtRow("tip_doc") = objPaciente.TipoDocumento
                    dtRow("num_doc") = objPaciente.NumeroDocumento
                    dtRow("entidad") = objPaciente.Entidad
                    dtRow("cantidad") = Trim(tbCantidad.Text)
                    dtRow("can_aplicada") = 0
                    dtRow("fecha") = DBNull.Value
                    dtRow("medico") = objGeneral.Login
                    dtRow("estado") = "P"
                    dtRow("pais") = objGeneral.Pais
                    dtRow("departamen") = objGeneral.Departamento
                    dtRow("ciudad") = objGeneral.Ciudad
                    dtRow("fec_con") = DBNull.Value
                    dtRow("login") = objGeneral.Login
                    dtRow("obs") = Trim(tbObservaciones.Text)
                    dtRow("Guia") = Trim(Me.tb_Guia.Text)
                    dtRow("xmlGrpXPar") = Me.ctluProcExterno.XmlGrpXPar

                    If ckBilateral.Checked = True Then
                        dtRow("Bilateral") = "S"
                    Else
                        dtRow("Bilateral") = "N"
                    End If
                    If Me.op_TipoServ.Checked = True Then
                        dtRow("TipServ") = "1" 'Posterior a la urgencias
                        dtRow("Priori") = "" ' sin prioridad
                    Else
                        dtRow("TipServ") = "2" 'prioridad
                        If Me.op_PrioSI.Checked = True Then
                            dtRow("Priori") = "1" 'si tiene prioridad
                        Else
                            dtRow("Priori") = "2" 'no tiene prioridad
                        End If
                    End If
                    dtRow("Justificacion") = Trim(Me.tb_Justi.Text)

                    'dtRow("recomendacion") = objBl.TraerConsultaSql(objConexion, "genproce", "obs", "procedim = '" & Trim(tbCodProc.Text) & "'")
                    '--Joseph G. Moreno Campos (IG) Fec:2018/12/05 cambio tabla Genproce -> VW_GENPROCE_DES Proy:Codificación
                    dtRow("recomendacion") = objBl.TraerConsultaSql(objConexion, "VW_GENPROCE_DES", "obs", "procedim = '" & Trim(tbCodProc.Text) & "' AND '" & Format(daoGeneral.traerFechaServidor(), objGeneral.FormatoFechaCorta) & "' BETWEEN fec_ini_proce AND fec_fin_proce ")


                    dtRow("Descripcion") = cbProcedimiento.Text
                    dtRow("Nuevo") = "N"
                    dtRow("tipoprocedim") = Trim(tbCodTipoProc.Text)
                    dtRow("desctipo") = Trim(tbDesTipoProc.Text)

                    'rmzaldua SISPRO 2017-03-28
                    pide_SISPRO = daoGeneral.EjecutarSQLStrValor("gensucur (nolock)", objConexion, " pide_SISPRO", " cod_sucur='" & objGeneral.Sucursal & "'")
                    pag_SISPRO = daoGeneral.EjecutarSQLStrValor("pargener (nolock)", objConexion, " pagsispro", " cod_pre_sgs='" & objGeneral.Prestador & "'")

                    'flag_pos = daoGeneral.EjecutarSQLStrValor("genproce (nolock)", objConexion, " flag_pos", " procedim='" & tbCodProc.Text & "'")
                    '--Joseph G. Moreno Campos (IG) Fec:2018/12/05 cambio tabla Genproce -> VW_GENPROCE_DES Proy:Codificación
                    flag_pos = daoGeneral.EjecutarSQLStrValor("VW_GENPROCE_DES (nolock)", objConexion, " flag_pos", " procedim='" & Trim(tbCodProc.Text) & "' AND '" & Format(daoGeneral.traerFechaServidor(), objGeneral.FormatoFechaCorta) & "' BETWEEN fec_ini_proce AND fec_fin_proce ")

                    If (flag_pos = Nothing) Then
                        flag_pos = "S"
                    End If

                    If (objPaciente.TipoEntidad = "EPS") And pide_SISPRO = "S" Then
                        'flag_pos = IIf(IsDBNull(dtProductoElegido.Item("flag_pos").ToString), "S", dtProductoElegido.Item("flag_pos").ToString)
                        If flag_pos = "N" Then

                            flag_posCondicionado = BLOrdenes.existePosCondicionado(objConexion, objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision, "P", tbCodProc.Text)
                            If flag_posCondicionado = True Then
                                cod_Sispro = "POS Condicionado"
                                MsgBox("El elemento prescrito es POS Condicionado por Diagnóstico", MsgBoxStyle.Information)
                            Else
                                System.Diagnostics.Process.Start(pag_SISPRO)
                                frm_SISPRO.Mostrar(cod_Sispro)
                                cod_Sispro = frm_SISPRO.Cod_SISPRO1
                            End If
                            dtRow("autoSISPRO") = cod_Sispro
                        Else
                            dtRow("autoSISPRO") = ""
                        End If
                    Else
                        dtRow("autoSISPRO") = ""
                    End If

                    'CCGUTIEREZ
                    'dtRow("ID") = DBNull.Value

                    dtTable.Rows.Add(dtRow)
                    dgProcedimiento.DataSource = dtTable
                    dgProcedimiento.Height = dgProcedimiento.ColumnHeadersHeight + (dgProcedimiento.Rows.GetRowsHeight(DataGridViewElementStates.None))
                    '/inicializar controles \
                    LimpiarProcedimiento(False)
                    BloquearProcedimiento(False)
                    tbCodTipoProc.ReadOnly = False
                    tbDesTipoProc.ReadOnly = False
                    Me.datosSinAlmacenar = True
                    '*************REF-CONT*************************
                    'If objPaciente.TipoAdmision = "E" Then
                    '    chkResumenEgreso.Visible = True
                    'End If
                    '**********************************************
                Else
                    MsgBox("Este procedimiento ya existe, por favor seleccion otro", MsgBoxStyle.Exclamation)
                End If

            Else
                '/Cuando es modificación
                dgProcedimiento.CurrentRow.Cells("Cantidad").Value = Trim(tbCantidad.Text)
                If Me.ckBilateral.Checked = True Then
                    dgProcedimiento.CurrentRow.Cells("Bilateral").Value = "S"
                Else
                    dgProcedimiento.CurrentRow.Cells("Bilateral").Value = "N"
                End If
                dgProcedimiento.CurrentRow.Cells("Obs").Value = Trim(tbObservaciones.Text)

                'Cuando se quiere grabar las contrarreferencias
                If objProcExternos.ContraReferencia = True Then
                    dtTable.Rows(dgProcedimiento.CurrentRow.Index).BeginEdit()
                    If txtResultado.ReadOnly = False Then
                        dtTable.Rows(dgProcedimiento.CurrentRow.Index).Item("resultado") = Trim(txtResultado.Text)
                    End If
                    If txtInterpretacion.ReadOnly = False Then
                        dtTable.Rows(dgProcedimiento.CurrentRow.Index).Item("Interpretacion") = Trim(txtInterpretacion.Text)
                    End If
                    dtTable.Rows(dgProcedimiento.CurrentRow.Index).EndEdit()
                    dgProcedimiento.DataSource = dtTable
                End If

                dgProcedimiento.Update()

                '/inicializar controles \
                LimpiarProcedimiento(True)
                BloquearProcedimiento(True)
                If objProcExternos.ContraReferencia = True Then
                    mostrarControlesContrarreferencia(True, False)
                Else
                    tbCodProc.ReadOnly = False
                    cbProcedimiento.Enabled = True
                    tbCodTipoProc.ReadOnly = False
                    tbDesTipoProc.ReadOnly = False
                End If
                Me.datosSinAlmacenar = True
            End If
            '/ Cargamos objeto \
            objProcExternos.Estado = "N"
            objProcExternos.dtProcedimientos = dgProcedimiento.DataSource

        End If
        'tbCodProcedimiento.Focus()
        'Walter Prens Herrera 2019-11-27
        'Joseph Moreno (IG) 2019/12/27 Prevenir limpieza de control si procedimiento está vigente.
        If tbCodTipoProc.Text = "" Then
            Me.ctluProcExterno.Limpiar(True)
        End If
    End Sub


#End Region

#Region "Borrar procedimiento grilla"
    Private Sub dgProcedimiento_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgProcedimiento.DataSourceChanged
        dgProcedimiento.Height = dgProcedimiento.ColumnHeadersHeight + (dgProcedimiento.Rows.GetRowsHeight(DataGridViewElementStates.None))
    End Sub

    Private Sub dgProcedimiento_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgProcedimiento.UserDeletingRow
        e.Cancel = False
        If objProcExternos.ContraReferencia = True Then
            e.Cancel = True
        End If
    End Sub

#End Region

#Region "VerificarProcedimiento"
    Private Function VerificarProcedimiento() As Boolean
        '// Verificar que el Procedimiento no se haya adicionado
        Dim dtTable As DataTable = New DataTable
        dtTable = Me.dgProcedimiento.DataSource
        Dim FilaBuscada() As DataRow
        Dim strCod As String = Mid(Trim(tbCodTipoProc.Text), 1, 1)

        If dtTable.Rows.Count > 0 Then
            FilaBuscada = dtTable.Select("Procedim=" & tbCodProc.Text)
            If FilaBuscada.Length = 0 Then
                VerificarProcedimiento = True
            Else
                VerificarProcedimiento = False
            End If
        Else
            VerificarProcedimiento = True
        End If
    End Function
#End Region

#Region "ValidarDatos-AdicionarGrilla"
    Private Function ValidarDatos() As Boolean
        '// Validar los datos antes de adicionar a la Grilla \\
        Dim Blorden As New BLOrdenes

        ValidarDatos = True
        If tbCodProc.Text = "" Or cbProcedimiento.Text = "" Then
            MsgBox("Por favor ingrese el procedimiento", MsgBoxStyle.Exclamation)
            tbCodTipoProc.Focus()
            ValidarDatos = False
            Exit Function
        End If

        If tbCantidad.Text.Length = 0 Then
            MsgBox("Por favor ingrese la cantidad", MsgBoxStyle.Exclamation)
            tbCantidad.Focus()
            ValidarDatos = False
            Exit Function
        Else
            If tbCantidad.Text = 0 Then
                MsgBox("La cantidad no Puede ser 0", MsgBoxStyle.Exclamation)
                tbCantidad.Focus()
                ValidarDatos = False
                Exit Function
            End If

        End If

        If objProcExternos.ContraReferencia = True Then
            If txtResultado.Text.Trim.Length = 0 Then
                MessageBox.Show("Por favor ingrese el Resultado", "Procedimientos Externos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ValidarDatos = False
                Exit Function
            End If
            If dgProcedimiento.Rows(0).Cells("medico").Value = objGeneral.Login Then
                If txtInterpretacion.Text.Trim.Length = 0 Then
                    MessageBox.Show("Por favor ingrese La Interpretación", "Procedimientos Externos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ValidarDatos = False
                    Exit Function
                End If
            End If
        End If
        If Me.op_Electivo.Checked = True Then
            If Me.op_PrioNO.Checked = False And Me.op_PrioSI.Checked = False Then
                MessageBox.Show("Por favor escojer la prioridad", "Procedimientos Externos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ValidarDatos = False
                Exit Function
            End If
        End If


        'If Blorden.ValidaAutorizacionProcedimiento(tbCodProc.Text, objPaciente.Entidad, objPaciente.TipoAdmision) = True Then
        '    ''Resolución 4331 cpgaray Marzo 7 de 2013
        '    If Len(Trim(tb_Guia.Text)) = 0 And objGeneral.Pais <> "482" Then
        '        MessageBox.Show("Por favor ingrese el Manejo Integral según guía de", "Procedimientos Externos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '        Me.tb_Guia.Focus()
        '        ValidarDatos = False
        '        Exit Function
        '    End If

        '    If Len(Trim(tb_Justi.Text)) = 0 And objGeneral.Pais <> "482" Then
        '        MessageBox.Show("Por favor ingrese la Justificación", "Procedimientos Externos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '        Me.tb_Justi.Focus()
        '        ValidarDatos = False
        '        Exit Function
        '    End If
        'End If

        ' Codificacion 
        ''Resolución 4331 cpgaray Marzo 7 de 2013
        If Len(Trim(tb_Guia.Text)) = 0 And objGeneral.Pais <> "482" Then
            MessageBox.Show("Por favor ingrese el Manejo Integral según guía de", "Procedimientos Externos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.tb_Guia.Focus()
            ValidarDatos = False
            Exit Function
        End If

        If Len(Trim(tb_Justi.Text)) = 0 And objGeneral.Pais <> "482" Then
            MessageBox.Show("Por favor ingrese la Justificación", "Procedimientos Externos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.tb_Justi.Focus()
            ValidarDatos = False
            Exit Function
        End If

        'Joseph Moreno (IG) Fec:2019/12/27 Seleccionar al menos una particularidad
        If Not Me.ctluProcExterno.Validar() Then
            MsgBox("Seleccione al menos una particularidad para continuar.")
            ValidarDatos = False
            Exit Function
        End If



    End Function
#End Region

#Region "EditarFilaGrilla-Actualizar"

    Private Sub EditarProcedimientosExternos(ByVal dr As DataGridViewRow)

        strModificar = ""

        If IsNothing(dr) Then
            Exit Sub
        End If
        Dim tabla As DataTable = dgProcedimiento.DataSource
        Dim Fila As DataRow = tabla.Rows.Item(dr.Index)
        tbCodProc.Text = dr.Cells("procedim").Value.ToString()
        cbProcedimiento.Text = dr.Cells("Descripcion").Value.ToString()
        tbCodTipoProc.Text = dr.Cells("tipoprocedim").Value.ToString()
        tbDesTipoProc.Text = dr.Cells("desctipo").Value.ToString()
        tbCantidad.Text = dr.Cells("Cantidad").Value.ToString()
        tbObservaciones.Text = dr.Cells("Obs").Value.ToString()
        Me.tb_Guia.Text = dr.Cells("Guia").Value.ToString()
        Me.tb_Justi.Text = dr.Cells("Justificacion").Value.ToString()
        If dr.Cells("Bilateral").Value.ToString() = "S" Then
            ckBilateral.Checked = True
        Else
            ckBilateral.Checked = False
        End If

        If dr.Cells("TipServ").Value.ToString() = "1" Then
            Me.op_TipoServ.Checked = True
        Else
            Me.op_Electivo.Checked = True
            If dr.Cells("Priori").Value.ToString() = "1" Then
                Me.op_PrioSI.Checked = True
            Else
                Me.op_PrioNO.Checked = True
            End If
        End If

        ''Carga los datos guardados en los campos de contrareferencia
        If objProcExternos.ContraReferencia = True Then
            txtResultado.Text = dr.Cells("resultado").Value.ToString()
            txtInterpretacion.Text = dr.Cells("Interpretacion").Value.ToString()
        End If
        'Walter Prens Herrera 2019-11-27
        If Not String.IsNullOrEmpty(Fila.ItemArray(32).ToString) Then
            Me.ctluProcExterno.PasarDatos(
            tbCodProc.Text, cbProcedimiento.Text,
            Sub(ByVal strDescripcionTotal As String, ByVal iCantidad As Integer, ByVal strXmlParticularidades As String, ByVal strXmlProcedimientos As String)
                ActualizarTextoDescripcion(strDescripcionTotal)
            End Sub, strXmlGrpXPart:=Fila.ItemArray(32).ToString)
        End If
        Me.ctluProcExterno.Activar(False)

    End Sub

    Private Sub dgProcedimiento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgProcedimiento.Click

        If dgProcedimiento.DataSource Is Nothing Then
            Exit Sub
        Else
            If dgProcedimiento.DataSource.Rows.Count <= 0 Then
                Exit Sub
            End If
        End If

        EditarProcedimientosExternos(sender.CurrentRow)

        If objProcExternos.ContraReferencia = False Then
            tbCodProc.ReadOnly = False
            cbProcedimiento.Enabled = True
            tbCodTipoProc.ReadOnly = False
            tbDesTipoProc.ReadOnly = False
        Else
            mostrarControlesContrarreferencia(True, False)
        End If

    End Sub

    Private Sub dgProcedimiento_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgProcedimiento.DoubleClick

        If dgProcedimiento.DataSource Is Nothing Then
            Exit Sub
        Else
            If dgProcedimiento.DataSource.Rows.Count <= 0 Then
                Exit Sub
            Else
                EditarProcedimientosExternos(sender.CurrentRow)
                If NVL(dgProcedimiento.CurrentRow.Cells("Nuevo").Value) <> "N" Then
                    'MessageBox.Show("No Es Permitido Modificar Este Registro")
                    'Si se desea grabar las contrareferencias
                    If NVL(dgProcedimiento.CurrentRow.Cells("cerrado").Value) = "S" Then
                        MessageBox.Show("No Es Permitido Modificar Este Registro, esta cerrado")
                    Else
                        If dgProcedimiento.CurrentRow.Cells("medico").Value <> objGeneral.Login Then
                            If dgProcedimiento.CurrentRow.Cells("resultado").Value.ToString.Trim.Length > 0 Then
                                MessageBox.Show("No Es Permitido Modificar Este Registro, la Respuesta ya ha sido Grabada")
                                Exit Sub
                            End If
                        End If
                        'txtResultado.ReadOnly = txtResultado.Text.Trim.Length > 0
                        txtResultado.ReadOnly = False
                        If objProcExternos.ContraReferencia = True Then
                            If dgProcedimiento.CurrentRow.Cells("medico").Value = objGeneral.Login Then
                                txtInterpretacion.ReadOnly = False
                            Else
                                txtInterpretacion.ReadOnly = True
                            End If
                        End If
                        strModificar = "PE"
                        If txtResultado.ReadOnly = False Then
                            txtResultado.Focus()
                        Else
                            txtInterpretacion.Focus()
                        End If
                    End If
                    Exit Sub
                End If

                tbCodProc.ReadOnly = True
                cbProcedimiento.Enabled = False
                tbCodTipoProc.ReadOnly = True
                tbDesTipoProc.ReadOnly = True
                strModificar = "PE"

            End If
        End If

    End Sub

    Private Sub dgProcedimiento_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgProcedimiento.RowsRemoved
        If objProcExternos.ContraReferencia = False Then
            dgProcedimiento.Height = dgProcedimiento.ColumnHeadersHeight + (dgProcedimiento.Rows.GetRowsHeight(DataGridViewElementStates.None))
        End If
        LimpiarProcedimiento(False)
        tbCodTipoProc.ReadOnly = False
        tbDesTipoProc.ReadOnly = False
        tbCodProc.ReadOnly = False
        cbProcedimiento.Enabled = True

        If dgProcedimiento.RowCount <= 0 Then
            Me.datosSinAlmacenar = False
        End If

        If dgProcedimiento.RowCount - 1 <= 0 And objProcExternos.ContraReferencia = False Then
            tbCodTipoProc.ReadOnly = False
            tbDesTipoProc.ReadOnly = False

            '*************REF-CONT*************************
            'chkResumenEgreso.Visible = False
            'chkResumenEgreso.Checked = True
            '**********************************************
        End If
    End Sub

    Private Sub tbCodProcedimiento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbCodTipoProc.Click
        If Not (Me.tbCodTipoProc.ReadOnly Or Me.tbDesTipoProc.ReadOnly) Then
            LimpiarProcedimiento(True)
        End If
    End Sub

    Private Sub LimpiarProcedimiento(ByVal limpiarTipoProcedimiento As Boolean)
        If limpiarTipoProcedimiento Then
            tbCodTipoProc.ResetText()
            tbDesTipoProc.ResetText()
        End If
        tbCodProc.ResetText()
        cbProcedimiento.ResetText()

        tbCantidad.ResetText()
        tbCantidad.Text = 1
        ckBilateral.Checked = False
        tbObservaciones.ResetText()
        strModificar = ""
        txtResultado.ResetText()
        txtInterpretacion.ResetText()

    End Sub

    Private Sub BloquearProcedimiento(ByVal BloquearTipoProcedimiento As Boolean)
        If BloquearTipoProcedimiento = False Then
            If Len(Trim(tb_Guia.Text)) > 0 Then
                Me.tb_Guia.Enabled = False
                Me.tb_Justi.Enabled = False
            End If
            Me.op_PrioNO.Enabled = False
            Me.op_PrioSI.Enabled = False
            Me.op_Electivo.Enabled = False
            Me.op_TipoServ.Enabled = False
        Else
            Me.tb_Guia.ResetText()
            Me.tb_Justi.ResetText()
            Me.op_PrioNO.Checked = False
            Me.op_PrioSI.Checked = False
            Me.op_Electivo.Checked = False
            Me.op_TipoServ.Checked = True
            Me.tb_Guia.Enabled = True
            Me.tb_Justi.Enabled = True
            Me.op_PrioNO.Enabled = True
            Me.op_PrioSI.Enabled = True
            Me.op_Electivo.Enabled = True
            Me.op_TipoServ.Enabled = True
        End If
    End Sub

    Private Sub tbCodProc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbCodProc.Click
        If Not (Me.tbCodProc.ReadOnly) Then
            LimpiarProcedimiento(False)
        Else

        End If
    End Sub


    Private Sub tbCodProc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbCodProc.GotFocus
        cbProcedimiento.CodigoTipoProcedimiento = tbCodTipoProc.Text
    End Sub
    ''' <summary>
    ''' Desarrollador: Walter Prens Herrera
    ''' Correo: wprens@intergrupo.com
    ''' fecha desarrollado  2019-11-26
    ''' Dependiendo de la parametrisacion despliega las particularidades que esten asociadas al 
    ''' tipo procedimineto
    ''' </summary>
    ''' <param name="datosElegidos"></param>
    Private Sub cbProcedimiento_ActualizarDatosElegidos(ByVal datosElegidos As System.Data.DataRow) Handles cbProcedimiento.ActualizarDatosElegidos
        If datosElegidos Is Nothing Then
            Me.tbCodTipoProc.Focus()
        End If
        'User control para las particularidades relacionadas con el procedimiento
        Me.ctluProcExterno.PasarDatos(
    tbCodProc.Text, cbProcedimiento.Text,
    Sub(ByVal strDescripcionTotal As String, ByVal iCantidad As Integer, ByVal strXmlParticularidades As String, ByVal strXmlProcedimientos As String)
        ActualizarTextoDescripcion(strDescripcionTotal)
        Me.ckBilateral.Checked = IIf(iCantidad < 2, False, True)
    End Sub)
    End Sub
    ''' <summary>
    ''' Actualiza la descripcion del procedimiento
    ''' </summary>
    ''' <param name="strDescripcionTotal"></param>
    Private Sub ActualizarTextoDescripcion(ByVal strDescripcionTotal As String)
        cbProcedimiento.Text = strDescripcionTotal
    End Sub
    Private Sub tbCodProc_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
                Handles tbCodProc.Validating, cbProcedimiento.Validating
        If (Not Me.tbCodProc.Text.Trim.Equals(String.Empty)) And (Not Me.cbProcedimiento.Text.Trim.Equals(String.Empty)) Then
            If cbProcedimiento.CodigoTipoProcedimiento.Trim.Equals(String.Empty) Then
                Me.tbCodTipoProc.Text = Me.tbCodProc.Text.Trim().Substring(0, 1)
                Me.tbDesTipoProc.Text = tbCodTipoProc.DescripcionCodigo
            ElseIf Not (Me.tbCodTipoProc.Text.Equals(Me.tbCodProc.Text.Substring(0, 1)) And (Not Me.tbCodProc.Text.Equals(""))) Then
                MessageBox.Show("El Procedimiento no corresponde al tipo de procedimiento " & Me.tbCodTipoProc.Text, "Procedimietos Externos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.ctluProcExterno.Limpiar(True)
                Me.tbCodProc.Clear()
                Me.cbProcedimiento.SelectedIndex = -1
                Me.cbProcedimiento.Text = ""
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub tbCodProcedimiento_ValidarTexto(ByVal sender As Object) Handles tbCodTipoProc.ValidarTexto
        cbProcedimiento.CodigoTipoProcedimiento = tbCodTipoProc.Text
        cbProcedimiento.UltimaDescripcionDeBusqueda = Nothing
    End Sub

    Private Sub validatingTipoProcedimiento(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
        Handles tbCodTipoProc.Validating, tbDesTipoProc.Validating

        If Not (Me.tbCodTipoProc.ReadOnly Or Me.tbDesTipoProc.ReadOnly) Then
            If Me.tbCodTipoProc.Text = String.Empty And Me.tbDesTipoProc.Text = String.Empty Then
                Exit Sub
            ElseIf (Me.tbCodTipoProc.Text = String.Empty Or Me.tbDesTipoProc.Text = String.Empty) Then
                If (Not (Me.tbDesTipoProc.Focused Or Me.tbCodTipoProc.Focused)) Then
                    MessageBox.Show("Debe seleccionar el Tipo de Procedimiento, para realizar la búsqueda.", "Historia Clinica", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    e.Cancel = True
                End If
            ElseIf (Not tbCodTipoProc.Text = String.Empty) AndAlso (Not tbCodProc.Text = String.Empty) Then
                If tbCodTipoProc.Text.Trim <> Me.tbCodProc.Text.Trim.Substring(0, 1) Then
                    tbCodProc.ResetText()
                    Me.cbProcedimiento.ResetText()
                End If
            End If
        End If
    End Sub

    Private Sub tbDesTipoProc_ValidarTexto(ByVal sender As Object) Handles tbDesTipoProc.ValidarTexto
        cbProcedimiento.CodigoTipoProcedimiento = tbCodTipoProc.Text
        'Joseph Moreno (IG) Fec:2019/12/27 Excepción Nulo
        Me.ctluProcExterno.Limpiar(True)
        Me.tbCodProc.Clear()
        Me.cbProcedimiento.SelectedIndex = -1
        cbProcedimiento.UltimaDescripcionDeBusqueda = Nothing
    End Sub

    Private Sub cbProcedimiento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbProcedimiento.Click
        cbProcedimiento.CodigoTipoProcedimiento = tbCodTipoProc.Text
    End Sub

#End Region

#Region "Grabar"
    Private Sub btGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGrabar.Click
        Me.tbCodTipoProc.ReadOnly = False
        Me.tbDesTipoProc.ReadOnly = False
        Me.tbCodProc.ReadOnly = False
        Me.cbProcedimiento.Enabled = True
        Me.guardarDatosGrid()

        ' Desarrollador: Walter Prens Herrera
        ' Correo: wprens@intergrupo.com
        ' fecha desarrollado  2019-11-26
        ' limpira el User Control Particularidad
        ' tipo procedimineto
        Me.ctluProcExterno.Limpiar(True)
    End Sub

    ''' <summary>
    ''' Almacena los datos que se encuentran en la grilla del control.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub guardarDatosGrid()

        If Me.dgProcedimiento.RowCount <= 0 Then
            MessageBox.Show("No existen datos por almacenar.", "Procedimientos externos", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            If Me.datosSinAlmacenar = True Then
                If MessageBox.Show("Una vez los datos sean guardados no podrán ser modificados. Desea continuar con la transacción?", "Historia Clinica", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim objBl As New Sophia.HistoriaClinica.BL.BLPlanManejo
                    Dim dtProcedimiento As New DataTable
                    Dim bError As Boolean = True
                    Dim lerror As Long
                    Dim NroOrden As Double

                    If dgProcedimiento.Rows.Count > 0 Then
                        dtProcedimiento = dgProcedimiento.DataSource

                        ''Grabacion de la contrareferencia
                        If objProcExternos.ContraReferencia = True Then
                            Try
                                With dtProcedimiento.Rows(0)
                                    lerror = objBl.GrabarProcContrarreferencia(objConexion, dtProcedimiento,
                                         .Item("cod_pre_sgs").ToString, .Item("cod_sucur").ToString,
                                         .Item("tip_admision").ToString, .Item("ano_adm").ToString,
                                         .Item("num_adm").ToString, objGeneral.Prestador, objGeneral.Sucursal,
                                         objPaciente.TipoAdmision, objPaciente.AnoAdmision,
                                         objPaciente.NumeroAdmision)
                                End With

                                If lerror = 0 Then
                                    objGeneral.HistoriaClinicaTieneModificaciones = True
                                    ImprimirReporte(dtProcedimiento.Rows(0).Item("cod_pre_sgs"), dtProcedimiento.Rows(0).Item("cod_sucur"), dtProcedimiento.Rows(0).Item("tip_admision"),
                                                     dtProcedimiento.Rows(0).Item("ano_adm"), dtProcedimiento.Rows(0).Item("num_adm"), dtProcedimiento.Rows(0).Item("con_procedim"))
                                    dtProcedimiento.Clear()
                                    dgProcedimiento.DataSource = dtProcedimiento
                                    LimpiarProcedimiento(True)
                                    BloquearProcedimiento(True)
                                    objProcExternos.ContraReferencia = False
                                    configurarPantallaContrareferencia()
                                    Me.datosSinAlmacenar = False
                                Else
                                    objProcExternos.Estado = "N"
                                    objProcExternos.dtProcedimientos = dtProcedimiento
                                    If lerror = 17 Then
                                        MsgBox("No existe información para grabar")
                                    Else
                                        MsgBox("Los procedimientos no se grabaron, por favor verifque la información")
                                    End If
                                End If

                            Catch ex As Exception
                                MessageBox.Show("El proceso de grabación del procedimiento falló por: " & ex.Message, "Historia Clínica")
                            End Try

                            Exit Sub
                        End If


                        ''Grabacion de los procedimientos ordenados
                        actualizarCampoPyP(dtProcedimiento)
                        Try
                            lerror = objBl.GrabarProcExternos(objConexion, dtProcedimiento, NroOrden)
                            If lerror = 0 Then
                                objGeneral.HistoriaClinicaTieneModificaciones = True

                                If objGeneral.Pais <> "482" Then
                                    ''Imprimiendo pdf
                                    Try
                                        Me.ImprimirFormulaProcedim(objGeneral.Prestador, objGeneral.Sucursal,
                                                objPaciente.TipoAdmision, objPaciente.AnoAdmision,
                                                objPaciente.NumeroAdmision, NroOrden, 1)

                                    Catch ex As Exception
                                        MessageBox.Show("Error en la creacion del reporte de solicitud de servicios de salud", "Historia Clinica", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    End Try
                                End If


                                '*************REF-CONT*************************
                                'If Len(TbMotRemision.Text.ToString) > 0 Then
                                '    ' Graba el motivo de la remision
                                '    objBl.GrabarHC_insertmotivoremisionprocedimientos(objConexion, NroOrden, TbMotRemision.Text.ToString)
                                '    If lerror <> 0 Then                                    
                                '        MsgBox("No se grabo el motivo de la remisión", MsgBoxStyle.Information)
                                '    End If
                                'End If
                                '**********************************************
                                Try
                                    ImprimirReporte(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision, NroOrden)
                                Catch ex As Exception
                                    MsgBox("Error en la impresion del reporte")
                                End Try

                                LimpiarProcedimiento(True)
                                BloquearProcedimiento(True)

                                dtProcedimiento.Clear()
                                chkPyP.Checked = False
                                dgProcedimiento.DataSource = dtProcedimiento
                                '*************REF-CONT*************************
                                'TbMotRemision.Text = ""
                                '**********************************************

                            Else
                                '/ Ingresar valores a la variable global
                                objProcExternos.Estado = "N"
                                objProcExternos.dtProcedimientos = dtProcedimiento
                                MsgBox("Los procedimientos no se grabaron, por favor verifque la información", MsgBoxStyle.Information)
                                Me.datosSinAlmacenar = True
                            End If
                        Catch ex As Exception
                            '***** para el control de errores ....*****
                            MessageBox.Show("El proceso de grabación del procedimiento falló por: " & ex.Message, "Historia Clínica", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
                            Me.datosSinAlmacenar = True
                        End Try
                        objProcExternos.dtProcedimientos = dtProcedimiento
                    Else
                        MsgBox("Debe ingresar al menos un Procedimiento", MsgBoxStyle.Exclamation)
                    End If
                End If
            End If

        End If
    End Sub



    Private Sub actualizarCampoPyP(ByRef dtProcedimiento As DataTable)
        Dim i As Integer
        Dim esPyP As String

        If chkPyP.Checked Then
            esPyP = "S"
        Else
            esPyP = "N"
        End If

        For i = 0 To dtProcedimiento.Rows.Count - 1
            dtProcedimiento.Rows(i).Item("PyP") = esPyP
        Next i

    End Sub
#End Region

#Region "ImprimirReporte"
    Public Sub ImprimirReporte(ByVal strPrestador As String, ByVal strSucursal As String, ByVal strTipoAdmision As String,
                               ByVal dblAnoAdmision As Double, ByVal dblNumAdmision As Double, ByVal NroOrden As Double)

        '*************REF-CONT*************************
        'If chkResumenEgreso.Visible = True And chkResumenEgreso.Checked = True Then
        '    frmRepResumenHistoriaClinica.Show()
        '    frmRepResumenHistoriaClinica.ImprimirResumenHistoriaClinica(objConexion, strPrestador, _
        '                          strSucursal, strTipoAdmision, dblAnoAdmision, dblNumAdmision)
        'End If
        '**********************************************
        Dim objDatosGenerales As objGenerales.Generales

        objDatosGenerales = objGenerales.Generales.Instancia

        If objDatosGenerales.Pais = "482" Then ''Peru 
            frmRepFormulaProcedim.Show()
            frmRepFormulaProcedim.imprimirFormulaProcedim(objConexion, strPrestador, strSucursal,
                                                            strTipoAdmision, dblAnoAdmision,
                                                            dblNumAdmision, NroOrden, False, objProcExternos.ContraReferencia)
        Else
            '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
            'Juan Carlos Jaramillo Lozano - IG
            RptHC_Enf_Med.Show()
            RptHC_Enf_Med.ImprimirHistoriaClinica_Procedimientos_externos(objConexion, "49", strPrestador,
                                                      strSucursal, strTipoAdmision,
                                                      dblAnoAdmision, dblNumAdmision, False,
                                                      objProcExternos.ContraReferencia, NroOrden, objPaciente.CodHistoria)
            '2019-03-11 Fin
        End If
    End Sub
#End Region

#Region "Impresio de formula de procedimientos pdf"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="codPrestador">Codigo prestador</param>
    ''' <param name="codSucursal">Codigo sucursal</param>
    ''' <param name="tipAdmin">Tipo Admision</param>
    ''' <param name="iAno">Año de admision</param>
    ''' <param name="lNumAdm">Numero de admision</param>s
    ''' <param name="dConProcedim">Procedimiento</param>
    ''' <remarks></remarks>
    Public Sub ImprimirFormulaProcedim(ByVal codPrestador As String, ByVal codSucursal As String,
                                            ByVal tipAdmin As String, ByVal iAno As Long,
                                            ByVal lNumAdm As Long, ByVal dConProcedim As Long, ByVal FlagConsulta As Long)

        Dim visorRptFormula As New FrmRepFomulaProcedimtPDF(codPrestador, codSucursal, tipAdmin, iAno, lNumAdm, dConProcedim, FlagConsulta)

        If (visorRptFormula.reportInfo Is Nothing) Then
            MessageBox.Show("El procedimiento no requiere autorización",
                                        "Historia Clinica", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ElseIf (visorRptFormula.reportInfo.emailDestinatario Is Nothing Or visorRptFormula.reportInfo.emailDestinatario = "") Then
            MessageBox.Show("No existe una direccion de correo de la entidad del afiliado : " & visorRptFormula.reportInfo.pagador,
                            "Historia Clinica", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            visorRptFormula.WindowState = FormWindowState.Maximized
            ''visorRptFormula.ShowDialog(Me.ParentForm)
            visorRptFormula.Visible = True
        Else
            If (visorRptFormula.reportInfo.tmpMail = 1) Then
                visorRptFormula.WindowState = FormWindowState.Maximized
                ''visorRptFormula.ShowDialog(Me.ParentForm)
                visorRptFormula.Visible = True
            Else

                ''Se hace visible el formulario para crear completamente los objetos.
                visorRptFormula.Visible = True
                ''Se obtienen los bytes del reporte generado en pdf
                Dim rptBytes As Byte() = visorRptFormula.getReportBytes(FrmRepFomulaProcedimtPDF.FormatReport.pdf)

                ''Se hace invisible el reporte
                visorRptFormula.Visible = False

                ''Se envia el reporte via correo electronico
                If (Me.sendFormulaByMail(visorRptFormula.reportInfo.emailDestinatario, rptBytes,
                                        "autoriza_servicios_salud.pdf", "smtp.gmail.com", "application/pdf")) Then
                    visorRptFormula.Dispose()
                    ''MsgBox("El reporte de solicitud de servicios ha sido enviado sin inconvenientes", MsgBoxStyle.Information, "Historia Clinica")
                    MessageBox.Show("El reporte de solicitud de servicios ha sido enviado sin inconvenientes", "Historia Clinica", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
                    'Juan Carlos Jaramillo Lozano - IG
                    RptHC_Enf_Med.Show()
                    RptHC_Enf_Med.RptHC_Enf_Med_FormEstado(objConexion, "59", "EM", "El reporte de solicitud de servicios ha sido enviado sin inconvenientes. " & "E-Mail: mailbog.colsanitas.com")
                    '2019-03-11 Fin

                    Dim visorRptFormula1 As New FrmRepFomulaProcedimtPDF(codPrestador, codSucursal, tipAdmin,
                                                                    iAno, lNumAdm, dConProcedim, FlagConsulta)
                    visorRptFormula1.WindowState = FormWindowState.Maximized
                    ''visorRptFormula.ShowDialog(Me.ParentForm)
                    visorRptFormula1.Visible = True

                Else
                    ''visorRptFormula.Dispose()
                    ''MessageBox.Show("El reporte de solicitud de servicios no ha podido ser enviado", "Historia Clinica", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' Envia un correo electronico con el reporte generado, en PDF
    ''' </summary>
    ''' <param name="emalDestino">Direccion de correo de destino</param>
    ''' <param name="reportBytes">Bytes del reporte a enviar</param>
    ''' <param name="reportName">Nombre del reporte</param>
    ''' <param name="smtpServer">Nombre del servidor smtp</param>
    ''' <param name="rptContentType">Tipo del contenido, definicion del tipo de reporte</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function sendFormulaByMail(ByVal emalDestino As String, ByVal reportBytes As Byte(),
                        ByVal reportName As String, ByVal smtpServer As String,
                        ByVal rptContentType As String) As Boolean
        Dim mailEnviado As Boolean = False
        ''Llenado del objeto que contiene la informacion para el mensaje
        Dim mail As New MailData()
        ''direccion de destinatario
        mail.toMail.Add(New MailAddress(emalDestino))

        ''direccion de remitente
        mail.from = New MailAddress("info-Sophia@colsanitas.com")   ' larb
        'mail.from = New MailAddress("no_responder@colsanitas.com")   

        mail.subject = "Solicitud Autorización de Servicios de Salud"
        mail.body = ""

        ''Prueba del reporte en una ruta por defecto
        'Dim fs As New FileStream("c:\" & reportName, FileMode.Create)
        'fs.Write(reportBytes, 0, reportBytes.Length)
        'fs.Close()

        ''crear un stream en memoria
        Dim strmMemory As New MemoryStream(reportBytes, 0, reportBytes.Length)
        ''Crea el contenido
        Dim content As New System.Net.Mime.ContentType(rptContentType)

        content.Name = reportName

        ''crear el attach para el envio del reporte
        Dim attach As New Attachment(strmMemory, content)
        ''atachar el objeto en el contenido del mail
        mail.attachmets.Add(attach)

        'enviar el mail
        Dim mSender As New MailSender(smtpServer, 587, SmtpDeliveryMethod.Network)
        Try
            mSender.sendMail(mail)
        Catch SmtpFailedRecipientException As Exception
            MessageBox.Show("El reporte de solicitud de servicios no ha podido ser enviado", "Historia Clinica", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        mailEnviado = True

        Return mailEnviado
    End Function
#End Region

#Region "Navegacion"

    Private Sub tbDesTipoProc_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        cbProcedimiento.CodigoTipoProcedimiento = tbCodTipoProc.Text
    End Sub

    Private Sub tbCodProcedimiento_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        cbProcedimiento.CodigoTipoProcedimiento = tbCodTipoProc.Text
        If tbCodTipoProc.Text.Length > 0 Then
            intCodPro = CInt(Mid(Trim(tbCodTipoProc.Text), 1, 1))
        End If
    End Sub

    Private Sub ClickCheckBox(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckBilateral.CheckStateChanged
        sender.Parent.GetNextControl(sender, True).Focus()
        If (ckBilateral.Checked = True) Then

            'Inicia: CCGUTIEREZ - OSI. 12/03/2020
            'Proyecto: Sophia - Codificacion
            'Cambio: Se retira linea porque el control no se debe ocultar en ningun momento
            '        cuando se capturan las Particularidades
            'Me.ctluProcExterno.Limpiar(True)
            'Fin. CCGUTIEREZ

        Else
            If (Not Me.tbCodProc.Text.Trim.Equals(String.Empty)) And (Not Me.cbProcedimiento.Text.Trim.Equals(String.Empty)) Then
                'Walter Prens Herrera 2019-11-26
                Me.ctluProcExterno.PasarDatos(
                tbCodProc.Text, cbProcedimiento.Text,
                Sub(ByVal strDescripcionTotal As String, ByVal iCantidad As Integer, ByVal strXmlParticularidades As String, ByVal strXmlProcedimientos As String)
                    ActualizarTextoDescripcion(strDescripcionTotal)
                    Me.ckBilateral.Checked = IIf(iCantidad < 2, False, True)
                End Sub)
            End If
        End If

    End Sub

    Private Sub tbCantidad_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbCantidad.Validated
        Me.tbObservaciones.Focus()
    End Sub

#End Region


    Public Sub CargarReferencia(ByVal dtProcedimientoReferencia As DataTable, Optional ByVal dtDatosID As DataTable = Nothing)
        LimpiarDatos()

        If IsNothing(dtProcedimientoReferencia) Then
            Exit Sub
        ElseIf dtProcedimientoReferencia.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (objProcExternos Is Nothing) Then
            objProcExternos = PlanProcExternos.Instancia
        End If

        objProcExternos.dtProcedimientos = dtProcedimientoReferencia
        objProcExternos.Estado = "M"
        objProcExternos.ContraReferencia = True
        objProcExternos.DatosImpresionDiagnostica = dtDatosID
    End Sub

    '*************REF-CONT*************************
    'Private Sub dtgInfoID_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgInfoID.DataSourceChanged
    '    dtgInfoID.Height = dtgInfoID.ColumnHeadersHeight + (dtgInfoID.Rows.GetRowsHeight(DataGridViewElementStates.None))
    'End Sub
    '**********************************************

    Private Sub cbProcedimiento_ItemCambio(ByVal sender As Object) Handles cbProcedimiento.ItemCambio
        Me.tbCodTipoProc.Text = Me.tbCodProc.Text.Trim().Substring(0, 1)
        Me.tbDesTipoProc.Text = tbCodTipoProc.DescripcionCodigo
    End Sub


    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub op_TipoServ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles op_TipoServ.Click
        If Me.op_TipoServ.Checked = True Then
            Me.GroupPriori.Enabled = False
            Me.op_PrioNO.Checked = False
            Me.op_PrioSI.Checked = False
        Else
            Me.GroupPriori.Enabled = False
            Me.op_PrioNO.Checked = False
            Me.op_PrioSI.Checked = False
        End If
    End Sub

    Private Sub op_Electivo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles op_Electivo.Click
        If Me.op_Electivo.Checked = True Then
            Me.GroupPriori.Enabled = True
        Else
            Me.GroupPriori.Enabled = False
        End If
    End Sub

    Private Sub lblGuia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblGuia.Click

    End Sub

    Private Sub pnlContrarreferencia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlContrarreferencia.Click
        TxtScroll.Visible = True
        TxtScroll.Focus()
        TxtScroll.Visible = False
    End Sub

    Private Sub Panel5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel5.Click
        TxtScroll.Visible = True
        TxtScroll.Focus()
        TxtScroll.Visible = False
    End Sub

    Private Sub Panel3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel3.Click
        TxtScroll.Visible = True
        TxtScroll.Focus()
        TxtScroll.Visible = False
    End Sub
    Private Sub InhabilitarPeru()
        If objGeneral.Pais = "482" Then
            GroupServi.Visible = False
            GroupPriori.Visible = False
            tb_Guia.Enabled = False
        End If

    End Sub

    'Inicia: CCGUTIEREZ - OSI. 20/01/2020
    'Proyecto: Sophia - Codificacion
    'Cambio: Se agrega el evento para que se Limpie el control de las Particularidades 
    'si se modifica la descripcion de búsqueda
    Private Sub cbProcedimiento_TextUpdate(sender As Object, e As EventArgs) Handles cbProcedimiento.TextUpdate
        Me.tbCodProc.Text = ""
        Me.ctluProcExterno.Limpiar(True)
        Me.tbCantidad.Text = "1"
    End Sub

    Private Sub cbProcedimiento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProcedimiento.SelectedIndexChanged

    End Sub

    Private Sub ckBilateral_CheckedChanged(sender As Object, e As EventArgs) Handles ckBilateral.CheckedChanged

    End Sub
End Class
