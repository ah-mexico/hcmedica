<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtlReunionFamiliar
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grpMiembrosParticipantes = New System.Windows.Forms.GroupBox()
        Me.cmdAdicionarMiembrosParticipantes = New System.Windows.Forms.Button()
        Me.cboEspecialidad = New System.Windows.Forms.ComboBox()
        Me.txtNombreProfesional = New HistoriaClinica.TextBoxConFormato()
        Me.lblEspecialidad = New System.Windows.Forms.Label()
        Me.LblNombreProfesional = New System.Windows.Forms.Label()
        Me.pnlMiembrosParticipantes = New System.Windows.Forms.Panel()
        Me.grdMiembrosParticipantes = New System.Windows.Forms.DataGridView()
        Me.IdEspecialidad = New HistoriaClinica.Sophia.HistoriaClinica.Comunes.CeldaNumerica()
        Me.NombreProfesional = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreEspecialidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grpFamiliaresParticipantes = New System.Windows.Forms.GroupBox()
        Me.cboVinculoPaciente = New System.Windows.Forms.ComboBox()
        Me.cmdAdicionarFamiliaresParticipantes = New System.Windows.Forms.Button()
        Me.txtNombreFamiliar = New HistoriaClinica.TextBoxConFormato()
        Me.lblVinculoPaciente = New System.Windows.Forms.Label()
        Me.lblNombreFamiliar = New System.Windows.Forms.Label()
        Me.pnlFamiliaresParticipantes = New System.Windows.Forms.Panel()
        Me.grdFamiliaresParticipantes = New System.Windows.Forms.DataGridView()
        Me.CeldaNumerica2 = New HistoriaClinica.Sophia.HistoriaClinica.Comunes.CeldaNumerica()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CeldaNumerica1 = New HistoriaClinica.Sophia.HistoriaClinica.Comunes.CeldaNumerica()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtEstrategiasSeguir = New System.Windows.Forms.TextBox()
        Me.txtInfoReunion = New System.Windows.Forms.TextBox()
        Me.lblInfoReunion = New System.Windows.Forms.Label()
        Me.txtTemasPendientes = New System.Windows.Forms.TextBox()
        Me.lblEstrategiasSeguir = New System.Windows.Forms.Label()
        Me.lblTemasPendientes = New System.Windows.Forms.Label()
        Me.txtPreocEmergentes = New System.Windows.Forms.TextBox()
        Me.lblPreocEmergentes = New System.Windows.Forms.Label()
        Me.btnSugerirRespuesta = New System.Windows.Forms.Button()
        Me.cmdGuardarRF = New System.Windows.Forms.Button()
        Me.grpMiembrosParticipantes.SuspendLayout()
        Me.pnlMiembrosParticipantes.SuspendLayout()
        CType(Me.grdMiembrosParticipantes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFamiliaresParticipantes.SuspendLayout()
        Me.pnlFamiliaresParticipantes.SuspendLayout()
        CType(Me.grdFamiliaresParticipantes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpMiembrosParticipantes
        '
        Me.grpMiembrosParticipantes.Controls.Add(Me.cmdAdicionarMiembrosParticipantes)
        Me.grpMiembrosParticipantes.Controls.Add(Me.cboEspecialidad)
        Me.grpMiembrosParticipantes.Controls.Add(Me.txtNombreProfesional)
        Me.grpMiembrosParticipantes.Controls.Add(Me.lblEspecialidad)
        Me.grpMiembrosParticipantes.Controls.Add(Me.LblNombreProfesional)
        Me.grpMiembrosParticipantes.Controls.Add(Me.pnlMiembrosParticipantes)
        Me.grpMiembrosParticipantes.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpMiembrosParticipantes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.grpMiembrosParticipantes.Location = New System.Drawing.Point(18, 34)
        Me.grpMiembrosParticipantes.Name = "grpMiembrosParticipantes"
        Me.grpMiembrosParticipantes.Size = New System.Drawing.Size(1079, 261)
        Me.grpMiembrosParticipantes.TabIndex = 115
        Me.grpMiembrosParticipantes.TabStop = False
        Me.grpMiembrosParticipantes.Text = "Miembros Participantes del Equipo"
        '
        'cmdAdicionarMiembrosParticipantes
        '
        Me.cmdAdicionarMiembrosParticipantes.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_agregar
        Me.cmdAdicionarMiembrosParticipantes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmdAdicionarMiembrosParticipantes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdAdicionarMiembrosParticipantes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cmdAdicionarMiembrosParticipantes.Location = New System.Drawing.Point(843, 67)
        Me.cmdAdicionarMiembrosParticipantes.Name = "cmdAdicionarMiembrosParticipantes"
        Me.cmdAdicionarMiembrosParticipantes.Size = New System.Drawing.Size(75, 23)
        Me.cmdAdicionarMiembrosParticipantes.TabIndex = 3
        '
        'cboEspecialidad
        '
        Me.cboEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEspecialidad.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.cboEspecialidad.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboEspecialidad.FormattingEnabled = True
        Me.cboEspecialidad.Location = New System.Drawing.Point(381, 67)
        Me.cboEspecialidad.Name = "cboEspecialidad"
        Me.cboEspecialidad.Size = New System.Drawing.Size(398, 22)
        Me.cboEspecialidad.TabIndex = 2
        '
        'txtNombreProfesional
        '
        Me.txtNombreProfesional.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreProfesional.ControlComboEnlace = Nothing
        Me.txtNombreProfesional.ControlTextoEnlace = Nothing
        Me.txtNombreProfesional.DatoRelacionado = Nothing
        Me.txtNombreProfesional.Decimals = CType(2, Byte)
        Me.txtNombreProfesional.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtNombreProfesional.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreProfesional.Format = HistoriaClinica.tbFormats.AlfabéticoConEspacios
        Me.txtNombreProfesional.Location = New System.Drawing.Point(381, 34)
        Me.txtNombreProfesional.MaxLength = 50
        Me.txtNombreProfesional.Name = "txtNombreProfesional"
        Me.txtNombreProfesional.NombreCampoBuscado = Nothing
        Me.txtNombreProfesional.NombreCampoBusqueda = Nothing
        Me.txtNombreProfesional.NombreCampoDatos = Nothing
        Me.txtNombreProfesional.Obligatorio = False
        Me.txtNombreProfesional.OrigenDeDatos = Nothing
        Me.txtNombreProfesional.PermitirValorCero = False
        Me.txtNombreProfesional.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtNombreProfesional.Size = New System.Drawing.Size(466, 22)
        Me.txtNombreProfesional.TabIndex = 1
        Me.txtNombreProfesional.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtNombreProfesional.UserValues = Nothing
        Me.txtNombreProfesional.ValorMaximo = CType(0, Long)
        Me.txtNombreProfesional.ValorMinimo = CType(0, Long)
        '
        'lblEspecialidad
        '
        Me.lblEspecialidad.BackColor = System.Drawing.Color.Transparent
        Me.lblEspecialidad.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEspecialidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblEspecialidad.Location = New System.Drawing.Point(197, 67)
        Me.lblEspecialidad.Name = "lblEspecialidad"
        Me.lblEspecialidad.Size = New System.Drawing.Size(178, 22)
        Me.lblEspecialidad.TabIndex = 176
        Me.lblEspecialidad.Text = "Especialidad"
        Me.lblEspecialidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblNombreProfesional
        '
        Me.LblNombreProfesional.BackColor = System.Drawing.Color.Transparent
        Me.LblNombreProfesional.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNombreProfesional.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.LblNombreProfesional.Location = New System.Drawing.Point(197, 34)
        Me.LblNombreProfesional.Name = "LblNombreProfesional"
        Me.LblNombreProfesional.Size = New System.Drawing.Size(178, 22)
        Me.LblNombreProfesional.TabIndex = 175
        Me.LblNombreProfesional.Text = "Nombre del Profesional"
        Me.LblNombreProfesional.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlMiembrosParticipantes
        '
        Me.pnlMiembrosParticipantes.Controls.Add(Me.grdMiembrosParticipantes)
        Me.pnlMiembrosParticipantes.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlMiembrosParticipantes.Location = New System.Drawing.Point(200, 115)
        Me.pnlMiembrosParticipantes.Name = "pnlMiembrosParticipantes"
        Me.pnlMiembrosParticipantes.Size = New System.Drawing.Size(727, 140)
        Me.pnlMiembrosParticipantes.TabIndex = 183
        '
        'grdMiembrosParticipantes
        '
        Me.grdMiembrosParticipantes.AllowUserToAddRows = False
        Me.grdMiembrosParticipantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdMiembrosParticipantes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grdMiembrosParticipantes.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.grdMiembrosParticipantes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdMiembrosParticipantes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdMiembrosParticipantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdMiembrosParticipantes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdEspecialidad, Me.NombreProfesional, Me.NombreEspecialidad})
        Me.grdMiembrosParticipantes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdMiembrosParticipantes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.grdMiembrosParticipantes.Location = New System.Drawing.Point(0, 0)
        Me.grdMiembrosParticipantes.MultiSelect = False
        Me.grdMiembrosParticipantes.Name = "grdMiembrosParticipantes"
        Me.grdMiembrosParticipantes.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdMiembrosParticipantes.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.grdMiembrosParticipantes.RowHeadersWidth = 30
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdMiembrosParticipantes.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.grdMiembrosParticipantes.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdMiembrosParticipantes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.grdMiembrosParticipantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdMiembrosParticipantes.Size = New System.Drawing.Size(727, 140)
        Me.grdMiembrosParticipantes.TabIndex = 184
        Me.grdMiembrosParticipantes.TabStop = False
        '
        'IdEspecialidad
        '
        Me.IdEspecialidad.DataPropertyName = "IdEspecialidad"
        Me.IdEspecialidad.FormatCelda = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.IdEspecialidad.HeaderText = "IdEspecialidad"
        Me.IdEspecialidad.Longitud = 0
        Me.IdEspecialidad.Name = "IdEspecialidad"
        Me.IdEspecialidad.NumeroDecimals = 0
        Me.IdEspecialidad.ReadOnly = True
        Me.IdEspecialidad.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IdEspecialidad.SeparadorDecimal = Global.Microsoft.VisualBasic.ChrW(0)
        Me.IdEspecialidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.IdEspecialidad.TipoControlCelda = HistoriaClinica.tbTipoControl.Normal
        Me.IdEspecialidad.ValorMaximo = 0
        Me.IdEspecialidad.ValorMinimo = 0
        Me.IdEspecialidad.Visible = False
        '
        'NombreProfesional
        '
        Me.NombreProfesional.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.NombreProfesional.DataPropertyName = "NombreProfesional"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.NombreProfesional.DefaultCellStyle = DataGridViewCellStyle2
        Me.NombreProfesional.HeaderText = "Nombre Profesional"
        Me.NombreProfesional.Name = "NombreProfesional"
        Me.NombreProfesional.ReadOnly = True
        Me.NombreProfesional.Width = 281
        '
        'NombreEspecialidad
        '
        Me.NombreEspecialidad.DataPropertyName = "NombreEspecialidad"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.NombreEspecialidad.DefaultCellStyle = DataGridViewCellStyle3
        Me.NombreEspecialidad.HeaderText = "Especialidad"
        Me.NombreEspecialidad.Name = "NombreEspecialidad"
        Me.NombreEspecialidad.ReadOnly = True
        '
        'grpFamiliaresParticipantes
        '
        Me.grpFamiliaresParticipantes.Controls.Add(Me.cboVinculoPaciente)
        Me.grpFamiliaresParticipantes.Controls.Add(Me.cmdAdicionarFamiliaresParticipantes)
        Me.grpFamiliaresParticipantes.Controls.Add(Me.txtNombreFamiliar)
        Me.grpFamiliaresParticipantes.Controls.Add(Me.lblVinculoPaciente)
        Me.grpFamiliaresParticipantes.Controls.Add(Me.lblNombreFamiliar)
        Me.grpFamiliaresParticipantes.Controls.Add(Me.pnlFamiliaresParticipantes)
        Me.grpFamiliaresParticipantes.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
        Me.grpFamiliaresParticipantes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.grpFamiliaresParticipantes.Location = New System.Drawing.Point(18, 300)
        Me.grpFamiliaresParticipantes.Name = "grpFamiliaresParticipantes"
        Me.grpFamiliaresParticipantes.Size = New System.Drawing.Size(1079, 261)
        Me.grpFamiliaresParticipantes.TabIndex = 116
        Me.grpFamiliaresParticipantes.TabStop = False
        Me.grpFamiliaresParticipantes.Text = "Familiares que Participaron en la reunión"
        '
        'cboVinculoPaciente
        '
        Me.cboVinculoPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVinculoPaciente.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.cboVinculoPaciente.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboVinculoPaciente.FormattingEnabled = True
        Me.cboVinculoPaciente.Location = New System.Drawing.Point(381, 67)
        Me.cboVinculoPaciente.Name = "cboVinculoPaciente"
        Me.cboVinculoPaciente.Size = New System.Drawing.Size(398, 22)
        Me.cboVinculoPaciente.TabIndex = 5
        '
        'cmdAdicionarFamiliaresParticipantes
        '
        Me.cmdAdicionarFamiliaresParticipantes.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_agregar
        Me.cmdAdicionarFamiliaresParticipantes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmdAdicionarFamiliaresParticipantes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdAdicionarFamiliaresParticipantes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cmdAdicionarFamiliaresParticipantes.Location = New System.Drawing.Point(843, 68)
        Me.cmdAdicionarFamiliaresParticipantes.Name = "cmdAdicionarFamiliaresParticipantes"
        Me.cmdAdicionarFamiliaresParticipantes.Size = New System.Drawing.Size(75, 23)
        Me.cmdAdicionarFamiliaresParticipantes.TabIndex = 6
        '
        'txtNombreFamiliar
        '
        Me.txtNombreFamiliar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreFamiliar.ControlComboEnlace = Nothing
        Me.txtNombreFamiliar.ControlTextoEnlace = Nothing
        Me.txtNombreFamiliar.DatoRelacionado = Nothing
        Me.txtNombreFamiliar.Decimals = CType(2, Byte)
        Me.txtNombreFamiliar.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtNombreFamiliar.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreFamiliar.Format = HistoriaClinica.tbFormats.AlfabéticoConEspacios
        Me.txtNombreFamiliar.Location = New System.Drawing.Point(381, 33)
        Me.txtNombreFamiliar.MaxLength = 50
        Me.txtNombreFamiliar.Name = "txtNombreFamiliar"
        Me.txtNombreFamiliar.NombreCampoBuscado = Nothing
        Me.txtNombreFamiliar.NombreCampoBusqueda = Nothing
        Me.txtNombreFamiliar.NombreCampoDatos = Nothing
        Me.txtNombreFamiliar.Obligatorio = False
        Me.txtNombreFamiliar.OrigenDeDatos = Nothing
        Me.txtNombreFamiliar.PermitirValorCero = False
        Me.txtNombreFamiliar.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtNombreFamiliar.Size = New System.Drawing.Size(466, 22)
        Me.txtNombreFamiliar.TabIndex = 4
        Me.txtNombreFamiliar.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtNombreFamiliar.UserValues = Nothing
        Me.txtNombreFamiliar.ValorMaximo = CType(0, Long)
        Me.txtNombreFamiliar.ValorMinimo = CType(0, Long)
        '
        'lblVinculoPaciente
        '
        Me.lblVinculoPaciente.BackColor = System.Drawing.Color.Transparent
        Me.lblVinculoPaciente.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVinculoPaciente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblVinculoPaciente.Location = New System.Drawing.Point(197, 64)
        Me.lblVinculoPaciente.Name = "lblVinculoPaciente"
        Me.lblVinculoPaciente.Size = New System.Drawing.Size(164, 22)
        Me.lblVinculoPaciente.TabIndex = 176
        Me.lblVinculoPaciente.Text = "Vinculo con el Paciente"
        Me.lblVinculoPaciente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNombreFamiliar
        '
        Me.lblNombreFamiliar.BackColor = System.Drawing.Color.Transparent
        Me.lblNombreFamiliar.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreFamiliar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblNombreFamiliar.Location = New System.Drawing.Point(197, 33)
        Me.lblNombreFamiliar.Name = "lblNombreFamiliar"
        Me.lblNombreFamiliar.Size = New System.Drawing.Size(152, 22)
        Me.lblNombreFamiliar.TabIndex = 175
        Me.lblNombreFamiliar.Text = "Nombre del Familiar"
        Me.lblNombreFamiliar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlFamiliaresParticipantes
        '
        Me.pnlFamiliaresParticipantes.Controls.Add(Me.grdFamiliaresParticipantes)
        Me.pnlFamiliaresParticipantes.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlFamiliaresParticipantes.Location = New System.Drawing.Point(200, 115)
        Me.pnlFamiliaresParticipantes.Name = "pnlFamiliaresParticipantes"
        Me.pnlFamiliaresParticipantes.Size = New System.Drawing.Size(727, 140)
        Me.pnlFamiliaresParticipantes.TabIndex = 210
        '
        'grdFamiliaresParticipantes
        '
        Me.grdFamiliaresParticipantes.AllowUserToAddRows = False
        Me.grdFamiliaresParticipantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdFamiliaresParticipantes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grdFamiliaresParticipantes.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.grdFamiliaresParticipantes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdFamiliaresParticipantes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.grdFamiliaresParticipantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdFamiliaresParticipantes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CeldaNumerica2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        Me.grdFamiliaresParticipantes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdFamiliaresParticipantes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.grdFamiliaresParticipantes.Location = New System.Drawing.Point(0, 0)
        Me.grdFamiliaresParticipantes.MultiSelect = False
        Me.grdFamiliaresParticipantes.Name = "grdFamiliaresParticipantes"
        Me.grdFamiliaresParticipantes.ReadOnly = True
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdFamiliaresParticipantes.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.grdFamiliaresParticipantes.RowHeadersWidth = 30
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.grdFamiliaresParticipantes.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.grdFamiliaresParticipantes.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdFamiliaresParticipantes.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.grdFamiliaresParticipantes.RowTemplate.Height = 24
        Me.grdFamiliaresParticipantes.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdFamiliaresParticipantes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.grdFamiliaresParticipantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdFamiliaresParticipantes.Size = New System.Drawing.Size(727, 140)
        Me.grdFamiliaresParticipantes.TabIndex = 209
        Me.grdFamiliaresParticipantes.TabStop = False
        '
        'CeldaNumerica2
        '
        Me.CeldaNumerica2.DataPropertyName = "IdVinculo"
        Me.CeldaNumerica2.FormatCelda = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.CeldaNumerica2.HeaderText = "IdVinculo"
        Me.CeldaNumerica2.Longitud = 0
        Me.CeldaNumerica2.Name = "CeldaNumerica2"
        Me.CeldaNumerica2.NumeroDecimals = 0
        Me.CeldaNumerica2.ReadOnly = True
        Me.CeldaNumerica2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CeldaNumerica2.SeparadorDecimal = Global.Microsoft.VisualBasic.ChrW(0)
        Me.CeldaNumerica2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.CeldaNumerica2.TipoControlCelda = HistoriaClinica.tbTipoControl.Normal
        Me.CeldaNumerica2.ValorMaximo = 0
        Me.CeldaNumerica2.ValorMinimo = 0
        Me.CeldaNumerica2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "NombreFamiliar"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Nombre del Familiar"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 281
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "VinculoPaciente"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Vínculo con el Paciente"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 414
        '
        'CeldaNumerica1
        '
        Me.CeldaNumerica1.DataPropertyName = "IdEspecialidad"
        Me.CeldaNumerica1.FormatCelda = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.CeldaNumerica1.HeaderText = "IdEspecialidad"
        Me.CeldaNumerica1.Longitud = 0
        Me.CeldaNumerica1.Name = "CeldaNumerica1"
        Me.CeldaNumerica1.NumeroDecimals = 0
        Me.CeldaNumerica1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CeldaNumerica1.SeparadorDecimal = Global.Microsoft.VisualBasic.ChrW(0)
        Me.CeldaNumerica1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.CeldaNumerica1.TipoControlCelda = HistoriaClinica.tbTipoControl.Normal
        Me.CeldaNumerica1.ValorMaximo = 0
        Me.CeldaNumerica1.ValorMinimo = 0
        Me.CeldaNumerica1.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "NombreProfesional"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Nombre Profesional"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 281
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "NombreEspecialidad"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Especialidad"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'txtEstrategiasSeguir
        '
        Me.txtEstrategiasSeguir.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEstrategiasSeguir.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstrategiasSeguir.Location = New System.Drawing.Point(462, 897)
        Me.txtEstrategiasSeguir.MaxLength = 800
        Me.txtEstrategiasSeguir.Multiline = True
        Me.txtEstrategiasSeguir.Name = "txtEstrategiasSeguir"
        Me.txtEstrategiasSeguir.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtEstrategiasSeguir.Size = New System.Drawing.Size(483, 99)
        Me.txtEstrategiasSeguir.TabIndex = 10
        '
        'txtInfoReunion
        '
        Me.txtInfoReunion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInfoReunion.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInfoReunion.Location = New System.Drawing.Point(462, 566)
        Me.txtInfoReunion.MaxLength = 1800
        Me.txtInfoReunion.Multiline = True
        Me.txtInfoReunion.Name = "txtInfoReunion"
        Me.txtInfoReunion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtInfoReunion.Size = New System.Drawing.Size(483, 99)
        Me.txtInfoReunion.TabIndex = 7
        '
        'lblInfoReunion
        '
        Me.lblInfoReunion.BackColor = System.Drawing.Color.Transparent
        Me.lblInfoReunion.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfoReunion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblInfoReunion.Location = New System.Drawing.Point(213, 566)
        Me.lblInfoReunion.Name = "lblInfoReunion"
        Me.lblInfoReunion.Size = New System.Drawing.Size(252, 99)
        Me.lblInfoReunion.TabIndex = 212
        Me.lblInfoReunion.Text = "Información Brindada en la Reunión"
        Me.lblInfoReunion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTemasPendientes
        '
        Me.txtTemasPendientes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTemasPendientes.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTemasPendientes.Location = New System.Drawing.Point(462, 785)
        Me.txtTemasPendientes.MaxLength = 800
        Me.txtTemasPendientes.Multiline = True
        Me.txtTemasPendientes.Name = "txtTemasPendientes"
        Me.txtTemasPendientes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTemasPendientes.Size = New System.Drawing.Size(483, 99)
        Me.txtTemasPendientes.TabIndex = 9
        '
        'lblEstrategiasSeguir
        '
        Me.lblEstrategiasSeguir.BackColor = System.Drawing.Color.Transparent
        Me.lblEstrategiasSeguir.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstrategiasSeguir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblEstrategiasSeguir.Location = New System.Drawing.Point(213, 897)
        Me.lblEstrategiasSeguir.Name = "lblEstrategiasSeguir"
        Me.lblEstrategiasSeguir.Size = New System.Drawing.Size(252, 99)
        Me.lblEstrategiasSeguir.TabIndex = 210
        Me.lblEstrategiasSeguir.Text = "Estrategias a Seguir"
        Me.lblEstrategiasSeguir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTemasPendientes
        '
        Me.lblTemasPendientes.BackColor = System.Drawing.Color.Transparent
        Me.lblTemasPendientes.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTemasPendientes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblTemasPendientes.Location = New System.Drawing.Point(213, 785)
        Me.lblTemasPendientes.Name = "lblTemasPendientes"
        Me.lblTemasPendientes.Size = New System.Drawing.Size(252, 99)
        Me.lblTemasPendientes.TabIndex = 208
        Me.lblTemasPendientes.Text = "Temas Pendientes"
        Me.lblTemasPendientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPreocEmergentes
        '
        Me.txtPreocEmergentes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPreocEmergentes.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPreocEmergentes.Location = New System.Drawing.Point(462, 673)
        Me.txtPreocEmergentes.MaxLength = 800
        Me.txtPreocEmergentes.Multiline = True
        Me.txtPreocEmergentes.Name = "txtPreocEmergentes"
        Me.txtPreocEmergentes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPreocEmergentes.Size = New System.Drawing.Size(483, 99)
        Me.txtPreocEmergentes.TabIndex = 8
        '
        'lblPreocEmergentes
        '
        Me.lblPreocEmergentes.BackColor = System.Drawing.Color.Transparent
        Me.lblPreocEmergentes.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPreocEmergentes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblPreocEmergentes.Location = New System.Drawing.Point(213, 673)
        Me.lblPreocEmergentes.Name = "lblPreocEmergentes"
        Me.lblPreocEmergentes.Size = New System.Drawing.Size(252, 99)
        Me.lblPreocEmergentes.TabIndex = 206
        Me.lblPreocEmergentes.Text = "Preocupaciones y dificultades Emergentes"
        Me.lblPreocEmergentes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSugerirRespuesta
        '
        Me.btnSugerirRespuesta.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btnSugerirRespuesta.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_proponer
        Me.btnSugerirRespuesta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSugerirRespuesta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSugerirRespuesta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSugerirRespuesta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSugerirRespuesta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btnSugerirRespuesta.Location = New System.Drawing.Point(947, 7)
        Me.btnSugerirRespuesta.Name = "btnSugerirRespuesta"
        Me.btnSugerirRespuesta.Size = New System.Drawing.Size(145, 26)
        Me.btnSugerirRespuesta.TabIndex = 214
        Me.btnSugerirRespuesta.Tag = "37"
        Me.btnSugerirRespuesta.UseVisualStyleBackColor = False
        '
        'cmdGuardarRF
        '
        Me.cmdGuardarRF.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_guardar
        Me.cmdGuardarRF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmdGuardarRF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdGuardarRF.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cmdGuardarRF.Location = New System.Drawing.Point(1006, 1010)
        Me.cmdGuardarRF.Name = "cmdGuardarRF"
        Me.cmdGuardarRF.Size = New System.Drawing.Size(74, 26)
        Me.cmdGuardarRF.TabIndex = 11
        Me.cmdGuardarRF.UseVisualStyleBackColor = True
        '
        'CtlReunionFamiliar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Controls.Add(Me.btnSugerirRespuesta)
        Me.Controls.Add(Me.txtEstrategiasSeguir)
        Me.Controls.Add(Me.txtInfoReunion)
        Me.Controls.Add(Me.lblInfoReunion)
        Me.Controls.Add(Me.txtTemasPendientes)
        Me.Controls.Add(Me.lblEstrategiasSeguir)
        Me.Controls.Add(Me.lblTemasPendientes)
        Me.Controls.Add(Me.txtPreocEmergentes)
        Me.Controls.Add(Me.lblPreocEmergentes)
        Me.Controls.Add(Me.cmdGuardarRF)
        Me.Controls.Add(Me.grpFamiliaresParticipantes)
        Me.Controls.Add(Me.grpMiembrosParticipantes)
        Me.Name = "CtlReunionFamiliar"
        Me.Size = New System.Drawing.Size(1100, 1050)
        Me.grpMiembrosParticipantes.ResumeLayout(False)
        Me.grpMiembrosParticipantes.PerformLayout()
        Me.pnlMiembrosParticipantes.ResumeLayout(False)
        CType(Me.grdMiembrosParticipantes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFamiliaresParticipantes.ResumeLayout(False)
        Me.grpFamiliaresParticipantes.PerformLayout()
        Me.pnlFamiliaresParticipantes.ResumeLayout(False)
        CType(Me.grdFamiliaresParticipantes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpMiembrosParticipantes As System.Windows.Forms.GroupBox
    Friend WithEvents cmdAdicionarMiembrosParticipantes As System.Windows.Forms.Button
    Friend WithEvents cboEspecialidad As System.Windows.Forms.ComboBox
    Friend WithEvents txtNombreProfesional As HistoriaClinica.TextBoxConFormato
    Friend WithEvents lblEspecialidad As System.Windows.Forms.Label
    Friend WithEvents LblNombreProfesional As System.Windows.Forms.Label
    Friend WithEvents grpFamiliaresParticipantes As System.Windows.Forms.GroupBox
    Friend WithEvents txtNombreFamiliar As HistoriaClinica.TextBoxConFormato
    Friend WithEvents lblVinculoPaciente As System.Windows.Forms.Label
    Friend WithEvents lblNombreFamiliar As System.Windows.Forms.Label
    Friend WithEvents CeldaNumerica1 As HistoriaClinica.Sophia.HistoriaClinica.Comunes.CeldaNumerica
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdGuardarRF As System.Windows.Forms.Button
    Friend WithEvents txtEstrategiasSeguir As System.Windows.Forms.TextBox
    Friend WithEvents txtInfoReunion As System.Windows.Forms.TextBox
    Friend WithEvents lblInfoReunion As System.Windows.Forms.Label
    Friend WithEvents txtTemasPendientes As System.Windows.Forms.TextBox
    Friend WithEvents lblEstrategiasSeguir As System.Windows.Forms.Label
    Friend WithEvents lblTemasPendientes As System.Windows.Forms.Label
    Friend WithEvents txtPreocEmergentes As System.Windows.Forms.TextBox
    Friend WithEvents lblPreocEmergentes As System.Windows.Forms.Label
    Friend WithEvents btnSugerirRespuesta As System.Windows.Forms.Button
    Friend WithEvents cmdAdicionarFamiliaresParticipantes As System.Windows.Forms.Button
    Friend WithEvents cboVinculoPaciente As System.Windows.Forms.ComboBox
    Friend WithEvents pnlMiembrosParticipantes As System.Windows.Forms.Panel
    Friend WithEvents grdMiembrosParticipantes As System.Windows.Forms.DataGridView
    Friend WithEvents IdEspecialidad As HistoriaClinica.Sophia.HistoriaClinica.Comunes.CeldaNumerica
    Friend WithEvents NombreProfesional As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombreEspecialidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlFamiliaresParticipantes As System.Windows.Forms.Panel
    Friend WithEvents grdFamiliaresParticipantes As System.Windows.Forms.DataGridView
    Friend WithEvents CeldaNumerica2 As HistoriaClinica.Sophia.HistoriaClinica.Comunes.CeldaNumerica
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
