Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports System.Text.RegularExpressions
Imports System.Collections.Generic
Imports System.Data.Common
Imports System.Text
Imports HistoriaClinica.Sophia.HistoriaClinica
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports objPaciente = HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente.Paciente
Imports SHDocVw





Public Class frmConsultaParaclinico
    Dim dtDescr As DataSet
    Dim DaoAgfa As New DaoParaclinico
    Dim strDir As String = System.Environment.SystemDirectory.ToString()
    Dim strCadenaLocal As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strDir & "\SOPHIA\Sophia.mdb"
    Dim _datosGenerales As Generales
    Dim _paciente As Paciente
    Dim _datosConexion As Conexion
    Private objIncapacidad As PlanIncapacidad
    Dim objP As objPaciente = objPaciente.Instancia
    Private objFormuExt As PlanFormuExterna 'jlalfonso
    Private objgeneral As New DAOGeneral
    Public WithEvents oIE As SHDocVw.InternetExplorer



    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _paciente = New Paciente()
        objFormuExt = PlanFormuExterna.Instancia

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
    End Sub

    Private Sub frmConsultaHC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        ValidaKeyPress(Me, e)
    End Sub

    Private Sub frmConsultaHC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dtgPacientes As DataGridView
        Dim controlListaEspera As ListaEspera
        controlListaEspera = ListaEspera.Instancia
        dtgPacientes = controlListaEspera.dtgLista


        cargarTiposDocumento()
        _datosConexion = Conexion.Instancia()
        _datosGenerales = Generales.Instancia()


        tbCodigoTipDoc.Focus()
        'mskFechaDesde.Text = Format(FuncionesGenerales.FechaServidor(), "dd/MM/yyyy")
        'mskFechaHasta.Text = Format(FuncionesGenerales.FechaServidor(), "dd/MM/yyyy")
        ''objP

        tbCodigoTipDoc.Text = objP.TipoDocumento
        txtNumDoc.Text = objP.NumeroDocumento
        txtPrimerApellido.Text = objP.PrimerApellido
        txtSegundoApellido.Text = objP.SegundoApellido
        txtPrimerNombre.Text = objP.PrimerNombre
        txtSegundoApellido.Text = objP.SegundoApellido

        oIE = New SHDocVw.InternetExplorer
        'If Not dtgPacientes.CurrentRow Is Nothing Then

        '    tbCodigoTipDoc.Text = dtgPacientes.CurrentRow.Cells("tip_doc").Value
        '    txtNumDoc.Text = dtgPacientes.CurrentRow.Cells("num_doc").Value
        'End If


    End Sub

    Public Sub mostrar(ByVal strTip_doc As String, ByVal strNum_doc As String)
        If strTip_doc.Trim.Length > 0 And strNum_doc.Trim.Length > 0 Then
            tbCodigoTipDoc.Text = strTip_doc
            txtNumDoc.Text = strNum_doc
            _datosConexion = Conexion.Instancia()
            _datosGenerales = Generales.Instancia()
            mskFechaDesde.Focus()
        End If

        Me.Show()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim objPaciente As New Paciente
        Dim FechaIni As String
        Dim fechaFin As String
        Dim FechaIniD As Date
        Dim fechaFinD As Date


        If mskFechaDesde.Text = "  /  /" Then
            FechaIni = ""
        Else
            FechaIni = mskFechaDesde.Text
        End If

        If mskFechaHasta.Text = "  /  /" Then
            fechaFin = ""
        Else
            fechaFin = mskFechaHasta.Text
        End If

        If FechaIni <> "" And fechaFin = "" Then
            MsgBox("Ingrese la Fecha Final")
            Exit Sub
        End If

        If fechaFin <> "" And FechaIni = "" Then
            MsgBox("Ingrese la Fecha Inicial")
            Exit Sub
        End If

        If tbCodigoTipDoc.Text = String.Empty Or txtNumDoc.Text = String.Empty Then
            MsgBox("Ingrese los datos del paciente")
            Exit Sub
        Else

            If FechaIni <> "" And fechaFin <> "" Then

                FechaIniD = CDate(FechaIni)
                fechaFinD = CDate(fechaFin)

                FechaIni = Format(FechaIniD, "yyyy/MM/dd")
                fechaFin = Format(fechaFinD, "yyyy/MM/dd")

            End If

            txtNumDoc.Text = Replace(Replace(Replace(Replace(Replace(Replace(txtNumDoc.Text, "=", "", 1), "OR", ""), "%", "", 1), "&", "", 1), "DELETE", "", 1), "'", "", 1)

            TraerDescripcioExamen(tbCodigoTipDoc.Text, txtNumDoc.Text, FechaIni, fechaFin)
        End If

        dtgExamenes.DataSource = Nothing

    End Sub

    Private Sub TraerDescripcioExamen(ByVal strTipDoc As String, ByVal strNumDoc As String, ByVal strFechaI As String, ByVal strFechaF As String)

        Dim id As String
        Dim dt As New DataTable
        Dim dtlimpia As DataTable

        _datosConexion = Conexion.Instancia()



        id = strTipDoc & strNumDoc

        dtDescr = DaoAgfa.HCAGFA_ConsultarDescripciones(id, strFechaI, strFechaF)

        If dtDescr.Tables(0).Rows.Count > 0 Then
            dtgDescr.DataSource = dtDescr.Tables(0)
            dtgDescr.Columns("seleccionado").Visible = False


            'dtgDescr.Columns("seleccion").Visible = False
            dt = objgeneral.EjecutarSQLConParametros("genpacie", _datosConexion, "pri_nom,seg_nom,pri_ape,seg_ape", "tip_doc='" & tbCodigoTipDoc.Text & "' and num_doc='" & txtNumDoc.Text & "'")
            txtPrimerNombre.Text = IIf(IsDBNull(dt.Rows(0).Item("pri_nom")), "", dt.Rows(0).Item("pri_nom"))
            txtSegundoNombre.Text = IIf(IsDBNull(dt.Rows(0).Item("seg_nom")), "", dt.Rows(0).Item("seg_nom"))
            txtPrimerApellido.Text = IIf(IsDBNull(dt.Rows(0).Item("pri_ape")), "", dt.Rows(0).Item("pri_ape"))
            txtSegundoApellido.Text = IIf(IsDBNull(dt.Rows(0).Item("seg_ape")), "", dt.Rows(0).Item("seg_ape"))

        Else
            MsgBox("No existen registros para los datos ingresados")

            If Not dtgDescr.DataSource Is Nothing Then
                dtlimpia = dtgDescr.DataSource

                If dtlimpia.Rows.Count > 0 Then
                    For i As Integer = 0 To dtlimpia.Rows.Count - 1
                        dtlimpia.Rows(i).Item("seleccionado") = "N"
                        dtlimpia.Rows(i).Item("OBR_04_EXAM_DESC") = ""
                        dtlimpia.Rows(i).Item("Seleccion") = "N"
                    Next

                    dtgDescr.DataSource = dtlimpia
                End If
            End If


            txtPrimerNombre.Text = ""
            txtSegundoNombre.Text = ""
            txtPrimerApellido.Text = ""
            txtSegundoApellido.Text = ""
        End If

    End Sub
    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Try
            If oIE.Visible = True Then
                oIE.Quit()

            End If
        Catch ex As Exception

        End Try

        ConsultaIMPAX()
    End Sub
    Private Sub ConsultaIMPAX()
        Dim proceso As New System.Diagnostics.Process
        Dim Sproceso As New System.Diagnostics.ProcessStartInfo
        Dim idpaciente As String
        Dim cod_acceso As String
        Dim frmver As New frmRepParaclinico
        Dim dt As DataTable = dtgExamenes.DataSource
        Dim dtInterface As DataTable
        Dim strip As String = ""
        Dim strusuario As String = ""
        Dim strClave As String = ""

        oIE = New SHDocVw.InternetExplorer

        If dtgExamenes.CurrentRow Is Nothing Then
            MsgBox("Debe elegir primero registro.", MsgBoxStyle.Information)
            Exit Sub
        Else
            Try
                dtInterface = DaoAgfa.HCAGFA_ConsultarInterface(_datosGenerales.Prestador, _datosGenerales.Sucursal)

                If dtInterface.Rows.Count = 0 Then
                    MsgBox("La Interface no está parametrizada. Consulte con el Administrador del Sistema", MsgBoxStyle.Information)
                    Exit Sub
                End If
                strip = LTrim(RTrim(dtInterface.Rows(0).Item("IP")))
                strusuario = LTrim(RTrim(dtInterface.Rows(0).Item("usuario")))
                strClave = LTrim(RTrim(dtInterface.Rows(0).Item("PASSWORD")))
                idpaciente = dtgExamenes.CurrentRow.Cells("PID_05_ID").Value()
                cod_acceso = dtgExamenes.CurrentRow.Cells("OBR_18_ACC_NUMBER").Value()

                oIE.Visible = True

                oIE.Navigate("https://" & strip & "/ResultsViewer/emr.aspx?action=Display&patientid=" & idpaciente & "&accession=" & cod_acceso & "&user=" & strusuario & "&password=" & strClave & "&domain=Agfa Healthcare&reusewindow=true")
                oIE.AddressBar = False

                'MsgBox("Sale del navegador")
                ''frmver.Show()
                ''imprimirImagen("https://" & strip & "/ResultsViewer/emr.aspx?action=Display&patientid=" & idpaciente & "&accession=" & cod_acceso & "&user=" & strusuario & "&password=" & strClave & "&domain=Agfa Healthcare&reusewindow=true")
            Catch ex As Exception
                MsgBox(ex.StackTrace)
            End Try


        End If
    End Sub

    Private Sub oIE_OnQuit()
        MsgBox("CERRE EXPLORADOR")
    End Sub
    Public Sub configurarGrilla()
        'dtgAdmisiones.AutoGenerateColumns = False
        With dtgExamenes
            '' .Columns("estado").Width = 60  ''Claudia Garay 08 junio 2010
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
            .Columns("edad").Visible = False
            .Columns("Entidad").Visible = False

        End With
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

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click

        Try
            If oIE.Visible = True Then
                oIE.Quit()
            End If
        Catch ex As Exception

        End Try
       

        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        LimpiarPantalla(GroupBox2, TLimpiar.tlTodos)
        LimpiarPantalla(Me, TLimpiar.tlTodos)
        LimpiarDataGrid(dtgExamenes)
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

    Private Sub mskFechaDesde_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mskFechaDesde.Validating
        If mskFechaDesde.Text <> "  /  /" Then
            If Not IsDate(mskFechaDesde.Text) Then

                MsgBox("Fecha invalida. Debe digitar una fecha valida.", MsgBoxStyle.Information)
                e.Cancel = True
                mskFechaDesde.Select(0, mskFechaDesde.TextLength)
            End If
        End If
    End Sub

    Private Sub mskFechaHasta_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mskFechaHasta.Validating
        If mskFechaHasta.Text <> "  /  /" Then
            If Not IsDate(mskFechaHasta.Text) Then
                MsgBox("Fecha invalida. Debe digitar una fecha valida.", MsgBoxStyle.Information)
                e.Cancel = True
                mskFechaHasta.Select(0, mskFechaDesde.TextLength)
            Else
                If Not CDate(mskFechaHasta.Text) >= CDate(mskFechaDesde.Text) Then
                    MsgBox("Fecha invalida. Debe digitar una fecha valida.", MsgBoxStyle.Information)
                    e.Cancel = True
                    mskFechaHasta.Select(0, mskFechaDesde.TextLength)
                End If
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
        End Select
    End Sub

    Private Sub LimpiarDataGrid(ByVal dtg As DataGridView)
        For i As Integer = 0 To dtg.Rows.Count - 1
            dtg.Rows.Remove(Me.dtgExamenes.Rows(0))
        Next i
    End Sub

    Private Sub cmdBuscarExamen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim dtgrilla As DataTable
        Dim strDescripcion As String



        ' dtgrilla = DaoAgfa.HCAGFA_ConsultarDescripciones(tbCodigoTipDoc.Text & txtNumDoc.Text)

    End Sub


    Private Sub FiltarGrillaExamenes(ByVal dtconsulta As DataTable, ByVal filtro As String)
        Dim dtgrilla As DataTable = dtgDescr.DataSource
        Dim dtExamen As DataTable
        Dim dtcompi As DataTable
        Dim dtcont As DataTable = dtconsulta.Clone
        Dim dtRows() As DataRow
        Dim dtRow As DataRow
        Dim dt As DataRow

        dtconsulta = filtrarTabla(dtconsulta, "OBR_04_EXAM_DESC='" & filtro & "'", dtcont)


        'For Each dtRow In dtRows
        '    dt = dtconsulta.NewRow
        '    dt = dtRow
        '    dtconsulta.Rows.Add(dt)
        'Next


        If dtgExamenes.DataSource Is Nothing Then
            dtgExamenes.DataSource = dtconsulta
        Else
            dtExamen = dtgExamenes.DataSource


            For i As Integer = 0 To dtconsulta.Rows.Count - 1
                dt = dtExamen.NewRow
                dt.Item("PID_05_ID") = dtconsulta.Rows(i).Item("PID_05_ID")
                dt.Item("OBR_04_EXAM_DESC") = dtconsulta.Rows(i).Item("OBR_04_EXAM_DESC")
                dt.Item("OBR_06_EXAM_DATE_BATCH") = dtconsulta.Rows(i).Item("OBR_06_EXAM_DATE_BATCH")
                dt.Item("OBR_13_ORDER_INFO") = dtconsulta.Rows(i).Item("OBR_13_ORDER_INFO")
                dt.Item("OBR_18_ACC_NUMBER") = dtconsulta.Rows(i).Item("OBR_18_ACC_NUMBER")
                dtExamen.Rows.Add(dt)
            Next

        End If

        dtgExamenes.Columns("OBR_18_ACC_NUMBER").Visible = False
        dtgExamenes.Columns("OBR_06_EXAM_DATE_BATCH").HeaderText = "Fecha Realización"
        dtgExamenes.Columns("OBR_04_EXAM_DESC").HeaderText = "Descripción"
        dtgExamenes.Columns("PID_05_ID").HeaderText = "Identificación"
        dtgExamenes.Columns("OBR_13_ORDER_INFO").HeaderText = "Observación"


    End Sub
    Private Sub FiltarGrillaQuitar(ByVal dtconsulta As DataTable, ByVal filtro As String)
        Dim dtgrilla As DataTable = dtgDescr.DataSource
        Dim dtcont As DataTable
        dtcont = borrarFilasInactivas(dtconsulta, filtro)

        dtgExamenes.DataSource = dtcont

        dtgExamenes.Columns("OBR_18_ACC_NUMBER").Visible = False
        dtgExamenes.Columns("OBR_06_EXAM_DATE_BATCH").HeaderText = "Fecha Realización"
        dtgExamenes.Columns("PID_05_ID").HeaderText = "Identificación"
        dtgExamenes.Columns("OBR_04_EXAM_DESC").HeaderText = "Descripción"
        dtgExamenes.Columns("OBR_13_ORDER_INFO").HeaderText = "Observación"

        ''  dtgDescr.Columns("seleccionado").Visible = False
    End Sub
    Private Function borrarFilasInactivas(ByVal dt As DataTable, ByVal filtro As String) As DataTable

        Dim rows() As DataRow
        Dim row As DataRow
        Dim dtRows() As DataRow


        rows = dt.Select("OBR_04_EXAM_DESC = '" & filtro & "' ")

        If Not dt Is Nothing Then
            dtRows = dt.Select
            For Each row In rows
                row.Delete()
            Next
        End If

        'Dim rows() As DataRow
        'Dim row As DataRow

        'rows = dtDatos.Select("estado = '" & BLOrdenes.INACTIVO & "' ")

        'For Each row In rows
        '    row.Delete()
        'Next

        Return dt

    End Function
    Public Shared Function filtrarTabla(ByVal dtBase As DataTable, ByVal filtro As String, ByVal dtContenedor As DataTable) As DataTable

        Dim rowsFiltradas() As DataRow

        rowsFiltradas = dtBase.Select(filtro)
        dtContenedor = FuncionesGenerales.copyArrayToDataTable(dtContenedor, rowsFiltradas)
        Return dtContenedor

    End Function

    Private Sub dtgDescr_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgDescr.CellClick
        Dim dtdatos As DataTable
        Dim valorcheck As Object
        Dim i As Integer
        Dim encabezado As String

        i = dtgDescr.CurrentCell.ColumnIndex
        encabezado = dtgDescr.Columns(i).HeaderText

        If encabezado = "Descripcion" Then
            Exit Sub
        End If


        dtdatos = dtgDescr.DataSource
        valorcheck = dtgDescr.CurrentCell.Value
        dtgDescr.CurrentCell.Value = "S"



        'If Not e.RowIndex = -1 Then
        '    
        '        valorcheck = dtgDescr.CurrentCell.Value
        If valorcheck Is Nothing Then
            dtdatos.BeginInit()
            dtdatos.Rows(e.RowIndex).Item("seleccionado") = "S"
            FiltarGrillaExamenes(dtDescr.Tables(1), dtdatos.Rows(e.RowIndex).Item("OBR_04_EXAM_DESC"))
            dtdatos.Rows(e.RowIndex).Item("Seleccion") = "S"
            'dtgDescr.CurrentCell.Value = "S"
            dtdatos.EndInit()
        ElseIf valorcheck = "S" Then '' truepart
            dtdatos.BeginInit()
            dtdatos.Rows(e.RowIndex).Item("seleccionado") = "S"
            dtdatos.Rows(e.RowIndex).Item("Seleccion") = "N"
            'dtgDescr.CurrentCell.Value = "N"
            FiltarGrillaQuitar(dtgExamenes.DataSource, dtdatos.Rows(e.RowIndex).Item("OBR_04_EXAM_DESC"))
            dtdatos.EndInit()
        ElseIf valorcheck = "N" Then '' falsepart
            dtdatos.BeginInit()
            dtdatos.Rows(e.RowIndex).Item("seleccionado") = "N"
            dtdatos.Rows(e.RowIndex).Item("Seleccion") = "S"
            FiltarGrillaExamenes(dtDescr.Tables(1), dtdatos.Rows(e.RowIndex).Item("OBR_04_EXAM_DESC"))
            'dtgDescr.CurrentCell.Value = "S"
            dtdatos.EndInit()
        End If
        'With dtgExamenes
        '    .Columns("OBR_04_EXAM_DESC").HeaderText = "Examen"
        '    .Columns("OBR_06_EXAM_DATE_BATCH").HeaderText = "Fecha"
        '    .Columns("PID_05_ID").Visible = False
        'End With

        'End If
    End Sub


    Private Sub dtgDescr_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgDescr.CellContentClick

    End Sub

    Private Sub dtgExamenes_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgExamenes.CellContentClick

    End Sub
End Class



