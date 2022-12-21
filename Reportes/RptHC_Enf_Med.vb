Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports Microsoft.Reporting.WinForms
Imports System.Net 'libreria para consumo
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales.Generales
Imports objPaciente = HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente.Paciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports System.Collections.Generic
Imports Newtonsoft.Json 'mab libreria para enviar json
Imports Newtonsoft.Json.Linq
Imports System.IO 'mab
Imports RestSharp
Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion 'mab para conectarse a la bd
Imports DAOGeneral.ConsultarDiasHistorico
Imports System.Globalization.CultureInfo
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles





Public Class RptHC_Enf_Med

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
    Private _resumenHistoriaClinica As FormatoHistoriaClinica
    Private Credenciales As New NetworkCredential
    Private pInfo As ReportParameterInfoCollection
    Private parametros As List(Of ReportParameter) = New List(Of ReportParameter)()
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
    Dim nombrearchivo21 As String

    Dim objConexion1 As Conexion
    Dim VisibleRep1 As String
    Dim id_programa1 As String
    Dim strtipdoc1 As String
    Dim strnumdoc1 As String
    Dim fec_ini1 As Date
    Dim fec_fin1 As Date
    Dim hora_ini1 As String
    Dim hora_fin1 As String
    Dim tip_admision1 As String
    Dim ano_adm1 As String
    Dim num_adm1 As String
    Dim cod_sucur1 As String
    Dim cod_pre_sgs1 As String
    Dim ANTECEDENTES_HST1 As Boolean
    Dim dCon_procedim1 As String
    Dim Compania1 As String
    Dim ContraReferenciaP1 As Boolean
    Dim EsReimpresion1 As Boolean
    Dim dNro_Formula1 As String
    Dim MedicoPE1 As String
    Dim cod_historia1 As String
    Private objPaciente As Sophia.HistoriaClinica.DatosPaciente.Paciente

#Region "Carga el reporte con las credenciales"
    Private Sub LoadReportConfig(ByVal NombreReporte As String)
        _historiaClinica = New FormatoHistoriaClinica()
        objDatosGenerales = Generales.Instancia
        Dim Credenciales As New NetworkCredential

        parametros = New List(Of ReportParameter)()

        ReportViewer1.Reset()

        Credenciales.UserName = objDatosGenerales.Usr_Rpt_Sophia
        Credenciales.Domain = objDatosGenerales.Dom_Rpt_Sophia
        Credenciales.Password = objDatosGenerales.Pwd_Rpt_Sophia

        ReportViewer1.ServerReport.ReportServerCredentials.NetworkCredentials = Credenciales

        ReportViewer1.ServerReport.ReportServerUrl = New Uri(objDatosGenerales.Srv_Rpt_Sophia.ToString)
        ReportViewer1.ServerReport.ReportPath = objDatosGenerales.Ruta_Rpt_Sophia + NombreReporte

        ReportViewer1.ShowParameterPrompts = False
        ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote

        If NombreReporte <> "rptHCMedConsulta" Then
            ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Else
            ReportViewer1.SetDisplayMode(DisplayMode.Normal)
        End If

        ReportViewer1.ZoomMode = ZoomMode.Percent
        ReportViewer1.ZoomPercent = 150
        ReportViewer1.ShowFindControls = True
        If (objDatosGenerales.OrigenAdm.ToString.ToUpper.Contains("[SOPHIA]").ToString Or objDatosGenerales.OrigenAdm.ToString.ToUpper.Contains("CECIMIN")) Then
            objDatosGenerales.OrigenAdm = ConsultarServRepDatosSensibles(objconex, objDatosGenerales.OrigenAdm.ToString)
        End If
        'mab se pasa un espacio en blanco parcialmente
        'parametros.Add(New ReportParameter("ORIGEN", " ", False))
        parametros.Add(New ReportParameter("ORIGEN", objDatosGenerales.OrigenAdm, False))
    End Sub
#End Region
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

#Region "Impresion Reportes De Enfermeria"
    Public Sub ImprimirHistoriaClinica(ByVal objConexion As Conexion, ByVal VisibleRep As String, ByVal id_programa As String, Optional ByVal fec_ini As Date = Nothing, Optional ByVal fec_fin As Date = Nothing, Optional ByVal hor_ini As String = "", Optional ByVal hor_fin As String = "", Optional ByVal escala As String = "", Optional ByVal fec_escala As Date = Nothing)
        Try
            Dim NombreReporte As String = "rptHCEnfConsolidada"
            IDPrograma = id_programa
            objconex = objConexion
            RptHC_Enf_Med_FormOpen()
            LoadReportConfig(NombreReporte)

            parametros.Add(New ReportParameter("strtipdoc", objP.TipoDocumento))
            parametros.Add(New ReportParameter("strnumdoc", objP.NumeroDocumento))
            parametros.Add(New ReportParameter("fec_ini", Format(fec_ini, "yyyy-MM-dd")))
            parametros.Add(New ReportParameter("fec_fin", Format(fec_fin, "yyyy-MM-dd")))
            parametros.Add(New ReportParameter("hora_ini", hor_ini))
            parametros.Add(New ReportParameter("hora_fin", hor_fin))
            parametros.Add(New ReportParameter("tip_admision", objP.TipoAdmision))
            parametros.Add(New ReportParameter("ano_adm", objP.AnoAdmision))
            parametros.Add(New ReportParameter("num_adm", objP.NumeroAdmision))
            parametros.Add(New ReportParameter("GeneradoPor", objG.Login))
            parametros.Add(New ReportParameter("VisibleRep", VisibleRep))
            parametros.Add(New ReportParameter("intCodhistoria", objP.CodHistoria))
            parametros.Add(New ReportParameter("cod_sucur", objG.Sucursal))
            parametros.Add(New ReportParameter("cod_pre_sgs", objG.Prestador))
            parametros.Add(New ReportParameter("idescala", escala))
            parametros.Add(New ReportParameter("fecha_escalas", Format(fec_escala, "yyyy-MM-dd")))

            ReportViewer1.ServerReport.SetParameters(parametros)
            pInfo = ReportViewer1.ServerReport.GetParameters()

            ReportViewer1.RefreshReport()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub ImprimirHistoriaClinica_Med_Consulta(ByVal objConexion As Conexion, ByVal VisibleRep As String,
                                                    ByVal id_programa As String, ByVal strtipdoc As String,
                                                    ByVal strnumdoc As String, ByVal fec_ini As Date,
                                                    ByVal fec_fin As Date, ByVal hora_ini As String,
                                                    ByVal hora_fin As String, ByVal tip_admision As String,
                                                    ByVal ano_adm As String, ByVal num_adm As String,
                                                    ByVal cod_sucur As String,
                                                    ByVal cod_pre_sgs As String, ByVal ANTECEDENTES_HST As Boolean,
                                                    ByVal dCon_procedim As String, ByVal Compania As String,
                                                    ByVal ContraReferenciaP As Boolean, ByVal EsReimpresion As Boolean,
                                                    ByVal dNro_Formula As String, ByVal MedicoPE As String,
                                                    ByVal cod_historia As String)
        Try
            objConexion1 = objConexion
            VisibleRep1 = VisibleRep
            id_programa1 = id_programa
            strtipdoc1 = strtipdoc
            strnumdoc1 = strnumdoc
            fec_ini1 = fec_ini
            fec_fin1 = fec_fin
            hora_ini1 = hora_ini
            hora_fin1 = hora_fin
            tip_admision1 = tip_admision
            ano_adm1 = ano_adm
            num_adm1 = num_adm
            cod_sucur1 = cod_sucur
            cod_pre_sgs1 = cod_pre_sgs
            ANTECEDENTES_HST1 = ANTECEDENTES_HST
            dCon_procedim1 = dCon_procedim
            Compania1 = Compania
            ContraReferenciaP1 = ContraReferenciaP
            EsReimpresion1 = EsReimpresion
            dNro_Formula1 = dNro_Formula
            MedicoPE1 = MedicoPE
            cod_historia1 = cod_historia




            Dim NombreReporte As String = "rptHCMedConsulta"
            nombrearchivo21 = "rptHCMedConsulta"
            IDPrograma = id_programa
            objconex = objConexion

            CodHistoria = cod_historia
            prestador = cod_pre_sgs
            Sucursal = cod_sucur
            TipoAdmision = tip_admision
            AnoAdmision = ano_adm
            NumeroAdmision = num_adm
            NombreMedico = objG.Login

            If Compania Is Nothing Then
                Compania = " "
            End If

            If MedicoPE Is Nothing Or MedicoPE = "" Then
                MedicoPE = " "
            End If

            RptHC_Enf_Med_FormOpen1()

            LoadReportConfig(NombreReporte)

            parametros.Add(New ReportParameter("strtipdoc", strtipdoc))
            parametros.Add(New ReportParameter("strnumdoc", strnumdoc))
            parametros.Add(New ReportParameter("fec_ini", Format(fec_ini, "yyyy-MM-dd")))
            parametros.Add(New ReportParameter("fec_fin", Format(fec_fin, "yyyy-MM-dd")))
            parametros.Add(New ReportParameter("hora_ini", hora_ini))
            parametros.Add(New ReportParameter("hora_fin", hora_fin))
            parametros.Add(New ReportParameter("tip_admision", tip_admision))
            parametros.Add(New ReportParameter("ano_adm", ano_adm))
            parametros.Add(New ReportParameter("num_adm", num_adm))
            parametros.Add(New ReportParameter("GeneradoPor", objG.Login))
            parametros.Add(New ReportParameter("VisibleRep", VisibleRep))
            parametros.Add(New ReportParameter("cod_sucur", cod_sucur))
            parametros.Add(New ReportParameter("cod_pre_sgs", cod_pre_sgs))
            parametros.Add(New ReportParameter("ANTECEDENTES_HST", ANTECEDENTES_HST))
            parametros.Add(New ReportParameter("dCon_procedim", dCon_procedim))
            parametros.Add(New ReportParameter("Compania", Compania))
            parametros.Add(New ReportParameter("ContraReferenciaP", ContraReferenciaP))
            parametros.Add(New ReportParameter("EsReimpresion", EsReimpresion))
            parametros.Add(New ReportParameter("dNro_Formula", dNro_Formula))
            parametros.Add(New ReportParameter("MedicoPE", MedicoPE))

            ReportViewer1.ServerReport.SetParameters(parametros)
            pInfo = ReportViewer1.ServerReport.GetParameters()

            ReportViewer1.RefreshReport()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub ImprimirHistoriaClinica_Tree(ByVal objConexion As Conexion, ByVal VisibleRep As String,
                                       ByVal id_programa As String, ByVal tip_doc As String,
                                       ByVal num_doc As String, ByVal tip_admision As String,
                                        ByVal ano_adm As String, ByVal num_adm As String,
                                       ByVal medico As String, ByVal cod_historia As String,
                                       ByVal cod_sucur As String, ByVal cod_pre_sgs As String,
                                       Optional ByVal fec_ini As Date = Nothing,
                                       Optional ByVal fec_fin As Date = Nothing, Optional ByVal hor_ini As String = "",
                                       Optional ByVal hor_fin As String = "", Optional ByVal escala As String = "",
                                       Optional ByVal fec_escala As Date = Nothing)
        Try
            Dim NombreReporte As String = "rptHCEnfConsolidada"
            IDPrograma = id_programa
            objconex = objConexion

            CodHistoria = cod_historia
            prestador = cod_pre_sgs
            Sucursal = cod_sucur
            TipoAdmision = tip_admision
            AnoAdmision = ano_adm
            NumeroAdmision = num_adm
            NombreMedico = objG.Login

            RptHC_Enf_Med_FormOpen1()

            LoadReportConfig(NombreReporte)

            parametros.Add(New ReportParameter("strtipdoc", tip_doc))
            parametros.Add(New ReportParameter("strnumdoc", num_doc))
            parametros.Add(New ReportParameter("fec_ini", Format(fec_ini, "yyyy-MM-dd")))
            parametros.Add(New ReportParameter("fec_fin", Format(fec_fin, "yyyy-MM-dd")))
            parametros.Add(New ReportParameter("hora_ini", hor_ini))
            parametros.Add(New ReportParameter("hora_fin", hor_fin))
            parametros.Add(New ReportParameter("tip_admision", tip_admision))
            parametros.Add(New ReportParameter("ano_adm", ano_adm))
            parametros.Add(New ReportParameter("num_adm", num_adm))
            parametros.Add(New ReportParameter("GeneradoPor", objG.Login))
            parametros.Add(New ReportParameter("VisibleRep", VisibleRep))
            parametros.Add(New ReportParameter("intCodhistoria", cod_historia))
            parametros.Add(New ReportParameter("cod_sucur", cod_sucur))
            parametros.Add(New ReportParameter("cod_pre_sgs", cod_pre_sgs))
            parametros.Add(New ReportParameter("idescala", "'" & escala & "'"))
            parametros.Add(New ReportParameter("fecha_escalas", Format(fec_escala, "yyyy-MM-dd")))

            ReportViewer1.ServerReport.SetParameters(parametros)
            pInfo = ReportViewer1.ServerReport.GetParameters()

            ReportViewer1.RefreshReport()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub ImprimirHistoriaClinica_Triage(ByVal objConexion As Conexion, ByVal id_programa As String)
        Try
            Dim NombreReporte As String = "rptHCTriage"
            IDPrograma = id_programa
            objconex = objConexion
            RptHC_Enf_Med_FormOpen()
            LoadReportConfig(NombreReporte)

            parametros.Add(New ReportParameter("strtipdoc", objP.TipoDocumento))
            parametros.Add(New ReportParameter("strnumdoc", objP.NumeroDocumento))
            parametros.Add(New ReportParameter("fec_ini", Format(Date.Now, "yyyy-MM-dd")))
            parametros.Add(New ReportParameter("fec_fin", Format(Date.Now, "yyyy-MM-dd")))
            parametros.Add(New ReportParameter("hora_ini", "1"))
            parametros.Add(New ReportParameter("hora_fin", "23"))
            parametros.Add(New ReportParameter("cod_pre_sgs", objG.Prestador))
            parametros.Add(New ReportParameter("cod_sucur", objG.Sucursal))
            parametros.Add(New ReportParameter("tip_admision", objP.TipoAdmision))
            parametros.Add(New ReportParameter("num_adm", objP.NumeroAdmision))
            parametros.Add(New ReportParameter("ano_adm", objP.AnoAdmision))
            parametros.Add(New ReportParameter("GeneradoPor", objG.Login))

            ReportViewer1.ServerReport.SetParameters(parametros)
            pInfo = ReportViewer1.ServerReport.GetParameters()

            ReportViewer1.RefreshReport()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub ImprimirHistoriaClinica_Triage_1(ByVal objConexion As Conexion, ByVal id_programa As String,
                                                  ByVal cod_pre_sgs As String, ByVal cod_sucur As String,
                                                  ByVal tip_doc As String, ByVal num_doc As String,
                                                  ByVal tip_admision As String, ByVal ano_adm As String,
                                                  ByVal num_adm As String, ByVal cod_historia As String)
        Try
            Dim NombreReporte As String = "rptHCTriage"
            IDPrograma = id_programa
            objconex = objConexion

            CodHistoria = cod_historia
            prestador = cod_pre_sgs
            Sucursal = cod_sucur
            TipoAdmision = tip_admision
            AnoAdmision = ano_adm
            NumeroAdmision = num_adm
            NombreMedico = objG.Login

            RptHC_Enf_Med_FormOpen1()

            LoadReportConfig(NombreReporte)

            parametros.Add(New ReportParameter("strtipdoc", tip_doc))
            parametros.Add(New ReportParameter("strnumdoc", num_doc))
            parametros.Add(New ReportParameter("fec_ini", Format(Date.Now, "yyyy-MM-dd")))
            parametros.Add(New ReportParameter("fec_fin", Format(Date.Now, "yyyy-MM-dd")))
            parametros.Add(New ReportParameter("hora_ini", "1"))
            parametros.Add(New ReportParameter("hora_fin", "23"))
            parametros.Add(New ReportParameter("cod_pre_sgs", prestador))
            parametros.Add(New ReportParameter("cod_sucur", Sucursal))
            parametros.Add(New ReportParameter("tip_admision", TipoAdmision))
            parametros.Add(New ReportParameter("num_adm", NumeroAdmision))
            parametros.Add(New ReportParameter("ano_adm", AnoAdmision))
            parametros.Add(New ReportParameter("GeneradoPor", NombreMedico))

            ReportViewer1.ServerReport.SetParameters(parametros)
            pInfo = ReportViewer1.ServerReport.GetParameters()

            ReportViewer1.RefreshReport()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub ImprimirHistoriaClinica_Admision(ByVal objConexion As Conexion, ByVal id_programa As String)
        Try
            Dim NombreReporte As String = "rptHCAdmision"
            IDPrograma = id_programa
            objconex = objConexion
            RptHC_Enf_Med_FormOpen()
            LoadReportConfig(NombreReporte)

            parametros.Add(New ReportParameter("strtipdoc", objP.TipoDocumento))
            parametros.Add(New ReportParameter("strnumdoc", objP.NumeroDocumento))
            parametros.Add(New ReportParameter("fec_ini", Format(Date.Now, "yyyy-MM-dd")))
            parametros.Add(New ReportParameter("fec_fin", Format(Date.Now, "yyyy-MM-dd")))
            parametros.Add(New ReportParameter("cod_sucur", objG.Sucursal))
            parametros.Add(New ReportParameter("cod_pre_sgs", objG.Prestador))
            parametros.Add(New ReportParameter("tip_admision", objP.TipoAdmision))
            parametros.Add(New ReportParameter("ano_adm", objP.AnoAdmision))
            parametros.Add(New ReportParameter("num_adm", objP.NumeroAdmision))
            parametros.Add(New ReportParameter("GeneradoPor", objG.Login))
            parametros.Add(New ReportParameter("hora_ini", "1"))
            parametros.Add(New ReportParameter("hora_fin", "23"))
            parametros.Add(New ReportParameter("intAccion", "1"))
            parametros.Add(New ReportParameter("intEntAdmadmen", "1"))
            parametros.Add(New ReportParameter("strFlagPrincipal", "S"))
            parametros.Add(New ReportParameter("strLogin", objG.Login))

            ReportViewer1.ServerReport.SetParameters(parametros)
            pInfo = ReportViewer1.ServerReport.GetParameters()

            ReportViewer1.RefreshReport()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub ImprimirHistoriaClinica_Admision_1(ByVal objConexion As Conexion, ByVal id_programa As String,
                                                  ByVal cod_pre_sgs As String, ByVal cod_sucur As String,
                                                  ByVal tip_doc As String, ByVal num_doc As String,
                                                  ByVal tip_admision As String, ByVal ano_adm As String,
                                                  ByVal num_adm As String, ByVal cod_historia As String)
        Try
            Dim NombreReporte As String = "rptHCAdmision"
            IDPrograma = id_programa
            objconex = objConexion

            CodHistoria = cod_historia
            prestador = cod_pre_sgs
            Sucursal = cod_sucur
            TipoAdmision = tip_admision
            AnoAdmision = ano_adm
            NumeroAdmision = num_adm
            NombreMedico = objG.Login

            RptHC_Enf_Med_FormOpen1()

            LoadReportConfig(NombreReporte)

            parametros.Add(New ReportParameter("strtipdoc", tip_doc))
            parametros.Add(New ReportParameter("strnumdoc", num_doc))
            parametros.Add(New ReportParameter("fec_ini", Format(Date.Now, "yyyy-MM-dd")))
            parametros.Add(New ReportParameter("fec_fin", Format(Date.Now, "yyyy-MM-dd")))
            parametros.Add(New ReportParameter("cod_sucur", Sucursal))
            parametros.Add(New ReportParameter("cod_pre_sgs", prestador))
            parametros.Add(New ReportParameter("tip_admision", TipoAdmision))
            parametros.Add(New ReportParameter("ano_adm", AnoAdmision))
            parametros.Add(New ReportParameter("num_adm", NumeroAdmision))
            parametros.Add(New ReportParameter("GeneradoPor", NombreMedico))
            parametros.Add(New ReportParameter("hora_ini", "1"))
            parametros.Add(New ReportParameter("hora_fin", "23"))
            parametros.Add(New ReportParameter("intAccion", "1"))
            parametros.Add(New ReportParameter("intEntAdmadmen", "1"))
            parametros.Add(New ReportParameter("strFlagPrincipal", "S"))
            parametros.Add(New ReportParameter("strLogin", NombreMedico))

            ReportViewer1.ServerReport.SetParameters(parametros)
            pInfo = ReportViewer1.ServerReport.GetParameters()

            ReportViewer1.RefreshReport()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Public Sub ImprimirHistoriaClinica_Orden_Medica(ByVal objConexion As Conexion, ByVal id_programa As String, Optional ByVal NroOrden As String = " ")
    '    Try
    '        Dim NombreReporte As String = "rptTAOrdenesMedicas"
    '        IDPrograma = id_programa
    '        objconex = objConexion
    '        RptHC_Enf_Med_FormOpen()
    '        LoadReportConfig(NombreReporte)

    '        If NroOrden = " " Then
    '            parametros.Add(New ReportParameter("NroOrden", "0", False))
    '        Else
    '            parametros.Add(New ReportParameter("NroOrden", NroOrden, False))
    '        End If
    '        parametros.Add(New ReportParameter("cod_pre_sgs", objG.Prestador))
    '        parametros.Add(New ReportParameter("cod_sucur", objG.Sucursal))
    '        parametros.Add(New ReportParameter("tip_admision", objP.TipoAdmision))
    '        parametros.Add(New ReportParameter("ano_adm", objP.AnoAdmision))
    '        parametros.Add(New ReportParameter("num_adm", objP.NumeroAdmision))
    '        parametros.Add(New ReportParameter("Medico", objG.NombreMedico))
    '        parametros.Add(New ReportParameter("RegistroMedico", objG.RegistroMedico))
    '        parametros.Add(New ReportParameter("Especialidad", objG.DescripcionEspecialidad))

    '        ReportViewer1.ServerReport.SetParameters(parametros)
    '        pInfo = ReportViewer1.ServerReport.GetParameters()

    '        ReportViewer1.RefreshReport()
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    Public Sub ImprimirHistoriaClinica_Procedimientos_externos(ByVal objConexion As Conexion, ByVal id_programa As String,
                                                               ByVal strcod_pre_sgs As String, ByVal strCod_sucur As String,
                                                               ByVal strTipAdm As String, ByVal ano_adm As String,
                                                               ByVal num_adm As String, ByVal esReimpresion As Boolean,
                                                               ByVal blnContraReferencia As Boolean,
                                                               ByVal dCon_procedim As Double, ByVal cod_historia As String)
        Dim NombreReporte As String = "repEnfReimprimeProcedimExternos"
        IDPrograma = id_programa
        objconex = objConexion

        CodHistoria = objP.CodHistoria
        prestador = strcod_pre_sgs
        Sucursal = strCod_sucur
        TipoAdmision = strTipAdm
        AnoAdmision = ano_adm
        NumeroAdmision = num_adm
        NombreMedico = objG.Login

        RptHC_Enf_Med_FormOpen1()

        Dim objOrden As Orden       ''Objeto que encapula la informacion de la orden
        Dim lerror As Long

        objOrden = New Orden

        Try
            ''Se consulta la base de datos con base en los parametros y se llena el objeto Orden con los
            ''datos obtenidos.
            lerror = objOrden.crearOrdenProcedimientos(objConexion, strcod_pre_sgs, strCod_sucur, strTipAdm, ano_adm,
                                               num_adm, dCon_procedim)

            If lerror <> 0 Then
                If lerror = 99 Then
                    MsgBox("No existen datos para el número de formula. ")
                Else
                    MsgBox("Error en la consulta de la formula. ")
                End If
                Exit Sub
            End If

            objOrden.EsReimpresion = esReimpresion

        Catch ex As Exception
            MsgBox("Error en la impresión de la orden. " & ex.Message, MsgBoxStyle.Critical)
        End Try
        LoadReportConfig(NombreReporte)

        'parametros.Add(New ReportParameter("strnumdoc", objP.NumeroDocumento))
        parametros.Add(New ReportParameter("cod_pre_sgs", strcod_pre_sgs))
        parametros.Add(New ReportParameter("tip_admision", strTipAdm))
        parametros.Add(New ReportParameter("num_adm", num_adm))
        parametros.Add(New ReportParameter("ano_adm", ano_adm))
        parametros.Add(New ReportParameter("dCon_procedim", dCon_procedim))
        parametros.Add(New ReportParameter("cod_sucur", strCod_sucur))
        parametros.Add(New ReportParameter("Compania", objOrden.Compañia))
        parametros.Add(New ReportParameter("GeneradoPor", NombreMedico))
        parametros.Add(New ReportParameter("ContraReferenciaP", blnContraReferencia))

        ReportViewer1.ServerReport.SetParameters(parametros)
        pInfo = ReportViewer1.ServerReport.GetParameters()

        ReportViewer1.RefreshReport()
    End Sub

    Public Sub ImprimirHistoriaClinica_imprimirFormulaMedica(ByVal objConexion As Conexion, ByVal id_programa As String,
                                                               ByVal strcod_pre_sgs As String, ByVal strCod_sucur As String,
                                                               ByVal strTipAdm As String, ByVal ano_adm As String,
                                                               ByVal num_adm As String, ByVal formula As String,
                                                               ByVal esReimpresion As Boolean, ByVal medico As String,
                                                              ByVal cod_historia As String)

        Dim NombreReporte As String = "repEnfFormulacionMedicamentos"
        IDPrograma = id_programa
        objconex = objConexion

        CodHistoria = cod_historia
        prestador = strcod_pre_sgs
        Sucursal = strCod_sucur
        TipoAdmision = strTipAdm
        AnoAdmision = ano_adm
        NumeroAdmision = num_adm
        NombreMedico = objG.Login


        Dim objConsulta As New Sophia.HistoriaClinica.BL.BLBasicasGenerales
        Dim objGeneral As Sophia.HistoriaClinica.DatosGenerales.Generales
        Dim objPaciente As Sophia.HistoriaClinica.DatosPaciente.Paciente

        Dim objOrden As Orden       ''Objeto que encapsula la informacion de la orden
        objOrden = New Orden()      ''Creacion del objeto
        objOrden.crearOrdenMedicamentos(objConexion, strcod_pre_sgs, strCod_sucur,
                                            strTipAdm, ano_adm, num_adm, formula, esReimpresion)

        Dim strIndica As String
        strIndica = ""
        Dim strEspecialidad As String
        strEspecialidad = ""

        objGeneral = Sophia.HistoriaClinica.DatosGenerales.Generales.Instancia
        objPaciente = Sophia.HistoriaClinica.DatosPaciente.Paciente.Instancia

        ''Modificado por Claudia Garay 
        ''Solicitud Juan Diego Arenas
        ''Se modifica parametro medico login por medico que formula
        ''14 Diciembre de 2009

        ''strIndica = objConsulta.ConsultarMedicoPuertaEntrada(objConexion, strcod_pre_sgs, strCod_sucur, objPaciente.Entidad, medico, 0)
        'If strIndica <> "S" Then
        '    'llarias Se crea función para consultar la especialidad del médico que realiza la orden 2014-11-16
        strEspecialidad = objConsulta.ConsultarEspecialidad(objConexion, objOrden.Especialidad, 0)
        'strIndica = strEspecialidad
        strIndica = objGeneral.DescripcionEspecialidad
        'End If

        RptHC_Enf_Med_FormOpen1()

        LoadReportConfig(NombreReporte)

        parametros.Add(New ReportParameter("strCod_pre_sgs", prestador))
        parametros.Add(New ReportParameter("strCod_sucur", Sucursal))
        parametros.Add(New ReportParameter("EsReimpresion", esReimpresion))
        parametros.Add(New ReportParameter("lNumAdm", NumeroAdmision))
        parametros.Add(New ReportParameter("dNro_Formula", CInt(formula)))
        parametros.Add(New ReportParameter("strTipAdm", TipoAdmision))
        parametros.Add(New ReportParameter("iAno", AnoAdmision))
        parametros.Add(New ReportParameter("MedicoPE", strIndica))


        ReportViewer1.ServerReport.SetParameters(parametros)
        pInfo = ReportViewer1.ServerReport.GetParameters()

        ReportViewer1.RefreshReport()
    End Sub

    Public Sub ImprimirHistoriaClinica_imprimirIncapacidad(ByVal objConexion As Conexion, ByVal id_programa As String,
                                                               ByVal strcod_pre_sgs As String, ByVal strCod_sucur As String,
                                                               ByVal tip_doc As String, ByVal num_doc As String,
                                                               ByVal strTipAdm As String, ByVal ano_adm As String,
                                                               ByVal num_adm As String, ByVal cod_historia As String)

        Dim NombreReporte As String = "rptHCMedIncapacidad"
        IDPrograma = id_programa
        objconex = objConexion

        CodHistoria = cod_historia
        prestador = strcod_pre_sgs
        Sucursal = strCod_sucur
        TipoAdmision = strTipAdm
        AnoAdmision = ano_adm
        NumeroAdmision = num_adm
        NombreMedico = objG.Login

        RptHC_Enf_Med_FormOpen1()

        LoadReportConfig(NombreReporte)

        parametros.Add(New ReportParameter("strtipdoc", tip_doc))
        parametros.Add(New ReportParameter("strnumdoc", num_doc))
        parametros.Add(New ReportParameter("fec_ini", Format(Date.Now, "yyyy-MM-dd")))
        parametros.Add(New ReportParameter("fec_fin", Format(Date.Now, "yyyy-MM-dd")))
        parametros.Add(New ReportParameter("tip_admision", TipoAdmision))
        parametros.Add(New ReportParameter("ano_adm", AnoAdmision))
        parametros.Add(New ReportParameter("num_adm", NumeroAdmision))
        parametros.Add(New ReportParameter("GeneradoPor", NombreMedico))
        parametros.Add(New ReportParameter("cod_sucur", Sucursal))
        parametros.Add(New ReportParameter("cod_pre_sgs", prestador))
        parametros.Add(New ReportParameter("VisibleRep", "|srptIncapacidadMed|"))

        ReportViewer1.ServerReport.SetParameters(parametros)
        pInfo = ReportViewer1.ServerReport.GetParameters()

        ReportViewer1.RefreshReport()
    End Sub
    ' MAB 27/10/2021 se añade llamada a WS para envio de correo electronico del reporte 
    ''' <summary>
    ''' 25/11/2021 MABONILLAR CU01.ENVIAR POR CORREO ORDEN DE REMISIÓN A LA CRYC Se quitan los _ del servicio
    ''' 29/12/21 Miabonilla ALM 1700 nuevo parametro para condicionar el envio de correo
    Public Sub ImprimirHistoriaClinica_imprimirRemision(ByVal objConexion As Conexion, ByVal id_programa As String,
                                                               ByVal strcod_pre_sgs As String, ByVal strCod_sucur As String,
                                                               ByVal tip_doc As String, ByVal num_doc As String,
                                                               ByVal strTipAdm As String, ByVal ano_adm As String,
                                                               ByVal num_adm As String, ByVal cod_historia As String, ByVal env_correo As String)

        Dim NombreReporte As String = "rptHCMedRemision"
        Dim objRemision As PlanRemision
        objRemision = PlanRemision.Instancia
        Dim servicio = objRemision.Servicio
        servicio = StrConv(servicio, VbStrConv.Lowercase)
        Dim ptipodoc As String
        Dim pdoc As String


        IDPrograma = id_programa
        objconex = objConexion

        CodHistoria = cod_historia
        prestador = strcod_pre_sgs
        Sucursal = strCod_sucur
        TipoAdmision = strTipAdm
        AnoAdmision = ano_adm
        NumeroAdmision = num_adm
        NombreMedico = objG.Login

        RptHC_Enf_Med_FormOpen1()

        LoadReportConfig(NombreReporte)

        parametros.Add(New ReportParameter("strtipdoc", tip_doc))
        parametros.Add(New ReportParameter("strnumdoc", num_doc))
        parametros.Add(New ReportParameter("fec_ini", Format(Date.Now, "yyyy-MM-dd")))
        parametros.Add(New ReportParameter("fec_fin", Format(Date.Now, "yyyy-MM-dd")))
        parametros.Add(New ReportParameter("tip_admision", TipoAdmision))
        parametros.Add(New ReportParameter("ano_adm", AnoAdmision))
        parametros.Add(New ReportParameter("num_adm", NumeroAdmision))
        parametros.Add(New ReportParameter("GeneradoPor", NombreMedico))
        parametros.Add(New ReportParameter("cod_sucur", Sucursal))
        parametros.Add(New ReportParameter("cod_pre_sgs", prestador))


        ReportViewer1.ServerReport.SetParameters(parametros)
        pInfo = ReportViewer1.ServerReport.GetParameters()


        '29/12/21 Miabonilla solo se envia correo cuando se graba la remision
        If env_correo = "S" Then
            'Miabonilla 13/12/21 llamado de Ws de Token: ''''''''''''''''''''
            Dim objdaotoken As New DAOGeneral
            Dim errortoken As Long = 0

            Dim tablacorreo As DataTable = objdaotoken.EjecutarSPSinParametros("CONSULTAR_PARAMETROS_CORREONOTIFICALO", objConexion, errortoken)
            Dim urltoken As String = tablacorreo.Rows(0).Item("ENDPOINTTOKENAPIMANAGER")

            Dim usertoken As String = tablacorreo.Rows(0).Item("USERNAMEAPIMANAGER")
            Dim pastoken As String = tablacorreo.Rows(0).Item("PASSWORDAPIMANAGER")
            Dim tipotoken As String = tablacorreo.Rows(0).Item("GRANTTYPEAPIMANAGER")

            Dim clienttoken = New RestClient(urltoken)
            clienttoken.Timeout = -1
            Dim requesttoken = New RestRequest(Method.POST)
            'miabonilla Header
            Dim autotoken As String = tablacorreo.Rows(0).Item("AUTHORIZATIONTYPEAPIMANAGER")
            requesttoken.AddHeader("Authorization", autotoken)
            requesttoken.AddHeader("Content-Type", "application/x-www-form-urlencoded")
            'requesttoken.AddHeader("Cookie", "incap_ses_1439_2197031=5En9H6LNkyHsi/72Vlv4EwpYt2EAAAAA+DcryJ0hsULG/jaWtwuYwA==; visid_incap_2197031=R05XjI2pQ6+KkgBbOdxO7N/klmEAAAAAQUIPAAAAAADL86UCtXR3Og3c7uirryTA")

            requesttoken.AddParameter("username", usertoken)
            requesttoken.AddParameter("password", pastoken)
            requesttoken.AddParameter("grant_type", tipotoken)
            Dim responsetoken As IRestResponse = clienttoken.Execute(requesttoken)
            Dim respuestatoken As String = responsetoken.Content
            Dim jsontoken As JObject = JObject.Parse(respuestatoken)
            Dim tipotpken As String = jsontoken.Item("token_type")
            Dim tokentoken As String = jsontoken.Item("access_token")
            Dim Authorizationtoken As String = tipotpken + " " + tokentoken
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            ' MAB 27/10/2021 Variables para capturar desde base de datos los parametros para el envio del correo.
            Dim destinatario As String = ""
            Dim cuerpocorreo As String = ""
            Dim url As String = ""
            Dim asunto As String = ""
            Dim aplicacion As String = ""
            Dim objdao As New DAOGeneral
            Dim dt As New DataTable
            Dim cultureInfo As New System.Globalization.CultureInfo("en-US")

            destinatario = objdao.EjecutarSQLStrValor("GENPARSOPHIA (nolock)", objConexion, "valor", " nombrepar='RemisionEmailDestinario' ")
            cuerpocorreo = objdao.EjecutarSQLStrValor("GENPARSOPHIA (nolock)", objConexion, "valor", " nombrepar='RemisionEmailCuerpo' ")

            'url = objdao.EjecutarSQLStrValor("GENPARSOPHIA (nolock)", objConexion, "valor", " nombrepar='URL_SERVICIO_NOTIFICACION_ELECTRONICA' ")
            url = tablacorreo.Rows(0).Item("ENDPOINTENVIACORREONOTIFICALO")
            asunto = objdao.EjecutarSQLStrValor("GENPARSOPHIA (nolock)", objConexion, "valor", " nombrepar='RemisionEmailAsunto' ")
            aplicacion = objdao.EjecutarSQLStrValor("GENPARSOPHIA (nolock)", objConexion, "valor", " nombrepar='RemisionEmailaplicacion' ")

            dt = objdao.EjecutarSQLConParametros("genpacie", objConexion, "pri_nom,seg_nom,pri_ape,seg_ape", "tip_doc='" & tip_doc & "' and num_doc='" & num_doc & "'")
            '05/01/21 MIabonilla se deja el tipo de documento como esta en bd
            'ptipodoc = StrConv(tip_doc, VbStrConv.ProperCase)
            ptipodoc = tip_doc
            asunto = Replace(asunto, "@TIP_DOC", ptipodoc)
            pdoc = StrConv(num_doc, VbStrConv.ProperCase)
            asunto = Replace(asunto, "@NUM_DOC", pdoc)
            Dim nombrecompleto As String
            nombrecompleto = ""

            '17/12/21 Miabonilla, se valida la existencia de segundos nombres o apellidos

            If (dt.Rows(0).Item("pri_nom").ToString.Length > 0) Then
                nombrecompleto = nombrecompleto + StrConv(dt.Rows(0).Item("pri_nom"), VbStrConv.ProperCase)
            End If

            If (dt.Rows(0).Item("seg_nom").ToString.Length > 0) Then
                nombrecompleto = nombrecompleto + " " + StrConv(dt.Rows(0).Item("seg_nom"), VbStrConv.ProperCase)
            End If

            If (dt.Rows(0).Item("pri_ape").ToString.Length > 0) Then
                nombrecompleto = nombrecompleto + " " + StrConv(dt.Rows(0).Item("pri_ape"), VbStrConv.ProperCase)
            End If

            If (dt.Rows(0).Item("seg_ape").ToString.Length > 0) Then
                nombrecompleto = nombrecompleto + " " + StrConv(dt.Rows(0).Item("seg_ape"), VbStrConv.ProperCase)
            End If


            asunto = Replace(asunto, "@NOMBRE", nombrecompleto)



            'asunto = Replace(asunto, "@NOMBRE", StrConv(dt.Rows(0).Item("pri_nom"), VbStrConv.ProperCase) & " " & StrConv(dt.Rows(0).Item("seg_nom"), VbStrConv.ProperCase) & " " & StrConv(dt.Rows(0).Item("pri_ape"), VbStrConv.ProperCase) & " " & StrConv(dt.Rows(0).Item("seg_ape"), VbStrConv.ProperCase))

            asunto = Replace(asunto, "@SERVICIO", servicio)


            Dim nombreapellido = dt.Rows(0).Item("pri_nom") & " " & dt.Rows(0).Item("pri_ape") & " " & dt.Rows(0).Item("seg_ape")

            'MAB 27/10/2021 atrapamos el reporte en Bytes
            Dim warnings As Warning() = Nothing
            Dim streamids As String() = Nothing
            Dim mimeType As String = Nothing
            Dim encoding As String = Nothing
            Dim extension As String = Nothing
            Dim respuesta As String


            Dim rptBytes As Byte() = ReportViewer1.ServerReport.Render("PDF", Nothing, mimeType,
                encoding, extension, streamids, warnings)

            'MAB 27/10/2021 pasamos el reporte  a texto
            Dim adjunto As String = Convert.ToBase64String(rptBytes)


            'MAB 27/10/2021 Llamada del WS
            Try
                Dim client = New RestClient(url)
                Dim request = New RestRequest(Method.POST)
                client.Timeout = -1
                'miabonilla 14/12/21 se agregan datos del token
                request.AddHeader("Content-Type", "application/json")
                request.AddHeader("Authorization", Authorizationtoken)
                'request.AddHeader("Cookie", "incap_ses_1439_2197031=5En9H6LNkyHsi/72Vlv4EwpYt2EAAAAA+DcryJ0hsULG/jaWtwuYwA==; visid_incap_2197031=R05XjI2pQ6+KkgBbOdxO7N/klmEAAAAAQUIPAAAAAADL86UCtXR3Og3c7uirryTA; BIGipServer~PreProduccion~Pool_Pre_Colsanitas-psvc01=372118188.19490.0000; BIGipServer~PreProduccion~Pool_Pre_Colsanitas_Osi_Api=422449836.23584.0000")

                Dim body = "{" + vbCr +
                """aplicacion"": """ + aplicacion + """," + vbCr +
                " ""emailIn"": {" + vbCr +
                 " ""mailConfirmacion"": """"," + vbCr +
                "		""adjuntos"": [" + vbCr +
                "			{" + vbCr +
                """contenido"": """ + adjunto + """," + vbCr +
                """nombre"": ""Remision de " + nombreapellido + ".pdf""" + vbCr +
                "			}" + vbCr +
                "		]," + vbCr +
                 """asunto"": """ + asunto + """," + vbCr +
                "		""certimail"": ""CNC""," + vbCr +
                         """mensaje"": """ + cuerpocorreo + """," + vbCr +
                "		""dummy"": """"," + vbCr +
                "		""observaciones"": """"," + vbCr +
                 """destinatario"": """ + destinatario + """" + vbCr +
                "	}" + vbCr +
                "}"
                request.AddParameter("application/json", body, ParameterType.RequestBody)
                Dim response As IRestResponse = client.Execute(request)



                respuesta = response.Content
            Catch ex As Exception
                MsgBox("Error enviando el correo")
            End Try
            ' fin mab

            If respuesta = "" Then
                MsgBox("No responde WS de correo")
            End If

            'ReportViewer1.Dispose()
            'MAB 27/10/2021 Generamos log de respuesta
            Dim Datos() As Object

            ReDim Datos(11)
            Datos(0) = prestador
            Datos(1) = Sucursal
            Datos(2) = TipoAdmision
            Datos(3) = AnoAdmision
            Datos(4) = NumeroAdmision
            Datos(5) = asunto
            Datos(6) = cuerpocorreo

            'Capturamos la respuesta
            Try
                Dim json As JObject = JObject.Parse(respuesta)
                Datos(7) = json.Item("codigoRespuesta")
                Datos(8) = json.Item("mensajeRespuesta")
                Datos(9) = json.Item("idProceso")
            Catch ex As Exception
                ' MsgBox(ex.Message)
                Datos(7) = "KO"
                Datos(8) = "timeout"
                Datos(9) = ""
            End Try




            Datos(10) = destinatario
            dt = objdao.EjecutarSPConParametros("SP_HC_REMISION_REGISTROLOG", objConexion, 0, Datos)
        End If
        ReportViewer1.RefreshReport()

    End Sub

    Public Sub ImprimirHistoriaClinica_imprimirCuidadosPaliativos(ByVal objConexion As Conexion, ByVal id_programa As String,
                                                               ByVal strcod_pre_sgs As String, ByVal strCod_sucur As String,
                                                               ByVal strTipAdm As String, ByVal ano_adm As String,
                                                               ByVal num_adm As String, ByVal tip_doc As String,
                                                               ByVal num_doc As String, ByVal cod_historia As String)

        Dim NombreReporte As String = "rptHCMedCuidadosPaliativos"
        IDPrograma = id_programa
        objconex = objConexion

        CodHistoria = cod_historia
        prestador = strcod_pre_sgs
        Sucursal = strCod_sucur
        TipoAdmision = strTipAdm
        AnoAdmision = ano_adm
        NumeroAdmision = num_adm
        NombreMedico = objG.Login

        RptHC_Enf_Med_FormOpen1()

        LoadReportConfig(NombreReporte)

        parametros.Add(New ReportParameter("strtipdoc", tip_doc))
        parametros.Add(New ReportParameter("strnumdoc", num_doc))
        parametros.Add(New ReportParameter("fec_ini", Format(Date.Now, "yyyy-MM-dd")))
        parametros.Add(New ReportParameter("fec_fin", Format(Date.Now, "yyyy-MM-dd")))
        parametros.Add(New ReportParameter("tip_admision", TipoAdmision))
        parametros.Add(New ReportParameter("ano_adm", AnoAdmision))
        parametros.Add(New ReportParameter("num_adm", NumeroAdmision))
        parametros.Add(New ReportParameter("GeneradoPor", NombreMedico))
        parametros.Add(New ReportParameter("cod_sucur", Sucursal))
        parametros.Add(New ReportParameter("cod_pre_sgs", prestador))
        parametros.Add(New ReportParameter("VisibleRep", "|srptCuidadosPaliativos|"))
        parametros.Add(New ReportParameter("ID_SECCION", 0))

        ReportViewer1.ServerReport.SetParameters(parametros)
        pInfo = ReportViewer1.ServerReport.GetParameters()

        ReportViewer1.RefreshReport()
    End Sub

    Public Sub ImprimirHistoriaClinica_imprimirCuidadosEpicrisis(ByVal objConexion As Conexion, ByVal id_programa As String,
                                                               ByVal strcod_pre_sgs As String, ByVal strCod_sucur As String,
                                                               ByVal strTipAdm As String, ByVal ano_adm As String,
                                                               ByVal num_adm As String, ByVal tip_doc As String, ByVal num_doc As String,
                                                               ByVal cod_historia As String)

        Dim NombreReporte As String = "rptHCResumenEpicrisis"
        Dim tipadmegreso As String
        Dim causa As String = ""


        IDPrograma = id_programa
        objconex = objConexion
        _resumenHistoriaClinica = New FormatoHistoriaClinica()

        _resumenHistoriaClinica.consultarResumenHistoriaClinica(objConexion, strcod_pre_sgs, strCod_sucur, strTipAdm, ano_adm, num_adm)

        CodHistoria = cod_historia
        prestador = strcod_pre_sgs
        Sucursal = strCod_sucur
        TipoAdmision = strTipAdm
        AnoAdmision = ano_adm
        NumeroAdmision = num_adm
        NombreMedico = objG.Login

        RptHC_Enf_Med_FormOpen1()

        LoadReportConfig(NombreReporte)

        'If _resumenHistoriaClinica.Encabezado.TipoAdmEgreso = "" Then
        '    tipadmegreso = " "
        'Else
        '    tipadmegreso = _resumenHistoriaClinica.Encabezado.TipoAdmEgreso
        'End If

        If _resumenHistoriaClinica.Encabezado.CausaExterna = "" Then
            causa = " "
        Else
            causa = _resumenHistoriaClinica.Encabezado.CausaExterna
        End If

        parametros.Add(New ReportParameter("strtipdoc", tip_doc))
        parametros.Add(New ReportParameter("strnumdoc", num_doc))
        parametros.Add(New ReportParameter("fec_ini", Format(Date.Now, "yyyy-MM-dd")))
        parametros.Add(New ReportParameter("fec_fin", Format(Date.Now, "yyyy-MM-dd")))
        parametros.Add(New ReportParameter("tip_admision", TipoAdmision))
        parametros.Add(New ReportParameter("ano_adm", AnoAdmision))
        parametros.Add(New ReportParameter("num_adm", NumeroAdmision))
        parametros.Add(New ReportParameter("GeneradoPor", NombreMedico))
        'parametros.Add(New ReportParameter("intCodhistoria", objP.CodHistoria))
        parametros.Add(New ReportParameter("cod_sucur", Sucursal))
        parametros.Add(New ReportParameter("cod_pre_sgs", prestador))
        parametros.Add(New ReportParameter("Antecedentes_HST", True))
        'parametros.Add(New ReportParameter("NROORDEN", prestador))
        'parametros.Add(New ReportParameter("tip_admision_egreso", tipadmegreso))
        parametros.Add(New ReportParameter("CausaExterna", causa))
        parametros.Add(New ReportParameter("Titulo", "EPICRISIS"))

        ReportViewer1.ServerReport.SetParameters(parametros)
        pInfo = ReportViewer1.ServerReport.GetParameters()

        ReportViewer1.RefreshReport()
    End Sub

    Public Sub ImprimirHistoriaClinica_imprimirQuirurjico(ByVal objConexion As Conexion, ByVal id_programa As String,
                                                          ByVal strcod_pre_sgs As String, ByVal strcod_sucur As String,
                                                          ByVal procedimiento As String, ByVal Consecutivo As String,
                                                          ByVal Secuencia As String, ByVal strTipAdm As String,
                                                          ByVal ano_adm As String, ByVal num_adm As String,
                                                          ByVal tip_doc As String, ByVal num_doc As String,
                                                          ByVal cod_historia As String)

        Dim NombreReporte As String = "rptHCMeddescripcionQuirurgica"
        IDPrograma = id_programa
        objconex = objConexion

        CodHistoria = cod_historia
        prestador = strcod_pre_sgs
        Sucursal = strcod_sucur
        TipoAdmision = strTipAdm
        AnoAdmision = ano_adm
        NumeroAdmision = num_adm
        NombreMedico = objG.Login

        RptHC_Enf_Med_FormOpen1()

        LoadReportConfig(NombreReporte)

        parametros.Add(New ReportParameter("strtipdoc", tip_doc))
        parametros.Add(New ReportParameter("strnumdoc", num_doc))
        'parametros.Add(New ReportParameter("fec_ini", Format(Date.Now, "yyyy-MM-dd")))
        'parametros.Add(New ReportParameter("fec_fin", Format(Date.Now, "yyyy-MM-dd")))
        parametros.Add(New ReportParameter("tip_admision", strTipAdm))
        parametros.Add(New ReportParameter("ano_adm", ano_adm))
        parametros.Add(New ReportParameter("num_adm", num_adm))
        'parametros.Add(New ReportParameter("GeneradoPor", NombreMedico))
        'parametros.Add(New ReportParameter("VisibleRep", "|srptMedDescripcionQX|"))
        parametros.Add(New ReportParameter("cod_sucur", Sucursal))
        parametros.Add(New ReportParameter("cod_pre_sgs", prestador))
        parametros.Add(New ReportParameter("consecutivo", Consecutivo))
        parametros.Add(New ReportParameter("secuencia", Secuencia))
        parametros.Add(New ReportParameter("procedim", procedimiento))


        ReportViewer1.ServerReport.SetParameters(parametros)
        pInfo = ReportViewer1.ServerReport.GetParameters()

        ReportViewer1.RefreshReport()
    End Sub

    Public Sub ImprimirHistoriaClinica_Recomendacion(ByVal objConexion As Conexion, ByVal id_programa As String,
                                                  ByVal cod_pre_sgs As String, ByVal cod_sucur As String,
                                                  ByVal tip_doc As String, ByVal num_doc As String,
                                                  ByVal tip_admision As String, ByVal ano_adm As String,
                                                  ByVal num_adm As String, ByVal cod_historia As String)
        Try
            Dim NombreReporte As String = "rptHCMedRecomendacionEgreso"
            IDPrograma = id_programa
            objconex = objConexion

            CodHistoria = cod_historia
            prestador = cod_pre_sgs
            Sucursal = cod_sucur
            TipoAdmision = tip_admision
            AnoAdmision = ano_adm
            NumeroAdmision = num_adm
            NombreMedico = objG.Login

            RptHC_Enf_Med_FormOpen1()

            LoadReportConfig(NombreReporte)

            parametros.Add(New ReportParameter("strtipdoc", tip_doc))
            parametros.Add(New ReportParameter("strnumdoc", num_doc))
            parametros.Add(New ReportParameter("fec_ini", Format(Date.Now, "yyyy-MM-dd")))
            parametros.Add(New ReportParameter("fec_fin", Format(Date.Now, "yyyy-MM-dd")))
            parametros.Add(New ReportParameter("tip_admision", TipoAdmision))
            parametros.Add(New ReportParameter("ano_adm", AnoAdmision))
            parametros.Add(New ReportParameter("num_adm", NumeroAdmision))
            parametros.Add(New ReportParameter("GeneradoPor", NombreMedico))
            parametros.Add(New ReportParameter("VisibleRep", "|srptHCMedRecomendacionEgreso|"))
            parametros.Add(New ReportParameter("cod_sucur", Sucursal))
            parametros.Add(New ReportParameter("cod_pre_sgs", prestador))

            ReportViewer1.ServerReport.SetParameters(parametros)
            pInfo = ReportViewer1.ServerReport.GetParameters()

            ReportViewer1.RefreshReport()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region

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

    Public Sub RptHC_Enf_Med_FormOpen()
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

    Public Sub RptHC_Enf_Med_FormOpen1()
        Try
            If TipoAdmision Is Nothing Then
                TipoAdmision = 0
            End If
            objBl.GrabarAuditoria(objconex, CodHistoria, prestador, Sucursal, TipoAdmision, AnoAdmision, NumeroAdmision, NombreMedico, "A", "", IDPrograma)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub RptHC_Enf_Med_FormEstado(ByVal objConexion As Conexion, ByVal id_programa As String, ByVal estado As String, ByVal obs As String)
        Try
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


    Private Sub RptHC_Enf_Med_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            If TipoAdmision Is Nothing Then
                TipoAdmision = 0
            End If
            If objP.TipoAdmision Is Nothing Then
                objBl.GrabarAuditoria(objconex, objP.CodHistoria, objG.Prestador, objG.Sucursal, TipoAdmision, AnoAdmision, NumeroAdmision, objG.Login, "C", "", IDPrograma)
            Else
                objBl.GrabarAuditoria(objconex, objP.CodHistoria, objG.Prestador, objG.Sucursal, objP.TipoAdmision, objP.AnoAdmision, objP.NumeroAdmision, objG.Login, "C", "", IDPrograma)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ReportViewer1_Back(sender As Object, e As BackEventArgs) Handles ReportViewer1.Back
        ImprimirHistoriaClinica_Med_Consulta(objConexion1, VisibleRep1, id_programa1, strtipdoc1, strnumdoc1, fec_ini1, fec_fin1, hora_ini1, hora_fin1,
                                             tip_admision1, ano_adm1, num_adm1, cod_sucur1, cod_pre_sgs1, ANTECEDENTES_HST1, dCon_procedim1, Compania1, ContraReferenciaP1, EsReimpresion1,
                                             dNro_Formula1, MedicoPE1, cod_historia1)
    End Sub

    Private Sub ReportViewer1_Drillthrough(sender As Object, e As DrillthroughEventArgs) Handles ReportViewer1.Drillthrough
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.Percent
        ReportViewer1.ZoomPercent = 150
        ReportViewer1.ShowFindControls = True
        ReportViewer1.RefreshReport()
    End Sub

#End Region
End Class