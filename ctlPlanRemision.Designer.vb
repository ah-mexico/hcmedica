<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlPlanRemision
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctlPlanRemision))
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.pnlInfoImpresionDiagnostica = New System.Windows.Forms.Panel
        Me.Label8 = New System.Windows.Forms.Label
        Me.dtgInfoID = New System.Windows.Forms.DataGridView
        Me.cod_pre_sgsID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cod_sucurID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tip_admisionID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ano_admID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.num_admID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tip_diagID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.diagnostID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descripcionID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clasificacionID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.obsID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.antecedenteID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.confidencialID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.planManejoID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.secuenciaID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clase_diagID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.categoria_diagID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.medicoID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fec_hcID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.sucursalID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.estadousuID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lnkPlandemanejo = New System.Windows.Forms.LinkLabel
        Me.tbCodigoAmbulancia = New HistoriaClinica.TextBoxConFormato
        Me.tbDesAmbulancia = New HistoriaClinica.TextBoxConFormato
        Me.lbNivel = New System.Windows.Forms.Label
        Me.cbNivel = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label110 = New System.Windows.Forms.Label
        Me.lnkMotivoConsulta = New System.Windows.Forms.LinkLabel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbTrasladoambNo = New System.Windows.Forms.RadioButton
        Me.rbTrasladoambSi = New System.Windows.Forms.RadioButton
        Me.txtObs = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.tbMinutoAutoriza = New HistoriaClinica.TextBoxConFormato
        Me.tbHoraAutoriza = New HistoriaClinica.TextBoxConFormato
        Me.lbMinAut = New System.Windows.Forms.Label
        Me.mkFechaAutoriza = New System.Windows.Forms.MaskedTextBox
        Me.lbFechaAut = New System.Windows.Forms.Label
        Me.lbHoraAut = New System.Windows.Forms.Label
        Me.tbNumeroAutoriza = New HistoriaClinica.TextBoxConFormato
        Me.lbNumeroAdmin = New System.Windows.Forms.Label
        Me.tbCargoMedico = New HistoriaClinica.TextBoxConFormato
        Me.tbMedicoConfirma = New HistoriaClinica.TextBoxConFormato
        Me.tbServicio = New HistoriaClinica.TextBoxConFormato
        Me.PFecha = New System.Windows.Forms.Panel
        Me.tbMinuto = New HistoriaClinica.TextBoxConFormato
        Me.tbHora = New HistoriaClinica.TextBoxConFormato
        Me.lbMinuto = New System.Windows.Forms.Label
        Me.mtFechaInicial = New System.Windows.Forms.MaskedTextBox
        Me.lbFecha = New System.Windows.Forms.Label
        Me.lbHora = New System.Windows.Forms.Label
        Me.cbEntidad = New HistoriaClinica.ComboBusqueda(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.tbCodEntidad = New HistoriaClinica.TextBoxConFormato
        Me.lbCargoMedico = New System.Windows.Forms.Label
        Me.lbMedico = New System.Windows.Forms.Label
        Me.lbServicio = New System.Windows.Forms.Label
        Me.lbInstitucion = New System.Windows.Forms.Label
        Me.tbAnamnesis = New System.Windows.Forms.TextBox
        Me.tbAuxiliares = New System.Windows.Forms.TextBox
        Me.tbEvolucion = New System.Windows.Forms.TextBox
        Me.tbDiagnostico = New System.Windows.Forms.TextBox
        Me.tbMotivos = New System.Windows.Forms.TextBox
        Me.TxtScroll = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.pnlContrarreferencia = New System.Windows.Forms.Panel
        Me.TxtScroll1 = New System.Windows.Forms.TextBox
        Me.txtRespuesta = New System.Windows.Forms.TextBox
        Me.lblRespuesta = New System.Windows.Forms.Label
        Me.pGrabar = New System.Windows.Forms.Panel
        Me.btGrabar = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pnlInfoImpresionDiagnostica.SuspendLayout()
        CType(Me.dtgInfoID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.PFecha.SuspendLayout()
        Me.pnlContrarreferencia.SuspendLayout()
        Me.pGrabar.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlInfoImpresionDiagnostica
        '
        Me.pnlInfoImpresionDiagnostica.AutoSize = True
        Me.pnlInfoImpresionDiagnostica.Controls.Add(Me.Label8)
        Me.pnlInfoImpresionDiagnostica.Controls.Add(Me.dtgInfoID)
        Me.pnlInfoImpresionDiagnostica.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlInfoImpresionDiagnostica.Location = New System.Drawing.Point(0, 32)
        Me.pnlInfoImpresionDiagnostica.Name = "pnlInfoImpresionDiagnostica"
        Me.pnlInfoImpresionDiagnostica.Size = New System.Drawing.Size(802, 59)
        Me.pnlInfoImpresionDiagnostica.TabIndex = 40
        Me.pnlInfoImpresionDiagnostica.Visible = False
        '
        'Label8
        '
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(0, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(802, 39)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "IMPRESION DIAGNOSTICA"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtgInfoID
        '
        Me.dtgInfoID.AllowUserToAddRows = False
        Me.dtgInfoID.AllowUserToDeleteRows = False
        Me.dtgInfoID.AllowUserToResizeColumns = False
        Me.dtgInfoID.AllowUserToResizeRows = False
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black
        Me.dtgInfoID.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle15
        Me.dtgInfoID.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtgInfoID.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.dtgInfoID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dtgInfoID.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.dtgInfoID.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgInfoID.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle16
        Me.dtgInfoID.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgInfoID.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cod_pre_sgsID, Me.cod_sucurID, Me.tip_admisionID, Me.ano_admID, Me.num_admID, Me.tip_diagID, Me.diagnostID, Me.descripcionID, Me.clasificacionID, Me.obsID, Me.antecedenteID, Me.confidencialID, Me.planManejoID, Me.secuenciaID, Me.clase_diagID, Me.categoria_diagID, Me.medicoID, Me.fec_hcID, Me.sucursalID, Me.estadousuID})
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgInfoID.DefaultCellStyle = DataGridViewCellStyle18
        Me.dtgInfoID.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dtgInfoID.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtgInfoID.Enabled = False
        Me.dtgInfoID.EnableHeadersVisualStyles = False
        Me.dtgInfoID.GridColor = System.Drawing.Color.Gray
        Me.dtgInfoID.Location = New System.Drawing.Point(0, 39)
        Me.dtgInfoID.MultiSelect = False
        Me.dtgInfoID.Name = "dtgInfoID"
        Me.dtgInfoID.ReadOnly = True
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(210, Byte), Integer))
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgInfoID.RowHeadersDefaultCellStyle = DataGridViewCellStyle19
        Me.dtgInfoID.RowHeadersVisible = False
        Me.dtgInfoID.RowHeadersWidth = 30
        DataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        DataGridViewCellStyle20.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.Gray
        Me.dtgInfoID.RowsDefaultCellStyle = DataGridViewCellStyle20
        Me.dtgInfoID.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.dtgInfoID.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Gray
        Me.dtgInfoID.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.dtgInfoID.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Gray
        Me.dtgInfoID.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgInfoID.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dtgInfoID.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgInfoID.Size = New System.Drawing.Size(802, 20)
        Me.dtgInfoID.TabIndex = 0
        '
        'cod_pre_sgsID
        '
        Me.cod_pre_sgsID.DataPropertyName = "cod_pre_sgs"
        Me.cod_pre_sgsID.HeaderText = "cod_pre_sgs"
        Me.cod_pre_sgsID.Name = "cod_pre_sgsID"
        Me.cod_pre_sgsID.ReadOnly = True
        Me.cod_pre_sgsID.Visible = False
        '
        'cod_sucurID
        '
        Me.cod_sucurID.DataPropertyName = "cod_sucur"
        Me.cod_sucurID.HeaderText = "cod_sucur"
        Me.cod_sucurID.Name = "cod_sucurID"
        Me.cod_sucurID.ReadOnly = True
        Me.cod_sucurID.Visible = False
        '
        'tip_admisionID
        '
        Me.tip_admisionID.DataPropertyName = "tip_admision"
        Me.tip_admisionID.HeaderText = "tip_admision"
        Me.tip_admisionID.Name = "tip_admisionID"
        Me.tip_admisionID.ReadOnly = True
        Me.tip_admisionID.Visible = False
        '
        'ano_admID
        '
        Me.ano_admID.DataPropertyName = "ano_adm"
        Me.ano_admID.HeaderText = "ano_adm"
        Me.ano_admID.Name = "ano_admID"
        Me.ano_admID.ReadOnly = True
        Me.ano_admID.Visible = False
        '
        'num_admID
        '
        Me.num_admID.DataPropertyName = "num_adm"
        Me.num_admID.HeaderText = "num_adm"
        Me.num_admID.Name = "num_admID"
        Me.num_admID.ReadOnly = True
        Me.num_admID.Visible = False
        '
        'tip_diagID
        '
        Me.tip_diagID.DataPropertyName = "tip_diag"
        Me.tip_diagID.HeaderText = "tip_diag"
        Me.tip_diagID.Name = "tip_diagID"
        Me.tip_diagID.ReadOnly = True
        Me.tip_diagID.Visible = False
        '
        'diagnostID
        '
        Me.diagnostID.DataPropertyName = "diagnost"
        Me.diagnostID.HeaderText = "diagnost"
        Me.diagnostID.Name = "diagnostID"
        Me.diagnostID.ReadOnly = True
        Me.diagnostID.Visible = False
        '
        'descripcionID
        '
        Me.descripcionID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.descripcionID.DataPropertyName = "descripcion"
        Me.descripcionID.HeaderText = "DIAGNÓSTICO"
        Me.descripcionID.Name = "descripcionID"
        Me.descripcionID.ReadOnly = True
        Me.descripcionID.Width = 355
        '
        'clasificacionID
        '
        Me.clasificacionID.DataPropertyName = "clasificacion"
        Me.clasificacionID.HeaderText = "clasificacion"
        Me.clasificacionID.Name = "clasificacionID"
        Me.clasificacionID.ReadOnly = True
        Me.clasificacionID.Visible = False
        '
        'obsID
        '
        Me.obsID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.obsID.DataPropertyName = "obs"
        Me.obsID.HeaderText = "OBSERVACIONES"
        Me.obsID.Name = "obsID"
        Me.obsID.ReadOnly = True
        Me.obsID.Width = 342
        '
        'antecedenteID
        '
        Me.antecedenteID.DataPropertyName = "antecedente"
        Me.antecedenteID.HeaderText = "antecedente"
        Me.antecedenteID.Name = "antecedenteID"
        Me.antecedenteID.ReadOnly = True
        Me.antecedenteID.Visible = False
        '
        'confidencialID
        '
        Me.confidencialID.DataPropertyName = "confidencial"
        Me.confidencialID.HeaderText = "confidencial"
        Me.confidencialID.Name = "confidencialID"
        Me.confidencialID.ReadOnly = True
        Me.confidencialID.Visible = False
        '
        'planManejoID
        '
        Me.planManejoID.DataPropertyName = "planmanejo"
        Me.planManejoID.HeaderText = "planManejo"
        Me.planManejoID.Name = "planManejoID"
        Me.planManejoID.ReadOnly = True
        Me.planManejoID.Visible = False
        '
        'secuenciaID
        '
        Me.secuenciaID.DataPropertyName = "secuencia"
        Me.secuenciaID.HeaderText = "secuencia"
        Me.secuenciaID.Name = "secuenciaID"
        Me.secuenciaID.ReadOnly = True
        Me.secuenciaID.Visible = False
        '
        'clase_diagID
        '
        Me.clase_diagID.DataPropertyName = "clase_diag"
        Me.clase_diagID.HeaderText = "clase_diag"
        Me.clase_diagID.Name = "clase_diagID"
        Me.clase_diagID.ReadOnly = True
        Me.clase_diagID.Visible = False
        '
        'categoria_diagID
        '
        Me.categoria_diagID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.categoria_diagID.DataPropertyName = "categoria_diag"
        Me.categoria_diagID.HeaderText = "CATEGORIA"
        Me.categoria_diagID.Name = "categoria_diagID"
        Me.categoria_diagID.ReadOnly = True
        '
        'medicoID
        '
        Me.medicoID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.medicoID.DataPropertyName = "medico"
        Me.medicoID.HeaderText = "MÉDICO"
        Me.medicoID.Name = "medicoID"
        Me.medicoID.ReadOnly = True
        Me.medicoID.Visible = False
        Me.medicoID.Width = 203
        '
        'fec_hcID
        '
        Me.fec_hcID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.fec_hcID.DataPropertyName = "fec_hc"
        DataGridViewCellStyle17.Format = "d"
        DataGridViewCellStyle17.NullValue = Nothing
        Me.fec_hcID.DefaultCellStyle = DataGridViewCellStyle17
        Me.fec_hcID.HeaderText = "FECHA"
        Me.fec_hcID.Name = "fec_hcID"
        Me.fec_hcID.ReadOnly = True
        Me.fec_hcID.Visible = False
        Me.fec_hcID.Width = 83
        '
        'sucursalID
        '
        Me.sucursalID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.sucursalID.DataPropertyName = "sucursal"
        Me.sucursalID.HeaderText = "SUCURSAL"
        Me.sucursalID.Name = "sucursalID"
        Me.sucursalID.ReadOnly = True
        Me.sucursalID.Visible = False
        Me.sucursalID.Width = 145
        '
        'estadousuID
        '
        Me.estadousuID.DataPropertyName = "estadousu"
        Me.estadousuID.HeaderText = "estadousu"
        Me.estadousuID.Name = "estadousuID"
        Me.estadousuID.ReadOnly = True
        Me.estadousuID.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lnkPlandemanejo)
        Me.Panel2.Controls.Add(Me.tbCodigoAmbulancia)
        Me.Panel2.Controls.Add(Me.tbDesAmbulancia)
        Me.Panel2.Controls.Add(Me.lbNivel)
        Me.Panel2.Controls.Add(Me.cbNivel)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label110)
        Me.Panel2.Controls.Add(Me.lnkMotivoConsulta)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.txtObs)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.tbMinutoAutoriza)
        Me.Panel2.Controls.Add(Me.tbHoraAutoriza)
        Me.Panel2.Controls.Add(Me.lbMinAut)
        Me.Panel2.Controls.Add(Me.mkFechaAutoriza)
        Me.Panel2.Controls.Add(Me.lbFechaAut)
        Me.Panel2.Controls.Add(Me.lbHoraAut)
        Me.Panel2.Controls.Add(Me.tbNumeroAutoriza)
        Me.Panel2.Controls.Add(Me.lbNumeroAdmin)
        Me.Panel2.Controls.Add(Me.tbCargoMedico)
        Me.Panel2.Controls.Add(Me.tbMedicoConfirma)
        Me.Panel2.Controls.Add(Me.tbServicio)
        Me.Panel2.Controls.Add(Me.PFecha)
        Me.Panel2.Controls.Add(Me.cbEntidad)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.tbCodEntidad)
        Me.Panel2.Controls.Add(Me.lbCargoMedico)
        Me.Panel2.Controls.Add(Me.lbMedico)
        Me.Panel2.Controls.Add(Me.lbServicio)
        Me.Panel2.Controls.Add(Me.lbInstitucion)
        Me.Panel2.Controls.Add(Me.tbAnamnesis)
        Me.Panel2.Controls.Add(Me.tbAuxiliares)
        Me.Panel2.Controls.Add(Me.tbEvolucion)
        Me.Panel2.Controls.Add(Me.tbDiagnostico)
        Me.Panel2.Controls.Add(Me.tbMotivos)
        Me.Panel2.Controls.Add(Me.TxtScroll)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 91)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(802, 760)
        Me.Panel2.TabIndex = 41
        '
        'lnkPlandemanejo
        '
        Me.lnkPlandemanejo.AutoSize = True
        Me.lnkPlandemanejo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lnkPlandemanejo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lnkPlandemanejo.LinkColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lnkPlandemanejo.Location = New System.Drawing.Point(593, 430)
        Me.lnkPlandemanejo.Name = "lnkPlandemanejo"
        Me.lnkPlandemanejo.Size = New System.Drawing.Size(98, 14)
        Me.lnkPlandemanejo.TabIndex = 93
        Me.lnkPlandemanejo.TabStop = True
        Me.lnkPlandemanejo.Text = "Ir a Evolución"
        '
        'tbCodigoAmbulancia
        '
        Me.tbCodigoAmbulancia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbCodigoAmbulancia.ControlComboEnlace = Nothing
        Me.tbCodigoAmbulancia.ControlTextoEnlace = Nothing
        Me.tbCodigoAmbulancia.DatoRelacionado = Nothing
        Me.tbCodigoAmbulancia.Decimals = CType(0, Byte)
        Me.tbCodigoAmbulancia.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.tbCodigoAmbulancia.Enabled = False
        Me.tbCodigoAmbulancia.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCodigoAmbulancia.Format = HistoriaClinica.tbFormats.AlfaNúmericoSinEspacios
        Me.tbCodigoAmbulancia.Location = New System.Drawing.Point(193, 204)
        Me.tbCodigoAmbulancia.MaxLength = 15
        Me.tbCodigoAmbulancia.Name = "tbCodigoAmbulancia"
        Me.tbCodigoAmbulancia.NombreCampoBuscado = Nothing
        Me.tbCodigoAmbulancia.NombreCampoBusqueda = Nothing
        Me.tbCodigoAmbulancia.NombreCampoDatos = Nothing
        Me.tbCodigoAmbulancia.Obligatorio = False
        Me.tbCodigoAmbulancia.OrigenDeDatos = Nothing
        Me.tbCodigoAmbulancia.PermitirValorCero = False
        Me.tbCodigoAmbulancia.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.tbCodigoAmbulancia.Size = New System.Drawing.Size(100, 22)
        Me.tbCodigoAmbulancia.TabIndex = 90
        Me.tbCodigoAmbulancia.TipoControl = HistoriaClinica.tbTipoControl.CodigoBusqueda
        Me.tbCodigoAmbulancia.UserValues = Nothing
        Me.tbCodigoAmbulancia.ValorMaximo = CType(5, Long)
        Me.tbCodigoAmbulancia.ValorMinimo = CType(1, Long)
        '
        'tbDesAmbulancia
        '
        Me.tbDesAmbulancia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.tbDesAmbulancia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.tbDesAmbulancia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbDesAmbulancia.ControlComboEnlace = Nothing
        Me.tbDesAmbulancia.ControlTextoEnlace = Nothing
        Me.tbDesAmbulancia.DatoRelacionado = Nothing
        Me.tbDesAmbulancia.Decimals = CType(2, Byte)
        Me.tbDesAmbulancia.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.tbDesAmbulancia.Enabled = False
        Me.tbDesAmbulancia.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDesAmbulancia.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.tbDesAmbulancia.Location = New System.Drawing.Point(299, 204)
        Me.tbDesAmbulancia.MaxLength = 100
        Me.tbDesAmbulancia.Name = "tbDesAmbulancia"
        Me.tbDesAmbulancia.NombreCampoBuscado = Nothing
        Me.tbDesAmbulancia.NombreCampoBusqueda = Nothing
        Me.tbDesAmbulancia.NombreCampoDatos = Nothing
        Me.tbDesAmbulancia.Obligatorio = False
        Me.tbDesAmbulancia.OrigenDeDatos = Nothing
        Me.tbDesAmbulancia.PermitirValorCero = False
        Me.tbDesAmbulancia.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.tbDesAmbulancia.Size = New System.Drawing.Size(346, 22)
        Me.tbDesAmbulancia.TabIndex = 91
        Me.tbDesAmbulancia.TipoControl = HistoriaClinica.tbTipoControl.ListaAutoComplete
        Me.tbDesAmbulancia.UserValues = Nothing
        Me.tbDesAmbulancia.ValorMaximo = CType(0, Long)
        Me.tbDesAmbulancia.ValorMinimo = CType(0, Long)
        '
        'lbNivel
        '
        Me.lbNivel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNivel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lbNivel.Location = New System.Drawing.Point(656, 205)
        Me.lbNivel.Name = "lbNivel"
        Me.lbNivel.Size = New System.Drawing.Size(43, 21)
        Me.lbNivel.TabIndex = 89
        Me.lbNivel.Text = "Nivel"
        '
        'cbNivel
        '
        Me.cbNivel.FormattingEnabled = True
        Me.cbNivel.Location = New System.Drawing.Point(706, 203)
        Me.cbNivel.Name = "cbNivel"
        Me.cbNivel.Size = New System.Drawing.Size(91, 21)
        Me.cbNivel.TabIndex = 92
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Salmon
        Me.Label11.Location = New System.Drawing.Point(326, 430)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(13, 15)
        Me.Label11.TabIndex = 88
        Me.Label11.Text = "*"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Salmon
        Me.Label10.Location = New System.Drawing.Point(163, 612)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(13, 15)
        Me.Label10.TabIndex = 88
        Me.Label10.Text = "*"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Salmon
        Me.Label3.Location = New System.Drawing.Point(118, 336)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(13, 15)
        Me.Label3.TabIndex = 86
        Me.Label3.Text = "*"
        '
        'Label110
        '
        Me.Label110.AutoSize = True
        Me.Label110.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label110.ForeColor = System.Drawing.Color.Salmon
        Me.Label110.Location = New System.Drawing.Point(73, 79)
        Me.Label110.Name = "Label110"
        Me.Label110.Size = New System.Drawing.Size(13, 15)
        Me.Label110.TabIndex = 85
        Me.Label110.Text = "*"
        '
        'lnkMotivoConsulta
        '
        Me.lnkMotivoConsulta.AutoSize = True
        Me.lnkMotivoConsulta.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lnkMotivoConsulta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lnkMotivoConsulta.LinkColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lnkMotivoConsulta.Location = New System.Drawing.Point(590, 240)
        Me.lnkMotivoConsulta.Name = "lnkMotivoConsulta"
        Me.lnkMotivoConsulta.Size = New System.Drawing.Size(162, 14)
        Me.lnkMotivoConsulta.TabIndex = 84
        Me.lnkMotivoConsulta.TabStop = True
        Me.lnkMotivoConsulta.Text = "Ir a Motivo De Consulta"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbTrasladoambNo)
        Me.GroupBox1.Controls.Add(Me.rbTrasladoambSi)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(5, 178)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(182, 50)
        Me.GroupBox1.TabIndex = 83
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Traslado en ambulancia"
        '
        'rbTrasladoambNo
        '
        Me.rbTrasladoambNo.AutoSize = True
        Me.rbTrasladoambNo.Location = New System.Drawing.Point(98, 27)
        Me.rbTrasladoambNo.Name = "rbTrasladoambNo"
        Me.rbTrasladoambNo.Size = New System.Drawing.Size(43, 18)
        Me.rbTrasladoambNo.TabIndex = 1
        Me.rbTrasladoambNo.TabStop = True
        Me.rbTrasladoambNo.Text = "No"
        Me.rbTrasladoambNo.UseVisualStyleBackColor = True
        '
        'rbTrasladoambSi
        '
        Me.rbTrasladoambSi.AutoSize = True
        Me.rbTrasladoambSi.Location = New System.Drawing.Point(24, 28)
        Me.rbTrasladoambSi.Name = "rbTrasladoambSi"
        Me.rbTrasladoambSi.Size = New System.Drawing.Size(38, 18)
        Me.rbTrasladoambSi.TabIndex = 0
        Me.rbTrasladoambSi.TabStop = True
        Me.rbTrasladoambSi.Text = "Si"
        Me.rbTrasladoambSi.UseVisualStyleBackColor = True
        '
        'txtObs
        '
        Me.txtObs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObs.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObs.Location = New System.Drawing.Point(7, 680)
        Me.txtObs.MaxLength = 500
        Me.txtObs.Multiline = True
        Me.txtObs.Name = "txtObs"
        Me.txtObs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObs.Size = New System.Drawing.Size(784, 64)
        Me.txtObs.TabIndex = 78
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(3, 662)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(280, 15)
        Me.Label2.TabIndex = 81
        Me.Label2.Text = "Observaciones"
        '
        'tbMinutoAutoriza
        '
        Me.tbMinutoAutoriza.ControlComboEnlace = Nothing
        Me.tbMinutoAutoriza.ControlTextoEnlace = Nothing
        Me.tbMinutoAutoriza.DatoRelacionado = Nothing
        Me.tbMinutoAutoriza.Decimals = CType(0, Byte)
        Me.tbMinutoAutoriza.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.tbMinutoAutoriza.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbMinutoAutoriza.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.tbMinutoAutoriza.Location = New System.Drawing.Point(654, 147)
        Me.tbMinutoAutoriza.MaxLength = 2
        Me.tbMinutoAutoriza.Name = "tbMinutoAutoriza"
        Me.tbMinutoAutoriza.NombreCampoBuscado = Nothing
        Me.tbMinutoAutoriza.NombreCampoBusqueda = Nothing
        Me.tbMinutoAutoriza.NombreCampoDatos = Nothing
        Me.tbMinutoAutoriza.Obligatorio = False
        Me.tbMinutoAutoriza.OrigenDeDatos = Nothing
        Me.tbMinutoAutoriza.PermitirValorCero = False
        Me.tbMinutoAutoriza.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.tbMinutoAutoriza.Size = New System.Drawing.Size(34, 22)
        Me.tbMinutoAutoriza.TabIndex = 66
        Me.tbMinutoAutoriza.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.tbMinutoAutoriza.UserValues = Nothing
        Me.tbMinutoAutoriza.ValorMaximo = CType(59, Long)
        Me.tbMinutoAutoriza.ValorMinimo = CType(0, Long)
        '
        'tbHoraAutoriza
        '
        Me.tbHoraAutoriza.ControlComboEnlace = Nothing
        Me.tbHoraAutoriza.ControlTextoEnlace = Nothing
        Me.tbHoraAutoriza.DatoRelacionado = Nothing
        Me.tbHoraAutoriza.Decimals = CType(0, Byte)
        Me.tbHoraAutoriza.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.tbHoraAutoriza.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbHoraAutoriza.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.tbHoraAutoriza.Location = New System.Drawing.Point(516, 147)
        Me.tbHoraAutoriza.MaxLength = 2
        Me.tbHoraAutoriza.Name = "tbHoraAutoriza"
        Me.tbHoraAutoriza.NombreCampoBuscado = Nothing
        Me.tbHoraAutoriza.NombreCampoBusqueda = Nothing
        Me.tbHoraAutoriza.NombreCampoDatos = Nothing
        Me.tbHoraAutoriza.Obligatorio = False
        Me.tbHoraAutoriza.OrigenDeDatos = Nothing
        Me.tbHoraAutoriza.PermitirValorCero = False
        Me.tbHoraAutoriza.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.tbHoraAutoriza.Size = New System.Drawing.Size(31, 22)
        Me.tbHoraAutoriza.TabIndex = 65
        Me.tbHoraAutoriza.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.tbHoraAutoriza.UserValues = Nothing
        Me.tbHoraAutoriza.ValorMaximo = CType(24, Long)
        Me.tbHoraAutoriza.ValorMinimo = CType(1, Long)
        '
        'lbMinAut
        '
        Me.lbMinAut.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMinAut.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lbMinAut.Location = New System.Drawing.Point(590, 148)
        Me.lbMinAut.Name = "lbMinAut"
        Me.lbMinAut.Size = New System.Drawing.Size(58, 20)
        Me.lbMinAut.TabIndex = 54
        Me.lbMinAut.Text = "Minuto"
        Me.lbMinAut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'mkFechaAutoriza
        '
        Me.mkFechaAutoriza.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mkFechaAutoriza.Location = New System.Drawing.Point(367, 147)
        Me.mkFechaAutoriza.Mask = "00/00/0000"
        Me.mkFechaAutoriza.Name = "mkFechaAutoriza"
        Me.mkFechaAutoriza.Size = New System.Drawing.Size(89, 22)
        Me.mkFechaAutoriza.TabIndex = 64
        Me.mkFechaAutoriza.ValidatingType = GetType(Date)
        '
        'lbFechaAut
        '
        Me.lbFechaAut.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFechaAut.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lbFechaAut.Location = New System.Drawing.Point(303, 148)
        Me.lbFechaAut.Name = "lbFechaAut"
        Me.lbFechaAut.Size = New System.Drawing.Size(58, 20)
        Me.lbFechaAut.TabIndex = 51
        Me.lbFechaAut.Text = "Fecha"
        Me.lbFechaAut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbHoraAut
        '
        Me.lbHoraAut.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbHoraAut.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lbHoraAut.Location = New System.Drawing.Point(471, 149)
        Me.lbHoraAut.Name = "lbHoraAut"
        Me.lbHoraAut.Size = New System.Drawing.Size(46, 20)
        Me.lbHoraAut.TabIndex = 52
        Me.lbHoraAut.Text = "Hora"
        Me.lbHoraAut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbNumeroAutoriza
        '
        Me.tbNumeroAutoriza.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbNumeroAutoriza.ControlComboEnlace = Nothing
        Me.tbNumeroAutoriza.ControlTextoEnlace = Nothing
        Me.tbNumeroAutoriza.DatoRelacionado = Nothing
        Me.tbNumeroAutoriza.Decimals = CType(0, Byte)
        Me.tbNumeroAutoriza.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.tbNumeroAutoriza.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNumeroAutoriza.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.tbNumeroAutoriza.Location = New System.Drawing.Point(181, 147)
        Me.tbNumeroAutoriza.MaxLength = 15
        Me.tbNumeroAutoriza.Name = "tbNumeroAutoriza"
        Me.tbNumeroAutoriza.NombreCampoBuscado = Nothing
        Me.tbNumeroAutoriza.NombreCampoBusqueda = Nothing
        Me.tbNumeroAutoriza.NombreCampoDatos = Nothing
        Me.tbNumeroAutoriza.Obligatorio = False
        Me.tbNumeroAutoriza.OrigenDeDatos = Nothing
        Me.tbNumeroAutoriza.PermitirValorCero = False
        Me.tbNumeroAutoriza.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.tbNumeroAutoriza.Size = New System.Drawing.Size(100, 21)
        Me.tbNumeroAutoriza.TabIndex = 63
        Me.tbNumeroAutoriza.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.tbNumeroAutoriza.UserValues = Nothing
        Me.tbNumeroAutoriza.ValorMaximo = CType(0, Long)
        Me.tbNumeroAutoriza.ValorMinimo = CType(0, Long)
        '
        'lbNumeroAdmin
        '
        Me.lbNumeroAdmin.AutoSize = True
        Me.lbNumeroAdmin.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNumeroAdmin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lbNumeroAdmin.Location = New System.Drawing.Point(2, 148)
        Me.lbNumeroAdmin.Name = "lbNumeroAdmin"
        Me.lbNumeroAdmin.Size = New System.Drawing.Size(144, 14)
        Me.lbNumeroAdmin.TabIndex = 57
        Me.lbNumeroAdmin.Text = "Número autorización"
        '
        'tbCargoMedico
        '
        Me.tbCargoMedico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbCargoMedico.ControlComboEnlace = Nothing
        Me.tbCargoMedico.ControlTextoEnlace = Nothing
        Me.tbCargoMedico.DatoRelacionado = Nothing
        Me.tbCargoMedico.Decimals = CType(0, Byte)
        Me.tbCargoMedico.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.tbCargoMedico.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCargoMedico.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.tbCargoMedico.Location = New System.Drawing.Point(181, 124)
        Me.tbCargoMedico.MaxLength = 60
        Me.tbCargoMedico.Name = "tbCargoMedico"
        Me.tbCargoMedico.NombreCampoBuscado = Nothing
        Me.tbCargoMedico.NombreCampoBusqueda = Nothing
        Me.tbCargoMedico.NombreCampoDatos = Nothing
        Me.tbCargoMedico.Obligatorio = False
        Me.tbCargoMedico.OrigenDeDatos = Nothing
        Me.tbCargoMedico.PermitirValorCero = False
        Me.tbCargoMedico.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.tbCargoMedico.Size = New System.Drawing.Size(336, 21)
        Me.tbCargoMedico.TabIndex = 62
        Me.tbCargoMedico.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.tbCargoMedico.UserValues = Nothing
        Me.tbCargoMedico.ValorMaximo = CType(0, Long)
        Me.tbCargoMedico.ValorMinimo = CType(0, Long)
        '
        'tbMedicoConfirma
        '
        Me.tbMedicoConfirma.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbMedicoConfirma.ControlComboEnlace = Nothing
        Me.tbMedicoConfirma.ControlTextoEnlace = Nothing
        Me.tbMedicoConfirma.DatoRelacionado = Nothing
        Me.tbMedicoConfirma.Decimals = CType(0, Byte)
        Me.tbMedicoConfirma.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.tbMedicoConfirma.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbMedicoConfirma.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.tbMedicoConfirma.Location = New System.Drawing.Point(181, 101)
        Me.tbMedicoConfirma.MaxLength = 30
        Me.tbMedicoConfirma.Name = "tbMedicoConfirma"
        Me.tbMedicoConfirma.NombreCampoBuscado = Nothing
        Me.tbMedicoConfirma.NombreCampoBusqueda = Nothing
        Me.tbMedicoConfirma.NombreCampoDatos = Nothing
        Me.tbMedicoConfirma.Obligatorio = False
        Me.tbMedicoConfirma.OrigenDeDatos = Nothing
        Me.tbMedicoConfirma.PermitirValorCero = False
        Me.tbMedicoConfirma.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.tbMedicoConfirma.Size = New System.Drawing.Size(336, 21)
        Me.tbMedicoConfirma.TabIndex = 61
        Me.tbMedicoConfirma.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.tbMedicoConfirma.UserValues = Nothing
        Me.tbMedicoConfirma.ValorMaximo = CType(0, Long)
        Me.tbMedicoConfirma.ValorMinimo = CType(0, Long)
        '
        'tbServicio
        '
        Me.tbServicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbServicio.ControlComboEnlace = Nothing
        Me.tbServicio.ControlTextoEnlace = Nothing
        Me.tbServicio.DatoRelacionado = Nothing
        Me.tbServicio.Decimals = CType(0, Byte)
        Me.tbServicio.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.tbServicio.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbServicio.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.tbServicio.Location = New System.Drawing.Point(181, 78)
        Me.tbServicio.MaxLength = 60
        Me.tbServicio.Name = "tbServicio"
        Me.tbServicio.NombreCampoBuscado = Nothing
        Me.tbServicio.NombreCampoBusqueda = Nothing
        Me.tbServicio.NombreCampoDatos = Nothing
        Me.tbServicio.Obligatorio = False
        Me.tbServicio.OrigenDeDatos = Nothing
        Me.tbServicio.PermitirValorCero = False
        Me.tbServicio.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.tbServicio.Size = New System.Drawing.Size(336, 21)
        Me.tbServicio.TabIndex = 60
        Me.tbServicio.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.tbServicio.UserValues = Nothing
        Me.tbServicio.ValorMaximo = CType(0, Long)
        Me.tbServicio.ValorMinimo = CType(0, Long)
        '
        'PFecha
        '
        Me.PFecha.Controls.Add(Me.tbMinuto)
        Me.PFecha.Controls.Add(Me.tbHora)
        Me.PFecha.Controls.Add(Me.lbMinuto)
        Me.PFecha.Controls.Add(Me.mtFechaInicial)
        Me.PFecha.Controls.Add(Me.lbFecha)
        Me.PFecha.Controls.Add(Me.lbHora)
        Me.PFecha.Location = New System.Drawing.Point(7, 11)
        Me.PFecha.Name = "PFecha"
        Me.PFecha.Size = New System.Drawing.Size(762, 33)
        Me.PFecha.TabIndex = 43
        '
        'tbMinuto
        '
        Me.tbMinuto.ControlComboEnlace = Nothing
        Me.tbMinuto.ControlTextoEnlace = Nothing
        Me.tbMinuto.DatoRelacionado = Nothing
        Me.tbMinuto.Decimals = CType(0, Byte)
        Me.tbMinuto.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.tbMinuto.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbMinuto.Format = HistoriaClinica.tbFormats.NúmericoEnteroSinSigno
        Me.tbMinuto.Location = New System.Drawing.Point(515, 3)
        Me.tbMinuto.MaxLength = 2
        Me.tbMinuto.Name = "tbMinuto"
        Me.tbMinuto.NombreCampoBuscado = Nothing
        Me.tbMinuto.NombreCampoBusqueda = Nothing
        Me.tbMinuto.NombreCampoDatos = Nothing
        Me.tbMinuto.Obligatorio = False
        Me.tbMinuto.OrigenDeDatos = Nothing
        Me.tbMinuto.PermitirValorCero = False
        Me.tbMinuto.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.tbMinuto.Size = New System.Drawing.Size(36, 22)
        Me.tbMinuto.TabIndex = 5
        Me.tbMinuto.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.tbMinuto.UserValues = Nothing
        Me.tbMinuto.ValorMaximo = CType(59, Long)
        Me.tbMinuto.ValorMinimo = CType(0, Long)
        '
        'tbHora
        '
        Me.tbHora.ControlComboEnlace = Nothing
        Me.tbHora.ControlTextoEnlace = Nothing
        Me.tbHora.DatoRelacionado = Nothing
        Me.tbHora.Decimals = CType(0, Byte)
        Me.tbHora.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.tbHora.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbHora.Format = HistoriaClinica.tbFormats.NúmericoEnteroSinSigno
        Me.tbHora.Location = New System.Drawing.Point(294, 4)
        Me.tbHora.MaxLength = 2
        Me.tbHora.Name = "tbHora"
        Me.tbHora.NombreCampoBuscado = Nothing
        Me.tbHora.NombreCampoBusqueda = Nothing
        Me.tbHora.NombreCampoDatos = Nothing
        Me.tbHora.Obligatorio = False
        Me.tbHora.OrigenDeDatos = Nothing
        Me.tbHora.PermitirValorCero = False
        Me.tbHora.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.tbHora.Size = New System.Drawing.Size(35, 22)
        Me.tbHora.TabIndex = 4
        Me.tbHora.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.tbHora.UserValues = Nothing
        Me.tbHora.ValorMaximo = CType(23, Long)
        Me.tbHora.ValorMinimo = CType(0, Long)
        '
        'lbMinuto
        '
        Me.lbMinuto.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMinuto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lbMinuto.Location = New System.Drawing.Point(450, 4)
        Me.lbMinuto.Name = "lbMinuto"
        Me.lbMinuto.Size = New System.Drawing.Size(58, 20)
        Me.lbMinuto.TabIndex = 0
        Me.lbMinuto.Text = "Minuto"
        Me.lbMinuto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'mtFechaInicial
        '
        Me.mtFechaInicial.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtFechaInicial.Location = New System.Drawing.Point(55, 6)
        Me.mtFechaInicial.Mask = "00/00/0000"
        Me.mtFechaInicial.Name = "mtFechaInicial"
        Me.mtFechaInicial.Size = New System.Drawing.Size(90, 22)
        Me.mtFechaInicial.TabIndex = 1
        Me.mtFechaInicial.ValidatingType = GetType(Date)
        '
        'lbFecha
        '
        Me.lbFecha.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFecha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lbFecha.Location = New System.Drawing.Point(3, 6)
        Me.lbFecha.Name = "lbFecha"
        Me.lbFecha.Size = New System.Drawing.Size(46, 20)
        Me.lbFecha.TabIndex = 0
        Me.lbFecha.Text = "Fecha"
        Me.lbFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbHora
        '
        Me.lbHora.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbHora.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lbHora.Location = New System.Drawing.Point(240, 5)
        Me.lbHora.Name = "lbHora"
        Me.lbHora.Size = New System.Drawing.Size(58, 20)
        Me.lbHora.TabIndex = 0
        Me.lbHora.Text = "Hora"
        Me.lbHora.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbEntidad
        '
        Me.cbEntidad.CampoEnlazado = Nothing
        Me.cbEntidad.CampoMostrar = Nothing
        Me.cbEntidad.CategoriaDatos = HistoriaClinica.CategoriaDatos.Entidades
        Me.cbEntidad.CodigoTipoProcedimiento = Nothing
        Me.cbEntidad.ControlTextoEnlace = Nothing
        Me.cbEntidad.ControlTieneCache = True
        Me.cbEntidad.ConvenioMedicamento = False
        Me.cbEntidad.DatoRelacionado = Nothing
        Me.cbEntidad.EdadPaciente = 0
        Me.cbEntidad.Entidad = Nothing
        Me.cbEntidad.EstadoMedicamento = False
        Me.cbEntidad.FechaInicialMedicamento = Nothing
        Me.cbEntidad.FormattingEnabled = True
        Me.cbEntidad.Location = New System.Drawing.Point(287, 54)
        Me.cbEntidad.Login = Nothing
        Me.cbEntidad.Medicamento = Nothing
        Me.cbEntidad.Name = "cbEntidad"
        Me.cbEntidad.Obligatorio = "False"
        Me.cbEntidad.Prestador = Nothing
        Me.cbEntidad.SeleccionadoConEnter = False
        Me.cbEntidad.SexoPaciente = Nothing
        Me.cbEntidad.Size = New System.Drawing.Size(403, 21)
        Me.cbEntidad.Sucursal = Nothing
        Me.cbEntidad.TabIndex = 59
        Me.cbEntidad.UltimaDescripcionDeBusqueda = Nothing
        Me.cbEntidad.ValorCampoEnlazado = Nothing
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(2, 240)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(307, 14)
        Me.Label7.TabIndex = 44
        Me.Label7.Text = "1. Motivo de Consulta y Enfermedad Actual"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(2, 335)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(144, 16)
        Me.Label6.TabIndex = 39
        Me.Label6.Text = "2. Antecedentes"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(2, 520)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(334, 17)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "4. Resumen de Evolución y Condición al Egreso"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(3, 611)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(195, 16)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "5. Motivos de remisión"
        '
        'tbCodEntidad
        '
        Me.tbCodEntidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbCodEntidad.ControlComboEnlace = Nothing
        Me.tbCodEntidad.ControlTextoEnlace = Nothing
        Me.tbCodEntidad.DatoRelacionado = Nothing
        Me.tbCodEntidad.Decimals = CType(0, Byte)
        Me.tbCodEntidad.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.tbCodEntidad.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCodEntidad.Format = HistoriaClinica.tbFormats.NúmericoEnteroSinSigno
        Me.tbCodEntidad.Location = New System.Drawing.Point(181, 54)
        Me.tbCodEntidad.MaxLength = 15
        Me.tbCodEntidad.Name = "tbCodEntidad"
        Me.tbCodEntidad.NombreCampoBuscado = Nothing
        Me.tbCodEntidad.NombreCampoBusqueda = Nothing
        Me.tbCodEntidad.NombreCampoDatos = Nothing
        Me.tbCodEntidad.Obligatorio = False
        Me.tbCodEntidad.OrigenDeDatos = Nothing
        Me.tbCodEntidad.PermitirValorCero = False
        Me.tbCodEntidad.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.tbCodEntidad.Size = New System.Drawing.Size(100, 22)
        Me.tbCodEntidad.TabIndex = 58
        Me.tbCodEntidad.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.tbCodEntidad.UserValues = Nothing
        Me.tbCodEntidad.ValorMaximo = CType(0, Long)
        Me.tbCodEntidad.ValorMinimo = CType(0, Long)
        '
        'lbCargoMedico
        '
        Me.lbCargoMedico.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCargoMedico.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lbCargoMedico.Location = New System.Drawing.Point(2, 126)
        Me.lbCargoMedico.Name = "lbCargoMedico"
        Me.lbCargoMedico.Size = New System.Drawing.Size(155, 20)
        Me.lbCargoMedico.TabIndex = 47
        Me.lbCargoMedico.Text = "Cargo quien confirma"
        '
        'lbMedico
        '
        Me.lbMedico.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMedico.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lbMedico.Location = New System.Drawing.Point(2, 101)
        Me.lbMedico.Name = "lbMedico"
        Me.lbMedico.Size = New System.Drawing.Size(173, 20)
        Me.lbMedico.TabIndex = 42
        Me.lbMedico.Text = "Persona quien confirma"
        '
        'lbServicio
        '
        Me.lbServicio.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbServicio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lbServicio.Location = New System.Drawing.Point(2, 78)
        Me.lbServicio.Name = "lbServicio"
        Me.lbServicio.Size = New System.Drawing.Size(65, 22)
        Me.lbServicio.TabIndex = 53
        Me.lbServicio.Text = "Servicio"
        '
        'lbInstitucion
        '
        Me.lbInstitucion.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbInstitucion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lbInstitucion.Location = New System.Drawing.Point(2, 56)
        Me.lbInstitucion.Name = "lbInstitucion"
        Me.lbInstitucion.Size = New System.Drawing.Size(135, 22)
        Me.lbInstitucion.TabIndex = 55
        Me.lbInstitucion.Text = "Prestador destino"
        '
        'tbAnamnesis
        '
        Me.tbAnamnesis.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbAnamnesis.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbAnamnesis.Location = New System.Drawing.Point(8, 260)
        Me.tbAnamnesis.MaxLength = 500
        Me.tbAnamnesis.Multiline = True
        Me.tbAnamnesis.Name = "tbAnamnesis"
        Me.tbAnamnesis.ReadOnly = True
        Me.tbAnamnesis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbAnamnesis.Size = New System.Drawing.Size(786, 70)
        Me.tbAnamnesis.TabIndex = 70
        '
        'tbAuxiliares
        '
        Me.tbAuxiliares.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbAuxiliares.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbAuxiliares.Location = New System.Drawing.Point(9, 354)
        Me.tbAuxiliares.MaxLength = 500
        Me.tbAuxiliares.Multiline = True
        Me.tbAuxiliares.Name = "tbAuxiliares"
        Me.tbAuxiliares.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbAuxiliares.Size = New System.Drawing.Size(785, 70)
        Me.tbAuxiliares.TabIndex = 71
        '
        'tbEvolucion
        '
        Me.tbEvolucion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbEvolucion.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbEvolucion.Location = New System.Drawing.Point(8, 448)
        Me.tbEvolucion.MaxLength = 500
        Me.tbEvolucion.Multiline = True
        Me.tbEvolucion.Name = "tbEvolucion"
        Me.tbEvolucion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbEvolucion.Size = New System.Drawing.Size(786, 70)
        Me.tbEvolucion.TabIndex = 72
        '
        'tbDiagnostico
        '
        Me.tbDiagnostico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbDiagnostico.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDiagnostico.Location = New System.Drawing.Point(7, 538)
        Me.tbDiagnostico.MaxLength = 500
        Me.tbDiagnostico.Multiline = True
        Me.tbDiagnostico.Name = "tbDiagnostico"
        Me.tbDiagnostico.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbDiagnostico.Size = New System.Drawing.Size(787, 70)
        Me.tbDiagnostico.TabIndex = 73
        '
        'tbMotivos
        '
        Me.tbMotivos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbMotivos.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbMotivos.Location = New System.Drawing.Point(6, 630)
        Me.tbMotivos.MaxLength = 500
        Me.tbMotivos.Name = "tbMotivos"
        Me.tbMotivos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbMotivos.Size = New System.Drawing.Size(787, 22)
        Me.tbMotivos.TabIndex = 76
        '
        'TxtScroll
        '
        Me.TxtScroll.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.TxtScroll.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtScroll.Location = New System.Drawing.Point(267, 385)
        Me.TxtScroll.Name = "TxtScroll"
        Me.TxtScroll.Size = New System.Drawing.Size(15, 13)
        Me.TxtScroll.TabIndex = 82
        Me.TxtScroll.Visible = False
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(2, 429)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(372, 15)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "3. Examen Físico, Diagnóstico y Plan de Manejo"
        '
        'pnlContrarreferencia
        '
        Me.pnlContrarreferencia.Controls.Add(Me.TxtScroll1)
        Me.pnlContrarreferencia.Controls.Add(Me.txtRespuesta)
        Me.pnlContrarreferencia.Controls.Add(Me.lblRespuesta)
        Me.pnlContrarreferencia.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlContrarreferencia.Location = New System.Drawing.Point(0, 851)
        Me.pnlContrarreferencia.Name = "pnlContrarreferencia"
        Me.pnlContrarreferencia.Size = New System.Drawing.Size(802, 80)
        Me.pnlContrarreferencia.TabIndex = 42
        Me.pnlContrarreferencia.Visible = False
        '
        'TxtScroll1
        '
        Me.TxtScroll1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.TxtScroll1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtScroll1.Location = New System.Drawing.Point(117, 6)
        Me.TxtScroll1.Name = "TxtScroll1"
        Me.TxtScroll1.Size = New System.Drawing.Size(19, 13)
        Me.TxtScroll1.TabIndex = 86
        Me.TxtScroll1.Visible = False
        '
        'txtRespuesta
        '
        Me.txtRespuesta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRespuesta.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRespuesta.Location = New System.Drawing.Point(7, 30)
        Me.txtRespuesta.MaxLength = 1000
        Me.txtRespuesta.Multiline = True
        Me.txtRespuesta.Name = "txtRespuesta"
        Me.txtRespuesta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRespuesta.Size = New System.Drawing.Size(784, 40)
        Me.txtRespuesta.TabIndex = 83
        '
        'lblRespuesta
        '
        Me.lblRespuesta.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRespuesta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblRespuesta.Location = New System.Drawing.Point(7, 12)
        Me.lblRespuesta.Name = "lblRespuesta"
        Me.lblRespuesta.Size = New System.Drawing.Size(280, 15)
        Me.lblRespuesta.TabIndex = 85
        Me.lblRespuesta.Text = "Respuesta"
        '
        'pGrabar
        '
        Me.pGrabar.Controls.Add(Me.btGrabar)
        Me.pGrabar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pGrabar.Location = New System.Drawing.Point(0, 931)
        Me.pGrabar.Name = "pGrabar"
        Me.pGrabar.Size = New System.Drawing.Size(802, 43)
        Me.pGrabar.TabIndex = 85
        '
        'btGrabar
        '
        Me.btGrabar.BackColor = System.Drawing.Color.Transparent
        Me.btGrabar.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_guardar_mostrar
        Me.btGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btGrabar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btGrabar.ForeColor = System.Drawing.Color.Transparent
        Me.btGrabar.Location = New System.Drawing.Point(344, 6)
        Me.btGrabar.Name = "btGrabar"
        Me.btGrabar.Size = New System.Drawing.Size(112, 27)
        Me.btGrabar.TabIndex = 0
        Me.btGrabar.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.imag_22
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(802, 32)
        Me.Panel1.TabIndex = 35
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "cod_pre_sgs"
        Me.DataGridViewTextBoxColumn1.HeaderText = "cod_pre_sgs"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "cod_sucur"
        Me.DataGridViewTextBoxColumn2.HeaderText = "cod_sucur"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "tip_admision"
        Me.DataGridViewTextBoxColumn3.HeaderText = "tip_admision"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "ano_adm"
        Me.DataGridViewTextBoxColumn4.HeaderText = "ano_adm"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Visible = False
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "num_adm"
        Me.DataGridViewTextBoxColumn5.HeaderText = "num_adm"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "tip_diag"
        Me.DataGridViewTextBoxColumn6.HeaderText = "tip_diag"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Visible = False
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "diagnost"
        Me.DataGridViewTextBoxColumn7.HeaderText = "diagnost"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Visible = False
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "descripcion"
        Me.DataGridViewTextBoxColumn8.HeaderText = "DIAGNÓSTICO"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 355
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "clasificacion"
        Me.DataGridViewTextBoxColumn9.HeaderText = "clasificacion"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Visible = False
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "obs"
        Me.DataGridViewTextBoxColumn10.HeaderText = "OBSERVACIONES"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 342
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "antecedente"
        Me.DataGridViewTextBoxColumn11.HeaderText = "antecedente"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Visible = False
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "confidencial"
        Me.DataGridViewTextBoxColumn12.HeaderText = "confidencial"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Visible = False
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "planmanejo"
        Me.DataGridViewTextBoxColumn13.HeaderText = "planManejo"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Visible = False
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "secuencia"
        Me.DataGridViewTextBoxColumn14.HeaderText = "secuencia"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.Visible = False
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "clase_diag"
        Me.DataGridViewTextBoxColumn15.HeaderText = "clase_diag"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        Me.DataGridViewTextBoxColumn15.Visible = False
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "categoria_diag"
        Me.DataGridViewTextBoxColumn16.HeaderText = "CATEGORIA"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "medico"
        Me.DataGridViewTextBoxColumn17.HeaderText = "MÉDICO"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        Me.DataGridViewTextBoxColumn17.Visible = False
        Me.DataGridViewTextBoxColumn17.Width = 203
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "fec_hc"
        DataGridViewCellStyle21.Format = "d"
        DataGridViewCellStyle21.NullValue = Nothing
        Me.DataGridViewTextBoxColumn18.DefaultCellStyle = DataGridViewCellStyle21
        Me.DataGridViewTextBoxColumn18.HeaderText = "FECHA"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        Me.DataGridViewTextBoxColumn18.Visible = False
        Me.DataGridViewTextBoxColumn18.Width = 83
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "sucursal"
        Me.DataGridViewTextBoxColumn19.HeaderText = "SUCURSAL"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.ReadOnly = True
        Me.DataGridViewTextBoxColumn19.Visible = False
        Me.DataGridViewTextBoxColumn19.Width = 145
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "estadousu"
        Me.DataGridViewTextBoxColumn20.HeaderText = "estadousu"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.ReadOnly = True
        Me.DataGridViewTextBoxColumn20.Visible = False
        '
        'ctlPlanRemision
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Controls.Add(Me.pGrabar)
        Me.Controls.Add(Me.pnlContrarreferencia)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlInfoImpresionDiagnostica)
        Me.Controls.Add(Me.Panel1)
        Me.Location = New System.Drawing.Point(0, 5)
        Me.Name = "ctlPlanRemision"
        Me.Size = New System.Drawing.Size(802, 1020)
        Me.pnlInfoImpresionDiagnostica.ResumeLayout(False)
        CType(Me.dtgInfoID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.PFecha.ResumeLayout(False)
        Me.PFecha.PerformLayout()
        Me.pnlContrarreferencia.ResumeLayout(False)
        Me.pnlContrarreferencia.PerformLayout()
        Me.pGrabar.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel

    Friend WithEvents pnlInfoImpresionDiagnostica As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtgInfoID As System.Windows.Forms.DataGridView
    Friend WithEvents cod_pre_sgsID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cod_sucurID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tip_admisionID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ano_admID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents num_admID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tip_diagID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents diagnostID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descripcionID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clasificacionID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents obsID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents antecedenteID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents confidencialID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents planManejoID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents secuenciaID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clase_diagID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents categoria_diagID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents medicoID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fec_hcID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sucursalID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents estadousuID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtObs As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbMinutoAutoriza As HistoriaClinica.TextBoxConFormato
    Friend WithEvents tbHoraAutoriza As HistoriaClinica.TextBoxConFormato
    Friend WithEvents lbMinAut As System.Windows.Forms.Label
    Friend WithEvents mkFechaAutoriza As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lbFechaAut As System.Windows.Forms.Label
    Friend WithEvents lbHoraAut As System.Windows.Forms.Label
    Friend WithEvents tbNumeroAutoriza As HistoriaClinica.TextBoxConFormato
    Friend WithEvents lbNumeroAdmin As System.Windows.Forms.Label
    Friend WithEvents tbCargoMedico As HistoriaClinica.TextBoxConFormato
    Friend WithEvents tbMedicoConfirma As HistoriaClinica.TextBoxConFormato
    Friend WithEvents tbServicio As HistoriaClinica.TextBoxConFormato
    Friend WithEvents PFecha As System.Windows.Forms.Panel
    Friend WithEvents tbMinuto As HistoriaClinica.TextBoxConFormato
    Friend WithEvents tbHora As HistoriaClinica.TextBoxConFormato
    Friend WithEvents lbMinuto As System.Windows.Forms.Label
    Friend WithEvents mtFechaInicial As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lbFecha As System.Windows.Forms.Label
    Friend WithEvents lbHora As System.Windows.Forms.Label
    Friend WithEvents cbEntidad As HistoriaClinica.ComboBusqueda
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbCodEntidad As HistoriaClinica.TextBoxConFormato
    Friend WithEvents lbCargoMedico As System.Windows.Forms.Label
    Friend WithEvents lbMedico As System.Windows.Forms.Label
    Friend WithEvents lbServicio As System.Windows.Forms.Label
    Friend WithEvents lbInstitucion As System.Windows.Forms.Label
    Friend WithEvents tbAnamnesis As System.Windows.Forms.TextBox
    Friend WithEvents tbAuxiliares As System.Windows.Forms.TextBox
    Friend WithEvents tbEvolucion As System.Windows.Forms.TextBox
    Friend WithEvents tbDiagnostico As System.Windows.Forms.TextBox
    Friend WithEvents tbMotivos As System.Windows.Forms.TextBox
    Friend WithEvents pnlContrarreferencia As System.Windows.Forms.Panel
    Friend WithEvents txtRespuesta As System.Windows.Forms.TextBox
    Friend WithEvents lblRespuesta As System.Windows.Forms.Label
    Friend WithEvents pGrabar As System.Windows.Forms.Panel
    Friend WithEvents btGrabar As System.Windows.Forms.Button
    Friend WithEvents TxtScroll As System.Windows.Forms.TextBox
    Friend WithEvents TxtScroll1 As System.Windows.Forms.TextBox
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
    Friend WithEvents lnkMotivoConsulta As System.Windows.Forms.LinkLabel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label110 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tbCodigoAmbulancia As HistoriaClinica.TextBoxConFormato
    Friend WithEvents tbDesAmbulancia As HistoriaClinica.TextBoxConFormato
    Friend WithEvents lbNivel As System.Windows.Forms.Label
    Friend WithEvents cbNivel As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbTrasladoambNo As System.Windows.Forms.RadioButton
    Friend WithEvents rbTrasladoambSi As System.Windows.Forms.RadioButton
    Friend WithEvents lnkPlandemanejo As System.Windows.Forms.LinkLabel
End Class
