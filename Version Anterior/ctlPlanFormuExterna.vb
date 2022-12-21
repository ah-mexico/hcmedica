Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.Util
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes.FuncionesGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports objGenerales = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports System.Windows.Forms
Imports System.Drawing
Imports HistoriaClinica.Mail
Imports System.Net.Mail
Imports System.IO
Imports System.Linq
' -----------------------------------------------------------------------------
' Project	 : HistoriaClinica.CtlPlanFormuExterna
' Class	 : Sophia.HistoriaClinica.ctlPlanFormuExterna
' -----------------------------------------------------------------------------
' Clase ctlPlanFormuExterna del namespace Sophia.HistoriaClinica.ctlPlanFormuExterna que es la clase base
' Esta clase tiene la funcionalidad del control de usuario para el plan de manejo en las
' formulaciones externas y será usado en la aplicación cliente en Windows Form 2005
' -----------------------------------------------------------------------------

Public Class CtlPlanFormuExterna
    Private Shared _Instancia As CtlPlanFormuExterna
    Private objGeneral As Generales
    Private daoGeneral As New DAOGeneral
    'hrariza@ CU05
    'Inicio
    Private daoOrdenes As New DAOOrdenes
    'Fin
    Private objPaciente As Paciente
    Private objConexion As Conexion
    Private objFormuExt As PlanFormuExterna
    '@hrariza CU05
    'Inicio
    Private objTblInformativa As PlanFormuExterna
    Private datosLogin As Generales
    'Fin
    Private strModificar As String = ""
    Private dtFormulas As DataTable
    Private blnNuevaFormula As Boolean = False
    Private dtRowViewAntesDeNuevo As DataRowView
    Private intPosAntesDeNuevo As Integer
    Private blnNoNuevo As Boolean
    Private TmpCronicos As Integer
    Private NumeroEntregas As Integer
    Private BoolMedControl As Boolean = False
    Private AltoCosto As Boolean = False
    Private InicioSesion As DateTime


#Region "Instancia de Control"
    Public Shared ReadOnly Property Instancia() As CtlPlanFormuExterna
        Get
            If _Instancia Is Nothing Then
                _Instancia = New CtlPlanFormuExterna
            End If
            Return _Instancia
        End Get
    End Property
#End Region

#Region "Load"

    Private Sub CtlPlanFormuExterna_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Leave
        FinalizarFormulacionExterna()
    End Sub


    Private Sub CtlPlanFormuExterna_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        frmHistoriaPrincipal.blnFirstPlanFormuExterna = False

        objGeneral = Generales.Instancia
        objPaciente = Paciente.Instancia
        objConexion = Conexion.Instancia
        objFormuExt = PlanFormuExterna.Instancia
        InicioSesion = FuncionesGenerales.FechaServidor()
        '@hrariza CU05
        'Inicio
        objTblInformativa = PlanFormuExterna.Instancia
        'Fin
        IniciarFormulacionExterna()
        CargarUnidadMedida()
        CargarFrecuencia()
        CargarViasAdministracion()
    End Sub
    '@hrariza CU05
    'Inicio
    Private Sub IniciarTblInformativa()
        Dim lError As Long
        Dim objBl As New Sophia.HistoriaClinica.BL.BLPlanManejo
        Dim intPosicion As Integer = 0
        Dim blnNuevo As Boolean = False
        Dim dblNroFormula As Double = 0
        Dim objtblInformativa As DataSet
        ' If objTblInformativa.Estado.ToString = "G" Then
        'Try
        lError = objBl.ConsultarTblInformativa(objConexion, objtblInformativa)
        If lError <> 0 Then
            MessageBox.Show("Error al consultar datos", "Historia Clinica", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        '    Catch ex As Exception
        'MessageBox.Show("Error al consultar datos", "Historia Clinica", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Exit Sub
        'End Try
        'Else
        'intPosicion = objTblInformativa.PosicionActualFormula
        'blnNuevo = objTblInformativa.EsNuevaFormula
        'dblNroFormula = objTblInformativa.NumeroFormulaActual
        'End If

        Me.dgTblInformativa.DataSource = objtblInformativa.Tables(0)
        Me.dgTblInformativa.AutoGenerateColumns = False
        CargarGrillaTblinformativa()
    End Sub
    'Fin
    Private Sub IniciarFormulacionExterna()
        Dim lError As Long
        Dim objBl As New Sophia.HistoriaClinica.BL.BLPlanManejo
        Dim intPosicion As Integer = 0
        Dim blnNuevo As Boolean = False
        Dim dblNroFormula As Double = 0

        If ValidarDatosHisBasica() Then
            Exit Sub
        End If

        TmpCronicos = 0
        If objFormuExt.Estado.ToString = "" Then
            Try
                lError = objBl.ConsultarFormulacion(objConexion, objFormuExt)
                If lError <> 0 Then
                    MessageBox.Show("Error al consultar datos", "Historia Clinica", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show("Error al consultar datos", "Historia Clinica", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        Else
            intPosicion = objFormuExt.PosicionActualFormula
            blnNuevo = objFormuExt.EsNuevaFormula
            dblNroFormula = objFormuExt.NumeroFormulaActual
        End If

        blnNoNuevo = True
        Me.bsrMedicamentos.DataSource = objFormuExt.dtNroFormulas
        If objFormuExt.Estado.ToString <> "" Then
            objFormuExt.PosicionActualFormula = intPosicion
        End If
        If objFormuExt.dtNroFormulas.Rows.Count > 0 Then

            If objFormuExt.PosicionActualFormula > 0 And objFormuExt.PosicionActualFormula <= bsrMedicamentos.Count Then
                blnNoNuevo = True
                bsrMedicamentos.Position = objFormuExt.PosicionActualFormula - 1
            ElseIf objFormuExt.PosicionActualFormula > 0 And objFormuExt.PosicionActualFormula > bsrMedicamentos.Count Then
                blnNoNuevo = True
                bsrMedicamentos.MoveLast()
                objFormuExt.PosicionActualFormula = intPosicion
            Else
                bsrMedicamentos.MoveFirst()
            End If
            If objFormuExt.Estado.ToString <> "" Then
                objFormuExt.EsNuevaFormula = blnNuevo
                objFormuExt.NumeroFormulaActual = dblNroFormula
            End If
            If objFormuExt.EsNuevaFormula = True Then
                objFormuExt.dtFormulacion.DefaultView.RowFilter = "nro_formula=0"
                objFormuExt.NumeroFormulaActual = 0
                lblNroFormula.Text = "(Nuevo)"
                LimpiarMedicamentoxraEntidad()
            Else
                ActualizarFormula()
            End If
        Else
            objFormuExt.EsNuevaFormula = True
            NewFormula.Enabled = False
            'Me.btTraerCronicas.Enabled = True
        End If
        If objFormuExt.dtNroFormulas.Rows.Count = 1 And objFormuExt.NuevaFormulaActiva = True Then
            btCancelar.Visible = True
        Else
            btCancelar.Visible = False
        End If
        ActualizarInfoPosicionFormula()
        CargarValoresIniciales()
        ActualizarInformacionControles()
        IniciarTblInformativa()

        If objFormuExt.EsNuevaFormula = True Then
            NewFormula.Enabled = False
        End If
        ''Configuracion inicial de los controles de formulacion cronica
        setConfiguracionInicialCronicos()


        'Cambio realizado por Ing. Ricardo Mauricio Zaldua C. 2009-03-26 solicitado por Mauricio Forero
        'Motivo traer si tiene formulacion cronicos
        dtFormulas = BLPlanManejo.consultarFormulaCronica(objConexion, objPaciente.TipoDocumento, objPaciente.NumeroDocumento)
        If dtFormulas.Rows.Count > 0 Then
            Me.lbFormulaCronica.Text = "Ultima Formula Cronica No. " & dtFormulas.Rows(0).Item("nro_formula").ToString.Trim.ToUpper() & " Vigencia " & Format(CDate(dtFormulas.Rows(0).Item("fecha").ToString.Trim.ToUpper()), "dd/MM/yyyy") & " A " & Format(CDate(dtFormulas.Rows(0).Item("fecha_final").ToString.Trim.ToUpper()), "dd/MM/yyyy")
        Else
            'Me.btTraerCronicas.Enabled = False
            TmpCronicos = 3
            Me.lbFormulaCronica.Text = ""
        End If
    End Sub

    Private Sub FinalizarFormulacionExterna()
        'objFormuExt.ObservacionesFormula = tbObs.Text
        GuardarFormula()
    End Sub
#End Region

#Region "CargarValoresIniciales - Load"
    Private Sub CargarValoresIniciales()
        CargarCombo()

        '// Definir Datos Para la grilla \\


        ''Ctc Noviembre 27 de 2012 se adicionan los campos necesarios para grabar los datos del equivalente
        'With objFormuExt.dtFormulacion
        '    .Columns.Add("cod_corto", System.Type.GetType("System.String"))
        '    .Columns.Add("concentracionEq", System.Type.GetType("System.String"))
        '    .Columns.Add("for_farma", System.Type.GetType("System.String"))
        '    .Columns.Add("diasTratamiento", System.Type.GetType("System.String"))
        '    .Columns.Add("DosisXDia", System.Type.GetType("System.String"))
        '    .Columns.Add("DosisXDiaNoPos", System.Type.GetType("System.String"))
        '    .Columns.Add("fec_desde", System.Type.GetType("System.String"))
        '    .Columns.Add("fec_hasta", System.Type.GetType("System.String"))
        '    .Columns.Add("diagnost", System.Type.GetType("System.String"))
        '    .Columns.Add("Justificacion", System.Type.GetType("System.String"))
        '    .Columns.Add("clasificacion", System.Type.GetType("System.String"))
        '    .Columns.Add("obsDiagn", System.Type.GetType("System.String"))
        '    .Columns.Add("especialidad", System.Type.GetType("System.String"))
        'End With

        dgFormulacion.DataSource = objFormuExt.dtFormulacion

        With dgFormulacion
            .Columns("cod_pre_sgs").Visible = False
            .Columns("cod_sucur").Visible = False
            .Columns("producto").Visible = False
            .Columns("tip_doc").Visible = False
            .Columns("Num_doc").Visible = False
            .Columns("entidad").Visible = False
            .Columns("des_entidad").Visible = False
            .Columns("medico").Visible = False
            .Columns("nroautoriza").Visible = False
            .Columns("dosis").Visible = False
            .Columns("cada").Visible = False
            .Columns("tiempo").Visible = False
            .Columns("estado").Visible = False
            .Columns("pais").Visible = False
            .Columns("departamen").Visible = False
            .Columns("ciudad").Visible = False
            .Columns("login").Visible = False
            .Columns("Descripcion").Visible = True
            .Columns("prescripcion").Visible = True
            .Columns("cantidad").Visible = False
            .Columns("Nuevo").Visible = False
            .Columns("Obs").Visible = False
            .Columns("Cronico").Visible = False
            .Columns("DuracionTrat").Visible = False
            .Columns("Tratamiento").Visible = False
            .Columns("entidad_ant").Visible = False
            .Columns("producto_ant").Visible = False
            .Columns("prescripcion_ant").Visible = False
            .Columns("cantidad_ant").Visible = False
            .Columns("cantidadDispensacion_ant").Visible = False
            .Columns("Cronico_ant").Visible = False
            .Columns("DuracionTrat_ant").Visible = False
            .Columns("Obs_ant").Visible = False
            .Columns("adicionado").Visible = False
            .Columns("uni_med_pedido").Visible = False
            .Columns("UnidadDispensacion").Visible = False
            .Columns("uni_med_dispensacion").Visible = False
            .Columns("cantidadDispensacion").Visible = False
            .Columns("MedControl").Visible = False
            .Columns("cantidadletrascontrol").Visible = False
            .Columns("AltoCosto").Visible = False
            .Columns("tiempomedcontrol").Visible = False
            .Columns("diastrat").Visible = False
            .Columns("UnidadDePrescripcion").Visible = False
            .Columns("CantidadControl").Visible = False
            .Columns("ViaAdministra").Visible = False
            .Columns("UniMedDosis").Visible = False
            .Columns("Frecuencia").Visible = False
            .Columns("UniMedDosisCon").Visible = False
            'llarias se agrega campo especialidad 

            .Columns("especialidad").Visible = False
            '.Columns("diastrat").Visible = False
            '.Columns("autoSISPRO").Visible = False
            '.Columns("MedControl").Visible = False
            ' .Columns("tiempomedcontrol").Visible = False
            ' .Columns("cantidadcontrol").Visible = False
            ' .Columns("cantidadletrascontrol").Visible = False
        End With
        'tbObs.Text = objFormuExt.ObservacionesFormula.ToString




    End Sub
    '
    Private Sub CargarGrillaTblinformativa() 'Hrariza CU05 Ini

        With dgTblInformativa
            .Columns("cod_pre_sgs").Visible = False
            .Columns("cod_sucur").Visible = False
            .Columns("tip_admision").Visible = False
            .Columns("num_adm").Visible = False
            .Columns("ano_adm").Visible = False
            .Columns("origen").Visible = False
            .Columns("fec_con").Visible = False
        End With

    End Sub 'Fin
    Private Sub ActualizarInformacionControles()
        Dim intRow As Integer

        For intRow = 0 To dgFormulacion.Rows.Count - 1
            With dgFormulacion.Rows(intRow)
                .Cells("entidad_ant").Value = .Cells("entidad").Value
                .Cells("producto_ant").Value = .Cells("producto").Value
                .Cells("prescripcion_ant").Value = .Cells("prescripcion").Value
                .Cells("cantidad_ant").Value = .Cells("cantidad").Value.ToString
                .Cells("cantidadDispensacion_ant").Value = .Cells("cantidadDispensacion").Value
                .Cells("cronico_ant").Value = .Cells("cronico").Value
                .Cells("duraciontrat_ant").Value = .Cells("duraciontrat").Value
                .Cells("obs_ant").Value = .Cells("obs").Value

            End With
        Next
        'tbObs.Tag = tbObs.Text

    End Sub

    Private Sub ActualizarFormula(Optional ByVal blnNuevo As Boolean = False, Optional ByRef strManejaConvenio As String = "")
        Dim dataRow As DataRowView

        If ValidarDatosHisBasica() Then
            Exit Sub
        End If

        If blnNuevo = True Then
            objFormuExt.dtFormulacion.DefaultView.RowFilter = "nro_formula=0"
            objFormuExt.NumeroFormulaActual = 0
            objFormuExt.PosicionActualFormula = bsrMedicamentos.Count + 1
            lblNroFormula.Text = "(Nuevo)"
            LimpiarMedicamento()
            tbCodEntidad.Focus()
            strManejaConvenio = objPaciente.ManejaConvenio
            strManejaConvenio = ""
        Else
            If objFormuExt.dtNroFormulas.Rows.Count > 0 Then
                If Not dtRowViewAntesDeNuevo Is Nothing Then
                    dataRow = dtRowViewAntesDeNuevo
                    dtRowViewAntesDeNuevo = Nothing
                    bsrMedicamentos.Position = intPosAntesDeNuevo
                Else
                    dataRow = bsrMedicamentos.Current
                End If
                'dgFormulacion.Sort(dgFormulacion.Columns("nro_formula"), System.ComponentModel.ListSortDirection.Ascending)
                If objFormuExt.dtFormulacion.DefaultView.RowFilter <> "nro_formula=0" And Not IsNothing(dataRow) Then
                    objFormuExt.dtFormulacion.DefaultView.RowFilter = "nro_formula=" & CInt(dataRow.Item("nro_formula")) & " AND entidad='" & dataRow.Item("entidad").ToString & "'"
                    objFormuExt.NumeroFormulaActual = CInt(dataRow.Item("nro_formula"))

                    objFormuExt.PosicionActualFormula = bsrMedicamentos.Position + 1
                    tbCodEntidad.Text = dataRow.Item("entidad").ToString
                    cbEntidad.Text = dataRow.Item("des_entidad").ToString
                    'txtObs.Text = dataRow.Item("obs").ToString
                    strManejaConvenio = dataRow.Item("man_conv_med").ToString
                End If
            End If
        End If
        dgFormulacion.DataSource = objFormuExt.dtFormulacion

        ActualizarInfoPosicionFormula()

    End Sub
#End Region

#Region "CargarCombo"
    Public Sub CargarCombo()
        '/ para los medicamentos \

        Dim dtFecha As Date
        Dim strEntidadManejaConvenio As String
        dtFecha = FuncionesGenerales.FechaServidor()
        tbCodEntidad.ControlComboEnlace = cbEntidad
        With cbEntidad
            .CampoMostrar = "descripcion"
            .ControlTextoEnlace = tbCodEntidad
            .CampoEnlazado = "codigo"
            .CategoriaDatos = CategoriaDatos.EntidadesNIPS
            .CargarDatos()
            .CargarButton()


        End With

        If objPaciente.Entidad.Length > 0 Then
            If objFormuExt.dtNroFormulas.Rows.Count <= 0 Then
                tbCodEntidad.Text = objPaciente.Entidad
                cbEntidad.Text = objPaciente.DescripcionEntidad
                strEntidadManejaConvenio = objPaciente.ManejaConvenio
            Else
                strEntidadManejaConvenio = objFormuExt.dtNroFormulas.Rows(0).Item("man_conv_med").ToString
            End If

            CargarComboMedicamentos(strEntidadManejaConvenio)

            tbCodMedicamento.Focus()
        Else
            tbCodEntidad.Focus()
        End If
    End Sub

    Private Sub tbCodEntidad_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbCodEntidad.Validating

        Dim recRowView As DataRowView
        Dim recName As DataRow
        Dim dtFecha As Date

        If Me.cbEntidad.SelectedItem Is Nothing Then
            Exit Sub
        End If

        dtFecha = FuncionesGenerales.FechaServidor()
        recRowView = Me.cbEntidad.SelectedItem
        recName = recRowView.Row

        CargarComboMedicamentos(recName.Item("man_conv_med").ToString)

    End Sub

    Private Sub CargarComboMedicamentos(Optional ByVal strEntidadManejaConvenio As String = "")
        tbCodMedicamento.ControlComboEnlace = cbMedicamento

        With cbMedicamento
            .CampoMostrar = "descripcion"
            .ControlTextoEnlace = tbCodMedicamento
            .CampoEnlazado = "codigo"
            If objGeneral.Pais = "482" Then
                .CategoriaDatos = CategoriaDatos.ProductosEx
            Else
                .CategoriaDatos = CategoriaDatos.ProductosConvenio
            End If
            .ConvenioMedicamento = IIf(strEntidadManejaConvenio = "S", True, False)
            .ControlTieneCache = Not .ConvenioMedicamento
            .Login = objGeneral.Login
            .Prestador = objGeneral.Prestador
            .Sucursal = objGeneral.Sucursal
            .Entidad = tbCodEntidad.Text
            .CargarDatos()
            If .BotonBusqueda Is Nothing Then
                .CargarButton()
            End If
        End With
    End Sub

#End Region

#Region "AgregarMedicamento"

#End Region

#Region "VerificarMedicamento"
    Private Function VerificarMedicamento(ByVal dblFormula As Double) As Boolean
        '// Verificar que el Procedimiento no se haya adicionado
        Dim dtTable As DataTable = New DataTable
        dtTable = dgFormulacion.DataSource
        Dim FilaBuscada() As DataRow
        If dtTable.Rows.Count > 0 Then
            FilaBuscada = dtTable.Select("Producto='" & tbCodMedicamento.Text & "' AND nro_formula='" & dblFormula & "'")
            If FilaBuscada.Length = 0 Then
                VerificarMedicamento = True
            Else
                VerificarMedicamento = False
            End If
        Else
            VerificarMedicamento = True
        End If
    End Function
#End Region

#Region "ValidarDatos-AdicionarGrilla"
    Private Function ValidarDatos() As Boolean

        'Dim dtMedicamentos As DataTable

        '// Validar los datos antes de adicionar a la Grilla \\
        ValidarDatos = True
        If tbCodEntidad.Text.Trim.Length = 0 Or cbEntidad.Text.Trim.Length = 0 Then
            MsgBox("Existen campos pendientes por diligenciar", MsgBoxStyle.Exclamation)
            tbCodEntidad.Focus()
            ValidarDatos = False
            Exit Function
        End If
        If tbCodMedicamento.Text.Trim.Length = 0 Or cbMedicamento.Text.Trim.Length = 0 Then
            MsgBox("Existen campos pendientes por diligenciar", MsgBoxStyle.Exclamation)
            tbCodMedicamento.Focus()
            ValidarDatos = False
            Exit Function
        End If
        If txtDosis.Text.Trim.Length = 0 Then
            MsgBox("Existen campos pendientes por diligenciar", MsgBoxStyle.Exclamation)
            txtDosis.Focus()
            ValidarDatos = False
            Exit Function
        End If
        If txtDescripcionUM.Text.Trim.Length = 0 Then
            MsgBox("Existen campos pendientes por diligenciar", MsgBoxStyle.Exclamation)
            txtDescripcionUM.Focus()
            ValidarDatos = False
            Exit Function
        End If
        If txtDescripcionVA.Text.Trim.Length = 0 Then
            MsgBox("Existen campos pendientes por diligenciar", MsgBoxStyle.Exclamation)
            txtDescripcionVA.Focus()
            ValidarDatos = False
            Exit Function
        End If
        If txtDescripcionFreq.Text.Trim.Length = 0 Then
            MsgBox("Existen campos pendientes por diligenciar", MsgBoxStyle.Exclamation)
            txtDescripcionFreq.Focus()
            ValidarDatos = False
            Exit Function
        End If
        If txtObs.Text.Trim.Length = 0 Then
            MsgBox("Existen campos pendientes por diligenciar", MsgBoxStyle.Exclamation)
            txtObs.Focus()
            ValidarDatos = False
            Exit Function
        End If
        If txtDiasTrat.Text.Trim.Length = 0 Or txtDiasTrat.Text = "0" Then
            MsgBox("Existen campos pendientes por diligenciar", MsgBoxStyle.Exclamation)
            txtObs.Focus()
            ValidarDatos = False
            Exit Function
        End If
        If tbCantidadPrescripcion.Enabled = True Then
            If tbCantidadPrescripcion.Text.Trim.Length = 0 Or tbCantidadPrescripcion.Text = "0" Then
                MsgBox("Existen campos pendientes por diligenciar", MsgBoxStyle.Exclamation)
                tbCantidadPrescripcion.Focus()
                ValidarDatos = False
                Exit Function
            End If
        End If
        'If tbPrescripcion.Text.Trim.Length = 0 Then
        'MsgBox("Por favor ingrese la prescripción", MsgBoxStyle.Exclamation)
        'tbPrescripcion.Focus()
        'ValidarDatos = False
        'Exit Function
        'End If
        'If tbCantidad.Text.Trim.Length = 0 Then
        'MsgBox("Por favor ingrese la cantidad", MsgBoxStyle.Exclamation)
        'tbCantidadPrescripcion.Focus()
        'ValidarDatos = False
        'Exit Function
        'End If


        ''Validacion de los medicamentos cronicos
        'If chkCronico.Checked = True Then
        ''Si es cronico se debe digitar la duracion del tratamiento
        'If tbDuracion.Text.Trim.Length <= 0 Then
        'MsgBox("Por favor ingrese la duración del tratamiento", MsgBoxStyle.Exclamation)
        'tbDuracion.Focus()
        'ValidarDatos = False
        'Exit Function
        'End If
        'If tbDuracion.Text > NumeroEntregas Then ' ojo cambio
        'MsgBox("El tratamiento no puede ser mayor a " & NumeroEntregas, MsgBoxStyle.Exclamation)
        'tbDuracion.Focus()
        'ValidarDatos = False
        'Exit Function
        'End If

        ''Se valida que todos los medicamentos de la orden sean cronicos
        ''Si hay medicamentos no cronicos en la grilla se marcan como cronicos
        'dtMedicamentos = dgFormulacion.DataSource.copy()
        'If existenMedicamentosEnGrilla(dtMedicamentos, "N") Then
        ' If strModificar <> "" And dtMedicamentos.Rows.Count = 1 Then
        ' Return True
        'End If
        'MsgBox("Todos los medicamentos de la formula deben ser crónicos. Debe modificar los registros existentes.", MsgBoxStyle.Exclamation)
        'Return False
        'modificarMedicamentosEnGrilla(dtMedicamentos, "S")
        'End If

        'End If

        ' ''Validacion del convenio del medicamento. No deja seguir si no tiene convenio.
        'tieneConvenio = Sophia.HistoriaClinica.BL.BLPlanManejo.medicamentoTieneConvenio(objConexion, tbCodMedicamento.Text, _
        '                objGeneral.Prestador, objGeneral.Sucursal, objPaciente.Entidad)
        'If tieneConvenio = False Then
        '    MsgBox("El medicamento no tiene convenio", MsgBoxStyle.Exclamation)
        '    ValidarDatos = False
        'End If

    End Function
#End Region






#Region "EditarFilaGrilla-Actualizar"

    Private Sub EditarFormulacionExterna(ByVal dr As DataGridViewRow)
        tbCodEntidad.Text = dr.Cells("entidad").Value.ToString()
        cbEntidad.Text = dr.Cells("des_entidad").Value.ToString()
        tbCodMedicamento.Text = dr.Cells("Producto").Value.ToString()
        cbMedicamento.Text = dr.Cells("Descripcion").Value.ToString()
        'tbCantidad.Text = dr.Cells("cantidadDispensacion").Value.ToString()
        tbCantidadPrescripcion.Text = dr.Cells("Cantidad").Value.ToString()
        'tbPrescripcion.Text = dr.Cells("Prescripcion").Value.ToString()
        'tbDuracion.Text = dr.Cells("DuracionTrat").Value.ToString()
        lblCodUnidadPrescripcion.Text = dr.Cells("uni_med_pedido").Value.ToString
        lblUnidadPrescripcion.Text = dr.Cells("UnidadDePrescripcion").Value.ToString
        lblCodUnidadDispensacion.Text = dr.Cells("uni_med_dispensacion").Value.ToString
        lblUnidadDispensacion.Text = dr.Cells("UnidadDispensacion").Value.ToString

        'txttiempo.Text = dr.Cells("tiempomedcontrol").Value.ToString ''cpgaray
        'txtnumero.Text = dr.Cells("cantidadcontrol").Value.ToString ''cpgaray
        'txtCantidadLetras.Text = dr.Cells("cantidadletrascontrol").Value.ToString ''cpgaray

        tbCantidadPrescripcion.Text = dr.Cells("cantidadcontrol").Value.ToString
        lblletras.Text = dr.Cells("cantidadletrascontrol").Value.ToString
        txtLetras.Text = lblletras.Text
        txtDosis.Text = dr.Cells("dosis").Value.ToString
        txtDiasTrat.Text = dr.Cells("diastrat").Value.ToString

        txtObs.Text = dr.Cells("obs").Value.ToString

        ActivarEditarCombos(dr)

        If dr.Cells("MedControl").Value.ToString.Length > 0 And dr.Cells("MedControl").Value.ToString = "S" Then
            tbCantidadPrescripcion.Enabled = True
        Else
            tbCantidadPrescripcion.Enabled = False
        End If

        If lblCodUnidadPrescripcion.Text = lblCodUnidadDispensacion.Text Then
            'tbCantidad.ReadOnly = True
        Else
            'tbCantidad.ReadOnly = False
        End If
        strModificar = "PF"
    End Sub


    Private Sub dgFormulacion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgFormulacion.DoubleClick

        If dgFormulacion.DataSource Is Nothing Then
            Exit Sub
        Else
            If dgFormulacion.DataSource.Rows.Count <= 0 Then
                Exit Sub
            Else
                EditarFormulacionExterna(sender.CurrentRow)
                tbCodEntidad.Enabled = False
                cbEntidad.Enabled = False
                tbCodMedicamento.Enabled = False
                cbMedicamento.Enabled = False
                strModificar = "PF"

            End If
        End If
    End Sub

    Private Sub LimpiarMedicamento()
        tbCodEntidad.ResetText()
        cbEntidad.ResetText()
        tbCodMedicamento.ResetText()
        'cbMedicamento.ResetText()
        'tbPrescripcion.ResetText()
        'tbCantidad.ResetText()
        tbCantidadPrescripcion.ReadOnly = False
        tbCantidadPrescripcion.ResetText()
        txtObs.ResetText()
        ' tbDuracion.ResetText()
        lblCodUnidadPrescripcion.ResetText()
        lblUnidadPrescripcion.ResetText()
        lblCodUnidadDispensacion.ResetText()
        lblUnidadDispensacion.ResetText()
        strModificar = ""
    End Sub

    Private Sub LimpiarMedicamentoxraEntidad()
        tbCodMedicamento.ResetText()
        'cbMedicamento.ResetText()
        'tbPrescripcion.ResetText()
        tbCantidadPrescripcion.ReadOnly = False
        tbCantidadPrescripcion.ResetText()
        'tbCantidad.ResetText()
        lblCodUnidadPrescripcion.ResetText()
        lblUnidadPrescripcion.ResetText()
        lblCodUnidadDispensacion.ResetText()
        lblUnidadDispensacion.ResetText()
        'tbDuracion.ResetText()
        strModificar = ""
    End Sub


    Private Sub tbCodEntidad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbCodEntidad.Click
        LimpiarMedicamento()
    End Sub

    Private Sub tbCodMedicamento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbCodMedicamento.Click
        LimpiarMedicamentoxraEntidad()
    End Sub


    Private Sub dgFormulacion_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgFormulacion.UserDeletingRow
        If e.Row.Cells("nro_formula").Value > 0 Then
            If dgFormulacion.RowCount <= 1 Then
                e.Cancel = True
                MessageBox.Show("No Puede Eliminar Todos Los Registros de Medicamentos Para Esta Formula", "Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                If e.Row.Cells("adicionado").Value.ToString.Trim.Length = 0 Then
                    If EliminarMedicamento(e.Row.Cells("nro_formula").Value, e.Row.Cells("producto").Value.ToString) = False Then
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
            End If
        Else
            If dgFormulacion.RowCount <= 1 Then
                'chkCronico.Checked = False
                'chkCronico.Enabled = True
                'tbDuracion.Enabled = False
                cbEntidad.Enabled = True
                tbCodEntidad.Enabled = True
                tbCodEntidad.Focus()
                'rmzaldua 2009-06-10
                bsrMedicamentos.MoveFirst()
            End If
            strModificar = ""
        End If
        Me.limpiarPanelMedicamento()
    End Sub


#End Region

#Region "Grabar"
    Private Sub btGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGrabar.Click
        Dim objBl As New Sophia.HistoriaClinica.BL.BLPlanManejo
        Dim dtMedicamento As New DataTable
        Dim bError As Boolean = True
        Dim lerror As Long
        Dim rtornoFormulas As String
        Dim dNroOrden As Double
        Dim i As Integer
        Dim blnReimpresion As Boolean
        Dim intRows As Integer
        Dim NroFormula As Double
        Dim tmpCodSucur As String
        Dim FechaServidor As Date
        Dim FechaIni As Date
        Dim FechaFin As Date
        Dim FlagUpdate As Integer
        Dim Opcion As Integer
        Dim dtFecha As Date
        Dim FormulasArray() As String
        Dim objDatosGenerales As objGenerales.Generales
        objDatosGenerales = objGenerales.Generales.Instancia
        dtFecha = FuncionesGenerales.FechaServidor()

        NroFormula = 0
        FlagUpdate = 0
        tmpCodSucur = ""

        If ValidarDatosHisBasica() Then
            Exit Sub
        End If
        Dim ResultadoSesion As String

        ' Try
        ResultadoSesion = objBl.Consultausuariosseccion(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                         objPaciente.NumeroAdmision, objPaciente.AnoAdmision, "CM", InicioSesion)
        If ResultadoSesion = "S" Then
            MessageBox.Show("Se acaban de realizar gestiones a la conciliación de medicamentos por otro usuario.", "Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Information)
            IniciarFormulacionExterna()
            objFormuExt.Estado = "N"
            objFormuExt.EsNuevaFormula = True
            Me.btGrabar.Enabled = True
            Exit Sub
        End If
        'Catch ex As Exception
        'MessageBox.Show("Error: " + ex.Message, "Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Exit Sub
        'End Try

        If TmpCronicos = 1 Then
            TmpCronicos = 2
            dtFormulas = BLPlanManejo.consultarFormulaCronica(objConexion, objPaciente.TipoDocumento, objPaciente.NumeroDocumento)
            If dtFormulas.Rows.Count > 0 Then
                Opcion = MsgBox("¿Ya existe una formula crónica activa, desea reemplazarla?", MsgBoxStyle.YesNo, "Grabar Formulación")
                If Opcion = vbYes Then
                    'Me.btTraerCronicas.Enabled = False
                    NroFormula = dtFormulas.Rows(0).Item("nro_formula").ToString.Trim.ToUpper()
                    tmpCodSucur = dtFormulas.Rows(0).Item("Cod_Sucur").ToString.Trim.ToUpper()
                    FechaIni = Format(CDate(dtFormulas.Rows(0).Item("fecha").ToString.Trim.ToUpper()), "dd/MM/yyyy")
                    FechaFin = Format(CDate(dtFormulas.Rows(0).Item("fecha_final").ToString.Trim.ToUpper()), "dd/MM/yyyy")
                    FechaServidor = Format(FuncionesGenerales.FechaServidor(), "dd/MM/yyyy")
                    If (FechaServidor >= FechaIni) And (FechaServidor <= FechaFin) Then
                        FlagUpdate = 1
                    End If
                Else
                    If dgFormulacion.Rows.Count > 0 Then
                        'Me.btTraerCronicas.Enabled = False
                        TmpCronicos = 1
                    Else
                        ' Me.btTraerCronicas.Enabled = True
                        TmpCronicos = 1
                    End If
                    Exit Sub
                End If

            End If
        End If

        If dgFormulacion.Rows.Count > 0 Then
            If objFormuExt.Estado = "M" Then
                blnReimpresion = False
                objFormuExt.Estado = "S"
            Else
                blnReimpresion = Reimpresion()
            End If

            dNroOrden = objFormuExt.NumeroFormulaActual
            If blnReimpresion = False Then
                dtMedicamento = dgFormulacion.DataSource
                Try
                    rtornoFormulas = objBl.GrabarFormulacionExterna(objConexion, dtMedicamento.DefaultView.ToTable, dNroOrden, objGeneral.Prestador, objGeneral.Sucursal,
                                                            objPaciente.TipoAdmision, objPaciente.NumeroAdmision, objPaciente.AnoAdmision, NroFormula, tmpCodSucur, FlagUpdate)
                    If rtornoFormulas <> "" Then
                        '/ Cambiar estado \
                        FormulasArray = Split(rtornoFormulas, "|")
                        dNroOrden = FormulasArray(0)
                        objGeneral.HistoriaClinicaTieneModificaciones = True
                        ActualizarInformacionControles()
                        For i = 0 To dgFormulacion.Rows.Count - 1
                            dgFormulacion.Rows(i).Cells("adicionado").Value = ""
                        Next
                        'objFormuExt.dtFormulacion = dgFormulacion.DataSource
                        'ActualizarFormula()
                        If objFormuExt.EsNuevaFormula = True Then
                            'For i = 0 To dgFormulacion.Rows.Count - 1
                            objFormuExt.dtFormulacion.DefaultView.RowFilter = "nro_formula=0 or nro_formula=" & dNroOrden
                            intRows = dgFormulacion.Rows.Count - 1
                            For i = intRows To 0 Step -1
                                If dgFormulacion.Rows(i).Cells("nro_formula").Value = 0 Then
                                    dgFormulacion.Rows(i).Cells("nro_formula").Value = dNroOrden

                                End If
                            Next
                            'dgFormulacion.DataSource = objFormuExt.dtFormulacion
                            dgFormulacion.Sort(dgFormulacion.Columns("nro_formula"), System.ComponentModel.ListSortDirection.Ascending)
                            For i = 0 To objFormuExt.dtNroFormulas.Rows.Count - 1
                                If objFormuExt.dtNroFormulas.Rows(i).Item("nro_formula") = 0 Then
                                    objFormuExt.dtNroFormulas.Rows(i).Item("posic") = 0
                                    objFormuExt.dtNroFormulas.Rows(i).Item("nro_formula") = dNroOrden
                                    'objFormuExt.dtNroFormulas.Rows(i).Item("obs") = txtObs.Text
                                    Exit For
                                End If
                            Next
                        Else
                            'objFormuExt.dtNroFormulas.Rows(objFormuExt.PosicionActualFormula - 1).Item("obs") = tbObs.Text
                        End If


                        For Fx As Integer = 0 To FormulasArray.Length - 1
                            ImprimirReporte(CDbl(FormulasArray(Fx)), blnReimpresion, New RptHC_Enf_Med)
                            'dNroOrden = CDbl(FormulasArray(Fx))
                            'ImprimirReporte(dNroOrden, blnReimpresion)
                        Next
                        objFormuExt.NumeroFormulaActual = dNroOrden
                        objFormuExt.PosicionActualFormula = bsrMedicamentos.Position + 1
                        objFormuExt.EsNuevaFormula = False
                        'objFormuExt.ObservacionesFormula = tbObs.Text

                        lblNroFormula.Text = "No. " & dNroOrden
                        ' ''Ctc's Medicamentos Claudia Garay Marzo 27 de 2012
                        'Dim dtMedica As New DataTable
                        'Try
                        '    dtMedica = dgFormulacion.DataSource
                        '    'tratamiento="S"
                        '    Dim daoGeneral As New DAOGeneral
                        '    Dim email As String = ""


                        '    email = daoGeneral.EjecutarSQLStrValor("gensucur (nolock)", objConexion, " email", " cod_sucur='" & objGeneral.Sucursal & "'")

                        '    For i = 0 To dtMedica.Rows.Count - 1
                        '        '' strtratamiento = IIf(IsDBNull(dtMedica.Rows(i).Item("Tratamiento")), "", dtMedica.Rows(i).Item("Tratamiento"))
                        '        If Not IsDBNull(dtMedica.Rows(i).Item("cod_corto")) Then
                        '            If Len(dtMedica.Rows(i).Item("cod_corto")) > 0 And IsDBNull(dtMedica.Rows(i).Item("tratamiento")) Then
                        '                Dim frmExcepcion As New frmRepExcepcion

                        '                frmExcepcion.imprimirRepExcepcion(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision, _
                        '                objPaciente.AnoAdmision, objPaciente.NumeroAdmision, objPaciente.TipoDocumento, dNroOrden, objPaciente.NumeroDocumento, _
                        '                dtMedica.Rows(i).Item("cod_corto"), 0)
                        '                frmExcepcion.Show()
                        '                If email Is Nothing Or email = "" Then
                        '                    MessageBox.Show("No existe una direccion de correo parametrizada para la sucursal", "Historia Clinica", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                        '                Else

                        '                    Dim rptBytes As Byte() = frmExcepcion.getReportBytes(frmRepExcepcion.FormatReport.pdf)
                        '                    ' frmExcepcion.Visible = False

                        '                    ''Se envia el reporte via correo electronico
                        '                    If (Me.sendFormulaByMail(email, rptBytes, _
                        '                                            "Insumo_No_incluido_en_el_POS.pdf", "mailbog.colsanitas.com", "application/pdf", "Insumo No Incluido en el POS")) Then
                        '                        frmExcepcion.Dispose()
                        '                        ''MsgBox("El reporte de solicitud de servicios ha sido enviado sin inconvenientes", MsgBoxStyle.Information, "Historia Clinica")
                        '                        MessageBox.Show("La solicitud de medicamento o procedimiento - Insumo No incluido en el POS ha sido enviado sin inconvenientes", "Historia Clinica", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        '                        'Dim visorRptFormula1 As New FrmRepFomulaProcedimtPDF(codPrestador, codSucursal, tipAdmin, _
                        '                        '                                   iAno, lNumAdm, dConProcedim, FlagConsulta)

                        '                        'visorRptFormula1.WindowState = FormWindowState.Maximized
                        '                        ' ''visorRptFormula.ShowDialog(Me.ParentForm)
                        '                        'frmExcepcion.Visible = True

                        '                    Else
                        '                        frmExcepcion.Dispose()
                        '                        MessageBox.Show("La solicitud de medicamento o procedimiento - Insumo No incluido en el POS no ha podido ser enviado", "Historia Clinica", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        '                    End If
                        '                End If
                        '                Dim frmExcepcionR As New frmRepExcepcion

                        '                frmExcepcionR.imprimirRepExcepcion(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision, _
                        '                objPaciente.AnoAdmision, objPaciente.NumeroAdmision, objPaciente.TipoDocumento, dNroOrden, objPaciente.NumeroDocumento, _
                        '                dtMedica.Rows(i).Item("cod_corto"), 0)
                        '                frmExcepcionR.Show()



                        '            End If
                        '            End If
                        '    Next

                        'Catch ex As Exception

                        'End Try

                        limpiarPanelMedicamento()
                        ActualizarFormula()
                        'tbObs.Text = objFormuExt.ObservacionesFormula.ToString
                        blnNoNuevo = False
                        NewFormula.Enabled = True
                        objFormuExt.NuevaFormulaActiva = False
                        tbCodMedicamento.Enabled = True
                        cbMedicamento.Enabled = True
                        btCancelar.Visible = False
                        'GroupBox1.Enabled = False
                    Else
                        '/ Ingresar valores a la variable global
                        MsgBox("La formulación no se grabó, por favor verifique los datos", MsgBoxStyle.Exclamation)

                    End If
                Catch ex As Exception
                    '***** para el control de errores ....*****
                    MessageBox.Show("El proceso de grabación de formulación externa falló por: " & ex.Message, "Historia Clínica", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
                End Try
            Else
                'ImprimirReporte(dNroOrden, blnReimpresion)
                ImprimirReporte(dNroOrden, blnReimpresion, New RptHC_Enf_Med)
            End If

        Else
            MsgBox("Debe ingresar al menos un medicamento", MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Function EliminarMedicamento(ByVal dblNroFormula As Double, ByVal strProducto As String) As Boolean
        Dim objBl As New Sophia.HistoriaClinica.BL.BLPlanManejo

        Dim lerror As Long


        Try
            lerror = objBl.EliminarMedicamentoFormulacionExterna(objConexion, dblNroFormula, strProducto, objGeneral.Prestador, objGeneral.Sucursal,
                                                     objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision)
            If lerror = 0 Then
                '/ Cambiar estado \
                limpiarPanelMedicamento()
            Else
                MsgBox("El Medicamento No Se Eliminó, por favor verifique los datos", MsgBoxStyle.Exclamation)
                Return False
            End If
        Catch ex As Exception
            '***** para el control de errores ....*****
            MessageBox.Show("El proceso de eliminación del medicamento falló por: " & ex.Message, "Historia Clínica", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
            Return False
        End Try

        Return True
    End Function

#End Region

#Region "ImprimirReporte"
    Public Sub ImprimirReporte(ByVal dNroOrden As Double, ByVal blnReimpresion As Boolean, Ventana As RptHC_Enf_Med)
        Dim objDatosGenerales As objGenerales.Generales

        objDatosGenerales = objGenerales.Generales.Instancia

        If objDatosGenerales.Pais = "482" Or objDatosGenerales.Pais = "484" Then ''Peru ó Venezuela
            frmRepFormuMedica.Show()
            frmRepFormuMedica.imprimirFormulaMedica(objConexion, objGeneral.Prestador, objGeneral.Sucursal,
                                                 objPaciente.TipoAdmision, objPaciente.AnoAdmision,
                                                 objPaciente.NumeroAdmision, dNroOrden, blnReimpresion, objPaciente.TipoUsuario)
        Else
            '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
            'Juan Carlos Jaramillo Lozano - IG
            Ventana.Show()
            Ventana.ImprimirHistoriaClinica_imprimirFormulaMedica(objConexion, "48", objGeneral.Prestador,
                                                                                objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                                                objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                            dNroOrden, blnReimpresion, objPaciente.TipoUsuario, objPaciente.CodHistoria)
            '2019-03-11 Fin
        End If
    End Sub

    Private Function Reimpresion() As Boolean
        Dim dtDatos As DataTable
        Dim intRow As Integer

        dtDatos = dgFormulacion.DataSource

        For intRow = 0 To dgFormulacion.Rows.Count - 1
            If dgFormulacion.Rows(intRow).Cells("adicionado").Value.ToString.Trim = "S" Then
                Reimpresion = False
                Exit Function
            End If

            If dgFormulacion.Rows(intRow).Cells("entidad").Value.ToString.Trim <> dgFormulacion.Rows(intRow).Cells("entidad_ant").Value.ToString.Trim Then
                Reimpresion = False
                Exit Function
            End If

            If dgFormulacion.Rows(intRow).Cells("producto").Value.ToString.Trim <> dgFormulacion.Rows(intRow).Cells("producto_ant").Value.ToString.Trim Then
                Reimpresion = False
                Exit Function
            End If

            If dgFormulacion.Rows(intRow).Cells("prescripcion").Value.ToString.Trim <> dgFormulacion.Rows(intRow).Cells("prescripcion_ant").Value.ToString.Trim Then
                Reimpresion = False
                Exit Function
            End If

            If dgFormulacion.Rows(intRow).Cells("cantidad").Value.ToString.Trim <> dgFormulacion.Rows(intRow).Cells("cantidad_ant").Value.ToString.Trim Then
                Reimpresion = False
                Exit Function
            End If

            If dgFormulacion.Rows(intRow).Cells("cantidadDispensacion").Value.ToString.Trim <> dgFormulacion.Rows(intRow).Cells("cantidadDispensacion_ant").Value.ToString.Trim Then
                Reimpresion = False
                Exit Function
            End If

            If dgFormulacion.Rows(intRow).Cells("cronico").Value.ToString.Trim <> dgFormulacion.Rows(intRow).Cells("cronico_ant").Value.ToString.Trim Then
                Reimpresion = False
                Exit Function
            End If

            If dgFormulacion.Rows(intRow).Cells("duraciontrat").Value.ToString.Trim <> dgFormulacion.Rows(intRow).Cells("duraciontrat_ant").Value.ToString.Trim Then
                Reimpresion = False
                Exit Function
            End If

            'If tbObs.Text.ToString.Trim <> tbObs.Tag.ToString.Trim Then
            '    Reimpresion = False
            '    Exit Function
            'End If

        Next

        Reimpresion = True

    End Function
#End Region

#Region "Funciones Comunes Procesos Formulacion Externa"

    Private Function ValidarCamposObligatorios(ByVal ctlContenedor As Panel) As Boolean
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

    Private Sub limpiarPanelMedicamento()

        tbCodMedicamento.ResetText()
        cbMedicamento.ResetText()
        'tbCantidad.ResetText()
        tbCantidadPrescripcion.ReadOnly = False
        tbCantidadPrescripcion.ResetText()
        'tbPrescripcion.ResetText()
        'tbDuracion.ResetText()
        lblCodUnidadPrescripcion.ResetText()
        lblUnidadPrescripcion.ResetText()
        lblCodUnidadDispensacion.ResetText()
        lblUnidadDispensacion.ResetText()
        txtDosis.ResetText()
        txtDescripcionFreq.ResetText()
        txtDescripcionUM.ResetText()
        txtDescripcionVA.ResetText()
        rbUsoAgudo.Checked = True
        txtObs.ResetText()
        lblletras.ResetText()
        txtLetras.ResetText()
        'txttiempo.ResetText() ''cpgaray
        'txtnumero.ResetText() ''cpgaray
        'txtCantidadLetras.ResetText() ''cpgaray
        txtDiasTrat.Text = 0
        If TmpCronicos <> 2 Then
            If objFormuExt.NumeroFormulaActual > 0 Then
                ' Me.btTraerCronicas.Enabled = False
            Else
                'Me.btTraerCronicas.Enabled = True
            End If
        Else
            'Me.btTraerCronicas.Enabled = False
            'Me.chkCronico.Checked = False
        End If
    End Sub

#End Region

#Region "Medicamentos Cronicos"

    Private Sub chkCronico_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim dtFormulaCronica As DataTable

        ' tbDuracion.ResetText()
        'If chkCronico.Checked = True Then
        'tbDuracion.Enabled = True
        'If TmpCronicos <> 2 Then
        'If objFormuExt.NumeroFormulaActual > 0 Then
        'TmpCronicos = 0
        'Else
        'TmpCronicos = 1
        'End If
        'End If

        'dtFormulaCronica = BLPlanManejo.consultarFormulaCronicaActiva(objConexion, objPaciente.TipoDocumento, _
        '                                           objPaciente.NumeroDocumento)
        'If Not IsNothing(dtFormulaCronica) Then
        '    If dtFormulaCronica.Rows.Count > 0 Then
        '        dgFormulacion.DataSource = dtFormulaCronica
        '        objFormuExt.dtFormulacion = dtFormulaCronica
        '        chkCronico.Enabled = False
        '    End If
        'End If
        'Else
        '    tbDuracion.Enabled = False
        '    If TmpCronicos <> 2 Then
        '        TmpCronicos = 0
        '    End If
        'End If
    End Sub

    Private Sub setConfiguracionInicialCronicos()
        Dim dtMedicamentos As DataTable

        dtMedicamentos = dgFormulacion.DataSource().copy()

        ''Si existen medicamentos cronicos en la grilla
        'If existenMedicamentosEnGrilla(dtMedicamentos, "S") Then
        ' chkCronico.Checked = True
        'chkCronico.Enabled = False
        'tbDuracion.Enabled = True
        'TmpCronicos = 2
        'Else
        'chkCronico.Checked = False
        'chkCronico.Enabled = True
        'tbDuracion.Enabled = False
        'End If

    End Sub
    ''' <summary>
    ''' Determina si hay en el datatable existen medicamentos cronicos o no 
    ''' cronicos dependiendo del parametro "strBuscarCronico"
    ''' </summary>
    ''' <param name="dtmedicamentos">DataTable donde se realiza la busqueda</param>
    ''' <param name="strBuscarCronicos">"S" Busca medicamentos cronicos o "N" busca medicamentos no cronicos</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function existenMedicamentosEnGrilla(ByVal dtmedicamentos As DataTable, ByVal strBuscarCronicos As String) As Boolean

        Dim arrayCronicos() As DataRow

        If IsNothing(dtmedicamentos) Then
            Return False
        End If

        arrayCronicos = dtmedicamentos.Select("Cronico = '" & strBuscarCronicos & "'")

        If IsNothing(arrayCronicos) Then
            Return False
        ElseIf arrayCronicos.Length > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Sub modificarMedicamentosEnGrilla(ByVal dtMedicamentos As DataTable, ByVal strCronico As String)
        Dim i As Integer

        For i = 0 To dtMedicamentos.Rows.Count - 1
            dtMedicamentos.Rows(i).Item("Cronico") = strCronico
        Next

    End Sub

#End Region

#Region "Procesos del Navegador"

    Private Sub bsrMedicamentos_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles bsrMedicamentos.PositionChanged
        Dim strManejaConvenio As String = String.Empty

        If blnNoNuevo = False Then
            If objFormuExt.EsNuevaFormula = True Then
                objFormuExt.EsNuevaFormula = False
                NewFormula.Enabled = True
            End If
        Else
            blnNoNuevo = False
        End If

        ActualizarFormula(, strManejaConvenio)

        CargarComboMedicamentos(strManejaConvenio)
        'setConfiguracionInicialCronicos()
    End Sub

    Private Sub NewFormula_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewFormula.Click
        GuardarFormula()
        dtRowViewAntesDeNuevo = bsrMedicamentos.Current
        intPosAntesDeNuevo = bsrMedicamentos.Position
        objFormuExt.EsNuevaFormula = True
        objFormuExt.NumeroFormulaActual = 0
        objFormuExt.NuevaFormulaActiva = True
        ActualizarFormula(True)
        NewFormula.Enabled = False
        cbEntidad.Enabled = True
        tbCodEntidad.Enabled = True
        'chkCronico.Enabled = True
        'chkCronico.Checked = False
        'tbDuracion.ResetText()
        'tbDuracion.Enabled = True
        tbCodEntidad.Text = objPaciente.Entidad
        cbEntidad.Text = objPaciente.DescripcionEntidad
        If objFormuExt.dtNroFormulas.Rows.Count = 1 Then
            btCancelar.Visible = True
        End If
        If TmpCronicos = 0 Then
            '   btTraerCronicas.Enabled = True
        Else
            '  btTraerCronicas.Enabled = False
            If TmpCronicos = 2 Then
                '    Me.chkCronico.Enabled = False
                '    Me.tbDuracion.Enabled = False
            End If
        End If
        Me.btCancelar.Visible = True

        CargarComboMedicamentos(objPaciente.ManejaConvenio)
        tbCodMedicamento.Focus()
    End Sub

    Private Sub ActualizarInfoPosicionFormula()
        txtPosicion.Text = objFormuExt.PosicionActualFormula & " de " & (objFormuExt.dtNroFormulas.Rows.Count + IIf(objFormuExt.EsNuevaFormula = True, IIf(objFormuExt.PosicionActualFormula = objFormuExt.dtNroFormulas.Rows.Count, 0, 1), 0))
        If objFormuExt.EsNuevaFormula = False Then
            lblNroFormula.Text = IIf(objFormuExt.NumeroFormulaActual = 0, "(Nuevo)", "No. " & objFormuExt.NumeroFormulaActual)
        End If
        If objFormuExt.dtNroFormulas.Rows.Count > 0 And dgFormulacion.RowCount > 0 Then
            tbCodEntidad.Enabled = False
            cbEntidad.Enabled = False
        Else
            tbCodEntidad.Enabled = True
            cbEntidad.Enabled = True
        End If
        If objFormuExt.NumeroFormulaActual = 0 Then
            objFormuExt.EsNuevaFormula = True
        End If
        If objFormuExt.NuevaFormulaActiva = True Then
            NewFormula.Enabled = False
        End If

    End Sub

    Private Sub btCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btCancelar.Click
        If TmpCronicos = 1 Then
            TmpCronicos = 0
        End If
        bsrMedicamentos.MoveFirst()
        objFormuExt.EsNuevaFormula = False
        objFormuExt.NuevaFormulaActiva = False
        ActualizarFormula()
        NewFormula.Enabled = True
        btCancelar.Visible = False
        CargarComboMedicamentos(objPaciente.ManejaConvenio)
        limpiarPanelMedicamento()
        If tbCodEntidad.Enabled = True Then
            tbCodEntidad.Focus()
        Else
            tbCodMedicamento.Focus()
        End If
        objFormuExt.Estado = ""
        IniciarFormulacionExterna()
        '@hrariza CU05
        'Inicio
        IniciarTblInformativa()
        'Fin
    End Sub

#End Region



    Private Sub cbEntidad_ActualizarDatosElegidos(ByVal datosElegidos As System.Data.DataRow) Handles cbEntidad.ActualizarDatosElegidos
        If cbEntidad.SelectedIndex > -1 Then
            cbMedicamento.ResetText()
            tbCodMedicamento.ResetText()
            cbMedicamento.ConvenioMedicamento = IIf(datosElegidos.Item("man_conv_med").ToString = "S", True, False)
            cbMedicamento.Entidad = datosElegidos.Item("codigo").ToString
            cbMedicamento.UltimaDescripcionDeBusqueda = ""
            cbMedicamento.ControlTieneCache = Not cbMedicamento.ConvenioMedicamento
            cbMedicamento.CargarDatos()

        End If
    End Sub

    Private Sub cbMedicamento_ActualizarDatosElegidos(ByVal datosElegidos As System.Data.DataRow) Handles cbMedicamento.ActualizarDatosElegidos

        Me.lblUnidadPrescripcion.Text = datosElegidos.Item("UnidadDePrescripcion").ToString
        Me.lblCodUnidadPrescripcion.Text = datosElegidos.Item("uni_med_pedido").ToString
        Me.lblUnidadDispensacion.Text = datosElegidos.Item("UnidadDispensacion").ToString
        Me.lblCodUnidadDispensacion.Text = datosElegidos.Item("uni_med_dispensacion").ToString

        'Me.txttiempo.Text = String.Empty
        'Me.txtCantidadLetras.Text = String.Empty
        'Me.txtnumero.Text = String.Empty

        If datosElegidos.Item("MedControl").ToString = "S" Then
            tbCantidadPrescripcion.Enabled = True
            'tbCantidad.Enabled = False
            'GroupBox1.Enabled = True
            BoolMedControl = True
        Else
            'GroupBox1.Enabled = False
            tbCantidadPrescripcion.Enabled = False
            'tbCantidad.Enabled = True
            BoolMedControl = False
        End If


        If Not IsDBNull(datosElegidos.Item("AltoCosto").ToString) Then
            If Len(datosElegidos.Item("AltoCosto").ToString) > 1 Then
                AltoCosto = True
            Else
                AltoCosto = False
            End If

        Else
            AltoCosto = False
        End If

    End Sub


    Private Sub navFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles navFirst.Click
        GuardarFormula()

    End Sub

    Private Sub GuardarFormula()
        Dim objBl As New Sophia.HistoriaClinica.BL.BLPlanManejo
        Dim dtMedicamento As New DataTable
        Dim bError As Boolean = True
        Dim lerror As Long
        Dim dNroOrden As Double
        Dim i As Integer
        Dim blnReimpresion As Boolean
        Dim intRows As Integer
        Dim NroFormula As Double
        Dim tmpCodSucur As String
        Dim FechaServidor As Date
        Dim FechaIni As Date
        Dim FechaFin As Date
        Dim FlagUpdate As Integer
        Dim Opcion As Integer

        If ValidarDatosHisBasica() Then
            Exit Sub
        End If

        NroFormula = 0
        tmpCodSucur = ""
        FlagUpdate = 0
        If TmpCronicos = 1 Then
            dtFormulas = BLPlanManejo.consultarFormulaCronica(objConexion, objPaciente.TipoDocumento, objPaciente.NumeroDocumento)
            If dtFormulas.Rows.Count > 0 Then
                Opcion = MsgBox("¿Ya existe una formula crónica activa, desea reemplazarla?", MsgBoxStyle.YesNo, "Grabar Formulación")
                If Opcion = vbYes Then
                    'Me.btTraerCronicas.Enabled = False
                    TmpCronicos = 2
                    NroFormula = dtFormulas.Rows(0).Item("nro_formula").ToString.Trim.ToUpper()
                    tmpCodSucur = dtFormulas.Rows(0).Item("Cod_Sucur").ToString.Trim.ToUpper()
                    FechaIni = Format(CDate(dtFormulas.Rows(0).Item("fecha").ToString.Trim.ToUpper()), "dd/MM/yyyy")
                    FechaFin = Format(CDate(dtFormulas.Rows(0).Item("fecha_final").ToString.Trim.ToUpper()), "dd/MM/yyyy")
                    FechaServidor = Format(FuncionesGenerales.FechaServidor(), "dd/MM/yyyy")
                    If (FechaServidor >= FechaIni) And (FechaServidor <= FechaFin) Then
                        FlagUpdate = 1
                    End If
                Else
                    'Me.btTraerCronicas.Enabled = True
                    TmpCronicos = 1
                    Exit Sub
                End If
            End If
        End If


        If dgFormulacion.Rows.Count > 0 Then
            If objFormuExt.Estado = "M" Then
                blnReimpresion = False
                objFormuExt.Estado = "S"
            Else
                blnReimpresion = Reimpresion()
            End If

            dNroOrden = objFormuExt.NumeroFormulaActual
            If blnReimpresion = False Then
                For i = 0 To dgFormulacion.Rows.Count - 1
                    ' dgFormulacion.Rows(i).Cells("obs").Value = tbObs.Text
                Next i
                dtMedicamento = dgFormulacion.DataSource
                Try
                    lerror = objBl.GrabarFormulacionExterna(objConexion, dtMedicamento.DefaultView.ToTable, dNroOrden, objGeneral.Prestador, objGeneral.Sucursal,
                                                            objPaciente.TipoAdmision, objPaciente.NumeroAdmision, objPaciente.AnoAdmision, NroFormula, tmpCodSucur, FlagUpdate)
                    If lerror = 0 Then
                        '/ Cambiar estado \
                        objGeneral.HistoriaClinicaTieneModificaciones = True
                        ActualizarInformacionControles()
                        For i = 0 To dgFormulacion.Rows.Count - 1
                            dgFormulacion.Rows(i).Cells("adicionado").Value = ""
                        Next
                        'objFormuExt.dtFormulacion = dgFormulacion.DataSource
                        'ActualizarFormula()
                        If objFormuExt.EsNuevaFormula = True Then
                            'For i = 0 To dgFormulacion.Rows.Count - 1
                            objFormuExt.dtFormulacion.DefaultView.RowFilter = "nro_formula=0 or nro_formula=" & dNroOrden
                            intRows = dgFormulacion.Rows.Count - 1
                            For i = intRows To 0 Step -1
                                If dgFormulacion.Rows(i).Cells("nro_formula").Value = 0 Then
                                    dgFormulacion.Rows(i).Cells("nro_formula").Value = dNroOrden
                                End If
                            Next
                            'dgFormulacion.DataSource = objFormuExt.dtFormulacion
                            dgFormulacion.Sort(dgFormulacion.Columns("nro_formula"), System.ComponentModel.ListSortDirection.Ascending)
                            For i = 0 To objFormuExt.dtNroFormulas.Rows.Count - 1
                                If objFormuExt.dtNroFormulas.Rows(i).Item("nro_formula") = 0 Then
                                    objFormuExt.dtNroFormulas.Rows(i).Item("posic") = 0
                                    objFormuExt.dtNroFormulas.Rows(i).Item("nro_formula") = dNroOrden
                                    'objFormuExt.dtNroFormulas.Rows(i).Item("obs") = tbObs.Text
                                    Exit For
                                End If
                            Next
                        Else
                            'objFormuExt.dtNroFormulas.Rows(objFormuExt.PosicionActualFormula - 1).Item("obs") = tbObs.Text
                        End If
                        objFormuExt.NumeroFormulaActual = dNroOrden
                        objFormuExt.PosicionActualFormula = bsrMedicamentos.Position + 1
                        objFormuExt.EsNuevaFormula = False
                        'objFormuExt.ObservacionesFormula = tbObs.Text
                        limpiarPanelMedicamento()
                        ActualizarFormula()
                        'tbObs.Text = objFormuExt.ObservacionesFormula.ToString
                        blnNoNuevo = False
                        NewFormula.Enabled = True
                        objFormuExt.NuevaFormulaActiva = False
                        tbCodMedicamento.Enabled = True
                        cbMedicamento.Enabled = True
                        btCancelar.Visible = False
                    Else
                        '/ Ingresar valores a la variable global
                        'MsgBox("La formulación no se grabó, por favor verifique los datos", MsgBoxStyle.Exclamation)

                    End If
                Catch ex As Exception
                    '***** para el control de errores ....*****
                    'MessageBox.Show("El proceso de grabación de formulación externa falló por: " & ex.Message, "Historia Clínica", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
                End Try
            Else
                'ImprimirReporte(dNroOrden, blnReimpresion)
            End If

        Else
            'MsgBox("Debe ingresar al menos un medicamento", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub navPrevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles navPrevious.Click
        GuardarFormula()
        setConfiguracionInicialCronicos()
    End Sub

    Private Sub navLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles navLast.Click
        GuardarFormula()
        setConfiguracionInicialCronicos()
    End Sub

    Private Sub navNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles navNext.Click
        GuardarFormula()
        setConfiguracionInicialCronicos()
    End Sub


    Private Sub CtlPlanFormuExterna_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged
        If sender.Visible = True Then
            If frmHistoriaPrincipal.blnFirstPlanFormuExterna = True Then
                LimpiarDatos()
                IniciarFormulacionExterna()
                'Hrariza@ CU05
                'Inicio
                IniciarTblInformativa()
                'Fin
                frmHistoriaPrincipal.blnFirstPlanFormuExterna = False
            End If
        Else
            FinalizarFormulacionExterna()
        End If
    End Sub

    Private Sub LimpiarDatos()
        tbCodEntidad.ResetText()
        cbEntidad.ResetText()
        tbCodMedicamento.ResetText()
        cbMedicamento.ResetText()
        'tbPrescripcion.ResetText()
        'tbCantidad.ResetText()
        tbCantidadPrescripcion.ReadOnly = False
        tbCantidadPrescripcion.ResetText()
        'chkCronico.Checked = False
        'tbDuracion.ResetText()
        tbObs.ResetText()
        txtPosicion.Text = ""
        Me.lblNroFormula.Text = ""

    End Sub

    Private Sub tbCantidadPrescripcion_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If lblCodUnidadPrescripcion.Text = lblCodUnidadDispensacion.Text Then
            'tbCantidad.Text = tbCantidadPrescripcion.Text
            'tbCantidad.ReadOnly = True
        Else
            'tbCantidad.ReadOnly = False
            'tbCantidad.ResetText()
        End If
    End Sub




    Private Sub cbMedicamento_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbMedicamento.Validating

        If cbMedicamento.OrigenDeDatos Is Nothing Then
            Exit Sub
        ElseIf cbMedicamento.OrigenDeDatos.Rows.Count = 0 Then
            Exit Sub
        End If
        Dim dtRows() As DataRow

        dtRows = cbMedicamento.OrigenDeDatos.Select("descripcion='" & cbMedicamento.Text & "' AND codigo='" & tbCodMedicamento.Text & "'")
        If dtRows.Length > 0 Then
            Me.lblUnidadPrescripcion.Text = dtRows(0).Item("UnidadDePrescripcion").ToString
            Me.lblCodUnidadPrescripcion.Text = dtRows(0).Item("uni_med_pedido").ToString
            Me.lblUnidadDispensacion.Text = dtRows(0).Item("UnidadDispensacion").ToString
            Me.lblCodUnidadDispensacion.Text = dtRows(0).Item("uni_med_dispensacion").ToString

            If dtRows(0).Item("MedControl").ToString = "S" Then
                tbCantidadPrescripcion.Enabled = True
                'tbCantidad.Enabled = False
                'GroupBox1.Enabled = True
                BoolMedControl = True
            Else
                'GroupBox1.Enabled = False
                tbCantidadPrescripcion.Enabled = False
                'tbCantidad.Enabled = True
                BoolMedControl = False
            End If

        End If
    End Sub




    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub btTraerCronicas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim dtFormulas As New DataTable
        Dim blnNuevo As Boolean = False
        Dim dblNroFormula As Double = 0
        Dim I As Integer
        Dim objBL As New BLBasicasGenerales
        Dim dtRow As DataRow
        Dim dtEntidad As DataTable
        Dim NumeroMedicamentos As Integer
        Dim objConseguirDatosS As New BLHistoriaBasica

        'If Me.chkCronico.Checked = True And Me.tbDuracion.Text <> "" Then
        'Cambio Realizado por Ing. Ricardo Mauricio Zaldua C.
        'Fecha 2009-05-08
        'Motivo realizar validacion de numero de tratamiento 
        'Solicitado por Mauricio Forero
        'dtEntidad = objConseguirDatosS.ConsultarTablasBasicas("genentid", objConexion, "nro_med_for,MaxEntregasFormulaCronicos", "entidad='" & tbCodEntidad.Text & "'")
        'If dtEntidad.Rows.Count > 0 Then
        'NumeroMedicamentos = dtEntidad.Rows(0).Item("nro_med_for").ToString
        'NumeroEntregas = IIf((dtEntidad.Rows(0).Item("MaxEntregasFormulaCronicos").ToString) = "", 0, dtEntidad.Rows(0).Item("MaxEntregasFormulaCronicos").ToString)
        'End If
        'If tbDuracion.Text > NumeroEntregas Then ' ojo cambio
        'MsgBox("El tratamiento no puede ser mayor a " & NumeroEntregas, MsgBoxStyle.Exclamation)
        'tbDuracion.Focus()
        'Exit Sub
        'End If

        'If Me.tbDuracion.Text = "0" Then
        'Me.tbDuracion.Text = "1"
        'End If
        dtFormulas = BLPlanManejo.consultarFormulaCronica(objConexion, objPaciente.TipoDocumento, objPaciente.NumeroDocumento)
        If dtFormulas.Rows.Count > 0 Then
            For I = 0 To dtFormulas.Rows.Count - 1
                'MsgBox(dtFormulas.Rows(I).Item("producto").ToString.Trim.ToUpper())
                'dtFormulas.Rows(I).Item("producto").ToString.Trim.ToUpper()
                dtRow = objFormuExt.dtNroFormulas.NewRow
                dtRow.Item("nro_formula") = 0
                dtRow.Item("entidad") = dtFormulas.Rows(I).Item("entidad").ToString.Trim.ToUpper() 'tbCodEntidad.Text
                dtRow.Item("des_entidad") = dtFormulas.Rows(I).Item("des_entidad").ToString.Trim.ToUpper() 'cbEntidad.Text
                dtRow.Item("posic") = 1
                dtRow.Item("man_conv_med") = dtFormulas.Rows(I).Item("man_conv_med").ToString.Trim.ToUpper() 'IIf(cbMedicamento.ConvenioMedicamento = True, "S", "N")
                objFormuExt.dtNroFormulas.Rows.Add(dtRow)
                dtRowViewAntesDeNuevo = Nothing
                'Cambio realizado por Ing. Ricardo Mauricio Zaldua C. 2009-05-13 solicitado por Mauricio Forero se comentario la linea para que no colocar el convenio en false 
                'bsrMedicamentos.Position = objFormuExt.dtNroFormulas.Rows.Count
                dtRow = dgFormulacion.DataSource.NewRow()
                dtRow("cod_pre_sgs") = objGeneral.Prestador
                dtRow("cod_sucur") = objGeneral.Sucursal
                dtRow("producto") = dtFormulas.Rows(I).Item("producto").ToString.Trim.ToUpper() 'tbCodMedicamento.Text
                dtRow("tip_doc") = objPaciente.TipoDocumento
                dtRow("Num_doc") = objPaciente.NumeroDocumento
                dtRow("entidad") = tbCodEntidad.Text
                dtRow("des_entidad") = cbEntidad.Text
                dtRow("medico") = objGeneral.Login
                dtRow("nroautoriza") = 0
                dtRow("dosis") = 0
                dtRow("cada") = 0
                dtRow("tiempo") = 0
                dtRow("estado") = "P"
                dtRow("pais") = objGeneral.Pais
                dtRow("departamen") = objGeneral.Departamento
                dtRow("ciudad") = objGeneral.Ciudad
                dtRow("login") = objGeneral.Login
                dtRow("Descripcion") = dtFormulas.Rows(I).Item("Descripcion").ToString.Trim.ToUpper()
                dtRow("prescripcion") = dtFormulas.Rows(I).Item("prescripcion").ToString.Trim.ToUpper() 'Trim(tbPrescripcion.Text)
                dtRow("cantidadDispensacion") = dtFormulas.Rows(I).Item("cantidadDispensacion").ToString.Trim.ToUpper() 'Trim(tbCantidad.Text)
                dtRow("cantidad") = dtFormulas.Rows(I).Item("cantidad").ToString.Trim.ToUpper() 'Trim(tbCantidadPrescripcion.Text)
                dtRow("UnidadDispensacion") = dtFormulas.Rows(I).Item("UnidadDispensacion").ToString.Trim.ToUpper() 'lblUnidadDispensacion.Text
                dtRow("adicionado") = "S"
                dtRow("Cronico") = "S"
                'dtRow("DuracionTrat") = IIf(tbDuracion.Text.Trim.Length > 0, tbDuracion.Text.Trim, 0)
                dtRow("Tratamiento") = Nothing  ''Medicamento iniciado
                dtRow("nro_formula") = IIf(objFormuExt.EsNuevaFormula = True, 0, objFormuExt.NumeroFormulaActual)
                dtRow("uni_med_pedido") = dtFormulas.Rows(I).Item("uni_med_pedido").ToString.Trim.ToUpper() 'lblCodUnidadPrescripcion.Text
                dtRow("UnidadDePrescripcion") = dtFormulas.Rows(I).Item("UnidadDePrescripcion").ToString.Trim.ToUpper() 'lblUnidadPrescripcion.Text
                dtRow("uni_med_dispensacion") = dtFormulas.Rows(I).Item("uni_med_dispensacion").ToString.Trim.ToUpper() 'lblCodUnidadDispensacion.Text
                'dtTable.Rows.Add(dtRow)
                dgFormulacion.DataSource.Rows.Add(dtRow)
            Next
            'Me.chkCronico.Enabled = False
            'Me.tbDuracion.Enabled = False
            'Me.btTraerCronicas.Enabled = False
            TmpCronicos = 1
        Else
            MsgBox("No Exsite Formulacion Crónicos", , "Traer Medicamentos Cronicos")
        End If
        ' Else
        MsgBox("Debe Escoger Formulación Crónica y/o la Duracion Del Tratamiento Debe Ser Mayor Que Cero", , "Traer Medicamentos Crónicos")
        'End If
        blnNoNuevo = True
    End Sub
    Private Function VerificarMedicamentoAltoCosto(ByVal dblFormula As Double) As Boolean
        '// Verificar que el Procedimiento no se haya adicionado
        Dim dtTable As DataTable = New DataTable
        Dim dtMedAltocos As New DataTable
        Dim dtMedControlado As New DataTable
        Dim objConseguirDatosS As New BLHistoriaBasica
        Dim cuentacontrol As Integer = 0
        Dim cuentacorriente As Integer = 0
        dtTable = dgFormulacion.DataSource
        'Dim FilaBuscada() As DataRow
        VerificarMedicamentoAltoCosto = False

        If dtTable.Rows.Count > 0 Then

            dtMedAltocos = objConseguirDatosS.ConsultarTablasBasicas("genmedicamenaltocos", objConexion, "Producto", "entidad='" & tbCodEntidad.Text & "' and Producto='" & tbCodMedicamento.Text & "'")
            dtMedControlado = objConseguirDatosS.ConsultarTablasBasicas("genprodu", objConexion, "cod_corto", "med_controlado='S' and cod_corto='" & tbCodMedicamento.Text & "'")

            ' ''cpgaray Se corrigen las validaciones de Medicamentos de control y alto costo
            If objFormuExt.EsNuevaFormula = True Then
                For i As Integer = 0 To dtTable.Rows.Count - 1
                    If dtTable.Rows(i).Item("Nro_Formula") = 0 Then
                        If dtTable.Rows(i).Item("MedControl") = "S" And dtMedControlado.Rows.Count = 0 Then
                            cuentacontrol = cuentacontrol + 1
                        End If
                        If dtTable.Rows(i).Item("MedControl") = "N" And dtMedControlado.Rows.Count > 0 Then
                            cuentacontrol = cuentacontrol + 1
                        End If
                    End If
                Next
                If cuentacontrol > 0 Then
                    Return True
                Else
                    Return False
                End If
            Else
                For i As Integer = 0 To dtTable.Rows.Count - 1

                    If dtTable.Rows(i).Item("MedControl") = "S" And dtMedControlado.Rows.Count = 0 Then
                        cuentacontrol = cuentacontrol + 1
                    End If
                    If dtTable.Rows(i).Item("MedControl") = "N" And dtMedControlado.Rows.Count > 0 Then
                        cuentacontrol = cuentacontrol + 1
                    End If

                Next
                If cuentacontrol > 0 Then
                    Return True
                Else
                    Return False
                End If
            End If

        Else

            Return False

        End If

        ''End If


        ' ''cpgaray

        'If dtTable.Rows(0).Item("MedControl") = "S" And dtMedControlado.Rows.Count = 0 Then
        '    VerificarMedicamentoAltoCosto = True
        'End If

        'If Not IsDBNull(dtTable.Rows(0).Item("AltoCosto")) > 1 And dtMedAltocos.Rows.Count = 0 Then
        '    VerificarMedicamentoAltoCosto = True
        'End If


        'If dgFormulacion.RowCount >= 1 And (dtMedAltocos.Rows.Count >= 1 Or dtMedControlado.Rows.Count >= 1) Then
        '    VerificarMedicamentoAltoCosto = True
        'End If




        'End If
    End Function


    Private Sub pnlMedicamentos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlMedicamentos.Click
        TxtScroll.Visible = True
        TxtScroll.Focus()
        TxtScroll.Visible = False
    End Sub

    Private Sub Panel1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel1.Click
        TxtScroll1.Visible = True
        TxtScroll1.Focus()
        TxtScroll1.Visible = False
    End Sub

    Private Function sendFormulaByMail(ByVal emalDestino As String, ByVal reportBytes As Byte(),
                        ByVal reportName As String, ByVal smtpServer As String,
                        ByVal rptContentType As String, ByVal strAsunto As String) As Boolean
        Dim mailEnviado As Boolean = False
        ''Llenado del objeto que contiene la informacion para el mensaje
        Dim mail As New MailData()
        ''direccion de destinatario

        mail.toMail.Add(New MailAddress(emalDestino))

        ''direccion de remitente
        mail.from = New MailAddress("info-Sophia@colsanitas.com")   ' larb
        'mail.from = New MailAddress("no_responder@colsanitas.com")    
        mail.subject = strAsunto



        mail.body = ""
        ''Prueba del reporte en una ruta por defecto
        'Dim fs As New FileStream("c:\" & reportName, FileMode.Create)
        'fs.Write(reportBytes, 0, reportBytes.Length)
        'fs.Close()

        ''crear un stream en memoria
        Dim strmMemory As New MemoryStream(reportBytes, 0, reportBytes.Length)
        ''Crea el contenido
        Dim content As New System.Net.Mime.ContentType(rptContentType)

        content.Name = reportName

        ''crear el attach para el envio del reporte
        Dim attach As New Attachment(strmMemory, content)
        ''atachar el objeto en el contenido del mail
        mail.attachmets.Add(attach)

        'enviar el mail
        Dim mSender As New MailSender(smtpServer, 25, SmtpDeliveryMethod.Network)

        mSender.sendMail(mail)

        mailEnviado = True

        Return mailEnviado
    End Function



    Private Sub txtnumero_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim objNumero As New Num2Words
        'If txtnumero.Text <> "" And txtnumero.Text <> "0" Then
        'objNumero.number = CDbl(txtnumero.Text)
        'txtCantidadLetras.Text = objNumero.monto
        'tbCantidadPrescripcion.Text = txtnumero.Text
        'tbCantidad.Text = txtnumero.Text
        'Else
        'txtCantidadLetras.Text = String.Empty
        'End If
    End Sub

    Private Sub btAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAgregar.Click

        Dim bError As Boolean = True
        Dim dtTable As New DataTable
        Dim strMedicamento As String
        Dim objBL As New BLBasicasGenerales
        Dim dtEntidad As DataTable
        Dim NumeroMedicamentos As Integer
        Dim objConseguirDatosS As New BLHistoriaBasica
        Dim dt As New DataTable
        Dim strJustificacionL As String = ""
        Dim BoolEsExcepcion As Boolean = False ''cpgaray Ctc's
        Dim dtCtc As New DataTable ''cpgaray Ctc's
        Dim frecuencia As Double
        Dim DosisXDia As Double
        Dim objfrmc_JustificaExcepcion As New frmc_JustificaExcepcion
        Dim pide_SISPRO As String
        Dim pag_SISPRO As String
        Dim cod_Sispro As String = ""
        Dim flag_pos As String = ""
        Dim flag_posCondicionado As Boolean


        'dtTable = dgFormulacion.DataSource

        'rmzaluda 2010-03-03 solicitado por jdarenas motivo comentario para que no realize validacion de nombres 

        'If tbCodMedicamento.Text.Trim.Length > 0 And cbMedicamento.Text.Trim.Length > 0 Then
        '    If objBL.ConsultarDescripcionItemPorCodigo(objConexion, CategoriaDatos.ProductosConvenio, tbCodMedicamento.Text.Trim, IIf(cbMedicamento.ConvenioMedicamento = True, "S", "N"), objGeneral.Sucursal, Me.tbCodEntidad.Text, objGeneral.Prestador).Trim.ToLower <> cbMedicamento.Text.Trim.ToLower Then
        '        MessageBox.Show("El Código y la Descripción del Medicamento Seleccionado no Coinciden." & vbCrLf & "Seleccione Nuevamente el Medicamento.", "Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        tbCodMedicamento.Focus()
        '        Exit Sub
        '    End If
        'End If
        If ValidarDatos() = False Then
            Exit Sub
        End If

        If tbCodEntidad.Text = "9988" And (objGeneral.Sucursal = "0139" Or objGeneral.Sucursal = "0138") Then
            If Me.lblUnidadPrescripcion.Text.Trim.Length = 0 Then
                MessageBox.Show("No es Posible Agregar el Medicamento sin Unidad de Prescripción.", "Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Information)
                tbCodMedicamento.Focus()
                Exit Sub
            End If
        End If

        dtEntidad = objConseguirDatosS.ConsultarTablasBasicas("genentid", objConexion, "nro_med_for,MaxEntregasFormulaCronicos,tip_entidad", "entidad='" & tbCodEntidad.Text & "'")
        If dtEntidad.Rows.Count > 0 Then
            NumeroMedicamentos = dtEntidad.Rows(0).Item("nro_med_for").ToString
            NumeroEntregas = IIf((dtEntidad.Rows(0).Item("MaxEntregasFormulaCronicos").ToString) = "", 0, dtEntidad.Rows(0).Item("MaxEntregasFormulaCronicos").ToString)
            objFormuExt.TipoEntidad = dtEntidad.Rows(0).Item("tip_entidad").ToString
        End If


        If dgFormulacion.Rows.Count > NumeroMedicamentos Then 'nro_med_for Me.cbEntidad.Items("nro_med_for")
            MessageBox.Show("No es Posible Agregar mas Medicamentos el maximo es " & NumeroMedicamentos, "Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbCodMedicamento.Focus()
            Exit Sub
        End If
        'rmzaldua 2017-03-27 control de dias de tratamiento en la formulacion en general
        'If txtDiasTrat.Text = 0 Or txtDiasTrat.Text = "" Then
        'MsgBox("debe digitar los dias de tratamiento", MsgBoxStyle.Information, "Formulación Externa")
        'Me.txtDiasTrat.Focus()
        'Exit Sub
        'End If


        dt = cbMedicamento.OrigenDeDatos
        If BoolMedControl = True Then

            ''cpgaray medicamentos de control 
            'If txttiempo.Text.Trim.Length = 0 Then
            'MsgBox("Por favor ingrese el tiempo", MsgBoxStyle.Exclamation)
            'txttiempo.Focus()
            'Exit Sub
            'End If
            'If txtnumero.Text.Trim.Length = 0 Then
            'MsgBox("Por favor ingrese el número", MsgBoxStyle.Exclamation)
            'txtnumero.Focus()
            'Exit Sub
            'End If

        End If
        If ValidarDatos() Then
            If strModificar = "" Then
                strMedicamento = cbMedicamento.Text.Trim
                ''/cuando es una fila nueva
                ''/cuando es una fila nueva
                'If tbCodEntidad.Text = "9991" Or tbCodEntidad.Text = "9089" Or tbCodEntidad.Text = "1002" Or tbCodEntidad.Text = "1003" Then
                'If VerificarMedicamentoAltoCosto(IIf(objFormuExt.EsNuevaFormula = True, 0, objFormuExt.NumeroFormulaActual)) Then
                'MessageBox.Show("No se posible mezclar medicamentos de control y/o de alto costo con medicamentos Corrientes.  Cree una nueva formula. ", "Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'tbCodMedicamento.Focus()
                'Exit Sub
                'End If
                'End If

                If VerificarMedicamento(IIf(objFormuExt.EsNuevaFormula = True, 0, objFormuExt.NumeroFormulaActual)) Then
                    ''Ctc Marzo 21 de 2012 cpgaray
                    ' If BLOrdenes.ConsultaExcepciones(tbCodEntidad.Text, tbCodMedicamento.Text) = True Then
                    '    MsgBox("El medicamento elegido es no POS por favor diligenciar la Justificación de Uso para CTC", MsgBoxStyle.Information)
                    '    BoolEsExcepcion = True
                    '    ' dtcmbFRE = txtDescripcionFreq.OrigenDeDatos
                    '    ' rows = dtcmbFRE.Select("descripcion='" & txtDescripcionFreq.Text & "'")
                    '    'frecuencia = CDbl(rows(0).Item("CadaNroHoras").ToString)

                    '    DosisXDia = CDbl(tbCantidadPrescripcion.Text) '' * (frecuencia / 24)

                    '    objfrmc_JustificaExcepcion.Mostrar(tbCodMedicamento.Text, frecuencia, objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision, objGeneral.Login, objConexion)
                    '    objfrmc_JustificaExcepcion.ShowDialog()
                    '    If objfrmc_JustificaExcepcion.dtCtc.Rows.Count = 0 Then
                    '        Exit Sub
                    '    Else
                    '        dtCtc = objfrmc_JustificaExcepcion.dtCtc
                    '    End If
                    'End If


                    Dim dtRow As DataRow
                    If objFormuExt.EsNuevaFormula = True And dgFormulacion.Rows.Count <= 0 Then
                        dtRow = objFormuExt.dtNroFormulas.NewRow
                        dtRow.Item("nro_formula") = 0
                        dtRow.Item("entidad") = tbCodEntidad.Text
                        dtRow.Item("des_entidad") = cbEntidad.Text
                        dtRow.Item("posic") = 1
                        dtRow.Item("man_conv_med") = IIf(cbMedicamento.ConvenioMedicamento = True, "S", "N")
                        blnNoNuevo = True
                        objFormuExt.dtNroFormulas.Rows.Add(dtRow)
                        dtRowViewAntesDeNuevo = Nothing
                        'llarias se agrega campo especialidad
                        dtRow("especialidad") = objGeneral.CodigoEspecialidad
                        'rmzaldua 2009-06-10
                        If objFormuExt.dtNroFormulas.Rows.Count = 1 Then
                            bsrMedicamentos.Position = objFormuExt.dtNroFormulas.Rows.Count
                        End If
                    End If

                    dtRow = dgFormulacion.DataSource.NewRow()

                    dtRow("cod_pre_sgs") = objGeneral.Prestador
                    dtRow("cod_sucur") = objGeneral.Sucursal
                    dtRow("producto") = tbCodMedicamento.Text
                    dtRow("tip_doc") = objPaciente.TipoDocumento
                    dtRow("Num_doc") = objPaciente.NumeroDocumento
                    dtRow("entidad") = tbCodEntidad.Text
                    dtRow("des_entidad") = cbEntidad.Text
                    dtRow("medico") = objGeneral.Login
                    'llarias se agrega campo especialidad
                    dtRow("especialidad") = objGeneral.CodigoEspecialidad
                    dtRow("nroautoriza") = 0
                    dtRow("dosis") = CDbl(Me.txtDosis.Text)
                    dtRow("cada") = 0
                    dtRow("tiempo") = 0
                    dtRow("estado") = "P"
                    dtRow("pais") = objGeneral.Pais
                    dtRow("departamen") = objGeneral.Departamento
                    dtRow("ciudad") = objGeneral.Ciudad
                    dtRow("login") = objGeneral.Login
                    dtRow("Descripcion") = strMedicamento
                    'dtRow("prescripcion") = Trim(tbPrescripcion.Text)
                    dtRow("prescripcion") =
                            Trim(Me.txtDosis.Text) & " " & Me.txtDescripcionUM.Text & " " & Me.txtDescripcionVA.Text & " " & Me.txtDescripcionFreq.Text & " por " & Trim(txtDiasTrat.Text) & " dia(s). " & txtObs.Text
                    'dtRow("cantidadDispensacion") = Trim(tbCantidad.Text)
                    If tbCantidadPrescripcion.Enabled = True Then
                        dtRow("cantidad") = CDbl(Trim(txtDosis.Text))
                        dtRow("cantidadDispensacion") = CDbl(Trim(Me.tbCantidadPrescripcion.Text))
                    Else
                        dtRow("cantidad") = CDbl(Trim(Me.txtDosis.Text))
                        dtRow("cantidadDispensacion") = 0
                    End If
                    dtRow("UnidadDispensacion") = lblUnidadDispensacion.Text
                    dtRow("adicionado") = "S"
                    'dtRow("justificacion_Excep") = strJustificacionL ''cpgaray Ctc's Marzo 27 2012
                    ''Campos para manejo de cronicos
                    'dtRow("Cronico") = IIf(chkCronico.Checked, "S", "N")
                    dtRow("Cronico") = IIf(UsoCheckCronico.Checked, "S", "N")

                    ''Si la formula es aguda el numero de entregas por defecto es 1
                    ''Cambio autorizado por Norma Jimeno
                    If UsoCheckCronico.Checked Then
                        ' dtRow("DuracionTrat") = IIf(tbDuracion.Text.Trim.Length > 0, tbDuracion.Text.Trim, 0)
                        ' tbDuracion.Enabled = False
                    Else
                        ' dtRow("DuracionTrat") = 1
                    End If

                    dtRow("Tratamiento") = Nothing  ''Medicamento iniciado
                    dtRow("nro_formula") = IIf(objFormuExt.EsNuevaFormula = True, 0, objFormuExt.NumeroFormulaActual)
                    dtRow("uni_med_pedido") = lblCodUnidadPrescripcion.Text
                    dtRow("UnidadDePrescripcion") = lblUnidadPrescripcion.Text
                    dtRow("uni_med_dispensacion") = lblCodUnidadDispensacion.Text
                    dtRow("ViaAdministra") = IIf(Me.txtDescripcionVA.SelectedValue = "", DBNull.Value, Me.txtDescripcionVA.SelectedValue)
                    'dtRow("uni_med_pedido") = IIf(Me.txtDescripcionUM.SelectedValue = "", DBNull.Value, Me.txtDescripcionUM.SelectedValue)
                    dtRow("UniMedDosisCon") = IIf(Me.txtDescripcionUM.SelectedValue = "", DBNull.Value, Me.txtDescripcionUM.SelectedValue)
                    'dtRow("UniMedDosis") = IIf(Me.txtDescripcionUM.SelectedValue = "", DBNull.Value, Me.txtDescripcionUM.SelectedValue)
                    dtRow("Frecuencia") = IIf(Me.txtDescripcionFreq.SelectedValue = "", DBNull.Value, Me.txtDescripcionFreq.SelectedValue)
                    dtRow("CantTotalLetras") = IIf(lblletras.Text = "", "0.00 (CERO)" & lblUnidadPrescripcion.Text, Me.tbCantidadPrescripcion.Text & " (" & lblletras.Text & ") " & lblUnidadPrescripcion.Text)
                    'dtRow("AltoCosto") = IIf(AltoCosto = True, "S", "N")
                    dtRow("cantidadcontrol") = 0
                    'dtRow("cantidadDispensacion") = IIf(Me.tbCantidadPrescripcion.Text = "", DBNull.Value, Me.tbCantidadPrescripcion.Text)
                    dtRow("obs") = Me.txtObs.Text

                    ''cpgaray
                    If BoolMedControl Then
                        'dtRow("tiempomedcontrol") = txttiempo.Text
                        dtRow("tiempomedcontrol") = CDbl(txtDiasTrat.Text)
                        dtRow("cantidadcontrol") = tbCantidadPrescripcion.Text
                        dtRow("cantidadletrascontrol") = lblletras.Text
                        dtRow("MedControl") = "S"
                    Else
                        dtRow("tiempomedcontrol") = CDbl(txtDiasTrat.Text)
                        dtRow("MedControl") = "N"
                    End If
                    ''fin cpgaray


                    If BoolEsExcepcion = True Then
                        ''ctc Noviembre 27 de 2012

                        dtRow("cod_corto") = dtCtc.Rows(0).Item("cod_corto")
                        dtRow("concentracionEq") = dtCtc.Rows(0).Item("concentracion")
                        dtRow("for_farma") = dtCtc.Rows(0).Item("for_farma")
                        dtRow("diasTratamiento") = dtCtc.Rows(0).Item("diasTratamiento")
                        dtRow("DosisXDia") = dtCtc.Rows(0).Item("DosisXDia")
                        dtRow("DosisXDiaNoPos") = DosisXDia
                        dtRow("fec_desde") = dtCtc.Rows(0).Item("fec_desde")
                        dtRow("fec_hasta") = dtCtc.Rows(0).Item("fec_hasta")
                        dtRow("diagnost") = dtCtc.Rows(0).Item("diagnost")
                        dtRow("clasificacion") = dtCtc.Rows(0).Item("clasificacion")
                        dtRow("obsDiagn") = dtCtc.Rows(0).Item("obs")
                        dtRow("Justificacion") = dtCtc.Rows(0).Item("Justificacion")
                        dtRow("especialidad") = objGeneral.CodigoEspecialidad
                    End If

                    Dim strGenExcep As Boolean
                    Dim strGenCTC_MP As String

                    strGenExcep = False
                    strGenCTC_MP = "N"

                    pide_SISPRO = daoGeneral.EjecutarSQLStrValor("gensucur (nolock)", objConexion, " pide_SISPRO", " cod_sucur='" & objGeneral.Sucursal & "'")
                    pag_SISPRO = daoGeneral.EjecutarSQLStrValor("pargener (nolock)", objConexion, " pagsispro", " cod_pre_sgs='" & objGeneral.Prestador & "'")
                    flag_pos = daoGeneral.EjecutarSQLStrValor("genprodu (nolock)", objConexion, " flag_pos", " cod_corto='" & tbCodMedicamento.Text & "'")
                    If (flag_pos = Nothing) Then
                        flag_pos = "S"
                    End If

                    If objFormuExt.TipoEntidad = "PRE" Then

                        strGenExcep = BLOrdenes.ConsultaExcepciones(objPaciente.Entidad, tbCodMedicamento.Text)

                        If strGenExcep Then

                            MsgBox("El medicamento Elegido no tiene cobertura para la  entidad " & objPaciente.DescripcionEntidad, MsgBoxStyle.Information)

                            strGenCTC_MP = BLOrdenes.PideCTCMP(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                    objPaciente.AnoAdmision, objPaciente.NumeroAdmision, tbCodMedicamento.Text)
                        End If
                    End If



                    If (objFormuExt.TipoEntidad = "EPS" Or strGenCTC_MP = "S") And pide_SISPRO = "S" Then
                        'flag_pos = IIf(IsDBNull(dtProductoElegido.Item("flag_pos").ToString), "S", dtProductoElegido.Item("flag_pos").ToString)
                        If flag_pos = "N" Then
                            'If Me.txtDiasTrat.Text < 1 Then
                            'MsgBox("debe digitar los dias de tratamiento", MsgBoxStyle.Information, "Medicamentos y Líquidos Endovensoso")
                            'Me.txtDiasTrat.Focus()
                            'Exit Sub
                            'End If
                            flag_posCondicionado = BLOrdenes.existePosCondicionado(objConexion, objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision, "M", tbCodMedicamento.Text)
                            If flag_posCondicionado = True Then
                                cod_Sispro = "POS Condicionado"
                                MsgBox("El elemento prescrito es POS Condicionado por Diagnóstico", MsgBoxStyle.Information)
                            Else
                                System.Diagnostics.Process.Start(pag_SISPRO)
                                frm_SISPRO.txt_SISPRO.MaxLength = 20
                                frm_SISPRO.Mostrar(cod_Sispro)
                                cod_Sispro = frm_SISPRO.Cod_SISPRO1
                            End If
                            dtRow("diastrat") = Me.txtDiasTrat.Text
                            dtRow("autoSISPRO") = cod_Sispro
                        Else
                            If Len(Me.txtDiasTrat.Text) > 0 Then
                                dtRow("diastrat") = Me.txtDiasTrat.Text
                            Else
                                dtRow("diastrat") = 0
                            End If
                            dtRow("autoSISPRO") = ""
                        End If
                    Else
                        'BoolEsExcepcion = False
                        If Len(Me.txtDiasTrat.Text) > 0 Then
                            dtRow("diastrat") = Me.txtDiasTrat.Text
                        Else
                            dtRow("diastrat") = 0
                        End If
                        dtRow("autoSISPRO") = ""
                    End If

                    'dtTable.Rows.Add(dtRow)
                    dgFormulacion.DataSource.Rows.Add(dtRow)


                    '/inicializar controles \
                    strModificar = ""
                    tbCodEntidad.Enabled = False
                    cbEntidad.Enabled = False

                    ''Inhabilitar el check cronico pues toda la orden es crinica
                    'If chkCronico.Checked Then
                    'chkCronico.Enabled = False
                    'tbDuracion.Enabled = False
                    'End If
                    limpiarPanelMedicamento()
                Else
                    MsgBox("Este medicamento ya existe, por favor seleccione otro", MsgBoxStyle.Exclamation)
                End If
            Else
                '/Cuando es modificación

                If dgFormulacion.CurrentRow.Cells("MedControl").Value.ToString.Length > 0 And dgFormulacion.CurrentRow.Cells("MedControl").Value.ToString = "S" Then
                    dgFormulacion.CurrentRow.Cells("cantidadDispensacion").Value = Trim(tbCantidadPrescripcion.Text)
                    dgFormulacion.CurrentRow.Cells("Cantidad").Value = Trim(txtDosis.Text)
                Else
                    dgFormulacion.CurrentRow.Cells("cantidadDispensacion").Value = 0
                    dgFormulacion.CurrentRow.Cells("Cantidad").Value = Trim(txtDosis.Text)
                End If

                dgFormulacion.CurrentRow.Cells("Prescripcion").Value = Trim(Me.txtDosis.Text) & " " & Me.txtDescripcionUM.Text & " " & Me.txtDescripcionVA.Text & " " & Me.txtDescripcionFreq.Text & " por " & Trim(txtDiasTrat.Text) & " dia(s). " & txtObs.Text
                dgFormulacion.CurrentRow.Cells("obs").Value = txtObs.Text
                dgFormulacion.CurrentRow.Cells("Cronico").Value = IIf(UsoCheckCronico.Checked, "S", "N")
                dgFormulacion.CurrentRow.Cells("DuracionTrat").Value = IIf(txtDiasTrat.Text.Trim.Length > 0, txtDiasTrat.Text.Trim, 0)

                dgFormulacion.CurrentRow.Cells("dosis").Value = IIf(txtDosis.Text.Trim.Length > 0, txtDosis.Text.Trim, 0)
                dgFormulacion.CurrentRow.Cells("ViaAdministra").Value = IIf(Me.txtDescripcionVA.SelectedValue = "", DBNull.Value, Me.txtDescripcionVA.SelectedValue)
                dgFormulacion.CurrentRow.Cells("UniMedDosisCon").Value = IIf(Me.txtDescripcionUM.SelectedValue = "", DBNull.Value, Me.txtDescripcionUM.SelectedValue)
                dgFormulacion.CurrentRow.Cells("Frecuencia").Value = IIf(Me.txtDescripcionFreq.SelectedValue = "", DBNull.Value, Me.txtDescripcionFreq.SelectedValue)

                If dgFormulacion.CurrentRow.Cells("MedControl").Value.ToString.Length > 0 And dgFormulacion.CurrentRow.Cells("MedControl").Value.ToString = "S" Then
                    dgFormulacion.CurrentRow.Cells("cantidadcontrol").Value = tbCantidadPrescripcion.Text
                    dgFormulacion.CurrentRow.Cells("cantidadletrascontrol").Value = lblletras.Text
                    dgFormulacion.CurrentRow.Cells("CantTotalLetras").Value = IIf(lblletras.Text = "", DBNull.Value, Me.tbCantidadPrescripcion.Text & " (" & lblletras.Text & ") " & lblUnidadPrescripcion.Text)
                End If

                dgFormulacion.Update()

                '/inicializar controles \
                strModificar = ""
                limpiarPanelMedicamento()

                ''Inhabilitar el check cronico pues toda la orden es cronica
                'If chkCronico.Checked Then
                'chkCronico.Enabled = False
                'End If
            End If

            '/ Cargamos objeto \
            'objFormuExt.Estado = "N"
            'objFormuExt.dtFormulacion = dgFormulacion.DataSource
            btCancelar.Visible = False
            tbCodMedicamento.Enabled = True
            cbMedicamento.Enabled = True
            strJustificacionL = String.Empty
            If tbCodEntidad.Enabled = True Then
                tbCodEntidad.Focus()
            Else
                tbCodMedicamento.Focus()
            End If
        End If
    End Sub

    Private Sub btDispensacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDispensacion.Click
        Try
            If Len(objPaciente.TipoDocumento) <> 0 Or Len(objPaciente.NumeroDocumento) <> 0 Then
                frmDispMedicamentos.mostrar(objPaciente.TipoDocumento, objPaciente.NumeroDocumento)
                'frmDispMedicamentos.mostrar("CC", "51902085")
            Else
                MessageBox.Show("Datos Incompletos")
            End If

        Catch ex As Exception

        End Try
    End Sub

    'Private Sub txtDiasTrat_Validated(ByVal sender As Object, ByVal e As System.EventArgs)

    'diastrat = daoGeneral.EjecutarSQLStrValor("pargener (nolock)", objConexion, " diastrat", " cod_pre_sgs='" & objGeneral.Prestador & "'")
    'If Me.txtDiasTrat.Text = "" Then
    'Me.txtDiasTrat.Text = 0
    'End If
    'If diastrat < Me.txtDiasTrat.Text Then
    'MsgBox("supera los dias de tratamiento a prescribir, esta parametrizado en:  " & diastrat, MsgBoxStyle.Information, "Administrador")
    'Me.txtDiasTrat.Text = diastrat
    'End If
    'End Sub


    Public Sub CargarUnidadMedida()
        With txtDescripcionUM
            .DataSource = BLOrdenes.consultarUnidadMedida(objConexion)
            .DisplayMember = "descripcion"
            .ValueMember = "concentracion"
            Try
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteCustomSource = CreateCustomSourceAutoComplete(.DataSource)
                .AutoCompleteSource = AutoCompleteSource.CustomSource
                .ResetText()
                .SelectedValue = vbNull
            Catch ex As Exception
                MsgBox("Error al consultar la parametrización de unidad de medida.", MsgBoxStyle.Information)
            End Try
        End With
    End Sub
    ''' 
    Public Sub CargarFrecuencia()

        With txtDescripcionFreq
            .DataSource = BLOrdenes.consultarFrecuencia(objConexion)
            .DisplayMember = "descripcion"
            .ValueMember = "frecuencia"
            Try
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteCustomSource = CreateCustomSourceAutoComplete(.DataSource)
                .AutoCompleteSource = AutoCompleteSource.CustomSource
                .ResetText()
                .SelectedValue = vbNull
            Catch ex As Exception
                MsgBox("Error al consultar la parametrización de frecuencias.", MsgBoxStyle.Information)
            End Try
        End With

    End Sub
    Public Sub CargarViasAdministracion()
        With txtDescripcionVA
            .DataSource = BLOrdenes.consultarViasAdmin(objConexion)
            .DisplayMember = "descripcion"
            .ValueMember = "via"
            Try
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteCustomSource = CreateCustomSourceAutoComplete(.DataSource)
                .AutoCompleteSource = AutoCompleteSource.CustomSource
                .ResetText()
                .SelectedValue = vbNull
            Catch ex As Exception
                MsgBox("Error al consultar la parametrización de Vias de Administración.", MsgBoxStyle.Information)
            End Try
        End With
    End Sub

    Private Function CreateCustomSourceAutoComplete(ByVal DataSource As DataTable) As AutoCompleteStringCollection
        Dim instcol As AutoCompleteStringCollection = New AutoCompleteStringCollection()

        Dim consulta = (From recs In DataSource.AsEnumerable
                        Select recs("descripcion")).ToList()
        Try
            For Each item As String In consulta
                instcol.Add(item)
            Next

        Catch ex As Exception
            MessageBox.Show("No se logro crear el diccionario de autocompletar", "Sophia")
        End Try
        Return instcol

    End Function

    Private Sub dgtblInformativa_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgTblInformativa.CellValueChanged
        Dim fila As Int16 = e.RowIndex
        Dim temCod As Int32
        Dim mensajeValidacion As String = ""

        Dim TextoValidar As String = ""

        If fila = -1 Then 'para evitar que se genere el error de excepción
            Exit Sub
        End If

        If dgTblInformativa.Rows(fila).Cells(0).Value = 1 Then

        End If
    End Sub

    Private Sub dgTblInformativa_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTblInformativa.CellDoubleClick
        'dgtbInformativa_CellValueChanged(sender, e)
        'dtgMedicamentos_CellContentClick(sender, e)
    End Sub

    Private Sub txtDescripcionUM_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtDescripcionUM.SelectedIndexChanged
        lblUnidadPrescripcion.Text = txtDescripcionUM.Text.ToUpper
    End Sub

    Private Sub txtDiasTrat_Validated(sender As Object, e As EventArgs) Handles txtDiasTrat.Validated
        Dim daoPlanManejo As New DAOPlanManejo
        Dim diastratMin, diastratMax As Double
        Dim dtDiasTrat As DataTable

        dtDiasTrat = daoPlanManejo.EjecutarSPConsultarDiasTratOsi(objConexion, tbCodEntidad.Text)

        If dtDiasTrat.Rows.Count > 0 Then
            diastratMin = dtDiasTrat.Rows(0).Item("DiasTraMin").ToString
            diastratMax = dtDiasTrat.Rows(0).Item("DiastratMax").ToString
        End If
        If Val(Me.txtDiasTrat.Text) > 0 Then
            If CDbl(IIf(Me.txtDiasTrat.Text = "", 0, Me.txtDiasTrat.Text)) < diastratMin Or CDbl(IIf(Me.txtDiasTrat.Text = "", 0, Me.txtDiasTrat.Text)) > diastratMax Then
                Me.txtDiasTrat.Text = ""
                Me.txtDiasTrat.Focus()
                MessageBox.Show("Supera los días de tratamiento a prescribir", "Sophia")
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        tbCantidadPrescripcion.Enabled = False
    End Sub

    Private Sub txtDosis_Leave(sender As Object, e As EventArgs) Handles txtDescripcionUM.Leave, txtDescripcionVA.Leave, txtDiasTrat.Leave, txtDescripcionFreq.Leave, txtDosis.Leave, txtObs.Leave
        Try
            Dim control = TryCast(sender, TextBox)
            If control Is Nothing Then
                control = TryCast(sender, ComboBox)
            End If

            If control.Visible And control.Enabled Then
                If control.Name = "txtDescripcionFreq" Then
                    Dim valor As String = control.Text
                    Dim index As Integer = control.FindString(valor)
                    If index < 0 Then
                        control.Text = String.Empty
                    End If
                End If

                If control.Text.Trim.Length < 1 Then
                    control.BackColor = Color.LightPink
                    If control.Name = "txtDiasTrat" Then
                        'MessageBox.Show("Debe diligenciar los días de Tratamiento")
                        'control.Focus()
                    End If
                    Exit Sub
                Else
                    control.BackColor = SystemColors.Window
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtDescripcionUM_Leave(sender As Object, e As EventArgs) Handles txtDescripcionVA.Leave, txtDescripcionUM.Leave
        ValidarTexto(sender, (DirectCast(sender, ComboBox)).Text)
    End Sub
    Private Sub ValidarTexto(ByRef cboLista As Object, ByVal valor As String)
        Dim listaItems As DataTable = (DirectCast(cboLista, ComboBox)).DataSource
        If ((listaItems.Select(String.Format("descripcion ='{0}'", valor))).Count < 1) Then
            DirectCast(cboLista, ComboBox).ResetText()
            '            DirectCast(cboLista, ComboBox).Focus()
        End If
    End Sub

    Private Sub txtDescripcionVA_Leave(sender As Object, e As EventArgs) Handles txtDescripcionVA.Leave
        ValidarTexto(sender, (DirectCast(sender, ComboBox)).Text)
    End Sub

    Private Sub txtDosis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDosis.KeyPress


        '
        Dim tb As TextBox = DirectCast(sender, TextBox)



        ' Carácter separador decimal existente actualmente
        ' en la configuración regional de windows. 
        ' 
        Dim separadorDecimal As String =
           Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator





        If ((e.KeyChar = "."c) OrElse (e.KeyChar = ","c)) Then
            ' Si en el control hay ya escrito un separador decimal, 
            ' deshechamos insertar otro separador más. 
            ' 
            If (tb.Text.IndexOf(separadorDecimal) >= 0) And Not (tb.SelectionLength <> 0) Then
                e.Handled = True
                Return

            Else
                If ((tb.TextLength = 0) OrElse (tb.SelectionLength > 0) OrElse
                      ((tb.TextLength = 1) And (tb.Text.Chars(0) = "-"c))) Then
                    ' Si no hay ningún número, insertamos un cero
                    ' antes del separador decimal.
                    tb.SelectedText = "0"
                End If

                ' Insertamos el separador decimal. 
                '
                e.KeyChar = CChar(separadorDecimal)
                Return
            End If
        End If

        If (Convert.ToInt32(e.KeyChar) = 8) Then
            ' Se ha pulsado la tecla retroceso 
            Return

        ElseIf (e.KeyChar = "-"c) Then
            ' Únicamente si no está seleccionado el texto del control 
            If (tb.SelectionLength = 0) Then
                ' Si en el control hay ya escrito un signo menos, 
                ' deshechamos todos los que posteriormente se escriban 
                If (tb.Text.IndexOf("-"c) >= 0) Then
                    e.Handled = True
                    Return
                End If

                ' Solo permito el signo menos si aparece en primera posición 
                '
                e.Handled = (tb.SelectionStart <> 0)
            End If

        ElseIf (Not (Char.IsDigit(e.KeyChar))) Then
            ' No se ha pulsado un dígito. 
            e.Handled = True
            Return

        End If

        ' Si existe el separador decimal, no permitimos que
        ' se escriban más de dos números decimales.
        '
        Dim index As Integer = tb.Text.IndexOf(separadorDecimal)

        If (index >= 0) Then
            Dim decimales As String = tb.Text.Substring(index + 1)
            e.Handled = (decimales.Length = 2)
        End If

        ' Si el texto del control actualmente está seleccionado, 
        ' permitimos que se pueda reemplazar por el carácter tecleado.
        '
        Dim index1 As Integer = tb.Text.IndexOf(separadorDecimal)


        If (index1 <= 0) Then
            If (tb.TextLength) > 9 Then

                e.Handled = True
                Return


            End If
        End If

        If (tb.SelectionLength > 0) Then e.Handled = False
    End Sub

    Private Sub ActivarEditarCombos(ByVal dr As DataGridViewRow)

        Dim dtcmbUM As New DataTable
        Dim dtcmbVA As New DataTable
        Dim dtcmbFRE As New DataTable
        Dim rows() As DataRow

        dtcmbUM = txtDescripcionUM.DataSource
        rows = dtcmbUM.Select("concentracion='" & dr.Cells("UniMedDosisCon").Value.ToString & "'")
        If rows.Length = 0 Then
            txtDescripcionUM.Text = ""
        Else
            If Not IsDBNull(rows(0).Item("descripcion").ToString) Then
                txtDescripcionUM.Text = rows(0).Item("descripcion").ToString
            End If
        End If

        dtcmbVA = txtDescripcionVA.DataSource
        rows = dtcmbVA.Select("via='" & dr.Cells("ViaAdministra").Value.ToString & "'")
        If rows.Length = 0 Then
            txtDescripcionVA.Text = ""
        Else
            If Not IsDBNull(rows(0).Item("descripcion").ToString) Then
                txtDescripcionVA.Text = rows(0).Item("descripcion").ToString
            End If
        End If

        dtcmbFRE = txtDescripcionFreq.DataSource
        rows = dtcmbFRE.Select("frecuencia='" & dr.Cells("Frecuencia").Value.ToString & "'")
        If rows.Length = 0 Then
            txtDescripcionFreq.Text = ""
        Else
            If Not IsDBNull(rows(0).Item("descripcion").ToString) Then
                txtDescripcionFreq.Text = rows(0).Item("descripcion").ToString
            End If
        End If
    End Sub

    Private Sub dgFormulacion_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgFormulacion.CellClick
        If e.ColumnIndex > 0 Then
            limpiarPanelMedicamento()
            Exit Sub
        End If

        If dgFormulacion.DataSource Is Nothing Then
            Exit Sub
        Else
            If dgFormulacion.DataSource.Rows.Count <= 0 Then
                Exit Sub
            End If
        End If

        EditarFormulacionExterna(sender.CurrentRow)
        tbCodEntidad.Enabled = False
        cbEntidad.Enabled = False
        tbCodMedicamento.Enabled = True
        cbMedicamento.Enabled = True
        strModificar = ""

    End Sub

    Private Sub tbCantidadPrescripcion_Validated(sender As Object, e As EventArgs) Handles tbCantidadPrescripcion.Validated
        Dim objNumero As New Num2Words
        'If tbCantidadPrescripcion.Text = "0" Then
        'lblletras.Text = "CERO"
        'Else
        If tbCantidadPrescripcion.Text <> "" And CDbl(tbCantidadPrescripcion.Text) >= 0.1 Then
            objNumero.number = CDbl(tbCantidadPrescripcion.Text)
            lblletras.Text = objNumero.monto_decimal
            Me.txtLetras.Text = lblletras.Text
        Else
            lblletras.Text = String.Empty
            Me.txtLetras.Text = String.Empty
            tbCantidadPrescripcion.Focus()
        End If
        ' Else
        ' lblletras.Text = String.Empty
        ' End If
    End Sub

    Private Sub tbCantidadPrescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbCantidadPrescripcion.KeyPress
        '
        Dim tb As TextBox = DirectCast(sender, TextBox)

        ' Carácter separador decimal existente actualmente
        ' en la configuración regional de windows. 
        ' 
        Dim separadorDecimal As String =
           Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator

        If ((e.KeyChar = "."c) OrElse (e.KeyChar = ","c)) Then
            ' Si en el control hay ya escrito un separador decimal, 
            ' deshechamos insertar otro separador más. 
            ' 
            If (tb.Text.IndexOf(separadorDecimal) >= 0) And Not (tb.SelectionLength <> 0) Then
                e.Handled = True
                Return

            Else
                If ((tb.TextLength = 0) OrElse (tb.SelectionLength > 0) OrElse
                      ((tb.TextLength = 1) And (tb.Text.Chars(0) = "-"c))) Then
                    ' Si no hay ningún número, insertamos un cero
                    ' antes del separador decimal.
                    tb.SelectedText = "0"
                End If

                ' Insertamos el separador decimal. 
                '
                e.KeyChar = CChar(separadorDecimal)
                Return
            End If
        End If

        If (Convert.ToInt32(e.KeyChar) = 8) Then
            ' Se ha pulsado la tecla retroceso 
            Return

        ElseIf (e.KeyChar = "-"c) Then
            ' Únicamente si no está seleccionado el texto del control 
            If (tb.SelectionLength = 0) Then
                ' Si en el control hay ya escrito un signo menos, 
                ' deshechamos todos los que posteriormente se escriban 
                If (tb.Text.IndexOf("-"c) >= 0) Then
                    e.Handled = True
                    Return
                End If

                ' Solo permito el signo menos si aparece en primera posición 
                '
                e.Handled = (tb.SelectionStart <> 0)
            End If

        ElseIf (Not (Char.IsDigit(e.KeyChar))) Then
            ' No se ha pulsado un dígito. 
            e.Handled = True
            Return

        End If

        ' Si existe el separador decimal, no permitimos que
        ' se escriban más de dos números decimales.
        '
        Dim index As Integer = tb.Text.IndexOf(separadorDecimal)

        If (index >= 0) Then
            Dim decimales As String = tb.Text.Substring(index + 1)
            e.Handled = (decimales.Length = 2)
        End If

        ' Si el texto del control actualmente está seleccionado, 
        ' permitimos que se pueda reemplazar por el carácter tecleado.
        '
        Dim index1 As Integer = tb.Text.IndexOf(separadorDecimal)

        If (index1 <= 0) Then
            If (tb.TextLength) > 9 Then
                e.Handled = True
                Return
            End If
        End If

        If (tb.SelectionLength > 0) Then e.Handled = False
    End Sub
    Private Function ValidarDatosHisBasica() As Boolean

        Dim AdmDestino As String
        AdmDestino = objGeneral.ValidadAdmTrasladada(objConexion, objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                              objPaciente.AnoAdmision, objPaciente.NumeroAdmision)

        If AdmDestino <> objPaciente.TipoAdmision.ToString & "-" &
                                              objPaciente.AnoAdmision.ToString & "-" & objPaciente.NumeroAdmision.ToString Then

            MessageBox.Show("El paciente ha sido trasladado a está  admisión " & AdmDestino &
                                        ", debe buscarlo en la Lista de Espera.", "Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Information)
            frmHistoriaPrincipal.pintarMenu(frmHistoriaPrincipal.OpcionesMenu.ListaEspera)
            frmHistoriaPrincipal.CargarListaEspera()
            Return True

        End If
    End Function

    Private Sub txtDescripcionUM_SelectedValueChanged(sender As Object, e As EventArgs) Handles txtDescripcionUM.SelectedValueChanged
        lblUnidadPrescripcion.Text = txtDescripcionUM.Text.ToUpper
    End Sub
End Class

