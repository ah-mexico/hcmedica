Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales

Public Class frmOrdenPatologia
    Private objPaciente As Paciente
    Private objGeneral As Generales
    Private objDaoQx As New DAODescripcionQX
    Private dtprocedim As DataTable
    Private objConexion As Sophia.HistoriaClinica.DatosConexion.Conexion
    Private dtdiagnosticoPre As DataTable
    Private dtdiagnosticoPos As DataTable
    Private objQx As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAODescripcionQX
    Private objQxManejaDatos As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAODescripcionQXManejoDeDatos
    Private objDescrQx As DescripcionQuirurgica
    Private cod_especialidad As String
    Dim objHcEncabezado As New Sophia.HistoriaClinica.Reportes.HCEncabezado()






    Public Sub Mostrar(ByVal dtProce As DataTable, ByVal dtPreoperatorio As DataTable, ByVal dtpostoperatorio As DataTable)
        dtprocedim = dtProce
        dtpostoperatorio.Merge(dtPreoperatorio)
        dtdiagnosticoPre = dtPreoperatorio
        dtdiagnosticoPos = dtpostoperatorio
        Me.ShowDialog()
    End Sub

    Private Sub frmOrdenPatologia_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        txtHallazgos.Text = ""
        TxtOrgano.Text = ""
        txtestudio.Text = ""
        CargarInfo()

    End Sub

    Private Sub CargarInfo()
        Dim fechaSol As DateTime
        Dim dtmedico As DataTable = Nothing
        Dim dtseccion As DataTable = Nothing
        Dim dt As DataTable = Nothing

        Me.lblmensaje1.Visible = False
        Me.Lblmensaje2.Visible = False
        Me.Lblmensaje3.Visible = False
        Me.Lblmensaje4.Visible = False
        Me.Lblmensaje5.Visible = False
        Me.Lblmensaje6.Visible = False
        Me.lblmensaje7.Visible = False
        Me.lblmensaje8.Visible = False
        Me.Lblmensaje9.Visible = False
        Me.Lblmensaje10.Visible = False


        objPaciente = Paciente.Instancia
        objGeneral = Generales.Instancia
        lblSucursal.Text = objGeneral.DescripcionSucursal & " - " & objGeneral.Sucursal
        lblPriApe.Text = objPaciente.PrimerApellido
        lblSegApe.Text = objPaciente.SegundoApellido
        lblPriNom.Text = objPaciente.PrimerNombre
        lblSegNom.Text = objPaciente.SegundoNombre
        lblTipDoc.Text = objPaciente.DescripcionTipoDocumento
        lblnumdoc.Text = objPaciente.NumeroDocumento
        lblcarnet.Text = objPaciente.Carnet
        Lblcama.Text = objPaciente.Cama
        lblGenero.Text = objPaciente.DescripcionGenero
        lblEdad.Text = objPaciente.Edad & " " & objPaciente.DescripcionUnidadMedidaEdad
        lblEntidad.Text = objPaciente.DescripcionEntidad
        Label24.Text = objPaciente.TipoAdmision & " " & objPaciente.AnoAdmision & " " & objPaciente.NumeroAdmision
        Me.txtpri_nomM.Text = objGeneral.NombreMedico
        lblRegistroM.Text = objGeneral.RegistroMedico



        Me.lblEspecialidad.Text = objGeneral.DescripcionEspecialidad
        cod_especialidad = objGeneral.CodigoEspecialidad
        Me.lblespecialidad.Text = objGeneral.DescripcionEspecialidad

        dt = objQx.CargarCombosDescQX(3, "")
        cmbEspecialidad.DataSource = dt
        cmbEspecialidad.DisplayMember = "descripcion"
        cmbEspecialidad.ValueMember = "especialidad"
        cmbEspecialidad.EndUpdate()

        lblespecialidad.DataSource = dt
        lblespecialidad.DisplayMember = "descripcion"
        lblEspecialidad.ValueMember = "especialidad"
        lblespecialidad.EndUpdate()

        Me.lblespecialidad.Text = objGeneral.DescripcionEspecialidad
        Me.cmbEspecialidad.Text = Me.lblEspecialidad.Text
        dtmedico = objDaoQx.ConsultaMedicoXDoc1(objGeneral.Login)

        txtpri_apeM.Text = dtmedico.Rows(0).Item("pri_ape").ToString
        txtseg_apeM.Text = dtmedico.Rows(0).Item("seg_ape").ToString
        txtpri_nomM.Text = dtmedico.Rows(0).Item("pri_nom").ToString
        txtseg_nomM.Text = dtmedico.Rows(0).Item("seg_nom").ToString
        txtMedico.Text = dtmedico.Rows(0).Item("medico").ToString
        dtgProcedim.DataSource = dtprocedim
        Me.dtgdiagnosticoPos.DataSource = dtdiagnosticoPos


        fechaSol = FuncionesGenerales.FechaServidor()

        mskFechaSolicitud.Text = Format(fechaSol, "dd/MM/yyyy")
        txtHora.Text = DatePart(DateInterval.Hour, fechaSol)
        txtMin.Text = DatePart(DateInterval.Minute, fechaSol)

        'Consulta las secciones 
        dtseccion = objDaoQx.ConsultarSeccion

        If dtseccion.Rows.Count = 0 Then
            MsgBox("No existen secciones parametrizadas")
        Else
            cmbSeccion.DataSource = dtseccion
            cmbSeccion.DisplayMember = "descripcion"
            cmbSeccion.ValueMember = "cod_seccion"
            cmbSeccion.EndUpdate()
            cmbSeccion.Text = ""
        End If

        'Consulta la Muestra 
        dtseccion = objDaoQx.ConsultarMuestra

        If dtseccion.Rows.Count = 0 Then
            MsgBox("No existen muestras parametrizadas")
        Else
            Cmbmuestra.DataSource = dtseccion
            Cmbmuestra.DisplayMember = "descripcion"
            Cmbmuestra.ValueMember = "cod_muestra"
            Cmbmuestra.EndUpdate()
            Cmbmuestra.Text = ""
        End If

    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim dtmedico As DataTable = Nothing
        Dim dt As DataTable = Nothing
        Dim frmConsultaT As New frmc_ConsultaMedicoQx(IIf(Len("") = 1, "", "P"))
        frmConsultaT.ShowDialog()
        If Len(frmConsultaT.CodigoMedico) > 0 Then
            Me.txtMedico.Text = frmConsultaT.CodigoMedico
            Me.txtpri_apeM.Text = frmConsultaT.pri_ape
            Me.txtpri_nomM.Text = frmConsultaT.pri_nom
            Me.txtseg_nomM.Text = frmConsultaT.seg_nom
            Me.txtseg_apeM.Text = frmConsultaT.seg_ape
            Me.txtMedico.Text = frmConsultaT.CodigoMedico
            lblRegistroM.Text = frmConsultaT.CodigoMedico

        Else
            lblRegistroM.Text = objGeneral.RegistroMedico
            dtmedico = objDaoQx.ConsultaMedicoXDoc1(objGeneral.Login)
            txtpri_apeM.Text = dtmedico.Rows(0).Item("pri_ape").ToString
            txtseg_apeM.Text = dtmedico.Rows(0).Item("seg_ape").ToString
            txtpri_nomM.Text = dtmedico.Rows(0).Item("pri_nom").ToString
            txtseg_nomM.Text = dtmedico.Rows(0).Item("seg_nom").ToString
            txtMedico.Text = dtmedico.Rows(0).Item("medico").ToString
        End If

        dt = objQx.CargarCombosDescQX(2, Me.txtMedico.Text)

        If dt.Rows.Count = 0 Then
            MsgBox("No existen especialidades parametrizadas para el médico seleccionado")
            Me.lblespecialidad.Text = String.Empty
        End If


        lblespecialidad.DataSource = dt

        Me.lblespecialidad.DisplayMember = "descripcion"
        lblespecialidad.ValueMember = "especialidad"
        lblespecialidad.EndUpdate()
        cod_especialidad = ""


    End Sub


    Private Sub btnGuardarDescripcionQx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarDescripcionQx.Click
        Dim strMensaje As String = ""
        Dim dtproced As DataTable = Nothing

        dtproced = Me.dtgProcedim.DataSource

        If Len(dtproced.Rows(0).Item("consecutivo")) = 0 Then
            MsgBox("No existen datos por almacenar")
            Exit Sub
        End If


        If Me.cmbEspecialidad.Text = "" Then
            Me.lblmensaje1.Visible = True
        End If
        If Me.mskFechaSolicitud.Text = "" Then
            Me.Lblmensaje2.Visible = True
        End If
        If Me.txtHora.Text = "" Or txtMin.Text = "" Then
            Me.Lblmensaje3.Visible = True
        End If
        If Me.txtHallazgos.Text = "" Then
            Me.Lblmensaje4.Visible = True
        End If
        If (Me.dtgProcedim.RowCount = 0) Then
            Me.Lblmensaje5.Visible = True
        End If
        If Me.cmbSeccion.Text = "" Then
            Me.Lblmensaje6.Visible = True
        End If
        If Me.TxtOrgano.Text = "" Then
            Me.lblmensaje7.Visible = True
        End If
        If Me.txtestudio.Text = "" Then
            Me.lblmensaje8.Visible = True
        End If
        If Me.Cmbmuestra.Text = "" Then
            Me.Lblmensaje9.Visible = True
        End If

        If cod_especialidad = "" Then
            cod_especialidad = Me.lblespecialidad.SelectedValue.ToString()
        End If

        If Me.cmbEspecialidad.Text = "" Or Me.mskFechaSolicitud.Text = "" Or Me.txtHora.Text = "" Or txtMin.Text = "" Or Me.txtHallazgos.Text = "" Or Me.dtgProcedim.RowCount = 0 Or Me.cmbSeccion.Text = "" Or Me.TxtOrgano.Text = "" Or Me.txtestudio.Text = "" Or Me.Cmbmuestra.Text = "" Then
            Exit Sub
        Else
            Try
                strMensaje = objQxManejaDatos.GuardarOrdenPatologia(objGeneral.Prestador, objGeneral.Sucursal, dtproced.Rows(0).Item("consecutivo"), mskFechaSolicitud.Text, Me.txtHora.Text, Me.txtMin.Text, _
                objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision, txtMedico.Text, cod_especialidad, txtHallazgos.Text, cmbSeccion.SelectedValue.ToString, TxtOrgano.Text, txtestudio.Text, Cmbmuestra.SelectedValue.ToString, dtproced.Rows(0).Item("procedimiento"), cmbEspecialidad.SelectedValue)

                If Len(strMensaje) = 0 Then
                    imprimirOrdendePatologia()
                    Me.Close()
                Else
                    MsgBox(strMensaje)
                    objQxManejaDatos.GrabarLogErrores(strMensaje, objGeneral.Sucursal, objGeneral.Login, objDescrQx.Consecutivo, objDescrQx.Procedimiento)

                End If

            Catch ex As Exception
                MsgBox("Error al guardar la orden de patologia  " & ex.Message)
                objQxManejaDatos.GrabarLogErrores(ex.Message, objGeneral.Sucursal, objGeneral.Login, objDescrQx.Consecutivo, objDescrQx.Procedimiento)

            End Try

        End If
    End Sub

    Private Sub imprimirOrdendePatologia()
        Dim frmRepOrdenP As New frmRepOrdenPatologia
        Dim dtproced As DataTable = Nothing

        dtproced = Me.dtgProcedim.DataSource

        frmRepOrdenP.imprimirOrdenPatologia(objGeneral.Prestador, objGeneral.Sucursal, _
        dtproced.Rows(0).Item("procedimiento"), dtproced.Rows(0).Item("consecutivo"), 20, objPaciente.TipoAdmision, objPaciente.AnoAdmision, _
        objPaciente.NumeroAdmision, objPaciente.TipoDocumento, objPaciente.NumeroDocumento)
        frmRepOrdenP.Show()
        'objDescrQx.Procedimiento
    End Sub

    Private Sub lblespecialidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cod_especialidad = ""
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub lblcarnet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblcarnet.Click

    End Sub






    Private Sub btnBuscarMedico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMedico.Click
        Dim dtmedico As DataTable = Nothing
        Dim dt As DataTable = Nothing
        Dim frmConsultaT As New frmc_ConsultaMedicoQx(IIf(Len("") = 1, "", "P"))
        frmConsultaT.ShowDialog()
        If Len(frmConsultaT.CodigoMedico) > 0 Then
            Me.txtMedico.Text = frmConsultaT.CodigoMedico
            Me.txtpri_apeM.Text = frmConsultaT.pri_ape
            Me.txtpri_nomM.Text = frmConsultaT.pri_nom
            Me.txtseg_nomM.Text = frmConsultaT.seg_nom
            Me.txtseg_apeM.Text = frmConsultaT.seg_ape
            Me.txtMedico.Text = frmConsultaT.CodigoMedico
            lblRegistroM.Text = frmConsultaT.CodigoMedico

        Else
            lblRegistroM.Text = objGeneral.RegistroMedico
            dtmedico = objDaoQx.ConsultaMedicoXDoc1(objGeneral.Login)
            txtpri_apeM.Text = dtmedico.Rows(0).Item("pri_ape").ToString
            txtseg_apeM.Text = dtmedico.Rows(0).Item("seg_ape").ToString
            txtpri_nomM.Text = dtmedico.Rows(0).Item("pri_nom").ToString
            txtseg_nomM.Text = dtmedico.Rows(0).Item("seg_nom").ToString
            txtMedico.Text = dtmedico.Rows(0).Item("medico").ToString
        End If

        dt = objQx.CargarCombosDescQX(2, Me.txtMedico.Text)

        If dt.Rows.Count = 0 Then
            MsgBox("No existen especialidades parametrizadas para el médico seleccionado")
            Me.lblespecialidad.Text = String.Empty
        End If


        lblespecialidad.DataSource = dt

        Me.lblespecialidad.DisplayMember = "descripcion"
        lblespecialidad.ValueMember = "especialidad"
        lblespecialidad.EndUpdate()
        cod_especialidad = ""
    End Sub

    Private Sub cmbEspecialidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEspecialidad.SelectedIndexChanged

    End Sub
End Class