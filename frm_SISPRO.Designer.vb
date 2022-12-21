<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_SISPRO
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.db_aceptar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_caracteres = New System.Windows.Forms.Label()
        Me.txt_SISPRO = New HistoriaClinica.TextBoxConFormato()
        Me.SuspendLayout()
        '
        'db_aceptar
        '
        Me.db_aceptar.Location = New System.Drawing.Point(270, 59)
        Me.db_aceptar.Name = "db_aceptar"
        Me.db_aceptar.Size = New System.Drawing.Size(75, 23)
        Me.db_aceptar.TabIndex = 0
        Me.db_aceptar.Text = "Aceptar"
        Me.db_aceptar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(173, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Código autorización Ministerio"
        '
        'lbl_caracteres
        '
        Me.lbl_caracteres.AutoSize = True
        Me.lbl_caracteres.Location = New System.Drawing.Point(165, 5)
        Me.lbl_caracteres.Name = "lbl_caracteres"
        Me.lbl_caracteres.Size = New System.Drawing.Size(0, 15)
        Me.lbl_caracteres.TabIndex = 5
        '
        'txt_SISPRO
        '
        Me.txt_SISPRO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txt_SISPRO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txt_SISPRO.BackColor = System.Drawing.Color.White
        Me.txt_SISPRO.ControlComboEnlace = Nothing
        Me.txt_SISPRO.ControlTextoEnlace = Nothing
        Me.txt_SISPRO.DatoRelacionado = Nothing
        Me.txt_SISPRO.Decimals = CType(0, Byte)
        Me.txt_SISPRO.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txt_SISPRO.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_SISPRO.Format = HistoriaClinica.tbFormats.NúmericoEnteroSinSigno
        Me.txt_SISPRO.Location = New System.Drawing.Point(165, 24)
        Me.txt_SISPRO.MaxLength = 30
        Me.txt_SISPRO.Name = "txt_SISPRO"
        Me.txt_SISPRO.NombreCampoBuscado = Nothing
        Me.txt_SISPRO.NombreCampoBusqueda = Nothing
        Me.txt_SISPRO.NombreCampoDatos = Nothing
        Me.txt_SISPRO.Obligatorio = False
        Me.txt_SISPRO.OrigenDeDatos = Nothing
        Me.txt_SISPRO.PermitirValorCero = False
        Me.txt_SISPRO.PosicionListaDesplegable = HistoriaClinica.tbPosicionLista.Bottom
        Me.txt_SISPRO.Size = New System.Drawing.Size(180, 24)
        Me.txt_SISPRO.TabIndex = 4
        Me.txt_SISPRO.TipoControl = HistoriaClinica.tbTipoControl.Normal
        Me.txt_SISPRO.UserValues = Nothing
        Me.txt_SISPRO.ValorMaximo = CType(0, Long)
        Me.txt_SISPRO.ValorMinimo = CType(0, Long)
        '
        'frm_SISPRO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.ClientSize = New System.Drawing.Size(357, 105)
        Me.ControlBox = False
        Me.Controls.Add(Me.lbl_caracteres)
        Me.Controls.Add(Me.txt_SISPRO)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.db_aceptar)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_SISPRO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro radicado SISPRO"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents db_aceptar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_SISPRO As HistoriaClinica.TextBoxConFormato
    Friend WithEvents lbl_caracteres As System.Windows.Forms.Label
End Class
