Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports System.Text.RegularExpressions
Imports System.Collections.Generic
Imports System.Data.Common
Imports System.Text
Imports HistoriaClinica.Sophia.HistoriaClinica
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports objPaciente = HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente.Paciente

Public Class frmConsultaHCEnfermeriaAlejo
    Dim strDir As String = System.Environment.SystemDirectory.ToString()
    Dim strCadenaLocal As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strDir & "\SOPHIA\Sophia.mdb"
    Dim _datosGenerales As Generales
    Dim _paciente As Paciente
    Dim _datosConexion As Conexion
    Private objIncapacidad As PlanIncapacidad
    Dim objP As objPaciente = objPaciente.Instancia
    Private objFormuExt As PlanFormuExterna 'jlalfonso

    Dim ColeccionNodo() As String
    Dim VisibleRep As String = "|"
    Dim IdEscalas As String = "0"
    Dim TN As TreeNode
    'Dim TNH As TreeNode
    Dim node As TreeNode

    Dim _OrigenAdm As String = ""

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

    Public Sub cargarHoras()
        Dim objTablasBasicas As New BLBasicasLocales

        For i As Byte = 0 To 23
            CBHoraDesde.Items.Insert(i, i)
            cbHoraHasta.Items.Insert(i, i)
        Next
        CBHoraDesde.SelectedIndex = 0
        cbHoraHasta.SelectedIndex = CBHoraDesde.Items.Count - 1
    End Sub

    Public Sub ExpandirNodos(ByVal treeNode As TreeNode)
        'For i As Byte = 0 To tvSelImpresion.Nodes.Count - 1
        '    tvSelImpresion.Nodes(i).Expand()
        'Next
        Dim node As TreeNode
        For Each node In treeNode.Nodes
            node.Expand()
            If node.Nodes.Count > 0 Then
                Me.ExpandirNodos(node)
            End If
        Next node
    End Sub

    Private Sub frmConsultaHC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        ValidaKeyPress(Me, e)
    End Sub

    Private Sub frmConsultaHC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarTiposDocumento()
        cargarHoras()
        tvSelImpresion.Nodes(0).Expand()
        ExpandirNodos(tvSelImpresion.Nodes(0))
        _datosConexion = Conexion.Instancia()
        _datosGenerales = Generales.Instancia()
        tvSelImpresion.TopNode = tvSelImpresion.Nodes(0)
        tbCodigoTipDoc.Focus()

        'Req. Datos Sensibles HC Raul Cruz
        _datosGenerales.ConsultarServidorReporte(_datosConexion)
        _OrigenAdm = _datosGenerales.OrigenAdm




    End Sub

    Public Sub mostrar(ByVal strTip_doc As String, ByVal strNum_doc As String)
        If strTip_doc.Trim.Length > 0 And strNum_doc.Trim.Length > 0 Then
            tbCodigoTipDoc.Text = strTip_doc
            txtNumDoc.Text = strNum_doc
            _datosConexion = Conexion.Instancia()
            _datosGenerales = Generales.Instancia()

            'Req. Datos Sensibles HC Raul Cruz
            _datosGenerales.ConsultarServidorReporte(_datosConexion)
            _OrigenAdm = _datosGenerales.OrigenAdm

            btnBuscar_Click(New Object(), New EventArgs())
            mskFechaDesde.Focus()
        End If

        Me.ShowDialog()
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim objPaciente As New Paciente
        Dim bPacienteEncontrado As Boolean

        Try
            'Busqueda por documento
            If Len(tbCodigoTipDoc.Text) > 0 And Len(txtNumDoc.Text) > 0 Then
                txtNumDoc.Text = Replace(Replace(Replace(Replace(Replace(Replace(txtNumDoc.Text, "=", "", 1), "OR", ""), "%", "", 1), "&", "", 1), "DELETE", "", 1), "'", "", 1)
                _paciente = New Paciente().buscarDocumento(_datosConexion, tbCodigoTipDoc.Text, txtNumDoc.Text)

                If Not New Paciente().PacienteVacio(_paciente) Then

                    If _paciente.Unificado = "U" And Not New Paciente().PacienteVacio(_paciente.PacienteUnificador) Then
                        With _paciente.PacienteUnificador
                            MsgBox("Este documento se ha unificado a el documento " _
                                   & .TipoDocumento & " " & .NumeroDocumento)
                            tbCodigoTipDoc.Text = .TipoDocumento
                            txtNumDoc.Text = .NumeroDocumento
                            txtPrimerNombre.Text = .PrimerNombre
                            txtSegundoNombre.Text = .SegundoNombre
                            txtPrimerApellido.Text = .PrimerApellido
                            txtSegundoApellido.Text = .SegundoApellido
                            ConsultarHistoria()
                        End With
                    Else
                        With _paciente
                            txtPrimerNombre.Text = .PrimerNombre
                            txtSegundoNombre.Text = .SegundoNombre
                            txtPrimerApellido.Text = .PrimerApellido
                            txtSegundoApellido.Text = .SegundoApellido
                            ConsultarHistoria()
                        End With
                    End If
                Else
                    MsgBox("Registro no existe.", MsgBoxStyle.Information)
                End If
            Else 'Busqueda por Nombre
                If Not String.IsNullOrEmpty(txtPrimerApellido.Text) And
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
                        ConsultarHistoria()
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

    Private Sub btnTraer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTraer.Click
        ConsultarHistoria()
    End Sub
    Private Sub ConsultarHistoria()
        Dim fechaInicial As Date
        Dim fechaFinal As Date
        Dim dtDatos As DataTable

        dtDatos = dtgAdmisiones.DataSource
        If Not dtDatos Is Nothing Then
            dtDatos.Clear()
        End If

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

            dtDatos = FormatoHistoriaClinicaEnfermeria.traerHistoriasXPaciente(_datosConexion, _paciente,
                                                                               fechaInicial, fechaFinal, _datosGenerales.Sucursal,
                                                                               _datosGenerales.Prestador)


            If dtDatos.Rows.Count Then
                dtgAdmisiones.DataSource = dtDatos
                '' Inicio llarias Se agrega filtro de fecha para la opcion de consulta por enfermeria
                '' OS 11460115 2018-11-19
                dtgAdmisiones.Sort(dtgAdmisiones.Columns("fec_hc"), System.ComponentModel.ListSortDirection.Descending)
                '' Fin llarias
                configurarGrilla()
            Else
                MsgBox("No existen registros que cumplan este criterio", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox("Error en la consulta de las Historias Clinicas." & ex.Message)
        End Try
    End Sub
    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Dim seccionesAdicionales As Secciones

        VisibleRep = "|"
        IdEscalas = "0"

        If _datosGenerales Is Nothing Then
            MsgBox("No existen parametros de entrada.", MsgBoxStyle.Information)
            Exit Sub
        End If

        If dtgAdmisiones.RowCount <= 0 Then
            MsgBox("Se deben consultar las historia clinicas.", MsgBoxStyle.Information)
            Exit Sub
        End If

        If ValidaArbolSelccion(tvSelImpresion.Nodes(0), False) = False Then
            MsgBox("Se deben selecccionar al menos una opci?n de impresi?n.", MsgBoxStyle.Information)
            Exit Sub
        End If

        'Inicio 20210412 Req Datos Sensibles HC, desarrollado por Raul Cruz
        If dtgAdmisiones.CurrentRow.Cells("LINKED_SERVER").Value.ToString <> "" Then
            'Se cambia por la que se trae en la grilla.
            _datosGenerales.OrigenAdm = dtgAdmisiones.CurrentRow.Cells("LINKED_SERVER").Value.ToString
        Else
            _datosGenerales.OrigenAdm = _OrigenAdm 'se deja con la inicial que carga la aplicaci?n
        End If
        'Fin 20210412 Req Datos Sensibles HC, desarrollado por Raul Cruz

        seccionesAdicionales = cargarOpcionesImpresion()

        Dim strFechaIni_RecNac As Nullable(Of DateTime)
        Dim strFechaFin_RecNac As Nullable(Of DateTime)
        Dim iHoraIni_RecNac As Nullable(Of Integer)
        Dim iHoraFin_RecNac As Nullable(Of Integer)

        If IsDate(mskFechaDesde.Text) Then
            strFechaIni_RecNac = CDate(mskFechaDesde.Text)
        Else
            strFechaIni_RecNac = Date.Now
        End If

        If IsDate(mskFechaHasta.Text) Then
            strFechaFin_RecNac = CDate(mskFechaHasta.Text)
        Else
            strFechaFin_RecNac = Date.Now
        End If

        If CBHoraDesde.SelectedIndex > 0 Then
            iHoraIni_RecNac = CBHoraDesde.SelectedIndex
        Else
            iHoraIni_RecNac = 1
        End If

        If cbHoraHasta.SelectedIndex < 23 Then
            iHoraFin_RecNac = cbHoraHasta.SelectedIndex
        Else
            iHoraFin_RecNac = 23
        End If

        TN = tvSelImpresion.Nodes(0)
        With dtgAdmisiones.CurrentRow
            'Se inicializan las variables para efectos de control de liquidos - dsanchez 21/09/2017
            'frmRepHistoriaClinicaEnfermeria.Mostrar(_datosGenerales.Prestador, _datosGenerales.Sucursal, CDbl(objP.NumeroAdmision), objP.AnoAdmision, objP.TipoAdmision, CInt(.Cells("cod_Historia").Value))

            Dim nodes As TreeNodeCollection = TN.Nodes
            'Se recorren los nodos principales
            For Each n As TreeNode In nodes
                'Se Declara un metodo para que recorra los hijos de los principales
                'Y los hijos de los hijos....Recorrido Total en pocas palabras
                'Para ello se env?a el nodo actual para evaluar si tiene hijos
                RecorrerNodos(n)
            Next

            '.Columns("Entidad").Visible = False
            '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
            'Juan Carlos Jaramillo Lozano - IG
            RptHC_Enf_Med.Show()
            RptHC_Enf_Med.ImprimirHistoriaClinica_Tree(_datosConexion, VisibleRep, "55",
                                                  .Cells("tip_doc").Value, .Cells("num_doc").Value,
                                                  .Cells("tip_admision").Value, .Cells("ano_adm").Value,
                                                  .Cells("num_adm").Value, "",
                                                  .Cells("cod_historia").Value, .Cells("cod_sucur").Value,
                                                  .Cells("cod_pre_sgs").Value,
                                                  strFechaIni_RecNac,
                                                  strFechaFin_RecNac, iHoraIni_RecNac, iHoraFin_RecNac,
                                                  IdEscalas, Date.Now)
            '2019-03-11 Fin



            'frmRepHistoriaClinicaEnfermeria.Show()
            ''frmRepHistoriaClinicaEnfermeria.ImprimirHistoriaClinica(_datosConexion, .Cells("cod_Historia").Value, strFechaIni_RecNac, strFechaFin_RecNac, iHoraIni_RecNac, iHoraFin_RecNac, tvSelImpresion.Nodes(0))
            'frmRepHistoriaClinicaEnfermeria.ImprimirHistoriaClinica(_datosConexion, .Cells("cod_Historia").Value, strFechaIni_RecNac, strFechaFin_RecNac,
            '                                                        iHoraIni_RecNac, iHoraFin_RecNac, tvSelImpresion.Nodes(0), _datosGenerales.Prestador,
            '                                                        _datosGenerales.Sucursal, .Cells("tip_admision").Value, .Cells("ano_adm").Value,
            '                                                        .Cells("num_adm").Value, .Cells("tip_doc").Value, .Cells("num_doc").Value)
        End With
    End Sub

    Private Sub RecorrerNodos(treeNode As TreeNode)
        Try
            'Si el nodo que recibimos tiene hijos se recorrer?
            'para luego verificar si esta o no checado
            For Each TNH As TreeNode In treeNode.Nodes
                'Se Verifica si esta marcado...
                If TNH.Checked = True Then
                    ColeccionNodo = TNH.Name.Split("-")
                    If ColeccionNodo.Length = 2 Then
                        If VisibleRep.IndexOf(ColeccionNodo(0)) = -1 Then
                            VisibleRep = VisibleRep & ColeccionNodo(0) & "|"
                        End If
                        If Not IdEscalas Is Nothing Then
                            If IdEscalas.IndexOf(ColeccionNodo(1)) = -1 Then
                                IdEscalas = IdEscalas & "," & ColeccionNodo(1)
                            End If
                        Else
                            IdEscalas = ColeccionNodo(1)
                        End If
                    Else
                        VisibleRep = VisibleRep & ColeccionNodo(0) & "|"
                    End If
                End If
                RecorrerNodos(TNH)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Function ValidaArbolSelccion(ByVal treeNode As TreeNode, ByVal bValidaArbolSelccion As Boolean) As Boolean
        'For i As Byte = 0 To tvSelImpresion.Nodes.Count - 1
        '    tvSelImpresion.Nodes(i).Expand()
        'Next
        Dim node As TreeNode
        If bValidaArbolSelccion = False Then
            For Each node In treeNode.Nodes
                If node.Checked = True Then
                    Return True
                End If
                If node.Nodes.Count > 0 Then
                    If ValidaArbolSelccion(node, bValidaArbolSelccion) = True Then
                        Return True
                    End If
                End If
            Next node
        Else
            Return bValidaArbolSelccion
        End If
    End Function

    Public Function cargarOpcionesImpresion() As Secciones
        Dim seccionesAdicionales As New Secciones

        With seccionesAdicionales
            '.Remision = ckRemision.Checked
            '.Recomendaciones = ckRecomendacion.Checked
            '.Triage = ckTriage.Checked
            '.Todas = ckTodos.Checked
            '.Incapacidad = ckIncapacidad.Checked
            '.Formula = ckFormula.Checked
            '.ProcedimExt = ckProcedimientosExt.Checked

        End With

        Return seccionesAdicionales
    End Function

    Public Sub configurarGrilla()
        'dtgAdmisiones.AutoGenerateColumns = False
        With dtgAdmisiones
            .Columns("cod_pre_sgs").Visible = False
            .Columns("cod_sucur").Visible = False
            '.Columns("tip_hc").Visible = False
            '.Columns("hor_hc").Visible = False
            '.Columns("min_hc").Visible = False
            .Columns("tip_doc").Visible = False
            .Columns("num_doc").Visible = False
            '.Columns("reg_med").Visible = False
            '.Columns("id_med").Visible = False
            ' .Columns("sucursal").Width = 60
            .Columns("direccion").Visible = False
            .Columns("telefono").Visible = False
            .Columns("edad").Visible = False
            .Columns("LINKED_SERVER").Visible = False
            .Columns("IdLocalizacion").Visible = False
        End With
    End Sub

    Private Sub dtgAdmisiones_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgAdmisiones.CellClick
    End Sub

    Private Sub dtgAdmisiones_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgAdmisiones.CellEnter
        dtgAdmisiones_CellClick(sender, e)
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
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
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
                If TipoLimpiar = TLimpiar.tlTodos Or (TipoLimpiar = TLimpiar.tlActivos And cControl.Enabled) Or
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
                If IsDate(mskFechaDesde.Text) Then
                    If Not CDate(mskFechaHasta.Text) >= CDate(mskFechaDesde.Text) Then
                        MsgBox("Fecha invalida. Debe digitar una fecha valida.", MsgBoxStyle.Information)
                        e.Cancel = True
                        mskFechaHasta.Select(0, mskFechaDesde.TextLength)
                    End If
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
            dtg.Rows.Remove(Me.dtgAdmisiones.Rows(0))
        Next i
    End Sub

#Region "Consulta Para Identificar Error en Examen Fisico"
    '**HDCPCEF (Habilitar - Deshabilitar C?digo Para Correcci?n Examen Fisico**
    Private Function ConsultarAdmisionesConEF_Errado(ByVal strPrestador As String, ByVal strSucursal As String, ByVal strTipoDocumento As String,
                                                     ByVal strNumeroDocumento As String, ByVal strTipoAdmision As String, ByVal intAnoAdmision As Double,
                                                     ByVal dblNumeroAdmision As Double, ByVal dteFechaHC As Date, ByVal strLogin As String, ByRef strTipoAcceso As String) As Boolean

        Dim objDAOGeneral As New Sophia.HistoriaClinica.DAO.DAOGeneral
        Dim dtDatos As DataTable
        Dim strCondicion As String
        Dim blnRespuesta As Boolean = False
        Dim dtRows() As DataRow
        Dim intOrden As Integer
        Dim dtRow As DataRow
        Dim blnAdmisionExiste As Boolean = False


        'strCondicion = "cod_pre_sgs='" & strPrestador & "' AND cod_sucur='" & strSucursal & "' AND " & _
        '               "tip_doc='" & strTipoDocumento & "' AND " & _
        '               "num_doc='" & strNumeroDocumento & "' AND tip_admision='" & strTipoAdmision & "' AND " & _
        '               "ano_adm=" & intAnoAdmision & " AND num_adm=" & dblNumeroAdmision & " AND estado='E'"

        If strLogin.Trim = _datosGenerales.Login.Trim Then
            strCondicion = "cod_pre_sgs='" & strPrestador & "' AND cod_sucur='" & strSucursal & "' AND " &
                           "tip_doc='" & strTipoDocumento & "' AND " &
                           "num_doc='" & strNumeroDocumento & "' AND login='" & _datosGenerales.Login & "' AND estado='E'"
        Else
            If _datosGenerales.MedicoRealizaCorreccion = "T" Then
                strCondicion = "cod_pre_sgs='" & strPrestador & "' AND cod_sucur='" & strSucursal & "' AND " &
                               "tip_doc='" & strTipoDocumento & "' AND " &
                               "num_doc='" & strNumeroDocumento & "' AND estado='E'"
            Else
                strCondicion = "cod_pre_sgs='" & strPrestador & "' AND cod_sucur='" & strSucursal & "' AND " &
                               "tip_doc='" & strTipoDocumento & "' AND " &
                               "num_doc='" & strNumeroDocumento & "' AND tip_admision='" & strTipoAdmision & "' AND ano_adm=" & intAnoAdmision &
                               " AND num_adm=" & dblNumeroAdmision & "AND login='" & strLogin & "' AND estado='E'"
            End If

        End If

        dtDatos = objDAOGeneral.EjecutarSQLConParametros("hcCorreccion with (NOLOCK)", _datosConexion, "cod_pre_sgs, cod_sucur, tip_admision, ano_adm, num_adm, tip_doc, num_doc, login_egreso, estado, fec_hc, fec_con, '" & _datosGenerales.Login & "' as login, obs, 0 as Orden, login as login_original", strCondicion)

        If dtDatos.Rows.Count > 0 Then
            blnRespuesta = True
            For intOrden = 0 To dtDatos.Rows.Count - 1
                If dtDatos.Rows(intOrden).Item("tip_admision") = strTipoAdmision And
                       dtDatos.Rows(intOrden).Item("ano_adm") = intAnoAdmision And
                       dtDatos.Rows(intOrden).Item("num_adm") = dblNumeroAdmision Then
                    dtDatos.Rows(intOrden).Item("orden") = 1
                    blnAdmisionExiste = True
                Else
                    If Month(dtDatos.Rows(intOrden).Item("fec_hc")) = Month(dteFechaHC) Then
                        dtDatos.Rows(intOrden).Item("orden") = 2
                    Else
                        dtDatos.Rows(intOrden).Item("orden") = 3
                    End If
                End If
            Next
            dtDatos.DefaultView.Sort = "Orden ASC, fec_hc ASC"

            If (strLogin.Trim = _datosGenerales.Login.Trim) Or (_datosGenerales.MedicoRealizaCorreccion = "T" AndAlso blnAdmisionExiste = True) Then
                Dim objPaciente As Sophia.HistoriaClinica.DatosPaciente.Paciente
                objPaciente = Sophia.HistoriaClinica.DatosPaciente.Paciente.Instancia
                objPaciente.HistoriasConErroresEF = dtDatos.DefaultView.ToTable
                strTipoAcceso = "M"
            Else
                If _datosGenerales.MedicoRealizaCorreccion <> "T" Then
                    strTipoAcceso = "N"
                Else
                    blnRespuesta = blnAdmisionExiste
                End If
            End If
        End If


        'blnRespuesta = dtDatos.Rows.Count > 0

        Return blnRespuesta

    End Function
    '**/
#End Region

    Private Sub tvSelImpresion_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvSelImpresion.AfterCheck
        If e.Action <> TreeViewAction.Unknown Then
            If e.Node.Nodes.Count > 0 Then
                Me.CheckAllChildNodes(e.Node, e.Node.Checked)
            End If
        End If
    End Sub

    Private Sub CheckAllChildNodes(ByVal treeNode As TreeNode, ByVal nodeChecked As Boolean)
        Dim node As TreeNode
        For Each node In treeNode.Nodes
            node.Checked = nodeChecked
            If node.Nodes.Count > 0 Then
                Me.CheckAllChildNodes(node, nodeChecked)
            End If
        Next node
    End Sub

    Private Sub rbImpMed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbImpMed.CheckedChanged
        Dim objPaciente As HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente.Paciente
        Dim dtgPacientes As DataGridView
        Dim controlListaEspera As ListaEspera
        ' Dim DatosPac As New ListaEspera

        ''Validacion de los parametros de entrada suministrador por sophia
        If _datosGenerales Is Nothing Then
            MsgBox("No existen parametros de entrada.", MsgBoxStyle.Information)
            Exit Sub
        End If
        Me.Close()
        frmConsultaHC.Dispose()
        Me.Visible = False
        ''Se obtiene el control Activo del contenedor de datos
        'controlListaEspera = pnlContenedorListaEspera.Controls("ListaEspera")
        controlListaEspera = ListaEspera.Instancia

        ''Si el control activo es la lista de espera
        If Not controlListaEspera Is Nothing Then
            dtgPacientes = controlListaEspera.dtgLista

            If dtgPacientes.CurrentRow Is Nothing Then

                If controlListaEspera.DatosBasicosPac.Count > 0 Then
                    frmConsultaHC.mostrar(controlListaEspera.DatosBasicosPac(1), controlListaEspera.DatosBasicosPac(0))
                    Me.Dispose(True)
                    Exit Sub
                Else
                    If controlListaEspera.txtCodigoTipoDocumento.Text.Trim <> "" And controlListaEspera.txtNumeroDocumento.Text.Trim <> "" Then
                        frmConsultaHC.mostrar(controlListaEspera.txtCodigoTipoDocumento.Text.Trim, controlListaEspera.txtNumeroDocumento.Text.Trim)
                        Me.Dispose(True)
                        Exit Sub
                    Else
                        frmConsultaHC.ShowDialog()
                        Me.Dispose(True)
                        Exit Sub
                    End If
                End If
            End If
            With dtgPacientes.CurrentRow
                If Len(.Cells("nombre").Value.ToString.Trim) <= 0 Then

                    frmConsultaHC.ShowDialog()
                    frmConsultaHC.Close()
                Else
                    If controlListaEspera.DatosBasicosPac.Count > 0 Then

                        frmConsultaHC.mostrar(controlListaEspera.DatosBasicosPac(1), controlListaEspera.DatosBasicosPac(0))
                    Else
                        frmConsultaHC.mostrar(.Cells("tip_doc").Value, .Cells("num_doc").Value)
                    End If
                End If
            End With
        Else
            objPaciente = HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente.Paciente.Instancia()
            If Not objPaciente Is Nothing Then
                frmConsultaHC.mostrar(objPaciente.TipoDocumento, objPaciente.NumeroDocumento)
            End If
        End If
        Me.Dispose(True)
        Me.Close()

    End Sub


End Class


