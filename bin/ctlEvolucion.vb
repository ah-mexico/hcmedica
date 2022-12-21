Imports System.Linq
Imports System.Collections.Generic
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports HistoriaClinica.Sophia.HistoriaClinica.BL


''' <summary>
''' Clase ctlEvolucion del namespace Sophia.HistoriaClinica.ctlEvolucion que 
''' es la clase base. Esta clase tiene la funcionalidad del control de usuario para  
''' la evolución y será usado en la aplicación cliente en Windows Form 2005 
''' </summary>
''' <remarks></remarks>
''' 

Public Class ctlEvolucion
    Private Shared _Instancia As ctlEvolucion
    Private objGeneral As Generales
    Private objPaciente As Paciente
    Private objConexion As Conexion
    Private objEvolucion As Evolucion
    Private TipoEvolucion As Integer
    Dim resPre1 As String = ""
    Dim resPre2 As String = ""
    Dim modPlanManj As String = ""
    Public txtPlanManejogotfocus As Boolean = False
    Public SeGuardoEvolucion As Boolean = True
    Private objDescrQx As DescripcionQuirurgica
    Private objQx As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAODescripcionQX
    Private objEvolucion1 As New HistoriaClinica.Sophia.HistoriaClinica.Reportes.Evolucion
    Private objQxManejaDatos As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAODescripcionQXManejoDeDatos
    Private strCirujanoInvitado As String = ""
    Private strClasifiDiagn As String = ""
    Private strNameControlLoad As String = ""
    Private blnCtlEvolucion As Boolean = False
    Private blnCtlDescQx As Boolean = False
    Public ctlDescrQx As ctlDescripcionQuirurgica
    Private strmedico As String
    Private strmotivo As String
    Public strvar As Integer
    Private strEspecialidad As String 'martovar especialidad medico 
    Private strDatoModificadoEvo As String 'rmzaldua diagnostico evolucion
    Private strCadenaLocal As String
    Private AdmDestino As String


    Private _RangosValidos As String
    Public Property RangosValidos() As String
        Get
            Return _RangosValidos
        End Get
        Set(ByVal value As String)
            _RangosValidos = value
        End Set
    End Property

    Private _plstInterconsulta As New List(Of ProcedimientoOM)
    Public Property plstInterconsulta As List(Of ProcedimientoOM)
        Get
            Return _plstInterconsulta
        End Get
        Set(ByVal Value As List(Of ProcedimientoOM))
            _plstInterconsulta = Value
        End Set
    End Property

    Private _pInterconsulta As New ProcedimientoOM
    Public Property pInterconsulta As ProcedimientoOM
        Get
            Return _pInterconsulta
        End Get
        Set(ByVal Value As ProcedimientoOM)
            _pInterconsulta = Value
        End Set
    End Property

#Region "Instancia de Control"
    Public Shared ReadOnly Property Instancia() As ctlEvolucion
        Get
            If _Instancia Is Nothing Then
                _Instancia = New ctlEvolucion
            End If
            Return _Instancia
        End Get
    End Property
#End Region

    ''' <summary>
    ''' Opciones de Cargue Inicial del Control según el estado (N:Nuevo)
    ''' Trae La Fecha actual del Servidor
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
#Region "Load"
    Private Sub ctlEvolucion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objDescrQx = DescripcionQuirurgica.Instancia ''cpgaray


        objDescrQx = DescripcionQuirurgica.Instancia ''cpgaray
        objGeneral = Generales.Instancia
        objPaciente = Paciente.Instancia
        objConexion = Conexion.Instancia
        objEvolucion = Evolucion.Instancia
        strCadenaLocal = objGeneral.CadenaLocal
        ctlDescrQx = ctlDescripcionQuirurgica.Instancia

        Dim dtFecha As Date
        dtFecha = FuncionesGenerales.FechaServidor()
        'PFecha.Enabled = False
        mtFechaInicial.Text = Format(dtFecha, "dd/MM/yyyy HH:mm")
        'tbHora.Text = Hour(dtFecha)
        'tbMinuto.Text = Minute(dtFecha)
        tmHoraEvolucion.Interval = (60 - Second(dtFecha)) * 1000
        tmHoraEvolucion.Enabled = True
        frmHistoriaPrincipal.blnFirstEvolucion = False

        IniciarEvolucion()
        loadCombos()
        pnlContEvolucion.Visible = True
        ctlDiagnostico.Visible = True

        AdmDestino = objGeneral.ValidadAdmTrasladada(objConexion, objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                              objPaciente.AnoAdmision, objPaciente.NumeroAdmision)

        If AdmDestino <> objPaciente.TipoAdmision.ToString & "-" &
                                              objPaciente.AnoAdmision.ToString & "-" & objPaciente.NumeroAdmision.ToString Then

            MessageBox.Show("El paciente ha sido trasladada a la admisión " & AdmDestino &
                                        ", para un nuevo registro buscar el paciente en Lista de Espera.", "Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Information)
            frmHistoriaPrincipal.pintarMenu(frmHistoriaPrincipal.OpcionesMenu.ListaEspera)
            frmHistoriaPrincipal.CargarListaEspera()
            Exit Sub

        End If

        pnlDatosEF.Enabled = objEvolucion.ValidaEspecialidadSignoVital(objConexion, 0, objGeneral.CodigoEspecialidad)
        Me.ctlDiagnostico.LoadControl()

        If objPaciente.TipoAdmision <> "P" Then
            If ValidarFinalizarHcb() = False Then
                pnlContEvolucion.Visible = False
                ctlDescrQx.Visible = False
                ctlDiagnostico.Visible = False

                MessageBox.Show("Debe diligenciar primero Historia Básica de Ingreso del paciente")
                Exit Sub
            End If
        End If

        'CCGUTIEREZ. 07/05/2020 
        Me.rbInterconNP.Visible = False
        Me.rbInterconNP.Checked = False

    End Sub

    Public Sub VerInterconsultaNP()

        'CCGUTIEREZ. 04/05/2020 
        Dim strResidente As String
        Dim dtMedico As DataTable
        Dim objDAOGeneral As New DAOGeneral()

        dtMedico = objDAOGeneral.dtbMedicoResidente(objGeneral.Login.ToString())

        If dtMedico.Rows.Count > 0 Then
            strResidente = Convert.ToString(dtMedico.Rows(0).Item(23))
            If strResidente = "S" Or objGeneral.CodigoEspecialidad = "001" Or objGeneral.CodigoEspecialidad = "003" Or objGeneral.CodigoEspecialidad = "004" Or objGeneral.CodigoEspecialidad = "0028" Or objGeneral.CodigoEspecialidad = "069" Or objGeneral.CodigoEspecialidad = "083" Or objGeneral.CodigoEspecialidad = "704" Or objGeneral.CodigoEspecialidad = "705" Or objGeneral.CodigoEspecialidad = "901" Or objGeneral.CodigoEspecialidad = "903" Then
                Me.rbInterconNP.Visible = False
            Else
                Me.rbInterconNP.Visible = True
            End If
        End If
        '--Fin. CCGUTIEREZ 

    End Sub

    Private Sub IniciarEvolucion()
        Dim lError As Long
        Dim objBl As New Sophia.HistoriaClinica.BL.BLPlanManejo
        Dim dtEvolucion As New DataTable

        dtEvolucion = objBl.ConsultarEvolucion(objConexion)
        dvEvolucion.DataSource = dtEvolucion

        Me.LimpiarPantalla()

        ConsultarInterconsultas()

        If objEvolucion.Estado = "N" Then
            tbObjetivo.Text = objEvolucion.Objetivo
            tbParaclinicos.Text = objEvolucion.Paraclinico
            tbSubjetivo.Text = objEvolucion.Subjetivo
            tbPlanManejo.Text = objEvolucion.PlanManejo
            mtFechaInicial.Text = objEvolucion.Fecha
            txtTipoEvolucion.Focus()
            Me.dvEvolucion.Enabled = True
            Exit Sub
        End If

        'martovar 2014-09-19 se agrega validacion en caso de que el medico ingrese nuevamente se habilitan los campos 2.9.0
        If objEvolucion.Estado = "" Then
            RbEvolucion.Enabled = True
            'Rbinterconsulta.Enabled = True
            rbIngreso.Enabled = True
            Me.btGrabar.Enabled = True
            Me.btNuevo.Enabled = True
            Me.btImprimir.Enabled = True
        End If

        txtTipoEvolucion.Focus()

        If objGeneral.Pais = "482" Then
            txtCierrreInterconsulta.Text = "¿Usted realizo el proceso de interacción de medicamentos?."
        End If

        'End If
        'martovar 2014-09-19 se agrega validacion en caso de que el medico tenga especialidad Medicina General 2.9.0
        If objGeneral.CodigoEspecialidad = "001" Or objGeneral.CodigoEspecialidad = "003" Or objGeneral.CodigoEspecialidad = "004" Or objGeneral.CodigoEspecialidad = "0028" Or objGeneral.CodigoEspecialidad = "069" Or objGeneral.CodigoEspecialidad = "083" Or objGeneral.CodigoEspecialidad = "704" Or objGeneral.CodigoEspecialidad = "705" Or objGeneral.CodigoEspecialidad = "901" Or objGeneral.CodigoEspecialidad = "903" Then
            'Me.Rbinterconsulta.Enabled = False
        End If

    End Sub

    Private Sub loadCombos()
        'Cargar Informacion Inicial Examen Fisico   
        '/Para Estado Conciencia
        With txtCodEstadoConcienciaEF
            .NombreCampoBusqueda = "codigo"
            .NombreCampoBuscado = "descripcion"
            .ControlTextoEnlace = txtDescEstadoConcienciaEF
        End With
        With txtDescEstadoConcienciaEF
            .NombreCampoDatos = "descripcion"
            .ControlTextoEnlace = txtCodEstadoConcienciaEF
            .OrigenDeDatos = CrearDatosEstadoConciencia()
            .CargarDatosDescripcion()
        End With
    End Sub
    Public Sub loadSignosVitales()
        Dim oSignosVitales As New SignosVitales
        Dim lstSignosVitales As New List(Of SignosVitales)
        Dim lError As Long
        Dim strDescripcionIMC As String
        strDescripcionIMC = ""
        Try
            oSignosVitales.cod_pre_sgs = objGeneral.Prestador
            oSignosVitales.cod_sucur = objGeneral.Sucursal
            oSignosVitales.tip_admision = objPaciente.TipoAdmision
            oSignosVitales.ano_adm = objPaciente.AnoAdmision
            oSignosVitales.num_adm = objPaciente.NumeroAdmision

            lstSignosVitales = oSignosVitales.Get_SignosVitales(objConexion, lError, oSignosVitales)
            If lError > 0 Then
                MsgBox("No fue posible consultar los signos vitales.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("No fue posible consultar los signos vitales.", MsgBoxStyle.Exclamation)
            Exit Sub
        End Try
        If lstSignosVitales.Count > 0 And pnlDatosEF.Enabled Then
            If Trim(txtTemperaturaEF.Text).Length = 0 Then
                txtTemperaturaEF.Text = If(lstSignosVitales(0).temperatura > 0, lstSignosVitales(0).temperatura.ToString(), String.Empty)
            End If
            If Trim(txtPesoEF.Text).Length = 0 Then
                txtPesoEF.Text = If(Decimal.Round(lstSignosVitales(0).peso, 2) > Convert.ToDecimal(0), Decimal.Round(lstSignosVitales(0).peso, 2), String.Empty)
            End If
            If Trim(txtTallaEF.Text).Length = 0 Then
                txtTallaEF.Text = If(Decimal.Round(lstSignosVitales(0).talla, 2) > Convert.ToDecimal(0), Decimal.Round(lstSignosVitales(0).talla, 2), String.Empty)
            End If

            If Trim(txtTallaEF.Text).Length > 0 And Trim(txtPesoEF.Text).Length > 0 Then

                txtValorIMCEF.Text = FuncionesGenerales.CalcularIndiceDeMasaCorporal(Val(txtPesoEF.Text), Val(txtTallaEF.Text), strDescripcionIMC)
                txtDescValorIMCEF.Text = strDescripcionIMC
            Else
                txtValorIMCEF.ResetText()
                txtDescValorIMCEF.ResetText()
            End If

            If objPaciente.CodigoUnidadMedidaEdad = "A" And objPaciente.Edad < 16 And objPaciente.CodigoUnidadMedidaEdad <> "D" And objPaciente.CodigoUnidadMedidaEdad <> "M" Then
                txtValorIMCEF.ResetText()
                txtDescValorIMCEF.ResetText()
            End If

            If objPaciente.CodigoUnidadMedidaEdad <> "A" Then
                txtValorIMCEF.ResetText()
                txtDescValorIMCEF.ResetText()
            End If

        Else
            txtTemperaturaEF.Text = String.Empty
            txtPesoEF.Text = String.Empty
            txtTallaEF.Text = String.Empty
        End If
    End Sub
    Private Function CrearDatosEstadoConciencia() As DataTable

        Dim dtDatosEstadoConciencia As New DataTable

        dtDatosEstadoConciencia.Columns.Add("Codigo", System.Type.GetType("System.Int32"))
        dtDatosEstadoConciencia.Columns.Add("Descripcion", System.Type.GetType("System.String"))

        Dim dr As DataRow = dtDatosEstadoConciencia.NewRow()
        dr.Item("Codigo") = 1
        dr.Item("Descripcion") = "ALERTA"
        dtDatosEstadoConciencia.Rows.Add(dr)

        dr = dtDatosEstadoConciencia.NewRow()
        dr.Item("Codigo") = 2
        dr.Item("Descripcion") = "RESPONDE A VOZ"
        dtDatosEstadoConciencia.Rows.Add(dr)

        dr = dtDatosEstadoConciencia.NewRow()
        dr.Item("Codigo") = 3
        dr.Item("Descripcion") = "RESPONDE A DOLOR"
        dtDatosEstadoConciencia.Rows.Add(dr)

        dr = dtDatosEstadoConciencia.NewRow()
        dr.Item("Codigo") = 4
        dr.Item("Descripcion") = "INCONSCIENTE"
        dtDatosEstadoConciencia.Rows.Add(dr)

        dr = dtDatosEstadoConciencia.NewRow()
        dr.Item("Codigo") = 5
        dr.Item("Descripcion") = "CONFUSO"
        dtDatosEstadoConciencia.Rows.Add(dr)

        Return dtDatosEstadoConciencia

    End Function

#End Region

    ''' <summary>
    ''' Limpia Todos los controles del Control
    ''' </summary>
    ''' <remarks></remarks>
#Region "LimpiarPantalla"
    Public Sub LimpiarPantalla()

        '--CCGUTIEREZ
        rbInterconNP.Checked = False

        Cmbanalogadedolor.SelectedIndex = -1
        ctlDiagnostico.Enabled = False
        Me.btGrabar.Enabled = True
        Me.TipoEvolucion = 0
        pnlEvolucion.Enabled = False
        pnlTitDiaReg.Enabled = False
        RbEvolucion.Checked = False
        rbIngreso.Checked = False
        '--CCGUTIEREZ. 26/04/2020 
        rbInterconNP.Visible = False
        rbInterconNP.Checked = False
        rbtCierreIntConNo.Checked = False
        rbtCierreIntConSI.Checked = False
        rdPlaManPrg1No.Checked = False
        rdPlaManPrg1Si.Checked = False
        tbObjetivo.Enabled = True
        tbObjetivo.Text = ""
        tbObjetivo.BackColor = SystemColors.Window

        tbParaclinicos.Enabled = True
        tbParaclinicos.Text = ""
        tbParaclinicos.BackColor = SystemColors.Window

        tbPlanManejo.Enabled = True
        tbPlanManejo.Text = ""
        tbPlanManejo.BackColor = SystemColors.Window

        tbSubjetivo.Enabled = True
        tbSubjetivo.Text = ""
        tbSubjetivo.BackColor = SystemColors.Window

        txtAnalisis.Text = ""
        txtAnalisis.BackColor = SystemColors.Window

        txtCodEstadoConcienciaEF.ResetText()
        txtCodEstadoConcienciaEF.BackColor = SystemColors.Window

        txtDescEstadoConcienciaEF.ResetText()
        txtDescEstadoConcienciaEF.BackColor = SystemColors.Window

        txtDescValorIMCEF.ResetText()
        txtDescValorIMCEF.BackColor = SystemColors.Window

        txtDiastoleEF.ResetText()
        txtDiastoleEF.BackColor = SystemColors.Window

        txtFrecuenciaCardiacaEF.ResetText()
        txtFrecuenciaCardiacaEF.BackColor = SystemColors.Window

        txtFrecuenciaRespiratoriaEF.ResetText()
        txtFrecuenciaRespiratoriaEF.BackColor = SystemColors.Window

        txtPesoEF.ResetText()
        txtPesoEF.BackColor = SystemColors.Window

        txtSatOxi.ResetText()
        txtSatOxi.BackColor = SystemColors.Window

        txtSistoleEF.ResetText()
        txtSistoleEF.BackColor = SystemColors.Window

        txtTallaEF.ResetText()
        txtTallaEF.BackColor = SystemColors.Window

        txtTemperaturaEF.ResetText()
        txtTemperaturaEF.BackColor = SystemColors.Window

        txtTipoEvolucion.Text = ""  ''Claudia Garay
        'txtTipoEvolucion.BackColor = SystemColors.Window

        txtValorIMCEF.ResetText()

    End Sub
#End Region



#Region "Validaciones"

    Private Sub tmHoraEvolucion_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmHoraEvolucion.Tick
        Dim dtFecha As Date
        dtFecha = FuncionesGenerales.FechaServidor()
        mtFechaInicial.Text = Format(dtFecha, "dd/MM/yyyy HH:mm")
        'tbHora.Text = Hour(dtFecha)
        'tbMinuto.Text = Minute(dtFecha)
        tmHoraEvolucion.Interval = 60000
    End Sub

    'Private Sub tbDiagnostico_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbDiagnostico.Validated
    '    objEvolucion.Estado = "N"
    '    objEvolucion.Diagnostico = tbDiagnostico.Text
    'End Sub

    'Private Sub tbSubjetivo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbSubjetivo.Validated
    '    objEvolucion.Estado = "N"
    '    objEvolucion.Subjetivo = tbSubjetivo.Text
    'End Sub

    'Private Sub tbParaclinicos_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbParaclinicos.Validated
    '    objEvolucion.Estado = "N"
    '    objEvolucion.Paraclinico = tbParaclinicos.Text
    'End Sub

    'Private Sub tbObjetivo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbObjetivo.Validated
    '    objEvolucion.Estado = "N"
    '    objEvolucion.Objetivo = tbObjetivo.Text
    'End Sub

    'Private Sub tbPlanManejo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbPlanManejo.Validated
    '    objEvolucion.Estado = "N"
    '    objEvolucion.PlanManejo = tbPlanManejo.Text
    'End Sub
#End Region

#Region "ImprimirReporte"
    Public Sub ImprimirReporte(ByVal strFecha As String, ByVal intHora As Integer, ByVal intMinuto As Integer, ByVal strcierre As String) 'martovar 2.9.0 req.03 2014-08-08 generacion de interconsultas 
        'frmRepEvolucion.Show()
        Dim dteFecha As String
        If strFecha.Length > 0 Then
            dteFecha = strFecha
        Else
            dteFecha = ""
        End If
        frmRepEvolucion.Show()
        frmRepEvolucion.imprimirRepEvolucion(objConexion, objGeneral.Prestador, objGeneral.Sucursal,
                                            objPaciente.TipoAdmision, objPaciente.AnoAdmision,
                                            objPaciente.NumeroAdmision, dteFecha, intHora, intMinuto,
                                            objGeneral.Login, strcierre)

    End Sub
#End Region



    Private Sub ctlEvolucion_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        Dim objBl As New Sophia.HistoriaClinica.BL.BLPlanManejo
        Dim dtEvolucion As New DataTable
        Try

            If sender.Visible = True Then
                AdmDestino = objGeneral.ValidadAdmTrasladada(objConexion, objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                              objPaciente.AnoAdmision, objPaciente.NumeroAdmision)
                If AdmDestino <> objPaciente.TipoAdmision.ToString & "-" &
                                              objPaciente.AnoAdmision.ToString & "-" & objPaciente.NumeroAdmision.ToString Then

                    MessageBox.Show("El paciente ha sido trasladada a la admisión " & AdmDestino &
                                        ", para un nuevo registro buscar el paciente en Lista de Espera.", "Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    frmHistoriaPrincipal.pintarMenu(frmHistoriaPrincipal.OpcionesMenu.ListaEspera)
                    frmHistoriaPrincipal.CargarListaEspera()
                    Exit Sub

                End If

                If objPaciente.TipoAdmision <> "P" Then
                    If ValidarFinalizarHcb() = False Then
                        pnlContEvolucion.Visible = False
                        ctlDescrQx.Visible = False
                        ctlDiagnostico.Visible = False
                        MessageBox.Show("Debe diligenciar primero Historia Básica de Ingreso del paciente")
                        Exit Sub
                    End If
                End If

                pnlEvolucion.Enabled = True
                ctlDiagnostico.Enabled = True

                ConsultarInterconsultas()

                dtEvolucion = objBl.ConsultarEvolucion(objConexion)
                dvEvolucion.DataSource = dtEvolucion

                ctlDiagnostico.LoadControl()
                pnlContEvolucion.Visible = True
                ctlDiagnostico.Visible = True

                ctlDescrQx.Visible = False
                'pnlContenedor.Height = 1500

                If frmHistoriaPrincipal.blnFirstEvolucion = True Then
                    frmHistoriaPrincipal.blnFirstEvolucion = False
                End If
                If Me.TipoEvolucion = 0 Then
                    pnlEvolucion.Enabled = False
                    ctlDiagnostico.Enabled = False
                    pnlTitDiaReg.Enabled = False
                End If
                ConsultarInterconsultas()
                loadSignosVitales()

                'CCGUTIEREZ. 07/05/2020 
                Me.rbInterconNP.Visible = False
                Me.rbInterconNP.Checked = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LimpiarDatos()

        mtFechaInicial.ResetText()
        tbSubjetivo.ResetText()
        tbParaclinicos.ResetText()
        tbObjetivo.ResetText()
        tbPlanManejo.ResetText()

    End Sub



    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub rbIngreso_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbIngreso.Click
        If rbIngreso.Checked = True Then

            MostrarIngreso()
            For Each row As DataGridViewRow In dgvInterconsultas.Rows
                Dim cell As New DataGridViewCheckBoxCell
                cell = row.Cells(0)
                cell.Value = False
            Next
            ctlDiagnostico.ResetText()
            ctlDiagnostico.LoadControl()
        End If
    End Sub

    Private Sub RbEvolucion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbEvolucion.Click
        If RbEvolucion.Checked = True Then

            MostrarEvolucion()
            For Each row As DataGridViewRow In dgvInterconsultas.Rows
                Dim cell As New DataGridViewCheckBoxCell
                cell = row.Cells(0)
                cell.Value = False
            Next
            ctlDiagnostico.ResetText()
            ctlDiagnostico.LoadControl()
        End If
    End Sub
    ''Claudia Garay Acreditacion Noviembre 26 de 2010
    Public Sub MostrarIngreso()
        TipoEvolucion = Evolucion.TipoEvolucion.Ingreso
        pInterconsulta = New ProcedimientoOM

        pnlEvolucion.Enabled = True

        lblTitEvolucion.Text = "INGRESO"
        lblTipEvolucion.Text = "Nota de Ingreso"
        lblTipEvolucion.Visible = True
        txtTipoEvolucion.Visible = True
        lblTipEvolucion.Enabled = True
        txtTipoEvolucion.Enabled = True

        grbCerrarInterconsulta.Visible = False
        pnlEvolucion.Visible = True
        pnlTitDiaReg.Visible = True
        ctlDiagnostico.Visible = True
        pnlEvolucion.Enabled = True
        ctlDiagnostico.Enabled = True
        pnlTitDiaReg.Enabled = True
        loadSignosVitales()

    End Sub
    ''Claudia Garay Acreditacion Noviembre 26 de 2010
    Public Sub MostrarEvolucion()
        pInterconsulta = New ProcedimientoOM
        TipoEvolucion = Evolucion.TipoEvolucion.Evolucion

        lblTitEvolucion.Text = "EVOLUCIÓN"
        lblTipEvolucion.Text = "Evolución"
        pnlEvolucion.Enabled = True

        txtTipoEvolucion.Visible = False
        txtTipoEvolucion.Enabled = False
        Me.lblTipEvolucion.Visible = False
        grbCerrarInterconsulta.Visible = False
        pnlEvolucion.Visible = True
        pnlTitDiaReg.Visible = True
        ctlDiagnostico.Visible = True

        pnlEvolucion.Enabled = True
        pnlTitDiaReg.Enabled = True
        ctlDiagnostico.Enabled = True

        loadSignosVitales()

    End Sub

    Public Sub MostrarInterconsulta()
        TipoEvolucion = Evolucion.TipoEvolucion.Interconsulta

        pnlEvolucion.Enabled = True
        txtTipoEvolucion.Visible = False
        txtTipoEvolucion.Enabled = False
        Me.txtTipoEvolucion.Visible = True
        Me.lblTipEvolucion.Visible = True
        loadSignosVitales()

    End Sub

#Region "Grabar"


    Private Sub btGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGrabar.Click

        Dim objBl As New Sophia.HistoriaClinica.BL.BLPlanManejo
        Dim oSignosVitales As New SignosVitales
        Dim oEvolucion As New Evolucion
        Dim bError As Boolean = True
        Dim lError As Long
        Dim strError As String = ""
        Dim intHora As Integer
        Dim intMinuto As Integer
        Dim strFecha As String = FuncionesGenerales.FechaServidor()
        Dim strvarcierre As String = ""
        Dim daoOrden As New DAOOrdenes()
        AdmDestino = ""

        If ValidarCamposGrabacionEvolucion() Then
            Try

                Dim strexp_pla As String
                Dim strcon_med As String = ""
                Dim FechaIni As DateTime
                Dim FechaFin As DateTime
                Dim EstadoInterconsulta As Integer = Nothing

                If rdPlaManPrg1Si.Checked = True Then
                    strexp_pla = "S"
                ElseIf rdPlaManPrg1No.Checked = True Then
                    strexp_pla = "N"
                Else
                    strexp_pla = ""
                End If
                If rbtCierreIntConSI.Checked = True Then
                    EstadoInterconsulta = Evolucion.EstadoInterconsulta.Cerrada
                ElseIf rbtCierreIntConNo.Checked = True Then
                    EstadoInterconsulta = Evolucion.EstadoInterconsulta.PendienteCierre
                Else
                    EstadoInterconsulta = Nothing 'DBNull.Value
                End If

                ''Claudia Garay Septiembre 8 de 2011
                ''Auditoria de evoluciones

                Try
                    daoOrden.GrabarAuditOrdenes(objConexion, objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                    objPaciente.TipoDocumento & objPaciente.NumeroDocumento, objGeneral.Login, 0, 0,
                    0, 0, 0, "CLICK BOTON GUARDAR", "EV")
                Catch ex As Exception

                End Try
                ''Fin

                If rbtCierreIntConSI.Checked Then
                    strvarcierre = "S"
                ElseIf rbtCierreIntConNo.Checked Then
                    strvarcierre = "N"
                End If

                objEvolucion.COD_PRE_SGS = objGeneral.Prestador
                objEvolucion.COD_SUCUR = objGeneral.Sucursal
                objEvolucion.TIP_DOC = objPaciente.TipoDocumento
                objEvolucion.NUM_DOC = objPaciente.NumeroDocumento
                objEvolucion.TIP_ADMISION = objPaciente.TipoAdmision

                objEvolucion.ANO_ADM = objPaciente.AnoAdmision
                objEvolucion.NUM_ADM = objPaciente.NumeroAdmision
                objEvolucion.LOGIN = objGeneral.Login
                objEvolucion.Diagnostico = String.Empty
                objEvolucion.Objetivo = Trim(tbObjetivo.Text)

                objEvolucion.Paraclinico = Trim(tbParaclinicos.Text)
                objEvolucion.Analisis = Trim(txtAnalisis.Text)
                objEvolucion.PlanManejo = Trim(tbPlanManejo.Text)
                objEvolucion.Subjetivo = Trim(tbSubjetivo.Text)
                objEvolucion.NotasIngreso = IIf(TipoEvolucion = Evolucion.TipoEvolucion.Ingreso, Trim(txtTipoEvolucion.Text), "")
                objEvolucion.Fecha = strFecha

                objEvolucion.Hora = intHora
                objEvolucion.Minuto = intMinuto
                objEvolucion.exp_pla = strexp_pla
                objEvolucion.con_med = strcon_med
                objEvolucion.Interconsulta = IIf(TipoEvolucion = Evolucion.TipoEvolucion.Interconsulta, Trim(Me.txtTipoEvolucion.Text), "")

                objEvolucion.Especialidad = objGeneral.CodigoEspecialidad
                objEvolucion.Medico = Trim(strmedico)
                objEvolucion.Motivo = Trim(strmotivo)
                objEvolucion.Cierre = strvarcierre
                objEvolucion.EspecMedSol = Trim(strEspecialidad)

                objEvolucion.NroOrden = Me.pInterconsulta.NROORDEN

                '--Inicia. CCGUTIEREZ. 26/04/2020 
                'If Me.rbInterconNP.Checked Then
                '    objEvolucion.IdTipoEvolucion = Evolucion.TipoEvolucion.InterconsultaNP
                'Else
                '    objEvolucion.IdTipoEvolucion = Evolucion.TipoEvolucion.Interconsulta
                'End If
                'objEvolucion.IdTipoEvolucion = Me.TipoEvolucion

                '--Inicia. CCGUTIEREZ. 16/03/2021
                If Me.rbInterconNP.Checked And TipoEvolucion = Evolucion.TipoEvolucion.Interconsulta Then
                    objEvolucion.IdTipoEvolucion = Evolucion.TipoEvolucion.InterconsultaNP
                ElseIf TipoEvolucion = Evolucion.TipoEvolucion.Interconsulta Then
                    objEvolucion.IdTipoEvolucion = TipoEvolucion
                ElseIf TipoEvolucion = Evolucion.TipoEvolucion.Evolucion Then
                    objEvolucion.IdTipoEvolucion = TipoEvolucion
                Else
                    objEvolucion.IdTipoEvolucion = TipoEvolucion
                End If
                '--Fin. CCGUTIEREZ 

                objEvolucion.Procedimiento = Me.pInterconsulta.PROCEDIMIENTO
                lError = objEvolucion.GrabarEvolucion(objConexion, objEvolucion)

                If lError > 0 Then
                    strvar = 0
                    MsgBox("La evolución no se grabó, por favor verifique los datos", MsgBoxStyle.Exclamation)
                    objEvolucion.Estado = "N"
                    bError = True
                    LimpiarPantalla()
                    IniciarEvolucion()
                Else

                    Try

                        'For Each oDiagnostico As Diagnostico In olstdiag.ToList()
                        For Each oDiagnostico As Diagnostico In Me.ctlDiagnostico.plstDiagnostico.ToList()
                            oDiagnostico.CLASE_DIAG = FuncionesGenerales.EnumDescription(Diagnostico.ClaseDiagnostico.Evolucion)
                            oDiagnostico.ANTECEDENTE = "N"
                            oDiagnostico.CONFIDENCIAL = "N"
                            oDiagnostico.LOGIN = objGeneral.Login
                            lError = oDiagnostico.addDiagnostico(objConexion, lError, oDiagnostico)
                        Next
                    Catch ex As Exception
                        MsgBox("Se presentó un error guardando los Diagnósticos. " & ex.Message, MsgBoxStyle.Exclamation)
                    End Try
                    'End If

                    If pnlDatosEF.Enabled Then

                        oSignosVitales.cod_pre_sgs = objGeneral.Prestador
                        oSignosVitales.cod_sucur = objGeneral.Sucursal
                        oSignosVitales.tip_doc = objPaciente.TipoDocumento
                        oSignosVitales.Num_doc = objPaciente.NumeroDocumento
                        oSignosVitales.tip_admision = objPaciente.TipoAdmision
                        oSignosVitales.ano_adm = objPaciente.AnoAdmision
                        oSignosVitales.num_adm = objPaciente.NumeroAdmision
                        oSignosVitales.peso = FuncionesGenerales.ReemplazarString(Val(txtPesoEF.Text), 0, "0")
                        oSignosVitales.talla = FuncionesGenerales.ReemplazarString(Val(txtTallaEF.Text), 0, "0")
                        oSignosVitales.imc = FuncionesGenerales.ReemplazarString(Val(txtValorIMCEF.Text), 0, "0")
                        'oSignosVitales.P_Cefalico = 0
                        oSignosVitales.ta_dias = FuncionesGenerales.ReemplazarString(Val(txtDiastoleEF.Text), 0, "0")
                        oSignosVitales.ta_sist = FuncionesGenerales.ReemplazarString(Val(txtSistoleEF.Text), 0, "0")
                        oSignosVitales.temperatura = FuncionesGenerales.ReemplazarString(Val(txtTemperaturaEF.Text), 0, "0")
                        oSignosVitales.fre_cardiaca = FuncionesGenerales.ReemplazarString(Val(txtFrecuenciaCardiacaEF.Text), 0, "0")
                        oSignosVitales.fre_respira = txtFrecuenciaRespiratoriaEF.Text
                        oSignosVitales.fec_con = Format(CDate(strFecha), "yyyy/MM/dd")
                        oSignosVitales.login = objGeneral.Login
                        oSignosVitales.obs = ""
                        oSignosVitales.confidencial = ""
                        oSignosVitales.alerta = txtCodEstadoConcienciaEF.Text
                        'oSignosVitales.glasgow = 0
                        oSignosVitales.embriaguez = ""
                        'oSignosVitales.P_abdominal = 0
                        oSignosVitales.satoxi = FuncionesGenerales.ReemplazarString(Val(txtSatOxi.Text), 0, "0")
                        oSignosVitales.EAnaloga_dolor = Me.Cmbanalogadedolor.Text
                        oSignosVitales.ORIGEN = FuncionesGenerales.EnumDescription(SignosVitales.OrigenSV.Evolucion)
                        oSignosVitales.idEspecialidad = objGeneral.CodigoEspecialidad.ToString
                        Try
                            lError = oSignosVitales.Add_SignosVitales(objConexion, oSignosVitales)
                            If lError > 0 Then
                                strvar = 0
                                MsgBox("No fue posible guardar los signos vitales.", MsgBoxStyle.Exclamation)
                                objEvolucion.Estado = "N"
                                bError = True
                            End If

                            Dim FactorRiesgo As ctlDatosPaciente
                            FactorRiesgo = ctlDatosPaciente.Instancia
                            FactorRiesgo.PrenderAlarmasPac()

                        Catch ex As Exception
                            MsgBox("No fue posible guardar los signos vitales.", MsgBoxStyle.Exclamation)
                            strvar = 0
                            objEvolucion.Estado = "N"
                            bError = True
                        End Try

                    End If

                    If rbtCierreIntConSI.Checked And TipoEvolucion = Evolucion.TipoEvolucion.Interconsulta Then
                        pInterconsulta.IDESTADOINTERCONSULTA = ProcedimientoOM.EstadoProcedimientoOM.CERRADA
                        lError = pInterconsulta.addProcedimientoOM(objConexion, lError, pInterconsulta)
                    ElseIf rbtCierreIntConNo.Checked And TipoEvolucion = Evolucion.TipoEvolucion.Interconsulta Then
                        pInterconsulta.IDESTADOINTERCONSULTA = ProcedimientoOM.EstadoProcedimientoOM.PENDIENTE_CIERRE
                        lError = pInterconsulta.addProcedimientoOM(objConexion, lError, pInterconsulta)
                    End If

                    If lError > 0 Then
                        strvar = 0
                        MsgBox("No fue posible actualizar el estado de la Interconsulta.", MsgBoxStyle.Exclamation)
                        objEvolucion.Estado = "N"
                        bError = True
                    End If
                    strvar = 1
                    objGeneral.HistoriaClinicaTieneModificaciones = True
                    objEvolucion.Estado = "G"
                    'tbHora.Tag = intHora
                    'tbMinuto.Tag = intMinuto
                    LimpiarPantalla()
                    IniciarEvolucion()

                    resPre1 = ""
                    resPre2 = ""
                    modPlanManj = ""
                    'grpGenPrg.Visible = False

                    bError = False
                    'cambio realizado por Ing. Ricardo Mauricio Zaldúa C.
                    'fecha 2009-06-08
                    'solicitado por Enrique Forero 
                    'Motivo preguntar si desea imprimir el reporte 
                    FechaIni = Format(CDate(strFecha), "yyyy-MM-dd HH:mm")
                    FechaFin = Format(CDate(strFecha), "yyyy-MM-dd HH:mm")

                    If MessageBox.Show("Desea imprimir el documento?", "Historia Clinica", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        'cambio realizado por Ing. Ricardo Mauricio Zaldúa C.
                        'fecha 2009-05-19
                        'solicitado por Enrique Forero 
                        'Motivo primero limpiar el formulario y dejar de ultima la impresion para que aparezca en pantalla
                        'ImprimirReporte(Format(CDate(strFecha), "yyyy/MM/dd"), intHora, intMinuto, strvarcierre) 'MARTOVAR se envia variable para identificar si se cerro la interconsulta
                        ' se implementa reporte en Reporting Services.
                        RptHC.ImprimirEvolucion(objConexion, objGeneral.Prestador,
                                              objGeneral.Sucursal, objPaciente.TipoAdmision,
                                              objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                              objPaciente.TipoDocumento, objPaciente.NumeroDocumento,
                                              objGeneral.NombreMedico, objPaciente.CodHistoria,
                                              Format(CDate(FechaIni), "yyyy-MM-dd HH:mm"),
                                             Format(CDate(FechaFin), "yyyy-MM-dd HH:mm"))
                        RptHC.ShowDialog()
                        RptHC.Close()
                    End If
                    AdmDestino = objGeneral.ValidadAdmTrasladada(objConexion, objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision,
                                              objPaciente.AnoAdmision, objPaciente.NumeroAdmision)
                    If AdmDestino <> objPaciente.TipoAdmision.ToString & "-" &
                                              objPaciente.AnoAdmision.ToString & "-" & objPaciente.NumeroAdmision.ToString Then

                        MessageBox.Show("Su nota ha sido guardada, el paciente ha sido trasladada a la admisión " & AdmDestino &
                                        ", para un nuevo registro buscar el paciente en Lista de Espera.", "Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        frmHistoriaPrincipal.pintarMenu(frmHistoriaPrincipal.OpcionesMenu.ListaEspera)
                        frmHistoriaPrincipal.CargarListaEspera()
                        Exit Sub
                    End If
                End If

                Try
                    daoOrden.GrabarAuditOrdenes(objConexion, objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                    objPaciente.TipoDocumento & objPaciente.NumeroDocumento, objGeneral.Login, 0, 0,
                    0, 0, 0, "REGISTRO GRABADO ERROR:" & lError, "EV")
                Catch ex As Exception

                End Try

            Catch ex As Exception
                LimpiarPantalla()
                IniciarEvolucion()
                'MessageBox.Show("El proceso de grabación de la evolución falló por: " & ex.Message, "Historia Clínica", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
                MessageBox.Show("El proceso de grabación de la evolución falló. Por favor intente nuevamente.", "Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
            Me.TipoEvolucion = 0
            Me.ctlDiagnostico.plstDiagNuevos = New List(Of Diagnostico)
            Me.ctlDiagnostico.LoadControl()

        Else
            objEvolucion.Estado = "N"
            Exit Sub
        End If

        'Adicionar valores al objeto \
        If bError Then
            objEvolucion.Objetivo = tbObjetivo.Text
            'objEvolucion.Diagnostico = tbDiagnostico.Text
            objEvolucion.Paraclinico = tbParaclinicos.Text
            objEvolucion.PlanManejo = tbPlanManejo.Text
            objEvolucion.Subjetivo = tbSubjetivo.Text
            objEvolucion.NotasIngreso = txtTipoEvolucion.Text
            If rdPlaManPrg1Si.Checked = True Then
                objEvolucion.exp_pla = "S"
            ElseIf rdPlaManPrg1No.Checked = True Then
                objEvolucion.exp_pla = "N"
            Else
                objEvolucion.exp_pla = ""
            End If
            'If rbtCierreIntConSI.Checked = True Then
            '    objEvolucion.con_med = "S"
            'ElseIf rbtCierreIntConNo.Checked = True Then
            '    objEvolucion.con_med = "N"
            'Else
            objEvolucion.con_med = ""
            'End If
        Else
            objEvolucion.Objetivo = ""
            objEvolucion.Diagnostico = ""
            objEvolucion.Paraclinico = ""
            objEvolucion.PlanManejo = ""
            objEvolucion.Subjetivo = ""
            objEvolucion.Fecha = ""
            objEvolucion.NotasIngreso = ""
            objEvolucion.exp_pla = ""
            objEvolucion.con_med = ""
            resPre1 = ""
            resPre2 = ""
            modPlanManj = ""
            rdPlaManPrg1Si.Checked = False
            rdPlaManPrg1No.Checked = False
            rbtCierreIntConSI.Checked = False
            rbtCierreIntConNo.Checked = False
            rbInterconNP.Checked = False '--CCGUTIEREZ. 26/04/2020 
        End If
        'If (strvar = 1) Then
        'RbEvolucion.Enabled = False
        'Rbinterconsulta.Enabled = False
        'rbIngreso.Enabled = False
        'Me.btGrabar.Enabled = False
        'Me.btNuevo.Enabled = False
        'Me.btImprimir.Enabled = False
        'Me.txtTipoEvolucion.Enabled = False
        'Me.tbSubjetivo.Enabled = False
        'Me.tbObjetivo.Enabled = False
        'Me.tbParaclinicos.Enabled = False
        'Me.tbPlanManejo.Enabled = False
        'Me.tbDiagnostico.Enabled = False
        'Me.Txtinterconsulta.Enabled = False
        'Me.tbDiagnostico.Enabled = False
        'End If
    End Sub
#End Region



    Private Sub dtgEvolucion_Click(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles dvEvolucion.Click
        If dvEvolucion.DataSource Is Nothing Then
            Exit Sub
        Else
            If dvEvolucion.DataSource.Rows.Count <= 0 Then
                Exit Sub
            End If
        End If
        'EditarDatosEvolucion(sender.CurrentRow)
    End Sub



    Private Sub btNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNuevo.Click
        Me.LimpiarPantalla()
        Dim dtFecha As Date
        dtFecha = FuncionesGenerales.FechaServidor()
        'Me.PFecha.Enabled = False
        Me.mtFechaInicial.Text = Format(dtFecha, "dd/MM/yyyy HH:mm")
        'Me.'tbHora.Text = Hour(dtFecha)
        'Me.'tbMinuto.Text = Minute(dtFecha)
        Me.tmHoraEvolucion.Interval = (60 - Second(dtFecha)) * 1000
        Me.tmHoraEvolucion.Enabled = True
        Me.btImprimir.Enabled = False
        Me.btNuevo.Enabled = False
        Me.dvEvolucion.Enabled = True
        txtPlanManejogotfocus = False ''Claudia Garay Enero 17 de 2011
        txtTipoEvolucion.Focus()
        resPre1 = ""
        resPre2 = ""
        modPlanManj = ""
        rdPlaManPrg1Si.Checked = False
        rdPlaManPrg1No.Checked = False
        rbtCierreIntConSI.Checked = False
        rbtCierreIntConNo.Checked = False
        RbEvolucion.Enabled = True
        'Rbinterconsulta.Enabled = True
        rbIngreso.Enabled = True
        Me.txtTipoEvolucion.Enabled = True
        'Me.tbDiagnostico.Enabled = True
        '--CCGUTIEREZ. 25/04/2020
        rbInterconNP.Checked = False

        rbInterconNP.Checked = False '--CCGUTIEREZ. 26/04/2020  

        'martovar 2014-09-19 se agrega validacion en caso de que el medico tenga especialidad Medicina General 2.9.0
        If objGeneral.CodigoEspecialidad = "001" Or objGeneral.CodigoEspecialidad = "003" Or objGeneral.CodigoEspecialidad = "004" Or objGeneral.CodigoEspecialidad = "0028" Or objGeneral.CodigoEspecialidad = "069" Or objGeneral.CodigoEspecialidad = "083" Or objGeneral.CodigoEspecialidad = "704" Or objGeneral.CodigoEspecialidad = "705" Or objGeneral.CodigoEspecialidad = "901" Or objGeneral.CodigoEspecialidad = "903" Then
            'Me.Rbinterconsulta.Enabled = False
        End If

    End Sub


    Private Sub btImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btImprimir.Click
        'ImprimirReporte(Format(CDate(Me.mtFechaInicial.Text), "yyyy/MM/dd HH:mm"), Me.'tbHora.Text, Me.'tbMinuto.Text, "")
        ImprimirReporte(Format(CDate(sender.Cells("Fecha_Evol").Value.ToString), "yyyy/MM/dd HH:mm"),
                        Format(CDate(sender.Cells("Fecha_Evol").Value.ToString), "HH"),
                        Format(CDate(sender.Cells("Fecha_Evol").Value.ToString), "mm"), "")
        'Format(CDate(sender.Cells("Fecha_Evol").Value.ToString), "dd/MM/yyyy HH:mm")
        Me.btNuevo.Enabled = True
    End Sub

    'Private Sub tbPlanManejo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbPlanManejo.GotFocus
    '    If txtPlanManejogotfocus = False Then
    '        txtPlanManejogotfocus = True
    '        If tbPlanManejo.Text = "" Then
    '            ''Claudia Garay 9 de diciembre. Se modifica mensaje.
    '            Dim msg As String = "Registre además del plan de manejo en este campo si el paciente necesita algún plan de egreso."
    '            MsgBox(msg, MsgBoxStyle.Information, "Historia Clinica Medica")
    '        End If
    '    End If
    'End Sub


    Private Sub tbPlanManejo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbPlanManejo.Validated
        '' txtPlanManejogotfocus = False
        'If tbPlanManejo.Text <> "" Then
        '    grpGenPrg.Visible = True
        'End If
    End Sub

    Private Sub rdPlaManPrg1Si_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdPlaManPrg1Si.Click
        If rdPlaManPrg1Si.Checked = True Then
            resPre1 = "S"
        End If
    End Sub


    Private Sub rdPlaManPrg1No_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdPlaManPrg1No.Click
        If rdPlaManPrg1No.Checked = True Then
            resPre1 = "S"
        End If
    End Sub


    Private Sub rdPlaManPrg2Si_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtCierreIntConSI.Click
        If rbtCierreIntConSI.Checked = True Then
            resPre2 = "S"
        End If
    End Sub

    Private Sub rdPlaManPrg2No_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtCierreIntConNo.Click
        If rbtCierreIntConNo.Checked = True Then
            resPre2 = "S"
        End If
    End Sub


    Private Sub tbPlanManejo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbPlanManejo.KeyPress
        modPlanManj = "S"
    End Sub
    ''Claudia Garay 
    ''Septiembre 8 de 2011
    Public Function ValidarSiEvolucionSeGuardo() As Boolean

        If btGrabar.Enabled = True Then
            If Len(txtTipoEvolucion.Text) > 0 Or Len(tbSubjetivo.Text) > 0 _
            Or Len(tbObjetivo.Text) > 0 Or Len(tbParaclinicos.Text) > 0 _
            Or Len(tbPlanManejo.Text) > 0 Then
                Return False
            Else
                Return True
            End If
        Else
            Return True
        End If

    End Function

    'Private Sub lnkRemision_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkRemision.LinkClicked
    '    frmHistoriaPrincipal.pintarMenu(frmHistoriaPrincipal.OpcionesMenu.Remision)
    '    frmHistoriaPrincipal.IniciarRemision()
    'End Sub

    Private Sub Panel2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel2.Click

        pnlContEvolucion.Visible = False
        ''   ctlDescrQx.Visible = False
        'pnlContenedor.Height = 1500

        Me.pnlContenedor.Controls.Add(ctlDescrQx)

        ctlDescrQx.Show()
        'pnlContEvolucion.Visible = True
        ctlDescrQx.Visible = True
        ctlDiagnostico.Visible = False


    End Sub

    ''''' <summary>
    ''''' Descripcion Quirurgica
    ''''' </summary>
    ''''' <remarks></remarks>

    ''Public Sub CargarProcedimientosQuirurgicos()


    ''    Dim dtdatos As New DataTable



    ''    ''  If objDescrQx.dtIntervencion Is Nothing Then

    ''    dtdatos = objQx.ConsultarProcedimientosXAdmision(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoDocumento, _
    ''    objPaciente.NumeroDocumento, objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision)

    ''    If dtdatos.Rows.Count = 0 Then
    ''        '  dtdatos.Rows.Add(dtdatos.NewRow)
    ''        MsgBox("No existen registros ")
    ''    Else
    ''        objDescrQx.dtIntervencion = dtdatos
    ''        dtgProcedim.DataSource = dtdatos
    ''        dtgProcedim.Columns("tie_limpieza").Visible = False
    ''        dtgProcedim.Columns("tip_anestesia").Visible = False

    ''        cmbTipoQx.Text = dtdatos.Rows(0).Item("tie_limpieza")


    ''        configurarGrillaProc()
    ''    End If
    ''    ''Else
    ''    'If objDescrQx.dtIntervencion.Rows.Count = 0 Then
    ''    '    MsgBox("No existen registros ")
    ''    '    Exit Sub
    ''    'End If
    ''    dtgProcedim.DataSource = dtdatos
    ''    'configurarGrillaProc()
    ''    ''End If

    ''End Sub

    ''Private Sub configurarGrillaProc()

    ''    'Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    ''    'DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    ''    'DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
    ''    'DataGridViewCellStyle7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    ''    'DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
    ''    'DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
    ''    'DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    ''    'DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    ''    'Me.dtgProcedim.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7

    ''    With dtgProcedim
    ''        .Columns.Item("Consecutivo").Width = 90
    ''        .Columns.Item("Procedimiento").Width = 120
    ''        .Columns.Item("Descripcion").Width = 150

    ''    End With

    ''End Sub

    ''Private Sub dtgProcedim_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgProcedim.CellClick
    ''    If dtgProcedim.CurrentRow Is Nothing Then
    ''        MessageBox.Show("Seleccione un Registro de la Lista", "Descripción Quirúrgica", MessageBoxButtons.OK, MessageBoxIcon.Information)
    ''        Exit Sub
    ''    End If



    ''End Sub
    ''Private Sub CargarCombos(ByVal intopcion As Integer)
    ''    Dim dt As New DataTable


    ''    Select Case intopcion
    ''        Case 1 ''Tipo de profesional
    ''            txtCodTipPers.ResetText()
    ''            txtTipPers.ResetText()
    ''            With txtCodTipPers
    ''                .NombreCampoBuscado = "DESCRIPCION"
    ''                .NombreCampoBusqueda = "TIP_EMPLEADO"
    ''                .ControlTextoEnlace = txtTipPers
    ''            End With

    ''            ''Configuracion del campo que maneja la descripcion 
    ''            With txtTipPers
    ''                .NombreCampoDatos = "DESCRIPCION"
    ''                .ControlTextoEnlace = txtCodTipPers
    ''                Try
    ''                    .OrigenDeDatos = objQx.CargarCombosDescQX(1)
    ''                    .CargarDatosDescripcion()
    ''                Catch ex As Exception
    ''                    MsgBox("Error en la consulta de los tipos profesional. " & ex.Message, MsgBoxStyle.Information)
    ''                End Try
    ''            End With
    ''        Case 2 ''Especilaidad
    ''            Try
    ''                cmbEspecialidad.ResetText()
    ''                cmbEspecialidad.BeginUpdate()

    ''                dt = objQx.CargarCombosDescQX(2, txtCodProfes.Text)

    ''                If dt.Rows.Count = 0 Then
    ''                    MsgBox("No existen especialidades parametrizadas para el médico seleccionado")
    ''                End If
    ''                cmbEspecialidad.DataSource = dt

    ''                cmbEspecialidad.DisplayMember = "descripcion"
    ''                cmbEspecialidad.ValueMember = "especialidad"
    ''                cmbEspecialidad.EndUpdate()
    ''            Catch ex As Exception
    ''                MsgBox("Error en la consulta de especialidades. " & ex.Message, MsgBoxStyle.Information)
    ''            End Try

    ''        Case 3
    ''            cmbProcedim.ResetText()
    ''            cmbProcedim.BeginUpdate()
    ''            txtcodProce.ControlComboEnlace = cmbProcedim

    ''            With cmbProcedim
    ''                .CampoMostrar = "descripcion"
    ''                .ControlTextoEnlace = txtcodProce
    ''                .CampoEnlazado = "Codigo"
    ''                .CategoriaDatos = CategoriaDatos.ProcedimientosQX
    ''                .CargarDatos()
    ''                .CargarButton()
    ''            End With
    ''            cmbProcedim.EndUpdate()
    ''        Case 4 ''Todas las Especialidades
    ''            Try
    ''                cmbEspecialidad.ResetText()
    ''                cmbEspecialidad.BeginUpdate()

    ''                cmbEspecialidad.DataSource = objQx.CargarCombosDescQX(3)
    ''                cmbEspecialidad.DisplayMember = "descripcion"
    ''                cmbEspecialidad.ValueMember = "especialidad"
    ''                cmbEspecialidad.EndUpdate()
    ''            Catch ex As Exception
    ''                MsgBox("Error en la consulta de especialidades. " & ex.Message, MsgBoxStyle.Information)
    ''            End Try
    ''        Case 5 ''Tipo de Anestesia
    ''            Try
    ''                cmbAnestesia.ResetText()
    ''                cmbAnestesia.BeginUpdate()

    ''                cmbAnestesia.DataSource = objQx.CargarCombosDescQX(4)
    ''                cmbAnestesia.DisplayMember = "descripcion"
    ''                cmbAnestesia.ValueMember = "tip_anestesia"
    ''                cmbAnestesia.EndUpdate()
    ''            Catch ex As Exception
    ''                MsgBox("Error en la consulta de los tipos de anestesia. " & ex.Message, MsgBoxStyle.Information)
    ''            End Try
    ''        Case 6 ''Medicamentos para profilaxis
    ''            cmbProfilaxis.ResetText()
    ''            cmbProfilaxis.BeginUpdate()
    ''            txtCodProfilaxis.ControlComboEnlace = cmbProfilaxis

    ''            With cmbProfilaxis
    ''                .CampoMostrar = "descripcion"
    ''                .ControlTextoEnlace = txtCodProfilaxis
    ''                .CampoEnlazado = "Codigo"
    ''                .CategoriaDatos = CategoriaDatos.OrdenMedicamentosDescripcion
    ''                .CargarDatos()
    ''                .CargarButton()
    ''            End With
    ''            cmbProfilaxis.EndUpdate()

    ''            dt.Columns.Add("codigo", System.Type.GetType("System.String"))
    ''            dt.Columns.Add("medicamento", System.Type.GetType("System.String"))
    ''            dtgProfilaxis.DataSource = dt
    ''        Case 7 ''Tipo de Cirugia
    ''            Try
    ''                cmbTipoQx.ResetText()
    ''                cmbTipoQx.BeginUpdate()

    ''                cmbTipoQx.DataSource = objQx.CargarCombosDescQX(5)
    ''                cmbTipoQx.DisplayMember = "DESCRIPCION"
    ''                cmbTipoQx.ValueMember = "TIE_LIMPIEZA"
    ''                cmbTipoQx.EndUpdate()
    ''            Catch ex As Exception
    ''                MsgBox("Error en la consulta de tipos de Cirugía. " & ex.Message, MsgBoxStyle.Information)
    ''            End Try

    ''    End Select



    ''End Sub


    ''Private Sub dtgProcedim_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgProcedim.CellDoubleClick
    ''    LimpiardatosDescQX()
    ''    TraerDetalleProcedimiento()
    ''End Sub

    '' ''cpgaray  13 feb 2012
    ''Private Sub TraerDetalleProcedimiento()
    ''    Dim dsdetalle As New DataSet

    ''    If dtgProcedim.CurrentRow Is Nothing Then
    ''        MsgBox("Seleccione un procedimiento")
    ''        Exit Sub
    ''    Else
    ''        txtcodProce.Text = dtgProcedim.CurrentRow.Cells("Procedimiento").Value
    ''        cmbProcedim.Text = dtgProcedim.CurrentRow.Cells("Descripcion").Value
    ''        mskInicioCir.Text = dtgProcedim.CurrentRow.Cells("FechaInicio").Value
    ''        txtHoraCir.Text = dtgProcedim.CurrentRow.Cells("HoraInicio").Value
    ''        txtMinCir.Text = dtgProcedim.CurrentRow.Cells("MinutoInicio").Value
    ''        mskFinalCir.Text = dtgProcedim.CurrentRow.Cells("FechaFinal").Value
    ''        txtHoraFinalCir.Text = dtgProcedim.CurrentRow.Cells("HoraFinal").Value
    ''        txtMinFinCir.Text = dtgProcedim.CurrentRow.Cells("MinutoFinal").Value
    ''        lblTiempQx.Text = dtgProcedim.CurrentRow.Cells("TiempoQX").Value
    ''        btnAgregarProc.Enabled = True
    ''        objDescrQx.Consecutivo = dtgProcedim.CurrentRow.Cells("consecutivo").Value
    ''        objDescrQx.Procedimiento = dtgProcedim.CurrentRow.Cells("Procedimiento").Value
    ''    End If

    ''    dsdetalle = objQx.ConsultarDetalleProcedimientosXAdmision(objGeneral.Prestador, objGeneral.Sucursal, dtgProcedim.CurrentRow.Cells("consecutivo").Value, dtgProcedim.CurrentRow.Cells("Procedimiento").Value)

    ''    If dsdetalle.Tables.Count = 0 Then
    ''        Exit Sub
    ''    End If

    ''    CargarTiempos(dsdetalle.Tables(0))
    ''    CargarEquipoQuirurgico(dsdetalle.Tables(1))
    ''    CargarPersonalMedico(dsdetalle.Tables(2))
    ''    CargarDiagnosticos(dsdetalle.Tables(3), dsdetalle.Tables(4))
    ''    CargarProfilaxis(dsdetalle.Tables(5))
    ''    txtcodProce.Enabled = False
    ''    cmbProcedim.Enabled = False


    ''End Sub
    ''Private Sub CargarProfilaxis(ByVal dt As DataTable)

    ''    dtgProfilaxis.DataSource = dt
    ''    dtgProfilaxis.Columns("Medicamento").Width = 400
    ''    dtgProfilaxis.Columns("codigo").Width = 100

    ''End Sub
    ''Private Sub CargarDiagnosticos(ByVal dtpre As DataTable, Optional ByVal dtpos As DataTable = Nothing)
    ''    Dim arraycol As New ArrayList

    ''    If Not dtpre Is Nothing > 0 Then
    ''        With dtgPreoperatorio
    ''            .DataSource = dtpre
    ''            .Columns("consecutivo").Visible = False
    ''            .Columns("procedim").Visible = False
    ''            .Columns("tip_diag").Visible = False
    ''            .Columns("login").Visible = False
    ''            .Columns("clasificacion").Visible = False
    ''            .Columns("clase").Visible = False
    ''            .Columns("diagnost").Visible = False
    ''            .Columns("Diagnostic").Width = 120
    ''            .Columns("TipoDiagnostico").Width = 180
    ''        End With
    ''    End If

    ''    If Not dtpos Is Nothing > 0 Then
    ''        With dtgPostperatorio
    ''            .DataSource = dtpos
    ''            .Columns("consecutivo").Visible = False
    ''            .Columns("procedim").Visible = False
    ''            .Columns("tip_diag").Visible = False
    ''            .Columns("login").Visible = False
    ''            .Columns("clasificacion").Visible = False
    ''            .Columns("clase").Visible = False
    ''            .Columns("diagnost").Visible = False
    ''            .Columns("Diagnostic").Width = 120
    ''            .Columns("TipoDiagnostico").Width = 180
    ''        End With
    ''    End If

    ''End Sub
    ''Private Sub CargarTiempos(ByVal dt As DataTable)




    ''    If dt.Rows.Count > 0 Then
    ''        mskFechaIng.Text = dt.Rows(0).Item("fecha_inicial")
    ''        txtHora.Text = dt.Rows(0).Item("hor_inicial")
    ''        txtMin.Text = dt.Rows(0).Item("min_inicial")
    ''        mskSalida.Text = dt.Rows(0).Item("fecha_final")
    ''        txtHoraSal.Text = dt.Rows(0).Item("hor_final")
    ''        txtMinSal.Text = dt.Rows(0).Item("min_final")
    ''        cmbAnestesia.Text = dt.Rows(0).Item("descripcion")
    ''    End If


    ''End Sub

    ''Private Sub CargarEquipoQuirurgico(ByVal dt As DataTable)

    ''End Sub
    ''Private Sub CargarPersonalMedico(ByVal dt As DataTable)

    ''    'dtgPersonalMedico.DataSource = dt
    ''    'If dt.Rows.Count > 0 Then
    ''    With dtgPersonalMedico
    ''        .DataSource = dt
    ''        .Columns("cod_pre_sgs").Visible = False
    ''        .Columns("cod_sucur").Visible = False
    ''        .Columns("consecutivo").Visible = False
    ''        .Columns("procedim").Visible = False
    ''        .Columns("tip_empleado").Visible = False
    ''        .Columns("estado").Visible = False
    ''        .Columns("bilateral").Visible = False
    ''        .Columns("espc").Visible = False
    ''        .Columns("login").Visible = False
    ''        .Columns("nro_autoriza").Visible = False
    ''        '.Columns("descripcion").Visible = False
    ''        .Columns("Especialidad").Width = 150
    ''        .Columns("Medico").Width = 300
    ''        .Columns("tip_empleado").Width = 100
    ''    End With

    ''    If dt.Rows.Count > 0 Then
    ''        objDescrQx.NroAutorizacion = dt.Rows(0).Item("nro_autoriza")

    ''        If Not IsDBNull(dt.Rows(0).Item("bilateral")) Then

    ''            If dt.Rows(0).Item("bilateral") = "S" Then
    ''                chkBilateral.Checked = True
    ''            ElseIf dt.Rows(0).Item("bilateral") = "N" Then
    ''                chkBilateral.Checked = False
    ''            Else
    ''                chkBilateral.Checked = False
    ''            End If
    ''        Else
    ''            chkBilateral.Checked = False
    ''        End If
    ''        chkBilateral.Enabled = False
    ''    End If

    ''    'Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    ''    'DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    ''    'DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
    ''    'DataGridViewCellStyle7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    ''    'DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
    ''    'DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
    ''    'DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    ''    'DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    ''    'Me.dtgPersonalMedico.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7

    ''End Sub


    ''Private Sub CalcularTiempoQuirurgico()
    ''    Dim hora As Integer
    ''    Dim min As Integer


    ''    If mskFinalCir.Text = mskInicioCir.Text Then


    ''        If Val(txtHoraCir.Text) > 0 And Val(txtHoraFinalCir.Text) > 0 Then

    ''            If Val(txtHoraFinalCir.Text) < Val(txtHoraCir.Text) Then
    ''                MsgBox("La hora de finalización no puede ser menor a la hora de inicio")
    ''                txtHoraFinalCir.Focus()
    ''                Exit Sub
    ''            End If

    ''            hora = Val(txtHoraFinalCir.Text) - Val(txtHoraCir.Text)

    ''            If IIf(Len(txtMinFinCir.Text) = 0, 0, Val(txtMinFinCir.Text)) < IIf(Len(txtMinCir.Text) = 0, 0, Val(txtMinCir.Text)) Then
    ''                min = (60 - Val(txtMinCir.Text)) + Val(txtMinFinCir.Text)
    ''                hora = hora - 1
    ''            Else
    ''                min = Val(txtMinFinCir.Text) - Val(txtMinCir.Text)
    ''            End If



    ''            lblTiempQx.Text = hora & " Horas " & min & " Minutos"



    ''        Else
    ''            MsgBox("Datos incompletos")
    ''            If Val(txtHoraCir.Text) > 0 Then
    ''                txtHoraFinalCir.Focus()
    ''            Else
    ''                txtHoraCir.Focus()
    ''            End If

    ''        End If


    ''    End If

    ''End Sub


    ''Private Sub BuscarMedico()
    ''    Dim frmConsulta As New frmc_ConsultaMedicoQx
    ''    frmConsulta.ShowDialog()

    ''    txtCodProfes.Text = frmConsulta.CodigoMedico
    ''    txtDescProfes.Text = frmConsulta.NombreMedico

    ''    If Len(txtCodProfes.Text) > 0 Then
    ''        CargarCombos(2)
    ''    End If

    ''End Sub

    ''Private Sub txtCodProfes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    ''End Sub

    ''Private Sub ConsultarMedicoXDoc()

    ''    If objQx.ConsultaMedicoXDoc(txtCodProfes.Text) = "" Then
    ''        MsgBox("No existen registros para el dato ingresado")
    ''    Else
    ''        txtDescProfes.Text = objQx.ConsultaMedicoXDoc(txtCodProfes.Text)
    ''        CargarCombos(2)
    ''    End If
    ''End Sub

    ''Private Sub AgregaMedico()
    ''    Dim drow As DataRow
    ''    Dim dtmedico As New DataTable
    ''    Dim rows() As DataRow

    ''    dtmedico = dtgPersonalMedico.DataSource

    ''    If strCirujanoInvitado = "N" Then

    ''        If Not dtmedico Is Nothing Then
    ''            If dtmedico.Rows.Count > 0 Then
    ''                rows = dtmedico.Select("consecutivo='" & dtmedico.Rows(0).Item("consecutivo") & _
    ''                   "' and procedim='" & dtmedico.Rows(0).Item("procedim") & "' and CodMedico='" & _
    ''                   txtCodProfes.Text & "' and tip_empleado='" & txtCodTipPers.Text & "'")

    ''                If rows.Length > 0 Then
    ''                    MsgBox("Registro ya existe")
    ''                    Exit Sub
    ''                End If

    ''            End If
    ''        End If
    ''    End If
    ''    drow = dtmedico.NewRow

    ''    drow.Item("cod_pre_sgs") = objGeneral.Prestador
    ''    drow.Item("cod_sucur") = objGeneral.Sucursal
    ''    drow.Item("consecutivo") = objDescrQx.Consecutivo
    ''    drow.Item("procedim") = objDescrQx.Procedimiento
    ''    drow.Item("tip_empleado") = txtCodTipPers.Text
    ''    drow.Item("estado") = "L" ''NO se que es este estado =(
    ''    drow.Item("bilateral") = IIf(chkBilateral.Checked = True, "S", "N")
    ''    drow.Item("espc") = cmbEspecialidad.SelectedValue
    ''    drow.Item("login") = objGeneral.Login
    ''    drow.Item("especialidad") = cmbEspecialidad.Text
    ''    drow.Item("TipoProfesional") = txtTipPers.Text
    ''    drow.Item("obs") = txtobs.Text
    ''    If strCirujanoInvitado = "N" Then
    ''        drow.Item("CodMedico") = txtCodProfes.Text
    ''        drow.Item("Medico") = txtDescProfes.Text
    ''    Else
    ''        drow.Item("CodMedico") = "INVITADO"
    ''        drow.Item("Medico") = txtCirujanoInvitado.Text
    ''    End If

    ''    dtmedico.Rows.Add(drow)

    ''    ActualizaEquipoMedico(drow)

    ''    dtgPersonalMedico.DataSource = dtmedico


    ''    txtCodTipPers.Text = String.Empty
    ''    txtCodProfes.Text = String.Empty
    ''    cmbEspecialidad.ResetText()
    ''    txtTipPers.Text = String.Empty
    ''    txtDescProfes.Text = String.Empty
    ''    txtCirujanoInvitado.Text = String.Empty
    ''    txtobs.Text = String.Empty

    ''End Sub
    ''Private Sub AgregaDiagnostico()
    ''    Dim drow As DataRow
    ''    Dim dtdiagn As New DataTable
    ''    Dim rows() As DataRow

    ''    If cmbClaseDiagn.Text = "" Or txtCodTipoDiagnosticoID.Text = "" _
    ''    Or txtDescTipoDiagnosticoID.Text = "" Or txtCodDiagnosticoID.Text = "" _
    ''    Or cboDescDiagnosticoID.Text = "" Then

    ''        MsgBox("Datos incompletos", MsgBoxStyle.Critical, "Diagnósticos")
    ''        Exit Sub

    ''    End If



    ''    If cmbClaseDiagn.Text = "PREOPERATORIO" Then
    ''        dtdiagn = dtgPreoperatorio.DataSource
    ''    Else
    ''        dtdiagn = dtgPostperatorio.DataSource
    ''    End If

    ''    If Not dtdiagn Is Nothing Then
    ''        If dtdiagn.Rows.Count > 0 Then
    ''            rows = dtdiagn.Select("consecutivo='" & dtdiagn.Rows(0).Item("consecutivo") & _
    ''                        "' and procedim='" & dtdiagn.Rows(0).Item("procedim") & "' and tip_diag='" & _
    ''                        txtCodTipoDiagnosticoID.Text & "' and diagnost='" & txtCodDiagnosticoID.Text & "'")

    ''            If rows.Length > 0 Then
    ''                MsgBox("Registro ya existe")
    ''                Exit Sub
    ''            End If

    ''        End If

    ''    Else

    ''        dtdiagn.Rows.Add(dtdiagn.NewRow)
    ''    End If



    ''    drow = dtdiagn.NewRow

    ''    drow.Item("consecutivo") = objDescrQx.Consecutivo
    ''    drow.Item("procedim") = objDescrQx.Procedimiento
    ''    drow.Item("diagnostic") = cboDescDiagnosticoID.Text
    ''    drow.Item("tip_diag") = txtCodTipoDiagnosticoID.Text
    ''    drow.Item("TipoDiagnostico") = txtDescTipoDiagnosticoID.Text
    ''    drow.Item("diagnost") = txtCodDiagnosticoID.Text
    ''    drow.Item("login") = objGeneral.Login
    ''    drow.Item("obs") = txtobsdiagn.Text
    ''    drow.Item("clasificacion") = strClasifiDiagn
    ''    If cmbClaseDiagn.Text = "PREOPERATORIO" Then
    ''        drow.Item("clase") = "PRE"
    ''    Else
    ''        drow.Item("clase") = "POS"
    ''    End If


    ''    dtdiagn.Rows.Add(drow)

    ''    ActualizaDiagnosticos(drow)

    ''    If cmbClaseDiagn.Text = "PREOPERATORIO" Then
    ''        dtgPreoperatorio.DataSource = dtdiagn
    ''    Else
    ''        dtgPostperatorio.DataSource = dtdiagn
    ''    End If



    ''    cmbClaseDiagn.Text = String.Empty
    ''    txtCodTipoDiagnosticoID.Text = String.Empty
    ''    txtDescTipoDiagnosticoID.Text = String.Empty
    ''    txtCodDiagnosticoID.Text = String.Empty
    ''    cboDescDiagnosticoID.Text = String.Empty
    ''    txtobsdiagn.Text = String.Empty

    ''End Sub
    ''Private Sub cmbProcedim_ActualizarDatosElegidos(ByVal datosElegidos As System.Data.DataRow) Handles cmbProcedim.ActualizarDatosElegidos
    ''    If datosElegidos Is Nothing Then
    ''        txtcodProce.Text = ""
    ''        Exit Sub
    ''    End If


    ''    txtcodProce.Text = datosElegidos.Item("codigo").ToString

    ''    If datosElegidos.Item("bilateral").ToString = "S" Then
    ''        chkBilateral.Checked = True
    ''    Else
    ''        chkBilateral.Checked = False
    ''    End If
    ''End Sub


    ''Private Sub txtMinFinCir_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMinFinCir.Validating
    ''    CalcularTiempoQuirurgico()
    ''End Sub


    ''Private Sub txtHoraFinalCir_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtHoraFinalCir.Validating
    ''    CalcularTiempoQuirurgico()
    ''End Sub


    ''Private Sub txtMinCir_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMinCir.Validating

    ''    If Len(txtHoraFinalCir.Text) > 0 And Len(txtHoraCir.Text) > 0 Then
    ''        CalcularTiempoQuirurgico()
    ''    End If
    ''End Sub

    ''Private Sub txtHoraCir_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtHoraCir.Validating
    ''    If Len(txtHoraFinalCir.Text) > 0 Then
    ''        CalcularTiempoQuirurgico()
    ''    End If
    ''End Sub


    ''Private Sub mskInicioCir_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mskInicioCir.Validating
    ''    If mskInicioCir.Text <> "  /  /" Then
    ''        If Not IsDate(mskInicioCir.Text) Then
    ''            MsgBox("Fecha invalida. Debe digitar una fecha valida.", MsgBoxStyle.Information)
    ''            e.Cancel = True
    ''            mskInicioCir.Select(0, mskInicioCir.TextLength)
    ''        End If
    ''    End If
    ''End Sub

    ''Private Sub mskFinalCir_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mskFinalCir.Validating
    ''    If mskFinalCir.Text <> "  /  /" Then
    ''        If Not IsDate(mskFinalCir.Text) Then
    ''            MsgBox("Fecha invalida. Debe digitar una fecha valida.", MsgBoxStyle.Information)
    ''            e.Cancel = True
    ''            mskFinalCir.Select(0, mskFinalCir.TextLength)
    ''        Else
    ''            If Not CDate(mskFinalCir.Text) >= CDate(mskInicioCir.Text) Then
    ''                MsgBox("La fecha de finalización no puede ser menor a la de inicio.", MsgBoxStyle.Information)
    ''                e.Cancel = True
    ''                mskFinalCir.Select(0, mskFinalCir.TextLength)
    ''            End If
    ''        End If
    ''    End If
    ''End Sub

    ''Private Sub btnAgregarEquipo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarEquipo.Click
    ''    AgregaMedico()
    ''End Sub

    ''Private Sub txtDescProfes_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescProfes.DoubleClick
    ''    BuscarMedico()
    ''End Sub


    ''Private Sub txtCodProfes_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodProfes.DoubleClick
    ''    BuscarMedico()
    ''End Sub


    ''Private Sub txtCodProfes_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodProfes.Validating
    ''    If Len(txtCodProfes.Text) > 0 Then
    ''        ConsultarMedicoXDoc()
    ''    End If
    ''End Sub

    ''Private Sub txtTipPers_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTipPers.TextChanged

    ''End Sub

    ''Private Sub txtTipPers_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTipPers.Validating
    ''    If txtCodTipPers.Text = "V" Then 'Cirujano invitado
    ''        pnlCirujanoInv.Visible = True
    ''        pnlProfesional.Visible = False
    ''        strCirujanoInvitado = "S"
    ''    Else
    ''        strCirujanoInvitado = "N"
    ''        pnlCirujanoInv.Visible = False
    ''        pnlProfesional.Visible = True
    ''    End If
    ''End Sub

    ''Private Sub txtDescProfes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescProfes.TextChanged

    ''End Sub

    ''Private Sub txtDescProfes_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDescProfes.Validating
    ''    ConsultarMedicoXDoc()
    ''End Sub

    ''Private Sub txtCirujanoInvitado_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCirujanoInvitado.Validating
    ''    CargarCombos(4)
    ''End Sub

    ''Private Sub rbProfilaxisSi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbProfilaxisSi.CheckedChanged

    ''    If rbProfilaxisSi.Checked = True Then
    ''        pnlProfilaxis.Enabled = True

    ''    Else
    ''        pnlProfilaxis.Enabled = False
    ''    End If

    ''End Sub

    ''Private Sub rbProfilaxisNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbProfilaxisNo.CheckedChanged
    ''    If rbProfilaxisNo.Checked = True Then
    ''        pnlProfilaxis.Enabled = False
    ''    Else
    ''        pnlProfilaxis.Enabled = True
    ''    End If
    ''End Sub

    ''Private Sub cmbProfilaxis_ActualizarDatosElegidos(ByVal datosElegidos As System.Data.DataRow) Handles cmbProfilaxis.ActualizarDatosElegidos
    ''    If datosElegidos Is Nothing Then
    ''        txtCodProfilaxis.Text = ""
    ''        cmbProfilaxis.Text = ""
    ''        Exit Sub
    ''    End If

    ''    With datosElegidos
    ''        txtCodProfilaxis.Text = .Item("codigo").ToString
    ''        'txtCodProfilaxis.Text = .Item("codigo").ToString
    ''    End With
    ''End Sub

    ''Private Sub cmdAgregarProfilaxis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAgregarProfilaxis.Click
    ''    AgregarProfilaxis()
    ''End Sub

    ''Private Sub AgregarProfilaxis()
    ''    Dim drow As DataRow
    ''    Dim dtprofilaxis As New DataTable
    ''    Dim rows() As DataRow

    ''    dtprofilaxis = dtgProfilaxis.DataSource

    ''    If Not dtprofilaxis Is Nothing Then

    ''        If dtprofilaxis.Rows.Count > 0 Then

    ''            rows = dtprofilaxis.Select("codigo='" & txtCodProfilaxis.Text & "'")

    ''            If rows.Length > 0 Then
    ''                MsgBox("Registro ya existe")
    ''                Exit Sub
    ''            End If
    ''        End If
    ''    End If

    ''    drow = dtprofilaxis.NewRow

    ''    drow.Item("codigo") = txtCodProfilaxis.Text
    ''    drow.Item("medicamento") = cmbProfilaxis.Text

    ''    dtprofilaxis.Rows.Add(drow)
    ''    ActualizaProfilaxis(drow, 0)

    ''    dtgProfilaxis.DataSource = dtprofilaxis
    ''    dtgProfilaxis.Columns("codigo").Width = 100
    ''    dtgProfilaxis.Columns("medicamento").Width = 400

    ''    txtCodProfilaxis.Text = String.Empty
    ''    cmbProfilaxis.Text = String.Empty

    ''End Sub
    ''Private Sub CargarObjetosDiagnosticos()
    ''    Dim objLocal As New BLBasicasLocales

    ''    '/Para Tipo Diagnóstico
    ''    With txtCodTipoDiagnosticoID
    ''        .NombreCampoBusqueda = "tip_diag"
    ''        .NombreCampoBuscado = "descripcion"
    ''        .ControlTextoEnlace = txtDescTipoDiagnosticoID
    ''    End With
    ''    With txtDescTipoDiagnosticoID
    ''        .NombreCampoDatos = "descripcion"
    ''        .ControlTextoEnlace = txtCodTipoDiagnosticoID
    ''        .OrigenDeDatos = objLocal.TraerDatosTablasBasicasLocales(objGeneral.CadenaLocal, "hcTipDiag", "tip_diag,descripcion", "")
    ''        .CargarDatosDescripcion()
    ''    End With
    ''    '/Para los Diagnosticos
    ''    txtCodDiagnosticoID.ControlComboEnlace = cboDescDiagnosticoID
    ''    With cboDescDiagnosticoID
    ''        .CampoMostrar = "descripcion"
    ''        .ControlTextoEnlace = txtCodDiagnosticoID
    ''        .CampoEnlazado = "codigo"
    ''        .CategoriaDatos = CategoriaDatos.Diagnosticos
    ''        .Login = objGeneral.Login
    ''        .SexoPaciente = objPaciente.Genero
    ''        .EdadPaciente = objPaciente.Edad
    ''        .CargarDatos()
    ''        .CargarButton()
    ''    End With

    ''End Sub

    ''Private Sub btnAgregarDiagn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarDiagn.Click
    ''    AgregaDiagnostico()
    ''End Sub

    ''Private Sub cboDescDiagnosticoID_ActualizarDatosElegidos(ByVal datosElegidos As System.Data.DataRow) Handles cboDescDiagnosticoID.ActualizarDatosElegidos
    ''    If datosElegidos Is Nothing Then

    ''        txtCodDiagnosticoID.Text = String.Empty
    ''        cboDescDiagnosticoID.Text = String.Empty

    ''        Exit Sub
    ''    End If

    ''    With datosElegidos
    ''        strClasifiDiagn = .Item("clasificacion").ToString
    ''    End With
    ''End Sub


    ''Private Sub rbSangradoSi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSangradoSi.CheckedChanged

    ''    If rbSangradoSi.Checked = True Then
    ''        txtSangrado.ReadOnly = False
    ''    Else
    ''        txtSangrado.ReadOnly = True
    ''        txtSangrado.ResetText()
    ''    End If


    ''End Sub

    ''Private Sub rbSangradoNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSangradoNo.CheckedChanged
    ''    If rbSangradoSi.Checked = True Then
    ''        txtSangrado.ReadOnly = False
    ''    Else
    ''        txtSangrado.ReadOnly = True
    ''        txtSangrado.ResetText()
    ''    End If

    ''End Sub


    ''Private Sub btnAgregarProc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarProc.Click
    ''    AgregarProcedimiento()

    ''End Sub

    ''Private Sub AgregarProcedimiento()
    ''    Dim drow As DataRow
    ''    Dim dtproc As New DataTable
    ''    Dim rows() As DataRow
    ''    Dim intaccion As Integer

    ''    If cmbAnestesia.Text = "" Or mskInicioCir.Text = "  /  /" Or txtHoraCir.Text = "" Or txtMinCir.Text = "" Or _
    ''       mskFinalCir.Text = "  /  /" Or txtHoraFinalCir.Text = "" Or txtMinFinCir.Text = "" _
    ''       Or txtcodProce.Text = "" Or cmbProcedim.Text = "" Then
    ''        MsgBox("Datos incompletos")
    ''        Exit Sub
    ''    End If

    ''    dtproc = dtgProcedim.DataSource

    ''    If txtcodProce.Enabled = True Then
    ''        If Not dtproc Is Nothing Then


    ''            If dtproc.Rows.Count > 0 Then
    ''                rows = dtproc.Select("Procedimiento='" & txtcodProce.Text & "'")

    ''                If rows.Length > 0 Then
    ''                    MsgBox("Registro ya existe")
    ''                    Exit Sub
    ''                End If
    ''            End If
    ''        End If

    ''        drow = dtproc.NewRow


    ''        drow.Item("consecutivo") = dtproc.Rows(0).Item("consecutivo")
    ''        drow.Item("Procedimiento") = txtcodProce.Text
    ''        drow.Item("Descripcion") = cmbProcedim.Text
    ''        drow.Item("tie_limpieza") = ""
    ''        drow.Item("FechaInicio") = mskInicioCir.Text
    ''        drow.Item("HoraInicio") = Val(txtHoraCir.Text)
    ''        drow.Item("MinutoInicio") = Val(txtMinCir.Text)
    ''        drow.Item("FechaFinal") = mskFinalCir.Text
    ''        drow.Item("HoraFinal") = Val(txtHoraFinalCir.Text)
    ''        drow.Item("MinutoFinal") = Val(txtMinFinCir.Text)
    ''        drow.Item("TiempoQX") = Val(lblTiempQx.Text)
    ''        drow.Item("tip_anestesia") = cmbAnestesia.SelectedValue
    ''        drow.Item("Anestesia") = cmbAnestesia.Text


    ''        dtproc.Rows.Add(drow)

    ''        intaccion = 2
    ''    Else

    ''        rows = dtproc.Select("Procedimiento='" & txtcodProce.Text & "'")
    ''        rows(0).Item("tie_limpieza") = ""
    ''        rows(0).Item("FechaInicio") = mskInicioCir.Text
    ''        rows(0).Item("HoraInicio") = Val(txtHoraCir.Text)
    ''        rows(0).Item("MinutoInicio") = Val(txtMinCir.Text)
    ''        rows(0).Item("FechaFinal") = mskFinalCir.Text
    ''        rows(0).Item("HoraFinal") = Val(txtHoraFinalCir.Text)
    ''        rows(0).Item("MinutoFinal") = Val(txtMinFinCir.Text)
    ''        rows(0).Item("TiempoQX") = lblTiempQx.Text
    ''        rows(0).Item("tip_anestesia") = cmbAnestesia.SelectedValue
    ''        rows(0).Item("Anestesia") = cmbAnestesia.Text
    ''        drow = rows(0)

    ''        intaccion = 0
    ''    End If


    ''    dtgProcedim.DataSource = dtproc

    ''    ActualizaProcedimientos(drow, intaccion)

    ''    cmbAnestesia.Text = String.Empty
    ''    lblTiempQx.Text = String.Empty
    ''    mskInicioCir.Text = String.Empty
    ''    txtHoraCir.Text = String.Empty
    ''    txtMinCir.Text = String.Empty
    ''    mskFinalCir.Text = String.Empty
    ''    txtHoraFinalCir.Text = String.Empty
    ''    txtMinFinCir.Text = String.Empty
    ''    txtcodProce.Text = String.Empty
    ''    cmbProcedim.Text = String.Empty
    ''    txtcodProce.Enabled = True
    ''    cmbProcedim.Enabled = True

    ''End Sub

    ''Private Function ActualizaProcedimientos(ByVal drow As DataRow, ByVal intaccion As Integer) As Boolean
    ''    Dim strMensaje As String = ""

    ''    strMensaje = objQxManejaDatos.GuardarProcedimiento(objGeneral.Prestador, objGeneral.Sucursal, drow.Item("consecutivo").ToString, drow.Item("Procedimiento").ToString, _
    ''    drow.Item("FechaInicio").ToString, drow.Item("HoraInicio").ToString, drow.Item("MinutoInicio").ToString, drow.Item("FechaFinal").ToString, drow.Item("TiempoQX").ToString, _
    ''    0, "", "", "", "", "", drow.Item("HoraFinal").ToString, drow.Item("MinutoFinal").ToString, drow.Item("tip_anestesia").ToString, objPaciente.Entidad, objGeneral.Login, intaccion)

    ''    If Len(strMensaje) = 0 Then
    ''        Return True
    ''    Else
    ''        MsgBox(strMensaje)
    ''        objQxManejaDatos.GrabarLogErrores(strMensaje, objGeneral.Sucursal, objGeneral.Login, objDescrQx.Consecutivo, objDescrQx.Procedimiento)
    ''        Return False
    ''    End If


    ''End Function
    ''Private Function ActualizaProcedimientos(ByVal drow As DataGridViewRow, ByVal intaccion As Integer) As Boolean
    ''    Dim strMensaje As String = ""

    ''    strMensaje = objQxManejaDatos.GuardarProcedimiento(objGeneral.Prestador, objGeneral.Sucursal, drow.Cells("consecutivo").Value.ToString, _
    ''    drow.Cells("Procedimiento").Value.ToString, "2000/01/01", drow.Cells("HoraInicio").Value.ToString, _
    ''    drow.Cells("MinutoInicio").Value.ToString, "2000/01/01", drow.Cells("TiempoQX").Value.ToString, _
    ''    0, "", "", "", "", "", drow.Cells("HoraFinal").Value.ToString, _
    ''    drow.Cells("MinutoFinal").Value.ToString, drow.Cells("tip_anestesia").Value.ToString, objPaciente.Entidad, objGeneral.Login, intaccion)

    ''    'CargarProcedimientosQuirurgicos()

    ''    If Len(strMensaje) = 0 Then

    ''        Return True
    ''    Else
    ''        MsgBox(strMensaje)
    ''        objQxManejaDatos.GrabarLogErrores(strMensaje, objGeneral.Sucursal, objGeneral.Login, objDescrQx.Consecutivo, objDescrQx.Procedimiento)
    ''        Return False

    ''    End If
    ''End Function
    ''Private Function ActualizaProfilaxis(ByVal drow As DataRow, ByVal intaccion As Integer) As Boolean
    ''    Dim strMensaje As String = ""

    ''    strMensaje = objQxManejaDatos.GrabarProfilaxis(objGeneral.Prestador, objGeneral.Sucursal, objDescrQx.Procedimiento, objDescrQx.Consecutivo, _
    ''    drow.Item("codigo").ToString, intaccion, objGeneral.Login, "")

    ''    If Len(strMensaje) = 0 Then
    ''        Return True
    ''    Else
    ''        MsgBox(strMensaje)
    ''        objQxManejaDatos.GrabarLogErrores(strMensaje, objGeneral.Sucursal, objGeneral.Login, objDescrQx.Consecutivo, objDescrQx.Procedimiento)
    ''        Return False
    ''    End If


    ''End Function
    ''Private Function ActualizaEquipoMedico(ByVal drow As DataRow) As Boolean
    ''    Dim strMensaje As String = ""

    ''    strMensaje = objQxManejaDatos.GuardarEquipoMedico(objGeneral.Prestador, objGeneral.Sucursal, drow.Item("consecutivo").ToString, drow.Item("procedim").ToString, _
    ''    drow.Item("CodMedico").ToString, drow.Item("tip_empleado").ToString, drow.Item("espc").ToString, drow.Item("estado").ToString, drow.Item("bilateral").ToString, _
    ''    drow.Item("nro_autoriza").ToString, drow.Item("obs").ToString, objGeneral.Login)

    ''    If Len(strMensaje) = 0 Then
    ''        Return True
    ''    Else
    ''        MsgBox(strMensaje)
    ''        objQxManejaDatos.GrabarLogErrores(strMensaje, objGeneral.Sucursal, objGeneral.Login, objDescrQx.Consecutivo, objDescrQx.Procedimiento)
    ''        Return False
    ''    End If
    ''End Function
    ''Private Function ActualizaDiagnosticos(ByVal drow As DataRow) As Boolean
    ''    Dim strMensaje As String = ""

    ''    strMensaje = objQxManejaDatos.GuardarDiagnosticos(objGeneral.Prestador, objGeneral.Sucursal, drow.Item("consecutivo").ToString, drow.Item("procedim").ToString, _
    ''    drow.Item("tip_diag").ToString, drow.Item("diagnost").ToString, drow.Item("clasificacion").ToString, drow.Item("clase").ToString, drow.Item("obs").ToString, _
    ''    objGeneral.Login)

    ''    If Len(strMensaje) = 0 Then
    ''        Return True
    ''    Else
    ''        MsgBox(strMensaje)
    ''        objQxManejaDatos.GrabarLogErrores(strMensaje, objGeneral.Sucursal, objGeneral.Login, objDescrQx.Consecutivo, objDescrQx.Procedimiento)
    ''        Return False
    ''    End If
    ''End Function
    ''Private Function GuardarDescripcionQx() As Boolean
    ''    Dim strMensaje As String = ""

    ''    strMensaje = objQxManejaDatos.GuardarProcedimiento(objGeneral.Prestador, objGeneral.Sucursal, objDescrQx.Consecutivo, objDescrQx.Procedimiento, _
    ''    "2011/01/01", 0, 0, "2011/01/01", 0, _
    ''    IIf(Len(txtSangrado.Text) > 0, Val(txtSangrado.Text), 0), txtTejidos.Text, txtDescIntervencion.Text, IIf(rbCompleto.Checked = True, "C", "I"), _
    ''    txtComplicaciones.Text, txtHallazgos.Text, 0, 0, "", objPaciente.Entidad, objGeneral.Login, 0)

    ''    If Len(strMensaje) = 0 Then
    ''        Return True
    ''    Else
    ''        MsgBox(strMensaje)
    ''        objQxManejaDatos.GrabarLogErrores(strMensaje, objGeneral.Sucursal, objGeneral.Login, objDescrQx.Consecutivo, objDescrQx.Procedimiento)
    ''        Return False
    ''    End If



    ''End Function


    ''Private Sub dtgProcedim_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dtgProcedim.UserDeletedRow
    ''    dtgProcedim.DataSource.AcceptChanges()
    ''End Sub


    ''Private Sub dtgProcedim_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dtgProcedim.UserDeletingRow
    ''    If MessageBox.Show("Esta Seguro de Borrar este Registro?", "Impresión Diagnóstica", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
    ''        ActualizaProcedimientos(e.Row, 1)
    ''    Else
    ''        e.Cancel = True
    ''    End If

    ''End Sub

    ''Private Sub LimpiardatosDescQX()
    ''    chkBilateral.Checked = False
    ''    cmbAnestesia.Text = String.Empty
    ''    lblTiempQx.Text = String.Empty
    ''    txtHoraCir.Text = String.Empty
    ''    txtMinCir.Text = String.Empty
    ''    txtHoraFinalCir.Text = String.Empty
    ''    txtMinFinCir.Text = String.Empty
    ''    txtcodProce.Text = String.Empty
    ''    cmbProcedim.Text = String.Empty
    ''    txtCodTipPers.Text = String.Empty
    ''    txtTipPers.Text = String.Empty
    ''    txtCodProfes.Text = String.Empty
    ''    txtDescProfes.Text = String.Empty
    ''    txtCirujanoInvitado.Text = String.Empty
    ''    cmbEspecialidad.Text = String.Empty
    ''    txtobs.Text = String.Empty
    ''    txtCodProfilaxis.Text = String.Empty
    ''    cmbClaseDiagn.Text = String.Empty
    ''    txtCodTipoDiagnosticoID.Text = String.Empty
    ''    txtDescTipoDiagnosticoID.Text = String.Empty
    ''    txtCodDiagnosticoID.Text = String.Empty
    ''    cboDescDiagnosticoID.Text = String.Empty
    ''    txtobsdiagn.Text = String.Empty
    ''    txtTejidos.Text = String.Empty
    ''    cmbTipoQx.Text = String.Empty
    ''    txtSangrado.Text = String.Empty
    ''    txtDescIntervencion.Text = String.Empty
    ''    txtComplicaciones.Text = String.Empty
    ''    txtHallazgos.Text = String.Empty
    ''    mskInicioCir.Text = String.Empty
    ''    mskFinalCir.Text = String.Empty
    ''    rbProfilaxisSi.Checked = False
    ''    rbProfilaxisNo.Checked = False
    ''    rbSangradoSi.Checked = False
    ''    rbSangradoNo.Checked = False
    ''    rbCompleto.Checked = False
    ''    rbIncompleto.Checked = False
    ''    rbSiCompl.Checked = False
    ''    rbNoCompl.Checked = False
    ''    dtgPersonalMedico.DataSource = Nothing
    ''    dtgProfilaxis.DataSource = Nothing
    ''    dtgPreoperatorio.DataSource = Nothing
    ''    dtgPostperatorio.DataSource = Nothing
    ''End Sub

    ''Private Sub btnGuardarDescripcionQx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarDescripcionQx.Click
    ''    GuardarDescripcionQx()
    ''    LimpiardatosDescQX()
    ''End Sub

    ''Private Sub rbSiCompl_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSiCompl.CheckedChanged

    ''    If rbSiCompl.Checked = True Then  
    ''        txtComplicaciones.ReadOnly = False
    ''    Else
    ''        txtComplicaciones.ReadOnly = True
    ''        txtComplicaciones.ResetText()
    ''    End If
    ''End Sub

    ''Private Sub rbNoCompl_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbNoCompl.CheckedChanged
    ''    If rbNoCompl.Checked = True Then
    ''        txtComplicaciones.ReadOnly = True
    ''        txtComplicaciones.ResetText()
    ''    Else
    ''        txtComplicaciones.ReadOnly = False
    ''    End If
    ''End Sub


    ''Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    ''End Sub


    ''Private Sub Panel2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel2.Click
    ''    Dim ctlDescripcion As ctlDescripcionQuirurgica
    ''End Sub


    Private Sub Panel1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel1.Click

        'objDescrQx = DescripcionQuirurgica.Instancia ''cpgaray

        'objDescrQx = DescripcionQuirurgica.Instancia ''cpgaray
        'objGeneral = Generales.Instancia
        'objPaciente = Paciente.Instancia
        'objConexion = Conexion.Instancia
        'objEvolucion = Evolucion.Instancia
        'strCadenaLocal = objGeneral.CadenaLocal
        'ctlDescrQx = ctlDescripcionQuirurgica.Instancia

        'Dim dtFecha As Date
        'dtFecha = FuncionesGenerales.FechaServidor()
        ''PFecha.Enabled = False
        'mtFechaInicial.Text = Format(dtFecha, "dd/MM/yyyy HH:mm")
        ''tbHora.Text = Hour(dtFecha)
        ''tbMinuto.Text = Minute(dtFecha)
        'tmHoraEvolucion.Interval = (60 - Second(dtFecha)) * 1000
        'tmHoraEvolucion.Enabled = True
        'frmHistoriaPrincipal.blnFirstEvolucion = False

        'IniciarEvolucion()
        'pnlContEvolucion.Visible = True
        'ctlDiagnostico.Visible = True

        'pnlDatosEF.Enabled = objEvolucion.ValidaEspecialidadSignoVital(objConexion, 0, objGeneral.CodigoEspecialidad)
        'Me.ctlDiagnostico.LoadControl()

        pnlContEvolucion.Visible = True
        ctlDescrQx.Visible = False
        ctlDiagnostico.Visible = True

        If objPaciente.TipoAdmision <> "P" Then
            If ValidarFinalizarHcb() = False Then
                pnlContEvolucion.Visible = False
                ctlDescrQx.Visible = False
                ctlDiagnostico.Visible = False

                MessageBox.Show("Debe diligenciar primero Historia Básica de Ingreso del paciente")
                Exit Sub
            End If
        End If

    End Sub

    'Private Sub 'Rbinterconsulta_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If 'Rbinterconsulta.Checked = True Then
    '        Dim var As String
    '        Dim var1 As String


    '        var = objEvolucion1.consultarMedicoTratante(objConexion, objGeneral.Prestador, objGeneral.Sucursal,
    '                          objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision, objGeneral.Login, objGeneral.CodigoEspecialidad)

    '        If var = "NO" Then
    '            MsgBox("El medico tratante del paciente no puede generar una interconsulta")
    '            objEvolucion.Objetivo = ""
    '            objEvolucion.Diagnostico = ""
    '            objEvolucion.Paraclinico = ""
    '            objEvolucion.PlanManejo = ""
    '            objEvolucion.Subjetivo = ""
    '            objEvolucion.Fecha = ""
    '            objEvolucion.NotasIngreso = ""
    '            MostrarEvolucion()
    '            Me.Txtinterconsulta.Visible = False
    '            Me.Label1.Visible = False
    '            RbEvolucion.Checked = True
    '            'Rbinterconsulta.Checked = False
    '        Else
    '            var1 = objEvolucion1.consultarEspecialidadInterconsulta(objConexion, objGeneral.Prestador, objGeneral.Sucursal,
    '                        objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision, objGeneral.Login, objGeneral.CodigoEspecialidad)
    '            If var1 = "SI" Then
    '                Me.Txtinterconsulta.Text = ""
    '                objEvolucion.Objetivo = ""
    '                objEvolucion.Diagnostico = ""
    '                objEvolucion.Paraclinico = ""
    '                objEvolucion.PlanManejo = ""
    '                objEvolucion.Subjetivo = ""
    '                objEvolucion.Fecha = ""
    '                objEvolucion.NotasIngreso = ""
    '                MostrarInterconsulta()
    '                Me.Txtinterconsulta.Visible = True
    '            Else
    '                If var1 = "NO" Then
    '                    strmedico = ""
    '                    strmotivo = ""
    '                    strEspecialidad = ""
    '                    Dim frminterconsulta As New frmc_Interconsulta(strmedico, strmotivo)
    '                    frminterconsulta.ShowDialog()
    '                    strmedico = frminterconsulta.strMedico
    '                    strmotivo = frminterconsulta.StrMotivo
    '                    strEspecialidad = frminterconsulta.strEspecialidad
    '                    Me.Txtinterconsulta.Text = ""
    '                    objEvolucion.Objetivo = ""
    '                    objEvolucion.Diagnostico = ""
    '                    objEvolucion.Paraclinico = ""
    '                    objEvolucion.PlanManejo = ""
    '                    objEvolucion.Subjetivo = ""
    '                    objEvolucion.Fecha = ""
    '                    objEvolucion.NotasIngreso = ""
    '                    MostrarInterconsulta()
    '                    Me.Txtinterconsulta.Visible = True
    '                End If
    '            End If
    '        End If
    '    End If
    'End Sub

#Region "AdicionarFila - Grilla - GrabarDiagnostico"

    Private Function ValidarCamposGrabacionEvolucion() As Boolean
        Dim blnRespuesta As Boolean

        blnRespuesta = True

        If (Me.TipoEvolucion = 0) Then
            MessageBox.Show("Debe seleccionar un tipo de Nota (Evolución, Ingreso o Inteconsulta).")
            blnRespuesta = False
            Return blnRespuesta
        End If



        Dim lstdiag As New List(Of Diagnostico)

        lstdiag = (From DIAG As Diagnostico In ctlDiagnostico.plstDiagnostico.ToList()
                   Where DIAG.CATEGORIA_DIAG = FuncionesGenerales.EnumDescription(Diagnostico.CategoriaDiagnostico.Principal) AndAlso
                       DIAG.IDESTADODIAGNOSTICO = Diagnostico.EstadoDiagnostico.Activo
                   Select DIAG).ToList()

        If lstdiag.Count <> 1 Then
            MessageBox.Show("En la grilla de diagnósticos debe haber un (1) diagnóstico Principal en estado Activo")

            blnRespuesta = False
            Return blnRespuesta
        End If

        If ValidarCamposObligatoriosEvo(pnlEvolucion) = False Then
            MessageBox.Show("Falta Información en Campo Obligatorio")
            blnRespuesta = False
            Return blnRespuesta
        End If

        If txtTipoEvolucion.Text.Trim.Length <= 0 Then
            Select Case TipoEvolucion
                'Case Evolucion.TipoEvolucion.Ingreso
                '    MessageBox.Show("Falta Información en Campo Obligatorio - Nota Ingreso.")
                '    txtTipoEvolucion.Focus()
                '    blnRespuesta = False
                '    Return blnRespuesta
                'Case Evolucion.TipoEvolucion.Interconsulta
                '    MessageBox.Show("Falta Información en Campo Obligatorio - Interconsulta.")
                '    txtTipoEvolucion.Focus()
                '    blnRespuesta = False
                '    Return blnRespuesta
            End Select

        End If


        If Not IsDate(mtFechaInicial.Text) Or mtFechaInicial.Text = "  /  /" Then
            MsgBox("Debe ingresar la fecha correctamente.")
            mtFechaInicial.Focus()
            blnRespuesta = False
            Return blnRespuesta
        End If

        'If tbSubjetivo.Text.Trim.Length <= 0 Then
        '    MessageBox.Show("Falta Información en Campo Obligatorio - Subjetivo")
        '    tbSubjetivo.Focus()
        '    blnRespuesta = False
        '    Return blnRespuesta
        'End If
        If pnlDatosEF.Enabled Then


            If (objPaciente.CodigoUnidadMedidaEdad = "A" And objPaciente.Edad >= 3) Then

                If txtSistoleEF.Text.Trim.Length <= 0 Then
                    MessageBox.Show("Falta Información en Campo Obligatorio - Tensión Arterial Sístole")
                    txtSistoleEF.Focus()
                    blnRespuesta = False
                    Return blnRespuesta
                End If

                If txtDiastoleEF.Text.Trim.Length <= 0 Then
                    MessageBox.Show("Falta Información en Campo Obligatorio - Tensión Arterial Diástole")
                    txtDiastoleEF.Focus()
                    blnRespuesta = False
                    Return blnRespuesta
                End If

            End If

            If txtFrecuenciaCardiacaEF.Text.Trim.Length <= 0 Then
                MessageBox.Show("Falta Información en Campo Obligatorio - Frecuencia Cardíaca")
                txtFrecuenciaCardiacaEF.Focus()
                blnRespuesta = False
                Return blnRespuesta
            End If

            If txtFrecuenciaRespiratoriaEF.Text.Trim.Length <= 0 Then
                MessageBox.Show("Falta Información en Campo Obligatorio - Frecuencia Respiratoria")
                txtFrecuenciaRespiratoriaEF.Focus()
                blnRespuesta = False
                Return blnRespuesta
            End If

            'If txtSatOxi.Text.Trim.Length <= 0 Then
            '    MessageBox.Show("Falta Información en Campo Obligatorio - Saturacion Oxigeno")
            '    txtSatOxi.Focus()
            '    blnRespuesta = False
            '    Return blnRespuesta
            'End If

            'If txtTemperaturaEF.Text.Trim.Length <= 0 Then
            '    MessageBox.Show("Falta Información en Campo Obligatorio - Temperatura")
            '    txtTemperaturaEF.Focus()
            '    blnRespuesta = False
            '    Return blnRespuesta
            'End If

            ' se retira obligatoriedad control de cambios ER_OSI_567
            'If txtPesoEF.Text.Trim.Length <= 0 Then
            '    MessageBox.Show("Falta Información en Campo Obligatorio - Peso")
            '    txtPesoEF.Focus()
            '    blnRespuesta = False
            '    Return blnRespuesta
            'End If

            If Cmbanalogadedolor.Text.Trim.Length = 0 Then
                MessageBox.Show("Falta Información en Campo Obligatorio - Escala de dolor")
                Cmbanalogadedolor.Focus()
                blnRespuesta = False
                Return blnRespuesta
            End If


            If txtCodEstadoConcienciaEF.Text.Trim.Length = 0 Or txtDescEstadoConcienciaEF.Text.Trim.Length = 0 Then
                MessageBox.Show("Falta Información en Campo Obligatorio - Estado de Conciencia")
                txtDescEstadoConcienciaEF.Focus()
                blnRespuesta = False
                Return blnRespuesta
            End If
        End If

        If tbObjetivo.Text.Trim.Length = 0 Then
            MessageBox.Show("Falta Información en Campo Obligatorio - Objetivo")
            tbObjetivo.Focus()
            blnRespuesta = False
            Return blnRespuesta
        End If

        'If tbParaclinicos.Text.Trim.Length <= 0 Then
        '    MessageBox.Show("Falta Información en Campo Obligatorio - Interpretación  Paraclínicos")
        '    tbParaclinicos.Focus()
        '    blnRespuesta = False
        '    Return blnRespuesta
        'End If

        If tbPlanManejo.Text.Trim.Length <= 0 Then
            MessageBox.Show("Falta Información en Campo Obligatorio - Plan de Manejo")
            tbPlanManejo.Focus()
            blnRespuesta = False
            Return blnRespuesta
        End If

        'If tbDiagnostico.Text.Trim.Length <= 0 Then
        '    MessageBox.Show("Falta Información en Campo Obligatorio - Diagnóstico Actual")
        '    tbDiagnostico.Focus()
        '    blnRespuesta = False
        '    Return blnRespuesta
        'End If

        If rdPlaManPrg1Si.Checked = False And rdPlaManPrg1No.Checked = False Then
            MsgBox("Falta Información en Campo Obligatorio - Explicación plan de manejo")
            'txtPlaManPrg1.Focus()
            blnRespuesta = False
            Return blnRespuesta
        End If

        If TipoEvolucion = Evolucion.TipoEvolucion.Interconsulta Then
            If rbtCierreIntConSI.Checked = False And rbtCierreIntConNo.Checked = False Then
                MsgBox("Falta Información en Campo Obligatorio - Cierre Interconsulta")
                'txtPlaManPrg1.Focus()
                blnRespuesta = False
                Return blnRespuesta
            End If

        End If

        Return blnRespuesta
    End Function
#End Region

#Region "Funciones Comunes Procesos evolucion"

    Private Function ValidarCamposObligatoriosEvo(ByVal ctlContenedor As Panel) As Boolean
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
#End Region

    ''' <summary>
    ''' Consulta Valores Inciales de la Historia Clínica y asigna valores 
    ''' en cada uno de los controles y objetos del Formulario
    ''' </summary>
    ''' <remarks></remarks>

#Region "ConsultarInterconsultas"
    Private Sub ConsultarInterconsultas()

        Dim lError As Long
        pInterconsulta = New ProcedimientoOM

        pInterconsulta.COD_PRE_SGS = objGeneral.Prestador
        pInterconsulta.COD_SUCUR = objGeneral.Sucursal
        pInterconsulta.TIP_ADMISION = objPaciente.TipoAdmision
        pInterconsulta.ANO_ADM = objPaciente.AnoAdmision
        pInterconsulta.NUM_ADM = objPaciente.NumeroAdmision
        pInterconsulta.ESPECIALIDAD = objGeneral.CodigoEspecialidad
        pInterconsulta.LOGIN = objGeneral.Login
        'Param(5) = objGeneral.Login

        Try

            plstInterconsulta = pInterconsulta.getInterconsultas(objConexion, lError, pInterconsulta)
            dgvInterconsultas.DataSource = plstInterconsulta

        Catch ex As Exception
            MsgBox("Error al consultar interconsultas", MsgBoxStyle.Exclamation)
        End Try

        If plstInterconsulta.Count > 0 Then

            For Each row As DataGridViewRow In dgvInterconsultas.Rows
                If row.Cells("CONTESTAIC").Value = 0 Then
                    row.[ReadOnly] = True
                    row.DefaultCellStyle.ForeColor = Color.Gray

                Else
                    row.[ReadOnly] = False
                    row.DefaultCellStyle.ForeColor = Color.Black
                End If
            Next
            dgvInterconsultas.Refresh()
        End If

    End Sub
#End Region



    Private Sub BtnRptCuidadoPaliativo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRptCuidadoPaliativo.Click
        Try
            'frmRepCuidadosPaliativos.Show()
            'frmRepCuidadosPaliativos.imprimirCuidadosPaliativos(objConexion, objGeneral.Prestador,
            'objGeneral.Sucursal, objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
            'objPaciente.TipoDocumento, objPaciente.NumeroDocumento)

            '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
            'Juan Carlos Jaramillo Lozano - IG
            RptHC_Enf_Med.Show()
            RptHC_Enf_Med.ImprimirHistoriaClinica_imprimirCuidadosPaliativos(objConexion, "47", objGeneral.Prestador, objGeneral.Sucursal,
                                                        objPaciente.TipoAdmision, objPaciente.AnoAdmision,
                                                        objPaciente.NumeroAdmision,
                                                        objPaciente.TipoDocumento, objPaciente.NumeroDocumento,
                                                         objPaciente.CodHistoria)
            '2019-03-11 Fin
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub RbEvolucion_CheckedChanged(sender As Object, e As EventArgs) Handles RbEvolucion.CheckedChanged
        If RbEvolucion.Checked = True Then
            MostrarEvolucion()
        End If
    End Sub

    Private Sub rbIngreso_CheckedChanged(sender As Object, e As EventArgs) Handles rbIngreso.CheckedChanged
        If rbIngreso.Checked = True Then
            MostrarIngreso()
        End If

    End Sub



    'Private Sub txtTipoEvolucion_Leave(sender As Object, e As EventArgs) Handles txtTipoEvolucion.Leave
    '    If txtTipoEvolucion.Text.Trim.Length = 0 Then
    '        txtTipoEvolucion.BackColor = Color.LightPink
    '    Else
    '        txtTipoEvolucion.BackColor = SystemColors.Window
    '    End If
    'End Sub

    'Private Sub tbSubjetivo_Leave(sender As Object, e As EventArgs) Handles tbSubjetivo.Leave
    '    If tbSubjetivo.Text.Trim.Length = 0 Then
    '        tbSubjetivo.BackColor = Color.LightPink
    '    Else
    '        tbSubjetivo.BackColor = SystemColors.Window
    '    End If
    'End Sub

    Private Sub txtSistoleEF_Leave(sender As Object, e As EventArgs) Handles txtSistoleEF.Leave
        Try

            If txtSistoleEF.Text.Trim.Length = 0 Then
                txtSistoleEF.BackColor = Color.LightPink
                Exit Sub
            Else
                txtSistoleEF.BackColor = SystemColors.Window
            End If

            If ValidadRangoSignosVitales(FuncionesGenerales.EnumDescription(SignosVitales.Abreviatura.Tensión_Arterial_Sistolica), txtSistoleEF.Text) Then
                txtSistoleEF.BackColor = SystemColors.Window
            Else
                txtSistoleEF.BackColor = Color.LightPink
                RangosValidos = False
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtDiastoleEF_Leave(sender As Object, e As EventArgs) Handles txtDiastoleEF.Leave
        Try

            If txtDiastoleEF.Text.Trim.Length = 0 Then
                txtDiastoleEF.BackColor = Color.LightPink
                Exit Sub
            Else
                txtDiastoleEF.BackColor = SystemColors.Window
            End If

            If ValidadRangoSignosVitales(FuncionesGenerales.EnumDescription(SignosVitales.Abreviatura.Tensión_Arterial_Diastolica), txtDiastoleEF.Text) Then
                txtDiastoleEF.BackColor = SystemColors.Window
            Else
                txtDiastoleEF.BackColor = Color.LightPink
                RangosValidos = False
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtFrecuenciaCardiacaEF_Leave(sender As Object, e As EventArgs) Handles txtFrecuenciaCardiacaEF.Leave
        Try
            If txtFrecuenciaCardiacaEF.Text.Trim.Length = 0 Then
                txtFrecuenciaCardiacaEF.BackColor = Color.LightPink
                Exit Sub
            Else
                txtFrecuenciaCardiacaEF.BackColor = SystemColors.Window
            End If

            If ValidadRangoSignosVitales(FuncionesGenerales.EnumDescription(SignosVitales.Abreviatura.Frecuencia_Cardiaca), txtFrecuenciaCardiacaEF.Text) Then
                txtFrecuenciaCardiacaEF.BackColor = SystemColors.Window
            Else
                txtFrecuenciaCardiacaEF.BackColor = Color.LightPink
                RangosValidos = False
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtFrecuenciaRespiratoriaEF_Leave(sender As Object, e As EventArgs) Handles txtFrecuenciaRespiratoriaEF.Leave
        Try
            If txtFrecuenciaRespiratoriaEF.Text.Trim.Length = 0 Then
                txtFrecuenciaRespiratoriaEF.BackColor = Color.LightPink
                Exit Sub
            Else
                txtFrecuenciaRespiratoriaEF.BackColor = SystemColors.Window
            End If

            If ValidadRangoSignosVitales(FuncionesGenerales.EnumDescription(SignosVitales.Abreviatura.Frecuencia_Respiratoria), txtFrecuenciaRespiratoriaEF.Text) Then
                txtFrecuenciaRespiratoriaEF.BackColor = SystemColors.Window
            Else
                txtFrecuenciaRespiratoriaEF.BackColor = Color.LightPink
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtSatOxi_Leave(sender As Object, e As EventArgs) Handles txtSatOxi.Leave
        Try

            'If txtSatOxi.Text.Trim.Length = 0 Then
            '    txtSatOxi.BackColor = Color.LightPink
            '    Exit Sub
            'Else
            '    txtSatOxi.BackColor = SystemColors.Window
            'End If
            If txtSatOxi.Text.Trim.Length > 0 Then
                If ValidadRangoSignosVitales(FuncionesGenerales.EnumDescription(SignosVitales.Abreviatura.Saturación_Oxígeno), txtSatOxi.Text) Then
                    txtSatOxi.BackColor = SystemColors.Window
                Else
                    txtSatOxi.BackColor = Color.LightPink
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtTemperaturaEF_Leave(sender As Object, e As EventArgs) Handles txtTemperaturaEF.Leave
        Try
            'If txtTemperaturaEF.Text.Trim.Length = 0 Then
            '    txtTemperaturaEF.BackColor = Color.LightPink
            '    Exit Sub
            'Else
            '    txtTemperaturaEF.BackColor = SystemColors.Window
            'End If
            If txtTemperaturaEF.Text.Trim.Length > 0 Then
                If ValidadRangoSignosVitales(FuncionesGenerales.EnumDescription(SignosVitales.Abreviatura.Temperatura), txtTemperaturaEF.Text) Then
                    txtTemperaturaEF.BackColor = SystemColors.Window
                Else
                    txtTemperaturaEF.BackColor = Color.LightPink
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cmbanalogadedolor_Leave(sender As Object, e As EventArgs) Handles Cmbanalogadedolor.Leave

        If Cmbanalogadedolor.Text.Trim.Length = 0 Then
            Cmbanalogadedolor.BackColor = Color.LightPink
        Else
            Cmbanalogadedolor.BackColor = SystemColors.Window
        End If

    End Sub
    Private Sub txtCodEstadoConcienciaEF_TextChanged(sender As Object, e As EventArgs) Handles txtCodEstadoConcienciaEF.TextChanged
        If txtCodEstadoConcienciaEF.Text.Trim.Length = 0 And txtDescEstadoConcienciaEF.Text.Trim.Length = 0 Then
            txtDescEstadoConcienciaEF.BackColor = Color.LightPink
            txtCodEstadoConcienciaEF.BackColor = Color.LightPink
        Else
            txtDescEstadoConcienciaEF.BackColor = SystemColors.Window
            txtCodEstadoConcienciaEF.BackColor = SystemColors.Window
        End If
    End Sub
    Private Sub txtDescEstadoConcienciaEF_Leave(sender As Object, e As EventArgs) Handles txtDescEstadoConcienciaEF.Leave
        If txtDescEstadoConcienciaEF.Text.Trim.Length = 0 And txtCodEstadoConcienciaEF.Text.Trim.Length = 0 Then
            txtDescEstadoConcienciaEF.BackColor = Color.LightPink
            txtCodEstadoConcienciaEF.BackColor = Color.LightPink
        Else
            txtDescEstadoConcienciaEF.BackColor = SystemColors.Window
            txtCodEstadoConcienciaEF.BackColor = SystemColors.Window
        End If
    End Sub
    Private Sub txtPesoEF_Leave(sender As Object, e As EventArgs) Handles txtPesoEF.Leave
        Dim strDescripcionIMC As String
        strDescripcionIMC = ""
        Try
            'If txtPesoEF.Text.Trim.Length = 0 Or Val(txtPesoEF.Text) = 0 Then
            '    txtPesoEF.BackColor = Color.LightPink
            '    txtPesoEF.ResetText()
            '    Exit Sub
            'Else
            '    txtPesoEF.BackColor = SystemColors.Window
            'End If

            If Val(txtPesoEF.Text) > 0 And Val(txtTallaEF.Text) > 0 Then
                txtValorIMCEF.Text = FuncionesGenerales.CalcularIndiceDeMasaCorporal(Val(txtPesoEF.Text), Val(txtTallaEF.Text), strDescripcionIMC)
                txtDescValorIMCEF.Text = strDescripcionIMC
            Else
                txtValorIMCEF.ResetText()
                txtDescValorIMCEF.ResetText()
            End If

            If objPaciente.CodigoUnidadMedidaEdad = "A" And objPaciente.Edad < 16 And objPaciente.CodigoUnidadMedidaEdad <> "D" And objPaciente.CodigoUnidadMedidaEdad <> "M" Then
                txtValorIMCEF.ResetText()
                txtDescValorIMCEF.ResetText()
            End If

            If objPaciente.CodigoUnidadMedidaEdad <> "A" Then
                txtValorIMCEF.ResetText()
                txtDescValorIMCEF.ResetText()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtTallaEF_Leave(sender As Object, e As EventArgs) Handles txtTallaEF.Leave
        Dim strDescripcionIMC As String
        strDescripcionIMC = ""
        Try
            If Val(txtPesoEF.Text) > 0 And Val(txtTallaEF.Text) > 0 Then
                txtValorIMCEF.Text = FuncionesGenerales.CalcularIndiceDeMasaCorporal(Val(txtPesoEF.Text), Val(txtTallaEF.Text), strDescripcionIMC)
                txtDescValorIMCEF.Text = strDescripcionIMC
            Else
                txtValorIMCEF.ResetText()
                txtDescValorIMCEF.ResetText()
            End If

            If objPaciente.CodigoUnidadMedidaEdad = "A" And objPaciente.Edad < 16 And objPaciente.CodigoUnidadMedidaEdad <> "D" And objPaciente.CodigoUnidadMedidaEdad <> "M" Then
                txtValorIMCEF.ResetText()
                txtDescValorIMCEF.ResetText()
            End If

            If objPaciente.CodigoUnidadMedidaEdad <> "A" Then
                txtValorIMCEF.ResetText()
                txtDescValorIMCEF.ResetText()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Function ValidadRangoSignosVitales(ByVal Abreviatura As String, ByVal Valor As Decimal) As Boolean
        Dim Datos() As Object
        Dim objActualizarAP As New BLHistoriaBasica
        Dim lError As Long
        Dim dtRangoValido As New DataTable

        ReDim Datos(4)
        Datos(0) = objPaciente.TipoDocumento
        Datos(1) = objPaciente.NumeroDocumento
        Datos(2) = Abreviatura
        Datos(3) = Valor
        Datos(4) = lError
        Try
            dtRangoValido = objActualizarAP.ValidaSignosVitales(objConexion, lError, Datos)
            If lError <> 0 Then
                MessageBox.Show("Error al validar rangos Signos vitales")
                RangosValidos = False
            Else
                If dtRangoValido.Rows.Count > 0 Then
                    RangosValidos = dtRangoValido.Rows(0)(0)
                Else
                    RangosValidos = False
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error al Grabar Datos Examen Físico")
        End Try

        Return RangosValidos
    End Function

    Private Sub dgvInterconsultas_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgvInterconsultas.CurrentCellDirtyStateChanged

        RemoveHandler dgvInterconsultas.CurrentCellDirtyStateChanged,
            AddressOf dgvInterconsultas_CurrentCellDirtyStateChanged
        Dim lstIntercon As New List(Of ProcedimientoOM)
        pInterconsulta = New ProcedimientoOM
        If TypeOf dgvInterconsultas.CurrentCell Is DataGridViewCheckBoxCell Then
            dgvInterconsultas.EndEdit()
            Dim Checked As Boolean = CType(dgvInterconsultas.CurrentCell.Value, Boolean)
            If Checked Then
                lstIntercon = (From Intercon As ProcedimientoOM In plstInterconsulta.ToList()
                               Where Intercon.NROORDEN = sender.CurrentRow.cells("NROORDEN").value.ToString() And
                                   Intercon.PROCEDIMIENTO = sender.CurrentRow.cells("PROCEDIMIENTO").value.ToString()
                               Select Intercon).ToList()
                'AndAlso DIAG.CATEGORIA_DIAG = sender.CurrentRow.cells("CATEGORIA_DIAG").value.ToString()
                'Select Case DIAG).ToList()

                'CCGUTIEREZ. 04/05/2020
                Dim strResidente As String
                Dim dtMedico As DataTable
                Dim objDAOGeneral As New DAOGeneral()

                dtMedico = objDAOGeneral.dtbMedicoResidente(objGeneral.Login.ToString())

                If dtMedico.Rows.Count > 0 Then
                    strResidente = Convert.ToString(dtMedico.Rows(0).Item(23))
                    If strResidente = "S" Then
                        MessageBox.Show("El Residente no está habilitado para responder interconsultas.")
                        Checked = False
                        dgvInterconsultas.Refresh()

                        For Each row As DataGridViewRow In dgvInterconsultas.Rows
                            Dim cell As New DataGridViewCheckBoxCell
                            cell = row.Cells(0)
                            If dgvInterconsultas.CurrentCell.RowIndex <> row.Index Then
                                cell.Value = False
                            End If
                        Next

                        AddHandler dgvInterconsultas.CurrentCellDirtyStateChanged,
                            AddressOf dgvInterconsultas_CurrentCellDirtyStateChanged

                        Exit Sub
                    End If
                End If


                RbEvolucion.Checked = False
                rbIngreso.Checked = False

                If lstIntercon.Count = 1 Then
                    If lstIntercon(0).CONTESTAIC = 1 Then

                        VerInterconsultaNP()

                        pnlEvolucion.Visible = True
                        pnlTitDiaReg.Visible = True
                        ctlDiagnostico.Visible = True
                        pnlEvolucion.Enabled = True
                        pnlTitDiaReg.Enabled = True
                        ctlDiagnostico.Enabled = True
                        ctlDiagnostico.ResetText()
                        ctlDiagnostico.LoadControl()
                        pInterconsulta = lstIntercon(0)

                        For Each row As DataGridViewRow In dgvInterconsultas.Rows
                            Dim cell As New DataGridViewCheckBoxCell
                            cell = row.Cells(0)
                            If dgvInterconsultas.CurrentCell.RowIndex <> row.Index Then
                                cell.Value = False
                            End If
                        Next

                        TipoEvolucion = Evolucion.TipoEvolucion.Interconsulta
                        lblTitEvolucion.Text = "INTERCONSULTA"
                        lblTipEvolucion.Text = "Interconsulta"
                        lblTipEvolucion.Visible = True
                        txtTipoEvolucion.Visible = True
                        txtTipoEvolucion.Enabled = True
                        grbCerrarInterconsulta.Visible = True
                        loadSignosVitales()
                    Else

                        pnlEvolucion.Enabled = False
                        pnlTitDiaReg.Enabled = False
                        ctlDiagnostico.Enabled = False

                        For Each row As DataGridViewRow In dgvInterconsultas.Rows
                            Dim cell As New DataGridViewCheckBoxCell
                            cell = row.Cells(0)
                            If dgvInterconsultas.CurrentCell.RowIndex <> row.Index Then
                                cell.Value = False
                            End If
                        Next
                        If lstIntercon(0).LOGIN = objGeneral.Login Then
                            MessageBox.Show("No es posible responder una interconsulta que fue generada por el mismo usuario.")
                        Else
                            MessageBox.Show("Este perfil no está habilitado para responder interconsultas.")
                        End If
                    End If

                Else

                    pnlEvolucion.Enabled = False
                    pnlTitDiaReg.Enabled = False
                    ctlDiagnostico.Enabled = False

                End If
            Else
                'CCGUTIEREZ. 07/05/2020
                Me.rbInterconNP.Visible = False
                Me.rbInterconNP.Checked = False
            End If
        End If

        AddHandler dgvInterconsultas.CurrentCellDirtyStateChanged,
            AddressOf dgvInterconsultas_CurrentCellDirtyStateChanged
    End Sub

    Private Function ValidarFinalizarHcb() As Boolean
        Dim objFinalizarHcb As New BLHistoriaBasica

        Dim Datos() As Object
        Dim lExistencia As Long
        Dim dtExistencia As DataTable

        ReDim Datos(4)
        Datos(0) = objGeneral.Prestador
        Datos(1) = objGeneral.Sucursal
        Datos(2) = objPaciente.TipoAdmision
        Datos(3) = objPaciente.AnoAdmision
        Datos(4) = objPaciente.NumeroAdmision

        Try

            dtExistencia = objFinalizarHcb.NVALIDAGRABACIONFINALHcb(objConexion, lExistencia, Datos)
            If dtExistencia.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Error Validacion Finalizar Historia Basica")
        End Try
    End Function

    Private Sub dvEvolucion_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dvEvolucion.CellContentClick
        Dim senderGrid = DirectCast(sender, DataGridView)

        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewImageColumn AndAlso
           e.RowIndex >= 0 Then
            RptHC.ImprimirEvolucion(objConexion, objGeneral.Prestador,
                                                  objGeneral.Sucursal, objPaciente.TipoAdmision,
                                                  objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                  objPaciente.TipoDocumento, objPaciente.NumeroDocumento,
                                                  objGeneral.NombreMedico, objPaciente.CodHistoria, 'Joseph Moreno (IG) Fec:2019/07/11 Cambio Traido de Branch Dev-RPT 
                                    Format(CDate(sender.currentrow.Cells("Fecha_Evol").Value.ToString), "yyyy-MM-dd HH:mm"),
                                    Format(CDate(sender.currentrow.Cells("Fecha_Evol").Value.ToString), "yyyy-MM-dd HH:mm"))
            RptHC.ShowDialog()
            RptHC.Close()
        ElseIf TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewLinkColumn Then 'Joseph Moreno (IG) Fec: 2019-06-10 Link Enlace CSH
            If sender.CurrentRow.Cells(e.ColumnIndex).Value.ToString() <> "" Then
                Process.Start(sender.CurrentRow.Cells(e.ColumnIndex).Value.ToString())
            End If
        End If
    End Sub

    Private Sub tbObjetivo_Leave(sender As Object, e As EventArgs) Handles tbObjetivo.Leave
        If tbObjetivo.Text.Trim.Length = 0 Then
            tbObjetivo.BackColor = Color.LightPink
            Exit Sub
        Else
            tbObjetivo.BackColor = SystemColors.Window
        End If
    End Sub

    Private Sub tbPlanManejo_Leave(sender As Object, e As EventArgs) Handles tbPlanManejo.Leave
        If tbPlanManejo.Text.Trim.Length = 0 Then
            tbPlanManejo.BackColor = Color.LightPink
            Exit Sub
        Else
            tbPlanManejo.BackColor = SystemColors.Window
        End If
    End Sub

    Private Sub PnlNota_DoubleClick(sender As Object, e As EventArgs) Handles PnlNota.DoubleClick
        '--CCGUTIEREZ. 29/04/2020 
        Me.rbInterconNP.Checked = False
    End Sub

    Private Sub dgvInterconsultas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInterconsultas.CellContentClick

    End Sub
End Class
