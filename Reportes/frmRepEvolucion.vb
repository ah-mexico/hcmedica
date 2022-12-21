Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes
Imports System.Collections.Generic
Imports Microsoft.Reporting.WinForms

Public Class frmRepEvolucion

    Private Sub frmRepEvolucion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    ''' <summary>
    ''' Metodo que permite imprimir el reporte de una deteminada
    ''' evolucion de la historia clinica
    ''' </summary>
    ''' <param name="strcod_pre_sgs">Codigo del Prestador</param>
    ''' <param name="strCod_sucur">Codigo de la sucursal</param>
    ''' <param name="strTip_admision">Tipo de Admision a la que se realizo la evolucion</param>
    ''' <param name="iAno_adm">Año de la Admision a la que se realizo la evolucion</param>
    ''' <param name="lNum_adm">Numero de la Admision a la que se realizo la evolucion</param>
    ''' <param name="strFecha_evol">Fecha de la evolucion</param>
    ''' <param name="iHora_evol">Hora de realizacion de la Evolucion</param>
    ''' <param name="iMin_evol">Minuto de realizacion de la Evolucion</param>
    ''' <param name="strLogin">Login de realizacion de la Evolucion</param>
    ''' <remarks></remarks>
    Public Sub imprimirRepEvolucion(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String, _
                   ByVal strCod_sucur As String, ByVal strTip_admision As String, _
                   ByVal iAno_adm As String, ByVal lNum_adm As Long, _
                   ByVal strFecha_evol As String, ByVal iHora_evol As Integer, _
                   ByVal iMin_evol As Integer, ByVal strLogin As String, ByVal strcierre As String)

        'martovar 2014-08-08 version 2.9.0 Generacion de interconsultas 

        Dim objEvolucion As New List(Of Evolucion)  'Informacion de la evolucion
        Dim objHcEncabezado As New HCEncabezado()   'Informacion del encabezado del reporte

        Try
            objHcEncabezado.consultarHcEncabezado(objConexion, strcod_pre_sgs, strCod_sucur, _
                            strTip_admision, iAno_adm, lNum_adm)   ' ok

            objEvolucion = New Evolucion().consultarEvolucion(objConexion, strcod_pre_sgs, strCod_sucur, _
                            strTip_admision, iAno_adm, lNum_adm, strFecha_evol, _
                            iHora_evol, iMin_evol, strLogin)

            If objEvolucion.Item(0).NotasIngreso.Length = 0 Then
                If objEvolucion.Item(0).Interconsulta.Length > 0 And objEvolucion.Item(0).Interconsulta <> "N" Then ''martovar version 2.9.0
                    If objEvolucion.Item(0).cierre = "S" Then
                        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "HistoriaClinica.RepEvolucionNOINTERCONSULTA.rdlc" ''martovar version 2.8.0
                    Else
                        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "HistoriaClinica.RepEvolucionINTERCONSULTA.rdlc" ''martovar version 2.8.0
                    End If
                Else
                    Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "HistoriaClinica.RepEvolucion.rdlc"
                End If
            Else
                Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "HistoriaClinica.RepEvolucionNI.rdlc"
            End If

            Me.HCEncabezadoBindingSource.DataSource = objHcEncabezado
            Me.EvolucionBindingSource.DataSource = objEvolucion
            Me.PacienteBindingSource.DataSource = objHcEncabezado.Paciente



        Catch ex As Exception
            MsgBox("Error en la impresion. " & ex.Message, MsgBoxStyle.Critical)
        End Try
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub ReportViewer1_RenderingComplete(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.RenderingCompleteEventArgs) Handles ReportViewer1.RenderingComplete
        ''Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
    End Sub

End Class