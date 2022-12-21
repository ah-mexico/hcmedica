Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports System.Collections.Generic
Imports Microsoft.Reporting.WinForms

Public Class frmRepRecomendacionEgreso

    Private blnEsReimpresion As Boolean

    'Public Sub imprimirRepRecomendacionEgreso(ByVal objRecomendacion As RecomEgreso, ByVal strCodigoPrestador As String, _
    '                    ByVal strCodigoSucursal As String, ByVal strTipDoc As String, ByVal strNumDoc As String, _
    '                    ByVal strTipoAdmision As String, ByVal iAnoAdm As Integer, ByVal lNumAdm As Long)

    '    Dim objEncabezado As New RecomendacionEgreso

    '    Try
    '        objEncabezado.crearRecomendacionEgreso(strCodigoPrestador, strCodigoSucursal, strTipDoc, _
    '                                strNumDoc, strTipoAdmision, iAnoAdm, lNumAdm)


    '        RecomendacionEgresoBindingSource.DataSource = objEncabezado
    '        RecomEgresoBindingSource.DataSource = objRecomendacion
    '        ObjetoSimpleBindingSource.DataSource = objEncabezado.Procedimientos
    '        ObjetoAuxiliarBindingSource.DataSource = objEncabezado.Medicamentos

    '    Catch ex As Exception
    '        MsgBox("Error en la impresion. " & ex.Message, MsgBoxStyle.Critical)
    '    End Try

    '    setParametrosReporte()

    '    ReportViewer1.RefreshReport()

    'End Sub

    Public Sub imprimirRepRecomendacionEgreso(ByVal strCodigoPrestador As String, _
                        ByVal strCodigoSucursal As String, ByVal strTipDoc As String, ByVal strNumDoc As String, _
                        ByVal strTipoAdmision As String, ByVal iAnoAdm As Integer, ByVal lNumAdm As Long, _
                        Optional ByVal objRecomendacion As RecomEgreso = Nothing, _
                        Optional ByVal blnReimpresion As Boolean = False)

        Dim objEncabezado As New RecomendacionEgreso
        Dim objGen As objGeneral.Generales

        objGen = objGeneral.Generales.Instancia

        blnEsReimpresion = blnReimpresion

        Try
            objEncabezado.crearRecomendacionEgreso(strCodigoPrestador, strCodigoSucursal, strTipDoc, _
                                    strNumDoc, strTipoAdmision, iAnoAdm, lNumAdm, objRecomendacion)

            RecomendacionEgresoBindingSource.DataSource = objEncabezado
            ObjetoSimpleBindingSource.DataSource = objEncabezado.Procedimientos
            ObjetoAuxiliarBindingSource.DataSource = objEncabezado.Medicamentos

        Catch ex As Exception
            MsgBox("Error en la impresion. " & ex.Message, MsgBoxStyle.Critical)
        End Try


        If objGen.Pais = "482" Then ''Peru
            Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "HistoriaClinica.RepRecomendacionEgresoPeru.rdlc"
        Else
            Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "HistoriaClinica.RepRecomendacionEgreso.rdlc"
        End If


        setParametrosReporte()

        ReportViewer1.RefreshReport()

    End Sub

    Private Sub ReportViewer1_RenderingComplete(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.RenderingCompleteEventArgs) Handles ReportViewer1.RenderingComplete
        ''Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
    End Sub

    Public Sub setParametrosReporte()
        Dim aParametros As New List(Of ReportParameter)

        aParametros.Add(New ReportParameter("FechaImpresion", Format(FuncionesGenerales.FechaServidor(), "dd/MM/yyyy HH:mm")))
        aParametros.Add(New ReportParameter("Reimpresion", blnEsReimpresion))
        ReportViewer1.LocalReport.SetParameters(aParametros)

    End Sub

End Class