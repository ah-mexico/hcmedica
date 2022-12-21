<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaBeeblos
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
        Me.btnSalir = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.tvDocumentos = New System.Windows.Forms.TreeView
        Me.lblError = New System.Windows.Forms.Label
        Me.lblDescargaDoc = New System.Windows.Forms.Label
        Me.btnVisualizar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbTodos = New System.Windows.Forms.RadioButton
        Me.rbPorDoc = New System.Windows.Forms.RadioButton
        Me.tvClases = New System.Windows.Forms.TreeView
        Me.BtnDetallesDoc = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.lblProClaseDoc = New System.Windows.Forms.ListBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.LblPropDoc = New System.Windows.Forms.ListBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblRepositorios = New System.Windows.Forms.ListBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnRecargar = New System.Windows.Forms.Button
        Me.txtSegundoApellido = New HistoriaClinica.TextBoxConFormato
        Me.txtPrimerApellido = New HistoriaClinica.TextBoxConFormato
        Me.txtSegundoNombre = New HistoriaClinica.TextBoxConFormato
        Me.txtPrimerNombre = New HistoriaClinica.TextBoxConFormato
        Me.txtNumDoc = New HistoriaClinica.TextBoxConFormato
        Me.tbCodigoTipDoc = New HistoriaClinica.TextBoxConFormato
        Me.tbDescTipDoc = New HistoriaClinica.TextBoxConFormato
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.Transparent
        Me.btnSalir.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_salir
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.ForeColor = System.Drawing.Color.Transparent
        Me.btnSalir.Location = New System.Drawing.Point(741, 662)
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
        Me.btnCancelar.Location = New System.Drawing.Point(631, 662)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(104, 22)
        Me.btnCancelar.TabIndex = 26
        Me.btnCancelar.UseVisualStyleBackColor = False
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
        Me.Panel1.Controls.Add(Me.tvDocumentos)
        Me.Panel1.Controls.Add(Me.lblError)
        Me.Panel1.Controls.Add(Me.lblDescargaDoc)
        Me.Panel1.Controls.Add(Me.btnVisualizar)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.tvClases)
        Me.Panel1.Controls.Add(Me.BtnDetallesDoc)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.lblProClaseDoc)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.LblPropDoc)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.lblRepositorios)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.btnSalir)
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(854, 693)
        Me.Panel1.TabIndex = 0
        Me.Panel1.TabStop = True
        '
        'tvDocumentos
        '
        Me.tvDocumentos.Location = New System.Drawing.Point(541, 255)
        Me.tvDocumentos.Name = "tvDocumentos"
        Me.tvDocumentos.Size = New System.Drawing.Size(301, 214)
        Me.tvDocumentos.TabIndex = 51
        '
        'lblError
        '
        Me.lblError.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblError.ForeColor = System.Drawing.Color.Red
        Me.lblError.Location = New System.Drawing.Point(11, 665)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(458, 19)
        Me.lblError.TabIndex = 50
        Me.lblError.Text = "Descargando Documento, Por favor Espere..."
        Me.lblError.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblError.Visible = False
        '
        'lblDescargaDoc
        '
        Me.lblDescargaDoc.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescargaDoc.ForeColor = System.Drawing.Color.Red
        Me.lblDescargaDoc.Location = New System.Drawing.Point(178, 499)
        Me.lblDescargaDoc.Name = "lblDescargaDoc"
        Me.lblDescargaDoc.Size = New System.Drawing.Size(667, 22)
        Me.lblDescargaDoc.TabIndex = 49
        Me.lblDescargaDoc.Text = "Descargando Documento, Por favor Espere..."
        Me.lblDescargaDoc.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblDescargaDoc.Visible = False
        '
        'btnVisualizar
        '
        Me.btnVisualizar.Location = New System.Drawing.Point(502, 661)
        Me.btnVisualizar.Name = "btnVisualizar"
        Me.btnVisualizar.Size = New System.Drawing.Size(123, 23)
        Me.btnVisualizar.TabIndex = 48
        Me.btnVisualizar.Text = "Ver Documento"
        Me.btnVisualizar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbTodos)
        Me.GroupBox1.Controls.Add(Me.rbPorDoc)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox1.Location = New System.Drawing.Point(14, 45)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(828, 46)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        '
        'rbTodos
        '
        Me.rbTodos.AutoSize = True
        Me.rbTodos.Location = New System.Drawing.Point(181, 21)
        Me.rbTodos.Name = "rbTodos"
        Me.rbTodos.Size = New System.Drawing.Size(100, 18)
        Me.rbTodos.TabIndex = 1
        Me.rbTodos.Text = "Traer Todos"
        Me.rbTodos.UseVisualStyleBackColor = True
        Me.rbTodos.Visible = False
        '
        'rbPorDoc
        '
        Me.rbPorDoc.AutoSize = True
        Me.rbPorDoc.Checked = True
        Me.rbPorDoc.Location = New System.Drawing.Point(13, 21)
        Me.rbPorDoc.Name = "rbPorDoc"
        Me.rbPorDoc.Size = New System.Drawing.Size(162, 18)
        Me.rbPorDoc.TabIndex = 0
        Me.rbPorDoc.TabStop = True
        Me.rbPorDoc.Text = "Por Nro. y Documento"
        Me.rbPorDoc.UseVisualStyleBackColor = True
        '
        'tvClases
        '
        Me.tvClases.Location = New System.Drawing.Point(177, 255)
        Me.tvClases.Name = "tvClases"
        Me.tvClases.Size = New System.Drawing.Size(358, 214)
        Me.tvClases.TabIndex = 47
        '
        'BtnDetallesDoc
        '
        Me.BtnDetallesDoc.Location = New System.Drawing.Point(177, 473)
        Me.BtnDetallesDoc.Name = "BtnDetallesDoc"
        Me.BtnDetallesDoc.Size = New System.Drawing.Size(667, 23)
        Me.BtnDetallesDoc.TabIndex = 46
        Me.BtnDetallesDoc.Text = "Detalles (Descargar Documento) >>"
        Me.BtnDetallesDoc.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(174, 521)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(180, 13)
        Me.Label11.TabIndex = 44
        Me.Label11.Text = "Detalles Clases Documentales"
        '
        'lblProClaseDoc
        '
        Me.lblProClaseDoc.BackColor = System.Drawing.SystemColors.Control
        Me.lblProClaseDoc.FormattingEnabled = True
        Me.lblProClaseDoc.Location = New System.Drawing.Point(177, 535)
        Me.lblProClaseDoc.Name = "lblProClaseDoc"
        Me.lblProClaseDoc.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.lblProClaseDoc.Size = New System.Drawing.Size(358, 121)
        Me.lblProClaseDoc.TabIndex = 43
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(538, 521)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(143, 13)
        Me.Label10.TabIndex = 42
        Me.Label10.Text = "Detalles del Documento"
        '
        'LblPropDoc
        '
        Me.LblPropDoc.BackColor = System.Drawing.SystemColors.Control
        Me.LblPropDoc.FormattingEnabled = True
        Me.LblPropDoc.Location = New System.Drawing.Point(541, 535)
        Me.LblPropDoc.Name = "LblPropDoc"
        Me.LblPropDoc.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.LblPropDoc.Size = New System.Drawing.Size(298, 121)
        Me.LblPropDoc.TabIndex = 41
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(538, 239)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 13)
        Me.Label9.TabIndex = 40
        Me.Label9.Text = "Documentos"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(177, 239)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(130, 13)
        Me.Label8.TabIndex = 39
        Me.Label8.Text = "Clases Documentales"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 239)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 13)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "Repositorios"
        '
        'lblRepositorios
        '
        Me.lblRepositorios.FormattingEnabled = True
        Me.lblRepositorios.Location = New System.Drawing.Point(11, 255)
        Me.lblRepositorios.Name = "lblRepositorios"
        Me.lblRepositorios.Size = New System.Drawing.Size(160, 225)
        Me.lblRepositorios.TabIndex = 34
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnRecargar)
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
        Me.GroupBox2.Location = New System.Drawing.Point(14, 104)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(828, 124)
        Me.GroupBox2.TabIndex = 28
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos del Paciente"
        '
        'btnRecargar
        '
        Me.btnRecargar.Location = New System.Drawing.Point(665, 37)
        Me.btnRecargar.Name = "btnRecargar"
        Me.btnRecargar.Size = New System.Drawing.Size(137, 23)
        Me.btnRecargar.TabIndex = 15
        Me.btnRecargar.Text = "Traer Imagenes"
        Me.btnRecargar.UseVisualStyleBackColor = True
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
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "tip_admision"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Tipo Admisión"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 115
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "ano_adm"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Año"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 116
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "num_adm"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Número"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 115
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "fec_hc"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Fecha Historia"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 115
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Especialidad"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Especialidad"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 115
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "medico"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Médico"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 116
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "estado_salida"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Estado"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 115
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "estado_salida"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Estado"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 115
        '
        'frmConsultaBeeblos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(857, 697)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frmConsultaBeeblos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta Historia Clinica"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
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
    Friend WithEvents lblRepositorios As System.Windows.Forms.ListBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LblPropDoc As System.Windows.Forms.ListBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblProClaseDoc As System.Windows.Forms.ListBox
    Friend WithEvents BtnDetallesDoc As System.Windows.Forms.Button
    Friend WithEvents tvClases As System.Windows.Forms.TreeView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbTodos As System.Windows.Forms.RadioButton
    Friend WithEvents rbPorDoc As System.Windows.Forms.RadioButton
    Friend WithEvents btnRecargar As System.Windows.Forms.Button
    Friend WithEvents btnVisualizar As System.Windows.Forms.Button
    Friend WithEvents lblDescargaDoc As System.Windows.Forms.Label
    Friend WithEvents lblError As System.Windows.Forms.Label
    Friend WithEvents tvDocumentos As System.Windows.Forms.TreeView
End Class
