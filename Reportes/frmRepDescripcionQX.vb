Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports objPaciente = HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente.Paciente
Imports System.Collections.Generic
Imports Microsoft.Reporting.WinForms


Public Class frmRepDescripcionQX
    Dim objDescripcionQxParametros As List(Of DescripcionQx)
    Dim objDiagnostico As List(Of HistoriaClinica.Sophia.HistoriaClinica.Reportes.Diagnostico)
    Dim dtEquipoMedico As DataTable
    'Private objP As objPaciente.Paciente
    Dim objP As objPaciente = objPaciente.Instancia
    Private objDesc As New DescripcionQx
    Private blnEsReimpresion As Boolean
    Dim objHcEncabezado As New HCEncabezado()
    Public objDatosGenerales As objGeneral.Generales
    Public Sub imprimirDescripcionQuirurgica(ByVal objConexion As Conexion, ByVal strCodigoPrestador As String, ByVal strCodigoSucursal As String,
    ByVal strProcedim As String, ByVal strConsecutivo As Decimal, ByVal secuencia As Integer, ByVal strTip_admision As String, ByVal iAno_adm As Integer, ByVal lNum_adm As String,
      Optional ByVal strTip_Doc As String = "", Optional ByVal strNum_Doc As String = "")

        Try

            Dim dsresultados As DataSet
            Dim row() As DataRow
            Dim dtDescqx As New DataTable
            'objP = objPaciente.Paciente.Instancia
            objDatosGenerales = objGeneral.Generales.Instancia

            objHcEncabezado.consultarHcEncabezado(objConexion, strCodigoPrestador, strCodigoSucursal,
                            strTip_admision, iAno_adm, lNum_adm)

            dsresultados = New DescripcionQx().ConsultarReporteDescripcionQX(strCodigoPrestador, strCodigoSucursal, strProcedim, strConsecutivo, secuencia, strTip_admision, iAno_adm, lNum_adm, strTip_Doc, strNum_Doc)
            objDescripcionQxParametros = New DescripcionQx().CargarDescripcionQX(dsresultados.Tables(1), dsresultados.Tables(3))
            objDiagnostico = New DescripcionQx().CargarDiagnosticoDescripcionQX(dsresultados.Tables(0))
            ' objDiagnostico = New DescripcionQx().ConsultarDiagnosticoDescripcionQX(strCodigoPrestador, strCodigoSucursal, strProcedim, strConsecutivo)
            dtEquipoMedico = dsresultados.Tables(2)
            dtDescqx = dsresultados.Tables(1)
            ' row = dtEquipoMedico.Select("tip_empleado='C' and (estado='A' or estado='') and origen='qxprogpermedas'")

            'objDiagnostico = New DescripcionQx().Diagnosticos

            HCEncabezadoBindingSource.DataSource = objHcEncabezado
            DescripcionQxBindingSource.DataSource = objDescripcionQxParametros
            PacienteBindingSource.DataSource = objHcEncabezado.Paciente

            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEventHandler
            If dtDescqx.Rows.Count > 0 Then


                If objDatosGenerales.Pais = "482" Then ''agregar segundo registro médico para Perú. Cpgaray Octubre 21 de 2013
                    If Len(dtDescqx.Rows(0).Item("reg_med2").ToString()) = 0 Then
                        setParametrosReporte(dtDescqx.Rows(0).Item("Medico").ToString, dtDescqx.Rows(0).Item("espec_login_modif").ToString, dtDescqx.Rows(0).Item("reg_med").ToString())
                    Else
                        setParametrosReporte(dtDescqx.Rows(0).Item("Medico").ToString, dtDescqx.Rows(0).Item("espec_login_modif").ToString, dtDescqx.Rows(0).Item("reg_med").ToString() & " - " & dtDescqx.Rows(0).Item("reg_med2").ToString())
                    End If

                Else
                    setParametrosReporte(dtDescqx.Rows(0).Item("Medico").ToString, dtDescqx.Rows(0).Item("espec_login_modif").ToString, dtDescqx.Rows(0).Item("reg_med").ToString())
                End If


            Else
                row = dtEquipoMedico.Select("tip_empleado='C' and (estado='A' or estado='')")
                If row.Length > 0 Then

                    If objDatosGenerales.Pais = "482" Then ''agregar segundo registro médico para Perú. Cpgaray Octubre 21 de 2013
                        If Len(row(0).Item("reg_med2").ToString()) = 0 Then
                            setParametrosReporte(row(0).Item("Medico").ToString(), row(0).Item("descripcion1").ToString(), row(0).Item("reg_med").ToString())
                        Else
                            setParametrosReporte(row(0).Item("Medico").ToString(), row(0).Item("descripcion1").ToString(), row(0).Item("reg_med").ToString() & " - " & row(0).Item("reg_med2").ToString())
                        End If

                    Else
                        setParametrosReporte(row(0).Item("Medico").ToString(), row(0).Item("descripcion1").ToString(), row(0).Item("reg_med").ToString())
                    End If


                Else
                    setParametrosReporte("", "", "")
                End If

            End If


            'Se pinta el reporte
            ReportViewer1.RefreshReport()

        Catch ex As Exception
            MsgBox("Error en la impresion. " & ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub



    'Public Sub imprimirDescripcionQuirurgica(ByVal objConexion As Conexion, ByVal strCodigoPrestador As String, ByVal strCodigoSucursal As String, _
    'ByVal strProcedim As String, ByVal strConsecutivo As Decimal, ByVal secuencia As Integer, ByVal strTip_admision As String, ByVal iAno_adm As Integer, ByVal lNum_adm As String, _
    '  Optional ByVal strTip_Doc As String = "", Optional ByVal strNum_Doc As String = "")

    '    Try

    '        Dim dsresultados As DataSet
    '        Dim row() As DataRow
    '        Dim dtDescqx As New DataTable
    '        objDatosGenerales = objGeneral.Generales.Instancia

    '        objHcEncabezado.consultarHcEncabezado(objConexion, strCodigoPrestador, strCodigoSucursal, _
    '                        strTip_admision, iAno_adm, lNum_adm)

    '        dsresultados = New DescripcionQx().ConsultarReporteDescripcionQX(strCodigoPrestador, strCodigoSucursal, strProcedim, strConsecutivo, secuencia, strTip_admision, iAno_adm, lNum_adm, strTip_Doc, strNum_Doc)
    '        objDescripcionQxParametros = New DescripcionQx().CargarDescripcionQX(dsresultados.Tables(1), dsresultados.Tables(3))
    '        objDiagnostico = New DescripcionQx().CargarDiagnosticoDescripcionQX(dsresultados.Tables(0))
    '        ' objDiagnostico = New DescripcionQx().ConsultarDiagnosticoDescripcionQX(strCodigoPrestador, strCodigoSucursal, strProcedim, strConsecutivo)
    '        dtEquipoMedico = dsresultados.Tables(2)
    '        dtDescqx = dsresultados.Tables(1)
    '        ' row = dtEquipoMedico.Select("tip_empleado='C' and (estado='A' or estado='') and origen='qxprogpermedas'")

    '        'objDiagnostico = New DescripcionQx().Diagnosticos

    '        HCEncabezadoBindingSource.DataSource = objHcEncabezado
    '        DescripcionQxBindingSource.DataSource = objDescripcionQxParametros
    '        PacienteBindingSource.DataSource = objHcEncabezado.Paciente

    '        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEventHandler
    '        If dtDescqx.Rows.Count > 0 Then


    '            If objDatosGenerales.Pais = "482" Then ''agregar segundo registro médico para Perú. Cpgaray Octubre 21 de 2013
    '                If Len(dtDescqx.Rows(0).Item("reg_med2").ToString()) = 0 Then
    '                    setParametrosReporte(dtDescqx.Rows(0).Item("Medico").ToString, dtDescqx.Rows(0).Item("espec_login_modif").ToString, dtDescqx.Rows(0).Item("reg_med").ToString())
    '                Else
    '                    setParametrosReporte(dtDescqx.Rows(0).Item("Medico").ToString, dtDescqx.Rows(0).Item("espec_login_modif").ToString, dtDescqx.Rows(0).Item("reg_med").ToString() & " - " & dtDescqx.Rows(0).Item("reg_med2").ToString())
    '                End If

    '            Else
    '                setParametrosReporte(dtDescqx.Rows(0).Item("Medico").ToString, dtDescqx.Rows(0).Item("espec_login_modif").ToString, dtDescqx.Rows(0).Item("reg_med").ToString())
    '            End If


    '        Else
    '            row = dtEquipoMedico.Select("tip_empleado='C' and (estado='A' or estado='')")
    '            If row.Length > 0 Then

    '                If objDatosGenerales.Pais = "482" Then ''agregar segundo registro médico para Perú. Cpgaray Octubre 21 de 2013
    '                    If Len(row(0).Item("reg_med2").ToString()) = 0 Then
    '                        setParametrosReporte(row(0).Item("Medico").ToString(), row(0).Item("descripcion1").ToString(), row(0).Item("reg_med").ToString())
    '                    Else
    '                        setParametrosReporte(row(0).Item("Medico").ToString(), row(0).Item("descripcion1").ToString(), row(0).Item("reg_med").ToString() & " - " & row(0).Item("reg_med2").ToString())
    '                    End If

    '                Else
    '                    setParametrosReporte(row(0).Item("Medico").ToString(), row(0).Item("descripcion1").ToString(), row(0).Item("reg_med").ToString())
    '                End If


    '            Else
    '                setParametrosReporte("", "", "")
    '            End If

    '        End If


    '        'Se pinta el reporte
    '        ReportViewer1.RefreshReport()

    '    Catch ex As Exception
    '        MsgBox("Error en la impresion. " & ex.Message, MsgBoxStyle.Critical)
    '    End Try

    'End Sub



    Public Sub setParametrosReporte(ByVal strMedico As String, ByVal strEspecialidad As String, ByVal strReg As String)

        Dim aParametros(17) As ReportParameter

        aParametros(0) = New ReportParameter("Medico", strMedico)
        aParametros(1) = New ReportParameter("Especialidad", strEspecialidad)
        aParametros(2) = New ReportParameter("RegistroMedico", strReg)

        With objHcEncabezado


            aParametros(3) = New ReportParameter("Sucursal", .Sucursal)
            aParametros(4) = New ReportParameter("NroHistoria", .Paciente.NumeroDocumento)
            aParametros(5) = New ReportParameter("Fecha", .Fecha)
            aParametros(6) = New ReportParameter("Hora", .Hora & " : " & .Minuto)
            aParametros(7) = New ReportParameter("NroAdmision", .TipoAdmision & " " & .AnoAdmision & " " & .NumeroAdmision)
            aParametros(8) = New ReportParameter("Entidad", .Entidad)
            aParametros(9) = New ReportParameter("Paciente", .Paciente.TipoDocumento & " " & .Paciente.NumeroDocumento)
            aParametros(10) = New ReportParameter("Nombre", .Paciente.Nombre)
            aParametros(11) = New ReportParameter("Edad", .Paciente.Edad & " " & .Paciente.UnidadEdad)
            aParametros(12) = New ReportParameter("Sexo", .Paciente.DescripSexo)
            aParametros(13) = New ReportParameter("Grupo", .Paciente.GrupoSanguineo)
            aParametros(14) = New ReportParameter("RH", .Paciente.FactorRH)
            aParametros(15) = New ReportParameter("FechaImpresion", Format(FuncionesGenerales.FechaServidor(), "dd/MM/yyyy HH:mm"))
            'aParametros(13) = New ReportParameter("Ciudad", .Ciudad)
            aParametros(16) = New ReportParameter("Pais", .Pais)
            'aParametros(15) = New ReportParameter("dirSucursal", .DirSucursal)
            'aParametros(16) = New ReportParameter("telSucursal", .telSucursal)
            aParametros(17) = New ReportParameter("Secuencia", .secuencia)
        End With

        ReportViewer1.LocalReport.SetParameters(aParametros)
    End Sub

    Private Sub ReportViewer1_RenderingComplete(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.RenderingCompleteEventArgs) Handles ReportViewer1.RenderingComplete
        ''Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
    End Sub
    Public Sub SubreportProcessingEventHandler(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)

        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_DiagnosticosQx", objDiagnostico))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_DescripcionQx", objDescripcionQxParametros))
        e.DataSources.Add(New ReportDataSource("dtsEquipoMedico_HCDescripcionQX_ReporteEquipoMedico", dtEquipoMedico))

    End Sub


    Private Sub DiagnosticoBindingSource_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DiagnosticoBindingSource.CurrentChanged

    End Sub
End Class