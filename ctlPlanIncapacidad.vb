Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports System.Collections.Generic
Imports System.Linq
Imports objGenerales = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales

' -----------------------------------------------------------------------------
' Project	 : HistoriaClinica.CtlPlanIncapacidad
' Class	 : Sophia.HistoriaClinica.ctlPlanIncapacidad
' -----------------------------------------------------------------------------
' Clase ctlPlanIncapacidad del namespace Sophia.HistoriaClinica.ctlPlanIncapacidad que 
' es la clase base. Esta clase tiene la funcionalidad del control de usuario para 
' el plan de manejo en las incapacidad y será usado en la aplicación cliente en Windows Form 2005
' -----------------------------------------------------------------------------

Public Class ctlPlanIncapacidad
    Private objGeneral As Generales
    Private objPaciente As Paciente
    Private objConexion As Conexion
    Private objIncapacidad As PlanIncapacidad
    Private Shared _Instancia As ctlPlanIncapacidad
    Private plstDiagnostico As New List(Of Diagnostico)

#Region "Instancia de Control"
    Public Shared ReadOnly Property Instancia() As ctlPlanIncapacidad
        Get
            If _Instancia Is Nothing Then
                _Instancia = New ctlPlanIncapacidad
            End If
            Return _Instancia
        End Get
    End Property
#End Region

#Region "Load"

    Private Sub ctlPlanIncapacidad_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
        FinalizarPlanIncapacidad()
    End Sub

    Private Sub ctlPlanIncapacidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        frmHistoriaPrincipal.blnFirstPlanIncapacidad = False

        objGeneral = Generales.Instancia
        objPaciente = Paciente.Instancia
        objConexion = Conexion.Instancia
        objIncapacidad = PlanIncapacidad.Instancia
        AjustesPeru()
        IniciarIncapacidad()

    End Sub

    Private Sub IniciarIncapacidad()
        Dim objBl As New Sophia.HistoriaClinica.BL.BLPlanManejo
        Dim lError As Long

        If objIncapacidad.Estado = "" Then
            Try
                lError = objBl.ConsultarIncapacidad(objConexion, objIncapacidad)
            Catch ex As Exception
                MsgBox("Error al consultar datos", MsgBoxStyle.Exclamation)
            End Try
        End If
        CargarValoresIniciales()
    End Sub

    Private Sub loadDiagnosticos()
        Dim oDiagnostico As New Diagnostico '= Diagnostico.Instancia
        Dim lError As Long
        Dim i As Integer = 0

        Try
            oDiagnostico.COD_PRE_SGS = objGeneral.Prestador
            oDiagnostico.COD_SUCUR = objGeneral.Sucursal
            oDiagnostico.TIP_ADMISION = objPaciente.TipoAdmision
            oDiagnostico.ANO_ADM = objPaciente.AnoAdmision
            oDiagnostico.NUM_ADM = objPaciente.NumeroAdmision
            oDiagnostico.CLASE_DIAG = Nothing
            'oDiagnostico.CLASE_DIAG = FuncionesGenerales.EnumDescription(Diagnostico.ClaseDiagnostico.Egreso)

            plstDiagnostico = oDiagnostico.getDiagnostico(objConexion, lError, oDiagnostico)

        Catch ex As Exception
            MsgBox("Error al consultar los Diagnósticos", MsgBoxStyle.Exclamation)
            Exit Sub
        End Try
        If plstDiagnostico.Count > 0 Then

            Dim lstdiag As New List(Of Diagnostico)

            lstdiag = (From DIAG As Diagnostico In plstDiagnostico.ToList()
                       Where DIAG.CATEGORIA_DIAG = FuncionesGenerales.EnumDescription(Diagnostico.CategoriaDiagnostico.Principal) AndAlso
                       DIAG.IDESTADODIAGNOSTICO = Diagnostico.EstadoDiagnostico.Activo
                       Select DIAG).ToList()

            If lstdiag.Count = 0 Then

                lstdiag = (From DIAG As Diagnostico In plstDiagnostico.ToList()
                           Where DIAG.CATEGORIA_DIAG = FuncionesGenerales.EnumDescription(Diagnostico.CategoriaDiagnostico.Principal) AndAlso
                           DIAG.IDESTADODIAGNOSTICO = Diagnostico.EstadoDiagnostico.Resuelto
                           Select DIAG).ToList()

            End If

            cmbDiagnostico.DataSource = lstdiag
            cmbDiagnostico.DisplayMember = "DIAGNOSTICO"
            cmbDiagnostico.ValueMember = "DIAGNOST"

            If lstdiag.Count = 1 Then
                cmbDiagnostico.Enabled = False
                tbObservaciones.Text = lstdiag(0).OBS.ToString()
            End If
            If lstdiag.Count > 1 Then
                cmbDiagnostico.Enabled = True
                cmbDiagnostico.ResetText()
                cmbDiagnostico.SelectedValue = -1

            End If
        Else
            MsgBox("No se han gestionado diagnosticos de Egreso.", MsgBoxStyle.Exclamation)

        End If


    End Sub

    Private Sub FinalizarPlanIncapacidad()
        With objIncapacidad
            .CodigoDiagnostico = cmbDiagnostico.SelectedValue
            .Diagnostico = cmbDiagnostico.SelectedText
            .Observacion = tbObservaciones.Text
            .Cantidad = Val(tbDias.Text)
            .FechaInicial = mtFechaInicial.Text
            .FechaFinal = tbFechaFinal.Text
            .Observacion = tbObservaciones.Text
        End With

        If Reimpresion() = False Then
            objIncapacidad.Estado = "M"
        End If
    End Sub
#End Region

#Region "CargarValoresIniciales-Load"
    Private Sub CargarValoresIniciales()

        '// consulta para traer el diagnostico y observaciones. \\

        Dim dtFecha As Date

        dtFecha = FuncionesGenerales.FechaServidor()
        mtFechaInicial.Text = Format(dtFecha, "dd/MM/yyyy")

        cmbDiagnostico.SelectedValue = IIf(IsNothing(objIncapacidad.CodigoDiagnostico), "", objIncapacidad.CodigoDiagnostico)
        cmbDiagnostico.SelectedText = objIncapacidad.Diagnostico
        tbObservaciones.Text = objIncapacidad.Observacion
        tbDias.Text = objIncapacidad.Cantidad
        tbFechaFinal.Text = objIncapacidad.FechaFinal
        loadDiagnosticos()
        ActualizarInformacionControles()

    End Sub

    Private Sub ActualizarInformacionControles()
        cmbDiagnostico.Tag = cmbDiagnostico.SelectedValue
        tbObservaciones.Tag = tbObservaciones.Text
        tbDias.Tag = tbDias.Text
        mtFechaInicial.Tag = mtFechaInicial.Text
        tbFechaFinal.Tag = tbFechaFinal.Text
    End Sub
#End Region

#Region "Grabar"
    Private Sub btGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGrabar.Click
        Dim objBl As New Sophia.HistoriaClinica.BL.BLPlanManejo
        Dim bError As Boolean = True
        Dim lError As Long
        Dim blnReimpresion As Boolean

        If objIncapacidad.Estado = "M" Then
            blnReimpresion = False
            objIncapacidad.Estado = "G"
        Else
            blnReimpresion = Reimpresion()
        End If


        If Me.cmbDiagnostico.Text.Length = 0 Then
            MsgBox("Debe asociar un Diagnóstico a la Incapacidad", MsgBoxStyle.Exclamation)
            bError = False
        End If
        If tbDias.Text.Length > 0 Then
            If (tbDias.Text < 0 Or tbDias.Text > 180) Then
                MsgBox("Por favor ingrese los días de incapacidad", MsgBoxStyle.Exclamation)
                tbDias.Focus()
                bError = False
            End If
        Else
            MsgBox("Por favor ingrese los días de incapacidad", MsgBoxStyle.Exclamation)
            tbDias.Focus()
            bError = False
        End If
        If mtFechaInicial.Text.Length = 10 Then
            If Not IsDate(CDate(mtFechaInicial.Text)) Then
                MsgBox("Por favor ingrese la fecha inicial correctamente", MsgBoxStyle.Exclamation)
                mtFechaInicial.Focus()
                bError = False
            End If
        Else
            MsgBox("Por favor ingrese la fecha inicial correctamente", MsgBoxStyle.Exclamation)
            mtFechaInicial.Focus()
            bError = False
        End If

        If bError Then
            '// Grabar
            Try
                'If blnReimpresion = False Then
                lError = objBl.GrabarIncapacidad(objConexion, cmbDiagnostico.SelectedValue, CType(tbDias.Text, Integer),
                                                     Trim(mtFechaInicial.Text), tbObservaciones.Text.ToString)
                    If lError > 0 Then
                        MsgBox("La incapacidad no se grabó, por favor verifique los datos", MsgBoxStyle.Exclamation)
                        objIncapacidad.Estado = "N"
                    Else
                        ' MsgBox("La incapacidad se grabó correctamente", MsgBoxStyle.Information)
                        objGeneral.HistoriaClinicaTieneModificaciones = True
                        objIncapacidad.Estado = "G"
                        '/ Ingresar valores a la variable global
                        objIncapacidad.CodigoDiagnostico = cmbDiagnostico.SelectedValue
                        objIncapacidad.Diagnostico = cmbDiagnostico.SelectedText
                        objIncapacidad.Observacion = tbObservaciones.Text
                        objIncapacidad.Cantidad = CInt(tbDias.Text)
                        objIncapacidad.FechaInicial = mtFechaInicial.Text
                        objIncapacidad.FechaFinal = tbFechaFinal.Text
                        ActualizarInformacionControles()
                        ImprimirReporte(blnReimpresion)
                    End If
                'Else
                '    ImprimirReporte(blnReimpresion)
                'End If
            Catch ex As Exception
                If blnReimpresion = False Then
                    If objIncapacidad.Estado <> "G" Then
                        objIncapacidad.Estado = "N"
                    End If

                    '***** para el control de errores ....*****
                    MessageBox.Show("El proceso de grabación de la incapacidad falló por: " & ex.Message, "Historia Clínica", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("No se pudo realizar la Reimpresión de la Incapacidad", "Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End Try
        End If
       

    End Sub
#End Region

#Region "FechaFinal"

    Private Sub mtFechaInicial_TypeValidationCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.TypeValidationEventArgs) Handles mtFechaInicial.TypeValidationCompleted

        Dim dteFecha As Date

        dteFecha = FuncionesGenerales.FechaServidor()

        If tbDias.Text.Length > 0 Then
            If mtFechaInicial.Text.Length = 10 Then
                If IsDate(CDate(mtFechaInicial.Text)) Then
                    If dteFecha > CDate(mtFechaInicial.Text) Then
                        tbFechaFinal.Text = DateAdd(DateInterval.Day, CType(tbDias.Text, Double) - 1, CType(mtFechaInicial.Text, Date))
                    Else
                        MsgBox("La Fecha Inicial no puede ser mayor de la Fecha Actual", MsgBoxStyle.Exclamation)
                        mtFechaInicial.Focus()
                    End If
                Else
                    MsgBox("La fecha inicial no es válida", MsgBoxStyle.Exclamation)
                    mtFechaInicial.Focus()
                End If
            Else
                MsgBox("La fecha inicial no es válida", MsgBoxStyle.Exclamation)
                mtFechaInicial.Focus()
            End If
        Else
        MsgBox("Debe ingresar los días de incapacidad", MsgBoxStyle.Exclamation)
        tbDias.Focus()
        End If
    End Sub

    'Private Sub mtFechaInicial_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles mtFechaInicial.Validated
    '    If tbDias.Text.Length > 0 Then
    '        If (CInt(tbDias.Text) > 0 And CInt(tbDias.Text) < 180) And mtFechaInicial.Text.Length = 10 Then
    '            If IsDate(CDate(mtFechaInicial.Text)) Then
    '                tbFechaFinal.Text = DateAdd(DateInterval.Day, CType(tbDias.Text, Double), CType(mtFechaInicial.Text, Date))
    '            Else
    '                MsgBox("La fecha inicial no es válidad", MsgBoxStyle.Exclamation)
    '                mtFechaInicial.Focus()
    '            End If
    '        Else
    '            MsgBox("La fecha inicial no es válidad", MsgBoxStyle.Exclamation)
    '            mtFechaInicial.Focus()
    '        End If
    '    Else
    '        MsgBox("Debe ingresar los días de incapacidad", MsgBoxStyle.Exclamation)
    '        tbDias.Focus()
    '    End If

    'End Sub
#End Region

#Region "ImprimirReporte"
    Public Sub ImprimirReporte(ByVal blnReimpresion As Boolean)
        Dim objDatosGenerales As objGenerales.Generales

        objDatosGenerales = objGenerales.Generales.Instancia

        If objDatosGenerales.Pais = "482" Or objDatosGenerales.Pais = "484" Then ''Peru ó Venezuela
            frmRepPlanIncapacidad.Show()
            frmRepPlanIncapacidad.imprimirRepPlanIncapacidad(objConexion, objGeneral.Prestador, objGeneral.Sucursal,
                                                            objPaciente.TipoDocumento, objPaciente.NumeroDocumento,
                                                            objPaciente.TipoAdmision, objPaciente.AnoAdmision,
                                                            objPaciente.NumeroAdmision, objIncapacidad, blnReimpresion)
        Else
            '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
            'Juan Carlos Jaramillo Lozano - IG
            RptHC_Enf_Med.Show()
            RptHC_Enf_Med.ImprimirHistoriaClinica_imprimirIncapacidad(objConexion, "50", objGeneral.Prestador, objGeneral.Sucursal,
                                                        objPaciente.TipoDocumento, objPaciente.NumeroDocumento,
                                                        objPaciente.TipoAdmision, objPaciente.AnoAdmision,
                                                        objPaciente.NumeroAdmision, objPaciente.CodHistoria)
            '2019-03-11 Fin
        End If
    End Sub

    Private Function Reimpresion() As Boolean
        If Not IsNothing(cmbDiagnostico.SelectedValue) And Not IsNothing(cmbDiagnostico.Tag) Then
            If Trim(cmbDiagnostico.Tag.ToString.ToUpper) <> Trim(cmbDiagnostico.SelectedValue.ToUpper) Then
                Reimpresion = False
                Exit Function
            End If
        End If

        If Trim(tbObservaciones.Tag.ToString.ToUpper) <> Trim(tbObservaciones.Text.ToUpper) Then
            Reimpresion = False
            Exit Function
        End If
        If Trim(tbDias.Tag.ToString.ToUpper) <> Trim(tbDias.Text.ToUpper) Then
            Reimpresion = False
            Exit Function
        End If
        If Trim(mtFechaInicial.Tag.ToString.ToUpper) <> Trim(mtFechaInicial.Text.ToUpper) Then
            Reimpresion = False
            Exit Function
        End If
        If Trim(tbFechaFinal.Tag.ToString.ToUpper) <> Trim(tbFechaFinal.Text.ToUpper) Then
            Reimpresion = False
            Exit Function
        End If

        Reimpresion = True

    End Function

#End Region

#Region "DiasIncapacidad"

    Private Sub tbDias_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbDias.Validated
        If tbDias.Text.Length > 0 Then
            If mtFechaInicial.Text.Length = 10 Then
                If IsDate(CDate(mtFechaInicial.Text)) Then
                    tbFechaFinal.Text = DateAdd(DateInterval.Day, CType(tbDias.Text, Double) - 1, CType(mtFechaInicial.Text, Date))
                Else
                    MsgBox("La fecha inicial no es válida", MsgBoxStyle.Exclamation)
                    mtFechaInicial.Focus()
                End If
            Else
                MsgBox("La fecha inicial no es válida", MsgBoxStyle.Exclamation)
                mtFechaInicial.Focus()
            End If
        Else
            'MsgBox("Debe ingresar los días de incapacidad", MsgBoxStyle.Exclamation)
            tbDias.Focus()
        End If
    End Sub

#End Region

#Region "Navegacion"
    Private Sub tbDias_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
            mtFechaInicial.Focus()
        End If
    End Sub
    Private Sub mtFechaInicial_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles mtFechaInicial.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub
    Private Sub tbFechaFinal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbFechaFinal.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub
#End Region



    Private Sub ctlPlanIncapacidad_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If sender.Visible = True Then
            LimpiarDatos()
            IniciarIncapacidad()
            If frmHistoriaPrincipal.blnFirstPlanIncapacidad = True Then
                frmHistoriaPrincipal.blnFirstPlanIncapacidad = False
            End If
        Else
            FinalizarPlanIncapacidad()
        End If
        AjustesPeru()
    End Sub

    Private Sub LimpiarDatos()
        cmbDiagnostico.ResetText()
        tbObservaciones.ResetText()
        tbDias.ResetText()
        mtFechaInicial.ResetText()
        tbFechaFinal.ResetText()

    End Sub
    Private Sub AjustesPeru()
        If objGeneral.Pais = "482" Then
            PictureBox1.Image = Global.HistoriaClinica.My.Resources.Resources.Sub_Menu_DescansoMedicoPorIincapacidad
            lbDias.Text = "Dias de descanso médico"
            lbDias.Size = New System.Drawing.Size(194, 20)
            '' lbDias.Location = New System.Drawing.Point(3, 163)
            tbDias.Location = New System.Drawing.Point(203, 175)
            lbFecIni.Location = New System.Drawing.Point(320, 175)
            mtFechaInicial.Location = New System.Drawing.Point(420, 175)
        ElseIf objGeneral.Pais = "484" Then
            PictureBox1.Image = Global.HistoriaClinica.My.Resources.Resources.Sub_Menu_reposo
            lbDias.Text = "Reposo"
        Else
            Me.PictureBox1.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.imag_25
        End If

    End Sub

    'Private Sub cmbDiagnostico_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbDiagnostico.SelectedValueChanged
    '    Dim lstdiag As New List(Of Diagnostico)
    '    Dim oDiagnostico As New Diagnostico
    '    oDiagnostico = cmbDiagnostico.SelectedValue
    '    'lstdiag = (From DIAG As Diagnostico In plstDiagnostico.ToList()
    '    '           Where DIAG.DIAGNOST = oDiagnostico.DIAGNOST
    '    '           Select DIAG).ToList()
    '    'tbObservaciones.Text = lstdiag(0).OBS
    '    tbObservaciones.Text = oDiagnostico.OBS
    'End Sub

    Private Sub cmbDiagnostico_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDiagnostico.SelectedIndexChanged
        Dim lstdiag As New List(Of Diagnostico)
        lstdiag = (From DIAG As Diagnostico In plstDiagnostico.ToList()
                   Where DIAG.DIAGNOSTICO = cmbDiagnostico.Text
                   Select DIAG).ToList()
        If lstdiag.Count = 1 Then
            tbObservaciones.Text = lstdiag(0).OBS
        End If
    End Sub
End Class
