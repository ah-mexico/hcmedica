Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes
Imports System.Collections.Generic
Imports Microsoft.Reporting.WinForms
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports System.IO
''WACHV, 03-Abril-2017 Se agrega Libreria para manejo de Pdfs
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.xml

''' <summary>
''' Forma que contiene el control reportviewer con la informacion del reporte
''' </summary>
''' <remarks></remarks>
Public Class frmRepCondolencias
    Private _historiaClinica As FormatoHistoriaClinica
    Private newFile As String = ""

    Private Sub frmRepCondolencias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        MaximizeBox = False
        MinimizeBox = False

        StartPosition = FormStartPosition.CenterScreen

    End Sub
    Public Sub imprimirCondolencias(ByVal objConexion As Conexion, ByVal strCod_pre_sgs As String, _
                                ByVal strCod_sucur As String, ByVal strTipAdm As String, _
                                ByVal intAnoAdm As Integer, ByVal dNumAdm As Double, _
                                ByVal strTipDoc As String, ByVal strNumDoc As String)
        Try

            Dim dtCondolencias As DataTable

            dtCondolencias = New Sophia.HistoriaClinica.Reportes.DAO.CondolenciasDAO().dsConsultarCondolencias( _
            strCod_pre_sgs, strCod_sucur, strTipAdm, intAnoAdm, dNumAdm, strTipDoc, strNumDoc)

            If (dtCondolencias.Rows.Count > 0) Then
                'setParametrosReporte(dtCondolencias.Rows(0).Item("Apellidos").ToString(), _
                'dtCondolencias.Rows(0).Item("dir_cas_pac").ToString(), _
                'dtCondolencias.Rows(0).Item("CiudadCasaPac").ToString(), _
                'dtCondolencias.Rows(0).Item("Nombres").ToString())

                ''INICIO, WACHV, 03-Abril-2017 para Manipular el archivo plantilla y el archivo que se genera y se visualiza.
                Dim strRuta As String = ""
                Dim arrCarpetas As String() = System.AppDomain.CurrentDomain.BaseDirectory().Split("\")
                'For Each itemCarpeta As String In arrCarpetas
                'strRuta = strRuta & itemCarpeta & "\"
                'Dim strSubDirectories As String() = Directory.GetDirectories(strRuta, "Reportes")
                'Dim strSubDirectories As String() = Directory.GetDirectories(strRuta, "")
                'If strSubDirectories.Length > 0 Then
                'strRuta = strRuta & "Reportes\"
                'strRuta = strRuta
                'Exit For
                'End If
                '   Next
                strRuta = System.AppDomain.CurrentDomain.BaseDirectory()
                'comprobamos que el archivo existe, y se borra
                If System.IO.File.Exists(newFile) = True Then
                    'WebBrowser1.Navigate("about:blank")
                    'If Not (WebBrowser1 Is Nothing) Then WebBrowser1.Dispose()
                    System.IO.File.Delete(newFile)
                End If

                '''Proceso para Llenar el pdf y generar un archivo a visualizar
                Dim pdfTemplate As String = strRuta & "CartaCondolenciasCampos.pdf"
                If Not System.IO.File.Exists(pdfTemplate) Then
                    MsgBox("No existe Archivo de Plantilla CartaCondolenciasCampos.pdf, consulte al Administrador", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                '''Proceso para Llenar el pdf y generar un archivo a visualizar
                newFile = strRuta & "CartaCondolencias_" & strTipDoc & "_" & strNumDoc & ".pdf"

                If System.IO.File.Exists(newFile) = True Then System.IO.File.Delete(newFile)   'comprobamos que el archivo existe, y se borra

                Dim pdfReader As New PdfReader(pdfTemplate)
                Dim pdfStamper As New PdfStamper(pdfReader, New FileStream(newFile, FileMode.Create))
                Dim pdfFormFields As AcroFields = pdfStamper.AcroFields
                ' set form pdfFormFields

                ' The first worksheet and W-4 form
                pdfFormFields.SetField("Apellidos", dtCondolencias.Rows(0).Item("Apellidos").ToString())
                pdfFormFields.SetField("Direccion", dtCondolencias.Rows(0).Item("dir_cas_pac").ToString())
                pdfFormFields.SetField("Ciudad", dtCondolencias.Rows(0).Item("CiudadCasaPac").ToString())
                pdfFormFields.SetField("Mes_Anio", Format(Now, "MMMM").ToUpper() & "  -  " & Year(Now))
                pdfFormFields.SetField("Nombres", dtCondolencias.Rows(0).Item("Nombres").ToString())
                ' flatten the form to remove editting options, set it to false
                ' to leave the form open to subsequent manual edits
                pdfStamper.FormFlattening = True

                ' close the pdf
                pdfStamper.Close()
                pdfFormFields = Nothing
                pdfStamper.Reader.Close()
                pdfStamper = Nothing

                Dim tmpStr As String = "file:///" & newFile
                WebBrowser1.Navigate(tmpStr)
                'WebBrowser1.Dispose()
                'WebBrowser1.Refresh()
                'Else
                '    setParametrosReporte("", "", "", "")
            End If

            ''FIN, WACHV, 03-Abril-2017 para Manipular el archivo plantilla y el archivo que se genera y se visualiza.

            'Me.HCEncabezadoBindingSource.DataSource = objHcEncabezado
            'PacienteBindingSource.DataSource = objHcEncabezado.Paciente
            'Me.RepVCondolencias.ProcessingMode = ProcessingMode.Local


        Catch ex As Exception
            MsgBox("Error en la impresion del Condolencias. " & ex.Message, MsgBoxStyle.Critical)
        End Try
        'Me.RepVCondolencias.RefreshReport()
    End Sub
    Private Sub frmRepCondolencias_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            e.Cancel = False
            WebBrowser1.Hide()
            WebBrowser1.Navigate("about:blank")
            Do Until WebBrowser1.ReadyState = WebBrowserReadyState.Complete
                Application.DoEvents()
                System.Threading.Thread.Sleep(250)
            Loop
            WebBrowser1.Dispose()
            System.Threading.Thread.Sleep(250)
            If System.IO.File.Exists(newFile) = True Then System.IO.File.Delete(newFile)
        Catch ex As Exception
            'MsgBox("Error en la impresion del Condolencias. " & ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub
    'Private Sub RepVCondolencias_RenderingComplete(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.RenderingCompleteEventArgs)
    '    Me.RepVCondolencias.SetDisplayMode(DisplayMode.PrintLayout)
    '    'Me.RepVCondolencias.ZoomMode = ZoomMode.PageWidth
    '    Me.RepVCondolencias.ZoomMode = ZoomMode.Percent
    '    Me.RepVCondolencias.ZoomPercent = 90
    'End Sub

    'Public Sub setParametrosReporte(ByVal strApellidoFamilia As String, _
    'ByVal strDireccionCasa As String, ByVal strCiudadCasa As String, _
    'ByVal strNombres As String)
    '    Dim aParametros As New List(Of ReportParameter)
    '    aParametros.Add(New ReportParameter("Apellidos", strApellidoFamilia))
    '    aParametros.Add(New ReportParameter("Direccion", strDireccionCasa))
    '    aParametros.Add(New ReportParameter("Ciudad", strCiudadCasa))
    '    aParametros.Add(New ReportParameter("MesAnio", Format(FuncionesGenerales.FechaServidor(), "dd/MM/yyyy ")))
    '    aParametros.Add(New ReportParameter("Nombres", strNombres))
    '    RepVCondolencias.LocalReport.SetParameters(aParametros)
    'End Sub

End Class