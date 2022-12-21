<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ConsultaLiquidos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_ConsultaLiquidos))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtgLiqElim = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnVisor = New System.Windows.Forms.Button()
        Me.mskFechaHasta = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnImprimirPlan = New System.Windows.Forms.Button()
        Me.dtgLiqAdmin = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.mskFechaInicial = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.mskFechaFinal = New System.Windows.Forms.MaskedTextBox()
        Me.dtgConsultaBalance = New System.Windows.Forms.DataGridView()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.dtgLiqElim, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dtgLiqAdmin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgConsultaBalance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(446, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(431, 21)
        Me.Label6.TabIndex = 75
        Me.Label6.Text = "LÍQUIDOS ELIMINADOS"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(12, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(428, 21)
        Me.Label5.TabIndex = 74
        Me.Label5.Text = "LÍQUIDOS ADMINISTRADOS"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'dtgLiqElim
        '
        Me.dtgLiqElim.AllowUserToAddRows = False
        Me.dtgLiqElim.AllowUserToDeleteRows = False
        Me.dtgLiqElim.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtgLiqElim.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dtgLiqElim.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtgLiqElim.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgLiqElim.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgLiqElim.ColumnHeadersHeight = 50
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgLiqElim.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtgLiqElim.Location = New System.Drawing.Point(449, 89)
        Me.dtgLiqElim.Name = "dtgLiqElim"
        Me.dtgLiqElim.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgLiqElim.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dtgLiqElim.RowHeadersVisible = False
        Me.dtgLiqElim.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgLiqElim.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dtgLiqElim.Size = New System.Drawing.Size(428, 468)
        Me.dtgLiqElim.TabIndex = 73
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btnVisor)
        Me.GroupBox1.Controls.Add(Me.mskFechaHasta)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox1.Location = New System.Drawing.Point(166, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(968, 53)
        Me.GroupBox1.TabIndex = 72
        Me.GroupBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(354, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 21)
        Me.Label4.TabIndex = 65
        Me.Label4.Text = "Fecha: "
        '
        'btnVisor
        '
        Me.btnVisor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVisor.Image = CType(resources.GetObject("btnVisor.Image"), System.Drawing.Image)
        Me.btnVisor.Location = New System.Drawing.Point(556, 21)
        Me.btnVisor.Name = "btnVisor"
        Me.btnVisor.Size = New System.Drawing.Size(30, 29)
        Me.btnVisor.TabIndex = 64
        Me.btnVisor.UseVisualStyleBackColor = True
        '
        'mskFechaHasta
        '
        Me.mskFechaHasta.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskFechaHasta.Location = New System.Drawing.Point(432, 26)
        Me.mskFechaHasta.Mask = "00/00/0000"
        Me.mskFechaHasta.Name = "mskFechaHasta"
        Me.mskFechaHasta.Size = New System.Drawing.Size(90, 21)
        Me.mskFechaHasta.TabIndex = 63
        Me.mskFechaHasta.ValidatingType = GetType(Date)
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(310, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(404, 21)
        Me.Label1.TabIndex = 62
        Me.Label1.Text = "CONTROL DE LÍQUIDOS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelar.BackgroundImage = CType(resources.GetObject("btnCancelar.BackgroundImage"), System.Drawing.Image)
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.ForeColor = System.Drawing.Color.Transparent
        Me.btnCancelar.Location = New System.Drawing.Point(1145, 562)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(104, 22)
        Me.btnCancelar.TabIndex = 71
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnImprimirPlan
        '
        Me.btnImprimirPlan.BackColor = System.Drawing.Color.Transparent
        Me.btnImprimirPlan.BackgroundImage = CType(resources.GetObject("btnImprimirPlan.BackgroundImage"), System.Drawing.Image)
        Me.btnImprimirPlan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnImprimirPlan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimirPlan.ForeColor = System.Drawing.Color.Transparent
        Me.btnImprimirPlan.Location = New System.Drawing.Point(958, 562)
        Me.btnImprimirPlan.Name = "btnImprimirPlan"
        Me.btnImprimirPlan.Size = New System.Drawing.Size(140, 22)
        Me.btnImprimirPlan.TabIndex = 70
        Me.btnImprimirPlan.UseVisualStyleBackColor = False
        '
        'dtgLiqAdmin
        '
        Me.dtgLiqAdmin.AllowUserToAddRows = False
        Me.dtgLiqAdmin.AllowUserToDeleteRows = False
        Me.dtgLiqAdmin.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtgLiqAdmin.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dtgLiqAdmin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtgLiqAdmin.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgLiqAdmin.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dtgLiqAdmin.ColumnHeadersHeight = 50
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgLiqAdmin.DefaultCellStyle = DataGridViewCellStyle5
        Me.dtgLiqAdmin.Location = New System.Drawing.Point(12, 89)
        Me.dtgLiqAdmin.Name = "dtgLiqAdmin"
        Me.dtgLiqAdmin.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgLiqAdmin.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dtgLiqAdmin.RowHeadersVisible = False
        Me.dtgLiqAdmin.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgLiqAdmin.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dtgLiqAdmin.Size = New System.Drawing.Size(428, 468)
        Me.dtgLiqAdmin.TabIndex = 69
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(281, 566)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 14)
        Me.Label2.TabIndex = 77
        Me.Label2.Text = "Fecha Inicial: "
        '
        'mskFechaInicial
        '
        Me.mskFechaInicial.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskFechaInicial.Location = New System.Drawing.Point(387, 564)
        Me.mskFechaInicial.Mask = "00/00/0000"
        Me.mskFechaInicial.Name = "mskFechaInicial"
        Me.mskFechaInicial.Size = New System.Drawing.Size(90, 21)
        Me.mskFechaInicial.TabIndex = 76
        Me.mskFechaInicial.ValidatingType = GetType(Date)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(545, 566)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 14)
        Me.Label3.TabIndex = 79
        Me.Label3.Text = "Fecha Final: "
        '
        'mskFechaFinal
        '
        Me.mskFechaFinal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskFechaFinal.Location = New System.Drawing.Point(638, 564)
        Me.mskFechaFinal.Mask = "00/00/0000"
        Me.mskFechaFinal.Name = "mskFechaFinal"
        Me.mskFechaFinal.Size = New System.Drawing.Size(90, 21)
        Me.mskFechaFinal.TabIndex = 78
        Me.mskFechaFinal.ValidatingType = GetType(Date)
        '
        'dtgConsultaBalance
        '
        Me.dtgConsultaBalance.AllowUserToAddRows = False
        Me.dtgConsultaBalance.AllowUserToDeleteRows = False
        Me.dtgConsultaBalance.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtgConsultaBalance.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dtgConsultaBalance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtgConsultaBalance.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgConsultaBalance.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dtgConsultaBalance.ColumnHeadersHeight = 50
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 6.75!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgConsultaBalance.DefaultCellStyle = DataGridViewCellStyle8
        Me.dtgConsultaBalance.Location = New System.Drawing.Point(891, 90)
        Me.dtgConsultaBalance.Name = "dtgConsultaBalance"
        Me.dtgConsultaBalance.ReadOnly = True
        Me.dtgConsultaBalance.RowHeadersVisible = False
        Me.dtgConsultaBalance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dtgConsultaBalance.Size = New System.Drawing.Size(356, 467)
        Me.dtgConsultaBalance.TabIndex = 80
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(891, 65)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(356, 21)
        Me.Label7.TabIndex = 81
        Me.Label7.Text = "BALANCE Y GASTO URINARIO"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frm_ConsultaLiquidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1259, 592)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dtgConsultaBalance)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.mskFechaFinal)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.mskFechaInicial)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dtgLiqElim)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnImprimirPlan)
        Me.Controls.Add(Me.dtgLiqAdmin)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frm_ConsultaLiquidos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Liquidos"
        CType(Me.dtgLiqElim, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dtgLiqAdmin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgConsultaBalance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtgLiqElim As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnVisor As System.Windows.Forms.Button
    Friend WithEvents mskFechaHasta As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnImprimirPlan As System.Windows.Forms.Button
    Friend WithEvents dtgLiqAdmin As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents mskFechaInicial As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents mskFechaFinal As System.Windows.Forms.MaskedTextBox
    Friend WithEvents dtgConsultaBalance As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
