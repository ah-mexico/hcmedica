Imports System.IO
Imports System.Collections.Generic
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.HistoriaBasica
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports HistoriaClinica.Sophia.HistoriaClinica.BL

Public Class ctlRetiroCateter    

#Region "Propiedades"
    Private Shared _Instancia As ctlRetiroCateter
    Private objGeneral As Generales
    Private objPaciente As Paciente
    Private objDAOEnfermeria As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOEnfermeriaCP
    Private objCateter As New RegistroCateter
    Private myParent As ctlCPEnfermeria
    Private cadenaFechaVacia As String = "/  /"
#End Region

#Region "Instancia de Control"

    Public Shared ReadOnly Property Instancia() As ctlRetiroCateter
        Get
            If _Instancia Is Nothing Then
                _Instancia = New ctlRetiroCateter
            End If
            Return _Instancia
        End Get
    End Property

#End Region

#Region "Events"

    Private Sub ctlRetiroCateter_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged
        objPaciente = Paciente.Instancia
        objGeneral = Generales.Instancia
        If Me.Visible Then
            myParent = Me.Parent.Parent.Parent.Parent.Parent
            CargarCombos()
        End If
    End Sub

    Private Sub cmbTipoCateterRet_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoCateterRet.SelectedIndexChanged
        Dim dt As New DataTable
        cmbMotivoRetiro.ResetText()
        cmbMotivoRetiro.BeginUpdate()
        If IsNothing(cmbTipoCateterRet.SelectedValue) Then
            dt = Nothing
        Else
            If cmbTipoCateterRet.SelectedValue.ToString() = "92601" Then
                dt = objDAOEnfermeria.CargarCombo(7, "S")
            Else
                dt = objDAOEnfermeria.CargarCombo(7, "I")
            End If
        End If

        If Not IsNothing(dt) Then
            If dt.Rows.Count = 0 Then
                MsgBox("No existen motivos de retiro parametrizados.")
            End If
        End If
        cmbMotivoRetiro.DataSource = dt
        If Not IsNothing(dt) Then
            cmbMotivoRetiro.DisplayMember = "descripcion"
            cmbMotivoRetiro.ValueMember = "Id"
        End If
        cmbMotivoRetiro.EndUpdate()
        cmbMotivoRetiro.SelectedValue = -1
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If (Not ValidarFechas()) Then
            Exit Sub
        End If
        GuardaRetiroCateter()
    End Sub

#End Region

#Region "Functions"
    Private Sub CargarCombos()
        Dim dt As New DataTable
        Try
            cmbTipoCateterRet.ResetText()
            cmbTipoCateterRet.BeginUpdate()
            dt = objDAOEnfermeria.CargarCombo(2, "R")

            If dt.Rows.Count = 0 Then
                MsgBox("No existen tipos de catéter parametrizados.")
            End If
            cmbTipoCateterRet.DataSource = dt

            cmbTipoCateterRet.DisplayMember = "descripcion"
            cmbTipoCateterRet.ValueMember = "Id"
            cmbTipoCateterRet.EndUpdate()
            cmbTipoCateterRet.SelectedValue = -1

            cmbMotivoRetiro.SelectedValue = -1

        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub


    Private Sub GuardaRetiroCateter()
        Dim Resultado As Boolean
        objCateter.Cod_pre_sgs = objGeneral.Prestador
        objCateter.Cod_sucur = objGeneral.Sucursal
        objCateter.Tip_admision = objPaciente.TipoAdmision
        objCateter.Ano_adm = objPaciente.AnoAdmision
        objCateter.Num_adm = objPaciente.NumeroAdmision
        objCateter.Tip_Doc = objPaciente.TipoDocumento
        objCateter.Num_Doc = objPaciente.NumeroDocumento
        objCateter.Tip_Registro = "RETIRO"
        If Not IsNothing(Me.cmbTipoCateterRet.SelectedValue) Then
            objCateter.Tip_Cateter = Convert.ToInt32(Me.cmbTipoCateterRet.SelectedValue)
        End If
        If Me.mskFecHorRetiro.Text.Trim() <> cadenaFechaVacia Then
            objCateter.Fec_Retiro = Me.mskFecHorRetiro.Text.Trim()
        End If
        If Not IsNothing(Me.cmbMotivoRetiro.SelectedValue) Then
            objCateter.MotivoRetiro = Convert.ToInt32(Me.cmbMotivoRetiro.SelectedValue)
        End If
        objCateter.Login = objGeneral.Login
        objCateter.Obs = String.Empty

        Resultado = Me.objDAOEnfermeria.GuardarRegistroCateter(objCateter)
        If Resultado Then
            MsgBox("Información de retiro de catéter guardada satisfactoriamiente", MsgBoxStyle.Information)
            LimpiarCampos()
        End If
        'myParent.CargarDatosCateter()
    End Sub


    Private Sub LimpiarCampos()
        Me.mskFecHorRetiro.Text = String.Empty
        Me.cmbTipoCateterRet.SelectedValue = -1
        Me.cmbMotivoRetiro.SelectedIndex = -1
        objCateter = New RegistroCateter
    End Sub

    Private Function ValidarFechas() As Boolean
        Dim esValido As Boolean = True
        Dim fecha As Date
        Dim formatoFecha As String = "dd/MM/yyyy"
        Try
            If Me.mskFecHorRetiro.Text.Trim().Length > 0 And Me.mskFecHorRetiro.Text.Trim() <> cadenaFechaVacia Then
                fecha = Date.ParseExact(Me.mskFecHorRetiro.Text.Trim(), formatoFecha, System.Globalization.DateTimeFormatInfo.InvariantInfo)
                If fecha > Date.Now Then
                    esValido = False
                    MsgBox("La fecha de retiro no debe ser superior al día de hoy. Favor revisar", MsgBoxStyle.Critical)
                    Return esValido
                End If
            End If
        Catch ex As Exception
            esValido = False
            MsgBox("La fecha de retiro no es válida. Favor revisar", MsgBoxStyle.Critical)
            Return esValido
        End Try

        Return esValido
    End Function

#End Region

End Class
