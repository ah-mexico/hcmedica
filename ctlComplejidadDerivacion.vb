Imports System.IO
Imports System.Collections
Imports System.Collections.Generic
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.HistoriaBasica
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports HistoriaClinica.wsCuidadoPaliativo
Imports System.Text.RegularExpressions

Public Class ctlComplejidadDerivacion
    Private Shared _Instancia As ctlComplejidadDerivacion
    Private objGeneral As Generales
    Private objPaciente As Paciente
    Private objConexion As Conexion
    Private objCompDeriv As New DAOComplejidadDerivacion
    Private estadoAntCompPsico As String = String.Empty
    Private estadoAntCompAtencion As String = String.Empty
    Private PregHabCompMediaBaja As New Hashtable()
    Private PregHabCompAteMediaBaja As New Hashtable()
    Private NumPregCompMedia As New Hashtable()
    Private NumPregCompMediaAte As New Hashtable()
    Private lstPreguntasCompDeriCP As List(Of PreguntaCP)


#Region "Instancia de Control"
    Public Shared ReadOnly Property Instancia() As ctlComplejidadDerivacion
        Get
            If _Instancia Is Nothing Then
                _Instancia = New ctlComplejidadDerivacion
            End If
            Return _Instancia
        End Get
    End Property
#End Region

    Private Sub ctlComplejidadDerivacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        objCompDeriv = New DAOComplejidadDerivacion()
        objGeneral = Generales.Instancia
        objPaciente = Paciente.Instancia
        objConexion = Conexion.Instancia
        LimpiardatosComplejidadDerivacion()
        ''WACHV,22SEPT2017, SE AGREGA VALIDACION DE ESTADO DE PPS E ik
        fncValidarFuncionalidadAplicada()
    End Sub

    Private Sub ctlComplejidadDerivacion_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        LimpiardatosComplejidadDerivacion()
        CargarCombos()
    End Sub

    ''' <summary>
    ''' Función para inicializar los elementos radio button y label.
    ''' </summary>
    Private Sub LimpiardatosComplejidadDerivacion()
        Dim ctrlsRadioButton As List(Of RadioButton) = Me.GetTypeControls(Of RadioButton)(Me, False, Nothing)
        For Each ctrl As Control In ctrlsRadioButton
            If (Not (TypeOf ctrl Is RadioButton)) Then
                Continue For
            End If
            Dim rb As RadioButton = DirectCast(ctrl, RadioButton)
            rb.Checked = False
        Next
        Dim ctrlsLblsConclusion As List(Of Label) = Me.GetTypeControls(Of Label)(Me, False, "Conclusion")
        For Each ctrl As Control In ctrlsLblsConclusion
            If (Not (TypeOf ctrl Is Label)) Then
                Continue For
            End If
            Dim lb As Label = DirectCast(ctrl, Label)
            lb.Text = String.Empty
            lb.Visible = False
        Next
        txtEscalaTMP.ResetText()
        ''WACHV,22SEPT2017, SE AGREGA VALIDACION DE ESTADO DE PPS E ik
        RB_IK_Preg520.Checked = False
        RB_PPS_Preg520.Checked = False
        txtEscalaTMP.Text = ""
        'cboLugarDerivacion.Enabled = False
    End Sub

    ''' <summary>
    ''' Obtiene una colección con los controles de un determinado
    ''' tipo existentes en un contenedor superior.
    ''' </summary>
    ''' <typeparam name="T">Tipo de control que se desea obtener.</typeparam>
    ''' <param name="contenedorPadre">Objeto Control que actua de
    ''' contenedor para el tipo de control que se desea obtener.</param>
    ''' <param name="incluirControlesHeredados">Indica si se incluyen en la
    ''' colección aquellos controles que heredan de la clase especificada.</param>
    ''' <param name="tagUser">Campo de información de usuario en un control para 
    ''' identificar si el control pertenece a un grupo de interes </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetTypeControls(Of T As Control)( _
    ByVal contenedorPadre As Control, ByVal incluirControlesHeredados As Boolean, ByVal tagUser As String) As List(Of T)
        If (contenedorPadre Is Nothing) Then Return Nothing
        Dim controles As New List(Of T)
        Dim tipoT As Type = GetType(T)
        For Each ctrl As Control In contenedorPadre.Controls
            If (incluirControlesHeredados) Then
                If (TypeOf ctrl Is T) Then _
                    controles.Add(DirectCast(ctrl, T))
            Else
                Dim typeControl As Type = ctrl.GetType()
                If (typeControl.Equals(tipoT)) Then
                    If (tagUser Is Nothing) Then
                        controles.Add(DirectCast(ctrl, T))
                    ElseIf (tagUser.Equals(ctrl.Tag)) Then
                        controles.Add(DirectCast(ctrl, T))
                    End If
                End If
            End If
            controles.AddRange(Me.GetTypeControls(Of T)(ctrl, incluirControlesHeredados, tagUser))
        Next
        Return controles
    End Function

    ''' <summary>
    ''' '''WACHV,22SEPT20217, VALIDAR QUE SEAN OBLIGATORIAS
    ''' Valida Obligatoriedad En Complejidad y Derivacion
    ''' </summary>
    ''' <remarks>WACHV, 22SEPT2017</remarks>
    Private Function bfncObligatoriedad() As Boolean
        Dim bValidoObligatorio As Boolean = True

        If lblConclusionComplejidadClinica.Text = "" Then
            bValidoObligatorio = False
        ElseIf lblConclusionComplejidadPsicosocial.Text = "" Then
            bValidoObligatorio = False
        ElseIf lblConclusionComplejidadAtencion.Text = "" Then
            bValidoObligatorio = False
        ElseIf txtEscalaTMP.Text = "" Then
            bValidoObligatorio = False
        ElseIf cboLugarDerivacion.SelectedValue.ToString = "" Then  ''Validar que seleccione alguna de las nuevas de lugar de derivacion
            bValidoObligatorio = False
        End If
        bfncObligatoriedad = bValidoObligatorio
    End Function

    ''' <summary>
    ''' Función que calcula según lo seleccionado por el usuario la conclusión para cada sección del formulario
    ''' </summary>
    Private Sub RB_Si_Preg501_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_Si_Preg501.CheckedChanged,
    RB_Si_Preg502.CheckedChanged, RB_Si_Preg503.CheckedChanged, RB_Si_Preg504.CheckedChanged, RB_Si_Preg505.CheckedChanged, RB_Si_Preg506.CheckedChanged,
    RB_Si_Preg507.CheckedChanged, RB_Si_Preg508.CheckedChanged, RB_Si_Preg509.CheckedChanged, RB_Si_Preg510.CheckedChanged, RB_Si_Preg511.CheckedChanged,
    RB_Si_Preg512.CheckedChanged, RB_Si_Preg513.CheckedChanged, RB_Si_Preg515.CheckedChanged, RB_Si_Preg516.CheckedChanged,
    RB_Si_Preg517.CheckedChanged, RB_Si_Preg518.CheckedChanged, RB_Si_Preg519.CheckedChanged, RB_Si_Preg514.CheckedChanged

        Dim rbCtrl As RadioButton = DirectCast(sender, RadioButton)
        Dim strCtrlName As String = rbCtrl.Tag


        ''WACHV,22SEPT2017, SE AGREGA VALIDACION DE ESTADO DE PPS E ik
        RB_IK_Preg520.Checked = False
        RB_PPS_Preg520.Checked = False
        txtEscalaTMP.Text = ""

        CargarCombos()
        ''x defecto  sin Seleccionar
        cboLugarDerivacion.SelectedIndex = -1

        fncValidarFuncionalidadAplicada() ''WACHV, Validar Funcionalidad de cada caso

        Select Case strCtrlName
            Case "Preg501"
                If (rbCtrl.Checked) Then
                    With lblConclusionComplejidadClinica
                        .Text = "Alta"
                        .Visible = rbCtrl.Checked
                    End With
                    GB_Preg502.Enabled = Not rbCtrl.Checked
                    GB_Preg503.Enabled = Not rbCtrl.Checked
                Else
                    With lblConclusionComplejidadClinica
                        .Text = String.Empty
                        .Visible = rbCtrl.Checked
                    End With
                    'RB_No_Preg501.Checked = rbCtrl.Checked
                    GB_Preg502.Enabled = Not rbCtrl.Checked
                    GB_Preg503.Enabled = Not rbCtrl.Checked
                End If
            Case "Preg502"
                If (rbCtrl.Checked) Then
                    With lblConclusionComplejidadClinica
                        .Text = "Intermedia"
                        .Visible = rbCtrl.Checked
                    End With
                    GB_Preg501.Enabled = Not rbCtrl.Checked
                    GB_Preg503.Enabled = Not rbCtrl.Checked
                Else
                    With lblConclusionComplejidadClinica
                        .Text = String.Empty
                        .Visible = rbCtrl.Checked
                    End With
                    'RB_No_Preg502.Checked = rbCtrl.Checked
                    GB_Preg501.Enabled = Not rbCtrl.Checked
                    GB_Preg503.Enabled = Not rbCtrl.Checked
                End If
            Case "Preg503"
                If (rbCtrl.Checked) Then
                    With lblConclusionComplejidadClinica
                        .Text = "Baja"
                        .Visible = rbCtrl.Checked
                    End With
                    GB_Preg501.Enabled = Not rbCtrl.Checked
                    GB_Preg502.Enabled = Not rbCtrl.Checked
                Else
                    With lblConclusionComplejidadClinica
                        .Text = String.Empty
                        .Visible = Not rbCtrl.Checked
                    End With
                    'RB_No_Preg503.Checked = rbCtrl.Checked
                    GB_Preg501.Enabled = Not rbCtrl.Checked
                    GB_Preg502.Enabled = Not rbCtrl.Checked
                End If
            Case "Preg504", "Preg505", "Preg506", "Preg507", "Preg508"
                If (Not rbCtrl.Checked) Then
                    If (PregHabCompMediaBaja.ContainsKey(rbCtrl.Tag)) Then PregHabCompMediaBaja.Remove(rbCtrl.Tag)
                Else
                    If (Not PregHabCompMediaBaja.ContainsKey(rbCtrl.Tag)) Then PregHabCompMediaBaja.Add(rbCtrl.Tag, 1)
                End If
                If (PregHabCompMediaBaja.Count = 0) Then
                    habilitarPreguntasCompejidadPsicosocial(True, "Media")
                    habilitarPreguntasCompejidadPsicosocial(True, "Baja")
                ElseIf (PregHabCompMediaBaja.Count = 1) Then
                    habilitarPreguntasCompejidadPsicosocial(False, "Media")
                    habilitarPreguntasCompejidadPsicosocial(False, "Baja")
                End If
                If (rbCtrl.Checked AndAlso PregHabCompMediaBaja.Count = 1) Then
                    With lblConclusionComplejidadPsicosocial
                        estadoAntCompPsico = .Text
                        .Text = "Alta"
                        .Visible = rbCtrl.Checked
                    End With
                ElseIf (Not rbCtrl.Checked AndAlso PregHabCompMediaBaja.Count = 0) Then
                    With lblConclusionComplejidadPsicosocial
                        .Text = IIf(NumPregCompMedia.Count = 0, String.Empty, estadoAntCompPsico)
                    End With
                End If
            Case "Preg509", "Preg510", "Preg511", "Preg512"
                If (Not rbCtrl.Checked) Then
                    If (NumPregCompMedia.ContainsKey(rbCtrl.Tag)) Then NumPregCompMedia.Remove(rbCtrl.Tag)
                Else
                    If (Not NumPregCompMedia.ContainsKey(rbCtrl.Tag)) Then NumPregCompMedia.Add(rbCtrl.Tag, 1)
                End If
                If (rbCtrl.Checked) Then
                    With lblConclusionComplejidadPsicosocial
                        estadoAntCompPsico = .Text
                        .Text = "Intermedia"
                        .Visible = rbCtrl.Checked
                    End With
                ElseIf (NumPregCompMedia.Count = 0) Then
                    With lblConclusionComplejidadPsicosocial
                        .Text = IIf(NumPregCompMedia.Count = 0, String.Empty, estadoAntCompPsico)
                    End With
                End If
            Case "Preg513"
                habilitarPreguntasCompejidadPsicosocial(Not rbCtrl.Checked, "All")
                If (rbCtrl.Checked) Then
                    With lblConclusionComplejidadPsicosocial
                        estadoAntCompPsico = .Text
                        .Text = "Baja"
                        .Visible = rbCtrl.Checked
                    End With
                Else
                    With lblConclusionComplejidadPsicosocial
                        .Text = IIf(NumPregCompMedia.Count = 0, String.Empty, estadoAntCompPsico)
                    End With
                End If
            Case "Preg514", "Preg515"
                If (Not rbCtrl.Checked) Then
                    If (PregHabCompAteMediaBaja.ContainsKey(rbCtrl.Tag)) Then PregHabCompAteMediaBaja.Remove(rbCtrl.Tag)
                Else
                    If (Not PregHabCompAteMediaBaja.ContainsKey(rbCtrl.Tag)) Then PregHabCompAteMediaBaja.Add(rbCtrl.Tag, 1)
                End If
                If (PregHabCompAteMediaBaja.Count = 0) Then
                    habilitarPreguntasCompejidadAtencion(True, "Media")
                    habilitarPreguntasCompejidadAtencion(True, "Baja")
                ElseIf (PregHabCompAteMediaBaja.Count = 1) Then
                    habilitarPreguntasCompejidadAtencion(False, "Media")
                    habilitarPreguntasCompejidadAtencion(False, "Baja")
                End If
                If (rbCtrl.Checked AndAlso PregHabCompAteMediaBaja.Count = 1) Then
                    With lblConclusionComplejidadAtencion
                        estadoAntCompAtencion = .Text
                        .Text = "Alta"
                        .Visible = rbCtrl.Checked
                    End With
                ElseIf (Not rbCtrl.Checked AndAlso PregHabCompAteMediaBaja.Count = 0) Then
                    With lblConclusionComplejidadAtencion
                        .Text = IIf(NumPregCompMediaAte.Count = 0, String.Empty, estadoAntCompAtencion)
                    End With
                End If
            Case "Preg516", "Preg517", "Preg518"
                If (Not rbCtrl.Checked) Then
                    If (NumPregCompMediaAte.ContainsKey(rbCtrl.Tag)) Then NumPregCompMediaAte.Remove(rbCtrl.Tag)
                Else
                    If (Not NumPregCompMediaAte.ContainsKey(rbCtrl.Tag)) Then NumPregCompMediaAte.Add(rbCtrl.Tag, 1)
                End If
                If (rbCtrl.Checked) Then
                    With lblConclusionComplejidadAtencion
                        estadoAntCompAtencion = .Text
                        .Text = "Intermedia"
                        .Visible = rbCtrl.Checked
                    End With
                ElseIf (NumPregCompMediaAte.Count = 0) Then
                    With lblConclusionComplejidadAtencion
                        .Text = IIf(NumPregCompMediaAte.Count = 0, String.Empty, estadoAntCompAtencion)
                    End With
                End If
            Case "Preg519"
                habilitarPreguntasCompejidadAtencion(Not rbCtrl.Checked, "All")
                If (rbCtrl.Checked) Then
                    With lblConclusionComplejidadAtencion
                        estadoAntCompAtencion = .Text
                        .Text = "Baja"
                        .Visible = rbCtrl.Checked
                    End With
                Else
                    With lblConclusionComplejidadAtencion
                        .Text = IIf(NumPregCompMediaAte.Count = 0, String.Empty, estadoAntCompAtencion)
                    End With
                End If
        End Select
    End Sub

    ''' <summary>
    ''' Habilitar o Deshabilitar preguntas de la sección Complejidad Psicosocial
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub habilitarPreguntasCompejidadPsicosocial(ByVal estado As Boolean, ByVal grupo As String)
        For i As Integer = 4 To 13
            With GBComplejidadPsicosocial
                Dim ctrl As Control = .Controls(.Controls.IndexOfKey("GB_Preg5" & IIf(i < 10, "0" & i.ToString, i.ToString)))
                If (TypeOf ctrl Is GroupBox) Then
                    If ((grupo.Equals("All") OrElse grupo.Equals("Alta")) AndAlso i < 9) Then
                        ctrl.Enabled = estado
                    End If
                    If ((grupo.Equals("All") OrElse grupo.Equals("Media")) AndAlso i >= 9 AndAlso i < 13) Then
                        ctrl.Enabled = estado
                    End If
                    If (grupo.Equals("Baja") AndAlso i = 13) Then
                        ctrl.Enabled = estado
                    End If
                End If
            End With
        Next
    End Sub

    ''' <summary>
    ''' Habilitar o Deshabilitar preguntas de la sección Complejidad de la Atencion
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub habilitarPreguntasCompejidadAtencion(ByVal estado As Boolean, ByVal grupo As String)
        For i As Integer = 14 To 19
            With GBComplejidadAtencion
                Dim ctrl As Control = .Controls(.Controls.IndexOfKey("GB_Preg5" & i.ToString))
                If (TypeOf ctrl Is GroupBox) Then
                    If ((grupo.Equals("All") OrElse grupo.Equals("Alta")) AndAlso i < 16) Then
                        ctrl.Enabled = estado
                    End If
                    If ((grupo.Equals("All") OrElse grupo.Equals("Media")) AndAlso i >= 16 AndAlso i < 19) Then
                        ctrl.Enabled = estado
                    End If
                    If (grupo.Equals("Baja") AndAlso i = 19) Then
                        ctrl.Enabled = estado
                    End If
                End If
            End With
        Next
    End Sub

    ''' <summary>
    ''' WACHV, 22SEPT2017, ' Procedimiento para Validar Funcionalidad Aplicada en Derivacion, Activa o Inactiva en cada Caso
    ''' </summary>
    Private Sub fncValidarFuncionalidadAplicada()
        Dim iRespuesta As Int16
        iRespuesta = objCompDeriv.ConsultarEscalaComplejidadDerivacion("VAL", objGeneral.Prestador, objGeneral.Sucursal,
        objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision)
        If iRespuesta = -2 Then ''Pps es Mayor
            RB_IK_Preg520.Enabled = False
            RB_PPS_Preg520.Enabled = True
        End If
        If iRespuesta = -1 Then ''Ik es mayor
            RB_IK_Preg520.Enabled = True
            RB_PPS_Preg520.Enabled = False
        End If
    End Sub

    Private Sub CargarCombos()
        Dim dt As New DataTable
        Try
            cboLugarDerivacion.ResetText()
            cboLugarDerivacion.BeginUpdate()
            dt = objCompDeriv.CargarCombo(1)

            If dt.Rows.Count = 0 Then
                MsgBox("No existen Lugares de derivacion.")
            End If

            cboLugarDerivacion.DataSource = dt
            cboLugarDerivacion.DisplayMember = "descripcion"
            cboLugarDerivacion.ValueMember = "Id"
            cboLugarDerivacion.EndUpdate()
            cboLugarDerivacion.SelectedValue = -1
            dt = Nothing
        Catch ex As Exception
            Throw (ex)
        End Try

    End Sub

    ''' <summary>
    ''' Función para consultar el puntaje de la escala según la selección del usuario.
    ''' </summary>
    Private Sub RB_PPS_Preg520_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_PPS_Preg520.CheckedChanged, RB_IK_Preg520.CheckedChanged
        Dim ctrl As RadioButton = DirectCast(sender, RadioButton)
        If (ctrl.Checked) Then
            Dim escala As String = ctrl.Text
            txtEscalaTMP.Text = objCompDeriv.ConsultarEscalaComplejidadDerivacion(escala, objGeneral.Prestador, objGeneral.Sucursal,
            objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision)
            If (IsNumeric(txtEscalaTMP.Text) AndAlso Short.Parse(txtEscalaTMP.Text) >= 0 _
                    AndAlso Short.Parse(txtEscalaTMP.Text) <= 100) Then
                calcularLugarDerivacion(txtEscalaTMP.Text)
            End If
        End If
    End Sub
    ''WACHV,INICIO,25OCT2017, Para Borrar o posicionar lo que llega
    Private Sub BorrarElementoComboBox(ByRef oCombobox As ComboBox, ByVal strValor As String)
        Dim index As Integer = cboLugarDerivacion.FindString(strValor)
        If index <> -1 Then
            Dim itm As DataRowView = cboLugarDerivacion.Items.Item(index)
            itm.Row.Delete()
            cboLugarDerivacion.Refresh()
        End If
        'Case "Posicionar"
        '    index = cboLugarDerivacion.FindString(strValor)
        '    cboLugarDerivacion.SelectedIndex = index
    End Sub  ''WACHV,FIN,25OCT2017, Para Borrar o posicionar lo que llega

    ''' <summary>
    ''' Realiza el cálculo de la información para el campo Lugar de Derivación
    ''' Basado en las conclusiones generadas resultantes a partir de las repuestas de cada pregunta 
    ''' WACHV, 22Sept207, Ajustar para Nuevos Calculos
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub calcularLugarDerivacion(ByVal resultado As Short)
        Dim strCompeljidadClinica As String = lblConclusionComplejidadClinica.Text '
        Dim strComplejidadPsicoSocial As String = lblConclusionComplejidadPsicosocial.Text
        Dim strCompeljidadAtenncion As String = lblConclusionComplejidadAtencion.Text
        Dim ctrlVisible As Boolean = True

        CargarCombos() '''WACHV,25OCT2017, cargar combos

        If resultado > 50 Then '50 Then ''WACHV, 05OCT2017, SE AJUSTO SOLO MAYORES EXCLUSIVAMENTE...Del req vr 2.0 req qf10
            'Si el resultado de cualquiera de las 2 escalas es mayor a 50 
            ''WACHV,22SEPTO2017, Se evalua los siguientes escenarios:

            '1
            If strCompeljidadClinica.Equals("Alta") And strComplejidadPsicoSocial.Equals("Alta") And strCompeljidadAtenncion.Equals("Alta") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Hospice")
                BorrarElementoComboBox(cboLugarDerivacion, "Programa Domiciliario")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = True
                'objRadioButtonHospitalizacion.Enabled = True
                'objRadioButtonHospice.Enabled = False
                'objRadioButtonProgramaDomiciliario.Enabled = False
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If
            '    ''Si complejidad sintomatica (clinica) es alta y complejidad psicosocial es alta y compelejidad de la atencion es Intermedia
            '    ''==> AMBULATORIO ALTA COMPLEJIDAD	/ HOSPITALIZACION
            '2
            If strCompeljidadClinica.Equals("Alta") And strComplejidadPsicoSocial.Equals("Alta") And strCompeljidadAtenncion.Equals("Intermedia") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Hospice")
                BorrarElementoComboBox(cboLugarDerivacion, "Programa Domiciliario")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = True
                'objRadioButtonHospitalizacion.Enabled = True
                'objRadioButtonHospice.Enabled = False
                'objRadioButtonProgramaDomiciliario.Enabled = False
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If
            '    ''Si complejidad sintomatica (clinica) es ALTA y complejidad psicosocial es ALTA y compelejidad de la atencion es BAJA
            '    ''==> AMBULATORIO ALTA COMPLEJIDAD	/ HOSPITALIZACION
            '3
            If strCompeljidadClinica.Equals("Alta") And strComplejidadPsicoSocial.Equals("Alta") And strCompeljidadAtenncion.Equals("Baja") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Hospice")
                BorrarElementoComboBox(cboLugarDerivacion, "Programa Domiciliario")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = True
                'objRadioButtonHospitalizacion.Enabled = True
                'objRadioButtonHospice.Enabled = False
                'objRadioButtonProgramaDomiciliario.Enabled = False
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            '    ''Si complejidad sintomatica (clinica) es ALTA y complejidad psicosocial es INTERMEDIA y compelejidad de la atencion es ALTA
            '    ''==> AMBULATORIO ALTA COMPLEJIDAD	/ HOSPITALIZACION
            '4
            If strCompeljidadClinica.Equals("Alta") And strComplejidadPsicoSocial.Equals("Intermedia") And strCompeljidadAtenncion.Equals("Alta") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Hospice")
                BorrarElementoComboBox(cboLugarDerivacion, "Programa Domiciliario")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = True
                'objRadioButtonHospitalizacion.Enabled = True
                'objRadioButtonHospice.Enabled = False
                'objRadioButtonProgramaDomiciliario.Enabled = False
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            '    ''Si complejidad sintomatica (clinica) es ALTA y complejidad psicosocial es INTERMEDIA y compelejidad de la atencion es INTERMEDIA
            '    ''==> AMBULATORIO ALTA COMPLEJIDAD	/ HOSPITALIZACION
            '5
            If strCompeljidadClinica.Equals("Alta") And strComplejidadPsicoSocial.Equals("Intermedia") And strCompeljidadAtenncion.Equals("Intermedia") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Hospice")
                BorrarElementoComboBox(cboLugarDerivacion, "Programa Domiciliario")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = True
                'objRadioButtonHospitalizacion.Enabled = True
                'objRadioButtonHospice.Enabled = False
                'objRadioButtonProgramaDomiciliario.Enabled = False
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            '    ''Si complejidad sintomatica (clinica) es ALTA y complejidad psicosocial es INTERMEDIA y compelejidad de la atencion es BAJA
            '    ''==> AMBULATORIO ALTA COMPLEJIDAD	/ HOSPITALIZACION
            '6
            If strCompeljidadClinica.Equals("Alta") And strComplejidadPsicoSocial.Equals("Intermedia") And strCompeljidadAtenncion.Equals("Baja") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Hospice")
                BorrarElementoComboBox(cboLugarDerivacion, "Programa Domiciliario")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = True
                'objRadioButtonHospitalizacion.Enabled = True
                'objRadioButtonHospice.Enabled = False
                'objRadioButtonProgramaDomiciliario.Enabled = False
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            '    ''Si complejidad sintomatica (clinica) es ALTA y complejidad psicosocial es BAJA y compelejidad de la atencion es ALTA
            '    ''==> AMBULATORIO ALTA COMPLEJIDAD	/ HOSPITALIZACION
            '7
            If strCompeljidadClinica.Equals("Alta") And strComplejidadPsicoSocial.Equals("Baja") And strCompeljidadAtenncion.Equals("Alta") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Hospice")
                BorrarElementoComboBox(cboLugarDerivacion, "Programa Domiciliario")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = True
                'objRadioButtonHospitalizacion.Enabled = True
                'objRadioButtonHospice.Enabled = False
                'objRadioButtonProgramaDomiciliario.Enabled = False
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            '    ''Si complejidad sintomatica (clinica) es ALTA y complejidad psicosocial es BAJA y compelejidad de la atencion es INTERMEDIA
            '    ''==> AMBULATORIO ALTA COMPLEJIDAD	/ HOSPITALIZACION
            '8
            If strCompeljidadClinica.Equals("Alta") And strComplejidadPsicoSocial.Equals("Baja") And strCompeljidadAtenncion.Equals("Intermedia") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Hospice")
                BorrarElementoComboBox(cboLugarDerivacion, "Programa Domiciliario")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = True
                'objRadioButtonHospitalizacion.Enabled = True
                'objRadioButtonHospice.Enabled = False
                'objRadioButtonProgramaDomiciliario.Enabled = False
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            '    ''Si complejidad sintomatica (clinica) es ALTA y complejidad psicosocial es BAJA y compelejidad de la atencion es BAJA
            '    ''==> AMBULATORIO ALTA COMPLEJIDAD	/ HOSPITALIZACION
            '9
            If strCompeljidadClinica.Equals("Alta") And strComplejidadPsicoSocial.Equals("Baja") And strCompeljidadAtenncion.Equals("Baja") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Hospice")
                BorrarElementoComboBox(cboLugarDerivacion, "Programa Domiciliario")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = True
                'objRadioButtonHospitalizacion.Enabled = True
                'objRadioButtonHospice.Enabled = False
                'objRadioButtonProgramaDomiciliario.Enabled = False
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            '    ''Si complejidad sintomatica (clinica) es INTERMEDIO y complejidad psicosocial es ALTA y compelejidad de la atencion es ALTO
            '    ''==> AMBULATORIO ALTA COMPLEJIDAD	/ HOSPITALIZACION
            '10
            If strCompeljidadClinica.Equals("Intermedia") And strComplejidadPsicoSocial.Equals("Alta") And strCompeljidadAtenncion.Equals("Alta") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Hospice")
                BorrarElementoComboBox(cboLugarDerivacion, "Programa Domiciliario")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = True
                'objRadioButtonHospitalizacion.Enabled = True
                'objRadioButtonHospice.Enabled = False
                'objRadioButtonProgramaDomiciliario.Enabled = False
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            '    ''Si complejidad sintomatica (clinica) es INTERMEDIO y complejidad psicosocial es ALTA y compelejidad de la atencion es INTERMEDIA
            '    ''==> AMBULATORIO ALTA COMPLEJIDAD	/ HOSPITALIZACION
            '11
            If strCompeljidadClinica.Equals("Intermedia") And strComplejidadPsicoSocial.Equals("Alta") And strCompeljidadAtenncion.Equals("Intermedia") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Hospitalizacion")
                BorrarElementoComboBox(cboLugarDerivacion, "Hospice")
                BorrarElementoComboBox(cboLugarDerivacion, "Programa Domiciliario")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = True
                'objRadioButtonHospitalizacion.Enabled = False
                'objRadioButtonHospice.Enabled = False
                'objRadioButtonProgramaDomiciliario.Enabled = False
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            '    ''Si complejidad sintomatica (clinica) es INTERMEDIO y complejidad psicosocial es ALTA y compelejidad de la atencion es BAJA
            '    ''==> AMBULATORIO ALTA COMPLEJIDAD	/ HOSPITALIZACION
            '12
            If strCompeljidadClinica.Equals("Intermedia") And strComplejidadPsicoSocial.Equals("Alta") And strCompeljidadAtenncion.Equals("Baja") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Hospitalizacion")
                BorrarElementoComboBox(cboLugarDerivacion, "Hospice")
                BorrarElementoComboBox(cboLugarDerivacion, "Programa Domiciliario")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = True
                'objRadioButtonHospitalizacion.Enabled = False
                'objRadioButtonHospice.Enabled = False
                'objRadioButtonProgramaDomiciliario.Enabled = False
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            '    ''Si complejidad sintomatica (clinica) es INTERMEDIO y complejidad psicosocial es INTERMEDIO y compelejidad de la atencion es ALTA
            '    ''==> AMBULATORIO ALTA COMPLEJIDAD	/ HOSPITALIZACION
            '13
            If strCompeljidadClinica.Equals("Intermedia") And strComplejidadPsicoSocial.Equals("Intermedia") And strCompeljidadAtenncion.Equals("Alta") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Hospice")
                BorrarElementoComboBox(cboLugarDerivacion, "Programa Domiciliario")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = True
                'objRadioButtonHospitalizacion.Enabled = True
                'objRadioButtonHospice.Enabled = False
                'objRadioButtonProgramaDomiciliario.Enabled = False
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            '    ''Si complejidad sintomatica (clinica) es INTERMEDIO y complejidad psicosocial es INTERMEDIO y compelejidad de la atencion es INTERMEDIO
            '    ''==> AMBULATORIO ALTA COMPLEJIDAD	
            '14
            If strCompeljidadClinica.Equals("Intermedia") And strComplejidadPsicoSocial.Equals("Intermedia") And strCompeljidadAtenncion.Equals("Intermedia") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Hospitalizacion")
                BorrarElementoComboBox(cboLugarDerivacion, "Hospice")
                BorrarElementoComboBox(cboLugarDerivacion, "Programa Domiciliario")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = True
                'objRadioButtonHospitalizacion.Enabled = False
                'objRadioButtonHospice.Enabled = False
                'objRadioButtonProgramaDomiciliario.Enabled = False
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            '    ''Si complejidad sintomatica (clinica) es INTERMEDIO y complejidad psicosocial es INTERMEDIO y compelejidad de la atencion es BAJA
            '    ''==> AMBULATORIO BAJA COMPLEJIDAD
            '15
            If strCompeljidadClinica.Equals("Intermedia") And strComplejidadPsicoSocial.Equals("Intermedia") And strCompeljidadAtenncion.Equals("Baja") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Alta Complejidad")
                BorrarElementoComboBox(cboLugarDerivacion, "Hospitalizacion")
                BorrarElementoComboBox(cboLugarDerivacion, "Hospice")
                BorrarElementoComboBox(cboLugarDerivacion, "Programa Domiciliario")

                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = False
                'objRadioButtonHospitalizacion.Enabled = False
                'objRadioButtonHospice.Enabled = False
                'objRadioButtonProgramaDomiciliario.Enabled = False
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = True
            End If

            '    ''Si complejidad sintomatica (clinica) es INTERMEDIO y complejidad psicosocial es BAJA y compelejidad de la atencion es ALTA
            '    ''==> AMBULATORIO ALTA COMPLEJIDAD	/ HOSPITALIZACION
            '16
            If strCompeljidadClinica.Equals("Intermedia") And strComplejidadPsicoSocial.Equals("Baja") And strCompeljidadAtenncion.Equals("Alta") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Hospice")
                BorrarElementoComboBox(cboLugarDerivacion, "Programa Domiciliario")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = True
                'objRadioButtonHospitalizacion.Enabled = True
                'objRadioButtonHospice.Enabled = False
                'objRadioButtonProgramaDomiciliario.Enabled = False
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            '    ''Si complejidad sintomatica (clinica) es INTERMEDIO y complejidad psicosocial es BAJA y compelejidad de la atencion es INTERMEDIA
            '    ''==> AMBULATORIO ALTA COMPLEJIDAD	/ HOSPITALIZACION
            '17
            If strCompeljidadClinica.Equals("Intermedia") And strComplejidadPsicoSocial.Equals("Baja") And strCompeljidadAtenncion.Equals("Intermedia") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Hospitalizacion")
                BorrarElementoComboBox(cboLugarDerivacion, "Hospice")
                BorrarElementoComboBox(cboLugarDerivacion, "Programa Domiciliario")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = True
                'objRadioButtonHospitalizacion.Enabled = False
                'objRadioButtonHospice.Enabled = False
                'objRadioButtonProgramaDomiciliario.Enabled = False
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            '    ''Si complejidad sintomatica (clinica) es INTERMEDIO y complejidad psicosocial es BAJA y compelejidad de la atencion es BAJA
            '    ''==> AMBULATORIO ALTA COMPLEJIDAD	/ HOSPITALIZACION
            '18
            If strCompeljidadClinica.Equals("Intermedia") And strComplejidadPsicoSocial.Equals("Baja") And strCompeljidadAtenncion.Equals("Baja") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Alta Complejidad")
                BorrarElementoComboBox(cboLugarDerivacion, "Hospitalizacion")
                BorrarElementoComboBox(cboLugarDerivacion, "Hospice")
                BorrarElementoComboBox(cboLugarDerivacion, "Programa Domiciliario")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = False
                'objRadioButtonHospitalizacion.Enabled = False
                'objRadioButtonHospice.Enabled = False
                'objRadioButtonProgramaDomiciliario.Enabled = False
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = True
            End If

            '    ''Si complejidad sintomatica (clinica) es BAJA y complejidad psicosocial es ALTA y compelejidad de la atencion es ALTA
            '    ''==> AMBULATORIO ALTA COMPLEJIDAD	/ HOSPITALIZACION
            '19
            If strCompeljidadClinica.Equals("Baja") And strComplejidadPsicoSocial.Equals("Alta") And strCompeljidadAtenncion.Equals("Alta") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Hospice")
                BorrarElementoComboBox(cboLugarDerivacion, "Programa Domiciliario")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = True
                'objRadioButtonHospitalizacion.Enabled = True
                'objRadioButtonHospice.Enabled = False
                'objRadioButtonProgramaDomiciliario.Enabled = False
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            '    ''Si complejidad sintomatica (clinica) es BAJA y complejidad psicosocial es ALTA y compelejidad de la atencion es INTERMEDIA
            '    ''==> AMBULATORIO ALTA COMPLEJIDAD	
            '20
            If strCompeljidadClinica.Equals("Baja") And strComplejidadPsicoSocial.Equals("Alta") And strCompeljidadAtenncion.Equals("Intermedia") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Hospitalizacion")
                BorrarElementoComboBox(cboLugarDerivacion, "Hospice")
                BorrarElementoComboBox(cboLugarDerivacion, "Programa Domiciliario")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = True
                'objRadioButtonHospitalizacion.Enabled = False
                'objRadioButtonHospice.Enabled = False
                'objRadioButtonProgramaDomiciliario.Enabled = False
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False

            End If

            '    ''Si complejidad sintomatica (clinica) es BAJA y complejidad psicosocial es ALTA y compelejidad de la atencion es BAJA
            '    ''==> AMBULATORIO ALTA COMPLEJIDAD	
            '21
            If strCompeljidadClinica.Equals("Baja") And strComplejidadPsicoSocial.Equals("Alta") And strCompeljidadAtenncion.Equals("Baja") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Hospitalizacion")
                BorrarElementoComboBox(cboLugarDerivacion, "Hospice")
                BorrarElementoComboBox(cboLugarDerivacion, "Programa Domiciliario")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = True
                'objRadioButtonHospitalizacion.Enabled = False
                'objRadioButtonHospice.Enabled = False
                'objRadioButtonProgramaDomiciliario.Enabled = False
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            '    ''Si complejidad sintomatica (clinica) es BAJA y complejidad psicosocial es INTERMEDIA y compelejidad de la atencion es ALTA
            '    ''==> AMBULATORIO ALTA COMPLEJIDAD	/ HOSPITALIZACION
            '22
            If strCompeljidadClinica.Equals("Baja") And strComplejidadPsicoSocial.Equals("Intermedia") And strCompeljidadAtenncion.Equals("Alta") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Hospice")
                BorrarElementoComboBox(cboLugarDerivacion, "Programa Domiciliario")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = True
                'objRadioButtonHospitalizacion.Enabled = True
                'objRadioButtonHospice.Enabled = False
                'objRadioButtonProgramaDomiciliario.Enabled = False
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            '    ''Si complejidad sintomatica (clinica) es BAJA y complejidad psicosocial es INTERMEDIA y compelejidad de la atencion es INTERMEDIA
            '    ''==> AMBULATORIO ALTA COMPLEJIDAD	/ HOSPITALIZACION
            '23
            If strCompeljidadClinica.Equals("Baja") And strComplejidadPsicoSocial.Equals("Intermedia") And strCompeljidadAtenncion.Equals("Intermedia") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Hospitalizacion")
                BorrarElementoComboBox(cboLugarDerivacion, "Hospice")
                BorrarElementoComboBox(cboLugarDerivacion, "Programa Domiciliario")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = True
                'objRadioButtonHospitalizacion.Enabled = False
                'objRadioButtonHospice.Enabled = False
                'objRadioButtonProgramaDomiciliario.Enabled = False
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            '    ''Si complejidad sintomatica (clinica) es BAJA y complejidad psicosocial es INTERMEDIA y compelejidad de la atencion es BAJA
            '    ''==> AMBULATORIO ALTA COMPLEJIDAD	
            '24
            If strCompeljidadClinica.Equals("Baja") And strComplejidadPsicoSocial.Equals("Intermedia") And strCompeljidadAtenncion.Equals("Baja") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Hospitalizacion")
                BorrarElementoComboBox(cboLugarDerivacion, "Hospice")
                BorrarElementoComboBox(cboLugarDerivacion, "Programa Domiciliario")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = True
                'objRadioButtonHospitalizacion.Enabled = False
                'objRadioButtonHospice.Enabled = False
                'objRadioButtonProgramaDomiciliario.Enabled = False
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            '    ''Si complejidad sintomatica (clinica) es BAJA y complejidad psicosocial es BAJA y compelejidad de la atencion es ALTA
            '    ''==> AMBULATORIO ALTA COMPLEJIDAD	/ HOSPITALIZACION
            '25
            If strCompeljidadClinica.Equals("Baja") And strComplejidadPsicoSocial.Equals("Baja") And strCompeljidadAtenncion.Equals("Alta") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Hospice")
                BorrarElementoComboBox(cboLugarDerivacion, "Programa Domiciliario")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = True
                'objRadioButtonHospitalizacion.Enabled = True
                'objRadioButtonHospice.Enabled = False
                'objRadioButtonProgramaDomiciliario.Enabled = False
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            '    ''Si complejidad sintomatica (clinica) es BAJA y complejidad psicosocial es BAJA y compelejidad de la atencion es INTERMEDIA
            '    ''==> AMBULATORIO ALTA COMPLEJIDAD	
            '26
            If strCompeljidadClinica.Equals("Baja") And strComplejidadPsicoSocial.Equals("Baja") And strCompeljidadAtenncion.Equals("Intermedia") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Hospitalizacion")
                BorrarElementoComboBox(cboLugarDerivacion, "Hospice")
                BorrarElementoComboBox(cboLugarDerivacion, "Programa Domiciliario")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = True
                'objRadioButtonHospitalizacion.Enabled = False
                'objRadioButtonHospice.Enabled = False
                'objRadioButtonProgramaDomiciliario.Enabled = False
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            '    ''Si complejidad sintomatica (clinica) es BAJA y complejidad psicosocial es BAJA y compelejidad de la atencion es BAJA
            '    ''==> AMBULATORIO ALTA COMPLEJIDAD	
            '27
            If strCompeljidadClinica.Equals("Baja") And strComplejidadPsicoSocial.Equals("Baja") And strCompeljidadAtenncion.Equals("Baja") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Alta Complejidad")
                BorrarElementoComboBox(cboLugarDerivacion, "Hospitalizacion")
                BorrarElementoComboBox(cboLugarDerivacion, "Hospice")
                BorrarElementoComboBox(cboLugarDerivacion, "Programa Domiciliario")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = False
                'objRadioButtonHospitalizacion.Enabled = False
                'objRadioButtonHospice.Enabled = False
                'objRadioButtonProgramaDomiciliario.Enabled = False
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = True
            End If

        Else   'Si el resultado de cualquiera de las 2 escalas es menor de 50  (<= 50)

            ''Si complejidad sintomatica (clinica) es ALTA y complejidad psicosocial es ALTA y compelejidad de la atencion es ALTA
            ''==> HOSPITALIZACION
            '28
            If strCompeljidadClinica.Equals("Alta") And strComplejidadPsicoSocial.Equals("Alta") And strCompeljidadAtenncion.Equals("Alta") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Alta Complejidad")
                BorrarElementoComboBox(cboLugarDerivacion, "Hospice")
                BorrarElementoComboBox(cboLugarDerivacion, "Programa Domiciliario")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = False
                'objRadioButtonHospitalizacion.Enabled = True
                'objRadioButtonHospice.Enabled = False
                'objRadioButtonProgramaDomiciliario.Enabled = False
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If
            ''Si complejidad sintomatica (clinica) es ALTA y complejidad psicosocial es ALTA y compelejidad de la atencion es INTERMEDIA
            ''==> HOSPITALIZACION / HOSPICE
            '29
            If strCompeljidadClinica.Equals("Alta") And strComplejidadPsicoSocial.Equals("Alta") And strCompeljidadAtenncion.Equals("Intermedia") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Alta Complejidad")
                BorrarElementoComboBox(cboLugarDerivacion, "Programa Domiciliario")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = False
                'objRadioButtonHospitalizacion.Enabled = True
                'objRadioButtonHospice.Enabled = True
                'objRadioButtonProgramaDomiciliario.Enabled = False
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            ''Si complejidad sintomatica (clinica) es ALTA y complejidad psicosocial es ALTA y compelejidad de la atencion es BAJA
            ''==> HOSPITALIZACION / PROGRAMA DOMICLIARIO / HOSPICE
            '30
            If strCompeljidadClinica.Equals("Alta") And strComplejidadPsicoSocial.Equals("Alta") And strCompeljidadAtenncion.Equals("Baja") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Alta Complejidad")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = False
                'objRadioButtonHospitalizacion.Enabled = True
                'objRadioButtonHospice.Enabled = True
                'objRadioButtonProgramaDomiciliario.Enabled = True
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            ''Si complejidad sintomatica (clinica) es ALTA y complejidad psicosocial es INTERMEDIA y compelejidad de la atencion es ALTA
            ''==> HOSPITALIZACION / HOSPICE
            '31
            If strCompeljidadClinica.Equals("Alta") And strComplejidadPsicoSocial.Equals("Intermedia") And strCompeljidadAtenncion.Equals("Alta") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Alta Complejidad")
                BorrarElementoComboBox(cboLugarDerivacion, "Programa Domiciliario")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = False
                'objRadioButtonHospitalizacion.Enabled = True
                'objRadioButtonHospice.Enabled = True
                'objRadioButtonProgramaDomiciliario.Enabled = False
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            ''Si complejidad sintomatica (clinica) es ALTA y complejidad psicosocial es INTERMEDIA y compelejidad de la atencion es INTERMEDIA
            ''==> HOSPITALIZACION / PROGRAMA DOMICLIARIO / HOSPICE
            '32
            If strCompeljidadClinica.Equals("Alta") And strComplejidadPsicoSocial.Equals("Intermedia") And strCompeljidadAtenncion.Equals("Intermedia") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Alta Complejidad")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = False
                'objRadioButtonHospitalizacion.Enabled = True
                'objRadioButtonHospice.Enabled = True
                'objRadioButtonProgramaDomiciliario.Enabled = True
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            ''Si complejidad sintomatica (clinica) es ALTA y complejidad psicosocial es INTERMEDIA y compelejidad de la atencion es BAJA
            ''==> HOSPITALIZACION / PROGRAMA DOMICLIARIO 
            '33
            If strCompeljidadClinica.Equals("Alta") And strComplejidadPsicoSocial.Equals("Intermedia") And strCompeljidadAtenncion.Equals("Baja") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Alta Complejidad")
                BorrarElementoComboBox(cboLugarDerivacion, "Hospice")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = False
                'objRadioButtonHospitalizacion.Enabled = True
                'objRadioButtonHospice.Enabled = False
                'objRadioButtonProgramaDomiciliario.Enabled = True
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            ''Si complejidad sintomatica (clinica) es ALTA y complejidad psicosocial es BAJA y compelejidad de la atencion es ALTA
            ''==> HOSPITALIZACION / HOSPICE
            '34
            If strCompeljidadClinica.Equals("Alta") And strComplejidadPsicoSocial.Equals("Baja") And strCompeljidadAtenncion.Equals("Alta") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Alta Complejidad")
                BorrarElementoComboBox(cboLugarDerivacion, "Programa Domiciliario")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = False
                'objRadioButtonHospitalizacion.Enabled = True
                'objRadioButtonHospice.Enabled = True
                'objRadioButtonProgramaDomiciliario.Enabled = False
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If
            ''Si complejidad sintomatica (clinica) es ALTA y complejidad psicosocial es BAJA y compelejidad de la atencion es INTERMEDIA
            ''==> HOSPITALIZACION / PROGRAMA DOMICLIARIO / HOSPICE
            '35
            If strCompeljidadClinica.Equals("Alta") And strComplejidadPsicoSocial.Equals("Baja") And strCompeljidadAtenncion.Equals("Intermedia") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Alta Complejidad")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = False
                'objRadioButtonHospitalizacion.Enabled = True
                'objRadioButtonHospice.Enabled = True
                'objRadioButtonProgramaDomiciliario.Enabled = True
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If
            ''Si complejidad sintomatica (clinica) es ALTA y complejidad psicosocial es BAJA y compelejidad de la atencion es BAJA
            ''==> HOSPITALIZACION / PROGRAMA DOMICLIARIO 
            '36
            If strCompeljidadClinica.Equals("Alta") And strComplejidadPsicoSocial.Equals("Baja") And strCompeljidadAtenncion.Equals("Baja") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Alta Complejidad")
                BorrarElementoComboBox(cboLugarDerivacion, "Hospice")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = False
                'objRadioButtonHospitalizacion.Enabled = True
                'objRadioButtonHospice.Enabled = False
                'objRadioButtonProgramaDomiciliario.Enabled = True
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If
            ''Si complejidad sintomatica (clinica) es INTERMEDIA y complejidad psicosocial es ALTA y compelejidad de la atencion es ALTA
            ''==> HOSPITALIZACION / HOSPICE
            '37
            If strCompeljidadClinica.Equals("Intermedia") And strComplejidadPsicoSocial.Equals("Alta") And strCompeljidadAtenncion.Equals("Alta") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Alta Complejidad")
                BorrarElementoComboBox(cboLugarDerivacion, "Programa Domiciliario")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = False
                'objRadioButtonHospitalizacion.Enabled = True
                'objRadioButtonHospice.Enabled = True
                'objRadioButtonProgramaDomiciliario.Enabled = False
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If
            ''Si complejidad sintomatica (clinica) es INTERMEDIA y complejidad psicosocial es ALTA y compelejidad de la atencion es INTERMDIA
            ''==>  HOSPICE
            '38
            If strCompeljidadClinica.Equals("Intermedia") And strComplejidadPsicoSocial.Equals("Alta") And strCompeljidadAtenncion.Equals("Intermedia") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Alta Complejidad")
                BorrarElementoComboBox(cboLugarDerivacion, "Hospitalizacion")
                BorrarElementoComboBox(cboLugarDerivacion, "Programa Domiciliario")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = False
                'objRadioButtonHospitalizacion.Enabled = False
                'objRadioButtonHospice.Enabled = True
                'objRadioButtonProgramaDomiciliario.Enabled = False
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            ''Si complejidad sintomatica (clinica) es INTERMEDIA y complejidad psicosocial es ALTA y compelejidad de la atencion es BAJA
            ''==>   PROGRAMA DOMICLIARIO  / HOSPICE
            '39
            If strCompeljidadClinica.Equals("Intermedia") And strComplejidadPsicoSocial.Equals("Alta") And strCompeljidadAtenncion.Equals("Baja") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Alta Complejidad")
                BorrarElementoComboBox(cboLugarDerivacion, "Hospitalizacion")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = False
                'objRadioButtonHospitalizacion.Enabled = False
                'objRadioButtonHospice.Enabled = True
                'objRadioButtonProgramaDomiciliario.Enabled = True
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            ''Si complejidad sintomatica (clinica) es INTERMEDIA y complejidad psicosocial es INTERMEDIA y compelejidad de la atencion es ALTA
            ''==>    HOSPITALIZACION / HOSPICE
            '40
            If strCompeljidadClinica.Equals("Intermedia") And strComplejidadPsicoSocial.Equals("Intermedia") And strCompeljidadAtenncion.Equals("Alta") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Alta Complejidad")
                BorrarElementoComboBox(cboLugarDerivacion, "Programa Domiciliario")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = False
                'objRadioButtonHospitalizacion.Enabled = True
                'objRadioButtonHospice.Enabled = True
                'objRadioButtonProgramaDomiciliario.Enabled = False
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            ''Si complejidad sintomatica (clinica) es INTERMEDIA y complejidad psicosocial es INTERMEDIA y compelejidad de la atencion es INTERMEDIA
            ''==>   PROGRAMA DOMICLIARIO  / HOSPICE
            '41
            If strCompeljidadClinica.Equals("Intermedia") And strComplejidadPsicoSocial.Equals("Intermedia") And strCompeljidadAtenncion.Equals("Intermedia") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Alta Complejidad")
                BorrarElementoComboBox(cboLugarDerivacion, "Hospitalizacion")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = False
                'objRadioButtonHospitalizacion.Enabled = False
                'objRadioButtonHospice.Enabled = True
                'objRadioButtonProgramaDomiciliario.Enabled = True
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            ''Si complejidad sintomatica (clinica) es INTERMEDIA y complejidad psicosocial es INTERMEDIA y compelejidad de la atencion es BAJA
            ''==>   PROGRAMA DOMICLIARIO 
            '42
            If strCompeljidadClinica.Equals("Intermedia") And strComplejidadPsicoSocial.Equals("Intermedia") And strCompeljidadAtenncion.Equals("Baja") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Alta Complejidad")
                BorrarElementoComboBox(cboLugarDerivacion, "Hospitalizacion")
                BorrarElementoComboBox(cboLugarDerivacion, "Hospice")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = False
                'objRadioButtonHospitalizacion.Enabled = False
                'objRadioButtonHospice.Enabled = False
                'objRadioButtonProgramaDomiciliario.Enabled = True
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            ''Si complejidad sintomatica (clinica) es INTERMEDIA y complejidad psicosocial es INTERMEDIA y compelejidad de la atencion es ALTA
            ''==>    HOSPITALIZACION / HOSPICE
            '43
            If strCompeljidadClinica.Equals("Intermedia") And strComplejidadPsicoSocial.Equals("Baja") And strCompeljidadAtenncion.Equals("Alta") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Alta Complejidad")
                BorrarElementoComboBox(cboLugarDerivacion, "Programa Domiciliario")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = False
                'objRadioButtonHospitalizacion.Enabled = True
                'objRadioButtonHospice.Enabled = True
                'objRadioButtonProgramaDomiciliario.Enabled = False
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            ''Si complejidad sintomatica (clinica) es INTERMEDIA y complejidad psicosocial es BAJA y compelejidad de la atencion es INTERMEDIA
            ''==>     PROGRAMA DOMICLIARIO  / HOSPICE
            '44
            If strCompeljidadClinica.Equals("Intermedia") And strComplejidadPsicoSocial.Equals("Baja") And strCompeljidadAtenncion.Equals("Intermedia") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Alta Complejidad")
                BorrarElementoComboBox(cboLugarDerivacion, "Hospitalizacion")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = False
                'objRadioButtonHospitalizacion.Enabled = False
                'objRadioButtonHospice.Enabled = True
                'objRadioButtonProgramaDomiciliario.Enabled = True
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            ''Si complejidad sintomatica (clinica) es INTERMEDIA y complejidad psicosocial es BAJA y compelejidad de la atencion es BAJA
            ''==>     PROGRAMA DOMICLIARIO
            '45
            If strCompeljidadClinica.Equals("Intermedia") And strComplejidadPsicoSocial.Equals("Baja") And strCompeljidadAtenncion.Equals("Baja") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Alta Complejidad")
                BorrarElementoComboBox(cboLugarDerivacion, "Hospitalizacion")
                BorrarElementoComboBox(cboLugarDerivacion, "Hospice")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = False
                'objRadioButtonHospitalizacion.Enabled = False
                'objRadioButtonHospice.Enabled = False
                'objRadioButtonProgramaDomiciliario.Enabled = True
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            ''Si complejidad sintomatica (clinica) es BAJA y complejidad psicosocial es ALTA y compelejidad de la atencion es ALTA
            ''==>      HOSPITALIZACION / HOSPICE
            '46
            If strCompeljidadClinica.Equals("Baja") And strComplejidadPsicoSocial.Equals("Alta") And strCompeljidadAtenncion.Equals("Alta") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Alta Complejidad")
                BorrarElementoComboBox(cboLugarDerivacion, "Programa Domiciliario")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = False
                'objRadioButtonHospitalizacion.Enabled = True
                'objRadioButtonHospice.Enabled = True
                'objRadioButtonProgramaDomiciliario.Enabled = False
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            ''Si complejidad sintomatica (clinica) es BAJA y complejidad psicosocial es ALTA y compelejidad de la atencion es INTERMEDIA
            ''==>      HOSPITALIZACION / HOSPICE
            '47
            If strCompeljidadClinica.Equals("Baja") And strComplejidadPsicoSocial.Equals("Alta") And strCompeljidadAtenncion.Equals("Intermedia") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Alta Complejidad")
                BorrarElementoComboBox(cboLugarDerivacion, "Programa Domiciliario")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = False
                'objRadioButtonHospitalizacion.Enabled = True
                'objRadioButtonHospice.Enabled = True
                'objRadioButtonProgramaDomiciliario.Enabled = False
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            ''Si complejidad sintomatica (clinica) es BAJA y complejidad psicosocial es ALTA y compelejidad de la atencion es BAJA
            ''==>      PROGRAMA DOMICLIARIO / HOSPICE
            '48
            If strCompeljidadClinica.Equals("Baja") And strComplejidadPsicoSocial.Equals("Alta") And strCompeljidadAtenncion.Equals("Baja") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Alta Complejidad")
                BorrarElementoComboBox(cboLugarDerivacion, "Hospitalizacion")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = False
                'objRadioButtonHospitalizacion.Enabled = False
                'objRadioButtonHospice.Enabled = True
                'objRadioButtonProgramaDomiciliario.Enabled = True
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            ''Si complejidad sintomatica (clinica) es BAJA y complejidad psicosocial es INTERMEDIA y compelejidad de la atencion es ALTA
            ''==>      HOSPITALIZACION / HOSPICE
            '49
            If strCompeljidadClinica.Equals("Baja") And strComplejidadPsicoSocial.Equals("Intermedia") And strCompeljidadAtenncion.Equals("Alta") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Alta Complejidad")
                BorrarElementoComboBox(cboLugarDerivacion, "Programa Domiciliario")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = False
                'objRadioButtonHospitalizacion.Enabled = True
                'objRadioButtonHospice.Enabled = True
                'objRadioButtonProgramaDomiciliario.Enabled = False
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            ''Si complejidad sintomatica (clinica) es BAJA y complejidad psicosocial es INTERMEDIA y compelejidad de la atencion es INTERMEDIA
            ''==>      PROGRAMA DOMICLIARIO / HOSPICE
            '50
            If strCompeljidadClinica.Equals("Baja") And strComplejidadPsicoSocial.Equals("Intermedia") And strCompeljidadAtenncion.Equals("Intermedia") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Alta Complejidad")
                BorrarElementoComboBox(cboLugarDerivacion, "Hospitalizacion")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = False
                'objRadioButtonHospitalizacion.Enabled = False
                'objRadioButtonHospice.Enabled = True
                'objRadioButtonProgramaDomiciliario.Enabled = True
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            ''Si complejidad sintomatica (clinica) es BAJA y complejidad psicosocial es INTERMEDIA y compelejidad de la atencion es BAJA
            ''==>      PROGRAMA DOMICLIARIO
            '51
            If strCompeljidadClinica.Equals("Baja") And strComplejidadPsicoSocial.Equals("Intermedia") And strCompeljidadAtenncion.Equals("Baja") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Alta Complejidad")
                BorrarElementoComboBox(cboLugarDerivacion, "Hospitalizacion")
                BorrarElementoComboBox(cboLugarDerivacion, "Hospice")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = False
                'objRadioButtonHospitalizacion.Enabled = False
                'objRadioButtonHospice.Enabled = False
                'objRadioButtonProgramaDomiciliario.Enabled = True
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            ''Si complejidad sintomatica (clinica) es BAJA y complejidad psicosocial es BAJA y compelejidad de la atencion es ALTA
            ''==>      HOSPITALIZACION / HOSPICE
            '52
            If strCompeljidadClinica.Equals("Baja") And strComplejidadPsicoSocial.Equals("Baja") And strCompeljidadAtenncion.Equals("Alta") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Alta Complejidad")
                BorrarElementoComboBox(cboLugarDerivacion, "Programa Domiciliario")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = False
                'objRadioButtonHospitalizacion.Enabled = True
                'objRadioButtonHospice.Enabled = True
                'objRadioButtonProgramaDomiciliario.Enabled = False
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            ''Si complejidad sintomatica (clinica) es BAJA y complejidad psicosocial es BAJA y compelejidad de la atencion es INTERMEDIA
            ''==>      PROGRAMA DOMICLIARIO / HOSPICE
            '53
            If strCompeljidadClinica.Equals("Baja") And strComplejidadPsicoSocial.Equals("Baja") And strCompeljidadAtenncion.Equals("Intermedia") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Alta Complejidad")
                BorrarElementoComboBox(cboLugarDerivacion, "Hospitalizacion")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = False
                'objRadioButtonHospitalizacion.Enabled = False
                'objRadioButtonHospice.Enabled = True
                'objRadioButtonProgramaDomiciliario.Enabled = True
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If

            ''Si complejidad sintomatica (clinica) es BAJA y complejidad psicosocial es BAJA y compelejidad de la atencion es BAJA
            ''==>      PROGRAMA DOMICLIARIO
            '55
            If strCompeljidadClinica.Equals("Baja") And strComplejidadPsicoSocial.Equals("Baja") And strCompeljidadAtenncion.Equals("Baja") Then
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Alta Complejidad")
                BorrarElementoComboBox(cboLugarDerivacion, "Hospitalizacion")
                BorrarElementoComboBox(cboLugarDerivacion, "Hospice")
                BorrarElementoComboBox(cboLugarDerivacion, "Ambulatorio Baja Complejidad")
                'objRadioButtonAmbulatorioAltaComplejidad.Enabled = False
                'objRadioButtonHospitalizacion.Enabled = False
                'objRadioButtonHospice.Enabled = False
                'objRadioButtonProgramaDomiciliario.Enabled = True
                'objRadioButtonAmbulatorioBajaComplejidad.Enabled = False
            End If
            cboLugarDerivacion.Enabled = True
        End If

        '    If ((strCompeljidadClinica.Equals("Intermedia") OrElse strCompeljidadClinica.Equals("Baja")) _
        '        AndAlso strComplejidadPsicoSocial.Equals("Baja") _
        '        AndAlso strCompeljidadAtenncion.Equals("Baja")) Then
        '        lblResultadoLugDerivacion.Text = "Atención ambulatoria baja complejidad"
        '    ElseIf ((strCompeljidadClinica.Equals("Alta") OrElse strCompeljidadClinica.Equals("Intermedia") OrElse strCompeljidadClinica.Equals("Baja")) _
        '        AndAlso (strComplejidadPsicoSocial.Equals("Alta") OrElse strComplejidadPsicoSocial.Equals("Intermedia")) _
        '        AndAlso (strCompeljidadAtenncion.Equals("Alta") OrElse strCompeljidadAtenncion.Equals("Intermedia"))) Then
        '        lblResultadoLugDerivacion.Text = "Atención ambulatoria de clínica"
        '    Else
        '        ctrlVisible = False
        '    End If
        'Else
        '    'Si el resultado de cualquiera de las 2 escalas es menor de 50 
        '    If ((strCompeljidadClinica.Equals("Alta") OrElse strCompeljidadClinica.Equals("Intermedia") OrElse strCompeljidadClinica.Equals("Baja")) _
        '        AndAlso (strComplejidadPsicoSocial.Equals("Alta") OrElse strComplejidadPsicoSocial.Equals("Intermedia") OrElse strComplejidadPsicoSocial.Equals("Baja")) _
        '        AndAlso strCompeljidadAtenncion.Equals("Baja")) Then
        '        lblResultadoLugDerivacion.Text = "Programa domiciliario de cuidados paliativos"
        '    ElseIf ((strCompeljidadClinica.Equals("Alta") OrElse strCompeljidadClinica.Equals("Intermedia") OrElse strCompeljidadClinica.Equals("Baja")) _
        '        AndAlso strComplejidadPsicoSocial.Equals("Alta") _
        '        AndAlso strCompeljidadAtenncion.Equals("Intermedia")) Then
        '        lblResultadoLugDerivacion.Text = "Hospice (Requiere autorización por junta)"
        '    ElseIf ((strCompeljidadClinica.Equals("Alta") OrElse strCompeljidadClinica.Equals("Intermedia") OrElse strCompeljidadClinica.Equals("Baja")) _
        '                    AndAlso (strComplejidadPsicoSocial.Equals("Alta") OrElse strComplejidadPsicoSocial.Equals("Intermedia") OrElse strComplejidadPsicoSocial.Equals("Baja")) _
        '                    AndAlso strCompeljidadAtenncion.Equals("Alta")) Then
        '        lblResultadoLugDerivacion.Text = "Hospitalización"
        '    Else
        '        ctrlVisible = False
        '    End If
        'End If
        'If (Not ctrlVisible) Then
        '    lblResultadoLugDerivacion.Text = String.Empty
        'End If
    End Sub

    ''' <summary>
    ''' Realiza la actualización del calculo para el campo Lugar Derivación cuando la conclusión
    ''' de cada sección cambia dependiendo de la selección del usuario 
    ''' </summary>
    Private Sub lblConclusionComplejidadAtencion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblConclusionComplejidadAtencion.TextChanged, lblConclusionComplejidadPsicosocial.TextChanged, lblConclusionComplejidadClinica.TextChanged
        If (RB_PPS_Preg520.Checked OrElse RB_IK_Preg520.Checked) Then
            If (IsNumeric(txtEscalaTMP.Text)) Then
                calcularLugarDerivacion(txtEscalaTMP.Text)
            End If
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        ''WACHV,22sept2017, valida que todos esten diligenciados segun sea el grupo
        If (bfncObligatoriedad() = False) Then
            MessageBox.Show("Se deben Diligenciar todas las preguntas.")
            Exit Sub
        End If
        IngresarInfoComplejidadDerivacion()
    End Sub

    ''' <summary>
    ''' Ingresar la información a la BD
    ''' </summary>
    Private Sub IngresarInfoComplejidadDerivacion()
        Dim strMensaje As String = ""
        Dim objComplejidadDerivacion As New ComplejidadDerivacion

        With objComplejidadDerivacion
            .Prestador = objGeneral.Prestador
            .Sucursal = objGeneral.Sucursal
            .TipoAdmision = objPaciente.TipoAdmision
            .AnoAdmision = objPaciente.AnoAdmision
            .NumeroAdmision = objPaciente.NumeroAdmision
            .Login = objGeneral.Login
            .Observaciones = String.Empty
            .TipoDocumento = objPaciente.TipoDocumento
            .NumeroDocumento = objPaciente.NumeroDocumento
            .ResultadoEscala = txtEscalaTMP.Text

            Dim ctrlsGB As List(Of GroupBox) ''''Complejidad Clinica
            ctrlsGB = Me.GetTypeControls(Of GroupBox)(GBComplejidadClinica, False, Nothing)
            For Each ctrl As GroupBox In ctrlsGB
                If (ctrl.Enabled) Then
                    Dim item As New PreguntaComplejidad
                    Dim ctrlSi As Control() = ctrl.Controls.Find("RB_Si_" & (CType(ctrl, GroupBox)).Tag, False)
                    Dim ctrlNo As Control() = ctrl.Controls.Find("RB_No_" & (CType(ctrl, GroupBox)).Tag, False)
                    If ((DirectCast(ctrlSi(0), RadioButton)).Checked _
                   OrElse (DirectCast(ctrlNo(0), RadioButton)).Checked) Then
                        With item
                            .NombreCampo = ctrl.Tag
                            .RespuestaPregunta = IIf((DirectCast(ctrlSi(0), RadioButton)).Checked, "SI", _
                            IIf((DirectCast(ctrlNo(0), RadioButton)).Checked, "NO", String.Empty))
                        End With
                        .itemsComplejidadClinica.Add(item)
                    End If
                End If
            Next

            ctrlsGB = Me.GetTypeControls(Of GroupBox)(GBComplejidadPsicosocial, False, Nothing)  ''''Complejidad Psicosocial
            For Each ctrl As GroupBox In ctrlsGB
                If (ctrl.Enabled) Then
                    Dim ctrlSi As Control() = ctrl.Controls.Find("RB_Si_" & (CType(ctrl, GroupBox)).Tag, False)
                    Dim ctrlNo As Control() = ctrl.Controls.Find("RB_No_" & (CType(ctrl, GroupBox)).Tag, False)
                    If ((DirectCast(ctrlSi(0), RadioButton)).Checked _
                    OrElse (DirectCast(ctrlNo(0), RadioButton)).Checked) Then
                        Dim item As New PreguntaComplejidad
                        With item
                            .NombreCampo = ctrl.Tag
                            .RespuestaPregunta = IIf((DirectCast(ctrlSi(0), RadioButton)).Checked, "SI", _
                            IIf((DirectCast(ctrlNo(0), RadioButton)).Checked, "NO", String.Empty))
                        End With
                        .itemsComplejidadPsicosocial.Add(item)
                    End If
                End If
            Next

            ctrlsGB = Me.GetTypeControls(Of GroupBox)(GBComplejidadAtencion, False, Nothing)  ''''Complejidad Atencion
            For Each ctrl As GroupBox In ctrlsGB
                If (ctrl.Enabled) Then
                    Dim ctrlSi As Control() = ctrl.Controls.Find("RB_Si_" & (CType(ctrl, GroupBox)).Tag, False)
                    Dim ctrlNo As Control() = ctrl.Controls.Find("RB_No_" & (CType(ctrl, GroupBox)).Tag, False)
                    If ((DirectCast(ctrlSi(0), RadioButton)).Checked _
                    OrElse (DirectCast(ctrlNo(0), RadioButton)).Checked) Then
                        Dim item As New PreguntaComplejidad
                        With item
                            .NombreCampo = ctrl.Tag
                            .RespuestaPregunta = IIf((DirectCast(ctrlSi(0), RadioButton)).Checked, "SI", _
                            IIf((DirectCast(ctrlNo(0), RadioButton)).Checked, "NO", String.Empty))
                        End With
                        .itemsComplejidadAtencion.Add(item)
                    End If
                End If
            Next

            ctrlsGB = Me.GetTypeControls(Of GroupBox)(GBDerivacion, False, Nothing)  ''''Derivacion
            For Each ctrl As GroupBox In ctrlsGB ''recorre los controles dentro del group Box
                If (ctrl.Enabled) Then  ''Si esta activo
                    Dim ctrlPPS As Control() = ctrl.Controls.Find("RB_PPS_" & (CType(ctrl, GroupBox)).Tag, False)
                    Dim ctrlIK As Control() = ctrl.Controls.Find("RB_IK_" & (CType(ctrl, GroupBox)).Tag, False)
                    If (ctrlIK.Length = 1 AndAlso ctrlPPS.Length = 1) Then
                        If ((DirectCast(ctrlPPS(0), RadioButton)).Checked _
                                            OrElse (DirectCast(ctrlIK(0), RadioButton)).Checked) Then
                            Dim item As New PreguntaComplejidad
                            With item
                                .NombreCampo = ctrl.Tag
                                .RespuestaPregunta = IIf((DirectCast(ctrlPPS(0), RadioButton)).Checked, "PPS",
                                IIf((DirectCast(ctrlIK(0), RadioButton)).Checked, "IK", String.Empty))
                            End With
                            .itemsDerivacion.Add(item)
                        End If
                        'ElseIf ctrl.Tag.Equals("Preg521") Then   '''WACHV, 24OCT2017, NO SE LLENA ESTA PREGUNTA 
                        '    Dim lugDerv As Control() = ctrl.Controls.Find("lblResultadoLugDerivacion", False)
                        '    If (lugDerv.Length = 1) Then
                        '        Dim item As New PreguntaComplejidad
                        '        With item
                        '            .NombreCampo = ctrl.Tag
                        '            .RespuestaPregunta = DirectCast(lugDerv(0), Label).Text
                        '        End With
                        '        .itemsDerivacion.Add(item)
                        '    End If
                    ElseIf ctrl.Tag.Equals("Preg522") Then
                        Dim objResEscala As Control() = ctrl.Controls.Find("txtEscalaTMP", False)
                        If (objResEscala.Length = 1) Then
                            Dim item As New PreguntaComplejidad
                            With item
                                .NombreCampo = ctrl.Tag
                                .RespuestaPregunta = DirectCast(objResEscala(0), TextBox).Text
                            End With
                            .itemsDerivacion.Add(item)
                        End If
                        'Else
                        '    Dim resultado As Control() = ctrl.Controls.Find("txtEscalaTMP", False)
                        '    If (resultado.Length = 1) Then
                        '        Dim item As New PreguntaComplejidad
                        '        With item
                        '            .NombreCampo = ctrl.Tag
                        '            .RespuestaPregunta = DirectCast(resultado(0), TextBox).Text
                        '        End With
                        '        .itemsDerivacion.Add(item)
                        '    End If
                    End If
                End If
            Next
            ''pregunta 523
            .LugarDerivacionNva = cboLugarDerivacion.SelectedValue   '''WACHV, 24OCT2017, PARA EL NUEVO CAMPO, pregunta 523
            ''''WACHV,INICIO 13OCT2017, GUARDAR LOS TOTALES DE CADA ESCALA
            .TotalComplejidadClinica = lblConclusionComplejidadClinica.Text             ''pregunta 524
            .TotalComplejidadPsicoSocial = lblConclusionComplejidadPsicosocial.Text     ''pregunta 525
            .TotalComplejidadAtencion = lblConclusionComplejidadAtencion.Text           ''pregunta 526
            ''''WACHV,FIN 13OCT2017, GUARDAR LOS TOTALES DE CADA ESCALA
        End With

        Try
            strMensaje = objCompDeriv.GuardarPreguntasComplejidadDerivacion(objComplejidadDerivacion)

            If Len(strMensaje) = 0 Then
                MsgBox("La operación se realizó satisfactoriamente")
                LimpiardatosComplejidadDerivacion()
            Else
                MsgBox(strMensaje)
            End If
        Catch ex As Exception
            MsgBox("Error al registrar los datos " & ex.Message)
        End Try
    End Sub

    Private Sub btnSugerirRespuesta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSugerirRespuesta.Click
        Try
            Dim srvWs As New CuidadosPaleativosServiceImpService()
            Dim oComplejidadDerivacion As New ComplejidadDerivacion()
            Dim oPreguntasComplDeriv As New PreguntaCP()

            lstPreguntasCompDeriCP = oComplejidadDerivacion.ConsultarPreguntas(New PreguntaCP)

            If lstPreguntasCompDeriCP.Count > 0 Then
                Dim aPreUltRespuesta(lstPreguntasCompDeriCP.Count - 1) As Long
                Dim aUltimaRespuesta(lstPreguntasCompDeriCP.Count - 1) As PreguntaType
                Dim DAOCP As New DAOCuidadosPaliativos()
                Dim Resultado As String = String.Empty
                Dim appOrigen As String = Paciente.AppOrigenCP.ToUpper()

                srvWs.Url = DAOCP.ConsultarUrlServicioUT(objGeneral.Prestador, objGeneral.Sucursal, "CP", "ultimasrespuestas")

                If srvWs.Url <> "" Then
                Else
                    MessageBox.Show("No fue posible consultar el servicio de últimas respuestas.", "Historia Clínica", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
                    Exit Sub
                End If

                For i As Integer = 0 To lstPreguntasCompDeriCP.Count - 1
                    aPreUltRespuesta(i) = lstPreguntasCompDeriCP.Item(i).id
                Next

                'Resultado = srvAspectosSociales.ultimasRespuestas(objPaciente.TipoDocumento, "17021266", aPreUltRespuesta, "SOPHIA", "BOGOTA", aUltimaRespuesta)
                ''WACHV, 22Dic2017, Se agrega Obtener la ref regional en cada Bd
                '',se cambia parametro de regional objPaciente.Ciudad.ToUpper() por lo retornado en strRegionalRefBD
                Dim strRegionalRefBD As String = DAOCP.ConsultarRegional()
                Resultado = srvWs.ultimasRespuestas(objPaciente.TipoDocumento, objPaciente.NumeroDocumento,
                aPreUltRespuesta, appOrigen, strRegionalRefBD.ToUpper(), aUltimaRespuesta)

                oComplejidadDerivacion = oComplejidadDerivacion.ObtenerUltimaRespuesta(aUltimaRespuesta)

                loadComplejidadDerivacion(oComplejidadDerivacion)
            End If
        Catch ex As Exception
            'Throw (ex)
        End Try
    End Sub

    Private Sub loadComplejidadDerivacion(ByRef oComplejidadDerivacion As ComplejidadDerivacion)
        LimpiardatosComplejidadDerivacion()
        Dim preguntas As New List(Of PreguntaComplejidad)
        With oComplejidadDerivacion
            If (.itemsComplejidadClinica.Count > 0) Then
                preguntas.AddRange(.itemsComplejidadClinica)
            End If
            If (.itemsComplejidadPsicosocial.Count > 0) Then
                preguntas.AddRange(.itemsComplejidadPsicosocial)
            End If
            If (.itemsComplejidadAtencion.Count > 0) Then
                preguntas.AddRange(.itemsComplejidadAtencion)
            End If
            If (.itemsDerivacion.Count > 0) Then
                preguntas.AddRange(.itemsDerivacion)
            End If
        End With

        For Each pr As PreguntaComplejidad In preguntas
            If (pr.RespuestaPregunta.Equals("SI") OrElse pr.RespuestaPregunta.Equals("NO")) Then
                Dim ctrlSi As Control() = Me.Controls.Find("RB_Si_" & pr.NombreCampo, True)
                Dim ctrlNo As Control() = Me.Controls.Find("RB_No_" & pr.NombreCampo, True)
                If (ctrlSi.Length = 1 AndAlso ctrlNo.Length = 1) Then
                    Dim rb As RadioButton
                    If (pr.RespuestaPregunta.Equals("SI")) Then
                        rb = DirectCast(ctrlSi(0), RadioButton)
                        rb.Checked = True
                    Else
                        rb = DirectCast(ctrlNo(0), RadioButton)
                        rb.Checked = True
                    End If
                End If
            ElseIf (pr.RespuestaPregunta.Equals("PPS") OrElse pr.RespuestaPregunta.Equals("IK")) Then
                Dim ctrlPPS As Control() = Me.Controls.Find("RB_PPS_" & pr.NombreCampo, True)
                Dim ctrlIK As Control() = Me.Controls.Find("RB_IK_" & pr.NombreCampo, True)
                If (ctrlPPS.Length = 1 AndAlso ctrlIK.Length = 1) Then
                    Dim rb As RadioButton
                    If (pr.RespuestaPregunta.Equals("PPS")) Then
                        rb = DirectCast(ctrlPPS(0), RadioButton)
                        rb.Checked = True
                    ElseIf (pr.RespuestaPregunta.Equals("IK")) Then
                        rb = DirectCast(ctrlIK(0), RadioButton)
                        rb.Checked = True
                    End If
                End If
                'ElseIf pr.NombreCampo.Equals("Preg521") Then
                '    lblResultadoLugDerivacion.Text = pr.RespuestaPregunta
            ElseIf pr.NombreCampo.Equals("Preg522") Then
                txtEscalaTMP.Text = pr.RespuestaPregunta
                calcularLugarDerivacion(txtEscalaTMP.Text)
            End If
        Next

        ''"Preg523"
        If oComplejidadDerivacion.LugarDerivacionNva <> "" Then
            
            cboLugarDerivacion.SelectedValue = oComplejidadDerivacion.LugarDerivacionNva
            
        End If

        ''"Preg524"   ''/*Total Complejidad Clinica*/	
        If oComplejidadDerivacion.TotalComplejidadClinica <> "" Then
            Me.lblConclusionComplejidadClinica.Text = oComplejidadDerivacion.TotalComplejidadClinica
        End If
        ''"Preg525" ''/*Total Complejidad Psicosocial*/	
        If oComplejidadDerivacion.TotalComplejidadAtencion <> "" Then
            Me.lblConclusionComplejidadPsicosocial.Text = oComplejidadDerivacion.TotalComplejidadPsicoSocial
        End If
        ''"Preg526" ''/*Total Complejidad de la Atención*/	
        If oComplejidadDerivacion.TotalComplejidadAtencion <> "" Then
            Me.lblConclusionComplejidadAtencion.Text = oComplejidadDerivacion.TotalComplejidadAtencion
        End If


        'ElseIf pr.NombreCampo.Equals("Preg523") Then
        'cboLugarDerivacion.SelectedValue = pr.RespuestaPregunta ''WACHV,24OCT2017, SE UTILIZA, ESTA PARA ENVIAR LO SELECCIONADO EN EL COMBO DE LUGAR DE DERIVACION
        ''''WACHV,INICIO 13OCT2017, LOS TOTALES
        'ElseIf pr.NombreCampo.Equals("Preg524") Then ''/*Total Complejidad Clinica*/	
        'lblConclusionComplejidadClinica.Text = pr.RespuestaPregunta
        'ElseIf pr.NombreCampo.Equals("Preg525") Then ''/*Total Complejidad Psicosocial*/	
        'lblConclusionComplejidadPsicosocial.Text = pr.RespuestaPregunta
        'ElseIf pr.NombreCampo.Equals("Preg526") Then ''/*Total Complejidad de la Atención*/		
        'lblConclusionComplejidadAtencion.Text = pr.RespuestaPregunta

        'If pr.NombreCampo.Equals("Preg522") Then
        '        txtEscalaTMP.Text = pr.RespuestaPregunta
        '    End If
        '    If pr.NombreCampo.Equals("Preg523") Then
        '        cboLugarDerivacion.SelectedValue = pr.RespuestaPregunta ''WACHV,24OCT2017, SE UTILIZA, ESTA PARA ENVIAR LO SELECCIONADO EN EL COMBO DE LUGAR DE DERIVACION
        '    End If
        '    '''WACHV,INICIO 13OCT2017, LOS TOTALES
        '    If pr.NombreCampo.Equals("Preg524") Then ''/*Total Complejidad Clinica*/	
        '        lblConclusionComplejidadClinica.Text = pr.RespuestaPregunta
        '    End If
        '    If pr.NombreCampo.Equals("Preg525") Then ''/*Total Complejidad Psicosocial*/	
        '        lblConclusionComplejidadPsicosocial.Text = pr.RespuestaPregunta
        '    End If
        '    If pr.NombreCampo.Equals("Preg526") Then ''/*Total Complejidad de la Atención*/	
        '        lblConclusionComplejidadAtencion.Text = pr.RespuestaPregunta
        '    End If
        '    '''WACHV,FIN 13OCT2017, LOS TOTALES
        'Next
    End Sub


End Class




