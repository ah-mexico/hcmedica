<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ctlParticularidadesProc
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pCont = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'pCont
        '
        Me.pCont.AutoScroll = True
        Me.pCont.Location = New System.Drawing.Point(0, 8)
        Me.pCont.Name = "pCont"
        Me.pCont.Size = New System.Drawing.Size(600, 35)
        Me.pCont.TabIndex = 0
        '
        'ctlParticularidadesProc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pCont)
        Me.Margin = New System.Windows.Forms.Padding(3, 3, 3, 6)
        Me.Name = "ctlParticularidadesProc"
        Me.Size = New System.Drawing.Size(603, 51)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pCont As Panel
End Class
