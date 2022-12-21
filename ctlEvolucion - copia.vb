Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes.FuncionesGenerales


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

        frmHistoriaPrincipal.blnFirstEvolucion = False

        objDescrQx = DescripcionQuirurgica.Instancia ''cpgaray

        objGeneral = Generales.Instancia
        objPaciente = Paciente.Instancia
        objConexion = Conexion.Instancia
        objEvolucion = Evolucion.Instancia
        strCadenaLocal = objGeneral.CadenaLocal
        'CargarCombos(1) ''Descripcion Quirurgica tipo de de empleado
        'CargarCombos(3) ''Descripcion Quirurgica procedimientos
        'CargarCombos(5) ''tipos de anestesia
        'CargarCombos(6) ''Profilaxis
        'CargarCombos(7)
        'CargarObjetosDiagnosticos() ''Diagnosticos
        pnlEvolucion.Enabled = False
        DatosIniciales()
        IniciarEvolucion()

        ctlDescrQx = ctlDescripcionQuirurgica.Instancia
        lblTitEvolucion.Text = String.Empty
        Dim var As String

        var = objEvolucion1.consultarEspecialidadInterconsulta(objConexion, objGeneral.Prestador, objGeneral.Sucursal, _
                                    objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision, objGeneral.Login, objGeneral.CodigoEspecialidad)
        If var = "SI" Then
            'Me.'Txtinterconsulta.Text = ""
            objEvolucion.Objetivo = ""
            objEvolucion.Diagnostico = ""
            objEvolucion.Paraclinico = ""
            objEvolucion.PlanManejo = ""
            objEvolucion.Subjetivo = ""
            objEvolucion.Fecha = ""
            objEvolucion.NotasIngreso = ""
            MostrarInterconsulta()
            'Me.'Txtinterconsulta.Visible = True
            RbEvolucion.Visible = False
            rbIngreso.Visible = False
            Rbinterconsulta.Visible = True
            Rbinterconsulta.Checked = True
            pnlEvolucion.Visible = True
            lblTitEvolucion.Text = "Interconsulta"
        Else
            RbEvolucion.Visible = True
            rbIngreso.Visible = True
            Rbinterconsulta.Visible = False
        End If
        txtFechaInicial.Text = FechaServidor()
        pnlEvolucion.Visible = False
    End Sub

    Private Sub IniciarEvolucion()
        Dim lError As Long
        Dim objBl As New Sophia.HistoriaClinica.BL.BLPlanManejo


        lError = objBl.ConsultarEvolucion(objConexion, objEvolucion)
        If lError <> 0 Then
            MessageBox.Show("Error al consultar datos", "Historia Clinica", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Me.LimpiarPantalla()
        Me.LimpiarDiagnosticoEvo()

        ConsultarValores()
        CargarValoresIniciales()

        If objEvolucion.Estado = "N" Then
            'tbDiagnostico.Text = objEvolucion.Diagnostico
            tbObjetivo.Text = objEvolucion.Objetivo
            tbParaclinicos.Text = objEvolucion.Paraclinico
            tbSubjetivo.Text = objEvolucion.Subjetivo
            tbPlanManejo.Text = objEvolucion.PlanManejo
            'mtFechaInicial.Text = objEvolucion.Fecha
            'tbHora.Text = objEvolucion.Hora
            'tbMinuto.Text = objEvolucion.Minuto
            'txtNotasIngr.Focus()
            Me.dtgEvolucion.Enabled = True
            Exit Sub
        End If

        'martovar 2014-09-19 se agrega validacion en caso de que el medico ingrese nuevamente se habilitan los campos 2.9.0
        If objEvolucion.Estado = "" Then
            RbEvolucion.Enabled = True
            Rbinterconsulta.Enabled = True
            rbIngreso.Enabled = True
            Me.btGrabar.Enabled = True
            Me.btNuevo.Enabled = True
            Me.btImprimir.Enabled = True
        End If


        'If Me.dtgEvolucion.RowCount > 0 Then
        '    Me.dtgEvolucion.Enabled = True
        '    'Me.'mtFechaInicial.Enabled = False
        '    'Me.'tbHora.Enabled = False
        '    'Me.'tbMinuto.Enabled = False
        '    'Me.'tbDiagnostico.Enabled = False
        '    Me.tbObjetivo.Enabled = False
        '    Me.tbParaclinicos.Enabled = False
        '    Me.tbPlanManejo.Enabled = False
        '    Me.tbSubjetivo.Enabled = False
        '    Me.btGrabar.Enabled = False
        '    Me.btNuevo.Enabled = True
        'Else
        Dim dtFecha As Date
        dtFecha = FuncionesGenerales.FechaServidor()
        PFecha.Enabled = False
        'mtFechaInicial.Text = Format(dtFecha, "dd/MM/yyyy")
        'tbHora.Text = Hour(dtFecha)
        'tbMinuto.Text = Minute(dtFecha)
        tmHoraEvolucion.Interval = (60 - Second(dtFecha)) * 1000
        tmHoraEvolucion.Enabled = True
        'txtNotasIngr.Focus()

        If objGeneral.Pais = "482" Then
            TextBox2.Text = "¿Usted realizo el proceso de interacción de medicamentos?."
        End If

        'End If
        'martovar 2014-09-19 se agrega validacion en caso de que el medico tenga especialidad Medicina General 2.9.0
        If objGeneral.CodigoEspecialidad = "001" Or objGeneral.CodigoEspecialidad = "003" Or objGeneral.CodigoEspecialidad = "004" Or objGeneral.CodigoEspecialidad = "0028" Or objGeneral.CodigoEspecialidad = "069" Or objGeneral.CodigoEspecialidad = "083" Or objGeneral.CodigoEspecialidad = "704" Or objGeneral.CodigoEspecialidad = "705" Or objGeneral.CodigoEspecialidad = "901" Or objGeneral.CodigoEspecialidad = "903" Then
            Me.Rbinterconsulta.Enabled = False
        End If


    End Sub

    Private Sub CargarValoresIniciales()

        If Not objEvolucion.dtDiagnosticoEvo Is Nothing Then
            dgListaEvo.DataSource = objEvolucion.dtDiagnosticoEvo
        End If
    End Sub
#End Region

    ''' <summary>
    ''' Limpia Todos los controles del Control
    ''' </summary>
    ''' <remarks></remarks>
#Region "LimpiarPantalla"
    Private Sub LimpiarPantalla()
        'tbDiagnostico.Text = ""
        tbObjetivo.Text = ""
        tbParaclinicos.Text = ""
        tbPlanManejo.Text = ""
        tbSubjetivo.Text = ""
        'txtNotasIngr.Text = ""  ''Claudia Garay
        ''Me.'Txtinterconsulta.Text = ""
        'tbDiagnostico.Enabled = True
        tbObjetivo.Enabled = True
        tbParaclinicos.Enabled = True
        tbPlanManejo.Enabled = True
        tbSubjetivo.Enabled = True
        Me.btGrabar.Enabled = True
        ''Me.'Txtinterconsulta.Enabled = True
    End Sub
#End Region



#Region "Validaciones"

    Private Sub tmHoraEvolucion_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmHoraEvolucion.Tick
        Dim dtFecha As Date
        dtFecha = FuncionesGenerales.FechaServidor()
        'mtFechaInicial.Text = Format(dtFecha, "dd/MM/yyyy")
        'tbHora.Text = Hour(dtFecha)
        'tbMinuto.Text = Minute(dtFecha)
        tmHoraEvolucion.Interval = 60000
    End Sub

    'Private Sub 'tbDiagnostico_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles 'tbDiagnostico.Validated
    '    objEvolucion.Estado = "N"
    '    objEvolucion.Diagnostico = 'tbDiagnostico.Text
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
        frmRepEvolucion.imprimirRepEvolucion(objConexion, objGeneral.Prestador, objGeneral.Sucursal, _
                                            objPaciente.TipoAdmision, objPaciente.AnoAdmision, _
                                            objPaciente.NumeroAdmision, dteFecha, intHora, intMinuto, _
                                            objGeneral.Login, strcierre)

    End Sub
#End Region



    Private Sub ctlEvolucion_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged

        If sender.Visible = True Then
            LimpiarDatos()
            IniciarEvolucion()
            pnlEvolucion.Enabled = False

            pnlContEvolucion.Visible = True
            ctlDescrQx.Visible = False
            pnlContenedor.Height = 1500

            If frmHistoriaPrincipal.blnFirstEvolucion = True Then
                frmHistoriaPrincipal.blnFirstEvolucion = False
            End If
        End If
    End Sub

    Private Sub LimpiarDatos()
        Dim i As Integer

        'mtFechaInicial.ResetText()
        'tbHora.ResetText()
        'tbMinuto.ResetText()
        'tbDiagnostico.ResetText()
        tbSubjetivo.ResetText()
        tbParaclinicos.ResetText()
        tbObjetivo.ResetText()
        tbPlanManejo.ResetText()
        cbDiagnosticoEvo.ResetText()
        If dgListaEvo.Rows.Count > 0 Then
            For i = 0 To dgListaEvo.Rows.Count - 1
                dgListaEvo.Rows.RemoveAt(0)
            Next
        End If
    End Sub



    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub



    Private Sub EditarDatosEvolucion(ByVal dr As DataGridViewRow)


        ''Me.'mtFechaInicial.Text = Format(CDate(dr.Cells("Fecha_Evol").Value.ToString), "dd/MM/yyyy")
        ''Me.'tbHora.Text = dr.Cells("hora_evol").Value.ToString
        ''Me.'tbMinuto.Text = dr.Cells("min_evol").Value.ToString
        ''Me.'tbDiagnostico.Text = dr.Cells("DiagActual").Value.ToString
        Me.tbSubjetivo.Text = dr.Cells("subjetivo").Value.ToString
        Me.tbParaclinicos.Text = dr.Cells("interpParaclic").Value.ToString
        Me.tbObjetivo.Text = dr.Cells("notas").Value.ToString
        Me.tbPlanManejo.Text = dr.Cells("orden").Value.ToString
        'Me.'txtNotasIngr.Text = dr.Cells("NotasIngreso").Value.ToString
        'Me.'Txtinterconsulta.Text = dr.Cells("Interconsulta").Value.ToString
        Me.btGrabar.Enabled = False
        Me.btImprimir.Enabled = True
        Me.btNuevo.Enabled = True
        Me.btImprimir.Focus()
        If Not IsDBNull(dr.Cells("NotasIngreso").Value.ToString) Then
            If dr.Cells("NotasIngreso").Value.ToString <> "" Then
                Me.rbIngreso.Checked = True
                MostrarIngreso()
            Else
                If dr.Cells("Interconsulta").Value.ToString <> "N" Then
                    Me.Rbinterconsulta.Checked = True
                    MostrarInterconsulta()
                Else
                    Me.RbEvolucion.Checked = True
                    MostrarEvolucion()
                End If
            End If
            'Me.rbIngreso.Enabled = False
            'Me.Rbinterconsulta.Enabled = False
            'Me.RbEvolucion.Enabled = False
            ''Me.'txtNotasIngr.Enabled = False
            'Me.tbSubjetivo.Enabled = False
            'Me.tbObjetivo.Enabled = False
            'Me.tbParaclinicos.Enabled = False
            'Me.tbPlanManejo.Enabled = False
            ''Me.'tbDiagnostico.Enabled = False
            ''Me.'Txtinterconsulta.Enabled = False
            ''Me.'tbDiagnostico.Enabled = False
        Else
            MostrarEvolucion()
        End If
    End Sub


    'Private Sub tbPlanManejo_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txtPlanManejogotfocus = False
    '    If tbPlanManejo.Text <> "" Then
    '        grpGenPrg.Visible = True
    '    End If
    'End Sub




    Private Sub rbIngreso_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbIngreso.Click
        If rbIngreso.Checked = True Then
            objEvolucion.Objetivo = ""
            objEvolucion.Diagnostico = ""
            objEvolucion.Paraclinico = ""
            objEvolucion.PlanManejo = ""
            objEvolucion.Subjetivo = ""
            objEvolucion.Fecha = ""
            objEvolucion.NotasIngreso = ""
            MostrarIngreso()
            'Me.'Txtinterconsulta.Visible = False
        End If
    End Sub

    Private Sub RbEvolucion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbEvolucion.Click
        If RbEvolucion.Checked = True Then
            objEvolucion.Objetivo = ""
            objEvolucion.Diagnostico = ""
            objEvolucion.Paraclinico = ""
            objEvolucion.PlanManejo = ""
            objEvolucion.Subjetivo = ""
            objEvolucion.Fecha = ""
            objEvolucion.NotasIngreso = ""
            MostrarEvolucion()
            'Me.'Txtinterconsulta.Visible = False
            Me.Label1.Visible = False
        End If
    End Sub
    ''Claudia Garay Acreditacion Noviembre 26 de 2010
    Public Sub MostrarIngreso()
        pnlEvolucion.Enabled = True
        ''lbDiagnostico.Visible = False
        ''tbDiagnostico.Visible = False
        ''tbDiagnostico.Enabled = False

        'Me.'lbDiagnostico.Location = New System.Drawing.Point(4, 434)
        ''Me.'tbDiagnostico.Location = New System.Drawing.Point(106, 431)
        'lblNotas.Visible = True
        'txtNotasIngr.Visible = True
        'lblNotas.Enabled = True
        'txtNotasIngr.Enabled = True
        'txtNotasIngr.TabIndex = 34
        tbSubjetivo.TabIndex = 35
        tbParaclinicos.TabIndex = 37
        tbObjetivo.TabIndex = 36
        tbPlanManejo.TabIndex = 38
        'tbDiagnostico.TabIndex = 39
        'Me.'Txtinterconsulta.Visible = False
        Me.Label1.Visible = False
    End Sub
    ''Claudia Garay Acreditacion Noviembre 26 de 2010
    Public Sub MostrarEvolucion()
        pnlEvolucion.Enabled = True
        'lbDiagnostico.Visible = True
        'tbDiagnostico.Visible = True
        'tbDiagnostico.Enabled = True
        ''lbDiagnostico.Location = 'lblNotas.Location
        ''lbDiagnostico.Location = New System.Drawing.Point(4, 434)
        ''Me.'tbDiagnostico.Location = New System.Drawing.Point(106, 431)
        'lblNotas.Visible = False
        'txtNotasIngr.Visible = False
        'lblNotas.Enabled = False
        'txtNotasIngr.Enabled = False
        'tbDiagnostico.TabIndex = 33
        'Me.'Txtinterconsulta.Visible = False
        Me.Label1.Visible = False
    End Sub

    Public Sub MostrarInterconsulta()
        pnlEvolucion.Enabled = True
        'Me.'lbDiagnostico.Location = New System.Drawing.Point(4, 434)
        ''Me.'tbDiagnostico.Location = New System.Drawing.Point(106, 431)
        'lblNotas.Visible = False
        'txtNotasIngr.Visible = False
        'lblNotas.Enabled = False
        'txtNotasIngr.Enabled = False
        ''tbDiagnostico.TabIndex = 33
        'Me.'Txtinterconsulta.Visible = True
        Me.Label1.Visible = True
    End Sub

#Region "Grabar"


    Private Sub btGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGrabar.Click

        Dim objBl As New Sophia.HistoriaClinica.BL.BLPlanManejo
        Dim bError As Boolean = True
        Dim lError As Long
        Dim strError As String = ""
        Dim intHora As Integer
        Dim intMinuto As Integer
        Dim strFecha As String = ""
        Dim strvarcierre As String = ""
        Dim daoOrden As New DAOOrdenes()

        If resPre1 = "" And resPre2 = "" And modPlanManj = "S" Then
            MsgBox("De respuesta a las preguntas de explicacion del plan y conciliacion de medicamentos.")
            rdPlaManPrg1Si.Focus()
            Return

        End If

        'If 'tbDiagnostico.Text.Length = 0 And tbObjetivo.Text.Length = 0 And tbParaclinicos.Text.Length = 0 _
        '         And 
        If tbPlanManejo.Text.Length = 0 And tbSubjetivo.Text.Length = 0 Then
            bError = False
            strError = "Debe ingresar algún valor para la evolución" & Chr(13)
        End If

        'If Not IsDate('mtFechaInicial.Text) Or 'mtFechaInicial.Text = "  /  /" Then
        '    strError = strError & "Debe ingresar la fecha correctamente" & Chr(13)
        '    'mtFechaInicial.Focus()
        '    bError = False
        'End If
        'If 'tbHora.Text.Length < 0 Or 'tbHora.Text > 24 Or (Not IsNumeric('tbHora.Text)) Then
        '    strError = strError & "Debe ingresar la hora" & Chr(13)
        '    'tbHora.Focus()
        '    bError = False
        'End If
        'If 'tbMinuto.Text.Length = 0 Or 'tbMinuto.Text > 59 Or (Not IsNumeric('tbMinuto.Text) Or 'tbMinuto.Text < 0) Then
        '    strError = strError & "Debe ingresar minutos" & Chr(13)
        '    'tbMinuto.Focus()
        '    bError = False
        'End If

        If bError Then
            Try
                'If Val('tbHora.Text) = Val('tbHora.Tag) And Val('tbMinuto.Text) = Val('tbMinuto.Tag) Then
                '    MessageBox.Show("Imposible Registrar Nueva Evolución en la Misma Hora y Minuto (" & Val('tbHora.Tag) & " : " & 'tbMinuto.Tag & ") de Evolución Anterior.", "Historia Clínica", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
                '    Exit Sub
                'End If
                Dim strexp_pla As String
                Dim strcon_med As String


                If rdPlaManPrg1Si.Checked = True Then
                    strexp_pla = "S"
                ElseIf rdPlaManPrg1No.Checked = True Then
                    strexp_pla = "N"
                Else
                    strexp_pla = ""
                End If
                If rdPlaManPrg2Si.Checked = True Then
                    strcon_med = "S"
                ElseIf rdPlaManPrg2No.Checked = True Then
                    strcon_med = "N"
                Else
                    strcon_med = ""
                End If

                ''Claudia Garay Septiembre 8 de 2011
                ''Auditoria de evoluciones

                Try
                    daoOrden.GrabarAuditOrdenes(objConexion, objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision, _
                    objPaciente.TipoDocumento & objPaciente.NumeroDocumento, objGeneral.Login, 0, 0, _
                    0, 0, 0, "CLICK BOTON GUARDAR", "EV")
                Catch ex As Exception

                End Try
                ''Fin

                'If Len('Txtinterconsulta.Text) > 0 Then
                '    If MessageBox.Show("Desea Cerrar la Interconsulta?", "Historia Clinica", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                '        strvarcierre = "S"
                '    Else
                '        strvarcierre = "N"
                '    End If
                'Else
                '    strmedico = ""
                '    strmotivo = ""
                '    Me.strEspecialidad = ""
                'End If

                'martovar 2014-08-25 se agrega funcion para guardar los datos de medico y motivo de interconsulta sin una orden de procedimiento
                'lError = objBl.GrabarEvolucion(objConexion, Trim('tbDiagnostico.Text), Trim(tbObjetivo.Text), _
                '            Trim(tbParaclinicos.Text), Trim(tbPlanManejo.Text), Trim(tbSubjetivo.Text), Trim('txtNotasIngr.Text), _
                '           strFecha, intHora, intMinuto, strexp_pla, strcon_med, Trim('Me.'Txtinterconsulta.Text), objGeneral.CodigoEspecialidad, Trim(strmedico), Trim(strmotivo), strvarcierre, Trim(strEspecialidad))

                If lError > 0 Then
                    strvar = 0
                    MsgBox("La evolución no se grabó, por favor verifique los datos", MsgBoxStyle.Exclamation)
                    objEvolucion.Estado = "N"
                    bError = True
                Else
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
                    If MessageBox.Show("Desea imprimir el documento?", "Historia Clinica", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        'cambio realizado por Ing. Ricardo Mauricio Zaldúa C.
                        'fecha 2009-05-19
                        'solicitado por Enrique Forero 
                        'Motivo primero limpiar el formulario y dejar de ultima la impresion para que aparezca en pantalla
                        ImprimirReporte(Format(CDate(strFecha), "yyyy/MM/dd"), intHora, intMinuto, strvarcierre) 'MARTOVAR se envia variable para identificar si se cerro la interconsulta
                    End If

                End If

                Try
                    daoOrden.GrabarAuditOrdenes(objConexion, objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision, _
                    objPaciente.TipoDocumento & objPaciente.NumeroDocumento, objGeneral.Login, 0, 0, _
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

        'Adicionar valores al objeto \
        If bError Then
            objEvolucion.Objetivo = tbObjetivo.Text
            'objEvolucion.Diagnostico = 'tbDiagnostico.Text
            objEvolucion.Paraclinico = tbParaclinicos.Text
            objEvolucion.PlanManejo = tbPlanManejo.Text
            objEvolucion.Subjetivo = tbSubjetivo.Text
            'objEvolucion.NotasIngreso = 'txtNotasIngr.Text
            If rdPlaManPrg1Si.Checked = True Then
                objEvolucion.exp_pla = "S"
            ElseIf rdPlaManPrg1No.Checked = True Then
                objEvolucion.exp_pla = "N"
            Else
                objEvolucion.exp_pla = ""
            End If
            If rdPlaManPrg2Si.Checked = True Then
                objEvolucion.con_med = "S"
            ElseIf rdPlaManPrg2No.Checked = True Then
                objEvolucion.con_med = "N"
            Else
                objEvolucion.con_med = ""
            End If
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
            rdPlaManPrg2Si.Checked = False
            rdPlaManPrg2No.Checked = False
        End If
        If (strvar = 1) Then
            RbEvolucion.Enabled = False
            Rbinterconsulta.Enabled = False
            rbIngreso.Enabled = False
            Me.btGrabar.Enabled = False
            Me.btNuevo.Enabled = False
            Me.btImprimir.Enabled = False
            'Me.'txtNotasIngr.Enabled = False
            Me.tbSubjetivo.Enabled = False
            Me.tbObjetivo.Enabled = False
            Me.tbParaclinicos.Enabled = False
            Me.tbPlanManejo.Enabled = False
            'Me.'tbDiagnostico.Enabled = False
            'Me.'Txtinterconsulta.Enabled = False
            'Me.'tbDiagnostico.Enabled = False
        End If
    End Sub
#End Region



    Private Sub dtgEvolucion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgEvolucion.Click
        If dtgEvolucion.DataSource Is Nothing Then
            Exit Sub
        Else
            If dtgEvolucion.DataSource.Rows.Count <= 0 Then
                Exit Sub
            End If
        End If
        EditarDatosEvolucion(sender.CurrentRow)
    End Sub



    Private Sub btNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNuevo.Click
        Me.LimpiarPantalla()
        Dim dtFecha As Date
        dtFecha = FuncionesGenerales.FechaServidor()
        Me.PFecha.Enabled = False
        'Me.'mtFechaInicial.Text = Format(dtFecha, "dd/MM/yyyy")
        'Me.'tbHora.Text = Hour(dtFecha)
        'Me.'tbMinuto.Text = Minute(dtFecha)
        Me.tmHoraEvolucion.Interval = (60 - Second(dtFecha)) * 1000
        Me.tmHoraEvolucion.Enabled = True
        Me.dtgEvolucion.Enabled = False
        Me.btImprimir.Enabled = False
        Me.btNuevo.Enabled = False
        Me.dtgEvolucion.Enabled = True
        txtPlanManejogotfocus = False ''Claudia Garay Enero 17 de 2011
        'txtNotasIngr.Focus()
        resPre1 = ""
        resPre2 = ""
        modPlanManj = ""
        rdPlaManPrg1Si.Checked = False
        rdPlaManPrg1No.Checked = False
        rdPlaManPrg2Si.Checked = False
        rdPlaManPrg2No.Checked = False
        RbEvolucion.Enabled = True
        Rbinterconsulta.Enabled = True
        rbIngreso.Enabled = True
        'Me.'txtNotasIngr.Enabled = True
        'Me.'tbDiagnostico.Enabled = True

        'martovar 2014-09-19 se agrega validacion en caso de que el medico tenga especialidad Medicina General 2.9.0
        If objGeneral.CodigoEspecialidad = "001" Or objGeneral.CodigoEspecialidad = "003" Or objGeneral.CodigoEspecialidad = "004" Or objGeneral.CodigoEspecialidad = "0028" Or objGeneral.CodigoEspecialidad = "069" Or objGeneral.CodigoEspecialidad = "083" Or objGeneral.CodigoEspecialidad = "704" Or objGeneral.CodigoEspecialidad = "705" Or objGeneral.CodigoEspecialidad = "901" Or objGeneral.CodigoEspecialidad = "903" Then
            Me.Rbinterconsulta.Enabled = False
        End If

    End Sub


    Private Sub btImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btImprimir.Click
        'ImprimirReporte(Format(CDate('Me.'mtFechaInicial.Text), "yyyy/MM/dd"), 'Me.'tbHora.Text, 'Me.'tbMinuto.Text, "")
        Me.btNuevo.Enabled = True
    End Sub

    Private Sub tbPlanManejo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbPlanManejo.GotFocus
        If txtPlanManejogotfocus = False Then
            txtPlanManejogotfocus = True
            If tbPlanManejo.Text = "" Then
                ''Claudia Garay 9 de diciembre. Se modifica mensaje.
                Dim msg As String = "Registre además del plan de manejo en este campo si el paciente necesita algún plan de egreso."
                MsgBox(msg, MsgBoxStyle.Information, "Historia Clinica Medica")
            End If
        End If
    End Sub


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


    Private Sub rdPlaManPrg2Si_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdPlaManPrg2Si.Click
        If rdPlaManPrg2Si.Checked = True Then
            resPre2 = "S"
        End If
    End Sub

    Private Sub rdPlaManPrg2No_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdPlaManPrg2No.Click
        If rdPlaManPrg2No.Checked = True Then
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
            'If Len('txtNotasIngr.Text) > 0 Or Len(tbSubjetivo.Text) > 0 _
            'Or Len(tbObjetivo.Text) > 0 Or Len(tbParaclinicos.Text) > 0 _
            'Or Len(tbPlanManejo.Text) > 0 Or Len('tbDiagnostico.Text) > 0 Then

            If Len(tbObjetivo.Text) > 0 Or Len(tbParaclinicos.Text) > 0 _
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
        pnlContenedor.Height = 1500

        Me.pnlContenedor.Controls.Add(ctlDescrQx)

        ctlDescrQx.Show()


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

        ''Evolucion

        pnlContenedor.Height = 900

        pnlContEvolucion.Visible = True
        ctlDescrQx.Visible = False


    End Sub


    Private Sub Rbinterconsulta_Click(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles Rbinterconsulta.Click
        If Rbinterconsulta.Checked = True Then
            Dim var As String
            Dim var1 As String


            var = objEvolucion1.consultarMedicoTratante(objConexion, objGeneral.Prestador, objGeneral.Sucursal, _
                              objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision, objGeneral.Login, objGeneral.CodigoEspecialidad)

            If var = "NO" Then
                MsgBox("El medico tratante del paciente no puede generar una interconsulta")
                objEvolucion.Objetivo = ""
                objEvolucion.Diagnostico = ""
                objEvolucion.Paraclinico = ""
                objEvolucion.PlanManejo = ""
                objEvolucion.Subjetivo = ""
                objEvolucion.Fecha = ""
                objEvolucion.NotasIngreso = ""
                MostrarEvolucion()
                'Me.'Txtinterconsulta.Visible = False
                Me.Label1.Visible = False
                RbEvolucion.Checked = True
                Rbinterconsulta.Checked = False
            Else
                var1 = objEvolucion1.consultarEspecialidadInterconsulta(objConexion, objGeneral.Prestador, objGeneral.Sucursal, _
                            objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision, objGeneral.Login, objGeneral.CodigoEspecialidad)
                If var1 = "SI" Then
                    'Me.'Txtinterconsulta.Text = ""
                    objEvolucion.Objetivo = ""
                    objEvolucion.Diagnostico = ""
                    objEvolucion.Paraclinico = ""
                    objEvolucion.PlanManejo = ""
                    objEvolucion.Subjetivo = ""
                    objEvolucion.Fecha = ""
                    objEvolucion.NotasIngreso = ""
                    MostrarInterconsulta()
                    'Me.'Txtinterconsulta.Visible = True
                Else
                    'If var1 = "NO" Then
                    '    strmedico = ""
                    '    strmotivo = ""
                    '    strEspecialidad = ""
                    '    Dim frminterconsulta As New frmc_Interconsulta(strmedico, strmotivo)
                    '    frminterconsulta.ShowDialog()
                    '    strmedico = frminterconsulta.strMedico
                    '    strmotivo = frminterconsulta.StrMotivo
                    '    strEspecialidad = frminterconsulta.strEspecialidad
                    '    'Me.'Txtinterconsulta.Text = ""
                    '    objEvolucion.Objetivo = ""
                    '    objEvolucion.Diagnostico = ""
                    '    objEvolucion.Paraclinico = ""
                    '    objEvolucion.PlanManejo = ""
                    '    objEvolucion.Subjetivo = ""
                    '    objEvolucion.Fecha = ""
                    '    objEvolucion.NotasIngreso = ""
                    '    MostrarInterconsulta()
                    '    'Me.'Txtinterconsulta.Visible = True
                    'End If
                End If
            End If
        End If
    End Sub


#Region "AdicionarFila - Grilla - GrabarDiagnostico"
    Private Sub btAgregarEvo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If ValidarCamposObligatoriosEvo(gbAgregarEvo) = False Then
            MessageBox.Show("Falta Información en Campo Obligatorio")
            Exit Sub
        End If

        If Len(strDatoModificadoEvo) = 0 Then
            AdicionarNuevoDiagnosticoEvo()
        Else
            ModificarDiagnosticoEvo(dgListaEvo.CurrentRow)
        End If
        strDatoModificadoEvo = ""
    End Sub
#End Region

#Region "Funciones Comunes Procesos evolucion"

    Private Function ValidarCamposObligatoriosEvo(ByVal ctlContenedor As GroupBox) As Boolean
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
    ''' Agrega Nuevo registro en el Grid y Graba Diagnostico en la BD
    ''' </summary>
    ''' <remarks></remarks>
#Region "Adicionar Nuevo Diagnostico evo"

    Private Sub AdicionarNuevoDiagnosticoEvo()

        Dim dtTable As New DataTable
        dtTable = dgListaEvo.DataSource

        Dim strError As String = ""
        Dim bExiste As Boolean = True

        'Verificar datos 
        If tbDesTipoDiagEvo.Text = "" Then
            strError = strError & "- Tipo de Diagnóstico" & Chr(13)
        End If
        If tbDesCategoriaEvo.Text = "" Then
            strError = strError & "- Categoría" & Chr(13)
        End If

        'Adicionar Nuevo Registro a la Grilla 
        If strError.Trim.Length = 0 Then
            If VerificarDiagnosticoEvo(-1) Then
                Dim dtRow As DataRow = dtTable.NewRow()
                Dim intorigen As Integer
                Dim strAntecedente As String
                Dim strConfidencial As String
                Dim intSecuencia As Integer
                Dim strClasi As String = ""

                intSecuencia = dtTable.Rows.Count + 1
                intorigen = cbDiagnosticoEvo.OrigenDeDatos.Rows.Count - 1

                If cbDiagnosticoEvo.Items.Count() > 0 Then
                    strClasi = cbDiagnosticoEvo.OrigenDeDatos.Rows(intorigen).Item("Clasificacion").ToString()
                End If

                If strClasi = "" Then
                    If Me.tbCodDiagEvo.Text <> "" Then
                        strClasi = cbDiagnosticoEvo.OrigenDeDatos.Rows(intorigen).Item("Clasificacion").ToString()
                    End If
                End If

                'If cbAgregarEvo.Checked = True Then
                '    strAntecedente = "S"
                'Else
                '    strAntecedente = "N"
                'End If
                'If ckConfidencialEvo.Checked = True Then
                '    strConfidencial = "S"
                'Else
                '    strConfidencial = "N"
                'End If

                'Grabar registro en la BD
                Dim objBl As New Sophia.HistoriaClinica.BL.BLEgresos
                Dim lError As Long
                Try
                    'lError = objBl.GrabarEgresoDiagnostico(objConexion, objGeneral.Prestador, _
                    '        objGeneral.Sucursal, objPaciente.TipoDocumento, objPaciente.NumeroDocumento, _
                    '        objPaciente.TipoAdmision, objPaciente.NumeroAdmision, objPaciente.AnoAdmision, _
                    '        "E", Trim(tbCodTipoDiagEvo.Text), Trim(tbCodDiagEvo.Text), strAntecedente, _
                    '        Trim(tbObservacionesEvo.Text), strConfidencial, strClasi, _
                    '        Trim(tbDesCategoriaEvo.Text), intSecuencia, 0, objGeneral.Login)
                Catch ex As Exception
                    MsgBox("El diagnostico no se grabó. " & ex.Message, MsgBoxStyle.Exclamation)
                    Exit Sub
                End Try
                If lError = 0 Then

                    dtRow("tip_admision_evo") = objPaciente.TipoAdmision.ToString()
                    dtRow("ano_adm_evo") = objPaciente.AnoAdmision.ToString()
                    dtRow("num_adm_evo") = objPaciente.NumeroAdmision.ToString()
                    dtRow("tip_diag_evo") = tbCodTipoDiagEvo.Text
                    dtRow("tDescripcion_evo") = tbDesTipoDiagEvo.Text
                    dtRow("diagnost_evo") = tbCodDiagEvo.Text
                    dtRow("descripcion_evo") = cbDiagnosticoEvo.Text
                    dtRow("clasificacion_evo") = strClasi
                    'dtRow("Obs_evo") = tbObservacionesEvo.Text
                    dtRow("Antecedente_evo") = strAntecedente
                    dtRow("confidencial_evo") = strConfidencial
                    dtRow("planManejo_evo") = ""
                    dtRow("secuencia_evo") = intSecuencia
                    dtRow("clase_diag_evo") = "E"
                    dtRow("categoria_diag_evo") = tbCodCategoriaEvo.Text
                    dtRow("fec_hc_evo") = ""
                    dtRow("CategoriaDes_evo") = tbDesCategoriaEvo.Text
                    dtRow("Nuevo_evo") = "N"

                    dtTable.Rows.Add(dtRow)
                    dgListaEvo.DataSource = dtTable
                    objGeneral.HistoriaClinicaTieneModificaciones = True
                Else
                    MsgBox("El diagnostico no se grabó", MsgBoxStyle.Exclamation)
                    bExiste = False
                End If
            Else
                MsgBox("el tipo de diagnóstico ya existe y/o la categoría principal, por favor seleccione otro", MsgBoxStyle.Information)
                bExiste = False
            End If

            If bExiste Then
                LimpiarDiagnosticoEvo()
            End If
        Else
            MsgBox("Por favor ingrese los siguientes datos :" & Chr(13) & strError, MsgBoxStyle.Information)
            Exit Sub
        End If

    End Sub

#End Region

    ''' <summary>
    ''' Validación de registro ya Ingresado sobbre el Grid
    ''' </summary>
    ''' <param name="intFila"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
#Region "VerificarDiagnostico_evo - Grilla"
    Private Function VerificarDiagnosticoEvo(ByVal intFila As Integer) As Boolean
        '// Verificar que el diagnostico no se haya adicionado o no se repita Principal
        Dim dtTable_evo As DataTable = New DataTable
        dtTable_evo = dgListaEvo.DataSource
        Dim FilaBuscada() As DataRow

        If intFila >= 0 Then
            Dim dtTableN As DataTable = New DataTable
            dtTableN = dtTable_evo.Clone()

            Dim dr As DataRow = dtTableN.NewRow()
            Dim j As Integer

            For j = 0 To dtTable_evo.Rows.Count - 1
                If j <> intFila Then
                    dtTableN.ImportRow(dtTable_evo.Rows(j))
                End If
            Next

            If tbCodCategoriaEvo.Text.Trim = "P" Then
                FilaBuscada = dtTableN.Select("categoria_diag_evo = 'P'")

                If FilaBuscada.Length = 0 Then
                    FilaBuscada = dtTableN.Select("tip_diag_evo='" & tbCodTipoDiagEvo.Text & "' and diagnost_Evo = '" & tbCodDiagEvo.Text & "'")
                End If
            Else
                FilaBuscada = dtTableN.Select("tip_diag=_evo'" & tbCodTipoDiagEvo.Text & "' and diagnost_evo = '" & tbCodDiagEvo.Text & "'")
            End If
        Else
            'dtTable.PrimaryKey = New DataColumn() {dtTable.Columns("CodTipoDiag"), dtTable.Columns("CodCategoria")}
            'FilaBuscada = dtTable.Rows.Find(arr)

            If tbCodCategoriaEvo.Text.Trim = "P" Then
                FilaBuscada = dtTable_evo.Select("categoria_diag_evo = 'P'")

                If FilaBuscada.Length = 0 Then
                    FilaBuscada = dtTable_evo.Select("tip_diag_Evo='" & tbCodTipoDiagEvo.Text & "' and diagnost_evo = '" & tbCodDiagEvo.Text & "'")
                End If

            Else
                FilaBuscada = dtTable_evo.Select("tip_diag_evo='" & tbCodTipoDiagEvo.Text & "' and diagnost_Evo = '" & tbCodDiagEvo.Text & "'")
            End If

        End If

        If FilaBuscada.Length = 0 Then
            VerificarDiagnosticoEvo = True
        Else
            VerificarDiagnosticoEvo = False
        End If
    End Function
#End Region

#Region "LimpiarDiagnostico"
    Private Sub LimpiarDiagnosticoEvo()
        tbCodTipoDiagEvo.ResetText()
        tbDesTipoDiagEvo.ResetText()
        tbCodCategoriaEvo.ResetText()
        tbDesCategoriaEvo.ResetText()
        tbCodDiagEvo.ResetText()
        cbDiagnosticoEvo.ResetText()
        'tbObservacionesEvo.ResetText()
        'cbAgregarEvo.Checked = False
        'ckConfidencialEvo.Checked = False
        tbCodDiagEvo.ResetText()
        cbDiagnosticoEvo.ResetText()
        strDatoModificadoEvo = ""
    End Sub
#End Region
    ''' <summary>
    ''' Modifica un Diagnostico Existente
    ''' </summary>
    ''' <param name="drFila"></param>
    ''' <remarks></remarks>
#Region "Modificar Diagnostico"

    Private Sub ModificarDiagnosticoEvo(ByVal drFila As DataGridViewRow)

        Dim intFila As Integer = dgListaEvo.CurrentRow.Index
        Dim dgR As DataGridViewRow = dgListaEvo.Rows(intFila)
        Dim strAntecedente As String
        Dim strConfidencial As String
        Dim intSecuencia As Integer
        Dim objBl As New Sophia.HistoriaClinica.BL.BLEgresos
        Dim lError As Long

        intSecuencia = CInt(drFila.Cells("secuencia_evo").Value)
        Dim strClasi As String = drFila.Cells("clasificacion_evo").Value

        '/- Actualizar Registro --
        'If cbAgregarEvo.Checked = True Then
        '    strAntecedente = "S"
        'Else
        '    strAntecedente = "N"
        'End If
        'If Me.ckConfidencialEvo.Checked = True Then
        '    strConfidencial = "S"
        'Else
        '    strConfidencial = "N"
        'End If
        Try
            'lError = objBl.GrabarEgresoDiagnostico(objConexion, objGeneral.Prestador, _
            '        objGeneral.Sucursal, objPaciente.TipoDocumento, objPaciente.NumeroDocumento, _
            '        objPaciente.TipoAdmision, objPaciente.NumeroAdmision, objPaciente.AnoAdmision, _
            '        "E", Trim(tbCodTipoDiagEvo.Text), Trim(tbCodDiagEvo.Text), strAntecedente, _
            '        Trim(tbObservacionesEvo.Text), strConfidencial, strClasi, _
            '        Trim(tbDesCategoriaEvo.Text), intSecuencia, 1, objGeneral.Login)
        Catch ex As Exception
            MsgBox("el El diagnóstico no se actualizó", MsgBoxStyle.Information)
            Exit Sub
        End Try

        If lError = 0 Then
            With dgR
                .Cells("tip_diag_evo").Value = tbCodTipoDiagEvo.Text
                .Cells("tDescripcion_evo").Value = tbDesTipoDiagEvo.Text
                .Cells("categoria_diag_evo").Value = tbCodCategoriaEvo.Text
                .Cells("CategoriaDes_evo").Value = tbDesCategoriaEvo.Text
                .Cells("diagnost_evo").Value = tbCodDiagEvo.Text
                .Cells("descripcion_evo").Value = cbDiagnosticoEvo.Text
                .Cells("clasificacion_evo").Value = strClasi
                '.Cells("Obs_evo").Value = tbObservacionesEvo.Text
                .Cells("Antecedente_evo").Value = strAntecedente
                .Cells("confidencial_evo").Value = strConfidencial


            End With
        Else
            MsgBox("el El diagnóstico no se actualizó", MsgBoxStyle.Information)
            Exit Sub
        End If

        LimpiarDiagnosticoEvo()

    End Sub
#End Region
    ''' <summary>
    ''' Carga los Controles de tipo ComboBox del Formulario
    ''' </summary>
    ''' <remarks></remarks>
#Region "CargarCombos"
    Private Sub CargarCombos()
        Dim obj As New Sophia.HistoriaClinica.BL.BLEgresos
        Dim objLocal As New Sophia.HistoriaClinica.BL.BLBasicasLocales
        '/// Llenamos los controles para las listas Inciales \\\
        '/ para los diagnósticos \
        tbDesTipoDiagEvo.NombreCampoDatos = "descripcion"
        tbCodTipoDiagEvo.NombreCampoBusqueda = "tip_diag"
        tbCodTipoDiagEvo.NombreCampoBuscado = "descripcion"
        tbCodTipoDiagEvo.ControlTextoEnlace = tbDesTipoDiagEvo
        tbDesTipoDiagEvo.ControlTextoEnlace = tbCodTipoDiagEvo
        'tbDesTipoDiag.OrigenDeDatos = obj.ConsultarTiposDiagnostico
        tbDesTipoDiagEvo.OrigenDeDatos = objLocal.TraerDatosTablasBasicasLocales(strCadenaLocal, "hctipdiag", "tip_diag,descripcion", "")
        tbDesTipoDiagEvo.CargarDatosDescripcion()

        '/ para las categorías \
        tbDesCategoriaEvo.NombreCampoDatos = "Descripcion"
        tbCodCategoriaEvo.NombreCampoBusqueda = "Categoria_diag"
        tbCodCategoriaEvo.NombreCampoBuscado = "Descripcion"
        tbCodCategoriaEvo.ControlTextoEnlace = tbDesCategoriaEvo
        tbDesCategoriaEvo.ControlTextoEnlace = tbCodCategoriaEvo
        tbDesCategoriaEvo.OrigenDeDatos = obj.ConsultarCategorias
        tbDesCategoriaEvo.CargarDatosDescripcion()

        '/ para los diagnósticos \
        tbCodDiagEvo.ControlComboEnlace = cbDiagnosticoEvo
        cbDiagnosticoEvo.CampoMostrar = "descripcion"
        cbDiagnosticoEvo.ControlTextoEnlace = tbCodDiagEvo
        cbDiagnosticoEvo.CampoEnlazado = "codigo"
        cbDiagnosticoEvo.CategoriaDatos = CategoriaDatos.Diagnosticos
        cbDiagnosticoEvo.Login = objGeneral.Login
        cbDiagnosticoEvo.SexoPaciente = objPaciente.Genero
        cbDiagnosticoEvo.EdadPaciente = objPaciente.Edad
        cbDiagnosticoEvo.CargarDatos()
        cbDiagnosticoEvo.CargarButton()


        obj = Nothing
        objLocal = Nothing

    End Sub
#End Region
#Region "AsignarDatosIniciales-Load"
    Private Sub DatosIniciales()

        CargarCombos()
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
            .Columns.Add("planManejo_Evo", System.Type.GetType("System.String"))
            .Columns.Add("secuencia_evo", System.Type.GetType("System.String"))
            .Columns.Add("clase_diag_evo", System.Type.GetType("System.String"))
            .Columns.Add("categoria_diag_evo", System.Type.GetType("System.String"))
            .Columns.Add("fec_hc_evo", System.Type.GetType("System.String"))
            .Columns.Add("CategoriaDes_evo", System.Type.GetType("System.String"))
            .Columns.Add("Nuevo_evo", System.Type.GetType("System.String"))
        End With
        dgListaEvo.DataSource = dtTable

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
            dtDiagnostico = objBl.ConsultarDiagnosticoReingreso_evo(objGeneral.Prestador, objGeneral.Sucursal, _
                                    objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision, _
                                    "E", objGeneral.Login, objConexion)


        Catch ex As Exception
            MsgBox("Error al consultar datos", MsgBoxStyle.Exclamation)
        End Try
        If dtDiagnostico.Rows.Count > 0 Then
            dgListaEvo.DataSource = dtDiagnostico

            objEvolucion.dtDiagnosticoEvo = dtDiagnostico

            For i = 0 To dtDiagnostico.Rows.Count - 1
                dtDiagnostico.Rows(i).Item("secuencia_evo") = i
            Next

        End If
    End Sub
#End Region
#Region "EditarFila - Grilla Evolucion"

    Private Sub EditarDatosDiagnosticoEvo(ByVal dr As DataGridViewRow)

        tbCodTipoDiagEvo.Text = dr.Cells("tip_diag_evo").Value.ToString()
        tbDesTipoDiagEvo.Text = dr.Cells("tDescripcion_evo").Value.ToString()
        tbCodCategoriaEvo.Text = dr.Cells("categoria_diag_evo").Value.ToString()
        tbDesCategoriaEvo.Text = dr.Cells("CategoriaDes_evo").Value.ToString()
        tbCodDiagEvo.Text = dr.Cells("diagnost_evo").Value.ToString()
        cbDiagnosticoEvo.Text = dr.Cells("descripcion_evo").Value.ToString()
        '        tbObservacionesEvo.Text = dr.Cells("Obs_evo").Value.ToString

        'If dr.Cells("Antecedente_evo").Value.ToString() = "S" Then
        '    cbAgregarEvo.Checked = True
        'Else
        '    cbAgregarEvo.Checked = False
        'End If

        'If dr.Cells("confidencial_evo").Value.ToString() = "S" Then
        '    ckConfidencialEvo.Checked = True
        'Else
        '    ckConfidencialEvo.Checked = False
        'End If
        strDatoModificadoEvo = ""

    End Sub

    Private Sub dgListaEvo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)

        If dgListaEvo.DataSource Is Nothing Then
            Exit Sub
        Else
            If dgListaEvo.DataSource.Rows.Count <= 0 Then
                Exit Sub
            Else
                EditarDatosDiagnosticoEvo(sender.CurrentRow)


                tbCodTipoDiagEvo.Enabled = False
                tbDesTipoDiagEvo.Enabled = False
                tbCodCategoriaEvo.Enabled = False
                tbDesCategoriaEvo.Enabled = False
                tbCodDiagEvo.Enabled = False
                cbDiagnosticoEvo.Enabled = False
                strDatoModificadoEvo = "EG"
                '                tbObservacionesEvo.Focus()
            End If
        End If
    End Sub



    Private Sub tbCodTipoDiagEvo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)

        If dgListaEvo.DataSource Is Nothing Then
            Exit Sub
        Else
            LimpiarDiagnosticoEvo()
            tbCodTipoDiagEvo.Focus()
        End If
    End Sub

#End Region




    Private Sub dgListaEvo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If dgListaEvo.DataSource Is Nothing Then
            Exit Sub
        Else
            If dgListaEvo.DataSource.Rows.Count <= 0 Then
                Exit Sub
            End If
        End If
        EditarDatosDiagnosticoEvo(sender.CurrentRow)
        tbCodTipoDiagEvo.Enabled = True
        tbDesTipoDiagEvo.Enabled = True
        tbCodCategoriaEvo.Enabled = True
        tbDesCategoriaEvo.Enabled = True
        tbCodDiagEvo.Enabled = True
        cbDiagnosticoEvo.Enabled = True
    End Sub

#Region "Eliminar Fila Grilla evo"

    Private Sub dgListaEvo_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs)

        'If NVL(e.Row.Cells("Nuevo").Value) = "N" Then
        If MessageBox.Show("Esta Seguro de Borrar este Registro?", "Evolución", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            EliminarDiagnosticoEvo(e.Row)
        Else
            e.Cancel = True
        End If

        tbCodTipoDiagEvo.Focus()
    End Sub
#End Region

#Region "Eliminar Diagnostico evo"
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
            lError = objBl.GrabarEgresoDiagnostico(objConexion, strCodPreSgs, strCodSucur, _
                            strTipDoc, strNumDoc, strTipAdm, dblNumAdm, intAnoAdm, strClaseDiag, _
                            strTipDiag, strDiagnostico, strAntecedente, strObservaciones, strConfidencial, _
                            strClasificacion, strCategoria, intSecuencia, intAccion, objGeneral.Login)

            If lError <> 0 Then
                MessageBox.Show("Error al eliminar el diagnóstico evolucion")
            Else

                LimpiarDiagnosticoEvo()
            End If
        Catch ex As Exception
            MessageBox.Show("Error al eliminar el diagnóstico")
        End Try

    End Sub
#End Region

    Private Sub BtnRptCuidadoPaliativo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRptCuidadoPaliativo.Click
        Try
            frmRepCuidadosPaliativos.Show()
            frmRepCuidadosPaliativos.imprimirCuidadosPaliativos(objConexion, objGeneral.Prestador, _
            objGeneral.Sucursal, objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision, _
            objPaciente.TipoDocumento, objPaciente.NumeroDocumento)
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub


    Private Sub RbEvolucion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbEvolucion.CheckedChanged
        If RbEvolucion.Checked Then
            lblTitEvolucion.Text = "Evolución"
            IniciarEvolucion()
            grpCerrarInterconsulta.Visible = False
            pnlEvolucion.Visible = True
        End If
    End Sub

    'Private Sub 'txtNotasIngr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    'End Sub

    Private Sub rbIngreso_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbIngreso.CheckedChanged
        If rbIngreso.Checked Then
            lblTitEvolucion.Text = "Ingreso"
            IniciarEvolucion()
            grpCerrarInterconsulta.Visible = False
            pnlEvolucion.Visible = True
        End If
    End Sub

    Private Sub Rbinterconsulta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rbinterconsulta.CheckedChanged
        If Rbinterconsulta.Checked Then
            lblTitEvolucion.Text = "Interconsulta"
            IniciarEvolucion()
            grpCerrarInterconsulta.Visible = True
            pnlEvolucion.Visible = True

        End If
    End Sub
End Class
