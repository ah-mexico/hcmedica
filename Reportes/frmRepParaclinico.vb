Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes
Imports System.Collections.Generic
Imports Microsoft.Reporting.WinForms

Public Class frmRepParaclinico

 

    ' <summary>
    ' Metodo que permite imprimir el reporte de una deteminada
    ' evolucion de la historia clinica
    ' </summary>
    ' <param name="strcod_pre_sgs">Codigo del Prestador</param>
    ' <param name="strCod_sucur">Codigo de la sucursal</param>
    ' <param name="strTip_admision">Tipo de Admision a la que se realizo la evolucion</param>
    ' <param name="iAno_adm">Año de la Admision a la que se realizo la evolucion</param>
    ' <param name="lNum_adm">Numero de la Admision a la que se realizo la evolucion</param>
    ' <param name="strFecha_evol">Fecha de la evolucion</param>
    ' <param name="iHora_evol">Hora de realizacion de la Evolucion</param>
    ' <param name="iMin_evol">Minuto de realizacion de la Evolucion</param>
    ' <param name="strLogin">Login de realizacion de la Evolucion</param>
    ''' <remarks></remarks>
    Public Sub imprimirImagen(ByVal url As String)

        Try

            WebBrowser1.Navigate(url) ''("http://dexon.colsanitas.com/ServiceDesk/")
            Me.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        

    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted

    End Sub

    Private Sub WebBrowser1_Navigated(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserNavigatedEventArgs) Handles WebBrowser1.Navigated

    End Sub

End Class