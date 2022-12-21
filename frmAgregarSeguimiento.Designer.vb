<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAgregarSeguimiento
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtfechaa = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.rbsi = New System.Windows.Forms.RadioButton()
        Me.rbno = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbgestfinal = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnagregar = New System.Windows.Forms.Button()
        Me.btncancelar = New System.Windows.Forms.Button()
        Me.chkListSitioInsert = New System.Windows.Forms.CheckedListBox()
        Me.chklistcuracion = New System.Windows.Forms.CheckedListBox()
        Me.chklistverifica = New System.Windows.Forms.CheckedListBox()
        Me.chklistmotreiro = New System.Windows.Forms.CheckedListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(26, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Fecha:"
        '
        'txtfechaa
        '
        Me.txtfechaa.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfechaa.Location = New System.Drawing.Point(13, 28)
        Me.txtfechaa.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtfechaa.Mask = "00/00/0000 00:00"
        Me.txtfechaa.Name = "txtfechaa"
        Me.txtfechaa.Size = New System.Drawing.Size(116, 21)
        Me.txtfechaa.TabIndex = 2
        Me.txtfechaa.ValidatingType = GetType(Date)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(28, 53)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(149, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Estado Sitio de Inserción:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(351, 17)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Se realiza Curación:"
        '
        'rbsi
        '
        Me.rbsi.AutoSize = True
        Me.rbsi.Checked = True
        Me.rbsi.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbsi.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.rbsi.Location = New System.Drawing.Point(482, 16)
        Me.rbsi.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.rbsi.Name = "rbsi"
        Me.rbsi.Size = New System.Drawing.Size(37, 17)
        Me.rbsi.TabIndex = 9
        Me.rbsi.TabStop = True
        Me.rbsi.Text = "Si"
        Me.rbsi.UseVisualStyleBackColor = True
        '
        'rbno
        '
        Me.rbno.AutoSize = True
        Me.rbno.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbno.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.rbno.Location = New System.Drawing.Point(531, 16)
        Me.rbno.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.rbno.Name = "rbno"
        Me.rbno.Size = New System.Drawing.Size(42, 17)
        Me.rbno.TabIndex = 10
        Me.rbno.TabStop = True
        Me.rbno.Text = "No"
        Me.rbno.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(351, 41)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Curación:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(28, 188)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Se Verifica:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(351, 156)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Gestión Final:"
        '
        'cmbgestfinal
        '
        Me.cmbgestfinal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbgestfinal.FormattingEnabled = True
        Me.cmbgestfinal.Location = New System.Drawing.Point(338, 171)
        Me.cmbgestfinal.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cmbgestfinal.Name = "cmbgestfinal"
        Me.cmbgestfinal.Size = New System.Drawing.Size(386, 21)
        Me.cmbgestfinal.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(351, 193)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(87, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Motivo Retiro:"
        '
        'btnagregar
        '
        Me.btnagregar.Image = Global.HistoriaClinica.My.Resources.Resources.bot_agregar
        Me.btnagregar.Location = New System.Drawing.Point(338, 298)
        Me.btnagregar.Name = "btnagregar"
        Me.btnagregar.Size = New System.Drawing.Size(62, 26)
        Me.btnagregar.TabIndex = 19
        Me.btnagregar.UseVisualStyleBackColor = True
        '
        'btncancelar
        '
        Me.btncancelar.Image = Global.HistoriaClinica.My.Resources.Resources.bot_cancelar
        Me.btncancelar.Location = New System.Drawing.Point(406, 300)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(62, 23)
        Me.btncancelar.TabIndex = 20
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'chkListSitioInsert
        '
        Me.chkListSitioInsert.CheckOnClick = True
        Me.chkListSitioInsert.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkListSitioInsert.FormattingEnabled = True
        Me.chkListSitioInsert.Location = New System.Drawing.Point(12, 69)
        Me.chkListSitioInsert.Name = "chkListSitioInsert"
        Me.chkListSitioInsert.Size = New System.Drawing.Size(306, 84)
        Me.chkListSitioInsert.TabIndex = 21
        '
        'chklistcuracion
        '
        Me.chklistcuracion.CheckOnClick = True
        Me.chklistcuracion.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chklistcuracion.FormattingEnabled = True
        Me.chklistcuracion.Location = New System.Drawing.Point(338, 69)
        Me.chklistcuracion.Name = "chklistcuracion"
        Me.chklistcuracion.Size = New System.Drawing.Size(387, 84)
        Me.chklistcuracion.TabIndex = 22
        '
        'chklistverifica
        '
        Me.chklistverifica.CheckOnClick = True
        Me.chklistverifica.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chklistverifica.FormattingEnabled = True
        Me.chklistverifica.Location = New System.Drawing.Point(9, 204)
        Me.chklistverifica.Name = "chklistverifica"
        Me.chklistverifica.Size = New System.Drawing.Size(309, 84)
        Me.chklistverifica.TabIndex = 23
        '
        'chklistmotreiro
        '
        Me.chklistmotreiro.CheckOnClick = True
        Me.chklistmotreiro.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chklistmotreiro.FormattingEnabled = True
        Me.chklistmotreiro.Location = New System.Drawing.Point(338, 209)
        Me.chklistmotreiro.Name = "chklistmotreiro"
        Me.chklistmotreiro.Size = New System.Drawing.Size(386, 84)
        Me.chklistmotreiro.TabIndex = 24
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(15, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "*"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(335, 14)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(14, 13)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "*"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(335, 41)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(14, 13)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "*"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(335, 156)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(14, 13)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "*"
        Me.Label11.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(335, 193)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(14, 13)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "*"
        Me.Label12.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(15, 189)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(14, 13)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "*"
        '
        'frmAgregarSeguimiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(739, 354)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chklistmotreiro)
        Me.Controls.Add(Me.chklistverifica)
        Me.Controls.Add(Me.chklistcuracion)
        Me.Controls.Add(Me.chkListSitioInsert)
        Me.Controls.Add(Me.btncancelar)
        Me.Controls.Add(Me.btnagregar)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmbgestfinal)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.rbno)
        Me.Controls.Add(Me.rbsi)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtfechaa)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAgregarSeguimiento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Seguimiento a Cateter"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents txtfechaa As MaskedTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents rbsi As RadioButton
    Friend WithEvents rbno As RadioButton
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbgestfinal As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents btnagregar As Button
    Friend WithEvents btncancelar As Button
    Friend WithEvents chkListSitioInsert As CheckedListBox
    Friend WithEvents chklistcuracion As CheckedListBox
    Friend WithEvents chklistverifica As CheckedListBox
    Friend WithEvents chklistmotreiro As CheckedListBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
End Class
