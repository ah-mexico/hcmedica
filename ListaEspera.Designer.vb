<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaEspera
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtgLista = New System.Windows.Forms.DataGridView()
        Me.gbDatos = New System.Windows.Forms.Panel()
        Me.calLista = New System.Windows.Forms.MonthCalendar()
        Me.rbUrgencias = New System.Windows.Forms.RadioButton()
        Me.rbProAdt = New System.Windows.Forms.RadioButton()
        Me.rbPendientes = New System.Windows.Forms.RadioButton()
        Me.rbHospitalizacion = New System.Windows.Forms.RadioButton()
        Me.rbEvolucion = New System.Windows.Forms.RadioButton()
        Me.rbCE = New System.Windows.Forms.RadioButton()
        Me.rbCirugia = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pcFoto = New System.Windows.Forms.PictureBox()
        Me.cmdLista = New System.Windows.Forms.Button()
        Me.lCama = New System.Windows.Forms.Label()
        Me.lNumAdmin = New System.Windows.Forms.Label()
        Me.lNumIde = New System.Windows.Forms.Label()
        Me.ltipoIde = New System.Windows.Forms.Label()
        Me.cmdAbrirHistoria = New System.Windows.Forms.Button()
        Me.txtNumeroCama = New HistoriaClinica.TextBoxConFormato()
        Me.txtNumeroAdmision = New HistoriaClinica.TextBoxConFormato()
        Me.txtAnoAdmision = New HistoriaClinica.TextBoxConFormato()
        Me.txtTipoAdmision = New HistoriaClinica.TextBoxConFormato()
        Me.txtNumeroDocumento = New HistoriaClinica.TextBoxConFormato()
        Me.txtDescTipoDocumento = New HistoriaClinica.TextBoxConFormato()
        Me.txtCodigoTipoDocumento = New HistoriaClinica.TextBoxConFormato()
        CType(Me.dtgLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatos.SuspendLayout()
        CType(Me.pcFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.CornflowerBlue
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(206, -49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(404, 32)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Lista de Pacientes en Espera"
        '
        'dtgLista
        '
        Me.dtgLista.AllowUserToAddRows = False
        Me.dtgLista.AllowUserToDeleteRows = False
        Me.dtgLista.AllowUserToResizeColumns = False
        Me.dtgLista.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.dtgLista.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgLista.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtgLista.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgLista.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtgLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(210, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgLista.DefaultCellStyle = DataGridViewCellStyle3
        Me.dtgLista.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtgLista.GridColor = System.Drawing.Color.Gray
        Me.dtgLista.Location = New System.Drawing.Point(0, 292)
        Me.dtgLista.Name = "dtgLista"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(210, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgLista.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dtgLista.RowHeadersVisible = False
        Me.dtgLista.RowHeadersWidth = 10
        Me.dtgLista.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dtgLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgLista.Size = New System.Drawing.Size(800, 304)
        Me.dtgLista.TabIndex = 4
        '
        'gbDatos
        '
        Me.gbDatos.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.gbDatos.Controls.Add(Me.calLista)
        Me.gbDatos.Controls.Add(Me.rbUrgencias)
        Me.gbDatos.Controls.Add(Me.rbProAdt)
        Me.gbDatos.Controls.Add(Me.rbPendientes)
        Me.gbDatos.Controls.Add(Me.rbHospitalizacion)
        Me.gbDatos.Controls.Add(Me.rbEvolucion)
        Me.gbDatos.Controls.Add(Me.rbCE)
        Me.gbDatos.Controls.Add(Me.rbCirugia)
        Me.gbDatos.Controls.Add(Me.Label1)
        Me.gbDatos.Controls.Add(Me.pcFoto)
        Me.gbDatos.Controls.Add(Me.cmdLista)
        Me.gbDatos.Controls.Add(Me.txtNumeroCama)
        Me.gbDatos.Controls.Add(Me.txtNumeroAdmision)
        Me.gbDatos.Controls.Add(Me.txtAnoAdmision)
        Me.gbDatos.Controls.Add(Me.txtTipoAdmision)
        Me.gbDatos.Controls.Add(Me.txtNumeroDocumento)
        Me.gbDatos.Controls.Add(Me.txtDescTipoDocumento)
        Me.gbDatos.Controls.Add(Me.txtCodigoTipoDocumento)
        Me.gbDatos.Controls.Add(Me.lCama)
        Me.gbDatos.Controls.Add(Me.lNumAdmin)
        Me.gbDatos.Controls.Add(Me.lNumIde)
        Me.gbDatos.Controls.Add(Me.ltipoIde)
        Me.gbDatos.Location = New System.Drawing.Point(0, 0)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(830, 289)
        Me.gbDatos.TabIndex = 6
        '
        'calLista
        '
        Me.calLista.BackColor = System.Drawing.Color.White
        Me.calLista.Enabled = False
        Me.calLista.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.calLista.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.calLista.Location = New System.Drawing.Point(568, 12)
        Me.calLista.MaxSelectionCount = 1
        Me.calLista.Name = "calLista"
        Me.calLista.ShowTodayCircle = False
        Me.calLista.TabIndex = 36
        Me.calLista.TitleBackColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        '
        'rbUrgencias
        '
        Me.rbUrgencias.AutoSize = True
        Me.rbUrgencias.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Bold)
        Me.rbUrgencias.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.rbUrgencias.Location = New System.Drawing.Point(30, 38)
        Me.rbUrgencias.Name = "rbUrgencias"
        Me.rbUrgencias.Size = New System.Drawing.Size(98, 20)
        Me.rbUrgencias.TabIndex = 35
        Me.rbUrgencias.TabStop = True
        Me.rbUrgencias.Text = "Urgencias"
        Me.rbUrgencias.UseVisualStyleBackColor = True
        '
        'rbProAdt
        '
        Me.rbProAdt.AutoSize = True
        Me.rbProAdt.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Bold)
        Me.rbProAdt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.rbProAdt.Location = New System.Drawing.Point(203, 64)
        Me.rbProAdt.Name = "rbProAdt"
        Me.rbProAdt.Size = New System.Drawing.Size(139, 20)
        Me.rbProAdt.TabIndex = 41
        Me.rbProAdt.TabStop = True
        Me.rbProAdt.Text = "Procedimientos"
        Me.rbProAdt.UseVisualStyleBackColor = True
        '
        'rbPendientes
        '
        Me.rbPendientes.AutoSize = True
        Me.rbPendientes.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Bold)
        Me.rbPendientes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.rbPendientes.Location = New System.Drawing.Point(369, 64)
        Me.rbPendientes.Name = "rbPendientes"
        Me.rbPendientes.Size = New System.Drawing.Size(107, 20)
        Me.rbPendientes.TabIndex = 42
        Me.rbPendientes.TabStop = True
        Me.rbPendientes.Text = "Pendientes"
        Me.rbPendientes.UseVisualStyleBackColor = True
        '
        'rbHospitalizacion
        '
        Me.rbHospitalizacion.AutoSize = True
        Me.rbHospitalizacion.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Bold)
        Me.rbHospitalizacion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.rbHospitalizacion.Location = New System.Drawing.Point(251, 38)
        Me.rbHospitalizacion.Name = "rbHospitalizacion"
        Me.rbHospitalizacion.Size = New System.Drawing.Size(137, 20)
        Me.rbHospitalizacion.TabIndex = 38
        Me.rbHospitalizacion.TabStop = True
        Me.rbHospitalizacion.Text = "Hospitalización"
        Me.rbHospitalizacion.UseVisualStyleBackColor = True
        '
        'rbEvolucion
        '
        Me.rbEvolucion.AutoSize = True
        Me.rbEvolucion.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Bold)
        Me.rbEvolucion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.rbEvolucion.Location = New System.Drawing.Point(413, 38)
        Me.rbEvolucion.Name = "rbEvolucion"
        Me.rbEvolucion.Size = New System.Drawing.Size(96, 20)
        Me.rbEvolucion.TabIndex = 39
        Me.rbEvolucion.TabStop = True
        Me.rbEvolucion.Text = "Evolución"
        Me.rbEvolucion.UseVisualStyleBackColor = True
        '
        'rbCE
        '
        Me.rbCE.AutoSize = True
        Me.rbCE.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Bold)
        Me.rbCE.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.rbCE.Location = New System.Drawing.Point(30, 64)
        Me.rbCE.Name = "rbCE"
        Me.rbCE.Size = New System.Drawing.Size(151, 20)
        Me.rbCE.TabIndex = 40
        Me.rbCE.TabStop = True
        Me.rbCE.Text = "Consulta Externa"
        Me.rbCE.UseVisualStyleBackColor = True
        '
        'rbCirugia
        '
        Me.rbCirugia.AutoSize = True
        Me.rbCirugia.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Bold)
        Me.rbCirugia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.rbCirugia.Location = New System.Drawing.Point(147, 38)
        Me.rbCirugia.Name = "rbCirugia"
        Me.rbCirugia.Size = New System.Drawing.Size(77, 20)
        Me.rbCirugia.TabIndex = 37
        Me.rbCirugia.TabStop = True
        Me.rbCirugia.Text = "Cirugía"
        Me.rbCirugia.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(9, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(260, 15)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Seleccionar Pacientes por"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pcFoto
        '
        Me.pcFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pcFoto.Location = New System.Drawing.Point(437, 150)
        Me.pcFoto.Name = "pcFoto"
        Me.pcFoto.Size = New System.Drawing.Size(110, 115)
        Me.pcFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcFoto.TabIndex = 33
        Me.pcFoto.TabStop = False
        Me.pcFoto.Visible = False
        '
        'cmdLista
        '
        Me.cmdLista.BackColor = System.Drawing.Color.Transparent
        Me.cmdLista.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_buscar
        Me.cmdLista.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdLista.Enabled = False
        Me.cmdLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdLista.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLista.ForeColor = System.Drawing.Color.Transparent
        Me.cmdLista.Location = New System.Drawing.Point(319, 209)
        Me.cmdLista.Name = "cmdLista"
        Me.cmdLista.Size = New System.Drawing.Size(68, 30)
        Me.cmdLista.TabIndex = 27
        Me.cmdLista.UseVisualStyleBackColor = False
        '
        'lCama
        '
        Me.lCama.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lCama.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lCama.Location = New System.Drawing.Point(22, 210)
        Me.lCama.Name = "lCama"
        Me.lCama.Size = New System.Drawing.Size(126, 19)
        Me.lCama.TabIndex = 32
        Me.lCama.Text = "Número de cama"
        Me.lCama.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lNumAdmin
        '
        Me.lNumAdmin.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lNumAdmin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lNumAdmin.Location = New System.Drawing.Point(22, 181)
        Me.lNumAdmin.Name = "lNumAdmin"
        Me.lNumAdmin.Size = New System.Drawing.Size(126, 19)
        Me.lNumAdmin.TabIndex = 31
        Me.lNumAdmin.Text = "Admisión"
        Me.lNumAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lNumIde
        '
        Me.lNumIde.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lNumIde.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lNumIde.Location = New System.Drawing.Point(22, 151)
        Me.lNumIde.Name = "lNumIde"
        Me.lNumIde.Size = New System.Drawing.Size(220, 19)
        Me.lNumIde.TabIndex = 30
        Me.lNumIde.Text = "Número de documento"
        Me.lNumIde.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ltipoIde
        '
        Me.ltipoIde.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ltipoIde.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.ltipoIde.Location = New System.Drawing.Point(22, 121)
        Me.ltipoIde.Name = "ltipoIde"
        Me.ltipoIde.Size = New System.Drawing.Size(220, 21)
        Me.ltipoIde.TabIndex = 29
        Me.ltipoIde.Text = "Tipo de documento"
        Me.ltipoIde.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdAbrirHistoria
        '
        Me.cmdAbrirHistoria.BackColor = System.Drawing.Color.Transparent
        Me.cmdAbrirHistoria.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_abrir_historia
        Me.cmdAbrirHistoria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdAbrirHistoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdAbrirHistoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAbrirHistoria.ForeColor = System.Drawing.Color.Transparent
        Me.cmdAbrirHistoria.Location = New System.Drawing.Point(660, 604)
        Me.cmdAbrirHistoria.Name = "cmdAbrirHistoria"
        Me.cmdAbrirHistoria.Size = New System.Drawing.Size(140, 30)
        Me.cmdAbrirHistoria.TabIndex = 5
        Me.cmdAbrirHistoria.UseVisualStyleBackColor = False
        '
        'txtNumeroCama
        '
        Me.txtNumeroCama.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeroCama.ControlComboEnlace = Nothing
        Me.txtNumeroCama.ControlTextoEnlace = Nothing
        Me.txtNumeroCama.DatoRelacionado = Nothing
        Me.txtNumeroCama.Decimals = CType(2, Byte)
        Me.txtNumeroCama.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtNumeroCama.Enabled = False
        Me.txtNumeroCama.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroCama.Format = HistoriaClinica.tbFormats.AlfaNúmericoSinEspacios
        Me.txtNumeroCama.Location = New System.Drawing.Point(203, 209)
        Me.txtNumeroCama.MaxLength = 5
        Me.txtNumeroCama.Name = "txtNumeroCama"
        Me.txtNumeroCama.NombreCampoBuscado = Nothing
        Me.txtNumeroCama.NombreCampoBusqueda = Nothing
        Me.txtNumeroCama.NombreCampoDatos = Nothing
        Me.txtNumeroCama.Obligatorio = False
        Me.txtNumeroCama.OrigenDeDatos = Nothing
        Me.txtNumeroCama.PermitirValorCero = False
        Me.txtNumeroCama.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtNumeroCama.Size = New System.Drawing.Size(105, 22)
        Me.txtNumeroCama.TabIndex = 28
        Me.txtNumeroCama.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtNumeroCama.UserValues = Nothing
        Me.txtNumeroCama.ValorMaximo = CType(0, Long)
        Me.txtNumeroCama.ValorMinimo = CType(0, Long)
        '
        'txtNumeroAdmision
        '
        Me.txtNumeroAdmision.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeroAdmision.ControlComboEnlace = Nothing
        Me.txtNumeroAdmision.ControlTextoEnlace = Nothing
        Me.txtNumeroAdmision.DatoRelacionado = Nothing
        Me.txtNumeroAdmision.Decimals = CType(2, Byte)
        Me.txtNumeroAdmision.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtNumeroAdmision.Enabled = False
        Me.txtNumeroAdmision.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroAdmision.Format = HistoriaClinica.tbFormats.NúmericoEnteroSinSigno
        Me.txtNumeroAdmision.Location = New System.Drawing.Point(319, 179)
        Me.txtNumeroAdmision.MaxLength = 9
        Me.txtNumeroAdmision.Name = "txtNumeroAdmision"
        Me.txtNumeroAdmision.NombreCampoBuscado = Nothing
        Me.txtNumeroAdmision.NombreCampoBusqueda = Nothing
        Me.txtNumeroAdmision.NombreCampoDatos = Nothing
        Me.txtNumeroAdmision.Obligatorio = False
        Me.txtNumeroAdmision.OrigenDeDatos = Nothing
        Me.txtNumeroAdmision.PermitirValorCero = False
        Me.txtNumeroAdmision.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtNumeroAdmision.Size = New System.Drawing.Size(75, 22)
        Me.txtNumeroAdmision.TabIndex = 26
        Me.txtNumeroAdmision.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtNumeroAdmision.UserValues = Nothing
        Me.txtNumeroAdmision.ValorMaximo = CType(0, Long)
        Me.txtNumeroAdmision.ValorMinimo = CType(0, Long)
        '
        'txtAnoAdmision
        '
        Me.txtAnoAdmision.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAnoAdmision.ControlComboEnlace = Nothing
        Me.txtAnoAdmision.ControlTextoEnlace = Nothing
        Me.txtAnoAdmision.DatoRelacionado = Nothing
        Me.txtAnoAdmision.Decimals = CType(2, Byte)
        Me.txtAnoAdmision.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtAnoAdmision.Enabled = False
        Me.txtAnoAdmision.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnoAdmision.Format = HistoriaClinica.tbFormats.NúmericoEnteroSinSigno
        Me.txtAnoAdmision.Location = New System.Drawing.Point(259, 179)
        Me.txtAnoAdmision.MaxLength = 4
        Me.txtAnoAdmision.Name = "txtAnoAdmision"
        Me.txtAnoAdmision.NombreCampoBuscado = Nothing
        Me.txtAnoAdmision.NombreCampoBusqueda = Nothing
        Me.txtAnoAdmision.NombreCampoDatos = Nothing
        Me.txtAnoAdmision.Obligatorio = False
        Me.txtAnoAdmision.OrigenDeDatos = Nothing
        Me.txtAnoAdmision.PermitirValorCero = False
        Me.txtAnoAdmision.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtAnoAdmision.Size = New System.Drawing.Size(54, 22)
        Me.txtAnoAdmision.TabIndex = 25
        Me.txtAnoAdmision.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtAnoAdmision.UserValues = Nothing
        Me.txtAnoAdmision.ValorMaximo = CType(9999, Long)
        Me.txtAnoAdmision.ValorMinimo = CType(1753, Long)
        '
        'txtTipoAdmision
        '
        Me.txtTipoAdmision.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTipoAdmision.ControlComboEnlace = Nothing
        Me.txtTipoAdmision.ControlTextoEnlace = Nothing
        Me.txtTipoAdmision.DatoRelacionado = Nothing
        Me.txtTipoAdmision.Decimals = CType(2, Byte)
        Me.txtTipoAdmision.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtTipoAdmision.Enabled = False
        Me.txtTipoAdmision.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoAdmision.Format = HistoriaClinica.tbFormats.AlfabéticoSinEspacios
        Me.txtTipoAdmision.Location = New System.Drawing.Point(203, 179)
        Me.txtTipoAdmision.MaxLength = 2
        Me.txtTipoAdmision.Name = "txtTipoAdmision"
        Me.txtTipoAdmision.NombreCampoBuscado = Nothing
        Me.txtTipoAdmision.NombreCampoBusqueda = Nothing
        Me.txtTipoAdmision.NombreCampoDatos = Nothing
        Me.txtTipoAdmision.Obligatorio = False
        Me.txtTipoAdmision.OrigenDeDatos = Nothing
        Me.txtTipoAdmision.PermitirValorCero = False
        Me.txtTipoAdmision.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtTipoAdmision.Size = New System.Drawing.Size(50, 22)
        Me.txtTipoAdmision.TabIndex = 24
        Me.txtTipoAdmision.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtTipoAdmision.UserValues = Nothing
        Me.txtTipoAdmision.ValorMaximo = CType(0, Long)
        Me.txtTipoAdmision.ValorMinimo = CType(0, Long)
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
        Me.txtNumeroDocumento.Location = New System.Drawing.Point(203, 149)
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
        Me.txtNumeroDocumento.TabIndex = 23
        Me.txtNumeroDocumento.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtNumeroDocumento.UserValues = Nothing
        Me.txtNumeroDocumento.ValorMaximo = CType(0, Long)
        Me.txtNumeroDocumento.ValorMinimo = CType(0, Long)
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
        Me.txtDescTipoDocumento.Location = New System.Drawing.Point(281, 120)
        Me.txtDescTipoDocumento.MaxLength = 40
        Me.txtDescTipoDocumento.Name = "txtDescTipoDocumento"
        Me.txtDescTipoDocumento.NombreCampoBuscado = Nothing
        Me.txtDescTipoDocumento.NombreCampoBusqueda = Nothing
        Me.txtDescTipoDocumento.NombreCampoDatos = Nothing
        Me.txtDescTipoDocumento.Obligatorio = False
        Me.txtDescTipoDocumento.OrigenDeDatos = Nothing
        Me.txtDescTipoDocumento.PermitirValorCero = False
        Me.txtDescTipoDocumento.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtDescTipoDocumento.Size = New System.Drawing.Size(275, 22)
        Me.txtDescTipoDocumento.TabIndex = 22
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
        Me.txtCodigoTipoDocumento.Location = New System.Drawing.Point(203, 120)
        Me.txtCodigoTipoDocumento.MaxLength = 3
        Me.txtCodigoTipoDocumento.Name = "txtCodigoTipoDocumento"
        Me.txtCodigoTipoDocumento.NombreCampoBuscado = Nothing
        Me.txtCodigoTipoDocumento.NombreCampoBusqueda = Nothing
        Me.txtCodigoTipoDocumento.NombreCampoDatos = Nothing
        Me.txtCodigoTipoDocumento.Obligatorio = False
        Me.txtCodigoTipoDocumento.OrigenDeDatos = Nothing
        Me.txtCodigoTipoDocumento.PermitirValorCero = False
        Me.txtCodigoTipoDocumento.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtCodigoTipoDocumento.Size = New System.Drawing.Size(72, 22)
        Me.txtCodigoTipoDocumento.TabIndex = 21
        Me.txtCodigoTipoDocumento.TipoControl = HistoriaClinica.tbTipoControl.CodigoBusqueda
        Me.txtCodigoTipoDocumento.UserValues = Nothing
        Me.txtCodigoTipoDocumento.ValorMaximo = CType(0, Long)
        Me.txtCodigoTipoDocumento.ValorMinimo = CType(0, Long)
        '
        'ListaEspera
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.gbDatos)
        Me.Controls.Add(Me.cmdAbrirHistoria)
        Me.Controls.Add(Me.dtgLista)
        Me.Controls.Add(Me.Label2)
        Me.DoubleBuffered = True
        Me.Name = "ListaEspera"
        Me.Size = New System.Drawing.Size(860, 634)
        CType(Me.dtgLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        CType(Me.pcFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtgLista As System.Windows.Forms.DataGridView
    Friend WithEvents cmdAbrirHistoria As System.Windows.Forms.Button
    Friend WithEvents gbDatos As System.Windows.Forms.Panel
    Friend WithEvents pcFoto As System.Windows.Forms.PictureBox
    Friend WithEvents cmdLista As System.Windows.Forms.Button
    Friend WithEvents txtNumeroCama As HistoriaClinica.TextBoxConFormato
    Friend WithEvents txtNumeroAdmision As HistoriaClinica.TextBoxConFormato
    Friend WithEvents txtAnoAdmision As HistoriaClinica.TextBoxConFormato
    Friend WithEvents txtTipoAdmision As HistoriaClinica.TextBoxConFormato
    Friend WithEvents txtNumeroDocumento As HistoriaClinica.TextBoxConFormato
    Friend WithEvents txtDescTipoDocumento As HistoriaClinica.TextBoxConFormato
    Friend WithEvents txtCodigoTipoDocumento As HistoriaClinica.TextBoxConFormato
    Friend WithEvents lCama As System.Windows.Forms.Label
    Friend WithEvents lNumAdmin As System.Windows.Forms.Label
    Friend WithEvents lNumIde As System.Windows.Forms.Label
    Friend WithEvents ltipoIde As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents calLista As System.Windows.Forms.MonthCalendar
    Friend WithEvents rbUrgencias As System.Windows.Forms.RadioButton
    Friend WithEvents rbProAdt As System.Windows.Forms.RadioButton
    Friend WithEvents rbPendientes As System.Windows.Forms.RadioButton
    Friend WithEvents rbHospitalizacion As System.Windows.Forms.RadioButton
    Friend WithEvents rbEvolucion As System.Windows.Forms.RadioButton
    Friend WithEvents rbCE As System.Windows.Forms.RadioButton
    Friend WithEvents rbCirugia As System.Windows.Forms.RadioButton

End Class
