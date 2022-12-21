<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlCPEnfermeria
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctlCPEnfermeria))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grbProfesional = New System.Windows.Forms.GroupBox()
        Me.txtNombreProfesional = New HistoriaClinica.TextBoxConFormato()
        Me.lblNombreProfesional = New System.Windows.Forms.Label()
        Me.grbAdminMedicamentos = New System.Windows.Forms.GroupBox()
        Me.btnRespAdmin = New System.Windows.Forms.Button()
        Me.cmbUnidadMedida = New System.Windows.Forms.ComboBox()
        Me.lblUnidadMedida = New System.Windows.Forms.Label()
        Me.btnAgregarMedicamento = New System.Windows.Forms.Button()
        Me.txtObsAdmin = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.mskFecHorAdmin = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbViaAdministracion = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDosis = New HistoriaClinica.TextBoxConFormato()
        Me.txtNombreMedicamento = New HistoriaClinica.TextBoxConFormato()
        Me.rbNoAdminMedicamento = New System.Windows.Forms.RadioButton()
        Me.rbSiAdminMedicamento = New System.Windows.Forms.RadioButton()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblAdminMedicamento = New System.Windows.Forms.Label()
        Me.lblNombreMedicamento = New System.Windows.Forms.Label()
        Me.pnlGrillaMedicamentos = New System.Windows.Forms.Panel()
        Me.dgvMedicamentos = New System.Windows.Forms.DataGridView()
        Me.IdAdmin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaRegistro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Medicamento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dosis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ViaAdmin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EsAdministrado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Horario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grbEntornoSocioFamiliar = New System.Windows.Forms.GroupBox()
        Me.txtEvolEnfermeria = New System.Windows.Forms.TextBox()
        Me.lblEvolEnfermeria = New System.Windows.Forms.Label()
        Me.txtCuidadoEnfermedad = New System.Windows.Forms.TextBox()
        Me.lblCuidadoEnfermeria = New System.Windows.Forms.Label()
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.pnlCateter = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rbNoPresentaHerida = New System.Windows.Forms.RadioButton()
        Me.rbSiPresentaHerida = New System.Windows.Forms.RadioButton()
        Me.lblPresentaHeridas = New System.Windows.Forms.Label()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlContHerida = New System.Windows.Forms.Panel()
        Me.pnlHistoricoHeridas = New System.Windows.Forms.Panel()
        Me.btnRespHerida = New System.Windows.Forms.Button()
        Me.lblHistoricoHeridas = New System.Windows.Forms.Label()
        Me.dgvHeridasPaciente = New System.Windows.Forms.DataGridView()
        Me.pnlPreguntaHerida = New System.Windows.Forms.Panel()
        Me.grbSeguimientoHeridas = New System.Windows.Forms.GroupBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnTraerRespuesta = New System.Windows.Forms.Button()
        Me.lblTitulo = New System.Windows.Forms.Label()
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
        Me.grbProfesional.SuspendLayout()
        Me.grbAdminMedicamentos.SuspendLayout()
        Me.pnlGrillaMedicamentos.SuspendLayout()
        CType(Me.dgvMedicamentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbEntornoSocioFamiliar.SuspendLayout()
        Me.pnlContenedor.SuspendLayout()
        Me.Panel16.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.pnlHistoricoHeridas.SuspendLayout()
        CType(Me.dgvHeridasPaciente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPreguntaHerida.SuspendLayout()
        Me.grbSeguimientoHeridas.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbProfesional
        '
        Me.grbProfesional.Controls.Add(Me.txtNombreProfesional)
        Me.grbProfesional.Controls.Add(Me.lblNombreProfesional)
        Me.grbProfesional.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbProfesional.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.grbProfesional.Location = New System.Drawing.Point(6, 4)
        Me.grbProfesional.Name = "grbProfesional"
        Me.grbProfesional.Size = New System.Drawing.Size(1046, 60)
        Me.grbProfesional.TabIndex = 111
        Me.grbProfesional.TabStop = False
        Me.grbProfesional.Text = "Profesional Enfermería"
        '
        'txtNombreProfesional
        '
        Me.txtNombreProfesional.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreProfesional.ControlComboEnlace = Nothing
        Me.txtNombreProfesional.ControlTextoEnlace = Nothing
        Me.txtNombreProfesional.DatoRelacionado = Nothing
        Me.txtNombreProfesional.Decimals = CType(0, Byte)
        Me.txtNombreProfesional.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtNombreProfesional.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreProfesional.Format = HistoriaClinica.tbFormats.AlfabéticoConEspacios
        Me.txtNombreProfesional.Location = New System.Drawing.Point(384, 23)
        Me.txtNombreProfesional.MaxLength = 100
        Me.txtNombreProfesional.Name = "txtNombreProfesional"
        Me.txtNombreProfesional.NombreCampoBuscado = Nothing
        Me.txtNombreProfesional.NombreCampoBusqueda = Nothing
        Me.txtNombreProfesional.NombreCampoDatos = Nothing
        Me.txtNombreProfesional.Obligatorio = True
        Me.txtNombreProfesional.OrigenDeDatos = Nothing
        Me.txtNombreProfesional.PermitirValorCero = False
        Me.txtNombreProfesional.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtNombreProfesional.Size = New System.Drawing.Size(645, 22)
        Me.txtNombreProfesional.TabIndex = 1
        Me.txtNombreProfesional.Tag = "13"
        Me.txtNombreProfesional.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtNombreProfesional.UserValues = Nothing
        Me.txtNombreProfesional.ValorMaximo = CType(0, Long)
        Me.txtNombreProfesional.ValorMinimo = CType(0, Long)
        '
        'lblNombreProfesional
        '
        Me.lblNombreProfesional.BackColor = System.Drawing.Color.Transparent
        Me.lblNombreProfesional.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreProfesional.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblNombreProfesional.Location = New System.Drawing.Point(131, 23)
        Me.lblNombreProfesional.Name = "lblNombreProfesional"
        Me.lblNombreProfesional.Size = New System.Drawing.Size(231, 19)
        Me.lblNombreProfesional.TabIndex = 112
        Me.lblNombreProfesional.Text = "Nombre Profesional Enfermería"
        Me.lblNombreProfesional.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grbAdminMedicamentos
        '
        Me.grbAdminMedicamentos.Controls.Add(Me.btnRespAdmin)
        Me.grbAdminMedicamentos.Controls.Add(Me.cmbUnidadMedida)
        Me.grbAdminMedicamentos.Controls.Add(Me.lblUnidadMedida)
        Me.grbAdminMedicamentos.Controls.Add(Me.btnAgregarMedicamento)
        Me.grbAdminMedicamentos.Controls.Add(Me.txtObsAdmin)
        Me.grbAdminMedicamentos.Controls.Add(Me.Label7)
        Me.grbAdminMedicamentos.Controls.Add(Me.mskFecHorAdmin)
        Me.grbAdminMedicamentos.Controls.Add(Me.Label3)
        Me.grbAdminMedicamentos.Controls.Add(Me.cmbViaAdministracion)
        Me.grbAdminMedicamentos.Controls.Add(Me.Label2)
        Me.grbAdminMedicamentos.Controls.Add(Me.txtDosis)
        Me.grbAdminMedicamentos.Controls.Add(Me.txtNombreMedicamento)
        Me.grbAdminMedicamentos.Controls.Add(Me.rbNoAdminMedicamento)
        Me.grbAdminMedicamentos.Controls.Add(Me.rbSiAdminMedicamento)
        Me.grbAdminMedicamentos.Controls.Add(Me.Label15)
        Me.grbAdminMedicamentos.Controls.Add(Me.lblAdminMedicamento)
        Me.grbAdminMedicamentos.Controls.Add(Me.lblNombreMedicamento)
        Me.grbAdminMedicamentos.Controls.Add(Me.pnlGrillaMedicamentos)
        Me.grbAdminMedicamentos.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grbAdminMedicamentos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.grbAdminMedicamentos.Location = New System.Drawing.Point(5, 66)
        Me.grbAdminMedicamentos.Name = "grbAdminMedicamentos"
        Me.grbAdminMedicamentos.Size = New System.Drawing.Size(1048, 361)
        Me.grbAdminMedicamentos.TabIndex = 181
        Me.grbAdminMedicamentos.TabStop = False
        Me.grbAdminMedicamentos.Text = "Administración de Medicamentos"
        '
        'btnRespAdmin
        '
        Me.btnRespAdmin.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btnRespAdmin.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_proponer
        Me.btnRespAdmin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnRespAdmin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRespAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRespAdmin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRespAdmin.ForeColor = System.Drawing.SystemColors.Control
        Me.btnRespAdmin.Location = New System.Drawing.Point(900, 12)
        Me.btnRespAdmin.Name = "btnRespAdmin"
        Me.btnRespAdmin.Size = New System.Drawing.Size(147, 33)
        Me.btnRespAdmin.TabIndex = 261
        Me.btnRespAdmin.Tag = "37"
        Me.btnRespAdmin.UseVisualStyleBackColor = False
        '
        'cmbUnidadMedida
        '
        Me.cmbUnidadMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUnidadMedida.FormattingEnabled = True
        Me.cmbUnidadMedida.Location = New System.Drawing.Point(493, 235)
        Me.cmbUnidadMedida.Name = "cmbUnidadMedida"
        Me.cmbUnidadMedida.Size = New System.Drawing.Size(162, 22)
        Me.cmbUnidadMedida.TabIndex = 259
        '
        'lblUnidadMedida
        '
        Me.lblUnidadMedida.AutoSize = True
        Me.lblUnidadMedida.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnidadMedida.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblUnidadMedida.Location = New System.Drawing.Point(348, 239)
        Me.lblUnidadMedida.Name = "lblUnidadMedida"
        Me.lblUnidadMedida.Size = New System.Drawing.Size(124, 14)
        Me.lblUnidadMedida.TabIndex = 256
        Me.lblUnidadMedida.Text = "Unidad de Medida"
        '
        'btnAgregarMedicamento
        '
        Me.btnAgregarMedicamento.BackColor = System.Drawing.Color.Transparent
        Me.btnAgregarMedicamento.BackgroundImage = CType(resources.GetObject("btnAgregarMedicamento.BackgroundImage"), System.Drawing.Image)
        Me.btnAgregarMedicamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregarMedicamento.ForeColor = System.Drawing.Color.Transparent
        Me.btnAgregarMedicamento.Location = New System.Drawing.Point(942, 311)
        Me.btnAgregarMedicamento.Name = "btnAgregarMedicamento"
        Me.btnAgregarMedicamento.Size = New System.Drawing.Size(74, 23)
        Me.btnAgregarMedicamento.TabIndex = 254
        Me.btnAgregarMedicamento.Tag = "25"
        Me.btnAgregarMedicamento.UseVisualStyleBackColor = False
        '
        'txtObsAdmin
        '
        Me.txtObsAdmin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObsAdmin.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObsAdmin.Location = New System.Drawing.Point(237, 299)
        Me.txtObsAdmin.MaxLength = 800
        Me.txtObsAdmin.Multiline = True
        Me.txtObsAdmin.Name = "txtObsAdmin"
        Me.txtObsAdmin.Size = New System.Drawing.Size(674, 45)
        Me.txtObsAdmin.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(132, 300)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(109, 44)
        Me.Label7.TabIndex = 214
        Me.Label7.Text = "Observaciones"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mskFecHorAdmin
        '
        Me.mskFecHorAdmin.Enabled = False
        Me.mskFecHorAdmin.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskFecHorAdmin.Location = New System.Drawing.Point(734, 269)
        Me.mskFecHorAdmin.Mask = "00/00/0000 00:00"
        Me.mskFecHorAdmin.Name = "mskFecHorAdmin"
        Me.mskFecHorAdmin.Size = New System.Drawing.Size(118, 21)
        Me.mskFecHorAdmin.TabIndex = 7
        Me.mskFecHorAdmin.ValidatingType = GetType(Date)
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(553, 271)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(175, 19)
        Me.Label3.TabIndex = 187
        Me.Label3.Text = "Horario Administración"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbViaAdministracion
        '
        Me.cmbViaAdministracion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbViaAdministracion.FormattingEnabled = True
        Me.cmbViaAdministracion.Location = New System.Drawing.Point(829, 235)
        Me.cmbViaAdministracion.Name = "cmbViaAdministracion"
        Me.cmbViaAdministracion.Size = New System.Drawing.Size(201, 22)
        Me.cmbViaAdministracion.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(681, 236)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(145, 19)
        Me.Label2.TabIndex = 185
        Me.Label2.Text = "Vía Administración"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDosis
        '
        Me.txtDosis.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDosis.ControlComboEnlace = Nothing
        Me.txtDosis.ControlTextoEnlace = Nothing
        Me.txtDosis.DatoRelacionado = Nothing
        Me.txtDosis.Decimals = CType(2, Byte)
        Me.txtDosis.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtDosis.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDosis.Format = HistoriaClinica.tbFormats.NúmericoPuntoFlotanteSinSigno
        Me.txtDosis.Location = New System.Drawing.Point(237, 235)
        Me.txtDosis.MaxLength = 8
        Me.txtDosis.Name = "txtDosis"
        Me.txtDosis.NombreCampoBuscado = Nothing
        Me.txtDosis.NombreCampoBusqueda = Nothing
        Me.txtDosis.NombreCampoDatos = Nothing
        Me.txtDosis.Obligatorio = True
        Me.txtDosis.OrigenDeDatos = Nothing
        Me.txtDosis.PermitirValorCero = False
        Me.txtDosis.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtDosis.Size = New System.Drawing.Size(74, 22)
        Me.txtDosis.TabIndex = 3
        Me.txtDosis.Tag = "13"
        Me.txtDosis.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtDosis.UserValues = Nothing
        Me.txtDosis.ValorMaximo = CType(0, Long)
        Me.txtDosis.ValorMinimo = CType(0, Long)
        '
        'txtNombreMedicamento
        '
        Me.txtNombreMedicamento.ControlComboEnlace = Nothing
        Me.txtNombreMedicamento.ControlTextoEnlace = Nothing
        Me.txtNombreMedicamento.DatoRelacionado = Nothing
        Me.txtNombreMedicamento.Decimals = CType(2, Byte)
        Me.txtNombreMedicamento.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtNombreMedicamento.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreMedicamento.Format = HistoriaClinica.tbFormats.AlfabéticoConEspacios
        Me.txtNombreMedicamento.Location = New System.Drawing.Point(385, 203)
        Me.txtNombreMedicamento.MaxLength = 150
        Me.txtNombreMedicamento.Name = "txtNombreMedicamento"
        Me.txtNombreMedicamento.NombreCampoBuscado = Nothing
        Me.txtNombreMedicamento.NombreCampoBusqueda = Nothing
        Me.txtNombreMedicamento.NombreCampoDatos = Nothing
        Me.txtNombreMedicamento.Obligatorio = True
        Me.txtNombreMedicamento.OrigenDeDatos = Nothing
        Me.txtNombreMedicamento.PermitirValorCero = False
        Me.txtNombreMedicamento.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtNombreMedicamento.Size = New System.Drawing.Size(645, 22)
        Me.txtNombreMedicamento.TabIndex = 2
        Me.txtNombreMedicamento.Tag = "20"
        Me.txtNombreMedicamento.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtNombreMedicamento.UserValues = Nothing
        Me.txtNombreMedicamento.ValorMaximo = CType(0, Long)
        Me.txtNombreMedicamento.ValorMinimo = CType(0, Long)
        '
        'rbNoAdminMedicamento
        '
        Me.rbNoAdminMedicamento.AutoSize = True
        Me.rbNoAdminMedicamento.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbNoAdminMedicamento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.rbNoAdminMedicamento.Location = New System.Drawing.Point(448, 269)
        Me.rbNoAdminMedicamento.Name = "rbNoAdminMedicamento"
        Me.rbNoAdminMedicamento.Size = New System.Drawing.Size(43, 18)
        Me.rbNoAdminMedicamento.TabIndex = 6
        Me.rbNoAdminMedicamento.TabStop = True
        Me.rbNoAdminMedicamento.Tag = "9"
        Me.rbNoAdminMedicamento.Text = "No"
        Me.rbNoAdminMedicamento.UseVisualStyleBackColor = True
        '
        'rbSiAdminMedicamento
        '
        Me.rbSiAdminMedicamento.AutoSize = True
        Me.rbSiAdminMedicamento.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSiAdminMedicamento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.rbSiAdminMedicamento.Location = New System.Drawing.Point(401, 269)
        Me.rbSiAdminMedicamento.Name = "rbSiAdminMedicamento"
        Me.rbSiAdminMedicamento.Size = New System.Drawing.Size(38, 18)
        Me.rbSiAdminMedicamento.TabIndex = 5
        Me.rbSiAdminMedicamento.TabStop = True
        Me.rbSiAdminMedicamento.Tag = "8"
        Me.rbSiAdminMedicamento.Text = "Si"
        Me.rbSiAdminMedicamento.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(132, 237)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(48, 17)
        Me.Label15.TabIndex = 182
        Me.Label15.Text = "Dosis"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAdminMedicamento
        '
        Me.lblAdminMedicamento.BackColor = System.Drawing.Color.Transparent
        Me.lblAdminMedicamento.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdminMedicamento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblAdminMedicamento.Location = New System.Drawing.Point(132, 269)
        Me.lblAdminMedicamento.Name = "lblAdminMedicamento"
        Me.lblAdminMedicamento.Size = New System.Drawing.Size(259, 19)
        Me.lblAdminMedicamento.TabIndex = 177
        Me.lblAdminMedicamento.Text = "¿Administración de Medicamento?"
        Me.lblAdminMedicamento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNombreMedicamento
        '
        Me.lblNombreMedicamento.BackColor = System.Drawing.Color.Transparent
        Me.lblNombreMedicamento.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreMedicamento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblNombreMedicamento.Location = New System.Drawing.Point(132, 206)
        Me.lblNombreMedicamento.Name = "lblNombreMedicamento"
        Me.lblNombreMedicamento.Size = New System.Drawing.Size(206, 19)
        Me.lblNombreMedicamento.TabIndex = 112
        Me.lblNombreMedicamento.Text = "Nombre Medicamento"
        Me.lblNombreMedicamento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlGrillaMedicamentos
        '
        Me.pnlGrillaMedicamentos.Controls.Add(Me.dgvMedicamentos)
        Me.pnlGrillaMedicamentos.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlGrillaMedicamentos.Location = New System.Drawing.Point(129, 51)
        Me.pnlGrillaMedicamentos.Name = "pnlGrillaMedicamentos"
        Me.pnlGrillaMedicamentos.Size = New System.Drawing.Size(812, 135)
        Me.pnlGrillaMedicamentos.TabIndex = 260
        '
        'dgvMedicamentos
        '
        Me.dgvMedicamentos.AllowUserToAddRows = False
        Me.dgvMedicamentos.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(210, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMedicamentos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvMedicamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMedicamentos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdAdmin, Me.FechaRegistro, Me.TipoDoc, Me.NumDoc, Me.Medicamento, Me.Dosis, Me.ViaAdmin, Me.EsAdministrado, Me.Horario, Me.Observaciones})
        Me.dgvMedicamentos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMedicamentos.Location = New System.Drawing.Point(0, 0)
        Me.dgvMedicamentos.Name = "dgvMedicamentos"
        Me.dgvMedicamentos.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(210, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.LightGoldenrodYellow
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMedicamentos.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvMedicamentos.RowHeadersWidth = 30
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvMedicamentos.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvMedicamentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMedicamentos.Size = New System.Drawing.Size(812, 135)
        Me.dgvMedicamentos.TabIndex = 259
        '
        'IdAdmin
        '
        Me.IdAdmin.DataPropertyName = "Id"
        Me.IdAdmin.HeaderText = "Id"
        Me.IdAdmin.Name = "IdAdmin"
        Me.IdAdmin.ReadOnly = True
        Me.IdAdmin.Visible = False
        '
        'FechaRegistro
        '
        Me.FechaRegistro.DataPropertyName = "FechaRegistro"
        Me.FechaRegistro.HeaderText = "FechaRegistro"
        Me.FechaRegistro.Name = "FechaRegistro"
        Me.FechaRegistro.ReadOnly = True
        Me.FechaRegistro.Visible = False
        '
        'TipoDoc
        '
        Me.TipoDoc.DataPropertyName = "TipoDoc"
        Me.TipoDoc.HeaderText = "TipoDoc"
        Me.TipoDoc.Name = "TipoDoc"
        Me.TipoDoc.ReadOnly = True
        Me.TipoDoc.Visible = False
        '
        'NumDoc
        '
        Me.NumDoc.DataPropertyName = "NumDoc"
        Me.NumDoc.HeaderText = "NumDoc"
        Me.NumDoc.Name = "NumDoc"
        Me.NumDoc.ReadOnly = True
        Me.NumDoc.Visible = False
        '
        'Medicamento
        '
        Me.Medicamento.DataPropertyName = "Medicamento"
        Me.Medicamento.HeaderText = "Medicamento"
        Me.Medicamento.Name = "Medicamento"
        Me.Medicamento.ReadOnly = True
        Me.Medicamento.Width = 150
        '
        'Dosis
        '
        Me.Dosis.DataPropertyName = "Dosis"
        Me.Dosis.HeaderText = "Dosis"
        Me.Dosis.Name = "Dosis"
        Me.Dosis.ReadOnly = True
        '
        'ViaAdmin
        '
        Me.ViaAdmin.DataPropertyName = "ViaAdmin"
        Me.ViaAdmin.HeaderText = "Vía Admin"
        Me.ViaAdmin.Name = "ViaAdmin"
        Me.ViaAdmin.ReadOnly = True
        Me.ViaAdmin.Width = 110
        '
        'EsAdministrado
        '
        Me.EsAdministrado.DataPropertyName = "EsAdministrado"
        Me.EsAdministrado.HeaderText = "¿Administrado?"
        Me.EsAdministrado.Name = "EsAdministrado"
        Me.EsAdministrado.ReadOnly = True
        Me.EsAdministrado.Width = 120
        '
        'Horario
        '
        Me.Horario.DataPropertyName = "Horario"
        Me.Horario.HeaderText = "Horario"
        Me.Horario.Name = "Horario"
        Me.Horario.ReadOnly = True
        '
        'Observaciones
        '
        Me.Observaciones.DataPropertyName = "Observaciones"
        Me.Observaciones.HeaderText = "Observaciones"
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.ReadOnly = True
        Me.Observaciones.Width = 190
        '
        'grbEntornoSocioFamiliar
        '
        Me.grbEntornoSocioFamiliar.Controls.Add(Me.txtEvolEnfermeria)
        Me.grbEntornoSocioFamiliar.Controls.Add(Me.lblEvolEnfermeria)
        Me.grbEntornoSocioFamiliar.Controls.Add(Me.txtCuidadoEnfermedad)
        Me.grbEntornoSocioFamiliar.Controls.Add(Me.lblCuidadoEnfermeria)
        Me.grbEntornoSocioFamiliar.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbEntornoSocioFamiliar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.grbEntornoSocioFamiliar.Location = New System.Drawing.Point(5, 430)
        Me.grbEntornoSocioFamiliar.Name = "grbEntornoSocioFamiliar"
        Me.grbEntornoSocioFamiliar.Size = New System.Drawing.Size(1042, 188)
        Me.grbEntornoSocioFamiliar.TabIndex = 187
        Me.grbEntornoSocioFamiliar.TabStop = False
        Me.grbEntornoSocioFamiliar.Text = "Evolución y Cuidados de Enfermería"
        '
        'txtEvolEnfermeria
        '
        Me.txtEvolEnfermeria.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEvolEnfermeria.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEvolEnfermeria.Location = New System.Drawing.Point(279, 110)
        Me.txtEvolEnfermeria.MaxLength = 8000
        Me.txtEvolEnfermeria.Multiline = True
        Me.txtEvolEnfermeria.Name = "txtEvolEnfermeria"
        Me.txtEvolEnfermeria.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtEvolEnfermeria.Size = New System.Drawing.Size(751, 59)
        Me.txtEvolEnfermeria.TabIndex = 10
        '
        'lblEvolEnfermeria
        '
        Me.lblEvolEnfermeria.BackColor = System.Drawing.Color.Transparent
        Me.lblEvolEnfermeria.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEvolEnfermeria.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblEvolEnfermeria.Location = New System.Drawing.Point(132, 129)
        Me.lblEvolEnfermeria.Name = "lblEvolEnfermeria"
        Me.lblEvolEnfermeria.Size = New System.Drawing.Size(153, 19)
        Me.lblEvolEnfermeria.TabIndex = 218
        Me.lblEvolEnfermeria.Text = "Evolución Enfermería"
        Me.lblEvolEnfermeria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCuidadoEnfermedad
        '
        Me.txtCuidadoEnfermedad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCuidadoEnfermedad.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuidadoEnfermedad.Location = New System.Drawing.Point(279, 31)
        Me.txtCuidadoEnfermedad.MaxLength = 8000
        Me.txtCuidadoEnfermedad.Multiline = True
        Me.txtCuidadoEnfermedad.Name = "txtCuidadoEnfermedad"
        Me.txtCuidadoEnfermedad.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCuidadoEnfermedad.Size = New System.Drawing.Size(751, 59)
        Me.txtCuidadoEnfermedad.TabIndex = 9
        '
        'lblCuidadoEnfermeria
        '
        Me.lblCuidadoEnfermeria.BackColor = System.Drawing.Color.Transparent
        Me.lblCuidadoEnfermeria.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCuidadoEnfermeria.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblCuidadoEnfermeria.Location = New System.Drawing.Point(132, 49)
        Me.lblCuidadoEnfermeria.Name = "lblCuidadoEnfermeria"
        Me.lblCuidadoEnfermeria.Size = New System.Drawing.Size(153, 19)
        Me.lblCuidadoEnfermeria.TabIndex = 216
        Me.lblCuidadoEnfermeria.Text = "Cuidados Enfermería"
        Me.lblCuidadoEnfermeria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlContenedor
        '
        Me.pnlContenedor.AutoSize = True
        Me.pnlContenedor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlContenedor.Controls.Add(Me.pnlCateter)
        Me.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedor.Location = New System.Drawing.Point(3, 11)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Size = New System.Drawing.Size(1046, 3)
        Me.pnlContenedor.TabIndex = 255
        '
        'pnlCateter
        '
        Me.pnlCateter.AutoSize = True
        Me.pnlCateter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlCateter.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.pnlCateter.Location = New System.Drawing.Point(0, 0)
        Me.pnlCateter.Name = "pnlCateter"
        Me.pnlCateter.Size = New System.Drawing.Size(0, 0)
        Me.pnlCateter.TabIndex = 225
        Me.pnlCateter.WrapContents = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(290, 19)
        Me.Label1.TabIndex = 219
        Me.Label1.Text = "¿Qué actividad desea realizar al catéter?"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rbNoPresentaHerida
        '
        Me.rbNoPresentaHerida.AutoSize = True
        Me.rbNoPresentaHerida.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbNoPresentaHerida.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.rbNoPresentaHerida.Location = New System.Drawing.Point(546, 23)
        Me.rbNoPresentaHerida.Name = "rbNoPresentaHerida"
        Me.rbNoPresentaHerida.Size = New System.Drawing.Size(43, 18)
        Me.rbNoPresentaHerida.TabIndex = 15
        Me.rbNoPresentaHerida.Tag = "9"
        Me.rbNoPresentaHerida.Text = "No"
        Me.rbNoPresentaHerida.UseVisualStyleBackColor = True
        '
        'rbSiPresentaHerida
        '
        Me.rbSiPresentaHerida.AutoSize = True
        Me.rbSiPresentaHerida.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSiPresentaHerida.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.rbSiPresentaHerida.Location = New System.Drawing.Point(470, 23)
        Me.rbSiPresentaHerida.Name = "rbSiPresentaHerida"
        Me.rbSiPresentaHerida.Size = New System.Drawing.Size(38, 18)
        Me.rbSiPresentaHerida.TabIndex = 14
        Me.rbSiPresentaHerida.Tag = "8"
        Me.rbSiPresentaHerida.Text = "Si"
        Me.rbSiPresentaHerida.UseVisualStyleBackColor = True
        '
        'lblPresentaHeridas
        '
        Me.lblPresentaHeridas.BackColor = System.Drawing.Color.Transparent
        Me.lblPresentaHeridas.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPresentaHeridas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblPresentaHeridas.Location = New System.Drawing.Point(132, 21)
        Me.lblPresentaHeridas.Name = "lblPresentaHeridas"
        Me.lblPresentaHeridas.Size = New System.Drawing.Size(263, 22)
        Me.lblPresentaHeridas.TabIndex = 200
        Me.lblPresentaHeridas.Text = "¿Presenta alguna herida?"
        Me.lblPresentaHeridas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel16
        '
        Me.Panel16.AutoSize = True
        Me.Panel16.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Panel16.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel16.Controls.Add(Me.grbEntornoSocioFamiliar)
        Me.Panel16.Controls.Add(Me.grbAdminMedicamentos)
        Me.Panel16.Controls.Add(Me.grbProfesional)
        Me.Panel16.Location = New System.Drawing.Point(13, 36)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(1059, 1003)
        Me.Panel16.TabIndex = 52
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.pnlContenedor, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.pnlContHerida, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.pnlHistoricoHeridas, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.pnlPreguntaHerida, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnGuardar, 0, 6)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(4, 624)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 108.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1052, 363)
        Me.TableLayoutPanel1.TabIndex = 257
        '
        'pnlContHerida
        '
        Me.pnlContHerida.AutoSize = True
        Me.pnlContHerida.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlContHerida.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContHerida.Location = New System.Drawing.Point(3, 84)
        Me.pnlContHerida.Name = "pnlContHerida"
        Me.pnlContHerida.Size = New System.Drawing.Size(1046, 1)
        Me.pnlContHerida.TabIndex = 256
        '
        'pnlHistoricoHeridas
        '
        Me.pnlHistoricoHeridas.AutoSize = True
        Me.pnlHistoricoHeridas.Controls.Add(Me.btnRespHerida)
        Me.pnlHistoricoHeridas.Controls.Add(Me.lblHistoricoHeridas)
        Me.pnlHistoricoHeridas.Controls.Add(Me.dgvHeridasPaciente)
        Me.pnlHistoricoHeridas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlHistoricoHeridas.Location = New System.Drawing.Point(3, 90)
        Me.pnlHistoricoHeridas.Name = "pnlHistoricoHeridas"
        Me.pnlHistoricoHeridas.Size = New System.Drawing.Size(1046, 162)
        Me.pnlHistoricoHeridas.TabIndex = 258
        '
        'btnRespHerida
        '
        Me.btnRespHerida.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btnRespHerida.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_proponer
        Me.btnRespHerida.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnRespHerida.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRespHerida.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRespHerida.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRespHerida.ForeColor = System.Drawing.SystemColors.Control
        Me.btnRespHerida.Location = New System.Drawing.Point(892, 3)
        Me.btnRespHerida.Name = "btnRespHerida"
        Me.btnRespHerida.Size = New System.Drawing.Size(147, 33)
        Me.btnRespHerida.TabIndex = 262
        Me.btnRespHerida.Tag = "37"
        Me.btnRespHerida.UseVisualStyleBackColor = False
        '
        'lblHistoricoHeridas
        '
        Me.lblHistoricoHeridas.BackColor = System.Drawing.Color.Transparent
        Me.lblHistoricoHeridas.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHistoricoHeridas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblHistoricoHeridas.Location = New System.Drawing.Point(4, 2)
        Me.lblHistoricoHeridas.Name = "lblHistoricoHeridas"
        Me.lblHistoricoHeridas.Size = New System.Drawing.Size(230, 25)
        Me.lblHistoricoHeridas.TabIndex = 253
        Me.lblHistoricoHeridas.Text = "Histórico Heridas del Paciente"
        Me.lblHistoricoHeridas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvHeridasPaciente
        '
        Me.dgvHeridasPaciente.AllowUserToAddRows = False
        Me.dgvHeridasPaciente.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(210, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvHeridasPaciente.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvHeridasPaciente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHeridasPaciente.Location = New System.Drawing.Point(6, 39)
        Me.dgvHeridasPaciente.Name = "dgvHeridasPaciente"
        Me.dgvHeridasPaciente.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(210, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.LightGoldenrodYellow
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvHeridasPaciente.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvHeridasPaciente.RowHeadersVisible = False
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvHeridasPaciente.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvHeridasPaciente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvHeridasPaciente.Size = New System.Drawing.Size(1028, 120)
        Me.dgvHeridasPaciente.TabIndex = 252
        '
        'pnlPreguntaHerida
        '
        Me.pnlPreguntaHerida.Controls.Add(Me.grbSeguimientoHeridas)
        Me.pnlPreguntaHerida.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPreguntaHerida.Location = New System.Drawing.Point(3, 20)
        Me.pnlPreguntaHerida.Name = "pnlPreguntaHerida"
        Me.pnlPreguntaHerida.Size = New System.Drawing.Size(1046, 58)
        Me.pnlPreguntaHerida.TabIndex = 255
        '
        'grbSeguimientoHeridas
        '
        Me.grbSeguimientoHeridas.Controls.Add(Me.lblPresentaHeridas)
        Me.grbSeguimientoHeridas.Controls.Add(Me.rbNoPresentaHerida)
        Me.grbSeguimientoHeridas.Controls.Add(Me.rbSiPresentaHerida)
        Me.grbSeguimientoHeridas.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbSeguimientoHeridas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.grbSeguimientoHeridas.Location = New System.Drawing.Point(1, 3)
        Me.grbSeguimientoHeridas.Name = "grbSeguimientoHeridas"
        Me.grbSeguimientoHeridas.Size = New System.Drawing.Size(1038, 51)
        Me.grbSeguimientoHeridas.TabIndex = 201
        Me.grbSeguimientoHeridas.TabStop = False
        Me.grbSeguimientoHeridas.Text = "Seguimiento Heridas"
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnGuardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btnGuardar.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_guardar
        Me.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btnGuardar.Location = New System.Drawing.Point(960, 297)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(89, 23)
        Me.btnGuardar.TabIndex = 259
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnTraerRespuesta
        '
        Me.btnTraerRespuesta.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btnTraerRespuesta.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_proponer
        Me.btnTraerRespuesta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnTraerRespuesta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTraerRespuesta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTraerRespuesta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTraerRespuesta.ForeColor = System.Drawing.SystemColors.Control
        Me.btnTraerRespuesta.Location = New System.Drawing.Point(922, 0)
        Me.btnTraerRespuesta.Name = "btnTraerRespuesta"
        Me.btnTraerRespuesta.Size = New System.Drawing.Size(147, 33)
        Me.btnTraerRespuesta.TabIndex = 192
        Me.btnTraerRespuesta.Tag = "37"
        Me.btnTraerRespuesta.UseVisualStyleBackColor = False
        '
        'lblTitulo
        '
        Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblTitulo.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(11, 7)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(197, 19)
        Me.lblTitulo.TabIndex = 217
        Me.lblTitulo.Text = "Enfermería Paliativos"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ParentescoDelIntegranteDeLaFamilia"
        Me.DataGridViewTextBoxColumn1.HeaderText = "IdParentesco"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 150
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "tip_doc"
        Me.DataGridViewTextBoxColumn2.HeaderText = "TipoDocumento"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Num_doc"
        Me.DataGridViewTextBoxColumn3.HeaderText = "NumeroDocumento"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Visible = False
        Me.DataGridViewTextBoxColumn3.Width = 110
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "NombreDelIntegranteDeLaFamilia"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Nombre"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Visible = False
        Me.DataGridViewTextBoxColumn4.Width = 250
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "dscParentescoDelIntegranteDeLaFamilia"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Parentesco"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 150
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "EdadDelIntegranteDeLaFamilia"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Edad"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 70
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "dscOcupacionDelIntegranteDeLaFamilia"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Ocupación"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Visible = False
        Me.DataGridViewTextBoxColumn7.Width = 250
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "ParentescoDelIntegranteDeLaFamilia"
        Me.DataGridViewTextBoxColumn8.HeaderText = "IdParentesco"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Visible = False
        Me.DataGridViewTextBoxColumn8.Width = 250
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "tip_doc"
        Me.DataGridViewTextBoxColumn9.HeaderText = "TipoDocumento"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Visible = False
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "Num_doc"
        Me.DataGridViewTextBoxColumn10.HeaderText = "NumeroDocumento"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Visible = False
        Me.DataGridViewTextBoxColumn10.Width = 190
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "NombreDelIntegranteDeLaFamilia"
        Me.DataGridViewTextBoxColumn11.HeaderText = "Nombre"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Visible = False
        Me.DataGridViewTextBoxColumn11.Width = 250
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "dscParentescoDelIntegranteDeLaFamilia"
        Me.DataGridViewTextBoxColumn12.HeaderText = "Parentesco"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Width = 150
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "EdadDelIntegranteDeLaFamilia"
        Me.DataGridViewTextBoxColumn13.HeaderText = "Edad"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.Width = 70
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "OcupacionDelIntegranteDeLaFamilia"
        Me.DataGridViewTextBoxColumn14.HeaderText = "IdOcupación"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.Visible = False
        Me.DataGridViewTextBoxColumn14.Width = 70
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "dscOcupacionDelIntegranteDeLaFamilia"
        Me.DataGridViewTextBoxColumn15.HeaderText = "Ocupación"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.Visible = False
        Me.DataGridViewTextBoxColumn15.Width = 250
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "dscOcupacionDelIntegranteDeLaFamilia"
        Me.DataGridViewTextBoxColumn16.HeaderText = "Ocupación"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.Width = 250
        '
        'ctlCPEnfermeria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.btnTraerRespuesta)
        Me.Controls.Add(Me.Panel16)
        Me.Name = "ctlCPEnfermeria"
        Me.Size = New System.Drawing.Size(1080, 1047)
        Me.grbProfesional.ResumeLayout(False)
        Me.grbProfesional.PerformLayout()
        Me.grbAdminMedicamentos.ResumeLayout(False)
        Me.grbAdminMedicamentos.PerformLayout()
        Me.pnlGrillaMedicamentos.ResumeLayout(False)
        CType(Me.dgvMedicamentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbEntornoSocioFamiliar.ResumeLayout(False)
        Me.grbEntornoSocioFamiliar.PerformLayout()
        Me.pnlContenedor.ResumeLayout(False)
        Me.pnlContenedor.PerformLayout()
        Me.Panel16.ResumeLayout(False)
        Me.Panel16.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.pnlHistoricoHeridas.ResumeLayout(False)
        CType(Me.dgvHeridasPaciente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPreguntaHerida.ResumeLayout(False)
        Me.grbSeguimientoHeridas.ResumeLayout(False)
        Me.grbSeguimientoHeridas.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grbProfesional As System.Windows.Forms.GroupBox
    Friend WithEvents txtNombreProfesional As HistoriaClinica.TextBoxConFormato
    Friend WithEvents lblNombreProfesional As System.Windows.Forms.Label
    Friend WithEvents grbAdminMedicamentos As System.Windows.Forms.GroupBox
    Friend WithEvents txtObsAdmin As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents mskFecHorAdmin As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbViaAdministracion As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDosis As HistoriaClinica.TextBoxConFormato
    Friend WithEvents txtNombreMedicamento As HistoriaClinica.TextBoxConFormato
    Friend WithEvents rbNoAdminMedicamento As System.Windows.Forms.RadioButton
    Friend WithEvents rbSiAdminMedicamento As System.Windows.Forms.RadioButton
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblAdminMedicamento As System.Windows.Forms.Label
    Friend WithEvents lblNombreMedicamento As System.Windows.Forms.Label
    Friend WithEvents grbEntornoSocioFamiliar As System.Windows.Forms.GroupBox
    Friend WithEvents txtEvolEnfermeria As System.Windows.Forms.TextBox
    Friend WithEvents lblEvolEnfermeria As System.Windows.Forms.Label
    Friend WithEvents txtCuidadoEnfermedad As System.Windows.Forms.TextBox
    Friend WithEvents lblCuidadoEnfermeria As System.Windows.Forms.Label
    Friend WithEvents lblPresentaHeridas As System.Windows.Forms.Label
    Friend WithEvents Panel16 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rbNoPresentaHerida As System.Windows.Forms.RadioButton
    Friend WithEvents rbSiPresentaHerida As System.Windows.Forms.RadioButton
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblHistoricoHeridas As System.Windows.Forms.Label
    Friend WithEvents dgvHeridasPaciente As System.Windows.Forms.DataGridView
    Friend WithEvents pnlContenedor As System.Windows.Forms.Panel
    Friend WithEvents pnlPreguntaHerida As System.Windows.Forms.Panel
    Friend WithEvents pnlContHerida As System.Windows.Forms.Panel
    Friend WithEvents pnlCateter As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlHistoricoHeridas As System.Windows.Forms.Panel
    Friend WithEvents grbSeguimientoHeridas As System.Windows.Forms.GroupBox
    Friend WithEvents btnTraerRespuesta As System.Windows.Forms.Button
    Friend WithEvents btnAgregarMedicamento As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblUnidadMedida As System.Windows.Forms.Label
    Friend WithEvents cmbUnidadMedida As System.Windows.Forms.ComboBox
    Friend WithEvents pnlGrillaMedicamentos As System.Windows.Forms.Panel
    Friend WithEvents dgvMedicamentos As System.Windows.Forms.DataGridView
    Friend WithEvents IdAdmin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaRegistro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoDoc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumDoc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Medicamento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Dosis As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViaAdmin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EsAdministrado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Horario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Observaciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnRespAdmin As System.Windows.Forms.Button
    Friend WithEvents btnRespHerida As System.Windows.Forms.Button
    Friend WithEvents lblTitulo As System.Windows.Forms.Label

End Class
