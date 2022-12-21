<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_IdenticadoresRiesgoHistorico
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.dtgHistorico = New System.Windows.Forms.DataGridView()
        Me.IdentificadorRiesgo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaAcivacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ObservacionActiva = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioActiva = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EspecialidadActiva = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaInacivacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ObservacionInacivacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioInacivacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EspecialidadInacivacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dtgHistorico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.HistoriaClinica.My.Resources.Resources.bot_salir
        Me.btnCancelar.Location = New System.Drawing.Point(1055, 240)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 28)
        Me.btnCancelar.TabIndex = 9
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'dtgHistorico
        '
        Me.dtgHistorico.AllowUserToAddRows = False
        Me.dtgHistorico.AllowUserToDeleteRows = False
        Me.dtgHistorico.AllowUserToResizeColumns = False
        Me.dtgHistorico.AllowUserToResizeRows = False
        Me.dtgHistorico.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgHistorico.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtgHistorico.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtgHistorico.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdentificadorRiesgo, Me.FechaAcivacion, Me.ObservacionActiva, Me.UsuarioActiva, Me.EspecialidadActiva, Me.FechaInacivacion, Me.ObservacionInacivacion, Me.UsuarioInacivacion, Me.EspecialidadInacivacion, Me.Fecha})
        Me.dtgHistorico.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dtgHistorico.Location = New System.Drawing.Point(3, 3)
        Me.dtgHistorico.Name = "dtgHistorico"
        Me.dtgHistorico.ReadOnly = True
        Me.dtgHistorico.Size = New System.Drawing.Size(1127, 231)
        Me.dtgHistorico.TabIndex = 8
        '
        'IdentificadorRiesgo
        '
        Me.IdentificadorRiesgo.DataPropertyName = "IdentificadorRiesgo"
        Me.IdentificadorRiesgo.HeaderText = "Identificador Riesgo"
        Me.IdentificadorRiesgo.Name = "IdentificadorRiesgo"
        Me.IdentificadorRiesgo.ReadOnly = True
        Me.IdentificadorRiesgo.Width = 126
        '
        'FechaAcivacion
        '
        Me.FechaAcivacion.DataPropertyName = "FechaAcivacion"
        DataGridViewCellStyle1.Format = "G"
        Me.FechaAcivacion.DefaultCellStyle = DataGridViewCellStyle1
        Me.FechaAcivacion.HeaderText = "Fecha Activación"
        Me.FechaAcivacion.Name = "FechaAcivacion"
        Me.FechaAcivacion.ReadOnly = True
        Me.FechaAcivacion.Width = 115
        '
        'ObservacionActiva
        '
        Me.ObservacionActiva.DataPropertyName = "ObservacionActiva"
        Me.ObservacionActiva.HeaderText = "Observación Activación"
        Me.ObservacionActiva.Name = "ObservacionActiva"
        Me.ObservacionActiva.ReadOnly = True
        Me.ObservacionActiva.Width = 145
        '
        'UsuarioActiva
        '
        Me.UsuarioActiva.DataPropertyName = "UsuarioActiva"
        Me.UsuarioActiva.HeaderText = "Usuario Activación"
        Me.UsuarioActiva.Name = "UsuarioActiva"
        Me.UsuarioActiva.ReadOnly = True
        Me.UsuarioActiva.Width = 121
        '
        'EspecialidadActiva
        '
        Me.EspecialidadActiva.DataPropertyName = "EspecialidadActiva"
        Me.EspecialidadActiva.HeaderText = "Especialidad / Cargo Activación"
        Me.EspecialidadActiva.Name = "EspecialidadActiva"
        Me.EspecialidadActiva.ReadOnly = True
        Me.EspecialidadActiva.Width = 184
        '
        'FechaInacivacion
        '
        Me.FechaInacivacion.DataPropertyName = "FechaInacivacion"
        DataGridViewCellStyle2.Format = "G"
        Me.FechaInacivacion.DefaultCellStyle = DataGridViewCellStyle2
        Me.FechaInacivacion.HeaderText = "Fecha Desactivación"
        Me.FechaInacivacion.Name = "FechaInacivacion"
        Me.FechaInacivacion.ReadOnly = True
        Me.FechaInacivacion.Width = 133
        '
        'ObservacionInacivacion
        '
        Me.ObservacionInacivacion.DataPropertyName = "ObservacionInacivacion"
        Me.ObservacionInacivacion.HeaderText = "Justificación Desactivación"
        Me.ObservacionInacivacion.Name = "ObservacionInacivacion"
        Me.ObservacionInacivacion.ReadOnly = True
        Me.ObservacionInacivacion.Width = 161
        '
        'UsuarioInacivacion
        '
        Me.UsuarioInacivacion.DataPropertyName = "UsuarioInacivacion"
        Me.UsuarioInacivacion.HeaderText = "Usuario Desactivación"
        Me.UsuarioInacivacion.Name = "UsuarioInacivacion"
        Me.UsuarioInacivacion.ReadOnly = True
        Me.UsuarioInacivacion.Width = 139
        '
        'EspecialidadInacivacion
        '
        Me.EspecialidadInacivacion.DataPropertyName = "EspecialidadInacivacion"
        Me.EspecialidadInacivacion.HeaderText = "Especialidad / Cargo Desactivación"
        Me.EspecialidadInacivacion.Name = "EspecialidadInacivacion"
        Me.EspecialidadInacivacion.ReadOnly = True
        Me.EspecialidadInacivacion.Width = 202
        '
        'Fecha
        '
        Me.Fecha.DataPropertyName = "Fecha"
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.Visible = False
        Me.Fecha.Width = 62
        '
        'Frm_IdenticadoresRiesgoHistorico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1137, 272)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.dtgHistorico)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Frm_IdenticadoresRiesgoHistorico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Hístorial Identificadores de Riesgo"
        CType(Me.dtgHistorico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnCancelar As Button
    Friend WithEvents dtgHistorico As DataGridView
    Friend WithEvents IdentificadorRiesgo As DataGridViewTextBoxColumn
    Friend WithEvents FechaAcivacion As DataGridViewTextBoxColumn
    Friend WithEvents ObservacionActiva As DataGridViewTextBoxColumn
    Friend WithEvents UsuarioActiva As DataGridViewTextBoxColumn
    Friend WithEvents EspecialidadActiva As DataGridViewTextBoxColumn
    Friend WithEvents FechaInacivacion As DataGridViewTextBoxColumn
    Friend WithEvents ObservacionInacivacion As DataGridViewTextBoxColumn
    Friend WithEvents UsuarioInacivacion As DataGridViewTextBoxColumn
    Friend WithEvents EspecialidadInacivacion As DataGridViewTextBoxColumn
    Friend WithEvents Fecha As DataGridViewTextBoxColumn
End Class
