
Public Class frmCriteriosIngresoPaliativo

    Public ctlCriIng As ctlCriterioIngreso

    Private Sub frmCriteriosIngresoPaliativo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Dim objBoton As Button
        Me.ctlCriIng = ctlCriterioIngreso.Instancia

        Me.ctlCriIng.Visible = True
        'objBoton = Me.ctlCriIng.Controls.SetChildIndex("btnGuardar")
        Me.pnlCriterioIngreso.Controls.Add(Me.ctlCriIng)

        Me.ctlCriIng.Show()
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False

        StartPosition = FormStartPosition.CenterScreen

        'Me.CenterToScreen()


    End Sub

    public Sub frmCriteriosIngresoPaliativo_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'Me.Close()
        e.Cancel = False
    End Sub

    Private Sub pnlCriterioIngreso_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlCriterioIngreso.Paint

    End Sub

    Private Sub frmCriteriosIngresoPaliativo_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        Me.Size = New System.Drawing.Size(ctlCriIng.Width + 25, ctlCriIng.Height + 50)
    End Sub

End Class