<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConsultaHCEnfermeriaAlejo
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Planeación de Medicamentos")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Planeación de Ordenes Generales")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Planeación de Cuidados de Enfermeria")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Planeacion", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3})
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Evolución Enfermeria")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Control Cateter - Inserción")
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Historia")
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Recien Nacido")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Notas de Enfermeria", New System.Windows.Forms.TreeNode() {TreeNode5, TreeNode6, TreeNode7, TreeNode8})
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Riesgo Caida")
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("RASS")
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Cam - IW")
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Riesgo Caida Pediatria")
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sarnat")
        Dim TreeNode15 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Tiss 28")
        Dim TreeNode16 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Valoración Dolor Neonatos")
        Dim TreeNode17 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Lesión de piel")
        Dim TreeNode18 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Escalas", New System.Windows.Forms.TreeNode() {TreeNode10, TreeNode11, TreeNode12, TreeNode13, TreeNode14, TreeNode15, TreeNode16, TreeNode17})
        Dim TreeNode19 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Signos Vitales")
        Dim TreeNode20 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Hoja Neurologica")
        Dim TreeNode21 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Seguimiento Dolor")
        Dim TreeNode22 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Hoja Toxemica")
        Dim TreeNode23 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Hemodinamico")
        Dim TreeNode24 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Hemodialisis")
        Dim TreeNode25 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Plasmaferesis")
        Dim TreeNode26 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("NeoNatal")
        Dim TreeNode27 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Liquidos")
        Dim TreeNode28 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Monitoreo", New System.Windows.Forms.TreeNode() {TreeNode19, TreeNode20, TreeNode21, TreeNode22, TreeNode23, TreeNode24, TreeNode25, TreeNode26, TreeNode27})
        Dim TreeNode29 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Todos", New System.Windows.Forms.TreeNode() {TreeNode4, TreeNode9, TreeNode18, TreeNode28})
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.dtgAdmisiones = New System.Windows.Forms.DataGridView()
        Me.btnTraer = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rbImpEnf = New System.Windows.Forms.RadioButton()
        Me.rbImpMed = New System.Windows.Forms.RadioButton()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CBHoraDesde = New System.Windows.Forms.ComboBox()
        Me.mskFechaDesde = New System.Windows.Forms.MaskedTextBox()
        Me.mskFechaHasta = New System.Windows.Forms.MaskedTextBox()
        Me.cbHoraHasta = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tvSelImpresion = New System.Windows.Forms.TreeView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtSegundoApellido = New HistoriaClinica.TextBoxConFormato()
        Me.txtPrimerApellido = New HistoriaClinica.TextBoxConFormato()
        Me.txtSegundoNombre = New HistoriaClinica.TextBoxConFormato()
        Me.txtPrimerNombre = New HistoriaClinica.TextBoxConFormato()
        Me.txtNumDoc = New HistoriaClinica.TextBoxConFormato()
        Me.tbCodigoTipDoc = New HistoriaClinica.TextBoxConFormato()
        Me.tbDescTipDoc = New HistoriaClinica.TextBoxConFormato()
        Me.Sucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cod_historia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tip_admision = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ano_adm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.num_adm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fec_hc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Especialidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.medico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dtgAdmisiones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
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
        Me.btnSalir.Location = New System.Drawing.Point(759, 663)
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
        Me.btnCancelar.Location = New System.Drawing.Point(649, 663)
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
        Me.btnImprimir.Location = New System.Drawing.Point(539, 663)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(104, 22)
        Me.btnImprimir.TabIndex = 25
        Me.btnImprimir.Text = " "
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'dtgAdmisiones
        '
        Me.dtgAdmisiones.AllowUserToAddRows = False
        Me.dtgAdmisiones.AllowUserToDeleteRows = False
        Me.dtgAdmisiones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgAdmisiones.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgAdmisiones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgAdmisiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgAdmisiones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Sucursal, Me.cod_historia, Me.tip_admision, Me.ano_adm, Me.num_adm, Me.fec_hc, Me.Especialidad, Me.medico})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(210, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgAdmisiones.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtgAdmisiones.GridColor = System.Drawing.Color.Gray
        Me.dtgAdmisiones.Location = New System.Drawing.Point(8, 264)
        Me.dtgAdmisiones.Name = "dtgAdmisiones"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(210, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgAdmisiones.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(210, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        Me.dtgAdmisiones.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dtgAdmisiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgAdmisiones.Size = New System.Drawing.Size(850, 109)
        Me.dtgAdmisiones.TabIndex = 4
        '
        'btnTraer
        '
        Me.btnTraer.BackColor = System.Drawing.Color.Transparent
        Me.btnTraer.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_traer_historia
        Me.btnTraer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnTraer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTraer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTraer.ForeColor = System.Drawing.Color.Transparent
        Me.btnTraer.Location = New System.Drawing.Point(751, 236)
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
        Me.GroupBox2.Location = New System.Drawing.Point(8, 106)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(850, 124)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos del Paciente"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(611, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Segundo Apellido"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(411, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Primer Apellido"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(210, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Segundo Nombre"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 73)
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
        Me.btnBuscar.Location = New System.Drawing.Point(555, 37)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(104, 22)
        Me.btnBuscar.TabIndex = 3
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(301, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Número Documento"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 20)
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
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.CBHoraDesde)
        Me.Panel1.Controls.Add(Me.mskFechaDesde)
        Me.Panel1.Controls.Add(Me.mskFechaHasta)
        Me.Panel1.Controls.Add(Me.cbHoraHasta)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.btnSalir)
        Me.Panel1.Controls.Add(Me.btnImprimir)
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Controls.Add(Me.btnTraer)
        Me.Panel1.Controls.Add(Me.dtgAdmisiones)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(868, 694)
        Me.Panel1.TabIndex = 0
        Me.Panel1.TabStop = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rbImpEnf)
        Me.GroupBox4.Controls.Add(Me.rbImpMed)
        Me.GroupBox4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox4.Location = New System.Drawing.Point(8, 45)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(848, 55)
        Me.GroupBox4.TabIndex = 35
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Tipo Reporte"
        '
        'rbImpEnf
        '
        Me.rbImpEnf.AutoSize = True
        Me.rbImpEnf.Checked = True
        Me.rbImpEnf.Location = New System.Drawing.Point(417, 21)
        Me.rbImpEnf.Name = "rbImpEnf"
        Me.rbImpEnf.Size = New System.Drawing.Size(276, 18)
        Me.rbImpEnf.TabIndex = 1
        Me.rbImpEnf.TabStop = True
        Me.rbImpEnf.Text = "Reporte Historia Clinica para Enfermeria"
        Me.rbImpEnf.UseVisualStyleBackColor = True
        '
        'rbImpMed
        '
        Me.rbImpMed.AutoSize = True
        Me.rbImpMed.Location = New System.Drawing.Point(131, 21)
        Me.rbImpMed.Name = "rbImpMed"
        Me.rbImpMed.Size = New System.Drawing.Size(258, 18)
        Me.rbImpMed.TabIndex = 0
        Me.rbImpMed.TabStop = True
        Me.rbImpMed.Text = "Reporte Historia Clinica para Medicos"
        Me.rbImpMed.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(453, 619)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 13)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "dd/mm/aaaa"
        '
        'CBHoraDesde
        '
        Me.CBHoraDesde.FormattingEnabled = True
        Me.CBHoraDesde.Location = New System.Drawing.Point(96, 643)
        Me.CBHoraDesde.Name = "CBHoraDesde"
        Me.CBHoraDesde.Size = New System.Drawing.Size(90, 21)
        Me.CBHoraDesde.TabIndex = 33
        '
        'mskFechaDesde
        '
        Me.mskFechaDesde.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskFechaDesde.Location = New System.Drawing.Point(96, 616)
        Me.mskFechaDesde.Mask = "00/00/0000"
        Me.mskFechaDesde.Name = "mskFechaDesde"
        Me.mskFechaDesde.Size = New System.Drawing.Size(90, 21)
        Me.mskFechaDesde.TabIndex = 8
        Me.mskFechaDesde.ValidatingType = GetType(Date)
        '
        'mskFechaHasta
        '
        Me.mskFechaHasta.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskFechaHasta.Location = New System.Drawing.Point(357, 616)
        Me.mskFechaHasta.Mask = "00/00/0000"
        Me.mskFechaHasta.Name = "mskFechaHasta"
        Me.mskFechaHasta.Size = New System.Drawing.Size(90, 21)
        Me.mskFechaHasta.TabIndex = 9
        Me.mskFechaHasta.ValidatingType = GetType(Date)
        '
        'cbHoraHasta
        '
        Me.cbHoraHasta.FormattingEnabled = True
        Me.cbHoraHasta.Location = New System.Drawing.Point(356, 643)
        Me.cbHoraHasta.Name = "cbHoraHasta"
        Me.cbHoraHasta.Size = New System.Drawing.Size(91, 21)
        Me.cbHoraHasta.TabIndex = 32
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(10, 619)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Fecha Desde"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(453, 646)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 13)
        Me.Label11.TabIndex = 31
        Me.Label11.Text = "Horas"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(311, 619)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Hasta"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(10, 646)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(74, 13)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "Hora Desde"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(192, 619)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 13)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "dd/mm/aaaa"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(311, 646)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(39, 13)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "Hasta"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(192, 646)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(40, 13)
        Me.Label14.TabIndex = 29
        Me.Label14.Text = "Horas"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tvSelImpresion)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(8, 379)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(851, 231)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Desea imprimir"
        '
        'tvSelImpresion
        '
        Me.tvSelImpresion.CheckBoxes = True
        Me.tvSelImpresion.Location = New System.Drawing.Point(13, 21)
        Me.tvSelImpresion.Name = "tvSelImpresion"
        TreeNode1.Name = "srptEnfPlaneacionMedPyxis"
        TreeNode1.Text = "Planeación de Medicamentos"
        TreeNode2.Name = "srptEnfPlaneacionGeneral"
        TreeNode2.Text = "Planeación de Ordenes Generales"
        TreeNode3.Name = "srepEnfPlaneacionCuidado"
        TreeNode3.Text = "Planeación de Cuidados de Enfermeria"
        TreeNode4.Name = "n1Planeacion"
        TreeNode4.Text = "Planeacion"
        TreeNode5.Name = "srptEnfNotasHistorico"
        TreeNode5.Text = "Evolución Enfermeria"
        TreeNode6.Name = "srptEnfControlCateterVascular"
        TreeNode6.Text = "Control Cateter - Inserción"
        TreeNode7.Name = "srptEnfHistoria"
        TreeNode7.Text = "Historia"
        TreeNode8.Name = "srptEnfRecienNacido"
        TreeNode8.Text = "Recien Nacido"
        TreeNode9.Name = "n2NotasdeEnfermeria"
        TreeNode9.Text = "Notas de Enfermeria"
        TreeNode10.Name = "RepEnfEscalas-6"
        TreeNode10.Text = "Riesgo Caida"
        TreeNode11.Name = "srptHCEscalasRass"
        TreeNode11.Text = "RASS"
        TreeNode12.Name = "srptHCEscalasCamIcu"
        TreeNode12.Text = "Cam - IW"
        TreeNode13.Name = "RepEnfEscalas-1"
        TreeNode13.Text = "Riesgo Caida Pediatria"
        TreeNode14.Name = "RepEnfEscalas-2"
        TreeNode14.Text = "Sarnat"
        TreeNode15.Name = "RepEnfEscalas-4"
        TreeNode15.Text = "Tiss 28"
        TreeNode16.Name = "RepEnfEscalas-5"
        TreeNode16.Text = "Valoración Dolor Neonatos"
        TreeNode17.Name = "RepEnfEscalas-3"
        TreeNode17.Text = "Lesión de piel"
        TreeNode18.Name = "n3Escalas"
        TreeNode18.Text = "Escalas"
        TreeNode19.Name = "srptEnfSignosVitales"
        TreeNode19.Text = "Signos Vitales"
        TreeNode20.Name = "srptEnfHojaNeurologica"
        TreeNode20.Text = "Hoja Neurologica"
        TreeNode21.Name = "srptEnfSeguimientoDolor"
        TreeNode21.Text = "Seguimiento Dolor"
        TreeNode22.Name = "srptEnfHojaToxemica"
        TreeNode22.Text = "Hoja Toxemica"
        TreeNode23.Name = "srptEnfHojaHemodinamica"
        TreeNode23.Text = "Hemodinamico"
        TreeNode24.Name = "srptEnfHemodialisis"
        TreeNode24.Text = "Hemodialisis"
        TreeNode25.Name = "srptEnfPlasmaferesis"
        TreeNode25.Text = "Plasmaferesis"
        TreeNode26.Name = "srptEnfSubseccionNeo"
        TreeNode26.Text = "NeoNatal"
        TreeNode27.Name = "srptEnfLiquidosAdminDet1"
        TreeNode27.Text = "Liquidos"
        TreeNode28.Name = "n4Monitoreo"
        TreeNode28.Text = "Monitoreo"
        TreeNode29.Name = "Nodo0"
        TreeNode29.Text = "Todos"
        Me.tvSelImpresion.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode29})
        Me.tvSelImpresion.Size = New System.Drawing.Size(819, 193)
        Me.tvSelImpresion.TabIndex = 28
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "tip_admision"
        Me.DataGridViewTextBoxColumn1.FillWeight = 106.599!
        Me.DataGridViewTextBoxColumn1.HeaderText = "Tipo Admisión"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 115
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "ano_adm"
        Me.DataGridViewTextBoxColumn2.FillWeight = 28.62944!
        Me.DataGridViewTextBoxColumn2.HeaderText = "Año"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Visible = False
        Me.DataGridViewTextBoxColumn2.Width = 116
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "num_adm"
        Me.DataGridViewTextBoxColumn3.FillWeight = 28.62944!
        Me.DataGridViewTextBoxColumn3.HeaderText = "Número"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 115
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "fec_hc"
        Me.DataGridViewTextBoxColumn4.FillWeight = 28.62944!
        Me.DataGridViewTextBoxColumn4.HeaderText = "Fecha Historia"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 115
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Especialidad"
        Me.DataGridViewTextBoxColumn5.FillWeight = 456.8528!
        Me.DataGridViewTextBoxColumn5.HeaderText = "Especialidad"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 115
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "medico"
        Me.DataGridViewTextBoxColumn6.FillWeight = 28.62944!
        Me.DataGridViewTextBoxColumn6.HeaderText = "Médico"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 116
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "estado_salida"
        Me.DataGridViewTextBoxColumn7.FillWeight = 28.62944!
        Me.DataGridViewTextBoxColumn7.HeaderText = "Estado"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 115
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "estado_salida"
        Me.DataGridViewTextBoxColumn8.FillWeight = 92.33466!
        Me.DataGridViewTextBoxColumn8.HeaderText = "Estado"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 115
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
        Me.txtSegundoApellido.Location = New System.Drawing.Point(615, 88)
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
        Me.txtPrimerApellido.Location = New System.Drawing.Point(414, 88)
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
        Me.txtSegundoNombre.Location = New System.Drawing.Point(213, 88)
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
        Me.txtPrimerNombre.Location = New System.Drawing.Point(13, 88)
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
        Me.txtNumDoc.Location = New System.Drawing.Point(304, 37)
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
        Me.tbCodigoTipDoc.Location = New System.Drawing.Point(13, 38)
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
        Me.tbDescTipDoc.Location = New System.Drawing.Point(55, 38)
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
        'Sucursal
        '
        Me.Sucursal.DataPropertyName = "Sucursal"
        Me.Sucursal.FillWeight = 124.3655!
        Me.Sucursal.HeaderText = "Descripción Sucursal"
        Me.Sucursal.Name = "Sucursal"
        '
        'cod_historia
        '
        Me.cod_historia.DataPropertyName = "cod_historia"
        Me.cod_historia.HeaderText = "CodHistoria"
        Me.cod_historia.Name = "cod_historia"
        Me.cod_historia.Visible = False
        '
        'tip_admision
        '
        Me.tip_admision.DataPropertyName = "tip_admision"
        Me.tip_admision.FillWeight = 58.44003!
        Me.tip_admision.HeaderText = "Tipo Admisión"
        Me.tip_admision.Name = "tip_admision"
        '
        'ano_adm
        '
        Me.ano_adm.DataPropertyName = "ano_adm"
        Me.ano_adm.FillWeight = 75.61722!
        Me.ano_adm.HeaderText = "Año"
        Me.ano_adm.Name = "ano_adm"
        '
        'num_adm
        '
        Me.num_adm.DataPropertyName = "num_adm"
        Me.num_adm.FillWeight = 96.38596!
        Me.num_adm.HeaderText = "Número"
        Me.num_adm.Name = "num_adm"
        '
        'fec_hc
        '
        Me.fec_hc.DataPropertyName = "fec_hc"
        Me.fec_hc.FillWeight = 181.92!
        Me.fec_hc.HeaderText = "Fecha Historia"
        Me.fec_hc.Name = "fec_hc"
        '
        'Especialidad
        '
        Me.Especialidad.DataPropertyName = "especialidad"
        Me.Especialidad.FillWeight = 73.70116!
        Me.Especialidad.HeaderText = "Especialidad"
        Me.Especialidad.Name = "Especialidad"
        '
        'medico
        '
        Me.medico.DataPropertyName = "medico"
        Me.medico.FillWeight = 89.57014!
        Me.medico.HeaderText = "Médico"
        Me.medico.Name = "medico"
        '
        'frmConsultaHCEnfermeriaAlejo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(869, 699)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frmConsultaHCEnfermeriaAlejo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta Historia Clinica"
        CType(Me.dtgAdmisiones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

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
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents mskFechaDesde As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mskFechaHasta As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents CBHoraDesde As System.Windows.Forms.ComboBox
    Friend WithEvents cbHoraHasta As System.Windows.Forms.ComboBox
    Friend WithEvents tvSelImpresion As System.Windows.Forms.TreeView
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rbImpEnf As System.Windows.Forms.RadioButton
    Friend WithEvents rbImpMed As System.Windows.Forms.RadioButton
    Friend WithEvents Sucursal As DataGridViewTextBoxColumn
    Friend WithEvents cod_historia As DataGridViewTextBoxColumn
    Friend WithEvents tip_admision As DataGridViewTextBoxColumn
    Friend WithEvents ano_adm As DataGridViewTextBoxColumn
    Friend WithEvents num_adm As DataGridViewTextBoxColumn
    Friend WithEvents fec_hc As DataGridViewTextBoxColumn
    Friend WithEvents Especialidad As DataGridViewTextBoxColumn
    Friend WithEvents medico As DataGridViewTextBoxColumn
End Class
