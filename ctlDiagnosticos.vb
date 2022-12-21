Imports System.Linq
Imports System.Reflection
Imports System.Collections.Generic
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports HistoriaClinica.Sophia.HistoriaClinica.BL

Public Class ctlDiagnosticos

    Private oConexion As Conexion
    Private oGeneral As Generales
    Private oPaciente As Paciente
    Private sCadenaLocal As String

#Region "Properties"

    Private _plstDiagnostico As New List(Of Diagnostico)
    Public Property plstDiagnostico As List(Of Diagnostico)
        Get
            Return _plstDiagnostico
        End Get
        Set(ByVal Value As List(Of Diagnostico))
            _plstDiagnostico = Value
        End Set
    End Property

    Private _plstDiagNuevos As New List(Of Diagnostico)
    Public Property plstDiagNuevos As List(Of Diagnostico)
        Get
            Return _plstDiagNuevos
        End Get
        Set(ByVal Value As List(Of Diagnostico))
            _plstDiagNuevos = Value
        End Set
    End Property

    Private _pDiagnostico As New Diagnostico
    Public Property pDiagnostico As Diagnostico
        Get
            Return _pDiagnostico
        End Get
        Set(ByVal Value As Diagnostico)
            _pDiagnostico = Value
        End Set
    End Property

    Private _pclase_diag As String
    Public Property pClase_Diag() As String
        Get
            Return _pclase_diag
        End Get
        Set(ByVal Value As String)
            _pclase_diag = Value
        End Set
    End Property

    Private Shared _Instancia As ctlDiagnosticos

    Public Shared ReadOnly Property Instancia() As ctlDiagnosticos
        Get
            If _Instancia Is Nothing Then
                _Instancia = New ctlDiagnosticos
            End If
            Return _Instancia
        End Get
    End Property
#End Region
#Region "Events"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub ctlDiagnosticos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        oConexion = Conexion.Instancia
        oGeneral = Generales.Instancia
        oPaciente = Paciente.Instancia
        sCadenaLocal = oGeneral.CadenaLocal
        Me.pDiagnostico = New Diagnostico
        pDiagnostico.ORIGEN = 1
        Me.plstDiagnostico = New List(Of Diagnostico)
        Me.plstDiagNuevos = New List(Of Diagnostico)

        If pClase_Diag = FuncionesGenerales.EnumDescription(Diagnostico.ClaseDiagnostico.Evolucion) Then
            lblObservaciones.Visible = False
            tbObservaciones.Visible = False
        Else
            lblObservaciones.Visible = True
            tbObservaciones.Visible = True
        End If

        loadCombos()
        LoadControl()

    End Sub

    Private Sub btnAgregarDiag_Click(sender As Object, e As EventArgs) Handles btnAgregarDiag.Click
        If ValidarCamposObligatorios(gbDiagnostico) = False Then
            MessageBox.Show("Falta Información en Campo Obligatorio")
            Exit Sub
        End If
        'pDiagnostico = New Diagnostico
        If pDiagnostico.ORIGEN = 1 Then
            addDiagnostico()
        Else
            updDiagnostico(dtgDiagnosticos.CurrentRow)
        End If
    End Sub


    'Private Sub dtgDiagnosticos_UserDeletingRow(sender As Object, e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dtgDiagnosticos.UserDeletingRow

    '    If e.Row.Cells("ORIGEN").Value.ToString() = "0" Then
    '        MessageBox.Show("No es posible eliminar este Diagnóstico.")
    '        e.Cancel = True
    '        Exit Sub
    '    End If

    '    'If NVL(e.Row.Cells("Nuevo").Value) = "N" Then
    '    If MessageBox.Show("Esta Seguro de Borrar este Registro?", "Evolución", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
    '        Dim lstdiag As New List(Of Diagnostico)

    '        lstdiag = (From DIAG As Diagnostico In plstDiagnostico.ToList()
    '                   Where DIAG.DIAGNOST = e.Row.Cells("DIAGNOST").Value.ToString()
    '                   Select DIAG).ToList()

    '        If lstdiag.Count = 1 Then
    '            pDiagnostico = lstdiag(0)
    '        End If

    '        EliminarDiagnostico(pDiagnostico)

    '    Else
    '        e.Cancel = True
    '    End If

    '    tbCodDiag.Focus()
    'End Sub


    Private Sub dtgDiagnosticos_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles dtgDiagnosticos.UserDeletedRow

    End Sub
#End Region

#Region "Functions"

    Public Sub LoadControl()
        oConexion = Conexion.Instancia
        oGeneral = Generales.Instancia
        oPaciente = Paciente.Instancia
        sCadenaLocal = oGeneral.CadenaLocal
        pDiagnostico = New Diagnostico
        pDiagnostico.ORIGEN = 1
        plstDiagnostico = New List(Of Diagnostico)
        'Me.plstDiagNuevos = New List(Of Diagnostico)
        loadDiagnosticos()
        resetControl()
    End Sub

    Private Sub loadDiagnosticos()
        Dim oDiagnostico As New Diagnostico '= Diagnostico.Instancia
        Dim lError As Long
        Dim i As Integer = 0

        Try
            dtgDiagnosticos.DataSource = New List(Of Diagnostico)
            oDiagnostico.COD_PRE_SGS = oGeneral.Prestador
            oDiagnostico.COD_SUCUR = oGeneral.Sucursal
            oDiagnostico.TIP_ADMISION = oPaciente.TipoAdmision
            oDiagnostico.ANO_ADM = oPaciente.AnoAdmision
            oDiagnostico.NUM_ADM = oPaciente.NumeroAdmision
            oDiagnostico.CLASE_DIAG = Nothing
            plstDiagnostico = oDiagnostico.getDiagnostico(oConexion, lError, oDiagnostico)
        Catch ex As Exception
            MsgBox("Error al consultar los Diagnósticos", MsgBoxStyle.Exclamation)
            Exit Sub
        End Try

        Dim lstdiag As New List(Of Diagnostico)

        lstdiag = (From DIAG As Diagnostico In plstDiagNuevos.ToList()
                   Where DIAG.COD_PRE_SGS = oGeneral.Prestador And
                           DIAG.COD_SUCUR = oGeneral.Sucursal And
                           DIAG.TIP_ADMISION = oPaciente.TipoAdmision And
                           DIAG.ANO_ADM = oPaciente.AnoAdmision And
                           DIAG.ANO_ADM = oPaciente.AnoAdmision And
                           DIAG.NUM_ADM = oPaciente.NumeroAdmision Select DIAG).ToList()

        If lstdiag.Count = 0 Then
            Me.plstDiagNuevos = New List(Of Diagnostico)
        End If

        'If Me.plstDiagNuevos.Count > 0 And Me.Parent.Name = "ctlEvolucion" Then
        If Me.plstDiagNuevos.Count > 0 Then
            For Each oDiagNuevo As Diagnostico In plstDiagNuevos
                If oDiagNuevo.ORIGEN = 2 Then

                    For i = 0 To Me.plstDiagnostico.Count - 1
                        If oDiagNuevo.DIAGNOST = Me.plstDiagnostico(i).DIAGNOST Then
                            Me.plstDiagnostico(i) = oDiagNuevo
                            Exit For
                        End If
                        ' Me.plstDiagnostico.Remove(oDiagNuevo)
                    Next
                Else
                    Me.plstDiagnostico.Add(oDiagNuevo)
                End If
            Next
        End If

        If plstDiagnostico.Count > 0 Then

            'If Me.plstDiagNuevos.Count > 0 Then
            '    For Each oDiagNuevo As Diagnostico In plstDiagNuevos
            '        For Each oDiag As Diagnostico In plstDiagnostico
            '            If oDiagNuevo.COD_PRE_SGS = oDiag.COD_PRE_SGS And
            '                oDiagNuevo.COD_SUCUR = oDiag.COD_SUCUR And
            '                oDiagNuevo.TIP_ADMISION = oDiag.TIP_ADMISION And
            '                oDiagNuevo.NUM_ADM = oDiag.NUM_ADM And
            '                oDiagNuevo.ANO_ADM = oDiag.ANO_ADM And
            '                oDiagNuevo.DIAGNOST = oDiag.DIAGNOST Then

            '                oDiag.ORIGEN = 1
            '            End If
            '        Next
            '    Next
            'End If
            dtgDiagnosticos.DataSource = plstDiagnostico

            dtgDiagnosticos.Columns("DIAGNOSTICO_DESC").DisplayIndex = 1
            dtgDiagnosticos.Columns("TIPO_DIAGNOSTICO").DisplayIndex = 2
            dtgDiagnosticos.Columns("CATEGORIA").DisplayIndex = 3
            dtgDiagnosticos.Columns("ESTADO").DisplayIndex = 4
            i = 0
            For Each row As DataGridViewRow In dtgDiagnosticos.Rows
                If row.Cells("IDESTADODIAGNOSTICO").Value <> 1 Then
                    'row.DataGridView.RowsDefaultCellStyle.BackColor = Color.Blue
                    dtgDiagnosticos.Rows(i).DefaultCellStyle.ForeColor = Color.Gray
                End If
                row.Cells("SECUENCIA").Value = i
                i += 1
            Next
        End If
    End Sub
    Private Sub loadDiagnostico(ByVal oDiagnostico As Diagnostico)
        tbCodTipoDiag.Text = oDiagnostico.TIP_DIAG

        tbDesTipoDiag.Text = oDiagnostico.TIPO_DIAGNOSTICO
        tbCodCategoria.Text = oDiagnostico.CATEGORIA_DIAG
        tbDesCategoria.Text = oDiagnostico.CATEGORIA
        txtCodEstadoDiag.Text = oDiagnostico.IDESTADODIAGNOSTICO
        txtEstadoDiag.Text = oDiagnostico.ESTADO
        tbCodDiag.Text = oDiagnostico.DIAGNOST
        cbDiagnostico.Text = oDiagnostico.DIAGNOSTICO.Replace(oDiagnostico.DIAGNOST + " ", "") 'oDiagnostico.DIAGNOSTICO
        tbObservaciones.Text = oDiagnostico.OBS

        If oDiagnostico.ANTECEDENTE = "S" Then
            cbAgregarEvo.Checked = True
        Else
            cbAgregarEvo.Checked = False
        End If

        If oDiagnostico.CONFIDENCIAL = "S" Then
            ckConfidencialEvo.Checked = True
        Else
            ckConfidencialEvo.Checked = False
        End If

        tbCodTipoDiag.Enabled = True
        tbDesTipoDiag.Enabled = True
        tbCodCategoria.Enabled = True
        tbDesCategoria.Enabled = True
        If oDiagnostico.ORIGEN = 1 Then
            txtCodEstadoDiag.Enabled = False
            txtEstadoDiag.Enabled = False
            txtCodEstadoDiag.Text = Diagnostico.EstadoDiagnostico.Activo
            txtEstadoDiag.Text = "ACTIVO"
        Else
            txtCodEstadoDiag.Enabled = True
            txtEstadoDiag.Enabled = True
        End If
        If Trim(oDiagnostico.DIAGNOST).Length > 0 Then

            tbCodDiag.Enabled = False
            cbDiagnostico.Enabled = False
        Else
            tbCodDiag.Enabled = True
            cbDiagnostico.Enabled = True
        End If

    End Sub
    Private Sub loadCombos()
        Dim obj As New Sophia.HistoriaClinica.BL.BLEgresos
        Dim objLocal As New Sophia.HistoriaClinica.BL.BLBasicasLocales
        '/// Llenamos los controles para las listas Inciales \\\
        '/ para los diagnósticos \
        tbDesTipoDiag.NombreCampoDatos = "descripcion"
        tbCodTipoDiag.NombreCampoBusqueda = "tip_diag"
        tbCodTipoDiag.NombreCampoBuscado = "descripcion"
        tbCodTipoDiag.ControlTextoEnlace = tbDesTipoDiag
        tbDesTipoDiag.ControlTextoEnlace = tbCodTipoDiag
        'tbDesTipoDiag.OrigenDeDatos = obj.ConsultarTiposDiagnostico
        tbDesTipoDiag.OrigenDeDatos = objLocal.TraerDatosTablasBasicasLocales(sCadenaLocal, "hctipdiag", "tip_diag,descripcion", "descripcion <> 'MIGRACION'", "descripcion")
        tbDesTipoDiag.CargarDatosDescripcion()

        '/ para los Estados \
        txtEstadoDiag.NombreCampoDatos = "DscEstadoDiagnostico"
        txtCodEstadoDiag.NombreCampoBusqueda = "IdEstadoDiagnostico"
        txtCodEstadoDiag.NombreCampoBuscado = "DscEstadoDiagnostico"
        txtCodEstadoDiag.ControlTextoEnlace = txtEstadoDiag
        txtEstadoDiag.ControlTextoEnlace = txtCodEstadoDiag
        txtEstadoDiag.OrigenDeDatos = objLocal.TraerDatosTablasBasicasLocales(sCadenaLocal, "HcEstadoDiagnostico", "IdEstadoDiagnostico,DscEstadoDiagnostico", "")
        txtEstadoDiag.CargarDatosDescripcion()

        '/ para las categorías \
        tbDesCategoria.NombreCampoDatos = "Descripcion"
        tbCodCategoria.NombreCampoBusqueda = "Categoria_diag"
        tbCodCategoria.NombreCampoBuscado = "Descripcion"
        tbCodCategoria.ControlTextoEnlace = tbDesCategoria
        tbDesCategoria.ControlTextoEnlace = tbCodCategoria
        tbDesCategoria.OrigenDeDatos = obj.ConsultarCategorias
        tbDesCategoria.CargarDatosDescripcion()

        '/ para los diagnósticos \
        tbCodDiag.ControlComboEnlace = cbDiagnostico
        cbDiagnostico.CampoMostrar = "descripcion"
        cbDiagnostico.ControlTextoEnlace = tbCodDiag
        cbDiagnostico.CampoEnlazado = "codigo"
        cbDiagnostico.CategoriaDatos = CategoriaDatos.Diagnosticos
        cbDiagnostico.Login = oGeneral.Login
        cbDiagnostico.SexoPaciente = oPaciente.Genero
        cbDiagnostico.EdadPaciente = oPaciente.Edad
        cbDiagnostico.CargarDatos()
        cbDiagnostico.CargarButton()

        obj = Nothing
        objLocal = Nothing

    End Sub


    Private Function ValidarCamposObligatorios(ByVal ctlContenedor As GroupBox) As Boolean
        Dim ctlControlTexto As TextBoxConFormato
        Dim ctlControlCombo As ComboBusqueda
        Dim intControl As Integer
        Dim blnRespuesta As Boolean

        blnRespuesta = True
        For intControl = 0 To ctlContenedor.Controls.Count - 1
            If TypeOf (ctlContenedor.Controls(intControl)) Is TextBoxConFormato Then
                ctlControlTexto = ctlContenedor.Controls(intControl)
                If ctlControlTexto.Obligatorio = True Then
                    If ctlControlTexto.Text.Trim.Length = 0 Then
                        ctlControlTexto.Focus()
                        blnRespuesta = False
                        Exit For
                    End If
                End If
            Else
                If TypeOf (ctlContenedor.Controls(intControl)) Is ComboBusqueda Then
                    ctlControlCombo = ctlContenedor.Controls(intControl)
                    If ctlControlCombo.Obligatorio = True Then
                        If ctlControlCombo.Text.Trim.Length = 0 Then
                            ctlControlCombo.Focus()
                            blnRespuesta = False
                            Exit For
                        End If
                    End If
                End If
            End If
        Next

        Return blnRespuesta
    End Function

    Private Sub resetControl()
        pDiagnostico = New Diagnostico
        pDiagnostico.ORIGEN = 1
        tbCodDiag.ResetText()
        cbDiagnostico.ResetText()
        tbCodTipoDiag.ResetText()
        tbDesTipoDiag.ResetText()
        tbCodCategoria.ResetText()
        tbDesCategoria.ResetText()
        txtCodEstadoDiag.ResetText()
        txtEstadoDiag.ResetText()
        tbObservaciones.ResetText()

        tbCodTipoDiag.Enabled = True
        tbDesTipoDiag.Enabled = True
        tbCodCategoria.Enabled = True
        tbDesCategoria.Enabled = True
        txtCodEstadoDiag.Enabled = True
        txtEstadoDiag.Enabled = False
        tbCodDiag.Enabled = True
        cbDiagnostico.Enabled = True
        tbObservaciones.Enabled = True


        txtCodEstadoDiag.Text = Diagnostico.EstadoDiagnostico.Activo
        txtEstadoDiag.Text = "ACTIVO"

        tbCodTipoDiag.BackColor = SystemColors.Window
        tbDesTipoDiag.BackColor = SystemColors.Window
        tbCodCategoria.BackColor = SystemColors.Window
        tbDesCategoria.BackColor = SystemColors.Window
        txtCodEstadoDiag.BackColor = SystemColors.Window
        txtEstadoDiag.BackColor = SystemColors.Window
        tbCodDiag.BackColor = SystemColors.Window
        cbDiagnostico.BackColor = SystemColors.Window
        tbObservaciones.BackColor = SystemColors.Window

    End Sub

    Private Sub addDiagnostico()

        'Dim dtTable As New DataTable
        'dtTable = dtgDiagnosticos.DataSource

        Dim strError As String = ""
        Dim bExiste As Boolean = True

        'Verificar datos 
        If tbDesTipoDiag.Text = "" Then
            strError = strError & "- Tipo de Diagnóstico" & Chr(13)
        End If
        If tbDesCategoria.Text = "" Then
            strError = strError & "- Categoría" & Chr(13)
        End If
        If txtEstadoDiag.Text = "" Then
            strError = strError & "- Estado" & Chr(13)
        End If

        'Adicionar Nuevo Registro a la Grilla 
        If strError.Trim.Length = 0 Then
            If validateDiagnostico() Then
                'Dim dtRow As DataRow = dtTable.NewRow()
                Dim intorigen As Integer
                Dim strAntecedente As String
                Dim strConfidencial As String
                Dim intSecuencia As Integer
                Dim strClasi As String = ""
                'Dim dtRows As DataRow()



                intSecuencia = plstDiagnostico.Count + 1
                intorigen = cbDiagnostico.OrigenDeDatos.Rows.Count - 1

                If cbDiagnostico.Items.Count() > 0 Then
                    strClasi = cbDiagnostico.OrigenDeDatos.Rows(intorigen).Item("Clasificacion").ToString()
                End If

                If strClasi = "" Then
                    If Me.tbCodDiag.Text <> "" Then
                        strClasi = cbDiagnostico.OrigenDeDatos.Rows(intorigen).Item("Clasificacion").ToString()
                    End If
                End If

                If cbAgregarEvo.Checked = True Then
                    strAntecedente = "S"
                Else
                    strAntecedente = "N"
                End If
                If ckConfidencialEvo.Checked = True Then
                    strConfidencial = "S"
                Else
                    strConfidencial = "N"
                End If

                'Grabar registro en la BD
                Dim objBl As New Sophia.HistoriaClinica.BL.BLDiagnostico
                Dim lError As Long = 0
                Try


                    Dim lstdiag As New List(Of Diagnostico)

                    lstdiag = (From DIAG As Diagnostico In plstDiagnostico.ToList()
                               Where DIAG.DIAGNOST = Trim(tbCodDiag.Text)
                               Select DIAG).ToList()

                    If lstdiag.Count = 1 Then

                        'pDiagnostico = New Diagnostico
                        Me.plstDiagNuevos.Remove(lstdiag(0))
                    End If

                    pDiagnostico.COD_PRE_SGS = oGeneral.Prestador
                    pDiagnostico.COD_SUCUR = oGeneral.Sucursal
                    pDiagnostico.TIP_DOC = oPaciente.TipoDocumento
                    pDiagnostico.NUM_DOC = oPaciente.NumeroDocumento
                    pDiagnostico.TIP_ADMISION = oPaciente.TipoAdmision
                    pDiagnostico.NUM_ADM = oPaciente.NumeroAdmision
                    pDiagnostico.ANO_ADM = oPaciente.AnoAdmision
                    pDiagnostico.CLASE_DIAG = pClase_Diag
                    pDiagnostico.TIPO_DIAGNOSTICO = Trim(tbDesTipoDiag.Text)
                    pDiagnostico.TIP_DIAG = Trim(tbCodTipoDiag.Text)
                    pDiagnostico.DIAGNOSTICO = Trim(tbCodDiag.Text) + " " + Trim(cbDiagnostico.Text)
                    pDiagnostico.DIAGNOST = Trim(tbCodDiag.Text)
                    pDiagnostico.ANTECEDENTE = strAntecedente
                    pDiagnostico.OBS = Trim(tbObservaciones.Text)
                    pDiagnostico.CONFIDENCIAL = strConfidencial
                    pDiagnostico.CLASIFICACION = strClasi
                    pDiagnostico.CATEGORIA = Trim(tbDesCategoria.Text)
                    pDiagnostico.CATEGORIA_DIAG = Trim(tbCodCategoria.Text)
                    pDiagnostico.LOGIN = oGeneral.Login
                    pDiagnostico.ESTADO = Trim(txtEstadoDiag.Text)
                    pDiagnostico.IDESTADODIAGNOSTICO = Trim(txtCodEstadoDiag.Text)
                    pDiagnostico.ORIGEN = 1

                    'lError = pDiagnostico.addDiagnostico(oConexion, lError, pDiagnostico)
                    Me.plstDiagNuevos.Add(Me.pDiagnostico)
                    'Me.plstDiagNuevos.Add(Me.pDiagnostico)

                Catch ex As Exception
                    MsgBox("El diagnostico no se grabó. " & ex.Message, MsgBoxStyle.Exclamation)
                    Exit Sub
                End Try

                loadDiagnosticos()

                resetControl()
                oGeneral.HistoriaClinicaTieneModificaciones = True

            End If


        Else
            MsgBox("Por favor ingrese los siguientes datos :" & Chr(13) & strError, MsgBoxStyle.Information)
            Exit Sub
        End If

    End Sub

    Private Sub updDiagnostico(ByVal drFila As DataGridViewRow)

        Dim intFila As Integer = dtgDiagnosticos.CurrentRow.Index
        Dim dgR As DataGridViewRow = dtgDiagnosticos.Rows(intFila)
        Dim strAntecedente As String
        Dim strConfidencial As String
        Dim intSecuencia As Integer
        Dim i As Integer
        Dim objBl As New Sophia.HistoriaClinica.BL.BLDiagnostico
        Dim lError As Long

        intSecuencia = CInt(drFila.Cells("SECUENCIA").Value)
        Dim strClasi As String = drFila.Cells("CLASIFICACION").Value

        '/- Actualizar Registro --
        If cbAgregarEvo.Checked = True Then
            strAntecedente = "S"
        Else
            strAntecedente = "N"
        End If
        If Me.ckConfidencialEvo.Checked = True Then
            strConfidencial = "S"
        Else
            strConfidencial = "N"
        End If
        If ((drFila.Cells("TIP_DIAG").Value.ToString() = "2" And Trim(tbCodTipoDiag.Text) = "1") Or
            (drFila.Cells("TIP_DIAG").Value.ToString() = "3" And Trim(tbCodTipoDiag.Text) = "1") Or
            (drFila.Cells("TIP_DIAG").Value.ToString() = "3" And Trim(tbCodTipoDiag.Text) = "2")) And
            (Me.pDiagnostico.ORIGEN <> 1) Then

            'MessageBox.Show("NO es posible cambiar el tipo de diagnóstico de " + drFila.Cells("TIPO_DIAGNOSTICO").Value + " a " + tbDesTipoDiag.Text.ToString())
            MessageBox.Show("No es posible realizar esta modificación, valide por favor las opciones")
            Exit Sub
        End If

        If (drFila.Cells("IDESTADODIAGNOSTICO").Value.ToString() = "2" And Trim(txtCodEstadoDiag.Text) = "3") Or
            (drFila.Cells("IDESTADODIAGNOSTICO").Value.ToString() = "3" And Trim(txtCodEstadoDiag.Text) = "2") Then

            'MessageBox.Show("NO es posible cambiar el estado del diagnóstico de " + drFila.Cells("ESTADO").Value + " a " + txtEstadoDiag.Text.ToString())
            MessageBox.Show("No es posible realizar esta modificación, valide por favor las opciones")
            Exit Sub
        End If

        If Not validateDiagnostico() Then
            Exit Sub
        End If

        Try
            Dim lstdiag As New List(Of Diagnostico)

            lstdiag = (From DIAG As Diagnostico In plstDiagnostico.ToList()
                       Where DIAG.DIAGNOST = drFila.Cells("DIAGNOST").Value.ToString()
                       Select DIAG).ToList()

            If lstdiag.Count = 1 Then
                'pDiagnostico = New Diagnostico
                Me.plstDiagNuevos.Remove(lstdiag(0))

                pDiagnostico.COD_PRE_SGS = oGeneral.Prestador
                pDiagnostico.COD_SUCUR = oGeneral.Sucursal
                pDiagnostico.TIP_DOC = oPaciente.TipoDocumento
                pDiagnostico.NUM_DOC = oPaciente.NumeroDocumento
                pDiagnostico.TIP_ADMISION = oPaciente.TipoAdmision
                pDiagnostico.NUM_ADM = oPaciente.NumeroAdmision
                pDiagnostico.ANO_ADM = oPaciente.AnoAdmision
                pDiagnostico.CLASE_DIAG = pClase_Diag
                pDiagnostico.TIPO_DIAGNOSTICO = Trim(tbDesTipoDiag.Text)
                pDiagnostico.TIP_DIAG = Trim(tbCodTipoDiag.Text)
                pDiagnostico.DIAGNOSTICO = Trim(tbCodDiag.Text) + " " + Trim(cbDiagnostico.Text)
                pDiagnostico.DIAGNOST = Trim(tbCodDiag.Text)
                pDiagnostico.ANTECEDENTE = strAntecedente
                pDiagnostico.OBS = Trim(tbObservaciones.Text)
                pDiagnostico.CONFIDENCIAL = strConfidencial
                pDiagnostico.CLASIFICACION = strClasi
                pDiagnostico.CATEGORIA = Trim(tbDesCategoria.Text)
                pDiagnostico.CATEGORIA_DIAG = Trim(tbCodCategoria.Text)
                pDiagnostico.LOGIN = oGeneral.Login
                pDiagnostico.ESTADO = Trim(txtEstadoDiag.Text)
                pDiagnostico.IDESTADODIAGNOSTICO = Trim(txtCodEstadoDiag.Text)
                pDiagnostico.ORIGEN = 2 'IIf(pDiagnostico.ORIGEN = 0, 2, 1)
                'lError = pDiagnostico.addDiagnostico(oConexion, lError, pDiagnostico)
                'Me.plstDiagnostico.Add(pDiagnostico)
                Me.plstDiagNuevos.Add(pDiagnostico)
            End If

        Catch ex As Exception
            MsgBox("El diagnóstico no se actualizó", MsgBoxStyle.Information)
            Exit Sub
        End Try

        '   
        loadDiagnosticos()
        resetControl()
        'dtgDiagnosticos.DataSource = plstDiagnostico

        'dtgDiagnosticos.Columns("DIAGNOSTICO_DESC").DisplayIndex = 1
        'dtgDiagnosticos.Columns("TIPO_DIAGNOSTICO").DisplayIndex = 2
        'dtgDiagnosticos.Columns("CATEGORIA").DisplayIndex = 3
        'dtgDiagnosticos.Columns("ESTADO").DisplayIndex = 4

        'For Each row As DataGridViewRow In dtgDiagnosticos.Rows
        '    If row.Cells("IDESTADODIAGNOSTICO").Value <> 1 Then
        '        'row.DataGridView.RowsDefaultCellStyle.BackColor = Color.Blue
        '        dtgDiagnosticos.Rows(i).DefaultCellStyle.ForeColor = Color.Gray
        '    Else
        '        dtgDiagnosticos.Rows(i).DefaultCellStyle.ForeColor = Color.Black
        '    End If
        '    row.Cells("SECUENCIA").Value = i
        '    i += 1
        'Next
        'resetControl()
        'oGeneral.HistoriaClinicaTieneModificaciones = True
        'pDiagnostico.ORIGEN = 1
    End Sub
    Public Function validateUxPrincipalActivo(ByVal DestinoFinal As String) As Boolean

        Dim lstdiag As New List(Of Diagnostico)

        lstdiag = (From DIAG As Diagnostico In Me.plstDiagnostico.ToList()
                   Where DIAG.CATEGORIA_DIAG = FuncionesGenerales.EnumDescription(Diagnostico.CategoriaDiagnostico.Principal) AndAlso
                       DIAG.IDESTADODIAGNOSTICO = Diagnostico.EstadoDiagnostico.Activo
                   Select DIAG).ToList()
        'If Me.plstDiagnostico(0).CLASE_DIAG = "E" Then


        Select Case lstdiag.Count
            Case 0
                If (DestinoFinal = "3") Then
                    MessageBox.Show("Se debe registrar al menos un diagnóstico Principal en estado Activo")
                    Return False
                    Exit Function
                End If

            Case > 1
                MessageBox.Show("Solo es posible tener un (1) diagnóstico Principal en estado Activo")
                Return False
                Exit Function

        End Select
        Return True
    End Function

    Public Function validateUxPrincipal() As Boolean

        Dim lstdiag As New List(Of Diagnostico)

        lstdiag = (From DIAG As Diagnostico In Me.plstDiagnostico.ToList()
                   Where DIAG.CATEGORIA_DIAG = FuncionesGenerales.EnumDescription(Diagnostico.CategoriaDiagnostico.Principal)
                   Select DIAG).ToList()

        If lstdiag.Count = 0 Then

            MessageBox.Show("Se debe registrar al menos un diagnóstico Principal.")

            Return False
            Exit Function
        End If

        Return True

    End Function

    Private Function validateDiagnostico() As Boolean

        Dim olstdiag As New List(Of Diagnostico)
        If tbCodCategoria.Text.Trim = "P" And txtCodEstadoDiag.Text.Trim = Diagnostico.EstadoDiagnostico.Activo Then

            olstdiag = (From DIAG As Diagnostico In plstDiagnostico.ToList()
                        Where DIAG.CATEGORIA_DIAG = tbCodCategoria.Text.Trim And
                        DIAG.IDESTADODIAGNOSTICO = Diagnostico.EstadoDiagnostico.Activo And
                            DIAG.DIAGNOST <> tbCodDiag.Text.Trim
                        Select DIAG).ToList()

            If olstdiag.Count > 0 Then

                MessageBox.Show("Sólo es posible tener un (1) diagnóstico Principal en estado Activo")
                Return False
                Exit Function
            End If
        End If

        If pDiagnostico.ORIGEN = 1 Then


            olstdiag = (From DIAG As Diagnostico In plstDiagnostico.ToList()
                        Where DIAG.DIAGNOST = tbCodDiag.Text
                        Select DIAG).ToList()
            If olstdiag.Count > 0 Then
                Dim lstDiagNuevos As New List(Of Diagnostico)

                lstDiagNuevos = (From DIAG As Diagnostico In Me.plstDiagNuevos.ToList()
                                 Where DIAG.DIAGNOST = tbCodDiag.Text
                                 Select DIAG).ToList()
                If lstDiagNuevos.Count > 0 Then
                    Me.plstDiagNuevos.Remove(lstDiagNuevos(0))
                Else
                    MessageBox.Show("El Diagnóstico ingresado ya se encuentra registrado")
                    Return False
                    Exit Function
                End If
            End If
        End If

        Return True

    End Function



    Private Sub EliminarDiagnostico(ByVal oDiagnostico As Diagnostico)



        Dim lError As Long

        Try
            lError = pDiagnostico.delDiagnostico(oConexion, lError, oDiagnostico)

            If lError > 0 Then
                MessageBox.Show("Error al eliminar el diagnóstico evolucion")
            Else
                Me.plstDiagNuevos.Remove(oDiagnostico)
                resetControl()
                loadDiagnosticos()
            End If
        Catch ex As Exception
            MessageBox.Show("Error al eliminar el diagnóstico")
        End Try

    End Sub

    Private Sub dtgDiagnosticos_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dtgDiagnosticos.UserDeletingRow
        If MessageBox.Show("Esta Seguro de Borrar este Registro?", "Evolución", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            MessageBox.Show("Esta Seguro de Borrar este Registro?")
        End If

    End Sub

    Private Sub dtgDiagnosticos_KeyDown(sender As Object, e As KeyEventArgs) Handles dtgDiagnosticos.KeyDown
        Dim lstdiag As New List(Of Diagnostico)
        Dim oDiag As New Diagnostico
        Dim dgvr As New DataGridViewRow
        If ((e.KeyCode = Keys.Delete) AndAlso (Me.dtgDiagnosticos.SelectedRows.Count > 0)) Then
            'Me.dtgDiagnosticos.Rows.Remove(Me.dtgDiagnosticos.SelectedRows.Item(0))
            dgvr = Me.dtgDiagnosticos.SelectedRows.Item(0)
            lstdiag = (From DIAG As Diagnostico In plstDiagnostico.ToList()
                       Where DIAG.DIAGNOST = dgvr.Cells("DIAGNOST").Value.ToString()
                       Select DIAG).ToList()
            If lstdiag.Count = 1 Then
                oDiag = lstdiag(0)
                If oDiag.ORIGEN <> 1 Then
                    MessageBox.Show("No es posible eliminar este Diagnóstico.")
                    e.Handled = True
                    'pDiagnostico = oDiag
                    resetControl()
                    'pDiagnostico.ORIGEN = 0
                    Exit Sub
                End If
                ' pDiagnostico = oDiag
                If MessageBox.Show("Esta Seguro de Borrar este Registro?", "Evolución", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    EliminarDiagnostico(oDiag)
                Else
                    e.Handled = True
                End If
            End If
            'tbCodDiag.Focus()
        End If
    End Sub

    Private Sub dtgDiagnosticos_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dtgDiagnosticos.EditingControlShowing
        AddHandler e.Control.KeyDown, New KeyEventHandler(AddressOf Me.dtgDiagnosticos_KeyDown)
    End Sub

    Private Sub tbCodDiag_Leave(sender As Object, e As EventArgs) Handles tbCodDiag.Leave
        'AddHandler tbCodDiag.LostFocus, New EventHandler(AddressOf Me.tbCodDiag.LostFocus())
        tbCodDiag.PerderFoco()
        Me.tbCodDiag.Text = Me.tbCodDiag.Text.Replace("'", "")
        If cbDiagnostico.Text = "" Then
            Me.tbCodDiag.Text = ""
        End If
        If tbCodDiag.Text.Trim.Length = 0 And cbDiagnostico.Text.Trim.Length = 0 Then
            tbCodDiag.BackColor = Color.LightPink
            tbCodDiag.BackColor = Color.LightPink
        Else
            tbCodDiag.BackColor = SystemColors.Window
            tbCodDiag.BackColor = SystemColors.Window
        End If
    End Sub

    'Private Sub tbCodDiag_TextChanged(sender As Object, e As EventArgs) Handles tbCodDiag.TextChanged
    '    If tbCodDiag.Text.Trim.Length = 0 And cbDiagnostico.Text.Trim.Length = 0 Then
    '        tbCodDiag.BackColor = Color.LightPink
    '        tbCodDiag.BackColor = Color.LightPink
    '    Else
    '        tbCodDiag.BackColor = SystemColors.Window
    '        tbCodDiag.BackColor = SystemColors.Window
    '    End If
    'End Sub

    Private Sub cbDiagnostico_Leave(sender As Object, e As EventArgs) Handles cbDiagnostico.Leave
        If cbDiagnostico.Text.Trim.Length = 0 Then
            cbDiagnostico.BackColor = Color.LightPink
            Exit Sub
        Else
            cbDiagnostico.BackColor = SystemColors.Window
        End If
    End Sub

    Private Sub tbCodTipoDiag_Leave(sender As Object, e As EventArgs) Handles tbCodTipoDiag.Leave
        If tbCodTipoDiag.Text.Trim.Length = 0 And tbDesTipoDiag.Text.Trim.Length = 0 Then
            tbCodTipoDiag.BackColor = Color.LightPink
            tbCodTipoDiag.BackColor = Color.LightPink
        Else
            tbCodTipoDiag.BackColor = SystemColors.Window
            tbCodTipoDiag.BackColor = SystemColors.Window
        End If

        If ((dtgDiagnosticos.CurrentRow.Cells("TIP_DIAG").Value.ToString() = "2" And Trim(tbCodTipoDiag.Text) = "1") Or
            (dtgDiagnosticos.CurrentRow.Cells("TIP_DIAG").Value.ToString() = "3" And Trim(tbCodTipoDiag.Text) = "1") Or
            (dtgDiagnosticos.CurrentRow.Cells("TIP_DIAG").Value.ToString() = "3" And Trim(tbCodTipoDiag.Text) = "2")) And
            (Me.pDiagnostico.ORIGEN <> 1) Then

            'MessageBox.Show("NO es posible cambiar el tipo de diagnóstico de " + drFila.Cells("TIPO_DIAGNOSTICO").Value + " a " + tbDesTipoDiag.Text.ToString())
            MessageBox.Show("No es posible realizar esta modificación, valide por favor las opciones")
            Exit Sub
        End If


    End Sub

    Private Sub tbDesTipoDiag_Leave(sender As Object, e As EventArgs) Handles tbDesTipoDiag.Leave
        If tbDesTipoDiag.Text.Trim.Length = 0 Then
            tbDesTipoDiag.BackColor = Color.LightPink
            Exit Sub
        Else
            tbDesTipoDiag.BackColor = SystemColors.Window
        End If
        If ((dtgDiagnosticos.CurrentRow.Cells("TIP_DIAG").Value.ToString() = "2" And Trim(tbCodTipoDiag.Text) = "1") Or
            (dtgDiagnosticos.CurrentRow.Cells("TIP_DIAG").Value.ToString() = "3" And Trim(tbCodTipoDiag.Text) = "1") Or
            (dtgDiagnosticos.CurrentRow.Cells("TIP_DIAG").Value.ToString() = "3" And Trim(tbCodTipoDiag.Text) = "2")) And
            (Me.pDiagnostico.ORIGEN <> 1) Then
            'MessageBox.Show("NO es posible cambiar el tipo de diagnóstico de " + drFila.Cells("TIPO_DIAGNOSTICO").Value + " a " + tbDesTipoDiag.Text.ToString())
            MessageBox.Show("No es posible realizar esta modificación, valide por favor las opciones")
            Exit Sub
        End If
    End Sub

    Private Sub tbDesCategoria_Leave(sender As Object, e As EventArgs) Handles tbDesCategoria.Leave
        If tbDesCategoria.Text.Trim.Length = 0 Then
            tbDesCategoria.BackColor = Color.LightPink
            Exit Sub
        Else
            tbDesCategoria.BackColor = SystemColors.Window
        End If
    End Sub

    Private Sub tbCodCategoria_Leave(sender As Object, e As EventArgs) Handles tbCodCategoria.Leave
        If tbCodCategoria.Text.Trim.Length = 0 And tbDesCategoria.Text.Trim.Length = 0 Then
            tbCodCategoria.BackColor = Color.LightPink
            tbCodCategoria.BackColor = Color.LightPink
        Else
            tbCodCategoria.BackColor = SystemColors.Window
            tbCodCategoria.BackColor = SystemColors.Window
        End If
    End Sub

    Private Sub txtEstadoDiag_Leave(sender As Object, e As EventArgs) Handles txtEstadoDiag.Leave
        If txtEstadoDiag.Text.Trim.Length = 0 Then
            txtEstadoDiag.BackColor = Color.LightPink
            Exit Sub
        Else
            txtEstadoDiag.BackColor = SystemColors.Window
        End If
        If (dtgDiagnosticos.CurrentRow.Cells("IDESTADODIAGNOSTICO").Value.ToString() = "2" And Trim(txtCodEstadoDiag.Text) = "3") Or
            (dtgDiagnosticos.CurrentRow.Cells("IDESTADODIAGNOSTICO").Value.ToString() = "3" And Trim(txtCodEstadoDiag.Text) = "2") Then
            'MessageBox.Show("NO es posible cambiar el estado del diagnóstico de " + drFila.Cells("ESTADO").Value + " a " + txtEstadoDiag.Text.ToString())
            MessageBox.Show("No es posible realizar esta modificación, valide por favor las opciones")
            Exit Sub
        End If
    End Sub

    Private Sub dtgDiagnosticos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgDiagnosticos.CellClick
        If e.RowIndex >= 0 Then

            Dim lstdiag As New List(Of Diagnostico)
            pDiagnostico = New Diagnostico

            lstdiag = (From DIAG As Diagnostico In plstDiagnostico.ToList()
                       Where DIAG.DIAGNOST = sender.CurrentRow.cells("DIAGNOST").value.ToString()
                       Select DIAG).ToList()
            'AndAlso DIAG.CATEGORIA_DIAG = sender.CurrentRow.cells("CATEGORIA_DIAG").value.ToString()
            'Select Case DIAG).ToList()

            If lstdiag.Count = 1 Then
                pDiagnostico = lstdiag(0)
            End If
            pDiagnostico.ORIGEN = IIf(pDiagnostico.ORIGEN = 1, 1, 2)
            loadDiagnostico(pDiagnostico)
        Else
            pDiagnostico = New Diagnostico
            pDiagnostico.ORIGEN = 1
            loadDiagnostico(pDiagnostico)
        End If
    End Sub








#End Region

End Class
