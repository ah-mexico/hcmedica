Imports System.IO
Imports System.Collections.Generic
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports HistoriaClinica.Sophia.HistoriaClinica.BL

Public Class ctlAspectosEmocionales
    Private Shared _Instancia As ctlAspectosEmocionales
    Private objGeneral As Generales
    Private objPaciente As Paciente
    Private objConexion As Conexion
    Private strCadenaLocal As String
    Private objAspectoEmocionales As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOAspectosEmocionales

#Region "Instancia de Control"
    Public Shared ReadOnly Property Instancia() As ctlAspectosEmocionales
        Get
            If _Instancia Is Nothing Then
                _Instancia = New ctlAspectosEmocionales
            End If
            Return _Instancia
        End Get
    End Property
#End Region

#Region "Load"

    Private Sub ctlAspectosEmocionales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        frmHistoriaPrincipal.blnFirstEvolucion = False

        objGeneral = Generales.Instancia
        objPaciente = Paciente.Instancia
        objConexion = Conexion.Instancia
        strCadenaLocal = objGeneral.CadenaLocal

        CargarAspectosEmocionales()

        cboNivelSufrimientoExistencial.SelectedIndex = -1
    End Sub

#End Region

#Region "AsignarDatosIniciales-Load"

    Private Sub CargarAspectosEmocionales()
        ActivarControles(True)
        CargarCombo()
        cboNivelSufrimientoExistencial.SelectedIndex = -1
    End Sub


    Private Sub IniciarAspectosEmocionales()

        Dim dTdetalleAspectosEmocionales As New DataTable
        dTdetalleAspectosEmocionales = _
        objAspectoEmocionales.ConsultarAspectosEmocionales(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision _
        , objPaciente.AnoAdmision, objPaciente.NumeroAdmision)

        If dTdetalleAspectosEmocionales.Rows.Count = 0 Then
            Exit Sub
        End If


        If dTdetalleAspectosEmocionales.Rows.Count > 0 Then

            If Not IsDBNull(dTdetalleAspectosEmocionales.Rows(0).Item("id_pregunta")) Then
                If dTdetalleAspectosEmocionales.Rows(0).Item("id_pregunta") = "301" Then
                    tbexamenMental.Text = dTdetalleAspectosEmocionales.Rows(0).Item("texto")
                End If
            End If

            If Not IsDBNull(dTdetalleAspectosEmocionales.Rows(1).Item("id_pregunta")) Then
                If dTdetalleAspectosEmocionales.Rows(1).Item("id_pregunta") = "302" Then
                    tbexpectativasycreeencias.Text = dTdetalleAspectosEmocionales.Rows(1).Item("texto")
                End If
            End If

            If Not IsDBNull(dTdetalleAspectosEmocionales.Rows(2).Item("id_pregunta")) Then
                If dTdetalleAspectosEmocionales.Rows(2).Item("id_pregunta") = "303" Then
                    tbafrontamientoenfermedad.Text = dTdetalleAspectosEmocionales.Rows(2).Item("texto")
                End If
            End If

            If Not IsDBNull(dTdetalleAspectosEmocionales.Rows(3).Item("id_pregunta")) Then
                If dTdetalleAspectosEmocionales.Rows(3).Item("id_pregunta") = "304" Then
                    tbafrontamientofamiliasituacion.Text = dTdetalleAspectosEmocionales.Rows(3).Item("texto")
                End If
            End If

            If Not IsDBNull(dTdetalleAspectosEmocionales.Rows(4).Item("id_pregunta")) Then
                If dTdetalleAspectosEmocionales.Rows(4).Item("id_pregunta") = "305" Then
                    tbProblemasIdentificados.Text = dTdetalleAspectosEmocionales.Rows(4).Item("texto")
                End If
            End If

            If Not IsDBNull(dTdetalleAspectosEmocionales.Rows(5).Item("id_pregunta")) Then
                If dTdetalleAspectosEmocionales.Rows(5).Item("id_pregunta") = "306" Then
                    tbplandeintervencion.Text = dTdetalleAspectosEmocionales.Rows(5).Item("texto")
                End If
            End If

            If Not IsDBNull(dTdetalleAspectosEmocionales.Rows(6).Item("id_pregunta")) Then
                If dTdetalleAspectosEmocionales.Rows(6).Item("id_pregunta") = "307" Then
                    Dim index As Integer
                    index = cboNivelSufrimientoExistencial.FindString(dTdetalleAspectosEmocionales.Rows(6).Item("descripcion"))
                    cboNivelSufrimientoExistencial.SelectedIndex = index
                End If
            End If

            If Not IsDBNull(dTdetalleAspectosEmocionales.Rows(7).Item("id_pregunta")) Then
                If dTdetalleAspectosEmocionales.Rows(7).Item("id_pregunta") = "308" Then
                    tbevalnecesidadespirituales.Text = (dTdetalleAspectosEmocionales.Rows(7).Item("texto"))
                End If
            End If

            If Not IsDBNull(dTdetalleAspectosEmocionales.Rows(8).Item("id_pregunta")) Then
                If dTdetalleAspectosEmocionales.Rows(8).Item("id_pregunta") = "309" Then
                    tbplanintervencionee.Text = (dTdetalleAspectosEmocionales.Rows(8).Item("texto"))
                End If
            End If

            If Not IsDBNull(dTdetalleAspectosEmocionales.Rows(9).Item("id_pregunta")) Then
                If dTdetalleAspectosEmocionales.Rows(9).Item("id_pregunta") = "310" Then
                    tbintervenciondeduelo.Text = (dTdetalleAspectosEmocionales.Rows(9).Item("texto"))
                End If
            End If

            If Not IsDBNull(dTdetalleAspectosEmocionales.Rows(10).Item("id_pregunta")) Then
                If dTdetalleAspectosEmocionales.Rows(10).Item("id_pregunta") = "311" Then
                    If (dTdetalleAspectosEmocionales.Rows(10).Item("descripcion") = "SI") Then
                        rbsi.Checked = True
                        rbno.Checked = False
                    Else
                        rbsi.Checked = False
                        rbno.Checked = True
                    End If
                End If
            End If

            If Not IsDBNull(dTdetalleAspectosEmocionales.Rows(11).Item("id_pregunta")) Then
                If dTdetalleAspectosEmocionales.Rows(11).Item("id_pregunta") = "312" Then
                    tbotrodiagnosticopsicologico.Text = (dTdetalleAspectosEmocionales.Rows(11).Item("texto"))
                End If
            End If

        End If

    End Sub

#End Region

#Region "Carga_Datos"

    Private Sub ctlAspectosEmocionales_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged
        If sender.Visible = True Then
            frmHistoriaPrincipal.blnFirstEvolucion = False
            CargarAspectosEmocionales()
        End If
    End Sub

    Private Sub LimpiarDatos()
        tbexamenMental.ResetText()
        tbexpectativasycreeencias.ResetText()
        tbafrontamientoenfermedad.ResetText()
        tbafrontamientofamiliasituacion.ResetText()
        tbProblemasIdentificados.ResetText()
        tbexpectativasycreeencias.ResetText()
        tbplandeintervencion.ResetText()
        tbevalnecesidadespirituales.ResetText()
        tbplanintervencionee.ResetText()
        tbintervenciondeduelo.ResetText()
        cboNivelSufrimientoExistencial.ResetText()
        cboNivelSufrimientoExistencial.SelectedIndex = -1
        rbsi.Checked = False
        rbno.Checked = False
        tbotrodiagnosticopsicologico.ResetText()
    End Sub

    Private Sub ActivarControles(ByVal Activar As Boolean)

        tbexamenMental.Enabled = Activar
        tbexpectativasycreeencias.Enabled = Activar
        tbafrontamientoenfermedad.Enabled = Activar
        tbafrontamientofamiliasituacion.Enabled = Activar
        tbProblemasIdentificados.Enabled = Activar
        tbexpectativasycreeencias.Enabled = Activar

        tbevalnecesidadespirituales.Enabled = Activar
        tbplanintervencionee.Enabled = Activar
        tbintervenciondeduelo.Enabled = Activar
        tbotrodiagnosticopsicologico.Enabled = Activar


    End Sub

    Private Function fncbool_ValidarInfControles() As Boolean


        Dim boolResultado As Boolean
        boolResultado = True

        'If tbexamenMental.Text.Length = 0 Then
        '    MsgBox("Es necesario algun valor para examen mental.")
        '    tbexamenMental.Focus()
        '    boolResultado = False
        '    Exit Function
        'End If

        'If tbexpectativasycreeencias.Text.Length = 0 Then
        '    MsgBox("Es necesario algun valor para plan de intervencion.")
        '    tbexpectativasycreeencias.Focus()
        '    boolResultado = False
        '    Exit Function
        'End If
        'If tbafrontamientoenfermedad.Text.Length = 0 Then
        '    MsgBox("Es necesario algun valor para afrontamiento de enfermedad.")
        '    tbafrontamientoenfermedad.Focus()
        '    boolResultado = False
        '    Exit Function
        'End If

        'If tbafrontamientofamiliasituacion.Text.Length = 0 Then
        '    MsgBox("Es necesario algun valor para afrontamiento de la familia a la situacion.")
        '    tbafrontamientofamiliasituacion.Focus()
        '    boolResultado = False
        '    Exit Function
        'End If

        'If tbProblemasIdentificados.Text.Length = 0 Then
        '    MsgBox("Es necesario algun valor para problemas identificados.")
        '    tbProblemasIdentificados.Focus()
        '    boolResultado = False
        '    Exit Function
        'End If

        'If tbplandeintervencion.Text.Length = 0 Then
        '    MsgBox("Es necesario algun valor para plan de intervencion.")
        '    tbplandeintervencion.Focus()
        '    boolResultado = False
        '    Exit Function
        'End If

        'If cboNivelSufrimientoExistencial.SelectedIndex = -1 Then
        '    MsgBox("Es necesario algun valor para nivel de sufrimiento.")
        '    cboNivelSufrimientoExistencial.Focus()
        '    boolResultado = False
        '    Exit Function
        'End If

        If tbevalnecesidadespirituales.Text.Length = 0 Then
            MsgBox("Es necesario algun valor para evaluacion de necesidades espirituales.")
            tbevalnecesidadespirituales.Focus()
            boolResultado = False
            Exit Function
        End If

        'If tbplanintervencionee.Text.Length = 0 Then
        '    MsgBox("Es necesario algun valor para el plan de intervencion de evaluacion espiritual.")
        '    tbplanintervencionee.Focus()
        '    boolResultado = False
        '    Exit Function
        'End If

        If tbintervenciondeduelo.Text.Length = 0 Then
            MsgBox("Es necesario algun valor para la intervencion del duelo.")
            tbintervenciondeduelo.Focus()
            boolResultado = False
            Exit Function
        End If

        'If ((rbsi.Checked = False) And (rbno.Checked = False)) Then
        '    MsgBox("Es necesario selecccionar un valor Si o No, en diagnóstico Z 63.4")
        '    tbintervenciondeduelo.Focus()
        '    boolResultado = False
        '    Exit Function
        'End If

        'If tbotrodiagnosticopsicologico.Text.Length = 0 Then
        '    MsgBox("Es necesario algun valor en otro diagniostico pisocologico.")
        '    tbintervenciondeduelo.Focus()
        '    boolResultado = False
        '    Exit Function
        'End If

        fncbool_ValidarInfControles = boolResultado

    End Function

    Private Sub CargarCombo()
        Dim dt As New DataTable

        Try

            With cboNivelSufrimientoExistencial
                .ValueMember = "Id"
                .DisplayMember = "Descripcion"
                Try
                    .DataSource = objAspectoEmocionales.CargarCombo()
                    .EndUpdate()
                Catch ex As Exception
                    MsgBox("Error en la consulta parametrica Nivel Sufrimiento. " & ex.Message, MsgBoxStyle.Information)
                End Try
            End With
            'cboNivelSufrimientoExistencial.

        Catch ex As Exception
        End Try
    End Sub
#End Region


    Private Sub btGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGrabar.Click
        Dim objBl As New Sophia.HistoriaClinica.BL.BLPlanManejo
        Dim bError As Boolean = True
        Dim lError As Long
        Dim strError As String = ""
        Dim strFecha As String = ""
        Dim strvarcierre As String = ""
        Dim daoOrden As New DAOOrdenes()
        Try

            If (fncbool_ValidarInfControles()) Then  ''INICIO, WACHV, 30AGO2017, Incluir Validacion de los campos obligatorios

                lError = objAspectoEmocionales.GrabarAspectosEmocionales(
            objConexion, objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision _
            , objPaciente.AnoAdmision, objPaciente.NumeroAdmision _
            , objPaciente.TipoDocumento, objPaciente.NumeroDocumento _
            , Me.tbexamenMental.Text, Me.tbexpectativasycreeencias.Text, Me.tbafrontamientoenfermedad.Text, Me.tbafrontamientofamiliasituacion.Text _
            , Me.tbProblemasIdentificados.Text, Me.tbplandeintervencion.Text _
            , Convert.ToInt32(Me.cboNivelSufrimientoExistencial.SelectedValue), Me.tbevalnecesidadespirituales.Text _
            , Me.tbplanintervencionee.Text, Me.tbintervenciondeduelo.Text _
            , IIf(Me.rbsi.Checked = True, "SI", IIf(Me.rbno.Checked = True, "NO", "")), Me.tbotrodiagnosticopsicologico.Text _
            , "", objGeneral.Login)
                'End If

                If lError = 0 Then
                    MessageBox.Show("Registro Guardado.", "Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    CargarAspectosEmocionales()
                    LimpiarDatos()
                End If
            End If ''FIN, WACHV, 30AGO2017, Incluir Validacion de los campos obligatorios
        Catch ex As Exception
            MessageBox.Show("El proceso de grabación de Aspectos Emocionales fallo por: " & ex.Message, "Historia Clínica", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
        End Try

    End Sub

    Private Sub cboNivelSufrimientoExistencial_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboNivelSufrimientoExistencial.KeyPress
        e.Handled = True
    End Sub

    Private Sub btnSugerirRespuesta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSugerirRespuesta.Click
        Try
            LimpiarDatos()
            Dim oAspectosEmocionales As New AspectosEmocionales()
            loadAspectosEmocionales(oAspectosEmocionales.SugerirRespuesta(objGeneral, objPaciente))

        Catch ex As Exception
            MessageBox.Show("No fue posible consultar las últimas respuestas de este paciente.", "Historia Clínica", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

        End Try
    End Sub

    ''' <summary>
    ''' Carga la información Asp. Emocionales
    ''' </summary>
    ''' <param name="oEmocionales">Aspecto Emocional a cargar</param>
    ''' <remarks></remarks>
    Private Sub loadAspectosEmocionales(ByVal oAspectosEmocionales As AspectosEmocionales)
        Try
            tbexamenMental.Text = IIf(oAspectosEmocionales.ExamenMental = Nothing, "", oAspectosEmocionales.ExamenMental)
            tbexpectativasycreeencias.Text = IIf(oAspectosEmocionales.Expectativasycreencias = Nothing, "", oAspectosEmocionales.Expectativasycreencias)
            tbafrontamientoenfermedad.Text = IIf(oAspectosEmocionales.Afrontamientodelaenfermedad = Nothing, "", oAspectosEmocionales.Afrontamientodelaenfermedad)
            tbafrontamientofamiliasituacion.Text = IIf(oAspectosEmocionales.Afrontamientodelafamiliaalasituacion = Nothing, "", oAspectosEmocionales.Afrontamientodelafamiliaalasituacion)
            tbProblemasIdentificados.Text = IIf(oAspectosEmocionales.Problemasidentificados = Nothing, "", oAspectosEmocionales.Problemasidentificados)
            tbplandeintervencion.Text = IIf(oAspectosEmocionales.Problemasidentificados = Nothing, "", oAspectosEmocionales.Plandeintervencion)

            cboNivelSufrimientoExistencial.SelectedValue = IIf(oAspectosEmocionales.Niveldesufrimientoexistencial = Nothing, "", oAspectosEmocionales.Niveldesufrimientoexistencial)

            tbevalnecesidadespirituales.Text = IIf(oAspectosEmocionales.Evaluaciondenecesidadesespirituales = Nothing, "", oAspectosEmocionales.Evaluaciondenecesidadesespirituales)
            tbplanintervencionee.Text = IIf(oAspectosEmocionales.Plandeintervencion_E_E = Nothing, "", oAspectosEmocionales.Plandeintervencion_E_E)
            tbintervenciondeduelo.Text = IIf(oAspectosEmocionales.Intervenciondeduelo = Nothing, "", oAspectosEmocionales.Intervenciondeduelo)

            If Not (oAspectosEmocionales.DiagnosticoZ63_4 = Nothing) Then
                If oAspectosEmocionales.DiagnosticoZ63_4.Substring(oAspectosEmocionales.DiagnosticoZ63_4.Length - 1).Contains("1") Then
                    rbsi.Checked = True
                    rbno.Checked = False
                Else
                    rbsi.Checked = False
                    rbno.Checked = True
                End If
            End If

            tbotrodiagnosticopsicologico.Text = IIf(oAspectosEmocionales.Otrodiagnosticopsicologico = Nothing, "", oAspectosEmocionales.Otrodiagnosticopsicologico)


        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub


End Class
