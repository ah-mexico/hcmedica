Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports System.Collections.Generic
Imports Microsoft.Reporting.WinForms

''' <summary>
''' Forma que contiene el control reportviewer con la informacion del reporte
''' </summary>
''' <remarks></remarks>
Public Class frmRepTriage

    ''' <summary>
    ''' Funcion que consulta la informacion del triage de un deteminado paciente, 
    ''' enlaza dicha informacion con el reporte y lo muestra
    ''' </summary>
    ''' <param name="strCod_pre_sgs">Codigo del prestador</param>
    ''' <param name="strCod_sucur">Codigo de la Sucursal</param>
    ''' <param name="strTipDoc">Codigo del tipo de documento</param>
    ''' <param name="strNumDoc">Numero de documento</param>
    ''' <param name="Estado">Detemina si el paciente es ADULTO o PEDIATRICO para mostrar o no hallazgos pediatricos</param>
    ''' <remarks></remarks>
    Public Sub imprimirTriage(ByVal objConexion As Conexion, ByVal strCod_pre_sgs As String, _
                              ByVal strCod_sucur As String, ByVal strTipDoc As String, _
                              ByVal strNumDoc As String, ByVal strTipAdm As String, _
                              ByVal intAnoAdm As Integer, ByVal dNumAdm As Double, _
                              ByVal Estado As String)

        Dim objTriage As Triage  'Objeto que contiene los datos del triage
        Dim existenDatos As Boolean

        objTriage = New Triage() 'Creacion del objeto

        Try
            ''Se realiza la consulta a la base de datos con base en los parametros y se llenan los 
            ''atributos del objeto triage.
            existenDatos = objTriage.llenarTriage(objConexion, strCod_pre_sgs, strCod_sucur, strTipDoc, strNumDoc, _
                                     strTipAdm, intAnoAdm, dNumAdm, Estado)

            If existenDatos Then
                ''Se enlaza el objeto fuente que utiliza el reporte con el objeto que contiene 
                ''la informacion del triage
                TriageBindingSource.DataSource = objTriage
                ''''Se enlaza el objeto paciente que utiliza el reporte con el objeto que contiene 
                ''la informacion del paciente contenido en el objeto triage
                PacienteBindingSource.DataSource = objTriage.Paciente

                setParametrosReporte()

                ''Muestra el reporte
                Me.RepVTriage.RefreshReport()
                'Me.RepVTriage.ShowPrintButton = False
            Else
                'MsgBox("No existen datos para el paciente.")
                Me.Hide()
                Me.Dispose(True)
            End If
        Catch ex As Exception
            MsgBox("Error en la impresion del Triage. " & ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub RepVTriage_RenderingComplete(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.RenderingCompleteEventArgs) Handles RepVTriage.RenderingComplete
        'Me.RepVTriage.SetDisplayMode(DisplayMode.PrintLayout)
        Me.RepVTriage.ZoomMode = ZoomMode.PageWidth
    End Sub

    Public Sub setParametrosReporte()
        Dim aParametros As New List(Of ReportParameter)

        aParametros.Add(New ReportParameter("FechaImpresion", Format(FuncionesGenerales.FechaServidor(), "dd/MM/yyyy HH:mm")))
        RepVTriage.LocalReport.SetParameters(aParametros)

    End Sub
End Class