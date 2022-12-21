<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConsultaHC
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaHC))
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.dtgAdmisiones = New System.Windows.Forms.DataGridView()
        Me.Sucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tip_admision = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ano_adm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.num_adm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fec_hc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Especialidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.medico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.estado_salida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnTraer = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtSegundoApellido = New HistoriaClinica.TextBoxConFormato()
        Me.txtPrimerApellido = New HistoriaClinica.TextBoxConFormato()
        Me.txtSegundoNombre = New HistoriaClinica.TextBoxConFormato()
        Me.txtPrimerNombre = New HistoriaClinica.TextBoxConFormato()
        Me.txtNumDoc = New HistoriaClinica.TextBoxConFormato()
        Me.tbCodigoTipDoc = New HistoriaClinica.TextBoxConFormato()
        Me.tbDescTipDoc = New HistoriaClinica.TextBoxConFormato()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkCuidadosPaliativos = New System.Windows.Forms.CheckBox()
        Me.txtNota = New HistoriaClinica.TextBoxConFormato()
        Me.dtgProcedim = New System.Windows.Forms.DataGridView()
        Me.Procedimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chkDescripcion = New System.Windows.Forms.CheckBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.mskFechaHastaRep = New System.Windows.Forms.MaskedTextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.mskFechaDesdeRep = New System.Windows.Forms.MaskedTextBox()
        Me.btDispensacion = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rbImpEnf = New System.Windows.Forms.RadioButton()
        Me.rbImpMed = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkHistIdentRiesgo1 = New System.Windows.Forms.CheckBox()
        Me.ckHCBasicaSinAnte = New System.Windows.Forms.CheckBox()
        Me.cboProcedimExt = New System.Windows.Forms.ComboBox()
        Me.ckProcedimientosExt = New System.Windows.Forms.CheckBox()
        Me.cboFormula = New System.Windows.Forms.ComboBox()
        Me.ckFormula = New System.Windows.Forms.CheckBox()
        Me.ckIncapacidad = New System.Windows.Forms.CheckBox()
        Me.ckHCBasica = New System.Windows.Forms.CheckBox()
        Me.ckTodos = New System.Windows.Forms.CheckBox()
        Me.ckTriage = New System.Windows.Forms.CheckBox()
        Me.ckRecomendacion = New System.Windows.Forms.CheckBox()
        Me.ckRemision = New System.Windows.Forms.CheckBox()
        Me.chkResumenEgreso = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.mskFechaDesde = New System.Windows.Forms.MaskedTextBox()
        Me.mskFechaHasta = New System.Windows.Forms.MaskedTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
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
        Me.chkConciliacionMed = New System.Windows.Forms.CheckBox()
        CType(Me.dtgAdmisiones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.dtgProcedim, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.Transparent
        Me.btnSalir.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_salir
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.ForeColor = System.Drawing.Color.Transparent
        Me.btnSalir.Location = New System.Drawing.Point(752, 627)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(104, 22)
        Me.btnSalir.TabIndex = 27
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelar.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_cancelar
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.ForeColor = System.Drawing.Color.Transparent
        Me.btnCancelar.Location = New System.Drawing.Point(642, 627)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(104, 22)
        Me.btnCancelar.TabIndex = 26
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnImprimir
        '
        Me.btnImprimir.BackColor = System.Drawing.Color.Transparent
        Me.btnImprimir.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_imprimir
        Me.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimir.ForeColor = System.Drawing.Color.Transparent
        Me.btnImprimir.Location = New System.Drawing.Point(532, 627)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(104, 22)
        Me.btnImprimir.TabIndex = 25
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'dtgAdmisiones
        '
        Me.dtgAdmisiones.AllowUserToAddRows = False
        Me.dtgAdmisiones.AllowUserToDeleteRows = False
        Me.dtgAdmisiones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgAdmisiones.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgAdmisiones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dtgAdmisiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgAdmisiones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Sucursal, Me.tip_admision, Me.ano_adm, Me.num_adm, Me.fec_hc, Me.Especialidad, Me.medico, Me.estado_salida, Me.estado})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(210, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgAdmisiones.DefaultCellStyle = DataGridViewCellStyle6
        Me.dtgAdmisiones.GridColor = System.Drawing.Color.Gray
        Me.dtgAdmisiones.Location = New System.Drawing.Point(10, 278)
        Me.dtgAdmisiones.Name = "dtgAdmisiones"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(210, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgAdmisiones.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(210, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        Me.dtgAdmisiones.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dtgAdmisiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgAdmisiones.Size = New System.Drawing.Size(855, 109)
        Me.dtgAdmisiones.TabIndex = 4
        '
        'Sucursal
        '
        Me.Sucursal.DataPropertyName = "sucursal"
        Me.Sucursal.HeaderText = "Descripción Sucursal"
        Me.Sucursal.Name = "Sucursal"
        '
        'tip_admision
        '
        Me.tip_admision.DataPropertyName = "tip_admision"
        Me.tip_admision.FillWeight = 70.03067!
        Me.tip_admision.HeaderText = "Tipo Admisión"
        Me.tip_admision.Name = "tip_admision"
        '
        'ano_adm
        '
        Me.ano_adm.DataPropertyName = "ano_adm"
        Me.ano_adm.FillWeight = 70.03067!
        Me.ano_adm.HeaderText = "Año"
        Me.ano_adm.Name = "ano_adm"
        '
        'num_adm
        '
        Me.num_adm.DataPropertyName = "num_adm"
        Me.num_adm.FillWeight = 70.03067!
        Me.num_adm.HeaderText = "Número"
        Me.num_adm.Name = "num_adm"
        '
        'fec_hc
        '
        Me.fec_hc.DataPropertyName = "fec_hc"
        Me.fec_hc.FillWeight = 70.03067!
        Me.fec_hc.HeaderText = "Fecha Historia"
        Me.fec_hc.Name = "fec_hc"
        '
        'Especialidad
        '
        Me.Especialidad.DataPropertyName = "especialidad"
        Me.Especialidad.FillWeight = 70.03067!
        Me.Especialidad.HeaderText = "Especialidad"
        Me.Especialidad.Name = "Especialidad"
        '
        'medico
        '
        Me.medico.DataPropertyName = "medico"
        Me.medico.FillWeight = 70.03067!
        Me.medico.HeaderText = "Médico"
        Me.medico.Name = "medico"
        '
        'estado_salida
        '
        Me.estado_salida.DataPropertyName = "estado_salida"
        Me.estado_salida.FillWeight = 70.03067!
        Me.estado_salida.HeaderText = "Estado"
        Me.estado_salida.Name = "estado_salida"
        '
        'estado
        '
        Me.estado.DataPropertyName = "estado"
        Me.estado.FillWeight = 50.0!
        Me.estado.HeaderText = "Estado Historia"
        Me.estado.Name = "estado"
        Me.estado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'btnTraer
        '
        Me.btnTraer.BackColor = System.Drawing.Color.Transparent
        Me.btnTraer.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_traer_historia
        Me.btnTraer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnTraer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTraer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTraer.ForeColor = System.Drawing.Color.Transparent
        Me.btnTraer.Location = New System.Drawing.Point(566, 243)
        Me.btnTraer.Name = "btnTraer"
        Me.btnTraer.Size = New System.Drawing.Size(105, 22)
        Me.btnTraer.TabIndex = 10
        Me.btnTraer.UseVisualStyleBackColor = False
        Me.btnTraer.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtSegundoApellido)
        Me.GroupBox2.Controls.Add(Me.txtPrimerApellido)
        Me.GroupBox2.Controls.Add(Me.txtSegundoNombre)
        Me.GroupBox2.Controls.Add(Me.txtPrimerNombre)
        Me.GroupBox2.Controls.Add(Me.txtNumDoc)
        Me.GroupBox2.Controls.Add(Me.tbCodigoTipDoc)
        Me.GroupBox2.Controls.Add(Me.tbDescTipDoc)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.btnBuscar)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox2.Location = New System.Drawing.Point(10, 113)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(850, 124)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos del Paciente"
        '
        'txtSegundoApellido
        '
        Me.txtSegundoApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSegundoApellido.ControlComboEnlace = Nothing
        Me.txtSegundoApellido.ControlTextoEnlace = Nothing
        Me.txtSegundoApellido.DatoRelacionado = Nothing
        Me.txtSegundoApellido.Decimals = CType(2, Byte)
        Me.txtSegundoApellido.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtSegundoApellido.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.txtSegundoApellido.Location = New System.Drawing.Point(613, 88)
        Me.txtSegundoApellido.Name = "txtSegundoApellido"
        Me.txtSegundoApellido.NombreCampoBuscado = Nothing
        Me.txtSegundoApellido.NombreCampoBusqueda = Nothing
        Me.txtSegundoApellido.NombreCampoDatos = Nothing
        Me.txtSegundoApellido.Obligatorio = False
        Me.txtSegundoApellido.OrigenDeDatos = Nothing
        Me.txtSegundoApellido.PermitirValorCero = False
        Me.txtSegundoApellido.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtSegundoApellido.Size = New System.Drawing.Size(200, 22)
        Me.txtSegundoApellido.TabIndex = 7
        Me.txtSegundoApellido.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtSegundoApellido.UserValues = Nothing
        Me.txtSegundoApellido.ValorMaximo = CType(0, Long)
        Me.txtSegundoApellido.ValorMinimo = CType(0, Long)
        '
        'txtPrimerApellido
        '
        Me.txtPrimerApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrimerApellido.ControlComboEnlace = Nothing
        Me.txtPrimerApellido.ControlTextoEnlace = Nothing
        Me.txtPrimerApellido.DatoRelacionado = Nothing
        Me.txtPrimerApellido.Decimals = CType(2, Byte)
        Me.txtPrimerApellido.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtPrimerApellido.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.txtPrimerApellido.Location = New System.Drawing.Point(412, 88)
        Me.txtPrimerApellido.Name = "txtPrimerApellido"
        Me.txtPrimerApellido.NombreCampoBuscado = Nothing
        Me.txtPrimerApellido.NombreCampoBusqueda = Nothing
        Me.txtPrimerApellido.NombreCampoDatos = Nothing
        Me.txtPrimerApellido.Obligatorio = False
        Me.txtPrimerApellido.OrigenDeDatos = Nothing
        Me.txtPrimerApellido.PermitirValorCero = False
        Me.txtPrimerApellido.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtPrimerApellido.Size = New System.Drawing.Size(200, 22)
        Me.txtPrimerApellido.TabIndex = 6
        Me.txtPrimerApellido.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtPrimerApellido.UserValues = Nothing
        Me.txtPrimerApellido.ValorMaximo = CType(0, Long)
        Me.txtPrimerApellido.ValorMinimo = CType(0, Long)
        '
        'txtSegundoNombre
        '
        Me.txtSegundoNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSegundoNombre.ControlComboEnlace = Nothing
        Me.txtSegundoNombre.ControlTextoEnlace = Nothing
        Me.txtSegundoNombre.DatoRelacionado = Nothing
        Me.txtSegundoNombre.Decimals = CType(2, Byte)
        Me.txtSegundoNombre.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtSegundoNombre.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.txtSegundoNombre.Location = New System.Drawing.Point(211, 88)
        Me.txtSegundoNombre.Name = "txtSegundoNombre"
        Me.txtSegundoNombre.NombreCampoBuscado = Nothing
        Me.txtSegundoNombre.NombreCampoBusqueda = Nothing
        Me.txtSegundoNombre.NombreCampoDatos = Nothing
        Me.txtSegundoNombre.Obligatorio = False
        Me.txtSegundoNombre.OrigenDeDatos = Nothing
        Me.txtSegundoNombre.PermitirValorCero = False
        Me.txtSegundoNombre.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtSegundoNombre.Size = New System.Drawing.Size(200, 22)
        Me.txtSegundoNombre.TabIndex = 5
        Me.txtSegundoNombre.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtSegundoNombre.UserValues = Nothing
        Me.txtSegundoNombre.ValorMaximo = CType(0, Long)
        Me.txtSegundoNombre.ValorMinimo = CType(0, Long)
        '
        'txtPrimerNombre
        '
        Me.txtPrimerNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrimerNombre.ControlComboEnlace = Nothing
        Me.txtPrimerNombre.ControlTextoEnlace = Nothing
        Me.txtPrimerNombre.DatoRelacionado = Nothing
        Me.txtPrimerNombre.Decimals = CType(2, Byte)
        Me.txtPrimerNombre.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtPrimerNombre.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.txtPrimerNombre.Location = New System.Drawing.Point(11, 88)
        Me.txtPrimerNombre.Name = "txtPrimerNombre"
        Me.txtPrimerNombre.NombreCampoBuscado = Nothing
        Me.txtPrimerNombre.NombreCampoBusqueda = Nothing
        Me.txtPrimerNombre.NombreCampoDatos = Nothing
        Me.txtPrimerNombre.Obligatorio = False
        Me.txtPrimerNombre.OrigenDeDatos = Nothing
        Me.txtPrimerNombre.PermitirValorCero = False
        Me.txtPrimerNombre.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtPrimerNombre.Size = New System.Drawing.Size(199, 22)
        Me.txtPrimerNombre.TabIndex = 4
        Me.txtPrimerNombre.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtPrimerNombre.UserValues = Nothing
        Me.txtPrimerNombre.ValorMaximo = CType(0, Long)
        Me.txtPrimerNombre.ValorMinimo = CType(0, Long)
        '
        'txtNumDoc
        '
        Me.txtNumDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumDoc.ControlComboEnlace = Nothing
        Me.txtNumDoc.ControlTextoEnlace = Nothing
        Me.txtNumDoc.DatoRelacionado = Nothing
        Me.txtNumDoc.Decimals = CType(2, Byte)
        Me.txtNumDoc.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtNumDoc.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.txtNumDoc.Location = New System.Drawing.Point(302, 37)
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.NombreCampoBuscado = Nothing
        Me.txtNumDoc.NombreCampoBusqueda = Nothing
        Me.txtNumDoc.NombreCampoDatos = Nothing
        Me.txtNumDoc.Obligatorio = False
        Me.txtNumDoc.OrigenDeDatos = Nothing
        Me.txtNumDoc.PermitirValorCero = False
        Me.txtNumDoc.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtNumDoc.Size = New System.Drawing.Size(244, 22)
        Me.txtNumDoc.TabIndex = 2
        Me.txtNumDoc.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtNumDoc.UserValues = Nothing
        Me.txtNumDoc.ValorMaximo = CType(0, Long)
        Me.txtNumDoc.ValorMinimo = CType(0, Long)
        '
        'tbCodigoTipDoc
        '
        Me.tbCodigoTipDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbCodigoTipDoc.ControlComboEnlace = Nothing
        Me.tbCodigoTipDoc.ControlTextoEnlace = Me.tbCodigoTipDoc
        Me.tbCodigoTipDoc.DatoRelacionado = Nothing
        Me.tbCodigoTipDoc.Decimals = CType(0, Byte)
        Me.tbCodigoTipDoc.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.tbCodigoTipDoc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCodigoTipDoc.Format = HistoriaClinica.tbFormats.AlfaNúmericoSinEspacios
        Me.tbCodigoTipDoc.Location = New System.Drawing.Point(11, 38)
        Me.tbCodigoTipDoc.MaxLength = 3
        Me.tbCodigoTipDoc.Name = "tbCodigoTipDoc"
        Me.tbCodigoTipDoc.NombreCampoBuscado = Nothing
        Me.tbCodigoTipDoc.NombreCampoBusqueda = Nothing
        Me.tbCodigoTipDoc.NombreCampoDatos = Nothing
        Me.tbCodigoTipDoc.Obligatorio = False
        Me.tbCodigoTipDoc.OrigenDeDatos = Nothing
        Me.tbCodigoTipDoc.PermitirValorCero = False
        Me.tbCodigoTipDoc.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.tbCodigoTipDoc.Size = New System.Drawing.Size(40, 21)
        Me.tbCodigoTipDoc.TabIndex = 0
        Me.tbCodigoTipDoc.TipoControl = HistoriaClinica.tbTipoControl.CodigoBusqueda
        Me.tbCodigoTipDoc.UserValues = Nothing
        Me.tbCodigoTipDoc.ValorMaximo = CType(0, Long)
        Me.tbCodigoTipDoc.ValorMinimo = CType(0, Long)
        '
        'tbDescTipDoc
        '
        Me.tbDescTipDoc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.tbDescTipDoc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.tbDescTipDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbDescTipDoc.ControlComboEnlace = Nothing
        Me.tbDescTipDoc.ControlTextoEnlace = Me.tbDescTipDoc
        Me.tbDescTipDoc.DatoRelacionado = Nothing
        Me.tbDescTipDoc.Decimals = CType(0, Byte)
        Me.tbDescTipDoc.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.tbDescTipDoc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDescTipDoc.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.tbDescTipDoc.Location = New System.Drawing.Point(53, 38)
        Me.tbDescTipDoc.MaxLength = 50
        Me.tbDescTipDoc.Name = "tbDescTipDoc"
        Me.tbDescTipDoc.NombreCampoBuscado = Nothing
        Me.tbDescTipDoc.NombreCampoBusqueda = Nothing
        Me.tbDescTipDoc.NombreCampoDatos = Nothing
        Me.tbDescTipDoc.Obligatorio = False
        Me.tbDescTipDoc.OrigenDeDatos = Nothing
        Me.tbDescTipDoc.PermitirValorCero = False
        Me.tbDescTipDoc.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.tbDescTipDoc.Size = New System.Drawing.Size(247, 21)
        Me.tbDescTipDoc.TabIndex = 1
        Me.tbDescTipDoc.TipoControl = HistoriaClinica.tbTipoControl.ListaAutoComplete
        Me.tbDescTipDoc.UserValues = Nothing
        Me.tbDescTipDoc.ValorMaximo = CType(0, Long)
        Me.tbDescTipDoc.ValorMinimo = CType(0, Long)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(609, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Segundo Apellido"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(409, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Primer Apellido"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(208, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Segundo Nombre"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Primer Nombre"
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.Color.Transparent
        Me.btnBuscar.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_buscar_individual
        Me.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.ForeColor = System.Drawing.Color.Transparent
        Me.btnBuscar.Location = New System.Drawing.Point(553, 37)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(104, 22)
        Me.btnBuscar.TabIndex = 3
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(299, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Número Documento"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Tipo Documento"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.HistoriaClinica.My.Resources.Resources.header_consultaHC
        Me.PictureBox1.Location = New System.Drawing.Point(1, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(867, 39)
        Me.PictureBox1.TabIndex = 57
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.chkCuidadosPaliativos)
        Me.Panel1.Controls.Add(Me.txtNota)
        Me.Panel1.Controls.Add(Me.dtgProcedim)
        Me.Panel1.Controls.Add(Me.chkDescripcion)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.mskFechaHastaRep)
        Me.Panel1.Controls.Add(Me.LinkLabel1)
        Me.Panel1.Controls.Add(Me.mskFechaDesdeRep)
        Me.Panel1.Controls.Add(Me.btDispensacion)
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.chkResumenEgreso)
        Me.Panel1.Controls.Add(Me.btnImprimir)
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Controls.Add(Me.btnSalir)
        Me.Panel1.Location = New System.Drawing.Point(1, 39)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(868, 668)
        Me.Panel1.TabIndex = 0
        Me.Panel1.TabStop = True
        '
        'chkCuidadosPaliativos
        '
        Me.chkCuidadosPaliativos.AutoSize = True
        Me.chkCuidadosPaliativos.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.chkCuidadosPaliativos.Location = New System.Drawing.Point(139, 475)
        Me.chkCuidadosPaliativos.Name = "chkCuidadosPaliativos"
        Me.chkCuidadosPaliativos.Size = New System.Drawing.Size(137, 17)
        Me.chkCuidadosPaliativos.TabIndex = 63
        Me.chkCuidadosPaliativos.Text = "Cuidados Paliativos"
        Me.chkCuidadosPaliativos.UseVisualStyleBackColor = True
        '
        'txtNota
        '
        Me.txtNota.ControlComboEnlace = Nothing
        Me.txtNota.ControlTextoEnlace = Nothing
        Me.txtNota.DatoRelacionado = Nothing
        Me.txtNota.Decimals = CType(2, Byte)
        Me.txtNota.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtNota.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.txtNota.Location = New System.Drawing.Point(80, 586)
        Me.txtNota.Multiline = True
        Me.txtNota.Name = "txtNota"
        Me.txtNota.NombreCampoBuscado = Nothing
        Me.txtNota.NombreCampoBusqueda = Nothing
        Me.txtNota.NombreCampoDatos = Nothing
        Me.txtNota.Obligatorio = False
        Me.txtNota.OrigenDeDatos = Nothing
        Me.txtNota.PermitirValorCero = False
        Me.txtNota.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtNota.Size = New System.Drawing.Size(731, 35)
        Me.txtNota.TabIndex = 24
        Me.txtNota.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtNota.UserValues = Nothing
        Me.txtNota.ValorMaximo = CType(0, Long)
        Me.txtNota.ValorMinimo = CType(0, Long)
        Me.txtNota.Visible = False
        '
        'dtgProcedim
        '
        Me.dtgProcedim.AllowUserToAddRows = False
        Me.dtgProcedim.AllowUserToDeleteRows = False
        Me.dtgProcedim.BackgroundColor = System.Drawing.Color.White
        Me.dtgProcedim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgProcedim.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Procedimiento, Me.Descripcion})
        Me.dtgProcedim.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.dtgProcedim.Location = New System.Drawing.Point(379, 448)
        Me.dtgProcedim.Name = "dtgProcedim"
        Me.dtgProcedim.Size = New System.Drawing.Size(479, 93)
        Me.dtgProcedim.TabIndex = 62
        '
        'Procedimiento
        '
        Me.Procedimiento.DataPropertyName = "Procedimiento"
        Me.Procedimiento.HeaderText = "Procedimiento"
        Me.Procedimiento.Name = "Procedimiento"
        '
        'Descripcion
        '
        Me.Descripcion.DataPropertyName = "Descripcion"
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.Width = 335
        '
        'chkDescripcion
        '
        Me.chkDescripcion.AutoSize = True
        Me.chkDescripcion.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.chkDescripcion.Location = New System.Drawing.Point(139, 450)
        Me.chkDescripcion.Name = "chkDescripcion"
        Me.chkDescripcion.Size = New System.Drawing.Size(155, 17)
        Me.chkDescripcion.TabIndex = 61
        Me.chkDescripcion.Text = "Descripción Quirúrgica"
        Me.chkDescripcion.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(77, 545)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(241, 14)
        Me.Label15.TabIndex = 60
        Me.Label15.Text = "Rango Fechas Impresión de Reporte:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(405, 562)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(39, 13)
        Me.Label14.TabIndex = 58
        Me.Label14.Text = "Hasta"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(549, 562)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(81, 13)
        Me.Label13.TabIndex = 58
        Me.Label13.Text = "dd/mm/aaaa"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(224, 565)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(81, 13)
        Me.Label12.TabIndex = 58
        Me.Label12.Text = "dd/mm/aaaa"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(79, 565)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 13)
        Me.Label11.TabIndex = 58
        Me.Label11.Text = "Desde"
        '
        'mskFechaHastaRep
        '
        Me.mskFechaHastaRep.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskFechaHastaRep.Location = New System.Drawing.Point(453, 559)
        Me.mskFechaHastaRep.Mask = "00/00/0000"
        Me.mskFechaHastaRep.Name = "mskFechaHastaRep"
        Me.mskFechaHastaRep.Size = New System.Drawing.Size(90, 21)
        Me.mskFechaHastaRep.TabIndex = 59
        Me.mskFechaHastaRep.ValidatingType = GetType(Date)
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.Location = New System.Drawing.Point(266, 633)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(31, 16)
        Me.LinkLabel1.TabIndex = 39
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Ctc"
        Me.LinkLabel1.Visible = False
        '
        'mskFechaDesdeRep
        '
        Me.mskFechaDesdeRep.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskFechaDesdeRep.Location = New System.Drawing.Point(128, 562)
        Me.mskFechaDesdeRep.Mask = "00/00/0000"
        Me.mskFechaDesdeRep.Name = "mskFechaDesdeRep"
        Me.mskFechaDesdeRep.Size = New System.Drawing.Size(90, 21)
        Me.mskFechaDesdeRep.TabIndex = 58
        Me.mskFechaDesdeRep.ValidatingType = GetType(Date)
        '
        'btDispensacion
        '
        Me.btDispensacion.BackColor = System.Drawing.Color.Transparent
        Me.btDispensacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btDispensacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btDispensacion.ForeColor = System.Drawing.Color.Transparent
        Me.btDispensacion.Image = CType(resources.GetObject("btDispensacion.Image"), System.Drawing.Image)
        Me.btDispensacion.Location = New System.Drawing.Point(320, 627)
        Me.btDispensacion.Name = "btDispensacion"
        Me.btDispensacion.Size = New System.Drawing.Size(206, 22)
        Me.btDispensacion.TabIndex = 38
        Me.btDispensacion.UseVisualStyleBackColor = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rbImpEnf)
        Me.GroupBox4.Controls.Add(Me.rbImpMed)
        Me.GroupBox4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox4.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(848, 55)
        Me.GroupBox4.TabIndex = 37
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Tipo Reporte"
        '
        'rbImpEnf
        '
        Me.rbImpEnf.AutoSize = True
        Me.rbImpEnf.Location = New System.Drawing.Point(417, 21)
        Me.rbImpEnf.Name = "rbImpEnf"
        Me.rbImpEnf.Size = New System.Drawing.Size(276, 18)
        Me.rbImpEnf.TabIndex = 1
        Me.rbImpEnf.Text = "Reporte Historia Clinica para Enfermeria"
        Me.rbImpEnf.UseVisualStyleBackColor = True
        '
        'rbImpMed
        '
        Me.rbImpMed.AutoSize = True
        Me.rbImpMed.Checked = True
        Me.rbImpMed.Location = New System.Drawing.Point(131, 21)
        Me.rbImpMed.Name = "rbImpMed"
        Me.rbImpMed.Size = New System.Drawing.Size(258, 18)
        Me.rbImpMed.TabIndex = 0
        Me.rbImpMed.TabStop = True
        Me.rbImpMed.Text = "Reporte Historia Clinica para Medicos"
        Me.rbImpMed.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkConciliacionMed)
        Me.GroupBox1.Controls.Add(Me.chkHistIdentRiesgo1)
        Me.GroupBox1.Controls.Add(Me.ckHCBasicaSinAnte)
        Me.GroupBox1.Controls.Add(Me.cboProcedimExt)
        Me.GroupBox1.Controls.Add(Me.ckProcedimientosExt)
        Me.GroupBox1.Controls.Add(Me.cboFormula)
        Me.GroupBox1.Controls.Add(Me.ckFormula)
        Me.GroupBox1.Controls.Add(Me.ckIncapacidad)
        Me.GroupBox1.Controls.Add(Me.ckHCBasica)
        Me.GroupBox1.Controls.Add(Me.ckTodos)
        Me.GroupBox1.Controls.Add(Me.ckTriage)
        Me.GroupBox1.Controls.Add(Me.ckRecomendacion)
        Me.GroupBox1.Controls.Add(Me.ckRemision)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(6, 354)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(851, 88)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Desea imprimir"
        '
        'chkHistIdentRiesgo1
        '
        Me.chkHistIdentRiesgo1.AutoSize = True
        Me.chkHistIdentRiesgo1.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.chkHistIdentRiesgo1.Location = New System.Drawing.Point(12, 66)
        Me.chkHistIdentRiesgo1.Name = "chkHistIdentRiesgo1"
        Me.chkHistIdentRiesgo1.Size = New System.Drawing.Size(221, 17)
        Me.chkHistIdentRiesgo1.TabIndex = 72
        Me.chkHistIdentRiesgo1.Text = "Historial Identificadores de Riesgo"
        Me.chkHistIdentRiesgo1.UseVisualStyleBackColor = True
        '
        'ckHCBasicaSinAnte
        '
        Me.ckHCBasicaSinAnte.AutoSize = True
        Me.ckHCBasicaSinAnte.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckHCBasicaSinAnte.Location = New System.Drawing.Point(133, 21)
        Me.ckHCBasicaSinAnte.Name = "ckHCBasicaSinAnte"
        Me.ckHCBasicaSinAnte.Size = New System.Drawing.Size(218, 17)
        Me.ckHCBasicaSinAnte.TabIndex = 23
        Me.ckHCBasicaSinAnte.Text = "Historia Clínica Ant. Consolidados"
        Me.ckHCBasicaSinAnte.UseVisualStyleBackColor = True
        '
        'cboProcedimExt
        '
        Me.cboProcedimExt.FormattingEnabled = True
        Me.cboProcedimExt.Location = New System.Drawing.Point(697, 40)
        Me.cboProcedimExt.Name = "cboProcedimExt"
        Me.cboProcedimExt.Size = New System.Drawing.Size(64, 22)
        Me.cboProcedimExt.TabIndex = 21
        '
        'ckProcedimientosExt
        '
        Me.ckProcedimientosExt.AutoSize = True
        Me.ckProcedimientosExt.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.ckProcedimientosExt.Location = New System.Drawing.Point(508, 43)
        Me.ckProcedimientosExt.Name = "ckProcedimientosExt"
        Me.ckProcedimientosExt.Size = New System.Drawing.Size(167, 17)
        Me.ckProcedimientosExt.TabIndex = 20
        Me.ckProcedimientosExt.Text = "Procedimientos Externos"
        Me.ckProcedimientosExt.UseVisualStyleBackColor = True
        '
        'cboFormula
        '
        Me.cboFormula.FormattingEnabled = True
        Me.cboFormula.Location = New System.Drawing.Point(393, 42)
        Me.cboFormula.Name = "cboFormula"
        Me.cboFormula.Size = New System.Drawing.Size(64, 22)
        Me.cboFormula.TabIndex = 19
        '
        'ckFormula
        '
        Me.ckFormula.AutoSize = True
        Me.ckFormula.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.ckFormula.Location = New System.Drawing.Point(133, 45)
        Me.ckFormula.Name = "ckFormula"
        Me.ckFormula.Size = New System.Drawing.Size(143, 17)
        Me.ckFormula.TabIndex = 18
        Me.ckFormula.Text = "Formulación Externa"
        Me.ckFormula.UseVisualStyleBackColor = True
        '
        'ckIncapacidad
        '
        Me.ckIncapacidad.AutoSize = True
        Me.ckIncapacidad.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.ckIncapacidad.Location = New System.Drawing.Point(12, 43)
        Me.ckIncapacidad.Name = "ckIncapacidad"
        Me.ckIncapacidad.Size = New System.Drawing.Size(95, 17)
        Me.ckIncapacidad.TabIndex = 17
        Me.ckIncapacidad.Text = "Incapacidad"
        Me.ckIncapacidad.UseVisualStyleBackColor = True
        '
        'ckHCBasica
        '
        Me.ckHCBasica.AutoSize = True
        Me.ckHCBasica.Checked = True
        Me.ckHCBasica.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckHCBasica.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.ckHCBasica.Location = New System.Drawing.Point(11, 20)
        Me.ckHCBasica.Name = "ckHCBasica"
        Me.ckHCBasica.Size = New System.Drawing.Size(111, 17)
        Me.ckHCBasica.TabIndex = 13
        Me.ckHCBasica.Text = "Historia Clínica"
        Me.ckHCBasica.UseVisualStyleBackColor = True
        '
        'ckTodos
        '
        Me.ckTodos.AutoSize = True
        Me.ckTodos.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.ckTodos.Location = New System.Drawing.Point(781, 40)
        Me.ckTodos.Name = "ckTodos"
        Me.ckTodos.Size = New System.Drawing.Size(59, 17)
        Me.ckTodos.TabIndex = 22
        Me.ckTodos.Text = "Todos"
        Me.ckTodos.UseVisualStyleBackColor = True
        '
        'ckTriage
        '
        Me.ckTriage.AutoSize = True
        Me.ckTriage.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.ckTriage.Location = New System.Drawing.Point(781, 20)
        Me.ckTriage.Name = "ckTriage"
        Me.ckTriage.Size = New System.Drawing.Size(61, 17)
        Me.ckTriage.TabIndex = 16
        Me.ckTriage.Text = "Triage"
        Me.ckTriage.UseVisualStyleBackColor = True
        '
        'ckRecomendacion
        '
        Me.ckRecomendacion.AutoSize = True
        Me.ckRecomendacion.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.ckRecomendacion.Location = New System.Drawing.Point(508, 20)
        Me.ckRecomendacion.Name = "ckRecomendacion"
        Me.ckRecomendacion.Size = New System.Drawing.Size(186, 17)
        Me.ckRecomendacion.TabIndex = 15
        Me.ckRecomendacion.Text = "Recomendaciones al egreso"
        Me.ckRecomendacion.UseVisualStyleBackColor = True
        '
        'ckRemision
        '
        Me.ckRemision.AutoSize = True
        Me.ckRemision.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.ckRemision.Location = New System.Drawing.Point(393, 19)
        Me.ckRemision.Name = "ckRemision"
        Me.ckRemision.Size = New System.Drawing.Size(78, 17)
        Me.ckRemision.TabIndex = 14
        Me.ckRemision.Text = "Remisión"
        Me.ckRemision.UseVisualStyleBackColor = True
        '
        'chkResumenEgreso
        '
        Me.chkResumenEgreso.AutoSize = True
        Me.chkResumenEgreso.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkResumenEgreso.Location = New System.Drawing.Point(10, 450)
        Me.chkResumenEgreso.Name = "chkResumenEgreso"
        Me.chkResumenEgreso.Size = New System.Drawing.Size(81, 18)
        Me.chkResumenEgreso.TabIndex = 23
        Me.chkResumenEgreso.Text = "Epicrisis"
        Me.chkResumenEgreso.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(428, 250)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 13)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "dd/mm/aaaa"
        '
        'mskFechaDesde
        '
        Me.mskFechaDesde.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskFechaDesde.Location = New System.Drawing.Point(71, 247)
        Me.mskFechaDesde.Mask = "00/00/0000"
        Me.mskFechaDesde.Name = "mskFechaDesde"
        Me.mskFechaDesde.Size = New System.Drawing.Size(90, 21)
        Me.mskFechaDesde.TabIndex = 8
        Me.mskFechaDesde.ValidatingType = GetType(Date)
        '
        'mskFechaHasta
        '
        Me.mskFechaHasta.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskFechaHasta.Location = New System.Drawing.Point(332, 247)
        Me.mskFechaHasta.Mask = "00/00/0000"
        Me.mskFechaHasta.Name = "mskFechaHasta"
        Me.mskFechaHasta.Size = New System.Drawing.Size(90, 21)
        Me.mskFechaHasta.TabIndex = 9
        Me.mskFechaHasta.ValidatingType = GetType(Date)
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(18, 250)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Desde"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(286, 250)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Hasta"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(167, 250)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 13)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "dd/mm/aaaa"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "tip_admision"
        Me.DataGridViewTextBoxColumn1.FillWeight = 79.47788!
        Me.DataGridViewTextBoxColumn1.HeaderText = "Tipo Admisión"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 115
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "ano_adm"
        Me.DataGridViewTextBoxColumn2.FillWeight = 79.47788!
        Me.DataGridViewTextBoxColumn2.HeaderText = "Año"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 116
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "num_adm"
        Me.DataGridViewTextBoxColumn3.FillWeight = 79.47788!
        Me.DataGridViewTextBoxColumn3.HeaderText = "Número"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 115
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "fec_hc"
        Me.DataGridViewTextBoxColumn4.FillWeight = 79.47788!
        Me.DataGridViewTextBoxColumn4.HeaderText = "Fecha Historia"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 115
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Especialidad"
        Me.DataGridViewTextBoxColumn5.FillWeight = 79.47788!
        Me.DataGridViewTextBoxColumn5.HeaderText = "Especialidad"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 115
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "medico"
        Me.DataGridViewTextBoxColumn6.FillWeight = 79.47788!
        Me.DataGridViewTextBoxColumn6.HeaderText = "Médico"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 116
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "estado_salida"
        Me.DataGridViewTextBoxColumn7.FillWeight = 79.47788!
        Me.DataGridViewTextBoxColumn7.HeaderText = "Estado"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 115
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "estado_salida"
        Me.DataGridViewTextBoxColumn8.FillWeight = 243.6548!
        Me.DataGridViewTextBoxColumn8.HeaderText = "Estado"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn8.Width = 101
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "estado_salida"
        Me.DataGridViewTextBoxColumn9.FillWeight = 70.03067!
        Me.DataGridViewTextBoxColumn9.HeaderText = "Estado"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Width = 105
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "estado"
        Me.DataGridViewTextBoxColumn10.FillWeight = 50.0!
        Me.DataGridViewTextBoxColumn10.HeaderText = "Estado Historia"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn10.Width = 75
        '
        'chkConciliacionMed
        '
        Me.chkConciliacionMed.AutoSize = True
        Me.chkConciliacionMed.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.chkConciliacionMed.Location = New System.Drawing.Point(393, 66)
        Me.chkConciliacionMed.Name = "chkConciliacionMed"
        Me.chkConciliacionMed.Size = New System.Drawing.Size(179, 17)
        Me.chkConciliacionMed.TabIndex = 73
        Me.chkConciliacionMed.Text = "Conciliación Medicamentos"
        Me.chkConciliacionMed.UseVisualStyleBackColor = True
        '
        'frmConsultaHC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(869, 690)
        Me.Controls.Add(Me.dtgAdmisiones)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.mskFechaDesde)
        Me.Controls.Add(Me.mskFechaHasta)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnTraer)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frmConsultaHC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta Historia Clinica"
        CType(Me.dtgAdmisiones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dtgProcedim, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents dtgAdmisiones As System.Windows.Forms.DataGridView
    Friend WithEvents btnTraer As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSegundoApellido As HistoriaClinica.TextBoxConFormato
    Friend WithEvents txtPrimerApellido As HistoriaClinica.TextBoxConFormato
    Friend WithEvents txtSegundoNombre As HistoriaClinica.TextBoxConFormato
    Friend WithEvents txtPrimerNombre As HistoriaClinica.TextBoxConFormato
    Friend WithEvents txtNumDoc As HistoriaClinica.TextBoxConFormato
    Friend WithEvents tbCodigoTipDoc As HistoriaClinica.TextBoxConFormato
    Friend WithEvents tbDescTipDoc As HistoriaClinica.TextBoxConFormato
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNota As HistoriaClinica.TextBoxConFormato
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents mskFechaDesde As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mskFechaHasta As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chkResumenEgreso As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ckTodos As System.Windows.Forms.CheckBox
    Friend WithEvents ckTriage As System.Windows.Forms.CheckBox
    Friend WithEvents ckRecomendacion As System.Windows.Forms.CheckBox
    Friend WithEvents ckRemision As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ckHCBasica As System.Windows.Forms.CheckBox
    Friend WithEvents ckIncapacidad As System.Windows.Forms.CheckBox
    Friend WithEvents ckFormula As System.Windows.Forms.CheckBox
    Friend WithEvents cboFormula As System.Windows.Forms.ComboBox
    Friend WithEvents ckProcedimientosExt As System.Windows.Forms.CheckBox
    Friend WithEvents cboProcedimExt As System.Windows.Forms.ComboBox
    Friend WithEvents ckHCBasicaSinAnte As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rbImpEnf As System.Windows.Forms.RadioButton
    Friend WithEvents rbImpMed As System.Windows.Forms.RadioButton
    Friend WithEvents btDispensacion As System.Windows.Forms.Button
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents mskFechaDesdeRep As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mskFechaHastaRep As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents chkDescripcion As System.Windows.Forms.CheckBox
    Friend WithEvents dtgProcedim As System.Windows.Forms.DataGridView
    Friend WithEvents Procedimiento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkCuidadosPaliativos As System.Windows.Forms.CheckBox
    Friend WithEvents chkHistIdentRiesgo1 As CheckBox
    Friend WithEvents Sucursal As DataGridViewTextBoxColumn
    Friend WithEvents tip_admision As DataGridViewTextBoxColumn
    Friend WithEvents ano_adm As DataGridViewTextBoxColumn
    Friend WithEvents num_adm As DataGridViewTextBoxColumn
    Friend WithEvents fec_hc As DataGridViewTextBoxColumn
    Friend WithEvents Especialidad As DataGridViewTextBoxColumn
    Friend WithEvents medico As DataGridViewTextBoxColumn
    Friend WithEvents estado_salida As DataGridViewTextBoxColumn
    Friend WithEvents estado As DataGridViewTextBoxColumn
    Friend WithEvents chkConciliacionMed As CheckBox
End Class
