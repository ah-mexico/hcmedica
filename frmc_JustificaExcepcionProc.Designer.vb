<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmc_JustificaExcepcionProc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmc_JustificaExcepcionProc))
        Me.btnAgregar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtJustificacion = New HistoriaClinica.TextBoxConFormato
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.btnAgregar.TabIndex = 20
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
        Me.Panel1.Location = New System.Drawing.Point(302, 134)
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
        Me.txtJustificacion.Location = New System.Drawing.Point(10, 37)
        Me.txtJustificacion.MaxLength = 1000
        Me.txtJustificacion.Multiline = True
        Me.txtJustificacion.Name = "txtJustificacion"
        Me.txtJustificacion.NombreCampoBuscado = Nothing
        Me.txtJustificacion.NombreCampoBusqueda = Nothing
        Me.txtJustificacion.NombreCampoDatos = Nothing
        Me.txtJustificacion.Obligatorio = False
        Me.txtJustificacion.OrigenDeDatos = Nothing
        Me.txtJustificacion.PermitirValorCero = False
        Me.txtJustificacion.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txtJustificacion.Size = New System.Drawing.Size(455, 91)
        Me.txtJustificacion.TabIndex = 12
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(123, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 14)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Ingrese la Justificación"
        '
        'frmc_JustificaExcepcionProc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(480, 183)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtJustificacion)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmc_JustificaExcepcionProc"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Excepciones"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtJustificacion As HistoriaClinica.TextBoxConFormato
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
