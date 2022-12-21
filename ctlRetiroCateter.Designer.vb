<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlRetiroCateter
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
        Me.grbRetiroCateter = New System.Windows.Forms.GroupBox
        Me.cmbMotivoRetiro = New System.Windows.Forms.ComboBox
        Me.lblMotivoRetiro = New System.Windows.Forms.Label
        Me.cmbTipoCateterRet = New System.Windows.Forms.ComboBox
        Me.lblTipoCateterRet = New System.Windows.Forms.Label
        Me.mskFecHorRetiro = New System.Windows.Forms.MaskedTextBox
        Me.lblFechaRetiro = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.grbRetiroCateter.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbRetiroCateter
        '
        Me.grbRetiroCateter.Controls.Add(Me.Button1)
        Me.grbRetiroCateter.Controls.Add(Me.cmbMotivoRetiro)
        Me.grbRetiroCateter.Controls.Add(Me.lblMotivoRetiro)
        Me.grbRetiroCateter.Controls.Add(Me.cmbTipoCateterRet)
        Me.grbRetiroCateter.Controls.Add(Me.lblTipoCateterRet)
        Me.grbRetiroCateter.Controls.Add(Me.mskFecHorRetiro)
        Me.grbRetiroCateter.Controls.Add(Me.lblFechaRetiro)
        Me.grbRetiroCateter.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grbRetiroCateter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.grbRetiroCateter.Location = New System.Drawing.Point(3, 3)
        Me.grbRetiroCateter.Name = "grbRetiroCateter"
        Me.grbRetiroCateter.Size = New System.Drawing.Size(583, 154)
        Me.grbRetiroCateter.TabIndex = 185
        Me.grbRetiroCateter.TabStop = False
        Me.grbRetiroCateter.Text = "Retiro de Catéter"
        '
        'cmbMotivoRetiro
        '
        Me.cmbMotivoRetiro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMotivoRetiro.FormattingEnabled = True
        Me.cmbMotivoRetiro.Location = New System.Drawing.Point(216, 84)
        Me.cmbMotivoRetiro.Name = "cmbMotivoRetiro"
        Me.cmbMotivoRetiro.Size = New System.Drawing.Size(352, 22)
        Me.cmbMotivoRetiro.TabIndex = 229
        '
        'lblMotivoRetiro
        '
        Me.lblMotivoRetiro.BackColor = System.Drawing.Color.Transparent
        Me.lblMotivoRetiro.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMotivoRetiro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblMotivoRetiro.Location = New System.Drawing.Point(6, 74)
        Me.lblMotivoRetiro.Name = "lblMotivoRetiro"
        Me.lblMotivoRetiro.Size = New System.Drawing.Size(184, 41)
        Me.lblMotivoRetiro.TabIndex = 228
        Me.lblMotivoRetiro.Text = "Motivo de retiro de catéter"
        Me.lblMotivoRetiro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipoCateterRet
        '
        Me.cmbTipoCateterRet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoCateterRet.FormattingEnabled = True
        Me.cmbTipoCateterRet.Location = New System.Drawing.Point(419, 29)
        Me.cmbTipoCateterRet.Name = "cmbTipoCateterRet"
        Me.cmbTipoCateterRet.Size = New System.Drawing.Size(149, 22)
        Me.cmbTipoCateterRet.TabIndex = 227
        '
        'lblTipoCateterRet
        '
        Me.lblTipoCateterRet.BackColor = System.Drawing.Color.Transparent
        Me.lblTipoCateterRet.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoCateterRet.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblTipoCateterRet.Location = New System.Drawing.Point(310, 30)
        Me.lblTipoCateterRet.Name = "lblTipoCateterRet"
        Me.lblTipoCateterRet.Size = New System.Drawing.Size(103, 19)
        Me.lblTipoCateterRet.TabIndex = 226
        Me.lblTipoCateterRet.Text = "Tipo Catéter"
        Me.lblTipoCateterRet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mskFecHorRetiro
        '
        Me.mskFecHorRetiro.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskFecHorRetiro.Location = New System.Drawing.Point(196, 28)
        Me.mskFecHorRetiro.Mask = "00/00/0000"
        Me.mskFecHorRetiro.Name = "mskFecHorRetiro"
        Me.mskFecHorRetiro.Size = New System.Drawing.Size(79, 21)
        Me.mskFecHorRetiro.TabIndex = 223
        Me.mskFecHorRetiro.ValidatingType = GetType(Date)
        '
        'lblFechaRetiro
        '
        Me.lblFechaRetiro.BackColor = System.Drawing.Color.Transparent
        Me.lblFechaRetiro.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaRetiro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblFechaRetiro.Location = New System.Drawing.Point(6, 30)
        Me.lblFechaRetiro.Name = "lblFechaRetiro"
        Me.lblFechaRetiro.Size = New System.Drawing.Size(197, 19)
        Me.lblFechaRetiro.TabIndex = 112
        Me.lblFechaRetiro.Text = "Fecha Retiro Catéter"
        Me.lblFechaRetiro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Button1.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_guardar
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Button1.Location = New System.Drawing.Point(491, 125)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(77, 23)
        Me.Button1.TabIndex = 293
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ctlRetiroCateter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Controls.Add(Me.grbRetiroCateter)
        Me.Name = "ctlRetiroCateter"
        Me.Size = New System.Drawing.Size(593, 161)
        Me.grbRetiroCateter.ResumeLayout(False)
        Me.grbRetiroCateter.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grbRetiroCateter As System.Windows.Forms.GroupBox
    Friend WithEvents lblMotivoRetiro As System.Windows.Forms.Label
    Friend WithEvents cmbTipoCateterRet As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipoCateterRet As System.Windows.Forms.Label
    Friend WithEvents mskFecHorRetiro As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblFechaRetiro As System.Windows.Forms.Label
    Friend WithEvents cmbMotivoRetiro As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
