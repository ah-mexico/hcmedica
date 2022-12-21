<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCorreccionEF_tmp
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CeldaNumerica1 = New HistoriaClinica.Sophia.HistoriaClinica.Comunes.CeldaNumerica
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtDatosMotivoConsulta = New System.Windows.Forms.RichTextBox
        Me.dtgHallazgosEF_tmp = New System.Windows.Forms.DataGridView
        Me.tlsMenu = New System.Windows.Forms.ToolStrip
        Me.tlbConfirmar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tlbReclasificar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.tlbSalir = New System.Windows.Forms.ToolStripButton
        Me.tlbSiguiente = New System.Windows.Forms.ToolStripButton
        Me.tlbSeparador = New System.Windows.Forms.ToolStripSeparator
        Me.tlbLabel = New System.Windows.Forms.ToolStripLabel
        Me.sistemaEFTMP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descripcionEFTMP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.obsEFTMP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.copiacodEFTMP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.codcorrecto = New HistoriaClinica.Sophia.HistoriaClinica.Comunes.CeldaNumerica
        Me.CodVieneDe = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dtgHallazgosEF_tmp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "sistema"
        Me.DataGridViewTextBoxColumn1.HeaderText = "sistema"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 55
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "descripcion"
        Me.DataGridViewTextBoxColumn2.HeaderText = "DESCRIPCIÓN"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.Width = 196
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "obs"
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewTextBoxColumn3.HeaderText = "HALLAZGOS"
        Me.DataGridViewTextBoxColumn3.MaxInputLength = 2000
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Width = 583
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "copiaobs"
        Me.DataGridViewTextBoxColumn4.HeaderText = "copiaobs"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn4.Visible = False
        '
        'CeldaNumerica1
        '
        Me.CeldaNumerica1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.CeldaNumerica1.DataPropertyName = "CodCorrecto"
        Me.CeldaNumerica1.FormatCelda = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.CeldaNumerica1.HeaderText = "CODIGO CORREGIDO"
        Me.CeldaNumerica1.Longitud = 0
        Me.CeldaNumerica1.Name = "CeldaNumerica1"
        Me.CeldaNumerica1.NumeroDecimals = 0
        Me.CeldaNumerica1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CeldaNumerica1.SeparadorDecimal = Global.Microsoft.VisualBasic.ChrW(0)
        Me.CeldaNumerica1.TipoControlCelda = HistoriaClinica.tbTipoControl.Normal
        Me.CeldaNumerica1.ValorMaximo = 0
        Me.CeldaNumerica1.ValorMinimo = 0
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "CodCorrecto"
        Me.DataGridViewTextBoxColumn5.HeaderText = "CODIGO CORREGIDO"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonShadow
        Me.Label1.Location = New System.Drawing.Point(0, 224)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1028, 18)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "E X A M E N    F I S I C O"
        '
        'txtDatosMotivoConsulta
        '
        Me.txtDatosMotivoConsulta.BackColor = System.Drawing.Color.White
        Me.txtDatosMotivoConsulta.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDatosMotivoConsulta.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDatosMotivoConsulta.Location = New System.Drawing.Point(12, 42)
        Me.txtDatosMotivoConsulta.Name = "txtDatosMotivoConsulta"
        Me.txtDatosMotivoConsulta.ReadOnly = True
        Me.txtDatosMotivoConsulta.Size = New System.Drawing.Size(1006, 180)
        Me.txtDatosMotivoConsulta.TabIndex = 24
        Me.txtDatosMotivoConsulta.Text = ""
        '
        'dtgHallazgosEF_tmp
        '
        Me.dtgHallazgosEF_tmp.AllowUserToAddRows = False
        Me.dtgHallazgosEF_tmp.AllowUserToDeleteRows = False
        Me.dtgHallazgosEF_tmp.AllowUserToOrderColumns = True
        Me.dtgHallazgosEF_tmp.AllowUserToResizeColumns = False
        Me.dtgHallazgosEF_tmp.AllowUserToResizeRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.dtgHallazgosEF_tmp.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dtgHallazgosEF_tmp.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtgHallazgosEF_tmp.BackgroundColor = System.Drawing.Color.White
        Me.dtgHallazgosEF_tmp.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgHallazgosEF_tmp.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dtgHallazgosEF_tmp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgHallazgosEF_tmp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.sistemaEFTMP, Me.descripcionEFTMP, Me.obsEFTMP, Me.copiacodEFTMP, Me.codcorrecto, Me.CodVieneDe})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(210, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgHallazgosEF_tmp.DefaultCellStyle = DataGridViewCellStyle4
        Me.dtgHallazgosEF_tmp.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dtgHallazgosEF_tmp.GridColor = System.Drawing.Color.Gray
        Me.dtgHallazgosEF_tmp.Location = New System.Drawing.Point(0, 242)
        Me.dtgHallazgosEF_tmp.MultiSelect = False
        Me.dtgHallazgosEF_tmp.Name = "dtgHallazgosEF_tmp"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(210, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgHallazgosEF_tmp.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dtgHallazgosEF_tmp.RowHeadersWidth = 30
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        Me.dtgHallazgosEF_tmp.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dtgHallazgosEF_tmp.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dtgHallazgosEF_tmp.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgHallazgosEF_tmp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dtgHallazgosEF_tmp.Size = New System.Drawing.Size(1028, 504)
        Me.dtgHallazgosEF_tmp.TabIndex = 27
        '
        'tlsMenu
        '
        Me.tlsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tlbConfirmar, Me.ToolStripSeparator1, Me.tlbReclasificar, Me.ToolStripSeparator3, Me.tlbSalir, Me.tlbSiguiente, Me.tlbSeparador, Me.tlbLabel})
        Me.tlsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tlsMenu.Name = "tlsMenu"
        Me.tlsMenu.Size = New System.Drawing.Size(1028, 39)
        Me.tlsMenu.TabIndex = 28
        Me.tlsMenu.Text = "ToolStrip1"
        '
        'tlbConfirmar
        '
        Me.tlbConfirmar.ForeColor = System.Drawing.Color.SteelBlue
        Me.tlbConfirmar.Image = Global.HistoriaClinica.My.Resources.Resources.iGuardar
        Me.tlbConfirmar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tlbConfirmar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlbConfirmar.Name = "tlbConfirmar"
        Me.tlbConfirmar.Size = New System.Drawing.Size(141, 36)
        Me.tlbConfirmar.Text = "CONFIRMAR DATOS"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'tlbReclasificar
        '
        Me.tlbReclasificar.ForeColor = System.Drawing.Color.SteelBlue
        Me.tlbReclasificar.Image = Global.HistoriaClinica.My.Resources.Resources.iReclasificarr
        Me.tlbReclasificar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tlbReclasificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlbReclasificar.Name = "tlbReclasificar"
        Me.tlbReclasificar.Size = New System.Drawing.Size(116, 36)
        Me.tlbReclasificar.Text = "RECLASIFICAR"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 39)
        '
        'tlbSalir
        '
        Me.tlbSalir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tlbSalir.ForeColor = System.Drawing.Color.SteelBlue
        Me.tlbSalir.Image = Global.HistoriaClinica.My.Resources.Resources.iSalir
        Me.tlbSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tlbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlbSalir.Name = "tlbSalir"
        Me.tlbSalir.Size = New System.Drawing.Size(72, 36)
        Me.tlbSalir.Text = "SALIR"
        '
        'tlbSiguiente
        '
        Me.tlbSiguiente.ForeColor = System.Drawing.Color.SteelBlue
        Me.tlbSiguiente.Image = Global.HistoriaClinica.My.Resources.Resources.iSiguiente
        Me.tlbSiguiente.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tlbSiguiente.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlbSiguiente.Name = "tlbSiguiente"
        Me.tlbSiguiente.Size = New System.Drawing.Size(188, 36)
        Me.tlbSiguiente.Text = "SIGUIENTE CORRECCIÓN . . ."
        Me.tlbSiguiente.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.tlbSiguiente.Visible = False
        '
        'tlbSeparador
        '
        Me.tlbSeparador.Name = "tlbSeparador"
        Me.tlbSeparador.Size = New System.Drawing.Size(6, 39)
        Me.tlbSeparador.Visible = False
        '
        'tlbLabel
        '
        Me.tlbLabel.ForeColor = System.Drawing.Color.SteelBlue
        Me.tlbLabel.Name = "tlbLabel"
        Me.tlbLabel.Size = New System.Drawing.Size(159, 36)
        Me.tlbLabel.Text = "1a. HC de 2 Para ser Revisadas"
        Me.tlbLabel.Visible = False
        '
        'sistemaEFTMP
        '
        Me.sistemaEFTMP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.sistemaEFTMP.DataPropertyName = "sistema"
        Me.sistemaEFTMP.HeaderText = "CÓDIGO"
        Me.sistemaEFTMP.Name = "sistemaEFTMP"
        Me.sistemaEFTMP.ReadOnly = True
        Me.sistemaEFTMP.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.sistemaEFTMP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.sistemaEFTMP.Width = 55
        '
        'descripcionEFTMP
        '
        Me.descripcionEFTMP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.descripcionEFTMP.DataPropertyName = "descripcion"
        Me.descripcionEFTMP.HeaderText = "DESCRIPCIÓN"
        Me.descripcionEFTMP.Name = "descripcionEFTMP"
        Me.descripcionEFTMP.ReadOnly = True
        Me.descripcionEFTMP.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.descripcionEFTMP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.descripcionEFTMP.Width = 196
        '
        'obsEFTMP
        '
        Me.obsEFTMP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.obsEFTMP.DataPropertyName = "obs"
        Me.obsEFTMP.HeaderText = "HALLAZGOS"
        Me.obsEFTMP.Name = "obsEFTMP"
        Me.obsEFTMP.ReadOnly = True
        Me.obsEFTMP.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.obsEFTMP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.obsEFTMP.Width = 600
        '
        'copiacodEFTMP
        '
        Me.copiacodEFTMP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.copiacodEFTMP.DataPropertyName = "copiacod"
        Me.copiacodEFTMP.HeaderText = "copiacod"
        Me.copiacodEFTMP.Name = "copiacodEFTMP"
        Me.copiacodEFTMP.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.copiacodEFTMP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.copiacodEFTMP.Visible = False
        '
        'codcorrecto
        '
        Me.codcorrecto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.codcorrecto.DataPropertyName = "codcorrecto"
        Me.codcorrecto.FormatCelda = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.codcorrecto.HeaderText = "CÓDIGO CORREGIDO"
        Me.codcorrecto.Longitud = 0
        Me.codcorrecto.Name = "codcorrecto"
        Me.codcorrecto.NumeroDecimals = 0
        Me.codcorrecto.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.codcorrecto.SeparadorDecimal = Global.Microsoft.VisualBasic.ChrW(0)
        Me.codcorrecto.TipoControlCelda = HistoriaClinica.tbTipoControl.Normal
        Me.codcorrecto.ValorMaximo = 0
        Me.codcorrecto.ValorMinimo = 0
        '
        'CodVieneDe
        '
        Me.CodVieneDe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.CodVieneDe.DataPropertyName = "CodVieneDe"
        Me.CodVieneDe.HeaderText = "CodVieneDe"
        Me.CodVieneDe.Name = "CodVieneDe"
        Me.CodVieneDe.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CodVieneDe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CodVieneDe.Visible = False
        '
        'frmCorreccionEF_tmp
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1028, 746)
        Me.Controls.Add(Me.tlsMenu)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDatosMotivoConsulta)
        Me.Controls.Add(Me.dtgHallazgosEF_tmp)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximumSize = New System.Drawing.Size(1036, 4000)
        Me.Name = "frmCorreccionEF_tmp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Corrección Examén Físico"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dtgHallazgosEF_tmp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlsMenu.ResumeLayout(False)
        Me.tlsMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CeldaNumerica1 As HistoriaClinica.Sophia.HistoriaClinica.Comunes.CeldaNumerica
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDatosMotivoConsulta As System.Windows.Forms.RichTextBox
    Friend WithEvents dtgHallazgosEF_tmp As System.Windows.Forms.DataGridView
    Friend WithEvents tlsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tlbConfirmar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tlbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tlbSeparador As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tlbReclasificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tlbSiguiente As System.Windows.Forms.ToolStripButton
    Friend WithEvents tlbLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents sistemaEFTMP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descripcionEFTMP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents obsEFTMP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents copiacodEFTMP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codcorrecto As HistoriaClinica.Sophia.HistoriaClinica.Comunes.CeldaNumerica
    Friend WithEvents CodVieneDe As System.Windows.Forms.DataGridViewTextBoxColumn


End Class
