
'Imports System.Text.RegularExpressions

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtlEgresos
    Inherits System.Windows.Forms.UserControl
    '/// Para el texbox tome solo letras o números \\\
    'Public Sub New()
    '    MyBase.New()
    '    Dim Ctrl As Control
    '    InitializeComponent()
    '    For Each Ctrl In Me.Controls
    '        If TypeOf Ctrl Is TextBox Then
    '            AddHandler Ctrl.KeyPress, AddressOf KeyPressed
    '        End If
    '        If TypeOf Ctrl Is GroupBox Then
    '            RevisarControles(Ctrl)
    '        End If
    '    Next
    'End Sub
    'Private Sub RevisarControles(ByRef CtrlOrigen As Control)
    '    Dim Ctrl As Control
    '    For Each Ctrl In CtrlOrigen.Controls
    '        If TypeOf Ctrl Is TextBox Then
    '            AddHandler Ctrl.KeyPress, AddressOf KeyPressed
    '        End If
    '        If TypeOf Ctrl Is GroupBox Then
    '            RevisarControles(Ctrl)
    '        End If
    '    Next
    'End Sub
    'Private Sub KeyPressed(ByVal o As [Object], ByVal e As KeyPressEventArgs)
    '    If Len(o.Tag) > 0 Then
    '        If Mid(o.Tag, 1, 1) = "N" Then
    '            If Not Regex.IsMatch(e.KeyChar, "[0-9]") Then
    '                e.Handled = True
    '            End If
    '        ElseIf Mid(o.Tag, 1, 1) = "L" Then
    '            If Not Regex.IsMatch(e.KeyChar, "[a-zA-Z]") Then
    '                e.Handled = True
    '            End If
    '        Else
    '            e.Handled = True
    '        End If
    '    End If

    '    Select Case e.KeyChar
    '        Case Convert.ToChar(Keys.Return)
    '            SendKeys.Send("{TAB}")
    '            e.Handled = True
    '        Case Convert.ToChar(Keys.Back)
    '            SendKeys.Send("{LEFT}")
    '            SendKeys.Send("{DELETE}")
    '    End Select
    'End Sub
    '\\\\

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CtlEgresos))
        Me.lbDestino = New System.Windows.Forms.Label()
        Me.gbDatosAdicion = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtObsPostegreso = New System.Windows.Forms.TextBox()
        Me.Txtscroll1 = New System.Windows.Forms.TextBox()
        Me.rbPostEgrNo = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rbPostEgrSi = New System.Windows.Forms.RadioButton()
        Me.lbResumenEvo = New System.Windows.Forms.Label()
        Me.btGrabar = New System.Windows.Forms.Button()
        Me.tbDesDestinoFinal = New HistoriaClinica.TextBoxConFormato()
        Me.tbCodDestinoFinal = New HistoriaClinica.TextBoxConFormato()
        Me.pEstado = New System.Windows.Forms.Panel()
        Me.cbDesMuerte = New HistoriaClinica.ComboBusqueda(Me.components)
        Me.tbCodMuerte = New HistoriaClinica.TextBoxConFormato()
        Me.lbSalida = New System.Windows.Forms.Label()
        Me.rbSalidaVivo = New System.Windows.Forms.RadioButton()
        Me.rbSalidaMuerto = New System.Windows.Forms.RadioButton()
        Me.lbCausaMuerte = New System.Windows.Forms.Label()
        Me.tbEvolucion = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbFecha = New System.Windows.Forms.Label()
        Me.mtFechaInicial = New System.Windows.Forms.MaskedTextBox()
        Me.LnkRec_Egreso = New System.Windows.Forms.LinkLabel()
        Me.LnkIncapacidad = New System.Windows.Forms.LinkLabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComboBusqueda1 = New HistoriaClinica.ComboBusqueda(Me.components)
        Me.ctlDiagnostico = New HistoriaClinica.ctlDiagnosticos()
        Me.gbDatosAdicion.SuspendLayout()
        Me.pEstado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbDestino
        '
        Me.lbDestino.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDestino.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lbDestino.Location = New System.Drawing.Point(5, 158)
        Me.lbDestino.Name = "lbDestino"
        Me.lbDestino.Size = New System.Drawing.Size(99, 22)
        Me.lbDestino.TabIndex = 0
        Me.lbDestino.Text = "Destino final"
        '
        'gbDatosAdicion
        '
        Me.gbDatosAdicion.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.gbDatosAdicion.Controls.Add(Me.Label2)
        Me.gbDatosAdicion.Controls.Add(Me.txtObsPostegreso)
        Me.gbDatosAdicion.Controls.Add(Me.Txtscroll1)
        Me.gbDatosAdicion.Controls.Add(Me.rbPostEgrNo)
        Me.gbDatosAdicion.Controls.Add(Me.Label1)
        Me.gbDatosAdicion.Controls.Add(Me.rbPostEgrSi)
        Me.gbDatosAdicion.Controls.Add(Me.lbResumenEvo)
        Me.gbDatosAdicion.Controls.Add(Me.btGrabar)
        Me.gbDatosAdicion.Controls.Add(Me.tbDesDestinoFinal)
        Me.gbDatosAdicion.Controls.Add(Me.tbCodDestinoFinal)
        Me.gbDatosAdicion.Controls.Add(Me.pEstado)
        Me.gbDatosAdicion.Controls.Add(Me.lbDestino)
        Me.gbDatosAdicion.Controls.Add(Me.tbEvolucion)
        Me.gbDatosAdicion.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosAdicion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.gbDatosAdicion.Location = New System.Drawing.Point(5, 336)
        Me.gbDatosAdicion.Name = "gbDatosAdicion"
        Me.gbDatosAdicion.Size = New System.Drawing.Size(1054, 301)
        Me.gbDatosAdicion.TabIndex = 3
        Me.gbDatosAdicion.TabStop = False
        Me.gbDatosAdicion.Text = "DATOS DEL EGRESO"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(6, 243)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 22)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Observaciones"
        '
        'txtObsPostegreso
        '
        Me.txtObsPostegreso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObsPostegreso.Enabled = False
        Me.txtObsPostegreso.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.txtObsPostegreso.Location = New System.Drawing.Point(136, 234)
        Me.txtObsPostegreso.MaxLength = 100
        Me.txtObsPostegreso.Multiline = True
        Me.txtObsPostegreso.Name = "txtObsPostegreso"
        Me.txtObsPostegreso.Size = New System.Drawing.Size(815, 52)
        Me.txtObsPostegreso.TabIndex = 10
        '
        'Txtscroll1
        '
        Me.Txtscroll1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Txtscroll1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Txtscroll1.Location = New System.Drawing.Point(19, 133)
        Me.Txtscroll1.Name = "Txtscroll1"
        Me.Txtscroll1.Size = New System.Drawing.Size(36, 15)
        Me.Txtscroll1.TabIndex = 9
        Me.Txtscroll1.Visible = False
        '
        'rbPostEgrNo
        '
        Me.rbPostEgrNo.AutoSize = True
        Me.rbPostEgrNo.Location = New System.Drawing.Point(287, 193)
        Me.rbPostEgrNo.Name = "rbPostEgrNo"
        Me.rbPostEgrNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.rbPostEgrNo.Size = New System.Drawing.Size(43, 18)
        Me.rbPostEgrNo.TabIndex = 8
        Me.rbPostEgrNo.Text = "No"
        Me.rbPostEgrNo.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(6, 195)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(195, 18)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Seguimiento Post Egreso"
        '
        'rbPostEgrSi
        '
        Me.rbPostEgrSi.AutoSize = True
        Me.rbPostEgrSi.Location = New System.Drawing.Point(227, 193)
        Me.rbPostEgrSi.Name = "rbPostEgrSi"
        Me.rbPostEgrSi.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.rbPostEgrSi.Size = New System.Drawing.Size(38, 18)
        Me.rbPostEgrSi.TabIndex = 7
        Me.rbPostEgrSi.Text = "Si"
        Me.rbPostEgrSi.UseVisualStyleBackColor = True
        '
        'lbResumenEvo
        '
        Me.lbResumenEvo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbResumenEvo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lbResumenEvo.Location = New System.Drawing.Point(5, 105)
        Me.lbResumenEvo.Name = "lbResumenEvo"
        Me.lbResumenEvo.Size = New System.Drawing.Size(99, 44)
        Me.lbResumenEvo.TabIndex = 0
        Me.lbResumenEvo.Text = "Resumen de evolución"
        '
        'btGrabar
        '
        Me.btGrabar.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btGrabar.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_guardar
        Me.btGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btGrabar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btGrabar.ForeColor = System.Drawing.Color.Transparent
        Me.btGrabar.Location = New System.Drawing.Point(968, 259)
        Me.btGrabar.Name = "btGrabar"
        Me.btGrabar.Size = New System.Drawing.Size(80, 27)
        Me.btGrabar.TabIndex = 6
        Me.btGrabar.UseVisualStyleBackColor = False
        '
        'tbDesDestinoFinal
        '
        Me.tbDesDestinoFinal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.tbDesDestinoFinal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.tbDesDestinoFinal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbDesDestinoFinal.ControlComboEnlace = Nothing
        Me.tbDesDestinoFinal.ControlTextoEnlace = Nothing
        Me.tbDesDestinoFinal.DatoRelacionado = Nothing
        Me.tbDesDestinoFinal.Decimals = CType(0, Byte)
        Me.tbDesDestinoFinal.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.tbDesDestinoFinal.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDesDestinoFinal.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.tbDesDestinoFinal.Location = New System.Drawing.Point(203, 155)
        Me.tbDesDestinoFinal.MaxLength = 100
        Me.tbDesDestinoFinal.Name = "tbDesDestinoFinal"
        Me.tbDesDestinoFinal.NombreCampoBuscado = Nothing
        Me.tbDesDestinoFinal.NombreCampoBusqueda = Nothing
        Me.tbDesDestinoFinal.NombreCampoDatos = Nothing
        Me.tbDesDestinoFinal.Obligatorio = False
        Me.tbDesDestinoFinal.OrigenDeDatos = Nothing
        Me.tbDesDestinoFinal.PermitirValorCero = False
        Me.tbDesDestinoFinal.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Top
        Me.tbDesDestinoFinal.Size = New System.Drawing.Size(460, 22)
        Me.tbDesDestinoFinal.TabIndex = 5
        Me.tbDesDestinoFinal.TipoControl = HistoriaClinica.tbTipoControl.ListaAutoComplete
        Me.tbDesDestinoFinal.UserValues = Nothing
        Me.tbDesDestinoFinal.ValorMaximo = CType(0, Long)
        Me.tbDesDestinoFinal.ValorMinimo = CType(0, Long)
        '
        'tbCodDestinoFinal
        '
        Me.tbCodDestinoFinal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbCodDestinoFinal.ControlComboEnlace = Nothing
        Me.tbCodDestinoFinal.ControlTextoEnlace = Nothing
        Me.tbCodDestinoFinal.DatoRelacionado = Nothing
        Me.tbCodDestinoFinal.Decimals = CType(0, Byte)
        Me.tbCodDestinoFinal.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.tbCodDestinoFinal.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCodDestinoFinal.Format = HistoriaClinica.tbFormats.AlfaNúmericoSinEspacios
        Me.tbCodDestinoFinal.Location = New System.Drawing.Point(112, 155)
        Me.tbCodDestinoFinal.MaxLength = 1
        Me.tbCodDestinoFinal.Name = "tbCodDestinoFinal"
        Me.tbCodDestinoFinal.NombreCampoBuscado = Nothing
        Me.tbCodDestinoFinal.NombreCampoBusqueda = Nothing
        Me.tbCodDestinoFinal.NombreCampoDatos = Nothing
        Me.tbCodDestinoFinal.Obligatorio = False
        Me.tbCodDestinoFinal.OrigenDeDatos = Nothing
        Me.tbCodDestinoFinal.PermitirValorCero = False
        Me.tbCodDestinoFinal.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.tbCodDestinoFinal.Size = New System.Drawing.Size(85, 22)
        Me.tbCodDestinoFinal.TabIndex = 4
        Me.tbCodDestinoFinal.TipoControl = HistoriaClinica.tbTipoControl.CodigoBusqueda
        Me.tbCodDestinoFinal.UserValues = Nothing
        Me.tbCodDestinoFinal.ValorMaximo = CType(0, Long)
        Me.tbCodDestinoFinal.ValorMinimo = CType(0, Long)
        '
        'pEstado
        '
        Me.pEstado.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.pEstado.Controls.Add(Me.cbDesMuerte)
        Me.pEstado.Controls.Add(Me.tbCodMuerte)
        Me.pEstado.Controls.Add(Me.lbSalida)
        Me.pEstado.Controls.Add(Me.rbSalidaVivo)
        Me.pEstado.Controls.Add(Me.rbSalidaMuerto)
        Me.pEstado.Controls.Add(Me.lbCausaMuerte)
        Me.pEstado.ForeColor = System.Drawing.Color.DarkCyan
        Me.pEstado.Location = New System.Drawing.Point(5, 27)
        Me.pEstado.Name = "pEstado"
        Me.pEstado.Size = New System.Drawing.Size(1049, 69)
        Me.pEstado.TabIndex = 2
        '
        'cbDesMuerte
        '
        Me.cbDesMuerte.CampoEnlazado = Nothing
        Me.cbDesMuerte.CampoMostrar = Nothing
        Me.cbDesMuerte.CategoriaDatos = HistoriaClinica.CategoriaDatos.Diagnosticos
        Me.cbDesMuerte.CodigoTipoProcedimiento = Nothing
        Me.cbDesMuerte.ControlTextoEnlace = Nothing
        Me.cbDesMuerte.ControlTieneCache = True
        Me.cbDesMuerte.ConvenioMedicamento = False
        Me.cbDesMuerte.DatoRelacionado = Nothing
        Me.cbDesMuerte.EdadPaciente = 0
        Me.cbDesMuerte.Entidad = Nothing
        Me.cbDesMuerte.EstadoMedicamento = False
        Me.cbDesMuerte.FechaInicialMedicamento = Nothing
        Me.cbDesMuerte.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDesMuerte.FormattingEnabled = True
        Me.cbDesMuerte.Location = New System.Drawing.Point(202, 34)
        Me.cbDesMuerte.Login = Nothing
        Me.cbDesMuerte.Medicamento = Nothing
        Me.cbDesMuerte.Name = "cbDesMuerte"
        Me.cbDesMuerte.Obligatorio = "False"
        Me.cbDesMuerte.Prestador = Nothing
        Me.cbDesMuerte.SeleccionadoConEnter = False
        Me.cbDesMuerte.SexoPaciente = Nothing
        Me.cbDesMuerte.Size = New System.Drawing.Size(456, 22)
        Me.cbDesMuerte.Sucursal = Nothing
        Me.cbDesMuerte.TabIndex = 4
        Me.cbDesMuerte.UltimaDescripcionDeBusqueda = Nothing
        Me.cbDesMuerte.ValorCampoEnlazado = Nothing
        '
        'tbCodMuerte
        '
        Me.tbCodMuerte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbCodMuerte.ControlComboEnlace = Nothing
        Me.tbCodMuerte.ControlTextoEnlace = Nothing
        Me.tbCodMuerte.DatoRelacionado = Nothing
        Me.tbCodMuerte.Decimals = CType(2, Byte)
        Me.tbCodMuerte.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.tbCodMuerte.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCodMuerte.Format = HistoriaClinica.tbFormats.AlfaNúmericoSinEspacios
        Me.tbCodMuerte.Location = New System.Drawing.Point(107, 34)
        Me.tbCodMuerte.MaxLength = 3
        Me.tbCodMuerte.Name = "tbCodMuerte"
        Me.tbCodMuerte.NombreCampoBuscado = Nothing
        Me.tbCodMuerte.NombreCampoBusqueda = Nothing
        Me.tbCodMuerte.NombreCampoDatos = Nothing
        Me.tbCodMuerte.Obligatorio = False
        Me.tbCodMuerte.OrigenDeDatos = Nothing
        Me.tbCodMuerte.PermitirValorCero = False
        Me.tbCodMuerte.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.tbCodMuerte.Size = New System.Drawing.Size(89, 22)
        Me.tbCodMuerte.TabIndex = 3
        Me.tbCodMuerte.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.tbCodMuerte.UserValues = Nothing
        Me.tbCodMuerte.ValorMaximo = CType(0, Long)
        Me.tbCodMuerte.ValorMinimo = CType(0, Long)
        '
        'lbSalida
        '
        Me.lbSalida.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lbSalida.Location = New System.Drawing.Point(5, 10)
        Me.lbSalida.Name = "lbSalida"
        Me.lbSalida.Size = New System.Drawing.Size(134, 18)
        Me.lbSalida.TabIndex = 0
        Me.lbSalida.Text = "Estado a la Salida"
        '
        'rbSalidaVivo
        '
        Me.rbSalidaVivo.AutoSize = True
        Me.rbSalidaVivo.Checked = True
        Me.rbSalidaVivo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.rbSalidaVivo.Location = New System.Drawing.Point(175, 8)
        Me.rbSalidaVivo.Name = "rbSalidaVivo"
        Me.rbSalidaVivo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.rbSalidaVivo.Size = New System.Drawing.Size(54, 18)
        Me.rbSalidaVivo.TabIndex = 1
        Me.rbSalidaVivo.TabStop = True
        Me.rbSalidaVivo.Text = "Vivo"
        Me.rbSalidaVivo.UseVisualStyleBackColor = True
        '
        'rbSalidaMuerto
        '
        Me.rbSalidaMuerto.AutoSize = True
        Me.rbSalidaMuerto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.rbSalidaMuerto.Location = New System.Drawing.Point(254, 10)
        Me.rbSalidaMuerto.Name = "rbSalidaMuerto"
        Me.rbSalidaMuerto.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.rbSalidaMuerto.Size = New System.Drawing.Size(71, 18)
        Me.rbSalidaMuerto.TabIndex = 2
        Me.rbSalidaMuerto.Text = "Muerto"
        Me.rbSalidaMuerto.UseVisualStyleBackColor = True
        '
        'lbCausaMuerte
        '
        Me.lbCausaMuerte.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCausaMuerte.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lbCausaMuerte.Location = New System.Drawing.Point(5, 29)
        Me.lbCausaMuerte.Name = "lbCausaMuerte"
        Me.lbCausaMuerte.Size = New System.Drawing.Size(98, 34)
        Me.lbCausaMuerte.TabIndex = 0
        Me.lbCausaMuerte.Text = "Causa de la muerte"
        '
        'tbEvolucion
        '
        Me.tbEvolucion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbEvolucion.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbEvolucion.Location = New System.Drawing.Point(112, 102)
        Me.tbEvolucion.MaxLength = 2500
        Me.tbEvolucion.Multiline = True
        Me.tbEvolucion.Name = "tbEvolucion"
        Me.tbEvolucion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbEvolucion.Size = New System.Drawing.Size(936, 47)
        Me.tbEvolucion.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Panel1.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.imag_23
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel1.Controls.Add(Me.lbFecha)
        Me.Panel1.Controls.Add(Me.mtFechaInicial)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1100, 35)
        Me.Panel1.TabIndex = 4
        '
        'lbFecha
        '
        Me.lbFecha.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFecha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lbFecha.Location = New System.Drawing.Point(831, 8)
        Me.lbFecha.Name = "lbFecha"
        Me.lbFecha.Size = New System.Drawing.Size(101, 20)
        Me.lbFecha.TabIndex = 49
        Me.lbFecha.Text = "Fecha y Hora"
        Me.lbFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtFechaInicial
        '
        Me.mtFechaInicial.Enabled = False
        Me.mtFechaInicial.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtFechaInicial.Location = New System.Drawing.Point(934, 8)
        Me.mtFechaInicial.Mask = "00/00/0000 00:00"
        Me.mtFechaInicial.Name = "mtFechaInicial"
        Me.mtFechaInicial.Size = New System.Drawing.Size(151, 22)
        Me.mtFechaInicial.TabIndex = 50
        Me.mtFechaInicial.ValidatingType = GetType(Date)
        '
        'LnkRec_Egreso
        '
        Me.LnkRec_Egreso.AutoSize = True
        Me.LnkRec_Egreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LnkRec_Egreso.LinkColor = System.Drawing.Color.Olive
        Me.LnkRec_Egreso.Location = New System.Drawing.Point(506, 15)
        Me.LnkRec_Egreso.Name = "LnkRec_Egreso"
        Me.LnkRec_Egreso.Size = New System.Drawing.Size(205, 16)
        Me.LnkRec_Egreso.TabIndex = 46
        Me.LnkRec_Egreso.TabStop = True
        Me.LnkRec_Egreso.Text = "Ir a Recomendaciones al Egreso"
        Me.LnkRec_Egreso.Visible = False
        '
        'LnkIncapacidad
        '
        Me.LnkIncapacidad.AutoSize = True
        Me.LnkIncapacidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LnkIncapacidad.LinkColor = System.Drawing.Color.Olive
        Me.LnkIncapacidad.Location = New System.Drawing.Point(373, 15)
        Me.LnkIncapacidad.Name = "LnkIncapacidad"
        Me.LnkIncapacidad.Size = New System.Drawing.Size(104, 16)
        Me.LnkIncapacidad.TabIndex = 45
        Me.LnkIncapacidad.TabStop = True
        Me.LnkIncapacidad.Text = "Ir a Incapacidad"
        Me.LnkIncapacidad.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.LnkRec_Egreso)
        Me.Panel2.Controls.Add(Me.LnkIncapacidad)
        Me.Panel2.Location = New System.Drawing.Point(5, 647)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1054, 58)
        Me.Panel2.TabIndex = 47
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "tip_admision"
        Me.DataGridViewTextBoxColumn1.HeaderText = ""
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "ano_adm"
        Me.DataGridViewTextBoxColumn2.HeaderText = ""
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "num_adm"
        Me.DataGridViewTextBoxColumn3.HeaderText = ""
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "tip_diag"
        Me.DataGridViewTextBoxColumn4.HeaderText = ""
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Visible = False
        Me.DataGridViewTextBoxColumn4.Width = 19
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "tDescripcion"
        Me.DataGridViewTextBoxColumn5.HeaderText = "TIPO DIAGNÓSTICO"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 220
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "diagnost"
        Me.DataGridViewTextBoxColumn6.HeaderText = "CÓDIGO"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 130
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "descripcion"
        Me.DataGridViewTextBoxColumn7.FillWeight = 150.0!
        Me.DataGridViewTextBoxColumn7.HeaderText = "DESCRIPCIÓN DIAGNÓSTICO"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 250
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "clasificacion"
        Me.DataGridViewTextBoxColumn8.HeaderText = ""
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Visible = False
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "obs"
        Me.DataGridViewTextBoxColumn9.HeaderText = ""
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Visible = False
        Me.DataGridViewTextBoxColumn9.Width = 19
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "Antecedente"
        Me.DataGridViewTextBoxColumn10.HeaderText = ""
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Visible = False
        Me.DataGridViewTextBoxColumn10.Width = 19
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "confidencial"
        Me.DataGridViewTextBoxColumn11.HeaderText = ""
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Visible = False
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "planManejo"
        Me.DataGridViewTextBoxColumn12.HeaderText = ""
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Visible = False
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "secuencia"
        Me.DataGridViewTextBoxColumn13.HeaderText = ""
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.Visible = False
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "clase_diag"
        Me.DataGridViewTextBoxColumn14.HeaderText = ""
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.Visible = False
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "categoria_diag"
        Me.DataGridViewTextBoxColumn15.FillWeight = 150.0!
        Me.DataGridViewTextBoxColumn15.HeaderText = ""
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        Me.DataGridViewTextBoxColumn15.Visible = False
        Me.DataGridViewTextBoxColumn15.Width = 120
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "fec_hc"
        Me.DataGridViewTextBoxColumn16.HeaderText = ""
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.Visible = False
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "CategoriaDes"
        Me.DataGridViewTextBoxColumn17.HeaderText = "CATEGORÍA"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        Me.DataGridViewTextBoxColumn17.Width = 160
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "Nuevo"
        Me.DataGridViewTextBoxColumn18.HeaderText = ""
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.Visible = False
        '
        'ComboBusqueda1
        '
        Me.ComboBusqueda1.CampoEnlazado = Nothing
        Me.ComboBusqueda1.CampoMostrar = Nothing
        Me.ComboBusqueda1.CategoriaDatos = HistoriaClinica.CategoriaDatos.Diagnosticos
        Me.ComboBusqueda1.CodigoTipoProcedimiento = Nothing
        Me.ComboBusqueda1.ControlTextoEnlace = Nothing
        Me.ComboBusqueda1.ControlTieneCache = True
        Me.ComboBusqueda1.ConvenioMedicamento = False
        Me.ComboBusqueda1.DatoRelacionado = Nothing
        Me.ComboBusqueda1.EdadPaciente = 0
        Me.ComboBusqueda1.Entidad = Nothing
        Me.ComboBusqueda1.EstadoMedicamento = False
        Me.ComboBusqueda1.FechaInicialMedicamento = Nothing
        Me.ComboBusqueda1.FormattingEnabled = True
        Me.ComboBusqueda1.Location = New System.Drawing.Point(161, 51)
        Me.ComboBusqueda1.Login = Nothing
        Me.ComboBusqueda1.Medicamento = Nothing
        Me.ComboBusqueda1.Name = "ComboBusqueda1"
        Me.ComboBusqueda1.Obligatorio = "False"
        Me.ComboBusqueda1.Prestador = Nothing
        Me.ComboBusqueda1.SeleccionadoConEnter = False
        Me.ComboBusqueda1.SexoPaciente = Nothing
        Me.ComboBusqueda1.Size = New System.Drawing.Size(427, 21)
        Me.ComboBusqueda1.Sucursal = Nothing
        Me.ComboBusqueda1.TabIndex = 15
        Me.ComboBusqueda1.UltimaDescripcionDeBusqueda = Nothing
        Me.ComboBusqueda1.ValorCampoEnlazado = Nothing
        '
        'ctlDiagnostico
        '
        Me.ctlDiagnostico.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ctlDiagnostico.Location = New System.Drawing.Point(0, 39)
        Me.ctlDiagnostico.Name = "ctlDiagnostico"
        Me.ctlDiagnostico.pClase_Diag = "E"
        Me.ctlDiagnostico.pDiagnostico = CType(resources.GetObject("ctlDiagnostico.pDiagnostico"), HistoriaClinica.Sophia.HistoriaClinica.Controles.Diagnostico)
        Me.ctlDiagnostico.plstDiagnostico = CType(resources.GetObject("ctlDiagnostico.plstDiagnostico"), System.Collections.Generic.List(Of HistoriaClinica.Sophia.HistoriaClinica.Controles.Diagnostico))
        Me.ctlDiagnostico.Size = New System.Drawing.Size(1086, 296)
        Me.ctlDiagnostico.TabIndex = 48
        '
        'CtlEgresos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Controls.Add(Me.ctlDiagnostico)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.gbDatosAdicion)
        Me.ForeColor = System.Drawing.Color.Transparent
        Me.Location = New System.Drawing.Point(0, 20)
        Me.Name = "CtlEgresos"
        Me.Size = New System.Drawing.Size(1100, 721)
        Me.gbDatosAdicion.ResumeLayout(False)
        Me.gbDatosAdicion.PerformLayout()
        Me.pEstado.ResumeLayout(False)
        Me.pEstado.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbDestino As System.Windows.Forms.Label
    Friend WithEvents gbDatosAdicion As System.Windows.Forms.GroupBox
    Friend WithEvents pEstado As System.Windows.Forms.Panel
    Friend WithEvents lbSalida As System.Windows.Forms.Label
    Friend WithEvents rbSalidaVivo As System.Windows.Forms.RadioButton
    Friend WithEvents rbSalidaMuerto As System.Windows.Forms.RadioButton
    Friend WithEvents lbCausaMuerte As System.Windows.Forms.Label
    Friend WithEvents tbEvolucion As System.Windows.Forms.TextBox
    Friend WithEvents tbCodMuerte As HistoriaClinica.TextBoxConFormato
    Friend WithEvents tbDesDestinoFinal As HistoriaClinica.TextBoxConFormato
    Friend WithEvents tbCodDestinoFinal As HistoriaClinica.TextBoxConFormato
    Friend WithEvents btGrabar As System.Windows.Forms.Button
    Friend WithEvents ComboBusqueda1 As HistoriaClinica.ComboBusqueda
    Friend WithEvents lbResumenEvo As System.Windows.Forms.Label
    Friend WithEvents cbDesMuerte As HistoriaClinica.ComboBusqueda
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rbPostEgrSi As System.Windows.Forms.RadioButton
    Friend WithEvents rbPostEgrNo As System.Windows.Forms.RadioButton
    Friend WithEvents LnkRec_Egreso As System.Windows.Forms.LinkLabel
    Friend WithEvents LnkIncapacidad As System.Windows.Forms.LinkLabel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Txtscroll1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtObsPostegreso As System.Windows.Forms.TextBox
    Friend WithEvents ctlDiagnostico As ctlDiagnosticos
    Friend WithEvents lbFecha As Label
    Friend WithEvents mtFechaInicial As MaskedTextBox

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class
