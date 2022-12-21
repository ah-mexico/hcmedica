Imports System.Linq
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports System.Math
Imports HistoriaClinica.Sophia.HistoriaClinica.Util
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports System.IO
Imports HistoriaClinica.Mail
Imports System.Net.Mail
Imports objGenerales = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales

Public Class ctlConcilMedicamentos
    Public datosSinAlmacenar As Boolean = False
    Private datosPaciente As Paciente
    Public _MedicamentosConcil As MedicamentosConciliados
    Private _MedicamentosConcilOtros As MedicamentosConciliadosOtros
    Private _MedicamentosConcilSus As MedicamentosConciliadosSusp
    Public valorContinuar As Object 'String = String.Empty
    Public valorModificar As String = String.Empty
    Public valorSuspender As Object ' = String.Empty
    Private m_validado As Boolean = True
    Private NroOrdenOrigen As Double
    '.....................................Verdadero, Falso 
    Public valoresContinuar As String() = {"C", "S"}
    Public valoresModificar As String() = {"M", "N"}
    Public valoresSuspender As String() = {"S", "C"}
    Dim InicioSesion As DateTime
    Public falg_modificar As Integer = 0
    Private objDao As New DAOGeneral
    Public flagNOPOS As Boolean = False
    Public VariableGrillaSeleccionada


    Public flagCONTROL As Boolean = False

    Public flaglimpiacampos As Boolean = True
    ''' <summary>
    ''' Datos generales que se pasan como parametro desde sophia.
    ''' Dentro de estos datos encontramos el codigo del prestador, 
    ''' el codigo de la sucursal, el login, etc..
    ''' </summary>
    ''' <remarks></remarks>
    Private datosLogin As Generales
    ''' <summary>
    ''' Datos necesarios para establecer una conexion a la base
    ''' de Datos. Dentro de estos datos esta el nombre del servidor, 
    ''' el nombre de la base de datos, el usuario y el password.
    ''' </summary>
    ''' <remarks></remarks>
    Private datosConexion As Conexion
    Public intload As Integer = 0
    Public intloadotros As Integer = 0
    Public intloadSus As Integer = 0
    Public Shared _Instancia As ctlConcilMedicamentos
    Private ErrorModulo As String
    Public op_TipoServ As RadioButton
    Public op_PrioSI As RadioButton
    Public dtaux As String
    Public dtaux2 As String



    ''' <summary>
    ''' Variable de tipo OrdenMedica que guarda la informacion cargada
    ''' en las grillas (Dietas, Medicamentos y Ordenes Generales) y permite 
    ''' tener la informacion de las ordenes medicas para evitar consultar
    ''' la base de datos cada vez que se cargue el control dentro de la 
    ''' misma historia clinica. Esta clase es un sigleton y se crea al 
    ''' cargar la primera vez el control.
    ''' Estos datos se actualizan conforme a los cambios hechos por el 
    ''' usuario.
    ''' </summary>
    ''' <remarks></remarks>
    Private _Ordenes As OrdenMedica

    ''' <summary>
    ''' Numero de caracteres del documento xml que encapsula la 
    ''' informacion de las Dietas. Este documento se envia 
    ''' al stored procedure que realiza el proceso de grabacion.
    ''' Se usa para controlar el tamaño del documento que no puede superar
    ''' los 8000 caracteres
    ''' </summary>
    ''' <remarks></remarks>
    Private _tamanoXmlDietas As Integer

    ''' <summary>
    ''' Numero de caracteres del documento xml que encapsula la 
    ''' informacion de los medicamentos. Este documento se envia 
    ''' al stored procedure que realiza el proceso de grabacion.
    ''' Se usa para controlar el tamaño del documento que no puede superar
    ''' los 8000 caracteres
    ''' </summary>
    ''' <remarks></remarks>
    Private _tamanoXmlMedica As Integer

    ''' <summary>
    ''' Numero de caracteres del documento xml que encapsula la 
    ''' informacion de los procedimientos. Este documento se envia 
    ''' al stored procedure que realiza el proceso de grabacion.
    ''' Se usa para controlar el tamaño del documento que no puede superar
    ''' los 8000 caracteres
    ''' </summary>
    ''' <remarks></remarks>
    Private _tamanoXmlProcedim As Integer

    ''' <summary>
    ''' Numero de caracteres del documento xml que encapsula la 
    ''' informacion de las ordenes generales. Este documento se envia 
    ''' al stored procedure que realiza el proceso de grabacion.
    ''' Se usa para controlar el tamaño del documento que no puede superar
    ''' los 8000 caracteres
    ''' </summary>
    ''' <remarks></remarks>
    Private _tamanoXmlOGeneral As Integer

    ''' <summary>
    ''' Variable que determinara si es necesario enviar el mensaje,
    ''' determinando que no se han almacenado datos del formulario.
    ''' </summary>
    ''' <remarks></remarks>

    Public datosSinAlmacenarDieta As Boolean = False



    Private Sub inicializaVariables()
        _tamanoXmlDietas = 57
        _tamanoXmlMedica = 57
        _tamanoXmlProcedim = 0
        _tamanoXmlOGeneral = 57
        datosSinAlmacenar = False
        datosSinAlmacenarDieta = False
    End Sub
    Public Shared ReadOnly Property Instancia() As ctlConcilMedicamentos
        Get
            If _Instancia Is Nothing Then
                _Instancia = New ctlConcilMedicamentos
            End If


            Return _Instancia
        End Get
    End Property

    Private Sub ctlConcilMedicamentos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrar()
        configurarComboMedicamentos()
        CargarUnidadMedida()
        CargarViasAdministracion()
        CargarFrecuencia()



    End Sub

    Public Function mostrar()
        Dim dtmedic As DataTable
        datosLogin = Generales.Instancia()
        datosPaciente = Paciente.Instancia()
        datosConexion = Conexion.Instancia()

        _MedicamentosConcil = MedicamentosConciliados.Instancia()
        _MedicamentosConcilOtros = MedicamentosConciliadosOtros.Instancia()
        _MedicamentosConcilSus = MedicamentosConciliadosSusp.Instancia()

        _Ordenes = OrdenMedica.Instancia()
        intload = 0
        intloadSus = 0
        intloadotros = 0


        cargarGrillas()

        Me.InicioSesion = FuncionesGenerales.FechaServidor()
    End Function



    Private Function ValidarDatosHisBasica() As Boolean
        ' Válidar si los datos de Historia Básica se encuentran grabados
        ' eloaiza@intergrupo.com
        ' Req. ER_OSI_584

        'Dim objPaciente As Object = Me.Parent.Parent.Controls("pnlContenedorDatosPaciente").Controls("ctlDatosPaciente")
        'ctlPaciente = CType(objPaciente, ctlDatosPaciente)

        'ojo revisar hcbasica
        'Dim objHistoriaBasica As Object = Me.Parent.Controls("HCBasica") 'Me.Parent.Parent.Controls("pnlContenedorDatosPaciente").Controls("ctlHCBasica")
        'ctlHistoria = CType(objHistoriaBasica, HCBasica)

        ''Dim objDatosPaciente As Paciente = ctlPaciente.ObjetoPaciente
        'Dim objDatosPaciente As Paciente = Paciente.Instancia
        'Dim objDatosHisBasica As DatosHistoriaBasica = ctlHistoria.objHistoriaBasica
        ''objDatosHisBasica.MotivoDeConsulta.MotivoDeConsulta = "dfasdfasfasfasdf"

        'If objDatosPaciente.TipoAdmision <> "P" Then
        '    If (String.IsNullOrEmpty(objDatosHisBasica.MotivoDeConsulta.EnfermedadActual.ToString().Trim()) Or
        '        String.IsNullOrEmpty(objDatosHisBasica.MotivoDeConsulta.MotivoDeConsulta.ToString().Trim()) And
        '        Not ValidarFinalizarHcb()) Then
        '        MessageBox.Show("Debe diligenciar primero Historia Básica de Ingreso del paciente")
        '        ctlPaciente.Visible = True
        '        ctlPaciente.Focus()
        '        Return False
        '    End If
        'End If

        Dim AdmDestino As String

        AdmDestino = datosLogin.ValidadAdmTrasladada(datosConexion, datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.TipoAdmision,
                                              datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision)

        If AdmDestino <> datosPaciente.TipoAdmision.ToString & "-" &
                                              datosPaciente.AnoAdmision.ToString & "-" & datosPaciente.NumeroAdmision.ToString Then

            MessageBox.Show("El paciente ha sido trasladada a está  admisión " & AdmDestino &
                                        ", debe buscarlo en la Lista de Espera.", "Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Information)
            frmHistoriaPrincipal.pintarMenu(frmHistoriaPrincipal.OpcionesMenu.ListaEspera)
            frmHistoriaPrincipal.CargarListaEspera()
            Return True

        End If

        ''Inicia: CCGUTIEREZ - OSI. 28/01/2020
        ''Proyecto: Sophia - Codificacion
        ''Cambio: Se muestran las particularidades de acuerdo al Centro de Costo y el parametro " man_csh "
        'If txtCodProcedim.Text <> String.Empty Then
        '    Me.ctlPartProce.PasarDatos(
        '    txtCodProcedim.Text, cmbDescripProcedim.Text,
        '    Sub(ByVal strDescripcionTotal As String, ByVal iCantidad As String, ByVal strXmlParticularidades As String, ByVal strXmlProcedimientos As String)
        '        ActualizarTextoDescripcionCantidad(strDescripcionTotal, iCantidad)
        '    End Sub)
        'Else
        '    Exit Sub
        'End If
        ''Fin. CCGUTIEREZ



    End Function


    Private Sub cmbDescripMedica_ActualizarDatosElegidos(ByVal datosElegidos As System.Data.DataRow) Handles cmbDescripMedica.ActualizarDatosElegidos
        If datosElegidos Is Nothing Then
            txtDosis.Text = ""
            ''cmbUnidadMedida.Text = ""
            txtDescripcionUM.Text = String.Empty
            'cmbViaAdmin.Text = ""
            txtDescripcionVA.Text = String.Empty
            'txtCodigoFreq.Text = ""
            txtDescripcionFreq.Text = ""
            txtTecnica.Text = ""
            Exit Sub
        End If

        Me.GroupCnt24.Visible = False
        With datosElegidos
            ''txtDosis.Text = IIf(IsDBNull(.Item("contenido")), "", .Item("contenido"))
            If .Item("contenido").ToString <> "0" Then
                ''  txtDosis.Text = .Item("contenido").ToString rcruzr corrección alm 57 20200122
            Else
                txtDosis.ResetText()
            End If
            'cmbUnidadMedida.Text = .Item("descrConcentracion").ToString
            txtDosis.ResetText()

            ''Claudia Garay Noviembre 17 de 2010
            ''Cambio de combo de unidad de medida y via de administracion por textbox con formato
            txtDescripcionUM.Text = .Item("descrConcentracion").ToString
            txtDescripcionVA.Text = .Item("descrVia").ToString
            'cmbViaAdmin.Text = .Item("descrVia").ToString
            'txtCodigoFreq.Text = .Item("frecuencia").ToString
            txtDescripcionFreq.Text = .Item("descrFrecuencia").ToString
            txtTecnica.Text = .Item("obs").ToString
            txtDosis.Focus()
            Me.lblDiasTrat.Visible = False
            Me.txtDiasTrat.Visible = False
            Me.flagNOPOS = False
            Me.flagCONTROL = False

            If .Item("flag_pos").ToString = "N" Then  'And datosPaciente.TipoEntidad = "EPS" Then
                'MsgBox("El medicamento elegido es no POS deberá diligenciar la Justificación de Uso para CTC", MsgBoxStyle.Information)
                Me.flagNOPOS = True
                Me.lblDiasTrat.Visible = True
                Me.txtDiasTrat.Visible = True
                Me.txtDiasTrat.Text = ""
            End If
            If .Item("MedControl").ToString = "S" Then
                Me.flagCONTROL = True
                Me.GroupCnt24.Visible = True
                Me.GroupCnt24.Enabled = True
                Me.txtCantidadC.Enabled = True
                Me.lblCantLetras.Enabled = True
                Me.lblCantidadC.Enabled = True
                txtCantidadC.Text = String.Empty
                txtCantidadLetras.Text = String.Empty
            End If

        End With
    End Sub




    Public Sub CargarViasAdministracion()
        With txtDescripcionVA
            .DataSource = BLOrdenes.consultarViasAdmin(datosConexion)
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

    Public Sub CargarUnidadMedida()

        'With txtCodigoUM
        '    .ControlComboEnlace = txtDescripcionUM
        '    .NombreCampoBuscado = "descripcion"
        '    .NombreCampoBusqueda = "concentracion"
        'End With

        With txtDescripcionUM
            .DataSource = BLOrdenes.consultarUnidadMedida(datosConexion)
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

    Public Sub CargarFrecuencia()

        With txtDescripcionFreq
            .DataSource = BLOrdenes.consultarFrecuencia(datosConexion)
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

    Public Sub configurarComboMedicamentos()
        cmbDescripMedica.BeginUpdate()
        txtCodMedica.ControlComboEnlace = cmbDescripMedica

        With cmbDescripMedica
            .CampoMostrar = "descripcion"
            .ControlTextoEnlace = txtCodMedica
            .CampoEnlazado = "codigo"
            .CategoriaDatos = CategoriaDatos.OrdenMedicamentosDescripcion
            .CargarDatos()
            .CargarButton()
        End With
        cmbDescripMedica.EndUpdate()
    End Sub

    Private Sub ComportamientoReformular(ByVal IndiceFilaSeleccionada As Integer, ByVal tratamiento As String, ByVal flag_sispro As String)
#Region "Reformular"
        ' Limpiar datos previos
        txtCodMedica.Text = String.Empty
        ' txtCodMedica.Enabled = True
        cmbDescripMedica.Text = String.Empty
        cmbDescripMedica.Enabled = True
        txtDosis.Text = String.Empty
        txtDescripcionUM.Text = String.Empty
        txtDescripcionUM.SelectedValue = String.Empty
        txtDescripcionVA.Text = String.Empty
        txtDescripcionVA.SelectedValue = String.Empty
        txtDescripcionFreq.Text = String.Empty
        txtDescripcionFreq.SelectedValue = String.Empty

        Dim dtDatos As DataTable = dgtMedicaConcil.DataSource
        Dim dtcmbFRE As New DataTable
        Dim rows() As DataRow
        Dim flagCambio As Boolean = False
        Dim valorCelda As String = dgtMedicaConcil.CurrentCell.Value.ToString()

        dgtMedicaConcil.CurrentCell.Value = System.DBNull.Value

        BLOrdenes.actualizarEstado(dtDatos.Rows(IndiceFilaSeleccionada), BLOrdenes.CONTINUA, dgtMedicaConcil.CurrentCell.Value, flag_sispro)

        'dtgMedicamentos.CurrentCell.Value = Nothing
        'If Not dtgMedicamentos.CurrentCell.Value = Nothing Then
        '    If dtDatos.Rows(IndiceFilaSeleccionada)("tratamiento") = "C" Then
        '        flagCambio = True
        '        dtgMedicamentos.CurrentCell.Value = "S"
        '        dtDatos.Rows(IndiceFilaSeleccionada)("tratamiento") = "S"
        '    End If
        'End If

        Me.datosSinAlmacenar = True
        'Else
        'BLOrdenes.deshacerActualizacionEstado(dtDatos.Rows(IndiceFilaSeleccionada))
        'End If
        Dim chkContinuar As DataGridViewCheckBoxCell = DirectCast(dgtMedicaConcil.Rows(IndiceFilaSeleccionada).Cells("modificar_med"), DataGridViewCheckBoxCell)

        Dim chkSuspender As DataGridViewCheckBoxCell = DirectCast(dgtMedicaConcil.Rows(IndiceFilaSeleccionada).Cells("suspender_med"), DataGridViewCheckBoxCell)

        chkContinuar.Value = valorCelda

        'GroupCnt24.Visible = False
        'lblCantidadC.Visible = False
        'txtCantidadC.Visible = False
        'lblCantLetras.Visible = False
        'txtCantidadLetras.Visible = False

        If dgtMedicaConcil.CurrentCell.Value = "C" Then

            If dtDatos.Rows(IndiceFilaSeleccionada)("Frecuencia") = "47" Then
                ' MsgBox("Debe generar una nueva orden para este medicamento", MsgBoxStyle.Information) ' a Solicitud del negocio Diana Cucaita y Nayibe ALM 137 no se debe mostrar el mensaje 20200310 Raul Cruz ajuste
                txtCodMedica.Text = String.Empty
                'txtCodMedica.Enabled = True
                cmbDescripMedica.Text = String.Empty
                cmbDescripMedica.Enabled = True
                txtDosis.Text = String.Empty
                txtDescripcionUM.Text = String.Empty
                txtDescripcionUM.SelectedValue = String.Empty
                txtDescripcionVA.Text = String.Empty
                txtDescripcionVA.SelectedValue = String.Empty
                txtDescripcionFreq.Text = String.Empty
                txtDescripcionFreq.SelectedValue = String.Empty
                dgtMedicaConcil.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = chkSuspender.TrueValue
                dgtMedicaConcil.CurrentCell.Value = chkContinuar.FalseValue
                dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_suspender_med") = chkSuspender.TrueValue
                dtDatos.Rows(IndiceFilaSeleccionada).Item("tratamiento") = chkContinuar.FalseValue
                'dtDatos.AcceptChanges()
                dgtMedicaConcil.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = chkSuspender.FalseValue
                dgtMedicaConcil.Rows(IndiceFilaSeleccionada).Cells("motivosus").Value = String.Empty
                dgtMedicaConcil.Rows(IndiceFilaSeleccionada).Cells("modificar_med").Value = chkContinuar.FalseValue
                'dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("continuar_med"). = False
                dgtMedicaConcil.Update()
                dgtMedicaConcil.RefreshEdit()
                Exit Sub
            End If

            'No se deben mostrar los controles al reformular. NICRUZ. 07/07/2020
            'If dtDatos.Rows(IndiceFilaSeleccionada).Item("MedControl") = "S" And Not IsDBNull(dtDatos.Rows(IndiceFilaSeleccionada).Item("cantidadcontrol")) And Not IsDBNull(dtDatos.Rows(IndiceFilaSeleccionada).Item("cantidadletrascontrol")) Then
            '    GroupCnt24.Visible = True
            '    txtCantidadC.Visible = True
            '    txtCantidadLetras.Visible = True
            '    txtCantidadC.Text = dtDatos.Rows(IndiceFilaSeleccionada).Item("cantidadcontrol")
            '    txtCantidadLetras.Text = dtDatos.Rows(IndiceFilaSeleccionada).Item("cantidadletrascontrol")
            'End If

            If dtDatos.Rows(IndiceFilaSeleccionada).Item("MedControl") = "S" Then
                'If MsgBox("¿Desea imprimir la fórmula de control?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                '    GroupBox1.Enabled = True
                'Else
                '    GroupBox1.Enabled = False
                'End If
            End If

            dgtMedicaConcil.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = chkSuspender.FalseValue
            dgtMedicaConcil.Rows(IndiceFilaSeleccionada).Cells("motivosus").Value = String.Empty

            'If dtDatos.Rows(IndiceFilaSeleccionada).Item("autoSISPRO").ToString <> "" Then
            '    Dim daoGeneral As New DAOGeneral
            '    Dim pag_SISPRO As String
            '    Dim cod_Sispro As String = ""
            '    pag_SISPRO = daoGeneral.EjecutarSQLStrValor("pargener (nolock)", datosConexion, " pagsispro", " cod_pre_sgs='" & datosLogin.Prestador & "'")
            '    System.Diagnostics.Process.Start(pag_SISPRO)
            '    frm_SISPRO.Mostrar(cod_Sispro)
            '    cod_Sispro = frm_SISPRO.Cod_SISPRO1
            '    dtDatos.Rows(IndiceFilaSeleccionada).Item("autoSISPRO") = cod_Sispro
            'End If

            If dtDatos.Rows(IndiceFilaSeleccionada).Item("diastrat") > 0 Then

                If flag_sispro = "S" Then
                    BLOrdenes.actualizarEstado(dtDatos.Rows(IndiceFilaSeleccionada), BLOrdenes.CONTINUA, dgtMedicaConcil.CurrentCell.Value, flag_sispro)
                    MsgBox("No puede continuar con el medicamento porque supera los días de tratamiento, debe modificarlo", MsgBoxStyle.Information)
                    txtCodMedica.Text = String.Empty
                    ' txtCodMedica.Enabled = True
                    cmbDescripMedica.Text = String.Empty
                    cmbDescripMedica.Enabled = True
                    txtDosis.Text = String.Empty
                    txtDescripcionUM.Text = String.Empty
                    txtDescripcionUM.SelectedValue = String.Empty
                    txtDescripcionVA.Text = String.Empty
                    txtDescripcionVA.SelectedValue = String.Empty
                    txtDescripcionFreq.Text = String.Empty
                    txtDescripcionFreq.SelectedValue = String.Empty
                    dgtMedicaConcil.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = chkSuspender.TrueValue
                    dgtMedicaConcil.CurrentCell.Value = chkContinuar.FalseValue
                    dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_suspender_med") = chkSuspender.TrueValue
                    dtDatos.Rows(IndiceFilaSeleccionada).Item("tratamiento") = chkContinuar.FalseValue
                    'dtDatos.AcceptChanges()
                    dgtMedicaConcil.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = chkSuspender.TrueValue
                    dgtMedicaConcil.Rows(IndiceFilaSeleccionada).Cells("modificar_med").Value = chkContinuar.FalseValue
                    dgtMedicaConcil.Update()
                    dgtMedicaConcil.RefreshEdit()
                    Exit Sub
                Else
                    For i As Integer = 0 To dtDatos.Rows.Count - 1
                        If dtDatos.Rows(i).Item("obs") = "M" Then
                            dtDatos.Rows(i).Item("obs") = ""
                        End If
                    Next

                    'If Not IsDBNull(dtgMedicamentos.CurrentCell.Value) Then
                    '    If dtgMedicamentos.CurrentCell.Value = "S" Then
                    '        dtgMedicamentos.CurrentCell.Value = "C"
                    '        dtDatos.Rows(IndiceFilaSeleccionada).Item("obs") = ""
                    '    Else
                    '        dtgMedicamentos.CurrentCell.Value = "S"
                    '        dtDatos.Rows(IndiceFilaSeleccionada).Item("obs") = ""
                    '    End If
                    'End If

                    BLOrdenes.actualizarEstado(dtDatos.Rows(IndiceFilaSeleccionada), BLOrdenes.CONTINUA, dgtMedicaConcil.CurrentCell.Value, flag_sispro)
                    If dtDatos.Rows(IndiceFilaSeleccionada).Item("obs") = "M" Then
                        'MostrarInforMedSispro(IndiceFilaSeleccionada)
                    Else
                        txtCodMedica.Text = String.Empty
                        ' txtCodMedica.Enabled = True
                        cmbDescripMedica.Text = String.Empty
                        cmbDescripMedica.Enabled = True
                        txtDosis.Text = String.Empty
                        txtDescripcionUM.Text = String.Empty
                        txtDescripcionUM.SelectedValue = String.Empty
                        txtDescripcionVA.Text = String.Empty
                        txtDescripcionVA.SelectedValue = String.Empty
                        txtDescripcionFreq.Text = String.Empty
                        txtDescripcionFreq.SelectedValue = String.Empty
                    End If

                End If

            End If
        Else

            For i As Integer = 0 To dtDatos.Rows.Count - 1
                If dtDatos.Rows(i).Item("obs") = "M" Then
                    dtDatos.Rows(i).Item("obs") = ""
                End If
            Next

            If Not IsDBNull(dgtMedicaConcil.CurrentCell.Value) Then
                If dgtMedicaConcil.CurrentCell.Value = "S" And Not flagCambio Then
                    ' dtgMedicamentos.CurrentCell.Value = "C" pilas raul validar que pasa sin esto
                    dtDatos.Rows(IndiceFilaSeleccionada).Item("obs") = ""
                Else
                    dgtMedicaConcil.CurrentCell.Value = "S"
                    dtDatos.Rows(IndiceFilaSeleccionada).Item("obs") = "M"
                End If
            End If

        End If

        BLOrdenes.actualizarEstado(dtDatos.Rows(IndiceFilaSeleccionada), BLOrdenes.CONTINUA, dgtMedicaConcil.CurrentCell.Value, flag_sispro)

        If dtDatos.Rows(IndiceFilaSeleccionada).Item("obs") = "M" And dgtMedicaConcil.CurrentCell.Value = "C" Then
            MostrarInforMedSispro(IndiceFilaSeleccionada)
        ElseIf dtDatos.Rows(IndiceFilaSeleccionada).Item("obs") = "M" Then
            ' MostrarInforMedSispro(IndiceFilaSeleccionada)
        Else
            txtCodMedica.Text = String.Empty
            ' txtCodMedica.Enabled = True
            cmbDescripMedica.Text = String.Empty
            cmbDescripMedica.Enabled = True
            txtDosis.Text = String.Empty
            txtDescripcionUM.Text = String.Empty
            txtDescripcionUM.SelectedValue = String.Empty
            txtDescripcionVA.Text = String.Empty
            txtDescripcionVA.SelectedValue = String.Empty
            txtDescripcionFreq.Text = String.Empty
            txtDescripcionFreq.SelectedValue = String.Empty
        End If

        'End If

        dtcmbFRE = txtDescripcionFreq.DataSource
        rows = dtcmbFRE.Select("frecuencia='" & (dtDatos.Rows(IndiceFilaSeleccionada)("Frecuencia")) & "'")

        ''If Not dtgMedicamentos.CurrentCell.Value = Nothing Then
        'If dtDatos.Rows(IndiceFilaSeleccionada)("Frecuencia") = "31" _
        '   Or dtDatos.Rows(IndiceFilaSeleccionada)("Frecuencia") = "43" _
        '   Or dtDatos.Rows(IndiceFilaSeleccionada)("Frecuencia") = "48" _
        '   Or dtDatos.Rows(IndiceFilaSeleccionada)("Frecuencia") = "49" _
        '   Or dtDatos.Rows(IndiceFilaSeleccionada)("Frecuencia") = "50" _
        '   Or rows.Length = 0 Then

        '    BLOrdenes.actualizarEstado(dtDatos.Rows(IndiceFilaSeleccionada), BLOrdenes.CONTINUA, dtgMedicamentos.CurrentCell.Value, flag_sispro)
        '    If dtgMedicamentos.CurrentCell.Value = "C" Then
        '        MsgBox("Debe volver a realizar la prescripción de este medicamento/líquido", MsgBoxStyle.Information)
        '    End If

        '    txtCodMedica.Text = String.Empty
        '    txtCodMedica.Enabled = True
        '    cmbDescripMedica.Text = String.Empty
        '    cmbDescripMedica.Enabled = True
        '    txtDosis.Text = String.Empty
        '    txtTecnica.Text = String.Empty
        '    txtDescripcionUM.Text = String.Empty
        '    txtDescripcionUM.SelectedValue = String.Empty
        '    txtDescripcionVA.Text = String.Empty
        '    txtDescripcionVA.SelectedValue = String.Empty
        '    txtDescripcionFreq.Text = String.Empty
        '    txtDescripcionFreq.SelectedValue = String.Empty
        'End If
        dgtMedicaConcil.CurrentCell.Value = valorCelda
        dgtMedicaConcil.RefreshEdit()
#End Region
    End Sub

    Private Sub MostrarInforMedSispro(ByVal row As Integer)
        Dim dt As New DataTable
        Dim dtcmbUM As New DataTable
        Dim dtcmbVA As New DataTable
        Dim dtcmbFRE As New DataTable
        Dim rows() As DataRow

        dt = dgtMedicaConcil.DataSource
        If Not IsDBNull(dt.Rows(row)("cantidadcontrol")) Then
            txtCantidadC.Text = dt.Rows(row)("cantidadcontrol")
        End If
        If Not IsDBNull(dt.Rows(row)("cantidadletrascontrol")) Then
            txtCantidadLetras.Text = dt.Rows(row)("cantidadletrascontrol")
        End If
        'If dt.Rows(row)("MedControl") = "S" Then
        '    GroupCnt24.Enabled = False
        'Else
        GroupCnt24.Enabled = True
        'End If


        txtCodMedica.Text = (dt.Rows(row)("producto"))
        txtCodMedica.Enabled = False
        cmbDescripMedica.Text = (dt.Rows(row)("descripcion"))
        cmbDescripMedica.Enabled = False
        txtDosis.Text = (dt.Rows(row)("Dosis"))
        txtDosis.Enabled = False
        ''Claudia Garay Noviembre 17 de 2010
        ''Cambio de combo de unidad de medida por textbox con formato
        '-->        dtcmbUM = txtDescripcionUM.OrigenDeDatos
        'dtcmbUM = cmbUnidadMedida.DataSource
        dtcmbUM = txtDescripcionUM.DataSource

        rows = dtcmbUM.Select("concentracion='" & (dt.Rows(row)("UniMedDosis")) & "'")
        'cmbUnidadMedida.Text = rows(0).Item("descripcion").ToString
        If Not IsDBNull(rows(0).Item("descripcion").ToString) Then
            txtDescripcionUM.Text = rows(0).Item("descripcion").ToString
        End If
        txtDescripcionUM.Enabled = False

        txtDescripcionUM.SelectedValue = rows(0).Item("concentracion").ToString
        'txtCodigoUM.Text = rows(0).Item("concentracion").ToString
        'txtCodigoUM.Enabled = False

        ''Claudia Garay Noviembre 17 de 2010
        ''Cambio de combo de via de administracion por textbox con formato
        '        dtcmbVA = cmbViaAdmin.DataSource
        dtcmbVA = txtDescripcionVA.DataSource
        'dtcmbVA = txtDescripcionVA.OrigenDeDatos
        rows = dtcmbVA.Select("via='" & (dt.Rows(row)("ViaAdministra")) & "'")
        'cmbViaAdmin.Text = rows(0).Item("descripcion").ToString
        txtDescripcionVA.Text = rows(0).Item("descripcion").ToString
        txtDescripcionVA.Enabled = False
        txtDescripcionVA.Text = rows(0).Item("via").ToString
        txtDescripcionVA.Enabled = False


        'dtcmbFRE = txtDescripcionFreq.OrigenDeDatos
        dtcmbFRE = txtDescripcionFreq.DataSource
        rows = dtcmbFRE.Select("frecuencia='" & (dt.Rows(row)("Frecuencia")) & "'")
        txtDescripcionFreq.Text = rows(0).Item("descripcion").ToString
        txtDescripcionFreq.Enabled = False
        'txtCodigoFreq.Text = rows(0).Item("frecuencia").ToString
        ''txtCodigoFreq.Enabled = False
        txtTecnica.Text = (dt.Rows(row)("TecnicaAdministra"))
        txtTecnica.Enabled = False
        IIf((dt.Rows(row)("TecnicaAdministra")) = "N", chkUnicaDosis.Checked = False, chkUnicaDosis.Checked = True)
        If Len(dt.Rows(row)("diastrat")) > 0 Then
            Me.txtDiasTrat.Visible = True
            Me.lblDiasTrat.Visible = True
            Me.txtDiasTrat.Text = dt.Rows(row)("diastrat")
        Else
            Me.txtDiasTrat.Visible = False
            Me.lblDiasTrat.Visible = False
        End If

    End Sub

    Private Function ValidarContinuar(fila As Int32, datagridgenerico As DataGridView) As String
        Dim dtDatos As DataTable = dgtMedicaConcil.DataSource
        Dim dtcmbFRE As New DataTable
        Dim rows() As DataRow
        Dim mensaje As String = ""
        Dim auxiliar As Integer = 0

        Dim chkContinuar As DataGridViewCheckBoxCell = DirectCast(datagridgenerico.Rows(fila).Cells("modificar_med"), DataGridViewCheckBoxCell)

        Dim chkSuspender As DataGridViewCheckBoxCell = DirectCast(datagridgenerico.Rows(fila).Cells("suspender_med"), DataGridViewCheckBoxCell)
        Dim valorCelda As String = datagridgenerico.CurrentCell.Value.ToString()
        chkContinuar.Value = valorCelda
        GroupCnt24.Visible = False
        'txtCantidadC.Visible = False
        'txtCantidadLetras.Visible = False

        txtCodMedica.Text = String.Empty
        'txtCodMedica.Enabled = True
        cmbDescripMedica.Text = String.Empty
        cmbDescripMedica.Enabled = True
        txtDosis.Text = String.Empty
        txtDescripcionUM.Text = String.Empty
        txtDescripcionUM.SelectedValue = String.Empty
        txtDescripcionVA.Text = String.Empty
        txtDescripcionVA.SelectedValue = String.Empty
        txtDescripcionFreq.Text = String.Empty
        txtDescripcionFreq.SelectedValue = String.Empty
        txtorigengrilla.Text = String.Empty
        'inicio validación si no estan activos la frencuencia, unudad medida dosis y via de administración
        ' si no estan activos no se debe permitir seguir con el registro REQ 584 numeral B Gestión ordenes medicas historicas 
        dtcmbFRE = txtDescripcionFreq.DataSource
        rows = dtcmbFRE.Select("frecuencia='" & (dtDatos.Rows(fila)("Frecuencia")) & "'")

        If datagridgenerico.Rows(fila).Cells("Frecuencia").Value = "47" Then 'Dosis Unica
            mensaje = "Debe generar una nueva orden para este medicamento"
            dgtMedicaConcil.Rows(fila).Cells("continuar_med").Value = False 'le quito el check
            dgtMedicaConcil.Update()
            dgtMedicaConcil.RefreshEdit()
            Return mensaje
        End If

        'If rows.Length = 0 Then
        '    auxiliar = 1 'marca por que   esta inactivo
        '    mensaje = "Debe volver a realizar la prescripción de este medicamento/líquido"
        '    datagridgenerico.Rows(fila).Cells("continuar_med").Value = False 'le quito el check
        '    datagridgenerico.Update()
        '    datagridgenerico.RefreshEdit()
        '    Return mensaje
        'End If

        dtcmbFRE = New DataTable
        dtcmbFRE = txtDescripcionUM.DataSource
        rows = dtcmbFRE.Select("concentracion='" & (dtDatos.Rows(fila)("UniMedDosis")) & "'")
        If rows.Length = 0 Then 'esta inactivo la unidad de medida

            auxiliar = 1 'marca por que   esta inactivo

            If dtDatos.Rows(fila)("UniMedDosis") = "3" Then ' se valida si el inactivo  tiene  homologo
                datagridgenerico.Rows(fila).Cells("UniMedDosis").Value = "67"
                auxiliar = 0 'marco por que no esta activo pero tiene un homologo
            End If

            If dtDatos.Rows(fila)("UniMedDosis") = "33" Then ' se valida si el inactivo  tiene  homologo
                datagridgenerico.Rows(fila).Cells("UniMedDosis").Value = "71"
                auxiliar = 0 'marco por que no esta activo pero tiene un homologo
            End If

            If dtDatos.Rows(fila)("UniMedDosis") = "48" Then ' se valida si el inactivo  tiene  homologo
                datagridgenerico.Rows(fila).Cells("UniMedDosis").Value = "72"
                auxiliar = 0 'marco por que no esta activo pero tiene un homologo
            End If

            If dtDatos.Rows(fila)("UniMedDosis") = "8" Then ' se valida si el inactivo  tiene  homologo
                datagridgenerico.Rows(fila).Cells("UniMedDosis").Value = "70"
                auxiliar = 0 'marco por que no esta activo pero tiene un homologo
            End If

            If dtDatos.Rows(fila)("UniMedDosis") = "27" Then ' se valida si el inactivo  tiene  homologo
                datagridgenerico.Rows(fila).Cells("UniMedDosis").Value = "69"
                auxiliar = 0 'marco por que no esta activo pero tiene un homologo
            End If

            If dtDatos.Rows(fila)("UniMedDosis") = "4" Then ' se valida si el inactivo  tiene  homologo
                datagridgenerico.Rows(fila).Cells("UniMedDosis").Value = "68"
                auxiliar = 0 'marco por que no esta activo pero tiene un homologo
            End If
        End If

        dtcmbFRE = New DataTable
        dtcmbFRE = txtDescripcionVA.DataSource

        rows = dtcmbFRE.Select("via='" & (dtDatos.Rows(fila)("ViaAdministra")) & "'")
        If rows.Length = 0 Then
            auxiliar = 1 'marca por que  no esta activo

            If dtDatos.Rows(fila)("ViaAdministra") = "IR" Or dtDatos.Rows(fila)("ViaAdministra") = "ES" Then ' se valida si el inactivo  tiene  homologo
                dgtMedicaConcil.Rows(fila).Cells("ViaAdministra").Value = "IQ"
                auxiliar = 0 'marco por que no esta activo pero tiene un homologo
            End If

            If dtDatos.Rows(fila)("ViaAdministra") = "NA" Then ' se valida si el inactivo  tiene  homologo
                dgtMedicaConcil.Rows(fila).Cells("ViaAdministra").Value = "IL"
                auxiliar = 0 'marco por que no esta activo pero tiene un homologo
            End If

        End If



        If dtDatos.Rows(fila)("Frecuencia") = "31" Or dtDatos.Rows(fila)("Frecuencia") = "43" Then '31 Infusión continua, 43 Rescate
            'inicio rmzaldua
            Dim fecha As Date
            Dim fechacero As DataTable
            Dim fechaval As String
            fecha = Date.Now()
            fechacero = objDao.ConsultarDiasHistorico("horaceroplanmedicamentos")
            If fechacero.Rows.Count > 0 Then
                fechaval = fechacero.Rows(0).Item("valor").ToString
            End If
            'rmzaldua  
            'se valida la fecha en que sale la version para que no muestre los balances de fecha anterior al despliegue
            If Format(CDate(dtDatos.Rows(fila)("fec_con")), "yyyyMMdd") < fechaval Then
                auxiliar = 1 'marca por que  no esta activo
            Else
                auxiliar = 0
            End If
            'fin rmzaldua
        End If

        If dtDatos.Rows(fila)("UniMedDosis") = "54" Then ' spray quedo inactivo
            auxiliar = 1
        End If

        'Fin validación si no estan activos la frencuencia, unudad medida dosis y via de administración

        If auxiliar > 0 Then
            mensaje = "Debe volver a realizar la prescripción de este medicamento/líquido"
            dgtMedicaConcil.Rows(fila).Cells("continuar_med").Value = False 'le quito el check
            dgtMedicaConcil.Update()
            dgtMedicaConcil.RefreshEdit()
        Else
            dgtMedicaConcil.Update()
            dgtMedicaConcil.RefreshEdit()
        End If

        Return mensaje
    End Function


    Private Sub MostrarInforMed(ByVal row As Integer, datagridgenerico As DataGridView, origengrilla As String)

        Dim dt As New DataTable
        Dim dtcmbUM As New DataTable
        Dim dtcmbVA As New DataTable
        Dim dtcmbFRE As New DataTable
        Dim rows() As DataRow

        dt = datagridgenerico.DataSource


        dtcmbFRE = txtDescripcionFreq.DataSource
        rows = dtcmbFRE.Select("frecuencia='" & (dt.Rows(row)("Frecuencia")) & "'")
        If rows.Length > 0 Then



            txtDescripcionFreq.Text = rows(0).Item("descripcion").ToString
            'txtCodigoFreq.Text = rows(0).Item("frecuencia").ToString
            txtTecnica.Text = (dt.Rows(row)("TecnicaAdministra"))
        Else
            txtDescripcionFreq.Text = ""
            'txtCodigoFreq.Text = ""
            txtTecnica.Text = "2"
        End If

        IIf((dt.Rows(row)("TecnicaAdministra")) = "N", chkUnicaDosis.Checked = False, chkUnicaDosis.Checked = True)

        If dt.Rows(row)("diastrat") > 0 Then
            Me.txtDiasTrat.Visible = True
            Me.lblDiasTrat.Visible = True
            Me.txtDiasTrat.Visible = True
            Me.txtDiasTrat.Text = dt.Rows(row)("diastrat")
        Else
            Me.lblDiasTrat.Visible = False
            Me.txtDiasTrat.Visible = False
        End If


        If Not IsDBNull(dt.Rows(row)("cantidadcontrol")) Then
            txtCantidadC.Text = dt.Rows(row)("cantidadcontrol")
            GroupCnt24.Enabled = True
            GroupCnt24.Visible = True
            lblCantidadC.Visible = True
            txtCantidadC.Visible = True
            lblCantLetras.Visible = True
            txtCantidadLetras.Visible = True
        Else
            GroupCnt24.Enabled = False
            GroupCnt24.Visible = False
            lblCantidadC.Visible = False
            txtCantidadC.Visible = False
            lblCantLetras.Visible = False
            txtCantidadLetras.Visible = False
        End If

        If Not IsDBNull(dt.Rows(row)("cantidadletrascontrol")) Then
            txtCantidadLetras.Text = dt.Rows(row)("cantidadletrascontrol")
        End If

        If dt.Rows(row)("MedControl") = "N" Then
            GroupCnt24.Visible = False
        Else
            GroupCnt24.Visible = True
        End If



        'ActualizarDatos(row, datagridgenerico)



        txtCodMedica.Text = (dt.Rows(row)("producto"))
        txtCodMedica.Enabled = False
        cmbDescripMedica.Text = (dt.Rows(row)("descripcion"))
        cmbDescripMedica.Enabled = False
        Dim ttxtDosis As Decimal = dt.Rows(row)("Dosis") ' FormatNumber(CDbl(dt.Rows(row)("Dosis")), 2)
        txtDosis.Text = ttxtDosis
        txtorigengrilla.Text = origengrilla
        'ChkBolo.Checked = (dt.Rows(row)("viaBolo"))

        If Not IsDBNull(dt.Rows(row)("viaBolo")) Then
            If dt.Rows(row)("viaBolo") = True Then
                ChkBolo.Checked = True
                Me.txtPasarEn.Text = (dt.Rows(row)("OMPasarEn"))
                Me.txtPasarEn.Visible = True
            End If
        Else
            ChkBolo.Checked = False
            Me.txtPasarEn.Visible = False
        End If


        If Not IsDBNull(dt.Rows(row)("diastrat")) Then
            txtDiasTrat.Text = (dt.Rows(row)("diastrat"))
            If txtDiasTrat.Text <> "" Then
                Me.txtDiasTrat.Visible = True
                Me.lblDiasTrat.Visible = True

                txtDiasTrat.Refresh()
            End If
        Else
            Me.txtDiasTrat.Visible = False
            Me.lblDiasTrat.Visible = False
        End If

        If Not IsDBNull(dt.Rows(row)("OMDurante")) And dt.Rows(row)("OMDurante") <> String.Empty Then 'dt.Rows(row)("OMDurante") > 0
            Dim prueba As String = FormatNumber(CDbl(dt.Rows(row)("OMDurante")), 1).ToString
            txtDurante24.Text = prueba  '' FormatNumber(CDbl(dt.Rows(row)("OMDurante")), 1).ToString '
            If Me.txtDurante24.Text <> "" Then
                Me.pnlDurante.Visible = True
            End If
            'Me.txtDurante24.Visible = True
            'Me.Label23.Visible = True
            'Me.txtDurante24.Enabled = True

        Else
            'Me.txtDurante24.Visible = False
            'Me.Label23.Visible = False
            Me.pnlDurante.Visible = False
        End If

        If Not IsDBNull(dt.Rows(row)("OMPasarEn")) Then
            txtPasarEn.Text = (dt.Rows(row)("OMPasarEn"))
            If txtPasarEn.Text <> "0" Then
                ' Me.txtPasarEn.Visible = True
                Me.pnlPasarEn.Visible = True
            End If

        Else
            'Me.txtPasarEn.Visible = False
            Me.pnlPasarEn.Visible = False
        End If

        If Not IsDBNull(dt.Rows(row)("OMRescates")) Then
            txtNumRescates.Text = (dt.Rows(row)("OMRescates")).ToString
            If txtNumRescates.Text <> "" And txtNumRescates.Text <> "0" Then
                Me.txtNumRescates.Visible = True
                Me.pnlRescate.Visible = True
            End If

        Else
            Me.pnlRescate.Visible = False
            Me.txtNumRescates.Visible = False
        End If

        If Not IsDBNull(dt.Rows(row)("OMNumDosis")) Then
            txtNumDosis.Text = (dt.Rows(row)("OMNumDosis"))
            If txtNumDosis.Text <> "" And txtNumDosis.Text <> "0" Then
                Me.pnlNumDosis.Visible = True
                txtNumDosis.Visible = True
            End If
        Else
            Me.pnlNumDosis.Visible = False
            txtNumDosis.Visible = False
        End If





        ''Claudia Garay Noviembre 17 de 2010
        ''Cambio de combo de unidad de medida por textbox con formato

        'dtcmbUM = txtDescripcionUM.OrigenDeDatos
        'dtcmbUM = cmbUnidadMedida.DataSource

        dtcmbUM = txtDescripcionUM.DataSource
        rows = dtcmbUM.Select("concentracion='" & (dt.Rows(row)("UniMedDosis")) & "'")
        'cmbUnidadMedida.Text = rows(0).Item("descripcion").ToString

        If rows.Length = 0 Then
            txtDescripcionUM.Text = ""
        Else
            If Not IsDBNull(rows(0).Item("descripcion").ToString) Then
                txtDescripcionUM.Text = rows(0).Item("descripcion").ToString
            End If
        End If



        '-->  txtCodigoUM.Text = rows(0).Item("concentracion").ToString

        ''Claudia Garay Noviembre 17 de 2010
        ''Cambio de combo de via de administracion por textbox con formato
        '        dtcmbVA = cmbViaAdmin.DataSource
        'dtcmbVA = txtDescripcionVA.OrigenDeDatos
        dtcmbVA = txtDescripcionVA.DataSource
        rows = dtcmbVA.Select("via='" & (dt.Rows(row)("ViaAdministra")) & "'")
        If rows.Length = 0 Then
            txtDescripcionVA.Text = ""
        Else
            If Not IsDBNull(rows(0).Item("descripcion").ToString) Then
                txtDescripcionVA.Text = rows(0).Item("descripcion").ToString
                txtDescripcionVA.SelectedValue = rows(0).Item("via").ToString
            End If
        End If
        'cmbViaAdmin.Text = rows(0).Item("descripcion").ToString

        'dtcmbFRE = txtDescripcionFreq.OrigenDeDatos


    End Sub


    Private Sub InicializaValorControles()
        txtDurante24.Text = ""
        txtPasarEn.Text = ""
        txtNumRescates.Text = ""
        txtNumDosis.Text = ""
        txtCantidadC.Text = ""
        txtCantidadLetras.Text = ""
        txtDosis.Text = ""
        txtCodMedica.Text = ""
        cmbDescripMedica.ResetText()
        txtDescripcionFreq.ResetText()
        txtDescripcionUM.ResetText()
        txtDescripcionVA.ResetText()
        Me.GroupCnt24.Visible = False
    End Sub

    Public Sub LimpiarPanel(ByVal objPanel As Panel, ByVal ctrlExcept As Control)
        Dim control As Control
        Dim ckControl As CheckBox

        For Each control In objPanel.Controls
            If Not control.Equals(ctrlExcept) Then
                If TypeOf control Is TextBoxConFormato Then
                    control.Text = ""
                End If
                If TypeOf control Is ComboBox Or TypeOf control Is ComboBusqueda Then
                    control.Text = ""
                End If
                If TypeOf control Is TextBox Then
                    control.Text = ""
                End If
                If TypeOf control Is CheckBox Then
                    ckControl = CType(control, CheckBox)
                    ckControl.Checked = False
                End If
            End If
        Next

    End Sub

    Private Function medicamentoSeleccionadoCombo() As DataRow
        Dim dtSeleccionCombo As DataTable
        Dim arrayConsulta() As DataRow

        'DATA TABLE RESULTADO DE LA BUSQUEDA 
        'cmbDescripMedica.
        dtSeleccionCombo = cmbDescripMedica.OrigenDeDatos

        'index = cmbDescripMedica.SelectedIndex
        If dtSeleccionCombo Is Nothing Then
            ''' 10/2019
            ''' Req. ER_OSI_584 Prescripcion_de_medicamentos
            ''' Se elimina mensaje
            ' MsgBox("Debe digitar la información del producto", MsgBoxStyle.Information)
            Return Nothing
        End If

        If txtCodMedica.Text.Trim.Length <= 0 Or cmbDescripMedica.Text.Trim.Length <= 1 Then
            ' Return Nothing raul
        End If


        arrayConsulta = dtSeleccionCombo.Select("codigo = '" & Me.txtCodMedica.Text & "' and descripcion = " & "'" & Me.cmbDescripMedica.Text & "'")
        If Not arrayConsulta Is Nothing Then
            If arrayConsulta.Length > 0 Then
                Return arrayConsulta(0)
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If

    End Function
    Private Sub txtDosis_Leave(sender As Object, e As EventArgs) Handles txtDescripcionUM.Leave, txtDescripcionVA.Leave, txtPasarEn.Leave, txtNumRescates.Leave, txtDiasTrat.Leave, txtDescripcionFreq.Leave, txtCantidadC.Leave, txtNumDosis.Leave, txtPasarEn.Leave, txtDurante24.Leave, txtDosis.Leave
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
                        MessageBox.Show("Debe diligenciar los días de Tratamiento")
                        'control.Focus()
                    End If
                    Exit Sub
                Else
                    control.BackColor = SystemColors.Window
                End If
            End If


            'Dim control As TextBox = CType(sender, TextBox)
            'If ValidadRangoSignosVitales(Tensión_Arterial_Sistolica, txtSistoleEF.Text) Then
            '    txtSistoleEF.BackColor = SystemColors.Window
            'Else
            '    txtSistoleEF.BackColor = Color.LightPink
            '    RangosValidos = False
            'End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtDurante24_KeyPress(sender As Object, e As KeyPressEventArgs)

        Dim keychar As Integer = AscW(e.KeyChar)
        If keychar = 8 Then
            e.Handled = False
            Exit Sub
        End If

        Dim IsDec As Boolean = False
        Dim nroDec As Integer = 0
        If txtDurante24.Text.Length < 1 Then
            Exit Sub
        End If
        For i As Integer = 1 To txtDurante24.Text.Length
            If txtDurante24.Text.Chars(i - 1) = "." Then
                IsDec = True
            End If

            If IsDec = True And (nroDec + 1) > 1 Then
                e.Handled = True
                Exit Sub
            ElseIf IsDec = True Then
                nroDec += 1
            End If
        Next

        If keychar >= 48 And keychar <= 57 Then
            e.Handled = False
        ElseIf (keychar = 46) Then
            e.Handled = IIf(IsDec, True, False)
        Else
            e.Handled = True
        End If

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
    Private Sub txtDescripcionFreq_TextChanged(sender As Object, e As EventArgs) Handles txtDescripcionFreq.TextChanged, txtDescripcionFreq.SelectedIndexChanged   ', txtDescripcionFreq.Click

        Dim codFrecuencia As String = String.Empty
        txtDiasTrat.Text = ""
        txtDiasTrat.ReadOnly = False

        Try
            'limpio todos los controles por seguridad
            ChkBolo.Checked = False
            pnlDurante.Visible = False
            pnlPasarEn.Visible = False
            pnlRescate.Visible = False
            pnlNumDosis.Visible = False


            If txtDescripcionFreq.SelectedValue.GetType().Name = "DataRowView" And String.IsNullOrEmpty(txtDescripcionFreq.SelectedText.Trim()) Then
                Exit Sub
            End If

            codFrecuencia = IIf(Not IsNothing(txtDescripcionFreq.SelectedValue), txtDescripcionFreq.SelectedValue.Trim(), String.Empty)
            If Me.txtDescripcionFreq.Text = String.Empty Or String.IsNullOrEmpty(codFrecuencia.ToString()) Then
                Me.txtDescripcionFreq.Text = String.Empty
                Me.txtDescripcionFreq.SelectedValue = String.Empty
                Exit Sub
            Else
                codFrecuencia = (New BLOrdenes().ConsultarFrecuenciasHomologadas(codFrecuencia)).Rows(0)("CodFrecuenciaPal").ToString()
                pnlDurante.Visible = IIf(codFrecuencia = "31", True, False)

                pnlPasarEn.Visible = ChkBolo.Checked
                pnlRescate.Visible = False
                pnlRescate.Visible = False
                txtDurante24.Text = ""
                txtPasarEn.Text = IIf(codFrecuencia = "47" And pnlPasarEn.Visible = True, txtPasarEn.Text, "")
                txtNumRescates.Text = ""
                txtNumDosis.Text = IIf(flagNOPOS = False, "", txtNumDosis.Text)
                ChkBolo.Enabled = True
                If codFrecuencia = "31" Or codFrecuencia.ToLower().Contains("infusi") Then
                    ChkBolo.Checked = False
                    ChkBolo.Enabled = False
                    pnlDurante.Visible = True
                    pnlDurante.Update()
                ElseIf codFrecuencia = "43" Or codFrecuencia.ToLower().Contains("rescate") Then
                    pnlRescate.Visible = True
                    txtNumRescates.Visible = True
                    pnlRescate.Update()
                ElseIf txtDescripcionFreq.Text.ToLower().Contains("min") Then
                    ChkBolo.Checked = False
                    ChkBolo.Enabled = False
                    pnlNumDosis.Visible = True
                    txtNumDosis.Visible = True
                    pnlNumDosis.Update()
                ElseIf codFrecuencia = "47" Then
                    If txtDiasTrat.Visible Then
                        txtDiasTrat.Text = 1
                        txtDiasTrat.ReadOnly = True
                    End If
                Else
                    If (String.IsNullOrEmpty(codFrecuencia.ToString())) Then
                        Me.txtDescripcionFreq.Text = String.Empty
                        Me.txtDescripcionFreq.SelectedValue = Nothing
                    End If




                    pnlPasarEn.Visible = ChkBolo.Checked
                End If
                SendKeys.Send("{ENTER}")
            End If
        Catch ex As System.MissingMemberException
            Me.txtDescripcionFreq.Text = String.Empty
            Me.txtDescripcionFreq.SelectedValue = Nothing
            Exit Sub
        Catch ex As System.NullReferenceException
            Exit Sub
        End Try
        Exit Sub
    End Sub
    Private Sub ValidarTexto(ByRef cboLista As Object, ByVal valor As String)
        Dim listaItems As DataTable = (DirectCast(cboLista, ComboBox)).DataSource
        If ((listaItems.Select(String.Format("descripcion ='{0}'", valor))).Count < 1) Then
            DirectCast(cboLista, ComboBox).ResetText()
            '            DirectCast(cboLista, ComboBox).Focus()
        End If
    End Sub
    Private Sub ValidarRangoNumeros(ByRef ControlToValidate As Object)
        Dim Min As Integer, Max As Integer

        Dim control As TextBoxConFormato = (DirectCast(ControlToValidate, TextBoxConFormato))
        If Not IsNothing(control.UserValues) Or Not String.IsNullOrEmpty(control.UserValues) Then
            Min = CInt(control.ValorMinimo)
            Max = CInt(control.ValorMaximo)
            Try
                Dim valor As Integer = Integer.Parse(ControlToValidate.Text)
                If (valor > Max Or valor < Min) Then
                    MessageBox.Show(String.Format("Rango Permitido del {0} al {1}", Min.ToString(), Max.ToString()), "Sophia", MessageBoxButtons.OK)
                End If
            Catch ex As Exception
                ControlToValidate.Text = ControlToValidate.Text.Remove(ControlToValidate.Text.Length - 1)
            End Try

        End If
        Return
    End Sub
    Private Sub txtDescripcionGen_Leave(sender As Object, e As EventArgs) Handles txtDescripcionVA.Leave, txtDescripcionUM.Leave
        ValidarTexto(sender, (DirectCast(sender, ComboBox)).Text)
    End Sub
    Private Sub txtRangosGen_Leave(sender As Object, e As EventArgs) Handles txtPasarEn.Leave
        ValidarRangoNumeros(sender)
    End Sub
    Private Sub txtCantidadC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCantidadC.Validated
        Dim objNumero As New Num2Words

        If txtCantidadC.Text = "0" Then
            txtCantidadLetras.Text = "CERO"
        ElseIf txtCantidadC.Text <> "" And txtCantidadC.Text <> "0" Then
            objNumero.number = CDbl(txtCantidadC.Text)
            txtCantidadLetras.Text = objNumero.monto
        Else
            txtCantidadLetras.Text = String.Empty
        End If

        'If txtCantidadC.Text <> "" Then
        '    objNumero.number = CDbl(txtCantidadC.Text)
        '    txtCantidadLetras.Text = objNumero.monto
        'ElseIf txtCantidadC.Text = "0" Then
        '    txtCantidadLetras.Text = "CERO"
        'Else
        '    txtCantidadLetras.Text = String.Empty
        'End If
    End Sub
    Private Sub ChkBolo_CheckedChanged(sender As Object, e As EventArgs) Handles ChkBolo.CheckedChanged
        ' La comparacion es sobre el codigo 31 que corresponde a infusion continua

        pnlDurante.Visible = False
        pnlPasarEn.Visible = False
        '      pnlRescate.Visible = False
        '     pnlNumDosis.Visible = False
        If Not IsNothing(txtDescripcionFreq.SelectedValue) Then
            If ChkBolo.Checked = True And txtDescripcionFreq.SelectedValue.Equals("31") Then
                Me.txtDescripcionFreq.ResetText()
                Me.txtDescripcionFreq.SelectedValue = String.Empty
            End If
            pnlPasarEn.Visible = ChkBolo.Checked
        End If

        If ChkBolo.Checked = True Then
            pnlPasarEn.Visible = ChkBolo.Checked
            txtPasarEn.Visible = True
            txtPasarEn.Text = ""

        End If
    End Sub
    Public Sub cargarGrillas()

        Me.CargargrillaMedicamentosConciliados()

        Me.CargargrillaMedicamentosConciliadosOtros()

        Me.CargargrillaMedicamentosConciliadosSuspendidos()
    End Sub

    Private Sub CargargrillaMedicamentosConciliadosOtros()

        datosSinAlmacenar = False

        If _MedicamentosConcilOtros.Estado = "N" Then  ''No ha sido cargado el objeto, primera carga del control 
            Try
                _MedicamentosConcilOtros.TablasOrdenes = BLConciliacionMedicamentos.consultarMedicamentosConciliadosOtros(datosConexion, datosLogin.Prestador, datosLogin.Sucursal,
                                      datosPaciente.TipoAdmision, datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision)

                _MedicamentosConcilOtros.TablasOrdenes.AcceptChanges()
                _MedicamentosConcilOtros.Estado = "M"  ''Marca el objeto para decir que ya fue cargado o modificado
            Catch ex As Exception
                MsgBox("Error en la consulta de las dietas. " & ex.Message, MsgBoxStyle.Information)
                Exit Sub
            End Try
        End If


        ''Carga la grilla de Medicamentos 
        configurarGrillaMedicamentosConciliadosOtros(_MedicamentosConcilOtros.TablasOrdenes.Tables("MEDICAMENTOSOTROS"))

    End Sub

    Public Sub configurarGrillaMedicamentosConciliadosOtros(ByVal dtMedicamentos As DataTable)
        If intloadotros = 0 Then
            With dtMedicamentos
                .Columns.Add("cod_corto", System.Type.GetType("System.String"))
                .Columns.Add("concentracionEq", System.Type.GetType("System.String"))
                .Columns.Add("for_farma", System.Type.GetType("System.String"))
                .Columns.Add("diasTratamiento", System.Type.GetType("System.String"))
                .Columns.Add("DosisXDia", System.Type.GetType("System.String"))
                .Columns.Add("DosisXDiaNoPos", System.Type.GetType("System.String"))
                .Columns.Add("fec_desde", System.Type.GetType("System.String"))
                .Columns.Add("fec_hasta", System.Type.GetType("System.String"))
                .Columns.Add("diagnost", System.Type.GetType("System.String"))
                .Columns.Add("Justificacion", System.Type.GetType("System.String"))
                .Columns.Add("clasificacion", System.Type.GetType("System.String"))
                .Columns.Add("obsDiagn", System.Type.GetType("System.String"))
                ' .Columns.Add("viaBolo", System.Type.GetType("System.String"))
                ''' 10/2019 eloaiza@intergrupo.com
                ''' Req. ER_OSI_584 Prescripcion_de_medicamentos
                '.Columns.Add("OMDurante", System.Type.GetType("System.Decimal"))
                ' .Columns.Add("OMPasarEn", System.Type.GetType("System.Decimal"))
                '.Columns.Add("OMRescates", System.Type.GetType("System.Decimal"))
                '.Columns.Add("OMNumDosis", System.Type.GetType("System.Decimal"))
                .Columns.Add("idRegistro", System.Type.GetType("System.String"))
                .Columns.Add("tmp_suspender_med", System.Type.GetType("System.String"))
                .Columns.Add("tmp_modificar_med", System.Type.GetType("System.String"))


            End With
            intloadotros = 1
        End If

        dtMedicamentos.Rows.Add()

        With dgtMedicaConcilOtros

            .DataSource = dtMedicamentos
            .Columns("cod_pre_sgs").Visible = False
            .Columns("cod_sucur").Visible = False
            .Columns("tip_admision").Visible = False
            .Columns("ano_adm").Visible = False
            .Columns("num_adm").Visible = False
            .Columns("NroOrden").Visible = False
            .Columns("producto").Visible = False
            .Columns("FormaFarma").Visible = False
            .Columns("Presentacion").Visible = False
            .Columns("Contenido").Visible = False
            .Columns("Concentracion").Visible = False
            .Columns("Dosis").Visible = False
            .Columns("UniMedDosis").Visible = False
            .Columns("ViaAdministra").Visible = False
            .Columns("Frecuencia").Visible = False
            .Columns("TecnicaAdministra").Visible = False
            .Columns("UnicaDosis").Visible = False
            .Columns("Tratamiento_med2").Visible = False
            .Columns("medico").Visible = False
            .Columns("estado").Visible = False
            .Columns("login").Visible = False
            .Columns("obs").Visible = False
            .Columns("Secuencia").Visible = False
            .Columns("cantidadcontrol").Visible = False ''cpgaray   
            .Columns("cantidadletrascontrol").Visible = False ''cpgaray
            '.Columns("descrProducto").Width = 300 ''Claudia Garay Enero 17 de 2011
            '.Sort(.Columns("fec_con_med"), System.ComponentModel.ListSortDirection.Descending)
            ''Ctc
            '.Columns("obs_med").Width = 260
            '.Columns("cod_corto").Visible = False
            .Columns("concentracion").Visible = False
            .Columns("for_farma").Visible = False
            .Columns("diasTratamiento").Visible = False
            .Columns("diasTrat1").Visible = False
            .Columns("DosisXDia").Visible = False
            .Columns("fec_desde").Visible = False
            .Columns("fec_hasta").Visible = False
            .Columns("diagnost").Visible = False
            .Columns("clasificacion").Visible = False
            .Columns("obsDiagn").Visible = False
            .Columns("concentracionEq").Visible = False
            .Columns("DosisXDiaNoPos").Visible = False
            .Columns("Justificacion").Visible = False
            '.Columns("autoSISPRO").Width = 140
            '.Columns("fecfintra").Width = 100
            ''' 10/2019
            ''' Req. ER_OSI_584 Prescripcion_de_medicamentos
            .Columns("viaBolo").Visible = False
            .Columns("OMDurante").Visible = False
            .Columns("OMPasarEn").Visible = False
            .Columns("OMRescates").Visible = False
            .Columns("OMNumDosis").Visible = False
            .Columns("idRegistro").Visible = False
            .Columns("tmp_suspender_med").Visible = False
            .Columns("tmp_modificar_med").Visible = False
            .Columns("conciliado").Visible = False
            .Columns("cod_corto").Visible = False

            .Columns("origen").Visible = False
        End With

        dtMedicamentos.Rows.RemoveAt(dtMedicamentos.Rows.Count - 1)
        ''PaginarGrillaMed()
    End Sub




#Region "medicamentos concliados"
    Private Sub CargargrillaMedicamentosConciliados()

        datosSinAlmacenar = False

        If _MedicamentosConcil.Estado = "N" Then  ''No ha sido cargado el objeto, primera carga del control 
            Try
                _MedicamentosConcil.TablasOrdenes = BLConciliacionMedicamentos.consultarMedicamentosConciliados(datosConexion, datosLogin.Prestador, datosLogin.Sucursal,
                                      datosPaciente.TipoAdmision, datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision)

                _MedicamentosConcil.TablasOrdenes.AcceptChanges()
                _MedicamentosConcil.Estado = "M"  ''Marca el objeto para decir que ya fue cargado o modificado
            Catch ex As Exception
                MsgBox("Error en la consulta de las dietas. " & ex.Message, MsgBoxStyle.Information)
                Exit Sub
            End Try
        End If


        ''Carga la grilla de Medicamentos 
        configurarGrillaMedicamentosConciliados(_MedicamentosConcil.TablasOrdenes.Tables("MEDICAMENTOS"))

    End Sub

    Public Sub configurarGrillaMedicamentosConciliados(ByVal dtMedicamentos As DataTable)
        '        dtSource = dtMedicamentos.Copy        

        'Dim tabla As New DataTable
        'dgtMedicaConcil.DataSource = tabla

        ''Ctc Noviembre 27 de 2012 se adicionan los campos necesarios para grabar los datos del equivalente

        If intload = 0 Then
            With dtMedicamentos
                .Columns.Add("cod_corto", System.Type.GetType("System.String"))
                .Columns.Add("concentracionEq", System.Type.GetType("System.String"))
                .Columns.Add("for_farma", System.Type.GetType("System.String"))
                .Columns.Add("diasTratamiento", System.Type.GetType("System.String"))
                .Columns.Add("DosisXDia", System.Type.GetType("System.String"))
                .Columns.Add("DosisXDiaNoPos", System.Type.GetType("System.String"))
                .Columns.Add("fec_desde", System.Type.GetType("System.String"))
                .Columns.Add("fec_hasta", System.Type.GetType("System.String"))
                .Columns.Add("diagnost", System.Type.GetType("System.String"))
                .Columns.Add("Justificacion", System.Type.GetType("System.String"))
                .Columns.Add("clasificacion", System.Type.GetType("System.String"))
                .Columns.Add("obsDiagn", System.Type.GetType("System.String"))
                ' .Columns.Add("viaBolo", System.Type.GetType("System.String"))
                ''' 10/2019 eloaiza@intergrupo.com
                ''' Req. ER_OSI_584 Prescripcion_de_medicamentos
                '.Columns.Add("OMDurante", System.Type.GetType("System.Decimal"))
                ' .Columns.Add("OMPasarEn", System.Type.GetType("System.Decimal"))
                '.Columns.Add("OMRescates", System.Type.GetType("System.Decimal"))
                '.Columns.Add("OMNumDosis", System.Type.GetType("System.Decimal"))
                .Columns.Add("idRegistro", System.Type.GetType("System.String"))
                .Columns.Add("tmp_suspender_med", System.Type.GetType("System.String"))
                .Columns.Add("tmp_modificar_med", System.Type.GetType("System.String"))
                'CU03 Hrariza
                'Inicio
                .Columns.Add("id_esquema", System.Type.GetType("System.String"))
                .Columns.Add("tratamiento_esquema", System.Type.GetType("System.String"))
                .Columns.Add("estado_esquema", System.Type.GetType("System.String"))
                .Columns.Add("peso_paciente", System.Type.GetType("System.String"))
                .Columns.Add("talla_paciente", System.Type.GetType("System.String"))
                .Columns.Add("sct", System.Type.GetType("System.String"))
                .Columns.Add("intencion_terapia", System.Type.GetType("System.String"))
                .Columns.Add("linea_tratamiento", System.Type.GetType("System.String"))
                .Columns.Add("ciclo", System.Type.GetType("System.String"))
                .Columns.Add("creatinina", System.Type.GetType("System.String"))
                .Columns.Add("unidad_medida_creatinina", System.Type.GetType("System.String"))
                .Columns.Add("tfg numeric", System.Type.GetType("System.String"))
                .Columns.Add("unidad_referencia", System.Type.GetType("System.String"))
                .Columns.Add("dosis_resultante", System.Type.GetType("System.String"))
                .Columns.Add("ajuste_dosis", System.Type.GetType("System.String"))
                .Columns.Add("dosis_ajustada", System.Type.GetType("System.String"))
                .Columns.Add("dosis_teorica", System.Type.GetType("System.String"))
                .Columns.Add("pasar_en", System.Type.GetType("System.String"))
                .Columns.Add("Tiempo", System.Type.GetType("System.String"))
                .Columns.Add("vehiculo", System.Type.GetType("System.String"))
                .Columns.Add("volumen_final_solucion", System.Type.GetType("System.String"))
                .Columns.Add("adm_durante_dias", System.Type.GetType("System.String"))
                .Columns.Add("fecha_sus", System.Type.GetType("System.String"))
                .Columns.Add("login_sus", System.Type.GetType("System.String"))
                .Columns.Add("textomotivo", System.Type.GetType("System.String"))
                .Columns.Add("motivo_id", System.Type.GetType("System.String"))
                .Columns.Add("espec_sus", System.Type.GetType("System.String"))
                .Columns.Add("motivosus", System.Type.GetType("System.String"))
                '.Columns.Add("MedControl", System.Type.GetType("System.String"))



                '.Columns.Add("conciliado", System.Type.GetType("System.String"))
                'Fin
            End With
            intload = 1
        End If





        dtMedicamentos.Rows.Add()

        With dgtMedicaConcil
            .DataSource = dtMedicamentos
            .Columns("cod_pre_sgs").Visible = False
            .Columns("cod_sucur").Visible = False
            .Columns("tip_admision").Visible = False
            .Columns("ano_adm").Visible = False
            .Columns("num_adm").Visible = False
            .Columns("NroOrden").Visible = False
            .Columns("producto").Visible = False
            .Columns("FormaFarma").Visible = False
            .Columns("Presentacion").Visible = False
            .Columns("Contenido").Visible = False
            .Columns("Concentracion").Visible = False
            .Columns("Dosis").Visible = False
            .Columns("UniMedDosis").Visible = False
            .Columns("ViaAdministra").Visible = False
            .Columns("Frecuencia").Visible = False
            .Columns("TecnicaAdministra").Visible = False
            .Columns("UnicaDosis").Visible = False
            .Columns("Tratamiento_med").Visible = False
            .Columns("medico").Visible = False
            .Columns("estado").Visible = False
            .Columns("login").Visible = False
            .Columns("obs").Visible = False
            .Columns("Secuencia").Visible = False
            .Columns("cantidadcontrol").Visible = False ''cpgaray   
            .Columns("cantidadletrascontrol").Visible = False ''cpgaray
            .Columns("descProducto").Width = 300 ''Claudia Garay Enero 17 de 2011
            '.Sort(.Columns("fec_con_med"), System.ComponentModel.ListSortDirection.Descending)
            ''Ctc
            .Columns("obs_med").Width = 260
            .Columns("cod_corto").Visible = False
            .Columns("concentracion").Visible = False
            .Columns("for_farma").Visible = False
            .Columns("diasTratamiento").Visible = False
            .Columns("diasTrat1").Visible = False
            .Columns("DosisXDia").Visible = False
            .Columns("fec_desde").Visible = False
            .Columns("fec_hasta").Visible = False
            .Columns("diagnost").Visible = False
            .Columns("clasificacion").Visible = False
            .Columns("obsDiagn").Visible = False
            .Columns("concentracionEq").Visible = False
            .Columns("DosisXDiaNoPos").Visible = False
            .Columns("Justificacion").Visible = False
            .Columns("autoSISPRO").Width = 140
            .Columns("fecfintra").Width = 100
            ''' 10/2019
            ''' Req. ER_OSI_584 Prescripcion_de_medicamentos
            .Columns("viaBolo").Visible = False
            .Columns("OMDurante").Visible = False
            .Columns("OMPasarEn").Visible = False
            .Columns("OMRescates").Visible = False
            .Columns("OMNumDosis").Visible = False
            .Columns("idRegistro").Visible = False
            .Columns("tmp_suspender_med").Visible = False
            .Columns("tmp_modificar_med").Visible = False
            'CU03 Hrariza
            'Inicio
            .Columns("id_esquema").Visible = False
            .Columns("tratamiento_esquema").Visible = False

            .Columns("estado_esquema").Visible = False
            .Columns("peso_paciente").Visible = False
            .Columns("talla_paciente").Visible = False
            .Columns("sct").Visible = False
            .Columns("intencion_terapia").Visible = False
            .Columns("linea_tratamiento").Visible = False
            .Columns("ciclo").Visible = False
            .Columns("creatinina").Visible = False
            .Columns("unidad_medida_creatinina").Visible = False
            .Columns("tfg numeric").Visible = False
            .Columns("unidad_referencia").Visible = False
            .Columns("dosis_resultante").Visible = False
            .Columns("ajuste_dosis").Visible = False
            .Columns("dosis_ajustada").Visible = False
            .Columns("dosis_teorica").Visible = False
            .Columns("pasar_en").Visible = False
            .Columns("Tiempo").Visible = False
            .Columns("vehiculo").Visible = False
            .Columns("volumen_final_solucion").Visible = False
            .Columns("adm_durante_dias").Visible = False
            .Columns("conciliado").Visible = False
            .Columns("fecha_sus").Visible = False
            .Columns("login_sus").Visible = False
            .Columns("textomotivo").Visible = False
            .Columns("motivo_id").Visible = False
            .Columns("espec_sus").Visible = False

            .Columns("origen").Visible = False
            .Columns("flag_pos").Visible = False
            .Columns("MedControl").Visible = False


            'Fin
        End With

        dtMedicamentos.Rows.RemoveAt(dtMedicamentos.Rows.Count - 1)






        ''PaginarGrillaMed()
    End Sub





    Private Sub dgtMedicaConcil_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgtMedicaConcil.CellContentClick


        If e.RowIndex = -1 Then

            Return
        End If


        If dgtMedicaConcil.Rows.Count > 0 Then
            For Each Fila As DataGridViewRow In dgtMedicaConcil.Rows
                If Not Fila Is Nothing Then
                    '//Puedes hacer una validación con el nombre de la columna
                    If Fila.Cells("origen").Value = "OrdenMed" Then
                        Fila.Cells("modificar_med").ReadOnly = True
                        DirectCast(Fila.Cells("modificar_med"), DataGridViewCheckBoxCell).ReadOnly = True


                    End If


                End If
            Next
        End If













        'If dgtMedicaConcil.Rows(e.RowIndex).Cells("modificar_med").ReadOnly = True Then

        '    Dim chkContinuar As DataGridViewCheckBoxCell = DirectCast(dgtMedicaConcil.Rows(e.RowIndex).Cells("modificar_med"), DataGridViewCheckBoxCell)
        '    dgtMedicaConcil.Rows(e.RowIndex).Cells("modificar_med").Value = chkContinuar.FalseValue





        'End If


        'If dgtMedicaConcil.Rows(e.RowIndex).Cells("suspender_med").ReadOnly = True Or dgtMedicaConcil.Rows(e.RowIndex).Cells("modificar_med").ReadOnly = True Then

        '    Return
        'End If


















        If dgtMedicaConcil.CurrentCell.ReadOnly = True And dgtMedicaConcil.Rows(e.RowIndex).Cells("origen").Value = "OrdenMed" Then 'Desmarcar el check de reformular
            dgtMedicaConcil.Rows(e.RowIndex).Cells("modificar_med").Value = "N"

            dgtMedicaConcil.Rows(e.RowIndex).Cells("modificar_med").Selected = True
            Return
        End If

        If dgtMedicaConcil.Rows(e.RowIndex).Cells("modificar_med").Value = "C" And dgtMedicaConcil.Rows(e.RowIndex).Cells("origen").Value <> "OrdenMed" And dgtMedicaConcil.CurrentCell.ReadOnly Then
            dgtMedicaConcil.Rows(e.RowIndex).Cells("modificar_med").Value = "C"

            dgtMedicaConcil.Rows(e.RowIndex).Cells("modificar_med").Selected = True
            Return
        End If


        Dim fecha_1 As Date
        Dim fecha_2 As Date
        Dim dias As Integer
        Dim FlagSispro As String
        Dim dtcmbFRE As New DataTable

        Dim dtDatos As DataTable = dgtMedicaConcil.DataSource

        If Not BLOrdenes.puedeModificarTratamientoconciliacion(dtDatos.Rows(e.RowIndex), dgtMedicaConcil.Rows(e.RowIndex).Cells("origen").Value) Then
            Exit Sub
        End If

        'If dgtMedicaConcil.CurrentCell.ColumnIndex = dgtMedicaConcil.Columns("modificar_med").Index And dgtMedicaConcil.Rows(e.RowIndex).Cells("origen").Value = "OrdenMed" Then

        '    dgtMedicaConcil.Rows(e.RowIndex).Cells("modificar_med").Value = "N"
        '    Exit Sub

        'End If


        dias = 0
        If dtDatos.Rows(e.RowIndex).Item("diastrat") > 0 Then
            fecha_1 = Format(Now.Date, "yyyy-MM-dd")
            If (dtDatos.Rows(e.RowIndex).Item("fecfintra")) Is DBNull.Value Then
                fecha_2 = Format(DateAdd(DateInterval.Day, dtDatos.Rows(e.RowIndex).Item("diastrat"), Now.Date), "yyyy-MM-dd")
                dtDatos.Rows(e.RowIndex).Item("fecfintra") = Format(fecha_2, "yyyy-MM-dd")
            End If
            fecha_2 = Format(dtDatos.Rows(e.RowIndex).Item("fecfintra"), "yyyy-MM-dd")
            'dias = DateDiff("d", Format(fecha_2, "yyyy-MM-dd"), Format(fecha_1, "yyyy-MM-dd")) + 1
            If Format(Now.Date, "yyyy-MM-dd") > Format(dtDatos.Rows(e.RowIndex).Item("fecfintra"), "yyyy-MM-dd") Then
                FlagSispro = "S"
            Else
                FlagSispro = "N"
            End If
        Else
            FlagSispro = "N"
        End If







        If falg_modificar = 0 Then
            ActualizarEstadoNuevo(e.RowIndex, String.Empty, FlagSispro, dgtMedicaConcil)
        Else

            'dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = chkSuspender.FalseValue
            Dim chkSuspender As DataGridViewCheckBoxCell = DirectCast(dgtMedicaConcil.Rows(e.RowIndex).Cells("suspender_med"), DataGridViewCheckBoxCell)
            Dim chkContinuar As DataGridViewCheckBoxCell = DirectCast(dgtMedicaConcil.Rows(e.RowIndex).Cells("modificar_med"), DataGridViewCheckBoxCell)



            If dgtMedicaConcil.CurrentCell.ReadOnly = True Then 'Desmarcar el check de reformular

                Exit Sub
            End If

            If dgtMedicaConcil.CurrentCell.Value = "C" Then
                dgtMedicaConcil.CurrentCell.Value = "C"
                'dgtMedicaConcil.Rows(e.RowIndex).Cells("suspender_med").Value = "C"
                'dgtMedicaConcil.Rows(e.RowIndex).Cells("suspender_med").Selected = False
                'falg_modificar = 0
                'MessageBox.Show("Para poder realizar esta acción debe desmarcar el check box Prescripción.", "Ordenes Medicas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                If dgtMedicaConcil.CurrentCell.Value = "S" Then
                    dgtMedicaConcil.CurrentCell.Value = "S"
                    'dgtMedicaConcil.Rows(e.RowIndex).Cells("modificar_med").Value = "N"
                    'dgtMedicaConcil.Rows(e.RowIndex).Cells("modificar_med").Selected = False
                    'falg_modificar = 0
                    'LimpiarDatos()
                    'MessageBox.Show("Para poder realizar esta acción debe desmarcar el check box Prescripción.", "Ordenes Medicas", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    If dgtMedicaConcil.CurrentCell.Value = "N" Then
                        Me.pnlDurante.Visible = False
                        falg_modificar = 0
                        ActualizarEstadoNuevo(e.RowIndex, String.Empty, FlagSispro, dgtMedicaConcil)
                        If GroupCnt24.Visible = True Then
                            GroupCnt24.Visible = False
                        End If
                    Else
                        dgtMedicaConcil.CurrentCell.Value = "N"
                        dgtMedicaConcil.Rows(e.RowIndex).Cells("suspender_med").Value = "C"
                        dgtMedicaConcil.Rows(e.RowIndex).Cells("suspender_med").Selected = False
                        falg_modificar = 0
                        'dgtMedicaConcil.CurrentCell.Value = "N"
                        'MessageBox.Show("Para poder realizar esta acción debe desmarcar el check box Prescripción.", "Ordenes Medicas", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'dgtMedicaConcil.Rows(e.RowIndex).Cells("modificar_med").Value = chkContinuar.FalseValue
                        dgtMedicaConcil.Rows(e.RowIndex).Cells("suspender_med").Value = chkSuspender.FalseValue
                    End If
                End If
            End If
            'falg_modificar = 0
            dgtMedicaConcil.RefreshEdit()

            'dtgMedicamentos.CurrentCell.Selected = True
            'dtgMedicamentos.EndEdit()
        End If

    End Sub

    Private Sub ActualizarEstadoNuevo(ByRef e As Integer, ByVal tratamiento As String, ByVal flag_sispro As String, datagridgenerico As DataGridView)





        'If TypeOf dtgMedicamentos.CurrentCell Is DataGridViewCheckBoxCell Then
        '    valorCheck = IIf(Not String.IsNullOrEmpty(dtgMedicamentos.CurrentCell.Value), dtgMedicamentos.CurrentCell.Value, "")
        'End If

        ' Valores que reprsentan la marcacion en las casillas (Verdadero, Falso)
        'Dim valoresContinuar As String() = {"C", "S"}
        'Dim valoresModificar As String() = {"M", "N"}
        'Dim valoresSuspender As String() = {"S", "C"}

        'Dim chkContinuar As DataGridViewCheckBoxCell = DirectCast(datagridgenerico.Rows(e).Cells("continuar_med"), DataGridViewCheckBoxCell)
        Dim chkModificar As DataGridViewCheckBoxCell = DirectCast(datagridgenerico.Rows(e).Cells("modificar_med"), DataGridViewCheckBoxCell)
        Dim chkSuspender As DataGridViewCheckBoxCell = DirectCast(datagridgenerico.Rows(e).Cells("suspender_med"), DataGridViewCheckBoxCell)

        Dim Fila As DataGridViewRow = DirectCast(datagridgenerico.Rows(e), DataGridViewRow)

        'Asegurar cual opción se selecciono
        'Dim refSel As Boolean = (Fila.Cells("continuar_med")).Selected
        Dim modSel As Boolean = (Fila.Cells("modificar_med")).Selected
        Dim susSel As Boolean = (Fila.Cells("suspender_med")).Selected

        If DirectCast(datagridgenerico.Rows(e).Cells("suspender_med"), DataGridViewCheckBoxCell).ReadOnly = False Then
            Fila.Cells("suspender_med").ReadOnly = False
        End If









        If datagridgenerico.CurrentCell.ColumnIndex = datagridgenerico.Columns("modificar_med").Index Then


            If datagridgenerico.Rows(e).Cells("modificar_med").Value = "C" Then
                'si el check lo activaron

                If ValidarContinuar(e, datagridgenerico).Length > 0 Then 'REQ 584 20200610 Raul Cruz
                    MsgBox(ValidarContinuar(e, datagridgenerico), MsgBoxStyle.Information)
                    Exit Sub
                End If


            End If
            'ComportamientoReformular(e, BLOrdenes.CONTINUA, flag_sispro)
        End If






        If datagridgenerico.CurrentCell.ColumnIndex = datagridgenerico.Columns("modificar_med").Index Then '' COLUMNA SUSPENDER
            'falg_modificar = 0
            ComportamientoModificar(e, String.Empty, flag_sispro, datagridgenerico)
        End If


        If datagridgenerico.CurrentCell.ColumnIndex = datagridgenerico.Columns("suspender_med").Index Then '' COLUMNA SUSPENDER           
            'falg_modificar = 0
            ComportamientoSuspender(e, String.Empty, flag_sispro, datagridgenerico)
        End If


        'falg_modificar = 0
        Exit Sub
        Select Case True
            'Case refSel

            '    Fila.Cells("continuar_med").Selected = True

            '    Fila.Cells("suspender_med").Selected = False
            '    Fila.Cells("suspender_med").ReadOnly = False
            Case modSel
                ComportamientoModificar(e, BLOrdenes.MODIFICA, flag_sispro, datagridgenerico)
                Fila.Cells("modificar_med").Value = True
                Fila.Cells("modificar_med").Selected = True
                Fila.Cells("suspender_med").Value = True
                Fila.Cells("continuar_med").Value = False
                falg_modificar = 0

            Case susSel
                ComportamientoSuspender(e, BLOrdenes.SUSPENDE, flag_sispro, datagridgenerico)
                falg_modificar = 0
                Fila.Cells("continuar_med").Value = False 'chkContinuar.FalseValue

        End Select

        datagridgenerico.EndEdit()

    End Sub


    Private Sub ComportamientoModificar(ByVal IndiceFilaSeleccionada As Integer, ByVal tratamiento As String, ByVal flag_sispro As String, datagridgenerico As DataGridView)
#Region "Modificar"

        Dim dtDatos As DataTable = datagridgenerico.DataSource
        Dim chkContinuar As DataGridViewCheckBoxCell = DirectCast(datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("modificar_med"), DataGridViewCheckBoxCell)

        Dim chkSuspender As DataGridViewCheckBoxCell = DirectCast(datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("suspender_med"), DataGridViewCheckBoxCell)




        If chkSuspender.Value = chkSuspender.TrueValue Then
            datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("fecha_sus").Value = String.Empty
            datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("login_sus").Value = String.Empty
            datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("textomotivo").Value = String.Empty
            datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("motivo_id").Value = String.Empty
            datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("espec_sus").Value = String.Empty
            datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("motivosus").Value = String.Empty
            datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("tmp_suspender_med").Selected = False
            datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = chkSuspender.FalseValue
        End If























        If datagridgenerico.CurrentCell.ReadOnly = True Then 'Desmarcar el check de reformular
            txtTecnica.Text = ""
            If datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("Frecuencia").Value = "47" Then
                MsgBox("Debe generar una nueva orden para este medicamento", MsgBoxStyle.Information)
                datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("continuar_med").Value = False 'le quito el check
                datagridgenerico.Update()
                datagridgenerico.RefreshEdit()
            End If
            Exit Sub
        End If


        If dtDatos.Rows(IndiceFilaSeleccionada)("Frecuencia") = "47" Then
            MsgBox("Debe generar una nueva orden para este medicamento", MsgBoxStyle.Information)
            txtCodMedica.Text = String.Empty
            ' txtCodMedica.Enabled = True
            cmbDescripMedica.Text = String.Empty
            cmbDescripMedica.Enabled = True
            txtDosis.Text = String.Empty
            txtDescripcionUM.Text = String.Empty
            txtDescripcionUM.SelectedValue = String.Empty
            txtDescripcionVA.Text = String.Empty
            txtDescripcionVA.SelectedValue = String.Empty
            txtDescripcionFreq.Text = String.Empty
            txtDescripcionFreq.SelectedValue = String.Empty
            'datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = chkSuspender.TrueValue
            datagridgenerico.CurrentCell.Value = chkContinuar.FalseValue
            dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_suspender_med") = chkSuspender.TrueValue
            dtDatos.Rows(IndiceFilaSeleccionada).Item("tratamiento") = chkContinuar.FalseValue
            'dtDatos.AcceptChanges()
            'datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = chkSuspender.TrueValue
            'datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("continuar_med").Value = chkContinuar.FalseValue
            datagridgenerico.Update()
            datagridgenerico.RefreshEdit()
            Exit Sub
        End If

        valorModificar = datagridgenerico.CurrentCell.Value
        For i As Integer = 0 To dtDatos.Rows.Count - 1
            If dtDatos.Rows(i).Item("obs") = "M" Then
                dtDatos.Rows(i).Item("obs") = "N" 'MARTOVAR CONTROL DE LIQUIDOS 2018/05/31

            End If
        Next



        If Not IsDBNull(datagridgenerico.CurrentCell.Value) Then
            If datagridgenerico.CurrentCell.Value = "M" And IsDBNull(dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_modificar_med")) Then
                datagridgenerico.CurrentCell.Value = "M"
                dtDatos.Rows(IndiceFilaSeleccionada).Item("obs") = "M"
                ''dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_suspender_med") = "S"
                'datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = chkSuspender.TrueValue
                datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("modificar_med").Selected = False
                datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("modificar_med").Value = chkContinuar.FalseValue
            ElseIf datagridgenerico.CurrentCell.Value = "N" And (dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_modificar_med").ToString() = "N" And String.IsNullOrEmpty(dtDatos.Rows(IndiceFilaSeleccionada).Item("obs").ToString())) Then
                datagridgenerico.CurrentCell.Value = "M"
                dtDatos.Rows(IndiceFilaSeleccionada).Item("obs") = "M"
                'dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_suspender_med") = "S"
                'datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = "S"
                datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("modificar_med").Selected = False
                datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("modificar_med").Value = "N"
            ElseIf datagridgenerico.CurrentCell.Value = "M" And dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_modificar_med").ToString() = "N" Then

                datagridgenerico.CurrentCell.Value = "M"
                dtDatos.Rows(IndiceFilaSeleccionada).Item("obs") = "M"
                dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_suspender_med") = chkSuspender.TrueValue
                datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = "C"
                datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("modificar_med").Selected = False
                datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("modificar_med").Value = "N"
                datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("motivosus").Value = String.Empty
            ElseIf datagridgenerico.CurrentCell.Value = "M" And dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_modificar_med").ToString() = "M" Then

                'dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_suspender_med") = chkSuspender.FalseValue
                'datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = chkSuspender.FalseValue
                dtDatos.Rows(IndiceFilaSeleccionada).Item("obs") = ""
            ElseIf datagridgenerico.CurrentCell.Value = "N" And dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_modificar_med").ToString() = "M" Then
                datagridgenerico.CurrentCell.Value = "N"
                dtDatos.Rows(IndiceFilaSeleccionada).Item("obs") = ""
                'dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_suspender_med") = "C"
                'datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = chkSuspender.FalseValue
                datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("modificar_med").Selected = False
                datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("modificar_med").Value = "N"
            ElseIf datagridgenerico.CurrentCell.Value = "N" And dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_modificar_med").ToString() = "N" And
                   dtDatos.Rows(IndiceFilaSeleccionada).Item("obs").ToString() = "N" Then

                dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_suspender_med") = chkSuspender.FalseValue
                datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = chkSuspender.FalseValue
                datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("motivosus").Value = String.Empty
                dtDatos.Rows(IndiceFilaSeleccionada).Item("obs") = ""
            Else
                datagridgenerico.CurrentCell.Value = "M"
                dtDatos.Rows(IndiceFilaSeleccionada).Item("obs") = "M"
                dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_modificar_med") = datagridgenerico.CurrentCell.Value
                ''dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_suspender_med") = "S"
                'DirectCast(datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("suspender_med"), DataGridViewCheckBoxCell).ReadOnly = True
                'datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = "S"
                chkSuspender.ReadOnly = True
                datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("modificar_med").Value = "N"

                'dtDatos.Rows(e.RowIndex).Item("obs") = ""
            End If
            dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_modificar_med") = datagridgenerico.CurrentCell.Value
        End If
        dtDatos.Rows(IndiceFilaSeleccionada).AcceptChanges()
        dtDatos.Rows(IndiceFilaSeleccionada).SetModified()

        BLOrdenes.actualizarEstado(dtDatos.Rows(IndiceFilaSeleccionada), BLOrdenes.CONTINUA, datagridgenerico.CurrentCell.Value, flag_sispro)
        'BLOrdenes.actualizarEstado(dtDatos.Rows(e.RowIndex), BLOrdenes.MODIFICA, dtgMedicamentos.CurrentCell.Value)
















        If dtDatos.Rows(IndiceFilaSeleccionada).Item("obs") = "M" Then






            MostrarInforMed(IndiceFilaSeleccionada, datagridgenerico, "GConciliados")
            falg_modificar = 1
        Else
            txtCodMedica.Text = String.Empty
            ' txtCodMedica.Enabled = True
            cmbDescripMedica.Text = String.Empty
            cmbDescripMedica.Enabled = False

            txtDosis.Text = String.Empty
            txtDescripcionUM.Text = String.Empty
            txtDescripcionUM.SelectedValue = String.Empty
            txtDescripcionVA.Text = String.Empty
            txtDescripcionVA.SelectedValue = String.Empty
            txtDescripcionFreq.Text = String.Empty
            txtDescripcionFreq.SelectedValue = String.Empty
            GroupCnt24.Visible = False

            Me.txtDiasTrat.Text = String.Empty
            Me.txtDiasTrat.Visible = False
            Me.lblDiasTrat.Visible = False
            falg_modificar = 0
            txtTecnica.Text = String.Empty
            txtorigengrilla.Text = String.Empty
        End If
        datagridgenerico.CurrentCell.Value = valorModificar
        datagridgenerico.RefreshEdit()
        Me.datosSinAlmacenar = True
#End Region
    End Sub

    Private Sub ComportamientoSuspender(ByVal IndiceFilaSeleccionada As Integer, ByVal tratamiento As String, ByVal flag_sispro As String, datagridgenerico As DataGridView)
#Region "Suspender"
        ' Suspender
        Dim resultado As String
        Dim mensaje = String.Empty
        Dim chkSuspender As DataGridViewCheckBoxCell = DirectCast(datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("suspender_med"), DataGridViewCheckBoxCell)
        If datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("Frecuencia").Value = "47" Then 'Dosis Unica ER_OSI_584 D.Suspender Raul Cruz
            resultado = New BLOrdenes().ConsultarEstadoDosisUnica(datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("cod_pre_sgs").Value,
                                                                  datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("cod_sucur").Value,
                                                                  datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("tip_admision").Value,
                                                                  datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("num_adm").Value,
                                                                  datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("ano_adm").Value,
                                                                  datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("NroOrden").Value,
                                                                  datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("Secuencia").Value)
            If resultado = "S" Then
                mensaje = "El medicamento ya fue administrado"
                datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = False 'le quito el check
                datagridgenerico.Update()
                datagridgenerico.RefreshEdit()
                MsgBox(mensaje, MsgBoxStyle.Information)
                Exit Sub
            End If
            If valorSuspender = "C" Then

                datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("motivosus").Value = String.Empty
            End If
        End If

        Dim dtDatos As DataTable = datagridgenerico.DataSource
        valorSuspender = datagridgenerico.CurrentCell.Value 'IIf(String.IsNullOrEmpty(dtgMedicamentos.CurrentCell.Value) Or IsDBNull(dtgMedicamentos.CurrentCell.Value), valoresSuspender(1), valoresSuspender(0))
        datagridgenerico.CurrentCell.Value = System.DBNull.Value
        If datagridgenerico.CurrentCell.ColumnIndex = datagridgenerico.Columns("suspender_med").Index Then
            If datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("modificar_med").Value = "M" And dgtMedicaConcil.CurrentCell.ReadOnly = True Then
                dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_suspender_med") = "C"
                datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Selected = False
                datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = "C"
                DirectCast(datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("suspender_med"), DataGridViewCheckBoxCell).ReadOnly = True
                Exit Sub
            End If
            If dtDatos.Rows(IndiceFilaSeleccionada).Item("diastrat") > 0 Then
                If flag_sispro = "S" Then
                    BLOrdenes.actualizarEstado(dtDatos.Rows(IndiceFilaSeleccionada), BLOrdenes.ACTIVO, "C", flag_sispro)
                Else
                    BLOrdenes.actualizarEstado(dtDatos.Rows(IndiceFilaSeleccionada), BLOrdenes.SUSPENDE, datagridgenerico.CurrentCell.Value, flag_sispro)
                    If valorSuspender = "S" Then
                        LimpiarDatos()
                        Dim myForm As New frm_Justificacion()
                        myForm.ShowDialog()
                        If myForm.descmotivoSuspension <> String.Empty Then
                            datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("motivosus").Value = myForm.descmotivoSuspension + "/" + datosLogin.NombreMedico + "/" + datosLogin.DescripcionEspecialidad
                            datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("fecha_sus").Value = FuncionesGenerales.FechaServidor()
                            datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("login_sus").Value = datosLogin.Login
                            datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("textomotivo").Value = myForm.descmotivoSuspension
                            datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("motivo_id").Value = myForm.idmotivosuspension
                            datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("espec_sus").Value = datosLogin.CodigoEspecialidad



                        Else

                            datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = chkSuspender.FalseValue
                            valorSuspender = "C"

                        End If


                    End If
                    If valorSuspender = "C" Then

                        datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("motivosus").Value = String.Empty
                        datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("fecha_sus").Value = String.Empty
                        datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("login_sus").Value = String.Empty
                        datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("textomotivo").Value = String.Empty
                        datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("motivo_id").Value = String.Empty
                        datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("espec_sus").Value = String.Empty

                    End If
                End If
            Else
                datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("modificar_med").Value = "N"
                datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("modificar_med").Selected = False
                If valorSuspender = "S" Then
                    LimpiarDatos()
                    cmbDescripMedica.ResetText()
                    Dim myForm As New frm_Justificacion
                    myForm.ShowDialog()
                    If myForm.descmotivoSuspension <> String.Empty Then
                        datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("motivosus").Value = myForm.descmotivoSuspension + "/" + datosLogin.NombreMedico + "/" + datosLogin.DescripcionEspecialidad
                        datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("fecha_sus").Value = FuncionesGenerales.FechaServidor()
                        datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("login_sus").Value = datosLogin.Login
                        datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("textomotivo").Value = myForm.descmotivoSuspension
                        datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("motivo_id").Value = myForm.idmotivosuspension
                        datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = chkSuspender.FalseValue
                        datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("espec_sus").Value = datosLogin.CodigoEspecialidad

                        LimpiarDatos()
                        cmbDescripMedica.ResetText()
                    Else

                        datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = chkSuspender.FalseValue
                        datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("fecha_sus").Value = String.Empty
                        datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("login_sus").Value = String.Empty
                        datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("textomotivo").Value = String.Empty
                        datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("motivo_id").Value = String.Empty
                        datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("espec_sus").Value = String.Empty

                        LimpiarDatos()
                        cmbDescripMedica.ResetText()
                        valorSuspender = "C"
                    End If

                End If
                If valorSuspender = "C" Then

                    datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("motivosus").Value = String.Empty
                End If









                BLOrdenes.actualizarEstado(dtDatos.Rows(IndiceFilaSeleccionada), BLOrdenes.SUSPENDE, "S", flag_sispro) 'raul cruz 20200721
            End If
            dtDatos.Rows(IndiceFilaSeleccionada).AcceptChanges()
            dtDatos.Rows(IndiceFilaSeleccionada).SetModified()
            datagridgenerico.CurrentCell.Value = valorSuspender
            datagridgenerico.RefreshEdit()
            Me.datosSinAlmacenar = True
        End If
#End Region
    End Sub

    Private Sub txtCodMedica_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodMedica.Validating
        Dim objDatos As New Sophia.HistoriaClinica.DAO.DAOGeneral
        Dim strUnimedped As String
        'If cmbUnidadMedida.Text = "" And txtCodMedica.Text <> "" Then
        ''Claudia Garay Noviembre 17 de 2010
        ''Cambio de combo de unidad de medida por textbox con formato
        If txtDescripcionUM.Text = "" And txtCodMedica.Text <> "" Then
            strUnimedped = objDatos.EjecutarSQLStrValor("GENPRODU a (NOLOCK) inner join genunimedped b (NOLOCK) on a.uni_med_pedido=b.uni_med_pedido", datosConexion, " b.descripcion", " a.cod_corto='" & txtCodMedica.Text & "'")
            'txtDescripcionUM.Text = strUnimedped
            'cmbUnidadMedida.Text = strUnimedped

        End If
    End Sub



    Private Sub dtgMedicamentos_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)  'Handles dtgMedicamentos.CellContentDoubleClick
        dgtMedicaConcil_CellValueChanged(sender, e)
        'dtgMedicamentos_CellContentClick(sender, e)
    End Sub

    Private Sub dtgMedicamentos_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Dim fila As Int16 = e.RowIndex
        Dim temCod As Int32
        Dim mensajeValidacion As String = ""

        Dim TextoValidar As String = ""

        If fila = -1 Then 'para evitar que se genere el error de excepción
            Exit Sub
        End If

        If dgtMedicaConcil.Rows(fila).Cells(0).Value = 1 Then

        End If
    End Sub

    Private Sub dgtMedicaConcil_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgtMedicaConcil.CurrentCellDirtyStateChanged
        If dgtMedicaConcil.IsCurrentCellDirty Then
            dgtMedicaConcil.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub btnAdicionarMedica_Click(sender As Object, e As EventArgs) Handles btnAdicionarMedica.Click

        If txtorigengrilla.Text = "GConciliados" Then
            AdicionarMedConciliados()
        ElseIf txtorigengrilla.Text = "GSuspendidos" Then
            AdicionarMedConciliadosSus()
        End If




    End Sub

    Private Sub AdicionarMedConciliados()
        'ALM 166 20200303 raul Cruz
        If ValidarDatosHisBasica() Then
            Exit Sub
        End If

        Dim dtMedica As DataTable
        Dim dtProductoElegido As DataRow
        Dim drFila As DataRow
        Dim mensaje As String = ""
        Dim tieneConvenio As Boolean
        Dim strEntidadManejaConvenio As String
        Dim objDatos As New Sophia.HistoriaClinica.DAO.DAOGeneral
        Dim BVerifica As Boolean
        Dim cont As Integer
        Dim strMedControl As String

        Dim strCantidadLetras As String = ""
        Dim BoolFormuladeControl As Boolean = False

        Dim strJustificacionL As String = "" ''cpgaray Ctc's
        Dim BoolEsExcepcion As Boolean = False ''cpgaray Ctc's
        Dim dtCtc As New DataTable ''cpgaray Ctc's
        Dim dtcmbFRE As New DataTable
        Dim rows() As DataRow
        Dim frecuencia As Double
        Dim DosisXDia As Double
        Dim frecuenciacod As String
        Dim pide_ctc As String
        Dim pide_SISPRO As String
        Dim pag_SISPRO As String
        Dim cod_Sispro As String = ""
        Dim flag_pos As String = ""
        Dim flag_posCondicionado As Boolean


        Dim dtmed As New DataTable

        cont = 0
        'Dim index As Integer

        'VALIDACION DEL DATASOURCE
        If IsNothing(dgtMedicaConcil) Then
            Exit Sub
        End If

        dtMedica = dgtMedicaConcil.DataSource
        If dtMedica Is Nothing Then
            Exit Sub
        End If

        If Me.txtDosis.Text = "" Then
            Me.txtDosis.Focus()
            Exit Sub
        End If

        ''Unica dosis no valida frecuencia ni via de administracion
        ''Claudia Garay
        ''Dic 15 de 2010

        If chkUnicaDosis.Checked = False Then

            'If txtCodigoUM.Text = "" Then
            '    MsgBox("Unidad de Medida no Valida")
            '    Exit Sub
            'End If

            If txtDescripcionUM.SelectedValue = "" Then
                txtDescripcionUM.Focus()
                'MsgBox("Unidad de Medida no Valida")
                Exit Sub
            End If
            If txtDescripcionVA.Text = "" Then
                txtDescripcionVA.Focus()
                'MsgBox("Via de Adminisración no Valida")
                Exit Sub
            End If
            If Me.txtDescripcionFreq.SelectedValue = "" Then
                txtDescripcionFreq.Focus()
                'MsgBox("Frecuencia no Valida")
                Exit Sub
            End If
        End If

        ' ''VERIFICAMOS SI SE SELECCIONO EL CHECK DE MODIFICACION DE MEDICAMENTO
        ' ''CLAUDIA GARAY
        ' eloaiza@intergrupo.com REQ OSI 584





        If txtDurante24.Visible And txtDurante24.Text = "" Then
            Me.txtDurante24.Focus()
            Exit Sub
        End If

        If txtPasarEn.Visible And txtPasarEn.Text = "" Then
            Me.txtPasarEn.Focus()
            Exit Sub
        End If

        If txtNumRescates.Visible And txtNumRescates.Text = "" Then
            Me.txtNumRescates.Focus()
            Exit Sub
        End If

        If txtNumDosis.Visible And txtNumDosis.Text = "" Then
            Me.txtNumDosis.Focus()
            Exit Sub
        End If

        If txtDiasTrat.Visible And Me.txtDiasTrat.Text = "" Then
            Me.txtDiasTrat.Focus()
            Exit Sub
        End If

        If txtCantidadC.Visible And txtCantidadC.Text = "" Then
            Me.txtCantidadC.Focus()
            Exit Sub
        End If




        BVerifica = ActualizaModificados(dtMedica)

        If BVerifica = True Then
            If flaglimpiacampos Then
                InicializaValorControles()
                flaglimpiacampos = True
            End If
            'pnlDurante.Visible = False
            'pnlPasarEn.Visible = False
            'pnlRescate.Visible = False
            'pnlNumDosis.Visible = False
            'InicializaValorControles()
            'Me.lblDiasTrat.Visible = False
            'Me.txtDiasTrat.Visible = False
            'Me.txtDiasTrat.Text = ""
            'Me.txtDiasTrat.ReadOnly = False
            'Me.GroupCnt24.Visible = False
            ''Me.txtCantidadC.Enabled = False
            ''Me.Label14.Enabled = False
            ''Me.Label9.Enabled = False

            'valorModificar = String.Empty
            'LimpiarPanel(Panel1, Nothing)
            'txtCantidadC.Text = String.Empty
            'BoolFormuladeControl = False
            'txtCantidadLetras.Text = String.Empty
            ''GroupCnt24.Visible = False
            'strJustificacionL = String.Empty
            'LIMPIA EL DATASOURCE DEL COMBO DE BUSQUEDA
            cmbDescripMedica.OrigenDeDatos.Rows.Clear()
            ' txtCodMedica.Focus()
            Exit Sub
        End If

        ''BUSCA EN EL DATASOURCE DEL COMBO LA INFORMACION DEL MEDICAMENTO 
        ''QUE ELIGIO EL USUARIO
        dtProductoElegido = medicamentoSeleccionadoCombo()

        If dtProductoElegido Is Nothing And cmbDescripMedica.Text.Trim().Length <= 1 Then
            MsgBox("Debe digitar la información del producto")
            Exit Sub
        End If


        ''prueba para compilar 20200205 

        'rmzaldua 
        'Cambio realizado por Ing. Ricardo Mauricio Zaluda
        'Motivo se realizo validacion para que escojan un tipo de Vía de Administración 
        '2009-10-22
        'solicitado por Juan Diego Arenas

        ''Claudia Garay Noviembre 17 de 2010
        ''Cambio de combo de via de administracion por textbox con formato
        'If cmbViaAdmin.SelectedValue.ToString = "" Then
        If txtDescripcionVA.Text = "" Then
            txtDescripcionVA.Focus()
            'MsgBox("Debe escoger vía de administración")
            Exit Sub
        End If
        ''Claudia Garay Noviembre 24 2010
        'If txtDescripcionFreq.Text = "" Then
        '    MsgBox("Debe escoger una Frecuencia")
        '    Exit Sub
        'End If

        'VALIDACIONES
        ''Claudia Garay Noviembre 17 de 2010 cambio de combo unidad de medida y via de administracion a textbox con formato
        If Not BLOrdenes.validarMedicamento(dtProductoElegido.Item("codigo").ToString, dtProductoElegido.Item("descripcion").ToString,
                                            Me.txtDosis.Text, Me.txtDescripcionUM.Text, Me.txtDescripcionVA.Text, Me.txtDescripcionFreq.SelectedValue,
                                            Me.txtDescripcionFreq.Text, Me.chkUnicaDosis.Checked, dtMedica, mensaje) Then
            MsgBox(mensaje, MsgBoxStyle.Information)
            Exit Sub

        End If

        'VALIDACION DEL CONVENIO DEL MEDICAMENTO PARA LA ENTIDAD COMO FORMA INFORMATIVA
        tieneConvenio = BLOrdenes.medicamentoTieneConvenio(datosConexion, dtProductoElegido.Item("codigo").ToString,
                                                           datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.Entidad)


        ''Se consulta si la entidad maneja convenio
        strEntidadManejaConvenio = objDatos.EjecutarSQLStrValor("GENENTID", datosConexion, "man_conv_med", "  entidad='" & datosPaciente.Entidad & "'")
        flag_pos = IIf(IsDBNull(dtProductoElegido.Item("flag_pos").ToString), "S", dtProductoElegido.Item("flag_pos").ToString)

        ''Se realizara esta validacion solo para entidades con convenio
        ''Claudia Garay
        ''08 feb 2010        
        If Not tieneConvenio And strEntidadManejaConvenio = "S" Then
            MsgBox("El medicamento no tiene convenio para esta entidad.", MsgBoxStyle.Information)
        End If

        If Len(LTrim(txtCantidadC.Text)) = 0 Then
            GroupCnt24.Enabled = True
            If dtProductoElegido.Item("MedControl").ToString = "S" Then
                ''' 10/2019
                ''' Req. ER_OSI_584 Prescripcion_de_medicamentos
                ''' Se omite esta funcionalidad
                'If MsgBox("¿Desea imprimir la fórmula de control?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                '    GroupCnt24.Enabled = True
                '    MsgBox("Ingrese la cantidad")
                '    txtCantidadC.Focus()
                '    Exit Sub
                'Else
                '    GroupCnt24.Enabled = False
                'End If

            End If
        Else
            BoolFormuladeControl = True
        End If

        Dim daoGeneral As New DAOGeneral

        pide_ctc = daoGeneral.EjecutarSQLStrValor("gensucur (nolock)", datosConexion, " pide_ctc", " cod_sucur='" & datosLogin.Sucursal & "'")
        pide_SISPRO = daoGeneral.EjecutarSQLStrValor("gensucur (nolock)", datosConexion, " pide_SISPRO", " cod_sucur='" & datosLogin.Sucursal & "'")
        pag_SISPRO = daoGeneral.EjecutarSQLStrValor("pargener (nolock)", datosConexion, " pagsispro", " cod_pre_sgs='" & datosLogin.Prestador & "'")

        'Version 3.0.0 CTC para medicina prepagada herojas 2015/01/15
        Dim strGenExcep As Boolean
        Dim strGenCTC_MP As String

        strGenExcep = False
        strGenCTC_MP = "N"

        If datosPaciente.TipoEntidad = "PRE" Then

            strGenExcep = BLOrdenes.ConsultaExcepciones(datosPaciente.Entidad, txtCodMedica.Text)

            If strGenExcep Then

                MsgBox("El medicamento Elegido no tiene cobertura para la  entidad " & datosPaciente.DescripcionEntidad, MsgBoxStyle.Information)

                strGenCTC_MP = BLOrdenes.PideCTCMP(datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.TipoAdmision,
                            datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision, txtCodMedica.Text)
            End If
        End If

        ' ''Ctc Marzo 21 de 2012 cpgaray
        ''pide_ctc = "S" And 
        If (datosPaciente.TipoEntidad = "EPS" Or strGenCTC_MP = "S") And pide_ctc = "S" Then
            ' Hernan Rojas 2014/05/12 No debe solicitar ctc cuando tiene uno vigente            
            flag_pos = IIf(IsDBNull(dtProductoElegido.Item("flag_pos").ToString), "S", dtProductoElegido.Item("flag_pos").ToString)
            'If BLOrdenes.ConsultaExcepciones(datosPaciente.Entidad, txtCodMedica.Text) = True Then
            If flag_pos = "N" Then
                If Not BLOrdenes.MedicamentoTieneCTC(datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.TipoAdmision,
                        datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision, txtCodMedica.Text) Then
                    MsgBox("El medicamento elegido es no POS por favor diligenciar la Justificación de Uso para CTC", MsgBoxStyle.Information)
                    BoolEsExcepcion = True
                    'dtcmbFRE = txtDescripcionFreq.OrigenDeDatos
                    dtcmbFRE = txtDescripcionFreq.DataSource

                    rows = dtcmbFRE.Select("descripcion='" & txtDescripcionFreq.Text & "'")

                    If chkUnicaDosis.Checked = False Then
                        If rows.Length = 0 Then
                            frecuencia = 0
                        Else
                            If rows(0).Item("CadaNroHoras").ToString <> "0" Then
                                frecuencia = CDbl(rows(0).Item("CadaNroHoras").ToString)
                                DosisXDia = CDbl(txtDosis.Text) * (24 / frecuencia)
                            Else
                                frecuenciacod = rows(0).Item("Frecuencia").ToString
                                If frecuenciacod = "40" Then ''7 minutos
                                    DosisXDia = CDbl(txtDosis.Text) * (1440 / 7)
                                ElseIf frecuenciacod = "41" Then '' 10 minutos
                                    DosisXDia = CDbl(txtDosis.Text) * (1440 / 10)
                                ElseIf frecuenciacod = "42" Then '' 15 minutos
                                    DosisXDia = CDbl(txtDosis.Text) * (1440 / 15)
                                ElseIf frecuenciacod = "37" Or frecuenciacod = "25" Or frecuenciacod = "45" Then '' Antes de las comidas , con las comidas , despues de la comida
                                    DosisXDia = CDbl(txtDosis.Text) * 3
                                ElseIf frecuenciacod = "33" Then '' Ahora
                                    DosisXDia = CDbl(txtDosis.Text)
                                ElseIf 1 = 0 Then


                                Else
                                    DosisXDia = 0
                                End If

                                frecuencia = 0
                            End If

                        End If
                    Else
                        DosisXDia = CDbl(txtDosis.Text) ''Unica dosis
                    End If

                    frmc_JustificaExcepcion.Mostrar(txtCodMedica.Text, frecuencia, datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.TipoAdmision, datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision, datosLogin.Login, datosConexion)
                    frmc_JustificaExcepcion.ShowDialog()
                    If frmc_JustificaExcepcion.dtCtc.Rows.Count = 0 Then
                        Exit Sub
                    Else
                        dtCtc = frmc_JustificaExcepcion.dtCtc
                    End If
                    'frmc_JustificaExcepcion.strJustificacion = String.Empty
                    'frmc_JustificaExcepcion.txtJustificacion.Text = String.Empty
                End If
            End If
        Else
            If (datosPaciente.TipoEntidad = "EPS" Or strGenCTC_MP = "S") And pide_SISPRO = "S" Then
                If flag_pos = "N" Then
                    If String.IsNullOrEmpty(Me.txtDiasTrat.Text) Or Me.txtDiasTrat.Text.Trim() = "0" Then
                        'If Me.txtDiasTrat.Text < 1 Then
                        MsgBox("debe digitar los dias de tratamiento", MsgBoxStyle.Information, "Conciliaciòn de medicamentos")
                        Me.txtDiasTrat.Focus()
                        Exit Sub
                    End If
                    flag_posCondicionado = BLOrdenes.existePosCondicionado(datosConexion, datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.TipoAdmision, datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision, "M", dtProductoElegido.Item("codigo").ToString)
                    If flag_posCondicionado = True Then
                        cod_Sispro = "POS Condicionado"
                        MsgBox("El elemento prescrito es POS Condicionado por Diagnóstico", MsgBoxStyle.Information)
                    Else
                        System.Diagnostics.Process.Start(pag_SISPRO)
                        frm_SISPRO.Text = "Registro Radicado MIPRES"
                        frm_SISPRO.Mostrar(cod_Sispro)
                        cod_Sispro = frm_SISPRO.Cod_SISPRO1
                    End If

                End If
            Else
                BoolEsExcepcion = False
            End If

        End If
        If flag_pos = "N" Then
            If String.IsNullOrEmpty(Me.txtDiasTrat.Text) Or Me.txtDiasTrat.Text.Trim() = "0" Then
                MsgBox("debe digitar los dias de tratamiento", MsgBoxStyle.Information, "Conciliaciòn de medicamentos")
                Me.txtDiasTrat.Focus()
                Exit Sub
            End If
        End If
        If txtPasarEn.Visible = True Then
            If String.IsNullOrEmpty(txtPasarEn.Text) Then
                Me.txtPasarEn.Focus()
                Exit Sub
            End If
        End If

        ' ER_OSI 584 eloaiza@intergrupo.com - Validar pre-existencia de medicamento y formulación

        Dim tabla As DataTable = dgtMedicaConcil.DataSource
        Dim descripcion As String = dtProductoElegido.Item("descProducto").ToString
        Dim prescripcion As String = txtDosis.Text & " " & txtDescripcionUM.Text.Trim() & " " & Me.txtDescripcionVA.Text.Trim() & " " &
                                     IIf(Not txtDescripcionFreq.Visible, "", txtDescripcionFreq.Text.Trim()) & " " &
                                     IIf(ChkBolo.Checked, " Bolo ", "") & "" &
                                     IIf(ChkBolo.Checked, IIf(Not txtPasarEn.Visible, "", "PASAR EN: " & txtPasarEn.Text.Trim() & " MINUTOS"), "") & "" &
                                     IIf(Not txtDurante24.Visible, "", " DURANTE: " & txtDurante24.Text.Trim() & " HORAS") &
                                     IIf(Not txtNumRescates.Visible, "", " Número de Rescates: " & txtNumRescates.Text.Trim()) & " " &
                                     IIf(Not txtNumDosis.Visible, "", "Número de Dosis: " & txtNumDosis.Text.Trim()) & " " & txtTecnica.Text



        Dim producto As String = dtProductoElegido.Item("codigo").ToString
        tabla.CaseSensitive = False

        Dim fila As DataRow() = tabla.Select("producto LIKE '" & producto.Trim().ToUpper() &
                                             "%' AND UniMedDosis =" & txtDescripcionUM.SelectedValue &
                                             " AND ViaAdministra = '" & txtDescripcionVA.SelectedValue &
                                             "'" & " AND Frecuencia =" & txtDescripcionFreq.SelectedValue &
        IIf(txtPasarEn.Text <> "", " AND OMPasarEn =" & txtPasarEn.Text.Trim(), " AND OMPasarEn = OMPasarEn ") & 'txtDurante24
        IIf(txtDiasTrat.Text <> "", " AND Diastrat =" & txtDiasTrat.Text.Trim(), " AND Diastrat = Diastrat ") &
        IIf(txtNumDosis.Text <> "", " AND OMNumDosis =" & txtNumDosis.Text.Trim(), " AND OMNumDosis = OMNumDosis ") & 'en la siguiente linea va txtDosis
        IIf(txtNumRescates.Text <> "", " AND OMRescates =" & txtNumRescates.Text.Trim(), " AND OMRescates = OMRescates "))

        Dim Dosistem As String
        Dim OMDuranteTem As String
        If fila.Length > 0 Then 'ALM_399 con este ajuste se valida los campos con formato decimal
            For i As Integer = 0 To tabla.Rows.Count - 1
                If producto = tabla.Rows(i).Item("producto").ToString Then
                    Dosistem = tabla.Rows(i).Item("Dosis").ToString
                    OMDuranteTem = tabla.Rows(i).Item("OMDurante").ToString
                    If CDbl(Dosistem) = CDbl(txtDosis.Text) Then
                        If txtDurante24.Text <> "" Then
                            If CDbl(OMDuranteTem) = CDbl(txtDurante24.Text) Then
                                MsgBox("El medicamento ya cuenta con  una prescripción", MsgBoxStyle.Information, "Conciliaciòn de medicamentos")
                                Me.cmbDescripMedica.Focus()
                                Exit Sub
                            End If
                        Else
                            MsgBox("El medicamento ya cuenta con  una prescripción", MsgBoxStyle.Information, "Conciliaciòn de medicamentos")
                            Me.cmbDescripMedica.Focus()
                            Exit Sub
                        End If
                    End If
                End If
            Next
        End If
        'Anterior
        'IIf(txtDurante24.Text <> "", " AND OMDurante =" & String.Format("{0:0.00}", CDbl(IIf(txtDurante24.Text.Trim() = "", "0", txtDurante24.Text.Trim()))), " AND OMDurante = OMDurante ") &
        '  IIf((String.Format("{0:0.00}", CDec(txtDosis.Text.Trim()))) <> "", " AND Dosis ='" & String.Format("{0:0.00}", CDec(txtDosis.Text.Trim())) & "'", " AND Dosis = Dosis ") & 'Se agrega formateo al campo txtDosis.Text. ALM_399 
        'IIf(txtDosis.Text <> "", " AND Dosis ='" & String.Format("{0:0.00}", CDbl(txtDosis.Text.Trim())) & "'", " AND Dosis = Dosis ") & 

        'If fila.Length > 0 Then
        '    MsgBox("El medicamento ya cuenta con  una prescripción", MsgBoxStyle.Information, "Conciliaciòn de medicamentos")
        '    Me.cmbDescripMedica.Focus()
        '    Exit Sub
        'End If

        'CREACION DE LA NUEVA FILA
        drFila = dtMedica.NewRow()
        ''Claudia Garay Noviembre 17 de 2010
        ''Cambio de combo de unidad de medida y via de administracion por textbox con formato
        'LLENADO DE LOS DATOS
        drFila("descripcion") = descripcion
        drFila("prescripcion") = prescripcion
        drFila("NombreMedico") = datosLogin.NombreMedico
        drFila("Especialidad") = datosLogin.DescripcionEspecialidad
        drFila("cod_pre_sgs") = datosLogin.Prestador
        drFila("cod_sucur") = datosLogin.Sucursal
        drFila("tip_admision") = datosPaciente.TipoAdmision
        drFila("ano_adm") = datosPaciente.AnoAdmision
        drFila("num_adm") = datosPaciente.NumeroAdmision
        drFila("NroOrden") = 0
        drFila("producto") = producto
        drFila("FormaFarma") = dtProductoElegido.Item("FormaFarma").ToString
        drFila("Presentacion") = dtProductoElegido.Item("Presentacion").ToString
        drFila("Contenido") = CDbl(IIf(dtProductoElegido.Item("Contenido").ToString = "", 0, dtProductoElegido.Item("Contenido").ToString)) ''Claudia Garay Noviembre Error al agregar med
        ''Claudia Garay Noviembre 17 de 2010
        ''Cambio de combo de unidad de medida y via de administracion por textbox con formato
        '-->drFila("Concentracion") = IIf(txtCodigoUM.Text = "", DBNull.Value, txtCodigoUM.Text) 'cmbUnidadMedida.SelectedValue  'dtProductoElegido.Item("Concentracion").ToString
        '-->drFila("UniMedDosis") = IIf(txtCodigoUM.Text = "", DBNull.Value, txtCodigoUM.Text)
        If String.IsNullOrEmpty(txtDosis.Text) Then
            txtDosis.Focus()
            Exit Sub
        End If

        drFila("Dosis") = CDbl(txtDosis.Text)
        drFila("ViaAdministra") = IIf(Me.txtDescripcionVA.SelectedValue = "", DBNull.Value, Me.txtDescripcionVA.SelectedValue) 'txtDescripcionVA.Text 'cmbViaAdmin.SelectedValue.ToString
        '        drFila("Frecuencia") = IIf('txtCodigoFreq.Text = "", DBNull.Value, 'txtCodigoFreq.Text)

        drFila("Concentracion") = IIf(Me.txtDescripcionUM.SelectedValue = "", DBNull.Value, Me.txtDescripcionUM.SelectedValue)
        'dtProductoElegido.Item("Concentracion").ToString() 'cmbUnidadMedida.SelectedValue  'dtProductoElegido.Item("Concentracion").ToString
        drFila("UniMedDosis") = IIf(Me.txtDescripcionUM.SelectedValue = "", DBNull.Value, Me.txtDescripcionUM.SelectedValue)

        drFila("Frecuencia") = IIf(Me.txtDescripcionFreq.SelectedValue = "", DBNull.Value, Me.txtDescripcionFreq.SelectedValue)
        drFila("TecnicaAdministra") = txtTecnica.Text
        drFila("UnicaDosis") = IIf(chkUnicaDosis.Checked, BLOrdenes.UNICADOSIS, BLOrdenes.VARIASDOSIS)
        drFila("obs") = ""

        If Me.chkUnicaDosis.Checked = True Then
            drFila("Tratamiento") = Nothing
            drFila("estado") = BLOrdenes.INACTIVO
        Else
            'CLAUDIA GARAY UNICA DOSIS INACTIVA
            drFila("Tratamiento") = Nothing
            drFila("estado") = BLOrdenes.ACTIVO
        End If
        drFila("medico") = datosLogin.Login
        drFila("Login") = datosLogin.Login
        ''Claudia Garay Noviembre 22 de 2010 Validar Medicamentos de control
        strMedControl = objDatos.EjecutarSQLStrValor("genprodu (nolock)", datosConexion, "med_controlado", " cod_corto='" & drFila("producto") & "'")
        If IsDBNull(strMedControl) Then
            strMedControl = "N"
        End If
        'Select Case strMedControl
        '    Case "A"
        '        strMedControl = "S"
        '    Case "I"
        '        strMedControl = "N"
        '    Case Else
        '        strMedControl = "N"
        'End Select
        drFila("MedControl") = strMedControl

        ''cpgaray Enero 5 de 2012 Medicamentos de Control
        If BoolFormuladeControl = True Then
            drFila("cantidadcontrol") = txtCantidadC.Text
            drFila("cantidadletrascontrol") = txtCantidadLetras.Text
        Else
            drFila("cantidadcontrol") = 0
            drFila("cantidadletrascontrol") = ""
        End If
        ''fin 
        'rmzaldua 2016-11-01
        If flag_pos = "N" Then
            drFila("diastrat") = Me.txtDiasTrat.Text
            drFila("CodSISPRO") = dtProductoElegido.Item("codsispro").ToString
            drFila("DesSISPRO") = dtProductoElegido.Item("dessispro").ToString
            drFila("autoSISPRO") = cod_Sispro

        Else
            If Len(Me.txtDiasTrat.Text) > 0 Then
                drFila("diastrat") = Me.txtDiasTrat.Text
            Else
                drFila("diastrat") = 0
            End If
            drFila("CodSISPRO") = ""
            drFila("DesSISPRO") = ""
            drFila("autoSISPRO") = ""
        End If

        If BoolEsExcepcion = True Then
            ''ctc Noviembre 27 de 2012
            'BLOrdenes.GrabarErroresOrdenesMedicas("HistoriaMedicaCTC" & " Entra llenar datos ctc para xml")
            drFila("cod_corto") = dtCtc.Rows(0).Item("cod_corto")
            drFila("concentracionEq") = dtCtc.Rows(0).Item("concentracion")
            drFila("for_farma") = dtCtc.Rows(0).Item("for_farma")
            drFila("diasTratamiento") = dtCtc.Rows(0).Item("diasTratamiento")
            drFila("DosisXDia") = dtCtc.Rows(0).Item("DosisXDia")
            If DosisXDia <> 0 Then
                drFila("DosisXDiaNoPos") = Round(DosisXDia, 2) & " " & IIf(txtDescripcionUM.Text = "", DBNull.Value, txtDescripcionUM.Text)
            Else
                drFila("DosisXDiaNoPos") = ""
            End If

            drFila("fec_desde") = dtCtc.Rows(0).Item("fec_desde")
            drFila("fec_hasta") = dtCtc.Rows(0).Item("fec_hasta")
            drFila("diagnost") = dtCtc.Rows(0).Item("diagnost")
            drFila("clasificacion") = dtCtc.Rows(0).Item("clasificacion")
            drFila("obsDiagn") = dtCtc.Rows(0).Item("obs")
            drFila("Justificacion") = dtCtc.Rows(0).Item("Justificacion")

        End If

        ''' 10/2019
        ''' Req. ER_OSI_584 Prescripcion_de_medicamentos

        drFila("viaBolo") = ChkBolo.Checked
        drFila("OMDurante") = IIf(txtDurante24.Visible = False, "0", txtDurante24.Text)
        drFila("OMPasarEn") = IIf(txtPasarEn.Visible = False, "0", txtPasarEn.Text)
        drFila("OMRescates") = IIf(txtNumRescates.Visible = False, "0", txtNumRescates.Text)
        drFila("OMNumDosis") = IIf(txtNumDosis.Visible = False, "0", txtNumDosis.Text)
        drFila("idRegistro") = "N" ' Indicador para marcar el registro como  nuevo
        drFila("origen") = "NordenMed"
        'ADICIONA LA NUEVA FILA A LA TABLA
        dtMedica.Rows.Add(drFila)
        ''ADICIONA A LA TABLA DEL PAGINADOR
        'dtSource.Rows.Add(drFila)  'Claudia Garay Noviembre 18 de 2010
        'ENLAZA LA TABLA Y EL DATAGRID

        dgtMedicaConcil.DataSource = dtMedica


        For i As Integer = 0 To dgtMedicaConcil.Rows.Count - 7
            If dgtMedicaConcil.Rows(i).IsNewRow Then
                dgtMedicaConcil.Rows(i).Cells(0).ReadOnly = True
            End If

        Next

        InicializaValorControles()
        pnlDurante.Visible = False
        pnlPasarEn.Visible = False
        pnlRescate.Visible = False
        pnlNumDosis.Visible = False
        InicializaValorControles()
        Me.lblDiasTrat.Visible = False
        Me.txtDiasTrat.Visible = False
        Me.txtDiasTrat.Text = ""
        Me.txtDiasTrat.ReadOnly = False
        Me.GroupCnt24.Visible = False
        'Me.txtCantidadC.Enabled = False
        'Me.Label14.Enabled = False
        'Me.Label9.Enabled = False

        valorModificar = String.Empty
        LimpiarPanel(Panel1, Nothing)
        txtCantidadC.Text = String.Empty
        BoolFormuladeControl = False
        txtCantidadLetras.Text = String.Empty
        'GroupCnt24.Visible = False
        strJustificacionL = String.Empty
        'LIMPIA EL DATASOURCE DEL COMBO DE BUSQUEDA
        cmbDescripMedica.OrigenDeDatos.Rows.Clear()
        'txtCodMedica.Focus()
        Me.datosSinAlmacenar = True
    End Sub

    Private Sub AdicionarMedConciliadosSus()
        'ALM 166 20200303 raul Cruz
        If ValidarDatosHisBasica() Then
            Exit Sub
        End If

        Dim dtMedica As DataTable
        Dim dtProductoElegido As DataRow
        Dim drFila As DataRow
        Dim mensaje As String = ""
        Dim tieneConvenio As Boolean
        Dim strEntidadManejaConvenio As String
        Dim objDatos As New Sophia.HistoriaClinica.DAO.DAOGeneral
        Dim BVerifica As Boolean
        Dim cont As Integer
        Dim strMedControl As String

        Dim strCantidadLetras As String = ""
        Dim BoolFormuladeControl As Boolean = False

        Dim strJustificacionL As String = "" ''cpgaray Ctc's
        Dim BoolEsExcepcion As Boolean = False ''cpgaray Ctc's
        Dim dtCtc As New DataTable ''cpgaray Ctc's
        Dim dtcmbFRE As New DataTable
        Dim rows() As DataRow
        Dim frecuencia As Double
        Dim DosisXDia As Double
        Dim frecuenciacod As String
        Dim pide_ctc As String
        Dim pide_SISPRO As String
        Dim pag_SISPRO As String
        Dim cod_Sispro As String = ""
        Dim flag_pos As String = ""
        Dim flag_posCondicionado As Boolean


        Dim dtmed As New DataTable

        cont = 0
        'Dim index As Integer

        'VALIDACION DEL DATASOURCE
        If IsNothing(dgtMedicaConcilSus) Then
            Exit Sub
        End If

        dtMedica = dgtMedicaConcilSus.DataSource
        If dtMedica Is Nothing Then
            Exit Sub
        End If

        If Me.txtDosis.Text = "" Then
            Me.txtDosis.Focus()
            Exit Sub
        End If

        ''Unica dosis no valida frecuencia ni via de administracion
        ''Claudia Garay
        ''Dic 15 de 2010

        If chkUnicaDosis.Checked = False Then

            'If txtCodigoUM.Text = "" Then
            '    MsgBox("Unidad de Medida no Valida")
            '    Exit Sub
            'End If

            If txtDescripcionUM.SelectedValue = "" Then
                txtDescripcionUM.Focus()
                'MsgBox("Unidad de Medida no Valida")
                Exit Sub
            End If
            If txtDescripcionVA.Text = "" Then
                txtDescripcionVA.Focus()
                'MsgBox("Via de Adminisración no Valida")
                Exit Sub
            End If
            If Me.txtDescripcionFreq.SelectedValue = "" Then
                txtDescripcionFreq.Focus()
                'MsgBox("Frecuencia no Valida")
                Exit Sub
            End If
        End If

        ' ''VERIFICAMOS SI SE SELECCIONO EL CHECK DE MODIFICACION DE MEDICAMENTO
        ' ''CLAUDIA GARAY
        ' eloaiza@intergrupo.com REQ OSI 584
        If txtDurante24.Visible And txtDurante24.Text = "" Then
            Me.txtDurante24.Focus()
            Exit Sub
        End If

        If txtPasarEn.Visible And txtPasarEn.Text = "" Then
            Me.txtPasarEn.Focus()
            Exit Sub
        End If

        If txtNumRescates.Visible And txtNumRescates.Text = "" Then
            Me.txtNumRescates.Focus()
            Exit Sub
        End If

        If txtNumDosis.Visible And txtNumDosis.Text = "" Then
            Me.txtNumDosis.Focus()
            Exit Sub
        End If

        If txtDiasTrat.Visible And Me.txtDiasTrat.Text = "" Then
            Me.txtDiasTrat.Focus()
            Exit Sub
        End If

        If txtCantidadC.Visible And txtCantidadC.Text = "" Then
            Me.txtCantidadC.Focus()
            Exit Sub
        End If



        BVerifica = ActualizaModificadosSuspendidos(dtMedica)

        If BVerifica = True Then
            If flaglimpiacampos Then
                InicializaValorControles()
                flaglimpiacampos = True
            End If
            'InicializaValorControles()
            'pnlDurante.Visible = False
            'pnlPasarEn.Visible = False
            'pnlRescate.Visible = False
            'pnlNumDosis.Visible = False
            'InicializaValorControles()
            'Me.lblDiasTrat.Visible = False
            'Me.txtDiasTrat.Visible = False
            'Me.txtDiasTrat.Text = ""
            'Me.txtDiasTrat.ReadOnly = False
            'Me.GroupCnt24.Visible = False
            ''Me.txtCantidadC.Enabled = False
            ''Me.Label14.Enabled = False
            ''Me.Label9.Enabled = False

            'valorModificar = String.Empty
            'LimpiarPanel(Panel1, Nothing)
            'txtCantidadC.Text = String.Empty
            'BoolFormuladeControl = False
            'txtCantidadLetras.Text = String.Empty
            ''GroupCnt24.Visible = False
            'strJustificacionL = String.Empty
            ''LIMPIA EL DATASOURCE DEL COMBO DE BUSQUEDA
            cmbDescripMedica.OrigenDeDatos.Rows.Clear()
                '' txtCodMedica.Focus()
                Exit Sub
            End If

            ''BUSCA EN EL DATASOURCE DEL COMBO LA INFORMACION DEL MEDICAMENTO 
            ''QUE ELIGIO EL USUARIO
            dtProductoElegido = medicamentoSeleccionadoCombo()

        If dtProductoElegido Is Nothing And cmbDescripMedica.Text.Trim().Length <= 1 Then
            MsgBox("Debe digitar la información del producto")
            Exit Sub
        End If


        ''prueba para compilar 20200205 

        'rmzaldua 
        'Cambio realizado por Ing. Ricardo Mauricio Zaluda
        'Motivo se realizo validacion para que escojan un tipo de Vía de Administración 
        '2009-10-22
        'solicitado por Juan Diego Arenas

        ''Claudia Garay Noviembre 17 de 2010
        ''Cambio de combo de via de administracion por textbox con formato
        'If cmbViaAdmin.SelectedValue.ToString = "" Then
        If txtDescripcionVA.Text = "" Then
            txtDescripcionVA.Focus()
            'MsgBox("Debe escoger vía de administración")
            Exit Sub
        End If
        ''Claudia Garay Noviembre 24 2010
        'If txtDescripcionFreq.Text = "" Then
        '    MsgBox("Debe escoger una Frecuencia")
        '    Exit Sub
        'End If

        'VALIDACIONES
        ''Claudia Garay Noviembre 17 de 2010 cambio de combo unidad de medida y via de administracion a textbox con formato
        If Not BLOrdenes.validarMedicamento(dtProductoElegido.Item("codigo").ToString, dtProductoElegido.Item("descripcion").ToString,
                                            Me.txtDosis.Text, Me.txtDescripcionUM.Text, Me.txtDescripcionVA.Text, Me.txtDescripcionFreq.SelectedValue,
                                            Me.txtDescripcionFreq.Text, Me.chkUnicaDosis.Checked, dtMedica, mensaje) Then
            MsgBox(mensaje, MsgBoxStyle.Information)
            Exit Sub

        End If

        'VALIDACION DEL CONVENIO DEL MEDICAMENTO PARA LA ENTIDAD COMO FORMA INFORMATIVA
        tieneConvenio = BLOrdenes.medicamentoTieneConvenio(datosConexion, dtProductoElegido.Item("codigo").ToString,
                                                           datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.Entidad)


        ''Se consulta si la entidad maneja convenio
        strEntidadManejaConvenio = objDatos.EjecutarSQLStrValor("GENENTID", datosConexion, "man_conv_med", "  entidad='" & datosPaciente.Entidad & "'")
        flag_pos = IIf(IsDBNull(dtProductoElegido.Item("flag_pos").ToString), "S", dtProductoElegido.Item("flag_pos").ToString)

        ''Se realizara esta validacion solo para entidades con convenio
        ''Claudia Garay
        ''08 feb 2010        
        If Not tieneConvenio And strEntidadManejaConvenio = "S" Then
            MsgBox("El medicamento no tiene convenio para esta entidad.", MsgBoxStyle.Information)
        End If

        If Len(LTrim(txtCantidadC.Text)) = 0 Then
            GroupCnt24.Enabled = True
            If dtProductoElegido.Item("MedControl").ToString = "S" Then
                ''' 10/2019
                ''' Req. ER_OSI_584 Prescripcion_de_medicamentos
                ''' Se omite esta funcionalidad
                'If MsgBox("¿Desea imprimir la fórmula de control?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                '    GroupCnt24.Enabled = True
                '    MsgBox("Ingrese la cantidad")
                '    txtCantidadC.Focus()
                '    Exit Sub
                'Else
                '    GroupCnt24.Enabled = False
                'End If

            End If
        Else
            BoolFormuladeControl = True
        End If

        Dim daoGeneral As New DAOGeneral

        pide_ctc = daoGeneral.EjecutarSQLStrValor("gensucur (nolock)", datosConexion, " pide_ctc", " cod_sucur='" & datosLogin.Sucursal & "'")
        pide_SISPRO = daoGeneral.EjecutarSQLStrValor("gensucur (nolock)", datosConexion, " pide_SISPRO", " cod_sucur='" & datosLogin.Sucursal & "'")
        pag_SISPRO = daoGeneral.EjecutarSQLStrValor("pargener (nolock)", datosConexion, " pagsispro", " cod_pre_sgs='" & datosLogin.Prestador & "'")

        'Version 3.0.0 CTC para medicina prepagada herojas 2015/01/15
        Dim strGenExcep As Boolean
        Dim strGenCTC_MP As String

        strGenExcep = False
        strGenCTC_MP = "N"

        If datosPaciente.TipoEntidad = "PRE" Then

            strGenExcep = BLOrdenes.ConsultaExcepciones(datosPaciente.Entidad, txtCodMedica.Text)

            If strGenExcep Then

                MsgBox("El medicamento Elegido no tiene cobertura para la  entidad " & datosPaciente.DescripcionEntidad, MsgBoxStyle.Information)

                strGenCTC_MP = BLOrdenes.PideCTCMP(datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.TipoAdmision,
                            datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision, txtCodMedica.Text)
            End If
        End If

        ' ''Ctc Marzo 21 de 2012 cpgaray
        ''pide_ctc = "S" And 
        If (datosPaciente.TipoEntidad = "EPS" Or strGenCTC_MP = "S") And pide_ctc = "S" Then
            ' Hernan Rojas 2014/05/12 No debe solicitar ctc cuando tiene uno vigente            
            flag_pos = IIf(IsDBNull(dtProductoElegido.Item("flag_pos").ToString), "S", dtProductoElegido.Item("flag_pos").ToString)
            'If BLOrdenes.ConsultaExcepciones(datosPaciente.Entidad, txtCodMedica.Text) = True Then
            If flag_pos = "N" Then
                If Not BLOrdenes.MedicamentoTieneCTC(datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.TipoAdmision,
                        datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision, txtCodMedica.Text) Then
                    MsgBox("El medicamento elegido es no POS por favor diligenciar la Justificación de Uso para CTC", MsgBoxStyle.Information)
                    BoolEsExcepcion = True
                    'dtcmbFRE = txtDescripcionFreq.OrigenDeDatos
                    dtcmbFRE = txtDescripcionFreq.DataSource

                    rows = dtcmbFRE.Select("descripcion='" & txtDescripcionFreq.Text & "'")

                    If chkUnicaDosis.Checked = False Then
                        If rows.Length = 0 Then
                            frecuencia = 0
                        Else
                            If rows(0).Item("CadaNroHoras").ToString <> "0" Then
                                frecuencia = CDbl(rows(0).Item("CadaNroHoras").ToString)
                                DosisXDia = CDbl(txtDosis.Text) * (24 / frecuencia)
                            Else
                                frecuenciacod = rows(0).Item("Frecuencia").ToString
                                If frecuenciacod = "40" Then ''7 minutos
                                    DosisXDia = CDbl(txtDosis.Text) * (1440 / 7)
                                ElseIf frecuenciacod = "41" Then '' 10 minutos
                                    DosisXDia = CDbl(txtDosis.Text) * (1440 / 10)
                                ElseIf frecuenciacod = "42" Then '' 15 minutos
                                    DosisXDia = CDbl(txtDosis.Text) * (1440 / 15)
                                ElseIf frecuenciacod = "37" Or frecuenciacod = "25" Or frecuenciacod = "45" Then '' Antes de las comidas , con las comidas , despues de la comida
                                    DosisXDia = CDbl(txtDosis.Text) * 3
                                ElseIf frecuenciacod = "33" Then '' Ahora
                                    DosisXDia = CDbl(txtDosis.Text)
                                ElseIf 1 = 0 Then


                                Else
                                    DosisXDia = 0
                                End If

                                frecuencia = 0
                            End If

                        End If
                    Else
                        DosisXDia = CDbl(txtDosis.Text) ''Unica dosis
                    End If

                    frmc_JustificaExcepcion.Mostrar(txtCodMedica.Text, frecuencia, datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.TipoAdmision, datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision, datosLogin.Login, datosConexion)
                    frmc_JustificaExcepcion.ShowDialog()
                    If frmc_JustificaExcepcion.dtCtc.Rows.Count = 0 Then
                        Exit Sub
                    Else
                        dtCtc = frmc_JustificaExcepcion.dtCtc
                    End If
                    'frmc_JustificaExcepcion.strJustificacion = String.Empty
                    'frmc_JustificaExcepcion.txtJustificacion.Text = String.Empty
                End If
            End If
        Else
            If (datosPaciente.TipoEntidad = "EPS" Or strGenCTC_MP = "S") And pide_SISPRO = "S" Then
                If flag_pos = "N" Then
                    If String.IsNullOrEmpty(Me.txtDiasTrat.Text) Or Me.txtDiasTrat.Text.Trim() = "0" Then
                        'If Me.txtDiasTrat.Text < 1 Then
                        MsgBox("debe digitar los dias de tratamiento", MsgBoxStyle.Information, "Conciliaciòn de medicamentos")
                        Me.txtDiasTrat.Focus()
                        Exit Sub
                    End If
                    flag_posCondicionado = BLOrdenes.existePosCondicionado(datosConexion, datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.TipoAdmision, datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision, "M", dtProductoElegido.Item("codigo").ToString)
                    If flag_posCondicionado = True Then
                        cod_Sispro = "POS Condicionado"
                        MsgBox("El elemento prescrito es POS Condicionado por Diagnóstico", MsgBoxStyle.Information)
                    Else
                        System.Diagnostics.Process.Start(pag_SISPRO)
                        frm_SISPRO.Text = "Registro Radicado MIPRES"
                        frm_SISPRO.Mostrar(cod_Sispro)
                        cod_Sispro = frm_SISPRO.Cod_SISPRO1
                    End If

                End If
            Else
                BoolEsExcepcion = False
            End If

        End If
        If flag_pos = "N" Then
            If String.IsNullOrEmpty(Me.txtDiasTrat.Text) Or Me.txtDiasTrat.Text.Trim() = "0" Then
                MsgBox("debe digitar los dias de tratamiento", MsgBoxStyle.Information, "Conciliaciòn de medicamentos")
                Me.txtDiasTrat.Focus()
                Exit Sub
            End If
        End If
        If txtPasarEn.Visible = True Then
            If String.IsNullOrEmpty(txtPasarEn.Text) Then
                Me.txtPasarEn.Focus()
                Exit Sub
            End If
        End If

        ' ER_OSI 584 eloaiza@intergrupo.com - Validar pre-existencia de medicamento y formulación

        Dim tabla As DataTable = dgtMedicaConcilSus.DataSource
        Dim descripcion As String = dtProductoElegido.Item("descProducto").ToString
        Dim prescripcion As String = txtDosis.Text & " " & txtDescripcionUM.Text.Trim() & " " & Me.txtDescripcionVA.Text.Trim() & " " &
                                     IIf(Not txtDescripcionFreq.Visible, "", txtDescripcionFreq.Text.Trim()) & " " &
                                     IIf(ChkBolo.Checked, " Bolo ", "") & "" &
                                     IIf(ChkBolo.Checked, IIf(Not txtPasarEn.Visible, "", "PASAR EN: " & txtPasarEn.Text.Trim() & " MINUTOS"), "") & "" &
                                     IIf(Not txtDurante24.Visible, "", " DURANTE: " & txtDurante24.Text.Trim() & " HORAS") &
                                     IIf(Not txtNumRescates.Visible, "", " Número de Rescates: " & txtNumRescates.Text.Trim()) & " " &
                                     IIf(Not txtNumDosis.Visible, "", "Número de Dosis: " & txtNumDosis.Text.Trim()) & " " & txtTecnica.Text



        Dim producto As String = dtProductoElegido.Item("codigo").ToString
        tabla.CaseSensitive = False

        Dim fila As DataRow() = tabla.Select("producto LIKE '" & producto.Trim().ToUpper() &
                                             "%' AND UniMedDosis =" & txtDescripcionUM.SelectedValue &
                                             " AND ViaAdministra = '" & txtDescripcionVA.SelectedValue &
                                             "'" & " AND Frecuencia =" & txtDescripcionFreq.SelectedValue &
        IIf(txtPasarEn.Text <> "", " AND OMPasarEn =" & txtPasarEn.Text.Trim(), " AND OMPasarEn = OMPasarEn ") & 'txtDurante24
        IIf(txtDiasTrat.Text <> "", " AND Diastrat =" & txtDiasTrat.Text.Trim(), " AND Diastrat = Diastrat ") &
        IIf(txtNumDosis.Text <> "", " AND OMNumDosis =" & txtNumDosis.Text.Trim(), " AND OMNumDosis = OMNumDosis ") & 'en la siguiente linea va txtDosis
        IIf(txtNumRescates.Text <> "", " AND OMRescates =" & txtNumRescates.Text.Trim(), " AND OMRescates = OMRescates "))

        Dim Dosistem As String
        Dim OMDuranteTem As String
        If fila.Length > 0 Then 'ALM_399 con este ajuste se valida los campos con formato decimal
            For i As Integer = 0 To tabla.Rows.Count - 1
                If producto = tabla.Rows(i).Item("producto").ToString Then
                    Dosistem = tabla.Rows(i).Item("Dosis").ToString
                    OMDuranteTem = tabla.Rows(i).Item("OMDurante").ToString
                    'If CDbl(Dosistem) = CDbl(txtDosis.Text) Then
                    '    If txtDurante24.Text <> "" Then
                    '        If CDbl(OMDuranteTem) = CDbl(txtDurante24.Text) Then
                    '            MsgBox("El medicamento ya cuenta con  una prescripción", MsgBoxStyle.Information, "Conciliaciòn de medicamentos")
                    '            Me.cmbDescripMedica.Focus()
                    '            Exit Sub
                    '        End If
                    '    Else
                    '        MsgBox("El medicamento ya cuenta con  una prescripción", MsgBoxStyle.Information, "Conciliaciòn de medicamentos")
                    '        Me.cmbDescripMedica.Focus()
                    '        Exit Sub
                    '    End If
                    'End If
                End If
            Next
        End If
        'Anterior
        'IIf(txtDurante24.Text <> "", " AND OMDurante =" & String.Format("{0:0.00}", CDbl(IIf(txtDurante24.Text.Trim() = "", "0", txtDurante24.Text.Trim()))), " AND OMDurante = OMDurante ") &
        '  IIf((String.Format("{0:0.00}", CDec(txtDosis.Text.Trim()))) <> "", " AND Dosis ='" & String.Format("{0:0.00}", CDec(txtDosis.Text.Trim())) & "'", " AND Dosis = Dosis ") & 'Se agrega formateo al campo txtDosis.Text. ALM_399 
        'IIf(txtDosis.Text <> "", " AND Dosis ='" & String.Format("{0:0.00}", CDbl(txtDosis.Text.Trim())) & "'", " AND Dosis = Dosis ") & 

        'If fila.Length > 0 Then
        '    MsgBox("El medicamento ya cuenta con  una prescripción", MsgBoxStyle.Information, "Conciliaciòn de medicamentos")
        '    Me.cmbDescripMedica.Focus()
        '    Exit Sub
        'End If

        'CREACION DE LA NUEVA FILA
        drFila = dtMedica.NewRow()
        ''Claudia Garay Noviembre 17 de 2010
        ''Cambio de combo de unidad de medida y via de administracion por textbox con formato
        'LLENADO DE LOS DATOS
        drFila("descripcion") = descripcion
        drFila("prescripcion") = prescripcion
        drFila("NombreMedico") = datosLogin.NombreMedico
        drFila("Especialidad") = datosLogin.DescripcionEspecialidad
        drFila("cod_pre_sgs") = datosLogin.Prestador
        drFila("cod_sucur") = datosLogin.Sucursal
        drFila("tip_admision") = datosPaciente.TipoAdmision
        drFila("ano_adm") = datosPaciente.AnoAdmision
        drFila("num_adm") = datosPaciente.NumeroAdmision
        drFila("NroOrden") = 0
        drFila("producto") = producto
        drFila("FormaFarma") = dtProductoElegido.Item("FormaFarma").ToString
        drFila("Presentacion") = dtProductoElegido.Item("Presentacion").ToString
        drFila("Contenido") = CDbl(IIf(dtProductoElegido.Item("Contenido").ToString = "", 0, dtProductoElegido.Item("Contenido").ToString)) ''Claudia Garay Noviembre Error al agregar med
        ''Claudia Garay Noviembre 17 de 2010
        ''Cambio de combo de unidad de medida y via de administracion por textbox con formato
        '-->drFila("Concentracion") = IIf(txtCodigoUM.Text = "", DBNull.Value, txtCodigoUM.Text) 'cmbUnidadMedida.SelectedValue  'dtProductoElegido.Item("Concentracion").ToString
        '-->drFila("UniMedDosis") = IIf(txtCodigoUM.Text = "", DBNull.Value, txtCodigoUM.Text)
        If String.IsNullOrEmpty(txtDosis.Text) Then
            txtDosis.Focus()
            Exit Sub
        End If

        drFila("Dosis") = CDbl(txtDosis.Text)
        drFila("ViaAdministra") = IIf(Me.txtDescripcionVA.SelectedValue = "", DBNull.Value, Me.txtDescripcionVA.SelectedValue) 'txtDescripcionVA.Text 'cmbViaAdmin.SelectedValue.ToString
        '        drFila("Frecuencia") = IIf('txtCodigoFreq.Text = "", DBNull.Value, 'txtCodigoFreq.Text)

        drFila("Concentracion") = IIf(Me.txtDescripcionUM.SelectedValue = "", DBNull.Value, Me.txtDescripcionUM.SelectedValue)
        'dtProductoElegido.Item("Concentracion").ToString() 'cmbUnidadMedida.SelectedValue  'dtProductoElegido.Item("Concentracion").ToString
        drFila("UniMedDosis") = IIf(Me.txtDescripcionUM.SelectedValue = "", DBNull.Value, Me.txtDescripcionUM.SelectedValue)

        drFila("Frecuencia") = IIf(Me.txtDescripcionFreq.SelectedValue = "", DBNull.Value, Me.txtDescripcionFreq.SelectedValue)
        drFila("TecnicaAdministra") = txtTecnica.Text
        drFila("UnicaDosis") = IIf(chkUnicaDosis.Checked, BLOrdenes.UNICADOSIS, BLOrdenes.VARIASDOSIS)
        drFila("obs") = ""

        If Me.chkUnicaDosis.Checked = True Then
            drFila("Tratamiento") = Nothing
            drFila("estado") = BLOrdenes.INACTIVO
        Else
            'CLAUDIA GARAY UNICA DOSIS INACTIVA
            drFila("Tratamiento") = Nothing
            drFila("estado") = BLOrdenes.ACTIVO
        End If
        drFila("medico") = datosLogin.Login
        drFila("Login") = datosLogin.Login
        ''Claudia Garay Noviembre 22 de 2010 Validar Medicamentos de control
        strMedControl = objDatos.EjecutarSQLStrValor("genprodu (nolock)", datosConexion, "med_controlado", " cod_corto='" & drFila("producto") & "'")
        If IsDBNull(strMedControl) Then
            strMedControl = "N"
        End If
        'Select Case strMedControl
        '    Case "A"
        '        strMedControl = "S"
        '    Case "I"
        '        strMedControl = "N"
        '    Case Else
        '        strMedControl = "N"
        'End Select
        drFila("MedControl") = strMedControl

        ''cpgaray Enero 5 de 2012 Medicamentos de Control
        If BoolFormuladeControl = True Then
            drFila("cantidadcontrol") = txtCantidadC.Text
            drFila("cantidadletrascontrol") = txtCantidadLetras.Text
        Else
            drFila("cantidadcontrol") = 0
            drFila("cantidadletrascontrol") = ""
        End If
        ''fin 
        'rmzaldua 2016-11-01
        If flag_pos = "N" Then
            drFila("diastrat") = Me.txtDiasTrat.Text
            drFila("CodSISPRO") = dtProductoElegido.Item("codsispro").ToString
            drFila("DesSISPRO") = dtProductoElegido.Item("dessispro").ToString
            drFila("autoSISPRO") = cod_Sispro

        Else
            If Len(Me.txtDiasTrat.Text) > 0 Then
                drFila("diastrat") = Me.txtDiasTrat.Text
            Else
                drFila("diastrat") = 0
            End If
            drFila("CodSISPRO") = ""
            drFila("DesSISPRO") = ""
            drFila("autoSISPRO") = ""
        End If

        If BoolEsExcepcion = True Then
            ''ctc Noviembre 27 de 2012
            'BLOrdenes.GrabarErroresOrdenesMedicas("HistoriaMedicaCTC" & " Entra llenar datos ctc para xml")
            drFila("cod_corto") = dtCtc.Rows(0).Item("cod_corto")
            drFila("concentracionEq") = dtCtc.Rows(0).Item("concentracion")
            drFila("for_farma") = dtCtc.Rows(0).Item("for_farma")
            drFila("diasTratamiento") = dtCtc.Rows(0).Item("diasTratamiento")
            drFila("DosisXDia") = dtCtc.Rows(0).Item("DosisXDia")
            If DosisXDia <> 0 Then
                drFila("DosisXDiaNoPos") = Round(DosisXDia, 2) & " " & IIf(txtDescripcionUM.Text = "", DBNull.Value, txtDescripcionUM.Text)
            Else
                drFila("DosisXDiaNoPos") = ""
            End If

            drFila("fec_desde") = dtCtc.Rows(0).Item("fec_desde")
            drFila("fec_hasta") = dtCtc.Rows(0).Item("fec_hasta")
            drFila("diagnost") = dtCtc.Rows(0).Item("diagnost")
            drFila("clasificacion") = dtCtc.Rows(0).Item("clasificacion")
            drFila("obsDiagn") = dtCtc.Rows(0).Item("obs")
            drFila("Justificacion") = dtCtc.Rows(0).Item("Justificacion")

        End If

        ''' 10/2019
        ''' Req. ER_OSI_584 Prescripcion_de_medicamentos

        drFila("viaBolo") = ChkBolo.Checked
        drFila("OMDurante") = IIf(txtDurante24.Visible = False, "0", txtDurante24.Text)
        drFila("OMPasarEn") = IIf(txtPasarEn.Visible = False, "0", txtPasarEn.Text)
        drFila("OMRescates") = IIf(txtNumRescates.Visible = False, "0", txtNumRescates.Text)
        drFila("OMNumDosis") = IIf(txtNumDosis.Visible = False, "0", txtNumDosis.Text)
        drFila("idRegistro") = "N" ' Indicador para marcar el registro como  nuevo
        drFila("origen") = "NordenMed"
        'ADICIONA LA NUEVA FILA A LA TABLA
        dtMedica.Rows.Add(drFila)
        ''ADICIONA A LA TABLA DEL PAGINADOR
        'dtSource.Rows.Add(drFila)  'Claudia Garay Noviembre 18 de 2010
        'ENLAZA LA TABLA Y EL DATAGRID

        dgtMedicaConcil.DataSource = dtMedica


        For i As Integer = 0 To dgtMedicaConcil.Rows.Count - 7
            If dgtMedicaConcil.Rows(i).IsNewRow Then
                dgtMedicaConcil.Rows(i).Cells(0).ReadOnly = True
            End If

        Next

        InicializaValorControles()
        pnlDurante.Visible = False
        pnlPasarEn.Visible = False
        pnlRescate.Visible = False
        pnlNumDosis.Visible = False
        InicializaValorControles()
        Me.lblDiasTrat.Visible = False
        Me.txtDiasTrat.Visible = False
        Me.txtDiasTrat.Text = ""
        Me.txtDiasTrat.ReadOnly = False
        Me.GroupCnt24.Visible = False
        'Me.txtCantidadC.Enabled = False
        'Me.Label14.Enabled = False
        'Me.Label9.Enabled = False

        valorModificar = String.Empty
        LimpiarPanel(Panel1, Nothing)
        txtCantidadC.Text = String.Empty
        BoolFormuladeControl = False
        txtCantidadLetras.Text = String.Empty
        'GroupCnt24.Visible = False
        strJustificacionL = String.Empty
        'LIMPIA EL DATASOURCE DEL COMBO DE BUSQUEDA
        cmbDescripMedica.OrigenDeDatos.Rows.Clear()
        'txtCodMedica.Focus()
        Me.datosSinAlmacenar = True
    End Sub

    Private Function validarExistenciaOrdenMedica(tabla As DataTable, i As Integer) As Boolean
        Dim producto As String = ((tabla.Rows(i))).ItemArray(14)
        _Ordenes.TablasOrdenes = BLOrdenes.consultarOrdenes(datosConexion, datosLogin.Prestador, datosLogin.Sucursal,
                                      datosPaciente.TipoAdmision, datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision)

        Dim tabla2 As DataTable = _Ordenes.TablasOrdenes.Tables("MEDICAMENTOS")

        'For i = 0 To tabla2.Rows.Count - 1

        '    If tabla2.Rows(i).Item("obs") = "M" Then

        '    End If
        '    End For



        Dim fila As DataRow() = tabla2.Select("producto LIKE '" & producto.Trim().ToUpper() &
                             "%' AND UniMedDosis =" & txtDescripcionUM.SelectedValue &
                             " AND ViaAdministra = '" & txtDescripcionVA.SelectedValue &
                             "'" & " AND Frecuencia =" & txtDescripcionFreq.SelectedValue &
         IIf(txtDosis.Text <> "", " AND Dosis ='" & FormatNumber(CDbl(txtDosis.Text.Trim()), 2) & "'", " AND Dosis = Dosis ")
        )
        '&
        'IIf(txtPasarEn.Text <> "", " AND OMPasarEn =" & txtPasarEn.Text.Trim(), " AND OMPasarEn = OMPasarEn ") &
        'IIf(txtDurante24.Text <> "", " AND OMDurante ='" & txtDurante24.Text.Trim() & "'", "AND OMDurante = OMDurante ") &
        'IIf(txtDiasTrat.Text <> "", " AND Diastrat =" & txtDiasTrat.Text.Trim(), " AND Diastrat = Diastrat ") &
        'IIf(txtNumDosis.Text <> "", " AND OMNumDosis =" & txtNumDosis.Text.Trim(), " AND OMNumDosis = OMNumDosis ") &
        'IIf(txtDosis.Text <> "", " AND Dosis ='" & txtDosis.Text.Trim() & "'", " AND Dosis = Dosis ") &
        'IIf(txtNumRescates.Text <> "", " AND OMRescates ='" & txtNumRescates.Text.Trim() & "'", "AND OMRescates = OMRescates "))

        If fila.Length > 0 Then
            Return True
        End If
        Return False
    End Function


    Private Function ActualizaModificados(ByVal dtMedica As DataTable) As Boolean
        Dim i As Integer
        Dim dtcmbFRE As New DataTable
        Dim rows() As DataRow
        Dim drFila As DataRow
        Dim cod_Sispro As String = ""
        Dim flag_posCondicionado As Boolean
        Dim intIndice As Integer ' @eloaiza@intergrupo.com REQ ER_OSI 584
        ActualizaModificados = False
        For i = 0 To dtMedica.Rows.Count - 1

            If dtMedica.Rows(i).Item("obs") = "M" Then



                ' ER_OSI 584 eloaiza@intergrupo.com - Validar pre-existencia de medicamento y formulación

                Dim tabla As DataTable = dgtMedicaConcil.DataSource

                Dim existe As Boolean = validarExistenciaOrdenMedica(tabla, i)

                Dim prescripcion As String = txtDosis.Text & " " & txtDescripcionUM.Text.Trim() & " " & Me.txtDescripcionVA.Text.Trim() & " " &
                                     IIf(Not txtDescripcionFreq.Visible, "", txtDescripcionFreq.Text.Trim()) & " " &
                                     IIf(ChkBolo.Checked, " Bolo ", "") & "" &
                                     IIf(ChkBolo.Checked, IIf(Not txtPasarEn.Visible, "", "PASAR EN: " & txtPasarEn.Text.Trim() & " MINUTOS"), "") & "" &
                                     IIf(Not txtDurante24.Visible, "", " DURANTE: " & txtDurante24.Text.Trim() & " HORAS") &
                                     IIf(Not txtNumRescates.Visible, "", " Número de Rescates: " & txtNumRescates.Text.Trim()) & " " &
                                     IIf(Not txtNumDosis.Visible, "", "Número de Dosis: " & txtNumDosis.Text.Trim())

                If (existe) Then
                    MsgBox("El medicamento ya cuenta con  una prescripción", MsgBoxStyle.Information, "Conciliaciòn de medicamentos")
                    'dtMedica.Rows(i).Item("Tratamiento").Value = ""
                    'dtMedica.Rows(i).Item("tmp_suspender_med").Value = ""
                    'dtMedica.Rows(i).Item("tmp_modificar_med").Value = ""
                    'Me.cmbDescripMedica.Focus(
                    'LimpiarDatos()
                    flaglimpiacampos = False
                    ActualizaModificados = True
                    Exit For
                End If

                Dim producto As String = ((tabla.Rows(i))).ItemArray(14)
                'ajuste realizado por Ricardo Zaldua validacion datos scring en la igualdad
                Dim fila As DataRow() = tabla.Select("producto LIKE '" & producto.Trim().ToUpper() &
                                             "%' AND UniMedDosis =" & txtDescripcionUM.SelectedValue &
                                             " AND ViaAdministra = '" & txtDescripcionVA.SelectedValue &
                                             "'" & " AND Frecuencia =" & txtDescripcionFreq.SelectedValue &
        IIf(txtPasarEn.Text <> "", " AND OMPasarEn =" & txtPasarEn.Text.Trim(), " AND OMPasarEn = OMPasarEn ") &
        IIf(txtDurante24.Text <> "", " AND OMDurante ='" & txtDurante24.Text.Trim() & "'", "AND OMDurante = OMDurante ") &
        IIf(txtDiasTrat.Text <> "", " AND Diastrat =" & txtDiasTrat.Text.Trim(), " AND Diastrat = Diastrat ") &
        IIf(txtNumDosis.Text <> "", " AND OMNumDosis =" & txtNumDosis.Text.Trim(), " AND OMNumDosis = OMNumDosis ") &
        IIf(txtDosis.Text <> "", " AND Dosis ='" &  txtDosis.Text.Trim() & "'", " AND Dosis = Dosis ") &
        IIf(txtNumRescates.Text <> "", " AND OMRescates ='" & txtNumRescates.Text.Trim() & "'", "AND OMRescates = OMRescates ") &
        IIf(txtorigengrilla.Text <> "", "AND origen = 'OrdenMed'", "AND origen = origen"))

                ''Dim producto As String = ((tabla.Rows(i))).ItemArray(1)

                If fila.Length > 0 Then
                    MsgBox("El medicamento ya cuenta con  una prescripción", MsgBoxStyle.Information, "Conciliaciòn de medicamentos")
                    'dtMedica.Rows(i).Item("Tratamiento").Value = ""
                    'dtMedica.Rows(i).Item("tmp_suspender_med").Value = ""
                    'dtMedica.Rows(i).Item("tmp_modificar_med").Value = ""
                    'Me.cmbDescripMedica.Focus(
                    'LimpiarDatos()
                    flaglimpiacampos = False
                    ActualizaModificados = True
                    Exit For
                End If


                ' FIN ER_OSI 584 eloaiza@intergrupo.com - Validar pre-existencia de medicamento y formulación

                If MsgBox("¿Está seguro de ingresar esta formulaciòn?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    falg_modificar = 0
                    If dtMedica.Rows(i).Item("MedControl") = "S" Then
                        'If MsgBox("¿Desea imprimir la fórmula de control?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        '    txtCantidadC.Text = Val(txtCantidadC.Text)
                        '    txtCantidadLetras.Text = txtCantidadLetras.Text
                        '    GroupCnt24.Enabled = True
                        ActualizaModificados = True
                        '    Exit Function
                        'Else
                        txtCantidadC.Text = Val(txtCantidadC.Text)
                        txtCantidadLetras.Text = txtCantidadLetras.Text
                        GroupCnt24.Enabled = False
                        'End If

                    End If
                    intIndice = i
                    dtMedica.Rows(i).Item("estado") = BLOrdenes.INACTIVO
                    dtMedica.Rows(i).Item("Tratamiento") = BLOrdenes.SUSPENDE
                    dtMedica.Rows(i).Item("obs") = "N"

                    drFila = dtMedica.NewRow()

                    'dtMedica.Rows(i).Item("Dosis") = CDbl(txtDosis.Text)
                    'dtMedica.Rows(i).Item("UniMedDosis") = cmbUnidadMedida.SelectedValue.ToString
                    'dtMedica.Rows(i).Item("ViaAdministra") = cmbViaAdmin.SelectedValue.ToString

                    'If 'txtCodigoFreq.Text = "" Then
                    '    dtcmbFRE = txtDescripcionFreq.OrigenDeDatos
                    '    rows = dtcmbFRE.Select("descripcion='" & txtDescripcionFreq.Text & "'")
                    '    'txtCodigoFreq.Text = rows(0).Item("frecuencia").ToString

                    'End If

                    'BLOrdenes.actualizarEstado(dtMedica.Rows(i), BLOrdenes.CONTINUA, dtgMedicamentos.CurrentCell.Value)

                    'dtMedica.Rows(i).Item("Frecuencia") = 'txtCodigoFreq.Text
                    'dtMedica.Rows(i).Item("TecnicaAdministra") = txtTecnica.Text
                    'dtMedica.Rows(i).Item("UnicaDosis") = IIf(chkUnicaDosis.Checked, BLOrdenes.UNICADOSIS, BLOrdenes.VARIASDOSIS)
                    'dtMedica.Rows(i).Item("prescripcion") = txtDosis.Text & "  " & cmbUnidadMedida.Text & "  " & Me.cmbViaAdmin.Text & "  " & _
                    '                     IIf(chkUnicaDosis.Checked, "UNICA DOSIS", txtDescripcionFreq.Text) & "  " & txtTecnica.Text
                    'dtMedica.Rows(i).Item("obs") = ""
                    'If Me.chkUnicaDosis.Checked = True Then
                    '    dtMedica.Rows(i).Item("Tratamiento") = Nothing
                    '    dtMedica.Rows(i).Item("estado") = BLOrdenes.INACTIVO
                    'Else
                    '    dtMedica.Rows(i).Item("Tratamiento") = BLOrdenes.CONTINUA
                    '    dtMedica.Rows(i).Item("estado") = BLOrdenes.ACTIVO
                    'End If
                    ' ''  dtMedica.Rows(i).Item("descripcion") = dtProductoElegido.Item("descProducto").ToString 'cmbDescripMedica.Text

                    'LLENADO DE LOS DATOS
                    drFila("descripcion") = dtMedica.Rows(i).Item("descripcion")
                    drFila("NombreMedico") = datosLogin.NombreMedico
                    drFila("Especialidad") = datosLogin.DescripcionEspecialidad
                    drFila("cod_pre_sgs") = datosLogin.Prestador
                    drFila("cod_sucur") = datosLogin.Sucursal
                    drFila("tip_admision") = datosPaciente.TipoAdmision
                    drFila("ano_adm") = datosPaciente.AnoAdmision
                    drFila("num_adm") = datosPaciente.NumeroAdmision
                    drFila("NroOrden") = 0
                    drFila("producto") = dtMedica.Rows(i).Item("producto")
                    drFila("FormaFarma") = dtMedica.Rows(i).Item("FormaFarma")
                    drFila("Presentacion") = dtMedica.Rows(i).Item("Presentacion")
                    drFila("Contenido") = dtMedica.Rows(i).Item("Contenido")
                    '   drFila("Concentracion") = IIf(txtCodigoUM.Text = "", DBNull.Value, txtCodigoUM.Text) 'cmbUnidadMedida.SelectedValue  'dtProductoElegido.Item("Concentracion").ToString
                    drFila("Concentracion") = IIf(Me.txtDescripcionUM.SelectedValue = "", DBNull.Value, Me.txtDescripcionUM.SelectedValue)
                    drFila("Dosis") = CDbl(txtDosis.Text)
                    '   drFila("UniMedDosis") = IIf(txtCodigoUM.Text = "", DBNull.Value, txtCodigoUM.Text)
                    drFila("UniMedDosis") = IIf(Me.txtDescripcionUM.SelectedValue = "", DBNull.Value, Me.txtDescripcionUM.SelectedValue)
                    drFila("ViaAdministra") = IIf(Me.txtDescripcionVA.SelectedValue = "", DBNull.Value, Me.txtDescripcionVA.SelectedValue) 'txtDescripcionVA.Text 'txtDescripcionVA.Text 'cmbViaAdmin.SelectedValue.ToString
                    drFila("cantidadcontrol") = Val(txtCantidadC.Text)
                    drFila("cantidadletrascontrol") = txtCantidadLetras.Text
                    drFila("MedControl") = dtMedica.Rows(i).Item("MedControl")

                    If Me.txtDescripcionFreq.SelectedValue = "" Then
                        '                        dtcmbFRE = txtDescripcionFreq.OrigenDeDatos
                        dtcmbFRE = txtDescripcionFreq.DataSource
                        rows = dtcmbFRE.Select("descripcion='" & txtDescripcionFreq.Text & "'")
                        Me.txtDescripcionFreq.SelectedValue = rows(0).Item("frecuencia").ToString

                    End If

                    drFila("Frecuencia") = IIf(Me.txtDescripcionFreq.SelectedValue = "", DBNull.Value, Me.txtDescripcionFreq.SelectedValue)
                    'BLOrdenes.actualizarEstado(dtMedica.Rows(i), BLOrdenes.CONTINUA, dtgMedicamentos.CurrentCell.Value)

                    drFila("TecnicaAdministra") = txtTecnica.Text
                    drFila("UnicaDosis") = IIf(chkUnicaDosis.Checked, BLOrdenes.UNICADOSIS, BLOrdenes.VARIASDOSIS)
                    ''martovar 2018-05-25 Se envia la orden y la secuencia en el campo de la oden medica origen 
                    drFila("obs") = dtMedica.Rows(i).Item("Nroorden").ToString + "|" + dtMedica.Rows(i).Item("secuencia").ToString


                    If Me.chkUnicaDosis.Checked = True Then
                        drFila("Tratamiento") = Nothing
                        drFila("estado") = BLOrdenes.INACTIVO
                    Else
                        drFila("Tratamiento") = Nothing
                        drFila("estado") = BLOrdenes.ACTIVO
                    End If
                    drFila("medico") = datosLogin.Login
                    drFila("Login") = datosLogin.Login
                    drFila("prescripcion") = txtDosis.Text & " " & txtDescripcionUM.Text.Trim() & " " & Me.txtDescripcionVA.Text.Trim() & " " &
                                             IIf(chkUnicaDosis.Checked, "UNICA DOSIS", txtDescripcionFreq.Text.Trim()) & " " &
                                             IIf(Not txtNumRescates.Visible, "", " Rescates: " & txtNumRescates.Text.Trim()) & " " &
                                             IIf(Not txtNumDosis.Visible, "", " Número de Dosis: " & txtNumDosis.Text.Trim()) & "" &
                                             IIf(Not txtPasarEn.Visible, "", " Pasar en: " & txtPasarEn.Text.Trim()) & " " &
                                              IIf(Not txtDurante24.Visible, "", " Durante: " & txtDurante24.Text.Trim()) & " " & txtTecnica.Text.Trim()
                    ' ER_OSI 584 se cambia por la nueva concatenación
                    'txtDosis.Text & "  " & txtDescripcionUM.Text & "  " & Me.txtDescripcionVA.Text & "  " &
                    '                            IIf(chkUnicaDosis.Checked, "UNICA DOSIS", txtDescripcionFreq.Text) & "  " & txtTecnica.Text
                    If Me.txtDiasTrat.Text = "" Then
                        drFila("diastrat") = 0
                    Else
                        drFila("diastrat") = Me.txtDiasTrat.Text
                    End If

                    drFila("CodSISPRO") = dtMedica.Rows(i).Item("CodSISPRO")
                    Dim pide_SISPRO As String = ""
                    Dim strGenCTC_MP As String = "N"
                    Dim daoGeneral As New DAOGeneral

                    pide_SISPRO = daoGeneral.EjecutarSQLStrValor("gensucur (nolock)", datosConexion, " pide_SISPRO", " cod_sucur='" & datosLogin.Sucursal & "'")
                    drFila("DesSISPRO") = dtMedica.Rows(i).Item("DesSISPRO")

                    strGenCTC_MP = BLOrdenes.PideCTCMP(datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.TipoAdmision,
                            datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision, txtCodMedica.Text)


                    If (datosPaciente.TipoEntidad = "EPS" Or strGenCTC_MP = "S") And pide_SISPRO = "S" Then 'Not IsDBNull(dtMedica.Rows(i).Item("CodSISPRO"))

                        If Len(dtMedica.Rows(i).Item("autoSISPRO")) > 0 Then

                            Dim pag_SISPRO As String

                            ''pide_SISPRO = DAOGeneral.EjecutarSQLStrValor("gensucur (nolock)", datosConexion, " pide_SISPRO", " cod_sucur='" & datosLogin.Sucursal & "'")
                            pag_SISPRO = daoGeneral.EjecutarSQLStrValor("pargener (nolock)", datosConexion, " pagsispro", " cod_pre_sgs='" & datosLogin.Prestador & "'")

                            If Me.txtDiasTrat.Text = "" And txtDiasTrat.Visible Then
                                MsgBox("debe digitar los dias de tratamiento", MsgBoxStyle.Information, "Conciliaciòn de medicamentos")
                                Me.txtDiasTrat.Focus()
                                dtMedica.Rows(i).Item("obs") = "M"
                                ActualizaModificados = True
                                Exit Function
                            End If

                            flag_posCondicionado = BLOrdenes.existePosCondicionado(datosConexion, datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.TipoAdmision, datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision, "M", dtMedica.Rows(i).Item("producto"))
                            If flag_posCondicionado = True Then
                                cod_Sispro = "POS Condicionado"
                                MsgBox("El elemento prescrito es POS Condicionado por Diagnóstico", MsgBoxStyle.Information, "Procedimientos")
                            Else
                                System.Diagnostics.Process.Start(pag_SISPRO)
                                frm_SISPRO.Text = "Registro Radicado MIPRES"
                                frm_SISPRO.Mostrar(cod_Sispro)
                                cod_Sispro = frm_SISPRO.Cod_SISPRO1
                            End If
                        Else
                            cod_Sispro = ""
                        End If
                    End If
                    drFila("autoSISPRO") = cod_Sispro

                    ''' 10/2019
                    ''' Req. ER_OSI_584 Prescripcion_de_medicamentos
                    drFila("viaBolo") = ChkBolo.Checked.ToString()
                    drFila("OMDurante") = IIf(String.IsNullOrEmpty(txtDurante24.Text.Trim()), "0", txtDurante24.Text.Trim())
                    drFila("OMPasarEn") = IIf(String.IsNullOrEmpty(txtPasarEn.Text.Trim()), "0", txtPasarEn.Text.Trim())
                    drFila("OMRescates") = IIf(String.IsNullOrEmpty(txtNumRescates.Text.Trim()), "0", txtNumRescates.Text.Trim())
                    drFila("OMNumDosis") = IIf(String.IsNullOrEmpty(txtNumDosis.Text.Trim()), "0", txtNumDosis.Text.Trim())
                    drFila("idRegistro") = ""
                    'CU03 Hrariza@
                    'Inicio
                    drFila("conciliado") = "S" '--- validar que el nuevo pase por aqui
                    drFila("origen") = "NordenMed"
                    'Fin
                    'ADICIONA LA NUEVA FILA A LA TABLA
                    dtMedica.Rows.Add(drFila)
                    'ADICIONA A LA TABLA DEL PAGINADOR CLAUDIA GARAY NOVIEMBRE DE 2010
                    'dtSource.Rows.Add(drFila)
                    'ENLAZA LA TABLA Y EL DATAGRID

                    dgtMedicaConcil.DataSource = dtMedica

                    LimpiarPanel(Panel1, Nothing)
                    txtCantidadC.Text = String.Empty
                    txtCantidadLetras.Text = String.Empty
                    GroupCnt24.Enabled = False
                    'LIMPIA EL DATASOURCE DEL COMBO DE BUSQUEDA
                    cmbDescripMedica.OrigenDeDatos.Rows.Clear()
                    'txtCodMedica.Focus()
                    Me.datosSinAlmacenar = True

                    dtMedica.Rows(i).Item("estado") = BLOrdenes.INACTIVO
                    dtMedica.Rows(i).Item("Tratamiento") = BLOrdenes.SUSPENDE
                    ActualizaModificados = True
                    ' txtCodMedica.Enabled = True
                    cmbDescripMedica.Enabled = True

                    ' Se inactiva la fila modificada
                    'DirectCast(datagridgenerico.Rows(intIndice).Cells("continuar_med"), DataGridViewCheckBoxCell).Value = valoresContinuar(1)
                    DirectCast(dgtMedicaConcil.Rows(intIndice).Cells("modificar_med"), DataGridViewCheckBoxCell).Value = valoresModificar(0)
                    DirectCast(dgtMedicaConcil.Rows(intIndice).Cells("suspender_med"), DataGridViewCheckBoxCell).Value = valoresSuspender(1)

                    'DirectCast(datagridgenerico.Rows(intIndice).Cells("continuar_med"), DataGridViewCheckBoxCell).ReadOnly = True
                    DirectCast(dgtMedicaConcil.Rows(intIndice).Cells("modificar_med"), DataGridViewCheckBoxCell).ReadOnly = True
                    DirectCast(dgtMedicaConcil.Rows(intIndice).Cells("suspender_med"), DataGridViewCheckBoxCell).ReadOnly = True

                    ' Se inactiva la fila nueva
                    'DirectCast(datagridgenerico.Rows(datagridgenerico.RowCount - 1).Cells("continuar_med"), DataGridViewCheckBoxCell).ReadOnly = True
                    DirectCast(dgtMedicaConcil.Rows(dgtMedicaConcil.RowCount - 1).Cells("modificar_med"), DataGridViewCheckBoxCell).ReadOnly = True
                    DirectCast(dgtMedicaConcil.Rows(dgtMedicaConcil.RowCount - 1).Cells("suspender_med"), DataGridViewCheckBoxCell).ReadOnly = True

                Else
                    falg_modificar = 1
                    flaglimpiacampos = True
                    intIndice = i
                    'DirectCast(datagridgenerico.Rows(intIndice).Cells("continuar_med"), DataGridViewCheckBoxCell).Value = valoresContinuar(1)
                    DirectCast(dgtMedicaConcil.Rows(intIndice).Cells("modificar_med"), DataGridViewCheckBoxCell).Value = valoresModificar(1)
                    DirectCast(dgtMedicaConcil.Rows(intIndice).Cells("suspender_med"), DataGridViewCheckBoxCell).Value = valoresSuspender(1)
                    ActualizaModificados = True
                End If

            End If
        Next
    End Function

    Private Function ActualizaModificadosSuspendidos(ByVal dtMedica As DataTable) As Boolean
        Dim i As Integer
        Dim dtcmbFRE As New DataTable
        Dim rows() As DataRow
        Dim drFila As DataRow
        Dim cod_Sispro As String = ""
        Dim flag_posCondicionado As Boolean
        Dim intIndice As Integer ' @eloaiza@intergrupo.com REQ ER_OSI 584
        ActualizaModificadosSuspendidos = False
        For i = 0 To dtMedica.Rows.Count - 1

            If dtMedica.Rows(i).Item("obs") = "M" Then



                ' ER_OSI 584 eloaiza@intergrupo.com - Validar pre-existencia de medicamento y formulación

                Dim tabla As DataTable = dgtMedicaConcilSus.DataSource

                Dim tabla2 As DataTable = dgtMedicaConcil.DataSource


                Dim prescripcion As String = txtDosis.Text & " " & txtDescripcionUM.Text.Trim() & " " & Me.txtDescripcionVA.Text.Trim() & " " &
                                     IIf(Not txtDescripcionFreq.Visible, "", txtDescripcionFreq.Text.Trim()) & " " &
                                     IIf(ChkBolo.Checked, " Bolo ", "") & "" &
                                     IIf(ChkBolo.Checked, IIf(Not txtPasarEn.Visible, "", "PASAR EN: " & txtPasarEn.Text.Trim() & " MINUTOS"), "") & "" &
                                     IIf(Not txtDurante24.Visible, "", " DURANTE: " & txtDurante24.Text.Trim() & " HORAS") &
                                     IIf(Not txtNumRescates.Visible, "", " Número de Rescates: " & txtNumRescates.Text.Trim()) & " " &
                                     IIf(Not txtNumDosis.Visible, "", "Número de Dosis: " & txtNumDosis.Text.Trim())
                Dim existe As Boolean = validarExistenciaOrdenMedica(tabla, i)
                If (existe) Then
                    MsgBox("El medicamento ya cuenta con  una prescripción", MsgBoxStyle.Information, "Conciliaciòn de medicamentos")

                    flaglimpiacampos = False
                    ActualizaModificadosSuspendidos = True
                    Exit For
                End If


                Dim producto As String = ((tabla.Rows(i))).ItemArray(14)
                'ajuste realizado por Ricardo Zaldua validacion datos scring en la igualdad
                Dim fila As DataRow() = tabla.Select("producto LIKE '" & producto.Trim().ToUpper() &
                                             "%' AND UniMedDosis =" & txtDescripcionUM.SelectedValue &
                                             " AND ViaAdministra = '" & txtDescripcionVA.SelectedValue &
                                             "'" & " AND Frecuencia =" & txtDescripcionFreq.SelectedValue &
        IIf(txtPasarEn.Text <> "", " AND OMPasarEn =" & txtPasarEn.Text.Trim(), " AND OMPasarEn = OMPasarEn ") &
        IIf(txtDurante24.Text <> "", " AND OMDurante ='" & txtDurante24.Text.Trim() & "'", "AND OMDurante = OMDurante ") &
        IIf(txtDiasTrat.Text <> "", " AND Diastrat =" & txtDiasTrat.Text.Trim(), " AND Diastrat = Diastrat ") &
        IIf(txtNumDosis.Text <> "", " AND OMNumDosis =" & txtNumDosis.Text.Trim(), " AND OMNumDosis = OMNumDosis ") &
        IIf(txtDosis.Text <> "", " AND Dosis ='" & txtDosis.Text.Trim() & "'", " AND Dosis = Dosis ") &
        IIf(txtNumRescates.Text <> "", " AND OMRescates ='" & txtNumRescates.Text.Trim() & "'", "AND OMRescates = OMRescates ") &
        IIf(txtorigengrilla.Text <> "", "AND origen = 'OrdenMed'", "AND origen = origen"))

                Dim fila2 As DataRow() = tabla2.Select("producto LIKE '" & producto.Trim().ToUpper() &
                                             "%' AND UniMedDosis =" & txtDescripcionUM.SelectedValue &
                                             " AND ViaAdministra = '" & txtDescripcionVA.SelectedValue &
                                             "'" & " AND Frecuencia =" & txtDescripcionFreq.SelectedValue &
        IIf(txtPasarEn.Text <> "", " AND OMPasarEn =" & txtPasarEn.Text.Trim(), " AND OMPasarEn = OMPasarEn ") &
        IIf(txtDurante24.Text <> "", " AND OMDurante ='" & txtDurante24.Text.Trim() & "'", "AND OMDurante = OMDurante ") &
        IIf(txtDiasTrat.Text <> "", " AND Diastrat =" & txtDiasTrat.Text.Trim(), " AND Diastrat = Diastrat ") &
        IIf(txtNumDosis.Text <> "", " AND OMNumDosis =" & txtNumDosis.Text.Trim(), " AND OMNumDosis = OMNumDosis ") &
        IIf(txtDosis.Text <> "", " AND Dosis ='" & txtDosis.Text.Trim() & "'", " AND Dosis = Dosis ") &
        IIf(txtNumRescates.Text <> "", " AND OMRescates ='" & txtNumRescates.Text.Trim() & "'", "AND OMRescates = OMRescates "))



                ''Dim producto As String = ((tabla.Rows(i))).ItemArray(1)

                If fila2.Length > 0 Then
                    MsgBox("El medicamento ya cuenta con  una prescripción", MsgBoxStyle.Information, "Conciliaciòn de medicamentos")

                    Me.cmbDescripMedica.Focus()
                    flaglimpiacampos = False
                    ActualizaModificadosSuspendidos = True
                    Exit For
                End If


                ' FIN ER_OSI 584 eloaiza@intergrupo.com - Validar pre-existencia de medicamento y formulación

                If MsgBox("¿Está seguro de ingresar esta formulaciòn?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    falg_modificar = 0
                    If dtMedica.Rows(i).Item("MedControl") = "S" Then
                        'If MsgBox("¿Desea imprimir la fórmula de control?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        '    txtCantidadC.Text = Val(txtCantidadC.Text)
                        '    txtCantidadLetras.Text = txtCantidadLetras.Text
                        '    GroupCnt24.Enabled = True
                        ActualizaModificadosSuspendidos = True
                        '    Exit Function
                        'Else
                        txtCantidadC.Text = Val(txtCantidadC.Text)
                        txtCantidadLetras.Text = txtCantidadLetras.Text
                        GroupCnt24.Enabled = False
                        'End If

                    End If
                    intIndice = i
                    dtMedica.Rows(i).Item("estado") = BLOrdenes.INACTIVO
                    dtMedica.Rows(i).Item("Tratamiento") = BLOrdenes.SUSPENDE
                    dtMedica.Rows(i).Item("obs") = "N"

                    drFila = dtMedica.NewRow()

                    'dtMedica.Rows(i).Item("Dosis") = CDbl(txtDosis.Text)
                    'dtMedica.Rows(i).Item("UniMedDosis") = cmbUnidadMedida.SelectedValue.ToString
                    'dtMedica.Rows(i).Item("ViaAdministra") = cmbViaAdmin.SelectedValue.ToString

                    'If 'txtCodigoFreq.Text = "" Then
                    '    dtcmbFRE = txtDescripcionFreq.OrigenDeDatos
                    '    rows = dtcmbFRE.Select("descripcion='" & txtDescripcionFreq.Text & "'")
                    '    'txtCodigoFreq.Text = rows(0).Item("frecuencia").ToString

                    'End If

                    'BLOrdenes.actualizarEstado(dtMedica.Rows(i), BLOrdenes.CONTINUA, dtgMedicamentos.CurrentCell.Value)

                    'dtMedica.Rows(i).Item("Frecuencia") = 'txtCodigoFreq.Text
                    'dtMedica.Rows(i).Item("TecnicaAdministra") = txtTecnica.Text
                    'dtMedica.Rows(i).Item("UnicaDosis") = IIf(chkUnicaDosis.Checked, BLOrdenes.UNICADOSIS, BLOrdenes.VARIASDOSIS)
                    'dtMedica.Rows(i).Item("prescripcion") = txtDosis.Text & "  " & cmbUnidadMedida.Text & "  " & Me.cmbViaAdmin.Text & "  " & _
                    '                     IIf(chkUnicaDosis.Checked, "UNICA DOSIS", txtDescripcionFreq.Text) & "  " & txtTecnica.Text
                    'dtMedica.Rows(i).Item("obs") = ""
                    'If Me.chkUnicaDosis.Checked = True Then
                    '    dtMedica.Rows(i).Item("Tratamiento") = Nothing
                    '    dtMedica.Rows(i).Item("estado") = BLOrdenes.INACTIVO
                    'Else
                    '    dtMedica.Rows(i).Item("Tratamiento") = BLOrdenes.CONTINUA
                    '    dtMedica.Rows(i).Item("estado") = BLOrdenes.ACTIVO
                    'End If
                    ' ''  dtMedica.Rows(i).Item("descripcion") = dtProductoElegido.Item("descProducto").ToString 'cmbDescripMedica.Text

                    'LLENADO DE LOS DATOS
                    drFila("descripcion") = dtMedica.Rows(i).Item("descripcion")
                    drFila("NombreMedico") = datosLogin.NombreMedico
                    drFila("Especialidad") = datosLogin.DescripcionEspecialidad
                    drFila("cod_pre_sgs") = datosLogin.Prestador
                    drFila("cod_sucur") = datosLogin.Sucursal
                    drFila("tip_admision") = datosPaciente.TipoAdmision
                    drFila("ano_adm") = datosPaciente.AnoAdmision
                    drFila("num_adm") = datosPaciente.NumeroAdmision
                    drFila("NroOrden") = 0
                    drFila("producto") = dtMedica.Rows(i).Item("producto")
                    drFila("FormaFarma") = dtMedica.Rows(i).Item("FormaFarma")
                    drFila("Presentacion") = dtMedica.Rows(i).Item("Presentacion")
                    drFila("Contenido") = dtMedica.Rows(i).Item("Contenido")
                    '   drFila("Concentracion") = IIf(txtCodigoUM.Text = "", DBNull.Value, txtCodigoUM.Text) 'cmbUnidadMedida.SelectedValue  'dtProductoElegido.Item("Concentracion").ToString
                    drFila("Concentracion") = IIf(Me.txtDescripcionUM.SelectedValue = "", DBNull.Value, Me.txtDescripcionUM.SelectedValue)
                    drFila("Dosis") = CDbl(txtDosis.Text)
                    '   drFila("UniMedDosis") = IIf(txtCodigoUM.Text = "", DBNull.Value, txtCodigoUM.Text)
                    drFila("UniMedDosis") = IIf(Me.txtDescripcionUM.SelectedValue = "", DBNull.Value, Me.txtDescripcionUM.SelectedValue)
                    drFila("ViaAdministra") = IIf(Me.txtDescripcionVA.SelectedValue = "", DBNull.Value, Me.txtDescripcionVA.SelectedValue) 'txtDescripcionVA.Text 'txtDescripcionVA.Text 'cmbViaAdmin.SelectedValue.ToString
                    drFila("cantidadcontrol") = Val(txtCantidadC.Text)
                    drFila("cantidadletrascontrol") = txtCantidadLetras.Text
                    drFila("MedControl") = dtMedica.Rows(i).Item("MedControl")

                    If Me.txtDescripcionFreq.SelectedValue = "" Then
                        '                        dtcmbFRE = txtDescripcionFreq.OrigenDeDatos
                        dtcmbFRE = txtDescripcionFreq.DataSource
                        rows = dtcmbFRE.Select("descripcion='" & txtDescripcionFreq.Text & "'")
                        Me.txtDescripcionFreq.SelectedValue = rows(0).Item("frecuencia").ToString

                    End If

                    drFila("Frecuencia") = IIf(Me.txtDescripcionFreq.SelectedValue = "", DBNull.Value, Me.txtDescripcionFreq.SelectedValue)
                    'BLOrdenes.actualizarEstado(dtMedica.Rows(i), BLOrdenes.CONTINUA, dtgMedicamentos.CurrentCell.Value)

                    drFila("TecnicaAdministra") = txtTecnica.Text
                    drFila("UnicaDosis") = IIf(chkUnicaDosis.Checked, BLOrdenes.UNICADOSIS, BLOrdenes.VARIASDOSIS)
                    ''martovar 2018-05-25 Se envia la orden y la secuencia en el campo de la oden medica origen 
                    drFila("obs") = dtMedica.Rows(i).Item("Nroorden").ToString + "|" + dtMedica.Rows(i).Item("secuencia").ToString


                    If Me.chkUnicaDosis.Checked = True Then
                        drFila("Tratamiento") = Nothing
                        drFila("estado") = BLOrdenes.INACTIVO
                    Else
                        drFila("Tratamiento") = Nothing
                        drFila("estado") = BLOrdenes.ACTIVO
                    End If
                    drFila("medico") = datosLogin.Login
                    drFila("Login") = datosLogin.Login
                    drFila("prescripcion") = txtDosis.Text & " " & txtDescripcionUM.Text.Trim() & " " & Me.txtDescripcionVA.Text.Trim() & " " &
                                             IIf(chkUnicaDosis.Checked, "UNICA DOSIS", txtDescripcionFreq.Text.Trim()) & " " &
                                             IIf(Not txtNumRescates.Visible, "", " Rescates: " & txtNumRescates.Text.Trim()) & " " &
                                             IIf(Not txtNumDosis.Visible, "", " Número de Dosis: " & txtNumDosis.Text.Trim()) & "" &
                                             IIf(Not txtPasarEn.Visible, "", " Pasar en: " & txtPasarEn.Text.Trim()) & " " &
                                              IIf(Not txtDurante24.Visible, "", " Durante: " & txtDurante24.Text.Trim()) & " " & txtTecnica.Text.Trim()
                    ' ER_OSI 584 se cambia por la nueva concatenación
                    'txtDosis.Text & "  " & txtDescripcionUM.Text & "  " & Me.txtDescripcionVA.Text & "  " &
                    '                            IIf(chkUnicaDosis.Checked, "UNICA DOSIS", txtDescripcionFreq.Text) & "  " & txtTecnica.Text
                    If Me.txtDiasTrat.Text = "" Then
                        drFila("diastrat") = 0
                    Else
                        drFila("diastrat") = Me.txtDiasTrat.Text
                    End If

                    drFila("CodSISPRO") = dtMedica.Rows(i).Item("CodSISPRO")
                    Dim pide_SISPRO As String = ""
                    Dim strGenCTC_MP As String = "N"
                    Dim daoGeneral As New DAOGeneral

                    pide_SISPRO = daoGeneral.EjecutarSQLStrValor("gensucur (nolock)", datosConexion, " pide_SISPRO", " cod_sucur='" & datosLogin.Sucursal & "'")
                    drFila("DesSISPRO") = dtMedica.Rows(i).Item("DesSISPRO")

                    strGenCTC_MP = BLOrdenes.PideCTCMP(datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.TipoAdmision,
                            datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision, txtCodMedica.Text)


                    If (datosPaciente.TipoEntidad = "EPS" Or strGenCTC_MP = "S") And pide_SISPRO = "S" Then 'Not IsDBNull(dtMedica.Rows(i).Item("CodSISPRO"))

                        If Len(dtMedica.Rows(i).Item("autoSISPRO")) > 0 Then

                            Dim pag_SISPRO As String

                            ''pide_SISPRO = DAOGeneral.EjecutarSQLStrValor("gensucur (nolock)", datosConexion, " pide_SISPRO", " cod_sucur='" & datosLogin.Sucursal & "'")
                            pag_SISPRO = daoGeneral.EjecutarSQLStrValor("pargener (nolock)", datosConexion, " pagsispro", " cod_pre_sgs='" & datosLogin.Prestador & "'")

                            If Me.txtDiasTrat.Text = "" And txtDiasTrat.Visible Then
                                MsgBox("debe digitar los dias de tratamiento", MsgBoxStyle.Information, "Conciliaciòn de medicamentos")
                                Me.txtDiasTrat.Focus()
                                dtMedica.Rows(i).Item("obs") = "M"
                                ActualizaModificadosSuspendidos = True
                                Exit Function
                            End If

                            flag_posCondicionado = BLOrdenes.existePosCondicionado(datosConexion, datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.TipoAdmision, datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision, "M", dtMedica.Rows(i).Item("producto"))
                            If flag_posCondicionado = True Then
                                cod_Sispro = "POS Condicionado"
                                MsgBox("El elemento prescrito es POS Condicionado por Diagnóstico", MsgBoxStyle.Information, "Procedimientos")
                            Else
                                System.Diagnostics.Process.Start(pag_SISPRO)
                                frm_SISPRO.Text = "Registro Radicado MIPRES"
                                frm_SISPRO.Mostrar(cod_Sispro)
                                cod_Sispro = frm_SISPRO.Cod_SISPRO1
                            End If
                        Else
                            cod_Sispro = ""
                        End If
                    End If
                    drFila("autoSISPRO") = cod_Sispro

                    ''' 10/2019
                    ''' Req. ER_OSI_584 Prescripcion_de_medicamentos
                    drFila("viaBolo") = ChkBolo.Checked.ToString()
                    drFila("OMDurante") = IIf(String.IsNullOrEmpty(txtDurante24.Text.Trim()), "0", txtDurante24.Text.Trim())
                    drFila("OMPasarEn") = IIf(String.IsNullOrEmpty(txtPasarEn.Text.Trim()), "0", txtPasarEn.Text.Trim())
                    drFila("OMRescates") = IIf(String.IsNullOrEmpty(txtNumRescates.Text.Trim()), "0", txtNumRescates.Text.Trim())
                    drFila("OMNumDosis") = IIf(String.IsNullOrEmpty(txtNumDosis.Text.Trim()), "0", txtNumDosis.Text.Trim())
                    drFila("idRegistro") = ""
                    'CU03 Hrariza@
                    'Inicio
                    drFila("conciliado") = "S" '--- validar que el nuevo pase por aqui
                    drFila("origen") = "NordenMed"
                    'Fin
                    'ADICIONA LA NUEVA FILA A LA TABLA
                    dtMedica.Rows.Add(drFila)
                    'ADICIONA A LA TABLA DEL PAGINADOR CLAUDIA GARAY NOVIEMBRE DE 2010
                    'dtSource.Rows.Add(drFila)
                    'ENLAZA LA TABLA Y EL DATAGRID

                    dgtMedicaConcilSus.DataSource = dtMedica

                    LimpiarPanel(Panel1, Nothing)
                    txtCantidadC.Text = String.Empty
                    txtCantidadLetras.Text = String.Empty
                    GroupCnt24.Enabled = False
                    'LIMPIA EL DATASOURCE DEL COMBO DE BUSQUEDA
                    cmbDescripMedica.OrigenDeDatos.Rows.Clear()
                    'txtCodMedica.Focus()
                    Me.datosSinAlmacenar = True

                    dtMedica.Rows(i).Item("estado") = BLOrdenes.INACTIVO
                    dtMedica.Rows(i).Item("Tratamiento") = BLOrdenes.SUSPENDE
                    ActualizaModificadosSuspendidos = True
                    ' txtCodMedica.Enabled = True
                    cmbDescripMedica.Enabled = True

                    ' Se inactiva la fila modificada
                    'DirectCast(datagridgenerico.Rows(intIndice).Cells("continuar_med"), DataGridViewCheckBoxCell).Value = valoresContinuar(1)
                    DirectCast(dgtMedicaConcilSus.Rows(intIndice).Cells("modificar_med2"), DataGridViewCheckBoxCell).Value = valoresModificar(0)


                    'DirectCast(datagridgenerico.Rows(intIndice).Cells("continuar_med"), DataGridViewCheckBoxCell).ReadOnly = True
                    DirectCast(dgtMedicaConcilSus.Rows(intIndice).Cells("modificar_med2"), DataGridViewCheckBoxCell).ReadOnly = True

                    ' Se inactiva la fila nueva
                    'DirectCast(datagridgenerico.Rows(datagridgenerico.RowCount - 1).Cells("continuar_med"), DataGridViewCheckBoxCell).ReadOnly = True
                    DirectCast(dgtMedicaConcilSus.Rows(dgtMedicaConcilSus.RowCount - 1).Cells("modificar_med2"), DataGridViewCheckBoxCell).ReadOnly = True

                Else
                    falg_modificar = 0
                    intIndice = i
                    'DirectCast(datagridgenerico.Rows(intIndice).Cells("continuar_med"), DataGridViewCheckBoxCell).Value = valoresContinuar(1)
                    DirectCast(dgtMedicaConcilSus.Rows(intIndice).Cells("modificar_med2"), DataGridViewCheckBoxCell).Value = valoresModificar(1)
                    ActualizaModificadosSuspendidos = True
                End If

            End If
        Next
    End Function



#End Region




#Region "medicamentos conciliados suspendidos"
    Private Sub CargargrillaMedicamentosConciliadosSuspendidos()

        datosSinAlmacenar = False

        If _MedicamentosConcilSus.Estado = "N" Then  ''No ha sido cargado el objeto, primera carga del control 
            Try
                _MedicamentosConcilSus.TablasOrdenes = BLConciliacionMedicamentos.consultarMedicamentosConciliadosSuspen(datosConexion, datosLogin.Prestador, datosLogin.Sucursal,
                                      datosPaciente.TipoAdmision, datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision)

                _MedicamentosConcilSus.TablasOrdenes.AcceptChanges()
                _MedicamentosConcilSus.Estado = "M"  ''Marca el objeto para decir que ya fue cargado o modificado
            Catch ex As Exception
                MsgBox("Error en la consulta de las dietas. " & ex.Message, MsgBoxStyle.Information)
                Exit Sub
            End Try
        End If


        ''Carga la grilla de Medicamentos 
        configurarGrillaMedicamentosConciliadosSuspendidos(_MedicamentosConcilSus.TablasOrdenes.Tables("MEDICAMENTOSSUS"))

    End Sub

    Public Sub configurarGrillaMedicamentosConciliadosSuspendidos(ByVal dtMedicamentos As DataTable)
        If intloadSus = 0 Then
            With dtMedicamentos
                .Columns.Add("cod_corto", System.Type.GetType("System.String"))
                .Columns.Add("concentracionEq", System.Type.GetType("System.String"))
                .Columns.Add("for_farma", System.Type.GetType("System.String"))
                .Columns.Add("diasTratamiento", System.Type.GetType("System.String"))
                .Columns.Add("DosisXDia", System.Type.GetType("System.String"))
                .Columns.Add("DosisXDiaNoPos", System.Type.GetType("System.String"))
                .Columns.Add("fec_desde", System.Type.GetType("System.String"))
                .Columns.Add("fec_hasta", System.Type.GetType("System.String"))
                .Columns.Add("diagnost", System.Type.GetType("System.String"))
                .Columns.Add("Justificacion", System.Type.GetType("System.String"))
                .Columns.Add("clasificacion", System.Type.GetType("System.String"))
                .Columns.Add("obsDiagn", System.Type.GetType("System.String"))
                ' .Columns.Add("viaBolo", System.Type.GetType("System.String"))
                ''' 10/2019 eloaiza@intergrupo.com
                ''' Req. ER_OSI_584 Prescripcion_de_medicamentos
                '.Columns.Add("OMDurante", System.Type.GetType("System.Decimal"))
                ' .Columns.Add("OMPasarEn", System.Type.GetType("System.Decimal"))
                '.Columns.Add("OMRescates", System.Type.GetType("System.Decimal"))
                '.Columns.Add("OMNumDosis", System.Type.GetType("System.Decimal"))
                .Columns.Add("idRegistro", System.Type.GetType("System.String"))
                .Columns.Add("tmp_suspender_med", System.Type.GetType("System.String"))
                .Columns.Add("tmp_modificar_med", System.Type.GetType("System.String"))
                .Columns.Add("flag_pos", System.Type.GetType("System.String"))



            End With
            intloadSus = 1
        End If

        dtMedicamentos.Rows.Add()

        With dgtMedicaConcilSus

            .DataSource = dtMedicamentos
            .Columns("cod_pre_sgs").Visible = False
            .Columns("cod_sucur").Visible = False
            .Columns("tip_admision").Visible = False
            .Columns("ano_adm").Visible = False
            .Columns("num_adm").Visible = False
            .Columns("NroOrden").Visible = False
            .Columns("producto").Visible = False
            .Columns("FormaFarma").Visible = False
            .Columns("Presentacion").Visible = False
            .Columns("Contenido").Visible = False
            .Columns("Concentracion").Visible = False
            .Columns("Dosis").Visible = False
            .Columns("UniMedDosis").Visible = False
            .Columns("ViaAdministra").Visible = False
            .Columns("Frecuencia").Visible = False
            .Columns("TecnicaAdministra").Visible = False
            .Columns("UnicaDosis").Visible = False
            .Columns("Tratamiento_med3").Visible = False
            .Columns("medico").Visible = False
            .Columns("estado").Visible = False
            .Columns("login").Visible = False
            .Columns("obs").Visible = False
            .Columns("Secuencia").Visible = False
            .Columns("cantidadcontrol").Visible = False ''cpgaray   
            .Columns("cantidadletrascontrol").Visible = False ''cpgaray
            '.Columns("descrProducto").Width = 300 ''Claudia Garay Enero 17 de 2011
            '.Sort(.Columns("fec_con_med"), System.ComponentModel.ListSortDirection.Descending)
            ''Ctc
            '.Columns("obs_med").Width = 260
            '.Columns("cod_corto").Visible = False
            .Columns("concentracion").Visible = False
            .Columns("for_farma").Visible = False
            .Columns("diasTratamiento").Visible = False
            .Columns("diasTrat1").Visible = False
            .Columns("DosisXDia").Visible = False
            .Columns("fec_desde").Visible = False
            .Columns("fec_hasta").Visible = False
            .Columns("diagnost").Visible = False
            .Columns("clasificacion").Visible = False
            .Columns("obsDiagn").Visible = False
            .Columns("concentracionEq").Visible = False
            .Columns("DosisXDiaNoPos").Visible = False
            .Columns("Justificacion").Visible = False
            '.Columns("autoSISPRO").Width = 140
            '.Columns("fecfintra").Width = 100
            ''' 10/2019
            ''' Req. ER_OSI_584 Prescripcion_de_medicamentos
            .Columns("viaBolo").Visible = False
            .Columns("OMDurante").Visible = False
            .Columns("OMPasarEn").Visible = False
            .Columns("OMRescates").Visible = False
            .Columns("OMNumDosis").Visible = False
            .Columns("idRegistro").Visible = False
            .Columns("tmp_suspender_med").Visible = False
            .Columns("tmp_modificar_med").Visible = False
            .Columns("conciliado").Visible = False
            .Columns("cod_corto").Visible = False

            .Columns("origen").Visible = False
            .Columns("flag_pos").Visible = False

        End With

        dtMedicamentos.Rows.RemoveAt(dtMedicamentos.Rows.Count - 1)
        ''PaginarGrillaMed()
    End Sub




    Private Sub ActualizarEstadoNuevoSus(ByRef e As Integer, ByVal tratamiento As String, ByVal flag_sispro As String, datagridgenerico As DataGridView)





        Dim chkModificar As DataGridViewCheckBoxCell = DirectCast(dgtMedicaConcilSus.Rows(e).Cells("modificar_med2"), DataGridViewCheckBoxCell)

        Dim Fila As DataGridViewRow = DirectCast(datagridgenerico.Rows(e), DataGridViewRow)

        'Asegurar cual opción se selecciono
        'Dim refSel As Boolean = (Fila.Cells("continuar_med")).Selected
        Dim modSel As Boolean = (Fila.Cells("modificar_med2")).Selected

        If dgtMedicaConcilSus.CurrentCell.ColumnIndex = dgtMedicaConcilSus.Columns("modificar_med2").Index Then '' COLUMNA SUSPENDER
            ComportamientoModificarSus(e, String.Empty, flag_sispro, dgtMedicaConcilSus)
        End If


        'If dgtMedicaConcilSus.CurrentCell.ColumnIndex = dgtMedicaConcilOtros.Columns("suspender_med2").Index Then '' COLUMNA SUSPENDER           
        '    ComportamientoSuspenderOtros(e, String.Empty, flag_sispro, dgtMedicaConcilSus)
        'End If



        Exit Sub
        Select Case True

            Case modSel
                ComportamientoModificarSus(e, BLOrdenes.MODIFICA, flag_sispro, dgtMedicaConcilSus)
                Fila.Cells("modificar_med2").Value = True
                Fila.Cells("modificar_med2").Selected = True
                'Fila.Cells("suspender_med2").Value = True
                Fila.Cells("continuar_med2").Value = False




        End Select

        datagridgenerico.EndEdit()

    End Sub


    Private Sub ComportamientoModificarSus(ByVal IndiceFilaSeleccionada As Integer, ByVal tratamiento As String, ByVal flag_sispro As String, datagridgenerico As DataGridView)
#Region "Modificar"

        Dim dtDatos As DataTable = dgtMedicaConcilSus.DataSource
        Dim chkContinuar As DataGridViewCheckBoxCell = DirectCast(dgtMedicaConcilSus.Rows(IndiceFilaSeleccionada).Cells("modificar_med2"), DataGridViewCheckBoxCell)

        'Dim chkSuspender As DataGridViewCheckBoxCell = DirectCast(dgtMedicaConcilSus.Rows(IndiceFilaSeleccionada).Cells("suspender_med1"), DataGridViewCheckBoxCell)








        If dgtMedicaConcilSus.CurrentCell.ReadOnly = True Then 'Desmarcar el check de reformular
            txtTecnica.Text = ""
            If dgtMedicaConcilSus.Rows(IndiceFilaSeleccionada).Cells("Frecuencia").Value = "47" Then
                MsgBox("Debe generar una nueva orden para este medicamento", MsgBoxStyle.Information)
                dgtMedicaConcilSus.Rows(IndiceFilaSeleccionada).Cells("continuar_med2").Value = False 'le quito el check
                dgtMedicaConcilSus.Update()
                dgtMedicaConcilSus.RefreshEdit()
            End If
            Exit Sub
        End If


        If dtDatos.Rows(IndiceFilaSeleccionada)("Frecuencia") = "47" Then
            MsgBox("Debe generar una nueva orden para este medicamento", MsgBoxStyle.Information)
            txtCodMedica.Text = String.Empty
            ' txtCodMedica.Enabled = True
            cmbDescripMedica.Text = String.Empty
            cmbDescripMedica.Enabled = True
            txtDosis.Text = String.Empty
            txtDescripcionUM.Text = String.Empty
            txtDescripcionUM.SelectedValue = String.Empty
            txtDescripcionVA.Text = String.Empty
            txtDescripcionVA.SelectedValue = String.Empty
            txtDescripcionFreq.Text = String.Empty
            txtDescripcionFreq.SelectedValue = String.Empty
            txtorigengrilla.Text = String.Empty
            'datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = chkSuspender.TrueValue
            dgtMedicaConcilOtros.CurrentCell.Value = chkContinuar.FalseValue
            'dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_suspender_med") = chkSuspender.TrueValue
            dtDatos.Rows(IndiceFilaSeleccionada).Item("tratamiento") = chkContinuar.FalseValue
            'dtDatos.AcceptChanges()
            'datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = chkSuspender.TrueValue
            dgtMedicaConcilSus.Rows(IndiceFilaSeleccionada).Cells("continuar_med2").Value = chkContinuar.FalseValue
            dgtMedicaConcilSus.Update()
            dgtMedicaConcilSus.RefreshEdit()
            Exit Sub
        End If

        valorModificar = dgtMedicaConcilSus.CurrentCell.Value
        For i As Integer = 0 To dtDatos.Rows.Count - 1
            If dtDatos.Rows(i).Item("obs") = "M" Then
                dtDatos.Rows(i).Item("obs") = "N" 'MARTOVAR CONTROL DE LIQUIDOS 2018/05/31

            End If
        Next



        If Not IsDBNull(dgtMedicaConcilSus.CurrentCell.Value) Then
            If dgtMedicaConcilSus.CurrentCell.Value = "M" And IsDBNull(dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_modificar_med")) Then
                dgtMedicaConcilSus.CurrentCell.Value = "M"
                dtDatos.Rows(IndiceFilaSeleccionada).Item("obs") = "M"
                ''dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_suspender_med") = "S"
                'datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = chkSuspender.TrueValue



                dgtMedicaConcilSus.Rows(IndiceFilaSeleccionada).Cells("modificar_med2").Selected = False
                dgtMedicaConcilSus.Rows(IndiceFilaSeleccionada).Cells("modificar_med2").Value = chkContinuar.FalseValue
            ElseIf dgtMedicaConcilSus.CurrentCell.Value = "N" And (dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_modificar_med").ToString() = "N" And String.IsNullOrEmpty(dtDatos.Rows(IndiceFilaSeleccionada).Item("obs").ToString())) Then
                dgtMedicaConcilSus.CurrentCell.Value = "M"
                dtDatos.Rows(IndiceFilaSeleccionada).Item("obs") = "M"
                'dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_suspender_med") = "S"
                'datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = "S"
                dgtMedicaConcilSus.Rows(IndiceFilaSeleccionada).Cells("modificar_med2").Selected = False
                dgtMedicaConcilSus.Rows(IndiceFilaSeleccionada).Cells("modificar_med2").Value = "N"
            ElseIf dgtMedicaConcilSus.CurrentCell.Value = "M" And dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_modificar_med").ToString() = "N" Then

                dgtMedicaConcilSus.CurrentCell.Value = "M"

                dtDatos.Rows(IndiceFilaSeleccionada).Item("obs") = "M"
                'dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_suspender_med") = chkSuspender.TrueValue
                'dgtMedicaConcilSus.Rows(IndiceFilaSeleccionada).Cells("suspender_med2").Value = "C"
                dgtMedicaConcilSus.Rows(IndiceFilaSeleccionada).Cells("modificar_med2").Selected = False
                dgtMedicaConcilSus.Rows(IndiceFilaSeleccionada).Cells("modificar_med2").Value = "N"
                dgtMedicaConcilSus.Rows(IndiceFilaSeleccionada).Cells("motivosus2").Value = String.Empty
            ElseIf dgtMedicaConcilSus.CurrentCell.Value = "M" And dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_modificar_med").ToString() = "M" Then

                'dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_suspender_med") = chkSuspender.FalseValue
                'datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = chkSuspender.FalseValue
                dtDatos.Rows(IndiceFilaSeleccionada).Item("obs") = ""
            ElseIf dgtMedicaConcilSus.CurrentCell.Value = "N" And dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_modificar_med").ToString() = "M" Then
                dgtMedicaConcilSus.CurrentCell.Value = "N"
                dtDatos.Rows(IndiceFilaSeleccionada).Item("obs") = ""
                'dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_suspender_med") = "C"
                'datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = chkSuspender.FalseValue
                dgtMedicaConcilSus.Rows(IndiceFilaSeleccionada).Cells("modificar_med2").Selected = False
                dgtMedicaConcilSus.Rows(IndiceFilaSeleccionada).Cells("modificar_med2").Value = "N"
            ElseIf datagridgenerico.CurrentCell.Value = "N" And dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_modificar_med").ToString() = "N" And
                   dtDatos.Rows(IndiceFilaSeleccionada).Item("obs").ToString() = "N" Then

                'dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_suspender_med") = chkSuspender.FalseValue
                'dgtMedicaConcilSus.Rows(IndiceFilaSeleccionada).Cells("suspender_med2").Value = chkSuspender.FalseValue
                dgtMedicaConcilSus.Rows(IndiceFilaSeleccionada).Cells("motivosus2").Value = String.Empty
                dtDatos.Rows(IndiceFilaSeleccionada).Item("obs") = ""
            Else
                dgtMedicaConcilSus.CurrentCell.Value = "M"
                dtDatos.Rows(IndiceFilaSeleccionada).Item("obs") = "M"
                dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_modificar_med") = dgtMedicaConcilSus.CurrentCell.Value
                ''dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_suspender_med") = "S"
                'DirectCast(datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("suspender_med"), DataGridViewCheckBoxCell).ReadOnly = True
                'datagridgenerico.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = "S"
                'chkSuspender.ReadOnly = True
                dgtMedicaConcilSus.Rows(IndiceFilaSeleccionada).Cells("modificar_med2").Value = "N"

                'dtDatos.Rows(e.RowIndex).Item("obs") = ""
            End If
            dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_modificar_med") = dgtMedicaConcilSus.CurrentCell.Value
        End If
        dtDatos.Rows(IndiceFilaSeleccionada).AcceptChanges()
        dtDatos.Rows(IndiceFilaSeleccionada).SetModified()

        BLOrdenes.actualizarEstado(dtDatos.Rows(IndiceFilaSeleccionada), BLOrdenes.CONTINUA, dgtMedicaConcilSus.CurrentCell.Value, flag_sispro)
        'BLOrdenes.actualizarEstado(dtDatos.Rows(e.RowIndex), BLOrdenes.MODIFICA, dtgMedicamentos.CurrentCell.Value)
        If dtDatos.Rows(IndiceFilaSeleccionada).Item("obs") = "M" Then



            MostrarInforMed(IndiceFilaSeleccionada, dgtMedicaConcilSus, "GSuspendidos")
            falg_modificar = 1
        Else
            txtCodMedica.Text = String.Empty
            ' txtCodMedica.Enabled = True
            cmbDescripMedica.Text = String.Empty
            cmbDescripMedica.Enabled = True
            txtDosis.Text = String.Empty
            txtDescripcionUM.Text = String.Empty
            txtDescripcionUM.SelectedValue = String.Empty
            txtDescripcionVA.Text = String.Empty
            txtDescripcionVA.SelectedValue = String.Empty
            txtDescripcionFreq.Text = String.Empty
            txtDescripcionFreq.SelectedValue = String.Empty
            Me.txtDiasTrat.Text = String.Empty
            Me.txtDiasTrat.Visible = False
            Me.lblDiasTrat.Visible = False
            falg_modificar = 0
            txtTecnica.Text = String.Empty
            txtorigengrilla.Text = String.Empty
        End If
        dgtMedicaConcilSus.CurrentCell.Value = valorModificar
        dgtMedicaConcilSus.RefreshEdit()
        Me.datosSinAlmacenar = True
#End Region
    End Sub

    Private Sub dgtMedicaConcilSus_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgtMedicaConcilSus.CellContentClick



        If e.RowIndex = -1 Then

            Return
        End If







        If dgtMedicaConcilSus.Rows(e.RowIndex).Cells("modificar_med2").ReadOnly = True Then
            Return
        End If



        Dim fecha_1 As Date
        Dim fecha_2 As Date
        Dim dias As Integer
        Dim FlagSispro As String
        Dim dtcmbFRE As New DataTable

        Dim dtDatos As DataTable = dgtMedicaConcilSus.DataSource

        dias = 0

        If dtDatos.Rows(e.RowIndex).Item("diastrat") > 0 Then
            fecha_1 = Format(Now.Date, "yyyy-MM-dd")
            If (dtDatos.Rows(e.RowIndex).Item("fecfintra")) Is DBNull.Value Then
                fecha_2 = Format(DateAdd(DateInterval.Day, dtDatos.Rows(e.RowIndex).Item("diastrat"), Now.Date), "yyyy-MM-dd")
                dtDatos.Rows(e.RowIndex).Item("fecfintra") = Format(fecha_2, "yyyy-MM-dd")
            End If
            fecha_2 = Format(dtDatos.Rows(e.RowIndex).Item("fecfintra"), "yyyy-MM-dd")
            'dias = DateDiff("d", Format(fecha_2, "yyyy-MM-dd"), Format(fecha_1, "yyyy-MM-dd")) + 1
            If Format(Now.Date, "yyyy-MM-dd") > Format(dtDatos.Rows(e.RowIndex).Item("fecfintra"), "yyyy-MM-dd") Then
                FlagSispro = "S"
            Else
                FlagSispro = "N"
            End If
        Else
            FlagSispro = "N"
        End If


        If falg_modificar = 0 Then
            ActualizarEstadoNuevoSus(e.RowIndex, String.Empty, FlagSispro, dgtMedicaConcilSus)
        Else

            'dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = chkSuspender.FalseValue
            'Dim chkSuspender As DataGridViewCheckBoxCell = DirectCast(dgtMedicaConcilSus.Rows(e.RowIndex).Cells("suspender_med2"), DataGridViewCheckBoxCell)
            Dim chkContinuar As DataGridViewCheckBoxCell = DirectCast(dgtMedicaConcilSus.Rows(e.RowIndex).Cells("modificar_med2"), DataGridViewCheckBoxCell)

            ' Valores que reprsentan la marcacion en las casillas (Verdadero, Falso)
            'Dim valoresContinuar As String() = {"C", "S"}
            'Dim valoresModificar As String() = {"M", "N"}
            'Dim valoresSuspender As String() = {"S", "C"}

            If dgtMedicaConcilSus.CurrentCell.ReadOnly = True Then 'Desmarcar el check de reformular
                Exit Sub
            End If

            'If datagridgenerico.CurrentCell.Value = "C" Then
            '    datagridgenerico.CurrentCell.Value = "S"
            '    txtCodMedica.Text = String.Empty
            '    ' txtCodMedica.Enabled = True
            '    cmbDescripMedica.Text = String.Empty
            '    cmbDescripMedica.Enabled = True
            '    txtDosis.Text = String.Empty
            '    txtDescripcionUM.Text = String.Empty
            '    txtDescripcionUM.SelectedValue = String.Empty
            '    txtDescripcionVA.Text = String.Empty
            '    txtDescripcionVA.SelectedValue = String.Empty
            '    txtDescripcionFreq.Text = String.Empty
            '    txtDescripcionFreq.SelectedValue = String.Empty
            '    Me.txtDiasTrat.Text = String.Empty
            '    Me.txtDiasTrat.Visible = False
            '    Me.lblDiasTrat.Visible = False
            '    falg_modificar = 0
            '    txtTecnica.Text = String.Empty
            'Else
            '    If datagridgenerico.CurrentCell.Value = "S" Then
            '        txtCodMedica.Text = String.Empty
            '        ' txtCodMedica.Enabled = True
            '        cmbDescripMedica.Text = String.Empty
            '        cmbDescripMedica.Enabled = True
            '        txtDosis.Text = String.Empty
            '        txtDescripcionUM.Text = String.Empty
            '        txtDescripcionUM.SelectedValue = String.Empty
            '        txtDescripcionVA.Text = String.Empty
            '        txtDescripcionVA.SelectedValue = String.Empty
            '        txtDescripcionFreq.Text = String.Empty
            '        txtDescripcionFreq.SelectedValue = String.Empty
            '        Me.txtDiasTrat.Text = String.Empty
            '        Me.txtDiasTrat.Visible = False
            '        Me.lblDiasTrat.Visible = False
            '        falg_modificar = 0
            '        txtTecnica.Text = String.Empty
            '        datagridgenerico.Rows(e.RowIndex).Cells("modificar_med").Value = chkContinuar.FalseValue

            '        Dim myForm As New frm_Justificacion
            '        myForm.ShowDialog()
            '        If myForm.descmotivoSuspension <> Nothing Then
            '            datagridgenerico.Rows(e.RowIndex).Cells("motivosus").Value = myForm.descmotivoSuspension + "/" + datosLogin.NombreMedico

            '        Else

            '            datagridgenerico.Rows(e.RowIndex).Cells("suspender_med").Value = chkSuspender.FalseValue
            '        End If



            '    Else
            '        If datagridgenerico.CurrentCell.Value = "N" Then
            '            Me.pnlDurante.Visible = False
            '            falg_modificar = 0
            '            ActualizarEstadoNuevo(e.RowIndex, String.Empty, FlagSispro)
            '            If GroupCnt24.Visible = True Then
            '                GroupCnt24.Visible = False
            '            End If
            '        Else
            '            'datagridgenerico.CurrentCell.Value = "N"
            '            'MessageBox.Show("Para poder realizar esta acción debe desmarcar el check box modificar.", "Ordenes Medicas", MessageBoxButtons.OK, MessageBoxIcon.Information)

            '            'datagridgenerico.Rows(e.RowIndex).Cells("suspender_med").Value = chkSuspender.FalseValue
            '        End If
            '    End If
            'End If
            '    datagridgenerico.RefreshEdit()
            '    'dtgMedicamentos.CurrentCell.Selected = True
            '    'dtgMedicamentos.EndEdit()
            'End If
            If dgtMedicaConcilSus.CurrentCell.Value = "C" Then
                dgtMedicaConcilSus.CurrentCell.Value = "S"
                MessageBox.Show("Para poder realizar esta acción debe desmarcar el check box Prescripción.", "Ordenes Medicas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                If dgtMedicaConcilSus.CurrentCell.Value = "S" Then
                    dgtMedicaConcilSus.CurrentCell.Value = "C"
                    MessageBox.Show("Para poder realizar esta acción debe desmarcar el check box Prescripción.", "Ordenes Medicas", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    If dgtMedicaConcilSus.CurrentCell.Value = "N" Then
                        Me.pnlDurante.Visible = False
                        falg_modificar = 0
                        ActualizarEstadoNuevoSus(e.RowIndex, String.Empty, FlagSispro, dgtMedicaConcilSus)
                        If GroupCnt24.Visible = True Then
                            GroupCnt24.Visible = False
                        End If
                    Else
                        dgtMedicaConcilSus.CurrentCell.Value = "N"
                        falg_modificar = 0
                        'MessageBox.Show("Para poder realizar esta acción debe desmarcar el check box Prescripción.", "Ordenes Medicas", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        dgtMedicaConcilSus.Rows(e.RowIndex).Cells("modificar_med2").Value = chkContinuar.FalseValue
                        'dgtMedicaConcilSus.Rows(e.RowIndex).Cells("suspender_med2").Value = chkSuspender.FalseValue
                    End If
                End If
            End If
            dgtMedicaConcilSus.RefreshEdit()
            'dtgMedicamentos.CurrentCell.Selected = True
            'dtgMedicamentos.EndEdit()
        End If
    End Sub

    Private Sub dgtMedicaConcilSus_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgtMedicaConcilSus.CurrentCellDirtyStateChanged
        If dgtMedicaConcilSus.IsCurrentCellDirty Then
            dgtMedicaConcilSus.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub
    Private Function CreateDataTablePaciente() As DataTable
        'Dim objPaciente As Object = Me.Parent.Parent.Controls("pnlContenedorDatosPaciente").Controls("ctlDatosPaciente")
        'Dim objPaciente As Paciente = Paciente.Instancia
        'Dim ctlPaciente As ctlDatosPaciente = CType(objPaciente, ctlDatosPaciente)

        Dim objDatosPaciente As Paciente = Paciente.Instancia

        Dim dtDatosPaciente As DataTable = New DataTable()
        dtDatosPaciente.Columns.Add("Admision", GetType(String))
        dtDatosPaciente.Columns.Add("AnoAdmision", GetType(String))
        dtDatosPaciente.Columns.Add("Cama", GetType(String))
        dtDatosPaciente.Columns.Add("Carnet", GetType(String))
        dtDatosPaciente.Columns.Add("Ciudad", GetType(String))
        dtDatosPaciente.Columns.Add("ClasificacionTriage", GetType(String))
        dtDatosPaciente.Columns.Add("CodHistoria", GetType(String))
        dtDatosPaciente.Columns.Add("CodigoOcupacionPaciente", GetType(String))
        dtDatosPaciente.Columns.Add("CodigoUnidadMedidaEdad", GetType(String))
        dtDatosPaciente.Columns.Add("Consultorio", GetType(String))
        dtDatosPaciente.Columns.Add("Cronico", GetType(String))
        dtDatosPaciente.Columns.Add("DescripcionEntidad", GetType(String))
        dtDatosPaciente.Columns.Add("DescripcionGenero", GetType(String))
        dtDatosPaciente.Columns.Add("DescripcionOcupacionPaciente", GetType(String))
        dtDatosPaciente.Columns.Add("DescripcionTipoDocumento", GetType(String))
        dtDatosPaciente.Columns.Add("DescripcionTipoHistoria", GetType(String))
        dtDatosPaciente.Columns.Add("DescripcionUnidadMedidaEdad", GetType(String))
        dtDatosPaciente.Columns.Add("DirSucursal", GetType(String))
        dtDatosPaciente.Columns.Add("Edad", GetType(String))
        dtDatosPaciente.Columns.Add("EdadAMD", GetType(String))
        dtDatosPaciente.Columns.Add("Entidad", GetType(String))
        dtDatosPaciente.Columns.Add("EstadoAdmision", GetType(String))
        dtDatosPaciente.Columns.Add("EstadoInicialHistoria", GetType(String))
        dtDatosPaciente.Columns.Add("EstadoInstancia", GetType(String))
        dtDatosPaciente.Columns.Add("FechaAtencionProcedimiento", GetType(String))
        dtDatosPaciente.Columns.Add("FechaCita", GetType(String))
        dtDatosPaciente.Columns.Add("FechaHistoriaClinica", GetType(String))
        dtDatosPaciente.Columns.Add("FechaHoraAdmision", GetType(String))
        dtDatosPaciente.Columns.Add("FechaIngresoAdmision", GetType(String))
        dtDatosPaciente.Columns.Add("FechaNacimiento", GetType(String))
        dtDatosPaciente.Columns.Add("Genero", GetType(String))
        dtDatosPaciente.Columns.Add("GrupoRH", GetType(String))
        dtDatosPaciente.Columns.Add("GrupoSanguineo", GetType(String))
        dtDatosPaciente.Columns.Add("HistoriaTieneEgreso", GetType(String))
        dtDatosPaciente.Columns.Add("HoraAtencionProcedimiento", GetType(String))
        dtDatosPaciente.Columns.Add("HoraCita", GetType(String))
        dtDatosPaciente.Columns.Add("HoraHistoriaClinica", GetType(String))
        dtDatosPaciente.Columns.Add("HoraIngresoAdmision", GetType(String))
        dtDatosPaciente.Columns.Add("IdentificadorCama", GetType(String))
        dtDatosPaciente.Columns.Add("ManejaConvenio", GetType(String))
        dtDatosPaciente.Columns.Add("MinutoAtencionProcedimiento", GetType(String))
        dtDatosPaciente.Columns.Add("MinutoCita", GetType(String))
        dtDatosPaciente.Columns.Add("MinutoHistoriaClinica", GetType(String))
        dtDatosPaciente.Columns.Add("MinutoIngresoAdmision", GetType(String))
        dtDatosPaciente.Columns.Add("NombreCompleto", GetType(String))
        dtDatosPaciente.Columns.Add("NumeroAdmision", GetType(String))
        dtDatosPaciente.Columns.Add("NumeroDocumento", GetType(String))
        dtDatosPaciente.Columns.Add("Pais", GetType(String))
        dtDatosPaciente.Columns.Add("PrimerApellido", GetType(String))
        dtDatosPaciente.Columns.Add("PrimerNombre", GetType(String))
        dtDatosPaciente.Columns.Add("RH", GetType(String))
        dtDatosPaciente.Columns.Add("Reingreso", GetType(String))
        dtDatosPaciente.Columns.Add("Religion", GetType(String))
        dtDatosPaciente.Columns.Add("SegundoApellido", GetType(String))
        dtDatosPaciente.Columns.Add("SegundoNombre", GetType(String))
        dtDatosPaciente.Columns.Add("TipoAdmision", GetType(String))
        dtDatosPaciente.Columns.Add("TipoConsultorio", GetType(String))
        dtDatosPaciente.Columns.Add("TipoDocumento", GetType(String))
        dtDatosPaciente.Columns.Add("TipoEntidad", GetType(String))
        dtDatosPaciente.Columns.Add("TipoHistoria", GetType(String))
        dtDatosPaciente.Columns.Add("TipoUsuario", GetType(String))
        dtDatosPaciente.Columns.Add("Ubicacion", GetType(String))

        Dim filaNueva As DataRow = dtDatosPaciente.NewRow()

        filaNueva("Admision") = objDatosPaciente.Admision
        filaNueva("AnoAdmision") = objDatosPaciente.AnoAdmision
        filaNueva("Cama") = objDatosPaciente.Cama
        filaNueva("Carnet") = objDatosPaciente.Carnet
        filaNueva("Ciudad") = objDatosPaciente.Ciudad
        filaNueva("ClasificacionTriage") = objDatosPaciente.ClasificacionTriage
        filaNueva("CodHistoria") = objDatosPaciente.CodHistoria
        filaNueva("CodigoOcupacionPaciente") = objDatosPaciente.CodigoOcupacionPaciente
        filaNueva("CodigoUnidadMedidaEdad") = objDatosPaciente.CodigoUnidadMedidaEdad
        filaNueva("Consultorio") = objDatosPaciente.Consultorio
        filaNueva("Cronico") = objDatosPaciente.Cronico
        filaNueva("DescripcionEntidad") = objDatosPaciente.DescripcionEntidad
        filaNueva("DescripcionGenero") = objDatosPaciente.DescripcionGenero
        filaNueva("DescripcionOcupacionPaciente") = objDatosPaciente.DescripcionOcupacionPaciente
        filaNueva("DescripcionTipoDocumento") = objDatosPaciente.DescripcionTipoDocumento
        filaNueva("DescripcionTipoHistoria") = objDatosPaciente.DescripcionTipoHistoria
        filaNueva("DescripcionUnidadMedidaEdad") = objDatosPaciente.DescripcionUnidadMedidaEdad
        filaNueva("DirSucursal") = objDatosPaciente.DirSucursal
        filaNueva("Edad") = objDatosPaciente.Edad
        filaNueva("EdadAMD") = objDatosPaciente.EdadAMD
        filaNueva("Entidad") = objDatosPaciente.Entidad
        filaNueva("EstadoAdmision") = objDatosPaciente.EstadoAdmision
        filaNueva("EstadoInicialHistoria") = objDatosPaciente.EstadoInicialHistoria
        filaNueva("EstadoInstancia") = objDatosPaciente.EstadoInstancia
        filaNueva("FechaAtencionProcedimiento") = objDatosPaciente.FechaAtencionProcedimiento
        filaNueva("FechaCita") = objDatosPaciente.FechaCita
        filaNueva("FechaHistoriaClinica") = objDatosPaciente.FechaHistoriaClinica
        filaNueva("FechaHoraAdmision") = objDatosPaciente.FechaHoraAdmision
        filaNueva("FechaIngresoAdmision") = objDatosPaciente.FechaIngresoAdmision
        filaNueva("FechaNacimiento") = objDatosPaciente.FechaNacimiento
        filaNueva("Genero") = objDatosPaciente.Genero
        filaNueva("GrupoRH") = objDatosPaciente.GrupoRH
        filaNueva("GrupoSanguineo") = objDatosPaciente.GrupoSanguineo
        filaNueva("HistoriaTieneEgreso") = objDatosPaciente.HistoriaTieneEgreso
        filaNueva("HoraAtencionProcedimiento") = objDatosPaciente.HoraAtencionProcedimiento
        filaNueva("HoraCita") = objDatosPaciente.HoraCita
        filaNueva("HoraHistoriaClinica") = objDatosPaciente.HoraHistoriaClinica
        filaNueva("HoraIngresoAdmision") = objDatosPaciente.HoraIngresoAdmision
        filaNueva("IdentificadorCama") = objDatosPaciente.IdentificadorCama
        filaNueva("ManejaConvenio") = objDatosPaciente.ManejaConvenio
        filaNueva("MinutoAtencionProcedimiento") = objDatosPaciente.MinutoAtencionProcedimiento
        filaNueva("MinutoCita") = objDatosPaciente.MinutoCita
        filaNueva("MinutoHistoriaClinica") = objDatosPaciente.MinutoHistoriaClinica
        filaNueva("MinutoIngresoAdmision") = objDatosPaciente.MinutoIngresoAdmision
        filaNueva("NombreCompleto") = objDatosPaciente.NombreCompleto
        filaNueva("NumeroAdmision") = objDatosPaciente.NumeroAdmision
        filaNueva("NumeroDocumento") = objDatosPaciente.NumeroDocumento
        filaNueva("Pais") = objDatosPaciente.Pais
        filaNueva("PrimerApellido") = objDatosPaciente.PrimerApellido
        filaNueva("PrimerNombre") = objDatosPaciente.PrimerNombre
        filaNueva("RH") = objDatosPaciente.RH
        filaNueva("Reingreso") = objDatosPaciente.Reingreso
        filaNueva("Religion") = objDatosPaciente.Religion
        filaNueva("SegundoApellido") = objDatosPaciente.SegundoApellido
        filaNueva("SegundoNombre") = objDatosPaciente.SegundoNombre
        filaNueva("TipoAdmision") = objDatosPaciente.TipoAdmision
        filaNueva("TipoConsultorio") = objDatosPaciente.TipoConsultorio
        filaNueva("TipoDocumento") = objDatosPaciente.TipoDocumento
        filaNueva("TipoEntidad") = objDatosPaciente.TipoEntidad
        filaNueva("TipoHistoria") = objDatosPaciente.TipoHistoria
        filaNueva("TipoUsuario") = objDatosPaciente.TipoUsuario
        filaNueva("Ubicacion") = objDatosPaciente.Ubicacion

        dtDatosPaciente.Rows.Add(filaNueva)

        Return dtDatosPaciente

    End Function

    Private Function sendFormulaByMail(ByVal emalDestino As String, ByVal reportBytes As Byte(),
                         ByVal reportName As String, ByVal smtpServer As String,
                         ByVal rptContentType As String, ByVal strAsunto As String) As Boolean
        Dim mailEnviado As Boolean = False
        ''Llenado del objeto que contiene la informacion para el mensaje
        Dim mail As New MailData()
        ''direccion de destinatario



        mail.toMail.Add(New MailAddress(emalDestino))

        Try
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
            Dim mSender As New MailSender(smtpServer, 587, SmtpDeliveryMethod.Network)

            mSender.sendMail(mail)

            mailEnviado = True
        Catch ex As Exception

        End Try
        Return mailEnviado
    End Function



    Public Sub guardarDatosOrdenesMedicas()
        Dim strmensaje As String = ""
        Dim strPracticaosi As String = ""
        Dim oEvolucion As New Evolucion
        Dim dtDatosPaciente As New DataTable
        Dim obj As New DAOOrdenes
        m_validado = True

        'ALM 166 20200303 raul Cruz
        If ValidarDatosHisBasica() Then
            Exit Sub
        End If

        'valido si no hay un checbox marcado el campo tratamiento debe quedar vacio ajuste alm 194
        Dim idfila As Int16 = 0
        Dim dtDatos As DataTable = dgtMedicaConcil.DataSource
        Dim dtDatosRespaldo As New DataTable
        Dim dt1 As New DataTable
        Dim countordenmed As Integer = 0
        Dim countfarmaco As Integer = 0
        Dim countmedconcil As Integer = 0
        Dim countNordenMed As Integer = 0
        Dim counsus As Integer = 0


        dtDatosRespaldo = dgtMedicaConcil.DataSource
        dt1 = dgtMedicaConcilSus.DataSource


        For Each row As DataRow In dt1.Rows


            dtDatosRespaldo.ImportRow(row)


        Next
        Dim RegistrosProcesar As Integer
        RegistrosProcesar = dgtMedicaConcil.Rows.Count
        dtDatosPaciente = CreateDataTablePaciente()
        For aux As Integer = 0 To RegistrosProcesar - 1
            For Each fila As DataGridViewRow In dgtMedicaConcil.Rows
                If fila.Cells("Modificar_med").FormattedValue = False And
               fila.Cells("Suspender_med").FormattedValue = False And
               fila.Cells("NroOrden").FormattedValue <> "0" Then

                    idfila = fila.Index
                    dtDatos.Rows.RemoveAt(idfila)
                End If
            Next
            dgtMedicaConcil.DataSource = dtDatos
        Next

        For Each Fila As DataGridViewRow In dgtMedicaConcil.Rows
            If Not Fila Is Nothing Then
                '//Puedes hacer una validación con el nombre de la columna
                If Fila.Cells("origen").Value = "OrdenMed" Then
                    countordenmed = +1

                End If

                If Fila.Cells("origen").Value = "Farmaco" Then
                    countfarmaco = +1

                End If

                If Fila.Cells("origen").Value = "MedConcil" Then
                    countmedconcil = +1

                End If

                If Fila.Cells("origen").Value = "NordenMed" Then
                    countNordenMed = +1

                End If

                If Fila.Cells("origen").Value = "OrdenMedSu" Then
                    counsus = +1

                End If




            End If
        Next




        If oEvolucion.ValidaEspDietaAislamiento(datosConexion, 0, datosLogin.CodigoEspecialidad) Then

            'se comentarea control de cambios de dietas 
            'If dtgDietas.RowCount = 0 And (datosPaciente.TipoAdmision = "A" Or datosPaciente.TipoAdmision = "H") Then
            '    MessageBox.Show("Pendiente prescripción de Dieta.", "Ordenes Medicas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Me.Panel2.Focus()
            '    m_validado = False
            '    Exit Sub
            'End If

            '''martovar requerimiento 593 Modificacion Funcionalidad de Dietas. 29/08/2017
            'If (Not Me.datosSinAlmacenarDieta) And dtgDietas.RowCount <> 0 And (datosPaciente.TipoAdmision = "U") Then
            '    If BLOrdenes.ValidarDieta24Horas1(dtgDietas(2, 0).Value.ToString) Then
            '        MessageBox.Show("Pendiente prescripción de Dieta.", "Ordenes Medicas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '        Me.Panel2.Focus()
            '        m_validado = False
            '        Exit Sub
            '    End If
            'End If

            '''martovar requerimiento 593 Modificacion Funcionalidad de Dietas. 29/08/2017
            'If (Not Me.datosSinAlmacenarDieta) And (datosPaciente.TipoAdmision = "A" Or datosPaciente.TipoAdmision = "H") Then
            '    If BLOrdenes.ValidarDieta24Horas1(dtgDietas(2, 0).Value.ToString) Then
            '        MessageBox.Show("Pendiente prescripción de Dieta.", "Ordenes Medicas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '        Me.Panel2.Focus()
            '        m_validado = False
            '        Exit Sub
            '    End If
            'End If

            If falg_modificar = 1 Then
                MessageBox.Show("Para emitir órdenes médicas de conciliación de medicamentos, primero debe dar clic en el botón Agregar y luego en el botón Guardar.", "Ordenes Medicas", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If


            'If (Not Me.datosSinAlmacenarDieta) And (Me.datosSinAlmacenar) Then
            '    If BLOrdenes.ValidarDieta24Horas1(dtgDietas(2, 0).Value.ToString) Then
            '        MessageBox.Show("Pendiente prescripción de Dieta.", "Ordenes Medicas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '        Me.Panel2.Focus()
            '        Exit Sub
            '    End If
            'End If
            '''fin

            ''Dsanchez IG- se valida que exista gestion en aislamientos req594 - 09/10/2017
            'If Not validaGuardarAislamientos() Then
            '    MessageBox.Show("Pendiente prescripción de Aislamientos.", "Ordenes Medicas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Me.Panel6.Focus()
            '    m_validado = False
            '    Exit Sub
            'End If

        End If

        If (Not Me.datosSinAlmacenar) Then

            MessageBox.Show("No existen datos por almacenar.", "Ordenes Medicas", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Exit Sub
        End If


        If datosLogin.Pais = "482" Then

            strmensaje = "Está generando Ordenes Medicas para el paciente " & Paciente.Instancia.NombreCompleto & vbCrLf &
                                       "Una vez los datos sean guardados no podrán ser modificados. Desea continuar con la transacción?"
        Else

            strmensaje = "Está generando Ordenes Medicas para el paciente " & Paciente.Instancia.NombreCompleto & vbCrLf &
                                       "Cama " & Paciente.Instancia.IdentificadorCama & vbCrLf &
                                       "Una vez los datos sean guardados no podrán ser modificados. Desea continuar con la transacción?"
        End If

        ''Claudia Garay Abril 5 de 2011
        If MessageBox.Show(strmensaje, "Historia Clinica", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
            Dim NroOrden As Double
            Dim fechaOrden As Date
            Dim lError As Long
            Dim strCodCentroCostoOrigen As String = ""
            Dim strDescripCentroCosto As String
            Dim strTipoServicio As String
            Dim strPrioridad As String
            Dim linkedServer As String  ''' Jimmy Leandro guevara 2017/09/19 triage avanzado (intergrupo)
            Dim MedControl As Int16 = 0
            Dim ResultadoGrabar As Int16 = 0
            Dim strMarcaCentroCostoOrigen As String = ""
            Dim strMarcaOrdenMEddia As String = ""

            'BtnGuardar.Enabled = False ' herojas honorario variable 2015/03/17 para que no permita duplicar las ordenes
            'If Me.op_TipoServ.Checked = True Then
            strTipoServicio = "1" ' Posterios a la Urgencia
            strPrioridad = ""     ' Electiva
            'Else
            '    strTipoServicio = "2"
            '    If Me.op_PrioSI.Checked = True Then
            '        strPrioridad = "1" ' Prioritaria
            '    Else
            '        strPrioridad = "2" ' No Prioritaria
            '    End If
            'End If

            Dim ResultadoSesion As String
            Try
                ResultadoSesion = BLOrdenes.Consultausuariosseccion(datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.TipoAdmision,
                                              datosPaciente.NumeroAdmision, datosPaciente.AnoAdmision, "CM", InicioSesion)

                If ResultadoSesion = "S" Then
                    MessageBox.Show("Las ordenes médicas acaban de ser gestionadas por otro usuario.  Debe volver a prescribir.", "Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'LimpiarDatos()
                    _MedicamentosConcil.Estado = "N"
                    _MedicamentosConcilSus.Estado = "N"
                    _MedicamentosConcilOtros.Estado = "N"
                    mostrar()
                    falg_modificar = 0
                    Me.BtnGuardar.Enabled = True
                    Exit Sub
                End If
            Catch ex As Exception
                MessageBox.Show("Error: " + ex.Message, "Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End Try



            Try
                ErrorModulo = "GuardarDatosOrdenesMedicas"
                ''Procedimiento que se guarda los datos que estan en las grillas
                Try
                    ErrorModulo = "GuardarDatosOrdenesMedicas"

                    Dim Loghomologacion As New DataTable  '' Jimmy Leandro guevara 2017/09/19 triage avanzado (intergrupo)
                    Dim dtRespuestaAdm As New DataTable  '' Jimmy Leandro guevara 2017/09/19 triage avanzado (intergrupo)
                    Dim homologacion As New DataTable '' Jimmy Leandro guevara 2017/09/19 triage avanzado (intergrupo)
                    dtDatosPaciente = CreateDataTablePaciente()


                    'Inicio EROSI584 Prescripcion de Medicamentos Raul Cruz alm 91
                    Dim tabla As DataTable = dgtMedicaConcil.DataSource
                    Dim filaMedControl As DataRow() = tabla.Select("(idRegistro = 'N' or tmp_modificar_med = 'M') and  medControl = 'S'")

                    If filaMedControl.Length > 0 Then 'si es por primera vez que insertan en la grilla
                        MsgBox("Debe imprimir la fórmula medicamento de control?", MsgBoxStyle.Information, "Historia Clínica")
                        MedControl = 1
                    Else
                        Dim filaMedControl2 As DataRow() = tabla.Select("Tratamiento = 'C'  and  medControl = 'S' ")

                        If filaMedControl2.Length > 0 Then 'si lo estan confirmando de nuevo

                            For aux As Integer = 0 To filaMedControl2(0).Table.Rows.Count - 1
                                Dim Fec_Con As Date
                                Dim medControlx As String

                                medControlx = filaMedControl2(0).Table.Rows(aux).Item("medControl")

                                If medControlx = "S" Then
                                    Fec_Con = filaMedControl2(0).Table.Rows(aux).Item(2)

                                    If Format(Now.Date, "yyyy-MM-dd") > Format(Fec_Con, "yyyy-MM-dd") And medControlx = "S" Then 'si viene del dia anteriorios y es el primer continuar
                                        MsgBox("Debe imprimir la fórmula medicamento de control?", MsgBoxStyle.Information, "Historia Clínica")
                                        MedControl = 1
                                        Exit For
                                    End If
                                End If

                            Next
                        End If

                    End If
                    'Fin EROSI584 Prescripcion de Medicamentos Raul Cruz


                    ' Borrar la marca para registros nuevos que se ingresaron en el modulo de medicamentos.
                    Dim dtMedica As DataTable = dgtMedicaConcil.DataSource
                    Dim resultados As DataRow() = dtMedica.Select("idRegistro = 'N'")
                    For Each fila As DataRow In resultados
                        fila("idRegistro") = ""
                    Next

                    Dim s As String

                    lError = BLConciliacionMedicamentos.guardarOrdenes(datosConexion, datosLogin.Prestador, datosLogin.Sucursal,
                                                                    datosPaciente.TipoAdmision, datosPaciente.NumeroAdmision,
                                                                    datosPaciente.AnoAdmision, datosLogin.Login, datosLogin.Login,
                                                                    datosLogin.CodigoEspecialidad, datosPaciente.Entidad,
                                                                    dgtMedicaConcil.DataSource, dtDatosPaciente,
                                                                    NroOrden, fechaOrden, strCodCentroCostoOrigen, "",
                                                                    "", strTipoServicio, strPrioridad, "", "",
                                                                    InicioSesion, strPracticaosi)
                    ' Jimmy Leandro guevara 2017/09/19 triage avanzado (intergrupo)
                    NroOrdenOrigen = NroOrden


                    'Inicio EROSI584 Grabar sesion usuario OM Raul Cruz 
                    Try
                        ResultadoGrabar = BLOrdenes.GrabarLogUsuario(datosLogin.Prestador, datosLogin.Sucursal,
                                                                    datosPaciente.TipoAdmision, datosPaciente.NumeroAdmision,
                                                                    datosPaciente.AnoAdmision, "CM", InicioSesion, datosLogin.Login, "")
                        'ocurrio un error al grabar  el log de usuario
                        If ResultadoGrabar > 0 Then
                            MessageBox.Show("Error " + ResultadoGrabar.ToString + " al grabar el log se usuario de sesión", "Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Error " + ex.Message)
                    End Try
                    'Fin EROSI584 Grabar sesion usuario OM Raul Cruz 

                    'rmzaldua  2020-09-29 inicio##

                    strCodCentroCostoOrigen = obj.consultarCCOrigen(datosConexion, datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.TipoAdmision, datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision, datosPaciente.Entidad)

                    strMarcaCentroCostoOrigen = obj.consultarMarcaccostopedidoPyxis(datosConexion, datosLogin.Prestador, datosLogin.Sucursal, strCodCentroCostoOrigen, datosPaciente.TipoAdmision, datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision)

                    'Invocar al servicio pyxis
                    If Not IsNothing(dtDatosPaciente) And strMarcaCentroCostoOrigen = "S" Then
                        InvocacionInterfacePyxis(dtDatosPaciente, dgtMedicaConcil.DataSource, NroOrden, strCodCentroCostoOrigen)
                    End If
                    'fin rmzaldua
                    If NroOrdenOrigen > 0 Then

                        ''If dtgProcedimientos.RowCount > 0 Then

                        ''    Dim dtProcedimientos As DataTable

                        ''    Dim dtRespuestaOrden As New DataTable

                        ''    homologacion = BLOrdenes.ConsultarHomologacion(datosLogin.Prestador, datosLogin.Sucursal)

                        ''    If homologacion IsNot Nothing And homologacion.Rows.Count > 0 Then
                        ''        If Convert.ToBoolean(homologacion.Rows(0)("Estado")) = True Then

                        ''            linkedServer = BLOrdenes.ConsultarLinkedServer(Convert.ToInt32(homologacion.Rows(0)("Id_Localizacion_Destino").ToString()))
                        ''            dtProcedimientos = BLOrdenes.ConsultarProcedimientoPorCodigo(dtgProcedimientos.DataSource, linkedServer, homologacion.Rows(0)("cod_pre_sgs_destino").ToString(), homologacion.Rows(0)("cod_sucur_destino").ToString())

                        ''            If dtProcedimientos.Rows.Count > 0 Then
                        ''                dtRespuestaAdm = GuardarAdmisionHomologada(linkedServer, Convert.ToInt32(homologacion.Rows(0)("Id_Localizacion_Destino").ToString()), dtProcedimientos, homologacion.Rows(0)("cod_pre_sgs_destino").ToString(), homologacion.Rows(0)("cod_sucur_destino").ToString())



                        ''                If dtRespuestaAdm.Rows.Count Then

                        ''                    Loghomologacion = BLOrdenes.guardarOrdenesHomologada(datosConexion, linkedServer, homologacion.Rows(0)("cod_pre_sgs_destino").ToString(), homologacion.Rows(0)("cod_sucur_destino").ToString(),
                        ''                                                        datosPaciente.TipoAdmision, dtRespuestaAdm.Rows(0)("NumeroAdmisionDestino"),
                        ''                                                        Date.Now.Year.ToString(), datosLogin.Login, datosLogin.Login,
                        ''                                                        datosLogin.CodigoEspecialidad, datosPaciente.Entidad,
                        ''                                                        dtgAislamiento.DataSource, dtgDietas.DataSource, dtgMedicamentos.DataSource,
                        ''                                                        dtgProcedimientos.DataSource, dtgGenerales.DataSource,
                        ''                                                        0, fechaOrden, strCodCentroCostoOrigen, Me.tb_Guia.Text,
                        ''                                                        Me.tb_Justi.Text, strTipoServicio, strPrioridad, txtCodProcedim.Text, cmbDescripProcedim.Text, strPracticaosi)


                        ''                End If
                        ''                GuardarLogOrdenHomologada(dtRespuestaAdm, Loghomologacion, NroOrdenOrigen, linkedServer, homologacion)
                        ''            End If
                        ''        End If
                        ''    End If
                        ''End If
                    End If
                    ''' Fin Jimmy Leandro guevara 2017/09/19 triage avanzado (intergrupo)
                    Me.datosSinAlmacenar = False

                Catch ex As Exception
                    MsgBox("Error en el proceso de grabación. Ingrese nuevamente la información " & ex.Message, MsgBoxStyle.Information)
                    BLOrdenes.GrabarErroresOrdenesMedicas("HistoriaMedic a" & ex.Message)
                    Me.datosSinAlmacenar = True
                    BtnGuardar.Enabled = True ' herojas honorario variable 2015/03/17 para que no permita duplicar las ordenes
                    ErroresHC(ex.Source & " - " & Environment.MachineName.ToString & " - " & ErrorModulo, ex.Message, ex.StackTrace & " - " & ex.TargetSite.ToString)
                    'Exit Sub
                End Try



                ''Manejo del error
                If lError <> 0 Then
                    If lError = 7 Then
                        Try
                            ResultadoSesion = BLOrdenes.Consultausuariosseccion(datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.TipoAdmision,
                                                          datosPaciente.NumeroAdmision, datosPaciente.AnoAdmision, "CM", InicioSesion)

                            If ResultadoSesion = "S" Then
                                MessageBox.Show("Las ordenes médicas acaban de ser gestionadas por otro usuario.  Debe volver a prescribir.", "Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                LimpiarDatos()
                                _MedicamentosConcil.Estado = "N"
                                _MedicamentosConcilSus.Estado = "N"
                                _MedicamentosConcilOtros.Estado = "N"
                                mostrar()
                                falg_modificar = 0
                                Me.BtnGuardar.Enabled = True
                                Exit Sub
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Error: " + ex.Message, "Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        End Try
                    End If

                    If lError = 99 Then
                        MsgBox("Error en el proceso de grabación. Error obteniendo el número de orden para la sucursal.", MsgBoxStyle.Information)
                    ElseIf lError = 999 Then
                        If dtDatos.Rows.Count = 0 Then 'esto cuando se hicieron gestion a todos los registros pero luego los desactivaron
                            _MedicamentosConcil.Estado = "N"
                            _MedicamentosConcilSus.Estado = "N"
                            _MedicamentosConcilOtros.Estado = "N"
                            mostrar()

                        End If
                        MsgBox("No existen datos para guardar.", MsgBoxStyle.Information)
                    Else
                        MsgBox("Error en el proceso de grabación." & lError, MsgBoxStyle.Information)
                    End If
                    BtnGuardar.Enabled = True ' herojas honorario variable 2015/03/17 para que no permita duplicar las ordenes
                    Exit Sub
                Else

                    'CDQUIROGA 14/02/2019 Comentar llamado a reporte local
                    'If datosLogin.Pais <> "482" Then ''cpgaray Peru
                    '    ''Imprimiendo pdf
                    '    Try
                    '        If dtgProcedimientos.RowCount > 0 Then
                    '            Me.ImprimirProcedim(datosLogin.Prestador, datosLogin.Sucursal,
                    '                    datosPaciente.TipoAdmision, datosPaciente.AnoAdmision,
                    '                    datosPaciente.NumeroAdmision, NroOrden, 2)
                    '        End If
                    '    Catch ex As Exception
                    '        MessageBox.Show("Error en la creacion del reporte de solicitud de servicios de salud", "Historia Clinica", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '    End Try
                    'End If
                    'CDQUIROGA 14/02/2019 Comentar llamado a reporte local

                    ''Se trae la descripcion del centro de costo para incluirla 
                    ''en el reporte.




                    strDescripCentroCosto = BLOrdenes.traerDescripcionCentroCosto(datosConexion, datosLogin.Prestador,
                                            datosLogin.Sucursal, strCodCentroCostoOrigen)

                    ''Se imprime el reporte de la orden medica
                    ''cdquiroga se adiciona control para visualizar medicamentos controlados
                    ''inicio
                    'If countordenmed > 0 Or countNordenMed > 0 Or counsus > 0 Then
                    '    If MedControl > 0 Then
                    imprimirOrdenMedica(NroOrden, strDescripCentroCosto, strPracticaosi, True)
                    'Else


                    '    End If
                    'End If
                    ''Fin
                    ''cdquiroga se adiciona control para visualizar medicamentos controlados


                    ' ''Ctc's Medicamentos Claudia Garay Marzo 27 de 2012
                    Dim dtMedica As New DataTable

                    dtMedica = dgtMedicaConcil.DataSource

                    ''consulta de la sucursal ctc

                    Dim daoGeneral As New DAOGeneral
                    Dim email As String = ""


                    email = daoGeneral.EjecutarSQLStrValor("gensucur (nolock)", datosConexion, " email_ctc ", " cod_sucur='" & datosLogin.Sucursal & "'")

                    Try
                        'tratamiento="S"
                        For i As Integer = 0 To dtMedica.Rows.Count - 1
                            '' strtratamiento = IIf(IsDBNull(dtMedica.Rows(i).Item("Tratamiento")), "", dtMedica.Rows(i).Item("Tratamiento"))
                            If Not IsDBNull(dtMedica.Rows(i).Item("cod_corto")) Then

                                If Len(dtMedica.Rows(i).Item("cod_corto")) > 0 And dtMedica.Rows(i).Item("NroOrden") = 0 Then

                                    Dim frmExcepcion As New frmRepExcepcion
                                    Dim dtReportctc As New DataTable

                                    frmExcepcion.imprimirRepExcepcion(datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.TipoAdmision,
                            datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision, datosPaciente.TipoDocumento, NroOrden, datosPaciente.NumeroDocumento,
                            dtMedica.Rows(i).Item("cod_corto"), 0, dtReportctc, dtMedica.Rows(i).Item("secuencia"))

                                    If dtReportctc.Rows.Count > 0 Then
                                        frmExcepcion.Show()
                                        If email Is Nothing Or email = "" Then
                                            MessageBox.Show("No existe una direccion de correo parametrizada para la sucursal", "Historia Clinica", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                                        Else

                                            Dim rptBytes As Byte() = frmExcepcion.getReportBytes(frmRepExcepcion.FormatReport.pdf)
                                            Dim strAsunto As String = datosPaciente.TipoDocumento & "_" & datosPaciente.NumeroDocumento & "_" & datosPaciente.NombreCompleto
                                            ' frmExcepcion.Visible = False

                                            ''Se envia el reporte via correo electronico
                                            'If (Me.sendFormulaByMail(email, rptBytes, _
                                            '                        "Insumo_No_incluido_en_el_POS.pdf", "SMTP.office365.com", "application/pdf", "Insumo No Incluido en el POS")) Then


                                            Try

                                                If (Me.sendFormulaByMail(email, rptBytes,
                                                 strAsunto & ".pdf", "smtp.gmail.com", "application/pdf", strAsunto)) Then
                                                    frmExcepcion.Dispose()
                                                    ''MsgBox("El reporte de solicitud de servicios ha sido enviado sin inconvenientes", MsgBoxStyle.Information, "Historia Clinica")
                                                    MessageBox.Show("La solicitud de medicamento o procedimiento - Insumo No incluido en el POS ha sido enviado sin inconvenientes", "Historia Clinica", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                    'Dim visorRptFormula1 As New FrmRepFomulaProcedimtPDF(codPrestador, codSucursal, tipAdmin, _
                                                    '                                   iAno, lNumAdm, dConProcedim, FlagConsulta)

                                                    'visorRptFormula1.WindowState = FormWindowState.Maximized
                                                    ' ''visorRptFormula.ShowDialog(Me.ParentForm)
                                                    'frmExcepcion.Visible = True

                                                Else

                                                    frmExcepcion.Dispose()
                                                    MessageBox.Show("La solicitud de medicamento o procedimiento - Insumo No incluido en el POS no ha podido ser enviado", "Historia Clinica", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                End If
                                            Catch ex As Exception
                                                BLOrdenes.GrabarErroresOrdenesMedicas("HistoriaMedicaCTCEnvio " & ex.Message)
                                                MsgBox(ex.Message)
                                            End Try
                                        End If

                                        Dim frmExcepcionR As New frmRepExcepcion
                                        Dim dttempctc As New DataTable
                                        frmExcepcionR.imprimirRepExcepcion(datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.TipoAdmision,
                                datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision, datosPaciente.TipoDocumento, NroOrden, datosPaciente.NumeroDocumento,
                                dtMedica.Rows(i).Item("cod_corto"), 0, dttempctc, dtMedica.Rows(i).Item("secuencia"))
                                        frmExcepcionR.Show()

                                    End If

                                End If

                            End If
                        Next

                        BtnGuardar.Enabled = True ' herojas honorario variable 2015/03/17 para que no permita duplicar las ordenes

                    Catch ex As Exception
                        MsgBox(ex.Message)
                        BtnGuardar.Enabled = True ' herojas honorario variable 2015/03/17 para que no permita duplicar las ordenes
                    End Try

                    'Ctc's Procedimientos Claudia Garay Marzo 27 de 2012
                    'Dim dtProcedim As New DataTable

                    'dtProcedim = dtgProcedimientos.DataSource

                    'For i As Integer = 0 To dtProcedim.Rows.Count - 1
                    '    '' strtratamiento = IIf(IsDBNull(dtMedica.Rows(i).Item("Tratamiento")), "", dtMedica.Rows(i).Item("Tratamiento"))
                    '    If Not IsDBNull(dtProcedim.Rows(i).Item("justificacion_Excep")) Then
                    '        If Len(dtProcedim.Rows(i).Item("justificacion_Excep")) > 0 And dtProcedim.Rows(i).Item("NroOrden") = 0 Then
                    '            Dim frmExcepcion As New frmRepExcepcion
                    '            frmExcepcion.imprimirRepExcepcion(datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.TipoAdmision, _
                    '            datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision, datosPaciente.TipoDocumento, NroOrden, datosPaciente.NumeroDocumento, _
                    '            dtProcedim.Rows(i).Item("procedim"), 0)
                    '            frmExcepcion.Show()
                    '        End If
                    '    End If

                    'Next



                    ''Se actualizan los datos de las grillas para que 
                    ''esten de acuerdo con lo que se guardo en la BD
                    ''Por ejemplo se borran de la grilla los registros suspendidos
                    actualizarGrillas(NroOrden, fechaOrden)

                    '''Se actualiza el flag que indica si se realizo alguna 
                    '''modificacion en la historia clinica. 
                    'datosLogin.HistoriaClinicaTieneModificaciones = True

                    'LimpiarPanel(Me.panelProce1, Me.btnAdicionarProcedim)
                    'InhabilitarSegunPais()
                    'Me.tb_Guia.Enabled = True
                    'Me.tb_Justi.Enabled = True
                    'Me.GroupServi.Enabled = True
                    '''Se inicializan las variables globales tales como 
                    '''los tamaños de los xml
                    'inicializaVariables()
                    ''agfa_orm_in 2014/10/30
                    'cargarDiagnosticos()
                    'strJustificaSinConvenio = "" ' Honorario variable 2015/03/17
                    Me.datosSinAlmacenar = False

                End If

            Catch ex As Exception
                MsgBox("Error en el proceso de impresión" & ex.Message, MsgBoxStyle.Information)
                BLOrdenes.GrabarErroresOrdenesMedicas("HistoriaMedica" & ex.Message)
                Me.datosSinAlmacenar = True
                BtnGuardar.Enabled = True ' herojas honorario variable 2015/03/17 para que no permita duplicar las ordenes
                ErroresHC(ex.Source & " - " & Environment.MachineName.ToString & " - " & ErrorModulo, ex.Message, ex.StackTrace & " - " & ex.TargetSite.ToString)

            End Try
        End If
        'txtCodMedica.Enabled = True
        cmbDescripMedica.Enabled = True


        _MedicamentosConcil.Estado = "N"
        _MedicamentosConcilSus.Estado = "N"
        _MedicamentosConcilOtros.Estado = "N"
        mostrar()
        ''InicializaValorControles()
        ''cargarGrillas()

    End Sub

    Private Sub actualizarGrillas(ByVal NuevoNroOrden As Double, ByVal fechaOrden As Date)

        'Dim dtProce As DataTable

        '''''''GRILLA DIETA 
        'actualizarNroOrden(dtgDietas.DataSource, NuevoNroOrden, DataViewRowState.Added)
        'actualizarNroOrden(dtgDietas.DataSource, NuevoNroOrden, DataViewRowState.ModifiedCurrent)
        'actualizarFechaOrden(dtgDietas.DataSource, fechaOrden, DataViewRowState.Added)
        'actualizarFechaOrden(dtgDietas.DataSource, fechaOrden, DataViewRowState.ModifiedCurrent)
        'borrarFilasInactivas(dtgDietas.DataSource)
        'For Each rowItem As DataGridViewRow In Me.dtgDietas.Rows
        '    rowItem.Cells("SUSPENDER").Value = Nothing
        '    rowItem.Cells("CONTINUAR").Value = Nothing
        'Next


        '''''''GRILLA MEDICAMENTOS
        'actualizarNroOrden(dtgMedicamentos.DataSource, NuevoNroOrden, DataViewRowState.Added)
        'actualizarNroOrden(dtgMedicamentos.DataSource, NuevoNroOrden, DataViewRowState.ModifiedCurrent)
        'actualizarFechaOrden(dtgMedicamentos.DataSource, fechaOrden, DataViewRowState.Added)
        'actualizarFechaOrden(dtgMedicamentos.DataSource, fechaOrden, DataViewRowState.ModifiedCurrent)
        'borrarFilasInactivas(dtgMedicamentos.DataSource)
        'For Each rowItem As DataGridViewRow In Me.dtgMedicamentos.Rows
        '    rowItem.Cells("SUSPENDER_MED").Value = Nothing
        '    rowItem.Cells("CONTINUAR_MED").Value = Nothing
        '    rowItem.Cells("modificar_med").Value = Nothing

        'Next

        '''''''GRILLA PROCEDIMIENTOS
        'dtProce = dtgProcedimientos.DataSource
        'dtProce.Clear()

        '''''''GRILLA ORDENES GENERALES
        'actualizarNroOrden(dtgGenerales.DataSource, NuevoNroOrden, DataViewRowState.Added)
        'actualizarNroOrden(dtgGenerales.DataSource, NuevoNroOrden, DataViewRowState.ModifiedCurrent)
        'actualizarFechaOrden(dtgGenerales.DataSource, fechaOrden, DataViewRowState.Added)
        'actualizarFechaOrden(dtgGenerales.DataSource, fechaOrden, DataViewRowState.ModifiedCurrent)
        'borrarFilasInactivas(dtgGenerales.DataSource)
        ''For Each rowItem As DataGridViewRow In Me.dtgGenerales.Rows
        ''    rowItem.Cells("suspender_gen").Value = Nothing
        ''    rowItem.Cells("CONTINUAR_GEN").Value = Nothing

        ''Next

        _MedicamentosConcil.TablasOrdenes.AcceptChanges()
    End Sub



    Private Sub LimpiarDatos()
        'txtTipDieta.ResetText()
        'txtDescripDieta.ResetText()
        'txtTextoOrden.ResetText()
        'txtObsDieta.ResetText()
        txtCodMedica.ResetText()
        'cmbDescripMedica.ResetText()
        txtDosis.ResetText()
        'cmbUnidadMedida.ResetText()
        txtDescripcionUM.ResetText()
        'txtCodigoUM.ResetText()
        'cmbViaAdmin.ResetText()
        txtDescripcionVA.ResetText()
        txtDescripcionVA.ResetText()
        'txtCodigoFreq.ResetText()
        txtDescripcionFreq.ResetText()
        txtTecnica.ResetText()
        'tbCodTipoProcedim.ResetText()
        'tbDesTipoProc.ResetText()
        'txtCodProcedim.ResetText()
        'cmbDescripProcedim.ResetText()
        'cmbCentroCosto.ResetText()
        'txtCantidad.ResetText()
        'txtObsProcedim.ResetText()
        'txtTextoOrden.ResetText()
        ' agfa_orm_in 2014/09/15 herojas
        'tb_Guia.ResetText()
        'tb_Justi.ResetText()
        'Me.tb_Guia.Enabled = True
        'Me.tb_Justi.Enabled = True
        'Me.txtcc.ResetText()
        'Me.RadioButton2.Checked = False
        'Me.RadioButton1.Checked = False
        'Me.txtcc.Enabled = True
        'Cmbtiempo.ResetText()
        'Cmbtiempo.Text = Nothing
        Me.txtTecnica.Text = ""
        txtorigengrilla.Text = ""

    End Sub

    Private Sub imprimirOrdenMedica(ByVal NroOrden As Double, Optional ByVal strCentroCostoOrigen As String = "", Optional ByVal strpractica As String = "", Optional ByVal VistaGuardarMostrar As Boolean = False)

        Try
            ''cdquiroga se adiciona control para visualizar medicamentos controlados
            RptHC.ImprimirOrdenMedica("57", datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.TipoAdmision,
                              datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision, datosPaciente.CodHistoria, NroOrden,
                              datosLogin.NombreMedico, datosLogin.RegistroMedico, datosLogin.DescripcionEspecialidad, False, VistaGuardarMostrar, False)
            RptHC.ShowDialog()
            RptHC.Close()

        Catch ex As Exception
            Dim dsOrdenesNuevasModif As DataSet
            Dim objGenerales As New DAOGeneral()
            Dim strDiagnostico As String
            ''Se extraen de las grillas solo los registros nuevos o los que fueron modificados
            ''con los cuales se realiza el reporte. 
            'dsOrdenesNuevasModif = BLOrdenes.RegistrosModificadosAdicionados(_Ordenes.TablasOrdenes)

            ''Se consulta lo almacenado en la base de datos para la impresion del reporte
            ''Claudia Garay 30 marzo 2011
            ''Solicitado por Hernan Rojas
            dsOrdenesNuevasModif = objGenerales.EjecutarSPConParametrosDataSet("HC_ConsultarOrdenReimpresion", datosConexion,
                                                                              -1, datosLogin.Prestador, datosLogin.Sucursal, NroOrden, datosPaciente.TipoAdmision,
                                                                              datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision)


            ''cpgaray Nov 15 de 2012
            ''Agregar el diagnostico principal a las ordenes de procedimientos

            dsOrdenesNuevasModif.Tables(4).Columns.Add("Diagnostico", System.Type.GetType("System.String"))


            If dsOrdenesNuevasModif.Tables(4).Rows.Count > 0 And dsOrdenesNuevasModif.Tables(6).Rows.Count > 0 Then


                For i As Integer = 0 To dsOrdenesNuevasModif.Tables(6).Rows.Count - 1
                    strDiagnostico = strDiagnostico & dsOrdenesNuevasModif.Tables(6).Rows(i).Item("diagnost").ToString & " " & dsOrdenesNuevasModif.Tables(6).Rows(i).Item("descripcion").ToString & " ,"
                Next

                For i As Integer = 0 To dsOrdenesNuevasModif.Tables(4).Rows.Count - 1
                    dsOrdenesNuevasModif.Tables(4).Rows(i).Item("Diagnostico") = strDiagnostico
                Next

            End If
            Dim objDatosGenerales As objGenerales.Generales

            objDatosGenerales = datosLogin

            With dsOrdenesNuevasModif


                If objDatosGenerales.Pais = "482" Then ''Peru 
                    frmRepOrdenMedica.Show()
                    frmRepOrdenMedica.imprimirOrdenMedica(.Tables(1), .Tables(2), .Tables(3),
                                                                      .Tables(4), .Tables(5), datosLogin, datosPaciente, NroOrden,
                                                                      strCentroCostoOrigen, strpractica)
                Else
                    RptHC.ImprimirOrdenMedica("57", datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.TipoAdmision,
                              datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision, datosPaciente.CodHistoria, " ",
                               datosLogin.NombreMedico, datosLogin.RegistroMedico, datosLogin.DescripcionEspecialidad)
                    RptHC.ShowDialog()
                    RptHC.Close()
                End If

            End With

        End Try

    End Sub

    Public Async Sub InvocacionInterfacePyxis(dato1 As Object, dato2 As DataTable, dato3 As String, dato4 As String)
        Dim reintento As DataTable
        Dim valor As Integer
        Dim item As Integer = 1
        Dim daoOrden As New DAOEnfermeriaCP
        Dim valida As String
        reintento = daoOrden.ConsultarDiasHistorico("REINTENTOS_CRUZ_VERDE")

        If reintento.Rows.Count > 0 Then
            valor = reintento.Rows(0).Item("valor").ToString
        End If

        For item = 1 To valor
            valida = BLOrdenes.CreateJsonObjectPyxis(dato1, dato2, dato3, dato4)
            If valida = 0 Then
                item = 4
            End If
        Next

    End Sub
    Public Sub ErroresHC(ByVal ExSource As String, ByVal ExMessage As String, ByVal ExStackTrace As String)
        Dim objcontrolHcb As New BLHistoriaBasica

        Dim Datos() As Object
        Dim lError As Long
        Dim s As String
        Dim objGeneral As Generales
        Dim objpaciente As Paciente
        Dim idErrorHC As Integer
        Dim objBL As New BLBasicasGenerales

        ReDim Datos(11)
        Datos(0) = datosLogin.Prestador
        Datos(1) = datosLogin.Sucursal
        Datos(2) = datosPaciente.TipoAdmision
        Datos(3) = datosPaciente.AnoAdmision
        Datos(4) = datosPaciente.NumeroAdmision
        Datos(5) = datosPaciente.TipoDocumento
        Datos(6) = datosPaciente.NumeroDocumento
        Datos(7) = ExSource
        Datos(8) = ExMessage
        Datos(9) = ExStackTrace
        Datos(10) = datosLogin.Login
        Datos(11) = lError
        Try
            lError = objBL.NErroresHC(datosConexion, lError, Datos)
            idErrorHC = lError
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        guardarDatosOrdenesMedicas()
    End Sub

    Public Sub ActualizarGrilla()


        _MedicamentosConcil.Estado = "N"
        _MedicamentosConcilSus.Estado = "N"
        _MedicamentosConcilOtros.Estado = "N"
        intload = 1
        intloadSus = 1
        intloadotros = 1

        mostrar()
    End Sub


#End Region

    Private Sub cmbDescripMedica_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDescripMedica.SelectedIndexChanged
        'Dim dtDatos As DataTable

        'dtDatos = cmbDescripMedica.DataSource
        'If dtDatos Is Nothing Then
        '    Exit Sub
        'End If

        'If dtDatos.Rows.Count <= 0 Then
        '    Exit Sub
        'End If

        'If cmbDescripMedica.SelectedIndex <> -1 Then
        '    With dtDatos.Rows(cmbDescripMedica.SelectedIndex)
        '        'eloaiza@intergrupo.com REQ OSI 584 Se deja en comentario y se limpia por si las moscas
        '        'txtDosis.Text = .Item("contenido").ToString
        '        txtDosis.Text = String.Empty
        '        txtDescripcionUM.Text = .Item("descrConcentracion").ToString
        '        ''Claudia Garay Noviembre 17 de 2010
        '        ''Cambio de combo de via de administracion y unidad de medida por textbox con formato
        '        'cmbUnidadMedida.Text = .Item("descrConcentracion").ToString
        '        'cmbViaAdmin.Text = .Item("descrVia").ToString
        '        txtDescripcionVA.Text = .Item("descrVia").ToString
        '        'txtCodigoFreq.Text = .Item("frecuencia").ToString
        '        txtDescripcionFreq.Text = .Item("descrFrecuencia").ToString
        '        txtTecnica.Text = .Item("obs").ToString
        '    End With
        'End If
    End Sub

    Private Sub cmbDescripMedica_TextChanged(sender As Object, e As EventArgs) Handles cmbDescripMedica.TextChanged
        'Dim dtDatos As DataTable

        'dtDatos = cmbDescripMedica.DataSource
        'If dtDatos Is Nothing Then
        '    Exit Sub
        'End If

        'If dtDatos.Rows.Count <= 0 Then
        '    Exit Sub
        'End If

        'If cmbDescripMedica.Text <> "" Then
        '    With dtDatos.Rows(cmbDescripMedica.SelectedIndex)
        '        'eloaiza@intergrupo.com REQ OSI 584 Se deja en comentario y se limpia por si las moscas
        '        'txtDosis.Text = .Item("contenido").ToString
        '        txtDosis.Text = String.Empty
        '        txtDescripcionUM.Text = .Item("descrConcentracion").ToString
        '        ''Claudia Garay Noviembre 17 de 2010
        '        ''Cambio de combo de via de administracion y unidad de medida por textbox con formato
        '        'cmbUnidadMedida.Text = .Item("descrConcentracion").ToString
        '        'cmbViaAdmin.Text = .Item("descrVia").ToString
        '        txtDescripcionVA.Text = .Item("descrVia").ToString
        '        'txtCodigoFreq.Text = .Item("frecuencia").ToString
        '        txtDescripcionFreq.Text = .Item("descrFrecuencia").ToString
        '        txtTecnica.Text = .Item("obs").ToString
        '    End With
        'End If
    End Sub


    Private Sub ActualizarDatos(ByVal IndiceFilaSeleccionada As Integer, datagrid As DataGridView)
        dtaux = "dgtMedicaConcil"
        dtaux2 = "dgtMedicaConcilSus"
        'If datosElegidos Is Nothing Then
        '    txtDosis.Text = ""
        '    ''cmbUnidadMedida.Text = ""
        '    txtDescripcionUM.Text = String.Empty
        '    'cmbViaAdmin.Text = ""
        '    txtDescripcionVA.Text = String.Empty
        '    'txtCodigoFreq.Text = ""
        '    txtDescripcionFreq.Text = ""
        '    txtTecnica.Text = ""
        '    Exit Sub
        'End If

        Me.GroupCnt24.Visible = False

        ''txtDosis.Text = IIf(IsDBNull(.Item("contenido")), "", .Item("contenido"))
        If datagrid.Rows(IndiceFilaSeleccionada).Cells("contenido").Value <> "0" Then
            ''  txtDosis.Text = .Item("contenido").ToString rcruzr corrección alm 57 20200122
        Else
            txtDosis.ResetText()
        End If
        'cmbUnidadMedida.Text = .Item("descrConcentracion").ToString
        txtDosis.ResetText()

        ''Claudia Garay Noviembre 17 de 2010
        ''Cambio de combo de unidad de medida y via de administracion por textbox con formato
        'txtDescripcionUM.Text = datagrid.Rows(IndiceFilaSeleccionada).Cells("descrConcentracion").Value.ToString()
        'txtDescripcionVA.Text = datagrid.Rows(IndiceFilaSeleccionada).Cells("descrVia").Value.ToString()
        'cmbViaAdmin.Text = .Item("descrVia").ToString
        'txtCodigoFreq.Text = .Item("frecuencia").ToString
        'txtDescripcionFreq.Text = datagrid.Rows(IndiceFilaSeleccionada).Cells("descrFrecuencia").Value.ToString()
        txtTecnica.Text = datagrid.Rows(IndiceFilaSeleccionada).Cells("obs").Value.ToString()
        txtDosis.Focus()
        Me.lblDiasTrat.Visible = False
        Me.txtDiasTrat.Visible = False
        Me.flagNOPOS = False
        Me.flagCONTROL = False

        If datagrid.Rows(IndiceFilaSeleccionada).Cells("flag_pos").Value.ToString() = "N" Then  'And datosPaciente.TipoEntidad = "EPS" Then
            'MsgBox("El medicamento elegido es no POS deberá diligenciar la Justificación de Uso para CTC", MsgBoxStyle.Information)
            Me.flagNOPOS = True
            Me.lblDiasTrat.Visible = True
            Me.txtDiasTrat.Visible = True
            Me.txtDiasTrat.Text = ""
        End If





        If dtaux = datagrid.Name Then
            If datagrid.Rows(IndiceFilaSeleccionada).Cells("MedControl").Value.ToString() = "S" Then
                Me.flagCONTROL = True
                Me.GroupCnt24.Visible = True
                Me.GroupCnt24.Enabled = True
                Me.txtCantidadC.Enabled = True
                Me.lblCantLetras.Enabled = True
                Me.lblCantidadC.Enabled = True
                txtCantidadC.Text = String.Empty
                txtCantidadLetras.Text = String.Empty
            End If
        End If

        If dtaux2 = datagrid.Name Then
            If datagrid.Rows(IndiceFilaSeleccionada).Cells("MedControl1").Value.ToString() = "S" Then
                Me.flagCONTROL = True
                Me.GroupCnt24.Visible = True
                Me.GroupCnt24.Enabled = True
                Me.txtCantidadC.Enabled = True
                Me.lblCantLetras.Enabled = True
                Me.lblCantidadC.Enabled = True
                txtCantidadC.Text = String.Empty
                txtCantidadLetras.Text = String.Empty
            End If
        End If


    End Sub



End Class
