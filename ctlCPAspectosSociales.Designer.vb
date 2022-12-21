<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlCPAspectosSociales
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctlCPAspectosSociales))
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbOcupacionCuidador = New System.Windows.Forms.ComboBox()
        Me.txtPlanIntervencion = New HistoriaClinica.TextBoxConFormato()
        Me.lblPlanIntervencion = New System.Windows.Forms.Label()
        Me.txtProblemasIdentificados = New HistoriaClinica.TextBoxConFormato()
        Me.lblProblemas = New System.Windows.Forms.Label()
        Me.cmbEstadoCivil = New System.Windows.Forms.ComboBox()
        Me.lblEstadoCivil = New System.Windows.Forms.Label()
        Me.txtDireccionCuidador = New HistoriaClinica.TextBoxConFormato()
        Me.lblDireccionCuidador = New System.Windows.Forms.Label()
        Me.cmbNivEduCuidador = New System.Windows.Forms.ComboBox()
        Me.lblNivEduCuidador = New System.Windows.Forms.Label()
        Me.cmbParentescoCuidador = New System.Windows.Forms.ComboBox()
        Me.lblParentescoCuidador = New System.Windows.Forms.Label()
        Me.txtDocumento = New HistoriaClinica.TextBoxConFormato()
        Me.lblDocumento = New System.Windows.Forms.Label()
        Me.cmbTipodocumento = New System.Windows.Forms.ComboBox()
        Me.lblTipodocumento = New System.Windows.Forms.Label()
        Me.txtNombreCuidador = New HistoriaClinica.TextBoxConFormato()
        Me.lblNombreCuidador = New System.Windows.Forms.Label()
        Me.txtOcupacionCuidador = New HistoriaClinica.TextBoxConFormato()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.grbFamilia = New System.Windows.Forms.GroupBox()
        Me.dtgFamiliar = New System.Windows.Forms.DataGridView()
        Me.IdPariente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tip_doc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Num_doc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreDelIntegranteDeLaFamilia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ParentescoDelIntegranteDeLaFamilia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dscParentescoDelIntegranteDeLaFamilia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EdadDelIntegranteDeLaFamilia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OcupacionDelIntegranteDeLaFamilia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dscOcupacionDelIntegranteDeLaFamilia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnSugerirFamiliares = New System.Windows.Forms.Button()
        Me.cmbOcupacionFam = New System.Windows.Forms.ComboBox()
        Me.txtEdadFamiliar = New HistoriaClinica.TextBoxConFormato()
        Me.lblEdad = New System.Windows.Forms.Label()
        Me.txtNombreFamiliar = New HistoriaClinica.TextBoxConFormato()
        Me.lblNombreFam = New System.Windows.Forms.Label()
        Me.cmbParentesco = New System.Windows.Forms.ComboBox()
        Me.lblParentesco = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lnkNuevo = New System.Windows.Forms.LinkLabel()
        Me.txtCodOcupacionFam = New HistoriaClinica.TextBoxConFormato()
        Me.btnAgregarFamiliar = New System.Windows.Forms.Button()
        Me.Label122 = New System.Windows.Forms.Label()
        Me.grbEntornoSocioFamiliar = New System.Windows.Forms.GroupBox()
        Me.txtLugarPaciente = New HistoriaClinica.TextBoxConFormato()
        Me.txtNumeroIntegrantes = New HistoriaClinica.TextBoxConFormato()
        Me.lblNumeroIntegrantes = New System.Windows.Forms.Label()
        Me.lblLugarPaciente = New System.Windows.Forms.Label()
        Me.txtPersonasCargo = New HistoriaClinica.TextBoxConFormato()
        Me.lblPersonasCargo = New System.Windows.Forms.Label()
        Me.cmbCondicionPadre = New System.Windows.Forms.ComboBox()
        Me.lblCondicionPadre = New System.Windows.Forms.Label()
        Me.rbtNoTieneHijos = New System.Windows.Forms.RadioButton()
        Me.rbtSiTieneHijos = New System.Windows.Forms.RadioButton()
        Me.txtNumeroHermanos = New HistoriaClinica.TextBoxConFormato()
        Me.lblNumeroHermanos = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbTipoFamilia = New System.Windows.Forms.ComboBox()
        Me.lblTipoFamilia = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbCondicionMadre = New System.Windows.Forms.ComboBox()
        Me.lblCondicionMadre = New System.Windows.Forms.Label()
        Me.grbEntorno = New System.Windows.Forms.GroupBox()
        Me.cmbOcupacion = New System.Windows.Forms.ComboBox()
        Me.rbtNoTrabajoEstable = New System.Windows.Forms.RadioButton()
        Me.rbtSiTrabajoEstable = New System.Windows.Forms.RadioButton()
        Me.txtOcupacion = New HistoriaClinica.TextBoxConFormato()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmbNivelIngresos = New System.Windows.Forms.ComboBox()
        Me.lblNivelIngresos = New System.Windows.Forms.Label()
        Me.lblEstabiliadLaboral = New System.Windows.Forms.Label()
        Me.cmbNivelEducativo = New System.Windows.Forms.ComboBox()
        Me.lblNivelEducativo = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.grbDomicilio = New System.Windows.Forms.GroupBox()
        Me.cmbEstrato = New System.Windows.Forms.ComboBox()
        Me.lblEstrato = New System.Windows.Forms.Label()
        Me.cmbTenencia = New System.Windows.Forms.ComboBox()
        Me.lblTenencia = New System.Windows.Forms.Label()
        Me.cmbTipoVivienda = New System.Windows.Forms.ComboBox()
        Me.lblTipoVivienda = New System.Windows.Forms.Label()
        Me.cmbConvivencia = New System.Windows.Forms.ComboBox()
        Me.lblConvivencia = New System.Windows.Forms.Label()
        Me.btnSugerirRespuesta = New System.Windows.Forms.Button()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel16.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grbFamilia.SuspendLayout()
        CType(Me.dtgFamiliar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbEntornoSocioFamiliar.SuspendLayout()
        Me.grbEntorno.SuspendLayout()
        Me.grbDomicilio.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel16
        '
        Me.Panel16.AutoScroll = True
        Me.Panel16.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Panel16.Controls.Add(Me.GroupBox1)
        Me.Panel16.Controls.Add(Me.grbFamilia)
        Me.Panel16.Controls.Add(Me.grbEntornoSocioFamiliar)
        Me.Panel16.Controls.Add(Me.grbEntorno)
        Me.Panel16.Controls.Add(Me.btnGuardar)
        Me.Panel16.Controls.Add(Me.Label3)
        Me.Panel16.Controls.Add(Me.grbDomicilio)
        Me.Panel16.Location = New System.Drawing.Point(1, 44)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(1096, 1162)
        Me.Panel16.TabIndex = 52
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbOcupacionCuidador)
        Me.GroupBox1.Controls.Add(Me.txtPlanIntervencion)
        Me.GroupBox1.Controls.Add(Me.lblPlanIntervencion)
        Me.GroupBox1.Controls.Add(Me.txtProblemasIdentificados)
        Me.GroupBox1.Controls.Add(Me.lblProblemas)
        Me.GroupBox1.Controls.Add(Me.cmbEstadoCivil)
        Me.GroupBox1.Controls.Add(Me.lblEstadoCivil)
        Me.GroupBox1.Controls.Add(Me.txtDireccionCuidador)
        Me.GroupBox1.Controls.Add(Me.lblDireccionCuidador)
        Me.GroupBox1.Controls.Add(Me.cmbNivEduCuidador)
        Me.GroupBox1.Controls.Add(Me.lblNivEduCuidador)
        Me.GroupBox1.Controls.Add(Me.cmbParentescoCuidador)
        Me.GroupBox1.Controls.Add(Me.lblParentescoCuidador)
        Me.GroupBox1.Controls.Add(Me.txtDocumento)
        Me.GroupBox1.Controls.Add(Me.lblDocumento)
        Me.GroupBox1.Controls.Add(Me.cmbTipodocumento)
        Me.GroupBox1.Controls.Add(Me.lblTipodocumento)
        Me.GroupBox1.Controls.Add(Me.txtNombreCuidador)
        Me.GroupBox1.Controls.Add(Me.lblNombreCuidador)
        Me.GroupBox1.Controls.Add(Me.txtOcupacionCuidador)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(4, 759)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1089, 361)
        Me.GroupBox1.TabIndex = 190
        Me.GroupBox1.TabStop = False
        '
        'cmbOcupacionCuidador
        '
        Me.cmbOcupacionCuidador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOcupacionCuidador.FormattingEnabled = True
        Me.cmbOcupacionCuidador.Location = New System.Drawing.Point(395, 170)
        Me.cmbOcupacionCuidador.Name = "cmbOcupacionCuidador"
        Me.cmbOcupacionCuidador.Size = New System.Drawing.Size(629, 22)
        Me.cmbOcupacionCuidador.TabIndex = 36
        Me.cmbOcupacionCuidador.Tag = "34"
        '
        'txtPlanIntervencion
        '
        Me.txtPlanIntervencion.ControlComboEnlace = Nothing
        Me.txtPlanIntervencion.ControlTextoEnlace = Nothing
        Me.txtPlanIntervencion.DatoRelacionado = Nothing
        Me.txtPlanIntervencion.Decimals = CType(2, Byte)
        Me.txtPlanIntervencion.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtPlanIntervencion.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlanIntervencion.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.txtPlanIntervencion.Location = New System.Drawing.Point(319, 281)
        Me.txtPlanIntervencion.MaxLength = 1500
        Me.txtPlanIntervencion.Multiline = True
        Me.txtPlanIntervencion.Name = "txtPlanIntervencion"
        Me.txtPlanIntervencion.NombreCampoBuscado = Nothing
        Me.txtPlanIntervencion.NombreCampoBusqueda = Nothing
        Me.txtPlanIntervencion.NombreCampoDatos = Nothing
        Me.txtPlanIntervencion.Obligatorio = True
        Me.txtPlanIntervencion.OrigenDeDatos = Nothing
        Me.txtPlanIntervencion.PermitirValorCero = False
        Me.txtPlanIntervencion.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtPlanIntervencion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPlanIntervencion.Size = New System.Drawing.Size(705, 64)
        Me.txtPlanIntervencion.TabIndex = 38
        Me.txtPlanIntervencion.Tag = "36"
        Me.txtPlanIntervencion.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtPlanIntervencion.UserValues = Nothing
        Me.txtPlanIntervencion.ValorMaximo = CType(0, Long)
        Me.txtPlanIntervencion.ValorMinimo = CType(0, Long)
        '
        'lblPlanIntervencion
        '
        Me.lblPlanIntervencion.BackColor = System.Drawing.Color.Transparent
        Me.lblPlanIntervencion.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlanIntervencion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblPlanIntervencion.Location = New System.Drawing.Point(116, 299)
        Me.lblPlanIntervencion.Name = "lblPlanIntervencion"
        Me.lblPlanIntervencion.Size = New System.Drawing.Size(178, 22)
        Me.lblPlanIntervencion.TabIndex = 216
        Me.lblPlanIntervencion.Text = "Plan Intervención"
        Me.lblPlanIntervencion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtProblemasIdentificados
        '
        Me.txtProblemasIdentificados.ControlComboEnlace = Nothing
        Me.txtProblemasIdentificados.ControlTextoEnlace = Nothing
        Me.txtProblemasIdentificados.DatoRelacionado = Nothing
        Me.txtProblemasIdentificados.Decimals = CType(2, Byte)
        Me.txtProblemasIdentificados.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtProblemasIdentificados.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProblemasIdentificados.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.txtProblemasIdentificados.Location = New System.Drawing.Point(319, 206)
        Me.txtProblemasIdentificados.MaxLength = 1500
        Me.txtProblemasIdentificados.Multiline = True
        Me.txtProblemasIdentificados.Name = "txtProblemasIdentificados"
        Me.txtProblemasIdentificados.NombreCampoBuscado = Nothing
        Me.txtProblemasIdentificados.NombreCampoBusqueda = Nothing
        Me.txtProblemasIdentificados.NombreCampoDatos = Nothing
        Me.txtProblemasIdentificados.Obligatorio = True
        Me.txtProblemasIdentificados.OrigenDeDatos = Nothing
        Me.txtProblemasIdentificados.PermitirValorCero = False
        Me.txtProblemasIdentificados.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtProblemasIdentificados.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtProblemasIdentificados.Size = New System.Drawing.Size(705, 64)
        Me.txtProblemasIdentificados.TabIndex = 37
        Me.txtProblemasIdentificados.Tag = "35"
        Me.txtProblemasIdentificados.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtProblemasIdentificados.UserValues = Nothing
        Me.txtProblemasIdentificados.ValorMaximo = CType(0, Long)
        Me.txtProblemasIdentificados.ValorMinimo = CType(0, Long)
        '
        'lblProblemas
        '
        Me.lblProblemas.BackColor = System.Drawing.Color.Transparent
        Me.lblProblemas.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProblemas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblProblemas.Location = New System.Drawing.Point(116, 224)
        Me.lblProblemas.Name = "lblProblemas"
        Me.lblProblemas.Size = New System.Drawing.Size(173, 28)
        Me.lblProblemas.TabIndex = 214
        Me.lblProblemas.Text = "Problemas Identificados"
        Me.lblProblemas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbEstadoCivil
        '
        Me.cmbEstadoCivil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstadoCivil.FormattingEnabled = True
        Me.cmbEstadoCivil.Location = New System.Drawing.Point(819, 137)
        Me.cmbEstadoCivil.Name = "cmbEstadoCivil"
        Me.cmbEstadoCivil.Size = New System.Drawing.Size(205, 22)
        Me.cmbEstadoCivil.TabIndex = 34
        Me.cmbEstadoCivil.Tag = "32"
        '
        'lblEstadoCivil
        '
        Me.lblEstadoCivil.BackColor = System.Drawing.Color.Transparent
        Me.lblEstadoCivil.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstadoCivil.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblEstadoCivil.Location = New System.Drawing.Point(617, 136)
        Me.lblEstadoCivil.Name = "lblEstadoCivil"
        Me.lblEstadoCivil.Size = New System.Drawing.Size(147, 19)
        Me.lblEstadoCivil.TabIndex = 212
        Me.lblEstadoCivil.Text = "Estado Civil"
        Me.lblEstadoCivil.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDireccionCuidador
        '
        Me.txtDireccionCuidador.ControlComboEnlace = Nothing
        Me.txtDireccionCuidador.ControlTextoEnlace = Nothing
        Me.txtDireccionCuidador.DatoRelacionado = Nothing
        Me.txtDireccionCuidador.Decimals = CType(2, Byte)
        Me.txtDireccionCuidador.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtDireccionCuidador.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDireccionCuidador.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.txtDireccionCuidador.Location = New System.Drawing.Point(319, 135)
        Me.txtDireccionCuidador.MaxLength = 50
        Me.txtDireccionCuidador.Name = "txtDireccionCuidador"
        Me.txtDireccionCuidador.NombreCampoBuscado = Nothing
        Me.txtDireccionCuidador.NombreCampoBusqueda = Nothing
        Me.txtDireccionCuidador.NombreCampoDatos = Nothing
        Me.txtDireccionCuidador.Obligatorio = True
        Me.txtDireccionCuidador.OrigenDeDatos = Nothing
        Me.txtDireccionCuidador.PermitirValorCero = False
        Me.txtDireccionCuidador.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtDireccionCuidador.Size = New System.Drawing.Size(205, 22)
        Me.txtDireccionCuidador.TabIndex = 33
        Me.txtDireccionCuidador.Tag = "31"
        Me.txtDireccionCuidador.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtDireccionCuidador.UserValues = Nothing
        Me.txtDireccionCuidador.ValorMaximo = CType(0, Long)
        Me.txtDireccionCuidador.ValorMinimo = CType(0, Long)
        '
        'lblDireccionCuidador
        '
        Me.lblDireccionCuidador.BackColor = System.Drawing.Color.Transparent
        Me.lblDireccionCuidador.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDireccionCuidador.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblDireccionCuidador.Location = New System.Drawing.Point(116, 135)
        Me.lblDireccionCuidador.Name = "lblDireccionCuidador"
        Me.lblDireccionCuidador.Size = New System.Drawing.Size(178, 22)
        Me.lblDireccionCuidador.TabIndex = 210
        Me.lblDireccionCuidador.Text = "Dirección"
        Me.lblDireccionCuidador.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbNivEduCuidador
        '
        Me.cmbNivEduCuidador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNivEduCuidador.FormattingEnabled = True
        Me.cmbNivEduCuidador.Location = New System.Drawing.Point(819, 103)
        Me.cmbNivEduCuidador.Name = "cmbNivEduCuidador"
        Me.cmbNivEduCuidador.Size = New System.Drawing.Size(205, 22)
        Me.cmbNivEduCuidador.TabIndex = 32
        Me.cmbNivEduCuidador.Tag = "30"
        '
        'lblNivEduCuidador
        '
        Me.lblNivEduCuidador.BackColor = System.Drawing.Color.Transparent
        Me.lblNivEduCuidador.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNivEduCuidador.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblNivEduCuidador.Location = New System.Drawing.Point(617, 103)
        Me.lblNivEduCuidador.Name = "lblNivEduCuidador"
        Me.lblNivEduCuidador.Size = New System.Drawing.Size(192, 19)
        Me.lblNivEduCuidador.TabIndex = 208
        Me.lblNivEduCuidador.Text = "Escolaridad del cuidador"
        Me.lblNivEduCuidador.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbParentescoCuidador
        '
        Me.cmbParentescoCuidador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbParentescoCuidador.FormattingEnabled = True
        Me.cmbParentescoCuidador.Location = New System.Drawing.Point(319, 100)
        Me.cmbParentescoCuidador.Name = "cmbParentescoCuidador"
        Me.cmbParentescoCuidador.Size = New System.Drawing.Size(205, 22)
        Me.cmbParentescoCuidador.TabIndex = 31
        Me.cmbParentescoCuidador.Tag = "29"
        '
        'lblParentescoCuidador
        '
        Me.lblParentescoCuidador.BackColor = System.Drawing.Color.Transparent
        Me.lblParentescoCuidador.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParentescoCuidador.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblParentescoCuidador.Location = New System.Drawing.Point(116, 101)
        Me.lblParentescoCuidador.Name = "lblParentescoCuidador"
        Me.lblParentescoCuidador.Size = New System.Drawing.Size(153, 19)
        Me.lblParentescoCuidador.TabIndex = 206
        Me.lblParentescoCuidador.Text = "Parentesco"
        Me.lblParentescoCuidador.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDocumento
        '
        Me.txtDocumento.BackColor = System.Drawing.Color.White
        Me.txtDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDocumento.ControlComboEnlace = Nothing
        Me.txtDocumento.ControlTextoEnlace = Nothing
        Me.txtDocumento.DatoRelacionado = Nothing
        Me.txtDocumento.Decimals = CType(2, Byte)
        Me.txtDocumento.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtDocumento.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDocumento.Format = HistoriaClinica.tbFormats.AlfaNúmericoSinEspacios
        Me.txtDocumento.Location = New System.Drawing.Point(777, 64)
        Me.txtDocumento.MaxLength = 15
        Me.txtDocumento.Name = "txtDocumento"
        Me.txtDocumento.NombreCampoBuscado = Nothing
        Me.txtDocumento.NombreCampoBusqueda = Nothing
        Me.txtDocumento.NombreCampoDatos = Nothing
        Me.txtDocumento.Obligatorio = False
        Me.txtDocumento.OrigenDeDatos = Nothing
        Me.txtDocumento.PermitirValorCero = False
        Me.txtDocumento.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtDocumento.Size = New System.Drawing.Size(247, 22)
        Me.txtDocumento.TabIndex = 30
        Me.txtDocumento.Tag = "28"
        Me.txtDocumento.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtDocumento.UserValues = Nothing
        Me.txtDocumento.ValorMaximo = CType(0, Long)
        Me.txtDocumento.ValorMinimo = CType(0, Long)
        '
        'lblDocumento
        '
        Me.lblDocumento.BackColor = System.Drawing.Color.Transparent
        Me.lblDocumento.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDocumento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblDocumento.Location = New System.Drawing.Point(617, 65)
        Me.lblDocumento.Name = "lblDocumento"
        Me.lblDocumento.Size = New System.Drawing.Size(106, 19)
        Me.lblDocumento.TabIndex = 204
        Me.lblDocumento.Text = "Documento"
        Me.lblDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipodocumento
        '
        Me.cmbTipodocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipodocumento.FormattingEnabled = True
        Me.cmbTipodocumento.Location = New System.Drawing.Point(319, 63)
        Me.cmbTipodocumento.Name = "cmbTipodocumento"
        Me.cmbTipodocumento.Size = New System.Drawing.Size(205, 22)
        Me.cmbTipodocumento.TabIndex = 29
        Me.cmbTipodocumento.Tag = "27"
        '
        'lblTipodocumento
        '
        Me.lblTipodocumento.BackColor = System.Drawing.Color.Transparent
        Me.lblTipodocumento.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipodocumento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblTipodocumento.Location = New System.Drawing.Point(116, 64)
        Me.lblTipodocumento.Name = "lblTipodocumento"
        Me.lblTipodocumento.Size = New System.Drawing.Size(156, 19)
        Me.lblTipodocumento.TabIndex = 202
        Me.lblTipodocumento.Text = "Tipo Documento"
        Me.lblTipodocumento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNombreCuidador
        '
        Me.txtNombreCuidador.ControlComboEnlace = Nothing
        Me.txtNombreCuidador.ControlTextoEnlace = Nothing
        Me.txtNombreCuidador.DatoRelacionado = Nothing
        Me.txtNombreCuidador.Decimals = CType(2, Byte)
        Me.txtNombreCuidador.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtNombreCuidador.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreCuidador.Format = HistoriaClinica.tbFormats.AlfabéticoConEspacios
        Me.txtNombreCuidador.Location = New System.Drawing.Point(319, 29)
        Me.txtNombreCuidador.MaxLength = 200
        Me.txtNombreCuidador.Name = "txtNombreCuidador"
        Me.txtNombreCuidador.NombreCampoBuscado = Nothing
        Me.txtNombreCuidador.NombreCampoBusqueda = Nothing
        Me.txtNombreCuidador.NombreCampoDatos = Nothing
        Me.txtNombreCuidador.Obligatorio = True
        Me.txtNombreCuidador.OrigenDeDatos = Nothing
        Me.txtNombreCuidador.PermitirValorCero = False
        Me.txtNombreCuidador.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtNombreCuidador.Size = New System.Drawing.Size(704, 22)
        Me.txtNombreCuidador.TabIndex = 28
        Me.txtNombreCuidador.Tag = "26"
        Me.txtNombreCuidador.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtNombreCuidador.UserValues = Nothing
        Me.txtNombreCuidador.ValorMaximo = CType(0, Long)
        Me.txtNombreCuidador.ValorMinimo = CType(0, Long)
        '
        'lblNombreCuidador
        '
        Me.lblNombreCuidador.BackColor = System.Drawing.Color.Transparent
        Me.lblNombreCuidador.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreCuidador.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblNombreCuidador.Location = New System.Drawing.Point(116, 29)
        Me.lblNombreCuidador.Name = "lblNombreCuidador"
        Me.lblNombreCuidador.Size = New System.Drawing.Size(173, 22)
        Me.lblNombreCuidador.TabIndex = 200
        Me.lblNombreCuidador.Text = "Nombre"
        Me.lblNombreCuidador.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOcupacionCuidador
        '
        Me.txtOcupacionCuidador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOcupacionCuidador.ControlComboEnlace = Nothing
        Me.txtOcupacionCuidador.ControlTextoEnlace = Nothing
        Me.txtOcupacionCuidador.DatoRelacionado = Nothing
        Me.txtOcupacionCuidador.Decimals = CType(2, Byte)
        Me.txtOcupacionCuidador.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtOcupacionCuidador.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOcupacionCuidador.Format = HistoriaClinica.tbFormats.AlfabéticoConEspacios
        Me.txtOcupacionCuidador.Location = New System.Drawing.Point(319, 171)
        Me.txtOcupacionCuidador.MaxLength = 10
        Me.txtOcupacionCuidador.Name = "txtOcupacionCuidador"
        Me.txtOcupacionCuidador.NombreCampoBuscado = Nothing
        Me.txtOcupacionCuidador.NombreCampoBusqueda = Nothing
        Me.txtOcupacionCuidador.NombreCampoDatos = Nothing
        Me.txtOcupacionCuidador.Obligatorio = True
        Me.txtOcupacionCuidador.OrigenDeDatos = Nothing
        Me.txtOcupacionCuidador.PermitirValorCero = False
        Me.txtOcupacionCuidador.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtOcupacionCuidador.Size = New System.Drawing.Size(70, 22)
        Me.txtOcupacionCuidador.TabIndex = 35
        Me.txtOcupacionCuidador.Tag = "33"
        Me.txtOcupacionCuidador.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtOcupacionCuidador.UserValues = Nothing
        Me.txtOcupacionCuidador.ValorMaximo = CType(0, Long)
        Me.txtOcupacionCuidador.ValorMinimo = CType(0, Long)
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(116, 176)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 28)
        Me.Label4.TabIndex = 182
        Me.Label4.Text = "Ocupación"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(6, -2)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(153, 23)
        Me.Label6.TabIndex = 181
        Me.Label6.Text = "Datos del Cuidador"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grbFamilia
        '
        Me.grbFamilia.Controls.Add(Me.dtgFamiliar)
        Me.grbFamilia.Controls.Add(Me.btnSugerirFamiliares)
        Me.grbFamilia.Controls.Add(Me.cmbOcupacionFam)
        Me.grbFamilia.Controls.Add(Me.txtEdadFamiliar)
        Me.grbFamilia.Controls.Add(Me.lblEdad)
        Me.grbFamilia.Controls.Add(Me.txtNombreFamiliar)
        Me.grbFamilia.Controls.Add(Me.lblNombreFam)
        Me.grbFamilia.Controls.Add(Me.cmbParentesco)
        Me.grbFamilia.Controls.Add(Me.lblParentesco)
        Me.grbFamilia.Controls.Add(Me.Label1)
        Me.grbFamilia.Controls.Add(Me.lnkNuevo)
        Me.grbFamilia.Controls.Add(Me.txtCodOcupacionFam)
        Me.grbFamilia.Controls.Add(Me.btnAgregarFamiliar)
        Me.grbFamilia.Controls.Add(Me.Label122)
        Me.grbFamilia.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbFamilia.ForeColor = System.Drawing.Color.Black
        Me.grbFamilia.Location = New System.Drawing.Point(4, 439)
        Me.grbFamilia.Name = "grbFamilia"
        Me.grbFamilia.Size = New System.Drawing.Size(1089, 317)
        Me.grbFamilia.TabIndex = 189
        Me.grbFamilia.TabStop = False
        '
        'dtgFamiliar
        '
        Me.dtgFamiliar.AllowUserToAddRows = False
        Me.dtgFamiliar.AllowUserToOrderColumns = True
        Me.dtgFamiliar.AllowUserToResizeColumns = False
        Me.dtgFamiliar.AllowUserToResizeRows = False
        Me.dtgFamiliar.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtgFamiliar.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(210, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgFamiliar.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgFamiliar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgFamiliar.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdPariente, Me.tip_doc, Me.Num_doc, Me.NombreDelIntegranteDeLaFamilia, Me.ParentescoDelIntegranteDeLaFamilia, Me.dscParentescoDelIntegranteDeLaFamilia, Me.EdadDelIntegranteDeLaFamilia, Me.OcupacionDelIntegranteDeLaFamilia, Me.dscOcupacionDelIntegranteDeLaFamilia})
        Me.dtgFamiliar.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtgFamiliar.Location = New System.Drawing.Point(206, 51)
        Me.dtgFamiliar.Name = "dtgFamiliar"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(210, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.LightGoldenrodYellow
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgFamiliar.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtgFamiliar.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dtgFamiliar.Size = New System.Drawing.Size(781, 120)
        Me.dtgFamiliar.TabIndex = 201
        '
        'IdPariente
        '
        Me.IdPariente.DataPropertyName = "IdPariente"
        Me.IdPariente.HeaderText = "IdPariente"
        Me.IdPariente.Name = "IdPariente"
        Me.IdPariente.ReadOnly = True
        Me.IdPariente.Visible = False
        '
        'tip_doc
        '
        Me.tip_doc.DataPropertyName = "tip_doc"
        Me.tip_doc.HeaderText = "TipoDocumento"
        Me.tip_doc.Name = "tip_doc"
        Me.tip_doc.ReadOnly = True
        Me.tip_doc.Visible = False
        '
        'Num_doc
        '
        Me.Num_doc.DataPropertyName = "Num_doc"
        Me.Num_doc.HeaderText = "NumeroDocumento"
        Me.Num_doc.Name = "Num_doc"
        Me.Num_doc.ReadOnly = True
        Me.Num_doc.Visible = False
        '
        'NombreDelIntegranteDeLaFamilia
        '
        Me.NombreDelIntegranteDeLaFamilia.DataPropertyName = "NombreDelIntegranteDeLaFamilia"
        Me.NombreDelIntegranteDeLaFamilia.HeaderText = "Nombre"
        Me.NombreDelIntegranteDeLaFamilia.Name = "NombreDelIntegranteDeLaFamilia"
        Me.NombreDelIntegranteDeLaFamilia.ReadOnly = True
        Me.NombreDelIntegranteDeLaFamilia.Width = 250
        '
        'ParentescoDelIntegranteDeLaFamilia
        '
        Me.ParentescoDelIntegranteDeLaFamilia.DataPropertyName = "ParentescoDelIntegranteDeLaFamilia"
        Me.ParentescoDelIntegranteDeLaFamilia.HeaderText = "IdParentesco"
        Me.ParentescoDelIntegranteDeLaFamilia.Name = "ParentescoDelIntegranteDeLaFamilia"
        Me.ParentescoDelIntegranteDeLaFamilia.ReadOnly = True
        Me.ParentescoDelIntegranteDeLaFamilia.Visible = False
        '
        'dscParentescoDelIntegranteDeLaFamilia
        '
        Me.dscParentescoDelIntegranteDeLaFamilia.DataPropertyName = "dscParentescoDelIntegranteDeLaFamilia"
        Me.dscParentescoDelIntegranteDeLaFamilia.HeaderText = "Parentesco"
        Me.dscParentescoDelIntegranteDeLaFamilia.Name = "dscParentescoDelIntegranteDeLaFamilia"
        Me.dscParentescoDelIntegranteDeLaFamilia.ReadOnly = True
        Me.dscParentescoDelIntegranteDeLaFamilia.Width = 150
        '
        'EdadDelIntegranteDeLaFamilia
        '
        Me.EdadDelIntegranteDeLaFamilia.DataPropertyName = "EdadDelIntegranteDeLaFamilia"
        Me.EdadDelIntegranteDeLaFamilia.HeaderText = "Edad"
        Me.EdadDelIntegranteDeLaFamilia.Name = "EdadDelIntegranteDeLaFamilia"
        Me.EdadDelIntegranteDeLaFamilia.ReadOnly = True
        Me.EdadDelIntegranteDeLaFamilia.Width = 70
        '
        'OcupacionDelIntegranteDeLaFamilia
        '
        Me.OcupacionDelIntegranteDeLaFamilia.DataPropertyName = "OcupacionDelIntegranteDeLaFamilia"
        Me.OcupacionDelIntegranteDeLaFamilia.HeaderText = "IdOcupación"
        Me.OcupacionDelIntegranteDeLaFamilia.Name = "OcupacionDelIntegranteDeLaFamilia"
        Me.OcupacionDelIntegranteDeLaFamilia.ReadOnly = True
        Me.OcupacionDelIntegranteDeLaFamilia.Visible = False
        '
        'dscOcupacionDelIntegranteDeLaFamilia
        '
        Me.dscOcupacionDelIntegranteDeLaFamilia.DataPropertyName = "dscOcupacionDelIntegranteDeLaFamilia"
        Me.dscOcupacionDelIntegranteDeLaFamilia.HeaderText = "Ocupación"
        Me.dscOcupacionDelIntegranteDeLaFamilia.Name = "dscOcupacionDelIntegranteDeLaFamilia"
        Me.dscOcupacionDelIntegranteDeLaFamilia.ReadOnly = True
        Me.dscOcupacionDelIntegranteDeLaFamilia.Width = 250
        '
        'btnSugerirFamiliares
        '
        Me.btnSugerirFamiliares.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btnSugerirFamiliares.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_proponer1
        Me.btnSugerirFamiliares.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSugerirFamiliares.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSugerirFamiliares.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSugerirFamiliares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSugerirFamiliares.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btnSugerirFamiliares.Location = New System.Drawing.Point(926, 12)
        Me.btnSugerirFamiliares.Name = "btnSugerirFamiliares"
        Me.btnSugerirFamiliares.Size = New System.Drawing.Size(163, 33)
        Me.btnSugerirFamiliares.TabIndex = 201
        Me.btnSugerirFamiliares.Tag = "37"
        Me.btnSugerirFamiliares.UseVisualStyleBackColor = False
        '
        'cmbOcupacionFam
        '
        Me.cmbOcupacionFam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOcupacionFam.FormattingEnabled = True
        Me.cmbOcupacionFam.Location = New System.Drawing.Point(430, 255)
        Me.cmbOcupacionFam.Name = "cmbOcupacionFam"
        Me.cmbOcupacionFam.Size = New System.Drawing.Size(409, 22)
        Me.cmbOcupacionFam.TabIndex = 26
        Me.cmbOcupacionFam.Tag = "24"
        '
        'txtEdadFamiliar
        '
        Me.txtEdadFamiliar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEdadFamiliar.ControlComboEnlace = Nothing
        Me.txtEdadFamiliar.ControlTextoEnlace = Nothing
        Me.txtEdadFamiliar.DatoRelacionado = Nothing
        Me.txtEdadFamiliar.Decimals = CType(2, Byte)
        Me.txtEdadFamiliar.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtEdadFamiliar.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEdadFamiliar.Format = HistoriaClinica.tbFormats.NúmericoEnteroSinSigno
        Me.txtEdadFamiliar.Location = New System.Drawing.Point(838, 196)
        Me.txtEdadFamiliar.MaxLength = 3
        Me.txtEdadFamiliar.Name = "txtEdadFamiliar"
        Me.txtEdadFamiliar.NombreCampoBuscado = Nothing
        Me.txtEdadFamiliar.NombreCampoBusqueda = Nothing
        Me.txtEdadFamiliar.NombreCampoDatos = Nothing
        Me.txtEdadFamiliar.Obligatorio = True
        Me.txtEdadFamiliar.OrigenDeDatos = Nothing
        Me.txtEdadFamiliar.PermitirValorCero = False
        Me.txtEdadFamiliar.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtEdadFamiliar.Size = New System.Drawing.Size(55, 22)
        Me.txtEdadFamiliar.TabIndex = 22
        Me.txtEdadFamiliar.Tag = "21"
        Me.txtEdadFamiliar.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtEdadFamiliar.UserValues = Nothing
        Me.txtEdadFamiliar.ValorMaximo = CType(0, Long)
        Me.txtEdadFamiliar.ValorMinimo = CType(0, Long)
        '
        'lblEdad
        '
        Me.lblEdad.BackColor = System.Drawing.Color.Transparent
        Me.lblEdad.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEdad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblEdad.Location = New System.Drawing.Point(770, 196)
        Me.lblEdad.Name = "lblEdad"
        Me.lblEdad.Size = New System.Drawing.Size(43, 22)
        Me.lblEdad.TabIndex = 200
        Me.lblEdad.Text = "Edad"
        Me.lblEdad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNombreFamiliar
        '
        Me.txtNombreFamiliar.ControlComboEnlace = Nothing
        Me.txtNombreFamiliar.ControlTextoEnlace = Nothing
        Me.txtNombreFamiliar.DatoRelacionado = Nothing
        Me.txtNombreFamiliar.Decimals = CType(2, Byte)
        Me.txtNombreFamiliar.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtNombreFamiliar.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreFamiliar.Format = HistoriaClinica.tbFormats.AlfabéticoConEspacios
        Me.txtNombreFamiliar.Location = New System.Drawing.Point(322, 196)
        Me.txtNombreFamiliar.MaxLength = 200
        Me.txtNombreFamiliar.Name = "txtNombreFamiliar"
        Me.txtNombreFamiliar.NombreCampoBuscado = Nothing
        Me.txtNombreFamiliar.NombreCampoBusqueda = Nothing
        Me.txtNombreFamiliar.NombreCampoDatos = Nothing
        Me.txtNombreFamiliar.Obligatorio = True
        Me.txtNombreFamiliar.OrigenDeDatos = Nothing
        Me.txtNombreFamiliar.PermitirValorCero = False
        Me.txtNombreFamiliar.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtNombreFamiliar.Size = New System.Drawing.Size(442, 22)
        Me.txtNombreFamiliar.TabIndex = 21
        Me.txtNombreFamiliar.Tag = "20"
        Me.txtNombreFamiliar.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtNombreFamiliar.UserValues = Nothing
        Me.txtNombreFamiliar.ValorMaximo = CType(0, Long)
        Me.txtNombreFamiliar.ValorMinimo = CType(0, Long)
        '
        'lblNombreFam
        '
        Me.lblNombreFam.BackColor = System.Drawing.Color.Transparent
        Me.lblNombreFam.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreFam.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblNombreFam.Location = New System.Drawing.Point(117, 196)
        Me.lblNombreFam.Name = "lblNombreFam"
        Me.lblNombreFam.Size = New System.Drawing.Size(175, 22)
        Me.lblNombreFam.TabIndex = 198
        Me.lblNombreFam.Text = "Nombre"
        Me.lblNombreFam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbParentesco
        '
        Me.cmbParentesco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbParentesco.FormattingEnabled = True
        Me.cmbParentesco.Location = New System.Drawing.Point(322, 224)
        Me.cmbParentesco.Name = "cmbParentesco"
        Me.cmbParentesco.Size = New System.Drawing.Size(205, 22)
        Me.cmbParentesco.TabIndex = 23
        Me.cmbParentesco.Tag = "22"
        '
        'lblParentesco
        '
        Me.lblParentesco.BackColor = System.Drawing.Color.Transparent
        Me.lblParentesco.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParentesco.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblParentesco.Location = New System.Drawing.Point(117, 225)
        Me.lblParentesco.Name = "lblParentesco"
        Me.lblParentesco.Size = New System.Drawing.Size(153, 19)
        Me.lblParentesco.TabIndex = 196
        Me.lblParentesco.Text = "Parentesco"
        Me.lblParentesco.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(-1, -3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(189, 23)
        Me.Label1.TabIndex = 195
        Me.Label1.Text = "Composición Familiar"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lnkNuevo
        '
        Me.lnkNuevo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lnkNuevo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lnkNuevo.LinkColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lnkNuevo.Location = New System.Drawing.Point(816, 230)
        Me.lnkNuevo.Name = "lnkNuevo"
        Me.lnkNuevo.Size = New System.Drawing.Size(54, 14)
        Me.lnkNuevo.TabIndex = 24
        Me.lnkNuevo.TabStop = True
        Me.lnkNuevo.Text = "Nuevo"
        '
        'txtCodOcupacionFam
        '
        Me.txtCodOcupacionFam.BackColor = System.Drawing.SystemColors.Window
        Me.txtCodOcupacionFam.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodOcupacionFam.ControlComboEnlace = Nothing
        Me.txtCodOcupacionFam.ControlTextoEnlace = Nothing
        Me.txtCodOcupacionFam.DatoRelacionado = Nothing
        Me.txtCodOcupacionFam.Decimals = CType(2, Byte)
        Me.txtCodOcupacionFam.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtCodOcupacionFam.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodOcupacionFam.Format = HistoriaClinica.tbFormats.AlfabéticoConEspacios
        Me.txtCodOcupacionFam.Location = New System.Drawing.Point(322, 255)
        Me.txtCodOcupacionFam.MaxLength = 10
        Me.txtCodOcupacionFam.Name = "txtCodOcupacionFam"
        Me.txtCodOcupacionFam.NombreCampoBuscado = Nothing
        Me.txtCodOcupacionFam.NombreCampoBusqueda = Nothing
        Me.txtCodOcupacionFam.NombreCampoDatos = Nothing
        Me.txtCodOcupacionFam.Obligatorio = True
        Me.txtCodOcupacionFam.OrigenDeDatos = Nothing
        Me.txtCodOcupacionFam.PermitirValorCero = False
        Me.txtCodOcupacionFam.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtCodOcupacionFam.Size = New System.Drawing.Size(101, 22)
        Me.txtCodOcupacionFam.TabIndex = 25
        Me.txtCodOcupacionFam.Tag = "23"
        Me.txtCodOcupacionFam.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtCodOcupacionFam.UserValues = Nothing
        Me.txtCodOcupacionFam.ValorMaximo = CType(0, Long)
        Me.txtCodOcupacionFam.ValorMinimo = CType(0, Long)
        '
        'btnAgregarFamiliar
        '
        Me.btnAgregarFamiliar.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btnAgregarFamiliar.BackgroundImage = CType(resources.GetObject("btnAgregarFamiliar.BackgroundImage"), System.Drawing.Image)
        Me.btnAgregarFamiliar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregarFamiliar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btnAgregarFamiliar.Location = New System.Drawing.Point(913, 275)
        Me.btnAgregarFamiliar.Name = "btnAgregarFamiliar"
        Me.btnAgregarFamiliar.Size = New System.Drawing.Size(74, 23)
        Me.btnAgregarFamiliar.TabIndex = 27
        Me.btnAgregarFamiliar.Tag = "25"
        Me.btnAgregarFamiliar.UseVisualStyleBackColor = False
        '
        'Label122
        '
        Me.Label122.BackColor = System.Drawing.Color.Transparent
        Me.Label122.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label122.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label122.Location = New System.Drawing.Point(117, 256)
        Me.Label122.Name = "Label122"
        Me.Label122.Size = New System.Drawing.Size(118, 19)
        Me.Label122.TabIndex = 26
        Me.Label122.Text = "Ocupación"
        Me.Label122.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grbEntornoSocioFamiliar
        '
        Me.grbEntornoSocioFamiliar.Controls.Add(Me.txtLugarPaciente)
        Me.grbEntornoSocioFamiliar.Controls.Add(Me.txtNumeroIntegrantes)
        Me.grbEntornoSocioFamiliar.Controls.Add(Me.lblNumeroIntegrantes)
        Me.grbEntornoSocioFamiliar.Controls.Add(Me.lblLugarPaciente)
        Me.grbEntornoSocioFamiliar.Controls.Add(Me.txtPersonasCargo)
        Me.grbEntornoSocioFamiliar.Controls.Add(Me.lblPersonasCargo)
        Me.grbEntornoSocioFamiliar.Controls.Add(Me.cmbCondicionPadre)
        Me.grbEntornoSocioFamiliar.Controls.Add(Me.lblCondicionPadre)
        Me.grbEntornoSocioFamiliar.Controls.Add(Me.rbtNoTieneHijos)
        Me.grbEntornoSocioFamiliar.Controls.Add(Me.rbtSiTieneHijos)
        Me.grbEntornoSocioFamiliar.Controls.Add(Me.txtNumeroHermanos)
        Me.grbEntornoSocioFamiliar.Controls.Add(Me.lblNumeroHermanos)
        Me.grbEntornoSocioFamiliar.Controls.Add(Me.Label2)
        Me.grbEntornoSocioFamiliar.Controls.Add(Me.cmbTipoFamilia)
        Me.grbEntornoSocioFamiliar.Controls.Add(Me.lblTipoFamilia)
        Me.grbEntornoSocioFamiliar.Controls.Add(Me.Label5)
        Me.grbEntornoSocioFamiliar.Controls.Add(Me.cmbCondicionMadre)
        Me.grbEntornoSocioFamiliar.Controls.Add(Me.lblCondicionMadre)
        Me.grbEntornoSocioFamiliar.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbEntornoSocioFamiliar.ForeColor = System.Drawing.Color.Black
        Me.grbEntornoSocioFamiliar.Location = New System.Drawing.Point(4, 267)
        Me.grbEntornoSocioFamiliar.Name = "grbEntornoSocioFamiliar"
        Me.grbEntornoSocioFamiliar.Size = New System.Drawing.Size(1089, 166)
        Me.grbEntornoSocioFamiliar.TabIndex = 187
        Me.grbEntornoSocioFamiliar.TabStop = False
        '
        'txtLugarPaciente
        '
        Me.txtLugarPaciente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLugarPaciente.ControlComboEnlace = Nothing
        Me.txtLugarPaciente.ControlTextoEnlace = Nothing
        Me.txtLugarPaciente.DatoRelacionado = Nothing
        Me.txtLugarPaciente.Decimals = CType(2, Byte)
        Me.txtLugarPaciente.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtLugarPaciente.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLugarPaciente.Format = HistoriaClinica.tbFormats.NúmericoEnteroSinSigno
        Me.txtLugarPaciente.Location = New System.Drawing.Point(633, 67)
        Me.txtLugarPaciente.MaxLength = 3
        Me.txtLugarPaciente.Name = "txtLugarPaciente"
        Me.txtLugarPaciente.NombreCampoBuscado = Nothing
        Me.txtLugarPaciente.NombreCampoBusqueda = Nothing
        Me.txtLugarPaciente.NombreCampoDatos = Nothing
        Me.txtLugarPaciente.Obligatorio = True
        Me.txtLugarPaciente.OrigenDeDatos = Nothing
        Me.txtLugarPaciente.PermitirValorCero = False
        Me.txtLugarPaciente.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtLugarPaciente.Size = New System.Drawing.Size(55, 22)
        Me.txtLugarPaciente.TabIndex = 14
        Me.txtLugarPaciente.Tag = "14"
        Me.txtLugarPaciente.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtLugarPaciente.UserValues = Nothing
        Me.txtLugarPaciente.ValorMaximo = CType(0, Long)
        Me.txtLugarPaciente.ValorMinimo = CType(0, Long)
        '
        'txtNumeroIntegrantes
        '
        Me.txtNumeroIntegrantes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeroIntegrantes.ControlComboEnlace = Nothing
        Me.txtNumeroIntegrantes.ControlTextoEnlace = Nothing
        Me.txtNumeroIntegrantes.DatoRelacionado = Nothing
        Me.txtNumeroIntegrantes.Decimals = CType(2, Byte)
        Me.txtNumeroIntegrantes.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtNumeroIntegrantes.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroIntegrantes.Format = HistoriaClinica.tbFormats.NúmericoEnteroSinSigno
        Me.txtNumeroIntegrantes.Location = New System.Drawing.Point(446, 99)
        Me.txtNumeroIntegrantes.MaxLength = 3
        Me.txtNumeroIntegrantes.Name = "txtNumeroIntegrantes"
        Me.txtNumeroIntegrantes.NombreCampoBuscado = Nothing
        Me.txtNumeroIntegrantes.NombreCampoBusqueda = Nothing
        Me.txtNumeroIntegrantes.NombreCampoDatos = Nothing
        Me.txtNumeroIntegrantes.Obligatorio = True
        Me.txtNumeroIntegrantes.OrigenDeDatos = Nothing
        Me.txtNumeroIntegrantes.PermitirValorCero = False
        Me.txtNumeroIntegrantes.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtNumeroIntegrantes.Size = New System.Drawing.Size(47, 22)
        Me.txtNumeroIntegrantes.TabIndex = 16
        Me.txtNumeroIntegrantes.Tag = "16"
        Me.txtNumeroIntegrantes.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtNumeroIntegrantes.UserValues = Nothing
        Me.txtNumeroIntegrantes.ValorMaximo = CType(0, Long)
        Me.txtNumeroIntegrantes.ValorMinimo = CType(0, Long)
        '
        'lblNumeroIntegrantes
        '
        Me.lblNumeroIntegrantes.BackColor = System.Drawing.Color.Transparent
        Me.lblNumeroIntegrantes.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroIntegrantes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblNumeroIntegrantes.Location = New System.Drawing.Point(119, 99)
        Me.lblNumeroIntegrantes.Name = "lblNumeroIntegrantes"
        Me.lblNumeroIntegrantes.Size = New System.Drawing.Size(256, 22)
        Me.lblNumeroIntegrantes.TabIndex = 191
        Me.lblNumeroIntegrantes.Text = "Número de Integrantes de la familia"
        Me.lblNumeroIntegrantes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLugarPaciente
        '
        Me.lblLugarPaciente.BackColor = System.Drawing.Color.Transparent
        Me.lblLugarPaciente.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLugarPaciente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblLugarPaciente.Location = New System.Drawing.Point(441, 66)
        Me.lblLugarPaciente.Name = "lblLugarPaciente"
        Me.lblLugarPaciente.Size = New System.Drawing.Size(137, 22)
        Me.lblLugarPaciente.TabIndex = 193
        Me.lblLugarPaciente.Text = "Lugar del Paciente"
        Me.lblLugarPaciente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPersonasCargo
        '
        Me.txtPersonasCargo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPersonasCargo.ControlComboEnlace = Nothing
        Me.txtPersonasCargo.ControlTextoEnlace = Nothing
        Me.txtPersonasCargo.DatoRelacionado = Nothing
        Me.txtPersonasCargo.Decimals = CType(2, Byte)
        Me.txtPersonasCargo.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtPersonasCargo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPersonasCargo.Format = HistoriaClinica.tbFormats.NúmericoEnteroSinSigno
        Me.txtPersonasCargo.Location = New System.Drawing.Point(909, 66)
        Me.txtPersonasCargo.MaxLength = 3
        Me.txtPersonasCargo.Name = "txtPersonasCargo"
        Me.txtPersonasCargo.NombreCampoBuscado = Nothing
        Me.txtPersonasCargo.NombreCampoBusqueda = Nothing
        Me.txtPersonasCargo.NombreCampoDatos = Nothing
        Me.txtPersonasCargo.Obligatorio = True
        Me.txtPersonasCargo.OrigenDeDatos = Nothing
        Me.txtPersonasCargo.PermitirValorCero = False
        Me.txtPersonasCargo.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtPersonasCargo.Size = New System.Drawing.Size(55, 22)
        Me.txtPersonasCargo.TabIndex = 15
        Me.txtPersonasCargo.Tag = "15"
        Me.txtPersonasCargo.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtPersonasCargo.UserValues = Nothing
        Me.txtPersonasCargo.ValorMaximo = CType(0, Long)
        Me.txtPersonasCargo.ValorMinimo = CType(0, Long)
        '
        'lblPersonasCargo
        '
        Me.lblPersonasCargo.BackColor = System.Drawing.Color.Transparent
        Me.lblPersonasCargo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPersonasCargo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblPersonasCargo.Location = New System.Drawing.Point(756, 65)
        Me.lblPersonasCargo.Name = "lblPersonasCargo"
        Me.lblPersonasCargo.Size = New System.Drawing.Size(134, 22)
        Me.lblPersonasCargo.TabIndex = 189
        Me.lblPersonasCargo.Text = "Personas a Cargo"
        Me.lblPersonasCargo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbCondicionPadre
        '
        Me.cmbCondicionPadre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCondicionPadre.FormattingEnabled = True
        Me.cmbCondicionPadre.Location = New System.Drawing.Point(762, 31)
        Me.cmbCondicionPadre.Name = "cmbCondicionPadre"
        Me.cmbCondicionPadre.Size = New System.Drawing.Size(205, 22)
        Me.cmbCondicionPadre.TabIndex = 12
        Me.cmbCondicionPadre.Tag = "12"
        '
        'lblCondicionPadre
        '
        Me.lblCondicionPadre.BackColor = System.Drawing.Color.Transparent
        Me.lblCondicionPadre.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCondicionPadre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblCondicionPadre.Location = New System.Drawing.Point(601, 34)
        Me.lblCondicionPadre.Name = "lblCondicionPadre"
        Me.lblCondicionPadre.Size = New System.Drawing.Size(163, 19)
        Me.lblCondicionPadre.TabIndex = 187
        Me.lblCondicionPadre.Text = "Condición del Padre"
        Me.lblCondicionPadre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rbtNoTieneHijos
        '
        Me.rbtNoTieneHijos.AutoSize = True
        Me.rbtNoTieneHijos.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtNoTieneHijos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.rbtNoTieneHijos.Location = New System.Drawing.Point(919, 99)
        Me.rbtNoTieneHijos.Name = "rbtNoTieneHijos"
        Me.rbtNoTieneHijos.Size = New System.Drawing.Size(43, 18)
        Me.rbtNoTieneHijos.TabIndex = 18
        Me.rbtNoTieneHijos.TabStop = True
        Me.rbtNoTieneHijos.Tag = "18"
        Me.rbtNoTieneHijos.Text = "No"
        Me.rbtNoTieneHijos.UseVisualStyleBackColor = True
        '
        'rbtSiTieneHijos
        '
        Me.rbtSiTieneHijos.AutoSize = True
        Me.rbtSiTieneHijos.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtSiTieneHijos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.rbtSiTieneHijos.Location = New System.Drawing.Point(875, 99)
        Me.rbtSiTieneHijos.Name = "rbtSiTieneHijos"
        Me.rbtSiTieneHijos.Size = New System.Drawing.Size(38, 18)
        Me.rbtSiTieneHijos.TabIndex = 17
        Me.rbtSiTieneHijos.TabStop = True
        Me.rbtSiTieneHijos.Tag = "17"
        Me.rbtSiTieneHijos.Text = "Si"
        Me.rbtSiTieneHijos.UseVisualStyleBackColor = True
        '
        'txtNumeroHermanos
        '
        Me.txtNumeroHermanos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeroHermanos.ControlComboEnlace = Nothing
        Me.txtNumeroHermanos.ControlTextoEnlace = Nothing
        Me.txtNumeroHermanos.DatoRelacionado = Nothing
        Me.txtNumeroHermanos.Decimals = CType(2, Byte)
        Me.txtNumeroHermanos.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtNumeroHermanos.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroHermanos.Format = HistoriaClinica.tbFormats.NúmericoEnteroSinSigno
        Me.txtNumeroHermanos.Location = New System.Drawing.Point(323, 65)
        Me.txtNumeroHermanos.MaxLength = 3
        Me.txtNumeroHermanos.Name = "txtNumeroHermanos"
        Me.txtNumeroHermanos.NombreCampoBuscado = Nothing
        Me.txtNumeroHermanos.NombreCampoBusqueda = Nothing
        Me.txtNumeroHermanos.NombreCampoDatos = Nothing
        Me.txtNumeroHermanos.Obligatorio = True
        Me.txtNumeroHermanos.OrigenDeDatos = Nothing
        Me.txtNumeroHermanos.PermitirValorCero = False
        Me.txtNumeroHermanos.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtNumeroHermanos.Size = New System.Drawing.Size(55, 22)
        Me.txtNumeroHermanos.TabIndex = 13
        Me.txtNumeroHermanos.Tag = "13"
        Me.txtNumeroHermanos.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtNumeroHermanos.UserValues = Nothing
        Me.txtNumeroHermanos.ValorMaximo = CType(0, Long)
        Me.txtNumeroHermanos.ValorMinimo = CType(0, Long)
        '
        'lblNumeroHermanos
        '
        Me.lblNumeroHermanos.BackColor = System.Drawing.Color.Transparent
        Me.lblNumeroHermanos.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroHermanos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblNumeroHermanos.Location = New System.Drawing.Point(119, 65)
        Me.lblNumeroHermanos.Name = "lblNumeroHermanos"
        Me.lblNumeroHermanos.Size = New System.Drawing.Size(176, 22)
        Me.lblNumeroHermanos.TabIndex = 182
        Me.lblNumeroHermanos.Text = "Número de Hermanos"
        Me.lblNumeroHermanos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(6, -3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(182, 23)
        Me.Label2.TabIndex = 181
        Me.Label2.Text = "Entorno Socio Familiar"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipoFamilia
        '
        Me.cmbTipoFamilia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoFamilia.FormattingEnabled = True
        Me.cmbTipoFamilia.Location = New System.Drawing.Point(323, 129)
        Me.cmbTipoFamilia.Name = "cmbTipoFamilia"
        Me.cmbTipoFamilia.Size = New System.Drawing.Size(272, 22)
        Me.cmbTipoFamilia.TabIndex = 19
        Me.cmbTipoFamilia.Tag = "19"
        '
        'lblTipoFamilia
        '
        Me.lblTipoFamilia.BackColor = System.Drawing.Color.Transparent
        Me.lblTipoFamilia.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoFamilia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblTipoFamilia.Location = New System.Drawing.Point(119, 130)
        Me.lblTipoFamilia.Name = "lblTipoFamilia"
        Me.lblTipoFamilia.Size = New System.Drawing.Size(154, 19)
        Me.lblTipoFamilia.TabIndex = 179
        Me.lblTipoFamilia.Text = "Tipo de Familia"
        Me.lblTipoFamilia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(627, 98)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(212, 19)
        Me.Label5.TabIndex = 177
        Me.Label5.Text = "¿El paciente tiene Hijos?"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbCondicionMadre
        '
        Me.cmbCondicionMadre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCondicionMadre.FormattingEnabled = True
        Me.cmbCondicionMadre.Location = New System.Drawing.Point(323, 31)
        Me.cmbCondicionMadre.Name = "cmbCondicionMadre"
        Me.cmbCondicionMadre.Size = New System.Drawing.Size(272, 22)
        Me.cmbCondicionMadre.TabIndex = 11
        Me.cmbCondicionMadre.Tag = "11"
        '
        'lblCondicionMadre
        '
        Me.lblCondicionMadre.BackColor = System.Drawing.Color.Transparent
        Me.lblCondicionMadre.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCondicionMadre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblCondicionMadre.Location = New System.Drawing.Point(119, 34)
        Me.lblCondicionMadre.Name = "lblCondicionMadre"
        Me.lblCondicionMadre.Size = New System.Drawing.Size(182, 19)
        Me.lblCondicionMadre.TabIndex = 112
        Me.lblCondicionMadre.Text = "Condición de la Madre"
        Me.lblCondicionMadre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grbEntorno
        '
        Me.grbEntorno.Controls.Add(Me.cmbOcupacion)
        Me.grbEntorno.Controls.Add(Me.rbtNoTrabajoEstable)
        Me.grbEntorno.Controls.Add(Me.rbtSiTrabajoEstable)
        Me.grbEntorno.Controls.Add(Me.txtOcupacion)
        Me.grbEntorno.Controls.Add(Me.Label15)
        Me.grbEntorno.Controls.Add(Me.Label17)
        Me.grbEntorno.Controls.Add(Me.cmbNivelIngresos)
        Me.grbEntorno.Controls.Add(Me.lblNivelIngresos)
        Me.grbEntorno.Controls.Add(Me.lblEstabiliadLaboral)
        Me.grbEntorno.Controls.Add(Me.cmbNivelEducativo)
        Me.grbEntorno.Controls.Add(Me.lblNivelEducativo)
        Me.grbEntorno.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbEntorno.ForeColor = System.Drawing.Color.Black
        Me.grbEntorno.Location = New System.Drawing.Point(4, 110)
        Me.grbEntorno.Name = "grbEntorno"
        Me.grbEntorno.Size = New System.Drawing.Size(1089, 155)
        Me.grbEntorno.TabIndex = 181
        Me.grbEntorno.TabStop = False
        '
        'cmbOcupacion
        '
        Me.cmbOcupacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOcupacion.FormattingEnabled = True
        Me.cmbOcupacion.Location = New System.Drawing.Point(398, 57)
        Me.cmbOcupacion.Name = "cmbOcupacion"
        Me.cmbOcupacion.Size = New System.Drawing.Size(577, 22)
        Me.cmbOcupacion.TabIndex = 7
        Me.cmbOcupacion.Tag = "7"
        '
        'rbtNoTrabajoEstable
        '
        Me.rbtNoTrabajoEstable.AutoSize = True
        Me.rbtNoTrabajoEstable.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtNoTrabajoEstable.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.rbtNoTrabajoEstable.Location = New System.Drawing.Point(486, 91)
        Me.rbtNoTrabajoEstable.Name = "rbtNoTrabajoEstable"
        Me.rbtNoTrabajoEstable.Size = New System.Drawing.Size(43, 18)
        Me.rbtNoTrabajoEstable.TabIndex = 9
        Me.rbtNoTrabajoEstable.TabStop = True
        Me.rbtNoTrabajoEstable.Tag = "9"
        Me.rbtNoTrabajoEstable.Text = "No"
        Me.rbtNoTrabajoEstable.UseVisualStyleBackColor = True
        '
        'rbtSiTrabajoEstable
        '
        Me.rbtSiTrabajoEstable.AutoSize = True
        Me.rbtSiTrabajoEstable.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtSiTrabajoEstable.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.rbtSiTrabajoEstable.Location = New System.Drawing.Point(442, 91)
        Me.rbtSiTrabajoEstable.Name = "rbtSiTrabajoEstable"
        Me.rbtSiTrabajoEstable.Size = New System.Drawing.Size(38, 18)
        Me.rbtSiTrabajoEstable.TabIndex = 8
        Me.rbtSiTrabajoEstable.TabStop = True
        Me.rbtSiTrabajoEstable.Tag = "8"
        Me.rbtSiTrabajoEstable.Text = "Si"
        Me.rbtSiTrabajoEstable.UseVisualStyleBackColor = True
        '
        'txtOcupacion
        '
        Me.txtOcupacion.BackColor = System.Drawing.SystemColors.Window
        Me.txtOcupacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOcupacion.ControlComboEnlace = Nothing
        Me.txtOcupacion.ControlTextoEnlace = Nothing
        Me.txtOcupacion.DatoRelacionado = Nothing
        Me.txtOcupacion.Decimals = CType(2, Byte)
        Me.txtOcupacion.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtOcupacion.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOcupacion.Format = HistoriaClinica.tbFormats.AlfabéticoConEspacios
        Me.txtOcupacion.Location = New System.Drawing.Point(322, 57)
        Me.txtOcupacion.MaxLength = 10
        Me.txtOcupacion.Name = "txtOcupacion"
        Me.txtOcupacion.NombreCampoBuscado = Nothing
        Me.txtOcupacion.NombreCampoBusqueda = Nothing
        Me.txtOcupacion.NombreCampoDatos = Nothing
        Me.txtOcupacion.Obligatorio = True
        Me.txtOcupacion.OrigenDeDatos = Nothing
        Me.txtOcupacion.PermitirValorCero = False
        Me.txtOcupacion.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtOcupacion.Size = New System.Drawing.Size(70, 22)
        Me.txtOcupacion.TabIndex = 6
        Me.txtOcupacion.Tag = "6"
        Me.txtOcupacion.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtOcupacion.UserValues = Nothing
        Me.txtOcupacion.ValorMaximo = CType(0, Long)
        Me.txtOcupacion.ValorMinimo = CType(0, Long)
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(113, 62)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(104, 17)
        Me.Label15.TabIndex = 182
        Me.Label15.Text = "Ocupación"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Label17.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(6, -2)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(90, 23)
        Me.Label17.TabIndex = 181
        Me.Label17.Text = "Entorno"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbNivelIngresos
        '
        Me.cmbNivelIngresos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNivelIngresos.FormattingEnabled = True
        Me.cmbNivelIngresos.Location = New System.Drawing.Point(322, 120)
        Me.cmbNivelIngresos.Name = "cmbNivelIngresos"
        Me.cmbNivelIngresos.Size = New System.Drawing.Size(397, 22)
        Me.cmbNivelIngresos.TabIndex = 10
        Me.cmbNivelIngresos.Tag = "10"
        '
        'lblNivelIngresos
        '
        Me.lblNivelIngresos.BackColor = System.Drawing.Color.Transparent
        Me.lblNivelIngresos.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNivelIngresos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblNivelIngresos.Location = New System.Drawing.Point(113, 121)
        Me.lblNivelIngresos.Name = "lblNivelIngresos"
        Me.lblNivelIngresos.Size = New System.Drawing.Size(156, 19)
        Me.lblNivelIngresos.TabIndex = 179
        Me.lblNivelIngresos.Text = "Nivel Ingresos"
        Me.lblNivelIngresos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEstabiliadLaboral
        '
        Me.lblEstabiliadLaboral.BackColor = System.Drawing.Color.Transparent
        Me.lblEstabiliadLaboral.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstabiliadLaboral.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblEstabiliadLaboral.Location = New System.Drawing.Point(113, 91)
        Me.lblEstabiliadLaboral.Name = "lblEstabiliadLaboral"
        Me.lblEstabiliadLaboral.Size = New System.Drawing.Size(310, 19)
        Me.lblEstabiliadLaboral.TabIndex = 177
        Me.lblEstabiliadLaboral.Text = "¿El paciente cuenta con un Trabajo Estable?"
        Me.lblEstabiliadLaboral.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbNivelEducativo
        '
        Me.cmbNivelEducativo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNivelEducativo.FormattingEnabled = True
        Me.cmbNivelEducativo.Location = New System.Drawing.Point(322, 28)
        Me.cmbNivelEducativo.Name = "cmbNivelEducativo"
        Me.cmbNivelEducativo.Size = New System.Drawing.Size(396, 22)
        Me.cmbNivelEducativo.TabIndex = 5
        '
        'lblNivelEducativo
        '
        Me.lblNivelEducativo.BackColor = System.Drawing.Color.Transparent
        Me.lblNivelEducativo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNivelEducativo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblNivelEducativo.Location = New System.Drawing.Point(113, 31)
        Me.lblNivelEducativo.Name = "lblNivelEducativo"
        Me.lblNivelEducativo.Size = New System.Drawing.Size(203, 19)
        Me.lblNivelEducativo.TabIndex = 112
        Me.lblNivelEducativo.Text = "Estudios del Paciente"
        Me.lblNivelEducativo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btnGuardar.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_guardar
        Me.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btnGuardar.Location = New System.Drawing.Point(917, 1126)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(84, 33)
        Me.btnGuardar.TabIndex = 200
        Me.btnGuardar.Tag = "37"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(12, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 23)
        Me.Label3.TabIndex = 173
        Me.Label3.Text = "Domicilio"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grbDomicilio
        '
        Me.grbDomicilio.Controls.Add(Me.cmbEstrato)
        Me.grbDomicilio.Controls.Add(Me.lblEstrato)
        Me.grbDomicilio.Controls.Add(Me.cmbTenencia)
        Me.grbDomicilio.Controls.Add(Me.lblTenencia)
        Me.grbDomicilio.Controls.Add(Me.cmbTipoVivienda)
        Me.grbDomicilio.Controls.Add(Me.lblTipoVivienda)
        Me.grbDomicilio.Controls.Add(Me.cmbConvivencia)
        Me.grbDomicilio.Controls.Add(Me.lblConvivencia)
        Me.grbDomicilio.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbDomicilio.ForeColor = System.Drawing.Color.Black
        Me.grbDomicilio.Location = New System.Drawing.Point(6, 8)
        Me.grbDomicilio.Name = "grbDomicilio"
        Me.grbDomicilio.Size = New System.Drawing.Size(1087, 101)
        Me.grbDomicilio.TabIndex = 111
        Me.grbDomicilio.TabStop = False
        '
        'cmbEstrato
        '
        Me.cmbEstrato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstrato.FormattingEnabled = True
        Me.cmbEstrato.Location = New System.Drawing.Point(768, 66)
        Me.cmbEstrato.Name = "cmbEstrato"
        Me.cmbEstrato.Size = New System.Drawing.Size(205, 22)
        Me.cmbEstrato.TabIndex = 4
        '
        'lblEstrato
        '
        Me.lblEstrato.BackColor = System.Drawing.Color.Transparent
        Me.lblEstrato.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstrato.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblEstrato.Location = New System.Drawing.Point(616, 69)
        Me.lblEstrato.Name = "lblEstrato"
        Me.lblEstrato.Size = New System.Drawing.Size(147, 19)
        Me.lblEstrato.TabIndex = 179
        Me.lblEstrato.Text = "Estrato"
        Me.lblEstrato.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTenencia
        '
        Me.cmbTenencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTenencia.FormattingEnabled = True
        Me.cmbTenencia.Location = New System.Drawing.Point(318, 66)
        Me.cmbTenencia.Name = "cmbTenencia"
        Me.cmbTenencia.Size = New System.Drawing.Size(205, 22)
        Me.cmbTenencia.TabIndex = 3
        '
        'lblTenencia
        '
        Me.lblTenencia.BackColor = System.Drawing.Color.Transparent
        Me.lblTenencia.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTenencia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblTenencia.Location = New System.Drawing.Point(111, 69)
        Me.lblTenencia.Name = "lblTenencia"
        Me.lblTenencia.Size = New System.Drawing.Size(200, 19)
        Me.lblTenencia.TabIndex = 177
        Me.lblTenencia.Text = "Tenencia de la Vivienda"
        Me.lblTenencia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipoVivienda
        '
        Me.cmbTipoVivienda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoVivienda.FormattingEnabled = True
        Me.cmbTipoVivienda.Location = New System.Drawing.Point(768, 34)
        Me.cmbTipoVivienda.Name = "cmbTipoVivienda"
        Me.cmbTipoVivienda.Size = New System.Drawing.Size(205, 22)
        Me.cmbTipoVivienda.TabIndex = 2
        '
        'lblTipoVivienda
        '
        Me.lblTipoVivienda.BackColor = System.Drawing.Color.Transparent
        Me.lblTipoVivienda.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoVivienda.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblTipoVivienda.Location = New System.Drawing.Point(616, 37)
        Me.lblTipoVivienda.Name = "lblTipoVivienda"
        Me.lblTipoVivienda.Size = New System.Drawing.Size(100, 19)
        Me.lblTipoVivienda.TabIndex = 175
        Me.lblTipoVivienda.Text = "Tipo Vivienda"
        Me.lblTipoVivienda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbConvivencia
        '
        Me.cmbConvivencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbConvivencia.FormattingEnabled = True
        Me.cmbConvivencia.Location = New System.Drawing.Point(318, 34)
        Me.cmbConvivencia.Name = "cmbConvivencia"
        Me.cmbConvivencia.Size = New System.Drawing.Size(205, 22)
        Me.cmbConvivencia.TabIndex = 1
        '
        'lblConvivencia
        '
        Me.lblConvivencia.BackColor = System.Drawing.Color.Transparent
        Me.lblConvivencia.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConvivencia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblConvivencia.Location = New System.Drawing.Point(111, 37)
        Me.lblConvivencia.Name = "lblConvivencia"
        Me.lblConvivencia.Size = New System.Drawing.Size(209, 19)
        Me.lblConvivencia.TabIndex = 112
        Me.lblConvivencia.Text = "¿Con quién vive el paciente?"
        Me.lblConvivencia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSugerirRespuesta
        '
        Me.btnSugerirRespuesta.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btnSugerirRespuesta.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_proponer1
        Me.btnSugerirRespuesta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSugerirRespuesta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSugerirRespuesta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSugerirRespuesta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSugerirRespuesta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btnSugerirRespuesta.Location = New System.Drawing.Point(931, 5)
        Me.btnSugerirRespuesta.Name = "btnSugerirRespuesta"
        Me.btnSugerirRespuesta.Size = New System.Drawing.Size(163, 33)
        Me.btnSugerirRespuesta.TabIndex = 189
        Me.btnSugerirRespuesta.Tag = "37"
        Me.btnSugerirRespuesta.UseVisualStyleBackColor = False
        '
        'lblTitulo
        '
        Me.lblTitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.lblTitulo.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(11, 10)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(232, 22)
        Me.lblTitulo.TabIndex = 193
        Me.lblTitulo.Text = "Aspectos Sociales"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ParentescoDelIntegranteDeLaFamilia"
        Me.DataGridViewTextBoxColumn1.HeaderText = "IdParentesco"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "tip_doc"
        Me.DataGridViewTextBoxColumn2.HeaderText = "TipoDocumento"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Num_doc"
        Me.DataGridViewTextBoxColumn3.HeaderText = "NumeroDocumento"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "NombreDelIntegranteDeLaFamilia"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Nombre"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 250
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "dscParentescoDelIntegranteDeLaFamilia"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Parentesco"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Visible = False
        Me.DataGridViewTextBoxColumn5.Width = 150
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "EdadDelIntegranteDeLaFamilia"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Edad"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 70
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "dscOcupacionDelIntegranteDeLaFamilia"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Ocupación"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Visible = False
        Me.DataGridViewTextBoxColumn7.Width = 250
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "dscOcupacionDelIntegranteDeLaFamilia"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Ocupación"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Visible = False
        Me.DataGridViewTextBoxColumn8.Width = 250
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "dscOcupacionDelIntegranteDeLaFamilia"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Ocupación"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 250
        '
        'ctlCPAspectosSociales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.btnSugerirRespuesta)
        Me.Controls.Add(Me.Panel16)
        Me.DoubleBuffered = True
        Me.Name = "ctlCPAspectosSociales"
        Me.Size = New System.Drawing.Size(1100, 1225)
        Me.Panel16.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grbFamilia.ResumeLayout(False)
        Me.grbFamilia.PerformLayout()
        CType(Me.dtgFamiliar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbEntornoSocioFamiliar.ResumeLayout(False)
        Me.grbEntornoSocioFamiliar.PerformLayout()
        Me.grbEntorno.ResumeLayout(False)
        Me.grbEntorno.PerformLayout()
        Me.grbDomicilio.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel16 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grbDomicilio As System.Windows.Forms.GroupBox
    Friend WithEvents cmbConvivencia As System.Windows.Forms.ComboBox
    Friend WithEvents lblConvivencia As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents cmbTipoVivienda As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipoVivienda As System.Windows.Forms.Label
    Friend WithEvents cmbEstrato As System.Windows.Forms.ComboBox
    Friend WithEvents lblEstrato As System.Windows.Forms.Label
    Friend WithEvents cmbTenencia As System.Windows.Forms.ComboBox
    Friend WithEvents lblTenencia As System.Windows.Forms.Label
    Friend WithEvents grbEntornoSocioFamiliar As System.Windows.Forms.GroupBox
    Friend WithEvents rbtNoTieneHijos As System.Windows.Forms.RadioButton
    Friend WithEvents rbtSiTieneHijos As System.Windows.Forms.RadioButton
    Friend WithEvents txtNumeroHermanos As HistoriaClinica.TextBoxConFormato
    Friend WithEvents lblNumeroHermanos As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoFamilia As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipoFamilia As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbCondicionMadre As System.Windows.Forms.ComboBox
    Friend WithEvents lblCondicionMadre As System.Windows.Forms.Label
    Friend WithEvents cmbCondicionPadre As System.Windows.Forms.ComboBox
    Friend WithEvents lblCondicionPadre As System.Windows.Forms.Label
    Friend WithEvents txtNumeroIntegrantes As HistoriaClinica.TextBoxConFormato
    Friend WithEvents lblNumeroIntegrantes As System.Windows.Forms.Label
    Friend WithEvents txtPersonasCargo As HistoriaClinica.TextBoxConFormato
    Friend WithEvents lblPersonasCargo As System.Windows.Forms.Label
    Friend WithEvents txtLugarPaciente As HistoriaClinica.TextBoxConFormato
    Friend WithEvents lblLugarPaciente As System.Windows.Forms.Label
    Friend WithEvents grbFamilia As System.Windows.Forms.GroupBox
    Friend WithEvents lnkNuevo As System.Windows.Forms.LinkLabel
    Friend WithEvents txtCodOcupacionFam As HistoriaClinica.TextBoxConFormato
    Friend WithEvents btnAgregarFamiliar As System.Windows.Forms.Button
    Friend WithEvents Label122 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtEdadFamiliar As HistoriaClinica.TextBoxConFormato
    Friend WithEvents lblEdad As System.Windows.Forms.Label
    Friend WithEvents txtNombreFamiliar As HistoriaClinica.TextBoxConFormato
    Friend WithEvents lblNombreFam As System.Windows.Forms.Label
    Friend WithEvents cmbParentesco As System.Windows.Forms.ComboBox
    Friend WithEvents lblParentesco As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNombreCuidador As HistoriaClinica.TextBoxConFormato
    Friend WithEvents lblNombreCuidador As System.Windows.Forms.Label
    Friend WithEvents txtOcupacionCuidador As HistoriaClinica.TextBoxConFormato
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents grbEntorno As System.Windows.Forms.GroupBox
    Friend WithEvents rbtNoTrabajoEstable As System.Windows.Forms.RadioButton
    Friend WithEvents rbtSiTrabajoEstable As System.Windows.Forms.RadioButton
    Friend WithEvents txtOcupacion As HistoriaClinica.TextBoxConFormato
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmbNivelIngresos As System.Windows.Forms.ComboBox
    Friend WithEvents lblNivelIngresos As System.Windows.Forms.Label
    Friend WithEvents lblEstabiliadLaboral As System.Windows.Forms.Label
    Friend WithEvents cmbNivelEducativo As System.Windows.Forms.ComboBox
    Friend WithEvents lblNivelEducativo As System.Windows.Forms.Label
    Friend WithEvents txtDocumento As HistoriaClinica.TextBoxConFormato
    Friend WithEvents lblDocumento As System.Windows.Forms.Label
    Friend WithEvents cmbTipodocumento As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipodocumento As System.Windows.Forms.Label
    Friend WithEvents cmbNivEduCuidador As System.Windows.Forms.ComboBox
    Friend WithEvents lblNivEduCuidador As System.Windows.Forms.Label
    Friend WithEvents cmbParentescoCuidador As System.Windows.Forms.ComboBox
    Friend WithEvents lblParentescoCuidador As System.Windows.Forms.Label
    Friend WithEvents txtDireccionCuidador As HistoriaClinica.TextBoxConFormato
    Friend WithEvents lblDireccionCuidador As System.Windows.Forms.Label
    Friend WithEvents txtPlanIntervencion As HistoriaClinica.TextBoxConFormato
    Friend WithEvents lblPlanIntervencion As System.Windows.Forms.Label
    Friend WithEvents txtProblemasIdentificados As HistoriaClinica.TextBoxConFormato
    Friend WithEvents lblProblemas As System.Windows.Forms.Label
    Friend WithEvents cmbEstadoCivil As System.Windows.Forms.ComboBox
    Friend WithEvents lblEstadoCivil As System.Windows.Forms.Label
    Friend WithEvents cmbOcupacionFam As System.Windows.Forms.ComboBox
    Friend WithEvents cmbOcupacionCuidador As System.Windows.Forms.ComboBox
    Friend WithEvents cmbOcupacion As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnSugerirRespuesta As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnSugerirFamiliares As System.Windows.Forms.Button
    Friend WithEvents dtgFamiliar As System.Windows.Forms.DataGridView
    Friend WithEvents IdPariente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tip_doc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Num_doc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombreDelIntegranteDeLaFamilia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ParentescoDelIntegranteDeLaFamilia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dscParentescoDelIntegranteDeLaFamilia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EdadDelIntegranteDeLaFamilia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OcupacionDelIntegranteDeLaFamilia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dscOcupacionDelIntegranteDeLaFamilia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblTitulo As System.Windows.Forms.Label

End Class
