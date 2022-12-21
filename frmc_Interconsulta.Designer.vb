<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmc_Interconsulta
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
        Me.CmbMotivo = New System.Windows.Forms.ComboBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.cmbEspecialidad = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtMotivo = New HistoriaClinica.TextBoxConFormato
        Me.txtMedicInterconsulta = New HistoriaClinica.TextBoxConFormato
        Me.txtMedInterconsulta = New HistoriaClinica.TextBoxConFormato
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CmbMotivo
        '
        Me.CmbMotivo.FormattingEnabled = True
        Me.CmbMotivo.Location = New System.Drawing.Point(223, 50)
        Me.CmbMotivo.Name = "CmbMotivo"
        Me.CmbMotivo.Size = New System.Drawing.Size(360, 21)
        Me.CmbMotivo.TabIndex = 14
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.HistoriaClinica.My.Resources.Resources.header_buscador
        Me.PictureBox1.Location = New System.Drawing.Point(3, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(595, 46)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmbEspecialidad)
        Me.GroupBox1.Controls.Add(Me.TxtMotivo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtMedicInterconsulta)
        Me.GroupBox1.Controls.Add(Me.cmdAceptar)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 53)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(595, 151)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(162, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Medico que solicita Interconsulta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Motivo Interconsulta"
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Location = New System.Drawing.Point(495, 122)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(89, 21)
        Me.cmdAceptar.TabIndex = 3
        Me.cmdAceptar.Text = "&Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmbEspecialidad
        '
        Me.cmbEspecialidad.FormattingEnabled = True
        Me.cmbEspecialidad.Location = New System.Drawing.Point(255, 57)
        Me.cmbEspecialidad.Name = "cmbEspecialidad"
        Me.cmbEspecialidad.Size = New System.Drawing.Size(329, 21)
        Me.cmbEspecialidad.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(238, 13)
        Me.Label3.TabIndex = 167
        Me.Label3.Text = "Especialidad Medico que Solicita la Interconsulta"
        '
        'TxtMotivo
        '
        Me.TxtMotivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtMotivo.ControlComboEnlace = Nothing
        Me.TxtMotivo.ControlTextoEnlace = Nothing
        Me.TxtMotivo.DatoRelacionado = Nothing
        Me.TxtMotivo.Decimals = CType(2, Byte)
        Me.TxtMotivo.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.TxtMotivo.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.TxtMotivo.Location = New System.Drawing.Point(255, 86)
        Me.TxtMotivo.Name = "TxtMotivo"
        Me.TxtMotivo.NombreCampoBuscado = Nothing
        Me.TxtMotivo.NombreCampoBusqueda = Nothing
        Me.TxtMotivo.NombreCampoDatos = Nothing
        Me.TxtMotivo.Obligatorio = False
        Me.TxtMotivo.OrigenDeDatos = Nothing
        Me.TxtMotivo.PermitirValorCero = False
        Me.TxtMotivo.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.TxtMotivo.Size = New System.Drawing.Size(329, 20)
        Me.TxtMotivo.TabIndex = 3
        Me.TxtMotivo.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.TxtMotivo.UserValues = Nothing
        Me.TxtMotivo.ValorMaximo = CType(0, Long)
        Me.TxtMotivo.ValorMinimo = CType(0, Long)
        '
        'txtMedicInterconsulta
        '
        Me.txtMedicInterconsulta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMedicInterconsulta.ControlComboEnlace = Nothing
        Me.txtMedicInterconsulta.ControlTextoEnlace = Nothing
        Me.txtMedicInterconsulta.DatoRelacionado = Nothing
        Me.txtMedicInterconsulta.Decimals = CType(2, Byte)
        Me.txtMedicInterconsulta.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtMedicInterconsulta.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.txtMedicInterconsulta.Location = New System.Drawing.Point(256, 31)
        Me.txtMedicInterconsulta.Name = "txtMedicInterconsulta"
        Me.txtMedicInterconsulta.NombreCampoBuscado = Nothing
        Me.txtMedicInterconsulta.NombreCampoBusqueda = Nothing
        Me.txtMedicInterconsulta.NombreCampoDatos = Nothing
        Me.txtMedicInterconsulta.Obligatorio = False
        Me.txtMedicInterconsulta.OrigenDeDatos = Nothing
        Me.txtMedicInterconsulta.PermitirValorCero = False
        Me.txtMedicInterconsulta.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtMedicInterconsulta.Size = New System.Drawing.Size(328, 20)
        Me.txtMedicInterconsulta.TabIndex = 1
        Me.txtMedicInterconsulta.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtMedicInterconsulta.UserValues = Nothing
        Me.txtMedicInterconsulta.ValorMaximo = CType(0, Long)
        Me.txtMedicInterconsulta.ValorMinimo = CType(0, Long)
        '
        'txtMedInterconsulta
        '
        Me.txtMedInterconsulta.ControlComboEnlace = Nothing
        Me.txtMedInterconsulta.ControlTextoEnlace = Nothing
        Me.txtMedInterconsulta.DatoRelacionado = Nothing
        Me.txtMedInterconsulta.Decimals = CType(2, Byte)
        Me.txtMedInterconsulta.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtMedInterconsulta.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.txtMedInterconsulta.Location = New System.Drawing.Point(0, 0)
        Me.txtMedInterconsulta.Name = "txtMedInterconsulta"
        Me.txtMedInterconsulta.NombreCampoBuscado = Nothing
        Me.txtMedInterconsulta.NombreCampoBusqueda = Nothing
        Me.txtMedInterconsulta.NombreCampoDatos = Nothing
        Me.txtMedInterconsulta.Obligatorio = False
        Me.txtMedInterconsulta.OrigenDeDatos = Nothing
        Me.txtMedInterconsulta.PermitirValorCero = False
        Me.txtMedInterconsulta.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtMedInterconsulta.Size = New System.Drawing.Size(100, 20)
        Me.txtMedInterconsulta.TabIndex = 0
        Me.txtMedInterconsulta.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtMedInterconsulta.UserValues = Nothing
        Me.txtMedInterconsulta.ValorMaximo = CType(0, Long)
        Me.txtMedInterconsulta.ValorMinimo = CType(0, Long)
        '
        'frmc_Interconsulta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(599, 216)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmc_Interconsulta"
        Me.Text = "Consulta Médico"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CmbMotivo As System.Windows.Forms.ComboBox
    Friend WithEvents txtMedInterconsulta As HistoriaClinica.TextBoxConFormato
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMedicInterconsulta As HistoriaClinica.TextBoxConFormato
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents TxtMotivo As HistoriaClinica.TextBoxConFormato
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbEspecialidad As System.Windows.Forms.ComboBox
End Class
