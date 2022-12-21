<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlPlanIncapacidad
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.lbObservaciones = New System.Windows.Forms.Label()
        Me.tbObservaciones = New System.Windows.Forms.TextBox()
        Me.lbDiagnostico = New System.Windows.Forms.Label()
        Me.lbDias = New System.Windows.Forms.Label()
        Me.lbFecIni = New System.Windows.Forms.Label()
        Me.lbFecFinal = New System.Windows.Forms.Label()
        Me.tbFechaFinal = New System.Windows.Forms.TextBox()
        Me.mtFechaInicial = New System.Windows.Forms.MaskedTextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btGrabar = New System.Windows.Forms.Button()
        Me.cmbDiagnostico = New System.Windows.Forms.ComboBox()
        Me.tbDias = New HistoriaClinica.TextBoxConFormato()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbObservaciones
        '
        Me.lbObservaciones.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbObservaciones.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lbObservaciones.Location = New System.Drawing.Point(3, 95)
        Me.lbObservaciones.Name = "lbObservaciones"
        Me.lbObservaciones.Size = New System.Drawing.Size(111, 26)
        Me.lbObservaciones.TabIndex = 0
        Me.lbObservaciones.Text = "Observaciones"
        Me.lbObservaciones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbObservaciones
        '
        Me.tbObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbObservaciones.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbObservaciones.Location = New System.Drawing.Point(117, 95)
        Me.tbObservaciones.MaxLength = 800
        Me.tbObservaciones.Multiline = True
        Me.tbObservaciones.Name = "tbObservaciones"
        Me.tbObservaciones.ReadOnly = True
        Me.tbObservaciones.Size = New System.Drawing.Size(665, 57)
        Me.tbObservaciones.TabIndex = 3
        '
        'lbDiagnostico
        '
        Me.lbDiagnostico.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDiagnostico.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lbDiagnostico.Location = New System.Drawing.Point(3, 52)
        Me.lbDiagnostico.Name = "lbDiagnostico"
        Me.lbDiagnostico.Size = New System.Drawing.Size(88, 22)
        Me.lbDiagnostico.TabIndex = 0
        Me.lbDiagnostico.Text = "Diagnóstico"
        Me.lbDiagnostico.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbDias
        '
        Me.lbDias.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDias.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lbDias.Location = New System.Drawing.Point(3, 176)
        Me.lbDias.Name = "lbDias"
        Me.lbDias.Size = New System.Drawing.Size(144, 20)
        Me.lbDias.TabIndex = 0
        Me.lbDias.Text = "Días de incapacidad"
        Me.lbDias.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbFecIni
        '
        Me.lbFecIni.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFecIni.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lbFecIni.Location = New System.Drawing.Point(274, 176)
        Me.lbFecIni.Name = "lbFecIni"
        Me.lbFecIni.Size = New System.Drawing.Size(106, 20)
        Me.lbFecIni.TabIndex = 0
        Me.lbFecIni.Text = "Fecha inicial "
        Me.lbFecIni.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbFecFinal
        '
        Me.lbFecFinal.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFecFinal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lbFecFinal.Location = New System.Drawing.Point(591, 174)
        Me.lbFecFinal.Name = "lbFecFinal"
        Me.lbFecFinal.Size = New System.Drawing.Size(86, 20)
        Me.lbFecFinal.TabIndex = 0
        Me.lbFecFinal.Text = "Fecha final"
        Me.lbFecFinal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbFechaFinal
        '
        Me.tbFechaFinal.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbFechaFinal.Location = New System.Drawing.Point(685, 174)
        Me.tbFechaFinal.Name = "tbFechaFinal"
        Me.tbFechaFinal.ReadOnly = True
        Me.tbFechaFinal.Size = New System.Drawing.Size(95, 22)
        Me.tbFechaFinal.TabIndex = 6
        '
        'mtFechaInicial
        '
        Me.mtFechaInicial.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtFechaInicial.Location = New System.Drawing.Point(377, 175)
        Me.mtFechaInicial.Mask = "00/00/0000"
        Me.mtFechaInicial.Name = "mtFechaInicial"
        Me.mtFechaInicial.Size = New System.Drawing.Size(87, 22)
        Me.mtFechaInicial.TabIndex = 5
        Me.mtFechaInicial.ValidatingType = GetType(Date)
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Image = Global.HistoriaClinica.My.Resources.Resources.imag_25
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(800, 34)
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'btGrabar
        '
        Me.btGrabar.BackColor = System.Drawing.Color.Transparent
        Me.btGrabar.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_guardar_mostrar
        Me.btGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btGrabar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btGrabar.ForeColor = System.Drawing.Color.Transparent
        Me.btGrabar.Location = New System.Drawing.Point(362, 221)
        Me.btGrabar.Name = "btGrabar"
        Me.btGrabar.Size = New System.Drawing.Size(114, 27)
        Me.btGrabar.TabIndex = 7
        Me.btGrabar.UseVisualStyleBackColor = False
        '
        'cmbDiagnostico
        '
        Me.cmbDiagnostico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDiagnostico.FormattingEnabled = True
        Me.cmbDiagnostico.Location = New System.Drawing.Point(117, 52)
        Me.cmbDiagnostico.Name = "cmbDiagnostico"
        Me.cmbDiagnostico.Size = New System.Drawing.Size(665, 21)
        Me.cmbDiagnostico.TabIndex = 14
        '
        'tbDias
        '
        Me.tbDias.ControlComboEnlace = Nothing
        Me.tbDias.ControlTextoEnlace = Nothing
        Me.tbDias.DatoRelacionado = Nothing
        Me.tbDias.Decimals = CType(0, Byte)
        Me.tbDias.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.tbDias.Format = HistoriaClinica.tbFormats.NúmericoEnteroSinSigno
        Me.tbDias.Location = New System.Drawing.Point(154, 173)
        Me.tbDias.MaxLength = 3
        Me.tbDias.Name = "tbDias"
        Me.tbDias.NombreCampoBuscado = Nothing
        Me.tbDias.NombreCampoBusqueda = Nothing
        Me.tbDias.NombreCampoDatos = Nothing
        Me.tbDias.Obligatorio = False
        Me.tbDias.OrigenDeDatos = Nothing
        Me.tbDias.PermitirValorCero = False
        Me.tbDias.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.tbDias.Size = New System.Drawing.Size(55, 20)
        Me.tbDias.TabIndex = 4
        Me.tbDias.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.tbDias.UserValues = Nothing
        Me.tbDias.ValorMaximo = CType(180, Long)
        Me.tbDias.ValorMinimo = CType(1, Long)
        '
        'ctlPlanIncapacidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Controls.Add(Me.cmbDiagnostico)
        Me.Controls.Add(Me.tbDias)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.mtFechaInicial)
        Me.Controls.Add(Me.btGrabar)
        Me.Controls.Add(Me.tbFechaFinal)
        Me.Controls.Add(Me.lbFecFinal)
        Me.Controls.Add(Me.lbFecIni)
        Me.Controls.Add(Me.lbDias)
        Me.Controls.Add(Me.lbObservaciones)
        Me.Controls.Add(Me.tbObservaciones)
        Me.Controls.Add(Me.lbDiagnostico)
        Me.Name = "ctlPlanIncapacidad"
        Me.Size = New System.Drawing.Size(800, 269)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbObservaciones As System.Windows.Forms.Label
    Friend WithEvents tbObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents lbDiagnostico As System.Windows.Forms.Label
    Friend WithEvents lbDias As System.Windows.Forms.Label
    Friend WithEvents lbFecIni As System.Windows.Forms.Label
    Friend WithEvents lbFecFinal As System.Windows.Forms.Label
    Friend WithEvents tbFechaFinal As System.Windows.Forms.TextBox
    Friend WithEvents btGrabar As System.Windows.Forms.Button
    Friend WithEvents mtFechaInicial As System.Windows.Forms.MaskedTextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents tbDias As HistoriaClinica.TextBoxConFormato
    Friend WithEvents cmbDiagnostico As ComboBox
End Class
