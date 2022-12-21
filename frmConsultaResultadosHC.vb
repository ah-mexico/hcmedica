Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports System.Text.RegularExpressions
Imports System.Collections.Generic
Imports System.Data.Common

Public Class frmConsultaResultadosHC

    '    Dim strCadenaLocal As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\WINDOWS\system32\SOPHIA\Sophia.mdb"
    Private strCadenaLocal As String = "Provider=sqloledb;Data Source=etiopia;Initial Catalog=sophiabog;User Id=sophia;Password=sophia;"
    Private _paciente As Paciente
    Private _datosConexion As conexion

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _paciente = New Paciente()
    End Sub

    Public Sub cargarTiposDocumento()
        Dim objTablasBasicas As New BLBasicasLocales

        With tbCodigoTipDoc
            .NombreCampoBuscado = "descripcion"
            .NombreCampoBusqueda = "tip_doc"
            .ControlTextoEnlace = tbDescTipDoc
        End With

        With tbDescTipDoc
            .NombreCampoDatos = "descripcion"
            .ControlTextoEnlace = tbCodigoTipDoc
            .OrigenDeDatos = objTablasBasicas.TraerDatosTablasBasicasLocales(strCadenaLocal, "gentipdo", "tip_doc, descripcion", "")
            .CargarDatosDescripcion()
        End With

        Try
            With Me.txtTipExamen
                .NombreCampoBuscado = "descripcion"
                .NombreCampoBusqueda = "tipo"
                .ControlTextoEnlace = txtDescTipoExamen
            End With

            With Me.txtDescTipoExamen
                .NombreCampoDatos = "descripcion"
                .ControlTextoEnlace = txtTipExamen
                .OrigenDeDatos = objTablasBasicas.TraerDatosTablasBasicasLocales(strCadenaLocal, "RESTIPOEXAMEN", "tipo, descripcion", "")
                .CargarDatosDescripcion()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
       

    End Sub

   
    Private Sub frmConsultaResultadosHC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
            ValidaKeyPress(Me, e)
    End Sub

    Private Sub frmConsultaResultadosHC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarTiposDocumento()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim objPaciente As New Paciente
        Dim bPacienteEncontrado As Boolean

        Try
            'Busqueda por documento
            If Len(tbCodigoTipDoc.Text) > 0 And Len(txtNumDoc.Text) > 0 Then

                _paciente = Paciente.buscarDocumento(_datosConexion, tbCodigoTipDoc.Text, txtNumDoc.Text)

                If Not Paciente.PacienteVacio(_paciente) Then

                    If _paciente.Unificado = "U" And Not Paciente.PacienteVacio(_paciente.PacienteUnificador) Then
                        With _paciente.PacienteUnificador
                            MsgBox("Este documento se ha unificado a el documento " _
                                   & .TipoDocumento & " " & .NumeroDocumento)
                            tbCodigoTipDoc.Text = .TipoDocumento
                            txtNumDoc.Text = .NumeroDocumento
                            txtPrimerNombre.Text = .PrimerNombre
                            txtSegundoNombre.Text = .SegundoNombre
                            txtPrimerApellido.Text = .PrimerApellido
                            txtSegundoApellido.Text = .SegundoApellido
                        End With
                    Else
                        With _paciente
                            txtPrimerNombre.Text = .PrimerNombre
                            txtSegundoNombre.Text = .SegundoNombre
                            txtPrimerApellido.Text = .PrimerApellido
                            txtSegundoApellido.Text = .SegundoApellido
                        End With
                    End If
                Else
                    MsgBox("Registro no existe.", MsgBoxStyle.Information)
                End If
            Else 'Busqueda por Nombre
                If Not String.IsNullOrEmpty(txtPrimerApellido.Text) And _
                   Not String.IsNullOrEmpty(txtPrimerNombre.Text) Then

                    objPaciente.PrimerApellido = txtPrimerApellido.Text
                    objPaciente.PrimerNombre = txtPrimerNombre.Text

                    bPacienteEncontrado = frmConsultaPorNombre.mostrar(objPaciente)

                    If bPacienteEncontrado = True Then
                        _paciente = objPaciente
                        With _paciente
                            tbCodigoTipDoc.Text = .TipoDocumento
                            txtNumDoc.Text = .NumeroDocumento
                            txtPrimerNombre.Text = .PrimerNombre
                            txtSegundoNombre.Text = .SegundoNombre
                            txtPrimerApellido.Text = .PrimerApellido
                            txtSegundoApellido.Text = .SegundoApellido
                        End With
                    Else
                        MsgBox("Registro no existe.", MsgBoxStyle.Information)
                    End If
                Else
                    MsgBox("Datos incompletos.", MsgBoxStyle.Information)
                End If
            End If

            Me.mskFechaDesde.Focus()
        Catch ex As Exception
            MsgBox("Error en la busqueda del paciente. " & ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub


    Private Sub btnTraer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fechaInicial As Date
        Dim fechaFinal As Date
        Dim dtDatos As DataTable

        If mskFechaDesde.Text = "  /  /" Then
            fechaInicial = Nothing
        Else
            fechaInicial = CDate(mskFechaDesde.Text)
        End If

        If mskFechaHasta.Text = "  /  /" Then
            fechaFinal = Nothing
        Else
            fechaFinal = CDate(mskFechaHasta.Text)
        End If

        Try
            dtDatos = FormatoHistoriaClinica.traerHistoriasXPaciente(_datosConexion, _paciente, fechaInicial, fechaFinal)
            If dtDatos.Rows.Count Then
                dtgAdmisiones.DataSource = dtDatos
                dtgAdmisiones.Sort(dtgAdmisiones.Columns("fec_hc"), System.ComponentModel.ListSortDirection.Descending)
                configurarGrilla()
            Else
                MsgBox("No existen registros que cumplan este criterio", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox("Error en la consulta de las Historias Clinicas." & ex.Message)
        End Try

    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        With dtgAdmisiones.CurrentRow
            'If chkResumenEgreso.CheckState = CheckState.Unchecked Then

            '    frmRepHistoriaClinica.Show()
            '    frmRepHistoriaClinica.ImprimirHistoriaClinica(.Cells("cod_pre_sgs").Value, _
            '                          .Cells("cod_sucur").Value, .Cells("tip_admision").Value, _
            '                          .Cells("ano_adm").Value, .Cells("num_adm").Value, _
            '                          globales.Login, globales.CodigoEspecialidad, _
            '                          .Cells("tip_hc").Value, "I", globales.Login)
            'Else
            '    frmRepResumenHistoriaClinica.Show()
            '    frmRepResumenHistoriaClinica.ImprimirResumenHistoriaClinica(.Cells("cod_pre_sgs").Value, _
            '                          .Cells("cod_sucur").Value, .Cells("tip_admision").Value, _
            '                          .Cells("ano_adm").Value, .Cells("num_adm").Value)
            'End If

        End With

    End Sub

    Public Sub configurarGrilla()
        'dtgAdmisiones.AutoGenerateColumns = False
        With dtgAdmisiones
            .Columns("cod_pre_sgs").Visible = False
            .Columns("cod_sucur").Visible = False
            .Columns("tip_hc").Visible = False
            .Columns("hor_hc").Visible = False
            .Columns("min_hc").Visible = False
            .Columns("tip_doc").Visible = False
            .Columns("num_doc").Visible = False
            .Columns("reg_med").Visible = False
            .Columns("id_med").Visible = False
            .Columns("sucursal").Visible = False
            .Columns("direccion").Visible = False
            .Columns("telefono").Visible = False
        End With
    End Sub

    Private Sub dtgAdmisiones_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
      
    End Sub

    Public Function grillaVacia(ByVal grilla As DataGridView) As Boolean
        Dim source As DataTable
        source = grilla.DataSource
        If source Is Nothing Then
            Return True
        ElseIf source.Rows.Count = 0 Then
            Return True
        End If

        Return False
    End Function

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LimpiarPantalla(GroupBox2, TLimpiar.tlTodos)
        LimpiarPantalla(Me, TLimpiar.tlTodos)
        LimpiarDataGrid(dtgAdmisiones)
    End Sub

    Public Enum TLimpiar
        tlTodos = 0
        tlActivos = 1
        tlInactivos = 2
    End Enum

    Public Shared Sub LimpiarPantalla(ByVal Forma As Object, Optional ByVal TipoLimpiar As TLimpiar = TLimpiar.tlTodos)
        Dim cControl As Control

        For Each cControl In Forma.Controls
            If TypeOf cControl Is TextBox Or TypeOf cControl Is CheckBox Or TypeOf cControl Is MaskedTextBox Then
                If TipoLimpiar = TLimpiar.tlTodos Or (TipoLimpiar = TLimpiar.tlActivos And cControl.Enabled) Or _
                                        (TipoLimpiar = TLimpiar.tlInactivos And Not cControl.Enabled) Then
                    If TypeOf cControl Is TextBox Then
                        Dim ctlTextBox As TextBox
                        ctlTextBox = cControl
                        ctlTextBox.Text = ""
                    ElseIf TypeOf cControl Is CheckBox Then
                        Dim ctlRadioButton As CheckBox
                        ctlRadioButton = cControl
                        ctlRadioButton.Checked = False
                    ElseIf TypeOf cControl Is MaskedTextBox Then
                        Dim ctlMaskedTextBox As MaskedTextBox
                        ctlMaskedTextBox = cControl
                        ctlMaskedTextBox.Clear()
                    End If
                End If
            End If
        Next cControl
    End Sub

    Private Sub mskFechaDesde_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If mskFechaDesde.Text <> "  /  /" Then
            If Not IsDate(mskFechaDesde.Text) Then

                MsgBox("Fecha invalida. Debe digitar una fecha valida.", MsgBoxStyle.Information)
                e.Cancel = True
                mskFechaDesde.Select(0, mskFechaDesde.TextLength)
            End If
        End If
    End Sub

    Private Sub mskFechaHasta_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If mskFechaHasta.Text <> "  /  /" Then
            If Not IsDate(mskFechaHasta.Text) Then
                MsgBox("Fecha invalida. Debe digitar una fecha valida.", MsgBoxStyle.Information)
                e.Cancel = True
                mskFechaHasta.Select(0, mskFechaDesde.TextLength)
            End If
        End If
    End Sub

    Public Shared Sub ValidaKeyPress(ByRef MyControl As Control, ByVal s As KeyPressEventArgs)
        If Len(MyControl.Tag) > 0 Then
            If Mid(MyControl.Tag, 1, 1) = "N" Then
                If Not Regex.IsMatch(s.KeyChar, "[0-9]") Then
                    s.Handled = True
                End If
            ElseIf Mid(MyControl.Tag, 1, 1) = "L" Then
                If Not Regex.IsMatch(s.KeyChar, "[a-zA-Z]") Then
                    s.Handled = True
                End If
            Else
                s.Handled = True
            End If
        End If

        Select Case s.KeyChar
            Case Convert.ToChar(Keys.Return)
                SendKeys.Send("{TAB}")
                s.Handled = True
            Case Convert.ToChar(Keys.Back)
                SendKeys.Send("{LEFT}")
                SendKeys.Send("{DELETE}")
        End Select
    End Sub

    Private Sub LimpiarDataGrid(ByVal dtg As DataGridView)
        For i As Integer = 0 To dtg.Rows.Count - 1
            dtg.Rows.Remove(Me.dtgAdmisiones.Rows(0))
        Next i
    End Sub

    Private Sub btnTraer_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTraer.Click

        Select Case Me.txtTipExamen.Text
            Case "1", "5", "6", "7", "11", "12"
                'rs = modHisMovimientos.TraerResDetImagenes(g_strCadenaConexion, cxtTipDoc.Text, txtNumDoc.Text, _
                '                  ConvSerial(mskFechaDesde.ClipText), ConvSerial(mskFechaHasta.ClipText), _
                '                  CInt(cxtTipoExamen.Text), bAuditoria:=modHistoria.ManejaAuditoria(), strLogin:=modHistoria.strLogin, strEstadoUnificacion:=m_cls.Unificado, o_lError:=lError)
            Case "2", "3", "4"
                ': rs = modHisMovimientos.TraerResDetEcografia(g_strCadenaConexion, cxtTipDoc.Text, txtNumDoc.Text, _
                '                 ConvSerial(mskFechaDesde.ClipText), ConvSerial(mskFechaHasta.ClipText), _
                '                CInt(cxtTipoExamen.Text), bAuditoria:=modHistoria.ManejaAuditoria(), strLogin:=modHistoria.strLogin, strEstadoUnificacion:=m_cls.Unificado, o_lError:=lError)
                '      estas opciones aún no se han implementado, por tal razón aparecen comentariadas
                '       Case "7": Set rs = objResultados.TraerResDetPatol(g_strCadenaConexion, cxtTipDoc.Text, txtNumDoc.Text, _
                '                          ConvSerial(mskFechaDesde.ClipText), ConvSerial(mskFechaHasta.ClipText), _
                '                          o_lerror:=  lError)
                '       Case "8": Set rs = objResultados.TraerResDetCitol(g_strCadenaConexion, cxtTipDoc.Text, txtNumDoc.Text, _
                '                          ConvSerial(mskFechaDesde.ClipText), ConvSerial(mskFechaHasta.ClipText), _
                '                          o_lerror:=  lError)
            Case "8" ': rs = modHisMovimientos.TraerResDetPatol(g_strCadenaConexion, cxtTipDoc.Text, txtNumDoc.Text, _
                'ConvSerial(mskFechaDesde.ClipText), ConvSerial(mskFechaHasta.ClipText), _
                'bAuditoria:=modHistoria.ManejaAuditoria(), strLogin:=modHistoria.strLogin, strEstadoUnificacion:=m_cls.Unificado, o_lError:=lError)
            Case "9" ': rs = modHisMovimientos.TraerResDetCitol(g_strCadenaConexion, cxtTipDoc.Text, txtNumDoc.Text, _
                'ConvSerial(mskFechaDesde.ClipText), ConvSerial(mskFechaHasta.ClipText), _
                'bAuditoria:=modHistoria.ManejaAuditoria(), strLogin:=modHistoria.strLogin, strEstadoUnificacion:=m_cls.Unificado, o_lError:=lError)
            Case "10" ': rs = modHisMovimientos.TraerResDetEcoCardiograma(g_strCadenaConexion, cxtTipDoc.Text, txtNumDoc.Text, _
                'ConvSerial(mskFechaDesde.ClipText), ConvSerial(mskFechaHasta.ClipText), "0024", _
                'bAuditoria:=modHistoria.ManejaAuditoria(), strLogin:=modHistoria.strLogin, strEstadoUnificacion:=m_cls.Unificado, o_lError:=lError)
            Case "13" ': rs = modHisMovimientos.TraerResDetGastroGenerales(g_strCadenaConexion, cxtTipDoc.Text, txtNumDoc.Text, _
                'ConvSerial(mskFechaDesde.ClipText), ConvSerial(mskFechaHasta.ClipText), 13, _
                'bAuditoria:=modHistoria.ManejaAuditoria(), strLogin:=modHistoria.strLogin, strEstadoUnificacion:=m_cls.Unificado, o_lError:=lError)
            Case "14" ': rs = modHisMovimientos.TraerResDetGastroGenerales(g_strCadenaConexion, cxtTipDoc.Text, txtNumDoc.Text, _
                'ConvSerial(mskFechaDesde.ClipText), ConvSerial(mskFechaHasta.ClipText), 14, _
                'bAuditoria:=modHistoria.ManejaAuditoria(), strLogin:=modHistoria.strLogin, strEstadoUnificacion:=m_cls.Unificado, o_lError:=lError)
            Case Else
        End Select
    End Sub


End Class


