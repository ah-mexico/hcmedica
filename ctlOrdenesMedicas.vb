Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.BL '    'Capa de negocio
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.Util
Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes.ExcepcionesProd
Imports System.Collections.Generic
Imports System.Data.Common
' agfa_orm_in
Imports objGenerales = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports System.Management

Imports System.Windows.Forms
Imports System.Drawing
Imports HistoriaClinica.Mail
Imports System.Net.Mail
Imports System.IO
Imports System.Math
Imports System.ComponentModel
Imports System.Linq
Imports HistoriaClinica.Sophia.HistoriaClinica.HistoriaBasica

''' <summary>0
''' Control que implementa toda la funcionalidad requerida en la 
''' realizacion de las ordenes medicas. Este control implementa la
''' parte visual y consume la logica de negocio de la clase BLOrdenes
''' </summary>
''' <remarks></remarks>
Public Class ctlOrdenesMedicas

    ''' <summary>
    ''' Datos del paciente al cual se le van a realizar 
    ''' las ordenes medicas. Paciente es un singleton que 
    ''' es creado cuando se abre la historia clinica y puede 
    ''' ser utilizado en cualquier lugar de la aplicacion.
    ''' </summary>
    ''' <remarks></remarks>
    Private datosPaciente As Paciente
    Private Shared _Instancia As ctlOrdenesMedicas
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
    Public datosSinAlmacenar As Boolean = False
    Public datosSinAlmacenarDieta As Boolean = False

    Private objDao As New DAOGeneral

    ' <summary>
    ' Determina si los datos que han sido ingresados han sido almacenados
    'correctamente.
    ' </summary>
    ' <value></value>
    ' <returns>True si no existen datos por almacenar.</returns>
    ' <remarks></remarks>
    ' Private PageCount As Integer
    Private NroOrdenOrigen As Double ''Jimmy Leandro Guevara 2017/09/19 triage avanzado
    Private maxRec As Integer
    Private pageSize As Integer
    Private currentPage As Integer
    Private recNo As Integer
    Private PageCount As Integer
    'Private dtSource As DataTable
    Public strDescripcion As String = ""
    Private Ivalidacc As Integer = 0
    Public intload As Integer = 0
    Private strCentroCostoOrigen As String = ""
    Private dsAislamiento As DataSet
    Private m_validado As Boolean = True
    Private ErrorModulo As String
    'Req. ER_OSI_584(eloaiza@intergrupo.com )
    Public ctlPaciente As ctlDatosPaciente
    Public ctlHistoria As HCBasica
    Public flagNOPOS As Boolean = False
    Public flagCONTROL As Boolean = False
    Private objCeldaActual As String
    Public valorContinuar As Object 'String = String.Empty
    Public valorModificar As String = String.Empty
    Public valorSuspender As Object ' = String.Empty
    '.....................................Verdadero, Falso 
    Public valoresContinuar As String() = {"C", "S"}
    Public valoresModificar As String() = {"M", "N"}
    Public valoresSuspender As String() = {"S", "C"}
    Public falg_modificar As Integer = 0

    Dim strJustificaSinConvenio As String = ""
    Public strRta As String = "Aceptar" 'CCGUTIEREZ. 25/06/2020. Pyxis - ALM_111
    Dim InicioSesion As DateTime
    Public ctlconcimedicamentos As ctlConcilMedicamentos


    Public Enum FormatReport As Integer
        pdf = 0
        image = 1
        excel = 2
    End Enum

    Public ReadOnly Property existenDatosSinAlmacenar() As Boolean
        Get
            Return Me.datosSinAlmacenar
        End Get
    End Property



#Region "Instancia de Control"
    Public Shared ReadOnly Property Instancia() As ctlOrdenesMedicas
        Get
            If _Instancia Is Nothing Then
                _Instancia = New ctlOrdenesMedicas
            End If
            Return _Instancia
        End Get
    End Property
#End Region
    'Me.Parent.Parent.Controls("pnlContenedorDatosPaciente")

#Region "Generales"

    ''' <summary>
    ''' Procedimiento que carga la informacion inicial como el paciente, 
    ''' los datos generales y los datos de la conexion. Ademas se llenan 
    ''' varios combos como los tipos de dietas, la unidad de medida etc.
    ''' Se cargan las grillas con la informacion de las ordenes que existen
    ''' para la historia clinica actual.
    ''' En general inicializacion y configuracion general.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ctlOrdenesMedicas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        panelConcilMedicamentos1.Visible = False
        Me.panelConcilMedicamentos1.Visible = False



        Me.panelMedica.Visible = True
        Me.panelProce.Visible = True
        Me.Panel4.Visible = True
        Me.Panel5.Visible = True
        Me.panelGeneral.Visible = True
        Me.Panel1.Visible = True
        Mostrar()



    End Sub

    Public Sub Mostrar()
        Dim sControl As ctlOrdenesMedicas

        Me.Cmbtiempo.Text = ""
        '  Cmbtiempo.SelectedValue = Nothing
        Cmbtiempo.Text = Nothing
        sControl = ctlOrdenesMedicas.Instancia
        'sControl = Me.pnlContenedorPantallas.Controls("pnlContenedorDatos").Controls("ctlOrdenesMedicas")
        sControl.AutoScrollPosition = New Point(0, 0)
        Cmbtiempo.ResetText()
        frmHistoriaPrincipal.blnFirstOrdenesMedicas = False
        intload = 0
        datosLogin = Generales.Instancia()
        datosPaciente = Paciente.Instancia()
        datosConexion = Conexion.Instancia()
        _Ordenes = OrdenMedica.Instancia()
        ctlconcimedicamentos = ctlConcilMedicamentos.Instancia()

        If ctlconcimedicamentos._MedicamentosConcil IsNot Nothing Then
            ctlconcimedicamentos.ActualizarGrilla()
        End If

        ' Validar existencia de historia básica - Eloaiza@intergrupo.com - 18-11-2019
        If ValidarDatosHisBasica() Then
            Exit Sub
        End If

        Ivalidacc = 0
        InicializaValorControles()
        cargaTiposDieta()
        'cargaOrdenes() ''Claudia Garay Julio 19 de 2010
        configurarComboMedicamentos()
        configurarComboProcedimientos()
        configurarComboIndicaciones()
        CargarUnidadMedida()
        CargarViasAdministracion()
        CargarFrecuencia()
        cargarGrillas()
        ''martovar ER_OSI_596_Indicaciones_Medicas 2017/09/25
        CargarTiempo()
        inicializaVariables()
        txtTipDieta.Focus()

        InhabilitarSegunPais()

        ' agfa_orm_in 2014/10/24  
        cargarDiagnosticos()
        Me.GroupBox2.Enabled = True
        'martovar sostenibilidad 
        Me.txtcada.Text = ""
        Me.Cmbtiempo.Text = ""
        Me.txtcc.Enabled = False
        'Dim objDatosHisBasica As DatosHistoriaBasica = DatosHistoriaBasica.Instancia
        Me.InicioSesion = FuncionesGenerales.FechaServidor()

    End Sub

    ''' <summary>
    ''' Inicializa las variables que controlan el tamaño del XML 
    ''' que se envia al stored procedure que guarda la orden.
    ''' Se inicializa con el tamaño del encabezado principal
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub inicializaVariables()
        _tamanoXmlDietas = 57
        _tamanoXmlMedica = 57
        _tamanoXmlProcedim = 0
        _tamanoXmlOGeneral = 57
        datosSinAlmacenar = False
        datosSinAlmacenarDieta = False
    End Sub

    ''' <summary>
    ''' Procedimiento que carga en las grillas (Dietas, Medicamentos y
    ''' Ordenes Generales) la informacion de las ordenes generales 
    ''' existentes para la admision. Si el objeto _Ordenes no ha sido 
    ''' cargado se hace una consulta a la base de datos para cargar el 
    ''' objeto. Se relaciona cada grilla con un dataTable determinado 
    ''' que se encuentra en el objeto _Ordenes.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub cargarGrillas()

        datosSinAlmacenar = False
        datosSinAlmacenarDieta = False
        If _Ordenes.Estado = "N" Then  ''No ha sido cargado el objeto, primera carga del control 
            Try
                _Ordenes.TablasOrdenes = BLOrdenes.consultarOrdenes(datosConexion, datosLogin.Prestador, datosLogin.Sucursal,
                                      datosPaciente.TipoAdmision, datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision)

                _Ordenes.TablasOrdenes.AcceptChanges()
                _Ordenes.Estado = "M"  ''Marca el objeto para decir que ya fue cargado o modificado
            Catch ex As Exception
                MsgBox("Error en la consulta de las dietas. " & ex.Message, MsgBoxStyle.Information)
                Exit Sub
            End Try
        End If

        ''Carga la grilla de Aislamiento
        configurarGrillaAislamiento(_Ordenes.TablasOrdenes.Tables("AISLAMIENTO"))
        ''Carga la grilla de Dietas 
        configurarGrillaDietas(_Ordenes.TablasOrdenes.Tables("DIETAS"))
        ''Carga la grilla de Medicamentos 
        configurarGrillaMedicamentos(_Ordenes.TablasOrdenes.Tables("MEDICAMENTOS"))
        ''Configura la grilla de Procedimientos
        configurarGrillaProcedimientos()
        ''Carga la grilla de Ordenes Generales 
        configurarGrillaGenerales(_Ordenes.TablasOrdenes.Tables("ORDENGENERAL"))

        If _Ordenes.Estado <> "N" Then
            ActualizarGrillaAislamiento(m_validado)
        End If

    End Sub

    ''' <remarks></remarks>
    ''' agfa_orm_in 2014/10/28
    Public Sub cargarDiagnosticos()
        Try

            Dim diagnosticos As List(Of HistoriaClinica.Sophia.HistoriaClinica.Reportes.Diagnostico)
            Dim g_strDX As String

            Dim i As Integer

            diagnosticos = New HistoriaClinica.Sophia.HistoriaClinica.Reportes.Diagnostico().consultaDiagnosticos(datosConexion, datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.TipoAdmision,
                                      datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision, datosLogin.Login, "I")


            g_strDX = ""
            For i = 0 To diagnosticos.Count - 1
                g_strDX = g_strDX & " " & diagnosticos.Item(i).DescripDiagnostico & ";"
            Next

            diagnosticos = New HistoriaClinica.Sophia.HistoriaClinica.Reportes.Diagnostico().consultaDiagnosticos(datosConexion, datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.TipoAdmision,
                                      datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision, datosLogin.Login, "E")

            For i = 0 To diagnosticos.Count - 1
                g_strDX = g_strDX & " " & diagnosticos.Item(i).DescripDiagnostico & ";"
            Next

            Me.tb_Justi.Text = g_strDX


        Catch ex As Exception
            MsgBox("Error en la consulta de los diagnosticos. " & ex.Message, MsgBoxStyle.Information)
            Exit Sub
        End Try



    End Sub
    ''' <summary>
    ''' Limpia los controles que se encuantran dentro del panel 
    ''' que es pasado como parametro, exeptuando un control pasado como parametro.
    ''' </summary>
    ''' <param name="objPanel">Panel que contiene los controles a ser limpiados</param>
    ''' <param name="ctrlExcept">Control que no se limpiara.</param>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' Evento que almacena en la base de datos la informacion que ha sido 
    ''' modificada o adicionada en las grillas correspondientes a las dietas
    ''' medicamentos, procedimientos y ordenes generales. 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click


        Me.guardarDatosOrdenesMedicas()
        Me.ActualizarGrillaAislamiento(m_validado)

        Me.RadioButton2.Checked = False
        Me.RadioButton1.Checked = False
        Me.txtcc.Enabled = False

        Dim alarmaRiesgo As ctlDatosPaciente
        alarmaRiesgo = ctlDatosPaciente.Instancia
        alarmaRiesgo.PrenderAlarmasPac()

        'prueba para el nuevo compilador
    End Sub

    Public Sub PasaraConciliacionMedicamentos()
        panelConcilMedicamentos1.Visible = True

        panelMedica.Visible = False
        Me.panelProce.Visible = False
        Me.Panel4.Visible = False
        Me.Panel5.Visible = False
        Me.panelGeneral.Visible = False
        Me.Panel1.Visible = False
        ''   ctlDescrQx.Visible = False
        'pnlContenedor.Height = 1500
        panelConcilMedicamentos1.Controls.Add(ctlconcimedicamentos)
        panelConcilMedicamentos1.Show()

        ctlconcimedicamentos.Show()
        'pnlContEvolucion.Visible = True
        ctlconcimedicamentos.Visible = True
    End Sub


    ''' <summary>
    ''' Almacena los cambios realizados en el control de ordenes medicas.
    ''' </summary>
    ''' <remarks></remarks>
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
        Dim dtDatos As DataTable = dtgMedicamentos.DataSource
        Dim dtDatosRespaldo As New DataTable
        dtDatosRespaldo = dtgMedicamentos.DataSource

        Dim RegistrosProcesar As Integer
        RegistrosProcesar = dtgMedicamentos.Rows.Count



        Dim regmodificado As Boolean


        For aux As Integer = 0 To RegistrosProcesar - 1
            For Each fila As DataGridViewRow In dtgMedicamentos.Rows
                If fila.Cells("Modificar_med").FormattedValue = False And
               fila.Cells("Suspender_med").FormattedValue = False And
               fila.Cells("continuar_med").FormattedValue = False And
               fila.Cells("conciliacion").FormattedValue <> "S" And
               fila.Cells("NroOrden").FormattedValue <> "0" Then
                    regmodificado = True

                End If
            Next
            dtgMedicamentos.DataSource = dtDatos
        Next

        If regmodificado Then
            MessageBox.Show("Usted no ha realizado la Conciliación de medicamentos. Debe realizarla para continuar.", "Ordenes Medicas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            PasaraConciliacionMedicamentos()
            Exit Sub
        End If



        For aux As Integer = 0 To RegistrosProcesar - 1
            For Each fila As DataGridViewRow In dtgMedicamentos.Rows
                If fila.Cells("NroOrden").FormattedValue <> "0" Then

                    If fila.Cells("Modificar_med").FormattedValue = False And
               fila.Cells("Suspender_med").FormattedValue = False And
               fila.Cells("continuar_med").FormattedValue = False And
               fila.Cells("NroOrden").FormattedValue <> "0" Then

                        idfila = fila.Index
                        dtDatos.Rows.RemoveAt(idfila)

                    End If
                End If


            Next
            dtgMedicamentos.DataSource = dtDatos
        Next






        If oEvolucion.ValidaEspDietaAislamiento(datosConexion, 0, datosLogin.CodigoEspecialidad) Then

            'se comentarea control de cambios de dietas 
            If dtgDietas.RowCount = 0 And (datosPaciente.TipoAdmision = "A" Or datosPaciente.TipoAdmision = "H") Then
                MessageBox.Show("Pendiente prescripción de Dieta.", "Ordenes Medicas", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Panel2.Focus()
                m_validado = False
                Exit Sub
            End If

            '''martovar requerimiento 593 Modificacion Funcionalidad de Dietas. 29/08/2017
            If (Not Me.datosSinAlmacenarDieta) And dtgDietas.RowCount <> 0 And (datosPaciente.TipoAdmision = "U") Then
                If BLOrdenes.ValidarDieta24Horas1(dtgDietas(2, 0).Value.ToString) Then
                    MessageBox.Show("Pendiente prescripción de Dieta.", "Ordenes Medicas", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Panel2.Focus()
                    m_validado = False
                    Exit Sub
                End If
            End If

            '''martovar requerimiento 593 Modificacion Funcionalidad de Dietas. 29/08/2017
            If (Not Me.datosSinAlmacenarDieta) And (datosPaciente.TipoAdmision = "A" Or datosPaciente.TipoAdmision = "H") Then
                If BLOrdenes.ValidarDieta24Horas1(dtgDietas(2, 0).Value.ToString) Then
                    MessageBox.Show("Pendiente prescripción de Dieta.", "Ordenes Medicas", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Panel2.Focus()
                    m_validado = False
                    Exit Sub
                End If
            End If

            If falg_modificar = 1 Then
                MessageBox.Show("Para poder realizar esta acción debe desmarcar el check box modificar.", "Ordenes Medicas", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            If Not validaGuardarAislamientos() Then
                MessageBox.Show("Pendiente prescripción de Aislamientos.", "Ordenes Medicas", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Panel6.Focus()
                m_validado = False
                Exit Sub
            End If

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

            btnGuardar.Enabled = False ' herojas honorario variable 2015/03/17 para que no permita duplicar las ordenes
            If Me.op_TipoServ.Checked = True Then
                strTipoServicio = "1" ' Posterios a la Urgencia
                strPrioridad = ""     ' Electiva
            Else
                strTipoServicio = "2"
                If Me.op_PrioSI.Checked = True Then
                    strPrioridad = "1" ' Prioritaria
                Else
                    strPrioridad = "2" ' No Prioritaria
                End If
            End If

            Dim ResultadoSesion As String
            Try
                ResultadoSesion = BLOrdenes.Consultausuariosseccion(datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.TipoAdmision,
                                              datosPaciente.NumeroAdmision, datosPaciente.AnoAdmision, "OM", InicioSesion)

                If ResultadoSesion = "S" Then
                    MessageBox.Show("Las ordenes médicas acaban de ser gestionadas por otro usuario.  Debe volver a prescribir.", "Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LimpiarDatos()
                    _Ordenes.Estado = "N"
                    Mostrar()
                    falg_modificar = 0
                    Me.btnGuardar.Enabled = True
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
                    Dim tabla As DataTable = dtgMedicamentos.DataSource
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
                    Dim dtMedica As DataTable = dtgMedicamentos.DataSource
                    Dim resultados As DataRow() = dtMedica.Select("idRegistro = 'N'")
                    For Each fila As DataRow In resultados
                        fila("idRegistro") = ""
                    Next


                    lError = BLOrdenes.guardarOrdenes(datosConexion, datosLogin.Prestador, datosLogin.Sucursal,
                                                                    datosPaciente.TipoAdmision, datosPaciente.NumeroAdmision,
                                                                    datosPaciente.AnoAdmision, datosLogin.Login, datosLogin.Login,
                                                                    datosLogin.CodigoEspecialidad, datosPaciente.Entidad,
                                                                    dtgAislamiento.DataSource, dtgDietas.DataSource, dtgMedicamentos.DataSource,
                                                                    dtgProcedimientos.DataSource, dtgGenerales.DataSource,
                                                                    dtDatosPaciente, NroOrden, fechaOrden, strCodCentroCostoOrigen, Me.tb_Guia.Text,
                                                                    Me.tb_Justi.Text, strTipoServicio, strPrioridad, txtCodProcedim.Text, cmbDescripProcedim.Text,
                                                                    InicioSesion, strPracticaosi)
                    '' Jimmy Leandro guevara 2017/09/19 triage avanzado (intergrupo)
                    NroOrdenOrigen = NroOrden


                    'Inicio EROSI584 Grabar sesion usuario OM Raul Cruz 
                    Try
                        ResultadoGrabar = BLOrdenes.GrabarLogUsuario(datosLogin.Prestador, datosLogin.Sucursal,
                                                                    datosPaciente.TipoAdmision, datosPaciente.NumeroAdmision,
                                                                    datosPaciente.AnoAdmision, "OM", InicioSesion, datosLogin.Login, "")
                        'ocurrio un error al grabar  el log de usuario
                        If ResultadoGrabar > 0 Then
                            MessageBox.Show("Error " + ResultadoGrabar.ToString + " al grabar el log se usuario de sesión", "Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Error " + ex.Message)
                    End Try
                    'Fin EROSI584 Grabar sesion usuario OM Raul Cruz 

                    'rmzaldua  2020-09-29 inicio

                    strCodCentroCostoOrigen = obj.consultarCCOrigen(datosConexion, datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.TipoAdmision, datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision, datosPaciente.Entidad)

                    strMarcaCentroCostoOrigen = obj.consultarMarcaccostopedidoPyxis(datosConexion, datosLogin.Prestador, datosLogin.Sucursal, strCodCentroCostoOrigen, datosPaciente.TipoAdmision, datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision)

                    'Invocar al servicio pyxis
                    If Not IsNothing(dtDatosPaciente) And strMarcaCentroCostoOrigen = "S" Then
                        InvocacionInterfacePyxis(dtDatosPaciente, dtgMedicamentos.DataSource, NroOrden, strCodCentroCostoOrigen)
                    End If
                    'fin rmzaldua
                    If NroOrdenOrigen > 0 Then

                        If dtgProcedimientos.RowCount > 0 Then

                            Dim dtProcedimientos As DataTable

                            Dim dtRespuestaOrden As New DataTable

                            homologacion = BLOrdenes.ConsultarHomologacion(datosLogin.Prestador, datosLogin.Sucursal)

                            If homologacion IsNot Nothing And homologacion.Rows.Count > 0 Then
                                If Convert.ToBoolean(homologacion.Rows(0)("Estado")) = True Then

                                    linkedServer = BLOrdenes.ConsultarLinkedServer(Convert.ToInt32(homologacion.Rows(0)("Id_Localizacion_Destino").ToString()))
                                    dtProcedimientos = BLOrdenes.ConsultarProcedimientoPorCodigo(dtgProcedimientos.DataSource, linkedServer, homologacion.Rows(0)("cod_pre_sgs_destino").ToString(), homologacion.Rows(0)("cod_sucur_destino").ToString())

                                    If dtProcedimientos.Rows.Count > 0 Then
                                        dtRespuestaAdm = GuardarAdmisionHomologada(linkedServer, Convert.ToInt32(homologacion.Rows(0)("Id_Localizacion_Destino").ToString()), dtProcedimientos, homologacion.Rows(0)("cod_pre_sgs_destino").ToString(), homologacion.Rows(0)("cod_sucur_destino").ToString())



                                        If dtRespuestaAdm.Rows.Count Then

                                            Loghomologacion = BLOrdenes.guardarOrdenesHomologada(datosConexion, linkedServer, homologacion.Rows(0)("cod_pre_sgs_destino").ToString(), homologacion.Rows(0)("cod_sucur_destino").ToString(),
                                                                                datosPaciente.TipoAdmision, dtRespuestaAdm.Rows(0)("NumeroAdmisionDestino"),
                                                                                Date.Now.Year.ToString(), datosLogin.Login, datosLogin.Login,
                                                                                datosLogin.CodigoEspecialidad, datosPaciente.Entidad,
                                                                                dtgAislamiento.DataSource, dtgDietas.DataSource, dtgMedicamentos.DataSource,
                                                                                dtgProcedimientos.DataSource, dtgGenerales.DataSource,
                                                                                0, fechaOrden, strCodCentroCostoOrigen, Me.tb_Guia.Text,
                                                                                Me.tb_Justi.Text, strTipoServicio, strPrioridad, txtCodProcedim.Text, cmbDescripProcedim.Text, strPracticaosi)


                                        End If
                                        GuardarLogOrdenHomologada(dtRespuestaAdm, Loghomologacion, NroOrdenOrigen, linkedServer, homologacion)
                                    End If
                                End If
                            End If
                        End If
                    End If
                    ''' Fin Jimmy Leandro guevara 2017/09/19 triage avanzado (intergrupo)
                    Me.datosSinAlmacenar = False

                Catch ex As Exception
                    MsgBox("Error en el proceso de grabación. Ingrese nuevamente la información " & ex.Message, MsgBoxStyle.Information)
                    BLOrdenes.GrabarErroresOrdenesMedicas("HistoriaMedic a" & ex.Message)
                    Me.datosSinAlmacenar = True
                    btnGuardar.Enabled = True ' herojas honorario variable 2015/03/17 para que no permita duplicar las ordenes
                    ErroresHC(ex.Source & " - " & Environment.MachineName.ToString & " - " & ErrorModulo, ex.Message, ex.StackTrace & " - " & ex.TargetSite.ToString)
                    'Exit Sub
                End Try



                ''Manejo del error
                If lError <> 0 Then
                    If lError = 7 Then
                        Try
                            ResultadoSesion = BLOrdenes.Consultausuariosseccion(datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.TipoAdmision,
                                                          datosPaciente.NumeroAdmision, datosPaciente.AnoAdmision, "OM", InicioSesion)

                            If ResultadoSesion = "S" Then
                                MessageBox.Show("Las ordenes médicas acaban de ser gestionadas por otro usuario.  Debe volver a prescribir.", "Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                LimpiarDatos()
                                _Ordenes.Estado = "N"
                                Mostrar()
                                falg_modificar = 0
                                Me.btnGuardar.Enabled = True
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
                            _Ordenes.Estado = "N"
                            Mostrar()

                        End If
                        MsgBox("No existen datos para guardar.", MsgBoxStyle.Information)
                    Else
                        MsgBox("Error en el proceso de grabación." & lError, MsgBoxStyle.Information)
                    End If
                    btnGuardar.Enabled = True ' herojas honorario variable 2015/03/17 para que no permita duplicar las ordenes
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
                    If MedControl > 0 Then
                        imprimirOrdenMedica(NroOrden, strDescripCentroCosto, strPracticaosi, True)
                    Else

                        imprimirOrdenMedica(NroOrden, strDescripCentroCosto, strPracticaosi, False)
                    End If

                    ''Fin
                    ''cdquiroga se adiciona control para visualizar medicamentos controlados


                    ' ''Ctc's Medicamentos Claudia Garay Marzo 27 de 2012
                    Dim dtMedica As New DataTable

                    dtMedica = dtgMedicamentos.DataSource

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

                        btnGuardar.Enabled = True ' herojas honorario variable 2015/03/17 para que no permita duplicar las ordenes

                    Catch ex As Exception
                        MsgBox(ex.Message)
                        btnGuardar.Enabled = True ' herojas honorario variable 2015/03/17 para que no permita duplicar las ordenes
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

                    ''Se actualiza el flag que indica si se realizo alguna 
                    ''modificacion en la historia clinica. 
                    datosLogin.HistoriaClinicaTieneModificaciones = True

                    LimpiarPanel(Me.panelProce1, Me.btnAdicionarProcedim)
                    InhabilitarSegunPais()
                    Me.tb_Guia.Enabled = True
                    Me.tb_Justi.Enabled = True
                    Me.GroupServi.Enabled = True
                    ''Se inicializan las variables globales tales como 
                    ''los tamaños de los xml
                    inicializaVariables()
                    'agfa_orm_in 2014/10/30
                    cargarDiagnosticos()
                    strJustificaSinConvenio = "" ' Honorario variable 2015/03/17
                    Me.datosSinAlmacenar = False

                End If

            Catch ex As Exception













                MsgBox("Error en el proceso de impresión" & ex.Message, MsgBoxStyle.Information)
                BLOrdenes.GrabarErroresOrdenesMedicas("HistoriaMedica" & ex.Message)
                Me.datosSinAlmacenar = True
                btnGuardar.Enabled = True ' herojas honorario variable 2015/03/17 para que no permita duplicar las ordenes
                ErroresHC(ex.Source & " - " & Environment.MachineName.ToString & " - " & ErrorModulo, ex.Message, ex.StackTrace & " - " & ex.TargetSite.ToString)

            End Try
        End If
        'txtCodMedica.Enabled = True
        cmbDescripMedica.Enabled = True

        _Ordenes.Estado = "N"


        If ctlconcimedicamentos._MedicamentosConcil IsNot Nothing Then
            ctlconcimedicamentos.ActualizarGrilla()
        End If

        Mostrar()

        'InicializaValorControles()
        'cargarGrillas()

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

    ''' <summary>
    ''' Procedimiento que imprime el reporte de una orden medica especifica
    ''' </summary>
    ''' <param name="NroOrden">Numero de la orden a imprimir</param>
    ''' <param name="strCentroCostoOrigen">Centro de costo origen con el que se grabo el pedido de procedimientos</param>
    ''' <remarks></remarks>
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

#Region "Impresion de formula de procedimientos pdf"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="codPrestador">Codigo prestador</param>
    ''' <param name="codSucursal">Codigo sucursal</param>
    ''' <param name="tipAdmin">Tipo Admision</param>
    ''' <param name="iAno">Año de admision</param>
    ''' <param name="lNumAdm">Numero de admision</param>s
    ''' <param name="dConProcedim">Procedimiento</param>
    ''' <remarks></remarks>
    Public Sub ImprimirProcedim(ByVal codPrestador As String, ByVal codSucursal As String,
                                            ByVal tipAdmin As String, ByVal iAno As Long,
                                            ByVal lNumAdm As Long, ByVal dConProcedim As Long, ByVal FlagConsulta As Long)

        Dim visorRptFormula As New FrmRepFomulaProcedimtPDF(codPrestador, codSucursal, tipAdmin,
                                                        iAno, lNumAdm, dConProcedim, FlagConsulta)


        If (visorRptFormula.reportInfo Is Nothing) Then
            'jlalfonso-2009-07-07
            'se retira mensaje por procedimientos que no requieren autorizacion y no generan PDF
            'solicitado por eforero.
            'MessageBox.Show("No existe información para generar el reporte", _
            '                           "Historia Clinica", MessageBoxButtons.OK, MessageBoxIcon.Error)

        ElseIf (visorRptFormula.reportInfo.emailDestinatario Is Nothing Or visorRptFormula.reportInfo.emailDestinatario = "") Then
            MessageBox.Show("No existe una direccion de correo de la entidad del afiliado : " & visorRptFormula.reportInfo.pagador,
                            "Historia Clinica", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            visorRptFormula.WindowState = FormWindowState.Maximized
            ''visorRptFormula.ShowDialog(Me.ParentForm)
            visorRptFormula.Visible = True
        Else
            ''Se hace visible el formulario para crear completamente los objetos.
            visorRptFormula.Visible = True
            ''Se obtienen los bytes del reporte generado en pdf
            Dim rptBytes As Byte() = visorRptFormula.getReportBytes(FrmRepFomulaProcedimtPDF.FormatReport.pdf)

            ''Se hace invisible el reporte
            visorRptFormula.Visible = False

            ''Se envia el reporte via correo electronico 
            ''herojas version 2.9.0 corregido error en el envio del correo
            'If (Me.sendFormulaByMail(visorRptFormula.reportInfo.emailDestinatario, rptBytes, _
            '                        "autoriza_servicios_salud.pdf", "mailbog.colsanitas.com", "application/pdf", "Solicitud Autorización de Servicios de Salud")) Then
            If (Me.sendFormulaByMail(visorRptFormula.reportInfo.emailDestinatario, rptBytes, "Solicitud Autorización de Servicios de Salud autoriza_servicios_salud.pdf", "smtp.gmail.com", "application/pdf", "Solicitud Autorización de Servicios de Salud")) Then
                '    visorRptFormula.Dispose()
                ''MsgBox("El reporte de solicitud de servicios ha sido enviado sin inconvenientes", MsgBoxStyle.Information, "Historia Clinica")
                MessageBox.Show("El reporte de solicitud de servicios ha sido enviado sin inconvenientes", "Historia Clinica", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dim visorRptFormula1 As New FrmRepFomulaProcedimtPDF(codPrestador, codSucursal, tipAdmin,
                                                   iAno, lNumAdm, dConProcedim, FlagConsulta)

                visorRptFormula1.WindowState = FormWindowState.Maximized
                ''visorRptFormula.ShowDialog(Me.ParentForm)
                visorRptFormula1.Visible = True
            Else
                visorRptFormula.Dispose()
                MessageBox.Show("El reporte de solicitud de servicios no ha podido ser enviado", "Historia Clinica", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        End If
    End Sub

    ''' <summary>
    ''' Envia un correo electronico con el reporte generado, en PDF
    ''' </summary>
    ''' <param name="emalDestino">Direccion de correo de destino</param>
    ''' <param name="reportBytes">Bytes del reporte a enviar</param>
    ''' <param name="reportName">Nombre del reporte</param>
    ''' <param name="smtpServer">Nombre del servidor smtp</param>
    ''' <param name="rptContentType">Tipo del contenido, definicion del tipo de reporte</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
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
#End Region


    ''' <summary>
    ''' Procedimiento que actualiza los datos de la grillas de acuerdo 
    ''' a lo que fue grabado en la base de datos. Por ejemplo se le asigna
    ''' a cada registro el numero de pedido y la fecha que devuelve el 
    ''' stored procedure.
    ''' Tambien se borra de las grillas los registro suspendidos o mejor 
    ''' los registros con estado inactivo.
    ''' </summary>
    ''' <param name="NuevoNroOrden">Numero de orden que fue devuelta por el stored procedure que guarda</param>
    ''' <param name="fechaOrden">Fecha en la que fue guardada la orden</param>
    ''' <remarks></remarks>
    Private Sub actualizarGrillas(ByVal NuevoNroOrden As Double, ByVal fechaOrden As Date)

        Dim dtProce As DataTable

        ''''''GRILLA DIETA 
        actualizarNroOrden(dtgDietas.DataSource, NuevoNroOrden, DataViewRowState.Added)
        actualizarNroOrden(dtgDietas.DataSource, NuevoNroOrden, DataViewRowState.ModifiedCurrent)
        actualizarFechaOrden(dtgDietas.DataSource, fechaOrden, DataViewRowState.Added)
        actualizarFechaOrden(dtgDietas.DataSource, fechaOrden, DataViewRowState.ModifiedCurrent)
        borrarFilasInactivas(dtgDietas.DataSource)
        For Each rowItem As DataGridViewRow In Me.dtgDietas.Rows
            rowItem.Cells("SUSPENDER").Value = Nothing
            rowItem.Cells("CONTINUAR").Value = Nothing
        Next


        ''''''GRILLA MEDICAMENTOS
        actualizarNroOrden(dtgMedicamentos.DataSource, NuevoNroOrden, DataViewRowState.Added)
        actualizarNroOrden(dtgMedicamentos.DataSource, NuevoNroOrden, DataViewRowState.ModifiedCurrent)
        actualizarFechaOrden(dtgMedicamentos.DataSource, fechaOrden, DataViewRowState.Added)
        actualizarFechaOrden(dtgMedicamentos.DataSource, fechaOrden, DataViewRowState.ModifiedCurrent)
        borrarFilasInactivas(dtgMedicamentos.DataSource)
        For Each rowItem As DataGridViewRow In Me.dtgMedicamentos.Rows
            rowItem.Cells("SUSPENDER_MED").Value = Nothing
            rowItem.Cells("CONTINUAR_MED").Value = Nothing
            rowItem.Cells("modificar_med").Value = Nothing

        Next

        ''''''GRILLA PROCEDIMIENTOS
        dtProce = dtgProcedimientos.DataSource
        dtProce.Clear()

        ''''''GRILLA ORDENES GENERALES
        actualizarNroOrden(dtgGenerales.DataSource, NuevoNroOrden, DataViewRowState.Added)
        actualizarNroOrden(dtgGenerales.DataSource, NuevoNroOrden, DataViewRowState.ModifiedCurrent)
        actualizarFechaOrden(dtgGenerales.DataSource, fechaOrden, DataViewRowState.Added)
        actualizarFechaOrden(dtgGenerales.DataSource, fechaOrden, DataViewRowState.ModifiedCurrent)
        borrarFilasInactivas(dtgGenerales.DataSource)
        For Each rowItem As DataGridViewRow In Me.dtgGenerales.Rows
            rowItem.Cells("suspender_gen").Value = Nothing
            rowItem.Cells("CONTINUAR_GEN").Value = Nothing

        Next

        _Ordenes.TablasOrdenes.AcceptChanges()
    End Sub

    ''' <summary>
    ''' Actualiza el numero de orden en cada registro de acuerdo a un 
    ''' fitro (filas modificadas, filas nuevas, todas las filas etc)
    ''' </summary>
    ''' <param name="dtDatos">DataTable que contiene la informacion a actualizar</param>
    ''' <param name="NroOrden">Numero de orden generada por el proceso de grabacion</param>
    ''' <param name="filtro">Filtro para actualizar (filas modificadas, filas nuevas, todas las filas etc)</param>
    ''' <remarks></remarks>
    Private Sub actualizarNroOrden(ByVal dtDatos As DataTable, ByVal NroOrden As Double, ByVal filtro As DataViewRowState)
        Dim rows() As DataRow
        Dim row As DataRow

        rows = dtDatos.Select("", "", filtro)

        For Each row In rows
            row.BeginEdit()
            row.Item("NroOrden") = NroOrden
            row.EndEdit()
        Next
    End Sub

    ''' <summary>
    ''' Actualiza la fecha de grabacion en cada registro de acuerdo a un 
    ''' fitro (filas modificadas, filas nuevas, todas las filas etc)
    ''' </summary>
    ''' <param name="dtDatos">DataTable que contiene la informacion a actualizar</param>
    ''' <param name="fechaOrden">Fecha generada por el proceso de grabacion</param>
    ''' <param name="filtro">Filtro para actualizar (filas modificadas, filas nuevas, todas las filas etc)</param>
    ''' <remarks></remarks>
    Private Sub actualizarFechaOrden(ByVal dtDatos As DataTable, ByVal fechaOrden As Date, ByVal filtro As DataViewRowState)
        Dim rows() As DataRow
        Dim row As DataRow

        rows = dtDatos.Select("", "", filtro)

        For Each row In rows
            row.BeginEdit()
            row.Item("fec_con") = fechaOrden
            row.EndEdit()
        Next
    End Sub

    ''' <summary>
    ''' Borra del datatable las filas que tienen estado Inactivo
    ''' </summary>
    ''' <param name="dtDatos">DataTable que va a ser modificado</param>
    ''' <remarks></remarks>
    Public Sub borrarFilasInactivas(ByVal dtDatos As DataTable)
        Dim rows() As DataRow
        Dim row As DataRow

        rows = dtDatos.Select("estado = '" & BLOrdenes.INACTIVO & "' ")

        For Each row In rows
            row.Delete()
        Next
    End Sub

    ''' <summary>
    ''' Procedimiento que valida la tecla digitada y si un "ENTER"
    ''' pasa al proximo contro por medio de la tecla "TAB"
    ''' </summary>
    ''' <param name="MyControl"></param>
    ''' <param name="s"></param>
    ''' <remarks></remarks>
    Public Sub validaKeyPress(ByRef MyControl As Control, ByVal s As KeyPressEventArgs)
        Select Case s.KeyChar
            Case Convert.ToChar(Keys.Return)
                SendKeys.Send("{TAB}")
                s.Handled = True
        End Select
    End Sub
#End Region

#Region "Dietas"

    ''' <summary>
    ''' Maneja el evento por el cual el usuario desea adicionar un nuevo 
    ''' registro a la grilla de Dietas
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAdicionarDieta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdicionarDieta.Click

        'ALM 166 20200303 raul Cruz
        If ValidarDatosHisBasica() Then
            Exit Sub
        End If

        Dim dtDietas As DataTable
        Dim cont As Integer



        Dim drFila As DataRow
        Dim mensaje As String = ""

        If IsNothing(dtgDietas) Then
            Exit Sub
        End If


        dtDietas = dtgDietas.DataSource
        If dtDietas Is Nothing Then
            Exit Sub
        End If

        '''martovar requerimiento 593 Modificacion Funcionalidad de Dietas. 29/08/2017
        For Each row As DataRow In dtDietas.Rows
            If row("Tratamiento").ToString() = "" Then
                cont = cont + 1
            End If
        Next

        If cont >= 1 Then
            Exit Sub
        End If
        ''fin 


        ''martovar especificacion ER_OSI 593 Modificacion Funcionalidad de Dietas
        If Me.txtDescripDieta.Enabled = False And Me.txtTipDieta.Enabled = False Then
            Me.txtTipDieta.Text = "NV"
            Me.txtDescripDieta.Text = "NADA VIA ORAL"
        End If

        ''Validacion de los datos obligatorios
        If Not BLOrdenes.validarDieta(txtTipDieta.Text, txtDescripDieta.Text, dtDietas, mensaje) Then
            MsgBox(mensaje, MsgBoxStyle.Information)
            Exit Sub
        End If

        If Me.RadioButton1.Checked = False And Me.RadioButton2.Checked = False And Me.txtDescripDieta.Enabled = True And Me.txtTipDieta.Enabled = True Then
            MsgBox("No se ha especificado la Restricción Hídrica.", MsgBoxStyle.Information)
            Exit Sub
        End If

        If Me.RadioButton2.Checked = True And Me.txtcc.Text = "" Then
            MsgBox("No se ha especificado la Restricción Hídrica.", MsgBoxStyle.Information)
            Exit Sub
        End If

        ''martovar 2017/10/04 control de cambios dietas

        If dtgDietas.Rows.Count > 0 Then
            For i As Integer = 0 To dtgDietas.Rows.Count - 1
                If dtgDietas.Rows(i).Cells("dieta").Value = txtTipDieta.Text And dtgDietas.Rows(i).Cells("ResHidrica").Value = Me.txtcc.Text Then
                    ''rmzaldua 2018-03-27 se deja en comentarios el mensaje restrictivo control de cambios ER_OSI_593_Modificacion_Funcionalidad_de_Dietas.doc
                    'MsgBox("La dieta formulada, ya se encuentra prescrita.", MsgBoxStyle.Information)
                    'Exit Sub
                End If
            Next
        End If



        ''Creacion del nuevo registro en el dataTable relacionado con la grilla
        drFila = dtDietas.NewRow()
        drFila("NroOrden") = 0
        drFila("Dieta") = txtTipDieta.Text
        drFila("DescriDieta") = txtDescripDieta.Text
        drFila("Tratamiento") = Nothing '"I"
        drFila("medico") = datosLogin.Login
        drFila("NombreMedico") = datosLogin.NombreMedico
        drFila("estado") = BLOrdenes.ACTIVO
        drFila("Login") = datosLogin.Login
        drFila("Obs") = Me.txtObsDieta.Text
        drFila("Especialidad") = datosLogin.DescripcionEspecialidad
        drFila("cod_pre_sgs") = datosLogin.Prestador
        drFila("cod_sucur") = datosLogin.Sucursal
        drFila("tip_admision") = datosPaciente.TipoAdmision
        drFila("ano_adm") = datosPaciente.AnoAdmision
        drFila("num_adm") = datosPaciente.NumeroAdmision
        drFila("fec_con") = FuncionesGenerales.FechaServidor() ''Cambio especificacion ER_OSI 593
        drFila("num_adm") = datosPaciente.NumeroAdmision
        drFila("ResHidrica") = Me.txtcc.Text ''martovar requerimiento 593 Modificacion Funcionalidad de Dietas. 29/08/2017




        ''Se adiciona el registro a la grilla
        dtDietas.Rows.Add(drFila)
        dtgDietas.DataSource = dtDietas
        txtTipDieta.Focus()
        LimpiarPanel(panelDietas, Nothing)

        Dim dtDatos As DataTable = dtgDietas.DataSource

        ''martovar requerimiento 593 Modificacion Funcionalidad de Dietas. 29/08/2017
        If dtgDietas.Rows.Count > 1 Then

            BLOrdenes.actualizarEstado(dtDatos.Rows(0), BLOrdenes.SUSPENDE, "S", "N")
            For i As Integer = 0 To dtgDietas.ColumnCount - 1
                dtgDietas.Rows(0).Cells(i).Style.BackColor = Color.LightGray
            Next
        End If


        Me.datosSinAlmacenarDieta = True
        Me.datosSinAlmacenar = True

        Me.txtTipDieta.Enabled = True
        Me.txtDescripDieta.Enabled = True
        Me.GroupBox2.Enabled = True
        Me.txtcc.Enabled = True
        Me.RadioButton1.Checked = False
        Me.RadioButton2.Checked = False

    End Sub

    ''' <summary>
    ''' Carga el combo que despliega los tipos de dietas
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub cargaTiposDieta()

        If txtDescripDieta.OrigenDeDatos IsNot Nothing Then
            If txtDescripDieta.OrigenDeDatos.Rows.Count > 0 Then
                Exit Sub
            End If
        End If

        ''Configuracion del campo que maneja el codigo
        Dim dtDieta As DataTable
        With txtTipDieta
            .NombreCampoBuscado = "descripcion"
            .NombreCampoBusqueda = "tipDieta"
            .ControlTextoEnlace = txtDescripDieta
        End With

        ''Configuracion del campo que maneja la descripcion 
        With txtDescripDieta
            .NombreCampoDatos = "descripcion"
            .ControlTextoEnlace = txtTipDieta
            Try
                '.OrigenDeDatos = 
                dtDieta = BLOrdenes.consultarTiposDieta(datosConexion)
                .OrigenDeDatos = dtDieta
                .CargarDatosDescripcion()
            Catch ex As Exception
                MsgBox("Error en la consulta de los tipos de dieta. " & ex.Message, MsgBoxStyle.Information)
            End Try
        End With
    End Sub
    'Public Sub cargaOrdenes()
    '    ''Configuracion del campo que maneja el codigo
    '    With txtTipOrden
    '        .NombreCampoBuscado = "descripcion"
    '        .NombreCampoBusqueda = "Orden"
    '        .ControlTextoEnlace = TxtDescripOrden
    '    End With

    '    ''Configuracion del campo que maneja la descripcion 
    '    With TxtDescripOrden
    '        .NombreCampoDatos = "descripcion"
    '        .ControlTextoEnlace = txtTipOrden
    '        Try
    '            .OrigenDeDatos = BLOrdenes.consultarTiposOrden(datosConexion)
    '            .CargarDatosDescripcion()
    '        Catch ex As Exception
    '            MsgBox("Error en la consulta de los tipos de dieta. " & ex.Message, MsgBoxStyle.Information)
    '        End Try
    '    End With
    'End Sub

    ''' <summary>
    ''' Configuracion de la grilla de Dietas. Basicamente se configura
    ''' la visibilidad de los campos cargado en la grilla
    ''' </summary>
    ''' <param name="dtDietas">DataTable relacionado con la grilla</param>
    ''' <remarks></remarks>
    Public Sub configurarGrillaDietas(ByVal dtDietas As DataTable)
        dtDietas.Rows.Add()
        With dtgDietas
            .DataSource = dtDietas
            .Columns("NroOrden").Visible = False
            .Columns("Dieta").Visible = False
            .Columns("Tratamiento").Visible = False
            .Columns("medico").Visible = False
            .Columns("estado").Visible = False
            .Columns("login").Visible = False
            .Columns("cod_pre_sgs").Visible = False
            .Columns("cod_sucur").Visible = False
            .Columns("tip_admision").Visible = False
            .Columns("ano_adm").Visible = False
            .Columns("num_adm").Visible = False
            .Columns("Secuencia").Visible = False
            .Columns("ResHidrica").Visible = True ''martovar se agrega campo requerimiento ER_OSI_593_Modificacion_Funcionalidad_de_Dietas
            .Columns("suspender").Visible = False
        End With

        dtDietas.Rows.RemoveAt(dtDietas.Rows.Count - 1)

        '''martovar 2017/10/04 control de cambios dietas
        'If dtDietas.Rows.Count > 0 Then
        '    For i As Integer = 0 To dtDietas.Rows.Count - 1
        '        If _Ordenes.Estado = "M" And Len(dtDietas.Rows(i).Item("Tratamiento").ToString) = 0 Then
        '            'dtDietas.Rows(i).Item("Tratamiento") = "I"
        '        End If
        '    Next
        'End If



    End Sub




    ''' <summary>
    ''' Evento que controla el comportamiento de los check box "Suspender" y "Continuar"
    ''' cuando el usuario da un click en estos campos. Basicamente controla que estos 
    ''' campos sean excluyentes y ademas actualiza el estado del registro("Activo Inactivo")
    ''' de acuerdo a la eleccion.
    ''' Tambien se controla que no se pueda modificar un registro cuando el 
    ''' tamaño maximo de registros permitidos para grabar es superado 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dtgDietas_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgDietas.CellContentClick

        Dim dtDatos As DataTable = dtgDietas.DataSource
        Dim cont As Integer
        Dim val As Boolean
        Dim drFila As DataRow
        Dim var As String

        'para cuando la fila esta de color gris esta no se debe marcar el check
        If dtgDietas.Rows(0).Cells(0).Style.BackColor = Color.LightGray Then

            BLOrdenes.actualizarEstado(dtDatos.Rows(e.RowIndex), BLOrdenes.SUSPENDE, BLOrdenes.SUSPENDE, "N")

            Exit Sub
        End If

        'martovar 2018/04/09 se corrige incidencia alm 746
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        If Not BLOrdenes.puedeModificarTratamiento(dtDatos.Rows(e.RowIndex)) Then
            Exit Sub
        End If

        drFila = dtDatos.Rows(e.RowIndex)

        '''validar que no quede en check el registro
        'If Not BLOrdenes.ValidarDieta24Horas1(dtgDietas(2, e.RowIndex).Value.ToString) Then
        '    var = dtgDietas(5, e.RowIndex).Value.ToString
        '    dtgDietas.Rows(e.RowIndex).ReadOnly = True
        '    drFila.Item("tratamiento") = Nothing
        '    MsgBox("Esta orden se encuentra vigente")
        '    drFila.Item("tratamiento") = var
        '    BLOrdenes.deshacerActualizacionEstado(dtDatos.Rows(e.RowIndex))
        '    Exit Sub
        'End If
        '''termina aca


        If Not e.RowIndex = -1 Then
            ''martovar 2017/09/02 se agregan validaciones requerimiento ER_OSI_593_Modificacion_Funcionalidad_de_Dietas
            If dtgDietas.CurrentCell.ColumnIndex = dtgDietas.Columns("Continuar").Index Then '' COLUMNA CONTINUAR

                If dtgDietas.Columns(e.ColumnIndex).Name = "Continuar" And dtgDietas.CurrentCell.RowIndex = 0 And dtgDietas(5, 0).Value.ToString = "C" And dtDatos.Rows.Count = 1 Then
                    BLOrdenes.actualizarEstado(dtDatos.Rows(e.RowIndex), BLOrdenes.SUSPENDE, BLOrdenes.CONTINUA, "N")
                Else
                    If dtgDietas(5, 0).Value.ToString = "" Then
                        BLOrdenes.actualizarEstado(dtDatos.Rows(e.RowIndex), BLOrdenes.CONTINUA, BLOrdenes.INICIA, "N")
                    Else
                        If dtgDietas.Columns(e.ColumnIndex).Name = "Continuar" And dtgDietas.CurrentCell.RowIndex = 0 And dtgDietas(5, 0).Value.ToString = "S" And dtDatos.Rows.Count > 1 Then
                            BLOrdenes.actualizarEstado(dtDatos.Rows(e.RowIndex), BLOrdenes.SUSPENDE, BLOrdenes.CONTINUA, "N")
                        Else
                            BLOrdenes.actualizarEstado(dtDatos.Rows(e.RowIndex), BLOrdenes.CONTINUA, dtgDietas.CurrentCell.Value, "N")
                        End If
                    End If
                End If
                Me.datosSinAlmacenarDieta = True
                Me.datosSinAlmacenar = True
            End If


            ''fin martovar
            If dtgDietas.CurrentCell.ColumnIndex = dtgDietas.Columns("Suspender").Index Then '' COLUMNA SUSPENDER
                'If puedeAdicionarRegistroDietas(dtDatos.Rows(e.RowIndex)) Then El campo en la base de datos es text por lo que esta validacion no tiene sentido 484950-20121227 cpgaray Enero 4 2013
                BLOrdenes.actualizarEstado(dtDatos.Rows(e.RowIndex), BLOrdenes.SUSPENDE, dtgDietas.CurrentCell.Value, "N")
                Me.datosSinAlmacenarDieta = True
                Me.datosSinAlmacenar = True
                'Else
                'BLOrdenes.deshacerActualizacionEstado(dtDatos.Rows(e.RowIndex))
                'End If
            End If
        End If


    End Sub

    ''' <summary>
    ''' Maneja el evento dobleclick de los check box "Suspender" y "Continuar"
    ''' con el fin de controlar que estos campos sean excluyentes
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dtgDietas_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgDietas.CellContentDoubleClick
        dtgDietas_CellContentClick(sender, e)
    End Sub

    Private Function EstadoCheck(ByVal filaposicion As Integer) As String
        Return Me.dtgDietas.Rows(filaposicion).Cells(5).Value
    End Function


    ''' <summary>
    ''' Captura los errores en la grilla y arroja mensajes personalizados.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dtgDietas_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dtgDietas.DataError
        If e.ColumnIndex = dtgDietas.Columns("fec_con").Index Then
            MessageBox.Show("Fecha invalida. Verifique que el formato corresponda al siguiente 'dd/mm/aaaa hh:mm' ", "Dietas", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            e.Cancel = True
        End If
    End Sub

    Private Sub dtgDietas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtgDietas.KeyDown
        If e.KeyValue = 46 Then
            If dtgDietas.Rows.Count > 1 Then
                dtgDietas.Rows(0).Cells("Tratamiento").Value = "C"
                For i As Integer = 0 To dtgDietas.ColumnCount - 1
                    dtgDietas.Rows(0).Cells(i).Style.BackColor = Color.LightGray
                Next
            End If
        End If
    End Sub

    ''' <summary>
    ''' Procedimiento que maneja el evento lanzado cuando el usuario intenta
    ''' borrar una fila. Solo se pueden borrar las filas nuevas.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dtgDietas_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dtgDietas.UserDeletingRow
        'Dim rows() As DataRow
        Dim row As DataRow
        Dim dtDatos As DataTable = dtgDietas.DataSource

        e.Cancel = True
        row = dtDatos.Rows(e.Row.Index)

        If row.RowState = DataRowState.Added Then
            _tamanoXmlDietas -= BLOrdenes.tamanoFilaXmlDietas(row)
            e.Cancel = False
        End If

    End Sub

    ''' <summary>
    ''' Funcion que determina si se puede adicionar o no un registro 
    ''' a la grilla de dietas. Esto depende del tamaño del documento XML que
    ''' no puede superar los 8000 caracteres
    ''' </summary>
    ''' <param name="drFila">Fila que va a ser adicionada</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function puedeAdicionarRegistroDietas(ByVal drFila As DataRow) As Boolean
        ''Validacion del tamaño maximo que se puede pasar al 
        ''stored procedure que guarda la orden
        Dim tamano As Integer

        tamano = _tamanoXmlDietas

        If drFila.RowState <> DataRowState.Modified Then
            tamano += BLOrdenes.tamanoFilaXmlDietas(drFila)
        End If

        If tamano > 8000 Then
            MsgBox("No se puede adicionar este registro pues se excede el número maximo de registros a grabar.")
            Return False
        Else
            _tamanoXmlDietas = tamano
            Return True
        End If

    End Function

#End Region

#Region "Medicamentos"

    ''' <summary>
    ''' Carga el combo con las diferentes unidades de medida que son 
    ''' consultadas en la base de datos
    ''' Modificado: eloaiza@intergrupo.com
    ''' 10/2019
    ''' Req. ER_OSI_584 Prescripcion_de_medicamentos
    ''' Se cambia el control personalizado por el generico de .net
    ''' </summary>
    ''' <remarks></remarks>
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
    ''' <summary>
    ''' Carga el combo correspodiente a la via de administracion con 
    ''' la informacion consultada de la base de datos
    ''' Modificado: eloaiza@intergrupo.com
    ''' 10/2019
    ''' Req. ER_OSI_584 Prescripcion_de_medicamentos
    ''' Se cambia el control personalizado por el generico de .net 
    ''' </summary>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' Carga el combo correspondiente a la frecuencia con la informacion
    ''' consultada de la base de datos
    ''' Modificado: eloaiza@intergrupo.com
    ''' 10/2019
    ''' Req. ER_OSI_584 Prescripcion_de_medicamentos
    ''' Se cambia el control personalizado por el generico de .net
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
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


    Public Sub CargarTiempo()

        Dim dt As New DataTable
        Try
            dt = BLOrdenes.consultarTiempo(datosConexion)
            If dt.Rows.Count = 0 Then
                MsgBox("No existen tiempos parametrizados.")
            End If

            Me.Cmbtiempo.DataSource = dt

            Cmbtiempo.DisplayMember = "descripcion"
            Cmbtiempo.ValueMember = "Id"
            Cmbtiempo.EndUpdate()
            Cmbtiempo.SelectedValue = -1

            Cmbtiempo.SelectedValue = -1
        Catch ex As Exception
            MsgBox("Error al consultar la parametrización de Tiempo.", MsgBoxStyle.Information)
        End Try

    End Sub
    ''' <summary>
    ''' Nuevo: eloaiza@intergrupo.com
    ''' 10/2019
    ''' Req. ER_OSI_584 Prescripcion_de_medicamentos
    ''' Crea la coleccion de registros para el origen de datos del autocompletar del control
    ''' </summary>
    ''' <param name="DataSource">Tabla que contiene los datos a procesar, el campo debe llamarse 'descipcion'</param>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' Configura la visibilidad de los campos en la grilla de medicamentos.
    ''' en la grilla solo se muestran algunos campos descriptivos y los demas
    ''' son utilizados en el proceso de grabacion de las ordenes
    ''' </summary>
    ''' <param name="dtMedicamentos"></param>
    ''' <remarks></remarks>
    Public Sub configurarGrillaMedicamentos(ByVal dtMedicamentos As DataTable)
        '        dtSource = dtMedicamentos.Copy        

        'Dim tabla As New DataTable
        'dtgMedicamentos.DataSource = tabla

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
                .Columns.Add("conciliado", System.Type.GetType("System.String"))
                'Fin
            End With
            intload = 1
        End If

        dtMedicamentos.Rows.Add()

        With dtgMedicamentos
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
            .Columns("conciliacion").Visible = False

            'Fin
        End With

        dtMedicamentos.Rows.RemoveAt(dtMedicamentos.Rows.Count - 1)
        ''PaginarGrillaMed()
    End Sub

    ''' <summary>
    ''' Se configura el combo busqueda y el texto con formato para estos
    ''' controles permitan la busqueda de un medicamento ya se por  
    ''' descripcion o por codigo.
    ''' </summary>
    ''' <remarks></remarks>
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

    '''martovar ER_OSI 598 Indicaciones Médicas
    ''' <summary>
    ''' Se configura el combo busqueda y el texto con formato para estos
    ''' controles permitan la busqueda de un medicamento ya se por  
    ''' descripcion o por codigo.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub configurarComboIndicaciones()
        Me.Cmbindicaciones.BeginUpdate()
        Me.txttiporden.ControlComboEnlace = Cmbindicaciones
        With Cmbindicaciones
            .CampoMostrar = "descripcion"
            .ControlTextoEnlace = txttiporden
            .CampoEnlazado = "codigo"
            .CategoriaDatos = CategoriaDatos.Ordenindicaciones
            .CargarDatos()
            .CargarButton()
        End With
        Cmbindicaciones.EndUpdate()
    End Sub

    ''' <summary>
    ''' Controla el evento lanzado cuando el usuario da click sobre 
    ''' el check box "Unica Dosis". Si se elige Unica Dosis se debe 
    ''' inactivar el campo frecuencia.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub chkUnicaDosis_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUnicaDosis.CheckedChanged
        If chkUnicaDosis.Checked = True Then
            ''txtCodigoFreq.Enabled = False
            txtDescripcionFreq.Enabled = False
            'txtCodigoFreq.Text = ""
            txtDescripcionFreq.Text = ""
        Else
            ''txtCodigoFreq.Enabled = True
            txtDescripcionFreq.Enabled = True
        End If
    End Sub

    ''' <summary>
    ''' Adiciona los datos que el usuario digito a la grilla, validando antes
    ''' los datos requeridos. Actualiza el data table asociado con el datagrid 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAdicionarMedica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdicionarMedica.Click

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
        If IsNothing(dtgMedicamentos) Then
            Exit Sub
        End If

        dtMedica = dtgMedicamentos.DataSource
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
            LimpiarPanel(panelMedica, Nothing)
            txtCantidadC.Text = String.Empty
            BoolFormuladeControl = False
            txtCantidadLetras.Text = String.Empty
            'GroupCnt24.Visible = False
            strJustificacionL = String.Empty
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
                        MsgBox("debe digitar los dias de tratamiento", MsgBoxStyle.Information, "Medicamentos y Líquidos Endovensoso")
                        Me.txtDiasTrat.Focus()
                        Exit Sub
                    End If
                    flag_posCondicionado = BLOrdenes.existePosCondicionado(datosConexion, datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.TipoAdmision, datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision, "M", dtProductoElegido.Item("codigo").ToString)
                    If flag_posCondicionado = True Then
                        cod_Sispro = "POS Condicionado"
                        MsgBox("El elemento prescrito es POS Condicionado por Diagnóstico", MsgBoxStyle.Information)
                    Else
                        System.Diagnostics.Process.Start(pag_SISPRO)
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
                MsgBox("debe digitar los dias de tratamiento", MsgBoxStyle.Information, "Medicamentos y Líquidos Endovensoso")
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

        Dim tabla As DataTable = dtgMedicamentos.DataSource
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
                                MsgBox("Prescripción ya realizada", MsgBoxStyle.Information, "Medicamentos y Líquidos Endovensoso")
                                Me.cmbDescripMedica.Focus()
                                Exit Sub
                            End If
                        Else
                            MsgBox("Prescripción ya realizada", MsgBoxStyle.Information, "Medicamentos y Líquidos Endovensoso")
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
        '    MsgBox("Prescripción ya realizada", MsgBoxStyle.Information, "Medicamentos y Líquidos Endovensoso")
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

        'ADICIONA LA NUEVA FILA A LA TABLA
        dtMedica.Rows.Add(drFila)
        ''ADICIONA A LA TABLA DEL PAGINADOR
        'dtSource.Rows.Add(drFila)  'Claudia Garay Noviembre 18 de 2010
        'ENLAZA LA TABLA Y EL DATAGRID

        dtgMedicamentos.DataSource = dtMedica


        For i As Integer = 0 To dtgMedicamentos.Rows.Count - 7
            If dtgMedicamentos.Rows(i).IsNewRow Then
                dtgMedicamentos.Rows(i).Cells(0).ReadOnly = True
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
        LimpiarPanel(panelMedica, Nothing)
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

    ' ''Hernan Rojas 2014/05/15
    ' ''Se verifica que no exista el CTC
    ' ''Solicitado por Mauricio Forero

    'Private Function MedicamentoTieneCTC(ByVal Producto As String) As Boolean



    '    Dim dsCTC As DataSet
    '    Dim objGenerales As New DAOGeneral()
    '    Dim FechaServidor As Date
    '    Dim fec_desde As String
    '    Dim fec_hasta As String


    '    FechaServidor = Format(FuncionesGenerales.FechaServidor(), "dd/MM/yyyy")

    '    objGenerales.setSQLSentence("HC_ConsultarCTC", CommandType.StoredProcedure)
    '    objGenerales.ClearParameters()
    '    objGenerales.addInputParameter("strcod_pre_sgs", SqlDbType.VarChar, datosLogin.Prestador)
    '    objGenerales.addInputParameter("strCod_sucur", SqlDbType.VarChar, datosLogin.Sucursal)
    '    objGenerales.addInputParameter("strTip_admision", SqlDbType.VarChar, datosPaciente.TipoAdmision)
    '    objGenerales.addInputParameter("iAno_adm", SqlDbType.Int, datosPaciente.AnoAdmision)
    '    objGenerales.addInputParameter("lNum_adm", SqlDbType.Decimal, datosPaciente.NumeroAdmision)
    '    objGenerales.addInputParameter("Producto", SqlDbType.VarChar, Producto)
    '    objGenerales.addInputParameter("fecha", SqlDbType.Date, FechaServidor)

    '    dsCTC = objGenerales.execDS

    '    If dsCTC.Tables(0).Rows.Count > 0 Then
    '        fec_desde = dsCTC.Tables(0).Rows(0).ToString
    '        fec_hasta = dsCTC.Tables(0).Rows(1).ToString
    '        MsgBox("EL PRODUCTO " & Producto & "YA TIENE UN CTC GENERADO QUE ESTA VIGENTE CON FECHA INICIAL " & fec_desde & " y FECHA FINAL " & fec_hasta)
    '        MedicamentoTieneCTC = True
    '    Else
    '        ''Retorna el error pues no cargo los datos
    '        MedicamentoTieneCTC = False
    '    End If



    'End Function

    ''Claudia Garay 09 junio 2010
    ''Cambio de modificacion de ordenes medicas
    ''Solicitado por Mauricio Forero
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

                Dim tabla As DataTable = dtgMedicamentos.DataSource

                Dim prescripcion As String = txtDosis.Text & " " & txtDescripcionUM.Text.Trim() & " " & Me.txtDescripcionVA.Text.Trim() & " " &
                                     IIf(Not txtDescripcionFreq.Visible, "", txtDescripcionFreq.Text.Trim()) & " " &
                                     IIf(ChkBolo.Checked, " Bolo ", "") & "" &
                                     IIf(ChkBolo.Checked, IIf(Not txtPasarEn.Visible, "", "PASAR EN: " & txtPasarEn.Text.Trim() & " MINUTOS"), "") & "" &
                                     IIf(Not txtDurante24.Visible, "", " DURANTE: " & txtDurante24.Text.Trim() & " HORAS") &
                                     IIf(Not txtNumRescates.Visible, "", " Número de Rescates: " & txtNumRescates.Text.Trim()) & " " &
                                     IIf(Not txtNumDosis.Visible, "", "Número de Dosis: " & txtNumDosis.Text.Trim())

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
        IIf(txtNumRescates.Text <> "", " AND OMRescates ='" & txtNumRescates.Text.Trim() & "'", "AND OMRescates = OMRescates "))

                ''Dim producto As String = ((tabla.Rows(i))).ItemArray(1)

                If fila.Length > 0 Then
                    MsgBox("Prescripción ya realizada", MsgBoxStyle.Information, "Medicamentos y Líquidos Endovensoso")
                    'dtMedica.Rows(i).Item("Tratamiento").Value = ""
                    'dtMedica.Rows(i).Item("tmp_suspender_med").Value = ""
                    'dtMedica.Rows(i).Item("tmp_modificar_med").Value = ""
                    Me.cmbDescripMedica.Focus()
                    ActualizaModificados = True
                    Exit For
                End If


                ' FIN ER_OSI 584 eloaiza@intergrupo.com - Validar pre-existencia de medicamento y formulación

                If MsgBox("¿Está seguro de suspender la formulación actual e ingresar la nueva?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
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

                            If Me.txtDiasTrat.Text < 1 Then
                                MsgBox("debe digitar los dias de tratamiento", MsgBoxStyle.Information, "Medicamentos y Líquidos Endovensoso")
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
                    'Fin
                    'ADICIONA LA NUEVA FILA A LA TABLA
                    dtMedica.Rows.Add(drFila)
                    'ADICIONA A LA TABLA DEL PAGINADOR CLAUDIA GARAY NOVIEMBRE DE 2010
                    'dtSource.Rows.Add(drFila)
                    'ENLAZA LA TABLA Y EL DATAGRID

                    dtgMedicamentos.DataSource = dtMedica

                    LimpiarPanel(panelMedica, Nothing)
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
                    DirectCast(dtgMedicamentos.Rows(intIndice).Cells("continuar_med"), DataGridViewCheckBoxCell).Value = valoresContinuar(1)
                    DirectCast(dtgMedicamentos.Rows(intIndice).Cells("modificar_med"), DataGridViewCheckBoxCell).Value = valoresModificar(0)
                    DirectCast(dtgMedicamentos.Rows(intIndice).Cells("suspender_med"), DataGridViewCheckBoxCell).Value = valoresSuspender(0)

                    DirectCast(dtgMedicamentos.Rows(intIndice).Cells("continuar_med"), DataGridViewCheckBoxCell).ReadOnly = True
                    DirectCast(dtgMedicamentos.Rows(intIndice).Cells("modificar_med"), DataGridViewCheckBoxCell).ReadOnly = True
                    DirectCast(dtgMedicamentos.Rows(intIndice).Cells("suspender_med"), DataGridViewCheckBoxCell).ReadOnly = True

                    ' Se inactiva la fila nueva
                    DirectCast(dtgMedicamentos.Rows(dtgMedicamentos.RowCount - 1).Cells("continuar_med"), DataGridViewCheckBoxCell).ReadOnly = True
                    DirectCast(dtgMedicamentos.Rows(dtgMedicamentos.RowCount - 1).Cells("modificar_med"), DataGridViewCheckBoxCell).ReadOnly = True
                    DirectCast(dtgMedicamentos.Rows(dtgMedicamentos.RowCount - 1).Cells("suspender_med"), DataGridViewCheckBoxCell).ReadOnly = True

                Else
                    falg_modificar = 0
                    intIndice = i
                    DirectCast(dtgMedicamentos.Rows(intIndice).Cells("continuar_med"), DataGridViewCheckBoxCell).Value = valoresContinuar(1)
                    DirectCast(dtgMedicamentos.Rows(intIndice).Cells("modificar_med"), DataGridViewCheckBoxCell).Value = valoresModificar(1)
                    DirectCast(dtgMedicamentos.Rows(intIndice).Cells("suspender_med"), DataGridViewCheckBoxCell).Value = valoresSuspender(1)
                    ActualizaModificados = True
                End If

            End If
        Next
    End Function

    'Private Sub CopiaDatatable(ByVal dtOrigen As DataTable)
    '    Dim dtDestino As New DataTable
    '    Dim i As Integer


    '    dtDestino = dtOrigen.Clone

    '    For i = 0 To dtOrigen.Rows.Count - 1
    '        dtDestino.Rows.Add()
    '        dtDestino.Rows(i).Item("descripcion") = dtOrigen.Rows(i).Item("descripcion")
    '        dtDestino.Rows(i).Item("prescripcion") = dtOrigen.Rows(i).Item("prescripcion")
    '        dtDestino.Rows(i).Item("NombreMedico") = dtOrigen.Rows(i).Item("NombreMedico")
    '        dtDestino.Rows(i).Item("Especialidad") = dtOrigen.Rows(i).Item("Especialidad")
    '        dtDestino.Rows(i).Item("cod_pre_sgs") = dtOrigen.Rows(i).Item("cod_pre_sgs")
    '        dtDestino.Rows(i).Item("cod_sucur") = dtOrigen.Rows(i).Item("cod_sucur")
    '        dtDestino.Rows(i).Item("tip_admision") = dtOrigen.Rows(i).Item("tip_admision")
    '        dtDestino.Rows(i).Item("ano_adm") = dtOrigen.Rows(i).Item("ano_adm")
    '        dtDestino.Rows(i).Item("num_adm") = dtOrigen.Rows(i).Item("num_adm")
    '        dtDestino.Rows(i).Item("NroOrden") = dtOrigen.Rows(i).Item("NroOrden")
    '        dtDestino.Rows(i).Item("producto") = dtOrigen.Rows(i).Item("producto")
    '        dtDestino.Rows(i).Item("FormaFarma") = dtOrigen.Rows(i).Item("FormaFarma")
    '        dtDestino.Rows(i).Item("Presentacion") = dtOrigen.Rows(i).Item("Presentacion")
    '        dtDestino.Rows(i).Item("Contenido") = dtOrigen.Rows(i).Item("Contenido")
    '        dtDestino.Rows(i).Item("Concentracion") = dtOrigen.Rows(i).Item("Concentracion")
    '        dtDestino.Rows(i).Item("Dosis") = dtOrigen.Rows(i).Item("Dosis")
    '        dtDestino.Rows(i).Item("UniMedDosis") = dtOrigen.Rows(i).Item("UniMedDosis")
    '        dtDestino.Rows(i).Item("ViaAdministra") = dtOrigen.Rows(i).Item("ViaAdministra")
    '        dtDestino.Rows(i).Item("Frecuencia") = dtOrigen.Rows(i).Item("Frecuencia")
    '        dtDestino.Rows(i).Item("TecnicaAdministra") = dtOrigen.Rows(i).Item("TecnicaAdministra")
    '        dtDestino.Rows(i).Item("UnicaDosis") = dtOrigen.Rows(i).Item("UnicaDosis")
    '        dtDestino.Rows(i).Item("obs") = dtOrigen.Rows(i).Item("obs")
    '        dtDestino.Rows(i).Item("Tratamiento") = dtOrigen.Rows(i).Item("Tratamiento")
    '        dtDestino.Rows(i).Item("estado") = dtOrigen.Rows(i).Item("estado")
    '        dtDestino.Rows(i).Item("medico") = dtOrigen.Rows(i).Item("medico")
    '        dtDestino.Rows(i).Item("Login") = dtOrigen.Rows(i).Item("Login")

    '    Next

    '    _Ordenes.dtMedicamentos = dtDestino

    'End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
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
            '' Return Nothing raul
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
    Private Sub dtgMedicamentos_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        Dim fila As Int16 = e.RowIndex
        Dim temCod As Int32
        Dim mensajeValidacion As String = ""

        Dim TextoValidar As String = ""

        If fila = -1 Then 'para evitar que se genere el error de excepción
            Exit Sub
        End If

        If dtgMedicamentos.Rows(fila).Cells(0).Value = 1 Then

        End If

    End Sub

    ''Claudia Garay Paginador Noviembre 18 de 2010
    'Private Function ActualizaDataTablePaginador(ByVal dtPag As DataTable, ByRef drDatos As DataRow) As DataTable
    '    Dim rows() As DataRow
    '    Dim row As DataRow
    '    rows = dtPag.Select("NroOrden='" & drDatos.Item("NroOrden") & "'and producto='" & drDatos.Item("producto") & "'")
    '    For Each row In rows
    '        row.BeginEdit()
    '        row.Item("Tratamiento") = drDatos.Item("Tratamiento")
    '        row.EndEdit()
    '    Next
    '    Return dtPag

    'End Function

    ''CLAUDIA GARAY
    Private Sub MostrarInforMed(ByVal row As Integer)

        Dim dt As New DataTable
        Dim dtcmbUM As New DataTable
        Dim dtcmbVA As New DataTable
        Dim dtcmbFRE As New DataTable
        Dim rows() As DataRow

        dt = dtgMedicamentos.DataSource


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

        txtCodMedica.Text = (dt.Rows(row)("producto"))
        txtCodMedica.Enabled = False
        cmbDescripMedica.Text = (dt.Rows(row)("descripcion"))
        cmbDescripMedica.Enabled = False
        Dim ttxtDosis As Decimal = dt.Rows(row)("Dosis") ' FormatNumber(CDbl(dt.Rows(row)("Dosis")), 2)
        txtDosis.Text = ttxtDosis
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
                txtDiasTrat.Refresh()
            End If
        Else
            Me.txtDiasTrat.Visible = False
        End If

        If Not IsDBNull(dt.Rows(row)("OMDurante")) Then 'dt.Rows(row)("OMDurante") > 0
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
            If txtPasarEn.Text <> "" Then
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

    Private Sub MostrarInforMedSispro(ByVal row As Integer)
        Dim dt As New DataTable
        Dim dtcmbUM As New DataTable
        Dim dtcmbVA As New DataTable
        Dim dtcmbFRE As New DataTable
        Dim rows() As DataRow

        dt = dtgMedicamentos.DataSource
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
            Me.txtDiasTrat.Text = dt.Rows(row)("diastrat")
        Else
            Me.txtDiasTrat.Visible = False
        End If

    End Sub

    Private Sub dtgMedicamentos_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) 'Handles dtgMedicamentos.CellContentDoubleClick
        dtgMedicamentos_CellValueChanged(sender, e)
        'dtgMedicamentos_CellContentClick(sender, e)
    End Sub

    Private Sub dtgMedicamentos_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dtgMedicamentos.UserDeletingRow
        'Dim rows() As DataRow 
        Dim row As DataRow
        Dim dtDatos As DataTable = dtgMedicamentos.DataSource
        Dim producto As String
        ''raul inicio alm 132
        producto = dtDatos.Rows(e.Row.Index).Item("Producto").ToString
        For Each Fila As DataGridViewRow In dtgMedicamentos.Rows

            If Fila.Cells("Producto").Value = producto Then
                DirectCast(dtgMedicamentos.Rows(Fila.Index).Cells("modificar_med"), DataGridViewCheckBoxCell).ReadOnly = False
                DirectCast(dtgMedicamentos.Rows(Fila.Index).Cells("suspender_med"), DataGridViewCheckBoxCell).ReadOnly = False
                DirectCast(dtgMedicamentos.Rows(Fila.Index).Cells("continuar_med"), DataGridViewCheckBoxCell).ReadOnly = False
                DirectCast(dtgMedicamentos.Rows(Fila.Index).Cells("modificar_med"), DataGridViewCheckBoxCell).Value = "N"
                DirectCast(dtgMedicamentos.Rows(Fila.Index).Cells("suspender_med"), DataGridViewCheckBoxCell).Value = "C"
                Exit For
            End If
        Next Fila
        ''raul Fin

        e.Cancel = True

        row = dtDatos.Rows(e.Row.Index)
        If row.RowState = DataRowState.Added Then
            _tamanoXmlMedica -= BLOrdenes.tamanoFilaXmlMedica(row)
            e.Cancel = False
        End If
    End Sub

    Private Sub cmbUnidadMedida_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        validaKeyPress(txtDescripcionUM, e)
    End Sub

    Private Sub cmbViaAdmin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'validaKeyPress(cmbViaAdmin_old, e)
    End Sub

    Private Sub chkUnicaDosis_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkUnicaDosis.KeyPress
        Select Case e.KeyChar
            Case Convert.ToChar(Keys.Return)
                Me.GetNextControl(chkUnicaDosis, True).Focus()
        End Select
    End Sub

    Private Sub cmbDescripMedica_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDescripMedica.SelectedIndexChanged
        Dim dtDatos As DataTable

        dtDatos = cmbDescripMedica.DataSource
        If dtDatos Is Nothing Then
            Exit Sub
        End If

        If dtDatos.Rows.Count <= 0 Then
            Exit Sub
        End If

        If cmbDescripMedica.SelectedIndex <> -1 Then
            With dtDatos.Rows(cmbDescripMedica.SelectedIndex)
                'eloaiza@intergrupo.com REQ OSI 584 Se deja en comentario y se limpia por si las moscas
                'txtDosis.Text = .Item("contenido").ToString
                txtDosis.Text = String.Empty
                txtDescripcionUM.Text = .Item("descrConcentracion").ToString
                ''Claudia Garay Noviembre 17 de 2010
                ''Cambio de combo de via de administracion y unidad de medida por textbox con formato
                'cmbUnidadMedida.Text = .Item("descrConcentracion").ToString
                'cmbViaAdmin.Text = .Item("descrVia").ToString
                txtDescripcionVA.Text = .Item("descrVia").ToString
                'txtCodigoFreq.Text = .Item("frecuencia").ToString
                txtDescripcionFreq.Text = .Item("descrFrecuencia").ToString
                txtTecnica.Text = .Item("obs").ToString
            End With
        End If
    End Sub


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





    Private Function puedeAdicionarRegistroMedicamento(ByVal drFila As DataRow) As Boolean
        ''Validacion del tamaño maximo que se puede pasar al 
        ''stored procedure que guarda la orden
        Dim tamano As Integer

        tamano = _tamanoXmlMedica

        If drFila.RowState <> DataRowState.Modified Then
            tamano += BLOrdenes.tamanoFilaXmlMedica(drFila)
        End If

        If tamano > 8000 Then
            MsgBox("No se puede adicionar este registro pues se excede el número maximo de registros a grabar.")
            Return False
        Else
            _tamanoXmlMedica = tamano
            Return True
        End If

    End Function

#End Region

#Region "Procedimientos"

    Public Sub configurarComboProcedimientos()

        Dim objBasicasLocales As New BLBasicasLocales

        ''Combo tipos de procedimiento
        With tbCodTipoProcedim
            .NombreCampoBusqueda = "tip_proced"
            .NombreCampoBuscado = "descripcion"
            .ControlTextoEnlace = tbDesTipoProc
        End With

        With tbDesTipoProc
            .NombreCampoDatos = "descripcion"
            .ControlTextoEnlace = tbCodTipoProcedim
            .OrigenDeDatos = objBasicasLocales.TraerDatosTablasBasicasLocales(datosLogin.CadenaLocal, "gentippr", "tip_proced,descripcion", "")
            .CargarDatosDescripcion()
        End With

        ''Combo buscador de procedimientos filtrados por tipo de procedimiento
        With txtCodProcedim
            .ControlComboEnlace = cmbDescripProcedim
        End With

        With cmbDescripProcedim
            .CampoMostrar = "descripcion"
            .ControlTextoEnlace = txtCodProcedim
            .CampoEnlazado = "codigo"
            '.CategoriaDatos = CategoriaDatos.ProcedimientosRis
            '.CargarDatos()
            .CargarButton()
        End With


    End Sub

    ''' <summary>
    ''' Crea el data table que contendra los datos de los procedimientos
    ''' y lo enlaza con el dataGrid de procedimientos
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub configurarGrillaProcedimientos()

        dtgProcedimientos.DataSource = crearTablaProcedimientos()

        With dtgProcedimientos
            .Columns("cod_pre_sgs").Visible = False
            .Columns("cod_sucur").Visible = False
            .Columns("tip_admision").Visible = False
            .Columns("num_adm").Visible = False
            .Columns("ano_adm").Visible = False
            .Columns("NroOrden").Visible = False
            'Joseph Moreno (IG) Fec:2019/12/20 Mostrar Código
            '.Columns("procedim").Visible = False
            .Columns("medico").Visible = False
            .Columns("fec_con").Visible = False
            .Columns("login").Visible = False
            .Columns("tip_proced").Visible = False
            .Columns("tieneConvenio").Visible = False

            ''VARIABLES PARA GUARDAR EL PEDIDO DEL PROCEDIMIENTO
            .Columns("secuencia").Visible = False
            .Columns("uni_solicit").Visible = False
            .Columns("uni_aplicada").Visible = False
            .Columns("uni_suministrada").Visible = False
            .Columns("durante").Visible = False
            .Columns("cen_cos_des").Visible = False
            .Columns("cen_cos_origen").Visible = False
            .Columns("descri_cen_cos_des").Visible = False
            .Columns("entidad").Visible = False
            .Columns("grabaPedido").Visible = False
            .Columns("NroPedido").Visible = False 'jlalfonso- 2009-01-08 se retira comentario que no tenia en cuenta numero de pedido
            .Columns("codigo_ris").Visible = False
            .Columns("OrigenProcedim").Visible = False
            .Columns("JustificaSinConve").Visible = False ' Honorario Variable 2015/03/17
            .Columns("tieneCcostoLabo").Visible = False ' HL7 RMZALDUA 2015-12-02     
            .Columns("EstadoInterconsulta").Visible = False ' HL7 RMZALDUA 2015-12-02
            'Joseph Moreno (IG) Fec:2019/11/20 Particularidades
            .Columns("genprocedes").Visible = False
            .Columns("particularidades").Visible = False
            .Columns("procedimientos").Visible = False
        End With
    End Sub

    Public Function crearTablaProcedimientos() As DataTable
        Dim dtProcedim As New DataTable()

        With dtProcedim.Columns
            .Add("procedim", System.Type.GetType("System.String"))
            .Add("descripcion_proce", System.Type.GetType("System.String"))
            .Add("Cantidad", System.Type.GetType("System.String"))
            .Add("obs", System.Type.GetType("System.String"))
            .Add("cod_pre_sgs", System.Type.GetType("System.String"))
            .Add("cod_sucur", System.Type.GetType("System.String"))
            .Add("tip_admision", System.Type.GetType("System.String"))
            .Add("num_adm", System.Type.GetType("System.String"))
            .Add("ano_adm", System.Type.GetType("System.String"))
            .Add("NroOrden", System.Type.GetType("System.String"))
            .Add("medico", System.Type.GetType("System.String"))
            .Add("fec_con", System.Type.GetType("System.String"))
            .Add("login", System.Type.GetType("System.String"))
            .Add("tieneConvenio", System.Type.GetType("System.String"))
            .Add("codigo_ris", System.Type.GetType("System.String")) ''CLaudia Garay Junio 2011
            .Add("numconsulta", System.Type.GetType("System.String")) ' agfa_orm_in herojas 2014/10/10
            .Add("mensaje", System.Type.GetType("System.String")) ' agfa_orm_in herojas 2014/10/10
            ''VARIABLES PARA GUARDAR EL PEDIDO DEL PROCEDIMIENTO
            .Add("grabaPedido", System.Type.GetType("System.String"))
            .Add("secuencia", System.Type.GetType("System.String"))
            .Add("uni_solicit", System.Type.GetType("System.String"))
            .Add("uni_aplicada", System.Type.GetType("System.String"))
            .Add("uni_suministrada", System.Type.GetType("System.String"))
            .Add("durante", System.Type.GetType("System.String"))
            .Add("cen_cos_des", System.Type.GetType("System.String"))
            .Add("cen_cos_origen", System.Type.GetType("System.String"))
            .Add("descri_cen_cos_des", System.Type.GetType("System.String"))
            .Add("entidad", System.Type.GetType("System.String"))
            .Add("tip_proced", System.Type.GetType("System.String"))
            .Add("NroPedido", System.Type.GetType("System.String")) 'jlalfonso- 2009-01-08 se retira comentario que no tenia en cuenta numero de pedido
            .Add("OrigenProcedim", System.Type.GetType("System.String"))
            .Add("JustificaSinConve", System.Type.GetType("System.String")) ' Honorario Variable 2015/03/17
            .Add("tieneCcostoLabo", System.Type.GetType("System.String")) ' HL7 RMZALDUA 2015-12-02
            .Add("CodSISPRO", System.Type.GetType("System.String")) ' SISPRO RMZALDUA 2016-11-18
            .Add("DesSISPRO", System.Type.GetType("System.String")) ' SISPRO RMZALDUA 2015-11-18
            .Add("autoSISPRO", System.Type.GetType("System.String")) ' SISPRO RMZALDUA 2015-11-18
            .Add("EstadoInterconsulta", System.Type.GetType("System.String")) ' Evolucion caraarias 2018-07-17
            'Joseph Moreno (IG) Fec:2019/11/20 Particularidades
            .Add("genprocedes", System.Type.GetType("System.String"))
            .Add("particularidades", System.Type.GetType("System.String"))
            .Add("procedimientos", System.Type.GetType("System.String"))
        End With
        Return dtProcedim
    End Function


    ''' <summary>
    ''' Adiciona el nuevo registro a la grilla validando los datos obligatorios
    ''' y los registros duplicados. se actualiza el dataTable relacionado con 
    ''' el dataGrid 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAdicionarProcedim_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdicionarProcedim.Click

        'ALM 166 20200303 raul Cruz
        If ValidarDatosHisBasica() Then
            Exit Sub
        End If

        Dim dtdatos As DataTable
        Dim drProcedimElegido As DataRow
        Dim mensaje As String = String.Empty
        Dim tieneConvenio As Boolean
        Dim tieneCcostoLabo As Boolean
        Dim tieneEntidadRec As Boolean
        'Dim tieneEpsReco As Boolean
        Dim rsNew As DataRow
        Dim intTipoProced As Integer
        Dim strJustificacionL As String = ""
        Dim procedimhomologo As String = ""
        Dim dtProc As DataTable

        Dim esHonorario As Boolean = False

        Dim pide_SISPRO As String
        Dim pag_SISPRO As String
        Dim cod_Sispro As String = ""
        Dim flag_pos As String = ""
        Dim flag_posCondicionado As Boolean
        Dim dtProInterconsulta As New DataTable

        'VALIDACION DEL DATASOURCE TABLA PROCEDIMIENTO
        dtdatos = dtgProcedimientos.DataSource
        If dtdatos Is Nothing Then
            MsgBox("Error en la carga de los datos a la grilla.", MsgBoxStyle.Information)
            Exit Sub
        End If

        'VALIDACION DEL RESULTADO DEL BUSCADOR
        ''BUSCA EN EL DATASOURCE DEL COMBO LA INFORMACION DEL PROCEDIMIENTO 
        ''QUE ELIGIO EL USUARIO
        drProcedimElegido = procedimientoSeleccionadoCombo()

        If drProcedimElegido Is Nothing Then
            MsgBox("Debe digitar la informacion del procedimiento")
            Exit Sub
        End If

        'drProcedimElegido.Item("tip_proced") = Mid(drProcedimElegido.Item("codigo"), 1, 1)
        drProcedimElegido.Item("tip_proced") = drProcedimElegido.Item("tip_proced").ToString()

        If txtCantidad.Text = "" Then
            txtCantidad.Text = 1
        End If
        ' Validacion ingresada por Claudia Garay 
        ' Solicitud Enrique Forero
        ' Observaciones obligatorias para los procedimientos de grupo 402
        ' agfa_orm_in se coloca antes de validar procedimientos para que los mensajes salgan en orden (observaciones, guia, justificacion) 2014/09/15
        ' se agrega esta validacion en validarProcedimientos
        'If Mid(txtCodProcedim.Text, 1, 3) = "402" And (LTrim(txtObsProcedim.Text) = String.Empty) Then
        '    MessageBox.Show("Para este procedimiento es obligatorio ingresar observaciones.", "Historia Clinica", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtObsProcedim.Focus()
        '    Exit Sub
        'End If

        'VALIDACIONES DE DATOS OBLIGATORIOS Y REGISTROS DUPLICADOS
        ' herojas agfa_orm_in Interfaz ORM Un codigo_ris puede tener aleas duplicados
        ' se envia origenprocedm y codigo_ris 2014/09/18
        ' se envian las observaciones 2014/11/26
        'Joseph Moreno (IG) Fec:2019/11/21 Particularidades
        If Not BLOrdenes.validarProcedimientos(drProcedimElegido.Item("codigo").ToString,
                                            drProcedimElegido.Item("descripcion").ToString,
                                            drProcedimElegido.Item("tip_proced").ToString,
                                            txtCantidad.Text, cmbCentroCosto.DataSource,
                                            cmbCentroCosto.Text, dtdatos, tb_Guia.Text, tb_Justi.Text, mensaje, datosPaciente.Entidad,
                                            datosPaciente.TipoAdmision, drProcedimElegido(3).ToString, drProcedimElegido.Item("codigo_ris"),
                                            drProcedimElegido.Item("mensaje"), txtObsProcedim.Text,
                                            Me.ctlPartProce.Validar()) Then
            If mensaje <> "" Then
                MsgBox(mensaje, MsgBoxStyle.Information)
            End If
            Exit Sub

        End If

#Region "--codigo old --"
        ''Ctc Marzo 21 de 2012 cpgaray
        'If BLOrdenes.ConsultaExcepcionesProce(datosPaciente.Entidad, txtCodProcedim.Text) = True Then
        '    MsgBox("El procedimiento elegido es una Excepción por favor ingrese la Justificación")
        '    frmc_JustificaExcepcionProc.ShowDialog()
        '    strJustificacionL = frmc_JustificaExcepcionProc.strJustificacion
        '    If Len(strJustificacionL) = 0 Then
        '        Exit Sub
        '    End If
        '    'frmc_JustificaExcepcion.strJustificacion = String.Empty
        '    'frmc_JustificaExcepcion.txtJustificacion.Text = String.Empty
        'End If


        'If drProcedimElegido.Item("codigo").ToString Then


        '    If drProcedimElegido.Item("codigo").ToString = "402010021" Or drProcedimElegido.Item("codigo").ToString = "402010027" Or drProcedimElegido.Item("codigo").ToString = "402030002" Or drProcedimElegido.Item("codigo").ToString = "402030052" Or drProcedimElegido.Item("codigo").ToString = "402030072" Or drProcedimElegido.Item("codigo").ToString = "402030109" Then

        '        MsgBox("EL PROCEDIMIENTO NO SE REALIZA EN ESTA INSTITUCIÓN")

        '    End If

        'End If 

#End Region

        Dim daoGeneral As New DAOGeneral

        pide_SISPRO = daoGeneral.EjecutarSQLStrValor("gensucur (nolock)", datosConexion, " pide_SISPRO", " cod_sucur='" & datosLogin.Sucursal & "'")
        pag_SISPRO = daoGeneral.EjecutarSQLStrValor("pargener (nolock)", datosConexion, " pagsispro", " cod_pre_sgs='" & datosLogin.Prestador & "'")


        rsNew = dtdatos.NewRow()

        'LLENADO DE DATOS
        rsNew("cod_pre_sgs") = datosLogin.Prestador
        rsNew("cod_sucur") = datosLogin.Sucursal
        rsNew("tip_admision") = datosPaciente.TipoAdmision
        rsNew("num_adm") = datosPaciente.NumeroAdmision
        rsNew("ano_adm") = datosPaciente.AnoAdmision
        rsNew("NroOrden") = 0
        rsNew("NroPedido") = 0 'jlalfonso
        rsNew("procedim") = drProcedimElegido.Item("codigo").ToString
        'Joseph Moreno (IG) Fec:2019/11/20 Particularidades
        'rsNew("descripcion_proce") = drProcedimElegido.Item("descripcion").ToString
        rsNew("genprocedes") = drProcedimElegido.Item("descripcion").ToString
        rsNew("cantidad") = txtCantidad.Text
        rsNew("medico") = datosLogin.Login
        rsNew("login") = datosLogin.Login
        rsNew("obs") = txtObsProcedim.Text
        rsNew("tip_proced") = tbCodTipoProcedim.Text
        rsNew("cen_cos_origen") = strCentroCostoOrigen
        rsNew("OrigenProcedim") = drProcedimElegido.Item("Origen").ToString 'agfa_orm_in  herojas 2014/10/10
        rsNew("codigo_ris") = drProcedimElegido.Item("codigo_ris").ToString 'agfa_orm_in  herojas 2014/10/10
        rsNew("numconsulta") = drProcedimElegido.Item("numconsulta").ToString 'agfa_orm_in  herojas 2014/10/10
        rsNew("mensaje") = drProcedimElegido.Item("mensaje").ToString 'agfa_orm_in  herojas 2014/10/10
        rsNew("entidad") = datosPaciente.Entidad 'agfa_orm_in  herojas 2014/10/10
        rsNew("JustificaSinConve") = strJustificaSinConvenio 'honorario variable  herojas 2015/03/17

        'Inicia: CCGUTIEREZ - OSI. 28/01/2020
        'Proyecto: Sophia - Codificacion
        'Cambio: Se corrige la descripcion del procedimiento que pasa al grid

        rsNew("descripcion_proce") = IIf(Me.ctlPartProce.DescripcionTotal <> "", Me.ctlPartProce.DescripcionTotal.ToString, drProcedimElegido.Item("descripcion").ToString)
        ''Joseph Moreno (IG) Fec:2019/11/20 Particularidades
        'rsNew("descripcion_proce") = Me.ctlPartProce.DescripcionTotal
        'Fin. CCGUTIEREZ

        ''Joseph Moreno (IG) Fec:2019/11/20 Particularidades
        rsNew("particularidades") = Me.ctlPartProce.XmlGrpXPar
        rsNew("procedimientos") = Me.ctlPartProce.XmlProcPar

        Dim codigo_RIS As String = ""
        Dim nombre_RIS As String = ""
        Dim dtAdmEnt As DataTable
        Dim dtExamenLabo As DataTable
        Dim dtEntidad As DataTable
        Dim strEntidadsec As String
        Dim strProcedimlabo As String
        Dim strTipEntLabo As String
        Dim strExcepcion As String = "N"
        Dim strTipoEntidad As String

        Dim i As Integer

        'BLOrdenes.consultarRIS(datosConexion, drProcedimElegido.Item("codigo").ToString, codigo_RIS, nombre_RIS)

        'rsNew("codigo_RIS") = drProcedimElegido.Item("codigo_ris").ToString
        'rsNew("nombre_RIS") = nombre_RIS

        ''VARIABLES PARA GRABAR EL PEDIDO DE PROCEDIMIENTOS
        rsNew("uni_solicit") = txtCantidad.Text
        'If cmbCentroCosto.DataSource.rows.count = 0 Then
        '    _Ordenes.ccDest_Proce = ""
        'Else
        '    _Ordenes.ccDest_Proce = cmbCentroCosto.SelectedValue.ToString ''cpgaray Octubre 24 2011
        'End If

        'jlalfonso 2009-07-02 se retira validacion porque para entidad particular tambien debe
        'generar pedido. solicitado por eforero.
        'If datosPaciente.TipoEntidad.Contains("PAR") = False Then
        strTipEntLabo = "0"
        strEntidadsec = ""
        If IsNumeric(drProcedimElegido.Item("codigo_ris").ToString) Then
            If drProcedimElegido.Item("codigo_ris").ToString <> 0 Then
                tieneCcostoLabo = BLOrdenes.CentroCostoLaboratorio(datosConexion, datosLogin.Prestador, datosLogin.Sucursal,
                                                                   cmbCentroCosto.SelectedValue.ToString)
            Else
                tieneCcostoLabo = False
            End If
        Else
            tieneCcostoLabo = False
        End If

        If tieneCcostoLabo Then
            rsNew("tieneCcostoLabo") = "S"
            dtExamenLabo = DAOOrdenes.consultarExamenTipEnt(datosConexion, drProcedimElegido.Item("codigo_ris").ToString, datosPaciente.Entidad)
            If dtExamenLabo.Rows.Count > 0 Then
                strExcepcion = dtExamenLabo.Rows(0).Item("excepcion").ToString()
                strProcedimlabo = dtExamenLabo.Rows(0).Item("procedim").ToString()
                strTipEntLabo = dtExamenLabo.Rows(0).Item("codentlabo").ToString()
            Else
                strExcepcion = "S"
                strProcedimlabo = drProcedimElegido.Item("codigo").ToString
                strTipEntLabo = "1"
            End If
            rsNew("procedim") = strProcedimlabo

            drProcedimElegido.Item("tip_proced") = Mid(strProcedimlabo, 1, 1)

            intTipoProced = Val(drProcedimElegido.Item("tip_proced").ToString)
            strTipoEntidad = datosPaciente.TipoEntidad.ToString
            If strExcepcion = "S" Then
                If strTipEntLabo = "2" Then
                    'MsgBox("pruebas")
                    strEntidadsec = BLOrdenes.EpsRecobrable(datosConexion, datosPaciente.Entidad)
                    tieneEntidadRec = BLOrdenes.existeEntidadAdmadmentrec(datosConexion, datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.TipoAdmision, datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision, strEntidadsec)
                    If tieneEntidadRec = True Then
                        dtExamenLabo = DAOOrdenes.consultarExamenTipEnt(datosConexion, drProcedimElegido.Item("codigo_ris").ToString, strEntidadsec)
                        If dtExamenLabo.Rows.Count > 0 Then
                            strExcepcion = dtExamenLabo.Rows(0).Item("excepcion").ToString()
                            strProcedimlabo = dtExamenLabo.Rows(0).Item("procedim").ToString()
                            strTipEntLabo = dtExamenLabo.Rows(0).Item("codentlabo").ToString()
                            rsNew("procedim") = strProcedimlabo
                            tieneConvenio = BLOrdenes.procedimientoTieneConvenio(datosConexion, strProcedimlabo, datosLogin.Prestador,
                                                                        datosLogin.Sucursal, strEntidadsec, procedimhomologo, cmbCentroCosto.SelectedValue.ToString)
                            'Resolucion 084 RJMAESTRE CU15 - 16-07-2021
                            'If tieneConvenio = True Then
                            '    '                               If strTipoEntidad = "EPS" Then
                            '    If MessageBox.Show("El procedimiento ordenado es no POS, por favor diligenciar la página de MIPRES", "Examenes de Laboratorio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                            '        Exit Sub
                            '    End If
                            '    '                                End If
                            'End If
                        Else
                            dtEntidad = DAOOrdenes.consultarEntidad(datosConexion, strEntidadsec)
                            If dtEntidad.Rows.Count > 0 Then
                                strTipoEntidad = dtEntidad.Rows(0).Item("tip_entidad").ToString
                            End If
                            strEntidadsec = datosPaciente.Entidad
                        End If
                    End If
                Else
                    dtAdmEnt = DAOOrdenes.consultarAdmisionEnt(datosConexion, datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.TipoAdmision,
                                                               datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision, datosPaciente.Entidad)

                    i = 0
                    Do While i < dtAdmEnt.Rows.Count
                        strEntidadsec = dtAdmEnt.Rows(i).Item("entidad").ToString()
                        dtExamenLabo = DAOOrdenes.consultarExamenTipEnt(datosConexion, drProcedimElegido.Item("codigo_ris").ToString, strEntidadsec)
                        If dtExamenLabo.Rows.Count > 0 Then
                            If Mid(strEntidadsec, 1, 3) = "PAR" Then
                                strExcepcion = "N"
                            Else
                                strExcepcion = dtExamenLabo.Rows(0).Item("excepcion").ToString()
                            End If

                            strProcedimlabo = dtExamenLabo.Rows(0).Item("procedim").ToString()
                            strTipEntLabo = dtExamenLabo.Rows(0).Item("codentlabo").ToString()
                            rsNew("procedim") = strProcedimlabo
                            tieneConvenio = BLOrdenes.procedimientoTieneConvenio(datosConexion, strProcedimlabo, datosLogin.Prestador,
                                                                        datosLogin.Sucursal, strEntidadsec, procedimhomologo, cmbCentroCosto.SelectedValue.ToString)

                            If strExcepcion = "N" Then
                                If tieneConvenio = True Then
                                    'tieneEpsReco = BLOrdenes.EpsRecobrable(datosConexion, strEntidadsec)
                                    'If tieneEpsReco Then
                                    '    If strTipoEntidad = "EPS" Then
                                    '        If MessageBox.Show("El procedimiento ordenado es no POS, por lo cual deberá diligenciar la justificación de realización para CTC", "Examenes de Laboratorio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                                    '            Exit Sub
                                    '        End If
                                    '    End If
                                    'End If
                                    Exit Do
                                Else
                                    If strTipEntLabo = "2" Then
                                        'MsgBox("EPESRECO")
                                        strEntidadsec = BLOrdenes.EpsRecobrable(datosConexion, strEntidadsec)
                                        tieneEntidadRec = BLOrdenes.existeEntidadAdmadmentrec(datosConexion, datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.TipoAdmision, datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision, strEntidadsec)
                                        If tieneEntidadRec = True Then
                                            dtExamenLabo = DAOOrdenes.consultarExamenTipEnt(datosConexion, drProcedimElegido.Item("codigo_ris").ToString, strEntidadsec)
                                            If dtExamenLabo.Rows.Count > 0 Then
                                                strExcepcion = dtExamenLabo.Rows(0).Item("excepcion").ToString()
                                                strProcedimlabo = dtExamenLabo.Rows(0).Item("procedim").ToString()
                                                strTipEntLabo = dtExamenLabo.Rows(0).Item("codentlabo").ToString()
                                                rsNew("procedim") = strProcedimlabo
                                                tieneConvenio = BLOrdenes.procedimientoTieneConvenio(datosConexion, strProcedimlabo, datosLogin.Prestador,
                                                                                            datosLogin.Sucursal, strEntidadsec, procedimhomologo, cmbCentroCosto.SelectedValue.ToString)

                                                If tieneConvenio = True Then
                                                    'If strTipoEntidad = "EPS" Then
                                                    If pide_SISPRO = "S" Then
                                                        'If MessageBox.Show("El procedimiento ordenado es no POS, por favor diligenciar la página de MIPRES", "Examenes de Laboratorio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                                                        '    Exit Sub
                                                        'End If
                                                    Else
                                                        If MessageBox.Show("El procedimiento ordenado es no POS, por lo cual deberá diligenciar la justificación de realización para CTC", "Examenes de Laboratorio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                                                            Exit Sub
                                                        End If
                                                    End If
                                                    'End If
                                                    Exit Do
                                                End If
                                            Else
                                                dtEntidad = DAOOrdenes.consultarEntidad(datosConexion, strEntidadsec)
                                                If dtEntidad.Rows.Count > 0 Then
                                                    strTipoEntidad = dtEntidad.Rows(0).Item("tip_entidad").ToString
                                                End If
                                                strEntidadsec = datosPaciente.Entidad
                                            End If
                                        End If
                                    End If
                                End If
                            Else
                                If strTipEntLabo = "2" Then
                                    'MsgBox("EPESRECO")
                                    strEntidadsec = BLOrdenes.EpsRecobrable(datosConexion, strEntidadsec)
                                    tieneEntidadRec = BLOrdenes.existeEntidadAdmadmentrec(datosConexion, datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.TipoAdmision, datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision, strEntidadsec)
                                    If tieneEntidadRec = True Then
                                        dtExamenLabo = DAOOrdenes.consultarExamenTipEnt(datosConexion, drProcedimElegido.Item("codigo_ris").ToString, strEntidadsec)
                                        If dtExamenLabo.Rows.Count > 0 Then
                                            strExcepcion = dtExamenLabo.Rows(0).Item("excepcion").ToString()
                                            strProcedimlabo = dtExamenLabo.Rows(0).Item("procedim").ToString()
                                            strTipEntLabo = dtExamenLabo.Rows(0).Item("codentlabo").ToString()
                                            rsNew("procedim") = strProcedimlabo
                                            tieneConvenio = BLOrdenes.procedimientoTieneConvenio(datosConexion, strProcedimlabo, datosLogin.Prestador,
                                                                                        datosLogin.Sucursal, strEntidadsec, procedimhomologo, cmbCentroCosto.SelectedValue.ToString)

                                            If tieneConvenio = True Then
                                                'If strTipoEntidad = "EPS" Then
                                                If pide_SISPRO = "S" Then
                                                    'If MessageBox.Show("El procedimiento ordenado es no POS, por favor diligenciar la página de MIPRES", "Examenes de Laboratorio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                                                    '    Exit Sub
                                                    'End If
                                                Else
                                                    If MessageBox.Show("El procedimiento ordenado es no POS, por lo cual deberá diligenciar la justificación de realización para CTC", "Examenes de Laboratorio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                                                        Exit Sub
                                                    End If
                                                End If
                                                'End If
                                                Exit Do
                                            End If
                                        Else
                                            dtEntidad = DAOOrdenes.consultarEntidad(datosConexion, strEntidadsec)
                                            If dtEntidad.Rows.Count > 0 Then
                                                strTipoEntidad = dtEntidad.Rows(0).Item("tip_entidad").ToString
                                            End If
                                            strEntidadsec = datosPaciente.Entidad
                                        End If
                                    End If
                                End If
                            End If
                        Else
                            dtEntidad = DAOOrdenes.consultarEntidad(datosConexion, strEntidadsec)
                            If dtEntidad.Rows.Count > 0 Then
                                strTipoEntidad = dtEntidad.Rows(0).Item("tip_entidad").ToString
                            End If
                            strEntidadsec = datosPaciente.Entidad
                        End If
                        i = i + 1
                    Loop
                End If
                If Len(strEntidadsec) > 0 Then
                    dtEntidad = DAOOrdenes.consultarEntidad(datosConexion, strEntidadsec)
                    ''              dtEntidad = DAOOrdenes.consultarEntidad(datosConexion, datosPaciente.Entidad)
                    If dtEntidad.Rows.Count > 0 Then
                        If dtEntidad.Rows(0).Item("tip_entidad").ToString().Contains("PAR") = True Then
                            If tieneConvenio = True Then
                                If MessageBox.Show("EL plan de salud del paciente no cubre el examen de laboratorio ordenado, si lo ordena va a ser cobrado como PARTICULAR. Desea ordenarlo?", "Examenes de Laboratorio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If
                Else
                    strEntidadsec = datosPaciente.Entidad
                End If
                drProcedimElegido.Item("tip_proced") = Mid(strProcedimlabo, 1, 1)

                intTipoProced = Val(drProcedimElegido.Item("tip_proced").ToString)

                esHonorario = BLOrdenes.EsHonorarioVariable(datosLogin.Prestador, datosLogin.Sucursal, datosLogin.Login, datosLogin.CodigoEspecialidad, strProcedimlabo, strEntidadsec, FuncionesGenerales.FechaServidor(), 0)
                If BLOrdenes.generaPedidoProcedim(drProcedimElegido.Item("tip_proced").ToString, cmbCentroCosto.Text) Or esHonorario Then

                    'Inicia. Christian Gutierrez - OSI. 04/02/2020
                    'Descripción: Se corrige el Item seleccionado en el control para evaluar las Particularidades
                    '             segun el Cen. Costo Destino seleccionado
                    rsNew("cen_cos_des") = cmbCentroCosto.SelectedItem("cen_costo").ToString
                    'rsNew("cen_cos_des") = cmbCentroCosto.SelectedValue.ToString
                    'Fin. CCGUTIEREZ

                    rsNew("descri_cen_cos_des") = cmbCentroCosto.Text
                    rsNew("entidad") = strEntidadsec

                    If tieneConvenio Then
                        rsNew("grabaPedido") = "S"
                        rsNew("tieneConvenio") = "S"
                        rsNew("JustificaSinConve") = ""
                    Else

                        If datosPaciente.TipoEntidad.Contains("PAR") = False Then

                            ' Justificacion para no convenio. Honorario Variable, solicitud Clinica 2015/03/01
                            If esHonorario Then

                                If MsgBox("El procedimiento no está cubierto por la entidad de la admisión, para poder ordenarlo debe ingresar una justificacion (minimo 10 caracteres). Continua con la orden de este procedimiento? ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                                    Do
                                        frmc_JustificaExcepcionProc.ShowDialog()
                                        strJustificaSinConvenio = frmc_JustificaExcepcionProc.strJustificacion
                                    Loop Until Len(strJustificaSinConvenio) > 10 ' La justificacion debe tener minimo 10 caracteres
                                    rsNew("JustificaSinConve") = strJustificaSinConvenio
                                Else
                                    cmbCentroCosto.DataSource.Rows.Clear()
                                    cmbDescripProcedim.OrigenDeDatos.Rows.Clear()
                                    txtCodProcedim.Text = String.Empty
                                    tbCodTipoProcedim.Text = String.Empty
                                    tbDesTipoProc.Text = String.Empty
                                    'Joseph Moreno (IG) Fec:2019/11/21 Particularidades
                                    Me.ctlPartProce.Limpiar(True)
                                    cmbCentroCosto.Text = String.Empty
                                    txtCodProcedim.Focus()
                                    Exit Sub
                                End If
                            Else
                                MsgBox("El procedimiento no está cubierto por la entidad de la admisión")
                            End If
                        Else
                            MsgBox("El procedimiento no está cubierto por la entidad de la admisión")
                        End If
                        rsNew("grabaPedido") = "N"
                        rsNew("tieneConvenio") = "N"
                    End If
                Else
                    If Len(Trim(cmbCentroCosto.Text)) > 0 Then

                        'Inicia. Christian Gutierrez - OSI. 04/02/2020
                        'Descripción: Se corrige el Item seleccionado en el control para evaluar las Particularidades
                        '             segun el Cen. Costo Destino seleccionado
                        rsNew("cen_cos_des") = cmbCentroCosto.SelectedItem("cen_costo").ToString
                        'rsNew("cen_cos_des") = cmbCentroCosto.SelectedValue.ToString 'Is Nothing
                        'Fin. CCGUTIEREZ

                    Else
                        rsNew("cen_cos_des") = ""
                    End If

                    rsNew("grabaPedido") = "N"
                    'rsNew("cen_cos_des") = "" ''calcularSubgrupoProcedim(drProcedimElegido.Item("codigo").ToString)
                    If tieneConvenio = False And (intTipoProced <> 1 And intTipoProced <> 3) Then
                        MsgBox("El procedimiento no lo realiza la Sucursal y no está cubierto por la entidad de la admisión", MsgBoxStyle.Information)
                        rsNew("tieneConvenio") = "N"
                    ElseIf tieneConvenio = True And (intTipoProced <> 1 And intTipoProced <> 3) Then
                        MsgBox("El procedimiento no lo realiza la Sucursal.", MsgBoxStyle.Information)
                        rsNew("tieneConvenio") = "S"
                    Else
                        rsNew("tieneConvenio") = "S"
                    End If
                End If
            Else
                tieneConvenio = BLOrdenes.procedimientoTieneConvenio(datosConexion, strProcedimlabo, datosLogin.Prestador,
                                                            datosLogin.Sucursal, datosPaciente.Entidad, procedimhomologo, cmbCentroCosto.SelectedValue.ToString)

                If tieneConvenio Then
                    esHonorario = BLOrdenes.EsHonorarioVariable(datosLogin.Prestador, datosLogin.Sucursal, datosLogin.Login, datosLogin.CodigoEspecialidad, drProcedimElegido.Item("codigo").ToString, datosPaciente.Entidad, FuncionesGenerales.FechaServidor(), 0)
                    If BLOrdenes.generaPedidoProcedim(drProcedimElegido.Item("tip_proced").ToString, cmbCentroCosto.Text) Or esHonorario Then

                        'Inicia. Christian Gutierrez - OSI. 04/02/2020
                        'Descripción: Se corrige el Item seleccionado en el control para evaluar las Particularidades
                        '             segun el Cen. Costo Destino seleccionado
                        rsNew("cen_cos_des") = cmbCentroCosto.SelectedItem("cen_costo").ToString
                        'rsNew("cen_cos_des") = cmbCentroCosto.SelectedValue.ToString
                        'Fin. CCGUTIEREZ

                        rsNew("descri_cen_cos_des") = cmbCentroCosto.Text
                        rsNew("entidad") = datosPaciente.Entidad

                        If tieneConvenio Then
                            rsNew("grabaPedido") = "S"
                            rsNew("tieneConvenio") = "S"
                            rsNew("JustificaSinConve") = ""
                        End If
                    Else
                        If Len(Trim(cmbCentroCosto.Text)) > 0 Then

                            'Inicia. Christian Gutierrez - OSI. 04/02/2020
                            'Descripción: Se corrige el Item seleccionado en el control para evaluar las Particularidades
                            '             segun el Cen. Costo Destino seleccionado
                            rsNew("cen_cos_des") = cmbCentroCosto.SelectedItem("cen_costo").ToString
                            'rsNew("cen_cos_des") = cmbCentroCosto.SelectedValue.ToString 'Is Nothing
                            'Fin. CCGUTIEREZ

                        Else
                            rsNew("cen_cos_des") = ""
                        End If

                        rsNew("grabaPedido") = "N"
                        'rsNew("cen_cos_des") = "" ''calcularSubgrupoProcedim(drProcedimElegido.Item("codigo").ToString)
                        If tieneConvenio = False And (intTipoProced <> 1 And intTipoProced <> 3) Then
                            MsgBox("El procedimiento no lo realiza la Sucursal y no está cubierto por la entidad de la admisión", MsgBoxStyle.Information)
                            rsNew("tieneConvenio") = "N"
                        ElseIf tieneConvenio = True And (intTipoProced <> 1 And intTipoProced <> 3) Then
                            MsgBox("El procedimiento no lo realiza la Sucursal.", MsgBoxStyle.Information)
                            rsNew("tieneConvenio") = "S"
                        Else
                            rsNew("tieneConvenio") = "S"
                        End If
                    End If
                Else

                    If strTipEntLabo = "2" Then
                        'MsgBox("EPESRECO")
                        strEntidadsec = BLOrdenes.EpsRecobrable(datosConexion, datosPaciente.Entidad)
                        tieneEntidadRec = BLOrdenes.existeEntidadAdmadmentrec(datosConexion, datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.TipoAdmision, datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision, strEntidadsec)
                        If tieneEntidadRec = True Then
                            dtExamenLabo = DAOOrdenes.consultarExamenTipEnt(datosConexion, drProcedimElegido.Item("codigo_ris").ToString, strEntidadsec)
                            If dtExamenLabo.Rows.Count > 0 Then
                                strExcepcion = dtExamenLabo.Rows(0).Item("excepcion").ToString()
                                strProcedimlabo = dtExamenLabo.Rows(0).Item("procedim").ToString()
                                strTipEntLabo = dtExamenLabo.Rows(0).Item("codentlabo").ToString()
                                rsNew("procedim") = strProcedimlabo
                                tieneConvenio = BLOrdenes.procedimientoTieneConvenio(datosConexion, strProcedimlabo, datosLogin.Prestador,
                                                                            datosLogin.Sucursal, strEntidadsec, procedimhomologo, cmbCentroCosto.SelectedValue.ToString)

                                If tieneConvenio = True Then
                                    'If strTipoEntidad = "EPS" Then
                                    If pide_SISPRO = "S" Then
                                        'If MessageBox.Show("El procedimiento ordenado es no POS, por favor diligenciar la página de MIPRES", "Examenes de Laboratorio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                                        'Exit Sub
                                        'End If
                                    Else
                                        If MessageBox.Show("El procedimiento ordenado es no POS, por lo cual deberá diligenciar la justificación de realización para CTC", "Examenes de Laboratorio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                                            Exit Sub
                                        End If
                                    End If
                                    'End If                                     
                                Else
                                    dtAdmEnt = DAOOrdenes.consultarAdmisionEnt(datosConexion, datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.TipoAdmision,
                                                                               datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision, datosPaciente.Entidad)

                                    i = 0
                                    Do While i < dtAdmEnt.Rows.Count
                                        strEntidadsec = dtAdmEnt.Rows(i).Item("entidad").ToString()
                                        dtExamenLabo = DAOOrdenes.consultarExamenTipEnt(datosConexion, drProcedimElegido.Item("codigo_ris").ToString, strEntidadsec)
                                        If dtExamenLabo.Rows.Count > 0 Then
                                            strExcepcion = dtExamenLabo.Rows(0).Item("excepcion").ToString()
                                            strProcedimlabo = dtExamenLabo.Rows(0).Item("procedim").ToString()
                                            strTipEntLabo = dtExamenLabo.Rows(0).Item("codentlabo").ToString()

                                            rsNew("procedim") = strProcedimlabo
                                            tieneConvenio = BLOrdenes.procedimientoTieneConvenio(datosConexion, strProcedimlabo, datosLogin.Prestador,
                                                                                        datosLogin.Sucursal, strEntidadsec, procedimhomologo, cmbCentroCosto.SelectedValue.ToString)

                                            'If strExcepcion = "N" Then
                                            If tieneConvenio Then
                                                'tieneEpsReco = BLOrdenes.EpsRecobrable(datosConexion, strEntidadsec)
                                                'If tieneEpsReco Then
                                                '    If strTipoEntidad = "EPS" Then
                                                '        If MessageBox.Show("El procedimiento ordenado es no POS, por lo cual deberá diligenciar la justificación de realización para CTC", "Examenes de Laboratorio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                                                '            Exit Sub
                                                '        End If
                                                '    End If
                                                'End If
                                                Exit Do
                                                'End If
                                            Else
                                                If strTipEntLabo = "2" Then
                                                    'MsgBox("EPESRECO")
                                                    strEntidadsec = BLOrdenes.EpsRecobrable(datosConexion, strEntidadsec)
                                                    tieneEntidadRec = BLOrdenes.existeEntidadAdmadmentrec(datosConexion, datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.TipoAdmision, datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision, strEntidadsec)
                                                    If tieneEntidadRec = True Then
                                                        dtExamenLabo = DAOOrdenes.consultarExamenTipEnt(datosConexion, drProcedimElegido.Item("codigo_ris").ToString, strEntidadsec)

                                                        If dtExamenLabo.Rows.Count > 0 Then
                                                            strExcepcion = dtExamenLabo.Rows(0).Item("excepcion").ToString()
                                                            strProcedimlabo = dtExamenLabo.Rows(0).Item("procedim").ToString()
                                                            strTipEntLabo = dtExamenLabo.Rows(0).Item("codentlabo").ToString()
                                                            rsNew("procedim") = strProcedimlabo
                                                            tieneConvenio = BLOrdenes.procedimientoTieneConvenio(datosConexion, strProcedimlabo, datosLogin.Prestador,
                                                                                                        datosLogin.Sucursal, strEntidadsec, procedimhomologo, cmbCentroCosto.SelectedValue.ToString)

                                                            If tieneConvenio = True Then
                                                                'If strTipoEntidad = "EPS" Then
                                                                If pide_SISPRO = "S" Then
                                                                    'If MessageBox.Show("El procedimiento ordenado es no POS, por favor diligenciar la página de MIPRES", "Examenes de Laboratorio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                                                                    '    Exit Sub
                                                                    'End If
                                                                Else
                                                                    If MessageBox.Show("El procedimiento ordenado es no POS, por lo cual deberá diligenciar la justificación de realización para CTC", "Examenes de Laboratorio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                                                                        Exit Sub
                                                                    End If
                                                                End If
                                                                'End If
                                                                Exit Do
                                                            End If
                                                        Else
                                                            dtEntidad = DAOOrdenes.consultarEntidad(datosConexion, strEntidadsec)
                                                            If dtEntidad.Rows.Count > 0 Then
                                                                strTipoEntidad = dtEntidad.Rows(0).Item("tip_entidad").ToString
                                                            End If
                                                            strEntidadsec = datosPaciente.Entidad
                                                        End If
                                                    End If
                                                End If

                                            End If
                                        Else
                                            dtEntidad = DAOOrdenes.consultarEntidad(datosConexion, strEntidadsec)
                                            If dtEntidad.Rows.Count > 0 Then
                                                strTipoEntidad = dtEntidad.Rows(0).Item("tip_entidad").ToString
                                            End If
                                            strEntidadsec = datosPaciente.Entidad
                                        End If
                                        i = i + 1
                                    Loop


                                End If
                            Else
                                dtEntidad = DAOOrdenes.consultarEntidad(datosConexion, strEntidadsec)
                                If dtEntidad.Rows.Count > 0 Then
                                    strTipoEntidad = dtEntidad.Rows(0).Item("tip_entidad").ToString
                                End If
                                strEntidadsec = datosPaciente.Entidad
                            End If
                        Else
                            dtAdmEnt = DAOOrdenes.consultarAdmisionEnt(datosConexion, datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.TipoAdmision,
                                                                       datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision, datosPaciente.Entidad)

                            i = 0
                            Do While i < dtAdmEnt.Rows.Count
                                strEntidadsec = dtAdmEnt.Rows(i).Item("entidad").ToString()
                                dtExamenLabo = DAOOrdenes.consultarExamenTipEnt(datosConexion, drProcedimElegido.Item("codigo_ris").ToString, strEntidadsec)
                                If dtExamenLabo.Rows.Count > 0 Then
                                    strExcepcion = dtExamenLabo.Rows(0).Item("excepcion").ToString()
                                    strProcedimlabo = dtExamenLabo.Rows(0).Item("procedim").ToString()
                                    strTipEntLabo = dtExamenLabo.Rows(0).Item("codentlabo").ToString()

                                    rsNew("procedim") = strProcedimlabo
                                    tieneConvenio = BLOrdenes.procedimientoTieneConvenio(datosConexion, strProcedimlabo, datosLogin.Prestador,
                                                                                datosLogin.Sucursal, strEntidadsec, procedimhomologo, cmbCentroCosto.SelectedValue.ToString)

                                    If strExcepcion = "N" Then
                                        If tieneConvenio Then
                                            'tieneEpsReco = BLOrdenes.EpsRecobrable(datosConexion, strEntidadsec)
                                            'If tieneEpsReco Then
                                            '    If strTipoEntidad = "EPS" Then
                                            '        If MessageBox.Show("El procedimiento ordenado es no POS, por lo cual deberá diligenciar la justificación de realización para CTC", "Examenes de Laboratorio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                                            '            Exit Sub
                                            '        End If
                                            '    End If
                                            'End If
                                            Exit Do
                                        End If
                                    Else
                                        If strTipEntLabo = "2" Then
                                            'MsgBox("EPESRECO")
                                            strEntidadsec = BLOrdenes.EpsRecobrable(datosConexion, strEntidadsec)
                                            tieneEntidadRec = BLOrdenes.existeEntidadAdmadmentrec(datosConexion, datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.TipoAdmision, datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision, strEntidadsec)
                                            If tieneEntidadRec = True Then
                                                dtExamenLabo = DAOOrdenes.consultarExamenTipEnt(datosConexion, drProcedimElegido.Item("codigo_ris").ToString, strEntidadsec)

                                                If dtExamenLabo.Rows.Count > 0 Then
                                                    strExcepcion = dtExamenLabo.Rows(0).Item("excepcion").ToString()
                                                    strProcedimlabo = dtExamenLabo.Rows(0).Item("procedim").ToString()
                                                    strTipEntLabo = dtExamenLabo.Rows(0).Item("codentlabo").ToString()
                                                    rsNew("procedim") = strProcedimlabo
                                                    tieneConvenio = BLOrdenes.procedimientoTieneConvenio(datosConexion, strProcedimlabo, datosLogin.Prestador,
                                                                                                datosLogin.Sucursal, strEntidadsec, procedimhomologo, cmbCentroCosto.SelectedValue.ToString)

                                                    If tieneConvenio = True Then
                                                        'If strTipoEntidad = "EPS" Then
                                                        If pide_SISPRO = "S" Then
                                                            'If MessageBox.Show("El procedimiento ordenado es no POS, por favor diligenciar la página de MIPRES", "Examenes de Laboratorio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                                                            '    Exit Sub
                                                            'End If
                                                        Else
                                                            If MessageBox.Show("El procedimiento ordenado es no POS, por lo cual deberá diligenciar la justificación de realización para CTC", "Examenes de Laboratorio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                                                                Exit Sub
                                                            End If
                                                        End If
                                                        'End If
                                                        Exit Do
                                                    End If
                                                Else
                                                    dtEntidad = DAOOrdenes.consultarEntidad(datosConexion, strEntidadsec)
                                                    If dtEntidad.Rows.Count > 0 Then
                                                        strTipoEntidad = dtEntidad.Rows(0).Item("tip_entidad").ToString
                                                    End If
                                                    strEntidadsec = datosPaciente.Entidad
                                                End If
                                            End If
                                        End If

                                    End If
                                Else
                                    dtEntidad = DAOOrdenes.consultarEntidad(datosConexion, strEntidadsec)
                                    If dtEntidad.Rows.Count > 0 Then
                                        strTipoEntidad = dtEntidad.Rows(0).Item("tip_entidad").ToString
                                    End If
                                    strEntidadsec = datosPaciente.Entidad
                                End If
                                i = i + 1
                            Loop
                        End If
                    End If
                    'If strTipEntLabo = "1" Then
                    '    If strExcepcion = "S" Then
                    '        tieneConvenio = False
                    '        'Exit Sub
                    '    End If
                    'End If
                    dtEntidad = DAOOrdenes.consultarEntidad(datosConexion, strEntidadsec)
                    If dtEntidad.Rows.Count > 0 Then
                        If dtEntidad.Rows(0).Item("tip_entidad").ToString().Contains("PAR") = True Then
                            If MessageBox.Show("EL plan de salud del paciente no cubre el examen de laboratorio ordenado, si lo ordena va a ser cobrado como PARTICULAR. Desea ordenarlo?", "Examenes de Laboratorio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                                Exit Sub
                            End If
                        End If
                    End If
                    drProcedimElegido.Item("tip_proced") = Mid(strProcedimlabo, 1, 1)

                    intTipoProced = Val(drProcedimElegido.Item("tip_proced").ToString)

                    esHonorario = BLOrdenes.EsHonorarioVariable(datosLogin.Prestador, datosLogin.Sucursal, datosLogin.Login, datosLogin.CodigoEspecialidad, strProcedimlabo, strEntidadsec, FuncionesGenerales.FechaServidor(), 0)
                    If BLOrdenes.generaPedidoProcedim(drProcedimElegido.Item("tip_proced").ToString, cmbCentroCosto.Text) Or esHonorario Then

                        'Inicia. Christian Gutierrez - OSI. 04/02/2020
                        'Descripción: Se corrige el Item seleccionado en el control para evaluar las Particularidades
                        '             segun el Cen. Costo Destino seleccionado
                        rsNew("cen_cos_des") = cmbCentroCosto.SelectedItem("cen_costo").ToString
                        'rsNew("cen_cos_des") = cmbCentroCosto.SelectedValue.ToString
                        'Fin. CCGUTIEREZ

                        rsNew("descri_cen_cos_des") = cmbCentroCosto.Text
                        rsNew("entidad") = strEntidadsec

                        If tieneConvenio Then
                            rsNew("grabaPedido") = "S"
                            rsNew("tieneConvenio") = "S"
                            rsNew("JustificaSinConve") = ""
                        Else
                            If datosPaciente.TipoEntidad.Contains("PAR") = False Then
                                ' Justificacion para no convenio. Honorario Variable, solicitud Clinica 2015/03/01
                                If esHonorario Then
                                    If MsgBox("El procedimiento no está cubierto por la entidad de la admisión, para poder ordenarlo debe ingresar una justificacion (minimo 10 caracteres). Continua con la orden de este procedimiento? ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                                        Do
                                            frmc_JustificaExcepcionProc.ShowDialog()
                                            strJustificaSinConvenio = frmc_JustificaExcepcionProc.strJustificacion
                                        Loop Until Len(strJustificaSinConvenio) > 10 ' La justificacion debe tener minimo 10 caracteres
                                        rsNew("JustificaSinConve") = strJustificaSinConvenio
                                    Else
                                        cmbCentroCosto.DataSource.Rows.Clear()
                                        cmbDescripProcedim.OrigenDeDatos.Rows.Clear()
                                        txtCodProcedim.Text = String.Empty
                                        tbCodTipoProcedim.Text = String.Empty
                                        tbDesTipoProc.Text = String.Empty
                                        'Joseph Moreno (IG) Fec:2019/11/21 Particularidades
                                        Me.ctlPartProce.Limpiar(True)
                                        cmbCentroCosto.Text = String.Empty
                                        txtCodProcedim.Focus()
                                        Exit Sub
                                    End If
                                Else
                                    MsgBox("El procedimiento no está cubierto por la entidad de la admisión")
                                End If
                            Else
                                MsgBox("El procedimiento no está cubierto por la entidad de la admisión")
                            End If
                            'MsgBox("El procedimiento no está cubierto por la entidad de la admisión")
                            rsNew("grabaPedido") = "N"
                            rsNew("tieneConvenio") = "N"
                        End If
                    Else
                        If Len(Trim(cmbCentroCosto.Text)) > 0 Then

                            'Inicia. Christian Gutierrez - OSI. 04/02/2020
                            'Descripción: Se corrige el Item seleccionado en el control para evaluar las Particularidades
                            '             segun el Cen. Costo Destino seleccionado
                            rsNew("cen_cos_des") = cmbCentroCosto.SelectedItem("cen_costo").ToString
                            'rsNew("cen_cos_des") = cmbCentroCosto.SelectedValue.ToString 'Is Nothing
                            'Fin. CCGUTIEREZ

                        Else
                            rsNew("cen_cos_des") = ""
                        End If

                        rsNew("grabaPedido") = "N"
                        'rsNew("cen_cos_des") = "" ''calcularSubgrupoProcedim(drProcedimElegido.Item("codigo").ToString)
                        If tieneConvenio = False And (intTipoProced <> 1 And intTipoProced <> 3) Then
                            MsgBox("El procedimiento no lo realiza la Sucursal y no está cubierto por la entidad de la admisión", MsgBoxStyle.Information)
                            rsNew("tieneConvenio") = "N"
                        ElseIf tieneConvenio = True And (intTipoProced <> 1 And intTipoProced <> 3) Then
                            MsgBox("El procedimiento no lo realiza la Sucursal.", MsgBoxStyle.Information)
                            rsNew("tieneConvenio") = "S"
                        Else
                            rsNew("tieneConvenio") = "S"
                        End If
                    End If

                End If
            End If

            If BLOrdenes.Valida_ordenes_examen_laboratorio(datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.TipoAdmision, datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision, strProcedimlabo) = True Then
            Else
                tbCodTipoProcedim_Validating(Me.tbCodTipoProcedim, New System.ComponentModel.CancelEventArgs())
                txtCantidad.Text = 1
                cmbCentroCosto.DataSource.Rows.Clear()
                cmbDescripProcedim.OrigenDeDatos.Rows.Clear()
                tbCodTipoProcedim.Focus()
                tbCodTipoProcedim.Text = String.Empty
                tbDesTipoProc.Text = String.Empty
                'Joseph Moreno (IG) Fec:2019/11/21 Particularidades
                Me.ctlPartProce.Limpiar(True)
                cmbCentroCosto.Text = String.Empty
                txtObsProcedim.Text = String.Empty
                Exit Sub
            End If


        Else
            rsNew("tieneCcostoLabo") = "N"
            If Len(Trim(cmbCentroCosto.Text)) > 0 Then

                'Inicia. Christian Gutierrez - OSI. 04/02/2020
                'Descripción: Se corrige el Item seleccionado en el control para evaluar las Particularidades
                '             segun el Cen. Costo Destino seleccionado
                rsNew("cen_cos_des") = cmbCentroCosto.SelectedItem("cen_costo").ToString
                'rsNew("cen_cos_des") = cmbCentroCosto.SelectedValue.ToString 'Is Nothing
                'Fin. CCGUTIEREZ

            Else
                rsNew("cen_cos_des") = ""
            End If

            If Len(rsNew("cen_cos_des")) > 0 Then
                tieneConvenio = BLOrdenes.procedimientoTieneConvenio(datosConexion, drProcedimElegido.Item("codigo").ToString,
               datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.Entidad, procedimhomologo, cmbCentroCosto.SelectedValue.ToString)
            Else
                tieneConvenio = BLOrdenes.procedimientoTieneConvenio(datosConexion, drProcedimElegido.Item("codigo").ToString,
           datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.Entidad, procedimhomologo, "")

            End If


            'End If
            intTipoProced = Val(drProcedimElegido.Item("tip_proced").ToString)
            'If tieneConvenio = False And (intTipoProced <> 1 And intTipoProced <> 3) Then
            '    MsgBox("El procedimiento no tiene convenio. Haga una orden manual y reporte el procedimiento para ser parametrizado a un convenio", MsgBoxStyle.Information)
            '    tbCodTipoProcedim.Text = String.Empty            
            '    tbDesTipoProc.Text = String.Empty
            '    cmbCentroCosto.Text = String.Empty
            '    txtObsProcedim.Text = String.Empty
            '    txtCodProcedim.Text = String.Empty
            '    cmbDescripProcedim.Text = String.Empty

            '    If tb_Guia.Enabled = True Then
            '        tb_Guia.Text = String.Empty
            '        tb_Justi.Text = String.Empty
            '    End If

            '    Exit Sub
            'End If




            esHonorario = BLOrdenes.EsHonorarioVariable(datosLogin.Prestador, datosLogin.Sucursal, datosLogin.Login, datosLogin.CodigoEspecialidad, drProcedimElegido.Item("codigo").ToString, datosPaciente.Entidad, FuncionesGenerales.FechaServidor(), 0)
            If BLOrdenes.generaPedidoProcedim(drProcedimElegido.Item("tip_proced").ToString, cmbCentroCosto.Text) Or esHonorario Then

                'Inicia. Christian Gutierrez - OSI. 04/02/2020
                'Descripción: Se corrige el Item seleccionado en el control para evaluar las Particularidades
                '             segun el Cen. Costo Destino seleccionado
                rsNew("cen_cos_des") = cmbCentroCosto.SelectedItem("cen_costo").ToString
                'rsNew("cen_cos_des") = cmbCentroCosto.SelectedValue.ToString
                'Fin. CCGUTIEREZ

                rsNew("descri_cen_cos_des") = cmbCentroCosto.Text
                rsNew("entidad") = datosPaciente.Entidad

                If tieneConvenio Then
                    rsNew("grabaPedido") = "S"
                    rsNew("tieneConvenio") = "S"
                    rsNew("JustificaSinConve") = ""
                Else
                    If datosPaciente.TipoEntidad.Contains("PAR") = False Then
                        ' Justificacion para no convenio. Honorario Variable, solicitud Clinica 2015/03/01
                        If esHonorario Then
                            If MsgBox("El procedimiento no está cubierto por la entidad de la admisión, para poder ordenarlo debe ingresar una justificacion (minimo 10 caracteres). Continua con la orden de este procedimiento? ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                                Do
                                    frmc_JustificaExcepcionProc.ShowDialog()
                                    strJustificaSinConvenio = frmc_JustificaExcepcionProc.strJustificacion
                                Loop Until Len(strJustificaSinConvenio) > 10 ' La justificacion debe tener minimo 10 caracteres
                                rsNew("JustificaSinConve") = strJustificaSinConvenio
                            Else
                                cmbCentroCosto.DataSource.Rows.Clear()
                                cmbDescripProcedim.OrigenDeDatos.Rows.Clear()
                                txtCodProcedim.Text = String.Empty
                                tbCodTipoProcedim.Text = String.Empty
                                'Joseph Moreno (IG) Fec:2019/11/21 Particularidades
                                Me.ctlPartProce.Limpiar(True)
                                tbDesTipoProc.Text = String.Empty
                                cmbCentroCosto.Text = String.Empty
                                txtCodProcedim.Focus()
                                Exit Sub
                            End If
                        Else
                            MsgBox("El procedimiento no está cubierto por la entidad de la admisión")
                        End If
                    End If
                    rsNew("grabaPedido") = "N"
                    rsNew("tieneConvenio") = "N"
                End If
            Else
                If Len(Trim(cmbCentroCosto.Text)) > 0 Then

                    'Inicia. Christian Gutierrez - OSI. 04/02/2020
                    'Descripción: Se corrige el Item seleccionado en el control para evaluar las Particularidades
                    '             segun el Cen. Costo Destino seleccionado
                    rsNew("cen_cos_des") = cmbCentroCosto.SelectedItem("cen_costo").ToString
                    'rsNew("cen_cos_des") = cmbCentroCosto.SelectedValue.ToString 'Is Nothing
                    'Fin. CCGUTIEREZ

                Else
                    rsNew("cen_cos_des") = ""
                End If

                rsNew("grabaPedido") = "N"
                'rsNew("cen_cos_des") = "" ''calcularSubgrupoProcedim(drProcedimElegido.Item("codigo").ToString)
                If tieneConvenio = False And (intTipoProced <> 1 And intTipoProced <> 3) Then
                    MsgBox("El procedimiento no lo realiza la Sucursal y no está cubierto por la entidad de la admisión", MsgBoxStyle.Information)
                    rsNew("tieneConvenio") = "N"
                ElseIf tieneConvenio = True And (intTipoProced <> 1 And intTipoProced <> 3) Then
                    MsgBox("El procedimiento no lo realiza la Sucursal.", MsgBoxStyle.Information)
                    rsNew("tieneConvenio") = "S"
                Else
                    rsNew("tieneConvenio") = "S"
                End If
            End If
        End If

        dtEntidad = DAOOrdenes.consultarEntidad(datosConexion, strEntidadsec)
        If dtEntidad.Rows.Count > 0 Then
            strTipoEntidad = dtEntidad.Rows(0).Item("tip_entidad").ToString
        Else
            strTipoEntidad = datosPaciente.TipoEntidad.ToString()
        End If

        'dtProc = daoGeneral.EjecutarSQLConParametros("genproce (NOLOCK)", datosConexion, "flag_pos, codSISPRO, desSISPRO", "procedim='" & rsNew("procedim") & "'")
        '--Joseph G. Moreno Campos (IG) Fec:2018/12/05 cambio tabla Genproce -> VW_GENPROCE_DES Proy:Codificación
        dtProc = daoGeneral.EjecutarSQLConParametros("VW_GENPROCE_DES (NOLOCK)", datosConexion, "flag_pos, codSISPRO, desSISPRO", "procedim='" & rsNew("procedim") & "'" & String.Format(" AND CONVERT(DATE, '{0}') BETWEEN fec_ini_proce AND fec_fin_proce ", Format(DateTime.Now, "yyyy-MM-dd")))



        '' validacion SISPRO
        If pide_SISPRO = "S" And strTipoEntidad = "EPS" Then
            'flag_pos = IIf(IsDBNull(drProcedimElegido.Item("flag_pos").ToString), "S", drProcedimElegido.Item("flag_pos").ToString)
            flag_pos = IIf(IsDBNull(dtProc.Rows(0).Item("flag_pos").ToString), "S", dtProc.Rows(0).Item("flag_pos").ToString)
            If flag_pos = "N" Then
                flag_posCondicionado = BLOrdenes.existePosCondicionado(datosConexion, datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.TipoAdmision, datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision, "P", rsNew("procedim"))
                If flag_posCondicionado = True Then
                    cod_Sispro = "POS Condicionado"
                    MsgBox("El elemento prescrito es POS Condicionado por Diagnóstico", MsgBoxStyle.Information, "Procedimientos")
                Else
                    'Resolucion 084 RJMAESTRE CU16 - 16-07-2021
                    'If MessageBox.Show("El procedimiento ordenado es no POS, por favor diligenciar la página de MIPRES", "Examenes de Laboratorio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                    'Exit Sub
                    'Else
                    System.Diagnostics.Process.Start(pag_SISPRO)
                    frm_SISPRO.Mostrar(cod_Sispro)
                    cod_Sispro = frm_SISPRO.Cod_SISPRO1
                    'End If
                End If
            End If

        End If

        If flag_pos = "N" Then
            rsNew("CodSISPRO") = dtProc.Rows(0).Item("codsispro").ToString
            rsNew("DesSISPRO") = dtProc.Rows(0).Item("dessispro").ToString
            rsNew("autoSISPRO") = cod_Sispro

        Else
            rsNew("CodSISPRO") = ""
            rsNew("DesSISPRO") = ""
            rsNew("autoSISPRO") = ""
        End If

        dtProInterconsulta = ValidaProcedimientoInterconsulta(rsNew("procedim"))
        If dtProInterconsulta.Rows.Count > 0 Then
            If dtProInterconsulta.Rows(0)("MENSAJERTA") = "" Then
                rsNew("EstadoInterconsulta") = 1
            Else
                MessageBox.Show(dtProInterconsulta.Rows(0)("MENSAJERTA").ToString(), "Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        Else
            rsNew("EstadoInterconsulta") = Nothing
        End If


        ''SE ADICIONA EL REGISTRO A LA GRILLA
        dtdatos.Rows.Add(rsNew)
        dtgProcedimientos.DataSource = dtdatos
        LimpiarPanel(panelProce, Me.tbCodTipoProcedim)
        InhabilitarSegunPais()
        If Len(Trim(tb_Guia.Text)) > 0 Then
            Me.tb_Guia.Enabled = False
            Me.tb_Justi.Enabled = False
        End If
        Me.GroupPriori.Enabled = False
        Me.GroupServi.Enabled = False
        tbCodTipoProcedim_Validating(Me.tbCodTipoProcedim, New System.ComponentModel.CancelEventArgs())
        txtCantidad.Text = 1
        cmbCentroCosto.DataSource.Rows.Clear()
        cmbDescripProcedim.OrigenDeDatos.Rows.Clear()
        tbCodTipoProcedim.Focus()
        tbCodTipoProcedim.Text = String.Empty
        tbDesTipoProc.Text = String.Empty
        'Joseph Moreno (IG) Fec:2019/11/21 Particularidades
        Me.ctlPartProce.Limpiar(True)
        cmbCentroCosto.Text = String.Empty
        Me.datosSinAlmacenar = True
        'Joseph Moreno (IG) Fec:2019/11/20 Particularidades
        Me.ctlPartProce.Limpiar(True)
    End Sub

    Private Function ValidaProcedimientoInterconsulta(ByVal IdProcedimiento As String) As DataTable
        Dim Objev As New BLEvolucion
        Dim Param() As Object
        Dim lError As Long

        ReDim Param(6)
        Param(0) = datosLogin.Prestador
        Param(1) = datosLogin.Sucursal
        Param(2) = datosPaciente.TipoAdmision
        Param(3) = datosPaciente.AnoAdmision
        Param(4) = datosPaciente.NumeroAdmision
        Param(5) = IdProcedimiento
        Param(6) = datosLogin.CodigoEspecialidad
        Try
            Return Objev.ConsultarProcedimientoInterconsultas(datosConexion, lError, Param)
        Catch ex As Exception
            MsgBox("Error en la consulta del procedimiento de interconsulta. " & ex.Message, MsgBoxStyle.Information)
        End Try

    End Function

    Private Sub tbCodTipoProcedim_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbCodTipoProcedim.Enter
        Ivalidacc = 0
        Me.txtObsProcedim.Clear()
        Me.txtCodProcedim.Clear()
        Me.cmbDescripProcedim.SelectedIndex = -1
        Me.cmbDescripProcedim.Text = ""
        If Not Me.cmbCentroCosto.DataSource Is Nothing Then
            Me.cmbCentroCosto.DataSource.Rows.Clear()
        End If
    End Sub

    Private Sub tbCodProc_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodProcedim.Validating, cmbDescripProcedim.Validating



        If (Not Me.txtCodProcedim.Text.Trim.Equals(String.Empty)) And (Not Me.cmbDescripProcedim.Text.Trim.Equals(String.Empty)) Then
            If tbCodTipoProcedim.Text.Trim.Equals(String.Empty) Then
                Me.tbCodTipoProcedim.Text = Me.txtCodProcedim.Text.Trim().Substring(0, 1)
                cmbDescripProcedim.CodigoTipoProcedimiento = Me.tbCodTipoProcedim.Text
                Me.tbDesTipoProc.Text = Me.tbCodTipoProcedim.DescripcionCodigo
            ElseIf Not (Me.tbCodTipoProcedim.Text.Equals(Me.txtCodProcedim.Text.Substring(0, 1)) And (Not Me.txtCodProcedim.Text.Equals(""))) Then
                'MessageBox.Show("El Procedimiento no corresponde al tipo de procedimiento " & Me.tbCodTipoProcedim.Text, "Procedimietos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                tbCodTipoProcedim.Clear()
                ''cpgaray ya no se amarra el tipo de procedimiento al codigo
                'Me.txtCodProcedim.Clear()
                'Me.cmbDescripProcedim.SelectedIndex = -1
                'Me.cmbDescripProcedim.Text = ""
                'e.Cancel = True
            End If
        End If

    End Sub

    Private Sub tbCodTipoProcedim_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbDesTipoProc.Validating, tbCodTipoProcedim.Validating


        If Not (Me.tbCodTipoProcedim.ReadOnly Or Me.tbDesTipoProc.ReadOnly) Then
            If Me.tbCodTipoProcedim.Text = String.Empty And Me.tbDesTipoProc.Text = String.Empty Then
                Me.txtCodProcedim.Clear()
                Me.cmbDescripProcedim.SelectedIndex = -1
                Exit Sub
            Else
                If Me.tbDesTipoProc.Text.Equals(String.Empty) And (Not Me.tbCodTipoProcedim.Text = String.Empty) Then
                    cmbDescripProcedim.CodigoTipoProcedimiento = Me.tbCodTipoProcedim.Text
                    Me.tbDesTipoProc.Text = Me.tbCodTipoProcedim.DescripcionCodigo
                    If (Me.tbDesTipoProc.Text = String.Empty) Then
                        If (Not (Me.tbCodTipoProcedim.Focused Or Me.tbDesTipoProc.BotonBusqueda.Focused)) Then
                            MessageBox.Show("El Tipo de Procedimiento es invalido.", "Historia Clinica", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            e.Cancel = True
                        End If
                    End If
                End If
            End If
        End If

        Me.cmbDescripProcedim.CodigoTipoProcedimiento = Me.tbCodTipoProcedim.Text
    End Sub

    Private Sub cmbDescripProcedim_ActualizarDatosElegidos(ByVal datosElegidos As System.Data.DataRow) Handles cmbDescripProcedim.ActualizarDatosElegidos

        If (datosElegidos Is Nothing) Then
            Me.tbCodTipoProcedim.Focus()
            'Joseph Moreno (IG) Fec:2019/11/20 Particularidades
            Me.ctlPartProce.Limpiar(True)
        Else
            cargarComboCentroCostoDestino()

            'Inicia: CCGUTIEREZ - OSI. 28/01/2020
            'Proyecto: Sophia - Codificacion
            'Cambio: Se inactiva bloque. Las particularidades se visualizan de acuerdo al Cen. Costo Destino y el parametro " man_csh "
            'Joseph Moreno (IG) Fec:2019/11/20 Particularidades
            'If txtCodProcedim.Text <> String.Empty Then
            '    Me.ctlPartProce.PasarDatos(
            '    txtCodProcedim.Text, cmbDescripProcedim.Text,
            '    Sub(ByVal strDescripcionTotal As String, ByVal iCantidad As String, ByVal strXmlParticularidades As String, ByVal strXmlProcedimientos As String)
            '        ActualizarTextoDescripcionCantidad(strDescripcionTotal, iCantidad)
            '    End Sub)
            'End If
            'Fin. CCGUTIEREZ

        End If
    End Sub

    'Joseph Moreno (IG) Fec:2019/11/20 Particularidades
    Private Sub ActualizarTextoDescripcionCantidad(ByVal strDescripcionTotal As String, ByVal iCantidad As Integer)
        cmbDescripProcedim.Text = strDescripcionTotal
        txtCantidad.Text = IIf(iCantidad > 0, iCantidad, txtCantidad.Text)
        ''txtCantidad.Text = iCantidad
    End Sub

    'Private Sub cmbDescripProcedim_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDescripProcedim.SelectedIndexChanged
    '    cargarComboCentroCostoDestino()
    'End Sub

    Private Sub cargarComboCentroCostoDestino()
        Dim dtDatos As DataTable

        Dim objDao As New DAOOrdenes
        Dim intTipoProced As Integer

        'If Ivalidacc = 1 Then
        '    Exit Sub
        'End If

        If Me.txtCodProcedim.Text.Trim.Length <= 0 Then
            Exit Sub
        End If

        '--Joseph G. Moreno Campos (IG) Fec:2018/12/05 cambio tabla Genproce -> VW_GENPROCE_DES 
        '--Proy: Codificación. Se consulta el tipo de procedimiento para no hacer substring 
        Dim objDaoP As New DAOGeneral
        Dim dtProcTip_Proced As DataTable

        dtProcTip_Proced = objDaoP.EjecutarSQLConParametros("VW_GENPROCE_DES (NOLOCK)", datosConexion, "tip_proced,flag_pos, codSISPRO, desSISPRO", "procedim='" & txtCodProcedim.Text & "'" & String.Format(" AND CONVERT(DATE, '{0}') BETWEEN fec_ini_proce AND fec_fin_proce ", Format(DateTime.Now, "yyyy-MM-dd")))

        If dtProcTip_Proced.Rows.Count >= 1 Then
            intTipoProced = dtProcTip_Proced.Rows(0).Item("tip_proced").ToString()
        End If

        ''intTipoProced = Mid(txtCodProcedim.Text, 1, 1)

        ''Consultamos el centro de costo Origen dependiendo del tipo de admision cpgaray Junio 2011
        strCentroCostoOrigen = objDao.consultarCCOrigen(datosConexion, datosLogin.Prestador, datosLogin.Sucursal, datosPaciente.TipoAdmision, datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision, datosPaciente.Entidad)
        ' _Ordenes.ccOrigen_Proce = strCentroCostoOrigen ''Cpgaray Octubre 24 de 2011 Enviar a RIS

        If strCentroCostoOrigen = "" And (intTipoProced <> 1 And intTipoProced <> 3) Then
            MsgBox("No existe Centro de Costo Origen parametrizado para el procedimiento. Consulte con el Administrador de Sophia", MsgBoxStyle.Information)
            'Ivalidacc = 1
            txtCodProcedim.Text = String.Empty
            cmbDescripProcedim.Text = String.Empty
            tbCodTipoProcedim.Text = String.Empty
            'Joseph Moreno (IG) Fec:2019/11/20 Particularidades
            Me.ctlPartProce.Limpiar()
            Exit Sub
        End If

        With cmbCentroCosto
            .BeginUpdate()
            dtDatos = BLOrdenes.consultarCentroCostoDestinoXProcedim(datosConexion, datosLogin.Prestador, datosLogin.Sucursal, Me.txtCodProcedim.Text, strCentroCostoOrigen)

            ''Se agrega siempre +1 Row para controlar la visualizacion de las Particularidades
            ''Mesa de trabajo. 15/10/2021
            If dtDatos.Rows.Count >= 1 Then
                dtDatos.Rows.InsertAt(dtDatos.NewRow(), 0)
                Label3.Visible = True
            End If

            .DataSource = dtDatos
            .DisplayMember = "descripcion"
            .ValueMember = "cen_costo"

            'Inicia: CCGUTIEREZ - OSI. 28/01/2020
            'Proyecto: Sophia - Codificacion
            'Cambio: Se agrega el parametro " man_csh " para controlar la visualizacion de las Particularidades
            .ValueMember = "man_csh" 'CCGUTIEREZ
            .ValueMember = "proceRIS"
            'Fin. CCGUTIEREZ

            .EndUpdate()

            'If dtDatos.Rows.Count >= 1 Then
            '    dtDatos.Rows.InsertAt(dtDatos.NewRow(), 0)
            '    '' cmbCentroCosto.Visible = True ''cpgaray junio 2011
            '    Label3.Visible = True
            'Else
            '    ''  cmbCentroCosto.Visible = False ''cpgaray junio 2011
            '    ''Label3.Visible = False
            'End If

        End With

    End Sub
    Public Function procedimientoSeleccionadoCombo() As DataRow
        Dim dtSeleccionCombo As DataTable
        Dim arrayConsulta() As DataRow

        'DATA TABLE RESULTADO DE LA BUSQUEDA 
        dtSeleccionCombo = Me.cmbDescripProcedim.OrigenDeDatos


        If dtSeleccionCombo Is Nothing Then
            MsgBox("Debe digitar la información del procedimiento.", MsgBoxStyle.Information)
            Return Nothing
        End If

        If Me.txtCodProcedim.Text.Trim.Length <= 0 Or Me.cmbDescripProcedim.Text.Trim.Length <= 0 Then
            Return Nothing
        End If

        '--Joseph G. Moreno Campos (IG) Fec:2018/12/05. Proy: Codificación
        '--Se corrige el parametro para la consulta 
        arrayConsulta = dtSeleccionCombo.Select("codigo = '" & Me.txtCodProcedim.Text & "'")
        ''arrayConsulta = dtSeleccionCombo.Select("codigo = " & Me.txtCodProcedim.Text)

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

    Private Sub cmbCentroCosto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCentroCosto.KeyPress
        Select Case e.KeyChar
            Case Convert.ToChar(Keys.Return)
                Me.GetNextControl(cmbCentroCosto, True).Focus()
                e.Handled = True
        End Select
    End Sub

    Private Function puedeAdicionarRegistroProcedimientos(ByVal drFila As DataRow) As Boolean
        ''Validacion del tamaño maximo que se puede pasar al 
        ''stored procedure que guarda la orden
        Dim tamano As Integer

        tamano = _tamanoXmlProcedim

        If drFila.RowState <> DataRowState.Modified Then
            tamano += BLOrdenes.tamanoFilaXmlProcedim(drFila, dtgProcedimientos.DataSource)
        End If

        If tamano > 8000 Then
            MsgBox("No se puede adicionar este registro pues se excede el número maximo de registros a grabar.")
            Return False
        Else
            _tamanoXmlProcedim = tamano
            Return True
        End If

    End Function

    Public Function calcularSubgrupoProcedim(ByVal strCodigo As String) As String
        Dim objProcedim As New HistoriaClinica.Sophia.HistoriaClinica.Reportes.Procedimiento

        objProcedim.Codigo = strCodigo
        objProcedim.calcularSubgrupo()
        Return objProcedim.SubGrupo

    End Function

#End Region

#Region "Ordenes Generales"

    Public Sub configurarGrillaGenerales(ByVal dtGenerales As DataTable)
        With dtgGenerales
            .DataSource = dtGenerales
            .Columns("cod_pre_sgs").Visible = False
            .Columns("cod_sucur").Visible = False
            .Columns("tip_admision").Visible = False
            .Columns("num_adm").Visible = False
            .Columns("ano_adm").Visible = False
            .Columns("NroOrden").Visible = False
            .Columns("Secuencia").Visible = False
            '.Columns("Tratamiento").Visible = False
            .Columns("medico").Visible = False
            .Columns("estado").Visible = False
            .Columns("login").Visible = False
            .Columns("obs").Visible = False
            .Columns("orden").Visible = False
            .Columns("frecuencia").Visible = True
            .Columns("Observaciones").Visible = True
            .Columns("cada").Visible = False
            .Columns("tiempo").Visible = False
            ''  .Columns("Orden").Visible = False  ''Claudia Garay Julio 19 de 2010
        End With
    End Sub

    ''' <summary>
    ''' Agrega los datos digitados por el usuario a la grilla de ordenes generales para su posterior 
    ''' almacenamiento. Valida que se digite la descripcion de la orden.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>TxtDescripOrden
    Private Sub btnAdicionarGenerales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdicionarGenerales.Click

        'ALM 166 20200303 raul Cruz
        If ValidarDatosHisBasica() Then
            Exit Sub
        End If

        Dim dtDatos As DataTable
        Dim mensaje As String = String.Empty
        Dim drNew As DataRow
        Dim dtResult As New DataTable


        'VALIDACIONESCmbindicaciones
        If dtgGenerales.DataSource Is Nothing Then
            MsgBox("Error en la carga de los datos a la grilla.", MsgBoxStyle.Information)
            Exit Sub
        End If

        If Len(Trim(txttiporden.Text)) <= 0 Or Len(Trim(Cmbindicaciones.Text)) <= 0 Then
            MsgBox("Registro inválido seleccione la Indicacion.", MsgBoxStyle.Information)
            Exit Sub
        End If


        dtResult = BLOrdenes.ConsultaIndicaciones(txttiporden.Text)
        If dtResult.Rows.Count > 0 Then
            Cmbindicaciones.Text = dtResult.Rows(0)("descripcion").ToString() ''martovar se vuelve a cargar el texto para que no lo modifique el usuario.
            If dtResult.Rows(0)("periodicidad").ToString() = "S" Then
                If (txtcada.Text = "" Or Len(Me.Cmbtiempo.SelectedValue) = 0) Then
                    MsgBox("Falta indicar la frecuencia para esta indicación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If
        Else
            MsgBox("Registro inválido seleccione la Indicacion.", MsgBoxStyle.Information)
            Exit Sub
        End If



        dtDatos = dtgGenerales.DataSource

        'CREA LA NUEVA FILA
        drNew = dtDatos.NewRow

        drNew("cod_pre_sgs") = datosLogin.Prestador
        drNew("cod_sucur") = datosLogin.Sucursal
        drNew("tip_admision") = datosPaciente.TipoAdmision
        drNew("num_adm") = datosPaciente.NumeroAdmision
        drNew("ano_adm") = datosPaciente.AnoAdmision
        drNew("NroOrden") = 0



        If Me.Cmbindicaciones.Text = "OXIGENO" Then
            drNew("TextoOrden") = Cmbindicaciones.Text & ". " & Cmbindicaciones.Text

        ElseIf Cmbindicaciones.Text = "OTROS" Then
            drNew("TextoOrden") = Cmbindicaciones.Text
        Else
            drNew("TextoOrden") = Cmbindicaciones.Text
        End If



        ''drNew("descripcion") = TxtDescripOrden.Text
        drNew("Tratamiento") = Nothing
        drNew("medico") = datosLogin.Login
        drNew("Orden") = txttiporden.Text
        drNew("estado") = BLOrdenes.ACTIVO
        'Try
        drNew("fec_con") = FuncionesGenerales.FechaServidor()
        'Catch ex As Exception
        '    MsgBox("Error en la consulta de la fecha del servidor. ", MsgBoxStyle.Information)
        'End Try

        drNew("login") = datosLogin.Login
        drNew("observaciones") = txtTextoOrden.Text
        drNew("nombreMedico") = datosLogin.NombreMedico
        drNew("especialidad") = datosLogin.DescripcionEspecialidad
        drNew("obs") = txtTextoOrden.Text

        ''martovar ER_OSI_596_Indicaciones_Medicas 2017/09/25
        drNew("Frecuencia") = txtcada.Text & " " & Me.Cmbtiempo.Text
        If Len(txtcada.Text) > 0 Then
            drNew("cada") = txtcada.Text
        Else
            drNew("cada") = 0
        End If
        If Len(Me.Cmbtiempo.SelectedValue) > 0 Then
            drNew("tiempo") = Me.Cmbtiempo.SelectedValue
        Else
            drNew("tiempo") = 0
        End If


        If Not BLOrdenes.validarGenerales(drNew, dtDatos, mensaje) Then
            ''If Not BLOrdenes.validarGenerales(txtTextoOrden.Text, dtDatos, mensaje) Then
            If Not BLOrdenes.validarGenerales(drNew, dtDatos, mensaje) Then
                MsgBox(mensaje, MsgBoxStyle.Information)
                Exit Sub
            End If
        End If

        dtDatos.Rows.Add(drNew)
        LimpiarPanel(panelGeneral, Nothing)
        txtTextoOrden.Focus()
        Me.datosSinAlmacenar = True
        Me.txtcada.Text = ""
        Me.Cmbtiempo.Text = ""
        Cmbtiempo.ResetText()
        Me.Cmbtiempo.SelectedValue = 0
    End Sub

    Private Sub dtgGenerales_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgGenerales.CellContentClick
        Dim dtDatos As DataTable = dtgGenerales.DataSource


        If Not BLOrdenes.puedeModificarTratamiento(dtDatos.Rows(e.RowIndex)) Then
            Exit Sub
        End If

        If Not e.RowIndex = -1 Then
            If dtgGenerales.CurrentCell.ColumnIndex = dtgGenerales.Columns("continuar_gen").Index Then '' COLUMNA CONTINUAR
                'If puedeAdicionarRegistroOrdenGeneral(dtDatos.Rows(e.RowIndex)) Then El campo en la base de datos es text por lo que esta validacion no tiene sentido 484950-20121227 cpgaray Enero 4 2013
                BLOrdenes.actualizarEstado(dtDatos.Rows(e.RowIndex), BLOrdenes.CONTINUA, dtgGenerales.CurrentCell.Value, "N")
                Me.datosSinAlmacenar = True
                'Else
                'BLOrdenes.deshacerActualizacionEstado(dtDatos.Rows(e.RowIndex))
                'End If
            End If
            If dtgGenerales.CurrentCell.ColumnIndex = dtgGenerales.Columns("suspender_gen").Index Then '' COLUMNA SUSPENDER
                'If puedeAdicionarRegistroOrdenGeneral(dtDatos.Rows(e.RowIndex)) Then El campo en la base de datos es text por lo que esta validacion no tiene sentido 484950-20121227 cpgaray Enero 4 2013
                BLOrdenes.actualizarEstado(dtDatos.Rows(e.RowIndex), BLOrdenes.SUSPENDE, dtgGenerales.CurrentCell.Value, "N")
                Me.datosSinAlmacenar = True
                'Else
                'BLOrdenes.deshacerActualizacionEstado(dtDatos.Rows(e.RowIndex))
                'End If

            End If
        End If
    End Sub

    Private Sub dtgGenerales_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgGenerales.CellContentDoubleClick
        dtgGenerales_CellContentClick(sender, e)
    End Sub

    Private Sub dtgGenerales_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dtgGenerales.UserDeletingRow
        Dim row As DataRow
        Dim dtDatos As DataTable = dtgGenerales.DataSource

        e.Cancel = True
        row = dtDatos.Rows(e.Row.Index)
        If row.RowState = DataRowState.Added Then
            _tamanoXmlOGeneral -= BLOrdenes.tamanoFilaXmlOrdenGeneral(row)
            e.Cancel = False
        End If
    End Sub

    Private Function puedeAdicionarRegistroOrdenGeneral(ByVal drFila As DataRow) As Boolean
        ''Validacion del tamaño maximo que se puede pasar al 
        ''stored procedure que guarda la orden
        Dim tamano As Integer

        tamano = _tamanoXmlOGeneral

        If drFila.RowState <> DataRowState.Modified Then
            tamano += BLOrdenes.tamanoFilaXmlOrdenGeneral(drFila)
        End If

        If tamano > 8000 Then
            MsgBox("No se puede adicionar este registro pues se excede el número maximo de registros a grabar.")
            Return False
        Else
            _tamanoXmlOGeneral = tamano
            Return True
        End If

    End Function

#End Region

    Private Sub ctlOrdenesMedicas_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged

        'Dim strRta As String

        If ValidarDatosHisBasica() Then
            Exit Sub
        End If

        InhabilitarSegunPais()
        Ivalidacc = 0
        strDescripcion = ""

        'If Me.datosSinAlmacenar And strRta <> "Cancel" Then 'CCGUTIEREZ. 25/06/2020. Pyxis - ALM_111
        '    If Me.datosSinAlmacenar Then
        '        If MsgBox("No se ha guardado la información registrada, perderá los cambios realizados ¿desea continuar?", MsgBoxStyle.OkCancel, "Historia Clinica") = DialogResult.OK Then

        '            _Ordenes.Estado = "N"
        '            Mostrar()
        '            Me.Visible = False

        '        Else
        '            Me.datosSinAlmacenar = True
        '            strRta = "Cancel" 'CCGUTIEREZ. 25/06/2020. Pyxis - ALM_111
        '        End If

        '        Exit Sub

        '    End If
        'End If
        If sender.Visible Then

            If Me.datosSinAlmacenar = False Then
                LimpiarDatos()
                _Ordenes.Estado = "N"
                Mostrar()
                falg_modificar = 0
            Else
                strRta = "Aceptar"
            End If

            If frmHistoriaPrincipal.blnCtlOrdenesMedicas Then
                frmHistoriaPrincipal.blnCtlOrdenesMedicas = False
            End If

        Else

            Dim NroOrden As Double
            Dim fechaOrden As Date
            Dim lError As Long
            Dim strCodCentroCostoOrigen As String = ""

            ''Procedimiento que se guarda los datos que estan en las grillas
            lError = BLOrdenes.verificoOrdenes(datosConexion, datosLogin.Prestador, datosLogin.Sucursal,
                                              datosPaciente.TipoAdmision, datosPaciente.NumeroAdmision,
                                              datosPaciente.AnoAdmision, datosLogin.Login, datosLogin.Login,
                                              datosLogin.CodigoEspecialidad, datosPaciente.Entidad,
                                              dtgDietas.DataSource, dtgMedicamentos.DataSource,
                                              dtgProcedimientos.DataSource, dtgGenerales.DataSource,
                                              NroOrden, fechaOrden, strCodCentroCostoOrigen)

            If lError <> 999 Then

                'Me.Dispose(True)
                'ctlOrdenesMedicas._Instancia = Nothing
            Else
                Me.datosSinAlmacenar = False
            End If

        End If

        ' agfa_orm_in 2014/10/24  
        cargarDiagnosticos()
        Me.RadioButton2.Checked = False
        Me.RadioButton1.Checked = False
        Me.txtcc.Enabled = False
        lblDiasTrat.Visible = False
        txtDiasTrat.Visible = False

    End Sub

    Private Sub LimpiarDatos()
        txtTipDieta.ResetText()
        txtDescripDieta.ResetText()
        txtTextoOrden.ResetText()
        txtObsDieta.ResetText()
        txtCodMedica.ResetText()
        cmbDescripMedica.ResetText()
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
        tbCodTipoProcedim.ResetText()
        tbDesTipoProc.ResetText()
        txtCodProcedim.ResetText()
        cmbDescripProcedim.ResetText()
        cmbCentroCosto.ResetText()
        txtCantidad.ResetText()
        txtObsProcedim.ResetText()
        txtTextoOrden.ResetText()
        ' agfa_orm_in 2014/09/15 herojas
        tb_Guia.ResetText()
        tb_Justi.ResetText()
        Me.tb_Guia.Enabled = True
        Me.tb_Justi.Enabled = True
        Me.txtcc.ResetText()
        Me.RadioButton2.Checked = False
        Me.RadioButton1.Checked = False
        Me.txtcc.Enabled = True
        Cmbtiempo.ResetText()
        Cmbtiempo.Text = Nothing
        Me.txtTecnica.Text = ""

    End Sub
    'Ing. Ricardo Maurcicio Zaldúa C.
    '2009-01-29
    'se creo este objeto para identificar el tipo de servicio y la proridad 
    'Solicitado por Mauricio Forero
    Private Sub op_TipoServ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles op_TipoServ.Click
        If Me.op_TipoServ.Checked = True Then
            Me.GroupPriori.Enabled = False
            Me.op_PrioNO.Checked = False
            Me.op_PrioSI.Checked = False
        Else
            Me.GroupPriori.Enabled = False
            Me.op_PrioNO.Checked = False
            Me.op_PrioSI.Checked = False
        End If
    End Sub

    Private Sub op_Electivo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles op_Electivo.Click
        If Me.op_Electivo.Checked = True Then
            Me.GroupPriori.Enabled = True
            Me.op_PrioSI.Enabled = True
        Else
            Me.GroupPriori.Enabled = False
        End If
    End Sub

    Private Sub panelDietas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles panelDietas.Click
        TxtScroll1.Visible = True
        TxtScroll1.Focus()
        TxtScroll1.Visible = False
    End Sub

    Private Sub panelMedica_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles panelMedica.Click
        TxtScroll2.Visible = True
        TxtScroll2.Focus()
        TxtScroll2.Visible = False
    End Sub

    Private Sub panelProce_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles panelProce.Click
        Txtscroll3.Visible = True
        Txtscroll3.Focus()
        Txtscroll3.Visible = False
    End Sub

    Private Sub panelGeneral_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles panelGeneral.Click
        Txtscroll4.Visible = True
        Txtscroll4.Focus()
        Txtscroll4.Visible = False
    End Sub

    Private Sub panelProce1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles panelProce1.Click
        Txtscroll3.Visible = True
        Txtscroll3.Focus()
        Txtscroll3.Visible = False
    End Sub

    Private Sub txtTecnica_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTecnica.KeyPress

        ''Ingresado por Claudia Garay para evitar el ingreso de estos
        ''Caracteres  19/01/2010

        If e.KeyChar = ">" Or e.KeyChar = "<" Or e.KeyChar = "&" Then
            ' SendKeys.Send("{TAB }")
            e.Handled = True
        End If

    End Sub



    ''Ingresado por Claudia Garay
    'Private Sub TxtDescripOrden_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
    '    If txtTipOrden.Text <> "" Then
    '        If TxtDescripOrden.Text <> "OTROS" And TxtDescripOrden.Text <> "OXIGENO" Then
    '            txtTextoOrden.Enabled = False
    '        Else
    '            txtTextoOrden.Enabled = True
    '        End If
    '    End If
    'End Sub



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


    'Private Sub LoadPage()
    '    Dim i As Integer
    '    Dim startRec As Integer
    '    Dim endRec As Integer
    '    Dim dtTemp As DataTable
    '    Dim dr As DataRow


    '    'Duplicate or clone the source table to create the temporary table.
    '    'dtTemp = dtgMedicamentos.DataSource 'dtSource.Clone
    '    dtSource.AcceptChanges()
    '    dtTemp = dtSource.Clone

    '    If currentPage = PageCount Then
    '        endRec = maxRec
    '    Else
    '        endRec = pageSize * currentPage
    '    End If

    '    startRec = recNo

    '    'Copy the rows from the source table to fill the temporary table.
    '    For i = startRec To endRec - 1
    '        'dtTemp.ImportRow(dtgMedicamentos.DataSource.Rows(i))
    '        dtTemp.ImportRow(dtSource.Rows(i))
    '        recNo = recNo + 1
    '    Next

    '    dtgMedicamentos.DataSource = dtTemp
    '    'DisplayPageInfo()

    'End Sub




    'Private Sub DisplayPageInfo()
    '    txtDisplayPageNo.Text = "Page " & currentPage.ToString & "/ " & PageCount.ToString
    'End Sub

    'Private Sub PaginarGrillaMed()


    '    'Set the start and max records. 
    '    pageSize = 5
    '    maxRec = dtSource.Rows.Count
    '    PageCount = maxRec \ pageSize

    '    ' Adjust the page number if the last page contains a partial page.
    '    If (maxRec Mod pageSize) > 0 Then
    '        PageCount = PageCount + 1
    '    End If

    '    'Initial seeings
    '    currentPage = 1
    '    recNo = 0

    '    ' Display the content of the current page.
    '    LoadPage()

    'End Sub
    'Private Function CheckFillButton() As Boolean

    '    'Check if the user clicks the "Fill Grid" button.
    '    If pageSize = 0 Then
    '        MessageBox.Show("Set the Page Size, and then click the ""Fill Grid"" button!")
    '        CheckFillButton = False
    '    Else
    '        CheckFillButton = True
    '    End If
    'End Function


    'Private Sub btnFirstPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirstPage.Click
    '    If Not CheckFillButton() Then Return

    '    ' Check if you are already at the first page.
    '    If currentPage = 1 Then
    '        ' MessageBox.Show("You are at the First Page!")
    '        Return
    '    End If

    '    currentPage = 1
    '    recNo = 0

    '    LoadPage()

    'End Sub

    'Private Sub btnNextPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextPage.Click
    '    If Not CheckFillButton() Then Return
    '    'If the user did not click the "Fill Grid" button then Return


    '    'Check if the user clicked the "Fill Grid" button.
    '    If pageSize = 0 Then
    '        MessageBox.Show("Set the Page Size, and then click the ""Fill Grid"" button!")
    '        Return
    '    End If

    '    currentPage = currentPage + 1

    '    If currentPage > PageCount Then
    '        currentPage = PageCount

    '        'Check if you are already at the last page.
    '        If recNo = maxRec Then
    '            'MessageBox.Show("You are at the Last Page!")
    '            Return
    '        End If
    '    End If

    '    LoadPage()
    'End Sub

    'Private Sub btnPreviousPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreviousPage.Click
    '    If Not CheckFillButton() Then Return

    '    If currentPage = PageCount Then
    '        recNo = pageSize * (currentPage - 2)
    '    End If

    '    currentPage = currentPage - 1

    '    'Check if you are already at the first page.
    '    If currentPage < 1 Then
    '        'MessageBox.Show("You are at the First Page!")
    '        currentPage = 1
    '        Return
    '    Else
    '        recNo = pageSize * (currentPage - 1)
    '    End If

    '    LoadPage()
    'End Sub


    'Private Sub btnLastPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLastPage.Click
    '    If Not CheckFillButton() Then Return

    '    ' Check if you are already at the last page.
    '    If recNo = maxRec Then
    '        MessageBox.Show("You are at the Last Page!")
    '        Return
    '    End If

    '    currentPage = PageCount

    '    recNo = pageSize * (currentPage - 1)

    '    LoadPage()
    'End Sub






    'Private Sub ComboBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.TextChanged

    '    Dim ListaDatos As New AutoCompleteStringCollection()
    '    Dim mDatasource As DataTable
    '    'Dim index As Integer
    '    mDatasource = ComboBox1.DataSource
    '    'index = ComboBox1.FindStringExact(ComboBox1.Text)
    '    'ComboBox1.SelectedIndex = index
    '    For intRow As Integer = 0 To mDatasource.Rows.Count - 1
    '        ListaDatos.Add(mDatasource.Rows(intRow)(ComboBox1.Text))
    '    Next
    'End Sub


    Private Sub btnCancelarOrden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelarOrden.Click
        frmCancelaOrden.ShowDialog()
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

    Private Sub txtObsDieta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObsDieta.KeyPress

        ''Ingresado por Claudia Garay para evitar el ingreso de estos
        ''Caracteres  07/03/2012

        If e.KeyChar = ">" Or e.KeyChar = "<" Or e.KeyChar = "&" Then
            'SendKeys.Send("{TAB }")
            e.Handled = True
        End If
    End Sub


    Private Sub txtTextoOrden_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTextoOrden.KeyPress

        ''Ingresado por Claudia Garay para evitar el ingreso de estos
        ''Caracteres  07/03/2012

        If e.KeyChar = ">" Or e.KeyChar = "<" Or e.KeyChar = "&" Then
            ''SendKeys.Send("{TAB }")
            e.Handled = True

        End If
    End Sub

    Private Sub txtObsProcedim_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObsProcedim.KeyPress

        ''Ingresado por Claudia Garay para evitar el ingreso de estos
        ''Caracteres  07/03/2012

        If e.KeyChar = ">" Or e.KeyChar = "<" Or e.KeyChar = "&" Then
            'SendKeys.Send("{TAB }")
            e.Handled = True
        End If
    End Sub

    Private Sub tb_Guia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_Guia.KeyPress

        ''Ingresado por Claudia Garay para evitar el ingreso de estos
        ''Caracteres  07/03/2012

        If e.KeyChar = ">" Or e.KeyChar = "<" Or e.KeyChar = "&" Then
            'SendKeys.Send("{TAB }")
            e.Handled = True
        End If
    End Sub

    Private Sub tb_Justi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_Justi.KeyPress

        ''Ingresado por Claudia Garay para evitar el ingreso de estos
        ''Caracteres  07/03/2012

        If e.KeyChar = ">" Or e.KeyChar = "<" Or e.KeyChar = "&" Then
            'SendKeys.Send("{TAB }")
            e.Handled = True
        End If
    End Sub

    'Private Sub txtTipOrden_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
    '    If txttiporden.Text = "" Then
    '        Exit Sub
    '    End If
    '    ''Claudia Garay Cambios Acreditacion campo Oxigeno febrero de 2011
    '    If txttiporden.Text = 106 Or txttiporden.Text = 107 Then
    '        txtTextoOrden.Enabled = True
    '    Else
    '        txtTextoOrden.Enabled = False
    '    End If
    'End Sub


    Private Sub InhabilitarSegunPais()
        If datosLogin.Pais = "482" Then
            panelDietas.Enabled = False
            panelMedica.Enabled = False
            panelGeneral.Enabled = False
            GroupServi.Visible = False
            GroupPriori.Visible = False
            tb_Guia.Enabled = False
            Label3.Text = "Servicio"

        End If
    End Sub

    'agfa_orm_in 2014/11/10
    Private Sub dtgProcedimientos_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dtgProcedimientos.UserDeletingRow
        If dtgProcedimientos.Rows.Count = 1 Then
            Me.tb_Justi.Enabled = True
            Me.tb_Guia.Enabled = True
            Me.txtObsProcedim.Enabled = True
        End If
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub txtDiasTrat_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim daoGeneral As New DAOGeneral
        Dim diastrat As Integer

        diastrat = daoGeneral.EjecutarSQLStrValor("pargener (nolock)", datosConexion, " diastrat", " cod_pre_sgs='" & datosLogin.Prestador & "'")
        If Me.txtDiasTrat.Text = "" Then
            Me.txtDiasTrat.Text = 0
        End If
        If diastrat < Me.txtDiasTrat.Text Then
            MsgBox("supera los dias de tratamiento a prescribir, esta parametrizado en:  " & diastrat, MsgBoxStyle.Information, "Administrador")
            Me.txtDiasTrat.Text = diastrat
        End If
    End Sub

    Private Sub Link_Laboratorio_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Link_Laboratorio.LinkClicked
        Dim ofrmHistoriaPrincipal As New frmHistoriaPrincipal
        ofrmHistoriaPrincipal.consultar_ordenes_laboratorio(datosLogin)
    End Sub


    Private Sub Chkviaoral_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chkviaoral.CheckedChanged

        If Chkviaoral.Checked = True Then
            Me.txtTipDieta.Text = ""
            Me.txtDescripDieta.Text = ""
            Me.txtTipDieta.Enabled = False
            Me.txtDescripDieta.Enabled = False
            Me.GroupBox2.Enabled = False
            Me.txtTipDieta.BackColor = Color.LightGray
            Me.txtcc.Text = ""
            Me.RadioButton2.Checked = False
            Me.RadioButton1.Checked = False
            Me.txtcc.Enabled = False
        Else
            Me.txtTipDieta.Enabled = True
            Me.txtDescripDieta.Enabled = True
            Me.txtTipDieta.Text = ""
            Me.txtDescripDieta.Text = ""
            Me.GroupBox2.Enabled = True
            Me.txtTipDieta.BackColor = Color.White
            Me.txtcc.Text = ""
            Me.RadioButton2.Checked = False
            Me.RadioButton1.Checked = False
            Me.txtcc.Enabled = False
        End If

    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        Me.txtcc.Enabled = True
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        Me.txtcc.Enabled = False
        Me.txtcc.Text = ""
    End Sub


    Public Sub ValidarDieta24Horas()
        Dim estado As Boolean

        Try
            _Ordenes.TablasOrdenes = BLOrdenes.consultarOrdenes(datosConexion, datosLogin.Prestador, datosLogin.Sucursal,
                                  datosPaciente.TipoAdmision, datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision)

            _Ordenes.TablasOrdenes.AcceptChanges()
            _Ordenes.Estado = "M"  ''Marca el objeto para decir que ya fue cargado o modificado
        Catch ex As Exception
            MsgBox("Error en la consulta de las dietas. " & ex.Message, MsgBoxStyle.Information)
            Exit Sub
        End Try


        ''Carga la grilla de Dietas 
        configurarGrillaDietas(_Ordenes.TablasOrdenes.Tables("DIETAS"))
        ''Carga la grilla de Medicamentos 
        configurarGrillaMedicamentos(_Ordenes.TablasOrdenes.Tables("MEDICAMENTOS"))
        ''Configura la grilla de Procedimientos
        configurarGrillaProcedimientos()
        ''Carga la grilla de Ordenes Generales 
        configurarGrillaGenerales(_Ordenes.TablasOrdenes.Tables("ORDENGENERAL"))
    End Sub






    '''-----Metodos-------*/
    ''' Jimmy leandro Guevara (Intergrupo)
    ''' <summary>
    ''' Metodo que guarda una admision homologada
    ''' </summary>
    ''' <remarks></remarks>
    Private Function GuardarAdmisionHomologada(ByVal linkedServer As String, ByVal idLocalizacionDestino As Int32, ByVal dtProcedimientos As DataTable, ByVal cod_pre_sgs_destino As String, ByVal cod_sucur_destino As String) As DataTable
        Dim datosAdmision As New DataTable
        Dim datosEntidades As New DataTable
        Dim datosProcedimientos As New DataTable
        Dim iConsecutivoCarmovim As Int32
        Dim iNumAdmision As Int32
        Dim fecha As Date
        Dim entidad1 As String = String.Empty
        Dim entidad2 As String = String.Empty
        Dim loginHomologacion As String = String.Empty
        Dim respuesta As New DataTable
        fecha = FuncionesGenerales.FechaServidor()
        'datosPaciente
        'datosLogin
        Dim centrocosto As String = dtProcedimientos.Rows(0)("cen_cos_des")
        iNumAdmision = BLOrdenes.ConsultarConsecutivo(cod_sucur_destino, datosPaciente.TipoAdmision, linkedServer)
        iConsecutivoCarmovim = BLOrdenes.ConsultarConsecutivo(cod_sucur_destino, centrocosto, linkedServer)
        datosEntidades = ConsultarEntidadesAdmision()
        loginHomologacion = BLOrdenes.ConsultarLoginHomologacion(linkedServer)

        'If datosEntidades.Rows.Count > 0 And datosEntidades.Rows.Count <= 1 Then
        '    entidad1 = datosEntidades.Rows(0)("entidad")
        'ElseIf datosEntidades.Rows.Count > 1 Then
        '    entidad1 = datosEntidades.Rows(0)("entidad")
        '    entidad2 = datosEntidades.Rows(1)("entidad")
        'End If
        entidad1 = datosPaciente.Entidad

        Dim ip As String
        'System.Net.IPHostEntry
        ip = "0"
        'System.Net.Dns.GetHostEntry(My.Computer.Name)

        'Declaracion de columnas
        datosAdmision.Columns.Add("strCadenaConexion")
        datosAdmision.Columns.Add("strCodPreSgs")
        datosAdmision.Columns.Add("strCodSucur")
        datosAdmision.Columns.Add("strTipAdm")
        datosAdmision.Columns.Add("strIngrInactivo")
        datosAdmision.Columns.Add("strEspec")
        datosAdmision.Columns.Add("dteFecIngreso")
        datosAdmision.Columns.Add("nHoraIngreso")
        datosAdmision.Columns.Add("iMinIngreso")
        datosAdmision.Columns.Add("strConPriVez")
        datosAdmision.Columns.Add("strEntidad1")
        datosAdmision.Columns.Add("strEntidad2")
        datosAdmision.Columns.Add("strCarnet")
        datosAdmision.Columns.Add("strManTriage")
        datosAdmision.Columns.Add("rsTriage")
        datosAdmision.Columns.Add("strCapitado")
        datosAdmision.Columns.Add("strNumAutoriza")
        datosAdmision.Columns.Add("strNomAutoriza")
        datosAdmision.Columns.Add("sObservaciones")
        datosAdmision.Columns.Add("strLogin")
        datosAdmision.Columns.Add("xPaciente")
        datosAdmision.Columns.Add("xResponsable")
        datosAdmision.Columns.Add("xAcompanante")
        datosAdmision.Columns.Add("xProcedimiento")
        datosAdmision.Columns.Add("xGeneralPaciente")
        datosAdmision.Columns.Add("xAutorizacion") 'VACIO
        datosAdmision.Columns.Add("xSqlLlave") 'VACIO
        datosAdmision.Columns.Add("xInconsistencia") 'VACIO 
        datosAdmision.Columns.Add("sPrimerApellido")
        datosAdmision.Columns.Add("sPrimerNombre")
        datosAdmision.Columns.Add("sSegundoApellido")
        datosAdmision.Columns.Add("sSegundoNombre")
        datosAdmision.Columns.Add("bAuditoria")
        datosAdmision.Columns.Add("nNumeroCuotas")
        datosAdmision.Columns.Add("sClaseMotivoInactividad")
        datosAdmision.Columns.Add("sTipoMotivoInactividad")
        datosAdmision.Columns.Add("sMotivoInactividad")
        datosAdmision.Columns.Add("sManejarInterfaceRIS")
        datosAdmision.Columns.Add("sTipoEntidad")
        datosAdmision.Columns.Add("sUsuarioCompartido")
        datosAdmision.Columns.Add("sAutorizaPaciente")
        datosAdmision.Columns.Add("sInconsistencia")
        datosAdmision.Columns.Add("sIP")
        datosAdmision.Columns.Add("sConsecutivoFur")
        datosAdmision.Columns.Add("nLocalizacion")
        datosAdmision.Columns.Add("dFechaRegistro")
        datosAdmision.Columns.Add("nMotivoTipo")
        datosAdmision.Columns.Add("SMotivoClase")
        datosAdmision.Columns.Add("sTipoVale")
        datosAdmision.Columns.Add("sVale")
        datosAdmision.Columns.Add("nNumeroCaja")
        datosAdmision.Columns.Add("nValorVale")
        datosAdmision.Columns.Add("dFechaExpiracion")
        datosAdmision.Columns.Add("nIdentificadorAdmision")
        datosAdmision.Columns.Add("sObservacionVale")
        datosAdmision.Columns.Add("sPlanCarnet")
        datosAdmision.Columns.Add("sContratoCarnet")
        datosAdmision.Columns.Add("sFamiliaCarnet")
        datosAdmision.Columns.Add("sUsuarioCarnet")
        datosAdmision.Columns.Add("iNumAdmision")
        datosAdmision.Columns.Add("iConsecutivoCarmovim")

        'Asignacion de registros
        datosAdmision.Rows.Add("",
         cod_pre_sgs_destino,
         cod_sucur_destino,
         datosPaciente.TipoAdmision,
         String.Empty,
         datosLogin.CodigoEspecialidad,
         fecha,
         fecha.Hour,
         fecha.Minute,
         "S",
         entidad1,
         entidad2,
         datosPaciente.Carnet,
         "S",
         ArmaxmlTriage(),
         "N",
         "",
         "",
         "",
         loginHomologacion,
         ArmaxmlPaciente(),
         "",
         "",
         ArmaxmlProcedimiento(linkedServer, idLocalizacionDestino, cod_pre_sgs_destino, cod_sucur_destino),
         ArmaxmlGeneralPaciente(linkedServer, idLocalizacionDestino, dtProcedimientos),
         "",
         "",
         "",
         datosPaciente.PrimerApellido,
         datosPaciente.PrimerNombre,
         datosPaciente.SegundoApellido,
         datosPaciente.SegundoNombre,
         0,
         1,
         Nothing,
         Nothing,
         Nothing,
         "S",
         datosPaciente.TipoEntidad,
         "",
         "N",
         "",
         ip,
         "",
         idLocalizacionDestino,
         Date.Now,
         "2",
         "4",
         "",
         "",
         "",
         "",
         "",
         "O",
         "N",
         "",
         "",
         "",
         "sUsuarioCarnet",
         iNumAdmision,
         iConsecutivoCarmovim)

        Return BLOrdenes.GuardarAdmisionHomologada(datosAdmision, linkedServer)

    End Function

    ''' <summary>
    ''' Metodo que guarda una orden medica homologada
    ''' </summary>
    ''' <remarks></remarks>
    Private Function GuardarLogOrdenHomologada(ByVal dtRespuestaAdm As DataTable, ByVal Loghomologacion As DataTable, ByVal NroOrden As Double, ByVal LinkedServer As String, ByVal homologacion As DataTable)
        Dim respuesta As New DataTable
        Dim Codigo_Admision_Origen As String = datosPaciente.NumeroAdmision
        Dim Ano_Admision_Origen As Int32 = datosPaciente.AnoAdmision
        Dim Tipo_Admision_Origen As String = datosPaciente.TipoAdmision
        Dim Codigo_Admision_Destino As String = 0
        Dim Ano_Admision_Destino As Int32 = 0
        Dim Tipo_Admision_Destino As String = ""
        Dim Codigo_Orden_Origen As String = NroOrden
        Dim Codigo_Orden_Destino As String = "0"
        Dim cod_pre_sgs_origen As String = String.Empty
        Dim cod_pre_sgs_destino As String = String.Empty
        Dim cod_sucur_origen As String = String.Empty
        Dim cod_sucur_destino As String = String.Empty
        Dim Numero_Documento As String = datosPaciente.NumeroDocumento
        Dim Tipo_Documento As String = datosPaciente.TipoDocumento
        Dim Id_Localizacion_Origen As Int32 = 0
        Dim Id_Localizacion_Destino As Int32 = 0
        Dim fec_con As Date = Date.Now
        Dim login As String = datosLogin.Login
        Dim obs As String


        If homologacion.Rows.Count > 0 Then
            cod_pre_sgs_origen = homologacion.Rows(0)("cod_pre_sgs_origen")
            cod_pre_sgs_destino = homologacion.Rows(0)("cod_pre_sgs_destino")
            cod_sucur_origen = homologacion.Rows(0)("cod_sucur_origen")
            cod_sucur_destino = homologacion.Rows(0)("cod_sucur_destino")
            Id_Localizacion_Destino = Convert.ToInt32(homologacion.Rows(0)("Id_Localizacion_Destino").ToString())
        End If

        obs = "Homologación realizada desde SOPHIA, "
        If dtRespuestaAdm.Rows.Count > 0 Then
            Codigo_Admision_Destino = Convert.ToDecimal(dtRespuestaAdm.Rows(0)("NumeroAdmisionDestino"))
            Ano_Admision_Destino = Convert.ToInt32(dtRespuestaAdm.Rows(0)("AnoAdmisionDestino"))
            Tipo_Admision_Destino = dtRespuestaAdm.Rows(0)("TipoAdmisionDestino")
            obs = obs + dtRespuestaAdm.Rows(0)("error")
        Else
            obs = obs + " El o los procedimientos seleccionados no están dentro de los permitidos para realizar la homologación."
            BLOrdenes.GrabarErroresOrdenesMedicas("HistoriaMedic a" & obs)
        End If

        If Loghomologacion.Rows.Count > 0 Then
            Codigo_Orden_Destino = Loghomologacion.Rows(0)("NroOrden")
        End If

        respuesta = BLOrdenes.GuardarLogHomologacion(Codigo_Admision_Origen, Ano_Admision_Origen, Tipo_Admision_Origen,
                    Codigo_Admision_Destino, Ano_Admision_Destino, Tipo_Admision_Destino, Codigo_Orden_Origen, Codigo_Orden_Destino,
                    cod_pre_sgs_origen, cod_pre_sgs_destino, cod_sucur_origen, cod_sucur_destino, Numero_Documento, Tipo_Documento,
                    Id_Localizacion_Origen, Id_Localizacion_Destino, fec_con, login, obs, LinkedServer)
        respuesta = BLOrdenes.GuardarLogHomologacion(Codigo_Admision_Origen, Ano_Admision_Origen, Tipo_Admision_Origen,
                    Codigo_Admision_Destino, Ano_Admision_Destino, Tipo_Admision_Destino, Codigo_Orden_Origen, Codigo_Orden_Destino,
                    cod_pre_sgs_origen, cod_pre_sgs_destino, cod_sucur_origen, cod_sucur_destino, Numero_Documento, Tipo_Documento,
                    Id_Localizacion_Origen, Id_Localizacion_Destino, fec_con, login, obs, "")
    End Function



    Private Function ConsultarEntidadesAdmision() As DataTable
        Return BLOrdenes.ConsultarEntidadesPorAdmision(datosPaciente.AnoAdmision, datosPaciente.TipoAdmision, datosPaciente.NumeroAdmision)
    End Function

    Private Function ArmaxmlTriage() As String
        Dim tip_consultorioDefeco As String = "UR"
        Dim consultorioDefeco As String = "106"
        Dim datosTriage As New DataTable
        datosTriage.Columns.Add("fec_ingreso")
        datosTriage.Columns.Add("hor_ingreso")
        datosTriage.Columns.Add("min_ingreso")
        datosTriage.Columns.Add("tip_consultorio")
        datosTriage.Columns.Add("consultorio")
        datosTriage.Rows.Add(Format(CDate(Date.Now.ToString()), "yyyy/MM/dd"), 0, 0, tip_consultorioDefeco, consultorioDefeco)
        Return FuncionesGenerales.GenerarXMLxProcedimientoTA(datosTriage)
    End Function


    Private Function ArmaxmlPaciente() As String

        Dim dtPaciente As New DataTable
        dtPaciente.Columns.Add("tip_doc")
        dtPaciente.Columns.Add("num_doc")
        dtPaciente.Columns.Add("sexo")
        dtPaciente.Columns.Add("uni_med_tie")
        dtPaciente.Columns.Add("pai_nacimien")
        dtPaciente.Columns.Add("dep_nacimien")
        dtPaciente.Columns.Add("ciu_nacimien")
        dtPaciente.Columns.Add("pai_cas_pac")
        dtPaciente.Columns.Add("dep_cas_pac")
        dtPaciente.Columns.Add("ciu_cas_pac")
        dtPaciente.Columns.Add("zon_residen")
        dtPaciente.Columns.Add("codpostal")
        dtPaciente.Columns.Add("ocupacion")
        dtPaciente.Columns.Add("est_civil")
        dtPaciente.Columns.Add("grupo_atencion_especial")
        dtPaciente.Columns.Add("pri_nom")
        dtPaciente.Columns.Add("seg_nom")
        dtPaciente.Columns.Add("pri_ape")
        dtPaciente.Columns.Add("seg_ape")
        dtPaciente.Columns.Add("fec_nac")
        dtPaciente.Columns.Add("edad")
        dtPaciente.Columns.Add("dir_cas_pac")
        dtPaciente.Columns.Add("tel_cas_pac1")
        dtPaciente.Columns.Add("tel_cas_pac2")
        dtPaciente.Columns.Add("nombre_madre")
        dtPaciente.Columns.Add("nombre_padre")
        dtPaciente.Columns.Add("trabajo_paciente")
        dtPaciente.Columns.Add("direccion_trabajo_paciente")
        dtPaciente.Columns.Add("telefono_trabajo_paciente1")
        dtPaciente.Columns.Add("telefono_trabajo_paciente2")
        dtPaciente.Columns.Add("numero_hijos")
        dtPaciente.Columns.Add("nombre_conyuge")
        dtPaciente.Columns.Add("trabajo_conyuge")
        dtPaciente.Columns.Add("direccion_trabajo_conyuge")
        dtPaciente.Columns.Add("telefono_trabajo_conyuge1")
        dtPaciente.Columns.Add("numero_archivo_historia")
        dtPaciente.Columns.Add("email")
        dtPaciente.Columns.Add("STATUS")
        dtPaciente.Columns.Add("gru_sanguineo")
        dtPaciente.Columns.Add("rh")
        dtPaciente.Columns.Add("religion")
        dtPaciente.Columns.Add("ano_menarquia")
        dtPaciente.Columns.Add("fecha_consulta")
        dtPaciente.Columns.Add("login")
        dtPaciente.Columns.Add("obs")
        dtPaciente.Columns.Add("entidad")
        dtPaciente.Columns.Add("carnet")
        dtPaciente.Columns.Add("tipo_baja")
        dtPaciente.Columns.Add("numero_envio")
        dtPaciente.Columns.Add("codigo_personal")
        dtPaciente.Columns.Add("ciudad_expedicion")
        dtPaciente.Columns.Add("departamento_expedicion")
        dtPaciente.Columns.Add("viadireccion")
        dtPaciente.Columns.Add("zonadirrecion")
        dtPaciente.Columns.Add("descripcionvia")
        dtPaciente.Columns.Add("numerovia")
        dtPaciente.Columns.Add("descripcionzona")
        dtPaciente.Columns.Add("bloque")
        dtPaciente.Columns.Add("escalera")
        dtPaciente.Columns.Add("piso")
        dtPaciente.Columns.Add("ocupaciontexto")
        dtPaciente.Columns.Add("escolaridad")
        dtPaciente.Columns.Add("etnia")

        dtPaciente.Rows.Add(datosPaciente.TipoDocumento,
        datosPaciente.NumeroDocumento,
        datosPaciente.Genero,
        datosPaciente.CodigoUnidadMedidaEdad,
        datosPaciente.Pais,
        0,
        datosPaciente.Ciudad,
        0, 0, 0, "",
        datosPaciente.CodigoOcupacionPaciente,
        "", "", "N", datosPaciente.PrimerNombre,
        datosPaciente.SegundoNombre,
        datosPaciente.PrimerApellido,
        datosPaciente.SegundoApellido,
        Format(CDate(datosPaciente.FechaNacimiento), "yyyy/MM/dd"),
        datosPaciente.Edad, "", "", "", "",
        "", "", "", "", "", 0, "", "", "",
        "", "", "", "I", datosPaciente.GrupoSanguineo, datosPaciente.RH,
        "", "0", datosPaciente.FechaCita, datosLogin.Login, "",
        datosPaciente.Entidad, datosPaciente.Carnet, "", 0, 0, "", "", "", "", "",
        "", "", "", "", "", "", "")

        Return FuncionesGenerales.GenerarXMLxProcedimientoTA(dtPaciente)
    End Function

    Private Function ArmaxmlProcedimiento(ByVal linkedServer As String, ByVal idLocalizacionDestino As Int32, ByVal cod_pre_sgs_destino As String, ByVal cod_sucur_destino As String) As String
        Dim dtProcedimiento As DataTable
        Dim dtXmlProcedimiento As New DataTable
        Dim xmlProcemiento As String = String.Empty
        dtXmlProcedimiento.Columns.Add("valor")
        dtXmlProcedimiento.Columns.Add("valorRecargo")
        dtXmlProcedimiento.Columns.Add("procedim")
        dtXmlProcedimiento.Columns.Add("cen_costo")
        dtXmlProcedimiento.Columns.Add("concepto")
        dtProcedimiento = BLOrdenes.ConsultarCargoAutmatico(cod_pre_sgs_destino, cod_sucur_destino, datosPaciente.Entidad, datosPaciente.TipoAdmision, "O", Date.Now, datosLogin.CodigoEspecialidad, "004", String.Empty, 1, datosPaciente.Edad, datosPaciente.TipoDocumento, datosPaciente.NumeroDocumento, datosLogin.NombreMedico, String.Empty, linkedServer, idLocalizacionDestino)
        If dtProcedimiento.Rows.Count > 0 Then
            dtXmlProcedimiento.Rows.Add(dtProcedimiento.Rows(0)("Valor"),
            0,
            dtProcedimiento.Rows(0)("Procedimiento"),
            dtProcedimiento.Rows(0)("CentroCosto"),
            dtProcedimiento.Rows(0)("Concepto"))
            xmlProcemiento = FuncionesGenerales.GenerarXMLxProcedimientoTA(dtXmlProcedimiento)
        End If
        Return xmlProcemiento
    End Function

    Private Function ArmaxmlGeneralPaciente(ByVal linkedServer As String, ByVal idLocalizacionDestino As Int32, ByVal dtProcedimiento As DataTable) As String
        Dim dtGeneralPaciente As New DataTable
        Dim codMedico As String
        dtGeneralPaciente.Columns.Add("tip_afiliad")
        dtGeneralPaciente.Columns.Add("medico")
        dtGeneralPaciente.Columns.Add("tip_plan")
        dtGeneralPaciente.Columns.Add("estado")
        dtGeneralPaciente.Columns.Add("pac_capitado")
        dtGeneralPaciente.Columns.Add("pac_capitaodon")
        dtGeneralPaciente.Columns.Add("instcapitacion")
        dtGeneralPaciente.Columns.Add("instcapitacionodo")
        dtGeneralPaciente.Columns.Add("fecha")


        If dtProcedimiento.Rows.Count > 0 Then
            codMedico = dtProcedimiento.Rows(0)("medico")
        End If

        dtGeneralPaciente.Rows.Add("O", codMedico, "O", "A", "N", "N", "N", "N", Format(CDate(Date.Now.ToString()), "yyyy/MM/dd"))

        Return FuncionesGenerales.GenerarXMLxProcedimientoTA(dtGeneralPaciente)
    End Function

    Private Sub btnAgregarAislamiento_Click(sender As Object, e As EventArgs) Handles btnAgregarAislamiento.Click

        'ALM 166 20200303 raul Cruz
        If ValidarDatosHisBasica() Then
            Exit Sub
        End If

        Dim dtAislamiento As New DataTable()
        Dim dtAislaValida As New DataTable()
        Dim inhabilitaCheck As Boolean = False

        dtAislamiento = dtgAislamiento.DataSource

        If Not ValidaItemSeleccionado() Then

            MessageBox.Show("Debe seleccionar un Aislamiento.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else

            If chkNoReqAislamiento.Checked = True Then

                Dim drFila As DataRow

                drFila = dtAislamiento.NewRow()
                drFila("cod_pre_sgs") = datosLogin.Prestador
                drFila("cod_sucur") = datosLogin.Sucursal
                drFila("tip_admision") = datosPaciente.TipoAdmision
                drFila("num_adm") = datosPaciente.NumeroAdmision
                drFila("ano_adm") = datosPaciente.AnoAdmision
                drFila("NroOrden") = 0
                drFila("Secuencia") = 0
                drFila("Tratamiento") = "I"
                drFila("medico") = datosLogin.Login
                drFila("estado") = BLOrdenes.ACTIVO
                drFila("aisla_fecha_hora") = Date.Now.ToString()
                drFila("login") = datosLogin.Login
                drFila("aisla_obs") = String.Empty
                drFila("aisla_medico") = datosLogin.NombreMedico
                drFila("aisla_especialidad") = datosLogin.DescripcionEspecialidad
                drFila("TextoOrden") = My.Resources.aislaNoRequerido.ToString()
                drFila("tipo_aislamiento") = BLOrdenes.consultarIdAislamiento(datosConexion, My.Resources.aislaNoRequerido.ToString())
                drFila("aisla_aislamiento") = My.Resources.aislaNoRequerido.ToString()
                drFila("aisla_continuar") = False
                drFila("aisla_suspender") = False
                drFila("aisla_nuevo") = 1

                dtAislamiento.Rows.Add(drFila)
                chkNoReqAislamiento.Checked = False
            Else

                For i As Integer = 0 To chkListAislamiento.Items.Count - 1

                    If chkListAislamiento.GetItemChecked(i) = True Then

                        Dim drFila As DataRow

                        drFila = dtAislamiento.NewRow()
                        drFila("cod_pre_sgs") = datosLogin.Prestador
                        drFila("cod_sucur") = datosLogin.Sucursal
                        drFila("tip_admision") = datosPaciente.TipoAdmision
                        drFila("num_adm") = datosPaciente.NumeroAdmision
                        drFila("ano_adm") = datosPaciente.AnoAdmision
                        drFila("NroOrden") = 0
                        drFila("Secuencia") = 0
                        drFila("Tratamiento") = "I"
                        drFila("medico") = datosLogin.Login
                        drFila("estado") = BLOrdenes.ACTIVO
                        drFila("aisla_fecha_hora") = Date.Now.ToString()
                        drFila("login") = datosLogin.Login
                        drFila("aisla_obs") = BLOrdenes.ConsultarMedidasAislamiento(chkListAislamiento.Items().Item(i).ToString())
                        drFila("aisla_medico") = datosLogin.NombreMedico
                        drFila("aisla_especialidad") = datosLogin.DescripcionEspecialidad
                        drFila("TextoOrden") = chkListAislamiento.Items().Item(i).ToString()
                        drFila("tipo_aislamiento") = BLOrdenes.consultarIdAislamiento(datosConexion, chkListAislamiento.Items().Item(i).ToString())
                        drFila("aisla_aislamiento") = chkListAislamiento.Items().Item(i).ToString()
                        drFila("aisla_continuar") = False
                        drFila("aisla_suspender") = False
                        drFila("aisla_nuevo") = 1

                        dtAislamiento.Rows.Add(drFila)

                    End If

                Next

            End If

            Me.datosSinAlmacenar = True

            dtgAislamiento.DataSource = dtAislamiento

            cargaAislamiento(dtAislamiento)

        End If

        dtAislaValida = dtgAislamiento.DataSource

        For Each fila As DataRow In dtAislaValida.Rows

            If fila("aisla_nuevo").ToString() = "1" Then

                inhabilitaCheck = True

            End If

        Next

        If inhabilitaCheck Then

            chkNoReqAislamiento.Enabled = False

            Dim validaTabla As DataTable

            validaTabla = dtgAislamiento.DataSource

            For Each fila As DataRow In validaTabla.Rows()

                If fila("tipo_aislamiento").ToString() = "0" Then

                    'btnAgregarAislamiento.Enabled = False
                    Exit For

                End If

            Next


        Else

            chkNoReqAislamiento.Enabled = True
            btnAgregarAislamiento.Enabled = True

        End If

        Panel6.Focus()

    End Sub

    Private Sub dtgAislamiento_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgAislamiento.CellContentClick

        Dim cantFilas As Integer = dtgAislamiento.Rows.Count()
        Dim contador As Integer = 0
        Dim dtInfo As DataTable
        Dim fecha As String = String.Empty
        Dim dateFecha As Date
        Dim z As Integer

        If Not e.RowIndex = -1 Then


            If dtgAislamiento.Columns(e.ColumnIndex).Name = "aisla_continuar" Or
               dtgAislamiento.Columns(e.ColumnIndex).Name = "aisla_suspender" Then

                If dtgAislamiento.Rows(e.RowIndex).Cells("aisla_nuevo").Value.ToString() = "0" Then

                    If dtgAislamiento.Columns(e.ColumnIndex).Name = "aisla_continuar" Then

                        fecha = dtgAislamiento.Rows(e.RowIndex).Cells("aisla_fecha_hora").Value.ToString()
                        dateFecha = CDate(fecha)

                        If dtgAislamiento.Rows.Count() = 1 Then

                            If dtgAislamiento.Rows(e.RowIndex).Cells("tipo_aislamiento").Value = "0" Then

                                If chkListAislamiento.CheckedItems.Count > 0 Then
                                    For i As Integer = 0 To chkListAislamiento.Items.Count - 1
                                        chkListAislamiento.SetItemChecked(i, False)
                                    Next
                                End If

                                chkListAislamiento.Enabled = False

                                ' btnAgregarAislamiento.Enabled = False

                            End If

                        End If

                        dtgAislamiento.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = True

                        'rmzaldua 2018-03-27 cambio realizado para la validacion de supender y/o continuar es escluyente cuando el tipo de aislamiento es no requiere aislamiento
                        If dtgAislamiento.Rows.Count() > 1 Then
                            For z = 0 To dtgAislamiento.RowCount() - 1
                                If dtgAislamiento.Rows(z).Cells("aisla_aislamiento").Value = "No requiere Aislamiento" Then
                                    dtgAislamiento.Rows(e.RowIndex).Cells("aisla_continuar").Value = "0"
                                    dtgAislamiento.Rows(e.RowIndex).Cells("aisla_suspender").Value = "1"
                                    dtgAislamiento.Rows(e.RowIndex).Cells("Tratamiento").Value = "S"
                                    dtgAislamiento.Rows(e.RowIndex).Cells("aisla_continuar").Value = False
                                    Exit For
                                Else
                                    dtgAislamiento.Rows(e.RowIndex).Cells("Tratamiento").Value = "C"
                                    dtgAislamiento.Rows(e.RowIndex).Cells("aisla_suspender").Value = False
                                End If
                            Next
                        Else
                            dtgAislamiento.Rows(e.RowIndex).Cells("Tratamiento").Value = "C"
                            dtgAislamiento.Rows(e.RowIndex).Cells("aisla_suspender").Value = False
                        End If




                        Me.datosSinAlmacenar = True

                    End If

                    If dtgAislamiento.Columns(e.ColumnIndex).Name = "aisla_suspender" Then

                        If dtgAislamiento.Rows.Count() = 1 Then

                            If dtgAislamiento.Rows(e.RowIndex).Cells("tipo_aislamiento").Value = "0" Then

                                chkListAislamiento.Enabled = True
                                btnAgregarAislamiento.Enabled = True
                                Me.chkNoReqAislamiento.Enabled = False
                                Me.chkNoReqAislamiento.Checked = False

                            End If

                        End If

                        dtgAislamiento.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = True
                        dtgAislamiento.Rows(e.RowIndex).Cells("aisla_continuar").Value = False
                        dtgAislamiento.Rows(e.RowIndex).Cells("Tratamiento").Value = "S"

                        Me.datosSinAlmacenar = True

                    End If

                    dtInfo = dtgAislamiento.DataSource

                    For Each fila As DataRow In dtInfo.Rows

                        If fila("aisla_suspender").ToString() = "1" Then
                            contador = contador + 1
                        End If

                    Next

                    If contador = cantFilas Then

                        If dtInfo.Rows.Count() = 1 Then

                            For Each fila As DataRow In dtInfo.Rows()



                                If CBool(fila("aisla_suspender").ToString()) = True Then
                                    chkNoReqAislamiento.Enabled = True
                                Else
                                    chkNoReqAislamiento.Enabled = False
                                End If

                                If fila("tipo_aislamiento").ToString() = "0" Then
                                    chkNoReqAislamiento.Enabled = False
                                End If
                            Next

                        Else
                            chkNoReqAislamiento.Enabled = True
                        End If

                    Else
                        chkNoReqAislamiento.Enabled = False
                    End If

                Else

                    dtgAislamiento.Rows(e.RowIndex).Cells("aisla_continuar").Value = "0"
                    dtgAislamiento.Rows(e.RowIndex).Cells("aisla_suspender").Value = "0"

                End If

            End If

        End If



    End Sub

    '' Dsanchez IG - Configura grilla de aislamiento - 11/10/2017
    Public Sub configurarGrillaAislamiento(ByVal dtAislamiento As DataTable)



        dtAislamiento.Rows.Add()

        With dtgAislamiento
            .DataSource = dtAislamiento
            .Columns("cod_pre_sgs").Visible = False
            .Columns("cod_sucur").Visible = False
            .Columns("tip_admision").Visible = False
            .Columns("num_adm").Visible = False
            .Columns("ano_adm").Visible = False
            .Columns("NroOrden").Visible = False
            .Columns("Secuencia").Visible = False
            .Columns("Tratamiento").Visible = False
            .Columns("medico").Visible = False
            .Columns("login").Visible = False
            .Columns("TextoOrden").Visible = False
            .Columns("ESTADO").Visible = False
            .Columns("tipo_aislamiento").Visible = False
            .Columns("aisla_medico").Visible = False
            .Columns("aisla_especialidad").Visible = False
            .Columns("aisla_nuevo").Visible = False
        End With
        dtAislamiento.Rows.RemoveAt(dtAislamiento.Rows.Count - 1)

        cargaAislamiento(dtgAislamiento.DataSource)

        Me.btnAgregarAislamiento.Enabled = True
    End Sub

    '''dsanchez ER_OSI_594 Aislamientos
    ''' <summary>
    ''' Se configura el combo busqueda y el texto con formato para estos
    ''' controles permitan la busqueda de un aislamiento ya se por  
    ''' descripcion o por codigo.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub cargaAislamiento(ByVal dtDatos As DataTable)

        Dim dtInfo As DataTable
        Dim nombreAislamiento As String = String.Empty
        Dim condicion As String = String.Empty
        Dim dtGrilla As DataTable

        dtGrilla = dtgAislamiento.DataSource

        For Each fila As DataRow In dtDatos.Rows

            nombreAislamiento = "'" + fila("aisla_aislamiento").ToString() + "'"
            condicion = condicion + nombreAislamiento + ","
        Next

        If Not condicion = String.Empty Then

            condicion = condicion.Substring(0, condicion.Length() - 1)

        End If

        dtInfo = BLOrdenes.consultarAislamiento(datosConexion, condicion)

        chkListAislamiento.Items().Clear()

        If dtInfo.Rows.Count > 0 Then
            dtInfo.Rows.InsertAt(dtInfo.NewRow(), 0)
        End If

        For i As Integer = 0 To dtInfo.Rows.Count - 1

            If i <> 0 Then

                chkListAislamiento.Items.Add(dtInfo.Rows(i)("descripcion").ToString(), False)

            End If

        Next

        If dtGrilla.Rows.Count() > 0 Then

            If ValidaSuspendidos() Then

                chkNoReqAislamiento.Enabled = True

            Else

                chkNoReqAislamiento.Enabled = False

            End If

        Else

            chkNoReqAislamiento.Enabled = True

        End If

        If dtgAislamiento.Rows.Count() = 1 Then

            Dim dtValidacionNoAisla As DataTable
            dtValidacionNoAisla = dtgAislamiento.DataSource

            For Each fila As DataRow In dtValidacionNoAisla.Rows

                If fila("tipo_aislamiento").ToString() = "0" Then

                    chkListAislamiento.Enabled = False
                    btnAgregarAislamiento.Enabled = False

                End If

            Next

        End If

    End Sub

    ''Dsanchez IG - Valida si seleccionó item - 11/10/2017
    Private Function ValidaItemSeleccionado() As Boolean

        Dim validacion As Boolean = False

        If chkNoReqAislamiento.Checked = False Then

            For i As Integer = 0 To chkListAislamiento.Items.Count - 1

                If chkListAislamiento.GetItemChecked(i) = True Then

                    validacion = True
                    Exit For

                End If

            Next

        Else

            validacion = True

        End If

        Return validacion

    End Function

    Private Sub chkNoReqAislamiento_Click(sender As Object, e As EventArgs) Handles chkNoReqAislamiento.Click

        If chkNoReqAislamiento.Checked = True Then

            chkListAislamiento.Enabled = False
            btnAgregarAislamiento.Enabled = True

        Else

            chkListAislamiento.Enabled = True
            btnAgregarAislamiento.Enabled = True

        End If

        Panel6.Focus()

    End Sub

    Private Sub chkNoReqAislamiento_CheckedChanged(sender As Object, e As EventArgs) Handles chkNoReqAislamiento.CheckedChanged

        If chkNoReqAislamiento.Checked = True Then

            cargaAislamiento(dtgAislamiento.DataSource)
            chkListAislamiento.Enabled = False

        End If

    End Sub

    '' Dsanchez IG - 09-10-2017, valida si se relaizo gestion en rpescripcion de aislamientos
    Private Function validaGuardarAislamientos() As Boolean

        Dim resultadoValidacion As Boolean = True
        Dim dtInfo As DataTable = dtgAislamiento.DataSource
        Dim cantidadNuevo As Integer = 0
        Dim val As Integer = 0

        If dtInfo.Rows.Count() = 0 Then

            resultadoValidacion = False

        Else

            For Each filaNuevo As DataRow In dtInfo.Rows
                If filaNuevo("aisla_nuevo").ToString() = "1" Then
                    cantidadNuevo = cantidadNuevo + 1
                End If
            Next

            For i As Integer = 0 To dtgAislamiento.Rows.Count - 1
                If dtgAislamiento(7, i).Value.ToString = "C" Or dtgAislamiento(7, i).Value.ToString = "I" Then
                    val = val + 1
                End If
            Next

            If cantidadNuevo = dtInfo.Rows.Count() Then
                resultadoValidacion = True

            Else

                For Each filaAntiguo As DataRow In dtInfo.Rows

                    If filaAntiguo("aisla_nuevo").ToString() = "0" Then

                        If CBool(filaAntiguo("aisla_continuar").ToString()) = False And CBool(filaAntiguo("aisla_suspender").ToString()) = False Then
                            resultadoValidacion = False
                            Exit For
                        End If
                    End If

                Next

            End If

        End If

        If Not resultadoValidacion And val > 0 Then
            For i As Integer = 0 To dtgAislamiento.Rows.Count - 1
                If BLOrdenes.ValidarDieta24Horas1(dtgAislamiento(10, i).Value.ToString) Then
                    resultadoValidacion = False
                Else
                    resultadoValidacion = True
                End If
            Next
        End If

        If val = 0 Then
            resultadoValidacion = False
        End If

        Return resultadoValidacion

    End Function

    Private Sub dtgAislamiento_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles dtgAislamiento.UserDeletedRow


        Dim dtInfo As DataTable

        dtInfo = dtgAislamiento.DataSource

        If validaItemsSuspenderMarca() = True Then

            chkNoReqAislamiento.Enabled = True
            chkNoReqAislamiento.Checked = False
            chkListAislamiento.Enabled = True
            btnAgregarAislamiento.Enabled = True

        Else

            chkNoReqAislamiento.Enabled = False

        End If

        cargaAislamiento(dtgAislamiento.DataSource)

        For Each fila As DataRow In dtInfo.Rows()

            If fila("tipo_aislamiento").ToString() = "0" Then
                chkNoReqAislamiento.Enabled = False
            End If
        Next

    End Sub

    Private Function validaItemsSuspenderMarca() As Boolean

        Dim dtInfo As DataTable
        Dim validacion As Boolean = True
        Dim cantNuevo As Integer = 0

        dtInfo = dtgAislamiento.DataSource

        If dtInfo.Rows.Count() = 0 Then

            validacion = True

        Else

            For Each fila As DataRow In dtInfo.Rows

                If fila("aisla_nuevo").ToString() = "1" Then

                    cantNuevo = cantNuevo + 1

                End If

            Next

            If cantNuevo > 0 Then

                validacion = False

            End If

            If validacion = True Then

                validacion = ValidaSuspendidos()

            End If

        End If

        Return validacion

    End Function

    Private Sub dtgAislamiento_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dtgAislamiento.UserDeletingRow


        Dim valor As String = e.Row.Cells("aisla_nuevo").Value.ToString()

        If valor = "1" Then

            If MessageBox.Show("¿Está seguro que desea eliminar este registro", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then

                e.Cancel = False

            Else

                e.Cancel = True

            End If

        Else

            MessageBox.Show("No se puede eliminar el registro", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Cancel = True

        End If

    End Sub

    ''Dsanchez IG - Se crea metodo para actualizar grilla de aislamientos - 12/10/2017
    Private Sub ActualizarGrillaAislamiento(ByVal validado As Boolean)

        If validado Then

            dsAislamiento = BLOrdenes.consultarOrdenes(datosConexion, datosLogin.Prestador, datosLogin.Sucursal,
                                      datosPaciente.TipoAdmision, datosPaciente.AnoAdmision, datosPaciente.NumeroAdmision)

            configurarGrillaAislamiento(dsAislamiento.Tables("AISLAMIENTO"))
            cargaAislamiento(dtgAislamiento.DataSource)
            configurarGrillaDietas(dsAislamiento.Tables("DIETAS"))

        End If

    End Sub

    Private Function ValidaSuspendidos() As Boolean

        Dim cantidadRegistros As Integer = 0
        Dim cantidadSuspendidos As Integer = 0
        Dim tablaValidacion As DataTable
        Dim suspendido As Boolean = False

        tablaValidacion = dtgAislamiento.DataSource
        cantidadRegistros = tablaValidacion.Rows().Count()

        For Each fila As DataRow In tablaValidacion.Rows()

            suspendido = CBool(fila("aisla_suspender").ToString())

            If suspendido Then

                cantidadSuspendidos = cantidadSuspendidos + 1

            End If

        Next

        If cantidadSuspendidos = cantidadRegistros Then

            Return True

        Else

            Return False

        End If

    End Function

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
    Private Sub txttiporden_Validating(sender As Object, e As CancelEventArgs) Handles txttiporden.Validating
        If txttiporden.Text = "" Then
            Exit Sub
        End If
        ''Claudia Garay Cambios Acreditacion campo Oxigeno febrero de 2011
        If txttiporden.Text = 106 Or txttiporden.Text = 107 Then
            txtTextoOrden.Enabled = False
        Else
            txtTextoOrden.Enabled = False
        End If
    End Sub
    ''' <summary>
    ''' Nuevo: eloaiza@intergrupo.com
    ''' 10/2019
    ''' Req. ER_OSI_584 Prescripcion_de_medicamentos
    ''' Validacion de exclusion si se selecciona el item de infusion continua de la lista de frecuencias el check de bolo no debe estar seleccionado
    ''' </summary>
    ''' <remarks></remarks>
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

    'Joseph Moreno (IG) Fec:2019/11/18 Particularidades
    Private Sub ctlPartProce_Load(sender As Object, e As EventArgs) Handles ctlPartProce.Load
        Me.ctlPartProce.PasarParametros(Me.lblParticularidad, 200, 3)
    End Sub
    ''' <summary>
    ''' Nuevo: eloaiza@intergrupo.com
    ''' 10/2019
    ''' Req. ER_OSI_584 Prescripcion_de_medicamentos
    ''' Validacion de exclusion si se selecciona el item de infusion continua de la lista de frecuencias el check de bolo no debe estar seleccionado
    ''' </summary>
    ''' <remarks></remarks>
    'Private Sub txtDescripcionFreq_Leave(sender As Object, e As EventArgs) Handles MyBase.Click, txtDescripcionFreq.Leave, txtDescripcionFreq.LostFocus

    '    If Not String.IsNullOrEmpty(Me.txtDescripcionFreq.Text) Then
    '        Dim codFrecuencia As String = txtDescripcionFreq.Text.Trim()
    '        If codFrecuencia = "31" Or codFrecuencia.Contains("infusi") Then
    '            ChkBolo.Checked = False
    '            ChkBolo.Enabled = False
    '            pnlDurante.Visible = True
    '            pnlPasarEn.Visible = False
    '        Else
    '            ChkBolo.Enabled = True
    '        End If
    '        ValidarTexto(txtDescripcionFreq, Me.txtDescripcionFreq.Text)
    '        SendKeys.Send("{ENTER}")
    '        SendKeys.Send("{TAB}")
    '    Else
    '        Exit Sub
    '    End If

    'End Sub

    ''' <summary>
    ''' Nuevo: eloaiza@intergrupo.com
    ''' 10/2019
    ''' Req. ER_OSI_584 Prescripcion_de_medicamentos
    ''' Validacion de exclusion si se selecciona el item de infusion continua de la lista de frecuencias el check de bolo no debe estar seleccionado
    ''' </summary>
    ''' <remarks></remarks>
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
    Private Sub txtDescripcionGen_Leave(sender As Object, e As EventArgs) Handles txtDescripcionVA.Leave, txtDescripcionUM.Leave
        ValidarTexto(sender, (DirectCast(sender, ComboBox)).Text)
    End Sub
    Private Sub txtRangosGen_Leave(sender As Object, e As EventArgs) Handles txtPasarEn.Leave
        ValidarRangoNumeros(sender)
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
    Private Sub InicializaValorControles()
        txtDurante24.Text = ""
        txtPasarEn.Text = ""
        txtNumRescates.Text = ""
        txtNumDosis.Text = ""
        txtCantidadC.Text = ""
        txtCantidadLetras.Text = ""
        txtDescripcionFreq.ResetText()
        txtDescripcionUM.ResetText()
        txtDescripcionVA.ResetText()
        Me.GroupCnt24.Visible = False
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

    Private Function ValidarFinalizarHcb() As Boolean
        Dim objFinalizarHcb As New BLHistoriaBasica

        Dim Datos() As Object
        Dim lExistencia As Long
        Dim dtExistencia As DataTable

        ReDim Datos(4)
        Datos(0) = objGenerales.Generales.Instancia.Prestador
        Datos(1) = objGenerales.Generales.Instancia.Sucursal
        Datos(2) = datosPaciente.TipoAdmision
        Datos(3) = datosPaciente.AnoAdmision
        Datos(4) = datosPaciente.NumeroAdmision

        Try

            dtExistencia = objFinalizarHcb.NVALIDAGRABACIONFINALHcb(datosConexion, lExistencia, Datos)
            If dtExistencia.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Error Validacion Finalizar Historia Basica")
        End Try
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

    ''' <summary>
    ''' Manejador génerico de eventos leave en control para que indique cuando un campo es obligatorio
    ''' cambiando el color de fondo del mismo. (Textbox, proximamente ListBox....)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
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

    ''Christian Gutierrez - OSI. 31/01/2020
    ''Descripción: Valida si el Procedimiento y Centro de Costo Destino seleccionado para ordenar,
    ''             muestra o no el control para seleccionar las Particularidades
    Private Function MostrarParticularidades() As Boolean

        ''CCGUTIEREZ. 30/09/2021. ALM-206
        ''Siempre retorna True para mostrar las Particularidades

        'Dim strFlagCSH As String
        'Dim strProceRIS As String

        Dim muestraPart As Boolean = True

        ''Se corrige la condicion para controlar la visualizacion de las Particularidades
        ''Mesa de trabajo. 15/10/2021
        If Me.cmbCentroCosto.SelectedIndex <= 0 Then
            Exit Function
        End If

        'If Me.cmbCentroCosto.SelectedIndex = 0 Then
        '    Exit Function
        'End If

        Return muestraPart

        'If Len(cmbCentroCosto.Text) > 0 Then

        '    strFlagCSH = Me.cmbCentroCosto.SelectedItem("man_csh").ToString
        '    strProceRIS = Me.cmbCentroCosto.SelectedItem("proceRIS").ToString

        '    If strFlagCSH = "S" And strProceRIS = txtCodProcedim.Text Then
        '        muestraPart = True
        '    ElseIf strFlagCSH <> "S" And strProceRIS <> txtCodProcedim.Text Then
        '        muestraPart = True
        '    ElseIf strFlagCSH = "S" And strProceRIS <> txtCodProcedim.Text Then
        '        muestraPart = True
        '    Else
        '        muestraPart = False
        '    End If

        '    Return muestraPart

        'End If

    End Function

    Private Sub txtDosis_KeyPress(sender As Object, e As KeyPressEventArgs)

        Dim keychar As Integer = AscW(e.KeyChar)
        If keychar = 8 Then
            e.Handled = False
            Exit Sub
        End If

        Dim IsDec As Boolean = False
        Dim nroDec As Integer = 0
        If txtDosis.Text.Length < 1 Then
            Exit Sub
        End If
        For i As Integer = 1 To txtDosis.Text.Length
            If txtDosis.Text.Chars(i - 1) = "." Then
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

    Private Sub dtgMedicamentos_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dtgMedicamentos.RowsAdded
        ' REQ ER OSI 584 eloaiza@intergrupo.com - Validar si registro es nuevo, solo aplica para registros existieran en la prescripcion
        If Not String.IsNullOrEmpty((dtgMedicamentos.Rows(e.RowIndex).Cells("idRegistro")).Value.ToString) Then
            DirectCast(dtgMedicamentos.Rows(dtgMedicamentos.RowCount - 1).Cells("continuar_med"), DataGridViewCheckBoxCell).Value = False
            DirectCast(dtgMedicamentos.Rows(dtgMedicamentos.RowCount - 1).Cells("continuar_med"), DataGridViewCheckBoxCell).ReadOnly = True
            DirectCast(dtgMedicamentos.Rows(dtgMedicamentos.RowCount - 1).Cells("modificar_med"), DataGridViewCheckBoxCell).Value = False
            DirectCast(dtgMedicamentos.Rows(dtgMedicamentos.RowCount - 1).Cells("modificar_med"), DataGridViewCheckBoxCell).ReadOnly = True
            DirectCast(dtgMedicamentos.Rows(dtgMedicamentos.RowCount - 1).Cells("suspender_med"), DataGridViewCheckBoxCell).Value = False
            DirectCast(dtgMedicamentos.Rows(dtgMedicamentos.RowCount - 1).Cells("suspender_med"), DataGridViewCheckBoxCell).ReadOnly = True
        End If

    End Sub

    Private Sub dtgMedicamentos_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dtgMedicamentos.CellContentClick 'dtgMedicamentos.CellValueChanged ', , dtgMedicamentos.CellClick,

        If e.RowIndex = -1 Then
            Return
        End If


        Dim fecha_1 As Date
        Dim fecha_2 As Date
        Dim dias As Integer
        Dim FlagSispro As String
        Dim dtcmbFRE As New DataTable
        'Dim rows() As DataRow
        Dim dtDatos As DataTable = dtgMedicamentos.DataSource

        If Not BLOrdenes.puedeModificarTratamiento(dtDatos.Rows(e.RowIndex)) Then
            Exit Sub
        End If

        'validar dias de tratamiento para SISPRO rmzaldua 2017-03-09
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
            ActualizarEstadoNuevo(e.RowIndex, String.Empty, FlagSispro)
        Else

            'dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = chkSuspender.FalseValue
            Dim chkSuspender As DataGridViewCheckBoxCell = DirectCast(dtgMedicamentos.Rows(e.RowIndex).Cells("suspender_med"), DataGridViewCheckBoxCell)
            Dim chkModificar As DataGridViewCheckBoxCell = DirectCast(dtgMedicamentos.Rows(e.RowIndex).Cells("modificar_med"), DataGridViewCheckBoxCell)


            ' Valores que reprsentan la marcacion en las casillas (Verdadero, Falso)
            'Dim valoresContinuar As String() = {"C", "S"}
            'Dim valoresModificar As String() = {"M", "N"}
            'Dim valoresSuspender As String() = {"S", "C"}

            If dtgMedicamentos.CurrentCell.ReadOnly = True Then 'Desmarcar el check de reformular
                Exit Sub
            End If

            If dtgMedicamentos.CurrentCell.Value = "C" Then
                dtgMedicamentos.CurrentCell.Value = "S"
                MessageBox.Show("Para poder realizar esta acción debe desmarcar el check box modificar.", "Ordenes Medicas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                If dtgMedicamentos.CurrentCell.Value = "S" Then
                    dtgMedicamentos.CurrentCell.Value = "C"
                    MessageBox.Show("Para poder realizar esta acción debe desmarcar el check box modificar.", "Ordenes Medicas", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    If dtgMedicamentos.CurrentCell.Value = "N" Then
                        Me.pnlDurante.Visible = False
                        falg_modificar = 0
                        ActualizarEstadoNuevo(e.RowIndex, String.Empty, FlagSispro)
                        If GroupCnt24.Visible = True Then
                            GroupCnt24.Visible = False
                        End If
                    Else
                        dtgMedicamentos.CurrentCell.Value = "N"
                        MessageBox.Show("Para poder realizar esta acción debe desmarcar el check box modificar.", "Ordenes Medicas", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        dtgMedicamentos.Rows(e.RowIndex).Cells("modificar_med").Value = chkModificar.FalseValue
                        dtgMedicamentos.Rows(e.RowIndex).Cells("suspender_med").Value = chkSuspender.FalseValue
                    End If
                End If
            End If
            dtgMedicamentos.RefreshEdit()
            'dtgMedicamentos.CurrentCell.Selected = True
            'dtgMedicamentos.EndEdit()
        End If
        ' dtgMedicamentos.Invalidate()
        'dtgMedicamentos.Update()

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="e"></param>
    ''' <param name="tratamiento"></param>
    ''' <param name="flag_sispro"></param>
    Private Sub ActualizarEstadoNuevo(ByRef e As Integer, ByVal tratamiento As String, ByVal flag_sispro As String)

        'If TypeOf dtgMedicamentos.CurrentCell Is DataGridViewCheckBoxCell Then
        '    valorCheck = IIf(Not String.IsNullOrEmpty(dtgMedicamentos.CurrentCell.Value), dtgMedicamentos.CurrentCell.Value, "")
        'End If

        ' Valores que reprsentan la marcacion en las casillas (Verdadero, Falso)
        'Dim valoresContinuar As String() = {"C", "S"}
        'Dim valoresModificar As String() = {"M", "N"}
        'Dim valoresSuspender As String() = {"S", "C"}

        Dim chkContinuar As DataGridViewCheckBoxCell = DirectCast(dtgMedicamentos.Rows(e).Cells("continuar_med"), DataGridViewCheckBoxCell)
        Dim chkModificar As DataGridViewCheckBoxCell = DirectCast(dtgMedicamentos.Rows(e).Cells("modificar_med"), DataGridViewCheckBoxCell)
        Dim chkSuspender As DataGridViewCheckBoxCell = DirectCast(dtgMedicamentos.Rows(e).Cells("suspender_med"), DataGridViewCheckBoxCell)

        Dim Fila As DataGridViewRow = DirectCast(dtgMedicamentos.Rows(e), DataGridViewRow)

        'Asegurar cual opción se selecciono
        Dim refSel As Boolean = (Fila.Cells("continuar_med")).Selected
        Dim modSel As Boolean = (Fila.Cells("modificar_med")).Selected
        Dim susSel As Boolean = (Fila.Cells("suspender_med")).Selected



        Fila.Cells("suspender_med").ReadOnly = False


        If dtgMedicamentos.CurrentCell.ColumnIndex = dtgMedicamentos.Columns("continuar_med").Index Then
            If Me.dtgMedicamentos.Rows(e).Cells("continuar_med").Value = "C" Then 'si el check lo activaron
                If ValidarContinuar(e).Length > 0 Then 'REQ 584 20200610 Raul Cruz
                    MsgBox(ValidarContinuar(e), MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If
            ComportamientoReformular(e, BLOrdenes.CONTINUA, flag_sispro)
        End If
        If dtgMedicamentos.CurrentCell.ColumnIndex = dtgMedicamentos.Columns("modificar_med").Index Then '' COLUMNA SUSPENDER
            ComportamientoModificar(e, String.Empty, flag_sispro)
        End If
        If dtgMedicamentos.CurrentCell.ColumnIndex = dtgMedicamentos.Columns("suspender_med").Index Then '' COLUMNA SUSPENDER           
            ComportamientoSuspender(e, String.Empty, flag_sispro)
        End If



        Exit Sub
        Select Case True
            Case refSel

                Fila.Cells("continuar_med").Selected = True
                Fila.Cells("modificar_med").Selected = False
                Fila.Cells("suspender_med").Selected = False
                Fila.Cells("suspender_med").ReadOnly = False

            Case modSel
                ComportamientoModificar(e, BLOrdenes.MODIFICA, flag_sispro)
                Fila.Cells("modificar_med").Value = True
                Fila.Cells("modificar_med").Selected = True
                Fila.Cells("suspender_med").Value = True
                Fila.Cells("continuar_med").Value = False

            Case susSel
                ComportamientoSuspender(e, BLOrdenes.SUSPENDE, flag_sispro)
                Fila.Cells("suspender_med").Value = True
                Fila.Cells("continuar_med").Value = False 'chkContinuar.FalseValue

        End Select

        dtgMedicamentos.EndEdit()

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

        Dim dtDatos As DataTable = dtgMedicamentos.DataSource
        Dim dtcmbFRE As New DataTable
        Dim rows() As DataRow
        Dim flagCambio As Boolean = False
        Dim valorCelda As String = dtgMedicamentos.CurrentCell.Value.ToString()

        dtgMedicamentos.CurrentCell.Value = System.DBNull.Value

        BLOrdenes.actualizarEstado(dtDatos.Rows(IndiceFilaSeleccionada), BLOrdenes.CONTINUA, dtgMedicamentos.CurrentCell.Value, flag_sispro)

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
        Dim chkContinuar As DataGridViewCheckBoxCell = DirectCast(dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("continuar_med"), DataGridViewCheckBoxCell)
        Dim chkModificar As DataGridViewCheckBoxCell = DirectCast(dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("modificar_med"), DataGridViewCheckBoxCell)
        Dim chkSuspender As DataGridViewCheckBoxCell = DirectCast(dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("suspender_med"), DataGridViewCheckBoxCell)

        chkContinuar.Value = valorCelda

        'GroupCnt24.Visible = False
        'lblCantidadC.Visible = False
        'txtCantidadC.Visible = False
        'lblCantLetras.Visible = False
        'txtCantidadLetras.Visible = False

        If dtgMedicamentos.CurrentCell.Value = "C" Then

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
                dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = chkSuspender.TrueValue
                dtgMedicamentos.CurrentCell.Value = chkContinuar.FalseValue
                dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_suspender_med") = chkSuspender.TrueValue
                dtDatos.Rows(IndiceFilaSeleccionada).Item("tratamiento") = chkContinuar.FalseValue
                'dtDatos.AcceptChanges()
                dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = chkSuspender.FalseValue
                dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("continuar_med").Value = chkContinuar.FalseValue
                'dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("continuar_med"). = False
                dtgMedicamentos.Update()
                dtgMedicamentos.RefreshEdit()
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

            dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = chkSuspender.FalseValue
            dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("modificar_med").Value = chkModificar.FalseValue

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
                    BLOrdenes.actualizarEstado(dtDatos.Rows(IndiceFilaSeleccionada), BLOrdenes.CONTINUA, dtgMedicamentos.CurrentCell.Value, flag_sispro)
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
                    dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = chkSuspender.TrueValue
                    dtgMedicamentos.CurrentCell.Value = chkContinuar.FalseValue
                    dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_suspender_med") = chkSuspender.TrueValue
                    dtDatos.Rows(IndiceFilaSeleccionada).Item("tratamiento") = chkContinuar.FalseValue
                    'dtDatos.AcceptChanges()
                    dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = chkSuspender.TrueValue
                    dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("continuar_med").Value = chkContinuar.FalseValue
                    dtgMedicamentos.Update()
                    dtgMedicamentos.RefreshEdit()
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

                    BLOrdenes.actualizarEstado(dtDatos.Rows(IndiceFilaSeleccionada), BLOrdenes.CONTINUA, dtgMedicamentos.CurrentCell.Value, flag_sispro)
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

            If Not IsDBNull(dtgMedicamentos.CurrentCell.Value) Then
                If dtgMedicamentos.CurrentCell.Value = "S" And Not flagCambio Then
                    ' dtgMedicamentos.CurrentCell.Value = "C" pilas raul validar que pasa sin esto
                    dtDatos.Rows(IndiceFilaSeleccionada).Item("obs") = ""
                Else
                    dtgMedicamentos.CurrentCell.Value = "S"
                    dtDatos.Rows(IndiceFilaSeleccionada).Item("obs") = "M"
                End If
            End If

        End If

        BLOrdenes.actualizarEstado(dtDatos.Rows(IndiceFilaSeleccionada), BLOrdenes.CONTINUA, dtgMedicamentos.CurrentCell.Value, flag_sispro)

        If dtDatos.Rows(IndiceFilaSeleccionada).Item("obs") = "M" And dtgMedicamentos.CurrentCell.Value = "C" Then
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
        dtgMedicamentos.CurrentCell.Value = valorCelda
        dtgMedicamentos.RefreshEdit()
#End Region
    End Sub

    Private Sub ComportamientoModificar(ByVal IndiceFilaSeleccionada As Integer, ByVal tratamiento As String, ByVal flag_sispro As String)
#Region "Modificar"

        Dim dtDatos As DataTable = dtgMedicamentos.DataSource
        Dim chkContinuar As DataGridViewCheckBoxCell = DirectCast(dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("continuar_med"), DataGridViewCheckBoxCell)
        Dim chkModificar As DataGridViewCheckBoxCell = DirectCast(dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("modificar_med"), DataGridViewCheckBoxCell)
        Dim chkSuspender As DataGridViewCheckBoxCell = DirectCast(dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("suspender_med"), DataGridViewCheckBoxCell)


        If dtgMedicamentos.CurrentCell.ReadOnly = True Then 'Desmarcar el check de reformular
            txtTecnica.Text = ""
            If dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("Frecuencia").Value = "47" Then
                MsgBox("Debe generar una nueva orden para este medicamento", MsgBoxStyle.Information)
                dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("continuar_med").Value = False 'le quito el check
                dtgMedicamentos.Update()
                dtgMedicamentos.RefreshEdit()
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
            dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = chkSuspender.TrueValue
            dtgMedicamentos.CurrentCell.Value = chkContinuar.FalseValue
            dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_suspender_med") = chkSuspender.TrueValue
            dtDatos.Rows(IndiceFilaSeleccionada).Item("tratamiento") = chkContinuar.FalseValue
            'dtDatos.AcceptChanges()
            dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = chkSuspender.TrueValue
            dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("continuar_med").Value = chkContinuar.FalseValue
            dtgMedicamentos.Update()
            dtgMedicamentos.RefreshEdit()
            Exit Sub
        End If

        valorModificar = dtgMedicamentos.CurrentCell.Value
        For i As Integer = 0 To dtDatos.Rows.Count - 1
            If dtDatos.Rows(i).Item("obs") = "M" Then
                dtDatos.Rows(i).Item("obs") = "N" 'MARTOVAR CONTROL DE LIQUIDOS 2018/05/31
                dtDatos.Rows(i).Item("tmp_modificar_med") = "N"
            End If
        Next

        If chkModificar.Value = chkModificar.TrueValue Then 'Desmarcar el check de reformular
            chkContinuar.Value = chkContinuar.FalseValue
            DirectCast(dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("modificar_med"), DataGridViewCheckBoxCell).Value = valorModificar
            chkModificar.Value = valorModificar
        End If

        If (chkSuspender.Value = chkSuspender.TrueValue And chkModificar.Value = chkModificar.FalseValue) Then
            DirectCast(dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("suspender_med"), DataGridViewCheckBoxCell).Value = chkSuspender.FalseValue
        End If
        If Not IsDBNull(dtgMedicamentos.CurrentCell.Value) Then
            If dtgMedicamentos.CurrentCell.Value = "M" And IsDBNull(dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_modificar_med")) Then
                dtgMedicamentos.CurrentCell.Value = "M"
                dtDatos.Rows(IndiceFilaSeleccionada).Item("obs") = "M"
                dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_suspender_med") = "S"
                dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = chkSuspender.TrueValue
                dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("continuar_med").Selected = False
                dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("continuar_med").Value = chkContinuar.FalseValue
            ElseIf dtgMedicamentos.CurrentCell.Value = "N" And (dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_modificar_med").ToString() = "N" And String.IsNullOrEmpty(dtDatos.Rows(IndiceFilaSeleccionada).Item("obs").ToString())) Then
                dtgMedicamentos.CurrentCell.Value = "M"
                dtDatos.Rows(IndiceFilaSeleccionada).Item("obs") = "M"
                dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_suspender_med") = "S"
                dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = "S"
                dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("continuar_med").Selected = False
                dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("continuar_med").Value = "S"
            ElseIf dtgMedicamentos.CurrentCell.Value = "M" And dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_modificar_med").ToString() = "N" Then
                dtgMedicamentos.CurrentCell.Value = "M"
                dtDatos.Rows(IndiceFilaSeleccionada).Item("obs") = "M"
                dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_suspender_med") = chkSuspender.TrueValue
                dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = "S"
                dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("continuar_med").Selected = False
                dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("continuar_med").Value = "S"
            ElseIf dtgMedicamentos.CurrentCell.Value = "M" And dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_modificar_med").ToString() = "M" Then
                dtgMedicamentos.CurrentCell.Value = chkModificar.FalseValue
                dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_suspender_med") = chkSuspender.FalseValue
                dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = chkSuspender.FalseValue
                dtDatos.Rows(IndiceFilaSeleccionada).Item("obs") = ""
            ElseIf dtgMedicamentos.CurrentCell.Value = "N" And dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_modificar_med").ToString() = "M" Then
                dtgMedicamentos.CurrentCell.Value = "N"
                dtDatos.Rows(IndiceFilaSeleccionada).Item("obs") = ""
                dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_suspender_med") = "C"
                dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = chkSuspender.FalseValue
                dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("continuar_med").Selected = False
                dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("continuar_med").Value = "S"
            ElseIf dtgMedicamentos.CurrentCell.Value = "N" And dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_modificar_med").ToString() = "N" And
                   dtDatos.Rows(IndiceFilaSeleccionada).Item("obs").ToString() = "N" And dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_suspender_med").ToString() = "S" Then
                dtgMedicamentos.CurrentCell.Value = chkModificar.FalseValue
                dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_suspender_med") = chkSuspender.FalseValue
                dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = chkSuspender.FalseValue
                dtDatos.Rows(IndiceFilaSeleccionada).Item("obs") = ""
            Else
                dtgMedicamentos.CurrentCell.Value = "M"
                dtDatos.Rows(IndiceFilaSeleccionada).Item("obs") = "M"
                dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_modificar_med") = dtgMedicamentos.CurrentCell.Value
                dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_suspender_med") = "S"
                DirectCast(dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("suspender_med"), DataGridViewCheckBoxCell).ReadOnly = True
                dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = "S"
                chkSuspender.ReadOnly = True
                dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("continuar_med").Value = "S"

                'dtDatos.Rows(e.RowIndex).Item("obs") = ""
            End If
            dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_modificar_med") = dtgMedicamentos.CurrentCell.Value
        End If
        dtDatos.Rows(IndiceFilaSeleccionada).AcceptChanges()
        dtDatos.Rows(IndiceFilaSeleccionada).SetModified()

        BLOrdenes.actualizarEstado(dtDatos.Rows(IndiceFilaSeleccionada), BLOrdenes.CONTINUA, dtgMedicamentos.CurrentCell.Value, flag_sispro)
        'BLOrdenes.actualizarEstado(dtDatos.Rows(e.RowIndex), BLOrdenes.MODIFICA, dtgMedicamentos.CurrentCell.Value)






        If dtDatos.Rows(IndiceFilaSeleccionada).Item("obs") = "M" Then

            MostrarInforMed(IndiceFilaSeleccionada)
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
        End If
        dtgMedicamentos.CurrentCell.Value = valorModificar
        dtgMedicamentos.RefreshEdit()
        Me.datosSinAlmacenar = True
#End Region
    End Sub
    Private Sub ComportamientoSuspender(ByVal IndiceFilaSeleccionada As Integer, ByVal tratamiento As String, ByVal flag_sispro As String)
#Region "Suspender"
        ' Suspender
        Dim resultado As String
        Dim mensaje = String.Empty

        If dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("Frecuencia").Value = "47" Then 'Dosis Unica ER_OSI_584 D.Suspender Raul Cruz
            resultado = New BLOrdenes().ConsultarEstadoDosisUnica(dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("cod_pre_sgs").Value,
                                                                  dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("cod_sucur").Value,
                                                                  dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("tip_admision").Value,
                                                                  dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("num_adm").Value,
                                                                  dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("ano_adm").Value,
                                                                  dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("NroOrden").Value,
                                                                  dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("Secuencia").Value)
            If resultado = "S" Then
                mensaje = "El medicamento ya fue administrado"
                dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = False 'le quito el check
                dtgMedicamentos.Update()
                dtgMedicamentos.RefreshEdit()
                MsgBox(mensaje, MsgBoxStyle.Information)
                Exit Sub
            End If

        End If

        Dim dtDatos As DataTable = dtgMedicamentos.DataSource
        valorSuspender = dtgMedicamentos.CurrentCell.Value 'IIf(String.IsNullOrEmpty(dtgMedicamentos.CurrentCell.Value) Or IsDBNull(dtgMedicamentos.CurrentCell.Value), valoresSuspender(1), valoresSuspender(0))
        dtgMedicamentos.CurrentCell.Value = System.DBNull.Value
        If dtgMedicamentos.CurrentCell.ColumnIndex = dtgMedicamentos.Columns("suspender_med").Index Then
            If dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("modificar_med").Value = "M" Then
                dtDatos.Rows(IndiceFilaSeleccionada).Item("tmp_suspender_med") = "S"
                dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Selected = True
                dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = "S"
                DirectCast(dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("suspender_med"), DataGridViewCheckBoxCell).ReadOnly = True

                Exit Sub
            Else
                dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Selected = True
                dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("suspender_med").Value = "S"
                dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("continuar_med").Value = "S"
                dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("modificar_med").Value = "N"
            End If
            If dtDatos.Rows(IndiceFilaSeleccionada).Item("diastrat") > 0 Then
                If flag_sispro = "S" Then
                    BLOrdenes.actualizarEstado(dtDatos.Rows(IndiceFilaSeleccionada), BLOrdenes.ACTIVO, "C", flag_sispro)
                Else
                    BLOrdenes.actualizarEstado(dtDatos.Rows(IndiceFilaSeleccionada), BLOrdenes.SUSPENDE, dtgMedicamentos.CurrentCell.Value, flag_sispro)
                End If
            Else
                dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("continuar_med").Value = "S"
                dtgMedicamentos.Rows(IndiceFilaSeleccionada).Cells("continuar_med").Selected = False
                BLOrdenes.actualizarEstado(dtDatos.Rows(IndiceFilaSeleccionada), BLOrdenes.SUSPENDE, "S", flag_sispro) 'raul cruz 20200721
            End If
            dtDatos.Rows(IndiceFilaSeleccionada).AcceptChanges()
            dtDatos.Rows(IndiceFilaSeleccionada).SetModified()
            dtgMedicamentos.CurrentCell.Value = valorSuspender
            dtgMedicamentos.RefreshEdit()
            Me.datosSinAlmacenar = True
        End If
#End Region
    End Sub
    Private Sub dtgMedicamentos_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dtgMedicamentos.CurrentCellDirtyStateChanged
        'Debug.Print("dgvSN_CurrentCellDirtyStateChanged")
        'MessageBox.Show("CurrentCellDirtyStateChanged")
        If dtgMedicamentos.IsCurrentCellDirty Then
            dtgMedicamentos.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub
    Private Sub dtgMedicamentos_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dtgMedicamentos.DataBindingComplete
        ' Validar primero si la frecuencia es dosis unica (47), si es así se inhabilita
        Dim dtDatos As DataTable = dtgMedicamentos.DataSource
        Dim codFrecuencia As String = String.Empty
        Dim tbFreq As DataTable
        For Each Fila As DataGridViewRow In dtgMedicamentos.Rows
            Dim chkCurrent As DataGridViewCheckBoxCell = DirectCast(dtgMedicamentos.Rows(Fila.Index).Cells("modificar_med"), DataGridViewCheckBoxCell)
            codFrecuencia = IIf(Not IsDBNull(Fila.Cells("Frecuencia").Value), Fila.Cells("Frecuencia").Value, String.Empty)
            tbFreq = New BLOrdenes().ConsultarFrecuenciasHomologadas(codFrecuencia)
            If tbFreq.Rows.Count > 0 And codFrecuencia.Equals("47") Then
                Fila.Cells("modificar_med").Value = chkCurrent.FalseValue
                DirectCast(dtgMedicamentos.Rows(Fila.Index).Cells("modificar_med"), DataGridViewCheckBoxCell).Value = chkCurrent.FalseValue
                DirectCast(dtgMedicamentos.Rows(Fila.Index).Cells("modificar_med"), DataGridViewCheckBoxCell).ReadOnly = True
                dtgMedicamentos.InvalidateCell(dtgMedicamentos.CurrentCell)
            End If
        Next Fila
    End Sub

    Private Sub cmbDescripMedica_LostFocus(sender As Object, e As EventArgs) Handles cmbDescripMedica.LostFocus

        Dim Texto As String = cmbDescripMedica.Text
        If Texto.Length <= 2 Then
            MsgBox("Ingrese mínimo 3 caracteres para realizar la búsqueda")
        Else

        End If
    End Sub

    Private Sub txtDurante24_TextChanged(sender As Object, e As EventArgs)
        If IsNumeric(txtDurante24.Text) Then
            If CInt(txtDurante24.Text) < 1 Or CInt(txtDurante24.Text) > 120 Then 'ALM 127
                txtDurante24.Text = ""
            End If
        Else
            txtDurante24.Text = ""
        End If
    End Sub

    Private Sub txtPasarEn_TextChanged(sender As Object, e As EventArgs) Handles txtPasarEn.TextChanged
        If IsNumeric(txtPasarEn.Text) Then
            If CInt(txtPasarEn.Text) < 1 Then 'ALM 135
                txtPasarEn.Text = ""
            End If
        Else
            txtPasarEn.Text = ""
        End If
    End Sub

    Private Sub txtDosis_KeyPress_1(sender As Object, e As KeyPressEventArgs) Handles txtDosis.KeyPress


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

    Private Function ValidarContinuar(fila As Int32) As String
        Dim dtDatos As DataTable = dtgMedicamentos.DataSource
        Dim dtcmbFRE As New DataTable
        Dim rows() As DataRow
        Dim mensaje As String = ""
        Dim auxiliar As Integer = 0

        Dim chkContinuar As DataGridViewCheckBoxCell = DirectCast(dtgMedicamentos.Rows(fila).Cells("continuar_med"), DataGridViewCheckBoxCell)
        Dim chkModificar As DataGridViewCheckBoxCell = DirectCast(dtgMedicamentos.Rows(fila).Cells("modificar_med"), DataGridViewCheckBoxCell)
        Dim chkSuspender As DataGridViewCheckBoxCell = DirectCast(dtgMedicamentos.Rows(fila).Cells("suspender_med"), DataGridViewCheckBoxCell)
        Dim valorCelda As String = dtgMedicamentos.CurrentCell.Value.ToString()
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

        'inicio validación si no estan activos la frencuencia, unudad medida dosis y via de administración
        ' si no estan activos no se debe permitir seguir con el registro REQ 584 numeral B Gestión ordenes medicas historicas 
        dtcmbFRE = txtDescripcionFreq.DataSource
        rows = dtcmbFRE.Select("frecuencia='" & (dtDatos.Rows(fila)("Frecuencia")) & "'")

        If dtgMedicamentos.Rows(fila).Cells("Frecuencia").Value = "47" Then 'Dosis Unica
            mensaje = "Debe generar una nueva orden para este medicamento"
            dtgMedicamentos.Rows(fila).Cells("continuar_med").Value = False 'le quito el check
            dtgMedicamentos.Update()
            dtgMedicamentos.RefreshEdit()
            Return mensaje
        End If

        If rows.Length = 0 Then
            auxiliar = 1 'marca por que   esta inactivo
            mensaje = "Debe volver a realizar la prescripción de este medicamento/líquido"
            dtgMedicamentos.Rows(fila).Cells("continuar_med").Value = False 'le quito el check
            dtgMedicamentos.Update()
            dtgMedicamentos.RefreshEdit()
            Return mensaje
        End If

        dtcmbFRE = New DataTable
        dtcmbFRE = txtDescripcionUM.DataSource
        rows = dtcmbFRE.Select("concentracion='" & (dtDatos.Rows(fila)("UniMedDosis")) & "'")
        If rows.Length = 0 Then 'esta inactivo la unidad de medida

            auxiliar = 1 'marca por que   esta inactivo

            If dtDatos.Rows(fila)("UniMedDosis") = "3" Then ' se valida si el inactivo  tiene  homologo
                dtgMedicamentos.Rows(fila).Cells("UniMedDosis").Value = "67"
                auxiliar = 0 'marco por que no esta activo pero tiene un homologo
            End If

            If dtDatos.Rows(fila)("UniMedDosis") = "33" Then ' se valida si el inactivo  tiene  homologo
                dtgMedicamentos.Rows(fila).Cells("UniMedDosis").Value = "71"
                auxiliar = 0 'marco por que no esta activo pero tiene un homologo
            End If

            If dtDatos.Rows(fila)("UniMedDosis") = "48" Then ' se valida si el inactivo  tiene  homologo
                dtgMedicamentos.Rows(fila).Cells("UniMedDosis").Value = "72"
                auxiliar = 0 'marco por que no esta activo pero tiene un homologo
            End If

            If dtDatos.Rows(fila)("UniMedDosis") = "8" Then ' se valida si el inactivo  tiene  homologo
                dtgMedicamentos.Rows(fila).Cells("UniMedDosis").Value = "70"
                auxiliar = 0 'marco por que no esta activo pero tiene un homologo
            End If

            If dtDatos.Rows(fila)("UniMedDosis") = "27" Then ' se valida si el inactivo  tiene  homologo
                dtgMedicamentos.Rows(fila).Cells("UniMedDosis").Value = "69"
                auxiliar = 0 'marco por que no esta activo pero tiene un homologo
            End If

            If dtDatos.Rows(fila)("UniMedDosis") = "4" Then ' se valida si el inactivo  tiene  homologo
                dtgMedicamentos.Rows(fila).Cells("UniMedDosis").Value = "68"
                auxiliar = 0 'marco por que no esta activo pero tiene un homologo
            End If
        End If

        dtcmbFRE = New DataTable
        dtcmbFRE = txtDescripcionVA.DataSource

        rows = dtcmbFRE.Select("via='" & (dtDatos.Rows(fila)("ViaAdministra")) & "'")
        If rows.Length = 0 Then
            auxiliar = 1 'marca por que  no esta activo

            If dtDatos.Rows(fila)("ViaAdministra") = "IR" Or dtDatos.Rows(fila)("ViaAdministra") = "ES" Then ' se valida si el inactivo  tiene  homologo
                dtgMedicamentos.Rows(fila).Cells("ViaAdministra").Value = "IQ"
                auxiliar = 0 'marco por que no esta activo pero tiene un homologo
            End If

            If dtDatos.Rows(fila)("ViaAdministra") = "NA" Then ' se valida si el inactivo  tiene  homologo
                dtgMedicamentos.Rows(fila).Cells("ViaAdministra").Value = "IL"
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
            dtgMedicamentos.Rows(fila).Cells("continuar_med").Value = False 'le quito el check
            dtgMedicamentos.Update()
            dtgMedicamentos.RefreshEdit()
        Else
            dtgMedicamentos.Update()
            dtgMedicamentos.RefreshEdit()
        End If

        Return mensaje
    End Function

    'Inicia: CCGUTIEREZ - OSI. 20/01/2020
    'Proyecto: Sophia - Codificacion
    'Cambio: Se agrega el evento para que se Limpie el control de las Particularidades 
    'si se modifica la descripcion de búsqueda
    Private Sub cmbDescripProcedim_TextUpdate(sender As Object, e As EventArgs) Handles cmbDescripProcedim.TextUpdate
        Me.txtCodProcedim.Text = ""
        Me.cmbCentroCosto.Text = ""
        Me.ctlPartProce.Limpiar(True)
        Me.txtCantidad.Text = "1"
    End Sub

    ''Inicia: CCGUTIEREZ - OSI. 28/01/2020
    ''Proyecto: Sophia - Codificacion
    ''Cambio: Se muestran las particularidades de acuerdo al Centro de Costo y el parametro " man_csh "
    Private Sub cmbCentroCosto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCentroCosto.SelectedIndexChanged

        ''Se corrige la condicion para controlar la visualizacion de las Particularidades
        ''Mesa de trabajo. 15/10/2021
        If Me.cmbCentroCosto.SelectedIndex <= 0 Then
            Exit Sub
        End If

        'If Me.cmbCentroCosto.SelectedIndex = 0 Then
        '    Exit Sub
        'End If

        If MostrarParticularidades() = True Then
            If txtCodProcedim.Text <> String.Empty Then
                Me.ctlPartProce.PasarDatos(
                txtCodProcedim.Text, cmbDescripProcedim.Text,
                Sub(ByVal strDescripcionTotal As String, ByVal iCantidad As String, ByVal strXmlParticularidades As String, ByVal strXmlProcedimientos As String)
                    ActualizarTextoDescripcionCantidad(strDescripcionTotal, iCantidad)
                End Sub)
            End If
        Else
            Me.ctlPartProce.Limpiar(True)
        End If

    End Sub
    Private Sub Panel3_Click(sender As Object, e As EventArgs) Handles Panel3.Click
        Me.panelConcilMedicamentos1.Visible = False



        Me.panelMedica.Visible = True
        Me.panelProce.Visible = True
        Me.Panel4.Visible = True
        Me.Panel5.Visible = True
        Me.panelGeneral.Visible = True
        Me.Panel1.Visible = True



    End Sub

    Private Sub pnlTabConcilMedicamentos_Click(sender As Object, e As EventArgs) Handles pnlTabConcilMedicamentos.Click
        panelConcilMedicamentos1.Visible = True

        panelMedica.Visible = False
        Me.panelProce.Visible = False
        Me.Panel4.Visible = False
        Me.Panel5.Visible = False
        Me.panelGeneral.Visible = False
        Me.Panel1.Visible = False
        ''   ctlDescrQx.Visible = False
        'pnlContenedor.Height = 1500
        panelConcilMedicamentos1.Controls.Add(ctlconcimedicamentos)
        panelConcilMedicamentos1.Show()

        ctlconcimedicamentos.Show()
        'pnlContEvolucion.Visible = True
        ctlconcimedicamentos.Visible = True

    End Sub
End Class