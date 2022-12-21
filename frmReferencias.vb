Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes

Public Class frmReferencias

    Private _tipReferencia As TipoReferencia
    Private _datosGenerales As Generales
    Private _datosConexion As Conexion


#Region "Enumeraciones"

    Enum TipoReferencia
        procedimientos = 1
        remision = 2
    End Enum

#End Region


#Region "Load"

    Private Sub frmReferencias_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _datosGenerales = Generales.Instancia
        _datosConexion = Conexion.Instancia
    End Sub

#End Region
   
#Region "Buscar"

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click

        Dim dtDatos As New DataTable
        Dim tipReferencia As TipoReferencia
        Dim strCerrado As String
        Dim strMedico As String

        If rbProcedim.Checked = True Then
            tipReferencia = TipoReferencia.procedimientos
        ElseIf rbRemisiones.Checked = True Then
            tipReferencia = TipoReferencia.remision
        Else
            MsgBox("Debe seleccionar el tipo de Contrarreferencia")
            Exit Sub
        End If

        If rbPendientes.Checked = True Then
            strCerrado = "N"
        ElseIf Me.rbCerradas.Checked = True Then
            strCerrado = "S"
        Else
            MsgBox("Debe seleccionar el estado")
            Exit Sub
        End If

        If rbMedicoOrdena.Checked = True Then
            strMedico = _datosGenerales.Login
        ElseIf Me.rbMedicoTodos.Checked = True Then
            strMedico = ""
        Else
            MsgBox("Debe seleccionar el medico")
            Exit Sub
        End If

        dtgReferencias.DataSource = Nothing

        Select Case tipReferencia
            Case TipoReferencia.procedimientos
                dtDatos = BLPlanManejo.traerProcedimientosXPaciente(_datosConexion, strCerrado, strMedico)
                dtgReferencias.DataSource = dtDatos
                configurarGrillaProcedim()
            Case TipoReferencia.remision
                dtDatos = BLPlanManejo.traerRemisionesXPaciente(_datosConexion, strCerrado, strMedico)
                dtgReferencias.DataSource = dtDatos
                configurarGrillaRemision()
        End Select

        _tipReferencia = tipReferencia

    End Sub

    Public Sub configurarGrillaProcedim()
        Dim i As Integer

        For i = 0 To dtgReferencias.Columns.Count - 1
            dtgReferencias.Columns(i).Visible = False
        Next

        With dtgReferencias
            .Columns("fecha").Visible = True
            .Columns("fecha").HeaderText = "FECHA"
            .Columns("fecha").Width = 80

            .Columns("desSucur").Visible = True
            .Columns("desSucur").HeaderText = "SUCURSAL"
            .Columns("desSucur").Width = 150

            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").HeaderText = "PROCEDIMIENTO"
            .Columns("Descripcion").Width = 250

            .Columns("NombreMedico").Visible = True
            .Columns("NombreMedico").HeaderText = "MEDICO"
            .Columns("NombreMedico").Width = 173

            .Columns("hcOrigen").Visible = True
            .Columns("hcOrigen").Width = 90
            .Columns("hcReferencia").Visible = True
            .Columns("hcReferencia").Width = 90
        End With
    End Sub

    Public Sub configurarGrillaRemision()

        Dim i As Integer

        For i = 0 To dtgReferencias.Columns.Count - 1
            dtgReferencias.Columns(i).Visible = False
        Next

        With dtgReferencias
            .Columns("fec_remision").Visible = True
            .Columns("fec_remision").HeaderText = "FECHA"
            .Columns("fec_remision").Width = 120

            .Columns("desSucur").Visible = True
            .Columns("desSucur").HeaderText = "SUCURSAL REMITE"
            .Columns("desSucur").Width = 200

            .Columns("NombreMedico").Visible = True
            .Columns("NombreMedico").HeaderText = "MEDICO"
            .Columns("NombreMedico").Width = 210

            .Columns("strDesInstitucion").Visible = True
            .Columns("strDesInstitucion").HeaderText = "PRESTADOR DESTINO"
            .Columns("strDesInstitucion").Width = 300
        End With

    End Sub

#End Region

#Region "Abrir Referencia"

    Private Sub dtgReferencias_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgReferencias.CellContentClick

        If e.ColumnIndex <> 33 And e.ColumnIndex <> 34 Then
            Exit Sub
        End If

        Dim seccionesAdicionales As New Secciones


        With seccionesAdicionales
            .Recomendaciones = False
            .Remision = False
            .Todas = False
            .Triage = False
        End With

        frmRepHistoriaClinica.Show()

        Select Case e.ColumnIndex
            Case 33 'Admisión de Origen
                With dtgReferencias
                    frmRepHistoriaClinica.ImprimirHistoriaClinica(_datosConexion, .CurrentRow.Cells("cod_pre_sgs").Value, _
                                          .CurrentRow.Cells("cod_sucur").Value, .CurrentRow.Cells("tip_admision").Value, _
                                          .CurrentRow.Cells("ano_adm").Value, .CurrentRow.Cells("num_adm").Value, _
                                          .CurrentRow.Cells("tip_doc").Value, .CurrentRow.Cells("num_doc").Value, _
                                          "", _datosGenerales.Login, _
                                          seccionesAdicionales, "R", "", "", "")
                End With
            Case 34 'Admisión de Referencia
                With dtgReferencias
                    frmRepHistoriaClinica.ImprimirHistoriaClinica(_datosConexion, .CurrentRow.Cells("codpresgs_prac").Value, _
                                          .CurrentRow.Cells("codsucur_prac").Value, .CurrentRow.Cells("tipadmi_prac").Value, _
                                          .CurrentRow.Cells("anoadm_prac").Value, .CurrentRow.Cells("numadm_prac").Value, _
                                          .CurrentRow.Cells("tip_doc").Value, .CurrentRow.Cells("num_doc").Value, _
                                          "", _datosGenerales.Login, _
                                          seccionesAdicionales, "R", "", "", "")
                End With

        End Select
    End Sub

    Private Sub dtgReferencias_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgReferencias.CellDoubleClick
        abrirReferencia(sender, e)
    End Sub

    Private Sub abrirReferencia(ByVal sender As System.Object, ByVal e As EventArgs)

        Dim objProcedim As PlanProcExternos
        Dim objRemision As PlanRemision
        Dim dtDatos As DataTable
        Dim arrayFiltro() As DataRow
        Dim objBLImpresionDiagnostica As New BLHistoriaBasica
        Dim dsDatosID As DataSet
        Dim Datos() As Object
        Dim lError As Long

        dtDatos = Me.dtgReferencias.DataSource

        If IsNothing(dtDatos) Then
            Exit Sub
        ElseIf dtDatos.Rows.Count <= 0 Then
            Exit Sub
        End If

        If dtgReferencias.CurrentRow Is Nothing Then
            MessageBox.Show("Seleccione un Registro de la Lista", "Contrarreferencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        'frmHistoriaPrincipal.pnlContenedorDatos.Controls.Clear()

        ReDim Datos(32)
        Datos(0) = 0
        Datos(1) = 3
        Datos(2) = dtgReferencias.CurrentRow.Cells("tip_doc").Value
        Datos(3) = dtgReferencias.CurrentRow.Cells("num_doc").Value
        If rbProcedim.Checked = True Then
            Datos(4) = dtgReferencias.CurrentRow.Cells("cod_pre_sgs").Value
        ElseIf rbRemisiones.Checked = True Then
            Datos(4) = dtgReferencias.CurrentRow.Cells("codpresgs_origen").Value
        End If
        If rbProcedim.Checked = True Then
            Datos(5) = dtgReferencias.CurrentRow.Cells("cod_sucur").Value
        ElseIf rbRemisiones.Checked = True Then
            Datos(5) = dtgReferencias.CurrentRow.Cells("codsucur_origen").Value
        End If
        Datos(6) = dtgReferencias.CurrentRow.Cells("tip_admision").Value
        Datos(7) = dtgReferencias.CurrentRow.Cells("ano_adm").Value
        Datos(8) = dtgReferencias.CurrentRow.Cells("num_adm").Value
        Datos(9) = ""
        Datos(10) = ""
        Datos(11) = ""
        Datos(12) = ""
        Datos(13) = ""
        Datos(14) = ""
        Datos(15) = ""
        Datos(16) = ""
        Datos(17) = ""
        Datos(18) = ""
        Datos(19) = ""
        Datos(20) = ""
        Datos(21) = ""
        Datos(22) = ""
        Datos(23) = ""
        Datos(24) = ""
        Datos(25) = 0
        Datos(26) = ""
        Datos(27) = 0
        Datos(28) = _datosGenerales.Login
        Datos(29) = ""
        Datos(30) = ""
        Datos(31) = ""
        Datos(32) = lError

        dsDatosID = objBLImpresionDiagnostica.ConsultarDatosImpresionDiagnostica(_datosConexion, lError, Datos)

        If lError <> 0 Then
            MessageBox.Show("No se pueden Mostrar los Datos de la Impresión Diagnóstica de la Referencia" & vbCrLf & "Error al Consultar Datos Impresión Diagnóstica")
        End If


        Select Case _tipReferencia
            Case TipoReferencia.procedimientos

                arrayFiltro = dtDatos.Select("con_procedim = " & dtgReferencias.CurrentRow.Cells("con_procedim").Value _
                                            & " and cod_pre_sgs = " & dtgReferencias.CurrentRow.Cells("cod_pre_sgs").Value _
                                            & " and cod_sucur = " & dtgReferencias.CurrentRow.Cells("cod_sucur").Value)
                'objProcedim = PlanProcExternos.Instancia
                'objProcedim.dtProcedimientos = FuncionesGenerales.copyArrayToDataTable(dtDatos.Clone(), arrayFiltro)
                'objProcedim.Estado = "M"
                'objProcedim.ContraReferencia = True

                Dim ctlPantallaProcedimientosExternos As ctlPlanProcExternos
                ctlPantallaProcedimientosExternos = ctlPlanProcExternos.Instancia
                ctlPantallaProcedimientosExternos.pnlInfoImpresionDiagnostica.Visible = True
                ctlPantallaProcedimientosExternos.CargarReferencia(FuncionesGenerales.copyArrayToDataTable(dtDatos.Clone(), arrayFiltro), dsDatosID.Tables(0))
                frmHistoriaPrincipal.btnProcedimientos_Click(sender, e)
                Me.Close()
                objProcedim = PlanProcExternos.Instancia
                objProcedim.PermiteLimpiarReferencia = True
            Case TipoReferencia.remision
                ' cargarObjetoRemision(dtDatos)
                Dim ctlPantallaRemision As ctlPlanRemision
                ctlPantallaRemision = ctlPlanRemision.Instancia
                ctlPantallaRemision.pnlInfoImpresionDiagnostica.Visible = True
                ctlPantallaRemision.CargarReferencia(dtDatos, dsDatosID.Tables(0))
                frmHistoriaPrincipal.btnRemisiones_Click(sender, e)
                Me.Close()
                objRemision = PlanRemision.Instancia
                objRemision.PermiteLimpiarReferencia = True
        End Select

    End Sub

    Private Sub cargarObjetoRemision(ByVal dtDatos As DataTable)

        Dim objRemision As PlanRemision

        If IsNothing(dtDatos) Then
            Exit Sub
        ElseIf dtDatos.Rows.Count <= 0 Then
            Exit Sub
        End If

        objRemision = PlanRemision.Instancia()


        objRemision.Contrareferencia = True
        objRemision.Estado = "G"

        With dtDatos.Rows(0)
            objRemision.TipoAdmisionOrigenR = .Item("tip_admision").ToString
            objRemision.AnoAdmisionOrigenR = CInt(.Item("ano_adm").ToString)
            objRemision.NumeroAdmisionOrigenR = CLng(.Item("num_adm").ToString)
            objRemision.FechaRemision = .Item("fec_remision").ToString
            objRemision.HoraRemision = CInt(.Item("hor_remision").ToString)
            objRemision.MinutoRemision = CInt(.Item("min_remision").ToString)
            objRemision.SucursalOrigen = .Item("codSucur_origen").ToString
            objRemision.PrestadorOrigen = .Item("codPreSgs_Origen").ToString
            objRemision.CodigoInstitucion = Trim(.Item("strCodigoInstitucion").ToString)
            objRemision.DesInstitucion = Trim(.Item("strDesInstitucion").ToString)
            objRemision.Servicio = Trim(.Item("strServicio").ToString)
            objRemision.MedicoConfirma = Trim(.Item("strMedicoConfirma").ToString)
            objRemision.CargoMedico = Trim(.Item("strCargoMedico").ToString)
            objRemision.DesAmbulancia = Trim(.Item("strDesAmbulancia").ToString)
            objRemision.CodigoAmbulancia = Trim(.Item("strCodigoAmbulancia").ToString)
            objRemision.Nivel = Trim(.Item("strNivel").ToString)
            objRemision.DesNivel = Trim(.Item("strDesNivel").ToString)
            objRemision.Ananmesis = Trim(.Item("strAnanmesis").ToString)
            objRemision.NumeroAutorizacion = Trim(.Item("strNroAutoriza").ToString)
            objRemision.AuxiliarDiagnostico = Trim(.Item("strAuxiliarDiagnostico").ToString)
            objRemision.Evolucion = Trim(.Item("strEvolucion").ToString)
            objRemision.Diagnostico = Trim(.Item("strDiagnostico").ToString)
            objRemision.Complicaciones = Trim(.Item("strComplicaciones").ToString)
            objRemision.Tratamientos = Trim(.Item("strTratamientos").ToString)
            objRemision.Motivos = Trim(.Item("strMotivos").ToString)
            objRemision.EstadoPaciente = Trim(.Item("strEstadoPaciente").ToString)
            objRemision.FechaAutorizacion = Trim(.Item("strFechaAutoriza").ToString)
            objRemision.HoraAutorizacion = CInt(Trim(.Item("strHoraAutoriza").ToString))
            objRemision.MinutoAutorizacion = CInt(Trim(.Item("strMinutoAutoriza").ToString))
            objRemision.Observaciones = .Item("strObservaciones").ToString
            objRemision.ContrareferenciaCerrada = .Item("cerrado").ToString
            objRemision.RepuestaContrareferencia = .Item("resultado").ToString
        End With

    End Sub

#End Region

#Region "Salir"

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbrir.Click
        abrirReferencia(sender, e)
    End Sub

#End Region
    
End Class