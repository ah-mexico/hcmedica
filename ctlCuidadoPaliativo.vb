Imports System.Collections.Generic
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales.Generales
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports HistoriaClinica.wsCuidadoPaliativo 'CCGUTIEREZ

''' <summary>
''' Clase ctlEvolucion del namespace Sophia.HistoriaClinica.ctlEvolucion que 
''' es la clase base. Esta clase tiene la funcionalidad del control de usuario para  
''' la evolución y será usado en la aplicación cliente en Windows Form 2005 
''' </summary>
''' <remarks></remarks>
''' 

Public Class ctlCuidadoPaliativo
    Private Shared _Instancia As ctlCuidadoPaliativo

    Private objPaciente As Paciente
    Private objConexion As Conexion
    Private objEvolucion As Evolucion
    Dim resPre1 As String = ""
    Dim resPre2 As String = ""
    Dim modPlanManj As String = ""
    Public txtPlanManejogotfocus As Boolean = False
    Public SeGuardoEvolucion As Boolean = True
    Private objValeIng As ValoraciondeIngreso
    Private objCP As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOCuidadosPaliativos
    Private objEvolucion1 As New HistoriaClinica.Sophia.HistoriaClinica.Reportes.Evolucion
    Private objCuidadosPaliativos As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOCuidadosPaliativos
    Private objAspectosEmocionales As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOAspectosEmocionales
    Private objQxManejaDatos As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAODescripcionQXManejoDeDatos
    Private objHerramientaEvaluacion As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOHerramientaEvaluacion
    Public ctlDescrQx As ctlCuidadoPaliativo
    Public ctlCuidadosPal As ctlCuidadoPaliativo
    Public ctlCriterioIng As ctlCriterioIngreso
    Private strCirujanoInvitado As String = ""
    Private strClasifiDiagn As String = ""
    Private strNameControlLoad As String = ""
    Private blnCtlEvolucion As Boolean = False
    Private objGeneral As objGeneral
    Private objDao As New DAOGeneral
    Private blnCtlDescQx As Boolean = False
    Private strmedico As String
    Private strmotivo As String
    Public strvar As Integer
    Private strEspecialidad As String 'martovar especialidad medico 
    Private strDatoModificadoEvo As String 'rmzaldua diagnostico evolucion
    Private strCadenaLocal As String
    Public ctlAspEmo As New ctlAspectosEmocionales
    Public ctlHerEva As New ctlHerramientaEvaluacion
    Public ctlAspSoc As New ctlCPAspectosSociales
    Public ctlEgreso As ctlEgresoCP
    Public ctlComplejDerivacion As ctlComplejidadDerivacion
    Public ctlReuFamiliar As CtlReunionFamiliar
    Public ctlCriIng As ctlCriterioIngreso
    Public ctlEnfermeria As New ctlCPEnfermeria
    ''WACHV, 07NOV2017, SE AGREGA NUEVO USER CONTROL
    Public ctlGestCateteres As New ctlGestionCateteres

    Public ctlIP As ctlIngresoaPrograma

    Public ReadOnly SeccionAspSocCP As Integer = 1
    Private lstPreguntasAspSocCP As List(Of PreguntaCP)
    'WACHV,Almacena El Criterio encontrado
    Private oiCriterioEncontrado As Integer = 0
    Dim objBLG As New BLBasicasGenerales ''WACHV, Para Obtener la descripcion de copdigo de procedimiento oncologico y no oncologicos
    Private oIngresoCP As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOEgresoCP 'CCGUTIEREZ
    Public strAVC As String = "N" 'CCGUTIEREZ
    Private FecIngProgAV As String = "" 'CCGUTIEREZ
    Private lstPreguntasValoradiondeIngresoCP As List(Of PreguntaCP) 'CCGUTIEREZ


#Region "Instancia de Control"
    Public Shared ReadOnly Property Instancia() As ctlCuidadoPaliativo
        Get
            If _Instancia Is Nothing Then
                _Instancia = New ctlCuidadoPaliativo
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
    Private Sub ctlCuidadoPaliativo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        frmHistoriaPrincipal.blnFirstEvolucion = False

        Me.objValeIng = ValoraciondeIngreso.Instancia ''cpgaray
        Me.ctlAspEmo = ctlAspectosEmocionales.Instancia
        Me.ctlHerEva = ctlHerramientaEvaluacion.Instancia
        Me.ctlCuidadosPal = ctlCuidadoPaliativo.Instancia
        Me.ctlEgreso = ctlEgresoCP.Instancia
        Me.ctlComplejDerivacion = ctlComplejidadDerivacion.Instancia
        Me.ctlReuFamiliar = CtlReunionFamiliar.Instancia
        Me.ctlCriIng = ctlCriterioIngreso.Instancia
        Me.ctlIP = ctlIngresoaPrograma.Instancia
        objGeneral = Generales.Instancia
        objPaciente = Paciente.Instancia
        objConexion = Conexion.Instancia
        objEvolucion = Evolucion.Instancia
        strCadenaLocal = objGeneral.CadenaLocal
        DatosIniciales()
        IniciarCuidadosPaliativos() ''Esta funcion tambien limpia, y llama ultimas respuestas
        CargarCombos(3) 'pregunta 
        ActivarValoracionInicial() ''Activa o inactiva la Hoja si esta o no el programa
    End Sub

    Private Sub ctlCuidadoPaliativo_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged
        If sender.Visible = True Then
            pnlValoracionInicial.Visible = True
            pnlContenedor.Height = pnlValoracionInicial.Height
            Me.ctlAspEmo.Visible = False
            Me.ctlAspSoc.Visible = False
            Me.ctlEgreso.Visible = False
            Me.ctlComplejDerivacion.Visible = False
            Me.ctlReuFamiliar.Visible = False
            Me.ctlCriIng.Visible = False
            Me.ctlCuidadosPal.Visible = True
            Me.ctlGestCateteres.Visible = False ''WACHV, 07nov2017,GESTION CATETERES
            pnlContenedor.Height = pnlValoracionInicial.Height
            ActivarValoracionInicial()
            If frmHistoriaPrincipal.blnFirstEvolucion = True Then
                frmHistoriaPrincipal.blnFirstEvolucion = False
            End If
            ''WACHV,INICIO, 26SEPT2017, llama a ultimas respuestas, Si es Falso debe Limpiar, WS No obtuvo informacion.
            If fncLeerUltimasRespuestas(False) = False Then '''Si es Falso el parametro no muestra el mensaje.
                ''Si es Con parametro True analiza opcion si esta ingresado en paliativo para activa o Inactivar los controles.
                LimpiarDatosPaliativo(True)
            End If
        End If
    End Sub

    Public Sub IniciarCuidadosPaliativos()

        'Private Sub IniciarCuidadosPaliativos() 'CCGUTIEREZ. 31/07/2020. CA_6353881. Se cambia el tipo de la Public

        LimpiarDatosPaliativo(False)
        pnlContenedor.Height = pnlValoracionInicial.Height

        Me.ctlAspEmo.Visible = False
        Me.ctlAspSoc.Visible = False
        Me.ctlEgreso.Visible = False
        Me.ctlComplejDerivacion.Visible = False
        Me.ctlReuFamiliar.Visible = False
        Me.ctlCriIng.Visible = False
        Me.ctlIP.Visible = False

        pnlValoracionInicial.Visible = True
        pnlAspectoEmocionales.Visible = True
        pnlHerramientasEvaluacion.Visible = True
        pnlAspectosSociales.Visible = True
        Me.ctlEnfermeria.Visible = False
        Pnlenfermeria.Visible = True

        ''WACHV,INICIO, 26SEPT2017, llama a ultimas respuestas, Si es Falso debe Limpiar, WS No obtuvo informacion.
        Me.ctlCriIng.bMostrar = False

        If fncLeerUltimasRespuestas(False) = False Then '''Si es Falso el parametro no muestra el mensaje.
            'LimpiarDatosPaliativo(False) ''Si es Falso Limpia todo...Sin Condicion
        End If
    End Sub

    ''WACHV,27dic2016, alarma para paliativo
    Public Sub ActivarValoracionInicial()
        If (BLValoracioneIngreso.intAlarmaPaliativo(objGeneral, objPaciente) = 1) Then
            Me.ParentForm.Controls.Find("pnlContenedorDatosPaciente", True)(0).Controls(0).Controls.Find("pnlAlarmas", True)(0).Controls.Find("btnPalitivo", True)(0).Visible = True
            fncActivarInactivarControlesValoracionInicial(False)
        Else
            Me.ParentForm.Controls.Find("pnlContenedorDatosPaciente", True)(0).Controls(0).Controls.Find("pnlAlarmas", True)(0).Controls.Find("btnPalitivo", True)(0).Visible = False
            fncActivarInactivarControlesValoracionInicial(True)
        End If
    End Sub
    ''' <summary>
    '''wachv,19setp2017,activar inactivar controles
    ''' </summary>
    Public Sub fncActivarInactivarControlesValoracionInicial(bActivar As Boolean)
        Gbvalinicial.Enabled = bActivar
        BttonGuardar.Visible = bActivar
        btnSugerirRespuesta.Visible = bActivar  ''WACHV, 29AGO2017, Visible Invisible el boton de proponer
        btnObtenerDiagnostico.Enabled = Not bActivar   ''WACHV, 21Sept2017, Ocultar Boton o Mostrar es inverso a los demas
    End Sub

#End Region

    ''' <summary>
    ''' Limpia Todos los controles del Control
    ''' </summary>
    ''' <remarks></remarks>
#Region "LimpiarPantalla"
    Private Sub LimpiarPantalla()
        Me.LblDiagnostico.Visible = False
        Me.txtCodDiagnostico.Visible = False
        Me.cboDescDiagnostico.Visible = False
        Me.ObsJuntaPal.Visible = False

    End Sub
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


    Public Sub LimpiarDatosPaliativo(bLimpiar As Boolean)
        If bLimpiar = True Then
            'Si ingresa al programa
            If RBSiInP.Checked = False Then ''INICIO, WACHV, 28AGO2017, Limpia solo cuando NO esta selecciona en si
                ObsJuntaPal.Text = ""
                ObsJuntaPal.ResetText()
                RbOncologico.Checked = False
                rbNoOncologico.Checked = False
                'txtCodDiagnostico.Text = ""
                cboDescDiagnostico.DataSource = Nothing
                cboDescDiagnostico.Items.Clear()
                cboDescDiagnostico.Text = ""
                cboDescDiagnostico.SelectedIndex = -1
                RBSiIngProg.Checked = False
                RBNoIngProg.Checked = False
                RBSiJP.Checked = False
                RBNoJP.Checked = False
                ObsJuntaPal.Text = ""
                ObsJuntaPal.Enabled = False
                RBSiInP.Checked = False
                RBNoInP.Checked = False
                txtCodDiagnostico.Enabled = False
                cboDescDiagnostico.Enabled = False
                cboDescDiagnostico.Text = ""
                txtCodDiagnostico.Text = ""
            End If ''FIN, WACHV, 28AGO2017, Limpia solo cuando NO esta selecciona en si
        End If
        If bLimpiar = False Then
            ObsJuntaPal.Text = ""
            ObsJuntaPal.ResetText()
            RbOncologico.Checked = False
            rbNoOncologico.Checked = False
            'txtCodDiagnostico.Text = ""
            cboDescDiagnostico.DataSource = Nothing
            cboDescDiagnostico.Items.Clear()
            cboDescDiagnostico.Text = ""
            cboDescDiagnostico.SelectedIndex = -1
            RBSiIngProg.Checked = False
            RBNoIngProg.Checked = False
            RBSiJP.Checked = False
            RBNoJP.Checked = False
            ObsJuntaPal.Text = ""
            ObsJuntaPal.Enabled = False
            RBSiInP.Checked = False
            RBNoInP.Checked = False
            txtCodDiagnostico.Enabled = False
            cboDescDiagnostico.Enabled = False
            cboDescDiagnostico.Text = ""
            txtCodDiagnostico.Text = ""
        End If
        'Si esta en la opcion de No Ingresa al programa, el boton proponer debe quedar habilitado
        If RBNoInP.Checked = True Then
            btnSugerirRespuesta.Enabled = True
        End If
    End Sub

    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Private Sub pnlValoracioneIngreso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlValoracioneIngreso.Click
        pnlIngresoaPrograma.SendToBack()
        Me.pnlValoracioneIngreso.BackColor = Color.Transparent
        pnlValoracioneIngreso.BringToFront()
        btnSugerirRespuesta.Visible = True
        pnlValoracionInicial.Visible = False
        Me.ctlAspSoc.Visible = False
        Me.ctlHerEva.Visible = False
        Me.ctlAspEmo.Visible = False
        Me.ctlEgreso.Visible = False
        Me.ctlReuFamiliar.Visible = False
        Me.ctlCriIng.Visible = False
        Me.ctlIP.Visible = False
        Me.ctlEnfermeria.Visible = False
        Me.ctlGestCateteres.Visible = False ''WACHV, 07nov2017,GESTION CATETERES
        IniciarCuidadosPaliativos()
    End Sub

    Private Sub pnlAspectoEmocionales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlAspectoEmocionales.Click
        btnSugerirRespuesta.Visible = False
        pnlValoracionInicial.Visible = False
        pnlContenedor.Height = Me.ctlAspEmo.Height
        Me.ctlReuFamiliar.Visible = False
        Me.ctlAspSoc.Visible = False
        Me.ctlHerEva.Visible = False
        Me.ctlEgreso.Visible = False
        Me.ctlComplejDerivacion.Visible = False
        Me.ctlCriIng.Visible = False
        Me.ctlIP.Visible = False
        Me.pnlContenedor.Controls.Add(Me.ctlAspEmo)
        Me.ctlEnfermeria.Visible = False
        Me.ctlGestCateteres.Visible = False ''WACHV, 07nov2017,GESTION CATETERES
        ctlAspEmo.Show()
    End Sub

    Private Sub pnlHerramientasEvaluacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlHerramientasEvaluacion.Click
        btnSugerirRespuesta.Visible = False
        pnlValoracionInicial.Visible = False
        pnlContenedor.Height = Me.ctlHerEva.Height
        Me.ctlReuFamiliar.Visible = False
        Me.ctlAspSoc.Visible = False
        Me.ctlAspEmo.Visible = False
        Me.ctlEgreso.Visible = False
        Me.ctlComplejDerivacion.Visible = False
        Me.ctlCriIng.Visible = False
        Me.ctlIP.Visible = False
        Me.ctlEnfermeria.Visible = False
        Me.ctlGestCateteres.Visible = False ''WACHV, 07nov2017,GESTION CATETERES
        Me.pnlContenedor.Controls.Add(Me.ctlHerEva)
        ctlHerEva.Show()
    End Sub

    Private Sub pnlEgresodelPrograma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlEgresodelPrograma.Click
        btnSugerirRespuesta.Visible = False
        pnlValoracionInicial.Visible = False
        pnlContenedor.Height = Me.ctlEgreso.Height
        Me.ctlReuFamiliar.Visible = False
        Me.ctlAspSoc.Visible = False
        Me.ctlAspEmo.Visible = False
        Me.ctlHerEva.Visible = False
        Me.ctlComplejDerivacion.Visible = False
        Me.ctlCriIng.Visible = False
        Me.ctlIP.Visible = False
        Me.ctlEnfermeria.Visible = False
        Me.ctlGestCateteres.Visible = False ''WACHV, 07nov2017,GESTION CATETERES
        Me.pnlContenedor.Controls.Add(Me.ctlEgreso)
        ctlEgreso.Show()
    End Sub
    Private Sub pnlAspectosSociales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlAspectosSociales.Click
        btnSugerirRespuesta.Visible = False
        pnlValoracionInicial.Visible = False
        pnlContenedor.Height = Me.ctlAspSoc.Height
        Me.ctlReuFamiliar.Visible = False
        Me.ctlHerEva.Visible = False
        Me.ctlAspEmo.Visible = False
        Me.ctlComplejDerivacion.Visible = False
        Me.ctlCriIng.Visible = False
        Me.ctlIP.Visible = False
        Me.ctlEnfermeria.Visible = False
        Me.ctlGestCateteres.Visible = False ''WACHV, 07nov2017,GESTION CATETERES
        Me.pnlContenedor.Controls.Add(Me.ctlAspSoc)
        ctlAspSoc.Show()
    End Sub

    Private Sub pnlComplejidadyDerivacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlComplejidadyDerivacion.Click
        btnSugerirRespuesta.Visible = False
        pnlValoracionInicial.Visible = False
        pnlContenedor.Height = Me.ctlComplejDerivacion.Height
        Me.ctlReuFamiliar.Visible = False
        Me.ctlEgreso.Visible = False
        Me.ctlAspSoc.Visible = False
        Me.ctlAspEmo.Visible = False
        Me.ctlHerEva.Visible = False
        Me.ctlCriIng.Visible = False
        Me.ctlIP.Visible = False
        Me.ctlEnfermeria.Visible = False
        Me.ctlGestCateteres.Visible = False ''WACHV, 07nov2017,GESTION CATETERES
        Me.pnlContenedor.Controls.Add(Me.ctlComplejDerivacion)
        ctlComplejDerivacion.Show()
    End Sub

    Private Sub pnlReunionFamiliar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlReunionFamiliar.Click
        btnSugerirRespuesta.Visible = False
        pnlValoracionInicial.Visible = False
        pnlContenedor.Height = Me.ctlReuFamiliar.Height
        Me.ctlComplejDerivacion.Visible = False
        Me.ctlEgreso.Visible = False
        Me.ctlAspSoc.Visible = False
        Me.ctlAspEmo.Visible = False
        Me.ctlHerEva.Visible = False
        Me.ctlCriIng.Visible = False
        Me.ctlIP.Visible = False
        Me.ctlEnfermeria.Visible = False
        Me.ctlGestCateteres.Visible = False ''WACHV, 07nov2017,GESTION CATETERES
        Me.pnlContenedor.Controls.Add(Me.ctlReuFamiliar)
        ctlReuFamiliar.Show()
    End Sub

    Private Sub pnlCriterioIngreso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btnSugerirRespuesta.Visible = False
        pnlValoracionInicial.Visible = False
        pnlContenedor.Height = Me.ctlCriIng.Height
        Me.ctlComplejDerivacion.Visible = False
        Me.ctlEgreso.Visible = False
        Me.ctlAspSoc.Visible = False
        Me.ctlAspEmo.Visible = False
        Me.ctlHerEva.Visible = False
        Me.ctlReuFamiliar.Visible = False
        Me.ctlIP.Visible = False
        Me.ctlEnfermeria.Visible = False
        Me.ctlGestCateteres.Visible = False ''WACHV, 07nov2017,GESTION CATETERES
        Me.pnlContenedor.Controls.Add(Me.ctlCriIng)
        ctlCriIng.Show()
    End Sub

    Private Sub pnlIngresoaPrograma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlIngresoaPrograma.Click
        pnlIngresoaPrograma.BringToFront()
        pnlValoracioneIngreso.SendToBack()
        Me.pnlIngresoaPrograma.BackColor = Color.Transparent
        btnSugerirRespuesta.Visible = False
        pnlValoracionInicial.Visible = False
        pnlContenedor.Height = Me.ctlIP.Height
        Me.ctlComplejDerivacion.Visible = False
        Me.ctlEgreso.Visible = False
        Me.ctlAspSoc.Visible = False
        Me.ctlAspEmo.Visible = False
        Me.ctlHerEva.Visible = False
        Me.ctlReuFamiliar.Visible = False
        Me.ctlEnfermeria.Visible = False
        Me.ctlGestCateteres.Visible = False ''WACHV, 07nov2017,GESTION CATETERES
        Me.pnlContenedor.Controls.Add(Me.ctlIP)
        ctlIP.Show()
    End Sub
    Private Sub pnlEnfermeria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pnlenfermeria.Click
        btnSugerirRespuesta.Visible = False
        pnlValoracionInicial.Visible = False
        pnlContenedor.Height = ctlEnfermeria.Height
        Me.ctlComplejDerivacion.Visible = False
        Me.ctlEgreso.Visible = False
        Me.ctlAspSoc.Visible = False
        Me.ctlAspEmo.Visible = False
        Me.ctlHerEva.Visible = False
        Me.ctlReuFamiliar.Visible = False
        Me.ctlEnfermeria.Visible = False
        Me.ctlCriIng.Visible = False
        Me.ctlIP.Visible = False
        Me.ctlGestCateteres.Visible = False ''WACHV, 07nov2017,GESTION CATETERES
        Me.pnlContenedor.Controls.Add(Me.ctlEnfermeria)
        ctlEnfermeria.Show()
    End Sub
    ''WACHV,INICIO, 07NOV2017 LLAMAR A USER CONTROL DE GESTION DE CATETERES NUEVO
    Private Sub pnlGestionCateteres_Click(sender As Object, e As EventArgs) Handles pnlGestionCateteres.Click
        btnSugerirRespuesta.Visible = False
        pnlValoracionInicial.Visible = False
        pnlContenedor.Height = ctlEnfermeria.Height
        Me.ctlComplejDerivacion.Visible = False
        Me.ctlEgreso.Visible = False
        Me.ctlAspSoc.Visible = False
        Me.ctlAspEmo.Visible = False
        Me.ctlHerEva.Visible = False
        Me.ctlReuFamiliar.Visible = False
        Me.ctlEnfermeria.Visible = False
        Me.ctlCriIng.Visible = False
        Me.ctlIP.Visible = False
        Me.ctlEnfermeria.Visible = False
        Me.pnlContenedor.Controls.Add(Me.ctlGestCateteres)
        ctlGestCateteres.Show()
    End Sub ''WACHV,FIN, 07NOV2017 LLAMAR A USER CONTROL DE GESTION DE CATETERES NUEVO

    'WACHV, 02-ENE2017
    'REQ ADICIONALES:  Considera que su paciente cumple criterios para ingreso al programa de cuidados paliativos?"Con la opcion de respuesta SI / NO. 
    'a.a Al seleccionar la opcion  Si  el sistema desplega una ventana emergente del cuestionario identificados   
    'con los criteriosde ingreso  segun diagnostico.(Ver anexo 3 criterios de ingreso.) 
    'Esta ventana debe tener la opción de   aceptar ( guardar) y  cancelar  y opcion de cierre en la parte superior derecha .   
    'Private Sub RBSiIngProg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBSiIngProg.Click

    '    If Me.txtCodDiagnostico.Text <> "" Then
    '        Me.ctlCriIng.CriterioIngreso = IIf(IsDBNull(Me.objCP.ConsultarDiagnostico_Criterio(5, txtCodDiagnostico.Text)), 0, Me.objCP.ConsultarDiagnostico_Criterio(5, txtCodDiagnostico.Text))
    '    Else
    '        Me.ctlCriIng.CriterioIngreso = 0
    '    End If

    '    If Me.ctlCriIng.CriterioIngreso > 0 Then
    '        Dim frmCriteriosIngresoModal As New frmCriteriosIngresoPaliativo
    '        frmCriteriosIngresoModal.ShowDialog()
    '    End If

    'End Sub


    'Private Sub cboDescDiagnostico_HandleDestroyed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDescDiagnostico.HandleDestroyed
    '    If cboDescDiagnostico.SelectedIndex <> -1 Then
    '        If Me.txtCodDiagnostico.Text <> "" Then
    '            Me.ctlCriIng.CriterioIngreso = IIf(IsDBNull(Me.objCP.ConsultarDiagnostico_Criterio(5, txtCodDiagnostico.Text)), 0, Me.objCP.ConsultarDiagnostico_Criterio(5, txtCodDiagnostico.Text))
    '        Else
    '            Me.ctlCriIng.CriterioIngreso = 0
    '        End If


    '        If Me.ctlCriIng.CriterioIngreso > 0 Then
    '            Dim frmCriteriosIngresoModal As New frmCriteriosIngresoPaliativo
    '            frmCriteriosIngresoModal.ShowDialog()
    '        End If
    '    End If
    'End Sub
    'Private Sub cboDescDiagnostico_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDescDiagnostico.HandleCreated
    '    If cboDescDiagnostico.SelectedIndex <> -1 Then
    '        If Me.txtCodDiagnostico.Text <> "" Then
    '            Me.ctlCriIng.CriterioIngreso = IIf(IsDBNull(Me.objCP.ConsultarDiagnostico_Criterio(5, txtCodDiagnostico.Text)), 0, Me.objCP.ConsultarDiagnostico_Criterio(5, txtCodDiagnostico.Text))
    '        Else
    '            Me.ctlCriIng.CriterioIngreso = 0
    '        End If


    '        If Me.ctlCriIng.CriterioIngreso > 0 Then
    '            Dim frmCriteriosIngresoModal As New frmCriteriosIngresoPaliativo
    '            frmCriteriosIngresoModal.ShowDialog()
    '        End If
    '    End If
    'End Sub


    'Private Sub cboDescDiagnostico_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDescDiagnostico.TextChanged
    '    If cboDescDiagnostico.Text = "" Then
    '        cboDescDiagnostico.DataSource = Nothing
    '        cboDescDiagnostico.Items.Clear()
    '        cboDescDiagnostico.Text = ""
    '        txtCodDiagnostico.Text = ""
    '        cboDescDiagnostico.SelectedIndex = -1
    '    End If
    'End Sub

#Region "Grabar"


    Private Sub btGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim objBl As New Sophia.HistoriaClinica.BL.BLPlanManejo
        Dim bError As Boolean = True
        Dim lError As Long
        Dim strError As String = ""
        Dim intHora As Integer
        Dim intMinuto As Integer
        Dim strFecha As String = ""
        Dim strvarcierre As String = ""
        Dim daoOrden As New DAOOrdenes()







        If bError Then
            Try





                Try
                    daoOrden.GrabarAuditOrdenes(objConexion, objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                    objPaciente.TipoDocumento & objPaciente.NumeroDocumento, objGeneral.Login, 0, 0,
                    0, 0, 0, "CLICK BOTON GUARDAR", "EV")
                Catch ex As Exception

                End Try
                ''Fin



                'martovar 2014-08-25 se agrega funcion para guardar los datos de medico y motivo de interconsulta sin una orden de procedimiento
                'lError = objBl.GrabarEvolucion(objConexion, Trim(tbDiagnostico.Text), Trim(tbObjetivo.Text), _
                '            Trim(tbParaclinicos.Text), Trim(tbPlanManejo.Text), Trim(tbSubjetivo.Text), Trim(txtNotasIngr.Text), _
                '           strFecha, intHora, intMinuto, strexp_pla, strcon_med, Trim(Me.Txtinterconsulta.Text), objGeneral.CodigoEspecialidad, Trim(strmedico), Trim(strmotivo), strvarcierre, Trim(strEspecialidad))

                If lError > 0 Then
                    strvar = 0
                    MsgBox("La evolución no se grabó, por favor verifique los datos", MsgBoxStyle.Exclamation)
                    objEvolucion.Estado = "N"
                    bError = True
                Else
                    strvar = 1
                    objGeneral.HistoriaClinicaTieneModificaciones = True
                    objEvolucion.Estado = "G"
                    LimpiarPantalla()


                    resPre1 = ""
                    resPre2 = ""
                    modPlanManj = ""
                    'grpGenPrg.Visible = False

                    bError = False
                    'cambio realizado por Ing. Ricardo Mauricio Zaldúa C.
                    'fecha 2009-06-08
                    'solicitado por Enrique Forero 
                    'Motivo preguntar si desea imprimir el reporte 
                    If MessageBox.Show("Desea imprimir el documento?", "Historia Clinica", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        'cambio realizado por Ing. Ricardo Mauricio Zaldúa C.
                        'fecha 2009-05-19
                        'solicitado por Enrique Forero 
                        'Motivo primero limpiar el formulario y dejar de ultima la impresion para que aparezca en pantalla
                        ImprimirReporte(Format(CDate(strFecha), "yyyy/MM/dd"), intHora, intMinuto, strvarcierre) 'MARTOVAR se envia variable para identificar si se cerro la interconsulta
                    End If

                End If

                Try
                    daoOrden.GrabarAuditOrdenes(objConexion, objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                    objPaciente.TipoDocumento & objPaciente.NumeroDocumento, objGeneral.Login, 0, 0,
                    0, 0, 0, "REGISTRO GRABADO ERROR:" & lError, "EV")
                Catch ex As Exception

                End Try

            Catch ex As Exception
                MessageBox.Show("El proceso de grabación de la evolución falló por: " & ex.Message, "Historia Clínica", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
            End Try
        Else
            MsgBox(strError, MsgBoxStyle.Exclamation)
            objEvolucion.Estado = "N"
        End If



    End Sub
#End Region

    Private Sub btNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.LimpiarPantalla()
        Dim dtFecha As Date
        dtFecha = FuncionesGenerales.FechaServidor()

        Me.tmHoraEvolucion.Interval = (60 - Second(dtFecha)) * 1000
        Me.tmHoraEvolucion.Enabled = True


        txtPlanManejogotfocus = False ''Claudia Garay Enero 17 de 2011

        resPre1 = ""
        resPre2 = ""
        modPlanManj = ""

    End Sub

    Private Sub tbPlanManejo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        modPlanManj = "S"
    End Sub

#Region "CargarCombos"
    Private Sub CargarCombos(ByVal intopcion As Integer)
        Dim dt As New DataTable

        Try

            Select Case intopcion
                Case 1 ''Diagnosticos Oncologicos


                    Try
                        Me.txtCodDiagnostico.ControlComboEnlace = Me.cboDescDiagnostico
                        With cboDescDiagnostico
                            .CampoMostrar = "descripcion"
                            .ControlTextoEnlace = txtCodDiagnostico
                            .CampoEnlazado = "codigo"
                            .CategoriaDatos = CategoriaDatos.DiagnosticosOncologicos
                            .Login = objGeneral.Login
                            .SexoPaciente = objPaciente.Genero
                            .EdadPaciente = objPaciente.Edad
                            .CargarDatos()
                            .CargarButton()
                        End With

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try


                Case 2 ''Diagnosticos No Oncologicos
                    Try
                        Me.txtCodDiagnostico.ControlComboEnlace = Me.cboDescDiagnostico
                        With cboDescDiagnostico
                            .CampoMostrar = "descripcion"
                            .ControlTextoEnlace = txtCodDiagnostico
                            .CampoEnlazado = "codigo"
                            .CategoriaDatos = CategoriaDatos.DiagnosticosNoOncologicos
                            .Login = objGeneral.Login
                            .SexoPaciente = objPaciente.Genero
                            .EdadPaciente = objPaciente.Edad
                            .CargarDatos()
                            .CargarButton()
                        End With

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try


                Case 4

                Case 5

                Case 7 ''Tipo de Cirugia


            End Select

        Catch ex As Exception



        End Try


    End Sub
#End Region
#Region "AsignarDatosIniciales-Load"
    Private Sub DatosIniciales()


        Dim dtTable As New DataTable
        With dtTable
            .Columns.Add("tip_admision_evo", System.Type.GetType("System.String"))
            .Columns.Add("ano_adm_evo", System.Type.GetType("System.String"))
            .Columns.Add("num_adm_evo", System.Type.GetType("System.String"))
            .Columns.Add("tip_diag_evo", System.Type.GetType("System.String"))
            .Columns.Add("tDescripcion_evo", System.Type.GetType("System.String"))
            .Columns.Add("diagnost_evo", System.Type.GetType("System.String"))
            .Columns.Add("descripcion_evo", System.Type.GetType("System.String"))
            .Columns.Add("clasificacion_evo", System.Type.GetType("System.String"))
            .Columns.Add("obs_evo", System.Type.GetType("System.String"))
            .Columns.Add("Antecedente_evo", System.Type.GetType("System.String"))
            .Columns.Add("confidencial_evo", System.Type.GetType("System.String"))
            .Columns.Add("planManejo_evo", System.Type.GetType("System.String"))
            .Columns.Add("secuencia_evo", System.Type.GetType("System.String"))
            .Columns.Add("clase_diag_evo", System.Type.GetType("System.String"))
            .Columns.Add("categoria_diag_evo", System.Type.GetType("System.String"))
            .Columns.Add("fec_hc_evo", System.Type.GetType("System.String"))
            .Columns.Add("CategoriaDes_evo", System.Type.GetType("System.String"))
            .Columns.Add("Nuevo_evo", System.Type.GetType("System.String"))
        End With


    End Sub
#End Region

    ''' <summary>
    ''' Consulta Valores Inciales de la Historia Clínica y asigna valores 
    ''' en cada uno de los controles y objetos del Formulario
    ''' </summary>
    ''' <remarks></remarks>
#Region "ConsultarValores"
    Private Sub ConsultarValores()
        Dim objBl As New Sophia.HistoriaClinica.BL.BLEgresos

        Dim dtDiagnostico As New DataTable
        Dim i As Integer

        Try

            '// Consultar valores iniciales cuando no se cierra la historia \\
            dtDiagnostico = objBl.ConsultarDiagnosticoReingreso(objGeneral.Prestador, objGeneral.Sucursal,
                                    objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                    "E", objGeneral.Login, objConexion)


        Catch ex As Exception
            'MsgBox("Error al consultar datos", MsgBoxStyle.Exclamation)
        End Try

    End Sub
#End Region

#Region "Eliminar Fila Grilla"

    Private Sub dgListaEvo_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs)

        'If NVL(e.Row.Cells("Nuevo").Value) = "N" Then
        If MessageBox.Show("Esta Seguro de Borrar este Registro?", "Evolución", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            EliminarDiagnosticoEvo(e.Row)
        Else
            e.Cancel = True
        End If


    End Sub
#End Region

#Region "Eliminar Diagnostico"
    Private Sub EliminarDiagnosticoEvo(ByVal drFila As DataGridViewRow)
        Dim objBl As New Sophia.HistoriaClinica.BL.BLEgresos
        Dim lError As Long
        Dim strCodPreSgs As String = objGeneral.Prestador
        Dim strCodSucur As String = objGeneral.Sucursal
        Dim strTipDoc As String = objPaciente.TipoDocumento
        Dim strNumDoc As String = objPaciente.NumeroDocumento
        Dim strTipAdm As String = drFila.Cells("tip_admision_evo").Value.ToString()
        Dim dblNumAdm As Long = CLng(drFila.Cells("num_adm_evo").Value.ToString())
        Dim intAnoAdm As Integer = CInt(drFila.Cells("ano_adm_evo").Value.ToString())
        Dim strClaseDiag As String = drFila.Cells("clase_diag_evo").Value.ToString()
        Dim strTipDiag As String = drFila.Cells("tip_diag_evo").Value.ToString()
        Dim strDiagnostico As String = drFila.Cells("diagnost_evo").Value.ToString()
        Dim strAntecedente As String = drFila.Cells("Antecedente_evo").Value.ToString()
        Dim strObservaciones As String = drFila.Cells("obs_evo").Value.ToString()
        Dim strConfidencial As String = drFila.Cells("confidencial_Evo").Value.ToString()
        Dim strClasificacion As String = drFila.Cells("clasificacion_evo").Value.ToString()
        Dim strCategoria As String = drFila.Cells("categoria_diag_evo").Value.ToString()
        Dim intSecuencia As Integer '= CInt(drFila.Cells("secuencia").Value.ToString())
        Dim intAccion As Integer = 2
        Try
            lError = objBl.GrabarEgresoDiagnostico(objConexion, strCodPreSgs, strCodSucur,
                            strTipDoc, strNumDoc, strTipAdm, dblNumAdm, intAnoAdm, strClaseDiag,
                            strTipDiag, strDiagnostico, strAntecedente, strObservaciones, strConfidencial,
                            strClasificacion, strCategoria, intSecuencia, intAccion, objGeneral.Login)

            If lError <> 0 Then
                MessageBox.Show("Error al eliminar el diagnóstico evolucion")
            Else


            End If
        Catch ex As Exception
            MessageBox.Show("Error al eliminar el diagnóstico")
        End Try

    End Sub
#End Region

#Region "ValoracionInicial"
    Private Sub RbOncologico_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbOncologico.CheckedChanged
        If RbOncologico.Checked Then
            LblDiagnostico.Text = "Diagnóstico oncológico"
            Me.LblDiagnostico.Visible = True
            Me.txtCodDiagnostico.Visible = True
            Me.cboDescDiagnostico.Visible = True
            cboDescDiagnostico.DataSource = Nothing
            cboDescDiagnostico.Items.Clear()
            txtCodDiagnostico.Enabled = True
            cboDescDiagnostico.Enabled = True
            cboDescDiagnostico.Text = ""
            txtCodDiagnostico.Text = ""
            cboDescDiagnostico.SelectedIndex = -1
            Me.CargarCombos(1)
        End If
    End Sub

    Private Sub rbNoOncologico_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbNoOncologico.CheckedChanged
        If rbNoOncologico.Checked Then
            LblDiagnostico.Text = "Diagnóstico no oncológico"
            Me.LblDiagnostico.Visible = True
            Me.txtCodDiagnostico.Visible = True
            Me.cboDescDiagnostico.Visible = True
            cboDescDiagnostico.DataSource = Nothing
            cboDescDiagnostico.Items.Clear()
            txtCodDiagnostico.Enabled = True
            cboDescDiagnostico.Enabled = True
            cboDescDiagnostico.Text = ""
            txtCodDiagnostico.Text = ""
            cboDescDiagnostico.SelectedIndex = -1
            Me.CargarCombos(2)
        End If
    End Sub

    Private Sub txtCodDiagnostico_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodDiagnostico.TextChanged
        If cboDescDiagnostico.Text <> "" Then
            txtCodDiagnostico_Validated(sender, e)
        End If
    End Sub

    ''''WACHV,INICIO, 21SEPT2017, FUNCION PARA MOSTRAR HABILITADO INHABILITADO EL CONTROL
    Private Sub btnObtenerDiagnostico_Click(sender As Object, e As EventArgs) Handles btnObtenerDiagnostico.Click
        fncMostrarCriterioIngreso(False)
    End Sub

    Private Function fncMostrarCriterioIngreso(bMostrar As Boolean)
        If oiCriterioEncontrado > 0 Then
            Me.ctlCriIng.bMostrar = bMostrar
            Me.ctlCriIng.CriterioIngreso = oiCriterioEncontrado
            Dim frmCriteriosIngresoModal As New frmCriteriosIngresoPaliativo
            frmCriteriosIngresoModal.ActiveForm.MaximizeBox = False
            frmCriteriosIngresoModal.ActiveForm.MinimizeBox = False
            frmCriteriosIngresoModal.ShowDialog()
        End If
    End Function

    Private Sub BttonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BttonGuardar.Click
        Try
            ''INICIO llarias Se agrega para que no permita guardar si no se ha ingresado diagnostico
            '' CA 4646382 2019-08-28
            If txtCodDiagnostico.Text <> "" And cboDescDiagnostico.Text <> "" Then
                If MsgBox("Una vez almacenados los datos no podrán ser modificados. Desea Continuar", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    If (GuardarValoracionInicial()) Then
                        MessageBox.Show("Registro Guardado.", "Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ActivarValoracionInicial()
                        LimpiarDatosPaliativo(True)
                    End If
                End If
            Else
                MessageBox.Show("Por favor ingrese un diagnóstico válido", "Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            ''FIN llarias
        Catch ex As Exception
            MessageBox.Show("El proceso de grabación de valoracion Inicial fallo por: " & ex.Message, "Historia Clínica", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Function GuardarValoracionInicial() As Boolean

        Dim lError As Long
        Dim oValoracionInicial As New ValoraciondeIngreso

        Try
            oValoracionInicial.cod_pre_sgs = objGeneral.Prestador
            oValoracionInicial.cod_sucur = objGeneral.Sucursal
            oValoracionInicial.tip_admision = objPaciente.TipoAdmision

            oValoracionInicial.ano_adm = objPaciente.AnoAdmision
            oValoracionInicial.num_adm = objPaciente.NumeroAdmision
            oValoracionInicial.tip_doc = objPaciente.TipoDocumento
            oValoracionInicial.Num_doc = objPaciente.NumeroDocumento

            oValoracionInicial.CriteriodeIngreso = "" ''PONERLO VACIO

            'datos obligatorios
            If ((rbNoOncologico.Checked = True Or RbOncologico.Checked = True) And txtCodDiagnostico.Text = "" And cboDescDiagnostico.Text = "") Then
                MsgBox("Datos incompletos en Criterio de Ingreso")
                Exit Function
            Else
                'Inicia: CCGUTIEREZ - OSI. 15/04/2020
                'Solicitud: CA_6353881 
                'Cambio: Se agrega condicion de control
                If RbOncologico.Checked = True Then
                    oValoracionInicial.CriteriodeIngreso = "S"
                Else
                    oValoracionInicial.CriteriodeIngreso = "N"
                End If
                'oValoracionInicial.CriteriodeIngreso = "S"
                'Fin. CCGUTIEREZ
            End If


            'Criterio: Oncológico o No Oncológico
            If RbOncologico.Checked = False And rbNoOncologico.Checked = False Then
                oValoracionInicial.CriteriodeIngreso = ""
                MsgBox("Sin Seleccionar el Criterio de Ingreso.")
                Exit Function
            Else
                If RbOncologico.Checked = True Then
                    oValoracionInicial.CriteriodeIngreso = "S"
                Else
                    oValoracionInicial.CriteriodeIngreso = "N"
                End If
                'oValoracionInicial.CriteriodeIngreso = "S"
            End If


            If cboDescDiagnostico.Text <> "" And RbOncologico.Checked = True Then
                oValoracionInicial.Diagnostico_oncologico = Me.txtCodDiagnostico.Text
            Else
                oValoracionInicial.Diagnostico_oncologico = ""
            End If

            If cboDescDiagnostico.Text <> "" And rbNoOncologico.Checked = True Then
                oValoracionInicial.Diagnostico_no_oncologico = Me.txtCodDiagnostico.Text
            Else
                oValoracionInicial.Diagnostico_no_oncologico = ""
            End If

            ''Cumple Criterios de Ingreso
            ''INICIO, WACHV, 28AGO2017, Hacerlos obligatorios
            If RBSiIngProg.Checked = False And RBNoIngProg.Checked = False Then
                MsgBox("No ha seleccionado algun Criterio de Ingreso.")
                Exit Function
            End If ''FIN, WACHV, 28AGO2017, Hacerlos obligatorios

            If RBSiIngProg.Checked = True Then
                oValoracionInicial.CumpleCI = "S"
            Else
                If RBNoIngProg.Checked = True Then
                    oValoracionInicial.CumpleCI = "N"
                Else
                    oValoracionInicial.CumpleCI = " "
                End If
            End If

            ''El Caso requiere junta paliativa
            ''INICIO, WACHV, 28AGO2017, Hacerlos obligatorios
            If RBSiJP.Checked = False And RBNoJP.Checked = False Then
                MsgBox("No ha seleccionado alguna opcion en junta paliativa.")
                Exit Function
            End If ''FIN, WACHV, 28AGO2017, Hacerlos obligatorios

            If RBSiJP.Checked = True Then
                oValoracionInicial.Req_JP = "S"
            Else
                If RBNoJP.Checked = True Then
                    oValoracionInicial.Req_JP = "N"
                Else
                    oValoracionInicial.Req_JP = " "
                End If
            End If

            ''Observaciones Junta Paliativa
            ''INICIO, WACHV, 28AGO2017, Hacerlos obligatorios
            If RBSiJP.Checked = True And Len(ObsJuntaPal.Text) = 0 Then
                MsgBox("No presenta alguna observacion para junta paliativa.")
                Exit Function
            End If ''FIN, WACHV, 28AGO2017, Hacerlos obligatorios

            oValoracionInicial.ObsJuntaP = ObsJuntaPal.Text

            ''Ingreso al programa
            ''INICIO, WACHV, 28AGO2017, Hacerlos obligatorios
            If RBSiInP.Checked = False And RBNoInP.Checked = False Then
                MsgBox("No ha seleccionado alguna opcion de ingreso al programa.")
                Exit Function
            End If ''FIN, WACHV, 28AGO2017, Hacerlos obligatorios

            If RBSiInP.Checked = True Then
                oValoracionInicial.IngPrograma = "S"
            Else
                If RBNoInP.Checked = True Then
                    oValoracionInicial.IngPrograma = "N"
                Else
                    oValoracionInicial.IngPrograma = " "
                End If
            End If

            oValoracionInicial.obs = String.Empty
            oValoracionInicial.login = objGeneral.Login

            '*************************************************************************************
            'Si el ingreso al Programa se realizó desde Avicena 
            'Se invoca el WS para recuperar la Fecha de Ingreso al programa 
            If strAVC = "S" Then

                lstPreguntasValoradiondeIngresoCP = objValeIng.ConsultarPreguntas(New PreguntaCP)

                Dim aPreUltRespuesta(lstPreguntasValoradiondeIngresoCP.Count) As Long
                Dim aUltimaRespuesta(lstPreguntasValoradiondeIngresoCP.Count) As PreguntaType
                Dim DAOCP As New DAOCuidadosPaliativos()
                Dim Resultado As String
                Dim appOrigen As String = objPaciente.AppOrigenCP.ToUpper()
                Dim strRegionalRefBD As String = DAOCP.ConsultarRegional()
                Dim srvIngresoaPrograma As New CuidadosPaleativosServiceImpService()

                srvIngresoaPrograma.Url = DAOCP.ConsultarUrlServicioUT(objGeneral.Prestador, objGeneral.Sucursal, DAOCP.TipoServicio, DAOCP.MetodoServicio)

                If srvIngresoaPrograma.Url = "" Then
                    Throw New Exception("No fue posible consultar el servicio de últimas respuestas (URL).")
                End If

                For i As Integer = 0 To lstPreguntasValoradiondeIngresoCP.Count - 1
                    aPreUltRespuesta(i) = lstPreguntasValoradiondeIngresoCP.Item(i).id
                Next

                Resultado = srvIngresoaPrograma.ultimasRespuestas(objPaciente.TipoDocumento, objPaciente.NumeroDocumento,
                    aPreUltRespuesta, appOrigen, strRegionalRefBD.ToUpper(), aUltimaRespuesta)

                'Se corrige la consulta de la respuesta para la pregunta 108 (Fecha Ingreso Prog. CP),
                'se debe leer de manera dinámica y no sobre una posicion fija dentro del array
                For Each pr As PreguntaType In aUltimaRespuesta
                    If pr.idPregunta = 108 Then
                        If pr.respuestas.textoRespuesta <> Nothing Then
                            objValeIng.FecIngProgAV = pr.respuestas.textoRespuesta.ToString()
                            oValoracionInicial.FecIngProgAV = objValeIng.FecIngProgAV
                        Else
                            LimpiarDatosPaliativo(False)
                            MsgBox("Paciente no registrado en Ingreso Programa Paliativos. Ultimas Respuestas")
                            Exit Function
                        End If
                    End If
                Next

                'For Each pr As PreguntaType In aUltimaRespuesta
                '    If pr.respuestas.textoRespuesta <> Nothing Then
                '        objValeIng = objValeIng.ObtenerUltimaRespuesta(pr.idPregunta, pr.respuestas.textoRespuesta)
                '        If aUltimaRespuesta(0).idPregunta = 108 Then
                '            If aUltimaRespuesta(0).respuestas.textoRespuesta <> Nothing Then
                '                objValeIng.FecIngProgAV = aUltimaRespuesta(0).respuestas.textoRespuesta.ToString()
                '                oValoracionInicial.FecIngProgAV = objValeIng.FecIngProgAV
                '            Else
                '                LimpiarDatosPaliativo(False)
                '                MsgBox("Paciente no registrado en Ingreso Programa Paliativos. Avicena")
                '                Exit Function
                '            End If
                '        End If
                '    End If
                'Next

            End If

            '*****************************************************************************************

            lError = oValoracionInicial.GuardarValoraciondeIngreso(oValoracionInicial, strAVC)

            If lError = 0 Then
                Return True
            Else
                'MsgBox(strMensaje)
                'objQxManejaDatos.GrabarLogErrores(strMensaje, objGeneral.Sucursal, objGeneral.Login)
                Return False
            End If

        Catch ex As Exception
            MsgBox("Error al guardar Valoracion e Ingreso a Cuidados Paliativos " & ex.Message)
            'objQxManejaDatos.GrabarLogErrores(ex.Message, objGeneral.Sucursal, objGeneral.Login)
            Return False
        End Try

    End Function
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

#End Region

    Private Sub btnSugerirRespuesta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSugerirRespuesta.Click
        fncLeerUltimasRespuestas(True)
    End Sub
    ''WACHV,INICIO,26sept2017,Funcion que Obtiene la Ultima respuesta y retorna verdadero si tiene respuesta y falso si no tiene respuesta del ws.
    Private Function fncLeerUltimasRespuestas(bMostrar As Boolean) As Boolean

        Dim bEstado As Boolean = False

        Try

            Dim oValoraciondeIngreso As New ValoraciondeIngreso()

            LimpiarDatosPaliativo(False)

            If bMostrar Then 'WACHV,05OCT2017, Si Oprime el Boton de proponer, trar la ultima respuesta
                loadValoraciondeIngreso(oValoraciondeIngreso.SugerirRespuesta(objGeneral, objPaciente))
            Else 'Si llega falso, es decir es invocado, cuando esta inghabilitado, evalua si esta en el programa para traer datos
                'WACHV,05OCT2017, si esta con en el programa ( hoja activa) obtener datos, en caso contrario, no obtener nada
                ''Pero activar el control para ingreso
                If Me.ParentForm.Controls.Find("pnlContenedorDatosPaciente", True)(0).Controls(0).Controls.Find("pnlAlarmas", True)(0).Controls.Find("btnPalitivo", True)(0).Visible = True Then
                    loadValoraciondeIngreso(oValoraciondeIngreso.SugerirRespuesta(objGeneral, objPaciente))

                    'Nueva funcion para guardar el ingreso a CP que se hizo en Avicena. 02/07/2020. CA_6353881
                    Dim dt As DataTable
                    Dim intCantDias As Integer
                    Dim strIngreso As String
                    Dim strFecha As String = FuncionesGenerales.FechaServidor()

                    dt = oIngresoCP.dtbCalcularEstanciaPrograma(objPaciente.TipoDocumento, objPaciente.NumeroDocumento, Format(CDate(strFecha), "dd/MM/yyyy"))

                    If dt.Rows.Count > 0 Then
                        intCantDias = Convert.ToInt32(dt.Rows(0).Item(0))
                        strIngreso = Convert.ToString(dt.Rows(0).Item(1))
                        If strIngreso = "N" And intCantDias = 0 Then
                            strAVC = "S"
                            If (GuardarValoracionInicial()) Then
                                MessageBox.Show("Paciente ingresado al programa en Avicena.", "Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                ActivarValoracionInicial()
                                LimpiarDatosPaliativo(True)
                            End If
                        End If
                    End If

                Else
                    fncActivarInactivarControlesValoracionInicial(Not Me.ParentForm.Controls.Find("pnlContenedorDatosPaciente", True)(0).Controls(0).Controls.Find("pnlAlarmas", True)(0).Controls.Find("btnPalitivo", True)(0).Visible)
                End If
            End If

        Catch ex As Exception
            If bMostrar Then
                MessageBox.Show("No fue posible consultar las últimas respuestas de este paciente.", "Historia Clínica", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
            End If
        End Try
        Return bEstado
    End Function ''WACHV,FIN,26sept2017,Funcion que Obtiene la Ultima respuesta y retorna verdadero si tiene respuesta y falso si no tiene respuesta del ws.

    ''' <summary>
    ''' Carga la información Valoracion de Ingreso
    ''' </summary>
    ''' <param name="oEmocionales">Aspecto Emocional a cargar</param>
    ''' <remarks></remarks>
    Private Sub loadValoraciondeIngreso(ByVal oValoraciondeIngreso As ValoraciondeIngreso)
        Try
            fncActivarInactivarControlesValoracionInicial(Not Me.ParentForm.Controls.Find("pnlContenedorDatosPaciente", True)(0).Controls(0).Controls.Find("pnlAlarmas", True)(0).Controls.Find("btnPalitivo", True)(0).Visible)
            'CRITERIO
            ''If Not (oValoraciondeIngreso.CriteriodeIngreso = Nothing) Then
            ''OJO SI CUMPLE CRITERIO DE INGRESO NO ES PARA LOS CHEKS DE ONCOLOGICO O NO ONCOLOGICO 
            '    If oValoraciondeIngreso.CriteriodeIngreso.Substring(oValoraciondeIngreso.CriteriodeIngreso.Length - 1).Contains("1") Then
            '        RbOncologico.Checked = True
            '        rbNoOncologico.Checked = False
            '    End If
            '    If oValoraciondeIngreso.CriteriodeIngreso.Substring(oValoraciondeIngreso.CriteriodeIngreso.Length - 1).Contains("2") Then
            '        RbOncologico.Checked = False
            '        rbNoOncologico.Checked = True
            '    End If
            'End If
            If Not (oValoraciondeIngreso.Diagnostico_oncologico = Nothing) Then
                RbOncologico.Checked = True
            ElseIf Not (oValoraciondeIngreso.Diagnostico_no_oncologico) = Nothing Then
                rbNoOncologico.Checked = True
            End If

            If RbOncologico.Checked = True And rbNoOncologico.Checked = False Then ''wachv, si es solo Oncologico Mostralo
                If Not (oValoraciondeIngreso.Diagnostico_oncologico = Nothing) Then
                    If oValoraciondeIngreso.Diagnostico_oncologico <> "" Then
                        txtCodDiagnostico.Text = oValoraciondeIngreso.Diagnostico_oncologico
                        cboDescDiagnostico.Text = objBLG.ConsultarDescripcionItemPorCodigo(objConexion, CategoriaDatos.Diagnosticos, oValoraciondeIngreso.Diagnostico_oncologico)
                    End If
                End If
            End If

            If RbOncologico.Checked = False And rbNoOncologico.Checked = True Then ''wachv, Es NoOncologico Mostralo
                If Not (oValoraciondeIngreso.Diagnostico_no_oncologico = Nothing) Then
                    If oValoraciondeIngreso.Diagnostico_no_oncologico <> "" Then
                        txtCodDiagnostico.Text = oValoraciondeIngreso.Diagnostico_no_oncologico
                        cboDescDiagnostico.Text = objBLG.ConsultarDescripcionItemPorCodigo(objConexion, CategoriaDatos.Diagnosticos, oValoraciondeIngreso.Diagnostico_no_oncologico)
                    End If
                End If
            End If


            If Not (oValoraciondeIngreso.CumpleCI = Nothing) Then
                If oValoraciondeIngreso.CumpleCI.Substring(oValoraciondeIngreso.CumpleCI.Length - 1).Contains("1") Then
                    RBSiIngProg.Checked = True
                    RBNoIngProg.Checked = False
                Else
                    RBSiIngProg.Checked = False
                    RBNoIngProg.Checked = True
                End If
            End If

            If Not (oValoraciondeIngreso.Req_JP = Nothing) Then
                If oValoraciondeIngreso.Req_JP.Substring(oValoraciondeIngreso.Req_JP.Length - 1).Contains("1") Then
                    RBSiJP.Checked = True
                    RBNoJP.Checked = False
                Else
                    RBSiJP.Checked = False
                    RBNoJP.Checked = True
                End If
            End If

            ObsJuntaPal.Text = IIf(oValoraciondeIngreso.ObsJuntaP = Nothing, "", oValoraciondeIngreso.ObsJuntaP)

            If Not (oValoraciondeIngreso.IngPrograma = Nothing) Then
                If oValoraciondeIngreso.IngPrograma.Substring(oValoraciondeIngreso.IngPrograma.Length - 1).Contains("1") Then
                    RBSiInP.Checked = True
                    RBNoInP.Checked = False
                Else
                    RBSiInP.Checked = False
                    RBNoInP.Checked = True
                End If
            End If

        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub


    Private Sub RBNoJP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBNoJP.CheckedChanged
        Label3.Enabled = False
        ObsJuntaPal.Enabled = False
        ObsJuntaPal.Text = ""
    End Sub


    Private Sub RBSiJP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBSiJP.CheckedChanged
        Label3.Enabled = True
        ObsJuntaPal.Enabled = True
        ObsJuntaPal.Text = ""
    End Sub

    'rmzaldua cambio realizado por incidecnias reportada en la OS 11472828
    Private Sub txtCodDiagnostico_Validated(sender As Object, e As EventArgs) Handles txtCodDiagnostico.Validated
        If txtCodDiagnostico.Text = "" Then
            cboDescDiagnostico.DataSource = Nothing
            cboDescDiagnostico.Items.Clear()
            cboDescDiagnostico.Text = ""
            txtCodDiagnostico.Text = ""
            cboDescDiagnostico.SelectedIndex = -1
            oiCriterioEncontrado = 0
        Else
            'If cboDescDiagnostico.SelectedIndex <> -1 Then
            If Me.txtCodDiagnostico.Text <> "" Then
                'wachv, se almacena el criterio encontrado
                oiCriterioEncontrado = IIf(IsDBNull(Me.objCP.ConsultarDiagnostico_Criterio(5, txtCodDiagnostico.Text)), 0, Me.objCP.ConsultarDiagnostico_Criterio(5, txtCodDiagnostico.Text))
                Me.ctlCriIng.CriterioIngreso = oiCriterioEncontrado
            Else
                oiCriterioEncontrado = 0
                Me.ctlCriIng.CriterioIngreso = oiCriterioEncontrado
            End If

            If oiCriterioEncontrado > 0 Then
                'Me.cboDescDiagnostico.Focus()
                Dim bEstado As Boolean = Not Me.ParentForm.Controls.Find("pnlContenedorDatosPaciente", True)(0).Controls(0).Controls.Find("pnlAlarmas", True)(0).Controls.Find("btnPalitivo", True)(0).Visible
                fncMostrarCriterioIngreso(bEstado) ''''WACHV,21SEPT2017, PARA MOSTRAR HABILITADO EL CONTROL, DEPENDIENDO DEL PANEL
                'Me.cboDescDiagnostico.Focus()
            End If
        End If


    End Sub

    Private Sub cboDescDiagnostico_Validated(sender As Object, e As EventArgs) Handles cboDescDiagnostico.Validated
        If txtCodDiagnostico.Text <> "" Then

        End If
    End Sub

    Private Sub pnlValoracioneIngreso_Paint(sender As Object, e As PaintEventArgs) Handles pnlValoracioneIngreso.Paint

    End Sub
End Class
