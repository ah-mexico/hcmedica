Imports Enfermeria.Sophia.HistoriaClinica.DatosPaciente
Imports Enfermeria.Sophia.HistoriaClinica.DAO
Imports Enfermeria.Sophia.HistoriaClinica.BL
Imports objGeneral = Enfermeria.Sophia.HistoriaClinica.DatosGenerales.Generales
Imports objCon = Enfermeria.Sophia.HistoriaClinica.DatosConexion.Conexion
Imports Enfermeria.Sophia.HistoriaClinica.Controles
Imports Enfermeria.Sophia.HistoriaClinica.DatosGenerales
Imports Enfermeria.Sophia.HistoriaClinica.DatosConexion
Public Class CtlEscalas

    Private Shared _Instancia As CtlEscalas
    Private objDao As New DAOGeneral
    Private _Ordenes As OrdenMedica
    Private datosconexion As objCon
    Private General As objGeneral
    ''Private Paciente As objPaciente
    Private AGrilla As New ArrayList
    Private strObsMed As String
    Private HfrmObs As frmc_Observaciones
    Private ControlGrabar As Integer
    Private datosSinAlmacenar As Boolean = False
    Private TipoOrden As String
    Private datosPaciente As Paciente
    Private datosLogin As Generales
    Private objPaciente As Paciente
    Private objConexion As Conexion



#Region "Instancia de Control"
    Public Shared ReadOnly Property Instancia() As CtlEscalas
        Get
            If _Instancia Is Nothing Then
                _Instancia = New CtlEscalas
            End If
            Return _Instancia
        End Get

    End Property
#End Region

    Private Sub CtlEscalas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        frmHistoriaPrincipal.blnFirstOrdenesMedicas = False

        datosLogin = Generales.Instancia()
        datosPaciente = Paciente.Instancia()
        datosconexion = Conexion.Instancia()
        _Ordenes = OrdenMedica.Instancia()

        LimpiarDatos()
        cargarComboRass()
        cargarGrillaEscalaRass()
        cargarGrillaCamIcu()
        cargarTiposRiesgo()
        cargarGrillaRiesgo() ''
        GroupServi.Enabled = False
        op_PrioPos.Checked = True
        PnlImgCam.Visible = False
    End Sub

    Public Sub cargarComboRass()
        ''Configuracion del campo que maneja el codigo
        With txtCodRass
            .NombreCampoBuscado = "desc_rass"
            .NombreCampoBusqueda = "cod_rass"
            .ControlTextoEnlace = txtDescripRass
        End With

        ''Configuracion del campo que maneja la descripcion 
        With txtDescripRass
            .NombreCampoDatos = "desc_rass"
            .ControlTextoEnlace = txtCodRass
            Try
                .OrigenDeDatos = BLEscalas.consultarTiposRass(datosconexion)
                .CargarDatosDescripcion()
            Catch ex As Exception
                MsgBox("Error en la consulta de los tipos de Rass. " & ex.Message, MsgBoxStyle.Information)
            End Try
        End With
    End Sub
    Public Sub cargarGrillaEscalaRass()
        Dim objBl As New Sophia.HistoriaClinica.BL.BLEscalas
        Dim dtRass As New DataTable
        objPaciente = Paciente.Instancia
        General = Generales.Instancia
        dtRass = objBl.ConsultarEscalasRass(objPaciente.CodHistoria, datosconexion)
        dtgRass.DataSource = dtRass

    End Sub

    Private Sub LimpiarDatos()
        txtCodRass.ResetText()
        txtDescripRass.ResetText()
    End Sub


    Public Sub LimpiarPanel(ByVal objPanel As Panel, ByVal ctrlExcept As Control)
        Dim control As Control
        Dim ckControl As CheckBox

        For Each control In objPanel.Controls
            If Not control.Equals(ctrlExcept) Then
                If TypeOf control Is TextBoxConFormato Then
                    control.Text = ""
                End If
                If TypeOf control Is ComboBox Or TypeOf control Is ComboBusqueda Then
                    control.Text = ""
                End If
                If TypeOf control Is TextBox Then
                    control.Text = ""
                End If
                If TypeOf control Is CheckBox Then
                    ckControl = CType(control, CheckBox)
                    ckControl.Checked = False
                End If
            End If
        Next

    End Sub

    Private Sub cmdGuardarMC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGuardarMC.Click
        Dim dtRass As DataTable
        If IsNothing(dtgRass) Then
            Exit Sub
        End If

        dtRass = dtgRass.DataSource
        If dtRass Is Nothing Then
            Exit Sub
        End If

        Dim mensaje As String = ""
        If Not BLEscalas.validarEscalas(txtCodRass.Text, txtDescripRass.Text, dtRass, mensaje) Then
            MsgBox(mensaje, MsgBoxStyle.Information)
            txtCodRass.Focus()
            Exit Sub
        Else
            AlmacenarRass()
            LimpiarDatos()
            txtCodRass.Focus()
        End If

    End Sub

    Private Sub AlmacenarRass()
        Dim dtgrillaRass As New DataTable
        Dim dtRass As New DataTable
        Dim lError As Long

        Dim objBl As New Sophia.HistoriaClinica.BL.BLEscalas

        ControlGrabar = 1
        If MessageBox.Show("Una vez el dato sea guardado no podra se modificado,desea continuar con la transaccion?", "Historia Clinica", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            datosconexion = objCon.Instancia
            General = objGeneral.Instancia


            lError = objBl.GrabarEscalasRass(datosconexion, objPaciente.CodHistoria, _
                        txtCodRass.Text, General.Login)

            If lError <> 0 Then
                MsgBox("Error en el proceso de grabación", MsgBoxStyle.Information)
            Else
                MsgBox("Grabación Exitosa.", MsgBoxStyle.Information)
                datosSinAlmacenar = False
                cargarGrillaEscalaRass()
            End If

        End If
    End Sub

    Public Sub cargarGrillaCamIcu()
        Dim objBl As New Sophia.HistoriaClinica.BL.BLEscalas
        Dim dtCamIcu As New DataTable
        objPaciente = Paciente.Instancia
        General = Generales.Instancia
        dtCamIcu = objBl.ConsultarCamIcu(objPaciente.CodHistoria, datosconexion)
        dtgCamIcu.DataSource = dtCamIcu

    End Sub

    Public Sub cargarGrillaRiesgo()
        Dim objBl As New Sophia.HistoriaClinica.BL.BLEscalas
        Dim dtRiesgoD As New DataTable
        objPaciente = Paciente.Instancia
        General = Generales.Instancia

        dtRiesgoD = objBl.ConsultarRiesgo(objPaciente.CodHistoria, datosconexion)

        dtgRiesgoD.DataSource = dtRiesgoD

    End Sub

    Public Sub cargarTiposRiesgo()
        Dim objBl As New Sophia.HistoriaClinica.BL.BLEscalas
        Dim dtRiesgo As New DataTable
        objPaciente = Paciente.Instancia
        General = Generales.Instancia

        dtRiesgo = BLEscalas.consultarTiposRiesgo(datosconexion)
        dtgRiesgo.DataSource = dtRiesgo

    End Sub

    Private Sub cmdGuardarCi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGuardarCi.Click

        Dim dtCamIcu As DataTable
        If IsNothing(dtgCamIcu) Then
            Exit Sub
        End If

        dtCamIcu = dtgRass.DataSource
        If dtCamIcu Is Nothing Then
            Exit Sub
        End If

        Dim mensaje As String = ""
        AlmacenarCamIcu()
        LimpiarDatos()

    End Sub
    Private Sub AlmacenarCamIcu()

        Dim strCamIcu As String
        Dim strCamIcu2 As String
        Dim lError As Long

        Dim objBl As New Sophia.HistoriaClinica.BL.BLEscalas


        If Me.op_PrioNeg.Checked = True Then
            strCamIcu = "N"
            strCamIcu2 = ""

            GroupServi.Enabled = False
        Else
            strCamIcu = "S"
            GroupServi.Enabled = True
            If Me.op_TipoHiper.Checked = True Then
                strCamIcu2 = "S"
            Else
                strCamIcu2 = "N"
            End If
        End If
        ControlGrabar = 1
        If MessageBox.Show("Una vez el dato sea guardado no podra se modificado,desea continuar con la transaccion?", "Historia Clinica", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            datosconexion = objCon.Instancia
            General = objGeneral.Instancia


            lError = objBl.GrabarEscalaCamIcu(datosconexion, objPaciente.CodHistoria, _
                        strCamIcu, strCamIcu2, General.Login)

            If lError <> 0 Then
                MsgBox("Error en el proceso de grabación", MsgBoxStyle.Information)
            Else
                MsgBox("Grabación Exitosa.", MsgBoxStyle.Information)
                datosSinAlmacenar = False
                cargarGrillaCamIcu()
            End If
        End If
    End Sub
    Private Sub cmdGuardarRiesgo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGuardarRiesgo.Click

        Dim dtRiesgoD As DataTable
        If IsNothing(dtgRiesgoD) Then
            Exit Sub
        End If

        dtRiesgoD = dtgRiesgoD.DataSource
        If dtRiesgoD Is Nothing Then
            Exit Sub
        End If
        Dim mensaje As String = ""
        AlmacenarRiesgo()
        LimpiarDatos()
    End Sub
    Private Sub AlmacenarRiesgo()

        Dim lError As Long

        Dim objBl As New Sophia.HistoriaClinica.BL.BLEscalas

        ControlGrabar = 1
        If MessageBox.Show("Una vez el dato sea guardado no podra se modificado,desea continuar con la transaccion?", "Historia Clinica", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            datosconexion = objCon.Instancia
            General = objGeneral.Instancia
            lError = objBl.GrabarEscalaRiesgo(datosconexion, objPaciente.CodHistoria, _
                        dtgRiesgo.DataSource, General.Login)


            If lError <> 0 Then
                MsgBox("Error en el proceso de grabación", MsgBoxStyle.Information)
            Else
                MsgBox("Grabación Exitosa.", MsgBoxStyle.Information)
                datosSinAlmacenar = False
                cargarGrillaRiesgo()


            End If

        End If
    End Sub

    Private Sub op_PrioNeg_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles op_PrioNeg.CheckedChanged
        GroupServi.Enabled = False
    End Sub

    Private Sub op_PrioPos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles op_PrioPos.CheckedChanged
        GroupServi.Enabled = True
    End Sub

    Private Sub cmdCollapse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCollapse.Click

        'If PnlImgCam.Visible = True Then
        Dim objPaciente As Paciente = Paciente.Instancia

        If PnlImgCam.Visible = True Then
            PnlImgCam.Visible = False
            cmdCollapse.Image = My.Resources.Collapse
            'pnlCamIcu.Height = 100 ''PnlImgCam.Height
            'lblDatosPaciente.Text = "Documento : " & objPaciente.TipoDocumento.Trim & " No. " & objPaciente.NumeroDocumento.Trim & "     Nombre : " & objPaciente.NombreCompleto
            'lblDatosPaciente.Visible = True
        Else
            PnlImgCam.Visible = True
            cmdCollapse.Image = My.Resources.Expand
            'pnlCamIcu.Height = 200 ''PnlImgCam.Height
            'lblDatosPaciente.Text = ""
            'lblDatosPaciente.Visible = False
        End If
    End Sub
End Class
