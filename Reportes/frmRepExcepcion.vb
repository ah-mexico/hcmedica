Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes
Imports System.Collections.Generic
Imports Microsoft.Reporting.WinForms
Imports HistoriaClinica.Mail
Imports System.Net.Mail
Imports System.IO

Public Class frmRepExcepcion
    Public Enum FormatReport As Integer
        pdf = 0
        image = 1
        excel = 2
        doc = 2
    End Enum


    Dim dtEncabezado As New DataTable
    Dim dtProducto As New DataTable
    Dim dtEvolucion As New DataTable
    Dim dtResumen As New DataTable
    Dim objExcepcionEnc As List(Of Excepciones)
    Dim objExcepcionProd As List(Of ExcepcionesProd)
    Dim objExcepcionDiagn As List(Of ExcepcionesDiag)
    Dim objExcepcionMotivo As List(Of ExcepcionesMot)
    Dim objExcepcionEvo As List(Of ExcepcionesEvo)
    Dim objconexion As Conexion
    ''' <summary>
    ''' <remarks></remarks>
    Public Sub imprimirRepExcepcion(ByVal strcod_pre_sgs As String, _
                   ByVal strCod_sucur As String, ByVal strTip_admision As String, _
                   ByVal iAno_adm As String, ByVal lNum_adm As Long, _
                   ByVal strtipDoc As String, ByVal Nrorden As Decimal, _
                   ByVal strnumDoc As String, ByVal strCodPro As String, ByVal intopcion As Integer, ByRef dtreportCtc As DataTable, ByVal secuencia As Integer)
        Try

            Dim objHcEncabezado As New HCEncabezado()   'Informacion del encabezado del reporte
            Dim objMedicamento As New Medicamento
            Dim dsreport As New DataSet
            Dim objExcepcion As New Excepciones


            'objHcEncabezado.consultarHcEncabezado(objconexion, strcod_pre_sgs, strCod_sucur, _
            '               strTip_admision, iAno_adm, lNum_adm)   ' ok

            dsreport = objExcepcion.TraerReporteCtc(strcod_pre_sgs, strCod_sucur, strTip_admision, iAno_adm, lNum_adm, _
                                           strtipDoc, strnumDoc, Nrorden, strCodPro, intopcion, secuencia)

            objExcepcionEnc = objExcepcion.CargarObjetoExcepcionesPac(dsreport.Tables(0))
            objExcepcionProd = objExcepcion.CargarObjetoExcepcionesProd_Proc(dsreport.Tables(1))
            dtreportCtc = dsreport.Tables(1)
            objExcepcionDiagn = objExcepcion.CargarObjetoExcepcionesDiagnostico(dsreport.Tables(2))
            objExcepcionEvo = objExcepcion.CargarObjetoExcepcionesEvolucion(dsreport.Tables(3))
            objExcepcionMotivo = objExcepcion.CargarObjetoExcepcionesMotivo(dsreport.Tables(4))




            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEventHandler

            'Se pinta el reporte



        Catch ex As Exception
            MsgBox("Error en la impresion. " & ex.Message, MsgBoxStyle.Critical)
        End Try
        ReportViewer1.RefreshReport()
    End Sub
    Private Function sendFormulaByMail(ByVal emalDestino As String, ByVal reportBytes As Byte(), _
                       ByVal reportName As String, ByVal smtpServer As String, _
                       ByVal rptContentType As String) As Boolean
        Dim mailEnviado As Boolean = False
        ''Llenado del objeto que contiene la informacion para el mensaje
        Dim mail As New MailData()
        ''direccion de destinatario

        MsgBox("Entra a envio")

#If DEBUG Then
        mail.toMail.Add(New MailAddress("cpgaray@colsanitas.com"))
#Else
        mail.toMail.Add(New MailAddress(emalDestino))
#End If


        ''direccion de remitente
        mail.from = New MailAddress("info-Sophia@colsanitas.com")   ' larb
        'mail.from = New MailAddress("no_responder@colsanitas.com")    
        mail.subject = "Solicitud de medicamento o procedimiento - Insumo No incluido en el POS"



        mail.body = ""
        ''Prueba del reporte en una ruta por defecto
        'Dim fs As New FileStream("c:\" & reportName, FileMode.Create)
        'fs.Write(reportBytes, 0, reportBytes.Length)
        'fs.Close()

        ''crear un stream en memoria
        Dim strmMemory As New MemoryStream(reportBytes, 0, reportBytes.Length)
        ''Crea el contenido
        Dim content As New System.Net.Mime.ContentType(rptContentType)

        content.Name = reportName

        ''crear el attach para el envio del reporte
        Dim attach As New Attachment(strmMemory, content)
        ''atachar el objeto en el contenido del mail
        mail.attachmets.Add(attach)

        'enviar el mail
        Dim mSender As New MailSender(smtpServer, 25, SmtpDeliveryMethod.Network)

        mSender.sendMail(mail)

        mailEnviado = True

        Return mailEnviado
    End Function

    Private Sub ReportViewer1_RenderingComplete(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.RenderingCompleteEventArgs) Handles ReportViewer1.RenderingComplete
        ''Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth        
    End Sub
    Public Sub SubreportProcessingEventHandler(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)

        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Excepciones", objExcepcionEnc))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_ExcepcionesProd", objExcepcionProd))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_ExcepcionesEvo", objExcepcionEvo))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_ExcepcionesMot", objExcepcionMotivo))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_ExcepcionesDiag", objExcepcionDiagn))

    End Sub

    Public Function getReportBytes(ByVal formatRpt As FormatReport) As Byte()
        Dim warnings As Warning() = Nothing
        Dim streamids As String() = Nothing
        Dim mimeType As String = Nothing
        Dim encoding As String = Nothing
        Dim extension As String = Nothing
        Dim format As String = "PDF"

        ''Seleccionando el formato para el render del reporte
        Select Case formatRpt
            Case FormatReport.pdf
                format = "PDF"
            Case FormatReport.image
                format = "IMAGE"
            Case FormatReport.excel
                format = "EXCEL"
            Case FormatReport.doc
                format = "DOC"
        End Select
        ''Inicializando los componentes

        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.CreateControl()

        Return ReportViewer1.LocalReport.Render(format, Nothing, mimeType, _
            encoding, extension, streamids, warnings)
    End Function


    Private Sub frmRepExcepcion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class