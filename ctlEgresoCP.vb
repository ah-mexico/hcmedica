Imports System.IO
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

Public Class ctlEgresoCP
    Private Shared _Instancia As ctlEgresoCP
    Private objGeneral As Generales
    Private objPaciente As Paciente
    Private objConexion As Conexion
    Private objEvolucion As Evolucion

    Dim resPre1 As String = ""
    Dim resPre2 As String = ""
    Dim modPlanManj As String = ""
    Public txtPlanManejogotfocus As Boolean = False
    Public SeGuardoEvolucion As Boolean = True
    Private objDescrQx As DescripcionQuirurgica
    Private objCP As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOCuidadosPaliativos
    Private objEvolucion1 As New HistoriaClinica.Sophia.HistoriaClinica.Reportes.Evolucion
    Private objQxManejaDatos As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAODescripcionQXManejoDeDatos
    Private strCirujanoInvitado As String = ""
    Private strClasifiDiagn As String = ""
    Private strNameControlLoad As String = ""
    Private blnCtlEvolucion As Boolean = False
    Private blnCtlDescQx As Boolean = False
    Public objEgreso As ctlEgresoCP
    Private strmedico As String
    Private strmotivo As String
    Public strvar As Integer
    Private strEspecialidad As String 'martovar especialidad medico 
    Private strDatoModificadoEvo As String 'rmzaldua diagnostico evolucion
    Private strCadenaLocal As String
    Private objEgresoCP As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOEgresoCP
    Private lstPreguntasEgresoCP As List(Of PreguntaCP)

#Region "Instancia de Control"
    Public Shared ReadOnly Property Instancia() As ctlEgresoCP
        Get
            If _Instancia Is Nothing Then
                _Instancia = New ctlEgresoCP
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
    Private Sub ctlEgresoCP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        frmHistoriaPrincipal.blnFirstEvolucion = False
        objGeneral = Generales.Instancia
        objPaciente = Paciente.Instancia
        objConexion = Conexion.Instancia
        objEvolucion = Evolucion.Instancia
        strCadenaLocal = objGeneral.CadenaLocal
        Me.TxtEgPrograma.Enabled = True
        Me.Label6.Enabled = True
        Me.TxtEgPrograma.Enabled = False
        IniciarEgresoCP()
    End Sub

    Private Sub IniciarEgresoCP()
        CargarCombos(1) 'Motivo Egreso 
        CargarCombos(2) 'Donde Fallece 
        CargarCombos(3) 'Causas Administrativas
        fncMostrar_CausasAdmin(False)
        LimpiarDatos()

        'Inicia: CCGUTIEREZ - OSI. 25/03/2020
        'Proyecto: Sophia - CA_5845702
        'Cambio: Se retira linea porque el calculo de las estancia, se debe hacer al ingresar la fecha
        '        de Egreso y no antes
        'Calcular tiempo instancia
        'Me.TxtEgPrograma.Text = objEgresoCP.intCalcularEstanciaPrograma(objPaciente.TipoDocumento, objPaciente.NumeroDocumento)
        'Fin. CCGUTIEREZ
    End Sub
#End Region

    ''' <summary>
    ''' Limpia Todos los controles del Control
    ''' </summary>
    ''' <remarks></remarks>

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
        frmRepEvolucion.imprimirRepEvolucion(objConexion, objGeneral.Prestador, objGeneral.Sucursal, _
                                            objPaciente.TipoAdmision, objPaciente.AnoAdmision, _
                                            objPaciente.NumeroAdmision, dteFecha, intHora, intMinuto, _
                                            objGeneral.Login, strcierre)

    End Sub
#End Region

    Private Sub LimpiarDatos()
        Me.mskEgrProg.Text = ""
        Me.TxtEgPrograma.Text = ""
        mskEgrProg.Text = ""
        TxtEgPrograma.Text = ""
        cmbMotEgreso.SelectedIndex = -1
        TxtHospital.Text = ""
        RBSi_IntP.Checked = False
        RBNo_IntP.Checked = False
        TxtRazon.Text = ""
        fncMostrar_CausasAdmin(False)
        'mskEgrProg.Text = Format(FuncionesGenerales.FechaServidor())
        CmbLugarFallece.SelectedIndex = -1
    End Sub

    Private Sub fncMostrar_CausasAdmin(ByVal bestado As Boolean)
        lblcausasadmin.Enabled = bestado
        CmboPreguntasAdministrativas.SelectedIndex = -1
        CmboPreguntasAdministrativas.Enabled = bestado
    End Sub

    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Private Sub ctlEgresoCP_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged
        If sender.Visible = True Then
            Me.TxtEgPrograma.Enabled = True
            Me.Label6.Enabled = True
            Me.TxtEgPrograma.Enabled = False
            IniciarEgresoCP()
        End If
    End Sub


#Region "Grabar"

    Private Sub btGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGrabar.Click

        Dim objBl As New Sophia.HistoriaClinica.BL.BLPlanManejo
        Dim bError As Boolean = True
        Dim lError As Long
        Dim strError As String = ""
        Dim daoOrden As New DAOOrdenes()
        Dim strIntervPsipostFalleciemiernto As String = ""

        'If TxtEgPrograma.Text = "" Then
        '    intEgPrograma = 0
        'Else
        '    intEgPrograma = TxtEgPrograma.Text
        'End If

        'If (Me.cmbMotEgreso.SelectedValue = Nothing) Then
        '    MsgBox("Error, debe seleccionar un Motivo de Egreso", MsgBoxStyle.Critical, "Historia Clinica")
        '    Exit Sub
        'End If

        'If Not (Me.cmbMotEgreso.SelectedValue = Nothing) Then
        '    intcmbMotEgreso = Me.cmbMotEgreso.SelectedValue
        'End If

        'If (Me.CmbLugarFallece.SelectedValue = Nothing) Then
        '    MsgBox("Error, debe seleccionar un Lugar de Fallecimiento", MsgBoxStyle.Critical, "Historia Clinica")
        '    Exit Sub
        'End If

        'If Not (Me.CmbLugarFallece.SelectedValue = Nothing) Then
        '    intCmbLugarFallece = Me.CmbLugarFallece.SelectedValue
        'End If


        'If Not (Me.CmboPreguntasAdministrativas.SelectedValue = Nothing) Then
        '    intCmbCausasAdminstrativas = Me.CmboPreguntasAdministrativas.SelectedValue
        'End If

        If mskEgrProg.Text <> "  /  /" Then 'WACHV,30 AGO2017, VALIDACION DE FECHA
            If bvalidarFecha(mskEgrProg.Text) = True Then
                MsgBox("Error, debe escribir una fecha de Egreso", MsgBoxStyle.Information, "Historia Clinica")
                Exit Sub
            End If
        Else
            MsgBox("Error, debe dar una fecha de Egreso", MsgBoxStyle.Information, "Historia Clinica")
            Exit Sub
        End If


        If (Me.cmbMotEgreso.SelectedValue = Nothing) Then 'WACHV,30 AGO2017, VALIDACION MOTIVO EGRESO
            MsgBox("Error, debe seleccionar un Motivo de Egreso", MsgBoxStyle.Information, "Historia Clinica")
            Exit Sub
        End If

        'WACHV,30 AGO2017, SI SELECCIONA FALLECE SON OBLIGATORIAS DONDE FALLECE
        If (Me.cmbMotEgreso.SelectedValue = 70301 And CmbLugarFallece.SelectedValue = Nothing) Then
            MsgBox("Error, Si el motivo de egreso es fallece, debe seleccionar algun lugar de fallecimiento ", MsgBoxStyle.Information, "Historia Clinica")
            Exit Sub
        End If

        'WACHV,30 AGO2017, SI SELECCIONA FALLECE SON OBLIGATORIAS Intervención psicológica pos fallecimiento
        If (Me.cmbMotEgreso.SelectedValue = 70301 And (RBSi_IntP.Checked = False And RBNo_IntP.Checked = False)) Then
            MsgBox("Error, Si el motivo de egreso es fallece, debe seleccionar la Intervención psicológica pos fallecimiento", MsgBoxStyle.Information, "Historia Clinica")
            Exit Sub
        End If

        If RBSi_IntP.Checked = True Then strIntervPsipostFalleciemiernto = "S"
        If RBNo_IntP.Checked = True Then strIntervPsipostFalleciemiernto = "N"


        lError = objEgresoCP.GrabarEgresoCP( _
        objConexion, objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision _
        , objPaciente.AnoAdmision, objPaciente.NumeroAdmision _
        , objPaciente.TipoDocumento, objPaciente.NumeroDocumento _
        , mskEgrProg.Text, TxtEgPrograma.Text, Me.cmbMotEgreso.SelectedValue, Me.CmboPreguntasAdministrativas.SelectedValue, Me.CmbLugarFallece.SelectedValue _
        , Me.TxtHospital.Text, strIntervPsipostFalleciemiernto _
        , Me.TxtRazon.Text _
        , "", objGeneral.Login)

        If lError = 0 Then
            MessageBox.Show("Registro Guardado.", "Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ParentForm.Controls.Find("pnlContenedorDatosPaciente", True)(0).Controls(0).Controls.Find("pnlAlarmas", True)(0).Controls.Find("btnPalitivo", True)(0).Visible = False
            Me.ParentForm.Controls.Find("pnlValoracionInicial", True)(0).Enabled = True
            fnRefrescarPaliativos()
            Me.ParentForm.Controls.Find("pnlContenedor", True)(0).Controls("btnSugerirRespuesta").Enabled = False ''WACHV, 29AGO2017, Activar el boton de proponer
            Me.Parent.Refresh()
            LimpiarDatos()
        End If

        '    'If bError Then
        '    '    Try
        '    '        Try
        '    '            daoOrden.GrabarAuditOrdenes(objConexion, objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision, _
        '    '            objPaciente.TipoDocumento & objPaciente.NumeroDocumento, objGeneral.Login, 0, 0, _
        '    '            0, 0, 0, "CLICK BOTON GUARDAR", "EV")
        '    '        Catch ex As Exception

        '    '        End Try
        '    '        ''Fin



        '    '        'martovar 2014-08-25 se agrega funcion para guardar los datos de medico y motivo de interconsulta sin una orden de procedimiento
        '    '        'lError = objBl.GrabarEvolucion(objConexion, Trim(tbDiagnostico.Text), Trim(tbObjetivo.Text), _
        '    '        '            Trim(tbParaclinicos.Text), Trim(tbPlanManejo.Text), Trim(tbSubjetivo.Text), Trim(txtNotasIngr.Text), _
        '    '        '           strFecha, intHora, intMinuto, strexp_pla, strcon_med, Trim(Me.Txtinterconsulta.Text), objGeneral.CodigoEspecialidad, Trim(strmedico), Trim(strmotivo), strvarcierre, Trim(strEspecialidad))

        '    '        If lError > 0 Then
        '    '            strvar = 0
        '    '            MsgBox("La evolución no se grabó, por favor verifique los datos", MsgBoxStyle.Exclamation)
        '    '            objEvolucion.Estado = "N"
        '    '            bError = True
        '    '        Else
        '    '            strvar = 1
        '    '            objGeneral.HistoriaClinicaTieneModificaciones = True
        '    '            objEvolucion.Estado = "G"
        '    '            LimpiarPantalla()


        '    '            resPre1 = ""
        '    '            resPre2 = ""
        '    '            modPlanManj = ""
        '    '            'grpGenPrg.Visible = False

        '    '            bError = False
        '    '            'cambio realizado por Ing. Ricardo Mauricio Zaldúa C.
        '    '            'fecha 2009-06-08
        '    '            'solicitado por Enrique Forero 
        '    '            'Motivo preguntar si desea imprimir el reporte 
        '    '            If MessageBox.Show("Desea imprimir el documento?", "Historia Clinica", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
        '    '                'cambio realizado por Ing. Ricardo Mauricio Zaldúa C.
        '    '                'fecha 2009-05-19
        '    '                'solicitado por Enrique Forero 
        '    '                'Motivo primero limpiar el formulario y dejar de ultima la impresion para que aparezca en pantalla
        '    '                ImprimirReporte(Format(CDate(strFecha), "yyyy/MM/dd"), intHora, intMinuto, strvarcierre) 'MARTOVAR se envia variable para identificar si se cerro la interconsulta
        '    '            End If

        '    '        End If

        '    '        Try
        '    '            daoOrden.GrabarAuditOrdenes(objConexion, objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision, _
        '    '            objPaciente.TipoDocumento & objPaciente.NumeroDocumento, objGeneral.Login, 0, 0, _
        '    '            0, 0, 0, "REGISTRO GRABADO ERROR:" & lError, "EV")
        '    '        Catch ex As Exception

        '    '        End Try

        '    '    Catch ex As Exception
        '    '        MessageBox.Show("El proceso de grabación de la evolución falló por: " & ex.Message, "Historia Clínica", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
        '    '    End Try
        '    'Else
        '    '    MsgBox(strError, MsgBoxStyle.Exclamation)
        '    '    objEvolucion.Estado = "N"
        '    'End If

    End Sub
    Private Sub fnRefrescarPaliativos()  'WACHV,30 AGO2017, Funcion que refresca los controles dentro un objeto
        For Each cntrl As Control In Me.ParentForm.Controls.Find("pnlValoracionInicial", True)(0).Controls("Gbvalinicial").Controls
            If TypeOf cntrl Is TextBox Then
                Dim objTextBox As New TextBox
                objTextBox = cntrl
                objTextBox.Text = ""
            End If
            If TypeOf cntrl Is RadioButton Then
                Dim objrb As New RadioButton()
                objrb = cntrl
                objrb.Checked = False
            End If
            'Si es un group box y es necesario recorrer dentro del objeto
            If TypeOf cntrl Is GroupBox Then
                For Each cntrlI As Control In cntrl.Controls
                    If TypeOf cntrlI Is RadioButton Then
                        Dim objrb As New RadioButton()
                        objrb = cntrlI
                        objrb.Checked = False
                    End If
                Next
                ''Activar Control
                cntrl.Enabled = True
            End If
        Next
        ''Para el boton de Guardar
        Me.ParentForm.Controls.Find("pnlValoracionInicial", True)(0).Controls("BttonGuardar").Enabled = True
        'Me.ParentForm.Controls.Find("pnlValoracionInicial", True)(0).Controls(0).Enabled = True

        'Dim rbOncologico As New RadioButton()
        'Dim rbNOOncologico As New RadioButton()
        'Dim RBSiIngProg As New RadioButton()
        'Dim RBNoIngProg As New RadioButton()
        'Dim RBSiJP As New RadioButton()
        'Dim RBNoJP As New RadioButton()
        'Dim RBSiInP As New RadioButton()
        'Dim RBNoInP As New RadioButton()

        'rbOncologico = CType(Me.ParentForm.Controls.Find("pnlValoracionInicial", True)(0).Controls("Gbvalinicial").Controls.Find("RbOncologico", True)(0), RadioButton)
        'rbNOOncologico = CType(Me.ParentForm.Controls.Find("pnlValoracionInicial", True)(0).Controls("Gbvalinicial").Controls.Find("RbNoOncologico", True)(0), RadioButton)
        'RBSiIngProg = CType(Me.ParentForm.Controls.Find("pnlValoracionInicial", True)(0).Controls("Gbvalinicial").Controls.Find("RBSiIngProg", True)(0), RadioButton)
        'RBNoIngProg = CType(Me.ParentForm.Controls.Find("pnlValoracionInicial", True)(0).Controls("Gbvalinicial").Controls.Find("RBNoIngProg", True)(0), RadioButton)
        'RBSiJP = CType(Me.ParentForm.Controls.Find("pnlValoracionInicial", True)(0).Controls("Gbvalinicial").Controls.Find("RBSiJP", True)(0), RadioButton)
        'RBNoJP = CType(Me.ParentForm.Controls.Find("pnlValoracionInicial", True)(0).Controls("Gbvalinicial").Controls.Find("RBNoJP", True)(0), RadioButton)
        'RBSiInP = CType(Me.ParentForm.Controls.Find("pnlValoracionInicial", True)(0).Controls("Gbvalinicial").Controls.Find("RBSiInP", True)(0), RadioButton)
        'RBNoInP = CType(Me.ParentForm.Controls.Find("pnlValoracionInicial", True)(0).Controls("Gbvalinicial").Controls.Find("RBNoInP", True)(0), RadioButton)

        'rbOncologico.Checked = False
        'rbNOOncologico.Checked = False
        'RBSiIngProg.Checked = False
        'RBNoIngProg.Checked = False
        'RBSiJP.Checked = False
        'RBNoJP.Checked = False
        'RBSiInP.Checked = False
        'RBNoInP.Checked = False

        'Me.ParentForm.Controls.Find("pnlContenedorDatosPaciente", True)(0).Controls(0).Controls.Find("pnlAlarmas", True)(0).Controls.Find("btnPalitivo", True)(0).Visible
        'Me.ParentForm.Controls.Find("pnlValoracionInicial", True)(0).Enabled = True
        'Me.ParentForm.Controls.Find("pnlValoracionInicial", True)(0).Controls("Gbvalinicial").Controls.Find("txtCodDiagnostico", True)(0).Text = ""
        'Me.ParentForm.Controls.Find("pnlValoracionInicial", True)(0).Controls("Gbvalinicial").Controls.Find("ObsJuntaPal", True)(0).Text = ""
        'Me.ParentForm.Controls.Find("pnlValoracionInicial", True)(0).Controls("Gbvalinicial").Controls.Find("txtCodDiagnostico", True)(0).Refresh()
        'Me.ParentForm.Controls.Find("pnlValoracionInicial", True)(0).Controls("Gbvalinicial").Controls.Find("ObsJuntaPal", True)(0).Refresh()
        'Me.ParentForm.Controls.Find("pnlValoracionInicial", True)(0).Refresh()
    End Sub

#End Region

    Private Sub btNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
        Try

            Select Case intopcion
                Case 1 '' motivo egreso
                    Try
                        cmbMotEgreso.ResetText()
                        cmbMotEgreso.BeginUpdate()
                        'cmbMotEgreso.Items.Insert(0, "Seleccione")
                        cmbMotEgreso.ValueMember = "id"
                        cmbMotEgreso.DisplayMember = "descripcion"
                        cmbMotEgreso.DataSource = objCP.CargarCombosCP(3)
                        cmbMotEgreso.EndUpdate()

                    Catch ex As Exception
                        MsgBox("Error en la consulta de Motivo Egreso. " & ex.Message, MsgBoxStyle.Information)
                    End Try
                Case 2 ''Donde Fallece
                    Try
                        CmbLugarFallece.ResetText()
                        CmbLugarFallece.BeginUpdate()
                        CmbLugarFallece.ValueMember = "id"
                        CmbLugarFallece.DisplayMember = "descripcion"
                        CmbLugarFallece.DataSource = objCP.CargarCombosCP(4)
                        CmbLugarFallece.EndUpdate()
                    Catch ex As Exception
                        MsgBox("Error en la consulta Donde Fallece. " & ex.Message, MsgBoxStyle.Information)
                    End Try
                Case 3 ''Causas Administrativas
                    Try
                        CmboPreguntasAdministrativas.ResetText()
                        CmboPreguntasAdministrativas.BeginUpdate()
                        CmboPreguntasAdministrativas.ValueMember = "id"
                        CmboPreguntasAdministrativas.DisplayMember = "descripcion"
                        CmboPreguntasAdministrativas.DataSource = objCP.CargarCombosCP(6)
                        CmboPreguntasAdministrativas.EndUpdate()
                    Catch ex As Exception
                        MsgBox("Error en la consulta Causas Administrativas. " & ex.Message, MsgBoxStyle.Information)
                    End Try

            End Select

        Catch ex As Exception

        End Try

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
            dtDiagnostico = objBl.ConsultarDiagnosticoReingreso(objGeneral.Prestador, objGeneral.Sucursal, _
                                    objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision, _
                                    "E", objGeneral.Login, objConexion)


        Catch ex As Exception
            'MsgBox("Error al consultar datos", MsgBoxStyle.Exclamation)
        End Try

    End Sub
#End Region

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub btnSugerirRespuesta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSugerirRespuesta.Click
        Try
            LimpiarDatos()
            Dim oEgresoCP As New EgresoCP()
            loadEgresoCP(oEgresoCP.SugerirRespuesta(objGeneral, objPaciente))

        Catch ex As Exception
            MessageBox.Show("No fue posible consultar las últimas respuestas de este paciente.", "Historia Clínica", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

        End Try

    End Sub
    Private Sub loadEgresoCP(ByVal oEgresoCP As EgresoCP)
        Try
            mskEgrProg.Text = IIf(oEgresoCP.Fecha_de_egreso = Nothing, "", oEgresoCP.Fecha_de_egreso)
            TxtEgPrograma.Text = IIf(oEgresoCP.EstanciadePrograma = Nothing, "", oEgresoCP.EstanciadePrograma)

            cmbMotEgreso.SelectedValue = IIf(oEgresoCP.MotivoEgreso = Nothing, "", oEgresoCP.MotivoEgreso)

            'Dim index0 As Integer
            'index0 = cmbMotEgreso.FindString(oEgresoCP.MotivoEgreso)
            'cmbMotEgreso.SelectedIndex = index0

            CmbLugarFallece.SelectedValue = IIf(oEgresoCP.LugarFallece = Nothing, DBNull.Value, oEgresoCP.LugarFallece)

            'Dim index1 As Integer
            'index1 = CmbLugarFallece.FindString(oEgresoCP.LugarFallece)
            'CmbLugarFallece.SelectedIndex = index1

            TxtHospital.Text = IIf(oEgresoCP.HospitalfueradeRed = Nothing, "", oEgresoCP.HospitalfueradeRed)

            If Not (oEgresoCP.IntervencionSicologicapostFallecimiento = Nothing) Then
                If oEgresoCP.IntervencionSicologicapostFallecimiento.Substring(oEgresoCP.IntervencionSicologicapostFallecimiento.Length - 1).Contains("1") Then
                    RBSi_IntP.Checked = True
                    RBNo_IntP.Checked = False
                Else
                    RBSi_IntP.Checked = False
                    RBNo_IntP.Checked = True
                End If
            End If

            TxtRazon.Text = IIf(oEgresoCP.ExpliqueRazon = Nothing, "", oEgresoCP.ExpliqueRazon)


        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub


    'Private Sub mskIngProg_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mskIngProg.Validating
    '    If mskEgrProg.Text <> "  /  /" Then
    '        If Not IsDate(mskEgrProg.Text) Then
    '            MsgBox("Fecha invalida. Debe digitar una fecha valida.", MsgBoxStyle.Information)
    '            e.Cancel = True
    '            mskEgrProg.Select(0, mskEgrProg.TextLength)
    '        End If
    '    End If
    'End Sub

    Private Sub ObsJuntaPal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub mskEgrProg_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mskEgrProg.Validating

        If mskEgrProg.Text <> "  /  /" Then

            If Not IsDate(mskEgrProg.Text) Then
                MsgBox("Fecha invalida. Debe digitar una fecha valida.", MsgBoxStyle.Information)
                mskEgrProg.Text = ""
                e.Cancel = True
                mskEgrProg.Select(0, mskEgrProg.TextLength)
            Else
                If bvalidarFecha(mskEgrProg.Text) Then
                    MsgBox("Fecha invalida. Debe digitar una fecha valida.", MsgBoxStyle.Information)
                    mskEgrProg.Text = ""
                    e.Cancel = True
                    mskEgrProg.Select(0, mskEgrProg.TextLength)
                End If
            End If

            'Inicia: CCGUTIEREZ - OSI. 25/03/2020
            'Proyecto: Sophia - CA_5845702 
            'Cambio: Se corrige la validacion de las Fechas, Dias de Estancia y el Ingreso en el programa,
            '        debido a que permite grabar Egresos a pacientes que no tienen ingreso,
            '        y calcular valores de Estancia negativos
            'Solicitud: CA_5845702

            Dim intCantDias As Integer
            Dim strIngreso As String
            Dim strFecProg As String
            Dim dt As DataTable

            dt = objEgresoCP.dtbCalcularEstanciaPrograma(objPaciente.TipoDocumento, objPaciente.NumeroDocumento, mskEgrProg.Text)

            If dt.Rows.Count > 0 Then
                intCantDias = Convert.ToInt32(dt.Rows(0).Item(0))
                strIngreso = Convert.ToString(dt.Rows(0).Item(1))
                strFecProg = Convert.ToString(dt.Rows(0).Item(2))
                If strIngreso = "S" Then
                    If intCantDias < 0 Then
                        MsgBox("Fecha Invalida. La fecha de Egreso no puede ser Anterior a la fecha de Ingreso. Paciente ingresa: " & strFecProg, MsgBoxStyle.Information)
                        Me.mskEgrProg.Focus()
                        mskEgrProg.Select(0, mskEgrProg.TextLength)
                        Me.TxtEgPrograma.Text = ""
                        Exit Sub
                    Else
                        Me.TxtEgPrograma.Text = intCantDias
                        mskEgrProg.Select(0, mskEgrProg.TextLength)
                    End If
                Else
                    MsgBox("El paciente no está ingresado en el programa de Cuidado Paliativo", MsgBoxStyle.Information)
                    Me.mskEgrProg.Text = ""
                    Me.TxtEgPrograma.Text = ""
                    Me.mskEgrProg.Focus()
                    Exit Sub
                End If
            End If

            'Me.TxtEgPrograma.Text = objEgresoCP.intCalcularEstanciaPrograma(objPaciente.TipoDocumento, objPaciente.NumeroDocumento, mskEgrProg.Text)
            'mskEgrProg.Select(0, mskEgrProg.TextLength)
            'Fin. CCGUTIEREZ
        End If
    End Sub

    Private Function bvalidarFecha(ByVal strvalorvalidar As String) As Boolean

        Dim bValidaFecha As Boolean = False
        Dim fechaMinima As New DateTime(1900, 1, 1)
        Dim fechaMaxima As DateTime = Format(FuncionesGenerales.FechaServidor())
        Dim dtFechaNacimientoPaciente As Date = objPaciente.FechaNacimiento

        Try
            ' Valor a Evaluar
            '
            If IsDate(strvalorvalidar) Then
                Dim fecha As DateTime = CDate(strvalorvalidar)

                'Inicia: CCGUTIEREZ - OSI. 25/03/2020
                'Proyecto: Sophia - CA_5845702 
                'Cambio: Se corrige la validacion de fechas para que no permita egresos a futuro

                If (fecha < fechaMinima) OrElse (fecha < dtFechaNacimientoPaciente) Then
                    'MessageBox.Show("Fecha errónea")
                    bValidaFecha = True
                ElseIf (fecha > fechaMaxima) Then
                    bValidaFecha = True
                End If

                'If (fecha < fechaMinima) OrElse (fecha > fechaMaxima) OrElse (fecha < dtFechaNacimientoPaciente) Then
                '    'MessageBox.Show("Fecha errónea")
                '    bValidaFecha = True
                'End If
                'Fin. CCGUTIEREZ
            Else
                'MessageBox.Show("Fecha errónea")
                bValidaFecha = True
            End If


            bvalidarFecha = bValidaFecha

        Catch ex As Exception
            bValidaFecha = True
        End Try

    End Function

    Private Sub cmbMotEgreso_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMotEgreso.SelectedIndexChanged
        If cmbMotEgreso.SelectedIndex <> -1 Then
            If cmbMotEgreso.Text = "Fallece" Then
                Me.Label1.Enabled = True
                Me.CmbLugarFallece.Enabled = True
                ImprimirReporte()
            ElseIf cmbMotEgreso.Text.Trim = "Causas administrativas" Then
                CmbLugarFallece.SelectedIndex = -1
                fncMostrar_CausasAdmin(True)
            Else
                CmbLugarFallece.SelectedIndex = -1
                Me.Label1.Enabled = False
                Me.CmbLugarFallece.Enabled = False
                Me.Label2.Enabled = False
                Me.TxtHospital.Enabled = False
                'Me.Label3.Enabled = False
                'Me.GroupBox4.Enabled = False
                fncMostrar_CausasAdmin(False)
            End If
        End If
    End Sub

    Private Sub CmbLugarFallece_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbLugarFallece.SelectedIndexChanged
        If CmbLugarFallece.SelectedIndex <> -1 Then
            If CmbLugarFallece.Text.Trim() = "Intrahospitalario fuera de la red" Then
                CmboPreguntasAdministrativas.Enabled = False
                Me.Label2.Enabled = True
                Me.TxtHospital.Enabled = True
                'Me.Label3.Enabled = True
                'Me.GroupBox4.Enabled = True
            Else
                Me.Label2.Enabled = False
                Me.TxtHospital.Enabled = False
                Me.TxtHospital.Text = ""
                'Me.Label3.Enabled = False
                'Me.GroupBox4.Enabled = False
                RBSi_IntP.Checked = False
                RBNo_IntP.Checked = False
                'Me.TxtRazon.Enabled = False
                'Me.TxtRazon.Text = ""
                'Me.Label4.Enabled = False
            End If
        End If
    End Sub

    Private Sub RBNo_IntP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBNo_IntP.CheckedChanged
        Me.TxtRazon.Enabled = True
        Me.Label4.Enabled = True
    End Sub

    Private Sub RBSi_IntP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBSi_IntP.CheckedChanged
        Me.TxtRazon.Enabled = False
        Me.TxtRazon.Text = ""
        Me.Label4.Enabled = False
    End Sub

    Private Sub ImprimirReporte()
        Dim frmRepCond As New frmRepCondolencias
        frmRepCond.imprimirCondolencias(objConexion, objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision, objPaciente.AnoAdmision,
        objPaciente.NumeroAdmision, objPaciente.TipoDocumento, objPaciente.NumeroDocumento)
        'frmRepCond.Show()
        'frmRepCond.ActiveForm.MaximizeBox = False ''No activar
        'frmRepCond.ActiveForm.MinimizeBox = False ''No Activar
        frmRepCond.ShowDialog()
        'objDescrQx.Procedimiento
    End Sub

    Private Sub mskEgrProg_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles mskEgrProg.MaskInputRejected

    End Sub
End Class
