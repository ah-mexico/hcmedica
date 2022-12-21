Imports System.IO
Imports System.Collections
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.HistoriaBasica
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports System.Collections.Generic
Imports HistoriaClinica.wsCuidadoPaliativo
Imports System.Linq
Imports CharFC.Lite
Public Class ctlHerramientaEvaluacion
    Private Shared _Instancia As ctlHerramientaEvaluacion
    Private objGeneral As Generales
    Private objPaciente As Paciente
    Private objConexion As Conexion
    Private objHerramienta As HerramientaEvaluacion
    Private objEscalas As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOHerramientaEvaluacion

    Dim lWidth As Integer = 300, lHeight As Integer = 200
    Dim GrupoSize As Size
    Dim GrupoLocation As Point

    Dim w As Integer
    Dim h As Integer
    Dim x As Integer
    Dim y As Integer

    ''''WACHV, 20Oct2017, Declara Arreglo para recibir los seleccionados
    Private ArregloSeleccionados() As String
    Private ArregloSeleccionadosUnicos() As String
    Private strSeparador As String = "<|^|>"

#Region "Instancia de Control"
    Public Shared ReadOnly Property Instancia() As ctlHerramientaEvaluacion
        Get
            If _Instancia Is Nothing Then
                _Instancia = New ctlHerramientaEvaluacion
            End If
            Return _Instancia
        End Get
    End Property
#End Region

    Private Sub ctlHerramientaEvaluacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        objGeneral = Generales.Instancia
        objPaciente = Paciente.Instancia
        objConexion = Conexion.Instancia

        objHerramienta = HerramientaEvaluacion.Instancia
        LimpiardatosEscalas(1) ''OSASIS
        Me.lblResultadoOasis.Text = "0/20"
        LimpiardatosEscalas(2) ''ODSIS
        Me.lblResultadoOdsis.Text = "0/20"
        LimpiardatosEscalas(3) ''ESAS
        LimpiardatosEscalas(4) ''ECAF
        Me.lblResultadoEcaf.Text = "0/24"
        LimpiardatosEscalas(5) ''IK
        Me.lblResultadoIK.Text = "0"
        LimpiardatosEscalas(6) ''BARTHEL
        Me.lblResultadoBarthel.Text = "0/100"
        LimpiardatosEscalas(7) ''RAMSAY
        Me.lblResultadoRamsay.Text = "0"
        LimpiardatosEscalas(8) ''CAM
        Me.lblResultadoCam.Text = ""
        LimpiardatosEscalas(9) ''MDAS
        Me.lblResultadoMdas.Text = ""
        LimpiardatosEscalas(10) ''MOCCA
        LimpiardatosEscalas(11) ''ZARIT
        Me.lblResultadoZarit.Text = ""
        LimpiardatosEscalas(12) ''HAD
        Me.lblResultadoHADAnsiedad.Text = ""
        Me.lblResultadoHADDepresion.Text = ""
        LimpiardatosEscalas(13) ''PPS
        Me.lblResultadoPPS.Text = "0"
        InicializarControlesOtrasHerramientasEvaluacion()
        CargarPreguntasHerramientaEvaluacion()
        InactivarGroupBoxCheck()  'WACHV, 14SEPT2017, Inactiva todos los GroupBox
        ''Ocultar todos los controles
        OcultarMostrarControlesOtrasHerramientasdeEvaluacion(False)
        InicialiarArreglo()
        'AsignarToolTipText()
    End Sub
    Private Sub InicialiarArreglo()
        ''WACHV, 20Oct2017, inicializa para recibir los seleccionados
        If (IsNothing(ArregloSeleccionados)) Then
            ReDim ArregloSeleccionados(0)
        ElseIf ArregloSeleccionados.Length > 0 Then
            ReDim ArregloSeleccionados(0)
        End If
        ''Unicos
        If (IsNothing(ArregloSeleccionadosUnicos)) Then
            ReDim ArregloSeleccionadosUnicos(0)
        ElseIf ArregloSeleccionadosUnicos.Length > 0 Then
            ReDim ArregloSeleccionadosUnicos(0)
        End If
    End Sub
    Private Sub ctlHerramientaEvaluacion_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If sender.Visible Then
            LimpiardatosEscalas(1) ''OSASIS
            Me.lblResultadoOasis.Text = "0/20"
            LimpiardatosEscalas(2) ''ODSIS
            Me.lblResultadoOdsis.Text = "0/20"
            LimpiardatosEscalas(3) ''ESAS
            LimpiardatosEscalas(4) ''ECAF
            Me.lblResultadoEcaf.Text = "0/24"
            LimpiardatosEscalas(5) ''IK
            Me.lblResultadoIK.Text = "0"
            LimpiardatosEscalas(6) ''BARTHEL
            Me.lblResultadoBarthel.Text = "0/100"
            LimpiardatosEscalas(7) ''RAMSAY
            Me.lblResultadoRamsay.Text = "0"
            LimpiardatosEscalas(8) ''CAM
            Me.lblResultadoCam.Text = ""
            LimpiardatosEscalas(9) ''MDAS
            Me.lblResultadoMdas.Text = ""
            LimpiardatosEscalas(10) ''MOCCA
            LimpiardatosEscalas(11) ''ZARIT
            Me.lblResultadoZarit.Text = ""
            LimpiardatosEscalas(12) ''HAD
            Me.lblResultadoHADAnsiedad.Text = ""
            Me.lblResultadoHADDepresion.Text = ""
            LimpiardatosEscalas(13) ''PPS
            Me.lblResultadoPPS.Text = "0"

            CargarPreguntasHerramientaEvaluacion()
            ''Ocultar todos los controles
            OcultarMostrarControlesOtrasHerramientasdeEvaluacion(False)
            ''WACHV, 20Oct2017, inicializa para recibir los seleccionados
            InicialiarArreglo()
        End If
    End Sub
    'Public Sub AsignarToolTipText(ByVal objCombobox As ComboBox)
    '    For Each ctrl As Control In Me.Controls
    '        If TypeOf ctrl Is ComboBox Then
    '            Dim cb As ComboBox = DirectCast(ctrl, ComboBox)
    '            If objCombobox.Name = cb.Name Then
    '                Dim tt As New ToolTip
    '                With tt
    '                    .IsBalloon = True
    '                    .ToolTipIcon = ToolTipIcon.Info
    '                    .ToolTipTitle = "Important Information"
    '                    .SetToolTip(cb, "This is your tooltip text")
    '                End With
    '            End If
    '        End If
    '    Next

    '    Dim TL(40) As ToolTip
    '    TL(0) = New ToolTip
    '    TL(0).SetToolTip(Me.cboRespuesta22, "a")
    '    TL(1) = New ToolTip
    '    TL(1).SetToolTip(Me.cboRespuesta23, "b")
    '    TL(2) = New ToolTip
    '    TL(2).SetToolTip(Me.cboRespuesta24, "c")
    '    TL(3) = New ToolTip
    '    TL(3).SetToolTip(Me.cboRespuesta25, "d")
    'End Sub

    '''''WACHV,FIN, 27Nov2017, Para Mostrar Ayuda tipo Tooltip text sobre los combos definidos
    Private Sub MostrarToolTip(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
            cboRespuesta1.MouseEnter, cboRespuesta1.MouseHover,
            cboRespuesta2.MouseEnter, cboRespuesta2.MouseHover,
            cboRespuesta3.MouseEnter, cboRespuesta3.MouseHover,
            cboRespuesta4.MouseEnter, cboRespuesta4.MouseHover,
            cboRespuesta5.MouseEnter, cboRespuesta5.MouseHover,
            cboRespuesta6.MouseEnter, cboRespuesta6.MouseHover,
            cboRespuesta7.MouseEnter, cboRespuesta7.MouseHover,
            cboRespuesta8.MouseEnter, cboRespuesta8.MouseHover,
            cboRespuesta9.MouseEnter, cboRespuesta9.MouseHover,
            cboRespuesta10.MouseEnter, cboRespuesta10.MouseHover,
            cboRespuesta28.MouseEnter, cboRespuesta28.MouseHover,
            cboRespuesta29.MouseEnter, cboRespuesta29.MouseHover,
            cboRespuesta30.MouseEnter, cboRespuesta30.MouseHover,
            cboRespuesta31.MouseEnter, cboRespuesta31.MouseHover,
            cboRespuesta32.MouseEnter, cboRespuesta32.MouseHover,
            cboRespuesta33.MouseEnter, cboRespuesta33.MouseHover,
            cboRespuesta34.MouseEnter, cboRespuesta34.MouseHover,
            cboRespuesta35.MouseEnter, cboRespuesta35.MouseHover,
            cboRespuesta36.MouseEnter, cboRespuesta36.MouseHover,
            cboRespuesta37.MouseEnter, cboRespuesta37.MouseHover,
            cboRespuesta38.MouseEnter, cboRespuesta38.MouseHover,
            cboRespuesta39.MouseEnter, cboRespuesta39.MouseHover,
            cboRespuesta44.MouseEnter, cboRespuesta44.MouseHover,
            cboRespuesta45.MouseEnter, cboRespuesta45.MouseHover,
            cboRespuesta46.MouseEnter, cboRespuesta46.MouseHover,
            cboRespuesta47.MouseEnter, cboRespuesta47.MouseHover,
            cboRespuesta48.MouseEnter, cboRespuesta48.MouseHover,
            cboRespuesta49.MouseEnter, cboRespuesta49.MouseHover,
            cboRespuesta50.MouseEnter, cboRespuesta50.MouseHover,
            cboRespuesta51.MouseEnter, cboRespuesta51.MouseHover,
            cboRespuesta52.MouseEnter, cboRespuesta52.MouseHover,
            cboRespuesta53.MouseEnter, cboRespuesta53.MouseHover,
            cboRespuesta55.MouseEnter, cboRespuesta55.MouseHover,
            cboRespuesta56.MouseEnter, cboRespuesta56.MouseHover,
            cboRespuesta57.MouseEnter, cboRespuesta57.MouseHover,
            cboRespuesta58.MouseEnter, cboRespuesta58.MouseHover,
            cboRespuesta59.MouseEnter, cboRespuesta59.MouseHover,
            cboRespuesta60.MouseEnter, cboRespuesta60.MouseHover,
            cboRespuesta61.MouseEnter, cboRespuesta61.MouseHover,
            cboRespuesta62.MouseEnter, cboRespuesta62.MouseHover,
            cboRespuesta63.MouseEnter, cboRespuesta63.MouseHover,
            cboRespuesta64.MouseEnter, cboRespuesta64.MouseHover,
            cboRespuesta65.MouseEnter, cboRespuesta65.MouseHover,
            cboRespuesta66.MouseEnter, cboRespuesta66.MouseHover,
            cboRespuesta67.MouseEnter, cboRespuesta67.MouseHover,
            cboRespuesta68.MouseEnter, cboRespuesta68.MouseHover,
            cboRespuesta69.MouseEnter, cboRespuesta69.MouseHover,
            cboRespuesta70.MouseEnter, cboRespuesta70.MouseHover,
            cboRespuesta71.MouseEnter, cboRespuesta71.MouseHover,
            cboRespuesta72.MouseEnter, cboRespuesta72.MouseHover,
            cboRespuesta73.MouseEnter, cboRespuesta73.MouseHover,
            cboRespuesta74.MouseEnter, cboRespuesta74.MouseHover,
            cboRespuesta75.MouseEnter, cboRespuesta75.MouseHover,
            cboRespuesta76.MouseEnter, cboRespuesta76.MouseHover,
            cboRespuesta77.MouseEnter, cboRespuesta77.MouseHover,
            cboRespuesta77.MouseEnter, cboRespuesta77.MouseHover,
            cboRespuesta78.MouseEnter, cboRespuesta78.MouseHover,
            cboRespuesta79.MouseEnter, cboRespuesta79.MouseHover,
            cboRespuesta80.MouseEnter, cboRespuesta80.MouseHover,
            cboRespuesta81.MouseEnter, cboRespuesta81.MouseHover,
            cboRespuesta82.MouseEnter, cboRespuesta82.MouseHover,
            cboRespuesta82.MouseEnter, cboRespuesta82.MouseHover,
            cboRespuesta83.MouseEnter, cboRespuesta83.MouseHover,
            cboRespuesta84.MouseEnter, cboRespuesta84.MouseHover,
            cboRespuesta85.MouseEnter, cboRespuesta85.MouseHover,
            cboRespuesta86.MouseEnter, cboRespuesta86.MouseHover,
            cboRespuesta87.MouseEnter, cboRespuesta87.MouseHover,
            cboRespuesta88.MouseEnter, cboRespuesta88.MouseHover,
            cboRespuesta89.MouseEnter, cboRespuesta89.MouseHover,
            cboRespuesta90.MouseEnter, cboRespuesta90.MouseHover,
            cboRespuesta91.MouseEnter, cboRespuesta91.MouseHover
        If (sender.text <> "") Then
            ToolTip1.SetToolTip(sender, sender.text)
        End If
    End Sub

    ''Inactivar las Groupbox segun sea el caso
    Public Sub InactivarGroupBoxCheck()  'WACHV, 14SEPT2017, x defecto opciones de agrupamiento y check nuevos
        grpESAS.Enabled = False
        grpEcaf.Enabled = False
        grpPPS.Enabled = False
        grpIK.Enabled = False
        grpOASIS.Enabled = False
        grpODSIS.Enabled = False
        grpBarthel.Enabled = False
        grpRAMSAY.Enabled = False
        grpCam.Enabled = False
        grpMdas.Enabled = False
        grpMocca.Enabled = False
        grpZarit.Enabled = False
        grpHAD.Enabled = False
        chkEsas.Checked = False
        chkECAF.Checked = False
        chkNingunoEvalSintomas.Checked = False
        chkPPS.Checked = False
        chkIK.Checked = False
        chkNingunoEvalFuncionalidad.Checked = False
        chkOASIS.Checked = False
        chkODSIS.Checked = False
        chkEscaladebarthel.Checked = False
        chkRamsay.Checked = False
        chkCAM.Checked = False
        chkMdas.Checked = False
        chkEscalaMocca.Checked = False
        chkTestdezarit.Checked = False
        chkHAD.Checked = False
    End Sub
    Public Sub OcultarGroupBoxCheck()  'WACHV, 14SEPT2017, x defecto opciones de agrupamiento y check nuevos
        grpESAS.Visible = False
        grpEcaf.Visible = False
        grpPPS.Visible = False
        grpIK.Visible = False
        grpOASIS.Visible = False
        grpODSIS.Visible = False
        grpBarthel.Visible = False
        grpRAMSAY.Visible = False
        grpCam.Visible = False
        grpMdas.Visible = False
        grpMocca.Visible = False
        grpZarit.Visible = False
        grpHAD.Visible = False
    End Sub

    Public Sub CargarPreguntasHerramientaEvaluacion()

        Dim dtdatos As New DataTable

        Try
            dtdatos = objEscalas.ConsultarPreguntasEscalas()

            If dtdatos.Rows.Count = 0 Then
                MsgBox("No existen registros ")
            Else
                dtdatos.Columns.Add("Copiar", System.Type.GetType("System.String"))

                For i As Integer = 0 To dtdatos.Rows.Count - 1
                    'inicio ESCALA DE SEVERIDAD Y DISCAPACIDAD DE LA ANSIEDAD (OASIS)
                    If i = 0 Then
                        Me.Pregunta1.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 1 Then
                        Me.Pregunta2.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 2 Then
                        Me.Pregunta3.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 3 Then
                        Me.Pregunta4.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 4 Then
                        Me.Pregunta5.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 5 Then
                        Me.lblTotalOasis.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    'fin  oasis
                    'inicio ESCALA DE SEVERIDAD Y DISCAPACIDAD DE LA TRISTEZA (ODSIS)
                    If i = 6 Then
                        Me.Pregunta6.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 7 Then
                        Me.Pregunta7.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 8 Then
                        Me.Pregunta8.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 9 Then
                        Me.Pregunta9.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 10 Then
                        Me.Pregunta10.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 11 Then
                        Me.lblTotalOdisis.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    'fin ODSIS
                    'inicio --EDMONTON SYMPTOMS ASSESMENT SCALE (ESAS)
                    If i = 12 Then
                        Me.Pregunta11.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 13 Then
                        Me.Pregunta12.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 14 Then
                        Me.Pregunta13.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 15 Then
                        Me.Pregunta14.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 16 Then
                        Me.Pregunta15.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 17 Then
                        Me.Pregunta16.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 18 Then
                        Me.Pregunta17.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 19 Then
                        Me.Pregunta18.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 20 Then
                        Me.Pregunta19.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 21 Then
                        Me.Pregunta20.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 22 Then
                        Me.Pregunta21.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    'fin ESAS
                    'inicio EDMONTON CONFORT ASSESMENT FORM (ECAF)
                    If i = 23 Then
                        Me.Pregunta22.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 24 Then
                        Me.Pregunta23.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 25 Then
                        Me.Pregunta24.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 26 Then
                        Me.Pregunta25.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 27 Then
                        Me.Pregunta26.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 28 Then
                        Me.Pregunta27.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 29 Then
                        Me.lblTotalEcaf.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    'fin ECAF
                    'inicio INDICE DE KARNOFSKY (IK)
                    If i = 30 Then
                        Me.Pregunta28.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 31 Then
                        Me.lblTotalIK.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    'fin IK
                    'inicio BARTHEL
                    If i = 32 Then
                        Me.Pregunta29.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 33 Then
                        Me.Pregunta30.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 34 Then
                        Me.Pregunta31.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 35 Then
                        Me.Pregunta32.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 36 Then
                        Me.Pregunta33.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 37 Then
                        Me.Pregunta34.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 38 Then
                        Me.Pregunta35.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 39 Then
                        Me.Pregunta36.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 40 Then
                        Me.Pregunta37.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 41 Then
                        Me.Pregunta38.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 42 Then
                        Me.lblTotalBarthel.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    'fin BARTHEL
                    'inicio INDICE DE RAMSAY
                    If i = 43 Then
                        Me.Pregunta39.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 44 Then
                        Me.lblTotalRamsay.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    'fin RAMSAY
                    'inicio CAM (Confussion Assessment Method)
                    If i = 45 Then
                        Me.Pregunta40.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 46 Then
                        Me.Pregunta41.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 47 Then
                        Me.Pregunta42.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 48 Then
                        Me.Pregunta43.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 49 Then
                        Me.lblTotalCam.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    'fin CAM
                    'inicio MDAS
                    If i = 50 Then
                        Me.Pregunta44.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 51 Then
                        Me.Pregunta45.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 52 Then
                        Me.Pregunta46.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 53 Then
                        Me.Pregunta47.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 54 Then
                        Me.Pregunta48.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 55 Then
                        Me.Pregunta49.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 56 Then
                        Me.Pregunta50.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 57 Then
                        Me.Pregunta51.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 58 Then
                        Me.Pregunta52.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 59 Then
                        Me.Pregunta53.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 60 Then
                        Me.lblTotalMADS.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    'fin MDAS
                    'inicio Mocca
                    If i = 61 Then
                        Me.Pregunta54.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    'fin Mocca
                    'inicio Zarit
                    If i = 62 Then
                        Me.Pregunta55.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 63 Then
                        Me.Pregunta56.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 64 Then
                        Me.Pregunta57.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 65 Then
                        Me.Pregunta58.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 66 Then
                        Me.Pregunta59.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 67 Then
                        Me.Pregunta60.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 68 Then
                        Me.Pregunta61.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 69 Then
                        Me.Pregunta62.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 70 Then
                        Me.Pregunta63.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 71 Then
                        Me.Pregunta64.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 72 Then
                        Me.Pregunta65.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 73 Then
                        Me.Pregunta66.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 74 Then
                        Me.Pregunta67.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 75 Then
                        Me.Pregunta68.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 76 Then
                        Me.Pregunta69.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 77 Then
                        Me.Pregunta70.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 78 Then
                        Me.Pregunta71.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 79 Then
                        Me.Pregunta72.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 80 Then
                        Me.Pregunta73.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 81 Then
                        Me.Pregunta74.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 82 Then
                        Me.Pregunta75.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 83 Then
                        Me.Pregunta76.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 84 Then
                        Me.lblTotalZarit.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    'fin zarit
                    'inicio HAD
                    If i = 85 Then
                        Me.Pregunta77.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 86 Then
                        Me.Pregunta78.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 87 Then
                        Me.Pregunta79.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 88 Then
                        Me.Pregunta80.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 89 Then
                        Me.Pregunta81.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 90 Then
                        Me.Pregunta82.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 91 Then
                        Me.Pregunta83.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 92 Then
                        Me.Pregunta84.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 93 Then
                        Me.Pregunta85.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 94 Then
                        Me.Pregunta86.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 95 Then
                        Me.Pregunta87.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 96 Then
                        Me.Pregunta88.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 97 Then
                        Me.Pregunta89.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 98 Then
                        Me.Pregunta90.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 99 Then
                        Me.lblTotalHadDepresion.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 100 Then
                        Me.lblTotalHadAnsiedad.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    'fin HAD
                    'inicioESCALA FUNCIONAL PALIATIVA (PPS)
                    If i = 101 Then
                        Me.Pregunta91.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    If i = 102 Then
                        Me.lblTotalPPS.Text = dtdatos.Rows(i).Item("descripcion").ToString
                        CargarRespuesta(i, dtdatos.Rows(i).Item("id").ToString)
                    End If
                    'fin PPS
                Next
            End If
        Catch ex As Exception
            MsgBox("Error al cargar los parametros de herramientas de evaluacion " & ex.Message)
        End Try

    End Sub

    Private Sub CargarRespuesta(ByVal intopcion As Integer, ByVal intparametrica As Integer)
        Dim dt As New DataTable

        Try
            Select Case intopcion
                'inicio OASIS
                Case 0
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta1.DataSource = dt
                    cboRespuesta1.DisplayMember = "descripcion"
                    cboRespuesta1.ValueMember = "id"
                    cboRespuesta1.SelectedValue = 0
                Case 1
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta2.DataSource = dt
                    cboRespuesta2.DisplayMember = "descripcion"
                    cboRespuesta2.ValueMember = "id"
                    cboRespuesta2.SelectedValue = 0
                Case 2
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta3.DataSource = dt
                    cboRespuesta3.DisplayMember = "descripcion"
                    cboRespuesta3.ValueMember = "id"
                    cboRespuesta3.SelectedValue = 0
                Case 3
                    dt = objEscalas.CargarCombosParametrica(intparametrica)

                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta4.DataSource = dt

                    cboRespuesta4.DisplayMember = "descripcion"
                    cboRespuesta4.ValueMember = "id"
                    cboRespuesta4.SelectedValue = 0
                Case 4
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta5.DataSource = dt
                    cboRespuesta5.DisplayMember = "descripcion"
                    cboRespuesta5.ValueMember = "id"
                    cboRespuesta5.SelectedValue = 0
                Case 5
                    dt = objEscalas.CargarCamposParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    Me.lblResultadoOasis.Tag = dt.Rows(0).Item("id").ToString
                    'fin OASIS
                    'inicio ODSIS
                Case 6
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta6.DataSource = dt
                    cboRespuesta6.DisplayMember = "descripcion"
                    cboRespuesta6.ValueMember = "id"
                    cboRespuesta6.SelectedValue = 0
                Case 7
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta7.DataSource = dt
                    cboRespuesta7.DisplayMember = "descripcion"
                    cboRespuesta7.ValueMember = "id"
                    cboRespuesta7.SelectedValue = 0
                Case 8
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta8.DataSource = dt
                    cboRespuesta8.DisplayMember = "descripcion"
                    cboRespuesta8.ValueMember = "id"
                    cboRespuesta8.SelectedValue = 0
                Case 9
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta9.DataSource = dt
                    cboRespuesta9.DisplayMember = "descripcion"
                    cboRespuesta9.ValueMember = "id"
                    cboRespuesta9.SelectedValue = 0
                Case 10
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta10.DataSource = dt
                    cboRespuesta10.DisplayMember = "descripcion"
                    cboRespuesta10.ValueMember = "id"
                    cboRespuesta10.SelectedValue = 0
                Case 11
                    dt = objEscalas.CargarCamposParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    Me.lblResultadoOdsis.Tag = dt.Rows(0).Item("id").ToString
                    'fin ODSIS
                    'inicio ESAS
                Case 12
                    Me.LinkGrafica11.Tag = intparametrica
                    dt = objEscalas.CargarCamposParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    Me.Label11.Text = dt.Rows(0).Item("id").ToString
                    Me.txtRespuesta11.Text = ""
                Case 13
                    Me.LinkGrafica12.Tag = intparametrica
                    dt = objEscalas.CargarCamposParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    Me.Label12.Text = dt.Rows(0).Item("id").ToString
                    Me.txtRespuesta12.Text = ""
                Case 14
                    Me.LinkGrafica13.Tag = intparametrica
                    dt = objEscalas.CargarCamposParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    Me.Label13.Text = dt.Rows(0).Item("id").ToString
                    Me.txtRespuesta13.Text = ""
                Case 15
                    Me.LinkGrafica14.Tag = intparametrica
                    dt = objEscalas.CargarCamposParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    Me.Label14.Text = dt.Rows(0).Item("id").ToString
                    Me.txtRespuesta14.Text = ""
                Case 16
                    Me.LinkGrafica15.Tag = intparametrica
                    dt = objEscalas.CargarCamposParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    Me.Label15.Text = dt.Rows(0).Item("id").ToString
                    Me.txtRespuesta15.Text = ""
                Case 17
                    Me.LinkGrafica16.Tag = intparametrica
                    dt = objEscalas.CargarCamposParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    Me.Label16.Text = dt.Rows(0).Item("id").ToString
                    Me.txtRespuesta16.Text = ""
                Case 18
                    Me.LinkGrafica17.Tag = intparametrica
                    dt = objEscalas.CargarCamposParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    Me.Label17.Text = dt.Rows(0).Item("id").ToString
                    Me.txtRespuesta17.Text = ""
                Case 19
                    Me.LinkGrafica18.Tag = intparametrica
                    dt = objEscalas.CargarCamposParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    Me.Label18.Text = dt.Rows(0).Item("id").ToString
                    Me.txtRespuesta18.Text = ""
                Case 20
                    Me.LinkGrafica19.Tag = intparametrica
                    dt = objEscalas.CargarCamposParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    Me.Label19.Text = dt.Rows(0).Item("id").ToString
                    Me.txtRespuesta19.Text = ""
                Case 21
                    Me.LinkGrafica20.Tag = intparametrica
                    dt = objEscalas.CargarCamposParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    Me.Label20.Text = dt.Rows(0).Item("id").ToString
                    Me.txtRespuesta20.Text = ""
                Case 22
                    Me.LinkGrafica21.Tag = intparametrica
                    dt = objEscalas.CargarCamposParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    Me.Label21.Text = dt.Rows(0).Item("id").ToString
                    Me.txtRespuesta21.Text = ""
                    'fin ESAS
                    'inicio ECAF
                Case 23
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta22.DataSource = dt
                    cboRespuesta22.DisplayMember = "descripcion"
                    cboRespuesta22.ValueMember = "id"
                    cboRespuesta22.SelectedValue = 0
                Case 24
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta23.DataSource = dt
                    cboRespuesta23.DisplayMember = "descripcion"
                    cboRespuesta23.ValueMember = "id"
                    cboRespuesta23.SelectedValue = 0
                Case 25
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta24.DataSource = dt
                    cboRespuesta24.DisplayMember = "descripcion"
                    cboRespuesta24.ValueMember = "id"
                    cboRespuesta24.SelectedValue = 0
                Case 26
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta25.DataSource = dt
                    cboRespuesta25.DisplayMember = "descripcion"
                    cboRespuesta25.ValueMember = "id"
                    cboRespuesta25.SelectedValue = 0
                Case 27
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta26.DataSource = dt
                    cboRespuesta26.DisplayMember = "descripcion"
                    cboRespuesta26.ValueMember = "id"
                    cboRespuesta26.SelectedValue = 0
                Case 28
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta27.DataSource = dt
                    cboRespuesta27.DisplayMember = "descripcion"
                    cboRespuesta27.ValueMember = "id"
                    cboRespuesta27.SelectedValue = 0
                Case 29
                    Me.LinkGraficaECAF.Tag = intparametrica
                    dt = objEscalas.CargarCamposParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    Me.lblResultadoEcaf.Tag = dt.Rows(0).Item("id").ToString
                    'fin ECAF
                    'inicio IK
                Case 30
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta28.DataSource = dt
                    cboRespuesta28.DisplayMember = "descripcion"
                    cboRespuesta28.ValueMember = "id"
                    cboRespuesta28.SelectedValue = 0
                Case 31
                    dt = objEscalas.CargarCamposParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    Me.lblResultadoIK.Tag = dt.Rows(0).Item("id").ToString
                    'fin IK
                    'inicio BARTHEL
                Case 32
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta29.DataSource = dt
                    cboRespuesta29.DisplayMember = "descripcion"
                    cboRespuesta29.ValueMember = "id"
                    cboRespuesta29.SelectedValue = 0
                Case 33
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta30.DataSource = dt
                    cboRespuesta30.DisplayMember = "descripcion"
                    cboRespuesta30.ValueMember = "id"
                    cboRespuesta30.SelectedValue = 0
                Case 34
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta31.DataSource = dt
                    cboRespuesta31.DisplayMember = "descripcion"
                    cboRespuesta31.ValueMember = "id"
                    cboRespuesta31.SelectedValue = 0
                Case 35
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta32.DataSource = dt
                    cboRespuesta32.DisplayMember = "descripcion"
                    cboRespuesta32.ValueMember = "id"
                    cboRespuesta32.SelectedValue = 0
                Case 36
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta33.DataSource = dt
                    cboRespuesta33.DisplayMember = "descripcion"
                    cboRespuesta33.ValueMember = "id"
                    cboRespuesta33.SelectedValue = 0
                Case 37
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta34.DataSource = dt
                    cboRespuesta34.DisplayMember = "descripcion"
                    cboRespuesta34.ValueMember = "id"
                    cboRespuesta34.SelectedValue = 0
                Case 38
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta35.DataSource = dt
                    cboRespuesta35.DisplayMember = "descripcion"
                    cboRespuesta35.ValueMember = "id"
                    cboRespuesta35.SelectedValue = 0
                Case 39
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta36.DataSource = dt
                    cboRespuesta36.DisplayMember = "descripcion"
                    cboRespuesta36.ValueMember = "id"
                    cboRespuesta36.SelectedValue = 0
                Case 40
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta37.DataSource = dt
                    cboRespuesta37.DisplayMember = "descripcion"
                    cboRespuesta37.ValueMember = "id"
                    cboRespuesta37.SelectedValue = 0
                Case 41
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta38.DataSource = dt
                    cboRespuesta38.DisplayMember = "descripcion"
                    cboRespuesta38.ValueMember = "id"
                    cboRespuesta38.SelectedValue = 0
                Case 42
                    dt = objEscalas.CargarCamposParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    Me.lblResultadoBarthel.Tag = dt.Rows(0).Item("id").ToString
                    'fin BARTHEL
                    'inicio RAMSAY
                Case 43
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta39.DataSource = dt
                    cboRespuesta39.DisplayMember = "descripcion"
                    cboRespuesta39.ValueMember = "id"
                    cboRespuesta39.SelectedValue = 0
                Case 44
                    dt = objEscalas.CargarCamposParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    Me.lblResultadoRamsay.Tag = dt.Rows(0).Item("id").ToString
                    'fin RAMSAY
                    'inicio CAM
                Case 45
                    dt = objEscalas.CargarCamposParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    For j As Integer = 0 To dt.Rows.Count - 1
                        If j = 0 Then
                            Me.opRespuestaNo40.Tag = dt.Rows(j).Item("id").ToString
                        End If
                        If j = 1 Then
                            Me.opRespuestaSi40.Tag = dt.Rows(j).Item("id").ToString
                        End If
                    Next
                Case 46
                    dt = objEscalas.CargarCamposParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    For j As Integer = 0 To dt.Rows.Count - 1
                        If j = 0 Then
                            Me.opRespuestaNo41.Tag = dt.Rows(j).Item("id").ToString
                        End If
                        If j = 1 Then
                            Me.opRespuestaSi41.Tag = dt.Rows(j).Item("id").ToString
                        End If
                    Next
                Case 47
                    dt = objEscalas.CargarCamposParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    For j As Integer = 0 To dt.Rows.Count - 1
                        If j = 0 Then
                            Me.opRespuestaNo42.Tag = dt.Rows(j).Item("id").ToString
                        End If
                        If j = 1 Then
                            Me.opRespuestaSi42.Tag = dt.Rows(j).Item("id").ToString
                        End If
                    Next
                Case 48
                    dt = objEscalas.CargarCamposParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    For j As Integer = 0 To dt.Rows.Count - 1
                        If j = 0 Then
                            Me.opRespuestaNo43.Tag = dt.Rows(j).Item("id").ToString
                        End If
                        If j = 1 Then
                            Me.opRespuestaSi43.Tag = dt.Rows(j).Item("id").ToString
                        End If
                    Next
                Case 49
                    dt = objEscalas.CargarCamposParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    Me.lblResultadoCam.Tag = dt.Rows(0).Item("id").ToString
                    'fin CAM
                    'inicio MDAS
                Case 50
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta44.DataSource = dt
                    cboRespuesta44.DisplayMember = "descripcion"
                    cboRespuesta44.ValueMember = "id"
                    cboRespuesta44.SelectedValue = 0
                Case 51
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta45.DataSource = dt
                    cboRespuesta45.DisplayMember = "descripcion"
                    cboRespuesta45.ValueMember = "id"
                    cboRespuesta45.SelectedValue = 0
                Case 52
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta46.DataSource = dt
                    cboRespuesta46.DisplayMember = "descripcion"
                    cboRespuesta46.ValueMember = "id"
                    cboRespuesta46.SelectedValue = 0
                Case 53
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta47.DataSource = dt
                    cboRespuesta47.DisplayMember = "descripcion"
                    cboRespuesta47.ValueMember = "id"
                    cboRespuesta47.SelectedValue = 0
                Case 54
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta48.DataSource = dt
                    cboRespuesta48.DisplayMember = "descripcion"
                    cboRespuesta48.ValueMember = "id"
                    cboRespuesta48.SelectedValue = 0
                Case 55
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta49.DataSource = dt
                    cboRespuesta49.DisplayMember = "descripcion"
                    cboRespuesta49.ValueMember = "id"
                    cboRespuesta49.SelectedValue = 0
                Case 56
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta50.DataSource = dt
                    cboRespuesta50.DisplayMember = "descripcion"
                    cboRespuesta50.ValueMember = "id"
                    cboRespuesta50.SelectedValue = 0
                Case 57
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta51.DataSource = dt
                    cboRespuesta51.DisplayMember = "descripcion"
                    cboRespuesta51.ValueMember = "id"
                    cboRespuesta51.SelectedValue = 0
                Case 58
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta52.DataSource = dt
                    cboRespuesta52.DisplayMember = "descripcion"
                    cboRespuesta52.ValueMember = "id"
                    cboRespuesta52.SelectedValue = 0
                Case 59
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta53.DataSource = dt
                    cboRespuesta53.DisplayMember = "descripcion"
                    cboRespuesta53.ValueMember = "id"
                    cboRespuesta53.SelectedValue = 0
                Case 60
                    dt = objEscalas.CargarCamposParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    Me.lblResultadoMdas.Tag = dt.Rows(0).Item("id").ToString
                    'fin MDAS
                    'inicio Mocca
                Case 61
                    dt = objEscalas.CargarCamposParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    Me.txtRespuesta54.Tag = dt.Rows(0).Item("id").ToString
                    Me.txtRespuesta15.Text = ""
                    'fin Mocca
                    'inicio Zarit
                Case 62
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta55.DataSource = dt
                    cboRespuesta55.DisplayMember = "descripcion"
                    cboRespuesta55.ValueMember = "id"
                    cboRespuesta55.SelectedValue = 0
                Case 63
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta56.DataSource = dt
                    cboRespuesta56.DisplayMember = "descripcion"
                    cboRespuesta56.ValueMember = "id"
                    cboRespuesta56.SelectedValue = 0
                Case 64
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta57.DataSource = dt
                    cboRespuesta57.DisplayMember = "descripcion"
                    cboRespuesta57.ValueMember = "id"
                    cboRespuesta57.SelectedValue = 0
                Case 65
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta58.DataSource = dt
                    cboRespuesta58.DisplayMember = "descripcion"
                    cboRespuesta58.ValueMember = "id"
                    cboRespuesta58.SelectedValue = 0
                Case 66
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta59.DataSource = dt
                    cboRespuesta59.DisplayMember = "descripcion"
                    cboRespuesta59.ValueMember = "id"
                    cboRespuesta59.SelectedValue = 0
                Case 67
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta60.DataSource = dt
                    cboRespuesta60.DisplayMember = "descripcion"
                    cboRespuesta60.ValueMember = "id"
                    cboRespuesta60.SelectedValue = 0
                Case 68
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta61.DataSource = dt
                    cboRespuesta61.DisplayMember = "descripcion"
                    cboRespuesta61.ValueMember = "id"
                    cboRespuesta61.SelectedValue = 0
                Case 69
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta62.DataSource = dt
                    cboRespuesta62.DisplayMember = "descripcion"
                    cboRespuesta62.ValueMember = "id"
                    cboRespuesta62.SelectedValue = 0
                Case 70
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta63.DataSource = dt
                    cboRespuesta63.DisplayMember = "descripcion"
                    cboRespuesta63.ValueMember = "id"
                    cboRespuesta63.SelectedValue = 0
                Case 71
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta64.DataSource = dt
                    cboRespuesta64.DisplayMember = "descripcion"
                    cboRespuesta64.ValueMember = "id"
                    cboRespuesta64.SelectedValue = 0
                Case 72
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta65.DataSource = dt
                    cboRespuesta65.DisplayMember = "descripcion"
                    cboRespuesta65.ValueMember = "id"
                    cboRespuesta65.SelectedValue = 0
                Case 73
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta66.DataSource = dt
                    cboRespuesta66.DisplayMember = "descripcion"
                    cboRespuesta66.ValueMember = "id"
                    cboRespuesta66.SelectedValue = 0
                Case 74
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta67.DataSource = dt
                    cboRespuesta67.DisplayMember = "descripcion"
                    cboRespuesta67.ValueMember = "id"
                    cboRespuesta67.SelectedValue = 0
                Case 75
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta68.DataSource = dt
                    cboRespuesta68.DisplayMember = "descripcion"
                    cboRespuesta68.ValueMember = "id"
                    cboRespuesta68.SelectedValue = 0
                Case 76
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta69.DataSource = dt
                    cboRespuesta69.DisplayMember = "descripcion"
                    cboRespuesta69.ValueMember = "id"
                    cboRespuesta69.SelectedValue = 0
                Case 77
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta70.DataSource = dt
                    cboRespuesta70.DisplayMember = "descripcion"
                    cboRespuesta70.ValueMember = "id"
                    cboRespuesta70.SelectedValue = 0
                Case 78
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta71.DataSource = dt
                    cboRespuesta71.DisplayMember = "descripcion"
                    cboRespuesta71.ValueMember = "id"
                    cboRespuesta71.SelectedValue = 0
                Case 79
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta72.DataSource = dt
                    cboRespuesta72.DisplayMember = "descripcion"
                    cboRespuesta72.ValueMember = "id"
                    cboRespuesta72.SelectedValue = 0
                Case 80
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta73.DataSource = dt
                    cboRespuesta73.DisplayMember = "descripcion"
                    cboRespuesta73.ValueMember = "id"
                    cboRespuesta73.SelectedValue = 0
                Case 81
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta74.DataSource = dt
                    cboRespuesta74.DisplayMember = "descripcion"
                    cboRespuesta74.ValueMember = "id"
                    cboRespuesta74.SelectedValue = 0
                Case 82
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta75.DataSource = dt
                    cboRespuesta75.DisplayMember = "descripcion"
                    cboRespuesta75.ValueMember = "id"
                    cboRespuesta75.SelectedValue = 0
                Case 83
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta76.DataSource = dt
                    cboRespuesta76.DisplayMember = "descripcion"
                    cboRespuesta76.ValueMember = "id"
                    cboRespuesta76.SelectedValue = 0
                Case 84
                    dt = objEscalas.CargarCamposParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    Me.lblResultadoZarit.Tag = dt.Rows(0).Item("id").ToString
                    'fin Zarit
                    'inicio HAD
                Case 85
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta77.DataSource = dt
                    cboRespuesta77.DisplayMember = "descripcion"
                    cboRespuesta77.ValueMember = "id"
                    cboRespuesta77.SelectedValue = 0
                Case 86
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta78.DataSource = dt
                    cboRespuesta78.DisplayMember = "descripcion"
                    cboRespuesta78.ValueMember = "id"
                    cboRespuesta78.SelectedValue = 0
                Case 87
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta79.DataSource = dt
                    cboRespuesta79.DisplayMember = "descripcion"
                    cboRespuesta79.ValueMember = "id"
                    cboRespuesta79.SelectedValue = 0
                Case 88
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta80.DataSource = dt
                    cboRespuesta80.DisplayMember = "descripcion"
                    cboRespuesta80.ValueMember = "id"
                    cboRespuesta80.SelectedValue = 0
                Case 89
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta81.DataSource = dt
                    cboRespuesta81.DisplayMember = "descripcion"
                    cboRespuesta81.ValueMember = "id"
                    cboRespuesta81.SelectedValue = 0
                Case 90
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta82.DataSource = dt
                    cboRespuesta82.DisplayMember = "descripcion"
                    cboRespuesta82.ValueMember = "id"
                    cboRespuesta82.SelectedValue = 0
                Case 91
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta83.DataSource = dt
                    cboRespuesta83.DisplayMember = "descripcion"
                    cboRespuesta83.ValueMember = "id"
                    cboRespuesta83.SelectedValue = 0
                Case 92
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta84.DataSource = dt
                    cboRespuesta84.DisplayMember = "descripcion"
                    cboRespuesta84.ValueMember = "id"
                    cboRespuesta84.SelectedValue = 0
                Case 93
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta85.DataSource = dt
                    cboRespuesta85.DisplayMember = "descripcion"
                    cboRespuesta85.ValueMember = "id"
                    cboRespuesta85.SelectedValue = 0
                Case 94
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta86.DataSource = dt
                    cboRespuesta86.DisplayMember = "descripcion"
                    cboRespuesta86.ValueMember = "id"
                    cboRespuesta86.SelectedValue = 0
                Case 95
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta87.DataSource = dt
                    cboRespuesta87.DisplayMember = "descripcion"
                    cboRespuesta87.ValueMember = "id"
                    cboRespuesta87.SelectedValue = 0
                Case 96
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta88.DataSource = dt
                    cboRespuesta88.DisplayMember = "descripcion"
                    cboRespuesta88.ValueMember = "id"
                    cboRespuesta88.SelectedValue = 0
                Case 97
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta89.DataSource = dt
                    cboRespuesta89.DisplayMember = "descripcion"
                    cboRespuesta89.ValueMember = "id"
                    cboRespuesta89.SelectedValue = 0
                Case 98
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta90.DataSource = dt
                    cboRespuesta90.DisplayMember = "descripcion"
                    cboRespuesta90.ValueMember = "id"
                    cboRespuesta90.SelectedValue = 0
                Case 99
                    dt = objEscalas.CargarCamposParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    Me.lblResultadoHADDepresion.Tag = dt.Rows(0).Item("id").ToString
                Case 100
                    dt = objEscalas.CargarCamposParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    Me.lblResultadoHADAnsiedad.Tag = dt.Rows(0).Item("id").ToString
                    'fin HAD
                    'inicio PPS
                Case 101
                    dt = objEscalas.CargarCombosParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta91.DataSource = dt
                    cboRespuesta91.DisplayMember = "descripcion"
                    Me.cboRespuesta91.DropDownWidth = 250

                    cboRespuesta91.ValueMember = "id"
                    cboRespuesta91.SelectedValue = 0
                Case 102
                    dt = objEscalas.CargarCamposParametrica(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    Me.lblResultadoPPS.Tag = dt.Rows(0).Item("id").ToString
                    'fin PPS
            End Select

        Catch ex As Exception
            MsgBox("Error en la consulta de parametricas. " & ex.Message, MsgBoxStyle.Information)
        End Try


    End Sub

    Private Sub totalpuntaje_escalas(ByVal iopcion As Integer)
        Dim iTotalpuntaje As Integer = 0
        'ESCALA DE SEVERIDAD Y DISCAPACIDAD DE LA ANSIEDAD (OASIS)
        If iopcion = 1 Then
            iTotalpuntaje = Int(Me.Puntaje1.Text) + Int(Me.Puntaje2.Text) + Int(Me.Puntaje3.Text) + Int(Me.Puntaje4.Text) + Int(Me.Puntaje5.Text)
            Me.lblResultadoOasis.Text = Str(iTotalpuntaje) + "/20"
        End If
        'ESCALA DE SEVERIDAD Y DISCAPACIDAD DE LA TRISTEZA (ODSIS)
        If iopcion = 2 Then
            iTotalpuntaje = Int(Me.Puntaje6.Text) + Int(Me.Puntaje7.Text) + Int(Me.Puntaje8.Text) + Int(Me.Puntaje9.Text) + Int(Me.Puntaje10.Text)
            Me.lblResultadoOdsis.Text = Str(iTotalpuntaje) + "/20"
        End If
        'EDMONTON CONFORT ASSESMENT FORM (ECAF)
        If iopcion = 4 Then
            iTotalpuntaje = Int(Me.Puntaje22.Text) + Int(Me.Puntaje23.Text) + Int(Me.Puntaje24.Text) + Int(Me.Puntaje25.Text) + Int(Me.Puntaje26.Text) + Int(Me.Puntaje27.Text)
            Me.lblResultadoEcaf.Text = Str(iTotalpuntaje) + "/24"
        End If
        'ESCALA DE BARTHEL
        If iopcion = 6 Then
            iTotalpuntaje = Int(Me.Puntaje29.Text) + Int(Me.Puntaje30.Text) + Int(Me.Puntaje31.Text) + Int(Me.Puntaje32.Text) + Int(Me.Puntaje33.Text) + Int(Me.Puntaje34.Text) + Int(Me.Puntaje35.Text) + +Int(Me.Puntaje36.Text) + Int(Me.Puntaje37.Text) + Int(Me.Puntaje38.Text)
            Me.lblResultadoBarthel.Text = Str(iTotalpuntaje) + "/100"
        End If
        'ESCALA DE CAM
        If iopcion = 8 Then
            ''WACHV,INICIO,20SEPT2015, SE UTILIZA NUEVA FUNCION
            If Not bfncObligatoriedad(iopcion) Then ''Si es Falso falta diligencias alguna pregunta
                Me.lblResultadoCam.Text = ""
            End If ''WACHV,FIN,20SEPT2015, SE UTILIZA NUEVA FUNCION
            ''WACHV,INICIO,20SEPT2015, SE COMENTA PARA AJUSTARLO CON LAS COMBINACIONES DE LA MATRIZ ENVIADA
            'If (Me.opRespuestaSi40.Checked = True And Me.opRespuestaSi41.Checked = True And (Me.opRespuestaSi42.Checked = True Or Me.opRespuestaSi43.Checked = True)) Then
            '    Me.lblResultadoCam.Text = "Compatible con Delirium"
            'Else
            '    Me.lblResultadoCam.Text = ""
            'End If
            ''WACHV,FIN,20SEPT2015, SE COMENTA PARA AJUSTARLO CON LAS COMBINACIONES DE LA MATRIZ ENVIADA
        End If
        'ESCALA DE MDAS
        If iopcion = 9 Then
            iTotalpuntaje = Int(Me.Puntaje44.Text) + Int(Me.Puntaje45.Text) + Int(Me.Puntaje46.Text) + Int(Me.Puntaje47.Text) + Int(Me.Puntaje48.Text) + Int(Me.Puntaje49.Text) + Int(Me.Puntaje50.Text) + +Int(Me.Puntaje51.Text) + Int(Me.Puntaje52.Text) + Int(Me.Puntaje53.Text)
            If iTotalpuntaje < 11 Then

                Me.lblResultadoMdas.Text = iTotalpuntaje.ToString() + " " + "Delirium Leve"   'WACHV,30 AGO2017, SE AGREGA EL VALOR DEL PUNTAJE
            Else
                If iTotalpuntaje > 10 And iTotalpuntaje < 21 Then
                    Me.lblResultadoMdas.Text = iTotalpuntaje.ToString() + " " + "Delirium Moderado" 'WACHV,30 AGO2017, SE AGREGA EL VALOR DEL PUNTAJE
                Else
                    Me.lblResultadoMdas.Text = iTotalpuntaje.ToString() + " " + "Delirium Severo"   'WACHV,30 AGO2017, SE AGREGA EL VALOR DEL PUNTAJE
                End If
            End If
        End If
        'ESCALA DE Zarit
        If iopcion = 11 Then
            iTotalpuntaje = Int(Me.Puntaje55.Text) + Int(Me.Puntaje56.Text) + Int(Me.Puntaje57.Text) + Int(Me.Puntaje58.Text) + Int(Me.Puntaje59.Text) _
                          + Int(Me.Puntaje60.Text) + Int(Me.Puntaje61.Text) + +Int(Me.Puntaje62.Text) + Int(Me.Puntaje63.Text) + Int(Me.Puntaje64.Text) _
                          + Int(Me.Puntaje65.Text) + Int(Me.Puntaje66.Text) + +Int(Me.Puntaje67.Text) + Int(Me.Puntaje68.Text) + Int(Me.Puntaje69.Text) _
                          + Int(Me.Puntaje70.Text) + Int(Me.Puntaje71.Text) + +Int(Me.Puntaje72.Text) + Int(Me.Puntaje73.Text) + Int(Me.Puntaje74.Text) _
                          + Int(Me.Puntaje75.Text) + Int(Me.Puntaje76.Text)
            If iTotalpuntaje < 47 Then
                Me.lblResultadoZarit.Text = iTotalpuntaje.ToString() + " " + "Ausencia de Sobrecarga"   'WACHV,30 AGO2017, SE AGREGA EL VALOR DEL PUNTAJE
            Else
                If iTotalpuntaje > 46 And iTotalpuntaje < 56 Then
                    Me.lblResultadoZarit.Text = iTotalpuntaje.ToString() + " " + "Sobrecarga Ligera"    'WACHV,30 AGO2017, SE AGREGA EL VALOR DEL PUNTAJE
                Else
                    Me.lblResultadoZarit.Text = iTotalpuntaje.ToString() + " " + "Sobrecarga Intensa"   'WACHV,30 AGO2017, SE AGREGA EL VALOR DEL PUNTAJE
                End If
            End If
        End If
        'ESCALA DE HAD
        If iopcion = 12 Then
            iTotalpuntaje = 0
            iTotalpuntaje = Int(Me.Puntaje77.Text) + Int(Me.Puntaje79.Text) + Int(Me.Puntaje81.Text) + Int(Me.Puntaje83.Text) + Int(Me.Puntaje85.Text) _
                          + Int(Me.Puntaje87.Text) + Int(Me.Puntaje89.Text)
            If iTotalpuntaje < 8 Then
                Me.lblResultadoHADAnsiedad.Text = iTotalpuntaje & " - Normal"
            Else
                If iTotalpuntaje > 7 And iTotalpuntaje < 11 Then
                    Me.lblResultadoHADAnsiedad.Text = iTotalpuntaje & " - Dudoso"
                Else
                    Me.lblResultadoHADAnsiedad.Text = iTotalpuntaje & " - Problema Clínico"
                End If
            End If
            iTotalpuntaje = 0
            iTotalpuntaje = Int(Me.Puntaje78.Text) + Int(Me.Puntaje80.Text) + Int(Me.Puntaje82.Text) + Int(Me.Puntaje84.Text) + Int(Me.Puntaje86.Text) _
                          + Int(Me.Puntaje88.Text) + Int(Me.Puntaje90.Text)
            If iTotalpuntaje < 8 Then
                Me.lblResultadoHADDepresion.Text = iTotalpuntaje & " - Normal"
            Else
                If iTotalpuntaje > 7 And iTotalpuntaje < 11 Then
                    Me.lblResultadoHADDepresion.Text = iTotalpuntaje & " - Dudoso"
                Else
                    Me.lblResultadoHADDepresion.Text = iTotalpuntaje & " - Problema Clínico"
                End If
            End If

        End If
    End Sub

    ''' <summary>
    ''' Valida Obligatoriedad de las escalas
    ''' </summary>
    ''' <remarks>WACHV, 20SEPT2017</remarks>
    Private Function bfncObligatoriedad(ByVal iopcion As Integer) As Boolean
        Dim bValidoObligatorio As Boolean = False

        Select Case iopcion
            Case 8 ''Escala de CAM
                If opRespuestaSi40.Checked Or opRespuestaNo40.Checked Then
                    If opRespuestaSi41.Checked Or opRespuestaNo41.Checked Then
                        If opRespuestaSi42.Checked Or opRespuestaNo42.Checked Then
                            If opRespuestaSi43.Checked Or opRespuestaNo43.Checked Then
                                bValidoObligatorio = True
                                'Escenario 1''Si, Si, Si,Si
                                If opRespuestaSi40.Checked And opRespuestaSi41.Checked And opRespuestaSi42.Checked And opRespuestaSi43.Checked Then
                                    Me.lblResultadoCam.Text = "CAM positivo para delirium"
                                End If
                                'Escenario 2'''Si, Si, Si, No
                                If opRespuestaSi40.Checked And opRespuestaSi41.Checked And opRespuestaSi42.Checked And opRespuestaNo43.Checked Then
                                    Me.lblResultadoCam.Text = "CAM positivo para delirium"
                                End If
                                'Escenario 3'''Si,Si,NO,Si
                                If opRespuestaSi40.Checked And opRespuestaSi41.Checked And opRespuestaNo42.Checked And opRespuestaSi43.Checked Then
                                    Me.lblResultadoCam.Text = "CAM positivo para delirium"
                                End If
                                'Escenario 4'''NO, NO,NO,NO
                                If opRespuestaNo40.Checked And opRespuestaNo41.Checked And opRespuestaNo42.Checked And opRespuestaNo43.Checked Then
                                    Me.lblResultadoCam.Text = "CAM negativo para delirium"
                                End If
                                'Escenario 5 '''NO, Si, Si,Si
                                If opRespuestaNo40.Checked And opRespuestaSi41.Checked And opRespuestaSi42.Checked And opRespuestaSi43.Checked Then
                                    Me.lblResultadoCam.Text = "CAM negativo para delirium"
                                End If
                                'Escenario 6 '''Si, No, Si, Si
                                If opRespuestaSi40.Checked And opRespuestaNo41.Checked And opRespuestaSi42.Checked And opRespuestaSi43.Checked Then
                                    Me.lblResultadoCam.Text = "CAM negativo para delirium"
                                End If
                                'Escenario 7 '''Si,Si,No, No
                                If opRespuestaSi40.Checked And opRespuestaSi41.Checked And opRespuestaNo42.Checked And opRespuestaNo43.Checked Then
                                    Me.lblResultadoCam.Text = "CAM negativo para delirium"
                                End If
                                'Escenario 8 '''No,No,Si,Si
                                If opRespuestaNo40.Checked And opRespuestaNo41.Checked And opRespuestaSi42.Checked And opRespuestaSi43.Checked Then
                                    Me.lblResultadoCam.Text = "CAM negativo para delirium"
                                End If
                                'Escenario 9 '''No,No,Si,No
                                If opRespuestaNo40.Checked And opRespuestaNo41.Checked And opRespuestaSi42.Checked And opRespuestaNo43.Checked Then
                                    Me.lblResultadoCam.Text = "CAM negativo para delirium"
                                End If
                                'Escenario 10 '''No,No,NO,Si
                                If opRespuestaNo40.Checked And opRespuestaNo41.Checked And opRespuestaNo42.Checked And opRespuestaSi43.Checked Then
                                    Me.lblResultadoCam.Text = "CAM negativo para delirium"
                                End If
                                'Escenario 11 '''No,Si,No,Si
                                If opRespuestaNo40.Checked And opRespuestaSi41.Checked And opRespuestaNo42.Checked And opRespuestaSi43.Checked Then
                                    Me.lblResultadoCam.Text = "CAM negativo para delirium"
                                End If
                                'Escenario 12 '''No,Si,Si,No
                                If opRespuestaNo40.Checked And opRespuestaSi41.Checked And opRespuestaSi42.Checked And opRespuestaNo43.Checked Then
                                    Me.lblResultadoCam.Text = "CAM negativo para delirium"
                                End If
                                'Escenario 13 '''Si,No,No,Si
                                If opRespuestaSi40.Checked And opRespuestaNo41.Checked And opRespuestaNo42.Checked And opRespuestaSi43.Checked Then
                                    Me.lblResultadoCam.Text = "CAM negativo para delirium"
                                End If
                                'Escenario 14 '''Si,No,Si,No
                                If opRespuestaSi40.Checked And opRespuestaNo41.Checked And opRespuestaSi42.Checked And opRespuestaNo43.Checked Then
                                    Me.lblResultadoCam.Text = "CAM negativo para delirium"
                                End If
                            End If
                        End If
                    End If
                End If

        End Select

        bfncObligatoriedad = bValidoObligatorio
    End Function

    ''WACHV, INICIO, 09OCT2017, SE GUARDA LA SECION CORRESPONDIENTE 
    Private Sub GuardarSecciones(ByVal intEscala() As String, ByVal iSeccion As Integer)
        Dim strMensaje As String = ""
        Dim strEvaluacionSintomas As String = ""
        Dim strEvaluacionFuncionalidad As String = ""
        Dim strOtrasHerramientasEvaluacion As String = ""
        Dim bValidarEscalas As Boolean = True
        Dim strRespuestaGuardar As String = ""
        Dim strRespuestaValidacion As String = ""

        Try
            ''Valida la escala y luego de guardarla, guarda la seccion el seleccionado en la misma
            Select Case iSeccion
                Case 1

                    strRespuestaValidacion = Validar_Escalas(intEscala, bValidarEscalas)

                    If Len(strRespuestaValidacion) > 0 Then
                        MsgBox(strRespuestaValidacion)
                        Exit Sub
                    Else
                        For i As Integer = intEscala.GetLowerBound(0) To intEscala.Length - 1
                            If intEscala(i) = "GRPESAS" Then
                                strRespuestaGuardar = GuardarEscalas(3)
                                strEvaluacionSintomas = "210701"
                                LimpiardatosEscalas(3)
                            ElseIf intEscala(i) = "GRPECAF" Then ''escala ECAF
                                strEvaluacionSintomas = "210702"
                                strRespuestaGuardar = GuardarEscalas(4)
                                LimpiardatosEscalas(4)
                            ElseIf intEscala(i) = "NINGUNO" Then
                                strEvaluacionSintomas = "210703"
                                strRespuestaGuardar = GuardarEscalas(0)
                                LimpiardatosEscalas(3)
                                LimpiardatosEscalas(4)
                            End If
                        Next
                    End If

                Case 2

                    strRespuestaValidacion = Validar_Escalas(intEscala, bValidarEscalas)

                    If Len(strRespuestaValidacion) > 0 Then
                        MsgBox(strRespuestaValidacion)
                        Exit Sub
                    Else
                        For i As Integer = intEscala.GetLowerBound(0) To intEscala.Length - 1
                            If intEscala(i) = "GRPPPS" Then
                                strRespuestaGuardar = GuardarEscalas(13)
                                strEvaluacionFuncionalidad = "210801"
                                LimpiardatosEscalas(13)
                            ElseIf intEscala(i) = "GRPIK" Then ''escala ECAF
                                strEvaluacionFuncionalidad = "210802"
                                strRespuestaGuardar = GuardarEscalas(5)
                                LimpiardatosEscalas(5)
                            ElseIf intEscala(i) = "NINGUNO" Then
                                strEvaluacionFuncionalidad = "210803"
                                strRespuestaGuardar = GuardarEscalas(0)
                                LimpiardatosEscalas(13)
                                LimpiardatosEscalas(5)
                            End If
                        Next
                    End If

                Case 3 'Seccion de Otras Herramientas de Evaluacion   ''3 ==> OASIS (1), ODSIS(2), BARTHEL (6),RAMSAY (7),CAM(8),MDAS (9), MOCCA(10),ZARIT(11),HAD(12)

                    strRespuestaValidacion = Validar_Escalas(intEscala, bValidarEscalas)

                    If Len(strRespuestaValidacion) > 0 Then
                        MsgBox(strRespuestaValidacion)
                        Exit Sub
                    Else
                        For i As Integer = intEscala.GetLowerBound(0) To intEscala.Length - 1
                            If intEscala(i) = "GRPOASIS" Then
                                strRespuestaGuardar = strRespuestaGuardar + " " + GuardarEscalas(1) + Chr(13)
                                strOtrasHerramientasEvaluacion = strOtrasHerramientasEvaluacion + "210901" + strSeparador
                            End If
                            If intEscala(i) = "GRPODSIS" Then
                                strRespuestaGuardar = strRespuestaGuardar + " " + GuardarEscalas(2) + Chr(13)
                                strOtrasHerramientasEvaluacion = strOtrasHerramientasEvaluacion + "210902" + strSeparador
                            End If
                            If intEscala(i) = "GRPBARTHEL" Then
                                strRespuestaGuardar = strRespuestaGuardar + " " + GuardarEscalas(6) + Chr(13)
                                strOtrasHerramientasEvaluacion = strOtrasHerramientasEvaluacion + "210903" + strSeparador
                            End If
                            If intEscala(i) = "GRPRAMSAY" Then
                                strRespuestaGuardar = strRespuestaGuardar + " " + GuardarEscalas(7) + Chr(13)
                                strOtrasHerramientasEvaluacion = strOtrasHerramientasEvaluacion + "210904" + strSeparador
                            End If
                            If intEscala(i) = "GRPCAM" Then
                                strRespuestaGuardar = strRespuestaGuardar + " " + GuardarEscalas(8) + Chr(13)
                                strOtrasHerramientasEvaluacion = strOtrasHerramientasEvaluacion + "210905" + strSeparador
                            End If
                            If intEscala(i) = "GRPMDAS" Then
                                strRespuestaGuardar = strRespuestaGuardar + " " + GuardarEscalas(9) + Chr(13)
                                strOtrasHerramientasEvaluacion = strOtrasHerramientasEvaluacion + "210906" + strSeparador
                            End If
                            If intEscala(i) = "GRPMOCCA" Then
                                strRespuestaGuardar = strRespuestaGuardar + " " + GuardarEscalas(10) + Chr(13)
                                strOtrasHerramientasEvaluacion = strOtrasHerramientasEvaluacion + "210907" + strSeparador
                            End If
                            If intEscala(i) = "GRPZARIT" Then
                                strRespuestaGuardar = strRespuestaGuardar + " " + GuardarEscalas(11) + Chr(13)
                                strOtrasHerramientasEvaluacion = strOtrasHerramientasEvaluacion + "210908" + strSeparador
                            End If
                            If intEscala(i) = "GRPHAD" Then
                                strRespuestaGuardar = strRespuestaGuardar + " " + GuardarEscalas(12) + Chr(13)
                                strOtrasHerramientasEvaluacion = strOtrasHerramientasEvaluacion + "210909" + strSeparador
                            End If
                        Next
                        LimpiardatosEscalas(1)
                        LimpiardatosEscalas(2)
                        LimpiardatosEscalas(6)
                        LimpiardatosEscalas(7)
                        LimpiardatosEscalas(8)
                        LimpiardatosEscalas(9)
                        LimpiardatosEscalas(10)
                        LimpiardatosEscalas(11)
                        LimpiardatosEscalas(12)
                    End If

            End Select

            'If Len(strRespuestaGuardar) > 0 Then
            '    MsgBox(strRespuestaGuardar)
            '    InicialiarArreglo()
            '    Exit Sub
            'End If


            If bValidarEscalas = True Then ''Si no presento algun valor de cada escala faltante entra a guardar la seccion
                If Len(strEvaluacionSintomas) > 0 Or Len(strEvaluacionFuncionalidad) > 0 Or Len(strOtrasHerramientasEvaluacion) > 0 Then ''Si Selecciono alguna opcion, 
                    strMensaje = objEscalas.GrabarOpcionesHerramientasEvaluacion(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                     objPaciente.AnoAdmision, objPaciente.NumeroAdmision, objPaciente.TipoDocumento, objPaciente.NumeroDocumento,
                                     strEvaluacionSintomas, strEvaluacionFuncionalidad, strOtrasHerramientasEvaluacion, "", objGeneral.Login)
                Else
                    MsgBox("Error en  " + strRespuestaGuardar, MsgBoxStyle.Information)
                End If
            Else ''salir de la seccion sin guardar 
                MsgBox(strRespuestaGuardar, MsgBoxStyle.Information)
                Exit Sub
            End If

            If strMensaje = "0" Then
                If iSeccion <> 3 Then
                    MsgBox("Se grabo la seccion exitosamente " + strRespuestaGuardar, MsgBoxStyle.Information)
                ElseIf (iSeccion = 3 And Not strOtrasHerramientasEvaluacion.Contains("NINGUNO")) Then ''No debe mostrar mensaje cuando es ninguno en esta seccion
                    MsgBox("Se grabo la seccion exitosamente " + strRespuestaGuardar, MsgBoxStyle.Information)
                End If
            End If

            InicialiarArreglo()

        Catch ex As Exception
            MsgBox("Error al guardar la seccion. " & ex.Message, MsgBoxStyle.Information)
        End Try


        'If (IsNothing(intEscala)) Then
        '    ReDim intEscala(0)
        'ElseIf intEscala.Length > 0 Then
        '    ReDim intEscala(0)
        'End If


        'Select Case intSeccion
        '    Case 1 'Seccion de Evaluacion de Sintomas       ''1 ==> ESAS (3), ECAF(4), NINGUNO (0)
        '        If chkEsas.Checked Then     ''escala ESAS
        '            strEvaluacionSintomas = "210701"
        '            intEscala(0) = 3
        '        ElseIf chkECAF.Checked Then ''escala ECAF
        '            strEvaluacionSintomas = "210702"
        '            intEscala(0) = 4
        '        ElseIf chkNingunoEvalSintomas.Checked Then
        '            strEvaluacionSintomas = "210703"
        '            intEscala(0) = 0
        '        End If

        '    Case 2 'Seccion de Evaluacion de Funcionalidad   ''2 ==> PPS (13), IK(5), NINGUNO (0)
        '        If chkPPS.Checked Then     ''escala PPS
        '            strEvaluacionFuncionalidad = "210801"
        '            intEscala(0) = 13
        '        ElseIf chkIK.Checked Then ''escala IK
        '            strEvaluacionFuncionalidad = "210802"
        '            intEscala(0) = 5
        '        ElseIf chkNingunoEvalFuncionalidad.Checked Then
        '            strEvaluacionFuncionalidad = "210803"
        '            intEscala(0) = 0
        '        End If

        '    Case 3 'Seccion de Otras Herramientas de Evaluacion   ''3 ==> OASIS (1), ODSIS(2), BARTHEL (6),RAMSAY (7),CAM(8),MDAS (9), MOCCA(10),ZARIT(11),HAD(12)

        '        If chkOASIS.Checked Then     ''escala OASIS
        '            strOtrasHerramientasEvaluacion = strOtrasHerramientasEvaluacion + "210901" + strSeparador
        '            If UBound(intEscala) = 0 And IsNothing(intEscala(UBound(intEscala))) Then
        '                intEscala(UBound(intEscala)) = 1
        '            Else
        '                ReDim Preserve intEscala(UBound(intEscala) + 1)
        '                intEscala(UBound(intEscala)) = 1
        '            End If

        '        End If
        '        If chkODSIS.Checked Then ''escala ODIS
        '            strOtrasHerramientasEvaluacion = strOtrasHerramientasEvaluacion + "210902" + strSeparador
        '            If UBound(intEscala) = 0 And IsNothing(intEscala(UBound(intEscala))) Then
        '                intEscala(UBound(intEscala)) = 2
        '            Else
        '                ReDim Preserve intEscala(UBound(intEscala) + 1)
        '                intEscala(UBound(intEscala)) = 2
        '            End If
        '        End If
        '        If chkEscaladebarthel.Checked Then ''escala Barthel
        '            strOtrasHerramientasEvaluacion = strOtrasHerramientasEvaluacion + "210903" + strSeparador
        '            If UBound(intEscala) = 0 And IsNothing(intEscala(UBound(intEscala))) Then
        '                intEscala(UBound(intEscala)) = 6
        '            Else
        '                ReDim Preserve intEscala(UBound(intEscala) + 1)
        '                intEscala(UBound(intEscala)) = 6
        '            End If
        '        End If
        '        If chkRamsay.Checked Then ''escala RAMSAY
        '            strOtrasHerramientasEvaluacion = strOtrasHerramientasEvaluacion + "210904" + strSeparador
        '            If UBound(intEscala) = 0 And IsNothing(intEscala(UBound(intEscala))) Then
        '                intEscala(UBound(intEscala)) = 7
        '            Else
        '                ReDim Preserve intEscala(UBound(intEscala) + 1)
        '                intEscala(UBound(intEscala)) = 7
        '            End If
        '        End If
        '        If chkCAM.Checked Then ''escala CAM
        '            strOtrasHerramientasEvaluacion = strOtrasHerramientasEvaluacion + "210905" + strSeparador
        '            If UBound(intEscala) = 0 And IsNothing(intEscala(UBound(intEscala))) Then
        '                intEscala(UBound(intEscala)) = 8
        '            Else
        '                ReDim Preserve intEscala(UBound(intEscala) + 1)
        '                intEscala(UBound(intEscala)) = 8
        '            End If
        '        End If
        '        If chkMdas.Checked Then ''escala MDAS
        '            strOtrasHerramientasEvaluacion = strOtrasHerramientasEvaluacion + "210906" + strSeparador
        '            If UBound(intEscala) = 0 And IsNothing(intEscala(UBound(intEscala))) Then
        '                intEscala(UBound(intEscala)) = 9
        '            Else
        '                ReDim Preserve intEscala(UBound(intEscala) + 1)
        '                intEscala(UBound(intEscala)) = 9
        '            End If
        '        End If
        '        If chkEscalaMocca.Checked Then ''escala MOCCA
        '            strOtrasHerramientasEvaluacion = strOtrasHerramientasEvaluacion + "210907" + strSeparador
        '            If UBound(intEscala) = 0 And IsNothing(intEscala(UBound(intEscala))) Then
        '                intEscala(UBound(intEscala)) = 10
        '            Else
        '                ReDim Preserve intEscala(UBound(intEscala) + 1)
        '                intEscala(UBound(intEscala)) = 10
        '            End If
        '        End If
        '        If chkTestdezarit.Checked Then ''escala ZARIT
        '            strOtrasHerramientasEvaluacion = strOtrasHerramientasEvaluacion + "210908" + strSeparador
        '            If UBound(intEscala) = 0 And IsNothing(intEscala(UBound(intEscala))) Then
        '                intEscala(UBound(intEscala)) = 11
        '            Else
        '                ReDim Preserve intEscala(UBound(intEscala) + 1)
        '                intEscala(UBound(intEscala)) = 11
        '            End If
        '        End If
        '        If chkHAD.Checked Then ''escala HAD
        '            strOtrasHerramientasEvaluacion = strOtrasHerramientasEvaluacion + "210909" + strSeparador
        '            If UBound(intEscala) = 0 And IsNothing(intEscala(UBound(intEscala))) Then
        '                intEscala(UBound(intEscala)) = 12
        '            Else
        '                ReDim Preserve intEscala(UBound(intEscala) + 1)
        '                intEscala(UBound(intEscala)) = 12
        '            End If
        '            'Else
        '            '    strOtrasHerramientasEvaluacion = "NINGUNO"
        '            '    intEscala(0) = 0
        '        End If

        'End Select

        'Dim strRespuestaValidacion As String = ""
        '''Valida la escala y luego de guardarla, guarda la seccion el seleccionado en la misma
        'For iEscalaEvaluar As Integer = 0 To intEscala.Length - 1
        '    If intEscala(iEscalaEvaluar) <> 0 Then ''Si el valor es diferente de cero (Ninguno)
        '        Validar_Escalas(intEscala(iEscalaEvaluar), strRespuestaValidacion)
        '        If Len(strRespuestaValidacion) = 0 Then
        '            GuardarEscalas(intEscala(iEscalaEvaluar))
        '            LimpiardatosEscalas(intEscala(iEscalaEvaluar))
        '        Else
        '            bValidarEscalas = False
        '            MsgBox(strRespuestaValidacion)
        '            Exit For
        '        End If
        '    End If
        'Next
        '''Quitar el ultimo separador
        'Dim separators() As String = {"<|^|>"}
        'Dim words() As String = strOtrasHerramientasEvaluacion.Split(strSeparador, StringSplitOptions.RemoveEmptyEntries)
        'If strOtrasHerramientasEvaluacion Then
        '    Dim strResult As String = strOtrasHerramientasEvaluacion
        'strOtrasHerramientasEvaluacion = strOtrasHerramientasEvaluacion.Substring(0, Len(strOtrasHerramientasEvaluacion) - Len(strSeparador))

        'If bValidarEscalas = True Then ''Si no presento algun valor de cada escala faltante entra a guardar la seccion
        '    If Len(strEvaluacionSintomas) > 0 Or Len(strEvaluacionFuncionalidad) > 0 Or Len(strOtrasHerramientasEvaluacion) > 0 Then ''Si Selecciono alguna opcion, 
        '        strMensaje = objEscalas.GrabarOpcionesHerramientasEvaluacion(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
        '                         objPaciente.AnoAdmision, objPaciente.NumeroAdmision, objPaciente.TipoDocumento, objPaciente.NumeroDocumento,
        '                         strEvaluacionSintomas, strEvaluacionFuncionalidad, strOtrasHerramientasEvaluacion, "", objGeneral.Login)
        '    Else
        '        MsgBox("Debe seleccionar alguna opcion. ", MsgBoxStyle.Information)
        '    End If
        'Else ''salir de la seccion sin guardar 
        '    Exit Sub
        'End If

        'If strMensaje = "0" Then
        '    If intSeccion <> 3 Then
        '        MsgBox("Se grabo la seccion exitosamente ", MsgBoxStyle.Information)
        '    ElseIf (intSeccion = 3 And Not strOtrasHerramientasEvaluacion.Contains("NINGUNO")) Then ''No debe mostrar mensaje cuando es ninguno en esta seccion
        '        MsgBox("Se grabo la seccion exitosamente ", MsgBoxStyle.Information)
        '    End If
        'End If
        'Catch ex As Exception
        '    MsgBox("Error al guardar la seccion. " & ex.Message, MsgBoxStyle.Information)
        'End Try
    End Sub ''WACHV, FIN, 09OCT2017, SE GUARDA LA SECION CORESPONDIENTE 
    ''WACHV, INICIO, 09OCT2017,LLAMA A SUB GUARDA SECCION
    Private Sub btAgregarEvaluaciondeSintomas_Click(sender As Object, e As EventArgs) Handles btAgregarEvaluaciondeSintomas.Click
        GuardarSecciones(ArregloSeleccionadosUnicos, 1)
    End Sub
    Private Sub btAgregarEvaluaciondeFuncionalidad_Click(sender As Object, e As EventArgs) Handles btAgregarEvaluaciondeFuncionalidad.Click
        GuardarSecciones(ArregloSeleccionadosUnicos, 2)
    End Sub
    Private Sub btAgregarOtrasHerramientasEvaluacion_Click(sender As Object, e As EventArgs) Handles btAgregarOtrasHerramientasEvaluacion.Click
        GuardarSecciones(ArregloSeleccionados, 3)
    End Sub
    ''WACHV, FIN, 09OCT2017,LLAMA A SUB GUARDA SECCION
    Private Function GuardarEscalas(ByVal intopcion As Integer) As String
        Dim strMensaje As String = ""
        Dim cont As Integer = 0
        Dim recuento As String = ""
        Dim secuencia As Integer = 0
        Dim objdao As New DAOGeneral
        Dim dtdatos As New DataTable
        Dim tmptotalpuntaje As Integer = 0
        Dim strRespuesta As String = ""

        dtdatos = objEscalas.ConsultarPreguntasEscalas()

        Try
            Select Case intopcion
                Case 1 'graba en la tabla HC_Cp_Escala_Oasis
                    Try
                        For i As Integer = 0 To 5
                            If i = 0 Then
                                If Len(Me.Label1.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label1.Text, "",
                                                                           Me.Puntaje1.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 1 Then
                                If Len(Me.Label2.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label2.Text, "",
                                                                           Me.Puntaje2.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 2 Then
                                If Len(Me.Label3.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label3.Text, "",
                                                                           Me.Puntaje3.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 3 Then
                                If Len(Me.Label4.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label4.Text, "",
                                                                           Me.Puntaje4.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 4 Then
                                If Len(Me.Label5.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label5.Text, "",
                                                                           Me.Puntaje5.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 5 Then
                                tmptotalpuntaje = Int(Me.Puntaje1.Text) + Int(Me.Puntaje2.Text) + Int(Me.Puntaje3.Text) + Int(Me.Puntaje4.Text) + Int(Me.Puntaje5.Text)
                                If (tmptotalpuntaje >= 0) Then

                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.lblResultadoOasis.Tag,
                                                                           Me.lblResultadoOasis.Text, tmptotalpuntaje, "", objGeneral.Login, intopcion)
                                End If
                            End If
                        Next

                        'MsgBox("se grabo la escala de OASIS exitosamente ", MsgBoxStyle.Information)
                        strRespuesta = "se grabo la escala de OASIS exitosamente "
                    Catch ex As Exception
                        strRespuesta = "Error al guardar escala OASIS. "
                        ''MsgBox("Error al guardar escala OASIS. " & ex.Message, MsgBoxStyle.Information)
                    End Try

                Case 2 'graba en la tabla HC_Cp_Escala_ODSIS
                    Try
                        For i As Integer = 6 To 11
                            If i = 6 Then
                                If Len(Me.Label6.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label6.Text, "",
                                                                           Me.Puntaje6.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 7 Then
                                If Len(Me.Label7.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label7.Text, "",
                                                                           Me.Puntaje7.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 8 Then
                                If Len(Me.Label8.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label8.Text, "",
                                                                           Me.Puntaje8.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 9 Then
                                If Len(Me.Label9.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label9.Text, "",
                                                                           Me.Puntaje9.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 10 Then
                                If Len(Me.Label10.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label10.Text, "",
                                                                           Me.Puntaje10.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 11 Then
                                tmptotalpuntaje = Int(Me.Puntaje6.Text) + Int(Me.Puntaje7.Text) + Int(Me.Puntaje8.Text) + Int(Me.Puntaje9.Text) + Int(Me.Puntaje10.Text)
                                If (tmptotalpuntaje >= 0) Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.lblResultadoOdsis.Tag,
                                                                           Me.lblResultadoOdsis.Text, tmptotalpuntaje, "", objGeneral.Login, intopcion)
                                End If
                            End If
                        Next
                        strRespuesta = "se grabo la escala de ODSIS exitosamente "
                        'MsgBox("se grabo la escala de ODSIS exitosamente ", MsgBoxStyle.Information)
                    Catch ex As Exception
                        strRespuesta = "se grabo la escala de ODSIS exitosamente "
                        'MsgBox("Error al guardar escala ODSIS. " & ex.Message, MsgBoxStyle.Information)
                    End Try

                Case 3 'graba en la tabla HC_Cp_Escala_ESAS
                    Try
                        For i As Integer = 12 To 22
                            If i = 12 Then
                                If Len(Me.txtRespuesta11.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label11.Text, Me.txtRespuesta11.Text,
                                                                           0, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 13 Then
                                If Len(Me.txtRespuesta12.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label12.Text, Me.txtRespuesta12.Text,
                                                                           0, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 14 Then
                                If Len(Me.txtRespuesta13.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label13.Text, Me.txtRespuesta13.Text,
                                                                           0, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 15 Then
                                If Len(Me.txtRespuesta14.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label14.Text, Me.txtRespuesta14.Text,
                                                                           0, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 16 Then
                                If Len(Me.txtRespuesta15.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label15.Text, Me.txtRespuesta15.Text,
                                                                           0, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 17 Then
                                If Len(Me.txtRespuesta16.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label16.Text, Me.txtRespuesta16.Text,
                                                                           0, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 18 Then
                                If Len(Me.txtRespuesta17.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label17.Text, Me.txtRespuesta17.Text,
                                                                           0, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 19 Then
                                If Len(Me.txtRespuesta18.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label18.Text, Me.txtRespuesta18.Text,
                                                                           0, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 20 Then
                                If Len(Me.txtRespuesta19.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label19.Text, Me.txtRespuesta19.Text,
                                                                           0, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 21 Then
                                If Len(Me.txtRespuesta20.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label20.Text, Me.txtRespuesta20.Text,
                                                                           0, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 22 Then
                                If Len(Me.txtRespuesta21.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label21.Text, Me.txtRespuesta21.Text,
                                                                           0, "", objGeneral.Login, intopcion)
                                End If
                            End If
                        Next
                        strRespuesta = "se grabo la escala de ESAS exitosamente "
                        'MsgBox("se grabo la escala de ESAS exitosamente ", MsgBoxStyle.Information)
                    Catch ex As Exception
                        strRespuesta = "Error al guardar escalas ESAS. "
                        ''MsgBox("Error al guardar escalas ESAS. " & ex.Message, MsgBoxStyle.Information)
                    End Try

                Case 4 'graba en la tabla HC_Cp_Escala_ECAF
                    Try
                        For i As Integer = 23 To 29
                            If i = 23 Then
                                If Len(Me.Label22.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label22.Text, "",
                                                                           Me.Puntaje22.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 24 Then
                                If Len(Me.Label23.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label23.Text, "",
                                                                           Me.Puntaje23.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 25 Then
                                If Len(Me.Label24.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label24.Text, "",
                                                                           Me.Puntaje24.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 26 Then
                                If Len(Me.Label25.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label25.Text, "",
                                                                           Me.Puntaje25.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 27 Then
                                If Len(Me.Label26.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label26.Text, "",
                                                                           Me.Puntaje26.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 28 Then
                                If Len(Me.Label27.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label27.Text, "",
                                                                           Me.Puntaje27.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 29 Then
                                tmptotalpuntaje = Int(Me.Puntaje22.Text) + Int(Me.Puntaje23.Text) + Int(Me.Puntaje24.Text) + Int(Me.Puntaje25.Text) + Int(Me.Puntaje26.Text) + Int(Me.Puntaje27.Text)
                                If (tmptotalpuntaje >= 0) Then

                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.lblResultadoEcaf.Tag,
                                                                           Me.lblResultadoEcaf.Text, tmptotalpuntaje, "", objGeneral.Login, intopcion)
                                End If
                            End If
                        Next
                        strRespuesta = "se grabo la escala de ECAF exitosamente "
                        ''MsgBox("se grabo la escala de ECAF exitosamente ", MsgBoxStyle.Information)
                    Catch ex As Exception
                        strRespuesta = "Error al guardar escalar de ECAF. "
                        ''MsgBox("Error al guardar escalar de ECAF. " & ex.Message, MsgBoxStyle.Information)
                    End Try

                Case 5 'graba en la tabla HC_Cp_Escala_IK
                    Try
                        For i As Integer = 30 To 31
                            If i = 30 Then
                                If Len(Me.Label28.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label28.Text, "",
                                                                           Me.Puntaje28.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 31 Then
                                If (Len(Me.Label28.Text) > 0) Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.lblResultadoIK.Tag,
                                                                           Me.lblResultadoIK.Text, Me.Puntaje28.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                        Next
                        strRespuesta = "se grabo la escala de IK exitosamente "
                        '''MsgBox("se grabo la escala de IK exitosamente ", MsgBoxStyle.Information)
                    Catch ex As Exception
                        strRespuesta = "Error al guardar escala de IK. "
                        '''MsgBox("Error al guardar escala de IK. " & ex.Message, MsgBoxStyle.Information)
                    End Try


                Case 6 'graba en la tabla HC_Cp_Escala_BARTHEL
                    Try
                        For i As Integer = 32 To 42
                            If i = 32 Then
                                If Len(Me.Label29.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label29.Text, "",
                                                                           Me.Puntaje29.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 33 Then
                                If Len(Me.Label30.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label30.Text, "",
                                                                           Me.Puntaje30.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 34 Then
                                If Len(Me.Label31.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label31.Text, "",
                                                                           Me.Puntaje31.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 35 Then
                                If Len(Me.Label32.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label32.Text, "",
                                                                           Me.Puntaje32.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 36 Then
                                If Len(Me.Label33.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label33.Text, "",
                                                                           Me.Puntaje33.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 37 Then
                                If Len(Me.Label34.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label34.Text, "",
                                                                           Me.Puntaje34.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 38 Then
                                If Len(Me.Label35.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label35.Text, "",
                                                                           Me.Puntaje35.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 39 Then
                                If Len(Me.Label36.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label36.Text, "",
                                                                           Me.Puntaje36.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 40 Then
                                If Len(Me.Label37.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label37.Text, "",
                                                                           Me.Puntaje37.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 41 Then
                                If Len(Me.Label38.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label38.Text, "",
                                                                           Me.Puntaje38.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 42 Then
                                tmptotalpuntaje = Int(Me.Puntaje29.Text) + Int(Me.Puntaje30.Text) + Int(Me.Puntaje31.Text) + Int(Me.Puntaje32.Text) + Int(Me.Puntaje33.Text) + Int(Me.Puntaje34.Text) + Int(Me.Puntaje35.Text) + +Int(Me.Puntaje36.Text) + Int(Me.Puntaje37.Text) + Int(Me.Puntaje38.Text)
                                If (tmptotalpuntaje >= 0) Then

                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.lblResultadoBarthel.Tag,
                                                                           Me.lblResultadoBarthel.Text, tmptotalpuntaje, "", objGeneral.Login, intopcion)
                                End If
                            End If
                        Next
                        strRespuesta = "se grabo la escala de BARTHEL exitosamente "
                        ''MsgBox("se grabo la escala de BARTHEL exitosamente ", MsgBoxStyle.Information)
                    Catch ex As Exception
                        strRespuesta = "Error al guardar escala de BARTHEL. "
                        ''MsgBox("Error al guardar escala de BARTHEL. " & ex.Message, MsgBoxStyle.Information)
                    End Try

                Case 7 'graba en la tabla HC_Cp_Escala_RAMSAY
                    Try
                        For i As Integer = 43 To 44
                            If i = 43 Then
                                If Len(Me.Label39.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label39.Text, "",
                                                                           Me.Puntaje39.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 44 Then
                                If (Len(Me.Label39.Text) > 0) Then

                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.lblResultadoRamsay.Tag,
                                                                           Me.lblResultadoRamsay.Text, Me.Puntaje39.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                        Next
                        strRespuesta = "se grabo la escala de RAMSAY exitosamente "
                        '''MsgBox("se grabo la escala de RAMSAY exitosamente ", MsgBoxStyle.Information)
                    Catch ex As Exception
                        strRespuesta = "Error al guardar escala de RAMSAY. "
                        ''MsgBox("Error al guardar escala de RAMSAY. " & ex.Message, MsgBoxStyle.Information)
                    End Try

                Case 8 'graba en la tabla HC_Cp_Escala_CAM
                    Try
                        For i As Integer = 45 To 49
                            If i = 45 Then
                                If Panel40.Enabled = True Then
                                    If Me.opRespuestaSi40.Checked = True Then
                                        strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                               objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                               dtdatos.Rows(i).Item("id").ToString, Me.opRespuestaSi40.Tag, "",
                                                                               0, "", objGeneral.Login, intopcion)
                                    Else
                                        strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                 objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                 dtdatos.Rows(i).Item("id").ToString, Me.opRespuestaNo40.Tag, "",
                                                 0, "", objGeneral.Login, intopcion)
                                    End If
                                End If
                            End If
                            If i = 46 Then
                                If Panel41.Enabled = True Then
                                    If Me.opRespuestaSi41.Checked = True Then
                                        strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                               objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                               dtdatos.Rows(i).Item("id").ToString, Me.opRespuestaSi41.Tag, "",
                                                                               0, "", objGeneral.Login, intopcion)
                                    Else
                                        strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                 objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                 dtdatos.Rows(i).Item("id").ToString, Me.opRespuestaNo41.Tag, "",
                                                 0, "", objGeneral.Login, intopcion)
                                    End If
                                End If
                            End If
                            If i = 47 Then
                                If Panel42.Enabled = True Then
                                    If Me.opRespuestaSi42.Checked = True Then
                                        strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                               objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                               dtdatos.Rows(i).Item("id").ToString, Me.opRespuestaSi42.Tag, "",
                                                                               0, "", objGeneral.Login, intopcion)
                                    Else
                                        strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                 objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                 dtdatos.Rows(i).Item("id").ToString, Me.opRespuestaNo42.Tag, "",
                                                 0, "", objGeneral.Login, intopcion)
                                    End If
                                End If
                            End If
                            If i = 48 Then
                                If Panel43.Enabled = True Then
                                    If Me.opRespuestaSi43.Checked = True Then
                                        strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                               objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                               dtdatos.Rows(i).Item("id").ToString, Me.opRespuestaSi43.Tag, "",
                                                                               0, "", objGeneral.Login, intopcion)
                                    Else
                                        strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                 objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                 dtdatos.Rows(i).Item("id").ToString, Me.opRespuestaNo43.Tag, "",
                                                 0, "", objGeneral.Login, intopcion)
                                    End If
                                End If
                            End If
                            If i = 49 Then
                                If Me.lblResultadoCam.Text <> "" Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.lblResultadoCam.Tag,
                                                                           Me.lblResultadoCam.Text, 0, "", objGeneral.Login, intopcion)
                                End If
                            End If
                        Next
                        strRespuesta = "se grabo la escala de CAM exitosamente "
                        ''' MsgBox("se grabo la escala de CAM exitosamente ", MsgBoxStyle.Information)
                    Catch ex As Exception
                        strRespuesta = "Error al guardar escala de CAM. "
                        '''MsgBox("Error al guardar escala de CAM. " & ex.Message, MsgBoxStyle.Information)
                    End Try

                Case 9 'graba en la tabla HC_Cp_Escala_MDAS
                    Try
                        For i As Integer = 50 To 60
                            If i = 50 Then
                                If Len(Me.Label44.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label44.Text, "",
                                                                           Me.Puntaje44.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 51 Then
                                If Len(Me.Label45.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label45.Text, "",
                                                                           Me.Puntaje45.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 52 Then
                                If Len(Me.Label46.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label46.Text, "",
                                                                           Me.Puntaje46.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 53 Then
                                If Len(Me.Label47.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label47.Text, "",
                                                                           Me.Puntaje47.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 54 Then
                                If Len(Me.Label48.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label48.Text, "",
                                                                           Me.Puntaje48.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 55 Then
                                If Len(Me.Label49.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label49.Text, "",
                                                                           Me.Puntaje49.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 56 Then
                                If Len(Me.Label50.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label50.Text, "",
                                                                           Me.Puntaje50.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 57 Then
                                If Len(Me.Label51.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label51.Text, "",
                                                                           Me.Puntaje51.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 58 Then
                                If Len(Me.Label52.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label52.Text, "",
                                                                           Me.Puntaje52.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 59 Then
                                If Len(Me.Label53.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label53.Text, "",
                                                                           Me.Puntaje53.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 60 Then
                                tmptotalpuntaje = Int(Me.Puntaje44.Text) + Int(Me.Puntaje45.Text) + Int(Me.Puntaje46.Text) + Int(Me.Puntaje47.Text) + Int(Me.Puntaje48.Text) + Int(Me.Puntaje49.Text) + Int(Me.Puntaje50.Text) + +Int(Me.Puntaje51.Text) + Int(Me.Puntaje52.Text) + Int(Me.Puntaje53.Text)
                                If (tmptotalpuntaje >= 0) Then

                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.lblResultadoMdas.Tag,
                                                                           Me.lblResultadoMdas.Text, tmptotalpuntaje, "", objGeneral.Login, intopcion)
                                End If
                            End If
                        Next
                        strRespuesta = "se grabo la escala de MDAS exitosamente "
                        '''MsgBox("se grabo la escala de MDAS exitosamente ", MsgBoxStyle.Information)
                    Catch ex As Exception
                        strRespuesta = "Error al guardar escala de MDAS. "
                        '''MsgBox("Error al guardar escala de MDAS. " & ex.Message, MsgBoxStyle.Information)
                    End Try

                Case 10 'graba en la tabla HC_Cp_Escala_MOCCA
                    Try
                        For i As Integer = 61 To 61
                            If i = 61 Then
                                If Len(Me.txtRespuesta54.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.txtRespuesta54.Tag,
                                                                           Me.txtRespuesta54.Text, 0, "", objGeneral.Login, intopcion)
                                End If
                            End If
                        Next
                        strRespuesta = "se grabo la escala de MOCCA exitosamente "
                        '''MsgBox("se grabo la escala de MOCCA exitosamente ", MsgBoxStyle.Information)
                    Catch ex As Exception
                        strRespuesta = "Error al guardar escala de MOCCA. "
                        '' MsgBox("Error al guardar escala de MOCCA. " & ex.Message, MsgBoxStyle.Information)
                    End Try

                Case 11 'graba en la tabla HC_Cp_Escala_ZARIT
                    Try
                        For i As Integer = 62 To 84
                            If i = 62 Then
                                If Len(Me.Label55.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label55.Text, "",
                                                                           Me.Puntaje55.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 63 Then
                                If Len(Me.Label56.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label56.Text, "",
                                                                           Me.Puntaje56.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 64 Then
                                If Len(Me.Label57.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label57.Text, "",
                                                                           Me.Puntaje57.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 65 Then
                                If Len(Me.Label58.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label58.Text, "",
                                                                           Me.Puntaje58.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 66 Then
                                If Len(Me.Label59.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label59.Text, "",
                                                                           Me.Puntaje59.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 67 Then
                                If Len(Me.Label60.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label60.Text, "",
                                                                           Me.Puntaje60.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 68 Then
                                If Len(Me.Label61.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label61.Text, "",
                                                                           Me.Puntaje61.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 69 Then
                                If Len(Me.Label62.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label62.Text, "",
                                                                           Me.Puntaje62.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 70 Then
                                If Len(Me.Label63.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label63.Text, "",
                                                                           Me.Puntaje63.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 71 Then
                                If Len(Me.Label64.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label64.Text, "",
                                                                           Me.Puntaje64.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 72 Then
                                If Len(Me.Label65.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label65.Text, "",
                                                                           Me.Puntaje65.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 73 Then
                                If Len(Me.Label66.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label66.Text, "",
                                                                           Me.Puntaje66.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 74 Then
                                If Len(Me.Label67.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label67.Text, "",
                                                                           Me.Puntaje67.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 75 Then
                                If Len(Me.Label68.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label68.Text, "",
                                                                           Me.Puntaje68.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 76 Then
                                If Len(Me.Label69.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label69.Text, "",
                                                                           Me.Puntaje69.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 77 Then
                                If Len(Me.Label70.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label70.Text, "",
                                                                           Me.Puntaje70.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 78 Then
                                If Len(Me.Label71.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label71.Text, "",
                                                                           Me.Puntaje71.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 79 Then
                                If Len(Me.Label72.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label72.Text, "",
                                                                           Me.Puntaje72.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 80 Then
                                If Len(Me.Label73.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label73.Text, "",
                                                                           Me.Puntaje73.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 81 Then
                                If Len(Me.Label74.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label74.Text, "",
                                                                           Me.Puntaje74.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 82 Then
                                If Len(Me.Label75.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label75.Text, "",
                                                                           Me.Puntaje75.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 83 Then
                                If Len(Me.Label76.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label76.Text, "",
                                                                           Me.Puntaje76.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 84 Then
                                tmptotalpuntaje = Int(Me.Puntaje55.Text) + Int(Me.Puntaje56.Text) + Int(Me.Puntaje57.Text) + Int(Me.Puntaje58.Text) + Int(Me.Puntaje59.Text) _
                                                      + Int(Me.Puntaje60.Text) + Int(Me.Puntaje61.Text) + +Int(Me.Puntaje62.Text) + Int(Me.Puntaje63.Text) + Int(Me.Puntaje64.Text) _
                                                      + Int(Me.Puntaje65.Text) + Int(Me.Puntaje66.Text) + +Int(Me.Puntaje67.Text) + Int(Me.Puntaje68.Text) + Int(Me.Puntaje69.Text) _
                                                      + Int(Me.Puntaje70.Text) + Int(Me.Puntaje71.Text) + +Int(Me.Puntaje72.Text) + Int(Me.Puntaje73.Text) + Int(Me.Puntaje74.Text) _
                                                      + Int(Me.Puntaje75.Text) + Int(Me.Puntaje76.Text)
                                If (tmptotalpuntaje >= 0) Then

                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.lblResultadoZarit.Tag,
                                                                           Me.lblResultadoZarit.Text, tmptotalpuntaje, "", objGeneral.Login, intopcion)
                                End If
                            End If
                        Next
                        strRespuesta = "se grabo la escala de Zarit exitosamente "
                        ''MsgBox("se grabo la escala de Zarit exitosamente ", MsgBoxStyle.Information)
                    Catch ex As Exception
                        strRespuesta = "Error al guardar escala de Zarit. "
                        'MsgBox("Error al guardar escala de Zarit. " & ex.Message, MsgBoxStyle.Information)
                    End Try

                Case 12 'graba en la tabla HC_Cp_Escala_HAD
                    Try
                        For i As Integer = 85 To 100
                            If i = 85 Then
                                If Len(Me.Label77.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label77.Text, "",
                                                                           Me.Puntaje77.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 86 Then
                                If Len(Me.Label78.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label78.Text, "",
                                                                           Me.Puntaje78.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 87 Then
                                If Len(Me.Label79.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label79.Text, "",
                                                                           Me.Puntaje79.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 88 Then
                                If Len(Me.Label80.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label80.Text, "",
                                                                           Me.Puntaje80.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 89 Then
                                If Len(Me.Label81.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label81.Text, "",
                                                                           Me.Puntaje81.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 90 Then
                                If Len(Me.Label82.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label82.Text, "",
                                                                           Me.Puntaje82.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 91 Then
                                If Len(Me.Label83.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label83.Text, "",
                                                                           Me.Puntaje83.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 92 Then
                                If Len(Me.Label84.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label84.Text, "",
                                                                           Me.Puntaje84.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 93 Then
                                If Len(Me.Label85.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label85.Text, "",
                                                                           Me.Puntaje85.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 94 Then
                                If Len(Me.Label86.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label86.Text, "",
                                                                           Me.Puntaje86.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 95 Then
                                If Len(Me.Label87.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label87.Text, "",
                                                                           Me.Puntaje87.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 96 Then
                                If Len(Me.Label88.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label88.Text, "",
                                                                           Me.Puntaje88.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 97 Then
                                If Len(Me.Label89.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label89.Text, "",
                                                                           Me.Puntaje89.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 98 Then
                                If Len(Me.Label90.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label90.Text, "",
                                                                           Me.Puntaje90.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 99 Then
                                tmptotalpuntaje = Int(Me.Puntaje78.Text) + Int(Me.Puntaje80.Text) + Int(Me.Puntaje82.Text) + Int(Me.Puntaje84.Text) + Int(Me.Puntaje86.Text) _
                                                    + Int(Me.Puntaje88.Text) + Int(Me.Puntaje90.Text)
                                If (tmptotalpuntaje >= 0) Then

                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.lblResultadoHADDepresion.Tag,
                                                                           Me.lblResultadoHADDepresion.Text, tmptotalpuntaje, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 100 Then
                                tmptotalpuntaje = Int(Me.Puntaje77.Text) + Int(Me.Puntaje79.Text) + Int(Me.Puntaje81.Text) + Int(Me.Puntaje83.Text) + Int(Me.Puntaje85.Text) _
                                                    + Int(Me.Puntaje87.Text) + Int(Me.Puntaje89.Text)
                                If (tmptotalpuntaje >= 0) Then

                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.lblResultadoHADAnsiedad.Tag,
                                                                           Me.lblResultadoHADAnsiedad.Text, tmptotalpuntaje, "", objGeneral.Login, intopcion)
                                End If
                            End If
                        Next
                        strRespuesta = "se grabo la escala de HAD exitosamente "
                        ''MsgBox("se grabo la escala de HAD exitosamente ", MsgBoxStyle.Information)
                    Catch ex As Exception
                        strRespuesta = "Error al guardar escala de HAD. "
                        '''MsgBox("Error al guardar escala de HAD. " & ex.Message, MsgBoxStyle.Information)
                    End Try

                Case 13 'graba en la tabla HC_Cp_Escala_PPS
                    Try
                        For i As Integer = 101 To 102
                            If i = 101 Then
                                If Len(Me.Label91.Text) > 0 Then
                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.Label91.Text, "",
                                                                           Me.Puntaje91.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                            If i = 102 Then
                                If (Len(Me.Label91.Text) > 0) Then

                                    strMensaje = objEscalas.GuardarEscalas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                           objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                           dtdatos.Rows(i).Item("id").ToString, Me.lblResultadoPPS.Tag,
                                                                           Me.lblResultadoPPS.Text, Me.Puntaje91.Text, "", objGeneral.Login, intopcion)
                                End If
                            End If
                        Next
                        strRespuesta = "se grabo la escala de PPS exitosamente "
                        '''MsgBox("se grabo la escala de PPS exitosamente ", MsgBoxStyle.Information)
                    Catch ex As Exception
                        strRespuesta = "Error al guardar escala de PPS. "
                        ''MsgBox("Error al guardar escala de PPS. " & ex.Message, MsgBoxStyle.Information)
                    End Try
            End Select

            GuardarEscalas = strRespuesta

        Catch ex As Exception
            MsgBox("Error al guardar Examenes de Evaluación " & ex.Message)
            Return False
        End Try


    End Function

    Private Sub CargarArhivo()
        'Dim sLine As String = ""
        'Dim arrText As New ArrayList()
        'Dim myStream As Stream = Nothing
        'Dim openFile As New OpenFileDialog
        'Dim objreader As StreamReader
        'Dim strRuta As String = ""

        'openFile.InitialDirectory = "c:\"
        'openFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        'openFile.FilterIndex = 2
        'openFile.RestoreDirectory = True

        'If openFile.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
        '    Try
        '        myStream = openFile.OpenFile()

        '        If (myStream IsNot Nothing) Then
        '            strRuta = openFile.FileName
        '        Else
        '            MsgBox("Error con el archivo seleccionado")
        '        End If


        '        objreader = New StreamReader(strRuta)

        '        Do
        '            sLine = objReader.ReadLine()
        '            If Not sLine Is Nothing Then
        '                arrText.Add(sLine)
        '            End If
        '        Loop Until sLine Is Nothing
        '        objreader.Close()

        '        For Each sLine In arrText
        '            If (Len(txtDescIntervencion.Text) + Len(sLine)) < 4000 Then
        '                txtDescIntervencion.Text += sLine
        '            End If

        '        Next
        '        'Console.ReadLine()

        '    Catch Ex As Exception
        '        MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
        '    Finally
        '        ' Check this again, since we need to make sure we didn't throw an exception on open.
        '        If (myStream IsNot Nothing) Then
        '            myStream.Close()
        '        End If
        '    End Try
        'End If
    End Sub
    ''Inicializa controles a su valor original
    Private Sub InicializarControlesOtrasHerramientasEvaluacion()
        grpOASIS.Location = New Point(171, 58)
        grpOASIS.Refresh()
        ''chkOASIS.Checked = False
        grpODSIS.Location = New Point(171, 405)
        grpODSIS.Refresh()
        ''chkODSIS.Checked = False
        grpODSIS.Location = New Point(171, 405)
        grpODSIS.Refresh()
        ''chkEscaladebarthel.Checked = False
        grpBarthel.Location = New Point(171, 691)
        grpBarthel.Refresh()
        ''chkRamsay.Checked = False
        grpRAMSAY.Location = New Point(171, 1076)
        grpRAMSAY.Refresh()
        ''chkCAM.Checked = False
        grpCam.Location = New Point(171, 1178)
        grpCam.Refresh()
        ''chkMdas.Checked = False
        grpMdas.Location = New Point(171, 1426)
        grpMdas.Refresh()
        '''chkEscalaMocca.Checked = False
        grpMocca.Location = New Point(171, 1932)
        grpMocca.Refresh()
        ''chkTestdezarit.Checked = False
        grpZarit.Location = New Point(171, 2137)
        grpZarit.Refresh()
        ''chkHAD.Checked = False
        grpHAD.Location = New Point(171, 2906)
        grpHAD.Refresh()
    End Sub

    Private Sub InicializarControlesOtrasHerramientasEvaluacionObjetos()
        Dim objPanelOtrasHerramientasEvaluacion As Panel
        Dim ctlControlTexto As TextBoxConFormato
        Dim ctlControlCombo As ComboBusqueda
        Dim ctlComboDatos As ComboBox
        Dim ctlTextoDatos As TextBox
        Dim ctlLabelDatos As Label
        Dim ctlPanelDatos As Panel
        Dim intControl As Integer
        objPanelOtrasHerramientasEvaluacion = Me.ParentForm.Controls.Find("pnlOtrasHerramientasdeevaluacion", True)(0)
        For i As Integer = 0 To objPanelOtrasHerramientasEvaluacion.Controls.Count - 1
            If TypeOf (objPanelOtrasHerramientasEvaluacion.Controls(i)) Is GroupBox Then ''Si son GroupBox
                Dim ctlContenedorExistente As GroupBox = objPanelOtrasHerramientasEvaluacion.Controls(i) ''El GroupBox Existente
                ctlContenedorExistente.Enabled = False
                ctlContenedorExistente.Visible = False
                For intControl = 0 To ctlContenedorExistente.Controls.Count - 1
                    If TypeOf (ctlContenedorExistente.Controls(intControl)) Is TextBoxConFormato Then
                        ctlControlTexto = ctlContenedorExistente.Controls(intControl)
                        ctlControlTexto.Text = ""
                    End If
                    If TypeOf (ctlContenedorExistente.Controls(intControl)) Is ComboBusqueda Then
                        ctlControlCombo = ctlContenedorExistente.Controls(intControl)
                        ctlControlCombo.SelectedIndex = -1
                        ctlControlCombo.Text = ""
                    End If
                    If TypeOf (ctlContenedorExistente.Controls(intControl)) Is ComboBox Then
                        ctlComboDatos = ctlContenedorExistente.Controls(intControl)
                        ctlComboDatos.SelectedIndex = -1
                        ctlComboDatos.Text = ""
                    End If
                    If TypeOf (ctlContenedorExistente.Controls(intControl)) Is TextBox Then
                        ctlTextoDatos = ctlContenedorExistente.Controls(intControl)
                        ctlTextoDatos.Text = ""
                    End If
                    If TypeOf (ctlContenedorExistente.Controls(intControl)) Is Label Then
                        ctlLabelDatos = ctlContenedorExistente.Controls(intControl)
                        If UCase(ctlLabelDatos.Name).Contains("RESULTADO") Then
                            ctlLabelDatos.Text = "0"
                        End If
                    End If
                    If TypeOf (ctlContenedorExistente.Controls(intControl)) Is Panel Then
                        ctlPanelDatos = ctlContenedorExistente.Controls(intControl)
                        For Each control As Control In ctlPanelDatos.Controls
                            If TypeOf (control) Is RadioButton Then
                                CType(control, RadioButton).Checked = False
                            End If
                        Next
                    End If
                Next
            End If
        Next

    End Sub

    Private Function LimpiardatosEscalas(ByVal opcion As Integer) As Boolean

        InactivarGroupBoxCheck() ''WACHV, INICIALIZAR LOS CONTROLES

        If opcion = 1 Then 'Oasis
            Me.cboRespuesta1.SelectedValue = 0
            Me.cboRespuesta2.SelectedValue = 0
            Me.cboRespuesta3.SelectedValue = 0
            Me.cboRespuesta4.SelectedValue = 0
            Me.cboRespuesta5.SelectedValue = 0

            Me.Puntaje1.Text = "0"
            Me.Puntaje2.Text = "0"
            Me.Puntaje3.Text = "0"
            Me.Puntaje4.Text = "0"
            Me.Puntaje5.Text = "0"

            Me.Label1.Text = ""
            Me.Label2.Text = ""
            Me.Label3.Text = ""
            Me.Label4.Text = ""
            Me.Label5.Text = ""

            Me.lblResultadoOasis.Text = "0/20"
        End If
        If opcion = 2 Then 'Odsis
            Me.cboRespuesta6.SelectedValue = 0
            Me.cboRespuesta7.SelectedValue = 0
            Me.cboRespuesta8.SelectedValue = 0
            Me.cboRespuesta9.SelectedValue = 0
            Me.cboRespuesta10.SelectedValue = 0

            Me.Puntaje6.Text = "0"
            Me.Puntaje7.Text = "0"
            Me.Puntaje7.Text = "0"
            Me.Puntaje9.Text = "0"
            Me.Puntaje10.Text = "0"

            Me.Label6.Text = ""
            Me.Label7.Text = ""
            Me.Label8.Text = ""
            Me.Label9.Text = ""
            Me.Label10.Text = ""

            Me.lblResultadoOdsis.Text = "0/20"
        End If

        If opcion = 3 Then 'ESAS
            Me.txtRespuesta11.Text = ""
            Me.txtRespuesta12.Text = ""
            Me.txtRespuesta13.Text = ""
            Me.txtRespuesta14.Text = ""
            Me.txtRespuesta15.Text = ""
            Me.txtRespuesta16.Text = ""
            Me.txtRespuesta17.Text = ""
            Me.txtRespuesta18.Text = ""
            Me.txtRespuesta19.Text = ""
            Me.txtRespuesta20.Text = ""
            Me.txtRespuesta21.Text = ""
        End If

        If opcion = 4 Then 'ECAF
            Me.cboRespuesta22.SelectedValue = 0
            Me.cboRespuesta23.SelectedValue = 0
            Me.cboRespuesta24.SelectedValue = 0
            Me.cboRespuesta25.SelectedValue = 0
            Me.cboRespuesta26.SelectedValue = 0
            Me.cboRespuesta27.SelectedValue = 0

            Me.Puntaje22.Text = "0"
            Me.Puntaje23.Text = "0"
            Me.Puntaje24.Text = "0"
            Me.Puntaje25.Text = "0"
            Me.Puntaje26.Text = "0"
            Me.Puntaje27.Text = "0"

            Me.Label22.Text = ""
            Me.Label23.Text = ""
            Me.Label24.Text = ""
            Me.Label25.Text = ""
            Me.Label26.Text = ""
            Me.Label27.Text = ""

            Me.lblResultadoEcaf.Text = "0/24"
        End If

        If opcion = 5 Then 'IK
            Me.cboRespuesta28.SelectedValue = 0
            Me.Puntaje28.Text = "0"

            Me.Label28.Text = ""

            Me.lblResultadoIK.Text = "0"
        End If

        If opcion = 6 Then 'BARTHEL
            Me.cboRespuesta29.SelectedValue = 0
            Me.cboRespuesta30.SelectedValue = 0
            Me.cboRespuesta31.SelectedValue = 0
            Me.cboRespuesta32.SelectedValue = 0
            Me.cboRespuesta33.SelectedValue = 0
            Me.cboRespuesta34.SelectedValue = 0
            Me.cboRespuesta35.SelectedValue = 0
            Me.cboRespuesta36.SelectedValue = 0
            Me.cboRespuesta37.SelectedValue = 0
            Me.cboRespuesta38.SelectedValue = 0

            Me.Puntaje29.Text = "0"
            Me.Puntaje30.Text = "0"
            Me.Puntaje31.Text = "0"
            Me.Puntaje32.Text = "0"
            Me.Puntaje33.Text = "0"
            Me.Puntaje34.Text = "0"
            Me.Puntaje35.Text = "0"
            Me.Puntaje36.Text = "0"
            Me.Puntaje37.Text = "0"
            Me.Puntaje38.Text = "0"

            Me.Label29.Text = ""
            Me.Label30.Text = ""
            Me.Label31.Text = ""
            Me.Label32.Text = ""
            Me.Label33.Text = ""
            Me.Label34.Text = ""
            Me.Label35.Text = ""
            Me.Label36.Text = ""
            Me.Label37.Text = ""
            Me.Label38.Text = ""

            Me.lblResultadoBarthel.Text = "0/100"
        End If
        If opcion = 7 Then 'RAMSAY
            Me.cboRespuesta39.SelectedValue = 0

            Me.Puntaje39.Text = "0"

            Me.Label39.Text = ""

            Me.lblResultadoRamsay.Text = "0"
        End If

        If opcion = 8 Then 'CAM
            Me.opRespuestaSi40.Checked = False
            Me.opRespuestaNo40.Checked = False
            Me.opRespuestaSi41.Checked = False
            Me.opRespuestaNo41.Checked = False
            Me.opRespuestaSi42.Checked = False
            Me.opRespuestaNo42.Checked = False
            Me.opRespuestaSi43.Checked = False
            Me.opRespuestaNo43.Checked = False
            Me.Panel40.Enabled = True
            Me.Panel41.Enabled = True
            Me.Panel42.Enabled = True
            Me.Panel43.Enabled = True

            Me.lblResultadoCam.Text = ""
        End If
        If opcion = 9 Then 'MDAS
            Me.cboRespuesta44.SelectedValue = 0
            Me.cboRespuesta45.SelectedValue = 0
            Me.cboRespuesta46.SelectedValue = 0
            Me.cboRespuesta47.SelectedValue = 0
            Me.cboRespuesta48.SelectedValue = 0
            Me.cboRespuesta49.SelectedValue = 0
            Me.cboRespuesta50.SelectedValue = 0
            Me.cboRespuesta51.SelectedValue = 0
            Me.cboRespuesta52.SelectedValue = 0
            Me.cboRespuesta53.SelectedValue = 0

            Me.Puntaje44.Text = "0"
            Me.Puntaje45.Text = "0"
            Me.Puntaje46.Text = "0"
            Me.Puntaje47.Text = "0"
            Me.Puntaje48.Text = "0"
            Me.Puntaje49.Text = "0"
            Me.Puntaje50.Text = "0"
            Me.Puntaje51.Text = "0"
            Me.Puntaje52.Text = "0"
            Me.Puntaje53.Text = "0"

            Me.Label44.Text = ""
            Me.Label45.Text = ""
            Me.Label46.Text = ""
            Me.Label47.Text = ""
            Me.Label48.Text = ""
            Me.Label49.Text = ""
            Me.Label50.Text = ""
            Me.Label51.Text = ""
            Me.Label52.Text = ""
            Me.Label53.Text = ""

            Me.lblResultadoMdas.Text = ""
        End If

        If opcion = 10 Then 'MOCCA
            Me.txtRespuesta54.Text = ""
        End If
        If opcion = 11 Then 'Zarit            
            Me.cboRespuesta55.SelectedValue = 0
            Me.cboRespuesta56.SelectedValue = 0
            Me.cboRespuesta57.SelectedValue = 0
            Me.cboRespuesta58.SelectedValue = 0
            Me.cboRespuesta59.SelectedValue = 0
            Me.cboRespuesta60.SelectedValue = 0
            Me.cboRespuesta61.SelectedValue = 0
            Me.cboRespuesta62.SelectedValue = 0
            Me.cboRespuesta63.SelectedValue = 0
            Me.cboRespuesta64.SelectedValue = 0
            Me.cboRespuesta65.SelectedValue = 0
            Me.cboRespuesta66.SelectedValue = 0
            Me.cboRespuesta67.SelectedValue = 0
            Me.cboRespuesta68.SelectedValue = 0
            Me.cboRespuesta69.SelectedValue = 0
            Me.cboRespuesta70.SelectedValue = 0
            Me.cboRespuesta71.SelectedValue = 0
            Me.cboRespuesta72.SelectedValue = 0
            Me.cboRespuesta73.SelectedValue = 0
            Me.cboRespuesta74.SelectedValue = 0
            Me.cboRespuesta75.SelectedValue = 0
            Me.cboRespuesta76.SelectedValue = 0

            Me.Puntaje55.Text = "0"
            Me.Puntaje56.Text = "0"
            Me.Puntaje57.Text = "0"
            Me.Puntaje58.Text = "0"
            Me.Puntaje59.Text = "0"
            Me.Puntaje60.Text = "0"
            Me.Puntaje61.Text = "0"
            Me.Puntaje62.Text = "0"
            Me.Puntaje63.Text = "0"
            Me.Puntaje64.Text = "0"
            Me.Puntaje65.Text = "0"
            Me.Puntaje66.Text = "0"
            Me.Puntaje67.Text = "0"
            Me.Puntaje68.Text = "0"
            Me.Puntaje69.Text = "0"
            Me.Puntaje70.Text = "0"
            Me.Puntaje71.Text = "0"
            Me.Puntaje72.Text = "0"
            Me.Puntaje73.Text = "0"
            Me.Puntaje74.Text = "0"
            Me.Puntaje75.Text = "0"
            Me.Puntaje76.Text = "0"

            Me.Label55.Text = ""
            Me.Label56.Text = ""
            Me.Label57.Text = ""
            Me.Label58.Text = ""
            Me.Label59.Text = ""
            Me.Label60.Text = ""
            Me.Label61.Text = ""
            Me.Label62.Text = ""
            Me.Label63.Text = ""
            Me.Label64.Text = ""
            Me.Label65.Text = ""
            Me.Label66.Text = ""
            Me.Label67.Text = ""
            Me.Label68.Text = ""
            Me.Label69.Text = ""
            Me.Label70.Text = ""
            Me.Label71.Text = ""
            Me.Label72.Text = ""
            Me.Label73.Text = ""
            Me.Label74.Text = ""
            Me.Label75.Text = ""
            Me.Label76.Text = ""

            Me.lblResultadoZarit.Text = ""
        End If
        If opcion = 12 Then 'HAD
            Me.cboRespuesta77.SelectedValue = 0
            Me.cboRespuesta78.SelectedValue = 0
            Me.cboRespuesta79.SelectedValue = 0
            Me.cboRespuesta80.SelectedValue = 0
            Me.cboRespuesta81.SelectedValue = 0
            Me.cboRespuesta82.SelectedValue = 0
            Me.cboRespuesta83.SelectedValue = 0
            Me.cboRespuesta84.SelectedValue = 0
            Me.cboRespuesta85.SelectedValue = 0
            Me.cboRespuesta86.SelectedValue = 0
            Me.cboRespuesta87.SelectedValue = 0
            Me.cboRespuesta88.SelectedValue = 0
            Me.cboRespuesta89.SelectedValue = 0
            Me.cboRespuesta90.SelectedValue = 0

            Me.Puntaje77.Text = "0"
            Me.Puntaje78.Text = "0"
            Me.Puntaje79.Text = "0"
            Me.Puntaje80.Text = "0"
            Me.Puntaje81.Text = "0"
            Me.Puntaje82.Text = "0"
            Me.Puntaje83.Text = "0"
            Me.Puntaje84.Text = "0"
            Me.Puntaje85.Text = "0"
            Me.Puntaje86.Text = "0"
            Me.Puntaje87.Text = "0"
            Me.Puntaje88.Text = "0"
            Me.Puntaje89.Text = "0"
            Me.Puntaje90.Text = "0"

            Me.Label77.Text = ""
            Me.Label78.Text = ""
            Me.Label79.Text = ""
            Me.Label80.Text = ""
            Me.Label81.Text = ""
            Me.Label82.Text = ""
            Me.Label83.Text = ""
            Me.Label84.Text = ""
            Me.Label85.Text = ""
            Me.Label86.Text = ""
            Me.Label87.Text = ""
            Me.Label88.Text = ""
            Me.Label89.Text = ""
            Me.Label90.Text = ""

            Me.lblResultadoHADAnsiedad.Text = ""
            Me.lblResultadoHADDepresion.Text = ""
        End If
        If opcion = 13 Then 'PPS
            Me.cboRespuesta91.SelectedValue = 0

            Me.Puntaje91.Text = "0"

            Me.Label91.Text = ""

            Me.lblResultadoPPS.Text = "0"
        End If

        w = 789
        h = 18
        x = 5
        y = 4130

        GrupoLocation.X = x
        GrupoLocation.Y = y

        GrupoSize.Width = w
        GrupoSize.Height = h

        Label40.Location = New Point(12, 4090)

        Me.dtgHistoEscalas_Barthel.DataSource = Nothing
        Me.dtgHistoEscalas_CAM.DataSource = Nothing
        Me.dtgHistoEscalas_ECAF.DataSource = Nothing
        Me.dtgHistoEscalas_ESAS.DataSource = Nothing
        Me.dtgHistoEscalas_HAD.DataSource = Nothing
        Me.dtgHistoEscalas_IK.DataSource = Nothing
        Me.dtgHistoEscalas_MDAS.DataSource = Nothing
        Me.dtgHistoEscalas_Mocca.DataSource = Nothing
        Me.dtgHistoEscalas_OASIS.DataSource = Nothing
        Me.dtgHistoEscalas_ODSIS.DataSource = Nothing
        Me.dtgHistoEscalas_PPS.DataSource = Nothing
        Me.dtgHistoEscalas_Ramsay.DataSource = Nothing
        Me.dtgHistoEscalas_Zarit.DataSource = Nothing

        Me.grpHistoESAS.Size = GrupoSize
        GrupoLocation.Y = y
        Me.grpHistoESAS.Location = GrupoLocation

        Me.grpHistoIK.Size = GrupoSize
        y = y + h + 1
        GrupoLocation.Y = y
        Me.grpHistoIK.Location = GrupoLocation

        Me.grpHistoPPS.Size = GrupoSize
        y = y + h + 1
        GrupoLocation.Y = y
        Me.grpHistoPPS.Location = GrupoLocation

        Me.grpHistoOASIS.Size = GrupoSize
        y = y + h + 1
        GrupoLocation.Y = y
        Me.grpHistoOASIS.Location = GrupoLocation

        Me.grpHistoODSIS.Size = GrupoSize
        y = y + h + 1
        GrupoLocation.Y = y
        Me.grpHistoODSIS.Location = GrupoLocation

        Me.grpHistoECAF.Size = GrupoSize
        y = y + h + 1
        GrupoLocation.Y = y
        Me.grpHistoECAF.Location = GrupoLocation

        Me.grpHistoBarthel.Size = GrupoSize
        y = y + h + 1
        GrupoLocation.Y = y
        Me.grpHistoBarthel.Location = GrupoLocation

        Me.grpHistoRamsay.Size = GrupoSize
        y = y + h + 1
        GrupoLocation.Y = y
        Me.grpHistoRamsay.Location = GrupoLocation

        Me.grpHistoCAM.Size = GrupoSize
        y = y + h + 1
        GrupoLocation.Y = y
        Me.grpHistoCAM.Location = GrupoLocation

        Me.grpHistoMDAS.Size = GrupoSize
        y = y + h + 1
        GrupoLocation.Y = y
        Me.grpHistoMDAS.Location = GrupoLocation

        Me.grpHistoMocca.Size = GrupoSize
        y = y + h + 1
        GrupoLocation.Y = y
        Me.grpHistoMocca.Location = GrupoLocation

        Me.grpHistoZarit.Size = GrupoSize
        y = y + h + 1
        GrupoLocation.Y = y
        Me.grpHistoZarit.Location = GrupoLocation

        Me.grpHistoHAD.Size = GrupoSize
        y = y + h + 1
        GrupoLocation.Y = y
        Me.grpHistoHAD.Location = GrupoLocation
    End Function

    Private Function Validar_Escalas(ByVal opcion() As String, ByRef bvalidarEscala As Boolean) As String
        ''WACHV, Obligatoriedad de las escalas
        Dim strRespuestavalidacion As String = ""

        For iEscalaEvaluar As Integer = 0 To opcion.Length - 1
            If opcion(iEscalaEvaluar) <> "" Then ''Si el valor es diferente de cero (Ninguno)
                If opcion(iEscalaEvaluar) = "GRPESAS" Then
                    '    ''''WACHV,INICIO, 20SEPT2017,se Agrega obligatoriedad, al menos una
                    If (Len(Me.txtRespuesta11.Text) > 0) And (Len(Me.txtRespuesta12.Text) > 0) And (Len(Me.txtRespuesta13.Text) > 0) And
                       (Len(Me.txtRespuesta14.Text) > 0) And (Len(Me.txtRespuesta15.Text) > 0) And (Len(Me.txtRespuesta16.Text) > 0) And
                       (Len(Me.txtRespuesta17.Text) > 0) And (Len(Me.txtRespuesta18.Text) > 0) And (Len(Me.txtRespuesta19.Text) > 0) And
                       (Len(Me.txtRespuesta20.Text) > 0) And (Len(Me.txtRespuesta21.Text) > 0) Then
                        bvalidarEscala = True
                    Else
                        'MsgBox("Debe digitar todas las preguntas de la escala ESAS")
                        strRespuestavalidacion = "Debe digitar todas las preguntas de la escala ESAS"
                        bvalidarEscala = False
                    End If
                    '    ''''WACHV,FIN, 20SEPT2017,se Agrega obligatoriedad, al menos una
                End If
                If opcion(iEscalaEvaluar) = "GRPECAF" Then
                    If (Len(Me.cboRespuesta22.Text) > 0) And (Len(Me.cboRespuesta23.Text) > 0) And (Len(Me.cboRespuesta24.Text) > 0) And
                           (Len(Me.cboRespuesta25.Text) > 0) And (Len(Me.cboRespuesta26.Text) > 0) And (Len(Me.cboRespuesta27.Text) > 0) Then
                        bvalidarEscala = True
                    Else
                        'MsgBox("Debe digitar todas las preguntas de la escala ECAF")
                        strRespuestavalidacion = "Debe digitar todas las preguntas de la escala ECAF"
                        bvalidarEscala = False
                    End If
                End If
                If opcion(iEscalaEvaluar) = "NINGUNO" Then
                    strRespuestavalidacion = ""
                    bvalidarEscala = True
                End If
                ''Or opcion(iEscalaEvaluar) = "GRPECAF" Or opcion(iEscalaEvaluar) = "NINGUNO" Then  ''sECCION EVAL SINTOMAS
                If opcion(iEscalaEvaluar) = "GRPPPS" Then
                    If (Len(Me.cboRespuesta91.Text) > 0) Then
                        bvalidarEscala = True
                    Else
                        strRespuestavalidacion = "Debe digitar la pregunta de la escala PPS"
                        bvalidarEscala = False
                        'MsgBox("Debe digitar la preguntas de la escala PPS")
                    End If
                End If
                If opcion(iEscalaEvaluar) = "GRPIK" Then
                    If (Len(Me.cboRespuesta28.Text) > 0) Then
                        bvalidarEscala = True
                    Else
                        'MsgBox("Debe digitar la preguntas de la escala IK")
                        strRespuestavalidacion = "Debe digitar la pregunta de la escala IK"
                        bvalidarEscala = False
                    End If
                End If
                If opcion(iEscalaEvaluar) = "GRPOASIS" Then
                    If (Len(Me.cboRespuesta1.Text) > 0) And (Len(Me.cboRespuesta2.Text) > 0) And (Len(Me.cboRespuesta3.Text) > 0) And
                        (Len(Me.cboRespuesta4.Text) > 0) And (Len(Me.cboRespuesta5.Text) > 0) Then
                        bvalidarEscala = True
                    Else
                        strRespuestavalidacion = strRespuestavalidacion + "Debe digitar todas las preguntas de la escala OASIS" + Chr(13)
                        'MsgBox("Debe digitar todas las preguntas de la escala OASIS")
                        bvalidarEscala = False
                    End If
                End If
                If opcion(iEscalaEvaluar) = "GRPODSIS" Then
                    If (Len(Me.cboRespuesta6.Text) > 0) And (Len(Me.cboRespuesta7.Text) > 0) And (Len(Me.cboRespuesta8.Text) > 0) And
                       (Len(Me.cboRespuesta9.Text) > 0) And (Len(Me.cboRespuesta10.Text) > 0) Then
                        bvalidarEscala = True
                    Else
                        'MsgBox("Debe digitar todas las preguntas de la escala ODSIS")
                        strRespuestavalidacion = strRespuestavalidacion + "Debe digitar todas las preguntas de la escala ODSIS" + Chr(13)
                        bvalidarEscala = False
                    End If
                End If
                If opcion(iEscalaEvaluar) = "GRPBARTHEL" Then
                    If (Len(Me.cboRespuesta29.Text) > 0) And (Len(Me.cboRespuesta30.Text) > 0) And (Len(Me.cboRespuesta31.Text) > 0) And
                       (Len(Me.cboRespuesta32.Text) > 0) And (Len(Me.cboRespuesta33.Text) > 0) And (Len(Me.cboRespuesta34.Text) > 0) And
                       (Len(Me.cboRespuesta35.Text) > 0) And (Len(Me.cboRespuesta36.Text) > 0) And (Len(Me.cboRespuesta37.Text) > 0) And
                       (Len(Me.cboRespuesta38.Text) > 0) Then
                        bvalidarEscala = True
                    Else
                        strRespuestavalidacion = strRespuestavalidacion + "Debe digitar todas las preguntas de la escala BARTHELK" + Chr(13)
                        'MsgBox("Debe digitar todas las preguntas de la escala BARTHEL")
                        bvalidarEscala = False
                    End If
                End If
                If opcion(iEscalaEvaluar) = "GRPRAMSAY" Then
                    If (Len(Me.cboRespuesta39.Text) > 0) Then
                        bvalidarEscala = True
                    Else
                        strRespuestavalidacion = strRespuestavalidacion + "Debe digitar la preguntas de la escala RAMSAY" + Chr(13)
                        'MsgBox("Debe digitar la preguntas de la escala RAMSAY")
                        bvalidarEscala = False
                    End If
                End If
                If opcion(iEscalaEvaluar) = "GRPCAM" Then
                    '    ''''WACHV,INICIO, 20SEPT2017,se Agrega obligatoriedad
                    If bfncObligatoriedad(8) Then
                        bvalidarEscala = True
                    Else
                        strRespuestavalidacion = strRespuestavalidacion + "Debe digitar todas las preguntas de la escala CAM" + Chr(13)
                        'MsgBox("Debe digitar todas las preguntas de la escala CAM")
                        bValidarEscala = False
                    End If
                    '    ''''WACHV,FIN, 20SEPT2017,se Agrega obligatoriedad
                End If
                If opcion(iEscalaEvaluar) = "GRPMDAS" Then
                    If (Len(Me.cboRespuesta44.Text) > 0) And (Len(Me.cboRespuesta45.Text) > 0) And (Len(Me.cboRespuesta46.Text) > 0) And
                       (Len(Me.cboRespuesta47.Text) > 0) And (Len(Me.cboRespuesta48.Text) > 0) And (Len(Me.cboRespuesta48.Text) > 0) And
                       (Len(Me.cboRespuesta50.Text) > 0) And (Len(Me.cboRespuesta51.Text) > 0) And (Len(Me.cboRespuesta52.Text) > 0) And
                       (Len(Me.cboRespuesta53.Text) > 0) Then
                        bvalidarEscala = True
                    Else
                        strRespuestavalidacion = strRespuestavalidacion + "Debe digitar todas las preguntas de la escala MDAS" + Chr(13)
                        'MsgBox("Debe digitar todas las preguntas de la escala MDAS")
                        bvalidarEscala = False
                    End If
                End If
                If opcion(iEscalaEvaluar) = "GRPMOCCA" Then
                    If (Len(Me.txtRespuesta54.Text) > 0) Then
                        bvalidarEscala = True
                    Else
                        strRespuestavalidacion = strRespuestavalidacion + "Debe digitar la pregunta de la escala MOCCA" + Chr(13)
                        'MsgBox("Debe digitar la pregunta de la escala MOCCA")
                        bvalidarEscala = False
                    End If
                End If
                If opcion(iEscalaEvaluar) = "GRPZARIT" Then
                    If (Len(Me.cboRespuesta55.Text) > 0) And (Len(Me.cboRespuesta56.Text) > 0) And (Len(Me.cboRespuesta57.Text) > 0) And
                       (Len(Me.cboRespuesta58.Text) > 0) And (Len(Me.cboRespuesta59.Text) > 0) And (Len(Me.cboRespuesta60.Text) > 0) And
                       (Len(Me.cboRespuesta61.Text) > 0) And (Len(Me.cboRespuesta62.Text) > 0) And (Len(Me.cboRespuesta63.Text) > 0) And
                       (Len(Me.cboRespuesta64.Text) > 0) And (Len(Me.cboRespuesta65.Text) > 0) And (Len(Me.cboRespuesta66.Text) > 0) And
                       (Len(Me.cboRespuesta67.Text) > 0) And (Len(Me.cboRespuesta68.Text) > 0) And (Len(Me.cboRespuesta69.Text) > 0) And
                       (Len(Me.cboRespuesta70.Text) > 0) And (Len(Me.cboRespuesta71.Text) > 0) And (Len(Me.cboRespuesta72.Text) > 0) And
                       (Len(Me.cboRespuesta73.Text) > 0) And (Len(Me.cboRespuesta74.Text) > 0) And (Len(Me.cboRespuesta75.Text) > 0) And
                       (Len(Me.cboRespuesta76.Text) > 0) Then
                        bvalidarEscala = True
                    Else
                        strRespuestavalidacion = strRespuestavalidacion +  "Debe digitar todas las preguntas de la escala Zarit" + Chr(13)
                        'MsgBox("Debe digitar todas las preguntas de la escala Zarit")
                        bvalidarEscala = False
                    End If
                End If
                If opcion(iEscalaEvaluar) = "GRPHAD" Then
                    If (Len(Me.cboRespuesta77.Text) > 0) And (Len(Me.cboRespuesta79.Text) > 0) And (Len(Me.cboRespuesta81.Text) > 0) And
                       (Len(Me.cboRespuesta83.Text) > 0) And (Len(Me.cboRespuesta85.Text) > 0) And (Len(Me.cboRespuesta87.Text) > 0) And
                       (Len(Me.cboRespuesta89.Text) > 0) Then
                        bvalidarEscala = True
                    Else
                        strRespuestavalidacion = strRespuestavalidacion + "Debe digitar todas las preguntas de la escala HAD" + Chr(13)
                        'MsgBox("Debe digitar todas las preguntas de la escala HAD")
                        bvalidarEscala = False
                    End If

                    If (Len(Me.cboRespuesta78.Text) > 0) And (Len(Me.cboRespuesta80.Text) > 0) And (Len(Me.cboRespuesta82.Text) > 0) And
                       (Len(Me.cboRespuesta84.Text) > 0) And (Len(Me.cboRespuesta86.Text) > 0) And (Len(Me.cboRespuesta88.Text) > 0) And
                       (Len(Me.cboRespuesta90.Text) > 0) Then
                        bvalidarEscala = True
                    Else
                        strRespuestavalidacion = strRespuestavalidacion + "Debe digitar todas las preguntas de la escala HAD" + Chr(13)
                        'MsgBox("Debe digitar todas las preguntas de la escala HAD")
                        bvalidarEscala = False
                    End If
                End If

            End If
        Next

        'If opcion = 1 Then 'Oasis
        '    If (Len(Me.cboRespuesta1.Text) > 0) And (Len(Me.cboRespuesta2.Text) > 0) And (Len(Me.cboRespuesta3.Text) > 0) And
        '        (Len(Me.cboRespuesta4.Text) > 0) And (Len(Me.cboRespuesta5.Text) > 0) Then
        '        bValidarEscala = True
        '    Else
        '        strRespuestavalidacion = strRespuestavalidacion + "Debe digitar todas las preguntas de la escala OASIS" + Chr(13)
        '        'MsgBox("Debe digitar todas las preguntas de la escala OASIS")
        '        bValidarEscala = False
        '    End If
        'End If
        'If opcion = 2 Then 'Odsis
        '    If (Len(Me.cboRespuesta6.Text) > 0) And (Len(Me.cboRespuesta7.Text) > 0) And (Len(Me.cboRespuesta8.Text) > 0) And
        '       (Len(Me.cboRespuesta9.Text) > 0) And (Len(Me.cboRespuesta10.Text) > 0) Then
        '        bValidarEscala = True
        '    Else
        '        'MsgBox("Debe digitar todas las preguntas de la escala ODSIS")
        '        strRespuestavalidacion = strRespuestavalidacion + "Debe digitar todas las preguntas de la escala ODSIS" + Chr(13)
        '        bValidarEscala = False
        '    End If
        'End If

        'If opcion = 3 Then 'ESAS
        '    ''''WACHV,INICIO, 20SEPT2017,se Agrega obligatoriedad, al menos una
        '    If (Len(Me.txtRespuesta11.Text) > 0) And (Len(Me.txtRespuesta12.Text) > 0) And (Len(Me.txtRespuesta13.Text) > 0) And
        '       (Len(Me.txtRespuesta14.Text) > 0) And (Len(Me.txtRespuesta15.Text) > 0) And (Len(Me.txtRespuesta16.Text) > 0) And
        '       (Len(Me.txtRespuesta17.Text) > 0) And (Len(Me.txtRespuesta18.Text) > 0) And (Len(Me.txtRespuesta19.Text) > 0) And
        '       (Len(Me.txtRespuesta20.Text) > 0) And (Len(Me.txtRespuesta21.Text) > 0) Then
        '        bValidarEscala = True
        '    Else
        '        'MsgBox("Debe digitar todas las preguntas de la escala ESAS")
        '        strRespuestavalidacion = strRespuestavalidacion + "Debe digitar todas las preguntas de la escala ESAS" + Chr(13)
        '        bValidarEscala = False
        '    End If
        '    ''''WACHV,FIN, 20SEPT2017,se Agrega obligatoriedad, al menos una
        'End If

        'If opcion = 4 Then 'ECAF
        '    If (Len(Me.cboRespuesta22.Text) > 0) And (Len(Me.cboRespuesta23.Text) > 0) And (Len(Me.cboRespuesta24.Text) > 0) And
        '       (Len(Me.cboRespuesta25.Text) > 0) And (Len(Me.cboRespuesta26.Text) > 0) And (Len(Me.cboRespuesta27.Text) > 0) Then
        '        bValidarEscala = True
        '    Else
        '        'MsgBox("Debe digitar todas las preguntas de la escala ECAF")
        '        strRespuestavalidacion = strRespuestavalidacion + "Debe digitar todas las preguntas de la escala ECAF" + Chr(13)
        '        bValidarEscala = False
        '    End If
        'End If

        'If opcion = 5 Then 'IK            
        '    If (Len(Me.cboRespuesta28.Text) > 0) Then
        '        bValidarEscala = True
        '    Else
        '        'MsgBox("Debe digitar la preguntas de la escala IK")
        '        strRespuestavalidacion = strRespuestavalidacion + "Debe digitar la preguntas de la escala IK" + Chr(13)
        '        bValidarEscala = False
        '    End If
        'End If

        'If opcion = 6 Then 'BARTHEL
        '    If (Len(Me.cboRespuesta29.Text) > 0) And (Len(Me.cboRespuesta30.Text) > 0) And (Len(Me.cboRespuesta31.Text) > 0) And
        '       (Len(Me.cboRespuesta32.Text) > 0) And (Len(Me.cboRespuesta33.Text) > 0) And (Len(Me.cboRespuesta34.Text) > 0) And
        '       (Len(Me.cboRespuesta35.Text) > 0) And (Len(Me.cboRespuesta36.Text) > 0) And (Len(Me.cboRespuesta37.Text) > 0) And
        '       (Len(Me.cboRespuesta38.Text) > 0) Then
        '        bValidarEscala = True
        '    Else
        '        strRespuestavalidacion = strRespuestavalidacion + "Debe digitar todas las preguntas de la escala BARTHELK" + Chr(13)
        '        'MsgBox("Debe digitar todas las preguntas de la escala BARTHEL")
        '        bValidarEscala = False
        '    End If
        'End If
        'If opcion = 7 Then 'RAMSAY
        '    If (Len(Me.cboRespuesta39.Text) > 0) Then
        '        bValidarEscala = True
        '    Else
        '        strRespuestavalidacion = strRespuestavalidacion + "Debe digitar la preguntas de la escala RAMSAY" + Chr(13)
        '        'MsgBox("Debe digitar la preguntas de la escala RAMSAY")
        '        bValidarEscala = False
        '    End If
        'End If

        'If opcion = 8 Then 'CAM
        '    '''bValidarEscala = True  'WACHV,10SEPT2017,se comenta
        '    ''''WACHV,INICIO, 20SEPT2017,se Agrega obligatoriedad
        '    If bfncObligatoriedad(opcion) Then
        '        bValidarEscala = True
        '    Else
        '        strRespuestavalidacion = strRespuestavalidacion + "Debe digitar todas las preguntas de la escala CAM" + Chr(13)
        '        'MsgBox("Debe digitar todas las preguntas de la escala CAM")
        '        bValidarEscala = False
        '    End If
        '    ''''WACHV,FIN, 20SEPT2017,se Agrega obligatoriedad
        'End If

        'If opcion = 9 Then 'MDAS
        '    If (Len(Me.cboRespuesta44.Text) > 0) And (Len(Me.cboRespuesta45.Text) > 0) And (Len(Me.cboRespuesta46.Text) > 0) And
        '       (Len(Me.cboRespuesta47.Text) > 0) And (Len(Me.cboRespuesta48.Text) > 0) And (Len(Me.cboRespuesta48.Text) > 0) And
        '       (Len(Me.cboRespuesta50.Text) > 0) And (Len(Me.cboRespuesta51.Text) > 0) And (Len(Me.cboRespuesta52.Text) > 0) And
        '       (Len(Me.cboRespuesta53.Text) > 0) Then
        '        bValidarEscala = True
        '    Else
        '        strRespuestavalidacion = strRespuestavalidacion + "Debe digitar todas las preguntas de la escala MDAS" + Chr(13)
        '        'MsgBox("Debe digitar todas las preguntas de la escala MDAS")
        '        bValidarEscala = False
        '    End If
        'End If
        'If opcion = 10 Then 'MOCCA            
        '    If (Len(Me.txtRespuesta54.Text) > 0) Then
        '        bValidarEscala = True
        '    Else
        '        strRespuestavalidacion = strRespuestavalidacion + "Debe digitar la pregunta de la escala MOCCA" + Chr(13)
        '        'MsgBox("Debe digitar la pregunta de la escala MOCCA")
        '        bValidarEscala = False
        '    End If
        'End If
        'If opcion = 11 Then 'Zarit            
        '    If (Len(Me.cboRespuesta55.Text) > 0) And (Len(Me.cboRespuesta56.Text) > 0) And (Len(Me.cboRespuesta57.Text) > 0) And
        '       (Len(Me.cboRespuesta58.Text) > 0) And (Len(Me.cboRespuesta59.Text) > 0) And (Len(Me.cboRespuesta60.Text) > 0) And
        '       (Len(Me.cboRespuesta61.Text) > 0) And (Len(Me.cboRespuesta62.Text) > 0) And (Len(Me.cboRespuesta63.Text) > 0) And
        '       (Len(Me.cboRespuesta64.Text) > 0) And (Len(Me.cboRespuesta65.Text) > 0) And (Len(Me.cboRespuesta66.Text) > 0) And
        '       (Len(Me.cboRespuesta67.Text) > 0) And (Len(Me.cboRespuesta68.Text) > 0) And (Len(Me.cboRespuesta69.Text) > 0) And
        '       (Len(Me.cboRespuesta70.Text) > 0) And (Len(Me.cboRespuesta71.Text) > 0) And (Len(Me.cboRespuesta72.Text) > 0) And
        '       (Len(Me.cboRespuesta73.Text) > 0) And (Len(Me.cboRespuesta74.Text) > 0) And (Len(Me.cboRespuesta75.Text) > 0) And
        '       (Len(Me.cboRespuesta76.Text) > 0) Then
        '        bValidarEscala = True
        '    Else
        '        strRespuestavalidacion = strRespuestavalidacion + strRespuesta = strRespuesta + "Debe digitar todas las preguntas de la escala Zarit" + Chr(13)
        '        'MsgBox("Debe digitar todas las preguntas de la escala Zarit")
        '        bValidarEscala = False
        '    End If
        'End If
        'If opcion = 12 Then 'HAD
        '    If (Len(Me.cboRespuesta77.Text) > 0) And (Len(Me.cboRespuesta79.Text) > 0) And (Len(Me.cboRespuesta81.Text) > 0) And
        '       (Len(Me.cboRespuesta83.Text) > 0) And (Len(Me.cboRespuesta85.Text) > 0) And (Len(Me.cboRespuesta87.Text) > 0) And
        '       (Len(Me.cboRespuesta89.Text) > 0) Then
        '        bValidarEscala = True
        '    Else
        '        strRespuestavalidacion = strRespuestavalidacion + "Debe digitar todas las preguntas de la escala HAD" + Chr(13)
        '        'MsgBox("Debe digitar todas las preguntas de la escala HAD")
        '        bValidarEscala = False
        '    End If

        '    If (Len(Me.cboRespuesta78.Text) > 0) And (Len(Me.cboRespuesta80.Text) > 0) And (Len(Me.cboRespuesta82.Text) > 0) And
        '       (Len(Me.cboRespuesta84.Text) > 0) And (Len(Me.cboRespuesta86.Text) > 0) And (Len(Me.cboRespuesta88.Text) > 0) And
        '       (Len(Me.cboRespuesta90.Text) > 0) Then
        '        bValidarEscala = True
        '    Else
        '        strRespuestavalidacion = strRespuestavalidacion + "Debe digitar todas las preguntas de la escala HAD" + Chr(13)
        '        'MsgBox("Debe digitar todas las preguntas de la escala HAD")
        '        bValidarEscala = False
        '    End If
        'End If
        'If opcion = 13 Then 'PPS            
        '    If (Len(Me.cboRespuesta91.Text) > 0) Then
        '        bValidarEscala = True
        '    Else
        '        strRespuestavalidacion = strRespuestavalidacion + "Debe digitar la preguntas de la escala PPS" + Chr(13)
        '        'MsgBox("Debe digitar la preguntas de la escala PPS")
        '        bValidarEscala = False
        '    End If
        'End If

        'If Len(strRespuestavalidacion) > 0 Then
        '    bValidarEscala = False
        'End If

        Validar_Escalas = strRespuestavalidacion
    End Function

#Region "Escala OASIS 1"
    Private Sub btAgregarOasis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAgregarOasis.Click
        'If Validar_Escalas(1) = True Then
        '    GuardarEscalas(1)
        '    LimpiardatosEscalas(1)
        'End If
    End Sub

    Private Sub cboRespuesta1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta1.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta1.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta1.SelectedValue, "|")
            Me.Label1.Text = strOpcion(0)
            Me.Puntaje1.Text = strOpcion(1)
            totalpuntaje_escalas(1)
        Else
            Me.Label1.Text = ""
            Me.Puntaje1.Text = "0"
            Me.cboRespuesta1.Text = ""
            totalpuntaje_escalas(1)
        End If
    End Sub

    Private Sub cboRespuesta2_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta2.Validated
        Dim strOpcion() As String


        If Len(Me.cboRespuesta2.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta2.SelectedValue, "|")
            Me.Label2.Text = strOpcion(0)
            Me.Puntaje2.Text = strOpcion(1)
            totalpuntaje_escalas(1)
        Else
            Me.Label2.Text = ""
            Me.Puntaje2.Text = "0"
            Me.cboRespuesta2.Text = ""
            totalpuntaje_escalas(1)
        End If

    End Sub

    Private Sub cboRespuesta3_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta3.Validated
        Dim strOpcion() As String


        If Len(Me.cboRespuesta3.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta3.SelectedValue, "|")
            Me.Label3.Text = strOpcion(0)
            Me.Puntaje3.Text = strOpcion(1)
            totalpuntaje_escalas(1)
        Else
            Me.Label3.Text = ""
            Me.Puntaje3.Text = "0"
            Me.cboRespuesta3.Text = ""
            totalpuntaje_escalas(1)
        End If
    End Sub

    Private Sub cboRespuesta4_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta4.Validated
        Dim strOpcion() As String


        If Len(Me.cboRespuesta4.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta4.SelectedValue, "|")
            Me.Label4.Text = strOpcion(0)
            Me.Puntaje4.Text = strOpcion(1)
            totalpuntaje_escalas(1)
        Else
            Me.Label4.Text = ""
            Me.Puntaje4.Text = "0"
            Me.cboRespuesta4.Text = ""
            totalpuntaje_escalas(1)
        End If

    End Sub

    Private Sub cboRespuesta5_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta5.Validated
        Dim strOpcion() As String


        If Len(Me.cboRespuesta5.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta5.SelectedValue, "|")
            Me.Label5.Text = strOpcion(0)
            Me.Puntaje5.Text = strOpcion(1)
            totalpuntaje_escalas(1)
        Else
            Me.Label5.Text = ""
            Me.Puntaje5.Text = "0"
            Me.cboRespuesta5.Text = ""
            totalpuntaje_escalas(1)
        End If

    End Sub
#End Region

#Region "Escala ODSIS 2"
    Private Sub btAgregarOdsis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAgregarOdsis.Click
        'If Validar_Escalas(2) = True Then
        '    GuardarEscalas(2)
        '    LimpiardatosEscalas(2)
        'End If
    End Sub

    Private Sub cboRespuesta6_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta6.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta6.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta6.SelectedValue, "|")
            Me.Label6.Text = strOpcion(0)
            Me.Puntaje6.Text = strOpcion(1)
            totalpuntaje_escalas(2)
        Else
            Me.Label6.Text = ""
            Me.Puntaje6.Text = "0"
        End If
    End Sub

    Private Sub cboRespuesta7_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta7.Validated
        Dim strOpcion() As String


        If Len(Me.cboRespuesta7.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta7.SelectedValue, "|")
            Me.Label7.Text = strOpcion(0)
            Me.Puntaje7.Text = strOpcion(1)
            totalpuntaje_escalas(2)
        Else
            Me.Label7.Text = ""
            Me.Puntaje7.Text = "0"
        End If

    End Sub

    Private Sub cboRespuesta8_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta8.Validated
        Dim strOpcion() As String


        If Len(Me.cboRespuesta8.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta8.SelectedValue, "|")
            Me.Label8.Text = strOpcion(0)
            Me.Puntaje8.Text = strOpcion(1)
            totalpuntaje_escalas(2)
        Else
            Me.Label8.Text = ""
            Me.Puntaje8.Text = "0"
        End If
    End Sub

    Private Sub cboRespuesta9_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta9.Validated
        Dim strOpcion() As String


        If Len(Me.cboRespuesta9.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta9.SelectedValue, "|")
            Me.Label9.Text = strOpcion(0)
            Me.Puntaje9.Text = strOpcion(1)
            totalpuntaje_escalas(2)
        Else
            Me.Label9.Text = ""
            Me.Puntaje9.Text = "0"
        End If

    End Sub

    Private Sub cboRespuesta10_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta10.Validated
        Dim strOpcion() As String


        If Len(Me.cboRespuesta10.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta10.SelectedValue, "|")
            Me.Label10.Text = strOpcion(0)
            Me.Puntaje10.Text = strOpcion(1)
            totalpuntaje_escalas(2)
        Else
            Me.Label10.Text = ""
            Me.Puntaje10.Text = "0"
        End If

    End Sub
#End Region

#Region "Escala ESAS 3"
    Private Sub btAgregarEsas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAgregarEsas.Click
        'If Validar_Escalas(3) = True Then
        '    GuardarEscalas(3)
        '    LimpiardatosEscalas(3)
        'End If
    End Sub

    Private Sub LinkGrafica11_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkGrafica11.LinkClicked
        Graficas_Escalas.Mostrar(3, objPaciente.TipoDocumento, objPaciente.NumeroDocumento, Me.LinkGrafica11.Tag, UCase(Me.Pregunta11.Text))
    End Sub

    Private Sub LinkGrafica12_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkGrafica12.LinkClicked
        Graficas_Escalas.Mostrar(3, objPaciente.TipoDocumento, objPaciente.NumeroDocumento, Me.LinkGrafica12.Tag, UCase(Me.Pregunta12.Text))
    End Sub

    Private Sub LinkGrafica13_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkGrafica13.LinkClicked
        Graficas_Escalas.Mostrar(3, objPaciente.TipoDocumento, objPaciente.NumeroDocumento, Me.LinkGrafica13.Tag, UCase(Me.Pregunta13.Text))
    End Sub
    Private Sub LinkGrafica14_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkGrafica14.LinkClicked
        Graficas_Escalas.Mostrar(3, objPaciente.TipoDocumento, objPaciente.NumeroDocumento, Me.LinkGrafica14.Tag, UCase(Me.Pregunta14.Text))
    End Sub
    Private Sub LinkGrafica15_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkGrafica15.LinkClicked
        Graficas_Escalas.Mostrar(3, objPaciente.TipoDocumento, objPaciente.NumeroDocumento, Me.LinkGrafica15.Tag, UCase(Me.Pregunta15.Text))
    End Sub
    Private Sub LinkGrafica16_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkGrafica16.LinkClicked
        Graficas_Escalas.Mostrar(3, objPaciente.TipoDocumento, objPaciente.NumeroDocumento, Me.LinkGrafica16.Tag, UCase(Me.Pregunta16.Text))
    End Sub
    Private Sub LinkGrafica17_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkGrafica17.LinkClicked
        Graficas_Escalas.Mostrar(3, objPaciente.TipoDocumento, objPaciente.NumeroDocumento, Me.LinkGrafica17.Tag, UCase(Me.Pregunta17.Text))
    End Sub
    Private Sub LinkGrafica18_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkGrafica18.LinkClicked
        Graficas_Escalas.Mostrar(3, objPaciente.TipoDocumento, objPaciente.NumeroDocumento, Me.LinkGrafica18.Tag, UCase(Me.Pregunta18.Text))
    End Sub
    Private Sub LinkGrafica19_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkGrafica19.LinkClicked
        Graficas_Escalas.Mostrar(3, objPaciente.TipoDocumento, objPaciente.NumeroDocumento, Me.LinkGrafica19.Tag, UCase(Me.Pregunta19.Text))
    End Sub
    Private Sub LinkGrafica20_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkGrafica20.LinkClicked
        Graficas_Escalas.Mostrar(3, objPaciente.TipoDocumento, objPaciente.NumeroDocumento, Me.LinkGrafica20.Tag, UCase(Me.Pregunta20.Text))
    End Sub
    Private Sub LinkGrafica21_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkGrafica21.LinkClicked
        Graficas_Escalas.Mostrar(3, objPaciente.TipoDocumento, objPaciente.NumeroDocumento, Me.LinkGrafica21.Tag, UCase(Me.Pregunta21.Text))
    End Sub

#End Region

#Region "Escala ECAF 4"
    Private Sub btAgregarEcaf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAgregarEcaf.Click
        'If Validar_Escalas(4) = True Then
        '    GuardarEscalas(4)
        '    LimpiardatosEscalas(4)
        'End If
    End Sub

    Private Sub cboRespuesta22_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta22.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta22.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta22.SelectedValue, "|")
            Me.Label22.Text = strOpcion(0)
            Me.Puntaje22.Text = strOpcion(1)
            totalpuntaje_escalas(4)
        Else
            Me.Label22.Text = ""
            Me.Puntaje22.Text = "0"
        End If
    End Sub

    Private Sub cboRespuesta23_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta23.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta23.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta23.SelectedValue, "|")
            Me.Label23.Text = strOpcion(0)
            Me.Puntaje23.Text = strOpcion(1)
            totalpuntaje_escalas(4)
        Else
            Me.Label23.Text = ""
            Me.Puntaje23.Text = "0"
        End If
    End Sub

    Private Sub cboRespuesta24_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta24.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta24.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta24.SelectedValue, "|")
            Me.Label24.Text = strOpcion(0)
            Me.Puntaje24.Text = strOpcion(1)
            totalpuntaje_escalas(4)
        Else
            Me.Label24.Text = ""
            Me.Puntaje24.Text = "0"
        End If
    End Sub

    Private Sub cboRespuesta25_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta25.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta25.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta25.SelectedValue, "|")
            Me.Label25.Text = strOpcion(0)
            Me.Puntaje25.Text = strOpcion(1)
            totalpuntaje_escalas(4)
        Else
            Me.Label25.Text = ""
            Me.Puntaje25.Text = "0"
        End If
    End Sub

    Private Sub cboRespuesta26_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta26.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta26.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta26.SelectedValue, "|")
            Me.Label26.Text = strOpcion(0)
            Me.Puntaje26.Text = strOpcion(1)
            totalpuntaje_escalas(4)
        Else
            Me.Label26.Text = ""
            Me.Puntaje26.Text = "0"
        End If
    End Sub

    Private Sub cboRespuesta27_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta27.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta27.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta27.SelectedValue, "|")
            Me.Label27.Text = strOpcion(0)
            Me.Puntaje27.Text = strOpcion(1)
            totalpuntaje_escalas(4)
        Else
            Me.Label27.Text = ""
            Me.Puntaje27.Text = "0"
        End If
    End Sub

    Private Sub LinkGraficaECAF_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkGraficaECAF.LinkClicked
        Graficas_Escalas.Mostrar(4, objPaciente.TipoDocumento, objPaciente.NumeroDocumento, Me.LinkGraficaECAF.Tag, "ECAF")
    End Sub
#End Region

#Region "Escala IK 5"
    Private Sub btAgregarIK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAgregarIK.Click
        'If Validar_Escalas(5) = True Then
        '    GuardarEscalas(5)
        '    LimpiardatosEscalas(5)
        'End If
    End Sub



    Private Sub cboRespuesta28_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta28.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta28.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta28.SelectedValue, "|")
            Me.Label28.Text = strOpcion(0)
            Me.Puntaje28.Text = strOpcion(1)
            Me.lblResultadoIK.Text = Me.Puntaje28.Text
        Else
            Me.Label28.Text = ""
            Me.Puntaje28.Text = "0"
            Me.cboRespuesta28.Text = ""
            Me.lblResultadoIK.Text = Me.Puntaje28.Text
        End If
    End Sub

#End Region

#Region "Escala BARTHEL 6"
    Private Sub btAgregarBarthel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAgregarBarthel.Click
        'If Validar_Escalas(6) = True Then
        '    GuardarEscalas(6)
        '    LimpiardatosEscalas(6)
        'End If
    End Sub

    Private Sub cboRespuesta29_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta29.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta29.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta29.SelectedValue, "|")
            Me.Label29.Text = strOpcion(0)
            Me.Puntaje29.Text = strOpcion(1)
            totalpuntaje_escalas(6)
        Else
            Me.Label29.Text = ""
            Me.Puntaje29.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta30_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta30.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta30.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta30.SelectedValue, "|")
            Me.Label30.Text = strOpcion(0)
            Me.Puntaje30.Text = strOpcion(1)
            totalpuntaje_escalas(6)
        Else
            Me.Label30.Text = ""
            Me.Puntaje30.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta31_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta31.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta31.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta31.SelectedValue, "|")
            Me.Label31.Text = strOpcion(0)
            Me.Puntaje31.Text = strOpcion(1)
            totalpuntaje_escalas(6)
        Else
            Me.Label30.Text = ""
            Me.Puntaje30.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta32_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta32.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta32.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta32.SelectedValue, "|")
            Me.Label32.Text = strOpcion(0)
            Me.Puntaje32.Text = strOpcion(1)
            totalpuntaje_escalas(6)
        Else
            Me.Label30.Text = ""
            Me.Puntaje30.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta33_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta33.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta33.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta33.SelectedValue, "|")
            Me.Label33.Text = strOpcion(0)
            Me.Puntaje33.Text = strOpcion(1)
            totalpuntaje_escalas(6)
        Else
            Me.Label33.Text = ""
            Me.Puntaje33.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta34_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta34.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta34.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta34.SelectedValue, "|")
            Me.Label34.Text = strOpcion(0)
            Me.Puntaje34.Text = strOpcion(1)
            totalpuntaje_escalas(6)
        Else
            Me.Label34.Text = ""
            Me.Puntaje34.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta35_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta35.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta35.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta35.SelectedValue, "|")
            Me.Label35.Text = strOpcion(0)
            Me.Puntaje35.Text = strOpcion(1)
            totalpuntaje_escalas(6)
        Else
            Me.Label35.Text = ""
            Me.Puntaje35.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta36_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta36.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta36.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta36.SelectedValue, "|")
            Me.Label36.Text = strOpcion(0)
            Me.Puntaje36.Text = strOpcion(1)
            totalpuntaje_escalas(6)
        Else
            Me.Label36.Text = ""
            Me.Puntaje36.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta37_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta37.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta37.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta37.SelectedValue, "|")
            Me.Label37.Text = strOpcion(0)
            Me.Puntaje37.Text = strOpcion(1)
            totalpuntaje_escalas(6)
        Else
            Me.Label37.Text = ""
            Me.Puntaje37.Text = "0"
        End If
    End Sub

    Private Sub cboRespuesta38_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta38.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta38.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta38.SelectedValue, "|")
            Me.Label38.Text = strOpcion(0)
            Me.Puntaje38.Text = strOpcion(1)
            totalpuntaje_escalas(6)
        Else
            Me.Label38.Text = ""
            Me.Puntaje38.Text = "0"
        End If
    End Sub
#End Region

#Region "Escala RAMSAY 7"
    Private Sub btAgregarRamsay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAgregarRamsay.Click
        'If Validar_Escalas(7) = True Then
        '    GuardarEscalas(7)
        '    LimpiardatosEscalas(7)
        'End If
    End Sub

    'Private Sub cboRespuesta39_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim strOpcion() As String

    '    If Len(Me.cboRespuesta39.SelectedValue) > 0 Then
    '        strOpcion = Split(cboRespuesta39.SelectedValue, "|")
    '        Me.Label39.Text = strOpcion(0)
    '        Me.Puntaje39.Text = strOpcion(1)
    '        Me.lblResultadoRamsay.Text = Me.Puntaje39.Text
    '    Else
    '        Me.Label39.Text = ""
    '        Me.Puntaje39.Text = "0"
    '    End If
    'End Sub
    Private Sub cboRespuesta39_Validated_1(sender As Object, e As EventArgs) Handles cboRespuesta39.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta39.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta39.SelectedValue, "|")
            Me.Label39.Text = strOpcion(0)
            Me.Puntaje39.Text = strOpcion(1)
            Me.lblResultadoRamsay.Text = Me.Puntaje39.Text
        Else
            Me.Label39.Text = ""
            Me.Puntaje39.Text = "0"
        End If
    End Sub
#End Region

#Region "Escala CAM 8"
    Private Sub btAgregarCam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAgregarCam.Click
        'If Validar_Escalas(8) = True Then
        '    GuardarEscalas(8)
        '    LimpiardatosEscalas(8)
        'End If
    End Sub

    Private Sub opRespuestaSi40_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles opRespuestaSi40.Click
        '''WACHV,INICIO, 20SEPT2017, SE COMENTA SEGUN LO SOLICITADO
        ''Se Se debe eliminar la siguiente funcionalidad: Si la Respuesta es “No”, 
        ''no se debe continuar el cuestionario, es decir se debe mostrar protegida la respuesta de las otras preguntas del Grupo CAM
        ''.Si ya se registraron, deben limpiar su respuesta".
        'If Me.opRespuestaSi40.Checked = True Then
        '    Me.Panel41.Enabled = True
        '    Me.Panel42.Enabled = True
        '    Me.Panel43.Enabled = True
        'Else
        '    Me.Panel41.Enabled = False
        '    Me.Panel42.Enabled = False
        '    Me.Panel43.Enabled = False
        '    Me.opRespuestaNo41.Checked = False
        '    Me.opRespuestaNo42.Checked = False
        '    Me.opRespuestaNo43.Checked = False
        '    Me.opRespuestaSi41.Checked = False
        '    Me.opRespuestaSi42.Checked = False
        '    Me.opRespuestaSi43.Checked = False
        'End If '''WACHV,FIN, 20SEPT2017, SE COMENTA SEGUN LO SOLICITADO
        totalpuntaje_escalas(8)
    End Sub
    Private Sub opRespuestaNo40_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles opRespuestaNo40.Click
        '''WACHV,INICIO, 20SEPT2017, SE COMENTA SEGUN LO SOLICITADO
        ''Se Se debe eliminar la siguiente funcionalidad: Si la Respuesta es “No”, 
        ''no se debe continuar el cuestionario, es decir se debe mostrar protegida la respuesta de las otras preguntas del Grupo CAM
        ''If Me.opRespuestaNo40.Checked = True Then
        ''    Me.Panel41.Enabled = False
        ''    Me.Panel42.Enabled = False
        ''    Me.Panel43.Enabled = False
        ''    Me.opRespuestaNo41.Checked = False
        ''    Me.opRespuestaNo42.Checked = False
        ''    Me.opRespuestaNo43.Checked = False
        ''    Me.opRespuestaSi41.Checked = False
        ''    Me.opRespuestaSi42.Checked = False
        ''    Me.opRespuestaSi43.Checked = False
        ''Else
        ''    Me.Panel41.Enabled = True
        ''    Me.Panel42.Enabled = True
        ''    Me.Panel43.Enabled = True
        ''End If '''WACHV,FIN, 20SEPT2017, SE COMENTA SEGUN LO SOLICITADO
        totalpuntaje_escalas(8)
    End Sub

    Private Sub opRespuestaSi41_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles opRespuestaSi41.Click
        '''WACHV,INICIO, 20SEPT2017, SE COMENTA SEGUN LO SOLICITADO
        ''Se Se debe eliminar la siguiente funcionalidad: Si la Respuesta es “No”, 
        ''no se debe continuar el cuestionario, es decir se debe mostrar protegida la respuesta de las otras preguntas del Grupo CAM
        'If Me.opRespuestaSi41.Checked = True Then
        '    Me.Panel40.Enabled = True
        '    Me.Panel42.Enabled = True
        '    Me.Panel43.Enabled = True
        'Else
        '    Me.Panel40.Enabled = False
        '    Me.Panel42.Enabled = False
        '    Me.Panel43.Enabled = False
        '    Me.opRespuestaNo40.Checked = False
        '    Me.opRespuestaNo42.Checked = False
        '    Me.opRespuestaNo43.Checked = False
        '    Me.opRespuestaSi40.Checked = False
        '    Me.opRespuestaSi42.Checked = False
        '    Me.opRespuestaSi43.Checked = False
        'End If '''WACHV,FIN, 20SEPT2017, SE COMENTA SEGUN LO SOLICITADO
        totalpuntaje_escalas(8)
    End Sub
    Private Sub opRespuestaNo41_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles opRespuestaNo41.Click
        '''WACHV,INICIO, 20SEPT2017, SE COMENTA SEGUN LO SOLICITADO
        ''Se Se debe eliminar la siguiente funcionalidad: Si la Respuesta es “No”, 
        ''no se debe continuar el cuestionario, es decir se debe mostrar protegida la respuesta de las otras preguntas del Grupo CAM
        'If Me.opRespuestaNo41.Checked = True Then
        '    Me.Panel40.Enabled = False
        '    Me.Panel42.Enabled = False
        '    Me.Panel43.Enabled = False
        '    Me.opRespuestaNo40.Checked = False
        '    Me.opRespuestaNo42.Checked = False
        '    Me.opRespuestaNo43.Checked = False
        '    Me.opRespuestaSi40.Checked = False
        '    Me.opRespuestaSi42.Checked = False
        '    Me.opRespuestaSi43.Checked = False
        'Else
        '    Me.Panel40.Enabled = True
        '    Me.Panel42.Enabled = True
        '    Me.Panel43.Enabled = True
        'End If '''WACHV,FIN, 20SEPT2017, SE COMENTA SEGUN LO SOLICITADO
        totalpuntaje_escalas(8)
    End Sub

    Private Sub opRespuestaSi42_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles opRespuestaSi42.Click
        totalpuntaje_escalas(8)
    End Sub
    Private Sub opRespuestaNo42_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles opRespuestaNo42.Click
        totalpuntaje_escalas(8)
    End Sub

    Private Sub opRespuestaSi43_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles opRespuestaSi43.Click
        totalpuntaje_escalas(8)
    End Sub
    Private Sub opRespuestaNo43_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles opRespuestaNo43.Click
        totalpuntaje_escalas(8)
    End Sub


#End Region

#Region "Escala MDAS 9"
    Private Sub btAgregarMdas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAgregarMdas.Click
        'If Validar_Escalas(9) = True Then
        '    GuardarEscalas(9)
        '    LimpiardatosEscalas(9)
        'End If
    End Sub

    Private Sub cboRespuesta44_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta44.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta44.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta44.SelectedValue, "|")
            Me.Label44.Text = strOpcion(0)
            Me.Puntaje44.Text = strOpcion(1)
            totalpuntaje_escalas(9)
        Else
            Me.Label44.Text = ""
            Me.Puntaje44.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta45_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta45.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta45.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta45.SelectedValue, "|")
            Me.Label45.Text = strOpcion(0)
            Me.Puntaje45.Text = strOpcion(1)
            totalpuntaje_escalas(9)
        Else
            Me.Label45.Text = ""
            Me.Puntaje45.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta46_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta46.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta46.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta46.SelectedValue, "|")
            Me.Label46.Text = strOpcion(0)
            Me.Puntaje46.Text = strOpcion(1)
            totalpuntaje_escalas(9)
        Else
            Me.Label46.Text = ""
            Me.Puntaje46.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta47_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta47.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta47.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta47.SelectedValue, "|")
            Me.Label47.Text = strOpcion(0)
            Me.Puntaje47.Text = strOpcion(1)
            totalpuntaje_escalas(9)
        Else
            Me.Label47.Text = ""
            Me.Puntaje47.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta48_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta48.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta48.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta48.SelectedValue, "|")
            Me.Label48.Text = strOpcion(0)
            Me.Puntaje48.Text = strOpcion(1)
            totalpuntaje_escalas(9)
        Else
            Me.Label48.Text = ""
            Me.Puntaje48.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta49_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta49.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta49.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta49.SelectedValue, "|")
            Me.Label49.Text = strOpcion(0)
            Me.Puntaje49.Text = strOpcion(1)
            totalpuntaje_escalas(9)
        Else
            Me.Label49.Text = ""
            Me.Puntaje49.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta50_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta50.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta50.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta50.SelectedValue, "|")
            Me.Label50.Text = strOpcion(0)
            Me.Puntaje50.Text = strOpcion(1)
            totalpuntaje_escalas(9)
        Else
            Me.Label50.Text = ""
            Me.Puntaje50.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta51_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta51.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta51.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta51.SelectedValue, "|")
            Me.Label51.Text = strOpcion(0)
            Me.Puntaje51.Text = strOpcion(1)
            totalpuntaje_escalas(9)
        Else
            Me.Label51.Text = ""
            Me.Puntaje51.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta52_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta52.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta52.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta52.SelectedValue, "|")
            Me.Label52.Text = strOpcion(0)
            Me.Puntaje52.Text = strOpcion(1)
            totalpuntaje_escalas(9)
        Else
            Me.Label52.Text = ""
            Me.Puntaje52.Text = "0"
        End If
    End Sub

    Private Sub cboRespuesta53_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta53.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta53.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta53.SelectedValue, "|")
            Me.Label53.Text = strOpcion(0)
            Me.Puntaje53.Text = strOpcion(1)
            totalpuntaje_escalas(9)
        Else
            Me.Label53.Text = ""
            Me.Puntaje53.Text = "0"
        End If
    End Sub
#End Region

#Region "Escala MOCCA 10"
    Private Sub btAgregarMocca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAgregarMocca.Click
        'If Validar_Escalas(10) = True Then
        '    GuardarEscalas(10)
        '    LimpiardatosEscalas(10)
        'End If
    End Sub
#End Region

#Region "Escala ZARIT 11"
    Private Sub btAgregarZarit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAgregarZarit.Click
        'If Validar_Escalas(11) = True Then
        '    GuardarEscalas(11)
        '    LimpiardatosEscalas(11)
        'End If
    End Sub

    Private Sub cboRespuesta55_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta55.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta55.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta55.SelectedValue, "|")
            Me.Label55.Text = strOpcion(0)
            Me.Puntaje55.Text = strOpcion(1)
            totalpuntaje_escalas(11)
        Else
            Me.Label55.Text = ""
            Me.Puntaje55.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta56_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta56.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta56.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta56.SelectedValue, "|")
            Me.Label56.Text = strOpcion(0)
            Me.Puntaje56.Text = strOpcion(1)
            totalpuntaje_escalas(11)
        Else
            Me.Label56.Text = ""
            Me.Puntaje56.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta57_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta57.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta57.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta57.SelectedValue, "|")
            Me.Label57.Text = strOpcion(0)
            Me.Puntaje57.Text = strOpcion(1)
            totalpuntaje_escalas(11)
        Else
            Me.Label57.Text = ""
            Me.Puntaje57.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta58_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta58.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta58.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta58.SelectedValue, "|")
            Me.Label58.Text = strOpcion(0)
            Me.Puntaje58.Text = strOpcion(1)
            totalpuntaje_escalas(11)
        Else
            Me.Label58.Text = ""
            Me.Puntaje58.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta59_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta59.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta59.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta59.SelectedValue, "|")
            Me.Label59.Text = strOpcion(0)
            Me.Puntaje59.Text = strOpcion(1)
            totalpuntaje_escalas(11)
        Else
            Me.Label59.Text = ""
            Me.Puntaje59.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta60_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta60.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta60.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta60.SelectedValue, "|")
            Me.Label60.Text = strOpcion(0)
            Me.Puntaje60.Text = strOpcion(1)
            totalpuntaje_escalas(11)
        Else
            Me.Label60.Text = ""
            Me.Puntaje60.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta61_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta61.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta61.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta61.SelectedValue, "|")
            Me.Label61.Text = strOpcion(0)
            Me.Puntaje61.Text = strOpcion(1)
            totalpuntaje_escalas(11)
        Else
            Me.Label61.Text = ""
            Me.Puntaje61.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta62_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta62.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta62.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta62.SelectedValue, "|")
            Me.Label62.Text = strOpcion(0)
            Me.Puntaje62.Text = strOpcion(1)
            totalpuntaje_escalas(11)
        Else
            Me.Label62.Text = ""
            Me.Puntaje62.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta63_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta63.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta63.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta63.SelectedValue, "|")
            Me.Label63.Text = strOpcion(0)
            Me.Puntaje63.Text = strOpcion(1)
            totalpuntaje_escalas(11)
        Else
            Me.Label63.Text = ""
            Me.Puntaje63.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta64_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta64.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta64.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta64.SelectedValue, "|")
            Me.Label64.Text = strOpcion(0)
            Me.Puntaje64.Text = strOpcion(1)
            totalpuntaje_escalas(11)
        Else
            Me.Label64.Text = ""
            Me.Puntaje64.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta65_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta65.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta65.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta65.SelectedValue, "|")
            Me.Label65.Text = strOpcion(0)
            Me.Puntaje65.Text = strOpcion(1)
            totalpuntaje_escalas(11)
        Else
            Me.Label65.Text = ""
            Me.Puntaje65.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta66_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta66.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta66.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta66.SelectedValue, "|")
            Me.Label66.Text = strOpcion(0)
            Me.Puntaje66.Text = strOpcion(1)
            totalpuntaje_escalas(11)
        Else
            Me.Label66.Text = ""
            Me.Puntaje66.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta67_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta67.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta67.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta67.SelectedValue, "|")
            Me.Label67.Text = strOpcion(0)
            Me.Puntaje67.Text = strOpcion(1)
            totalpuntaje_escalas(11)
        Else
            Me.Label67.Text = ""
            Me.Puntaje67.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta68_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta68.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta68.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta68.SelectedValue, "|")
            Me.Label68.Text = strOpcion(0)
            Me.Puntaje68.Text = strOpcion(1)
            totalpuntaje_escalas(11)
        Else
            Me.Label68.Text = ""
            Me.Puntaje68.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta69_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta69.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta69.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta69.SelectedValue, "|")
            Me.Label69.Text = strOpcion(0)
            Me.Puntaje69.Text = strOpcion(1)
            totalpuntaje_escalas(11)
        Else
            Me.Label69.Text = ""
            Me.Puntaje69.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta70_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta70.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta70.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta70.SelectedValue, "|")
            Me.Label70.Text = strOpcion(0)
            Me.Puntaje70.Text = strOpcion(1)
            totalpuntaje_escalas(11)
        Else
            Me.Label70.Text = ""
            Me.Puntaje70.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta71_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta71.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta71.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta71.SelectedValue, "|")
            Me.Label71.Text = strOpcion(0)
            Me.Puntaje71.Text = strOpcion(1)
            totalpuntaje_escalas(11)
        Else
            Me.Label71.Text = ""
            Me.Puntaje71.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta72_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta72.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta72.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta72.SelectedValue, "|")
            Me.Label72.Text = strOpcion(0)
            Me.Puntaje72.Text = strOpcion(1)
            totalpuntaje_escalas(11)
        Else
            Me.Label72.Text = ""
            Me.Puntaje72.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta73_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta73.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta73.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta73.SelectedValue, "|")
            Me.Label73.Text = strOpcion(0)
            Me.Puntaje73.Text = strOpcion(1)
            totalpuntaje_escalas(11)
        Else
            Me.Label73.Text = ""
            Me.Puntaje73.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta74_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta74.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta74.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta74.SelectedValue, "|")
            Me.Label74.Text = strOpcion(0)
            Me.Puntaje74.Text = strOpcion(1)
            totalpuntaje_escalas(11)
        Else
            Me.Label74.Text = ""
            Me.Puntaje74.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta75_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta75.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta75.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta75.SelectedValue, "|")
            Me.Label75.Text = strOpcion(0)
            Me.Puntaje75.Text = strOpcion(1)
            totalpuntaje_escalas(11)
        Else
            Me.Label75.Text = ""
            Me.Puntaje75.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta76_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta76.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta76.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta76.SelectedValue, "|")
            Me.Label76.Text = strOpcion(0)
            Me.Puntaje76.Text = strOpcion(1)
            totalpuntaje_escalas(11)
        Else
            Me.Label76.Text = ""
            Me.Puntaje76.Text = "0"
        End If
    End Sub

#End Region

#Region "Escala HAD 12"
    Private Sub btAgregarHad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAgregarHad.Click
        'If Validar_Escalas(12) = True Then
        '    GuardarEscalas(12)
        '    LimpiardatosEscalas(12)
        'End If
    End Sub

    Private Sub cboRespuesta77_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta77.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta77.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta77.SelectedValue, "|")
            Me.Label77.Text = strOpcion(0)
            Me.Puntaje77.Text = strOpcion(1)
            totalpuntaje_escalas(12)
        Else
            Me.Label77.Text = ""
            Me.Puntaje77.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta78_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta78.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta78.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta78.SelectedValue, "|")
            Me.Label78.Text = strOpcion(0)
            Me.Puntaje78.Text = strOpcion(1)
            totalpuntaje_escalas(12)
        Else
            Me.Label78.Text = ""
            Me.Puntaje78.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta79_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta79.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta79.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta79.SelectedValue, "|")
            Me.Label79.Text = strOpcion(0)
            Me.Puntaje79.Text = strOpcion(1)
            totalpuntaje_escalas(12)
        Else
            Me.Label79.Text = ""
            Me.Puntaje79.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta80_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta80.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta80.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta80.SelectedValue, "|")
            Me.Label80.Text = strOpcion(0)
            Me.Puntaje80.Text = strOpcion(1)
            totalpuntaje_escalas(12)
        Else
            Me.Label80.Text = ""
            Me.Puntaje80.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta81_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta81.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta81.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta81.SelectedValue, "|")
            Me.Label81.Text = strOpcion(0)
            Me.Puntaje81.Text = strOpcion(1)
            totalpuntaje_escalas(12)
        Else
            Me.Label81.Text = ""
            Me.Puntaje81.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta82_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta82.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta82.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta82.SelectedValue, "|")
            Me.Label82.Text = strOpcion(0)
            Me.Puntaje82.Text = strOpcion(1)
            totalpuntaje_escalas(12)
        Else
            Me.Label82.Text = ""
            Me.Puntaje82.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta83_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta83.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta83.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta83.SelectedValue, "|")
            Me.Label83.Text = strOpcion(0)
            Me.Puntaje83.Text = strOpcion(1)
            totalpuntaje_escalas(12)
        Else
            Me.Label83.Text = ""
            Me.Puntaje83.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta84_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta84.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta84.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta84.SelectedValue, "|")
            Me.Label84.Text = strOpcion(0)
            Me.Puntaje84.Text = strOpcion(1)
            totalpuntaje_escalas(12)
        Else
            Me.Label84.Text = ""
            Me.Puntaje84.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta85_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta85.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta85.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta85.SelectedValue, "|")
            Me.Label85.Text = strOpcion(0)
            Me.Puntaje85.Text = strOpcion(1)
            totalpuntaje_escalas(12)
        Else
            Me.Label85.Text = ""
            Me.Puntaje85.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta86_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta86.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta86.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta86.SelectedValue, "|")
            Me.Label86.Text = strOpcion(0)
            Me.Puntaje86.Text = strOpcion(1)
            totalpuntaje_escalas(12)
        Else
            Me.Label86.Text = ""
            Me.Puntaje86.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta87_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta87.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta87.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta87.SelectedValue, "|")
            Me.Label87.Text = strOpcion(0)
            Me.Puntaje87.Text = strOpcion(1)
            totalpuntaje_escalas(12)
        Else
            Me.Label87.Text = ""
            Me.Puntaje87.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta88_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta88.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta88.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta88.SelectedValue, "|")
            Me.Label88.Text = strOpcion(0)
            Me.Puntaje88.Text = strOpcion(1)
            totalpuntaje_escalas(12)
        Else
            Me.Label88.Text = ""
            Me.Puntaje88.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta89_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta89.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta89.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta89.SelectedValue, "|")
            Me.Label89.Text = strOpcion(0)
            Me.Puntaje89.Text = strOpcion(1)
            totalpuntaje_escalas(12)
        Else
            Me.Label89.Text = ""
            Me.Puntaje89.Text = "0"
        End If
    End Sub
    Private Sub cboRespuesta90_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta90.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta90.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta90.SelectedValue, "|")
            Me.Label90.Text = strOpcion(0)
            Me.Puntaje90.Text = strOpcion(1)
            totalpuntaje_escalas(12)
        Else
            Me.Label90.Text = ""
            Me.Puntaje90.Text = "0"
        End If
    End Sub

#End Region

#Region "Escala PPS 13"
    Private Sub btAgregarPPS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAgregarPPS.Click
        'If Validar_Escalas(13) = True Then
        '    GuardarEscalas(13)
        '    LimpiardatosEscalas(13)
        'End If
    End Sub

    Private Sub cboRespuesta91_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRespuesta91.Validated
        Dim strOpcion() As String

        If Len(Me.cboRespuesta91.SelectedValue) > 0 Then
            strOpcion = Split(cboRespuesta91.SelectedValue, "|")
            Me.Label91.Text = strOpcion(0)
            Me.Puntaje91.Text = strOpcion(1)
            Me.lblResultadoPPS.Text = Me.Puntaje91.Text
        Else
            Me.Label91.Text = ""
            Me.Puntaje91.Text = "0"
        End If
    End Sub

#End Region

#Region "Historico Escalas"

    Private Sub bt_Histo_Escalas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_Histo_Escalas.Click

        Dim strMensaje As String = ""
        Dim dtdatos_Esas As New DataTable
        Dim dtdatos_IK As New DataTable
        Dim dtdatos_PPS As New DataTable
        Dim dtdatos_OASIS As New DataTable
        Dim dtdatos_ODSIS As New DataTable
        Dim dtdatos_ECAF As New DataTable
        Dim dtdatos_BARTHEL As New DataTable
        Dim dtdatos_RAMSAY As New DataTable
        Dim dtdatos_CAM As New DataTable
        Dim dtdatos_MDAS As New DataTable
        Dim dtdatos_MOCCA As New DataTable
        Dim dtdatos_ZARIT As New DataTable
        Dim dtdatos_HAD As New DataTable
        Dim strIP As String = ""
        Dim strHostName As String

        strHostName = System.Net.Dns.GetHostName()

        strIP = System.Net.Dns.GetHostByName(strHostName).AddressList(0).ToString()

        Dim totalcolum As Integer

        GrupoLocation.X = 5

        'Escala ESAS
        strMensaje = objEscalas.InserRegHistoSophia(3, Me.objPaciente.TipoDocumento, Me.objPaciente.NumeroDocumento, strIP)
        CargarHistoricosAvicena(204, strIP)

        dtdatos_Esas = objEscalas.ConsultarHistoricoEscalas(strIP)
        If dtdatos_Esas.Rows.Count > 0 Then


            dtgHistoEscalas_ESAS.DataSource = dtdatos_Esas
            totalcolum = dtgHistoEscalas_ESAS.ColumnCount
            With dtgHistoEscalas_ESAS
                .Columns.Item("IdPregunta").Width = 0
                .Columns.Item("IdPregunta").Visible = False
                .Columns.Item("Pregunta").Width = 90
                For i As Integer = 2 To totalcolum - 1
                    .Columns.Item(i).Width = 100
                Next
            End With
            h = 293
            GrupoSize.Height = h
            Me.grpHistoESAS.Size = GrupoSize
            GrupoLocation.Y = 4090
            Me.grpHistoESAS.Location = GrupoLocation
            y = Me.grpHistoESAS.Location.Y + h + 1
            GrupoLocation.Y = y
            Me.grpHistoIK.Location = GrupoLocation
        Else
            h = 18
            GrupoSize.Height = h
            Me.grpHistoESAS.Size = GrupoSize
            y = Me.grpHistoESAS.Location.Y + h + 1
            GrupoLocation.Y = y
            Me.grpHistoIK.Location = GrupoLocation
        End If

        'Escala IK
        strMensaje = objEscalas.InserRegHistoSophia(5, Me.objPaciente.TipoDocumento, Me.objPaciente.NumeroDocumento, strIP)
        CargarHistoricosAvicena(206, strIP)

        dtdatos_IK = objEscalas.ConsultarHistoricoEscalas(strIP)
        If dtdatos_IK.Rows.Count > 0 Then
            dtgHistoEscalas_IK.DataSource = dtdatos_IK
            totalcolum = dtgHistoEscalas_IK.ColumnCount

            With dtgHistoEscalas_IK
                .Columns.Item("IdPregunta").Width = 0
                .Columns.Item("IdPregunta").Visible = False
                .Columns.Item("Pregunta").Width = 150
                For i As Integer = 2 To totalcolum - 1
                    .Columns.Item(i).Width = 100
                Next
            End With
            h = 137
            GrupoSize.Height = h
            Me.grpHistoIK.Size = GrupoSize
            y = Me.grpHistoIK.Location.Y + h + 1
            GrupoLocation.Y = y
            Me.grpHistoPPS.Location = GrupoLocation
        Else
            h = 18
            GrupoSize.Height = h
            Me.grpHistoIK.Size = GrupoSize
            y = Me.grpHistoIK.Location.Y + h + 1
            GrupoLocation.Y = y
            Me.grpHistoPPS.Location = GrupoLocation
        End If

        'Escala PPS
        strMensaje = objEscalas.InserRegHistoSophia(13, Me.objPaciente.TipoDocumento, Me.objPaciente.NumeroDocumento, strIP)
        CargarHistoricosAvicena(210, strIP)

        dtdatos_PPS = objEscalas.ConsultarHistoricoEscalas(strIP)
        If dtdatos_PPS.Rows.Count > 0 Then
            dtgHistoEscalas_PPS.DataSource = dtdatos_PPS
            totalcolum = dtgHistoEscalas_PPS.ColumnCount

            With dtgHistoEscalas_PPS
                .Columns.Item("IdPregunta").Width = 0
                .Columns.Item("IdPregunta").Visible = False
                .Columns.Item("Pregunta").Width = 230
                For i As Integer = 2 To totalcolum - 1
                    .Columns.Item(i).Width = 100
                Next
            End With
            h = 138
            GrupoSize.Height = h
            Me.grpHistoPPS.Size = GrupoSize
            y = Me.grpHistoPPS.Location.Y + h + 1
            GrupoLocation.Y = y
            Me.grpHistoOASIS.Location = GrupoLocation
        Else
            h = 18
            GrupoSize.Height = h
            Me.grpHistoPPS.Size = GrupoSize
            y = Me.grpHistoPPS.Location.Y + h + 1
            GrupoLocation.Y = y
            Me.grpHistoOASIS.Location = GrupoLocation
        End If

        'Escala OASIS
        strMensaje = objEscalas.InserRegHistoSophia(1, Me.objPaciente.TipoDocumento, Me.objPaciente.NumeroDocumento, strIP)
        CargarHistoricosAvicena(209, strIP)

        dtdatos_OASIS = objEscalas.ConsultarHistoricoEscalas(strIP)
        If dtdatos_OASIS.Rows.Count > 0 Then
            dtgHistoEscalas_OASIS.DataSource = dtdatos_OASIS
            totalcolum = dtgHistoEscalas_OASIS.ColumnCount
            With dtgHistoEscalas_OASIS
                .Columns.Item("IdPregunta").Width = 0
                .Columns.Item("IdPregunta").Visible = False
                .Columns.Item("Pregunta").Width = 230
                For i As Integer = 2 To totalcolum - 1
                    .Columns.Item(i).Width = 100
                Next
            End With
            h = 203
            GrupoSize.Height = h
            Me.grpHistoOASIS.Size = GrupoSize
            y = Me.grpHistoOASIS.Location.Y + h + 1
            GrupoLocation.Y = y
            Me.grpHistoODSIS.Location = GrupoLocation
        Else
            h = 18
            GrupoSize.Height = h
            Me.grpHistoOASIS.Size = GrupoSize
            y = Me.grpHistoOASIS.Location.Y + h + 1
            GrupoLocation.Y = y
            Me.grpHistoODSIS.Location = GrupoLocation
        End If

        'Escala ODSIS
        strMensaje = objEscalas.InserRegHistoSophia(2, Me.objPaciente.TipoDocumento, Me.objPaciente.NumeroDocumento, strIP)
        CargarHistoricosAvicena(212, strIP)

        dtdatos_ODSIS = objEscalas.ConsultarHistoricoEscalas(strIP)
        If dtdatos_ODSIS.Rows.Count > 0 Then
            dtgHistoEscalas_ODSIS.DataSource = dtdatos_ODSIS
            totalcolum = dtgHistoEscalas_ODSIS.ColumnCount
            With dtgHistoEscalas_ODSIS
                .Columns.Item("IdPregunta").Width = 0
                .Columns.Item("IdPregunta").Visible = False
                .Columns.Item("Pregunta").Width = 230
                For i As Integer = 2 To totalcolum - 1
                    .Columns.Item(i).Width = 100
                Next
            End With
            h = 207
            GrupoSize.Height = h
            Me.grpHistoODSIS.Size = GrupoSize
            y = Me.grpHistoODSIS.Location.Y + h + 1
            GrupoLocation.Y = y
            Me.grpHistoECAF.Location = GrupoLocation
        Else
            h = 18
            GrupoSize.Height = h
            Me.grpHistoODSIS.Size = GrupoSize
            y = Me.grpHistoODSIS.Location.Y + h + 1
            GrupoLocation.Y = y
            Me.grpHistoECAF.Location = GrupoLocation
        End If

        'Escala ECAF
        strMensaje = objEscalas.InserRegHistoSophia(4, Me.objPaciente.TipoDocumento, Me.objPaciente.NumeroDocumento, strIP)
        CargarHistoricosAvicena(203, strIP)

        dtdatos_ECAF = objEscalas.ConsultarHistoricoEscalas(strIP)
        If dtdatos_ECAF.Rows.Count > 0 Then
            dtgHistoEscalas_ECAF.DataSource = dtdatos_ECAF
            totalcolum = dtgHistoEscalas_ECAF.ColumnCount
            With dtgHistoEscalas_ECAF
                .Columns.Item("IdPregunta").Width = 0
                .Columns.Item("IdPregunta").Visible = False
                .Columns.Item("Pregunta").Width = 150
                For i As Integer = 2 To totalcolum - 1
                    .Columns.Item(i).Width = 100
                Next
            End With
            h = 236
            GrupoSize.Height = h
            Me.grpHistoECAF.Size = GrupoSize
            y = Me.grpHistoECAF.Location.Y + h + 1
            GrupoLocation.Y = y
            Me.grpHistoBarthel.Location = GrupoLocation
        Else
            h = 18
            GrupoSize.Height = h
            Me.grpHistoECAF.Size = GrupoSize
            y = Me.grpHistoECAF.Location.Y + h + 1
            GrupoLocation.Y = y
            Me.grpHistoBarthel.Location = GrupoLocation
        End If

        'Escala BARTHEL
        strMensaje = objEscalas.InserRegHistoSophia(6, Me.objPaciente.TipoDocumento, Me.objPaciente.NumeroDocumento, strIP)
        CargarHistoricosAvicena(201, strIP)

        dtdatos_BARTHEL = objEscalas.ConsultarHistoricoEscalas(strIP)
        If dtdatos_BARTHEL.Rows.Count > 0 Then
            dtgHistoEscalas_Barthel.DataSource = dtdatos_BARTHEL
            totalcolum = dtgHistoEscalas_Barthel.ColumnCount
            With dtgHistoEscalas_Barthel
                .Columns.Item("IdPregunta").Width = 0
                .Columns.Item("IdPregunta").Visible = False
                .Columns.Item("Pregunta").Width = 230
                For i As Integer = 2 To totalcolum - 1
                    .Columns.Item(i).Width = 100
                Next
            End With
            h = 297
            GrupoSize.Height = h
            Me.grpHistoBarthel.Size = GrupoSize
            y = Me.grpHistoBarthel.Location.Y + h + 1
            GrupoLocation.Y = y
            Me.grpHistoRamsay.Location = GrupoLocation
        Else
            h = 18
            GrupoSize.Height = h
            Me.grpHistoBarthel.Size = GrupoSize
            y = Me.grpHistoBarthel.Location.Y + h + 1
            GrupoLocation.Y = y
            Me.grpHistoRamsay.Location = GrupoLocation
        End If

        'Escala RAMSAY
        strMensaje = objEscalas.InserRegHistoSophia(7, Me.objPaciente.TipoDocumento, Me.objPaciente.NumeroDocumento, strIP)
        CargarHistoricosAvicena(211, strIP)

        dtdatos_RAMSAY = objEscalas.ConsultarHistoricoEscalas(strIP)
        If dtdatos_RAMSAY.Rows.Count > 0 Then
            dtgHistoEscalas_Ramsay.DataSource = dtdatos_RAMSAY
            totalcolum = dtgHistoEscalas_Ramsay.ColumnCount
            With dtgHistoEscalas_Ramsay
                .Columns.Item("IdPregunta").Width = 0
                .Columns.Item("IdPregunta").Visible = False
                .Columns.Item("Pregunta").Width = 130
                For i As Integer = 2 To totalcolum - 1
                    .Columns.Item(i).Width = 100
                Next
            End With
            h = 137
            GrupoSize.Height = h
            Me.grpHistoRamsay.Size = GrupoSize
            y = Me.grpHistoRamsay.Location.Y + h + 1
            GrupoLocation.Y = y
            Me.grpHistoCAM.Location = GrupoLocation
        Else
            h = 18
            GrupoSize.Height = h
            Me.grpHistoRamsay.Size = GrupoSize
            y = Me.grpHistoRamsay.Location.Y + h + 1
            GrupoLocation.Y = y
            Me.grpHistoCAM.Location = GrupoLocation
        End If

        'Escala CAM
        strMensaje = objEscalas.InserRegHistoSophia(8, Me.objPaciente.TipoDocumento, Me.objPaciente.NumeroDocumento, strIP)
        CargarHistoricosAvicena(202, strIP)

        dtdatos_CAM = objEscalas.ConsultarHistoricoEscalas(strIP)
        If dtdatos_CAM.Rows.Count > 0 Then
            dtgHistoEscalas_CAM.DataSource = dtdatos_CAM
            totalcolum = dtgHistoEscalas_CAM.ColumnCount

            With dtgHistoEscalas_CAM
                .Columns.Item("IdPregunta").Width = 0
                .Columns.Item("IdPregunta").Visible = False
                .Columns.Item("Pregunta").Width = 230
                For i As Integer = 2 To totalcolum - 1
                    .Columns.Item(i).Width = 100
                Next
            End With
            h = 203
            GrupoSize.Height = h
            Me.grpHistoCAM.Size = GrupoSize
            y = Me.grpHistoCAM.Location.Y + h + 1
            GrupoLocation.Y = y
            Me.grpHistoMDAS.Location = GrupoLocation
        Else
            h = 18
            GrupoSize.Height = h
            Me.grpHistoCAM.Size = GrupoSize
            y = Me.grpHistoCAM.Location.Y + h + 1
            GrupoLocation.Y = y
            Me.grpHistoMDAS.Location = GrupoLocation
        End If

        'Escala MDAS
        strMensaje = objEscalas.InserRegHistoSophia(9, Me.objPaciente.TipoDocumento, Me.objPaciente.NumeroDocumento, strIP)
        CargarHistoricosAvicena(207, strIP)

        dtdatos_MDAS = objEscalas.ConsultarHistoricoEscalas(strIP)
        If dtdatos_MDAS.Rows.Count > 0 Then
            dtgHistoEscalas_MDAS.DataSource = dtdatos_MDAS
            totalcolum = dtgHistoEscalas_MDAS.ColumnCount

            With dtgHistoEscalas_MDAS
                .Columns.Item("IdPregunta").Width = 0
                .Columns.Item("IdPregunta").Visible = False
                .Columns.Item("Pregunta").Width = 230
                For i As Integer = 2 To totalcolum - 1
                    .Columns.Item(i).Width = 100
                Next
            End With
            h = 288
            GrupoSize.Height = h
            Me.grpHistoMDAS.Size = GrupoSize
            y = Me.grpHistoMDAS.Location.Y + h + 1
            GrupoLocation.Y = y
            Me.grpHistoMocca.Location = GrupoLocation
        Else
            h = 18
            GrupoSize.Height = h
            Me.grpHistoMDAS.Size = GrupoSize
            y = Me.grpHistoMDAS.Location.Y + h + 1
            GrupoLocation.Y = y
            Me.grpHistoMocca.Location = GrupoLocation
        End If

        'Escala MOCCA
        strMensaje = objEscalas.InserRegHistoSophia(10, Me.objPaciente.TipoDocumento, Me.objPaciente.NumeroDocumento, strIP)
        CargarHistoricosAvicena(208, strIP)

        dtdatos_MOCCA = objEscalas.ConsultarHistoricoEscalas(strIP)
        If dtdatos_MOCCA.Rows.Count > 0 Then
            dtgHistoEscalas_Mocca.DataSource = dtdatos_MOCCA
            totalcolum = dtgHistoEscalas_Mocca.ColumnCount

            With dtgHistoEscalas_Mocca
                .Columns.Item("IdPregunta").Width = 0
                .Columns.Item("IdPregunta").Visible = False
                .Columns.Item("Pregunta").Width = 230
                For i As Integer = 2 To totalcolum - 1
                    .Columns.Item(i).Width = 100
                Next
            End With
            h = 127
            GrupoSize.Height = h
            Me.grpHistoMocca.Size = GrupoSize
            y = Me.grpHistoMocca.Location.Y + h + 1
            GrupoLocation.Y = y
            Me.grpHistoZarit.Location = GrupoLocation
        Else
            h = 18
            GrupoSize.Height = h
            Me.grpHistoMocca.Size = GrupoSize
            y = Me.grpHistoMocca.Location.Y + h + 1
            GrupoLocation.Y = y
            Me.grpHistoZarit.Location = GrupoLocation
        End If

        'Escala ZARIT
        strMensaje = objEscalas.InserRegHistoSophia(11, Me.objPaciente.TipoDocumento, Me.objPaciente.NumeroDocumento, strIP)
        CargarHistoricosAvicena(213, strIP)

        dtdatos_ZARIT = objEscalas.ConsultarHistoricoEscalas(strIP)
        If dtdatos_ZARIT.Rows.Count > 0 Then
            dtgHistoEscalas_Zarit.DataSource = dtdatos_ZARIT
            totalcolum = dtgHistoEscalas_Zarit.ColumnCount

            With dtgHistoEscalas_Zarit
                .Columns.Item("IdPregunta").Width = 0
                .Columns.Item("IdPregunta").Visible = False
                .Columns.Item("Pregunta").Width = 230
                For i As Integer = 2 To totalcolum - 1
                    .Columns.Item(i).Width = 100
                Next
            End With
            h = 525
            GrupoSize.Height = h
            Me.grpHistoZarit.Size = GrupoSize
            y = Me.grpHistoZarit.Location.Y + h + 1
            GrupoLocation.Y = y
            Me.grpHistoHAD.Location = GrupoLocation
        Else
            h = 18
            GrupoSize.Height = h
            Me.grpHistoZarit.Size = GrupoSize
            y = Me.grpHistoZarit.Location.Y + h + 1
            GrupoLocation.Y = y
            Me.grpHistoHAD.Location = GrupoLocation
        End If

        'Escala HAD
        strMensaje = objEscalas.InserRegHistoSophia(12, Me.objPaciente.TipoDocumento, Me.objPaciente.NumeroDocumento, strIP)
        CargarHistoricosAvicena(205, strIP)

        dtdatos_HAD = objEscalas.ConsultarHistoricoEscalas(strIP)
        If dtdatos_HAD.Rows.Count > 0 Then
            dtgHistoEscalas_HAD.DataSource = dtdatos_HAD
            totalcolum = dtgHistoEscalas_HAD.ColumnCount

            With dtgHistoEscalas_HAD
                .Columns.Item("IdPregunta").Width = 0
                .Columns.Item("IdPregunta").Visible = False
                .Columns.Item("Pregunta").Width = 230
                For i As Integer = 2 To totalcolum - 1
                    .Columns.Item(i).Width = 100
                Next
            End With
            h = 391
            GrupoSize.Height = h
            Me.grpHistoHAD.Size = GrupoSize
        Else
            h = 18
            GrupoSize.Height = h
            Me.grpHistoHAD.Size = GrupoSize
        End If


    End Sub

#End Region

#Region "Proponer Respuesta"

    Private Sub btSugerirRespuestaEscalas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSugerirRespuestaEscalas.Click
        Dim dtdatosPregunta As New DataTable
        Dim srvHerramientaEvaluacion As New CuidadosPaleativosServiceImpService()

        Try
            InicialiarArreglo()
            InactivarGroupBoxCheck()  'WACHV, 14SEPT2017, Inactiva todos los GroupBox
            InicializarControlesOtrasHerramientasEvaluacion()
            OcultarGroupBoxCheck()
            CargarPreguntasHerramientaEvaluacion()

            'fncOrganizarGroupBox(2109, 210901, False)
            'fncOrganizarGroupBox(2109, 210905, False)
            'fncOrganizarGroupBox(2109, 210906, False)
            'fncOrganizarGroupBox(2109, 210909, False)

            dtdatosPregunta = objEscalas.ConsultarPreguntasEscalas()

            If dtdatosPregunta.Rows.Count > 0 Then
                Dim aPreUltRespuesta(dtdatosPregunta.Rows.Count) As Long
                Dim aUltimaRespuesta(dtdatosPregunta.Rows.Count) As PreguntaType
                Dim DAOCP As New DAOCuidadosPaliativos()
                Dim Resultado As String
                Dim appOrigen As String = objPaciente.AppOrigenCP.ToUpper()

                srvHerramientaEvaluacion.Url = DAOCP.ConsultarUrlServicioUT(objGeneral.Prestador, objGeneral.Sucursal, DAOCP.TipoServicio, DAOCP.MetodoServicio)

                If srvHerramientaEvaluacion.Url = "" Then
                    Throw New Exception("No fue posible consultar el servicio de últimas respuestas (URL).")
                End If

                For i As Integer = 0 To dtdatosPregunta.Rows.Count - 1
                    aPreUltRespuesta(i) = dtdatosPregunta.Rows(i).Item("id").ToString
                Next

                ''WACHV, 22Dic2017, Se agrega Obtener la ref regional en cada Bd
                '',se cambia parametro de regional objPaciente.Ciudad.ToUpper() por lo retornado en strRegionalRefBD
                Dim strRegionalRefBD As String = DAOCP.ConsultarRegional()
                Resultado = srvHerramientaEvaluacion.ultimasRespuestas(objPaciente.TipoDocumento, objPaciente.NumeroDocumento,
                aPreUltRespuesta, appOrigen, strRegionalRefBD.ToUpper(), aUltimaRespuesta)
                For Each pr As PreguntaType In aUltimaRespuesta
                    If pr.respuestas.textoRespuesta <> Nothing Then
                        CargarUltimaRespuesta(pr.idPregunta, 0, pr.respuestas.textoRespuesta)
                    End If
                    If Not pr.respuestas.listadoIdRespuesta Is Nothing Then
                        If pr.respuestas.listadoIdRespuesta.Length > 0 Then
                            For i As Integer = 0 To pr.respuestas.listadoIdRespuesta.Length - 1
                                CargarUltimaRespuesta(pr.idPregunta, pr.respuestas.listadoIdRespuesta(i).ToString(), pr.respuestas.textoRespuesta)
                            Next
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            'Throw ex
            MsgBox("No es posible consultar la ultima respuesta del Paciente")
        End Try

    End Sub
    Private Sub CargarUltimaRespuesta(ByVal intPregunta As Integer, ByVal intparametrica As Integer, ByVal strRespuesta As String)
        Dim dt As New DataTable
        Dim strOpcion() As String
        Try

            Select Case intPregunta
                'inicio OASIS
                Case 2001
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta1.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta1.SelectedValue, "|")
                    Me.Label1.Text = strOpcion(0)
                    Me.Puntaje1.Text = strOpcion(1)

                Case 2002
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta2.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta2.SelectedValue, "|")
                    Me.Label2.Text = strOpcion(0)
                    Me.Puntaje2.Text = strOpcion(1)

                Case 2003
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta3.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta3.SelectedValue, "|")
                    Me.Label3.Text = strOpcion(0)
                    Me.Puntaje3.Text = strOpcion(1)
                Case 2004
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta4.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta4.SelectedValue, "|")
                    Me.Label4.Text = strOpcion(0)
                    Me.Puntaje4.Text = strOpcion(1)
                Case 2005
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta5.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta5.SelectedValue, "|")
                    Me.Label5.Text = strOpcion(0)
                    Me.Puntaje5.Text = strOpcion(1)
                Case 2006
                    Me.lblResultadoOasis.Text = strRespuesta
                    totalpuntaje_escalas(1)
                    'fin OASIS
                    'inicio ODSIS
                Case 2007
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta6.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta6.SelectedValue, "|")
                    Me.Label6.Text = strOpcion(0)
                    Me.Puntaje6.Text = strOpcion(1)
                Case 2008
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta7.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta7.SelectedValue, "|")
                    Me.Label7.Text = strOpcion(0)
                    Me.Puntaje7.Text = strOpcion(1)
                Case 2009
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta8.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta8.SelectedValue, "|")
                    Me.Label8.Text = strOpcion(0)
                    Me.Puntaje8.Text = strOpcion(1)
                Case 2010
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta9.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta9.SelectedValue, "|")
                    Me.Label9.Text = strOpcion(0)
                    Me.Puntaje9.Text = strOpcion(1)
                Case 2011
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta10.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta10.SelectedValue, "|")
                    Me.Label10.Text = strOpcion(0)
                    Me.Puntaje10.Text = strOpcion(1)
                Case 2012
                    Me.lblResultadoOdsis.Text = strRespuesta
                    totalpuntaje_escalas(2)
                    'fin ODSIS
                    'inicio ESAS
                Case 2013
                    Me.txtRespuesta11.Text = strRespuesta
                Case 2014
                    Me.txtRespuesta12.Text = strRespuesta
                Case 2015
                    Me.txtRespuesta13.Text = strRespuesta
                Case 2016
                    Me.txtRespuesta14.Text = strRespuesta
                Case 2017
                    Me.txtRespuesta15.Text = strRespuesta
                Case 2018
                    Me.txtRespuesta16.Text = strRespuesta
                Case 2019
                    Me.txtRespuesta17.Text = strRespuesta
                Case 2020
                    Me.txtRespuesta18.Text = strRespuesta
                Case 2021
                    Me.txtRespuesta19.Text = strRespuesta
                Case 2022
                    Me.txtRespuesta20.Text = strRespuesta
                Case 2023
                    Me.txtRespuesta21.Text = strRespuesta
                    'fin ESAS
                    'inicio ECAF
                Case 2024
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta22.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta22.SelectedValue, "|")
                    Me.Label22.Text = strOpcion(0)
                    Me.Puntaje22.Text = strOpcion(1)
                Case 2025
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta23.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta23.SelectedValue, "|")
                    Me.Label23.Text = strOpcion(0)
                    Me.Puntaje23.Text = strOpcion(1)
                Case 2026
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta24.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta24.SelectedValue, "|")
                    Me.Label24.Text = strOpcion(0)
                    Me.Puntaje24.Text = strOpcion(1)
                Case 2027
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta25.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta25.SelectedValue, "|")
                    Me.Label25.Text = strOpcion(0)
                    Me.Puntaje25.Text = strOpcion(1)
                Case 2028
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta26.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta26.SelectedValue, "|")
                    Me.Label26.Text = strOpcion(0)
                    Me.Puntaje26.Text = strOpcion(1)
                Case 2029
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta27.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta27.SelectedValue, "|")
                    Me.Label27.Text = strOpcion(0)
                    Me.Puntaje27.Text = strOpcion(1)
                Case 2030
                    Me.lblResultadoEcaf.Text = strRespuesta
                    totalpuntaje_escalas(4)
                    'fin ECAF
                    'inicio IK
                Case 2031
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta28.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta28.SelectedValue, "|")
                    Me.Label28.Text = strOpcion(0)
                    Me.Puntaje28.Text = strOpcion(1)
                    Me.lblResultadoIK.Text = Me.Puntaje28.Text
                Case 2032
                    Me.lblResultadoIK.Text = strRespuesta
                    'fin IK
                    'inicio BARTHEL
                Case 2033
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta29.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta29.SelectedValue, "|")
                    Me.Label29.Text = strOpcion(0)
                    Me.Puntaje29.Text = strOpcion(1)
                Case 2034
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta30.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta30.SelectedValue, "|")
                    Me.Label30.Text = strOpcion(0)
                    Me.Puntaje30.Text = strOpcion(1)
                Case 2035
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta31.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta31.SelectedValue, "|")
                    Me.Label31.Text = strOpcion(0)
                    Me.Puntaje31.Text = strOpcion(1)
                Case 2036
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta32.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta32.SelectedValue, "|")
                    Me.Label32.Text = strOpcion(0)
                    Me.Puntaje32.Text = strOpcion(1)
                Case 2037
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta33.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta33.SelectedValue, "|")
                    Me.Label33.Text = strOpcion(0)
                    Me.Puntaje33.Text = strOpcion(1)
                Case 2038
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta34.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta34.SelectedValue, "|")
                    Me.Label34.Text = strOpcion(0)
                    Me.Puntaje34.Text = strOpcion(1)
                Case 2039
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta35.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta35.SelectedValue, "|")
                    Me.Label35.Text = strOpcion(0)
                    Me.Puntaje35.Text = strOpcion(1)
                Case 2040
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta36.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta36.SelectedValue, "|")
                    Me.Label36.Text = strOpcion(0)
                    Me.Puntaje36.Text = strOpcion(1)
                Case 2041
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta37.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta37.SelectedValue, "|")
                    Me.Label37.Text = strOpcion(0)
                    Me.Puntaje37.Text = strOpcion(1)
                Case 2042
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta38.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta38.SelectedValue, "|")
                    Me.Label38.Text = strOpcion(0)
                    Me.Puntaje38.Text = strOpcion(1)
                Case 2043
                    Me.lblResultadoBarthel.Text = strRespuesta
                    'totalpuntaje_escalas(6)
                    'fin BARTHEL
                    'inicio RAMSAY
                Case 2044
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    'cboRespuesta39.SelectedValue = "204401|1"
                    cboRespuesta39.SelectedValue = dt.Rows(0).Item("id").ToString
                    cboRespuesta39.Refresh()
                    'SendKeys.Send("{TAB}")
                    strOpcion = Split(cboRespuesta39.SelectedValue, "|")
                    Me.Label39.Text = strOpcion(0)
                    Me.Puntaje39.Text = strOpcion(1)
                    Me.lblResultadoRamsay.Text = Me.Puntaje39.Text
                Case 2045
                    Me.lblResultadoRamsay.Text = strRespuesta
                    'fin RAMSAY
                    'inicio CAM
                Case 2046
                    If Me.opRespuestaNo40.Tag = intparametrica Then
                        Me.opRespuestaNo40.Checked = True
                        'Me.Panel40.Enabled = True
                        'Me.Panel41.Enabled = False
                        'Me.Panel42.Enabled = False
                        'Me.Panel43.Enabled = False
                        'Me.opRespuestaSi41.Checked = False
                        'Me.opRespuestaNo41.Checked = False
                        'Me.opRespuestaSi42.Checked = False
                        'Me.opRespuestaNo42.Checked = False
                        'Me.opRespuestaSi43.Checked = False
                        'Me.opRespuestaNo43.Checked = False
                    End If
                    If Me.opRespuestaSi40.Tag = intparametrica Then
                        Me.opRespuestaSi40.Checked = True
                        'Me.Panel40.Enabled = True
                        'Me.Panel41.Enabled = True
                        'Me.Panel42.Enabled = True
                        'Me.Panel43.Enabled = True
                    End If
                Case 2047
                    If Me.opRespuestaNo41.Tag = intparametrica Then
                        Me.opRespuestaNo41.Checked = True
                        'Me.Panel40.Enabled = True '''ojo estaba falso
                        'Me.Panel41.Enabled = True
                        'Me.Panel42.Enabled = True '''ojo estaba falso
                        'Me.Panel43.Enabled = True
                        'Me.opRespuestaSi40.Checked = False
                        'Me.opRespuestaNo40.Checked = False
                        'Me.opRespuestaSi42.Checked = False
                        'Me.opRespuestaNo42.Checked = False
                        'Me.opRespuestaSi43.Checked = False
                        'Me.opRespuestaNo43.Checked = False
                    End If
                    'If Me.opRespuestaSi40.Checked = True Then
                    If Me.opRespuestaSi41.Tag = intparametrica Then
                            Me.opRespuestaSi41.Checked = True
                            'Me.Panel40.Enabled = True
                            'Me.Panel41.Enabled = True
                            'Me.Panel42.Enabled = True
                            'Me.Panel43.Enabled = True
                        End If
                    'End If
                Case 2048
                    'If Me.opRespuestaSi40.Checked = True And Me.opRespuestaSi41.Checked = True Then
                    If Me.opRespuestaNo42.Tag = intparametrica Then
                            Me.opRespuestaNo42.Checked = True
                        End If
                        If Me.opRespuestaSi42.Tag = intparametrica Then
                            Me.opRespuestaSi42.Checked = True
                        End If
                    'End If
                Case 2049
                    'If Me.opRespuestaSi40.Checked = True And Me.opRespuestaSi41.Checked = True Then
                    If Me.opRespuestaNo43.Tag = intparametrica Then
                        Me.opRespuestaNo43.Checked = True
                    End If
                    If Me.opRespuestaSi43.Tag = intparametrica Then
                            Me.opRespuestaSi43.Checked = True
                        End If
                    'End If
                Case 2050
                    Me.lblResultadoCam.Text = strRespuesta
                    totalpuntaje_escalas(8)
                    'fin CAM

                    'inicio MDAS
                Case 2051
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta44.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta44.SelectedValue, "|")
                    Me.Label44.Text = strOpcion(0)
                    Me.Puntaje44.Text = strOpcion(1)
                Case 2052
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta45.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta45.SelectedValue, "|")
                    Me.Label45.Text = strOpcion(0)
                    Me.Puntaje45.Text = strOpcion(1)
                Case 2053
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta46.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta46.SelectedValue, "|")
                    Me.Label46.Text = strOpcion(0)
                    Me.Puntaje46.Text = strOpcion(1)
                Case 2054
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta47.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta47.SelectedValue, "|")
                    Me.Label47.Text = strOpcion(0)
                    Me.Puntaje47.Text = strOpcion(1)
                Case 2055
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta48.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta48.SelectedValue, "|")
                    Me.Label48.Text = strOpcion(0)
                    Me.Puntaje48.Text = strOpcion(1)
                Case 2056
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta49.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta49.SelectedValue, "|")
                    Me.Label49.Text = strOpcion(0)
                    Me.Puntaje49.Text = strOpcion(1)
                Case 2057
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta50.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta50.SelectedValue, "|")
                    Me.Label50.Text = strOpcion(0)
                    Me.Puntaje50.Text = strOpcion(1)
                Case 2058
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta51.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta51.SelectedValue, "|")
                    Me.Label51.Text = strOpcion(0)
                    Me.Puntaje51.Text = strOpcion(1)
                Case 2059
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta52.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta52.SelectedValue, "|")
                    Me.Label52.Text = strOpcion(0)
                    Me.Puntaje52.Text = strOpcion(1)
                Case 2060
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta53.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta53.SelectedValue, "|")
                    Me.Label53.Text = strOpcion(0)
                    Me.Puntaje53.Text = strOpcion(1)
                Case 2061
                    Me.lblResultadoMdas.Text = strRespuesta
                    totalpuntaje_escalas(9)
                    'fin MDAS
                    'inicio Mocca
                Case 2062
                    Me.txtRespuesta54.Text = strRespuesta
                    'fin Mocca
                    'inicio Zarit
                Case 2063
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta55.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta55.SelectedValue, "|")
                    Me.Label55.Text = strOpcion(0)
                    Me.Puntaje55.Text = strOpcion(1)
                Case 2064
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta56.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta56.SelectedValue, "|")
                    Me.Label56.Text = strOpcion(0)
                    Me.Puntaje56.Text = strOpcion(1)
                Case 2065
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta57.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta57.SelectedValue, "|")
                    Me.Label57.Text = strOpcion(0)
                    Me.Puntaje57.Text = strOpcion(1)
                Case 2066
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta58.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta58.SelectedValue, "|")
                    Me.Label58.Text = strOpcion(0)
                    Me.Puntaje58.Text = strOpcion(1)
                Case 2067
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta59.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta59.SelectedValue, "|")
                    Me.Label59.Text = strOpcion(0)
                    Me.Puntaje59.Text = strOpcion(1)
                Case 2068
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta60.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta60.SelectedValue, "|")
                    Me.Label60.Text = strOpcion(0)
                    Me.Puntaje60.Text = strOpcion(1)
                Case 2069
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta61.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta61.SelectedValue, "|")
                    Me.Label61.Text = strOpcion(0)
                    Me.Puntaje61.Text = strOpcion(1)
                Case 2070
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta62.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta62.SelectedValue, "|")
                    Me.Label62.Text = strOpcion(0)
                    Me.Puntaje62.Text = strOpcion(1)
                Case 2071
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta63.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta63.SelectedValue, "|")
                    Me.Label63.Text = strOpcion(0)
                    Me.Puntaje63.Text = strOpcion(1)
                Case 2072
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta64.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta64.SelectedValue, "|")
                    Me.Label64.Text = strOpcion(0)
                    Me.Puntaje64.Text = strOpcion(1)
                Case 2073
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta65.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta65.SelectedValue, "|")
                    Me.Label65.Text = strOpcion(0)
                    Me.Puntaje65.Text = strOpcion(1)
                Case 2074
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta66.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta66.SelectedValue, "|")
                    Me.Label66.Text = strOpcion(0)
                    Me.Puntaje66.Text = strOpcion(1)
                Case 2075
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta67.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta67.SelectedValue, "|")
                    Me.Label67.Text = strOpcion(0)
                    Me.Puntaje67.Text = strOpcion(1)
                Case 2076
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta68.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta68.SelectedValue, "|")
                    Me.Label68.Text = strOpcion(0)
                    Me.Puntaje68.Text = strOpcion(1)
                Case 2077
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta69.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta69.SelectedValue, "|")
                    Me.Label69.Text = strOpcion(0)
                    Me.Puntaje69.Text = strOpcion(1)
                Case 2078
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta70.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta70.SelectedValue, "|")
                    Me.Label70.Text = strOpcion(0)
                    Me.Puntaje70.Text = strOpcion(1)
                Case 2079
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta71.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta71.SelectedValue, "|")
                    Me.Label71.Text = strOpcion(0)
                    Me.Puntaje71.Text = strOpcion(1)
                Case 2080
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta72.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta72.SelectedValue, "|")
                    Me.Label72.Text = strOpcion(0)
                    Me.Puntaje72.Text = strOpcion(1)
                Case 2081
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta73.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta73.SelectedValue, "|")
                    Me.Label73.Text = strOpcion(0)
                    Me.Puntaje73.Text = strOpcion(1)
                Case 2082
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta74.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta74.SelectedValue, "|")
                    Me.Label74.Text = strOpcion(0)
                    Me.Puntaje74.Text = strOpcion(1)
                Case 2083
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta75.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta75.SelectedValue, "|")
                    Me.Label75.Text = strOpcion(0)
                    Me.Puntaje75.Text = strOpcion(1)
                Case 2084
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta76.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta76.SelectedValue, "|")
                    Me.Label76.Text = strOpcion(0)
                    Me.Puntaje76.Text = strOpcion(1)
                Case 2085
                    Me.lblResultadoZarit.Text = strRespuesta
                    totalpuntaje_escalas(11)
                    'fin Zarit

                    'inicio HAD
                Case 2086
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta77.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta77.SelectedValue, "|")
                    Me.Label77.Text = strOpcion(0)
                    Me.Puntaje77.Text = strOpcion(1)
                Case 2087
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta78.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta78.SelectedValue, "|")
                    Me.Label78.Text = strOpcion(0)
                    Me.Puntaje78.Text = strOpcion(1)
                Case 2088
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta79.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta79.SelectedValue, "|")
                    Me.Label79.Text = strOpcion(0)
                    Me.Puntaje79.Text = strOpcion(1)
                Case 2089
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta80.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta80.SelectedValue, "|")
                    Me.Label80.Text = strOpcion(0)
                    Me.Puntaje80.Text = strOpcion(1)
                Case 2090
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta81.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta81.SelectedValue, "|")
                    Me.Label81.Text = strOpcion(0)
                    Me.Puntaje81.Text = strOpcion(1)
                Case 2091
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta82.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta82.SelectedValue, "|")
                    Me.Label82.Text = strOpcion(0)
                    Me.Puntaje82.Text = strOpcion(1)
                Case 2092
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta83.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta83.SelectedValue, "|")
                    Me.Label83.Text = strOpcion(0)
                    Me.Puntaje83.Text = strOpcion(1)
                Case 2093
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta84.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta84.SelectedValue, "|")
                    Me.Label84.Text = strOpcion(0)
                    Me.Puntaje84.Text = strOpcion(1)
                Case 2094
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta85.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta85.SelectedValue, "|")
                    Me.Label85.Text = strOpcion(0)
                    Me.Puntaje85.Text = strOpcion(1)
                Case 2095
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta86.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta86.SelectedValue, "|")
                    Me.Label86.Text = strOpcion(0)
                    Me.Puntaje86.Text = strOpcion(1)
                Case 2096
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta87.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta87.SelectedValue, "|")
                    Me.Label87.Text = strOpcion(0)
                    Me.Puntaje87.Text = strOpcion(1)
                Case 2097
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta88.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta88.SelectedValue, "|")
                    Me.Label88.Text = strOpcion(0)
                    Me.Puntaje88.Text = strOpcion(1)
                Case 2098
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta89.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta89.SelectedValue, "|")
                    Me.Label89.Text = strOpcion(0)
                    Me.Puntaje89.Text = strOpcion(1)
                Case 2099
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta90.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta90.SelectedValue, "|")
                    Me.Label90.Text = strOpcion(0)
                    Me.Puntaje90.Text = strOpcion(1)
                Case 2100
                    Me.lblResultadoHADDepresion.Text = strRespuesta
                    totalpuntaje_escalas(12)
                Case 2101
                    Me.lblResultadoHADAnsiedad.Text = strRespuesta
                    totalpuntaje_escalas(12)
                    'fin HAD
                    'inicio PPS
                Case 2102
                    dt = objEscalas.CargarParametricaRespuesta(intparametrica)
                    If dt.Rows.Count = 0 Then
                        MsgBox("No existen datos parametricos")
                    End If
                    cboRespuesta91.SelectedValue = dt.Rows(0).Item("id").ToString
                    strOpcion = Split(cboRespuesta91.SelectedValue, "|")
                    Me.Label91.Text = strOpcion(0)
                    Me.Puntaje91.Text = strOpcion(1)
                    Me.lblResultadoPPS.Text = Me.Puntaje91.Text
                Case 2103
                    Me.lblResultadoPPS.Text = strRespuesta
                    'fin PPS
                    ''WACHV,01NOV2017, obtener la ultima respuesta para las nuevas preguntas
                Case 2107 'Evaluacion Sintomas
                    fncOrganizarGroupBox(intPregunta, intparametrica, False)
                    '    If intparametrica.ToString() = "210701" Then
                    '        chkEsas.Checked = True
                    '    ElseIf intparametrica.ToString() = "210702" Then
                    '        chkECAF.Checked = True
                    '    ElseIf intparametrica.ToString() = "210703" Then
                    '        chkNingunoEvalSintomas.Checked = True
                    '    End If

                Case 2108 'Evaluacion Funcionalidad
                    fncOrganizarGroupBox(intPregunta, intparametrica, False)
                    '    If intparametrica.ToString() = "210801" Then
                    '        chkPPS.Checked = True
                    '    ElseIf intparametrica.ToString() = "210802" Then
                    '        chkIK.Checked = True
                    '    ElseIf intparametrica.ToString() = "210803" Then
                    '        chkNingunoEvalFuncionalidad.Checked = True
                    '    End If
                Case 2109 'Otras herramientas
                    fncOrganizarGroupBox(intPregunta, intparametrica, False)

                    '    If intparametrica.ToString() = "210901" Then
                    '        chkOASIS.Checked = True
                    '    ElseIf intparametrica.ToString() = "210902" Then
                    '        chkODSIS.Checked = True
                    '    ElseIf intparametrica.ToString() = "210903" Then
                    '        chkEscaladebarthel.Checked = True
                    '    ElseIf intparametrica.ToString() = "210904" Then
                    '        chkEscaladebarthel.Checked = True
                    '    ElseIf intparametrica.ToString() = "210905" Then
                    '        chkRamsay.Checked = True
                    '    ElseIf intparametrica.ToString() = "210906" Then
                    '        chkCAM.Checked = True
                    '    ElseIf intparametrica.ToString() = "210907" Then
                    '        chkMdas.Checked = True
                    '    ElseIf intparametrica.ToString() = "210908" Then
                    '        chkEscalaMocca.Checked = True
                    '    ElseIf intparametrica.ToString() = "210909" Then
                    '        chkTestdezarit.Checked = True
                    '    ElseIf intparametrica.ToString() = "210910" Then
                    '        chkHAD.Checked = True
                    '    End If
            End Select


        Catch ex As Exception
            MsgBox("Error en la consulta de proponer respuesta. " & ex.Message, MsgBoxStyle.Information)
        End Try

    End Sub

    '''WACHV, INICIO, Funcion para validar mostrar los grupos
    Private Sub fncOrganizarGroupBox(ByVal intPregunta As Integer, ByVal intparametrica As Integer, Optional bProponer As Boolean = True)
        Dim dt As New DataTable
        Try
            Dim strValor As String = intparametrica.ToString()
            dt = objEscalas.CargarParametricaRespuesta(intparametrica)

            Select Case intPregunta
                Case 2107 '''seccion de  Evaluacion de sintomas 
                    If strValor = "210701" Then   ''ESAS
                        LimpiarControlesSeccion(chkECAF)
                        chkEsas.Checked = True
                        chkECAF.Checked = False
                        chkNingunoEvalSintomas.Checked = False
                        grpESAS.Enabled = True
                        grpESAS.Visible = True
                        grpEcaf.Enabled = False
                        LimpiarControlesSeccion(chkEsas, bProponer)
                        fncOperacionArregloUnico(ArregloSeleccionadosUnicos, "+", chkEsas.Tag)
                    End If
                    If strValor = "210702" Then ''ECAF
                        LimpiarControlesSeccion(chkEsas)
                        chkECAF.Checked = True
                        chkEsas.Checked = False
                        chkNingunoEvalSintomas.Checked = False
                        grpESAS.Enabled = False
                        grpESAS.Visible = False
                        grpEcaf.Enabled = True
                        grpEcaf.Visible = True
                        LimpiarControlesSeccion(chkECAF, bProponer)
                        fncOperacionArregloUnico(ArregloSeleccionadosUnicos, "+", chkECAF.Tag)
                    End If
                    If strValor = "210703" Then '''NINGUNO
                        chkECAF.Checked = False
                        chkEsas.Checked = False
                        LimpiarControlesSeccion(chkEsas)
                        LimpiarControlesSeccion(chkECAF)
                        chkNingunoEvalSintomas.Checked = True
                        grpESAS.Enabled = False
                        grpESAS.Visible = False
                        grpEcaf.Enabled = False
                        grpEcaf.Visible = False
                        fncOperacionArregloUnico(ArregloSeleccionadosUnicos, "+", chkNingunoEvalSintomas.Tag)
                    End If

                Case 2108 '''seccion Evaluacion Funcionalidad
                    If strValor = "210801" Then  ''PPS
                        LimpiarControlesSeccion(chkIK)
                        chkPPS.Checked = True
                        chkIK.Checked = False
                        chkNingunoEvalFuncionalidad.Checked = False
                        grpPPS.Enabled = True
                        grpPPS.Visible = True
                        grpIK.Enabled = False
                        grpIK.Visible = False
                        LimpiarControlesSeccion(chkPPS, bProponer)
                        fncOperacionArregloUnico(ArregloSeleccionadosUnicos, "+", chkPPS.Tag)
                    End If

                    If strValor = "210802" Then ''IK
                        LimpiarControlesSeccion(chkPPS)
                        chkPPS.Checked = False
                        chkIK.Checked = True
                        chkNingunoEvalFuncionalidad.Checked = False
                        grpPPS.Enabled = False
                        grpPPS.Visible = False
                        grpIK.Enabled = True
                        grpIK.Visible = True
                        LimpiarControlesSeccion(chkIK, bProponer)
                        fncOperacionArregloUnico(ArregloSeleccionadosUnicos, "+", chkIK.Tag)
                    End If

                    If strValor = "210803" Then ''NINGUNO
                        chkPPS.Checked = False
                        chkIK.Checked = False
                        LimpiarControlesSeccion(chkPPS)
                        LimpiarControlesSeccion(chkIK)
                        chkNingunoEvalFuncionalidad.Checked = True
                        grpPPS.Enabled = False
                        grpPPS.Visible = False
                        grpIK.Enabled = False
                        grpIK.Visible = False
                        fncOperacionArregloUnico(ArregloSeleccionadosUnicos, "+", chkNingunoEvalFuncionalidad.Tag)
                    End If

                Case 2109 '''seccion Otras herramientas de Evaluacion
                    'If strValor = "" Then ''NINGUNO
                    'chkOASIS.Checked = False
                    '    grpOASIS.Enabled = False
                    'chkODSIS.Checked = False
                    '    grpODSIS.Enabled = False
                    '    chkEscaladebarthel.Checked = False
                    '    grpBarthel.Enabled = False
                    '    chkRamsay.Checked = False
                    '    grpRAMSAY.Enabled = False
                    '    chkCAM.Checked = False
                    '    grpCam.Enabled = False
                    '    chkMdas.Checked = False
                    '    grpMdas.Enabled = False
                    '    chkEscalaMocca.Checked = False
                    '    grpMocca.Enabled = False
                    '    chkTestdezarit.Checked = False
                    '    grpZarit.Enabled = False
                    '    chkHAD.Checked = False
                    '    grpHAD.Enabled = False
                    'End If
                    If strValor = "210901" Then ''OASIS
                        chkOASIS.Checked = True
                        fncOperacionArreglos(ArregloSeleccionados, "+", chkOASIS.Tag)
                        LimpiarControlesSeccion(chkOASIS, bProponer)
                    End If

                    If strValor = "210902" Then ''ODSIS
                        chkODSIS.Checked = True
                        fncOperacionArreglos(ArregloSeleccionados, "+", chkODSIS.Tag)
                        LimpiarControlesSeccion(chkODSIS, bProponer)
                    End If

                    If strValor = "210903" Then ''BARTEHL
                        chkEscaladebarthel.Checked = True
                        fncOperacionArreglos(ArregloSeleccionados, "+", chkEscaladebarthel.Tag)
                        LimpiarControlesSeccion(chkEscaladebarthel, bProponer)
                    End If

                    If strValor = "210904" Then ''RAMSAY
                        chkRamsay.Checked = True
                        fncOperacionArreglos(ArregloSeleccionados, "+", chkRamsay.Tag)
                        LimpiarControlesSeccion(chkRamsay, bProponer)
                    End If

                    If strValor = "210905" Then ''CAM
                        chkCAM.Checked = True
                        fncOperacionArreglos(ArregloSeleccionados, "+", chkCAM.Tag)
                        LimpiarControlesSeccion(chkCAM, bProponer)
                    End If

                    If strValor = "210906" Then ''MDAS
                        chkMdas.Checked = True
                        fncOperacionArreglos(ArregloSeleccionados, "+", chkMdas.Tag)
                        LimpiarControlesSeccion(chkMdas, bProponer)
                    End If

                    If strValor = "210907" Then ''MOCCA
                        chkEscalaMocca.Checked = True
                        fncOperacionArreglos(ArregloSeleccionados, "+", chkEscalaMocca.Tag)
                        LimpiarControlesSeccion(chkEscalaMocca, bProponer)
                    End If

                    If strValor = "210908" Then ''ZARIT
                        chkTestdezarit.Checked = True
                        fncOperacionArreglos(ArregloSeleccionados, "+", chkTestdezarit.Tag)
                        LimpiarControlesSeccion(chkTestdezarit, bProponer)
                    End If

                    If strValor = "210909" Then ''HAD
                        chkHAD.Checked = True
                        fncOperacionArreglos(ArregloSeleccionados, "+", chkHAD.Tag)
                        LimpiarControlesSeccion(chkHAD, bProponer)
                    End If


                    'Case 2001, 2002, 2003, 2004, 2005, 2006 ''OASIS
                    '    If Len(strValor) > 0 Then
                    '        chkOASIS.Checked = True
                    '        grpOASIS.Enabled = True
                    '    End If

                    'Case 2007, 2008, 2009, 2010, 2011, 2012 ''ODSIS
                    '    If Len(strValor) > 0 Then
                    '        chkODSIS.Checked = True
                    '        grpODSIS.Enabled = True
                    '    End If

                    'Case 2033, 2034, 2035, 2036, 2037, 2038, 2039, 2040, 2041, 2042, 2043 ''ESCALA BARTHEL
                    '    If Len(strValor) > 0 Then
                    '        chkEscaladebarthel.Checked = True
                    '        grpBarthel.Enabled = True
                    '    End If

                    'Case 2044, 2045 ''Ramsay
                    '    If Len(strValor) > 0 Then
                    '        chkRamsay.Checked = True
                    '        grpRAMSAY.Enabled = True
                    '    End If

                    'Case 2046, 2047, 2048, 2049, 2050 ''CAM
                    '    If Len(strValor) > 0 Then
                    '        chkCAM.Checked = True
                    '        grpCam.Enabled = True
                    '    End If

                    'Case 2051, 2052, 2053, 2054, 2055, 2056, 2057, 2058, 2059, 2060, 2061 '''MDAS
                    '    If Len(strValor) > 0 Then
                    '        chkMdas.Checked = True
                    '        grpMdas.Enabled = True
                    '    End If

                    'Case 2062 '''MOcca
                    '    If Len(strValor) > 0 Then
                    '        chkEscalaMocca.Checked = True
                    '        grpMocca.Enabled = True
                    '    End If

                    'Case 2063 To 2085 '''Test de zarit
                    '    If Len(strValor) > 0 Then
                    '        chkTestdezarit.Checked = True
                    '        grpZarit.Enabled = True
                    '    End If

                    'Case 2086 To 2101 '''HAD
                    '    If Len(strValor) > 0 Then
                    '        chkHAD.Checked = True
                    '        grpHAD.Enabled = True
                    '    End If

            End Select

            ''recorere el arreglo con las opciones que llegaron
            'Dim strSeleccionados As String()
            'strSeleccionados = fncOperacionArreglos(ArregloSeleccionados, "*", Nothing)
            'If ArregloSeleccionados.Count > 0 Then
            '    '    For j As Integer = strSeleccionados.GetLowerBound(0) To strSeleccionados.Length - 1

            '    '    Next
            'End If
            ''Inicia ciclo para recorere los seleccionados en el arreglo
            'For j As Integer = ArregloSeleccionados.GetLowerBound(0) To ArregloSeleccionados.Length - 1
            '    ''Asignar el control groupbox que llega por el tag del check seleccionado
            '    Dim ctlContenedorSeleccionado As GroupBox = Me.ParentForm.Controls.Find(ArregloSeleccionados(j), True)(0)
            ''el Control visible y Enabled =true
            'Me.ParentForm.Controls.Find(ArregloSeleccionados(j), True)(0).Enabled = True
            'Me.ParentForm.Controls.Find(ArregloSeleccionados(j), True)(0).Visible = True


        Catch ex As Exception
            MsgBox("Error Organizar grupos " + ex.Message)
        End Try

    End Sub
    '''''WACHV,INICIO, 14SEPT2017, Para que solo selecciona uno solo
    Private Sub chkEsas_Click(sender As Object, e As EventArgs) Handles chkEsas.Click
        CambiarEstadoChecks(chkEsas)
    End Sub 'WACHV,FIN,14SEPT2017, Para que solo selecciona uno solo
    '''''WACHV,INICIO, 14SEPT2017, Para que solo selecciona uno solo
    Private Sub chkECAF_Click(sender As Object, e As EventArgs) Handles chkECAF.Click
        CambiarEstadoChecks(chkECAF)
    End Sub 'WACHV,FIN,14SEPT2017, Para que solo selecciona uno solo
    ''''WACHV,INICIO, 15SEPT2017, Para que solo selecciona uno solo
    Private Sub chkNingunoEvalSintomas_Click(sender As Object, e As EventArgs) Handles chkNingunoEvalSintomas.Click
        CambiarEstadoChecks(chkNingunoEvalSintomas)
    End Sub ''''WACHV,FIN, 15SEPT2017, Para que solo selecciona uno solo
    ''''WACHV,INICIO, 15SEPT2017, Para que solo selecciona uno solo
    Private Sub chkPPS_Click(sender As Object, e As EventArgs) Handles chkPPS.Click
        CambiarEstadoChecks(chkPPS)
    End Sub ''''WACHV,FIN, 15SEPT2017, Para que solo selecciona uno solo
    ''''WACHV,INICIO, 15SEPT2017, Para que solo selecciona uno solo
    Private Sub chkIK_Click(sender As Object, e As EventArgs) Handles chkIK.Click
        CambiarEstadoChecks(chkIK)
    End Sub ''''WACHV,FIN, 15SEPT2017, Para que solo selecciona uno solo
    ''''WACHV,INICIO, 15SEPT2017, Para que solo selecciona uno solo
    Private Sub chkNingunoEvalFuncionalidad_Click(sender As Object, e As EventArgs) Handles chkNingunoEvalFuncionalidad.Click
        CambiarEstadoChecks(chkNingunoEvalFuncionalidad)
    End Sub    ''''WACHV,INICIO, 15SEPT2017, Para que solo selecciona uno solo
    ''''WACHV,INICIO, 15SEPT2017, Para que solo selecciona uno solo
    ''''WACHV,INICIO, 15SEPT2017, Multiple seleccion
    Private Sub chkOASIS_Click(sender As Object, e As EventArgs) Handles chkOASIS.Click
        CambiarEstadoChecks(chkOASIS)
    End Sub
    ''''WACHV,INICIO, 18SEPT2017, Multiple seleccion
    Private Sub chkODSIS_Click(sender As Object, e As EventArgs) Handles chkODSIS.Click
        CambiarEstadoChecks(chkODSIS)
    End Sub
    ''''WACHV,INICIO, 18SEPT2017, Multiple seleccion
    Private Sub chkEscaladebarthel_Click(sender As Object, e As EventArgs) Handles chkEscaladebarthel.Click
        CambiarEstadoChecks(chkEscaladebarthel)
    End Sub
    ''''WACHV,INICIO, 18SEPT2017, Multiple seleccion
    Private Sub chkRamsay_Click(sender As Object, e As EventArgs) Handles chkRamsay.Click
        CambiarEstadoChecks(chkRamsay)
    End Sub
    ''''WACHV,INICIO, 18SEPT2017, Multiple seleccion
    Private Sub chkCAM_Click(sender As Object, e As EventArgs) Handles chkCAM.Click
        CambiarEstadoChecks(chkCAM)
    End Sub
    ''''WACHV,INICIO, 18SEPT2017, Multiple seleccion
    Private Sub chkMdas_Click(sender As Object, e As EventArgs) Handles chkMdas.Click
        CambiarEstadoChecks(chkMdas)
    End Sub
    ''''WACHV,INICIO, 18SEPT2017, Multiple seleccion
    Private Sub chkEscalaMocca_Click(sender As Object, e As EventArgs) Handles chkEscalaMocca.Click
        CambiarEstadoChecks(chkEscalaMocca)
    End Sub
    ''''WACHV,INICIO, 18SEPT2017, Multiple seleccion
    Private Sub chkTestdezarit_Click(sender As Object, e As EventArgs) Handles chkTestdezarit.Click
        CambiarEstadoChecks(chkTestdezarit)
    End Sub
    ''''WACHV,INICIO, 18SEPT2017, Multiple seleccion
    Private Sub chkHAD_Click(sender As Object, e As EventArgs) Handles chkHAD.Click
        CambiarEstadoChecks(chkHAD)
    End Sub
    ''WACHV, 20OCT2017,Funcion que permitira agregar elementos al arreglo, que manejara los elementos de Heramientas de evaluacion
    ''seleccionados por el usuario de manera aleatoria, esta funcion retornara el arreglo con el valor final 
    ''para que en el formulario se visualice las escalas seleccionadas
    Private Function fncOperacionArreglos(ByRef oArregloSeleccionados() As String, ByVal strOpcion As String, ByVal strValor As String) As String()
        If (IsNothing(oArregloSeleccionados)) Then
            ReDim ArregloSeleccionados(0)
        ElseIf (UBound(oArregloSeleccionados) = -1) Then
            ReDim ArregloSeleccionados(0)
        End If
        Select Case strOpcion
            Case "+"
                If UBound(oArregloSeleccionados) = 0 And IsNothing(oArregloSeleccionados(UBound(oArregloSeleccionados))) Then
                    oArregloSeleccionados(UBound(oArregloSeleccionados)) = strValor
                Else
                    ReDim Preserve oArregloSeleccionados(UBound(oArregloSeleccionados) + 1)
                    oArregloSeleccionados(UBound(oArregloSeleccionados)) = strValor
                End If
            Case "-"
                Dim index As Integer = Array.IndexOf(oArregloSeleccionados, strValor)
                'Dim strList As List(Of String) = oArregloSeleccionados.ToList()
                'strList.Remove(index)
                'oArregloSeleccionados = strList.ToArray()
                Dim i As Long, j As Long
                Dim Tmp() As String
                Tmp = oArregloSeleccionados
                If index <> -1 Then
                    ReDim oArregloSeleccionados(UBound(oArregloSeleccionados) - 1)
                    For i = 0 To UBound(Tmp)
                        If i = index Then j = 1 Else oArregloSeleccionados(i - j) = Tmp(i)
                    Next i
                    Erase Tmp
                End If

            Case "*"
                Return oArregloSeleccionados

        End Select

        Return oArregloSeleccionados

    End Function

    Private Function fncOperacionArregloUnico(ByRef oArregloSeleccionadosUnicos() As String, ByVal strOpcion As String, ByVal strValor As String) As String()
        If (IsNothing(oArregloSeleccionadosUnicos)) Then
            ReDim oArregloSeleccionadosUnicos(0)
        ElseIf (UBound(oArregloSeleccionadosUnicos) = -1) Then
            ReDim ArregloSeleccionados(0)
        End If
        Select Case strOpcion
            Case "+"
                If UBound(oArregloSeleccionadosUnicos) = 0 And IsNothing(oArregloSeleccionadosUnicos(UBound(oArregloSeleccionadosUnicos))) Then
                    oArregloSeleccionadosUnicos(UBound(oArregloSeleccionadosUnicos)) = strValor
                Else
                    ReDim Preserve oArregloSeleccionadosUnicos(UBound(oArregloSeleccionadosUnicos) + 1)
                    oArregloSeleccionadosUnicos(UBound(oArregloSeleccionadosUnicos)) = strValor
                End If
            Case "-"
                Dim index As Integer = Array.IndexOf(oArregloSeleccionadosUnicos, strValor)
                'Dim strList As List(Of String) = oArregloSeleccionados.ToList()
                'strList.Remove(index)
                'oArregloSeleccionados = strList.ToArray()
                Dim i As Long, j As Long
                Dim Tmp1() As String
                Tmp1 = oArregloSeleccionadosUnicos
                If index <> -1 Then
                    ReDim oArregloSeleccionadosUnicos(UBound(oArregloSeleccionadosUnicos) - 1)
                    For i = 0 To UBound(Tmp1)
                        If i = index Then j = 1 Else oArregloSeleccionadosUnicos(i - j) = Tmp1(i)
                    Next i
                    Erase Tmp1
                End If

            Case "*"
                Return oArregloSeleccionadosUnicos

        End Select

        Return oArregloSeleccionadosUnicos

    End Function



    ''WACHV, 14OCT2017,Cambia los estados de grupo de checks si se seleciona uno , desmarca los otros
    Private Sub CambiarEstadoChecks(ByRef objCheckBox As CheckBox)
        'Evaluacion de Sintomas
        If objCheckBox.Name = "chkEsas" Or objCheckBox.Name = "chkECAF" Or objCheckBox.Name = "chkNingunoEvalSintomas" Then
            InicialiarArreglo()
            Select Case objCheckBox.CheckState
                Case CheckState.Checked
                    ''Cambiar a Otros estados
                    If objCheckBox.Name = chkEsas.Name Then
                        chkECAF.Checked = False
                        chkNingunoEvalSintomas.Checked = False
                    End If
                    If objCheckBox.Name = chkECAF.Name Then
                        chkEsas.Checked = False
                        chkNingunoEvalSintomas.Checked = False
                    End If

                    If objCheckBox.Name = chkNingunoEvalSintomas.Name Then
                        chkEsas.Checked = False
                        chkECAF.Checked = False
                    End If
                    grpESAS.Enabled = chkEsas.CheckState
                    grpESAS.Visible = chkEsas.CheckState
                    LimpiarControlesSeccion(chkEsas)
                    grpEcaf.Visible = chkECAF.CheckState
                    grpEcaf.Enabled = chkECAF.CheckState
                    LimpiarControlesSeccion(chkECAF)
                    fncOperacionArregloUnico(ArregloSeleccionadosUnicos, "+", objCheckBox.Tag)
                Case CheckState.Unchecked
                    grpEcaf.Enabled = False
                    LimpiarControlesSeccion(chkECAF)
                    grpESAS.Enabled = False
                    LimpiarControlesSeccion(chkEsas)
                    fncOperacionArregloUnico(ArregloSeleccionadosUnicos, "-", objCheckBox.Tag)
                Case CheckState.Indeterminate
            End Select
            Return
        End If
        ''Evaluacion Funcionalidad
        If objCheckBox.Name = "chkPPS" Or objCheckBox.Name = "chkIK" Or objCheckBox.Name = "chkNingunoEvalFuncionalidad" Then
            InicialiarArreglo()
            Select Case objCheckBox.CheckState
                Case CheckState.Checked
                    '''Cambiar a Otros estados
                    If objCheckBox.Name = chkPPS.Name Then
                        chkIK.Checked = False
                        chkNingunoEvalFuncionalidad.Checked = False
                    End If
                    If objCheckBox.Name = chkIK.Name Then
                        chkPPS.Checked = False
                        chkNingunoEvalFuncionalidad.Checked = False
                    End If
                    If objCheckBox.Name = chkNingunoEvalFuncionalidad.Name Then
                        chkIK.Checked = False
                        chkPPS.Checked = False
                    End If
                    grpPPS.Enabled = chkPPS.CheckState
                    grpPPS.Visible = chkPPS.CheckState
                    LimpiarControlesSeccion(chkPPS)
                    grpIK.Enabled = chkIK.CheckState
                    grpIK.Visible = chkIK.CheckState
                    LimpiarControlesSeccion(chkIK)
                    fncOperacionArregloUnico(ArregloSeleccionadosUnicos, "+", objCheckBox.Tag)
                Case CheckState.Unchecked
                    grpPPS.Enabled = False
                    LimpiarControlesSeccion(chkPPS)
                    grpIK.Enabled = False
                    LimpiarControlesSeccion(chkIK)
                    fncOperacionArregloUnico(ArregloSeleccionadosUnicos, "-", objCheckBox.Tag)
                Case CheckState.Indeterminate
            End Select
            Return
        End If
        'Son de multiple seleccion
        If objCheckBox.Name = "chkOASIS" Or objCheckBox.Name = "chkODSIS" _
            Or objCheckBox.Name = "chkEscaladebarthel" Or objCheckBox.Name = "chkRamsay" _
            Or objCheckBox.Name = "chkCAM" Or objCheckBox.Name = "chkMdas" _
            Or objCheckBox.Name = "chkEscalaMocca" Or objCheckBox.Name = "chkTestdezarit" _
            Or objCheckBox.Name = "chkHAD" Then


            Select Case objCheckBox.CheckState
                Case CheckState.Checked
                    fncOperacionArreglos(ArregloSeleccionados, "+", objCheckBox.Tag)
                    LimpiarControlesSeccion(objCheckBox)
                Case CheckState.Unchecked
                    fncOperacionArreglos(ArregloSeleccionados, "-", objCheckBox.Tag)
                    LimpiarControlesSeccion(objCheckBox)
                Case CheckState.Indeterminate
            End Select
            Return
        End If

    End Sub     ''''WACHV,INICIO, 15SEPT2017, Para que solo selecciona uno solo
    ''' <summary>
    ''' WACHV, 04OCT2017, Función para inicializar los elementos dentro de un group box
    ''' </summary>
    Private Sub LimpiarControlesSeccion(ByVal objChkSeleccionado As CheckBox, Optional bProponer As Boolean = True)
        Dim objPanelOtrasHerramientasEvaluacion As Panel
        Dim ctlContenedor As GroupBox
        Dim ctlControlTexto As TextBoxConFormato
        Dim ctlControlCombo As ComboBusqueda
        Dim ctlComboDatos As ComboBox
        Dim ctlTextoDatos As TextBox
        Dim ctlLabelDatos As Label
        Dim ctlPanelDatos As Panel
        Dim intControl As Integer

        'Evaluacion de Sintomas y Evaluacion Funcionalidad
        If objChkSeleccionado.Name = "chkEsas" Or objChkSeleccionado.Name = "chkECAF" Or objChkSeleccionado.Name = "chkNingunoEvalSintomas" Or
             objChkSeleccionado.Name = "chkPPS" Or objChkSeleccionado.Name = "chkIK" Or objChkSeleccionado.Name = "chkNingunoEvalFuncionalidad" Then
            If objChkSeleccionado.CheckState = False Then ''Los que se ocultan se limpian
                ''Asignar el control groupbox que llega por el tag del check seleccionado
                ctlContenedor = Me.ParentForm.Controls.Find(objChkSeleccionado.Tag, True)(0)
                'ctlContenedor.Enabled = objChkSeleccionado.CheckState
                'ctlContenedor.Visible = objChkSeleccionado.CheckState

                ''Solo cuando viene de true (x defecto) limpia
                If bProponer = True Then
                    For intControl = 0 To ctlContenedor.Controls.Count - 1
                        If TypeOf (ctlContenedor.Controls(intControl)) Is TextBoxConFormato Then
                            ctlControlTexto = ctlContenedor.Controls(intControl)
                            ctlControlTexto.Text = ""
                        End If
                        If TypeOf (ctlContenedor.Controls(intControl)) Is ComboBusqueda Then
                            ctlControlCombo = ctlContenedor.Controls(intControl)
                            ctlControlCombo.SelectedIndex = -1
                            ctlControlCombo.Text = ""
                        End If
                        If TypeOf (ctlContenedor.Controls(intControl)) Is ComboBox Then
                            ctlComboDatos = ctlContenedor.Controls(intControl)
                            ctlComboDatos.SelectedIndex = -1
                            ctlComboDatos.Text = ""
                        End If
                        If TypeOf (ctlContenedor.Controls(intControl)) Is TextBox Then
                            ctlTextoDatos = ctlContenedor.Controls(intControl)
                            ctlTextoDatos.Text = ""
                        End If
                        If TypeOf (ctlContenedor.Controls(intControl)) Is Label Then
                            ctlLabelDatos = ctlContenedor.Controls(intControl)
                            If UCase(ctlLabelDatos.Name).Contains("RESULTADO") Then
                                ctlLabelDatos.Text = "0"
                            End If
                        End If
                        If TypeOf (ctlContenedor.Controls(intControl)) Is Panel Then
                            ctlPanelDatos = ctlContenedor.Controls(intControl)
                            For Each control As Control In ctlPanelDatos.Controls
                                If TypeOf (control) Is RadioButton Then
                                    CType(control, RadioButton).Checked = False
                                End If
                            Next
                        End If
                    Next
                End If ''Si llega parametro true
            End If

            'Son de multiple seleccion
        ElseIf objChkSeleccionado.Name = "chkOASIS" Or objChkSeleccionado.Name = "chkODSIS" _
            Or objChkSeleccionado.Name = "chkEscaladebarthel" Or objChkSeleccionado.Name = "chkRamsay" _
            Or objChkSeleccionado.Name = "chkCAM" Or objChkSeleccionado.Name = "chkMdas" _
            Or objChkSeleccionado.Name = "chkEscalaMocca" Or objChkSeleccionado.Name = "chkTestdezarit" _
            Or objChkSeleccionado.Name = "chkHAD" Then

            '''Recorrer los dos Arreglos con los seleccionados y la Totalidad de los controles, no por el chekbox que llega si no por el arreglo lleno
            objPanelOtrasHerramientasEvaluacion = Me.ParentForm.Controls.Find("pnlOtrasHerramientasdeevaluacion", True)(0)
            For i As Integer = 0 To objPanelOtrasHerramientasEvaluacion.Controls.Count - 1
                If TypeOf (objPanelOtrasHerramientasEvaluacion.Controls(i)) Is GroupBox Then ''Si son GroupBox
                    Dim ctlContenedorExistente As GroupBox = objPanelOtrasHerramientasEvaluacion.Controls(i) ''El GroupBox Existente

                    If (UCase(objChkSeleccionado.Tag)) = UCase(ctlContenedorExistente.Name) Then
                        ''Pone el estado como venga el check
                        ctlContenedorExistente.Enabled = objChkSeleccionado.CheckState
                        ctlContenedorExistente.Visible = objChkSeleccionado.CheckState
                        ''Solo cuando viene de true (x defecto) limpia
                        If bProponer = True Then
                            For intControl = 0 To ctlContenedorExistente.Controls.Count - 1
                                If TypeOf (ctlContenedorExistente.Controls(intControl)) Is TextBoxConFormato Then
                                    ctlControlTexto = ctlContenedorExistente.Controls(intControl)
                                    ctlControlTexto.Text = ""
                                End If
                                If TypeOf (ctlContenedorExistente.Controls(intControl)) Is ComboBusqueda Then
                                    ctlControlCombo = ctlContenedorExistente.Controls(intControl)
                                    ctlControlCombo.SelectedIndex = -1
                                    ctlControlCombo.Text = ""
                                End If
                                If TypeOf (ctlContenedorExistente.Controls(intControl)) Is ComboBox Then
                                    ctlComboDatos = ctlContenedorExistente.Controls(intControl)
                                    ctlComboDatos.SelectedIndex = -1
                                    ctlComboDatos.Text = ""
                                End If
                                If TypeOf (ctlContenedorExistente.Controls(intControl)) Is TextBox Then
                                    ctlTextoDatos = ctlContenedorExistente.Controls(intControl)
                                    ctlTextoDatos.Text = ""
                                End If
                                If TypeOf (ctlContenedorExistente.Controls(intControl)) Is Label Then
                                    ctlLabelDatos = ctlContenedorExistente.Controls(intControl)
                                    If UCase(ctlLabelDatos.Name).Contains("RESULTADO") Then
                                        ctlLabelDatos.Text = "0"
                                    End If
                                End If
                                If TypeOf (ctlContenedorExistente.Controls(intControl)) Is Panel Then
                                    ctlPanelDatos = ctlContenedorExistente.Controls(intControl)
                                    For Each control As Control In ctlPanelDatos.Controls
                                        If TypeOf (control) Is RadioButton Then
                                            CType(control, RadioButton).Checked = False
                                        End If
                                    Next
                                End If
                            Next
                        End If  ''SI LLEGA X DEFECTO
                    End If
                End If ''Si el Group Box
            Next

            'If objChkSeleccionado.Name = "chkOASIS" Then
            '    LimpiardatosEscalas(1) ''OSASIS
            '    Me.lblResultadoOasis.Text = "0/20"
            'End If
            'If objChkSeleccionado.Name = "chkODSIS" Then
            '    LimpiardatosEscalas(2) ''ODSIS
            '    Me.lblResultadoOdsis.Text = "0/20"
            'End If
            'If objChkSeleccionado.Name = "chkEscaladebarthel" Then
            '    LimpiardatosEscalas(6) ''BARTHEL
            '    Me.lblResultadoBarthel.Text = "0/100"
            'End If
            'If objChkSeleccionado.Name = "chkRamsay" Then
            '    LimpiardatosEscalas(7) ''RAMSAY
            '    Me.lblResultadoRamsay.Text = "0"
            'End If
            'If objChkSeleccionado.Name = "chkCAM" Then
            '    LimpiardatosEscalas(8) ''CAM
            '    Me.lblResultadoCam.Text = ""
            'End If
            'If objChkSeleccionado.Name = "chkMdas" Then
            '    LimpiardatosEscalas(9) ''MDAS
            '    Me.lblResultadoMdas.Text = ""
            'End If
            'If objChkSeleccionado.Name = "chkEscalaMocca" Then
            '    LimpiardatosEscalas(10) ''MOCCA
            'End If
            'If objChkSeleccionado.Name = "chkTestdezarit" Then
            '    LimpiardatosEscalas(11) ''ZARIT
            '    Me.lblResultadoZarit.Text = ""
            'End If
            'If objChkSeleccionado.Name = "chkHAD" Then
            '    LimpiardatosEscalas(12) ''HAD
            '    Me.lblResultadoHADAnsiedad.Text = ""
            '    Me.lblResultadoHADDepresion.Text = ""
            'End If

        End If

        '''MoverControlesSeccion(ctlContenedor) ''WACHV, 20OCT2017,Mueve los controles,en el panel
        MoverControlesSeccion(Me.ParentForm.Controls.Find(objChkSeleccionado.Tag, True)(0)) ''WACHV, 20OCT2017,Mueve los controles,en el panel

        ''Evaluar si tiene seleccionados
        'If ArregloSeleccionados.Count > 0 Then
        ''Inicia ciclo para recorere los seleccionados en el arreglo
        'For j As Integer = ArregloSeleccionados.GetLowerBound(0) To ArregloSeleccionados.Length - 1
        '    ''Asignar el control groupbox que llega por el tag del check seleccionado
        '    Dim ctlContenedorSeleccionado As GroupBox = Me.ParentForm.Controls.Find(ArregloSeleccionados(j), True)(0)
        ''el Control visible y Enabled =true
        'Me.ParentForm.Controls.Find(ArregloSeleccionados(j), True)(0).Enabled = True
        'Me.ParentForm.Controls.Find(ArregloSeleccionados(j), True)(0).Visible = True
        'ctlContenedorSeleccionado.Enabled = True
        'ctlContenedorSeleccionado.Visible = True
        ''Una vez Asignado se verifica que este en el arreglo,si esta se limpia y si no esta se inhabilita
        '        If UCase(ctlContenedorSeleccionado.Name) = UCase(ctlContenedorExistente.Name) Then ''Si son Iguales se limpian
        '            For intControl = 0 To ctlContenedorSeleccionado.Controls.Count - 1
        '                If TypeOf (ctlContenedorSeleccionado.Controls(intControl)) Is TextBoxConFormato Then
        '                    ctlControlTexto = ctlContenedorSeleccionado.Controls(intControl)
        '                    ctlControlTexto.Text = ""
        '                End If
        '                If TypeOf (ctlContenedorSeleccionado.Controls(intControl)) Is ComboBusqueda Then
        '                    ctlControlCombo = ctlContenedorSeleccionado.Controls(intControl)
        '                    ctlControlCombo.SelectedIndex = -1
        '                    ctlControlCombo.Text = ""
        '                End If
        '                If TypeOf (ctlContenedorSeleccionado.Controls(intControl)) Is ComboBox Then
        '                    ctlComboDatos = ctlContenedorSeleccionado.Controls(intControl)
        '                    ctlComboDatos.SelectedIndex = -1
        '                    ctlComboDatos.Text = ""
        '                End If
        '                If TypeOf (ctlContenedorSeleccionado.Controls(intControl)) Is TextBox Then
        '                    ctlTextoDatos = ctlContenedorSeleccionado.Controls(intControl)
        '                    ctlTextoDatos.Text = ""
        '                End If
        '                If TypeOf (ctlContenedorSeleccionado.Controls(intControl)) Is Label Then
        '                    ctlLabelDatos = ctlContenedorSeleccionado.Controls(intControl)
        '                    If UCase(ctlLabelDatos.Name).Contains("RESULTADO") Then
        '                        ctlLabelDatos.Text = "0"
        '                    End If
        '                End If
        '                If TypeOf (ctlContenedorSeleccionado.Controls(intControl)) Is Panel Then
        '                    ctlPanelDatos = ctlContenedorSeleccionado.Controls(intControl)
        '                    For Each control As Control In ctlPanelDatos.Controls
        '                        If TypeOf (control) Is RadioButton Then
        '                            CType(control, RadioButton).Checked = False
        '                        End If
        '                    Next
        '                End If
        '            Next
        '        End If ''Si esta dentro de los seleccionados
        '    Next
    End Sub
    '''WACHV, INICIO,23OCT2017, INICIALIZAR CONTROLES
    Private Sub OcultarMostrarControlesOtrasHerramientasdeEvaluacion(iMostrar As Boolean)
        Dim objPanelOtrasHerramientasEvaluacion As Panel
        Dim ctlControlTexto As TextBoxConFormato
        Dim ctlControlCombo As ComboBusqueda
        Dim ctlComboDatos As ComboBox
        Dim ctlTextoDatos As TextBox
        Dim ctlLabelDatos As Label
        Dim ctlPanelDatos As Panel
        Dim intControl As Integer
        objPanelOtrasHerramientasEvaluacion = Me.ParentForm.Controls.Find("pnlOtrasHerramientasdeevaluacion", True)(0)
        For i As Integer = 0 To objPanelOtrasHerramientasEvaluacion.Controls.Count - 1
            If TypeOf (objPanelOtrasHerramientasEvaluacion.Controls(i)) Is GroupBox Then ''Si son GroupBox
                Dim ctlContenedorExistente As GroupBox = objPanelOtrasHerramientasEvaluacion.Controls(i) ''El GroupBox Existente
                ctlContenedorExistente.Enabled = iMostrar
                ctlContenedorExistente.Visible = iMostrar
                If iMostrar = False Then ''Muestre limpiando
                    For intControl = 0 To ctlContenedorExistente.Controls.Count - 1
                        If TypeOf (ctlContenedorExistente.Controls(intControl)) Is TextBoxConFormato Then
                            ctlControlTexto = ctlContenedorExistente.Controls(intControl)
                            ctlControlTexto.Text = ""
                        End If
                        If TypeOf (ctlContenedorExistente.Controls(intControl)) Is ComboBusqueda Then
                            ctlControlCombo = ctlContenedorExistente.Controls(intControl)
                            ctlControlCombo.SelectedIndex = -1
                            ctlControlCombo.Text = ""
                        End If
                        If TypeOf (ctlContenedorExistente.Controls(intControl)) Is ComboBox Then
                            ctlComboDatos = ctlContenedorExistente.Controls(intControl)
                            ctlComboDatos.SelectedIndex = -1
                            ctlComboDatos.Text = ""
                        End If
                        If TypeOf (ctlContenedorExistente.Controls(intControl)) Is TextBox Then
                            ctlTextoDatos = ctlContenedorExistente.Controls(intControl)
                            ctlTextoDatos.Text = ""
                        End If
                        If TypeOf (ctlContenedorExistente.Controls(intControl)) Is Label Then
                            ctlLabelDatos = ctlContenedorExistente.Controls(intControl)
                            If UCase(ctlLabelDatos.Name).Contains("RESULTADO") Then
                                ctlLabelDatos.Text = "0"
                            End If
                        End If
                        If TypeOf (ctlContenedorExistente.Controls(intControl)) Is Panel Then
                            ctlPanelDatos = ctlContenedorExistente.Controls(intControl)
                            For Each control As Control In ctlPanelDatos.Controls
                                If TypeOf (control) Is RadioButton Then
                                    CType(control, RadioButton).Checked = False
                                End If
                            Next
                        End If
                    Next
                End If
            End If
        Next
    End Sub  '''WACHV, FIN,23OCT2017, INICIALIZAR CONTROLES

    ''' WACHV, 20OCT2017, INICIO,Función para Ubicar los controles dento del panel
    Private Sub MoverControlesSeccion(ByRef ctlContenedor As GroupBox)
        ''Inicializar controles
        ''InicializarControlesOtrasHerramientasEvaluacion()
        ''Nuevo reposicionar controles, siguiendo la referencia del control
        ''Evaluacion de Sintomas
        If UCase(ctlContenedor.Tag) = "GRPESAS" Or UCase(ctlContenedor.Tag) = "GRPECAF" Then
            ctlContenedor.Location = New Point(chkEsas.Location.X + 80, chkEsas.Location.Y)
        End If
        ''Evaluacion de Funcionalidad
        If UCase(ctlContenedor.Tag) = "GRPPPS" Or UCase(ctlContenedor.Tag) = "GRPIK" Then
            ctlContenedor.Location = New Point(chkPPS.Location.X + 80, chkPPS.Location.Y)
        End If

        ''Otras Herramientas de Evaluacion

        ''Seleccion MUltiple
        If UCase(ctlContenedor.Tag) = "GRPOASIS" Or UCase(ctlContenedor.Tag) = "GRPODSIS" _
            Or UCase(ctlContenedor.Tag) = "GRPBARTHEL" Or UCase(ctlContenedor.Tag) = "GRPRAMSAY" _
            Or ctlContenedor.Tag = "grpCam" Or ctlContenedor.Tag = "grpMdas" _
            Or UCase(ctlContenedor.Tag) = "GRPMOCCA" Or UCase(ctlContenedor.Tag) = "GRPZARIT" _
            Or UCase(ctlContenedor.Tag) = "GRPHAD" Then

            ''Recorrer el Arreglo para posicionar los group box de cada escala
            Dim X As Integer = chkOASIS.Location.X + 120
            Dim Y As Integer = chkOASIS.Location.Y
            Dim YAnt As Integer = 0
            Dim iSeparadorSecciones As Integer = 10

            For i As Integer = ArregloSeleccionados.GetLowerBound(0) To ArregloSeleccionados.Length - 1
                Dim ctlContenedorAnterior As New GroupBox
                Dim ctlContenedorSiguiente As New GroupBox

                If i = 0 Then
                    ctlContenedorAnterior = Me.ParentForm.Controls.Find(ArregloSeleccionados(i), True)(0)
                    ctlContenedorSiguiente = Me.ParentForm.Controls.Find(ArregloSeleccionados(i), True)(0)
                Else
                    ctlContenedorAnterior = Me.ParentForm.Controls.Find(ArregloSeleccionados(i - 1), True)(0)
                    ctlContenedorSiguiente = Me.ParentForm.Controls.Find(ArregloSeleccionados(i), True)(0)
                    Y = (Y + ctlContenedorAnterior.Size.Height) + iSeparadorSecciones
                End If
                ''Asignar el control groupbox que llega por el tag del check seleccionado
                ctlContenedorSiguiente.Location = New Point(X, Y)
            Next
        End If
    End Sub

    Private Sub ReposicicionarPaneles(ByVal ctlPanelContenedor As Panel)
        ''Para reposiccionar controles
        ''SI ES EL PRIMER PANEL
        Dim iSeparadorSecciones As Integer = 10
        If ctlPanelContenedor.Tag = "EVALUACIONSINTOMAS" Then
            Me.pnlEvaluaciondefuncionalidad.Location = New Point(ctlPanelContenedor.Location.X, (ctlPanelContenedor.Location.Y + ctlPanelContenedor.Size.Height) + iSeparadorSecciones)
            ''El siguiente panel
            Me.pnlOtrasHerramientasdeevaluacion.Location = New Point(pnlEvaluaciondefuncionalidad.Location.X, (pnlEvaluaciondefuncionalidad.Location.Y + pnlEvaluaciondefuncionalidad.Size.Height) + iSeparadorSecciones)
            'El Panel de Historicos
            Me.pnlHistoricos.Location = New Point(pnlOtrasHerramientasdeevaluacion.Location.X, (pnlOtrasHerramientasdeevaluacion.Location.Y + pnlOtrasHerramientasdeevaluacion.Size.Height) + iSeparadorSecciones)
        End If
        ''SI ES EL SEGUNDO PANEL
        If ctlPanelContenedor.Tag = "EVALUACIONFUNCIONALIDAD" Then
            Me.pnlOtrasHerramientasdeevaluacion.Location = New Point(ctlPanelContenedor.Location.X, (ctlPanelContenedor.Location.Y + ctlPanelContenedor.Size.Height) + iSeparadorSecciones)
            'El Panel de Historicos
            Me.pnlHistoricos.Location = New Point(pnlOtrasHerramientasdeevaluacion.Location.X, (pnlOtrasHerramientasdeevaluacion.Location.Y + pnlOtrasHerramientasdeevaluacion.Size.Height) + iSeparadorSecciones)
        End If

        ''SI ES EL TERCER PANEL
        If ctlPanelContenedor.Tag = "OTRASHERRAMIENTASDEEVALUACION" Then
            Me.pnlHistoricos.Location = New Point(ctlPanelContenedor.Location.X, (ctlPanelContenedor.Location.Y + ctlPanelContenedor.Size.Height) + iSeparadorSecciones)
        End If

    End Sub

    '''''WACHV,INICIO, 19OCT2017, Para Contraer o expandir el panel
    Private Sub cmdExpandirContraerEvaluacioSintomas_Click(sender As Object, e As EventArgs) Handles cmdExpandirContraerEvaluacioSintomas.Click
        If pnlEvaluacionSintomas.Height = 28 Then ''Esta Contraido, se expnade
            pnlEvaluacionSintomas.Height = 430
            cmdExpandirContraerEvaluacioSintomas.Image = My.Resources.Expand
            ''Reposicionar los otros controles
            ReposicicionarPaneles(pnlEvaluacionSintomas)
        Else
            pnlEvaluacionSintomas.Height = 28
            cmdExpandirContraerEvaluacioSintomas.Image = My.Resources.Collapse
            ReposicicionarPaneles(pnlEvaluacionSintomas)
        End If
    End Sub
    Private Sub cmdExpandirContraerEvaluacionFuncionalidad_Click(sender As Object, e As EventArgs) Handles cmdExpandirContraerEvaluacionFuncionalidad.Click
        If pnlEvaluaciondefuncionalidad.Height = 28 Then ''Esta Contraido, se expnade
            pnlEvaluaciondefuncionalidad.Height = 229
            cmdExpandirContraerEvaluacionFuncionalidad.Image = My.Resources.Expand
            ''Reposicionar los otros controles
            ReposicicionarPaneles(pnlEvaluaciondefuncionalidad)
        Else
            pnlEvaluaciondefuncionalidad.Height = 28
            cmdExpandirContraerEvaluacionFuncionalidad.Image = My.Resources.Collapse
            ReposicicionarPaneles(pnlEvaluaciondefuncionalidad)
        End If
    End Sub
    Private Sub cmdExpandirContraerOtrasHeramientasdeEvaluacion_Click(sender As Object, e As EventArgs) Handles cmdExpandirContraerOtrasHeramientasdeEvaluacion.Click
        If pnlOtrasHerramientasdeevaluacion.Height = 28 Then ''Esta Contraido, se expnade
            pnlOtrasHerramientasdeevaluacion.Height = 3449
            cmdExpandirContraerOtrasHeramientasdeEvaluacion.Image = My.Resources.Expand
            ''Reposicionar los otros controles
            ReposicicionarPaneles(pnlOtrasHerramientasdeevaluacion)
        Else
            pnlOtrasHerramientasdeevaluacion.Height = 28
            cmdExpandirContraerOtrasHeramientasdeEvaluacion.Image = My.Resources.Collapse
            ReposicicionarPaneles(pnlOtrasHerramientasdeevaluacion)
        End If
    End Sub  '''''WACHV,FIN, 19OCT2017, Para Contraer o expandir el panel
#End Region

#Region "Historicos Avicena"
    'ByVal intPregunta As Integer, ByVal intparametrica As Integer, ByVal strRespuesta As String
    Private Sub CargarHistoricosAvicena(ByVal strTabla As Integer, ByVal strIP As String)

        Dim strMensaje As String = ""
        Dim dtdatosPregunta As New DataTable
        Dim srvHerramientaEvaluacion As New CuidadosPaleativosServiceImpService()

        Try
            dtdatosPregunta = objEscalas.ConsultarPreguntas_x_Escala(strTabla)

            If dtdatosPregunta.Rows.Count > 0 Then
                Dim aPreHisAvicena As New UltimaRespuestaResquestType
                Dim aPreHisPreguntas(dtdatosPregunta.Rows.Count) As Long
                Dim aUltimaRespuesta(dtdatosPregunta.Rows.Count) As GrupoFechaType
                Dim DAOCP As New DAOCuidadosPaliativos()
                Dim Resultado As String
                Dim appOrigen As String = objPaciente.AppOrigenCP.ToUpper()
                Dim Fecha As String
                Dim dtDato As New DataTable
                Dim Dias As Integer = 0

                srvHerramientaEvaluacion.Url = DAOCP.ConsultarUrlServicioUT(objGeneral.Prestador, objGeneral.Sucursal, DAOCP.TipoServicio, DAOCP.MetodoServicioH)

                If srvHerramientaEvaluacion.Url = "" Then
                    Throw New Exception("No fue posible consultar el servicio de últimas respuestas (URL).")
                End If
                dtDato = objEscalas.ConsultarDiasHistorico("Historico_Paliativos")
                If dtDato.Rows.Count = 0 Then
                    MsgBox("No existen parametros para el calulo de dias historico paliativos")
                Else
                    Dias = dtDato.Rows(0).Item("valor").ToString
                End If

                aPreHisAvicena.tipoDocumento = objPaciente.TipoDocumento
                aPreHisAvicena.numeroDocumento = objPaciente.NumeroDocumento

                For i As Integer = 0 To dtdatosPregunta.Rows.Count - 1
                    aPreHisPreguntas(i) = dtdatosPregunta.Rows(i).Item("idpregunta").ToString
                Next
                aPreHisAvicena.preguntas = aPreHisPreguntas
                aPreHisAvicena.origen = appOrigen
                ''WACHV, 22Dic2017, Se agrega Obtener la ref regional en cada Bd
                '',se cambia parametro de regional objPaciente.Ciudad.ToUpper() por lo retornado en strRegionalRefBD
                Dim strRegionalRefBD As String = DAOCP.ConsultarRegional()
                aPreHisAvicena.regional = strRegionalRefBD.ToUpper()
                Fecha = Format(DateTime.Now, "yyyy-MM-dd")
                Fecha = Fecha & " 23:59:59"

                Resultado = srvHerramientaEvaluacion.historicoRespuestas(aPreHisAvicena, Dias, Fecha, DAOCP.ProgramaH.ToUpper(), DAOCP.SeccionH.ToUpper(), DAOCP.SubSeccionH.ToUpper(), aUltimaRespuesta)

                For i As Integer = aUltimaRespuesta.Length - 1 To 0 Step -1
                    Dim pr As GrupoFechaType = aUltimaRespuesta(i)
                    If Not pr.resultadosHist Is Nothing Then
                        If pr.resultadosHist.Length > 0 Then
                            For j As Integer = 0 To pr.resultadosHist.Length - 1
                                strMensaje = objEscalas.InserRegHistoAvicena(pr.resultadosHist(j).idPregunta, pr.fecha, pr.resultadosHist(j).interpretacion, strIP, "")
                            Next
                        End If
                    End If
                Next

            End If
            'Return oURAspectosSociales
        Catch ex As Exception
            'Throw ex
        End Try
    End Sub

#End Region

End Class

