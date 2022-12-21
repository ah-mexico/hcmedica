Public Class frmVisualizarPdf

    Public Sub New(ByVal ruta As String)

        ' This call is required by the designer.
        InitializeComponent()
        frmVisualizarPdf(ruta)
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub frmVisualizarPdf(ByVal ruta As String)
        WebBrowser1.Navigate(New Uri(ruta))
    End Sub
End Class