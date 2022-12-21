Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports System.Windows.Forms



Public Class ListaEspera
    Private Shared _Instancia As ListaEspera
    Private objDatosGenerales As Generales
    Private objDatosPaciente As Paciente
    Private objConexion As Conexion
    Private strProcedimientoConseguirDatos As String
    Private strOpcion As String
    Private dtClearDatos As New DataTable
    Private blnHistoriaPendiente As Boolean
    Private blnCrearEncabezadoHC As Boolean
    Private DatosConsulta() As Object
    Private strProcedimientoConsulta As String
    Private blnConsultaLista As Boolean = True
    Private DT As DataTable
    Public DatosBasicosPac As New ArrayList()


    Public Sub New()

        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        SetStyle(ControlStyles.UserPaint, True)
        ' This call is required by the Windows Form Designer.

        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

#Region "Instancia de Control"
    Public Shared ReadOnly Property Instancia() As ListaEspera
        Get
            If _Instancia Is Nothing Then
                _Instancia = New ListaEspera
            End If
            Return _Instancia
        End Get
    End Property
#End Region

    Private Sub ListaEspera_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim objLocal As New BLBasicasLocales


        objDatosGenerales = Generales.Instancia
        objDatosPaciente = Paciente.Instancia
        objConexion = Conexion.Instancia

        ''cpgaray validar perfil de solo consulta Octubre 2 de 2013
        If objDatosGenerales.SoloConsulta = True Then
            cmdLista.Enabled = False
            cmdAbrirHistoria.Enabled = False
            rbUrgencias.Enabled = False
            rbCirugia.Enabled = False
            rbHospitalizacion.Enabled = False
            rbEvolucion.Enabled = False
            rbCE.Enabled = False
            rbProAdt.Enabled = False
            rbPendientes.Enabled = False
            frmHistoriaPrincipal.btnNotas.Enabled = False
        End If

        ''cpgaray validar perfil de solo consulta Octubre 2 de 2013
        If objDatosGenerales.SoloConsultaFarma = True Then
            'cmdLista.Enabled = False
            cmdAbrirHistoria.Enabled = False
            'rbUrgencias.Enabled = False
            'rbCirugia.Enabled = False
            'rbHospitalizacion.Enabled = False
            'rbEvolucion.Enabled = False
            rbCE.Enabled = False
            rbProAdt.Enabled = False
            'rbPendientes.Enabled = False
            frmHistoriaPrincipal.btnNotas.Enabled = False
            frmHistoriaPrincipal.btnTriage.Enabled = False
            frmHistoriaPrincipal.btnBeeblos.Enabled = False
            frmHistoriaPrincipal.btnConsultaHC.Enabled = False
            frmHistoriaPrincipal.cmdParaclinico.Enabled = False
            frmHistoriaPrincipal.btnAdmision.Enabled = False

        End If

        CrearOrigenDeDatosLimpio()
        dtgLista.DataSource = dtClearDatos
        ConfigurarGrilla()

        With txtCodigoTipoDocumento
            .NombreCampoBusqueda = "tip_doc"
            .NombreCampoBuscado = "descripcion"
            .ControlTextoEnlace = txtDescTipoDocumento
        End With
        With txtDescTipoDocumento
            .NombreCampoDatos = "descripcion"
            .ControlTextoEnlace = txtCodigoTipoDocumento
            .OrigenDeDatos = objLocal.TraerDatosTablasBasicasLocales(objDatosGenerales.CadenaLocal, "gentipdo", "tip_doc,descripcion", "")
            .CargarDatosDescripcion()
        End With

        InhabilitarPeru()

    End Sub

    Private Sub OpcionesServicio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbUrgencias.CheckedChanged, rbProAdt.CheckedChanged, rbPendientes.CheckedChanged, rbHospitalizacion.CheckedChanged, rbEvolucion.CheckedChanged, rbCirugia.CheckedChanged, rbCE.CheckedChanged
        Dim ctlOpcion As New RadioButton

        ctlOpcion = sender
        If ctlOpcion.Checked = True Then
            strOpcion = ctlOpcion.Text.ToString.ToUpper
            LimpiarDatosPersonales()
            calLista.TodayDate = Now
            HabilitarControles(False)


            Select Case strOpcion
                Case "CIRUGÍA"
                    HabilitarControles(True, "UCP")

                Case "CONSULTA EXTERNA"
                    HabilitarControles(True, "UCP")

                Case "EVOLUCIÓN"
                    HabilitarControles(True, "HE")
                    txtCodigoTipoDocumento.Focus()

                Case "HOSPITALIZACIÓN"
                    HabilitarControles(True, "UCP")
                    'txtCodigoTipoDocumento.Focus()

                Case "PENDIENTES"
                    HabilitarControles(True, "UCP")
                    calLista.Enabled = False

                Case "PROCEDIMIENTOS"
                    HabilitarControles(True, "UCP")

                Case "URGENCIAS"
                    HabilitarControles(True, "UCP")

            End Select
        End If
    End Sub

    Private Sub HabilitarControles(ByVal blnHabilitado As Boolean, Optional ByVal strGrupo As String = "")

        Select Case strGrupo
            Case ""
                calLista.Enabled = blnHabilitado
                cmdLista.Enabled = blnHabilitado
                txtCodigoTipoDocumento.Enabled = blnHabilitado
                txtDescTipoDocumento.Enabled = blnHabilitado
                txtNumeroDocumento.Enabled = blnHabilitado
                txtTipoAdmision.Enabled = blnHabilitado
                txtAnoAdmision.Enabled = blnHabilitado
                txtNumeroAdmision.Enabled = blnHabilitado
                txtNumeroCama.Enabled = blnHabilitado
                dtgLista.Enabled = blnHabilitado
            Case "UCP"
                calLista.Enabled = blnHabilitado
                cmdLista.Enabled = blnHabilitado
                txtCodigoTipoDocumento.Enabled = blnHabilitado
                txtDescTipoDocumento.Enabled = blnHabilitado
                txtNumeroDocumento.Enabled = blnHabilitado
                txtTipoAdmision.Enabled = blnHabilitado
                txtAnoAdmision.Enabled = blnHabilitado
                txtNumeroAdmision.Enabled = blnHabilitado
            Case "HE"
                txtCodigoTipoDocumento.Enabled = blnHabilitado
                txtDescTipoDocumento.Enabled = blnHabilitado
                txtNumeroDocumento.Enabled = blnHabilitado
                txtTipoAdmision.Enabled = blnHabilitado
                txtAnoAdmision.Enabled = blnHabilitado
                txtNumeroAdmision.Enabled = blnHabilitado
                txtNumeroCama.Enabled = blnHabilitado

        End Select
        cmdAbrirHistoria.Enabled = False
    End Sub

    Private Sub LimpiarDatosPersonales()
        Dim dtDatos As New DataTable


        txtCodigoTipoDocumento.ResetText()
        txtDescTipoDocumento.ResetText()
        txtNumeroDocumento.ResetText()
        txtTipoAdmision.ResetText()
        txtAnoAdmision.ResetText()
        txtNumeroAdmision.ResetText()
        txtNumeroCama.ResetText()
        pcFoto.Image = Nothing
        dtgLista.DataSource = dtClearDatos
        ConfigurarGrilla()
    End Sub

    Private Sub TextosBuscador_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTipoAdmision.TextChanged, txtNumeroDocumento.TextChanged, txtNumeroCama.TextChanged, txtNumeroAdmision.TextChanged, txtDescTipoDocumento.TextChanged, txtCodigoTipoDocumento.TextChanged, txtAnoAdmision.TextChanged

        Dim blnTextoBusqueda As Boolean
        If sender.Text.Trim.Length > 0 Then
            cmdLista.Enabled = True
        Else
            Dim ctlControl As Control

            For Each ctlControl In Me.gbDatos.Controls
                If TypeOf ctlControl Is TextBox Then
                    If ctlControl.Text.Trim.Length > 0 Then
                        blnTextoBusqueda = True
                        Exit For
                    End If
                End If
            Next

            If rbEvolucion.Checked = True Or rbHospitalizacion.Checked = True Then
                cmdLista.Enabled = blnTextoBusqueda
            Else
                cmdLista.Enabled = True
            End If
        End If

        If Me.txtTipoAdmision.Text <> "" Then
            If Me.txtAnoAdmision.Text = "" Then
                Dim temaño As Integer
                temaño = Year(Date.Today)
                Me.txtAnoAdmision.Text = temaño
            End If
        End If

    End Sub

    Private Sub cmdLista_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLista.Click
        Dim dtDatosLista As New DataTable
        Dim objConseguirDatos As New BLHistoriaBasica
        Dim lError As Long
        Dim Datos() As Object = Nothing
        Dim intRow As Integer
        Dim intDatoCompletoDoc As Integer
        Dim intDatoCompletoAdm As Integer



        If (Me.txtCodigoTipoDocumento.Text.Trim.Length > 0) Then
            intDatoCompletoDoc += 1
        End If
        If (Me.txtNumeroDocumento.Text.Trim.Length > 0) Then
            intDatoCompletoDoc += 1
        End If

        If (Me.txtTipoAdmision.Text.Trim.Length > 0) Then
            intDatoCompletoAdm += 1
        End If
        If (Me.txtAnoAdmision.Text.Trim.Length > 0) Then
            intDatoCompletoAdm += 1
        End If
        If (Me.txtNumeroAdmision.Text.Trim.Length > 0) Then
            intDatoCompletoAdm += 1
        End If


        If intDatoCompletoDoc = 2 Or intDatoCompletoAdm = 3 Or Me.txtNumeroCama.Text.Trim.Length > 0 Then
            TraerPacienteListaEspera()
            Exit Sub
        End If

        If intDatoCompletoDoc = 1 Then
            MessageBox.Show("Datos Incompletos")
            If (Me.txtCodigoTipoDocumento.Text.Trim.Length = 0) Then
                Me.txtCodigoTipoDocumento.Focus()
            Else
                Me.txtNumeroDocumento.Focus()
            End If
            Exit Sub
        End If

        If intDatoCompletoAdm > 0 Then
            MessageBox.Show("Datos Incompletos")
            If (Me.txtTipoAdmision.Text.Trim.Length = 0) Then
                Me.txtTipoAdmision.Focus()
            ElseIf (Me.txtAnoAdmision.Text.Trim.Length = 0) Then
                Me.txtAnoAdmision.Focus()
            ElseIf (Me.txtNumeroAdmision.Text.Trim.Length = 0) Then
                Me.txtNumeroAdmision.Focus()
            End If
            Exit Sub
        End If


        Select Case strOpcion
            Case "CIRUGÍA"
                strProcedimientoConseguirDatos = "HC_TraerListaDatosPacientesCirugia"
                'strProcedimientoConseguirPaciente = "HC_TraerDatosPacienteCirugia"
                ReDim Datos(3)
                Datos(0) = objDatosGenerales.Prestador
                Datos(1) = objDatosGenerales.Sucursal
                Datos(2) = Format(calLista.SelectionStart, "yyyy/MM/dd").ToString
                Datos(3) = lError

            Case "CONSULTA EXTERNA"
                strProcedimientoConseguirDatos = "HC_TraerListaDatosPacientesConsultaExterna"
                'strProcedimientoConseguirPaciente = "HC_TraerDatosPacienteConsultaExterna"
                ReDim Datos(4)
                Datos(0) = objDatosGenerales.Prestador
                Datos(1) = objDatosGenerales.Sucursal
                Datos(2) = objDatosGenerales.Login
                Datos(3) = Format(calLista.SelectionStart, "yyyy/MM/dd").ToString
                Datos(4) = lError

            Case "PENDIENTES"
                strProcedimientoConseguirDatos = "HC_TraerListaDatosPacientesObservacion"
                'strProcedimientoConseguirPaciente = "HC_TraerDatosPacienteObservacion"
                ReDim Datos(9)
                Datos(0) = objDatosGenerales.Prestador
                Datos(1) = objDatosGenerales.Sucursal
                Datos(2) = "P"
                Datos(3) = ""
                Datos(4) = ""
                Datos(5) = ""
                Datos(6) = 0
                Datos(7) = 0
                Datos(8) = objDatosGenerales.Login
                Datos(9) = lError

            Case "PROCEDIMIENTOS"
                strProcedimientoConseguirDatos = "HC_TraerListaDatosPacientesProcedimientos"
                'strProcedimientoConseguirPaciente = "HC_TraerDatosPacienteProcedimientos"
                ReDim Datos(4)
                Datos(0) = objDatosGenerales.Prestador
                Datos(1) = objDatosGenerales.Sucursal
                Datos(2) = Format(calLista.SelectionStart, "yyyy/MM/dd").ToString
                Datos(3) = objDatosGenerales.Login
                Datos(4) = lError

            Case "URGENCIAS"
                strProcedimientoConseguirDatos = "HC_TraerListaDatosPacientesUrgencias"
                'strProcedimientoConseguirPaciente = "HC_TraerDatosPacienteUrgencias"
                ReDim Datos(3)
                Datos(0) = objDatosGenerales.Prestador
                Datos(1) = objDatosGenerales.Sucursal
                Datos(2) = Format(calLista.SelectionStart, "yyyy/MM/dd").ToString
                Datos(3) = lError

                ' Se agrega para realizar consulta sin parametros
                ' 24 de julio 2009
                ' Solicitado por Enrique Forero
                ' Realizado por Claudia Garay

            Case "HOSPITALIZACIÓN"
                strProcedimientoConseguirDatos = "HC_TraerDatosPacienteHospitalizacion"
                ReDim Datos(8)
                Datos(0) = objDatosGenerales.Prestador
                Datos(1) = objDatosGenerales.Sucursal
                Datos(2) = txtCodigoTipoDocumento.Text.Trim
                Datos(3) = txtNumeroDocumento.Text.Trim
                Datos(4) = txtTipoAdmision.Text.Trim
                Datos(5) = Val(txtAnoAdmision.Text.Trim)
                Datos(6) = Val(txtNumeroAdmision.Text.Trim)
                Datos(7) = txtNumeroCama.Text.Trim
                Datos(8) = lError
        End Select

        Try
            Me.Cursor = Cursors.WaitCursor
            dtDatosLista = objConseguirDatos.ConsultarDatosPacientes(strProcedimientoConseguirDatos, objConexion, lError, Datos)
            If lError = 9999 Then
                MessageBox.Show("No Existen Datos Para Esta Consulta")
            Else
                Me.dtgLista.Enabled = True
                For intRow = 0 To dtDatosLista.Rows.Count - 1
                    If Not dtDatosLista.Rows(intRow).Item("edad") Is DBNull.Value Then
                        If dtDatosLista.Rows(intRow).Item("edad") = 1 Then
                            'If dtDatosLista.Rows(intRow).Item("uni_med_tie") = "M" Then
                            '    dtDatosLista.Rows(intRow).Item("descEdad") = dtDatosLista.Rows(intRow).Item("descEdad").ToString.Substring(0, dtDatosLista.Rows(intRow).Item("descEdad").ToString.Length - 2)
                            'Else
                            '    dtDatosLista.Rows(intRow).Item("descEdad") = dtDatosLista.Rows(intRow).Item("descEdad").ToString.Substring(0, dtDatosLista.Rows(intRow).Item("descEdad").ToString.Length - 1)
                            'End If
                        End If
                    Else
                        dtDatosLista.Rows(intRow).Item("descEdad") = ""
                    End If
                Next
                dtDatosLista.DefaultView.Sort = "fec_ingreso, hor_ingreso, min_ingreso, clasificacion "
                Me.dtgLista.DataSource = dtDatosLista
                ConfigurarGrilla()
                DatosConsulta = Datos
                strProcedimientoConsulta = strProcedimientoConseguirDatos

            End If
        Catch ex As Exception

            ' MessageBox.Show(ex.Message)
            'Implementar
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub calLista_DateSelected(ByVal sender As Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles calLista.DateSelected
        LimpiarDatosPersonales()
        cmdAbrirHistoria.Enabled = False
    End Sub

    Private Sub ConfigurarGrilla()

        Dim intCol As Integer

        For intCol = 0 To dtgLista.Columns.Count - 1
            dtgLista.Columns(intCol).Visible = True

            Select Case dtgLista.Columns(intCol).Name.ToLower
                Case "edescripcion"
                    dtgLista.Columns(intCol).HeaderText = "ENTIDAD"
                    dtgLista.Columns(intCol).Width = 90 '- -155
                    dtgLista.Columns(intCol).Visible = False
                    dtgLista.Columns(intCol).HeaderCell.Style.Font = New Font("Arial", 6.5)
                    dtgLista.Columns(intCol).DefaultCellStyle.Font = New Font("Arial", 6.5)
                Case "nombre"
                    dtgLista.Columns(intCol).HeaderText = "NOMBRE"
                    dtgLista.Columns(intCol).Width = 250
                    dtgLista.Columns(intCol).HeaderCell.Style.Font = New Font("Arial", 6.5)
                    dtgLista.Columns(intCol).DefaultCellStyle.Font = New Font("Arial", 6.5)
                Case "descentidad"
                    dtgLista.Columns(intCol).HeaderText = "ENTIDAD"
                    If objDatosGenerales.Pais <> "482" Then
                        dtgLista.Columns(intCol).Visible = False
                    End If
                    dtgLista.Columns(intCol).Width = 150 '90
                    dtgLista.Columns(intCol).HeaderCell.Style.Font = New Font("Arial", 6.5)
                    dtgLista.Columns(intCol).DefaultCellStyle.Font = New Font("Arial", 6.5)
                Case "descedad"
                    dtgLista.Columns(intCol).HeaderText = "EDAD"
                    dtgLista.Columns(intCol).Width = 55 '60
                    dtgLista.Columns(intCol).Visible = False
                    dtgLista.Columns(intCol).HeaderCell.Style.Font = New Font("Arial", 6.5)
                    dtgLista.Columns(intCol).DefaultCellStyle.Font = New Font("Arial", 6.5)
                Case "hor_atenc"
                    dtgLista.Columns(intCol).HeaderText = "HORA CITA"
                    dtgLista.Columns(intCol).Width = 76
                    dtgLista.Columns(intCol).Visible = False
                    dtgLista.Columns(intCol).HeaderCell.Style.Font = New Font("Arial", 6.5)
                    dtgLista.Columns(intCol).DefaultCellStyle.Font = New Font("Arial", 6.5)
                Case "min_atenc"
                    dtgLista.Columns(intCol).HeaderText = "MINUTO CITA"
                    dtgLista.Columns(intCol).Width = 76
                    dtgLista.Columns(intCol).Visible = False
                    dtgLista.Columns(intCol).HeaderCell.Style.Font = New Font("Arial", 6.5)
                    dtgLista.Columns(intCol).DefaultCellStyle.Font = New Font("Arial", 6.5)
                Case "fec_ingreso"
                    dtgLista.Columns(intCol).HeaderText = "FECHA INGRESO"
                    dtgLista.Columns(intCol).Width = 90 ' 76
                    dtgLista.Columns(intCol).HeaderCell.Style.Font = New Font("Arial", 6.5)
                    dtgLista.Columns(intCol).DefaultCellStyle.Font = New Font("Arial", 6.5)
                Case "hor_ingreso"
                    dtgLista.Columns(intCol).HeaderText = "HORA INGRESO"
                    dtgLista.Columns(intCol).Width = 90 '70 
                    dtgLista.Columns(intCol).HeaderCell.Style.Font = New Font("Arial", 6.5)
                    dtgLista.Columns(intCol).DefaultCellStyle.Font = New Font("Arial", 6.5)
                Case "min_ingreso"
                    dtgLista.Columns(intCol).HeaderText = "MINUTO INGRESO"
                    dtgLista.Columns(intCol).Width = 90 '50 
                    dtgLista.Columns(intCol).HeaderCell.Style.Font = New Font("Arial", 6.5)
                    dtgLista.Columns(intCol).DefaultCellStyle.Font = New Font("Arial", 6.5)
                Case "clasificacion"
                    dtgLista.Columns(intCol).HeaderText = "TRIAGE"
                    dtgLista.Columns(intCol).Width = 50 '60
                    dtgLista.Columns(intCol).Visible = False
                    dtgLista.Columns(intCol).HeaderCell.Style.Font = New Font("Arial", 6.5)
                    dtgLista.Columns(intCol).DefaultCellStyle.Font = New Font("Arial", 6.5)
                Case "cama"
                    dtgLista.Columns(intCol).HeaderText = "CAMA"
                    dtgLista.Columns(intCol).Width = 60
                    dtgLista.Columns(intCol).Visible = False
                    dtgLista.Columns(intCol).HeaderCell.Style.Font = New Font("Arial", 6.5)
                    dtgLista.Columns(intCol).DefaultCellStyle.Font = New Font("Arial", 6.5)
                Case "destino"
                    dtgLista.Columns(intCol).HeaderText = "DESTINO"
                    dtgLista.Columns(intCol).Width = 150 '90
                    dtgLista.Columns(intCol).Visible = False
                    dtgLista.Columns(intCol).HeaderCell.Style.Font = New Font("Arial", 6.5)
                    dtgLista.Columns(intCol).DefaultCellStyle.Font = New Font("Arial", 6.5)
     
                Case Else
                    dtgLista.Columns(intCol).Visible = False
            End Select
        Next

        If Not dtgLista.DataSource Is Nothing Then
            'if stropcion="EVOLUCIÓN" OR STROPCION=""
            If strOpcion = "EVOLUCIÓN" Or strOpcion = "URGENCIAS" Then
                dtgLista.Columns("clasificacion").Visible = True
                dtgLista.Columns("destino").Visible = True
            End If

           

            If strOpcion = "HOSPITALIZACIÓN" Or strOpcion = "EVOLUCIÓN" Then
                dtgLista.Columns("cama").Visible = True
            End If
          

            If dtgLista.Columns("clasificacion").Visible = False AndAlso dtgLista.Columns("cama").Visible = False Then
                If objDatosGenerales.Pais = "482" Then
                    dtgLista.Columns("nombre").Width = 321 '471 '455
                Else
                    dtgLista.Columns("nombre").Width = 471 '455
                End If

            Else
                If dtgLista.Columns("clasificacion").Visible = True AndAlso dtgLista.Columns("cama").Visible = True Then
                    dtgLista.Columns("nombre").Width = 265 '250 
                Else
                    dtgLista.Columns("nombre").Width = 410 '395 
                End If
            End If
            If strOpcion = "PROCEDIMIENTOS" Or strOpcion = "CONSULTA EXTERNA" Then
                dtgLista.Columns("hor_atenc").Visible = True
                dtgLista.Columns("min_atenc").Visible = True
                dtgLista.Columns("nombre").Width = 320 '305
            End If

            If strOpcion = "URGENCIAS" Then
                dtgLista.Columns("nombre").Width = 210 '220
                dtgLista.Columns("edescripcion").Visible = True
                dtgLista.Columns("hor_ingreso").Width -= 25
                dtgLista.Columns("hor_ingreso").HeaderText = "HORA"
                dtgLista.Columns("min_ingreso").Width -= 10
                dtgLista.Columns("clasificacion").Width -= 10
                dtgLista.Columns("min_ingreso").HeaderText = "MIN" '- -"MINUTO"
                dtgLista.Columns("descedad").Visible = True
                dtgLista.Columns("destino").HeaderText = "DESTINO"

            End If
            dtgLista.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
        End If

    End Sub

    Private Sub dtgLista_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgLista.CellClick
        EditarValores(dtgLista.CurrentRow)
        DatosBasicosPac.Clear()

    End Sub

    Private Sub CrearOrigenDeDatosLimpio()
        Dim dr As DataRow
        With dtClearDatos
            .Columns.Add("edescripcion", System.Type.GetType("System.String"))
            .Columns.Add("nombre", System.Type.GetType("System.String"))
            .Columns.Add("descentidad", System.Type.GetType("System.String"))
            .Columns.Add("descEdad", System.Type.GetType("System.String"))
            .Columns.Add("fec_ingreso", System.Type.GetType("System.String"))
            .Columns.Add("hor_ingreso", System.Type.GetType("System.String"))
            .Columns.Add("min_ingreso", System.Type.GetType("System.String"))
            .Columns.Add("clasificacion", System.Type.GetType("System.String"))
            .Columns.Add("cama", System.Type.GetType("System.String"))
            .Columns.Add("hor_atenc", System.Type.GetType("System.String"))
            .Columns.Add("min_atenc", System.Type.GetType("System.String"))
            .Columns.Add("destino", System.Type.GetType("System.String"))
            dr = dtClearDatos.NewRow()
            .Rows.Add(dr)
        End With

    End Sub

    Private Sub EditarValores(ByVal dtRow As DataGridViewRow)

        pcFoto.Image = Nothing
        txtCodigoTipoDocumento.Text = dtRow.Cells("tip_doc").Value.ToString
        txtDescTipoDocumento.Text = txtCodigoTipoDocumento.DescripcionCodigo
        txtNumeroDocumento.Text = dtRow.Cells("num_doc").Value.ToString
        txtTipoAdmision.Text = dtRow.Cells("tip_admision").Value.ToString
        txtAnoAdmision.Text = dtRow.Cells("ano_adm").Value.ToString
        txtNumeroAdmision.Text = dtRow.Cells("num_adm").Value.ToString
        txtNumeroCama.Text = dtRow.Cells("cama").Value.ToString
        ConsultarFoto(dtRow.Cells("tip_doc").Value.ToString, dtRow.Cells("num_doc").Value.ToString)
        cmdAbrirHistoria.Enabled = True
    End Sub

    Private Sub ConsultarFoto(ByVal strTipDoc As String, ByVal strNumDoc As String)
        Dim dtFoto As New DataTable
        Dim objConseguirDatos As New BLHistoriaBasica
        Dim lError As Long
        Dim objComunes As New HistoriaClinica.Sophia.HistoriaClinica.Comunes.FuncionesGenerales
        If strTipDoc.Trim.Length = 0 Or strNumDoc.Trim.Length = 0 Then
            Exit Sub
        End If
        Try
            dtFoto = objConseguirDatos.ConsultarFotoPaciente("HC_TraerFotoPaciente", objConexion, lError, strTipDoc, strNumDoc)
            If lError = 9999 Then
                MessageBox.Show("Paciente No Tiene Foto")
            Else
                If Not IsDBNull(dtFoto.Rows(0).Item(0)) Then
                    pcFoto.Image = objComunes.SetPhoto(dtFoto.Rows(0).Item("fot_pac"))
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub TraerPacienteListaEspera()
        Dim dtDatosPaciente As New DataTable
        Dim objConseguirDatos As New BLHistoriaBasica
        Dim lError As Long
        Dim Datos() As Object = Nothing
        Dim strEstadoAdmision As String = ""
        Dim strEstadoHistoria As String = ""
        Dim OpcionEstado As String = ""



        Select Case strOpcion
            Case "CIRUGÍA"
                strProcedimientoConseguirDatos = "HC_TraerDatosPacienteCirugia"
                ReDim Datos(7)
                Datos(0) = objDatosGenerales.Prestador
                Datos(1) = objDatosGenerales.Sucursal
                Datos(2) = txtCodigoTipoDocumento.Text.Trim
                Datos(3) = txtNumeroDocumento.Text.Trim
                Datos(4) = txtTipoAdmision.Text.Trim
                Datos(5) = Val(txtAnoAdmision.Text.Trim)
                Datos(6) = Val(txtNumeroAdmision.Text.Trim)
                Datos(7) = lError

            Case "CONSULTA EXTERNA"
                strProcedimientoConseguirDatos = "HC_TraerDatosPacienteConsultaExterna"
                ReDim Datos(8)
                Datos(0) = objDatosGenerales.Prestador
                Datos(1) = objDatosGenerales.Sucursal
                Datos(2) = txtCodigoTipoDocumento.Text.Trim
                Datos(3) = txtNumeroDocumento.Text.Trim
                Datos(4) = txtTipoAdmision.Text.Trim
                Datos(5) = Val(txtAnoAdmision.Text.Trim)
                Datos(6) = Val(txtNumeroAdmision.Text.Trim)
                Datos(7) = objDatosGenerales.Login
                Datos(8) = lError

            Case "PENDIENTES"
                strProcedimientoConseguirDatos = "HC_TraerDatosPacienteObservacion"
                ReDim Datos(9)
                Datos(0) = objDatosGenerales.Prestador
                Datos(1) = objDatosGenerales.Sucursal
                Datos(2) = "P"
                Datos(3) = txtCodigoTipoDocumento.Text.Trim
                Datos(4) = txtNumeroDocumento.Text.Trim
                Datos(5) = txtTipoAdmision.Text.Trim
                Datos(6) = Val(txtAnoAdmision.Text.Trim)
                Datos(7) = Val(txtNumeroAdmision.Text.Trim)
                Datos(8) = txtNumeroCama.Text.Trim
                Datos(9) = lError

            Case "PROCEDIMIENTOS"
                strProcedimientoConseguirDatos = "HC_TraerDatosPacienteProcedimientos"
                ReDim Datos(8)
                Datos(0) = objDatosGenerales.Prestador
                Datos(1) = objDatosGenerales.Sucursal
                Datos(2) = txtCodigoTipoDocumento.Text.Trim
                Datos(3) = txtNumeroDocumento.Text.Trim
                Datos(4) = txtTipoAdmision.Text.Trim
                Datos(5) = Val(txtAnoAdmision.Text.Trim)
                Datos(6) = Val(txtNumeroAdmision.Text.Trim)
                Datos(7) = objDatosGenerales.Login
                Datos(8) = lError

            Case "URGENCIAS"
                strProcedimientoConseguirDatos = "HC_TraerDatosPacienteUrgencias"
                ReDim Datos(7)
                Datos(0) = objDatosGenerales.Prestador
                Datos(1) = objDatosGenerales.Sucursal
                Datos(2) = txtCodigoTipoDocumento.Text.Trim
                Datos(3) = txtNumeroDocumento.Text.Trim
                Datos(4) = txtTipoAdmision.Text.Trim
                Datos(5) = Val(txtAnoAdmision.Text.Trim)
                Datos(6) = Val(txtNumeroAdmision.Text.Trim)
                Datos(7) = lError

            Case "EVOLUCIÓN"
                strProcedimientoConseguirDatos = "HC_TraerDatosPacienteObservacion"
                ReDim Datos(9)
                Datos(0) = objDatosGenerales.Prestador
                Datos(1) = objDatosGenerales.Sucursal
                Datos(2) = "O"
                Datos(3) = txtCodigoTipoDocumento.Text.Trim
                Datos(4) = txtNumeroDocumento.Text.Trim
                Datos(5) = txtTipoAdmision.Text.Trim
                Datos(6) = Val(txtAnoAdmision.Text.Trim)
                Datos(7) = Val(txtNumeroAdmision.Text.Trim)
                Datos(8) = txtNumeroCama.Text.Trim
                Datos(9) = lError

            Case "HOSPITALIZACIÓN"
                strProcedimientoConseguirDatos = "HC_TraerDatosPacienteHospitalizacion"
                ReDim Datos(8)
                Datos(0) = objDatosGenerales.Prestador
                Datos(1) = objDatosGenerales.Sucursal
                Datos(2) = txtCodigoTipoDocumento.Text.Trim
                Datos(3) = txtNumeroDocumento.Text.Trim
                Datos(4) = txtTipoAdmision.Text.Trim
                Datos(5) = Val(txtAnoAdmision.Text.Trim)
                Datos(6) = Val(txtNumeroAdmision.Text.Trim)
                Datos(7) = txtNumeroCama.Text.Trim
                Datos(8) = lError
        End Select

        Try
            Me.Cursor = Cursors.WaitCursor
            dtDatosPaciente = objConseguirDatos.ConsultarDatosPacientes(strProcedimientoConseguirDatos, objConexion, lError, Datos)
            If lError = 9999 Then
                ''Claudia Garay Para evaluar el estado de ala historia 2011-05-06
                strProcedimientoConseguirDatos = "HCConsultaEstadoHCyAdmision"
                ReDim Datos(5)
                Datos(0) = objDatosGenerales.Prestador
                Datos(1) = objDatosGenerales.Sucursal
                Datos(2) = txtTipoAdmision.Text.Trim
                Datos(3) = Val(txtNumeroAdmision.Text.Trim)
                Datos(4) = Val(txtAnoAdmision.Text.Trim)
                Datos(5) = 0


                dtDatosPaciente = objConseguirDatos.ConsultarDatosPacientes(strProcedimientoConseguirDatos, objConexion, lError, Datos)

                If dtDatosPaciente.Rows.Count = 0 Then
                    MessageBox.Show("No Existen Datos Para Esta Consulta")
                Else     
                    OpcionEstado = IIf(IsDBNull(dtDatosPaciente.Rows(0).Item("EstadoHistoria")), "", dtDatosPaciente.Rows(0).Item("EstadoHistoria"))
                    Select Case OpcionEstado
                        Case "O"
                            strEstadoHistoria = "Observación"
                        Case "E"
                            strEstadoHistoria = "Egresada"
                        Case "L"
                            strEstadoHistoria = "Lista"
                        Case "P"
                            strEstadoHistoria = "Pendiente"
                    End Select
                    MessageBox.Show("La Historia se encuentra en estado: " & strEstadoHistoria)
                End If

            Else
            Me.dtgLista.Enabled = True
            Me.dtgLista.DataSource = dtDatosPaciente
            ConfigurarGrilla()
            ConsultarFoto(dtDatosPaciente.Rows(0).Item("tip_doc").ToString, dtDatosPaciente.Rows(0).Item("num_doc").ToString)
            cmdAbrirHistoria.Enabled = True
            DatosConsulta = Datos
            strProcedimientoConsulta = strProcedimientoConseguirDatos
            blnConsultaLista = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            'Implementar
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub AlmacenarInformacionPaciente(ByVal dRow As DataGridViewRow)

        Dim objConseguirDatos As New BLBasicasLocales
        Dim objConseguirDatosS As New BLHistoriaBasica
        Dim objPaciente As New BLHistoriaBasica
        Dim objGeneral As New DAOGeneral()
        Dim Datos() As Object
        Dim dtDatosPaciente As DataTable
        Dim dtEntidad As DataTable
        Dim lError As Long

        With objDatosPaciente
            .TipoDocumento = dRow.Cells("tip_doc").Value.ToString
            Try
                .DescripcionTipoDocumento = objConseguirDatos.TraerDatosTablasBasicasLocales(objDatosGenerales.CadenaLocal, "gentipdo", "descripcion", "tip_doc='" & dRow.Cells("tip_doc").Value.ToString & "'").Rows(0)("descripcion").ToString
            Catch ex As Exception
                .DescripcionTipoDocumento = ""
            End Try
            .NumeroDocumento = dRow.Cells("num_doc").Value.ToString
            .PrimerApellido = dRow.Cells("pri_ape").Value.ToString
            .SegundoApellido = dRow.Cells("seg_ape").Value.ToString
            .PrimerNombre = dRow.Cells("pri_nom").Value.ToString
            .SegundoNombre = dRow.Cells("seg_nom").Value.ToString
            .Genero = dRow.Cells("sexo").Value.ToString
            .FechaNacimiento = dRow.Cells("fec_nac").Value.ToString
            '.Edad = Val(dRow.Cells("edad").Value.ToString)
            '.CodigoUnidadMedidaEdad = dRow.Cells("uni_med_tie").Value.ToString
            .Cronico = dRow.Cells("parcela").Value.ToString  ''Insertado por Claudia Garay 2009-12-22
            .Carnet = dRow.Cells("carnet").Value.ToString
            .Cama = dRow.Cells("cama").Value.ToString
            Try
                .DescripcionUnidadMedidaEdad = objConseguirDatos.TraerDatosTablasBasicasLocales(objDatosGenerales.CadenaLocal, "genunime", "descripcion", "uni_med_tie='" & dRow.Cells("uni_med_tie").Value.ToString & "'").Rows(0)("descripcion").ToString
            Catch ex As Exception
                .DescripcionUnidadMedidaEdad = ""
            End Try
            .GrupoSanguineo = dRow.Cells("gru_sanguineo").Value.ToString
            .RH = dRow.Cells("RH").Value.ToString
            .FotoPaciente = pcFoto.Image
            .CodigoOcupacionPaciente = dRow.Cells("ocupacion").Value.ToString
            Try
                .DescripcionOcupacionPaciente = objConseguirDatos.TraerDatosTablasBasicasLocales(objDatosGenerales.CadenaLocal, "genocupa", "descripcion", "ocupacion='" & dRow.Cells("ocupacion").Value.ToString & "'").Rows(0)("descripcion").ToString
            Catch ex As Exception
                .DescripcionOcupacionPaciente = ""
            End Try
            .ClasificacionTriage = dRow.Cells("clasificacion").Value.ToString
            .Unificado = dRow.Cells("unificado").ToString
            .TipoConsultorio = dRow.Cells("tip_consultorio").Value.ToString
            .Consultorio = dRow.Cells("consultorio").Value.ToString
            .TipoAdmision = dRow.Cells("tip_admision").Value.ToString
            .AnoAdmision = Val(dRow.Cells("ano_adm").Value.ToString)
            .NumeroAdmision = Val(dRow.Cells("num_adm").Value.ToString)
            .FechaIngresoAdmision = dRow.Cells("fec_ingreso").Value.ToString
            .HoraIngresoAdmision = Val(dRow.Cells("hor_ingreso").Value.ToString)
            .MinutoIngresoAdmision = Val(dRow.Cells("min_ingreso").Value.ToString)
            .TipoHistoria = DefinirTipoHistoria(strOpcion, dRow.Cells("tip_hc").Value.ToString)
            .FechaHistoriaClinica = dRow.Cells("fec_hc").Value.ToString
            .HoraHistoriaClinica = Val(dRow.Cells("hor_hc").Value.ToString)
            .MinutoHistoriaClinica = Val(dRow.Cells("min_hc").Value.ToString)
            .IdentificadorCama = IIf(IsDBNull(dRow.Cells("cama").Value), "", dRow.Cells("cama").Value)
            .HistoriaTieneEgreso = HistoriaTieneEgreso()
            .FechaCita = dRow.Cells("fec_cita").Value.ToString
            .HoraCita = Val(dRow.Cells("hor_cita").Value.ToString)
            .MinutoCita = Val(dRow.Cells("min_cita").Value.ToString)
            .FechaAtencionProcedimiento = dRow.Cells("fec_atenc").Value.ToString
            .HoraAtencionProcedimiento = Val(dRow.Cells("hor_atenc").Value.ToString)
            .MinutoAtencionProcedimiento = Val(dRow.Cells("min_atenc").Value.ToString)
            .EstadoAdmision = dRow.Cells("estado").Value.ToString
            .Entidad = dRow.Cells("entidad").Value.ToString
            .DirSucursal = dRow.Cells("dirSucursal").Value.ToString
            .telSucursal = dRow.Cells("telSucursal").Value.ToString
            .Ciudad = dRow.Cells("ciudad").Value.ToString
            .Pais = dRow.Cells("pais").Value.ToString
            Try
                dtEntidad = objConseguirDatosS.ConsultarTablasBasicas("genentid", objConexion, "descripcion,man_conv_med,tip_usuario,tip_entidad", "entidad='" & .Entidad & "'")
                .DescripcionEntidad = dtEntidad.Rows(0)("descripcion").ToString
                .ManejaConvenio = dtEntidad.Rows(0)("man_conv_med").ToString
                .TipoUsuario = dtEntidad.Rows(0)("tip_usuario").ToString
                .TipoEntidad = dtEntidad.Rows(0)("tip_entidad").ToString
            Catch ex As Exception
                MessageBox.Show("Error al Consultar Datos Entidad", "LISTA ESPERA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                .DescripcionEntidad = ""
                .ManejaConvenio = ""
            End Try
            Try
                ''Claudia Garay Alarmas 28 sept 2010
                .CodHistoria = objGeneral.EjecutarSQLStrValor("hcenfermeria", objConexion, "cod_historia", "cod_pre_sgs='" & objDatosGenerales.Prestador & _
                                                              "' and cod_sucur='" & objDatosGenerales.Sucursal & "' and tip_admision='" & objDatosPaciente.TipoAdmision & _
                                                              "' and num_adm='" & objDatosPaciente.NumeroAdmision & "' and ano_adm='" & objDatosPaciente.AnoAdmision & "'")
            Catch ex As Exception
                .CodHistoria = ""
            End Try
            .EstadoInstancia = True
            .DocumentosUnificados = ConsultarDocumentosUnificados()
            If .DocumentosUnificados.Rows.Count > 0 Then
                .XMLDocumentosUnificados = FuncionesGenerales.GenerarXMLxProcedimiento(.DocumentosUnificados())
            Else
                .XMLDocumentosUnificados = ""
            End If
            .EstadoInicialHistoria = dRow.Cells("estadoHistoria").Value.ToString


            '2017-06-14 cariasm 
            'Inclusión de nuevos campos desde la admisión 
            strProcedimientoConseguirDatos = "HCL_LSTDATOSPACIENTE"
            ReDim Datos(4)
            Datos(0) = dRow.Cells("tip_doc").Value.ToString
            Datos(1) = dRow.Cells("num_doc").Value.ToString()
            Datos(2) = dRow.Cells("tip_admision").Value.ToString()
            Datos(3) = Val(dRow.Cells("ano_adm").Value.ToString)
            Datos(4) = Val(dRow.Cells("num_adm").Value.ToString)

            dtDatosPaciente = objPaciente.ConsultarDatosPacientes(strProcedimientoConseguirDatos, objConexion, lError, Datos)
            .NombreCompleto = dtDatosPaciente.Rows(0)("NOMBRECOMPLETO").ToString
            .EdadAMD = dtDatosPaciente.Rows(0)("EDAD").ToString
            .Religion = dtDatosPaciente.Rows(0)("RELIGION").ToString
            .Admision = dtDatosPaciente.Rows(0)("ADMISION").ToString
            .FechaHoraAdmision = dtDatosPaciente.Rows(0)("FECHAADM").ToString
            .Ubicacion = dtDatosPaciente.Rows(0)("UBICACION").ToString
            .GrupoRH = dtDatosPaciente.Rows(0)("GRUPORH").ToString

            .Edad = dtDatosPaciente.Rows(0)("ANIOSHCL").ToString
            .CodigoUnidadMedidaEdad = dtDatosPaciente.Rows(0)("UNIMEDPACHCL").ToString
            'Fin 2017-06-14 cariasm 

        End With

    End Sub

    Private Function DefinirTipoHistoria(ByVal strOpcionSel As String, ByVal strTipoHCGrilla As String) As String
        Dim strTipoHistoria As String = String.Empty

        blnHistoriaPendiente = False
        Select Case strOpcionSel
            Case "CIRUGÍA"
                strTipoHistoria = "A"
            Case "CONSULTA EXTERNA"
                strTipoHistoria = "E"
            Case "PENDIENTES"
                blnHistoriaPendiente = True
                strTipoHistoria = strTipoHCGrilla
            Case "URGENCIAS"
                strTipoHistoria = "U"
            Case "EVOLUCIÓN"
                strTipoHistoria = "V"
            Case "PROCEDIMIENTOS"
                strTipoHistoria = "P"
            Case "HOSPITALIZACIÓN"
                strTipoHistoria = "H"
        End Select

        blnCrearEncabezadoHC = (Not blnHistoriaPendiente) And (strTipoHistoria <> "V")

        Return strTipoHistoria

    End Function

    Private Function HistoriaTieneEgreso() As Boolean
        Dim objConseguirDatos As New BLHistoriaBasica
        Dim dtDatos As DataTable
        Dim strWhere As String

        strWhere = "cod_pre_sgs='" & objDatosGenerales.Prestador & "' AND cod_sucur='" & objDatosGenerales.Sucursal & "' AND " & _
                   "tip_admision='" & objDatosPaciente.TipoAdmision & "' AND ano_adm=" & objDatosPaciente.AnoAdmision & " AND " & _
                   "num_adm = " & objDatosPaciente.NumeroAdmision & " AND clase_diag='E' AND categoria_diag='P'"
        dtDatos = objConseguirDatos.ConsultarTablasBasicas("hcimpdiagn", objConexion, "count(*) as contador", strWhere)
        If Val(dtDatos.Rows(0)("contador")) > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Function CrearEncabezadoHistoria() As Boolean

        Dim objHCB As New BLHistoriaBasica
        Dim lError As Long
        Dim Datos() As Object

        ReDim Datos(14)
        Datos(0) = objDatosGenerales.Prestador.ToString
        Datos(1) = objDatosGenerales.Sucursal.ToString
        Datos(2) = objDatosPaciente.TipoDocumento.ToString
        Datos(3) = objDatosPaciente.NumeroDocumento.ToString
        Datos(4) = objDatosPaciente.TipoAdmision.ToString
        Datos(5) = objDatosPaciente.AnoAdmision.ToString
        Datos(6) = objDatosPaciente.NumeroAdmision.ToString
        Datos(7) = objDatosPaciente.TipoHistoria.ToString
        Datos(8) = objDatosPaciente.Entidad.ToString
        Datos(9) = Format(CDate(objDatosPaciente.FechaHistoriaClinica.ToString), "yyyy/MM/dd")
        Datos(10) = Val(objDatosPaciente.HoraHistoriaClinica.ToString)
        Datos(11) = Val(objDatosPaciente.MinutoHistoriaClinica.ToString)
        Datos(12) = objDatosGenerales.CodigoEspecialidad
        Datos(13) = objDatosGenerales.Login
        Datos(14) = lError

        Try
            lError = objHCB.CrearEncabezadoHistoriaClinica(objConexion, Datos)
            If lError <> 0 Then
                MessageBox.Show("Error al Crear Encabezado Historia Clinica", "LISTA ESPERA", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Error al Crear Encabezado Historia Clinica", "LISTA ESPERA", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

        Return True


    End Function

    Private Sub AbrirHistoriaClinica()

        Dim ctlPantallaDatosPaciente As ctlDatosPaciente
        Dim ctlPantallaHistoriaBasica As HCBasica

        ctlPantallaDatosPaciente = ctlDatosPaciente.Instancia
        ctlPantallaHistoriaBasica = HCBasica.Instancia

        Dim objHCB As New BLHistoriaBasica
        Dim lError As Long

        'Dim DT As DataTable  Esta variable se deja como privada para la clase con el fin de poder utilizar
        'los valores traidos en el metodo pintarMenuHistoria() para validar el estado de la HistoriaClinica
        'Claudia Garay  28 julio 2009

  

        If dtgLista.CurrentRow Is Nothing Then
            MessageBox.Show("Seleccione un Registro de la Lista", "Lista de Espera", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If


      

        With frmHistoriaPrincipal
            .blnFirstHCBasica = True
            .blnFirstDatosPaciente = True
            .blnFirstEgresos = True
            .blnFirstEvolucion = True
            .blnFirstOrdenesMedicas = True
            .blnFirstPlanFormuExterna = True
            .blnFirstPlanIncapacidad = True
            .blnFirstPlanProcExternos = True
            .blnFirstPlanRemision = True
            .blnFirstRecomEgreso = True


        End With

        AlmacenarInformacionPaciente(dtgLista.CurrentRow)

        ''Auditoria de apertura y cierres de historia
        ''Claudia Garay 
        ''Abril 5 de 2011

        objHCB.ActualizaTablaAuditoria(objConexion, 0, objDatosGenerales.Prestador, objDatosGenerales.Sucursal,
        objDatosPaciente.TipoAdmision, objDatosPaciente.AnoAdmision, objDatosPaciente.NumeroAdmision, objDatosGenerales.Login, "A", "")

        DT = objHCB.ConsultarLoginEstadoEncabezadoHC(objConexion, objDatosGenerales.Prestador, objDatosGenerales.Sucursal,
                                                       objDatosPaciente.TipoAdmision, objDatosPaciente.AnoAdmision, objDatosPaciente.NumeroAdmision, lError)

        '' En este arreglo se almacenara el tipo y documento del paciente que se esta
        '' consultando con el fin de predeterminar estos datos al volver a la lista de espera
        '' e intentar imprimir por alli la historia clinica
        '' Claudia Garay 12 agosto 2009
        '' Solicitud = Enrique Forero

        DatosBasicosPac.Clear()
        DatosBasicosPac.Add(objDatosPaciente.NumeroDocumento)
        DatosBasicosPac.Add(objDatosPaciente.TipoDocumento)
        If lError <> 0 Then
            Exit Sub
        End If

        If Not DT Is Nothing Then
            If DT.Rows(0).Item("estado").ToString = "E" Then
                MessageBox.Show("La Historia Clínica ya  ha sido Egresada por el Dr. " & DT.Rows(0).Item("Login").ToString)
                Exit Sub
            Else
                If DT.Rows(0).Item("estado").ToString = "P" And
                    UCase(DT.Rows(0).Item("Login").ToString) <> UCase(objDatosGenerales.Login) Then
                    MessageBox.Show("La Historia Clínica se encuentra en estado Pendiente para el Dr. " & DT.Rows(0).Item("Login").ToString)
                    Exit Sub
                End If
            End If
        End If

        If blnCrearEncabezadoHC = True Then
            If CrearEncabezadoHistoria() = False Then
                Exit Sub
            End If
        End If


        Dim controlListaEspera As ListaEspera
        controlListaEspera = ListaEspera.Instancia
        controlListaEspera.Hide()

        pintarMenuHistoria()



        Me.ParentForm.Controls("pnlContenedorPantallas").Controls("pnlInfoDatosPaciente").Visible = True
        Me.ParentForm.Controls("pnlContenedorPantallas").Visible = True
        Me.ParentForm.Controls("pnlContenedorSecciones").Visible = True
        'Me.ParentForm.Controls("pnlContenedorPantallas").Controls("pnlContenedorDatosPaciente").Controls.Clear()



        If frmHistoriaPrincipal.blnCtlDatosPaciente = False Then
            ctlPantallaDatosPaciente.Dock = DockStyle.Fill
            ctlPantallaDatosPaciente.Size = Me.ParentForm.Controls("pnlContenedorPantallas").Controls("pnlContenedorDatosPaciente").Size
            Me.ParentForm.Controls("pnlContenedorPantallas").Controls("pnlContenedorDatosPaciente").Controls.Add(ctlPantallaDatosPaciente)
            frmHistoriaPrincipal.blnCtlDatosPaciente = True
            ctlPantallaDatosPaciente.Show()
        End If

        'Me.ParentForm.Controls("pnlContenedorPantallas").Controls("pnlContenedorDatos").Controls.Clear()

        If frmHistoriaPrincipal.strNameControlLoad.Trim.Length > 0 And frmHistoriaPrincipal.strNameControlLoad.ToUpper <> "HCBASICA" Then
            Me.ParentForm.Controls("pnlContenedorPantallas").Controls("pnlContenedorDatos").Controls(frmHistoriaPrincipal.strNameControlLoad).Visible = False
            frmHistoriaPrincipal.strNameControlLoad = "HCBasica"
        End If


        If frmHistoriaPrincipal.blnCtlHCBasica = False Then
            ctlPantallaHistoriaBasica.Dock = DockStyle.Fill
            ctlPantallaHistoriaBasica.Size = Me.ParentForm.Controls("pnlContenedorPantallas").Controls("pnlContenedorDatos").Size
            ctlPantallaHistoriaBasica.AutoScroll = True
            Me.ParentForm.Controls("pnlContenedorPantallas").Controls("pnlContenedorDatos").Controls.Add(ctlPantallaHistoriaBasica)
            frmHistoriaPrincipal.blnCtlHCBasica = True
            ctlPantallaHistoriaBasica.Show()
            frmHistoriaPrincipal.strNameControlLoad = "HCBasica"
        Else
            Me.ParentForm.Controls("pnlContenedorPantallas").Controls("pnlContenedorDatos").Controls("HCBasica").Visible = True
        End If

        ''2019-03-11 Inicio. Se Registra la apertura de la historia clinica
        ''Juan Carlos Jaramillo Lozano - IG
        RptHC_Enf_Med.RptHC_Enf_Med_FormEstado(objConexion, "1", "A", "")
        ''2019-03-11 Fin

        'Se adiciona validacion para mostrar el boton de paciente 360
        ' eloaiza@intergrupo.com   17/09/2019
        If Me.ParentForm.Controls("btn360Layout").Visible = False Then
            Me.ParentForm.Controls("btn360Layout").Visible = True
        End If
        'Fin


        Me.Parent.Visible = False
        'Me.Parent.Controls.Clear()
    End Sub

    Private Sub cmdAbrirHistoria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbrirHistoria.Click
        If objDatosGenerales.SoloConsultaFarma = True Then
            cmdAbrirHistoria.Enabled = False
        Else
            AbrirHistoriaClinica()
        End If

    End Sub

    Private Sub dtgLista_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgLista.CellDoubleClick
        If objDatosGenerales.SoloConsultaFarma = True Then
            cmdAbrirHistoria.Enabled = False
        Else
            AbrirHistoriaClinica()
        End If
    End Sub

    Private Function ConsultarDocumentosUnificados() As DataTable
        Dim objHCB As New BLHistoriaBasica
        Dim lError As Long
        Dim Datos() As Object
        Dim dtDocs As New DataTable

        ReDim Datos(2)
        Datos(0) = objDatosPaciente.NumeroDocumento
        Datos(1) = objDatosPaciente.TipoDocumento
        Datos(2) = objDatosPaciente.Unificado

        Try
            dtDocs = objHCB.ConsultarDocumentosUnificados(objConexion, lError, Datos)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "LISTA ESPERA", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return dtDocs


    End Function

    Public Sub pintarMenuHistoria()
        Dim ubicacion As Double
  

        With Me.ParentForm.Controls("pnlTitulo")
            CType(.Controls("pnlListaHCBasica").Controls("cmdHistoriaBasica"), Button).Image = My.Resources.act_10
            'TODO: CAMBIAR LA IMAGEN AL TITULO DE HISTORIA BASICA
            CType(.Controls("pcTitulo"), PictureBox).Image = My.Resources.tit_historia_basica
            'Me.ParentForm.BackgroundImage = My.Resources.fondo_historia

            'Para los tipos de admision A(Cirugia), H(Hospitalizacion) y U(Urgencias) se muestran
            'todas las opciones de menu al abrir la historia.
            If objDatosPaciente.TipoAdmision = "A" Or objDatosPaciente.TipoAdmision = "H" Or _
               objDatosPaciente.TipoAdmision = "U" Then

                'Localizacion de los paneles
                .Controls("pnlOrdenesEvolEgreso").Size = New System.Drawing.Size(310, 31)
                .Controls("pnlOrdenesEvolEgreso").Controls("btnOrdenes").Visible = True
                .Controls("pnlOrdenesEvolEgreso").Controls("btnEgreso").Visible = True
                .Controls("pnlOrdenesEvolEgreso").Left = .Controls("pnlListaHCBasica").Left + .Controls("pnlListaHCBasica").Size.Width
                .Controls("btnProgramas").Left = .Controls("pnlOrdenesEvolEgreso").Left + .Controls("pnlOrdenesEvolEgreso").Size.Width - 35
                .Controls("btnPlanManejo").Left = .Controls("btnProgramas").Left + .Controls("btnProgramas").Size.Width
                .Controls("pnlMenuInicial").Left = .Controls("btnPlanManejo").Left + .Controls("btnPlanManejo").Size.Width
           
                'Paneles Visibles
                .Controls("pnlListaHCBasica").Visible = True
                .Controls("btnPlanManejo").Visible = True
                .Controls("pnlOrdenesEvolEgreso").Visible = True
                .Controls("pnlMenuInicial").Visible = True
                .Controls("pnlMenuPlanManejo").Visible = False
                .Controls("pnlMenuConsultas").Visible = False
                .Controls("btnProgramas").Visible = True

                'Mostrar botones que aplican a estas admisiones
                .Controls("pnlMenuConsultas").Controls("btnConsultaOrdenesMedicas").Visible = True
                ubicacion = .Controls("pnlMenuConsultas").Controls("btnConsultaOrdenesMedicas").Left + .Controls("pnlMenuConsultas").Controls("btnConsultaOrdenesMedicas").Size.Width
                .Controls("pnlMenuConsultas").Controls("btnConsultaResultados").Left = ubicacion
                .Controls("pnlMenuPlanManejo").Controls("btnRemisiones").Visible = True
                ubicacion = .Controls("pnlMenuPlanManejo").Controls("btnRemisiones").Left + .Controls("pnlMenuPlanManejo").Controls("btnRemisiones").Size.Width
                .Controls("pnlMenuPlanManejo").Controls("btnRecomendaciones").Left = ubicacion
                ubicacion = .Controls("pnlMenuPlanManejo").Controls("btnRecomendaciones").Left + .Controls("pnlMenuPlanManejo").Controls("btnRecomendaciones").Size.Width
                .Controls("pnlMenuPlanManejo").Controls("btnContrareferencia").Left = ubicacion
          

                'Se ingresa esta validacion para mostrar la opcion de evolucion para admisiones Tipo P y E e HC
                'estado P y L
                'Solicitado por Enrique Forero
                'Realizado por Claudia Garay
                '28 julio 2009


            ElseIf (objDatosPaciente.TipoAdmision = "P" Or objDatosPaciente.TipoAdmision = "E") And (DT.Rows(0).Item("estado").ToString = "P" Or DT.Rows(0).Item("estado").ToString = "L") Then

          

                ''Para Perú debe permitir hacer ordenes intrahopitalarias cpgaray Octubre 24 de 2013
                objDatosGenerales = Generales.Instancia
                If objDatosGenerales.Pais = "482" Then
                    .Controls("pnlOrdenesEvolEgreso").Controls("btnOrdenes").Visible = True
                    .Controls("pnlMenuConsultas").Controls("btnConsultaOrdenesMedicas").Visible = True
                    .Controls("pnlOrdenesEvolEgreso").Size = New System.Drawing.Size(250, 31)

                Else
                    .Controls("pnlMenuConsultas").Controls("btnConsultaResultados").Left = .Controls("pnlMenuConsultas").Controls("btnConsultaOrdenesMedicas").Left
                    .Controls("pnlOrdenesEvolEgreso").Controls("btnOrdenes").Visible = False
                    .Controls("pnlMenuConsultas").Controls("btnConsultaOrdenesMedicas").Visible = False
                    .Controls("pnlOrdenesEvolEgreso").Size = New System.Drawing.Size(78, 31)
                End If

                'Localizacion de los paneles                 
                .Controls("pnlOrdenesEvolEgreso").Left = .Controls("pnlListaHCBasica").Left + .Controls("pnlListaHCBasica").Size.Width
                .Controls("btnPlanManejo").Left = .Controls("pnlOrdenesEvolEgreso").Left + .Controls("pnlOrdenesEvolEgreso").Size.Width + .Controls("btnProgramas").Size.Width
                .Controls("btnProgramas").Left = .Controls("pnlOrdenesEvolEgreso").Left + .Controls("pnlOrdenesEvolEgreso").Size.Width
                .Controls("pnlMenuInicial").Left = .Controls("btnPlanManejo").Left + .Controls("btnPlanManejo").Size.Width
                .Controls("pnlMenuConsultas").Left = .Controls("pnlMenuInicial").Left

                'Paneles Visibles
                .Controls("pnlListaHCBasica").Visible = True
                .Controls("btnPlanManejo").Visible = True
                .Controls("pnlOrdenesEvolEgreso").Visible = True
                .Controls("pnlMenuInicial").Visible = True
                .Controls("pnlMenuPlanManejo").Visible = False
                .Controls("pnlMenuConsultas").Visible = False
                .Controls("btnProgramas").Visible = True



                'Ocultar botones que no aplican a estas admisiones

                .Controls("pnlOrdenesEvolEgreso").Controls("btnEgreso").Visible = False
                .Controls("pnlOrdenesEvolEgreso").Controls("btnEvolucion").Left = .Controls("pnlMenuInicial").Controls("btnConsultas").Left                                
                .Controls("pnlMenuPlanManejo").Controls("btnRemisiones").Visible = False
                .Controls("pnlMenuPlanManejo").Controls("btnRecomendaciones").Left = .Controls("pnlMenuPlanManejo").Controls("btnRemisiones").Left
                ubicacion = .Controls("pnlMenuPlanManejo").Controls("btnRecomendaciones").Left + .Controls("pnlMenuPlanManejo").Controls("btnRecomendaciones").Size.Width
                .Controls("pnlMenuPlanManejo").Controls("btnContrareferencia").Left = ubicacion

            ElseIf objDatosPaciente.TipoAdmision = "P" Or objDatosPaciente.TipoAdmision = "E" Then

                'Para los tipos de admision P(Procedimientos) y E(Consulta externa) no se muestran
                'todas las opciones de menu ordenes, egreso y evolucion
                'Localizacion de los paneles 
                '.Controls("btnPlanManejo").Left = .Controls("pnlListaHCBasica").Left + .Controls("pnlListaHCBasica").Size.Width
                .Controls("btnPlanManejo").Left = .Controls("btnProgramas").Left + .Controls("btnProgramas").Size.Width
                .Controls("pnlMenuInicial").Left = .Controls("btnPlanManejo").Left + .Controls("btnPlanManejo").Size.Width
                .Controls("pnlMenuConsultas").Left = .Controls("pnlMenuInicial").Left

                'Paneles Visibles
                .Controls("pnlListaHCBasica").Visible = True
                .Controls("btnPlanManejo").Visible = True
                .Controls("pnlOrdenesEvolEgreso").Visible = False
                .Controls("pnlMenuInicial").Visible = True
                .Controls("pnlMenuPlanManejo").Visible = False
                .Controls("pnlMenuConsultas").Visible = False
                .Controls("btnProgramas").Visible = True


                'Ocultar botones que no aplican a estas admisiones
                .Controls("pnlMenuConsultas").Controls("btnConsultaOrdenesMedicas").Visible = False
                .Controls("pnlMenuConsultas").Controls("btnConsultaResultados").Left = .Controls("pnlMenuConsultas").Controls("btnConsultaOrdenesMedicas").Left
                .Controls("pnlMenuPlanManejo").Controls("btnRemisiones").Visible = False
                .Controls("pnlMenuPlanManejo").Controls("btnRecomendaciones").Left = .Controls("pnlMenuPlanManejo").Controls("btnRemisiones").Left
                ubicacion = .Controls("pnlMenuPlanManejo").Controls("btnRecomendaciones").Left + .Controls("pnlMenuPlanManejo").Controls("btnRecomendaciones").Size.Width
                .Controls("pnlMenuPlanManejo").Controls("btnContrareferencia").Left = ubicacion
            End If

        End With
    End Sub

    Private Sub ListaEspera_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged

        Dim dtDatosLista As New DataTable
        Dim objConseguirDatos As New BLHistoriaBasica
        Dim lError As Long
        Dim Datos() As Object = Nothing
        Dim intRow As Integer

        If sender.Visible = True Then

            LimpiarDatos()
            If blnConsultaLista = True Then
                dtDatosLista = objConseguirDatos.ConsultarDatosPacientes(strProcedimientoConseguirDatos, objConexion, lError, DatosConsulta)
                If lError = 9999 Then
                    blnConsultaLista = False
                    LimpiarDatos()
                    calLista.TodayDate = Now
                    HabilitarControles(False)
                Else
                    For intRow = 0 To dtDatosLista.Rows.Count - 1
                        If dtDatosLista.Rows(intRow).Item("edad") Is DBNull.Value Then
                            dtDatosLista.Rows(intRow).Item("descEdad") = ""
                        End If
                    Next
                    Me.dtgLista.Enabled = True
                    Me.cmdAbrirHistoria.Enabled = False
                End If

                If dtDatosLista.Rows.Count > 0 Then
                    dtDatosLista.DefaultView.Sort = "fec_ingreso, hor_ingreso, min_ingreso"
                    Me.dtgLista.DataSource = dtDatosLista
                Else
                    dtgLista.DataSource = dtClearDatos
                    calLista.TodayDate = Now
                    HabilitarControles(False)
                    'frmHistoriaPrincipal.blnCtlHCBasica = False
                End If

            Else
                dtgLista.DataSource = dtClearDatos
                ConfigurarGrilla()
                calLista.TodayDate = Now
                HabilitarControles(False)
            End If
        End If
        InhabilitarPeru()
    End Sub

    Private Sub LimpiarDatos()
        If blnConsultaLista = False Then
            rbUrgencias.Checked = False
            rbCirugia.Checked = False
            rbHospitalizacion.Checked = False
            rbEvolucion.Checked = False
            rbCE.Checked = False
            rbProAdt.Checked = False
            rbPendientes.Checked = False
        End If
        txtCodigoTipoDocumento.ResetText()
        txtDescTipoDocumento.ResetText()
        txtNumeroDocumento.ResetText()
        txtTipoAdmision.ResetText()
        txtAnoAdmision.ResetText()
        txtNumeroAdmision.ResetText()
        txtNumeroCama.ResetText()
        pcFoto.Image = Nothing
    End Sub

    Private Sub InhabilitarPeru()

        If objDatosGenerales.Pais = "482" Then
            rbUrgencias.Enabled = False
            rbCirugia.Enabled = False
            rbEvolucion.Enabled = False
            rbHospitalizacion.Enabled = False
        End If
    End Sub

    Private Sub dtgLista_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgLista.CellContentClick
        AlmacenarInformacionPaciente(dtgLista.CurrentRow)
    End Sub

    Private Sub dtgLista_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgLista.CellMouseClick
        AlmacenarInformacionPaciente(dtgLista.CurrentRow)
    End Sub
End Class
