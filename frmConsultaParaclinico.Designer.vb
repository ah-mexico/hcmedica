<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaParaclinico
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaParaclinico))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btnSalir = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.dtgExamenes = New System.Windows.Forms.DataGridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.dtgDescr = New System.Windows.Forms.DataGridView
        Me.Label10 = New System.Windows.Forms.Label
        Me.mskFechaDesde = New System.Windows.Forms.MaskedTextBox
        Me.mskFechaHasta = New System.Windows.Forms.MaskedTextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtSegundoApellido = New HistoriaClinica.TextBoxConFormato
        Me.txtPrimerApellido = New HistoriaClinica.TextBoxConFormato
        Me.txtSegundoNombre = New HistoriaClinica.TextBoxConFormato
        Me.txtPrimerNombre = New HistoriaClinica.TextBoxConFormato
        Me.txtNumDoc = New HistoriaClinica.TextBoxConFormato
        Me.tbCodigoTipDoc = New HistoriaClinica.TextBoxConFormato
        Me.tbDescTipDoc = New HistoriaClinica.TextBoxConFormato
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Seleccion = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.OBR_04_EXAM_DESC = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dtgExamenes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.dtgDescr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.Transparent
        Me.btnSalir.BackgroundImage = CType(resources.GetObject("btnSalir.BackgroundImage"), System.Drawing.Image)
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.ForeColor = System.Drawing.Color.Transparent
        Me.btnSalir.Location = New System.Drawing.Point(755, 434)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(104, 22)
        Me.btnSalir.TabIndex = 27
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelar.BackgroundImage = CType(resources.GetObject("btnCancelar.BackgroundImage"), System.Drawing.Image)
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.ForeColor = System.Drawing.Color.Transparent
        Me.btnCancelar.Location = New System.Drawing.Point(645, 434)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(104, 22)
        Me.btnCancelar.TabIndex = 11
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnImprimir
        '
        Me.btnImprimir.BackColor = System.Drawing.Color.Transparent
        Me.btnImprimir.BackgroundImage = CType(resources.GetObject("btnImprimir.BackgroundImage"), System.Drawing.Image)
        Me.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimir.ForeColor = System.Drawing.Color.Transparent
        Me.btnImprimir.Location = New System.Drawing.Point(535, 434)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(104, 22)
        Me.btnImprimir.TabIndex = 10
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'dtgExamenes
        '
        Me.dtgExamenes.AllowUserToAddRows = False
        Me.dtgExamenes.AllowUserToDeleteRows = False
        Me.dtgExamenes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgExamenes.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgExamenes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgExamenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(210, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgExamenes.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtgExamenes.GridColor = System.Drawing.Color.Gray
        Me.dtgExamenes.Location = New System.Drawing.Point(8, 300)
        Me.dtgExamenes.Name = "dtgExamenes"
        Me.dtgExamenes.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(210, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgExamenes.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(210, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        Me.dtgExamenes.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dtgExamenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgExamenes.Size = New System.Drawing.Size(855, 109)
        Me.dtgExamenes.TabIndex = 9
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
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos del Paciente"
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
        Me.btnBuscar.BackgroundImage = CType(resources.GetObject("btnBuscar.BackgroundImage"), System.Drawing.Image)
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
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(1, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(867, 39)
        Me.PictureBox1.TabIndex = 57
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.dtgDescr)
        Me.Panel1.Controls.Add(Me.dtgExamenes)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.btnImprimir)
        Me.Panel1.Controls.Add(Me.mskFechaDesde)
        Me.Panel1.Controls.Add(Me.mskFechaHasta)
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.btnSalir)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Location = New System.Drawing.Point(1, 39)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(868, 520)
        Me.Panel1.TabIndex = 0
        Me.Panel1.TabStop = True
        '
        'dtgDescr
        '
        Me.dtgDescr.AllowUserToAddRows = False
        Me.dtgDescr.AllowUserToOrderColumns = True
        Me.dtgDescr.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        Me.dtgDescr.BackgroundColor = System.Drawing.Color.White
        Me.dtgDescr.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgDescr.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dtgDescr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgDescr.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Seleccion, Me.OBR_04_EXAM_DESC})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(210, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgDescr.DefaultCellStyle = DataGridViewCellStyle6
        Me.dtgDescr.Location = New System.Drawing.Point(111, 203)
        Me.dtgDescr.Name = "dtgDescr"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(210, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgDescr.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dtgDescr.Size = New System.Drawing.Size(443, 91)
        Me.dtgDescr.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(432, 38)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 13)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "dd/mm/aaaa"
        '
        'mskFechaDesde
        '
        Me.mskFechaDesde.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskFechaDesde.Location = New System.Drawing.Point(75, 35)
        Me.mskFechaDesde.Mask = "00/00/0000"
        Me.mskFechaDesde.Name = "mskFechaDesde"
        Me.mskFechaDesde.Size = New System.Drawing.Size(90, 21)
        Me.mskFechaDesde.TabIndex = 12
        Me.mskFechaDesde.ValidatingType = GetType(Date)
        '
        'mskFechaHasta
        '
        Me.mskFechaHasta.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskFechaHasta.Location = New System.Drawing.Point(336, 35)
        Me.mskFechaHasta.Mask = "00/00/0000"
        Me.mskFechaHasta.Name = "mskFechaHasta"
        Me.mskFechaHasta.Size = New System.Drawing.Size(90, 21)
        Me.mskFechaHasta.TabIndex = 13
        Me.mskFechaHasta.ValidatingType = GetType(Date)
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(22, 38)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Desde"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(290, 38)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Hasta"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(171, 38)
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
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 115
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
        Me.tbCodigoTipDoc.Format = HistoriaClinica.tbFormats.AlfabéticoSinEspacios
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
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "estado"
        Me.DataGridViewTextBoxColumn9.FillWeight = 50.0!
        Me.DataGridViewTextBoxColumn9.HeaderText = "Estado Historia"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn9.Width = 75
        '
        'Seleccion
        '
        Me.Seleccion.DataPropertyName = "Seleccion"
        Me.Seleccion.FalseValue = "N"
        Me.Seleccion.HeaderText = "Sel"
        Me.Seleccion.Name = "Seleccion"
        Me.Seleccion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Seleccion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Seleccion.TrueValue = "S"
        Me.Seleccion.Width = 30
        '
        'OBR_04_EXAM_DESC
        '
        Me.OBR_04_EXAM_DESC.DataPropertyName = "OBR_04_EXAM_DESC"
        Me.OBR_04_EXAM_DESC.HeaderText = "Descripcion"
        Me.OBR_04_EXAM_DESC.Name = "OBR_04_EXAM_DESC"
        Me.OBR_04_EXAM_DESC.ReadOnly = True
        Me.OBR_04_EXAM_DESC.Width = 370
        '
        'frmConsultaParaclinico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(869, 571)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frmConsultaParaclinico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta Historia Clinica"
        CType(Me.dtgExamenes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dtgDescr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents dtgExamenes As System.Windows.Forms.DataGridView
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
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents mskFechaDesde As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mskFechaHasta As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgDescr As System.Windows.Forms.DataGridView
    Friend WithEvents Seleccion As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents OBR_04_EXAM_DESC As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
