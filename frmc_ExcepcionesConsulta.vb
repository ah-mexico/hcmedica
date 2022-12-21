
Imports System
Public Class frmc_ExcepcionesConsulta

    Private strDoc As String
    Private strNum As String


    Public Sub New(ByVal dt As DataTable, ByVal strNum_doc As String, ByVal strTipDoc As String)
        InitializeComponent()
        dtgExcepciones.DataSource = dt
        strDoc = strTipDoc
        strNum = strNum_doc
        dtgExcepciones.Columns("Orden").Width = 50
        dtgExcepciones.Columns("Descripcion").Width = 200
        dtgExcepciones.Columns("Justificacion").Width = 250
        dtgExcepciones.Columns("tip_admision").Visible = False
        dtgExcepciones.Columns("num_adm").Visible = False
        dtgExcepciones.Columns("ano_adm").Visible = False
        dtgExcepciones.Columns("cod_pre_sgs").Visible = False
        dtgExcepciones.Columns("producto").Visible = False
        dtgExcepciones.Columns("Origen").Visible = False


    End Sub


    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        With dtgExcepciones.CurrentRow
            frmRepExcepcion.imprimirRepExcepcion(.Cells("cod_pre_sgs").Value, .Cells("cod_sucur").Value, .Cells("tip_admision").Value, _
            .Cells("ano_adm").Value, .Cells("num_adm").Value, strDoc, .Cells("Orden").Value, strNum, _
            .Cells("producto").Value, .Cells("Origen").Value)
            frmRepExcepcion.Show()
        End With


    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
End Class