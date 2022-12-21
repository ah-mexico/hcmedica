Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.HistoriaBasica
Imports HistoriaClinica.Sophia.HistoriaClinica.BL


' -----------------------------------------------------------------------------
' Project	 : HistoriaClinica.ctlPlanRemision
' Class	 : Sophia.HistoriaClinica.ctlPlanRemision
' -----------------------------------------------------------------------------
' Clase ctlPlanRemision del namespace Sophia.HistoriaClinica.ctlPlanRemision que 
' es la clase base. Esta clase tiene la funcionalidad del control de usuario para 
' las remisiones en el plan de manejo y será usado en la aplicación cliente en Windows Form 2005
' -----------------------------------------------------------------------------

Public Class ctlPlanRemision
    Private objConexion As Conexion
    Private objRemision As PlanRemision
    Private objGeneral As Generales
    Private objPaciente As Paciente
    Private strFechaSistema As String
    Private objEgreso As Egreso
    Private objDatosHistoriaBasica As DatosHistoriaBasica
    Private Shared _Instancia As ctlPlanRemision
    Public SeGuardoRemision As Boolean = True ''cpgaray

#Region "Instancia de Control"
    Public Shared ReadOnly Property Instancia() As ctlPlanRemision
        Get
            If _Instancia Is Nothing Then
                _Instancia = New ctlPlanRemision
            End If
            Return _Instancia
        End Get
    End Property
#End Region

#Region "Salir"
    Private Sub ctlPlanRemision_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave

    End Sub

    Public Sub disposeSingletonRemision()
        ''Si se ha cargado una contrareferencia se debe limpiar el objeto 
        ''que guarda la informacion de la remision 
        'If objRemision.Contrareferencia = True Then
        '    objRemision.Dispose()
        'End If
    End Sub

    Private Sub ctlPlanRemision_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        rbTrasladoambNo.Checked = False
        rbTrasladoambSi.Checked = False
        If SeGuardoRemision = True Then
            If sender.Visible = True Then
                LimpiarDatos()
                IniciarPlanRemision()
                If frmHistoriaPrincipal.blnFirstPlanRemision = True Then
                    frmHistoriaPrincipal.blnFirstPlanRemision = False
                End If
            Else
                If objRemision.PermiteLimpiarReferencia = True Then
                    objRemision.PermiteLimpiarReferencia = False
                    objRemision.Estado = objRemision.EstadoOriginal
                    objRemision.EstadoOriginal = ""
                    objRemision.DatosImpresionDiagnostica = Nothing
                    pnlInfoImpresionDiagnostica.Visible = False
                    LimpiarDatos()
                    HabilitarCampos()
                    objRemision.Contrareferencia = False
                    objRemision.Limpiar()
                    IniciarPlanRemision()
                    mostrarControlesContrarreferencia(False)
                End If
                'disposeSingletonRemision()
                'FinalizarPlanRemision()
            End If
        End If
    End Sub

    Private Sub LimpiarDatos()
        mtFechaInicial.ResetText()
        tbHora.ResetText()
        tbMinuto.ResetText()
        tbCodEntidad.ResetText()
        cbEntidad.ResetText()
        tbServicio.ResetText()
        tbMedicoConfirma.ResetText()
        tbCargoMedico.ResetText()
        tbNumeroAutoriza.ResetText()
        mkFechaAutoriza.ResetText()
        tbHoraAutoriza.ResetText()
        tbMinutoAutoriza.ResetText()
        tbCodigoAmbulancia.ResetText()
        tbDesAmbulancia.ResetText()
        cbNivel.ResetText()
        tbAnamnesis.ResetText()
        tbAuxiliares.ResetText()
        tbEvolucion.ResetText()
        tbDiagnostico.ResetText()
        ' tbComplicaciones.ResetText() cpgaray se unifican campos
        ' tbTratamientos.ResetText() cpgaray se unifican campos
        tbMotivos.ResetText()
        'tbEstadoPaciente.ResetText()
        txtObs.ResetText()
        txtRespuesta.ResetText()
    End Sub

#End Region

#Region "Load"

    Private Sub ctlPlanRemision_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        frmHistoriaPrincipal.blnFirstPlanRemision = False

        objConexion = Conexion.Instancia
        objRemision = PlanRemision.Instancia
        objGeneral = Generales.Instancia
        objPaciente = Paciente.Instancia
        objEgreso = Egreso.Instancia
        objDatosHistoriaBasica = DatosHistoriaBasica.Instancia
        SeGuardoRemision = True
        ValoresIniciales()
        IniciarPlanRemision()
    End Sub

    Private Sub IniciarPlanRemision()
        Dim objBl As New Sophia.HistoriaClinica.BL.BLPlanManejo
        strFechaSistema = Format(CDate(FuncionesGenerales.FechaServidor()), "dd/MM/yyyy")

        'Consultar datos, cuando queda en espera
        Dim lError As Long

        ''Si la remision es una contrareferencia no debe consultarla pues se carga 
        ''en el objeto cuando se abre en la pantalla frmReferencias
        If objRemision.Contrareferencia = False Then
            If objRemision.Estado = "G" Or objRemision.Estado = "" Then
                Try
                    lError = objBl.ConsultarRemision(objConexion, objRemision)
                Catch ex As Exception
                    MsgBox("Error al consultar datos", MsgBoxStyle.Exclamation)
                End Try
            End If
            'Este resumen de evolución es independiente al del egreso
            'cpgaray 
            'objBl.consultarResumenEvolucion(objConexion, objRemision) 
            mostrarControlesContrarreferencia(False)

            '*************REF-CONT*************************
            'If objDatosHistoriaBasica.ImpresionDiagnostica.DatosDiagnosticos.Rows.Count > 0 Then
            '    pnlInfoImpresionDiagnostica.Visible = True
            '    dtgInfoID.DataSource = objDatosHistoriaBasica.ImpresionDiagnostica.DatosDiagnosticos
            '    dtgInfoID.Height = dtgInfoID.ColumnHeadersHeight + (dtgInfoID.Rows.GetRowsHeight(DataGridViewElementStates.None))
            'End If

            '**********************************************
        Else
            mostrarControlesContrarreferencia(True)
            txtRespuesta.Text = objRemision.RepuestaContrareferencia

            '*************REF-CONT*************************
            'If Not objRemision.DatosImpresionDiagnostica Is Nothing Then
            '    If objRemision.DatosImpresionDiagnostica.Rows.Count > 0 Then
            '        pnlInfoImpresionDiagnostica.Visible = True
            '        dtgInfoID.DataSource = objRemision.DatosImpresionDiagnostica
            '        dtgInfoID.Height = dtgInfoID.ColumnHeadersHeight + (dtgInfoID.Rows.GetRowsHeight(DataGridViewElementStates.None))
            '    End If
            'End If
            '**********************************************
        End If

        If objRemision.Estado = "N" Then
            tbCodEntidad.Focus()
        End If
        If objRemision.Estado = "G" Or objRemision.Estado = "M" Then
            Invalidar()
        End If


        'If objRemision.Estado <> "" And objRemision.Estado = "G" Then
        cbEntidad.Text = objRemision.DesInstitucion
        If objRemision.CodigoInstitucion <> "" Then
            tbCodEntidad.Text = objRemision.CodigoInstitucion
            tbServicio.Focus()
        Else
            tbCodEntidad.Focus()
        End If

        tbServicio.Text = objRemision.Servicio
        tbMedicoConfirma.Text = objRemision.MedicoConfirma
        tbCargoMedico.Text = objRemision.CargoMedico
        tbDesAmbulancia.SelectedText = objRemision.DesAmbulancia
        tbCodigoAmbulancia.Text = objRemision.CodigoAmbulancia
        cbNivel.Text = objRemision.Nivel
        tbAnamnesis.Text = objRemision.Ananmesis
        tbAuxiliares.Text = objRemision.AuxiliarDiagnostico

        Select Case objRemision.TrasladoAmbulancia
            Case "N"
                rbTrasladoambNo.Checked = True
            Case "S"
                rbTrasladoambSi.Checked = True
            Case Else
                rbTrasladoambNo.Checked = False
                rbTrasladoambSi.Checked = False
        End Select


        'If objEgreso.ResumenEvolucion.Trim.Length > 0 Then
        '   tbEvolucion.Text = objEgreso.ResumenEvolucion
        '   tbEvolucion.ReadOnly = True
        'Else

        tbEvolucion.Text = objRemision.Evolucion

        If tbEvolucion.Text.Length > 0 Then
            tbEvolucion.Enabled = False
            lnkPlandemanejo.Enabled = False
        Else
            tbEvolucion.Enabled = True
            lnkPlandemanejo.Enabled = True
        End If

        'tbEvolucion.ReadOnly = True
        'End If

        'If objRemision.Estado = "" Or objRemision.Evolucion.Trim.Length = 0 Then
        '    tbEvolucion.Text = objEgreso.ResumenEvolucion
        '    tbEvolucion.ReadOnly = True
        'Else
        '    tbEvolucion.Text = objRemision.Evolucion
        'End If

        tbDiagnostico.Text = objRemision.Diagnostico
        'tbComplicaciones.Text = objRemision.Complicaciones  cpgaray se unifican campos
        'tbTratamientos.Text = objRemision.Tratamientos   cpgaray se unifican campos
        tbMotivos.Text = objRemision.Motivos
        'tbEstadoPaciente.Text = objRemision.EstadoPaciente
        tbNumeroAutoriza.Text = objRemision.NumeroAutorizacion
        If objRemision.HoraAutorizacion >= 0 Then
            tbHoraAutoriza.Text = objRemision.HoraAutorizacion
        Else
            tbHoraAutoriza.Text = ""
        End If
        If objRemision.MinutoAutorizacion >= 0 Then
            tbMinutoAutoriza.Text = objRemision.MinutoAutorizacion
        Else
            tbMinutoAutoriza.Text = ""
        End If

        If objRemision.FechaAutorizacion <> "" Then
            mkFechaAutoriza.Text = objRemision.FechaAutorizacion
        Else

            mkFechaAutoriza.Text = strFechaSistema
        End If

        txtObs.Text = objRemision.Observaciones


        'Else
        'ValoresIniciales()
        'tbCodEntidad.Focus()
        ' End If


        'If objGeneral.Contingencia Then
        Dim dtFecha As Date
        dtFecha = FuncionesGenerales.FechaServidor()
        PFecha.Enabled = False
        mtFechaInicial.Text = Format(dtFecha, "dd/MM/yyyy")
        tbHora.Text = Hour(dtFecha)
        tbMinuto.Text = Minute(dtFecha)
        ' mtFechaInicial.Focus()
        ''tbCodEntidad.Focus()
        'Else
        'PFecha.Visible = False
        'End If
        ActualizarInformacionControles()
    End Sub

    Private Sub FinalizarPlanRemision()
        CargarValoresObjeto()
        If Reimpresion() = False And objRemision.Estado <> "N" Then
            objRemision.Estado = "M"
        End If
    End Sub

    Public Sub mostrarControlesContrarreferencia(ByVal esVisible As Boolean)
        pnlContrarreferencia.Visible = esVisible
        'lblRespuesta.Visible = esVisible
        'txtRespuesta.Visible = esVisible

        If objRemision.ContrareferenciaCerrada = "S" Then
            txtRespuesta.ReadOnly = True
        Else
            txtRespuesta.ReadOnly = False
            txtRespuesta.Enabled = True
        End If

    End Sub

#End Region

#Region "ValoresIniciales"
    Private Sub ValoresIniciales()
        Dim obj As New Sophia.HistoriaClinica.BL.BLPlanManejo

        '// Llenamos los controles para las listas Inciales \\
        '/ para las entidades \
        tbCodEntidad.ControlComboEnlace = cbEntidad
        With cbEntidad
            .CampoMostrar = "descripcion"
            .ControlTextoEnlace = tbCodEntidad
            .CampoEnlazado = "codigo"
            .CategoriaDatos = CategoriaDatos.Entidades
            .Login = objGeneral.Login
            .EdadPaciente = 0
            .SexoPaciente = "M"
            .CargarDatos()
            .CargarButton()
        End With

        '/ para las empresas de ambulancias \
        Me.tbDesAmbulancia.NombreCampoDatos = "descripcion"
        tbCodigoAmbulancia.NombreCampoBusqueda = "ambulancia"
        tbCodigoAmbulancia.NombreCampoBuscado = "descripcion"
        tbCodigoAmbulancia.ControlTextoEnlace = tbDesAmbulancia
        tbDesAmbulancia.ControlTextoEnlace = tbCodigoAmbulancia
        tbDesAmbulancia.OrigenDeDatos = obj.ConsultarEmpresaAmbulancia(objConexion)
        tbDesAmbulancia.CargarDatosDescripcion()
        cbNivel.DataSource = obj.ConsultarNiveles
        cbNivel.DisplayMember = "Descripcion"
        cbNivel.ValueMember = "Nivel"
        strFechaSistema = Format(FuncionesGenerales.FechaServidor, "dd/MM/yyyy")
        mkFechaAutoriza.Text = strFechaSistema
    End Sub

    Private Sub ActualizarInformacionControles()
        cbEntidad.Tag = cbEntidad.Text
        tbCodEntidad.Tag = tbCodEntidad.Text
        tbServicio.Tag = tbServicio.Text
        tbMedicoConfirma.Tag = tbMedicoConfirma.Text
        tbCargoMedico.Tag = tbCargoMedico.Text
        tbNumeroAutoriza.Tag = tbNumeroAutoriza.Text
        mkFechaAutoriza.Tag = mkFechaAutoriza.Text
        tbHoraAutoriza.Tag = tbHoraAutoriza.Text
        tbMinutoAutoriza.Tag = tbMinutoAutoriza.Text
        tbCodigoAmbulancia.Tag = tbCodigoAmbulancia.Text
        tbDesAmbulancia.Tag = tbDesAmbulancia.Text
        cbNivel.Tag = cbNivel.Text
        tbAnamnesis.Tag = tbAnamnesis.Text
        tbAuxiliares.Tag = tbAuxiliares.Text
        tbEvolucion.Tag = tbEvolucion.Text
        tbDiagnostico.Tag = tbDiagnostico.Text
        'tbComplicaciones.Tag = tbComplicaciones.Text  cpgaray se unifican campos
        'tbTratamientos.Tag = tbTratamientos.Text  cpgaray se unifican campos
        tbMotivos.Tag = tbMotivos.Text
        'tbEstadoPaciente.Tag = tbEstadoPaciente.Text
        txtObs.Tag = txtObs.Text
        txtRespuesta.Tag = txtRespuesta.Text
    End Sub
#End Region

#Region "Grabar"
    Private Sub btGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGrabar.Click
        Dim objBl As New Sophia.HistoriaClinica.BL.BLPlanManejo
        Dim bError As Boolean = True
        Dim lerror As Long
        Dim strFecha As String = ""
        Dim dteFechaActual As String
        Dim blnReimpresion As Boolean
        Dim strFechaRemision As String
        Dim RequiereAmb As String = ""


        If objRemision.Estado = "M" Then
            blnReimpresion = False
            objRemision.Estado = "G"
        ElseIf objRemision.Estado <> "N" Then
            blnReimpresion = Reimpresion()
        End If

        bError = VerificarDatos()
        If bError Then

            ''Se realiza la actualizacion de la remision para guardar la 
            ''contrareferencia
            If objRemision.Contrareferencia = True Then
                lerror = objBl.GrabarPlanRemisionContrareferencia(objConexion, objRemision.PrestadorOrigen,
                               objRemision.SucursalOrigen, objPaciente.TipoDocumento, objPaciente.NumeroDocumento,
                               objRemision.FechaRemision, objRemision.HoraRemision, objRemision.MinutoRemision,
                               objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                               objPaciente.AnoAdmision, objPaciente.NumeroAdmision, txtRespuesta.Text, mtFechaInicial.Text, "S")

                If lerror = 0 Then
                    objRemision.Estado = "G"
                    objRemision.ContrareferenciaCerrada = "S"
                    objGeneral.HistoriaClinicaTieneModificaciones = True
                    Invalidar()
                    'ImprimirReporte(objRemision.PrestadorOrigen, objRemision.SucursalOrigen, _
                    '                objPaciente.TipoDocumento, objPaciente.NumeroDocumento, _
                    '                objRemision.TipoAdmisionOrigenR, objRemision.AnoAdmisionOrigenR, _
                    '                objRemision.NumeroAdmisionOrigenR, False)
                Else
                    If lerror = 17 Then
                        MsgBox("No hay datos para grabar")
                    Else
                        MsgBox("La remisión no se grabó, por favor verifique los datos", MsgBoxStyle.Exclamation)
                    End If
                End If

                Exit Sub
            End If



            dteFechaActual = FuncionesGenerales.FechaServidor()
            strFecha = mkFechaAutoriza.Text
            If objRemision.FechaRemision.Trim.Length = 0 Then
                strFechaRemision = ""
            Else
                strFechaRemision = Format(CDate(objRemision.FechaRemision), "dd/MM/yyyy")
            End If
            Try
                If blnReimpresion = False Then

                    ''cpgaray
                    If rbTrasladoambNo.Checked = True Then
                        RequiereAmb = "N"
                    ElseIf rbTrasladoambSi.Checked = True Then
                        RequiereAmb = "S"
                    Else
                        RequiereAmb = ""
                    End If


                    lerror = objBl.GrabarPlanRemision(objConexion, IIf(objRemision.Estado = "G", 1, 0), Trim(tbCodEntidad.Text),
                                Trim(cbEntidad.Text), Trim(tbServicio.Text), Trim(tbMedicoConfirma.Text),
                                Trim(tbCargoMedico.Text), Trim(tbCodigoAmbulancia.Text),
                                Trim(tbDesAmbulancia.Text), Trim(cbNivel.SelectedValue),
                                "", Trim(tbAuxiliares.Text),
                                Trim(tbEvolucion.Text), Trim(tbDiagnostico.Text),
                                "", "",
                                Trim(tbMotivos.Text), "",
                                Format(CDate(dteFechaActual), "dd/MM/yyyy"), Hour(dteFechaActual), Minute(dteFechaActual),
                                strFechaRemision, objRemision.HoraRemision, objRemision.MinutoRemision,
                                Trim(tbNumeroAutoriza.Text), strFecha, CInt(tbHoraAutoriza.Text), CInt(tbMinutoAutoriza.Text),
                                txtObs.Text, RequiereAmb)

                    If lerror = 0 Then
                        objRemision.Estado = "G"
                        tbEvolucion.ReadOnly = True
                        lnkPlandemanejo.Enabled = False
                        objGeneral.HistoriaClinicaTieneModificaciones = True
                        'MsgBox("La remisión se grabó correctamente", MsgBoxStyle.Information)
                        Invalidar()
                        ActualizarInformacionControles()
                        objRemision.FechaRemision = Format(CDate(dteFechaActual), "dd/MM/yyyy")
                        objRemision.HoraRemision = Hour(dteFechaActual)
                        objRemision.MinutoRemision = Minute(dteFechaActual)
                        CargarValoresObjeto()
                        ImprimirReporte(objGeneral.Prestador, objGeneral.Sucursal,
                                        objPaciente.TipoDocumento, objPaciente.NumeroDocumento,
                                        objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision, blnReimpresion)

                    Else
                        '/ Ingresar valores a la variable global
                        MsgBox("La remisión no se grabó, por favor verifique los datos", MsgBoxStyle.Exclamation)
                        If objRemision.Estado <> "G" Then
                            objRemision.Estado = "N"
                        End If
                    End If
                Else
                    ImprimirReporte(objGeneral.Prestador, objGeneral.Sucursal,
                                    objPaciente.TipoDocumento, objPaciente.NumeroDocumento,
                                    objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision, blnReimpresion)
                End If
            Catch ex As Exception
                If blnReimpresion = False Then
                    If objRemision.Estado <> "G" Then
                        objRemision.Estado = "N"
                    End If

                    '***** para el control de errores ....*****
                    MessageBox.Show("El proceso de grabación de la remisión falló por: " & ex.Message, "Historia Clínica", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("No se pudo realizar la Reimpresión de la Remisión", "Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Try
        End If

    End Sub
#End Region

#Region "VerificarDatos - al grabar"
    Public Function VerificarDatos() As Boolean
        VerificarDatos = True
        Dim strMensaje As String = ""
        'If objGeneral.Contingencia Then
        If Not IsDate(mtFechaInicial.Text) Or mtFechaInicial.Text = "  /  /" Then
            strMensaje = "Fecha de la remisión" & Chr(13)
            mtFechaInicial.Focus()
        End If
        If tbHora.Text.Length > 0 Then
            If tbHora.Text > 23 Or (Not IsNumeric(tbHora.Text) Or tbHora.Text < 0) Then
                strMensaje = strMensaje & "Hora de la remisión" & Chr(13)
                tbHora.Focus()
            End If
            'Else
            '    strMensaje = strMensaje & "Hora de la remisión" & Chr(13)
            '    tbHora.Focus()
            '    'VerificarDatos = False
        End If
        If tbMinuto.Text.Length > 0 Then
            If tbMinuto.Text > 59 Or (Not IsNumeric(tbMinuto.Text) Or tbMinuto.Text < 0) Then
                strMensaje = strMensaje & "Minutos de la remisión" & Chr(13)
                tbMinuto.Focus()
            End If
            'Else
            '    strMensaje = strMensaje & "Minutos de la remisión" & Chr(13)
            '    tbMinuto.Focus()
            '    'VerificarDatos = False
        End If
        'End If



        If tbServicio.Text.Length = 0 Then
            If strMensaje.Length = 0 Then
                tbServicio.Focus()
            End If
            strMensaje = strMensaje & "Servicio" & Chr(13)

            'VerificarDatos = False
        End If
        ''Los antecedentes y motivos de remision son de obligatorio diligenciamiento
        ''Cpgaray Enero 2 de 2012
        If tbAuxiliares.Text.Length = 0 Then
            If strMensaje.Length = 0 Then
                tbAuxiliares.Focus()
            End If
            strMensaje = strMensaje & "Antecedentes" & Chr(13)

            'VerificarDatos = False
        End If

        If Len(tbEvolucion.Text) = 0 Then
            If strMensaje.Length = 0 Then
                Me.tbEvolucion.Focus()
            End If
            strMensaje = strMensaje & "Exámen Físico diagnostico y plan de manejo" & Chr(13)

        End If

        '' Enfermeria II Fase 
        '' Claudia Garay
        '' Enero 2 de 2012

        'If tbDiagnostico.Text.Length = 0 Then
        '    strMensaje = strMensaje & "Resumen de Evolución y Condición al Egreso" & Chr(13)
        '    tbDiagnostico.Focus()
        '    'VerificarDatos = False
        'End If

        ''Fin cpgaray

        If tbMotivos.Text.Length = 0 Then
            If strMensaje.Length = 0 Then
                tbMotivos.Focus()
            End If
            strMensaje = strMensaje & "Motivos de Remisión" & Chr(13)

            'VerificarDatos = False
        End If
        ''Fin cpgaray


        'If tbMedicoConfirma.Text.Length = 0 Then
        '    strMensaje = strMensaje & "Persona quien confirma" & Chr(13)
        '    tbMedicoConfirma.Focus()
        '    ' VerificarDatos = False
        'End If
        'If tbCargoMedico.Text.Length = 0 Then
        '    strMensaje = strMensaje & "Cargo de la persona quien confirma" & Chr(13)
        '    tbCargoMedico.Focus()
        '    'VerificarDatos = False
        'End If
        If Not IsDate(mkFechaAutoriza.Text) Or mkFechaAutoriza.Text = "  /  /" Then
            strMensaje = strMensaje & "Fecha de autorización" & Chr(13)
            mkFechaAutoriza.Focus()
            'VerificarDatos = False
        End If
        If tbHoraAutoriza.Text.Length > 0 Then
            If Val(tbHoraAutoriza.Text) > 23 Or Val(tbHoraAutoriza.Text) < 0 Then
                strMensaje = strMensaje & "Hora de autorización" & Chr(13)
                tbHoraAutoriza.Focus()
                'VerificarDatos = False
            End If
        Else
            strMensaje = strMensaje & "Hora de autorización" & Chr(13)
            tbHoraAutoriza.Focus()
            'VerificarDatos = False
        End If
        If tbMinutoAutoriza.Text.Length > 0 Then
            If tbMinutoAutoriza.Text > 59 Or tbMinutoAutoriza.Text < 0 Then
                strMensaje = strMensaje & "Minutos de autorización" & Chr(13)
                tbMinutoAutoriza.Focus()
                'VerificarDatos = False
            End If
        Else
            strMensaje = strMensaje & "Minutos de autorización" & Chr(13)
            tbMinutoAutoriza.Focus()
            'VerificarDatos = False
        End If

        'If cbNivel.Text = "" Then
        '    strMensaje = strMensaje & "Nivel" & Chr(13)
        '    cbNivel.Focus()
        'End If

        If tbAnamnesis.Text.Length = 0 Then
            MsgBox(" Los datos de Motivo de Consulta deben ser registrados en la Historia Básica ")
            VerificarDatos = False
        End If

        If rbTrasladoambSi.Checked = True And tbDesAmbulancia.Text.Length = 0 Then
            strMensaje = strMensaje & "Ambulancia" & Chr(13)
        End If


        If objRemision.Contrareferencia = True Then
            If txtRespuesta.Text.Trim.Length = 0 Then
                strMensaje = strMensaje & "Respuesta" & Chr(13)
                Me.txtRespuesta.Focus()
            End If
        End If
        If strMensaje.Length > 0 Then
            MsgBox("Por favor ingrese correctamente" & Chr(13) & strMensaje, MsgBoxStyle.Information)
            VerificarDatos = False
        End If
    End Function
#End Region

#Region "ImprimirReporte"
    Public Sub ImprimirReporte(ByVal strPrestador As String, ByVal strSucursal As String,
                               ByVal strTipoDocumento As String, ByVal strNumeroDocumento As String,
                               ByVal strTipoAdmision As String, ByVal strAnoAdmision As Integer,
                               ByVal strNumeroAdmision As Long, ByVal blnReimpresion As Boolean)
        'frmRepRemision.Show()
        'frmRepRemision.imprimirRepRemision(objConexion, strPrestador, strSucursal,
        '                                   strTipoDocumento, strNumeroDocumento,
        '                                   strTipoAdmision, strAnoAdmision,
        '                                   strNumeroAdmision, objRemision, blnReimpresion)

        '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
        'Juan Carlos Jaramillo Lozano - IG
        RptHC_Enf_Med.Show()
        '29/12/21 Miabonilla Enviamos la impresion de correo
        RptHC_Enf_Med.ImprimirHistoriaClinica_imprimirRemision(objConexion, "51", objGeneral.Prestador, objGeneral.Sucursal,
                                                        objPaciente.TipoDocumento, objPaciente.NumeroDocumento,
                                                        objPaciente.TipoAdmision, objPaciente.AnoAdmision,
                                                        objPaciente.NumeroAdmision, objPaciente.CodHistoria, "S")
        '2019-03-11 Fin

    End Sub

    Private Function Reimpresion() As Boolean
        If Trim(cbEntidad.Tag.ToString.ToUpper) <> Trim(cbEntidad.Text.ToUpper) Then
            Reimpresion = False
            Exit Function
        End If
        If Trim(tbCodEntidad.Tag.ToString.ToUpper) <> Trim(tbCodEntidad.Text.ToUpper) Then
            Reimpresion = False
            Exit Function
        End If
        If Trim(tbServicio.Tag.ToString.ToUpper) <> Trim(tbServicio.Text.ToUpper) Then
            Reimpresion = False
            Exit Function
        End If
        If Trim(tbMedicoConfirma.Tag.ToString.ToUpper) <> Trim(tbMedicoConfirma.Text.ToUpper) Then
            Reimpresion = False
            Exit Function
        End If
        If Trim(tbCargoMedico.Tag.ToString.ToUpper) <> Trim(tbCargoMedico.Text.ToUpper) Then
            Reimpresion = False
            Exit Function
        End If
        If Trim(tbNumeroAutoriza.Tag.ToString.ToUpper) <> Trim(tbNumeroAutoriza.Text.ToUpper) Then
            Reimpresion = False
            Exit Function
        End If
        If Trim(mkFechaAutoriza.Tag.ToString.ToUpper) <> Trim(mkFechaAutoriza.Text.ToUpper) Then
            Reimpresion = False
            Exit Function
        End If
        If Trim(tbHoraAutoriza.Tag.ToString.ToUpper) <> Trim(tbHoraAutoriza.Text.ToUpper) Then
            Reimpresion = False
            Exit Function
        End If
        If Trim(tbMinutoAutoriza.Tag.ToString.ToUpper) <> Trim(tbMinutoAutoriza.Text.ToUpper) Then
            Reimpresion = False
            Exit Function
        End If
        If Trim(tbCodigoAmbulancia.Tag.ToString.ToUpper) <> Trim(tbCodigoAmbulancia.Text.ToUpper) Then
            Reimpresion = False
            Exit Function
        End If
        If Trim(tbDesAmbulancia.Tag.ToString.ToUpper) <> Trim(tbDesAmbulancia.Text.ToUpper) Then
            Reimpresion = False
            Exit Function
        End If
        If Trim(cbNivel.Tag.ToString.ToUpper) <> Trim(cbNivel.Text.ToUpper) Then
            Reimpresion = False
            Exit Function
        End If
        If Trim(tbAnamnesis.Tag.ToString.ToUpper) <> Trim(tbAnamnesis.Text.ToUpper) Then
            Reimpresion = False
            Exit Function
        End If
        If Trim(tbAuxiliares.Tag.ToString.ToUpper) <> Trim(tbAuxiliares.Text.ToUpper) Then
            Reimpresion = False
            Exit Function
        End If
        If Trim(tbEvolucion.Tag.ToString.ToUpper) <> Trim(tbEvolucion.Text.ToUpper) Then
            Reimpresion = False
            Exit Function
        End If
        If Trim(tbDiagnostico.Tag.ToString.ToUpper) <> Trim(tbDiagnostico.Text.ToUpper) Then
            Reimpresion = False
            Exit Function
        End If

        'cpgaray se unifican campos

        'If Trim(tbComplicaciones.Tag.ToString.ToUpper) <> Trim(tbComplicaciones.Text.ToUpper) Then
        '    Reimpresion = False
        '    Exit Function
        'End If
        'If Trim(tbTratamientos.Tag.ToString.ToUpper) <> Trim(tbTratamientos.Text.ToUpper) Then
        '    Reimpresion = False
        '    Exit Function
        'End If

        If Trim(tbMotivos.Tag.ToString.ToUpper) <> Trim(tbMotivos.Text.ToUpper) Then
            Reimpresion = False
            Exit Function
        End If
        'If Trim(tbEstadoPaciente.Tag.ToString.ToUpper) <> Trim(tbEstadoPaciente.Text.ToUpper) Then
        '    Reimpresion = False
        '    Exit Function
        'End If
        If Trim(txtObs.Tag.ToString.ToUpper) <> Trim(txtObs.Text.ToUpper) Then
            Reimpresion = False
            Exit Function
        End If
        If Trim(txtRespuesta.Tag.ToString.ToUpper) <> Trim(txtRespuesta.Text.ToUpper) Then
            Reimpresion = False
            Exit Function
        End If

        Reimpresion = True

    End Function
#End Region

#Region "CargarValoresObjeto"
    Private Sub CargarValoresObjeto()
        objRemision.CodigoInstitucion = Trim(tbCodEntidad.Text)
        objRemision.DesInstitucion = cbEntidad.Text
        objRemision.Servicio = Trim(tbServicio.Text)
        objRemision.MedicoConfirma = Trim(tbMedicoConfirma.Text)
        objRemision.CargoMedico = Trim(tbCargoMedico.Text)
        objRemision.CodigoAmbulancia = Trim(tbCodigoAmbulancia.Text)
        objRemision.DesAmbulancia = Trim(tbDesAmbulancia.Text)
        objRemision.Ananmesis = Trim(tbAnamnesis.Text)
        objRemision.Nivel = Trim(cbNivel.Text)
        objRemision.DesNivel = Trim(cbNivel.Text)
        objRemision.AuxiliarDiagnostico = Trim(tbAuxiliares.Text)
        objRemision.Evolucion = Trim(tbEvolucion.Text)
        objRemision.Diagnostico = Trim(tbDiagnostico.Text)
        'objRemision.Complicaciones = Trim(tbComplicaciones.Text) cpgaray se unifican campos
        'objRemision.Tratamientos = Trim(tbTratamientos.Text) cpgaray se unifican campos
        objRemision.Motivos = Trim(tbMotivos.Text)
        'objRemision.EstadoPaciente = Trim(tbEstadoPaciente.Text)
        objRemision.NumeroAutorizacion = Trim(tbNumeroAutoriza.Text)
        objRemision.FechaAutorizacion = Trim(mkFechaAutoriza.Text)
        If tbHoraAutoriza.Text.Length > 0 Then
            objRemision.HoraAutorizacion = CInt(tbHoraAutoriza.Text)
        End If
        If tbMinutoAutoriza.Text.Length > 0 Then
            objRemision.MinutoAutorizacion = CInt(tbMinutoAutoriza.Text)
        End If
        objRemision.Observaciones = txtObs.Text
    End Sub

    Private Sub mtFechaInicial_TypeValidationCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.TypeValidationEventArgs) Handles mtFechaInicial.TypeValidationCompleted
        If mtFechaInicial.Text.Length = 10 Then
            If IsDate(mkFechaAutoriza.Text) Then
                If CDate(mtFechaInicial.Text) < CDate(strFechaSistema) Then
                    MsgBox("La fecha de remisión no debe ser inferior a la actual", MsgBoxStyle.Exclamation)
                    e.Cancel = False
                    mtFechaInicial.Focus()
                End If

            Else
                MsgBox("La fecha de remisión no es correcta", MsgBoxStyle.Exclamation)
                e.Cancel = False
                mtFechaInicial.Focus()
            End If
        End If

    End Sub
#End Region

#Region "Navegabilidad-controles"
    Private Sub mtFechaInicial_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles mtFechaInicial.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub
    Private Sub tbHora_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub
    Private Sub tbMinuto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

#End Region

#Region "Navegabilidad"

    Private Sub mkFechaAutoriza_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles mkFechaAutoriza.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Sub Invalidar()
        'Dim Ctrl As Control
        'For Each Ctrl In Me.Controls
        '    Ctrl.Enabled = False
        'Next

        ''Se valida si la informacion cargada es una contrareferencia, para 
        ''habilitar o no los botones de guardar o reimpresion
        If objRemision.Contrareferencia = False Then
            ''Se habilita el boton de reimpresion
            pGrabar.Enabled = True
        Else
            tbAnamnesis.ReadOnly = True
            tbAuxiliares.ReadOnly = True
            tbCargoMedico.ReadOnly = True
            tbCodEntidad.ReadOnly = True
            tbCodigoAmbulancia.Enabled = False
            ' tbComplicaciones.ReadOnly = True  cpgaray se unifican campos
            tbDesAmbulancia.Enabled = False
            tbDiagnostico.ReadOnly = True
            'tbEstadoPaciente.ReadOnly = True
            tbEvolucion.ReadOnly = True
            lnkPlandemanejo.Enabled = False
            tbHora.ReadOnly = True
            tbHoraAutoriza.ReadOnly = True
            tbMedicoConfirma.ReadOnly = True
            tbMinuto.ReadOnly = True
            tbMinutoAutoriza.ReadOnly = True
            tbMotivos.ReadOnly = True
            tbNumeroAutoriza.ReadOnly = True
            tbServicio.ReadOnly = True
            'tbTratamientos.ReadOnly = True  cpgaray se unifican campos
            cbEntidad.Enabled = False
            cbNivel.Enabled = False
            mkFechaAutoriza.Enabled = False
            txtObs.ReadOnly = True

            ''Si la contrareferencia esta cerrada se permite reimprimir
            If objRemision.ContrareferenciaCerrada = "S" Then
                pGrabar.Enabled = False
                txtRespuesta.ReadOnly = True
                txtObs.ReadOnly = True
            Else
                ''Si la contrareferencia no esta cerrada se permite guardarla
                pGrabar.Enabled = True
                txtRespuesta.ReadOnly = False
                txtRespuesta.Enabled = True
            End If
        End If

        mtFechaInicial.Enabled = False


    End Sub
#End Region

    Private Sub mkFechaAutoriza_TypeValidationCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.TypeValidationEventArgs) Handles mkFechaAutoriza.TypeValidationCompleted
        tbHoraAutoriza.Focus()
        If mkFechaAutoriza.Text.Length = 10 Then
            tbHoraAutoriza.Focus()
            If IsDate(mkFechaAutoriza.Text) Then
                If CDate(mkFechaAutoriza.Text) < CDate(strFechaSistema) Then
                    MsgBox("La fecha de autorización no debe ser inferior a la actual", MsgBoxStyle.Exclamation)
                    e.Cancel = False
                    mkFechaAutoriza.Focus()
                End If

            Else
                MsgBox("La fecha de autorización no es correcta", MsgBoxStyle.Exclamation)
                e.Cancel = False
                mkFechaAutoriza.Focus()
            End If
        End If
    End Sub

    Private Sub tbHoraAutoriza_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbHoraAutoriza.Validating
        If Len(tbHoraAutoriza.Text) > 0 Then
            If CInt(tbHoraAutoriza.Text) > 23 Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub tbMinutoAutoriza_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbMinutoAutoriza.Validating
        If Len(Me.tbMinutoAutoriza.Text) > 0 Then
            If CInt(tbMinutoAutoriza.Text) > 59 Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub tbDesAmbulancia_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        If Len(tbCodigoAmbulancia.Text) = 0 Then
            tbDesAmbulancia.Text = ""
        End If
    End Sub

    Private Sub cbNivel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        tbAnamnesis.Focus()
        e.Handled = True
    End Sub

    Public Sub CargarReferencia(ByVal dtRemisionReferencia As DataTable, Optional ByVal dtDatosID As DataTable = Nothing)
        LimpiarDatos()


        If IsNothing(dtRemisionReferencia) Then
            Exit Sub
        ElseIf dtRemisionReferencia.Rows.Count <= 0 Then
            Exit Sub
        End If

        If (objRemision Is Nothing) Then
            objRemision = PlanRemision.Instancia
        End If


        objRemision.Contrareferencia = True
        objRemision.EstadoOriginal = objRemision.Estado
        objRemision.Estado = "G"

        With dtRemisionReferencia.Rows(0)
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
            '*************REF-CONT*************************
            'objRemision.DatosImpresionDiagnostica = dtDatosID
            '**********************************************
        End With

        IniciarPlanRemision()
    End Sub

    '*************REF-CONT*************************
    'Private Sub dtgInfoID_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgInfoID.DataSourceChanged
    '    dtgInfoID.Height = dtgInfoID.ColumnHeadersHeight + (dtgInfoID.Rows.GetRowsHeight(DataGridViewElementStates.None))
    'End Sub
    '**********************************************

    Private Sub HabilitarCampos()
        tbAnamnesis.ReadOnly = False
        tbAuxiliares.ReadOnly = False
        tbCargoMedico.ReadOnly = False
        tbCodEntidad.ReadOnly = False
        tbCodigoAmbulancia.Enabled = False
        'tbComplicaciones.ReadOnly = False cpgaray se unifican campos
        tbDesAmbulancia.Enabled = True
        tbDiagnostico.ReadOnly = False
        'tbEstadoPaciente.ReadOnly = False
        tbHora.ReadOnly = False
        tbHoraAutoriza.ReadOnly = False
        tbMedicoConfirma.ReadOnly = False
        tbMinuto.ReadOnly = False
        tbMinutoAutoriza.ReadOnly = False
        tbMotivos.ReadOnly = False
        tbNumeroAutoriza.ReadOnly = False
        tbServicio.ReadOnly = False
        'tbTratamientos.ReadOnly = False  cpgaray se unifican campos
        cbEntidad.Enabled = True
        cbNivel.Enabled = True
        mkFechaAutoriza.Enabled = True
        txtObs.ReadOnly = False

    End Sub

    Private Sub Panel2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel2.Click
        TxtScroll.Visible = True
        TxtScroll.Focus()
        TxtScroll.Visible = False
    End Sub

    Private Sub rbTrasladoambSi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbTrasladoambSi.Click
        tbCodigoAmbulancia.Enabled = True
        tbDesAmbulancia.Enabled = True
    End Sub

    Private Sub rbTrasladoambNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbTrasladoambNo.Click
        tbCodigoAmbulancia.Enabled = False
        tbDesAmbulancia.Enabled = False
        tbCodigoAmbulancia.Text = String.Empty
        tbDesAmbulancia.Text = String.Empty
    End Sub

    Private Sub lnkMotivoConsulta_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkMotivoConsulta.LinkClicked

        frmHistoriaPrincipal.pintarMenu(frmHistoriaPrincipal.OpcionesMenu.HistoriaBasica)
        frmHistoriaPrincipal.IniciaHistoriaBasica()

    End Sub

    Private Sub lnkPlandemanejo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkPlandemanejo.LinkClicked
        Dim dtEvolucion As New DataTable

        SeGuardoRemision = False

        dtEvolucion = BLPlanManejo.ConsultarEvolucion(objConexion)

        If dtEvolucion.Rows.Count = 0 Then
            MsgBox("No hay datos registrados en la evolución")
        Else
            Dim ctlevo As New frmc_evolucion(dtEvolucion)
            ctlevo.ShowDialog()
        End If

        'frmHistoriaPrincipal.pintarMenu(frmHistoriaPrincipal.OpcionesMenu.Evolucion)
        'frmHistoriaPrincipal.IniciarEvolucion()
    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class
