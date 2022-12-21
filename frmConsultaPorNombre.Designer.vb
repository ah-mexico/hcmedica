<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaPorNombre
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dtgPacientes = New System.Windows.Forms.DataGridView
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.tip_doc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.num_doc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pri_ape = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.seg_ape = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pri_nom = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.seg_nom = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.unificado = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dtgPacientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtgPacientes
        '
        Me.dtgPacientes.AllowUserToAddRows = False
        Me.dtgPacientes.AllowUserToDeleteRows = False
        Me.dtgPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgPacientes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tip_doc, Me.num_doc, Me.pri_ape, Me.seg_ape, Me.pri_nom, Me.seg_nom, Me.unificado})
        Me.dtgPacientes.Location = New System.Drawing.Point(4, 2)
        Me.dtgPacientes.Name = "dtgPacientes"
        Me.dtgPacientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgPacientes.Size = New System.Drawing.Size(699, 229)
        Me.dtgPacientes.TabIndex = 0
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.Location = New System.Drawing.Point(511, 241)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(93, 20)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(610, 241)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(93, 20)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'tip_doc
        '
        Me.tip_doc.DataPropertyName = "tip_doc"
        Me.tip_doc.HeaderText = "Tipo Documento"
        Me.tip_doc.Name = "tip_doc"
        Me.tip_doc.ReadOnly = True
        Me.tip_doc.Width = 114
        '
        'num_doc
        '
        Me.num_doc.DataPropertyName = "num_doc"
        Me.num_doc.HeaderText = "Numero Documento"
        Me.num_doc.Name = "num_doc"
        Me.num_doc.ReadOnly = True
        Me.num_doc.Width = 130
        '
        'pri_ape
        '
        Me.pri_ape.DataPropertyName = "pri_ape"
        Me.pri_ape.HeaderText = "Primer Apellido"
        Me.pri_ape.Name = "pri_ape"
        Me.pri_ape.ReadOnly = True
        Me.pri_ape.Width = 104
        '
        'seg_ape
        '
        Me.seg_ape.DataPropertyName = "seg_ape"
        Me.seg_ape.HeaderText = "Segundo Apellido"
        Me.seg_ape.Name = "seg_ape"
        Me.seg_ape.ReadOnly = True
        Me.seg_ape.Width = 118
        '
        'pri_nom
        '
        Me.pri_nom.DataPropertyName = "pri_nom"
        Me.pri_nom.HeaderText = "Primer Nombre"
        Me.pri_nom.Name = "pri_nom"
        Me.pri_nom.ReadOnly = True
        Me.pri_nom.Width = 104
        '
        'seg_nom
        '
        Me.seg_nom.DataPropertyName = "seg_nom"
        Me.seg_nom.HeaderText = "Segundo Nombre"
        Me.seg_nom.Name = "seg_nom"
        Me.seg_nom.ReadOnly = True
        Me.seg_nom.Width = 118
        '
        'unificado
        '
        Me.unificado.DataPropertyName = "unificado"
        Me.unificado.HeaderText = "Unificado"
        Me.unificado.Name = "unificado"
        Me.unificado.ReadOnly = True
        Me.unificado.Width = 77
        '
        'frmConsultaPorNombre
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(707, 273)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.dtgPacientes)
        Me.Name = "frmConsultaPorNombre"
        Me.Text = "frmConsultaPorNombre"
        CType(Me.dtgPacientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtgPacientes As System.Windows.Forms.DataGridView
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents tip_doc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents num_doc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pri_ape As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents seg_ape As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pri_nom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents seg_nom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents unificado As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
