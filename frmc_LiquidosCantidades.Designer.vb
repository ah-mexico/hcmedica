<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmc_LiquidosCantidades
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmc_LiquidosCantidades))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdGuardarAlarma = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkmenos = New System.Windows.Forms.CheckBox()
        Me.chkmas = New System.Windows.Forms.CheckBox()
        Me.pnlLiqElim = New System.Windows.Forms.Panel()
        Me.chkListBoxCar = New System.Windows.Forms.CheckedListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pbEquivalencias = New System.Windows.Forms.PictureBox()
        Me.LblCarateristicas = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlLiqAdm = New System.Windows.Forms.Panel()
        Me.txtCantidad1 = New HistoriaClinica.TextBoxConFormato()
        Me.txtobs = New HistoriaClinica.TextBoxConFormato()
        Me.txtCantidad = New HistoriaClinica.TextBoxConFormato()
        Me.GroupBox1.SuspendLayout()
        Me.pnlLiqElim.SuspendLayout()
        CType(Me.pbEquivalencias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLiqAdm.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(211, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 14)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Centímetros Cúbicos"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(12, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 14)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Cantidad"
        '
        'cmdGuardarAlarma
        '
        Me.cmdGuardarAlarma.BackgroundImage = CType(resources.GetObject("cmdGuardarAlarma.BackgroundImage"), System.Drawing.Image)
        Me.cmdGuardarAlarma.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmdGuardarAlarma.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdGuardarAlarma.ForeColor = System.Drawing.Color.Transparent
        Me.cmdGuardarAlarma.Location = New System.Drawing.Point(260, 202)
        Me.cmdGuardarAlarma.Name = "cmdGuardarAlarma"
        Me.cmdGuardarAlarma.Size = New System.Drawing.Size(79, 25)
        Me.cmdGuardarAlarma.TabIndex = 2
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelar.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_cancelar
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.ForeColor = System.Drawing.Color.Transparent
        Me.btnCancelar.Location = New System.Drawing.Point(345, 203)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(104, 22)
        Me.btnCancelar.TabIndex = 27
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkmenos)
        Me.GroupBox1.Controls.Add(Me.chkmas)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(135, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(89, 38)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        '
        'chkmenos
        '
        Me.chkmenos.AutoSize = True
        Me.chkmenos.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold)
        Me.chkmenos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.chkmenos.Location = New System.Drawing.Point(48, 10)
        Me.chkmenos.Name = "chkmenos"
        Me.chkmenos.Size = New System.Drawing.Size(35, 22)
        Me.chkmenos.TabIndex = 32
        Me.chkmenos.Text = "-"
        Me.chkmenos.UseVisualStyleBackColor = True
        '
        'chkmas
        '
        Me.chkmas.AutoSize = True
        Me.chkmas.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold)
        Me.chkmas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.chkmas.Location = New System.Drawing.Point(6, 10)
        Me.chkmas.Name = "chkmas"
        Me.chkmas.Size = New System.Drawing.Size(40, 22)
        Me.chkmas.TabIndex = 31
        Me.chkmas.Text = "+"
        Me.chkmas.UseVisualStyleBackColor = True
        '
        'pnlLiqElim
        '
        Me.pnlLiqElim.Controls.Add(Me.chkListBoxCar)
        Me.pnlLiqElim.Controls.Add(Me.Label4)
        Me.pnlLiqElim.Location = New System.Drawing.Point(2, 70)
        Me.pnlLiqElim.Name = "pnlLiqElim"
        Me.pnlLiqElim.Size = New System.Drawing.Size(453, 123)
        Me.pnlLiqElim.TabIndex = 10
        '
        'chkListBoxCar
        '
        Me.chkListBoxCar.FormattingEnabled = True
        Me.chkListBoxCar.Location = New System.Drawing.Point(161, 15)
        Me.chkListBoxCar.MultiColumn = True
        Me.chkListBoxCar.Name = "chkListBoxCar"
        Me.chkListBoxCar.Size = New System.Drawing.Size(264, 94)
        Me.chkListBoxCar.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(10, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 14)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Caracteristicas"
        '
        'pbEquivalencias

        Me.pbEquivalencias.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.DatosPaciente
        Me.pbEquivalencias.Location = New System.Drawing.Point(479, 72)
        Me.pbEquivalencias.Name = "pbEquivalencias"
        Me.pbEquivalencias.Size = New System.Drawing.Size(137, 107)
        Me.pbEquivalencias.TabIndex = 32
        Me.pbEquivalencias.TabStop = False
        '
        'LblCarateristicas
        '
        Me.LblCarateristicas.AutoSize = True
        Me.LblCarateristicas.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LblCarateristicas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.LblCarateristicas.Location = New System.Drawing.Point(15, 12)
        Me.LblCarateristicas.Name = "LblCarateristicas"
        Me.LblCarateristicas.Size = New System.Drawing.Size(106, 14)
        Me.LblCarateristicas.TabIndex = 10
        Me.LblCarateristicas.Text = "Caracteristicas"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(16, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 14)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Observaciones"
        '
        'pnlLiqAdm
        '
        Me.pnlLiqAdm.Controls.Add(Me.txtobs)
        Me.pnlLiqAdm.Controls.Add(Me.Label3)
        Me.pnlLiqAdm.Controls.Add(Me.LblCarateristicas)
        Me.pnlLiqAdm.Location = New System.Drawing.Point(2, 71)
        Me.pnlLiqAdm.Name = "pnlLiqAdm"
        Me.pnlLiqAdm.Size = New System.Drawing.Size(471, 123)
        Me.pnlLiqAdm.TabIndex = 31
        '
        'txtCantidad1
        '
        Me.txtCantidad1.ControlComboEnlace = Nothing
        Me.txtCantidad1.ControlTextoEnlace = Nothing
        Me.txtCantidad1.DatoRelacionado = Nothing
        Me.txtCantidad1.Decimals = CType(1, Byte)
        Me.txtCantidad1.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtCantidad1.Format = HistoriaClinica.tbFormats.NúmericoDecimalFijoSinSigno
        Me.txtCantidad1.Location = New System.Drawing.Point(135, 45)
        Me.txtCantidad1.Name = "txtCantidad1"
        Me.txtCantidad1.NombreCampoBuscado = Nothing
        Me.txtCantidad1.NombreCampoBusqueda = Nothing
        Me.txtCantidad1.NombreCampoDatos = Nothing
        Me.txtCantidad1.Obligatorio = False
        Me.txtCantidad1.OrigenDeDatos = Nothing
        Me.txtCantidad1.PermitirValorCero = False
        Me.txtCantidad1.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtCantidad1.Size = New System.Drawing.Size(70, 20)
        Me.txtCantidad1.TabIndex = 35
        Me.txtCantidad1.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtCantidad1.UserValues = Nothing
        Me.txtCantidad1.ValorMaximo = CType(9999, Long)
        Me.txtCantidad1.ValorMinimo = CType(0, Long)
        '
        'txtobs
        '
        Me.txtobs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtobs.ControlComboEnlace = Nothing
        Me.txtobs.ControlTextoEnlace = Nothing
        Me.txtobs.DatoRelacionado = Nothing
        Me.txtobs.Decimals = CType(2, Byte)
        Me.txtobs.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtobs.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.txtobs.Location = New System.Drawing.Point(139, 12)
        Me.txtobs.MaxLength = 200
        Me.txtobs.Multiline = True
        Me.txtobs.Name = "txtobs"
        Me.txtobs.NombreCampoBuscado = Nothing
        Me.txtobs.NombreCampoBusqueda = Nothing
        Me.txtobs.NombreCampoDatos = Nothing
        Me.txtobs.Obligatorio = False
        Me.txtobs.OrigenDeDatos = Nothing
        Me.txtobs.PermitirValorCero = False
        Me.txtobs.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtobs.Size = New System.Drawing.Size(314, 65)
        Me.txtobs.TabIndex = 1
        Me.txtobs.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtobs.UserValues = Nothing
        Me.txtobs.ValorMaximo = CType(0, Long)
        Me.txtobs.ValorMinimo = CType(0, Long)
        '
        'txtCantidad
        '
        Me.txtCantidad.ControlComboEnlace = Nothing
        Me.txtCantidad.ControlTextoEnlace = Nothing
        Me.txtCantidad.DatoRelacionado = Nothing
        Me.txtCantidad.Decimals = CType(1, Byte)
        Me.txtCantidad.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtCantidad.Format = HistoriaClinica.tbFormats.NúmericoDecimalFijoConSigno
        Me.txtCantidad.Location = New System.Drawing.Point(505, 12)
        Me.txtCantidad.MaxLength = 6
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.NombreCampoBuscado = Nothing
        Me.txtCantidad.NombreCampoBusqueda = Nothing
        Me.txtCantidad.NombreCampoDatos = Nothing
        Me.txtCantidad.Obligatorio = False
        Me.txtCantidad.OrigenDeDatos = Nothing
        Me.txtCantidad.PermitirValorCero = False
        Me.txtCantidad.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtCantidad.Size = New System.Drawing.Size(89, 20)
        Me.txtCantidad.TabIndex = 0
        Me.txtCantidad.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtCantidad.UserValues = Nothing
        Me.txtCantidad.ValorMaximo = CType(0, Long)
        Me.txtCantidad.ValorMinimo = CType(0, Long)
        '
        'frmc_LiquidosCantidades
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(640, 231)
        Me.Controls.Add(Me.txtCantidad1)
        Me.Controls.Add(Me.pbEquivalencias)
        Me.Controls.Add(Me.pnlLiqElim)
        Me.Controls.Add(Me.pnlLiqAdm)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.cmdGuardarAlarma)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmc_LiquidosCantidades"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Liquidos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlLiqElim.ResumeLayout(False)
        Me.pnlLiqElim.PerformLayout()
        CType(Me.pbEquivalencias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLiqAdm.ResumeLayout(False)
        Me.pnlLiqAdm.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As HistoriaClinica.TextBoxConFormato
    Friend WithEvents cmdGuardarAlarma As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkmenos As System.Windows.Forms.CheckBox
    Friend WithEvents chkmas As System.Windows.Forms.CheckBox
    Friend WithEvents pnlLiqElim As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pbEquivalencias As System.Windows.Forms.PictureBox
    Friend WithEvents chkListBoxCar As System.Windows.Forms.CheckedListBox
    Friend WithEvents LblCarateristicas As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtobs As TextBoxConFormato
    Friend WithEvents pnlLiqAdm As Panel
    Friend WithEvents txtCantidad1 As TextBoxConFormato
End Class
