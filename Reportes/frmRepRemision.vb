Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports System.Collections.Generic
Imports Microsoft.Reporting.WinForms

Public Class frmRepRemision

    Private blnEsReimpresion As Boolean


    Public Sub imprimirRepRemision(ByVal objConexion As Conexion, ByVal strCodigoPrestador As String, _
                       ByVal strCodigoSucursal As String, ByVal strTipDoc As String, _
                       ByVal strNumDoc As String, ByVal strTipoAdmision As String, _
                       ByVal iAnoAdm As Integer, ByVal lNumAdm As Long, _
                       Optional ByVal objRemision As PlanRemision = Nothing, _
                       Optional ByVal blnReimpresion As Boolean = False)

        Dim objRem As New RemisionPlanManejo
        Dim hayRemision As Boolean


        Try
            blnEsReimpresion = blnReimpresion
            hayRemision = objRem.crearRemision(strCodigoPrestador, strCodigoSucursal, strTipDoc, _
                                    strNumDoc, strTipoAdmision, iAnoAdm, lNumAdm)

            If Not hayRemision Then
                MsgBox("No existen datos para el paciente.")
                Exit Sub
            End If

            If objRemision Is Nothing Then
                BLPlanManejo.ConsultarRemision(objConexion, strCodigoPrestador, _
                             strCodigoSucursal, strTipoAdmision, iAnoAdm, lNumAdm, objRem)
            Else
                llenarRemision(objRemision, objRem)
            End If

            RemisionPlanManejoBindingSource.DataSource = objRem
            'PlanRemisionBindingSource.DataSource = objRemision

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

    Public Sub llenarRemision(ByVal objRemision As PlanRemision, ByRef objRemisionReporte As RemisionPlanManejo)
        With objRemisionReporte
            .DesInstitucion = objRemision.DesInstitucion
            .Servicio = objRemision.Servicio
            .MedicoConfirma = objRemision.MedicoConfirma
            .CargoMedico = objRemision.CargoMedico
            .DesAmbulancia = objRemision.DesAmbulancia
            .DesNivel = objRemision.DesNivel
            .Ananmesis = objRemision.Ananmesis
            .NumeroAutoriza = objRemision.NumeroAutorizacion
            .AuxiliarDiagnostico = objRemision.AuxiliarDiagnostico
            .Evolucion = objRemision.Evolucion
            .Diagnostico = objRemision.Diagnostico
            .Complicaciones = objRemision.Complicaciones
            .Tratamientos = objRemision.Tratamientos
            .Motivos = objRemision.Motivos
            .EstadoPaciente = objRemision.EstadoPaciente
            .FechaAutoriza = objRemision.FechaAutorizacion
            .HoraAutoriza = objRemision.HoraAutorizacion
            .MinutoAutoriza = objRemision.MinutoAutorizacion
            .Observaciones = objRemision.Observaciones

        End With
    End Sub

    Private Sub RemisionPlanManejoBindingSource_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemisionPlanManejoBindingSource.CurrentChanged

    End Sub

    Private Sub frmRepRemision_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class