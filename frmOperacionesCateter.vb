
Public Class frmOperacionesCateter

    Public ctlInsercionCateter As ctlInsercionCateter
    Public ctlRetiroCateter As ctlRetiroCateter
    Public ctlSeguimientoCateter As ctlSeguimientoCateter
    Public iCaso As Integer = 0
    ''WACHV, se agrega para Activar o Inativar el control
    Public bActivarControles As Boolean = False

    Private Sub frmOperacionesCateter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.ctlInsercionCateter = ctlInsercionCateter.Instancia
        Me.ctlRetiroCateter = ctlRetiroCateter.Instancia
        Me.ctlSeguimientoCateter = ctlSeguimientoCateter.Instancia

        ctlSeguimientoCateter.bActivarControles = bActivarControles ''Si es True esta activo, Si es falso Inactivo


        Select Case iCaso
            Case 1 ''Activa Insercion
                ctlInsercionCateter.Visible = True
                Me.pnlOperacionesCateter.Controls.Add(Me.ctlInsercionCateter)
                ctlRetiroCateter.Visible = False
                ctlSeguimientoCateter.Visible = False
                Me.ctlInsercionCateter.Show()
            Case 2 ''Activa Retiro
                ctlInsercionCateter.Visible = False
                ctlRetiroCateter.Visible = True
                Me.pnlOperacionesCateter.Controls.Add(Me.ctlRetiroCateter)
                ctlSeguimientoCateter.Visible = False
                Me.ctlRetiroCateter.Show()
            Case 3 ''Seguimiento
                ctlInsercionCateter.Visible = False
                ctlRetiroCateter.Visible = False
                ctlSeguimientoCateter.Visible = True
                Me.pnlOperacionesCateter.Controls.Add(Me.ctlSeguimientoCateter)
                Me.ctlSeguimientoCateter.Show()
        End Select

        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False

        StartPosition = FormStartPosition.CenterScreen

    End Sub

    Public Sub frmOperacionesCateter_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'Me.Close()
        Select Case iCaso
            Case 3
                ctlSeguimientoCateter.Instancia.cguardar()
        End Select
        e.Cancel = False
    End Sub

    Private Sub frmCriteriosIngresoPaliativo_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged

        Select Case iCaso
            Case 1 ''Activa Insercion
                Me.Size = New System.Drawing.Size(ctlInsercionCateter.Width + 25, ctlInsercionCateter.Height + 50)
            Case 2 ''Activa Retiro
                Me.Size = New System.Drawing.Size(ctlRetiroCateter.Width + 25, ctlRetiroCateter.Height + 50)
            Case 3 ''Seguimiento
                Me.Size = New System.Drawing.Size(ctlSeguimientoCateter.Width + 25, ctlSeguimientoCateter.Height + 50)
        End Select



    End Sub

End Class