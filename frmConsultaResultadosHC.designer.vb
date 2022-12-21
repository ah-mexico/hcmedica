<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaResultadosHC
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.grpFiltro = New System.Windows.Forms.GroupBox
        Me.chkFechas = New System.Windows.Forms.CheckBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.mskFechaHasta = New System.Windows.Forms.MaskedTextBox
        Me.mskFechaDesde = New System.Windows.Forms.MaskedTextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.dtgAdmisiones = New System.Windows.Forms.DataGridView
        Me.tip_admision = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ano_adm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.num_adm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fec_hc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Especialidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.medico = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.estado_salida = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnTraer = New System.Windows.Forms.Button
        Me.btnSalir = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.txtTipExamen = New HistoriaClinica.TextBoxConFormato
        Me.txtDescTipoExamen = New HistoriaClinica.TextBoxConFormato
        Me.txtSegundoApellido = New HistoriaClinica.TextBoxConFormato
        Me.txtPrimerApellido = New HistoriaClinica.TextBoxConFormato
        Me.txtSegundoNombre = New HistoriaClinica.TextBoxConFormato
        Me.txtPrimerNombre = New HistoriaClinica.TextBoxConFormato
        Me.txtNumDoc = New HistoriaClinica.TextBoxConFormato
        Me.tbCodigoTipDoc = New HistoriaClinica.TextBoxConFormato
        Me.tbDescTipDoc = New HistoriaClinica.TextBoxConFormato
        Me.GroupBox2.SuspendLayout()
        Me.grpFiltro.SuspendLayout()
        CType(Me.dtgAdmisiones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
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
        Me.GroupBox2.Location = New System.Drawing.Point(9, 11)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(850, 124)
        Me.GroupBox2.TabIndex = 42
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos del Paciente"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(611, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Segundo Apellido"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(411, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Primer Apellido"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(210, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Segundo Nombre"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Primer Nombre"
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscar.Location = New System.Drawing.Point(555, 38)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(101, 20)
        Me.btnBuscar.TabIndex = 4
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(301, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Número Documento"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tipo Documento"
        '
        'grpFiltro
        '
        Me.grpFiltro.Controls.Add(Me.btnSalir)
        Me.grpFiltro.Controls.Add(Me.btnCancelar)
        Me.grpFiltro.Controls.Add(Me.btnImprimir)
        Me.grpFiltro.Controls.Add(Me.txtTipExamen)
        Me.grpFiltro.Controls.Add(Me.txtDescTipoExamen)
        Me.grpFiltro.Controls.Add(Me.Label11)
        Me.grpFiltro.Controls.Add(Me.dtgAdmisiones)
        Me.grpFiltro.Controls.Add(Me.btnTraer)
        Me.grpFiltro.Controls.Add(Me.chkFechas)
        Me.grpFiltro.Controls.Add(Me.Label10)
        Me.grpFiltro.Controls.Add(Me.Label9)
        Me.grpFiltro.Controls.Add(Me.Label8)
        Me.grpFiltro.Controls.Add(Me.Label7)
        Me.grpFiltro.Controls.Add(Me.mskFechaHasta)
        Me.grpFiltro.Controls.Add(Me.mskFechaDesde)
        Me.grpFiltro.Location = New System.Drawing.Point(9, 141)
        Me.grpFiltro.Name = "grpFiltro"
        Me.grpFiltro.Size = New System.Drawing.Size(850, 330)
        Me.grpFiltro.TabIndex = 62
        Me.grpFiltro.TabStop = False
        '
        'chkFechas
        '
        Me.chkFechas.AutoSize = True
        Me.chkFechas.Location = New System.Drawing.Point(58, 26)
        Me.chkFechas.Name = "chkFechas"
        Me.chkFechas.Size = New System.Drawing.Size(123, 17)
        Me.chkFechas.TabIndex = 66
        Me.chkFechas.Text = "Rango de Fechas"
        Me.chkFechas.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(594, 27)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 13)
        Me.Label10.TabIndex = 64
        Me.Label10.Text = "dd/mm/aaaa"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(350, 27)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 13)
        Me.Label9.TabIndex = 62
        Me.Label9.Text = "dd/mm/aaaa"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(449, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 13)
        Me.Label8.TabIndex = 61
        Me.Label8.Text = "Hasta"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(201, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 60
        Me.Label7.Text = "Desde"
        '
        'mskFechaHasta
        '
        Me.mskFechaHasta.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskFechaHasta.Location = New System.Drawing.Point(496, 24)
        Me.mskFechaHasta.Mask = "00/00/0000"
        Me.mskFechaHasta.Name = "mskFechaHasta"
        Me.mskFechaHasta.Size = New System.Drawing.Size(90, 21)
        Me.mskFechaHasta.TabIndex = 65
        Me.mskFechaHasta.ValidatingType = GetType(Date)
        '
        'mskFechaDesde
        '
        Me.mskFechaDesde.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskFechaDesde.Location = New System.Drawing.Point(252, 24)
        Me.mskFechaDesde.Mask = "00/00/0000"
        Me.mskFechaDesde.Name = "mskFechaDesde"
        Me.mskFechaDesde.Size = New System.Drawing.Size(90, 21)
        Me.mskFechaDesde.TabIndex = 63
        Me.mskFechaDesde.ValidatingType = GetType(Date)
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(55, 68)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 13)
        Me.Label11.TabIndex = 69
        Me.Label11.Text = "Tipo Exámen"
        '
        'dtgAdmisiones
        '
        Me.dtgAdmisiones.AllowUserToAddRows = False
        Me.dtgAdmisiones.AllowUserToDeleteRows = False
        Me.dtgAdmisiones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgAdmisiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgAdmisiones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tip_admision, Me.ano_adm, Me.num_adm, Me.fec_hc, Me.Especialidad, Me.medico, Me.estado_salida})
        Me.dtgAdmisiones.Location = New System.Drawing.Point(3, 98)
        Me.dtgAdmisiones.Name = "dtgAdmisiones"
        Me.dtgAdmisiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgAdmisiones.Size = New System.Drawing.Size(838, 183)
        Me.dtgAdmisiones.TabIndex = 68
        '
        'tip_admision
        '
        Me.tip_admision.DataPropertyName = "tip_admision"
        Me.tip_admision.HeaderText = "Tipo Admisión"
        Me.tip_admision.Name = "tip_admision"
        '
        'ano_adm
        '
        Me.ano_adm.DataPropertyName = "ano_adm"
        Me.ano_adm.HeaderText = "Año"
        Me.ano_adm.Name = "ano_adm"
        '
        'num_adm
        '
        Me.num_adm.DataPropertyName = "num_adm"
        Me.num_adm.HeaderText = "Número"
        Me.num_adm.Name = "num_adm"
        '
        'fec_hc
        '
        Me.fec_hc.DataPropertyName = "fec_hc"
        Me.fec_hc.HeaderText = "Fecha Historia"
        Me.fec_hc.Name = "fec_hc"
        '
        'Especialidad
        '
        Me.Especialidad.DataPropertyName = "Especialidad"
        Me.Especialidad.HeaderText = "Especialidad"
        Me.Especialidad.Name = "Especialidad"
        '
        'medico
        '
        Me.medico.DataPropertyName = "medico"
        Me.medico.HeaderText = "Médico"
        Me.medico.Name = "medico"
        '
        'estado_salida
        '
        Me.estado_salida.DataPropertyName = "estado_salida"
        Me.estado_salida.HeaderText = "Estado"
        Me.estado_salida.Name = "estado_salida"
        '
        'btnTraer
        '
        Me.btnTraer.BackColor = System.Drawing.SystemColors.Control
        Me.btnTraer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTraer.Location = New System.Drawing.Point(496, 61)
        Me.btnTraer.Name = "btnTraer"
        Me.btnTraer.Size = New System.Drawing.Size(124, 20)
        Me.btnTraer.TabIndex = 67
        Me.btnTraer.Text = "Traer Resultados"
        Me.btnTraer.UseVisualStyleBackColor = False
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.SystemColors.Control
        Me.btnSalir.Location = New System.Drawing.Point(707, 298)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(104, 26)
        Me.btnSalir.TabIndex = 74
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.Location = New System.Drawing.Point(597, 298)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(104, 26)
        Me.btnCancelar.TabIndex = 73
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnImprimir
        '
        Me.btnImprimir.BackColor = System.Drawing.SystemColors.Control
        Me.btnImprimir.Location = New System.Drawing.Point(487, 298)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(104, 26)
        Me.btnImprimir.TabIndex = 72
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'txtTipExamen
        '
        Me.txtTipExamen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTipExamen.ControlComboEnlace = Nothing
        Me.txtTipExamen.ControlTextoEnlace = Me.txtTipExamen
        Me.txtTipExamen.DatoRelacionado = Nothing
        Me.txtTipExamen.Decimals = CType(0, Byte)
        Me.txtTipExamen.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtTipExamen.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipExamen.Format = HistoriaClinica.tbFormats.NúmericoEnteroSinSigno
        Me.txtTipExamen.Location = New System.Drawing.Point(142, 62)
        Me.txtTipExamen.MaxLength = 3
        Me.txtTipExamen.Name = "txtTipExamen"
        Me.txtTipExamen.NombreCampoBuscado = Nothing
        Me.txtTipExamen.NombreCampoBusqueda = Nothing
        Me.txtTipExamen.NombreCampoDatos = Nothing
        Me.txtTipExamen.Obligatorio = False
        Me.txtTipExamen.OrigenDeDatos = Nothing
        Me.txtTipExamen.Size = New System.Drawing.Size(40, 21)
        Me.txtTipExamen.TabIndex = 70
        Me.txtTipExamen.TipoControl = HistoriaClinica.tbTipoControl.CodigoBusqueda
        Me.txtTipExamen.UserValues = Nothing
        Me.txtTipExamen.ValorMaximo = CType(0, Long)
        Me.txtTipExamen.ValorMinimo = CType(0, Long)
        '
        'txtDescTipoExamen
        '
        Me.txtDescTipoExamen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtDescTipoExamen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtDescTipoExamen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescTipoExamen.ControlComboEnlace = Nothing
        Me.txtDescTipoExamen.ControlTextoEnlace = Me.txtDescTipoExamen
        Me.txtDescTipoExamen.DatoRelacionado = Nothing
        Me.txtDescTipoExamen.Decimals = CType(0, Byte)
        Me.txtDescTipoExamen.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtDescTipoExamen.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescTipoExamen.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.txtDescTipoExamen.Location = New System.Drawing.Point(184, 62)
        Me.txtDescTipoExamen.MaxLength = 50
        Me.txtDescTipoExamen.Name = "txtDescTipoExamen"
        Me.txtDescTipoExamen.NombreCampoBuscado = Nothing
        Me.txtDescTipoExamen.NombreCampoBusqueda = Nothing
        Me.txtDescTipoExamen.NombreCampoDatos = Nothing
        Me.txtDescTipoExamen.Obligatorio = False
        Me.txtDescTipoExamen.OrigenDeDatos = Nothing
        Me.txtDescTipoExamen.Size = New System.Drawing.Size(247, 21)
        Me.txtDescTipoExamen.TabIndex = 71
        Me.txtDescTipoExamen.TipoControl = HistoriaClinica.tbTipoControl.ListaAutoComplete
        Me.txtDescTipoExamen.UserValues = Nothing
        Me.txtDescTipoExamen.ValorMaximo = CType(0, Long)
        Me.txtDescTipoExamen.ValorMinimo = CType(0, Long)
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
        Me.txtSegundoApellido.Size = New System.Drawing.Size(200, 22)
        Me.txtSegundoApellido.TabIndex = 8
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
        Me.txtPrimerApellido.Size = New System.Drawing.Size(200, 22)
        Me.txtPrimerApellido.TabIndex = 7
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
        Me.txtSegundoNombre.Size = New System.Drawing.Size(200, 22)
        Me.txtSegundoNombre.TabIndex = 6
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
        Me.txtPrimerNombre.Size = New System.Drawing.Size(199, 22)
        Me.txtPrimerNombre.TabIndex = 5
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
        Me.txtNumDoc.Size = New System.Drawing.Size(244, 22)
        Me.txtNumDoc.TabIndex = 3
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
        Me.tbCodigoTipDoc.Format = HistoriaClinica.tbFormats.AlfabéticoSinEspacios
        Me.tbCodigoTipDoc.Location = New System.Drawing.Point(13, 38)
        Me.tbCodigoTipDoc.MaxLength = 3
        Me.tbCodigoTipDoc.Name = "tbCodigoTipDoc"
        Me.tbCodigoTipDoc.NombreCampoBuscado = Nothing
        Me.tbCodigoTipDoc.NombreCampoBusqueda = Nothing
        Me.tbCodigoTipDoc.NombreCampoDatos = Nothing
        Me.tbCodigoTipDoc.Obligatorio = False
        Me.tbCodigoTipDoc.OrigenDeDatos = Nothing
        Me.tbCodigoTipDoc.Size = New System.Drawing.Size(40, 21)
        Me.tbCodigoTipDoc.TabIndex = 1
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
        Me.tbDescTipDoc.Size = New System.Drawing.Size(247, 21)
        Me.tbDescTipDoc.TabIndex = 2
        Me.tbDescTipDoc.TipoControl = HistoriaClinica.tbTipoControl.ListaAutoComplete
        Me.tbDescTipDoc.UserValues = Nothing
        Me.tbDescTipDoc.ValorMaximo = CType(0, Long)
        Me.tbDescTipDoc.ValorMinimo = CType(0, Long)
        '
        'frmConsultaResultadosHC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(868, 483)
        Me.Controls.Add(Me.grpFiltro)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "frmConsultaResultadosHC"
        Me.Text = "Consulta Historia Clinica - Resultados"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.grpFiltro.ResumeLayout(False)
        Me.grpFiltro.PerformLayout()
        CType(Me.dtgAdmisiones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
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
    Friend WithEvents grpFiltro As System.Windows.Forms.GroupBox
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents txtTipExamen As HistoriaClinica.TextBoxConFormato
    Friend WithEvents txtDescTipoExamen As HistoriaClinica.TextBoxConFormato
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtgAdmisiones As System.Windows.Forms.DataGridView
    Friend WithEvents tip_admision As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ano_adm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents num_adm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fec_hc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Especialidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents medico As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents estado_salida As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnTraer As System.Windows.Forms.Button
    Friend WithEvents chkFechas As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents mskFechaHasta As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mskFechaDesde As System.Windows.Forms.MaskedTextBox
End Class
