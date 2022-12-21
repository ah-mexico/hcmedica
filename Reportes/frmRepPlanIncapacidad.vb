Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports Historiaclinica.Sophia.HistoriaClinica.DatosConexion
Imports objGenerales = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports System.Collections.Generic
Imports Microsoft.Reporting.WinForms

Public Class frmRepPlanIncapacidad

    Private blnEsReimpresion As Boolean



    Public Sub imprimirRepPlanIncapacidad(ByVal objConexion As Conexion, ByVal strCodigoPrestador As String, _
                        ByVal strCodigoSucursal As String, ByVal strTipDoc As String, ByVal strNumDoc As String, _
                        ByVal strTipoAdmision As String, ByVal iAnoAdm As Integer, ByVal lNumAdm As Long, _
                        Optional ByVal objIncapacidad As PlanIncapacidad = Nothing, _
                        Optional ByVal blnReimpresion As Boolean = False)

        Dim objEncabezado As New EncabezadoPlanManejo
        Dim objIncapacidadReporte As New Incapacidad
        Dim objDatosGenerales As objGenerales.Generales

        objDatosGenerales = objGenerales.Generales.Instancia

        blnEsReimpresion = blnReimpresion

        Try
            objEncabezado.crearEncabezado(strCodigoPrestador, strCodigoSucursal, strTipDoc, _
                                    strNumDoc, strTipoAdmision, iAnoAdm, lNumAdm)

            EncabezadoPlanManejoBindingSource.DataSource = objEncabezado

            'If objIncapacidad Is Nothing Then
            BLPlanManejo.ConsultarIncapacidad(objConexion, objIncapacidadReporte, strCodigoPrestador, _
            strCodigoSucursal, strTipoAdmision, iAnoAdm, lNumAdm)
            'Else
            '    With objIncapacidadReporte
            '        .Diagnostico = objIncapacidad.Diagnostico
            '        .Dias = objIncapacidad.Cantidad
            '        .FechaFinal = objIncapacidad.FechaFinal
            '        .FechaInicial = objIncapacidad.FechaInicial
            '        .Observaciones = objIncapacidad.Observacion
            '    End With
            'End If

            If objDatosGenerales.Pais = "482" Then ''Peru
                Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "HistoriaClinica.RepIncapacidadPeru.rdlc"
                Me.Text = "Descanso Médico"
            ElseIf objDatosGenerales.Pais = "484" Then
                Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "HistoriaClinica.RepIncapacidadVen.rdlc"
                Me.Text = "Reposo"
            End If


            IncapacidadBindingSource.DataSource = objIncapacidadReporte

        Catch ex As Exception
            MsgBox("Error en la impresion. " & ex.Message, MsgBoxStyle.Critical)
        End Try

        setParametrosReporte()

        'Se pinta el reporte
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