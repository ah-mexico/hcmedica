<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ctlEvolucion
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctlEvolucion))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tmHoraEvolucion = New System.Windows.Forms.Timer(Me.components)
        Me.pnlContEvolucion = New System.Windows.Forms.Panel()
        Me.dvEvolucion = New System.Windows.Forms.DataGridView()
        Me.Sel_evo = New System.Windows.Forms.DataGridViewImageColumn()
        Me.fecha_evol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn61 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn62 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIPONOTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CIERREINTERCONSULTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn53 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn54 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIP_DOC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUM_DOC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn55 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn57 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn56 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HORA_EVOL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MIN_EVOL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOTAS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FEC_CON = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn52 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn67 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ORDEN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CONFIDENCIAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DIAGACTUAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SUBJETIVO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.INTERPPARACLIC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.INTERCONSULTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Imagenes = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.pnlEvolucion = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAnalisis = New System.Windows.Forms.TextBox()
        Me.lblAnalisis = New System.Windows.Forms.Label()
        Me.lbObjetivo = New System.Windows.Forms.Label()
        Me.lblSignosVitales = New System.Windows.Forms.Label()
        Me.lblTitEvolucion = New System.Windows.Forms.Label()
        Me.pnlTitDiaReg = New System.Windows.Forms.Panel()
        Me.BtnRptCuidadoPaliativo = New System.Windows.Forms.Button()
        Me.lblTipEvolucion = New System.Windows.Forms.Label()
        Me.grpGenPrg = New System.Windows.Forms.Panel()
        Me.grbCerrarInterconsulta = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCierrreInterconsulta = New System.Windows.Forms.TextBox()
        Me.rbtCierreIntConNo = New System.Windows.Forms.RadioButton()
        Me.rbtCierreIntConSI = New System.Windows.Forms.RadioButton()
        Me.grpPlaManPrg1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPlaManPrg1 = New System.Windows.Forms.TextBox()
        Me.rdPlaManPrg1No = New System.Windows.Forms.RadioButton()
        Me.rdPlaManPrg1Si = New System.Windows.Forms.RadioButton()
        Me.btGrabar = New System.Windows.Forms.Button()
        Me.txtTipoEvolucion = New System.Windows.Forms.TextBox()
        Me.btNuevo = New System.Windows.Forms.Button()
        Me.btImprimir = New System.Windows.Forms.Button()
        Me.tbPlanManejo = New System.Windows.Forms.TextBox()
        Me.lbPlanManejo = New System.Windows.Forms.Label()
        Me.tbSubjetivo = New System.Windows.Forms.TextBox()
        Me.tbParaclinicos = New System.Windows.Forms.TextBox()
        Me.lbSubjetivo = New System.Windows.Forms.Label()
        Me.lbParaclinicos = New System.Windows.Forms.Label()
        Me.tbObjetivo = New System.Windows.Forms.TextBox()
        Me.pnlDatosEF = New System.Windows.Forms.Panel()
        Me.txtDescEstadoConcienciaEF = New HistoriaClinica.TextBoxConFormato()
        Me.LbOblescdol = New System.Windows.Forms.Label()
        Me.LbOblfrecresp = New System.Windows.Forms.Label()
        Me.LbOblfrecard = New System.Windows.Forms.Label()
        Me.LbObltenardias = New System.Windows.Forms.Label()
        Me.LbObltenarsis = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtFrecuenciaRespiratoriaEF = New HistoriaClinica.TextBoxConFormato()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.Cmbanalogadedolor = New System.Windows.Forms.ComboBox()
        Me.Label114 = New System.Windows.Forms.Label()
        Me.Label113 = New System.Windows.Forms.Label()
        Me.Label112 = New System.Windows.Forms.Label()
        Me.txtSatOxi = New HistoriaClinica.TextBoxConFormato()
        Me.Label111 = New System.Windows.Forms.Label()
        Me.Label103 = New System.Windows.Forms.Label()
        Me.Label101 = New System.Windows.Forms.Label()
        Me.Label99 = New System.Windows.Forms.Label()
        Me.lblObligatorioEstado = New System.Windows.Forms.Label()
        Me.txtCodEstadoConcienciaEF = New HistoriaClinica.TextBoxConFormato()
        Me.txtTallaEF = New HistoriaClinica.TextBoxConFormato()
        Me.txtPesoEF = New HistoriaClinica.TextBoxConFormato()
        Me.txtTemperaturaEF = New HistoriaClinica.TextBoxConFormato()
        Me.txtFrecuenciaCardiacaEF = New HistoriaClinica.TextBoxConFormato()
        Me.txtDiastoleEF = New HistoriaClinica.TextBoxConFormato()
        Me.txtSistoleEF = New HistoriaClinica.TextBoxConFormato()
        Me.Label87 = New System.Windows.Forms.Label()
        Me.Label86 = New System.Windows.Forms.Label()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.txtDescValorIMCEF = New System.Windows.Forms.TextBox()
        Me.txtValorIMCEF = New System.Windows.Forms.TextBox()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.PnlNota = New System.Windows.Forms.Panel()
        Me.rbInterconNP = New System.Windows.Forms.RadioButton()
        Me.dgvInterconsultas = New System.Windows.Forms.DataGridView()
        Me.Sel = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.FechaInterconsulta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProInterconsulta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstadoInterconsulta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LOGIN_IC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COD_PRE_SGS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COD_SUCUR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIP_ADMISION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUM_ADM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ANO_ADM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NROORDEN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PROCEDIMIENTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANTIDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MEDICO_IC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ESPECIALIDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CEN_COSTO_ORIGEN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CEN_COSTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NROPEDIDO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FEC_CON_IC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OBS_IC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIPSERV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRIORI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GUIA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JUSTIFICACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ESTADOPLANEA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JUSTIFICACION_EXCEP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ENTIDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGO_RIS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGOLABORATORIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AUTOSISPRO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDESTADOINTERCONSULTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CONTESTAIC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RbEvolucion = New System.Windows.Forms.RadioButton()
        Me.rbIngreso = New System.Windows.Forms.RadioButton()
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbFecha = New System.Windows.Forms.Label()
        Me.mtFechaInicial = New System.Windows.Forms.MaskedTextBox()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn27 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn28 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn29 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn30 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn31 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn32 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn34 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn35 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn36 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn37 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn38 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn39 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn40 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn41 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn42 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn43 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn44 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn45 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn46 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn47 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn48 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ctlDiagnostico = New HistoriaClinica.ctlDiagnosticos()
        Me.pnlContEvolucion.SuspendLayout()
        CType(Me.dvEvolucion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEvolucion.SuspendLayout()
        Me.grpGenPrg.SuspendLayout()
        Me.grbCerrarInterconsulta.SuspendLayout()
        Me.grpPlaManPrg1.SuspendLayout()
        Me.pnlDatosEF.SuspendLayout()
        Me.PnlNota.SuspendLayout()
        CType(Me.dgvInterconsultas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlContenedor.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tmHoraEvolucion
        '
        Me.tmHoraEvolucion.Interval = 30000
        '
        'pnlContEvolucion
        '
        Me.pnlContEvolucion.Controls.Add(Me.dvEvolucion)
        Me.pnlContEvolucion.Controls.Add(Me.pnlEvolucion)
        Me.pnlContEvolucion.Controls.Add(Me.PnlNota)
        Me.pnlContEvolucion.Location = New System.Drawing.Point(0, 3)
        Me.pnlContEvolucion.Name = "pnlContEvolucion"
        Me.pnlContEvolucion.Size = New System.Drawing.Size(1081, 1585)
        Me.pnlContEvolucion.TabIndex = 53
        '
        'dvEvolucion
        '
        Me.dvEvolucion.AllowUserToAddRows = False
        Me.dvEvolucion.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(210, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dvEvolucion.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dvEvolucion.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dvEvolucion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dvEvolucion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dvEvolucion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Sel_evo, Me.fecha_evol, Me.DataGridViewTextBoxColumn61, Me.DataGridViewTextBoxColumn62, Me.TIPONOTA, Me.NOTA, Me.CIERREINTERCONSULTA, Me.DataGridViewTextBoxColumn53, Me.DataGridViewTextBoxColumn54, Me.TIP_DOC, Me.NUM_DOC, Me.DataGridViewTextBoxColumn55, Me.DataGridViewTextBoxColumn57, Me.DataGridViewTextBoxColumn56, Me.HORA_EVOL, Me.MIN_EVOL, Me.NOTAS, Me.FEC_CON, Me.DataGridViewTextBoxColumn52, Me.DataGridViewTextBoxColumn67, Me.ORDEN, Me.CONFIDENCIAL, Me.DIAGACTUAL, Me.SUBJETIVO, Me.INTERPPARACLIC, Me.INTERCONSULTA, Me.Imagenes})
        Me.dvEvolucion.GridColor = System.Drawing.Color.Gray
        Me.dvEvolucion.Location = New System.Drawing.Point(5, 1443)
        Me.dvEvolucion.Name = "dvEvolucion"
        Me.dvEvolucion.ReadOnly = True
        Me.dvEvolucion.RowHeadersWidth = 30
        Me.dvEvolucion.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dvEvolucion.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dvEvolucion.RowTemplate.Height = 20
        Me.dvEvolucion.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dvEvolucion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dvEvolucion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dvEvolucion.Size = New System.Drawing.Size(1064, 139)
        Me.dvEvolucion.TabIndex = 51
        '
        'Sel_evo
        '
        Me.Sel_evo.HeaderText = ""
        Me.Sel_evo.Image = Global.HistoriaClinica.My.Resources.Resources.bot_ayuda
        Me.Sel_evo.Name = "Sel_evo"
        Me.Sel_evo.ReadOnly = True
        Me.Sel_evo.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Sel_evo.Width = 40
        '
        'fecha_evol
        '
        Me.fecha_evol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.fecha_evol.DataPropertyName = "fecha_evol"
        Me.fecha_evol.HeaderText = "Fecha"
        Me.fecha_evol.Name = "fecha_evol"
        Me.fecha_evol.ReadOnly = True
        Me.fecha_evol.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.fecha_evol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.fecha_evol.Width = 50
        '
        'DataGridViewTextBoxColumn61
        '
        Me.DataGridViewTextBoxColumn61.DataPropertyName = "MEDICO"
        Me.DataGridViewTextBoxColumn61.HeaderText = "Médico"
        Me.DataGridViewTextBoxColumn61.Name = "DataGridViewTextBoxColumn61"
        Me.DataGridViewTextBoxColumn61.ReadOnly = True
        Me.DataGridViewTextBoxColumn61.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn61.Width = 195
        '
        'DataGridViewTextBoxColumn62
        '
        Me.DataGridViewTextBoxColumn62.DataPropertyName = "ESPECIALIDAD"
        Me.DataGridViewTextBoxColumn62.HeaderText = "Especialidad"
        Me.DataGridViewTextBoxColumn62.Name = "DataGridViewTextBoxColumn62"
        Me.DataGridViewTextBoxColumn62.ReadOnly = True
        Me.DataGridViewTextBoxColumn62.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'TIPONOTA
        '
        Me.TIPONOTA.DataPropertyName = "TIPONOTA"
        Me.TIPONOTA.HeaderText = "Tipo Nota"
        Me.TIPONOTA.Name = "TIPONOTA"
        Me.TIPONOTA.ReadOnly = True
        Me.TIPONOTA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'NOTA
        '
        Me.NOTA.DataPropertyName = "NOTA"
        Me.NOTA.HeaderText = "Nota"
        Me.NOTA.Name = "NOTA"
        Me.NOTA.ReadOnly = True
        Me.NOTA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.NOTA.Width = 300
        '
        'CIERREINTERCONSULTA
        '
        Me.CIERREINTERCONSULTA.DataPropertyName = "CIERREINTERCONSULTA"
        Me.CIERREINTERCONSULTA.HeaderText = "Cierre Interconsulta"
        Me.CIERREINTERCONSULTA.Name = "CIERREINTERCONSULTA"
        Me.CIERREINTERCONSULTA.ReadOnly = True
        Me.CIERREINTERCONSULTA.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CIERREINTERCONSULTA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn53
        '
        Me.DataGridViewTextBoxColumn53.DataPropertyName = "COD_PRE_SGS"
        Me.DataGridViewTextBoxColumn53.HeaderText = "COD_PRE_SGS"
        Me.DataGridViewTextBoxColumn53.Name = "DataGridViewTextBoxColumn53"
        Me.DataGridViewTextBoxColumn53.ReadOnly = True
        Me.DataGridViewTextBoxColumn53.Visible = False
        '
        'DataGridViewTextBoxColumn54
        '
        Me.DataGridViewTextBoxColumn54.DataPropertyName = "COD_SUCUR"
        Me.DataGridViewTextBoxColumn54.HeaderText = "COD_SUCUR"
        Me.DataGridViewTextBoxColumn54.Name = "DataGridViewTextBoxColumn54"
        Me.DataGridViewTextBoxColumn54.ReadOnly = True
        Me.DataGridViewTextBoxColumn54.Visible = False
        '
        'TIP_DOC
        '
        Me.TIP_DOC.DataPropertyName = "TIP_DOC"
        Me.TIP_DOC.HeaderText = "TIP_DOC"
        Me.TIP_DOC.Name = "TIP_DOC"
        Me.TIP_DOC.ReadOnly = True
        Me.TIP_DOC.Visible = False
        '
        'NUM_DOC
        '
        Me.NUM_DOC.DataPropertyName = "NUM_DOC"
        Me.NUM_DOC.HeaderText = "NUM_DOC"
        Me.NUM_DOC.Name = "NUM_DOC"
        Me.NUM_DOC.ReadOnly = True
        Me.NUM_DOC.Visible = False
        '
        'DataGridViewTextBoxColumn55
        '
        Me.DataGridViewTextBoxColumn55.DataPropertyName = "TIP_ADMISION"
        Me.DataGridViewTextBoxColumn55.HeaderText = "TIP_ADMISION"
        Me.DataGridViewTextBoxColumn55.Name = "DataGridViewTextBoxColumn55"
        Me.DataGridViewTextBoxColumn55.ReadOnly = True
        Me.DataGridViewTextBoxColumn55.Visible = False
        '
        'DataGridViewTextBoxColumn57
        '
        Me.DataGridViewTextBoxColumn57.DataPropertyName = "ANO_ADM"
        Me.DataGridViewTextBoxColumn57.HeaderText = "ANO_ADM"
        Me.DataGridViewTextBoxColumn57.Name = "DataGridViewTextBoxColumn57"
        Me.DataGridViewTextBoxColumn57.ReadOnly = True
        Me.DataGridViewTextBoxColumn57.Visible = False
        '
        'DataGridViewTextBoxColumn56
        '
        Me.DataGridViewTextBoxColumn56.DataPropertyName = "NUM_ADM"
        Me.DataGridViewTextBoxColumn56.HeaderText = "NUM_ADM"
        Me.DataGridViewTextBoxColumn56.Name = "DataGridViewTextBoxColumn56"
        Me.DataGridViewTextBoxColumn56.ReadOnly = True
        Me.DataGridViewTextBoxColumn56.Visible = False
        '
        'HORA_EVOL
        '
        Me.HORA_EVOL.DataPropertyName = "HORA_EVOL"
        Me.HORA_EVOL.HeaderText = "HORA_EVOL"
        Me.HORA_EVOL.Name = "HORA_EVOL"
        Me.HORA_EVOL.ReadOnly = True
        Me.HORA_EVOL.Visible = False
        '
        'MIN_EVOL
        '
        Me.MIN_EVOL.DataPropertyName = "MIN_EVOL"
        Me.MIN_EVOL.HeaderText = "MIN_EVOL"
        Me.MIN_EVOL.Name = "MIN_EVOL"
        Me.MIN_EVOL.ReadOnly = True
        Me.MIN_EVOL.Visible = False
        '
        'NOTAS
        '
        Me.NOTAS.DataPropertyName = "NOTAS"
        Me.NOTAS.HeaderText = "NOTAS"
        Me.NOTAS.Name = "NOTAS"
        Me.NOTAS.ReadOnly = True
        Me.NOTAS.Visible = False
        '
        'FEC_CON
        '
        Me.FEC_CON.DataPropertyName = "FEC_CON"
        Me.FEC_CON.HeaderText = "FEC_CON"
        Me.FEC_CON.Name = "FEC_CON"
        Me.FEC_CON.ReadOnly = True
        Me.FEC_CON.Visible = False
        '
        'DataGridViewTextBoxColumn52
        '
        Me.DataGridViewTextBoxColumn52.DataPropertyName = "LOGIN"
        Me.DataGridViewTextBoxColumn52.HeaderText = "LOGIN"
        Me.DataGridViewTextBoxColumn52.Name = "DataGridViewTextBoxColumn52"
        Me.DataGridViewTextBoxColumn52.ReadOnly = True
        Me.DataGridViewTextBoxColumn52.Visible = False
        '
        'DataGridViewTextBoxColumn67
        '
        Me.DataGridViewTextBoxColumn67.DataPropertyName = "OBS"
        Me.DataGridViewTextBoxColumn67.HeaderText = "OBS"
        Me.DataGridViewTextBoxColumn67.Name = "DataGridViewTextBoxColumn67"
        Me.DataGridViewTextBoxColumn67.ReadOnly = True
        Me.DataGridViewTextBoxColumn67.Visible = False
        '
        'ORDEN
        '
        Me.ORDEN.DataPropertyName = "ORDEN"
        Me.ORDEN.HeaderText = "ORDEN"
        Me.ORDEN.Name = "ORDEN"
        Me.ORDEN.ReadOnly = True
        Me.ORDEN.Visible = False
        '
        'CONFIDENCIAL
        '
        Me.CONFIDENCIAL.DataPropertyName = "CONFIDENCIAL"
        Me.CONFIDENCIAL.HeaderText = "CONFIDENCIAL"
        Me.CONFIDENCIAL.Name = "CONFIDENCIAL"
        Me.CONFIDENCIAL.ReadOnly = True
        Me.CONFIDENCIAL.Visible = False
        '
        'DIAGACTUAL
        '
        Me.DIAGACTUAL.DataPropertyName = "DIAGACTUAL"
        Me.DIAGACTUAL.HeaderText = "DIAGACTUAL"
        Me.DIAGACTUAL.Name = "DIAGACTUAL"
        Me.DIAGACTUAL.ReadOnly = True
        Me.DIAGACTUAL.Visible = False
        '
        'SUBJETIVO
        '
        Me.SUBJETIVO.DataPropertyName = "SUBJETIVO"
        Me.SUBJETIVO.HeaderText = "SUBJETIVO"
        Me.SUBJETIVO.Name = "SUBJETIVO"
        Me.SUBJETIVO.ReadOnly = True
        Me.SUBJETIVO.Visible = False
        '
        'INTERPPARACLIC
        '
        Me.INTERPPARACLIC.DataPropertyName = "INTERPPARACLIC"
        Me.INTERPPARACLIC.HeaderText = "INTERPPARACLIC"
        Me.INTERPPARACLIC.Name = "INTERPPARACLIC"
        Me.INTERPPARACLIC.ReadOnly = True
        Me.INTERPPARACLIC.Visible = False
        '
        'INTERCONSULTA
        '
        Me.INTERCONSULTA.DataPropertyName = "INTERCONSULTA"
        Me.INTERCONSULTA.HeaderText = "INTERCONSULTA"
        Me.INTERCONSULTA.Name = "INTERCONSULTA"
        Me.INTERCONSULTA.ReadOnly = True
        Me.INTERCONSULTA.Visible = False
        Me.INTERCONSULTA.Width = 555
        '
        'Imagenes
        '
        Me.Imagenes.DataPropertyName = "Imagenes"
        Me.Imagenes.HeaderText = "Imágenes"
        Me.Imagenes.Name = "Imagenes"
        Me.Imagenes.ReadOnly = True
        Me.Imagenes.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Imagenes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Imagenes.Width = 195
        '
        'pnlEvolucion
        '
        Me.pnlEvolucion.Controls.Add(Me.Label2)
        Me.pnlEvolucion.Controls.Add(Me.Label1)
        Me.pnlEvolucion.Controls.Add(Me.txtAnalisis)
        Me.pnlEvolucion.Controls.Add(Me.lblAnalisis)
        Me.pnlEvolucion.Controls.Add(Me.lbObjetivo)
        Me.pnlEvolucion.Controls.Add(Me.lblSignosVitales)
        Me.pnlEvolucion.Controls.Add(Me.lblTitEvolucion)
        Me.pnlEvolucion.Controls.Add(Me.pnlTitDiaReg)
        Me.pnlEvolucion.Controls.Add(Me.BtnRptCuidadoPaliativo)
        Me.pnlEvolucion.Controls.Add(Me.lblTipEvolucion)
        Me.pnlEvolucion.Controls.Add(Me.grpGenPrg)
        Me.pnlEvolucion.Controls.Add(Me.btGrabar)
        Me.pnlEvolucion.Controls.Add(Me.txtTipoEvolucion)
        Me.pnlEvolucion.Controls.Add(Me.btNuevo)
        Me.pnlEvolucion.Controls.Add(Me.btImprimir)
        Me.pnlEvolucion.Controls.Add(Me.tbPlanManejo)
        Me.pnlEvolucion.Controls.Add(Me.lbPlanManejo)
        Me.pnlEvolucion.Controls.Add(Me.tbSubjetivo)
        Me.pnlEvolucion.Controls.Add(Me.tbParaclinicos)
        Me.pnlEvolucion.Controls.Add(Me.lbSubjetivo)
        Me.pnlEvolucion.Controls.Add(Me.lbParaclinicos)
        Me.pnlEvolucion.Controls.Add(Me.tbObjetivo)
        Me.pnlEvolucion.Controls.Add(Me.pnlDatosEF)
        Me.pnlEvolucion.Location = New System.Drawing.Point(0, 135)
        Me.pnlEvolucion.Name = "pnlEvolucion"
        Me.pnlEvolucion.Size = New System.Drawing.Size(1069, 1282)
        Me.pnlEvolucion.TabIndex = 36
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Salmon
        Me.Label2.Location = New System.Drawing.Point(118, 1054)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(13, 15)
        Me.Label2.TabIndex = 69
        Me.Label2.Text = "*"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Salmon
        Me.Label1.Location = New System.Drawing.Point(82, 737)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(13, 15)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "*"
        '
        'txtAnalisis
        '
        Me.txtAnalisis.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAnalisis.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnalisis.Location = New System.Drawing.Point(2, 966)
        Me.txtAnalisis.MaxLength = 1500
        Me.txtAnalisis.Multiline = True
        Me.txtAnalisis.Name = "txtAnalisis"
        Me.txtAnalisis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAnalisis.Size = New System.Drawing.Size(1036, 78)
        Me.txtAnalisis.TabIndex = 41
        '
        'lblAnalisis
        '
        Me.lblAnalisis.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAnalisis.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblAnalisis.Location = New System.Drawing.Point(5, 942)
        Me.lblAnalisis.Name = "lblAnalisis"
        Me.lblAnalisis.Size = New System.Drawing.Size(287, 18)
        Me.lblAnalisis.TabIndex = 67
        Me.lblAnalisis.Text = "Análisis"
        Me.lblAnalisis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbObjetivo
        '
        Me.lbObjetivo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbObjetivo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lbObjetivo.Location = New System.Drawing.Point(5, 736)
        Me.lbObjetivo.Name = "lbObjetivo"
        Me.lbObjetivo.Size = New System.Drawing.Size(71, 18)
        Me.lbObjetivo.TabIndex = 39
        Me.lbObjetivo.Text = "Objetivo"
        Me.lbObjetivo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSignosVitales
        '
        Me.lblSignosVitales.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSignosVitales.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblSignosVitales.Location = New System.Drawing.Point(5, 524)
        Me.lblSignosVitales.Name = "lblSignosVitales"
        Me.lblSignosVitales.Size = New System.Drawing.Size(287, 18)
        Me.lblSignosVitales.TabIndex = 62
        Me.lblSignosVitales.Text = "Signos Vitales"
        Me.lblSignosVitales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTitEvolucion
        '
        Me.lblTitEvolucion.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitEvolucion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblTitEvolucion.Location = New System.Drawing.Point(5, 272)
        Me.lblTitEvolucion.Name = "lblTitEvolucion"
        Me.lblTitEvolucion.Size = New System.Drawing.Size(1033, 23)
        Me.lblTitEvolucion.TabIndex = 60
        Me.lblTitEvolucion.Text = "EVOLUCIÓN"
        Me.lblTitEvolucion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlTitDiaReg
        '
        Me.pnlTitDiaReg.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.pnlTitDiaReg.BackgroundImage = CType(resources.GetObject("pnlTitDiaReg.BackgroundImage"), System.Drawing.Image)
        Me.pnlTitDiaReg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pnlTitDiaReg.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitDiaReg.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitDiaReg.Name = "pnlTitDiaReg"
        Me.pnlTitDiaReg.Size = New System.Drawing.Size(1069, 32)
        Me.pnlTitDiaReg.TabIndex = 57
        '
        'BtnRptCuidadoPaliativo
        '
        Me.BtnRptCuidadoPaliativo.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.BtnRptCuidadoPaliativo.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_cuidadoPaliativo
        Me.BtnRptCuidadoPaliativo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnRptCuidadoPaliativo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnRptCuidadoPaliativo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRptCuidadoPaliativo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRptCuidadoPaliativo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.BtnRptCuidadoPaliativo.Location = New System.Drawing.Point(890, 1196)
        Me.BtnRptCuidadoPaliativo.Name = "BtnRptCuidadoPaliativo"
        Me.BtnRptCuidadoPaliativo.Size = New System.Drawing.Size(148, 22)
        Me.BtnRptCuidadoPaliativo.TabIndex = 49
        Me.BtnRptCuidadoPaliativo.Tag = "Para Ingresar Un nuevo registro de Evolucion"
        Me.BtnRptCuidadoPaliativo.UseVisualStyleBackColor = False
        '
        'lblTipEvolucion
        '
        Me.lblTipEvolucion.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipEvolucion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblTipEvolucion.Location = New System.Drawing.Point(5, 316)
        Me.lblTipEvolucion.Name = "lblTipEvolucion"
        Me.lblTipEvolucion.Size = New System.Drawing.Size(152, 18)
        Me.lblTipEvolucion.TabIndex = 50
        Me.lblTipEvolucion.Text = "Interconsulta"
        Me.lblTipEvolucion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTipEvolucion.Visible = False
        '
        'grpGenPrg
        '
        Me.grpGenPrg.Controls.Add(Me.grbCerrarInterconsulta)
        Me.grpGenPrg.Controls.Add(Me.grpPlaManPrg1)
        Me.grpGenPrg.Location = New System.Drawing.Point(3, 1154)
        Me.grpGenPrg.Name = "grpGenPrg"
        Me.grpGenPrg.Size = New System.Drawing.Size(881, 124)
        Me.grpGenPrg.TabIndex = 43
        '
        'grbCerrarInterconsulta
        '
        Me.grbCerrarInterconsulta.Controls.Add(Me.Label4)
        Me.grbCerrarInterconsulta.Controls.Add(Me.txtCierrreInterconsulta)
        Me.grbCerrarInterconsulta.Controls.Add(Me.rbtCierreIntConNo)
        Me.grbCerrarInterconsulta.Controls.Add(Me.rbtCierreIntConSI)
        Me.grbCerrarInterconsulta.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbCerrarInterconsulta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.grbCerrarInterconsulta.Location = New System.Drawing.Point(5, 62)
        Me.grbCerrarInterconsulta.Name = "grbCerrarInterconsulta"
        Me.grbCerrarInterconsulta.Size = New System.Drawing.Size(862, 58)
        Me.grbCerrarInterconsulta.TabIndex = 44
        Me.grbCerrarInterconsulta.TabStop = False
        Me.grbCerrarInterconsulta.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Salmon
        Me.Label4.Location = New System.Drawing.Point(791, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(13, 15)
        Me.Label4.TabIndex = 71
        Me.Label4.Text = "*"
        '
        'txtCierrreInterconsulta
        '
        Me.txtCierrreInterconsulta.Enabled = False
        Me.txtCierrreInterconsulta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.txtCierrreInterconsulta.Location = New System.Drawing.Point(5, 12)
        Me.txtCierrreInterconsulta.Multiline = True
        Me.txtCierrreInterconsulta.Name = "txtCierrreInterconsulta"
        Me.txtCierrreInterconsulta.Size = New System.Drawing.Size(780, 38)
        Me.txtCierrreInterconsulta.TabIndex = 40
        Me.txtCierrreInterconsulta.Text = "¿Desea cerrar la interconsulta?"
        '
        'rbtCierreIntConNo
        '
        Me.rbtCierreIntConNo.AutoSize = True
        Me.rbtCierreIntConNo.Location = New System.Drawing.Point(811, 30)
        Me.rbtCierreIntConNo.Name = "rbtCierreIntConNo"
        Me.rbtCierreIntConNo.Size = New System.Drawing.Size(45, 20)
        Me.rbtCierreIntConNo.TabIndex = 47
        Me.rbtCierreIntConNo.TabStop = True
        Me.rbtCierreIntConNo.Text = "No"
        Me.rbtCierreIntConNo.UseVisualStyleBackColor = True
        '
        'rbtCierreIntConSI
        '
        Me.rbtCierreIntConSI.AutoSize = True
        Me.rbtCierreIntConSI.Location = New System.Drawing.Point(811, 13)
        Me.rbtCierreIntConSI.Name = "rbtCierreIntConSI"
        Me.rbtCierreIntConSI.Size = New System.Drawing.Size(39, 20)
        Me.rbtCierreIntConSI.TabIndex = 46
        Me.rbtCierreIntConSI.TabStop = True
        Me.rbtCierreIntConSI.Text = "Si"
        Me.rbtCierreIntConSI.UseVisualStyleBackColor = True
        '
        'grpPlaManPrg1
        '
        Me.grpPlaManPrg1.Controls.Add(Me.Label3)
        Me.grpPlaManPrg1.Controls.Add(Me.txtPlaManPrg1)
        Me.grpPlaManPrg1.Controls.Add(Me.rdPlaManPrg1No)
        Me.grpPlaManPrg1.Controls.Add(Me.rdPlaManPrg1Si)
        Me.grpPlaManPrg1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpPlaManPrg1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.grpPlaManPrg1.Location = New System.Drawing.Point(5, 3)
        Me.grpPlaManPrg1.Name = "grpPlaManPrg1"
        Me.grpPlaManPrg1.Size = New System.Drawing.Size(862, 58)
        Me.grpPlaManPrg1.TabIndex = 43
        Me.grpPlaManPrg1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Salmon
        Me.Label3.Location = New System.Drawing.Point(791, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(13, 15)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "*"
        '
        'txtPlaManPrg1
        '
        Me.txtPlaManPrg1.Enabled = False
        Me.txtPlaManPrg1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.txtPlaManPrg1.Location = New System.Drawing.Point(5, 15)
        Me.txtPlaManPrg1.Multiline = True
        Me.txtPlaManPrg1.Name = "txtPlaManPrg1"
        Me.txtPlaManPrg1.Size = New System.Drawing.Size(780, 38)
        Me.txtPlaManPrg1.TabIndex = 39
        Me.txtPlaManPrg1.Text = "¿Se explicó el plan de manejo al paciente y a sus familiares, asegurándose el ent" &
    "endimiento de este?."
        '
        'rdPlaManPrg1No
        '
        Me.rdPlaManPrg1No.AutoSize = True
        Me.rdPlaManPrg1No.Location = New System.Drawing.Point(811, 33)
        Me.rdPlaManPrg1No.Name = "rdPlaManPrg1No"
        Me.rdPlaManPrg1No.Size = New System.Drawing.Size(45, 20)
        Me.rdPlaManPrg1No.TabIndex = 45
        Me.rdPlaManPrg1No.TabStop = True
        Me.rdPlaManPrg1No.Text = "No"
        Me.rdPlaManPrg1No.UseVisualStyleBackColor = True
        '
        'rdPlaManPrg1Si
        '
        Me.rdPlaManPrg1Si.AutoSize = True
        Me.rdPlaManPrg1Si.Location = New System.Drawing.Point(811, 14)
        Me.rdPlaManPrg1Si.Name = "rdPlaManPrg1Si"
        Me.rdPlaManPrg1Si.Size = New System.Drawing.Size(39, 20)
        Me.rdPlaManPrg1Si.TabIndex = 44
        Me.rdPlaManPrg1Si.TabStop = True
        Me.rdPlaManPrg1Si.Text = "Si"
        Me.rdPlaManPrg1Si.UseVisualStyleBackColor = True
        '
        'btGrabar
        '
        Me.btGrabar.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btGrabar.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_guardarMostrar
        Me.btGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btGrabar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btGrabar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btGrabar.Location = New System.Drawing.Point(890, 1168)
        Me.btGrabar.Name = "btGrabar"
        Me.btGrabar.Size = New System.Drawing.Size(148, 22)
        Me.btGrabar.TabIndex = 48
        Me.btGrabar.UseVisualStyleBackColor = False
        '
        'txtTipoEvolucion
        '
        Me.txtTipoEvolucion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTipoEvolucion.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoEvolucion.Location = New System.Drawing.Point(2, 339)
        Me.txtTipoEvolucion.MaxLength = 5000
        Me.txtTipoEvolucion.Multiline = True
        Me.txtTipoEvolucion.Name = "txtTipoEvolucion"
        Me.txtTipoEvolucion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTipoEvolucion.Size = New System.Drawing.Size(1036, 78)
        Me.txtTipoEvolucion.TabIndex = 34
        Me.txtTipoEvolucion.Visible = False
        '
        'btNuevo
        '
        Me.btNuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btNuevo.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_nuevo
        Me.btNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btNuevo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btNuevo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btNuevo.Location = New System.Drawing.Point(890, 1224)
        Me.btNuevo.Name = "btNuevo"
        Me.btNuevo.Size = New System.Drawing.Size(148, 22)
        Me.btNuevo.TabIndex = 50
        Me.btNuevo.Tag = "Para Ingresar Un nuevo registro de Evolucion"
        Me.btNuevo.UseVisualStyleBackColor = False
        Me.btNuevo.Visible = False
        '
        'btImprimir
        '
        Me.btImprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btImprimir.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_reimprimir
        Me.btImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btImprimir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btImprimir.Location = New System.Drawing.Point(890, 1252)
        Me.btImprimir.Name = "btImprimir"
        Me.btImprimir.Size = New System.Drawing.Size(148, 22)
        Me.btImprimir.TabIndex = 51
        Me.btImprimir.UseVisualStyleBackColor = False
        Me.btImprimir.Visible = False
        '
        'tbPlanManejo
        '
        Me.tbPlanManejo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbPlanManejo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPlanManejo.Location = New System.Drawing.Point(2, 1074)
        Me.tbPlanManejo.MaxLength = 1500
        Me.tbPlanManejo.Multiline = True
        Me.tbPlanManejo.Name = "tbPlanManejo"
        Me.tbPlanManejo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbPlanManejo.Size = New System.Drawing.Size(1036, 78)
        Me.tbPlanManejo.TabIndex = 42
        '
        'lbPlanManejo
        '
        Me.lbPlanManejo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPlanManejo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lbPlanManejo.Location = New System.Drawing.Point(5, 1053)
        Me.lbPlanManejo.Name = "lbPlanManejo"
        Me.lbPlanManejo.Size = New System.Drawing.Size(119, 18)
        Me.lbPlanManejo.TabIndex = 41
        Me.lbPlanManejo.Text = "Plan de Manejo"
        Me.lbPlanManejo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbSubjetivo
        '
        Me.tbSubjetivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbSubjetivo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSubjetivo.Location = New System.Drawing.Point(2, 443)
        Me.tbSubjetivo.MaxLength = 500
        Me.tbSubjetivo.Multiline = True
        Me.tbSubjetivo.Name = "tbSubjetivo"
        Me.tbSubjetivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbSubjetivo.Size = New System.Drawing.Size(1036, 78)
        Me.tbSubjetivo.TabIndex = 36
        '
        'tbParaclinicos
        '
        Me.tbParaclinicos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbParaclinicos.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbParaclinicos.Location = New System.Drawing.Point(2, 859)
        Me.tbParaclinicos.MaxLength = 3000
        Me.tbParaclinicos.Multiline = True
        Me.tbParaclinicos.Name = "tbParaclinicos"
        Me.tbParaclinicos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbParaclinicos.Size = New System.Drawing.Size(1036, 78)
        Me.tbParaclinicos.TabIndex = 40
        '
        'lbSubjetivo
        '
        Me.lbSubjetivo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSubjetivo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lbSubjetivo.Location = New System.Drawing.Point(5, 422)
        Me.lbSubjetivo.Name = "lbSubjetivo"
        Me.lbSubjetivo.Size = New System.Drawing.Size(287, 18)
        Me.lbSubjetivo.TabIndex = 35
        Me.lbSubjetivo.Text = "Subjetivo"
        Me.lbSubjetivo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbParaclinicos
        '
        Me.lbParaclinicos.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbParaclinicos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lbParaclinicos.Location = New System.Drawing.Point(5, 838)
        Me.lbParaclinicos.Name = "lbParaclinicos"
        Me.lbParaclinicos.Size = New System.Drawing.Size(287, 18)
        Me.lbParaclinicos.TabIndex = 37
        Me.lbParaclinicos.Text = "Interpretación  Paraclínicos"
        Me.lbParaclinicos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbObjetivo
        '
        Me.tbObjetivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbObjetivo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbObjetivo.Location = New System.Drawing.Point(2, 757)
        Me.tbObjetivo.MaxLength = 2000
        Me.tbObjetivo.Multiline = True
        Me.tbObjetivo.Name = "tbObjetivo"
        Me.tbObjetivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbObjetivo.Size = New System.Drawing.Size(1036, 78)
        Me.tbObjetivo.TabIndex = 39
        '
        'pnlDatosEF
        '
        Me.pnlDatosEF.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.pnlDatosEF.Controls.Add(Me.txtDescEstadoConcienciaEF)
        Me.pnlDatosEF.Controls.Add(Me.LbOblescdol)
        Me.pnlDatosEF.Controls.Add(Me.LbOblfrecresp)
        Me.pnlDatosEF.Controls.Add(Me.LbOblfrecard)
        Me.pnlDatosEF.Controls.Add(Me.LbObltenardias)
        Me.pnlDatosEF.Controls.Add(Me.LbObltenarsis)
        Me.pnlDatosEF.Controls.Add(Me.Label22)
        Me.pnlDatosEF.Controls.Add(Me.txtFrecuenciaRespiratoriaEF)
        Me.pnlDatosEF.Controls.Add(Me.Label82)
        Me.pnlDatosEF.Controls.Add(Me.Cmbanalogadedolor)
        Me.pnlDatosEF.Controls.Add(Me.Label114)
        Me.pnlDatosEF.Controls.Add(Me.Label113)
        Me.pnlDatosEF.Controls.Add(Me.Label112)
        Me.pnlDatosEF.Controls.Add(Me.txtSatOxi)
        Me.pnlDatosEF.Controls.Add(Me.Label111)
        Me.pnlDatosEF.Controls.Add(Me.Label103)
        Me.pnlDatosEF.Controls.Add(Me.Label101)
        Me.pnlDatosEF.Controls.Add(Me.Label99)
        Me.pnlDatosEF.Controls.Add(Me.lblObligatorioEstado)
        Me.pnlDatosEF.Controls.Add(Me.txtCodEstadoConcienciaEF)
        Me.pnlDatosEF.Controls.Add(Me.txtTallaEF)
        Me.pnlDatosEF.Controls.Add(Me.txtPesoEF)
        Me.pnlDatosEF.Controls.Add(Me.txtTemperaturaEF)
        Me.pnlDatosEF.Controls.Add(Me.txtFrecuenciaCardiacaEF)
        Me.pnlDatosEF.Controls.Add(Me.txtDiastoleEF)
        Me.pnlDatosEF.Controls.Add(Me.txtSistoleEF)
        Me.pnlDatosEF.Controls.Add(Me.Label87)
        Me.pnlDatosEF.Controls.Add(Me.Label86)
        Me.pnlDatosEF.Controls.Add(Me.Label72)
        Me.pnlDatosEF.Controls.Add(Me.Label81)
        Me.pnlDatosEF.Controls.Add(Me.Label80)
        Me.pnlDatosEF.Controls.Add(Me.Label79)
        Me.pnlDatosEF.Controls.Add(Me.Label71)
        Me.pnlDatosEF.Controls.Add(Me.Label77)
        Me.pnlDatosEF.Controls.Add(Me.Label75)
        Me.pnlDatosEF.Controls.Add(Me.txtDescValorIMCEF)
        Me.pnlDatosEF.Controls.Add(Me.txtValorIMCEF)
        Me.pnlDatosEF.Controls.Add(Me.Label74)
        Me.pnlDatosEF.Controls.Add(Me.Label73)
        Me.pnlDatosEF.Location = New System.Drawing.Point(2, 545)
        Me.pnlDatosEF.Name = "pnlDatosEF"
        Me.pnlDatosEF.Size = New System.Drawing.Size(1036, 188)
        Me.pnlDatosEF.TabIndex = 37
        '
        'txtDescEstadoConcienciaEF
        '
        Me.txtDescEstadoConcienciaEF.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtDescEstadoConcienciaEF.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtDescEstadoConcienciaEF.BackColor = System.Drawing.SystemColors.Window
        Me.txtDescEstadoConcienciaEF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescEstadoConcienciaEF.ControlComboEnlace = Nothing
        Me.txtDescEstadoConcienciaEF.ControlTextoEnlace = Nothing
        Me.txtDescEstadoConcienciaEF.DatoRelacionado = Nothing
        Me.txtDescEstadoConcienciaEF.Decimals = CType(2, Byte)
        Me.txtDescEstadoConcienciaEF.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtDescEstadoConcienciaEF.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescEstadoConcienciaEF.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.txtDescEstadoConcienciaEF.Location = New System.Drawing.Point(821, 91)
        Me.txtDescEstadoConcienciaEF.MaxLength = 30
        Me.txtDescEstadoConcienciaEF.Name = "txtDescEstadoConcienciaEF"
        Me.txtDescEstadoConcienciaEF.NombreCampoBuscado = Nothing
        Me.txtDescEstadoConcienciaEF.NombreCampoBusqueda = Nothing
        Me.txtDescEstadoConcienciaEF.NombreCampoDatos = Nothing
        Me.txtDescEstadoConcienciaEF.Obligatorio = True
        Me.txtDescEstadoConcienciaEF.OrigenDeDatos = Nothing
        Me.txtDescEstadoConcienciaEF.PermitirValorCero = False
        Me.txtDescEstadoConcienciaEF.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtDescEstadoConcienciaEF.ReadOnly = True
        Me.txtDescEstadoConcienciaEF.Size = New System.Drawing.Size(170, 22)
        Me.txtDescEstadoConcienciaEF.TabIndex = 13
        Me.txtDescEstadoConcienciaEF.TipoControl = HistoriaClinica.tbTipoControl.ListaAutoComplete
        Me.txtDescEstadoConcienciaEF.UserValues = Nothing
        Me.txtDescEstadoConcienciaEF.ValorMaximo = CType(0, Long)
        Me.txtDescEstadoConcienciaEF.ValorMinimo = CType(0, Long)
        '
        'LbOblescdol
        '
        Me.LbOblescdol.AutoSize = True
        Me.LbOblescdol.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbOblescdol.ForeColor = System.Drawing.Color.Salmon
        Me.LbOblescdol.Location = New System.Drawing.Point(305, 69)
        Me.LbOblescdol.Name = "LbOblescdol"
        Me.LbOblescdol.Size = New System.Drawing.Size(13, 15)
        Me.LbOblescdol.TabIndex = 27
        Me.LbOblescdol.Text = "*"
        '
        'LbOblfrecresp
        '
        Me.LbOblfrecresp.AutoSize = True
        Me.LbOblfrecresp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbOblfrecresp.ForeColor = System.Drawing.Color.Salmon
        Me.LbOblfrecresp.Location = New System.Drawing.Point(736, 3)
        Me.LbOblfrecresp.Name = "LbOblfrecresp"
        Me.LbOblfrecresp.Size = New System.Drawing.Size(13, 15)
        Me.LbOblfrecresp.TabIndex = 15
        Me.LbOblfrecresp.Text = "*"
        '
        'LbOblfrecard
        '
        Me.LbOblfrecard.AutoSize = True
        Me.LbOblfrecard.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbOblfrecard.ForeColor = System.Drawing.Color.Salmon
        Me.LbOblfrecard.Location = New System.Drawing.Point(521, 3)
        Me.LbOblfrecard.Name = "LbOblfrecard"
        Me.LbOblfrecard.Size = New System.Drawing.Size(13, 15)
        Me.LbOblfrecard.TabIndex = 11
        Me.LbOblfrecard.Text = "*"
        '
        'LbObltenardias
        '
        Me.LbObltenardias.AutoSize = True
        Me.LbObltenardias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbObltenardias.ForeColor = System.Drawing.Color.Salmon
        Me.LbObltenardias.Location = New System.Drawing.Point(313, 17)
        Me.LbObltenardias.Name = "LbObltenardias"
        Me.LbObltenardias.Size = New System.Drawing.Size(13, 15)
        Me.LbObltenardias.TabIndex = 7
        Me.LbObltenardias.Text = "*"
        '
        'LbObltenarsis
        '
        Me.LbObltenarsis.AutoSize = True
        Me.LbObltenarsis.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbObltenarsis.ForeColor = System.Drawing.Color.Salmon
        Me.LbObltenarsis.Location = New System.Drawing.Point(142, 17)
        Me.LbObltenarsis.Name = "LbObltenarsis"
        Me.LbObltenarsis.Size = New System.Drawing.Size(13, 15)
        Me.LbObltenarsis.TabIndex = 3
        Me.LbObltenarsis.Text = "*"
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(635, 41)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(94, 18)
        Me.Label22.TabIndex = 14
        Me.Label22.Text = "Por Minuto"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFrecuenciaRespiratoriaEF
        '
        Me.txtFrecuenciaRespiratoriaEF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFrecuenciaRespiratoriaEF.ControlComboEnlace = Nothing
        Me.txtFrecuenciaRespiratoriaEF.ControlTextoEnlace = Nothing
        Me.txtFrecuenciaRespiratoriaEF.DatoRelacionado = Nothing
        Me.txtFrecuenciaRespiratoriaEF.Decimals = CType(0, Byte)
        Me.txtFrecuenciaRespiratoriaEF.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtFrecuenciaRespiratoriaEF.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFrecuenciaRespiratoriaEF.Format = HistoriaClinica.tbFormats.NúmericoEnteroSinSigno
        Me.txtFrecuenciaRespiratoriaEF.Location = New System.Drawing.Point(558, 37)
        Me.txtFrecuenciaRespiratoriaEF.MaxLength = 2
        Me.txtFrecuenciaRespiratoriaEF.Name = "txtFrecuenciaRespiratoriaEF"
        Me.txtFrecuenciaRespiratoriaEF.NombreCampoBuscado = Nothing
        Me.txtFrecuenciaRespiratoriaEF.NombreCampoBusqueda = Nothing
        Me.txtFrecuenciaRespiratoriaEF.NombreCampoDatos = Nothing
        Me.txtFrecuenciaRespiratoriaEF.Obligatorio = False
        Me.txtFrecuenciaRespiratoriaEF.OrigenDeDatos = Nothing
        Me.txtFrecuenciaRespiratoriaEF.PermitirValorCero = False
        Me.txtFrecuenciaRespiratoriaEF.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtFrecuenciaRespiratoriaEF.Size = New System.Drawing.Size(57, 22)
        Me.txtFrecuenciaRespiratoriaEF.TabIndex = 4
        Me.txtFrecuenciaRespiratoriaEF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtFrecuenciaRespiratoriaEF.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtFrecuenciaRespiratoriaEF.UserValues = Nothing
        Me.txtFrecuenciaRespiratoriaEF.ValorMaximo = CType(100, Long)
        Me.txtFrecuenciaRespiratoriaEF.ValorMinimo = CType(0, Long)
        '
        'Label82
        '
        Me.Label82.BackColor = System.Drawing.Color.Transparent
        Me.Label82.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label82.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label82.Location = New System.Drawing.Point(551, 3)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(169, 18)
        Me.Label82.TabIndex = 12
        Me.Label82.Text = "Frecuencia Respiratoria"
        Me.Label82.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Cmbanalogadedolor
        '
        Me.Cmbanalogadedolor.AutoCompleteCustomSource.AddRange(New String() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.Cmbanalogadedolor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cmbanalogadedolor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cmbanalogadedolor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbanalogadedolor.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Cmbanalogadedolor.FormattingEnabled = True
        Me.Cmbanalogadedolor.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.Cmbanalogadedolor.Location = New System.Drawing.Point(180, 91)
        Me.Cmbanalogadedolor.MaxDropDownItems = 11
        Me.Cmbanalogadedolor.MaxLength = 2
        Me.Cmbanalogadedolor.Name = "Cmbanalogadedolor"
        Me.Cmbanalogadedolor.Size = New System.Drawing.Size(58, 22)
        Me.Cmbanalogadedolor.TabIndex = 7
        '
        'Label114
        '
        Me.Label114.BackColor = System.Drawing.Color.Transparent
        Me.Label114.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label114.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label114.Location = New System.Drawing.Point(246, 96)
        Me.Label114.Name = "Label114"
        Me.Label114.Size = New System.Drawing.Size(49, 18)
        Me.Label114.TabIndex = 26
        Me.Label114.Text = "/10"
        Me.Label114.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label113
        '
        Me.Label113.BackColor = System.Drawing.Color.Transparent
        Me.Label113.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label113.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label113.Location = New System.Drawing.Point(180, 69)
        Me.Label113.Name = "Label113"
        Me.Label113.Size = New System.Drawing.Size(115, 18)
        Me.Label113.TabIndex = 24
        Me.Label113.Text = "Escala de dolor"
        Me.Label113.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label112
        '
        Me.Label112.BackColor = System.Drawing.Color.Transparent
        Me.Label112.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label112.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label112.Location = New System.Drawing.Point(862, 41)
        Me.Label112.Name = "Label112"
        Me.Label112.Size = New System.Drawing.Size(34, 18)
        Me.Label112.TabIndex = 18
        Me.Label112.Text = "%"
        Me.Label112.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSatOxi
        '
        Me.txtSatOxi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSatOxi.ControlComboEnlace = Nothing
        Me.txtSatOxi.ControlTextoEnlace = Nothing
        Me.txtSatOxi.DatoRelacionado = Nothing
        Me.txtSatOxi.Decimals = CType(3, Byte)
        Me.txtSatOxi.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtSatOxi.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSatOxi.Format = HistoriaClinica.tbFormats.NúmericoEnteroSinSigno
        Me.txtSatOxi.Location = New System.Drawing.Point(774, 37)
        Me.txtSatOxi.MaxLength = 6
        Me.txtSatOxi.Name = "txtSatOxi"
        Me.txtSatOxi.NombreCampoBuscado = Nothing
        Me.txtSatOxi.NombreCampoBusqueda = Nothing
        Me.txtSatOxi.NombreCampoDatos = Nothing
        Me.txtSatOxi.Obligatorio = False
        Me.txtSatOxi.OrigenDeDatos = Nothing
        Me.txtSatOxi.PermitirValorCero = False
        Me.txtSatOxi.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtSatOxi.Size = New System.Drawing.Size(57, 22)
        Me.txtSatOxi.TabIndex = 5
        Me.txtSatOxi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtSatOxi.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtSatOxi.UserValues = Nothing
        Me.txtSatOxi.ValorMaximo = CType(100, Long)
        Me.txtSatOxi.ValorMinimo = CType(0, Long)
        '
        'Label111
        '
        Me.Label111.BackColor = System.Drawing.Color.Transparent
        Me.Label111.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label111.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label111.Location = New System.Drawing.Point(774, 3)
        Me.Label111.Name = "Label111"
        Me.Label111.Size = New System.Drawing.Size(151, 18)
        Me.Label111.TabIndex = 16
        Me.Label111.Text = "Saturación Oxígeno"
        Me.Label111.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label103
        '
        Me.Label103.BackColor = System.Drawing.Color.Transparent
        Me.Label103.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label103.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label103.Location = New System.Drawing.Point(434, 41)
        Me.Label103.Name = "Label103"
        Me.Label103.Size = New System.Drawing.Size(94, 18)
        Me.Label103.TabIndex = 10
        Me.Label103.Text = "Por Minuto"
        Me.Label103.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label101
        '
        Me.Label101.BackColor = System.Drawing.Color.Transparent
        Me.Label101.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label101.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label101.Location = New System.Drawing.Point(80, 41)
        Me.Label101.Name = "Label101"
        Me.Label101.Size = New System.Drawing.Size(49, 18)
        Me.Label101.TabIndex = 2
        Me.Label101.Text = "mmHg"
        Me.Label101.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label99
        '
        Me.Label99.BackColor = System.Drawing.Color.Transparent
        Me.Label99.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label99.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label99.Location = New System.Drawing.Point(253, 41)
        Me.Label99.Name = "Label99"
        Me.Label99.Size = New System.Drawing.Size(49, 18)
        Me.Label99.TabIndex = 6
        Me.Label99.Text = "mmHg"
        Me.Label99.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblObligatorioEstado
        '
        Me.lblObligatorioEstado.AutoSize = True
        Me.lblObligatorioEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblObligatorioEstado.ForeColor = System.Drawing.Color.Salmon
        Me.lblObligatorioEstado.Location = New System.Drawing.Point(938, 70)
        Me.lblObligatorioEstado.Name = "lblObligatorioEstado"
        Me.lblObligatorioEstado.Size = New System.Drawing.Size(13, 15)
        Me.lblObligatorioEstado.TabIndex = 44
        Me.lblObligatorioEstado.Text = "*"
        '
        'txtCodEstadoConcienciaEF
        '
        Me.txtCodEstadoConcienciaEF.BackColor = System.Drawing.SystemColors.Window
        Me.txtCodEstadoConcienciaEF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodEstadoConcienciaEF.ControlComboEnlace = Nothing
        Me.txtCodEstadoConcienciaEF.ControlTextoEnlace = Nothing
        Me.txtCodEstadoConcienciaEF.DatoRelacionado = Nothing
        Me.txtCodEstadoConcienciaEF.Decimals = CType(2, Byte)
        Me.txtCodEstadoConcienciaEF.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtCodEstadoConcienciaEF.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodEstadoConcienciaEF.Format = HistoriaClinica.tbFormats.NúmericoEnteroSinSigno
        Me.txtCodEstadoConcienciaEF.Location = New System.Drawing.Point(774, 91)
        Me.txtCodEstadoConcienciaEF.MaxLength = 1
        Me.txtCodEstadoConcienciaEF.Name = "txtCodEstadoConcienciaEF"
        Me.txtCodEstadoConcienciaEF.NombreCampoBuscado = Nothing
        Me.txtCodEstadoConcienciaEF.NombreCampoBusqueda = Nothing
        Me.txtCodEstadoConcienciaEF.NombreCampoDatos = Nothing
        Me.txtCodEstadoConcienciaEF.Obligatorio = True
        Me.txtCodEstadoConcienciaEF.OrigenDeDatos = Nothing
        Me.txtCodEstadoConcienciaEF.PermitirValorCero = False
        Me.txtCodEstadoConcienciaEF.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtCodEstadoConcienciaEF.Size = New System.Drawing.Size(46, 22)
        Me.txtCodEstadoConcienciaEF.TabIndex = 12
        Me.txtCodEstadoConcienciaEF.TipoControl = HistoriaClinica.tbTipoControl.CodigoBusqueda
        Me.txtCodEstadoConcienciaEF.UserValues = Nothing
        Me.txtCodEstadoConcienciaEF.ValorMaximo = CType(5, Long)
        Me.txtCodEstadoConcienciaEF.ValorMinimo = CType(1, Long)
        '
        'txtTallaEF
        '
        Me.txtTallaEF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTallaEF.ControlComboEnlace = Nothing
        Me.txtTallaEF.ControlTextoEnlace = Nothing
        Me.txtTallaEF.DatoRelacionado = Nothing
        Me.txtTallaEF.Decimals = CType(2, Byte)
        Me.txtTallaEF.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtTallaEF.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTallaEF.Format = HistoriaClinica.tbFormats.NúmericoDecimalFijoSinSigno
        Me.txtTallaEF.Location = New System.Drawing.Point(453, 92)
        Me.txtTallaEF.MaxLength = 4
        Me.txtTallaEF.Name = "txtTallaEF"
        Me.txtTallaEF.NombreCampoBuscado = Nothing
        Me.txtTallaEF.NombreCampoBusqueda = Nothing
        Me.txtTallaEF.NombreCampoDatos = Nothing
        Me.txtTallaEF.Obligatorio = False
        Me.txtTallaEF.OrigenDeDatos = Nothing
        Me.txtTallaEF.PermitirValorCero = False
        Me.txtTallaEF.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtTallaEF.Size = New System.Drawing.Size(50, 22)
        Me.txtTallaEF.TabIndex = 9
        Me.txtTallaEF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtTallaEF.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtTallaEF.UserValues = Nothing
        Me.txtTallaEF.ValorMaximo = CType(3, Long)
        Me.txtTallaEF.ValorMinimo = CType(0, Long)
        '
        'txtPesoEF
        '
        Me.txtPesoEF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPesoEF.ControlComboEnlace = Nothing
        Me.txtPesoEF.ControlTextoEnlace = Nothing
        Me.txtPesoEF.DatoRelacionado = Nothing
        Me.txtPesoEF.Decimals = CType(2, Byte)
        Me.txtPesoEF.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtPesoEF.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPesoEF.Format = HistoriaClinica.tbFormats.NúmericoDecimalFijoConSigno
        Me.txtPesoEF.Location = New System.Drawing.Point(343, 92)
        Me.txtPesoEF.MaxLength = 6
        Me.txtPesoEF.Name = "txtPesoEF"
        Me.txtPesoEF.NombreCampoBuscado = Nothing
        Me.txtPesoEF.NombreCampoBusqueda = Nothing
        Me.txtPesoEF.NombreCampoDatos = Nothing
        Me.txtPesoEF.Obligatorio = False
        Me.txtPesoEF.OrigenDeDatos = Nothing
        Me.txtPesoEF.PermitirValorCero = False
        Me.txtPesoEF.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtPesoEF.Size = New System.Drawing.Size(64, 22)
        Me.txtPesoEF.TabIndex = 8
        Me.txtPesoEF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPesoEF.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtPesoEF.UserValues = Nothing
        Me.txtPesoEF.ValorMaximo = CType(500, Long)
        Me.txtPesoEF.ValorMinimo = CType(0, Long)
        '
        'txtTemperaturaEF
        '
        Me.txtTemperaturaEF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTemperaturaEF.ControlComboEnlace = Nothing
        Me.txtTemperaturaEF.ControlTextoEnlace = Nothing
        Me.txtTemperaturaEF.DatoRelacionado = Nothing
        Me.txtTemperaturaEF.Decimals = CType(2, Byte)
        Me.txtTemperaturaEF.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtTemperaturaEF.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTemperaturaEF.Format = HistoriaClinica.tbFormats.NúmericoDecimalFijoSinSigno
        Me.txtTemperaturaEF.Location = New System.Drawing.Point(17, 92)
        Me.txtTemperaturaEF.MaxLength = 4
        Me.txtTemperaturaEF.Name = "txtTemperaturaEF"
        Me.txtTemperaturaEF.NombreCampoBuscado = Nothing
        Me.txtTemperaturaEF.NombreCampoBusqueda = Nothing
        Me.txtTemperaturaEF.NombreCampoDatos = Nothing
        Me.txtTemperaturaEF.Obligatorio = False
        Me.txtTemperaturaEF.OrigenDeDatos = Nothing
        Me.txtTemperaturaEF.PermitirValorCero = False
        Me.txtTemperaturaEF.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtTemperaturaEF.Size = New System.Drawing.Size(57, 22)
        Me.txtTemperaturaEF.TabIndex = 6
        Me.txtTemperaturaEF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtTemperaturaEF.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtTemperaturaEF.UserValues = Nothing
        Me.txtTemperaturaEF.ValorMaximo = CType(50, Long)
        Me.txtTemperaturaEF.ValorMinimo = CType(0, Long)
        '
        'txtFrecuenciaCardiacaEF
        '
        Me.txtFrecuenciaCardiacaEF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFrecuenciaCardiacaEF.ControlComboEnlace = Nothing
        Me.txtFrecuenciaCardiacaEF.ControlTextoEnlace = Nothing
        Me.txtFrecuenciaCardiacaEF.DatoRelacionado = Nothing
        Me.txtFrecuenciaCardiacaEF.Decimals = CType(0, Byte)
        Me.txtFrecuenciaCardiacaEF.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtFrecuenciaCardiacaEF.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFrecuenciaCardiacaEF.Format = HistoriaClinica.tbFormats.NúmericoEnteroSinSigno
        Me.txtFrecuenciaCardiacaEF.Location = New System.Drawing.Point(363, 37)
        Me.txtFrecuenciaCardiacaEF.MaxLength = 3
        Me.txtFrecuenciaCardiacaEF.Name = "txtFrecuenciaCardiacaEF"
        Me.txtFrecuenciaCardiacaEF.NombreCampoBuscado = Nothing
        Me.txtFrecuenciaCardiacaEF.NombreCampoBusqueda = Nothing
        Me.txtFrecuenciaCardiacaEF.NombreCampoDatos = Nothing
        Me.txtFrecuenciaCardiacaEF.Obligatorio = False
        Me.txtFrecuenciaCardiacaEF.OrigenDeDatos = Nothing
        Me.txtFrecuenciaCardiacaEF.PermitirValorCero = False
        Me.txtFrecuenciaCardiacaEF.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtFrecuenciaCardiacaEF.Size = New System.Drawing.Size(57, 22)
        Me.txtFrecuenciaCardiacaEF.TabIndex = 3
        Me.txtFrecuenciaCardiacaEF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtFrecuenciaCardiacaEF.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtFrecuenciaCardiacaEF.UserValues = Nothing
        Me.txtFrecuenciaCardiacaEF.ValorMaximo = CType(250, Long)
        Me.txtFrecuenciaCardiacaEF.ValorMinimo = CType(0, Long)
        '
        'txtDiastoleEF
        '
        Me.txtDiastoleEF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDiastoleEF.ControlComboEnlace = Nothing
        Me.txtDiastoleEF.ControlTextoEnlace = Nothing
        Me.txtDiastoleEF.DatoRelacionado = Nothing
        Me.txtDiastoleEF.Decimals = CType(0, Byte)
        Me.txtDiastoleEF.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtDiastoleEF.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiastoleEF.Format = HistoriaClinica.tbFormats.NúmericoEnteroSinSigno
        Me.txtDiastoleEF.Location = New System.Drawing.Point(189, 37)
        Me.txtDiastoleEF.MaxLength = 3
        Me.txtDiastoleEF.Name = "txtDiastoleEF"
        Me.txtDiastoleEF.NombreCampoBuscado = Nothing
        Me.txtDiastoleEF.NombreCampoBusqueda = Nothing
        Me.txtDiastoleEF.NombreCampoDatos = Nothing
        Me.txtDiastoleEF.Obligatorio = False
        Me.txtDiastoleEF.OrigenDeDatos = Nothing
        Me.txtDiastoleEF.PermitirValorCero = False
        Me.txtDiastoleEF.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtDiastoleEF.Size = New System.Drawing.Size(57, 22)
        Me.txtDiastoleEF.TabIndex = 2
        Me.txtDiastoleEF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtDiastoleEF.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtDiastoleEF.UserValues = Nothing
        Me.txtDiastoleEF.ValorMaximo = CType(250, Long)
        Me.txtDiastoleEF.ValorMinimo = CType(0, Long)
        '
        'txtSistoleEF
        '
        Me.txtSistoleEF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSistoleEF.ControlComboEnlace = Nothing
        Me.txtSistoleEF.ControlTextoEnlace = Nothing
        Me.txtSistoleEF.DatoRelacionado = Nothing
        Me.txtSistoleEF.Decimals = CType(0, Byte)
        Me.txtSistoleEF.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtSistoleEF.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSistoleEF.Format = HistoriaClinica.tbFormats.NúmericoEnteroSinSigno
        Me.txtSistoleEF.Location = New System.Drawing.Point(16, 37)
        Me.txtSistoleEF.MaxLength = 3
        Me.txtSistoleEF.Name = "txtSistoleEF"
        Me.txtSistoleEF.NombreCampoBuscado = Nothing
        Me.txtSistoleEF.NombreCampoBusqueda = Nothing
        Me.txtSistoleEF.NombreCampoDatos = Nothing
        Me.txtSistoleEF.Obligatorio = False
        Me.txtSistoleEF.OrigenDeDatos = Nothing
        Me.txtSistoleEF.PermitirValorCero = False
        Me.txtSistoleEF.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtSistoleEF.Size = New System.Drawing.Size(57, 22)
        Me.txtSistoleEF.TabIndex = 1
        Me.txtSistoleEF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtSistoleEF.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtSistoleEF.UserValues = Nothing
        Me.txtSistoleEF.ValorMaximo = CType(250, Long)
        Me.txtSistoleEF.ValorMinimo = CType(0, Long)
        '
        'Label87
        '
        Me.Label87.BackColor = System.Drawing.Color.Transparent
        Me.Label87.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label87.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label87.Location = New System.Drawing.Point(507, 96)
        Me.Label87.Name = "Label87"
        Me.Label87.Size = New System.Drawing.Size(35, 18)
        Me.Label87.TabIndex = 33
        Me.Label87.Text = "M"
        Me.Label87.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label86
        '
        Me.Label86.BackColor = System.Drawing.Color.Transparent
        Me.Label86.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label86.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label86.Location = New System.Drawing.Point(413, 96)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(34, 18)
        Me.Label86.TabIndex = 30
        Me.Label86.Text = "Kg"
        Me.Label86.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label72
        '
        Me.Label72.BackColor = System.Drawing.Color.Transparent
        Me.Label72.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label72.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label72.Location = New System.Drawing.Point(774, 69)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(152, 18)
        Me.Label72.TabIndex = 43
        Me.Label72.Text = "Estado de Conciencia"
        Me.Label72.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label81
        '
        Me.Label81.BackColor = System.Drawing.Color.Transparent
        Me.Label81.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label81.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label81.Location = New System.Drawing.Point(363, 3)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(147, 18)
        Me.Label81.TabIndex = 8
        Me.Label81.Text = "Frecuencia Cardíaca"
        Me.Label81.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label80
        '
        Me.Label80.BackColor = System.Drawing.Color.Transparent
        Me.Label80.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label80.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label80.Location = New System.Drawing.Point(82, 96)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(25, 18)
        Me.Label80.TabIndex = 22
        Me.Label80.Text = "° C"
        Me.Label80.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label79
        '
        Me.Label79.BackColor = System.Drawing.Color.Transparent
        Me.Label79.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label79.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label79.Location = New System.Drawing.Point(178, 3)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(122, 32)
        Me.Label79.TabIndex = 4
        Me.Label79.Text = "Tensión Arterial Diástole"
        Me.Label79.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label71
        '
        Me.Label71.BackColor = System.Drawing.Color.Transparent
        Me.Label71.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label71.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label71.Location = New System.Drawing.Point(16, 3)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(118, 32)
        Me.Label71.TabIndex = 0
        Me.Label71.Text = "Tensión Arterial Sístole"
        Me.Label71.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label77
        '
        Me.Label77.BackColor = System.Drawing.Color.Transparent
        Me.Label77.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label77.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label77.Location = New System.Drawing.Point(16, 69)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(99, 18)
        Me.Label77.TabIndex = 20
        Me.Label77.Text = "Temperatura"
        Me.Label77.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label75
        '
        Me.Label75.BackColor = System.Drawing.Color.Transparent
        Me.Label75.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label75.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label75.Location = New System.Drawing.Point(551, 69)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(42, 18)
        Me.Label75.TabIndex = 34
        Me.Label75.Text = "I.M.C."
        Me.Label75.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDescValorIMCEF
        '
        Me.txtDescValorIMCEF.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtDescValorIMCEF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescValorIMCEF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescValorIMCEF.Enabled = False
        Me.txtDescValorIMCEF.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescValorIMCEF.Location = New System.Drawing.Point(589, 92)
        Me.txtDescValorIMCEF.MaxLength = 30
        Me.txtDescValorIMCEF.Name = "txtDescValorIMCEF"
        Me.txtDescValorIMCEF.Size = New System.Drawing.Size(173, 22)
        Me.txtDescValorIMCEF.TabIndex = 11
        Me.txtDescValorIMCEF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtValorIMCEF
        '
        Me.txtValorIMCEF.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtValorIMCEF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValorIMCEF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtValorIMCEF.Enabled = False
        Me.txtValorIMCEF.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorIMCEF.Location = New System.Drawing.Point(553, 92)
        Me.txtValorIMCEF.MaxLength = 5
        Me.txtValorIMCEF.Name = "txtValorIMCEF"
        Me.txtValorIMCEF.Size = New System.Drawing.Size(37, 22)
        Me.txtValorIMCEF.TabIndex = 10
        Me.txtValorIMCEF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label74
        '
        Me.Label74.BackColor = System.Drawing.Color.Transparent
        Me.Label74.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label74.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label74.Location = New System.Drawing.Point(450, 69)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(42, 18)
        Me.Label74.TabIndex = 31
        Me.Label74.Text = "Talla"
        Me.Label74.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label73
        '
        Me.Label73.BackColor = System.Drawing.Color.Transparent
        Me.Label73.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label73.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label73.Location = New System.Drawing.Point(356, 69)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(41, 18)
        Me.Label73.TabIndex = 28
        Me.Label73.Text = "Peso"
        Me.Label73.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnlNota
        '
        Me.PnlNota.Controls.Add(Me.rbInterconNP)
        Me.PnlNota.Controls.Add(Me.dgvInterconsultas)
        Me.PnlNota.Controls.Add(Me.RbEvolucion)
        Me.PnlNota.Controls.Add(Me.rbIngreso)
        Me.PnlNota.Location = New System.Drawing.Point(4, 3)
        Me.PnlNota.Name = "PnlNota"
        Me.PnlNota.Size = New System.Drawing.Size(1065, 133)
        Me.PnlNota.TabIndex = 35
        '
        'rbInterconNP
        '
        Me.rbInterconNP.AutoSize = True
        Me.rbInterconNP.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.rbInterconNP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.rbInterconNP.Location = New System.Drawing.Point(8, 51)
        Me.rbInterconNP.Name = "rbInterconNP"
        Me.rbInterconNP.Size = New System.Drawing.Size(208, 18)
        Me.rbInterconNP.TabIndex = 4
        Me.rbInterconNP.TabStop = True
        Me.rbInterconNP.Text = "Interconsulta No Presencial"
        Me.rbInterconNP.UseVisualStyleBackColor = True
        '
        'dgvInterconsultas
        '
        Me.dgvInterconsultas.AllowUserToAddRows = False
        Me.dgvInterconsultas.AllowUserToDeleteRows = False
        Me.dgvInterconsultas.AllowUserToResizeRows = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(210, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvInterconsultas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvInterconsultas.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInterconsultas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvInterconsultas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInterconsultas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Sel, Me.FechaInterconsulta, Me.ProInterconsulta, Me.EstadoInterconsulta, Me.LOGIN_IC, Me.COD_PRE_SGS, Me.COD_SUCUR, Me.TIP_ADMISION, Me.NUM_ADM, Me.ANO_ADM, Me.NROORDEN, Me.PROCEDIMIENTO, Me.CANTIDAD, Me.MEDICO_IC, Me.ESPECIALIDAD, Me.CEN_COSTO_ORIGEN, Me.CEN_COSTO, Me.NROPEDIDO, Me.FEC_CON_IC, Me.OBS_IC, Me.TIPSERV, Me.PRIORI, Me.GUIA, Me.JUSTIFICACION, Me.ESTADOPLANEA, Me.JUSTIFICACION_EXCEP, Me.ENTIDAD, Me.CODIGO_RIS, Me.CODIGOLABORATORIO, Me.AUTOSISPRO, Me.IDESTADOINTERCONSULTA, Me.CONTESTAIC})
        Me.dgvInterconsultas.GridColor = System.Drawing.Color.Gray
        Me.dgvInterconsultas.Location = New System.Drawing.Point(222, 5)
        Me.dgvInterconsultas.Name = "dgvInterconsultas"
        Me.dgvInterconsultas.RowHeadersWidth = 30
        Me.dgvInterconsultas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvInterconsultas.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgvInterconsultas.RowTemplate.Height = 20
        Me.dgvInterconsultas.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvInterconsultas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvInterconsultas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvInterconsultas.Size = New System.Drawing.Size(840, 123)
        Me.dgvInterconsultas.TabIndex = 3
        '
        'Sel
        '
        Me.Sel.DataPropertyName = "SEL"
        Me.Sel.Frozen = True
        Me.Sel.HeaderText = ""
        Me.Sel.Name = "Sel"
        Me.Sel.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Sel.Width = 20
        '
        'FechaInterconsulta
        '
        Me.FechaInterconsulta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.FechaInterconsulta.DataPropertyName = "FECHA"
        Me.FechaInterconsulta.HeaderText = "FECHA"
        Me.FechaInterconsulta.Name = "FechaInterconsulta"
        Me.FechaInterconsulta.ReadOnly = True
        Me.FechaInterconsulta.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.FechaInterconsulta.Width = 73
        '
        'ProInterconsulta
        '
        Me.ProInterconsulta.DataPropertyName = "INTERCONSULTA"
        Me.ProInterconsulta.HeaderText = "INTERCONSULTA"
        Me.ProInterconsulta.Name = "ProInterconsulta"
        Me.ProInterconsulta.ReadOnly = True
        Me.ProInterconsulta.Width = 555
        '
        'EstadoInterconsulta
        '
        Me.EstadoInterconsulta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.EstadoInterconsulta.DataPropertyName = "ESTADO"
        Me.EstadoInterconsulta.HeaderText = "ESTADO"
        Me.EstadoInterconsulta.Name = "EstadoInterconsulta"
        Me.EstadoInterconsulta.ReadOnly = True
        Me.EstadoInterconsulta.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.EstadoInterconsulta.Width = 81
        '
        'LOGIN_IC
        '
        Me.LOGIN_IC.DataPropertyName = "LOGIN"
        Me.LOGIN_IC.HeaderText = "LOGIN"
        Me.LOGIN_IC.Name = "LOGIN_IC"
        Me.LOGIN_IC.Visible = False
        '
        'COD_PRE_SGS
        '
        Me.COD_PRE_SGS.DataPropertyName = "COD_PRE_SGS"
        Me.COD_PRE_SGS.HeaderText = "COD_PRE_SGS"
        Me.COD_PRE_SGS.Name = "COD_PRE_SGS"
        Me.COD_PRE_SGS.Visible = False
        '
        'COD_SUCUR
        '
        Me.COD_SUCUR.DataPropertyName = "COD_SUCUR"
        Me.COD_SUCUR.HeaderText = "COD_SUCUR"
        Me.COD_SUCUR.Name = "COD_SUCUR"
        Me.COD_SUCUR.Visible = False
        '
        'TIP_ADMISION
        '
        Me.TIP_ADMISION.DataPropertyName = "TIP_ADMISION"
        Me.TIP_ADMISION.HeaderText = "TIP_ADMISION"
        Me.TIP_ADMISION.Name = "TIP_ADMISION"
        Me.TIP_ADMISION.Visible = False
        '
        'NUM_ADM
        '
        Me.NUM_ADM.DataPropertyName = "NUM_ADM"
        Me.NUM_ADM.HeaderText = "NUM_ADM"
        Me.NUM_ADM.Name = "NUM_ADM"
        Me.NUM_ADM.Visible = False
        '
        'ANO_ADM
        '
        Me.ANO_ADM.DataPropertyName = "ANO_ADM"
        Me.ANO_ADM.HeaderText = "ANO_ADM"
        Me.ANO_ADM.Name = "ANO_ADM"
        Me.ANO_ADM.Visible = False
        '
        'NROORDEN
        '
        Me.NROORDEN.DataPropertyName = "NROORDEN"
        Me.NROORDEN.HeaderText = "NROORDEN"
        Me.NROORDEN.Name = "NROORDEN"
        Me.NROORDEN.Visible = False
        '
        'PROCEDIMIENTO
        '
        Me.PROCEDIMIENTO.DataPropertyName = "PROCEDIMIENTO"
        Me.PROCEDIMIENTO.HeaderText = "PROCEDIMIENTO"
        Me.PROCEDIMIENTO.Name = "PROCEDIMIENTO"
        Me.PROCEDIMIENTO.Visible = False
        '
        'CANTIDAD
        '
        Me.CANTIDAD.DataPropertyName = "CANTIDAD"
        Me.CANTIDAD.HeaderText = "CANTIDAD"
        Me.CANTIDAD.Name = "CANTIDAD"
        Me.CANTIDAD.Visible = False
        '
        'MEDICO_IC
        '
        Me.MEDICO_IC.DataPropertyName = "MEDICO"
        Me.MEDICO_IC.HeaderText = "MEDICO"
        Me.MEDICO_IC.Name = "MEDICO_IC"
        Me.MEDICO_IC.Visible = False
        '
        'ESPECIALIDAD
        '
        Me.ESPECIALIDAD.DataPropertyName = "ESPECIALIDAD"
        Me.ESPECIALIDAD.HeaderText = "ESPECIALIDAD"
        Me.ESPECIALIDAD.Name = "ESPECIALIDAD"
        Me.ESPECIALIDAD.Visible = False
        '
        'CEN_COSTO_ORIGEN
        '
        Me.CEN_COSTO_ORIGEN.DataPropertyName = "CEN_COSTO_ORIGEN"
        Me.CEN_COSTO_ORIGEN.HeaderText = "CEN_COSTO_ORIGEN"
        Me.CEN_COSTO_ORIGEN.Name = "CEN_COSTO_ORIGEN"
        Me.CEN_COSTO_ORIGEN.Visible = False
        '
        'CEN_COSTO
        '
        Me.CEN_COSTO.DataPropertyName = "CEN_COSTO"
        Me.CEN_COSTO.HeaderText = "CEN_COSTO"
        Me.CEN_COSTO.Name = "CEN_COSTO"
        Me.CEN_COSTO.Visible = False
        '
        'NROPEDIDO
        '
        Me.NROPEDIDO.DataPropertyName = "NROPEDIDO"
        Me.NROPEDIDO.HeaderText = "NROPEDIDO"
        Me.NROPEDIDO.Name = "NROPEDIDO"
        Me.NROPEDIDO.Visible = False
        '
        'FEC_CON_IC
        '
        Me.FEC_CON_IC.DataPropertyName = "FEC_CON"
        Me.FEC_CON_IC.HeaderText = "FEC_CON"
        Me.FEC_CON_IC.Name = "FEC_CON_IC"
        Me.FEC_CON_IC.Visible = False
        '
        'OBS_IC
        '
        Me.OBS_IC.DataPropertyName = "OBS"
        Me.OBS_IC.HeaderText = "OBS"
        Me.OBS_IC.Name = "OBS_IC"
        Me.OBS_IC.Visible = False
        '
        'TIPSERV
        '
        Me.TIPSERV.DataPropertyName = "TIPSERV"
        Me.TIPSERV.HeaderText = "TIPSERV"
        Me.TIPSERV.Name = "TIPSERV"
        Me.TIPSERV.Visible = False
        '
        'PRIORI
        '
        Me.PRIORI.DataPropertyName = "PRIORI"
        Me.PRIORI.HeaderText = "PRIORI"
        Me.PRIORI.Name = "PRIORI"
        Me.PRIORI.Visible = False
        '
        'GUIA
        '
        Me.GUIA.DataPropertyName = "GUIA"
        Me.GUIA.HeaderText = "GUIA"
        Me.GUIA.Name = "GUIA"
        Me.GUIA.Visible = False
        '
        'JUSTIFICACION
        '
        Me.JUSTIFICACION.DataPropertyName = "JUSTIFICACION"
        Me.JUSTIFICACION.HeaderText = "JUSTIFICACION"
        Me.JUSTIFICACION.Name = "JUSTIFICACION"
        Me.JUSTIFICACION.Visible = False
        '
        'ESTADOPLANEA
        '
        Me.ESTADOPLANEA.DataPropertyName = "ESTADOPLANEA"
        Me.ESTADOPLANEA.HeaderText = "ESTADOPLANEA"
        Me.ESTADOPLANEA.Name = "ESTADOPLANEA"
        Me.ESTADOPLANEA.Visible = False
        '
        'JUSTIFICACION_EXCEP
        '
        Me.JUSTIFICACION_EXCEP.DataPropertyName = "JUSTIFICACION_EXCEP"
        Me.JUSTIFICACION_EXCEP.HeaderText = "JUSTIFICACION_EXCEP"
        Me.JUSTIFICACION_EXCEP.Name = "JUSTIFICACION_EXCEP"
        Me.JUSTIFICACION_EXCEP.Visible = False
        '
        'ENTIDAD
        '
        Me.ENTIDAD.DataPropertyName = "ENTIDAD"
        Me.ENTIDAD.HeaderText = "ENTIDAD"
        Me.ENTIDAD.Name = "ENTIDAD"
        Me.ENTIDAD.Visible = False
        '
        'CODIGO_RIS
        '
        Me.CODIGO_RIS.DataPropertyName = "CODIGO_RIS"
        Me.CODIGO_RIS.HeaderText = "CODIGO_RIS"
        Me.CODIGO_RIS.Name = "CODIGO_RIS"
        Me.CODIGO_RIS.Visible = False
        '
        'CODIGOLABORATORIO
        '
        Me.CODIGOLABORATORIO.DataPropertyName = "CODIGOLABORATORIO"
        Me.CODIGOLABORATORIO.HeaderText = "CODIGOLABORATORIO"
        Me.CODIGOLABORATORIO.Name = "CODIGOLABORATORIO"
        Me.CODIGOLABORATORIO.Visible = False
        '
        'AUTOSISPRO
        '
        Me.AUTOSISPRO.DataPropertyName = "AUTOSISPRO"
        Me.AUTOSISPRO.HeaderText = "AUTOSISPRO"
        Me.AUTOSISPRO.Name = "AUTOSISPRO"
        Me.AUTOSISPRO.Visible = False
        '
        'IDESTADOINTERCONSULTA
        '
        Me.IDESTADOINTERCONSULTA.DataPropertyName = "IDESTADOINTERCONSULTA"
        Me.IDESTADOINTERCONSULTA.HeaderText = "IDESTADOINTERCONSULTA"
        Me.IDESTADOINTERCONSULTA.Name = "IDESTADOINTERCONSULTA"
        Me.IDESTADOINTERCONSULTA.Visible = False
        '
        'CONTESTAIC
        '
        Me.CONTESTAIC.DataPropertyName = "CONTESTAIC"
        Me.CONTESTAIC.HeaderText = "CONTESTAIC"
        Me.CONTESTAIC.Name = "CONTESTAIC"
        Me.CONTESTAIC.Visible = False
        '
        'RbEvolucion
        '
        Me.RbEvolucion.AutoSize = True
        Me.RbEvolucion.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.RbEvolucion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.RbEvolucion.Location = New System.Drawing.Point(8, 15)
        Me.RbEvolucion.Name = "RbEvolucion"
        Me.RbEvolucion.Size = New System.Drawing.Size(88, 18)
        Me.RbEvolucion.TabIndex = 1
        Me.RbEvolucion.TabStop = True
        Me.RbEvolucion.Text = "Evolución"
        Me.RbEvolucion.UseVisualStyleBackColor = True
        '
        'rbIngreso
        '
        Me.rbIngreso.AutoSize = True
        Me.rbIngreso.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.rbIngreso.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.rbIngreso.Location = New System.Drawing.Point(135, 15)
        Me.rbIngreso.Name = "rbIngreso"
        Me.rbIngreso.Size = New System.Drawing.Size(76, 18)
        Me.rbIngreso.TabIndex = 2
        Me.rbIngreso.TabStop = True
        Me.rbIngreso.Text = "Ingreso"
        Me.rbIngreso.UseVisualStyleBackColor = True
        '
        'pnlContenedor
        '
        Me.pnlContenedor.Controls.Add(Me.pnlContEvolucion)
        Me.pnlContenedor.Location = New System.Drawing.Point(1, 30)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Size = New System.Drawing.Size(1084, 1595)
        Me.pnlContenedor.TabIndex = 54
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel2.Location = New System.Drawing.Point(182, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(291, 35)
        Me.Panel2.TabIndex = 52
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Panel1.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.imag_18
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel1.Controls.Add(Me.lbFecha)
        Me.Panel1.Controls.Add(Me.mtFechaInicial)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1097, 35)
        Me.Panel1.TabIndex = 0
        '
        'lbFecha
        '
        Me.lbFecha.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFecha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lbFecha.Location = New System.Drawing.Point(825, 6)
        Me.lbFecha.Name = "lbFecha"
        Me.lbFecha.Size = New System.Drawing.Size(101, 20)
        Me.lbFecha.TabIndex = 5
        Me.lbFecha.Text = "Fecha y Hora"
        Me.lbFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtFechaInicial
        '
        Me.mtFechaInicial.Enabled = False
        Me.mtFechaInicial.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtFechaInicial.Location = New System.Drawing.Point(928, 6)
        Me.mtFechaInicial.Mask = "00/00/0000 00:00"
        Me.mtFechaInicial.Name = "mtFechaInicial"
        Me.mtFechaInicial.Size = New System.Drawing.Size(151, 22)
        Me.mtFechaInicial.TabIndex = 6
        Me.mtFechaInicial.ValidatingType = GetType(Date)
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Diagnos"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn1.HeaderText = "Diagnostico"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 190
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Subjetivo"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Subjetivo"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Visible = False
        Me.DataGridViewTextBoxColumn2.Width = 190
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Paracli"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn3.HeaderText = "Inter. Paraclinico"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Visible = False
        Me.DataGridViewTextBoxColumn3.Width = 190
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Objetivo"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Objetivo"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Visible = False
        Me.DataGridViewTextBoxColumn4.Width = 190
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "PlanManejo"
        Me.DataGridViewTextBoxColumn5.FillWeight = 150.0!
        Me.DataGridViewTextBoxColumn5.HeaderText = "Plan de Manejo"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Visible = False
        Me.DataGridViewTextBoxColumn5.Width = 190
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "ano_adm"
        Me.DataGridViewTextBoxColumn6.HeaderText = "ano_adm"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Visible = False
        Me.DataGridViewTextBoxColumn6.Width = 130
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "num_adm"
        Me.DataGridViewTextBoxColumn7.FillWeight = 150.0!
        Me.DataGridViewTextBoxColumn7.HeaderText = "num_adm"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Visible = False
        Me.DataGridViewTextBoxColumn7.Width = 250
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "fecha_evol"
        Me.DataGridViewTextBoxColumn8.FillWeight = 150.0!
        Me.DataGridViewTextBoxColumn8.HeaderText = "Fecha_Evolucion"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Visible = False
        Me.DataGridViewTextBoxColumn8.Width = 150
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "Hora_Evol"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Hora_Evolicion"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Visible = False
        Me.DataGridViewTextBoxColumn9.Width = 19
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "Min_Evol"
        Me.DataGridViewTextBoxColumn10.HeaderText = "Min_Evolucion"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Visible = False
        Me.DataGridViewTextBoxColumn10.Width = 19
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "DiagActual"
        Me.DataGridViewTextBoxColumn11.HeaderText = "Diagnostico_Actual"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Visible = False
        Me.DataGridViewTextBoxColumn11.Width = 150
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "subjetivo"
        Me.DataGridViewTextBoxColumn12.HeaderText = "subjetivo"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Visible = False
        Me.DataGridViewTextBoxColumn12.Width = 19
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "interpParaclic"
        Me.DataGridViewTextBoxColumn13.HeaderText = "Interpretacion"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Visible = False
        Me.DataGridViewTextBoxColumn13.Width = 19
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "notas"
        Me.DataGridViewTextBoxColumn14.HeaderText = "Objetivo"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.Visible = False
        Me.DataGridViewTextBoxColumn14.Width = 19
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "orden"
        Me.DataGridViewTextBoxColumn15.FillWeight = 150.0!
        Me.DataGridViewTextBoxColumn15.HeaderText = "Plan_de_Manejo"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        Me.DataGridViewTextBoxColumn15.Visible = False
        Me.DataGridViewTextBoxColumn15.Width = 120
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "confidencial"
        Me.DataGridViewTextBoxColumn16.HeaderText = "confidencial"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        Me.DataGridViewTextBoxColumn16.Visible = False
        Me.DataGridViewTextBoxColumn16.Width = 19
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "DiagActual"
        Me.DataGridViewTextBoxColumn17.HeaderText = "Diagnostico_Actual"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        Me.DataGridViewTextBoxColumn17.Visible = False
        Me.DataGridViewTextBoxColumn17.Width = 160
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "subjetivo"
        Me.DataGridViewTextBoxColumn18.FillWeight = 150.0!
        Me.DataGridViewTextBoxColumn18.HeaderText = "subjetivo"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        Me.DataGridViewTextBoxColumn18.Visible = False
        Me.DataGridViewTextBoxColumn18.Width = 120
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "interpParaclic"
        Me.DataGridViewTextBoxColumn19.HeaderText = "Interpretacion"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.Visible = False
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "interpParaclic"
        Me.DataGridViewTextBoxColumn20.FillWeight = 150.0!
        Me.DataGridViewTextBoxColumn20.HeaderText = "Interpretacion"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.ReadOnly = True
        Me.DataGridViewTextBoxColumn20.Visible = False
        Me.DataGridViewTextBoxColumn20.Width = 120
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.DataPropertyName = "Interconsulta"
        Me.DataGridViewTextBoxColumn21.FillWeight = 150.0!
        Me.DataGridViewTextBoxColumn21.HeaderText = "Interconsulta"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.ReadOnly = True
        Me.DataGridViewTextBoxColumn21.Visible = False
        Me.DataGridViewTextBoxColumn21.Width = 120
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.DataPropertyName = "num_doc"
        Me.DataGridViewTextBoxColumn22.HeaderText = "num_doc"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.Visible = False
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.DataPropertyName = "tip_admision"
        Me.DataGridViewTextBoxColumn23.HeaderText = "tip_admision"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        Me.DataGridViewTextBoxColumn23.Visible = False
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.DataPropertyName = "ano_adm"
        Me.DataGridViewTextBoxColumn24.HeaderText = "ano_adm"
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        Me.DataGridViewTextBoxColumn24.Visible = False
        '
        'DataGridViewTextBoxColumn25
        '
        Me.DataGridViewTextBoxColumn25.DataPropertyName = "num_adm"
        Me.DataGridViewTextBoxColumn25.HeaderText = "num_adm"
        Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
        Me.DataGridViewTextBoxColumn25.Visible = False
        '
        'DataGridViewTextBoxColumn26
        '
        Me.DataGridViewTextBoxColumn26.DataPropertyName = "fecha_evol"
        Me.DataGridViewTextBoxColumn26.HeaderText = "Fecha_Evolucion"
        Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
        Me.DataGridViewTextBoxColumn26.Visible = False
        '
        'DataGridViewTextBoxColumn27
        '
        Me.DataGridViewTextBoxColumn27.DataPropertyName = "Hora_Evol"
        Me.DataGridViewTextBoxColumn27.HeaderText = "Hora_Evolucion"
        Me.DataGridViewTextBoxColumn27.Name = "DataGridViewTextBoxColumn27"
        Me.DataGridViewTextBoxColumn27.Visible = False
        '
        'DataGridViewTextBoxColumn28
        '
        Me.DataGridViewTextBoxColumn28.DataPropertyName = "Min_Evol"
        Me.DataGridViewTextBoxColumn28.HeaderText = "Min_Evolucion"
        Me.DataGridViewTextBoxColumn28.Name = "DataGridViewTextBoxColumn28"
        Me.DataGridViewTextBoxColumn28.Visible = False
        '
        'DataGridViewTextBoxColumn29
        '
        Me.DataGridViewTextBoxColumn29.DataPropertyName = "Medico"
        Me.DataGridViewTextBoxColumn29.HeaderText = "Medico"
        Me.DataGridViewTextBoxColumn29.Name = "DataGridViewTextBoxColumn29"
        Me.DataGridViewTextBoxColumn29.Visible = False
        '
        'DataGridViewTextBoxColumn30
        '
        Me.DataGridViewTextBoxColumn30.DataPropertyName = "Interconsulta"
        Me.DataGridViewTextBoxColumn30.HeaderText = "Interconsulta"
        Me.DataGridViewTextBoxColumn30.Name = "DataGridViewTextBoxColumn30"
        Me.DataGridViewTextBoxColumn30.Visible = False
        '
        'DataGridViewTextBoxColumn31
        '
        Me.DataGridViewTextBoxColumn31.DataPropertyName = "notas"
        Me.DataGridViewTextBoxColumn31.HeaderText = "Objetivo"
        Me.DataGridViewTextBoxColumn31.Name = "DataGridViewTextBoxColumn31"
        '
        'DataGridViewTextBoxColumn32
        '
        Me.DataGridViewTextBoxColumn32.DataPropertyName = "Login"
        Me.DataGridViewTextBoxColumn32.HeaderText = "Login"
        Me.DataGridViewTextBoxColumn32.Name = "DataGridViewTextBoxColumn32"
        Me.DataGridViewTextBoxColumn32.Visible = False
        '
        'DataGridViewTextBoxColumn33
        '
        Me.DataGridViewTextBoxColumn33.DataPropertyName = "Fec_Con"
        Me.DataGridViewTextBoxColumn33.HeaderText = "Fec_Con"
        Me.DataGridViewTextBoxColumn33.Name = "DataGridViewTextBoxColumn33"
        Me.DataGridViewTextBoxColumn33.Visible = False
        '
        'DataGridViewTextBoxColumn34
        '
        Me.DataGridViewTextBoxColumn34.DataPropertyName = "Obs"
        Me.DataGridViewTextBoxColumn34.HeaderText = "Obs"
        Me.DataGridViewTextBoxColumn34.Name = "DataGridViewTextBoxColumn34"
        Me.DataGridViewTextBoxColumn34.Visible = False
        '
        'DataGridViewTextBoxColumn35
        '
        Me.DataGridViewTextBoxColumn35.DataPropertyName = "orden"
        Me.DataGridViewTextBoxColumn35.HeaderText = "Plan_de_Manejo"
        Me.DataGridViewTextBoxColumn35.Name = "DataGridViewTextBoxColumn35"
        Me.DataGridViewTextBoxColumn35.Visible = False
        '
        'DataGridViewTextBoxColumn36
        '
        Me.DataGridViewTextBoxColumn36.DataPropertyName = "confidencial"
        Me.DataGridViewTextBoxColumn36.HeaderText = "confidencial"
        Me.DataGridViewTextBoxColumn36.Name = "DataGridViewTextBoxColumn36"
        Me.DataGridViewTextBoxColumn36.Visible = False
        '
        'DataGridViewTextBoxColumn37
        '
        Me.DataGridViewTextBoxColumn37.DataPropertyName = "DiagActual"
        Me.DataGridViewTextBoxColumn37.HeaderText = "Diagnostico_Actual"
        Me.DataGridViewTextBoxColumn37.Name = "DataGridViewTextBoxColumn37"
        Me.DataGridViewTextBoxColumn37.Visible = False
        '
        'DataGridViewTextBoxColumn38
        '
        Me.DataGridViewTextBoxColumn38.DataPropertyName = "subjetivo"
        Me.DataGridViewTextBoxColumn38.HeaderText = "subjetivo"
        Me.DataGridViewTextBoxColumn38.Name = "DataGridViewTextBoxColumn38"
        Me.DataGridViewTextBoxColumn38.Visible = False
        '
        'DataGridViewTextBoxColumn39
        '
        Me.DataGridViewTextBoxColumn39.DataPropertyName = "interpParaclic"
        Me.DataGridViewTextBoxColumn39.HeaderText = "Interpretacion"
        Me.DataGridViewTextBoxColumn39.Name = "DataGridViewTextBoxColumn39"
        Me.DataGridViewTextBoxColumn39.Visible = False
        '
        'DataGridViewTextBoxColumn40
        '
        Me.DataGridViewTextBoxColumn40.DataPropertyName = "FECHA"
        Me.DataGridViewTextBoxColumn40.HeaderText = "FECHA"
        Me.DataGridViewTextBoxColumn40.Name = "DataGridViewTextBoxColumn40"
        Me.DataGridViewTextBoxColumn40.Visible = False
        Me.DataGridViewTextBoxColumn40.Width = 150
        '
        'DataGridViewTextBoxColumn41
        '
        Me.DataGridViewTextBoxColumn41.DataPropertyName = "INTERCONSULTA"
        Me.DataGridViewTextBoxColumn41.HeaderText = "INTERCONSULTA"
        Me.DataGridViewTextBoxColumn41.Name = "DataGridViewTextBoxColumn41"
        Me.DataGridViewTextBoxColumn41.Visible = False
        Me.DataGridViewTextBoxColumn41.Width = 700
        '
        'DataGridViewTextBoxColumn42
        '
        Me.DataGridViewTextBoxColumn42.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn42.DataPropertyName = "ESTADO"
        Me.DataGridViewTextBoxColumn42.HeaderText = "ESTADO"
        Me.DataGridViewTextBoxColumn42.Name = "DataGridViewTextBoxColumn42"
        Me.DataGridViewTextBoxColumn42.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'DataGridViewTextBoxColumn43
        '
        Me.DataGridViewTextBoxColumn43.DataPropertyName = "LOGIN"
        Me.DataGridViewTextBoxColumn43.HeaderText = "LOGIN"
        Me.DataGridViewTextBoxColumn43.Name = "DataGridViewTextBoxColumn43"
        Me.DataGridViewTextBoxColumn43.Visible = False
        Me.DataGridViewTextBoxColumn43.Width = 530
        '
        'DataGridViewTextBoxColumn44
        '
        Me.DataGridViewTextBoxColumn44.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn44.DataPropertyName = "ESTADO"
        Me.DataGridViewTextBoxColumn44.HeaderText = "ESTADO"
        Me.DataGridViewTextBoxColumn44.Name = "DataGridViewTextBoxColumn44"
        Me.DataGridViewTextBoxColumn44.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'DataGridViewTextBoxColumn45
        '
        Me.DataGridViewTextBoxColumn45.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn45.DataPropertyName = "LOGIN"
        Me.DataGridViewTextBoxColumn45.HeaderText = "LOGIN"
        Me.DataGridViewTextBoxColumn45.Name = "DataGridViewTextBoxColumn45"
        Me.DataGridViewTextBoxColumn45.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn45.Visible = False
        '
        'DataGridViewTextBoxColumn46
        '
        Me.DataGridViewTextBoxColumn46.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn46.DataPropertyName = "ESTADO"
        Me.DataGridViewTextBoxColumn46.HeaderText = "ESTADO"
        Me.DataGridViewTextBoxColumn46.Name = "DataGridViewTextBoxColumn46"
        Me.DataGridViewTextBoxColumn46.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'DataGridViewTextBoxColumn47
        '
        Me.DataGridViewTextBoxColumn47.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn47.DataPropertyName = "LOGIN"
        Me.DataGridViewTextBoxColumn47.HeaderText = "LOGIN"
        Me.DataGridViewTextBoxColumn47.Name = "DataGridViewTextBoxColumn47"
        Me.DataGridViewTextBoxColumn47.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn47.Visible = False
        '
        'DataGridViewTextBoxColumn48
        '
        Me.DataGridViewTextBoxColumn48.DataPropertyName = "LOGIN"
        Me.DataGridViewTextBoxColumn48.HeaderText = "LOGIN"
        Me.DataGridViewTextBoxColumn48.Name = "DataGridViewTextBoxColumn48"
        Me.DataGridViewTextBoxColumn48.Visible = False
        '
        'ctlDiagnostico
        '
        Me.ctlDiagnostico.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ctlDiagnostico.Location = New System.Drawing.Point(-4, 200)
        Me.ctlDiagnostico.Name = "ctlDiagnostico"
        Me.ctlDiagnostico.pClase_Diag = "EVL"
        Me.ctlDiagnostico.pDiagnostico = CType(resources.GetObject("ctlDiagnostico.pDiagnostico"), HistoriaClinica.Sophia.HistoriaClinica.Controles.Diagnostico)
        Me.ctlDiagnostico.plstDiagnostico = CType(resources.GetObject("ctlDiagnostico.plstDiagnostico"), System.Collections.Generic.List(Of HistoriaClinica.Sophia.HistoriaClinica.Controles.Diagnostico))
        Me.ctlDiagnostico.plstDiagNuevos = CType(resources.GetObject("ctlDiagnostico.plstDiagNuevos"), System.Collections.Generic.List(Of HistoriaClinica.Sophia.HistoriaClinica.Controles.Diagnostico))
        Me.ctlDiagnostico.Size = New System.Drawing.Size(1086, 246)
        Me.ctlDiagnostico.TabIndex = 4
        '
        'ctlEvolucion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Controls.Add(Me.ctlDiagnostico)
        Me.Controls.Add(Me.pnlContenedor)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ctlEvolucion"
        Me.Size = New System.Drawing.Size(1100, 1642)
        Me.pnlContEvolucion.ResumeLayout(False)
        CType(Me.dvEvolucion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEvolucion.ResumeLayout(False)
        Me.pnlEvolucion.PerformLayout()
        Me.grpGenPrg.ResumeLayout(False)
        Me.grbCerrarInterconsulta.ResumeLayout(False)
        Me.grbCerrarInterconsulta.PerformLayout()
        Me.grpPlaManPrg1.ResumeLayout(False)
        Me.grpPlaManPrg1.PerformLayout()
        Me.pnlDatosEF.ResumeLayout(False)
        Me.pnlDatosEF.PerformLayout()
        Me.PnlNota.ResumeLayout(False)
        Me.PnlNota.PerformLayout()
        CType(Me.dgvInterconsultas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlContenedor.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tmHoraEvolucion As System.Windows.Forms.Timer
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnlContEvolucion As System.Windows.Forms.Panel
    Friend WithEvents pnlEvolucion As System.Windows.Forms.Panel
    Friend WithEvents grpGenPrg As System.Windows.Forms.Panel
    Friend WithEvents grbCerrarInterconsulta As System.Windows.Forms.GroupBox
    Friend WithEvents txtCierrreInterconsulta As System.Windows.Forms.TextBox
    Friend WithEvents rbtCierreIntConNo As System.Windows.Forms.RadioButton
    Friend WithEvents rbtCierreIntConSI As System.Windows.Forms.RadioButton
    Friend WithEvents grpPlaManPrg1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPlaManPrg1 As System.Windows.Forms.TextBox
    Friend WithEvents rdPlaManPrg1No As System.Windows.Forms.RadioButton
    Friend WithEvents rdPlaManPrg1Si As System.Windows.Forms.RadioButton
    Friend WithEvents btGrabar As System.Windows.Forms.Button
    Friend WithEvents txtTipoEvolucion As System.Windows.Forms.TextBox
    Friend WithEvents btNuevo As System.Windows.Forms.Button
    Friend WithEvents btImprimir As System.Windows.Forms.Button
    Friend WithEvents tbPlanManejo As System.Windows.Forms.TextBox
    Friend WithEvents lbPlanManejo As System.Windows.Forms.Label
    Friend WithEvents tbObjetivo As System.Windows.Forms.TextBox
    Friend WithEvents lbObjetivo As System.Windows.Forms.Label
    Friend WithEvents tbSubjetivo As System.Windows.Forms.TextBox
    Friend WithEvents tbParaclinicos As System.Windows.Forms.TextBox
    Friend WithEvents lbSubjetivo As System.Windows.Forms.Label
    Friend WithEvents lbParaclinicos As System.Windows.Forms.Label
    Friend WithEvents PnlNota As System.Windows.Forms.Panel
    Friend WithEvents RbEvolucion As System.Windows.Forms.RadioButton
    Friend WithEvents rbIngreso As System.Windows.Forms.RadioButton
    Friend WithEvents pnlContenedor As System.Windows.Forms.Panel
    Friend WithEvents lblTipEvolucion As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BtnRptCuidadoPaliativo As System.Windows.Forms.Button
    Friend WithEvents pnlTitDiaReg As System.Windows.Forms.Panel
    Friend WithEvents ctlDiagnostico As ctlDiagnosticos
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn27 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn28 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn29 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn30 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn31 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn32 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn34 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn35 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn36 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn37 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn38 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn39 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvInterconsultas As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn40 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn41 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn42 As DataGridViewTextBoxColumn
    Friend WithEvents lblTitEvolucion As Label
    Friend WithEvents DataGridViewTextBoxColumn43 As DataGridViewTextBoxColumn
    Friend WithEvents pnlDatosEF As Panel
    Friend WithEvents LbOblescdol As Label
    Friend WithEvents LbOblfrecresp As Label
    Friend WithEvents LbOblfrecard As Label
    Friend WithEvents LbObltenardias As Label
    Friend WithEvents LbObltenarsis As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents txtFrecuenciaRespiratoriaEF As TextBoxConFormato
    Friend WithEvents Label82 As Label
    Friend WithEvents Cmbanalogadedolor As ComboBox
    Friend WithEvents Label114 As Label
    Friend WithEvents Label113 As Label
    Friend WithEvents Label112 As Label
    Friend WithEvents txtSatOxi As TextBoxConFormato
    Friend WithEvents Label111 As Label
    Friend WithEvents Label103 As Label
    Friend WithEvents Label101 As Label
    Friend WithEvents Label99 As Label
    Friend WithEvents lblObligatorioEstado As Label
    Friend WithEvents txtDescEstadoConcienciaEF As TextBoxConFormato
    Friend WithEvents txtCodEstadoConcienciaEF As TextBoxConFormato
    Friend WithEvents txtTallaEF As TextBoxConFormato
    Friend WithEvents txtPesoEF As TextBoxConFormato
    Friend WithEvents txtTemperaturaEF As TextBoxConFormato
    Friend WithEvents txtFrecuenciaCardiacaEF As TextBoxConFormato
    Friend WithEvents txtDiastoleEF As TextBoxConFormato
    Friend WithEvents txtSistoleEF As TextBoxConFormato
    Friend WithEvents Label87 As Label
    Friend WithEvents Label86 As Label
    Friend WithEvents Label72 As Label
    Friend WithEvents Label81 As Label
    Friend WithEvents Label80 As Label
    Friend WithEvents Label79 As Label
    Friend WithEvents Label71 As Label
    Friend WithEvents Label77 As Label
    Friend WithEvents Label75 As Label
    Friend WithEvents txtDescValorIMCEF As TextBox
    Friend WithEvents txtValorIMCEF As TextBox
    Friend WithEvents Label74 As Label
    Friend WithEvents Label73 As Label
    Friend WithEvents lblSignosVitales As Label
    Friend WithEvents DataGridViewTextBoxColumn44 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn45 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn46 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn47 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn48 As DataGridViewTextBoxColumn
    Friend WithEvents dvEvolucion As DataGridView
    Friend WithEvents txtAnalisis As TextBox
    Friend WithEvents lblAnalisis As Label
    Friend WithEvents lbFecha As Label
    Friend WithEvents mtFechaInicial As MaskedTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Sel As DataGridViewCheckBoxColumn
    Friend WithEvents FechaInterconsulta As DataGridViewTextBoxColumn
    Friend WithEvents ProInterconsulta As DataGridViewTextBoxColumn
    Friend WithEvents EstadoInterconsulta As DataGridViewTextBoxColumn
    Friend WithEvents LOGIN_IC As DataGridViewTextBoxColumn
    Friend WithEvents COD_PRE_SGS As DataGridViewTextBoxColumn
    Friend WithEvents COD_SUCUR As DataGridViewTextBoxColumn
    Friend WithEvents TIP_ADMISION As DataGridViewTextBoxColumn
    Friend WithEvents NUM_ADM As DataGridViewTextBoxColumn
    Friend WithEvents ANO_ADM As DataGridViewTextBoxColumn
    Friend WithEvents NROORDEN As DataGridViewTextBoxColumn
    Friend WithEvents PROCEDIMIENTO As DataGridViewTextBoxColumn
    Friend WithEvents CANTIDAD As DataGridViewTextBoxColumn
    Friend WithEvents MEDICO_IC As DataGridViewTextBoxColumn
    Friend WithEvents ESPECIALIDAD As DataGridViewTextBoxColumn
    Friend WithEvents CEN_COSTO_ORIGEN As DataGridViewTextBoxColumn
    Friend WithEvents CEN_COSTO As DataGridViewTextBoxColumn
    Friend WithEvents NROPEDIDO As DataGridViewTextBoxColumn
    Friend WithEvents FEC_CON_IC As DataGridViewTextBoxColumn
    Friend WithEvents OBS_IC As DataGridViewTextBoxColumn
    Friend WithEvents TIPSERV As DataGridViewTextBoxColumn
    Friend WithEvents PRIORI As DataGridViewTextBoxColumn
    Friend WithEvents GUIA As DataGridViewTextBoxColumn
    Friend WithEvents JUSTIFICACION As DataGridViewTextBoxColumn
    Friend WithEvents ESTADOPLANEA As DataGridViewTextBoxColumn
    Friend WithEvents JUSTIFICACION_EXCEP As DataGridViewTextBoxColumn
    Friend WithEvents ENTIDAD As DataGridViewTextBoxColumn
    Friend WithEvents CODIGO_RIS As DataGridViewTextBoxColumn
    Friend WithEvents CODIGOLABORATORIO As DataGridViewTextBoxColumn
    Friend WithEvents AUTOSISPRO As DataGridViewTextBoxColumn
    Friend WithEvents IDESTADOINTERCONSULTA As DataGridViewTextBoxColumn
    Friend WithEvents CONTESTAIC As DataGridViewTextBoxColumn
    Friend WithEvents Sel_evo As DataGridViewImageColumn
    Friend WithEvents fecha_evol As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn61 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn62 As DataGridViewTextBoxColumn
    Friend WithEvents TIPONOTA As DataGridViewTextBoxColumn
    Friend WithEvents NOTA As DataGridViewTextBoxColumn
    Friend WithEvents CIERREINTERCONSULTA As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn53 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn54 As DataGridViewTextBoxColumn
    Friend WithEvents TIP_DOC As DataGridViewTextBoxColumn
    Friend WithEvents NUM_DOC As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn55 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn57 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn56 As DataGridViewTextBoxColumn
    Friend WithEvents HORA_EVOL As DataGridViewTextBoxColumn
    Friend WithEvents MIN_EVOL As DataGridViewTextBoxColumn
    Friend WithEvents NOTAS As DataGridViewTextBoxColumn
    Friend WithEvents FEC_CON As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn52 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn67 As DataGridViewTextBoxColumn
    Friend WithEvents ORDEN As DataGridViewTextBoxColumn
    Friend WithEvents CONFIDENCIAL As DataGridViewTextBoxColumn
    Friend WithEvents DIAGACTUAL As DataGridViewTextBoxColumn
    Friend WithEvents SUBJETIVO As DataGridViewTextBoxColumn
    Friend WithEvents INTERPPARACLIC As DataGridViewTextBoxColumn
    Friend WithEvents INTERCONSULTA As DataGridViewTextBoxColumn
    Friend WithEvents Imagenes As DataGridViewLinkColumn
    Friend WithEvents rbInterconNP As RadioButton
End Class
