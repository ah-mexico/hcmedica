<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmc_ConsultaMedico
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdbuscar = New System.Windows.Forms.Button
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.dtgmedico = New System.Windows.Forms.DataGridView
        Me.medico = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtApellido = New HistoriaClinica.TextBoxConFormato
        Me.txtNombre = New HistoriaClinica.TextBoxConFormato
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.dtgmedico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdbuscar)
        Me.GroupBox1.Controls.Add(Me.cmdCancelar)
        Me.GroupBox1.Controls.Add(Me.cmdAceptar)
        Me.GroupBox1.Controls.Add(Me.dtgmedico)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtApellido)
        Me.GroupBox1.Controls.Add(Me.txtNombre)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 52)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(595, 249)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Médico Acompañante"
        '
        'cmdbuscar
        '
        Me.cmdbuscar.Location = New System.Drawing.Point(494, 30)
        Me.cmdbuscar.Name = "cmdbuscar"
        Me.cmdbuscar.Size = New System.Drawing.Size(89, 21)
        Me.cmdbuscar.TabIndex = 7
        Me.cmdbuscar.Text = "&Buscar"
        Me.cmdbuscar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Location = New System.Drawing.Point(449, 222)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(89, 21)
        Me.cmdCancelar.TabIndex = 6
        Me.cmdCancelar.Text = "&Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Location = New System.Drawing.Point(343, 222)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(89, 21)
        Me.cmdAceptar.TabIndex = 5
        Me.cmdAceptar.Text = "&Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'dtgmedico
        '
        Me.dtgmedico.AllowUserToDeleteRows = False
        Me.dtgmedico.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgmedico.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgmedico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgmedico.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.medico, Me.Nombre})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgmedico.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtgmedico.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtgmedico.Location = New System.Drawing.Point(14, 60)
        Me.dtgmedico.Name = "dtgmedico"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgmedico.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dtgmedico.Size = New System.Drawing.Size(569, 142)
        Me.dtgmedico.TabIndex = 4
        '
        'medico
        '
        Me.medico.DataPropertyName = "medico"
        Me.medico.HeaderText = "Identificación"
        Me.medico.Name = "medico"
        '
        'Nombre
        '
        Me.Nombre.DataPropertyName = "Nombre"
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Width = 420
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(236, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Apellido"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Nombre"
        '
        'txtApellido
        '
        Me.txtApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApellido.ControlComboEnlace = Nothing
        Me.txtApellido.ControlTextoEnlace = Nothing
        Me.txtApellido.DatoRelacionado = Nothing
        Me.txtApellido.Decimals = CType(2, Byte)
        Me.txtApellido.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtApellido.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.txtApellido.Location = New System.Drawing.Point(239, 31)
        Me.txtApellido.Name = "txtApellido"
        Me.txtApellido.NombreCampoBuscado = Nothing
        Me.txtApellido.NombreCampoBusqueda = Nothing
        Me.txtApellido.NombreCampoDatos = Nothing
        Me.txtApellido.Obligatorio = False
        Me.txtApellido.OrigenDeDatos = Nothing
        Me.txtApellido.PermitirValorCero = False
        Me.txtApellido.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtApellido.Size = New System.Drawing.Size(219, 20)
        Me.txtApellido.TabIndex = 1
        Me.txtApellido.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtApellido.UserValues = Nothing
        Me.txtApellido.ValorMaximo = CType(0, Long)
        Me.txtApellido.ValorMinimo = CType(0, Long)
        '
        'txtNombre
        '
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.ControlComboEnlace = Nothing
        Me.txtNombre.ControlTextoEnlace = Nothing
        Me.txtNombre.DatoRelacionado = Nothing
        Me.txtNombre.Decimals = CType(2, Byte)
        Me.txtNombre.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtNombre.Format = HistoriaClinica.tbFormats.AlfaNúmericoConEspacios
        Me.txtNombre.Location = New System.Drawing.Point(14, 31)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.NombreCampoBuscado = Nothing
        Me.txtNombre.NombreCampoBusqueda = Nothing
        Me.txtNombre.NombreCampoDatos = Nothing
        Me.txtNombre.Obligatorio = False
        Me.txtNombre.OrigenDeDatos = Nothing
        Me.txtNombre.PermitirValorCero = False
        Me.txtNombre.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtNombre.Size = New System.Drawing.Size(219, 20)
        Me.txtNombre.TabIndex = 0
        Me.txtNombre.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txtNombre.UserValues = Nothing
        Me.txtNombre.ValorMaximo = CType(0, Long)
        Me.txtNombre.ValorMinimo = CType(0, Long)
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "medico"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Identificación"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Nombre"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Nombre"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 400
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.HistoriaClinica.My.Resources.Resources.header_buscador
        Me.PictureBox1.Location = New System.Drawing.Point(1, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(598, 46)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'frmc_ConsultaMedico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(599, 304)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmc_ConsultaMedico"
        Me.Text = "Consulta Médico"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dtgmedico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtApellido As HistoriaClinica.TextBoxConFormato
    Friend WithEvents txtNombre As HistoriaClinica.TextBoxConFormato
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtgmedico As System.Windows.Forms.DataGridView
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents cmdbuscar As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents medico As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
