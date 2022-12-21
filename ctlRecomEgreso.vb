Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports System.Collections.Generic
Imports System.Data.Common
Imports objGenerales = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales



''' <summary>
''' Clase ctlRecomEgreso del namespace Sophia.HistoriaClinica.ctlRecomEgreso que 
''' es la clase base. Esta clase tiene la funcionalidad del control de usuario para 
''' las recomendaciones al egreso y será usado en la aplicación cliente en Windows Form 2005
''' </summary>
''' <remarks></remarks>
Public Class ctlRecomEgreso

    Private Shared _Instancia As ctlRecomEgreso
    Private objConexion As Conexion
    Private objRecomendacion As RecomEgreso
    Private objGeneral As Generales
    Private objPaciente As Paciente
    Private dtFecha As String
    Private objIncapacidad As PlanIncapacidad
    Private m_strVerEstado As String
    Private m_strEstado As String
    Private obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
    Private DAOGPM As New Sophia.HistoriaClinica.DAO.GPMData
    Private objBasicas As New BLBasicasGenerales

    Private _plstDiagnostico As New List(Of Diagnostico)
    Public Property plstDiagnostico As List(Of Diagnostico)
        Get
            Return _plstDiagnostico
        End Get
        Set(ByVal Value As List(Of Diagnostico))
            _plstDiagnostico = Value
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


#Region "Instancia de Control"
    Public Shared ReadOnly Property Instancia() As ctlRecomEgreso
        Get
            If _Instancia Is Nothing Then
                _Instancia = New ctlRecomEgreso
            End If
            Return _Instancia
        End Get
    End Property
#End Region

    ''' <summary>
    ''' Ejecuta el Método AdicionarValeresObjeto
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
#Region "Salir"

    Private Sub ctlRecomEgreso_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click

        TxtScroll1.Visible = True
        TxtScroll1.Focus()
        TxtScroll1.Visible = False

    End Sub
    Private Sub ctlRecomEgreso_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
        FinalizarRecomendacionesEgreso()
        'If Reimpresion() = False Then
        '    If objRecomendacion.Estado = "G" Then
        '        objRecomendacion.Estado = "D"
        '    Else
        '        objRecomendacion.Estado = "M"
        '    End If
        'End If
    End Sub
#End Region

    ''' <summary>
    ''' Ejecuta todas la Opciones necesarias para el Cargue del Control ctlRecomEgreso
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
#Region "Load"

    Private Sub ctlRecomEgreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        frmHistoriaPrincipal.blnFirstRecomEgreso = False

        objConexion = Conexion.Instancia
        objRecomendacion = RecomEgreso.Instancia
        objGeneral = Generales.Instancia
        objPaciente = Paciente.Instancia

        If objPaciente.TipoAdmision = "E" Then
            TxtDias.Visible = True
            Label1.Visible = True


        End If

        IniciarRecomendacionesEgreso()
        CargarGrillaProgramas()
        ConfigurarSegunPais()
    End Sub
    Private Sub CargarGrillaProgramas()
        Dim BlManejo As New BLPlanManejo
        Dim dtmanejo As DataTable

        dtmanejo = BlManejo.TraeProgramasEducacion(objConexion, objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision, "", objGeneral.Login, "", 1)
        dtgPrograma.DataSource = dtmanejo

    End Sub

    Private Sub IniciarRecomendacionesEgreso()
        Dim objBl As New Sophia.HistoriaClinica.BL.BLPlanManejo
        Dim objBlEgres As New Sophia.HistoriaClinica.BL.BLEgresos
        Dim dtdiagnosticoE As DataTable
        objIncapacidad = PlanIncapacidad.Instancia

        'verificar si ya se grabó
        Dim lError As Long
        If objRecomendacion Is Nothing Or objRecomendacion.Estado = "" Then
            Try
                lError = objBl.ConsultarRecomendacionEgreso(objConexion, objRecomendacion)
            Catch ex As Exception
                MsgBox("Error al consultar datos", MsgBoxStyle.Exclamation)
                Exit Sub
            End Try
        End If

        loadDiagnosticos()

        dtFecha = Format(FuncionesGenerales.FechaServidor(), objGeneral.FormatoFechaCorta)
        tbSignos.Text = objRecomendacion.SignosAlarma
        If objRecomendacion.SignoCalor = True Then
            ckCalor.Checked = True
        End If
        If objRecomendacion.SignoEnrojecimiento = True Then
            ckEnrojecimiento.Checked = True
        End If
        If objRecomendacion.SignoFiebre = True Then
            ckFiebre.Checked = True
        End If
        If objRecomendacion.SignoSecrecion = True Then
            ckSecrecion.Checked = True
        End If

        tbActividad.Text = objRecomendacion.ActividadFisica
        tbNutricionales.Text = objRecomendacion.RecomendacionNutricional
        tbGenerales.Text = objRecomendacion.RecomendacionGeneral
        tbResultado.Text = objRecomendacion.ResultadoDiagnostico
        tbIncapacidad.Text = objRecomendacion.Incapacidad
        mkFechaControl.Text = objRecomendacion.FechaControl
        tbLugar.Text = objRecomendacion.LugarControl
        tbTelefono.Text = objRecomendacion.TelefonoMedico
        tbIncapacidad.Text = objIncapacidad.Cantidad
        objRecomendacion.Incapacidad = objIncapacidad.Cantidad

        Try
            If objBlEgres.ValidarConciliacionMedicamentos(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision, objConexion) = 0 Then
                objRecomendacion.ConciliacionMedicamentos = "S"
            Else
                objRecomendacion.ConciliacionMedicamentos = "N"
            End If
        Catch ex As Exception
            MsgBox("Error al validar conciliación medicamentos ", MsgBoxStyle.Exclamation)
        End Try

        ''cpgaray Conciliacion de medicamentos febrero 27 2012
        If objRecomendacion.ConciliacionMedicamentos = "S" Then
            rdConciliaMedSi.Checked = True
            rdConciliaMedNo.Checked = False
        ElseIf objRecomendacion.ConciliacionMedicamentos = "N" Then
            rdConciliaMedNo.Checked = True
            rdConciliaMedSi.Checked = False
        Else
            rdConciliaMedNo.Checked = False
            rdConciliaMedSi.Checked = False
        End If

        rdConciliaMedSi.Enabled = False
        rdConciliaMedNo.Enabled = False

        ''fin cpgaray 

        If Len(objRecomendacion.FechaControl) > 0 Then
            mkFechaControl.Enabled = False
            TxtDias.Enabled = False
        End If
        If Len(objRecomendacion.LugarControl) > 0 Then
            tbLugar.Enabled = False
        End If
        If Len(objRecomendacion.TelefonoMedico) > 0 Then
            tbTelefono.Enabled = False
        End If
        tbSignos.Focus()

        ActualizarInformacionControles()
        ''Cargar programas de educacion. Acreditacion diciembre 9 de 2010
        cargaProgramas()

        If objRecomendacion.Estado = "G" Or objRecomendacion.Estado = "M" Then
            Invalidar()
        End If
    End Sub

    Private Sub loadDiagnosticos()
        Dim oDiagnostico As New Diagnostico '= Diagnostico.Instancia
        Dim lError As Long
        Dim i As Integer = 0

        Try
            oDiagnostico.COD_PRE_SGS = objGeneral.Prestador
            oDiagnostico.COD_SUCUR = objGeneral.Sucursal
            oDiagnostico.TIP_ADMISION = objPaciente.TipoAdmision
            oDiagnostico.ANO_ADM = objPaciente.AnoAdmision
            oDiagnostico.NUM_ADM = objPaciente.NumeroAdmision
            oDiagnostico.CLASE_DIAG = FuncionesGenerales.EnumDescription(Diagnostico.ClaseDiagnostico.Egreso)

            plstDiagnostico = oDiagnostico.getDiagnostico(objConexion, lError, oDiagnostico)

        Catch ex As Exception
            MsgBox("Error al consultar los Diagnósticos", MsgBoxStyle.Exclamation)
            Exit Sub
        End Try
        If plstDiagnostico.Count > 0 Then
            dtgDiagnost.DataSource = plstDiagnostico

            For Each row As DataGridViewRow In dtgDiagnost.Rows
                If row.Cells("IDESTADODIAGNOSTICO").Value <> 1 Then
                    'row.DataGridView.RowsDefaultCellStyle.BackColor = Color.Blue
                    dtgDiagnost.Rows(i).DefaultCellStyle.ForeColor = Color.Gray
                End If
                row.Cells("SECUENCIA").Value = i
                i += 1
            Next
        End If
    End Sub


    Private Sub FinalizarRecomendacionesEgreso()
        AdicionarValeresObjeto()
    End Sub
#End Region

    ''' <summary>
    ''' Ejecuta el el Método GrabarRecomendacionEgreso y hace la validaciones previas
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>


    ''' <summary>
    ''' Imprime y Reimprime el  Reporte RepRecomendacionEgreso Según la Opcion Digitada
    ''' </summary>
    ''' <remarks></remarks>
#Region "ImprimirReporte"
    Public Sub ImprimirReporte(ByVal blnReimpresion As Boolean)
        Dim objDatosGenerales As objGenerales.Generales

        objDatosGenerales = objGenerales.Generales.Instancia

        If objDatosGenerales.Pais = "482" Then ''Peru 
            frmRepRecomendacionEgreso.Show()
            frmRepRecomendacionEgreso.imprimirRepRecomendacionEgreso(objGeneral.Prestador, objGeneral.Sucursal,
                                                            objPaciente.TipoDocumento, objPaciente.NumeroDocumento,
                                                            objPaciente.TipoAdmision, objPaciente.AnoAdmision,
                                                            objPaciente.NumeroAdmision, objRecomendacion, blnReimpresion)
        Else
            '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
            'Juan Carlos Jaramillo Lozano - IG
            RptHC_Enf_Med.Show()
            RptHC_Enf_Med.ImprimirHistoriaClinica_Recomendacion(objConexion, "52", objGeneral.Prestador,
                                                                              objGeneral.Sucursal, objPaciente.TipoDocumento,
                                                                               objPaciente.NumeroDocumento, objPaciente.TipoAdmision,
                                                                              objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                                                objPaciente.CodHistoria)
            '2019-03-11 Fin
        End If


    End Sub

#End Region

    ''' <summary>
    ''' Adiciona los valores registrados al Objeto objRecomendacion
    ''' </summary>
    ''' <remarks></remarks>
#Region "AdicionarValoresObjeto"
    Private Sub AdicionarValeresObjeto()
        objRecomendacion.SignosAlarma = Trim(tbSignos.Text)
        If ckFiebre.Checked Then
            objRecomendacion.SignoFiebre = True
        Else
            objRecomendacion.SignoFiebre = False
        End If
        If ckEnrojecimiento.Checked Then
            objRecomendacion.SignoEnrojecimiento = True
        Else
            objRecomendacion.SignoEnrojecimiento = False
        End If
        If ckCalor.Checked Then
            objRecomendacion.SignoCalor = True
        Else
            objRecomendacion.SignoCalor = False
        End If
        If ckSecrecion.Checked Then
            objRecomendacion.SignoSecrecion = True
        Else
            objRecomendacion.SignoSecrecion = False
        End If
        objRecomendacion.ActividadFisica = Trim(tbActividad.Text)
        objRecomendacion.RecomendacionNutricional = Trim(tbNutricionales.Text)
        objRecomendacion.RecomendacionGeneral = Trim(tbGenerales.Text)
        objRecomendacion.ResultadoDiagnostico = Trim(tbResultado.Text)
        objRecomendacion.LugarControl = Trim(tbLugar.Text)
        objRecomendacion.TelefonoMedico = Trim(tbTelefono.Text)
        If Me.mkFechaControl.Text.Length = 10 Then
            objRecomendacion.FechaControl = Trim(mkFechaControl.Text)
        Else
            objRecomendacion.FechaControl = ""
        End If
    End Sub
#End Region

    ''' <summary>
    ''' Validaciones Necesarias a los controles ckFiebre, ckCalor, ckEnrojecimiento, ckSecrecion, mkFechaControl
    ''' Control para el manejo de Fechas 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
#Region "ValidarControles "

    Private Sub ckFiebre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckFiebre.CheckedChanged
        ckCalor.Focus()
    End Sub

    Private Sub ckCalor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckCalor.CheckedChanged
        ckEnrojecimiento.Focus()
    End Sub
    Private Sub ckEnrojecimiento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckEnrojecimiento.CheckedChanged
        ckSecrecion.Focus()
    End Sub
    Private Sub ckSecrecion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckSecrecion.CheckedChanged
        tbActividad.Focus()
    End Sub

    Private Sub mkFechaControl_TypeValidationCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.TypeValidationEventArgs)
        If mkFechaControl.Text.Length = 10 Then
            If IsDate(mkFechaControl.Text) Then
                If CDate(mkFechaControl.Text) < CDate(dtFecha) Then
                    MsgBox("La fecha de control no debe ser inferior a la actual", MsgBoxStyle.Exclamation)
                    e.Cancel = False
                    mkFechaControl.Focus()
                Else
                    objRecomendacion.FechaControl = mkFechaControl.Text
                    If objPaciente.TipoAdmision = "E" Then
                        TraerDisponibilidadCitasMedico()
                    End If
                End If

            Else
                MsgBox("La fecha de control no es correcta", MsgBoxStyle.Exclamation)
                e.Cancel = False
                mkFechaControl.Focus()
            End If
        End If

    End Sub

    Private Sub ActualizarInformacionControles()
        tbSignos.Tag = tbSignos.Text
        tbActividad.Tag = tbActividad.Text
        tbIncapacidad.Tag = tbIncapacidad.Text
        tbNutricionales.Tag = tbNutricionales.Text
        tbGenerales.Tag = tbGenerales.Text
        tbResultado.Tag = tbResultado.Text
        mkFechaControl.Tag = mkFechaControl.Text
        tbLugar.Tag = tbLugar.Text
        tbTelefono.Tag = tbTelefono.Text
        ckFiebre.Tag = ckFiebre.Checked
        ckCalor.Tag = ckCalor.Checked
        ckEnrojecimiento.Tag = ckEnrojecimiento.Checked
        ckSecrecion.Tag = ckSecrecion.Checked
    End Sub

#End Region

    ''' <summary>
    ''' Métodos Necesarios de control de la navegacion en el Formulario
    ''' </summary>
    ''' <remarks></remarks>
#Region "Navegabilidad"

    Public Sub New()
        MyBase.New()
        Dim Ctrl As Control
        InitializeComponent()
        For Each Ctrl In Me.Controls
            If TypeOf Ctrl Is CheckBox Then
                AddHandler Ctrl.KeyPress, AddressOf KeyPressed
            End If
            If TypeOf Ctrl Is TextBox Then
                AddHandler Ctrl.KeyPress, AddressOf KeyPressed
            End If
        Next

    End Sub

    Private Sub RevisarControles(ByRef CtrlOrigen As Control)
        Dim Ctrl As Control
        For Each Ctrl In CtrlOrigen.Controls
            If TypeOf Ctrl Is CheckBox Then
                AddHandler Ctrl.KeyPress, AddressOf KeyPressed
            End If
            If TypeOf Ctrl Is TextBox Then
                AddHandler Ctrl.KeyPress, AddressOf KeyPressed
            End If
        Next
    End Sub

    Private Sub KeyPressed(ByVal o As [Object], ByVal e As KeyPressEventArgs)
        Select Case e.KeyChar
            Case Convert.ToChar(Keys.Return)
                SendKeys.Send("{TAB}")
                e.Handled = True
        End Select
    End Sub

    Private Sub mkFechaControl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Sub Invalidar()
        'tbActividad.ReadOnly = True
        'tbGenerales.ReadOnly = True
        'tbIncapacidad.ReadOnly = True
        'tbLugar.ReadOnly = True
        'tbNutricionales.ReadOnly = True
        'tbResultado.ReadOnly = True
        'tbSignos.ReadOnly = True
        'tbTelefono.ReadOnly = True
        'ckCalor.Enabled = False
        'ckEnrojecimiento.Enabled = False
        'ckFiebre.Enabled = False
        'ckSecrecion.Enabled = False
        'mkFechaControl.Enabled = False
        PGrabar.Enabled = True
    End Sub

    Private Function Reimpresion() As Boolean

        If tbActividad.Text <> tbActividad.Tag Then
            Reimpresion = False
            Exit Function
        End If
        If tbGenerales.Text <> tbGenerales.Tag Then
            Reimpresion = False
            Exit Function
        End If
        If tbIncapacidad.Text <> tbIncapacidad.Tag Then
            Reimpresion = False
            Exit Function
        End If
        If tbLugar.Text <> tbLugar.Tag Then
            Reimpresion = False
            Exit Function
        End If
        If tbNutricionales.Text <> tbNutricionales.Tag Then
            Reimpresion = False
            Exit Function
        End If
        If tbResultado.Text <> tbResultado.Tag Then
            Reimpresion = False
            Exit Function
        End If
        If tbSignos.Text <> tbSignos.Tag Then
            Reimpresion = False
            Exit Function
        End If
        If tbTelefono.Text <> tbTelefono.Tag Then
            Reimpresion = False
            Exit Function
        End If
        If ckCalor.Checked <> ckCalor.Tag Then
            Reimpresion = False
            Exit Function
        End If
        If ckEnrojecimiento.Checked <> ckEnrojecimiento.Tag Then
            Reimpresion = False
            Exit Function
        End If
        If ckFiebre.Checked <> ckFiebre.Tag Then
            Reimpresion = False
            Exit Function
        End If
        If ckSecrecion.Checked <> ckSecrecion.Tag Then
            Reimpresion = False
            Exit Function
        End If
        If mkFechaControl.Text <> mkFechaControl.Tag Then
            Reimpresion = False
            Exit Function
        End If

        Reimpresion = True
    End Function

#End Region

    Private Sub ctlRecomEgreso_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick

    End Sub




    Private Sub ctlRecomEgreso_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If sender.Visible = True Then
            LimpiarDatos()
            IniciarRecomendacionesEgreso()
            If frmHistoriaPrincipal.blnFirstRecomEgreso = True Then
                frmHistoriaPrincipal.blnFirstRecomEgreso = False
            End If
        Else
            FinalizarRecomendacionesEgreso()
        End If
    End Sub

    Private Sub LimpiarDatos()
        tbSignos.ResetText()
        ckFiebre.Checked = False
        ckCalor.Checked = False
        ckEnrojecimiento.Checked = False
        ckSecrecion.Checked = False
        tbActividad.ResetText()
        tbNutricionales.ResetText()
        tbGenerales.ResetText()
        tbResultado.ResetText()
        tbIncapacidad.ResetText()
        mkFechaControl.ResetText()
        tbLugar.ResetText()
        tbTelefono.ResetText()
        TxtDias.ResetText()
        mkFechaControl.ResetText()
        tbLugar.Enabled = True
        mkFechaControl.Enabled = True
        TxtDias.Enabled = True
    End Sub
    ''Claudia Garay 02 septiembre 2009
    Private Sub TraerDisponibilidadCitasMedico()

        Dim Fecha As Date
        Dim MIN As String
        Dim dt As DataTable
        Dim dtMed As DataTable
        Dim Citas As Long
        Dim dtset As DataSet
        Dim strcondicion As String
        Dim strFecha As String
        Dim des_sucursal As String
        Dim strHorainicial As Integer
        Dim strmininicial As Integer
        Dim strHoradispo As Integer
        Dim strmindispo As Integer
        Dim strHoraOportuna As Integer
        Dim strminOportuno As Integer
        Dim strtip_consultorio As String
        Dim consultorio As String
        Dim Strmensajecita As String
        Dim horario As String
        Dim Consecutivo As Integer
        Dim contador As Integer
        Dim lError As Integer
        Dim Datos() As Object = Nothing
        Dim DatosCita() As Object = Nothing


        horario = ""
        strcondicion = ""
        obj.paramsArray = Nothing

        'Consultamos si es medico familiar

        DatosCita = Nothing
        Datos = Nothing
        contador = 0


        ''Consultamos si el medico esta parametrizado como cronico
        dtMed = obj.EjecutarSQLConParametros("medcronico", objConexion, "medico", "medico='" & objGeneral.Login & "'")

        If dtMed.Rows.Count > 0 And objPaciente.Entidad = "9991" Then

            ''Consultamos la disponibilidad del medico para la fecha ingresada
            ReDim Datos(6)
            Datos(0) = objGeneral.Prestador
            Datos(1) = objGeneral.Sucursal
            ''Datos(2) = objGeneral.CodigoEspecialidad
            Datos(2) = objPaciente.Entidad
            Datos(3) = "M"
            Datos(4) = "G"
            Datos(5) = Format(CDate(mkFechaControl.Text), objGeneral.FormatoFechaCorta)
            Datos(6) = objGeneral.Login

            ''Traemos la disponibilidad del medico
            dt = obj.EjecutarSPConParametros("DB_TraerInfoOportunidadxraCitasNHC", objConexion, -1, Datos)

            If dt.Rows.Count = 0 Then

                MsgBox("No tiene citas disponibles para la fecha ingresada", MsgBoxStyle.Exclamation)

                Exit Sub
            Else

                'dia disponible por med
                strFecha = dt.Rows(0).Item("fecha").ToString
                des_sucursal = dt.Rows(0).Item("des_sucursal").ToString

                ''Hora y minuto inicial de la disponibilidad(sin tener en cuenta aun si ya
                ''se tomaron fechas de esa dispo
                strHorainicial = dt.Rows(0).Item("horaini")
                strmininicial = dt.Rows(0).Item("minini")

                ''hora disponible desde
                strHoradispo = dt.Rows(0).Item("hora")
                strmindispo = dt.Rows(0).Item("minuto")
                strtip_consultorio = dt.Rows(0).Item("tip_consultorio").ToString
                consultorio = dt.Rows(0).Item("consultorio").ToString


                If strHoradispo >= 12 And strmindispo >= 0 Then
                    horario = " PM"
                Else
                    horario = " AM"
                End If

                Fecha = strFecha

                ''Se debe consultar las citas, para esta especialidad, que el paciente tenga
                ''asignadas 15 dias antes y en adelante

                Citas = ConsultarCitasAsignadas(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoDocumento, objPaciente.NumeroDocumento, Format(DateAdd(DateInterval.Day, -15, Fecha), objGeneral.FormatoFechaCorta))

                If Citas = 1 Then
                    tbLugar.ResetText()
                    tbLugar.Enabled = False
                    mkFechaControl.ResetText()
                    mkFechaControl.Enabled = False
                    TxtDias.ResetText()
                    TxtDias.Enabled = False
                    Exit Sub

                End If

                If strmindispo < 10 Then
                    MIN = "0" & strmindispo
                Else
                    MIN = strmindispo
                End If

                If MsgBox("CITA OPORTUNA PARA EL: " & strFecha & " EN " & des_sucursal & " A LAS " & strHoradispo & ":" & MIN & horario & vbLf & _
                "DESEA ACEPTAR ESTA CITA? ", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then

                    ReDim DatosCita(21)
                    DatosCita(0) = objGeneral.Prestador
                    DatosCita(1) = objGeneral.Sucursal
                    DatosCita(2) = strtip_consultorio
                    DatosCita(3) = consultorio
                    DatosCita(4) = objPaciente.TipoDocumento
                    DatosCita(5) = objPaciente.NumeroDocumento
                    DatosCita(6) = Format(CDate(strFecha), objGeneral.FormatoFechaCorta)
                    DatosCita(7) = strHoradispo
                    DatosCita(8) = strmindispo
                    DatosCita(9) = strHorainicial
                    DatosCita(10) = strmininicial
                    DatosCita(11) = objPaciente.Entidad
                    DatosCita(12) = objGeneral.Login
                    DatosCita(13) = dt.Rows(0).Item("especialidad").ToString 'objGeneral.CodigoEspecialidad
                    DatosCita(14) = objPaciente.TipoAdmision
                    DatosCita(15) = objGeneral.Login
                    DatosCita(16) = objGeneral.Login
                    DatosCita(17) = Format(CDate(strFecha), objGeneral.FormatoFechaCorta)
                    DatosCita(18) = strHoraOportuna
                    DatosCita(19) = strminOportuno
                    DatosCita(20) = Consecutivo
                    DatosCita(21) = lError



                    Try

                        ''Almacena la cita de control
                        dtset = obj.EjecutarSPConParametrosDataSet("GrabaCitaControlHC", objConexion, -1, DatosCita)
                        If dtset.Tables.Count > 0 Then
                            Consecutivo = dtset.Tables(0).Rows(0).Item("Con_cita")
                        Else
                            Consecutivo = 0
                        End If

                    Catch ex As Exception

                        MsgBox("Error al grabar datos", MsgBoxStyle.Exclamation)
                        Exit Sub

                    End Try

                    If strmindispo < 10 Then
                        MIN = "0" & strmindispo
                    End If

                    Consecutivo = dtset.Tables(0).Rows(0).Item("Con_cita")
                    Strmensajecita = " CITA GENERADA PARA: " & objPaciente.PrimerNombre & " " & Trim(objPaciente.SegundoNombre) & " " & Trim(objPaciente.PrimerApellido) & " " & Trim(objPaciente.SegundoApellido) & vbLf & _
                    " EN : " & des_sucursal & vbLf & _
                    " EN LA FECHA :" & strFecha & " " & vbLf & _
                    " A LAS :" & strHoradispo & ":" & MIN & horario & vbLf & _
                    " CONSECUTIVO No :" & Consecutivo
                    mkFechaControl.Text = Format(CDate(strFecha))
                    tbLugar.Text = des_sucursal
                    tbLugar.Enabled = False
                    mkFechaControl.Enabled = False
                    TxtDias.Enabled = False


                    MsgBox(Strmensajecita, MsgBoxStyle.Information)

                Else

                    Exit Sub

                End If
            End If
        End If
    End Sub





    Private Sub TxtDias_Validated(ByVal sender As Object, ByVal e As System.EventArgs)

        'Claudia Garay 02/09/2009

        Dim DFecha As Date

        'Claudia Garay 5 de mayo
        'Validacion de ingreso de Cero

        If TxtDias.Text = 0 Then
            MsgBox("DEBE INGRESAR UN NUMERO MAYOR A CERO", MsgBoxStyle.Information)
            Label1.Focus()
            Exit Sub
        End If

        DFecha = Format(obj.traerFechaServidor(), objGeneral.FormatoFechaCorta)

        If Len(TxtDias.Text) > 0 Then

            mkFechaControl.Text = DateAdd(DateInterval.Day, Val(TxtDias.Text), DFecha)
            mkFechaControl.Focus()

        End If

    End Sub

    ''Creado  por Claudia Garay para consultar las citas asignadas al paciente por especialidad
    ''14 septiembre de 2009

    Private Function ConsultarCitasAsignadas(ByVal cod_prestador As String, ByVal Cod_sucursal As String, ByVal Tip_doc As String, ByVal Num_doc As String, ByVal fecha As String) As Long

        Dim dtConsulta As DataTable
        Dim IError As Long
        Dim Datos() As Object
        Dim rowArray() As DataRow
        Dim MINUTO As String

        ReDim Datos(4)

        Datos(0) = cod_prestador
        Datos(1) = Cod_sucursal
        Datos(2) = Tip_doc
        Datos(3) = Num_doc
        Datos(4) = fecha


        dtConsulta = obj.EjecutarSPConParametros("DB_TraerCitasporPac", objConexion, IError, Datos)
        If dtConsulta.Rows.Count > 0 Then

            rowArray = dtConsulta.Select("genmedsuespec = '" & objGeneral.CodigoEspecialidad & "'")
            If rowArray.Length > 0 Then

                If (rowArray(0).ItemArray(2)) < 10 Then
                    MINUTO = "0" & rowArray(0).ItemArray(2)
                Else
                    MINUTO = rowArray(0).ItemArray(2)
                End If

                If Format(rowArray(0).ItemArray(0), objGeneral.FormatoFechaCorta) < Format(obj.traerFechaServidor(), objGeneral.FormatoFechaCorta) Then
                    MsgBox("EL PACIENTE HA TENIDO CITA CON ESTA ESPECIALIDAD EN UN LAPSO DE 15 DIAS :" & vbLf & _
                   "FECHA " & rowArray(0).ItemArray(0) & vbLf & "A LAS " & rowArray(0).ItemArray(1) & _
                " : " & MINUTO & vbLf & "CON EL MEDICO " & rowArray(0).ItemArray(7) & vbLf & "EN " & rowArray(0).ItemArray(27), MsgBoxStyle.OkOnly)
                    Return 1
                Else

                    MsgBox("EL PACIENTE YA TIENE UNA CITA ASIGNADA EN ESTA ESPECIALIDAD PARA" & vbLf & _
                    "FECHA " & rowArray(0).ItemArray(0) & vbLf & "A LAS " & rowArray(0).ItemArray(1) & _
                    " : " & MINUTO & vbLf & "CON EL MEDICO " & rowArray(0).ItemArray(7) & vbLf & "EN " & rowArray(0).ItemArray(27), MsgBoxStyle.OkOnly)
                    Return 1
                    Exit Function
                End If
            Else

                Return 0

            End If
        Else
            Return 0
        End If


    End Function
    ''Claudia Garay. Cambios Acreditacion 9 de diciembre de 2010
    Public Sub cargaProgramas()
        ''Configuracion del campo que maneja el codigo
        With txtCodigoProg
            .NombreCampoBuscado = "descripcion"
            .NombreCampoBusqueda = "codigo_programa"
            .ControlTextoEnlace = txtDescrProgr
        End With

        ''Configuracion del campo que maneja la descripcion 
        With txtDescrProgr
            .NombreCampoDatos = "descripcion"
            .ControlTextoEnlace = txtCodigoProg
            Try
                .OrigenDeDatos = BLPlanManejo.consultarProgramasEdu(objConexion)
                .CargarDatosDescripcion()
            Catch ex As Exception
                MsgBox("Error en la consulta de los tipos de dieta. " & ex.Message, MsgBoxStyle.Information)
            End Try
        End With
    End Sub
    
    Private Function AgregarPrograma(ByVal dr As DataRow) As Long
        Dim BlManejo As New BLPlanManejo
        Dim dtmanejo As DataTable

        Try
            dtmanejo = BlManejo.TraeProgramasEducacion(objConexion, objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision, dr("codigo_programa"), objGeneral.Login, dr("obs"), 2)
            dtgPrograma.DataSource = dtmanejo
        Catch ex As Exception
            MsgBox("Error al agregar Programa. " & ex.Message, MsgBoxStyle.Information)
        End Try
    End Function


    Private Sub rbSi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbSi.Click
        If rbSi.Checked = True Then
            ' pnlProEdu.Enabled = True
            txtDescrProgr.Enabled = True
            txtCodigoProg.Enabled = True
            btAgregar.Enabled = True
            Label4.Enabled = True
            txtObsProg.Enabled = True
        End If
    End Sub



    Private Sub rbNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbNo.Click
        If rbNo.Checked = True Then
            'pnlProEdu.Enabled = False
            txtDescrProgr.Enabled = False
            txtCodigoProg.Enabled = False
            btAgregar.Enabled = False
            Label4.Enabled = False
            txtObsProg.Enabled = False
        End If
    End Sub

    ''Claudia Garay. Cambios Acreditacion diciembre 9 de 2010
    Private Sub btAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAgregar.Click
        Dim dtProgr As DataTable
        Dim drFila As DataRow
        Dim lError As Long

        If IsNothing(dtgPrograma) Then
            Exit Sub
        End If

        dtProgr = dtgPrograma.DataSource
        drFila = dtProgr.NewRow

        drFila("codigo_programa") = txtCodigoProg.Text
        drFila("descripcion") = txtDescrProgr.Text
        drFila("fec_con") = Format(FuncionesGenerales.FechaServidor(), objGeneral.FormatoFechaCorta)
        drFila("login") = objGeneral.NombreMedico
        drFila("obs") = txtObsProg.Text

        AgregarPrograma(drFila)

        dtProgr.Rows.Add(drFila)
        With dtgPrograma
            .DataSource = dtProgr
            .Columns("codigo_programa").Visible = False
            .Columns("descripcion").HeaderText = "Programa"
            .Columns("descripcion").Width = 200
            .Columns("fec_con").HeaderText = "Fecha"
            .Columns("fec_con").Width = 110
            .Columns("login").HeaderText = "Medico"
            .Columns("login").Width = 130
            .Columns("obs").HeaderText = "Observación"
            .Columns("obs").Width = 300
        End With


        txtCodigoProg.Text = String.Empty
        txtDescrProgr.Text = String.Empty
        txtObsProg.Text = String.Empty
    End Sub

#Region "Grabar"

#End Region

    Private Sub btGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGrabar.Click
        Dim objBl As New Sophia.HistoriaClinica.BL.BLPlanManejo
        Dim lError As Long
        Dim strFiebre As String
        Dim strCalor As String
        Dim strSecrecion As String
        Dim strEnrojecimiento As String
        Dim blnReimpresion As Boolean
        Dim strConciliacion As String


        'If objRecomendacion.Estado = "D" Then
        '    objRecomendacion.Estado = "G"
        '    blnReimpresion = False
        'Else
        '    objRecomendacion.Estado = ""
        '    blnReimpresion = Reimpresion()
        'End If

        If mkFechaControl.Text.Length = 10 Then
            If IsDate(mkFechaControl.Text) Then
                If CDate(mkFechaControl.Text) < CDate(dtFecha) Then
                    MsgBox("La fecha de control no debe ser inferior a la actual", MsgBoxStyle.Exclamation)
                    mkFechaControl.Focus()
                End If
                If tbLugar.Text.Length < 2 Then
                    MsgBox("Por favor ingrese lugar de atención para próximo control", MsgBoxStyle.Exclamation)
                    tbLugar.Focus()
                    Exit Sub
                End If
            Else
                MsgBox("La fecha de control no es correcta", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        Else
            If mkFechaControl.Text <> "  /  /" Then
                MsgBox("La fecha de control no es correcta", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        End If


        ''Conciliacion de medicamentos Febrero 27 2012
        'Claudia Patricia Garay Guerrero

        If rdConciliaMedSi.Checked = False And rdConciliaMedNo.Checked = False Then
            MsgBox("De respuesta a las preguntas de conciliacion de medicamentos.")
            Exit Sub
        Else
            If rdConciliaMedSi.Checked = True Then
                strConciliacion = "S"
            Else
                strConciliacion = "N"
            End If

        End If

        ''fin Conciliacion de medicamentos


            If Trim(tbSignos.Text.Length) = 0 Then
                MsgBox("Por favor ingrese el campo Consultar si presenta", MsgBoxStyle.Exclamation)
                tbSignos.Focus()
            Else

                If ckFiebre.Checked = True Then
                    strFiebre = "S"
                Else
                    strFiebre = "N"
                End If
                If ckCalor.Checked = True Then
                    strCalor = "S"
                Else
                    strCalor = "N"
                End If
                If ckSecrecion.Checked = True Then
                    strSecrecion = "S"
                Else
                    strSecrecion = "N"
                End If
                If ckEnrojecimiento.Checked = True Then
                    strEnrojecimiento = "S"
                Else
                    strEnrojecimiento = "N"
                End If
                Try
                    'If blnReimpresion = False Then
                lError = objBl.GrabarRecomendacionEgreso(objConexion, IIf(objRecomendacion.Estado = "G", 1, 0), Trim(tbSignos.Text), _
                            strFiebre, strCalor, strSecrecion, strEnrojecimiento, _
                            Trim(tbActividad.Text), Trim(tbNutricionales.Text), _
                            Trim(tbGenerales.Text), Trim(tbResultado.Text), _
                            Trim(mkFechaControl.Text), Trim(tbLugar.Text), _
                            Trim(tbTelefono.Text), strConciliacion)
                    If lError > 0 Then
                        MsgBox("Las recomendaciones al egreso no se grabaron, por favor verifique los datos", MsgBoxStyle.Exclamation)
                        objRecomendacion.Estado = "N"
                    Else
                        objRecomendacion.Estado = "G"
                        AdicionarValeresObjeto()
                        Invalidar()
                        ActualizarInformacionControles()
                        objGeneral.HistoriaClinicaTieneModificaciones = True
                        ImprimirReporte(blnReimpresion)
                    End If
                    'Else
                    'ImprimirReporte(blnReimpresion)
                    'End If
                Catch ex As Exception
                    'If blnReimpresion = False Then
                    If objRecomendacion.Estado <> "G" Then
                        objRecomendacion.Estado = "N"
                    End If
                    '***** para el control de errores ....*****
                    MessageBox.Show("El proceso de grabación de las recomendaciones falló por: " & ex.Message, "Historia Clínica", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
                    'Else
                    'MessageBox.Show("No se pudo realizar la Reimpresión de las Recomendaciones al Egreso", "Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'End If
                End Try
            End If
            '/ Ingresar valores a la variable global
            'AdicionarValeresObjeto()
    End Sub

    Private Sub ConfigurarSegunPais()

        If objGeneral.Pais = "482" Then
            lbIncapacidad.Text = "Días de decanso médico"
            txtConciliacionMed.Text = "¿Usted realizo el proceso de interacción de medicamentos?."
        End If

    End Sub
End Class
