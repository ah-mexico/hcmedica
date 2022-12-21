Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports System.Text.RegularExpressions
Imports System.Collections.Generic
Imports System.Data.Common
Imports System.Text
Imports HistoriaClinica.Sophia.HistoriaClinica
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports objPaciente = HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente.Paciente
Imports objGenerales = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales

Public Class frmConsultaHC

    Dim strDir As String = System.Environment.SystemDirectory.ToString()
    Dim strCadenaLocal As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strDir & "\SOPHIA\Sophia.mdb"
    Dim _datosGenerales As Generales
    Dim _paciente As Paciente
    Dim _datosConexion As Conexion
    Private objIncapacidad As PlanIncapacidad
    Dim dtvalores As New DataTable
    Dim objP As objPaciente = objPaciente.Instancia
    Private objFormuExt As PlanFormuExterna 'jlalfonso
    Dim _OrigenAdm As String = ""




    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _paciente = New Paciente()
        objFormuExt = PlanFormuExterna.Instancia
    End Sub

    Public Sub cargarTiposDocumento()
        Dim objTablasBasicas As New BLBasicasLocales

        With tbCodigoTipDoc
            .NombreCampoBuscado = "descripcion"
            .NombreCampoBusqueda = "tip_doc"
            .ControlTextoEnlace = tbDescTipDoc
        End With

        With tbDescTipDoc
            .NombreCampoDatos = "descripcion"
            .ControlTextoEnlace = tbCodigoTipDoc
            .OrigenDeDatos = objTablasBasicas.TraerDatosTablasBasicasLocales(strCadenaLocal, "gentipdo", "tip_doc, descripcion", "")
            .CargarDatosDescripcion()
        End With
    End Sub

    Private Sub frmConsultaHC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        ValidaKeyPress(Me, e)
    End Sub

    Private Sub frmConsultaHC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarTiposDocumento()
        _datosConexion = Conexion.Instancia()
        _datosGenerales = Generales.Instancia()

        'Req. Datos Sensibles HC Raul Cruz
        _datosGenerales.ConsultarServidorReporte(_datosConexion)
        _OrigenAdm = _datosGenerales.OrigenAdm

        tbCodigoTipDoc.Focus()
        If _datosGenerales.Pais = "482" Then
            ckIncapacidad.Text = "Descanso Médico"
            ''  ckFormula.Location = New System.Drawing.Point(238, 44)
        ElseIf _datosGenerales.Pais = "484" Then
            ckIncapacidad.Text = "Reposo"
        End If
    End Sub

    Public Sub mostrar(ByVal strTip_doc As String, ByVal strNum_doc As String)
        If strTip_doc.Trim.Length > 0 And strNum_doc.Trim.Length > 0 Then
            tbCodigoTipDoc.Text = strTip_doc
            txtNumDoc.Text = strNum_doc
            _datosConexion = Conexion.Instancia()
            _datosGenerales = Generales.Instancia()
            'Req. Datos Sensibles HC Raul Cruz
            _datosGenerales.ConsultarServidorReporte(_datosConexion)
            _OrigenAdm = _datosGenerales.OrigenAdm

            'If _OrigenAdm = "" Then
            '    _OrigenAdm = _datosGenerales.OrigenAdm
            'End If
            btnBuscar_Click(New Object(), New EventArgs())
            mskFechaDesde.Focus()
        End If

        Me.ShowDialog()
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        'prueba raul para Git
        Dim objPaciente As New Paciente
        Dim bPacienteEncontrado As Boolean

        LimpiarDataGrid(dtgAdmisiones) ''Claudia Garay 5 de Agosto de 2010 Limpiar la grilla de admisiones

        Try
            'Busqueda por documento
            If Len(tbCodigoTipDoc.Text) > 0 And Len(txtNumDoc.Text) > 0 Then

                txtNumDoc.Text = Replace(Replace(Replace(Replace(Replace(Replace(txtNumDoc.Text, "=", "", 1), "OR", ""), "%", "", 1), "&", "", 1), "DELETE", "", 1), "'", "", 1)

                _paciente = New Paciente().buscarDocumento(_datosConexion, tbCodigoTipDoc.Text, txtNumDoc.Text)

                If Not New Paciente().PacienteVacio(_paciente) Then

                    If _paciente.Unificado = "U" And Not New Paciente().PacienteVacio(_paciente.PacienteUnificador) Then
                        With _paciente.PacienteUnificador
                            MsgBox("Este documento se ha unificado a el documento " _
                                   & .TipoDocumento & " " & .NumeroDocumento)
                            tbCodigoTipDoc.Text = .TipoDocumento
                            txtNumDoc.Text = .NumeroDocumento
                            txtPrimerNombre.Text = .PrimerNombre
                            txtSegundoNombre.Text = .SegundoNombre
                            txtPrimerApellido.Text = .PrimerApellido
                            txtSegundoApellido.Text = .SegundoApellido
                            ConsultarHistoria()
                        End With
                    Else
                        With _paciente
                            txtPrimerNombre.Text = .PrimerNombre
                            txtSegundoNombre.Text = .SegundoNombre
                            txtPrimerApellido.Text = .PrimerApellido
                            txtSegundoApellido.Text = .SegundoApellido
                            ConsultarHistoria() ''Procedimiento que ejecuta lo q se contenia en el boton traer historia 05/08/2010
                        End With
                    End If
                Else
                    MsgBox("Registro no existe.", MsgBoxStyle.Information)
                End If
            Else 'Busqueda por Nombre
                If Not String.IsNullOrEmpty(txtPrimerApellido.Text) And
                   Not String.IsNullOrEmpty(txtPrimerNombre.Text) Then

                    objPaciente.PrimerApellido = txtPrimerApellido.Text
                    objPaciente.PrimerNombre = txtPrimerNombre.Text

                    bPacienteEncontrado = frmConsultaPorNombre.mostrar(objPaciente)

                    If bPacienteEncontrado = True Then
                        _paciente = objPaciente
                        With _paciente
                            tbCodigoTipDoc.Text = .TipoDocumento
                            txtNumDoc.Text = .NumeroDocumento
                            txtPrimerNombre.Text = .PrimerNombre
                            txtSegundoNombre.Text = .SegundoNombre
                            txtPrimerApellido.Text = .PrimerApellido
                            txtSegundoApellido.Text = .SegundoApellido
                        End With
                        ConsultarHistoria() ''Procedimiento que ejecuta lo q se contenia en el boton traer historia
                        _paciente = New Paciente().buscarDocumento(_datosConexion, tbCodigoTipDoc.Text, txtNumDoc.Text)

                    Else
                        MsgBox("Registro no existe.", MsgBoxStyle.Information)
                    End If
                Else
                    MsgBox("Datos incompletos.", MsgBoxStyle.Information)
                End If
            End If



            Me.mskFechaDesde.Focus()
        Catch ex As Exception
            MsgBox("Error en la busqueda del paciente. " & ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub


    Private Sub btnTraer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTraer.Click
        Dim fechaInicial As Date
        Dim fechaFinal As Date
        Dim dtDatos As DataTable

        dtDatos = dtgAdmisiones.DataSource
        If Not dtDatos Is Nothing Then
            dtDatos.Clear()
        End If

        If mskFechaDesde.Text = "  /  /" Then
            fechaInicial = Nothing
        Else
            fechaInicial = CDate(mskFechaDesde.Text)
        End If

        If mskFechaHasta.Text = "  /  /" Then
            fechaFinal = Nothing
        Else
            fechaFinal = CDate(mskFechaHasta.Text)
        End If

        Try

            dtDatos = FormatoHistoriaClinica.traerHistoriasXPaciente(_datosConexion, _paciente, fechaInicial, fechaFinal,
                                                                     _datosGenerales.Sucursal, _datosGenerales.Prestador)

            If dtDatos.Rows.Count Then
                dtgAdmisiones.DataSource = dtDatos
                dtgAdmisiones.Sort(dtgAdmisiones.Columns("fec_hc"), System.ComponentModel.ListSortDirection.Descending)
                configurarGrilla()
            Else
                MsgBox("No existen registros que cumplan este criterio", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox("Error en la consulta de las Historias Clinicas." & ex.Message)
        End Try

    End Sub

    ''Claudia Garay 5 de agosto
    '' Se recoge la rutina que estaba en btnTraer_Click
    Private Sub ConsultarHistoria()

        Dim fechaInicial As Date
        Dim fechaFinal As Date
        Dim dtDatos As DataTable
        Dim objDatosGenerales As objGenerales.Generales

        objDatosGenerales = objGenerales.Generales.Instancia

        dtDatos = dtgAdmisiones.DataSource
        If Not dtDatos Is Nothing Then
            dtDatos.Clear()
        End If

        If mskFechaDesde.Text = "  /  /" Then
            fechaInicial = Nothing
        Else
            fechaInicial = CDate(mskFechaDesde.Text)
        End If

        If mskFechaHasta.Text = "  /  /" Then
            fechaFinal = Nothing
        Else
            fechaFinal = CDate(mskFechaHasta.Text)
        End If

        Try

            dtDatos = FormatoHistoriaClinica.traerHistoriasXPaciente(_datosConexion, _paciente, fechaInicial, fechaFinal,
                                                                     objDatosGenerales.Sucursal, objDatosGenerales.Prestador)
            If dtDatos.Rows.Count Then
                dtgAdmisiones.DataSource = dtDatos

                dtgAdmisiones.Sort(dtgAdmisiones.Columns("fec_hc"), System.ComponentModel.ListSortDirection.Descending)
                configurarGrilla()
            Else
                MsgBox("No existen registros que cumplan este criterio", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox("Error en la consulta de las Historias Clinicas." & ex.Message)
        End Try

    End Sub
    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click

        Dim edadPaciente As Integer
        Dim seccionesAdicionales As Secciones
        Dim historiaClinica As FormatoHistoriaClinica
        Dim strPermitirImprimirHC As String = "S"
        Dim intOrden As Integer
        Dim dtDatos As DataTable
        Dim objConseguirDatosS As New BLHistoriaBasica
        Dim dtEntidad As DataTable
        Dim strTipoUsuario As String = ""
        Dim fec_ini As String
        Dim fec_fin As String
        _datosGenerales = Generales.Instancia

        If Me.mskFechaDesdeRep.Text <> "  /  /" And Me.mskFechaHastaRep.Text <> "  /  /" Then
            fec_ini = CDate(Me.mskFechaDesdeRep.Text)
            fec_fin = CDate(Me.mskFechaHastaRep.Text)
        Else
            fec_ini = IIf(_paciente.FechaNacimiento = "", dtgAdmisiones.CurrentRow.Cells("fec_hc").Value.ToString(), _paciente.FechaNacimiento)
            fec_fin = FuncionesGenerales.FechaServidor()
            'fec_fin = dtgAdmisiones.CurrentRow.Cells("fec_hc").Value.ToString()
        End If

        If _datosGenerales Is Nothing Then
            MsgBox("No existen parametros de entrada.", MsgBoxStyle.Information)
            Exit Sub
        End If

        If dtgAdmisiones.RowCount <= 0 Then
            MsgBox("Se deben consultar las historia clinicas.", MsgBoxStyle.Information)
            Exit Sub
        End If

        ''cpgaray Julio 23 de 2012 auditoria de Impresion de Historias
        Try

            With dtgAdmisiones.CurrentRow

                GrabarAuditoriaConsultaHC(_datosGenerales.Prestador, _datosGenerales.Sucursal, .Cells("tip_admision").Value, .Cells("ano_adm").Value, .Cells("num_adm").Value, .Cells("tip_doc").Value & .Cells("num_doc").Value, _datosGenerales.Login)

            End With

        Catch ex As Exception

        End Try

        'Inicio 20210409 Req Datos Sensibles HC, desarrollado por Raul Cruz
        If dtgAdmisiones.CurrentRow.Cells("LINKED_SERVER").FormattedValue <> "" Then
            'Se cambia por la que se trae en la grilla.
            _datosGenerales.OrigenAdm = dtgAdmisiones.CurrentRow.Cells("LINKED_SERVER").Value.ToString
        Else
            _datosGenerales.OrigenAdm = _OrigenAdm 'se deja con la inicial que carga la aplicación
        End If
        'Fin 20210409 Req Datos Sensibles HC, desarrollado por Raul Cruz

        'Se adiciona control para imprimir nuevo reporte de conciliacion CU_CONC_11 INDRA/FABAICUE 18/03/2022
        If chkConciliacionMed.Checked = True Then
            Dim fec_ini_con As String = String.Empty
            Dim fec_fin_con As String = String.Empty

            If Me.mskFechaDesdeRep.Text <> "  /  /" And Me.mskFechaHastaRep.Text <> "  /  /" Then
                fec_ini_con = CDate(Me.mskFechaDesdeRep.Text)
                fec_fin_con = CDate(Me.mskFechaHastaRep.Text)
            End If

            With dtgAdmisiones.CurrentRow
                RptHC.ImprimirConciliacionMedicamentos(_datosConexion, _datosGenerales.Prestador, _datosGenerales.Sucursal, .Cells("tip_admision").Value, .Cells("ano_adm").Value,
                    .Cells("num_adm").Value, IIf(String.IsNullOrEmpty(dtgAdmisiones.CurrentRow.Cells("tip_doc").Value), _paciente.TipoDocumento, dtgAdmisiones.CurrentRow.Cells("tip_doc").Value),
                    IIf(String.IsNullOrEmpty(dtgAdmisiones.CurrentRow.Cells("num_doc").Value), _paciente.NumeroDocumento, dtgAdmisiones.CurrentRow.Cells("num_doc").Value),
                    _datosGenerales.Login, fec_ini_con, fec_fin_con)
                RptHC.ShowDialog()
                RptHC.Close()
            End With
            Exit Sub
        End If

        If chkDescripcion.Checked = True Then
            ImprimirDescripcionQX()
            Exit Sub
        End If

        '**HDCPCEF (Habilitar - Deshabilitar Código Para Corrección Examen Fisico**
        If ckHCBasica.Checked = True Or ckTodos.Checked = True Then

            Dim objPaciente As Sophia.HistoriaClinica.DatosPaciente.Paciente = Sophia.HistoriaClinica.DatosPaciente.Paciente.Instancia
            Dim dtRows() As DataRow
            Dim blnConsultarHCErrores As Boolean = False



            If dtgAdmisiones.CurrentRow.Cells("id_med").Value.ToString.Trim = _datosGenerales.Login.Trim Then
                If Not objPaciente.HistoriasConErroresEF Is Nothing Then
                    If objPaciente.HistoriasConErroresEF.Rows.Count > 0 Then
                        dtDatos = dtgAdmisiones.DataSource
                        With dtgAdmisiones.CurrentRow
                            dtRows = objPaciente.HistoriasConErroresEF.Select("cod_pre_sgs='" & .Cells("cod_pre_sgs").Value & "' AND cod_sucur='" & .Cells("cod_sucur").Value & "' AND " &
                                                                              "tip_doc='" & .Cells("tip_doc").Value & "' AND num_doc='" & .Cells("num_doc").Value & "' AND tip_admision='" &
                                                                              .Cells("tip_admision").Value & "' AND ano_adm=" & .Cells("ano_adm").Value & " AND num_adm=" & .Cells("num_adm").Value &
                                                                              " AND estado<>'M'")
                            If dtRows.Length > 0 Then
                                strPermitirImprimirHC = "M"
                                With objPaciente.HistoriasConErroresEF
                                    For intOrden = 0 To .Rows.Count - 1
                                        If .Rows(intOrden).Item("tip_admision") = dtgAdmisiones.CurrentRow.Cells("tip_admision").Value And
                                            .Rows(intOrden).Item("ano_adm") = dtgAdmisiones.CurrentRow.Cells("ano_adm").Value And
                                            .Rows(intOrden).Item("num_adm") = dtgAdmisiones.CurrentRow.Cells("num_adm").Value Then
                                            .Rows(intOrden).Item("orden") = 1
                                        Else
                                            If Month(.Rows(intOrden).Item("fec_hc")) = Month(dtgAdmisiones.CurrentRow.Cells("fec_hc").Value) Then
                                                .Rows(intOrden).Item("orden") = 2
                                            Else
                                                .Rows(intOrden).Item("orden") = 3
                                            End If
                                        End If
                                    Next
                                    .DefaultView.Sort = "Orden ASC, fec_hc ASC"
                                    objPaciente.HistoriasConErroresEF = .DefaultView.ToTable
                                End With
                            Else
                                blnConsultarHCErrores = True
                            End If
                        End With
                    Else
                        blnConsultarHCErrores = True
                    End If
                Else
                    blnConsultarHCErrores = True
                End If
            Else
                blnConsultarHCErrores = True
            End If


            If blnConsultarHCErrores Or _datosGenerales.MedicoRealizaCorreccion = "T" Then
                With dtgAdmisiones.CurrentRow
                    ConsultarAdmisionesConEF_Errado(.Cells("cod_pre_sgs").Value, .Cells("cod_sucur").Value,
                                                    .Cells("tip_doc").Value, .Cells("num_doc").Value,
                                                    .Cells("tip_admision").Value, .Cells("ano_adm").Value,
                                                    .Cells("num_adm").Value, .Cells("fec_hc").Value, .Cells("id_med").Value.ToString,
                                                    strPermitirImprimirHC)
                End With
            End If
        End If
        '**/

        seccionesAdicionales = cargarOpcionesImpresion()


        Dim _historiaClinica As FormatoHistoriaClinica = New FormatoHistoriaClinica()


        With dtgAdmisiones.CurrentRow

            Dim antecedentes As Boolean
            Dim objOrden As Orden       ''Objeto que encapula la informacion de la orden
            Dim procedimext_todos As Double
            Dim formula_todos As Integer
            objOrden = New Orden

            If ckTodos.Checked = True Then

                If ckHCBasica.Checked Then
                    antecedentes = True
                Else
                    antecedentes = False
                End If

                If cboProcedimExt.Text = "" Then
                    procedimext_todos = 0
                Else
                    procedimext_todos = CDbl(cboProcedimExt.Text)
                End If

                If cboFormula.Text = "" Then
                    formula_todos = 0
                Else
                    formula_todos = CInt(cboFormula.Text)
                End If
                '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
                'Juan Carlos Jaramillo Lozano - IG
                RptHC_Enf_Med.Show()
                RptHC_Enf_Med.ImprimirHistoriaClinica_Med_Consulta(_datosConexion, "|srptIncapacidadMed|srptHCMedRecomendacionEgreso|", "82",
                                                               .Cells("tip_doc").Value, .Cells("num_doc").Value,
                                                               Date.Now, Date.Now, "1", "23", .Cells("tip_admision").Value,
                                                               .Cells("ano_adm").Value, .Cells("num_adm").Value,
                                                               .Cells("cod_sucur").Value, .Cells("cod_pre_sgs").Value,
                                                               antecedentes, procedimext_todos, objOrden.Compañia,
                                                               False, False, formula_todos, strTipoUsuario,
                                                               objP.CodHistoria)
                '2019-03-11 Fin
                Exit Sub
            End If

            If ckHCBasica.Checked Then
                'Dim ruta As String = "http://app02.colsanitas.com/ReportServer/?%2fHC%2frptHCConsolidada&rs:Command=Render&strtipdoc=CC&strnumdoc=7842519&fec_ini=1900-01-01&fec_fin=2019-01-01&cod_pre_sgs=1100109887&cod_sucur=115&tip_admision=H&ano_adm=2017&num_adm=12959&ANTECEDENTES_HST=true&GeneradoPor=CAM&rs:Format=PDF"
                'Dim ruta As String = "http://app02.colsanitas.com/ReportServer/?%2fHC%2frptHCConsolidada&rs:Command=Render&strtipdoc=CC&strnumdoc=7842519&fec_ini=1900-01-01&fec_fin=2019-01-01&cod_pre_sgs=1100109887&cod_sucur=115&tip_admision=H&ano_adm=2017&num_adm=12959&ANTECEDENTES_HST=true&GeneradoPor=CAM&rc:Parameters=false"
                'Dim frm1 As frmVisualizarPdf = New frmVisualizarPdf(ruta)
                'frm1.ShowDialog()

                Select Case _datosGenerales.ReportingService

                    Case 0
                        frmRepHistoriaClinica.Show()
                        frmRepHistoriaClinica.ImprimirHistoriaClinica(_datosConexion, .Cells("cod_pre_sgs").Value,
                                          .Cells("cod_sucur").Value, .Cells("tip_admision").Value,
                                          .Cells("ano_adm").Value, .Cells("num_adm").Value,
                                          .Cells("tip_doc").Value, .Cells("num_doc").Value,
                                          .Cells("tip_hc").Value, _datosGenerales.Login,
                                          seccionesAdicionales, strPermitirImprimirHC, _datosGenerales.MedicoRealizaCorreccion,
                                          fec_ini, fec_fin, True)
                    Case 1
                        Try
                            RptHC.ImprimirHistoriaClinica(_datosConexion, .Cells("cod_pre_sgs").Value,
                                              .Cells("cod_sucur").Value, .Cells("tip_admision").Value,
                                              .Cells("ano_adm").Value, .Cells("num_adm").Value, objP.CodHistoria,
                                              IIf(String.IsNullOrEmpty(dtgAdmisiones.CurrentRow.Cells("tip_doc").Value), _paciente.TipoDocumento, dtgAdmisiones.CurrentRow.Cells("tip_doc").Value),
                                              IIf(String.IsNullOrEmpty(dtgAdmisiones.CurrentRow.Cells("num_doc").Value), _paciente.NumeroDocumento, dtgAdmisiones.CurrentRow.Cells("num_doc").Value),
                                              .Cells("tip_hc").Value, _datosGenerales.NombreMedico,
                                              True, _datosGenerales.Login, seccionesAdicionales, edadPaciente,
                                                strPermitirImprimirHC, fec_ini, fec_fin)
                            RptHC.ShowDialog()
                            RptHC.Close()

                        Catch ex As Exception
                            'RptHC.Close()
                            'frmRepHistoriaClinica.Show()
                            'frmRepHistoriaClinica.ImprimirHistoriaClinica(_datosConexion, .Cells("cod_pre_sgs").Value,
                            '                  .Cells("cod_sucur").Value, .Cells("tip_admision").Value,
                            '                  .Cells("ano_adm").Value, .Cells("num_adm").Value,
                            '                  .Cells("tip_doc").Value, .Cells("num_doc").Value,
                            '                  .Cells("tip_hc").Value, _datosGenerales.Login,
                            '                  seccionesAdicionales, strPermitirImprimirHC, _datosGenerales.MedicoRealizaCorreccion,
                            '                  fec_ini, fec_fin, True)
                        End Try

                    Case 2
                        RptHC.ImprimirHistoriaClinica(_datosConexion, .Cells("cod_pre_sgs").Value,
                                          .Cells("cod_sucur").Value, .Cells("tip_admision").Value,
                                          .Cells("ano_adm").Value, .Cells("num_adm").Value, objP.CodHistoria,
                                          IIf(String.IsNullOrEmpty(dtgAdmisiones.CurrentRow.Cells("tip_doc").Value), _paciente.TipoDocumento, dtgAdmisiones.CurrentRow.Cells("tip_doc").Value),
                                          IIf(String.IsNullOrEmpty(dtgAdmisiones.CurrentRow.Cells("num_doc").Value), _paciente.NumeroDocumento, dtgAdmisiones.CurrentRow.Cells("num_doc").Value),
                                          .Cells("tip_hc").Value, _datosGenerales.NombreMedico,
                                          True, _datosGenerales.Login, seccionesAdicionales, edadPaciente,
                                                strPermitirImprimirHC, fec_ini, fec_fin)
                        RptHC.ShowDialog()
                        RptHC.Close()

                        frmRepHistoriaClinica.Show()
                        frmRepHistoriaClinica.ImprimirHistoriaClinica(_datosConexion, .Cells("cod_pre_sgs").Value,
                                          .Cells("cod_sucur").Value, .Cells("tip_admision").Value,
                                          .Cells("ano_adm").Value, .Cells("num_adm").Value,
                                          .Cells("tip_doc").Value, .Cells("num_doc").Value,
                                          .Cells("tip_hc").Value, _datosGenerales.Login,
                                          seccionesAdicionales, strPermitirImprimirHC, _datosGenerales.MedicoRealizaCorreccion,
                                          fec_ini, fec_fin, True)
                End Select

            ElseIf chkCuidadosPaliativos.Checked Then
                '    frmRepCuidadosPaliativos.Show()
                '    frmRepCuidadosPaliativos.imprimirCuidadosPaliativos(_datosConexion, .Cells("cod_pre_sgs").Value,
                '.Cells("cod_sucur").Value, .Cells("tip_admision").Value, .Cells("ano_adm").Value, .Cells("num_adm").Value,
                '.Cells("tip_doc").Value, .Cells("num_doc").Value)

                '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
                'Juan Carlos Jaramillo Lozano - IG
                RptHC_Enf_Med.Show()
                RptHC_Enf_Med.ImprimirHistoriaClinica_imprimirCuidadosPaliativos(_datosConexion, "78", .Cells("cod_pre_sgs").Value,
                                                                                .Cells("cod_sucur").Value, .Cells("tip_admision").Value,
                                                                                 .Cells("ano_adm").Value, .Cells("num_adm").Value,
                                                                                .Cells("tip_doc").Value, .Cells("num_doc").Value,
                                                                                 objP.CodHistoria)
                '2019-03-11 Fin

            ElseIf chkResumenEgreso.Checked Then
                'frmRepResumenHistoriaClinica.Show()
                'frmRepResumenHistoriaClinica.ImprimirResumenHistoriaClinica(_datosConexion, .Cells("cod_pre_sgs").Value,
                '                  .Cells("cod_sucur").Value, .Cells("tip_admision").Value,
                '                  .Cells("ano_adm").Value, .Cells("num_adm").Value)

                'Ingresado por Claudia Garay
                '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
                'Juan Carlos Jaramillo Lozano - IG
                RptHC_Enf_Med.Show()
                RptHC_Enf_Med.ImprimirHistoriaClinica_imprimirCuidadosEpicrisis(_datosConexion, "77", .Cells("cod_pre_sgs").Value,
                                                                                .Cells("cod_sucur").Value, .Cells("tip_admision").Value,
                                                                                .Cells("ano_adm").Value, .Cells("num_adm").Value,
                                                                                .Cells("tip_doc").Value, .Cells("num_doc").Value,
                                                                                objP.CodHistoria)
                '2019-03-11 Fin


            ElseIf ckHCBasicaSinAnte.Checked Then

                Select Case _datosGenerales.ReportingService
                    Case 0

                        frmRepHistoriaClinica.Show()
                        frmRepHistoriaClinica.ImprimirHistoriaClinicaSinAnte(_datosConexion, .Cells("cod_pre_sgs").Value,
                                      .Cells("cod_sucur").Value, .Cells("tip_admision").Value,
                                      .Cells("ano_adm").Value, .Cells("num_adm").Value,
                                      .Cells("tip_doc").Value, .Cells("num_doc").Value,
                                      .Cells("tip_hc").Value, _datosGenerales.Login,
                                      seccionesAdicionales, strPermitirImprimirHC, _datosGenerales.MedicoRealizaCorreccion,
                                      fec_ini, fec_fin)

                        'frmRepHistoriaClinica.Show()
                        'frmRepHistoriaClinica.ImprimirHistoriaClinica(_datosConexion, .Cells("cod_pre_sgs").Value,
                        '                  .Cells("cod_sucur").Value, .Cells("tip_admision").Value,
                        '                  .Cells("ano_adm").Value, .Cells("num_adm").Value,
                        '                  .Cells("tip_doc").Value, .Cells("num_doc").Value,
                        '                  .Cells("tip_hc").Value, _datosGenerales.Login,
                        '                  seccionesAdicionales, strPermitirImprimirHC, _datosGenerales.MedicoRealizaCorreccion,
                        '                  fec_ini, fec_fin, False)
                    Case 1
                        Try
                            'CU_CONC_07 y CU_CONC_10 (Conciliación Medicamentos) INDRA
                            'Se pasa estado False a True para que siempre muestre el Profesional en el reporte INDRA/OJPARRA 16/03/2022.
                            RptHC.ImprimirHistoriaClinica(_datosConexion, .Cells("cod_pre_sgs").Value,
                                              .Cells("cod_sucur").Value, .Cells("tip_admision").Value,
                                              .Cells("ano_adm").Value, .Cells("num_adm").Value, objP.CodHistoria,
                                              IIf(String.IsNullOrEmpty(dtgAdmisiones.CurrentRow.Cells("tip_doc").Value), _paciente.TipoDocumento, dtgAdmisiones.CurrentRow.Cells("tip_doc").Value),
                                              IIf(String.IsNullOrEmpty(dtgAdmisiones.CurrentRow.Cells("num_doc").Value), _paciente.NumeroDocumento, dtgAdmisiones.CurrentRow.Cells("num_doc").Value),
                                              .Cells("tip_hc").Value, _datosGenerales.NombreMedico,
                                              True, _datosGenerales.Login, seccionesAdicionales, edadPaciente,
                                                strPermitirImprimirHC, fec_ini, fec_fin)
                            RptHC.ShowDialog()
                            RptHC.Close()

                        Catch ex As Exception
                            'RptHC.Close()
                            'frmRepHistoriaClinica.Show()
                            'frmRepHistoriaClinica.ImprimirHistoriaClinicaSinAnte(_datosConexion, .Cells("cod_pre_sgs").Value,
                            '              .Cells("cod_sucur").Value, .Cells("tip_admision").Value,
                            '              .Cells("ano_adm").Value, .Cells("num_adm").Value,
                            '              .Cells("tip_doc").Value, .Cells("num_doc").Value,
                            '              .Cells("tip_hc").Value, _datosGenerales.Login,
                            '              seccionesAdicionales, strPermitirImprimirHC, _datosGenerales.MedicoRealizaCorreccion,
                            '              fec_ini, fec_fin)


                        End Try
                    Case 2

                        RptHC.ImprimirHistoriaClinica(_datosConexion, .Cells("cod_pre_sgs").Value,
                                          .Cells("cod_sucur").Value, .Cells("tip_admision").Value,
                                          .Cells("ano_adm").Value, .Cells("num_adm").Value, objP.CodHistoria,
                                          IIf(String.IsNullOrEmpty(dtgAdmisiones.CurrentRow.Cells("tip_doc").Value), _paciente.TipoDocumento, dtgAdmisiones.CurrentRow.Cells("tip_doc").Value),
                                          IIf(String.IsNullOrEmpty(dtgAdmisiones.CurrentRow.Cells("num_doc").Value), _paciente.NumeroDocumento, dtgAdmisiones.CurrentRow.Cells("num_doc").Value),
                                          .Cells("tip_hc").Value, _datosGenerales.NombreMedico,
                                          False, _datosGenerales.Login, seccionesAdicionales, edadPaciente,
                                                strPermitirImprimirHC, fec_ini, fec_fin)
                        RptHC.ShowDialog()
                        RptHC.Close()

                        frmRepHistoriaClinica.Show()
                        frmRepHistoriaClinica.ImprimirHistoriaClinicaSinAnte(_datosConexion, .Cells("cod_pre_sgs").Value,
                                          .Cells("cod_sucur").Value, .Cells("tip_admision").Value,
                                          .Cells("ano_adm").Value, .Cells("num_adm").Value,
                                          .Cells("tip_doc").Value, .Cells("num_doc").Value,
                                          .Cells("tip_hc").Value, _datosGenerales.Login,
                                          seccionesAdicionales, strPermitirImprimirHC, _datosGenerales.MedicoRealizaCorreccion,
                                          fec_ini, fec_fin)

                End Select

            Else
                historiaClinica = New FormatoHistoriaClinica()



                historiaClinica.consultarSeccionesAdicionales(_datosConexion, .Cells("cod_pre_sgs").Value,
                                                    .Cells("cod_sucur").Value, .Cells("tip_admision").Value,
                                                    .Cells("ano_adm").Value, .Cells("num_adm").Value,
                                                    .Cells("tip_doc").Value, .Cells("num_doc").Value,
                                                    .Cells("tip_hc").Value, _datosGenerales.Login,
                                                    edadPaciente, seccionesAdicionales)

                If seccionesAdicionales.Remision Then
                    'frmRepRemisionConsultaHC.Show()
                    'frmRepRemisionConsultaHC.imprimirRemision(historiaClinica)

                    '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
                    'Juan Carlos Jaramillo Lozano - IG
                    RptHC_Enf_Med.Show()
                    '29/12/21 Miabonilla alm 700 No enviamos correo
                    RptHC_Enf_Med.ImprimirHistoriaClinica_imprimirRemision(_datosConexion, "73", .Cells("cod_pre_sgs").Value,
                                                                              .Cells("cod_sucur").Value, .Cells("tip_doc").Value,
                                                                              .Cells("num_doc").Value, .Cells("tip_admision").Value,
                                                                              .Cells("ano_adm").Value, .Cells("num_adm").Value,
                                                                           objP.CodHistoria, "N")
                    '2019-03-11 Fin

                ElseIf seccionesAdicionales.Recomendaciones Then
                    Dim objDatosGenerales As objGenerales.Generales

                    objDatosGenerales = objGenerales.Generales.Instancia

                    If objDatosGenerales.Pais = "482" Then ''Peru 
                        frmRepRecomendacionesConsultaHC.Show()
                        frmRepRecomendacionesConsultaHC.imprimirRecomendaciones(historiaClinica)
                    Else
                        '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
                        'Juan Carlos Jaramillo Lozano - IG
                        RptHC_Enf_Med.Show()
                        RptHC_Enf_Med.ImprimirHistoriaClinica_Recomendacion(_datosConexion, "67", .Cells("cod_pre_sgs").Value,
                                                                              .Cells("cod_sucur").Value, .Cells("tip_doc").Value,
                                                                              .Cells("num_doc").Value, .Cells("tip_admision").Value,
                                                                              .Cells("ano_adm").Value, .Cells("num_adm").Value,
                                                                            objP.CodHistoria)
                        '2019-03-11 Fin
                    End If


                ElseIf seccionesAdicionales.Triage Then
                    'frmRepTriageConsultaHC.Show()
                    frmRepTriageConsultaHC.imprimirTriage(historiaClinica)

                    '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
                    'Juan Carlos Jaramillo Lozano - IG
                    RptHC_Enf_Med.Show()
                    RptHC_Enf_Med.ImprimirHistoriaClinica_Triage_1(_datosConexion, "75", .Cells("cod_pre_sgs").Value,
                                                                              .Cells("cod_sucur").Value, .Cells("tip_doc").Value,
                                                                              .Cells("num_doc").Value, .Cells("tip_admision").Value,
                                                                              .Cells("ano_adm").Value, .Cells("num_adm").Value,
                                                                   objP.CodHistoria)
                    '2019-03-11 Fin
                ElseIf seccionesAdicionales.Incapacidad Then
                    'cpgaray Julio 23 de 2012 por errores en las evoluciones el objeto paciente no sera actualizado
                    'objP.TipoDocumento = .Cells("tip_doc").Value
                    'objP.NumeroDocumento = .Cells("num_doc").Value
                    'objP.TipoAdmision = .Cells("tip_admision").Value
                    'objP.AnoAdmision = .Cells("ano_adm").Value
                    'objP.NumeroAdmision = .Cells("num_adm").Value
                    'frmRepPlanIncapacidad.Show()
                    'frmRepPlanIncapacidad.imprimirRepPlanIncapacidad(_datosConexion, .Cells("cod_pre_sgs").Value, .Cells("cod_sucur").Value, _
                    '                                                objP.TipoDocumento, objP.NumeroDocumento, _
                    '                                                objP.TipoAdmision, objP.AnoAdmision, _
                    '                                                objP.NumeroAdmision, objIncapacidad, True)
                    Dim objDatosGenerales As objGenerales.Generales

                    objDatosGenerales = objGenerales.Generales.Instancia

                    If objDatosGenerales.Pais = "482" Or objDatosGenerales.Pais = "484" Then ''Peru ó Venezuela
                        frmRepPlanIncapacidad.Show()
                        frmRepPlanIncapacidad.imprimirRepPlanIncapacidad(_datosConexion, .Cells("cod_pre_sgs").Value, .Cells("cod_sucur").Value,
                                                .Cells("tip_doc").Value, .Cells("num_doc").Value,
                                                .Cells("tip_admision").Value, .Cells("ano_adm").Value,
                                                .Cells("num_adm").Value, objIncapacidad, True)
                    Else
                        '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
                        'Juan Carlos Jaramillo Lozano - IG
                        RptHC_Enf_Med.Show()
                        RptHC_Enf_Med.ImprimirHistoriaClinica_imprimirIncapacidad(_datosConexion, "71", .Cells("cod_pre_sgs").Value,
                                                                              .Cells("cod_sucur").Value, .Cells("tip_doc").Value,
                                                                              .Cells("num_doc").Value, .Cells("tip_admision").Value,
                                                                              .Cells("ano_adm").Value, .Cells("num_adm").Value,
                                                                                  objP.CodHistoria)
                        '2019-03-11 Fin
                    End If

                ElseIf seccionesAdicionales.Formula Then
                    objP.TipoDocumento = .Cells("tip_doc").Value
                    objP.NumeroDocumento = .Cells("num_doc").Value
                    objP.TipoAdmision = .Cells("tip_admision").Value
                    objP.AnoAdmision = .Cells("ano_adm").Value
                    objP.NumeroAdmision = .Cells("num_adm").Value
                    Dim objDatosGenerales As objGenerales.Generales

                    objDatosGenerales = objGenerales.Generales.Instancia

                    Dim Origen As String = objDatosGenerales.OrigenAdm

                    dtEntidad = objConseguirDatosS.ConsultarTablasBasicas(Origen & "genentid", _datosConexion, "descripcion,man_conv_med,tip_usuario", "entidad='" & .Cells("entidad").Value.ToString & "'")
                    If dtEntidad.Rows.Count > 0 Then
                        strTipoUsuario = dtEntidad.Rows(0).Item("tip_usuario").ToString
                    End If

                    If objDatosGenerales.Pais = "482" Or objDatosGenerales.Pais = "484" Then ''Peru ó Venezuela
                        frmRepFormuMedica.Show()
                        frmRepFormuMedica.imprimirFormulaMedica(_datosConexion, .Cells("cod_pre_sgs").Value,
                                                                .Cells("cod_sucur").Value, objP.TipoAdmision,
                                                            objP.AnoAdmision, objP.NumeroAdmision, CInt(cboFormula.Text), True, strTipoUsuario)
                    Else
                        '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
                        'Juan Carlos Jaramillo Lozano - IG
                        RptHC_Enf_Med.Show()
                        RptHC_Enf_Med.ImprimirHistoriaClinica_imprimirFormulaMedica(_datosConexion, "65", .Cells("cod_pre_sgs").Value,
                                                                                .Cells("cod_sucur").Value, objP.TipoAdmision,
                                                                                objP.AnoAdmision, objP.NumeroAdmision,
                                                                            CInt(cboFormula.Text), True, strTipoUsuario, objP.CodHistoria)
                        '2019-03-11 Fin
                    End If



                    'jlalfonso- 2009-02-03
                    'reimprimir procedimientos externos
                ElseIf seccionesAdicionales.ProcedimExt Then
                    Dim objDatosGenerales As objGenerales.Generales
                    objDatosGenerales = objGenerales.Generales.Instancia

                    If cboProcedimExt.Text = "" Then
                        cboProcedimExt.Text = 0
                    End If

                    If objDatosGenerales.Pais = "482" Then ''Peru 
                        frmRepFormulaProcedim.Show()
                        frmRepFormulaProcedim.imprimirFormulaProcedim(_datosConexion, .Cells("cod_pre_sgs").Value, .Cells("cod_sucur").Value,
                                                                    .Cells("tip_admision").Value, .Cells("ano_adm").Value,
                                                                    .Cells("num_adm").Value, CDbl(cboProcedimExt.Text), True, False)
                    Else
                        '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
                        'Juan Carlos Jaramillo Lozano - IG
                        RptHC_Enf_Med.Show()
                        RptHC_Enf_Med.ImprimirHistoriaClinica_Procedimientos_externos(_datosConexion, "69", .Cells("cod_pre_sgs").Value,
                                                                                  .Cells("cod_sucur").Value, .Cells("tip_admision").Value,
                                                                                  .Cells("ano_adm").Value, .Cells("num_adm").Value,
                                                                                  True, False, CDbl(cboProcedimExt.Text), objP.CodHistoria)
                        '2019-03-11 Fin
                    End If

                ElseIf seccionesAdicionales.IdentificadorRiesgo Then

                    Try

                        Dim rpt As RptHC = New RptHC()


                        rpt.ImprimirHistoricoIdentificadorRiesgo(_datosConexion, .Cells("tip_doc").Value, .Cells("num_doc").Value, .Cells("cod_pre_sgs").Value,
                                                                 .Cells("cod_sucur").Value, .Cells("tip_admision").Value, .Cells("ano_adm").Value,
                                                                 .Cells("num_adm").Value, objP.CodHistoria,
                                                                 fec_ini, fec_fin, _datosGenerales.NombreMedico)


                        rpt.ShowDialog()
                        rpt.Close()
                        seccionesAdicionales.IdentificadorRiesgo = False
                    Catch ex As Exception
                        MsgBox("Error al imprimir el reporte :" + " " + ex.Message, MsgBoxStyle.Critical)
                    End Try
                End If

            End If
            If seccionesAdicionales.IdentificadorRiesgo Then

                Try 'Req 651 20181128 rcruzr

                    Dim rpt As RptHC = New RptHC()


                    rpt.ImprimirHistoricoIdentificadorRiesgo(_datosConexion, .Cells("tip_doc").Value, .Cells("num_doc").Value, .Cells("cod_pre_sgs").Value,
                                                             .Cells("cod_sucur").Value, .Cells("tip_admision").Value, .Cells("ano_adm").Value,
                                                             .Cells("num_adm").Value, objP.CodHistoria,
                                                             fec_ini, fec_fin, _datosGenerales.NombreMedico)


                    rpt.ShowDialog()
                    rpt.Close()
                Catch ex As Exception
                    MsgBox("Error al imprimir el reporte :" + " " + ex.Message, MsgBoxStyle.Critical)
                End Try

            End If

            ''p

        End With

    End Sub

    Public Function cargarOpcionesImpresion() As Secciones
        Dim seccionesAdicionales As New Secciones

        With seccionesAdicionales
            .Remision = ckRemision.Checked
            .Recomendaciones = ckRecomendacion.Checked
            .Triage = ckTriage.Checked
            .Todas = ckTodos.Checked
            .Incapacidad = ckIncapacidad.Checked
            .Formula = ckFormula.Checked
            .ProcedimExt = ckProcedimientosExt.Checked
            .DescripcionQx = chkDescripcion.Checked
            .IdentificadorRiesgo = chkHistIdentRiesgo1.Checked
        End With

        Return seccionesAdicionales
    End Function

    Public Sub configurarGrilla()
        'dtgAdmisiones.AutoGenerateColumns = False
        With dtgAdmisiones
            '' .Columns("estado").Width = 60  ''Claudia Garay 08 junio 2010
            .Columns("cod_pre_sgs").Visible = False
            .Columns("cod_sucur").Visible = False
            .Columns("tip_hc").Visible = False
            .Columns("hor_hc").Visible = False
            .Columns("min_hc").Visible = False
            .Columns("tip_doc").Visible = False
            .Columns("num_doc").Visible = False
            .Columns("reg_med").Visible = False
            .Columns("id_med").Visible = False
            'Columns("sucursal").Visible = False
            .Columns("direccion").Visible = False
            .Columns("telefono").Visible = False
            .Columns("edad").Visible = False
            .Columns("Entidad").Visible = False
            .Columns("IDLOCALIZACION").Visible = False
            .Columns("LINKED_SERVER").Visible = False

        End With
    End Sub

    Private Sub dtgAdmisiones_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgAdmisiones.CellClick
        Dim listaNotas As List(Of Nota)
        Dim strNotas As New StringBuilder

        txtNota.Visible = False
        txtNota.Text = ""

        If grillaVacia(dtgAdmisiones) Then
            Exit Sub
        End If

        If _datosGenerales Is Nothing Then
            Exit Sub
        End If

        'martovar 2014-10-17 al seleccionar una nueva admision limpie la grilla
        chkDescripcion.Checked = False
        dtgProcedim.DataSource = Nothing

        'Inicio 20210409 Req Datos Sensibles HC, desarrollado por Raul Cruz
        If dtgAdmisiones.CurrentRow.Cells("LINKED_SERVER").Value.ToString <> "" Then
            'Se cambia por la que se trae en la grilla.
            _datosGenerales.OrigenAdm = dtgAdmisiones.CurrentRow.Cells("LINKED_SERVER").Value.ToString
        Else
            _datosGenerales.OrigenAdm = _OrigenAdm 'se deja con la inicial que carga la aplicación
        End If
        'Fin 20210409 Req Datos Sensibles HC, desarrollado por Raul Cruz


        With dtgAdmisiones.CurrentRow
            If Len(.Cells("tip_admision").Value) <> 0 And Len(.Cells("ano_adm").Value) <> 0 And Len(.Cells("num_adm").Value) <> 0 Then
                listaNotas = Nota.consultarNotas(_datosConexion, .Cells("cod_pre_sgs").Value, .Cells("cod_sucur").Value,
                                                .Cells("tip_admision").Value, .Cells("ano_adm").Value,
                                                .Cells("num_adm").Value)

                For Each objNota As Nota In listaNotas
                    'txtNota.Text = txtNota.Text & "Fecha Nota: " & objNota.Fecha & " Hora: " & objNota.Hora & vbCrLf & objNota.Descripcion
                    strNotas.Append("Fecha Nota: " & objNota.Fecha & " Hora: " & objNota.Hora & vbCrLf & objNota.Descripcion)
                Next
                '2009-02-02 
                'jlalfonso   carga formulas medicas de admision
                CargarNumFormulas()
                CargarProcedExt()

                txtNota.Text = ""
                txtNota.AppendText(strNotas.ToString)

                If listaNotas.Count > 0 Then
                    txtNota.Visible = True
                End If
            End If
        End With

    End Sub

    Private Sub dtgAdmisiones_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgAdmisiones.CellEnter
        dtgAdmisiones_CellClick(sender, e)
    End Sub

    Public Function grillaVacia(ByVal grilla As DataGridView) As Boolean
        Dim source As DataTable
        source = grilla.DataSource
        If source Is Nothing Then
            Return True
        ElseIf source.Rows.Count = 0 Then
            Return True
        End If

        Return False
    End Function

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        LimpiarPantalla(GroupBox2, TLimpiar.tlTodos)
        LimpiarPantalla(Me, TLimpiar.tlTodos)
        LimpiarDataGrid(dtgAdmisiones)
    End Sub

    Public Enum TLimpiar
        tlTodos = 0
        tlActivos = 1
        tlInactivos = 2
    End Enum

    Public Shared Sub LimpiarPantalla(ByVal Forma As Object, Optional ByVal TipoLimpiar As TLimpiar = TLimpiar.tlTodos)
        Dim cControl As Control

        For Each cControl In Forma.Controls
            If TypeOf cControl Is TextBox Or TypeOf cControl Is CheckBox Or TypeOf cControl Is MaskedTextBox Then
                If TipoLimpiar = TLimpiar.tlTodos Or (TipoLimpiar = TLimpiar.tlActivos And cControl.Enabled) Or
                                        (TipoLimpiar = TLimpiar.tlInactivos And Not cControl.Enabled) Then
                    If TypeOf cControl Is TextBox Then
                        Dim ctlTextBox As TextBox
                        ctlTextBox = cControl
                        ctlTextBox.Text = ""
                    ElseIf TypeOf cControl Is CheckBox Then
                        Dim ctlRadioButton As CheckBox
                        ctlRadioButton = cControl
                        ctlRadioButton.Checked = False
                    ElseIf TypeOf cControl Is MaskedTextBox Then
                        Dim ctlMaskedTextBox As MaskedTextBox
                        ctlMaskedTextBox = cControl
                        ctlMaskedTextBox.Clear()
                    End If
                End If
            End If
        Next cControl
    End Sub

    Private Sub mskFechaDesde_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mskFechaDesde.Validating
        If mskFechaDesde.Text <> "  /  /" Then
            If Not IsDate(mskFechaDesde.Text) Then

                MsgBox("Fecha invalida. Debe digitar una fecha valida.", MsgBoxStyle.Information)
                e.Cancel = True
                mskFechaDesde.Select(0, mskFechaDesde.TextLength)
            End If
        End If
    End Sub

    Private Sub mskFechaHasta_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mskFechaHasta.Validating
        If mskFechaHasta.Text <> "  /  /" Then
            If Not IsDate(mskFechaHasta.Text) Then
                MsgBox("Fecha invalida. Debe digitar una fecha valida.", MsgBoxStyle.Information)
                e.Cancel = True
                mskFechaHasta.Select(0, mskFechaDesde.TextLength)
            Else
                If Not CDate(mskFechaHasta.Text) >= CDate(mskFechaDesde.Text) Then
                    MsgBox("Fecha invalida. Debe digitar una fecha valida.", MsgBoxStyle.Information)
                    e.Cancel = True
                    mskFechaHasta.Select(0, mskFechaDesde.TextLength)
                End If
            End If
        End If
    End Sub

    Public Shared Sub ValidaKeyPress(ByRef MyControl As Control, ByVal s As KeyPressEventArgs)
        If Len(MyControl.Tag) > 0 Then
            If Mid(MyControl.Tag, 1, 1) = "N" Then
                If Not Regex.IsMatch(s.KeyChar, "[0-9]") Then
                    s.Handled = True
                End If
            ElseIf Mid(MyControl.Tag, 1, 1) = "L" Then
                If Not Regex.IsMatch(s.KeyChar, "[a-zA-Z]") Then
                    s.Handled = True
                End If
            Else
                s.Handled = True
            End If
        End If

        Select Case s.KeyChar
            Case Convert.ToChar(Keys.Return)
                SendKeys.Send("{TAB}")
                s.Handled = True
        End Select
    End Sub

    Private Sub LimpiarDataGrid(ByVal dtg As DataGridView)
        For i As Integer = 0 To dtg.Rows.Count - 1
            dtg.Rows.Remove(Me.dtgAdmisiones.Rows(0))
        Next i
    End Sub

    Private Sub ckTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckTodos.CheckedChanged
        If ckTodos.Checked = True Then
            'Desactivar Check de conciliacion INDRA/FABAICUE 23/04/2022.
            chkConciliacionMed.Checked = False

            ckHCBasica.Checked = True
            ckRemision.Checked = True
            ckRecomendacion.Checked = True
            ckTriage.Checked = True
            ckFormula.Checked = True
            ckProcedimientosExt.Checked = True
            chkResumenEgreso.Checked = False
            ckIncapacidad.Checked = True

        Else
            ckHCBasica.Checked = False
            ckRemision.Checked = False
            ckRecomendacion.Checked = False
            ckTriage.Checked = False
            ckFormula.Checked = False
            ckProcedimientosExt.Checked = False
            ckIncapacidad.Checked = False
        End If
    End Sub

    Private Sub chkResumenEgreso_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkResumenEgreso.CheckedChanged
        If chkResumenEgreso.Checked = True Then
            'Desactivar Check de conciliacion INDRA/FABAICUE 23/04/2022.
            chkConciliacionMed.Checked = False

            ckHCBasica.Checked = False
            ckRemision.Checked = False
            ckRecomendacion.Checked = False
            ckTriage.Checked = False
            'ckIncapacidad.Checked = False
            ckFormula.Checked = False
            ckProcedimientosExt.Checked = False
            'ckTodos.Checked = False
        End If
    End Sub

    Private Sub ckHCBasica_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckHCBasica.CheckedChanged
        If ckHCBasica.Checked Then
            'Desactivar Check de conciliacion INDRA/FABAICUE 23/04/2022.
            chkConciliacionMed.Checked = False

            chkResumenEgreso.Checked = False
            ckHCBasicaSinAnte.Checked = False
            chkDescripcion.Checked = False
        Else
            'ckTodos.Checked = False
        End If
    End Sub

    Private Sub ckRemision_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckRemision.CheckedChanged
        If ckRemision.Checked Then
            'Desactivar Check de conciliacion INDRA/FABAICUE 23/04/2022.
            chkConciliacionMed.Checked = False

            'ckHCBasica.Checked = False
        Else
            'ckTodos.Checked = False
        End If
    End Sub

    Private Sub ckRecomendacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckRecomendacion.CheckedChanged
        If ckRecomendacion.Checked Then
            'Desactivar Check de conciliacion INDRA/FABAICUE 23/04/2022.
            chkConciliacionMed.Checked = False

            'ckHCBasica.Checked = False
        Else
            'ckTodos.Checked = False
        End If
    End Sub

    Private Sub ckTriage_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckTriage.CheckedChanged
        If ckTriage.Checked Then
            'Desactivar Check de conciliacion INDRA/FABAICUE 23/04/2022.
            chkConciliacionMed.Checked = False

            'ckHCBasica.Checked = False
        Else
            'ckTodos.Checked = False
        End If
    End Sub

    Private Sub ckIncapacidad_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckIncapacidad.CheckedChanged
        If ckIncapacidad.Checked Then
            'Desactivar Check de conciliacion INDRA/FABAICUE 23/04/2022.
            chkConciliacionMed.Checked = False

            ' ckHCBasica.Checked = False
        Else
            'ckIncapacidad.Checked = False
        End If
    End Sub
    Private Sub ckFormula_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckFormula.CheckedChanged
        If ckFormula.Checked Then
            'Desactivar Check de conciliacion INDRA/FABAICUE 23/04/2022.
            chkConciliacionMed.Checked = False

            'ckHCBasica.Checked = False
            If cboFormula.Items.Count <= 0 Then
                MsgBox("No hay Registros de formulacion para seleccionar.", MsgBoxStyle.Information)
                ckFormula.Checked = False
            End If
        Else
            ckFormula.Checked = False
        End If
    End Sub

    Private Sub ckProcedimientosExt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckProcedimientosExt.CheckedChanged
        If ckProcedimientosExt.Checked Then
            'Desactivar Check de conciliacion INDRA/FABAICUE 23/04/2022.
            chkConciliacionMed.Checked = False

            'ckHCBasica.Checked = False
            If cboProcedimExt.Items.Count <= 0 Then
                MsgBox("No hay Registros de procedimientos para seleccionar.", MsgBoxStyle.Information)
                ckProcedimientosExt.Checked = False
            End If
        Else
            ckProcedimientosExt.Checked = False
        End If
    End Sub
    Public Sub CargarNumFormulas()

        Dim dtdatos As New DataTable
        Dim objConseguirDatosS As New BLHistoriaBasica

        Dim OrigenBD As String
        Dim objDatosGenerales As objGenerales.Generales
        objDatosGenerales = objGenerales.Generales.Instancia

        OrigenBD = objDatosGenerales.OrigenAdm
        Try
            cboFormula.BeginUpdate()
            With dtgAdmisiones.CurrentRow
                dtdatos = objConseguirDatosS.ConsultarTablasBasicas(OrigenBD & "carformu", _datosConexion, " distinct nro_formula", "cod_pre_sgs='" _
                                    & .Cells("cod_pre_sgs").Value & "' and cod_sucur= '" & .Cells("cod_sucur").Value & "' and tip_admision= '" _
                                    & .Cells("tip_admision").Value & "' and ano_adm= " & .Cells("ano_adm").Value & " and num_adm= " & .Cells("num_adm").Value & " ")


            End With

            If dtdatos.Rows.Count > 0 Then
                cboFormula.DataSource = dtdatos
                cboFormula.DisplayMember = "nro_formula"
                cboFormula.ValueMember = "nro_formula"
                cboFormula.EndUpdate()
            Else
                cboFormula.DataSource = dtdatos
                cboFormula.DisplayMember = ""
                cboFormula.ValueMember = ""
                cboFormula.EndUpdate()
            End If



        Catch ex As Exception
            MsgBox("Error al consultar Formulación Externa.", MsgBoxStyle.Information)
        End Try

    End Sub
    Public Sub CargarProcedExt()

        Dim dtdatos As New DataTable
        Dim objConseguirDatosS As New BLHistoriaBasica
        Dim OrigenBD As String
        Dim objDatosGenerales As objGenerales.Generales
        objDatosGenerales = objGenerales.Generales.Instancia

        OrigenBD = objDatosGenerales.OrigenAdm

        Try
            cboProcedimExt.BeginUpdate()
            With dtgAdmisiones.CurrentRow
                dtdatos = objConseguirDatosS.ConsultarTablasBasicas(OrigenBD & "carforpro", _datosConexion, " distinct con_procedim", "cod_pre_sgs='" _
                                    & .Cells("cod_pre_sgs").Value & "' and cod_sucur= '" & .Cells("cod_sucur").Value & "' and tip_admision= '" _
                                    & .Cells("tip_admision").Value & "' and ano_adm= " & .Cells("ano_adm").Value & " and num_adm= " & .Cells("num_adm").Value & " ")


            End With

            If dtdatos.Rows.Count > 0 Then
                cboProcedimExt.DataSource = dtdatos
                cboProcedimExt.DisplayMember = "con_procedim"
                cboProcedimExt.ValueMember = "con_procedim"
                cboProcedimExt.EndUpdate()
            Else
                cboProcedimExt.DataSource = dtdatos
                cboProcedimExt.DisplayMember = ""
                cboProcedimExt.ValueMember = ""
                cboProcedimExt.EndUpdate()
            End If



        Catch ex As Exception
            MsgBox("Error al consultar Procedimientos Externos.", MsgBoxStyle.Information)
        End Try

    End Sub


#Region "Consulta Para Identificar Error en Examen Fisico"
    '**HDCPCEF (Habilitar - Deshabilitar Código Para Corrección Examen Fisico**
    Private Function ConsultarAdmisionesConEF_Errado(ByVal strPrestador As String, ByVal strSucursal As String, ByVal strTipoDocumento As String,
                                                     ByVal strNumeroDocumento As String, ByVal strTipoAdmision As String, ByVal intAnoAdmision As Double,
                                                     ByVal dblNumeroAdmision As Double, ByVal dteFechaHC As Date, ByVal strLogin As String, ByRef strTipoAcceso As String) As Boolean

        Dim objDAOGeneral As New Sophia.HistoriaClinica.DAO.DAOGeneral
        Dim dtDatos As DataTable
        Dim strCondicion As String
        Dim blnRespuesta As Boolean = False
        Dim dtRows() As DataRow
        Dim intOrden As Integer
        Dim dtRow As DataRow
        Dim blnAdmisionExiste As Boolean = False


        'strCondicion = "cod_pre_sgs='" & strPrestador & "' AND cod_sucur='" & strSucursal & "' AND " & _
        '               "tip_doc='" & strTipoDocumento & "' AND " & _
        '               "num_doc='" & strNumeroDocumento & "' AND tip_admision='" & strTipoAdmision & "' AND " & _
        '               "ano_adm=" & intAnoAdmision & " AND num_adm=" & dblNumeroAdmision & " AND estado='E'"

        If strLogin.Trim = _datosGenerales.Login.Trim Then
            strCondicion = "cod_pre_sgs='" & strPrestador & "' AND cod_sucur='" & strSucursal & "' AND " &
                           "tip_doc='" & strTipoDocumento & "' AND " &
                           "num_doc='" & strNumeroDocumento & "' AND login='" & _datosGenerales.Login & "' AND estado='E'"
        Else
            If _datosGenerales.MedicoRealizaCorreccion = "T" Then
                strCondicion = "cod_pre_sgs='" & strPrestador & "' AND cod_sucur='" & strSucursal & "' AND " &
                               "tip_doc='" & strTipoDocumento & "' AND " &
                               "num_doc='" & strNumeroDocumento & "' AND estado='E'"
            Else
                strCondicion = "cod_pre_sgs='" & strPrestador & "' AND cod_sucur='" & strSucursal & "' AND " &
                               "tip_doc='" & strTipoDocumento & "' AND " &
                               "num_doc='" & strNumeroDocumento & "' AND tip_admision='" & strTipoAdmision & "' AND ano_adm=" & intAnoAdmision &
                               " AND num_adm=" & dblNumeroAdmision & "AND login='" & strLogin & "' AND estado='E'"
            End If

        End If

        dtDatos = objDAOGeneral.EjecutarSQLConParametros("hcCorreccion WITH (NOLOCK)", _datosConexion, "cod_pre_sgs, cod_sucur, tip_admision, ano_adm, num_adm, tip_doc, num_doc, login_egreso, estado, fec_hc, fec_con, '" & _datosGenerales.Login & "' as login, obs, 0 as Orden, login as login_original", strCondicion)

        If dtDatos.Rows.Count > 0 Then
            blnRespuesta = True
            For intOrden = 0 To dtDatos.Rows.Count - 1
                If dtDatos.Rows(intOrden).Item("tip_admision") = strTipoAdmision And
                       dtDatos.Rows(intOrden).Item("ano_adm") = intAnoAdmision And
                       dtDatos.Rows(intOrden).Item("num_adm") = dblNumeroAdmision Then
                    dtDatos.Rows(intOrden).Item("orden") = 1
                    blnAdmisionExiste = True
                Else
                    If Month(dtDatos.Rows(intOrden).Item("fec_hc")) = Month(dteFechaHC) Then
                        dtDatos.Rows(intOrden).Item("orden") = 2
                    Else
                        dtDatos.Rows(intOrden).Item("orden") = 3
                    End If
                End If
            Next
            dtDatos.DefaultView.Sort = "Orden ASC, fec_hc ASC"

            If (strLogin.Trim = _datosGenerales.Login.Trim) Or (_datosGenerales.MedicoRealizaCorreccion = "T" AndAlso blnAdmisionExiste = True) Then
                Dim objPaciente As Sophia.HistoriaClinica.DatosPaciente.Paciente
                objPaciente = Sophia.HistoriaClinica.DatosPaciente.Paciente.Instancia
                objPaciente.HistoriasConErroresEF = dtDatos.DefaultView.ToTable
                strTipoAcceso = "M"
            Else
                If _datosGenerales.MedicoRealizaCorreccion <> "T" Then
                    strTipoAcceso = "N"
                Else
                    blnRespuesta = blnAdmisionExiste
                End If
            End If
        End If


        'blnRespuesta = dtDatos.Rows.Count > 0

        Return blnRespuesta

    End Function
    '**/
#End Region

    Private Sub ckHCBasicaSinAnte_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckHCBasicaSinAnte.CheckedChanged
        If ckHCBasicaSinAnte.Checked = True Then
            'Desactivar Check de conciliacion INDRA/FABAICUE 23/04/2022.
            chkConciliacionMed.Checked = False

            ckHCBasica.Checked = False
        End If
    End Sub

    Private Sub rbImpEnf_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbImpEnf.CheckedChanged
        Dim objPaciente As HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente.Paciente
        'Dim objPaciente As Paciente
        Dim dtgPacientes As DataGridView
        Dim controlListaEspera As ListaEspera
        ' Dim DatosPac As New ListaEspera

        ''Validacion de los parametros de entrada suministrador por sophia
        If _datosGenerales Is Nothing Then
            MsgBox("No existen parametros de entrada.", MsgBoxStyle.Information)
            Exit Sub
        End If
        frmConsultaHCEnfermeriaAlejo.Dispose()
        Me.Close()
        Me.Visible = False
        ''Se obtiene el control Activo del contenedor de datos
        'controlListaEspera = pnlContenedorListaEspera.Controls("ListaEspera")
        controlListaEspera = ListaEspera.Instancia

        ''Si el control activo es la lista de espera
        If Not controlListaEspera Is Nothing Then
            dtgPacientes = controlListaEspera.dtgLista

            If dtgPacientes.CurrentRow Is Nothing Then

                If controlListaEspera.DatosBasicosPac.Count > 0 Then
                    frmConsultaHCEnfermeriaAlejo.mostrar(controlListaEspera.DatosBasicosPac(1), controlListaEspera.DatosBasicosPac(0))
                    Me.Dispose(True)
                    Exit Sub
                Else
                    If controlListaEspera.txtCodigoTipoDocumento.Text.Trim <> "" And controlListaEspera.txtNumeroDocumento.Text.Trim <> "" Then
                        frmConsultaHCEnfermeriaAlejo.mostrar(controlListaEspera.txtCodigoTipoDocumento.Text.Trim, controlListaEspera.txtNumeroDocumento.Text.Trim)
                        Me.Dispose(True)
                        Exit Sub
                    Else
                        frmConsultaHCEnfermeriaAlejo.ShowDialog()
                        Me.Dispose(True)
                        Exit Sub
                    End If
                End If
            End If
            With dtgPacientes.CurrentRow
                If Len(.Cells("nombre").Value.ToString.Trim) <= 0 Then
                    frmConsultaHCEnfermeriaAlejo.ShowDialog()
                    frmConsultaHCEnfermeriaAlejo.Close()
                Else
                    If controlListaEspera.DatosBasicosPac.Count > 0 Then

                        frmConsultaHCEnfermeriaAlejo.mostrar(controlListaEspera.DatosBasicosPac(1), controlListaEspera.DatosBasicosPac(0))
                    Else
                        frmConsultaHCEnfermeriaAlejo.mostrar(.Cells("tip_doc").Value, .Cells("num_doc").Value)
                    End If
                End If
            End With
        Else
            objPaciente = HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente.Paciente.Instancia()
            If Not objPaciente Is Nothing Then
                frmConsultaHCEnfermeriaAlejo.mostrar(objP.TipoDocumento, objP.NumeroDocumento)
            End If
        End If
        Me.Dispose(True)

    End Sub

    Private Sub btDispensacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDispensacion.Click
        Try
            If Len(tbCodigoTipDoc.Text) <> 0 Or Len(txtNumDoc.Text) <> 0 Then
                frmDispMedicamentos.mostrar(tbCodigoTipDoc.Text, txtNumDoc.Text)
                'frmDispMedicamentos.mostrar("CC", "51902085")
            Else
                MessageBox.Show("Datos Incompletos")
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim objDAOOrden As New Sophia.HistoriaClinica.DAO.DAOOrdenes
        Dim dtdatos As New DataTable

        If dtgAdmisiones.DataSource Is Nothing Then
            Exit Sub
        End If

        With dtgAdmisiones.CurrentRow
            'dtdatos = objDAOOrden.ConsultaOrdenesConExcepcion(.Cells("cod_pre_sgs").Value, .Cells("cod_sucur").Value, .Cells("tip_admision").Value, _
            '.Cells("num_adm").Value, .Cells("ano_adm").Value)

            If dtdatos.Rows.Count = 0 Then
                MsgBox("No exiten datos para esta consulta")
                Exit Sub
            End If

            'Dim frmexcepcion As New frmc_ExcepcionesConsulta(dtdatos, .Cells("num_doc").Value, .Cells("tip_doc").Value)

            'frmexcepcion.ShowDialog()


        End With



    End Sub

    ''cpgaray Auditoria de Impresion de Historias Medicas 23 de Julio 2012
    Private Sub GrabarAuditoriaConsultaHC(ByVal strPrestador As String, ByVal strSucursal As String, ByVal strTipAdmision As String,
                                          ByVal intanoadm As Integer, ByVal DnumAdm As Double, ByVal strPaciente As String, ByVal strMedico As String)
        Dim objDAOOrden As New Sophia.HistoriaClinica.DAO.DAOOrdenes
        Dim intError As Integer = 0

        intError = objDAOOrden.GrabarAuditOrdenes(_datosConexion, strPrestador, strSucursal, strTipAdmision, intanoadm, DnumAdm, strPaciente, strMedico, 0, 0, 0, 0, 0, "ConsultaMedico", "")

    End Sub

    Private Sub chkDescripcion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDescripcion.CheckedChanged

        dtgProcedim.DataSource = Nothing

        If chkDescripcion.Checked = True Then
            'Desactivar Check de conciliacion INDRA/FABAICUE 23/04/2022.
            chkConciliacionMed.Checked = False

            ckHCBasica.Checked = False
            If (MsgBox("¿Desea Consultar los procedimientos programados para la admisión?", MsgBoxStyle.OkCancel)) = MsgBoxResult.Ok Then
                MostrarProcedimientos()
            End If
        Else
            dtgProcedim.DataSource = Nothing
        End If


    End Sub
    Private Sub MostrarProcedimientos()
        Dim objDescripcion As New Sophia.HistoriaClinica.DAO.DAODescripcionQX
        Dim dt As New DataTable

        'Inicio 20210409 Req Datos Sensibles HC, desarrollado por Raul Cruz
        If dtgAdmisiones.CurrentRow.Cells("LINKED_SERVER").Value.ToString <> "" Then
            'Se cambia por la que se trae en la grilla.
            _datosGenerales.OrigenAdm = dtgAdmisiones.CurrentRow.Cells("LINKED_SERVER").Value.ToString
        Else
            _datosGenerales.OrigenAdm = _OrigenAdm 'se deja con la inicial que carga la aplicación
        End If
        'Fin 20210409 Req Datos Sensibles HC, desarrollado por Raul Cruz

        With dtgAdmisiones.CurrentRow
            'dt = objDescripcion.ConsultarProcedimientosXAdmision(.Cells("cod_pre_sgs").Value, .Cells("cod_sucur").Value, .Cells("tip_doc").Value, .Cells("num_doc").Value, .Cells("tip_admision").Value, .Cells("ano_adm").Value, .Cells("num_adm").Value)
            'martovar  2014-08-08 Req. 03 Version 2.9.0 descripcion quirurgica
            dt = objDescripcion.ConsultarProcedimientosXAdmision(.Cells("cod_pre_sgs").Value, .Cells("cod_sucur").Value, .Cells("tip_doc").Value, .Cells("num_doc").Value, .Cells("tip_admision").Value, .Cells("ano_adm").Value, .Cells("num_adm").Value, 0)
            If dt.Rows.Count = 0 Then
                MsgBox("No existen procedimientos programados para esta admisión")
                chkDescripcion.Checked = False

                Exit Sub
            Else
                ConfigurarGrillaProcedim(dt)
                dtvalores = dt
                dtgProcedim.CurrentCell = dtgProcedim.Rows(0).Cells(1)
            End If
        End With

        'HCDescripcionQX_TraerProcedimientos
    End Sub
    Private Sub ConfigurarGrillaProcedim(ByVal dt As DataTable)

        With dtgProcedim
            .DataSource = dt
            .Columns("Consecutivo").Visible = False
            .Columns("FechaInicio").Visible = False
            .Columns("HoraInicio").Visible = False
            .Columns("MinutoInicio").Visible = False
            .Columns("FechaFinal").Visible = False
            .Columns("HoraFinal").Visible = False
            .Columns("MinutoFinal").Visible = False
            .Columns("TiempoQX").Visible = False
            .Columns("tip_anestesia").Visible = False
            .Columns("Anestesia").Visible = False
            .Columns("bilateral").Visible = False
            .Columns("secuencia").Visible = False
            .Columns("estado").Visible = False
            .Columns("procedimiento").Width = 100
            .Columns("descripcion").Width = 335
            .Columns.Item("cod_permedas").Visible = False
        End With
    End Sub

    Private Sub dtgProcedim_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgProcedim.CellDoubleClick
        ImprimirDescripcionQX()
    End Sub

    Private Sub ImprimirDescripcionQX()
        Dim frmRepDescr As New frmRepDescripcionQX
        Dim objDatosGenerales As objGenerales.Generales
        'Dim objP1 As objPaciente '= objPaciente.Instancia

        'objP1 = objPaciente.Instancia

        '_paciente.TipoDocumento.ToString()
        objDatosGenerales = objGenerales.Generales.Instancia

        If objDatosGenerales.Pais = "482" Then ''Peru 
            frmRepDescr.imprimirDescripcionQuirurgica(_datosConexion, _datosGenerales.Prestador,
                                                      _datosGenerales.Sucursal,
                                                      dtgProcedim.CurrentRow.Cells("Procedimiento").Value,
                                                      dtgProcedim.CurrentRow.Cells("Consecutivo").Value,
                                                      dtgProcedim.CurrentRow.Cells("Consecutivo").Value,
                                                      dtgAdmisiones.CurrentRow.Cells("tip_admision").Value,
                                                      dtgAdmisiones.CurrentRow.Cells("ano_adm").Value,
                                                      dtgAdmisiones.CurrentRow.Cells("num_adm").Value)
            frmRepDescr.Show()
        Else
            '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
            'Juan Carlos Jaramillo Lozano - IG
            RptHC_Enf_Med.Show()
            RptHC_Enf_Med.ImprimirHistoriaClinica_imprimirQuirurjico(_datosConexion, "80", dtgAdmisiones.CurrentRow.Cells("cod_pre_sgs").Value,
                                                                   dtgAdmisiones.CurrentRow.Cells("cod_sucur").Value,
                                                                     dtgProcedim.CurrentRow.Cells("Procedimiento").Value,
                                                                     dtgProcedim.CurrentRow.Cells("Consecutivo").Value,
                                                                     dtgProcedim.CurrentRow.Cells("secuencia").Value,
                                                                     dtgAdmisiones.CurrentRow.Cells("tip_admision").Value,
                                                                    dtgAdmisiones.CurrentRow.Cells("ano_adm").Value,
                                                                     dtgAdmisiones.CurrentRow.Cells("num_adm").Value,
                                                                    _paciente.TipoDocumento.ToString(), _paciente.NumeroDocumento.ToString(),
                                                                     objP.CodHistoria
                                                                    )
            '2019-03-11 Fin
        End If

    End Sub

    'Private Sub ImprimirDescripcionQX()
    '    Dim frmRepDescr As New frmRepDescripcionQX
    '    frmRepDescr.imprimirDescripcionQuirurgica(_datosConexion, _datosGenerales.Prestador, _datosGenerales.Sucursal,
    '     dtgProcedim.CurrentRow.Cells("Procedimiento").Value, dtgProcedim.CurrentRow.Cells("Consecutivo").Value, dtgProcedim.CurrentRow.Cells("Consecutivo").Value, dtgAdmisiones.CurrentRow.Cells("tip_admision").Value, dtgAdmisiones.CurrentRow.Cells("ano_adm").Value, dtgAdmisiones.CurrentRow.Cells("num_adm").Value)
    '    frmRepDescr.Show()
    'End Sub
    Private Sub rbImpMed_CheckedChanged(sender As Object, e As EventArgs) Handles rbImpMed.CheckedChanged

    End Sub

    'Private Sub chkCuidadosPaliativos_CheckedChanged(sender As Object, e As EventArgs) Handles chkCuidadosPaliativos.CheckedChanged
    'If ckHCBasica.Checked Then
    '       ckHCBasica.Checked = False

    'End If
    'End Sub

    Private Sub chkConciliacionMed_CheckedChanged(sender As Object, e As EventArgs) Handles chkConciliacionMed.CheckedChanged
        'Se desmarcan todos los checks al selecionar el de conciliacion INDRA/FABAICUE 22/03/2022.
        If chkConciliacionMed.Checked = True Then
            ckHCBasica.Checked = False
            ckHCBasicaSinAnte.Checked = False
            ckRemision.Checked = False
            ckRecomendacion.Checked = False
            ckTriage.Checked = False
            ckIncapacidad.Checked = False
            ckFormula.Checked = False
            ckProcedimientosExt.Checked = False
            ckTodos.Checked = False
            chkResumenEgreso.Checked = False
            chkCuidadosPaliativos.Checked = False
            chkHistIdentRiesgo1.Checked = False
            chkDescripcion.Checked = False
            ckTodos.Checked = False
        End If
    End Sub

    Private Sub chkCuidadosPaliativos_CheckedChanged(sender As Object, e As EventArgs) Handles chkCuidadosPaliativos.CheckedChanged
        If chkCuidadosPaliativos.Checked = True Then
            'Desactivar Check de conciliacion INDRA/FABAICUE 23/04/2022.
            chkConciliacionMed.Checked = False
        End If
    End Sub

    Private Sub chkHistIdentRiesgo1_CheckedChanged(sender As Object, e As EventArgs) Handles chkHistIdentRiesgo1.CheckedChanged
        If chkHistIdentRiesgo1.Checked = True Then
            'Desactivar Check de conciliacion INDRA/FABAICUE 23/04/2022.
            chkConciliacionMed.Checked = False
        End If
    End Sub
End Class


