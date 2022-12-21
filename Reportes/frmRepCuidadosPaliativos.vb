Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports System.Collections.Generic
Imports Microsoft.Reporting.WinForms
Imports System.Data.SqlClient

Public Class frmRepCuidadosPaliativos
    Dim objDescripcionQxParametros As List(Of DescripcionQx)
    Dim objDiagnostico As List(Of HistoriaClinica.Sophia.HistoriaClinica.Reportes.Diagnostico)

    Dim objHcEncabezado As New HCEncabezado()
    Public objDatosGenerales As objGeneral.Generales

    Public Sub imprimirCuidadosPaliativos(ByVal objConexion As Conexion, ByVal strCodigoPrestador As String, _
    ByVal strCodigoSucursal As String, ByVal strTip_admision As String, ByVal iAno_adm As Integer, _
    ByVal lNum_adm As String, Optional ByVal strTip_Doc As String = "", Optional ByVal strNum_Doc As String = "")

        Try

            Dim lstResultados As List(Of CuidadosPaliativos)

            objDatosGenerales = objGeneral.Generales.Instancia

            objHcEncabezado.consultarHcEncabezado(objConexion, strCodigoPrestador, strCodigoSucursal, _
                            strTip_admision, iAno_adm, lNum_adm)

            lstResultados = New CuidadosPaliativos().ConsultarReporteCuidadosPaliativos(strCodigoPrestador, strCodigoSucursal, _
            strTip_admision, iAno_adm, lNum_adm, strTip_Doc, strNum_Doc)

            CuidadosPaliativosBindingSource.DataSource = lstResultados

            setparametrosreporte()
            ReportViewer1.RefreshReport()

        Catch ex As Exception
            MsgBox("Error en la impresion. " & ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Public Sub setparametrosreporte()

        Dim hst As New Hashtable
        With objHcEncabezado
            hst.Add("Sucursal", .Sucursal)
            hst.Add("NroHistoria", .Paciente.NumeroDocumento)
            hst.Add("Secuencia", .secuencia)
            hst.Add("FechaImpresion", Format(FuncionesGenerales.FechaServidor(), "dd/MM/yyyy hh:mm"))
            hst.Add("Nombre", .Paciente.Nombre)
            hst.Add("Paciente", .Paciente.TipoDocumento & " " & .Paciente.NumeroDocumento)
            hst.Add("NroAdmision", .TipoAdmision & " " & .AnoAdmision & " " & .NumeroAdmision)
            hst.Add("Sexo", .Paciente.DescripSexo)
            hst.Add("Edad", .Paciente.Edad & " " & .Paciente.UnidadEdad)
            hst.Add("Entidad", .Entidad)
            hst.Add("Fecha", .Fecha)
            hst.Add("Hora", .Hora & " : " & .Minuto)
            hst.Add("Grupo", .Paciente.GrupoSanguineo)
            hst.Add("RH", .Paciente.FactorRH)
            hst.Add("Pais", .Pais)
        End With

        Dim aparametros(hst.Count - 1) As ReportParameter

        Dim i As Integer = 0
        For Each de As DictionaryEntry In hst
            aparametros(i) = New ReportParameter(de.Key.ToString(), de.Value.ToString())
            i += 1
        Next

        ReportViewer1.LocalReport.SetParameters(aparametros)
    End Sub

    Private Sub reportviewer1_renderingcomplete(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.RenderingCompleteEventArgs) Handles ReportViewer1.RenderingComplete
        ''Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        'Me.reportviewer1.zoommode = zoommode.pagewidth
    End Sub
End Class