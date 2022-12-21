<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlInsercionCateter
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
        Me.grpInsercionCateter = New System.Windows.Forms.GroupBox()
        Me.chklistComplicaciones = New System.Windows.Forms.CheckedListBox()
        Me.chklistIndicaciones = New System.Windows.Forms.CheckedListBox()
        Me.LblReqNumPunciones = New System.Windows.Forms.Label()
        Me.lblReqIndicaciones = New System.Windows.Forms.Label()
        Me.lblReqLateralidad = New System.Windows.Forms.Label()
        Me.lblReqCalibreCateter = New System.Windows.Forms.Label()
        Me.lblReqZonaInsercion = New System.Windows.Forms.Label()
        Me.lblReqTipoCateter = New System.Windows.Forms.Label()
        Me.lblReqFechaHoraInsercionCateter = New System.Windows.Forms.Label()
        Me.cboTipoCateter = New System.Windows.Forms.ComboBox()
        Me.cbCalibreCateter = New System.Windows.Forms.ComboBox()
        Me.cboNumeroPunciones = New System.Windows.Forms.ComboBox()
        Me.cboZonaInsercion = New System.Windows.Forms.ComboBox()
        Me.mskFecHoraInsercion = New System.Windows.Forms.MaskedTextBox()
        Me.lblFechaHoraInsercion = New System.Windows.Forms.Label()
        Me.btnGuardarInsercion = New System.Windows.Forms.Button()
        Me.lblNumPunciones = New System.Windows.Forms.Label()
        Me.lblIndicaciones = New System.Windows.Forms.Label()
        Me.cmbLateralidad = New System.Windows.Forms.ComboBox()
        Me.lblLateralidad = New System.Windows.Forms.Label()
        Me.lblCalibre = New System.Windows.Forms.Label()
        Me.lblComplicaciones = New System.Windows.Forms.Label()
        Me.lblZonaInsercion = New System.Windows.Forms.Label()
        Me.lblTipoCateterIns = New System.Windows.Forms.Label()
        Me.grpInsercionCateter.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpInsercionCateter
        '
        Me.grpInsercionCateter.Controls.Add(Me.chklistComplicaciones)
        Me.grpInsercionCateter.Controls.Add(Me.chklistIndicaciones)
        Me.grpInsercionCateter.Controls.Add(Me.LblReqNumPunciones)
        Me.grpInsercionCateter.Controls.Add(Me.lblReqIndicaciones)
        Me.grpInsercionCateter.Controls.Add(Me.lblReqLateralidad)
        Me.grpInsercionCateter.Controls.Add(Me.lblReqCalibreCateter)
        Me.grpInsercionCateter.Controls.Add(Me.lblReqZonaInsercion)
        Me.grpInsercionCateter.Controls.Add(Me.lblReqTipoCateter)
        Me.grpInsercionCateter.Controls.Add(Me.lblReqFechaHoraInsercionCateter)
        Me.grpInsercionCateter.Controls.Add(Me.cboTipoCateter)
        Me.grpInsercionCateter.Controls.Add(Me.cbCalibreCateter)
        Me.grpInsercionCateter.Controls.Add(Me.cboNumeroPunciones)
        Me.grpInsercionCateter.Controls.Add(Me.cboZonaInsercion)
        Me.grpInsercionCateter.Controls.Add(Me.mskFecHoraInsercion)
        Me.grpInsercionCateter.Controls.Add(Me.lblFechaHoraInsercion)
        Me.grpInsercionCateter.Controls.Add(Me.btnGuardarInsercion)
        Me.grpInsercionCateter.Controls.Add(Me.lblNumPunciones)
        Me.grpInsercionCateter.Controls.Add(Me.lblIndicaciones)
        Me.grpInsercionCateter.Controls.Add(Me.cmbLateralidad)
        Me.grpInsercionCateter.Controls.Add(Me.lblLateralidad)
        Me.grpInsercionCateter.Controls.Add(Me.lblCalibre)
        Me.grpInsercionCateter.Controls.Add(Me.lblComplicaciones)
        Me.grpInsercionCateter.Controls.Add(Me.lblZonaInsercion)
        Me.grpInsercionCateter.Controls.Add(Me.lblTipoCateterIns)
        Me.grpInsercionCateter.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grpInsercionCateter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.grpInsercionCateter.Location = New System.Drawing.Point(0, 3)
        Me.grpInsercionCateter.Name = "grpInsercionCateter"
        Me.grpInsercionCateter.Size = New System.Drawing.Size(627, 357)
        Me.grpInsercionCateter.TabIndex = 182
        Me.grpInsercionCateter.TabStop = False
        Me.grpInsercionCateter.Text = "Inserción de Catéter"
        '
        'chklistComplicaciones
        '
        Me.chklistComplicaciones.CheckOnClick = True
        Me.chklistComplicaciones.FormattingEnabled = True
        Me.chklistComplicaciones.Location = New System.Drawing.Point(199, 227)
        Me.chklistComplicaciones.Name = "chklistComplicaciones"
        Me.chklistComplicaciones.Size = New System.Drawing.Size(416, 72)
        Me.chklistComplicaciones.TabIndex = 8
        '
        'chklistIndicaciones
        '
        Me.chklistIndicaciones.CheckOnClick = True
        Me.chklistIndicaciones.FormattingEnabled = True
        Me.chklistIndicaciones.Location = New System.Drawing.Point(199, 133)
        Me.chklistIndicaciones.Name = "chklistIndicaciones"
        Me.chklistIndicaciones.Size = New System.Drawing.Size(416, 72)
        Me.chklistIndicaciones.TabIndex = 7
        '
        'LblReqNumPunciones
        '
        Me.LblReqNumPunciones.AutoSize = True
        Me.LblReqNumPunciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReqNumPunciones.ForeColor = System.Drawing.Color.Salmon
        Me.LblReqNumPunciones.Location = New System.Drawing.Point(502, 96)
        Me.LblReqNumPunciones.Name = "LblReqNumPunciones"
        Me.LblReqNumPunciones.Size = New System.Drawing.Size(13, 15)
        Me.LblReqNumPunciones.TabIndex = 301
        Me.LblReqNumPunciones.Text = "*"
        '
        'lblReqIndicaciones
        '
        Me.lblReqIndicaciones.AutoSize = True
        Me.lblReqIndicaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReqIndicaciones.ForeColor = System.Drawing.Color.Salmon
        Me.lblReqIndicaciones.Location = New System.Drawing.Point(127, 160)
        Me.lblReqIndicaciones.Name = "lblReqIndicaciones"
        Me.lblReqIndicaciones.Size = New System.Drawing.Size(13, 15)
        Me.lblReqIndicaciones.TabIndex = 300
        Me.lblReqIndicaciones.Text = "*"
        '
        'lblReqLateralidad
        '
        Me.lblReqLateralidad.AutoSize = True
        Me.lblReqLateralidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReqLateralidad.ForeColor = System.Drawing.Color.Salmon
        Me.lblReqLateralidad.Location = New System.Drawing.Point(127, 102)
        Me.lblReqLateralidad.Name = "lblReqLateralidad"
        Me.lblReqLateralidad.Size = New System.Drawing.Size(13, 15)
        Me.lblReqLateralidad.TabIndex = 299
        Me.lblReqLateralidad.Text = "*"
        '
        'lblReqCalibreCateter
        '
        Me.lblReqCalibreCateter.AutoSize = True
        Me.lblReqCalibreCateter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReqCalibreCateter.ForeColor = System.Drawing.Color.Salmon
        Me.lblReqCalibreCateter.Location = New System.Drawing.Point(502, 66)
        Me.lblReqCalibreCateter.Name = "lblReqCalibreCateter"
        Me.lblReqCalibreCateter.Size = New System.Drawing.Size(13, 15)
        Me.lblReqCalibreCateter.TabIndex = 298
        Me.lblReqCalibreCateter.Text = "*"
        '
        'lblReqZonaInsercion
        '
        Me.lblReqZonaInsercion.AutoSize = True
        Me.lblReqZonaInsercion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReqZonaInsercion.ForeColor = System.Drawing.Color.Salmon
        Me.lblReqZonaInsercion.Location = New System.Drawing.Point(127, 64)
        Me.lblReqZonaInsercion.Name = "lblReqZonaInsercion"
        Me.lblReqZonaInsercion.Size = New System.Drawing.Size(13, 15)
        Me.lblReqZonaInsercion.TabIndex = 297
        Me.lblReqZonaInsercion.Text = "*"
        '
        'lblReqTipoCateter
        '
        Me.lblReqTipoCateter.AutoSize = True
        Me.lblReqTipoCateter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReqTipoCateter.ForeColor = System.Drawing.Color.Salmon
        Me.lblReqTipoCateter.Location = New System.Drawing.Point(361, 28)
        Me.lblReqTipoCateter.Name = "lblReqTipoCateter"
        Me.lblReqTipoCateter.Size = New System.Drawing.Size(13, 15)
        Me.lblReqTipoCateter.TabIndex = 296
        Me.lblReqTipoCateter.Text = "*"
        '
        'lblReqFechaHoraInsercionCateter
        '
        Me.lblReqFechaHoraInsercionCateter.AutoSize = True
        Me.lblReqFechaHoraInsercionCateter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReqFechaHoraInsercionCateter.ForeColor = System.Drawing.Color.Salmon
        Me.lblReqFechaHoraInsercionCateter.Location = New System.Drawing.Point(127, 28)
        Me.lblReqFechaHoraInsercionCateter.Name = "lblReqFechaHoraInsercionCateter"
        Me.lblReqFechaHoraInsercionCateter.Size = New System.Drawing.Size(13, 15)
        Me.lblReqFechaHoraInsercionCateter.TabIndex = 295
        Me.lblReqFechaHoraInsercionCateter.Text = "*"
        '
        'cboTipoCateter
        '
        Me.cboTipoCateter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoCateter.FormattingEnabled = True
        Me.cboTipoCateter.Location = New System.Drawing.Point(382, 25)
        Me.cboTipoCateter.Name = "cboTipoCateter"
        Me.cboTipoCateter.Size = New System.Drawing.Size(234, 22)
        Me.cboTipoCateter.TabIndex = 2
        '
        'cbCalibreCateter
        '
        Me.cbCalibreCateter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCalibreCateter.FormattingEnabled = True
        Me.cbCalibreCateter.Location = New System.Drawing.Point(518, 60)
        Me.cbCalibreCateter.Name = "cbCalibreCateter"
        Me.cbCalibreCateter.Size = New System.Drawing.Size(97, 22)
        Me.cbCalibreCateter.TabIndex = 4
        '
        'cboNumeroPunciones
        '
        Me.cboNumeroPunciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNumeroPunciones.FormattingEnabled = True
        Me.cboNumeroPunciones.Location = New System.Drawing.Point(518, 94)
        Me.cboNumeroPunciones.Name = "cboNumeroPunciones"
        Me.cboNumeroPunciones.Size = New System.Drawing.Size(97, 22)
        Me.cboNumeroPunciones.TabIndex = 6
        '
        'cboZonaInsercion
        '
        Me.cboZonaInsercion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZonaInsercion.FormattingEnabled = True
        Me.cboZonaInsercion.Location = New System.Drawing.Point(145, 62)
        Me.cboZonaInsercion.Name = "cboZonaInsercion"
        Me.cboZonaInsercion.Size = New System.Drawing.Size(227, 22)
        Me.cboZonaInsercion.TabIndex = 3
        '
        'mskFecHoraInsercion
        '
        Me.mskFecHoraInsercion.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskFecHoraInsercion.Location = New System.Drawing.Point(145, 26)
        Me.mskFecHoraInsercion.Mask = "00/00/0000 00:00"
        Me.mskFecHoraInsercion.Name = "mskFecHoraInsercion"
        Me.mskFecHoraInsercion.Size = New System.Drawing.Size(118, 21)
        Me.mskFecHoraInsercion.TabIndex = 1
        Me.mskFecHoraInsercion.ValidatingType = GetType(Date)
        '
        'lblFechaHoraInsercion
        '
        Me.lblFechaHoraInsercion.BackColor = System.Drawing.Color.Transparent
        Me.lblFechaHoraInsercion.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaHoraInsercion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblFechaHoraInsercion.Location = New System.Drawing.Point(2, 27)
        Me.lblFechaHoraInsercion.Name = "lblFechaHoraInsercion"
        Me.lblFechaHoraInsercion.Size = New System.Drawing.Size(113, 19)
        Me.lblFechaHoraInsercion.TabIndex = 294
        Me.lblFechaHoraInsercion.Text = "Fecha/Hora"
        Me.lblFechaHoraInsercion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnGuardarInsercion
        '
        Me.btnGuardarInsercion.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnGuardarInsercion.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btnGuardarInsercion.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_guardar
        Me.btnGuardarInsercion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnGuardarInsercion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardarInsercion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardarInsercion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarInsercion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btnGuardarInsercion.Location = New System.Drawing.Point(539, 315)
        Me.btnGuardarInsercion.Name = "btnGuardarInsercion"
        Me.btnGuardarInsercion.Size = New System.Drawing.Size(77, 23)
        Me.btnGuardarInsercion.TabIndex = 9
        Me.btnGuardarInsercion.UseVisualStyleBackColor = True
        '
        'lblNumPunciones
        '
        Me.lblNumPunciones.BackColor = System.Drawing.Color.Transparent
        Me.lblNumPunciones.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumPunciones.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblNumPunciones.Location = New System.Drawing.Point(380, 96)
        Me.lblNumPunciones.Name = "lblNumPunciones"
        Me.lblNumPunciones.Size = New System.Drawing.Size(121, 17)
        Me.lblNumPunciones.TabIndex = 182
        Me.lblNumPunciones.Text = "No. de Punciones"
        Me.lblNumPunciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIndicaciones
        '
        Me.lblIndicaciones.BackColor = System.Drawing.Color.Transparent
        Me.lblIndicaciones.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIndicaciones.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblIndicaciones.Location = New System.Drawing.Point(29, 157)
        Me.lblIndicaciones.Name = "lblIndicaciones"
        Me.lblIndicaciones.Size = New System.Drawing.Size(93, 19)
        Me.lblIndicaciones.TabIndex = 221
        Me.lblIndicaciones.Text = "Indicaciones"
        Me.lblIndicaciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbLateralidad
        '
        Me.cmbLateralidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLateralidad.FormattingEnabled = True
        Me.cmbLateralidad.Location = New System.Drawing.Point(145, 96)
        Me.cmbLateralidad.Name = "cmbLateralidad"
        Me.cmbLateralidad.Size = New System.Drawing.Size(227, 22)
        Me.cmbLateralidad.TabIndex = 5
        '
        'lblLateralidad
        '
        Me.lblLateralidad.BackColor = System.Drawing.Color.Transparent
        Me.lblLateralidad.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLateralidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblLateralidad.Location = New System.Drawing.Point(28, 100)
        Me.lblLateralidad.Name = "lblLateralidad"
        Me.lblLateralidad.Size = New System.Drawing.Size(87, 19)
        Me.lblLateralidad.TabIndex = 218
        Me.lblLateralidad.Text = "Lateralidad"
        Me.lblLateralidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCalibre
        '
        Me.lblCalibre.BackColor = System.Drawing.Color.Transparent
        Me.lblCalibre.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCalibre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblCalibre.Location = New System.Drawing.Point(380, 62)
        Me.lblCalibre.Name = "lblCalibre"
        Me.lblCalibre.Size = New System.Drawing.Size(116, 19)
        Me.lblCalibre.TabIndex = 217
        Me.lblCalibre.Text = "Calibre Catéter"
        Me.lblCalibre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblComplicaciones
        '
        Me.lblComplicaciones.BackColor = System.Drawing.Color.Transparent
        Me.lblComplicaciones.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComplicaciones.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblComplicaciones.Location = New System.Drawing.Point(5, 242)
        Me.lblComplicaciones.Name = "lblComplicaciones"
        Me.lblComplicaciones.Size = New System.Drawing.Size(190, 30)
        Me.lblComplicaciones.TabIndex = 214
        Me.lblComplicaciones.Text = "Complicaciones de Catéter"
        Me.lblComplicaciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblZonaInsercion
        '
        Me.lblZonaInsercion.BackColor = System.Drawing.Color.Transparent
        Me.lblZonaInsercion.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZonaInsercion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblZonaInsercion.Location = New System.Drawing.Point(2, 62)
        Me.lblZonaInsercion.Name = "lblZonaInsercion"
        Me.lblZonaInsercion.Size = New System.Drawing.Size(132, 19)
        Me.lblZonaInsercion.TabIndex = 185
        Me.lblZonaInsercion.Text = "Zona de Inserción"
        Me.lblZonaInsercion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTipoCateterIns
        '
        Me.lblTipoCateterIns.BackColor = System.Drawing.Color.Transparent
        Me.lblTipoCateterIns.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoCateterIns.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblTipoCateterIns.Location = New System.Drawing.Point(269, 26)
        Me.lblTipoCateterIns.Name = "lblTipoCateterIns"
        Me.lblTipoCateterIns.Size = New System.Drawing.Size(117, 19)
        Me.lblTipoCateterIns.TabIndex = 112
        Me.lblTipoCateterIns.Text = "Tipo Catéter"
        Me.lblTipoCateterIns.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ctlInsercionCateter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Controls.Add(Me.grpInsercionCateter)
        Me.Name = "ctlInsercionCateter"
        Me.Size = New System.Drawing.Size(631, 368)
        Me.grpInsercionCateter.ResumeLayout(False)
        Me.grpInsercionCateter.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpInsercionCateter As System.Windows.Forms.GroupBox
    Friend WithEvents lblComplicaciones As System.Windows.Forms.Label
    Friend WithEvents lblZonaInsercion As System.Windows.Forms.Label
    Friend WithEvents lblNumPunciones As System.Windows.Forms.Label
    Friend WithEvents lblTipoCateterIns As System.Windows.Forms.Label
    Friend WithEvents cmbLateralidad As System.Windows.Forms.ComboBox
    Friend WithEvents lblLateralidad As System.Windows.Forms.Label
    Friend WithEvents lblIndicaciones As System.Windows.Forms.Label
    Friend WithEvents btnGuardarInsercion As System.Windows.Forms.Button
    Friend WithEvents lblFechaHoraInsercion As Label
    Friend WithEvents mskFecHoraInsercion As MaskedTextBox
    Friend WithEvents cboZonaInsercion As ComboBox
    Friend WithEvents cboNumeroPunciones As ComboBox
    Friend WithEvents cbCalibreCateter As ComboBox
    Friend WithEvents lblCalibre As Label
    Friend WithEvents cboTipoCateter As ComboBox
    Friend WithEvents lblReqFechaHoraInsercionCateter As Label
    Friend WithEvents LblReqNumPunciones As Label
    Friend WithEvents lblReqIndicaciones As Label
    Friend WithEvents lblReqLateralidad As Label
    Friend WithEvents lblReqCalibreCateter As Label
    Friend WithEvents lblReqZonaInsercion As Label
    Friend WithEvents lblReqTipoCateter As Label
    Friend WithEvents chklistIndicaciones As CheckedListBox
    Friend WithEvents chklistComplicaciones As CheckedListBox
End Class
