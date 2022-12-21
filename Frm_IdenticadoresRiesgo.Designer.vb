<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_IdenticadoresRiesgo
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
        Me.pnlIdenRiesgo = New System.Windows.Forms.Panel()
        Me.btnAgragar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblObservaciones = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblIdentificadorRiesgo = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.dgIdenticadores = New System.Windows.Forms.DataGridView()
        Me.IdentRiesgo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Obserbaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Especialidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Desactivar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Eliminar = New System.Windows.Forms.DataGridViewImageColumn()
        Me.IdIdentificador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdTipoUsuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdEspecialidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdHistoria1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Grabado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.login = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.irIdRegistro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ddl_IdentRiesgo = New System.Windows.Forms.ComboBox()
        Me.pnlInactivacion = New System.Windows.Forms.Panel()
        Me.btnCancelarInac = New System.Windows.Forms.Button()
        Me.btnGuardarInac = New System.Windows.Forms.Button()
        Me.lbl_Justificacion = New System.Windows.Forms.Label()
        Me.txtJustificación = New System.Windows.Forms.TextBox()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lbl_observaciones1 = New System.Windows.Forms.Label()
        Me.lbl_Justificación1 = New System.Windows.Forms.Label()
        Me.pnlIdenRiesgo.SuspendLayout()
        CType(Me.dgIdenticadores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlInactivacion.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlIdenRiesgo
        '
        Me.pnlIdenRiesgo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlIdenRiesgo.Controls.Add(Me.lbl_observaciones1)
        Me.pnlIdenRiesgo.Controls.Add(Me.btnAgragar)
        Me.pnlIdenRiesgo.Controls.Add(Me.btnGuardar)
        Me.pnlIdenRiesgo.Controls.Add(Me.lblObservaciones)
        Me.pnlIdenRiesgo.Controls.Add(Me.btnCancelar)
        Me.pnlIdenRiesgo.Controls.Add(Me.lblIdentificadorRiesgo)
        Me.pnlIdenRiesgo.Controls.Add(Me.txtObservaciones)
        Me.pnlIdenRiesgo.Controls.Add(Me.dgIdenticadores)
        Me.pnlIdenRiesgo.Controls.Add(Me.ddl_IdentRiesgo)
        Me.pnlIdenRiesgo.Location = New System.Drawing.Point(12, 12)
        Me.pnlIdenRiesgo.Name = "pnlIdenRiesgo"
        Me.pnlIdenRiesgo.Size = New System.Drawing.Size(815, 316)
        Me.pnlIdenRiesgo.TabIndex = 17
        '
        'btnAgragar
        '
        Me.btnAgragar.Image = Global.HistoriaClinica.My.Resources.Resources.bot_agregar
        Me.btnAgragar.Location = New System.Drawing.Point(626, 69)
        Me.btnAgragar.Name = "btnAgragar"
        Me.btnAgragar.Size = New System.Drawing.Size(75, 28)
        Me.btnAgragar.TabIndex = 5
        Me.btnAgragar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.HistoriaClinica.My.Resources.Resources.bot_guardar
        Me.btnGuardar.Location = New System.Drawing.Point(643, 278)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 28)
        Me.btnGuardar.TabIndex = 7
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblObservaciones.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblObservaciones.Location = New System.Drawing.Point(9, 48)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(105, 14)
        Me.lblObservaciones.TabIndex = 4
        Me.lblObservaciones.Text = "Observaciones"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.HistoriaClinica.My.Resources.Resources.bot_salir
        Me.btnCancelar.Location = New System.Drawing.Point(724, 278)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 28)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblIdentificadorRiesgo
        '
        Me.lblIdentificadorRiesgo.AutoSize = True
        Me.lblIdentificadorRiesgo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblIdentificadorRiesgo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblIdentificadorRiesgo.Location = New System.Drawing.Point(9, 21)
        Me.lblIdentificadorRiesgo.Name = "lblIdentificadorRiesgo"
        Me.lblIdentificadorRiesgo.Size = New System.Drawing.Size(160, 14)
        Me.lblIdentificadorRiesgo.TabIndex = 1
        Me.lblIdentificadorRiesgo.Text = "Identificador de Riesgo"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(175, 46)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(430, 51)
        Me.txtObservaciones.TabIndex = 2
        '
        'dgIdenticadores
        '
        Me.dgIdenticadores.AllowUserToAddRows = False
        Me.dgIdenticadores.AllowUserToDeleteRows = False
        Me.dgIdenticadores.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgIdenticadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgIdenticadores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdentRiesgo, Me.Obserbaciones, Me.usuario, Me.Especialidad, Me.Desactivar, Me.Eliminar, Me.IdIdentificador, Me.IdEstado, Me.IdTipoUsuario, Me.IdEspecialidad, Me.IdHistoria1, Me.Grabado, Me.login, Me.irIdRegistro})
        Me.dgIdenticadores.Location = New System.Drawing.Point(12, 103)
        Me.dgIdenticadores.Name = "dgIdenticadores"
        Me.dgIdenticadores.Size = New System.Drawing.Size(787, 169)
        Me.dgIdenticadores.TabIndex = 3
        '
        'IdentRiesgo
        '
        Me.IdentRiesgo.DataPropertyName = "IdentificadorRiesgo"
        Me.IdentRiesgo.HeaderText = "Identificador de Riesgo"
        Me.IdentRiesgo.Name = "IdentRiesgo"
        '
        'Obserbaciones
        '
        Me.Obserbaciones.DataPropertyName = "irObservacion"
        Me.Obserbaciones.HeaderText = "Observaciones"
        Me.Obserbaciones.Name = "Obserbaciones"
        '
        'usuario
        '
        Me.usuario.DataPropertyName = "Usuario"
        Me.usuario.HeaderText = "Usuario"
        Me.usuario.Name = "usuario"
        '
        'Especialidad
        '
        Me.Especialidad.DataPropertyName = "Especialidad"
        Me.Especialidad.HeaderText = "Especialidad / Cargo"
        Me.Especialidad.Name = "Especialidad"
        '
        'Desactivar
        '
        Me.Desactivar.HeaderText = "Desactivar"
        Me.Desactivar.Name = "Desactivar"
        '
        'Eliminar
        '
        Me.Eliminar.HeaderText = "Eliminar"
        Me.Eliminar.Image = Global.HistoriaClinica.My.Resources.Resources.bot_x
        Me.Eliminar.Name = "Eliminar"
        Me.Eliminar.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'IdIdentificador
        '
        Me.IdIdentificador.DataPropertyName = "IdIdentRiesgo"
        Me.IdIdentificador.HeaderText = "IdIdentificador"
        Me.IdIdentificador.Name = "IdIdentificador"
        Me.IdIdentificador.Visible = False
        '
        'IdEstado
        '
        Me.IdEstado.DataPropertyName = "IdEstado"
        Me.IdEstado.HeaderText = "IdEstado"
        Me.IdEstado.Name = "IdEstado"
        Me.IdEstado.Visible = False
        '
        'IdTipoUsuario
        '
        Me.IdTipoUsuario.DataPropertyName = "IdTipoUsuario"
        Me.IdTipoUsuario.HeaderText = "IdTipoUsuario"
        Me.IdTipoUsuario.Name = "IdTipoUsuario"
        Me.IdTipoUsuario.Visible = False
        '
        'IdEspecialidad
        '
        Me.IdEspecialidad.DataPropertyName = "IdEspecialidad"
        Me.IdEspecialidad.HeaderText = "IdEspecialidad"
        Me.IdEspecialidad.Name = "IdEspecialidad"
        Me.IdEspecialidad.Visible = False
        '
        'IdHistoria1
        '
        Me.IdHistoria1.DataPropertyName = "IdHistoria"
        Me.IdHistoria1.HeaderText = "IdHistoria1"
        Me.IdHistoria1.Name = "IdHistoria1"
        Me.IdHistoria1.Visible = False
        '
        'Grabado
        '
        Me.Grabado.DataPropertyName = "grabado"
        Me.Grabado.HeaderText = "Grabado"
        Me.Grabado.Name = "Grabado"
        Me.Grabado.Visible = False
        '
        'login
        '
        Me.login.DataPropertyName = "Login"
        Me.login.HeaderText = "login"
        Me.login.Name = "login"
        Me.login.Visible = False
        '
        'irIdRegistro
        '
        Me.irIdRegistro.DataPropertyName = "irIdRegistro"
        Me.irIdRegistro.HeaderText = "irIdRegistro"
        Me.irIdRegistro.Name = "irIdRegistro"
        Me.irIdRegistro.Visible = False
        '
        'ddl_IdentRiesgo
        '
        Me.ddl_IdentRiesgo.FormattingEnabled = True
        Me.ddl_IdentRiesgo.Location = New System.Drawing.Point(175, 19)
        Me.ddl_IdentRiesgo.Name = "ddl_IdentRiesgo"
        Me.ddl_IdentRiesgo.Size = New System.Drawing.Size(260, 21)
        Me.ddl_IdentRiesgo.TabIndex = 0
        '
        'pnlInactivacion
        '
        Me.pnlInactivacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlInactivacion.Controls.Add(Me.lbl_Justificación1)
        Me.pnlInactivacion.Controls.Add(Me.btnCancelarInac)
        Me.pnlInactivacion.Controls.Add(Me.btnGuardarInac)
        Me.pnlInactivacion.Controls.Add(Me.lbl_Justificacion)
        Me.pnlInactivacion.Controls.Add(Me.txtJustificación)
        Me.pnlInactivacion.Location = New System.Drawing.Point(12, 334)
        Me.pnlInactivacion.Name = "pnlInactivacion"
        Me.pnlInactivacion.Size = New System.Drawing.Size(815, 90)
        Me.pnlInactivacion.TabIndex = 18
        Me.pnlInactivacion.Visible = False
        '
        'btnCancelarInac
        '
        Me.btnCancelarInac.Image = Global.HistoriaClinica.My.Resources.Resources.bot_cancelar2
        Me.btnCancelarInac.Location = New System.Drawing.Point(724, 51)
        Me.btnCancelarInac.Name = "btnCancelarInac"
        Me.btnCancelarInac.Size = New System.Drawing.Size(75, 28)
        Me.btnCancelarInac.TabIndex = 14
        Me.btnCancelarInac.UseVisualStyleBackColor = True
        '
        'btnGuardarInac
        '
        Me.btnGuardarInac.Image = Global.HistoriaClinica.My.Resources.Resources.bot_guardar
        Me.btnGuardarInac.Location = New System.Drawing.Point(643, 51)
        Me.btnGuardarInac.Name = "btnGuardarInac"
        Me.btnGuardarInac.Size = New System.Drawing.Size(75, 28)
        Me.btnGuardarInac.TabIndex = 15
        Me.btnGuardarInac.UseVisualStyleBackColor = True
        '
        'lbl_Justificacion
        '
        Me.lbl_Justificacion.AutoSize = True
        Me.lbl_Justificacion.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_Justificacion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lbl_Justificacion.Location = New System.Drawing.Point(9, 9)
        Me.lbl_Justificacion.Name = "lbl_Justificacion"
        Me.lbl_Justificacion.Size = New System.Drawing.Size(97, 14)
        Me.lbl_Justificacion.TabIndex = 12
        Me.lbl_Justificacion.Text = "Justificación  "
        '
        'txtJustificación
        '
        Me.txtJustificación.Location = New System.Drawing.Point(125, 9)
        Me.txtJustificación.Multiline = True
        Me.txtJustificación.Name = "txtJustificación"
        Me.txtJustificación.Size = New System.Drawing.Size(675, 37)
        Me.txtJustificación.TabIndex = 13
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "IdentificadorRiesgo"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Identificador de Riesgo"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "irObservacion"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Observaciones"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Usuario"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Usuario"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Especialidad"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Especialidad"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "IdIdentRiesgo"
        Me.DataGridViewTextBoxColumn5.HeaderText = "IdIdentificador"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "IdEstado"
        Me.DataGridViewTextBoxColumn6.HeaderText = "IdEstado"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Visible = False
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "IdTipoUsuario"
        Me.DataGridViewTextBoxColumn7.HeaderText = "IdTipoUsuario"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Visible = False
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "IdEspecialidad"
        Me.DataGridViewTextBoxColumn8.HeaderText = "IdEspecialidad"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Visible = False
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "IdHistoria"
        Me.DataGridViewTextBoxColumn9.HeaderText = "IdHistoria1"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Visible = False
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "grabado"
        Me.DataGridViewTextBoxColumn10.HeaderText = "Grabado"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Visible = False
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "Login"
        Me.DataGridViewTextBoxColumn11.HeaderText = "login"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Visible = False
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "irIdRegistro"
        Me.DataGridViewTextBoxColumn12.HeaderText = "irIdRegistro"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Visible = False
        '
        'lbl_observaciones1
        '
        Me.lbl_observaciones1.AutoSize = True
        Me.lbl_observaciones1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_observaciones1.ForeColor = System.Drawing.Color.Red
        Me.lbl_observaciones1.Location = New System.Drawing.Point(122, 48)
        Me.lbl_observaciones1.Name = "lbl_observaciones1"
        Me.lbl_observaciones1.Size = New System.Drawing.Size(13, 16)
        Me.lbl_observaciones1.TabIndex = 9
        Me.lbl_observaciones1.Text = "*"
        Me.lbl_observaciones1.Visible = False
        '
        'lbl_Justificación1
        '
        Me.lbl_Justificación1.AutoSize = True
        Me.lbl_Justificación1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Justificación1.ForeColor = System.Drawing.Color.Red
        Me.lbl_Justificación1.Location = New System.Drawing.Point(106, 10)
        Me.lbl_Justificación1.Name = "lbl_Justificación1"
        Me.lbl_Justificación1.Size = New System.Drawing.Size(13, 16)
        Me.lbl_Justificación1.TabIndex = 16
        Me.lbl_Justificación1.Text = "*"
        '
        'Frm_IdenticadoresRiesgo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(839, 515)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlIdenRiesgo)
        Me.Controls.Add(Me.pnlInactivacion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Frm_IdenticadoresRiesgo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Identificadores de Riesgo"
        Me.pnlIdenRiesgo.ResumeLayout(False)
        Me.pnlIdenRiesgo.PerformLayout()
        CType(Me.dgIdenticadores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlInactivacion.ResumeLayout(False)
        Me.pnlInactivacion.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlIdenRiesgo As Panel
    Friend WithEvents btnAgragar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents lblObservaciones As Label
    Friend WithEvents btnCancelar As Button
    Friend WithEvents lblIdentificadorRiesgo As Label
    Friend WithEvents txtObservaciones As TextBox
    Friend WithEvents dgIdenticadores As DataGridView
    Friend WithEvents ddl_IdentRiesgo As ComboBox
    Friend WithEvents pnlInactivacion As Panel
    Friend WithEvents btnCancelarInac As Button
    Friend WithEvents btnGuardarInac As Button
    Friend WithEvents lbl_Justificacion As Label
    Friend WithEvents txtJustificación As TextBox
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn
    Friend WithEvents IdentRiesgo As DataGridViewTextBoxColumn
    Friend WithEvents Obserbaciones As DataGridViewTextBoxColumn
    Friend WithEvents usuario As DataGridViewTextBoxColumn
    Friend WithEvents Especialidad As DataGridViewTextBoxColumn
    Friend WithEvents Desactivar As DataGridViewCheckBoxColumn
    Friend WithEvents Eliminar As DataGridViewImageColumn
    Friend WithEvents IdIdentificador As DataGridViewTextBoxColumn
    Friend WithEvents IdEstado As DataGridViewTextBoxColumn
    Friend WithEvents IdTipoUsuario As DataGridViewTextBoxColumn
    Friend WithEvents IdEspecialidad As DataGridViewTextBoxColumn
    Friend WithEvents IdHistoria1 As DataGridViewTextBoxColumn
    Friend WithEvents Grabado As DataGridViewTextBoxColumn
    Friend WithEvents login As DataGridViewTextBoxColumn
    Friend WithEvents irIdRegistro As DataGridViewTextBoxColumn
    Friend WithEvents lbl_observaciones1 As Label
    Friend WithEvents lbl_Justificación1 As Label
End Class
