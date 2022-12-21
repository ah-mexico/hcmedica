
Imports System.IO
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes.FuncionesGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente


#Region "Enumeración de formatos"


Public Enum CategoriaDatos
    Diagnosticos
    Procedimientos
    Productos
    OrdenMedicamentosDescripcion
    OrdenMedicamentosCodigo
    Entidades
    EntidadesNIPS
    ProductosConvenio    
    ProcedimientosEx
    ProductosEx
    ProcedimientoCodigoVarios
    DiagnosticosOncologicos
    DiagnosticosNoOncologicos
    DiagnosticosPatologicos
    DiagnosticosTraumatologicos
    Ordenindicaciones
    ProcedimientosQX
End Enum

#End Region

Public Class ComboBusqueda
    Inherits System.Windows.Forms.ComboBox
    Event ItemCambio(ByVal sender As Object)
    Private objGeneral As Generales
    Private objPaciente As Paciente

#Region "Campos protected y private"
    Protected mDatos As New DataTable
    Protected mDatosTemp As New DataTable
    Protected mCampoMostrar As String = ""
    Protected mctlTextoEnlace As TextBoxConFormato
    Protected mCampoEnlazado As String = ""
    Protected mArchivoLoad As String = ""
    Protected mValorCampoEnlazado As String = ""
    Protected mCategoriaDatos As CategoriaDatos
    Protected mDescripcion As String = ""
    Protected mLogin As String = ""
    Protected mCodprocedimiento As String = ""
    Protected cmdButton As New Button
    Protected mObligatorio As Boolean
    Protected mPrestadorMedicamento As String = ""
    Protected mSucursalMedicamento As String = ""
    Protected mEntidad As String = ""
    Protected mFechaInicialMedicamento As String = ""
    Protected mblnManejaConvenioMedicamento As Boolean
    Protected mMedicamento As String = ""
    Protected mblnConSinEstadoMedicamento As Boolean
    Protected mEdadPaciente As Integer
    Protected mSexoPaciente As String = ""
    Protected mDatoRelacionado As String = ""
    Private _botonBusqueda As Button

    Private mValidoEnter As Boolean = False
    Private mControlTieneCache As Boolean = True
    Private mGuardarArchivoCache As Boolean = True
#End Region

#Region "Eventos"
    Event ActualizarDatosElegidos(ByVal datosElegidos As DataRow)
#End Region

#Region "Métodos de Apoyo"
    Private Sub AutoCompleteCombo_KeyUp(ByVal cbo As ComboBox, ByVal e As KeyEventArgs)
        Dim sTypedText As String
        Dim iFoundIndex As Integer
        Dim oFoundItem As Object
        Dim sFoundText As String
        Dim sAppendText As String

        'Permite Seleccionar Teclas sin Autocompletar
        Select Case e.KeyCode
            Case Keys.Back, Keys.Left, Keys.Right, Keys.Up, Keys.Delete, Keys.Down, Keys.Home, Keys.ShiftKey, Keys.Shift, Keys.End, Keys.Tab
                Return
            Case Keys.Enter
                Dim recRowView As DataRowView
                Dim recName As DataRow



                If MyBase.Text.Trim.Length > 0 Then
                    AutoCompleteCombo_Leave(cbo)

                    'Consigue el Registro Seleccionado desde el Combo Enlazado a Datos (Retorna DataRowView)
                    recRowView = cbo.SelectedItem
                    If recRowView Is Nothing Then
                        mValorCampoEnlazado = ""
                        _botonBusqueda.Focus()
                        Me.mctlTextoEnlace.Text = mValorCampoEnlazado
                        Exit Sub
                    End If

                    'Muestra el Información del nombre(La fila viene desde el dataset enlazado)
                    recName = recRowView.Row
                    recName("cons") = recName("cons") + 1
                    mValorCampoEnlazado = recName(Me.mCampoEnlazado)
                    Me.mctlTextoEnlace.Text = mValorCampoEnlazado
                    ''My.Computer.Keyboard.SendKeys("{TAB}")

                    'Me.Parent.GetNextControl(Me, True).Focus()
                    SiguienteControl(Me).Focus()
                Else
                    mValorCampoEnlazado = ""
                    Me.mctlTextoEnlace.Text = mValorCampoEnlazado
                    'Me.Parent.GetNextControl(Me, True).Focus()
                    SiguienteControl(Me).Focus()
                End If
                mValidoEnter = True
                Exit Sub
            Case 219
                Return
        End Select

        ''Se valida si se cambia de buscar por codigo o por descripcion 
        ''Se se digita algo en el textboxconformato la categoria es OrdenMedicamentosCodigo
        ''si se digita algo en el comboBusqueda la categoria se cambia a OrdenMedicamentosDescripcion
        If CategoriaDatos = HistoriaClinica.CategoriaDatos.OrdenMedicamentosCodigo Then
            CategoriaDatos = HistoriaClinica.CategoriaDatos.OrdenMedicamentosDescripcion
        End If
        'AGFA_ORM_IN herojas 2014/10/10
        If CategoriaDatos = HistoriaClinica.CategoriaDatos.ProcedimientoCodigoVarios Then
            CategoriaDatos = HistoriaClinica.CategoriaDatos.Procedimientos
        End If

        'Consigue el Texto escrito t lo encuentra en la lista
        sTypedText = cbo.Text
        iFoundIndex = cbo.FindString(sTypedText)

        'Si el texto es encontrado en la lista se realiza el Autocomplete
        If iFoundIndex >= 0 Then

            'Consigue el Item de la Lista(Retorna un Tipo dependiendo si Origen de Datos es enlazado
            ' o la Lista Creada)
            oFoundItem = cbo.Items(iFoundIndex)

            'Use el ListControl.GetItemText para resolver el Nombre en caso de que el Combo
            'haya sido enlazado a Datos
            sFoundText = cbo.GetItemText(oFoundItem)

            'Adiciona al texto escrito, el texto encontrado para preservar el caso
            sAppendText = sFoundText.Substring(sTypedText.Length)
            cbo.Text = sTypedText & sAppendText

            'Selecciona el texto adicionado
            cbo.SelectionStart = sTypedText.Length
            cbo.SelectionLength = sAppendText.Length

        End If

    End Sub

    Public Sub CargarDatos()
        Dim value As Boolean
        Dim strDirSys As String
        Dim dt As New DataTable
        Dim dv As DataView
        Dim ListaDatos As New AutoCompleteStringCollection()
        Dim intRow As Integer
        Dim objDatosGenerales As HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales.Generales


        If mCategoriaDatos = HistoriaClinica.CategoriaDatos.OrdenMedicamentosCodigo Or mCategoriaDatos = HistoriaClinica.CategoriaDatos.OrdenMedicamentosDescripcion Then
            Exit Sub
        End If

        If Me.mControlTieneCache = False Then
            If Me.mGuardarArchivoCache = True Then
                GuardarDatos()
            End If
            Me.mctlTextoEnlace.AutoCompleteCustomSource = Nothing
            Me.OrigenDeDatos = Nothing
            Exit Sub
        End If

        objDatosGenerales = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales.Generales.Instancia
        mLogin = objDatosGenerales.Login.ToUpper

        strDirSys = Environment.SystemDirectory.ToString()
        'value = My.Computer.FileSystem.FileExists(strDirSys & "\sophia\" & Me.mArchivoLoad)
        If value Then
            dt.ReadXml(strDirSys & "\sophia\" & Me.mArchivoLoad)
            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    dv = dt.DefaultView
                    dv.RowFilter = "Login='" & mLogin & "'"
                    'dv.RowStateFilter = DataViewRowState.CurrentRows
                    For intRow = 0 To dt.Rows.Count - 1
                        ListaDatos.Add(dt.Rows(intRow)(Me.mCampoEnlazado))
                    Next
                    'Me.mctlTextoEnlace.AutoCompleteSource = Windows.Forms.AutoCompleteSource.CustomSource
                    'Me.mctlTextoEnlace.AutoCompleteMode = Windows.Forms.AutoCompleteMode.Suggest
                    'Me.mctlTextoEnlace.AutoCompleteCustomSource = ListaDatos
                    Me.OrigenDeDatos = dt
                    Me.ResetText()
                End If
            End If
        End If
    End Sub

    Private Sub GuardarDatos()

        Dim strDirSys As String
        Dim dv As DataView

        If mCategoriaDatos = HistoriaClinica.CategoriaDatos.OrdenMedicamentosCodigo Or _
            mCategoriaDatos = HistoriaClinica.CategoriaDatos.OrdenMedicamentosDescripcion Or _
            mCategoriaDatos = HistoriaClinica.CategoriaDatos.EntidadesNIPS Or _
            mCategoriaDatos = HistoriaClinica.CategoriaDatos.Entidades Then
            Exit Sub
        End If



        If mDatos Is Nothing Then
            Exit Sub
        End If

        If mDatos.Rows.Count > 20 Then
            dv = mDatos.DefaultView
            dv.Sort = "cons ASC"
            dv.Delete(0)
        End If

        strDirSys = Environment.SystemDirectory.ToString()
        If mDatos.TableName.Trim.Length = 0 And mArchivoLoad.Trim.Length > 0 Then
            mDatos.TableName = Me.mArchivoLoad.Substring(1, Me.mArchivoLoad.Trim.Length - 4)
        End If

        'mDatos.WriteXml(strDirSys & "\Sophia\" & Me.mArchivoLoad, XmlWriteMode.WriteSchema)


    End Sub

    Public Sub CargarButton()
        'Dim imageb As Image = Image.FromFile(My.Resources.Busca)

        If Not Me.Parent Is Nothing Then
            Me.Parent.Controls.Add(cmdButton)
        End If
        With cmdButton
            .Location = New System.Drawing.Point(Me.Location.X + Me.Width + 1, Me.Location.Y)
            .FlatStyle = Windows.Forms.FlatStyle.Flat
            .Width = 62
            .Height = 22
            .Image = My.Resources.Ibuscar
            .FlatAppearance.BorderSize = 0
            .BackColor = Color.White
            AddHandler .Click, AddressOf ClickEvent
            .Cursor = Cursors.Hand
        End With

        _botonBusqueda = (cmdButton)
    End Sub

    Public Sub CargarButtonFarma(ByVal nombre As String)

        If Not Me.Parent Is Nothing Then
            Me.Parent.Controls.Add(cmdButton)
        End If
        With cmdButton
            .Location = New System.Drawing.Point(Me.Location.X + Me.Width + 1, Me.Location.Y)
            .FlatStyle = Windows.Forms.FlatStyle.Flat
            .Width = 62
            .Height = 22
            .Image = My.Resources.Ibuscar
            .FlatAppearance.BorderSize = 0
            .BackColor = Color.White
            AddHandler .Click, AddressOf ClickEvent
            .Cursor = Cursors.Hand
            .Text = nombre
            .ForeColor = Color.Transparent
        End With

        _botonBusqueda = (cmdButton)
    End Sub

    Private Sub ClickEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim blnBuscador As Boolean
        Dim result As DialogResult


        If mCategoriaDatos = HistoriaClinica.CategoriaDatos.OrdenMedicamentosCodigo Then
            Sophia.HistoriaClinica.Buscador.frmBuscador.Mostrar(mCategoriaDatos, Me, Me.mctlTextoEnlace.Text)
        Else
            If Me.Text.Trim.Length < 2 Then
                Exit Sub
            End If

            'If mCategoriaDatos = HistoriaClinica.CategoriaDatos.ProductosConvenio Then
            '    If Me.UltimaDescripcionDeBusqueda = "X" Then
            '        Me.UltimaDescripcionDeBusqueda = ""
            '        'Me.Text = ""
            '        Me.Focus()
            '        Exit Sub
            '    End If
            'End If

            If InStr(Me.UltimaDescripcionDeBusqueda, "ITEM$NO$ENCONTRADO$") > 0 Then
                If Trim(Me.UltimaDescripcionDeBusqueda) = "ITEM$NO$ENCONTRADO$" & Trim(Me.Text) Then
                    'Me.UltimaDescripcionDeBusqueda = Me.Text

                    'cdqf no vademecum
                    If sender.text = "-" And Me.Parent.Name = "pnlDatosAntecedentesFarmacologicos" Then

                        result = MessageBox.Show("No existen registros para esta búsqueda, registre medicamento fuera del listado", "Buscador", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

                        If result = DialogResult.OK Then

                            Me.Parent.Controls("txtCodFarmacoAFar").Text = ""
                            Me.Parent.Controls("cboMedicamentosAF").Text = ""
                            'Me.Parent.Controls("txtObservacionesAFar").Text = ""
                            'Campos nuevos CU1 INDRA/ojparra 
                            Me.Parent.Controls("txtDosisAFar").Text = ""
                            Me.Parent.Controls("cmbUnidadMedidaAFar").Select()
                            Me.Parent.Controls("cmbViaAdministracionAFar").Select()
                            Me.Parent.Controls("cmbFrecuenciaAFar").Select()


                            Me.Parent.Controls("txtCodFarmacoAFar").Enabled = False
                            Me.Parent.Controls("txtCodFarmacoAFar").Visible = False
                            Me.Parent.Controls("cboMedicamentosAF").Enabled = False
                            Me.Parent.Controls("cboMedicamentosAF").Visible = False
                            'Me.Parent.Controls("txtObservacionesAFar").Enabled = False

                            'Me.Parent.Controls("cmdAdicionarAFar").Enabled = False

                            Me.Parent.Controls("lblOtroFarma").Enabled = True
                            'Me.Parent.Controls("LblDfFarma").Enabled = True
                            Me.Parent.Controls("lblOtroFarma").Visible = True
                            'Me.Parent.Controls("LblDfFarma").Visible = True

                            Me.Parent.Controls("TbxOtroMed").Text = ""
                            'Me.Parent.Controls("TbxOtroDosisFrec").Text = ""
                            Me.Parent.Controls("TbxOtroMed").Visible = True
                            'Me.Parent.Controls("TbxOtroDosisFrec").Visible = True
                            Me.Parent.Controls("TbxOtroMed").Enabled = True
                            'Me.Parent.Controls("TbxOtroDosisFrec").Enabled = True
                            'Me.Parent.Controls("BtnOtroAdd").Visible = True
                            'Me.Parent.Controls("BtnOtroAdd").Enabled = True
                            Me.Parent.Controls("Label60").Visible = False


                        Else
                            ' Me.Parent.Controls("ChbxNoVademec").Visible = False
                            ' MessageBox.Show("No existen registros para esta búsqueda", "Buscador", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            ' Me.Parent.Controls("txtCodFarmacoAFar").Text = ""
                            ' Me.Parent.Controls("cboMedicamentosAF").Text = ""
                            ' Me.Parent.Controls("txtObservacionesAFar").Text = ""

                            Me.Parent.Controls("txtCodFarmacoAFar").Enabled = True
                            Me.Parent.Controls("cboMedicamentosAF").Enabled = True
                            'Me.Parent.Controls("txtObservacionesAFar").Enabled = True

                            'Me.Parent.Controls("cmdAdicionarAFar").Enabled = True

                            Me.Parent.Controls("lblOtroFarma").Enabled = False
                            'Me.Parent.Controls("LblDfFarma").Enabled = False
                            Me.Parent.Controls("lblOtroFarma").Visible = False
                            'Me.Parent.Controls("LblDfFarma").Visible = False

                            Me.Parent.Controls("TbxOtroMed").Text = ""
                            'Me.Parent.Controls("TbxOtroDosisFrec").Text = ""
                            'Campos nuevos CU1 INDRA/ojparra 

                            Me.Parent.Controls("TbxOtroMed").Visible = False
                            'Me.Parent.Controls("TbxOtroDosisFrec").Visible = False

                            Me.Parent.Controls("TbxOtroMed").Enabled = False
                            'Me.Parent.Controls("TbxOtroDosisFrec").Enabled = False
                            'Me.Parent.Controls("BtnOtroAdd").Visible = False
                            'Me.Parent.Controls("BtnOtroAdd").Enabled = False
                            'Me.Parent.Controls("Label60").Visible = False
                            'Me.Parent.Controls("txtCodFarmacoAFar").Visible = False
                            'Me.Parent.Controls("cboMedicamentosAF").Visible = False

                            'Me.Parent.Controls("BtnOtroAdd").Visible = False
                            'Me.Parent.Controls("BtnOtroAdd").Enabled = False
                            Me.Focus()
                            Exit Sub
                        End If

                    Else
                        If Trim(Me.UltimaDescripcionDeBusqueda) = "ITEM$NO$ENCONTRADO$" & Trim(Me.Text) Then
                            Me.Focus()
                            Exit Sub
                        End If
                        MessageBox.Show("No existen registros para esta búsqueda", "Buscador", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Focus()
                        Exit Sub

                    End If

                Else
                    If Trim(Me.UltimaDescripcionDeBusqueda) = "ITEM$NO$ENCONTRADO$" & Trim(Me.Text) Then
                        Me.Focus()
                        Exit Sub
                    End If
                    blnBuscador = True
                End If
            Else
                If Me.UltimaDescripcionDeBusqueda <> Me.Text Then
                    blnBuscador = True
                End If
            End If
            If blnBuscador = True Then
                Sophia.HistoriaClinica.Buscador.frmBuscador.Mostrar(mCategoriaDatos, Me, Me.Text)
                'RaiseEvent ActualizarDatosElegidos(Nothing)
            Else
                'Me.Focus()
                Exit Sub
            End If
        End If

        If Not Me.CodigoTipoProcedimiento Is Nothing Then
            If MyBase.Text.Length > 0 And Me.CodigoTipoProcedimiento <> "" Then
                'Me.Parent.GetNextControl(Me, True).Focus()
                SiguienteControl(Me).Focus()
            End If
        End If

        objGeneral = Generales.Instancia
        'cdqf no vademecum
        If objGeneral.strNoVademecum = True And sender.text = "-" And Me.Parent.Name = "pnlDatosAntecedentesFarmacologicos" Then

            Me.Parent.Controls("txtCodFarmacoAFar").Text = ""
            Me.Parent.Controls("cboMedicamentosAF").Text = ""
            'Me.Parent.Controls("txtObservacionesAFar").Text = ""
            Me.Parent.Controls("txtDosisAFar").Text = ""
            Me.Parent.Controls("cmbUnidadMedidaAFar").Select()
            Me.Parent.Controls("cmbViaAdministracionAFar").Select()
            Me.Parent.Controls("cmbFrecuenciaAFar").Select()

            'Ocultar el botón buscar cuando se grabe un medicamento NoVademecum
            cmdButton.Visible = False

            Me.Parent.Controls("txtCodFarmacoAFar").Enabled = False
            Me.Parent.Controls("cboMedicamentosAF").Enabled = False
            Me.Parent.Controls("txtCodFarmacoAFar").Visible = False
            Me.Parent.Controls("cboMedicamentosAF").Visible = False

            Me.Parent.Controls("Label60").Enabled = False
            Me.Parent.Controls("Label60").Visible = False

            Me.Parent.Controls("lblOtroFarma").Enabled = True
            Me.Parent.Controls("lblOtroFarma").Visible = True
            Me.Parent.Controls("TbxOtroMed").Text = ""
            Me.Parent.Controls("TbxOtroMed").Visible = True
            Me.Parent.Controls("TbxOtroMed").Enabled = True

            'Campos nuevos CU_CONC_01. (VISUALIZAR CONCILIACIÓN DE MEDICAMENTOS EN ANTECEDENTES FARMACOLOGICOS) INDRA/OJPARRA 
            'Me.Parent.Controls("txtObservacionesAFar").Enabled = False
            'Me.Parent.Controls("cmdAdicionarAFar").Enabled = False
            'Me.Parent.Controls("LblDfFarma").Enabled = True
            'Me.Parent.Controls("LblDfFarma").Visible = True
            'Me.Parent.Controls("TbxOtroDosisFrec").Text = ""
            'Campos nuevos CU1 INDRA/ojparra 
            'Me.Parent.Controls("TbxOtroDosisFrec").Visible = True
            'Me.Parent.Controls("TbxOtroDosisFrec").Enabled = True
            'Me.Parent.Controls("BtnOtroAdd").Visible = True
            'Me.Parent.Controls("BtnOtroAdd").Enabled = True

        ElseIf objGeneral.strNoVademecum = False And sender.text = "-" And Me.Parent.Name = "pnlDatosAntecedentesFarmacologicos" Then

                Me.Parent.Controls("txtCodFarmacoAFar").Enabled = True
            Me.Parent.Controls("cboMedicamentosAF").Enabled = True

            'Campos nuevos CU_CONC_01. (VISUALIZAR CONCILIACIÓN DE MEDICAMENTOS EN ANTECEDENTES FARMACOLOGICOS) INDRA/OJPARRA 
            'Me.Parent.Controls("txtObservacionesAFar").Enabled = True
            'Campos nuevos CU1 INDRA/ojparra 
            Me.Parent.Controls("txtDosisAFar").Enabled = True
            Me.Parent.Controls("cmbUnidadMedidaAFar").Enabled = True
            Me.Parent.Controls("cmbViaAdministracionAFar").Enabled = True
            Me.Parent.Controls("cmbFrecuenciaAFar").Enabled = True

            'Me.Parent.Controls("cmdAdicionarAFar").Enabled = True

            Me.Parent.Controls("lblOtroFarma").Enabled = False
            'Me.Parent.Controls("LblDfFarma").Enabled = False
            Me.Parent.Controls("lblOtroFarma").Visible = False
            'Me.Parent.Controls("LblDfFarma").Visible = False

            Me.Parent.Controls("TbxOtroMed").Text = ""
            'Me.Parent.Controls("TbxOtroDosisFrec").Text = ""
            Me.Parent.Controls("TbxOtroMed").Visible = False
            'Me.Parent.Controls("TbxOtroDosisFrec").Visible = False
            Me.Parent.Controls("TbxOtroMed").Enabled = False
            'Me.Parent.Controls("TbxOtroDosisFrec").Enabled = False
            'Me.Parent.Controls("BtnOtroAdd").Visible = False
            'Me.Parent.Controls("BtnOtroAdd").Enabled = False


        End If

    End Sub

    'Inicia: INDRA/OJPARRA  09/03/2022
    'Proyecto: Sophia - Conciliación Medicamentos (VISUALIZAR CONCILIACIÓN DE MEDICAMENTOS EN ANTECEDENTES FARMACOLOGICOS CU1)
    'Cambio: Método que indica en qué momento se debe mostrar el botón Buscar cuando se esta adicionando o modificando un medicamento OtroMed.
    Public Sub MuestraButtonBuscar(ByVal mostrar As Boolean)
        If mostrar = False Then
            cmdButton.Visible = False
        Else
            cmdButton.Visible = True
        End If

    End Sub

    Public Sub AdicionarDato(ByVal Valores As DataRow)
        'Dim dFila As DataRow
        'Dim intFila As Integer
        Dim dv As DataView
        Dim dRows() As DataRow
        'dFila = mDatos.NewRow()
        'For intFila = 0 To Valores.Length - 1
        '    dFila.Item(intFila) = Valores(intFila)
        'Next
        Try
            dRows = mDatos.Select(mCampoEnlazado & "='" & Valores(mCampoEnlazado).ToString & "'")

            If dRows.Length <= 0 Then
                mDatos.ImportRow(Valores)
                dv = mDatos.DefaultView
                dv.RowFilter = "Login='" & mLogin & "'"
                'Me.ControlTextoEnlace.AutoCompleteCustomSource.Add(Me.mValorCampoEnlazado)
            End If
            Me.Text = Valores(Me.mCampoMostrar)
            Me.mValorCampoEnlazado = Valores(Me.mCampoEnlazado).ToString
            Me.ControlTextoEnlace.Text = Me.mValorCampoEnlazado
            'dv.RowStateFilter = DataViewRowState.OriginalRows
            'Me.Text = dFila(Me.mCampoMostrar)
            'RaiseEvent ActualizarDatosElegidos(Valores)
            'AutoCompleteCombo_Leave(Me)
        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub AutoCompleteCombo_Leave(ByVal cbo As ComboBox)
        Dim iFoundIndex As Integer
        iFoundIndex = cbo.FindStringExact(cbo.Text)
        cbo.SelectedIndex = iFoundIndex
    End Sub

    Public Function BuscarCodigo(ByVal strCodigo As String) As String
        Dim objDatos As New Sophia.HistoriaClinica.DAO.DAOGeneral
        Dim dtDatos As New DataTable
        Dim dtRowSel As DataRow
        Dim strDescripcion As String
        Dim objConexion As Sophia.HistoriaClinica.DatosConexion.Conexion = Sophia.HistoriaClinica.DatosConexion.Conexion.Instancia

        objGeneral = Generales.Instancia
        objPaciente = Paciente.Instancia ''cpgaray OS9673589, no se está refrescando el genero y la edad del paciente lo que genera errores en la busqueda de diagnosticos

        strDescripcion = ""
        Try
            'Me.CargarDatos()
            'dtDatos = objDatos.EjecutarSPConParametros("HC_BuscarCodigo", objConexion, -1, Me.mDescripcion, strCodigo, Me.mEdadPaciente, IIf(Me.SexoPaciente Is Nothing, "", Me.SexoPaciente), _
            '                                           IIf(Me.mblnManejaConvenioMedicamento = False, "N", "S"), IIf(Me.mMedicamento Is Nothing, "", Me.mMedicamento), _
            '                                           IIf(Me.mblnConSinEstadoMedicamento = False, 0, 1), IIf(objGeneral.Prestador Is Nothing, "", objGeneral.Prestador), _
            '                                           IIf(objGeneral.Sucursal, "", objGeneral.Sucursal), IIf(Me.mEntidad Is Nothing, "", Me.mEntidad), IIf(Me.mFechaInicialMedicamento Is Nothing, "", Me.mFechaInicialMedicamento), IIf(Me.mCodprocedimiento Is Nothing, "", Me.mCodprocedimiento))

            ''cpgaray OS9673589, no se está refrescando el genero y la edad del paciente lo que genera errores en la busqueda de diagnosticos
            dtDatos = objDatos.EjecutarSPConParametros("HC_BuscarCodigo", objConexion, -1, mCategoriaDatos, strCodigo, objPaciente.Edad, IIf(objPaciente.Genero Is Nothing, "", objPaciente.Genero),
                                           IIf(Me.mblnManejaConvenioMedicamento = False, "N", "S"), IIf(Me.mMedicamento Is Nothing, "", Me.mMedicamento),
                                           IIf(Me.mblnConSinEstadoMedicamento = False, 0, 1), IIf(objGeneral.Prestador Is Nothing, "", objGeneral.Prestador),
                                           IIf(objGeneral.Sucursal, "", objGeneral.Sucursal), IIf(Me.mEntidad Is Nothing, "", Me.mEntidad), IIf(Me.mFechaInicialMedicamento Is Nothing, "", Me.mFechaInicialMedicamento), IIf(Me.mCodprocedimiento Is Nothing, "", Me.mCodprocedimiento))
            dtDatos.Columns.Add("login", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("cons", System.Type.GetType("System.Int32"))
            'dtDatos.Columns.Add("bilateral", System.Type.GetType("System.Int32"))

            If dtDatos.Rows.Count > 0 Then
                If dtDatos.Rows.Count = 1 Then ' agfa_orm_in herojas 2014/10/10
                    If Me.CategoriaDatos = HistoriaClinica.CategoriaDatos.ProductosConvenio And
                       Me.ConvenioMedicamento = True Then
                        If dtDatos.Rows(0).Item("convenio").ToString = "N" Then
                            Me.ControlTextoEnlace.Text = ""
                            MessageBox.Show("Este medicamento no es cubierto por la entidad seleccionada." & vbCrLf & "Debe ser formulado por otra entidad.", "Historia clínica", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Return ""
                        End If
                    End If
                    If Me.mDatos Is Nothing Then
                        dtDatos.Rows(0).Item("cons") = 1
                        dtDatos.Rows(0).Item("Login") = Me.mLogin
                        Me.OrigenDeDatos = dtDatos
                        strDescripcion = dtDatos.Rows(0).Item("descripcion").ToString()
                    Else
                        If Me.mDatos.Rows.Count <= 0 Then
                            dtDatos.Rows(0).Item("cons") = 1
                            dtDatos.Rows(0).Item("Login") = Me.mLogin
                            Me.OrigenDeDatos = dtDatos
                            strDescripcion = dtDatos.Rows(0).Item("descripcion").ToString()
                        Else
                            If dtDatos.Rows.Count = 1 Then
                                dtRowSel = dtDatos.Rows(0)
                                dtRowSel("Login") = Me.mLogin
                                dtRowSel("cons") = 1
                                Me.AdicionarDato(dtRowSel)
                                strDescripcion = dtRowSel("descripcion").ToString()
                            End If
                        End If
                    End If

                    ''Se lanza el evento que permite acceder a la informacion encontrada 
                    ''para ser actualizada o procesada por el contenedor del control. Ejm 
                    ''Actualizar el centro de costo en las ordenes de procedimientos
                    RaiseEvent ActualizarDatosElegidos(dtDatos.Rows(0))
                Else ' agfa_orm_in herojas 2014/10/10
                    Sophia.HistoriaClinica.Buscador.frmBuscador.Mostrar(CategoriaDatos.ProcedimientoCodigoVarios, Me, strCodigo, dtDatos) ' agfa_orm_in herojas 2014/10/10
                    dtDatos.Rows(0).Item("cons") = 1
                    dtDatos.Rows(0).Item("Login") = Me.mLogin
                    Me.OrigenDeDatos = dtDatos
                    strDescripcion = dtDatos.Rows(0).Item("descripcion").ToString()
                    RaiseEvent ActualizarDatosElegidos(dtDatos.Rows(0))
                End If
            Else
                MessageBox.Show("No existen registros para esta búsqueda", "Buscador", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
            ''Fin llarias
        Catch ex As Exception
            MessageBox.Show("Error consultando datos. " & ex.Message(), "Historia Clinica", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return strDescripcion
    End Function

    Private Function BuscarDescripcion(ByVal strDescripcion As String) As String
        Dim strRespuesta As String
        Dim dtRows() As DataRow

        strRespuesta = ""

        If Me.mDatos Is Nothing Then
            Return strRespuesta
            Exit Function
        End If

        If Me.mDatos.Columns.Count = 0 Then
            Return strRespuesta
        End If


        dtRows = Me.mDatos.Select(mCampoMostrar & "='" & strDescripcion & "'")
        If dtRows.Length > 0 Then
            strRespuesta = dtRows(0).Item(mCampoEnlazado).ToString
            RaiseEvent ActualizarDatosElegidos(dtRows(0))
        Else
            RaiseEvent ActualizarDatosElegidos(Nothing)
        End If

        Return strRespuesta
    End Function

    Public Sub lanzaEventoActualizarDatosElegidos(ByVal drDatosElegidos As DataRow)
        RaiseEvent ActualizarDatosElegidos(drDatosElegidos)
    End Sub

#End Region

#Region "Eventos Modificados"

    Protected Overloads Sub OnLostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim strCodigo As String

        If MyBase.Text.Trim.Length = 0 Then
            Exit Sub
        End If
        If mValidoEnter = True Then
            mValidoEnter = False
            Exit Sub
        End If

        strCodigo = BuscarDescripcion(MyBase.Text.Trim)
        Me.ControlTextoEnlace.Text = strCodigo



        'Me.lanzaEventoActualizarDatosElegidos(Nothing)

        RaiseEvent ItemCambio(Me)
    End Sub

    Private Sub ComboBusqueda_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        'Me.ResetText()
        If mCategoriaDatos = HistoriaClinica.CategoriaDatos.OrdenMedicamentosCodigo Then
            mCategoriaDatos = HistoriaClinica.CategoriaDatos.OrdenMedicamentosDescripcion
        End If
    End Sub

    Private Sub ComboBusqueda_HandleDestroyed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.HandleDestroyed
        GuardarDatos()
    End Sub

    Private Sub ComboBusqueda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = "'" Then
            e.Handled = True
            Exit Sub
        End If
    End Sub

    Private Sub ComboBusqueda_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        AutoCompleteCombo_KeyUp(sender, e)
    End Sub

    Private Sub ComboBusqueda_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
        'Dim recRowView As DataRowView
        'Dim recName As DataRow
        'Dim j As New ArrayList


        'AutoCompleteCombo_Leave(sender)

        ''Consigue el Registro Seleccionado desde el Combo Enlazado a Datos (Retorna DataRowView)
        'recRowView = sender.SelectedItem
        'If recRowView Is Nothing Then
        '    mValorCampoEnlazado = ""
        '    cmdButton.Focus()
        '    Me.mctlTextoEnlace.Text = mValorCampoEnlazado
        '    Exit Sub
        'End If

        ''Muestra el Información del nombre(La fila viene desde el dataset enlazado)
        'recName = recRowView.Row
        'recName("cons") = recName("cons") + 1
        'mValorCampoEnlazado = recName(Me.mCampoEnlazado)
        'Me.mctlTextoEnlace.Text = mValorCampoEnlazado
        ''My.Computer.Keyboard.SendKeys("{TAB}")

    End Sub
#End Region

#Region "Nuevas Propiedades"

    'Es el campo que muestra la información que se ve en el combo
    <System.ComponentModel.Category("Misc"), System.ComponentModel.Description("Devuelve o establece el nombre del campo que muestra la información en el Combo")> _
    Public Property CampoMostrar() As String
        Get
            Return Me.mCampoMostrar
        End Get
        Set(ByVal Value As String)
            Me.mCampoMostrar = Value
            Me.DisplayMember = mCampoMostrar
        End Set
    End Property

    'Devuelve o establece el Origen de Datos de Información del Combo
    <System.ComponentModel.Category("Misc"), System.ComponentModel.Description("Devuelve o establece el Origen de Datos de Información del Combo")> _
    Public Property OrigenDeDatos() As DataTable
        Get
            Return Me.mDatos
        End Get
        Set(ByVal Value As DataTable)
            Me.mDatos = Value
            Me.DataSource = mDatos
        End Set
    End Property

    'Indica si el control debe tener o no información de caché
    <System.ComponentModel.Category("Misc"), System.ComponentModel.Description("Indica si el control debe tener o no información de caché")> _
    Public Property ControlTieneCache() As Boolean
        Get
            Return Me.mControlTieneCache
        End Get
        Set(ByVal Value As Boolean)
            If (mControlTieneCache = True) And (Value = False Or Value = True) Then
                Me.mGuardarArchivoCache = True
            Else
                Me.mGuardarArchivoCache = False
            End If
            Me.mControlTieneCache = Value
        End Set
    End Property

    'Indica si el control debe guardar o no información de caché
    <System.ComponentModel.Category("Misc"), System.ComponentModel.Description("Indica si el control debe guardar o no información de caché")> _
    Public ReadOnly Property GuardarArchivoCache() As Boolean
        Get
            Return Me.mGuardarArchivoCache
        End Get
    End Property


    'Devuelve o establece el Origen de Datos Temporal  de Información del Combo
    <System.ComponentModel.Category("Misc"), System.ComponentModel.Description("Devuelve o establece el Origen de Datos Temporal de Información del Combo")> _
    Public Property OrigenDeDatosTemporal() As DataTable
        Get
            Return Me.mDatosTemp
        End Get
        Set(ByVal Value As DataTable)
            Me.mDatosTemp = Value
            Me.DataSource = mDatosTemp
        End Set
    End Property

    <System.ComponentModel.Category("Misc"), System.ComponentModel.Description("El Control Texto donde se escribe el valor del Campo Relacionado con el Item Mostrado en el Combo")> _
    Public Property ControlTextoEnlace() As TextBox
        Get
            Return Me.mctlTextoEnlace
        End Get
        Set(ByVal Value As TextBox)
            Me.mctlTextoEnlace = Value
        End Set
    End Property

    <System.ComponentModel.Category("Misc"), System.ComponentModel.Description("El Nombre del Campo relacionado con el Control Texto de Enlace")> _
    Public Property CampoEnlazado() As String
        Get
            Return Me.mCampoEnlazado
        End Get
        Set(ByVal Value As String)
            Me.mCampoEnlazado = Value
        End Set
    End Property

    <System.ComponentModel.Category("Misc"), System.ComponentModel.Description("Valor del Campo Enlazado")> _
    Public Property ValorCampoEnlazado() As String
        Get
            Return Me.mValorCampoEnlazado
        End Get
        Set(ByVal Value As String)
            Me.mValorCampoEnlazado = Value
        End Set
    End Property

    <System.ComponentModel.Category("Misc"), System.ComponentModel.Description("La categoría de la información que se muestra en el Combo")> _
    Public Property CategoriaDatos() As CategoriaDatos
        Get
            Return Me.mCategoriaDatos
        End Get
        Set(ByVal Value As CategoriaDatos)
            mCategoriaDatos = Value
            Select Case Value
                Case 0
                    mDescripcion = "DIAGNOSTICOS"
                    'mArchivoLoad = "mDatDiag.xml"
                Case 1
                    mDescripcion = "PROCEDIMIENTOS"
                    'mArchivoLoad = "mDatProc.xml"
                Case 2
                    mDescripcion = "PRODUCTOS"
                    'mArchivoLoad = "mDatProd.xml"
                Case 3
                    mDescripcion = "ORDENMEDICAMENTOSDESCRIPCION"
                Case 4
                    mDescripcion = "ORDENMEDICAMENTOSCODIGO"
                Case 5
                    mDescripcion = "ENTIDADES"
                Case 6
                    mDescripcion = "ENTIDADESNOIPS"
                Case 7
                    mDescripcion = "PRODUCTOSCONVENIO"
                'mArchivoLoad = "mDatProd.xml"
                Case 15
                    mDescripcion = "INDICACIONES"
                Case 16
                    mDescripcion = "PROCEDIMIENTOSQX"
            End Select

        End Set
    End Property

    <System.ComponentModel.Category("Misc"), System.ComponentModel.Description("Descripción de la Categoría de Datos del Combo")> _
    Public ReadOnly Property Descripcion() As String
        Get
            Return Me.mDescripcion
        End Get
    End Property

    <System.ComponentModel.Category("Misc"), System.ComponentModel.Description("Descripción de la Categoría de Datos del Combo")> _
    Public Property Login() As String
        Get
            Return Me.mLogin
        End Get
        Set(ByVal value As String)
            mLogin = value
        End Set

    End Property

    <System.ComponentModel.Category("Misc"), System.ComponentModel.Description("Define si el campo es obligatorio")> _
      Public Property Obligatorio() As String
        Get
            Return Me.mObligatorio
        End Get
        Set(ByVal Value As String)
            Me.mObligatorio = Value
        End Set
    End Property

    Public Property FechaInicialMedicamento() As String
        Get
            Return Me.mFechaInicialMedicamento
        End Get
        Set(ByVal Value As String)
            Me.mFechaInicialMedicamento = Value
        End Set
    End Property

    Public Property Prestador() As String
        Get
            Return Me.mPrestadorMedicamento
        End Get
        Set(ByVal Value As String)
            Me.mPrestadorMedicamento = Value
        End Set
    End Property

    Public Property Sucursal() As String
        Get
            Return Me.mSucursalMedicamento
        End Get
        Set(ByVal Value As String)
            Me.mSucursalMedicamento = Value
        End Set
    End Property

    Public Property ConvenioMedicamento() As Boolean
        Get
            Return Me.mblnManejaConvenioMedicamento
        End Get
        Set(ByVal Value As Boolean)
            Me.mblnManejaConvenioMedicamento = Value
        End Set
    End Property


    Public Property Medicamento() As String
        Get
            Return Me.mMedicamento
        End Get
        Set(ByVal Value As String)
            Me.mMedicamento = Value
        End Set
    End Property
    Public Property CodigoTipoProcedimiento() As String
        Get
            Return Me.mCodprocedimiento
        End Get
        Set(ByVal value As String)
            Me.mCodprocedimiento = value
        End Set
    End Property

    Public Property EstadoMedicamento() As Boolean
        Get
            Return Me.mblnConSinEstadoMedicamento
        End Get
        Set(ByVal Value As Boolean)
            Me.mblnConSinEstadoMedicamento = Value
        End Set
    End Property

    Public Property Entidad() As String
        Get
            Return Me.mEntidad
        End Get
        Set(ByVal Value As String)
            Me.mEntidad = Value
        End Set
    End Property

    Public Property EdadPaciente() As Integer
        Get
            Return Me.mEdadPaciente
        End Get
        Set(ByVal Value As Integer)
            Me.mEdadPaciente = Value
        End Set
    End Property

    Public Property SexoPaciente() As String
        Get
            Return Me.mSexoPaciente
        End Get
        Set(ByVal Value As String)
            Me.mSexoPaciente = Value
        End Set
    End Property

    Public Property DatoRelacionado() As String
        Get
            Return Me.mDatoRelacionado
        End Get
        Set(ByVal Value As String)
            Me.mDatoRelacionado = Value
        End Set
    End Property

    Public ReadOnly Property BotonBusqueda() As Button
        Get
            Return _botonBusqueda
        End Get
    End Property

    Private _blnSeleccionadoConEnter As Boolean = False
    Public Property SeleccionadoConEnter() As Boolean
        Get
            Return _blnSeleccionadoConEnter
        End Get
        Set(ByVal Value As Boolean)
            _blnSeleccionadoConEnter = Value
        End Set
    End Property

    Private _strUltimaDescripcionBuscador As String
    Public Property UltimaDescripcionDeBusqueda() As String
        Get
            Return _strUltimaDescripcionBuscador
        End Get
        Set(ByVal value As String)
            _strUltimaDescripcionBuscador = value
        End Set
    End Property

#End Region

    Private Sub ComboBusqueda_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SelectionChangeCommitted

        Dim recRowView As DataRowView
        Dim recName As DataRow

        'If sender.Text = "" Then
        '    Exit SubBuscarCodigo
        'End If

        'Consigue el Registro Seleccionado desde el Combo Enlazado a Datos (Retorna DataRowView)
        recRowView = sender.SelectedItem
        If recRowView Is Nothing Then
            mValorCampoEnlazado = ""
            cmdButton.Focus()
            Me.mctlTextoEnlace.Text = mValorCampoEnlazado
            Me.lanzaEventoActualizarDatosElegidos(Nothing)
            RaiseEvent ItemCambio(Me)
            Exit Sub
        End If

        'Muestra el Información del nombre(La fila viene desde el dataset enlazado)
        recName = recRowView.Row
        If Not recName("cons") Is DBNull.Value Then
            recName("cons") = recName("cons") + 1
        End If

        Me.UltimaDescripcionDeBusqueda = Nothing
        mValorCampoEnlazado = recName(Me.mCampoEnlazado)
        SiguienteControl(Me).Focus()
        Me.mctlTextoEnlace.Text = mValorCampoEnlazado
        'Me.mctlTextoEnlace.Refresh()
        'My.Computer.Keyboard.SendKeys("{TAB}")
        'My.Computer.Keyboard.SendKeys("{TAB}")
        'Me.Parent.GetNextControl(Me, True).Focus()
        Me.lanzaEventoActualizarDatosElegidos(recName)
        RaiseEvent ItemCambio(Me)
    End Sub

    Private Function SiguienteControl(ByVal ctlControl As Control) As Control
        Dim blnRespuesta As Boolean
        Dim ctlControlFocus As Control
        Dim ctlControlActual As Control

        ctlControlActual = ctlControl
        Do
            ctlControlFocus = Me.Parent.GetNextControl(ctlControlActual, True)
            If ctlControlFocus.CanFocus = True Then
                blnRespuesta = True
            Else
                ctlControlActual = ctlControlFocus
            End If

        Loop While blnRespuesta = False

        Return ctlControlFocus

    End Function

End Class
