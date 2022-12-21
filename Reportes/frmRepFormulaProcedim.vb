Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports System.Collections.Generic
Imports Microsoft.Reporting.WinForms

Public Class frmRepFormulaProcedim

    ''' <summary>
    ''' Funcion que llena el objeto que encapsula la info de la orden, lo enlaza con el reporte y lo pinta.  
    ''' </summary>
    ''' <param name="objConexion">Datos de la conexion</param>
    ''' <param name="strcod_pre_sgs">Codigo del prestador</param>
    ''' <param name="strCod_sucur">Codigo de la sucursal</param>
    ''' <param name="strTipAdm">Tipo de admision</param>
    ''' <param name="iAno">Año de admision</param>
    ''' <param name="lNumAdm">Numero de Admision</param>
    ''' <param name="dCon_procedim">Numero de orden de formulacion de procedimientos</param>
    ''' <remarks></remarks>
    Public Sub imprimirFormulaProcedim(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String, ByVal strCod_sucur As String, _
                                             ByVal strTipAdm As String, ByVal iAno As Integer, _
                                             ByVal lNumAdm As Long, ByVal dCon_procedim As Double, _
                                             ByVal esReimpresion As Boolean, ByVal blnContraReferencia As Boolean)

        Dim objOrden As Orden       ''Objeto que encapula la informacion de la orden
        Dim lerror As Long
        Dim objDatosGenerales As objGeneral.Generales

        objDatosGenerales = objGeneral.Generales.Instancia

        objOrden = New Orden

        Try
            ''Se consulta la base de datos con base en los parametros y se llena el objeto Orden con los
            ''datos obtenidos.
            lerror = objOrden.crearOrdenProcedimientos(objConexion, strcod_pre_sgs, strCod_sucur, strTipAdm, iAno, _
                                               lNumAdm, dCon_procedim)

            If lerror <> 0 Then
                If lerror = 99 Then
                    MsgBox("No existen datos para el número de formula. ")
                Else
                    MsgBox("Error en la consulta de la formula. ")
                End If
                Exit Sub
            End If


            If objDatosGenerales.Pais = "482" Then
                Me.ReportFormula.LocalReport.ReportEmbeddedResource = "HistoriaClinica.RepFormulaProcedimPeru.rdlc"
                Me.RepFormulaAutoriza.LocalReport.ReportEmbeddedResource = "HistoriaClinica.RepFormulaProcedimPeru.rdlc"
            Else
                Me.ReportFormula.LocalReport.ReportEmbeddedResource = "HistoriaClinica.RepFormulaProcedim.rdlc"
                Me.RepFormulaAutoriza.LocalReport.ReportEmbeddedResource = "HistoriaClinica.RepFormulaProcedim.rdlc"
            End If


            objOrden.EsReimpresion = esReimpresion

            ''Se enlaza el objeto que contiene la informacion de la orden con el origen de datos del reporte
            OrdenBindingSource.DataSource = objOrden
            ''Se enlaza el objeto que contiene la informacion del paciente con el origen de datos del reporte
            ''para los datos del paciente
            PacienteBindingSource.DataSource = objOrden.Paciente
            ''''Se enlaza el objeto que contiene la informacion de los procedimientos con el origen de datos del reporte
            ''para los datos del procedimientos
            ProcedimientoBindingSource.DataSource = objOrden.Procedimientos
            ''''Se enlaza el objeto que contiene la informacion de los diagnosticos con el origen de datos del reporte
            ''para los datos de los  diagnosticos
            DiagnosticoBindingSource.DataSource = objOrden.Diagnosticos

        Catch ex As Exception
            MsgBox("Error en la impresión de la orden. " & ex.Message, MsgBoxStyle.Critical)
        End Try

        With objOrden
            setParametrosReporte(blnContraReferencia, .requiereAutorizacion, .NumeroOrden, .Compañia)
        End With

        ''Si algunos de los procedimientos de la orden requiere autorizacion se debe imprimir un 
        ''desprendible con la informacion de los procedimientos y las recomendaciones para que el
        ''paciente lo conserve.

        If objOrden.requiereAutorizacion And blnContraReferencia = False Then
            Me.RepFormulaAutoriza.RefreshReport()
            Me.RepFormulaAutoriza.Visible = True
            Me.ReportFormula.Visible = False
        Else
            Me.ReportFormula.RefreshReport()
            Me.ReportFormula.Visible = True
            Me.RepFormulaAutoriza.Visible = False
        End If

    End Sub

    Private Sub RepFormulaAutoriza_RenderingComplete(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.RenderingCompleteEventArgs) Handles RepFormulaAutoriza.RenderingComplete
        'Me.RepFormulaAutoriza.SetDisplayMode(DisplayMode.PrintLayout)
        Me.RepFormulaAutoriza.ZoomMode = ZoomMode.PageWidth
    End Sub

    Private Sub ReportFormula_RenderingComplete(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.RenderingCompleteEventArgs) Handles ReportFormula.RenderingComplete
        ' Me.ReportFormula.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportFormula.ZoomMode = ZoomMode.PageWidth
    End Sub

    Public Sub setParametrosReporte(ByVal blnContraReferencia As Boolean, Optional ByVal blnRequiereAutorizacion As Boolean = False, _
                                    Optional ByVal strNumeroOrden As String = "", Optional ByVal strCompania As String = "")
        Dim aParametros(4) As ReportParameter

        aParametros(0) = New ReportParameter("FechaImpresion", Format(FuncionesGenerales.FechaServidor(), "dd/MM/yyyy HH:mm"))
        aParametros(1) = New ReportParameter("Copia", "N")
        aParametros(2) = New ReportParameter("ContraReferenciaP", blnContraReferencia)
        aParametros(3) = New ReportParameter("NumeroOrden", strNumeroOrden)
        aParametros(4) = New ReportParameter("Compania", strCompania)

        If blnRequiereAutorizacion = True And blnContraReferencia = False Then
            RepFormulaAutoriza.LocalReport.SetParameters(aParametros)
        Else
            ReportFormula.LocalReport.SetParameters(aParametros)
        End If


    End Sub

    Private Sub frmRepFormulaProcedim_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class