<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmc_JustificaExcepcion
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmc_JustificaExcepcion))
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtgEquivalente = New System.Windows.Forms.DataGridView
        Me.GrpMedicamento = New System.Windows.Forms.GroupBox
        Me.txtDosis = New HistoriaClinica.TextBoxConFormato
        Me.txtDias = New HistoriaClinica.TextBoxConFormato
        Me.txtForFarma = New HistoriaClinica.TextBoxConFormato
        Me.txtConcentracion = New HistoriaClinica.TextBoxConFormato
        Me.txtPA = New HistoriaClinica.TextBoxConFormato
        Me.txtCodMed = New HistoriaClinica.TextBoxConFormato
        Me.cmbUnidad = New System.Windows.Forms.ComboBox
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.lblDuracion = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.mskFechaHasta = New System.Windows.Forms.MaskedTextBox
        Me.mskFechaDesde = New System.Windows.Forms.MaskedTextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtdescDiagn = New HistoriaClinica.ComboBusqueda(Me.components)
        Me.txtCodDiagn = New HistoriaClinica.TextBoxConFormato
        Me.Label12 = New System.Windows.Forms.Label
        Me.btnBuscarDiag = New System.Windows.Forms.Button
        Me.txtObsDiagn = New HistoriaClinica.TextBoxConFormato
        Me.Label10 = New System.Windows.Forms.Label
        Me.dtgDiagnostico = New System.Windows.Forms.DataGridView
        Me.Label11 = New System.Windows.Forms.Label
        Me.btnAgregar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtJustificacion = New HistoriaClinica.TextBoxConFormato
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dtgEquivalente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpMedicamento.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dtgDiagnostico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(123, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(353, 14)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Ingrese la Justificación para el uso del medicamento"
        '
        'dtgEquivalente
        '
        Me.dtgEquivalente.AllowUserToAddRows = False
        Me.dtgEquivalente.AllowUserToDeleteRows = False
        Me.dtgEquivalente.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgEquivalente.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgEquivalente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgEquivalente.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtgEquivalente.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.dtgEquivalente.Location = New System.Drawing.Point(5, 26)
        Me.dtgEquivalente.Name = "dtgEquivalente"
        Me.dtgEquivalente.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgEquivalente.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dtgEquivalente.Size = New System.Drawing.Size(603, 102)
        Me.dtgEquivalente.TabIndex = 0
        '
        'GrpMedicamento
        '
        Me.GrpMedicamento.Controls.Add(Me.txtDosis)
        Me.GrpMedicamento.Controls.Add(Me.txtDias)
        Me.GrpMedicamento.Controls.Add(Me.txtForFarma)
        Me.GrpMedicamento.Controls.Add(Me.txtConcentracion)
        Me.GrpMedicamento.Controls.Add(Me.txtPA)
        Me.GrpMedicamento.Controls.Add(Me.txtCodMed)
        Me.GrpMedicamento.Controls.Add(Me.cmbUnidad)
        Me.GrpMedicamento.Controls.Add(Me.btnBuscar)
        Me.GrpMedicamento.Controls.Add(Me.lblDuracion)
        Me.GrpMedicamento.Controls.Add(Me.Label9)
        Me.GrpMedicamento.Controls.Add(Me.Label6)
        Me.GrpMedicamento.Controls.Add(Me.Label5)
        Me.GrpMedicamento.Controls.Add(Me.Label4)
        Me.GrpMedicamento.Controls.Add(Me.Label3)
        Me.GrpMedicamento.Controls.Add(Me.Label2)
        Me.GrpMedicamento.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpMedicamento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GrpMedicamento.Location = New System.Drawing.Point(5, 179)
        Me.GrpMedicamento.Name = "GrpMedicamento"
        Me.GrpMedicamento.Size = New System.Drawing.Size(603, 177)
        Me.GrpMedicamento.TabIndex = 1
        Me.GrpMedicamento.TabStop = False
        Me.GrpMedicamento.Text = "Medicamento Equivalente u homólogo en el POS"
        '
        'txtDosis
        '
        Me.txtDosis.ControlComboEnlace = Nothing
        Me.txtDosis.ControlTextoEnlace = Nothing
        Me.txtDosis.DatoRelacionado = Nothing
        Me.txtDosis.Decimals = CType(2, Byte)
        Me.txtDosis.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtDosis.Format = HistoriaClinica.tbFormats.NúmericoDecimalFijoConSigno
        Me.txtDosis.Location = New System.Drawing.Point(322, 116)
        Me.txtDosis.Name = "txtDosis"
        Me.txtDosis.NombreCampoBuscado = Nothing
        Me.txtDosis.NombreCampoBusqueda = Nothing
        Me.txtDosis.NombreCampoDatos = Nothing
        Me.txtDosis.Obligatorio = False
        Me.txtDosis.OrigenDeDatos = Nothing
        Me.txtDosis.PermitirValorCero = False
        Me.txtDosis.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtDosis.Size = New System.Drawing.Size(42, 22)
        Me.txtDosis.TabIndex = 9
        Me.txtDosis.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtDosis.UserValues = Nothing
        Me.txtDosis.ValorMaximo = CType(0, Long)
        Me.txtDosis.ValorMinimo = CType(0, Long)
        '
        'txtDias
        '
        Me.txtDias.ControlComboEnlace = Nothing
        Me.txtDias.ControlTextoEnlace = Nothing
        Me.txtDias.DatoRelacionado = Nothing
        Me.txtDias.Decimals = CType(2, Byte)
        Me.txtDias.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtDias.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.txtDias.Location = New System.Drawing.Point(142, 116)
        Me.txtDias.MaxLength = 3
        Me.txtDias.Name = "txtDias"
        Me.txtDias.NombreCampoBuscado = Nothing
        Me.txtDias.NombreCampoBusqueda = Nothing
        Me.txtDias.NombreCampoDatos = Nothing
        Me.txtDias.Obligatorio = False
        Me.txtDias.OrigenDeDatos = Nothing
        Me.txtDias.PermitirValorCero = False
        Me.txtDias.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtDias.Size = New System.Drawing.Size(48, 22)
        Me.txtDias.TabIndex = 8
        Me.txtDias.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtDias.UserValues = Nothing
        Me.txtDias.ValorMaximo = CType(0, Long)
        Me.txtDias.ValorMinimo = CType(0, Long)
        '
        'txtForFarma
        '
        Me.txtForFarma.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtForFarma.ControlComboEnlace = Nothing
        Me.txtForFarma.ControlTextoEnlace = Nothing
        Me.txtForFarma.DatoRelacionado = Nothing
        Me.txtForFarma.Decimals = CType(2, Byte)
        Me.txtForFarma.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtForFarma.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.txtForFarma.Location = New System.Drawing.Point(142, 84)
        Me.txtForFarma.Name = "txtForFarma"
        Me.txtForFarma.NombreCampoBuscado = Nothing
        Me.txtForFarma.NombreCampoBusqueda = Nothing
        Me.txtForFarma.NombreCampoDatos = Nothing
        Me.txtForFarma.Obligatorio = False
        Me.txtForFarma.OrigenDeDatos = Nothing
        Me.txtForFarma.PermitirValorCero = False
        Me.txtForFarma.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtForFarma.Size = New System.Drawing.Size(377, 22)
        Me.txtForFarma.TabIndex = 7
        Me.txtForFarma.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtForFarma.UserValues = Nothing
        Me.txtForFarma.ValorMaximo = CType(0, Long)
        Me.txtForFarma.ValorMinimo = CType(0, Long)
        '
        'txtConcentracion
        '
        Me.txtConcentracion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConcentracion.ControlComboEnlace = Nothing
        Me.txtConcentracion.ControlTextoEnlace = Nothing
        Me.txtConcentracion.DatoRelacionado = Nothing
        Me.txtConcentracion.Decimals = CType(2, Byte)
        Me.txtConcentracion.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtConcentracion.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.txtConcentracion.Location = New System.Drawing.Point(142, 56)
        Me.txtConcentracion.Name = "txtConcentracion"
        Me.txtConcentracion.NombreCampoBuscado = Nothing
        Me.txtConcentracion.NombreCampoBusqueda = Nothing
        Me.txtConcentracion.NombreCampoDatos = Nothing
        Me.txtConcentracion.Obligatorio = False
        Me.txtConcentracion.OrigenDeDatos = Nothing
        Me.txtConcentracion.PermitirValorCero = False
        Me.txtConcentracion.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtConcentracion.Size = New System.Drawing.Size(377, 22)
        Me.txtConcentracion.TabIndex = 6
        Me.txtConcentracion.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtConcentracion.UserValues = Nothing
        Me.txtConcentracion.ValorMaximo = CType(0, Long)
        Me.txtConcentracion.ValorMinimo = CType(0, Long)
        '
        'txtPA
        '
        Me.txtPA.ControlComboEnlace = Nothing
        Me.txtPA.ControlTextoEnlace = Nothing
        Me.txtPA.DatoRelacionado = Nothing
        Me.txtPA.Decimals = CType(2, Byte)
        Me.txtPA.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtPA.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.txtPA.Location = New System.Drawing.Point(221, 27)
        Me.txtPA.Name = "txtPA"
        Me.txtPA.NombreCampoBuscado = Nothing
        Me.txtPA.NombreCampoBusqueda = Nothing
        Me.txtPA.NombreCampoDatos = Nothing
        Me.txtPA.Obligatorio = False
        Me.txtPA.OrigenDeDatos = Nothing
        Me.txtPA.PermitirValorCero = False
        Me.txtPA.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtPA.Size = New System.Drawing.Size(298, 22)
        Me.txtPA.TabIndex = 4
        Me.txtPA.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtPA.UserValues = Nothing
        Me.txtPA.ValorMaximo = CType(0, Long)
        Me.txtPA.ValorMinimo = CType(0, Long)
        '
        'txtCodMed
        '
        Me.txtCodMed.ControlComboEnlace = Nothing
        Me.txtCodMed.ControlTextoEnlace = Nothing
        Me.txtCodMed.DatoRelacionado = Nothing
        Me.txtCodMed.Decimals = CType(2, Byte)
        Me.txtCodMed.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtCodMed.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.txtCodMed.Location = New System.Drawing.Point(142, 27)
        Me.txtCodMed.Name = "txtCodMed"
        Me.txtCodMed.NombreCampoBuscado = Nothing
        Me.txtCodMed.NombreCampoBusqueda = Nothing
        Me.txtCodMed.NombreCampoDatos = Nothing
        Me.txtCodMed.Obligatorio = False
        Me.txtCodMed.OrigenDeDatos = Nothing
        Me.txtCodMed.PermitirValorCero = False
        Me.txtCodMed.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtCodMed.Size = New System.Drawing.Size(73, 22)
        Me.txtCodMed.TabIndex = 3
        Me.txtCodMed.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtCodMed.UserValues = Nothing
        Me.txtCodMed.ValorMaximo = CType(0, Long)
        Me.txtCodMed.ValorMinimo = CType(0, Long)
        '
        'cmbUnidad
        '
        Me.cmbUnidad.FormattingEnabled = True
        Me.cmbUnidad.Location = New System.Drawing.Point(370, 116)
        Me.cmbUnidad.Name = "cmbUnidad"
        Me.cmbUnidad.Size = New System.Drawing.Size(127, 22)
        Me.cmbUnidad.TabIndex = 10
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.Color.Transparent
        Me.btnBuscar.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_buscar
        Me.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscar.ForeColor = System.Drawing.Color.Transparent
        Me.btnBuscar.Location = New System.Drawing.Point(520, 19)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(78, 31)
        Me.btnBuscar.TabIndex = 5
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'lblDuracion
        '
        Me.lblDuracion.AutoSize = True
        Me.lblDuracion.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDuracion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblDuracion.Location = New System.Drawing.Point(306, 148)
        Me.lblDuracion.Name = "lblDuracion"
        Me.lblDuracion.Size = New System.Drawing.Size(0, 16)
        Me.lblDuracion.TabIndex = 14
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(112, 148)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(200, 16)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Duración del Tratamiento: "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(224, 119)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 14)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Dosis X Dia"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(2, 119)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 14)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Dias Tratamiento"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(1, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(142, 14)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Forma Farmaceutica"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(1, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 14)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Concentración"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(1, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 14)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Principio Activo"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.mskFechaHasta)
        Me.GroupBox2.Controls.Add(Me.mskFechaDesde)
        Me.GroupBox2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(5, 128)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(603, 51)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Duración Tratamiento"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(294, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 14)
        Me.Label8.TabIndex = 67
        Me.Label8.Text = "Hasta"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(41, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 14)
        Me.Label7.TabIndex = 66
        Me.Label7.Text = "Desde"
        '
        'mskFechaHasta
        '
        Me.mskFechaHasta.Enabled = False
        Me.mskFechaHasta.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskFechaHasta.Location = New System.Drawing.Point(362, 20)
        Me.mskFechaHasta.Mask = "00/00/0000"
        Me.mskFechaHasta.Name = "mskFechaHasta"
        Me.mskFechaHasta.Size = New System.Drawing.Size(90, 21)
        Me.mskFechaHasta.TabIndex = 2
        Me.mskFechaHasta.ValidatingType = GetType(Date)
        '
        'mskFechaDesde
        '
        Me.mskFechaDesde.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskFechaDesde.Location = New System.Drawing.Point(114, 20)
        Me.mskFechaDesde.Mask = "00/00/0000"
        Me.mskFechaDesde.Name = "mskFechaDesde"
        Me.mskFechaDesde.Size = New System.Drawing.Size(90, 21)
        Me.mskFechaDesde.TabIndex = 1
        Me.mskFechaDesde.ValidatingType = GetType(Date)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtdescDiagn)
        Me.GroupBox1.Controls.Add(Me.txtCodDiagn)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.btnBuscarDiag)
        Me.GroupBox1.Controls.Add(Me.txtObsDiagn)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.dtgDiagnostico)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(5, 359)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(603, 229)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Diagnóstico para el uso del medicamento"
        '
        'txtdescDiagn
        '
        Me.txtdescDiagn.CampoEnlazado = Nothing
        Me.txtdescDiagn.CampoMostrar = Nothing
        Me.txtdescDiagn.CategoriaDatos = HistoriaClinica.CategoriaDatos.Diagnosticos
        Me.txtdescDiagn.CodigoTipoProcedimiento = Nothing
        Me.txtdescDiagn.ControlTextoEnlace = Nothing
        Me.txtdescDiagn.ControlTieneCache = True
        Me.txtdescDiagn.ConvenioMedicamento = False
        Me.txtdescDiagn.DatoRelacionado = Nothing
        Me.txtdescDiagn.EdadPaciente = 0
        Me.txtdescDiagn.Entidad = Nothing
        Me.txtdescDiagn.EstadoMedicamento = False
        Me.txtdescDiagn.FechaInicialMedicamento = Nothing
        Me.txtdescDiagn.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdescDiagn.FormattingEnabled = True
        Me.txtdescDiagn.Location = New System.Drawing.Point(186, 143)
        Me.txtdescDiagn.Login = Nothing
        Me.txtdescDiagn.MaxLength = 300
        Me.txtdescDiagn.Medicamento = Nothing
        Me.txtdescDiagn.Name = "txtdescDiagn"
        Me.txtdescDiagn.Obligatorio = "True"
        Me.txtdescDiagn.OrigenDeDatos = Nothing
        Me.txtdescDiagn.Prestador = Nothing
        Me.txtdescDiagn.SeleccionadoConEnter = False
        Me.txtdescDiagn.SexoPaciente = Nothing
        Me.txtdescDiagn.Size = New System.Drawing.Size(333, 22)
        Me.txtdescDiagn.Sucursal = Nothing
        Me.txtdescDiagn.TabIndex = 70
        Me.txtdescDiagn.UltimaDescripcionDeBusqueda = Nothing
        Me.txtdescDiagn.ValorCampoEnlazado = Nothing
        '
        'txtCodDiagn
        '
        Me.txtCodDiagn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodDiagn.ControlComboEnlace = Nothing
        Me.txtCodDiagn.ControlTextoEnlace = Nothing
        Me.txtCodDiagn.DatoRelacionado = Nothing
        Me.txtCodDiagn.Decimals = CType(2, Byte)
        Me.txtCodDiagn.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtCodDiagn.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodDiagn.Format = HistoriaClinica.tbFormats.AlfaNúmericoSinEspacios
        Me.txtCodDiagn.Location = New System.Drawing.Point(105, 143)
        Me.txtCodDiagn.MaxLength = 6
        Me.txtCodDiagn.Name = "txtCodDiagn"
        Me.txtCodDiagn.NombreCampoBuscado = Nothing
        Me.txtCodDiagn.NombreCampoBusqueda = Nothing
        Me.txtCodDiagn.NombreCampoDatos = Nothing
        Me.txtCodDiagn.Obligatorio = True
        Me.txtCodDiagn.OrigenDeDatos = Nothing
        Me.txtCodDiagn.PermitirValorCero = False
        Me.txtCodDiagn.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtCodDiagn.Size = New System.Drawing.Size(82, 22)
        Me.txtCodDiagn.TabIndex = 69
        Me.txtCodDiagn.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtCodDiagn.UserValues = Nothing
        Me.txtCodDiagn.ValorMaximo = CType(0, Long)
        Me.txtCodDiagn.ValorMinimo = CType(0, Long)
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(7, 175)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(90, 14)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "Observación"
        '
        'btnBuscarDiag
        '
        Me.btnBuscarDiag.BackColor = System.Drawing.Color.Transparent
        Me.btnBuscarDiag.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_buscar
        Me.btnBuscarDiag.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnBuscarDiag.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscarDiag.ForeColor = System.Drawing.Color.Transparent
        Me.btnBuscarDiag.Location = New System.Drawing.Point(520, 138)
        Me.btnBuscarDiag.Name = "btnBuscarDiag"
        Me.btnBuscarDiag.Size = New System.Drawing.Size(78, 34)
        Me.btnBuscarDiag.TabIndex = 17
        Me.btnBuscarDiag.UseVisualStyleBackColor = False
        '
        'txtObsDiagn
        '
        Me.txtObsDiagn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObsDiagn.ControlComboEnlace = Nothing
        Me.txtObsDiagn.ControlTextoEnlace = Nothing
        Me.txtObsDiagn.DatoRelacionado = Nothing
        Me.txtObsDiagn.Decimals = CType(2, Byte)
        Me.txtObsDiagn.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtObsDiagn.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.txtObsDiagn.Location = New System.Drawing.Point(104, 172)
        Me.txtObsDiagn.MaxLength = 100
        Me.txtObsDiagn.Multiline = True
        Me.txtObsDiagn.Name = "txtObsDiagn"
        Me.txtObsDiagn.NombreCampoBuscado = Nothing
        Me.txtObsDiagn.NombreCampoBusqueda = Nothing
        Me.txtObsDiagn.NombreCampoDatos = Nothing
        Me.txtObsDiagn.Obligatorio = False
        Me.txtObsDiagn.OrigenDeDatos = Nothing
        Me.txtObsDiagn.PermitirValorCero = False
        Me.txtObsDiagn.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtObsDiagn.Size = New System.Drawing.Size(415, 47)
        Me.txtObsDiagn.TabIndex = 14
        Me.txtObsDiagn.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtObsDiagn.UserValues = Nothing
        Me.txtObsDiagn.ValorMaximo = CType(0, Long)
        Me.txtObsDiagn.ValorMinimo = CType(0, Long)
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(6, 146)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 14)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Diagnóstico"
        '
        'dtgDiagnostico
        '
        Me.dtgDiagnostico.AllowUserToAddRows = False
        Me.dtgDiagnostico.AllowUserToDeleteRows = False
        Me.dtgDiagnostico.BackgroundColor = System.Drawing.Color.White
        Me.dtgDiagnostico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgDiagnostico.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.dtgDiagnostico.Location = New System.Drawing.Point(7, 19)
        Me.dtgDiagnostico.Name = "dtgDiagnostico"
        Me.dtgDiagnostico.ReadOnly = True
        Me.dtgDiagnostico.Size = New System.Drawing.Size(586, 112)
        Me.dtgDiagnostico.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(7, 590)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(89, 14)
        Me.Label11.TabIndex = 18
        Me.Label11.Text = "Justificación"
        '
        'btnAgregar
        '
        Me.btnAgregar.BackgroundImage = CType(resources.GetObject("btnAgregar.BackgroundImage"), System.Drawing.Image)
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.ForeColor = System.Drawing.Color.Transparent
        Me.btnAgregar.ImageKey = "(none)"
        Me.btnAgregar.Location = New System.Drawing.Point(9, 7)
        Me.btnAgregar.Margin = New System.Windows.Forms.Padding(0)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(74, 23)
        Me.btnAgregar.TabIndex = 16
        Me.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_cancelar2
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.ForeColor = System.Drawing.Color.Transparent
        Me.btnCancelar.Location = New System.Drawing.Point(91, 8)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(67, 23)
        Me.btnCancelar.TabIndex = 42
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnAgregar)
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Location = New System.Drawing.Point(445, 702)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(163, 36)
        Me.Panel1.TabIndex = 43
        '
        'txtJustificacion
        '
        Me.txtJustificacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtJustificacion.ControlComboEnlace = Nothing
        Me.txtJustificacion.ControlTextoEnlace = Nothing
        Me.txtJustificacion.DatoRelacionado = Nothing
        Me.txtJustificacion.Decimals = CType(2, Byte)
        Me.txtJustificacion.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtJustificacion.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.txtJustificacion.Location = New System.Drawing.Point(5, 609)
        Me.txtJustificacion.MaxLength = 500
        Me.txtJustificacion.Multiline = True
        Me.txtJustificacion.Name = "txtJustificacion"
        Me.txtJustificacion.NombreCampoBuscado = Nothing
        Me.txtJustificacion.NombreCampoBusqueda = Nothing
        Me.txtJustificacion.NombreCampoDatos = Nothing
        Me.txtJustificacion.Obligatorio = False
        Me.txtJustificacion.OrigenDeDatos = Nothing
        Me.txtJustificacion.PermitirValorCero = False
        Me.txtJustificacion.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtJustificacion.Size = New System.Drawing.Size(603, 91)
        Me.txtJustificacion.TabIndex = 15
        Me.txtJustificacion.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtJustificacion.UserValues = Nothing
        Me.txtJustificacion.ValorMaximo = CType(0, Long)
        Me.txtJustificacion.ValorMinimo = CType(0, Long)
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "producto_equiv"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Código"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "descripcion"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Descripcion"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 300
        '
        'frmc_JustificaExcepcion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(616, 739)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtJustificacion)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GrpMedicamento)
        Me.Controls.Add(Me.dtgEquivalente)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmc_JustificaExcepcion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Excepciones"
        CType(Me.dtgEquivalente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpMedicamento.ResumeLayout(False)
        Me.GrpMedicamento.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dtgDiagnostico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtgEquivalente As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GrpMedicamento As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents mskFechaHasta As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mskFechaDesde As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblDuracion As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtgDiagnostico As System.Windows.Forms.DataGridView
    Friend WithEvents txtObsDiagn As HistoriaClinica.TextBoxConFormato
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtJustificacion As HistoriaClinica.TextBoxConFormato
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnBuscarDiag As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbUnidad As System.Windows.Forms.ComboBox
    Friend WithEvents txtPA As HistoriaClinica.TextBoxConFormato
    Friend WithEvents txtCodMed As HistoriaClinica.TextBoxConFormato
    Friend WithEvents txtDosis As HistoriaClinica.TextBoxConFormato
    Friend WithEvents txtDias As HistoriaClinica.TextBoxConFormato
    Friend WithEvents txtForFarma As HistoriaClinica.TextBoxConFormato
    Friend WithEvents txtConcentracion As HistoriaClinica.TextBoxConFormato
    Friend WithEvents txtdescDiagn As HistoriaClinica.ComboBusqueda
    Friend WithEvents txtCodDiagn As HistoriaClinica.TextBoxConFormato

End Class
