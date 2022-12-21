Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports Microsoft.Reporting.WinForms


Public Class frmRepHistoriaClinica

    Private _historiaClinica As FormatoHistoriaClinica
    Private _objConexion As Conexion
    Private intMessages As Integer = 0
    Private strPermitirImprimirHClinica As String = "S"
    Private strTipoAdmision As String
    Private lAnoAdmision As Long
    Private dblNumeroAdmision As Double
    Private strPrestador As String
    Private strSucursal As String
    Private strMedicoRealizaCorreccion As String


#Region "Propiedades"
    Public Property HistoriaClinica() As FormatoHistoriaClinica
        Get
            Return _historiaClinica
        End Get
        Set(ByVal Value As FormatoHistoriaClinica)
            _historiaClinica = Value
        End Set
    End Property
#End Region

    ''' <summary>
    ''' Funcion que crea el objeto que encapsula la informacion de la historia clinica y lo enlaza 
    ''' a la fuente de datos del reporte
    ''' </summary>
    ''' <param name="objConexion">Datos de la conexion</param>
    ''' <param name="strcod_pre_sgs">Codigo del prestador</param>
    ''' <param name="strCod_sucur">Codigo de la sucursal</param>
    ''' <param name="strTip_admision">Tipo de admision</param>
    ''' <param name="lano_adm">año de la admision</param>
    ''' <param name="dnum_adm">Numero de la admision</param>
    ''' <param name="strTip_historia">Tipo de historia clinica</param>
    ''' <param name="strLogin">Login del medico que inicia sesion</param>
    ''' <remarks></remarks>
    Public Sub ImprimirHistoriaClinica(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String,
                   ByVal strCod_sucur As String, ByVal strTip_admision As String,
                   ByVal lano_adm As Long, ByVal dnum_adm As Double,
                   ByVal strTipDoc As String, ByVal strNumDoc As String,
                   ByVal strTip_historia As String, ByVal strLogin As String,
                   ByVal seccionesAdicionales As Secciones, Optional ByVal strPermitirImprimir As String = "S",
                   Optional ByVal strCorreccion As String = "",
                   Optional ByVal fec_ini As Date = Nothing, Optional ByVal fec_fin As Date = Nothing, Optional ByVal AntHst As Boolean = True)



        strTipoAdmision = strTip_admision
        lAnoAdmision = lano_adm
        dblNumeroAdmision = dnum_adm
        strPrestador = strcod_pre_sgs
        strSucursal = strCod_sucur
        strMedicoRealizaCorreccion = strCorreccion

        'fec_ini = fec_ini.ToString("yyyy-MM-dd")
        'fec_fin = fec_fin.ToString("yyyy-MM-dd")

        Try
            _objConexion = objConexion
            ''Cracion del objeto que encapsula la informacion de la historia clinica
            _historiaClinica = New FormatoHistoriaClinica()
            ''Consulta de los datos de la historia clinica. Con esta info se llena el objeto _historiaClinica
            _historiaClinica.consultarHistoriaClinica(objConexion, strcod_pre_sgs, strCod_sucur,
                                                  strTip_admision, lano_adm, dnum_adm, strTipDoc,
                                                  strNumDoc, strTip_historia, strLogin, seccionesAdicionales, fec_ini, fec_fin)

            ''Se enlaza el objeto _historiaClinica con el origen de datos el reporte
            HCEncabezadoBindingSource.DataSource = _historiaClinica.Encabezado
            ''Se enlaza el objeto Paciente del objeto _historiaClinica con el origen de datos el reporte
            ''para acceder a los datos del paciente
            PacienteBindingSource.DataSource = _historiaClinica.Encabezado.Paciente
            OrdenBindingSource.DataSource = _historiaClinica.EncabezadoOrdenes

            strPermitirImprimirHClinica = strPermitirImprimir
            configurarPantallaReporte(strPermitirImprimirHClinica)

        Catch ex As Exception
            MsgBox("Error en la impresion del reporte. ")
        End Try

        ''Se define que el metodo SubreportProcessingEventHandler maneja el evento ReportViewer1.LocalReport.SubreportProcessing 
        ''del Reporte. Este evento ocurre cuando se procesan los subreportes contenidos en el reporte principal
        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEventHandler

        setParametrosReporte()

        Me.ReportViewer1.RefreshReport()

    End Sub

    'Ingresado por Claudia Garay para imprimir historia clinica sin antecedentes
    ' 24 julio 2009

    Public Sub ImprimirHistoriaClinicaSinAnte(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String, _
                   ByVal strCod_sucur As String, ByVal strTip_admision As String, _
                   ByVal lano_adm As Long, ByVal dnum_adm As Double, _
                   ByVal strTipDoc As String, ByVal strNumDoc As String, _
                   ByVal strTip_historia As String, ByVal strLogin As String, _
                   ByVal seccionesAdicionales As Secciones, Optional ByVal strPermitirImprimir As String = "S", _
                   Optional ByVal strCorreccion As String = "", Optional ByVal fec_ini As String = "", _
                   Optional ByVal fec_fin As String = "")


        strTipoAdmision = strTip_admision
        lAnoAdmision = lano_adm
        dblNumeroAdmision = dnum_adm
        strPrestador = strcod_pre_sgs
        strSucursal = strCod_sucur
        strMedicoRealizaCorreccion = strCorreccion


        Try
            _objConexion = objConexion
            ''Cracion del objeto que encapsula la informacion de la historia clinica
            _historiaClinica = New FormatoHistoriaClinica()
            ''Consulta de los datos de la historia clinica. Con esta info se llena el objeto _historiaClinica
            _historiaClinica.consultarHistoriaClinicaSinAntecedentes(objConexion, strcod_pre_sgs, strCod_sucur, _
                                                  strTip_admision, lano_adm, dnum_adm, strTipDoc, _
                                                  strNumDoc, strTip_historia, strLogin, seccionesAdicionales, _
                                                  fec_ini, fec_fin)

            ''Se enlaza el objeto _historiaClinica con el origen de datos el reporte
            HCEncabezadoBindingSource.DataSource = _historiaClinica.Encabezado
            ''Se enlaza el objeto Paciente del objeto _historiaClinica con el origen de datos el reporte
            ''para acceder a los datos del paciente
            PacienteBindingSource.DataSource = _historiaClinica.Encabezado.Paciente
            OrdenBindingSource.DataSource = _historiaClinica.EncabezadoOrdenes

            strPermitirImprimirHClinica = strPermitirImprimir
            configurarPantallaReporte(strPermitirImprimirHClinica)

        Catch ex As Exception
            MsgBox("Error en la impresion del reporte. ")
        End Try

        ''Se define que el metodo SubreportProcessingEventHandler maneja el evento ReportViewer1.LocalReport.SubreportProcessing 
        ''del Reporte. Este evento ocurre cuando se procesan los subreportes contenidos en el reporte principal
        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEventHandler

        setParametrosReporte()

        Me.ReportViewer1.RefreshReport()

    End Sub


    Private Sub ReportViewer1_RenderingComplete(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.RenderingCompleteEventArgs) Handles ReportViewer1.RenderingComplete
        'Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth

        If strPermitirImprimirHClinica = "N" Or strPermitirImprimirHClinica = "M" Then
            intMessages = intMessages + 1
            If intMessages = 2 Then
                If strPermitirImprimirHClinica = "N" Then
                    MsgBox("LA HISTORIA CLINICA QUE ESTA CONSULTANDO" & vbCrLf & _
                           "NO PUEDE SER IMPRESA YA QUE EL EXAMEN FISICO" & vbCrLf & _
                           "ESTA PENDIENTE POR RECLASIFICAR." & _
                           vbCrLf & vbCrLf & _
                           "ESTA RECLASIFICACION DEBE SER HECHA POR UN " & vbCrLf & _
                           "MEDICO AUTORIZADO.", MsgBoxStyle.Information, "IMPRESION HISTORIA CLINICA (No Permitida)")
                Else
                    If MsgBox("LA HISTORIA CLINICA QUE ESTA CONSULTANDO" & vbCrLf & _
                           "NO PUEDE SER IMPRESA YA QUE EL EXAMEN FISICO" & vbCrLf & _
                           "ESTA PENDIENTE POR RECLASIFICAR." & _
                           vbCrLf & vbCrLf & _
                           "DESEA CORREGIR ESTA HISTORIA CLINICA AHORA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "IMPRESION HISTORIA CLINICA (No Permitida)") = MsgBoxResult.Yes Then

                        If frmCorreccionEF_tmp.Mostrar() = True Then
                            configurarPantallaReporte()
                            frmHistoriaPrincipal.Timer1.Enabled = False
                            frmHistoriaPrincipal.lblError1.Visible = False
                            frmHistoriaPrincipal.lblError2.Visible = False
                        Else
                            Dim objpaciente As Sophia.HistoriaClinica.DatosPaciente.Paciente
                            Dim dtDatos As DataTable
                            Dim dtRows() As DataRow
                            Dim dtRow As DataRow
                            Dim intHCs As Integer

                            objpaciente = Sophia.HistoriaClinica.DatosPaciente.Paciente.Instancia

                            If objpaciente.HistoriasConErroresEF.Rows.Count > 1 Then
                                dtDatos = objpaciente.HistoriasConErroresEF
                                dtRows = dtDatos.Select("Estado='M'")
                                For Each dtRow In dtRows
                                    If dtRow.Item("tip_admision") = strTipoAdmision And dtRow.Item("ano_adm") = lAnoAdmision And dtRow.Item("num_adm") = dblNumeroAdmision Then
                                        configurarPantallaReporte()
                                    End If
                                    dtDatos.Rows.Remove(dtRow)
                                Next
                                objpaciente.HistoriasConErroresEF = dtDatos
                                intHCs = dtDatos.Rows.Count
                                frmHistoriaPrincipal.lblError1.Text = frmHistoriaPrincipal.lblError1.Text.Replace(frmHistoriaPrincipal.lblError1.Text.Substring(frmHistoriaPrincipal.lblError1.Text.IndexOf("(")), _
                                                                                                                  "(" & intHCs & " Historia" & IIf(intHCs > 1, "s", "") & " por Corregir - Clic Aquí para Corregir)")
                                frmHistoriaPrincipal.lblError2.Text = frmHistoriaPrincipal.lblError1.Text
                            End If
                        End If
                        'MsgBox("Si esta Historia Clínica fue corregida, envíe nuevamente la impresión", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Impresión Historia Clínica")
                        _historiaClinica.RevisionSistemas.Clear()
                        _historiaClinica.consultarRevisionSistemasExamenFisicoCorregido(_objConexion, strPrestador, strSucursal, _
                                                              strTipoAdmision, lAnoAdmision, dblNumeroAdmision)
                        _historiaClinica.Notas.Clear()
                        _historiaClinica.consultarNotasExamenFisicoCorregido(_objConexion, strPrestador, strSucursal, _
                                                              strTipoAdmision, lAnoAdmision, dblNumeroAdmision)

                        Me.ReportViewer1.RefreshReport()
                    End If
                End If
            End If
        End If
    End Sub


    ''' <summary>
    ''' Metodo que asigna la informacion consultada para cada una de las secciones de la historia clinica
    ''' a los origenes de datos de sus correspondientes subreportes. Este metodo se ejecuta cuando se 
    ''' dispara el evento ReportViewer1.LocalReport.SubreportProcessing que sucede en el momento que se 
    ''' se procesan los subreportes contenidos en el reporte principal  
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub SubreportProcessingEventHandler(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)
        Dim bsSource As New BindingSource()


        bsSource.DataSource = _historiaClinica.MotivoConsulta
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_MotivoConsulta", bsSource))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_RevisionEA", _historiaClinica.RevisionSistemasEA))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Perinatales", _historiaClinica.AntecedentesPerinatales))
        bsSource = New BindingSource()
        bsSource.DataSource = _historiaClinica.RiesgoNutricional
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_RiesgoNutricional", bsSource))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_DesarrolloPsicoMotor", _historiaClinica.AntecedentesDesarrolloPsicomotor))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Patologico", _historiaClinica.AntecedentesPalotogicos))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Ginecologico", _historiaClinica.AntecedentesGinecologicos))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Vacunacion", _historiaClinica.AntecedentesVacunacion))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Quirurgico", _historiaClinica.AntecedentesQuirurgicos))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Farmacologico", _historiaClinica.AntecedentesFarmacologicos))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Alergico", _historiaClinica.AntecedentesAlergicos))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Inmunologico", _historiaClinica.AntecedentesInmunologicos))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Toxico", _historiaClinica.AntecedentesToxicos))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Transfusional", _historiaClinica.AntecedentesTransfusionales))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Traumatologico", _historiaClinica.AntecedentesTraumatologicos))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Familiares", _historiaClinica.AntecedentesFamiliares))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Antecedente", _historiaClinica.OtrosAntecedentes))

        bsSource = New BindingSource()
        bsSource.DataSource = _historiaClinica.ExamenFisico
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_ExamenFisico", bsSource))

        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Revision", _historiaClinica.RevisionSistemas))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Diagnostico", _historiaClinica.Diagnosticos))

        bsSource = New BindingSource()
        If _historiaClinica.Encabezado.TipoAdmision = "E" Then
            bsSource.DataSource = Nothing
        Else
            bsSource.DataSource = _historiaClinica.Encabezado
        End If

        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_HCEncabezado", bsSource))

        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Evolucion", _historiaClinica.Evoluciones))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_EvolucionInterconsulta", _historiaClinica.evolucionesInterconsulta))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_MedicamentoExt", _historiaClinica.Medicamentos))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_ProcedimientoExt", _historiaClinica.Procedimientos))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_DiagnosticoEgreso", _historiaClinica.DiagnosticosEgreso))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Admision", _historiaClinica.Egresos))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Nota", _historiaClinica.Notas))

        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Aislamiento", _historiaClinica.DetalleOrdenesAislamientos))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Dieta", _historiaClinica.DetalleOrdenesDietas))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Medicamento", _historiaClinica.DetalleOrdenesMedica))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Procedimiento", _historiaClinica.DetalleOrdenesProce))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_OrdenGeneral", _historiaClinica.DetalleOrdenesGenerales))
        'e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_DiagnosticosQx", _historiaClinica.DiagnosticoQx))        
        'e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_DescripcionQx", _historiaClinica.Descripcion))


        'bsSource = New BindingSource()
        'bsSource.DataSource = _historiaClinica.Remision
        'e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_RemisionPlanManejo", bsSource))

        'bsSource = New BindingSource()
        'bsSource.DataSource = _historiaClinica.Recomendaciones
        'e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_RecomendacionEgreso", bsSource))

        'If Not _historiaClinica.Recomendaciones Is Nothing Then
        '    bsSource = New BindingSource()
        '    bsSource.DataSource = _historiaClinica.Recomendaciones.Medicamentos
        '    e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Comunes_ObjetoAuxiliar", bsSource))

        '    bsSource = New BindingSource()
        '    bsSource.DataSource = _historiaClinica.Recomendaciones.Procedimientos
        '    e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Comunes_ObjetoSimple", bsSource))
        'Else
        '    bsSource = New BindingSource()
        '    bsSource.DataSource = Nothing
        '    e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Comunes_ObjetoAuxiliar", bsSource))
        '    e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Comunes_ObjetoSimple", bsSource))
        'End If

        'bsSource = New BindingSource()
        'bsSource.DataSource = _historiaClinica.Triage
        'e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Triage", bsSource))

        'If Not _historiaClinica.Triage Is Nothing Then
        '    bsSource = New BindingSource()
        '    bsSource.DataSource = _historiaClinica.Triage.Paciente
        'Else
        '    bsSource = New BindingSource()
        '    bsSource.DataSource = Nothing
        'End If.Paciente.NombreCompleto

        'e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Paciente", bsSource))

    End Sub

    ''' <summary>
    ''' Debido a que el encabezado debe aparecer en todas las paginas del reporte, esta informacion 
    ''' debe ser pasada como parametro al reporte para que pueda ser pintada en el header
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub setParametrosReporte()
        Dim aParametros(22) As ReportParameter
        Dim row() As DataRow
        With _historiaClinica.Encabezado
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
            aParametros(17) = New ReportParameter("Secuencia", .secuencia)
            aParametros(18) = New ReportParameter("CausaExterna", .CausaExterna)
            aParametros(19) = New ReportParameter("Religion", .Paciente.Religion)
            aParametros(20) = New ReportParameter("FechaHoraAdmision", .Paciente.FechaHoraAdmision)
            aParametros(21) = New ReportParameter("Ubicacion", .Paciente.Ubicacion)
            aParametros(22) = New ReportParameter("EdadAMD", .Paciente.EdadAMD)
        End With


        'row = _historiaClinica.EquipoMedico.Select("tip_empleado='C' and (estado='A' or estado='')")

        'aParametros(17) = New ReportParameter("Medico", row(0).Item("Medico").ToString())
        'aParametros(18) = New ReportParameter("Especialidad", row(0).Item("descripcion1").ToString())
        'aParametros(19) = New ReportParameter("RegistroMedico", row(0).Item("reg_med").ToString())

        ReportViewer1.LocalReport.SetParameters(aParametros)
    End Sub

    Private Sub frmRepHistoriaClinica_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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
    End Sub

    Private Sub configurarPantallaReporte(Optional ByVal strPermitirImprimir As String = "S")

        If strPermitirImprimir = "N" Or strPermitirImprimir = "M" Or strPermitirImprimir = "R" Or _
           strMedicoRealizaCorreccion = "T" Then
            ReportViewer1.ShowPrintButton = False
            ReportViewer1.ShowExportButton = False
            Exit Sub
        End If

        If _historiaClinica.Encabezado.Estado = HCEncabezado.PENDIENTE Or _
            _historiaClinica.Encabezado.Estado = HCEncabezado.ENLISTA Then
            ReportViewer1.ShowPrintButton = False
            ReportViewer1.ShowExportButton = False
        Else
            ReportViewer1.ShowPrintButton = True
            ReportViewer1.ShowExportButton = True
            ReportViewer1.ShowFindControls = True
        End If

    End Sub


    Private Sub ReportViewer1_Search(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.SearchEventArgs) Handles ReportViewer1.Search
        'MsgBox("Buscar")
    End Sub

    Private Sub frmRepHistoriaClinica_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load
        'Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
    End Sub
End Class