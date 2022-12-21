Public Class frm_SISPRO
    Public Cod_SISPRO1 As String

    Private Sub db_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles db_aceptar.Click
        'Resolucion 084 Ajuste de mensaje cufe 15-16 rjamestre
        If Me.txt_SISPRO.Text = "" Then ' And Me.chk_sispro.CheckState = CheckState.Unchecked
            MsgBox("Debe digitar el código de autorización ministerio y en caso contrario si la página MIPRES no funciona, se debe ingresar el número ""11111111111111111111""")
            'MsgBox("debe digitar el código de autorización Ministerio y/o seleccionar Error Conexión SISPRO ")
        Else
            Me.Close()
        End If
    End Sub

    Public Sub Mostrar(ByVal Cod_SISPRO As String)
        Cod_SISPRO1 = Cod_SISPRO
        Me.txt_SISPRO.Text = Cod_SISPRO
        'Resolucion 084 Ajuste de mensaje cufe 15-16 rjamestre
        'Me.chk_sispro.CheckState = CheckState.Unchecked
        Me.ShowDialog()
        'If Me.chk_sispro.CheckState = CheckState.Checked Then
        'Cod_SISPRO1 = "Error SISPRO"
        'Else
        Cod_SISPRO1 = Me.txt_SISPRO.Text
        'End If
    End Sub

    Private Sub txt_SISPRO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_SISPRO.TextChanged
        Me.lbl_caracteres.Text = Len(txt_SISPRO.Text)
    End Sub

    Private Sub txt_SISPRO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_SISPRO.Validated
        If txt_SISPRO.Text <> "" Then
            If Len(txt_SISPRO.Text) <> 20 Then
                MsgBox("Código incompleto y/o máximo hasta 20 dígitos, revise la información")
                Me.txt_SISPRO.Focus()
            Else
                If IsNumeric(txt_SISPRO.Text) Then
                    Me.db_aceptar.Focus()
                Else
                    MsgBox("el campo debe ser numérico")
                    Me.txt_SISPRO.Focus()
                End If
            End If
        End If
    End Sub

    'Resolucion 084 Ajuste de mensaje cufe 15-16 rjamestre
    'Private Sub chk_sispro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Me.chk_sispro.CheckState = CheckState.Checked Then
    '        Me.txt_SISPRO.Text = ""
    '        Me.txt_SISPRO.Enabled = False
    '    Else
    '        Me.txt_SISPRO.Enabled = True
    '    End If
    'End Sub
End Class