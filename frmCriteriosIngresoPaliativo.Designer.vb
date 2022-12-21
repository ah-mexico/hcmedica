<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCriteriosIngresoPaliativo
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
        Me.pnlCriterioIngreso = New System.Windows.Forms.Panel
        Me.SuspendLayout()
        '
        'pnlCriterioIngreso
        '
        Me.pnlCriterioIngreso.AutoScroll = True
        Me.pnlCriterioIngreso.Location = New System.Drawing.Point(9, 10)
        Me.pnlCriterioIngreso.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.pnlCriterioIngreso.Name = "pnlCriterioIngreso"
        Me.pnlCriterioIngreso.Size = New System.Drawing.Size(823, 738)
        Me.pnlCriterioIngreso.TabIndex = 0
        '
        'frmCriteriosIngresoPaliativo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(840, 716)
        Me.Controls.Add(Me.pnlCriterioIngreso)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "frmCriteriosIngresoPaliativo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Criterios de Ingreso"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlCriterioIngreso As System.Windows.Forms.Panel
End Class
