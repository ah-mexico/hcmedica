<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaEsperaError
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtgLista = New System.Windows.Forms.DataGridView
        Me.tip_doc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.num_doc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NOMBRE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ADMISION = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fec_hc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cod_pre_sgs = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cod_sucur = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tip_admision = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ano_adm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.num_adm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.estado = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fec_con = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.login = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pri_ape = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.seg_ape = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pri_nom = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.seg_nom = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gbDatos = New System.Windows.Forms.Panel
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.rbtConsultaOpcionAdmision = New System.Windows.Forms.RadioButton
        Me.rbtConsultaOpcionDocumento = New System.Windows.Forms.RadioButton
        Me.rbtConsultaOpcionSucursal = New System.Windows.Forms.RadioButton
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.txtNumeroAdmision = New HistoriaClinica.TextBoxConFormato
        Me.txtAnoAdmision = New HistoriaClinica.TextBoxConFormato
        Me.txtTipoAdmision = New HistoriaClinica.TextBoxConFormato
        Me.lNumAdmin = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.txtNumeroDocumento = New HistoriaClinica.TextBoxConFormato
        Me.txtDescTipoDocumento = New HistoriaClinica.TextBoxConFormato
        Me.txtCodigoTipoDocumento = New HistoriaClinica.TextBoxConFormato
        Me.lNumIde = New System.Windows.Forms.Label
        Me.ltipoIde = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.dtFecIni = New System.Windows.Forms.MaskedTextBox
        Me.dtFecFin = New System.Windows.Forms.MaskedTextBox
        Me.cboSucursal = New HistoriaClinica.TextBoxConFormato
        Me.txtCodigoSucursal = New HistoriaClinica.TextBoxConFormato
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.rbUrgencias = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdLista = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
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
        CType(Me.dtgLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatos.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.CornflowerBlue
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(206, -49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(404, 32)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Lista de Pacientes en Espera"
        '
        'dtgLista
        '
        Me.dtgLista.AllowUserToAddRows = False
        Me.dtgLista.AllowUserToDeleteRows = False
        Me.dtgLista.AllowUserToResizeColumns = False
        Me.dtgLista.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.dtgLista.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgLista.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtgLista.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgLista.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtgLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgLista.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tip_doc, Me.num_doc, Me.NOMBRE, Me.ADMISION, Me.fec_hc, Me.cod_pre_sgs, Me.cod_sucur, Me.tip_admision, Me.ano_adm, Me.num_adm, Me.estado, Me.fec_con, Me.login, Me.pri_ape, Me.seg_ape, Me.pri_nom, Me.seg_nom})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(210, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgLista.DefaultCellStyle = DataGridViewCellStyle3
        Me.dtgLista.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtgLista.GridColor = System.Drawing.Color.Gray
        Me.dtgLista.Location = New System.Drawing.Point(0, 314)
        Me.dtgLista.Name = "dtgLista"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(210, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgLista.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dtgLista.RowHeadersVisible = False
        Me.dtgLista.RowHeadersWidth = 10
        Me.dtgLista.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dtgLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgLista.Size = New System.Drawing.Size(665, 282)
        Me.dtgLista.TabIndex = 1
        '
        'tip_doc
        '
        Me.tip_doc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.tip_doc.DataPropertyName = "tip_doc"
        Me.tip_doc.HeaderText = "TIPO DOC."
        Me.tip_doc.Name = "tip_doc"
        Me.tip_doc.ReadOnly = True
        Me.tip_doc.Width = 50
        '
        'num_doc
        '
        Me.num_doc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.num_doc.DataPropertyName = "num_doc"
        Me.num_doc.HeaderText = "No. DOCUMENTO"
        Me.num_doc.Name = "num_doc"
        Me.num_doc.ReadOnly = True
        Me.num_doc.Width = 140
        '
        'NOMBRE
        '
        Me.NOMBRE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.NOMBRE.DataPropertyName = "nombre"
        Me.NOMBRE.HeaderText = "NOMBRE"
        Me.NOMBRE.Name = "NOMBRE"
        Me.NOMBRE.ReadOnly = True
        Me.NOMBRE.Width = 300
        '
        'ADMISION
        '
        Me.ADMISION.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ADMISION.DataPropertyName = "admision"
        Me.ADMISION.HeaderText = "ADMISION"
        Me.ADMISION.Name = "ADMISION"
        Me.ADMISION.ReadOnly = True
        Me.ADMISION.Width = 80
        '
        'fec_hc
        '
        Me.fec_hc.DataPropertyName = "fec_hc"
        Me.fec_hc.HeaderText = "FECHA"
        Me.fec_hc.Name = "fec_hc"
        Me.fec_hc.ReadOnly = True
        '
        'cod_pre_sgs
        '
        Me.cod_pre_sgs.DataPropertyName = "cod_pre_sgs"
        Me.cod_pre_sgs.HeaderText = "cod_pre_sgs"
        Me.cod_pre_sgs.Name = "cod_pre_sgs"
        Me.cod_pre_sgs.ReadOnly = True
        Me.cod_pre_sgs.Visible = False
        '
        'cod_sucur
        '
        Me.cod_sucur.DataPropertyName = "cod_sucur"
        Me.cod_sucur.HeaderText = "cod_sucur"
        Me.cod_sucur.Name = "cod_sucur"
        Me.cod_sucur.ReadOnly = True
        Me.cod_sucur.Visible = False
        '
        'tip_admision
        '
        Me.tip_admision.DataPropertyName = "tip_admision"
        Me.tip_admision.HeaderText = "tip_admision"
        Me.tip_admision.Name = "tip_admision"
        Me.tip_admision.ReadOnly = True
        Me.tip_admision.Visible = False
        '
        'ano_adm
        '
        Me.ano_adm.DataPropertyName = "ano_adm"
        Me.ano_adm.HeaderText = "ano_adm"
        Me.ano_adm.Name = "ano_adm"
        Me.ano_adm.ReadOnly = True
        Me.ano_adm.Visible = False
        '
        'num_adm
        '
        Me.num_adm.DataPropertyName = "num_adm"
        Me.num_adm.HeaderText = "num_adm"
        Me.num_adm.Name = "num_adm"
        Me.num_adm.ReadOnly = True
        Me.num_adm.Visible = False
        '
        'estado
        '
        Me.estado.DataPropertyName = "estado"
        Me.estado.HeaderText = "estado"
        Me.estado.Name = "estado"
        Me.estado.Visible = False
        '
        'fec_con
        '
        Me.fec_con.DataPropertyName = "fec_con"
        Me.fec_con.HeaderText = "fec_con"
        Me.fec_con.Name = "fec_con"
        Me.fec_con.ReadOnly = True
        Me.fec_con.Visible = False
        '
        'login
        '
        Me.login.DataPropertyName = "login"
        Me.login.HeaderText = "login"
        Me.login.Name = "login"
        Me.login.ReadOnly = True
        Me.login.Visible = False
        '
        'pri_ape
        '
        Me.pri_ape.DataPropertyName = "pri_ape"
        Me.pri_ape.HeaderText = "pri_ape"
        Me.pri_ape.Name = "pri_ape"
        Me.pri_ape.Visible = False
        '
        'seg_ape
        '
        Me.seg_ape.DataPropertyName = "seg_ape"
        Me.seg_ape.HeaderText = "seg_ape"
        Me.seg_ape.Name = "seg_ape"
        Me.seg_ape.Visible = False
        '
        'pri_nom
        '
        Me.pri_nom.DataPropertyName = "pri_nom"
        Me.pri_nom.HeaderText = "pri_nom"
        Me.pri_nom.Name = "pri_nom"
        Me.pri_nom.Visible = False
        '
        'seg_nom
        '
        Me.seg_nom.DataPropertyName = "seg_nom"
        Me.seg_nom.HeaderText = "seg_nom"
        Me.seg_nom.Name = "seg_nom"
        Me.seg_nom.Visible = False
        '
        'gbDatos
        '
        Me.gbDatos.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.gbDatos.Controls.Add(Me.Panel4)
        Me.gbDatos.Controls.Add(Me.Panel3)
        Me.gbDatos.Controls.Add(Me.Panel2)
        Me.gbDatos.Controls.Add(Me.Panel1)
        Me.gbDatos.Controls.Add(Me.rbUrgencias)
        Me.gbDatos.Controls.Add(Me.Label1)
        Me.gbDatos.Controls.Add(Me.cmdLista)
        Me.gbDatos.Location = New System.Drawing.Point(0, 3)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(665, 310)
        Me.gbDatos.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.rbtConsultaOpcionAdmision)
        Me.Panel4.Controls.Add(Me.rbtConsultaOpcionDocumento)
        Me.Panel4.Controls.Add(Me.rbtConsultaOpcionSucursal)
        Me.Panel4.Location = New System.Drawing.Point(7, 60)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(20, 224)
        Me.Panel4.TabIndex = 6
        '
        'rbtConsultaOpcionAdmision
        '
        Me.rbtConsultaOpcionAdmision.AutoSize = True
        Me.rbtConsultaOpcionAdmision.Location = New System.Drawing.Point(3, 196)
        Me.rbtConsultaOpcionAdmision.Name = "rbtConsultaOpcionAdmision"
        Me.rbtConsultaOpcionAdmision.Size = New System.Drawing.Size(14, 13)
        Me.rbtConsultaOpcionAdmision.TabIndex = 9
        Me.rbtConsultaOpcionAdmision.TabStop = True
        Me.rbtConsultaOpcionAdmision.UseVisualStyleBackColor = True
        '
        'rbtConsultaOpcionDocumento
        '
        Me.rbtConsultaOpcionDocumento.AutoSize = True
        Me.rbtConsultaOpcionDocumento.Location = New System.Drawing.Point(3, 114)
        Me.rbtConsultaOpcionDocumento.Name = "rbtConsultaOpcionDocumento"
        Me.rbtConsultaOpcionDocumento.Size = New System.Drawing.Size(14, 13)
        Me.rbtConsultaOpcionDocumento.TabIndex = 8
        Me.rbtConsultaOpcionDocumento.TabStop = True
        Me.rbtConsultaOpcionDocumento.UseVisualStyleBackColor = True
        '
        'rbtConsultaOpcionSucursal
        '
        Me.rbtConsultaOpcionSucursal.AutoSize = True
        Me.rbtConsultaOpcionSucursal.Location = New System.Drawing.Point(3, 21)
        Me.rbtConsultaOpcionSucursal.Name = "rbtConsultaOpcionSucursal"
        Me.rbtConsultaOpcionSucursal.Size = New System.Drawing.Size(14, 13)
        Me.rbtConsultaOpcionSucursal.TabIndex = 7
        Me.rbtConsultaOpcionSucursal.TabStop = True
        Me.rbtConsultaOpcionSucursal.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.txtNumeroAdmision)
        Me.Panel3.Controls.Add(Me.txtAnoAdmision)
        Me.Panel3.Controls.Add(Me.txtTipoAdmision)
        Me.Panel3.Controls.Add(Me.lNumAdmin)
        Me.Panel3.Enabled = False
        Me.Panel3.Location = New System.Drawing.Point(28, 237)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(538, 47)
        Me.Panel3.TabIndex = 2
        '
        'txtNumeroAdmision
        '
        Me.txtNumeroAdmision.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeroAdmision.ControlComboEnlace = Nothing
        Me.txtNumeroAdmision.ControlTextoEnlace = Nothing
        Me.txtNumeroAdmision.DatoRelacionado = Nothing
        Me.txtNumeroAdmision.Decimals = CType(2, Byte)
        Me.txtNumeroAdmision.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtNumeroAdmision.Enabled = False
        Me.txtNumeroAdmision.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroAdmision.Format = HistoriaClinica.tbFormats.NúmericoEnteroSinSigno
        Me.txtNumeroAdmision.Location = New System.Drawing.Point(325, 12)
        Me.txtNumeroAdmision.MaxLength = 9
        Me.txtNumeroAdmision.Name = "txtNumeroAdmision"
        Me.txtNumeroAdmision.NombreCampoBuscado = Nothing
        Me.txtNumeroAdmision.NombreCampoBusqueda = Nothing
        Me.txtNumeroAdmision.NombreCampoDatos = Nothing
        Me.txtNumeroAdmision.Obligatorio = False
        Me.txtNumeroAdmision.OrigenDeDatos = Nothing
        Me.txtNumeroAdmision.PermitirValorCero = False
        Me.txtNumeroAdmision.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtNumeroAdmision.Size = New System.Drawing.Size(75, 22)
        Me.txtNumeroAdmision.TabIndex = 2
        Me.txtNumeroAdmision.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtNumeroAdmision.UserValues = Nothing
        Me.txtNumeroAdmision.ValorMaximo = CType(999999999, Long)
        Me.txtNumeroAdmision.ValorMinimo = CType(1, Long)
        '
        'txtAnoAdmision
        '
        Me.txtAnoAdmision.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAnoAdmision.ControlComboEnlace = Nothing
        Me.txtAnoAdmision.ControlTextoEnlace = Nothing
        Me.txtAnoAdmision.DatoRelacionado = Nothing
        Me.txtAnoAdmision.Decimals = CType(2, Byte)
        Me.txtAnoAdmision.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtAnoAdmision.Enabled = False
        Me.txtAnoAdmision.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnoAdmision.Format = HistoriaClinica.tbFormats.NúmericoEnteroSinSigno
        Me.txtAnoAdmision.Location = New System.Drawing.Point(269, 12)
        Me.txtAnoAdmision.MaxLength = 4
        Me.txtAnoAdmision.Name = "txtAnoAdmision"
        Me.txtAnoAdmision.NombreCampoBuscado = Nothing
        Me.txtAnoAdmision.NombreCampoBusqueda = Nothing
        Me.txtAnoAdmision.NombreCampoDatos = Nothing
        Me.txtAnoAdmision.Obligatorio = False
        Me.txtAnoAdmision.OrigenDeDatos = Nothing
        Me.txtAnoAdmision.PermitirValorCero = False
        Me.txtAnoAdmision.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtAnoAdmision.Size = New System.Drawing.Size(54, 22)
        Me.txtAnoAdmision.TabIndex = 1
        Me.txtAnoAdmision.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtAnoAdmision.UserValues = Nothing
        Me.txtAnoAdmision.ValorMaximo = CType(9999, Long)
        Me.txtAnoAdmision.ValorMinimo = CType(1753, Long)
        '
        'txtTipoAdmision
        '
        Me.txtTipoAdmision.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTipoAdmision.ControlComboEnlace = Nothing
        Me.txtTipoAdmision.ControlTextoEnlace = Nothing
        Me.txtTipoAdmision.DatoRelacionado = Nothing
        Me.txtTipoAdmision.Decimals = CType(2, Byte)
        Me.txtTipoAdmision.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtTipoAdmision.Enabled = False
        Me.txtTipoAdmision.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoAdmision.Format = HistoriaClinica.tbFormats.AlfabéticoSinEspacios
        Me.txtTipoAdmision.Location = New System.Drawing.Point(217, 12)
        Me.txtTipoAdmision.MaxLength = 2
        Me.txtTipoAdmision.Name = "txtTipoAdmision"
        Me.txtTipoAdmision.NombreCampoBuscado = Nothing
        Me.txtTipoAdmision.NombreCampoBusqueda = Nothing
        Me.txtTipoAdmision.NombreCampoDatos = Nothing
        Me.txtTipoAdmision.Obligatorio = False
        Me.txtTipoAdmision.OrigenDeDatos = Nothing
        Me.txtTipoAdmision.PermitirValorCero = False
        Me.txtTipoAdmision.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtTipoAdmision.Size = New System.Drawing.Size(50, 22)
        Me.txtTipoAdmision.TabIndex = 0
        Me.txtTipoAdmision.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtTipoAdmision.UserValues = Nothing
        Me.txtTipoAdmision.ValorMaximo = CType(0, Long)
        Me.txtTipoAdmision.ValorMinimo = CType(0, Long)
        '
        'lNumAdmin
        '
        Me.lNumAdmin.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lNumAdmin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lNumAdmin.Location = New System.Drawing.Point(2, 14)
        Me.lNumAdmin.Name = "lNumAdmin"
        Me.lNumAdmin.Size = New System.Drawing.Size(126, 19)
        Me.lNumAdmin.TabIndex = 3
        Me.lNumAdmin.Text = "Admisión"
        Me.lNumAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.txtNumeroDocumento)
        Me.Panel2.Controls.Add(Me.txtDescTipoDocumento)
        Me.Panel2.Controls.Add(Me.txtCodigoTipoDocumento)
        Me.Panel2.Controls.Add(Me.lNumIde)
        Me.Panel2.Controls.Add(Me.ltipoIde)
        Me.Panel2.Enabled = False
        Me.Panel2.Location = New System.Drawing.Point(28, 157)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(622, 73)
        Me.Panel2.TabIndex = 1
        '
        'txtNumeroDocumento
        '
        Me.txtNumeroDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeroDocumento.ControlComboEnlace = Nothing
        Me.txtNumeroDocumento.ControlTextoEnlace = Nothing
        Me.txtNumeroDocumento.DatoRelacionado = Nothing
        Me.txtNumeroDocumento.Decimals = CType(0, Byte)
        Me.txtNumeroDocumento.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtNumeroDocumento.Enabled = False
        Me.txtNumeroDocumento.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroDocumento.Format = HistoriaClinica.tbFormats.NúmericoEnteroSinSigno
        Me.txtNumeroDocumento.Location = New System.Drawing.Point(217, 45)
        Me.txtNumeroDocumento.MaxLength = 20
        Me.txtNumeroDocumento.Name = "txtNumeroDocumento"
        Me.txtNumeroDocumento.NombreCampoBuscado = Nothing
        Me.txtNumeroDocumento.NombreCampoBusqueda = Nothing
        Me.txtNumeroDocumento.NombreCampoDatos = Nothing
        Me.txtNumeroDocumento.Obligatorio = False
        Me.txtNumeroDocumento.OrigenDeDatos = Nothing
        Me.txtNumeroDocumento.PermitirValorCero = False
        Me.txtNumeroDocumento.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtNumeroDocumento.Size = New System.Drawing.Size(180, 22)
        Me.txtNumeroDocumento.TabIndex = 2
        Me.txtNumeroDocumento.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtNumeroDocumento.UserValues = Nothing
        Me.txtNumeroDocumento.ValorMaximo = CType(0, Long)
        Me.txtNumeroDocumento.ValorMinimo = CType(0, Long)
        '
        'txtDescTipoDocumento
        '
        Me.txtDescTipoDocumento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtDescTipoDocumento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtDescTipoDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescTipoDocumento.ControlComboEnlace = Nothing
        Me.txtDescTipoDocumento.ControlTextoEnlace = Nothing
        Me.txtDescTipoDocumento.DatoRelacionado = Nothing
        Me.txtDescTipoDocumento.Decimals = CType(2, Byte)
        Me.txtDescTipoDocumento.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtDescTipoDocumento.Enabled = False
        Me.txtDescTipoDocumento.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescTipoDocumento.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.txtDescTipoDocumento.Location = New System.Drawing.Point(289, 10)
        Me.txtDescTipoDocumento.MaxLength = 40
        Me.txtDescTipoDocumento.Name = "txtDescTipoDocumento"
        Me.txtDescTipoDocumento.NombreCampoBuscado = Nothing
        Me.txtDescTipoDocumento.NombreCampoBusqueda = Nothing
        Me.txtDescTipoDocumento.NombreCampoDatos = Nothing
        Me.txtDescTipoDocumento.Obligatorio = False
        Me.txtDescTipoDocumento.OrigenDeDatos = Nothing
        Me.txtDescTipoDocumento.PermitirValorCero = False
        Me.txtDescTipoDocumento.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtDescTipoDocumento.Size = New System.Drawing.Size(327, 22)
        Me.txtDescTipoDocumento.TabIndex = 1
        Me.txtDescTipoDocumento.TipoControl = HistoriaClinica.tbTipoControl.ListaAutoComplete
        Me.txtDescTipoDocumento.UserValues = Nothing
        Me.txtDescTipoDocumento.ValorMaximo = CType(0, Long)
        Me.txtDescTipoDocumento.ValorMinimo = CType(0, Long)
        '
        'txtCodigoTipoDocumento
        '
        Me.txtCodigoTipoDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoTipoDocumento.ControlComboEnlace = Nothing
        Me.txtCodigoTipoDocumento.ControlTextoEnlace = Nothing
        Me.txtCodigoTipoDocumento.DatoRelacionado = Nothing
        Me.txtCodigoTipoDocumento.Decimals = CType(2, Byte)
        Me.txtCodigoTipoDocumento.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtCodigoTipoDocumento.Enabled = False
        Me.txtCodigoTipoDocumento.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoTipoDocumento.Format = HistoriaClinica.tbFormats.AlfaNúmericoSinEspacios
        Me.txtCodigoTipoDocumento.Location = New System.Drawing.Point(217, 10)
        Me.txtCodigoTipoDocumento.MaxLength = 3
        Me.txtCodigoTipoDocumento.Name = "txtCodigoTipoDocumento"
        Me.txtCodigoTipoDocumento.NombreCampoBuscado = Nothing
        Me.txtCodigoTipoDocumento.NombreCampoBusqueda = Nothing
        Me.txtCodigoTipoDocumento.NombreCampoDatos = Nothing
        Me.txtCodigoTipoDocumento.Obligatorio = False
        Me.txtCodigoTipoDocumento.OrigenDeDatos = Nothing
        Me.txtCodigoTipoDocumento.PermitirValorCero = False
        Me.txtCodigoTipoDocumento.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtCodigoTipoDocumento.Size = New System.Drawing.Size(70, 22)
        Me.txtCodigoTipoDocumento.TabIndex = 0
        Me.txtCodigoTipoDocumento.TipoControl = HistoriaClinica.tbTipoControl.CodigoBusqueda
        Me.txtCodigoTipoDocumento.UserValues = Nothing
        Me.txtCodigoTipoDocumento.ValorMaximo = CType(0, Long)
        Me.txtCodigoTipoDocumento.ValorMinimo = CType(0, Long)
        '
        'lNumIde
        '
        Me.lNumIde.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lNumIde.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lNumIde.Location = New System.Drawing.Point(2, 47)
        Me.lNumIde.Name = "lNumIde"
        Me.lNumIde.Size = New System.Drawing.Size(160, 19)
        Me.lNumIde.TabIndex = 4
        Me.lNumIde.Text = "Número de documento"
        Me.lNumIde.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ltipoIde
        '
        Me.ltipoIde.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ltipoIde.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.ltipoIde.Location = New System.Drawing.Point(2, 10)
        Me.ltipoIde.Name = "ltipoIde"
        Me.ltipoIde.Size = New System.Drawing.Size(140, 23)
        Me.ltipoIde.TabIndex = 3
        Me.ltipoIde.Text = "Tipo de documento"
        Me.ltipoIde.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.dtFecIni)
        Me.Panel1.Controls.Add(Me.dtFecFin)
        Me.Panel1.Controls.Add(Me.cboSucursal)
        Me.Panel1.Controls.Add(Me.txtCodigoSucursal)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Enabled = False
        Me.Panel1.Location = New System.Drawing.Point(28, 60)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(622, 90)
        Me.Panel1.TabIndex = 0
        '
        'dtFecIni
        '
        Me.dtFecIni.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFecIni.Location = New System.Drawing.Point(215, 53)
        Me.dtFecIni.Mask = "00/00/0000"
        Me.dtFecIni.Name = "dtFecIni"
        Me.dtFecIni.Size = New System.Drawing.Size(116, 23)
        Me.dtFecIni.TabIndex = 1
        Me.dtFecIni.ValidatingType = GetType(Date)
        '
        'dtFecFin
        '
        Me.dtFecFin.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFecFin.Location = New System.Drawing.Point(498, 53)
        Me.dtFecFin.Mask = "00/00/0000"
        Me.dtFecFin.Name = "dtFecFin"
        Me.dtFecFin.Size = New System.Drawing.Size(116, 23)
        Me.dtFecFin.TabIndex = 2
        Me.dtFecFin.ValidatingType = GetType(Date)
        '
        'cboSucursal
        '
        Me.cboSucursal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboSucursal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboSucursal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cboSucursal.ControlComboEnlace = Nothing
        Me.cboSucursal.ControlTextoEnlace = Nothing
        Me.cboSucursal.DatoRelacionado = Nothing
        Me.cboSucursal.Decimals = CType(2, Byte)
        Me.cboSucursal.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.cboSucursal.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSucursal.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.cboSucursal.Location = New System.Drawing.Point(215, 15)
        Me.cboSucursal.MaxLength = 40
        Me.cboSucursal.Name = "cboSucursal"
        Me.cboSucursal.NombreCampoBuscado = Nothing
        Me.cboSucursal.NombreCampoBusqueda = Nothing
        Me.cboSucursal.NombreCampoDatos = Nothing
        Me.cboSucursal.Obligatorio = False
        Me.cboSucursal.OrigenDeDatos = Nothing
        Me.cboSucursal.PermitirValorCero = False
        Me.cboSucursal.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.cboSucursal.Size = New System.Drawing.Size(399, 22)
        Me.cboSucursal.TabIndex = 0
        Me.cboSucursal.TipoControl = HistoriaClinica.tbTipoControl.ListaAutoComplete
        Me.cboSucursal.UserValues = Nothing
        Me.cboSucursal.ValorMaximo = CType(0, Long)
        Me.cboSucursal.ValorMinimo = CType(0, Long)
        '
        'txtCodigoSucursal
        '
        Me.txtCodigoSucursal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoSucursal.ControlComboEnlace = Nothing
        Me.txtCodigoSucursal.ControlTextoEnlace = Nothing
        Me.txtCodigoSucursal.DatoRelacionado = Nothing
        Me.txtCodigoSucursal.Decimals = CType(2, Byte)
        Me.txtCodigoSucursal.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtCodigoSucursal.Enabled = False
        Me.txtCodigoSucursal.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoSucursal.Format = HistoriaClinica.tbFormats.AlfaNúmericoSinEspacios
        Me.txtCodigoSucursal.Location = New System.Drawing.Point(215, 15)
        Me.txtCodigoSucursal.MaxLength = 3
        Me.txtCodigoSucursal.Name = "txtCodigoSucursal"
        Me.txtCodigoSucursal.NombreCampoBuscado = Nothing
        Me.txtCodigoSucursal.NombreCampoBusqueda = Nothing
        Me.txtCodigoSucursal.NombreCampoDatos = Nothing
        Me.txtCodigoSucursal.Obligatorio = False
        Me.txtCodigoSucursal.OrigenDeDatos = Nothing
        Me.txtCodigoSucursal.PermitirValorCero = False
        Me.txtCodigoSucursal.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtCodigoSucursal.Size = New System.Drawing.Size(70, 22)
        Me.txtCodigoSucursal.TabIndex = 2
        Me.txtCodigoSucursal.TipoControl = HistoriaClinica.tbTipoControl.CodigoBusqueda
        Me.txtCodigoSucursal.UserValues = Nothing
        Me.txtCodigoSucursal.ValorMaximo = CType(0, Long)
        Me.txtCodigoSucursal.ValorMinimo = CType(0, Long)
        Me.txtCodigoSucursal.Visible = False
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(2, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 23)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Sucursal"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(422, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 23)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Hasta :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(138, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 23)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Desde :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(3, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(139, 23)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Seleccionar Fecha"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rbUrgencias
        '
        Me.rbUrgencias.AutoSize = True
        Me.rbUrgencias.Checked = True
        Me.rbUrgencias.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Bold)
        Me.rbUrgencias.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.rbUrgencias.Location = New System.Drawing.Point(25, 33)
        Me.rbUrgencias.Name = "rbUrgencias"
        Me.rbUrgencias.Size = New System.Drawing.Size(393, 20)
        Me.rbUrgencias.TabIndex = 5
        Me.rbUrgencias.TabStop = True
        Me.rbUrgencias.Text = "Reclasificación en Examén Físico Historias Clínicas"
        Me.rbUrgencias.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(23, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(182, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Seleccionar Pacientes por"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdLista
        '
        Me.cmdLista.BackColor = System.Drawing.Color.Transparent
        Me.cmdLista.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_buscar
        Me.cmdLista.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdLista.Enabled = False
        Me.cmdLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdLista.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLista.ForeColor = System.Drawing.Color.Transparent
        Me.cmdLista.Location = New System.Drawing.Point(582, 254)
        Me.cmdLista.Name = "cmdLista"
        Me.cmdLista.Size = New System.Drawing.Size(68, 30)
        Me.cmdLista.TabIndex = 3
        Me.cmdLista.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelar.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_cancelar
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.ForeColor = System.Drawing.Color.Transparent
        Me.btnCancelar.Location = New System.Drawing.Point(561, 602)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(104, 22)
        Me.btnCancelar.TabIndex = 42
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "tip_doc"
        Me.DataGridViewTextBoxColumn1.HeaderText = "TIPO DOC."
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 50
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "num_doc"
        Me.DataGridViewTextBoxColumn2.HeaderText = "No. DOCUMENTO"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 120
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "nombre"
        Me.DataGridViewTextBoxColumn3.HeaderText = "NOMBRE"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 250
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "admision"
        Me.DataGridViewTextBoxColumn4.HeaderText = "ADMISION"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 80
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "fec_hc"
        Me.DataGridViewTextBoxColumn5.HeaderText = "FECHA"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "cod_pre_sgs"
        Me.DataGridViewTextBoxColumn6.HeaderText = "cod_pre_sgs"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Visible = False
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "cod_sucur"
        Me.DataGridViewTextBoxColumn7.HeaderText = "cod_sucur"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Visible = False
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "tip_admision"
        Me.DataGridViewTextBoxColumn8.HeaderText = "tip_admision"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Visible = False
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "num_adm"
        Me.DataGridViewTextBoxColumn9.HeaderText = "num_adm"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Visible = False
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "estado"
        Me.DataGridViewTextBoxColumn10.HeaderText = "estado"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Visible = False
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "fec_con"
        Me.DataGridViewTextBoxColumn11.HeaderText = "fec_con"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Visible = False
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "login"
        Me.DataGridViewTextBoxColumn12.HeaderText = "login"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Visible = False
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "login"
        Me.DataGridViewTextBoxColumn13.HeaderText = "login"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Visible = False
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "pri_ape"
        Me.DataGridViewTextBoxColumn14.HeaderText = "pri_ape"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.Visible = False
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "seg_ape"
        Me.DataGridViewTextBoxColumn15.HeaderText = "seg_ape"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.Visible = False
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "pri_nom"
        Me.DataGridViewTextBoxColumn16.HeaderText = "pri_nom"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.Visible = False
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "seg_nom"
        Me.DataGridViewTextBoxColumn17.HeaderText = "seg_nom"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.Visible = False
        '
        'ListaEsperaError
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.gbDatos)
        Me.Controls.Add(Me.dtgLista)
        Me.Controls.Add(Me.Label2)
        Me.DoubleBuffered = True
        Me.Name = "ListaEsperaError"
        Me.Size = New System.Drawing.Size(668, 625)
        CType(Me.dtgLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtgLista As System.Windows.Forms.DataGridView
    Friend WithEvents gbDatos As System.Windows.Forms.Panel
    Friend WithEvents cmdLista As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rbUrgencias As System.Windows.Forms.RadioButton
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
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents tip_doc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents num_doc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBRE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ADMISION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fec_hc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cod_pre_sgs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cod_sucur As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tip_admision As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ano_adm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents num_adm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents estado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fec_con As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents login As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pri_ape As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents seg_ape As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pri_nom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents seg_nom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txtNumeroAdmision As HistoriaClinica.TextBoxConFormato
    Friend WithEvents txtAnoAdmision As HistoriaClinica.TextBoxConFormato
    Friend WithEvents txtTipoAdmision As HistoriaClinica.TextBoxConFormato
    Friend WithEvents lNumAdmin As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtNumeroDocumento As HistoriaClinica.TextBoxConFormato
    Friend WithEvents txtDescTipoDocumento As HistoriaClinica.TextBoxConFormato
    Friend WithEvents txtCodigoTipoDocumento As HistoriaClinica.TextBoxConFormato
    Friend WithEvents lNumIde As System.Windows.Forms.Label
    Friend WithEvents ltipoIde As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dtFecIni As System.Windows.Forms.MaskedTextBox
    Friend WithEvents dtFecFin As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cboSucursal As HistoriaClinica.TextBoxConFormato
    Friend WithEvents txtCodigoSucursal As HistoriaClinica.TextBoxConFormato
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents rbtConsultaOpcionAdmision As System.Windows.Forms.RadioButton
    Friend WithEvents rbtConsultaOpcionDocumento As System.Windows.Forms.RadioButton
    Friend WithEvents rbtConsultaOpcionSucursal As System.Windows.Forms.RadioButton

End Class
