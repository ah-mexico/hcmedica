Public Class frmCorreccionEF_tmp

    Private strPrestador As String
    Private strSucursal As String
    Private strNombrePaciente As String
    Private strTipoAdmision As String
    Private intAnoAdmision As String
    Private lNumeroAdmision As Long
    Private strTipoDocumento As String
    Private strNumeroDocumento As String
    Private strMedico As String
    Private strMedicoOriginal As String
    Private strFecha As String
    Private objConexion As Sophia.HistoriaClinica.DatosConexion.Conexion = Sophia.HistoriaClinica.DatosConexion.Conexion.Instancia
    Private dtDatos As DataTable
    Private blnRespuesta As Boolean
    Private intTotalHC As Integer
    Private intHCActual As Integer
    Private objPaciente As Sophia.HistoriaClinica.DatosPaciente.Paciente


    Private Sub frmCorreccionEF_tmp_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        'strPrestador = "1100109887"
        'strSucursal = "0139"
        'strTipoAdmision = "E"
        'intAnoAdmision = 2007
        'lNumeroAdmision = 5
        'strTipoDocumento = "TI"
        'strNumeroDocumento = "95101323502"
        'strMedico = "52263654"

        'Me.Text = "ALEJANDRO PAVA MOSQUERA - TI : 95101323502 (Admisión " & strTipoAdmision & " " & intAnoAdmision & " " & lNumeroAdmision & " - Fecha : " & "05/01/2007" & ")"
        dtDatos = objPaciente.HistoriasConErroresEF
        strPrestador = dtDatos.Rows(0).Item("cod_pre_sgs").ToString.Trim
        strSucursal = dtDatos.Rows(0).Item("cod_sucur").ToString.Trim
        strTipoAdmision = dtDatos.Rows(0).Item("tip_admision").ToString.Trim
        intAnoAdmision = dtDatos.Rows(0).Item("ano_adm")
        lNumeroAdmision = dtDatos.Rows(0).Item("num_adm")
        strTipoDocumento = dtDatos.Rows(0).Item("tip_doc").ToString.Trim
        strNumeroDocumento = dtDatos.Rows(0).Item("num_doc").ToString.Trim
        strMedico = dtDatos.Rows(0).Item("login").ToString.Trim
        strMedicoOriginal = dtDatos.Rows(0).Item("login_original").ToString.Trim
        strFecha = dtDatos.Rows(0).Item("fec_hc").ToString.Trim
        strNombrePaciente = objPaciente.PrimerNombre & " " & objPaciente.SegundoNombre & " " & objPaciente.PrimerApellido & " " & objPaciente.SegundoApellido

        Me.Text = strNombrePaciente & " - " & strTipoDocumento & " : " & _
                  strNumeroDocumento & " (Admisión " & strTipoAdmision & " " & intAnoAdmision & " " & lNumeroAdmision & " - Fecha Historia Clínica : " & strFecha & ")"

        tlbConfirmar.Enabled = True
        tlbReclasificar.Enabled = True

        intHCActual = 1

        intTotalHC = dtDatos.Rows.Count
        If intTotalHC > 1 Then
            tlbSiguiente.Visible = True
            tlbSiguiente.Enabled = False
            tlbSeparador.Visible = False
            tlbLabel.Text = intHCActual & "a. HC de " & intTotalHC & " para ser Revisadas."
            tlbLabel.Visible = True
        Else
            tlbSiguiente.Visible = False
            tlbSiguiente.Enabled = False
            tlbSeparador.Visible = False
            tlbLabel.Text = intHCActual & "a. HC de " & intTotalHC & " para ser Revisadas."
            tlbLabel.Visible = False
        End If
        dtgHallazgosEF_tmp.Columns("codcorrecto").ReadOnly = False
        ConsultarDatosHC()
    End Sub

    Private Sub ConsultarDatosHC()
        Dim dsDatosEF As DataSet
        Dim Datos() As Object
        Dim lError As Long
        Dim objDatos As New Sophia.HistoriaClinica.DAO.DAOGeneral



        'If Not objConexion Is Nothing Then
        '    objConexion.strServidor = "PRUEBASDESA"
        '    objConexion.strBaseDatos = "SOPHIA"
        '    objConexion.strUsuarioBD = "SOPHIA"
        '    objConexion.strClaveUsuarioBD = "SOPHIA"
        '    objConexion.EstadoInstancia = True
        'End If

        ReDim Datos(28)
        Datos(0) = 3
        Datos(1) = strPrestador
        Datos(2) = strSucursal
        Datos(3) = strTipoAdmision
        Datos(4) = intAnoAdmision
        Datos(5) = lNumeroAdmision
        Datos(6) = strTipoDocumento
        Datos(7) = strNumeroDocumento
        Datos(8) = ""
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
        Datos(25) = ""
        Datos(26) = ""
        Datos(27) = strMedicoOriginal
        Datos(28) = lError

        Try
            dsDatosEF = objDatos.EjecutarSPConParametrosDataSet("HC_CorregirExamenFisico", objConexion, lError, Datos)
            If lError <> 0 Then
                MessageBox.Show("Error al Consultar Datos Historia Clínica")
            Else
                ActualizarInformacionExamenFisico(dsDatosEF.Tables(0), dsDatosEF.Tables(1), dsDatosEF.Tables(2))
                GuardarEstadoActualControles()
            End If
        Catch ex As Exception
            MessageBox.Show("Error al Consultar Datos Historia Clinica")
        End Try

    End Sub


    Public Function Mostrar() As Boolean

        objPaciente = Sophia.HistoriaClinica.DatosPaciente.Paciente.Instancia
        Me.ShowDialog()
        objPaciente.HistoriasConErroresEF = dtDatos
        Return blnRespuesta

    End Function

    Private Sub ActualizarInformacionExamenFisico(ByVal dtMotivoConsulta As DataTable, ByVal dtDiagnosticosID As DataTable, ByVal dtExamenFisico As DataTable)
        Dim strTexto As String
        Dim intRow As Integer

        Dim font1 As New Font(txtDatosMotivoConsulta.Font, FontStyle.Regular)
        txtDatosMotivoConsulta.Font = font1

        strTexto = "MOTIVO DE CONSULTA    : " & vbCrLf & _
                   dtMotivoConsulta.Rows(0).Item("mot_consulta").ToString.Trim.ToUpper & vbCrLf & vbCrLf & _
                   "ENFERMEDAD ACTUAL     : " & vbCrLf & _
                   dtMotivoConsulta.Rows(0).Item("enf_actual").ToString.Trim.ToUpper & vbCrLf & vbCrLf & _
                   "IMPRESION DIAGNOSTICA : " & vbCrLf

        For intRow = 0 To dtDiagnosticosID.Rows.Count - 1
            strTexto = strTexto & " - " & dtDiagnosticosID.Rows(intRow).Item("descripcion").ToString & vbCrLf
        Next

        With txtDatosMotivoConsulta
            .Text = strTexto
            .SelectionStart = .Find("MOTIVO DE CONSULTA    : ")
            Dim ifont As New Font(.Font, FontStyle.Bold)
            .SelectionFont = ifont
            .SelectionStart = .Find("ENFERMEDAD ACTUAL     : ")
            .SelectionFont = ifont
            .SelectionStart = .Find("IMPRESION DIAGNOSTICA : ")
            .SelectionFont = ifont
        End With

        dtExamenFisico.Columns.Add("CopiaCod", System.Type.GetType("System.String"))
        dtExamenFisico.Columns.Add("CodVieneDe", System.Type.GetType("System.String"))
        dtExamenFisico.DefaultView.Sort = "sistema"

        Me.dtgHallazgosEF_tmp.DataSource = dtExamenFisico

    End Sub

    Private Sub GuardarEstadoActualControles()
        Dim intRow As Integer

        For intRow = 0 To dtgHallazgosEF_tmp.Rows.Count - 1
            dtgHallazgosEF_tmp.Rows(intRow).Cells("CopiaCodEFTMP").Value = dtgHallazgosEF_tmp.Rows(intRow).Cells("CodCorrecto").Value
        Next

    End Sub

    Private Sub dtgHallazgosEF_tmp_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgHallazgosEF_tmp.CellValidated
        Dim intRow As Integer
        Dim strDato As String

        If e.ColumnIndex = 3 Then
            If dtgHallazgosEF_tmp.Rows(e.RowIndex).Cells("codcorrecto").Value.ToString.Trim.Length > 0 Then
                strDato = dtgHallazgosEF_tmp.Rows(e.RowIndex).Cells("codcorrecto").Value.ToString.Trim
                For intRow = 0 To dtgHallazgosEF_tmp.Rows.Count - 1
                    If intRow <> e.RowIndex Then
                        If dtgHallazgosEF_tmp.Rows(intRow).Cells("codcorrecto").Value = strDato Then
                            MessageBox.Show("El Código Digitado ya ha sido reclasificado", "Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            dtgHallazgosEF_tmp.Rows(e.RowIndex).Cells("codcorrecto").Value = ""
                            Exit Sub
                        End If
                    End If
                Next
                dtgHallazgosEF_tmp.Rows(e.RowIndex).Cells("obsEFTMP").ErrorText = ""
                dtgHallazgosEF_tmp.Rows(e.RowIndex).Cells("CodVieneDe").Value = ""
                If dtgHallazgosEF_tmp.Rows(e.RowIndex).Cells("codcorrecto").Value <> dtgHallazgosEF_tmp.Rows(e.RowIndex).Cells("sistemaEFTMP").Value Then
                    For intRow = 0 To dtgHallazgosEF_tmp.Rows.Count - 1
                        If dtgHallazgosEF_tmp.Rows(intRow).Cells("CodVieneDe").Value.ToString = dtgHallazgosEF_tmp.Rows(e.RowIndex).Cells("sistemaEFTMP").Value.ToString Then
                            dtgHallazgosEF_tmp.Rows(intRow).Cells("obsEFTMP").ErrorText = ""
                            dtgHallazgosEF_tmp.Rows(intRow).Cells("CodVieneDe").Value = ""
                            Exit For
                        End If
                    Next
                    intRow = Val(dtgHallazgosEF_tmp.Rows(e.RowIndex).Cells("codcorrecto").Value) - 1
                    If dtgHallazgosEF_tmp.Rows(intRow).Cells("obsEFTMP").Value.ToString.Trim.Length > 0 And _
                       dtgHallazgosEF_tmp.Rows(intRow).Cells("codcorrecto").Value.ToString.Trim.Length = 0 Then
                        dtgHallazgosEF_tmp.Rows(intRow).Cells("obsEFTMP").ErrorText = "Este Dato Debe Ser Reclasificado"
                        dtgHallazgosEF_tmp.Rows(intRow).Cells("CodVieneDe").Value = dtgHallazgosEF_tmp.Rows(e.RowIndex).Cells("sistemaEFTMP").Value
                    End If
                End If
            Else
                For intRow = 0 To dtgHallazgosEF_tmp.Rows.Count - 1
                    If dtgHallazgosEF_tmp.Rows(intRow).Cells("CodVieneDe").Value.ToString = dtgHallazgosEF_tmp.Rows(e.RowIndex).Cells("sistemaEFTMP").Value.ToString Then
                        dtgHallazgosEF_tmp.Rows(intRow).Cells("obsEFTMP").ErrorText = ""
                        dtgHallazgosEF_tmp.Rows(intRow).Cells("CodVieneDe").Value = ""
                        Exit For
                    End If
                Next
                If dtgHallazgosEF_tmp.Rows(e.RowIndex).Cells("obsEFTMP").Value.ToString.Trim.Length > 0 Then
                    For intRow = 0 To dtgHallazgosEF_tmp.Rows.Count - 1
                        If intRow <> e.RowIndex Then
                            If dtgHallazgosEF_tmp.Rows(intRow).Cells("codcorrecto").Value.ToString = dtgHallazgosEF_tmp.Rows(e.RowIndex).Cells("sistemaEFTMP").Value.ToString Then
                                dtgHallazgosEF_tmp.Rows(e.RowIndex).Cells("obsEFTMP").ErrorText = "Este Dato Debe Ser Reclasificado"
                                dtgHallazgosEF_tmp.Rows(e.RowIndex).Cells("CodVieneDe").Value = dtgHallazgosEF_tmp.Rows(intRow).Cells("sistemaEFTMP").Value
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub tlbReclasificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tlbReclasificar.Click
        Dim intRow As Integer


        For intRow = 0 To dtgHallazgosEF_tmp.Rows.Count - 1
            If dtgHallazgosEF_tmp.Rows(intRow).Cells("obsEFTMP").ErrorText.Trim.Length > 0 Then
                MessageBox.Show("No se puede reclasificar la información porque existen datos pendientes por clasificar." & vbCrLf & "Clasifique los datos que se encuentran marcados con la señal roja.", "Historia Clinica", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        Next

        Reclasificar()


    End Sub

    Private Sub Reclasificar()
        Dim intRow As Integer
        Dim Datos(2, 17) As String
        Dim intY As Integer
        '' '' ''Dim intActual As Integer

        For intRow = 0 To dtgHallazgosEF_tmp.Rows.Count - 1
            If dtgHallazgosEF_tmp.Rows(intRow).Cells("codcorrecto").Value.ToString.Trim.Length > 0 Then
                intY = (dtgHallazgosEF_tmp.Rows(intRow).Cells("codcorrecto").Value) - 1
                Datos(0, intY) = intY + 1
                Datos(1, intY) = dtgHallazgosEF_tmp.Rows(intRow).Cells("obsEFTMP").Value.ToString
                Datos(2, intY) = "S"
            ElseIf dtgHallazgosEF_tmp.Rows(intRow).Cells("obsEFTMP").Value.ToString.Trim.Length > 0 Then
                intY = (dtgHallazgosEF_tmp.Rows(intRow).Cells("sistemaEFTMP").Value) - 1
                Datos(0, intY) = intY + 1
                Datos(1, intY) = dtgHallazgosEF_tmp.Rows(intRow).Cells("obsEFTMP").Value.ToString
                Datos(2, intY) = ""
            End If
        Next

        For intRow = 0 To dtgHallazgosEF_tmp.Rows.Count - 1
            dtgHallazgosEF_tmp.Rows(intRow).Cells("obsEFTMP").Value = Datos(1, intRow)
            If Datos(2, intRow) = "S" Then
                dtgHallazgosEF_tmp.Rows(intRow).Cells("codcorrecto").Value = Datos(0, intRow)
            Else
                dtgHallazgosEF_tmp.Rows(intRow).Cells("codcorrecto").Value = ""
            End If
        Next
    End Sub


    Private Sub tlbConfirmar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tlbConfirmar.Click
        Dim intRow As Integer
        Dim Datos(2, 17) As String
        Dim intY As Integer
        Dim objActualizarAP As New Sophia.HistoriaClinica.BL.BLHistoriaBasica
        Dim DatosMod() As Object
        Dim lError As Long
        Dim objDAOGeneral As New Sophia.HistoriaClinica.DAO.DAOGeneral
        Dim blnDatos As Boolean
        '' ''Dim intActual As Integer


        For intRow = 0 To dtgHallazgosEF_tmp.Rows.Count - 1
            If dtgHallazgosEF_tmp.Rows(intRow).Cells("codcorrecto").Value.ToString.Trim.Length > 0 Then
                blnDatos = True
                Exit For
            End If
        Next

        If blnDatos = False Then
            If MessageBox.Show("No hay Datos Reclasificados. Confirma que los datos están Correctos?", "Historia Clinica", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
        End If

        If blnDatos = True Then
            For intRow = 0 To dtgHallazgosEF_tmp.Rows.Count - 1
                If dtgHallazgosEF_tmp.Rows(intRow).Cells("obsEFTMP").ErrorText.Trim.Length > 0 Then
                    MessageBox.Show("No se puede reclasificar la información porque existen datos pendientes por clasificar." & vbCrLf & "Clasifique los datos que se encuentran marcados con la señal roja.", "Historia Clinica", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            Next

            For intRow = 0 To dtgHallazgosEF_tmp.Rows.Count - 1
                If dtgHallazgosEF_tmp.Rows(intRow).Cells("codcorrecto").Value.ToString.Trim.Length > 0 Then
                    intY = (dtgHallazgosEF_tmp.Rows(intRow).Cells("codcorrecto").Value) - 1
                    Datos(0, intY) = intY + 1
                    Datos(1, intY) = dtgHallazgosEF_tmp.Rows(intRow).Cells("obsEFTMP").Value.ToString
                    Datos(2, intY) = "S"
                ElseIf dtgHallazgosEF_tmp.Rows(intRow).Cells("obsEFTMP").Value.ToString.Trim.Length > 0 Then
                    intY = (dtgHallazgosEF_tmp.Rows(intRow).Cells("sistemaEFTMP").Value) - 1
                    Datos(0, intY) = intY + 1
                    Datos(1, intY) = dtgHallazgosEF_tmp.Rows(intRow).Cells("obsEFTMP").Value.ToString
                    Datos(2, intY) = ""
                End If
            Next
        End If

        ReDim DatosMod(28)
        DatosMod(0) = IIf(blnDatos = True, 0, 1)
        DatosMod(1) = strPrestador
        DatosMod(2) = strSucursal
        DatosMod(3) = strTipoAdmision
        DatosMod(4) = intAnoAdmision
        DatosMod(5) = lNumeroAdmision
        DatosMod(6) = strTipoDocumento
        DatosMod(7) = strNumeroDocumento
        For intRow = 0 To dtgHallazgosEF_tmp.RowCount - 1
            If blnDatos = True Then
                DatosMod(intRow + 8) = IIf(Datos(1, intRow) Is Nothing, "", Datos(1, intRow))
            Else
                DatosMod(intRow + 8) = ""
            End If
        Next
        DatosMod(26) = ""
        DatosMod(27) = strMedico
        DatosMod(28) = lError

        Try
            lError = objDAOGeneral.EjecutarSPConParametrosTran("HC_CorregirExamenFisico", objConexion, DatosMod)
            If lError <> 0 Then
                If blnDatos = True Then
                    MessageBox.Show("Error al Corregir Datos Examen Físico")
                Else
                    MessageBox.Show("Error al Confirmar Datos Examen Físico")
                End If
            Else
                If blnDatos = True Then
                    GuardarEstadoActualControles()
                    Reclasificar()
                    MessageBox.Show("Los Datos Fueron Corregidos")
                Else
                    MessageBox.Show("Los Datos Fueron Confirmados")
                End If
                dtgHallazgosEF_tmp.Columns("codcorrecto").ReadOnly = True
                tlbConfirmar.Enabled = False
                tlbReclasificar.Enabled = False
                If intHCActual < intTotalHC Then
                    tlbSiguiente.Enabled = True
                ElseIf intHCActual = intTotalHC Then
                    tlbSiguiente.Visible = False
                    tlbSeparador.Visible = False
                    tlbLabel.Visible = False
                    blnRespuesta = True
                End If
                dtDatos.Rows(intHCActual - 1).Item("Estado") = "M"
            End If
        Catch ex As Exception
            If blnDatos = True Then
                MessageBox.Show("Error al Corregir Datos Examen Físico")
            Else
                MessageBox.Show("Error al Confirmar Datos Examen Físico")
            End If
        End Try


    End Sub

    Private Sub tlbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tlbSalir.Click
        Me.Close()
    End Sub

    Private Sub tlbSiguiente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tlbSiguiente.Click

        intHCActual = intHCActual + 1
        tlbLabel.Text = intHCActual & "a. HC de " & intTotalHC & " para ser Revisadas."


        strPrestador = dtDatos.Rows(intHCActual - 1).Item("cod_pre_sgs").ToString.Trim
        strSucursal = dtDatos.Rows(intHCActual - 1).Item("cod_sucur").ToString.Trim
        strTipoAdmision = dtDatos.Rows(intHCActual - 1).Item("tip_admision").ToString.Trim
        intAnoAdmision = dtDatos.Rows(intHCActual - 1).Item("ano_adm")
        lNumeroAdmision = dtDatos.Rows(intHCActual - 1).Item("num_adm")
        strTipoDocumento = dtDatos.Rows(intHCActual - 1).Item("tip_doc").ToString.Trim
        strNumeroDocumento = dtDatos.Rows(intHCActual - 1).Item("num_doc").ToString.Trim
        strMedico = dtDatos.Rows(intHCActual - 1).Item("login").ToString.Trim
        strFecha = dtDatos.Rows(intHCActual - 1).Item("fec_hc").ToString.Trim


        Me.Text = strNombrePaciente & " - " & strTipoDocumento & " : " & _
                  strNumeroDocumento & " (Admisión " & strTipoAdmision & " " & intAnoAdmision & " " & lNumeroAdmision & " - Fecha : " & strFecha & ")"

        ConsultarDatosHC()

        tlbConfirmar.Enabled = True
        tlbReclasificar.Enabled = True
        dtgHallazgosEF_tmp.Columns("codcorrecto").ReadOnly = False
        tlbSiguiente.Enabled = False

    End Sub
End Class

