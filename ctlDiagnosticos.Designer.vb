<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlDiagnosticos
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctlDiagnosticos))
        Me.gbDiagnostico = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LbObltenarsis = New System.Windows.Forms.Label()
        Me.tbObservaciones = New System.Windows.Forms.TextBox()
        Me.lblObservaciones = New System.Windows.Forms.Label()
        Me.cbAgregarEvo = New System.Windows.Forms.CheckBox()
        Me.lblEstadoDiag = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ckConfidencialEvo = New System.Windows.Forms.CheckBox()
        Me.dtgDiagnosticos = New System.Windows.Forms.DataGridView()
        Me.btnAgregarDiag = New System.Windows.Forms.Button()
        Me.lblDiagnostico = New System.Windows.Forms.Label()
        Me.lblCategoria = New System.Windows.Forms.Label()
        Me.lblTipoDiagnostico = New System.Windows.Forms.Label()
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
        Me.txtEstadoDiag = New HistoriaClinica.TextBoxConFormato()
        Me.txtCodEstadoDiag = New HistoriaClinica.TextBoxConFormato()
        Me.cbDiagnostico = New HistoriaClinica.ComboBusqueda(Me.components)
        Me.DIAGNOSTICO_desc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIPO_DIAGNOSTICO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CATEGORIA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ESTADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COD_PRE_SGS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COD_SUCUR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIP_ADMISION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ANO_ADM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUM_ADM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DIAGNOST = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIP_DIAG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LOGIN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIP_DOC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUM_DOC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CATEGORIA_DIAG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDESTADODIAGNOSTICO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLASIFICACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OBS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ANTECEDENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CONFIDENCIAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SECUENCIA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLASE_DIAG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FEC_CON = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ORIGEN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbCodDiag = New HistoriaClinica.TextBoxConFormato()
        Me.tbDesCategoria = New HistoriaClinica.TextBoxConFormato()
        Me.tbCodCategoria = New HistoriaClinica.TextBoxConFormato()
        Me.tbDesTipoDiag = New HistoriaClinica.TextBoxConFormato()
        Me.tbCodTipoDiag = New HistoriaClinica.TextBoxConFormato()
        Me.gbDiagnostico.SuspendLayout()
        CType(Me.dtgDiagnosticos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbDiagnostico
        '
        Me.gbDiagnostico.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.gbDiagnostico.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gbDiagnostico.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.gbDiagnostico.Controls.Add(Me.Label3)
        Me.gbDiagnostico.Controls.Add(Me.Label2)
        Me.gbDiagnostico.Controls.Add(Me.Label1)
        Me.gbDiagnostico.Controls.Add(Me.LbObltenarsis)
        Me.gbDiagnostico.Controls.Add(Me.tbObservaciones)
        Me.gbDiagnostico.Controls.Add(Me.lblObservaciones)
        Me.gbDiagnostico.Controls.Add(Me.cbAgregarEvo)
        Me.gbDiagnostico.Controls.Add(Me.txtEstadoDiag)
        Me.gbDiagnostico.Controls.Add(Me.txtCodEstadoDiag)
        Me.gbDiagnostico.Controls.Add(Me.lblEstadoDiag)
        Me.gbDiagnostico.Controls.Add(Me.TextBox1)
        Me.gbDiagnostico.Controls.Add(Me.ckConfidencialEvo)
        Me.gbDiagnostico.Controls.Add(Me.cbDiagnostico)
        Me.gbDiagnostico.Controls.Add(Me.dtgDiagnosticos)
        Me.gbDiagnostico.Controls.Add(Me.tbCodDiag)
        Me.gbDiagnostico.Controls.Add(Me.tbDesCategoria)
        Me.gbDiagnostico.Controls.Add(Me.tbCodCategoria)
        Me.gbDiagnostico.Controls.Add(Me.tbDesTipoDiag)
        Me.gbDiagnostico.Controls.Add(Me.tbCodTipoDiag)
        Me.gbDiagnostico.Controls.Add(Me.btnAgregarDiag)
        Me.gbDiagnostico.Controls.Add(Me.lblDiagnostico)
        Me.gbDiagnostico.Controls.Add(Me.lblCategoria)
        Me.gbDiagnostico.Controls.Add(Me.lblTipoDiagnostico)
        Me.gbDiagnostico.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDiagnostico.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.gbDiagnostico.Location = New System.Drawing.Point(5, 0)
        Me.gbDiagnostico.Name = "gbDiagnostico"
        Me.gbDiagnostico.Size = New System.Drawing.Size(1049, 237)
        Me.gbDiagnostico.TabIndex = 59
        Me.gbDiagnostico.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Salmon
        Me.Label3.Location = New System.Drawing.Point(760, 156)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(13, 15)
        Me.Label3.TabIndex = 68
        Me.Label3.Text = "*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Salmon
        Me.Label2.Location = New System.Drawing.Point(493, 156)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(13, 15)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "*"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Salmon
        Me.Label1.Location = New System.Drawing.Point(122, 156)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(13, 15)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "*"
        '
        'LbObltenarsis
        '
        Me.LbObltenarsis.AutoSize = True
        Me.LbObltenarsis.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbObltenarsis.ForeColor = System.Drawing.Color.Salmon
        Me.LbObltenarsis.Location = New System.Drawing.Point(122, 132)
        Me.LbObltenarsis.Name = "LbObltenarsis"
        Me.LbObltenarsis.Size = New System.Drawing.Size(13, 15)
        Me.LbObltenarsis.TabIndex = 65
        Me.LbObltenarsis.Text = "*"
        '
        'tbObservaciones
        '
        Me.tbObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbObservaciones.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbObservaciones.Location = New System.Drawing.Point(137, 179)
        Me.tbObservaciones.MaxLength = 150
        Me.tbObservaciones.Multiline = True
        Me.tbObservaciones.Name = "tbObservaciones"
        Me.tbObservaciones.Size = New System.Drawing.Size(802, 53)
        Me.tbObservaciones.TabIndex = 12
        '
        'lblObservaciones
        '
        Me.lblObservaciones.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblObservaciones.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblObservaciones.Location = New System.Drawing.Point(2, 192)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(119, 23)
        Me.lblObservaciones.TabIndex = 0
        Me.lblObservaciones.Text = "Observaciones"
        Me.lblObservaciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbAgregarEvo
        '
        Me.cbAgregarEvo.AutoSize = True
        Me.cbAgregarEvo.Location = New System.Drawing.Point(5, 194)
        Me.cbAgregarEvo.Name = "cbAgregarEvo"
        Me.cbAgregarEvo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cbAgregarEvo.Size = New System.Drawing.Size(273, 18)
        Me.cbAgregarEvo.TabIndex = 8
        Me.cbAgregarEvo.Text = "Agregar diagnóstico como antecedente"
        Me.cbAgregarEvo.UseVisualStyleBackColor = True
        Me.cbAgregarEvo.Visible = False
        '
        'lblEstadoDiag
        '
        Me.lblEstadoDiag.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstadoDiag.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblEstadoDiag.Location = New System.Drawing.Point(704, 154)
        Me.lblEstadoDiag.Name = "lblEstadoDiag"
        Me.lblEstadoDiag.Size = New System.Drawing.Size(74, 22)
        Me.lblEstadoDiag.TabIndex = 60
        Me.lblEstadoDiag.Text = "Estado"
        Me.lblEstadoDiag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Location = New System.Drawing.Point(464, 190)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(43, 15)
        Me.TextBox1.TabIndex = 11
        Me.TextBox1.Visible = False
        '
        'ckConfidencialEvo
        '
        Me.ckConfidencialEvo.AutoSize = True
        Me.ckConfidencialEvo.Location = New System.Drawing.Point(335, 192)
        Me.ckConfidencialEvo.Name = "ckConfidencialEvo"
        Me.ckConfidencialEvo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ckConfidencialEvo.Size = New System.Drawing.Size(102, 18)
        Me.ckConfidencialEvo.TabIndex = 9
        Me.ckConfidencialEvo.Text = "Confidencial"
        Me.ckConfidencialEvo.UseVisualStyleBackColor = True
        Me.ckConfidencialEvo.Visible = False
        '
        'dtgDiagnosticos
        '
        Me.dtgDiagnosticos.AllowUserToAddRows = False
        Me.dtgDiagnosticos.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(210, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dtgDiagnosticos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgDiagnosticos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgDiagnosticos.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgDiagnosticos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtgDiagnosticos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgDiagnosticos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DIAGNOSTICO_desc, Me.TIPO_DIAGNOSTICO, Me.CATEGORIA, Me.ESTADO, Me.COD_PRE_SGS, Me.COD_SUCUR, Me.TIP_ADMISION, Me.ANO_ADM, Me.NUM_ADM, Me.DIAGNOST, Me.TIP_DIAG, Me.LOGIN, Me.TIP_DOC, Me.NUM_DOC, Me.CATEGORIA_DIAG, Me.IDESTADODIAGNOSTICO, Me.CLASIFICACION, Me.OBS, Me.ANTECEDENTE, Me.CONFIDENCIAL, Me.SECUENCIA, Me.CLASE_DIAG, Me.FEC_CON, Me.ORIGEN})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(210, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgDiagnosticos.DefaultCellStyle = DataGridViewCellStyle3
        Me.dtgDiagnosticos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dtgDiagnosticos.GridColor = System.Drawing.Color.Gray
        Me.dtgDiagnosticos.Location = New System.Drawing.Point(0, 3)
        Me.dtgDiagnosticos.Name = "dtgDiagnosticos"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(210, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgDiagnosticos.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dtgDiagnosticos.RowHeadersWidth = 30
        Me.dtgDiagnosticos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dtgDiagnosticos.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dtgDiagnosticos.RowTemplate.Height = 20
        Me.dtgDiagnosticos.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgDiagnosticos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgDiagnosticos.Size = New System.Drawing.Size(1049, 124)
        Me.dtgDiagnosticos.TabIndex = 1
        '
        'btnAgregarDiag
        '
        Me.btnAgregarDiag.BackColor = System.Drawing.Color.Transparent
        Me.btnAgregarDiag.BackgroundImage = CType(resources.GetObject("btnAgregarDiag.BackgroundImage"), System.Drawing.Image)
        Me.btnAgregarDiag.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAgregarDiag.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregarDiag.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregarDiag.ForeColor = System.Drawing.Color.Transparent
        Me.btnAgregarDiag.Location = New System.Drawing.Point(953, 190)
        Me.btnAgregarDiag.Name = "btnAgregarDiag"
        Me.btnAgregarDiag.Size = New System.Drawing.Size(80, 24)
        Me.btnAgregarDiag.TabIndex = 15
        Me.btnAgregarDiag.UseVisualStyleBackColor = False
        '
        'lblDiagnostico
        '
        Me.lblDiagnostico.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiagnostico.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblDiagnostico.Location = New System.Drawing.Point(2, 132)
        Me.lblDiagnostico.Name = "lblDiagnostico"
        Me.lblDiagnostico.Size = New System.Drawing.Size(107, 23)
        Me.lblDiagnostico.TabIndex = 0
        Me.lblDiagnostico.Text = "Diagnóstico"
        Me.lblDiagnostico.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCategoria
        '
        Me.lblCategoria.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategoria.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblCategoria.Location = New System.Drawing.Point(419, 154)
        Me.lblCategoria.Name = "lblCategoria"
        Me.lblCategoria.Size = New System.Drawing.Size(74, 22)
        Me.lblCategoria.TabIndex = 0
        Me.lblCategoria.Text = "Categoría"
        Me.lblCategoria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTipoDiagnostico
        '
        Me.lblTipoDiagnostico.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoDiagnostico.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblTipoDiagnostico.Location = New System.Drawing.Point(3, 154)
        Me.lblTipoDiagnostico.Name = "lblTipoDiagnostico"
        Me.lblTipoDiagnostico.Size = New System.Drawing.Size(122, 22)
        Me.lblTipoDiagnostico.TabIndex = 0
        Me.lblTipoDiagnostico.Text = "Tipo diagnóstico"
        Me.lblTipoDiagnostico.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "COD_PRE_SGS"
        Me.DataGridViewTextBoxColumn1.FillWeight = 150.0!
        Me.DataGridViewTextBoxColumn1.HeaderText = "COD_PRE_SGS"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 400
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "ORIGEN"
        Me.DataGridViewTextBoxColumn2.HeaderText = "ORIGEN"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn2.Visible = False
        Me.DataGridViewTextBoxColumn2.Width = 240
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "COD_SUCUR"
        Me.DataGridViewTextBoxColumn3.HeaderText = "COD_SUCUR"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn3.Visible = False
        Me.DataGridViewTextBoxColumn3.Width = 200
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "tip_admision_evo"
        Me.DataGridViewTextBoxColumn4.HeaderText = ""
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn4.Visible = False
        Me.DataGridViewTextBoxColumn4.Width = 150
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "ano_adm_evo"
        Me.DataGridViewTextBoxColumn5.HeaderText = ""
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "num_adm_evo"
        Me.DataGridViewTextBoxColumn6.HeaderText = ""
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Visible = False
        Me.DataGridViewTextBoxColumn6.Width = 19
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "tip_diag_evo"
        Me.DataGridViewTextBoxColumn7.FillWeight = 150.0!
        Me.DataGridViewTextBoxColumn7.HeaderText = ""
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Visible = False
        Me.DataGridViewTextBoxColumn7.Width = 19
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "descripcion_evo"
        Me.DataGridViewTextBoxColumn8.FillWeight = 150.0!
        Me.DataGridViewTextBoxColumn8.HeaderText = "DIAGNÓSTICO"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Visible = False
        Me.DataGridViewTextBoxColumn8.Width = 400
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "tDescripcion_evo"
        Me.DataGridViewTextBoxColumn9.FillWeight = 150.0!
        Me.DataGridViewTextBoxColumn9.HeaderText = "TIPO DIAGNÓSTICO"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Visible = False
        Me.DataGridViewTextBoxColumn9.Width = 240
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "CategoriaDes_evo"
        Me.DataGridViewTextBoxColumn10.FillWeight = 150.0!
        Me.DataGridViewTextBoxColumn10.HeaderText = "CATEGORÍA"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Visible = False
        Me.DataGridViewTextBoxColumn10.Width = 200
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "ESTADO"
        Me.DataGridViewTextBoxColumn11.HeaderText = "ESTADO"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Visible = False
        Me.DataGridViewTextBoxColumn11.Width = 150
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "IDESTADO"
        Me.DataGridViewTextBoxColumn12.HeaderText = "IDESTADO"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Visible = False
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "diagnost_evo"
        Me.DataGridViewTextBoxColumn13.FillWeight = 150.0!
        Me.DataGridViewTextBoxColumn13.HeaderText = "CÓDIGO"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Visible = False
        Me.DataGridViewTextBoxColumn13.Width = 130
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "clasificacion_evo"
        Me.DataGridViewTextBoxColumn14.FillWeight = 150.0!
        Me.DataGridViewTextBoxColumn14.HeaderText = ""
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.Visible = False
        Me.DataGridViewTextBoxColumn14.Width = 200
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "obs_evo"
        Me.DataGridViewTextBoxColumn15.FillWeight = 150.0!
        Me.DataGridViewTextBoxColumn15.HeaderText = ""
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        Me.DataGridViewTextBoxColumn15.Visible = False
        Me.DataGridViewTextBoxColumn15.Width = 19
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "Antecedente_Evo"
        Me.DataGridViewTextBoxColumn16.HeaderText = ""
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        Me.DataGridViewTextBoxColumn16.Visible = False
        Me.DataGridViewTextBoxColumn16.Width = 19
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "confidencial_Evo"
        Me.DataGridViewTextBoxColumn17.HeaderText = ""
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        Me.DataGridViewTextBoxColumn17.Visible = False
        Me.DataGridViewTextBoxColumn17.Width = 19
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "planManejo_Evo"
        Me.DataGridViewTextBoxColumn18.HeaderText = ""
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        Me.DataGridViewTextBoxColumn18.Visible = False
        Me.DataGridViewTextBoxColumn18.Width = 19
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "secuencia_evo"
        Me.DataGridViewTextBoxColumn19.HeaderText = ""
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.ReadOnly = True
        Me.DataGridViewTextBoxColumn19.Visible = False
        Me.DataGridViewTextBoxColumn19.Width = 19
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "clase_diag_evo"
        Me.DataGridViewTextBoxColumn20.HeaderText = ""
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.ReadOnly = True
        Me.DataGridViewTextBoxColumn20.Visible = False
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.DataPropertyName = "categoria_diag_evo"
        Me.DataGridViewTextBoxColumn21.FillWeight = 150.0!
        Me.DataGridViewTextBoxColumn21.HeaderText = ""
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.ReadOnly = True
        Me.DataGridViewTextBoxColumn21.Visible = False
        Me.DataGridViewTextBoxColumn21.Width = 120
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.DataPropertyName = "fec_hc_evo"
        Me.DataGridViewTextBoxColumn22.HeaderText = ""
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.ReadOnly = True
        Me.DataGridViewTextBoxColumn22.Visible = False
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.DataPropertyName = "Nuevo_evo"
        Me.DataGridViewTextBoxColumn23.HeaderText = ""
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        Me.DataGridViewTextBoxColumn23.ReadOnly = True
        Me.DataGridViewTextBoxColumn23.Visible = False
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.DataPropertyName = "ORIGEN"
        Me.DataGridViewTextBoxColumn24.HeaderText = "ORIGEN"
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        Me.DataGridViewTextBoxColumn24.ReadOnly = True
        Me.DataGridViewTextBoxColumn24.Visible = False
        '
        'txtEstadoDiag
        '
        Me.txtEstadoDiag.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtEstadoDiag.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtEstadoDiag.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEstadoDiag.ControlComboEnlace = Nothing
        Me.txtEstadoDiag.ControlTextoEnlace = Nothing
        Me.txtEstadoDiag.DatoRelacionado = Nothing
        Me.txtEstadoDiag.Decimals = CType(2, Byte)
        Me.txtEstadoDiag.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtEstadoDiag.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstadoDiag.Format = HistoriaClinica.tbFormats.AlfabéticoConEspacios
        Me.txtEstadoDiag.Location = New System.Drawing.Point(779, 154)
        Me.txtEstadoDiag.MaxLength = 20
        Me.txtEstadoDiag.Name = "txtEstadoDiag"
        Me.txtEstadoDiag.NombreCampoBuscado = Nothing
        Me.txtEstadoDiag.NombreCampoBusqueda = Nothing
        Me.txtEstadoDiag.NombreCampoDatos = Nothing
        Me.txtEstadoDiag.Obligatorio = False
        Me.txtEstadoDiag.OrigenDeDatos = Nothing
        Me.txtEstadoDiag.PermitirValorCero = False
        Me.txtEstadoDiag.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtEstadoDiag.Size = New System.Drawing.Size(160, 22)
        Me.txtEstadoDiag.TabIndex = 11
        Me.txtEstadoDiag.TipoControl = HistoriaClinica.tbTipoControl.ListaAutoComplete
        Me.txtEstadoDiag.UserValues = Nothing
        Me.txtEstadoDiag.ValorMaximo = CType(0, Long)
        Me.txtEstadoDiag.ValorMinimo = CType(0, Long)
        '
        'txtCodEstadoDiag
        '
        Me.txtCodEstadoDiag.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodEstadoDiag.ControlComboEnlace = Nothing
        Me.txtCodEstadoDiag.ControlTextoEnlace = Nothing
        Me.txtCodEstadoDiag.DatoRelacionado = Nothing
        Me.txtCodEstadoDiag.Decimals = CType(0, Byte)
        Me.txtCodEstadoDiag.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtCodEstadoDiag.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodEstadoDiag.Format = HistoriaClinica.tbFormats.NúmericoEnteroSinSigno
        Me.txtCodEstadoDiag.Location = New System.Drawing.Point(779, 154)
        Me.txtCodEstadoDiag.MaxLength = 1
        Me.txtCodEstadoDiag.Name = "txtCodEstadoDiag"
        Me.txtCodEstadoDiag.NombreCampoBuscado = Nothing
        Me.txtCodEstadoDiag.NombreCampoBusqueda = Nothing
        Me.txtCodEstadoDiag.NombreCampoDatos = Nothing
        Me.txtCodEstadoDiag.Obligatorio = True
        Me.txtCodEstadoDiag.OrigenDeDatos = Nothing
        Me.txtCodEstadoDiag.PermitirValorCero = False
        Me.txtCodEstadoDiag.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtCodEstadoDiag.Size = New System.Drawing.Size(33, 22)
        Me.txtCodEstadoDiag.TabIndex = 61
        Me.txtCodEstadoDiag.TipoControl = HistoriaClinica.tbTipoControl.CodigoBusqueda
        Me.txtCodEstadoDiag.UserValues = Nothing
        Me.txtCodEstadoDiag.ValorMaximo = CType(3, Long)
        Me.txtCodEstadoDiag.ValorMinimo = CType(1, Long)
        Me.txtCodEstadoDiag.Visible = False
        '
        'cbDiagnostico
        '
        Me.cbDiagnostico.CampoEnlazado = Nothing
        Me.cbDiagnostico.CampoMostrar = Nothing
        Me.cbDiagnostico.CategoriaDatos = HistoriaClinica.CategoriaDatos.Diagnosticos
        Me.cbDiagnostico.CodigoTipoProcedimiento = Nothing
        Me.cbDiagnostico.ControlTextoEnlace = Nothing
        Me.cbDiagnostico.ControlTieneCache = True
        Me.cbDiagnostico.ConvenioMedicamento = False
        Me.cbDiagnostico.DatoRelacionado = Nothing
        Me.cbDiagnostico.EdadPaciente = 0
        Me.cbDiagnostico.Entidad = Nothing
        Me.cbDiagnostico.EstadoMedicamento = False
        Me.cbDiagnostico.FechaInicialMedicamento = Nothing
        Me.cbDiagnostico.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDiagnostico.FormattingEnabled = True
        Me.cbDiagnostico.Location = New System.Drawing.Point(231, 130)
        Me.cbDiagnostico.Login = Nothing
        Me.cbDiagnostico.MaxLength = 200
        Me.cbDiagnostico.Medicamento = Nothing
        Me.cbDiagnostico.Name = "cbDiagnostico"
        Me.cbDiagnostico.Obligatorio = "False"
        Me.cbDiagnostico.Prestador = Nothing
        Me.cbDiagnostico.SeleccionadoConEnter = False
        Me.cbDiagnostico.SexoPaciente = Nothing
        Me.cbDiagnostico.Size = New System.Drawing.Size(552, 22)
        Me.cbDiagnostico.Sucursal = Nothing
        Me.cbDiagnostico.TabIndex = 6
        Me.cbDiagnostico.UltimaDescripcionDeBusqueda = Nothing
        Me.cbDiagnostico.ValorCampoEnlazado = Nothing
        '
        'DIAGNOSTICO_desc
        '
        Me.DIAGNOSTICO_desc.DataPropertyName = "DIAGNOSTICO"
        Me.DIAGNOSTICO_desc.FillWeight = 150.0!
        Me.DIAGNOSTICO_desc.HeaderText = "DIAGNÓSTICO"
        Me.DIAGNOSTICO_desc.Name = "DIAGNOSTICO_desc"
        Me.DIAGNOSTICO_desc.ReadOnly = True
        '
        'TIPO_DIAGNOSTICO
        '
        Me.TIPO_DIAGNOSTICO.DataPropertyName = "TIPO_DIAGNOSTICO"
        Me.TIPO_DIAGNOSTICO.HeaderText = "TIPO DIAGNÓSTICO"
        Me.TIPO_DIAGNOSTICO.Name = "TIPO_DIAGNOSTICO"
        Me.TIPO_DIAGNOSTICO.ReadOnly = True
        Me.TIPO_DIAGNOSTICO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'CATEGORIA
        '
        Me.CATEGORIA.DataPropertyName = "CATEGORIA"
        Me.CATEGORIA.HeaderText = "CATEGORÍA"
        Me.CATEGORIA.Name = "CATEGORIA"
        Me.CATEGORIA.ReadOnly = True
        Me.CATEGORIA.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'ESTADO
        '
        Me.ESTADO.DataPropertyName = "ESTADO"
        Me.ESTADO.HeaderText = "ESTADO"
        Me.ESTADO.Name = "ESTADO"
        Me.ESTADO.ReadOnly = True
        Me.ESTADO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'COD_PRE_SGS
        '
        Me.COD_PRE_SGS.DataPropertyName = "COD_PRE_SGS"
        Me.COD_PRE_SGS.HeaderText = "COD_PRE_SGS"
        Me.COD_PRE_SGS.Name = "COD_PRE_SGS"
        Me.COD_PRE_SGS.ReadOnly = True
        Me.COD_PRE_SGS.Visible = False
        '
        'COD_SUCUR
        '
        Me.COD_SUCUR.DataPropertyName = "COD_SUCUR"
        Me.COD_SUCUR.HeaderText = "COD_SUCUR"
        Me.COD_SUCUR.Name = "COD_SUCUR"
        Me.COD_SUCUR.ReadOnly = True
        Me.COD_SUCUR.Visible = False
        '
        'TIP_ADMISION
        '
        Me.TIP_ADMISION.DataPropertyName = "TIP_ADMISION"
        Me.TIP_ADMISION.HeaderText = "TIP_ADMISION"
        Me.TIP_ADMISION.Name = "TIP_ADMISION"
        Me.TIP_ADMISION.ReadOnly = True
        Me.TIP_ADMISION.Visible = False
        '
        'ANO_ADM
        '
        Me.ANO_ADM.DataPropertyName = "ANO_ADM"
        Me.ANO_ADM.HeaderText = "ANO_ADM"
        Me.ANO_ADM.Name = "ANO_ADM"
        Me.ANO_ADM.ReadOnly = True
        Me.ANO_ADM.Visible = False
        '
        'NUM_ADM
        '
        Me.NUM_ADM.DataPropertyName = "NUM_ADM"
        Me.NUM_ADM.HeaderText = "NUM_ADM"
        Me.NUM_ADM.Name = "NUM_ADM"
        Me.NUM_ADM.ReadOnly = True
        Me.NUM_ADM.Visible = False
        '
        'DIAGNOST
        '
        Me.DIAGNOST.DataPropertyName = "DIAGNOST"
        Me.DIAGNOST.HeaderText = "DIAGNOST"
        Me.DIAGNOST.Name = "DIAGNOST"
        Me.DIAGNOST.ReadOnly = True
        Me.DIAGNOST.Visible = False
        '
        'TIP_DIAG
        '
        Me.TIP_DIAG.DataPropertyName = "TIP_DIAG"
        Me.TIP_DIAG.HeaderText = "TIP_DIAG"
        Me.TIP_DIAG.Name = "TIP_DIAG"
        Me.TIP_DIAG.ReadOnly = True
        Me.TIP_DIAG.Visible = False
        '
        'LOGIN
        '
        Me.LOGIN.DataPropertyName = "LOGIN"
        Me.LOGIN.HeaderText = "LOGIN"
        Me.LOGIN.Name = "LOGIN"
        Me.LOGIN.ReadOnly = True
        Me.LOGIN.Visible = False
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
        'CATEGORIA_DIAG
        '
        Me.CATEGORIA_DIAG.DataPropertyName = "CATEGORIA_DIAG"
        Me.CATEGORIA_DIAG.FillWeight = 150.0!
        Me.CATEGORIA_DIAG.HeaderText = "CATEGORIA_DIAG"
        Me.CATEGORIA_DIAG.Name = "CATEGORIA_DIAG"
        Me.CATEGORIA_DIAG.ReadOnly = True
        Me.CATEGORIA_DIAG.Visible = False
        '
        'IDESTADODIAGNOSTICO
        '
        Me.IDESTADODIAGNOSTICO.DataPropertyName = "IDESTADODIAGNOSTICO"
        Me.IDESTADODIAGNOSTICO.HeaderText = "IDESTADODIAGNOSTICO"
        Me.IDESTADODIAGNOSTICO.Name = "IDESTADODIAGNOSTICO"
        Me.IDESTADODIAGNOSTICO.ReadOnly = True
        Me.IDESTADODIAGNOSTICO.Visible = False
        '
        'CLASIFICACION
        '
        Me.CLASIFICACION.DataPropertyName = "CLASIFICACION"
        Me.CLASIFICACION.HeaderText = "CLASIFICACION"
        Me.CLASIFICACION.Name = "CLASIFICACION"
        Me.CLASIFICACION.ReadOnly = True
        Me.CLASIFICACION.Visible = False
        '
        'OBS
        '
        Me.OBS.DataPropertyName = "OBS"
        Me.OBS.HeaderText = "OBS"
        Me.OBS.Name = "OBS"
        Me.OBS.ReadOnly = True
        Me.OBS.Visible = False
        '
        'ANTECEDENTE
        '
        Me.ANTECEDENTE.DataPropertyName = "ANTECEDENTE"
        Me.ANTECEDENTE.HeaderText = "ANTECEDENTE"
        Me.ANTECEDENTE.Name = "ANTECEDENTE"
        Me.ANTECEDENTE.ReadOnly = True
        Me.ANTECEDENTE.Visible = False
        '
        'CONFIDENCIAL
        '
        Me.CONFIDENCIAL.DataPropertyName = "CONFIDENCIAL"
        Me.CONFIDENCIAL.HeaderText = "CONFIDENCIAL"
        Me.CONFIDENCIAL.Name = "CONFIDENCIAL"
        Me.CONFIDENCIAL.ReadOnly = True
        Me.CONFIDENCIAL.Visible = False
        '
        'SECUENCIA
        '
        Me.SECUENCIA.DataPropertyName = "SECUENCIA"
        Me.SECUENCIA.HeaderText = "SECUENCIA"
        Me.SECUENCIA.Name = "SECUENCIA"
        Me.SECUENCIA.ReadOnly = True
        Me.SECUENCIA.Visible = False
        '
        'CLASE_DIAG
        '
        Me.CLASE_DIAG.DataPropertyName = "CLASE_DIAG"
        Me.CLASE_DIAG.HeaderText = "CLASE_DIAG"
        Me.CLASE_DIAG.Name = "CLASE_DIAG"
        Me.CLASE_DIAG.ReadOnly = True
        Me.CLASE_DIAG.Visible = False
        '
        'FEC_CON
        '
        Me.FEC_CON.DataPropertyName = "FEC_CON"
        Me.FEC_CON.HeaderText = "FEC_CON"
        Me.FEC_CON.Name = "FEC_CON"
        Me.FEC_CON.ReadOnly = True
        Me.FEC_CON.Visible = False
        '
        'ORIGEN
        '
        Me.ORIGEN.DataPropertyName = "ORIGEN"
        Me.ORIGEN.HeaderText = "ORIGEN"
        Me.ORIGEN.Name = "ORIGEN"
        Me.ORIGEN.ReadOnly = True
        Me.ORIGEN.Visible = False
        '
        'tbCodDiag
        '
        Me.tbCodDiag.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbCodDiag.ControlComboEnlace = Nothing
        Me.tbCodDiag.ControlTextoEnlace = Nothing
        Me.tbCodDiag.DatoRelacionado = Nothing
        Me.tbCodDiag.Decimals = CType(0, Byte)
        Me.tbCodDiag.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.tbCodDiag.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCodDiag.Format = HistoriaClinica.tbFormats.AlfaNúmericoSinEspacios
        Me.tbCodDiag.Location = New System.Drawing.Point(137, 130)
        Me.tbCodDiag.MaxLength = 6
        Me.tbCodDiag.Name = "tbCodDiag"
        Me.tbCodDiag.NombreCampoBuscado = Nothing
        Me.tbCodDiag.NombreCampoBusqueda = Nothing
        Me.tbCodDiag.NombreCampoDatos = Nothing
        Me.tbCodDiag.Obligatorio = True
        Me.tbCodDiag.OrigenDeDatos = Nothing
        Me.tbCodDiag.PermitirValorCero = False
        Me.tbCodDiag.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.tbCodDiag.Size = New System.Drawing.Size(85, 22)
        Me.tbCodDiag.TabIndex = 5
        Me.tbCodDiag.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.tbCodDiag.UserValues = Nothing
        Me.tbCodDiag.ValorMaximo = CType(0, Long)
        Me.tbCodDiag.ValorMinimo = CType(0, Long)
        '
        'tbDesCategoria
        '
        Me.tbDesCategoria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.tbDesCategoria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.tbDesCategoria.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbDesCategoria.ControlComboEnlace = Nothing
        Me.tbDesCategoria.ControlTextoEnlace = Nothing
        Me.tbDesCategoria.DatoRelacionado = Nothing
        Me.tbDesCategoria.Decimals = CType(2, Byte)
        Me.tbDesCategoria.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.tbDesCategoria.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDesCategoria.Format = HistoriaClinica.tbFormats.AlfabéticoConEspacios
        Me.tbDesCategoria.Location = New System.Drawing.Point(545, 154)
        Me.tbDesCategoria.MaxLength = 20
        Me.tbDesCategoria.Name = "tbDesCategoria"
        Me.tbDesCategoria.NombreCampoBuscado = Nothing
        Me.tbDesCategoria.NombreCampoBusqueda = Nothing
        Me.tbDesCategoria.NombreCampoDatos = Nothing
        Me.tbDesCategoria.Obligatorio = False
        Me.tbDesCategoria.OrigenDeDatos = Nothing
        Me.tbDesCategoria.PermitirValorCero = False
        Me.tbDesCategoria.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.tbDesCategoria.Size = New System.Drawing.Size(153, 22)
        Me.tbDesCategoria.TabIndex = 10
        Me.tbDesCategoria.TipoControl = HistoriaClinica.tbTipoControl.ListaAutoComplete
        Me.tbDesCategoria.UserValues = Nothing
        Me.tbDesCategoria.ValorMaximo = CType(0, Long)
        Me.tbDesCategoria.ValorMinimo = CType(0, Long)
        '
        'tbCodCategoria
        '
        Me.tbCodCategoria.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbCodCategoria.ControlComboEnlace = Nothing
        Me.tbCodCategoria.ControlTextoEnlace = Nothing
        Me.tbCodCategoria.DatoRelacionado = Nothing
        Me.tbCodCategoria.Decimals = CType(0, Byte)
        Me.tbCodCategoria.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.tbCodCategoria.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCodCategoria.Format = HistoriaClinica.tbFormats.AlfabéticoSinEspacios
        Me.tbCodCategoria.Location = New System.Drawing.Point(510, 154)
        Me.tbCodCategoria.MaxLength = 1
        Me.tbCodCategoria.Name = "tbCodCategoria"
        Me.tbCodCategoria.NombreCampoBuscado = Nothing
        Me.tbCodCategoria.NombreCampoBusqueda = Nothing
        Me.tbCodCategoria.NombreCampoDatos = Nothing
        Me.tbCodCategoria.Obligatorio = True
        Me.tbCodCategoria.OrigenDeDatos = Nothing
        Me.tbCodCategoria.PermitirValorCero = False
        Me.tbCodCategoria.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.tbCodCategoria.Size = New System.Drawing.Size(33, 22)
        Me.tbCodCategoria.TabIndex = 9
        Me.tbCodCategoria.TipoControl = HistoriaClinica.tbTipoControl.CodigoBusqueda
        Me.tbCodCategoria.UserValues = Nothing
        Me.tbCodCategoria.ValorMaximo = CType(0, Long)
        Me.tbCodCategoria.ValorMinimo = CType(0, Long)
        '
        'tbDesTipoDiag
        '
        Me.tbDesTipoDiag.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.tbDesTipoDiag.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.tbDesTipoDiag.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbDesTipoDiag.ControlComboEnlace = Nothing
        Me.tbDesTipoDiag.ControlTextoEnlace = Nothing
        Me.tbDesTipoDiag.DatoRelacionado = Nothing
        Me.tbDesTipoDiag.Decimals = CType(2, Byte)
        Me.tbDesTipoDiag.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.tbDesTipoDiag.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDesTipoDiag.Format = HistoriaClinica.tbFormats.AlfabéticoConEspacios
        Me.tbDesTipoDiag.Location = New System.Drawing.Point(188, 154)
        Me.tbDesTipoDiag.MaxLength = 30
        Me.tbDesTipoDiag.Name = "tbDesTipoDiag"
        Me.tbDesTipoDiag.NombreCampoBuscado = Nothing
        Me.tbDesTipoDiag.NombreCampoBusqueda = Nothing
        Me.tbDesTipoDiag.NombreCampoDatos = Nothing
        Me.tbDesTipoDiag.Obligatorio = False
        Me.tbDesTipoDiag.OrigenDeDatos = Nothing
        Me.tbDesTipoDiag.PermitirValorCero = False
        Me.tbDesTipoDiag.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.tbDesTipoDiag.Size = New System.Drawing.Size(226, 22)
        Me.tbDesTipoDiag.TabIndex = 8
        Me.tbDesTipoDiag.TipoControl = HistoriaClinica.tbTipoControl.ListaAutoComplete
        Me.tbDesTipoDiag.UserValues = Nothing
        Me.tbDesTipoDiag.ValorMaximo = CType(0, Long)
        Me.tbDesTipoDiag.ValorMinimo = CType(0, Long)
        '
        'tbCodTipoDiag
        '
        Me.tbCodTipoDiag.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbCodTipoDiag.ControlComboEnlace = Nothing
        Me.tbCodTipoDiag.ControlTextoEnlace = Nothing
        Me.tbCodTipoDiag.DatoRelacionado = Nothing
        Me.tbCodTipoDiag.Decimals = CType(0, Byte)
        Me.tbCodTipoDiag.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.tbCodTipoDiag.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCodTipoDiag.Format = HistoriaClinica.tbFormats.NúmericoEnteroSinSigno
        Me.tbCodTipoDiag.Location = New System.Drawing.Point(137, 154)
        Me.tbCodTipoDiag.MaxLength = 1
        Me.tbCodTipoDiag.Name = "tbCodTipoDiag"
        Me.tbCodTipoDiag.NombreCampoBuscado = Nothing
        Me.tbCodTipoDiag.NombreCampoBusqueda = Nothing
        Me.tbCodTipoDiag.NombreCampoDatos = Nothing
        Me.tbCodTipoDiag.Obligatorio = True
        Me.tbCodTipoDiag.OrigenDeDatos = Nothing
        Me.tbCodTipoDiag.PermitirValorCero = False
        Me.tbCodTipoDiag.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.tbCodTipoDiag.Size = New System.Drawing.Size(49, 22)
        Me.tbCodTipoDiag.TabIndex = 7
        Me.tbCodTipoDiag.TipoControl = HistoriaClinica.tbTipoControl.CodigoBusqueda
        Me.tbCodTipoDiag.UserValues = Nothing
        Me.tbCodTipoDiag.ValorMaximo = CType(5, Long)
        Me.tbCodTipoDiag.ValorMinimo = CType(1, Long)
        '
        'ctlDiagnosticos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Controls.Add(Me.gbDiagnostico)
        Me.Name = "ctlDiagnosticos"
        Me.Size = New System.Drawing.Size(1057, 238)
        Me.gbDiagnostico.ResumeLayout(False)
        Me.gbDiagnostico.PerformLayout()
        CType(Me.dtgDiagnosticos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gbDiagnostico As GroupBox
    Friend WithEvents tbObservaciones As TextBox
    Friend WithEvents lblObservaciones As Label
    Friend WithEvents cbAgregarEvo As CheckBox
    Friend WithEvents txtEstadoDiag As TextBoxConFormato
    Friend WithEvents txtCodEstadoDiag As TextBoxConFormato
    Friend WithEvents lblEstadoDiag As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents ckConfidencialEvo As CheckBox
    Friend WithEvents cbDiagnostico As ComboBusqueda
    Friend WithEvents dtgDiagnosticos As DataGridView
    Friend WithEvents tbCodDiag As TextBoxConFormato
    Friend WithEvents tbDesCategoria As TextBoxConFormato
    Friend WithEvents tbCodCategoria As TextBoxConFormato
    Friend WithEvents tbDesTipoDiag As TextBoxConFormato
    Friend WithEvents tbCodTipoDiag As TextBoxConFormato
    Friend WithEvents btnAgregarDiag As Button
    Friend WithEvents lblDiagnostico As Label
    Friend WithEvents lblCategoria As Label
    Friend WithEvents lblTipoDiagnostico As Label
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As DataGridViewTextBoxColumn
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LbObltenarsis As Label
    Friend WithEvents DIAGNOSTICO_desc As DataGridViewTextBoxColumn
    Friend WithEvents TIPO_DIAGNOSTICO As DataGridViewTextBoxColumn
    Friend WithEvents CATEGORIA As DataGridViewTextBoxColumn
    Friend WithEvents ESTADO As DataGridViewTextBoxColumn
    Friend WithEvents COD_PRE_SGS As DataGridViewTextBoxColumn
    Friend WithEvents COD_SUCUR As DataGridViewTextBoxColumn
    Friend WithEvents TIP_ADMISION As DataGridViewTextBoxColumn
    Friend WithEvents ANO_ADM As DataGridViewTextBoxColumn
    Friend WithEvents NUM_ADM As DataGridViewTextBoxColumn
    Friend WithEvents DIAGNOST As DataGridViewTextBoxColumn
    Friend WithEvents TIP_DIAG As DataGridViewTextBoxColumn
    Friend WithEvents LOGIN As DataGridViewTextBoxColumn
    Friend WithEvents TIP_DOC As DataGridViewTextBoxColumn
    Friend WithEvents NUM_DOC As DataGridViewTextBoxColumn
    Friend WithEvents CATEGORIA_DIAG As DataGridViewTextBoxColumn
    Friend WithEvents IDESTADODIAGNOSTICO As DataGridViewTextBoxColumn
    Friend WithEvents CLASIFICACION As DataGridViewTextBoxColumn
    Friend WithEvents OBS As DataGridViewTextBoxColumn
    Friend WithEvents ANTECEDENTE As DataGridViewTextBoxColumn
    Friend WithEvents CONFIDENCIAL As DataGridViewTextBoxColumn
    Friend WithEvents SECUENCIA As DataGridViewTextBoxColumn
    Friend WithEvents CLASE_DIAG As DataGridViewTextBoxColumn
    Friend WithEvents FEC_CON As DataGridViewTextBoxColumn
    Friend WithEvents ORIGEN As DataGridViewTextBoxColumn
End Class
