<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCancelaOrden
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.dtgBusqueda = New System.Windows.Forms.DataGridView
        Me.dgvOrdenes = New System.Windows.Forms.DataGridView
        Me.Cancelar = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.btnSalir = New System.Windows.Forms.Button
        Me.btnCancelarSelec = New System.Windows.Forms.Button
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvOrdenes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.Image = Global.HistoriaClinica.My.Resources.Resources.header_buscador
        Me.PictureBox1.Location = New System.Drawing.Point(0, -2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(703, 39)
        Me.PictureBox1.TabIndex = 60
        Me.PictureBox1.TabStop = False
        '
        'dtgBusqueda
        '
        Me.dtgBusqueda.AllowUserToDeleteRows = False
        Me.dtgBusqueda.AllowUserToOrderColumns = True
        Me.dtgBusqueda.AllowUserToResizeRows = False
        Me.dtgBusqueda.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgBusqueda.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dtgBusqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(210, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgBusqueda.DefaultCellStyle = DataGridViewCellStyle5
        Me.dtgBusqueda.Location = New System.Drawing.Point(2, 37)
        Me.dtgBusqueda.MultiSelect = False
        Me.dtgBusqueda.Name = "dtgBusqueda"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(210, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgBusqueda.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dtgBusqueda.RowHeadersVisible = False
        Me.dtgBusqueda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgBusqueda.Size = New System.Drawing.Size(701, 306)
        Me.dtgBusqueda.TabIndex = 61
        '
        'dgvOrdenes
        '
        Me.dgvOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOrdenes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cancelar})
        Me.dgvOrdenes.Location = New System.Drawing.Point(12, 43)
        Me.dgvOrdenes.Name = "dgvOrdenes"
        Me.dgvOrdenes.Size = New System.Drawing.Size(681, 253)
        Me.dgvOrdenes.TabIndex = 62
        '
        'Cancelar
        '
        Me.Cancelar.HeaderText = "Cancelar"
        Me.Cancelar.Name = "Cancelar"
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(618, 309)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 63
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnCancelarSelec
        '
        Me.btnCancelarSelec.Location = New System.Drawing.Point(467, 309)
        Me.btnCancelarSelec.Name = "btnCancelarSelec"
        Me.btnCancelarSelec.Size = New System.Drawing.Size(145, 23)
        Me.btnCancelarSelec.TabIndex = 64
        Me.btnCancelarSelec.Text = "Cancelar Seleccionados"
        Me.btnCancelarSelec.UseVisualStyleBackColor = True
        '
        'frmCancelaOrden
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(705, 344)
        Me.Controls.Add(Me.btnCancelarSelec)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.dgvOrdenes)
        Me.Controls.Add(Me.dtgBusqueda)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmCancelaOrden"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CancelaOrden"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvOrdenes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents dtgBusqueda As System.Windows.Forms.DataGridView
    Friend WithEvents dgvOrdenes As System.Windows.Forms.DataGridView
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnCancelarSelec As System.Windows.Forms.Button
    Friend WithEvents Cancelar As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class

