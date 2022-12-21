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
Imports BeeObjectsAPI

Public Class frmConsultaBeeblos
    Dim strDir As String = System.Environment.SystemDirectory.ToString()
    Dim strCadenaLocal As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strDir & "\SOPHIA\Sophia.mdb"
    Dim _datosGenerales As Generales
    Dim _paciente As Paciente
    Dim _datosConexion As Conexion
    Private objIncapacidad As PlanIncapacidad

    Dim objP As objPaciente = objPaciente.Instancia
    Private objFormuExt As PlanFormuExterna 'jlalfonso


    Dim Bee As New beeSession
    Dim BeeDoc As New beeDocument
    Dim CompanyId As Integer = 1
    Dim FullPath As String = System.IO.Path.GetTempPath()

    Dim beeCollDocClasstT As beeCollDocClass = New beeCollDocClass

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
        _datosConexion = Conexion.Instancia
        cargarTiposDocumento()
        _datosConexion = Conexion.Instancia()
        _datosGenerales = Generales.Instancia()
        tbCodigoTipDoc.Focus()

        Me.Cursor = Cursors.WaitCursor
        CargarBeeblos()
        Me.Cursor = Cursors.Default
    End Sub

    ''' <summary>
    ''' Se conecta al repositorio y si es 
    ''' efectiva, carga los repositorios
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CargarBeeblos()
        Try
            Me.Cursor = Cursors.WaitCursor

            '<example> Este ejemplo demuestra como realizar la instancía del objeto          
            '</example>

            Dim dt As DataTable

            dt = TraerBeeblosConfig()

            With Bee
                '.UserLoginName = "sysadmin"
                .UserLoginName = dt.Rows(0)("UserLoginName")
                '.password = "test"
                .password = dt.Rows(0)("password")
                '.Host = "192.168.1.59"
                .Host = dt.Rows(0)("Host")
                .Port = dt.Rows(0)("Port")
                .CompanyId = dt.Rows(0)("CompanyId")
                '.UserID = txtUserID.Text

                If .Login() Then
                    CargarRepositorios()
                    'CargarClasesDocumentales()
                Else
                    MsgBox("Error al Conectar a Beeblos", MsgBoxStyle.Critical, "Beeblos")
                End If
                'If rbPorDoc.Checked Then
                '    If
                Me.Cursor = Cursors.Default
            End With
        Catch ex As Exception
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Function TraerBeeblosConfig() As DataTable
        Dim ds As New DataSet
        Try
            Dim da As DataAdapter = New SqlClient.SqlDataAdapter("select * from GestorDocumentalBeeblos where Activo = 1", _datosConexion.getStringConnection())
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return ds.Tables(0)
    End Function

    Private Sub CargarRepositorios()
        Try
            Me.Cursor = Cursors.WaitCursor
            Bee.UserID = Bee.User.UserID.ToString()
            'Llenar Repositorios
            Bee.collRepositories = New BeeObjectsAPI.beeCollRepositories
            Bee.collRepositories.getRepositories("", "")

            Dim dt As New DataTable
            'Dim dt2 As New DataTable
            dt.Columns.Add(New DataColumn("CODE"))
            dt.Columns.Add(New DataColumn("NAME"))
            'dt2.Columns.Add(New DataColumn("CODE"))
            'dt2.Columns.Add(New DataColumn("NAME"))

            Dim dr As DataRow
            'Dim dr2 As DataRow

            For i As Int32 = 1 To Bee.collRepositories.Count
                dr = dt.NewRow()
                dr("CODE") = Bee.collRepositories.Item(i).repositoryId
                dr("NAME") = Bee.collRepositories.Item(i).repositoryname
                dt.Rows.Add(dr)
            Next

            lblRepositorios.DataSource = Nothing
            lblRepositorios.Items.Clear()
            lblRepositorios.ValueMember = "CODE"
            lblRepositorios.DisplayMember = "NAME"
            lblRepositorios.DataSource = dt
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message.ToString(), MsgBoxStyle.Critical, "Beeblos")
        End Try
    End Sub

    Private Sub CargarClasesDocumentales()
        Try
            'Clases Documentales
            Bee.beeCollDocClass = New BeeObjectsAPI.beeCollDocClass
            Bee.beeCollDocClass.getDocClass("")

            tvClases.Nodes.Clear()
            'tvClases.Nodes.Add("-2", "-- TODOS --")

            If rbTodos.Checked = True Then
                'FILTRA POR NRO DOC
                'ya se hace en :lblRepositorios_SelectedIndexChanged
                'CargarDocumentos("Todos")
                CargarDocumentos("Filtro")
                For j As Integer = 1 To tvDocumentos.Nodes.Count - 1
                    'LblDocumentos.SelectedIndex = j
                    Bee.Document = New beeDocument
                    Bee.Document.FileProfile = New beeFileProfile

                    Bee.Document.DocID = CDbl(tvDocumentos.Nodes(j).Name.ToString().Split(New Char() {"|"c})(0))
                    Bee.Document.repositoryId = CShort(lblRepositorios.SelectedValue)
                    Bee.Document.FileName = "Prueba"

                    If Bee.Document.FileProfile.getFileProfile Then
                        'For k As Integer = 1 To Bee.Document.FileProfile.DocClass.Propertys.Count
                        'If Bee.Document.FileProfile.DocClass.Propertys.Item(k).PropertyName = "Nro Doc Id" Then
                        'If Bee.Document.FileProfile.DocClass.Propertys.Item(k).PropertyValue.IndexOf(txtNumDoc.Text) <> -1 Then
                        Dim SiExiste As Boolean = False
                        For m As Integer = 0 To tvClases.Nodes.Count - 1
                            If tvClases.Nodes(m).Name = Bee.Document.FileProfile.DocClass.ID.ToString() Then
                                SiExiste = True
                            End If
                        Next
                        If SiExiste = False Then
                            For n As Integer = 1 To Bee.beeCollDocClass.Count
                                If Bee.beeCollDocClass.Item(n).ID.ToString() = Bee.Document.FileProfile.DocClass.ID.ToString() Then
                                    If Bee.beeCollDocClass.Item(n).IDDocClassPadre = 0 Then
                                        tvClases.Nodes.Add(Bee.beeCollDocClass.Item(n).ID, Bee.beeCollDocClass.Item(n).Nombre)
                                    End If
                                End If
                            Next
                        End If
                        'End If
                        'End If
                        'Next
                    End If
                Next
                CargarDocumentos("Filtro")
            Else
                'FILTRA POR NRO DOC
                'ya se hace en :lblRepositorios_SelectedIndexChanged
                CargarDocumentos("Filtro")
                For j As Integer = 0 To tvDocumentos.Nodes.Count - 1
                    'LblDocumentos.SelectedIndex = j
                    Bee.Document = New beeDocument
                    Bee.Document.FileProfile = New beeFileProfile

                    Bee.Document.DocID = CDbl(tvDocumentos.Nodes(j).Name.ToString().Split(New Char() {"|"c})(0))
                    Bee.Document.repositoryId = CShort(lblRepositorios.SelectedValue)
                    Bee.Document.FileName = "Prueba"

                    If Bee.Document.FileProfile.getFileProfile Then
                        For k As Integer = 1 To Bee.Document.FileProfile.DocClass.Propertys.Count
                            If Bee.Document.FileProfile.DocClass.Propertys.Item(k).PropertyName = "Nro Doc Id" Then
                                If Bee.Document.FileProfile.DocClass.Propertys.Item(k).PropertyValue.IndexOf(txtNumDoc.Text) <> -1 Then
                                    Dim SiExiste As Boolean = False
                                    For m As Integer = 0 To tvClases.Nodes.Count - 1
                                        If tvClases.Nodes(m).Name = Bee.Document.FileProfile.DocClass.ID.ToString() Then
                                            SiExiste = True
                                        End If
                                    Next
                                    If SiExiste = False Then
                                        For n As Integer = 1 To Bee.beeCollDocClass.Count
                                            If Bee.beeCollDocClass.Item(n).ID.ToString() = Bee.Document.FileProfile.DocClass.ID.ToString() Then
                                                tvClases.Nodes.Add(Bee.beeCollDocClass.Item(n).ID, Bee.beeCollDocClass.Item(n).Nombre)
                                            End If
                                        Next
                                    End If
                                End If
                            End If
                        Next
                    End If
                Next
                CargarDocumentos("Filtro")
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString(), MsgBoxStyle.Critical, "Beeblos")
        End Try
    End Sub

    Public Sub mostrar(ByVal strTip_doc As String, ByVal strNum_doc As String)
        If strTip_doc.Trim.Length > 0 And strNum_doc.Trim.Length > 0 Then
            tbCodigoTipDoc.Text = strTip_doc
            txtNumDoc.Text = strNum_doc
            _datosConexion = Conexion.Instancia()
            _datosGenerales = Generales.Instancia()
            btnBuscar_Click(New Object(), New EventArgs())
        End If

        Me.Show()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim objPaciente As New Paciente
        Dim bPacienteEncontrado As Boolean

        lblRepositorios.DataSource = Nothing
        lblRepositorios.Items.Clear()
        tvClases.Nodes.Clear()
        tvDocumentos.Nodes.Clear()

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

        Catch ex As Exception
            MsgBox("Error en la busqueda del paciente. " & ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

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

    Private Sub dtgAdmisiones_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    End Sub

    Private Sub dtgAdmisiones_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
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
                If TipoLimpiar = TLimpiar.tlTodos Or (TipoLimpiar = TLimpiar.tlActivos And cControl.Enabled) Or (TipoLimpiar = TLimpiar.tlInactivos And Not cControl.Enabled) Then
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

#Region "Consulta Para Identificar Error en Examen Fisico"
    '**HDCPCEF (Habilitar - Deshabilitar Código Para Corrección Examen Fisico**
    Private Function ConsultarAdmisionesConEF_Errado(ByVal strPrestador As String, ByVal strSucursal As String, ByVal strTipoDocumento As String, _
                                                     ByVal strNumeroDocumento As String, ByVal strTipoAdmision As String, ByVal intAnoAdmision As Double, _
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
            strCondicion = "cod_pre_sgs='" & strPrestador & "' AND cod_sucur='" & strSucursal & "' AND " & _
                           "tip_doc='" & strTipoDocumento & "' AND " & _
                           "num_doc='" & strNumeroDocumento & "' AND login='" & _datosGenerales.Login & "' AND estado='E'"
        Else
            If _datosGenerales.MedicoRealizaCorreccion = "T" Then
                strCondicion = "cod_pre_sgs='" & strPrestador & "' AND cod_sucur='" & strSucursal & "' AND " & _
                               "tip_doc='" & strTipoDocumento & "' AND " & _
                               "num_doc='" & strNumeroDocumento & "' AND estado='E'"
            Else
                strCondicion = "cod_pre_sgs='" & strPrestador & "' AND cod_sucur='" & strSucursal & "' AND " & _
                               "tip_doc='" & strTipoDocumento & "' AND " & _
                               "num_doc='" & strNumeroDocumento & "' AND tip_admision='" & strTipoAdmision & "' AND ano_adm=" & intAnoAdmision & _
                               " AND num_adm=" & dblNumeroAdmision & "AND login='" & strLogin & "' AND estado='E'"
            End If

        End If

        dtDatos = objDAOGeneral.EjecutarSQLConParametros("hcCorreccion with (NOLOCK)", _datosConexion, "cod_pre_sgs, cod_sucur, tip_admision, ano_adm, num_adm, tip_doc, num_doc, login_egreso, estado, fec_hc, fec_con, '" & _datosGenerales.Login & "' as login, obs, 0 as Orden, login as login_original", strCondicion)

        If dtDatos.Rows.Count > 0 Then
            blnRespuesta = True
            For intOrden = 0 To dtDatos.Rows.Count - 1
                If dtDatos.Rows(intOrden).Item("tip_admision") = strTipoAdmision And _
                       dtDatos.Rows(intOrden).Item("ano_adm") = intAnoAdmision And _
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

    Private Sub tvSelImpresion_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs)
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

    Private Sub rbImpMed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim objPaciente As HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente.Paciente
        Dim dtgPacientes As DataGridView
        Dim controlListaEspera As ListaEspera
        ' Dim DatosPac As New ListaEspera

        ''Validacion de los parametros de entrada suministrador por sophia
        If _datosGenerales Is Nothing Then
            MsgBox("No existen parametros de entrada.", MsgBoxStyle.Information)
            Exit Sub
        End If

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
                    frmConsultaHC.Show()
                    Me.Dispose(True)
                    Exit Sub
                End If
            End If
            With dtgPacientes.CurrentRow
                If Len(.Cells("nombre").Value.ToString.Trim) <= 0 Then
                    frmConsultaHC.ShowDialog()
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
    End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    CargarBeeblos()
    'End Sub

    Private Sub LblClasesDoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CargarDocumentos("PorNodo")
    End Sub

    Private Sub CargarDocumentos(ByVal Selection As String)
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim ClassID As String = ""

            Bee.collDocuments = New beeCollDocuments()

            tvDocumentos.Nodes.Clear()

            'LblDocumentos.SelectedItem = Nothing
            'LblDocumentos.DataSource = Nothing

            If Selection = "PorNodo" Then
                If Not tvClases.SelectedNode Is Nothing Then
                    ClassID = tvClases.SelectedNode.Name.ToString()
                End If
            ElseIf Selection = "Todos" Then
                ClassID = "-2"
            ElseIf Selection = "Filtro" Then
                ClassID = Selection
            End If

            If lblRepositorios.SelectedValue <> -1 And lblRepositorios.SelectedValue <> Nothing And ClassID <> "" Then

                Dim ToolTip1 As New ToolTip
                ToolTip1.SetToolTip(lblRepositorios, lblRepositorios.Text)
                'ToolTip1.SetToolTip(tvClases, tvClases.SelectedNode.Text)
                If Bee.collDocuments.Search(lblRepositorios.SelectedValue, "property_59:" & txtNumDoc.Text, "+documentstatus:storage") = True Then

                    Dim dt As New DataTable
                    dt.Columns.Add(New DataColumn("CODE"))
                    dt.Columns.Add(New DataColumn("NAME"))

                    Dim dr As DataRow

                    For i As Int32 = 1 To Bee.collDocuments.Count
                        'TODO
                        If ClassID = "Filtro" Then
                            Bee.Document = New beeDocument
                            Bee.Document.FileProfile = New beeFileProfile

                            Bee.Document.DocID = Bee.collDocuments(i).DocID
                            Bee.Document.repositoryId = CShort(lblRepositorios.SelectedValue)
                            Bee.Document.FileName = "Prueba"


                            dr = dt.NewRow()
                            dr("CODE") = Bee.collDocuments.Item(i).DocID.ToString() & "|" & Bee.collDocuments.Item(i).DocClassID.ToString()
                            dr("NAME") = Bee.collDocuments.Item(i).FileName & " / " & Bee.collDocuments.Item(i).CreateDate
                            dt.Rows.Add(dr)

                            'If Bee.Document.FileProfile.getFileProfile Then
                            '    Dim arr As Array = Bee.Document.FileProfile.fullUserProperties.ToString().Split(New Char() {"|"c})
                            '    For g As Integer = 1 To UBound(arr)
                            '        If arr(g).ToString().Length > 0 AndAlso arr(g).ToString().Substring(0, 2) = "59" Then
                            '            Dim arr2 As Array = arr(g).ToString().Split(New Char() {"#"c})
                            '            If arr2(1).ToString.IndexOf(txtNumDoc.Text.Trim) <> -1 Then
                            '                dr = dt.NewRow()
                            '                dr("CODE") = Bee.collDocuments.Item(i).DocID.ToString() & "|" & Bee.collDocuments.Item(i).DocClassID.ToString()
                            '                dr("NAME") = Bee.collDocuments.Item(i).FileName
                            '                dt.Rows.Add(dr)
                            '            End If
                            '        End If
                            '    Next
                            'End If


                        ElseIf ClassID = "-2" Then
                            dr = dt.NewRow()
                            dr("CODE") = Bee.collDocuments.Item(i).DocID.ToString() & "|" & Bee.collDocuments.Item(i).DocClassID.ToString()
                            dr("NAME") = Bee.collDocuments.Item(i).FileName & " / " & Bee.collDocuments.Item(i).CreateDate
                            dt.Rows.Add(dr)
                        ElseIf Bee.collDocuments.Item(i).DocClassID.ToString() = ClassID Then
                            dr = dt.NewRow()
                            dr("CODE") = Bee.collDocuments.Item(i).DocID.ToString() & "|" & Bee.collDocuments.Item(i).DocClassID.ToString()
                            dr("NAME") = Bee.collDocuments.Item(i).FileName & " / " & Bee.collDocuments.Item(i).CreateDate
                            dt.Rows.Add(dr)

                        End If
                    Next

                    For i As Int32 = 0 To dt.Rows.Count - 1
                        tvDocumentos.Nodes.Add(dt.Rows(i)("CODE").ToString(), dt.Rows(i)("NAME").ToString())

                        Bee.Document = New beeDocument
                        Bee.Document.FileProfile = New beeFileProfile
                        Bee.Document.DocID = CDbl(tvDocumentos.Nodes(i).Name.ToString().Split(New Char() {"|"c})(0))
                        Bee.Document.repositoryId = CShort(lblRepositorios.SelectedValue)
                        Bee.Document.FileName = "Prueba"

                        If Bee.Document.FileProfile.getFileProfile Then
                            Dim collChildrens As New beeCollDocuments
                            If Bee.Document.getChild(collChildrens) Then
                                For k As Int32 = 1 To collChildrens.Count
                                    tvDocumentos.Nodes(i).Nodes.Add(collChildrens.Item(k).DocID & "|" & collChildrens.Item(k).repositoryId, collChildrens.Item(k).FileName & " / " & Bee.collDocuments.Item(k).CreateDate)
                                Next
                            End If
                        End If

                    Next
                End If
            End If

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message.ToString(), MsgBoxStyle.Critical, "Beeblos")
        End Try
    End Sub

    Private Sub lblRepositorios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRepositorios.SelectedIndexChanged
        'CargarDocumentos("PorNodo")
        CargarClasesDocumentales()
    End Sub

    Private Sub BtnDetallesDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDetallesDoc.Click
        Try
            lblDescargaDoc.Visible = True
            Application.DoEvents()
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("CODE"))
            dt.Columns.Add(New DataColumn("NAME"))
            Dim dtClass As New DataTable
            dtClass.Columns.Add(New DataColumn("CODE"))
            dtClass.Columns.Add(New DataColumn("NAME"))
            Dim dr As DataRow
            Dim drClass As DataRow

            lblProClaseDoc.ValueMember = "CODE"
            lblProClaseDoc.DisplayMember = "NAME"
            LblPropDoc.ValueMember = "CODE"
            LblPropDoc.DisplayMember = "NAME"


            If tvClases.SelectedNode Is Nothing OrElse tvClases.SelectedNode.Name.ToString() = "-2" Or tvDocumentos.SelectedNode.Name.ToString() = Nothing Then
                drClass = dtClass.NewRow()
                drClass("CODE") = "No ha seleccionado una clase o un Documento."
                drClass("NAME") = "No ha seleccionado una clase o un Documento."
                dtClass.Rows.Add(drClass)
                lblProClaseDoc.DataSource = dtClass
                LblPropDoc.DataSource = dtClass
                Return
            End If


            Bee.Document = New beeDocument
            Bee.Document.FileProfile = New beeFileProfile

            Bee.Repository = New beeRepository
            Bee.Repository.repositoryId = CShort(lblRepositorios.SelectedValue)
            Bee.Repository.getDefinicion()

            Bee.DocClass = New beeDocClass
            Bee.DocClass.getDefinicion(CShort(tvClases.SelectedNode.Name.ToString()))

            Bee.Document.DocID = CDbl(tvDocumentos.SelectedNode.Name.ToString().Split(New Char() {"|"c})(0))
            Bee.Document.repositoryId = CShort(lblRepositorios.SelectedValue)
            Bee.Document.FileName = "Prueba"


            If Bee.Document.FileProfile.getFileProfile Then
                For i As Int32 = 1 To Bee.Document.FileProfile.DocClass.Propertys.Count
                    drClass = dtClass.NewRow()
                    drClass("CODE") = Bee.Document.FileProfile.DocClass.Propertys.Item(i).PropertyID
                    drClass("NAME") = Bee.Document.FileProfile.DocClass.Propertys.Item(i).PropertyName + ": " + Bee.Document.FileProfile.DocClass.Propertys.Item(i).PropertyValue
                    dtClass.Rows.Add(drClass)
                Next
            End If

            lblProClaseDoc.ValueMember = "CODE"
            lblProClaseDoc.DisplayMember = "NAME"
            lblProClaseDoc.DataSource = dtClass

            With BeeDoc
                .UserID = Bee.UserID
                .repositoryId = CShort(lblRepositorios.SelectedValue)
                .DocClassID = CShort(tvDocumentos.SelectedNode.Name.ToString().Split(New Char() {"|"c})(1))
                .CompanyId = CompanyId
                .DocID = CDbl(tvDocumentos.SelectedNode.Name.ToString().Split(New Char() {"|"c})(0))
                '.FileName = "test2.tif"

                If .getDocument(FullPath) = True Then

                    dr = dt.NewRow()
                    dr("CODE") = BeeDoc.DocID
                    dr("NAME") = "DocumentoID: " + BeeDoc.DocID.ToString()
                    dt.Rows.Add(dr)

                    dr = dt.NewRow()
                    dr("CODE") = BeeDoc.MimeType
                    dr("NAME") = "MimeType: " + BeeDoc.MimeType
                    dt.Rows.Add(dr)

                    For i As Int32 = 1 To BeeDoc.FileProfile.DocClass.Propertys.Count
                        dr = dt.NewRow()
                        dr("CODE") = BeeDoc.FileProfile.DocClass.Propertys.Item(i).PropertyValue
                        dr("NAME") = BeeDoc.FileProfile.DocClass.Propertys.Item(i).PropertyName + ": " + BeeDoc.FileProfile.DocClass.Propertys.Item(i).PropertyValue
                        dt.Rows.Add(dr)
                    Next
                End If
            End With
            LblPropDoc.ValueMember = "CODE"
            LblPropDoc.DisplayMember = "NAME"
            LblPropDoc.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message.ToString(), MsgBoxStyle.Critical, "Beeblos")
        Finally
            lblDescargaDoc.Visible = False
        End Try
    End Sub


    Private Sub tvClases_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvClases.AfterSelect
        CargarDocumentos("PorNodo")
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTodos.CheckedChanged
        GroupBox2.Enabled = False
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPorDoc.CheckedChanged
        GroupBox2.Enabled = True
    End Sub

    Private Sub btnRecargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecargar.Click
        CargarBeeblos()
    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        If LblPropDoc.Items.Count > 0 OrElse Not BeeDoc.FileName Is Nothing Then
            Dim sVisor As String = ProgramFilesx86() + "\STDU Viewer\STDUViewerApp.exe"
            Shell(sVisor + " " + FullPath + BeeDoc.FileName, AppWinStyle.MaximizedFocus, True)
        Else
            MsgBox("Debe seleccionar un Documento y ver Detalles antes de ejecutar esta operacion.", MsgBoxStyle.Information, "Beeblos")
        End If
    End Sub

    Public Shared Function ProgramFilesx86() As String
        If 8 = IntPtr.Size OrElse Not String.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432")) Then
            Return Environment.GetEnvironmentVariable("ProgramFiles(x86)")
        End If
        Return Environment.GetEnvironmentVariable("ProgramFiles")
    End Function

End Class

