Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion

Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes
Imports System.Collections.Generic
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes

Imports Microsoft.Reporting.WinForms


Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports HistoriaClinica.Sophia.HistoriaClinica.BL

Public Class frmRepHistoriaClinicaEnfermeria

    'Planeacion







    Dim objalarmas As DataTable
    Dim objPlaneacionParametros As List(Of Planeacion)
    Dim objPlaneaciongenerales As List(Of PlaneacionGeneral)
    Dim objPlaneacioncuidados As List(Of PlaneacionCuidado)




    Dim objNotasParametros As New DataTable  'Informacion del recien nacido
    Dim objNotasEvolucion As New DataTable
    Dim objControlCateterVascular As List(Of ControlCateterVascular) 'Informacion del control de cateter vscular
    Dim ReporteHerida As DataTable
    Dim RecienNacido As DataTable

    'Dim objNotasParametr As New DataTable
    'Dim objRecienNacido As New List(Of RecienNacido)  'Informacion del recien nacido

    'Escalas
    Dim objEscalaRiesgo As New List(Of EscalaRiesgoL)


    Dim objEscalaRass As New DataTable
    Dim objEscalaCam As New DataTable


    Dim objEscalaRiesgoTem As List(Of EscalaRiesgoL)
    Dim objEscalaRiesgoPed As List(Of EscalaRiesgoCaidaPed)
    Dim objEscalaSarnat As List(Of EscalaSarnat)
    Dim objEscalaTiss28 As List(Of EscalaTiss28)
    Dim objValorDolorN As List(Of EscalaValorDolorNeonatos)
    Dim objEscalaLesionpiel As List(Of EscalaLesionDePiel)
    Dim objEscalaLPUlceras As List(Of EscalaLesionDePielUlceras)


    Dim objIdentRiesgo As New List(Of IdentificadoresRiesgoConsolidado)


    'Monitoreo
    Dim objHojaSignos As New DataTable
    Dim objHojaNeurologica As New DataTable
    Dim objNotasSeccionSD As New DataTable

    Dim objMonitoreoHojaToxemica As New DataTable
    Dim ReporteMonitoreo As DataTable
    Dim objHemodialisis As New DataTable
    Dim ReportePlasmaferisis As DataTable
    Dim objNotasSeccionNeo As New DataTable
    Dim objLiquidosAdmin As List(Of Liquidos)

    Dim objLiquidosAdmin1 As List(Of Liquidos1)
    Dim objBalances1 As List(Of Balances1)
    Dim objBalances As List(Of Balances)






    Dim m_peso As Double = 0
    Dim m_edad As Double = 0


    Dim m_DifDias As Integer = 0
    Dim m_fechaInicio As String = String.Empty
    Dim m_fechaFin As String = String.Empty
    Dim objHcEnfEncabezado As New HCEnfEncabezado()   'Informacion del encabezado del reporte

    Dim tnLocal As TreeNode
    Dim _IDEscalas As String = Nothing





    Public Sub ImprimirHistoriaClinica(ByVal objConexion As Conexion, ByVal dCod_Historia As Long, ByVal strFechaIni_RecNac As Nullable(Of DateTime),
                                       ByVal strFechaFin_RecNac As Nullable(Of DateTime), ByVal iHoraIni_RecNac As Nullable(Of Integer),
                                       ByVal iHoraFin_RecNac As Nullable(Of Integer), ByVal tn As TreeNode, ByVal strPrestador As String,
                                       ByVal strSucursal As String, ByVal strTipoAdmision As String, ByVal anoadmision As Integer,
                                       ByVal admision As Integer, ByVal tip_doc As String, ByVal num_doc As String)
        Try
            _IDEscalas = Nothing 'limpio la variable que verifica que escalas se van a imprimir rcruzr 20180503


            tnLocal = tn


            'Se llena el encabezado de la Historia Clinica. Contiene informacion 
            'de la admision, del paciente y la historia clinica
            objHcEnfEncabezado.consultarHcEnfEncabezado(objConexion, dCod_Historia)


            'Se llena el objeto que almacena infomacion del recien nacido
            LlenarObjetos(objConexion, dCod_Historia, strFechaIni_RecNac, strFechaFin_RecNac, iHoraIni_RecNac, iHoraFin_RecNac, tn,
                          strPrestador, strSucursal, strTipoAdmision, anoadmision, admision, tip_doc, num_doc)



            Me.HCEnfEncabezadoBindingSource.DataSource = objHcEnfEncabezado

            'Se asigna el objeto con la info del paciente al datasource
            'que se asocio al reporte
            Me.PacienteBindingSource.DataSource = objHcEnfEncabezado.Paciente

        Catch ex As Exception
            MsgBox("Error en la impresion. " & ex.Message, MsgBoxStyle.Critical)
        End Try

        ''Se define que el metodo SubreportProcessingEventHandler maneja el evento ReportViewer1.LocalReport.SubreportProcessing 
        ''del Reporte. Este evento ocurre cuando se procesan los subreportes contenidos en el reporte principal
        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEventHandler

        setParametrosReporte()

        'Se pinta el reporte
        Me.ReportViewer1.RefreshReport()




















    End Sub

    Private Sub LlenarObjetos(ByVal objConexion As Conexion, ByVal dCod_Historia As Integer, ByVal strFechaIni_RecNac As Nullable(Of DateTime),
                              ByVal strFechaFin_RecNac As Nullable(Of DateTime), ByVal iHoraIni_RecNac As Nullable(Of Integer),
                              ByVal iHoraFin_RecNac As Nullable(Of Integer), ByVal tn As TreeNode, ByVal strPrestador As String,
                              ByVal strSucursal As String, ByVal strTipoAdmision As String, ByVal anoadmision As Integer,
                              ByVal admision As Integer, ByVal tip_doc As String, ByVal num_doc As String)
        Dim node As TreeNode
        Dim DAOGeneral As New DAOGeneral
        Dim dtParametro As DataTable

        For Each node In tn.Nodes
            If node.Checked = True Then
                Select Case node.Name
                    Case "n11Alarmas"
                        objalarmas = New Alarma().consultarHistoricoAlarmas(objConexion, dCod_Historia, strFechaIni_RecNac, strFechaFin_RecNac, iHoraIni_RecNac, iHoraFin_RecNac)
                    Case "n12Cuidados"
                        objPlaneacionParametros = New Planeacion().consultarPlaneacionDT(objConexion, dCod_Historia, strFechaIni_RecNac, strFechaFin_RecNac, iHoraIni_RecNac, iHoraFin_RecNac)
                    Case "n13generales"
                        objPlaneaciongenerales = New PlaneacionGeneral().consultarPlaneacionDT(objConexion, dCod_Historia, strFechaIni_RecNac, strFechaFin_RecNac, iHoraIni_RecNac, iHoraFin_RecNac)
                    Case "n14cuidados"
                        objPlaneacioncuidados = New PlaneacionCuidado().consultarPlaneacionDT(objConexion, dCod_Historia, strFechaIni_RecNac, strFechaFin_RecNac, iHoraIni_RecNac, iHoraFin_RecNac)
                    Case "n21NotasParametricas"
                        objNotasParametros = New NotasParametros().consultarNotasParametricasDT(objConexion, dCod_Historia, strFechaIni_RecNac, strFechaFin_RecNac, iHoraIni_RecNac, iHoraFin_RecNac)
                    Case "n22Evolucion"
                        objNotasEvolucion = New NotasEvolucion().consultarNotasEvolucionDT(objConexion, dCod_Historia, strFechaIni_RecNac, strFechaFin_RecNac, iHoraIni_RecNac, iHoraFin_RecNac)
                    Case "n23ControlCateterInsercion"
                        objControlCateterVascular = New ControlCateterVascular().consultarControlCateterVascular_1(objConexion, dCod_Historia, strFechaIni_RecNac, strFechaFin_RecNac, iHoraIni_RecNac, iHoraFin_RecNac)
                    Case "n24Historia"
                        ReporteHerida = Sophia.HistoriaClinica.BL.BLNotasEnfermeria.ReporteHeridas(objConexion, dCod_Historia, strFechaIni_RecNac, strFechaFin_RecNac, iHoraIni_RecNac, iHoraFin_RecNac)
                    Case "n25RecienNacido"
                        RecienNacido = New Sophia.HistoriaClinica.BL.BLNotasEnfermeria().consultarhcEnfEvaPost(objConexion, dCod_Historia, strFechaIni_RecNac, strFechaFin_RecNac, iHoraIni_RecNac, iHoraFin_RecNac)
                    Case "n31RiesgoCaida"
                        _IDEscalas = _IDEscalas + "6|"
                        'llarias Se cambia consulta escala riesgo 2015-11-26
                        'objEscalaRiesgo = New EscalaRiesgo().consultarEscalaRiesgo(objConexion, dCod_Historia, strFechaIni_RecNac, strFechaFin_RecNac, iHoraIni_RecNac, iHoraFin_RecNac)
                        objEscalaRiesgo = New EscalaRiesgoL().consultarEscalaRiesgo(objConexion, dCod_Historia, strFechaIni_RecNac, strFechaFin_RecNac, iHoraIni_RecNac, iHoraFin_RecNac, 6)
                    Case "n32RASS"
                        _IDEscalas = _IDEscalas + "7|"
                        objEscalaRass = New EscalaRass().consultarEscalaRass(objConexion, dCod_Historia, strFechaIni_RecNac, strFechaFin_RecNac, iHoraIni_RecNac, iHoraFin_RecNac)

                    Case "n33CamIW"
                        _IDEscalas = _IDEscalas + "8|"
                        objEscalaCam = New EscalaCam().consultarEscalaCam(objConexion, dCod_Historia, strFechaIni_RecNac, strFechaFin_RecNac, iHoraIni_RecNac, iHoraFin_RecNac)
                    Case "n34RiesgoCaidaPediatria"
                        _IDEscalas = _IDEscalas + "1|"
                        objEscalaRiesgoPed = New EscalaRiesgoCaidaPed().consultarEscalaRiesgo(objConexion, dCod_Historia, strFechaIni_RecNac, strFechaFin_RecNac, iHoraIni_RecNac, iHoraFin_RecNac, 1)

                    Case "N35Sarnat"
                        _IDEscalas = _IDEscalas + "2|"
                        objEscalaSarnat = New EscalaSarnat().consultarEscalaRiesgo(objConexion, dCod_Historia, strFechaIni_RecNac, strFechaFin_RecNac, iHoraIni_RecNac, iHoraFin_RecNac, 2)

                    Case "n36Tiss"
                        _IDEscalas = _IDEscalas + "4|"
                        objEscalaTiss28 = New EscalaTiss28().consultarEscalaRiesgo(objConexion, dCod_Historia, strFechaIni_RecNac, strFechaFin_RecNac, iHoraIni_RecNac, iHoraFin_RecNac, 4)

                    Case "n38LesionPiel"
                        _IDEscalas = _IDEscalas + "3|"
                        objEscalaLesionpiel = New EscalaLesionDePiel().consultarEscalaRiesgo(objConexion, dCod_Historia, strFechaIni_RecNac, strFechaFin_RecNac, iHoraIni_RecNac, iHoraFin_RecNac, 3)
                        objEscalaLPUlceras = New EscalaLesionDePielUlceras().consultarLesionPielUlceras(objConexion, strPrestador, strSucursal, strTipoAdmision, anoadmision, admision, dCod_Historia)

                    Case "n37ValorDolNeonatos"
                        _IDEscalas = _IDEscalas + "5|"
                        objValorDolorN = New EscalaValorDolorNeonatos().consultarEscalaRiesgo(objConexion, dCod_Historia, strFechaIni_RecNac, strFechaFin_RecNac, iHoraIni_RecNac, iHoraFin_RecNac, 5)
                    Case "n41SignosVitales" 'n41SignosVitales
                        objHojaSignos = New EnfSignos_Vitales().consultarSignosVitales(objConexion, dCod_Historia, strFechaIni_RecNac, strFechaFin_RecNac, iHoraIni_RecNac, iHoraFin_RecNac)
                    Case "n42HojaNeurologica"
                        objHojaNeurologica = New HojaNeurologica().consultarTraerHojaNeurologica(objConexion, dCod_Historia, strFechaIni_RecNac, strFechaFin_RecNac, iHoraIni_RecNac, iHoraFin_RecNac)
                    Case "n43SeguimientoDolor"
                        objNotasSeccionSD = New SubseccionSD().consultarMonitoreoSubseccionSD(objConexion, dCod_Historia, strFechaIni_RecNac, strFechaFin_RecNac, iHoraIni_RecNac, iHoraFin_RecNac)
                    Case "n44HojaToxemica"
                        objMonitoreoHojaToxemica = New MonitoreoHojaToxemica().consultarMonitoreoHojaToxemica(objConexion, dCod_Historia, strFechaIni_RecNac, strFechaFin_RecNac, iHoraIni_RecNac, iHoraFin_RecNac)
                    Case "n45Hemodinamico"
                        ReporteMonitoreo = Sophia.HistoriaClinica.BL.BLMonitoreoHemo.ReporteMonitoreoHemo(objConexion, dCod_Historia, strFechaIni_RecNac, strFechaFin_RecNac, iHoraIni_RecNac, iHoraFin_RecNac)
                    Case "n46Hemodialisis"
                        objHemodialisis = New Hemodialisis().consultarHemodialisis(objConexion, dCod_Historia, strFechaIni_RecNac, strFechaFin_RecNac, iHoraIni_RecNac, iHoraFin_RecNac)
                    Case "n47Plasmaferesis"
                        ReportePlasmaferisis = Sophia.HistoriaClinica.BL.BLPlasmaferesis.ReportePlasmeresis(objConexion, dCod_Historia, strFechaIni_RecNac, strFechaFin_RecNac, iHoraIni_RecNac, iHoraFin_RecNac)
                    Case "n48SubNeoNatal"
                        objNotasSeccionNeo = New SubseccionNeo().consultarSubseccionNeoDT(objConexion, dCod_Historia, strFechaIni_RecNac, strFechaFin_RecNac, iHoraIni_RecNac, iHoraFin_RecNac)
                    Case "n49Liquidos"
                        'Martovar se deja parametrizable para que maneje la version anterior de liquidos 2018/03/02
                        dtParametro = DAOGeneral.ConsultarDiasHistorico("Liquidos")
                        If dtParametro.Rows.Count > 0 Then
                            If dtParametro.Rows(0).Item("valor").ToString = "1" Then
                                If strFechaFin_RecNac.HasValue = False Then
                                    m_fechaFin = BLPlaneacion.obtenerFecha(Date.Now.Date)
                                Else
                                    m_fechaFin = BLPlaneacion.obtenerFecha(CDate(strFechaFin_RecNac))
                                End If

                                If strFechaIni_RecNac.HasValue = False Then
                                    m_fechaInicio = BLPlaneacion.obtenerFecha(Date.Now.Date)
                                Else
                                    m_fechaInicio = BLPlaneacion.obtenerFecha(CDate(strFechaIni_RecNac))
                                End If
                                m_DifDias = BLPlaneacion.obtenerDiferenciaDia(m_fechaInicio, m_fechaFin)
                                objLiquidosAdmin = New Liquidos().consultarLiquidosAdmin(objConexion, dCod_Historia, m_fechaInicio, "LA", m_DifDias)
                                objBalances = New Balances().consultarRepBalances(dCod_Historia, m_fechaInicio, m_DifDias)

                            Else
                                objLiquidosAdmin1 = New Liquidos1().consultarLiquidosAdmin(objConexion, dCod_Historia, strFechaIni_RecNac, strFechaFin_RecNac, iHoraIni_RecNac, iHoraFin_RecNac)
                                objBalances1 = New Balances1().consultarRepBalances(objConexion, dCod_Historia, strFechaIni_RecNac, strFechaFin_RecNac, iHoraIni_RecNac, iHoraFin_RecNac)
                            End If
                        End If
                        'Case "n5IdentRiesgo" 'REQ 651 no fue autorizado sacarlo 20181216 raucruz
                        '    objIdentRiesgo = New IdentificadoresRiesgoConsolidado().consultarIdentificadoresRiesgoCon(objConexion, dCod_Historia, strFechaIni_RecNac, strFechaFin_RecNac, iHoraIni_RecNac, iHoraFin_RecNac,
                        '                                                                                              strPrestador, strSucursal, strTipoAdmision, anoadmision, admision, tip_doc, num_doc)
                End Select
            End If

            If node.Nodes.Count > 0 Then
                Me.LlenarObjetos(objConexion, dCod_Historia, strFechaIni_RecNac, strFechaFin_RecNac, iHoraIni_RecNac, iHoraFin_RecNac, node, strPrestador,
                                 strSucursal, strTipoAdmision, anoadmision, admision, tip_doc, num_doc)
            End If
        Next node
    End Sub































    Private Sub ReportViewer1_RenderingComplete(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.RenderingCompleteEventArgs) Handles ReportViewer1.RenderingComplete
        ''Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)

        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
    End Sub

    Public Sub SubreportProcessingEventHandler(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)
        Me.cargarSubreportes(sender, e, tnLocal, e.ReportPath)
    End Sub

    Private Sub cargarSubreportes(ByRef sender As Object, ByRef e As SubreportProcessingEventArgs, ByVal nodeCargue As TreeNode, ByVal ReportName As String)
        Dim DAOGeneral As New DAOGeneral
        Dim dtParametro As DataTable
        For Each node As TreeNode In nodeCargue.Nodes
            If node.Checked = True Then
                Select Case node.Name
                    Case "n11Alarmas"
                        If ReportName = "RepAlarma" Then
                            e.DataSources.Add(New ReportDataSource("Enfermeria_Sophia_HistoriaClinica_Reportes_Alarma", objalarmas))
                        End If
                    Case "n12Cuidados"
                        If ReportName = "RepEnfPlaneacionDet" Then
                            e.DataSources.Add(New ReportDataSource("Enfermeria_Sophia_HistoriaClinica_Reportes_Planeacion", objPlaneacionParametros))

                        End If
                    Case "n13generales"
                        If ReportName = "RepEnfPlaneacionGeneral" Then
                            e.DataSources.Add(New ReportDataSource("Enfermeria_Sophia_HistoriaClinica_Reportes_PlaneacionGeneral", objPlaneaciongenerales))
                        End If
                    Case "n14cuidados"
                        If ReportName = "RepEnfPlaneacionCuidado" Then
                            e.DataSources.Add(New ReportDataSource("Enfermeria_Sophia_HistoriaClinica_Reportes_PlaneacionCuidado", objPlaneacioncuidados))
                        End If
                    Case "n21NotasParametricas"
                        If ReportName = "RepNotasParametricas" Then
                            e.DataSources.Add(New ReportDataSource("dsNotasParametricas_HCENF_TraerNotasParametricas", objNotasParametros))
                        End If
                    Case "n22Evolucion"
                        If ReportName = "RepNotasEvolucion" Then
                            e.DataSources.Add(New ReportDataSource("dsNotasEvolucion_HCEnf_TraerNotasEvolucion", objNotasEvolucion))
                        End If
                    Case "n23ControlCateterInsercion"
                        If ReportName = "RepControlCateterVascular1" Then
                            e.DataSources.Add(New ReportDataSource("Enfermeria_Sophia_HistoriaClinica_Reportes_ControlCateterVascular", objControlCateterVascular))
                        End If
                    Case "n24Historia"
                        If ReportName = "RepHerida" Then
                            e.DataSources.Add(New ReportDataSource("ConsultaHeridas_ConsultaHerida", ReporteHerida))
                        End If
                    Case "n25RecienNacido"
                        If ReportName = "RepRecienNacido" Then
                            e.DataSources.Add(New ReportDataSource("sophiaDataSet_ConsultaRecienNacido", RecienNacido))
                        End If
                    Case "n31RiesgoCaida"
                        If ReportName = "RepEscalaRiesgo" Then
                            'llarias se cambia el reporte a consultar  2015-11-26
                            'e.DataSources.Add(New ReportDataSource("Enfermeria_Sophia_HistoriaClinica_Reportes_EscalaRiesgo", objEscalaRiesgo))
                            e.DataSources.Add(New ReportDataSource("Enfermeria_Sophia_HistoriaClinica_Reportes_EscalaRiesgoL", objEscalaRiesgo))
                        End If
                    Case "n34RiesgoCaidaPediatria"
                        If ReportName = "RepEscalaRiesgoCaidaPed" Then
                            e.DataSources.Add(New ReportDataSource("Enfermeria_Sophia_HistoriaClinica_Reportes_EscalaRiesgoCaidaPed", objEscalaRiesgoPed))
                        End If

                    Case "N35Sarnat"
                        If ReportName = "RepEscalaSarnat" Then
                            e.DataSources.Add(New ReportDataSource("Enfermeria_Sophia_HistoriaClinica_Reportes_EscalaSarnat", objEscalaSarnat))
                        End If
                    Case "n32RASS"
                        If ReportName = "RepEscalaRass" Then
                            e.DataSources.Add(New ReportDataSource("Enfermeria_Sophia_HistoriaClinica_Reportes_EscalaRass", objEscalaRass))
                        End If
                    Case "n36Tiss"
                        If ReportName = "RepEscalaTiss28" Then
                            e.DataSources.Add(New ReportDataSource("Enfermeria_Sophia_HistoriaClinica_Reportes_EscalaTiss28", objEscalaTiss28))
                        End If
                    Case "n38LesionPiel"

                        If ReportName = "RepEscalaLesionPiel2" Then
                            e.DataSources.Add(New ReportDataSource("Enfermeria_Sophia_HistoriaClinica_Reportes_EscalaLesionDePiel", objEscalaLesionpiel))
                        End If

                        If ReportName = "RepEnfEscalaUlcerasLP2" Then
                            e.DataSources.Add(New ReportDataSource("Enfermeria_Sophia_HistoriaClinica_Reportes_EscalaLesionDePielUlceras", objEscalaLPUlceras))
                        End If
                    Case "n37ValorDolNeonatos"
                        If ReportName = "RepEscalaValorDolorNeonatos" Then
                            e.DataSources.Add(New ReportDataSource("Enfermeria_Sophia_HistoriaClinica_Reportes_EscalaValorDolorNeonatos", objValorDolorN))
                        End If

                    Case "n33CamIW"
                        If ReportName = "RepEscalaCam" Then
                            e.DataSources.Add(New ReportDataSource("Enfermeria_Sophia_HistoriaClinica_Reportes_EscalaCam", objEscalaCam))
                        End If

                    Case "n41SignosVitales"
                        If ReportName = "RepEnfSignosVitales" Then
                            e.DataSources.Add(New ReportDataSource("dsEnfSignosVitales_HCENF_ReporteSignosVitales", objHojaSignos))
                        End If
                    Case "n42HojaNeurologica"
                        If ReportName = "RepHojaNeurologica" Then
                            e.DataSources.Add(New ReportDataSource("dsHojaNeurologica_HCENF_TraerHojaNeurologica", objHojaNeurologica))

                        End If
                    Case "n43SeguimientoDolor"
                        If ReportName = "RepSubseccionSD" Then
                            e.DataSources.Add(New ReportDataSource("dsTraerMonitoreoSubseccionSD_HCENF_TraerMonitoreoSubseccionSD", objNotasSeccionSD))

                        End If
                    Case "n44HojaToxemica"
                        If ReportName = "RepMonitoreoHToxemica" Then
                            e.DataSources.Add(New ReportDataSource("dsHojaToxemica_HENF_ReporteHojaToxemica", objMonitoreoHojaToxemica))
                        End If
                    Case "n45Hemodinamico"
                        If ReportName = "RepMonitoreoHemoLuis" Then
                            e.DataSources.Add(New ReportDataSource("dsMonitoreoHemo_HCENF_ReporteMonitoreoHemo", ReporteMonitoreo))
                        End If
                    Case "n46Hemodialisis"
                        If ReportName = "RepHemodialisis" Then
                            e.DataSources.Add(New ReportDataSource("dsHemodialisis_HCENF_ReporteHemodialisis", objHemodialisis))
                        End If
                    Case "n47Plasmaferesis"
                        If ReportName = "RepPlasmaferesis" Then
                            e.DataSources.Add(New ReportDataSource("oDsPLasmaferis_VistaPlasmaferis", ReportePlasmaferisis))
                        End If
                    Case "n48SubNeoNatal"
                        If ReportName = "RepSubseccionNeo" Then
                            e.DataSources.Add(New ReportDataSource("dsSubseccionNeo_HCENF_TraerSubseccionNeo", objNotasSeccionNeo))
                        End If
                    Case "n49Liquidos"

                        'Martovar se deja parametrizable para que maneje la version anterior de liquidos 2018/03/02
                        dtParametro = DAOGeneral.ConsultarDiasHistorico("Liquidos")
                        If dtParametro.Rows.Count > 0 Then
                            If dtParametro.Rows(0).Item("valor").ToString = "1" Then
                                If ReportName = "RepEnfLiquidosAdminDet1" Then
                                    e.DataSources.Add(New ReportDataSource("Enfermeria_Sophia_HistoriaClinica_Reportes_Liquidos", objLiquidosAdmin))
                                End If

                                If ReportName = "RepEnfBalanceInfo" Then
                                    e.DataSources.Add(New ReportDataSource("Enfermeria_Sophia_HistoriaClinica_Reportes_Balances", objBalances))
                                End If

                            Else
                                If ReportName = "RepEnfLiquidosAdminDet" Then
                                    e.DataSources.Add(New ReportDataSource("Enfermeria_Sophia_HistoriaClinica_Reportes_Liquidos", objLiquidosAdmin))
                                End If
                                If ReportName = "RepEnfBalanceDet" Then
                                    e.DataSources.Add(New ReportDataSource("Enfermeria_Sophia_HistoriaClinica_Reportes_Balances", objBalances))
                                End If
                            End If
                        End If
                        'Case "n5IdentRiesgo" 'REQ 651 no fue autorizado sacarlo 20181216 raucruz
                        '    If ReportName = "srpIdentificadorRiesgo" Then
                        '        e.DataSources.Add(New ReportDataSource("Enfermeria_Sophia_HistoriaClinica_Reportes_Identificador_Riesgo", objIdentRiesgo))
                        '    End If

                End Select
            End If

            If node.Nodes.Count > 0 Then
                Me.cargarSubreportes(sender, e, node, ReportName)
            End If
        Next
    End Sub



    Public Sub setParametrosReporte()
        Dim aParametros(21) As ReportParameter




        With objHcEnfEncabezado
            aParametros(0) = New ReportParameter("Sucursal", .Sucursal)
            aParametros(1) = New ReportParameter("NroHistoria", .Paciente.NumeroDocumento)
            aParametros(2) = New ReportParameter("Fecha", .Fecha)
            aParametros(3) = New ReportParameter("Hora", .Hora & " : " & .Minuto)
            aParametros(4) = New ReportParameter("NroAdmision", .TipoAdmision & " " & .AnoAdmision & " " & .NumeroAdmision)
            aParametros(5) = New ReportParameter("Entidad", .Entidad)
            aParametros(6) = New ReportParameter("Paciente", .Paciente.TipoDocumento & " " & .Paciente.NumeroDocumento)
            aParametros(7) = New ReportParameter("Nombre", .Paciente.Nombre)
            aParametros(8) = New ReportParameter("Edad", .Paciente.Edad & " " & .Paciente.UnidadEdad)
            aParametros(9) = New ReportParameter("Sexo", .Paciente.DescripSexo)
            aParametros(10) = New ReportParameter("Grupo", .Paciente.GrupoSanguineo)
            aParametros(11) = New ReportParameter("RH", .Paciente.FactorRH)
            aParametros(12) = New ReportParameter("FechaImpresion", Format(FuncionesGenerales.FechaServidor(), "dd/MM/yyyy HH:mm"))
            aParametros(13) = New ReportParameter("Ciudad", .Ciudad)
            aParametros(14) = New ReportParameter("Pais", .Pais)
            aParametros(15) = New ReportParameter("dirSucursal", .DirSucursal)
            aParametros(16) = New ReportParameter("telSucursal", .telSucursal)
            ' aParametros(17) = New ReportParameter("Secuencia", .secuencia)
            aParametros(18) = New ReportParameter("Prestador", .Prestador)
            aParametros(19) = New ReportParameter("religion", .Paciente.Religion)
            aParametros(20) = New ReportParameter("Ubicacion", .Paciente.Ubicacion)
            aParametros(21) = New ReportParameter("EdadAMD", .Paciente.EdadAMD)

        End With

        ' Dim snReporte As String = tnLocal.Nodes("n1Planeacion").Nodes("n11Alarmas").Checked.ToString() + "|"
        Dim snReporte As String = tnLocal.Nodes("n1Planeacion").Nodes("n12Cuidados").Checked.ToString() + "|"
        snReporte += tnLocal.Nodes("n2NotasdeEnfermeria").Nodes("n21NotasParametricas").Checked.ToString() + "|"
        snReporte += tnLocal.Nodes("n2NotasdeEnfermeria").Nodes("n22Evolucion").Checked.ToString() + "|"
        snReporte += tnLocal.Nodes("n2NotasdeEnfermeria").Nodes("n23ControlCateterInsercion").Checked.ToString() + "|"
        snReporte += tnLocal.Nodes("n2NotasdeEnfermeria").Nodes("n24Historia").Checked.ToString() + "|"
        snReporte += tnLocal.Nodes("n2NotasdeEnfermeria").Nodes("n25RecienNacido").Checked.ToString() + "|"
        snReporte += tnLocal.Nodes("n3Escalas").Nodes("n31RiesgoCaida").Checked.ToString() + "|"
        snReporte += tnLocal.Nodes("n3Escalas").Nodes("n32RASS").Checked.ToString() + "|"
        snReporte += tnLocal.Nodes("n3Escalas").Nodes("n33CamIW").Checked.ToString() + "|"
        snReporte += tnLocal.Nodes("n4Monitoreo").Nodes("n41SignosVitales").Checked.ToString() + "|"
        snReporte += tnLocal.Nodes("n4Monitoreo").Nodes("n42HojaNeurologica").Checked.ToString() + "|"
        snReporte += tnLocal.Nodes("n4Monitoreo").Nodes("n43SeguimientoDolor").Checked.ToString() + "|"
        snReporte += tnLocal.Nodes("n4Monitoreo").Nodes("n44HojaToxemica").Checked.ToString() + "|"
        snReporte += tnLocal.Nodes("n4Monitoreo").Nodes("n45Hemodinamico").Checked.ToString() + "|"
        snReporte += tnLocal.Nodes("n4Monitoreo").Nodes("n46Hemodialisis").Checked.ToString() + "|"
        snReporte += tnLocal.Nodes("n4Monitoreo").Nodes("n47Plasmaferesis").Checked.ToString() + "|"
        snReporte += tnLocal.Nodes("n4Monitoreo").Nodes("n48SubNeoNatal").Checked.ToString() + "|"
        snReporte += tnLocal.Nodes("n4Monitoreo").Nodes("n49Liquidos").Checked.ToString() + "|"
        snReporte += tnLocal.Nodes("n1Planeacion").Nodes("n14cuidados").Checked.ToString() + "|"
        snReporte += tnLocal.Nodes("n1Planeacion").Nodes("n13generales").Checked.ToString() + "|"
        snReporte += tnLocal.Nodes("n3Escalas").Nodes("n34RiesgoCaidaPediatria").Checked.ToString() + "|"
        snReporte += tnLocal.Nodes("n3Escalas").Nodes("N35Sarnat").Checked.ToString() + "|"
        snReporte += tnLocal.Nodes("n3Escalas").Nodes("n36Tiss").Checked.ToString() + "|"
        snReporte += tnLocal.Nodes("n3Escalas").Nodes("n37ValorDolNeonatos").Checked.ToString() + "|"
        snReporte += tnLocal.Nodes("n3Escalas").Nodes("n38LesionPiel").Checked.ToString() + "|"


        aParametros(17) = New ReportParameter("snVerRep", snReporte)

        ReportViewer1.LocalReport.SetParameters(aParametros)

        ''' snReporte += tnLocal.Nodes("n1Planeacion").Nodes("n5IdentRiesgo").Checked.ToString() + "|" 'REQ 651 no fue autorizado sacarlo 20181216 raucruz
    End Sub
    Public Sub setParametrosReporteSD()
        Dim aParametros(19) As ReportParameter

        With objHcEnfEncabezado
            aParametros(0) = New ReportParameter("Sucursal", .Sucursal)
            aParametros(1) = New ReportParameter("NroHistoria", .Paciente.NumeroDocumento)
            aParametros(2) = New ReportParameter("Fecha", .Fecha)
            aParametros(3) = New ReportParameter("Hora", .Hora & " : " & .Minuto)
            aParametros(4) = New ReportParameter("NroAdmision", .TipoAdmision & " " & .AnoAdmision & " " & .NumeroAdmision)
            aParametros(5) = New ReportParameter("Entidad", .Entidad)
            aParametros(6) = New ReportParameter("Paciente", .Paciente.TipoDocumento & " " & .Paciente.NumeroDocumento)
            aParametros(7) = New ReportParameter("Nombre", .Paciente.Nombre)
            aParametros(8) = New ReportParameter("Edad", .Paciente.Edad & " " & .Paciente.UnidadEdad)
            aParametros(9) = New ReportParameter("Sexo", .Paciente.DescripSexo)
            aParametros(10) = New ReportParameter("Grupo", .Paciente.GrupoSanguineo)
            aParametros(11) = New ReportParameter("RH", .Paciente.FactorRH)
            aParametros(12) = New ReportParameter("FechaImpresion", Format(FuncionesGenerales.FechaServidor(), "dd/MM/yyyy HH:mm"))
            aParametros(13) = New ReportParameter("Ciudad", .Ciudad)
            aParametros(14) = New ReportParameter("Pais", .Pais)
            aParametros(15) = New ReportParameter("dirSucursal", .DirSucursal)
            aParametros(16) = New ReportParameter("telSucursal", .telSucursal)
            aParametros(17) = New ReportParameter("snVerRep", "False|False|False|False|False|False|False|False|False|False|False|False|True|False|False|False|False|False|False|False|False|")
            aParametros(18) = New ReportParameter("Secuencia", .secuencia)
        End With


        ReportViewer1.LocalReport.SetParameters(aParametros)
    End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load



    End Sub
End Class