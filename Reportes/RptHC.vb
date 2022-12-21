Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports Microsoft.Reporting.WinForms
Imports System.Net
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports System
Imports System.IO
Imports System.Web.Services.Protocols
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales.Generales
Imports objPaciente = HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente.Paciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO

Public Class RptHC
#Region "Propiedades"
    Private _historiaClinica As FormatoHistoriaClinica
    Public Property HistoriaClinica() As FormatoHistoriaClinica
        Get
            Return _historiaClinica
        End Get
        Set(ByVal Value As FormatoHistoriaClinica)
            _historiaClinica = Value
        End Set
    End Property
#End Region
    Private objDatosGenerales As Generales
    Private Credenciales As New NetworkCredential
    Private pInfo As ReportParameterInfoCollection
    Private paramList As Generic.List(Of ReportParameter)
    Dim objG As objGeneral = objGeneral.Instancia
    Dim objP As objPaciente = objPaciente.Instancia
    Dim objBl As New Sophia.HistoriaClinica.BL.BLRptHC_Enf_Med
    Dim IDPrograma As Integer
    Dim objconex As Conexion
    Dim CodHistoria As String
    Dim prestador As String
    Dim Sucursal As String
    Dim TipoAdmision As String
    Dim AnoAdmision As String
    Dim NumeroAdmision As String
    Dim NombreMedico As String

    Private Sub LoadReportConfig(ByVal NombreReporte As String)
        _historiaClinica = New FormatoHistoriaClinica()
        objDatosGenerales = Generales.Instancia
        Dim Credenciales As New NetworkCredential

        paramList = New Generic.List(Of ReportParameter)

        ReportViewer1.Reset()

        Credenciales.UserName = objDatosGenerales.Usr_Rpt_Sophia
        Credenciales.Domain = objDatosGenerales.Dom_Rpt_Sophia
        Credenciales.Password = objDatosGenerales.Pwd_Rpt_Sophia

        ReportViewer1.ServerReport.ReportServerCredentials.NetworkCredentials = Credenciales

        ReportViewer1.ServerReport.ReportServerUrl = New Uri(objDatosGenerales.Srv_Rpt_Sophia.ToString)
        ReportViewer1.ServerReport.ReportPath = objDatosGenerales.Ruta_Rpt_Sophia + NombreReporte

        ReportViewer1.ShowParameterPrompts = False
        ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.Percent
        ReportViewer1.ZoomPercent = 150
        ReportViewer1.ShowFindControls = True

        If (objDatosGenerales.OrigenAdm.ToString.ToUpper.Contains("[SOPHIA]").ToString Or objDatosGenerales.OrigenAdm.ToString.ToUpper.Contains("CECIMIN")) Then
            objDatosGenerales.OrigenAdm = ConsultarServRepDatosSensibles(objconex, objDatosGenerales.OrigenAdm.ToString)
        End If

        paramList.Add(New ReportParameter("Origen", objDatosGenerales.OrigenAdm, False))
    End Sub
    Private Function ConsultarServRepDatosSensibles(ByVal objConexion As Conexion, ByVal strOrigen As String) As String

        Dim objGeneral As New DAOGeneral()
        Dim lError As Long = -1
        Dim servidorReporte As String = ""
        Dim Datos() As Object
        Dim dtResultado As New DataTable

        ReDim Datos(2)
        Datos(0) = "HCL_RPT_RUTA_SOPHIA" 'String.Empty
        Datos(1) = 0
        Try
            dtResultado = objGeneral.EjecutarSPConParametros(strOrigen & "HCL_CONFIG_SRV_REPORTES", objConexion, 0, Datos)

            If dtResultado.Rows.Count Then
                servidorReporte = dtResultado.Rows(0)("OrigenAdm")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Return servidorReporte
    End Function

    Public Sub ImprimirHistoriaClinica(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String,
               ByVal strCod_sucur As String, ByVal strTip_admision As String,
               ByVal lano_adm As Integer, ByVal dnum_adm As Double, ByVal cod_historia As String,
               ByVal strTipDoc As String, ByVal strNumDoc As String,
               ByVal strTip_historia As String, ByVal GeneradoPor As String,
               ByVal VerAntecedentes As Boolean, ByVal strLogin As String, ByVal seccionesAdicionales As Secciones, ByVal edadPaciente As Integer,
                Optional ByVal strPermitirImprimir As String = "S",
               Optional ByVal fec_ini As String = "", Optional ByVal fec_fin As String = "")
        'Optional ByVal fec_ini As Date = Nothing, Optional ByVal fec_fin As Date = Nothing)

        Dim NombreReporte As String = "rptHCConsolidada"
        paramList = New Generic.List(Of ReportParameter)

        CodHistoria = cod_historia
        prestador = strcod_pre_sgs
        Sucursal = strCod_sucur
        TipoAdmision = strTip_admision
        AnoAdmision = lano_adm
        NumeroAdmision = dnum_adm
        NombreMedico = objG.Login
        IDPrograma = 56

        RptHC_FormOpen()

        LoadReportConfig(NombreReporte)

        paramList.Add(New ReportParameter("strtipdoc", strTipDoc, False))
        paramList.Add(New ReportParameter("strnumdoc", strNumDoc, False))
        'paramList.Add(New ReportParameter("fec_ini", CDate(fec_ini).ToString("yyyy-MM-dd HH:mm"), False))
        paramList.Add(New ReportParameter("fec_ini", CDate(fec_ini).ToString("yyyy-MM-dd ") + "00:00", False))

        'paramList.Add(New ReportParameter("fec_fin", CDate(fec_fin).ToString("yyyy-MM-dd HH:mm"), False))
        paramList.Add(New ReportParameter("fec_fin", CDate(fec_fin).ToString("yyyy-MM-dd ") + "23:59", False))
        paramList.Add(New ReportParameter("cod_pre_sgs", strcod_pre_sgs, False))
        paramList.Add(New ReportParameter("cod_sucur", strCod_sucur, False))

        paramList.Add(New ReportParameter("tip_admision", strTip_admision, False))
        paramList.Add(New ReportParameter("ano_adm", lano_adm, False))
        paramList.Add(New ReportParameter("num_adm", dnum_adm, False))
        paramList.Add(New ReportParameter("GeneradoPor", GeneradoPor, False))
        paramList.Add(New ReportParameter("ANTECEDENTES_HST", VerAntecedentes, False))

        ReportViewer1.ServerReport.SetParameters(paramList)

        pInfo = ReportViewer1.ServerReport.GetParameters()

        ReportViewer1.RefreshReport()

        _historiaClinica.consultarSeccionesAdicionales(objConexion, strcod_pre_sgs, strCod_sucur,
                                                  strTip_admision, lano_adm, dnum_adm, strTipDoc,
                                                  strNumDoc, strTip_historia, strLogin, edadPaciente, seccionesAdicionales)

    End Sub

    'Public Sub ReporteSignosVitalesEnfermeria(ByVal objConexion As Conexion,
    '                                          ByVal strcod_pre_sgs As String, ByVal strCod_sucur As String, ByVal strTip_admision As String,
    '                                          ByVal lano_adm As Integer, ByVal dnum_adm As Double, ByVal GeneradoPor As String)

    '    Dim NombreReporte As String = "rptEnfSignosVitales"
    '    paramList = New Generic.List(Of ReportParameter)

    '    LoadReportConfig(NombreReporte)
    '    paramList.Add(New ReportParameter("cod_pre_sgs", strcod_pre_sgs, False))
    '    paramList.Add(New ReportParameter("cod_sucur", strCod_sucur, False))
    '    paramList.Add(New ReportParameter("tip_admision", strTip_admision, False))
    '    paramList.Add(New ReportParameter("ano_adm", lano_adm, False))
    '    paramList.Add(New ReportParameter("num_adm", dnum_adm, False))
    '    paramList.Add(New ReportParameter("GeneradoPor", GeneradoPor, False))

    '    ReportViewer1.ServerReport.SetParameters(paramList)

    '    pInfo = ReportViewer1.ServerReport.GetParameters()

    '    ReportViewer1.RefreshReport()
    'End Sub

    Public Sub ReporteEvoluvionNotasEnfermeria(ByVal objConexion As Conexion,
                                              ByVal strcod_pre_sgs As String, ByVal strCod_sucur As String,
                                               ByVal strTip_admision As String, ByVal lano_adm As Integer,
                                               ByVal dnum_adm As Double, ByVal GeneradoPor As String,
                                              ByVal cod_historia As String)

        Dim NombreReporte As String = "rptEnfEvolucion"
        paramList = New Generic.List(Of ReportParameter)

        CodHistoria = cod_historia
        prestador = strcod_pre_sgs
        Sucursal = strCod_sucur
        TipoAdmision = strTip_admision
        AnoAdmision = lano_adm
        NumeroAdmision = dnum_adm
        NombreMedico = objG.Login
        IDPrograma = 44

        RptHC_FormOpen()

        LoadReportConfig(NombreReporte)
        paramList.Add(New ReportParameter("cod_pre_sgs", strcod_pre_sgs, False))
        paramList.Add(New ReportParameter("cod_sucur", strCod_sucur, False))
        paramList.Add(New ReportParameter("tip_admision", strTip_admision, False))
        paramList.Add(New ReportParameter("ano_adm", lano_adm, False))
        paramList.Add(New ReportParameter("num_adm", dnum_adm, False))
        paramList.Add(New ReportParameter("GeneradoPor", GeneradoPor, False))

        ReportViewer1.ServerReport.SetParameters(paramList)

        pInfo = ReportViewer1.ServerReport.GetParameters()

        ReportViewer1.RefreshReport()
    End Sub

    'Public Sub ImprimirControLiquidos(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String,
    '           ByVal strCod_sucur As String, ByVal strTip_admision As String,
    '           ByVal lano_adm As Integer, ByVal dnum_adm As Double,
    '           ByVal strTipDoc As String, ByVal strNumDoc As String,
    '           ByVal strTip_historia As String, ByVal strLogin As String, ByVal NombreReporte As String,
    '            ByVal dCod_Historia As Integer, ByVal fechaInicial As String, ByVal cantDias As Integer,
    '            ByVal peso As Double, ByVal edad As Double)

    '    paramList = New Generic.List(Of ReportParameter)

    '    LoadReportConfig(NombreReporte)

    '    paramList.Add(New ReportParameter("strtipdoc", strTipDoc, False))
    '    paramList.Add(New ReportParameter("strnumdoc", strNumDoc, False))
    '    paramList.Add(New ReportParameter("cod_pre_sgs", strcod_pre_sgs, False))

    '    paramList.Add(New ReportParameter("cod_sucur", strCod_sucur, False))
    '    paramList.Add(New ReportParameter("tip_admision", strTip_admision, False))
    '    paramList.Add(New ReportParameter("ano_adm", lano_adm, False))

    '    paramList.Add(New ReportParameter("num_adm", dnum_adm, False))
    '    paramList.Add(New ReportParameter("fecha", fechaInicial, False))
    '    paramList.Add(New ReportParameter("cantDif", cantDias, False))

    '    paramList.Add(New ReportParameter("codHistoria", dCod_Historia, False))
    '    paramList.Add(New ReportParameter("tipo", "LA", False))

    '    ReportViewer1.ServerReport.SetParameters(paramList)

    '    pInfo = ReportViewer1.ServerReport.GetParameters()

    '    ReportViewer1.ServerReport.Render("PDF")
    '    ReportViewer1.RefreshReport()

    'End Sub

    Public Sub ImprimirOrdenMedica(ByVal id_programa As String, ByVal cod_pre_sgs As String,
               ByVal Cod_sucur As String, ByVal Tip_admision As String,
               ByVal ano_adm As Integer, ByVal num_adm As Double, ByVal cod_historia As String, Optional ByVal NroOrden As String = " ",
               Optional ByVal Medico As String = " ", Optional ByVal RegMedico As String = " ",
               Optional ByVal Especialidad As String = " ", Optional ByVal Reimprimir As Boolean = False,
               Optional ByVal VistaGuardarMostrar As Boolean = False,
               Optional ByVal VistaControlados As Boolean = False)

        Dim NombreReporte As String = "rptTAOrdenesMedicas"
        paramList = New Generic.List(Of ReportParameter)

        CodHistoria = cod_historia
        prestador = cod_pre_sgs
        Sucursal = Cod_sucur
        TipoAdmision = Tip_admision
        AnoAdmision = ano_adm
        NumeroAdmision = num_adm
        NombreMedico = objG.Login
        IDPrograma = id_programa
        NroOrden = NroOrden

        RptHC_FormOpen()


        LoadReportConfig(NombreReporte)

        'If NroOrden = " " Then
        '    paramList.Add(New ReportParameter("NroOrden", "0", False))
        'Else
        '    paramList.Add(New ReportParameter("NroOrden", NroOrden, False))
        'End If

        Dim Strnull As String = Nothing

        If NroOrden Is Nothing Then
            paramList.Add(New ReportParameter("NroOrden", Strnull, False))
        Else
            paramList.Add(New ReportParameter("NroOrden", NroOrden, False))
        End If

        If Reimprimir = True Then
            paramList.Add(New ReportParameter("REIMPRESION", True, False))
        End If

        ''cdquiroga se adiciona control para visualizar medicamentos controlados
        If VistaGuardarMostrar = True Then
            paramList.Add(New ReportParameter("VistaGuardarMostrar", True, False))
        End If

        If VistaControlados = True Then
            paramList.Add(New ReportParameter("VistaControlados", True, False))
        End If
        ''cdquiroga se adiciona control para visualizar medicamentos controlados

        paramList.Add(New ReportParameter("cod_pre_sgs", cod_pre_sgs, False))
        paramList.Add(New ReportParameter("cod_sucur", Cod_sucur, False))

        paramList.Add(New ReportParameter("tip_admision", Tip_admision, False))
        paramList.Add(New ReportParameter("ano_adm", ano_adm, False))
        paramList.Add(New ReportParameter("num_adm", num_adm, False))
        paramList.Add(New ReportParameter("Medico", Medico, False))
        paramList.Add(New ReportParameter("RegistroMedico", RegMedico, False))
        paramList.Add(New ReportParameter("Especialidad", Especialidad, False))

        ReportViewer1.ServerReport.SetParameters(paramList)

        pInfo = ReportViewer1.ServerReport.GetParameters()

        ReportViewer1.RefreshReport()

    End Sub

    'Public Sub ImprimirEscalasEnfermeria(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String,
    '             ByVal strCod_sucur As String, ByVal strTip_admision As String,
    '             ByVal lano_adm As Integer, ByVal dnum_adm As Double,
    '             ByVal strTipDoc As String, ByVal strNumDoc As String, ByVal strQuienGenera As String, ByVal strIdEscala As String,
    '             Optional ByVal fec_ini As String = "", Optional ByVal fec_fin As String = "")

    '    Dim NombreReporte As String = "RepEnfEscalas"
    '    paramList = New Generic.List(Of ReportParameter)


    '    LoadReportConfig(NombreReporte)

    '    paramList.Add(New ReportParameter("STRTIPDOC", strTipDoc, False))
    '    paramList.Add(New ReportParameter("STRNUMDOC", strNumDoc, False))
    '    paramList.Add(New ReportParameter("FEC_INI", fec_ini.ToString(), False))

    '    paramList.Add(New ReportParameter("FEC_FIN", fec_fin.ToString(), False))
    '    paramList.Add(New ReportParameter("COD_PRE_SGS", strcod_pre_sgs, False))
    '    paramList.Add(New ReportParameter("COD_SUCUR", strCod_sucur, False))

    '    paramList.Add(New ReportParameter("TIP_ADMISION", strTip_admision, False))
    '    paramList.Add(New ReportParameter("ANO_ADM", lano_adm, False))
    '    paramList.Add(New ReportParameter("NUM_ADM", dnum_adm, False))
    '    paramList.Add(New ReportParameter("IDESCALA", strIdEscala.ToString(), False))
    '    paramList.Add(New ReportParameter("QUIENGENERA", strQuienGenera.ToString(), False))

    '    ReportViewer1.ServerReport.SetParameters(paramList)

    '    pInfo = ReportViewer1.ServerReport.GetParameters()

    '    ReportViewer1.RefreshReport()

    'End Sub

    Public Sub ImprimirEvolucion(ByVal objConexion As Conexion, ByVal cod_pre_sgs As String,
               ByVal Cod_sucur As String, ByVal Tip_admision As String,
               ByVal ano_adm As Integer, ByVal num_adm As Double,
               ByVal strTipDoc As String, ByVal strNumDoc As String,
               ByVal GeneradoPor As String, ByVal cod_historia As String,
               Optional ByVal fec_ini As String = "", Optional ByVal fec_fin As String = "")
        'Optional ByVal fec_ini As Date = Nothing, Optional ByVal fec_fin As Date = Nothing)

        Dim NombreReporte As String = "rptEvolucion"
        paramList = New Generic.List(Of ReportParameter)

        CodHistoria = cod_historia
        prestador = cod_pre_sgs
        Sucursal = Cod_sucur
        TipoAdmision = Tip_admision
        AnoAdmision = ano_adm
        NumeroAdmision = num_adm
        NombreMedico = objG.Login
        IDPrograma = 40

        RptHC_FormOpen()

        LoadReportConfig(NombreReporte)

        paramList.Add(New ReportParameter("strtipdoc", strTipDoc, False))
        paramList.Add(New ReportParameter("strnumdoc", strNumDoc, False))
        paramList.Add(New ReportParameter("fec_ini", fec_ini.ToString(), False))

        paramList.Add(New ReportParameter("fec_fin", fec_fin.ToString(), False))
        paramList.Add(New ReportParameter("cod_pre_sgs", cod_pre_sgs, False))
        paramList.Add(New ReportParameter("cod_sucur", Cod_sucur, False))

        paramList.Add(New ReportParameter("tip_admision", Tip_admision, False))
        paramList.Add(New ReportParameter("ano_adm", ano_adm, False))
        paramList.Add(New ReportParameter("num_adm", num_adm, False))
        paramList.Add(New ReportParameter("GeneradoPor", GeneradoPor, False))

        ReportViewer1.ServerReport.SetParameters(paramList)

        pInfo = ReportViewer1.ServerReport.GetParameters()

        ReportViewer1.RefreshReport()

    End Sub

    Public Sub ImprimirHistoricoIdentificadorRiesgo(ByVal objConexion As Conexion, ByVal strTipDoc As String, ByVal strNumDoc As String,
                                                    ByVal strcod_pre_sgs As String, ByVal strCod_sucur As String, ByVal strTip_admision As String,
                                                    ByVal ano_adm As Integer, ByVal dnum_adm As Double, ByVal cod_historia As String, Optional ByVal fec_ini As String = "",
                                                    Optional ByVal fec_fin As String = "", Optional ByVal QuinGenera As String = "")

        Dim NombreReporte As String = "RepIdentificadorRiesgoHis"
        paramList = New Generic.List(Of ReportParameter)

        CodHistoria = cod_historia
        prestador = strcod_pre_sgs
        Sucursal = strCod_sucur
        TipoAdmision = strTip_admision
        AnoAdmision = ano_adm
        NumeroAdmision = dnum_adm
        NombreMedico = objG.Login
        IDPrograma = 63

        RptHC_FormOpen()

        LoadReportConfig(NombreReporte)

        paramList.Add(New ReportParameter("STRTIPDOC", strTipDoc, False))
        paramList.Add(New ReportParameter("STRNUMDOC", strNumDoc, False))
        paramList.Add(New ReportParameter("FEC_INI", fec_ini.ToString(), False))
        paramList.Add(New ReportParameter("FEC_FIN", fec_fin.ToString(), False))
        paramList.Add(New ReportParameter("COD_PRE_SGS", strcod_pre_sgs, False))
        paramList.Add(New ReportParameter("COD_SUCUR", strCod_sucur, False))
        paramList.Add(New ReportParameter("TIP_ADMISION", strTip_admision, False))
        paramList.Add(New ReportParameter("ANO_ADM", ano_adm, False))
        paramList.Add(New ReportParameter("NUM_ADM", dnum_adm, False))
        paramList.Add(New ReportParameter("QUIENGENERA", QuinGenera.ToString(), False))

        ReportViewer1.ServerReport.SetParameters(paramList)

        pInfo = ReportViewer1.ServerReport.GetParameters()

        ReportViewer1.RefreshReport()

    End Sub

    'Inicia: INDRA/FABAICUE  18/03/2022
    'Proyecto: Sophia - Conciliación Medicamentos (Rporte Conciliaicon CU_CONC_11)
    'Cambio: Se crea metodo para imprimir reporte. 
    Public Sub ImprimirConciliacionMedicamentos(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String,
               ByVal strCod_sucur As String, ByVal strTip_admision As String,
               ByVal lano_adm As Integer, ByVal dnum_adm As Double, ByVal strTipDoc As String, ByVal strNumDoc As String,
                ByVal GeneradoPor As String, Optional ByVal fec_ini As String = "", Optional ByVal fec_fin As String = "")

        Dim NombreReporte As String = "rptHCConciliacionConsolidada"
        paramList = New Generic.List(Of ReportParameter)

        prestador = strcod_pre_sgs
        Sucursal = strCod_sucur
        TipoAdmision = strTip_admision
        AnoAdmision = lano_adm
        NumeroAdmision = dnum_adm
        NombreMedico = objG.Login
        IDPrograma = 56

        RptHC_FormOpen()

        LoadReportConfig(NombreReporte)

        paramList.Add(New ReportParameter("strtipdoc", strTipDoc, False))
        paramList.Add(New ReportParameter("strnumdoc", strNumDoc, False))

        If String.IsNullOrEmpty(fec_ini) = False And String.IsNullOrEmpty(fec_fin) = False Then
            paramList.Add(New ReportParameter("fec_ini", CDate(fec_ini).ToString("yyyy-MM-dd ") + "00:00:00", False))
            paramList.Add(New ReportParameter("fec_fin", CDate(fec_fin).ToString("yyyy-MM-dd ") + "23:59:00", False))
        End If

        paramList.Add(New ReportParameter("cod_pre_sgs", strcod_pre_sgs, False))
        paramList.Add(New ReportParameter("cod_sucur", strCod_sucur, False))

        paramList.Add(New ReportParameter("tip_admision", strTip_admision, False))
        paramList.Add(New ReportParameter("ano_adm", lano_adm, False))
        paramList.Add(New ReportParameter("num_adm", dnum_adm, False))
        paramList.Add(New ReportParameter("GeneradoPor", GeneradoPor, False))

        ReportViewer1.ServerReport.SetParameters(paramList)

        pInfo = ReportViewer1.ServerReport.GetParameters()

        ReportViewer1.RefreshReport()

    End Sub


#Region "Auditoria sobre la Historia Clinica en cada evento del ReportViewer"
    Private Sub ReportViewer1_ReportExport(sender As Object, e As ReportExportEventArgs) Handles ReportViewer1.ReportExport
        Try
            If e.Extension.Name <> "PDF" Then
                MessageBox.Show("Sólo se permite guardar en formato PDF.")
                e.Cancel = True
                Exit Sub
            Else
                If TipoAdmision Is Nothing Then
                    TipoAdmision = 0
                End If
                If objP.TipoAdmision Is Nothing Then
                    objBl.GrabarAuditoria(objconex, objP.CodHistoria, objG.Prestador, objG.Sucursal, TipoAdmision, AnoAdmision, NumeroAdmision, objG.Login, "EX", "", IDPrograma)
                Else
                    objBl.GrabarAuditoria(objconex, objP.CodHistoria, objG.Prestador, objG.Sucursal, objP.TipoAdmision, objP.AnoAdmision, objP.NumeroAdmision, objG.Login, "EX", "", IDPrograma)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'If e.Extension.Name <> "PDF" Then
        '    MessageBox.Show("Sólo se permite guardar en formato PDF.")
        '    e.Cancel = True
        '    Exit Sub
        'End If
    End Sub

    Private Sub ReportViewer1_Print(sender As Object, e As EventArgs) Handles ReportViewer1.Print
        Try
            If TipoAdmision Is Nothing Then
                TipoAdmision = 0
            End If
            If objP.TipoAdmision Is Nothing Then
                objBl.GrabarAuditoria(objconex, objP.CodHistoria, objG.Prestador, objG.Sucursal, TipoAdmision, AnoAdmision, NumeroAdmision, objG.Login, "IP", "", IDPrograma)
            Else
                objBl.GrabarAuditoria(objconex, objP.CodHistoria, objG.Prestador, objG.Sucursal, objP.TipoAdmision, objP.AnoAdmision, objP.NumeroAdmision, objG.Login, "IP", "", IDPrograma)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Public Sub RptHC_Enf_Med_FormOpen1()
    '    Try
    '        objBl.GrabarAuditoria(objconex, objP.CodHistoria, objG.Prestador, objG.Sucursal, objP.TipoAdmision, objP.AnoAdmision, objP.NumeroAdmision, objG.NombreMedico, "A", "", IDPrograma)
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    Public Sub RptHC_FormOpen()
        Try
            If TipoAdmision Is Nothing Then
                TipoAdmision = 0
            End If
            If objP.TipoAdmision Is Nothing Then
                objBl.GrabarAuditoria(objconex, objP.CodHistoria, objG.Prestador, objG.Sucursal, TipoAdmision, AnoAdmision, NumeroAdmision, objG.Login, "A", "", IDPrograma)
            Else
                objBl.GrabarAuditoria(objconex, objP.CodHistoria, objG.Prestador, objG.Sucursal, objP.TipoAdmision, objP.AnoAdmision, objP.NumeroAdmision, objG.Login, "A", "", IDPrograma)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub RptHC_FormEstado(ByVal objConexion As Conexion, ByVal id_programa As String, ByVal estado As String, ByVal obs As String)
        Try
            'If objP.TipoAdmision Is Nothing Then
            '    objBl.GrabarAuditoria(objconex, objP.CodHistoria, prestador, Sucursal, TipoAdmision, AnoAdmision, NumeroAdmision, NombreMedico, "A", "", IDPrograma)
            '    'objBl.GrabarAuditoria(objconex, objP.CodHistoria, objG.Prestador, objG.Sucursal, "", objP.AnoAdmision, objP.NumeroAdmision, objG.NombreMedico, estado, obs, id_programa)
            'Else
            '    objBl.GrabarAuditoria(objconex, objP.CodHistoria, prestador, Sucursal, TipoAdmision, AnoAdmision, NumeroAdmision, NombreMedico, "A", "", IDPrograma)
            '    'objBl.GrabarAuditoria(objconex, objP.CodHistoria, objG.Prestador, objG.Sucursal, objP.TipoAdmision, objP.AnoAdmision, objP.NumeroAdmision, objG.NombreMedico, estado, obs, id_programa)
            'End If
            If TipoAdmision Is Nothing Then
                TipoAdmision = 0
            End If
            If objP.TipoAdmision Is Nothing Then
                objBl.GrabarAuditoria(objconex, objP.CodHistoria, objG.Prestador, objG.Sucursal, TipoAdmision, AnoAdmision, NumeroAdmision, objG.Login, estado, obs, id_programa)
            Else
                objBl.GrabarAuditoria(objconex, objP.CodHistoria, objG.Prestador, objG.Sucursal, objP.TipoAdmision, objP.AnoAdmision, objP.NumeroAdmision, objG.Login, estado, obs, id_programa)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub RptHC_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            If TipoAdmision Is Nothing Then
                TipoAdmision = 0
            End If
            If objP.TipoAdmision Is Nothing Then
                objBl.GrabarAuditoria(objconex, objP.CodHistoria, objG.Prestador, objG.Sucursal, TipoAdmision, AnoAdmision, NumeroAdmision, objG.Login, "C", "", IDPrograma)
            Else
                objBl.GrabarAuditoria(objconex, objP.CodHistoria, objG.Prestador, objG.Sucursal, objP.TipoAdmision, objP.AnoAdmision, objP.NumeroAdmision, objG.Login, "C", "", IDPrograma)
            End If
            If _historiaClinica.SeccionesHC.Remision = True Then
                frmRepRemisionConsultaHC.Show()
                frmRepRemisionConsultaHC.imprimirRemision(_historiaClinica)

            ElseIf _historiaClinica.SeccionesHC.Recomendaciones = True Then
                frmRepRecomendacionesConsultaHC.Show()
                frmRepRecomendacionesConsultaHC.imprimirRecomendaciones(HistoriaClinica)

            ElseIf _historiaClinica.SeccionesHC.Triage = True Then
                frmRepTriageConsultaHC.Show()
                frmRepTriageConsultaHC.imprimirTriage(HistoriaClinica)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region
End Class