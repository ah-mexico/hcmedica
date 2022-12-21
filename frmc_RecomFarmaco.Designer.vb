<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmc_RecomFarmaco
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
        Me.dtgFarmaco = New System.Windows.Forms.DataGridView
        Me.recomendacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fec_con = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.login = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dtgFarmaco, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtgFarmaco
        '
        Me.dtgFarmaco.AllowUserToAddRows = False
        Me.dtgFarmaco.AllowUserToDeleteRows = False
        Me.dtgFarmaco.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgFarmaco.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.recomendacion, Me.fec_con, Me.login})
        Me.dtgFarmaco.Location = New System.Drawing.Point(12, 9)
        Me.dtgFarmaco.Name = "dtgFarmaco"
        Me.dtgFarmaco.ReadOnly = True
        Me.dtgFarmaco.Size = New System.Drawing.Size(723, 328)
        Me.dtgFarmaco.TabIndex = 0
        '
        'recomendacion
        '
        Me.recomendacion.DataPropertyName = "recomendacion"
        Me.recomendacion.HeaderText = "Recomendacion"
        Me.recomendacion.Name = "recomendacion"
        Me.recomendacion.ReadOnly = True
        Me.recomendacion.Width = 400
        '
        'fec_con
        '
        Me.fec_con.DataPropertyName = "fec_con"
        Me.fec_con.HeaderText = "Fecha Registro"
        Me.fec_con.Name = "fec_con"
        Me.fec_con.ReadOnly = True
        '
        'login
        '
        Me.login.DataPropertyName = "login"
        Me.login.HeaderText = "Login"
        Me.login.Name = "login"
        Me.login.ReadOnly = True
        Me.login.Width = 180
        '
        'frmc_RecomFarmaco
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(742, 349)
        Me.Controls.Add(Me.dtgFarmaco)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmc_RecomFarmaco"
        Me.Text = "Recomendaciones Farmacoterapeúticas"
        CType(Me.dtgFarmaco, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtgFarmaco As System.Windows.Forms.DataGridView
    Friend WithEvents recomendacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fec_con As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents login As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
