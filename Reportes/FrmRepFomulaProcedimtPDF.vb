
Imports Microsoft.Reporting.WinForms
Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes.Data
Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes.DAO

Public Class FrmRepFomulaProcedimtPDF
    ''' <summary>
    ''' Informacion del reporte
    ''' </summary>
    ''' <remarks></remarks>
    Private formulaData As FormulaProcedimData = Nothing
    ''' <summary>
    ''' Formatos en los que se puede exportar el reporte
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum FormatReport As Integer
        pdf = 0
        image = 1
        excel = 2
    End Enum

    ''' <summary>
    ''' Constructor de la clase
    ''' </summary>
    ''' <param name="codPrestador">Codigo prestador</param>
    ''' <param name="codSucursal">Codigo sucursal</param>
    ''' <param name="tipAdmin">Tipo Admision</param>
    ''' <param name="iAno">Año de admision</param>
    ''' <param name="lNumAdm">Numero de admision</param>
    ''' <param name="dConProcedim">Procedimiento</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal codPrestador As String, ByVal codSucursal As String, _
                    ByVal tipAdmin As String, ByVal iAno As Long, _
                    ByVal lNumAdm As Long, ByVal dConProcedim As Long, ByVal FlagConsulta As Long)
        Me.InitializeComponent()
        ''llenando los objeotos para los bindings del reporte
        Me.fillDataReportObj(codPrestador, codSucursal, _
                                    tipAdmin, iAno, lNumAdm, dConProcedim, FlagConsulta)
    End Sub

    ''' <summary>
    ''' Carga el formulario
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmRepFomulaProcedimPDF_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.viewFomulaProcedimPDF.RefreshReport()
    End Sub

    ''' <summary>
    ''' Obtiene los bytes del reporte
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
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
        End Select
        ''Inicializando los componentes
        Me.viewFomulaProcedimPDF.RefreshReport()
        Me.viewFomulaProcedimPDF.CreateControl()

        Return viewFomulaProcedimPDF.LocalReport.Render(format, Nothing, mimeType, _
            encoding, extension, streamids, warnings)
    End Function

    ''' <summary>
    ''' Llena los objetos con la informacion para generar el reporte
    ''' </summary>
    ''' <param name="codPrestador">Codigo prestador</param>
    ''' <param name="codSucursal">Codigo sucursal</param>
    ''' <param name="tipAdmin">Tipo Admision</param>
    ''' <param name="iAno">Año de admision</param>
    ''' <param name="lNumAdm">Numero de admision</param>
    ''' <param name="dConProcedim">Procedimiento</param>
    ''' <remarks></remarks>
    Private Sub fillDataReportObj(ByVal codPrestador As String, ByVal codSucursal As String, _
                    ByVal tipAdmin As String, ByVal iAno As Long, _
                    ByVal lNumAdm As Long, ByVal dConProcedim As Long, ByVal FlagConsulta As Long)

        Me.formulaData = New FormulaProcedimDAO().consultFormulProcedim(codPrestador, codSucursal, _
                                            tipAdmin, iAno, lNumAdm, dConProcedim, FlagConsulta)
        'jlalfonso 2009-07-07
        'se realiza validacion para procedimientos que no requieren autorizacion
        'no se muestra reporte pdf
        'solicitado por eforero.
        If formulaData IsNot Nothing Then
            ''Adicion de objetos a los binding del reporte
            Me.FormulaProcedimDataBindingSource.DataSource = formulaData
            Me.DetailFormulaProcedDataBindingSource.DataSource = formulaData.detalle
            'Me.DiagnFrmlProcedimDataBindingSource.DataSource = formulaData.diagnosticos
        End If
    End Sub

    ''' <summary>
    ''' Retorna la informacion del reporte generado
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property reportInfo() As FormulaProcedimData
        Get
            Return Me.formulaData
        End Get
    End Property

    Private Sub viewFomulaProcedimPDF_RenderingComplete(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.RenderingCompleteEventArgs) Handles viewFomulaProcedimPDF.RenderingComplete
        'Me.viewFomulaProcedimPDF.SetDisplayMode(DisplayMode.PrintLayout)
        Me.viewFomulaProcedimPDF.ZoomMode = ZoomMode.PageWidth
    End Sub
End Class