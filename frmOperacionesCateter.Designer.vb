<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmOperacionesCateter
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
        Me.pnlOperacionesCateter = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'pnlOperacionesCateter
        '
        Me.pnlOperacionesCateter.AutoScroll = True
        Me.pnlOperacionesCateter.Location = New System.Drawing.Point(9, 10)
        Me.pnlOperacionesCateter.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlOperacionesCateter.Name = "pnlOperacionesCateter"
        Me.pnlOperacionesCateter.Size = New System.Drawing.Size(823, 738)
        Me.pnlOperacionesCateter.TabIndex = 0
        '
        'frmOperacionesCateter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(840, 716)
        Me.Controls.Add(Me.pnlOperacionesCateter)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmOperacionesCateter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Operaciones Cateter"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlOperacionesCateter As System.Windows.Forms.Panel
End Class
