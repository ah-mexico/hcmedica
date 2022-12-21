Imports System.Collections.Generic
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales.Generales
Imports HistoriaClinica.Sophia.HistoriaClinica.BL

''' <summary>
''' Clase ctlEvolucion del namespace Sophia.HistoriaClinica.ctlEvolucion que 
''' es la clase base. Esta clase tiene la funcionalidad del control de usuario para  
''' la evolución y será usado en la aplicación cliente en Windows Form 2005 
''' </summary>
''' <remarks></remarks>
''' 

Public Class ctlIngresoaPrograma
    Private Shared _Instancia As ctlIngresoaPrograma
    Private objIngresoaPrograma As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOIngresoaPrograma
    Private objPaciente As Paciente
    Private objConexion As Conexion
    Private objGeneral As objGeneral
    Private objDao As New DAOGeneral
    Private strCadenaLocal As String


#Region "Instancia de Control"
    Public Shared ReadOnly Property Instancia() As ctlIngresoaPrograma
        Get
            If _Instancia Is Nothing Then
                _Instancia = New ctlIngresoaPrograma
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

        objGeneral = Generales.Instancia
        objPaciente = Paciente.Instancia
        objConexion = Conexion.Instancia
        strCadenaLocal = objGeneral.CadenaLocal

        'POner la fecha del servidor
        ' mskIngProg.Text = FuncionesGenerales.FechaServidor() william 2017/02/01
        mskIngProg.Enabled = False
        mskIngProg.Text = ""
        DatosIniciales()
        LimpiarDatos(True)
        CargarCombos() 'pregunta 
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

    Private Sub LimpiarDatos(ByVal bLimpiarConfecha As Boolean)
        ''Si es True limpia la Fecha de Ingreso
        If bLimpiarConfecha Then
            Me.mskIngProg.Text = ""
            mskIngProg.Enabled = False
        End If

        RBSiAtencionPrevia.Checked = False
            RBNoAtencionPrevia.Checked = False
            TxtLugAtenc.Text = ""
            MskFecDiagn.Text = ""
            RBSiAtencionUH.Checked = False
            RBNoAtencionUH.Checked = False
            MskFecAtenUH.Text = ""
            RBSiAsoDiagnBase.Checked = False
            RBNoAsoDiagnBase.Checked = False
            TxtObsAtenUrgHosp.Text = ""
            RBSiAtenCirAmb.Checked = False
            RBNoAtenCirAmb.Checked = False
            chkQuimioterapia.Checked = False
            chkRadioterapia.Checked = False
            chkSedacionPaliativa.Checked = False
            TxtObsIp.Text = ""
            RBSiConDiagn.Checked = False
            RBNoConDiagn.Checked = False
            RBParConDiagn.Checked = False
            RBSiConPron.Checked = False
            RBNoConPron.Checked = False
            RBParConPron.Checked = False
            RBSiPidInfo.Checked = False
            RBNoPidInfo.Checked = False
            RBParPidInfo.Checked = False
            RBSiPidNoInfo.Checked = False
            RBNoPidNoInfo.Checked = False
            RBParPidNoInfo.Checked = False
            RBSiComDiagFam.Checked = False
            RBNoComDiagFam.Checked = False
            RBParcComDiagFam.Checked = False
            RBSiConPronFam.Checked = False
            RBNoConPronFam.Checked = False
            RBParConPronFam.Checked = False
            RBSiPidInfoFam.Checked = False
            RBNoPidInfoFam.Checked = False
            RBParPidInfoFam.Checked = False
            RBSiPidNoInfFam.Checked = False
            RBNoPidNoInfFam.Checked = False
            RBParPidNoInfFam.Checked = False
            Me.lblCercoSilencio.Text = ""
            Me.lblInfIsuficiente.Text = ""
        fnMostrarAtencionUH(False)
    End Sub

    Private Function GetCheckBoxListSelections() As String

        Dim i As Integer
        Dim strResult As String = ""
        'Dim ListItems As New List(Of String)
        'For i = 0 To (CheckedListBox1.Items.Count - 1)
        '    If CheckedListBox1.GetItemChecked(i) = True Then
        '        ListItems.Add(CheckedListBox1.Items(i)(1).ToString.Trim)
        '    End If
        'Next

        If chkQuimioterapia.Checked Then
            strResult = strResult + chkQuimioterapia.Text + ","
            'ListItems.Add(chkQuimioterapia.Text)
        End If

        If chkRadioterapia.Checked Then
            strResult = strResult + chkRadioterapia.Text + ","
            'ListItems.Add(chkRadioterapia.Text)
        End If

        If chkSedacionPaliativa.Checked Then
            strResult = strResult + chkSedacionPaliativa.Text + ","
            'ListItems.Add(chkSedacionPaliativa.Text)
        End If

        Return strResult

        'If ListItems.Count = 1 Then
        '    strResult = ListItems.Item(0).ToString()
        '    strResult = strResult + ","
        '    Return strResult
        'Else
        '    Return String.Join(",", ListItems.ToArray())
        'End If


    End Function
    'WACHV, 28-DIC-2016
    Private Function ValidarPacienteyFamilia() As Boolean

        'CASO CERCO SILENCIO
        'Si el paciente responde si a "pide información"
        'y la familia responde si "pide que no se le informe" 
        'es igual a un si en el cerco de silencio. De lo contrario marque no a la respuesta. 

        Dim strCercoSilencio As String = ""
        Dim strInfInsuficientePaciente As String = ""
        Dim strInfInsuficienteFamilia As String = ""
        Dim strInfInsuficienteGlobal As String = ""
        lblInfIsuficiente.Text = ""

        'PACIENTE Y FAMILIA CERCO DE SILENCIO
        If (RBSiPidInfo.Checked = True And RBSiPidNoInfFam.Checked = True) Then
            strCercoSilencio = "SI"
        Else
            strCercoSilencio = "NO"
        End If


        'Solamente cuando se esciba la primerz vez ya sigue
        If lblCercoSilencio.Text = "" Then
            If (RBSiPidInfo.Checked = True And RBNoPidNoInfFam.Checked = True) Then 'Si NO
                lblCercoSilencio.Text = strCercoSilencio
            ElseIf (RBSiPidInfo.Checked = True And RBSiPidNoInfFam.Checked = True) Then 'Si Si
                lblCercoSilencio.Text = strCercoSilencio
            End If
        Else
            lblCercoSilencio.Text = strCercoSilencio
        End If


        'PACIENTE Y FAMILIA INF INSUFICIENTE
        ''1. Se debe validar por aparte el grupo de información del paciente  y el grupo de  información de la familia. 
        ''2. Se puede realizar el cálculo siempre y cuando cualquiera de los dos grupos (paciente Y/o familia) 
        ''tengan respondidas las 3 preguntas que permiten realizar el calculo que son "conoce el diagnostico", "conoce el pronóstico" 
        ''y "pide información".

        ''3. Cuando en el grupo del paciente y/o la familia se  
        ''responde "parcialmente o no" a las preguntas "conoce el diagnostico" y/o "conoce el pronostico" 
        ''y ademas responde si a la pregunta "pide información" entonces el resultado debe ser "si".

        ''4. Cuando la respuesta es "si" a las 2 preguntas "conoce el diagnóstico y conoce el pronóstico" 
        ''y "si" a la pregunta pide información, la respuesta en información insuficiente es "no".

        ''5. Cuando se cumple la validación de que cualquiera de las dos preguntas o las 2 preguntas (conoce el diagnóstico y conoce el pronostico) 
        ''su respuesta sea parcialmente/No, y la respuesta a pide información sea "no" la respuesta es "no" 
        ''cuando se responde 

        ''6. Ademas se debe realizar una validación entre los dos grupos (familia y paciente) 
        ''donde si en alguno de los dos grupos el calculo es si y en el otro grupo 
        ''el calculo es no (prima el si como respuesta) en el campo de calculo de información insuficiente.
        ''        si(+si = si)
        ''        no(+si = si)
        ''        no(+no = no)

        ''Caso Paciente Se agregan loS casos de la matrix
        'Conoce el diagnóstico   NO, Conoce el pronóstico NO, Pide información SI
        If (RBNoConDiagn.Checked And RBNoConPron.Checked And RBSiPidInfo.Checked) Then
            strInfInsuficientePaciente = "SI"
        End If

        'Conoce el diagnóstico   SI, Conoce el pronóstico SI, Pide información NO
        If (RBSiConDiagn.Checked And RBSiConPron.Checked And RBNoPidInfo.Checked) Then
            strInfInsuficientePaciente = "NO"
        End If

        'Conoce el diagnóstico PARC, Conoce el pronóstico PARC, Pide información SI
        If (RBParConDiagn.Checked And RBParConPron.Checked And RBSiPidInfo.Checked) Then
            strInfInsuficientePaciente = "SI"
        End If

        'Conoce el diagnóstico NO, Conoce el pronóstico NO, Pide información NO
        If (RBNoConDiagn.Checked And RBNoConPron.Checked And RBNoPidInfo.Checked) Then
            strInfInsuficientePaciente = "SI"
        End If

        'Conoce el diagnóstico NO, Conoce el pronóstico NO, Pide información NO
        If (RBNoConDiagn.Checked And RBNoConPron.Checked And RBNoPidInfo.Checked) Then
            strInfInsuficientePaciente = "NO"
        End If

        'Conoce el diagnóstico NO, Conoce el pronóstico SI, Pide información SI
        If (RBNoConDiagn.Checked And RBSiConPron.Checked And RBSiPidInfo.Checked) Then
            strInfInsuficientePaciente = "SI"
        End If

        'Conoce el diagnóstico PARC, Conoce el pronóstico PARC, Pide información NO
        If (RBParConDiagn.Checked And RBParConPron.Checked And RBNoPidInfo.Checked) Then
            strInfInsuficientePaciente = "NO"
        End If

        'Conoce el diagnóstico NO, Conoce el pronóstico SI, Pide información SI
        If (RBNoConDiagn.Checked And RBNoConPron.Checked And RBSiPidInfo.Checked) Then
            strInfInsuficientePaciente = "SI"
        End If

        'Conoce el diagnóstico PARC, Conoce el pronóstico SI, Pide información SI
        If (RBParConDiagn.Checked And RBSiConPron.Checked And RBSiPidInfo.Checked) Then
            strInfInsuficientePaciente = "SI"
        End If

        'Conoce el diagnóstico NO, Conoce el pronóstico PARC, Pide información NO
        If (RBNoConDiagn.Checked And RBParConPron.Checked And RBNoPidInfo.Checked) Then
            strInfInsuficientePaciente = "NO"
        End If

        'Conoce el diagnóstico NO, Conoce el pronóstico PARC, Pide información NO
        If (RBNoConDiagn.Checked And RBParConPron.Checked And RBNoPidInfo.Checked) Then
            strInfInsuficientePaciente = "NO"
        End If

        'Conoce el diagnóstico PARC, Conoce el pronóstico SI, Pide información SI
        If (RBParConDiagn.Checked And RBSiConPron.Checked And RBSiPidInfo.Checked) Then
            strInfInsuficientePaciente = "SI"
        End If

        'Conoce el diagnóstico PARC, Conoce el pronóstico NO, Pide información SI
        If (RBParConDiagn.Checked And RBNoConPron.Checked And RBSiPidInfo.Checked) Then
            strInfInsuficientePaciente = "SI"
        End If

        'Conoce el diagnóstico SI, Conoce el pronóstico SI, Pide información SI
        If (RBSiConDiagn.Checked And RBSiConPron.Checked And RBSiPidInfo.Checked) Then
            strInfInsuficientePaciente = "NO"
        End If

        'Conoce el diagnóstico SI, Conoce el pronóstico no, Pide información SI
        If (RBSiConDiagn.Checked And RBNoConPron.Checked And RBSiPidInfo.Checked) Then
            strInfInsuficientePaciente = "SI"
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''
        ''Caso Familia Se agregan loS casos de la matrix
        'Conoce el diagnóstico NO, Conoce el pronóstico NO, Pide información SI
        If (RBNoComDiagFam.Checked And RBNoConPronFam.Checked And RBSiPidInfoFam.Checked) Then
            strInfInsuficienteFamilia = "SI"
        End If
        'Conoce el diagnóstico SI, Conoce el pronóstico SI, Pide información NO
        If (RBSiComDiagFam.Checked And RBSiConPronFam.Checked And RBNoPidInfoFam.Checked) Then
            strInfInsuficienteFamilia = "NO"
        End If
        'Conoce el diagnóstico PARC, Conoce el pronóstico PARC, Pide información SI
        If (RBParcComDiagFam.Checked And RBParConPronFam.Checked And RBSiPidInfoFam.Checked) Then
            strInfInsuficienteFamilia = "SI"
        End If
        'Conoce el diagnóstico NO, Conoce el pronóstico NO, Pide información NO
        If (RBNoComDiagFam.Checked And RBNoConPronFam.Checked And RBNoPidInfoFam.Checked) Then
            strInfInsuficienteFamilia = "NO"
        End If
        'Conoce el diagnóstico PARC, Conoce el pronóstico PARC, Pide información SI
        If (RBParcComDiagFam.Checked And RBParConPronFam.Checked And RBSiPidInfoFam.Checked) Then
            strInfInsuficienteFamilia = "SI"
        End If
        'Conoce el diagnóstico SI, Conoce el pronóstico PARC, Pide información SI
        If (RBSiComDiagFam.Checked And RBParConPronFam.Checked And RBSiPidInfoFam.Checked) Then
            strInfInsuficienteFamilia = "SI"
        End If
        'Conoce el diagnóstico PARC, Conoce el pronóstico PARC, Pide información NO
        If (RBParcComDiagFam.Checked And RBParConPronFam.Checked And RBNoPidInfoFam.Checked) Then
            strInfInsuficienteFamilia = "NO"
        End If
        'Conoce el diagnóstico NO, Conoce el pronóstico PARC, Pide información SI
        If (RBNoComDiagFam.Checked And RBParConPronFam.Checked And RBSiPidInfoFam.Checked) Then
            strInfInsuficienteFamilia = "SI"
        End If
        'Conoce el diagnóstico SI, Conoce el pronóstico SI, Pide información SI
        If (RBSiComDiagFam.Checked And RBSiConPronFam.Checked And RBSiPidInfoFam.Checked) Then
            strInfInsuficienteFamilia = "NO"
        End If
        'Conoce el diagnóstico SI, Conoce el pronóstico NO, Pide información SI
        If (RBSiComDiagFam.Checked And RBNoConPronFam.Checked And RBSiPidInfoFam.Checked) Then
            strInfInsuficienteFamilia = "SI"
        End If

        ' ''Por Paciente y Familia 
        If (strInfInsuficientePaciente <> "" And strInfInsuficienteFamilia <> "") Then
            If (strInfInsuficientePaciente = "SI" And strInfInsuficienteFamilia = "SI") Then strInfInsuficienteGlobal = "SI" '' si(+si = si)
            If (strInfInsuficientePaciente = "NO" And strInfInsuficienteFamilia = "NO") Then strInfInsuficienteGlobal = "NO" '' no(+no = no) 
            If (strInfInsuficientePaciente = "SI" And strInfInsuficienteFamilia = "NO") Then strInfInsuficienteGlobal = "SI" '' si(+NO = si)
            If (strInfInsuficientePaciente = "NO" And strInfInsuficienteFamilia = "SI") Then strInfInsuficienteGlobal = "SI" ''no(+si = si)
        ElseIf strInfInsuficientePaciente <> "" Then  ''Por Paciente 
            If strInfInsuficientePaciente = "SI" Then strInfInsuficienteGlobal = "SI"
            If (strInfInsuficientePaciente = "NO") Then strInfInsuficienteGlobal = "NO"
        ElseIf strInfInsuficienteFamilia <> "" Then  ''Por Familia 
            If strInfInsuficienteFamilia = "SI" Then strInfInsuficienteGlobal = "SI"
            If strInfInsuficienteFamilia = "NO" Then strInfInsuficienteGlobal = "NO"
        End If

        ''''Solamente cuando ya complete los campos del requerimiento
        ''''Solamente cuando se esciba la primerz vez ya sigue
        If lblInfIsuficiente.Text = "" And strInfInsuficienteGlobal <> "" Then
            'If ((((RBNoConDiagn.Checked Or RBParConDiagn.Checked) And (RBNoConPron.Checked Or RBParConPron.Checked)) And RBSiPidInfo.Checked) _
            'Or ((RBNoComDiagFam.Checked Or RBParcComDiagFam.Checked) And (RBNoConPronFam.Checked Or RBParConPronFam.Checked)) And RBSiPidInfoFam.Checked) Then
            ' If (((((RBNoConDiagn.Checked Or RBParConDiagn.Checked) And (RBNoConPron.Checked Or RBParConPron.Checked)) And RBSiPidInfo.Checked) _
            'Or ((RBNoComDiagFam.Checked Or RBParcComDiagFam.Checked) And (RBNoConPronFam.Checked Or RBParConPronFam.Checked)) And RBSiPidInfoFam.Checked) _
            'Or (((RBSiConDiagn.Checked And RBSiConPron.Checked And RBSiPidInfo.Checked)) Or ((RBSiConDiagn.Checked And RBSiConPron.Checked And RBSiPidInfo.Checked)))) Then
            lblInfIsuficiente.Text = strInfInsuficienteGlobal
        End If
        'End If

    End Function

    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

#Region "CargarCombos"
    Private Sub CargarCombos()
        Dim dt As New DataTable

        Try

            'CheckedListBox1.ResetText()
            'CheckedListBox1.BeginUpdate()

            'CheckedListBox1.DataSource = Me.objIngresoaPrograma.CargarCombosCP(2)
            'CheckedListBox1.DisplayMember = "descripcion"
            'CheckedListBox1.ValueMember = "id"
            'CheckedListBox1.EndUpdate()

        Catch ex As Exception
            MsgBox("Error en la consulta de las respuestas de intervencion " & ex.Message, MsgBoxStyle.Information)
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
            dtDiagnostico = objBl.ConsultarDiagnosticoReingreso(objGeneral.Prestador, objGeneral.Sucursal, _
                                    objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision, _
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
            lError = objBl.GrabarEgresoDiagnostico(objConexion, strCodPreSgs, strCodSucur, _
                            strTipDoc, strNumDoc, strTipAdm, dblNumAdm, intAnoAdm, strClaseDiag, _
                            strTipDiag, strDiagnostico, strAntecedente, strObservaciones, strConfidencial, _
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

#Region "ValoracioneIngreso"

    Private Sub RBSiAtencionPrevia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBSiAtencionPrevia.CheckedChanged
        Me.TxtLugAtenc.Enabled = True
        Me.Label6.Enabled = True
        TxtLugAtenc.Text = ""
    End Sub

    Private Sub RBNoAtencionPrevia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBNoAtencionPrevia.CheckedChanged
        Me.TxtLugAtenc.Enabled = False
        Me.Label6.Enabled = False
        TxtLugAtenc.Text = ""
    End Sub

    Private Sub RBSiAsoDiagnBase_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBSiAsoDiagnBase.CheckedChanged
        Label14.Enabled = True
        TxtObsAtenUrgHosp.Enabled = True
    End Sub

    Private Sub RBNoAsoDiagnBase_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBNoAsoDiagnBase.CheckedChanged
        Label14.Enabled = False
        TxtObsAtenUrgHosp.Enabled = False
        TxtObsAtenUrgHosp.Text = ""
    End Sub

    Private Sub mskIngProg_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mskIngProg.Validating
        If mskIngProg.Text <> "  /  /" Then
            If Not IsDate(mskIngProg.Text) Then
                MsgBox("Fecha invalida. Debe digitar una fecha valida.", MsgBoxStyle.Information)
                mskIngProg.Text = ""
                e.Cancel = True
                mskIngProg.Select(0, mskIngProg.TextLength)
            Else
                If bvalidarFecha(mskIngProg.Text) Then
                    MsgBox("Fecha invalida. Debe digitar una fecha valida.", MsgBoxStyle.Information)
                    mskIngProg.Text = ""
                    e.Cancel = True
                    mskIngProg.Select(0, mskIngProg.TextLength)
                End If
            End If
        End If
    End Sub

    Private Sub MskFecDiagn_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MskFecDiagn.Validating
        If MskFecDiagn.Text <> "  /  /" Then
            If Not IsDate(MskFecDiagn.Text) Then
                MsgBox("Fecha invalida. Debe digitar una fecha valida.", MsgBoxStyle.Information)
                MskFecDiagn.Text = ""
                e.Cancel = True
                MskFecDiagn.Select(0, MskFecDiagn.TextLength)
            Else
                If bvalidarFecha(MskFecDiagn.Text) Then
                    MsgBox("Fecha invalida. Debe digitar una fecha valida.", MsgBoxStyle.Information)
                    mskIngProg.Text = ""
                    e.Cancel = True
                    mskIngProg.Select(0, mskIngProg.TextLength)
                End If
            End If
       
        End If

    End Sub

    Private Sub MskFecAtenUH_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MskFecAtenUH.Validating
        Dim objFechaSer As Date = CDate(Format(FuncionesGenerales.FechaServidor()))
        If MskFecAtenUH.Text <> "  /  /" Then
            If Not IsDate(MskFecAtenUH.Text) Then
                MsgBox("Fecha invalida. Debe digitar una fecha valida.", MsgBoxStyle.Information)
                MskFecAtenUH.Text = ""
                e.Cancel = True
                MskFecAtenUH.Select(0, MskFecAtenUH.TextLength)
            ElseIf bvalidarFecha(MskFecAtenUH.Text) Then
                MsgBox("Fecha invalida. Debe digitar una fecha valida.", MsgBoxStyle.Information)
                MskFecAtenUH.Text = ""
                e.Cancel = True
                MskFecAtenUH.Select(0, MskFecAtenUH.TextLength)
                'ElseIf DateDiff(DateInterval.Month, CDate(MskFecAtenUH.Text), objFechaSer) <> 1 Then
                '    MsgBox("Fecha invalida.La Fecha Ingresada no corresponde al mes anterior .", MsgBoxStyle.Information)
                '    MskFecAtenUH.Text = ""
                '    e.Cancel = True
                '    mskIngProg.Select(0, MskFecAtenUH.TextLength)
            End If

        End If
    End Sub
    'Private Sub mskfechaatencionxurgencias_hospitalizacion_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
    '    If mskfechaatencionxurgencias_hospitalizacion.Text <> "  /  /" Then
    '        If Not IsDate(mskfechaatencionxurgencias_hospitalizacion.Text) Then
    '            MsgBox("Fecha invalida. Debe digitar una fecha valida.", MsgBoxStyle.Information)
    '            mskfechaatencionxurgencias_hospitalizacion.Text = ""
    '            e.Cancel = True
    '            mskfechaatencionxurgencias_hospitalizacion.Select(0, mskfechaatencionxurgencias_hospitalizacion.TextLength)
    '        Else
    '            If bvalidarFecha(mskfechaatencionxurgencias_hospitalizacion.Text) Then
    '                MsgBox("Fecha invalida. Debe digitar una fecha valida.", MsgBoxStyle.Information)
    '                mskIngProg.Text = ""
    '                e.Cancel = True
    '                mskIngProg.Select(0, mskIngProg.TextLength)
    '            End If
    '        End If
    '    End If
    'End Sub


    Private Sub ObsJuntaPal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub RBNoAtenCirAmb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBNoAtenCirAmb.CheckedChanged

    End Sub

    'Private Sub CheckedListBox1_ItemCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs)
    '    If e.NewValue = CheckState.Unchecked Then
    '        If CheckedListBox1.CheckedItems.Count = 1 Then
    '            Me.TxtObsIp.Visible = False
    '            Me.Label16.Visible = False
    '        Else
    '            Me.TxtObsIp.Visible = False
    '            Me.Label16.Visible = False
    '            'Me.TxtObsIp.Text = ""
    '        End If
    '    Else
    '        Me.TxtObsIp.Visible = True
    '        Me.Label16.Visible = True
    '    End If
    'End Sub

    'Private Sub CheckedListBox1_ItemCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles CheckedListBox1.ItemCheck
    '    '    If e.NewValue = CheckState.Unchecked Then
    '    '        If CheckedListBox1.CheckedItems.Count = 1 Then
    '    '            Me.TxtObsIp.Visible = True
    '    '            Me.Label16.Visible = True
    '    '        Else
    '    '            Me.TxtObsIp.Visible = False
    '    '            Me.Label16.Visible = False
    '    '        End If
    '    '    Else
    '    '        Me.TxtObsIp.Visible = True
    '    '        Me.Label16.Visible = True
    '    '    End If
    'End Sub


    Private Sub CheckedListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim i As Integer
        'For i = 0 To CheckedListBox1.Items.Count - 1
        '    If (CheckedListBox1.GetItemChecked(i)) Then
        '        Me.TxtObsIp.Visible = True
        '        Me.Label16.Visible = True
        '    End If
        'Next
    End Sub

    'Private Sub RBNoAtencionPrevia_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBNoAtencionPrevia.CheckedChanged1
    '    Label6.Visible = False
    '    TxtLugAtenc.Visible = False
    'End Sub

    Private Sub RBSiPidInfo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBSiPidInfo.CheckedChanged
        'If RBSiPidInfo.Checked = True And RBSiPidNoInfFam.Checked = True Then
        '    Me.lblCercoSilencio.Text = "SI"
        'End If
        ValidarPacienteyFamilia()
    End Sub

    Private Sub RBSiPidNoInfFam_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBSiPidNoInfFam.CheckedChanged
        'If RBSiPidInfo.Checked = True And RBSiPidNoInfFam.Checked = True Then
        '    Me.lblCercoSilencio.Text = "SI"
        'End If
        ValidarPacienteyFamilia()
    End Sub

    Private Sub RBNoConDiagn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBNoConDiagn.CheckedChanged
        'If (RBNoConDiagn.Checked = True Or RBParConDiagn.Checked = True) And (RBNoConPron.Checked = True Or RBParConPron.Checked = True) And (RBNoComDiagFam.Checked = True Or RBParcComDiagFam.Checked = True) Or (RBNoConPronFam.Checked = True Or RBParConPronFam.Checked = True) Then
        '    Me.lblCercoSilencio.Text = "SI"
        'End If
        ValidarPacienteyFamilia()
    End Sub
    Private Sub RBSiConDiagn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBSiConDiagn.CheckedChanged
        ValidarPacienteyFamilia()
    End Sub

    Private Sub RBParConDiagn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBParConDiagn.CheckedChanged
        ValidarPacienteyFamilia()
    End Sub

    Private Sub RBSiConPron_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBSiConPron.CheckedChanged
        ValidarPacienteyFamilia()
    End Sub

    Private Sub RBNoConPron_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBNoConPron.CheckedChanged
        ValidarPacienteyFamilia()
    End Sub

    Private Sub RBParConPron_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBParConPron.CheckedChanged
        ValidarPacienteyFamilia()
    End Sub

    Private Sub RBNoPidInfo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBNoPidInfo.CheckedChanged
        ValidarPacienteyFamilia()
    End Sub

    Private Sub RBParPidInfo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBParPidInfo.CheckedChanged
        ValidarPacienteyFamilia()
    End Sub

    Private Sub RBSiPidNoInfo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBSiPidNoInfo.CheckedChanged
        ValidarPacienteyFamilia()
    End Sub

    Private Sub RBNoPidNoInfo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBNoPidNoInfo.CheckedChanged
        ValidarPacienteyFamilia()
    End Sub

    Private Sub RBParPidNoInfo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBParPidNoInfo.CheckedChanged
        ValidarPacienteyFamilia()
    End Sub

    Private Sub RBSiComDiagFam_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBSiComDiagFam.CheckedChanged
        ValidarPacienteyFamilia()
    End Sub

    Private Sub RBNoComDiagFam_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBNoComDiagFam.CheckedChanged
        ValidarPacienteyFamilia()
    End Sub

    Private Sub RBParcComDiagFam_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBParcComDiagFam.CheckedChanged
        ValidarPacienteyFamilia()
    End Sub

    Private Sub RBSiConPronFam_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBSiConPronFam.CheckedChanged
        ValidarPacienteyFamilia()
    End Sub

    Private Sub RBNoConPronFam_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBNoConPronFam.CheckedChanged
        ValidarPacienteyFamilia()
    End Sub

    Private Sub RBParConPronFam_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBParConPronFam.CheckedChanged
        ValidarPacienteyFamilia()
    End Sub

    Private Sub RBSiPidInfoFam_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBSiPidInfoFam.CheckedChanged
        ValidarPacienteyFamilia()
    End Sub

    Private Sub RBNoPidInfoFam_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBNoPidInfoFam.CheckedChanged
        ValidarPacienteyFamilia()
    End Sub

    Private Sub RBParPidInfoFam_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBParPidInfoFam.CheckedChanged
        ValidarPacienteyFamilia()
    End Sub

    Private Sub RBNoPidNoInfFam_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBNoPidNoInfFam.CheckedChanged
        ValidarPacienteyFamilia()
    End Sub

    Private Sub RBParPidNoInfFam_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBParPidNoInfFam.CheckedChanged
        ValidarPacienteyFamilia()
    End Sub

    Private Sub BttonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BttonGuardar.Click
        Try
            If MsgBox("Una vez almacenados los datos no podrán ser modificados. Desea Continuar", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                If (GuardarIngresoaPrograma()) Then
                    MessageBox.Show("Registro Guardado.", "Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LimpiarDatos(False) ''Con Falso es Todo
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("El proceso de grabación de Cuidados Paliativos fallo por: " & ex.Message, "Historia Clínica", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
        End Try
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

                If (fecha < fechaMinima) OrElse (fecha > fechaMaxima) OrElse (fecha < dtFechaNacimientoPaciente) Then
                    'MessageBox.Show("Fecha errónea")
                    bValidaFecha = True
                End If
            Else
                'MessageBox.Show("Fecha errónea")
                bValidaFecha = True
            End If


            bvalidarFecha = bValidaFecha

        Catch ex As Exception
            bValidaFecha = True
        End Try

    End Function

    Private Function GuardarIngresoaPrograma() As Boolean
        Dim lError As Long
        Dim oIngresoaPrograma As New IngresoaPrograma

        Try

            oIngresoaPrograma.cod_pre_sgs = objGeneral.Prestador
            oIngresoaPrograma.cod_sucur = objGeneral.Sucursal
            oIngresoaPrograma.tip_admision = objPaciente.TipoAdmision

            oIngresoaPrograma.ano_adm = objPaciente.AnoAdmision
            oIngresoaPrograma.num_adm = objPaciente.NumeroAdmision
            oIngresoaPrograma.tip_doc = objPaciente.TipoDocumento
            oIngresoaPrograma.Num_doc = objPaciente.NumeroDocumento

            'datos obligatorios

            ''fecha de ingreso al programa
            Dim FecIngrProg As String
            FecIngrProg = mskIngProg.Text

            If mskIngProg.Text <> "  /  /" Then
                If bvalidarFecha(mskIngProg.Text) = False Then
                    oIngresoaPrograma.FechaIngreso = mskIngProg.Text
                Else
                    Dim parts As String() = FecIngrProg.Split(New Char() {"/"c})
                    FecIngrProg = parts(1) + "/" + parts(0) + "/" + parts(2)
                    mskIngProg.Enabled = False
                    oIngresoaPrograma.FechaIngreso = FecIngrProg
                End If
            Else
                oIngresoaPrograma.FechaIngreso = ""
            End If

            ''Atencion Previa
            If RBSiAtencionPrevia.Checked = True Then
                oIngresoaPrograma.Harecibidoatencionpreviaporcuidadospaliativos = "S"
            Else
                If RBNoAtencionPrevia.Checked = True Then
                    oIngresoaPrograma.Harecibidoatencionpreviaporcuidadospaliativos = "N"
                Else
                    oIngresoaPrograma.Harecibidoatencionpreviaporcuidadospaliativos = ""
                End If
            End If

            ''lugar atencio previa
            oIngresoaPrograma.Donderecibioatencionporcuidadospaliativos = TxtLugAtenc.Text

            ''fecha diagnostivo
            If MskFecDiagn.Text <> "  /  /" Then
                If bvalidarFecha(MskFecDiagn.Text) = False Then
                    oIngresoaPrograma.FechaDiagnostico = MskFecDiagn.Text
                Else
                    Exit Function
                End If
            Else
                oIngresoaPrograma.FechaDiagnostico = ""
            End If


            ''Atencion Previa
            If RBSiAtencionUH.Checked = True Then
                oIngresoaPrograma.Harequeridoatencionporurgenciasuhospitalizacionenelultimomes = "S"
            Else
                If RBNoAtencionUH.Checked = True Then
                    oIngresoaPrograma.Harequeridoatencionporurgenciasuhospitalizacionenelultimomes = "N"
                Else
                    oIngresoaPrograma.Harequeridoatencionporurgenciasuhospitalizacionenelultimomes = ""
                End If
            End If

            ''fecha de atencion

            If MskFecAtenUH.Text <> "  /  /" Then
                If bvalidarFecha(MskFecAtenUH.Text) = False Then
                    oIngresoaPrograma.Fechadelaatencionporurgencias_Hospitalizacion = MskFecAtenUH.Text
                Else
                    Exit Function
                End If
            Else
                oIngresoaPrograma.Fechadelaatencionporurgencias_Hospitalizacion = ""
            End If


            ''la atencion esta asociada a un diagnostico base
            If RBSiAsoDiagnBase.Checked = True Then
                oIngresoaPrograma.Laatencionporurgencias_hospitalizacionestaasociadacoeldiagnosticodebase = "S"
            Else
                If RBNoAsoDiagnBase.Checked = True Then
                    oIngresoaPrograma.Laatencionporurgencias_hospitalizacionestaasociadacoeldiagnosticodebase = "N"
                Else
                    oIngresoaPrograma.Laatencionporurgencias_hospitalizacionestaasociadacoeldiagnosticodebase = " "
                End If
            End If

            ''observacion atencion hospitalizacion/Urgencias

            oIngresoaPrograma.Observacionesdelaatencion_Urgencias_Hospitalizacion = TxtObsAtenUrgHosp.Text

            ''Atencion por cirugia ambulatoria el ultimo mes
            If RBSiAtenCirAmb.Checked = True Then
                oIngresoaPrograma.Harequeridoatencionporcirugiaambulatoriaenelultimomes = "S"
            Else
                If RBNoAtenCirAmb.Checked = True Then
                    oIngresoaPrograma.Harequeridoatencionporcirugiaambulatoriaenelultimomes = "N"
                Else
                    oIngresoaPrograma.Harequeridoatencionporcirugiaambulatoriaenelultimomes = " "
                End If
            End If

            ''intervenciones, guardar string separado por comas
            Dim strIntervenciones As String = ""
            strIntervenciones = GetCheckBoxListSelections()
            oIngresoaPrograma.Elpacienteestarecibiendoalgunadelassiguientesintervenciones = strIntervenciones

            ''Observacion Intervenciones
            oIngresoaPrograma.Observacionesintervencionespaliativos = TxtObsIp.Text

            ''Conoce el diagnostico Paciente
            If RBSiConDiagn.Checked = True Then
                oIngresoaPrograma.Conoceeldiagnostico_Paciente = "S"
            Else
                If RBNoConDiagn.Checked = True Then
                    oIngresoaPrograma.Conoceeldiagnostico_Paciente = "N"
                Else
                    If RBParConDiagn.Checked = True Then
                        oIngresoaPrograma.Conoceeldiagnostico_Paciente = "PARCIALMENTE"
                    Else
                        oIngresoaPrograma.Conoceeldiagnostico_Paciente = ""
                    End If
                End If
            End If

            ''Conoce el Pronostico Paciente
            If RBSiConPron.Checked = True Then
                oIngresoaPrograma.Conoceelpronostico_Paciente = "S"
            Else
                If RBNoConPron.Checked = True Then
                    oIngresoaPrograma.Conoceelpronostico_Paciente = "N"
                Else
                    If RBParConPron.Checked = True Then
                        oIngresoaPrograma.Conoceelpronostico_Paciente = "PARCIALMENTE"
                    Else
                        oIngresoaPrograma.Conoceelpronostico_Paciente = ""
                    End If
                End If
            End If

            ''Pide Informacion Paciente
            If RBSiPidInfo.Checked = True Then
                oIngresoaPrograma.Pideinformacion_Paciente = "S"
            Else
                If RBNoPidInfo.Checked = True Then
                    oIngresoaPrograma.Pideinformacion_Paciente = "N"
                Else
                    If RBParPidInfo.Checked = True Then
                        oIngresoaPrograma.Pideinformacion_Paciente = "PARCIALMENTE"
                    Else
                        oIngresoaPrograma.Pideinformacion_Paciente = ""
                    End If
                End If
            End If

            ''Pide que no se le informe Paciente
            If RBSiPidNoInfo.Checked = True Then
                oIngresoaPrograma.Pidequenoseleinforme_Paciente = "S"
            Else
                If RBNoPidNoInfo.Checked = True Then
                    oIngresoaPrograma.Pidequenoseleinforme_Paciente = "N"
                Else
                    If RBParPidNoInfo.Checked = True Then
                        oIngresoaPrograma.Pidequenoseleinforme_Paciente = "PARCIALMENTE"
                    Else
                        oIngresoaPrograma.Pidequenoseleinforme_Paciente = ""
                    End If
                End If
            End If

            ''Conoce el diagnóstico Familia
            If RBSiComDiagFam.Checked = True Then
                oIngresoaPrograma.Conoceeldiagnostico_Familia = "S"
            Else
                If RBNoComDiagFam.Checked = True Then
                    oIngresoaPrograma.Conoceeldiagnostico_Familia = "N"
                Else
                    If RBParcComDiagFam.Checked = True Then
                        oIngresoaPrograma.Conoceeldiagnostico_Familia = "PARCIALMENTE"
                    Else
                        oIngresoaPrograma.Conoceeldiagnostico_Familia = ""
                    End If
                End If
            End If

            ''Pide Informacion Familia
            If RBSiConPronFam.Checked = True Then
                oIngresoaPrograma.Conoceelpronostico_Familia = "S"
            Else
                If RBNoConPronFam.Checked = True Then
                    oIngresoaPrograma.Conoceelpronostico_Familia = "N"
                Else
                    If RBParConPronFam.Checked = True Then
                        oIngresoaPrograma.Conoceelpronostico_Familia = "PARCIALMENTE"
                    Else
                        oIngresoaPrograma.Conoceelpronostico_Familia = ""
                    End If
                End If
            End If

            ''Pide Informacion Familia
            If RBSiPidInfoFam.Checked = True Then
                oIngresoaPrograma.Pideinformacion_Familia = "S"
            Else
                If RBNoPidInfoFam.Checked = True Then
                    oIngresoaPrograma.Pideinformacion_Familia = "N"
                Else
                    If RBParPidInfoFam.Checked = True Then
                        oIngresoaPrograma.Pideinformacion_Familia = "PARCIALMENTE"
                    Else
                        oIngresoaPrograma.Pideinformacion_Familia = ""
                    End If

                End If
            End If

            ''Pide que no se le informe Familia
            If RBSiPidNoInfFam.Checked = True Then
                oIngresoaPrograma.Pidequenoseleinforme_Familia = "S"
            Else
                If RBNoPidNoInfFam.Checked = True Then
                    oIngresoaPrograma.Pidequenoseleinforme_Familia = "N"
                Else
                    If RBParPidNoInfFam.Checked = True Then
                        oIngresoaPrograma.Pidequenoseleinforme_Familia = "PARCIALMENTE"
                    Else
                        oIngresoaPrograma.Pidequenoseleinforme_Familia = ""
                    End If

                End If
            End If

            ''Cerco de silencio
            If lblCercoSilencio.Text <> "" Then
                If lblCercoSilencio.Text = "SI" Then oIngresoaPrograma.CercodeSilencio = "S"
                If lblCercoSilencio.Text = "NO" Then oIngresoaPrograma.CercodeSilencio = "N"
            Else
                oIngresoaPrograma.CercodeSilencio = " "
            End If

            ''Informacion Insuficiente
            If lblInfIsuficiente.Text <> "" Then
                If lblInfIsuficiente.Text = "SI" Then oIngresoaPrograma.Informacioninsuficiente = "S"
                If lblInfIsuficiente.Text = "NO" Then oIngresoaPrograma.Informacioninsuficiente = "N"
            Else
                oIngresoaPrograma.Informacioninsuficiente = " "
            End If

            oIngresoaPrograma.obs = String.Empty
            oIngresoaPrograma.login = objGeneral.Login

            lError = objIngresoaPrograma.GuardarIngresoaPrograma(oIngresoaPrograma)


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


    Private Sub cboDescDiagnostico_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    'Private Sub RBSiInP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBSiInP.CheckedChanged
    '    Me.GroupBox20.Enabled = True
    '    GroupBox1.Enabled = True
    '    GroupBox2.Enabled = True
    '    mskIngProg.Text = Format(objDao.traerFechaServidor())

    'End Sub

    'Private Sub RBNoInP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBNoInP.CheckedChanged
    '    Me.GroupBox20.Enabled = False
    '    GroupBox1.Enabled = False
    '    GroupBox2.Enabled = False
    'End Sub
#End Region

    Private Function fnMostrarAtencionUH(ByVal bMostrar As Boolean)
        Label10.Enabled = bMostrar
        Label11.Enabled = bMostrar
        MskFecAtenUH.Enabled = bMostrar
        Label13.Enabled = bMostrar
        GroupBox8.Enabled = bMostrar
        RBSiAsoDiagnBase.Enabled = bMostrar
        RBNoAsoDiagnBase.Enabled = bMostrar
        If bMostrar = False Then
            RBSiAsoDiagnBase.Checked = bMostrar
            RBNoAsoDiagnBase.Checked = bMostrar
            Label14.Enabled = bMostrar
            TxtObsAtenUrgHosp.Enabled = bMostrar
            TxtObsAtenUrgHosp.Text = ""
        End If
    End Function


    Private Sub RBNoAtencionUH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBNoAtencionUH.CheckedChanged
        fnMostrarAtencionUH(False)
    End Sub

    Private Sub RBSiAtencionUH_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBSiAtencionUH.CheckedChanged
        fnMostrarAtencionUH(True)
    End Sub

    Private Sub btnSugerirRespuesta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSugerirRespuesta.Click
        fncLeerUltimasRespuestas(True)
    End Sub

    ''WACHV,INICIO,26sept2017,Funcion que Obtiene la Ultima respuesta y retorna verdadero si tiene respuesta y falso si no tiene respuesta del ws.
    Private Function fncLeerUltimasRespuestas(bMostrar As Boolean) As Boolean
        Dim bEstado As Boolean = False
        Try
            Dim oIngresoaPrograma As New IngresoaPrograma()
            LimpiarDatos(False)
            loadIngresoaPrograma(oIngresoaPrograma.SugerirRespuesta(objGeneral, objPaciente))

            If bMostrar = False Then 'Si esta en paliativos, tiene alguna fecha de egreso, queda el control bloqueado 
                If Me.ParentForm.Controls.Find("pnlContenedorDatosPaciente", True)(0).Controls(0).Controls.Find("pnlAlarmas", True)(0).Controls.Find("btnPalitivo", True)(0).Visible = True Then
                    mskIngProg.Enabled = False
                    LimpiarDatos(False)
                Else ''Si No esta en en Programa, activa el boton para edicion
                    'mskIngProg.Enabled = True
                    LimpiarDatos(True)
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
    ''' Carga la información Asp. Emocionales
    ''' </summary>
    ''' <param name="oEmocionales">Aspecto Emocional a cargar</param>
    ''' <remarks></remarks>
    Private Sub loadIngresoaPrograma(ByVal oIngresoaPrograma As IngresoaPrograma)
        Try
            ''' mskIngProg.Text = IIf(oIngresoaPrograma.FechaIngreso = Nothing, "", oIngresoaPrograma.FechaIngreso)
            'WACHV,1-FEB-2016, Se realiza cambio segun la reunion del dia de hoy con German, Alix,Marily y William Ch. para 
            'que permita agregar fecha si no llega por el servicio cuando se guarda por avicena
            'WACHV, 21sept2017,Si no trae fecha se muestra en blanco 
            'WACHV, 22SEPT2017, para que la fecha se muestre activa o no dependeiendo <see cref="esta activo

            Dim FecIngrProg As String
            FecIngrProg = oIngresoaPrograma.FechaIngreso

            If (oIngresoaPrograma.FechaIngreso = Nothing) Then
                mskIngProg.Text = ""
                'mskIngProg.Enabled = True    
            Else   'WACHV, 21sept2017,Si trae fecha se muestra bloqueado    

                mskIngProg.Enabled = False
                mskIngProg.Text = oIngresoaPrograma.FechaIngreso

                If mskIngProg.Text <> "  /  /" Then
                    If bvalidarFecha(mskIngProg.Text) = False Then
                        oIngresoaPrograma.FechaIngreso = mskIngProg.Text
                    Else
                        Dim parts As String() = FecIngrProg.Split(New Char() {"/"c})
                        FecIngrProg = parts(1) + "/" + parts(0) + "/" + parts(2)
                        mskIngProg.Enabled = False
                        oIngresoaPrograma.FechaIngreso = FecIngrProg
                    End If
                Else
                    oIngresoaPrograma.FechaIngreso = ""
                End If

                ''mskIngProg.Text = oIngresoaPrograma.FechaIngreso

            End If

            If Not (oIngresoaPrograma.Harecibidoatencionpreviaporcuidadospaliativos = Nothing) Then
                    If oIngresoaPrograma.Harecibidoatencionpreviaporcuidadospaliativos.Substring(oIngresoaPrograma.Harecibidoatencionpreviaporcuidadospaliativos.Length - 1).Contains("1") Then
                        RBSiAtencionPrevia.Checked = True
                        RBNoAtencionPrevia.Checked = False
                    Else
                        RBSiAtencionPrevia.Checked = False
                        RBNoAtencionPrevia.Checked = True
                    End If
                End If


                TxtLugAtenc.Text = IIf(oIngresoaPrograma.Donderecibioatencionporcuidadospaliativos = Nothing, "", oIngresoaPrograma.Donderecibioatencionporcuidadospaliativos)
                MskFecDiagn.Text = IIf(oIngresoaPrograma.FechaDiagnostico = Nothing, "", oIngresoaPrograma.FechaDiagnostico)

                If Not (oIngresoaPrograma.Harequeridoatencionporcirugiaambulatoriaenelultimomes = Nothing) Then
                    If oIngresoaPrograma.Harequeridoatencionporcirugiaambulatoriaenelultimomes.Substring(oIngresoaPrograma.Harequeridoatencionporcirugiaambulatoriaenelultimomes.Length - 1).Contains("1") Then
                        RBSiAtencionUH.Checked = True
                        RBNoAtencionUH.Checked = False
                    Else
                        RBSiAtencionUH.Checked = False
                        RBNoAtencionUH.Checked = True
                    End If
                End If


            MskFecAtenUH.Text = IIf(oIngresoaPrograma.Fechadelaatencionporurgencias_Hospitalizacion = Nothing, "", oIngresoaPrograma.Fechadelaatencionporurgencias_Hospitalizacion)

            If Not (oIngresoaPrograma.Laatencionporurgencias_hospitalizacionestaasociadacoeldiagnosticodebase = Nothing) Then
                    If oIngresoaPrograma.Laatencionporurgencias_hospitalizacionestaasociadacoeldiagnosticodebase.Substring(oIngresoaPrograma.Laatencionporurgencias_hospitalizacionestaasociadacoeldiagnosticodebase.Length - 1).Contains("1") Then
                        RBSiAsoDiagnBase.Checked = True
                        RBNoAsoDiagnBase.Checked = False
                    Else
                        RBSiAsoDiagnBase.Checked = False
                        RBNoAsoDiagnBase.Checked = True
                    End If
                End If

                TxtObsAtenUrgHosp.Text = IIf(oIngresoaPrograma.Observacionesdelaatencion_Urgencias_Hospitalizacion = Nothing, "", oIngresoaPrograma.Observacionesdelaatencion_Urgencias_Hospitalizacion)

            TxtObsIp.Text = IIf(oIngresoaPrograma.Observacionesintervencionespaliativos = Nothing, "", oIngresoaPrograma.Observacionesintervencionespaliativos)

            If Not (oIngresoaPrograma.Harequeridoatencionporurgenciasuhospitalizacionenelultimomes = Nothing) Then
                    If oIngresoaPrograma.Harequeridoatencionporurgenciasuhospitalizacionenelultimomes.Substring(oIngresoaPrograma.Harequeridoatencionporurgenciasuhospitalizacionenelultimomes.Length - 1).Contains("1") Then
                        RBSiAtenCirAmb.Checked = True
                        RBNoAtenCirAmb.Checked = False
                    Else
                        RBSiAtenCirAmb.Checked = False
                        RBNoAtenCirAmb.Checked = True
                    End If
                End If

            'mskfechaatencionxurgencias_hospitalizacion.Text = IIf(oIngresoaPrograma.Fechadelaatencionporurgencias_Hospitalizacion = Nothing, "", oIngresoaPrograma.Fechadelaatencionporurgencias_Hospitalizacion)

            ''Pendiente verificar llenado
            If Not (oIngresoaPrograma.Elpacienteestarecibiendoalgunadelassiguientesintervenciones = Nothing) Then
                Dim delimiter As Char = ","
                Dim substrings() As String = oIngresoaPrograma.Elpacienteestarecibiendoalgunadelassiguientesintervenciones.Split(delimiter)

                For i As Integer = 0 To substrings.Length - 1
                    If chkQuimioterapia.Tag = substrings(i).ToString Then
                        chkQuimioterapia.Checked = True
                    End If
                    If chkRadioterapia.Tag = substrings(i).ToString Then
                        chkRadioterapia.Checked = True
                    End If
                    If chkSedacionPaliativa.Tag = substrings(i).ToString Then
                        chkSedacionPaliativa.Checked = True
                    End If
                Next

                'If oIngresoaPrograma.Elpacienteestarecibiendoalgunadelassiguientesintervenciones.Substring(oIngresoaPrograma.Elpacienteestarecibiendoalgunadelassiguientesintervenciones.Length - 1).Contains("1") Then
                ' chkQuimioterapia.Checked = True
                ' End If
                'If oIngresoaPrograma.Elpacienteestarecibiendoalgunadelassiguientesintervenciones.Substring(oIngresoaPrograma.Elpacienteestarecibiendoalgunadelassiguientesintervenciones.Length - 1).Contains("2") Then
                'chkRadioterapia.Checked = True
                'End If
                'If oIngresoaPrograma.Elpacienteestarecibiendoalgunadelassiguientesintervenciones.Substring(oIngresoaPrograma.Elpacienteestarecibiendoalgunadelassiguientesintervenciones.Length - 1).Contains("3") Then
                'chkSedacionPaliativa.Checked = True
                ' End If
            End If

            ''Paciente
            If Not (oIngresoaPrograma.Conoceeldiagnostico_Paciente = Nothing) Then
                    If oIngresoaPrograma.Conoceeldiagnostico_Paciente.Substring(oIngresoaPrograma.Conoceeldiagnostico_Paciente.Length - 1).Contains("1") Then
                        RBSiConDiagn.Checked = True
                        RBNoConDiagn.Checked = False
                        RBParConDiagn.Checked = False
                    Else
                        If oIngresoaPrograma.Conoceeldiagnostico_Paciente.Substring(oIngresoaPrograma.Conoceeldiagnostico_Paciente.Length - 1).Contains("2") Then
                            RBSiConDiagn.Checked = False
                            RBNoConDiagn.Checked = True
                            RBParConDiagn.Checked = False
                        Else
                            RBSiConDiagn.Checked = False
                            RBNoConDiagn.Checked = False
                            RBParConDiagn.Checked = True
                        End If
                    End If
                End If

                If Not (oIngresoaPrograma.Conoceelpronostico_Paciente = Nothing) Then
                    If oIngresoaPrograma.Conoceelpronostico_Paciente.Substring(oIngresoaPrograma.Conoceelpronostico_Paciente.Length - 1).Contains("1") Then
                        RBSiConPron.Checked = True
                        RBNoConPron.Checked = False
                        RBParConPron.Checked = False
                    Else
                        If oIngresoaPrograma.Conoceelpronostico_Paciente.Substring(oIngresoaPrograma.Conoceelpronostico_Paciente.Length - 1).Contains("2") Then
                            RBSiConPron.Checked = False
                            RBNoConPron.Checked = True
                            RBParConPron.Checked = False
                        Else
                            RBSiConPron.Checked = False
                            RBNoConPron.Checked = False
                            RBParConPron.Checked = True
                        End If
                    End If
                End If

                If Not (oIngresoaPrograma.Pideinformacion_Paciente = Nothing) Then
                    If oIngresoaPrograma.Pideinformacion_Paciente.Substring(oIngresoaPrograma.Pideinformacion_Paciente.Length - 1).Contains("1") Then
                        RBSiPidInfo.Checked = True
                        RBNoPidInfo.Checked = False
                        RBParPidInfo.Checked = False
                    Else
                        If oIngresoaPrograma.Pideinformacion_Paciente.Substring(oIngresoaPrograma.Pideinformacion_Paciente.Length - 1).Contains("2") Then
                            RBSiPidInfo.Checked = False
                            RBNoPidInfo.Checked = True
                            RBParPidInfo.Checked = False
                        Else
                            RBSiPidInfo.Checked = False
                            RBNoPidInfo.Checked = False
                            RBParPidInfo.Checked = True
                        End If
                    End If

                End If

                If Not (oIngresoaPrograma.Pidequenoseleinforme_Paciente = Nothing) Then
                    If oIngresoaPrograma.Pidequenoseleinforme_Paciente.Substring(oIngresoaPrograma.Pidequenoseleinforme_Paciente.Length - 1).Contains("1") Then
                        RBSiPidNoInfo.Checked = True
                        RBNoPidNoInfo.Checked = False
                        RBParPidNoInfo.Checked = False
                    Else
                        If oIngresoaPrograma.Pidequenoseleinforme_Paciente.Substring(oIngresoaPrograma.Pidequenoseleinforme_Paciente.Length - 1).Contains("2") Then
                            RBSiPidNoInfo.Checked = False
                            RBNoPidNoInfo.Checked = True
                            RBParPidNoInfo.Checked = False
                        Else
                            RBSiPidNoInfo.Checked = False
                            RBNoPidNoInfo.Checked = False
                            RBParPidNoInfo.Checked = True
                        End If
                    End If
                End If


                ''Familia
                If Not (oIngresoaPrograma.Conoceeldiagnostico_Familia = Nothing) Then
                    If oIngresoaPrograma.Conoceeldiagnostico_Familia.Substring(oIngresoaPrograma.Conoceeldiagnostico_Familia.Length - 1).Contains("1") Then
                        RBSiComDiagFam.Checked = True
                        RBNoComDiagFam.Checked = False
                        RBParcComDiagFam.Checked = False
                    Else
                        If oIngresoaPrograma.Conoceeldiagnostico_Familia.Substring(oIngresoaPrograma.Conoceeldiagnostico_Familia.Length - 1).Contains("2") Then
                            RBSiComDiagFam.Checked = False
                            RBNoComDiagFam.Checked = True
                            RBParcComDiagFam.Checked = False
                        Else
                            RBSiComDiagFam.Checked = False
                            RBNoComDiagFam.Checked = False
                            RBParcComDiagFam.Checked = True
                        End If
                    End If
                End If

                If Not (oIngresoaPrograma.Conoceelpronostico_Familia = Nothing) Then
                    If oIngresoaPrograma.Conoceelpronostico_Familia.Substring(oIngresoaPrograma.Conoceelpronostico_Familia.Length - 1).Contains("1") Then
                        RBSiConPronFam.Checked = True
                        RBNoConPronFam.Checked = False
                        RBParConPronFam.Checked = False
                    Else
                        If oIngresoaPrograma.Conoceelpronostico_Familia.Substring(oIngresoaPrograma.Conoceelpronostico_Familia.Length - 1).Contains("2") Then
                            RBSiConPronFam.Checked = False
                            RBNoConPronFam.Checked = True
                            RBParConPronFam.Checked = False
                        Else
                            RBSiConPronFam.Checked = False
                            RBNoConPronFam.Checked = False
                            RBParConPronFam.Checked = True
                        End If
                    End If
                End If

                If Not (oIngresoaPrograma.Pideinformacion_Familia = Nothing) Then
                    If oIngresoaPrograma.Pideinformacion_Familia.Substring(oIngresoaPrograma.Pideinformacion_Familia.Length - 1).Contains("1") Then
                        RBSiPidInfoFam.Checked = True
                        RBNoPidInfoFam.Checked = False
                        RBParPidInfoFam.Checked = False
                    Else
                        If oIngresoaPrograma.Pideinformacion_Familia.Substring(oIngresoaPrograma.Pideinformacion_Familia.Length - 1).Contains("2") Then
                            RBSiPidInfoFam.Checked = False
                            RBNoPidInfoFam.Checked = True
                            RBParPidInfoFam.Checked = False
                        Else
                            RBSiPidInfoFam.Checked = False
                            RBNoPidInfoFam.Checked = False
                            RBParPidInfoFam.Checked = True
                        End If
                    End If
                End If

                If Not (oIngresoaPrograma.Pidequenoseleinforme_Familia = Nothing) Then
                    If oIngresoaPrograma.Pidequenoseleinforme_Familia.Substring(oIngresoaPrograma.Pidequenoseleinforme_Familia.Length - 1).Contains("1") Then
                        RBSiPidNoInfFam.Checked = True
                        RBNoPidNoInfFam.Checked = False
                        RBParPidNoInfFam.Checked = False
                    Else
                        If oIngresoaPrograma.Pidequenoseleinforme_Familia.Substring(oIngresoaPrograma.Pidequenoseleinforme_Familia.Length - 1).Contains("2") Then
                            RBSiPidNoInfFam.Checked = False
                            RBNoPidNoInfFam.Checked = True
                            RBParPidNoInfFam.Checked = False
                        Else
                            RBSiPidNoInfFam.Checked = False
                            RBNoPidNoInfFam.Checked = False
                            RBParPidNoInfFam.Checked = True
                        End If
                    End If
                End If

                If Not (oIngresoaPrograma.CercodeSilencio = Nothing) Then
                    If oIngresoaPrograma.CercodeSilencio.Substring(oIngresoaPrograma.CercodeSilencio.Length - 1).Contains("1") Then
                        Me.lblCercoSilencio.Text = "SI"
                    End If
                    If oIngresoaPrograma.CercodeSilencio.Substring(oIngresoaPrograma.CercodeSilencio.Length - 1).Contains("2") Then
                        Me.lblCercoSilencio.Text = "NO"
                    End If
                End If

                If Not (oIngresoaPrograma.Informacioninsuficiente = Nothing) Then
                    If oIngresoaPrograma.Informacioninsuficiente.Substring(oIngresoaPrograma.Informacioninsuficiente.Length - 1).Contains("1") Then
                        Me.lblInfIsuficiente.Text = "SI"
                    End If
                    If oIngresoaPrograma.Informacioninsuficiente.Substring(oIngresoaPrograma.Informacioninsuficiente.Length - 1).Contains("2") Then
                        Me.lblInfIsuficiente.Text = "NO"
                    End If
                End If


        Catch ex As Exception
            'If (ex.Message.ToString() <> "ERROR") Then  ''WACHV, VALIDAR ERROR
            Throw (ex)
            'End If
        End Try
    End Sub
    ''WACHV, SE INACTIVA EL DIA 02 DE FEBRERO, DEJAR PARA TODOS LOS CASOS ACTIVA
    ''WACHV,16ene2017, Activar control de fecha si estan egresado en caso contrario Inactivarlo
    'Public Sub ActivarIngreso()
    '    If (BLValoracioneIngreso.intAlarmaPaliativo(objGeneral, objPaciente) = 1) Then
    '        mskIngProg.Enabled = False
    '    Else
    '        mskIngProg.Enabled = True
    '    End If
    'End Sub

    Private Sub ctlIngresoaPrograma_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged
        If sender.Visible = True Then
            ''WACHV, SE INACTIVA EL DIA 02 DE FEBRERO, DEJAR PARA TODOS LOS CASOS ACTIVA
            'ActivarIngreso()
            ''WACHV, 21SEPT2017, TRAER LA ULTIMA SOLO LA FECHA
            ''Si esta egresado La fecha debe quedar habilitada
            ''Si es Con parametro True analiza opcion si esta ingresado en paliativo para activa o Inactivar los controles.
            LimpiarDatos(True)
            If fncLeerUltimasRespuestas(False) = False Then
            End If
        End If
    End Sub

    Private Sub mskIngProg_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles mskIngProg.MaskInputRejected

    End Sub
End Class
