<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReferencias
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
        Me.dtgReferencias = New System.Windows.Forms.DataGridView
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnAbrir = New System.Windows.Forms.Button
        Me.btnSalir = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.rbMedicoTodos = New System.Windows.Forms.RadioButton
        Me.rbMedicoOrdena = New System.Windows.Forms.RadioButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rbCerradas = New System.Windows.Forms.RadioButton
        Me.rbPendientes = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rbRemisiones = New System.Windows.Forms.RadioButton
        Me.rbProcedim = New System.Windows.Forms.RadioButton
        Me.hcOrigen = New System.Windows.Forms.DataGridViewLinkColumn
        Me.hcReferencia = New System.Windows.Forms.DataGridViewLinkColumn
        CType(Me.dtgReferencias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtgReferencias
        '
        Me.dtgReferencias.AllowUserToAddRows = False
        Me.dtgReferencias.AllowUserToDeleteRows = False
        Me.dtgReferencias.AllowUserToOrderColumns = True
        Me.dtgReferencias.AllowUserToResizeColumns = False
        Me.dtgReferencias.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtgReferencias.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgReferencias.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgReferencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgReferencias.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.hcOrigen, Me.hcReferencia})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(210, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgReferencias.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtgReferencias.Location = New System.Drawing.Point(12, 171)
        Me.dtgReferencias.MultiSelect = False
        Me.dtgReferencias.Name = "dtgReferencias"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(210, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgReferencias.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dtgReferencias.RowHeadersVisible = False
        Me.dtgReferencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgReferencias.Size = New System.Drawing.Size(837, 213)
        Me.dtgReferencias.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.Image = Global.HistoriaClinica.My.Resources.Resources.header_contrarreferencia2
        Me.PictureBox1.Location = New System.Drawing.Point(1, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(859, 39)
        Me.PictureBox1.TabIndex = 58
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnAbrir)
        Me.Panel1.Controls.Add(Me.btnSalir)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(861, 415)
        Me.Panel1.TabIndex = 0
        '
        'btnAbrir
        '
        Me.btnAbrir.BackColor = System.Drawing.Color.Transparent
        Me.btnAbrir.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_salir
        Me.btnAbrir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAbrir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAbrir.ForeColor = System.Drawing.Color.Transparent
        Me.btnAbrir.Image = Global.HistoriaClinica.My.Resources.Resources.bot_abrir
        Me.btnAbrir.Location = New System.Drawing.Point(635, 387)
        Me.btnAbrir.Name = "btnAbrir"
        Me.btnAbrir.Size = New System.Drawing.Size(110, 23)
        Me.btnAbrir.TabIndex = 2
        Me.btnAbrir.UseVisualStyleBackColor = False
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.Transparent
        Me.btnSalir.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_salir
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.ForeColor = System.Drawing.Color.Transparent
        Me.btnSalir.Location = New System.Drawing.Point(744, 387)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(104, 22)
        Me.btnSalir.TabIndex = 1
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(11, 47)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(837, 116)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Buscar Por:"
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.Color.Transparent
        Me.btnBuscar.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_buscar_individual
        Me.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.ForeColor = System.Drawing.Color.Transparent
        Me.btnBuscar.Location = New System.Drawing.Point(678, 71)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(104, 22)
        Me.btnBuscar.TabIndex = 0
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rbMedicoTodos)
        Me.GroupBox4.Controls.Add(Me.rbMedicoOrdena)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Black
        Me.GroupBox4.Location = New System.Drawing.Point(448, 22)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(175, 82)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Medico"
        '
        'rbMedicoTodos
        '
        Me.rbMedicoTodos.AutoSize = True
        Me.rbMedicoTodos.Location = New System.Drawing.Point(18, 55)
        Me.rbMedicoTodos.Name = "rbMedicoTodos"
        Me.rbMedicoTodos.Size = New System.Drawing.Size(63, 18)
        Me.rbMedicoTodos.TabIndex = 1
        Me.rbMedicoTodos.TabStop = True
        Me.rbMedicoTodos.Text = "Todos"
        Me.rbMedicoTodos.UseVisualStyleBackColor = True
        '
        'rbMedicoOrdena
        '
        Me.rbMedicoOrdena.AutoSize = True
        Me.rbMedicoOrdena.Location = New System.Drawing.Point(18, 20)
        Me.rbMedicoOrdena.Name = "rbMedicoOrdena"
        Me.rbMedicoOrdena.Size = New System.Drawing.Size(100, 18)
        Me.rbMedicoOrdena.TabIndex = 0
        Me.rbMedicoOrdena.TabStop = True
        Me.rbMedicoOrdena.Text = "Que ordena"
        Me.rbMedicoOrdena.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbCerradas)
        Me.GroupBox3.Controls.Add(Me.rbPendientes)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(267, 22)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(175, 82)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Estado"
        '
        'rbCerradas
        '
        Me.rbCerradas.AutoSize = True
        Me.rbCerradas.Location = New System.Drawing.Point(24, 55)
        Me.rbCerradas.Name = "rbCerradas"
        Me.rbCerradas.Size = New System.Drawing.Size(83, 18)
        Me.rbCerradas.TabIndex = 1
        Me.rbCerradas.TabStop = True
        Me.rbCerradas.Text = "Cerradas"
        Me.rbCerradas.UseVisualStyleBackColor = True
        '
        'rbPendientes
        '
        Me.rbPendientes.AutoSize = True
        Me.rbPendientes.Location = New System.Drawing.Point(24, 20)
        Me.rbPendientes.Name = "rbPendientes"
        Me.rbPendientes.Size = New System.Drawing.Size(96, 18)
        Me.rbPendientes.TabIndex = 0
        Me.rbPendientes.TabStop = True
        Me.rbPendientes.Text = "Pendientes"
        Me.rbPendientes.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbRemisiones)
        Me.GroupBox2.Controls.Add(Me.rbProcedim)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(86, 22)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(175, 82)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo"
        '
        'rbRemisiones
        '
        Me.rbRemisiones.AutoSize = True
        Me.rbRemisiones.Location = New System.Drawing.Point(18, 55)
        Me.rbRemisiones.Name = "rbRemisiones"
        Me.rbRemisiones.Size = New System.Drawing.Size(96, 18)
        Me.rbRemisiones.TabIndex = 1
        Me.rbRemisiones.TabStop = True
        Me.rbRemisiones.Text = "Remisiones"
        Me.rbRemisiones.UseVisualStyleBackColor = True
        '
        'rbProcedim
        '
        Me.rbProcedim.AutoSize = True
        Me.rbProcedim.Location = New System.Drawing.Point(18, 20)
        Me.rbProcedim.Name = "rbProcedim"
        Me.rbProcedim.Size = New System.Drawing.Size(121, 18)
        Me.rbProcedim.TabIndex = 0
        Me.rbProcedim.TabStop = True
        Me.rbProcedim.Text = "Procedimientos"
        Me.rbProcedim.UseVisualStyleBackColor = True
        '
        'hcOrigen
        '
        Me.hcOrigen.DataPropertyName = "hcOrigen"
        Me.hcOrigen.HeaderText = "ORIGEN"
        Me.hcOrigen.Name = "hcOrigen"
        Me.hcOrigen.Visible = False
        '
        'hcReferencia
        '
        Me.hcReferencia.DataPropertyName = "hcReferencia"
        Me.hcReferencia.HeaderText = "REFERENCIA"
        Me.hcReferencia.Name = "hcReferencia"
        Me.hcReferencia.Visible = False
        '
        'frmReferencias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(861, 415)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.dtgReferencias)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmReferencias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Referencias"
        CType(Me.dtgReferencias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtgReferencias As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbMedicoTodos As System.Windows.Forms.RadioButton
    Friend WithEvents rbMedicoOrdena As System.Windows.Forms.RadioButton
    Friend WithEvents rbCerradas As System.Windows.Forms.RadioButton
    Friend WithEvents rbPendientes As System.Windows.Forms.RadioButton
    Friend WithEvents rbRemisiones As System.Windows.Forms.RadioButton
    Friend WithEvents rbProcedim As System.Windows.Forms.RadioButton
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnAbrir As System.Windows.Forms.Button
    Friend WithEvents hcOrigen As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents hcReferencia As System.Windows.Forms.DataGridViewLinkColumn
End Class
