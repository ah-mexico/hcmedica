Imports System.IO
Imports System.Collections
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports System.Collections.ArrayList

Imports System.Windows.Forms
Imports System.Collections.Generic
Imports HistoriaClinica.Sophia.HistoriaClinica.HistoriaBasica
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports HistoriaClinica.wsCuidadoPaliativo

Public Class CtlReunionFamiliar
    Public objReunionFam As New BLReunionFamiliar()
    Public CtlReuFamiliar As CtlReunionFamiliar
    Private Shared _Instancia As CtlReunionFamiliar
    Private objGeneral As Generales
    Private objPaciente As Paciente
    Private objConexion As Conexion
    Private objReunionFamDAO As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOReunionFamiliar
    Public strNombreParticipanteEliminar As String = String.Empty
    Public strNombreCaracteristicaParticipanteEliminar As String = String.Empty
	Private lstPreguntasReunionFamilias As List(Of PreguntaCP)

#Region "Instancia de Control"
    Public Shared ReadOnly Property Instancia() As CtlReunionFamiliar
        Get
            If _Instancia Is Nothing Then
                _Instancia = New CtlReunionFamiliar
            End If
            Return _Instancia
        End Get
    End Property
#End Region

    Private Sub CtlReunionFamiliar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        objGeneral = Generales.Instancia
        objPaciente = Paciente.Instancia
        objConexion = Conexion.Instancia

        With objReunionFam
            .NumDocumento = objPaciente.NumeroDocumento
            .TipoDocumento = objPaciente.TipoDocumento
            .Sucursal = objGeneral.Sucursal
            .TipoAdmision = objPaciente.TipoAdmision
            .AnioAdmision = objPaciente.AnoAdmision
            .NumAdmision = objPaciente.NumeroAdmision
            .Login = objGeneral.Login
            .Prestador = objGeneral.Prestador
        End With

        Try
            cboEspecialidad.ResetText()
            cboEspecialidad.BeginUpdate()
            CargarComboEspecialidades()
        Catch ex As Exception
            MsgBox("Error en la consulta de Especialidades. " & ex.Message, MsgBoxStyle.Information)
        End Try

        Try
            cboVinculoPaciente.ResetText()
            cboVinculoPaciente.BeginUpdate()
            CargarComboVinculoPaciente()
        Catch ex As Exception
            MsgBox("Error en la consulta de Especialidades. " & ex.Message, MsgBoxStyle.Information)
        End Try

        CtlReuFamiliar = CtlReunionFamiliar.Instancia
    End Sub

    Private Sub CargarComboEspecialidades()
        Dim dt As New DataTable
        dt = objReunionFamDAO.CargarEspecialidades(602)
        If dt.Rows.Count = 0 Then
            MessageBox.Show("Error al Cargar Especialidades", "Historia Clínica", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
        End If
        cboEspecialidad.DataSource = dt

        cboEspecialidad.DisplayMember = "descripcion"
        cboEspecialidad.ValueMember = "id"
        cboEspecialidad.EndUpdate()
        cboEspecialidad.SelectedIndex = -1
    End Sub

    Private Sub CargarComboVinculoPaciente()
        Dim dt As New DataTable
        dt = objReunionFamDAO.CargarTipoParentesco()
        If dt.Rows.Count = 0 Then
            MessageBox.Show("Error al Cargar los Tipos de Parentesco", "Historia Clínica", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
        End If
        cboVinculoPaciente.DataSource = dt

        cboVinculoPaciente.DisplayMember = "Descripcion"
        cboVinculoPaciente.ValueMember = "IdParentesco"
        'cboVinculoPaciente.ValueMember = "par_respon"
        cboVinculoPaciente.EndUpdate()
        cboVinculoPaciente.SelectedIndex = -1
    End Sub

    Private Sub cmdAdicionarMiembrosParticipantes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdicionarMiembrosParticipantes.Click
        If ValidarCamposText(txtNombreProfesional) = False OrElse Not cboEspecialidad.SelectedIndex >= 0 Then
            MessageBox.Show("Falta Información en Campo Obligatorio", "Historia Clínica", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
            Exit Sub
        End If
        AdicionarMiembros("Profesional")
    End Sub

    Private Sub cmdAdicionarFamiliaresParticipantes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdicionarFamiliaresParticipantes.Click
        If ValidarCamposText(txtNombreFamiliar) = False OrElse Not cboVinculoPaciente.SelectedIndex >= 0 Then
            MessageBox.Show("Falta Información en Campo Obligatorio", "Historia Clínica", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
            Exit Sub
        End If
        AdicionarMiembros("Familiar")
    End Sub

    Private Function ValidarCamposText(ByVal txtVal As TextBox) As Boolean
        Dim blnRespuesta As Boolean = True
        If (Len(txtVal.Text) <= 0) Then
            Return False
        End If
        Return blnRespuesta
    End Function
    '''WACHV, 25SEPT2017, Valida que que no exista repetido el Familiar con el mismo Nombre
    Private Function bValidarFamiliaresRepetidos(strNombre As String, strCaracteristica As String) As Boolean
        Dim bExisteRegistro As Boolean = False

        For Each linea As DataGridViewRow In grdFamiliaresParticipantes.Rows
            If linea.Cells(1).Value.ToString.Equals(strNombre) And linea.Cells(2).Value.ToString.Equals(strCaracteristica) Then
                bExisteRegistro = True
                bValidarFamiliaresRepetidos = bExisteRegistro
                Exit Function
            End If
        Next
        bValidarFamiliaresRepetidos = bExisteRegistro

    End Function


    Private Function AdicionarMiembros(ByVal tipoMiembro As String) As Boolean
        Dim objEquipoReunion As New BLParticipantesReunion()
        With objEquipoReunion
            Select Case tipoMiembro
                Case "Profesional"
                    .IdPreguntaNombre = 601
                    .IdRespuestaNombre = 60101
                    .NombreParticipante = txtNombreProfesional.Text

                    .IdPreguntaCaracteristica = 602
                    .IdCaracteriscitaParticipante = cboEspecialidad.SelectedValue
                    .NombreCaracteristicaParticipante = String.Empty

                    objReunionFam.ParticipantesEquipoReunion.Add(objEquipoReunion)
                    grdMiembrosParticipantes.Rows.Insert(0, .IdCaracteriscitaParticipante, txtNombreProfesional.Text, cboEspecialidad.Text)
                    txtNombreProfesional.ResetText()
                    cboEspecialidad.SelectedIndex = -1
                    txtNombreProfesional.Focus()

                Case "Familiar"
                    ''WACHV,25092017, INICIO VALIDAR QUE NO SE REPITA EL FAMILIAR
                    If bValidarFamiliaresRepetidos(txtNombreFamiliar.Text, cboVinculoPaciente.Text) = False Then
                        .IdPreguntaNombre = 603
                        .IdRespuestaNombre = 60301
                        .NombreParticipante = txtNombreFamiliar.Text

                        .IdPreguntaCaracteristica = 604
                        .IdCaracteriscitaParticipante = 60401
                        .NombreCaracteristicaParticipante = cboVinculoPaciente.SelectedValue


                        objReunionFam.ParticipantesFamiliaReunion.Add(objEquipoReunion)
                        grdFamiliaresParticipantes.Rows.Insert(0, .IdCaracteriscitaParticipante, txtNombreFamiliar.Text, cboVinculoPaciente.Text)
                        txtNombreFamiliar.ResetText()
                        cboVinculoPaciente.SelectedIndex = -1
                        txtNombreFamiliar.Focus()
                    Else
                        MessageBox.Show("Registro ya Existe!", "Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If  ''WACHV,25092017, FIN VALIDAR QUE NO SE REPITA EL FAMILIAR

                    txtNombreFamiliar.Focus()
            End Select
        End With
    End Function

    Private Sub grdMiembrosParticipantes_UserDeletedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles grdMiembrosParticipantes.UserDeletedRow, grdFamiliaresParticipantes.UserDeletedRow
        Dim objEliminar As New BLParticipantesReunion()
        With objEliminar
            For index As Integer = 0 To e.Row.Cells.Count - 1
                Select Case e.Row.Cells(index).OwningColumn.Name
                    Case "IdEspecialidad", "IdVinculoPaciente"
                        .IdCaracteriscitaParticipante = e.Row.Cells(index).Value
                    Case "NombreProfesional", "NombreFamiliar"
                        .NombreParticipante = e.Row.Cells(index).Value
                        strNombreParticipanteEliminar = .NombreParticipante
                    Case "NombreEspecialidad", "VinculoPaciente"
                        .NombreCaracteristicaParticipante = e.Row.Cells(index).Value
                        strNombreCaracteristicaParticipanteEliminar = .NombreCaracteristicaParticipante
                End Select
            Next
            If DirectCast(sender, DataGridView).Name.Equals("grdMiembrosParticipantes") Then
                objReunionFam.ParticipantesEquipoReunion.RemoveAll(AddressOf EliminarRegistroParticipantes)
            Else
                objReunionFam.ParticipantesFamiliaReunion.RemoveAll(AddressOf EliminarRegistroParticipantes)
            End If
        End With
    End Sub

    Private Function EliminarRegistroParticipantes(ByVal objPartEquReun As BLParticipantesReunion) _
        As Boolean
        Return IIf(objPartEquReun.NombreParticipante.Equals(strNombreParticipanteEliminar) _
        AndAlso objPartEquReun.NombreCaracteristicaParticipante.Equals(strNombreCaracteristicaParticipanteEliminar), True, False)
    End Function
	
	Private Sub LimpiarDatos()
        txtNombreProfesional.ResetText()
        cboEspecialidad.SelectedIndex = -1
        cboEspecialidad.DataSource = Nothing
        CargarComboEspecialidades()
        grdMiembrosParticipantes.Rows.Clear()
        grdMiembrosParticipantes.DataSource = Nothing

        txtNombreFamiliar.ResetText()
        cboVinculoPaciente.SelectedIndex = -1
        cboVinculoPaciente.DataSource = Nothing
        CargarComboVinculoPaciente()
        grdFamiliaresParticipantes.Rows.Clear()
        grdFamiliaresParticipantes.DataSource = Nothing

        txtInfoReunion.ResetText()
        txtPreocEmergentes.ResetText()
        txtTemasPendientes.ResetText()
        txtEstrategiasSeguir.ResetText()
        strNombreCaracteristicaParticipanteEliminar = String.Empty
        strNombreParticipanteEliminar = String.Empty
    End Sub

    Private Sub cmdGuardarRF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGuardarRF.Click
        Dim strMensajeError As String
        Try
            cmdGuardarRF.Enabled = False
            cmdGuardarRF.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_guardar_apagado
            With objReunionFam
                .InformacionReunion = txtInfoReunion.Text
                .PreocupacionesDificultadesEmergentes = txtPreocEmergentes.Text
                .TemasPendientes = txtTemasPendientes.Text
                .EstrategiasASeguir = txtEstrategiasSeguir.Text
            End With

            strMensajeError = objReunionFamDAO.DAOActualizarDataReunionFamiliar(objReunionFam)

            If strMensajeError.Length = 0 Then
                MessageBox.Show("Registro Guardado!", "Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LimpiarDatos()
            End If
        Catch ex As Exception
            MessageBox.Show("No fue posible registrar la información sobre Reunión Familiar de este paciente." _
            + Environment.NewLine + Environment.NewLine + "Mensaje de Error: " + IIf(ex.Message Is Nothing, String.Empty, ex.Message), _
            "Historia Clínica", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
        Finally
            cmdGuardarRF.Enabled = True
            cmdGuardarRF.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_guardar
        End Try
    End Sub
	
	Private Sub btnSugerirRespuesta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSugerirRespuesta.Click
        Dim srvWs As New CuidadosPaleativosServiceImpService()
        Dim oReunionFamiliar As New BLReunionFamiliar()
        Dim oPreguntaReunionFamiliar As New PreguntaCP()
        Dim falloWS As Boolean = False
        Dim falloDB As Boolean = False
        Dim strMessage As String

        Try

            lstPreguntasReunionFamilias = oReunionFamiliar.ConsultarPreguntas(New PreguntaCP)

            If lstPreguntasReunionFamilias.Count > 0 Then
                Dim aPreUltRespuesta(lstPreguntasReunionFamilias.Count - 1) As Long
                Dim aUltimaRespuesta(lstPreguntasReunionFamilias.Count - 1) As PreguntaType
                Dim DAOCP As New DAOCuidadosPaliativos()
                Dim Resultado As String = String.Empty
                Dim appOrigen As String = Paciente.AppOrigenCP.ToUpper()

                srvWs.Url = DAOCP.ConsultarUrlServicioUT(objGeneral.Prestador, objGeneral.Sucursal, "CP", "ultimasrespuestas")

                If srvWs.Url <> "" Then
                Else
                    MessageBox.Show("No fue posible consultar el servicio de últimas respuestas.", "Historia Clínica", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
                    Exit Sub
                End If

                For i As Integer = 0 To lstPreguntasReunionFamilias.Count - 1
                    aPreUltRespuesta(i) = lstPreguntasReunionFamilias.Item(i).id
                Next

                'srvWs.Url = "http://BOAD100DESAR026:8880/CuidadosPaleativosWS/CuidadosPaleativosService"

                'Resultado = srvWs.ultimasRespuestas(objPaciente.TipoDocumento, "52259800", aPreUltRespuesta, "AVICENA", "BOGOTA", aUltimaRespuesta)
                ''WACHV, 22Dic2017, Se agrega Obtener la ref regional en cada Bd
                '',se cambia parametro de regional objPaciente.Ciudad.ToUpper() por lo retornado en strRegionalRefBD
                Dim strRegionalRefBD As String = DAOCP.ConsultarRegional()
                Resultado = srvWs.ultimasRespuestas(objPaciente.TipoDocumento, objPaciente.NumeroDocumento,
                aPreUltRespuesta, appOrigen, strRegionalRefBD.ToUpper(), aUltimaRespuesta)

                oReunionFamiliar = oReunionFamiliar.ObtenerUltimaRespuesta(aUltimaRespuesta)

            End If
        Catch ex As Exception
            'strMessage = "No fue posible consultar algunas de las últimas respuestas de este paciente."
            'falloWS = True
            'MessageBox.Show("No fue posible consultar las últimas respuestas de este paciente.", "Historia Clínica", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
        End Try

        Try
            Dim participante As BLParticipantesReunion
            Dim tmpDtProfesionales As DataTable = oReunionFamiliar.obtenerParticipantesReunion(objPaciente.TipoDocumento, objPaciente.NumeroDocumento, "Profesional")
            oReunionFamiliar.ParticipantesEquipoReunion.Clear()
            For Each row As DataRow In tmpDtProfesionales.Rows
                participante = New BLParticipantesReunion()
                With participante
                    .IdPreguntaNombre = row("IdPreguntaNombre")
                    .IdRespuestaNombre = row("IdRespuestaNombre")
                    .NombreParticipante = row("NombreParticipante")
                    .IdPreguntaCaracteristica = iif(row("IdPreguntaCaracteristica").ToString.Length = 0,0,row("IdPreguntaCaracteristica"))
                    .IdCaracteriscitaParticipante = IIf(row("IdCaracteriscitaParticipante").ToString.Length = 0, 0, row("IdCaracteriscitaParticipante"))
                    .NombreCaracteristicaParticipante = IIf(row("NombreCaracteristicaParticipante").ToString.Length = 0, 0, row("NombreCaracteristicaParticipante"))
                End With
                oReunionFamiliar.ParticipantesEquipoReunion.Add(participante)
            Next

            Dim tmpDtFamiliares As DataTable = oReunionFamiliar.obtenerParticipantesReunion(objPaciente.TipoDocumento, objPaciente.NumeroDocumento, "Familiar")
            oReunionFamiliar.ParticipantesFamiliaReunion.Clear()
            For Each row As DataRow In tmpDtFamiliares.Rows
                participante = New BLParticipantesReunion()
                With participante
                    .IdPreguntaNombre = row("IdPreguntaNombre")
                    .IdRespuestaNombre = row("IdRespuestaNombre")
                    .NombreParticipante = row("NombreParticipante")
                    .IdPreguntaCaracteristica = IIf(row("IdPreguntaCaracteristica").ToString.Length = 0, 0, row("IdPreguntaCaracteristica"))
                    .IdCaracteriscitaParticipante = IIf(row("IdCaracteriscitaParticipante").ToString.Length = 0, 0, row("IdCaracteriscitaParticipante"))
                    .NombreCaracteristicaParticipante = IIf(row("NombreCaracteristicaParticipante").ToString.Length = 0, 0, row("NombreCaracteristicaParticipante"))
                End With
                oReunionFamiliar.ParticipantesFamiliaReunion.Add(participante)
            Next

            loadReunionFamiliar(oReunionFamiliar)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub loadReunionFamiliar(ByRef oReunionFamiliar As BLReunionFamiliar)
        With oReunionFamiliar
            If Not .InformacionReunion = String.Empty Then
                txtInfoReunion.Text = .InformacionReunion
            End If
            If Not .PreocupacionesDificultadesEmergentes = String.Empty Then
                txtPreocEmergentes.Text = .PreocupacionesDificultadesEmergentes
            End If
            If Not .TemasPendientes = String.Empty Then
                txtTemasPendientes.Text = .TemasPendientes
            End If
            If Not .EstrategiasASeguir = String.Empty Then
                txtEstrategiasSeguir.Text = .EstrategiasASeguir
            End If

            Dim rowsPart() As DataRow
            grdMiembrosParticipantes.Rows.Clear()
            If .ParticipantesEquipoReunion.Count > 0 Then
                For Each preg As BLParticipantesReunion In .ParticipantesEquipoReunion
                    rowsPart = DirectCast(cboEspecialidad.DataSource, DataTable).Select("id=" + preg.IdCaracteriscitaParticipante.ToString())
                    If rowsPart.Length > 0 Then
                        grdMiembrosParticipantes.Rows.Insert(0, preg.IdCaracteriscitaParticipante, preg.NombreParticipante, rowsPart(0)("descripcion"))
                    End If
                Next
            End If
            grdFamiliaresParticipantes.Rows.Clear()
            If .ParticipantesFamiliaReunion.Count > 0 Then
                For Each preg As BLParticipantesReunion In .ParticipantesFamiliaReunion
                    rowsPart = DirectCast(cboVinculoPaciente.DataSource, DataTable).Select("IdParentesco='" + preg.NombreCaracteristicaParticipante + "'")
                    If rowsPart.Length > 0 Then
                        grdFamiliaresParticipantes.Rows.Insert(0, preg.IdCaracteriscitaParticipante, preg.NombreParticipante, rowsPart(0)("descripcion"))
                    End If
                Next
            End If
        End With
    End Sub
End Class
