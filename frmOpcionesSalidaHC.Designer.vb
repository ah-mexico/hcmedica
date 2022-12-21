<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOpcionesSalidaHC
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
        Me.btnCerrarHistoria = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnPendiente = New System.Windows.Forms.Button
        Me.btnObservacion = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnCerrarHistoria
        '
        Me.btnCerrarHistoria.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCerrarHistoria.Location = New System.Drawing.Point(16, 41)
        Me.btnCerrarHistoria.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnCerrarHistoria.Name = "btnCerrarHistoria"
        Me.btnCerrarHistoria.Size = New System.Drawing.Size(123, 29)
        Me.btnCerrarHistoria.TabIndex = 0
        Me.btnCerrarHistoria.Text = "Cerrar Historia"
        Me.btnCerrarHistoria.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCancelar.Location = New System.Drawing.Point(396, 41)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(123, 29)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnPendiente
        '
        Me.btnPendiente.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnPendiente.Location = New System.Drawing.Point(269, 41)
        Me.btnPendiente.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnPendiente.Name = "btnPendiente"
        Me.btnPendiente.Size = New System.Drawing.Size(123, 29)
        Me.btnPendiente.TabIndex = 2
        Me.btnPendiente.Text = "Pendiente"
        Me.btnPendiente.UseVisualStyleBackColor = True
        '
        'btnObservacion
        '
        Me.btnObservacion.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnObservacion.Location = New System.Drawing.Point(143, 41)
        Me.btnObservacion.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnObservacion.Name = "btnObservacion"
        Me.btnObservacion.Size = New System.Drawing.Size(123, 29)
        Me.btnObservacion.TabIndex = 3
        Me.btnObservacion.Text = "Observación"
        Me.btnObservacion.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(191, 14)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Seleccione la accion a seguir:"
        '
        'frmOpcionesSalidaHC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(532, 85)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnObservacion)
        Me.Controls.Add(Me.btnPendiente)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnCerrarHistoria)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "frmOpcionesSalidaHC"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Opciones"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCerrarHistoria As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnPendiente As System.Windows.Forms.Button
    Friend WithEvents btnObservacion As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
