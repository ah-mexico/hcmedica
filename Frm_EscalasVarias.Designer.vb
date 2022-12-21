<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_EscalasVarias
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlRiesgo = New System.Windows.Forms.Panel()
        Me.pnlEscala2 = New System.Windows.Forms.Panel()
        Me.txtResultadoEsc2 = New System.Windows.Forms.TextBox()
        Me.txtEsc2Interpretacion = New System.Windows.Forms.TextBox()
        Me.pnlEscala4Riss = New System.Windows.Forms.Panel()
        Me.txtResultadoRelaconEP = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Proceso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.categoria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.factor_riesgo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn36 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cod_tiporiesgo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.categoriaRiesgo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EscalaId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Visible = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Informacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PFechaR = New System.Windows.Forms.Panel()
        Me.tbMinutoR = New System.Windows.Forms.MaskedTextBox()
        Me.tbHoraR = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.mtFechaR = New System.Windows.Forms.MaskedTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btImprimirRiesgo = New System.Windows.Forms.Button()
        Me.LblRiesgo = New System.Windows.Forms.Label()
        Me.cmdGuardarRiesgo = New System.Windows.Forms.Button()
        Me.dtgRiesgoD = New System.Windows.Forms.DataGridView()
        Me.FechayHora = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codigo_historia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.hora_riesgocaida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.min_riesgocaida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Puntaje = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Riesgo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Secuencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLASIFICACIONEP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.medico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cargos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Escala = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdEscalaBd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ChkRiesgo = New System.Windows.Forms.CheckedListBox()
        Me.ChkRiesgoDet = New System.Windows.Forms.CheckedListBox()
        Me.pnlEscalas = New System.Windows.Forms.Panel()
        Me.TxtTotalPuntaje = New System.Windows.Forms.TextBox()
        Me.TxtRiesgo = New System.Windows.Forms.TextBox()
        Me.TxtPuntaje2 = New System.Windows.Forms.TextBox()
        Me.pnlRiesgo.SuspendLayout()
        Me.pnlEscala2.SuspendLayout()
        Me.pnlEscala4Riss.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PFechaR.SuspendLayout()
        CType(Me.dtgRiesgoD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEscalas.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlRiesgo
        '
        Me.pnlRiesgo.AutoSize = True
        Me.pnlRiesgo.Controls.Add(Me.pnlEscala2)
        Me.pnlRiesgo.Controls.Add(Me.pnlEscala4Riss)
        Me.pnlRiesgo.Controls.Add(Me.TextBox1)
        Me.pnlRiesgo.Controls.Add(Me.DataGridView1)
        Me.pnlRiesgo.Controls.Add(Me.PFechaR)
        Me.pnlRiesgo.Controls.Add(Me.btImprimirRiesgo)
        Me.pnlRiesgo.Controls.Add(Me.LblRiesgo)
        Me.pnlRiesgo.Controls.Add(Me.cmdGuardarRiesgo)
        Me.pnlRiesgo.Controls.Add(Me.dtgRiesgoD)
        Me.pnlRiesgo.Controls.Add(Me.Panel3)
        Me.pnlRiesgo.Controls.Add(Me.ChkRiesgo)
        Me.pnlRiesgo.Controls.Add(Me.ChkRiesgoDet)
        Me.pnlRiesgo.Controls.Add(Me.pnlEscalas)
        Me.pnlRiesgo.Location = New System.Drawing.Point(1, 12)
        Me.pnlRiesgo.Name = "pnlRiesgo"
        Me.pnlRiesgo.Size = New System.Drawing.Size(1102, 555)
        Me.pnlRiesgo.TabIndex = 9
        '
        'pnlEscala2
        '
        Me.pnlEscala2.Controls.Add(Me.txtResultadoEsc2)
        Me.pnlEscala2.Controls.Add(Me.txtEsc2Interpretacion)
        Me.pnlEscala2.Location = New System.Drawing.Point(3, 486)
        Me.pnlEscala2.Name = "pnlEscala2"
        Me.pnlEscala2.Size = New System.Drawing.Size(552, 27)
        Me.pnlEscala2.TabIndex = 114
        '
        'txtResultadoEsc2
        '
        Me.txtResultadoEsc2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtResultadoEsc2.Cursor = System.Windows.Forms.Cursors.No
        Me.txtResultadoEsc2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResultadoEsc2.Location = New System.Drawing.Point(232, 3)
        Me.txtResultadoEsc2.Name = "txtResultadoEsc2"
        Me.txtResultadoEsc2.ReadOnly = True
        Me.txtResultadoEsc2.Size = New System.Drawing.Size(317, 21)
        Me.txtResultadoEsc2.TabIndex = 115
        Me.txtResultadoEsc2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtEsc2Interpretacion
        '
        Me.txtEsc2Interpretacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEsc2Interpretacion.Cursor = System.Windows.Forms.Cursors.No
        Me.txtEsc2Interpretacion.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEsc2Interpretacion.Location = New System.Drawing.Point(3, 3)
        Me.txtEsc2Interpretacion.Name = "txtEsc2Interpretacion"
        Me.txtEsc2Interpretacion.ReadOnly = True
        Me.txtEsc2Interpretacion.Size = New System.Drawing.Size(234, 21)
        Me.txtEsc2Interpretacion.TabIndex = 114
        Me.txtEsc2Interpretacion.Text = "Interpretación a la gravedad"
        Me.txtEsc2Interpretacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'pnlEscala4Riss
        '
        Me.pnlEscala4Riss.Controls.Add(Me.txtResultadoRelaconEP)
        Me.pnlEscala4Riss.Controls.Add(Me.TextBox5)
        Me.pnlEscala4Riss.Location = New System.Drawing.Point(3, 516)
        Me.pnlEscala4Riss.Name = "pnlEscala4Riss"
        Me.pnlEscala4Riss.Size = New System.Drawing.Size(552, 30)
        Me.pnlEscala4Riss.TabIndex = 116
        '
        'txtResultadoRelaconEP
        '
        Me.txtResultadoRelaconEP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtResultadoRelaconEP.Cursor = System.Windows.Forms.Cursors.No
        Me.txtResultadoRelaconEP.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResultadoRelaconEP.Location = New System.Drawing.Point(216, 3)
        Me.txtResultadoRelaconEP.Name = "txtResultadoRelaconEP"
        Me.txtResultadoRelaconEP.ReadOnly = True
        Me.txtResultadoRelaconEP.Size = New System.Drawing.Size(333, 21)
        Me.txtResultadoRelaconEP.TabIndex = 115
        Me.txtResultadoRelaconEP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox5
        '
        Me.TextBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox5.Cursor = System.Windows.Forms.Cursors.No
        Me.TextBox5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(3, 3)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(217, 21)
        Me.TextBox5.TabIndex = 114
        Me.TextBox5.Text = "Relación Enfermera/Paciente: "
        Me.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(488, 80)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(521, 21)
        Me.TextBox1.TabIndex = 112
        Me.TextBox1.Text = "Histórico"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Proceso, Me.categoria, Me.factor_riesgo, Me.DataGridViewCheckBoxColumn1, Me.DataGridViewTextBoxColumn36, Me.cod_tiporiesgo, Me.categoriaRiesgo, Me.EscalaId, Me.Visible, Me.Informacion})
        Me.DataGridView1.Location = New System.Drawing.Point(6, 34)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 23
        Me.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DataGridView1.Size = New System.Drawing.Size(479, 446)
        Me.DataGridView1.TabIndex = 108
        '
        'Proceso
        '
        Me.Proceso.DataPropertyName = "Proceso"
        Me.Proceso.HeaderText = "Proceso"
        Me.Proceso.Name = "Proceso"
        Me.Proceso.ReadOnly = True
        Me.Proceso.Visible = False
        '
        'categoria
        '
        Me.categoria.DataPropertyName = "categoria"
        Me.categoria.HeaderText = "Parámetro"
        Me.categoria.Name = "categoria"
        Me.categoria.ReadOnly = True
        Me.categoria.Width = 90
        '
        'factor_riesgo
        '
        Me.factor_riesgo.DataPropertyName = "factor_riesgo"
        Me.factor_riesgo.FillWeight = 80.0!
        Me.factor_riesgo.HeaderText = "Criterio de Riesgo"
        Me.factor_riesgo.Name = "factor_riesgo"
        Me.factor_riesgo.ReadOnly = True
        Me.factor_riesgo.Width = 180
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.DataPropertyName = "check"
        Me.DataGridViewCheckBoxColumn1.FalseValue = "0"
        Me.DataGridViewCheckBoxColumn1.HeaderText = ""
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.TrueValue = "1"
        Me.DataGridViewCheckBoxColumn1.Width = 50
        '
        'DataGridViewTextBoxColumn36
        '
        Me.DataGridViewTextBoxColumn36.DataPropertyName = "valor"
        Me.DataGridViewTextBoxColumn36.HeaderText = "valor"
        Me.DataGridViewTextBoxColumn36.Name = "DataGridViewTextBoxColumn36"
        Me.DataGridViewTextBoxColumn36.ReadOnly = True
        Me.DataGridViewTextBoxColumn36.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn36.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn36.Visible = False
        Me.DataGridViewTextBoxColumn36.Width = 150
        '
        'cod_tiporiesgo
        '
        Me.cod_tiporiesgo.DataPropertyName = "cod_tiporiesgo"
        Me.cod_tiporiesgo.HeaderText = "cod_tiporiesgo"
        Me.cod_tiporiesgo.Name = "cod_tiporiesgo"
        Me.cod_tiporiesgo.ReadOnly = True
        Me.cod_tiporiesgo.Visible = False
        '
        'categoriaRiesgo
        '
        Me.categoriaRiesgo.DataPropertyName = "categoriaRiesgo"
        Me.categoriaRiesgo.HeaderText = "categoriaRiesgo"
        Me.categoriaRiesgo.Name = "categoriaRiesgo"
        Me.categoriaRiesgo.ReadOnly = True
        Me.categoriaRiesgo.Visible = False
        '
        'EscalaId
        '
        Me.EscalaId.DataPropertyName = "IdEscala"
        Me.EscalaId.HeaderText = "IdEscala"
        Me.EscalaId.Name = "EscalaId"
        Me.EscalaId.ReadOnly = True
        Me.EscalaId.Visible = False
        '
        'Visible
        '
        Me.Visible.DataPropertyName = "Visible"
        Me.Visible.HeaderText = "Visible"
        Me.Visible.Name = "Visible"
        Me.Visible.ReadOnly = True
        Me.Visible.Visible = False
        '
        'Informacion
        '
        Me.Informacion.DataPropertyName = "informacion"
        Me.Informacion.HeaderText = "Informacion"
        Me.Informacion.Name = "Informacion"
        Me.Informacion.Visible = False
        '
        'PFechaR
        '
        Me.PFechaR.Controls.Add(Me.tbMinutoR)
        Me.PFechaR.Controls.Add(Me.tbHoraR)
        Me.PFechaR.Controls.Add(Me.Label5)
        Me.PFechaR.Controls.Add(Me.mtFechaR)
        Me.PFechaR.Controls.Add(Me.Label6)
        Me.PFechaR.Controls.Add(Me.Label7)
        Me.PFechaR.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PFechaR.Location = New System.Drawing.Point(488, 39)
        Me.PFechaR.Name = "PFechaR"
        Me.PFechaR.Size = New System.Drawing.Size(333, 35)
        Me.PFechaR.TabIndex = 37
        '
        'tbMinutoR
        '
        Me.tbMinutoR.Enabled = False
        Me.tbMinutoR.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.tbMinutoR.Location = New System.Drawing.Point(297, 3)
        Me.tbMinutoR.Mask = "00"
        Me.tbMinutoR.Name = "tbMinutoR"
        Me.tbMinutoR.Size = New System.Drawing.Size(29, 20)
        Me.tbMinutoR.TabIndex = 116
        '
        'tbHoraR
        '
        Me.tbHoraR.Enabled = False
        Me.tbHoraR.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.tbHoraR.Location = New System.Drawing.Point(198, 3)
        Me.tbHoraR.Mask = "00"
        Me.tbHoraR.Name = "tbHoraR"
        Me.tbHoraR.Size = New System.Drawing.Size(29, 20)
        Me.tbHoraR.TabIndex = 115
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(233, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 15)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Minuto"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'mtFechaR
        '
        Me.mtFechaR.Enabled = False
        Me.mtFechaR.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.mtFechaR.Location = New System.Drawing.Point(53, 2)
        Me.mtFechaR.Mask = "00/00/0000"
        Me.mtFechaR.Name = "mtFechaR"
        Me.mtFechaR.Size = New System.Drawing.Size(88, 20)
        Me.mtFechaR.TabIndex = 0
        Me.mtFechaR.ValidatingType = GetType(Date)
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(3, 4)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 17)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Fecha"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(147, 4)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 17)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Hora"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btImprimirRiesgo
        '
        Me.btImprimirRiesgo.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btImprimirRiesgo.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_consultar
        Me.btImprimirRiesgo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btImprimirRiesgo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btImprimirRiesgo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btImprimirRiesgo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btImprimirRiesgo.ForeColor = System.Drawing.Color.Transparent
        Me.btImprimirRiesgo.Location = New System.Drawing.Point(985, 449)
        Me.btImprimirRiesgo.Name = "btImprimirRiesgo"
        Me.btImprimirRiesgo.Size = New System.Drawing.Size(103, 31)
        Me.btImprimirRiesgo.TabIndex = 36
        Me.btImprimirRiesgo.UseVisualStyleBackColor = False
        '
        'LblRiesgo
        '
        Me.LblRiesgo.BackColor = System.Drawing.Color.Transparent
        Me.LblRiesgo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRiesgo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.LblRiesgo.Location = New System.Drawing.Point(3, 70)
        Me.LblRiesgo.Name = "LblRiesgo"
        Me.LblRiesgo.Size = New System.Drawing.Size(237, 16)
        Me.LblRiesgo.TabIndex = 35
        Me.LblRiesgo.Text = "Tiene Riesgo:"
        Me.LblRiesgo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblRiesgo.Visible = False
        '
        'cmdGuardarRiesgo
        '
        Me.cmdGuardarRiesgo.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_guardar
        Me.cmdGuardarRiesgo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmdGuardarRiesgo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdGuardarRiesgo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdGuardarRiesgo.ForeColor = System.Drawing.Color.Transparent
        Me.cmdGuardarRiesgo.Location = New System.Drawing.Point(889, 449)
        Me.cmdGuardarRiesgo.Name = "cmdGuardarRiesgo"
        Me.cmdGuardarRiesgo.Size = New System.Drawing.Size(79, 31)
        Me.cmdGuardarRiesgo.TabIndex = 32
        '
        'dtgRiesgoD
        '
        Me.dtgRiesgoD.AllowUserToAddRows = False
        Me.dtgRiesgoD.AllowUserToDeleteRows = False
        Me.dtgRiesgoD.AllowUserToResizeColumns = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.dtgRiesgoD.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dtgRiesgoD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgRiesgoD.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dtgRiesgoD.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.dtgRiesgoD.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgRiesgoD.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dtgRiesgoD.ColumnHeadersHeight = 30
        Me.dtgRiesgoD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtgRiesgoD.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FechayHora, Me.codigo_historia, Me.hora_riesgocaida, Me.min_riesgocaida, Me.Puntaje, Me.Riesgo, Me.Secuencia, Me.CLASIFICACIONEP, Me.medico, Me.usuario, Me.Cargos, Me.Descripcion, Me.Escala, Me.IdEscalaBd})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(210, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgRiesgoD.DefaultCellStyle = DataGridViewCellStyle5
        Me.dtgRiesgoD.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtgRiesgoD.GridColor = System.Drawing.Color.Black
        Me.dtgRiesgoD.Location = New System.Drawing.Point(488, 100)
        Me.dtgRiesgoD.Name = "dtgRiesgoD"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(210, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgRiesgoD.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dtgRiesgoD.RowHeadersWidth = 40
        Me.dtgRiesgoD.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgRiesgoD.RowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dtgRiesgoD.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgRiesgoD.RowTemplate.Height = 20
        Me.dtgRiesgoD.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgRiesgoD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgRiesgoD.Size = New System.Drawing.Size(600, 182)
        Me.dtgRiesgoD.TabIndex = 30
        '
        'FechayHora
        '
        Me.FechayHora.DataPropertyName = "fecha"
        Me.FechayHora.HeaderText = "Fecha y Hora"
        Me.FechayHora.Name = "FechayHora"
        Me.FechayHora.ReadOnly = True
        Me.FechayHora.Width = 107
        '
        'codigo_historia
        '
        Me.codigo_historia.DataPropertyName = "cod_historia"
        Me.codigo_historia.HeaderText = "Codigo Historia"
        Me.codigo_historia.Name = "codigo_historia"
        Me.codigo_historia.ReadOnly = True
        Me.codigo_historia.Visible = False
        Me.codigo_historia.Width = 119
        '
        'hora_riesgocaida
        '
        Me.hora_riesgocaida.DataPropertyName = "hora_riesgocaida"
        Me.hora_riesgocaida.HeaderText = "hora_riesgocaida"
        Me.hora_riesgocaida.Name = "hora_riesgocaida"
        Me.hora_riesgocaida.ReadOnly = True
        Me.hora_riesgocaida.Visible = False
        Me.hora_riesgocaida.Width = 130
        '
        'min_riesgocaida
        '
        Me.min_riesgocaida.DataPropertyName = "min_riesgocaida"
        Me.min_riesgocaida.HeaderText = "min_riesgocaida"
        Me.min_riesgocaida.Name = "min_riesgocaida"
        Me.min_riesgocaida.ReadOnly = True
        Me.min_riesgocaida.Visible = False
        Me.min_riesgocaida.Width = 125
        '
        'Puntaje
        '
        Me.Puntaje.DataPropertyName = "valorriesgo"
        Me.Puntaje.HeaderText = "Puntaje"
        Me.Puntaje.Name = "Puntaje"
        Me.Puntaje.ReadOnly = True
        Me.Puntaje.Width = 75
        '
        'Riesgo
        '
        Me.Riesgo.DataPropertyName = "Riesgo"
        Me.Riesgo.HeaderText = "Riesgo"
        Me.Riesgo.Name = "Riesgo"
        Me.Riesgo.ReadOnly = True
        Me.Riesgo.Width = 70
        '
        'Secuencia
        '
        Me.Secuencia.DataPropertyName = "Consecutivo"
        Me.Secuencia.HeaderText = "Consecutivo"
        Me.Secuencia.Name = "Secuencia"
        Me.Secuencia.ReadOnly = True
        Me.Secuencia.Visible = False
        Me.Secuencia.Width = 102
        '
        'CLASIFICACIONEP
        '
        Me.CLASIFICACIONEP.DataPropertyName = "CLASIFICACIONEP"
        Me.CLASIFICACIONEP.HeaderText = "Relación Enfermera/Paciente"
        Me.CLASIFICACIONEP.Name = "CLASIFICACIONEP"
        Me.CLASIFICACIONEP.ReadOnly = True
        Me.CLASIFICACIONEP.Visible = False
        Me.CLASIFICACIONEP.Width = 197
        '
        'medico
        '
        Me.medico.DataPropertyName = "medico"
        Me.medico.HeaderText = "medico"
        Me.medico.Name = "medico"
        Me.medico.ReadOnly = True
        Me.medico.Visible = False
        Me.medico.Width = 73
        '
        'usuario
        '
        Me.usuario.DataPropertyName = "login"
        Me.usuario.HeaderText = "usuario"
        Me.usuario.Name = "usuario"
        Me.usuario.ReadOnly = True
        Me.usuario.Width = 74
        '
        'Cargos
        '
        Me.Cargos.DataPropertyName = "cargo"
        Me.Cargos.HeaderText = "Cargo"
        Me.Cargos.Name = "Cargos"
        Me.Cargos.ReadOnly = True
        Me.Cargos.Width = 67
        '
        'Descripcion
        '
        Me.Descripcion.DataPropertyName = "Descripcion"
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Visible = False
        Me.Descripcion.Width = 98
        '
        'Escala
        '
        Me.Escala.DataPropertyName = "Escala"
        Me.Escala.HeaderText = "Escala"
        Me.Escala.Name = "Escala"
        Me.Escala.ReadOnly = True
        Me.Escala.Visible = False
        Me.Escala.Width = 68
        '
        'IdEscalaBd
        '
        Me.IdEscalaBd.DataPropertyName = "IdEscalaBd"
        Me.IdEscalaBd.HeaderText = "IdEscalaBd"
        Me.IdEscalaBd.Name = "IdEscalaBd"
        Me.IdEscalaBd.ReadOnly = True
        Me.IdEscalaBd.Visible = False
        Me.IdEscalaBd.Width = 95
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1102, 33)
        Me.Panel3.TabIndex = 17
        '
        'ChkRiesgo
        '
        Me.ChkRiesgo.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ChkRiesgo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChkRiesgo.ColumnWidth = 175
        Me.ChkRiesgo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkRiesgo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.ChkRiesgo.FormattingEnabled = True
        Me.ChkRiesgo.Location = New System.Drawing.Point(9, 101)
        Me.ChkRiesgo.MultiColumn = True
        Me.ChkRiesgo.Name = "ChkRiesgo"
        Me.ChkRiesgo.Size = New System.Drawing.Size(358, 34)
        Me.ChkRiesgo.TabIndex = 106
        '
        'ChkRiesgoDet
        '
        Me.ChkRiesgoDet.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ChkRiesgoDet.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChkRiesgoDet.ColumnWidth = 175
        Me.ChkRiesgoDet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkRiesgoDet.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ChkRiesgoDet.FormattingEnabled = True
        Me.ChkRiesgoDet.Location = New System.Drawing.Point(9, 101)
        Me.ChkRiesgoDet.MultiColumn = True
        Me.ChkRiesgoDet.Name = "ChkRiesgoDet"
        Me.ChkRiesgoDet.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.ChkRiesgoDet.Size = New System.Drawing.Size(349, 34)
        Me.ChkRiesgoDet.Sorted = True
        Me.ChkRiesgoDet.TabIndex = 105
        Me.ChkRiesgoDet.Tag = "2"
        '
        'pnlEscalas
        '
        Me.pnlEscalas.Controls.Add(Me.TxtTotalPuntaje)
        Me.pnlEscalas.Controls.Add(Me.TxtRiesgo)
        Me.pnlEscalas.Controls.Add(Me.TxtPuntaje2)
        Me.pnlEscalas.Location = New System.Drawing.Point(6, 485)
        Me.pnlEscalas.Name = "pnlEscalas"
        Me.pnlEscalas.Size = New System.Drawing.Size(520, 28)
        Me.pnlEscalas.TabIndex = 117
        '
        'TxtTotalPuntaje
        '
        Me.TxtTotalPuntaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTotalPuntaje.Cursor = System.Windows.Forms.Cursors.No
        Me.TxtTotalPuntaje.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalPuntaje.Location = New System.Drawing.Point(0, 3)
        Me.TxtTotalPuntaje.Name = "TxtTotalPuntaje"
        Me.TxtTotalPuntaje.ReadOnly = True
        Me.TxtTotalPuntaje.Size = New System.Drawing.Size(125, 21)
        Me.TxtTotalPuntaje.TabIndex = 113
        Me.TxtTotalPuntaje.Text = "Total Puntaje"
        Me.TxtTotalPuntaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtRiesgo
        '
        Me.TxtRiesgo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtRiesgo.Cursor = System.Windows.Forms.Cursors.No
        Me.TxtRiesgo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRiesgo.Location = New System.Drawing.Point(195, 3)
        Me.TxtRiesgo.Name = "TxtRiesgo"
        Me.TxtRiesgo.ReadOnly = True
        Me.TxtRiesgo.Size = New System.Drawing.Size(318, 21)
        Me.TxtRiesgo.TabIndex = 111
        Me.TxtRiesgo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtPuntaje2
        '
        Me.TxtPuntaje2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPuntaje2.Cursor = System.Windows.Forms.Cursors.No
        Me.TxtPuntaje2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPuntaje2.Location = New System.Drawing.Point(121, 3)
        Me.TxtPuntaje2.Name = "TxtPuntaje2"
        Me.TxtPuntaje2.ReadOnly = True
        Me.TxtPuntaje2.Size = New System.Drawing.Size(79, 21)
        Me.TxtPuntaje2.TabIndex = 110
        Me.TxtPuntaje2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Frm_EscalasVarias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1104, 569)
        Me.Controls.Add(Me.pnlRiesgo)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_EscalasVarias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Escalas"
        Me.pnlRiesgo.ResumeLayout(False)
        Me.pnlRiesgo.PerformLayout()
        Me.pnlEscala2.ResumeLayout(False)
        Me.pnlEscala2.PerformLayout()
        Me.pnlEscala4Riss.ResumeLayout(False)
        Me.pnlEscala4Riss.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PFechaR.ResumeLayout(False)
        Me.PFechaR.PerformLayout()
        CType(Me.dtgRiesgoD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEscalas.ResumeLayout(False)
        Me.pnlEscalas.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlRiesgo As Panel
    Friend WithEvents pnlEscala2 As Panel
    Friend WithEvents txtResultadoEsc2 As TextBox
    Friend WithEvents txtEsc2Interpretacion As TextBox
    Friend WithEvents pnlEscala4Riss As Panel
    Friend WithEvents txtResultadoRelaconEP As TextBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Proceso As DataGridViewTextBoxColumn
    Friend WithEvents categoria As DataGridViewTextBoxColumn
    Friend WithEvents factor_riesgo As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn36 As DataGridViewTextBoxColumn
    Friend WithEvents cod_tiporiesgo As DataGridViewTextBoxColumn
    Friend WithEvents categoriaRiesgo As DataGridViewTextBoxColumn
    Friend WithEvents EscalaId As DataGridViewTextBoxColumn
    Friend WithEvents Visible As DataGridViewTextBoxColumn
    Friend WithEvents Informacion As DataGridViewTextBoxColumn
    Friend WithEvents PFechaR As Panel
    Friend WithEvents tbMinutoR As MaskedTextBox
    Friend WithEvents tbHoraR As MaskedTextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents mtFechaR As MaskedTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents btImprimirRiesgo As Button
    Friend WithEvents LblRiesgo As Label
    Friend WithEvents cmdGuardarRiesgo As Button
    Friend WithEvents dtgRiesgoD As DataGridView
    Friend WithEvents FechayHora As DataGridViewTextBoxColumn
    Friend WithEvents codigo_historia As DataGridViewTextBoxColumn
    Friend WithEvents hora_riesgocaida As DataGridViewTextBoxColumn
    Friend WithEvents min_riesgocaida As DataGridViewTextBoxColumn
    Friend WithEvents Puntaje As DataGridViewTextBoxColumn
    Friend WithEvents Riesgo As DataGridViewTextBoxColumn
    Friend WithEvents Secuencia As DataGridViewTextBoxColumn
    Friend WithEvents CLASIFICACIONEP As DataGridViewTextBoxColumn
    Friend WithEvents medico As DataGridViewTextBoxColumn
    Friend WithEvents usuario As DataGridViewTextBoxColumn
    Friend WithEvents Cargos As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents Escala As DataGridViewTextBoxColumn
    Friend WithEvents IdEscalaBd As DataGridViewTextBoxColumn
    Friend WithEvents Panel3 As Panel
    Friend WithEvents ChkRiesgo As CheckedListBox
    Friend WithEvents ChkRiesgoDet As CheckedListBox
    Friend WithEvents pnlEscalas As Panel
    Friend WithEvents TxtTotalPuntaje As TextBox
    Friend WithEvents TxtRiesgo As TextBox
    Friend WithEvents TxtPuntaje2 As TextBox
End Class
