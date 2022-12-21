<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConsultaResultadosLab
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.dtpFechaInicial = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.dgvResultadoLaboratorio = New System.Windows.Forms.DataGridView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
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
        Me.Ano = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Orden = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pruebas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Validado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Interpretacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Modulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaOrdena = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtDescTipoDocumento = New HistoriaClinica.TextBoxConFormato()
        Me.txtCodigoTipoDocumento = New HistoriaClinica.TextBoxConFormato()
        Me.txtNumeroDocumento = New HistoriaClinica.TextBoxConFormato()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvResultadoLaboratorio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.Transparent
        Me.btnSalir.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_salir
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.ForeColor = System.Drawing.Color.Transparent
        Me.btnSalir.Location = New System.Drawing.Point(752, 410)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(104, 22)
        Me.btnSalir.TabIndex = 59
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.WebBrowser1)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.dgvResultadoLaboratorio)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.btnSalir)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(868, 450)
        Me.Panel1.TabIndex = 60
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(20, 405)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(713, 35)
        Me.WebBrowser1.TabIndex = 65
        Me.WebBrowser1.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtNumeroDocumento)
        Me.GroupBox1.Controls.Add(Me.txtDescTipoDocumento)
        Me.GroupBox1.Controls.Add(Me.txtCodigoTipoDocumento)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtSegundoApellido)
        Me.GroupBox1.Controls.Add(Me.txtPrimerApellido)
        Me.GroupBox1.Controls.Add(Me.txtSegundoNombre)
        Me.GroupBox1.Controls.Add(Me.txtPrimerNombre)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.dtpFechaInicial)
        Me.GroupBox1.Controls.Add(Me.dtpFechaFinal)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 47)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(844, 157)
        Me.GroupBox1.TabIndex = 64
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Rango de Busqueda"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(313, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 13)
        Me.Label7.TabIndex = 82
        Me.Label7.Text = "No. Documento"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 13)
        Me.Label8.TabIndex = 81
        Me.Label8.Text = "Tipo Documento"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(607, 111)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 13)
        Me.Label6.TabIndex = 74
        Me.Label6.Text = "Segundo Apellido"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(407, 111)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 13)
        Me.Label5.TabIndex = 73
        Me.Label5.Text = "Primer Apellido"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(206, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 13)
        Me.Label4.TabIndex = 72
        Me.Label4.Text = "Segundo Nombre"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 13)
        Me.Label3.TabIndex = 71
        Me.Label3.Text = "Primer Nombre"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(228, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 66
        Me.Label2.Text = "Fecha Final"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 65
        Me.Label1.Text = "Fecha Inicial"
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.Color.Transparent
        Me.btnBuscar.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_buscar_individual
        Me.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.ForeColor = System.Drawing.Color.Transparent
        Me.btnBuscar.Location = New System.Drawing.Point(486, 79)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(104, 22)
        Me.btnBuscar.TabIndex = 64
        Me.btnBuscar.Text = "0"
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'dtpFechaInicial
        '
        Me.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicial.Location = New System.Drawing.Point(9, 80)
        Me.dtpFechaInicial.Name = "dtpFechaInicial"
        Me.dtpFechaInicial.Size = New System.Drawing.Size(200, 21)
        Me.dtpFechaInicial.TabIndex = 62
        '
        'dtpFechaFinal
        '
        Me.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFinal.Location = New System.Drawing.Point(231, 80)
        Me.dtpFechaFinal.Name = "dtpFechaFinal"
        Me.dtpFechaFinal.Size = New System.Drawing.Size(200, 21)
        Me.dtpFechaFinal.TabIndex = 63
        '
        'dgvResultadoLaboratorio
        '
        Me.dgvResultadoLaboratorio.BackgroundColor = System.Drawing.Color.White
        Me.dgvResultadoLaboratorio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResultadoLaboratorio.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Ano, Me.Fecha, Me.Orden, Me.Pruebas, Me.Validado, Me.Interpretacion, Me.Modulo, Me.FechaOrdena})
        Me.dgvResultadoLaboratorio.GridColor = System.Drawing.Color.Gray
        Me.dgvResultadoLaboratorio.Location = New System.Drawing.Point(12, 210)
        Me.dgvResultadoLaboratorio.Name = "dgvResultadoLaboratorio"
        Me.dgvResultadoLaboratorio.Size = New System.Drawing.Size(843, 181)
        Me.dgvResultadoLaboratorio.TabIndex = 61
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.PictureBox1.Image = Global.HistoriaClinica.My.Resources.Resources.header_resultadosLaboratorio
        Me.PictureBox1.Location = New System.Drawing.Point(1, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(867, 39)
        Me.PictureBox1.TabIndex = 60
        Me.PictureBox1.TabStop = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Acciones"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Acciones"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn1.Width = 70
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Ano"
        DataGridViewCellStyle3.Format = "d"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn2.HeaderText = "Año"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.DataGridViewTextBoxColumn2.Width = 50
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Fecha"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Fecha"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 90
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Orden"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Orden"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 255
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Pruebas"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Pruebas"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn5.Width = 300
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Validado"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Validado"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn6.Width = 80
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Interpretacion"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Interpretación"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Visible = False
        Me.DataGridViewTextBoxColumn7.Width = 90
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "FechaOrdena"
        Me.DataGridViewTextBoxColumn8.HeaderText = "FechaOrdena"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Visible = False
        '
        'txtSegundoApellido
        '
        Me.txtSegundoApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSegundoApellido.ControlComboEnlace = Nothing
        Me.txtSegundoApellido.ControlTextoEnlace = Nothing
        Me.txtSegundoApellido.DatoRelacionado = Nothing
        Me.txtSegundoApellido.Decimals = CType(2, Byte)
        Me.txtSegundoApellido.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtSegundoApellido.Enabled = False
        Me.txtSegundoApellido.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.txtSegundoApellido.Location = New System.Drawing.Point(611, 126)
        Me.txtSegundoApellido.Name = "txtSegundoApellido"
        Me.txtSegundoApellido.NombreCampoBuscado = Nothing
        Me.txtSegundoApellido.NombreCampoBusqueda = Nothing
        Me.txtSegundoApellido.NombreCampoDatos = Nothing
        Me.txtSegundoApellido.Obligatorio = False
        Me.txtSegundoApellido.OrigenDeDatos = Nothing
        Me.txtSegundoApellido.PermitirValorCero = False
        Me.txtSegundoApellido.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtSegundoApellido.Size = New System.Drawing.Size(200, 21)
        Me.txtSegundoApellido.TabIndex = 70
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
        Me.txtPrimerApellido.Enabled = False
        Me.txtPrimerApellido.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.txtPrimerApellido.Location = New System.Drawing.Point(410, 126)
        Me.txtPrimerApellido.Name = "txtPrimerApellido"
        Me.txtPrimerApellido.NombreCampoBuscado = Nothing
        Me.txtPrimerApellido.NombreCampoBusqueda = Nothing
        Me.txtPrimerApellido.NombreCampoDatos = Nothing
        Me.txtPrimerApellido.Obligatorio = False
        Me.txtPrimerApellido.OrigenDeDatos = Nothing
        Me.txtPrimerApellido.PermitirValorCero = False
        Me.txtPrimerApellido.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtPrimerApellido.Size = New System.Drawing.Size(200, 21)
        Me.txtPrimerApellido.TabIndex = 69
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
        Me.txtSegundoNombre.Enabled = False
        Me.txtSegundoNombre.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.txtSegundoNombre.Location = New System.Drawing.Point(209, 126)
        Me.txtSegundoNombre.Name = "txtSegundoNombre"
        Me.txtSegundoNombre.NombreCampoBuscado = Nothing
        Me.txtSegundoNombre.NombreCampoBusqueda = Nothing
        Me.txtSegundoNombre.NombreCampoDatos = Nothing
        Me.txtSegundoNombre.Obligatorio = False
        Me.txtSegundoNombre.OrigenDeDatos = Nothing
        Me.txtSegundoNombre.PermitirValorCero = False
        Me.txtSegundoNombre.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtSegundoNombre.Size = New System.Drawing.Size(200, 21)
        Me.txtSegundoNombre.TabIndex = 68
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
        Me.txtPrimerNombre.Enabled = False
        Me.txtPrimerNombre.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.txtPrimerNombre.Location = New System.Drawing.Point(9, 126)
        Me.txtPrimerNombre.Name = "txtPrimerNombre"
        Me.txtPrimerNombre.NombreCampoBuscado = Nothing
        Me.txtPrimerNombre.NombreCampoBusqueda = Nothing
        Me.txtPrimerNombre.NombreCampoDatos = Nothing
        Me.txtPrimerNombre.Obligatorio = False
        Me.txtPrimerNombre.OrigenDeDatos = Nothing
        Me.txtPrimerNombre.PermitirValorCero = False
        Me.txtPrimerNombre.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtPrimerNombre.Size = New System.Drawing.Size(199, 21)
        Me.txtPrimerNombre.TabIndex = 67
        Me.txtPrimerNombre.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtPrimerNombre.UserValues = Nothing
        Me.txtPrimerNombre.ValorMaximo = CType(0, Long)
        Me.txtPrimerNombre.ValorMinimo = CType(0, Long)
        '
        'Ano
        '
        Me.Ano.DataPropertyName = "Ano"
        Me.Ano.HeaderText = "Año"
        Me.Ano.Name = "Ano"
        Me.Ano.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Ano.Width = 42
        '
        'Fecha
        '
        Me.Fecha.DataPropertyName = "Fecha"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.Fecha.DefaultCellStyle = DataGridViewCellStyle4
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Width = 90
        '
        'Orden
        '
        Me.Orden.DataPropertyName = "Orden"
        Me.Orden.HeaderText = "Orden"
        Me.Orden.Name = "Orden"
        '
        'Pruebas
        '
        Me.Pruebas.DataPropertyName = "Pruebas"
        Me.Pruebas.HeaderText = "Pruebas"
        Me.Pruebas.Name = "Pruebas"
        Me.Pruebas.Width = 315
        '
        'Validado
        '
        Me.Validado.DataPropertyName = "Validado"
        Me.Validado.HeaderText = "Validado"
        Me.Validado.Name = "Validado"
        Me.Validado.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Validado.Width = 150
        '
        'Interpretacion
        '
        Me.Interpretacion.DataPropertyName = "Interpretacion"
        Me.Interpretacion.HeaderText = "Interpretación"
        Me.Interpretacion.Name = "Interpretacion"
        Me.Interpretacion.Width = 92
        '
        'Modulo
        '
        Me.Modulo.DataPropertyName = "Modulo"
        Me.Modulo.HeaderText = "Modulo"
        Me.Modulo.Name = "Modulo"
        Me.Modulo.Visible = False
        '
        'FechaOrdena
        '
        Me.FechaOrdena.DataPropertyName = "FechaOrdena"
        Me.FechaOrdena.HeaderText = "FechaOrdena"
        Me.FechaOrdena.Name = "FechaOrdena"
        Me.FechaOrdena.Visible = False
        '
        'txtDescTipoDocumento
        '
        Me.txtDescTipoDocumento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtDescTipoDocumento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtDescTipoDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescTipoDocumento.ControlComboEnlace = Nothing
        Me.txtDescTipoDocumento.ControlTextoEnlace = Nothing
        Me.txtDescTipoDocumento.DatoRelacionado = Nothing
        Me.txtDescTipoDocumento.Decimals = CType(2, Byte)
        Me.txtDescTipoDocumento.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtDescTipoDocumento.Enabled = False
        Me.txtDescTipoDocumento.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescTipoDocumento.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.txtDescTipoDocumento.Location = New System.Drawing.Point(77, 33)
        Me.txtDescTipoDocumento.MaxLength = 40
        Me.txtDescTipoDocumento.Name = "txtDescTipoDocumento"
        Me.txtDescTipoDocumento.NombreCampoBuscado = Nothing
        Me.txtDescTipoDocumento.NombreCampoBusqueda = Nothing
        Me.txtDescTipoDocumento.NombreCampoDatos = Nothing
        Me.txtDescTipoDocumento.Obligatorio = False
        Me.txtDescTipoDocumento.OrigenDeDatos = Nothing
        Me.txtDescTipoDocumento.PermitirValorCero = False
        Me.txtDescTipoDocumento.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtDescTipoDocumento.Size = New System.Drawing.Size(192, 22)
        Me.txtDescTipoDocumento.TabIndex = 87
        Me.txtDescTipoDocumento.TipoControl = HistoriaClinica.tbTipoControl.ListaAutoComplete
        Me.txtDescTipoDocumento.UserValues = Nothing
        Me.txtDescTipoDocumento.ValorMaximo = CType(0, Long)
        Me.txtDescTipoDocumento.ValorMinimo = CType(0, Long)
        '
        'txtCodigoTipoDocumento
        '
        Me.txtCodigoTipoDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoTipoDocumento.ControlComboEnlace = Nothing
        Me.txtCodigoTipoDocumento.ControlTextoEnlace = Nothing
        Me.txtCodigoTipoDocumento.DatoRelacionado = Nothing
        Me.txtCodigoTipoDocumento.Decimals = CType(2, Byte)
        Me.txtCodigoTipoDocumento.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtCodigoTipoDocumento.Enabled = False
        Me.txtCodigoTipoDocumento.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoTipoDocumento.Format = HistoriaClinica.tbFormats.AlfaNúmericoSinEspacios
        Me.txtCodigoTipoDocumento.Location = New System.Drawing.Point(8, 33)
        Me.txtCodigoTipoDocumento.MaxLength = 3
        Me.txtCodigoTipoDocumento.Name = "txtCodigoTipoDocumento"
        Me.txtCodigoTipoDocumento.NombreCampoBuscado = Nothing
        Me.txtCodigoTipoDocumento.NombreCampoBusqueda = Nothing
        Me.txtCodigoTipoDocumento.NombreCampoDatos = Nothing
        Me.txtCodigoTipoDocumento.Obligatorio = False
        Me.txtCodigoTipoDocumento.OrigenDeDatos = Nothing
        Me.txtCodigoTipoDocumento.PermitirValorCero = False
        Me.txtCodigoTipoDocumento.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtCodigoTipoDocumento.Size = New System.Drawing.Size(63, 22)
        Me.txtCodigoTipoDocumento.TabIndex = 86
        Me.txtCodigoTipoDocumento.TipoControl = HistoriaClinica.tbTipoControl.CodigoBusqueda
        Me.txtCodigoTipoDocumento.UserValues = Nothing
        Me.txtCodigoTipoDocumento.ValorMaximo = CType(0, Long)
        Me.txtCodigoTipoDocumento.ValorMinimo = CType(0, Long)
        '
        'txtNumeroDocumento
        '
        Me.txtNumeroDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeroDocumento.ControlComboEnlace = Nothing
        Me.txtNumeroDocumento.ControlTextoEnlace = Nothing
        Me.txtNumeroDocumento.DatoRelacionado = Nothing
        Me.txtNumeroDocumento.Decimals = CType(0, Byte)
        Me.txtNumeroDocumento.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtNumeroDocumento.Enabled = False
        Me.txtNumeroDocumento.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroDocumento.Format = HistoriaClinica.tbFormats.AlfaNúmericoSinEspacios
        Me.txtNumeroDocumento.Location = New System.Drawing.Point(316, 33)
        Me.txtNumeroDocumento.MaxLength = 20
        Me.txtNumeroDocumento.Name = "txtNumeroDocumento"
        Me.txtNumeroDocumento.NombreCampoBuscado = Nothing
        Me.txtNumeroDocumento.NombreCampoBusqueda = Nothing
        Me.txtNumeroDocumento.NombreCampoDatos = Nothing
        Me.txtNumeroDocumento.Obligatorio = False
        Me.txtNumeroDocumento.OrigenDeDatos = Nothing
        Me.txtNumeroDocumento.PermitirValorCero = False
        Me.txtNumeroDocumento.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtNumeroDocumento.Size = New System.Drawing.Size(180, 22)
        Me.txtNumeroDocumento.TabIndex = 88
        Me.txtNumeroDocumento.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtNumeroDocumento.UserValues = Nothing
        Me.txtNumeroDocumento.ValorMaximo = CType(0, Long)
        Me.txtNumeroDocumento.ValorMinimo = CType(0, Long)
        '
        'frmConsultaResultadosLab
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(868, 450)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frmConsultaResultadosLab"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta Historia Clinica"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvResultadoLaboratorio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSalir As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents dgvResultadoLaboratorio As DataGridView
    Friend WithEvents dtpFechaInicial As DateTimePicker
    Friend WithEvents dtpFechaFinal As DateTimePicker
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnBuscar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents txtSegundoApellido As TextBoxConFormato
    Friend WithEvents txtPrimerApellido As TextBoxConFormato
    Friend WithEvents txtSegundoNombre As TextBoxConFormato
    Friend WithEvents txtPrimerNombre As TextBoxConFormato
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents Ano As DataGridViewTextBoxColumn
    Friend WithEvents Fecha As DataGridViewTextBoxColumn
    Friend WithEvents Orden As DataGridViewTextBoxColumn
    Friend WithEvents Pruebas As DataGridViewTextBoxColumn
    Friend WithEvents Validado As DataGridViewTextBoxColumn
    Friend WithEvents Interpretacion As DataGridViewTextBoxColumn
    Friend WithEvents Modulo As DataGridViewTextBoxColumn
    Friend WithEvents FechaOrdena As DataGridViewTextBoxColumn
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtDescTipoDocumento As TextBoxConFormato
    Friend WithEvents txtCodigoTipoDocumento As TextBoxConFormato
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents txtNumeroDocumento As TextBoxConFormato
End Class
